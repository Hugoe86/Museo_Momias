using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Reportes.Ingresos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using CrystalDecisions.CrystalReports.Engine;
using ERP_BASE.Paginas.Catalogos.Generales;
using ERP_BASE.App_Code.Reporte;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Catalogos.Turnos.Negocio;
using Erp.Constantes;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using OfficeOpenXml.Drawing.Chart;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rep_Mensual_Ingresos : Form
    {
        #region Load
        //*******************************************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <returns>un datatable con el resultado de la consulta</returns>
        /// <creo></creo>
        /// <fecha_creo></fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public Frm_Rep_Mensual_Ingresos()
        {
            InitializeComponent();
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento Load para el formulario: carga de combos y configuración inicial del formulario
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico>Héctor Gabriel Galicia Luna</modifico>
        /// <fecha_modifico>03-Mar-2015</fecha_modifico>
        /// <causa_modificacion>Se agregan los filtros de Turno, Tipo de Pago y Número de Caja</causa_modificacion>
        private void Frm_Rep_Mensual_Ingresos_Load(object sender, EventArgs e)
        {
            Boolean Bol_Seleccion_Anio = false;
            DataTable Dt_Consultas = new DataTable(); ;
            DataRow Fila;
            Cls_Cat_Turnos_Negocio Rs_Turnos = new Cls_Cat_Turnos_Negocio();// Se consultan los Turnos

            try
            {
                //  años **********************************************************************
                for (int Cont_For = DateTime.Now.Year; Cont_For >= 2009; Cont_For--)
                {
                    if (Cont_For == DateTime.Now.Year) Bol_Seleccion_Anio = true;
                    else Bol_Seleccion_Anio = false;

                    Chk_ListB_Periodo_Anio.Items.Add(Cont_For.ToString(), Bol_Seleccion_Anio);
                }

                //  turnos **********************************************************************
                Dt_Consultas = Rs_Turnos.Consultar_Turnos();
                Fila = Dt_Consultas.NewRow();
                Fila[Cat_Turnos.Campo_Turno_ID] = string.Empty;
                Fila[Cat_Turnos.Campo_Nombre] = string.Empty;
                Dt_Consultas.Rows.InsertAt(Fila, 0);

                Cmb_Turno.DataSource = Dt_Consultas.Copy();
                Cmb_Turno.DisplayMember = Cat_Turnos.Campo_Nombre;
                Cmb_Turno.ValueMember = Cat_Turnos.Campo_Turno_ID;

                Dt_Consultas.Dispose();

                //  cajas *****************************************************************************
                // Se consulta las Cajas con el Estatus de 'ACTIVO'.
                Cls_Cat_Cajas_Negocio Cajas = new Cls_Cat_Cajas_Negocio();
                Cajas.P_Estatus = "ACTIVO";
                Dt_Consultas = Cajas.Consultar_Caja();
                Fila = Dt_Consultas.NewRow();
                Fila[Cat_Cajas.Campo_Caja_ID] = string.Empty;
                Fila[Cat_Cajas.Campo_Numero_Caja] = DBNull.Value;
                Dt_Consultas.Rows.InsertAt(Fila, 0);

                Cmb_Numero_Caja.DataSource = Dt_Consultas.Copy();
                Cmb_Numero_Caja.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
                Cmb_Numero_Caja.ValueMember = Cat_Cajas.Campo_Caja_ID;

                Dt_Consultas.Dispose();

                // productos *****************************************************************************
                Cls_Cat_Productos_Negocio Neg_Productos = new Cls_Cat_Productos_Negocio();
                DataTable Dt_Productos = Neg_Productos.Consultar_Producto();


                for (int i = 0; i < Dt_Productos.Rows.Count; i++)
                {
                    Dt_Productos.Rows[i]["Nombre"] = Dt_Productos.Rows[i]["Nombre"].ToString().Trim();
                    Dt_Productos.Rows[i]["Nombre"] = "  " + Dt_Productos.Rows[i]["Nombre"].ToString();
                }

                Dt_Productos = (from Dt_P in Dt_Productos.AsEnumerable()
                                orderby Dt_P.Field<int>("Anio") descending
                                select Dt_P).CopyToDataTable();

                var Dt_Productos_Anios = from Dt_P in Dt_Productos.AsEnumerable()
                                         group Dt_P by Dt_P.Field<int>("Anio") into g
                                         select new
                                         {
                                             Anio = g.Key,
                                             Total = g.Count()
                                         };

                int Pos = 0;
                foreach (var x in Dt_Productos_Anios)
                {
                    DataRow Anio = Dt_Productos.NewRow();
                    Anio["Nombre"] = x.Anio.ToString();

                    Dt_Productos.Rows.InsertAt(Anio, Pos);
                    Pos += x.Total + 1;
                }

                Chk_ListB_Periodo_Tarifa.DataSource = Dt_Productos;
                Chk_ListB_Periodo_Tarifa.DisplayMember = Cat_Productos.Campo_Nombre;
                Chk_ListB_Periodo_Tarifa.ValueMember = Cat_Productos.Campo_Producto_Id;
                Chk_ListB_Periodo_Tarifa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion Load

        #region METODOS

        ///*******************************************************************************************************
        /// <summary>
        /// Realiza la consulta de la informacion
        /// </summary>
        /// <param name="Int_Tipo_Reporte">Consulta que se estara ejecutna</param>
        /// <returns>un datatable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Consulta_Ingresos_Accesos(int Int_Tipo_Reporte)
        {
            Cls_Rep_Ingresos_Negocio Rs_Consulta = new Cls_Rep_Ingresos_Negocio();
            String Str_Tarifa_Id = "";
            String Str_Anios = "";
            String Str_Meses = "";
            DataRow Dr_Tarifa;
            String Str_Producto_Id = "";
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Ventas_Mixtas = new DataTable();
            DataTable Dt_Venta_Detalle = new DataTable();
            DataTable Dt_Venta_Detalle_Pago = new DataTable();

            try
            {
                //  años ******************************************************************
                if (Chk_ListB_Periodo_Anio.CheckedItems.Count != 0)
                {
                    for (int x = 0; x <= Chk_ListB_Periodo_Anio.CheckedItems.Count - 1; x++)
                    {
                        Str_Anios += Chk_ListB_Periodo_Anio.CheckedItems[x].ToString() + ",";
                    }
                }

                if (Str_Anios.Length > 0)
                    Str_Anios = Str_Anios.Remove(Str_Anios.Length - 1);

                if (!String.IsNullOrEmpty(Str_Anios))
                    Rs_Consulta.P_Anios_Busqueda = Str_Anios;


                //  meses ********************************************************************
                Dictionary< string, Int32> Dic_Meses = Crear_Diccionario_Meses();

                if (Chk_ListB_Periodo_Meses.CheckedItems.Count != 0)
                {
                    for (int x = 0; x <= Chk_ListB_Periodo_Meses.CheckedItems.Count - 1; x++)
                    {
                        if (Dic_Meses.ContainsKey(Chk_ListB_Periodo_Meses.CheckedItems[x].ToString()) == true)
                        {
                            Str_Meses += Dic_Meses[Chk_ListB_Periodo_Meses.CheckedItems[x].ToString()] + ",";
                        }
                    }
                }

                if (Str_Meses.Length > 0)
                    Str_Meses = Str_Meses.Remove(Str_Meses.Length - 1);

                if (!String.IsNullOrEmpty(Str_Meses))
                    Rs_Consulta.P_Meses_Busqueda= Str_Meses;


                //  tarifa ***********************************************************
                for (int i = 0; i < Chk_ListB_Periodo_Tarifa.CheckedItems.Count; i++)
                {
                    Dr_Tarifa = ((DataRowView)this.Chk_ListB_Periodo_Tarifa.CheckedItems[i]).Row;
                    Str_Producto_Id = (Dr_Tarifa[this.Chk_ListB_Periodo_Tarifa.ValueMember]).ToString();

                    if (!String.IsNullOrEmpty(Str_Producto_Id))
                        Str_Tarifa_Id += "'" + Str_Producto_Id + "',";

                    Dr_Tarifa = null;
                }
                             
                if (Str_Tarifa_Id.Length > 0)
                    Str_Tarifa_Id = Str_Tarifa_Id.Remove(Str_Tarifa_Id.Length - 1);

                
                if (!String.IsNullOrEmpty(Str_Tarifa_Id))
                {
                    Rs_Consulta.P_Tarifa_Id = Str_Tarifa_Id;
                }

                //  tipo de pago **************************************************
                if (Cmb_Tipo_Pago.SelectedIndex > -1)
                {
                    if (Cmb_Tipo_Pago.SelectedIndex == 1)//debito y credito
                        Rs_Consulta.P_Forma_ID = "00003";
                    else
                        Rs_Consulta.P_Forma_ID = "00001";// efectivo
                }

                if (Cmb_Turno.SelectedIndex > 0)
                    Rs_Consulta.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();

                if (Cmb_Numero_Caja.SelectedIndex > 0)
                    Rs_Consulta.P_Numero_Caja = Cmb_Numero_Caja.SelectedValue.ToString();

              

                if (Cmb_Lugar_Venta.Text is object)
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                        Rs_Consulta.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                //  se ejecuta el reporte
                if (Int_Tipo_Reporte == 0)
                {
                    Dt_Ventas_Mixtas = Rs_Consulta.Consultar_Ventas_Dia_Mixtas();
                    String No_Ventas_Pago_Mixto = "";

                    foreach (DataRow Registro in Dt_Ventas_Mixtas.Rows)
                    {
                        No_Ventas_Pago_Mixto += "'" +Registro["No_Venta"].ToString() + "',";
                    }

                    //  se remueve la ultima coma
                    if (No_Ventas_Pago_Mixto.Length > 0)
                    {
                        No_Ventas_Pago_Mixto = No_Ventas_Pago_Mixto.Remove(No_Ventas_Pago_Mixto.Length - 1);
                        Rs_Consulta.P_No_Venta_Mixto = No_Ventas_Pago_Mixto;
                    }


                    Dt_Consulta = Rs_Consulta.Consultar_Ingresos_Mensual_Tarifa();

                    //  se ingresaran los valores de los pagos mixtos
                    if (Dt_Ventas_Mixtas != null && Dt_Ventas_Mixtas.Rows.Count > 0)
                    {
                        foreach (DataRow Registo in Dt_Ventas_Mixtas.Rows)
                        {
                            //  se obtendra el detalle de la venta y el pago mixto
                            Rs_Consulta.P_No_Venta_Detalle = Registo["No_Venta"].ToString();
                            Dt_Venta_Detalle = Rs_Consulta.Consultar_No_Venta_Detalle();
                            Dt_Venta_Detalle_Pago = Rs_Consulta.Consultar_No_Venta_Detalle_Pago();

                            Double Db_Efectivo = 0;
                            Double Db_Tarjeta = 0;

                            foreach (DataRow Registro_Pagos in Dt_Venta_Detalle_Pago.Rows)
                            {
                                Db_Efectivo = Convert.ToDouble(Registro_Pagos["Efectivo"].ToString());
                                Db_Tarjeta = Convert.ToDouble(Registro_Pagos["Tarjeta"].ToString());
                            }

                            foreach (DataRow Registro_Detalle in Dt_Venta_Detalle.Rows)
                            {
                                //  se realizara la busqueda de la
                                foreach (DataRow Registro_General in Dt_Consulta.Rows)
                                {
                                    if (Registro_General["tarifa"].ToString() == Registro_Detalle["nombre"].ToString()
                                        && Registro_General["anio"].ToString() == Registro_Detalle["año"].ToString()
                                        && Registro_General["mes"].ToString() == Registro_Detalle["mes"].ToString())
                                    {
                                        Registro_General.BeginEdit();

                                        //  sin filtro
                                        if (Cmb_Tipo_Pago.SelectedIndex == -1)
                                        {
                                            Registro_General["monto_pago"] = Convert.ToDouble(Registro_General["monto_pago"]) + Convert.ToDouble(Registro_Detalle["Total"].ToString());
                                        }
                                        else if (Cmb_Tipo_Pago.SelectedIndex == 0)//    efectivo
                                        {
                                            if (Db_Efectivo > 0)
                                            {
                                                //  validamos que el saldo sea menor al total
                                                if (Db_Efectivo <= Convert.ToDouble(Registro_Detalle["Total"].ToString()))
                                                {
                                                    Registro_General["monto_pago"] = Convert.ToDouble(Registro_General["monto_pago"]) + Db_Efectivo;
                                                    Db_Efectivo = 0;
                                                }
                                                else if (Db_Efectivo > Convert.ToDouble(Registro_Detalle["Total"].ToString()))
                                                {
                                                    Registro_General["monto_pago"] = Convert.ToDouble(Registro_General["monto_pago"]) + Convert.ToDouble(Registro_Detalle["Total"].ToString());
                                                    Db_Efectivo = Db_Efectivo - Convert.ToDouble(Registro_Detalle["Total"].ToString());
                                                }
                                            }
                                        }
                                        else if (Cmb_Tipo_Pago.SelectedIndex == 1)//    Tarjeta
                                        {
                                            if (Db_Tarjeta > 0)
                                            {  
                                                //  validamos que el saldo sea menor al total
                                                if (Db_Tarjeta <= Convert.ToDouble(Registro_Detalle["Total"].ToString()))
                                                {
                                                    Registro_General["monto_pago"] = Convert.ToDouble(Registro_General["monto_pago"]) + Db_Tarjeta;
                                                    Db_Tarjeta = 0;
                                                }
                                                else if (Db_Tarjeta > Convert.ToDouble(Registro_Detalle["Total"].ToString()))
                                                {
                                                    Registro_General["monto_pago"] = Convert.ToDouble(Registro_General["monto_pago"]) + Convert.ToDouble(Registro_Detalle["Total"].ToString());
                                                    Db_Tarjeta = Db_Tarjeta - Convert.ToDouble(Registro_Detalle["Total"].ToString());
                                                }

                                            }
                                        }
                                        Registro_General.EndEdit();
                                        Registro_General.AcceptChanges();
                                    }
                                }
                            }
                        }
                    }
                }// fin de ingresos
                else if (Int_Tipo_Reporte == 1)//   visitantes
                {
                    Dt_Consulta = Rs_Consulta.Consultar_Accesos_Mensual_Tarifa();
                }// fin de visitantes
                else if (Int_Tipo_Reporte == 2)//   concentrado
                {
                    Dt_Ventas_Mixtas = Rs_Consulta.Consultar_Ventas_Dia_Mixtas();
                    String No_Ventas_Pago_Mixto = "";

                    foreach (DataRow Registro in Dt_Ventas_Mixtas.Rows)
                    {
                        No_Ventas_Pago_Mixto += "'" + Registro["No_Venta"].ToString() + "',";
                    }

                    //  se remueve la ultima coma
                    if (No_Ventas_Pago_Mixto.Length > 0)
                    {
                        No_Ventas_Pago_Mixto = No_Ventas_Pago_Mixto.Remove(No_Ventas_Pago_Mixto.Length - 1);
                        Rs_Consulta.P_No_Venta_Mixto = No_Ventas_Pago_Mixto;
                    }

                    Dt_Consulta = Rs_Consulta.Consultar_Ingresos_Accesos_Mensual();

                    //  se ingresaran los valores de los pagos mixtos
                    if (Dt_Ventas_Mixtas != null && Dt_Ventas_Mixtas.Rows.Count > 0)
                    {
                        foreach (DataRow Registo in Dt_Ventas_Mixtas.Rows)
                        {
                            //  se obtendra el detalle de la venta y el pago mixto
                            Rs_Consulta.P_No_Venta_Detalle = Registo["No_Venta"].ToString();
                            Dt_Venta_Detalle = Rs_Consulta.Consultar_No_Venta_Detalle();
                            Dt_Venta_Detalle_Pago = Rs_Consulta.Consultar_No_Venta_Detalle_Pago();

                            Double Db_Efectivo = 0;
                            Double Db_Tarjeta = 0;

                            foreach (DataRow Registro_Pagos in Dt_Venta_Detalle_Pago.Rows)
                            {
                                Db_Efectivo = Convert.ToDouble(Registro_Pagos["Efectivo"].ToString());
                                Db_Tarjeta = Convert.ToDouble(Registro_Pagos["Tarjeta"].ToString());
                            }


                            foreach (DataRow Registro_Detalle in Dt_Venta_Detalle.Rows)
                            {
                                //  se realizara la busqueda de la
                                foreach (DataRow Registro_General in Dt_Consulta.Rows)
                                {
                                    if (Registro_General["tipo"].ToString() == "Recaudacion"
                                        && Registro_General["anio_"].ToString() == Registro_Detalle["año"].ToString()
                                        && Registro_General["mes"].ToString() == Registro_Detalle["mes"].ToString())
                                    {
                                        Registro_General.BeginEdit();

                                        //  sin filtro
                                        if (Cmb_Tipo_Pago.SelectedIndex == -1)
                                        {
                                            Registro_General["Recaudacion_Visitantes"] = Convert.ToDouble(Registro_General["Recaudacion_Visitantes"]) + Convert.ToDouble(Registro_Detalle["Total"].ToString());
                                        }
                                        else if (Cmb_Tipo_Pago.SelectedIndex == 0)//    efectivo
                                        {
                                            if (Db_Efectivo > 0)
                                            {
                                                Registro_General["Recaudacion_Visitantes"] = Convert.ToDouble(Registro_General["Recaudacion_Visitantes"]) + Db_Efectivo;
                                                Db_Efectivo = 0;
                                            }
                                        }
                                        else if (Cmb_Tipo_Pago.SelectedIndex == 1)//    Tarjeta
                                        {
                                            if (Db_Tarjeta > 0)
                                            {
                                                Registro_General["Recaudacion_Visitantes"] = Convert.ToDouble(Registro_General["Recaudacion_Visitantes"]) + Db_Tarjeta;
                                                Db_Tarjeta = 0;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }

                }// fin de concentrado
            }
            catch (Exception Ex)
            {

                throw new Exception("[Consulta_Ingresos]: " + Ex.Message);
            }

            return Dt_Consulta;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtiene de la clase de negocio un listado de accesos por mes y año y lo regresa como datatable
        /// </summary>
        /// <param name="Periodo_Inicio">fecha inicial para la consulta</param>
        /// <param name="Periodo_Final">fecha final a incluir en la consulta</param>
        /// <returns>un datatable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Consulta_Accesos_Promedio()
        { 
            Cls_Rep_Ingresos_Negocio Rs_Consulta = new Cls_Rep_Ingresos_Negocio();
            String Str_Tarifa_Id = "";
            String Str_Anios = "";
            String Str_Meses = "";
            DataRow Dr_Tarifa;
            String Str_Producto_Id = "";
            DataTable Dt_Consulta = new DataTable();

            try
            {
               
                //  años ******************************************************************
                if (Chk_ListB_Periodo_Anio.CheckedItems.Count != 0)
                {
                    for (int x = 0; x <= Chk_ListB_Periodo_Anio.CheckedItems.Count - 1; x++)
                    {
                        Str_Anios += Chk_ListB_Periodo_Anio.CheckedItems[x].ToString() + ",";
                    }
                }

                if (Str_Anios.Length > 0)
                    Str_Anios = Str_Anios.Remove(Str_Anios.Length - 1);

                if (!String.IsNullOrEmpty(Str_Anios))
                    Rs_Consulta.P_Anios_Busqueda = Str_Anios;


                //  meses ********************************************************************
                Dictionary<string, Int32> Dic_Meses = Crear_Diccionario_Meses();

                if (Chk_ListB_Periodo_Meses.CheckedItems.Count != 0)
                {
                    for (int x = 0; x <= Chk_ListB_Periodo_Meses.CheckedItems.Count - 1; x++)
                    {
                        if (Dic_Meses.ContainsKey(Chk_ListB_Periodo_Meses.CheckedItems[x].ToString()) == true)
                        {
                            Str_Meses += Dic_Meses[Chk_ListB_Periodo_Meses.CheckedItems[x].ToString()] + ",";
                        }
                    }
                }

                if (Str_Meses.Length > 0)
                    Str_Meses = Str_Meses.Remove(Str_Meses.Length - 1);

                if (!String.IsNullOrEmpty(Str_Meses))
                    Rs_Consulta.P_Meses_Busqueda = Str_Meses;


                //  tarifa ***********************************************************
                for (int i = 0; i < Chk_ListB_Periodo_Tarifa.CheckedItems.Count; i++)
                {
                    Dr_Tarifa = ((DataRowView)this.Chk_ListB_Periodo_Tarifa.CheckedItems[i]).Row;
                    Str_Producto_Id = (Dr_Tarifa[this.Chk_ListB_Periodo_Tarifa.ValueMember]).ToString();

                    if (!String.IsNullOrEmpty(Str_Producto_Id))
                        Str_Tarifa_Id += "'" + Str_Producto_Id + "',";

                    Dr_Tarifa = null;
                }

                if (Str_Tarifa_Id.Length > 0)
                    Str_Tarifa_Id = Str_Tarifa_Id.Remove(Str_Tarifa_Id.Length - 1);


                if (!String.IsNullOrEmpty(Str_Tarifa_Id))
                {
                    Rs_Consulta.P_Tarifa_Id = Str_Tarifa_Id;
                }


                //  tipo de pago ***********************************************************
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if (Cmb_Tipo_Pago.SelectedIndex == 1)
                        Rs_Consulta.P_Forma_ID = "00001";
                    else
                        Rs_Consulta.P_Forma_ID = "00002";
                }

                //  numero de caja ***********************************************************
                if (Cmb_Numero_Caja.SelectedIndex > 0)
                    Rs_Consulta.P_Numero_Caja = Cmb_Numero_Caja.SelectedValue.ToString();

                //  turno ***********************************************************
                if (Cmb_Turno.SelectedIndex > 0)
                    Rs_Consulta.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();

                //  lugar de la venta ***********************************************************
                if (Cmb_Lugar_Venta.Text is object)
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                        Rs_Consulta.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                return Rs_Consulta.Consultar_Accesos_Promedio_Tarifa();
            }
            catch (Exception Ex)
            {

                throw new Exception("[Consulta_Accesos]: " + Ex.Message);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// forma un datatable con ingresos y accesos por mes, año y tarifa y totales a partir de las tablas 
        /// con ingresos y accesos agrupados por año y mes
        /// </summary>
        /// <param name="Dt_Ingresos_Accesos">datatable con los ingresos o accesos agrupados por número de mes, año y tarifa</param>
        /// <returns>un datatable con los ingresos y accesos por año, nombre de mes, total por mes y total por año</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Generar_Tabla_Resultado(DataTable Dt_Ingresos_Accesos)
        {
            try
            {
                DataTable Dt_Resultados = Formar_Tabla_Resultado(0);
                DataRow Dr_Nueva_Fila_Ingreso;
                DataTable Dt_Ingresos_Anio;
                int Numero_Mes;
                decimal Total_Ingresos;
                decimal Monto_Mes;
                DataTable Dt_Posiciones = new DataTable();


                Dt_Posiciones = Formar_Tabla_Posicion_Meses();
              


                // obtener los diferentes años en la consulta
                var Dt_Anios = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                select new { anio = Fila_Ingresos.Field<int>("anio") }).Distinct();
              
                // recorrer Dt_Anios
                foreach (var row in Dt_Anios.Reverse())
                {
                    // obtener las diferentes tarifas en la tabla
                    var Dt_Tarifas = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                      where Fila_Ingresos.Field<int>("anio") == row.anio
                                      select new { tarifa = Fila_Ingresos.Field<string>("tarifa") }).Distinct();

                    // bucle para sumar todas las tarifas
                    foreach (var Fila_Tarifa in Dt_Tarifas)
                    {
                        // nueva fila
                        Dr_Nueva_Fila_Ingreso = Dt_Resultados.NewRow();
                        // asignar el año
                        Dr_Nueva_Fila_Ingreso[0] = row.anio;
                        // asignar las tarifas
                        Dr_Nueva_Fila_Ingreso[1] = Fila_Tarifa.tarifa;

                        // subconsulta linq para filtrar ingresos por año
                        Dt_Ingresos_Anio = (from Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                            where Fila_Ingresos.Field<int>("anio") == row.anio
                                            && Fila_Ingresos.Field<string>("tarifa") == Fila_Tarifa.tarifa
                                            select Fila_Ingresos).AsDataView().ToTable();
                        Total_Ingresos = 0;

                        int Cont_Insercion_Meses = 1;
                        int Cont_Posicion = 0;
                        // recorrer la tabla de ingresos por año para llenar los montos por mes y total
                        foreach (DataRow Fila_Ingreso in Dt_Ingresos_Anio.Rows)
                        {
                            //  numero de mes
                            for (int X = 0; X < Dt_Posiciones.Rows.Count; X++)
                            {
                                if (Dt_Posiciones.Rows[X]["mes"].ToString() == Fila_Ingreso["mes"].ToString())
                                {
                                    int.TryParse(Fila_Ingreso[1].ToString(), out Numero_Mes);

                                    //  monto del mes
                                    decimal.TryParse(Fila_Ingreso[2].ToString(), out Monto_Mes);

                                    Dr_Nueva_Fila_Ingreso[Cont_Insercion_Meses + Convert.ToInt32(Dt_Posiciones.Rows[X]["posicion"].ToString())] = Monto_Mes;
                                    Total_Ingresos += Monto_Mes;
                                    break;
                                }
                            }




                        }
                        Dr_Nueva_Fila_Ingreso["TOTAL"] = Total_Ingresos;

                        // agregar filas a la tabla
                        Dt_Resultados.Rows.Add(Dr_Nueva_Fila_Ingreso);
                    }
                }

                return Dt_Resultados;
            }
            catch (Exception Ex)
            {

                throw new Exception("[Generar_Tabla_Resultado]: " + Ex.Message);
            }
        }


        ///*******************************************************************************************************
        /// <summary>
        /// forma un datatable con el promedio de accesos por mes, año y tarifa y totales a partir de las tablas 
        /// con ingresos y accesos agrupados por año y mes
        /// </summary>
        /// <param name="Dt_Ingresos_Accesos">datatable con los ingresos o accesos agrupados por número de mes, año y tarifa</param>
        /// <returns>un datatable con los ingresos y accesos por año, nombre de mes, total por mes y total por año</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Generar_Tabla_Promedio_Resultado(DataTable Dt_Ingresos_Accesos)
        {
            try
            {
                DataTable Dt_Resultados = Formar_Tabla_Resultado(1);
                DataRow Dr_Nueva_Fila_Ingreso;
                DataTable Dt_Ingresos_Anio;
                int Numero_Mes;
                decimal Total_Ingresos;
                decimal Dec_Promedio;
                DataTable Dt_Posiciones = new DataTable();


                Dt_Posiciones = Formar_Tabla_Posicion_Meses();



                // obtener los diferentes años en la consulta
                var Dt_Anios = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                select new { anio = Fila_Ingresos.Field<int>("anio") }).Distinct();

                // recorrer Dt_Anios
                foreach (var row in Dt_Anios.Reverse())
                {
                    // obtener las diferentes tarifas en la tabla
                    var Dt_Tarifas = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                      where Fila_Ingresos.Field<int>("anio") == row.anio
                                      select new { tarifa = Fila_Ingresos.Field<string>("tarifa") }).Distinct();

                    // bucle para sumar todas las tarifas
                    foreach (var Fila_Tarifa in Dt_Tarifas)
                    {
                        // nueva fila
                        Dr_Nueva_Fila_Ingreso = Dt_Resultados.NewRow();
                        // asignar el año
                        Dr_Nueva_Fila_Ingreso[0] = row.anio;
                        // asignar las tarifas
                        Dr_Nueva_Fila_Ingreso[1] = Fila_Tarifa.tarifa;

                        // subconsulta linq para filtrar ingresos por año
                        Dt_Ingresos_Anio = (from Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                            where Fila_Ingresos.Field<int>("anio") == row.anio
                                            && Fila_Ingresos.Field<string>("tarifa") == Fila_Tarifa.tarifa
                                            select Fila_Ingresos).AsDataView().ToTable();
                        Total_Ingresos = 0;

                        int Cont_Insercion_Meses = 1;
                        int Cont_Posicion = 0;
                        // recorrer la tabla de ingresos por año para llenar los montos por mes y total
                        foreach (DataRow Fila_Ingreso in Dt_Ingresos_Anio.Rows)
                        {
                            //  numero de mes
                            for (int X = 0; X < Dt_Posiciones.Rows.Count; X++)
                            {
                                if (Dt_Posiciones.Rows[X]["mes"].ToString() == Fila_Ingreso["mes"].ToString())
                                {
                                    //  promedio del mes
                                    decimal.TryParse(Fila_Ingreso["promedio"].ToString(), out Dec_Promedio);
                                    Dec_Promedio = Math.Round(Dec_Promedio, 0);
                                    Dr_Nueva_Fila_Ingreso[Cont_Insercion_Meses + Convert.ToInt32(Dt_Posiciones.Rows[X]["posicion"].ToString())] = Dec_Promedio;
                                    break;
                                }
                            }
                            
                        }

                        // agregar filas a la tabla
                        Dt_Resultados.Rows.Add(Dr_Nueva_Fila_Ingreso);
                    }
                }

                return Dt_Resultados;
            }
            catch (Exception Ex)
            {

                throw new Exception("[Generar_Tabla_Resultado]: " + Ex.Message);
            }
        }


        ///*******************************************************************************************************
        /// <summary>
        /// forma un datatable con ingresos y accesos por mes, año y tarifa y totales a partir de las tablas 
        /// con ingresos y accesos agrupados por año y mes
        /// </summary>
        /// <param name="Dt_Ingresos_Accesos_Concentrado">datatable con los ingresos o accesos agrupados por número de mes, año y tarifa</param>
        /// <returns>un datatable con los ingresos y accesos por año, nombre de mes, total por mes y total por año</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Generar_Tabla_Concentrado_Resultado(DataTable Dt_Ingresos_Accesos_Concentrado)
        {
            DataTable Dt_Resultados = Formar_Tabla_Resultado(0);
            DataRow Dr_Nueva_Fila_Ingreso;
            DataTable Dt_Ingresos_Anio = null;
            int Numero_Mes;
            decimal Total_Ingresos;
            decimal Monto_Mes;

            try
            {
                //  se agrega una nueva columna, ya que la que arroja la consulta marca conflictos
                Dt_Ingresos_Accesos_Concentrado.Columns.Add("Anio", typeof(int));

                foreach (DataRow Registro in Dt_Ingresos_Accesos_Concentrado.Rows)
                {
                    Registro.BeginEdit();
                    Registro["Anio"] = Convert.ToInt16(Registro["Anio_"].ToString());
                    Registro.EndEdit();
                    Registro.AcceptChanges();
                }

                Dt_Ingresos_Accesos_Concentrado.Columns.RemoveAt(0);
                Dt_Ingresos_Accesos_Concentrado.AcceptChanges();

                // obtener los diferentes años en la consulta
                var Dt_Anios = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos_Concentrado.AsEnumerable()
                                select new { anio = Fila_Ingresos.Field<int>("anio") }).Distinct();

                // recorrer Dt_Anios
                foreach (var row in Dt_Anios.Reverse())
                {
                    // obtener las diferentes tarifas en la tabla
                    var Dt_Tarifas = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos_Concentrado.AsEnumerable()
                                      where Fila_Ingresos.Field<int>("anio") == row.anio
                                      select new { Tipo = Fila_Ingresos.Field<string>("Tipo") }).Distinct();

                    // bucle para sumar todas las tarifas
                    foreach (var Fila_Tarifa in Dt_Tarifas)
                    {
                        // nueva fila
                        Dr_Nueva_Fila_Ingreso = Dt_Resultados.NewRow();
                        // asignar el año
                        Dr_Nueva_Fila_Ingreso[0] = row.anio;
                        // asignar las tarifas
                        Dr_Nueva_Fila_Ingreso[1] = Fila_Tarifa.Tipo;

                        // subconsulta linq para filtrar ingresos por año
                        Dt_Ingresos_Anio = (from Fila_Ingresos in Dt_Ingresos_Accesos_Concentrado.AsEnumerable()
                                            where Fila_Ingresos.Field<int>("anio") == row.anio
                                            && Fila_Ingresos.Field<string>("tipo") == Fila_Tarifa.Tipo
                                            select Fila_Ingresos).AsDataView().ToTable();
                        Total_Ingresos = 0;

                        int Cont_Insercion_Meses = 2;
                        // recorrer la tabla de ingresos por año para llenar los montos por mes y total
                        foreach (DataRow Fila_Ingreso in Dt_Ingresos_Anio.Rows)
                        {
                            //  numero de mes
                            int.TryParse(Fila_Ingreso[0].ToString(), out Numero_Mes);

                            //  monto del mes
                            decimal.TryParse(Fila_Ingreso[1].ToString(), out Monto_Mes);

                            Dr_Nueva_Fila_Ingreso[Cont_Insercion_Meses] = Monto_Mes;
                            Total_Ingresos += Monto_Mes;
                            Cont_Insercion_Meses++;
                        }
                        Dr_Nueva_Fila_Ingreso["TOTAL"] = Total_Ingresos;

                        // agregar filas a la tabla
                        Dt_Resultados.Rows.Add(Dr_Nueva_Fila_Ingreso);
                    }
                }

                return Dt_Resultados;
            }
            catch (Exception Ex)
            {
                throw new Exception("[Generar_Tabla_Concentrado_Resultado]: " + Ex.Message);
            }
        }

        /////*******************************************************************************************************
        ///// <summary>
        ///// genera un datatable nuevo con los campos para la 
        ///// </summary>
        ///// <returns>un datatable con los campos para mostrar accesos e ingresos por año y mes</returns>
        ///// <creo>Roberto González Oseguera</creo>
        ///// <fecha_creo>28-may-2014</fecha_creo>
        ///// <modifico></modifico>
        ///// <fecha_modifico></fecha_modifico>
        ///// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Formar_Tabla_Resultado(int Opcion_Total)
        {
            DataTable Dt_Resultado = new DataTable();
            Dt_Resultado.Columns.Add(new DataColumn("AÑO", typeof(int)));
            Dt_Resultado.Columns.Add(new DataColumn("TARIFA", typeof(string)));

            foreach (Object Registros in Chk_ListB_Periodo_Meses.CheckedItems)
            {
                if (Registros.ToString() == "Enero")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("ENE", typeof(decimal)));
                }
                else if (Registros.ToString() == "Febrero")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("FEB", typeof(decimal)));
                }
                else if (Registros.ToString() == "Marzo")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("MAR", typeof(decimal)));
                }
                else if (Registros.ToString() == "Abril")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("ABR", typeof(decimal)));
                }
                else if (Registros.ToString() == "Mayo")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("MAY", typeof(decimal)));
                }
                else if (Registros.ToString() == "Junio")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("JUN", typeof(decimal)));
                }
                else if (Registros.ToString() == "Julio")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("JUL", typeof(decimal)));
                }
                else if (Registros.ToString() == "Agosto")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("AGO", typeof(decimal)));
                }
                else if (Registros.ToString() == "Septiembre")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("SEP", typeof(decimal)));
                }
                else if (Registros.ToString() == "Octubre")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("OCT", typeof(decimal)));
                }
                else if (Registros.ToString() == "Noviembre")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("NOV", typeof(decimal)));                    
                }
                else if (Registros.ToString() == "Diciembre")
                {
                    Dt_Resultado.Columns.Add(new DataColumn("DIC", typeof(decimal)));                    
                }
            }

            int Cont_For = 0;
            foreach (DataColumn Columna in Dt_Resultado.Columns)
            {
                if (Cont_For >= 2)
                {
                    Dt_Resultado.Columns[Cont_For].DefaultValue = 0M;
                }
                Cont_For++;
            }

            if (Opcion_Total == 0)
                Dt_Resultado.Columns.Add(new DataColumn("TOTAL", typeof(decimal)));
            

            Dt_Resultado.TableName = "Dt_Ingresos";

            return Dt_Resultado;
        }

        /////*******************************************************************************************************
        ///// <summary>
        ///// genera un datatable nuevo con los campos para la 
        ///// </summary>
        ///// <returns>un datatable con los campos para mostrar accesos e ingresos por año y mes</returns>
        ///// <creo>Roberto González Oseguera</creo>
        ///// <fecha_creo>28-may-2014</fecha_creo>
        ///// <modifico></modifico>
        ///// <fecha_modifico></fecha_modifico>
        ///// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Formar_Tabla_Posicion_Meses()
        {
            DataTable Dt_Resultado = new DataTable();
            DataRow Dr_Posicion;
            Dt_Resultado.Columns.Add("Mes", typeof(int));
            Dt_Resultado.Columns.Add("Posicion", typeof(int));
            int Cont_Registros = 1;

            foreach (Object Registros in Chk_ListB_Periodo_Meses.CheckedItems)
            {
                if (Registros.ToString() == "Enero")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 1;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Febrero")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 2;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Marzo")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 3;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Abril")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 4;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Mayo")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 5;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Junio")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 6;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Julio")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 7;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Agosto")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 8;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Septiembre")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 9;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Octubre")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 10;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Noviembre")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 11;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }
                else if (Registros.ToString() == "Diciembre")
                {
                    Dr_Posicion = Dt_Resultado.NewRow();
                    Dr_Posicion["Mes"] = 12;
                    Dr_Posicion["Posicion"] = Cont_Registros;
                    Dt_Resultado.Rows.Add(Dr_Posicion);
                }

                Cont_Registros++;
            }

            return Dt_Resultado;
        }

        /////*******************************************************************************************************
        ///// <summary>
        ///// genera un datatable nuevo con los campos para la 
        ///// </summary>
        ///// <returns>un datatable con los campos para mostrar accesos e ingresos por año y mes</returns>
        ///// <creo>Hugo Enrique Ramírez Aguilera</creo>
        ///// <fecha_creo>13-Enero-2016</fecha_creo>
        ///// <modifico></modifico>
        ///// <fecha_modifico></fecha_modifico>
        ///// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private Dictionary<Int32, String> Crear_Diccionario_Excel()
        {
            var Diccionario = new Dictionary<Int32, String>();

            Diccionario.Add(0, "A");
            Diccionario.Add(1, "B");
            Diccionario.Add(2, "C");
            Diccionario.Add(3, "D");
            Diccionario.Add(4, "E");
            Diccionario.Add(5, "F");
            Diccionario.Add(6, "G");
            Diccionario.Add(7, "H");
            Diccionario.Add(8, "I");
            Diccionario.Add(9, "J");
            Diccionario.Add(10, "K");
            Diccionario.Add(11, "L");
            Diccionario.Add(12, "M");
            Diccionario.Add(13, "N");

            return Diccionario;
        }

        /////*******************************************************************************************************
        ///// <summary>
        ///// genera un datatable nuevo con los campos para la 
        ///// </summary>
        ///// <returns>un datatable con los campos para mostrar accesos e ingresos por año y mes</returns>
        ///// <creo>Hugo Enrique Ramírez Aguilera</creo>
        ///// <fecha_creo>13-Enero-2016</fecha_creo>
        ///// <modifico></modifico>
        ///// <fecha_modifico></fecha_modifico>
        ///// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private Dictionary<string, Int32> Crear_Diccionario_Meses()
        {
            var Diccionario = new Dictionary<string, Int32>();

            Diccionario.Add("Enero", 1);
            Diccionario.Add("Febrero", 2);
            Diccionario.Add("Marzo", 3);
            Diccionario.Add("Abril", 4);
            Diccionario.Add("Mayo", 5);
            Diccionario.Add("Junio", 6);
            Diccionario.Add("Julio", 7);
            Diccionario.Add("Agosto", 8);
            Diccionario.Add("Septiembre", 9);
            Diccionario.Add("Octubre", 10);
            Diccionario.Add("Noviembre", 11);
            Diccionario.Add("Diciembre", 12);

            return Diccionario;
        }
        /////*******************************************************************************************************
        ///// <summary>
        ///// genera un datatable nuevo con los campos para la 
        ///// </summary>
        ///// <returns>un datatable con los campos para mostrar accesos e ingresos por año y mes</returns>
        ///// <creo>Hugo Enrique Ramírez Aguilera</creo>
        ///// <fecha_creo>13-Enero-2016</fecha_creo>
        ///// <modifico></modifico>
        ///// <fecha_modifico></fecha_modifico>
        ///// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private Dictionary<Int32, string> Crear_Diccionario_NumMeses_Texto()
        {
            var Diccionario = new Dictionary<Int32, string>();

            Diccionario.Add(1, "Enero");
            Diccionario.Add(2, "Febrero");
            Diccionario.Add(3, "Marzo");
            Diccionario.Add(4, "Abril");
            Diccionario.Add(5, "Mayo");
            Diccionario.Add(6, "Junio");
            Diccionario.Add(7, "Julio");
            Diccionario.Add(8, "Agosto");
            Diccionario.Add(9, "Septiembre");
            Diccionario.Add(10, "Octubre");
            Diccionario.Add(11, "Noviembre");
            Diccionario.Add(12, "Diciembre");

            return Diccionario;
        }

        /////*******************************************************************************************************
        ///// <summary>
        ///// genera un datatable nuevo con los campos para la 
        ///// </summary>
        ///// <returns>un datatable con los campos para mostrar accesos e ingresos por año y mes</returns>
        ///// <creo>Hugo Enrique Ramírez Aguilera</creo>
        ///// <fecha_creo>13-Enero-2016</fecha_creo>
        ///// <modifico></modifico>
        ///// <fecha_modifico></fecha_modifico>
        ///// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private Dictionary<string, string> Crear_Diccionario_AbrevMeses_Texto()
        {
            var Diccionario = new Dictionary<String, string>();

            Diccionario.Add("ENE", "Enero");
            Diccionario.Add("FEB", "Febrero");
            Diccionario.Add("MAR", "Marzo");
            Diccionario.Add("ABR", "Abril");
            Diccionario.Add("MAY", "Mayo");
            Diccionario.Add("JUN", "Junio");
            Diccionario.Add("JUL", "Julio");
            Diccionario.Add("AGO", "Agosto");
            Diccionario.Add("SEP", "Septiembre");
            Diccionario.Add("OCT", "Octubre");
            Diccionario.Add("NOV", "Noviembre");
            Diccionario.Add("DIC", "Diciembre");

            return Diccionario;
        }
        ///*******************************************************************************************************
        /// <summary>
        /// método que muestra el reporte en un diálogo (formulario Frm_Rpt_Mostrar_Reporte_)
        /// </summary>
        /// <param name="Ds_Reporte">Dataset con la información a mostrar en el reporte</param>
        /// <param name="Nombre_Plantilla_Reporte">nombre del archivo rpt del reporte a mostrar</param>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        protected void Generar_Reporte(DataSet Ds_Reporte, String Nombre_Plantilla_Reporte, DateTime Fecha_Primero_Mes, DateTime Fecha_Ultimo_Mes)
        {
            ReportDocument Reporte = new ReportDocument();//Variable de tipo reporte.
            try
            {
                Reporte.Load(Nombre_Plantilla_Reporte);

                // agregar dataset al reporte
                Reporte.SetDataSource(Ds_Reporte);
                Frm_Rpt_Mostrar_Reporte_ Frm_Mostrar_Reporte = new Frm_Rpt_Mostrar_Reporte_();

                //// asignar el periodo como parámetro del reporte
                //Reporte.DataDefinition.FormulaFields["periodo"].Text = "ToText('Periodo: " + Fecha_Primero_Mes.ToLongDateString() + " - " + Fecha_Ultimo_Mes.ToLongDateString() + "')";
                //Reporte.DataDefinition.FormulaFields["fecha_esp"].Text = "ToText('" + DateTime.Now.ToLongDateString() + "')";

                Frm_Mostrar_Reporte.P_Reporte = Reporte;
                Frm_Mostrar_Reporte.ShowDialog(this);

                Reporte.Close();
                Reporte.Dispose();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte: [" + Ex.Message + "]");
            }
        }

         ///*******************************************************************************************************
        /// <summary>
        /// Genera la consulta 
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        protected DataTable Cambiar_Nombre_Columnas_Tabla(DataTable Dt_Consulta)
        {
             try
             {
                 Dictionary<string, string> Dic_Meses = Crear_Diccionario_AbrevMeses_Texto();

                 for (int Cont_For = 2; Cont_For <= Dt_Consulta.Columns.Count - 2; Cont_For++)
                 {
                     Dt_Consulta.Columns[Cont_For].ColumnName = Dic_Meses[Dt_Consulta.Columns[Cont_For].ColumnName.ToString()];
                 }
             }
             catch (Exception Ex)
             {
                 throw new Exception("Error al generar el reporte: [" + Ex.Message + "]");
             }
             return Dt_Consulta;
        }


        ///*******************************************************************************************************
        /// <summary>
        /// Genera la consulta 
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        protected DataTable Cambiar_Nombre_Columnas_Tabla_Promedio(DataTable Dt_Consulta)
        {
            try
            {
                Dictionary<string, string> Dic_Meses = Crear_Diccionario_AbrevMeses_Texto();

                for (int Cont_For = 2; Cont_For <= Dt_Consulta.Columns.Count - 1; Cont_For++)
                {
                    Dt_Consulta.Columns[Cont_For].ColumnName = Dic_Meses[Dt_Consulta.Columns[Cont_For].ColumnName.ToString()];
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte: [" + Ex.Message + "]");
            }
            return Dt_Consulta;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Genera la consulta 
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        protected DataTable Realizar_Consulta()
        {
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Resultado = new DataTable();
            Boolean Bol_Estatus = true;
             try
            {
                //  validamos que se encuentre seleccionado algun año
                if (Chk_ListB_Periodo_Anio.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar algun año", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Bol_Estatus = false;
                }
                else
                {
                    if (Chk_ListB_Periodo_Meses.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Debe seleccionar algun meses", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Bol_Estatus = false;
                    }
                }

                if (Bol_Estatus == true)
                {
                    //**************************************************************************************
                    // consultar por tipo de reporte (ingresos o accesos)
                    if (Rbt_Opc_Reporte_Ingresos.Checked)
                    {
                        Dt_Consulta = Consulta_Ingresos_Accesos(0);
                    }
                    else if (Rbt_Opc_Visitantes.Checked)
                    {
                        Dt_Consulta = Consulta_Ingresos_Accesos(1);
                    }
                    else if (Rbt_Opc_Concentrado.Checked)
                    {
                        Dt_Consulta = Consulta_Ingresos_Accesos(2);
                    }

                    //**************************************************************************************
                    //  se genera la tabla resultado
                    if ((Rbt_Opc_Reporte_Ingresos.Checked) || (Rbt_Opc_Visitantes.Checked))
                    {
                        Dt_Resultado = Generar_Tabla_Resultado(Dt_Consulta);
                    }
                    else
                    {
                        Dt_Resultado = Generar_Tabla_Concentrado_Resultado(Dt_Consulta);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte: [" + Ex.Message + "]");
            }
             
            return Dt_Resultado;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Genera la consulta 
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        protected String Parametros_Reporte_A_Mostrar()
        {
            String Str_Parametros = "";
            String Str_Anios = "";
            String Str_Meses = "";
            String Str_Producto_Id = "";
            String Str_Tarifa_Id = "";
            Boolean Estatus = false;
            DataRow Dr_Tarifa;
            
            try
            {
                //  años ******************************************************************
                if (Chk_ListB_Periodo_Anio.CheckedItems.Count != 0)
                {
                    for (int x = 0; x <= Chk_ListB_Periodo_Anio.CheckedItems.Count - 1; x++)
                    {
                        Str_Anios += Chk_ListB_Periodo_Anio.CheckedItems[x].ToString() + ", ";
                    }
                }

                if (Str_Anios.Length > 0)
                {
                    Str_Anios = Str_Anios.Remove(Str_Anios.Length - 1);
                    Str_Anios = Str_Anios.Remove(Str_Anios.Length - 1);
                }

                if (!String.IsNullOrEmpty(Str_Anios))
                {
                    Str_Parametros += "Periodo: Años " + Str_Anios;
                }


                //  meses ********************************************************************
                if (Chk_ListB_Periodo_Meses.CheckedItems.Count != 0)
                {
                    for (int x = 0; x <= Chk_ListB_Periodo_Meses.CheckedItems.Count - 1; x++)
                    {
                        Str_Meses += Chk_ListB_Periodo_Meses.CheckedItems[x].ToString() + ", ";
                    }
                }

                if (Str_Meses.Length > 0)
                {
                    Str_Meses = Str_Meses.Remove(Str_Meses.Length - 1);
                    Str_Meses = Str_Meses.Remove(Str_Meses.Length - 1);
                }

                if (!String.IsNullOrEmpty(Str_Meses))
                {
                    Str_Parametros += " en los meses de " + Str_Meses;
                    Str_Parametros += "\n";
                }

                //  tipo ******************************************************************
                Str_Parametros += "Tipo: ";
                if (Rbt_Opc_Reporte_Ingresos.Checked)
                {
                    Str_Parametros += "Recaudacion por tarifa";
                }
                else if (Rbt_Opc_Visitantes.Checked)
                {
                    Str_Parametros += "Visitantes por tarifa";
                }
                else if (Rbt_Opc_Concentrado.Checked)
                {
                    Str_Parametros += "Concentrado";
                }

                Estatus = true;

                //  tarifa ***********************************************************
                for (int i = 0; i < Chk_ListB_Periodo_Tarifa.CheckedItems.Count; i++)
                {
                    Dr_Tarifa = ((DataRowView)this.Chk_ListB_Periodo_Tarifa.CheckedItems[i]).Row;
                    Str_Producto_Id = (Dr_Tarifa[this.Chk_ListB_Periodo_Tarifa.DisplayMember]).ToString();

                    if (!String.IsNullOrEmpty(Str_Producto_Id))
                        Str_Tarifa_Id += "" + Str_Producto_Id + ",";

                    Dr_Tarifa = null;
                }

                if (Str_Tarifa_Id.Length > 0)
                    Str_Tarifa_Id = Str_Tarifa_Id.Remove(Str_Tarifa_Id.Length - 1);


                if (!String.IsNullOrEmpty(Str_Tarifa_Id))
                {
                    if (Estatus)
                        Str_Parametros += ", ";

                    Str_Parametros += "Tarifa: " + Str_Tarifa_Id;

                    Estatus = true;
                }

                //  tipo de pago **************************************************
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if (Estatus)
                        Str_Parametros += ", ";

                    Str_Parametros += "Tipo de pago: ";

                    if (Cmb_Tipo_Pago.SelectedIndex == 1)
                        Str_Parametros += "Efectivo";
                    else
                        Str_Parametros += "Credito-Debito";

                    Estatus = true;
                }

                //  turno ***************************************************************************
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    if (Estatus)
                        Str_Parametros += ", ";

                    Str_Parametros += "Turno: " + Cmb_Turno.Text;
                    Estatus = true;
                }

                //  numero de caja ***************************************************************************
                if (Cmb_Numero_Caja.SelectedIndex > 0)
                {
                    if (Estatus)
                        Str_Parametros += ", ";
                 
                   Str_Parametros += "Numero de caja: " +  Cmb_Numero_Caja.Text;
                   Estatus = true;
                }

                //  lugar de la venta ***************************************************************************
                if (Cmb_Lugar_Venta.Text is object)
                {
                    if (Cmb_Lugar_Venta.SelectedIndex > -1)
                    {
                        if (Estatus)
                            Str_Parametros += ", ";

                        Str_Parametros += "Lugar de la venta: " + Cmb_Lugar_Venta.Text;

                        Estatus = true;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte: [" + Ex.Message + "]");
            }

            return Str_Parametros;
        }



        #endregion METODOS



        #region EVENTOS

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón buscar: llamar al método que consulta la información y 
        /// carga el resultado en el grid
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            DataTable Dt_Resultado = new DataTable();
            try
            {
                Dt_Resultado = Realizar_Consulta();

                //  se carga el grid con la informacion de la consulta
                Grid_Resultado.DataSource = new DataTable();
                // cargar resultado en el grid
                Grid_Resultado.DataSource = Dt_Resultado;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Buscar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón exportar PDF: llamar al método que muestra el reporte
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            DateTime Fecha_Primero_Mes = new DateTime(); ;
            DateTime Fecha_Ultimo_Mes = new DateTime(); ;
            DataSet Ds_Reporte = new DataSet();
            String Nombre_Plantilla = "";
            DataTable Dt_Ingresos = new DataTable();

            try
            {

                //Dictionary<Int32, string> Dic_Meses = Crear_Diccionario_NumMeses_Texto();
                //Dt_Ingresos = Consulta_Ingresos_Accesos(0);

                //Dt_Ingresos.Columns.Add("mes_Anio");
                //foreach (DataRow Registro in Dt_Ingresos.Rows)
                //{
                //    Registro.BeginEdit();
                //    Registro["mes_anio"] = Dic_Meses[Convert.ToInt32(Registro["mes"].ToString())] + " " + Registro["Anio"].ToString();
                //    Registro.EndEdit();
                //    Registro.AcceptChanges();
                //}

                //Dt_Ingresos.TableName = "Dt_Recaudacion_Visitantes";
                //Ds_Reporte.Tables.Add(Dt_Ingresos.Copy());
                //Nombre_Plantilla = "Crs_Rep_Analisis_Mensual_Recaudacion.rpt";
                
                //// método que muestra el reporte
                //Generar_Reporte(Ds_Reporte, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + Nombre_Plantilla, Fecha_Primero_Mes, Fecha_Ultimo_Mes);


                //  ingresos
                //    Nombre_Plantilla = "Rpt_Mensual_Ingresos.rpt";
               

                ////// consultar detalles de ingresos o accesos
                //if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                //{
                //    DataTable Dt_Ingresos_Detalle = Consulta_Ingresos(Fecha_Primero_Mes, Fecha_Ultimo_Mes);
                //    Dt_Ingresos_Detalle = Agrupar_Mes_Anio(Dt_Ingresos_Detalle);
                //    Dt_Ingresos_Detalle.TableName = "Dt_Ingresos_Detalle";
                //    // agregar tabla al dataset, quitando la tabla con el mismo nombre
                //    Ds_Reporte.Tables.Add(Dt_Ingresos_Detalle);
                //    // si no hay una tarifa seleccionada, asignar el reporte mensual
                //    //if (Cmb_Tarifa.SelectedIndex <= 0)
                //    //{
                
                //    //}
                //    //else // asignar el reporte para una sola tarifa
                //    //{
                //    //    Nombre_Plantilla = "Rpt_Mensual_Ingresos_Tarifa.rpt";
                //    //}
                //}
                //else if (Cmb_Tipo_Reporte.Text.Equals("Visitantes"))
                //{
                //    DataTable Dt_Accesos_Detalle = Consulta_Accesos(Fecha_Primero_Mes, Fecha_Ultimo_Mes);
                //    DataTable Dt_Accesos_Promedio = Consulta_Accesos_Promedio(Fecha_Primero_Mes, Fecha_Ultimo_Mes);
                //    DataTable Dt_Accesos_Comportamiento = new DataTable();
                //    Dt_Accesos_Detalle = Agrupar_Mes_Anio(Dt_Accesos_Detalle);
                //    Dt_Accesos_Detalle.TableName = "Dt_Accesos_Detalle";

                //    Dt_Accesos_Comportamiento = Dt_Accesos_Promedio.Copy();
                //    Dt_Accesos_Comportamiento.TableName = "Dt_Comportamiento";
                //    Dt_Accesos_Promedio = Agrupar_Promedio(Dt_Accesos_Promedio);

                //    Dt_Accesos_Promedio.TableName = "Dt_Promedio";

                //    // agregar tabla al dataset, quitando la tabla con el mismo nombre
                //    Ds_Reporte.Tables.Add(Dt_Accesos_Detalle);
                //    Ds_Reporte.Tables.Add(Dt_Accesos_Promedio);
                //    Ds_Reporte.Tables.Add(Dt_Accesos_Comportamiento);

                //    // si no hay una tarifa seleccionada, asignar el reporte mensual
                //    //if (Cmb_Tarifa.SelectedIndex <= 0)
                //    //{
                //    Nombre_Plantilla = "Rpt_Mensual_Accesos.rpt";
                //    //}
                //    //else // asignar el reporte para una sola tarifa
                //    //{
                //    //    Nombre_Plantilla = "Rpt_Mensual_Accesos_Tarifa.rpt";
                //    //}
                //}

                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Exportar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón exportar PDF: llamar al método que muestra el reporte
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Pdf_Itesharp_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Resultado = new DataTable();
            DataTable Dt_Promedio = new DataTable();
            String Str_Leyenda = "";
            try
            {
                Sfd_Ruta_Archivo.Filter = "PDF(*.pdf)|*.pdf";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  se carga el grid
                Grid_Resultado.DataSource = new DataTable();

                //  se obtienen las leyendas que se mostraran en el reporte
                Str_Leyenda = Parametros_Reporte_A_Mostrar();

                // Generación del Archivo de Excel.
                // Validación a la Ruta del Archivo.
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (Rbt_Opc_Reporte_Ingresos.Checked)
                    {
                        Dt_Consulta = Realizar_Consulta();
                        Dt_Consulta = Cambiar_Nombre_Columnas_Tabla(Dt_Consulta);
                        Dt_Resultado = Dt_Consulta.Copy();
                        Exportar_Pdf_Ingresos_Visitantes(Sfd_Ruta_Archivo, Dt_Consulta, "recaudación por tarifa", Dt_Promedio, "Recaudación", Str_Leyenda);
                    }
                    else if (Rbt_Opc_Visitantes.Checked)
                    {
                        Dt_Consulta = Realizar_Consulta();//    visitantes
                        Dt_Consulta = Cambiar_Nombre_Columnas_Tabla(Dt_Consulta);
                        Dt_Resultado = Dt_Consulta.Copy();
                        Dt_Promedio = Consulta_Accesos_Promedio();//   promedio de visitantes
                        Dt_Promedio = Generar_Tabla_Promedio_Resultado(Dt_Promedio);
                        Dt_Promedio = Cambiar_Nombre_Columnas_Tabla_Promedio(Dt_Promedio);
                        Exportar_Pdf_Ingresos_Visitantes(Sfd_Ruta_Archivo, Dt_Consulta, "visitantes por tarifa", Dt_Promedio, "Visitantes", Str_Leyenda);
                    }
                    else if (Rbt_Opc_Concentrado.Checked)
                    {
                        Dt_Consulta = Realizar_Consulta();
                        Dt_Consulta = Cambiar_Nombre_Columnas_Tabla(Dt_Consulta);
                        Dt_Resultado = Dt_Consulta.Copy();
                        Exportar_Pdf_Ingresos_Visitantes(Sfd_Ruta_Archivo, Dt_Consulta, "concentrado", Dt_Promedio, "Concentrado", Str_Leyenda);
                    }

                    //  se carga el grid
                    Grid_Resultado.DataSource = new DataTable();
                    Grid_Resultado.DataSource = Dt_Resultado;
                }

            }// fin try

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón exportar excel: llamar al método que muestra el reporte
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Hugo Enrique Ramírez Aguilera</creo>
        /// <fecha_creo>15-Enero-2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Exel_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Resultado = new DataTable();
            DataTable Dt_Promedio = new DataTable();
            String Str_Leyenda = "";

            try
            {
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  se limpia el grid
                Grid_Resultado.DataSource = new DataTable();

                //  se obtiene la leyenda que se mostrara en el reporte de excel
                Str_Leyenda = Parametros_Reporte_A_Mostrar();


                // Generación del Archivo de Excel.
                // Validación a la Ruta del Archivo.
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (Rbt_Opc_Reporte_Ingresos.Checked)// ingresos
                    {
                        Dt_Consulta = Realizar_Consulta();
                        Dt_Consulta = Cambiar_Nombre_Columnas_Tabla(Dt_Consulta);
                        Dt_Resultado = Dt_Consulta.Copy();
                        Exportar_Excel(Sfd_Ruta_Archivo, Dt_Consulta, "recaudación por tarifa", "Recaudación", Dt_Promedio, Str_Leyenda);

                        Grid_Resultado.DataSource = new DataTable();
                        Grid_Resultado.DataSource = Dt_Resultado;
                    }
                    else if (Rbt_Opc_Visitantes.Checked)//  visitantes
                    {
                        Dt_Consulta = Realizar_Consulta();//    visitantes
                        Dt_Consulta = Cambiar_Nombre_Columnas_Tabla(Dt_Consulta);
                        Dt_Resultado = Dt_Consulta.Copy();

                        Dt_Promedio = Consulta_Accesos_Promedio();//   promedio de visitantes
                        Dt_Promedio = Generar_Tabla_Promedio_Resultado(Dt_Promedio);
                        Dt_Promedio = Cambiar_Nombre_Columnas_Tabla_Promedio(Dt_Promedio);

                        Exportar_Excel(Sfd_Ruta_Archivo, Dt_Consulta, "visitantes", "Visitantes", Dt_Promedio, Str_Leyenda);
                    }
                    else if (Rbt_Opc_Concentrado.Checked)// concentrado
                    {
                        Dt_Consulta = Realizar_Consulta();
                        Dt_Consulta = Cambiar_Nombre_Columnas_Tabla(Dt_Consulta);
                        Dt_Resultado = Dt_Consulta.Copy();
                        Exportar_Excel(Sfd_Ruta_Archivo, Dt_Consulta, "concentrado", "Concentrado", Dt_Promedio, Str_Leyenda);

                    }

                    //  se carga el grid
                    Grid_Resultado.DataSource = new DataTable();
                    Grid_Resultado.DataSource = Dt_Resultado;

                }// fin del sdf_dialog
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Btn_Exel_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion EVENTOS
      

        #region reporte itesharp
        /// <summary>
        /// Método que carga los lugares donde se pueden registrar las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Exportar_Pdf_Ingresos_Visitantes(SaveFileDialog Sfd_Ruta_Archivo, DataTable Dt_Resultado, String Tipo_Reporte, DataTable Dt_Promedios,
                                                        String Str_Leyenda_Grafico, String Str_Leyenda)
        {
            DataTable Dt_Anio = new DataTable();
            DataTable Dt_Auxiliar = new DataTable();
            DataTable Dt_Auxiliar_Promedio = new DataTable();

            PdfPTable Tabla_Separador = new PdfPTable(1);
            PdfPCell Celda_Separador = new PdfPCell();
            int Cont_Paginas = 0;
            try
            {
                using (FileStream Archivo_PDF = new FileStream(Sfd_Ruta_Archivo.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.LETTER.Rotate());
                    Document Documento = new Document(rec);
                    Documento.SetMargins(Documento.LeftMargin, Documento.RightMargin, Documento.TopMargin + 50, Documento.BottomMargin);
                    PdfWriter PDF = PdfWriter.GetInstance(Documento, Archivo_PDF);

                    // Se agrega el Encabezado y Pie de Página.
                    PageEventHandler evt = new PageEventHandler()
                    {
                        //Fecha_Inicio = new DateTime(,
                        //Fecha_Fin = DateTime.Now,
                        Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario,
                        Parametros = Str_Leyenda,
                        Posicion_Encabezado = 600
                    };

                    PDF.PageEvent = evt;

                    Documento.Open();
                    Documento.NewPage();

                    //  se obtienen los años
                    Dt_Anio = Dt_Resultado.DefaultView.ToTable(true, "Año");

                    //  encabezado del tipo de reporte *****************************************************************************************************
                    PdfPTable Tabla_Titulo_Reporte = new PdfPTable(1);
                    PdfPCell Celda_Titulo_Reporte = new PdfPCell();

                    iTextSharp.text.Font Fuente_Titulo_Reporte= new iTextSharp.text.Font(FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLDITALIC));

                    float[] Tamaño_Titulo_Reporte = new float[1];
                    Tamaño_Titulo_Reporte[0] = 430;

                    Tabla_Titulo_Reporte.SetWidths(Tamaño_Titulo_Reporte);
                    Tabla_Titulo_Reporte.WidthPercentage = 100;

                    Celda_Titulo_Reporte.Phrase = new Phrase("Análisis  mensual " + Tipo_Reporte, Fuente_Titulo_Reporte);
                    Celda_Titulo_Reporte.HorizontalAlignment = Element.ALIGN_CENTER;
                    Celda_Titulo_Reporte.Border = 0;
                    Tabla_Titulo_Reporte.AddCell(Celda_Titulo_Reporte);
                    Documento.Add(Tabla_Titulo_Reporte);
                    //Documento.Add(new iTextSharp.text.Paragraph("\n"));

                    //se recorren los años consultados ***********************************************************************
                    //********************************************************************************************************
                    foreach (DataRow Registro in Dt_Anio.Rows)
                    {
                        if (Cont_Paginas > 0)
                            Documento.NewPage();

                        //  encabezado año arriba de la tabla de detalle
                        PdfPTable Tabla_Anio = new PdfPTable(1);
                        PdfPCell Celda_Anio = new PdfPCell();

                        iTextSharp.text.Font Fuente_Anio = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLDITALIC));

                        float[] Tamaño_Anios = new float[1];
                        Tamaño_Anios[0] = 430;

                        Tabla_Anio.SetWidths(Tamaño_Anios);
                        Tabla_Anio.WidthPercentage = 100;

                        Celda_Anio.Phrase = new Phrase(Registro["Año"].ToString(), Fuente_Anio);
                        Celda_Anio.HorizontalAlignment = Element.ALIGN_CENTER;
                        Celda_Anio.BackgroundColor = BaseColor.LIGHT_GRAY;
                        Tabla_Anio.AddCell(Celda_Anio);
                        Documento.Add(Tabla_Anio);

                        //  detalle **************************************************************************************
                        #region Tabla principal
                        PdfPTable table = new PdfPTable(Dt_Resultado.Columns.Count-1);
                        PdfPCell cell = new PdfPCell();

                        iTextSharp.text.Font fnt = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8,  iTextSharp.text.Font.NORMAL));

                        iTextSharp.text.Font fnt_Totales = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD));

                        float[] widths = new float[Dt_Resultado.Columns.Count-1];
                        decimal[] totales = new decimal[Dt_Resultado.Columns.Count-1];

                        float val = 430 / Dt_Resultado.Columns.Count-1;

                        for (int i = 0; i < Dt_Resultado.Columns.Count-1; i++)
                        {
                            widths[i] = val;
                        }

                        table.SetWidths(widths);
                        table.WidthPercentage = 100;


                        //  se obtienen los valores del año
                        Dt_Resultado.DefaultView.RowFilter = "año =" + Registro["año"].ToString();
                        Dt_Auxiliar = Dt_Resultado.DefaultView.ToTable();

                        //  se elimina la columna del año
                        Dt_Auxiliar.Columns.RemoveAt(0);

                        //  se asingan los nombres de las columnas
                        foreach (DataColumn Col in Dt_Auxiliar.Columns)
                        {
                            table.AddCell(new PdfPCell(new Phrase(Col.ColumnName.ToUpper(), fnt))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                BackgroundColor = BaseColor.LIGHT_GRAY
                            });
                        }

                        table.HeaderRows = 1;

                        foreach (DataRow Fila in Dt_Auxiliar.Rows)
                        {
                            decimal Total = 0;

                            for (int i = 0; i < Dt_Auxiliar.Columns.Count; i++)
                            {
                                if (i == 0)
                                {
                                    cell.Phrase = new Phrase(Fila[i].ToString(), fnt_Totales);
                                    cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                                    table.AddCell(cell);
                                }
                                else
                                {
                                    decimal Val = Convert.ToDecimal(Fila[i]);

                                    Total += Val;
                                    totales[i] += Val;

                                    if (Tipo_Reporte.Contains("recaudación"))
                                    {
                                        cell.Phrase = new Phrase(Val.ToString("C").Replace("$", ""), fnt_Totales);
                                    }
                                    else if (Tipo_Reporte.Contains("concentrado"))
                                    {
                                        if (Fila["Tarifa"].ToString() == "Recaudacion")
                                        {
                                            cell.Phrase = new Phrase(Val.ToString("C").Replace("$", ""), fnt_Totales);
                                        }
                                        else
                                        {
                                            cell.Phrase = new Phrase(Val.ToString("n0").Replace("$", ""), fnt_Totales);
                                        }
                                    }
                                    else
                                    {
                                        cell.Phrase = new Phrase(Val.ToString("n0").Replace("$", ""), fnt_Totales);
                                    }
                                    
                                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                    table.AddCell(cell);
                                }
                            }

                        }

                        if (!Tipo_Reporte.Contains("concentrado"))
                        {
                            for (int i = 0; i < totales.Length; i++)
                            {
                                if (i == 0)
                                {
                                    cell.Phrase = new Phrase("Totales", fnt);
                                    cell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                                    table.AddCell(cell);
                                }
                                else
                                {
                                    if (Tipo_Reporte.Contains("recaudación"))
                                    {
                                        cell.Phrase = new Phrase(totales[i].ToString("C").Replace("$", ""), fnt_Totales);
                                    }
                                    else
                                    {
                                        cell.Phrase = new Phrase(totales[i].ToString("n0").Replace("$", ""), fnt_Totales);
                                    }


                                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                    table.AddCell(cell);
                                }
                            }
                        }

                        Documento.Add(table);

                        #endregion

                        //  separador**************************************************************************************
                        #region Separador

                        Tamaño_Anios = new float[1];
                        Tamaño_Anios[0] = 430;

                        Tabla_Separador.SetWidths(Tamaño_Anios);
                        Tabla_Separador.WidthPercentage = 100;
                        Documento.Add(Tabla_Separador);
                        Documento.Add(new iTextSharp.text.Paragraph("\n"));

                        #endregion Separador Principal

                        //  grafica**************************************************************************************
                        #region Grafica Principal

                        Documento.NewPage();
                        Chart_Grafico.Size = new System.Drawing.Size(700, 500);
                        Chart_Grafico.Series.Clear();
                        Chart_Grafico.Titles.Clear();
                        Chart_Grafico.Titles.Add(Str_Leyenda_Grafico + " " + Registro["Año"].ToString());
                        
                        //  se agregan las series que tendra la grafica
                        DataTable Dt_Posiciones = new DataTable();
                        Dt_Posiciones = Formar_Tabla_Posicion_Meses();

                        foreach (DataRow Dr_Registro_Serie in Dt_Posiciones.Rows)
                        {
                            if (Dr_Registro_Serie["Mes"].ToString() == "1")
                            {
                                Chart_Grafico.Series.Add("Enero");
                                Chart_Grafico.Series["Enero"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "2")
                            {
                                Chart_Grafico.Series.Add("Febrero");
                                Chart_Grafico.Series["Febrero"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "3")
                            {
                                Chart_Grafico.Series.Add("Marzo");
                                Chart_Grafico.Series["Marzo"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "4")
                            {
                                Chart_Grafico.Series.Add("Abril");
                                Chart_Grafico.Series["Abril"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "5")
                            {
                                Chart_Grafico.Series.Add("Mayo");
                                Chart_Grafico.Series["Mayo"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "6")
                            {
                                Chart_Grafico.Series.Add("Junio");
                                Chart_Grafico.Series["Junio"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "7")
                            {
                                Chart_Grafico.Series.Add("Julio");
                                Chart_Grafico.Series["Julio"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "8")
                            {
                                Chart_Grafico.Series.Add("Agosto");
                                Chart_Grafico.Series["Agosto"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "9")
                            {
                                Chart_Grafico.Series.Add("Septiembre");
                                Chart_Grafico.Series["Septiembre"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "10")
                            {
                                Chart_Grafico.Series.Add("Octubre");
                                Chart_Grafico.Series["Octubre"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "11")
                            {
                                Chart_Grafico.Series.Add("Noviembre");
                                Chart_Grafico.Series["Noviembre"]["DrawingStyle"] = "Cylinder";
                            }
                            else if (Dr_Registro_Serie["Mes"].ToString() == "12")
                            {
                                Chart_Grafico.Series.Add("Diciembre");
                                Chart_Grafico.Series["Diciembre"]["DrawingStyle"] = "Cylinder";
                            }
                        }

                        foreach (DataRow Registro_Grafica in Dt_Auxiliar.Rows)
                        {
                            foreach (DataRow Dr_Registro_Serie in Dt_Posiciones.Rows)
                            {
                                if (Dr_Registro_Serie["Mes"].ToString() == "1") 
                                    Chart_Grafico.Series["Enero"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Enero"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "2")
                                    Chart_Grafico.Series["Febrero"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Febrero"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "3")
                                    Chart_Grafico.Series["Marzo"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Marzo"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "4")
                                    Chart_Grafico.Series["Abril"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Abril"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "5")
                                    Chart_Grafico.Series["Mayo"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Mayo"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "6")
                                    Chart_Grafico.Series["Junio"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Junio"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "7")
                                    Chart_Grafico.Series["Julio"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Julio"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "8")
                                    Chart_Grafico.Series["Agosto"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Agosto"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "9")
                                    Chart_Grafico.Series["Septiembre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Septiembre"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "10")
                                    Chart_Grafico.Series["Octubre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Octubre"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "11")
                                    Chart_Grafico.Series["Noviembre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Noviembre"].ToString()));
                                else if (Dr_Registro_Serie["Mes"].ToString() == "12")
                                    Chart_Grafico.Series["Diciembre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Diciembre"].ToString()));
                            }
                            
                        }

                        //  estilo de la grafica
                        Chart_Grafico.ChartAreas[0].Area3DStyle.IsClustered = true;
                        Chart_Grafico.ChartAreas[0].Area3DStyle.PointDepth = 100;
                        Chart_Grafico.ChartAreas[0].Area3DStyle.PointGapDepth = 100;

                        Chart_Grafico.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Near;
                        Chart_Grafico.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Auto;
                        Chart_Grafico.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 6.25F, System.Drawing.FontStyle.Bold);


                        Chart_Grafico.ChartAreas[0].RecalculateAxesScale();
                        Chart_Grafico.Update();

                        var Chart_Imagen = new MemoryStream();

                        Chart_Grafico.SaveImage(Chart_Imagen, ChartImageFormat.Jpeg);
                        iTextSharp.text.Image ITx_Chart_Imagen = iTextSharp.text.Image.GetInstance(Chart_Imagen.GetBuffer());

                        PdfPTable Tabla_Grafica__= new PdfPTable(1);
                        PdfPCell Celda_Grafica_ = new PdfPCell();

                        float[] Tamaño_Grafico_ = new float[1];
                        Tamaño_Grafico_[0] = 430;

                        Tabla_Grafica__.SetWidths(Tamaño_Grafico_);
                        Tabla_Grafica__.WidthPercentage = 100;

                        Celda_Grafica_.Image = ITx_Chart_Imagen;
                        Celda_Grafica_.HorizontalAlignment = Element.ALIGN_CENTER;
                        Celda_Grafica_.Border = 0;
                        Tabla_Grafica__.AddCell(Celda_Grafica_);
                        Documento.Add(Tabla_Grafica__);

                        #endregion Grafica Principal


                        //  grafica estilo PIE **************************************************************************************
                        #region Grafica Porcentaje
                        if (Rbt_Opc_Visitantes.Checked)
                        {
                            Documento.NewPage();
                            Chart_Grafico_Porcentaje.Size = new System.Drawing.Size(1440, 900);
                        
                            Chart_Grafico_Porcentaje.Series.Clear();
                            Chart_Grafico_Porcentaje.Titles.Clear();
                            Chart_Grafico_Porcentaje.Legends.Clear();
                            Chart_Grafico_Porcentaje.Titles.Add("Porcentaje de visitantes " + Registro["Año"].ToString());

                            Chart_Grafico_Porcentaje.Legends.Add(new Legend("Porcentaje"));
                            Chart_Grafico_Porcentaje.Legends["Porcentaje"].Alignment = System.Drawing.StringAlignment.Center;
                            Chart_Grafico_Porcentaje.Legends["Porcentaje"].BackColor = System.Drawing.Color.Transparent;
                            Chart_Grafico_Porcentaje.Legends["Porcentaje"].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
                            Chart_Grafico_Porcentaje.Legends["Porcentaje"].Enabled = true;
                            Chart_Grafico_Porcentaje.Legends["Porcentaje"].Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                            Chart_Grafico_Porcentaje.Legends["Porcentaje"].IsTextAutoFit = false;

                            Chart_Grafico_Porcentaje.Series.Add(new Series("Visitantes"));
                            Chart_Grafico_Porcentaje.Series["Visitantes"].ChartType = SeriesChartType.Pie;
                            Chart_Grafico_Porcentaje.Series["Visitantes"].Label = "#VALX " + " = " + "#PERCENT{P0}";
                            Chart_Grafico_Porcentaje.Series["Visitantes"].Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Regular);
                            Chart_Grafico_Porcentaje.Series["Visitantes"].LegendText = "#VALX";
                            Chart_Grafico_Porcentaje.Series["Visitantes"].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;


                            Chart_Grafico_Porcentaje.Series["Visitantes"].CustomProperties = "DoughnutRadius=10, PieDrawingStyle=Concave, CollectedLabel=Other, MinimumRelative" + "PieSize=20";
                            Chart_Grafico_Porcentaje.Series["Visitantes"]["PieLabelStyle"] = "Outside";
                            Chart_Grafico_Porcentaje.Series["Visitantes"]["PieDrawingStyle"] = "SoftEdge";

                            Chart_Grafico_Porcentaje.ChartAreas[0].Area3DStyle.Enable3D = true;

                            
                            foreach (DataRow Registro_Total in Dt_Auxiliar.Rows)
                            {
                                Chart_Grafico_Porcentaje.Series["Visitantes"].Points.AddXY(Registro_Total["Tarifa"].ToString(), Convert.ToDouble(Registro_Total["Total"].ToString()));
                            }
                           

                            Chart_Grafico_Porcentaje.ChartAreas[0].RecalculateAxesScale();
                            Chart_Grafico_Porcentaje.Update();

                            var Chart_Imagen_Porcentaje = new MemoryStream();

                            Chart_Grafico_Porcentaje.SaveImage(Chart_Imagen_Porcentaje, ChartImageFormat.Png);
                            iTextSharp.text.Image ITx_Chart_Imagen_Porcentaje = iTextSharp.text.Image.GetInstance(Chart_Imagen_Porcentaje.GetBuffer());

                            PdfPTable Tabla_Grafica_Porcentaje = new PdfPTable(1);
                            PdfPCell Celda_Grafica_Porcentaje = new PdfPCell();

                            float[] Tamaño_Grafico_Porcentaje = new float[1];
                            Tamaño_Grafico_Porcentaje[0] = 430;

                            Tabla_Grafica_Porcentaje.SetWidths(Tamaño_Grafico_Porcentaje);
                            Tabla_Grafica_Porcentaje.WidthPercentage = 100;

                            Celda_Grafica_Porcentaje.Image = ITx_Chart_Imagen_Porcentaje;
                            Celda_Grafica_Porcentaje.HorizontalAlignment = Element.ALIGN_CENTER;
                            Celda_Grafica_Porcentaje.Border = 0;
                            Tabla_Grafica_Porcentaje.AddCell(Celda_Grafica_Porcentaje);
                            Documento.Add(Tabla_Grafica_Porcentaje);

                        }


                        #endregion

                        //  area de promedios**************************************************************************************
                        //  si la opcion es visitantes se obtiene los promedio de la tarifa
                        if (Rbt_Opc_Visitantes.Checked)
                        {
                            //  tabla promedios *************************************************************************************
                            #region Tabla Promedio
                            Documento.NewPage();

                            //  encabezado año arriba de la tabla de detalle
                            PdfPTable Tabla_Anio_Promedio = new PdfPTable(1);
                            PdfPCell Celda_Anio_Promedio = new PdfPCell();

                            iTextSharp.text.Font Fuente_Promedio = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLDITALIC));

                            float[] Tamaño_Promedio = new float[1];
                            Tamaño_Promedio[0] = 430;

                            Tabla_Anio_Promedio.SetWidths(Tamaño_Promedio);
                            Tabla_Anio_Promedio.WidthPercentage = 100;

                            Celda_Anio_Promedio.Phrase = new Phrase("Promedio " + Registro["Año"].ToString(), Fuente_Promedio);
                            Celda_Anio_Promedio.HorizontalAlignment = Element.ALIGN_CENTER;
                            Celda_Anio_Promedio.BackgroundColor = BaseColor.LIGHT_GRAY;
                            Tabla_Anio_Promedio.AddCell(Celda_Anio_Promedio);
                            Documento.Add(Tabla_Anio_Promedio);

                            //  detalle Promedio**************************************************************************************
                            PdfPTable Tabla_Promedio = new PdfPTable(Dt_Promedios.Columns.Count - 1);
                            PdfPCell Celda_Promedio = new PdfPCell();

                            iTextSharp.text.Font Fnt_Promedio = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL));

                            iTextSharp.text.Font Fnt_Promedio_Totales = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.BOLD));

                            float[] Widths_Promedio = new float[Dt_Promedios.Columns.Count - 1];
                            decimal[] Totales_Promedio = new decimal[Dt_Promedios.Columns.Count - 1];

                            float val_Promedio = 430 / Dt_Promedios.Columns.Count - 1;

                            for (int i = 0; i < Dt_Promedios.Columns.Count - 1; i++)
                            {
                                Widths_Promedio[i] = val_Promedio;
                            }

                            Tabla_Promedio.SetWidths(Widths_Promedio);
                            Tabla_Promedio.WidthPercentage = 100;


                            //  se obtienen los valores del año
                            Dt_Promedios.DefaultView.RowFilter = "año =" + Registro["año"].ToString();
                            Dt_Auxiliar_Promedio = Dt_Promedios.DefaultView.ToTable();

                            //  se elimina la columna del año
                            Dt_Auxiliar_Promedio.Columns.RemoveAt(0);

                            //  se asingan los nombres de las columnas
                            foreach (DataColumn Col in Dt_Auxiliar_Promedio.Columns)
                            {
                                Tabla_Promedio.AddCell(new PdfPCell(new Phrase(Col.ColumnName.ToUpper(), fnt))
                                {
                                    HorizontalAlignment = Element.ALIGN_CENTER,
                                    VerticalAlignment = Element.ALIGN_MIDDLE,
                                    BackgroundColor = BaseColor.LIGHT_GRAY
                                });
                            }

                            Tabla_Promedio.HeaderRows = 1;

                            foreach (DataRow Fila_Promedio in Dt_Auxiliar_Promedio.Rows)
                            {
                                decimal Total = 0;

                                for (int i = 0; i < Dt_Auxiliar_Promedio.Columns.Count; i++)
                                {
                                    if (i == 0)
                                    {
                                        Celda_Promedio.Phrase = new Phrase(Fila_Promedio[i].ToString(), Fnt_Promedio_Totales);
                                        Celda_Promedio.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                                        Tabla_Promedio.AddCell(Celda_Promedio);
                                    }
                                    else
                                    {
                                        decimal Val = Convert.ToDecimal(Fila_Promedio[i]);

                                        Total += Val;
                                        Totales_Promedio[i] += Val;
                                        Celda_Promedio.Phrase = new Phrase(Val.ToString("n0").Replace("$", ""), Fnt_Promedio_Totales);
                                        Celda_Promedio.HorizontalAlignment = Element.ALIGN_RIGHT;
                                        Tabla_Promedio.AddCell(Celda_Promedio);
                                    }
                                }

                            }

                            for (int i = 0; i < Totales_Promedio.Length; i++)
                            {
                                if (i == 0)
                                {
                                    Celda_Promedio.Phrase = new Phrase("Totales", Fnt_Promedio);
                                    Celda_Promedio.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                                    Tabla_Promedio.AddCell(Celda_Promedio);
                                }
                                else
                                {
                                    Celda_Promedio.Phrase = new Phrase(Totales_Promedio[i].ToString("n0").Replace("$", ""), Fnt_Promedio_Totales);
                                    Celda_Promedio.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    Tabla_Promedio.AddCell(Celda_Promedio);
                                }
                            }

                            Documento.Add(Tabla_Promedio);

                            #endregion Tabla Promedio

                            //  separador**************************************************************************************
                            #region Separador

                            Tamaño_Anios = new float[1];
                            Tamaño_Anios[0] = 430;

                            Tabla_Separador.SetWidths(Tamaño_Anios);
                            Tabla_Separador.WidthPercentage = 100;
                            Documento.Add(Tabla_Separador);
                            Documento.Add(new iTextSharp.text.Paragraph("\n"));

                            #endregion Separador

                            //  grafica**************************************************************************************
                            #region Grafica Promedio

                            Documento.NewPage();
                            Chart_Grafico.Size = new System.Drawing.Size(700, 500);
                            Chart_Grafico.Series.Clear();
                            Chart_Grafico.Titles.Clear();
                            Chart_Grafico.Titles.Add(Str_Leyenda_Grafico + " " + Registro["Año"].ToString());

                            Chart_Grafico.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Center;
                            Chart_Grafico.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Auto;
                            

                            //  se agregan las series que tendra la grafica
                            Dt_Posiciones = new DataTable();
                            Dt_Posiciones = Formar_Tabla_Posicion_Meses();

                            foreach (DataRow Dr_Registro_Serie in Dt_Posiciones.Rows)
                            {
                                if (Dr_Registro_Serie["Mes"].ToString() == "1")
                                {
                                    Chart_Grafico.Series.Add("Enero");
                                    Chart_Grafico.Series["Enero"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "2")
                                {
                                    Chart_Grafico.Series.Add("Febrero");
                                    Chart_Grafico.Series["Febrero"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "3")
                                {
                                    Chart_Grafico.Series.Add("Marzo");
                                    Chart_Grafico.Series["Marzo"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "4")
                                {
                                    Chart_Grafico.Series.Add("Abril");
                                    Chart_Grafico.Series["Abril"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "5")
                                {
                                    Chart_Grafico.Series.Add("Mayo");
                                    Chart_Grafico.Series["Mayo"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "6")
                                {
                                    Chart_Grafico.Series.Add("Junio");
                                    Chart_Grafico.Series["Junio"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "7")
                                {
                                    Chart_Grafico.Series.Add("Julio");
                                    Chart_Grafico.Series["Julio"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "8")
                                {
                                    Chart_Grafico.Series.Add("Agosto");
                                    Chart_Grafico.Series["Agosto"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "9")
                                {
                                    Chart_Grafico.Series.Add("Septiembre");
                                    Chart_Grafico.Series["Septiembre"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "10")
                                {
                                    Chart_Grafico.Series.Add("Octubre");
                                    Chart_Grafico.Series["Octubre"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "11")
                                {
                                    Chart_Grafico.Series.Add("Noviembre");
                                    Chart_Grafico.Series["Noviembre"]["DrawingStyle"] = "Cylinder";
                                }
                                else if (Dr_Registro_Serie["Mes"].ToString() == "12")
                                {
                                    Chart_Grafico.Series.Add("Diciembre");
                                    Chart_Grafico.Series["Diciembre"]["DrawingStyle"] = "Cylinder";
                                }
                            }

                            foreach (DataRow Registro_Grafica in Dt_Auxiliar_Promedio.Rows)
                            {
                                foreach (DataRow Dr_Registro_Serie in Dt_Posiciones.Rows)
                                {
                                    if (Dr_Registro_Serie["Mes"].ToString() == "1")
                                        Chart_Grafico.Series["Enero"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Enero"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "2")
                                        Chart_Grafico.Series["Febrero"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Febrero"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "3")
                                        Chart_Grafico.Series["Marzo"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Marzo"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "4")
                                        Chart_Grafico.Series["Abril"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Abril"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "5")
                                        Chart_Grafico.Series["Mayo"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Mayo"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "6")
                                        Chart_Grafico.Series["Junio"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Junio"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "7")
                                        Chart_Grafico.Series["Julio"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Julio"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "8")
                                        Chart_Grafico.Series["Agosto"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Agosto"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "9")
                                        Chart_Grafico.Series["Septiembre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Septiembre"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "10")
                                        Chart_Grafico.Series["Octubre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Octubre"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "11")
                                        Chart_Grafico.Series["Noviembre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Noviembre"].ToString()));
                                    else if (Dr_Registro_Serie["Mes"].ToString() == "12")
                                        Chart_Grafico.Series["Diciembre"].Points.AddXY(Registro_Grafica["tarifa"].ToString(), Convert.ToDouble(Registro_Grafica["Diciembre"].ToString()));
                                }

                            }

                            Chart_Grafico.ChartAreas[0].RecalculateAxesScale();
                            Chart_Grafico.Update();

                            Chart_Imagen = new MemoryStream();

                            Chart_Grafico.SaveImage(Chart_Imagen, ChartImageFormat.Jpeg);
                            ITx_Chart_Imagen = iTextSharp.text.Image.GetInstance(Chart_Imagen.GetBuffer());

                            Tabla_Grafica__ = new PdfPTable(1);
                            Celda_Grafica_ = new PdfPCell();

                            Tamaño_Grafico_ = new float[1];
                            Tamaño_Grafico_[0] = 430;

                            Tabla_Grafica__.SetWidths(Tamaño_Grafico_);
                            Tabla_Grafica__.WidthPercentage = 100;

                            Celda_Grafica_.Image = ITx_Chart_Imagen;
                            Celda_Grafica_.HorizontalAlignment = Element.ALIGN_CENTER;
                            Celda_Grafica_.Border = 0;
                            Tabla_Grafica__.AddCell(Celda_Grafica_);
                            Documento.Add(Tabla_Grafica__);

                            #endregion Grafica Promedio

                        }// validacion if para los promedios de visitantes

                        Cont_Paginas++;

                    }// fin foreach

                    Documento.Close();
                }

                MessageBox.Show("Archivo Guardado Correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }// fin try
            catch (Exception Ex)
            {
                throw new Exception("Error: (Exportar_Pdf_Producto). Descripción: " + Ex.Message);
            }
        }

        #endregion


        #region Exportacion Excel

        /// <summary>
        /// Método que carga los lugares donde se pueden registrar las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Exportar_Excel(SaveFileDialog Sfd_Ruta_Archivo, DataTable Dt_Consulta, String Tipo_Reporte, String Titulo_Grafico, 
                                        DataTable Dt_Promedio, String Str_Leyenda)
        {
            String Str_Columna_Tope = ""; //    contendra la letra que se utilizara como tope en el archivo de excel
            String Str_Columna_Tope_Promedio = ""; 
            DataTable Dt_Anio = new DataTable();
            DataTable Dt_Auxiliar = new DataTable();
            DataTable Dt_Auxiliar_Promedio = new DataTable();
            int Cont_Columnas = 0;
            int Cont_Columnas_Promedio = 0;
            int Cont_Tablas = 0; 
            ExcelRangeBase Rango_Detalle = null;

            try
            {
                // *******************************************************************************************************************************
                //  se obtiene el diccionario referente a las columnas en excel
                Dictionary<Int32, string> Dic_Excel = Crear_Diccionario_Excel();
               
                //// *******************************************************************************************************************************
                String[] Str_Matriz_Leyenda = Str_Leyenda.Split('\n');


                // *******************************************************************************************************************************
                //  se obtiene el tope del archivo de excel
                Cont_Columnas = Dt_Consulta.Columns.Count - 2; 
                if (Dic_Excel.ContainsKey(Cont_Columnas) == true)
                {
                    Str_Columna_Tope = Dic_Excel[Cont_Columnas];
                }
                else
                {
                    Str_Columna_Tope = "I";
                }


                // *******************************************************************************************************************************
                //  se obtiene el tope del archivo de excel para el promedio
                if (Rbt_Opc_Visitantes.Checked)
                {
                    Cont_Columnas_Promedio = Dt_Promedio.Columns.Count - 2;
                    if (Dic_Excel.ContainsKey(Cont_Columnas_Promedio) == true)
                    {
                        Str_Columna_Tope_Promedio = Dic_Excel[Cont_Columnas_Promedio];
                    }
                    else
                    {
                        Str_Columna_Tope_Promedio = "I";
                    }
                }

                // *******************************************************************************************************************************
                //  se obtienen los años
                Dt_Anio = Dt_Consulta.DefaultView.ToTable(true, "Año");


                // *******************************************************************************************************************************                
                //  se valida que exista el archivo
                if (File.Exists(Sfd_Ruta_Archivo.FileName))
                {
                    File.Delete(Sfd_Ruta_Archivo.FileName);
                }
                
                //  se crea el archivo 
                FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                using (ExcelPackage Excel_Doc_Analisis_Mensual = new ExcelPackage(newFile))
                {
                    ExcelWorksheet Detallado = Excel_Doc_Analisis_Mensual.Workbook.Worksheets.Add("Analisis mensual");
                    // *******************************************************************************************************************************
                    Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                    Detallado.Cells["A2"].Value = "Dirección de ingresos";
                    Detallado.Cells["A3"].Value = "Museo de las momias";
                    Detallado.Cells["A4"].Value = Str_Matriz_Leyenda[0];
                    Detallado.Cells["A5"].Value = Str_Matriz_Leyenda[1];

                    Detallado.Cells["A7"].Value = "Analisis mensual " + Tipo_Reporte;

                    Detallado.Cells["A1:A1"].Style.Font.Bold = true;
                    Detallado.Cells["A3:A7"].Style.Font.Bold = true;

                    // Encabezados del reporte
                    Detallado.Cells["A1:" + Str_Columna_Tope + "1"].Merge = true;
                    Detallado.Cells["A2:" + Str_Columna_Tope + "2"].Merge = true;
                    Detallado.Cells["A3:" + Str_Columna_Tope + "3"].Merge = true;
                    Detallado.Cells["A4:" + Str_Columna_Tope + "4"].Merge = true;
                    Detallado.Cells["A5:" + Str_Columna_Tope + "5"].Merge = true;
                    Detallado.Cells["A6:" + Str_Columna_Tope + "6"].Merge = true;
                    Detallado.Cells["A7:" + Str_Columna_Tope + "7"].Merge = true;

                    Detallado.Cells["A1:" + Str_Columna_Tope + "1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    Detallado.Cells["A2:" + Str_Columna_Tope + "2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    Detallado.Cells["A3:" + Str_Columna_Tope + "3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    Detallado.Cells["A4:" + Str_Columna_Tope + "4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    Detallado.Cells["A5:" + Str_Columna_Tope + "5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    Detallado.Cells["A6:" + Str_Columna_Tope + "6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    Detallado.Cells["A7:" + Str_Columna_Tope + "7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    Detallado.Cells["A1:" + Str_Columna_Tope + "1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Detallado.Cells["A2:" + Str_Columna_Tope + "2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Detallado.Cells["A3:" + Str_Columna_Tope + "3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Detallado.Cells["A4:" + Str_Columna_Tope + "4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Detallado.Cells["A5:" + Str_Columna_Tope + "5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Detallado.Cells["A6:" + Str_Columna_Tope + "6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    Detallado.Cells["A7:" + Str_Columna_Tope + "7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                    Int32 Filas = 8;
                    //  se generan los registros correspondientes a los años
                    foreach (DataRow Dr_Registro_Anios in Dt_Anio.Rows)
                    {
                        Dt_Auxiliar = new DataTable();
                        
                        //  se obtienen los valores del año
                        Dt_Consulta.DefaultView.RowFilter = "año =" + Dr_Registro_Anios["año"].ToString();
                        Dt_Auxiliar = Dt_Consulta.DefaultView.ToTable();

                        //  se elimina la columna del año
                        Dt_Auxiliar.Columns.RemoveAt(0);
                        Dt_Auxiliar.TableName = "Analisis_Mensual_" + Cont_Tablas.ToString();
                        Cont_Tablas++;

                        // *******************************************************************************************************************************
                        Detallado.Cells["A" + Filas].Value = Dr_Registro_Anios["año"].ToString();
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.Font.Bold = true;
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Merge = true;
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Filas++;

                        // *******************************************************************************************************************************
                        //  detalle del año
                        int Posicion_Tabla = 0;
                        Posicion_Tabla = Filas;
                        Generar_Tabla_Detalle_Excel(Rango_Detalle, Detallado, Dt_Auxiliar, Filas);

                        Filas = Filas + Dt_Auxiliar.Rows.Count + 1;

                        // *******************************************************************************************************************************
                        //  formulas
                        if (!Rbt_Opc_Concentrado.Checked)
                        {
                            Detallado.Cells[(Filas), 2, (Filas), Dt_Auxiliar.Columns.Count].Style.Numberformat.Format = "#,##0.00";

                            Detallado.Cells["A" + Filas].Value = "Total";
                            Detallado.Cells["A" +Filas +":" + Str_Columna_Tope + Filas].Style.Font.Bold = true;

                            for (Int32 Cont_For = 1; Cont_For < Cont_Columnas + 1; Cont_For++)
                            {
                                if (Dic_Excel.ContainsKey(Cont_For) == true)
                                {
                                    Detallado.Cells[Dic_Excel[Cont_For] + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Auxiliar.TableName + "[" + Dt_Auxiliar.Columns[Cont_For].ColumnName + "] )");
                                }
                            }
                        }
                        Filas = Filas + 2;

                        // *******************************************************************************************************************************
                        //  grafica
                        ExcelWorksheet Graph = Detallado.Workbook.Worksheets.Add("Grafica_" + Titulo_Grafico+"_" + Dr_Registro_Anios["año"].ToString());

                        var Grafica = Graph.Drawings.AddChart("Grafica_" + Dr_Registro_Anios["año"].ToString(), OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
                        Grafica.Title.Text = Titulo_Grafico + " " + Dr_Registro_Anios["Año"].ToString();
                        Grafica.SetSize(1280, 800);
                        Grafica.SetPosition(0, 0, 0, 0);

                        //  variable que guarda la posicion de la tabla: " Posicion_Tabla "
                        Posicion_Tabla++;// se incrementa el titulo
                        for (int Cont_For_Grafica = 0; Cont_For_Grafica < Dt_Auxiliar.Rows.Count ; Cont_For_Grafica++)
                        {
                            var Serie_Grafica = Grafica.Series.Add(Detallado.Cells["Analisis mensual!$B$" + (Posicion_Tabla + Cont_For_Grafica) + ":$" +
                                                                    Dic_Excel[Cont_Columnas - 1] + "$" + (Posicion_Tabla + Cont_For_Grafica)],
                                                                Detallado.Cells["Analisis mensual!$B$" + (Posicion_Tabla - 1) + ":$" + Dic_Excel[Cont_Columnas - 1] + "$" + (Posicion_Tabla - 1)]);

                            Serie_Grafica.Header = Detallado.Cells["Analisis mensual!$A$" + (Posicion_Tabla + Cont_For_Grafica)].Text.ToString();
                        }
                        Posicion_Tabla--;

                        // *******************************************************************************************************************************
                        //  validacion para el acceso generacion de grafica porcentajes de tarifas "PIE"
                        if (Rbt_Opc_Visitantes.Checked)
                        {
                            ExcelWorksheet Graph_Porcentaje = Detallado.Workbook.Worksheets.Add("Graf_%" + Titulo_Grafico + "_" + Dr_Registro_Anios["año"].ToString());

                            var Grafica_Porcentaje = Graph_Porcentaje.Drawings.AddChart("Grafica Porcentaje " + Dr_Registro_Anios["año"].ToString(), OfficeOpenXml.Drawing.Chart.eChartType.Pie3D) as ExcelPieChart;
                            Grafica_Porcentaje.Title.Text = Titulo_Grafico + " " + Dr_Registro_Anios["Año"].ToString();
                            Grafica_Porcentaje.SetSize(1280, 800);
                            Grafica_Porcentaje.SetPosition(0, 0, 0, 0);

                            //  variable que guarda la posicion de la tabla: " Posicion_Tabla "
                            Posicion_Tabla++;// se incrementa el titulo
                            Int32 Cont_Row_Dt_Auxiliar = 0;
                            Cont_Row_Dt_Auxiliar = Dt_Auxiliar.Rows.Count -1;
                           
                            var Serie_Grafica_ = Grafica_Porcentaje.Series.Add(Detallado.Cells["Analisis mensual!$" + Dic_Excel[Cont_Columnas] + "$" + (Posicion_Tabla) + ":$" +
                                                         Dic_Excel[Cont_Columnas] + "$" + (Posicion_Tabla + Cont_Row_Dt_Auxiliar)],
                                                     Detallado.Cells["Analisis mensual!$A$" + (Posicion_Tabla) + ":$A$" + (Posicion_Tabla + Cont_Row_Dt_Auxiliar)]);

                            Grafica_Porcentaje.DataLabel.ShowCategory = true;
                            Grafica_Porcentaje.DataLabel.ShowPercent = true;
                            Grafica_Porcentaje.DataLabel.ShowLeaderLines = true;
                            Grafica_Porcentaje.DataLabel.Separator = "  ";
                            //Grafica_Porcentaje.Legend.Position= 
                        }

                        // *******************************************************************************************************************************
                        //  fin del recorrido del año
                        Filas = Filas + 2;

                        // *******************************************************************************************************************************
                        //  si es consulta por visitantes se genera la tabla de promedios***************************************************************************
                        if (Rbt_Opc_Visitantes.Checked)
                        {
                            
                            // *******************************************************************************************************************************
                            //  se obtienen los valores del año
                            Dt_Auxiliar_Promedio = new DataTable();
                            Dt_Promedio.DefaultView.RowFilter = "año =" + Dr_Registro_Anios["año"].ToString();
                            Dt_Auxiliar_Promedio = Dt_Promedio.DefaultView.ToTable();

                            //  se elimina la columna del año
                            Dt_Auxiliar_Promedio.Columns.RemoveAt(0);
                            Dt_Auxiliar_Promedio.TableName = "Promedio_Mensual_" + Cont_Tablas.ToString();
                            Cont_Tablas++;

                            // *******************************************************************************************************************************
                            Detallado.Cells["A" + Filas].Value = "Promedio " + Dr_Registro_Anios["año"].ToString();
                            Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope_Promedio + Filas].Style.Font.Bold = true;
                            Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope_Promedio + Filas].Merge = true;
                            Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope_Promedio + Filas].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope_Promedio + Filas].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Filas++;

                            // *******************************************************************************************************************************
                            //  detalle del promedio por año
                            Posicion_Tabla = 0;
                            Posicion_Tabla = Filas;
                            Generar_Tabla_Detalle_Excel(Rango_Detalle, Detallado, Dt_Auxiliar_Promedio, Filas);

                            Filas = Filas + Dt_Auxiliar_Promedio.Rows.Count + 1;

                            // *******************************************************************************************************************************
                            //  formulas
                            Detallado.Cells[(Filas), 2, (Filas), Dt_Auxiliar_Promedio.Columns.Count].Style.Numberformat.Format = "#,##0.00";
                            Detallado.Cells["A" + Filas].Value = "Total";
                            Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope_Promedio + Filas].Style.Font.Bold = true;


                            for (Int32 Cont_For = 1; Cont_For < Cont_Columnas_Promedio + 1; Cont_For++)
                            {
                                if (Dic_Excel.ContainsKey(Cont_For) == true)
                                {
                                    Detallado.Cells[Dic_Excel[Cont_For] + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Auxiliar_Promedio.TableName + "[" + Dt_Auxiliar_Promedio.Columns[Cont_For].ColumnName + "] )");
                                }
                            }

                            Filas = Filas + 2;


                            // *******************************************************************************************************************************
                            //  grafica
                            ExcelWorksheet Graph_Promedio = Detallado.Workbook.Worksheets.Add("Graf_Promedio_" + Titulo_Grafico + "_" + Dr_Registro_Anios["año"].ToString());

                            var Grafica_Promedio = Graph_Promedio.Drawings.AddChart("Grafica_Promedio" + Dr_Registro_Anios["año"].ToString(), OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
                            Grafica_Promedio.Title.Text = "Promedio " + Dr_Registro_Anios["Año"].ToString();
                            Grafica_Promedio.SetSize(1280, 800);
                            Grafica_Promedio.SetPosition(0, 0, 0, 0);

                            //  variable que guarda la posicion de la tabla: " Posicion_Tabla "
                            Posicion_Tabla++;// se incrementa el titulo
                            for (int Cont_For_Grafica = 0; Cont_For_Grafica < Dt_Auxiliar_Promedio.Rows.Count; Cont_For_Grafica++)
                            {
                                var Serie_Grafica_Promedio = Grafica_Promedio.Series.Add(Detallado.Cells["Analisis mensual!$B$" + (Posicion_Tabla + Cont_For_Grafica) + ":$" +
                                                                        Dic_Excel[Cont_Columnas_Promedio] + "$" + (Posicion_Tabla + Cont_For_Grafica)],
                                                                    Detallado.Cells["Analisis mensual!$B$" + (Posicion_Tabla - 1) + ":$" + Dic_Excel[Cont_Columnas_Promedio] + "$" + (Posicion_Tabla - 1)]);

                                Serie_Grafica_Promedio.Header = Detallado.Cells["Analisis mensual!$A$" + (Posicion_Tabla + Cont_For_Grafica)].Text.ToString();
                            }

                            // *******************************************************************************************************************************
                            //  fin de la graficacion del promedio
                            //Filas = Filas + 2;


                        }

                    }// fin del foreach anios

                    
                    // *******************************************************************************************************************************
                    //  pie de pagina
                    Filas = Filas + 2;
                    Detallado.Cells["A" + Filas.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Detallado.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();

                    // *******************************************************************************************************************************
                    //  se guarda el documento
                    Excel_Doc_Analisis_Mensual.Save();

                    //  mensaje de confirmacion
                    MessageBox.Show(this, "Exportacion exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Exportar_Excel). Descripción: " + Ex.Message);
            }
        }

        /// <summary>
        /// Método que carga los lugares donde se pueden registrar las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Generar_Tabla_Detalle_Excel(ExcelRangeBase Rango, ExcelWorksheet Detallado, DataTable Dt_Consulta, int Filas)
        {
            try
            {
                Rango = null;
                Rango = Detallado.Cells["A" + Filas].LoadFromDataTable(Dt_Consulta, true, OfficeOpenXml.Table.TableStyles.Medium2);
                Rango.AutoFitColumns();

                // *******************************************************************************************************************************
                //  formato a las celdas 

                if (Rbt_Opc_Reporte_Ingresos.Checked)
                {
                    Detallado.Cells[Filas, 1, Rango.End.Row, 1].Style.Numberformat.Format = "#,##0";
                    Detallado.Cells[Filas, 2, Rango.End.Row, Dt_Consulta.Columns.Count].Style.Numberformat.Format = "#,##0.00";
                }
                else if (Rbt_Opc_Visitantes.Checked)
                {
                    Detallado.Cells[Filas, 1, Rango.End.Row, 1].Style.Numberformat.Format = "#,##0";
                    Detallado.Cells[Filas, 2, Rango.End.Row, Dt_Consulta.Columns.Count].Style.Numberformat.Format = "#,##0";
                }
                else if (Rbt_Opc_Concentrado.Checked)
                {
                    Detallado.Cells[(Filas + 1), 2, (Filas + 1), Dt_Consulta.Columns.Count].Style.Numberformat.Format = "#,##0.00";
                    Detallado.Cells[(Filas + 2), 2, (Filas + 2), Dt_Consulta.Columns.Count].Style.Numberformat.Format = "#,##0";
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Generar_Tabla_Detalle_Excel). Descripción: " + Ex.Message);
            }
        }

        #endregion
    }
}
