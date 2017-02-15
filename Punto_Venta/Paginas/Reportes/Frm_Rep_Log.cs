using System;
using System.Data;
using System.Windows.Forms;
using Erp_Apl_Usuarios.Negocio;
using Erp.Constantes;
using BitacorasAutomaticas.Tablas.Negocio;
using CarlosAg.ExcelXmlWriter;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rep_Log : Form
    {
        public Frm_Rep_Log()
        {
            InitializeComponent();
        }

        #region METODOS

        ///*******************************************************************************************************
        /// <summary>
        /// Obtiene un listado de registros del log y lo carga en el grid resultado
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Consulta_Log()
        {
            try
            {
                Cls_Tablas_Negocio Neg_Tablas = new Cls_Tablas_Negocio();
                Neg_Tablas.P_Nombre_Tabla = Cmb_Tabla.Text;
                // si hay un tipo de operación seleccionada, asignar
                if (Cmb_Operacion.SelectedIndex > 0)
                {
                    Neg_Tablas.P_Operacion = Cmb_Operacion.Text;
                }
                // si hay un usuario seleccionado, asignar
                if (Cmb_Usuario.SelectedIndex > 0)
                {
                    Neg_Tablas.P_Usuario = Cmb_Usuario.Text;
                }
                // validar selección de fecha inicial
                if (true == Dtp_Fecha_Inicio.Checked)
                {
                    Neg_Tablas.P_Fecha_Inicio = Dtp_Fecha_Inicio.Value;
                }
                // validar selección de fecha final
                if (true == Dtp_Fecha_Termino.Checked)
                {
                    Neg_Tablas.P_Fecha_Final = Dtp_Fecha_Termino.Value;
                }
                DataTable Dt_Resultado = Neg_Tablas.Consultar_Bitacora();
                // si la primera columna es el id de bitácora, quitarlo
                if (Dt_Resultado != null && Dt_Resultado.Columns.Count > 0 && Dt_Resultado.Columns[0].ColumnName.StartsWith("btc_"))
                {
                    Dt_Resultado.Columns.RemoveAt(0);
                }

                Grd_Resultado.DataSource = Dt_Resultado;
            }
            catch (Exception Ex)
            {

                throw new Exception("[Consulta_Log]: " + Ex.Message);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        ///  Método que exporta la tabla de resultados en el grid a PDF
        /// </summary>
        /// <param name="Documento">Objeto al cúal agregaremos el contenido del reporte</param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>27-nov-2013</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public void Exportar_Datos_PDF(iTextSharp.text.Document Documento)
        {
            bool Es_Footer = false;
            try
            {
                iTextSharp.text.Phrase _frase = null;
                iTextSharp.text.pdf.PdfPCell _celda = null;

                iTextSharp.text.FontFactory.RegisterDirectory(@"C:\Windows\Fonts");
                //Creamos el objeto de tipo tabla para almacenar el resultado de la búsqueda. 
                iTextSharp.text.pdf.PdfPTable Rpt_Tabla = new iTextSharp.text.pdf.PdfPTable(Grd_Resultado.Columns.Count);
                //Obtenemos y establecemos el formato de las columnas de la tabla.
                float[] Ancho_Cabeceras = Obtener_Tamano_Columnas(Grd_Resultado);
                //Creamos y definimos algunas propiedades que tendrá la fuente que se aplicara a las celdas de la tabla de resultados.
                iTextSharp.text.Font Fuente_Tabla_Contenido = iTextSharp.text.FontFactory.GetFont("Courier New", 7, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font Fuente_Tabla_Footer = iTextSharp.text.FontFactory.GetFont("Courier New", 9, iTextSharp.text.Font.BOLD);

                //Establecemos el formato que tendrá la tabla que mostrara el resultado de la búsqueda según el movimiento consultado.
                Rpt_Tabla.DefaultCell.Padding = 3;
                Rpt_Tabla.SetWidths(Ancho_Cabeceras);
                Rpt_Tabla.WidthPercentage = 100;
                Rpt_Tabla.DefaultCell.BorderWidth = 2;
                Rpt_Tabla.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                Rpt_Tabla.HeaderRows = 1;

                // Creamos y establecemos el formato que tendrá el titulo del reporte.
                iTextSharp.text.Paragraph Titulo = new iTextSharp.text.Paragraph();
                Titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Titulo.Font = iTextSharp.text.FontFactory.GetFont("Consolas");
                Titulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Titulo.Font.Size = 14;
                Titulo.Add("Museo de las Momias de Guanajuato");

                // Creamos y establecemos el formato que tendrá el subtitulo del reporte.
                iTextSharp.text.Paragraph Subtitulo = new iTextSharp.text.Paragraph();
                Subtitulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Subtitulo.Font = iTextSharp.text.FontFactory.GetFont("Consolas");
                Subtitulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Subtitulo.Font.Size = 12;
                Subtitulo.Add("Log de eventos en " + Cmb_Tabla.Text.ToString()
                    + ": " + (Dtp_Fecha_Inicio.Checked.Equals(true) ? Dtp_Fecha_Inicio.Text : "")
                    + " - " + (Dtp_Fecha_Termino.Checked.Equals(true) ? Dtp_Fecha_Termino.Text : "")); // rango de fechas del reporte
                // fecha actual
                iTextSharp.text.Phrase Fecha = new iTextSharp.text.Phrase(DateTime.Today.ToString("dd-MMM-yyyy"));
                Fecha.Font.Size = 11;

                float[] Anchura_Tabla_Subtitulo = { 90, 10 };
                // subtitulo con fecha en una tabla sin bordes (misma línea)
                iTextSharp.text.pdf.PdfPTable Tabla_Subtitulo = new iTextSharp.text.pdf.PdfPTable(Anchura_Tabla_Subtitulo);
                Tabla_Subtitulo.WidthPercentage = 100;
                Tabla_Subtitulo.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Subtitulo.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                Tabla_Subtitulo.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                Tabla_Subtitulo.AddCell(Subtitulo);
                Tabla_Subtitulo.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                Tabla_Subtitulo.AddCell(Fecha);


                //Agregamos los nombres de las columnas de la tabla que se imprimira en el reporte.
                Array.ForEach(Grd_Resultado.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    var cabecera = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(columna.HeaderText, iTextSharp.text.FontFactory.GetFont("Consolas", 8, iTextSharp.text.Font.BOLD)));
                    cabecera.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cabecera.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    Rpt_Tabla.AddCell(cabecera);
                });
                //Modificamos el tipo de border que tendrá las celdas que mostraran los datos, con respécto al borde que tiene asignado la cabeceras de las columnas.
                Rpt_Tabla.DefaultCell.BorderWidth = 1;

                //Agreamos el resultado de la búsqueda de movimientos al tabla que se enviara al reporte.
                Array.ForEach(Grd_Resultado.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                {
                    if (fila.Cells[0] != null)
                    {
                        if (fila.Cells[0].Value != null)
                        {
                            if (fila.Cells[0].Value.ToString().ToLower().Contains("totales"))
                                Es_Footer = true;
                            else
                                Es_Footer = false;
                        }
                        else Es_Footer = false;
                    }
                    else Es_Footer = false;

                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                    {
                        string texto = string.Empty;

                        if (celda.Value != null)
                        {
                            if (celda.ValueType.Name.Equals("DateTime"))
                                texto = string.Format("{0:dd MMM yyyy}", celda.Value);
                            else if (celda.ValueType.Name.Equals("Decimal") && !celda.OwningColumn.HeaderText.Equals("NoCaja"))
                                texto = string.Format("{0:n}", celda.Value);
                            else
                                texto = celda.Value.ToString();
                        }

                        if (Es_Footer)
                        {
                            //Establecemos el formato que llevaran las celdas de totales de la tabla del reporte.
                            _frase = new iTextSharp.text.Phrase(texto, Fuente_Tabla_Footer);
                            _celda = new iTextSharp.text.pdf.PdfPCell(_frase);
                            _celda.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        }
                        else
                        {
                            //Establecemos el formato que llevaran las celdas de contenido de la tabla del reporte.
                            _frase = new iTextSharp.text.Phrase(texto, Fuente_Tabla_Contenido);
                            _celda = new iTextSharp.text.pdf.PdfPCell(_frase);
                        }

                        if (texto.Contains("$"))
                            _celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        else
                            _celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                        _celda.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                        //Establecemos el valor de la celda.
                        Rpt_Tabla.AddCell(_celda);
                    });
                    //Indicamos que se completo de editar la fila y completamos la operación.
                    Rpt_Tabla.CompleteRow();
                });

                // Se agrega el PDFTable al documento.
                Documento.Add(Titulo);
                Documento.Add(Tabla_Subtitulo);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Rpt_Tabla);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Exportar_Datos_PDF]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        ///  Método que obtiene la propiedad Width de cada columna y la almacena en un arreglo
        /// </summary>
        /// <param name="Tabla">Tabla de resultados de la cuál obtendremos la propiedad Width de cada columna</param>
        /// <returns>Arreglo con los valores establecidos de cada columna de la tabla de resultados</returns>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>27-nov-2013</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public float[] Obtener_Tamano_Columnas(DataGridView Tabla)
        {
            float[] Lst_Ancho_Columnas = null; // arreglo que almacenara la anchura de cada columna de la tabla de resultados.
            int Contador = 0; // contador que se utilizará para ir estableciendo los valores al arreglo.

            try
            {
                Lst_Ancho_Columnas = new float[Tabla.ColumnCount]; // establecemos el número de elementos que tendrá el arreglo.
                Array.ForEach(Tabla.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    Lst_Ancho_Columnas[Contador++] = (float)columna.Width; // establecemos el valor Width actual de la columna.
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Obtener_Tamano_Columnas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lst_Ancho_Columnas;
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
        ///*******************************************************************************************************
        /// <summary>
        ///  Método que exporta la información de una datatable a un archivo excel en una ruta dada
        /// </summary>
        /// <param name="Dt_Datos">Tabla que contiene los datos que se mostrarán en el reporte</param>
        /// <param name="Titulo">Título del reporte</param>
        /// <param name="Ruta_Archivo">Ruta para escribir el archivo</param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>21-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public void Exportar_Excel(DataTable Dt_Datos, string Titulo, string Ruta_Archivo)
        {
            try
            {
                CarlosAg.ExcelXmlWriter.Workbook Libro = new CarlosAg.ExcelXmlWriter.Workbook();
                Libro.Properties.Title = "Reporte Museo de las momias de Guanajuato";
                Libro.Properties.Created = DateTime.Now;
                Libro.Properties.Author = "Sistema de Administración, control y monitoreo del Museo de momias de Guanajuato";

                //Creamos una hoja que tendrá el libro.
                CarlosAg.ExcelXmlWriter.Worksheet Hoja = Libro.Worksheets.Add(Titulo);
                //Agregamos un renglón a la hoja de excel.
                CarlosAg.ExcelXmlWriter.WorksheetRow Renglon = Hoja.Table.Rows.Add();

                //Creamos el estilo cabecera para la hoja de excel. 
                CarlosAg.ExcelXmlWriter.WorksheetStyle Estilo_Cabecera = Libro.Styles.Add("HeaderStyle");
                Estilo_Cabecera.Font.FontName = "Tahoma";
                Estilo_Cabecera.Font.Size = 10;
                Estilo_Cabecera.Font.Bold = true;
                Estilo_Cabecera.Alignment.Horizontal = StyleHorizontalAlignment.Center;
                Estilo_Cabecera.Font.Color = "#FFFFFF";
                Estilo_Cabecera.Interior.Color = "#193d61";
                Estilo_Cabecera.Interior.Pattern = StyleInteriorPattern.Solid;
                Estilo_Cabecera.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "Black");
                Estilo_Cabecera.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "Black");
                Estilo_Cabecera.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "Black");
                Estilo_Cabecera.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "Black");

                //Creamos el estilo cabecera para la hoja de excel. 
                CarlosAg.ExcelXmlWriter.WorksheetStyle Estilo_Resaltar = Libro.Styles.Add("EstiloResaltar");
                Estilo_Resaltar.Font.FontName = "Tahoma";
                Estilo_Resaltar.Font.Size = 10;
                Estilo_Resaltar.Font.Bold = true;
                Estilo_Resaltar.Alignment.Horizontal = StyleHorizontalAlignment.Left;

                //Creamos el estilo contenido para la hoja de excel. 
                CarlosAg.ExcelXmlWriter.WorksheetStyle Estilo_Contenido = Libro.Styles.Add("BodyStyle");
                Estilo_Contenido.Font.FontName = "Tahoma";
                Estilo_Contenido.Font.Size = 9;
                Estilo_Contenido.Font.Bold = false;
                Estilo_Contenido.Alignment.Horizontal = StyleHorizontalAlignment.Left;
                Estilo_Contenido.Font.Color = "#000000";
                Estilo_Contenido.Interior.Color = "#FFFFFF";
                Estilo_Contenido.Interior.Pattern = StyleInteriorPattern.Solid;
                Estilo_Contenido.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1, "Black");
                Estilo_Contenido.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1, "Black");
                Estilo_Contenido.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1, "Black");
                Estilo_Contenido.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1, "Black");
                Estilo_Contenido.Alignment.WrapText = true;

                // agregar las columnas a la hoja recorriendo Dt_Datos
                Array.ForEach(Dt_Datos.Columns.OfType<DataColumn>().ToArray(), columna =>
                {
                    Hoja.Table.Columns.Add(new CarlosAg.ExcelXmlWriter.WorksheetColumn(90));
                });

                // agregar nombre de la tabla y fecha
                Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell(Titulo, DataType.String, "EstiloResaltar"));
                Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell("", DataType.String, "EstiloResaltar"));
                Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell(DateTime.Today.ToString("dd-MMM-yyyy"), DataType.String, "EstiloResaltar"));
                // si hay un rango de fechas seleccionado, agregarlo
                if (Dtp_Fecha_Inicio.Checked.Equals(true) || Dtp_Fecha_Termino.Checked.Equals(true))
                {
                    Renglon = Hoja.Table.Rows.Add();
                    Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell(Dtp_Fecha_Inicio.Text + " - " + Dtp_Fecha_Termino.Text, DataType.String, "EstiloResaltar"));
                }
                // si hay un usuario o tipo de operación seleccionado, agregar
                if (Cmb_Operacion.SelectedIndex > 0)
                {
                    Renglon = Hoja.Table.Rows.Add();
                    Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell(Cmb_Operacion.Text, DataType.String, "EstiloResaltar"));
                }
                if (Cmb_Usuario.SelectedIndex > 0)
                {
                    Renglon = Hoja.Table.Rows.Add();
                    Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell(Cmb_Usuario.Text, DataType.String, "EstiloResaltar"));
                }

                // validar la tabla
                if (Dt_Datos is DataTable && Dt_Datos != null && Dt_Datos.Rows.Count > 0)
                {
                    Renglon = Hoja.Table.Rows.Add();
                    // recorrer las columnas en Dt_Datos para agregar las celdas encabezado
                    foreach (DataColumn Columna in Dt_Datos.Columns)
                    {
                        if (Columna is DataColumn)
                        {
                            Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell(Columna.ColumnName.Replace("_", " "), "HeaderStyle"));
                        }
                    }

                    int Contador_Columnas;
                    int Total_columnas = Dt_Datos.Columns.Count;
                    // recorrer las filas en Dt_Datos para agregar las celdas
                    foreach (DataRow Dr in Dt_Datos.Rows)
                    {
                        Renglon = Hoja.Table.Rows.Add();

                        for (Contador_Columnas = 0; Contador_Columnas < Total_columnas; Contador_Columnas++)
                        {
                            Renglon.Cells.Add(new CarlosAg.ExcelXmlWriter.WorksheetCell(Dr[Contador_Columnas].ToString(), DataType.String, "BodyStyle"));
                        }
                    }
                }

                Libro.Save(Ruta_Archivo);
            }
            catch (IOException Ex)
            {
                throw Ex;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        #endregion METODOS

        #region EVENTOS

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click sobre el botón buscar: ejecutar búsqueda
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                // consultar log
                Consulta_Log();
                // habilitar los botones exportar
                Btn_Exportar_Excel.Enabled = true;
                Btn_Exportar_PDF.Enabled = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Buscar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento Load para el formulario: Cargar el listado de usuarios del sistema en el combo
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Frm_Rep_Log_Load(object sender, EventArgs e)
        {
            try
            {
                // consultar la lista de usuario activos
                Cls_Apl_Usuarios_Negocio Neg_Usuario = new Cls_Apl_Usuarios_Negocio();
                Neg_Usuario.P_Estatus = "ACTIVO";
                Cmb_Usuario.ValueMember = Apl_Usuarios.Campo_Nombre_Usuario;
                Cmb_Usuario.DisplayMember = Apl_Usuarios.Campo_Nombre_Usuario;
                DataTable Dt_Usuarios = Neg_Usuario.Consultar_Usuario();
                // si la consulta regresó resultados, agregar una fila vacía
                if (Dt_Usuarios != null && Dt_Usuarios.Rows.Count > 0)
                {
                    DataRow Dr = Dt_Usuarios.NewRow();
                    Dr[Apl_Usuarios.Campo_Nombre_Usuario] = "";
                    Dt_Usuarios.Rows.InsertAt(Dr, 0);
                }
                // asignar la fuente de datos
                Cmb_Usuario.DataSource = Dt_Usuarios;

                // consultar la lista de tablas en la base de datos que tienen log
                Cls_Tablas_Negocio Neg_Tablas = new Cls_Tablas_Negocio();
                DataTable Dt_Tablas = Neg_Tablas.Listar_Tablas_Con_Log();
                Cmb_Tabla.DisplayMember = "table_name";
                Cmb_Tabla.DataSource = Dt_Tablas;
            }
            catch { }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón exportar pdf: llamar al método que genera el archivo en pdf 
        /// con la información en el grid de datos
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>23-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            FileStream Archivo = null;
            try
            {
                // validar que el grid contenga registros, si no, mostrar mensaje
                if (Grd_Resultado.Rows.Count > 0)
                {
                    iTextSharp.text.Document Documento = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate(), 10, 10, 10, 10);
                    // Path que guarda el reporte en los archivos temporales de windows (con el nombre de la tabla).
                    string Ruta_Archivo = (System.IO.Path.GetTempPath() + "btc_" + Cmb_Tabla.Text + ".pdf");
                    Archivo = new FileStream(Ruta_Archivo, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(Documento, Archivo);
                    Documento.Open();
                    Exportar_Datos_PDF(Documento);
                    Documento.Close();
                    Process.Start(Ruta_Archivo);
                }
                else
                {
                    MessageBox.Show(this, "No hay registros para exportar", "Exportar a PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show(this, "No se puede generar el archivo.", "Error al generar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Exportar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Archivo != null)
                {
                    Archivo.Close();
                }
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón exportar Excel: llamar al método que genera el archivo excel 
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>23-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            try
            {

                // validar que el grid contenga registros, si no, mostrar mensaje
                if (Grd_Resultado.Rows.Count > 0)
                {

                    SaveFileDialog Sfd_Bitacora = new SaveFileDialog();

                    Sfd_Bitacora.Title = "Respaldar Bitácora";
                    Sfd_Bitacora.FileName = "btc_" + Cmb_Tabla.Text;
                    Sfd_Bitacora.Filter = "Archivos de Excel(*.xls)|*.xls|Todos los Archivos (*.*)|*.*";
                    Sfd_Bitacora.RestoreDirectory = true;

                    if (Sfd_Bitacora.ShowDialog() == DialogResult.OK)
                    {
                        DataTable Dt_Datos_Exportar = Grd_Resultado.DataSource as DataTable;
                        Exportar_Excel(Dt_Datos_Exportar, Cmb_Tabla.Text, Sfd_Bitacora.FileName);
                    }
                    // mostrar mensaje para confirmar apertura
                    if (DialogResult.Yes == MessageBox.Show(this, "¿Desea abrir el archivo generado?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        Process.Start(Sfd_Bitacora.FileName);
                    }
                }
                else
                {
                    MessageBox.Show(this, "No hay registros para exportar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show(this, "No se puede generar el archivo.", "Error al generar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Exportar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion EVENTOS

    }
}
