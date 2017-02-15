using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Operaciones.Recolecciones.Negocio;
using Erp.Metodos_Generales;
using System.Threading;
using System.Globalization;
using Erp.Validador;
using Erp.Constantes;
using ResizeableForm;
using Erp_Apl_Parametros.Negocio;
using System.Collections.Generic;
using Erp.Sesiones;
using ERP_BASE.Paginas.Paginas_Generales;
//using jp.co.epson.uposcommon;
using System.Reflection;
using Microsoft.PointOfService;
using Erp_Apl_Parametros.Negocio;
using Erp_Solicitud_Facturacion.Negocio;
using Operaciones.Cajas.Negocio;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Seguridad;
using MySql.Data.MySqlClient;
using System.Data.Odbc;


namespace ERP_BASE.Paginas.Operacion
{
    public partial class Frm_Ope_Recolecciones : Form
    {
        PosPrinter m_Printer = null;
        Validador_Generico Validador;
        string Usuario_Autoriza;//Identificador del empleado que autoriza el movimiento.
        string Usuario_Autoriza_Nombre;
        string Monto_A_Depositar_Cierre = ""; 
        TextBox Caja_Activo = new TextBox();//Variable para almacenar el control que tiene el foco en los controles con denominación de 
        //Billetes o Monedas.


        #region (Init/Load)
        public Frm_Ope_Recolecciones()
        {
            InitializeComponent();
            this.Txt_No_Billetes_1000.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Billetes_500.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Billetes_200.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Billetes_100.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Billetes_50.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Billetes_20.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_20.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_10.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_5.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_2.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_1.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_050.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_020.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            this.Txt_No_Monedas_010.GotFocus += new System.EventHandler(this.Caja_GotFocus);
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        #endregion

        #region (Metodos)

        #region (Generales)
        /// <summary>
        /// Nombre: Frm_Ope_Recoleccion_Load
        /// 
        /// Descripción: Método que realiza la carga inicial de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 09 Octubre 2013 18:42 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Ope_Recoleccion_Load(object sender, EventArgs e)
        {
            if (MDI_Frm_Apl_Principal.Opt_Arqueos)
                this.Text = "Arqueo";
            else if (MDI_Frm_Apl_Principal.Opt_Cierre)
                this.Text = "Cierre";

            Cls_Metodos_Generales.Validar_Acceso_Sistema("Retiros", this);//Valida las operaciones que puede realizar el usuario logueado.
            Cls_Ope_Recolecciones_Negocio Obj_Recoleccion = new Cls_Ope_Recolecciones_Negocio();//Variable para realizar peticiones a la clase de negocios.
            DataTable Dt_Cajas = null;//Variable para guardar los registros consultados de la tabla de cajas.
            DataTable Dt_Cajas_Equipo = null;//Variable para guardar los registros consultados de la tabla de cajas.
            DataTable Dt_Bancos = null;//Variable para guardar los registros consultados de la tabla de bancos.

            //Opt_Cierre_Caja.Checked = false;
            //Opt_Recoleccion.Checked = false;
            //Opt_Arqueo.Checked = false;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-Mx");
                Limpiar_Controles();

                //Se consulta las cajas que se encuentran abiertas

                if (this.Text == "Arqueo")
                {
                    Dt_Cajas = Obj_Recoleccion.Consultar_Cajas();

                    Dt_Cajas_Equipo = Obj_Recoleccion.Consultar_Cajas();

                    Dt_Bancos = Obj_Recoleccion.Consultar_Bancos();
                    Cmb_Cajas.Enabled = false;
                
                }
                else
                {
                    Dt_Cajas = Obj_Recoleccion.Consultar_Cajas();

                    Obj_Recoleccion.P_Nombre_Equipo = Environment.MachineName;
                    Dt_Cajas_Equipo = Obj_Recoleccion.Consultar_Cajas();

                    Dt_Bancos = Obj_Recoleccion.Consultar_Bancos();
                    Cmb_Cajas.Enabled = true;
                
                }

                if (!Dt_Cajas.AsEnumerable().Any())
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        //  se activan los menus de recoleccino, arqueo, cierre de caja
                        MDI_Frm_Apl_Principal Frm_Principal = (MDI_Frm_Apl_Principal)this.MdiParent;
                        Frm_Principal.recoleccionesToolStripMenuItem.Enabled = true;
                        Frm_Principal.SubMenu_Operacion_Arqueo.Enabled = true;
                        Frm_Principal.SubMenu_Operacion_Cierre_Caja.Enabled = true;

                        MessageBox.Show(this, "No se encuentra ninguna caja abierta por el momento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Frm_Ope_Recolecciones_FormClosing(sender, null);
                        this.Dispose();
                    });
                }

                if (!Dt_Cajas_Equipo.AsEnumerable().Any())
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        //  se activan los menus de recoleccino, arqueo, cierre de caja
                        MDI_Frm_Apl_Principal Frm_Principal = (MDI_Frm_Apl_Principal)this.MdiParent;
                        Frm_Principal.recoleccionesToolStripMenuItem.Enabled = true;
                        Frm_Principal.SubMenu_Operacion_Arqueo.Enabled = true;
                        Frm_Principal.SubMenu_Operacion_Cierre_Caja.Enabled = true;

