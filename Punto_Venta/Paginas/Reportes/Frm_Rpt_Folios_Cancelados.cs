using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
using System.IO;
using OfficeOpenXml;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Folios_Cancelados : Form
    {
        DataTable Dt_Productos;

        #region (Init/Load)
        public Frm_Rpt_Folios_Cancelados()
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
            //KCmb_Caja.Enabled = Habilitado;
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
                Habilitar_Controles(false);

                //Cmb_Anio.SelectedIndex = 0;
                //KCmb_Tarifa_Productos.SelectedIndex = 0;
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
                //KCmb_Tarifa_Productos.ValueMember = Cat_Productos.Campo_Producto_Id;
                //KCmb_Tarifa_Productos.DisplayMember = Cat_Productos.Campo_Nombre;
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
        /// Método que carga los lugares donde se pueden registrar las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private DataSet Consultar_DsReporte()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Reporte = new DataSet();
            String Leyenda_Encabezado = "";

            try
            {
                //Establecemos los filtros para realizar la búsqueda.
                if (KDtp_Fecha_Inicio.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                    Leyenda_Encabezado += "Periodo: Del " + Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("dd")
                                        + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("MM")))
                                        + " de " + Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("yyyy");
                }


                if (KDtp_Fecha_Termino.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(KDtp_Fecha_Termino.Value.Year
                        , KDtp_Fecha_Termino.Value.Month
                        , KDtp_Fecha_Termino.Value.Day, 23, 59, 59);

                    Leyenda_Encabezado += " al " + Obj_Rpt_Ventas.P_Fecha_Termino.ToString("dd")
                                        + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Ventas.P_Fecha_Termino.ToString("MM")))
                                        + " de " + Obj_Rpt_Ventas.P_Fecha_Termino.ToString("yyyy");
                }


                //  producto
                //if (KCmb_Tarifa_Productos.SelectedValue is object)
                //{
                //    if (!string.IsNullOrEmpty(KCmb_Tarifa_Productos.SelectedValue.ToString()))
                //        Obj_Rpt_Ventas.P_Producto_ID = KCmb_Tarifa_Productos.SelectedValue.ToString();
                //}

                //  turno
                if (KCmb_Turnos.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();
                        Leyenda_Encabezado += ", Turno: " + KCmb_Turnos.Text;
                    }
                }

                //  caja
                if (KCmb_Caja.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();
                        Leyenda_Encabezado += ", No. caja: " + KCmb_Caja.Text;
                    }
                }

                //  lugar de la venta
                if (KCmb_Lugar_Venta.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = KCmb_Lugar_Venta.Text;

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

                //  filtro para el numero de venta
                if (!String.IsNullOrEmpty(Txt_No_Venta.Text))
                {
                    Obj_Rpt_Ventas.P_No_Venta = Txt_No_Venta.Text;
                    Leyenda_Encabezado += ", No. de la venta: " + Txt_No_Venta.Text;
                }

                Obj_Rpt_Ventas.P_Tipo = Leyenda_Encabezado;

                //  generacion de la consulta
                Ds_Reporte = Obj_Rpt_Ventas.Rpt_Folios_Cancelados();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Consultar_DsReporte). Descripción: " + Ex.Message);
            }

            return Ds_Reporte;
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
                    //columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //if (columna.ValueType.Name.Equals("DateTime"))
                    //    columna.DefaultCellStyle.Format = "dd MMM yyyy";
                    //else if (columna.ValueType.Name.Equals("Decimal") && !columna.HeaderText.Equals("Total Productos")
                    //    && !columna.HeaderText.Equals("Total Accesos") && !columna.HeaderText.Equals("Visitantes"))
                    //    columna.DefaultCellStyle.Format = "c";

                    //if (columna.HeaderText.Equals("Motivo"))
                    //{
                    //    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //    columna.Width = 300;
                    //}
                    //else if (columna.HeaderText.Equals("Usuario Cancelo"))
                    //{
                    //    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //    columna.Width = 200;
                    //}
                    //else if (columna.HeaderText.Equals("Fecha Cancelacion"))
                    //{
                    //    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //    columna.Width = 150;
                    //}
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Formato_Tabla]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Metodo que cambia el formato de las celdas del grid de detalles de la venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:31 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        private void Grid_Resultado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.Font = new System.Drawing.Font("Consolas Black", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            
            try
            {
                Grid_Resultado.DataSource = null;

                //  realiza la consulta de la informacion
                Ds_Resultados_Busqueda = Consultar_DsReporte();

                //  cargar informacion en grid
                if (Ds_Resultados_Busqueda.Tables["Detalle_Ventas"] is DataTable)
                {
                    if (Ds_Resultados_Busqueda.Tables["Detalle_Ventas"].Rows.Count > 0)
                    {
                        Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables["Detalle_Ventas"];
                    }
                    else
                    {
                        Grid_Resultado.DataSource = new DataTable();
                    }
                }
                else
                {
                    Grid_Resultado.DataSource = new DataTable();
                }

                Formato_Tabla(Grid_Resultado);//Modificamos el formato de la tabla de resultados de la búsqueda.
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

                //  realiza la consulta de la informacion
                Ds_Resultados_Busqueda = Consultar_DsReporte();

                Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Folios_Cancelados.rpt");
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
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_Cancelaciones = new DataTable();
            DataTable Dt_General = new DataTable();
            Int32 Cont_Registros = 0;
            try
            {

                //  realiza la consulta de la informacion
                Ds_Resultados_Busqueda = Consultar_DsReporte();

                Dt_Cancelaciones = Ds_Resultados_Busqueda.Tables["Detalle_Ventas"];
                Dt_General = Ds_Resultados_Busqueda.Tables["Datos_Generales"];

                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;
             
                //  se cambiaran los nombres de ñas columnas
                foreach (DataColumn Dc_Registro in Dt_Cancelaciones.Columns)
                {
                    Dc_Registro.ColumnName = Dc_Registro.ColumnName.Replace('_', ' ');
                }

                //  se cambia el nombre de la columna Fecha
                Dt_Cancelaciones.Columns["Fecha"].ColumnName = "Fecha_";
                Dt_Cancelaciones.Columns.Add("Fecha", typeof(System.DateTime));

                foreach (DataRow Dr_Registro in Dt_Cancelaciones.Rows)
                {
                    Dr_Registro["Fecha"] = Convert.ToDateTime(Dr_Registro["Fecha_"].ToString());
                }

                //  se remueve la columna de fecha_
                Dt_Cancelaciones.Columns.RemoveAt(6);

                  //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName)) File.Delete(Sfd_Ruta_Archivo.FileName);
                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    //  obtenemos el numero de registros que se ingresaran
                    Cont_Registros = Dt_Cancelaciones.Rows.Count;

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Folios cancelados");

                        //  orden de las columnas
                        Dt_Cancelaciones.Columns["Folio del ticket de venta"].SetOrdinal(0);
                        Dt_Cancelaciones.Columns["Folio del acceso Numero Inicial"].SetOrdinal(1);
                        Dt_Cancelaciones.Columns["Folio del acceso Numero Final"].SetOrdinal(2);
                        Dt_Cancelaciones.Columns["Total Accesos"].SetOrdinal(3);
                        Dt_Cancelaciones.Columns["Importe total Ticket"].SetOrdinal(4);
                        Dt_Cancelaciones.Columns["Lugar de la venta"].SetOrdinal(5);
                        Dt_Cancelaciones.Columns["Fecha"].SetOrdinal(6);
                        Dt_Cancelaciones.Columns["Hora"].SetOrdinal(7);
                        Dt_Cancelaciones.Columns["Usuario Cancelo"].SetOrdinal(8);
                        Dt_Cancelaciones.Columns["Motivo Cancelacion"].SetOrdinal(9);


                        Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las momias";
                        Detallado.Cells["A4"].Value = Dt_General.Rows[0]["Periodo_Reporte"].ToString();
                        Detallado.Cells["A6"].Value = "Folios cancelados";


                        Detallado.Cells["A1:A1"].Style.Font.Bold = true;
                        Detallado.Cells["A3:A6"].Style.Font.Bold = true;


                        // Encabezados del reporte
                        Detallado.Cells["A1:J1"].Merge = true;
                        Detallado.Cells["A2:J2"].Merge = true;
                        Detallado.Cells["A3:J3"].Merge = true;
                        Detallado.Cells["A4:J4"].Merge = true;
                        Detallado.Cells["A6:J6"].Merge = true;

                        Detallado.Cells["A1:J1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A2:J2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A3:J3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A4:J4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A6:J6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado.Cells["A1:J1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A2:J2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A3:J3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A4:J4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A6:J6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        //  se carga el archivo
                        ExcelRangeBase Rango = Detallado.Cells["A7"].LoadFromDataTable(Dt_Cancelaciones,
                                                       true, OfficeOpenXml.Table.TableStyles.Medium2);


                        Int32 Filas = 0;
                        Filas = Filas + Dt_Cancelaciones.Rows.Count + 8;

                        //  formato a las celdas 
                        Detallado.Cells[7, 7, Rango.End.Row, 7].Style.Numberformat.Format = "mm-dd-yy";
                        Detallado.Cells[7, 4, Rango.End.Row, 4].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[7, 5, Rango.End.Row, 5].Style.Numberformat.Format = "#,##0.00";

                        //  subtotal
                        Detallado.Cells["D" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Cancelaciones.TableName + "[Total Accesos] )");
                        Detallado.Cells["E" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Cancelaciones.TableName + "[Importe total Ticket] )");
                        Detallado.Cells["D" + (Filas) + ":E" + (Filas)].Style.Font.Bold = true;
                        Detallado.Cells[(Filas), 4, (Filas), 4].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[(Filas), 5, (Filas), 5].Style.Numberformat.Format = "#,##0.00";

                        Filas = Filas + 2;
                        
                        //  pie de pagina
                        Detallado.Cells["A" + Filas.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Detallado.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();


                        Rango.AutoFitColumns();
                        Epc_Accesos.Save();
                    }


                    MessageBox.Show(this, "Exportacion exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    //KCmb_Tarifa_Productos.SelectedIndex = 0;
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
            //if (KCmb_Lugar_Venta.SelectedValue != null)
            //{
            //    switch (KCmb_Lugar_Venta.SelectedValue.ToString())
            //    {
            //        case "No Caja":
            //            KCmb_Caja.Enabled = true;
            //            break;
            //        default:
            //            KCmb_Caja.Enabled = false;
            //            KCmb_Caja.SelectedIndex = 0;
            //            break;
            //    }
            //}
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

        private void Flp_Barra_Herramientas_Paint(object sender, PaintEventArgs e)
        {

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
                //if (Cmb_Anio.SelectedIndex > 0)
                //{
                //    DataTable Dt_Prod = (from Dt_P in Dt_Productos.AsEnumerable()
                //                         where Dt_P.Field<int>("Anio") == int.Parse(Cmb_Anio.Text)
                //                         select Dt_P).CopyToDataTable();

                //    DataRow Seleccione = Dt_Prod.NewRow();
                //    Seleccione["Nombre"] = "SELECCIONE";
                //    Dt_Prod.Rows.InsertAt(Seleccione, 0);

                //    KCmb_Tarifa_Productos.DataSource = Dt_Prod;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
