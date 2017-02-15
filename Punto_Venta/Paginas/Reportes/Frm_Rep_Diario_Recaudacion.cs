using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Reportes.Ingresos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP_BASE.Paginas.Catalogos.Generales;
using ERP_BASE.App_Code.Reporte;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Constantes;
using System.Collections.Generic;
using MySql.Data.Types;
using Catalogos.Turnos.Negocio;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Erp.Metodos_Generales;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rep_Diario_Recaudacion : Form
    {
        DataTable Dt_Productos;
        bool Anio_Anterior = false;

        // Relación de las Tarifas a través de los años.
        int[] Adultos = { 1, 18, 30, 42, 54, 66, 81 };
        int[] Cap_Dif = { 7, 26, 38, 50, 62, 74, 87 };
        int[] Estudiante = { 2, 19, 31, 43, 55, 67, 82 };
        int[] Ninos = { 4, 20, 32, 44, 56, 68, 84 };
        int[] Adultos_M = { 5, 21, 33, 45, 57, 69, 85 };
        int[] Cortesias = { 11, 17, 22, 34, 46, 58, 70, 91 };
        int[] Descuentos = { 12, 23, 35, 47, 59, 71, 92 };
        int[] Maestros = { 3, 24, 36, 48, 60, 72, 83 };
        int[] Residentes = { 6, 25, 37, 49, 61, 73, 86 };
        int[] RPVD = { 27, 39, 51, 63 };
        int[] RPVN = { 28, 40, 52, 64 };
        int[] RN = { 8, 76, 88 };
        int[] Culto_Muerte = { 29, 41, 53, 65, 80 };
        int[] Uso_Camara = { 9, 75, 77, 89 };
        int[] Uso_Camara_Profesional = { 10, 90, 10, 78 };
        int[] Tarifa_20 = { 79 };
        int[] Promotor = { 13 };

        public Frm_Rep_Diario_Recaudacion()
        {
            InitializeComponent();
        }

        #region METODOS
       
        /// <summary>
        /// Método que realiza la carga de las cajas registradas por catálogo.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:16 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Cajas()
        {
            Cls_Cat_Cajas_Negocio Obj_Cajas = new Cls_Cat_Cajas_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Cajas = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Cajas = Obj_Cajas.Consultar_Caja();//Ejecutamos la consulta de las cajas registradas por catálogo.
                if (Dt_Cajas is DataTable)
                {
                    if (Dt_Cajas.Rows.Count > 0)
                    {
                        var Lista = Dt_Cajas.AsEnumerable()
                            .Select(x => new
                            {
                                Caja_ID = x.IsNull(Cat_Cajas.Campo_Caja_ID) ? string.Empty : x.Field<string>(Cat_Cajas.Campo_Caja_ID),
                                Numero_Caja = x.IsNull(Cat_Cajas.Campo_Numero_Caja) ? string.Empty : x.Field<decimal>(Cat_Cajas.Campo_Numero_Caja).ToString("#")
                            }).ToList();

                        Lista.Insert(0, new { Caja_ID = string.Empty, Numero_Caja = "" });
                        Cmb_No_Caja.DataSource = Lista;
                        Cmb_No_Caja.ValueMember = Cat_Cajas.Campo_Caja_ID;
                        Cmb_No_Caja.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Método que carga los turnos en sistema.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:16 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Turnos()
        {
            Cls_Cat_Turnos_Negocio Obj_Turnos = new Cls_Cat_Turnos_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Turnos = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Turnos = Obj_Turnos.Consultar_Turnos();//Ejecutamos la consulta de las cajas registrados por catálogo.
                if (Dt_Turnos is DataTable)
                {
                    DataRow Dr = Dt_Turnos.NewRow();
                    Dr[Cat_Turnos.Campo_Turno_ID] = string.Empty;
                    Dr[Cat_Turnos.Campo_Nombre] = "";
                    Dt_Turnos.Rows.InsertAt(Dr, 0);
                }
                Cmb_Turno.DataSource = Dt_Turnos;
                Cmb_Turno.ValueMember = Cat_Turnos.Campo_Turno_ID;
                Cmb_Turno.DisplayMember = Cat_Turnos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método que carga los turnos en sistema.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:16 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Combo_Anio()
        {
            int Cont_Anio = 0;
            int Cont_Indice_Combo = 0;
            try
            {
                Cmb_Anio.Items.Clear();
                Cmb_Anio.Items.Insert(Cont_Indice_Combo, "SELECCIONE");
                Cont_Indice_Combo++;

                for (Cont_Anio = DateTime.Now.Year; Cont_Anio >= 2009; Cont_Anio--)
                {
                    Cmb_Anio.Items.Insert(Cont_Indice_Combo, Cont_Anio.ToString());
                    Cont_Indice_Combo++;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Combo_Anio]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************************************
        /// <summary>
        /// Obtiene de la clase de negocio un listado de ingresos por mes, año y tarifa y lo regresa como datatable
        /// </summary>
        /// <param name="Periodo_Inicio">fecha inicial para la consulta</param>
        /// <param name="Periodo_Final">fecha final a incluir en la consulta</param>
        /// <returns>un datatable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Consulta_Ingresos(DateTime Periodo_Inicio, DateTime Periodo_Final)
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos = new Cls_Rep_Ingresos_Negocio();

                // asignar fechas si tienen un valor asignado
                if (Periodo_Inicio != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Inicio = Periodo_Inicio;
                }
                if (Periodo_Final != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Final = Periodo_Final;
                }
                if (Cmb_Tarifa.SelectedIndex > 0)
                {
                    if (!Anio_Anterior)
                    {
                        Neg_Ingresos.P_Tarifa_Id = Cmb_Tarifa.SelectedValue.ToString();
                    }
                }
                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_No_Caja = Cmb_No_Caja.SelectedValue.ToString();
                }
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Turno = Cmb_Turno.SelectedValue.ToString();
                }
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if(Cmb_Tipo_Pago.SelectedIndex == 1)
                        Neg_Ingresos.P_Forma_ID = "00001";
                    else
                        Neg_Ingresos.P_Forma_ID = "00002";
                }

                if (Cmb_Lugar_Venta.Text is object)
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                        Neg_Ingresos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                return Neg_Ingresos.Consultar_Ingresos_Diarios();
            }
            catch (Exception Ex)
            {

                throw new Exception("[Consulta_Ingresos]: " + Ex.Message);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtiene de la clase de negocio un listado de accesos por día y lo regresa como datatable
        /// </summary>
        /// <param name="Periodo_Inicio">fecha inicial para la consulta</param>
        /// <param name="Periodo_Final">fecha final a incluir en la consulta</param>
        /// <returns>un datatable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Consulta_Accesos(DateTime Periodo_Inicio, DateTime Periodo_Final)
        {
            Cls_Rep_Ingresos_Negocio Neg_Ingresos = new Cls_Rep_Ingresos_Negocio();
            try
            {
                // asignar fechas si tienen un valor asignado
                if (Periodo_Inicio != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Inicio = new DateTime(Periodo_Inicio.Year, Periodo_Inicio.Month, Periodo_Inicio.Day, 0, 0, 0);
                }
                if (Periodo_Final != DateTime.MaxValue)
                {
                    Neg_Ingresos.P_Fecha_Final = new DateTime(Periodo_Final.Year, Periodo_Final.Month, Periodo_Final.Day, 23, 59, 59); ;
                }
                // si hay un elemento seleccionado en el combo tarifa, asignar la tarifa
                if (Cmb_Tarifa.SelectedIndex > 0)
                {
                    if (!Anio_Anterior)
                    {
                        Neg_Ingresos.P_Tarifa_Id = Cmb_Tarifa.SelectedValue.ToString();
                    }
                }

                //  caja
                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_No_Caja = Cmb_No_Caja.SelectedValue.ToString();
                }

                //  turno
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Turno = Cmb_Turno.SelectedValue.ToString();
                } 

                //  tipo de pago
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if (Cmb_Tipo_Pago.SelectedIndex == 1)
                        Neg_Ingresos.P_Forma_ID = "00001";
                    else
                        Neg_Ingresos.P_Forma_ID = "00002";
                }

                //  lugar de la venta
                if (Cmb_Lugar_Venta.Text is object)
                {
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                    {
                        Neg_Ingresos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;
                    }
                }

                return Neg_Ingresos.Consultar_Accesos_Diarios();
            }
            catch (Exception Ex)
            {

                throw new Exception("[Consulta_Accesos]: " + Ex.Message);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtiene de la clase de negocio un listado de accesos por día y lo regresa como datatable
        /// </summary>
        /// <param name="Periodo_Inicio">fecha inicial para la consulta</param>
        /// <param name="Periodo_Final">fecha final a incluir en la consulta</param>
        /// <returns>un datatable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Consulta_Accesos_Sin_Formato(DateTime Periodo_Inicio, DateTime Periodo_Final)
        {
            Cls_Rep_Ingresos_Negocio Neg_Ingresos = new Cls_Rep_Ingresos_Negocio();
            try
            {
                // asignar fechas si tienen un valor asignado
                if (Periodo_Inicio != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Inicio = Periodo_Inicio;
                }
                if (Periodo_Final != DateTime.MaxValue)
                {
                    Neg_Ingresos.P_Fecha_Final = Periodo_Final;
                }
                // si hay un elemento seleccionado en el combo tarifa, asignar la tarifa
                if (Cmb_Tarifa.SelectedIndex > 0)
                {
                    if (!Anio_Anterior)
                    {
                        Neg_Ingresos.P_Tarifa_Id = Cmb_Tarifa.SelectedValue.ToString();
                    }
                }

                //  caja
                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_No_Caja = Cmb_No_Caja.SelectedValue.ToString();
                }

                //  turno
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Turno = Cmb_Turno.SelectedValue.ToString();
                }

                //  tipo de pago
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if (Cmb_Tipo_Pago.SelectedIndex == 1)
                        Neg_Ingresos.P_Forma_ID = "00001";
                    else
                        Neg_Ingresos.P_Forma_ID = "00002";
                }

                //  lugar de la venta
                if (Cmb_Lugar_Venta.Text is object)
                {
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                    {
                        Neg_Ingresos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;
                    }
                }

                return Neg_Ingresos.Consultar_Accesos_Sin_Formato();
            }
            catch (Exception Ex)
            {

                throw new Exception("[Consulta_Accesos]: " + Ex.Message);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtiene de la clase de negocio un listado de accesos por día y lo regresa como datatable
        /// </summary>
        /// <param name="Periodo_Inicio">fecha inicial para la consulta</param>
        /// <param name="Periodo_Final">fecha final a incluir en la consulta</param>
        /// <returns>un datatable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Consulta_Tarifa(DateTime Periodo_Inicio, DateTime Periodo_Final, int Operacion)
        {
            Cls_Rep_Ingresos_Negocio Neg_Ingresos = new Cls_Rep_Ingresos_Negocio();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Auxiliar = new DataTable();
            try
            {
                // asignar fechas si tienen un valor asignado
                if (Periodo_Inicio != DateTime.MinValue)
                {
                    Periodo_Inicio = new DateTime(Periodo_Inicio.Year, Periodo_Inicio.Month, Periodo_Inicio.Day, 0, 0, 0);
                    Neg_Ingresos.P_Fecha_Inicio = Periodo_Inicio;
                }

                if (Periodo_Final != DateTime.MaxValue)
                {
                    Periodo_Final = new DateTime(Periodo_Final.Year, Periodo_Final.Month, Periodo_Final.Day, 23, 59, 59);
                    Neg_Ingresos.P_Fecha_Final = Periodo_Final;
                }

                // si hay un elemento seleccionado en el combo tarifa, asignar la tarifa
                if (Cmb_Tarifa.SelectedIndex > 0)
                {
                    if (!Anio_Anterior)
                    {
                        Neg_Ingresos.P_Tarifa_Id = Cmb_Tarifa.SelectedValue.ToString();
                    }
                }

                //  caja
                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_No_Caja = Cmb_No_Caja.SelectedValue.ToString();
                }

                //  turno
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Turno = Cmb_Turno.SelectedValue.ToString();
                }

                //  tipo de pago
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if (Cmb_Tipo_Pago.SelectedIndex == 1)
                        Neg_Ingresos.P_Forma_ID = "00001";
                    else
                        Neg_Ingresos.P_Forma_ID = "00002";
                }

                //  lugar de la venta
                if (Cmb_Lugar_Venta.Text is object)
                {
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                    {
                        Neg_Ingresos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;
                    }
                }

                Dt_Consulta = Neg_Ingresos.Consultar_Reporte_Diario_Recuadiacion_Tarifa();

                if (Operacion == 1)
                {
                    Dt_Auxiliar = Dt_Consulta.Copy();
                    Grd_Resultado.DataSource = Dt_Auxiliar;

                    // *******************************************************************************************************************************
                    //  se agrega el total x renglon
                    Dt_Consulta.Columns[0].ColumnName = "Fecha_";
                    Dt_Consulta.Columns[1].ColumnName = "Visitantes";
                    Dt_Consulta.Columns[2].ColumnName = "Recaudacion";
                    Dt_Consulta.Columns.Add("Fecha", typeof(DateTime));

                    foreach (DataRow Dr_Registro in Dt_Consulta.Rows)
                    {
                        Dr_Registro.BeginEdit();

                        //  se coloca la fecha
                        Dr_Registro["Fecha"] = Convert.ToDateTime(Dr_Registro["Fecha_"].ToString());

                        Dr_Registro.EndEdit();
                    }

                    Dt_Consulta.Columns.RemoveAt(0);//   se remueve la columna de la fecha original
                    Dt_Consulta.AcceptChanges();
                    Dt_Consulta.Columns["Fecha"].SetOrdinal(0);
                    Dt_Consulta.Columns["Visitantes"].SetOrdinal(1);
                    Dt_Consulta.Columns["Recaudacion"].SetOrdinal(2);
                    Dt_Consulta.AcceptChanges();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Accesos]: " + Ex.Message);
            }

            return Dt_Consulta;
        }
        ///*******************************************************************************************************
        /// <summary>
        /// forma un datatable con ingresos o accesos por día y totales a partir de las tablas 
        /// con ingresos y accesos agrupados por día y tarifa
        /// </summary>
        /// <param name="Dt_Ingresos_Accesos">datatable con los ingresos o accesos agrupados por día y tarifa</param>
        /// <returns>un datatable con los ingresos y accesos por año, nombre de mes, total por mes y total por año</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Generar_Tabla_Resultado(DataTable Dt_Ingresos_Accesos)
        {
            Double Total = 0;
            try
            {
                // obtener un listado de columnas para formar la tabla
                List<string> Nombre_Columnas = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                                select Fila_Ingresos.Field<string>("tarifa")).Distinct().ToList();

                Nombre_Columnas.Add("Total");

                DataTable Dt_Resultados = Formar_Tabla_Resultado(Nombre_Columnas);
                DataRow Dr_Nueva_Fila_Ingreso;
                DataTable Dt_Ingresos_Fecha;

                // obtener las diferentes fechas en la tabla
                var Dt_Fechas = (from DataRow Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                 select new { fecha = Fila_Ingresos.Field<MySqlDateTime>("fecha") }).Distinct();
                // bucle para cada fecha crear una fila con los ingresos por tarifa
                foreach (var Fila_Fecha in Dt_Fechas.Reverse())
                {
                    Total = 0;
                    // subconsulta linq para filtrar ingresos por fecha (en Fila_Fecha)
                    Dt_Ingresos_Fecha = (from Fila_Ingresos in Dt_Ingresos_Accesos.AsEnumerable()
                                         where Fila_Ingresos.Field<MySqlDateTime>("fecha").ToString() == Fila_Fecha.fecha.ToString()
                                         select Fila_Ingresos).AsDataView().ToTable();

                    // nueva fila
                    Dr_Nueva_Fila_Ingreso = Dt_Resultados.NewRow();
                    // asignar fecha
                    Dr_Nueva_Fila_Ingreso[0] = Fila_Fecha.fecha.GetDateTime();
                    // recorrer Dt_Ingresos_Fecha y agregar los montos la columna correspondiente (tarifa)
                    foreach (DataRow Fila_Ingreso in Dt_Ingresos_Fecha.Rows)
                    {
                        // si es el reporte de ingresos, agregar columnas tipo decimal
                        if (Cmb_Tipo_Reporte.Text == "Ingresos")
                        {
                            Dr_Nueva_Fila_Ingreso[Fila_Ingreso[2].ToString()] = (decimal)Fila_Ingreso[1];
                            Total = Total + (Double)((decimal)Fila_Ingreso[1]);
                        }
                        else if (Cmb_Tipo_Reporte.Text.Equals("Visitantes")) // agregar columnas de tipo entero
                        {
                            string aux = Fila_Ingreso[2].ToString();
                            Dr_Nueva_Fila_Ingreso[aux] = (Int64)Fila_Ingreso[1];
                            Total = Total + (Double)((Int64)Fila_Ingreso[1]);
                        }
                    }

                    //  se agrega el total
                    Dr_Nueva_Fila_Ingreso["Total"] = Total;

                    // agregar filas a la tabla
                    Dt_Resultados.Rows.Add(Dr_Nueva_Fila_Ingreso);
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
        /// genera un datatable nuevo con los campos para la tabla a partir de la lista que recibe como parámetro
        /// </summary>
        /// <param name="Columnas">listado de columnas para agregar a la nueva tabla</param>
        /// <returns>un datatable con los campos para mostrar accesos e ingresos por año y mes</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private DataTable Formar_Tabla_Resultado(List<string> Columnas)
        {
            DataTable Dt_Resultado = new DataTable();
            Dt_Resultado.Columns.Add(new DataColumn("fecha", typeof(DateTime)));

            // recorrer la lista de columnas para agregar a la tabla
            foreach (string Nombre_Columna in Columnas)
            {
                // si es el reporte de ingresos, agregar columnas tipo decimal
                if (Cmb_Tipo_Reporte.Text == "Ingresos")
                {
                    Dt_Resultado.Columns.Add(new DataColumn(Nombre_Columna, typeof(decimal)));
                    Dt_Resultado.Columns[Nombre_Columna].DefaultValue = 0M;
                }
                else if (Cmb_Tipo_Reporte.Text.Equals("Visitantes")) // agregar columnas de tipo entero
                {
                    Dt_Resultado.Columns.Add(new DataColumn(Nombre_Columna, typeof(int)));
                    Dt_Resultado.Columns[Nombre_Columna].DefaultValue = 0;
                }
            }

            return Dt_Resultado;
        }

        /// *************************************************************************************
        /// NOMBRE: Generar_Reporte
        /// 
        /// DESCRIPCIÓN: Método que invoca la generación del reporte.
        ///              
        /// PARÁMETROS: Nombre_Plantilla_Reporte.- Nombre del archivo del Crystal Report.
        ///             Nombre_Reporte_Generar.- Nombre que tendrá el reporte generado.
        /// 
        /// USUARIO CREO: Juan Alberto Hernández Negrete.
        /// FECHA CREO: 3/Mayo/2011 18:15 p.m.
        /// USUARIO MODIFICO:
        /// FECHA MODIFICO:
        /// CAUSA MODIFICACIÓN:
        /// *************************************************************************************
        protected void Generar_Reporte_Sin_Parametros(ref DataSet Ds_Datos, String Nombre_Plantilla_Reporte)
        {
            ReportDocument Reporte = new ReportDocument();//Variable de tipo reporte.
            String Ruta = String.Empty;//Variable que almacenara la ruta del archivo del crystal report. 

            try
            {
                Ruta = (Nombre_Plantilla_Reporte);
                Reporte.Load(Ruta);

                if (Ds_Datos is DataSet)
                {
                    if (Ds_Datos.Tables.Count > 0)
                    {
                        Reporte.SetDataSource(Ds_Datos);

                        Frm_Rpt_Mostrar_Reporte_ Frm_Mostrar_Reporte = new Frm_Rpt_Mostrar_Reporte_();
                        Frm_Mostrar_Reporte.P_Reporte = Reporte;
                        Frm_Mostrar_Reporte.ShowDialog(this);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte. Error: [" + Ex.Message + "]");
            }
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable Comparativo()
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos = new Cls_Rep_Ingresos_Negocio();
                Cls_Cat_Productos_Negocio P_Productos = new Cls_Cat_Productos_Negocio();

                if (Dtp_Periodo_Inicial.Value != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Inicio = Dtp_Periodo_Inicial.Value;
                }
                
                if (Dtp_Periodo_Final.Value != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Final = Dtp_Periodo_Final.Value;
                }
                
                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_No_Caja = Cmb_No_Caja.SelectedValue.ToString();
                }
                
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Turno = Cmb_Turno.SelectedValue.ToString();
                }
                
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if (Cmb_Tipo_Pago.SelectedIndex == 1)
                        Neg_Ingresos.P_Forma_ID = "00001";
                    else
                        Neg_Ingresos.P_Forma_ID = "00002";
                }

                if (Cmb_Lugar_Venta.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;
                }

                DataTable Aux = Neg_Ingresos.Consultar_Comparativo(false);
                DataTable Aux_Anterior = Neg_Ingresos.Consultar_Comparativo(true);
                DataTable Diario = new DataTable("Comparativo");

                Diario.Columns.Add("Fecha", typeof(DateTime));
                Diario.Columns.Add("Producto", typeof(string));
                Diario.Columns.Add("Recaudacion_Actual", typeof(decimal));
                Diario.Columns.Add("Visitantes_Actual", typeof(decimal));
                Diario.Columns.Add("Recaudacion_Anterior", typeof(decimal));
                Diario.Columns.Add("Visitantes_Anterior", typeof(decimal));

                var leftJoin = from Actual in Aux.AsEnumerable()
                               join Anterior in Aux_Anterior.AsEnumerable()
                               on
                                 new
                                 {
                                     P = Actual.Field<string>("Producto_Anterior"),
                                     M = Actual.Field<DateTime>("Fecha").Month,
                                     D = Actual.Field<DateTime>("Fecha").Day
                                 }
                               equals
                                 new
                                 {
                                     P = Anterior.Field<string>("Producto_ID"),
                                     M = Anterior.Field<DateTime>("Fecha").Month,
                                     D = Anterior.Field<DateTime>("Fecha").Day
                                 } into Cmp
                               from R in Cmp.DefaultIfEmpty()
                               select new
                               {
                                   Fecha = Actual.Field<DateTime>("Fecha"),
                                   Producto = Actual.Field<string>("Producto_ID"),
                                   RecAct = Actual.Field<decimal>("Total"),
                                   VisActual = Actual.Field<decimal>("Visitantes"),
                                   RecAnt = R == null ? 0 : R.Field<decimal>("Total"),
                                   VisAnt = R == null ? 0 : R.Field<decimal>("Visitantes")
                               };

                var rightJoin = from Anterior in Aux_Anterior.AsEnumerable()
                                join Actual in Aux.AsEnumerable()
                                on
                                  new
                                  {
                                      P = Anterior.Field<string>("Producto_ID"),//Producto_ID
                                      M = Anterior.Field<DateTime>("Fecha").Month,
                                      D = Anterior.Field<DateTime>("Fecha").Day
                                  }
                                equals
                                  new
                                  {
                                      P = Actual.Field<string>("Producto_Anterior"),
                                      M = Actual.Field<DateTime>("Fecha").Month,
                                      D = Actual.Field<DateTime>("Fecha").Day
                                  } into Cmp
                                from R in Cmp.DefaultIfEmpty()
                                select new
                                {
                                    Fecha = Anterior.Field<DateTime>("Fecha").AddYears(1),
                                    Producto = Anterior.Field<string>("Producto_Siguiente") == null ?
                                        Anterior.Field<string>("Producto_ID") :
                                        Anterior.Field<string>("Producto_Siguiente"),
                                    RecAct = R == null ? 0 : R.Field<decimal>("Total"),
                                    VisActual = R == null ? 0 : R.Field<decimal>("Visitantes"),
                                    RecAnt = Anterior.Field<decimal>("Total"),
                                    VisAnt = Anterior.Field<decimal>("Visitantes")
                                };

                var Res = leftJoin.Union(rightJoin);

                string Nombre_Producto;
                Dt_Productos = P_Productos.Consultar_Producto_Venta();

                foreach (var item in Res)
                {
                    DataRow[] Dr_Productos = Dt_Productos.Select("Producto_ID = '" + item.Producto + "'");

                    if (Dr_Productos.Length == 0)
                    {
                        Nombre_Producto = string.Empty;
                    }
                    else
                    {
                        Nombre_Producto = Dr_Productos[0]["Nombre"].ToString();
                    }

                    Diario.Rows.Add(item.Fecha, Nombre_Producto.Trim().ToUpper(), item.RecAct,
                        item.VisActual, item.RecAnt, item.VisAnt);
                }

                if (Diario.Rows.Count > 0)
                {
                    Diario = (from D in Diario.AsEnumerable()
                              orderby D.Field<DateTime>("Fecha") ascending
                              select D).CopyToDataTable();

                    Diario.TableName = "Comparativo";
                }

                return Diario;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// método que muestra el reporte en un diálogo (formulario Frm_Rpt_Mostrar_Reporte_)
        /// </summary>
        /// <param name="Ds_Reporte">Dataset con la información a mostrar en el reporte</param>
        /// <param name="Nombre_Plantilla_Reporte">nombre del archivo rpt del reporte a mostrar</param>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        protected void Generar_Reporte(DataSet Ds_Reporte, String Nombre_Plantilla_Reporte)
        {
            ReportDocument Reporte = new ReportDocument();//Variable de tipo reporte.
            
            try
            {
                Reporte.Load(Nombre_Plantilla_Reporte);

                // agregar dataset al reporte
                Reporte.SetDataSource(Ds_Reporte);
                Frm_Rpt_Mostrar_Reporte_ Frm_Mostrar_Reporte = new Frm_Rpt_Mostrar_Reporte_();

                ParameterFieldDefinitions Parametros = Reporte.DataDefinition.ParameterFields;
                ParameterFieldDefinition Parametro;
                ParameterDiscreteValue Valor = new ParameterDiscreteValue();
                ParameterValues Valores = new ParameterValues();

                List<object[]> objParametros = new List<object[]>();

                objParametros.Add(new object[] { Dtp_Periodo_Inicial.Value, "Periodo_Inicial" });
                objParametros.Add(new object[] { Dtp_Periodo_Final.Value, "Periodo_Final" });
                objParametros.Add(new object[] { string.Empty, "Estatus" });
                objParametros.Add(new object[] { string.Empty, "Museo" });
                objParametros.Add(new object[] { string.Empty, "Folio" });
                objParametros.Add(new object[] { DateTime.Now, "Fecha_Creo" });
                objParametros.Add(new object[] { MDI_Frm_Apl_Principal.Nombre_Usuario, "Usuario_Creo" });

                if (Cmb_Turno.SelectedIndex > 0)
                {
                    objParametros.Add(new object[] { Cmb_Turno.Text, "Turno" });
                }
                else
                {
                    objParametros.Add(new object[] { string.Empty, "Turno" });
                }

                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    objParametros.Add(new object[] { Cmb_No_Caja.Text, "No_Caja" });
                }
                else
                {
                    objParametros.Add(new object[] { string.Empty, "No_Caja" });
                }

                if (Cmb_Lugar_Venta.SelectedIndex > 0)
                {
                    objParametros.Add(new object[] { Cmb_Lugar_Venta.Text, "Lugar_Venta" });
                }
                else
                {
                    objParametros.Add(new object[] { string.Empty, "Lugar_Venta" });
                }

                if (Cmb_Tarifa.SelectedIndex > 0)
                {
                    objParametros.Add(new object[] { Cmb_Tarifa.Text, "Tarifa" });
                }
                else
                {
                    objParametros.Add(new object[] { string.Empty, "Tarifa" });
                }

                if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                {
                    objParametros.Add(new object[] { Cmb_Tipo_Reporte.Text, "Tipo" });
                }

                if (Cmb_Tipo_Reporte.Text.Equals("Visitantes"))
                {
                    objParametros.Add(new object[] { Cmb_Tipo_Reporte.Text, "Tipo" });
                }
                

                foreach (object[] objParametro in objParametros)
                {
                    Parametro = Parametros[objParametro[1].ToString()];
                    Valores = Parametro.CurrentValues;
                    Valores.Clear();

                    Valor.Value = objParametro[0];
                    Valores.Add(Valor);
                    Parametro.ApplyCurrentValues(Valores);
                }

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

        /// <summary>
        /// Se genera la información de Ingresos para el Diario de Recaudación.
        /// </summary>
        /// <returns>DataTable con las Tarifas como columnas.</returns>
        private DataTable Informacion_Ingresos(int tipo)
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos = new Cls_Rep_Ingresos_Negocio();

                if (Dtp_Periodo_Inicial.Value != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Inicio = Dtp_Periodo_Inicial.Value;
                }
                
                if (Dtp_Periodo_Final.Value != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Final = Dtp_Periodo_Final.Value;
                }
                
                if (Cmb_Tarifa.SelectedIndex > 0)
                {
                    if (!Anio_Anterior)
                    {
                        Neg_Ingresos.P_Tarifa_Id = Cmb_Tarifa.SelectedValue.ToString();
                    }
                }
                
                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_No_Caja = Cmb_No_Caja.SelectedValue.ToString();
                }
                
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Turno = Cmb_Turno.SelectedValue.ToString();
                }

                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {
                    if (Cmb_Tipo_Pago.SelectedIndex == 1)
                        Neg_Ingresos.P_Forma_ID = "00001";
                    else
                        Neg_Ingresos.P_Forma_ID = "00002";
                }

                if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                {
                    Neg_Ingresos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;
                }

                if (tipo == 0)
                {
                    return Neg_Ingresos.Consultar_Ingresos_Diarios();
                }
                else
                {
                    return Neg_Ingresos.Consultar_Ingresos_Diarios_Crystal();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Genera el Archivo de Excel de Diario de Recaudación de Ingresos.
        /// </summary>
        private void Generar_Excel_Ingresos()
        {
            try
            {
                SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
                Sfd_Ruta_Archivo.Filter = "Archivos de Excel(*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // Generación del Archivo de Excel.
                // Validación a la Ruta del Archivo.
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    // Se consulta la información de la Base de Datos.
                    DataTable Res_Aux = Informacion_Ingresos(0);
                    DataTable Res = new DataTable("Padre");

                    Res.Columns.Add("Fecha", typeof(DateTime));
                    for (int j = 1; j < Res_Aux.Columns.Count; j++)
                    {
                        Res.Columns.Add(Res_Aux.Columns[j].ColumnName, Res_Aux.Columns[j].DataType);
                    }

                    foreach (DataRow Fila in Res_Aux.Rows)
                    {
                        Res.Rows.Add(Fila.ItemArray);
                    }

                    Res.Columns.Add("Total", typeof(decimal));

                    DataRow Totales = Res.NewRow();

                    decimal Total_Fecha = 0;
                    decimal Totales_Fecha = 0;
                    decimal Totales_Producto = 0;

                    for (int i = 0; i < Res.Rows.Count; i++)
                    {
                        Total_Fecha = 0;

                        for (int j = 1; j < Res.Columns.Count - 1; j++)
                        {
                            if (i == 0)
                            {
                                decimal Aux = (from P in Res.AsEnumerable()
                                               select P.Field<decimal>(j)).Sum();

                                Totales[j] = Aux;
                                Totales_Producto += Aux;
                            }

                            Total_Fecha += Convert.ToDecimal(Res.Rows[i][j]);
                        }

                        Res.Rows[i][Res.Columns.Count - 1] = Total_Fecha;
                        Totales_Fecha += Total_Fecha;
                    }

                    // Se valida si existe un archivo.
                    if (File.Exists(Sfd_Ruta_Archivo.FileName)) File.Delete(Sfd_Ruta_Archivo.FileName);
                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    // Se genera el encabezado de los Filtros (En caso que aplique).
                    string Filtros = string.Empty;

                    if (Cmb_Turno.SelectedIndex > 0)
                    {
                        Filtros += "Turno: " + Cmb_Turno.Text + ", ";
                    }

                    if (Cmb_No_Caja.SelectedIndex > 0)
                    {
                        Filtros += "No. Caja: " + Cmb_No_Caja.Text + ", ";
                    }

                    if (Cmb_Lugar_Venta.SelectedIndex > 0)
                    {
                        if (Cmb_Lugar_Venta.Text == "No Caja")
                        {
                            Filtros += "Lugar de la Venta: Número de Caja, "; ;
                        }
                        else
                        {
                            Filtros += "Lugar de la Venta: Número de Caja, ";
                        }
                    }

                    if (Cmb_Tarifa.SelectedIndex > 0)
                    {
                        Filtros += "Tarifa: " + Cmb_Tarifa.Text + ", ";
                    }

                    if (Cmb_Tipo_Reporte.Text.Equals("Ingresos")
                    || Cmb_Tipo_Reporte.Text.Equals("Visitantes"))
                    {
                        Filtros += "Tipo: " + Cmb_Tipo_Reporte.Text + ", ";
                    }
                    
                    if (Filtros != string.Empty)
                    {
                        Filtros = Filtros.Remove(Filtros.LastIndexOf(","));
                    }

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Ventas");

                        Detallado.Cells["A1"].Value = "Tesorería Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las Momias";
                        Detallado.Cells["A4"].Value = "Periodo: De " + Dtp_Periodo_Inicial.Value.ToLongDateString() + " al " + Dtp_Periodo_Inicial.Value.ToLongDateString();
                        Detallado.Cells["A5"].Value = Filtros;

                        // Encabezados del Reporte.
                        string Letra_Fin = ((char)(65 + Res.Columns.Count - 1)).ToString();

                        Detallado.Cells["A1:J5"].Style.Font.Bold = true;

                        Detallado.Cells["A1:" + Letra_Fin + "1"].Merge = true;
                        Detallado.Cells["A2:" + Letra_Fin + "2"].Merge = true;
                        Detallado.Cells["A3:" + Letra_Fin + "3"].Merge = true;
                        Detallado.Cells["A4:" + Letra_Fin + "4"].Merge = true;
                        Detallado.Cells["A5:" + Letra_Fin + "5"].Merge = true;

                        Detallado.Cells["A1:" + Letra_Fin + "1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A2:" + Letra_Fin + "2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A3:" + Letra_Fin + "3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A4:" + Letra_Fin + "4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A5:" + Letra_Fin + "5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado.Cells["A1:" + Letra_Fin + "1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A2:" + Letra_Fin + "2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A3:" + Letra_Fin + "3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A4:" + Letra_Fin + "4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A5:" + Letra_Fin + "5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        ExcelRangeBase Rango = Detallado.Cells["A7"].LoadFromDataTable(Res,
                                                       true, OfficeOpenXml.Table.TableStyles.Medium2);

                        int Fila = Rango.End.Row + 1;

                        for (int i = 1; i < Res.Columns.Count; i++)
                        {
                            string celda = ((char)(65 + i)).ToString() + Fila;
                            Detallado.Cells[celda].Formula = "SUM(Padre[" + Res.Columns[i].ColumnName + "])";
                        }

                        // Formato de Fechas
                        Detallado.Cells[7, 1, Fila, 1].Style.Numberformat.Format = "mm-dd-yy";
                        Detallado.Cells[7, 2, Fila, Rango.End.Column].Style.Numberformat.Format = "#,##0.00";

                        Fila += 2;
                        Detallado.Cells["A" + Fila.ToString()].Value = "Usuario Creó: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Detallado.Cells["A" + (++Fila).ToString()].Value = "Fecha de Emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();

                        Rango.AutoFitColumns();
                        Epc_Accesos.Save();

                        MessageBox.Show("Archivo Guardado Correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Genera el Comparativo en un archivo de Excel (Hoja por Producto).
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna.</creo>
        /// <fecha_creo>13 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Generar_Excel_Comparativo()
        {
            DataTable Dt_Comparativo = new DataTable();
            DataTable Distinct = new DataTable();

            try
            {
                SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
                Sfd_Ruta_Archivo.Filter = "Archivos de Excel(*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // Generación del Archivo de Excel.
                // Validación a la Ruta del Archivo.
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    Dt_Comparativo = Comparativo();

                    var Aux = from P in Dt_Comparativo.AsEnumerable()
                              .GroupBy(i => i.Field<string>("Producto"))
                              .Select(g => g.First())
                              .ToList()
                              orderby P.Field<string>("Producto")
                              select new { Producto = P.Field<string>("Producto") };

                    if (File.Exists(Sfd_Ruta_Archivo.FileName)) 
                        File.Delete(Sfd_Ruta_Archivo.FileName);
 
                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    string Filtros = string.Empty;

                    if (Cmb_Turno.SelectedIndex > 0)
                    {
                        Filtros += "Turno: " + Cmb_Turno.Text + ", ";
                    }

                    if (Cmb_No_Caja.SelectedIndex > 0)
                    {
                        Filtros += "No. Caja: " + Cmb_No_Caja.Text + ", ";
                    }

                    if (Cmb_Lugar_Venta.SelectedIndex > 0)
                    {
                        if (Cmb_Lugar_Venta.Text == "No. caja")
                        {
                            Filtros += "Lugar de la Venta: Número de Caja, "; ;
                        }
                        else
                        {
                            Filtros += "Lugar de la Venta: " + Cmb_Lugar_Venta.Text + ", ";
                        }
                    }

                    if (Cmb_Tarifa.SelectedIndex > 0)
                    {
                        Filtros += "Tarifa: " + Cmb_Tarifa.Text + ", ";
                    }

                    if (Filtros != string.Empty)
                    {
                        Filtros = Filtros.Remove(Filtros.LastIndexOf(","));
                    }

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        DataTable Productos;
                        foreach (var item in Aux)
                        {
                            ExcelWorksheet Hoja = Epc_Accesos.Workbook.Worksheets.Add(item.Producto);

                            Productos = (from P in Dt_Comparativo.AsEnumerable()
                                         where P.Field<string>("Producto") == item.Producto
                                         orderby P.Field<DateTime>("Fecha")
                                         select P).CopyToDataTable();

                            Productos.TableName = item.Producto.Replace("/", " ");
                            Productos.Columns.Remove("Producto");

                            Hoja.Cells["A1"].Value = "Tesorería Municipal";
                            Hoja.Cells["A2"].Value = "Dirección de Ingresos";
                            Hoja.Cells["A3"].Value = "Museo de las Momias";
                            Hoja.Cells["A4"].Value = "Periodo: De " + Dtp_Periodo_Inicial.Value.ToLongDateString() + " al " + Dtp_Periodo_Inicial.Value.ToLongDateString();
                            Hoja.Cells["A5"].Value = Filtros;

                            Hoja.Cells["B7"].Value = "VISITANTES";
                            Hoja.Cells["D7"].Value = "RECAUDACIÓN";

                            Hoja.Cells["B8"].Value = Dtp_Periodo_Inicial.Value.Year - 1;
                            Hoja.Cells["C8"].Value = Dtp_Periodo_Inicial.Value.Year;
                            Hoja.Cells["D8"].Value = Dtp_Periodo_Inicial.Value.Year - 1;
                            Hoja.Cells["E8"].Value = Dtp_Periodo_Inicial.Value.Year;

                            Hoja.Cells["A1:J5"].Style.Font.Bold = true;

                            Hoja.Cells["A1:E1"].Merge = true;
                            Hoja.Cells["A2:E2"].Merge = true;
                            Hoja.Cells["A3:E3"].Merge = true;
                            Hoja.Cells["A4:E4"].Merge = true;
                            Hoja.Cells["A5:E5"].Merge = true;

                            Hoja.Cells["B7:C7"].Merge = true;
                            Hoja.Cells["D7:E7"].Merge = true;
                            Hoja.Cells["B7:E7"].Style.Font.Bold = true;

                            Hoja.Cells["A1:E1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Hoja.Cells["A2:E2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Hoja.Cells["A3:E3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Hoja.Cells["A4:E4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Hoja.Cells["A5:E5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Hoja.Cells["B7:E7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            Hoja.Cells["A1:E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Hoja.Cells["A2:E2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Hoja.Cells["A3:E3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Hoja.Cells["A4:E4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Hoja.Cells["A5:E5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Hoja.Cells["B7:E7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                            Productos.Columns["Visitantes_Anterior"].SetOrdinal(1);
                            Productos.Columns["Visitantes_Actual"].SetOrdinal(2);
                            Productos.Columns["Recaudacion_Anterior"].SetOrdinal(3);
                            Productos.Columns["Recaudacion_Actual"].SetOrdinal(4);

                            Productos.Columns[1].ColumnName = "V. Anterior";
                            Productos.Columns[2].ColumnName = "V. Actual";
                            Productos.Columns[3].ColumnName = "R. Anterior";
                            Productos.Columns[4].ColumnName = "R. Actual";

                            ExcelRangeBase Rango = Hoja.Cells["A9"].LoadFromDataTable(Productos,
                                                       true, OfficeOpenXml.Table.TableStyles.Medium2);

                            int Fila = Rango.End.Row + 1;

                            for (int i = 1; i < Productos.Columns.Count; i++)
                            {
                                string celda = ((char)(66 + i)).ToString() + Fila;
                                Hoja.Cells[celda].Formula = "SUM(" + Productos.TableName + "[" +
                                    Productos.Columns[i].ColumnName + "])";
                            }

                            Hoja.Cells[1, 1, Rango.End.Row, 1].Style.Numberformat.Format = "dd/mmm";
                            Hoja.Cells[9, 4, Fila, Rango.End.Column].Style.Numberformat.Format = "#,##0.00";

                            Fila++;
                            Hoja.Cells["A" + (++Fila).ToString()].Value = "Usuario Creó: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                            Hoja.Cells["A" + (++Fila).ToString()].Value = "Fecha Creó: " + DateTime.Now.ToLongDateString();

                            //Rango.AutoFitColumns();
                        }

                        Epc_Accesos.Save();
                    }

                    MessageBox.Show("Archivo Guardado Correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion METODOS

        #region EVENTOS

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento Load para el formulario: carga de combos y configuración inicial del formulario
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Frm_Rep_Diario_Recaudacion_Load(object sender, EventArgs e)
        {
            // consultar catálogo de productos
            Cls_Cat_Productos_Negocio Neg_Productos = new Cls_Cat_Productos_Negocio();
            //Neg_Productos.P_Estatus = "ACTIVO";

            Dt_Productos = Neg_Productos.Consultar_Producto();
            
            // cargar combo tarifas
            Cmb_Tarifa.DisplayMember = Cat_Productos.Campo_Nombre;
            Cmb_Tarifa.ValueMember = Cat_Productos.Campo_Producto_Id;
            //Cmb_Tarifa.DataSource = Dt_Productos;

            Cargar_Cajas();
            Cargar_Turnos();
            Cargar_Combo_Anio();

            Cmb_Tipo_Reporte.SelectedIndex = 0;
            Cmb_Anio.SelectedIndex = 0;
            Cmb_Tarifa.SelectedIndex = 0;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón buscar: llamar al método que consulta la información y 
        /// carga el resultado en el grid
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            DataTable Dt_Resultado = new DataTable();
            DataTable Dt_Accesos_Ingresos = new DataTable();
            Boolean Filtro_Tarifa = false;
            try
            {
                Anio_Anterior = false;

                // si es mayor la fecha inicial que la fecha final, mostrar mensaje
                if (Dtp_Periodo_Inicial.Value.Date > Dtp_Periodo_Final.Value.Date)
                {
                    MessageBox.Show(this, "La fecha del periodo inicial no puede ser mayor al periodo final, por favor seleccione un rango válido.", "Seleccionar rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Cmb_Tarifa.SelectedIndex > 0)// tarifa
                {
                    Dt_Accesos_Ingresos = Consulta_Tarifa(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value, 0);
                }
                // consultar por tipo de reporte (ingresos o accesos)
                else if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                {
                    Dt_Accesos_Ingresos = Consulta_Ingresos(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);

                    Dt_Accesos_Ingresos.Columns.Add("Totales", typeof(decimal));
                    DataRow Totales = Dt_Accesos_Ingresos.NewRow();
                    decimal Total_Fila;
                    decimal Total_General;
                    int Indice = Dt_Accesos_Ingresos.Rows.Count;

                    for (int i = 0; i < Dt_Accesos_Ingresos.Rows.Count; i++)
                    {
                        Total_Fila = 0;

                        for (int j = 1; j < Dt_Accesos_Ingresos.Columns.Count - 1; j++)
                        {
                            if (i == 0)
                            {
                                Totales[j] = (from T in Dt_Accesos_Ingresos.AsEnumerable()
                                              select T.Field<decimal>(j)).Sum();

                            }

                            Total_Fila += Convert.ToDecimal(Dt_Accesos_Ingresos.Rows[i][j]);
                        }

                        Dt_Accesos_Ingresos.Rows[i]["Totales"] = Total_Fila;
                    }

                    Dt_Accesos_Ingresos.Rows.Add(Totales);

                    // Se agrega el Total General del Reporte.
                    Total_General = (from T in Dt_Accesos_Ingresos.AsEnumerable()
                                     where !T.IsNull("Totales")
                                     select T.Field<decimal>("Totales")).Sum();

                    Dt_Accesos_Ingresos.Rows[Indice]["Totales"] = Total_General;

                    /********* Formato con el sigo de $ *********/
                    DataTable Dt_Aux = new DataTable();

                    for (int i = 0; i < Dt_Accesos_Ingresos.Columns.Count; i++)
                    {
                        Dt_Aux.Columns.Add(Dt_Accesos_Ingresos.Columns[i].ColumnName, typeof(string));
                    }

                    // Dar formato a la Tabla.
                    for (int i = 0; i < Dt_Accesos_Ingresos.Rows.Count; i++)
                    {
                        DataRow Fila = Dt_Aux.NewRow();

                        for (int j = 0; j < Dt_Accesos_Ingresos.Columns.Count; j++)
                        {
                            if (j == 0)
                                Fila[j] = Dt_Accesos_Ingresos.Rows[i][j];
                            else
                                Fila[j] = Convert.ToDecimal(Dt_Accesos_Ingresos.Rows[i][j]).ToString("C");
                        }

                        Dt_Aux.Rows.Add(Fila);
                    }

                    Dt_Accesos_Ingresos = Dt_Aux;
                }
                else if (Cmb_Tipo_Reporte.Text.Equals("Visitantes"))
                {
                    Dt_Accesos_Ingresos = Consulta_Accesos(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);
                }
                else if (Cmb_Tipo_Reporte.Text.Equals("Comparativo"))
                {
                    Dt_Accesos_Ingresos = Comparativo();
                }

                // cargar resultado en el grid
                Grd_Resultado.DataSource = Dt_Accesos_Ingresos;
                
                //// habilitar botón exportar
                //Btn_Exportar_PDF.Enabled = true;
                //Btn_Exportar_PDF_iTextSharp.Enabled = true;
                //Btn_Exportar_Excel.Enabled = true;
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
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_General = new DataTable();
            DataTable Dt_Accesos_Ingresos = new DataTable();
            Ds_Rep_Diario_Recaudacion Ds_Reporte = new Ds_Rep_Diario_Recaudacion();
            DataRow Dr_Fila_Nueva;
            DataTable Dt_Reporte = new DataTable();
            MySqlDateTime Fecha_Mysql = new MySqlDateTime();
            string Nombre_Plantilla = "";

            try
            {
                if (Cmb_Tarifa.SelectedIndex > 0)// tarifa
                {
                    Exportar_Excel_Producto();
                }
                else if (Cmb_Tipo_Reporte.Text.Equals("Visitantes"))//  visitantes
                {
                    Exportar_Excel_Accesos();
                }
                // consultar detalles de ingresos o accesos
                else if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))//**************************************************************************************************
                {
                    Generar_Excel_Ingresos();
                }
                else if (Cmb_Tipo_Reporte.Text.Equals("Comparativo"))
                {
                    Generar_Excel_Comparativo();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Btn_Exportar_Excel_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Exportar_Excel_Accesos()
        {
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Datos_Generales = new DataTable();
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_Accesos_Ingresos = new DataTable();
            String Str_Columna_Tope = ""; //    contendra la letra que se utilizara como tope en el archivo de excel
            try
            {
                // *******************************************************************************************************************************
                //  se obtiene el diccionario referente a las columnas en excel
                Dictionary<Int32, string> Dic_Equivalencias_Excel = Obtener_Columnas_Excel();

                // *******************************************************************************************************************************
                Dt_Consulta = Consulta_Accesos(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);
                Grd_Resultado.DataSource = Dt_Consulta;

                // *******************************************************************************************************************************
                //  se agrega el total x renglon
                Dt_Consulta.Columns[0].ColumnName = "Fecha_";
                Dt_Consulta.Columns.Add("Total", typeof(Double));
                Dt_Consulta.Columns.Add("Fecha", typeof(DateTime));

                Double Db_Total = 0;
                Int32 Cont_Columnas = 0;

                Cont_Columnas = Dt_Consulta.Columns.Count;

                foreach (DataRow Dr_Registro in Dt_Consulta.Rows)
                {
                    Db_Total = 0;
                    Dr_Registro.BeginEdit();

                    //  se coloca la fecha
                    Dr_Registro["Fecha"] = Convert.ToDateTime(Dr_Registro["Fecha_"].ToString());

                    //  se recorren la informacion del registro, esto para obtener el total del renglon
                    for (int Cont_For = 1; Cont_For < Cont_Columnas - 2; Cont_For++)
                    {
                        Db_Total = Db_Total + Convert.ToDouble(Dr_Registro[Cont_For].ToString());
                    }

                    //  se ingresa el total
                    Dr_Registro["Total"] = Db_Total;
                    Dr_Registro.EndEdit();
                }

                Dt_Consulta.Columns.RemoveAt(0);//   se remueve la columna de la fecha original
                Dt_Consulta.AcceptChanges();
                Dt_Consulta.Columns["Fecha"].SetOrdinal(0);
                Dt_Consulta.AcceptChanges();
                Cont_Columnas = Dt_Consulta.Columns.Count;
                // *******************************************************************************************************************************
                //  se obtiene el tope del archivo de excel
                if (Dic_Equivalencias_Excel.ContainsKey(Cont_Columnas - 1) == true)
                {
                    Str_Columna_Tope = Dic_Equivalencias_Excel[Cont_Columnas - 1];
                }
                else
                {
                    Str_Columna_Tope = "Z";
                }

                // *******************************************************************************************************************************
                //  datos generales del reporte
                Dt_Datos_Generales = Crear_Tabla_Datos_Generales(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);

                // *******************************************************************************************************************************
                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // *******************************************************************************************************************************

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName))
                    {
                        File.Delete(Sfd_Ruta_Archivo.FileName);
                    }

                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Tipo de pago");
                        // *******************************************************************************************************************************
                        Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las momias";
                        Detallado.Cells["A4"].Value = Dt_Datos_Generales.Rows[0][2].ToString();
                        Detallado.Cells["A5"].Value = Dt_Datos_Generales.Rows[0][3].ToString();

                        Detallado.Cells["A7"].Value = "Diario de visitantes";

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

                        // *******************************************************************************************************************************
                        Int32 Filas = 8;
                        //  se carga el archivo
                        ExcelRangeBase Rango = Detallado.Cells["A" + Filas].LoadFromDataTable(Dt_Consulta, true, OfficeOpenXml.Table.TableStyles.Medium2);

                        // *******************************************************************************************************************************
                        //  formato a las celdas 
                        Detallado.Cells[Filas, 2, Rango.End.Row, Dt_Consulta.Columns.Count].Style.Numberformat.Format = "#,##0";
                        //  formato de fecha
                        Detallado.Cells[Filas, 1, Rango.End.Row, 1].Style.Numberformat.Format = "mm-dd-yy";

                        Filas = Filas + Dt_Consulta.Rows.Count + 1;

                        // *******************************************************************************************************************************
                        //  subtotal
                        Detallado.Cells[(Filas), 1, (Filas), Cont_Columnas].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.Font.Bold = true;

                        for (Int32 Cont_For = 1; Cont_For < Cont_Columnas; Cont_For++)
                        {
                            if (Dic_Equivalencias_Excel.ContainsKey(Cont_For) == true)
                            {
                                Detallado.Cells[Dic_Equivalencias_Excel[Cont_For] + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[" + Dt_Consulta.Columns[Cont_For].ColumnName + "] )");
                            }
                        }

                        Filas = Filas + 2;

                        // *******************************************************************************************************************************
                        //  pie de pagina
                        Detallado.Cells["A" + Filas.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Detallado.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();

                        // *******************************************************************************************************************************
                        Rango.AutoFitColumns();
                        Epc_Accesos.Save();
                    }
                    MessageBox.Show(this, "Exportacion exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Exportar_Excel_Concentrado_Ventas). Descripción: " + Ex.Message);
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
        private void Exportar_Pdf_Ingresos_Accesos(SaveFileDialog Sfd_Ruta_Archivo, DataTable Res)
        {
            try
            {
                using (FileStream Archivo_PDF = new FileStream(Sfd_Ruta_Archivo.FileName, FileMode.Create,
                           FileAccess.Write, FileShare.None))
                {
                    iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.LETTER.Rotate());
                    Document doc = new Document(rec);
                    doc.SetMargins(doc.LeftMargin, doc.RightMargin, doc.TopMargin + 50, doc.BottomMargin);
                    PdfWriter PDF = PdfWriter.GetInstance(doc, Archivo_PDF);
                    string Tipo_Reporte = string.Empty;

                    if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                        Tipo_Reporte = "Tipo: Ingresos";
                    else if (Cmb_Tipo_Reporte.Text.Equals("Visitantes"))
                        Tipo_Reporte = "Tipo: Visitantes";

                    // Se agrega el Encabezado y Pie de Página.
                    PageEventHandler evt = new PageEventHandler()
                    {
                        Fecha_Inicio = Dtp_Periodo_Inicial.Value,
                        Fecha_Fin = Dtp_Periodo_Final.Value,
                        Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario,
                        Posicion_Encabezado = 600,
                        Tipo_Reporte = Tipo_Reporte
                    };

                    PDF.PageEvent = evt;

                    doc.Open();
                    doc.NewPage();

                    PdfPTable table = new PdfPTable(Res.Columns.Count + 1);
                    PdfPCell cell = new PdfPCell();

                    iTextSharp.text.Font fnt = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 4,
                        iTextSharp.text.Font.BOLDITALIC));

                    iTextSharp.text.Font fnt_Totales = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 5,
                        iTextSharp.text.Font.BOLD));

                    float[] widths = new float[Res.Columns.Count + 1];
                    decimal[] totales = new decimal[Res.Columns.Count + 1];

                    float val = 430 / Res.Columns.Count + 1;

                    for (int i = 0; i < Res.Columns.Count + 1; i++)
                    {
                        widths[i] = val;
                    }

                    table.SetWidths(widths);
                    table.WidthPercentage = 100;

                    foreach (DataColumn Col in Res.Columns)
                    {
                        table.AddCell(new PdfPCell(new Phrase(Col.ColumnName.ToUpper(), fnt))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        });
                    }

                    table.AddCell(new PdfPCell(new Phrase("Total", fnt))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BackgroundColor = BaseColor.LIGHT_GRAY
                    });

                    table.HeaderRows = 1;

                    foreach (DataRow Fila in Res.Rows)
                    {
                        decimal Total = 0;

                        for (int i = 0; i < Res.Columns.Count; i++)
                        {
                            if (i == 0)
                            {
                                cell.Phrase = new Phrase(Fila[i].ToString(), fnt_Totales);
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                table.AddCell(cell);
                            }
                            else
                            {
                                decimal Val = Convert.ToDecimal(Fila[i]);
                                string Valor = string.Empty;

                                Total += Val;
                                totales[i] += Val;

                                if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                                    Valor = Val.ToString("C");
                                else
                                    Valor = string.Format("{0:n0}", Fila[i]);

                                cell.Phrase = new Phrase(Valor, fnt_Totales);
                                cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                table.AddCell(cell);
                            }
                        }

                        string Total_Fila = string.Empty;
                        totales[totales.Length - 1] += Total;

                        if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                            Total_Fila = Total.ToString("C");
                        else
                            Total_Fila = string.Format("{0:n0}", Total);

                        cell.Phrase = new Phrase(Total_Fila, fnt_Totales);
                        cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                        table.AddCell(cell);
                    }

                    for (int i = 0; i < totales.Length; i++)
                    {
                        if (i == 0)
                        {
                            cell.Phrase = new Phrase("Totales", fnt);
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(cell);
                        }
                        else
                        {
                            string Total_Columna = string.Empty;

                            if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                                Total_Columna = totales[i].ToString("C");
                            else
                                Total_Columna = string.Format("{0:n0}", totales[i]);

                            cell.Phrase = new Phrase(Total_Columna, fnt_Totales);
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }

                MessageBox.Show("Archivo Guardado Correctamente", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        

            }// fin try
            catch (Exception Ex)
            {
                throw new Exception("Error: (Exportar_Pdf_Producto). Descripción: " + Ex.Message);
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
        private void Exportar_Pdf_Producto(DataTable Dt_Consulta, DataTable Dt_Datos_Generales, SaveFileDialog Sfd_Ruta_Archivo)
        {
            try
            {
                using (FileStream Archivo_PDF = new FileStream(Sfd_Ruta_Archivo.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    iTextSharp.text.Rectangle Rec_Rectangulo = new iTextSharp.text.Rectangle(PageSize.LETTER);
                    Document Doc_Documento_Pdf = new Document(Rec_Rectangulo);
                    Doc_Documento_Pdf.SetMargins(Doc_Documento_Pdf.LeftMargin, Doc_Documento_Pdf.RightMargin, Doc_Documento_Pdf.TopMargin + 50, Doc_Documento_Pdf.BottomMargin);
                    PdfWriter PDF_Escritura = PdfWriter.GetInstance(Doc_Documento_Pdf, Archivo_PDF);

                    // Se agrega el Encabezado y Pie de Página.
                    PageEventHandler evt = new PageEventHandler()
                    {
                        Fecha_Inicio = Dtp_Periodo_Inicial.Value,
                        Fecha_Fin = Dtp_Periodo_Final.Value,
                        Parametros = Dt_Datos_Generales.Rows[0][3].ToString(),
                        Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario,
                        Posicion_Encabezado = 787
                    };

                    PDF_Escritura.PageEvent = evt;

                    Doc_Documento_Pdf.Open();
                    Doc_Documento_Pdf.NewPage();

                    PdfPTable Pdf_PTable_Tabla = new PdfPTable(Dt_Consulta.Columns.Count);
                    PdfPCell Pdf_Cel_Celda = new PdfPCell();

                    iTextSharp.text.Font Fnt_Detalle = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLDITALIC));

                    iTextSharp.text.Font Fnt_Totales = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 9,
                        iTextSharp.text.Font.BOLD));

                    float[] Flt_Longitud = new float[Dt_Consulta.Columns.Count];
                    decimal[] Dec_Totales = new decimal[Dt_Consulta.Columns.Count];

                    float Flt_Val = 430 / Dt_Consulta.Columns.Count;

                    //  se asigna la longitud de las columnas
                    for (int Cont_For = 0; Cont_For < Dt_Consulta.Columns.Count; Cont_For++)
                    {
                        Flt_Longitud[Cont_For] = Flt_Val;

                    }// fin for cont_For

                    Pdf_PTable_Tabla.SetWidths(Flt_Longitud);
                    Pdf_PTable_Tabla.WidthPercentage = 100;

                    //  el nombre de las columnas se pasan a MAYUSCULAS
                    foreach (DataColumn Col_Registro in Dt_Consulta.Columns)
                    {
                        Pdf_PTable_Tabla.AddCell(new PdfPCell(new Phrase(Col_Registro.ColumnName.ToUpper(), Fnt_Detalle))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        });
                    }

                    Pdf_PTable_Tabla.HeaderRows = 1;

                    //  se ingresan los registros
                    foreach (DataRow Fila_Registro in Dt_Consulta.Rows)
                    {
                        String Str_Fecha = "";
                        DateTime DTi_Fecha = new DateTime();
                        decimal Dec_Total = 0;

                        for (int Cont_For = 0; Cont_For < Dt_Consulta.Columns.Count; Cont_For++)
                        {
                            if (Cont_For == 0)
                            {
                                DTi_Fecha = Convert.ToDateTime(Fila_Registro[Cont_For].ToString());
                                Str_Fecha = string.Format("{0:dd/MM/yyyy}", DTi_Fecha);
                                Pdf_Cel_Celda.Phrase = new Phrase(Str_Fecha, Fnt_Totales);
                                Pdf_Cel_Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                                Pdf_PTable_Tabla.AddCell(Pdf_Cel_Celda);
                            }
                            else if (Cont_For == 1)
                            {
                                decimal Dec_Val = Convert.ToDecimal(Fila_Registro[Cont_For]);
                                Dec_Total += Dec_Val;
                                Dec_Totales[Cont_For] += Dec_Val;

                                Pdf_Cel_Celda.Phrase = new Phrase(Dec_Val.ToString("C0").Replace("$", ""), Fnt_Totales);
                                Pdf_Cel_Celda.HorizontalAlignment = Element.ALIGN_RIGHT;

                                Pdf_PTable_Tabla.AddCell(Pdf_Cel_Celda);
                            }
                            else
                            {
                                decimal Dec_Val = Convert.ToDecimal(Fila_Registro[Cont_For]);
                                Dec_Total += Dec_Val;
                                Dec_Totales[Cont_For] += Dec_Val;

                                Pdf_Cel_Celda.Phrase = new Phrase(Dec_Val.ToString("C").Replace("$", ""), Fnt_Totales);
                                Pdf_Cel_Celda.HorizontalAlignment = Element.ALIGN_RIGHT;

                                Pdf_PTable_Tabla.AddCell(Pdf_Cel_Celda);
                            }
                        }// fin del for Cont_For

                    }// fin del foreach Fila

                    for (int Cont_For = 0; Cont_For < Dec_Totales.Length; Cont_For++)
                    {
                        if (Cont_For == 0)
                        {
                            Pdf_Cel_Celda.Phrase = new Phrase("Totales", Fnt_Detalle);
                            Pdf_Cel_Celda.HorizontalAlignment = Element.ALIGN_CENTER;
                            Pdf_PTable_Tabla.AddCell(Pdf_Cel_Celda);
                        }
                        else if (Cont_For == 1)
                        {
                            Pdf_Cel_Celda.Phrase = new Phrase(Dec_Totales[Cont_For].ToString("C0").Replace("$", ""), Fnt_Totales);
                            Pdf_Cel_Celda.HorizontalAlignment = Element.ALIGN_RIGHT;

                            Pdf_PTable_Tabla.AddCell(Pdf_Cel_Celda);
                        }
                        else
                        {
                            Pdf_Cel_Celda.Phrase = new Phrase(Dec_Totales[Cont_For].ToString("C").Replace("$", ""), Fnt_Totales);
                            Pdf_Cel_Celda.HorizontalAlignment = Element.ALIGN_RIGHT;

                            Pdf_PTable_Tabla.AddCell(Pdf_Cel_Celda);
                        }

                    }// fin for cont_For

                    Doc_Documento_Pdf.Add(Pdf_PTable_Tabla);
                    Doc_Documento_Pdf.Close();

                }// fin using

            }// fin try
            catch (Exception Ex)
            {
                throw new Exception("Error: (Exportar_Pdf_Producto). Descripción: " + Ex.Message);
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
        private void Exportar_Excel_Producto()
        {
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Datos_Generales = new DataTable();
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_Accesos_Ingresos = new DataTable();
            String Str_Columna_Tope = ""; //    contendra la letra que se utilizara como tope en el archivo de excel
            try
            {
                // *******************************************************************************************************************************
                //  se obtiene el diccionario referente a las columnas en excel
                Dictionary<Int32, string> Dic_Equivalencias_Excel = Obtener_Columnas_Excel();

                // *******************************************************************************************************************************
                Dt_Consulta = Consulta_Tarifa(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value, 0);
                Grd_Resultado.DataSource = Dt_Consulta;

                // *******************************************************************************************************************************
                //  se agrega el total x renglon
                Dt_Consulta.Columns[0].ColumnName = "Fecha_";
                Dt_Consulta.Columns.Add("Fecha", typeof(DateTime));

                Double Db_Total = 0;
                Int32 Cont_Columnas = 0;

                Cont_Columnas = Dt_Consulta.Columns.Count;

                foreach (DataRow Dr_Registro in Dt_Consulta.Rows)
                {
                    Db_Total = 0;
                    Dr_Registro.BeginEdit();

                    //  se coloca la fecha
                    Dr_Registro["Fecha"] = Convert.ToDateTime(Dr_Registro["Fecha_"].ToString());

                    Dr_Registro.EndEdit();
                }

                Dt_Consulta.Columns.RemoveAt(0);//   se remueve la columna de la fecha original
                Dt_Consulta.AcceptChanges();
                Dt_Consulta.Columns["Fecha"].SetOrdinal(0);
                Dt_Consulta.AcceptChanges();
                Cont_Columnas = Dt_Consulta.Columns.Count;

                // *******************************************************************************************************************************
                //  se obtiene el tope del archivo de excel
                if (Dic_Equivalencias_Excel.ContainsKey(Cont_Columnas - 1) == true)
                {
                    Str_Columna_Tope = Dic_Equivalencias_Excel[Cont_Columnas - 1];
                }
                else
                {
                    Str_Columna_Tope = "Z";
                }

                // *******************************************************************************************************************************
                //  datos generales del reporte
                Dt_Datos_Generales = Crear_Tabla_Datos_Generales(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);

                // *******************************************************************************************************************************
                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // *******************************************************************************************************************************

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName))
                    {
                        File.Delete(Sfd_Ruta_Archivo.FileName);
                    }

                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Tipo de pago");
                        // *******************************************************************************************************************************
                        Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las momias";
                        Detallado.Cells["A4"].Value = Dt_Datos_Generales.Rows[0][2].ToString();
                        Detallado.Cells["A5"].Value = Dt_Datos_Generales.Rows[0][3].ToString();

                        Detallado.Cells["A7"].Value = "Diario de recaudación y visitantes";

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


                        // *******************************************************************************************************************************
                        Int32 Filas = 8;
                        Detallado.Cells["A" + Filas].Value = "Tarifa " + Cmb_Anio.Text + " " + Cmb_Tarifa.Text;
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.Font.Bold = true;
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Merge = true;
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Filas++;

                        // *******************************************************************************************************************************
                        //  se carga el archivo
                        ExcelRangeBase Rango = Detallado.Cells["A" + Filas].LoadFromDataTable(Dt_Consulta, true, OfficeOpenXml.Table.TableStyles.Medium2);

                        // *******************************************************************************************************************************
                        //  formato a las celdas 
                        Detallado.Cells[Filas, 2, Rango.End.Row, 2].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[Filas, 3, Rango.End.Row, 3].Style.Numberformat.Format = "#,##0.00";
                        //  formato de fecha
                        Detallado.Cells[Filas, 1, Rango.End.Row, 1].Style.Numberformat.Format = "mm-dd-yy";

                        Filas = Filas + Dt_Consulta.Rows.Count + 1;

                        // *******************************************************************************************************************************
                        //  subtotal
                        Detallado.Cells[(Filas), 2, (Filas), 2].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[(Filas), 3, (Filas), 3].Style.Numberformat.Format = "#,##0.00";
                        Detallado.Cells["A" + Filas + ":" + Str_Columna_Tope + Filas].Style.Font.Bold = true;

                        for (Int32 Cont_For = 1; Cont_For < Cont_Columnas; Cont_For++)
                        {
                            if (Dic_Equivalencias_Excel.ContainsKey(Cont_For) == true)
                            {
                                Detallado.Cells[Dic_Equivalencias_Excel[Cont_For] + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[" + Dt_Consulta.Columns[Cont_For].ColumnName + "] )");
                            }
                        }

                        Filas = Filas + 2;

                        // *******************************************************************************************************************************
                        //  pie de pagina
                        Detallado.Cells["A" + Filas.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Detallado.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();

                        // *******************************************************************************************************************************
                        Rango.AutoFitColumns();
                        Epc_Accesos.Save();
                    }
                    MessageBox.Show(this, "Exportacion exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Exportar_Excel_Producto). Descripción: " + Ex.Message);
            }
        }



        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: StringBuilder Obtener_Formas_Pago
        ///DESCRIPCIÓN: Consulta el catálogo de formas de pago y regresa un diccionario con las formas de pago 
        ///             con el ID como llave y el nombre como valor
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 30-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private Dictionary<Int32, string> Obtener_Columnas_Excel()
        {
            var Diccionario = new Dictionary<Int32, string>();
            //  PRIMIER GRUPO
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
            Diccionario.Add(14, "O");
            Diccionario.Add(15, "P");
            Diccionario.Add(16, "Q");
            Diccionario.Add(17, "R");
            Diccionario.Add(18, "S");
            Diccionario.Add(19, "T");
            Diccionario.Add(20, "U");
            Diccionario.Add(21, "V");
            Diccionario.Add(22, "W");
            Diccionario.Add(23, "X");
            Diccionario.Add(24, "Y");
            Diccionario.Add(25, "Z");

            //  SEGUNGO GRUPO
            Diccionario.Add(26, "AA");
            Diccionario.Add(27, "AB");
            Diccionario.Add(28, "AC");
            Diccionario.Add(29, "AD");
            Diccionario.Add(30, "AE");
            Diccionario.Add(31, "AF");
            Diccionario.Add(32, "AG");
            Diccionario.Add(33, "AH");
            Diccionario.Add(34, "AI");
            Diccionario.Add(35, "AJ");
            Diccionario.Add(36, "AK");
            Diccionario.Add(37, "AL");
            Diccionario.Add(38, "AM");
            Diccionario.Add(39, "AN");
            Diccionario.Add(40, "AO");
            Diccionario.Add(41, "AP");
            Diccionario.Add(42, "AQ");
            Diccionario.Add(43, "AR");
            Diccionario.Add(44, "AS");
            Diccionario.Add(45, "AT");
            Diccionario.Add(46, "AU");
            Diccionario.Add(47, "AV");
            Diccionario.Add(48, "AW");
            Diccionario.Add(49, "AX");
            Diccionario.Add(50, "AY");
            Diccionario.Add(51, "AZ");

            return Diccionario;
        }


        /// <summary>
        /// Método que carga los lugares donde se pueden registrar las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private DataTable Crear_Tabla_Datos_Generales(DateTime Periodo_Inicio, DateTime Periodo_Final)
        {
            Cls_Rep_Ingresos_Negocio Neg_Ingresos = new Cls_Rep_Ingresos_Negocio();
            DataTable Dt_Datos_Generales = new DataTable();
            String Leyenda_Encabezado = "";
            String Leyenda_Periodo = "";
            Boolean Estatus = false;

            try
            {

                // asignar fechas si tienen un valor asignado
                if (Periodo_Inicio != DateTime.MinValue)
                {
                    Neg_Ingresos.P_Fecha_Inicio = Periodo_Inicio;

                    Leyenda_Periodo += "Periodo: Del " + Periodo_Inicio.ToString("dd")
                                    + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Periodo_Inicio.ToString("MM")))
                                    + " de " + Periodo_Inicio.ToString("yyyy");

                }

                if (Periodo_Final != DateTime.MaxValue)
                {
                    Neg_Ingresos.P_Fecha_Final = Periodo_Final;
                    Leyenda_Periodo += " al " + Periodo_Final.ToString("dd")
                                   + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Periodo_Final.ToString("MM")))
                                   + " de " + Periodo_Final.ToString("yyyy");
                }

                // si hay un elemento seleccionado en el combo tarifa, asignar la tarifa
                if (Cmb_Tarifa.SelectedIndex > 0)
                {
                    if (!Anio_Anterior)
                    {
                        Neg_Ingresos.P_Tarifa_Id = Cmb_Tarifa.SelectedValue.ToString();

                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Producto: " + Cmb_Tarifa.Text.ToString() + ", Año: " + Cmb_Anio.Text.ToString();

                        Estatus = true;
                    }
                }

                //  caja
                if (Cmb_No_Caja.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_No_Caja = Cmb_No_Caja.SelectedValue.ToString();

                    if (Estatus)
                        Leyenda_Encabezado += ", ";

                    Leyenda_Encabezado += "Caja: " + Cmb_No_Caja.Text.ToString();

                    Estatus = true;
                }

                //  turno
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Neg_Ingresos.P_Turno = Cmb_Turno.SelectedValue.ToString();

                    if (Estatus)
                        Leyenda_Encabezado += ", ";

                    Leyenda_Encabezado += "Turno: " + Cmb_Turno.Text.ToString();

                    Estatus = true;
                }

                //  tipo de pago
                if (Cmb_Tipo_Pago.SelectedIndex > 0)
                {

                }

                //  lugar de la venta
                if (Cmb_Lugar_Venta.SelectedIndex > 0)
                {
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                    {
                        Neg_Ingresos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Lugar de la venta: " + Cmb_Lugar_Venta.Text.ToString();

                        Estatus = true;
                    }
                }


                //  se asignan las columnas a la tabla
                Dt_Datos_Generales.TableName = "Datos_Generales";

                Dt_Datos_Generales.Columns.Add("Usuario_Creo", typeof(string));
                Dt_Datos_Generales.Columns.Add("Fecha_Creo", typeof(string));
                Dt_Datos_Generales.Columns.Add("Periodo_Reporte", typeof(string));
                Dt_Datos_Generales.Columns.Add("Filtros", typeof(string));

                var Registro = Dt_Datos_Generales.NewRow();
                Registro["Usuario_Creo"] = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Registro["Periodo_Reporte"] = Leyenda_Periodo;
                Registro["Filtros"] = Leyenda_Encabezado;
                Dt_Datos_Generales.Rows.Add(Registro);

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Crear_Tabla_Datos_Generales). Descripción: " + Ex.Message);
            }

            return Dt_Datos_Generales;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón exportar PDF: llamar al método que muestra el reporte
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet Ds_Reporte = new DataSet();
                DataRow Dr_Fila_Nueva;
                DataTable Dt_Reporte = new DataTable();
                MySqlDateTime Fecha_Mysql = new MySqlDateTime();
                string Nombre_Plantilla = "";
                DataTable Dt_Consulta = new DataTable();
                DataTable Dt_Auxiliar = new DataTable();
                DataTable Dt_Datos_Generales = new DataTable();

                // si es mayor el año inicial que el final, mostrar mensaje
                if (Dtp_Periodo_Inicial.Value.Date > Dtp_Periodo_Final.Value.Date)
                {
                    MessageBox.Show(this, "La fecha del periodo inicial no puede ser mayor al periodo final, por favor seleccione un rango válido.", "Seleccionar rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // consultar detalles de ingresos o accesos
                if (Cmb_Tarifa.SelectedIndex > 0)// tarifa
                {
                    //  informacion del reporte
                    // *******************************************************************************************************************************
                    Dt_Consulta = Consulta_Tarifa(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value, 1);
                   
                    // *******************************************************************************************************************************
                    //  datos generales del reporte
                    Dt_Datos_Generales = Crear_Tabla_Datos_Generales(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);

                    //  se carga el dataset
                    Dt_Consulta.TableName = "Dt_Tarifa";
                    Ds_Reporte.Tables.Add(Dt_Consulta);
                    Ds_Reporte.Tables.Add(Dt_Datos_Generales);

                    //  se ejectua el reporte
                    Nombre_Plantilla = "Cr_Rpt_Diario_Recaudacion_Visitantes_Tarifa.rpt";
                    Generar_Reporte_Sin_Parametros(ref Ds_Reporte, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + Nombre_Plantilla);

                } 
                else if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))//**************************************************************************************************
                {
                    DataTable Ingresos = Informacion_Ingresos(1);
                    Ds_Reporte.Tables.Add(Ingresos);

                    Nombre_Plantilla = "Cr_Rpt_Diario_Recuadacion_Ingresos.rpt";
                    // método que muestra el reporte
                    Generar_Reporte(Ds_Reporte, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + Nombre_Plantilla);
                }
                else if (Cmb_Tipo_Reporte.Text.Equals("Visitantes"))//*************************************************************************************************
                {
                    DataTable Ingresos = Consulta_Accesos_Sin_Formato(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);
                    
                    Ingresos.Columns[0].ColumnName = "Fecha";
                    Ingresos.Columns[2].ColumnName = "Producto";
                    Ingresos.Columns[1].ColumnName = "Total";

                    Ingresos.Columns.RemoveAt(3);
                    Ingresos.TableName = "Ingresos";
                    Ds_Reporte.Tables.Add(Ingresos);

                    Nombre_Plantilla = "Cr_Rpt_Diario_Recuadacion_Ingresos.rpt";
                    // método que muestra el reporte
                    Generar_Reporte(Ds_Reporte, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + Nombre_Plantilla);
                }
                else if (Cmb_Tipo_Reporte.Text.Equals("Comparativo"))
                {
                    DataTable Res = Comparativo();

                    Ds_Reporte.Tables.Add(Res);
                    Nombre_Plantilla = "Cr_Rpt_Diario_Recaudacion_Ingresos_Comparativo.rpt";
                    
                    // método que muestra el reporte
                    Generar_Reporte(Ds_Reporte, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + Nombre_Plantilla);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Exportar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Anio_Anterior = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Exportar_PDF_iTextSharp_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
                Sfd_Ruta_Archivo.Filter = "PDF(*.pdf)|*.pdf";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // Generación del Archivo de Excel.
                // Validación a la Ruta del Archivo.
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (Cmb_Tarifa.SelectedIndex > 0)// tarifa ********************************************************************************
                    {
                        #region Tarifa

                        DataTable Dt_Consulta = new DataTable();
                        DataTable Dt_Datos_Generales = new DataTable();
                        //  informacion del reporte
                        // *******************************************************************************************************************************
                        Dt_Consulta = Consulta_Tarifa(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value, 1);

                        // *******************************************************************************************************************************
                        //  datos generales del reporte
                        Dt_Datos_Generales = Crear_Tabla_Datos_Generales(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);
                        
                        // *******************************************************************************************************************************
                        //  exportacion a pdf
                        Exportar_Pdf_Producto(Dt_Consulta, Dt_Datos_Generales, Sfd_Ruta_Archivo);

                        MessageBox.Show("Archivo Guardado Correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        #endregion Tarifa
                    }
                    else if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))//  Ingresos ********************************************************
                    {
                        #region Ingresos

                        DataTable Res = Informacion_Ingresos(0);
                        Exportar_Pdf_Ingresos_Accesos(Sfd_Ruta_Archivo, Res);

                        #endregion Ingresos

                    }// fin if ingresos
                    else if(Cmb_Tipo_Reporte.Text.Equals("Comparativo"))
                    {
                        DataTable Res = Informacion_Ingresos(0);
                        Exportar_Pdf_Ingresos_Accesos(Sfd_Ruta_Archivo, Res);
                    }
                    else//  accesos
                    {
                        #region Visitantes
                        DataTable Dt_Visitantes = Consulta_Accesos(Dtp_Periodo_Inicial.Value, Dtp_Periodo_Final.Value);
                        Exportar_Pdf_Ingresos_Accesos(Sfd_Ruta_Archivo, Dt_Visitantes);
                        #endregion
                    }

                }// fin Sfd_Ruta_Archivo
            
            }// fin try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se Filtran las tarifas en base al año seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Anio.SelectedIndex > 0)
                {
                    DataTable Dt_Prod = (from Dt_P in Dt_Productos.AsEnumerable()
                                         where Dt_P.Field<int>("Anio") == int.Parse(Cmb_Anio.Text)
                                         select Dt_P).CopyToDataTable();

                    DataRow Seleccione = Dt_Prod.NewRow();
                    Seleccione["Nombre"] = "SELECCIONE";

                    Dt_Prod.Rows.InsertAt(Seleccione, 0);

                    Cmb_Tarifa.DataSource = Dt_Prod;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se Filtran las tarifas en base al año seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Tipo_ReporteSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (Cmb_Tipo_Reporte.Text.Equals("Ingresos"))
                //{
                    Btn_Exportar_PDF_iTextSharp.Enabled = true;
                //}
                //else
                //{
                //    Btn_Exportar_PDF_iTextSharp.Enabled = false;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion EVENTOS
    }
}