                        MessageBox.Show(this, "El equipo no tiene caja asignada con la cual realizar operaciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Frm_Ope_Recolecciones_FormClosing(sender, null);
                        this.Dispose();
                    });
                }


                if (!Dt_Bancos.AsEnumerable().Any())
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        //  se activan los menus de recoleccino, arqueo, cierre de caja
                        MDI_Frm_Apl_Principal Frm_Principal = (MDI_Frm_Apl_Principal)this.MdiParent;
                        Frm_Principal.recoleccionesToolStripMenuItem.Enabled = true;
                        Frm_Principal.SubMenu_Operacion_Arqueo.Enabled = true;
                        Frm_Principal.SubMenu_Operacion_Cierre_Caja.Enabled = true;

                        MessageBox.Show(this, "No se encuentra ningun banco registrado por el momento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Frm_Ope_Recolecciones_FormClosing(sender, null);
                        this.Dispose();
                    });
                }
                

                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Cajas, Dt_Cajas_Equipo, Cat_Cajas.Campo_Comentarios, "No_Caja");
                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Bancos, Dt_Bancos, Cat_Bancos.Campo_Cuenta, "Cuenta");
                  
                Manejo_Botones_Operacion("Cancelar");
                Validador = new Validador_Generico(Erp_Validaciones);
                Erp_Validaciones.Clear();


                if (this.Text != "Arqueo")
                {
                    Cmb_Cajas.Enabled = false;
                }
                else
                {
                    Cmb_Cajas.Enabled = true;
                }

                ///*************** Impresora de Tickets ***************/
                //string strLogicalName = "PosPrinter";

                //PosExplorer posExplorer = new PosExplorer();
                //DeviceInfo deviceInfo = null;

                //deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName);
                //m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);

                ////<<<step9>>>--Start	
                ////Register OutputCompleteEvent
                //AddOutputCompleteEvent(m_Printer);
                ////<<<step9>>>--End
                ////<<<step10>>>--Start	
                ////Register OutputCompleteEvent
                //AddErrorEvent(m_Printer);
                ////Register OutputCompleteEvent
                //AddStatusUpdateEvent(m_Printer);

                //m_Printer.Open();
                //m_Printer.Claim(1000);
                //m_Printer.DeviceEnabled = true;
                //m_Printer.RecLetterQuality = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Metodo: [Frm_Ope_Retiros_Load]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add StatusUpdateEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void AddStatusUpdateEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo statusUpdateEvent = eventSource.GetType().GetEvent("StatusUpdateEvent");
            if (statusUpdateEvent != null)
            {
                statusUpdateEvent.AddEventHandler(eventSource,
                    new StatusUpdateEventHandler(OnStatusUpdateEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// Add ErrorEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void AddErrorEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo errorEvent = eventSource.GetType().GetEvent("ErrorEvent");
            if (errorEvent != null)
            {
                errorEvent.AddEventHandler(eventSource,
                    new DeviceErrorEventHandler(OnErrorEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// Error Event.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OnErrorEvent(object source, DeviceErrorEventArgs e)
        {
            if (InvokeRequired)
            {
                //Ensure calls to Windows Form Controls are from this application's thread
                Invoke(new DeviceErrorEventHandler(OnErrorEvent), new object[2] { source, e });
                return;
            }

            //<<<step10>>>--Start
            DialogResult dialogResult;

            string strMessage = "Printer Error\n\n" + "ErrorCode = " + e.ErrorCode.ToString()
                + "\n" + "ErrorCodeExtended = " + e.ErrorCodeExtended.ToString();

            dialogResult = MessageBox.Show(strMessage, "PrinterSample_Step11"
                , MessageBoxButtons.RetryCancel);

            if (dialogResult == DialogResult.Cancel)
            {
                e.ErrorResponse = ErrorResponse.Clear;
            }
            else if (dialogResult == DialogResult.Retry)
            {
                e.ErrorResponse = ErrorResponse.Retry;
            }
            //<<<step10>>>--End

        }

        protected void AddOutputCompleteEvent(object eventSource)
        {
            EventInfo statusUpdateEvent = eventSource.GetType().GetEvent("StatusUpdateEvent");
            if (statusUpdateEvent != null)
            {
                statusUpdateEvent.RemoveEventHandler(eventSource,
                    new StatusUpdateEventHandler(OnStatusUpdateEvent));
            }
        }

        /// <summary>
        /// StatusUpdateEvnet.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OnStatusUpdateEvent(object source, StatusUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                //Ensure calls to Windows Form Controls are from this application's thread
                Invoke(new StatusUpdateEventHandler(OnStatusUpdateEvent), new object[2] { source, e });
                return;
            }

            //When there is a change of the status on the printer, the event is fired.
            switch (e.Status)
            {
                //Printer cover is open.
                case PosPrinter.StatusCoverOpen:
                    //m_btnStateByCover = false;
                    break;
                //No receipt paper.
                case PosPrinter.StatusReceiptEmpty:
                    //m_btnStateByPaper = false;
                    break;
                //'Printer cover is close.
                case PosPrinter.StatusCoverOK:
                    //m_btnStateByCover = true;
                    break;
                //'Receipt paper is ok.
                case PosPrinter.StatusReceiptPaperOK:
                case PosPrinter.StatusReceiptNearEmpty:
                    //m_btnStateByPaper = true;
                    break;
            }
        }

        /// <summary>
        /// Nombre: Manejo_Botones_Operacion
        /// 
        /// Descripción: Método que establecera la configuración de los botones según la operación a realizar.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 18:43 p.m.
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
                        Btn_Consultar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Pnl_Monedas.Enabled = true;
                        Pnl_Billetes.Enabled = true;
                        Pnl_Teclado.Enabled = true;
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
                        Btn_Consultar.Enabled = false;
                        Btn_Salir.Enabled = true;

                        Pnl_Monedas.Enabled = true;
                        Pnl_Billetes.Enabled = true;
                        Pnl_Teclado.Enabled = true;
                        Erp_Validaciones.Clear();
                        break;
                    }
                case "Cancelar":
                    {
                        Habilitar = false;
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Modificar.Text = "Modificar";
                        Btn_Eliminar.Text = "Cancelar";
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Btn_Consultar.Enabled = true;
                        Btn_Salir.Enabled = true;

                        Pnl_Monedas.Enabled = false;
                        Pnl_Billetes.Enabled = false;
                        Pnl_Teclado.Enabled = false;
                        this.Usuario_Autoriza = string.Empty;
                        Erp_Validaciones.Clear();
                        break;
                    }
                default: break;
            }

            Txt_No_Recoleccion.Enabled = false;
            Cmb_Cajas.Enabled = false;
            Dtp_Fecha_Recoleccion.Enabled = Habilitar;
            Dtp_Hora_Recoleccion.Enabled = Habilitar;
            Opt_Recoleccion.Enabled = Habilitar;
            Opt_Cierre_Caja.Enabled = Habilitar;
            Opt_Arqueo.Enabled = Habilitar;
            Txt_Numero_Recoleccion.Enabled = false;
            Txt_Monto_Recolectado.Enabled = false;
            Pnl_Totales.Enabled = false;
            Txt_Horario_Turno.Enabled = false;
            Txt_Total_En_Caja.Enabled = false;
            Txt_Total_Tarjeta.Enabled = false;

            if (MDI_Frm_Apl_Principal.Opt_Arqueos == false)
            {
                if (Cmb_Cajas.Items.Count == 2)
                {
                    Cmb_Cajas.SelectedIndex = 1;
                    Cmb_Cajas_SelectedIndexChanged(Cmb_Cajas, EventArgs.Empty);
                    //Cmb_Cajas.Enabled = true;
                }
                if (Cmb_Bancos.Items.Count == 2)
                {
                    Cmb_Bancos.SelectedIndex = 1;
                }
            }
            else
            {
                TXt_Resultado_Corte.Visible = false;
                Txt_Total_En_Caja.Visible = false;
            }

        }
        /// <summary>
        /// Nombre: Limpiar_Controles
        /// 
        /// Descripción: Método que limpia los controles de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 18:43 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Limpiar_Controles()
        {
            try
            {
                Cmb_Cajas.Focus();
                Txt_No_Recoleccion.Text = string.Empty;

                if (Cmb_Cajas.Items.Count == 0)
                    Cmb_Cajas.SelectedIndex = (-1);
                else if (Cmb_Cajas.Items.Count == 2)
                    Cmb_Cajas.SelectedIndex = 1;


                Dtp_Fecha_Recoleccion.Value = DateTime.Now;
                Dtp_Hora_Recoleccion.Value = DateTime.Now;
                Opt_Recoleccion.Checked = false;
                Opt_Cierre_Caja.Checked = false;
                Opt_Arqueo.Checked = false;
                Txt_Numero_Recoleccion.Text = string.Empty;
                Txt_Monto_Recolectado.Text = string.Empty;
                Txt_Horario_Turno.Text = string.Empty;
                Txt_Total_En_Caja.Text = string.Empty;
                Txt_Total_Tarjeta.Text = string.Empty;
                Pnl_Contenedor.Tag = null;
                Caja_Activo = new TextBox();

                Array.ForEach(Pnl_Billetes.Controls.OfType<TextBox>().ToArray(), caja => { caja.Text = string.Empty; caja.BackColor = SystemColors.Window; });
                Array.ForEach(Pnl_Monedas.Controls.OfType<TextBox>().ToArray(), caja => { caja.Text = string.Empty; caja.BackColor = SystemColors.Window; });
                Array.ForEach(Pnl_Totales.Controls.OfType<TextBox>().ToArray(), caja => { caja.Text = string.Empty; });

                Array.ForEach(GPnl_Datos_Movimiento.Controls.OfType<TextBox>().ToArray(), caja => { caja.Text = string.Empty; caja.BackColor = SystemColors.Window; });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Limpiar_Controles]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Operación)
           /// <summary>
        /// Nombre: Alta_Recoleccion
        /// 
        /// Descripción: Método que realiza el alta de los datos de las recolecciones.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 09:20 a.m.
        /// Usuario Modifico::
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private void Habilitar_Caja()
        {
            try
            {
                if (MDI_Frm_Apl_Principal.Opt_Arqueos == true) Opt_Arqueo.Checked = true;
                else if (MDI_Frm_Apl_Principal.Opt_Cierre == true) Opt_Cierre_Caja.Checked = true;
                else if (MDI_Frm_Apl_Principal.Opt_Recoleccion == true) Opt_Recoleccion.Checked = true;
                Cmb_Cajas.Enabled = true;
                Cmb_Cajas.SelectedIndex = 0;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Habilitar_Caja]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          /// <summary>
        /// Nombre: Alta_Recoleccion
        /// 
        /// Descripción: Método que realiza el alta de los datos de las recolecciones.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 09:20 a.m.
        /// Usuario Modifico::
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private String Texto_Ticket_Recoleccion()
        {
            String Informacion_Ticket = "";

            try
            {
                #region Operaciones
                Double Total_Venta = 0;
                Double Efectivo = 0;
                Double Total_Cierre = 0;
                Double Recoleccion = 0;
                Double Resultado_Arqueo = 0;

                Total_Venta = Convert.ToDouble(Txt_Monto_Inicial.Text) + Convert.ToDouble(Txt_Ventas_Efectivo.Text) + Convert.ToDouble(Txt_Venta_Tarjetas.Text);
                Efectivo = Convert.ToDouble(Txt_Monto_Inicial.Text) + Convert.ToDouble(Txt_Ventas_Efectivo.Text);
                Total_Cierre = Efectivo - Convert.ToDouble(Txt_Retiros_Caja.Text) - (Convert.ToDouble(Txt_Cortes_Caja.Text)) - Convert.ToDouble(Txt_Total_Cancelaciones.Text);
                Recoleccion = Convert.ToDouble(Txt_Cortes_Caja.Text);
                Resultado_Arqueo = Convert.ToDouble(TXt_Resultado_Corte.Text);
                #endregion

               
                Int32 Numero_Recoleccion = 0;
                string Tipo = string.Empty;

                if (Opt_Arqueo.Checked) { Tipo = "Arqueo"; }
                if (Opt_Recoleccion.Checked) { Tipo = "Recolección"; }
                if (Opt_Cierre_Caja.Checked) { Tipo = "Cierre de Caja"; }

                Numero_Recoleccion = Convert.ToInt32(Txt_Numero_Recoleccion.Text) + 1;

                if (Opt_Cierre_Caja.Checked == false)
                {
                    Informacion_Ticket = "\t" + Tipo + "\t\n";
                    Informacion_Ticket += "\tMomias de Guanajuato\t\n";
                    Informacion_Ticket += "Turno: " + Txt_Horario_Turno.Text + "\n";
                    Informacion_Ticket += "Fecha: " + Dtp_Fecha_Recoleccion.Text;
                    Informacion_Ticket += " Hora: " + Dtp_Hora_Recoleccion.Text + "\n";

                    Informacion_Ticket += "Caja: " + Cmb_Cajas.Text + "\n";
                    Informacion_Ticket += "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario + "\n";

                    if (Opt_Arqueo.Checked == true)
                    {
                        Informacion_Ticket += "No. Recolección: " + Numero_Recoleccion.ToString() + "\n\n";
                    }
                    Informacion_Ticket += "--------------------------\n";

                    float Total = 0;

                    foreach (Control text in Pnl_Billetes.Controls)
                    {
                        if (text is TextBox)
                        {
                            if (!string.IsNullOrEmpty(text.Text))
                            {
                                string[] words = text.Name.Split(new char[] { '_' });
                                string Numero = words[words.Length - 1];
                                Total += float.Parse(Numero) * float.Parse(text.Text);

                                Informacion_Ticket += "Billetes de " + Numero + ": \t" + text.Text + "\n";
                            }
                        }
                    }

                    foreach (Control text in Pnl_Monedas.Controls)
                    {
                        if (text is TextBox)
                        {
                            if (!string.IsNullOrEmpty(text.Text))
                            {
                                string[] words = text.Name.Split(new char[] { '_' });
                                string Numero = words[words.Length - 1];

                                if (Numero[0] == '0') { Numero = "." + Numero[1] + Numero[2]; }

                                Total += float.Parse(Numero) * float.Parse(text.Text);

                                Informacion_Ticket += "Monedas de " + Numero + ": \t" + text.Text + "\n";
                            }
                        }
                    }

                    if (Opt_Arqueo.Checked)
                    {
                        Informacion_Ticket += "--------------------------\n";
                        Informacion_Ticket += "Faltante: " + Resultado_Arqueo.ToString("n") + "\n";
                        Informacion_Ticket += "--------------------------\n\n";
                    }

                    if (Opt_Recoleccion.Checked)
                        Informacion_Ticket += "\nTotal Ingresado: " + Total.ToString("C") + "\n";
                    else
                        Informacion_Ticket += "\nTotal Arqueo: " + Total.ToString("C") + "\n";
                }
                else//  para el cierre de caja
                {

                    Informacion_Ticket = "\t" + Tipo + "\t\n";
                    Informacion_Ticket += "\tMomias de Guanajuato\t\n";
                    Informacion_Ticket += "Turno: " + Txt_Horario_Turno.Text + "\n";
                    Informacion_Ticket += "Fecha: " + Dtp_Fecha_Recoleccion.Text;
                    Informacion_Ticket += " Hora: " + Dtp_Hora_Recoleccion.Text + "\n";
                    Informacion_Ticket += "Caja: " + Cmb_Cajas.Text + "\n";
                    Informacion_Ticket += "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario + "\n";

                    #region Montos cierre
                    Informacion_Ticket += "Monto inicial:\t\t" + Txt_Monto_Inicial.Text + "\n";
                    Informacion_Ticket += "Ventas efectivo:\t" + Txt_Ventas_Efectivo.Text + "\n";
                    Informacion_Ticket += "Ventas tarjeta:\t\t" + Txt_Venta_Tarjetas.Text + "\n";
                    Informacion_Ticket += "--------------------------\n";
                    Informacion_Ticket += "Total venta:\t " + Total_Venta.ToString("n") + "\n";
                    Informacion_Ticket += "--------------------------\n";
                    #endregion

                    #region Montos detalle
                    Informacion_Ticket += "Total venta en efectivo:\t\t" + Efectivo.ToString("n") + "\n";
                    Informacion_Ticket += "Retiros:\t\t -" + Txt_Retiros_Caja.Text + "\n";
                    Informacion_Ticket += "Recolecciones:\t -" + Recoleccion.ToString("n") + "\n";
                    Informacion_Ticket += "Cancelaciones:\t -" + Txt_Total_Cancelaciones.Text + "\n";

                    Informacion_Ticket += "--------------------------\n";
                    Informacion_Ticket += "Total en caja:\t\t " + Total_Cierre.ToString("n") + "\n";
                    Informacion_Ticket += "--------------------------\n";
                    #endregion

                    Double Total = 0;

                    #region Billetes
                    foreach (Control text in Pnl_Billetes.Controls)
                    {
                        if (text is TextBox)
                        {
                            if (!string.IsNullOrEmpty(text.Text))
                            {
                                string[] words = text.Name.Split(new char[] { '_' });
                                string Numero = words[words.Length - 1];
                                Total += float.Parse(Numero) * float.Parse(text.Text);

                                Informacion_Ticket += "Billetes de " + Numero + ": \t" + text.Text + "\n";
                            }
                        }
                    }
                    #endregion

                    #region Monedas
                    foreach (Control text in Pnl_Monedas.Controls)
                    {
                        if (text is TextBox)
                        {
                            if (!string.IsNullOrEmpty(text.Text))
                            {
                                string[] words = text.Name.Split(new char[] { '_' });
                                string Numero = words[words.Length - 1];

                                if (Numero[0] == '0') { Numero = "." + Numero[1] + Numero[2]; }

                                Total += float.Parse(Numero) * float.Parse(text.Text);

                                Informacion_Ticket += "Monedas de " + Numero + ": \t" + text.Text + "\n";
                            }
                        }
                    }
                    #endregion

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Texto_Ticket_Recoleccion]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Informacion_Ticket;
        }
        /// <summary>
        /// Nombre: Crear_Tabla_Ventas
        /// 
        /// Descripción: Método que realiza la construccion de las ventas del dia
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 09:20 a.m.
        /// Usuario Modifico: Cruz Amaya Olimpo Alberto 
        /// Fecha Modifico: 14/Febrero /2015
        /// Causa Modificación: Se crea un pdf con los datos del movimiento, el desglose de monedas, el sobrante y faltante y las firmas 
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private DataTable Crear_Tabla_Ventas( Cls_Ope_Recolecciones_Negocio Obj_Recoleccion)
        {
            DataTable Dt_Ventas = new DataTable();
            String Leyenda = "";
            String Nombre_Caja = "";
            String Nombre_Turno = "";
            String Nombre_Turno_Filtro = "";
            String Fecha = "";
            Boolean Estatus = false;
            DataRow Dr_Ventas;
            DataTable Dt_Consulta_Ventas = new DataTable();
            DataTable Dt_Ventas_Mixtas = new DataTable();
            DataTable Dt_Consulta_Ventas_Individual_Mixta = new DataTable();
            String No_Ventas_Pago_Mixto = "";
            try
            {


                Dt_Ventas_Mixtas = Obj_Recoleccion.Consultar_Ventas_Dia_Mixtas();

                foreach (DataRow Registro in Dt_Ventas_Mixtas.Rows)
                {
                    No_Ventas_Pago_Mixto += "'" + Registro["No_Venta"].ToString() + "',";
                }

                //  se remueve la ultima coma
                if (No_Ventas_Pago_Mixto.Length > 0)
                {
                    No_Ventas_Pago_Mixto = No_Ventas_Pago_Mixto.Remove(No_Ventas_Pago_Mixto.Length - 1);
                }



                Obj_Recoleccion.P_No_Venta_Mixto = No_Ventas_Pago_Mixto;
                Dt_Consulta_Ventas = Obj_Recoleccion.Consultar_Ventas_Dia();


                //  proceso para generar los registros de las listas
                Dt_Ventas.Columns.Add("Leyenda");
                Dt_Ventas.Columns.Add("Total");
                Dt_Ventas.Columns.Add("Nombre_Caja");
                Dt_Ventas.Columns.Add("Nombre_Turno");
                Dt_Ventas.Columns.Add("No_Caja");
                Dt_Ventas.Columns.Add("Fecha_Hora_Inicio");
                Dt_Ventas.Columns.Add("Tipo_Pago");
                //Dt_Ventas.Columns.Add("Fecha_4Digitos");

                DataTable Dt_Formas_Pago = Dt_Consulta_Ventas.DefaultView.ToTable(true, "Forma_ID");

                foreach (DataRow Registro_Forma_Id in Dt_Formas_Pago.Rows)
                {
                    //  se forma la leyenda de los boletos vendidos
                    foreach (DataRow Registro in Dt_Consulta_Ventas.Rows)
                    {
                        if (Registro["Forma_ID"].ToString() == Registro_Forma_Id["Forma_Id"].ToString())
                        {
                            Nombre_Turno_Filtro = Registro["Nombre_Turno"].ToString();

                            if (Cmb_Cajas.Text == Registro["Nombre_Caja"].ToString()
                                && Txt_Horario_Turno.Text.Contains(Nombre_Turno_Filtro))
                            {
                                Leyenda += Registro["Leyenda"].ToString() + ",";

                                if (Fecha == "")
                                    Fecha = Registro["Fecha_Hora_Inicio"].ToString();

                                if (Nombre_Caja == "")
                                    Nombre_Caja = "C" + Registro["Numero_Caja"].ToString();

                                if (Nombre_Turno == "")
                                    Nombre_Turno = Registro["Nombre_Turno"].ToString();


                            }

                            Estatus = true;
                        }
                    }

                    //  se remueve la ultima coma
                    if (Leyenda.Length > 0)
                    {
                       Leyenda = Leyenda.Remove(Leyenda.Length - 1);
                    }

                    if (Estatus == true)
                    {
                        Dt_Consulta_Ventas.DefaultView.RowFilter = Ope_Cajas.Campo_No_Caja + "= '" + Cmb_Cajas.SelectedValue.ToString() + "'" +
                                " and " + Ope_Pagos.Campo_Forma_ID + "= '" + Registro_Forma_Id["Forma_Id"].ToString() + "'";

                        Dr_Ventas = Dt_Ventas.NewRow();
                        Dr_Ventas["Leyenda"] = Leyenda;
                        Dr_Ventas["No_Caja"] = Cmb_Cajas.SelectedValue.ToString();
                        Dr_Ventas["Total"] = Dt_Consulta_Ventas.DefaultView.ToTable().Compute("sum (Total)", "").ToString();
                        Dr_Ventas["Nombre_Caja"] = Nombre_Caja;
                        Dr_Ventas["Nombre_Turno"] = Nombre_Turno;
                        Dr_Ventas["Fecha_Hora_Inicio"] = Fecha;
                        Dr_Ventas["Tipo_Pago"] = Registro_Forma_Id["Forma_Id"].ToString();

                        Dt_Ventas.Rows.Add(Dr_Ventas);
                        Dt_Ventas.AcceptChanges();
                    }

                    Estatus = false;
                    Leyenda = "";
                }


                Obj_Recoleccion.P_No_Venta_Mixto = "";

                //  consultar las ventas mixtas
                if (Dt_Ventas_Mixtas != null && Dt_Ventas_Mixtas.Rows.Count > 0)
                {
                    foreach (DataRow Registro_Mixto in Dt_Ventas_Mixtas.Rows)
                    {
                        Obj_Recoleccion.P_No_Venta_Mixto_Agrupada = Registro_Mixto["No_Venta"].ToString();
                        Dt_Consulta_Ventas_Individual_Mixta = Obj_Recoleccion.Consultar_Pago_De_Venta_Mixta();

                        foreach (DataRow Registro_Venta_Mixto in Dt_Consulta_Ventas_Individual_Mixta.Rows)
                        {
                            foreach (DataRow Registro_Ventas in Dt_Ventas.Rows)
                            {
                                if (Registro_Venta_Mixto["Forma_Id"].ToString() == Registro_Ventas["Tipo_Pago"].ToString())
                                {
                                    Registro_Ventas.BeginEdit();

                                    Registro_Ventas["Total"] = Convert.ToDouble(Registro_Ventas["Total"].ToString()) + Convert.ToDouble(Registro_Venta_Mixto["Monto_Pago"].ToString());
                                    Registro_Ventas["leyenda"] = Registro_Ventas["leyenda"].ToString() + ", 1-$" + Registro_Venta_Mixto["Monto_Pago"].ToString();

                                    Registro_Ventas.EndEdit();
                                    Dt_Ventas.AcceptChanges();
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Crear_Tabla_Ventas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Dt_Ventas;
        }
        /// <summary>
        /// Nombre: Alta_Recoleccion
        /// 
        /// Descripción: Método que realiza el alta de los datos de las recolecciones.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 09:20 a.m.
        /// Usuario Modifico: Cruz Amaya Olimpo Alberto 
        /// Fecha Modifico: 14/Febrero /2015
        /// Causa Modificación: Se crea un pdf con los datos del movimiento, el desglose de monedas, el sobrante y faltante y las firmas 
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private Boolean Alta_Recoleccion(String Informacion_Ticket)
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recoleccion = new Cls_Ope_Recolecciones_Negocio();//Variable que se utiliza para realizar peticiones a la clase de negocios.
            Cls_Cat_Lista_Deudorcad_Negocio Rs_Consulta_Listas = new Cls_Cat_Lista_Deudorcad_Negocio();

            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Consulta_Lista_Deudorcad = new DataTable();
            
            bool Estatus = false;//Variable que mantiene el estatus de la operación que se ejecuta.
            Boolean Validacion_Conexion = false;

            DataTable Dt_Consultar_Referencias_Online = new DataTable();
            DataTable Dt_Consultar_Referencias_Local = new DataTable();
            DateTime Fecha;

            Boolean Bol_Estatus_Referencias = false;

            try
            {
                Obj_Recoleccion.P_Texto_Ticket = Informacion_Ticket;
                Monto_A_Depositar_Cierre = "";
               

                 // selección de tipo de recolección
                if (true == Opt_Cierre_Caja.Checked)
                {
                    #region Parametro
                    Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                    Consulta_Parametros.P_Parametro_Id = "00001";
                    Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
                    Obj_Recoleccion.P_Cuenta_Momias = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Cuenta_Museo].ToString();
                    Obj_Recoleccion.P_Lista_Adeudo = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                    Obj_Recoleccion.P_Tipo_Adeudo = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                    Obj_Recoleccion.P_Clave_Venta = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Clave_Venta_Deudorcad].ToString();
                    Obj_Recoleccion.P_Clave_Sobrante = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Clave_Sobrante_Deudorcad].ToString();
                    #endregion

                    #region Validacion de conexion Deudorcad

                    String StrConexion = "";                 

                    try
                    {
                        if (Dt_Consulta.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                        {
                            #region Version odbc

                            foreach (DataRow Registro in Dt_Consulta.Rows)
                            {
                                StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                                StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                                StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                                StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                                StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                                StrConexion += "OPTION=3";
                            }

                            using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))
                            {
                                using (OdbcCommand Cmd = new OdbcCommand())
                                {
                                    MyConnection.Open();
                                    MyConnection.Close();
                                }
                            }

                            Validacion_Conexion = true;
                            #endregion
                        }
                        else
                        {
                            #region version 5

                            foreach (DataRow Registro in Dt_Consulta.Rows)
                            {
                                StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                                StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                                StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                                StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                            }

                            //  revisamos la conexion
                            MySqlConnection Obj_Conexion = null;
                            Obj_Conexion = new MySqlConnection(StrConexion);
                            Obj_Conexion.Open();
                            Obj_Conexion.Close();
                            Validacion_Conexion = true;
                            #endregion
                        }


                        //  se consultaran las referencias locales del deudorcad contra "Online"
                        Cls_Ope_Solicitud_Facturacion_Negocio Rs_Consulta_Online = new Cls_Ope_Solicitud_Facturacion_Negocio();

                        Rs_Consulta_Online.P_Curp = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Cuenta_Museo].ToString();
                        Rs_Consulta_Online.P_Tipo = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                        Rs_Consulta_Online.P_Lista = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                        Rs_Consulta_Online.P_Dt_Parametros = Dt_Consulta;

                        // consulta online
                        Dt_Consultar_Referencias_Online = Rs_Consulta_Online.Consultar_Contribuyente();

                        // consulta local
                        Dt_Consultar_Referencias_Local = Rs_Consulta_Online.Consultar_Contribuyente_Local();


                        //  validamos que tenga informacion en ambos lados
                        if ((Dt_Consultar_Referencias_Online.Rows.Count > 0 && Dt_Consultar_Referencias_Online != null)
                            && (Dt_Consultar_Referencias_Local.Rows.Count > 0 && Dt_Consultar_Referencias_Local != null))
                        {
                            //  validamos la referencia1
                            if (Dt_Consultar_Referencias_Online.Rows[0]["referencia1"].ToString() != Dt_Consultar_Referencias_Local.Rows[0]["referencia1"].ToString())
                            {
                                Bol_Estatus_Referencias = true;
                            }

                            //  validamos la referencia2
                            if (Dt_Consultar_Referencias_Online.Rows[0]["referencia2"].ToString() != Dt_Consultar_Referencias_Local.Rows[0]["referencia2"].ToString())
                            {
                                Bol_Estatus_Referencias = true;
                            }

                            Rs_Consulta_Online.P_Referencia1_Actualizacion = Dt_Consultar_Referencias_Online.Rows[0]["referencia1"].ToString();
                            Rs_Consulta_Online.P_Referencia2_Actualizacion = Dt_Consultar_Referencias_Online.Rows[0]["referencia2"].ToString();

                        }// fin de la validacion referencias


                        //  se realizara la actualizacion de los cambios de referencia
                        if (Bol_Estatus_Referencias == true)
                        {
                            Rs_Consulta_Online.Actualizar_Referencias_Locales();
                        }

                    }
                    catch (Exception Excepcion)
                    {
                        Validacion_Conexion = false;
                    }

                    #endregion


                    #region Referencia
                    //  se consulta la referencia 1 y referencia 2 basandonos en la cuenta momias
                    Cls_Ope_Solicitud_Facturacion_Negocio Rs_Consulta = new Cls_Ope_Solicitud_Facturacion_Negocio();
                    DataTable Dt_Consulta_Contribuyente = new DataTable();

                    Rs_Consulta.P_Curp = Obj_Recoleccion.P_Cuenta_Momias;
                    Rs_Consulta.P_Tipo = Obj_Recoleccion.P_Tipo_Adeudo;
                    Rs_Consulta.P_Lista = Obj_Recoleccion.P_Lista_Adeudo;
                    Rs_Consulta.P_Dt_Parametros = Dt_Consulta;

                    if (Validacion_Conexion == true)
                    {
                        Dt_Consulta_Contribuyente = Rs_Consulta.Consultar_Contribuyente();
                        Rs_Consulta.P_Rfc = Obj_Recoleccion.P_Cuenta_Momias;
                        Dt_Consulta_Contribuyente = Rs_Consulta.Consultar_Contribuyente();
                    }
                    else
                    {
                        Dt_Consulta_Contribuyente = Rs_Consulta.Consultar_Contribuyente_Local();
                        Rs_Consulta.P_Rfc = Obj_Recoleccion.P_Cuenta_Momias;
                        Dt_Consulta_Contribuyente = Rs_Consulta.Consultar_Contribuyente_Local();
                    }


                    ////  se valida que contenga informacion del contribuyente
                    //if (Dt_Consulta_Contribuyente.Rows.Count == 0)
                    //{
                    //    Rs_Consulta.P_Rfc = Obj_Recoleccion.P_Cuenta_Momias;
                    //    Dt_Consulta_Contribuyente = Rs_Consulta.Consultar_Contribuyente();
                    //}

                    // //  se valida que contenga informacion del contribuyente
                    //if (Dt_Consulta_Contribuyente.Rows.Count == 0)
                    //{
                    //    MessageBox.Show(this, "No existe cuenta en list deudor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return false;
                    //}


                    foreach (DataRow Registro in Dt_Consulta_Contribuyente.Rows)
                    {
                        Obj_Recoleccion.P_Referencia1 = Registro["referencia1"].ToString();
                        Obj_Recoleccion.P_Referencia2 = Registro["referencia2"].ToString();
                    }
                    #endregion

                    #region listas deudorcad
                    Rs_Consulta_Listas.P_Operacion = "Venta general";
                    Rs_Consulta_Listas.P_Estatus = "ACTIVO";
                    Dt_Consulta_Lista_Deudorcad = Rs_Consulta_Listas.Consultar_Listas();
                    #endregion
                }

                #region (Set Datos Generales Recolección)
                
                
                Obj_Recoleccion.P_No_Caja = Cmb_Cajas.SelectedValue.ToString();
                Obj_Recoleccion.P_Fecha_Venta = DateTime.Now.ToString("yyyy-MM-dd");
                Obj_Recoleccion.P_Nombre_Caja = Cmb_Cajas.SelectedValue.ToString();
                Obj_Recoleccion.P_Dt_Ventas_Dia = Crear_Tabla_Ventas(Obj_Recoleccion);
                Obj_Recoleccion.P_Dt_Listas_Deudorcad = Dt_Consulta_Lista_Deudorcad;

                Obj_Recoleccion.P_Nombre_Caja = Cmb_Cajas.Text;
                Obj_Recoleccion.P_Fecha_Hora = DateTime.Now;
                Obj_Recoleccion.P_Monto_Recolectado = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Monto_Recolectado.Text) ? "0.0" : Txt_Monto_Recolectado.Text.Trim());
                Obj_Recoleccion.P_Numero_Recoleccion = Convert.ToInt32(string.IsNullOrEmpty(Txt_Numero_Recoleccion.Text) ? "0" : Txt_Numero_Recoleccion.Text.Trim());
                Obj_Recoleccion.P_Usuario_ID_Recolecta = this.Usuario_Autoriza;
                Obj_Recoleccion.P_Estatus = "RECOLECTADO";

                //Pedimos la observacion
                string Observacion = Microsoft.VisualBasic.Interaction.InputBox("Introduzca una observación.", "Observaciones", string.Empty);
                
                if (!string.IsNullOrEmpty(Observacion))
                    Obj_Recoleccion.P_Observacion = Observacion;
                //Si no hay observacion.
                else
                   Obj_Recoleccion.P_Observacion = ""; 
                

                Obj_Recoleccion.P_Total_Cancelaciones = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Total_Cancelaciones.Text) ? "0.0" : Txt_Total_Cancelaciones.Text.Trim());
                Obj_Recoleccion.P_Total_Tarjeta = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Total_Tarjeta.Text) ? "0.0" : Txt_Total_Tarjeta.Text.Trim());
                Obj_Recoleccion.P_Resultado_Corte = Convert.ToDecimal(string.IsNullOrEmpty(TXt_Resultado_Corte.Text) ? "0.0" : TXt_Resultado_Corte.Text.Trim());
                Obj_Recoleccion.P_Total_Retiros = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Retiros_Caja.Text) ? "0.0" : Txt_Retiros_Caja.Text.Trim());
                Obj_Recoleccion.P_Total_Cortes = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Cortes_Caja.Text) ? "0.0" : Txt_Cortes_Caja.Text.Trim());
                //Obj_Recoleccion.P_Monto_Depositar = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Monto_Depositar.Text) ? "0.0" : Txt_Monto_Depositar.Text.Trim());
                Obj_Recoleccion.P_Total_Caja_Sistema = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Total_En_Caja.Text) ? "0.0" : Txt_Total_En_Caja.Text.Trim());
               
                // selección de tipo de recolección
                if (true == Opt_Cierre_Caja.Checked && this.Text == "Cierre")
                {
                    Obj_Recoleccion.P_Tipo = "CIERRE";
                }
                else if (true == Opt_Arqueo.Checked && this.Text == "Arqueo")
                {
                    Obj_Recoleccion.P_Tipo = "ARQUEO";
                    Obj_Recoleccion.P_Estatus = "ARQUEO";
                }
                else if (Opt_Recoleccion.Checked == true && this.Text == "Recoleccion")
                {
                    Obj_Recoleccion.P_Tipo = "RECOLECCION";
                }
                else
                {

                    throw new Exception("No se detecta que operacion realizar");
                }
                #endregion

                #region (Set Detalles Recolección)
                Obj_Recoleccion.P_Billetes_1000 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_1000.Text) ? "0" : Txt_No_Billetes_1000.Text.Trim());
                Obj_Recoleccion.P_Billetes_500 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_500.Text) ? "0" : Txt_No_Billetes_500.Text.Trim());
                Obj_Recoleccion.P_Billetes_200 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_200.Text) ? "0" : Txt_No_Billetes_200.Text.Trim());
                Obj_Recoleccion.P_Billetes_100 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_100.Text) ? "0" : Txt_No_Billetes_100.Text.Trim());
                Obj_Recoleccion.P_Billetes_50 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_50.Text) ? "0" : Txt_No_Billetes_50.Text.Trim());
                Obj_Recoleccion.P_Billetes_20 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_20.Text) ? "0" : Txt_No_Billetes_20.Text.Trim());
                Obj_Recoleccion.P_Monedas_20 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_20.Text) ? "0" : Txt_No_Monedas_20.Text.Trim());
                Obj_Recoleccion.P_Monedas_10 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_10.Text) ? "0" : Txt_No_Monedas_10.Text.Trim());
                Obj_Recoleccion.P_Monedas_5 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_5.Text) ? "0" : Txt_No_Monedas_5.Text.Trim());
                Obj_Recoleccion.P_Monedas_2 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_2.Text) ? "0" : Txt_No_Monedas_2.Text.Trim());
                Obj_Recoleccion.P_Monedas_1 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_1.Text) ? "0" : Txt_No_Monedas_1.Text.Trim());
                Obj_Recoleccion.P_Monedas_050 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_050.Text) ? "0" : Txt_No_Monedas_050.Text.Trim());
                Obj_Recoleccion.P_Monedas_020 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_020.Text) ? "0" : Txt_No_Monedas_020.Text.Trim());
                Obj_Recoleccion.P_Monedas_010 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_010.Text) ? "0" : Txt_No_Monedas_010.Text.Trim());
                #endregion

                Obj_Recoleccion.P_Monto_Depositar = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Monto_Depositar.Text) ? "0.0" : Txt_Monto_Depositar.Text.Trim());
                
                //Se realiza el alta de la recolección.
                Obj_Recoleccion = Obj_Recoleccion.Alta_Recoleccion();

                //Se imprime un pdf con la información de la recoleccion. 
                if(Obj_Recoleccion.P_Accion == true)
                    Exportar_PDF(Obj_Recoleccion);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Alta_Retiro]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Obj_Recoleccion.P_Accion;
           
        }

        /// <summary>
        /// Nombre: Btn_Exportar_PDF_Click
        /// 
        /// Descripción: Método que exporta el listado de la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:37 Hrs.
        /// Usuario Modifico: Cruz Amaya Olimpo Alberto 
        /// Fecha Modifico: 14/Febrero /2015
        /// Causa Modificación: Se crea un pdf con los datos del movimiento, el desglose de monedas, el sobrante y faltante y las firmas 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool Exportar_PDF(Cls_Ope_Recolecciones_Negocio MyObj_Recoleccion)
        {
            bool ErrorPDF = false; 
                try
                {
                    
                    iTextSharp.text.Document Documento = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 10);
                    iTextSharp.text.Document Documento_Copia = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 10);
                    // Path que guarda el reporte en los archivos temporales de windows.
                    //CultureInfo ci = new CultureInfo("de-DE");

                    string Fecha = DateTime.Now.ToString("dd-MMM-yyyy hh.mm.ss tt");
                    string Nombre_Archivo =  MyObj_Recoleccion.P_Tipo +" "+Fecha+ ".pdf";
                    string Ruta_Archivo = ObtenerRutaArchivo(Nombre_Archivo);
                    
                    //Copia de seguridad del archivo
                    string Ruta_Archivo_Copia = (System.IO.Path.GetTempPath() + Nombre_Archivo);
                    
                    FileStream Archivo = new FileStream(Ruta_Archivo, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                    FileStream Archivo_Copia = new FileStream(Ruta_Archivo_Copia, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                    
                    iTextSharp.text.pdf.PdfWriter.GetInstance(Documento, Archivo);
                    iTextSharp.text.pdf.PdfWriter.GetInstance(Documento_Copia, Archivo_Copia);
                    
                    Documento.Open();
                    Exportar_Datos_PDF(Documento, MyObj_Recoleccion);
                    Documento.Close();
                    
                    //Ficha de Deposito Bancario 
                    if (MyObj_Recoleccion.P_Tipo == "CIERRE" || MyObj_Recoleccion.P_Tipo == "RECOLECCION")
                    {
                        string Nombre_Ficha = "FICHA DE "+ MyObj_Recoleccion.P_Tipo + " " + Fecha + ".pdf";
                        string Ruta_Ficha = ObtenerRutaArchivo(Nombre_Ficha);
                        iTextSharp.text.Document Ficha_Deposito = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER, 10, 10, 10, 10);
                        FileStream Ficha = new FileStream(Ruta_Ficha, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

                        iTextSharp.text.pdf.PdfWriter.GetInstance(Ficha_Deposito, Ficha);
                        Ficha_Deposito.Open();
                        //Exportar_Datos_PDF(Ficha_Deposito, MyObj_Recoleccion);
                        Exportar_FichaDeposito_PDF(Ficha_Deposito, MyObj_Recoleccion);
                       
                        Ficha_Deposito.Close();
                        //MessageBox.Show(this, "", Txt_Monto_Depositar.Text  , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.Start(Ruta_Ficha);
                    }

                    Process.Start(Ruta_Archivo);
                    
                    Documento_Copia.Open();
                    Exportar_Datos_PDF(Documento_Copia, MyObj_Recoleccion);
                    Documento_Copia.Close(); 
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_PDF_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorPDF = true;
                }
                return ErrorPDF;
            
        }

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
                return String.Empty ;
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
        /// Fecha Modifico: 14/Febrero /2015
        /// Causa Modificación: Se detalla un pdf con los datos del movimiento, el desglose de monedas, el sobrante y faltante y las firmas 
        /// </summary>
        /// <param name="Documento">Objeto al cúal agregaremos el contenido del reporte</param>
        /// <param name="MyRecoleccion">Objeto que contiene los datos de la recolección</param>
        private void Exportar_Datos_PDF(iTextSharp.text.Document Documento, Cls_Ope_Recolecciones_Negocio MyRecoleccion)
        {
            
            try
            {
                //string FolioMov = Obtener_Folio(MyRecoleccion);
                string FolioMov = MyRecoleccion.P_No_Recoleccion;
                decimal Monto_Recolectado_Billetes = 0.0M;//Variable que mantiene el total recolectado en billetes.
                decimal Monto_Recolectado_Monedas = 0.0M;//Variable que mantiene el total recolectado en monedas.
                decimal Sobrante = 0;
                decimal Faltante = 0;


                #region (Obtener Total Billetes)
                Array.ForEach(Pnl_Billetes.Controls.OfType<TextBox>().ToArray(), caja =>
                {
                    if (!string.IsNullOrEmpty(caja.Text) && !caja.Text.Trim().Equals("0"))
                        Monto_Recolectado_Billetes += (Convert.ToDecimal(string.IsNullOrEmpty(caja.Text) ? "0" : caja.Text) *
                                    Convert.ToDecimal(string.IsNullOrEmpty(caja.Tag.ToString()) ? "0" : caja.Tag.ToString()));
                });
                //Mostrar el total en billetes recolectado.
                //Txt_Total_Billetes.Text = string.Format("{0:c}", Monto_Recolectado_Billetes);
                #endregion

                #region (Obtener Total Monedas)
                Array.ForEach(Pnl_Monedas.Controls.OfType<TextBox>().ToArray(), caja =>
                {
                    if (!string.IsNullOrEmpty(caja.Text) && !caja.Text.Trim().Equals("0"))
                        Monto_Recolectado_Monedas += (Convert.ToDecimal(string.IsNullOrEmpty(caja.Text) ? "0" : caja.Text) *
                                    Convert.ToDecimal(string.IsNullOrEmpty(caja.Tag.ToString()) ? "0" : caja.Tag.ToString()));
                });
                //Mostrar el total en monedas recolectado.
                //Txt_Total_Monedas.Text = string.Format("{0:c}", Monto_Recolectado_Monedas);
                #endregion

           
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
                //document.Add(pic);
                //iTextSharp.text.Phrase Logo = new iTextSharp.text.Phrase("LOGOTIPO");
                //Logo.Width = 10;
                //Logo.Height = 10; 
                //Logo.Font.Size = 14;
                //Logo.Font.SetStyle(iTextSharp.text.Font.BOLD);

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


                //iTextSharp.text.Paragraph Titulo = new iTextSharp.text.Paragraph();
                //Titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                //Titulo.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                //Titulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                //Titulo.Font.Size = 14;
                //Titulo.Add("Gobierno Municipial de Guanajuato\nMuseo de las momias de Guanajuato\n\n");

                
                //Fecha Actual
                iTextSharp.text.Paragraph Fecha = new iTextSharp.text.Paragraph();
                Fecha.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Fecha.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Fecha.Font.SetStyle(iTextSharp.text.Font.NORMAL);
                Fecha.Font.Size = 11;
                Fecha.Add("Fecha:"+DateTime.Today.ToString("dd-MMM-yyyy")+"\n");

                // Creamos y establecemos el formato que tendrá el subtitulo del reporte.
                iTextSharp.text.Paragraph Subtitulo = new iTextSharp.text.Paragraph();
                Subtitulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Subtitulo.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Subtitulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Subtitulo.Font.Size = 11;
                Subtitulo.Add(MyRecoleccion.P_Tipo.ToString() + ": "+ DateTime.Today.ToString("dd-MMM-yyyy")+"\n"); //+ Dtp_Fecha_Recoleccion.Text + "\n");

                //Creamos Tabla con Datos Generales
                iTextSharp.text.Paragraph Generales = new iTextSharp.text.Paragraph();
                Generales.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Generales.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Generales.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Generales.Font.Size = 12;
                Generales.Add("DATOS GENERALES:\n");

                iTextSharp.text.Phrase Cajero = new iTextSharp.text.Phrase("Cajero:\n" + MDI_Frm_Apl_Principal.Nombre_Usuario);
                Cajero.Font.Size = 7;
                iTextSharp.text.Phrase Usuario = new iTextSharp.text.Phrase("Usuario Autoriza:\n" + this.Usuario_Autoriza_Nombre);
                Usuario.Font.Size = 7;
                iTextSharp.text.Phrase Folio = new iTextSharp.text.Phrase("Folio:\n" + FolioMov);
                Folio.Font.Size = 7;
                iTextSharp.text.Phrase Movimiento = new iTextSharp.text.Phrase("No Movimiento:\n" + Txt_Numero_Recoleccion.Text);
                Movimiento.Font.Size = 7;
                iTextSharp.text.Phrase Id_Caja = new iTextSharp.text.Phrase("Hora:\n" + DateTime.Now.ToString("t", CultureInfo.CreateSpecificCulture("en-us")));
                Id_Caja.Font.Size = 7;
                iTextSharp.text.Phrase No_Caja = new iTextSharp.text.Phrase("Descripción Caja:\n"+Cmb_Cajas.Text);
                No_Caja.Font.Size = 7;

                //Tabla Generales
                iTextSharp.text.pdf.PdfPTable Tabla_Generales = new iTextSharp.text.pdf.PdfPTable(6);
                Tabla_Generales.WidthPercentage = 100;
                Tabla_Generales.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.SECTION;

                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Cajero) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Usuario) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Folio) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Movimiento) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER }); 
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Id_Caja) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(No_Caja) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
             
                //Creamos Tabla con el Desglose de Dinero
                iTextSharp.text.Paragraph Desglose = new iTextSharp.text.Paragraph();
                Desglose.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Desglose.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Desglose.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Desglose.Font.Size = 12;
                Desglose.Add("DESGLOSE DE DINERO:\n");
            
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
                iTextSharp.text.Phrase Cantidad1000 = new iTextSharp.text.Phrase(MyRecoleccion.P_Billetes_1000.ToString());
                Cantidad1000.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes1000 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Billetes_1000) * 1000).ToString("C", CultureInfo.CurrentCulture));
                TotalBilletes1000.Font.Size = 11;

                iTextSharp.text.Phrase Billetes500 = new iTextSharp.text.Phrase("Billetes $500");
                Billetes500.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad500 = new iTextSharp.text.Phrase(MyRecoleccion.P_Billetes_500.ToString());
                Cantidad500.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes500 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Billetes_500) * 500).ToString("C", CultureInfo.CurrentCulture));
                TotalBilletes500.Font.Size = 11;


                iTextSharp.text.Phrase Billetes200 = new iTextSharp.text.Phrase("Billetes $200");
                Billetes200.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad200 = new iTextSharp.text.Phrase(MyRecoleccion.P_Billetes_200.ToString());
                Cantidad200.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes200 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Billetes_200) * 200).ToString("C", CultureInfo.CurrentCulture));
                TotalBilletes200.Font.Size = 11;

                iTextSharp.text.Phrase Billetes100 = new iTextSharp.text.Phrase("Billetes $100");
                Billetes100.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad100 = new iTextSharp.text.Phrase(MyRecoleccion.P_Billetes_100.ToString());
                Cantidad100.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes100 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Billetes_100) * 100).ToString("C", CultureInfo.CurrentCulture));
                TotalBilletes100.Font.Size = 11;

                iTextSharp.text.Phrase Billetes50 = new iTextSharp.text.Phrase("Billetes $50");
                Billetes50.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad50 = new iTextSharp.text.Phrase(MyRecoleccion.P_Billetes_50.ToString());
                Cantidad50.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes50 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Billetes_50) * 50).ToString("C", CultureInfo.CurrentCulture));
                TotalBilletes50.Font.Size = 11;

                iTextSharp.text.Phrase Billetes20 = new iTextSharp.text.Phrase("Billetes $20");
                Billetes20.Font.Size = 11;
                iTextSharp.text.Phrase Cantidad20 = new iTextSharp.text.Phrase(MyRecoleccion.P_Billetes_20.ToString());
                Cantidad20.Font.Size = 11;
                iTextSharp.text.Phrase TotalBilletes20 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Billetes_20) * 20).ToString("C", CultureInfo.CurrentCulture));
                TotalBilletes20.Font.Size = 11;

                iTextSharp.text.Phrase Monedas20 = new iTextSharp.text.Phrase("Monedas $20");
                Monedas20.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM20 = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_20.ToString());
                CantidadM20.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas20 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_20) * 20).ToString("C",CultureInfo.CurrentCulture));
                TotalMonedas20.Font.Size = 11;

                iTextSharp.text.Phrase Monedas10 = new iTextSharp.text.Phrase("Monedas $10");
                Monedas10.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM10 = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_10.ToString());
                CantidadM10.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas10 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_10) * 10).ToString("C", CultureInfo.CurrentCulture));
                TotalMonedas10.Font.Size = 11;

                iTextSharp.text.Phrase Monedas5 = new iTextSharp.text.Phrase("Monedas $5");
                Monedas5.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM5 = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_5.ToString());
                CantidadM5.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas5 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_5) * 5).ToString("C", CultureInfo.CurrentCulture));
                TotalMonedas5.Font.Size = 11;

                iTextSharp.text.Phrase Monedas2 = new iTextSharp.text.Phrase("Monedas $2");
                Monedas2.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM2 = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_2.ToString());
                CantidadM2.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas2 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_2) * 2).ToString("C", CultureInfo.CurrentCulture));
                TotalMonedas2.Font.Size = 11;

                iTextSharp.text.Phrase Monedas1 = new iTextSharp.text.Phrase("Monedas $1");
                Monedas1.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM1 = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_1.ToString());
                CantidadM1.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas1 = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_1) * 1).ToString("C", CultureInfo.CurrentCulture));
                TotalMonedas1.Font.Size = 11;

                iTextSharp.text.Phrase Monedas50c = new iTextSharp.text.Phrase("Monedas 50c");
                Monedas50c.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM50c = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_050.ToString());
                CantidadM50c.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas50c = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_050) * 0.50).ToString("C", CultureInfo.CurrentCulture));
                TotalMonedas50c.Font.Size = 11;

                iTextSharp.text.Phrase Monedas20c = new iTextSharp.text.Phrase("Monedas 20c");
                Monedas20c.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM20c = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_020.ToString());
                CantidadM20c.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas20c = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_020) * 0.20).ToString("C", CultureInfo.CurrentCulture));
                TotalMonedas20c.Font.Size = 11;

                iTextSharp.text.Phrase Monedas10c = new iTextSharp.text.Phrase("Monedas 10c");
                Monedas10c.Font.Size = 11;
                iTextSharp.text.Phrase CantidadM10c = new iTextSharp.text.Phrase(MyRecoleccion.P_Monedas_010.ToString());
                CantidadM10c.Font.Size = 11;
                iTextSharp.text.Phrase TotalMonedas10c = new iTextSharp.text.Phrase(Convert.ToDecimal((MyRecoleccion.P_Monedas_010) * 0.10).ToString("C", CultureInfo.CurrentCulture));
                TotalMonedas10c.Font.Size = 11;

                iTextSharp.text.Phrase SubTotal_Billetes_Name = new iTextSharp.text.Phrase("TOTAL BILLETES");
                SubTotal_Billetes_Name.Font.Size = 7;
                SubTotal_Billetes_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);
                iTextSharp.text.Phrase SubTotal_Billetes = new iTextSharp.text.Phrase(Convert.ToDecimal(Monto_Recolectado_Billetes).ToString("C", CultureInfo.CurrentCulture));
                SubTotal_Billetes.Font.Size = 11;
                SubTotal_Billetes.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase SubTotal_Monedas_Name = new iTextSharp.text.Phrase("TOTAL MONEDAS");
                SubTotal_Monedas_Name.Font.Size = 7;
                SubTotal_Monedas_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);
                iTextSharp.text.Phrase SubTotal_Monedas = new iTextSharp.text.Phrase(Convert.ToDecimal(Monto_Recolectado_Monedas).ToString("C", CultureInfo.CurrentCulture));
                SubTotal_Monedas.Font.Size = 11;
                SubTotal_Monedas.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase Total_Desglose_Name = new iTextSharp.text.Phrase("TOTAL DESGLOSE");
                Total_Desglose_Name.Font.Size = 9;
                Total_Desglose_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                iTextSharp.text.Phrase Total_Desglose = new iTextSharp.text.Phrase(Convert.ToDecimal(Txt_Monto_Recolectado.Text).ToString("C", CultureInfo.CurrentCulture));
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

                //Creamos Tabla Resultados
                iTextSharp.text.Paragraph Resultados = new iTextSharp.text.Paragraph();
                Resultados.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Resultados.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Resultados.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Resultados.Font.Size = 12;
                Resultados.Add("RESULTADOS DE " + MyRecoleccion.P_Tipo +":\n");
                bool Bool_Faltante = false;

                #region Datos Resultado Recolección
                //Encabezado
                iTextSharp.text.Phrase Total_Cantidad_Recolectado_Retirado_Name = new iTextSharp.text.Phrase("Cantidad " + MyRecoleccion.P_Tipo);
                Total_Cantidad_Recolectado_Retirado_Name.Font.Size = 11;
                Total_Cantidad_Recolectado_Retirado_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);
                //Resultados
                decimal Total_Caja_Decimal_Recoleccion = Convert.ToDecimal(Txt_Monto_Recolectado.Text);
                iTextSharp.text.Phrase Total_Caja_Desglose_Recoleccion = new iTextSharp.text.Phrase(Total_Caja_Decimal_Recoleccion.ToString("C", CultureInfo.CurrentCulture));
                Total_Caja_Desglose_Recoleccion.Font.Size = 11;
                #endregion

                #region Tabla Resultado Recolección
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


                #region Datos Generales Resultado Arqueo y Cierre

                #endregion 

              

                iTextSharp.text.pdf.PdfPTable Tabla_Resultado_Detallado_Arquero_Cierre = new iTextSharp.text.pdf.PdfPTable(2);
                iTextSharp.text.pdf.PdfPTable Tabla_Resultado_Detallado_Arquero_Cierre_P2 = new iTextSharp.text.pdf.PdfPTable(2);
                iTextSharp.text.pdf.PdfPTable Tabla_Resultado_Detallado_Arquero_Cierre_P3 = new iTextSharp.text.pdf.PdfPTable(2);

                if (MyRecoleccion.P_Tipo == "ARQUEO" || MyRecoleccion.P_Tipo == "CIERRE")
                {
                    #region Datos Resultado Detallado Arqueo Cierre

                    //Total efectivo en caja
                    decimal Total_en_caja = Convert.ToDecimal(Txt_Monto_Recolectado.Text);
                    //iTextSharp.text.Phrase Total_Caja_Cierre_Arqueo = new iTextSharp.text.Phrase(Total_en_caja.ToString("C", CultureInfo.CurrentCulture));
                    //Total_Caja_Cierre_Arqueo.Font.Size = 9;


                    //Monto Inicial en Caja
                    decimal Monto_Inicial = Convert.ToDecimal(Txt_Monto_Inicial.Text);
                    iTextSharp.text.Phrase Total_Monto_Inicial = new iTextSharp.text.Phrase(Monto_Inicial.ToString("C", CultureInfo.CurrentCulture));
                    Total_Monto_Inicial.Font.Size = 9;

                    //Total efectivo en caja Visible  + Monto Inicial 
                    decimal Tontal_en_caja_con_fondo_fijo = Total_en_caja + Monto_Inicial;
                    iTextSharp.text.Phrase Total_Caja_Con_Fondo_Fijo = new iTextSharp.text.Phrase(Total_en_caja.ToString("C", CultureInfo.CurrentCulture));
                    Total_Caja_Con_Fondo_Fijo.Font.Size = 9;

                    //SUBTOTAL_1(EFECTIVO CAJA(CON FONDO FIJO) - MONTO INICIAL)
                    decimal SubTotal_1 = Total_en_caja - Monto_Inicial; //Tontal_en_caja_con_fondo_fijo - Monto_Inicial; 
                    iTextSharp.text.Phrase SUBTOTAL_1 = new iTextSharp.text.Phrase(SubTotal_1.ToString("C", CultureInfo.CurrentCulture));
                    SUBTOTAL_1.Font.Size = 9;

                    //Total ventas credito/debito
                    decimal T_Ventas_Credito_Debito = Convert.ToDecimal(Txt_Venta_Tarjetas.Text);
                    iTextSharp.text.Phrase Total_Ventas_Credito_Debito = new iTextSharp.text.Phrase(T_Ventas_Credito_Debito.ToString("C", CultureInfo.CurrentCulture));
                    Total_Ventas_Credito_Debito.Font.Size = 9;
                    
                    //Total recolecciones y retiros
                    decimal T_Recolecciones = Convert.ToDecimal(Txt_Cortes_Caja.Text) + Convert.ToDecimal(Txt_Retiros_Caja.Text);
                    iTextSharp.text.Phrase Total_Recolecciones = new iTextSharp.text.Phrase(T_Recolecciones.ToString("C", CultureInfo.CurrentCulture));
                    Total_Recolecciones.Font.Size = 9;

                    //SUBTOTAL_2(SUBTOTAL_1 + VENTAS CREDITO Y DEBITO + RECOLECCIONES)
                    decimal SubTotal_2 = SubTotal_1+ T_Ventas_Credito_Debito+ T_Recolecciones;
                    iTextSharp.text.Phrase SUBTOTAL_2 = new iTextSharp.text.Phrase(SubTotal_2.ToString("C", CultureInfo.CurrentCulture));
                    SUBTOTAL_2.Font.Size = 9;
                    SUBTOTAL_2.Font.SetStyle(iTextSharp.text.Font.BOLD);
                    
                    
                    //Total cancelaciones 
                    decimal T_Cancelaciones = Convert.ToDecimal(Txt_Total_Cancelaciones.Text);
                    iTextSharp.text.Phrase Total_Cancelaciones = new iTextSharp.text.Phrase(T_Cancelaciones.ToString("C", CultureInfo.CurrentCulture));
                    Total_Cancelaciones.Font.Size = 9;

                    //Total Sistema Visible (Total_en_caja(ventas efectivo), Recolecciones, ventas credito/debito, Cancelaciones y sin monto inicial)
                    decimal Total_Sistema = Convert.ToDecimal(Txt_Total_En_Caja.Text) + T_Ventas_Credito_Debito + T_Recolecciones + T_Cancelaciones - Monto_Inicial;
                    iTextSharp.text.Phrase Total_Efectivo_Sistema = new iTextSharp.text.Phrase(Total_Sistema.ToString("C", CultureInfo.CurrentCulture));
                    Total_Efectivo_Sistema.Font.Size = 9;
 
                    //SUBTOTAL_3(TOTAL SISTEMA - CANCELACIONES)
                    decimal SubTotal_3 = Total_Sistema - T_Cancelaciones;
                    iTextSharp.text.Phrase SUBTOTAL_3 = new iTextSharp.text.Phrase(SubTotal_3.ToString("C", CultureInfo.CurrentCulture));
                    SUBTOTAL_3.Font.Size = 9;
                    SUBTOTAL_3.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    //Sobrante o Faltante

                    //Total ventas en efectivo
                    //decimal T_Ventas_Efectivo = Convert.ToDecimal(Txt_Ventas_Efectivo.Text);
                    //iTextSharp.text.Phrase Total_Ventas_Efectivo = new iTextSharp.text.Phrase(T_Ventas_Efectivo.ToString("C", CultureInfo.CurrentCulture));
                    //Total_Ventas_Efectivo.Font.Size = 9;

                    //Total en efectivo (sistema)
                    decimal Total_Caja_Comparar_Cierre = SubTotal_2; //Total_en_caja + T_Recolecciones;
                    decimal Total_Efectivo_Decimal = SubTotal_3;//Convert.ToDecimal(Txt_Total_En_Caja.Text) + T_Recolecciones;

                    if (Total_Efectivo_Decimal <= 0)
                    {
                        Total_Efectivo_Decimal = 0;
                    }

                    //iTextSharp.text.Phrase Total_Efectivo_Sistema = new iTextSharp.text.Phrase(Total_Efectivo_Decimal.ToString("C", CultureInfo.CurrentCulture));
                    
                    iTextSharp.text.Phrase Total_Sobrante_Faltante = new iTextSharp.text.Phrase("");

                    if (Total_Caja_Comparar_Cierre >= Total_Efectivo_Decimal)
                    {
                        Sobrante = Total_Caja_Comparar_Cierre - Total_Efectivo_Decimal;
                        Total_Sobrante_Faltante = new iTextSharp.text.Phrase(Sobrante.ToString("C", CultureInfo.CurrentCulture));
                        Total_Sobrante_Faltante.Font.Size = 9;
                    }

                    //Faltante
                    else
                    {
                        Bool_Faltante = true;
                        Faltante = Total_Efectivo_Decimal - Total_Caja_Comparar_Cierre;
                        Total_Sobrante_Faltante = new iTextSharp.text.Phrase(Faltante.ToString("C", CultureInfo.CurrentCulture));
                        Total_Sobrante_Faltante.Font.Size = 9;
                    }

                    //Monto a Depositar
                    decimal T_Monto_Depositar = 0;
                    decimal Monto_Recolectado_Cajero = Convert.ToDecimal(Txt_Monto_Recolectado.Text);
                    //Si hay faltante
                    if (Bool_Faltante)
                    {
                        T_Monto_Depositar = Monto_Recolectado_Cajero - Monto_Inicial  + Faltante;
                    }
                    else 
                        T_Monto_Depositar = Monto_Recolectado_Cajero - Monto_Inicial;


                    Monto_A_Depositar_Cierre = T_Monto_Depositar.ToString("n");
                    Txt_Monto_Depositar.Text = T_Monto_Depositar.ToString("n");
                    iTextSharp.text.Phrase Total_Monto_Depositar = new iTextSharp.text.Phrase(T_Monto_Depositar.ToString("C", CultureInfo.CurrentCulture));
                    Total_Monto_Depositar.Font.Size = 9;

                    #region Encabezados
                    iTextSharp.text.Phrase Monto_Inicial_Name = new iTextSharp.text.Phrase("Monto Inicial en Caja");
                    Monto_Inicial_Name.Font.Size = 9;
                    Monto_Inicial_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase Total_Ventas_Efectivo_Name = new iTextSharp.text.Phrase("Total ventas en efectivo");
                    Total_Ventas_Efectivo_Name.Font.Size = 9;
                    Total_Ventas_Efectivo_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase Total_Ventas_Credito_Debito_Name = new iTextSharp.text.Phrase("Total ventas en credito/debito");
                    Total_Ventas_Credito_Debito_Name.Font.Size = 9;
                    Total_Ventas_Credito_Debito_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase Total_Cancelaciones_Name = new iTextSharp.text.Phrase("Total en cancelaciones");
                    Total_Cancelaciones_Name.Font.Size = 9;
                    Total_Cancelaciones_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase Total_Recolecciones_Name = new iTextSharp.text.Phrase("Total en recolecciones y retiros");
                    Total_Recolecciones_Name.Font.Size = 9;
                    Total_Recolecciones_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);


                    iTextSharp.text.Phrase Total_Monto_Depositar_Name = new iTextSharp.text.Phrase("Monto a Depositar");
                    Total_Monto_Depositar_Name.Font.Size = 9;
                    Total_Monto_Depositar_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase SubTotal_1_TotalEfectivoCobrado_Name = new iTextSharp.text.Phrase("Total efectivo cobrado");
                    SubTotal_1_TotalEfectivoCobrado_Name.Font.Size = 9;
                    SubTotal_1_TotalEfectivoCobrado_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase SubTotal_2_TotalCobrado_Name = new iTextSharp.text.Phrase("Total cobrado");
                    SubTotal_2_TotalCobrado_Name.Font.Size = 9;
                    SubTotal_2_TotalCobrado_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase SubTotal_3_TotalCobradoSistema_Name = new iTextSharp.text.Phrase("Total cobrado en sistema");
                    SubTotal_3_TotalCobradoSistema_Name.Font.Size = 9;
                    SubTotal_3_TotalCobradoSistema_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase Total_Caja_Desglose_Name = new iTextSharp.text.Phrase("Efectivo en caja");
                    Total_Caja_Desglose_Name.Font.Size = 9;
                    Total_Caja_Desglose_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase Total_Efectivo_Sistema_Name = new iTextSharp.text.Phrase("Total sistema");
                    Total_Efectivo_Sistema_Name.Font.Size = 9;
                    Total_Efectivo_Sistema_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                    iTextSharp.text.Phrase Total_Sobrante_Faltante_Name = new iTextSharp.text.Phrase("");
                    if (Bool_Faltante)
                    {
                        Total_Sobrante_Faltante_Name = new iTextSharp.text.Phrase("FALTANTE:");
                    }
                    else
                    {
                        Total_Sobrante_Faltante_Name = new iTextSharp.text.Phrase("SOBRANTE");
                    }
                    Total_Sobrante_Faltante_Name.Font.Size = 9;
                    Total_Sobrante_Faltante_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);
                    #endregion

                    #endregion

                    #region Tabla Resultado Detallado de Arqueo Cierre Parrafo 1
                    Tabla_Resultado_Detallado_Arquero_Cierre = new iTextSharp.text.pdf.PdfPTable(2);
                    Tabla_Resultado_Detallado_Arquero_Cierre.WidthPercentage = 50;
                    Tabla_Resultado_Detallado_Arquero_Cierre.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                    Tabla_Resultado_Detallado_Arquero_Cierre.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                    //Efectivo Caja
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Caja_Desglose_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Caja_Con_Fondo_Fijo) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    
                    //Monto inicial
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Monto_Inicial_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Monto_Inicial) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    
                    //SUBTOTAL EFECTIVO COBRADO
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(SubTotal_1_TotalEfectivoCobrado_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(SUBTOTAL_1) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });

                    //Total ventas credito/debito
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Ventas_Credito_Debito_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Ventas_Credito_Debito) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    
                    //Total recolecciones
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Recolecciones_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Recolecciones) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    
                    //SUBTOTAL COBRADO
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(SubTotal_2_TotalCobrado_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(SUBTOTAL_2) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    #endregion

                    #region Tabla Resultado Detallado de Arqueo Cierre Parrafo 2
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2 = new iTextSharp.text.pdf.PdfPTable(2);
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.WidthPercentage = 50;
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                  

                    //Total ventas efectivo
                    //Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Ventas_Efectivo_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED });
                    //Tabla_Resultado_Detallado_Arquero_Cierre.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Ventas_Efectivo) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });

                    //Total sistema sin monto inicial
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Efectivo_Sistema_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Efectivo_Sistema) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });

                    //Total Cancelaciones
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Cancelaciones_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Cancelaciones) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    
                    //SUBTOTAL COBRADO EN SISTEMA
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell(SubTotal_3_TotalCobradoSistema_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell(SUBTOTAL_3) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });

                    //ESPACIO
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell() { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    Tabla_Resultado_Detallado_Arquero_Cierre_P2.AddCell(new iTextSharp.text.pdf.PdfPCell() { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    #endregion

                    #region Tabla Resultado Detallado de Arqueo Cierre Parrafo 3
                    Tabla_Resultado_Detallado_Arquero_Cierre_P3 = new iTextSharp.text.pdf.PdfPTable(2);
                    Tabla_Resultado_Detallado_Arquero_Cierre_P3.WidthPercentage = 50;
                    Tabla_Resultado_Detallado_Arquero_Cierre_P3.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                    Tabla_Resultado_Detallado_Arquero_Cierre_P3.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                    //FALTANTE O SOBRANTE
                    Tabla_Resultado_Detallado_Arquero_Cierre_P3.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Sobrante_Faltante_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });
                    Tabla_Resultado_Detallado_Arquero_Cierre_P3.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Sobrante_Faltante) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER, BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY });

                    //MONTO A DEPOSITAR
                    if ( MyRecoleccion.P_Tipo == "CIERRE")
                    {
                        Tabla_Resultado_Detallado_Arquero_Cierre_P3.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Monto_Depositar_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_JUSTIFIED, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                        Tabla_Resultado_Detallado_Arquero_Cierre_P3.AddCell(new iTextSharp.text.pdf.PdfPCell(Total_Monto_Depositar) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                    }
                    #endregion

                }

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
                Documento.Add(Desglose);
                Documento.Add(Tabla_Desglose);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Resultados);
                if (MyRecoleccion.P_Tipo == "RECOLECCION")
                    Documento.Add(Tabla_Resultado_Recoleccion);
                Documento.Add(Tabla_Resultado_Detallado_Arquero_Cierre);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Tabla_Resultado_Detallado_Arquero_Cierre_P2);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Tabla_Resultado_Detallado_Arquero_Cierre_P3);
                Documento.Add(Tabla_Firmas);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Exportar_Datos_PDF]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        #endregion

        #region (Ficha_Deposito)
        /// <summary>
        /// Nombre: Exportar_FichaDeposito_PDF
        /// 
        /// Descripción: Método que exporta la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:50 Hrs.
        /// Usuario Modifico: Cruz Amaya Olimpo Alberto 
        /// Fecha Modifico: 27/Marzo /2015
        /// Causa Modificación: Se detalla un pdf con la cantidad a depositar y el desglose en blanco 
        /// </summary>
        /// <param name="Documento">Objeto al cúal agregaremos el contenido del reporte</param>
        /// <param name="MyRecoleccion">Objeto que contiene los datos de la recolección</param>
        private void Exportar_FichaDeposito_PDF(iTextSharp.text.Document Documento, Cls_Ope_Recolecciones_Negocio MyRecoleccion)
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
                Subtitulo.Add("FICHA DE DEPOSITO" + ": " + DateTime.Today.ToString("dd-MMM-yyyy") + "\n");

                //Creamos Tabla con Datos Generales
                iTextSharp.text.Paragraph Generales = new iTextSharp.text.Paragraph();
                Generales.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Generales.Font = iTextSharp.text.FontFactory.GetFont("Arial");
                Generales.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Generales.Font.Size = 12;
                Generales.Add("DATOS GENERALES:\n\n");


                iTextSharp.text.Phrase Usuario = new iTextSharp.text.Phrase("Usuario Autoriza:\n" + this.Usuario_Autoriza_Nombre);
                Usuario.Font.Size = 7;
                iTextSharp.text.Phrase Cajero = new iTextSharp.text.Phrase("Cajero:\n" + MDI_Frm_Apl_Principal.Nombre_Usuario);
                Cajero.Font.Size = 7;
                iTextSharp.text.Phrase Movimiento = new iTextSharp.text.Phrase("No Movimiento:\n" + Txt_Numero_Recoleccion.Text);
                Movimiento.Font.Size = 7;
                iTextSharp.text.Phrase Turno = new iTextSharp.text.Phrase("Hora:\n" + DateTime.Now.ToString("t",CultureInfo.CreateSpecificCulture("en-us")));
                Turno.Font.Size = 7;
                iTextSharp.text.Phrase No_Caja = new iTextSharp.text.Phrase("Descripción Caja:\n" + Cmb_Cajas.Text);
                No_Caja.Font.Size = 7;

                //Tabla Generales
                iTextSharp.text.pdf.PdfPTable Tabla_Generales = new iTextSharp.text.pdf.PdfPTable(5);
                Tabla_Generales.WidthPercentage = 100;
                Tabla_Generales.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;

                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Usuario) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Cajero) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Movimiento) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                Tabla_Generales.AddCell(new iTextSharp.text.pdf.PdfPCell(Turno) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
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

                iTextSharp.text.Phrase Total_Desglose_Name = new iTextSharp.text.Phrase("TOTAL A DEPOSITAR");
                Total_Desglose_Name.Font.Size = 9;
                Total_Desglose_Name.Font.SetStyle(iTextSharp.text.Font.BOLD);

                //iTextSharp.text.Phrase Total_Desglose = new iTextSharp.text.Phrase("");
                String Monto_A_Recolectar = "";

                if (true == Opt_Cierre_Caja.Checked)
                {
                    //  si es cierre de caja
                    Monto_A_Recolectar = Monto_A_Depositar_Cierre;
                }
                else
                {
                    //  si es recolecion
                    Monto_A_Recolectar = Txt_Monto_Recolectado.Text;
                }


                iTextSharp.text.Phrase Total_Desglose = new iTextSharp.text.Phrase(Monto_A_Recolectar);
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

                //Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                //Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                //Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas20) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                //Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(Monedas10) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT });
                //Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(CantidadM10) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER });
                //Tabla_Desglose.AddCell(new iTextSharp.text.pdf.PdfPCell(TotalMonedas10) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

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

                #region Sobrante o Faltante
                //Tabla Sobrante_Faltante
                iTextSharp.text.pdf.PdfPTable Tabla_Faltante_Sobrante = new iTextSharp.text.pdf.PdfPTable(1);
                Tabla_Faltante_Sobrante.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Faltante_Sobrante.WidthPercentage = 100;

                //Sobrante
                if (TXt_Resultado_Corte.BackColor == Color.Chartreuse)
                {
                    
                    iTextSharp.text.Phrase Sobrante_Name = new iTextSharp.text.Phrase("Sobrante: " + TXt_Resultado_Corte.Text + " (  )");
                    Sobrante_Name.Font.Size = 10;
                    Tabla_Faltante_Sobrante.AddCell(new iTextSharp.text.pdf.PdfPCell(Sobrante_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
               
                }

                //Faltante
                else
                {
                    iTextSharp.text.Phrase Faltante_Name = new iTextSharp.text.Phrase("Faltante: " + TXt_Resultado_Corte.Text + " (  )");
                    Faltante_Name.Font.Size = 10;
                    Tabla_Faltante_Sobrante.AddCell(new iTextSharp.text.pdf.PdfPCell(Faltante_Name) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
                }
                #endregion 

                #region Numero de Cuenta

                //No Cuenta
                iTextSharp.text.Phrase No_Cuenta = new iTextSharp.text.Phrase("FICHA DE APOYO PARA DEPOSITO A LA CUENTA:\n" + Cmb_Bancos.Text );
                No_Cuenta.Font.Size = 10;

                //Tabla No_Cuenta
                iTextSharp.text.pdf.PdfPTable Tabla_No_Cuenta= new iTextSharp.text.pdf.PdfPTable(1);
                Tabla_No_Cuenta.WidthPercentage = 100;
                Tabla_No_Cuenta.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_No_Cuenta.AddCell(new iTextSharp.text.pdf.PdfPCell(No_Cuenta) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER, Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER });
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

                //Tabla Datos Ficha
                iTextSharp.text.pdf.PdfPTable Tabla_Datos_Ficha = new iTextSharp.text.pdf.PdfPTable(1);
                Tabla_Datos_Ficha.WidthPercentage = 100;
                Tabla_Datos_Ficha.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Datos_Ficha.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                Tabla_Datos_Ficha.AddCell(Tabla_Generales);
                //Tabla_Datos_Ficha.AddCell(Tabla_Faltante_Sobrante);
                Tabla_Datos_Ficha.AddCell(Tabla_No_Cuenta);
                Tabla_Datos_Ficha.AddCell(Tabla_Firmas);

                //Tabla Grupal
                iTextSharp.text.pdf.PdfPTable Tabla_Grupal = new iTextSharp.text.pdf.PdfPTable(2);
                Tabla_Grupal.WidthPercentage = 100;
                Tabla_Grupal.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.RECTANGLE;
                Tabla_Grupal.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
                Tabla_Grupal.AddCell(Tabla_Desglose);
                Tabla_Grupal.AddCell(Tabla_Datos_Ficha);
                

                //Se agrega el Todo al documento al documento.
                Documento.Add(Tabla_Logotipo);
                Documento.Add(Tabla_Titulo);
                Documento.Add(Subtitulo);
                Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Tabla_Grupal);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Exportar_Datos_PDF]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion 


        /// <summary>
        /// Nombre: Actualizar_Recoleccion
        /// 
        /// Descripción: Método que realiza la actualización de los datos de la recolección.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 09:18 a.m.
        /// Usuario Modifico::
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private bool Actualizar_Recoleccion(String Informacion_Ticket)
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recoleccion = new Cls_Ope_Recolecciones_Negocio();//Variable para realizar las peticiones a la clase de negocios.
            bool Estatus = false;//Variable para devolver el estatus de la operación.

            try
            {
                Obj_Recoleccion.P_Texto_Ticket = Informacion_Ticket;

                #region (Set Datos Generales Recolección)
                Obj_Recoleccion.P_No_Recoleccion = Txt_No_Recoleccion.Text;
                Obj_Recoleccion.P_No_Caja = Cmb_Cajas.SelectedValue.ToString();
                Obj_Recoleccion.P_Fecha_Hora = Dtp_Fecha_Recoleccion.Value;
                Obj_Recoleccion.P_Monto_Recolectado = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Monto_Recolectado.Text) ? "0.0" : Txt_Monto_Recolectado.Text.Trim());
                //Obj_Recoleccion.P_Numero_Recoleccion = Convert.ToInt32(string.IsNullOrEmpty(Txt_Numero_Recoleccion.Text) ? "0" : Txt_Numero_Recoleccion.Text.Trim());
                Obj_Recoleccion.P_Usuario_ID_Recolecta = this.Usuario_Autoriza;

                Obj_Recoleccion.P_Total_Cancelaciones = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Total_Cancelaciones.Text) ? "0.0" : Txt_Total_Cancelaciones.Text.Trim());
                Obj_Recoleccion.P_Total_Tarjeta = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Total_Tarjeta.Text) ? "0.0" : Txt_Total_Tarjeta.Text.Trim());
                Obj_Recoleccion.P_Resultado_Corte = Convert.ToDecimal(string.IsNullOrEmpty(TXt_Resultado_Corte.Text) ? "0.0" : TXt_Resultado_Corte.Text.Trim());
                Obj_Recoleccion.P_Total_Retiros = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Retiros_Caja.Text) ? "0.0" : Txt_Retiros_Caja.Text.Trim());
                Obj_Recoleccion.P_Total_Cortes = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Cortes_Caja.Text) ? "0.0" : Txt_Cortes_Caja.Text.Trim());
                Obj_Recoleccion.P_Monto_Depositar = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Monto_Depositar.Text) ? "0.0" : Txt_Monto_Depositar.Text.Trim());
                #endregion

                #region (Set Detalles Recolección)
                Obj_Recoleccion.P_Billetes_1000 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_1000.Text) ? "0" : Txt_No_Billetes_1000.Text.Trim());
                Obj_Recoleccion.P_Billetes_500 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_500.Text) ? "0" : Txt_No_Billetes_500.Text.Trim());
                Obj_Recoleccion.P_Billetes_200 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_200.Text) ? "0" : Txt_No_Billetes_200.Text.Trim());
                Obj_Recoleccion.P_Billetes_100 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_100.Text) ? "0" : Txt_No_Billetes_100.Text.Trim());
                Obj_Recoleccion.P_Billetes_50 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_50.Text) ? "0" : Txt_No_Billetes_50.Text.Trim());
                Obj_Recoleccion.P_Billetes_20 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Billetes_20.Text) ? "0" : Txt_No_Billetes_20.Text.Trim());
                Obj_Recoleccion.P_Monedas_20 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_20.Text) ? "0" : Txt_No_Monedas_20.Text.Trim());
                Obj_Recoleccion.P_Monedas_10 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_10.Text) ? "0" : Txt_No_Monedas_10.Text.Trim());
                Obj_Recoleccion.P_Monedas_5 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_5.Text) ? "0" : Txt_No_Monedas_5.Text.Trim());
                Obj_Recoleccion.P_Monedas_2 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_2.Text) ? "0" : Txt_No_Monedas_2.Text.Trim());
                Obj_Recoleccion.P_Monedas_1 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_1.Text) ? "0" : Txt_No_Monedas_1.Text.Trim());
                Obj_Recoleccion.P_Monedas_050 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_050.Text) ? "0" : Txt_No_Monedas_050.Text.Trim());
                Obj_Recoleccion.P_Monedas_020 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_020.Text) ? "0" : Txt_No_Monedas_020.Text.Trim());
                Obj_Recoleccion.P_Monedas_010 = Convert.ToInt32(string.IsNullOrEmpty(Txt_No_Monedas_010.Text) ? "0" : Txt_No_Monedas_010.Text.Trim());
                #endregion

                //Se realiza la modificación de la recolección.
                Estatus = Obj_Recoleccion.Modificar_Recoleccion();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Actualizar_Recoleccion]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        /// <summary>
        /// Nombre: Eliminar_Recolección
        /// 
        /// Descripción: Método que realiza la baja del registro de recolección.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 09:16 a.m.
        /// Usuario Modifico::
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Estatus de la operación</returns>
        private bool Eliminar_Recolección()
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recoleccion = new Cls_Ope_Recolecciones_Negocio();//Variable para realizar las peticiones a la clase de negocios.
            bool Estatus = false;//Variable para devolver el estatus de la operación.

            try
            {
                Obj_Recoleccion.P_No_Recoleccion = Txt_No_Recoleccion.Text;
                Obj_Recoleccion.P_Motivo_Cancelacion = Microsoft.VisualBasic.Interaction.InputBox("Ingresar el motivo de la cancalecaion?", "Cancelar Recolecciones", string.Empty);
                //Se realiza la baja de la recolección
                if (!string.IsNullOrEmpty(Obj_Recoleccion.P_Motivo_Cancelacion))
                    Estatus = Obj_Recoleccion.Eliminar_Recoleccion();
                else Estatus = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Cancelar_Recolección]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool Validar_Datos()
        {
            bool Datos_Validados = true;//Variable que mantiene el estatus de la validación.
            StringBuilder Datos_Faltantes = new StringBuilder();//Variable para almacenar los datos que faltan de ingresar por el usuario.
            decimal Monto_Recolectado;
            decimal Monto_Efectivo;
            decimal Porcentaje_Faltante = 0;
            decimal Monto_Porcentaje_Faltante = 0;
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta = new DataTable();
            String Parametro_Id = "";
   

            try
            {

                Parametro_Id = "00001";
                Consulta_Parametros.P_Parametro_Id = Parametro_Id;
                Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                    decimal.TryParse(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Porcentaje_Faltante_Excedente].ToString(), out Porcentaje_Faltante);

                decimal.TryParse(Txt_Total_En_Caja.Text, out Monto_Efectivo);

                //  si tiene algun porcentaje se calcula el monto permitido
                if (Porcentaje_Faltante != 0)
                {
                    Monto_Porcentaje_Faltante = Monto_Efectivo * (Porcentaje_Faltante / 100);
                    Monto_Porcentaje_Faltante = Monto_Efectivo - Monto_Porcentaje_Faltante;
                }
                else
                    Monto_Porcentaje_Faltante = Monto_Efectivo;

                
                Datos_Faltantes.Append("Es necesario:\n");

                if (string.IsNullOrEmpty(Txt_Numero_Recoleccion.Text))
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" El número de recolección es un dato requerido. \n");
                }

                if (Cmb_Cajas.SelectedIndex <= 0)
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" La caja de la cuál se hará la recolección es un dato requerido. \n");
                }

                if (string.IsNullOrEmpty(Dtp_Fecha_Recoleccion.Text))
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" La fecha de la recolección es un dato requerido. \n");
                }

                if (string.IsNullOrEmpty(Dtp_Hora_Recoleccion.Text))
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" La hora de la recolección es un dato requerido. \n");
                }

                if (Opt_Recoleccion.Checked == false && Opt_Cierre_Caja.Checked == false && Opt_Arqueo.Checked == false)
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" Indique si es una recolección, arqueo o cierre de caja. \n");
                }

                if (decimal.TryParse(Txt_Monto_Recolectado.Text, out Monto_Recolectado) == false)
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" El monto recolectado es un dato requerido. \n");
                }
                else if (Monto_Recolectado <= 0)
                {
                    Datos_Validados = false;
                    Datos_Faltantes.Append(" El monto a recolectar no puede ser $0.00. \n");
                }
                // si es nuevo o modificación
                if (!Btn_Nuevo.Text.Equals("Nuevo") || !Btn_Modificar.Text.Equals("Modificar"))
                {
                    // validar que si es cierre de caja no haya remanente o exceso
                    if (Opt_Cierre_Caja.Checked == true)
                    {
                        
                    }
                    else if (Opt_Arqueo.Checked == true)
                    {
                        decimal.TryParse(Txt_Total_En_Caja.Text, out Monto_Efectivo);
                        if (Monto_Efectivo < Monto_Recolectado)
                        {
                            //Datos_Validados = false;
                            Datos_Faltantes.Append(" Monto excedente " + (Monto_Recolectado - Monto_Efectivo).ToString("c") + " \n");
                            
                            TXt_Resultado_Corte.Visible = false;
                            Txt_Total_En_Caja.Visible = false;
                        }
                        else if (Monto_Efectivo > Monto_Recolectado)
                        {
                            //Datos_Validados = false;
                            Datos_Faltantes.Append(" Monto faltante " + (Monto_Efectivo - Monto_Recolectado).ToString("c") + " \n");

                            TXt_Resultado_Corte.Visible = false;
                            Txt_Total_En_Caja.Visible = false;
                        }
                        
                    }
                }

                Pnl_Contenedor.Tag = Datos_Faltantes.ToString();
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

                if (!String.IsNullOrEmpty(this.Usuario_Autoriza))
                {
                    ObjMyRecoleccion.P_Usuario_Autorizo = this.Usuario_Autoriza;
                    Dt_Consulta_Usuario = ObjMyRecoleccion.Consultar_Usuario_Autorizo();
                    //Nombre del usuario que pre-autoriza
                    this.Usuario_Autoriza_Nombre = Dt_Consulta_Usuario.Rows[0][Apl_Usuarios.Campo_Nombre_Usuario].ToString();
                }
                else
                {

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Autorizar_Movimiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !string.IsNullOrEmpty(this.Usuario_Autoriza);
        }

        /// <summary>
        /// Nombre: Obtener_Folio
        /// 
        /// Descripción: Método que obtiene el folio de la venta
        /// 
        /// Usuario Modifico: Olimpo Cruz
        /// Fecha Modifico: 28 Mayo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Verdadero (true) si se autoriza y falso (false) en caso contrario</returns>
        private string Obtener_Folio(Cls_Ope_Recolecciones_Negocio ObjMyRecoleccion)
        {
            DataTable Dt_Consulta_Folio = new DataTable();
            //Cls_Ope_Recolecciones_Negocio ObjMyRecoleccion = new Cls_Ope_Recolecciones_Negocio();
            string Folio_Mov = "";
            try
            {
                
                Dt_Consulta_Folio = ObjMyRecoleccion.Consultar_Folio_Movimiento();
                //Nombre del usuario que pre-autoriza
                Folio_Mov = Dt_Consulta_Folio.Rows[0]["FOLIO"].ToString();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Autorizar_Movimiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Folio_Mov;
        }

        
        #endregion


        #endregion

        #region (Eventos)

        #region (Botones)
        /// <summary>
        /// Nombre: Btn_Nuevo_Click
        /// 
        /// Descripción: Método que se liga al evento click del botón de alta.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 09 Octubre 2013 18:56 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            String Tipo = string.Empty;
            String Informacion_Ticket = "";
            DataTable Dt_Solicitudes_Pendientes;
            String Solicitudes = "";
            // validar que no haya cajas abiertas
            Cls_Ope_Cajas_Negocio Consultar_Cajas = new Cls_Ope_Cajas_Negocio();

            try
            {
                if (Btn_Nuevo.Text.Trim() == "Nuevo")
                {
                    if (Cmb_Cajas.SelectedIndex != 0 && Cmb_Bancos.SelectedIndex != 0)
                    {
                        if (Autorizar_Movimiento())
                        {
                            Limpiar_Controles();
                            Manejo_Botones_Operacion("Nuevo");

                            //  validacion que sea arqueo
                            if (MDI_Frm_Apl_Principal.Opt_Arqueos == true) Opt_Arqueo.Checked = true;
                            else if (MDI_Frm_Apl_Principal.Opt_Cierre == true) Opt_Cierre_Caja.Checked = true;
                            else if (MDI_Frm_Apl_Principal.Opt_Recoleccion == true) Opt_Recoleccion.Checked = true;
                            Cmb_Cajas_SelectedIndexChanged(sender, null);


                            if (Opt_Cierre_Caja.Checked == true)
                            {
                                //  validacion para las solicitudes pendientes por ingresar
                                Consultar_Cajas.P_Caja_ID = Cmb_Cajas.SelectedValue.ToString();
                                Dt_Solicitudes_Pendientes = Consultar_Cajas.Consultar_Solicitudes_Pendientes();

                                if (Dt_Solicitudes_Pendientes != null && Dt_Solicitudes_Pendientes.Rows.Count > 0)
                                {
                                    Solicitudes = "Faltan por registrar las siguientes solicitudes de facturación con número de venta:\n";
                                    foreach (DataRow Registro in Dt_Solicitudes_Pendientes.Rows)
                                    {
                                        Solicitudes += "" + Registro[Ope_Ventas_Detalles.Campo_No_Venta].ToString() + "\n";
                                    }

                                    Limpiar_Controles();
                                    Manejo_Botones_Operacion("Cancelar");
                                    Cmb_Cajas.Enabled = true;
                                    Cmb_Cajas.SelectedIndex = 0;

                                    MessageBox.Show(this, Solicitudes, "Modificar turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Seleccione una caja y una referencia bancaria", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (this.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        
                        if (Validar_Datos())
                        {
                            //Informacion_Ticket = Texto_Ticket_Recoleccion();

                            if (Opt_Arqueo.Checked) { Tipo = "Arqueo"; }
                            if (Opt_Recoleccion.Checked) { Tipo = "Recolección"; }
                            if (Opt_Cierre_Caja.Checked) { Tipo = "Cierre de Caja"; }

                            if (Alta_Recoleccion(""))
                            {
                                Limpiar_Controles();
                                Manejo_Botones_Operacion("Cancelar");
                                MessageBox.Show(this, "Alta de " + Tipo + " Exitosa", "Operación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (MDI_Frm_Apl_Principal.Opt_Arqueos == true) Opt_Arqueo.Checked = true;
                                else if (MDI_Frm_Apl_Principal.Opt_Cierre == true)
                                {
                                    Opt_Cierre_Caja.Checked = true;

                                    Frm_Ope_Recoleccion_Load(sender, null);
                                }
                                else if (MDI_Frm_Apl_Principal.Opt_Recoleccion == true) Opt_Recoleccion.Checked = true;
                                Cmb_Cajas.Enabled = true;
                                Cmb_Cajas.SelectedIndex = 0;

                            }
                        }
                        else
                        {
                            MessageBox.Show(this, Pnl_Contenedor.Tag.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Descripción: Método que se liga al evento click del botón de actualizar datos de la recolección.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 04 Octubre 2013 18:56 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            string Informacion_Ticket = ""; 
            
            try
            {
                if (Btn_Modificar.Text.Trim().Equals("Modificar"))
                {
                    if (Autorizar_Movimiento())
                    {
                        if (!string.IsNullOrEmpty(Txt_No_Recoleccion.Text))
                        {
                            Manejo_Botones_Operacion("Modificar");
                        }
                        else
                        {
                            MessageBox.Show(this, "No se ha seleccionado ningún registro de recolección de caja a modificar.",
                                "Modificar Recolección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        Informacion_Ticket = Texto_Ticket_Recoleccion();

                        if (Actualizar_Recoleccion(Informacion_Ticket))
                        {
                            Limpiar_Controles();
                            Manejo_Botones_Operacion("Cancelar");
                            MessageBox.Show(this, "Actualizar Recolección", "Operación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Habilitar_Caja();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, Pnl_Contenedor.Tag.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Fecha Creo: 09 Octubre 2013 18:57 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Autorizar_Movimiento())
                {
                    if (!string.IsNullOrEmpty(Txt_No_Recoleccion.Text))
                    {
                        if (Validar_Datos())
                        {
                            if (Eliminar_Recolección())
                            {
                                Limpiar_Controles();
                                Manejo_Botones_Operacion("Cancelar");
                                MessageBox.Show(this, "Cancelación Exitosa", "Operación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Habilitar_Caja();
                            }
                            else
                            {
                                MessageBox.Show(this, "La cancelación de la recolección no se completo", "Cancelar Recolección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No se ha seleccionado ningún registro de recolección de caja a cancelar.", "Cancelar Recolección", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        /// Fecha Creo: 09 Octubre 2013 18:58 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Cmb_Cajas.Enabled == false)
            {
                Limpiar_Controles();
                Cmb_Cajas.Enabled = true;
                Cmb_Cajas.SelectedIndex = 0;
            }
            else if (!Btn_Salir.Text.Equals("Cancelar"))
            {   //  se activan los menus de recoleccino, arqueo, cierre de caja
                MDI_Frm_Apl_Principal Frm_Principal = (MDI_Frm_Apl_Principal)this.MdiParent;
                Frm_Principal.recoleccionesToolStripMenuItem.Enabled = true;
                Frm_Principal.SubMenu_Operacion_Arqueo.Enabled = true;
                Frm_Principal.SubMenu_Operacion_Cierre_Caja.Enabled = true;

                Frm_Ope_Recolecciones_FormClosing(sender, null);

                this.Dispose();
                this.Close();
                this.Usuario_Autoriza = string.Empty;
            }

            else
            {
                Limpiar_Controles();
                Manejo_Botones_Operacion("Cancelar");
                Cmb_Cajas.Enabled = true;
                Cmb_Cajas.SelectedIndex = 0;
                Habilitar_Caja();
            }
        }
        /// <summary>
        /// Nombre: Teclado_Click
        /// 
        /// Descripción: Método que llama cuando se pulsa alguna tecla del teclado en pantalla.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 16:21 p.m.
        /// Usario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Manejador de evento del click del botón</param>
        private void Teclado_Click(object sender, EventArgs e)
        {
            try
            {
                // si no hay texto seleccionado, agregar texto del botón
                if (this.Caja_Activo.SelectionLength <= 0)
                {
                    this.Caja_Activo.Text += ((Button)sender).Text;
                }
                else if (((Button)sender).Text == "0" && this.Caja_Activo.Text != "0")
                {
                    this.Caja_Activo.Text += ((Button)sender).Text;
                }
                else
                {
                    this.Caja_Activo.SelectedText = ((Button)sender).Text;
                }
                //this.Caja_Activo.Focus();
                Sumar_Billetes_Monedas(this, new KeyEventArgs(Keys.A));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Teclado_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Siguiente_Click
        /// 
        /// Descripción: Método que llama cuando se pulsa el boton de siguiente.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 16:26 p.m.
        /// Usario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Caja_Activo.TabIndex >= 9 && this.Caja_Activo.TabIndex < 22)
                {
                    this.Caja_Activo = Pnl_Billetes.Controls.OfType<TextBox>()
                        .Concat(Pnl_Monedas.Controls.OfType<TextBox>())
                        .AsEnumerable<TextBox>()
                        .Where(caja => caja.TabIndex == (this.Caja_Activo.TabIndex + 1))
                        .First<TextBox>();

                    this.Caja_Activo.Focus();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Siguiente_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Anterior_Click
        /// 
        /// Descripción: Método que llama cuando se pulsa el boton de anterior.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 16:26 p.m.
        /// Usario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Anterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Caja_Activo.TabIndex >= 9 && this.Caja_Activo.TabIndex <= 22)
                {
                    this.Caja_Activo = Pnl_Billetes.Controls.OfType<TextBox>()
                        .Concat(Pnl_Monedas.Controls.OfType<TextBox>())
                        .AsEnumerable<TextBox>()
                        .Where(caja => caja.TabIndex == (this.Caja_Activo.TabIndex - 1))
                        .First<TextBox>();

                    this.Caja_Activo.Focus();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Btn_Anterior_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Anterior_Click
        /// 
        /// Descripción: Método que llama cuando se pulsa el boton de borrar texto.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 16:29 p.m.
        /// Usario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Backspace_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Caja_Activo.Text.Length >= 1)
                {
                    // si la caja de texto no tiene texto seleccionado, borrar el último caracter
                    if (this.Caja_Activo.SelectionLength <= 0)
                    {
                        this.Caja_Activo.Text = this.Caja_Activo.Text.Substring(0, this.Caja_Activo.Text.Length - 1);
                        Sumar_Billetes_Monedas(this, new KeyEventArgs(Keys.A));
                    }
                    else
                    {
                        this.Caja_Activo.SelectedText = "";
                        Sumar_Billetes_Monedas(this, new KeyEventArgs(Keys.A));
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Backspace_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Consultar_Click
        /// 
        /// Descripción: Método que consulta los datos de la recolección y sus detalles.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 11:27 p.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 21-feb-2014
        /// Causa modificación: Se cambia <DateTime?> por <MySql.Data.Types.MySqlDateTime?> para recibir 
        ///                     un campo fecha al utilizar una base de datos MySQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recoleccion = new Cls_Ope_Recolecciones_Negocio();
            string No_Recoleccion = string.Empty;//Variable que almacenara el número de la recolección.
            DataTable Dt_Recoleccion = null;
            decimal Total_Billetes = 0.0M;
            decimal Total_Monedas = 0.0M;

            try
            {
                No_Recoleccion = new Cls_Busqueda_Recolecciones().Mostrar_Consulta_Recolecciones("Consultar Recolecciones", this);
                if (!string.IsNullOrEmpty(No_Recoleccion))
                {
                    Obj_Recoleccion.P_No_Recoleccion = No_Recoleccion;
                    Dt_Recoleccion = Obj_Recoleccion.Consultar_Recoleccion();

                    if (Dt_Recoleccion is DataTable)
                    {
                        if (Dt_Recoleccion.AsEnumerable().Any())
                        {
                            var _datos_recoleccion = Dt_Recoleccion
                                .AsEnumerable()
                                .Select(_rec => new
                                {
                                    no_recoleccion = _rec.IsNull(Ope_Recolecciones.Campo_No_Recoleccion) ? string.Empty : _rec.Field<string>(Ope_Recolecciones.Campo_No_Recoleccion),
                                    no_caja = _rec.IsNull(Ope_Recolecciones.Campo_No_Caja) ? string.Empty : _rec.Field<string>(Ope_Recolecciones.Campo_No_Caja),
                                    numero_recoleccion = _rec.IsNull(Ope_Recolecciones.Campo_Numero_Recoleccion) ? string.Empty : _rec.Field<string>(Ope_Recolecciones.Campo_Numero_Recoleccion),
                                    fecha_hora = _rec.IsNull(Ope_Recolecciones.Campo_Fecha_Hora) ? null : _rec.Field<MySql.Data.Types.MySqlDateTime?>(Ope_Recolecciones.Campo_Fecha_Hora),
                                    monto_recolectado = _rec.IsNull(Ope_Recolecciones.Campo_Monto_Recolectado) ? 0 : _rec.Field<decimal>(Ope_Recolecciones.Campo_Monto_Recolectado),
                                    billetes_1000 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Billetes_1000) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Billetes_1000),
                                    billetes_500 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Billetes_500) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Billetes_500),
                                    billetes_200 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Billetes_200) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Billetes_200),
                                    billetes_100 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Billetes_100) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Billetes_100),
                                    billetes_50 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Billetes_50) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Billetes_50),
                                    billetes_20 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Billetes_20) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Billetes_20),
                                    monedas_20 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_20) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_20),
                                    monedas_10 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_10) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_10),
                                    monedas_5 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_5) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_5),
                                    monedas_2 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_2) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_2),
                                    monedas_1 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_1) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_1),
                                    monedas_050 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_050) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_050),
                                    monedas_020 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_020) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_020),
                                    monedas_010 = _rec.IsNull(Ope_Recolecciones_Detalles.Campo_Monedas_010) ? 0 : _rec.Field<int>(Ope_Recolecciones_Detalles.Campo_Monedas_010)
                                });

                            if (_datos_recoleccion.Any())
                            {
                                foreach (var _row in _datos_recoleccion)
                                {
                                    Txt_No_Recoleccion.Text = _row.no_recoleccion;
                                    Cmb_Cajas.SelectedValue = _row.no_caja;
                                    Txt_Numero_Recoleccion.Text = _row.numero_recoleccion;
                                    // se ocupa .GetDateTime() cuando es un tipo MySqlDateTime
                                    Dtp_Fecha_Recoleccion.Value = _row.fecha_hora.Value.GetDateTime();
                                    Dtp_Hora_Recoleccion.Value = _row.fecha_hora.Value.GetDateTime();
                                    Txt_Monto_Recolectado.Text = string.Format("{0:n}", _row.monto_recolectado);
                                    Txt_No_Billetes_1000.Text = _row.billetes_1000.ToString();
                                    Txt_No_Billetes_500.Text = _row.billetes_500.ToString();
                                    Txt_No_Billetes_200.Text = _row.billetes_200.ToString();
                                    Txt_No_Billetes_100.Text = _row.billetes_100.ToString();
                                    Txt_No_Billetes_50.Text = _row.billetes_50.ToString();
                                    Txt_No_Billetes_20.Text = _row.billetes_20.ToString();
                                    Txt_No_Monedas_20.Text = _row.monedas_20.ToString();
                                    Txt_No_Monedas_10.Text = _row.monedas_10.ToString();
                                    Txt_No_Monedas_5.Text = _row.monedas_5.ToString();
                                    Txt_No_Monedas_2.Text = _row.monedas_2.ToString();
                                    Txt_No_Monedas_1.Text = _row.monedas_1.ToString();
                                    Txt_No_Monedas_050.Text = _row.monedas_050.ToString();
                                    Txt_No_Monedas_020.Text = _row.monedas_020.ToString();
                                    Txt_No_Monedas_010.Text = _row.monedas_010.ToString();

                                    Total_Billetes = ((_row.billetes_1000 * 1000) + (_row.billetes_500 * 500) + (_row.billetes_200 * 200) + (_row.billetes_100 * 100) + (_row.billetes_50 * 50) + (_row.billetes_20 * 20));
                                    Total_Monedas = ((_row.monedas_20 * 20M) + (_row.monedas_10 * 10M) + (_row.monedas_5 * 5M) + (_row.monedas_2 * 2M) + (_row.monedas_1 * 1M) + (_row.monedas_050 * 0.50M) + (_row.monedas_020 * 0.20M) + (_row.monedas_010 * 0.10M));
                                }
                            }
                        }
                    }
                }
                Txt_Total_Billetes.Text = string.Format("{0:n}", Total_Billetes);
                Txt_Total_Monedas.Text = string.Format("{0:n}", Total_Monedas);
                Manejo_Botones_Operacion("Cancelar");

                if (MDI_Frm_Apl_Principal.Opt_Arqueos == true) Opt_Arqueo.Checked = true;
                else if (MDI_Frm_Apl_Principal.Opt_Cierre == true) Opt_Cierre_Caja.Checked = true;
                else if (MDI_Frm_Apl_Principal.Opt_Recoleccion == true) Opt_Recoleccion.Checked = true;
                Cmb_Cajas.Enabled = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Cajas)
        /// <summary>
        /// Nombre: Sumar_Billetes_Monedas
        /// 
        /// Descripción: Método que se invoca cuando se presiona una tecla sobre una caja de texto. Y suma 
        ///              la cantidad dependiendo si se trata de billetes o monedas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 10:53 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sumar_Billetes_Monedas(object sender, KeyEventArgs e)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            string Parametro_Id = "00001";
            Consulta_Parametros.P_Parametro_Id = Parametro_Id;
            DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

            decimal Monto_Recolectado_Billetes = 0.0M;//Variable que mantiene el total recolectado en billetes.
            decimal Monto_Recolectado_Monedas = 0.0M;//Variable que mantiene el total recolectado en monedas.
            decimal Tope = 0.0M;
            string Tope_Recoleccion = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Tope_Recoleccion].ToString();
            decimal Tope_Parametro_Recoleccion = Convert.ToDecimal(Tope_Recoleccion);//5000M;

            try
            {
                Tope_Parametro_Recoleccion = 900000M;

                //if (Tope_Recoleccion == "0")
                //{
                   
                //}
                //else if(Opt_Arqueo.Checked == true)
                //{
                //    Tope_Parametro_Recoleccion = Convert.ToDecimal(Txt_Total_En_Caja.Text);
                //}


                #region (Obtener Total Billetes)
                Array.ForEach(Pnl_Billetes.Controls.OfType<TextBox>().ToArray(), caja =>
                {
                    if (!string.IsNullOrEmpty(caja.Text) && !caja.Text.Trim().Equals("0"))
                        Monto_Recolectado_Billetes += (Convert.ToDecimal(string.IsNullOrEmpty(caja.Text) ? "0" : caja.Text) *
                                    Convert.ToDecimal(string.IsNullOrEmpty(caja.Tag.ToString()) ? "0" : caja.Tag.ToString()));
                });
                //Mostrar el total en billetes recolectado.
                Txt_Total_Billetes.Text = string.Format("{0:c}", Monto_Recolectado_Billetes);
                #endregion

                #region (Obtener Total Monedas)
                Array.ForEach(Pnl_Monedas.Controls.OfType<TextBox>().ToArray(), caja =>
                {
                    if (!string.IsNullOrEmpty(caja.Text) && !caja.Text.Trim().Equals("0"))
                        Monto_Recolectado_Monedas += (Convert.ToDecimal(string.IsNullOrEmpty(caja.Text) ? "0" : caja.Text) *
                                    Convert.ToDecimal(string.IsNullOrEmpty(caja.Tag.ToString()) ? "0" : caja.Tag.ToString()));
                });
                //Mostrar el total en monedas recolectado.
                Txt_Total_Monedas.Text = string.Format("{0:c}", Monto_Recolectado_Monedas);
                #endregion

                Txt_Monto_Recolectado.Text = string.Format("{0:n}", (Monto_Recolectado_Billetes + Monto_Recolectado_Monedas));

                decimal _total_efectivo = 0;
                decimal _total = 0;
                decimal _result = 0;
                decimal.TryParse(Txt_Monto_Recolectado.Text, out _total_efectivo);
                decimal.TryParse(Txt_Total_En_Caja.Text, out _total);

                TXt_Resultado_Corte.Text = (_total_efectivo - _total).ToString("n");
                decimal.TryParse(TXt_Resultado_Corte.Text, out _result);

                if (_result > 0)
                {
                    TXt_Resultado_Corte.BackColor = Color.Chartreuse;
                }
                else if (_result == 0)
                {
                    TXt_Resultado_Corte.BackColor = Color.DeepSkyBlue;
                }
                else if (_result < 0)
                {
                    TXt_Resultado_Corte.BackColor = Color.OrangeRed;
                }

                if ((Monto_Recolectado_Billetes + Monto_Recolectado_Monedas) <= Tope_Parametro_Recoleccion)
                {
                    Tope = 100000;//Convert.ToDecimal(string.IsNullOrEmpty(Txt_Total_En_Caja.Text) ? "0" : Txt_Total_En_Caja.Text.Trim());
                    if ((Monto_Recolectado_Billetes + Monto_Recolectado_Monedas) > Tope)
                    {
                        MessageBox.Show(this, "No es posible recolectar mas de lo que hay en caja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // si la caja de texto activa no está vacía, limpiar y volver a calcular, si no, intentar con la anterior o la siguiente
                        if (this.Caja_Activo.Text != string.Empty)
                        {
                            this.Caja_Activo.Text = string.Empty;
                            Sumar_Billetes_Monedas(sender, e);
                        }
                        else
                        {
                            // intentar con la caja de texto anterior
                            if (this.Caja_Activo.TabIndex >= 9 && this.Caja_Activo.TabIndex <= 22)
                            {
                                this.Caja_Activo = Pnl_Billetes.Controls.OfType<TextBox>()
                                    .Concat(Pnl_Monedas.Controls.OfType<TextBox>())
                                    .AsEnumerable<TextBox>()
                                    .Where(caja => caja.TabIndex == (this.Caja_Activo.TabIndex - 1))
                                    .First<TextBox>();

                                this.Caja_Activo.Focus();
                            }
                            // validar si la caja de texto contiene texto
                            if (this.Caja_Activo.Text != string.Empty)
                            {
                                this.Caja_Activo.Text = string.Empty;
                                Sumar_Billetes_Monedas(sender, e);
                            }
                            else
                            {
                                // intentar con la caja siguiente
                                if (this.Caja_Activo.TabIndex >= 9 && this.Caja_Activo.TabIndex < 22)
                                {
                                    this.Caja_Activo = Pnl_Billetes.Controls.OfType<TextBox>()
                                        .Concat(Pnl_Monedas.Controls.OfType<TextBox>())
                                        .AsEnumerable<TextBox>()
                                        .Where(caja => caja.TabIndex == (this.Caja_Activo.TabIndex + 1))
                                        .First<TextBox>();

                                    this.Caja_Activo.Focus();
                                }
                                // validar si la caja de texto contiene texto
                                if (this.Caja_Activo.Text != string.Empty)
                                {
                                    this.Caja_Activo.Text = string.Empty;
                                    Sumar_Billetes_Monedas(sender, e);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "No es posible retirar más de " + string.Format("{0:c}", Tope_Parametro_Recoleccion) + " por recolección.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Caja_Activo.Text = string.Empty;
                    Sumar_Billetes_Monedas(sender, e);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Sumar_Billetes_Monedas: [Sumar_Billetes_Monedas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Billetes_Monedas_KeyPress
        /// 
        /// Descripción: Método que se invoca cuando se presiona una tecla sobre una caja de texto. Valida que solo
        ///              acepte los carácteres correctos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 10:54 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Billetes_Monedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Digito);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Billetes_Monedas_KeyPress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Caja_GotFocus
        /// 
        /// Descripción: Método que se llama cuando una caja de texto de los paneles de Billetes y/o Monedas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 16:22 p.m.
        /// Usario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender">Objeto que dispara el evento</param>
        /// <param name="e">Manejador de evento del foco de la caja de texto</param>
        private void Caja_GotFocus(object sender, EventArgs e)
        {
            try
            {
                this.Caja_Activo = ((TextBox)sender);
                Array.ForEach(Pnl_Billetes.Controls.OfType<TextBox>().Concat(Pnl_Monedas.Controls.OfType<TextBox>()).ToArray(), caja => { caja.BackColor = System.Drawing.Color.White; });
                this.Caja_Activo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Caja_GotFocus]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Combos)
        /// <summary>
        /// Nombre: Cmb_Cajas_SelectedIndexChanged
        /// 
        /// Descripción: Método que se ejecuta la seleccionar un elemento del listado de cajas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 11 Octubre 2013 18:50 p.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 21-feb-2014
        /// Causa modificación: Se cambia <DateTime?> por <MySql.Data.Types.MySqlDateTime?> para recibir 
        ///                     un campo fecha al utilizar una base de datos MySQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Cajas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recolecciones = new Cls_Ope_Recolecciones_Negocio();//Variable para realizar peticiones a la clase de datos.
            DataTable Dt_Datos_Caja = null;

            try
            {
                if (Cmb_Cajas.SelectedIndex > 0)
                {
                    //MessageBox.Show(Cmb_Cajas.SelectedValue.ToString());
                    // validar selección de cmb_caja 
                    if (Cmb_Cajas.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        Obj_Recolecciones.P_No_Caja = Cmb_Cajas.SelectedValue.ToString();
                        Dt_Datos_Caja = Obj_Recolecciones.Consultar_Consecutivo_Recoleccion_Por_Caja_Turno();

                        if (Dt_Datos_Caja is DataTable)
                        {
                            if (Dt_Datos_Caja.AsEnumerable().Any())
                            {
                                var _datos_caja = from _caja in Dt_Datos_Caja.AsEnumerable()
                                                  select new
                                                  {
                                                      _nombre_turno = _caja.IsNull(Cat_Turnos.Campo_Nombre) ? string.Empty : _caja.Field<string>(Cat_Turnos.Campo_Nombre),
                                                      //// recibir campo de una BD SQLServer
                                                      //_fecha_hora_inicio = _caja.IsNull(Ope_Turnos.Campo_Fecha_Hora_Inicio) ? null : _caja.Field<DateTime?>(Ope_Turnos.Campo_Fecha_Hora_Inicio),
                                                      //_fecha_hora_cierre = _caja.IsNull(Ope_Turnos.Campo_Fecha_Hora_Cierre) ? null : _caja.Field<DateTime?>(Ope_Turnos.Campo_Fecha_Hora_Cierre),
                                                      // recibir campo fecha de una BD MySQL
                                                      _fecha_hora_inicio = _caja.IsNull(Ope_Turnos.Campo_Fecha_Hora_Inicio) ? null : _caja.Field<MySql.Data.Types.MySqlDateTime?>(Ope_Turnos.Campo_Fecha_Hora_Inicio),
                                                      _fecha_hora_cierre = _caja.IsNull(Ope_Turnos.Campo_Fecha_Hora_Cierre) ? null : _caja.Field<MySql.Data.Types.MySqlDateTime?>(Ope_Turnos.Campo_Fecha_Hora_Cierre),
                                                      _consecutivo_rec = _caja.IsNull("Numero_Recoleccion") ? 1 : _caja.Field<Int64>("Numero_Recoleccion"),
                                                      _total_tarjeta = _caja.IsNull("Total_Tarjeta") ? 1 : _caja.Field<decimal>("Total_Tarjeta"),
                                                      _total_caja_menos_rec_y_ret = _caja.IsNull("Total") ? 0 : _caja.Field<decimal>("Total"),
                                                      _total_cancelado = _caja.IsNull("Total_Cancelado") ? 0 : _caja.Field<decimal>("Total_Cancelado"),
                                                      _total_recolectado = _caja.IsNull("Total_Recolectado") ? 0 : _caja.Field<decimal>("Total_Recolectado"),
                                                      _total_retiros = _caja.IsNull("Total_Retiros") ? 0 : _caja.Field<decimal>("Total_Retiros"),
                                                      _monto_inicial = _caja.IsNull("Monto_Inicial") ? 0 : _caja.Field<decimal>("Monto_Inicial"),
                                                      _Ventas_Efectivo = _caja.IsNull("Ventas") ? 0 : _caja.Field<decimal>("Ventas"),
                                                      _Ventas_Tarjeta = _caja.IsNull("Ventas_Tarjeta") ? 0 : _caja.Field<decimal>("Ventas_Tarjeta")
                                                  };

                                if (_datos_caja.Any())
                                {
                                    foreach (var _dato in _datos_caja)
                                    {
                                        Txt_Numero_Recoleccion.Text = _dato._consecutivo_rec.ToString();
                                        Dtp_Fecha_Recoleccion.Value = _dato._fecha_hora_inicio.Value.GetDateTime();
                                        Dtp_Hora_Recoleccion.Value = _dato._fecha_hora_inicio.Value.GetDateTime();

                                        Txt_Horario_Turno.Text = "**" + _dato._nombre_turno + "**    Día: " + string.Format("{0:dd MMMM yyyy}", _dato._fecha_hora_inicio.Value) +
                                            "    Horario: (" + string.Format("{0:HH:mm:ss tt}", _dato._fecha_hora_inicio.Value + " - ");

                                        Txt_Fecha_Turno.Text =   "" + String.Format("{0:yyyy-MM-dd}",_dato._fecha_hora_inicio.Value);

                                        if (_dato._fecha_hora_cierre != null && _dato._fecha_hora_cierre.Value.GetDateTime() != DateTime.MinValue)
                                        {
                                            Txt_Horario_Turno.Text += string.Format("{0:HH:mm:ss tt}",
                                                _dato._fecha_hora_cierre.Value);
                                        }
                                        Txt_Horario_Turno.Text += ")";

                                        Txt_Total_En_Caja.Text = string.Format("{0:n}",
                                            _dato._total_caja_menos_rec_y_ret);
                                        Txt_Total_Tarjeta.Text = _dato._total_tarjeta.ToString("n");

                                        Txt_Total_Cancelaciones.Text = _dato._total_cancelado.ToString("n");
                                        Txt_Total_Cancelaciones.Tag = _dato._total_cancelado;

                                        Txt_Cortes_Caja.Text = _dato._total_recolectado.ToString("n");
                                        Txt_Cortes_Caja.Tag = _dato._total_recolectado;

                                        Txt_Retiros_Caja.Text = _dato._total_retiros.ToString("n");
                                        Txt_Retiros_Caja.Tag = _dato._total_retiros;

                                        Txt_Monto_Inicial.Text = _dato._monto_inicial.ToString("n");
                                        Txt_Monto_Inicial.Tag = _dato._monto_inicial;

                                        Txt_Ventas_Efectivo.Text = _dato._Ventas_Efectivo.ToString("n");
                                        Txt_Ventas_Efectivo.Tag = _dato._Ventas_Efectivo;

                                        Txt_Venta_Tarjetas.Text = _dato._Ventas_Tarjeta.ToString("n");
                                        Txt_Venta_Tarjetas.Tag = _dato._Ventas_Tarjeta;
                                    }
                                }
                            }
                        }
                    }
                }
                //else
                //{
                //    Limpiar_Controles();
                //    Manejo_Botones_Operacion("Cancelar");
                //}

                Cmb_Cajas.Enabled = true;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cmb_Cajas_SelectedIndexChanged]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Caja_Activo = new TextBox();
            this.Txt_Total_En_Caja.Visible = true;
            this.TXt_Resultado_Corte.Visible = true;

            //  se activan los menus de recoleccino, arqueo, cierre de caja
            MDI_Frm_Apl_Principal Frm_Principal = (MDI_Frm_Apl_Principal)this.MdiParent;
            Frm_Principal.recoleccionesToolStripMenuItem.Enabled = true;
            Frm_Principal.SubMenu_Operacion_Arqueo.Enabled = true;
            Frm_Principal.SubMenu_Operacion_Cierre_Caja.Enabled = true;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Ope_Recolecciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_Printer != null)
            {
                try
                {
                    ////<<<step9>>>--Start
                    //// Remove OutputCompleteEventHanlder.
                    //RemoveOutputCompleteEvent(m_Printer);
                    ////<<<step9>>>--End
                    ////<<<step10>>>--Start
                    ////Remove ErrorEventHandler.
                    //RemoveErrorEvent(m_Printer);
                    //// Remove StatusUpdateEventHandler.
                    //RemoveStatusUpdateEvent(m_Printer);
                    ////<<<step10>>>--End
                    ////Cancel the device
                    //m_Printer.DeviceEnabled = false;
                    ////Release the device exclusive control right.
                    //m_Printer.Release();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Remove StatusUpdateEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void RemoveStatusUpdateEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo statusUpdateEvent = eventSource.GetType().GetEvent("StatusUpdateEvent");
            if (statusUpdateEvent != null)
            {
                statusUpdateEvent.RemoveEventHandler(eventSource,
                    new StatusUpdateEventHandler(OnStatusUpdateEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// Remove ErrorEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void RemoveErrorEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo errorEvent = eventSource.GetType().GetEvent("ErrorEvent");
            if (errorEvent != null)
            {
                errorEvent.RemoveEventHandler(eventSource,
                    new DeviceErrorEventHandler(OnErrorEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// Remove OutputCompleteEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void RemoveOutputCompleteEvent(object eventSource)
        {
            //<<<step7>>>--Start
            EventInfo outputCompleteEvent = eventSource.GetType().GetEvent("OutputCompleteEvent");
            if (outputCompleteEvent != null)
            {
                outputCompleteEvent.RemoveEventHandler(eventSource,
                    new OutputCompleteEventHandler(OnOutputCompleteEvent));
            }
            //<<<step7>>>--End
        }

        /// <summary>
        /// OutputComplete Event.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OnOutputCompleteEvent(object source, OutputCompleteEventArgs e)
        {
            //<<<step7>>>--Start
            //Notify that printing is completed when it is asnchronous.
            MessageBox.Show("Complete printing : ID = " + e.OutputId.ToString()
                , "Impresión");
            //<<<step7>>>--End
        }

        #endregion
    }
    /// <summary>
    /// Nombre: Cls_Busqueda_Recolecciones
    /// 
    /// Descripción: Clase que se utiliza para crear la ventana de búsqueda de 
    ///               recolecciones. La misma se filtra por la caja seleccionada.
    /// </summary>
    internal class Cls_Busqueda_Recolecciones
    {
        /// <summary>
        /// Nombre: Mostrar_Consulta_Recolecciones
        /// 
        /// Descripción: Método que mostrara una pantalla al usuario que le permitira realizar la busqueda de alguna recolección.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 11 Octubre 2013 09:34 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Titulo">Titulo de la ventana</param>
        /// <returns>El número de la recolección a consultar</returns>
        public string Mostrar_Consulta_Recolecciones(string Titulo, Form _Parent)
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recolecciones = new Cls_Ope_Recolecciones_Negocio();//Variable que se utilizara para realizar peticiones a la clase de datos.
            DataTable Dt_Cajas = null;//Variable para almacenar los resultados de la búsqueda.
            string No_Recoleccion = string.Empty;//Variable para almacenar la recolección consultada.

            #region (Crear Ventana)
            ResizableForm Ventana_Busqueda_Recolecciones = new ResizableForm();
            Ventana_Busqueda_Recolecciones.Width = 792;
            Ventana_Busqueda_Recolecciones.Height = 600;
            Ventana_Busqueda_Recolecciones.FormBorderStyle = FormBorderStyle.Sizable;
            Ventana_Busqueda_Recolecciones.BackColor = SystemColors.GradientActiveCaption;
            Ventana_Busqueda_Recolecciones.Text = Titulo;
            #endregion

            #region (Crear Controles)
            FlowLayoutPanel Pnl_Cajas = new FlowLayoutPanel();
            Pnl_Cajas.SetBounds(10, 10, 765, 175);
            Pnl_Cajas.BackColor = System.Drawing.SystemColors.Window;
            Pnl_Cajas.BorderStyle = BorderStyle.FixedSingle;
            //----------------------------------------------------------------------------
            GroupBox Pnl_Recolecciones = new GroupBox();
            Pnl_Recolecciones.BackColor = System.Drawing.Color.White;
            Pnl_Recolecciones.SetBounds(0, 200, 785, 390);
            Pnl_Recolecciones.Text = "Lista de Recolecciones";
            //----------------------------------------------------------------------------
            DataGridView Grid_Recolecciones = new DataGridView();
            Grid_Recolecciones.SetBounds(0, 0, 777, 360);
            Grid_Recolecciones.BackgroundColor = System.Drawing.Color.White;
            Grid_Recolecciones.ScrollBars = ScrollBars.Vertical;
            #endregion

            #region (Eventos)
            /// <summary>
            /// Nombre: SelectionChanged
            /// 
            /// Descripción: Método que se ejecutara al seleccionar un elemento del grid.
            /// 
            /// Usuario Creo: Juan Alberto Hernández Negrete.
            /// Fecha Creo: 11 Octubre 2013 09:14 a.m.
            /// Usuario Modifico:
            /// Fecha Modifico:
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            Grid_Recolecciones.CellClick += (sender, e) =>
            {
                if (e.RowIndex != (-1))
                {
                    if (!string.IsNullOrEmpty(Grid_Recolecciones.Rows[e.RowIndex].Cells[Ope_Recolecciones.Campo_No_Recoleccion].FormattedValue.ToString()))
                    {
                        Ventana_Busqueda_Recolecciones.Close();
                        No_Recoleccion = Grid_Recolecciones.Rows[e.RowIndex].Cells[Ope_Recolecciones.Campo_No_Recoleccion].FormattedValue.ToString();
                    }
                }
            };
            #endregion

            #region (Crear y consultar cajas)
            //Consultamos las cajas.

            //  validacion para la cuando no sea arqueo
            //if (MDI_Frm_Apl_Principal.Opt_Arqueos == false)
            //{
            //    Obj_Recolecciones.P_Caja_Id = MDI_Frm_Apl_Principal.Caja_ID;
            //}

            Dt_Cajas = Obj_Recolecciones.Consultar_Cajas();

            var Cajas = Dt_Cajas.AsEnumerable()
                .Select(caja => new
                {
                    no_caja = caja.IsNull("No_Caja") ? string.Empty : caja.Field<string>("No_Caja"),
                    caja = caja.IsNull("Caja") ? string.Empty : caja.Field<string>("Caja"),
                });

            //Validamos que existan resultados en la búsqueda hecha.
            if (Cajas.Any())
            {
                Button Btn_Cajas = null;//Declaramos una variable tipo botón que se utilizara para crear y agregar un botón por caja.
                foreach (var _caja in Cajas)
                {
                    Btn_Cajas = new Button();//Instanciamos el objeto tipo botón.
                    Btn_Cajas.Text = _caja.caja;
                    Btn_Cajas.Tag = _caja.no_caja;
                    Btn_Cajas.Width = 80;
                    Btn_Cajas.Height = 80;
                    Btn_Cajas.BackColor = System.Drawing.SystemColors.Info;
                    Btn_Cajas.ForeColor = System.Drawing.Color.Black;
                    Btn_Cajas.Font = new System.Drawing.Font("Tahoma", 11F, FontStyle.Bold);
                    Btn_Cajas.FlatAppearance.BorderColor = Color.DarkGray;
                    Btn_Cajas.FlatStyle = FlatStyle.Popup;
                    //Agregamos al botón su manejador de eventos al hacer click.
                    Btn_Cajas.Click += (sender, e) =>
                    {
                        Cargar_Grid(Grid_Recolecciones, ((Button)sender).Tag.ToString());
                    };
                    //Agregamos el boton instanciado al panel contenedor.
                    Pnl_Cajas.Controls.Add(Btn_Cajas);
                }
            }
            #endregion

            #region (Agregar los controles a su contenedor)
            Pnl_Recolecciones.Controls.Add(Grid_Recolecciones);
            Ventana_Busqueda_Recolecciones.Controls.Add(Pnl_Cajas);
            Ventana_Busqueda_Recolecciones.Controls.Add(Pnl_Recolecciones);
            Ventana_Busqueda_Recolecciones.ShowDialog(_Parent);
            #endregion

            return No_Recoleccion;
        }
        /// <summary>
        /// Nombre: Cargar_Grid
        /// 
        /// Descripción: Método que realiza la carga del grid de recolecciones.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 11 Octubre 2013 09:23 a.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 21-feb-2014
        /// Causa modificación: Se cambia <DateTime?> por <MySql.Data.Types.MySqlDateTime?> para recibir 
        ///                     un campo fecha al utilizar una base de datos MySQL
        /// </summary>
        /// <param name="Grid_Recolecciones"></param>
        private void Cargar_Grid(DataGridView Grid_Recolecciones, string No_Caja)
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recolecciones = new Cls_Ope_Recolecciones_Negocio();//Variable que se utilizara para realizar peticiones a la clase de datos.
            DataTable Dt_Recolecciones = null;//Variable para almacenar los resultados de la búsqueda de recolecciones.

            try
            {
                Obj_Recolecciones.P_No_Caja = No_Caja;
                //Consultamos las recolecciones por caja.
                Dt_Recolecciones = Obj_Recolecciones.Consultar_Recoleccion();

                if (Dt_Recolecciones.AsEnumerable().Any())
                {
                    Grid_Recolecciones.DataSource = Dt_Recolecciones.AsEnumerable().OrderByDescending(rec => rec.Field<string>((Ope_Recolecciones.Campo_No_Recoleccion))).Select(rec => new
                    {
                        NUMERO = rec.IsNull(Ope_Recolecciones.Campo_Numero_Recoleccion) ? string.Empty : rec.Field<string>(Ope_Recolecciones.Campo_Numero_Recoleccion),
                        NO_CAJA = rec.IsNull(Ope_Recolecciones.Campo_No_Caja) ? string.Empty : rec.Field<string>(Ope_Recolecciones.Campo_No_Caja),
                        CAJA = rec.IsNull("Caja_Abierta") ? string.Empty : rec.Field<string>("Caja_Abierta"),
                        FECHA = rec.IsNull(Ope_Recolecciones.Campo_Fecha_Hora) ? null : string.Format("{0:dd MMM yyyy HH:mm:ss tt}", rec.Field<MySql.Data.Types.MySqlDateTime?>(Ope_Recolecciones.Campo_Fecha_Hora).Value),
                        MONTO = rec.IsNull(Ope_Recolecciones.Campo_Monto_Recolectado) ? string.Empty : string.Format("{0:c}", rec.Field<decimal>(Ope_Recolecciones.Campo_Monto_Recolectado)),
                        NO_RECOLECCION = rec.IsNull(Ope_Recolecciones.Campo_No_Recoleccion) ? string.Empty : rec.Field<string>(Ope_Recolecciones.Campo_No_Recoleccion)
                    }).ToList();

                    Array.ForEach(Grid_Recolecciones.Columns.OfType<DataGridViewColumn>().ToArray(),
                        columna =>
                        {
                            switch (columna.HeaderText)
                            {
                                case "NO_RECOLECCION":
                                    columna.Width = 115;
                                    columna.Visible = false;
                                    break;
                                case "CAJA":
                                    columna.Width = 90;
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.HeaderText = "DESCRIPCIÓN";
                                    break;
                                case "FECHA":
                                    columna.Width = 230;
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.HeaderText = "FECHA HORA RECOLECCIÓN";
                                    break;
                                case "NO_CAJA":
                                    columna.Width = 120;
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    break;
                                case "MONTO":
                                    columna.Width = 150;
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.HeaderText = "MONTO RECOLECTADO";
                                    break;
                                case "NUMERO":
                                    columna.Width = 115;
                                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    columna.HeaderText = "NO RECOLECCIÓN";
                                    break;
                                default:
                                    break;
                            }
                            columna.HeaderText = columna.HeaderText.Replace("_", " ");
                            columna.HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Bold);
                        });
                    Array.ForEach(Grid_Recolecciones.Rows.OfType<DataGridViewRow>().ToArray(), fila => { fila.Height = 50; Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda => { celda.Style.Font = new Font("Tahoma", 10, FontStyle.Regular); celda.Style.ForeColor = System.Drawing.Color.Black; celda.Style.BackColor = System.Drawing.Color.WhiteSmoke; }); });
                }
                else
                {
                    Grid_Recolecciones.DataSource = new DataTable();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error - Método [Cargar_Grid]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
