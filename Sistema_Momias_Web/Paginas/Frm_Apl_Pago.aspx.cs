using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using Erp.Metodos_Generales;
using Erp.Principal.Negocio;
using Erp.Productos_Detalles;
using Newtonsoft.Json;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Erp_Apl_Parametros.Negocio;
using Erp.Constantes;
using Erp.Seguridad;
using Ean13Barcode2005;

namespace WEB
{
    public partial class Paginas_Frm_Apl_Pago : System.Web.UI.Page
    {
        private Cls_Apl_Principal_Negocio Negocio_Ventas;
        private DataTable Productos;
        private DataTable Accesos;
        private string Ruta_Pdf;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CcErrCode"] != null)
                {
                    int ccErrCode = Convert.ToInt16(Request.QueryString["CcErrCode"]);

                    if (ccErrCode == 50)
                    {
                        /*Mensaje de Error*/
                        Img_Operacion.ImageUrl = "../Imagenes/paginas/cross-mark.png";
                        Img_Operacion.CssClass = "Img";
                        Lbl_Mensaje.CssClass = "alert-box error";
                        Lbl_Msj.Text = "error al realizar la compra. ";
                        Lbl_Msj.Text += Request.QueryString["Text"];

                        return;
                    }

                    Img_Operacion.ImageUrl = "../Imagenes/paginas/confirm.png";
                    Img_Operacion.CssClass = "Img";
                    Lbl_Mensaje.CssClass = "alert-box success";
                    Lbl_Msj.Text = "Gracias por Realizar su compra.";

                    if (Application["Compra"] != null)
                    {
                        Negocio_Ventas = (Cls_Apl_Principal_Negocio)Application["Compra"];
                        Application.Remove("Compra");

                        Negocio_Ventas.P_Numero_Transaccion = Request.QueryString["OrderId"];
                        Productos = Crear_Dt_Productos(Negocio_Ventas.P_Productos);

                        Grd_Productos.DataSource = Productos;
                        Grd_Productos.DataBind();

                        Accesos = Generar_Venta_BD(Negocio_Ventas, Productos);
                        Ruta_Pdf = Generar_Pdf(Negocio_Ventas, Accesos);

                        try
                        {
                            Lbl_Ruta_Pdf.Text = Ruta_Pdf;
                            Enviar_Correo_Pdf(Negocio_Ventas.P_Email, Ruta_Pdf);
                        }
                        catch (Exception ex)
                        {
                            Lbl_Msj.Text = "Ocurrió un error al enviar los boletos al correo asignado.<br />";
                            Lbl_Msj.Text += "Detalle del Error: " + ex.Message;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metodo para formatear las fechas
        /// </summary>
        /// <returns>La cadena con el formato de fecha yyyy/mm/dd</returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>21/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private String Formatear_Fecha(String Fecha)
        {
            String[] Fechas;
            String Mes = String.Empty;
            String Dia = String.Empty;
            String Anio = String.Empty;

            try
            {
                if (!String.IsNullOrEmpty(Fecha.Trim()))
                {
                    Fechas = Fecha.Split('/');

                    Mes = String.Format("{0:00}", Convert.ToInt32(Fechas[0].Trim()));
                    Dia = String.Format("{0:00}", Convert.ToInt32(Fechas[1].Trim()));
                    Anio = String.Format("{0:0000}", Convert.ToInt32(Fechas[2].Trim()));

                    Fecha = Anio + "/" + Mes + "/" + Dia;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al formatear la fecha Error[" + Ex.Message + "]");
            }

            return Fecha;
        }

        /// <summary>
        /// Metodo para generar la venta 
        /// </summary>
        /// <param name="Productos">Productos que se adquiriran en la compra</param>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>30/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private DataTable Generar_Venta_BD(Cls_Apl_Principal_Negocio Negocio, DataTable Dt_Productos)
        {
            DataTable Dt_Productos_Accesos = new DataTable();
            try
            {
                Negocio.P_Subtotal = Convert.ToDecimal(String.IsNullOrEmpty(Negocio.P_Total) ? "0" : Negocio.P_Total);
                Negocio.P_Total_Venta = Convert.ToDecimal(String.IsNullOrEmpty(Negocio.P_Total) ? "0" : Negocio.P_Total);
                Negocio.P_Estatus = "PAGADA";
                Negocio.P_Fecha_Inicio_Vigencia = Convert.ToDateTime(Formatear_Fecha(Negocio.P_Fecha));
                //String VigenciaFin = 
                //String Vigencia = VigenciaFin.Substring(0, 10);
                Negocio.P_Fecha_Termino_Vigencia = Obtener_Vigencia_Fin();
                Negocio.P_Dt_Ventas = Dt_Productos;
                Negocio.P_Dt_Pagos = Generar_Dt_Pagos(Negocio);

                if (Negocio.Alta_Venta())
                {
                    Dt_Productos_Accesos = Negocio.P_Dt_Productos;
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar la venta. Error[" + Ex.Message + "]");
            }
            return Dt_Productos_Accesos;
        }

        /// <summary>
        /// Metodo para generar la tabla de la venta 
        /// </summary>
        /// <param name="Productos">tabla con los datos de los pagos</param>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>31/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private DataTable Generar_Dt_Pagos(Cls_Apl_Principal_Negocio Negocio)
        {
            DataTable Dt_Pagos = new DataTable();
            DataRow Fila = null;

            try
            {
                Dt_Pagos.Columns.Add("Forma_Id", typeof(String));
                Dt_Pagos.Columns.Add("Monto_Pago", typeof(Decimal));
                Dt_Pagos.Columns.Add("Numero_Transaccion", typeof(String));
                Dt_Pagos.Columns.Add("Numero_Tarjeta_Banco", typeof(String));
                Dt_Pagos.Columns.Add("Estatus", typeof(String));

                Fila = Dt_Pagos.NewRow();
                Fila["Forma_Id"] = Negocio.Obtener_Forma_Pago();
                Fila["Monto_Pago"] = Convert.ToDecimal(String.IsNullOrEmpty(Negocio.P_Total) ? "0" : Negocio.P_Total);
                Fila["Numero_Transaccion"] = Negocio.P_Numero_Transaccion;
                Fila["Numero_Tarjeta_Banco"] = Negocio.P_Numero_Tarjeta;
                Fila["Estatus"] = "PAGADO";
                Dt_Pagos.Rows.Add(Fila);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar la tabla de pagos. Error[" + Ex.Message + "]");
            }
            return Dt_Pagos;
        }

        /// <summary>
        /// Metodo para obtener la tabla de los productos 
        /// </summary>
        /// <param name="Productos">Productos que se adquiriran en la compra</param>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>29/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private DataTable Crear_Dt_Productos(ArrayList Productos)
        {
            Cls_Productos_Detalles Productos_Detalle = new Cls_Productos_Detalles();
            DataTable Dt_Productos = new DataTable();
            int i = 0;
            String Registro = String.Empty;
            DataRow Fila = null;

            try
            {
                //creamos las columnas del datatable
                Dt_Productos.Columns.Add("PRODUCTO_ID", typeof(String));
                Dt_Productos.Columns.Add("CANTIDAD", typeof(Decimal));
                Dt_Productos.Columns.Add("COSTO", typeof(Decimal));
                Dt_Productos.Columns.Add("TOTAL", typeof(Decimal));
                Dt_Productos.Columns.Add("TIPO", typeof(String));
                Dt_Productos.Columns.Add("DESCRIPCION", typeof(String));
                Dt_Productos.Columns.Add("RUTA_IMAGEN", typeof(String));
                Dt_Productos.Columns.Add("CODIGO", typeof(String));

                for (i = 0; i < Productos.Count; i++)
                {
                    Registro = Productos[i].ToString();//obtenemos el registro json del producto 
                    Productos_Detalle = JsonConvert.DeserializeObject<Cls_Productos_Detalles>(Registro);  //deserealizamos el json con los datos del producto

                    //agregamos los datos al datatable
                    Fila = Dt_Productos.NewRow();
                    Fila["PRODUCTO_ID"] = Productos_Detalle.Producto_Id;
                    Fila["CANTIDAD"] = Convert.ToDecimal(String.IsNullOrEmpty(Productos_Detalle.Cantidad) ? "0" : Productos_Detalle.Cantidad);
                    Fila["COSTO"] = Convert.ToDecimal(String.IsNullOrEmpty(Productos_Detalle.Costo) ? "0" : Productos_Detalle.Costo);
                    Fila["TOTAL"] = Convert.ToDecimal(String.IsNullOrEmpty(Productos_Detalle.Subtotal) ? "0" : Productos_Detalle.Subtotal);
                    Fila["TIPO"] = Productos_Detalle.Tipo;
                    Fila["DESCRIPCION"] = Productos_Detalle.Descripcion;
                    Fila["RUTA_IMAGEN"] = Productos_Detalle.Ruta_Imagen;
                    Fila["CODIGO"] = Productos_Detalle.Codigo;
                    Dt_Productos.Rows.Add(Fila);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al obtener los productos. Error[" + Ex.Message + "]");
            }
            return Dt_Productos;
        }

        /// <summary>
        /// Metodo para generar el pdf
        /// </summary>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>31/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private String Generar_Pdf(Cls_Apl_Principal_Negocio Negocio, DataTable Dt_Productos_Accesos)
        {
            DataTable Dt_Encabezado = new DataTable();
            DataRow Fila = null;
            DataSet Ds_Reporte = new DataSet();
            DataTable Dt_Detallado_Accesos = new DataTable();
            try
            {
                //creamos el encabezado del pdf
                Dt_Encabezado.Columns.Add("IMAGEN_ENCABEZADO", typeof(Byte[]));
                Dt_Encabezado.Columns.Add("NOMBRE", typeof(String));
                Dt_Encabezado.Columns.Add("ESTADO", typeof(String));
                Dt_Encabezado.Columns.Add("CUIDAD", typeof(String));
                Dt_Encabezado.Columns.Add("DOMICILIO", typeof(String));
                Dt_Encabezado.Columns.Add("CP", typeof(String));
                Dt_Encabezado.Columns.Add("EMAIL", typeof(String));
                Dt_Encabezado.Columns.Add("NO_TARJETA", typeof(String));
                Dt_Encabezado.Columns.Add("TELEFONO", typeof(String));
                Dt_Encabezado.Columns.Add("TOTAL", typeof(String));
                Dt_Encabezado.Columns.Add("LEYENDA", typeof(String));
                Dt_Encabezado.Columns.Add("FOLIO", typeof(String));

                Fila = Dt_Encabezado.NewRow();
                //Fila["IMAGEN_ENCABEZADO"] = Cls_Metodos_Generales.Convertir_Imagen_Bytes(@Server.MapPath(ConfigurationManager.AppSettings["Imagen_Encabezado_Reporte"]), 200, 300);
                string Ruta_Archivo = Obtener_Directorio_Compartido();
                Ruta_Archivo += "/Imagenes/WEB/EncabezadoPDF.png";
                Fila["IMAGEN_ENCABEZADO"] = Cls_Metodos_Generales.Convertir_Imagen_Bytes(Ruta_Archivo, 200, 300);

                Fila["NOMBRE"] = Negocio.P_Nombre;
                Fila["ESTADO"] = Negocio.P_Estado;
                Fila["CUIDAD"] = Negocio.P_Ciudad;
                Fila["DOMICILIO"] = Negocio.P_Domicilio;
                Fila["CP"] = Negocio.P_Codigo_Postal;
                Fila["EMAIL"] = Negocio.P_Email;
                Fila["NO_TARJETA"] = Negocio.P_Numero_Tarjeta;
                Fila["TELEFONO"] = Negocio.P_Telefono;
                Fila["TOTAL"] = String.Format("{0:c}", Convert.ToDouble(String.IsNullOrEmpty(Negocio.P_Total) ? "0" : Negocio.P_Total));
                Fila["LEYENDA"] = Obtener_Leyenda_Boleto();
                Fila["FOLIO"] = Negocio.P_No_Venta;
                Dt_Encabezado.Rows.Add(Fila);

                Dt_Detallado_Accesos = Crear_Dt_Productos_Servicios_Detallados(Dt_Productos_Accesos, Negocio);
                //filtramos solo los accesos por productos
                Dt_Detallado_Accesos = (from Fila_Det in Dt_Detallado_Accesos.AsEnumerable()
                                        where Fila_Det.Field<String>("TIPO") == "Producto"
                                        select Fila_Det).AsDataView().ToTable();


                // Renombra las tablas
                Dt_Encabezado.TableName = "DT_ENCABEZADO"; //encabezado del reprote
                Dt_Detallado_Accesos.TableName = "DT_DETALLADO_ACCESOS"; //detalles de los accesos desglosado por unidad
                Dt_Productos_Accesos.TableName = "DT_PRODUCTOS_ACCESOS"; // productos de la compra

                Ds_Reporte.Tables.Add(Dt_Encabezado.Copy());
                Ds_Reporte.Tables.Add(Dt_Detallado_Accesos.Copy());
                Ds_Reporte.Tables.Add(Dt_Productos_Accesos.Copy());

                Generar_Reporte(ref Ds_Reporte, "Rpt_Detalles_Compra.rpt", "Entradas_Museo_" + Convert.ToInt32(String.IsNullOrEmpty(Negocio.P_No_Venta) ? "1" : Negocio.P_No_Venta) + ".pdf", "../Rpt/");
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el Pdf. Error[" + Ex.Message + ", " + Ex.InnerException + "]");
            }
            return "../Rpt/Entradas_Museo_" + Convert.ToInt32(String.IsNullOrEmpty(Negocio.P_No_Venta) ? "1" : Negocio.P_No_Venta) + ".pdf";
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
        protected void Generar_Reporte(ref DataSet Ds_Datos, String Nombre_Plantilla_Reporte, String Nombre_Reporte_Generar, string Ruta_PDF)
        {
            ReportDocument Reporte = new ReportDocument();//Variable de tipo reporte.
            String Ruta = String.Empty;//Variable que almacenara la ruta del archivo del crystal report. 

            try
            {
                Ruta = @Server.MapPath("../Plantillas_Crystal/" + Nombre_Plantilla_Reporte);
                Reporte.Load(Ruta);

                if (Ds_Datos is DataSet)
                {
                    if (Ds_Datos.Tables.Count > 0)
                    {
                        Reporte.SetDataSource(Ds_Datos);
                        Exportar_Reporte_PDF(Reporte, Nombre_Reporte_Generar, Ruta_PDF);
                        //Mostrar_Reporte(Nombre_Reporte_Generar);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte. Error: [" + Ex.Message + "]");
            }
        }

        /// *************************************************************************************
        /// NOMBRE: Exportar_Reporte_PDF
        /// 
        /// DESCRIPCIÓN: Método que guarda el reporte generado en formato PDF en la ruta
        ///              especificada.
        ///              
        /// PARÁMETROS: Reporte.- Objeto de tipo documento que contiene el reporte a guardar.
        ///             Nombre_Reporte.- Nombre que se le dará al reporte.
        /// 
        /// USUARIO CREO: Juan Alberto Hernández Negrete.
        /// FECHA CREO: 3/Mayo/2011 18:19 p.m.
        /// USUARIO MODIFICO:
        /// FECHA MODIFICO:
        /// CAUSA MODIFICACIÓN:
        /// *************************************************************************************
        protected void Exportar_Reporte_PDF(ReportDocument Reporte, String Nombre_Reporte, string Ruta_PDF)
        {
            ExportOptions Opciones_Exportacion = new ExportOptions();
            DiskFileDestinationOptions Direccion_Guardar_Disco = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions Opciones_Formato_PDF = new PdfRtfWordFormatOptions();
            Ruta_PDF = @Server.MapPath(Ruta_PDF) + Nombre_Reporte;
            try
            {
                if (Reporte is ReportDocument)
                {
                    Direccion_Guardar_Disco.DiskFileName = Ruta_PDF;
                    Opciones_Exportacion.ExportDestinationOptions = Direccion_Guardar_Disco;
                    Opciones_Exportacion.ExportDestinationType = ExportDestinationType.DiskFile;
                    Opciones_Exportacion.ExportFormatType = ExportFormatType.PortableDocFormat;
                    Reporte.Export(Opciones_Exportacion);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al exportar el reporte. Error: [" + Ex.Message + "]");
            }
        }

        /// <summary>
        /// Metodo para obtener la leyenda del boleto
        /// </summary>
        ///  /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>05/Junio/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private String Obtener_Leyenda_Boleto()
        {
            Cls_Apl_Parametros_Negocio Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros = new DataTable();
            String Leyenda = String.Empty;
            try
            {
                Dt_Parametros = Parametros.Consultar_Parametros();
                if (Dt_Parametros != null)
                {
                    if (Dt_Parametros.Rows.Count > 0)
                    {
                        if (!String.IsNullOrEmpty(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Leyenda].ToString().Trim()))
                            Leyenda = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Leyenda].ToString().Trim();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al obtener la leyenda del boleto. Error[" + Ex.Message + "]");
            }
            return Leyenda;
        }

        /// <summary>
        /// Metodo para crear el detalle de la compra para el pdf
        /// </summary>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>31/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private DataTable Crear_Dt_Productos_Servicios_Detallados(DataTable Dt_Productos_Accesos, Cls_Apl_Principal_Negocio Negocio)
        {
            DataTable Dt_Detallado = new DataTable();
            DataRow Fila = null;
            Int32 Cantidad = 0;
            int i = 0;
            String[] Accesos = null;
            String Acceso = String.Empty;

            try
            {
                if (Dt_Productos_Accesos != null)
                {
                    if (Dt_Productos_Accesos.Rows.Count > 0)
                    {
                        //creamos las columnas del datatable de detalles para el pdf
                        Dt_Detallado.Columns.Add("NO", typeof(Int32));
                        Dt_Detallado.Columns.Add("NOMBRE", typeof(String));
                        Dt_Detallado.Columns.Add("NO_ACCESO", typeof(String));
                        Dt_Detallado.Columns.Add("LUGAR_VENTA", typeof(String));
                        Dt_Detallado.Columns.Add("COSTO", typeof(String));
                        Dt_Detallado.Columns.Add("PRODUCTO", typeof(String));
                        Dt_Detallado.Columns.Add("CODIGO", typeof(String));
                        Dt_Detallado.Columns.Add("FECHA", typeof(String));
                        Dt_Detallado.Columns.Add("TIPO", typeof(String));
                        Dt_Detallado.Columns.Add("IMAGEN", typeof(Byte[]));
                        Dt_Detallado.Columns.Add("BARCODE", typeof(Byte[]));

                        //RECORREMOS EL DATATABLE PARA MANDAR LOS DETALLES
                        foreach (DataRow Dr in Dt_Productos_Accesos.Rows)
                        {
                            Cantidad = Convert.ToInt32(String.IsNullOrEmpty(Dr["CANTIDAD"].ToString()) ? "0" : Dr["CANTIDAD"]);
                            if (Dr["TIPO"].ToString().Trim().Equals("Producto"))
                                Accesos = Dr["ACCESOS"].ToString().Split(',');

                            for (i = 1; i <= Cantidad; i++)
                            {
                                Fila = Dt_Detallado.NewRow();
                                Fila["NO"] = i;
                                Fila["NOMBRE"] = Negocio.P_Nombre;
                                if (Dr["TIPO"].ToString().Trim().Equals("Producto"))
                                    Fila["NO_ACCESO"] = "*" + Accesos[i - 1].ToString().Trim() + "*";
                                else
                                    Fila["NO_ACCESO"] = "";
                                Fila["LUGAR_VENTA"] = "Internet";
                                Fila["COSTO"] = String.Format("{0:c}", Dr["COSTO"]);
                                Fila["PRODUCTO"] = Dr["DESCRIPCION"].ToString().Trim();
                                Fila["CODIGO"] = Dr["CODIGO"].ToString().Trim();
                                Fila["FECHA"] = String.Format("{0:dd/MMM/yyyy}", Negocio.P_Fecha_Inicio_Vigencia);
                                Fila["TIPO"] = Dr["TIPO"].ToString().Trim(); ;
                                //Fila["IMAGEN"] = Cls_Metodos_Generales.Convertir_Imagen_Bytes(@Server.MapPath(ConfigurationManager.AppSettings["Imagen_Boleto"]), 200, 300);
                                string Ruta_Archivo = Obtener_Directorio_Compartido();
                                Ruta_Archivo += "/Imagenes/WEB/Boleto.png";
                                Fila["IMAGEN"] = Cls_Metodos_Generales.Convertir_Imagen_Bytes(Ruta_Archivo, 200, 300);
                                
                                Ean13 Codigo = new Ean13();
                                Codigo.ManufacturerCode = Accesos[i - 1].Trim().Substring(0, 5);
                                Codigo.ProductCode = Accesos[i - 1].Trim().Substring(5, 5);
                                Codigo.ChecksumDigit = "0";
                                Codigo.Scale = 1.8f;
                                System.Drawing.Bitmap bmp = Codigo.CreateBitmap();

                                string Ruta_Codigo = Server.MapPath("~/Codigos/codigo.bmp");
                                bmp.Save(Ruta_Codigo);

                                Fila["BARCODE"] = ConversionImagen(Ruta_Codigo);

                                Dt_Detallado.Rows.Add(Fila);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar la tabla detallada de productos y servicios. Error[" + Ex.Message + "]");
            }

            return Dt_Detallado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: ConversionImagen();
        ///DESCRIPCIÓN: Convierte una imagen en un byte[]
        ///PARAMETROS:  devuelve un byte[] que contiene la imagen .   
        ///CREO: Cruz Amaya Olimpo Alberto.
        ///FECHA_CREO: 13/Diciembre/2014 
        ///MODIFICO:
        ///FECHA_MODIFICO
        ///CAUSA_MODIFICACIÓN
        ///*******************************************************************************  
        public static byte[] ConversionImagen(string nombrearchivo)
        {
            //Declaramos fs para poder abrir la imagen.
            FileStream fs = new FileStream(nombrearchivo, FileMode.Open);

            // Declaramos un lector binario para pasar la imagen
            // a bytes
            BinaryReader br = new BinaryReader(fs);
            byte[] imagen = new byte[(int)fs.Length];
            br.Read(imagen, 0, (int)fs.Length);
            br.Close();
            fs.Close();
            return imagen;
        }

        /// <summary>
        /// Metodo para enviar por correo el pdf 
        /// </summary>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>29/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private void Enviar_Correo_Pdf(String Correo_Destino, String Ruta_Archivo)
        {
            Cls_Apl_Parametros_Negocio Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros = new DataTable();
            MailMessage Correo = new MailMessage(); //obtenemos el objeto del correo
            String Correo_Origen = String.Empty;
            String Host = string.Empty;
            String Contrasenia = String.Empty;
            String Puerto = String.Empty;
            String Asunto = String.Empty;
            String Texto_Correo = String.Empty;

            try
            {
                Dt_Parametros = Parametros.Consultar_Parametros();
                if (Dt_Parametros != null)
                {
                    if (Dt_Parametros.Rows.Count > 0)
                    {
                        Correo_Origen = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Email].ToString().Trim();
                        Host = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Host_Email].ToString().Trim();
                        Contrasenia = Cls_Seguridad.Desencriptar(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Contrasenia].ToString().Trim());
                        Puerto = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Puerto].ToString().Trim();

                        if (!String.IsNullOrEmpty(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Asunto_Correo].ToString().Trim()))
                            Asunto = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Asunto_Correo].ToString().Trim();

                        if (!String.IsNullOrEmpty(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Texto_Correo].ToString().Trim()))
                            Texto_Correo = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Texto_Correo].ToString().Trim();

                        if (!String.IsNullOrEmpty(Correo_Destino) && !String.IsNullOrEmpty(Puerto)
                             && !String.IsNullOrEmpty(Correo_Origen)
                             && !String.IsNullOrEmpty(Host) && !String.IsNullOrEmpty(Contrasenia))
                        {
                            Correo.To.Clear();
                            Correo.To.Add(Correo_Destino);
                            Correo.From = new MailAddress(Correo_Origen, "Museo Momias Guanajuato", System.Text.Encoding.UTF8);
                            Correo.Subject = Asunto;
                            Correo.SubjectEncoding = System.Text.Encoding.UTF8;

                            if ((!Correo.From.Equals("") || Correo.From != null) && (!Correo.To.Equals("") || Correo.To != null))
                            {
                                Correo.Body = "<html>" +
                                                "<body style=\"font-family:Consolas; font-size:10pt;\"> " +
                                                  Texto_Correo + " <br />" +
                                               "</body>" +
                                             "</html>";
                                Correo.BodyEncoding = System.Text.Encoding.UTF8;
                                Correo.IsBodyHtml = true;

                                //agregamos el dato adjunto
                                Attachment Data = new Attachment(@Server.MapPath(Ruta_Archivo), MediaTypeNames.Application.Octet);
                                // Agrega la informacion del tiempo del archivo.
                                ContentDisposition disposition = Data.ContentDisposition;
                                disposition.DispositionType = DispositionTypeNames.Attachment;
                                // Agrega los archivos adjuntos al mensaje
                                Correo.Attachments.Add(Data);

                                SmtpClient Cliente_Correo = new SmtpClient();
                                Cliente_Correo.UseDefaultCredentials = false;
                                Cliente_Correo.Credentials = new System.Net.NetworkCredential(Correo_Origen, Contrasenia);
                                Cliente_Correo.Port = int.Parse(Puerto);
                                Cliente_Correo.Host = Host;
                                Cliente_Correo.EnableSsl = true;
                                Cliente_Correo.DeliveryMethod = SmtpDeliveryMethod.Network;
                                Cliente_Correo.Send(Correo);
                                Correo = null;
                            }
                            else
                            {
                                throw new Exception("No se tiene configurada una cuenta de correo, favor de notificar");
                            }
                        }

                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al enviar el correo con el Pdf. Error[" + Ex.Message + "]");
            }
        }

        /// <summary>
        /// Metodo para obtener el directorio compartido
        /// </summary>
        ///  /// <creo>Olimpo Cruz Amaya</creo>
        /// <fecha creo>21/Abril/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private String Obtener_Directorio_Compartido()
        {
            Cls_Apl_Parametros_Negocio Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros = new DataTable();
            String Directorio = String.Empty;
            try
            {
                Dt_Parametros = Parametros.Consultar_Parametros();
                if (Dt_Parametros != null)
                {
                    if (Dt_Parametros.Rows.Count > 0)
                    {
                        if (!String.IsNullOrEmpty(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Directorio_Compartido].ToString().Trim()))
                            Directorio = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Directorio_Compartido].ToString().Trim();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al obtener la leyenda del boleto. Error[" + Ex.Message + "]");
            }
            return Directorio;
        }

        /// <summary>
        /// Metodo para obtener el fecha vigencia fin
        /// </summary>
        ///  /// <creo>Olimpo Cruz Amaya</creo>
        /// <fecha creo>22/Abril/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        private DateTime Obtener_Vigencia_Fin()
        {
            Cls_Apl_Parametros_Negocio Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros = new DataTable();
            String Fecha_Vigencia = String.Empty;

            try
            {
                Dt_Parametros = Parametros.Consultar_Parametros();
                if (Dt_Parametros != null)
                {
                    if (Dt_Parametros.Rows.Count > 0)
                    {
                        if (!String.IsNullOrEmpty(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Vigencia_Web].ToString().Trim()))
                            Fecha_Vigencia = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Vigencia_Web].ToString().Trim();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al obtener la leyenda del boleto. Error[" + Ex.Message + "]");
            }

            return DateTime.Parse(Fecha_Vigencia);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Principal_Click(object sender, EventArgs e)
        {
            Response.Redirect("Frm_Apl_Principal.aspx");
        }
    }
}