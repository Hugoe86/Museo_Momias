using System;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using Erp_Apl_Parametros.Negocio;
using Punto_Venta.Impresiones;
using ERP_BASE.App_Code.Negocio.Catalogos;
using System.Text;
using System.Collections.Generic;
using ERP_BASE.App_Code.Negocio.Operaciones;
using Erp.Constantes;
using System.Threading;
using Erp.Helper;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ean13Barcode2005;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Ope_Impresiones.Negocio
{
    public class Cls_Ope_Impresiones_Negocio
    {
        #region Variables Internas
        private const SByte Anchura_Ticket = 40;
        private Font printFont;
        private Font Fuente_Texto = new Font("Arial", 7, FontStyle.Bold);
        private Font Fuente_Texto_Detalle = new Font("Arial", 8);
        private Font Fuente_Texto_Producto = new Font("Arial", 6, FontStyle.Bold);
        private Font Fuente_Codigo_Acceso = new Font("IDAutomationHC39M", 10);
        private StringFormat Formato_Centrado = new StringFormat();
        private string Numero_Serie_Acceso = "";
        private string Tipo_Acceso = "";
        private string Encabezado = "";
        private string Folio = "";
        private string Caja = "";
        private string Costo = "";
        private string Vigencia = "";
        private string Fecha_Impresion = "";
        private string Hora_Impresion = "";
        private Cls_Cat_Impresoras_Cajas_Negocio Obj_Impresora_Caja;
        private Dictionary<string, string> Valores_Reemplazar = new Dictionary<string, string>()
        {
                { "Á", "\x0A0" },
                { "É", "\x090" },
                { "Í", "\x0A1" },
                { "Ó", "\x0A2" },
                { "Ú", "\x0A3" },
                { "á", "\x0A0" },
                { "é", "\x090" },
                { "í", "\x0A1" },
                { "ó", "\x0A2" },
                { "ú", "\x0A3" },
                { "Ñ", "\x0A5" },
                { "ñ", "\x0A4" }
            };

        private String No_Descuento = String.Empty;
        private String No_Venta = String.Empty;
        private String Serie = String.Empty;
        private Int32 Cantidad = 0;
        private Decimal Total_Pago = 0;
        private Decimal Subtotal_Pago = 0;
        private String Motivo_Descuento = String.Empty;
        private Decimal Descuento_Pago = 0;
        private DateTime Fecha = DateTime.MinValue;
        private DataTable Dt_Datos_Pago;
        private DataTable Dt_Solicitud;
        private DataTable Dt_Formas_Pago;
        private DataTable Dt_Reimpresion;
        private String Texto_Recoleccion = String.Empty;
        private Double Total_Venta_En_Solicitd = 0;
        private String Imagen_Bits;
        private System.Windows.Forms.DataGridView Grid_Accesos;
        #endregion Variables Internas

        #region Variables Publicas
        public String P_No_Descuento
        {
            get { return No_Descuento; }
            set { No_Descuento = value; }
        }
        public String P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public String P_Serie
        {
            get { return Serie; }
            set { Serie = value; }
        }
        public Int32 P_Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public Decimal P_Monto_Pago
        {
            get { return Total_Pago; }
            set { Total_Pago = value; }
        }
        public Decimal P_Subtotal_Pago
        {
            get { return Subtotal_Pago; }
            set { Subtotal_Pago = value; }
        }
        public String P_Motivo_Descuento
        {
            get { return Motivo_Descuento; }
            set { Motivo_Descuento = value; }
        }
        public Decimal P_Descuento_Pago
        {
            get { return Descuento_Pago; }
            set { Descuento_Pago = value; }
        }
        public DateTime P_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public DataTable P_Dt_Datos_Pago
        {
            get { return Dt_Datos_Pago; }
            set { Dt_Datos_Pago = value; }
        }

        public DataTable P_Dt_Solicitud
        {
            get { return Dt_Solicitud; }
            set { Dt_Solicitud = value; }
        }

        public DataTable P_Dt_Formas_Pago
        {
            get { return Dt_Formas_Pago; }
            set { Dt_Formas_Pago = value; }
        }
        public System.Windows.Forms.DataGridView P_Grid_Accesos
        {
            get { return Grid_Accesos; }
            set { Grid_Accesos = value; }
        }

        public DataTable P_Dt_Reimpresion
        {
            get { return Dt_Reimpresion; }
            set { Dt_Reimpresion = value; }
        }

        public String P_Texto_Recoleccion
        {
            get { return Texto_Recoleccion; }
            set { Texto_Recoleccion = value; }
        }

        public Double P_Total_Venta_En_Solicitd
        {
            get { return Total_Venta_En_Solicitd; }
            set { Total_Venta_En_Solicitd = value; }
        }
        public string P_Imagen_Bits
        {
            get { return Imagen_Bits; }
            set { Imagen_Bits = value; }
        }
        #endregion Variables Publicas

        #region Metodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Imprimir_Pago
        ///DESCRIPCIÓN          : Manda los datos a la impresora
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Imprimir_Pago()
        {
            try
            {
                // consultar impresoras para la caja actual
                Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                // imprimir recibo de pago
                //Imprimir_Recibo();
                Imprimir_Solicitud_Recibo_Venta();
                Imprimir_Accesos();

                //// imprimir accesos en una tarea diferente para evitar el tiempo de espera si se imprime una cantidad considerable
                //Thread Tarea_Impresion = new Thread(Imprimir_Accesos);
                //// se asigna como tarea de fondo para que la aplicación pueda continuar mientras esta nueva tarea termina de ejecutarse
                //Tarea_Impresion.IsBackground = true;
                //Tarea_Impresion.Start();

            }
            catch (Exception Ex)
            {
                throw new Exception("Error de impresión: " + Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : ReImprimir_Accesos
        ///DESCRIPCIÓN          : Manda los datos a la impresora
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 13/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void ReImprimir_Accesos()
        {
            String Encabezado_Boleto = "";
            String Hora = "";
            DateTime Fecha ;
            PrintDocument Prn_Impresion;

            DataGridViewCheckBoxCell Check_Box_Cell = new DataGridViewCheckBoxCell();
            try
            {
                // consultar impresoras para la caja actual
                Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                Encabezado_Boleto = Obj_Parametros.P_Encabezado_Recibo;


                if (Grid_Accesos != null && Grid_Accesos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Registro in Grid_Accesos.Rows)
                    {
                        Check_Box_Cell = new DataGridViewCheckBoxCell();

                        Check_Box_Cell = Registro.Cells[0] as DataGridViewCheckBoxCell;

                        if (Check_Box_Cell.Value != null)
                        {
                            //  se valida que se encuentre seleccionado el check de reimpresion
                            switch (Check_Box_Cell.Value.ToString())
                            {
                                case "True":
                                    // asignar valores para impresión
                                    //Numero_Serie_Acceso = Registro.Cells[Ope_Accesos.Campo_Numero_Serie].Value.ToString();
                                    Numero_Serie_Acceso = Registro.Cells[Ope_Accesos.Campo_No_Acceso].Value.ToString();
                                    Tipo_Acceso = Registro.Cells["PRODUCTO"].Value.ToString();
                                    Encabezado = Encabezado_Boleto;

                                    //  cambia el formato de hora
                                    if (!String.IsNullOrEmpty(Registro.Cells["Hora_Expedicion"].Value.ToString()))
                                    {
                                        Hora = Registro.Cells["Hora_Expedicion"].Value.ToString().Replace("P", "p.").Replace("M", "m.").Replace("A", "a.");
                                    }


                                    No_Venta = Registro.Cells["No_Venta"].Value.ToString();
                                    Caja = Registro.Cells["Numero_Caja"].Value.ToString();
                                    Folio = Registro.Cells["No_Acceso"].Value.ToString();
                                    Fecha_Impresion = String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime(Registro.Cells["Fecha_Expedicion"].Value.ToString()));
                                    Hora_Impresion = Hora;
                                    Vigencia = String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime(Registro.Cells["Fecha_Vigencia"].Value.ToString()));
                                    Costo = "$ " + Convert.ToDouble(Registro.Cells["Costo"].Value.ToString()).ToString("N") + " m.n.";

                                    // llamar método de impresión
                                    Prn_Impresion = new PrintDocument();
                                    // si se encontró un nombre para la impresora, asignar nombre
                                    if (!string.IsNullOrEmpty(Obj_Impresora_Caja.P_Impresora_Accesos))
                                    {
                                        Prn_Impresion.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Accesos;
                                    }

                                    Prn_Impresion.DefaultPageSettings.PaperSize = new PaperSize("Custom Access ticket", 200, 551);
                                    Prn_Impresion.PrintPage += new PrintPageEventHandler(this.Imprimir_Acceso_OnPrintPage);
                                    Prn_Impresion.Print();
                                    break;
                            }//  fin del switch
                        }// fin del if
                    }
                }
                else
                {
                    // imprimir números
                    foreach (DataRow Registro in Dt_Reimpresion.Rows)
                    {
                        // asignar valores para impresión
                        Numero_Serie_Acceso = Registro[Ope_Accesos.Campo_No_Acceso].ToString();
                        Tipo_Acceso = Registro["PRODUCTO"].ToString();
                        Encabezado = Encabezado_Boleto;

                        //  cambia el formato de hora
                        if (!String.IsNullOrEmpty(Registro["Hora_Expedicion"].ToString()))
                        {
                            Hora = Registro["Hora_Expedicion"].ToString().Replace("P", "p.").Replace("M", "m.").Replace("A", "a.");
                        }
                        No_Venta = Registro["No_Venta"].ToString();
                        Caja = Registro["Numero_Caja"].ToString();
                        Folio = Registro["No_Acceso"].ToString();
                        Fecha_Impresion = String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime(Registro["Fecha_Expedicion"].ToString()));
                        Hora_Impresion = Hora;
                        Vigencia = String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime(Registro["Fecha_Vigencia"].ToString()));
                        Costo = "$ " + Convert.ToDouble(Registro["Costo"].ToString()).ToString("N") + " m.n.";

                        // llamar método de impresión
                        Prn_Impresion = new PrintDocument();
                        // si se encontró un nombre para la impresora, asignar nombre
                        if (!string.IsNullOrEmpty(Obj_Impresora_Caja.P_Impresora_Accesos))
                        {
                            Prn_Impresion.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Accesos;
                        }

                        Prn_Impresion.DefaultPageSettings.PaperSize = new PaperSize("Custom Access ticket", 200, 551);
                        Prn_Impresion.PrintPage += new PrintPageEventHandler(this.Imprimir_Acceso_OnPrintPage);
                        Prn_Impresion.Print();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error de impresión: " + Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Imprimir_Solicitud_Facturacion
        ///DESCRIPCIÓN          : Manda los datos a la impresora
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Imprimir_Solicitud_Facturacion()
        {
            Dictionary<string, string> Dic_Formas_Pago = Obtener_Formas_Pago();

            try
            {
                // consultar impresoras para la caja actual
                Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();


                if (Dt_Solicitud != null && Dt_Solicitud.Rows.Count > 0)
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument PD = new PrintDocument();
                    PD.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Pago;
                    PD.PrintPage += new PrintPageEventHandler(Imprimir_Solicitud);
                    PD.Print();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error de impresión: " + Ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Imprimir_Solicitud(object sender, PrintPageEventArgs e)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = 5;
                float topMargin = 55;
                string line = null;

                List<string> Texto_Imprimir = new List<string>();
                Cls_Apl_Parametros_Negocio Obj_Parametros = new Cls_Apl_Parametros_Negocio();

                ////  se obtiene la imagen del directorio compartido
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Accesos/Acceso.png";
                Image Logo = Image.FromFile(Ruta_Archivo);

                Texto_Imprimir.Add(Obj_Parametros.P_Encabezado_Recibo + "\n\n");//   Encabezado
                Texto_Imprimir.Add("Titulo:   Solicitud de factura");// tipo
                Texto_Imprimir.Add("Fecha:   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ""); // fecha y hora

                foreach (DataRow Registro_Solicitud in Dt_Solicitud.Rows)
                {
                    Texto_Imprimir.Add("Cajero:  " + Registro_Solicitud["Numero_Caja"].ToString() + "");// Numero de caja 
                    Texto_Imprimir.Add("Nombre:  " + Registro_Solicitud["Nombre_Cajero"].ToString() + "");// Nombre del cajero
                    Texto_Imprimir.Add("Folio:   " + Registro_Solicitud["Folio_Venta"].ToString() + "");// Nombre del cajero
                    Texto_Imprimir.Add("Importe: $ " + Convert.ToDouble(P_Total_Venta_En_Solicitd).ToString("n") + " m.n.");// Nombre del cajero

                    No_Venta = Registro_Solicitud["Folio_Venta"].ToString();
                    break;
                }

                //  datos fiscales
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("Datos fiscales requeridos\n");
                Texto_Imprimir.Add("Nombre _____________________________\n");//   nombre
                Texto_Imprimir.Add("____________________________________\n");
                Texto_Imprimir.Add("Rfc    _____________________________\n");//   Rfc
                Texto_Imprimir.Add("Domicilio \n");//   Domicilio
                Texto_Imprimir.Add("Calle  _____________________________\n");//   calle
                Texto_Imprimir.Add("____________________________________\n");
                Texto_Imprimir.Add("No int._____________________________\n");//   numero interior
                Texto_Imprimir.Add("No ext._____________________________\n");//   numero exterior
                Texto_Imprimir.Add("Colonia_____________________________\n");//   Colonia
                Texto_Imprimir.Add("____________________________________\n");
                Texto_Imprimir.Add("Ciudad _____________________________\n");//   Ciudad
                Texto_Imprimir.Add("Estado _____________________________\n");//   Estado
                Texto_Imprimir.Add("CP     _____________________________\n");//   Cp
                Texto_Imprimir.Add("Email  _____________________________\n");//   Email
                Texto_Imprimir.Add("____________________________________"); 
                Texto_Imprimir.Add("Telefono____________________________\n");//   Telefono
                Texto_Imprimir.Add("____________________________________");
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("**Es necesario proporcionar los datos\n");
                Texto_Imprimir.Add("requeridos de forma legible y de manera\n");
                Texto_Imprimir.Add("completa");

                e.Graphics.DrawImage(Logo, new Rectangle(1, 1, 200, 50));

                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                float Height = 0;

                foreach (string Linea in Texto_Imprimir)
                {
                    Height = printFont.GetHeight(e.Graphics) + 5;
                    yPos = topMargin + (count * Height);
                    e.Graphics.DrawString(Linea, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                    count++;
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Prueba imprimir recibo venta
        /// </summary>
        public void Imprimir_Solicitud_Recibo_Venta()
        {
            Dictionary<string, string> Dic_Formas_Pago = Obtener_Formas_Pago();

            try
            {
                // consultar impresoras para la caja actual
                Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                //if (Dt_Solicitud != null && Dt_Solicitud.Rows.Count > 0)
                //{
                    printFont = new Font("Arial", 9);
                    PrintDocument PD = new PrintDocument();
                    PD.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Pago;
                    PD.PrintPage += new PrintPageEventHandler(Imprimir_Recibo_Venta);
                    PD.Print();
                //}
            }
            catch (Exception Ex)
            {
                throw new Exception("Error de impresión: " + Ex.Message);
            }
        }

        /// <summary>
        /// Prueba para imprimir el recibo de venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Imprimir_Recibo_Venta(object sender, PrintPageEventArgs e)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = 0;
                float topMargin = 15;

                List<string> Texto_Imprimir = new List<string>();
                Cls_Apl_Parametros_Negocio Obj_Parametros = new Cls_Apl_Parametros_Negocio();
                int Cantidad_Producto;
                decimal Total_Producto;
                decimal Total_Pagado;
                Dictionary<string, string> Dic_Formas_Pago = Obtener_Formas_Pago();

                ////  se obtiene la imagen del directorio compartido
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                //string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Accesos/Acceso.png";
                //Image Logo = Image.FromFile(Ruta_Archivo);

                Texto_Imprimir.Add(Obj_Parametros.P_Encabezado_Recibo + "\n\n");//   Encabezado
                //Texto_Imprimir.Add("Titulo:   Solicitud de factura");// tipo
                Texto_Imprimir.Add("Fecha:   " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + ""); // fecha y hora
                
                //separador
                Texto_Imprimir.Add("".PadLeft(60, '-') + "\n" + "  Producto\t\tPrecio\n" + "".PadLeft(60, '-'));
                Texto_Imprimir.Add(" " + "\n");
                
                foreach (DataRow Fila_Venta in Dt_Datos_Pago.Rows)
                {
                    // obtener la cantidad de productos y validar que sea mayor que cero
                    if (int.TryParse(Fila_Venta["CANTIDAD"].ToString(), out Cantidad_Producto) == true && Cantidad_Producto > 0)
                    {
                        // obtener el tipo de producto y recortar si excede la longitud
                        Tipo_Acceso = Fila_Venta["PRODUCTO"].ToString();
                        
                        if (Tipo_Acceso.Length > 23)
                        {
                            Tipo_Acceso = Tipo_Acceso.Substring(0, 23);
                        }
                        
                        decimal.TryParse(Fila_Venta["TOTAL"].ToString(), out Total_Producto);

                        if (Tipo_Acceso.Length > 11) { Tipo_Acceso = Tipo_Acceso.Substring(0, 12); }

                        // agregar línea producto
                        Texto_Imprimir.Add(
                            Cantidad_Producto.ToString().PadLeft(4, '0') + " "
                            + Tipo_Acceso + "\t\t"
                            + Total_Producto.ToString("#,##0.00")
                            );

                        //si es un SERVICIO y se imprime, enviar impresión a la impresora de servicios 
                        if (string.Compare(Fila_Venta["TIPO"].ToString(), "Servicio", true) == 0 && string.Compare(Fila_Venta["IMPRIMIR"].ToString(), "True", true) == 0 && !string.IsNullOrEmpty(Obj_Impresora_Caja.P_Impresora_Servicios))
                        {
                            string Imprimir_Servicio = Tipo_Acceso + "\n\n\n\n\n";
                            // enviar a imprimir productos
                            for (int i = 0; i < Cantidad_Producto; i++)
                            {
                                RawPrinterHelper.Enviar_Texto_Impresora(Obj_Impresora_Caja.P_Impresora_Servicios, Reemplazo_StringBuilder(new StringBuilder(Imprimir_Servicio)).ToString(), "Servicio " + i + 1 + No_Venta);
                            }
                        }
                    }
                }

                // separador y total
                Texto_Imprimir.Add(" " + "\n");
                Texto_Imprimir.Add("".PadLeft(60, '-') + "\n" + "Subtotal\t\t" + Subtotal_Pago.ToString("c"));
                
                // si hay descuento: mostrar
                if (Descuento_Pago > 0)
                {
                    Texto_Imprimir.Add(" " + "\n");
                    Texto_Imprimir.Add(("Descuento\t\t-" + Motivo_Descuento) + Descuento_Pago.ToString("c"));
                }
                
                Texto_Imprimir.Add(" " + "\n");
                Texto_Imprimir.Add("Total\t\t" + Total_Pago.ToString("c"));
                
                // agregar forma de pago
                if (Dt_Formas_Pago != null)
                {
                    string Tarjeta = "";
                    string Str_Forma_Pago;
                    foreach (DataRow Fila in Dt_Formas_Pago.Rows)
                    {
                        Str_Forma_Pago = "";
                        if (Dic_Formas_Pago.ContainsKey(Fila["Forma_Id"].ToString()))
                        {
                            Str_Forma_Pago = Dic_Formas_Pago[Fila["Forma_Id"].ToString()];
                        }
                        
                        decimal.TryParse(Fila["Monto_Pago"].ToString(), out Total_Pagado);
                        Texto_Imprimir.Add(("Su pago " + Str_Forma_Pago) + "\t\t" + Total_Pagado.ToString("c"));
                        Tarjeta = Fila["Numero_Tarjeta_Banco"].ToString().Trim();

                        // si hay un número de tarjeta, mostrar últimos 3 caracteres
                        if (!string.IsNullOrEmpty(Tarjeta))
                        {
                            Texto_Imprimir.Add(Tarjeta.Substring(Tarjeta.Length - 3, 3).PadLeft(16, '*'));
                        }
                    }
                }

                // folio y cajero
                
                Texto_Imprimir.Add("\nFolio: " + No_Venta);
                Texto_Imprimir.Add("\nCajero: " + ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Numero_Caja);

                // obtener datos del grupo
                Cls_Ope_Grupos_Negocio Obj_Grupos_Negocio = new Cls_Ope_Grupos_Negocio();
                Obj_Grupos_Negocio.P_No_Venta = No_Venta;
                DataTable Dt_Grupos = Obj_Grupos_Negocio.Consultar_Grupos();
                if (Dt_Grupos != null && Dt_Grupos.Rows.Count > 0)
                {
                    // agregar datos del grupo
                    Texto_Imprimir.Add("".PadLeft(40, '-') + "\n" + "Grupo " + Dt_Grupos.Rows[0][Ope_Ventas.Campo_Empresa].ToString());
                    Texto_Imprimir.Add(Dt_Grupos.Rows[0][Ope_Ventas.Campo_Persona_Tramita].ToString());
                }

                // separador y mensaje del día
                Texto_Imprimir.Add("\n" + Obj_Parametros.P_Mensaje_Dia_Recibo + "\n");

                StringFormat strFormat = new StringFormat();
                float[] tabs = { 150, 75 };

                strFormat.SetTabStops(0, tabs);

                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                float Height = 0;

                foreach (string Linea in Texto_Imprimir)
                {
                    Height = printFont.GetHeight(e.Graphics) + 5;
                    yPos = topMargin + (count * Height);
                    e.Graphics.DrawString(Linea, printFont, Brushes.Black, leftMargin, yPos, strFormat);
                    //MessageBox.Show(Linea.ToString());
                    count++;
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Imprimir_Pago
        ///DESCRIPCIÓN          : Manda los datos a la impresora
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Imprimir_Recoleccion()
        {
            String Informacion_Recoleecion = ""; 
            try
            {
                Informacion_Recoleecion = this.P_Texto_Recoleccion;
                // consultar impresoras para la caja actual
                Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                // imprimir recibo de pago
                Imprimir_Recolecciones_Arqueo_Cierre(Informacion_Recoleecion);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error de impresión: " + Ex.Message);
            }

        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Imprimir_Accesos
        ///DESCRIPCIÓN: genera la impresión de los accesos leyendo los valores en Dt_Datos_Pago y 
        ///             enviando a la impresora en Obj_Impresora_Caja.P_Impresora_Accesos
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 11-nov-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Imprimir_Accesos()
        {
            var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
            String Encabezado_Boleto = "";

            int Cantidad_Producto;
            int Contador;
            PrintDocument Prn_Impresion;
            string[] Lista_Accesos;
            string[] Lista_Folio_Accesos;
            string[] Lista_Bytes_Accesos;

            try
            {
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                Encabezado_Boleto = Obj_Parametros.P_Encabezado_Recibo;
                Serie = MDI_Frm_Apl_Principal.Serie_Caja;

                // validar que la tabla no sea nulo y tenga una columna ACCESOS
                if (Dt_Datos_Pago != null && Dt_Datos_Pago.Columns.Contains("ACCESOS"))
                {
                    // recorrer la tabla
                    foreach (DataRow Fila_Venta in Dt_Datos_Pago.Rows)
                    {
                        // obtener la cantidad de productos, validar que sea mayor que cero y que sea de tipo PRODUCTO
                        if (int.TryParse(Fila_Venta["CANTIDAD"].ToString(), out Cantidad_Producto) == true && Cantidad_Producto > 0 && Fila_Venta["TIPO"].ToString().ToUpper().Equals("PRODUCTO"))
                        {
                            // obtener lista de accesos
                            Lista_Accesos = Fila_Venta["ACCESOS"].ToString().Split(',');
                            Lista_Folio_Accesos = Fila_Venta["FOLIO"].ToString().Split(',');
                            Lista_Bytes_Accesos = Fila_Venta["ASCII"].ToString().Split(',');
                            // imprimir números
                            for (Contador = 0; Contador < Lista_Accesos.Length; Contador++)
                            {
                                // asignar valores para impresión
                               // Numero_Serie_Acceso = Lista_Accesos[Contador];
                                Numero_Serie_Acceso = Lista_Folio_Accesos[Contador];
                                Tipo_Acceso = Fila_Venta["PRODUCTO"].ToString();
                                Encabezado = Encabezado_Boleto;

                                Caja = Fila_Venta["CAJA"].ToString();
                                Folio = Lista_Folio_Accesos[Contador];
                                Fecha_Impresion = Fila_Venta["FECHA"].ToString();
                                Hora_Impresion = Fila_Venta["HORA"].ToString();
                                Vigencia = Fila_Venta["VIGENCIA"].ToString();
                                Costo = "$ " + Convert.ToDouble(Fila_Venta["Costo"].ToString()).ToString("N") + " m.n.";

                                // llamar método de impresión
                                Prn_Impresion = new PrintDocument();
                                // si se encontró un nombre para la impresora, asignar nombre
                                if (!string.IsNullOrEmpty(Obj_Impresora_Caja.P_Impresora_Accesos))
                                {
                                    Prn_Impresion.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Accesos;
                                }

                                Prn_Impresion.DefaultPageSettings.PaperSize = new PaperSize("Custom Access ticket",200, 551);
                                Prn_Impresion.PrintPage += new PrintPageEventHandler(this.Imprimir_Acceso_OnPrintPage);
                                Prn_Impresion.Print();
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Imprimir accesos: " + Ex.Message);
            }

        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Imprimir_Acceso_OnPrintPage
        ///DESCRIPCIÓN: Manejo del evento imprimir página: Imprime los valores de Tipo_Acceso y Numero_Serie_Acceso
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 24-oct-2013
        ///MODIFICÓ: Olimpo Alberto Cruz Amaya  
        ///FECHA_MODIFICÓ: 23/Feb/2015
        ///CAUSA_MODIFICACIÓN: Se cambio la de la imagen para que sea accesible desde parametros
        ///*******************************************************************************************************
        private void Imprimir_Acceso_OnPrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                //string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Acceso/Logo_Accesos_Momias.png";
                string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Accesos/Acceso.png";

                Image Logo = Image.FromFile(Ruta_Archivo);
                RectangleF Renctangulo_Compimido = new RectangleF(1, 12, 180, 95);


                //  se asignan los valores para centrar el titulo
                Formato_Centrado.Alignment = StringAlignment.Center;
                Formato_Centrado.LineAlignment = StringAlignment.Center;
                SizeF SzF_Str_Tamaño_Texto = new SizeF();
                Single Tamaño = 0;
                RectangleF Rectangulo = new RectangleF();

                //  imagen del boleto ******************************************************************************************************************
                ev.Graphics.DrawImage(Logo, Renctangulo_Compimido);
                //ev.Graphics.DrawString("xxx ", Fuente_Texto_Detalle, Brushes.Black, 10, 10, new StringFormat());
                //ev.Graphics.DrawString("xxx ", Fuente_Texto_Detalle, Brushes.Black, 10, 80, new StringFormat());


                // imprimir la fecha y hora ******************************************************************************************************************
                ev.Graphics.DrawString("Fecha: ", Fuente_Texto_Detalle, Brushes.Black, 10, 120, new StringFormat());
                ev.Graphics.DrawString(Fecha_Impresion, Fuente_Texto_Detalle, Brushes.Black, 90, 120, new StringFormat());
                ev.Graphics.DrawString("Hora: ", Fuente_Texto_Detalle, Brushes.Black, 10, 130, new StringFormat());
                ev.Graphics.DrawString(Hora_Impresion, Fuente_Texto_Detalle, Brushes.Black, 90, 130, new StringFormat());

                //  se ingresa el folio y la caja ******************************************************************************************************************
                ev.Graphics.DrawString("Folio acceso: ", Fuente_Texto_Detalle, Brushes.Black, 10, 140, new StringFormat());
                ev.Graphics.DrawString(Folio, Fuente_Texto_Detalle, Brushes.Black, 90, 140, new StringFormat());

                ev.Graphics.DrawString("Folio venta: ", Fuente_Texto_Detalle, Brushes.Black, 10, 150, new StringFormat());
                ev.Graphics.DrawString(No_Venta, Fuente_Texto_Detalle, Brushes.Black, 90, 150, new StringFormat());

                ev.Graphics.DrawString("Caja: ", Fuente_Texto_Detalle, Brushes.Black, 10, 160, new StringFormat());
                ev.Graphics.DrawString(Caja, Fuente_Texto_Detalle, Brushes.Black, 90, 160, new StringFormat());

                //  se agrega la vigencia del boleto ******************************************************************************************************************
                ev.Graphics.DrawString("Vigencia: ", Fuente_Texto_Detalle, Brushes.Black, 10, 170, new StringFormat());
                ev.Graphics.DrawString(Vigencia, Fuente_Texto_Detalle, Brushes.Black, 90, 170, new StringFormat());


                // imprimir el costo ******************************************************************************************************************
                ev.Graphics.DrawString("Costo:", Fuente_Texto_Detalle, Brushes.Black, 10, 180, new StringFormat());
                ev.Graphics.DrawString( Costo, Fuente_Texto_Detalle, Brushes.Black, 90, 180, new StringFormat());

                // imprimir el tipo de acceso ******************************************************************************************************************
                ev.Graphics.DrawString("Tipo", Fuente_Texto_Detalle, Brushes.Black, 10, 200, new StringFormat());

                //  se toma el tamaño del producto
                SzF_Str_Tamaño_Texto = ev.Graphics.MeasureString(Tipo_Acceso, Fuente_Texto_Producto);
                // se crea el rectangulo con el texto
                Tamaño = ev.Graphics.MeasureString(Tipo_Acceso, Fuente_Texto_Producto, 205, Formato_Centrado).Height;
                Rectangulo = new RectangleF(ev.MarginBounds.Left, 200, ev.MarginBounds.Width, Tamaño);

                ev.Graphics.DrawString(Tipo_Acceso, Fuente_Texto_Producto, Brushes.Black, Rectangulo, Formato_Centrado);


              
                // imprimir código de barras ******************************************************************************************************************
                //ev.Graphics.DrawString("*" + Numero_Serie_Acceso + "*", Fuente_Codigo_Acceso, Brushes.Black, 2, 300, new StringFormat());
                Ean13 Codigo = new Ean13();
                Codigo.ManufacturerCode = MDI_Frm_Apl_Principal.No_Caja +  Numero_Serie_Acceso.Substring(1, 4);
                Codigo.ProductCode = Numero_Serie_Acceso.Substring(5, 5);
                Codigo.ChecksumDigit = "0";
                Codigo.Scale = 1.0f;
                Codigo.DrawEan13Barcode(ev.Graphics, new Point(0, 60));




                ////  Encabezado del boleto ******************************************************************************************************************
                //SzF_Str_Tamaño_Texto = ev.Graphics.MeasureString(Encabezado, Fuente_Texto);

                //// se crea el rectangulo con el texto
                //Tamaño = ev.Graphics.MeasureString(Encabezado, Fuente_Texto, 195, Formato_Centrado).Height;
                //Rectangulo = new RectangleF(ev.MarginBounds.Left, 380, ev.MarginBounds.Width, Tamaño);

                //// imprimir el encabeado del boleto ******************************************************************************************************************
                //ev.Graphics.DrawString(Encabezado, Fuente_Texto, Brushes.Black, Rectangulo, Formato_Centrado);

                ////********************************************************************************************************************************************
                ////********************************************************************************************************************************************
                ////********************************************************************************************************************************************
                //// imprimir la fecha y hora ******************************************************************************************************************
                //ev.Graphics.DrawString("Fecha: ", Fuente_Texto_Detalle, Brushes.Black, 10, 450, new StringFormat());
                //ev.Graphics.DrawString(Fecha_Impresion, Fuente_Texto_Detalle, Brushes.Black, 70, 450, new StringFormat());
                //ev.Graphics.DrawString("Hora: ", Fuente_Texto_Detalle, Brushes.Black, 10, 460, new StringFormat());
                //ev.Graphics.DrawString(Hora_Impresion, Fuente_Texto_Detalle, Brushes.Black, 70, 460, new StringFormat());

                ////  se ingresa el folio y la caja ******************************************************************************************************************
                //ev.Graphics.DrawString("Folio: ", Fuente_Texto_Detalle, Brushes.Black, 10, 470, new StringFormat());
                //ev.Graphics.DrawString(Folio, Fuente_Texto_Detalle, Brushes.Black, 70, 470, new StringFormat());
                //ev.Graphics.DrawString("Caja: ", Fuente_Texto_Detalle, Brushes.Black, 10, 480, new StringFormat());
                //ev.Graphics.DrawString(Caja, Fuente_Texto_Detalle, Brushes.Black, 70, 480, new StringFormat());

                ////  se agrega la vigencia del boleto ******************************************************************************************************************
                //ev.Graphics.DrawString("Vigencia: ", Fuente_Texto_Detalle, Brushes.Black, 10, 490, new StringFormat());
                //ev.Graphics.DrawString(Vigencia, Fuente_Texto_Detalle, Brushes.Black, 70, 490, new StringFormat());

                //// imprimir el costo ******************************************************************************************************************
                //ev.Graphics.DrawString("Costo:", Fuente_Texto_Detalle, Brushes.Black, 10, 500, new StringFormat());
                //ev.Graphics.DrawString(Costo, Fuente_Texto_Detalle, Brushes.Black, 70, 500, new StringFormat());

                //// imprimir el encabeado del boleto     ******************************************************************************************************************
                //SzF_Str_Tamaño_Texto = ev.Graphics.MeasureString(Encabezado, Fuente_Texto);

                //// se crea el rectangulo con el texto
                //Tamaño = ev.Graphics.MeasureString(Encabezado, Fuente_Texto, 195, Formato_Centrado).Height;
                //Rectangulo = new RectangleF(ev.MarginBounds.Left, 520, ev.MarginBounds.Width, Tamaño);
                //ev.Graphics.DrawString(Encabezado, Fuente_Texto, Brushes.Black, Rectangulo, Formato_Centrado);


                ev.HasMorePages = false;
            }
            catch (Exception Ex)
            {
                throw new Exception("Imprimir_Acceso_OnPrintPage: " + Ex.Message);
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Imprimir_Recibo
        ///DESCRIPCIÓN: Formar un string con la información del recibo de pago y anviar a la impresora
        ///PARÁMETROS: 
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 24-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Imprimir_Recibo()
        {
            StringBuilder Texto_Imprimir = new StringBuilder(120);
            // consultar parámetros
            var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
            Obj_Parametros = Obj_Parametros.Obtener_Parametros();
            int Cantidad_Producto;
            decimal Total_Producto;
            decimal Total_Pagado;
            Dictionary<string, string> Dic_Formas_Pago = Obtener_Formas_Pago();

            try
            {
                // validar que la tabla no sea nulo
                if (Dt_Datos_Pago != null && Dt_Datos_Pago.Columns.Contains("ACCESOS"))
                {


                    // formar texto del recibo
                    Texto_Imprimir.AppendLine(Obj_Parametros.P_Encabezado_Recibo + "\n");
                    Texto_Imprimir.AppendLine("Fecha " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss").ToLower());
                    // encabezado detalles:
                    Texto_Imprimir.AppendLine("".PadLeft(40, '-') + "\n" + "  Producto                       Precio\n" + "".PadLeft(40, '-'));
                    // recorrer la tabla
                    foreach (DataRow Fila_Venta in Dt_Datos_Pago.Rows)
                    {
                        // obtener la cantidad de productos y validar que sea mayor que cero
                        if (int.TryParse(Fila_Venta["CANTIDAD"].ToString(), out Cantidad_Producto) == true && Cantidad_Producto > 0)
                        {
                            // obtener el tipo de producto y recortar si excede la longitud
                            Tipo_Acceso = Fila_Venta["PRODUCTO"].ToString();
                            if (Tipo_Acceso.Length > 23)
                            {
                                Tipo_Acceso = Tipo_Acceso.Substring(0, 23);
                            }
                            decimal.TryParse(Fila_Venta["TOTAL"].ToString(), out Total_Producto);
                            // agregar línea producto
                            Texto_Imprimir.AppendLine(
                                Cantidad_Producto.ToString().PadLeft(4, '0') + " "
                                + Tipo_Acceso.PadRight(23) + " "
                                + Total_Producto.ToString("#,##0.00").PadLeft(10)
                                );
                            // si es un SERVICIO y se imprime, enviar impresión a la impresora de servicios 
                            if (string.Compare(Fila_Venta["TIPO"].ToString(), "Servicio", true) == 0 && string.Compare(Fila_Venta["IMPRIMIR"].ToString(), "True", true) == 0 && !string.IsNullOrEmpty(Obj_Impresora_Caja.P_Impresora_Servicios))
                            {
                                string Imprimir_Servicio = Tipo_Acceso + "\n\n\n\n\n";
                                // enviar a imprimir productos
                                for (int i = 0; i < Cantidad_Producto; i++)
                                {
                                    RawPrinterHelper.Enviar_Texto_Impresora(Obj_Impresora_Caja.P_Impresora_Servicios, Reemplazo_StringBuilder(new StringBuilder(Imprimir_Servicio)).ToString(), "Servicio " + i + 1 + No_Venta);
                                }
                            }
                        }
                    }
                    // separador y total
                    Texto_Imprimir.AppendLine("".PadLeft(40, '-') + "\n" + "Subtotal".PadRight(24) + Subtotal_Pago.ToString("c").PadLeft(15));
                    // si hay descuento: mostrar
                    if (Descuento_Pago > 0)
                    {

                        Texto_Imprimir.AppendLine(("Descuento " + Motivo_Descuento).PadRight(29) + Descuento_Pago.ToString("c").PadLeft(10));
                    }
                    Texto_Imprimir.AppendLine("Total".PadRight(24) + Total_Pago.ToString("c").PadLeft(15));
                    // agregar forma de pago
                    if (Dt_Formas_Pago != null)
                    {
                        string Tarjeta = "";
                        string Str_Forma_Pago;
                        foreach (DataRow Fila in Dt_Formas_Pago.Rows)
                        {
                            Str_Forma_Pago = "";
                            if (Dic_Formas_Pago.ContainsKey(Fila["Forma_Id"].ToString()))
                            {
                                Str_Forma_Pago = Dic_Formas_Pago[Fila["Forma_Id"].ToString()];
                            }
                            decimal.TryParse(Fila["Monto_Pago"].ToString(), out Total_Pagado);
                            Texto_Imprimir.AppendLine(("Su pago " + Str_Forma_Pago).PadRight(24) + Total_Pagado.ToString("c").PadLeft(15));
                            Tarjeta = Fila["Numero_Tarjeta_Banco"].ToString().Trim();
                            // si hay un número de tarjeta, mostrar últimos 3 caracteres
                            if (!string.IsNullOrEmpty(Tarjeta))
                            {
                                Texto_Imprimir.AppendLine(Tarjeta.Substring(Tarjeta.Length - 3, 3).PadLeft(16, '*'));
                            }
                        }
                    }

                    // folio y cajero
                    Texto_Imprimir.AppendLine("\nFolio: " + No_Venta);
                    Texto_Imprimir.AppendLine("Cajero: " + ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Nombre_Usuario);

                    // obtener datos del grupo
                    Cls_Ope_Grupos_Negocio Obj_Grupos_Negocio = new Cls_Ope_Grupos_Negocio();
                    Obj_Grupos_Negocio.P_No_Venta = No_Venta;
                    DataTable Dt_Grupos = Obj_Grupos_Negocio.Consultar_Grupos();
                    if (Dt_Grupos != null && Dt_Grupos.Rows.Count > 0)
                    {
                        // agregar datos del grupo
                        Texto_Imprimir.AppendLine("".PadLeft(40, '-') + "\n" + "Grupo " + Dt_Grupos.Rows[0][Ope_Ventas.Campo_Empresa].ToString());
                        Texto_Imprimir.AppendLine(Dt_Grupos.Rows[0][Ope_Ventas.Campo_Persona_Tramita].ToString());
                    }

                    // separador y mensaje del día
                    Texto_Imprimir.AppendLine("\n" + Obj_Parametros.P_Mensaje_Dia_Recibo + "\n\n\n\n\n\n\n\n");

                    //// enviar a la impresora
                    RawPrinterHelper.Enviar_Texto_Impresora(Obj_Impresora_Caja.P_Impresora_Pago, Reemplazo_StringBuilder(Texto_Imprimir).ToString(), "Venta " + No_Venta);
                    //RawPrinterHelper.Enviar_Texto_Impresora(Obj_Impresora_Caja.P_Impresora_Pago, Texto_Imprimir.ToString().Replace("ñ", "\x0A4").Replace("á", "\x0A0"), "Venta " + No_Venta);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Imprimir accesos: " + Ex.Message);
            }
        }



        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Imprimir_Recolecciones
        ///DESCRIPCIÓN: Formar un string con la información del recibo de pago y anviar a la impresora
        ///PARÁMETROS: 
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 24-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Imprimir_Recolecciones_Arqueo_Cierre(String Texto)
        {

            StringBuilder Texto_Imprimir = new StringBuilder();
            Texto_Imprimir.Append(Texto);

            // consultar parámetros
            var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
            Obj_Parametros = Obj_Parametros.Obtener_Parametros();

            // enviar a la impresora
            RawPrinterHelper.Enviar_Texto_Impresora(Obj_Impresora_Caja.P_Impresora_Pago, Reemplazo_StringBuilder(Texto_Imprimir).ToString(), "Recoleccion ");
        }



        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Reemplazo_StringBuilder
        ///DESCRIPCIÓN: Reemplaza los caracteres en el stringbuilder con los del diccionario en Reemplazo_StringBuilder
        ///PARÁMETROS:
        /// 		1. Cadena: cadena a reemplazar
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 29-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private StringBuilder Reemplazo_StringBuilder(StringBuilder Cadena)
        {
            foreach (string Valor in Valores_Reemplazar.Keys)
            {
                Cadena = Cadena.Replace(Valor, Valores_Reemplazar[Valor]);
            }

            return Cadena;
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
        private Dictionary<string, string> Obtener_Formas_Pago()
        {
            var Obj_Consulta_Formas_Pago = new Cls_Cat_Formas_Pago_Negocio();
            var Diccionario = new Dictionary<string, string>();
            DataTable Dt_Formas_Pago;

            Dt_Formas_Pago = Obj_Consulta_Formas_Pago.Consultar_Formas_Pago();
            // validar contenido de Dt_Formas_Pago
            if (Dt_Formas_Pago != null)
            {
                foreach (DataRow Fila in Dt_Formas_Pago.Rows)
                {
                    // si no existe el id en el diccionario, agregar
                    if (!Diccionario.ContainsKey(Fila[Cat_Formas_Pago.Campo_Forma_ID].ToString()))
                    {
                        Diccionario.Add(Fila[Cat_Formas_Pago.Campo_Forma_ID].ToString(), Fila[Cat_Formas_Pago.Campo_Nombre].ToString());
                    }
                }
            }

            return Diccionario;
        }

        #endregion Metodos
    }
}