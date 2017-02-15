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

namespace Erp_Ope_Impresiones.Negocio
{
    public class Cls_Ope_Impresiones_Negocio
    {
        #region Variables Internas
        private const SByte Anchura_Ticket = 40;
        private Font Fuente_Texto = new Font("Arial", 10);
        private Font Fuente_Codigo_Acceso = new Font("IDAutomationHC39M", 12);
        private string Numero_Serie_Acceso = "";
        private string Tipo_Acceso = "";
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
        private Int32 Cantidad = 0;
        private Decimal Total_Pago = 0;
        private Decimal Subtotal_Pago = 0;
        private String Motivo_Descuento = String.Empty;
        private Decimal Descuento_Pago = 0;
        private DateTime Fecha = DateTime.MinValue;
        private DataTable Dt_Datos_Pago;
        private DataTable Dt_Formas_Pago;

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
        public DataTable P_Dt_Formas_Pago
        {
            get { return Dt_Formas_Pago; }
            set { Dt_Formas_Pago = value; }
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
                Obj_Impresora_Caja.P_Caja_ID = "";
                Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                // imprimir recibo de pago
                Imprimir_Recibo();
                // imprimir accesos en una tarea diferente para evitar el tiempo de espera si se imprime una cantidad considerable
                Thread Tarea_Impresion = new Thread(Imprimir_Accesos);
                // se asigna como tarea de fondo para que la aplicación pueda continuar mientras esta nueva tarea termina de ejecutarse
                Tarea_Impresion.IsBackground = true;
                Tarea_Impresion.Start();

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
            int Cantidad_Producto;
            int Contador;
            PrintDocument Prn_Impresion;
            string[] Lista_Accesos;

            try
            {
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
                            // imprimir números
                            for (Contador = 0; Contador < Lista_Accesos.Length; Contador++)
                            {
                                // asignar valores para impresión
                                Numero_Serie_Acceso = Lista_Accesos[Contador];
                                Tipo_Acceso = Fila_Venta["PRODUCTO"].ToString();
                                // llamar método de impresión
                                Prn_Impresion = new PrintDocument();
                                // si se encontró un nombre para la impresora, asignar nombre
                                if (!string.IsNullOrEmpty(Obj_Impresora_Caja.P_Impresora_Accesos))
                                {
                                    Prn_Impresion.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Accesos;
                                }
                                Prn_Impresion.DefaultPageSettings.PaperSize = new PaperSize("Custom Access ticket", 307, 400);
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
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Imprimir_Acceso_OnPrintPage(object sender, PrintPageEventArgs ev)
        {
            // imprimir el tipo de acceso
            ev.Graphics.DrawString(Tipo_Acceso, Fuente_Texto, Brushes.Black, 10, 10, new StringFormat());
            // imprimir código de barras
            ev.Graphics.DrawString(Numero_Serie_Acceso, Fuente_Codigo_Acceso, Brushes.Black, 10, 330, new StringFormat());
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
                Texto_Imprimir.AppendLine("Cajero: Usuario Punto Venta Web");

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