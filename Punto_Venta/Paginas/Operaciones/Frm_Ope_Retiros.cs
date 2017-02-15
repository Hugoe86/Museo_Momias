using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using ERP_BASE.App_Code.Negocio.Operacion.Retiros;
using Erp.Constantes;
using Erp.Metodos_Generales;
using Erp.Validador;
using System.Globalization;
using System.Threading;
using Erp_Apl_Usuarios.Negocio;
using Erp.Seguridad;
using ResizeableForm;
using Operaciones.Recolecciones.Negocio;
using Erp_Apl_Parametros.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;

namespace ERP_BASE.Paginas.Operacion
{
    public partial class Frm_Ope_Retiros : ResizableForm
    {
        Validador_Generico Validador;
        string Usuario_Autoriza;//Identificador del empleado que autoriza el movimiento.
        string Usuario_Autoriza_Nombre; 

        #region (Init/Load)
        /// <summary>
        /// Nombre: Frm_Ope_Retiros
        /// 
        /// Descripción: Método que inicializa los controles del formulario.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 05 Octubre 2013 10:48 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public Frm_Ope_Retiros()
        {
            InitializeComponent();
            Txt_Cantidad.LostFocus += new EventHandler(this.Txt_Cantidad_OnLostFocus);
        }
        #endregion

        #region (Metodos)

        #region (Generales)
        /// <summary>
        /// Nombre: Frm_Ope_Retiros_Load
        /// 
        /// Descripción: Método que realiza la carga inicial de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 08:10 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Ope_Retiros_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Retiros", this);//Valida las operaciones que puede realizar el usuario logueado.
            Cls_Ope_Retiros_Negocio Obj_Retiros = new Cls_Ope_Retiros_Negocio();//Variable para realizar peticiones a la clase de negocios.
            Cls_Ope_Recolecciones_Negocio Obj_Recolecciones = new Cls_Ope_Recolecciones_Negocio();
            DataTable Dt_Cajas = null;//Variable para guardar los registros consultados de la tabla de cajas.

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-Mx");
                //Se consulta las cajas que se encuentran abiertas

                Dt_Cajas = Obj_Recolecciones.Consultar_Cajas();
                //Dt_Cajas = Obj_Retiros.Consultar_Cajas();

