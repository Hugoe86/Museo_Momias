using Erp.Constantes;
using ERP_BASE.App_Code.Controles;
using Operaciones.Estacionamiento.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_BASE.App_Code.Negocio.Catalogos;
using System.Threading;
using ResizeableForm;

namespace ERP_BASE.Paginas.Operaciones
{
    public partial class Frm_Ope_Estacionamiento : ResizableForm
    {
        #region (Variables Privadas)
        private const string Caracteres_Validos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private int Cantidad_Caracteres = Caracteres_Validos.Length;
        private const SByte Anchura_Ticket = 40;
        private Font Fuente_Texto = new Font("Consolas", 9);
        private Font Tipo_Fuente_IDAutomationHC39M = new Font("IDAutomationHC39M", 12);
        private Cls_Cat_Impresoras_Cajas_Negocio Obj_Impresora_Caja;
        private Cls_Ope_Estacionamiento_Negocio Datos_Ticket = null;
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
        #endregion

        #region (Init/Load)
        /// <summary>
        /// Nombre: Frm_Ope_Estacionamiento
        /// 
        /// Descripción: Método que realiza la carga inicial del formulario.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public Frm_Ope_Estacionamiento()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Nombre: Frm_Ope_Estacionamiento_Load
        /// 
        /// Descripción: Método que realiza la carga inicial del formulario.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Ope_Estacionamiento_Load(object sender, EventArgs e)
        {
            try
            {
                //Se consulta los servicios de tipo estacionamiento y se muestran al usuario.
                Consultar_Servicios_Estacionamiento();
                this.ActiveControl = Txt_Codigo_Barras;
                Txt_Codigo_Barras.Focus();
                Actualizar_Contador_Accesos_Estacionamiento();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Frm_Ope_Estacionamiento_Load]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Metodos)

