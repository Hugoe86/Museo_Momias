using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using ERP_BASE.Paginas.Paginas_Generales;
using Catalogos.Turnos.Negocio;
using Reportes.Ingresos.Negocio;
using Reportes.Ventas.Negocio;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rep_Anual : Form
    {
        private DataTable Dt_Productos;
        delegate void SetResultadosCallBack(DataTable Res);
        delegate void HidePanelCallBack();

        private void SetResultados(DataTable Res)
        {
            if (Grd_Resultados.InvokeRequired)
            {
                SetResultadosCallBack T = new SetResultadosCallBack(SetResultados);
                this.Invoke(T, new object[] { Res });
            }
            else
            {
                int Columnas = Res.Columns.Count - 1;
                int Contador = 0;

                for (int f = 0; f < Res.Rows.Count; f++)
                {
                    Contador = 0;

                    for (int c = 1; c < Res.Columns.Count; c++)
                    {
                        if (Res.Rows[f][c] == DBNull.Value)
                        {
                            Contador++;
                        }
                    }

                    if (Contador == Columnas)
                    {
                        Res.Rows.RemoveAt(f--);
                    }
                }

                Grd_Resultados.DataSource = Res;

                Btn_Buscar.Enabled = true;
                Btn_Exportar_PDF.Enabled = true;
                Btn_Exportar_Excel.Enabled = true;

                Pnl_Mensaje.Hide();
            }
        }

        private void HidePanel()
        {
            if (Pnl_Mensaje.InvokeRequired)
            {
                HidePanelCallBack H = new HidePanelCallBack(HidePanel);
                this.Invoke(H);
            }
            else
            {
                Pnl_Mensaje.Hide();
            }
        }

        public Frm_Rep_Anual()
        {
            InitializeComponent();
        }

        #region METODOS
        /// <summary>
        /// Carga los Turnos.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
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
        /// Carga los Turnos.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Turnos()
        {
            DataTable Combos;
            DataRow Fila;

            try
            {
                // Se consultan los Turnos del Catálogo de Productos
                Cls_Cat_Turnos_Negocio Turnos = new Cls_Cat_Turnos_Negocio();

                Combos = Turnos.Consultar_Turnos();
                Fila = Combos.NewRow();
                Fila[Cat_Turnos.Campo_Turno_ID] = string.Empty;
                Fila[Cat_Turnos.Campo_Nombre] = "SELECCIONE";
                Combos.Rows.InsertAt(Fila, 0);

                Cmb_Turno.DataSource = Combos.Copy();
                Cmb_Turno.DisplayMember = Cat_Turnos.Campo_Nombre;
                Cmb_Turno.ValueMember = Cat_Turnos.Campo_Turno_ID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Carga las Cajas.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Cajas()
        {
            DataTable Combos;
            
            try
            {
                Cls_Cat_Cajas_Negocio Cajas = new Cls_Cat_Cajas_Negocio();

                Cajas.P_Estatus = "ACTIVO";

                Combos = Cajas.Consultar_Caja();
                var Aux = (from C in Combos.AsEnumerable()
                           select new
                           {
                               Caja_ID = C.Field<string>("Caja_ID"),
                               Numero_Caja = C.Field<decimal>("Numero_Caja").ToString()
                           }).ToList();

                Aux.Insert(0, new { Caja_ID = string.Empty, Numero_Caja = "SELECCIONE" });

                Cmb_Numero_Caja.DataSource = Aux;
                Cmb_Numero_Caja.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
                Cmb_Numero_Caja.ValueMember = Cat_Cajas.Campo_Caja_ID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Muestra la información de las Tarifas en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Recaudacion_Tarifa(object Filtros)
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos =
                    (Cls_Rep_Ingresos_Negocio)Filtros;

                DataSet Resultados = Neg_Ingresos.Recaudación_Tarifa();

                Limpiar_Resultados(Resultados);
                SetResultados(Resultados.Tables[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                HidePanel();
            }
        }

        /// <summary>
        /// Muestra la Información de la Recaudación por Tarifa en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Recaudacion_Acumulado_Tarifa(object Filtros)
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos;
                DataSet Resultados;
                DataRow Totales;

                Neg_Ingresos = (Cls_Rep_Ingresos_Negocio)Filtros;
                
                Resultados = Neg_Ingresos.Recaudacion_Acumulado_Tarifa();
                Limpiar_Resultados(Resultados);

                Totales = Resultados.Tables[0].NewRow();
                Totales[0] = "Totales";

                // Se realiza la suma de los Totales por Año.
                for (int i = 1; i < Resultados.Tables[0].Columns.Count; i++)
                {
                    decimal Total = (from Aux in Resultados.Tables[0].AsEnumerable()
                                     where Aux.Field<decimal?>(i).HasValue
                                     select Aux.Field<decimal>(i)).Sum();

                    Totales[i] = Total;
                }

                Resultados.Tables[0].Rows.Add(Totales);

                SetResultados(Resultados.Tables[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                HidePanel();
            }
        }

        /// <summary>
        /// Muestra la Información de la Visitanes por Tarifa en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Recaudacion_Acumulado_Visitantes(object Filtros)
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos;
                DataSet Resultados;
                DataRow Totales;

                Neg_Ingresos = (Cls_Rep_Ingresos_Negocio)Filtros;
                Resultados = Neg_Ingresos.Recaudacion_Acumulado_Visitantes();

                Limpiar_Resultados(Resultados);

                Totales = Resultados.Tables[0].NewRow();
                Totales[0] = "Totales";

                // Se realiza la suma de los Totales por Año.
                for (int i = 1; i < Resultados.Tables[0].Columns.Count; i++)
                {
                    Int64 Total = (from Aux in Resultados.Tables[0].AsEnumerable()
                                   where Aux.Field<Int64?>(i).HasValue
                                   select Aux.Field<Int64>(i)).Sum();

                    Totales[i] = Total;
                }

                Resultados.Tables[0].Rows.Add(Totales);
                
                SetResultados(Resultados.Tables[0]);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                HidePanel();
            }
        }

        /// <summary>
        /// Muestra la Información del Concentrado de Recaudación y Visitantes en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Concentrado(object Filtros)
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos =
                    (Cls_Rep_Ingresos_Negocio)Filtros;

                DataTable Resultados = Neg_Ingresos.Concentrado();

                SetResultados(Resultados);
                //Grd_Resultados.DataSource = Neg_Ingresos.Concentrado();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                HidePanel();
            }
        }

        /// <summary>
        /// Genera la Información de los Filtros de Búsqueda.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private object[] Filtros()
        {
            Cls_Rep_Ingresos_Negocio Aux = new Cls_Rep_Ingresos_Negocio();

            string Res = string.Empty;
            int Anio_Inicial = string.IsNullOrEmpty(Cmb_Anio_Inicial.Text) ? 0 : int.Parse(Cmb_Anio_Inicial.Text);
            int Anio_Final = string.IsNullOrEmpty(Cmb_Anio_Final.Text) ? 0 : int.Parse(Cmb_Anio_Final.Text);

            if (Anio_Inicial > Anio_Final)
            {
                throw new Exception("El Año Inicial no puede ser Mayor al Año Final");
            }

            Aux.P_Anio_Inicio = Anio_Inicial;
            Aux.P_Anio_Final = Anio_Final;

            if (Cmb_Turno.SelectedIndex > 0)
            {
                if (Res != null) { Res += "Turno: " + Cmb_Turno.Text + ", "; }
                Aux.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();
            }

            if (Cmb_Numero_Caja.SelectedIndex > 0)
            {
                if (Res != null) { Res += "No. Caja: " + Cmb_Numero_Caja.Text + ", "; }
                Aux.P_No_Caja = Cmb_Numero_Caja.SelectedValue.ToString();
            }

            if (Cmb_Museo.SelectedIndex > 0)
            {
                if (Res != null) { Res += "Museo: " + Cmb_Museo.Text + ", "; }
                Aux.P_Museo_ID = Cmb_Museo.Text == "MUSEO MOMIAS" ? "00001" : "00002";
            }

            if (Cmb_Lugar_Venta.SelectedIndex > 0)
            {
                if (Res != null) { Res += "Lugar de Venta: " + Cmb_Lugar_Venta.Text + ", "; }
                Aux.P_Lugar_Venta = Cmb_Lugar_Venta.Text;
            }

            if (Cmb_Producto.SelectedIndex > 0)
            {
                if (Res != null) { Res += "Tarifa: " + Cmb_Producto.Text + ", "; }
                Aux.P_Tarifa_Id = Cmb_Producto.SelectedValue.ToString();
            }

            if (Cmb_Tipo_Reporte.SelectedIndex > 0)
            {
                if (Res != null) { Res += "Tipo: " + Cmb_Tipo_Reporte.Text + ", "; }
            }

            if (Res != string.Empty) { Res = Res.Substring(0, Res.LastIndexOf(",")); }
            return new object[] { Aux, Res };
        }

        /// <summary>
        /// Limpia el campo cuando no existe una tarifa en una Año.
        /// </summary>
        /// <param name="Resultados"></param>
        private void Limpiar_Resultados(DataSet Resultados)
        {
            try
            {
                for (int i = 0; i < Resultados.Tables[0].Rows.Count; i++)
                {
                    for (int j = 1; j < Resultados.Tables[0].Columns.Count; j++)
                    {
                        string Categoria = Resultados.Tables[0].Rows[i][0].ToString();
                        int Anio = int.Parse(Resultados.Tables[0].Columns[j].ColumnName);

                        var Aux = from P in Resultados.Tables[1].AsEnumerable()
                                  where P.Field<string>("Nombre") == Categoria &&
                                  P.Field<int>("Anio") == Anio
                                  select P;

                        if (!Aux.Any())
                        {
                            Resultados.Tables[0].Rows[i][j] = DBNull.Value;
                        }
                    }
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
        private void Generar_PDF()
        {
            try
            {
                SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
                Sfd_Ruta_Archivo.Filter = "PDF(*.pdf)|*.pdf";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // Validación a la Ruta del Archivo.
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {

                    using (FileStream fs = new FileStream(Sfd_Ruta_Archivo.FileName, FileMode.Create))
                    {
                        DataTable Res = Grd_Resultados.DataSource as DataTable; // Se utilizan los datos del DataTable.
                        Document doc = new Document(PageSize.LETTER);
                        doc.SetMargins(doc.LeftMargin, doc.RightMargin, doc.TopMargin + 50, doc.BottomMargin);
                        PdfWriter PDF = PdfWriter.GetInstance(doc, fs);

                        // Se agrega el Encabezado y Pie de Página.
                        PageEventHandler evt = new PageEventHandler()
                        {
                            Anio_Inicio = int.Parse(Cmb_Anio_Inicial.Text),
                            Anio_Fin = int.Parse(Cmb_Anio_Final.Text),
                            Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario,
                            Posicion_Encabezado = 780,
                            Parametros = Filtros()[1].ToString()
                        };

                        PDF.PageEvent = evt;

                        doc.Open();

                        PdfPTable table = new PdfPTable(Res.Columns.Count);
                        float factor = 250 / 50;
                        float[] widths = new float[Res.Columns.Count];

                        float max = (from A in Res.AsEnumerable()
                                     select A.Field<string>(0).Length).Max();

                        widths[0] = max * factor;
                        for (int i = 1; i < widths.Length; i++) { widths[i] = 55.0f; }
                        table.SetWidths(widths);

                        // Options: Element.ALIGN_LEFT (or 0), Element.ALIGN_CENTER (1), Element.ALIGN_RIGHT (2).
                        table.HorizontalAlignment = Element.ALIGN_CENTER;

                        // Fuente para el Encabezado.
                        iTextSharp.text.Font fnt_Encabezado = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 6,
                                iTextSharp.text.Font.BOLD));

                        // Fuente para el Encabezado.
                        iTextSharp.text.Font fnt_Encabezados = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 5,
                                iTextSharp.text.Font.BOLD));

                        // Fuente para el Contenido.
                        iTextSharp.text.Font fnt = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 5,
                                iTextSharp.text.Font.NORMAL));

                        // Encabezado.
                        PdfPCell head = new PdfPCell(new Phrase(Cmb_Tipo_Reporte.Text,
                                fnt_Encabezados))
                                {
                                    Colspan = Res.Columns.Count,
                                    BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY,
                                    HorizontalAlignment = Element.ALIGN_CENTER
                                };

                        table.AddCell(head);

                        // Se imprimen los Encabezados.
                        foreach (DataColumn Column in Res.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(Column.ColumnName,
                                fnt_Encabezados));

                            if (Column.Ordinal != 0) { cell.HorizontalAlignment = Element.ALIGN_CENTER; }

                            table.AddCell(cell);
                        }

                        table.HeaderRows = 1;

                        // Se generan los resultados.
                        for (int i = 0; i < Res.Rows.Count; i++)
                        {
                            foreach (DataColumn Column in Res.Columns)
                            {
                                string Con = Res.Rows[i][Column].ToString();

                                if (Cmb_Tipo_Reporte.Text.Equals("Concentrado") &&
                                    Column.Ordinal > 0)
                                {
                                    if (i == 1)
                                        Con = Convert.ToInt32(Res.Rows[i][Column]).ToString("D");
                                    else if (i == 0)
                                        Con = Convert.ToInt32(Res.Rows[i][Column]).ToString("C")
                                            .Replace("$", "");
                                }

                                if ((Cmb_Tipo_Reporte.SelectedIndex == 1 ||
                                    Cmb_Tipo_Reporte.SelectedIndex == 2) &&
                                    Column.Ordinal > 0)
                                {
                                    if (Res.Rows[i][Column] != DBNull.Value)
                                    {
                                        Con = Convert.ToInt32(Res.Rows[i][Column]).ToString("C")
                                            .Replace("$", "");
                                    }
                                    else
                                    {
                                        Con = string.Empty;
                                    }
                                }

                                PdfPCell cell = new PdfPCell(new Phrase(Con,
                                    fnt));

                                if (Column.Ordinal != 0)
                                {
                                    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                }

                                table.AddCell(cell);
                            }
                        }

                        doc.Add(table);

                        if (Cmb_Tipo_Reporte.SelectedIndex == 2 ||
                            Cmb_Tipo_Reporte.SelectedIndex == 3)
                        {
                            PdfPTable Tabla_Grafica__ = new PdfPTable(2);
                            for (int i = 1; i < Res.Columns.Count; i++)
                            {
                                var Aux = new DataTable();

                                if (Cmb_Tipo_Reporte.SelectedIndex == 2)
                                {
                                    Aux = (from P in Res.AsEnumerable()
                                           where P.Field<decimal?>(i).HasValue
                                           select P).CopyToDataTable();
                                }

                                if (Cmb_Tipo_Reporte.SelectedIndex == 3)
                                {
                                    Aux = (from P in Res.AsEnumerable()
                                           where P.Field<Int64?>(i).HasValue
                                           select P).CopyToDataTable();
                                }

                                string[] SeriesArray = new string[Aux.Rows.Count];
                                decimal[] PointsArray = new decimal[Aux.Rows.Count];

                                for (int j = 0; j < Aux.Rows.Count; j++)
                                {
                                    SeriesArray[j] = Aux.Rows[j][0].ToString();
                                    PointsArray[j] = Convert.ToDecimal(Aux.Rows[j][i]);
                                }

                                this.Chart.Titles.Clear();
                                this.Chart.Titles.Add(Res.Columns[i].ColumnName);

                                this.Chart.Series.Clear();
                                for (int j = 0; j < Aux.Rows.Count; j++)
                                {
                                    // Aqui se agregan las series o Categorias.
                                    Series series = this.Chart.Series.Add(SeriesArray[j]);
                                    // Aqui se agregan los Valores.
                                    series.Points.Add((int)PointsArray[j]);
                                }

                                Chart.ChartAreas[0].RecalculateAxesScale();
                                Chart.Update();

                                MemoryStream ms = new MemoryStream();
                                this.Chart.SaveImage(ms, ChartImageFormat.Png);
                                iTextSharp.text.Image ITx_Chart_Imagen = iTextSharp.text.Image.GetInstance(ms.GetBuffer());

                                PdfPCell Celda_Grafica_ = new PdfPCell();

                                float[] Tamaño_Grafico_ = new float[1];
                                Tamaño_Grafico_[0] = 250;

                                Tabla_Grafica__.SetWidths(new float[] { 250, 250 });
                                //Tabla_Grafica__.WidthPercentage = 45;

                                Celda_Grafica_.Image = ITx_Chart_Imagen;
                                Celda_Grafica_.HorizontalAlignment = Element.ALIGN_CENTER;
                                Celda_Grafica_.Border = 0;
                                Tabla_Grafica__.AddCell(Celda_Grafica_);
                            }

                            if (Res.Columns.Count % 2 == 0)
                            {
                                Tabla_Grafica__.AddCell(new PdfPCell() { Border = 0 });
                            }

                            doc.Add(Tabla_Grafica__);
                        }

                        doc.Close();
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

        private void Generar_Excel()
        { 
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_General = Grd_Resultados.DataSource as DataTable;

            try
            {
                Dt_General.TableName = "Padre";
                if (Cmb_Tipo_Reporte.SelectedIndex == 2 ||
                    Cmb_Tipo_Reporte.SelectedIndex == 3)
                {
                    Dt_General.Rows.RemoveAt(Dt_General.Rows.Count - 1);
                }

                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Excel (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName)) File.Delete(Sfd_Ruta_Archivo.FileName);
                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    using (ExcelPackage Anual = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Anual.Workbook.Worksheets.Add("Analisis_Anual");
                        string Letra_Fin = ((char)(65 + Dt_General.Columns.Count - 1)).ToString();
                        string EFiltros = (string)Filtros()[1];

                        Detallado.Cells["A1"].Value = "Tesorería Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las Momias";
                        Detallado.Cells["A4"].Value = "Periodo: De " + Cmb_Anio_Inicial.Text + " al " + Cmb_Anio_Final.Text;
                        Detallado.Cells["A5"].Value = EFiltros;

                        Detallado.Cells["A1:" + Letra_Fin + "5"].Style.Font.Bold = true;

                        // Encabezados del reporte
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

                        // Se carga la información del DataTable en la Hoja de Excel.
                        ExcelRangeBase Rango = Detallado.Cells["A7"].LoadFromDataTable(Dt_General,
                                                       true, OfficeOpenXml.Table.TableStyles.Medium2);

                        // Se generan los Totales;
                        if (Cmb_Tipo_Reporte.SelectedIndex == 2 ||
                            Cmb_Tipo_Reporte.SelectedIndex == 3)
                        {
                            int C = (int)'A';
                            for (int i = 1; i < Dt_General.Columns.Count; i++)
                            {
                                string Column = Dt_General.Columns[i].ColumnName;
                                string cell = (char)(C + i) + (Rango.End.Row + 1).ToString();

                                Detallado.Cells[cell].Formula = "SUM(Padre[" + Column + "])";
                            }
                        }

                        if (Cmb_Tipo_Reporte.SelectedIndex == 1 ||
                                Cmb_Tipo_Reporte.SelectedIndex == 2)
                        {
                            Detallado.Cells[8, 1, Rango.End.Row + 1, Rango.End.Column]
                            .Style.Numberformat.Format = "#,##0.00";
                        }

                        if (Cmb_Tipo_Reporte.Text.Equals("Concentrado"))
                        {
                            Detallado.Cells[Rango.End.Row - 1, 1, Rango.End.Row - 1, Rango.End.Column]
                                .Style.Numberformat.Format = "#,##0.00";
                        }

                        Rango.AutoFitColumns();

                        int Fila = Rango.End.Row + 1;


                        //  generacion de graficas
                        if (Cmb_Tipo_Reporte.SelectedIndex == 2 ||
                            Cmb_Tipo_Reporte.SelectedIndex == 3)
                        {
                            int Letter = (int)'B';
                            for (int i = 1; i < Dt_General.Columns.Count; i++)
                            {
                                string Nombre = Dt_General.Columns[i].ColumnName;
                                ExcelWorksheet Graph = Anual.Workbook.Worksheets.Add(Nombre);

                                var chart = Graph.Drawings.AddChart(Nombre,
                                OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);

                                chart.SetPosition(0, 0, 0, 0);
                                chart.SetSize(1280, 800);

                                for (int j = 8; j <= Rango.End.Row; j++)
                                {
                                    int Column = i + 1;
                                    if (Detallado.Cells[j, Column, j, Column].Value != null)
                                    {
                                        string Cell = ((char)Letter).ToString();
                                        string Adress = "Analisis_Anual!$" + Cell + "$" + j + ":$"
                                            + Cell + "$" + j;

                                        chart.Series.Add(Adress,
                                            "Analisis_Anual!$" + Cell + "$7:$" + Cell + "$7")
                                            .Header = Detallado.Cells["A" + j].Value.ToString();
                                    }
                                }

                                chart.Title.Text = "Análisis Anual " + Nombre;
                                Letter++;
                            }
                        }

                        Anual.Save();
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

        /// <summary>
        /// Punto de Entrada al Cargar la Pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Frm_Rep_Anual_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Productos();
                Cargar_Turnos();
                Cargar_Cajas();

                for (int i = DateTime.Now.Year; i >= 2009; i--)
                {
                    Cmb_Anio_Inicial.Items.Add(i);
                    Cmb_Anio_Final.Items.Add(i);
                    Cmb_Anio.Items.Add(i);
                }

                Cmb_Anio.Items.Insert(0, "SELECCIONE");

                Cmb_Anio.SelectedIndex = 0;
                Cmb_Anio_Inicial.SelectedIndex = 0;
                Cmb_Anio_Final.SelectedIndex = 0;
                Cmb_Tipo_Reporte.SelectedIndex = 0;
                Cmb_Numero_Caja.SelectedIndex = 0;
                Cmb_Turno.SelectedIndex = 0;
                Cmb_Museo.SelectedIndex = 0;
                Cmb_Lugar_Venta.SelectedIndex = 0;
                
                Pnl_Mensaje.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador del evento click del botón buscar: llamar al método que consulta la información y 
        /// carga el resultado en el grid
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Rep_Ingresos_Negocio RFiltros;
                Thread TBusqueda;
                
                // Se utiliza para limpiar los Resultados en pantalla.
                Grd_Resultados.DataSource = null;

                RFiltros = (Cls_Rep_Ingresos_Negocio)Filtros()[0];

                // Se valida la opción del Tipo de Reporte.
                switch (Cmb_Tipo_Reporte.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("Debe Seleccionar un Tipo de Reporte.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;

                    case 1:
                        TBusqueda = new Thread(new ParameterizedThreadStart(
                            Recaudacion_Tarifa));
                        TBusqueda.Start(RFiltros);

                        Pnl_Mensaje.Show();
                        break;

                    case 2:
                        TBusqueda = new Thread(new ParameterizedThreadStart(
                            Recaudacion_Acumulado_Tarifa));
                        TBusqueda.Start(RFiltros);

                        Btn_Buscar.Enabled = false;
                        Btn_Exportar_PDF.Enabled = false;
                        Btn_Exportar_Excel.Enabled = false;
                        Pnl_Mensaje.Show();
                        break;

                    case 3:
                        TBusqueda = new Thread(new ParameterizedThreadStart(
                            Recaudacion_Acumulado_Visitantes));
                        TBusqueda.Start(RFiltros);

                        Btn_Buscar.Enabled = false;
                        Btn_Exportar_PDF.Enabled = false;
                        Btn_Exportar_Excel.Enabled = false;
                        Pnl_Mensaje.Show();
                        break;

                    case 4:
                        TBusqueda = new Thread(new ParameterizedThreadStart(
                            Concentrado));
                        TBusqueda.Start(RFiltros);

                        Btn_Buscar.Enabled = false;
                        Btn_Exportar_PDF.Enabled = false;
                        Btn_Exportar_Excel.Enabled = false;
                        Pnl_Mensaje.Show();
                        break;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Buscar]", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Manejador del evento click del botón exportar PDF: llamar al método que muestra el reporte
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                Generar_PDF();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Exportar]", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Exporta la información a Excel.
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>20 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Generar_Excel();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Exportar]",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las Tarifas Correspondientes al Año Seleccionado.
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>20 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cmb_Tipo_Reporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            Btn_Exportar_PDF.Enabled = false;
            Btn_Exportar_Excel.Enabled = false;
        }

        /// <summary>
        /// Inhabilita los Botones de PDF y Excel cuando se selecciona un tipo de reporte.
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>20 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
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
        #endregion

        private void Grd_Resultados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (Cmb_Tipo_Reporte.Text.Equals("Concentrado"))
                {
                    if (e.RowIndex == 1)
                    {
                        e.Value = Convert.ToInt32(e.Value).ToString("D");
                        e.FormattingApplied = true;
                    }
                }
            }
            catch (Exception)
            { 
            
            }
        }
    }
}