                if (!Dt_Cajas.AsEnumerable().Any())
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(this, "No se encuentra ninguna caja abierta por el momento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Dispose();
                    });
                }

                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Caja, Dt_Cajas, Cat_Cajas.Campo_Comentarios, "No_Caja");
                //Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Caja, Dt_Cajas, "Caja", "No_Caja");
                Manejo_Botones_Operacion("Cancelar");
                Limpiar_Controles();
                Validador = new Validador_Generico(Erp_Validaciones);
                Erp_Validaciones.Clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Metodo: [Frm_Ope_Retiros_Load]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Manejo_Botones_Operacion
        /// 
        /// Descripción: Método que establecera la configuración de los botones según la operación a realizar.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 04 Octubre 2013 08:25 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Tipo">Configuracion a establecer</param>
        private void Manejo_Botones_Operacion(String Tipo)
        {
            bool Habilitar = false;
            switch (Tipo)
            {
                case "Nuevo":
                    {
                        Habilitar = true;
                        Btn_Nuevo.Text = "Dar de Alta";
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Cmb_Caja.Enabled = Habilitar;
                        Grid_Retiros.Enabled = !Habilitar;
                        Erp_Validaciones.Clear();
                        break;
                    }
                case "Modificar":
                    {
                        Habilitar = true;
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Cmb_Caja.Enabled = !Habilitar;
                        Grid_Retiros.Enabled = !Habilitar;
                        Erp_Validaciones.Clear();
                        break;
                    }
                case "Cancelar":
                    {
                        Habilitar = false;
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Modificar.Text = "Modificar";
                        Btn_Eliminar.Text = "Eliminar";
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Btn_Salir.Enabled = true;
                        Cmb_Caja.Enabled = !Habilitar;
                        Grid_Retiros.Enabled = false;
                        this.Usuario_Autoriza = string.Empty;
                        Erp_Validaciones.Clear();
                        break;
                    }
                default:break;
            }

            Txt_No_Retiro.Enabled = false; ;
            Dtp_Fecha.Enabled = Habilitar;
            Dtp_Hora.Enabled = Habilitar;
            Txt_Cantidad.Enabled = Habilitar;
            Txt_Motivo.Enabled = Habilitar;

            if (Cmb_Caja.Items.Count == 2)
            {
                Cmb_Caja.SelectedIndex = 1;
                Cmb_Caja_SelectedIndexChanged(Cmb_Caja, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Nombre: Limpiar_Controles
        /// 
        /// Descripción: Método que limpia los controles de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 07 Octubre 2013 17:00 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Limpiar_Controles()
        {
            try
            {
                Txt_No_Retiro.Text = string.Empty;
                if (Cmb_Caja.Items.Count == 0)
                    Cmb_Caja.SelectedIndex = (-1);
                else if (Cmb_Caja.Items.Count == 2)
                    Cmb_Caja.SelectedIndex = 1;

                Dtp_Fecha.Value = DateTime.Now;
                Dtp_Hora.Value = DateTime.Now;
                Txt_Cantidad.Text = string.Empty;
                Txt_Motivo.Text = string.Empty;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Limpiar_Controles]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Reset
        /// 
        /// Descripción: Método que limpia los controles de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 07 Octubre 2013 17:00 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Reset()
        {
            try
            {
                Txt_No_Retiro.Text = string.Empty;
                Dtp_Fecha.Value = DateTime.Now;
                Dtp_Hora.Value = DateTime.Now;
                Txt_Cantidad.Text = string.Empty;
                Txt_Motivo.Text = string.Empty;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Limpiar_Controles]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Cargar_Datos_Caja_Abierta
        /// 
        /// Descripción: Método que realiza la carga de los datos de la caja abierta.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 13 Noviembre 2013 11:01 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Datos_Caja_Abierta()
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recolecciones = new Cls_Ope_Recolecciones_Negocio();//Variable para realizar peticiones a la clase de datos.
            DataTable Dt_Datos_Caja = null;

            try
            {
                if (Cmb_Caja.SelectedIndex > 0)
                {
                    string No_Caja = Cmb_Caja.SelectedValue.ToString().Trim();
                    //Se cargan los registros de retiros hechos de la caja seleccionada.
                    Cargar_Grid_Retiros(No_Caja);
                    if (Btn_Nuevo.Text.Trim() == "Nuevo")
                        Grid_Retiros.Enabled = true;
                    else
                        Reset();

                    Obj_Recolecciones.P_No_Caja = No_Caja;
                    Dt_Datos_Caja = Obj_Recolecciones.Consultar_Consecutivo_Recoleccion_Por_Caja_Turno();

                    if (Dt_Datos_Caja is DataTable)
                    {
                        if (Dt_Datos_Caja.AsEnumerable().Any())
                        {
                            var _datos_caja = from _caja in Dt_Datos_Caja.AsEnumerable()
                                              select new
                                              {
                                                  _total_caja_menos_rec_y_ret = _caja.IsNull("Total") ? 0 : _caja.Field<decimal>("Total")
                                              };
                            if (_datos_caja.Any())
                            {
                                foreach (var _dato in _datos_caja)
                                {
                                    Txt_Disponible_Caja.Text = string.Format("{0:n}",
                                        _dato._total_caja_menos_rec_y_ret);
                                }
                            }
                        }
                    }
                }
                else
                {
                    Cargar_Grid_Retiros(string.Empty);
                    Reset();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Cargar_Datos_Caja_Abierta]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Operación)
        /// <summary>
        /// Nombre: Alta_Retiro
        /// 
        /// Descripción: Método que realiza el alta de los datos del retiro.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 04 Octubre 2013 12:58 p.pm.
        /// Usuario Modifico::
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private bool Alta_Retiro()
        {
            Cls_Ope_Retiros_Negocio Obj_Retiros = new Cls_Ope_Retiros_Negocio();//Variable que se utiliza para realizar peticiones a la clase de negocios.
            bool Estatus = false;//Variable que mantiene el estatus de la operación que se ejecuta.

            try
            {
                Obj_Retiros.P_No_Caja = Cmb_Caja.SelectedValue.ToString();
                Obj_Retiros.P_Fecha = Dtp_Fecha.Value.Date.AddSeconds(Dtp_Hora.Value.TimeOfDay.TotalSeconds);
                Obj_Retiros.P_Cantidad = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Cantidad.Text) ? "0.0" : Txt_Cantidad.Text.Trim());
                Obj_Retiros.P_Motivo = Txt_Motivo.Text;
                Obj_Retiros.P_Usuario_ID_Autoriza = this.Usuario_Autoriza;

                //Se imprime un pdf con la información del retiro
                bool Error_Exportar = Exportar_PDF(Obj_Retiros);

               //Se realiza el alta de la recolección.
               if (!Error_Exportar)
                    Estatus = Obj_Retiros.Alta_Retiro();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Alta_Retiro]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }

        /// <summary>
        /// Nombre: Btn_Exportar_PDF_Click
        /// 
        /// Descripción: Método que exporta el listado de la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:37 Hrs.
        /// Usuario Modifico: Cruz Amaya Olimpo Alberto 
        /// Fecha Modifico: 26/Marzo /2015
        /// Causa Modificación: Se crea un pdf con los datos del movimiento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool Exportar_PDF(Cls_Ope_Retiros_Negocio MyObj_Retiro)
        {
            bool ErrorPDF = false;
            try
            {

                // iTextSharp.text.Document Documento = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER.Rotate(), 10, 10, 10, 10);
                iTextSharp.text.Document Documento = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 10);
                iTextSharp.text.Document Documento_Copia = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 10);
                // Path que guarda el reporte en los archivos temporales de windows.
                //CultureInfo ci = new CultureInfo("de-DE");

                string Fecha = DateTime.Now.ToString("dd-MMM-yyyy hh.mm.ss tt");
                string Nombre_Archivo = "RETIRO"+ " " + Fecha + ".pdf";
                string Ruta_Archivo = ObtenerRutaArchivo(Nombre_Archivo);

                //Copia de seguridad del archivo
                string Ruta_Archivo_Copia = (System.IO.Path.GetTempPath() + Nombre_Archivo);

                FileStream Archivo = new FileStream(Ruta_Archivo, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                FileStream Archivo_Copia = new FileStream(Ruta_Archivo_Copia, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                iTextSharp.text.pdf.PdfWriter.GetInstance(Documento, Archivo);
                iTextSharp.text.pdf.PdfWriter.GetInstance(Documento_Copia, Archivo_Copia);
                Documento.Open();
                Exportar_Datos_PDF(Documento, MyObj_Retiro);
                Documento.Close();
                Documento_Copia.Open();
                Exportar_Datos_PDF(Documento_Copia, MyObj_Retiro);
                Documento_Copia.Close();

                Process.Start(Ruta_Archivo);
    

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_PDF_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ErrorPDF = true;
            }
            return ErrorPDF;

        }
        /// <summary>
        /// Nombre: Btn_Exportar_PDF_Click
        /// 
        /// Descripción: Método que exporta el listado de la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:37 Hrs.
        /// Usuario Modifico: Cruz Amaya Olimpo Alberto 
        /// Fecha Modifico: 26/Marzo /2015
        /// Causa Modificación: Obtiene la ruta para guardar del documento en PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private string ObtenerRutaArchivo(string NombreArchivo)
        {
            try
            {
                Stream myStream;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = NombreArchivo;
                string targetPath = "";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        targetPath = saveFileDialog1.FileName;
                        // Code to write the stream goes here.
                        myStream.Close();
                    }
                }

                return targetPath;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Error al generar la ruta para guardar el archivo\n" + Ex.ToString(), "Alta Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
        }

        #region (Reporte)
        /// <summary>
        /// Nombre: Exportar_Datos_PDF
        /// 
        /// Descripción: Método que exporta la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:50 Hrs.
        /// Usuario Modifico: Cruz Amaya Olimpo Alberto 
        /// Fecha Modifico: 27/Marzo /2015
        /// Causa Modificación: Se detalla un pdf con los datos del movimiento, el desglose de monedas, el sobrante y faltante y las firmas 
        /// </summary>
        /// <param name="Documento">Objeto al cúal agregaremos el contenido del reporte</param>
        /// <param name="MyRetiro">Objeto que contiene los datos de la recolección</param>
        private void Exportar_Datos_PDF(iTextSharp.text.Document Documento, Cls_Ope_Retiros_Negocio MyRetiro)
        {

            try
            {
                iTextSharp.text.FontFactory.RegisterDirectory(@"C:\Windows\Fonts");

                //Tabla Logotipo
                iTextSharp.text.pdf.PdfPTable Tabla_Logotipo = new iTextSharp.text.pdf.PdfPTable(2);
                Tabla_Logotipo.WidthPercentage = 100;
                Tabla_Logotipo.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;

                var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Logo/Logotipo.jpg";

                Image image = Image.FromFile(Ruta_Archivo);


                iTextSharp.text.Image Logo = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                Tabla_Logotipo.AddCell(new iTextSharp.text.pdf.PdfPCell(Logo) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                Tabla_Logotipo.AddCell(new iTextSharp.text.Phrase(""));

                // Creamos y establecemos el formato que tendrá el titulo del reporte.
                iTextSharp.text.pdf.PdfPTable Tabla_Titulo = new iTextSharp.text.pdf.PdfPTable(1);
                Tabla_Titulo.WidthPercentage = 100;
                Tabla_Titulo.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;


                iTextSharp.text.Phrase Titulo_Name = new iTextSharp.text.Phrase("Gobierno Municipial de Guanajuato\nMuseo de las momias de Guanajuato\n");
                Titulo_Name.Font.Size = 14;
                Titulo_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                Tabla_Titulo.AddCell(new iTextSharp.text.Phrase(""));
                Tabla_Titulo.AddCell(new iTextSharp.text.pdf.PdfPCell(Titulo_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });


                //Fecha Actual
                iTextSharp.text.Paragraph Fecha = new iTextSharp.text.Paragraph();
                Fecha.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Fecha.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Fecha.Font.SetStyle(iTextSharp.text.Font.NORMAL);
                Fecha.Font.Size = 11;
                Fecha.Add("Fecha:" + DateTime.Today.ToString("dd-MMM-yyyy") + "\n");

                // Creamos y establecemos el formato que tendrá el subtitulo del reporte.
                iTextSharp.text.Paragraph Subtitulo = new iTextSharp.text.Paragraph();
                Subtitulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Subtitulo.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Subtitulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Subtitulo.Font.Size = 11;
                Subtitulo.Add("RETIRO" + ": " + DateTime.Today.ToString("dd-MMM-yyyy") + "\n"); 

                //Creamos Tabla con Datos Generales
                iTextSharp.text.Paragraph Generales = new iTextSharp.text.Paragraph();
                Generales.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Generales.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Generales.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Generales.Font.Size = 12;
                Generales.Add("DATOS GENERALES:\n\n");

                //iTextSharp.text.Phrase Fecha_Retiro = new iTextSharp.text.Phrase("Fecha:\n" + Dtp_Fecha.Value.ToString("dd-MMM-yyyy"));
                //Fecha_Retiro.Font.Size = 7;
                iTextSharp.text.Phrase Usuario = new iTextSharp.text.Phrase("Usuario Autoriza:\n" + this.Usuario_Autoriza_Nombre);
                Usuario.Font.Size = 7;
                iTextSharp.text.Phrase Cajero = new iTextSharp.text.Phrase("Cajero:\n" + MDI_Frm_Apl_Principal.Nombre_Usuario);
                Cajero.Font.Size = 7;
                iTextSharp.text.Phrase Hora_Retiro = new iTextSharp.text.Phrase("Hora:\n" + Dtp_Hora.Value.ToString("HH:mm:ss"));
                Hora_Retiro.Font.Size = 7;
                iTextSharp.text.Phrase No_Caja = new iTextSharp.text.Phrase("No Caja:\n" + Cmb_Caja.Text);
                No_Caja.Font.Size = 7;

                //Tabla Generales
                iTextSharp.text.pdf.PdfPTable Tabla_Generales = new iTextSharp.text.pdf.PdfPTable(4);
                Tabla_Generales.WidthPercentage = 100;
                Tabla_Generales.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.SECTION;

                //Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Fecha_Retiro) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Usuario) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Cajero) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Hora_Retiro) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(No_Caja) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });

                //Creamos Tabla con el Desglose de Dinero
                iTextSharp.text.Paragraph Desglose = new iTextSharp.text.Paragraph();
                Desglose.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Desglose.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Desglose.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Desglose.Font.Size = 12;
                Desglose.Add("DESGLOSE DE DINERO:\n\n");

                #region Datos Desglose
                //Encabezado
                iTextSharp.text.Phrase Descripcion = new iTextSharp.text.Phrase("Billete/Moneda");
                Descripcion.Font.Size = 11;
                Descripcion.Font.SetStyle(iTextSharp.text.Element.ALIGN_MIDDLE);
                Descripcion.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase Cantidad = new iTextSharp.text.Phrase("Cantidad");
                Cantidad.Font.Size = 11;
                Cantidad.Font.SetStyle(iTextSharp.text.Element.ALIGN_MIDDLE);
                Cantidad.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase TotalBM = new iTextSharp.text.Phrase("Total");
                TotalBM.Font.Size = 11;
                TotalBM.Font.SetStyle(iTextSharp.text.Element.ALIGN_MIDDLE);
                TotalBM.Font.SetStyle(iTextSharp.text.Font.BOLD);

                //Billetes/Monedas
                iTextSharp.text.Phrase Billetes1000 = new iTextSharp.text.Phrase("Billetes $1,000");
                Billetes1000.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad1000 = new iTextSharp.text.Phrase("");
                Cantidad1000.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes1000 = new iTextSharp.text.Phrase("");
                TotalBilletes1000.Font.Size = 11;

                iTextSharp.text.Phrase Billetes500 = new iTextSharp.text.Phrase("Billetes $500");
                Billetes500.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad500 = new iTextSharp.text.Phrase("");
                Cantidad500.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes500 = new iTextSharp.text.Phrase("");
                TotalBilletes500.Font.Size = 11;


                iTextSharp.text.Phrase Billetes200 = new iTextSharp.text.Phrase("Billetes $200");
                Billetes200.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad200 = new iTextSharp.text.Phrase("");
                Cantidad200.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes200 = new iTextSharp.text.Phrase("");
                TotalBilletes200.Font.Size = 11;

                iTextSharp.text.Phrase Billetes100 = new iTextSharp.text.Phrase("Billetes $100");
                Billetes100.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad100 = new iTextSharp.text.Phrase("");
                Cantidad100.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes100 = new iTextSharp.text.Phrase("");
                TotalBilletes100.Font.Size = 11;

                iTextSharp.text.Phrase Billetes50 = new iTextSharp.text.Phrase("Billetes $50");
                Billetes50.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad50 = new iTextSharp.text.Phrase("");
                Cantidad50.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes50 = new iTextSharp.text.Phrase("");
                TotalBilletes50.Font.Size = 11;

                iTextSharp.text.Phrase Billetes20 = new iTextSharp.text.Phrase("Billetes $20");
                Billetes20.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad20 = new iTextSharp.text.Phrase("");
                Cantidad20.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes20 = new iTextSharp.text.Phrase("");
                TotalBilletes20.Font.Size = 11;

                iTextSharp.text.Phrase Monedas20 = new iTextSharp.text.Phrase("Monedas $20");
                Monedas20.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM20 = new iTextSharp.text.Phrase("");
                CantidadM20.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas20 = new iTextSharp.text.Phrase("");
                TotalMonedas20.Font.Size = 11;

                iTextSharp.text.Phrase Monedas10 = new iTextSharp.text.Phrase("Monedas $10");
                Monedas10.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM10 = new iTextSharp.text.Phrase("");
                CantidadM10.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas10 = new iTextSharp.text.Phrase("");
                TotalMonedas10.Font.Size = 11;

                iTextSharp.text.Phrase Monedas5 = new iTextSharp.text.Phrase("Monedas $5");
                Monedas5.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM5 = new iTextSharp.text.Phrase("");
                CantidadM5.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas5 = new iTextSharp.text.Phrase("");
                TotalMonedas5.Font.Size = 11;

                iTextSharp.text.Phrase Monedas2 = new iTextSharp.text.Phrase("Monedas $2");
                Monedas2.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM2 = new iTextSharp.text.Phrase("");
                CantidadM2.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas2 = new iTextSharp.text.Phrase("");
                TotalMonedas2.Font.Size = 11;

                iTextSharp.text.Phrase Monedas1 = new iTextSharp.text.Phrase("Monedas $1");
                Monedas1.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM1 = new iTextSharp.text.Phrase("");
                CantidadM1.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas1 = new iTextSharp.text.Phrase("");
                TotalMonedas1.Font.Size = 11;

                iTextSharp.text.Phrase Monedas50c = new iTextSharp.text.Phrase("Monedas 50c");
                Monedas50c.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM50c = new iTextSharp.text.Phrase("");
                CantidadM50c.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas50c = new iTextSharp.text.Phrase("");
                TotalMonedas50c.Font.Size = 11;

                iTextSharp.text.Phrase Monedas20c = new iTextSharp.text.Phrase("Monedas 20c");
                Monedas20c.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM20c = new iTextSharp.text.Phrase("");
                CantidadM20c.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas20c = new iTextSharp.text.Phrase("");
                TotalMonedas20c.Font.Size = 11;

                iTextSharp.text.Phrase Monedas10c = new iTextSharp.text.Phrase("Monedas 10c");
                Monedas10c.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM10c = new iTextSharp.text.Phrase("");
                CantidadM10c.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas10c = new iTextSharp.text.Phrase("");
                TotalMonedas10c.Font.Size = 11;

                iTextSharp.text.Phrase SubTotal_Billetes_Name = new iTextSharp.text.Phrase("TOTAL BILLETES");
                SubTotal_Billetes_Name.Font.Size = 7;
                SubTotal_Billetes_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);
                iTextSharp.text.Phrase SubTotal_Billetes = new iTextSharp.text.Phrase("");
                SubTotal_Billetes.Font.Size = 11;
                SubTotal_Billetes.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase SubTotal_Monedas_Name = new iTextSharp.text.Phrase("TOTAL MONEDAS");
                SubTotal_Monedas_Name.Font.Size = 7;
                SubTotal_Monedas_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);
                iTextSharp.text.Phrase SubTotal_Monedas = new iTextSharp.text.Phrase("");
                SubTotal_Monedas.Font.Size = 11;
                SubTotal_Monedas.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase Total_Desglose_Name = new iTextSharp.text.Phrase("TOTAL DESGLOSE");
                Total_Desglose_Name.Font.Size = 9;
                Total_Desglose_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase Total_Desglose = new iTextSharp.text.Phrase(Convert.ToDecimal(Txt_Cantidad.Text).ToString("C", CultureInfo.CurrentCulture));
                Total_Desglose.Font.Size = 11;
                Total_Desglose.Font.SetStyle(iTextSharp.text.Font.BOLD);
                #endregion

                #region Tabla Desglose
                //Tabla Desglose
                iTextSharp.text.pdf.PdfPTable Tabla_Desglose = new iTextSharp.text.pdf.PdfPTable(3);
                Tabla_Desglose.WidthPercentage = 50;
                Tabla_Desglose.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.RECTANGLE;
                Tabla_Desglose.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                Tabla_Desglose.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                //Encabezado
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Descripcion) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Cantidad) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalBM) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });

                //Billetes/Monedas
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Billetes1000) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Cantidad1000) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalBilletes1000) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Billetes500) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Cantidad500) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalBilletes500) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Billetes200) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Cantidad200) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalBilletes200) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Billetes100) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Cantidad100) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalBilletes100) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Billetes50) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Cantidad50) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalBilletes50) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Billetes20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Cantidad20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalBilletes20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });


                //SubTotalBilletes
                Tabla_Desglose.AddCell(new iTextSharp.text.Phrase(""));
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(SubTotal_Billetes_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(SubTotal_Billetes) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas10) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM10) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas10) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas5) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM5) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas5) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas2) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM2) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas2) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas1) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM1) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas1) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas50c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM50c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas50c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas20c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM20c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas20c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas10c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM10c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas10c) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                //SubTotalMonedas
                Tabla_Desglose.AddCell(new iTextSharp.text.Phrase(""));
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(SubTotal_Monedas_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(SubTotal_Monedas) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                //Total Desglose
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell((new iTextSharp.text.Phrase(""))) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Desglose_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Desglose) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });

                #endregion

              


                //Creamos Tabla Montivo
                iTextSharp.text.Paragraph Montivo = new iTextSharp.text.Paragraph();
                Montivo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Montivo.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Montivo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Montivo.Font.Size = 12;
                Montivo.Add("MOTIVO DEL RETIRO:\n");

                //Motivo
                iTextSharp.text.Phrase Montivo_Name = new iTextSharp.text.Phrase(Txt_Motivo.Text);
                Montivo_Name.Font.Size = 10;
                Montivo_Name.Font.SetStyle(iTextSharp.text.Font.NORMAL);

                //Tabla Motivo
                iTextSharp.text.pdf.PdfPTable Tabla_Motivo= new iTextSharp.text.pdf.PdfPTable(1);
                Tabla_Motivo.WidthPercentage = 100;
                //Tabla_Resultado_Recoleccion.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Motivo.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //Encabezado Celda
                Tabla_Motivo.AddCell(new iTextSharp.text.pdf.PdfPCell(Montivo_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });



                //Creamos Tabla Resultados
                iTextSharp.text.Paragraph Resultados = new iTextSharp.text.Paragraph();
                Resultados.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Resultados.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Resultados.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Resultados.Font.Size = 12;
                Resultados.Add("RESULTADOS DEL RETIRO:\n");

                #region Datos Resultado Retiro
                //Encabezado
                iTextSharp.text.Phrase Total_Cantidad_Recolectado_Retirado_Name = new iTextSharp.text.Phrase("Cantidad Retirada:");
                Total_Cantidad_Recolectado_Retirado_Name.Font.Size = 11;
                Total_Cantidad_Recolectado_Retirado_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);
                //Resultados
                decimal Total_Caja_Decimal_Recoleccion = Convert.ToDecimal(Txt_Cantidad.Text);
                iTextSharp.text.Phrase Total_Caja_Desglose_Recoleccion = new iTextSharp.text.Phrase(Total_Caja_Decimal_Recoleccion.ToString("C", CultureInfo.CurrentCulture));
                Total_Caja_Desglose_Recoleccion.Font.Size = 11;
                #endregion

                #region Tabla Resultado Retiro
                //Tabla Resultado
                iTextSharp.text.pdf.PdfPTable Tabla_Resultado_Recoleccion = new iTextSharp.text.pdf.PdfPTable(1);
                Tabla_Resultado_Recoleccion.WidthPercentage = 100;
                //Tabla_Resultado_Recoleccion.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Resultado_Recoleccion.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                //Encabezado Celda
                Tabla_Resultado_Recoleccion.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Cantidad_Recolectado_Retirado_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                //Resultado Celda
                Tabla_Resultado_Recoleccion.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Caja_Desglose_Recoleccion) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                #endregion

                #region Firmas
                //Firma Izquierda
                iTextSharp.text.Phrase Firma_Izquierda = new iTextSharp.text.Phrase("\n\n\n________________________\nFirma Cajero");
                Firma_Izquierda.Font.Size = 7;

                // Firma Derecha
                iTextSharp.text.Phrase Firma_Derecha = new iTextSharp.text.Phrase("\n\n\n________________________\nFirma Supervisor");
                Firma_Derecha.Font.Size = 7;

                //Tabla con firmas
                iTextSharp.text.pdf.PdfPTable Tabla_Firmas = new iTextSharp.text.pdf.PdfPTable(2);
                Tabla_Firmas.WidthPercentage = 100;
                Tabla_Firmas.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Firmas.AddCell(new iTextSharp.text.pdf.PdfPCell(Firma_Izquierda) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                Tabla_Firmas.AddCell(new iTextSharp.text.pdf.PdfPCell(Firma_Derecha) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                #endregion

                //Se agrega el Todo al documento al documento.
                Documento.Add(Tabla_Logotipo);
                Documento.Add(Tabla_Titulo);
                //Documento.Add(Titulo);
                Documento.Add(Subtitulo);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Generales);
                Documento.Add(Tabla_Generales);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                //Documento.Add(Desglose);
                //Documento.Add(Tabla_Desglose);
                //Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Montivo);
                Documento.Add(Tabla_Motivo);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Resultados);
                Documento.Add(Tabla_Resultado_Recoleccion);
                Documento.Add(Tabla_Firmas);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Exportar_Datos_PDF]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        /// <summary>
        /// Nombre: Actualizar_Retiro
        /// 
        /// Descripción: Método que realiza la actualización de los datos del retiro.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 04 Octubre 2013 13:05 p.pm.
        /// Usuario Modifico::
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private bool Actualizar_Retiro()
        {
            Cls_Ope_Retiros_Negocio Obj_Retiros = new Cls_Ope_Retiros_Negocio();//Variable para realizar las peticiones a la clase de negocios.
            bool Estatus = false;//Variable para devolver el estatus de la operación.

            try
            {
                Obj_Retiros.P_No_Retiro = Txt_No_Retiro.Text;
                Obj_Retiros.P_No_Caja = Cmb_Caja.SelectedValue.ToString();
                Obj_Retiros.P_Fecha = Dtp_Fecha.Value.Date.AddSeconds(Dtp_Hora.Value.TimeOfDay.TotalSeconds);
                Obj_Retiros.P_Cantidad = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Cantidad.Text) ? "0.0" : Txt_Cantidad.Text.Trim());
                Obj_Retiros.P_Motivo = Txt_Motivo.Text;
                Obj_Retiros.P_Usuario_ID_Autoriza = this.Usuario_Autoriza;

                //Se realiza la modificación del retiro.
                Estatus = Obj_Retiros.Modificar_Retiro();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Actualizar_Retiro]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        /// <summary>
        /// Nombre: Eliminar_Retiro
        /// 
        /// Descripción: Método que realiza la baja del retiro.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 04 Octubre 2013 13:09 p.pm.
        /// Usuario Modifico::
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private bool Eliminar_Retiro()
        {
            Cls_Ope_Retiros_Negocio Obj_Retiros = new Cls_Ope_Retiros_Negocio();//Variable para realizar las peticiones a la clase de negocios.
            bool Estatus = false;//Variable para devolver el estatus de la operación.

            try
            {
                Obj_Retiros.P_No_Retiro = Txt_No_Retiro.Text;
                //Se realiza la baja del retiro.
                Estatus = Obj_Retiros.Eliminar_Retiro();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Eliminar_Retiro]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        #endregion

        #region (Validación)
        /// <summary>
        /// Nombre: Validar_Datos
        /// 
        /// Descripción: Método que válida los datos que son requeridos para la operación.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 04 Octubre 2013 10:56 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>true si se ingresaron todos los datos y false si hay datos incorrectos</returns>
        private bool Validar_Datos() {
            bool Datos_Validados = true;//Variable que mantiene el estatus de la validación.
            StringBuilder Datos_Faltantes = new StringBuilder();//Variable para almacenar los datos que faltan de ingresar por el usuario.

            try
            {
                Datos_Faltantes.Append("Es necesario:\n");

                if (string.IsNullOrEmpty(Txt_Cantidad.Text)) {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" Introducir la cantidad a retirar \n");
                }

                if (string.IsNullOrEmpty(Txt_Motivo.Text))
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" Introducir el motivo por el cuál se realiza el retiro de la caja \n");
                }
                else Txt_Motivo.Text = (Txt_Motivo.Text.Length > 245) ? Txt_Motivo.Text.Substring(0, 240) : Txt_Motivo.Text;

                if (Cmb_Caja.SelectedIndex <= 0)
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" Seleccionar la caja de la cuál se realizara el retiro \n");
                }

                if (string.IsNullOrEmpty(Dtp_Fecha.Text))
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" Ingresar la fecha del retiro \n");
                }
                //else if (Dtp_Fecha.Value.CompareTo(DateTime.Today) < 0)
                //{
                //    Datos_Validados = false;
                //    Datos_Faltantes.Append("La fecha no puede ser menor a la fecha actual \n");
                //}

                if (string.IsNullOrEmpty(Dtp_Hora.Text))
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" Ingresar la hora del retiro \n");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Validar_Datos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Datos_Validados;
        }
        /// <summary>
        /// Nombre: Autorizar_Movimiento
        /// 
        /// Descripción: Método que invoca la autorización del movimiento.
        /// 
        /// Usuario Modifico: Juan Alberto Hernández Negrete
        /// Fecha Modifico: 06 Octubre 2013 11:31 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Verdadero (true) si se autoriza y falso (false) en caso contrario</returns>
        private bool Autorizar_Movimiento()
        {
            DataTable Dt_Consulta_Usuario = new DataTable();
            Cls_Ope_Recolecciones_Negocio ObjMyRecoleccion = new Cls_Ope_Recolecciones_Negocio();
            try
            {
                //Utilizamos la clase (Frm_Apl_Usuario_Autoriza) e invocamos su método (Mostrar_Ventana) para autorizar el movimiento.
                this.Usuario_Autoriza = new Frm_Apl_Usuario_Autoriza().Mostrar_Ventana("Autorización", this);
                //Se hace una consulta para conocer el nombre del usuario que se logea en la pre-autorización.
                ObjMyRecoleccion.P_Usuario_Autorizo = this.Usuario_Autoriza;
                Dt_Consulta_Usuario = ObjMyRecoleccion.Consultar_Usuario_Autorizo();
                //Nombre del usuario que pre-autoriza
                this.Usuario_Autoriza_Nombre = Dt_Consulta_Usuario.Rows[0][Apl_Usuarios.Campo_Nombre_Usuario].ToString();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Autorizar_Movimiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !string.IsNullOrEmpty(this.Usuario_Autoriza);
        }
        #endregion

        #endregion

        #region (Grid)
        /// <summary>
        /// Nombre: Cargar_Grid_Retiros
        /// 
        /// Descripción: Método que realiza la carga de retiros por caja.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 08:14 a.m.
        /// Usuario Modifco:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Dt_Retiros">Tabla con los registros de los retiros por caja</param>
        private void Cargar_Grid_Retiros(string No_Caja)
        {
            Cls_Ope_Retiros_Negocio Obj_Retiros = new Cls_Ope_Retiros_Negocio();//Variable de negocios para realizar peticiones a la clase de negocios.
            DataTable Dt_Retiro = null;//Variable de guardar los registros consultados de la tabla de retiros.
            DataTable Dt_Registros_Mostrar = new DataTable("Retiros");//Variable del tipo DataTable para almacenar las columnas que se mostraran en el listado de retiros.

            try
            {
                Dt_Registros_Mostrar.Columns.Add(Ope_Retiros.Campo_No_Retiro.ToUpper(), typeof(string));
                Dt_Registros_Mostrar.Columns.Add("FECHA", typeof(string));
                Dt_Registros_Mostrar.Columns.Add("HORA", typeof(string));
                Dt_Registros_Mostrar.Columns.Add("CANTIDAD", typeof(decimal));
                Dt_Registros_Mostrar.Columns.Add(Ope_Retiros.Campo_Motivo.ToUpper(), typeof(string));

                if (!string.IsNullOrEmpty(No_Caja) && No_Caja != "0")
                {
                    Obj_Retiros.P_No_Caja = No_Caja;
                    Dt_Retiro = Obj_Retiros.Consultar_Retiros();
                    if (Dt_Retiro is DataTable)
                    {
                        var registros = Dt_Retiro.AsEnumerable().Select(retiro => new
                        {
                            no_retiro = retiro.Field<string>(Ope_Retiros.Campo_No_Retiro),
                            fecha_retiro = retiro.IsNull(Ope_Retiros.Campo_Fecha) ? null : retiro.Field<MySql.Data.Types.MySqlDateTime?>("FECHA_RETIRO"),
                            hora_retiro = retiro.IsNull(Ope_Retiros.Campo_Fecha) ? null : retiro.Field<MySql.Data.Types.MySqlDateTime?>("HORA_RETIRO"),
                            cantidad = retiro.Field<decimal>("CANTIDAD"),
                            motivo = retiro.Field<string>(Ope_Retiros.Campo_Motivo)
                        });

                        if (registros.Any())
                        {
                            foreach (var _registro in registros)
                            {
                                var row = Dt_Registros_Mostrar.NewRow();
                                row.SetField<string>(Ope_Retiros.Campo_No_Retiro.ToUpper(), _registro.no_retiro);
                                row.SetField<string>("FECHA", _registro.fecha_retiro.Value.GetDateTime().ToString("dd MMM yyyy"));
                                row.SetField<string>("HORA", _registro.hora_retiro.Value.GetDateTime().ToString("HH:mm:ss tt"));
                                row.SetField<decimal>("CANTIDAD", Convert.ToDecimal(_registro.cantidad));
                                row.SetField<string>(Ope_Retiros.Campo_Motivo.ToUpper(), _registro.motivo);
                                Dt_Registros_Mostrar.Rows.Add(row);
                            }
                        }
                        Grid_Retiros.DataSource = Dt_Registros_Mostrar;//Cargamos los datos al grid.

                        Array.ForEach(Grid_Retiros.Columns.OfType<DataGridViewColumn>().ToArray(), columna => {
                            columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            
                            switch (columna.HeaderText)
                            {
                                case "NO_RETIRO":
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                    columna.HeaderText = "NO RETIRO";
                                    break;
                                case "FECHA":
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    break;
                                case "HORA":
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    break;
                                case "CANTIDAD":
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Format = "c";
                                    break;
                                case "MOTIVO":
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                    break;
                                default:
                                    break;
                            }
                        });
                        
                        Array.ForEach(Grid_Retiros.Rows.OfType<DataGridViewRow>().ToArray(), fila => {
                            Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda => {
                                celda.Style.Font = new Font("Arial", 10, FontStyle.Regular);
                                celda.Style.BackColor = Color.WhiteSmoke;
                            });
                        });
                    }
                }
                else
                {
                    Grid_Retiros.DataSource = new DataTable();//Si no existe una caja seleccionada no se mostraran registros de retiros.
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Cargar_Grid_Retiros]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Grid_Retiros_SelectionChanged
        /// 
        /// Descripción: Método para 
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 05 Octubre 2013 10:08 a.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 21-feb-2014
        /// Causa modificación: Se cambia <DateTime?> por <MySql.Data.Types.MySqlDateTime?> para recibir 
        ///                     un campo fecha al utilizar una base de datos MySQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Retiros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cls_Ope_Retiros_Negocio Obj_Retiros = new Cls_Ope_Retiros_Negocio();//Variable para realizar peticiones  a la clase de negocios de retiros.
            DataTable Dt_Retiros = null;//Variable para almacenar los registros de retiros.

            if (e.RowIndex != (-1))
            {
                if (!string.IsNullOrEmpty(Grid_Retiros.Rows[e.RowIndex].Cells["No_Retiro"].FormattedValue.ToString()))
                {
                    Obj_Retiros.P_No_Retiro = Grid_Retiros.Rows[e.RowIndex].Cells["No_Retiro"].FormattedValue.ToString();//Obtenemos el no de retiro del registro seleccionado del grid.
                    Dt_Retiros = Obj_Retiros.Consultar_Retiros();//Consultamos los datos del registro.

                    var retiros = Dt_Retiros.AsEnumerable().
                        Select(_retiro => new
                        {
                            no_retiro = _retiro.IsNull(Ope_Retiros.Campo_No_Retiro) ? string.Empty : _retiro.Field<string>(Ope_Retiros.Campo_No_Retiro),
                            no_caja = _retiro.IsNull(Ope_Retiros.Campo_No_Caja) ? string.Empty : _retiro.Field<string>(Ope_Retiros.Campo_No_Caja),
                            fecha = _retiro.IsNull(Ope_Retiros.Campo_Fecha) ? null : _retiro.Field<MySql.Data.Types.MySqlDateTime?>(Ope_Retiros.Campo_Fecha),
                            hora = _retiro.IsNull(Ope_Retiros.Campo_Fecha) ? null : _retiro.Field<MySql.Data.Types.MySqlDateTime?>(Ope_Retiros.Campo_Fecha),
                            cantidad = _retiro.IsNull("CANTIDAD") ? 0 : _retiro.Field<decimal>("CANTIDAD"),
                            motivo = _retiro.IsNull(Ope_Retiros.Campo_Motivo) ? string.Empty : _retiro.Field<string>(Ope_Retiros.Campo_Motivo),
                            usuario_autoriza = _retiro.IsNull("USUARIO") ? string.Empty : _retiro.Field<string>("USUARIO")
                        });

                    if (retiros.Any())
                    {
                        foreach (var _ret in retiros)
                        {
                            Txt_No_Retiro.Text = _ret.no_retiro;
                            Txt_Cantidad.Text = _ret.cantidad.ToString();
                            // se ocupa .GetDateTime() cuando es un tipo MySqlDateTime
                            Dtp_Fecha.Value = _ret.fecha.Value.GetDateTime();
                            Dtp_Hora.Value = _ret.hora.Value.GetDateTime();
                            Txt_Motivo.Text = _ret.motivo;
                        }
                    }
                }
            }
        }
        #endregion

        #region (Eventos)

        #region (Botones)
        /// <summary>
        /// Nombre: Btn_Nuevo_Click
        /// 
        /// Descripción: Método que se liga al evento click del botón de alta.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 13:48 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {

                if (Btn_Nuevo.Text.Trim() == "Nuevo")
                {
                    if (Autorizar_Movimiento())
                    {
                        Manejo_Botones_Operacion("Nuevo");
                        Limpiar_Controles(); 
                    }
                    else
                    {
                        MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (this.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        if (Validar_Datos())
                        {
                            if (Alta_Retiro())
                            {
                                Manejo_Botones_Operacion("Cancelar");
                                Limpiar_Controles();
                            }
                        }                        
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Btn_Nuevo_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Modificar_Click
        /// 
        /// Descripción: Método que se liga al evento click del botón dactualizar datos del retiro
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 14:08 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Modificar.Text.Trim().Equals("Modificar"))
                {
                    if (Autorizar_Movimiento())
                    {
                        if (!string.IsNullOrEmpty(Txt_No_Retiro.Text))
                        {
                            Manejo_Botones_Operacion("Modificar");
                        }
                        else
                        {
                            MessageBox.Show(this, "No se ha seleccionado ningún registro de retiro de caja a modificar.",
                                "Modificar Retiro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (Validar_Datos())
                    {
                        if (Actualizar_Retiro())
                        {
                            Manejo_Botones_Operacion("Cancelar");
                            Limpiar_Controles();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Btn_Modificar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Eliminar_Click
        /// 
        /// Descripción: Método que se liga al evento click del botón de eliminar.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 14:03 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Ope_Retiros_Negocio Obj_Retiros = new Cls_Ope_Retiros_Negocio();//Variable para realizar peticiones a la clase de negocios.

            try
            {
                if (Autorizar_Movimiento())
                {
                    if (!string.IsNullOrEmpty(Txt_No_Retiro.Text))
                    {
                        if (MessageBox.Show(this, "¿Esta seguro de eliminar el registro (" + Txt_No_Retiro.Text + ")?", "Advertencia", MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (Validar_Datos())
                            {
                                Eliminar_Retiro();
                                Manejo_Botones_Operacion("Cancelar");
                                Limpiar_Controles();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No se ha seleccionado ningún registro de retiro de caja a eliminar.", "Eliminar Retiro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Btn_Eliminar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Salir_Click
        /// 
        /// Descripción: Evento de salir de la forma.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 14:13 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Salir.Text == "Salir")
            {
                this.Dispose();
                this.Close();
                this.Usuario_Autoriza = string.Empty;
            }
            else
            {
                Manejo_Botones_Operacion("Cancelar");
                Limpiar_Controles();
            }
        }
        #endregion

        #region (Combos)
        /// <summary>
        /// Nombre: Cmb_Caja_SelectedIndexChanged
        /// 
        /// Descripción: Evento que se liga al listado de cajas abiertas y carga los
        ///              retiros que se han realizado en la caja seleccionada.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 17:03 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Caja_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos_Caja_Abierta();
        }
        #endregion

        #region (Cajas)
        /// <summary>
        /// Nombre: Txt_Cantidad_OnLostFocus
        /// 
        /// Descripción: Método que se ejecuta cuando la caja de texto pierde el foco.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 12 Noviembre 2013 18:40 Hrs.
        /// Usuario Creo:
        /// Fecha Creo:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Cantidad_OnLostFocus(object sender, EventArgs e)
        {
            decimal Disponible_Caja = 0;//Variable que almacenara el disponible en caja.
            decimal Monto_Retirar = 0;//Variable que almacenara el monto a retirar de caja.

            try
            {
                Disponible_Caja = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Disponible_Caja.Text) ? "0.0" : Txt_Disponible_Caja.Text.Trim());
                Monto_Retirar = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Cantidad.Text) ? "0.0" : Txt_Cantidad.Text.Trim());

                if (Monto_Retirar > Disponible_Caja)
                {
                    Txt_Cantidad.Text = string.Empty;
                    MessageBox.Show(this, "No es posible retirar mas del disponible en caja.", "Información Retiro de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Txt_Cantidad_OnLostFocus]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Ventana)
        /// <summary>
        /// Nombre: Frm_Ope_Retiros_FormClosed
        /// 
        /// Descripción: Método que se liga al evento de cerrar la ventana.y que limpia
        ///              la variable que nos indica el usuario que autoriza el movimiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 05 Octubre 2013 14:15 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Ope_Retiros_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Limpiamos la variable que almacena el usuario que autoriza el movimiento.
            this.Usuario_Autoriza = string.Empty;
        }
        #endregion

        #endregion

        #region (Eventos Validación)
        /// <summary>
        /// Nombre: Txt_Cantidad_KeyPress
        /// 
        /// Descripción: Método que se liga al evento de presionar una tecla de la caja de texto cantidad.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 14:27 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }
        /// <summary>
        /// Nombre: Txt_Motivo_KeyPress
        /// 
        /// Descripción: Método que se liga al evento de presionar una tecla de la caja de texto motivo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 14:27 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Motivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }
        /// <summary>
        /// Nombre: Txt_Cantidad_Validating
        /// 
        /// Descripción: Método que valida que se halla ingresado alguna cantidad.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 12 Noviembre 2013 19:04 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Cantidad_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
        }
        /// <summary>
        /// Nombre: Txt_Motivo_Validating
        /// 
        /// Descripción: Método que valida que se halla ingresado algun motivo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 12 Noviembre 2013 19:04 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Motivo_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
        }
        #endregion
    }
    /// <summary>
    /// Nombre: Frm_Apl_Usuario_Autoriza
    /// 
    /// Descripción: Clase que crea una ventana para realizar la autorización
    ///              del usuario que valida el movimiento de retiro de caja.
    /// </summary>
    public class Frm_Apl_Usuario_Autoriza {
        /// <summary>
        /// Nombre: Mostrar_Ventana
        /// 
        /// Descripción: Método que crea una ventana con los campos necesarios para realizar la autorización
        ///              del movimiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 05 Octubre 2013 11:05 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Titulo">Titulo que se le asignara a la ventana</param>
        /// <returns>Identificador del usuario que autoriza el movimiento</returns>
        public string Mostrar_Ventana(string Titulo, Form _Parent) {
            Cls_Apl_Usuarios_Negocio Rs_Usuario_logueado = new Cls_Apl_Usuarios_Negocio();//Variable de negocios para realizar peticiones del usaurio.
            DataTable Dt_Resultado = new DataTable();//Tabla para almacenar los datos del usuario que esta autorizando el movimiento.
            string Usuario_ID_Autoriza = string.Empty;//Variable para almacenar el identificador del empleado que autoriza el movimiento.

            //Creamos la ventana para la autorización.
            ResizableForm Ventana_Validacion_Usuario = new ResizableForm();
            Ventana_Validacion_Usuario.Width = 200;
            Ventana_Validacion_Usuario.Height = 150;
            Ventana_Validacion_Usuario.Text = Titulo;
            Ventana_Validacion_Usuario.FormBorderStyle = FormBorderStyle.Sizable;
            Ventana_Validacion_Usuario.MaximizeBox = true;
            Ventana_Validacion_Usuario.MinimizeBox = true;

            //Definimos y creamos los controles que tendrá el formulario de autorización del movimiento.
            Label Lbl_Usuario = new Label() { Left = 10, Top = 20, Text = "Usuario", Width = 60 };
            TextBox Txt_Usuario = new TextBox() { Left = 70, Top = 20, Width = 100, Height= 18 };
            Label Lbl_Password = new Label() { Left = 10, Top = 50, Text = "Password", Width = 60 };
            TextBox Txt_Password = new TextBox() { Left = 70, Top = 50, Width = 100 };
            Txt_Password.PasswordChar = '*';

            Button Btn_Autorizar_Movimiento = new Button() { Text = "Autorizar", Left = 60, Width = 75, Top = 80, Height = 24 };
            Btn_Autorizar_Movimiento.Font = new System.Drawing.Font("Arial", 10F);

            //Establecemos el manejador de evento del botón y definimos la tarea que desencadena el mismo (Consultar al usuario, por su usuario y password).
            Btn_Autorizar_Movimiento.Click += (sender, e) => { 
                Ventana_Validacion_Usuario.Close();

                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable Dt_Consulta = new DataTable();

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
                Rs_Usuario_logueado.P_Rol_ID = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Rol_Id].ToString();
                Rs_Usuario_logueado.P_Usuario = Txt_Usuario.Text.ToString();
                Rs_Usuario_logueado.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Password.Text.ToString());
                Dt_Resultado = Rs_Usuario_logueado.Consultar_Usuario();

                var users = (Dt_Resultado.AsEnumerable().
                    Select(_user => new { usuario_id = _user.IsNull(Apl_Usuarios.Campo_Usuario_Id) ? string.Empty : _user.Field<string>(Apl_Usuarios.Campo_Usuario_Id) }));
                    //Select(_user => new { usuario_id = _user.IsNull(Apl_Usuarios.Campo_Nombre_Usuario) ? string.Empty : _user.Field<string>(Apl_Usuarios.Campo_Nombre_Usuario) }));
                
                if (users.Any())
                    foreach (var user in users)
                        Usuario_ID_Autoriza = user.usuario_id;
            };
            //Se agregan los controles al formulario.
            Ventana_Validacion_Usuario.Controls.Add(Btn_Autorizar_Movimiento);
            Ventana_Validacion_Usuario.Controls.Add(Lbl_Usuario);
            Ventana_Validacion_Usuario.Controls.Add(Txt_Usuario);
            Ventana_Validacion_Usuario.Controls.Add(Lbl_Password);
            Ventana_Validacion_Usuario.Controls.Add(Txt_Password);
            Ventana_Validacion_Usuario.ShowDialog(_Parent);
            return Usuario_ID_Autoriza;
        }
    }
}
