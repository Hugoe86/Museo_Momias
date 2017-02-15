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
using ERP_BASE.Paginas.Catalogos.Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using Reportes.Ventas.Negocio;
using ERP_BASE.Paginas.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using OfficeOpenXml;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Ventas_ : Form
    {
        private DataTable Dt_Productos;

        public Frm_Rpt_Ventas_()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Ventas__Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Productos(); //Se realiza la carga del listado de productos.
                Cargar_Cajas();     //Se realiza la carga de las cajas registradas por catálogo.
                Cargar_Turnos();    //Se realiza la carga de los turnos registrados por catálogo.
                Cargar_Anios();

                Cmb_Anio.SelectedIndex = 0;
                Cmb_Museo.SelectedIndex = 0;
                Cmb_Producto.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Frm_Rpt_Ventas_Load]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region (Metodos)
        /// <summary>
        /// Nombre: Cargar_Productos
        /// 
        /// Descripción: Método que realiza la carga de productos registrados por catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:17 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Productos()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Resultados_Busqueda = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Consultar_Productos();//Ejecutamos la consulta de productos.
                //Cmb_Producto.DataSource = Dt_Resultados_Busqueda;//Cargamos el listado de productos.
                Dt_Resultados_Busqueda.Rows.RemoveAt(0);
                Dt_Productos = Dt_Resultados_Busqueda;
                Cmb_Producto.ValueMember = Cat_Productos.Campo_Producto_Id;
                Cmb_Producto.DisplayMember = Cat_Productos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Productos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Cargar_Cajas
        /// 
        /// Descripción: Método que realiza la carga de las cajas registradas por catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:20 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
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
                        Cmb_Cajas.DataSource = Lista;
                        Cmb_Cajas.ValueMember = Cat_Cajas.Campo_Caja_ID;
                        Cmb_Cajas.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
                    }
                }
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
        /// Nombre: CalcularPeriodo6Meses 
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

        /// <summary>
        /// Nombre: Cargar_Turnos
        /// 
        /// Descripción: Método que carga la lista de turnos registrados por catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:22 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico
        /// </summary>
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
                Cmb_Turnos.DataSource = Dt_Turnos;
                Cmb_Turnos.ValueMember = Cat_Turnos.Campo_Turno_ID;
                Cmb_Turnos.DisplayMember = Cat_Turnos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Filtro de Tarifas por Año
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Anio.SelectedIndex > 0)
                {
                    DataTable Dt_Prod = (from P in Dt_Productos.AsEnumerable()
                                         where P.Field<int>("Anio") == int.Parse(Cmb_Anio.Text)
                                         select P).CopyToDataTable();

                    DataRow Seleccione = Dt_Prod.NewRow();
                    Seleccione["Nombre"] = "SELECCIONE";
                    Dt_Prod.Rows.InsertAt(Seleccione, 0);

                    Cmb_Producto.DisplayMember = "Nombre";
                    Cmb_Producto.ValueMember = "Producto_ID";
                    Cmb_Producto.DataSource = Dt_Prod;
                }
                else
                {
                    Cmb_Producto.DataSource = null;
                    Cmb_Producto.Items.Add("SELECCIONE");
                    Cmb_Producto.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Btn_Consultar_Click
        /// 
        /// Descripción: Método que ejecuta la consulta de los tipos de movimientos [Ventas - Recolecciones - Arqueos]
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:36 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            Boolean Periodo6Meses = false;

            try
            {
                Grid_Resultados_Busqueda.DataSource = null;

                //Establecemos los filtros para realizar la búsqueda.
                if (Dtp_Fecha_Inicio.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(Dtp_Fecha_Inicio.Value.Year
                        , Dtp_Fecha_Inicio.Value.Month
                        , Dtp_Fecha_Inicio.Value.Day, 0, 0, 0);
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar una Fecha de Inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Dtp_Fecha_Termino.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(Dtp_Fecha_Termino.Value.Year
                        , Dtp_Fecha_Termino.Value.Month
                        , Dtp_Fecha_Termino.Value.Day, 23, 59, 59);
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar una Fecha de Término", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Cmb_Producto.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Producto.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Producto_ID = Cmb_Producto.SelectedValue.ToString();

                if (Cmb_Cajas.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Cajas.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = Cmb_Cajas.SelectedValue.ToString();

                if (Cmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = Cmb_Turnos.SelectedValue.ToString();

                if (Cmb_Lugar_Venta.Text is object)
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                        Obj_Rpt_Ventas.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                if (!string.IsNullOrEmpty(Txt_Folio_Venta.Text))
                    Obj_Rpt_Ventas.P_Folio_Venta = Txt_Folio_Venta.Text;

                if (Cmb_Museo.SelectedIndex > 0)
                {
                    Obj_Rpt_Ventas.P_Museo = Cmb_Museo.Text == "MUSEO MOMIAS" ? "00001" : "00002";
                }

                Periodo6Meses = CalcularPeriodo6Meses(Obj_Rpt_Ventas.P_Fecha_Inicio, Obj_Rpt_Ventas.P_Fecha_Termino);

                if (Periodo6Meses)
                {
                    Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Ventas().Tables["Padre"];
                    
                    if (Dt_Resultados_Busqueda is DataTable)
                        if (Dt_Resultados_Busqueda.Rows.Count > 0)
                            Grid_Resultados_Busqueda.DataSource = Dt_Resultados_Busqueda;
                        else Grid_Resultados_Busqueda.DataSource = new DataTable();
                    else Grid_Resultados_Busqueda.DataSource = new DataTable();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Btn_Exportar_PDF_Click
        /// 
        /// Descripción: Método que exporta el listado de la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:37 Hrs.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 11-mar-2014
        /// Causa Modificación: Se agrega validación: el Grid_Resultados_Busqueda debe contener registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            if (Grid_Resultados_Busqueda.Columns.Count > 0)
            {
                try
                {
                    string Ruta_Reporte = "../../Paginas/Plantillas_Crystal/Rpt_Ventas.rpt";
                    DataTable Datos = (DataTable)Grid_Resultados_Busqueda.DataSource;
                    DataTable Dt_PDF = Datos.Copy();

                    Dt_PDF.Rows.RemoveAt(Datos.Rows.Count - 1);
                    Generar_Reporte(ref Dt_PDF, Ruta_Reporte);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_PDF_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se da click sobre el botón de exportar reporte a excel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>21 Mayo 2014 10:05 Hrs</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            if (Grid_Resultados_Busqueda.Columns.Count > 0)
            {
                try
                {
                    DataTable Dt_Datos_Exportar = Grid_Resultados_Busqueda.DataSource as DataTable;
                    
                    Exportar_Excel_Epplus(Dt_Datos_Exportar, "");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_Excel_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ds_Datos"></param>
        /// <param name="Nombre_Plantilla_Reporte"></param>
        protected void Generar_Reporte(ref DataTable Ds_Datos, String Nombre_Plantilla_Reporte)
        {
            ReportDocument Reporte = new ReportDocument();//Variable de tipo reporte.

            String Ruta = String.Empty;//Variable que almacenara la ruta del archivo del crystal report. 

            try
            {
                Reporte.Load(Nombre_Plantilla_Reporte);

                if (Ds_Datos.Rows.Count > 0)
                {
                    Reporte.SetDataSource(Ds_Datos);

                    ParameterFieldDefinitions Parametros = Reporte.DataDefinition.ParameterFields;
                    ParameterFieldDefinition Parametro;
                    ParameterDiscreteValue Valor = new ParameterDiscreteValue();
                    ParameterValues Valores = new ParameterValues();

                    List<object[]> objParametros = new List<object[]>();

                    objParametros.Add(new object[] { Dtp_Fecha_Inicio.Value, "Periodo_Inicial" });
                    objParametros.Add(new object[] { Dtp_Fecha_Termino.Value, "Periodo_Final" });
                    objParametros.Add(new object[] { string.Empty, "Estatus" });
                    objParametros.Add(new object[] { DateTime.Now, "Fecha_Creo" });
                    objParametros.Add(new object[] { MDI_Frm_Apl_Principal.Nombre_Usuario, "Usuario_Creo" });

                    if (Cmb_Turnos.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Turnos.Text, "Turno" });
                    }
                    else
                    {
                        objParametros.Add(new object[] { string.Empty, "Turno" });
                    }

                    if (Cmb_Cajas.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Cajas.Text, "No_Caja" });
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

                    if (Cmb_Museo.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Museo.Text, "Museo" });
                    }
                    else
                    {
                        objParametros.Add(new object[] { string.Empty, "Museo" });
                    }

                    if (!string.IsNullOrEmpty(Txt_Folio_Venta.Text))
                    {
                        objParametros.Add(new object[] { Txt_Folio_Venta.Text, "Folio" });
                    }
                    else
                    {
                        objParametros.Add(new object[] { string.Empty, "Folio" });
                    }

                    if (Cmb_Producto.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Producto.Text, "Tarifa" });
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
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte. Error: [" + Ex.Message + "]");
            }
        }

        /// <summary>
        /// Método que exporta el reporte a excel.
        /// </summary>
        /// <param name="Dt_Datos">Tabla que contiene los datos que se mostraran en el reporte</param>
        /// <param name="Titulo">Titulo del reporte</param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>21 Mayo 2014 10:08 Hrs</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public void Exportar_Excel_Epplus(DataTable Dt_Datos, string Titulo)
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_General = new DataTable();

            try
            {
                Dt_General = Dt_Datos.Copy();
                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName)) File.Delete(Sfd_Ruta_Archivo.FileName);
                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    string Filtros = string.Empty;

                    if (Cmb_Turnos.SelectedIndex > 0)
                    {
                        Filtros += "Turno: " + Cmb_Turnos.Text + ", ";
                    }

                    if (Cmb_Cajas.SelectedIndex > 0)
                    {
                        Filtros += "No. Caja: " + Cmb_Cajas.Text + ", ";
                    }

                    if (Cmb_Lugar_Venta.SelectedIndex > 0)
                    {
                        if (Cmb_Lugar_Venta.Text.Equals("No Caja"))
                        {
                            Filtros += "Lugar Venta: Número de Caja, ";
                        }
                        else
                        {
                            Filtros += "Lugar Venta: " + Cmb_Lugar_Venta.Text + ", ";
                        }
                    }
                    
                    if (Cmb_Museo.SelectedIndex > 0)
                    {
                        Filtros += "Museo: " + Cmb_Museo.Text + ", ";
                    }
                    
                    if (!string.IsNullOrEmpty(Txt_Folio_Venta.Text))
                    {
                        Filtros += "Folio: " + Txt_Folio_Venta.Text + ", ";
                    }

                    if (Cmb_Producto.SelectedIndex > 0)
                    {
                        Filtros += "Tarifa: " + Cmb_Producto.Text + ", ";
                    }

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Ventas");

                        Detallado.Cells["A1"].Value = "Tesorería Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las Momias";
                        Detallado.Cells["A4"].Value = "Periodo: De " + Dtp_Fecha_Inicio.Value.ToLongDateString() + " al " + Dtp_Fecha_Termino.Value.ToLongDateString();

                        if (!string.IsNullOrEmpty(Filtros))
                        {
                            string Aux = Filtros.Trim().Substring(0, Filtros.Trim().Length - 1);
                            Detallado.Cells["A5"].Value = Aux;
                        }

                        Detallado.Cells["A1:J5"].Style.Font.Bold = true;

                        // Encabezados del reporte
                        Detallado.Cells["A1:J1"].Merge = true;
                        Detallado.Cells["A2:J2"].Merge = true;
                        Detallado.Cells["A3:J3"].Merge = true;
                        Detallado.Cells["A4:J4"].Merge = true;
                        Detallado.Cells["A5:J5"].Merge = true;

                        Detallado.Cells["A1:J1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A2:J2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A3:J3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A4:J4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A5:J5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado.Cells["A1:J1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A2:J2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A3:J3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A4:J4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A5:J5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        Dt_General.Columns[0].ColumnName = "Folio del Ticket de Venta";
                        Dt_General.Columns[1].ColumnName = "Fecha de Expedición";
                        Dt_General.Columns[2].ColumnName = "Tarifa";
                        Dt_General.Columns[8].ColumnName = "Lugar Venta";

                        //  se carga el archivo
                        Dt_General.Rows.RemoveAt(Dt_General.Rows.Count - 1);
                        ExcelRangeBase Rango = Detallado.Cells["A7"].LoadFromDataTable(Dt_General,
                                                       true, OfficeOpenXml.Table.TableStyles.Medium2);

                        // Formato de Fechas
                        Detallado.Cells[8, 2, Rango.End.Row, 2].Style.Numberformat.Format = "mm-dd-yy";
                        
                        int Fila = Rango.End.Row + 1;

                        Detallado.Cells["E" + Fila].Formula = "SUM(Padre[Subtotal])";
                        Detallado.Cells["F" + Fila].Formula = "SUM(Padre[Descuentos])";
                        Detallado.Cells["G" + Fila].Formula = "SUM(Padre[Total])";

                        // Formato de Moneda
                        Detallado.Cells[8, 5, Fila, 7].Style.Numberformat.Format = "#,##0.00";

                        Fila += 2;
                        Detallado.Cells["A" + Fila.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Detallado.Cells["A" + (Fila + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();

                        Rango.AutoFitColumns();
                        Epc_Accesos.Save();

                        MessageBox.Show("Archivo Guardado Correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Exportar_Excel_Epplus]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
