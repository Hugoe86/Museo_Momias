using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Constantes;
using Catalogos.Turnos.Negocio;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Reportes.Ventas.Negocio;
using CrystalDecisions.CrystalReports.Engine;
using ERP_BASE.Paginas.Catalogos.Generales;
using ComponentFactory.Krypton.Toolkit;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp.Metodos_Generales;
using System.IO;
using OfficeOpenXml;
using CrystalDecisions.Shared;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Reporte_Cortes_Arqueo_Cajas : Form
    {
        string Tipo_Busqueda_Reporte = null;

        #region (Init/Load)
        public Frm_Rpt_Reporte_Cortes_Arqueo_Cajas()
        {
            InitializeComponent();
            Configuracion_Inicial();
            Lbl_Fecha_Inicio_Busqueda.Text = "Fecha Inicio";
            Lbl_Fecha_Fin.Text = "Fecha Fin";
        }
        #endregion

        #region (Métodos)
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
                KDtp_Fecha_Inicio.CalendarTodayDate = DateTime.Now;
                Dtp_Fecha_Fin.CalendarTodayDate = DateTime.Now;

                Cargar_Cajas();
                Cargar_Turnos();
                Cargar_Tipo_Reporte();
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: Metodo(Configuracion_Inicial). Descripción:" + Ex.Message);
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
        /// Método que carga el tipo concentrado o detallado del reporte
        /// </summary>
        /// <creo>Olimpo Cruz Amaya</creo>
        /// <fecha_creo>2015 06 02 16:49 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Tipo_Reporte()
        {
            try
            {
              //  Dictionary<string, string> Tipo_Reporte = new Dictionary<string, string> { 
              //              {"DETALLADO", "DETALLADO"},
              //              {"CONCENTRADO", "CONCENTRADO"}
              //};
              //  KCmb_Tipo_Reporte.DataSource = new BindingSource(Tipo_Reporte, null);
              //  KCmb_Tipo_Reporte.DisplayMember = "Key";
              //  KCmb_Tipo_Reporte.ValueMember = "Value";
              //  KCmb_Tipo_Reporte.SelectedIndex = (0);
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
        public DataSet Consultar_Informacion ()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            String Leyenda_Encabezado = "";
            String Leyenda_Periodo = "";
            Boolean Estatus = false;
            DataTable Dt_Datos_Generales = new DataTable();

            try
            {
                //Establecemos los filtros para realizar la búsqueda.    
                //  filtro para la fecha inicial
                if (KDtp_Fecha_Inicio.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                    Leyenda_Periodo += "Periodo: Del " + Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("dd")
                                     + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("MM")))
                                     + " de " + Obj_Rpt_Ventas.P_Fecha_Inicio.ToString("yyyy");
                }

                //  filtro para la fecha final
                if (Dtp_Fecha_Fin.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(Dtp_Fecha_Fin.Value.Year
                        , Dtp_Fecha_Fin.Value.Month
                        , Dtp_Fecha_Fin.Value.Day, 0, 0, 0);

                    Leyenda_Periodo += " al " + Obj_Rpt_Ventas.P_Fecha_Termino.ToString("dd")
                                     + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Ventas.P_Fecha_Termino.ToString("MM")))
                                     + " de " + Obj_Rpt_Ventas.P_Fecha_Termino.ToString("yyyy");
                }

                //  filtro numero de caja
                if (KCmb_Caja.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();

                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Caja: " + KCmb_Caja.Text.ToString();

                        Estatus = true;

                    }
                }

                //  filtro turno
                if (KCmb_Turnos.SelectedValue is object)
                {
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                    {
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();

                        if (Estatus)
                            Leyenda_Encabezado += ", ";

                        Leyenda_Encabezado += "Turno: " + KCmb_Turnos.Text.ToString();

                        Estatus = true;
                    }
                }

                //  filtro folio de la recoleccion
                if (!String.IsNullOrEmpty(Txt_Folio_Recoleccion.Text))
                {
                    Obj_Rpt_Ventas.P_No_Recoleccion = String.Format("{0:0000000000}", Convert.ToDouble(Txt_Folio_Recoleccion.Text));

                    if (Estatus)
                        Leyenda_Encabezado += ", ";

                    Leyenda_Encabezado += "Folio del documento: " + Obj_Rpt_Ventas.P_No_Recoleccion;

                    Estatus = true;
                }

                //  filtro tipo de reporte
                if (RBtn_Cortes_Caja.Checked)
                {
                    Obj_Rpt_Ventas.P_Es_Corte_Arqueo = "CIERRE";//"RECOLECCION";
                }
                else if (RBtn_Arques.Checked)
                {
                    Obj_Rpt_Ventas.P_Es_Corte_Arqueo = "ARQUEO";
                    Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Arqueo();
                }
                else if (Rbt_Opc_Recoleccion.Checked)
                {
                    Obj_Rpt_Ventas.P_Es_Corte_Arqueo = "RECOLECCION";
                    Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Recoleciones();
                }

                //  datos generales
                //  se asignan las columnas a la tabla
                Dt_Datos_Generales.TableName = "Datos_Generales";

                Dt_Datos_Generales.Columns.Add("Usuario", typeof(string));
                Dt_Datos_Generales.Columns.Add("Periodo_Reporte", typeof(string));
                Dt_Datos_Generales.Columns.Add("Filtros", typeof(string)); 
                Dt_Datos_Generales.Columns.Add("Tipo_Reporte", typeof(string));

                var Registro = Dt_Datos_Generales.NewRow();
                Registro["Usuario"] = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Registro["Periodo_Reporte"] = Leyenda_Periodo;
                Registro["Filtros"] = Leyenda_Encabezado;
                Registro["Tipo_Reporte"] = Obj_Rpt_Ventas.P_Es_Corte_Arqueo;
                Dt_Datos_Generales.Rows.Add(Registro);

                //  se carga el dataset
                Ds_Resultados_Busqueda.Tables.Add(Dt_Datos_Generales);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Consultar_Informacion]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Ds_Resultados_Busqueda;
        }

        /// <summary>
        /// 
        /// </summary>
        private DataSet Rpt_Cortes()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.

            try
            {
                Grid_Resultado.DataSource = null;

                //Establecemos los filtros para realizar la búsqueda.
                if (KDtp_Fecha_Inicio.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                if (Dtp_Fecha_Fin.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(Dtp_Fecha_Fin.Value.Year
                        , Dtp_Fecha_Fin.Value.Month
                        , Dtp_Fecha_Fin.Value.Day, 23, 59, 59);

                if (KCmb_Caja.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();

                if (KCmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();

                if (!String.IsNullOrEmpty(Txt_Folio_Recoleccion.Text))
                    Obj_Rpt_Ventas.P_No_Recoleccion = String.Format("{0:0000000000}", Convert.ToDouble(Txt_Folio_Recoleccion.Text));

                Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Cortes_Arqueos_Concentrado();

                return Ds_Resultados_Busqueda;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Rpt_Cortes_Excel()
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();

            try
            {
                DataTable Resultados = Rpt_Cortes().Tables[0];

                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Archivos de Excel(*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  SE RENOMBRAN LAS COLUMNAS
                foreach (DataColumn Dc_Registro in Resultados.Columns)
                {
                    Dc_Registro.ColumnName = Dc_Registro.ColumnName.Replace('_', ' ');
                }

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName))
                    {
                        File.Delete(Sfd_Ruta_Archivo.FileName);
                    }

                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    string Filtros = string.Empty;

                    if (KCmb_Turnos.SelectedIndex > 0)
                    {
                        Filtros += "Turno: " + KCmb_Turnos.Text + "', ";
                    }

                    if (!string.IsNullOrEmpty(Txt_Folio_Recoleccion.Text))
                    {
                        Filtros += "Folio del Documento: " + Txt_Folio_Recoleccion.Text + ", ";
                    }

                    if (KCmb_Caja.SelectedIndex > 0)
                    {
                        Filtros += "Número de Caja: " + KCmb_Caja.Text + "', ";
                    }

                    Filtros = "Tipo del Documento: Corte de Caja, ";
                    Filtros = Filtros.Substring(0, Filtros.Length - 2);
                    
                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Cortes = Epc_Accesos.Workbook.Worksheets.Add("Concentrado por ticket de venta");

                        Cortes.Cells["A1"].Value = "Tesorería Municipal";
                        Cortes.Cells["A2"].Value = "Dirección de ingresos";
                        Cortes.Cells["A3"].Value = "Museo de las momias";
                        Cortes.Cells["A4"].Value = "Periodo: De " + KDtp_Fecha_Inicio.Value.ToLongDateString() + " al " + Dtp_Fecha_Fin.Value.ToLongDateString();
                        Cortes.Cells["A5"].Value = Filtros;

                        Cortes.Cells["A7"].Value = "Detalle de: Corte de Caja";

                        Cortes.Cells["A1:A1"].Style.Font.Bold = true;
                        Cortes.Cells["A3:A7"].Style.Font.Bold = true;

                        // Encabezados del reporte
                        Cortes.Cells["A1:T1"].Merge = true;
                        Cortes.Cells["A2:T2"].Merge = true;
                        Cortes.Cells["A3:T3"].Merge = true;
                        Cortes.Cells["A4:T4"].Merge = true;
                        Cortes.Cells["A5:T5"].Merge = true;
                        Cortes.Cells["A6:T6"].Merge = true;
                        Cortes.Cells["A7:T7"].Merge = true;

                        Cortes.Cells["A1:T1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A2:T2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A3:T3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A4:T4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A5:T5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A6:T6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A7:T7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Cortes.Cells["A1:T1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A2:T2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A3:T3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A4:T4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A5:T5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A6:T6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A7:T7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        // Se agrega columna de Resultado (Faltante o Sobrante).
                        Resultados.Columns.Add("Resultado", typeof(string));
                        Resultados.Columns["Resultado"].SetOrdinal(13);

                        // Se cambia el nombre de las columnas
                        Resultados.Columns[0].ColumnName = "Folio del documento";
                        Resultados.Columns[3].ColumnName = "No. Caja";
                        Resultados.Columns[5].ColumnName = "Efectivo en caja";
                        Resultados.Columns[8].ColumnName = "Tarjeta";
                        Resultados.Columns[9].ColumnName = "Recolecciones";
                        Resultados.Columns[10].ColumnName = "Total cobrado";
                        Resultados.Columns[14].ColumnName = "Importe";
                        Resultados.Columns[18].ColumnName = "Fecha y hora inicio de operaciones";
                        Resultados.Columns[19].ColumnName = "Fecha y hora fin de operaciones";

                        decimal Importe = 0;
                        for (int i = 0; i < Resultados.Rows.Count; i++)
                        {
                            Importe = Convert.ToDecimal(Resultados.Rows[i]["Importe"]);

                            if (Importe == 0)
                            {
                                Resultados.Rows[i]["Resultado"] = "CERO";
                            }
                            else if (Importe > 0)
                            {
                                Resultados.Rows[i]["Resultado"] = "Sobrante";
                            }
                            else
                            {
                                Resultados.Rows[i]["Resultado"] = "Faltante";
                            }
                        }

                        ExcelRangeBase Rango = Cortes.Cells["A8"].LoadFromDataTable(Resultados,
                            true, OfficeOpenXml.Table.TableStyles.Medium2);

                        Cortes.Cells[9, 6, Rango.End.Row, 15].Style.Numberformat.Format = "#,##0.00";
                        Cortes.Cells[9, 19, Rango.End.Row, 20].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                        int Filas = Rango.End.Row + 2;

                        //  Pie de página.
                        Cortes.Cells["A" + Filas.ToString()].Value = "Usuario Creó: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Cortes.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();
                        
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
        /// 
        /// </summary>
        private void Rpt_Arqueo_Excel()
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();

            try
            {
                DataTable Dt_Resultado = Consultar_Informacion().Tables[0];
                Grid_Resultado.DataSource = Dt_Resultado;

                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Archivos de Excel(*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  SE RENOMBRAN LAS COLUMNAS
                foreach (DataColumn Dc_Registro in Dt_Resultado.Columns)
                {
                    Dc_Registro.ColumnName = Dc_Registro.ColumnName.Replace('_', ' ');
                }


                //  se cambia el nombre de las columnas
                Dt_Resultado.Columns[0].ColumnName = "Folio del documento";
                Dt_Resultado.Columns[3].ColumnName = "No. Caja";
                Dt_Resultado.Columns[5].ColumnName = "Efectivo en caja";
                Dt_Resultado.Columns[8].ColumnName = "Tarjeta";
                Dt_Resultado.Columns[9].ColumnName = "Recolecciones";
                Dt_Resultado.Columns[10].ColumnName = "Total cobrado";
                Dt_Resultado.Columns[14].ColumnName = "Importe";
                Dt_Resultado.Columns[17].ColumnName = "Fecha y hora inicio de operaciones";

                Dt_Resultado.Columns.Remove("Fecha Hora Cierre");

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName))
                    {
                        File.Delete(Sfd_Ruta_Archivo.FileName);
                    }

                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    string Filtros = string.Empty;

                    if (KCmb_Turnos.SelectedIndex > 0)
                    {
                        Filtros += "Turno: " + KCmb_Turnos.Text + "', ";
                    }

                    if (!string.IsNullOrEmpty(Txt_Folio_Recoleccion.Text))
                    {
                        Filtros += "Folio del Documento: " + Txt_Folio_Recoleccion.Text + ", ";
                    }

                    if (KCmb_Caja.SelectedIndex > 0)
                    {
                        Filtros += "Número de Caja: " + KCmb_Caja.Text + "', ";
                    }

                    Filtros = "Tipo del Documento: Corte de Caja, ";
                    Filtros = Filtros.Substring(0, Filtros.Length - 2);

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Cortes = Epc_Accesos.Workbook.Worksheets.Add("Concentrado por ticket de venta");

                        Cortes.Cells["A1"].Value = "Tesorería Municipal";
                        Cortes.Cells["A2"].Value = "Dirección de ingresos";
                        Cortes.Cells["A3"].Value = "Museo de las momias";
                        Cortes.Cells["A4"].Value = "Periodo: De " + KDtp_Fecha_Inicio.Value.ToLongDateString() + " al " + Dtp_Fecha_Fin.Value.ToLongDateString();
                        Cortes.Cells["A5"].Value = Filtros;
                        Cortes.Cells["A7"].Value = "Detalle de: Arqueo";

                        Cortes.Cells["A1:A1"].Style.Font.Bold = true;
                        Cortes.Cells["A3:A7"].Style.Font.Bold = true;

                        // Encabezados del reporte
                        Cortes.Cells["A1:R1"].Merge = true;
                        Cortes.Cells["A2:R2"].Merge = true;
                        Cortes.Cells["A3:R3"].Merge = true;
                        Cortes.Cells["A4:R4"].Merge = true;
                        Cortes.Cells["A5:R5"].Merge = true;
                        Cortes.Cells["A6:R6"].Merge = true;
                        Cortes.Cells["A7:R7"].Merge = true;

                        Cortes.Cells["A1:R1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A2:R2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A3:R3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A4:R4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A5:R5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A6:R6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Cortes.Cells["A7:R7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Cortes.Cells["A1:R1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A2:R2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A3:R3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A4:R4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A5:R5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A6:R6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Cortes.Cells["A7:R7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        ExcelRangeBase Rango = Cortes.Cells["A8"].LoadFromDataTable(Dt_Resultado,
                            true, OfficeOpenXml.Table.TableStyles.Medium2);

                        Cortes.Cells[9, 4, Rango.End.Row, 4].Style.Numberformat.Format = "#,##0";
                        Cortes.Cells[9, 7, Rango.End.Row, 13].Style.Numberformat.Format = "#,##0.00";
                        Cortes.Cells[9, 15, Rango.End.Row, 15].Style.Numberformat.Format = "#,##0.00";
                        Cortes.Cells[9, 18, Rango.End.Row, 18].Style.Numberformat.Format = "dd/MM/yyyy HH:mm:ss";

                        int Filas = Rango.End.Row + 2;

                        //  Pie de página.
                        Cortes.Cells["A" + Filas.ToString()].Value = "Usuario Creó: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Cortes.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();

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
        private void Exportar_Excel_Recolecciones()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Datos_Generales = new DataTable();
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();

            try
            {
                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Excel files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;


                Ds_Resultados_Busqueda = Consultar_Informacion();
                Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables["Dt_Recoleccion_Arqueo"];

                //  datos generales
                Dt_Datos_Generales = Ds_Resultados_Busqueda.Tables["Datos_Generales"];
                //  recolecciones
                Dt_Consulta = Ds_Resultados_Busqueda.Tables["Dt_Recoleccion_Arqueo"];

                //  SE RENOMBRAN LAS COLUMNAS
                foreach (DataColumn Dc_Registro in Dt_Consulta.Columns)
                {
                    Dc_Registro.ColumnName = Dc_Registro.ColumnName.Replace('_', ' ');
                }


                //  se cambia el nombre de las columnas
                Dt_Consulta.Columns[0].ColumnName = "Folio del documento";
                Dt_Consulta.Columns[3].ColumnName = "No. Caja";
                Dt_Consulta.Columns[5].ColumnName = "Total recolectado";
                Dt_Consulta.Columns[17].ColumnName = "Monedas 0.50";
                Dt_Consulta.Columns[18].ColumnName = "Monedas 0.20";
                Dt_Consulta.Columns[19].ColumnName = "Monedas 0.10";
                Dt_Consulta.Columns[22].ColumnName = "Fecha y hora inicio de operaciones";

                Dt_Consulta.Columns.Remove("Fecha Cierre");

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

                        //*****************************************************************************************
                        Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las momias";
                        Detallado.Cells["A4"].Value = Dt_Datos_Generales.Rows[0][1].ToString();
                        Detallado.Cells["A5"].Value = Dt_Datos_Generales.Rows[0][2].ToString();

                        Detallado.Cells["A7"].Value = "Detalle de: Recolección";

                        Detallado.Cells["A1:A1"].Style.Font.Bold = true;
                        Detallado.Cells["A3:A7"].Style.Font.Bold = true;

                        // Encabezados del reporte
                        Detallado.Cells["A1:W1"].Merge = true;
                        Detallado.Cells["A2:W2"].Merge = true;
                        Detallado.Cells["A3:W3"].Merge = true;
                        Detallado.Cells["A4:W4"].Merge = true;
                        Detallado.Cells["A5:W5"].Merge = true;
                        Detallado.Cells["A6:W6"].Merge = true;
                        Detallado.Cells["A7:W7"].Merge = true;

                        Detallado.Cells["A1:W1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A2:W2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A3:W3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A4:W4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A5:W5"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A6:W6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A7:W7"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado.Cells["A1:W1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A2:W2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A3:W3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A4:W4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A5:W5"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A6:W6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A7:W7"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        //*****************************************************************************************
                        Int32 Filas = 8;
                        //  se carga el archivo
                        ExcelRangeBase Rango = Detallado.Cells["A" + Filas].LoadFromDataTable(Dt_Consulta, true, OfficeOpenXml.Table.TableStyles.Medium2);

                        ////  formato a las celdas 
                        Detallado.Cells[Filas, 4, Rango.End.Row, 4].Style.Numberformat.Format = "#,##0";
                        Detallado.Cells[Filas, 6, Rango.End.Row, 6].Style.Numberformat.Format = "#,##0.00";
                        Detallado.Cells[Filas, 7, Rango.End.Row, 20].Style.Numberformat.Format = "#,##0";
                        //*****************************************************************************************
                        Filas = Filas + Dt_Consulta.Rows.Count + 4;

                        //  pie de pagina
                        Detallado.Cells["A" + Filas.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                        Detallado.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();
                        //*****************************************************************************************

                        Rango.AutoFitColumns();
                        Epc_Accesos.Save();
                        //*****************************************************************************************
                    }
                    MessageBox.Show(this, "Exportacion exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Exportar_Excel_Concentrado_Ventas). Descripción: " + Ex.Message);
            }
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

            try
            {
                Grid_Resultado.DataSource = null;

                if (Rbt_Opc_Recoleccion.Checked == true)//      recoleccion
                {
                    Ds_Resultados_Busqueda = Consultar_Informacion();
                    Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables["Dt_Recoleccion_Arqueo"];
                }
                else if (RBtn_Cortes_Caja.Checked == true)//    corte
                {
                    Ds_Resultados_Busqueda = Rpt_Cortes();
                    Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables[0];
                }
                else if (RBtn_Arques.Checked == true)//         arqueo
                {
                    Ds_Resultados_Busqueda = Consultar_Informacion();    
                    Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables["Cortes_Caja"];
                }

                Formato_Tabla(Grid_Resultado);//Modificamos el formato de la tabla de om adeudosresultados de la búsqueda.
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
            try
            {
                if (Rbt_Opc_Recoleccion.Checked == true)
                {   
                    Exportar_Excel_Recolecciones();
                }
                else if (RBtn_Cortes_Caja.Checked == true)
                {
                    Rpt_Cortes_Excel();
                }
                else if (RBtn_Arques.Checked == true)
                {
                    Rpt_Arqueo_Excel();
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
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Datos_Generales = new DataTable();
            try
            {
                if (Rbt_Opc_Recoleccion.Checked == true)
                {
                    Ds_Resultados_Busqueda = Consultar_Informacion();
                    Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables["Dt_Recoleccion_Arqueo"];
                    Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Recoleccion.rpt");
                }
                else if(RBtn_Cortes_Caja.Checked == true)
                {
                    Ds_Resultados_Busqueda = Rpt_Cortes();
                    Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables[0];
                    Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Cortes_Caja.rpt");
                }
                else if (RBtn_Arques.Checked == true)
                {
                    Ds_Resultados_Busqueda = Consultar_Informacion();
                    Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables["Cortes_Caja"];
                    Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Arqueo.rpt");
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
                case "caja":
                    KCmb_Caja.SelectedIndex = 0;
                    break;
                case "turno":
                    KCmb_Turnos.SelectedIndex = 0;
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
            KCmb_Caja.Enabled = false;
            KCmb_Turnos.SelectedIndex = 0;
            Txt_Folio_Recoleccion.Text = String.Empty;
            KDtp_Fecha_Inicio.Value = DateTime.Now;
            KDtp_Fecha_Inicio.Checked = false;
            KDtp_Fecha_Inicio.Invalidate();

            Grid_Resultado.DataSource = new DataTable();
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

                        if (Ruta.Contains("Cr_Rpt_Cortes_Caja.rpt") || Ruta.Contains("Cr_Rpt_Arqueo.rpt"))
                        {
                            ParameterFieldDefinitions Parametros = Reporte.DataDefinition.ParameterFields;
                            ParameterFieldDefinition Parametro;
                            ParameterDiscreteValue Valor = new ParameterDiscreteValue();
                            ParameterValues Valores = new ParameterValues();

                            List<object[]> objParametros = new List<object[]>();

                            if (Ruta.Contains("Cr_Rpt_Cortes_Caja.rpt"))
                            {
                                objParametros.Add(new object[] { "Corte de Caja", "Tipo" });
                            }
                            else if (Ruta.Contains("Cr_Rpt_Arqueo.rpt"))
                            {
                                objParametros.Add(new object[] { "Arqueo", "Tipo" });
                            }

                            objParametros.Add(new object[] { KDtp_Fecha_Inicio.Value, "Periodo_Inicial" });
                            objParametros.Add(new object[] { Dtp_Fecha_Fin.Value, "Periodo_Final" });
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

                            if (!string.IsNullOrEmpty(Txt_Folio_Recoleccion.Text))
                            {
                                objParametros.Add(new object[] { Txt_Folio_Recoleccion.Text, "Folio" });
                            }
                            else
                            {
                                objParametros.Add(new object[] { string.Empty, "Folio" });
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

        #region RadioButton
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
        private void Rbt_Opc_Recoleccion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Rbt_Opc_Recoleccion.Checked)
                {
                    RBtn_Cortes_Caja.Checked = false;
                    RBtn_Arques.Checked = false;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: Metodo(Rbt_Opc_Recoleccion_CheckedChanged). Descripción:" + Ex.Message);
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
        private void RBtn_Cortes_Caja_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (RBtn_Cortes_Caja.Checked)
                {
                    Rbt_Opc_Recoleccion.Checked = false;
                    RBtn_Arques.Checked = false;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: Metodo(RBtn_Cortes_Caja_CheckedChanged). Descripción:" + Ex.Message);
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
        private void RBtn_Arques_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (RBtn_Arques.Checked)
                {
                    Rbt_Opc_Recoleccion.Checked = false;
                    RBtn_Cortes_Caja.Checked = false;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: Metodo(RBtn_Arques_CheckedChanged). Descripción:" + Ex.Message);
            }
        }
        #endregion
    }
}