        #region (Generales)
        /// <summary>
        /// Nombre: Consultar_Servicios_Estacionamiento
        /// 
        /// Descripción: Método que realiza la consulta de los servicios de tipo estacionamiento
        ///              y los carga en el panel de servicios.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Consultar_Servicios_Estacionamiento()
        {
            Cls_Ope_Estacionamiento_Negocio Obj_Estacionamiento = new Cls_Ope_Estacionamiento_Negocio();//Variable de negocios para realizar peticiones a la clase de datos.
            DataTable Dt_Servicios = null;//Variable que almacenara los servicios de tipo estacionamiento.
            Image Img_Productos = null;//Variable para almacenar la imagen del producto.

            try
            {
                //Realizar la consulta de servicios de tipo estacionamiento.
                Dt_Servicios = Obj_Estacionamiento.Consultar_Servicios_Estacionamiento();

                Array.ForEach(Dt_Servicios.Rows.OfType<DataRow>().ToArray(), fila =>
                {

                    if (!string.IsNullOrEmpty(fila.Field<string>(Cat_Productos.Campo_Ruta_Imagen)) && File.Exists(fila.Field<string>(Cat_Productos.Campo_Ruta_Imagen)))
                        Img_Productos = Image.FromFile(fila.Field<string>(Cat_Productos.Campo_Ruta_Imagen));
                    else
                        Img_Productos = global::ERP_BASE.Properties.Resources.img_no_disponible;

                    JButton Btn_Aux = new JButton(Img_Productos, new Size(228, 218), new Size(170, 145), new Point(19, 20), "", true);
                    Btn_Aux.Text = "\n" + fila.Field<string>(Cat_Productos.Campo_Nombre) + " $" + Convert.ToDecimal(fila.Field<decimal>(Cat_Productos.Campo_Costo)).ToString("#,##0.00");
                    Btn_Aux.TextAlign = ContentAlignment.BottomCenter;
                    Btn_Aux.BackColor = Color.WhiteSmoke;
                    Btn_Aux.Font = new System.Drawing.Font("Consolas", 11, FontStyle.Bold);
                    Btn_Aux.Tag = fila.Field<string>(Cat_Productos.Campo_Producto_Id);
                    Btn_Aux.Click += new EventHandler(this.Imprimir_Acceso_Estacionamiento);
                    Pnl_Servicios_Estacionamiento.Controls.Add(Btn_Aux);
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Alta_Registro_Estacionamiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Crear_Datos_Pago
        /// 
        /// Descripción: Método que crea y carga una tabla con los datos para enviar a la pantalla de pagos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 19 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Servicio_Estacionamiento_ID"></param>
        /// <returns></returns>
        private DataTable Crear_Datos_Pago(string Servicio_Estacionamiento_ID, decimal Horas, ref Cls_Ope_Estacionamiento_Negocio _Obj_Estacionamiento)
        {
            Cls_Ope_Estacionamiento_Negocio Obj_Estacionamiento = new Cls_Ope_Estacionamiento_Negocio();///Variable de negocios para realizar peticiones a la capa de datos.
            DataTable Dt_Servicios = null;//Variable para guardar el resultado de la consulta de servicios.
            DataTable Dt_Pedidos = new DataTable();//Variable para almacenar los datos del pago.
            decimal Costo;

            try
            {
                Obj_Estacionamiento.P_Producto_ID = Servicio_Estacionamiento_ID;
                Dt_Servicios = Obj_Estacionamiento.Consultar_Servicios_Estacionamiento();

                Dt_Pedidos.Columns.Add("CANTIDAD", typeof(decimal));
                Dt_Pedidos.Columns.Add("PRODUCTO", typeof(String));
                Dt_Pedidos.Columns.Add("TOTAL", typeof(decimal));
                Dt_Pedidos.Columns.Add("PRODUCTO_ID", typeof(String));
                Dt_Pedidos.Columns.Add("COSTO", typeof(decimal));
                Dt_Pedidos.Columns.Add("TIPO", typeof(String));
                Dt_Pedidos.Columns.Add("IMPRIMIR", typeof(String));

                if (Dt_Servicios != null)
                {
                    if (Dt_Servicios.Rows.Count > 0)
                    {
                        foreach (DataRow fila in Dt_Servicios.Rows)
                        {
                            DataRow Dr_Servicio = Dt_Pedidos.NewRow();
                            decimal.TryParse(fila[Cat_Productos.Campo_Costo].ToString(), out Costo);

                            Dr_Servicio["CANTIDAD"] = 1;

                            if (!string.IsNullOrEmpty(fila[Cat_Productos.Campo_Nombre].ToString()))
                                Dr_Servicio["PRODUCTO"] = fila[Cat_Productos.Campo_Nombre].ToString();
                            else
                                Dr_Servicio["PRODUCTO"] = string.Empty;

                            if (!string.IsNullOrEmpty(fila[Cat_Productos.Campo_Costo].ToString()))
                            {
                                Dr_Servicio["TOTAL"] = Costo * Horas;
                                _Obj_Estacionamiento.P_Importe = Costo * Horas;
                            }
                            else
                                Dr_Servicio["TOTAL"] = 0;

                            if (!string.IsNullOrEmpty(fila[Cat_Productos.Campo_Producto_Id].ToString()))
                                Dr_Servicio["PRODUCTO_ID"] = fila[Cat_Productos.Campo_Producto_Id].ToString();
                            else
                                Dr_Servicio["PRODUCTO_ID"] = string.Empty;


                            Dr_Servicio["COSTO"] = Costo;

                            if (!string.IsNullOrEmpty(fila[Cat_Productos.Campo_Tipo].ToString()))
                                Dr_Servicio["TIPO"] = fila[Cat_Productos.Campo_Tipo].ToString();
                            else
                                Dr_Servicio["TIPO"] = string.Empty;

                            Dr_Servicio["IMPRIMIR"] = string.Empty;

                            Dt_Pedidos.Rows.Add(Dr_Servicio);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Crear_Datos_Pago]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Dt_Pedidos;
        }
        /// <summary>
        /// Nombre: Operacion_Completa
        /// 
        /// Descripción: Método que vuelve la pantalla a un estado inicial.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 20 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public void Operacion_Completa()
        {
            try
            {
                this.Show();
                Txt_Codigo_Barras.Text = string.Empty;
                this.ActiveControl = Txt_Codigo_Barras;
                Txt_Codigo_Barras.Focus();
                Actualizar_Contador_Accesos_Estacionamiento();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Operacion_Completa]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Operacion_Cancelada
        ///DESCRIPCIÓN: Regresa la pantalla al estado inicial y muestra un mensaje indicando que el pago no fue realizado
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 10-mar-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Operacion_Cancelada()
        {
            try
            {
                MessageBox.Show(this, "No se completó el pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Show();
                Txt_Codigo_Barras.Text = string.Empty;
                this.ActiveControl = Txt_Codigo_Barras;
                Txt_Codigo_Barras.Focus();
                Actualizar_Contador_Accesos_Estacionamiento();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Operacion_Completa]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// Nombre: Actualizar_Contador_Accesos_Estacionamiento
        /// 
        /// Descripción: Método que actualiza el contador de accesos de carros y camionetas
        ///              al estacionamiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 20 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Actualizar_Contador_Accesos_Estacionamiento()
        {
            Cls_Ope_Estacionamiento_Negocio Obj_Estacionamiento = new Cls_Ope_Estacionamiento_Negocio();//Variable de negocios que nos sirve para realizar peticiones al aclase de datos.
            DataTable Dt_Servicios = null;
            DataTable Dt_Accesos = null;

            try
            {
                Dt_Servicios = Obj_Estacionamiento.Consultar_Servicios_Estacionamiento();

                // validar que la tabla contenga valores
                if (Dt_Servicios != null && Dt_Servicios.Rows.Count > 0)
                {
                    var Clave_Camioneta = Dt_Servicios.AsEnumerable()
                        .OrderByDescending(valor => valor.Field<decimal>(Cat_Productos.Campo_Costo))
                        .Select(item => new { producto_id = item.Field<string>(Cat_Productos.Campo_Producto_Id) }).First();

                    var Clave_Carro = Dt_Servicios.AsEnumerable()
                        .OrderBy(valor => valor.Field<decimal>(Cat_Productos.Campo_Costo))
                        .Select(item => new { producto_id = item.Field<string>(Cat_Productos.Campo_Producto_Id) }).First();

                    Obj_Estacionamiento.P_Estatus = "PENDIENTE";
                    Dt_Accesos = Obj_Estacionamiento.Consultar_Estacionamiento();

                    var cont_carros = Dt_Accesos.AsEnumerable()
                        .Where(carro => carro.Field<string>(Ope_Estacionamiento.Campo_Producto_ID).Equals(Clave_Carro.producto_id))
                        .Select(carro => carro).Count();

                    var cont_camionetas = Dt_Accesos.AsEnumerable()
                        .Where(carro => carro.Field<string>(Ope_Estacionamiento.Campo_Producto_ID).Equals(Clave_Camioneta.producto_id))
                        .Select(carro => carro).Count();

                    Txt_Carros.Text = cont_carros.ToString();
                    Txt_Camionetas.Text = cont_camionetas.ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Actualizar_Contador_Accesos_Estacionamiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Impresion Ticket Estacionamiento)
        /// <summary>
        /// Nombre: Imprimir_Acceso_Estacionamiento
        /// 
        /// Descripción: Método que comienza el proceso de impresión del ticket del estacionamiento y
        ///              que realiza el alta del registro de acceso al mismo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Imprimir_Acceso_Estacionamiento(object sender, EventArgs e)
        {
            Cls_Ope_Estacionamiento_Negocio Obj_Estacionamiento = new Cls_Ope_Estacionamiento_Negocio();//Variable de negocios para realizar peticiones a la capa de datos.
            DataTable Dt_Estacionamiento = null;//Variable para almacenar el resulatdo de la búsqueda.

            try
            {
                do
                {
                    //Proceso para obtener el codigo de barras del acceso al estacionamiento.
                    //Si el código generado ya existe, se ignora y se vuelve a generar otro código.
                    Obj_Estacionamiento.P_Codigo = Generar_Cadena_Proteccion(10);
                    Dt_Estacionamiento = Obj_Estacionamiento.Consultar_Estacionamiento();
                } while (Dt_Estacionamiento.Rows.Count > 0);

                //Establecemos algunos datos que se mostraran en el ticket que se enviara a impresión.
                Datos_Ticket = new Cls_Ope_Estacionamiento_Negocio();
                Datos_Ticket.P_Fecha_Hora_Ingreso = DateTime.Now;
                Datos_Ticket.P_Codigo = Obj_Estacionamiento.P_Codigo;
                Datos_Ticket.Tipo_Servicio = ((JButton)sender).Text + " por hora o fracción";

                //Se realiza la petición al proceso de configuración e impresión del ticket.
                Imprimir_Ticket();

                //Establecemos algunos datos que se almacenaran como registro del acceso al estacionamiento.
                Obj_Estacionamiento.P_Producto_ID = ((JButton)sender).Tag.ToString();
                Obj_Estacionamiento.P_Fecha_Hora_Ingreso = Datos_Ticket.P_Fecha_Hora_Ingreso;
                Obj_Estacionamiento.P_Estatus = "PENDIENTE";
                Obj_Estacionamiento.Alta_Estacionamiento();

                this.ActiveControl = Txt_Codigo_Barras;
                Txt_Codigo_Barras.Focus();
                Actualizar_Contador_Accesos_Estacionamiento();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Imprimir_Acceso_Estacionamiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Imprimir_Ticket
        /// 
        /// Descripción: Método que realiza la configuracion de la propiedades para realizar
        ///              la impresión. Ademas que crea la tarea que se encargara de realizar
        ///              el proceso de impresión.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public void Imprimir_Ticket()
        {
            try
            {
                // Consultar impresoras para la caja que se encuentra abierta actualmente.
                Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();
                // Creamos un hilo o proceso que se encargara de realizar la tarea de impresión.
                Thread Tarea_Impresion = new Thread(Imprimir_Ticket_Acceso_Estacionamiento);
                // Se asigna como tarea de fondo para que la aplicación pueda continuar mientras esta nueva tarea termina de ejecutarse
                Tarea_Impresion.IsBackground = true;
                Tarea_Impresion.Start();

            }
            catch (Exception Ex)
            {
                throw new Exception("Error de impresión: " + Ex.Message);
            }

        }
        /// <summary>
        /// Nombre: Imprimir_Ticket_Acceso_Estacionamiento
        /// 
        /// Descripción: Método que establece la configuración para la impresión del ticket.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public void Imprimir_Ticket_Acceso_Estacionamiento()
        {
            PrintDocument Prn_Impresion;//Creamos el objeto de impresión para enviar el ticket.

            try
            {
                //Instaciamos el objeto de impresión.
                Prn_Impresion = new PrintDocument();
                // Si se encontró un nombre para la impresora, asignar nombre.
                if (!string.IsNullOrEmpty(Obj_Impresora_Caja.P_Impresora_Accesos))
                {
                    Prn_Impresion.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Accesos;
                }

                //Establecemos la configuración para la impresión del ticket.
                Prn_Impresion.DefaultPageSettings.PaperSize = new PaperSize("Custom Access ticket", 200, 150);
                Prn_Impresion.PrintPage += new PrintPageEventHandler(this.Imprimir_Acceso_Estacionamiento_OnPrintPage);
                Prn_Impresion.Print();
            }
            catch (Exception Ex)
            {
                throw new Exception("Imprimir accesos: " + Ex.Message);
            }
        }
        /// <summary>
        /// Nombre: Imprimir_Acceso_Estacionamiento_OnPrintPage
        /// 
        /// Descripción: Método que escribe los datos sobre el ticket.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>
        private void Imprimir_Acceso_Estacionamiento_OnPrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                Graphics dibujante = ev.Graphics;
                //Impresión de titulo.
                dibujante.DrawString("Museo Momias", Fuente_Texto, Brushes.Black, (200 - 90) / 2, 10, new StringFormat());
                //Impresión de la fecha de ingreso al estacionamiento.
                dibujante.DrawString(Datos_Ticket.P_Fecha_Hora_Ingreso.ToString("dd MMMM yyyy HH:mm:ss tt"), new Font("Tahoma", 7), Brushes.Black, 20, 30, new StringFormat());
                //Impresion del tipo de acceso al estacionamiento.
                dibujante.DrawString(Datos_Ticket.Tipo_Servicio, new Font("Tahoma", 7), Brushes.Black, 25, 40, new StringFormat());
                // Imprimir código de barras.
                dibujante.DrawString(Reemplazar_Caracteres_Acentuados(new StringBuilder(Datos_Ticket.P_Codigo)).ToString(), Tipo_Fuente_IDAutomationHC39M, Brushes.Black, 15, 75, new StringFormat());
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Imprimir_Acceso_Estacionamiento_OnPrintPage]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Reemplazar_Caracteres_Acentuados
        /// 
        /// Descripción: Método que realiza la revisión de la cadena que se pasa como parámetro
        ///              al método y que si encuentra algún carácter acentuado lo remplaza por su
        ///              su equivalente hexadecimal.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Cadena"></param>
        /// <returns></returns>
        private StringBuilder Reemplazar_Caracteres_Acentuados(StringBuilder Cadena)
        {
            try
            {
                foreach (string Valor in Valores_Reemplazar.Keys)
                    Cadena = Cadena.Replace(Valor, Valores_Reemplazar[Valor]);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Reemplazar_Caracteres_Acentuados]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Cadena;
        }
        /// <summary>
        /// Nombre: Generar_Cadena_Proteccion
        /// 
        /// Descripción: Método que genera el código que se enviara a impresión como código de barras.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Longitud"></param>
        /// <returns></returns>
        public string Generar_Cadena_Proteccion(int Longitud)
        {
            char[] Caracteres = new char[Longitud];
            var Aleatortio = new Random();

            try
            {
                // Si la longitud solicitada es 0 ó menos asignar 10
                if (Longitud <= 0)
                    Longitud = 10;

                // Ciclo para llenar el arreglo de caracteres
                for (int i = 0; i < Caracteres.Length; i++)
                    // asignar un caracter aleatorio al arreglo de carácteres.
                    Caracteres[i] = Caracteres_Validos[Aleatortio.Next(Cantidad_Caracteres)];
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Generar_Cadena_Proteccion]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new String(Caracteres);
        }
        #endregion

        #endregion

        #region (Eventos)

        #endregion

        /// <summary>
        /// Nombre: Txt_Codigo_Barras_KeyUp
        /// 
        /// Descripción: Método que se ejecuta al presionar una tecla en la caja de código de barras.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 21-feb-2014
        /// Causa modificación: Se cambia <DateTime?> por <MySql.Data.Types.MySqlDateTime?> para recibir 
        ///                     un campo fecha al utilizar una base de datos MySQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Codigo_Barras_KeyUp(object sender, KeyEventArgs e)
        {
            // entrar solamente con la tecla enter
            if (e.KeyCode == Keys.Return && Txt_Codigo_Barras.Text.Length > 0)
            {

                Cls_Ope_Estacionamiento_Negocio Obj_Estacionamiento;
                DataTable Dt_Datos_Acceso_Estacionamiento = null;
                DataTable Dt_Datos_Pago = null;
                string Producto_ID = string.Empty;
                string No_Estacionamiento = string.Empty;
                string Estatus = string.Empty;
                MySql.Data.Types.MySqlDateTime? Fecha_Hora_Ingreso = null;
                double Horas = 0;

                try
                {
                    Obj_Estacionamiento = new Cls_Ope_Estacionamiento_Negocio();
                    Obj_Estacionamiento.P_Codigo = Txt_Codigo_Barras.Text.Trim();
                    Dt_Datos_Acceso_Estacionamiento = Obj_Estacionamiento.Consultar_Estacionamiento();

                    // validar que la consulta haya regresado resultados
                    if (Dt_Datos_Acceso_Estacionamiento != null && Dt_Datos_Acceso_Estacionamiento.Rows.Count > 0)
                    {
                        Array.ForEach(Dt_Datos_Acceso_Estacionamiento.Rows.OfType<DataRow>().ToArray(), fila =>
                        {
                            Producto_ID = fila.IsNull(Ope_Estacionamiento.Campo_Producto_ID) ? string.Empty : fila.Field<string>(Ope_Estacionamiento.Campo_Producto_ID);
                            Fecha_Hora_Ingreso = fila.IsNull(Ope_Estacionamiento.Campo_Fecha_Hora_Ingreso) ? null : fila.Field<MySql.Data.Types.MySqlDateTime?>(Ope_Estacionamiento.Campo_Fecha_Hora_Ingreso);
                            No_Estacionamiento = fila.IsNull(Ope_Estacionamiento.Campo_No_Estacionamiento) ? string.Empty : fila.Field<string>(Ope_Estacionamiento.Campo_No_Estacionamiento);
                            Estatus = fila.IsNull(Ope_Estacionamiento.Campo_Estatus) ? string.Empty : fila.Field<string>(Ope_Estacionamiento.Campo_Estatus);
                        });

                        // si el estatus del acceso es PENDIENTE, entrar al pago
                        if (Estatus.Equals("PENDIENTE"))
                        {
                            // se ocupa .GetDateTime() cuando es un tipo MySqlDateTime
                            Horas = Math.Ceiling(DateTime.Now.Subtract(Fecha_Hora_Ingreso.Value.GetDateTime()).Duration().TotalHours);

                            Obj_Estacionamiento.P_Estatus = "PAGADO";
                            Obj_Estacionamiento.P_Fecha_Hora_Salida = DateTime.Now;
                            Obj_Estacionamiento.P_Horas = Convert.ToInt32(Horas);
                            Obj_Estacionamiento.P_No_Estacionamiento = No_Estacionamiento;

                            Dt_Datos_Pago = Crear_Datos_Pago(Producto_ID, Convert.ToDecimal(Horas), ref Obj_Estacionamiento);

                            Frm_Ope_Pago Frm_Pago = new Frm_Ope_Pago();
                            Frm_Pago.P_Obj_Estacionamiento = Obj_Estacionamiento;
                            Frm_Pago.Es_Pago_Estacionamiento = true;
                            Frm_Pago.MdiParent = this.ParentForm;
                            Frm_Pago.Set_Dt_Detalles_Venta(Dt_Datos_Pago);
                            Frm_Pago.Set_Frm_Estacionamiento(this);
                            this.Hide();
                            Frm_Pago.Show();

                        }
                        else
                        {
                            Txt_Codigo_Barras.Text = string.Empty;
                            MessageBox.Show(this, "El acceso al estacionamiento tiene un estatus de " + Estatus, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        Txt_Codigo_Barras.Text = string.Empty;
                        MessageBox.Show(this, "No se encontró el código de acceso ingresado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "Error - Método: [Txt_Codigo_Barras_KeyPress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
