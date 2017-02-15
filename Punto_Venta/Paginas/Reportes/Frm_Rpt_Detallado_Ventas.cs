using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Erp.Constantes;
using Catalogos.Turnos.Negocio;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Reportes.Ventas.Negocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP_BASE.Paginas.Catalogos.Generales;
using ComponentFactory.Krypton.Toolkit;
using ERP_BASE.Paginas.Paginas_Generales;
using OfficeOpenXml;
using Erp.Metodos_Generales;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Detallado_Ventas : Form
    {
        DataTable Dt_Productos;

        #region (Init/Load)
        public Frm_Rpt_Detallado_Ventas()
        {
            InitializeComponent();
            Configuracion_Inicial();
            this.Text = "Reporte Detallado de Ventas";
        }
        #endregion

        #region (Métodos)

        private void Format(DataTable Dt_Concentrado)
        {
            Dt_Concentrado.Columns["Folio_Acceso"].SetOrdinal(0);
            Dt_Concentrado.Columns["Folio_Venta"].SetOrdinal(1);
            Dt_Concentrado.Columns["Fecha_Expedicion_Folio"].SetOrdinal(2);
            Dt_Concentrado.Columns["Hora_Expedicion_Folio"].SetOrdinal(3);
            Dt_Concentrado.Columns["Lugar_Venta"].SetOrdinal(4);
            Dt_Concentrado.Columns["Tarifa"].SetOrdinal(5);
            Dt_Concentrado.Columns["Acceso_Torniquete"].SetOrdinal(6);
            Dt_Concentrado.Columns["Hora_Acceso_Torniquete"].SetOrdinal(7);
            Dt_Concentrado.Columns["Tipo_Pago"].SetOrdinal(8);
            Dt_Concentrado.Columns["Estado_Folio"].SetOrdinal(9);
            Dt_Concentrado.Columns["Titular_Tarjeta"].SetOrdinal(10);
            Dt_Concentrado.Columns["Banco"].SetOrdinal(11);
            Dt_Concentrado.Columns["Tipo_Tarjeta"].SetOrdinal(12);
            Dt_Concentrado.Columns["Tarjeta_Credito"].SetOrdinal(13);
            Dt_Concentrado.Columns["Usuario_Cancelo"].SetOrdinal(14);
            Dt_Concentrado.Columns["Fecha_Cancelacion"].SetOrdinal(15);
            Dt_Concentrado.Columns["Reimpresion"].SetOrdinal(16);
            Dt_Concentrado.Columns["Usuario_Reimprimio"].SetOrdinal(17);
            Dt_Concentrado.Columns["Fecha_Reimpresion"].SetOrdinal(18);

            Dt_Concentrado.Columns.RemoveAt(19);
            Dt_Concentrado.Columns.RemoveAt(19);
            Dt_Concentrado.Columns.RemoveAt(19);
        }

        /// <summary>
        /// Método que habilita los controles según el valor del parámetro.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 16:42 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Habilitar_Controles(bool Habilitado)
        {
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
                this.Text = "Reporte Detallado de Ventas de Accesos";
                Cargar_Combo_Anio();
                Cargar_Productos();
                Cargar_Cajas();
                Cargar_Turnos();
                Cargar_Lugar_Venta();
                Cargar_Estatus();

                kryptonComboBox1.SelectedIndex = 0;
                Cmb_Anio.SelectedIndex = 0;
                Cmb_Tipo_Reporte.SelectedIndex = 0;
                KDtp_Fecha_Inicio.Checked = true;
                KDtp_Fecha_Termino.Checked = true;


                Habilitar_Controles(false);
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
        /// Metodo que carga los años de los productos
        /// </summary>
        /// <creo>Hugo Enrique Ramirez Aguilera</creo>
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
        /// Método que carga los estatus de las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Estatus()
        {
            try
            {
                Dictionary<string, string> Lugares_Venta = new Dictionary<string, string> { 
                            {"SELECCIONE", string.Empty},
                            {"PAGADO", "PAGADO"},
                            {"CANCELADO", "CANCELADO"}
              };
                KCmb_Estatus.DataSource = new BindingSource(Lugares_Venta, null);
                KCmb_Estatus.DisplayMember = "Key";
                KCmb_Estatus.ValueMember = "Value";
                KCmb_Estatus.SelectedIndex = (0);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Cargar_Lugar_Venta). Descripción: " + Ex.Message);
            }
        }

        private void Exporta_Excel_Detallado(DataTable Detallado)
        {
            SaveFileDialog sf = new SaveFileDialog();

            try
            {
                sf.Filter = "";
                sf.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sf.FileName))
                    {
                        File.Delete(sf.FileName);
                    }

                    FileInfo newFile = new FileInfo(sf.FileName);

                    string Filtros = string.Empty;

                    if (KCmb_Turnos.SelectedIndex > 0)
                    {
                        Filtros += "Turno: " + KCmb_Turnos.Text + ", ";
                    }

                    if (KCmb_Caja.SelectedIndex > 0)
                    {
                        Filtros += "No. Caja: " + KCmb_Caja.Text + ", ";
                    }

                    if (KCmb_Lugar_Venta.SelectedIndex > 0)
                    {
                        if (KCmb_Lugar_Venta.Text.Equals("No Caja"))
                        {
                            Filtros += "Lugar Venta: Número de Caja, ";
                        }
                        else
                        {
                            Filtros += "Lugar Venta: " + KCmb_Lugar_Venta.Text + ", ";
                        }
                    }

                    if (kryptonComboBox1.SelectedIndex > 0)
                    {
                        Filtros += "Museo: " + kryptonComboBox1.Text + ", ";
                    }

                    if (!string.IsNullOrEmpty(Txt_Folio_Acceso.Text))
                    {
                        string Estatus_Folio = "";
                        Filtros += "Folio de Acceso: " + Txt_Folio_Acceso.Text + ", ";

                        Estatus_Folio = Detallado.Rows[0]["Estado_Folio"].ToString();

                        Filtros += "Estatus del Folio: " + Estatus_Folio + ", ";
                    }

                    if (KCmb_Tarifa_Productos.SelectedIndex > 0)
                    {
                        Filtros += "Tarifa: " + KCmb_Tarifa_Productos.Text + ", ";
                    }

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        Detallado.Rows.RemoveAt(Detallado.Rows.Count - 1);
                        
                        Detallado.Columns.Add("Hora de Expedición", typeof(DateTime));
                        Detallado.Columns.Add("Hora Acceso Torniquete", typeof(DateTime));

                        Detallado.Columns["Hora de Expedición"].SetOrdinal(4);
                        Detallado.Columns["Forma_Pago"].SetOrdinal(6);
                        Detallado.Columns["Hora Acceso Torniquete"].SetOrdinal(9);

                        Detallado.Columns[0].ColumnName = "Folio del Ticket de Venta";
                        Detallado.Columns[1].ColumnName = "Folio de Acceso";
                        Detallado.Columns[2].ColumnName = "Tarifa";
                        Detallado.Columns[3].ColumnName = "Fecha de Expedición";
                        Detallado.Columns[5].ColumnName = "Lugar de la Venta";
                        Detallado.Columns[6].ColumnName = "Tipo de Pago";
                        Detallado.Columns[7].ColumnName = "Estatus del Folio";
                        Detallado.Columns[8].ColumnName = "Fecha Acceso Torniquete";
                        Detallado.Columns[10].ColumnName = "Usuario";
                        Detallado.Columns[11].ColumnName = "Fecha";

                        for (int i = 0; i < Detallado.Rows.Count; i++)
                        {
                            Detallado.Rows[i]["Hora de Expedición"] = Detallado.Rows[i]["Fecha de Expedición"];
                            Detallado.Rows[i]["Hora Acceso Torniquete"] = Detallado.Rows[i]["Fecha Acceso Torniquete"];
                        }

                        ExcelWorksheet Detallado_Ventas = Epc_Accesos.Workbook.Worksheets.Add("Detalle Folio de Acceso");

                        Detallado_Ventas.Cells["A1:J6"].Style.Font.Bold = true;
                        Detallado_Ventas.Cells["A1"].Value = "Tesorería Municipal";
                        Detallado_Ventas.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado_Ventas.Cells["A3"].Value = "Museo de las Momias";
                        Detallado_Ventas.Cells["A4"].Value = "Periodo: De " + KDtp_Fecha_Inicio.Value.ToLongDateString() + " al " + KDtp_Fecha_Termino.Value.ToLongDateString();

                        if (!string.IsNullOrEmpty(Filtros))
                        {
                            string Aux = Filtros.Trim().Substring(0, Filtros.Trim().Length - 1);
                            Detallado_Ventas.Cells["A5"].Value = Aux;
                        }

                        Detallado_Ventas.Cells["A6"].Value = "Detalle la venta (Detallado por Folio de Acceso)";

                        Detallado_Ventas.Cells["A1:L1"].Merge = true;
                        Detallado_Ventas.Cells["A2:L2"].Merge = true;
                        Detallado_Ventas.Cells["A3:L3"].Merge = true;
                        Detallado_Ventas.Cells["A4:L4"].Merge = true;
                        Detallado_Ventas.Cells["A5:L5"].Merge = true;
                        Detallado_Ventas.Cells["A6:L6"].Merge = true;

                        Detallado_Ventas.Cells["A1:J1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado_Ventas.Cells["A2:J2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado_Ventas.Cells["A3:J3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado_Ventas.Cells["A4:J4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado_Ventas.Cells["A5:J5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado_Ventas.Cells["A6:J6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado_Ventas.Cells["A1:J1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado_Ventas.Cells["A2:J2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado_Ventas.Cells["A3:J3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado_Ventas.Cells["A4:J4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado_Ventas.Cells["A5:J5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado_Ventas.Cells["A6:J6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        int Fila = 8;
                        ExcelRangeBase Rango = Detallado_Ventas.Cells["A" + Fila].LoadFromDataTable(Detallado,
                            true, OfficeOpenXml.Table.TableStyles.Medium2);

                        int Formato = Fila + 1;
                        Detallado_Ventas.Cells["C" + (Rango.End.Row + 1)].Formula = "SUM(Detalle_Ventas[Tarifa])";

                        //  formato a las celdas
                        Detallado_Ventas.Cells[Formato, 4, Rango.End.Row, 4].Style.Numberformat.Format = "dd/mm/yyyy";
                        Detallado_Ventas.Cells[Formato, 5, Rango.End.Row, 5].Style.Numberformat.Format = "HH:mm:ss";
                        Detallado_Ventas.Cells[Formato, 9, Rango.End.Row, 9].Style.Numberformat.Format = "dd/mm/yyyy";
                        Detallado_Ventas.Cells[Formato, 10, Rango.End.Row, 10].Style.Numberformat.Format = "HH:mm:ss";
                        Detallado_Ventas.Cells[Formato, 12, Rango.End.Row, 12].Style.Numberformat.Format = "dd/mm/yyyy";
                        Detallado_Ventas.Cells[Formato, 3, Rango.End.Row + 1, 3].Style.Numberformat.Format = "#,##0.00";

                        Detallado_Ventas.Cells["A" + (Rango.End.Row + 3)].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Detallado_Ventas.Cells["A" + (Rango.End.Row + 4)].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();

                        Rango.AutoFitColumns();
                        Epc_Accesos.Save();
                    }

                    MessageBox.Show(this, "Exportación exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Exportar_Excel_Concentrado_Ventas()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Datos_Generales = new DataTable();
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();

            try
            { //  informacion del reporte
                Dt_Consulta = Consultar_Reporte_Concentrado_Ticket_Venta_Y_Tipo_Pago(0);
                Grid_Resultado.DataSource = Dt_Consulta;

                //  datos generales del reporte
                Dt_Datos_Generales = Crear_Tabla_Datos_Generales();


                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;


                //  se cambia el nombre de las columnas
                Dt_Consulta.Columns[0].ColumnName = "Folio del Ticket de Venta";
                Dt_Consulta.Columns[1].ColumnName = "Folio del acceso inicial";
                Dt_Consulta.Columns[2].ColumnName = "Folio del acceso final";
                Dt_Consulta.Columns[3].ColumnName = "Total accesos";
                Dt_Consulta.Columns[4].ColumnName = "Importe";
                Dt_Consulta.Columns[5].ColumnName = "Descuento";
                Dt_Consulta.Columns[6].ColumnName = "Importe cancelado";
                Dt_Consulta.Columns[7].ColumnName = "Importe total del ticket";
                Dt_Consulta.Columns[8].ColumnName = "Estatus de la venta";
                Dt_Consulta.Columns[9].ColumnName = "Lugar de la venta";
                Dt_Consulta.Columns[10].ColumnName = "Museo";  
                
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
                        ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Concentrado por ticket de venta");

                        Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las momias";
                        Detallado.Cells["A4"].Value = Dt_Datos_Generales.Rows[0][2].ToString();
                        Detallado.Cells["A5"].Value = Dt_Datos_Generales.Rows[0][3].ToString();

                        Detallado.Cells["A7"].Value = "Detallado de la venta (concentrado por ticket de venta)";

                        Detallado.Cells["A1:A1"].Style.Font.Bold = true;
                        Detallado.Cells["A3:A7"].Style.Font.Bold = true;

                        // Encabezados del reporte
                        Detallado.Cells["A1:H1"].Merge = true;
                        Detallado.Cells["A2:H2"].Merge = true;
                        Detallado.Cells["A3:H3"].Merge = true;
                        Detallado.Cells["A4:H4"].Merge = true;
                        Detallado.Cells["A5:H5"].Merge = true; 
                        Detallado.Cells["A6:H6"].Merge = true;
                        Detallado.Cells["A7:H7"].Merge = true;

                        Detallado.Cells["A1:H1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A2:H2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A3:H3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A4:H4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A5:H5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A6:H6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A7:H7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado.Cells["A1:H1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A2:H2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A3:H3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A4:H4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A5:H5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A6:H6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A7:H7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        Int32 Filas = 8;
                        //  se carga el archivo
                        ExcelRangeBase Rango = Detallado.Cells["A" + Filas].LoadFromDataTable(Dt_Consulta, true, OfficeOpenXml.Table.TableStyles.Medium2);

                        //  formato a las celdas 
                        Detallado.Cells[Filas, 4, Rango.End.Row, 4].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[Filas, 5, Rango.End.Row, 8].Style.Numberformat.Format = "#,##0.00";

                        Filas = Filas + Dt_Consulta.Rows.Count + 1;

                        //  subtotal
                        Detallado.Cells["D" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[Total accesos] )");
                        Detallado.Cells["E" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[Importe] )");
                        Detallado.Cells["F" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[Descuento] )");
                        Detallado.Cells["G" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[Impor cancelado] )");
                        Detallado.Cells["H" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[Impor total del ticket] )");

                        Detallado.Cells["D" + (Filas) + ":H" + (Filas)].Style.Font.Bold = true;
                        Detallado.Cells[(Filas), 4, (Filas), 4].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[(Filas), 5, (Filas), 8].Style.Numberformat.Format = "#,##0.00";

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
        private void Exportar_Excel_Tipo_Pago()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Datos_Generales = new DataTable();
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();

            try
            {
                //  informacion del reporte
                Dt_Consulta = Consultar_Reporte_Concentrado_Ticket_Venta_Y_Tipo_Pago(2);
                Grid_Resultado.DataSource = Dt_Consulta;

                //  datos generales del reporte
                Dt_Datos_Generales = Crear_Tabla_Datos_Generales();

                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  se cambia el nombre de las columnas
                Dt_Consulta.Columns[0].ColumnName = "Folio del Ticket de Venta";
                Dt_Consulta.Columns[1].ColumnName = "Folio del acceso inicial";
                Dt_Consulta.Columns[2].ColumnName = "Folio del acceso final";
                Dt_Consulta.Columns[3].ColumnName = "Total accesos";
                Dt_Consulta.Columns[4].ColumnName = "Impor total del ticket";
                Dt_Consulta.Columns[5].ColumnName = "Estatus de la venta";
                Dt_Consulta.Columns[6].ColumnName = "Lugar de la venta";
                Dt_Consulta.Columns[7].ColumnName = "Tipo de pago";
                Dt_Consulta.Columns[8].ColumnName = "Titular";
                Dt_Consulta.Columns[9].ColumnName = "Tipo de tarjeta";
                Dt_Consulta.Columns[10].ColumnName = "Banco";
                Dt_Consulta.Columns[11].ColumnName = "Numero de tarjeta";
                Dt_Consulta.Columns[12].ColumnName = "Fecha cancelacion";
                Dt_Consulta.Columns[13].ColumnName = "Usuario cancelacion";

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

                        Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las momias";
                        Detallado.Cells["A4"].Value = Dt_Datos_Generales.Rows[0][2].ToString();
                        Detallado.Cells["A5"].Value = Dt_Datos_Generales.Rows[0][3].ToString();

                        Detallado.Cells["A7"].Value = "Detallado de la venta (tipo de pago)";

                        Detallado.Cells["A1:A1"].Style.Font.Bold = true;
                        Detallado.Cells["A3:A7"].Style.Font.Bold = true;

                        // Encabezados del reporte
                        Detallado.Cells["A1:N1"].Merge = true;
                        Detallado.Cells["A2:N2"].Merge = true;
                        Detallado.Cells["A3:N3"].Merge = true;
                        Detallado.Cells["A4:N4"].Merge = true;
                        Detallado.Cells["A5:N5"].Merge = true;
                        Detallado.Cells["A6:N6"].Merge = true;
                        Detallado.Cells["A7:N7"].Merge = true;

                        Detallado.Cells["A1:N1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A2:N2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A3:N3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A4:N4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A5:N5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A6:N6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A7:N7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado.Cells["A1:N1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A2:N2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A3:N3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A4:N4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A5:N5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A6:N6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A7:N7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        Int32 Filas = 8;
                        //  se carga el archivo
                        ExcelRangeBase Rango = Detallado.Cells["A" + Filas].LoadFromDataTable(Dt_Consulta, true, OfficeOpenXml.Table.TableStyles.Medium2);

                        //  formato a las celdas 
                        Detallado.Cells[Filas, 4, Rango.End.Row, 4].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[Filas, 5, Rango.End.Row, 8].Style.Numberformat.Format = "#,##0.00";

                        Filas = Filas + Dt_Consulta.Rows.Count + 1;

                        //  subtotal
                        Detallado.Cells["D" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[Total accesos] )");
                        Detallado.Cells["E" + (Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Consulta.TableName + "[Impor total del ticket] )");

                        Detallado.Cells["D" + (Filas) + ":H" + (Filas)].Style.Font.Bold = true;
                        Detallado.Cells[(Filas), 4, (Filas), 4].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[(Filas), 5, (Filas), 8].Style.Numberformat.Format = "#,##0.00";

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
        private DataTable Crear_Tabla_Datos_Generales()
        {
            DataTable Dt_Datos_Generales = new DataTable();
            String Leyenda_Encabezado = "";
            String Leyenda_Periodo = "";
            Boolean Estatus = false;

            try
            {
                //  periodo del reporte
                if (KDtp_Fecha_Inicio.Checked)
                {
                    DateTime Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                    Leyenda_Periodo += "Periodo: Del " + Fecha_Inicio.ToString("dd")
                                      + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Fecha_Inicio.ToString("MM")))
                                      + " de " + Fecha_Inicio.ToString("yyyy");
                }

                if (KDtp_Fecha_Termino.Checked)
                {
                    DateTime Fecha_Terminio = new DateTime(KDtp_Fecha_Termino.Value.Year
                           , KDtp_Fecha_Termino.Value.Month
                           , KDtp_Fecha_Termino.Value.Day, 23, 59, 59);

                    Leyenda_Periodo += " al " + Fecha_Terminio.ToString("dd")
                                      + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Fecha_Terminio.ToString("MM")))
                                      + " de " + Fecha_Terminio.ToString("yyyy");
                }

                //  filtros utilizados
                if (KCmb_Tarifa_Productos.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Tarifa_Productos.SelectedValue.ToString()))
                    {
                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Producto: " + KCmb_Tarifa_Productos.Text.ToString();

                        Estatus = true;
                    }
                }

                //  turno
                if (KCmb_Turnos.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                    {
                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Turno: " + KCmb_Turnos.Text.ToString();
                        Estatus = true;
                    }
                }

                //  caja
                if (KCmb_Caja.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                    {
                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Numero de caja: " + KCmb_Caja.Text.ToString();
                        Estatus = true;
                    }
                }

                //  lugar de la venta
                if (KCmb_Lugar_Venta.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                    {
                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Lugar de la venta: ";


                        if (KCmb_Lugar_Venta.SelectedValue.ToString() == "No Caja")
                        {
                            Leyenda_Encabezado += " Numero de caja";
                        }
                        else
                        {
                            Leyenda_Encabezado += "" + KCmb_Lugar_Venta.Text.ToString();
                        }

                        Estatus = true;
                    }
                }

                //  estatus
                if (KCmb_Estatus.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Estatus.SelectedValue.ToString()))
                    {
                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Estatus: " + KCmb_Estatus.Text.ToString();
                        Estatus = true;
                    }
                }

                //  numero de folio
                if (!String.IsNullOrEmpty(Txt_Folio_Acceso.Text))
                {

                    if (Estatus)
                        Leyenda_Encabezado += ", ";

                    Leyenda_Encabezado += "Numero de folio de acceso: " + Txt_Folio_Acceso.Text;
                    Estatus = true;
                }

                //  museo
                if (kryptonComboBox1.SelectedIndex > 0)
                {

                    if (Estatus)
                        Leyenda_Encabezado += ", ";

                    Leyenda_Encabezado += "Museo: ";
                    Leyenda_Encabezado += kryptonComboBox1.Text == "MUSEO MOMIAS" ? "Museo de las momias" : "Culto a la muerte";
                    Estatus = true;
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

        /// <summary>
        /// Método para Consultar el Detalle de la Venta por Folio de Acceso, en base de los Filtros de Acceso.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>10 de Diciembre de 2015</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        /// <returns>DataSet con los Resultados</returns>
        private DataSet Consultar_Detallado_Venta()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();

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

                if (KCmb_Estatus.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Estatus.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Estatus = KCmb_Estatus.SelectedValue.ToString();

                if (!String.IsNullOrEmpty(Txt_Folio_Acceso.Text))
                    Obj_Rpt_Ventas.P_Folio_Acceso = Txt_Folio_Acceso.Text;

                if (kryptonComboBox1.SelectedIndex > 0)
                {
                    Obj_Rpt_Ventas.P_Museo = kryptonComboBox1.Text == "MUSEO MOMIAS" ? "00001" : "00002";
                }

                return Obj_Rpt_Ventas.Rpt_Detalle_Ventas();
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
        private DataTable Consultar_Reporte_Concentrado_Ticket_Venta_Y_Tipo_Pago(int Int_Tipo_Reporte)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Reporte = new DataSet();
            DataTable Dt_Consulta = new DataTable();
            String Leyenda_Encabezado = ""; 
            Boolean Periodo6Meses = false;

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

                    if (KCmb_Estatus.SelectedValue is object)
                        if (!string.IsNullOrEmpty(KCmb_Estatus.SelectedValue.ToString()))
                            Obj_Rpt_Ventas.P_Estatus = KCmb_Estatus.SelectedValue.ToString();

                    if (!String.IsNullOrEmpty(Txt_Folio_Acceso.Text))
                        Obj_Rpt_Ventas.P_Folio_Acceso = Txt_Folio_Acceso.Text;

                    if (kryptonComboBox1.SelectedIndex > 0)
                    {
                        Obj_Rpt_Ventas.P_Museo = kryptonComboBox1.Text == "MUSEO MOMIAS" ? "00001" : "00002";
                    }

                    Periodo6Meses = CalcularPeriodo6Meses(Obj_Rpt_Ventas.P_Fecha_Inicio, Obj_Rpt_Ventas.P_Fecha_Termino);

                    if (Periodo6Meses)
                    {
                        if(Int_Tipo_Reporte == 0)
                            Dt_Consulta = Obj_Rpt_Ventas.Rpt_Detalle_Ventas_Concenteado_Ventas();
                        else if(Int_Tipo_Reporte == 2)
                            Dt_Consulta = Obj_Rpt_Ventas.Rpt_Detalle_Ventas_Tipo_Pago();
                    }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Consultar_Reporte_Concentrado_Ticket_Venta). Descripción: " + Ex.Message);
            }

            return Dt_Consulta;
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
                    else if (columna.ValueType.Name.Equals("Decimal"))
                        columna.DefaultCellStyle.Format = "c";

                    if (columna.HeaderText.Equals("Detalle"))
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        columna.Width = 300;
                    }
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
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Auxiliar = new DataTable();

            try
            {
                //  se limpia el grid
                Grid_Resultado.DataSource = null;

                if (Cmb_Tipo_Reporte.SelectedIndex == 0)//  reporte concentrado por ticket de venta
                {
                    Dt_Consulta = Consultar_Reporte_Concentrado_Ticket_Venta_Y_Tipo_Pago(0); 
                    Grid_Resultado.DataSource = Dt_Consulta;
                }
                else if (Cmb_Tipo_Reporte.SelectedIndex == 1)//  Detallado por folio de acceso
                {
                    Ds_Resultados_Busqueda = Consultar_Detallado_Venta();
                    Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables[0];
                }
                else if (Cmb_Tipo_Reporte.SelectedIndex == 2)//  Tipo de pago
                {
                    Dt_Consulta = Consultar_Reporte_Concentrado_Ticket_Venta_Y_Tipo_Pago(2);
                    Grid_Resultado.DataSource = Dt_Consulta;
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
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            //Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataSet Ds_Resultados_Busqueda = new DataSet();

            try
            {
                DataTable Dt_Resultados = ((DataTable)Grid_Resultado.DataSource).Copy();
                
                Dt_Resultados.TableName = "Detalle_Ventas";
                Dt_Resultados.Rows.RemoveAt(Dt_Resultados.Rows.Count - 1);

                Ds_Resultados_Busqueda.Tables.Add(Dt_Resultados);

                if (sender.Equals(Btn_Exportar_Excel)) { }
            
                if (Cmb_Tipo_Reporte.SelectedIndex == 0)//  reporte concentrado por ticket de venta
                {
                    Exportar_Excel_Concentrado_Ventas();
                }
                else if (Cmb_Tipo_Reporte.SelectedIndex == 1)//  Detallado por folio de acceso
                {
                    DataSet Aux = Consultar_Detallado_Venta();
                    Exporta_Excel_Detallado(Aux.Tables[0]);
                }
                else if (Cmb_Tipo_Reporte.SelectedIndex == 2)//  Tipo de pago
                {
                    Exportar_Excel_Tipo_Pago();
                }
                else
                {

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_Excel_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Datos_Generales = new DataTable();
            try
            {

                if (Cmb_Tipo_Reporte.SelectedIndex == 0)//  reporte concentrado por ticket de venta
                {
                    //  informacion del reporte
                    Dt_Consulta = Consultar_Reporte_Concentrado_Ticket_Venta_Y_Tipo_Pago(0);
                    Grid_Resultado.DataSource = Dt_Consulta;

                    //  datos generales del reporte
                    Dt_Datos_Generales = Crear_Tabla_Datos_Generales();
                    
                    //  se carga el dataset
                    Dt_Consulta.TableName = "Dt_Concentrado";
                    Ds_Resultados_Busqueda.Tables.Add(Dt_Consulta);
                    Ds_Resultados_Busqueda.Tables.Add(Dt_Datos_Generales);
                    
                    //  se ejectua el reporte
                    Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Detallado_Venta_Concentrado_Tickets.rpt", 0);
                }
                else if (Cmb_Tipo_Reporte.SelectedIndex == 1)//  Detallado por folio de acceso
                {
                    DataTable Dt_Accesos = Consultar_Detallado_Venta().Tables[0].Copy();

                    if (Dt_Accesos.Rows.Count > 0)
                    {
                        Dt_Accesos.Rows.RemoveAt(Dt_Accesos.Rows.Count - 1);
                        Dt_Accesos.TableName = "Detalle_Ventas";
                        Ds_Resultados_Busqueda.Tables.Add(Dt_Accesos);

                        Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Detalle_Ventas.rpt", 1);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron resultados de la búsqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Cmb_Tipo_Reporte.SelectedIndex == 2)//  Tipo de pago
                {
                    //  informacion del reporte
                    Dt_Consulta = Consultar_Reporte_Concentrado_Ticket_Venta_Y_Tipo_Pago(2);
                    Grid_Resultado.DataSource = Dt_Consulta;

                    //  datos generales del reporte
                    Dt_Datos_Generales = Crear_Tabla_Datos_Generales();

                    //  se carga el dataset
                    Dt_Consulta.TableName = "Dt_Tipo_Pago";
                    Ds_Resultados_Busqueda.Tables.Add(Dt_Consulta);
                    Ds_Resultados_Busqueda.Tables.Add(Dt_Datos_Generales);

                    //  se ejectua el reporte
                    Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Detallado_Venta_Tipo_Pago.rpt", 2);
                }
                else
                {
                    /*int Rows = Ds_Resultados_Busqueda.Tables[0].Rows.Count;
                    
                    for (int i = 0; i < Rows; i++)
                    {
                        if (Ds_Resultados_Busqueda.Tables[0].Rows[i][3] != DBNull.Value)
                        {
                            Ds_Resultados_Busqueda.Tables[0].Rows[i][3] =
                                Convert.ToDateTime(Ds_Resultados_Busqueda.Tables[0].Rows[i][3]).Date;
                        }
                    }*/
                    
                    //Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Detalle_Ventas.rpt");
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
                case "estatus":
                    KCmb_Estatus.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Evento que limpia los controles de la pagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            KCmb_Caja.SelectedIndex = 0;
            KCmb_Caja.Enabled = true;
            KCmb_Estatus.SelectedIndex = 0;
            KCmb_Lugar_Venta.SelectedIndex = 0;
            KCmb_Tarifa_Productos.SelectedIndex = 0;
            KCmb_Turnos.SelectedIndex = 0;

            KDtp_Fecha_Inicio.Value = DateTime.Now;
            KDtp_Fecha_Inicio.Checked = false;
            KDtp_Fecha_Inicio.Invalidate();

            KDtp_Fecha_Termino.Value = DateTime.Now;
            KDtp_Fecha_Termino.Checked = false;
            KDtp_Fecha_Termino.Invalidate();

            Grid_Resultado.DataSource = new DataTable();
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
        protected void Generar_Reporte(ref DataSet Ds_Datos, String Nombre_Plantilla_Reporte, int Indice)
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

                        objParametros.Add(new object[] { KDtp_Fecha_Inicio.Value, "Periodo_Inicial" });
                        objParametros.Add(new object[] { KDtp_Fecha_Termino.Value, "Periodo_Final" });
                        objParametros.Add(new object[] { DateTime.Now, "Fecha_Creo" });
                        objParametros.Add(new object[] { MDI_Frm_Apl_Principal.Nombre_Usuario, "Usuario_Creo" });
                        
                        if (kryptonComboBox1.SelectedIndex > 0)
                        {
                            objParametros.Add(new object[] { kryptonComboBox1.SelectedText, "Museo" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "Museo" });
                        }

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

                        if (!string.IsNullOrEmpty(Txt_Folio_Acceso.Text))
                        {
                            string Estatus_Folio;
                            objParametros.Add(new object[] { Txt_Folio_Acceso.Text, "Folio" });

                            Estatus_Folio = Ds_Datos.Tables[0].Rows[0]["Estado_Folio"].ToString();
                            objParametros.Add(new object[] { Estatus_Folio, "Estatus" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "Estatus" });
                            objParametros.Add(new object[] { string.Empty, "Folio" });
                        }

                        if (KCmb_Tarifa_Productos.SelectedIndex > 0)
                        {
                            objParametros.Add(new object[] { KCmb_Tarifa_Productos.Text, "Tarifa" });
                        }
                        else
                        {
                            objParametros.Add(new object[] { string.Empty, "Tarifa" });
                        }

                        if (Indice == 1)
                        {
                            foreach (object[] objParametro in objParametros)
                            {
                                Parametro = Parametros[objParametro[1].ToString()];
                                Valores = Parametro.CurrentValues;
                                Valores.Clear();

                                Valor.Value = objParametro[0];
                                Valores.Add(Valor);
                                Parametro.ApplyCurrentValues(Valores);
                            }
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
        /// Filtra las Tarifas en base al año seleccionado.
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
