using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Catalogos.Turnos.Negocio;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Reportes.Ventas.Negocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP_BASE.Paginas.Catalogos.Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using ComponentFactory.Krypton.Toolkit;
using Erp.Metodos_Generales;
using OfficeOpenXml;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Concentrado_Ventas : Form
    {
        DataTable Dt_Productos;

        #region (Init/Load)
        public Frm_Rpt_Concentrado_Ventas()
        {
            InitializeComponent();
            Configuracion_Inicial();
        }
        #endregion

        #region (Métodos)
        /// <summary>
        /// Método que habilita los controles según el valor del parámetro.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 16:42 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Habilitar_Controles(bool Habilitado) {
            KCmb_Caja.Enabled = Habilitado;
        }
        /// <summary>
        /// Método que habilita la configuración inical de la pagina.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:19 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Configuracion_Inicial()
        {
            try
            {
                Cargar_Productos();
                Cargar_Cajas();
                Cargar_Turnos();
                Cargar_Lugar_Venta();
                Cargar_Anios();
                Habilitar_Controles(false);

                Cmb_Museo.SelectedIndex = 0;
                Cmb_Anio.SelectedIndex = 0;
                KCmb_Tarifa_Productos.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: Metodo(Configuracion_Inicial). Descripción:" + Ex.Message);
            }
        }
        /// <summary>
        /// Método que realiza la carga de productos registrados por catálogo.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:16 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Productos()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Resultados_Busqueda = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Consultar_Productos();//Ejecutamos la consulta de productos.
                //KCmb_Tarifa_Productos.DataSource = Dt_Resultados_Busqueda;//Cargamos el listado de productos.

                Dt_Resultados_Busqueda.Rows.RemoveAt(0);
                Dt_Productos = Dt_Resultados_Busqueda;
                KCmb_Tarifa_Productos.ValueMember = Cat_Productos.Campo_Producto_Id;
                KCmb_Tarifa_Productos.DisplayMember = Cat_Productos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Productos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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

                        Lista.Insert(0, new { Caja_ID = string.Empty, Numero_Caja = "SELECCIONE" });
                        KCmb_Caja.DataSource = Lista;
                        KCmb_Caja.ValueMember = Cat_Cajas.Campo_Caja_ID;
                        KCmb_Caja.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
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
                    Dr[Cat_Turnos.Campo_Nombre] = "SELECCIONE";
                    Dt_Turnos.Rows.InsertAt(Dr, 0);
                }
                KCmb_Turnos.DataSource = Dt_Turnos;
                KCmb_Turnos.ValueMember = Cat_Turnos.Campo_Turno_ID;
                KCmb_Turnos.DisplayMember = Cat_Turnos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Cargar_Anios 
        /// Descripcion: Carga los Años desde 2009 al Actual.
        /// Usuario_Creo: Héctor Gabriel Galicia Luna.
        /// </summary>
        private void Cargar_Anios()
        {
            try
            {
                Cmb_Anio.Items.Add("SELECCIONE");

                for (int i = DateTime.Now.Year; i >= 2009; i--)
                {
                    Cmb_Anio.Items.Add(i.ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
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
        private void Cargar_Lugar_Venta()
        {
            try
            {
                Dictionary<string, string> Lugares_Venta = new Dictionary<string, string> { 
                            {"SELECCIONE", string.Empty},
                            {"No Caja", "No Caja"},
                            {"Internet", "Internet"},
                            {"Kiosko", "Kiosko"}
              };
                KCmb_Lugar_Venta.DataSource = new BindingSource(Lugares_Venta, null);
                KCmb_Lugar_Venta.DisplayMember = "Key";
                KCmb_Lugar_Venta.ValueMember = "Value";
                KCmb_Lugar_Venta.SelectedIndex = (0);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Cargar_Lugar_Venta). Descripción: " + Ex.Message);
            }
        }
        /// <summary>
        /// Nombre: Hacer_Lista
        /// 
        /// Descripción: Método generico que utilizaremos para crear listas con datos anonimos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:24 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemOftype"></param>
        /// <returns></returns>
        public static List<T> Hacer_Lista<T>(T itemOftype)
        {
            List<T> Lista_Nueva = new List<T>();
            return Lista_Nueva;
        }
        /// <summary>
        /// Nombre: CalcularPeriodo6Meses 
        /// Fecha_Creo: 05/Mayo/2015
        /// Descripcion: Se encaga de evaluar si el periodo de busqueda sobrepasa los 6 meses
        /// Usuario_Creo: Olimpo_Cruz
        /// </summary>
        /// <param name="FechaInicio"> Parametro de fecha de inicio a ser evaluado</param>
        /// <param name="FechaFin">Parametro de fecha final a aser evaluado</param>
        /// <returns></returns>
        private bool CalcularPeriodo6Meses(DateTime FechaInicio, DateTime FechaFin)
        {
            Boolean Periodo6meses = false;

            if (FechaInicio <= FechaFin)
            {
                int Dias = (FechaFin - FechaInicio).Days;
                //MessageBox.Show("La cantidad de días es: " + Dias.ToString());
                if (Dias > 183) // 183 dias = 6 meses.
                {
                    Periodo6meses = false;
                    if (!Periodo6meses)
                    {
                        if (MessageBox.Show("El periodo de consulta es MAYOR a 6 meses.\nRealizar esta consulta puede demorar debido a la gran cantidad de ventas efectuadas.\nAún así, ¿Desea continuar?", "Alerta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                                            == DialogResult.Yes)
                        {
                            Periodo6meses = true;
                        }
                        else Periodo6meses = false;
                    }
                }
                else
                    Periodo6meses = true;
            }
            return Periodo6meses;
        }

        #endregion

        #region (Grid)
        /// <summary>
        /// Nombre: Formato_Tabla
        /// 
        /// Descripción: Método que modifica el formato de la tabla que lista el resultado de la búsqueda.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:31 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Tabla">Control DataGridView del cuál se modificara su formato</param>
        private void Formato_Tabla(DataGridView Tabla)
        {
            try
            {
                Tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Array.ForEach(Tabla.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    columna.HeaderText = columna.HeaderText.Replace("_", " ");
                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (columna.ValueType.Name.Equals("DateTime"))
                        columna.DefaultCellStyle.Format = "dd MMM yyyy";
                    else if (columna.ValueType.Name.Equals("Decimal") && !columna.HeaderText.Equals("Total Productos")
                        && !columna.HeaderText.Equals("Total Accesos") && !columna.HeaderText.Equals("Visitantes"))
                        columna.DefaultCellStyle.Format = "c";

                    if (columna.HeaderText.Equals("Detalle"))
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        columna.Width = 300;
                    }
                });

                Array.ForEach(Tabla.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                {
                    fila.DefaultCellStyle.Font = new Font("Consolas", 8, FontStyle.Regular);

                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda => {
                        if (celda.OwningColumn.Name.Contains("Acceso")) {
                            celda.Value = Convert.ToDecimal(celda.Value).ToString();
                        }
                    });
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Formato_Tabla]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Eventos)

        #region (Botones)
        /// <summary>
        /// Evento que realiza la búsqueda de las ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            Boolean Periodo6Meses = false; 

            try
            {
                Grid_Resultado.DataSource = null;

                //Establecemos los filtros para realizar la búsqueda.
                if (KDtp_Fecha_Inicio.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                if (KDtp_Fecha_Termino.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(KDtp_Fecha_Termino.Value.Year
                        , KDtp_Fecha_Termino.Value.Month
                        , KDtp_Fecha_Termino.Value.Day, 23, 59, 59);

                if (KCmb_Tarifa_Productos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Tarifa_Productos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Producto_ID = KCmb_Tarifa_Productos.SelectedValue.ToString();

                if (KCmb_Caja.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();

                if (KCmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = KCmb_Lugar_Venta.Text;

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Lugar_Venta= KCmb_Lugar_Venta.SelectedValue.ToString();

                if (Cmb_Museo.SelectedIndex > 0)
                {
                    Obj_Rpt_Ventas.P_Museo = Cmb_Museo.Text == "MUSEO MOMIAS" ? "00001" : "00002";
                }

                Periodo6Meses = CalcularPeriodo6Meses(Obj_Rpt_Ventas.P_Fecha_Inicio, Obj_Rpt_Ventas.P_Fecha_Termino);

                if (Periodo6Meses)
                {
                    Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Concentrado_Ventas();

                    if (Ds_Resultados_Busqueda.Tables["Concentrado_Ventas_Tarifa"] is DataTable)
                        if (Ds_Resultados_Busqueda.Tables["Concentrado_Ventas_Tarifa"].Rows.Count > 0)
                        {
                            var Dt_Productos_Aux = from P in Ds_Resultados_Busqueda.Tables["Concentrado_Ventas_Tarifa"].AsEnumerable()
                                                   where P.Field<string>("Tipo") == "Producto"
                                                   select P;

                            var Dt_Servicios_Aux = from P in Ds_Resultados_Busqueda.Tables["Concentrado_Ventas_Tarifa"].AsEnumerable()
                                               where P.Field<string>("Tipo") == "Servicio"
                                               select P;

                            Int64 Total_Productos = 0;
                            Int64 Importe_Productos = 0;
                            Int64 Total_Servicios = 0;
                            Int64 Importe_Servicios = 0;

                            DataTable Dt_Productos = new DataTable();
                            DataTable Dt_Servicios = new DataTable();

                            if (Dt_Productos_Aux.Any())
                            {
                                Dt_Productos = Dt_Productos_Aux.CopyToDataTable();

                                Dt_Productos.Columns.Remove("Tipo");

                                Total_Productos = (Int64)(from P in Dt_Productos.AsEnumerable()
                                                                select P.Field<decimal>("Ventas")).Sum();
                                Importe_Productos = (Int64)(from P in Dt_Productos.AsEnumerable()
                                                                  select P.Field<decimal>("Importe_Total")).Sum();

                                DataRow Totales = Dt_Productos.NewRow();
                                Totales["Tarifa"] = "Total Accesos";
                                Totales["Ventas"] = Total_Productos;
                                Totales["Importe_Total"] = Importe_Productos;

                                Dt_Productos.Rows.InsertAt(Totales, Dt_Productos.Rows.Count);

                                DataRow Header = Dt_Productos.NewRow();
                                Header[0] = "Producto";

                                Dt_Productos.Rows.InsertAt(Header, 0);
                            }

                            if (Dt_Servicios_Aux.Any())
                            {
                                Dt_Servicios = Dt_Servicios_Aux.CopyToDataTable();

                                Dt_Servicios.Columns.Remove("Tipo");
                                Total_Servicios = (Int64)(from P in Dt_Servicios.AsEnumerable()
                                                                select P.Field<decimal>("Ventas")).Sum();
                                Importe_Servicios = (Int64)(from P in Dt_Servicios.AsEnumerable()
                                                                  select P.Field<decimal>("Importe_Total")).Sum();

                                DataRow Totales_S = Dt_Servicios.NewRow();
                                Totales_S["Tarifa"] = "Total Servicios";
                                Totales_S["Ventas"] = Total_Servicios;
                                Totales_S["Importe_Total"] = Importe_Servicios;

                                Dt_Servicios.Rows.InsertAt(Totales_S, Dt_Servicios.Rows.Count);

                                DataRow HeaderS = Dt_Servicios.NewRow();
                                HeaderS[0] = "Servicio";

                                Dt_Servicios.Rows.InsertAt(HeaderS, 0);   
                            }

                            if(Dt_Productos_Aux.Any() && Dt_Servicios_Aux.Any())
                            {
                                Dt_Productos.Merge(Dt_Servicios);

                                DataRow Totales_General = Dt_Productos.NewRow();
                                Totales_General["Tarifa"] = "Totales";
                                Totales_General["Ventas"] = Total_Productos + Total_Servicios;
                                Totales_General["Importe_Total"] = Importe_Productos + Importe_Servicios;

                                Dt_Productos.Rows.Add(Totales_General);
                            }

                            if (Dt_Productos.Rows.Count > 0)
                            {
                                Grid_Resultado.DataSource = Dt_Productos;
                            }
                            else
                            {
                                Grid_Resultado.DataSource = Dt_Servicios;
                            }
                        }
                        else Grid_Resultado.DataSource = new DataTable();
                    else Grid_Resultado.DataSource = new DataTable();

                    if (Ds_Resultados_Busqueda.Tables[1].Rows.Count > 0)
                    {
                        DataTable Dt_Folios = Ds_Resultados_Busqueda.Tables[1];
                        DataRow Totales = Dt_Folios.NewRow();

                        Totales["Total_Folios"] = (from T in Dt_Folios.AsEnumerable()
                                                   select T.Field<Int64>("Total_Folios")).Sum();

                        Totales["Total"] = (from T in Dt_Folios.AsEnumerable()
                                            select T.Field<Int64>("Total")).Sum();

                        Dt_Folios.Rows.Add(Totales);

                        Grid_Totales.DataSource = Dt_Folios;
                    }
                    else
                    {
                        Grid_Totales.DataSource = new DataTable();
                    }

                    Array.ForEach(Grid_Totales.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                    {
                        switch (columna.HeaderText)
                        {
                            case "Producto":
                                columna.HeaderText = "Tarifas";
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                break;
                            case "Total Productos":
                                columna.HeaderText = "Visitantes";
                                break;
                            case "Importe Total":
                                columna.HeaderText = "Total por tarifa";
                                break;
                            default:
                                break;
                        }
                    });
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que genera el reporte de concentrado de las ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.

            try
            {
                //Establecemos los filtros para realizar la búsqueda.
                if (KDtp_Fecha_Inicio.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                if (KDtp_Fecha_Termino.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(KDtp_Fecha_Termino.Value.Year
                        , KDtp_Fecha_Termino.Value.Month
                        , KDtp_Fecha_Termino.Value.Day, 23, 59, 59);

                if (KCmb_Tarifa_Productos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Tarifa_Productos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Producto_ID = KCmb_Tarifa_Productos.SelectedValue.ToString();

                if (KCmb_Caja.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();

                if (KCmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = KCmb_Lugar_Venta.Text;

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Lugar_Venta = KCmb_Lugar_Venta.SelectedValue.ToString();

                if (Cmb_Museo.SelectedIndex > 0)
                {
                    Obj_Rpt_Ventas.P_Museo = Cmb_Museo.Text == "MUSEO MOMIAS" ? "00001" : "00002";
                }

                Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Concentrado_Ventas();
                
                Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Concentrado_Ventas_Propuesta.rpt");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que genera el reporte de concentrado de las ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            String Leyenda_Encabezado = "";

            DataTable Dt_Productos = new DataTable();
            DataTable Dt_Servicios = new DataTable();
            DataTable Dt_Concentrado_Folios = new DataTable();

            Int32 Cont_Posicion = 7;
            Int32 Cantidad_Registros = 0;
            Int32 Posicion_Productos = 0;
            Int32 Posicion_Servicios = 0;
            Boolean Si_Consulta_Producto = false;

            try
            {

                if (KDtp_Fecha_Inicio.Checked != true || KDtp_Fecha_Termino.Checked != true)
                {
                    MessageBox.Show("Seleccione las fechas a consultar", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //Establecemos los filtros para realizar la búsqueda.
                //  fecha inicio
                if (KDtp_Fecha_Inicio.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);



                    Leyenda_Encabezado += "Periodo: Del " + Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("dd")
                                        + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("MM")))
                                        + " de " + Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("yyyy");
                }

                //  fecha termino
                if (KDtp_Fecha_Termino.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(KDtp_Fecha_Termino.Value.Year
                        , KDtp_Fecha_Termino.Value.Month
                        , KDtp_Fecha_Termino.Value.Day, 23, 59, 59);

                    Leyenda_Encabezado += " al " + Obj_Rpt_Ventas.P_Fecha_Termino.ToString("dd")
                                       + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Ventas.P_Fecha_Termino.ToString("MM")))
                                       + " de " + Obj_Rpt_Ventas.P_Fecha_Termino.ToString("yyyy");
                }


                //  tarifa
                if (KCmb_Tarifa_Productos.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Tarifa_Productos.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Producto_ID = KCmb_Tarifa_Productos.SelectedValue.ToString();

                        Leyenda_Encabezado += ", Tarifa: " + KCmb_Tarifa_Productos.Text;
                        Si_Consulta_Producto = true;
                    }
                }

                //  caja
                if (KCmb_Caja.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();

                        Leyenda_Encabezado += ", Numero de caja: " + KCmb_Caja.Text;
                    }
                }

                //  turno
                if (KCmb_Turnos.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();

                        Leyenda_Encabezado += ", Turno: " + KCmb_Turnos.Text;
                    }
                }

                //  lugar de la venta
                if (KCmb_Lugar_Venta.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = KCmb_Lugar_Venta.Text;

                    }
                }

                //   Lugar de la venta
                if (KCmb_Lugar_Venta.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Lugar_Venta = KCmb_Lugar_Venta.SelectedValue.ToString();

                        Leyenda_Encabezado += ", Lugar de la venta: ";

                        if (KCmb_Lugar_Venta.Text.ToString() == "No Caja")
                        {
                            Leyenda_Encabezado += " Numero de caja";
                        }
                        else
                        {
                            Leyenda_Encabezado += "" + KCmb_Lugar_Venta.Text.ToString();
                        }
                    }
                }

                //  museo
                if (Cmb_Museo.SelectedIndex > 0)
                {
                    Obj_Rpt_Ventas.P_Museo = Cmb_Museo.Text == "MUSEO MOMIAS" ? "00001" : "00002";
                    Leyenda_Encabezado += ", Museo: " + Cmb_Museo.Text;

                }


                Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Concentrado_Ventas();

                if (sender.Equals(Btn_Exportar_Excel))
                {
                    if (Ds_Resultados_Busqueda.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se ha encontrado información con los Filtros seleccionados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    SaveFileDialog sf = new SaveFileDialog();
                    sf.Filter = "Archivos de Excel (*.xlsx) | *xlsx";
                    sf.DefaultExt = "xlsx";

                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(sf.FileName)) File.Delete(sf.FileName);
                        FileInfo newFile = new FileInfo(sf.FileName);

                        //  se da formato a los nombres de las columnas
                        foreach (DataColumn Dc_Columna in Ds_Resultados_Busqueda.Tables[0].Columns)
                        {
                            Dc_Columna.ColumnName = Dc_Columna.ColumnName.Replace('_', ' ');
                        }

                        foreach (DataColumn Dc_Columna in Ds_Resultados_Busqueda.Tables[1].Columns)
                        {
                            Dc_Columna.ColumnName = Dc_Columna.ColumnName.Replace('_', ' ');
                        }

                        //  se obtienen los prodcutos
                        Ds_Resultados_Busqueda.Tables[0].DefaultView.RowFilter = "Tipo = 'Producto'";
                        Dt_Productos = Ds_Resultados_Busqueda.Tables[0].DefaultView.ToTable();
                        Dt_Productos.TableName = "Productos";

                        //  se obtienen los prodcutos
                        Ds_Resultados_Busqueda.Tables[0].DefaultView.RowFilter = "Tipo = 'Servicio'";
                        Dt_Servicios = Ds_Resultados_Busqueda.Tables[0].DefaultView.ToTable();
                        Dt_Servicios.TableName = "Servicios";

                        //  se obtiene el concentrado de Folios
                        Dt_Concentrado_Folios = Ds_Resultados_Busqueda.Tables[1];

                        //  se ordena las columnas
                        Dt_Concentrado_Folios.Columns["No Caja"].SetOrdinal(0);
                        Dt_Concentrado_Folios.Columns["Folio Inicial"].SetOrdinal(1);
                        Dt_Concentrado_Folios.Columns["Folio Final"].SetOrdinal(2);
                        Dt_Concentrado_Folios.Columns["Total Folios"].SetOrdinal(3);
                        Dt_Concentrado_Folios.Columns["Inicial"].SetOrdinal(4);
                        Dt_Concentrado_Folios.Columns["Final"].SetOrdinal(5);
                        Dt_Concentrado_Folios.Columns["Total"].SetOrdinal(6);
                        

                        //  se quitaran la columna del tipo de producto
                        Dt_Productos.Columns.RemoveAt(2);
                        Dt_Servicios.Columns.RemoveAt(2);

                        using (ExcelPackage pck = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet Concentrado = pck.Workbook.Worksheets.Add("Concentrado de Ventas");

                            #region Encabezados
                            Concentrado.Cells["A1"].Value = "Tesoreria Municipal";
                            Concentrado.Cells["A2"].Value = "Dirección de ingresos";
                            Concentrado.Cells["A3"].Value = "Museo de las momias";
                            Concentrado.Cells["A4"].Value = Leyenda_Encabezado;
                            Concentrado.Cells["A6"].Value = "Concentrado de ventas";


                            Concentrado.Cells["A1:A1"].Style.Font.Bold = true;
                            Concentrado.Cells["A3:A6"].Style.Font.Bold = true;


                            // Encabezados del reporte
                            Concentrado.Cells["A1:G1"].Merge = true;
                            Concentrado.Cells["A2:G2"].Merge = true;
                            Concentrado.Cells["A3:G3"].Merge = true;
                            Concentrado.Cells["A4:G4"].Merge = true;
                            Concentrado.Cells["A6:G6"].Merge = true;

                            Concentrado.Cells["A1:G1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Concentrado.Cells["A2:G2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Concentrado.Cells["A3:G3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Concentrado.Cells["A4:G4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Concentrado.Cells["A6:G6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            Concentrado.Cells["A1:G1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Concentrado.Cells["A2:G2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Concentrado.Cells["A3:G3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Concentrado.Cells["A4:G4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Concentrado.Cells["A6:G6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                            #endregion


                            // *******************************************************************************************
                            //  tabla de productos 1 tabla
                            if (Dt_Productos.Rows.Count > 0)
                            {
                                Concentrado.Cells["A" + Cont_Posicion.ToString()].Value = "Productos";
                                Concentrado.Cells["A" + Cont_Posicion + ":A" + Cont_Posicion].Style.Font.Bold = true;
                                Cont_Posicion++;

                                ExcelRangeBase Rango = Concentrado.Cells["A" + Cont_Posicion].LoadFromDataTable(Dt_Productos, true, OfficeOpenXml.Table.TableStyles.Medium2);
                                Rango.AutoFitColumns();

                                //  formato a la tabla de productos
                                Concentrado.Cells[Cont_Posicion, 2, Rango.End.Row, 2].Style.Numberformat.Format = "#,##0.00";
                                Concentrado.Cells[Cont_Posicion, 3, Rango.End.Row, 3].Style.Numberformat.Format = "#,##0";
                                Concentrado.Cells[Cont_Posicion, 4, Rango.End.Row, 4].Style.Numberformat.Format = "#,##0.00";
                                

                                //  Totales
                                Cont_Posicion = Cont_Posicion + Dt_Productos.Rows.Count + 1;// posicion de los totales de la primera tabla
                                Concentrado.Cells["A" + Cont_Posicion.ToString()].Value = "Total Accesos";
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Merge = true;
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                                //  formula para los totales
                                Concentrado.Cells["C" + (Cont_Posicion)].Formula = string.Format("SUBTOTAL(109, " + Dt_Productos.TableName + "[Ventas] )");
                                Concentrado.Cells["D" + (Cont_Posicion)].Formula = string.Format("SUBTOTAL(109, " + Dt_Productos.TableName + "[Importe Total] )");
                                Concentrado.Cells[(Cont_Posicion), 4, (Cont_Posicion), 4].Style.Numberformat.Format = "#,##0.00";
                                Concentrado.Cells[(Cont_Posicion), 3, (Cont_Posicion), 3].Style.Numberformat.Format = "#,##0";

                                Concentrado.Cells["A" + Cont_Posicion + ":D" + Cont_Posicion].Style.Font.Bold = true;
                                Posicion_Productos = Cont_Posicion;//  se toma la posicion del total de los productos

                                Cont_Posicion = Cont_Posicion + 2;//    se mueve la posicion
                            }

                            // *******************************************************************************************
                            //  tabla de servicios 2 tabla
                            if (Dt_Servicios.Rows.Count > 0)
                            {
                                Concentrado.Cells["A" + Cont_Posicion.ToString()].Value = "Servicios";
                                Concentrado.Cells["A" + Cont_Posicion + ":A" + Cont_Posicion].Style.Font.Bold = true;
                                Cont_Posicion++;

                                ExcelRangeBase Rango_Servicios = Concentrado.Cells["A" + Cont_Posicion].LoadFromDataTable(Dt_Servicios, true, OfficeOpenXml.Table.TableStyles.Medium2);
                                Rango_Servicios.AutoFitColumns();

                                //  formato a la tabla de servicios
                                Concentrado.Cells[Cont_Posicion, 2, Rango_Servicios.End.Row, 2].Style.Numberformat.Format = "#,##0.00";
                                Concentrado.Cells[Cont_Posicion, 3, Rango_Servicios.End.Row, 3].Style.Numberformat.Format = "#,##0";
                                Concentrado.Cells[Cont_Posicion, 4, Rango_Servicios.End.Row, 4].Style.Numberformat.Format = "#,##0.00";
                                
                                //  encabezados Totales
                                Cont_Posicion = Cont_Posicion + Dt_Servicios.Rows.Count + 1;// posicion de los totales de la primera tabla
                                Concentrado.Cells["A" + Cont_Posicion.ToString()].Value = "Total Servicios";
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Merge = true;
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                                //  formulas totales
                                Concentrado.Cells["C" + (Cont_Posicion)].Formula = string.Format("SUBTOTAL(109, " + Dt_Servicios.TableName + "[Ventas] )");
                                Concentrado.Cells["D" + (Cont_Posicion)].Formula = string.Format("SUBTOTAL(109, " + Dt_Servicios.TableName + "[Importe Total] )");
                                Concentrado.Cells[(Cont_Posicion), 4, (Cont_Posicion), 4].Style.Numberformat.Format = "#,##0.00";
                                Concentrado.Cells[(Cont_Posicion), 3, (Cont_Posicion), 3].Style.Numberformat.Format = "#,##0";
                                Concentrado.Cells["A" + Cont_Posicion + ":D" + Cont_Posicion].Style.Font.Bold = true;
                                Posicion_Servicios = Cont_Posicion;//  se toma la posicion del total de los servicios

                                Cont_Posicion = Cont_Posicion + 2;
                            }

                            // *******************************************************************************************
                            //  totales
                            if (Dt_Productos.Rows.Count > 0 && Dt_Servicios.Rows.Count > 0)
                            {
                                //  total de servicios + productos
                                //  encabezado de total
                                Concentrado.Cells["A" + Cont_Posicion.ToString()].Value = "Total";
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Merge = true;
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                Concentrado.Cells["A" + Cont_Posicion + ":B" + Cont_Posicion].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                                //  formulas totales
                                Concentrado.Cells["C" + (Cont_Posicion)].Formula = string.Format("C" + Posicion_Productos + " + C" + Posicion_Servicios);
                                Concentrado.Cells["D" + (Cont_Posicion)].Formula = string.Format("D" + Posicion_Productos + " + D" + Posicion_Servicios);
                                Concentrado.Cells[(Cont_Posicion), 4, (Cont_Posicion), 4].Style.Numberformat.Format = "#,##0.00";
                                Concentrado.Cells[(Cont_Posicion), 3, (Cont_Posicion), 3].Style.Numberformat.Format = "#,##0";
                                Concentrado.Cells["A" + Cont_Posicion + ":D" + Cont_Posicion].Style.Font.Bold = true;

                                Cont_Posicion = Cont_Posicion + 2;
                            }


                            // *******************************************************************************************
                            // concentrado de folios 3 tabla
                            Concentrado.Cells["A" + Cont_Posicion].Value = "Concentrado de folios";
                            Concentrado.Cells["A" + Cont_Posicion + ":G" + Cont_Posicion].Style.Font.Bold = true;
                            Concentrado.Cells["A" + Cont_Posicion + ":G" + Cont_Posicion].Merge = true;
                            Concentrado.Cells["A" + Cont_Posicion + ":G" + Cont_Posicion].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Concentrado.Cells["A" + Cont_Posicion + ":G" + Cont_Posicion].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                            Cont_Posicion++;

                            ExcelRangeBase Rango_Folios = Concentrado.Cells["A" + Cont_Posicion].LoadFromDataTable(Dt_Concentrado_Folios, true, OfficeOpenXml.Table.TableStyles.Medium2);
                            Rango_Folios.AutoFitColumns();

                            //  formato a la tabla de servicios
                            Concentrado.Cells[Cont_Posicion, 4, Rango_Folios.End.Row, 4].Style.Numberformat.Format = "#,##0";
                            Concentrado.Cells[Cont_Posicion, 7, Rango_Folios.End.Row, 7].Style.Numberformat.Format = "#,##0";

                            // formulas totales 
                            Cont_Posicion = Cont_Posicion + Ds_Resultados_Busqueda.Tables[1].Rows.Count + 1;// totales
                            Concentrado.Cells["D" + (Cont_Posicion)].Formula = string.Format("SUBTOTAL(109, " + Ds_Resultados_Busqueda.Tables[1].TableName + "[Total Folios] )");
                            Concentrado.Cells["G" + (Cont_Posicion)].Formula = string.Format("SUBTOTAL(109, " + Ds_Resultados_Busqueda.Tables[1].TableName + "[Total] )");
                            Concentrado.Cells[(Cont_Posicion), 4, (Cont_Posicion), 4].Style.Numberformat.Format = "#,##0";
                            Concentrado.Cells[(Cont_Posicion), 7, (Cont_Posicion), 7].Style.Numberformat.Format = "#,##0";
                            Concentrado.Cells["A" + Cont_Posicion + ":G" + Cont_Posicion].Style.Font.Bold = true;

                            // *******************************************************************************************
                            //  pie de pagina
                            Cont_Posicion = Cont_Posicion + 4;
                            Concentrado.Cells["A" + Cont_Posicion.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                            Concentrado.Cells["A" + (Cont_Posicion + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();
                            // *******************************************************************************************

                            pck.Save();

                            MessageBox.Show("Archivo Guardado Correctamente", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que limpia los combos de lugar de venta, cajas, turnos y tarifas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void SBtn_Clear_Click(object sender, EventArgs e)
        {
            switch (((ButtonSpecAny)sender).Tag.ToString())
            {
                case "lugar_venta":
                    KCmb_Lugar_Venta.SelectedIndex = 0;
                    break;
                case "caja":
                    KCmb_Caja.SelectedIndex = 0;
                    break;
                case "turno":
                    KCmb_Turnos.SelectedIndex = 0;
                    break;
                case "tarifa":
                    KCmb_Tarifa_Productos.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region (Combos)
        /// <summary>
        /// Evento que habilita o deshabilita el combo de cajas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void KCmb_Lugar_Venta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KCmb_Lugar_Venta.SelectedValue != null)
            {
                switch (KCmb_Lugar_Venta.SelectedValue.ToString())
                {
                    case "No Caja":
                        KCmb_Caja.Enabled = true;
                        break;
                    default:
                        KCmb_Caja.Enabled = false;
                        KCmb_Caja.SelectedIndex = 0;
                        break;
                }
            }
        }
        #endregion

        #endregion

        #region (Reporte)
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
        protected void Generar_Reporte(ref DataSet Ds_Datos, String Nombre_Plantilla_Reporte)
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

                        ParameterFieldDefinitions Parametros = Reporte.DataDefinition.ParameterFields;
                        ParameterFieldDefinition Parametro;
                        ParameterDiscreteValue Valor = new ParameterDiscreteValue();
                        ParameterValues Valores = new ParameterValues();

                        List<object[]> objParametros = new List<object[]>();

                        objParametros.Add(new object[] { KDtp_Fecha_Inicio.Value, "Fecha_Inicio" });
                        objParametros.Add(new object[] { KDtp_Fecha_Termino.Value, "Fecha_Fin" });
                        objParametros.Add(new object[] { DateTime.Now, "Fecha_Creo" });
                        objParametros.Add(new object[] { MDI_Frm_Apl_Principal.Nombre_Usuario, "Usuario_Creo" });

                        if (KCmb_Turnos.SelectedIndex > 0)
                        {
                            objParametros.Add(new object[] { KCmb_Turnos.Text, "Turno" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "Turno" });
                        }

                        if (KCmb_Caja.SelectedIndex > 0)
                        {
                            objParametros.Add(new object[] { KCmb_Caja.Text, "No_Caja" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "No_Caja" });
                        }

                        if (KCmb_Lugar_Venta.SelectedIndex > 0)
                        {
                            objParametros.Add(new object[] { KCmb_Lugar_Venta.Text, "Lugar_Venta" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "Lugar_Venta" });
                        }

                        if (Cmb_Museo.SelectedIndex > 0)
                        {
                            objParametros.Add(new object[] { Cmb_Museo.Text, "Museo" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "Museo" });
                        }

                        if (KCmb_Tarifa_Productos.SelectedIndex > 0)
                        {
                            objParametros.Add(new object[] { KCmb_Tarifa_Productos.Text, "Tarifa" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "Tarifa" });
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
        #endregion

        /// <summary>
        /// 
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

                    KCmb_Tarifa_Productos.DataSource = Dt_Prod;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
