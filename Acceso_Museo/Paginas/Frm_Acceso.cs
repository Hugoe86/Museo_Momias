using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Erp_Ope_Accesos.Negocio;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Operaciones;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Catalogos.Dias.Feriados.Negocio;
using System.IO.Ports;
using DigitalIO;
using System.Threading;
using Erp.Ayudante_Lector_Codigo;
using Telerik.WinControls.UI;

namespace Acceso_Museo.Paginas
{
    public partial class Frm_Acceso : Telerik.WinControls.UI.RadForm
    {
        String Terminal_Id = "";
        String Acceso = String.Empty;
        String Serial_1 = String.Empty;
        Relevador Rele;
        String codigo_recibido_escanerA = "";
        String codigo_recibido_escanerB = "";
        String codigo_recibido_escanerC = "";
        int tiempo_espera_para_acceder = 5;/*  variable para indicar el tiempo que espera el torniquete para liberar el boleto, 
                                                el torniquete no cuenta con algun pulso para indicar que ya termino de activar el acceso*/


        DateTime tiempo_inicial_a = new DateTime();//   variable para indicar la hora de inicio de acceso tras la lectura
        DateTime tiempo_final_a = new DateTime();//   variable para indicar la hora limite en que debe de pasar de acceso tras la lectura
        DateTime tiempo_inicial_b = new DateTime();//   variable para indicar la hora de inicio de acceso tras la lectura
        DateTime tiempo_final_b = new DateTime();//   variable para indicar la hora limite en que debe de pasar de acceso tras la lectura
        DateTime tiempo_inicial_c = new DateTime();//   variable para indicar la hora de inicio de acceso tras la lectura
        DateTime tiempo_final_c = new DateTime();//   variable para indicar la hora limite en que debe de pasar de acceso tras la lectura

        bool First_TA = true;
        bool First_TB = true;
        bool First_TC = true;

        bool LectorA = true;
        bool LectorB = true;
        bool LectorC = true;

        string Codigo_LectorA = string.Empty;
        string Codigo_LectorB = string.Empty;
        string Codigo_LectorC = string.Empty;

        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(0);

        DateTime Dtime_Fecha_Inicio_Timer = new DateTime();

        int NumPorts, NumBits, FirstBit;
        int PortType, ProgAbility;

        MccDaq.DigitalPortType PortNum;

        DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();

        /// <summary>
        /// 
        /// </summary>
        public Frm_Acceso()
        {
            InitializeComponent();
        }



        #region Lector
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Frm_Ope_Accesos_Load
        ///DESCRIPCIÓN: Habilitara los seriales para el uso de los escaners
        ///PARÁMETROS: N/A
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 24-Noviembre-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Frm_Ope_Accesos_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            SerialPort Puerto_Serial_Auxiliar = new SerialPort();

            try
            {

                //String X = PortNum.ToString();


                DataTable Dt_Consulta = new DataTable();

                string[] Aux = SerialPort.GetPortNames();
                Dt_Consulta = Cls_Ayudante_Lector_Codigo.Consultar_Puerto("");

                foreach (string Nombre_Puerto in SerialPort.GetPortNames())
                {
                    foreach (DataRow registros in Dt_Consulta.Rows)
                    {
                        //  validamos que sea el puerco correcto
                        if (registros[Cat_Parametros_Lector_Codigo.Campo_Puerto].ToString() == Nombre_Puerto)
                        {
                            Int32 Serial = 0;

                            Serial = Convert.ToInt32(registros[Cat_Parametros_Lector_Codigo.Campo_Salida].ToString());


                            ////  validamos que puerto se estara utilizando
                            //if (Serial == 1)
                            //{
                            //    Puerto_Serial_Auxiliar = SerialA;
                            //}
                            //  se valida el puerto numero 2
                            if (Serial == 2)
                            {
                                Puerto_Serial_Auxiliar = SerialB;
                            }
                            //  se toman los valores para el numero 3
                            else if (Serial == 3)
                            {
                                Puerto_Serial_Auxiliar = SerialC;
                            }

                            //  se conecta el serial
                            Conectar_Serial(Puerto_Serial_Auxiliar, Nombre_Puerto);
                        }
                    }
                }

                PortType = clsDigitalIO.PORTIN;
                NumPorts = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility, out PortNum, out NumBits, out FirstBit);

                Rele = new Relevador();
                Rele.Activar_Relevador();

                Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Accesos = new App_Code.Negocio.Cls_Ope_Accesos_Negocio();

                Accesos.Consultar_Accesos_Apertura();


                ////  validamos que este abierto el puerto
                //if (!SerialA.IsOpen)
                //{
                //    Mostrar_Mensaje_Error_Alert(RadAlert_EscanerA, "Error escaner A", "No esta conectado el escaner A");

                //    Mostrar_Mensaje_Pantalla(0, "Error en escaner", "Fuera de servicio Escaner", Color.Red, Acceso_Museo.Properties.Resources.Error_80_icon_icons_com_57326);
                //}

                //  validamos que este abierto el puerto
                if (!SerialB.IsOpen)
                {
                    Mostrar_Mensaje_Error_Alert(RadAlert_EscanerB, "Error escaner B", "No esta conectado el escaner B");

                    Mostrar_Mensaje_Pantalla(1, "Error en escaner", "Fuera de servicio Escaner", Color.Red, Acceso_Museo.Properties.Resources.Error_80_icon_icons_com_57326, "");

                }

                //  validamos que este abierto el puerto
                if (!SerialC.IsOpen)
                {
                    Mostrar_Mensaje_Error_Alert(RadAlert_EscanerC, "Error escaner C", "No esta conectado el escaner C");
                    Mostrar_Mensaje_Pantalla(0, "Error en escaner", "Fuera de servicio Escaner", Color.Red, Acceso_Museo.Properties.Resources.Error_80_icon_icons_com_57326, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Texto"></param>
        private void Mostrar_Mensaje_Error_Alert(RadDesktopAlert Control, String Titulo, String Texto)
        {
            try
            {
                Control.CaptionText = "advertencia";
                Control.ContentText = Texto;
                Control.Show();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Serial"></param>
        /// <param name="Dt_Valores"></param>
        public void Conectar_Serial(SerialPort Serial, String Nombre_Puerto)
        {

            Serial.PortName = Nombre_Puerto;
            Serial.BaudRate = 9600;
            Serial.DataBits = 8;
            Serial.Parity = Parity.None;
            Serial.StopBits = StopBits.One;
            Serial.Handshake = Handshake.None;
            Serial.RtsEnable = true;
            Serial.DtrEnable = true;

            try
            {
                if (!Serial.IsOpen)
                {
                    Serial.Open();

                    if (!System.IO.Directory.Exists("reportes"))
                        System.IO.Directory.CreateDirectory("reportes");

                    // System.IO.File.WriteAllText("reportes/ex-" + DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss") + ".txt", "Serial Abierto\n");
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (!System.IO.Directory.Exists("reportes"))
                        System.IO.Directory.CreateDirectory("reportes");

                    System.IO.File.WriteAllText("reportes/ex-" + DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss") + ".txt",
                        ex.Message + "\n");
                }
                catch { }

                return;
            }

        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Frm_Ope_Accesos_FormClosing
        ///DESCRIPCIÓN: Cierra los seriales para el uso de los escaners
        ///PARÁMETROS: N/A
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 24-Noviembre-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Frm_Ope_Accesos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SerialB.IsOpen)
                SerialB.Close();
        }

        #endregion

        #region Relevador

        private void Pulso(int Puerto)
        {
            Monitor.Enter(Rele);

            try
            {
                Rele.Activar_Relevador(MccDaq.DigitalLogicState.High, Puerto);
                Thread.Sleep(150);
                Rele.Activar_Relevador(MccDaq.DigitalLogicState.Low, Puerto);
            }
            finally
            {
                Monitor.Exit(Rele);
            }
        }
        #endregion

        #region EVENTOS

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Entrar_Click
        ///DESCRIPCIÓN: Manejador del evento click sobre el botón Entrar: se valida que el texto en txt_acceso
        ///             esté registrado en Ope_Accesos
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 14-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Torniquete = Txt_Acceso.Text[0].ToString().ToUpper();

                //if (Torniquete == "A")
                //{
                Proceso_Boleto(Txt_Acceso.Text, 1);
                //}
                
            }
            catch (Exception)
            {
            }
            finally
            {
                // borrar el campo de texto y asignar control activo
                //Txt_Acceso.Text = "";
                //Txt_Acceso.Focus();
            }
        }



        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Frm_Ope_Accesos_Paint
        ///DESCRIPCIÓN: Manejador del evento paint del ofrmulario: cambiar el tamaño de fuente para las etiquetas
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 28-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Frm_Ope_Accesos_Paint(object sender, PaintEventArgs e)
        {
            float Tamanio_Fuente = Obtener_Tamanio_Fuente(e.Graphics, this.Bounds.Size, Lbl_Mensaje_Bienvenida.Font, Lbl_Mensaje_Bienvenida.Text);
            Font Fuente_Mensaje = new Font("Microsoft Sans Serif", Tamanio_Fuente * 0.8F, FontStyle.Regular);
            Lbl_Mensaje_Bienvenida.Font = Fuente_Mensaje;

            Font Fuente_Txt_Acceso = new Font("Microsoft Sans Serif", Tamanio_Fuente * 0.4F, FontStyle.Regular);
            //Txt_Acceso.Font = Fuente_Txt_Acceso;
            Tamanio_Fuente = Obtener_Tamanio_Fuente(e.Graphics, this.Bounds.Size, Lbl_Tipo_Acceso.Font, Lbl_Tipo_Acceso.Text);

            Font Fuente_Acceso = new Font("Microsoft Sans Serif", Tamanio_Fuente * 0.6F, FontStyle.Regular);
            /*
            Lbl_Tipo_Acceso.Font = Fuente_Acceso;
            Lbl_Tipo_Acceso_2.Font = Fuente_Acceso;
            Lbl_Tipo_Acceso_3.Font = Fuente_Acceso;

            Lbl_Mensaje_1.Font = Fuente_Acceso;
            Lbl_Mensaje_2.Font = Fuente_Acceso;
            Lbl_Mensaje_3.Font = Fuente_Acceso;
            */

            Font Fuente_Acceso_Codigo = new Font("Microsoft Sans Serif", Tamanio_Fuente * 0.3F, FontStyle.Regular);

            Lbl_Tipo_Acceso.Font = Fuente_Acceso_Codigo;
            Lbl_Tipo_Acceso_2.Font = Fuente_Acceso_Codigo;
            Lbl_Tipo_Acceso_3.Font = Fuente_Acceso_Codigo;

            Lbl_Mensaje_1.Font = Fuente_Acceso_Codigo;
            Lbl_Mensaje_2.Font = Fuente_Acceso_Codigo;
            Lbl_Mensaje_3.Font = Fuente_Acceso_Codigo;

            Lbl_Codigo_1.Font = Fuente_Acceso_Codigo;
            Lbl_Codigo_2.Font = Fuente_Acceso_Codigo;
            Lbl_Codigo_3.Font = Fuente_Acceso_Codigo;
        }

        #endregion EVENTOS

        #region METODOS

        //********************************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Mostrar_Mensaje_Pantalla
        ///DESCRIPCIÓN          : Metodo que se usa para mostrar la informacion en pantalla
        ///PROPIEDADES          1 Terminal, Posicion de la terminal en pantalla
        ///                     2 Mensaje,  que se mostrara en pantalla
        ///                     3 Color, Color de la fuente 
        ///CREO                 : Leslie González Vázquez
        ///FECHA_CREO           : 12/Noviembre/2011
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN...:
        ///*********************************************************************************************************
        private void Mostrar_Mensaje_Pantalla(Int32 Terminal, String Tipo, String Mensaje, Color Color, Image Imagen_Pantalla, String  numero_boleto)
        {
            //  terminal A
            if (Terminal == 2)
            {
                Lbl_Tipo_Acceso.ForeColor = Color;
                Lbl_Tipo_Acceso.Text = Tipo;
                Lbl_Mensaje_1.ForeColor = Color;
                Lbl_Mensaje_1.Text = Mensaje;
                Lbl_Codigo_1.ForeColor = Color;
                Lbl_Codigo_1.Text = numero_boleto; //Txt_Acceso.Text.Substring(2, 10);
                Pic_Semaforo.Image = Imagen_Pantalla;
            }
            //  terminal B
            else if (Terminal == 1)
            {
                Lbl_Tipo_Acceso_2.ForeColor = Color;
                Lbl_Tipo_Acceso_2.Text = Tipo;
                Lbl_Mensaje_2.ForeColor = Color;
                Lbl_Mensaje_2.Text = Mensaje;
                Lbl_Codigo_2.ForeColor = Color;
                Lbl_Codigo_2.Text = numero_boleto; //Txt_Acceso.Text.Substring(2, 10); //Txt_Acceso.Text.Substring(2, 10);
                
                Pic_Semaforo_2.Image = Imagen_Pantalla;
            }
            //  terminal C
            else if (Terminal == 0)
            {
                Lbl_Tipo_Acceso_3.ForeColor = Color;
                Lbl_Tipo_Acceso_3.Text = Tipo;
                Lbl_Mensaje_3.ForeColor = Color;
                Lbl_Mensaje_3.Text = Mensaje;
                Lbl_Codigo_3.ForeColor = Color;
                Lbl_Codigo_3.Text = numero_boleto; //Txt_Acceso.Text.Substring(2, 10);
                Pic_Semaforo_3.Image = Imagen_Pantalla;
            }

            // borrar el campo de texto y asignar control activo
            //Txt_Acceso.Text = "";
            //Txt_Acceso.Focus();
        }

        private void Limpiar_Pantalla()
        {
            Lbl_Tipo_Acceso.ForeColor = Color.Transparent;
            Lbl_Tipo_Acceso.Text = string.Empty;
            Lbl_Mensaje_1.ForeColor = Color.Transparent;
            Lbl_Mensaje_1.Text = string.Empty;
            Lbl_Codigo_1.ForeColor = Color.Transparent;
            Lbl_Codigo_1.Text = string.Empty;
            Pic_Semaforo.Image = null;

            Lbl_Tipo_Acceso_2.ForeColor = Color.Transparent;
            Lbl_Tipo_Acceso_2.Text = string.Empty;
            Lbl_Mensaje_2.ForeColor = Color.Transparent;
            Lbl_Mensaje_2.Text = string.Empty;
            Lbl_Codigo_2.ForeColor = Color.Transparent;
            Lbl_Codigo_2.Text = string.Empty;
            Pic_Semaforo_2.Image = null;

            Lbl_Tipo_Acceso_3.ForeColor = Color.Transparent;
            Lbl_Tipo_Acceso_3.Text = string.Empty;
            Lbl_Mensaje_3.ForeColor = Color.Transparent;
            Lbl_Mensaje_3.Text = string.Empty;
            Lbl_Codigo_3.ForeColor = Color.Transparent;
            Lbl_Codigo_3.Text = string.Empty;
            Pic_Semaforo_3.Image = null;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Obtener_Tamanio_Fuente
        ///DESCRIPCIÓN: Refrescaa un valor flotante con el tamaño de fuente proporcional para los parámetros proporcionados
        ///PARÁMETROS:
        /// 		1. Graficos: Objeto de superficie de dibujo del control (para obtener medidas del texto)
        /// 		2. Dimensiones: medidas del objeto contenedor (forma)
        /// 		3. Fuente: Fuente actual del control
        /// 		4. Texto_Etiqueta: texto a mostrar en la etiqueta
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 28-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static float Obtener_Tamanio_Fuente(Graphics Graficos, Size Dimensiones, Font Fuente, string Texto_Etiqueta)
        {
            SizeF Tamanio_Texto_Etiqueta = Graficos.MeasureString(Texto_Etiqueta.PadRight(25, '-'), Fuente);
            float Proporcion_Horizontal = Dimensiones.Width / Tamanio_Texto_Etiqueta.Width;
            float Proporcion_Vertical = Dimensiones.Height / Tamanio_Texto_Etiqueta.Height;
            float Proporcion = Math.Min(Proporcion_Vertical, Proporcion_Horizontal);
            return Fuente.Size * Proporcion;
        }
        #endregion METODOS

        /// <summary>
        /// Método utilizado para detectar la Tecla "Enter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Acceso_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Btn_Entrar_Click(sender, e);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_TorniqueteA_Tick(object sender, EventArgs e)
        {
            try
            {
                Tmr_TorniqueteA.Stop();
                short DataValue = 0;
                Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio = new App_Code.Negocio.Cls_Ope_Accesos_Negocio();

                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);

                int resul = DataValue & (1 << 2);

                if (tiempo_final_a >= DateTime.Now)
                {
                    if (resul != 0)
                    {
                        //if (First_TA)
                        //{
                        //    First_TA = false;
                        //}
                        //else
                        //{
                        short DataValue2 = 0;
                        MccDaq.ErrorInfo ULStat2 = DaqBoard.DIn(PortNum, out DataValue2);

                        int resul2 = DataValue2 & (1 << 2);

                        if (resul2 != 0)
                        {
                            Acceso_Negocio.P_No_Acceso = Codigo_LectorA;
                            Acceso_Negocio.P_Terminal_ID = "00001";
                            Acceso_Negocio.P_Estatus = "UTILIZADO";
                            Acceso_Negocio.P_Fecha_Hora_Acceso = DateTime.Now;
                            Acceso_Negocio.Actualizar_Estatus_Acceso();
                            tiempo_final_a = DateTime.MinValue;
                        }
                        //}
                    }
                    else
                    {
                        //if (!First_TA)
                        //{
                        //    if (!SerialA.IsOpen)
                        //        SerialA.Open();

                        //    tiempo_final_a = DateTime.MinValue;
                        //    Codigo_LectorA = string.Empty;
                        //    First_TA = true;
                        //    Tmr_TorniqueteA.Enabled = false;
                        //    LectorA = true;

                        //    SerialA.DiscardInBuffer();
                        //    SerialA.DiscardOutBuffer();
                        //}
                    }

                    Tmr_TorniqueteA.Start();
                }
                else
                {
                    tiempo_final_a = DateTime.MinValue;
                    Codigo_LectorA = string.Empty;
                    First_TA = true;
                    Tmr_TorniqueteA.Enabled = false;
                    LectorA = true;
                }
            }
            catch (Exception ex)
            {
                var d = ex.Message;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_TorniqueteB_Tick(object sender, EventArgs e)
        {
            try
            {
                Tmr_TorniqueteB.Stop();
                short DataValue = 0;
                Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio = new App_Code.Negocio.Cls_Ope_Accesos_Negocio();

                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);

                int resul = DataValue & (1 << 1);


                //  validacion para saber en que hora se estara ejecutando
                if (tiempo_final_b >= DateTime.Now)
                {
                    if (resul != 0)
                    {
                        //if (First_TB)
                        //{
                        //    First_TB = false;
                        //}
                        //else
                        //{
                        short DataValue2 = 0;
                        MccDaq.ErrorInfo ULStat2 = DaqBoard.DIn(PortNum, out DataValue2);

                        int resul2 = DataValue2 & (1 << 1);

                        if (resul2 != 0)
                        {
                            Acceso_Negocio.P_No_Acceso = Codigo_LectorB;
                            Acceso_Negocio.P_Terminal_ID = "00001";
                            Acceso_Negocio.P_Estatus = "UTILIZADO";
                            Acceso_Negocio.P_Fecha_Hora_Acceso = DateTime.Now;
                            Acceso_Negocio.Actualizar_Estatus_Acceso();
                            tiempo_final_b = DateTime.MinValue;
                        }
                        //}
                    }
                    else
                    {
                        //if (!First_TB)
                        //{
                        //    if (!SerialB.IsOpen)
                        //        SerialB.Open();

                        //    tiempo_final_b = DateTime.MinValue;
                        //    Codigo_LectorB = string.Empty;
                        //    First_TB = true;
                        //    Tmr_TorniqueteB.Enabled = false;
                        //    LectorB = true;

                        //    SerialB.DiscardInBuffer();
                        //    SerialB.DiscardOutBuffer();
                        //}
                    }

                    Tmr_TorniqueteB.Start();
                }
                //  se inicializan las variables
                else
                {
                    if (!SerialB.IsOpen)
                        SerialB.Open();

                    tiempo_final_b = DateTime.MinValue;
                    Codigo_LectorB = string.Empty;
                    First_TB = true;
                    Tmr_TorniqueteB.Enabled = false;
                    LectorB = true;
                }
            }
            catch (Exception ex)
            {
                var d = ex.Message;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_TorniqueteC_Tick(object sender, EventArgs e)
        {
            try
            {
                Tmr_TorniqueteC.Stop();
                short DataValue = 0;
                Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio = new App_Code.Negocio.Cls_Ope_Accesos_Negocio();

                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);

                int resul = DataValue & (1 << 0);


                //  validacion para saber en que hora se estara ejecutando
                if (tiempo_final_c >= DateTime.Now)
                {
                    if (resul != 0)
                    {
                        //if (First_TC)
                        //{
                        //    First_TC = false;
                        //}
                        //else
                        //{
                        short DataValue2 = 0;
                        MccDaq.ErrorInfo ULStat2 = DaqBoard.DIn(PortNum, out DataValue2);

                        int resul2 = DataValue2 & (1 << 0);

                        if (resul2 != 0)
                        {
                            Acceso_Negocio.P_No_Acceso = Codigo_LectorC;
                            Acceso_Negocio.P_Terminal_ID = "00001";
                            Acceso_Negocio.P_Estatus = "UTILIZADO";
                            Acceso_Negocio.P_Fecha_Hora_Acceso = DateTime.Now;
                            Acceso_Negocio.Actualizar_Estatus_Acceso();

                            tiempo_final_c = DateTime.MinValue;
                        }
                        //}
                    }
                    else
                    {
                        //if (!First_TC)
                        //{
                        //    if (!SerialC.IsOpen)
                        //        SerialC.Open();

                        //    tiempo_final_c = DateTime.MinValue;

                        //    Codigo_LectorC = string.Empty;
                        //    First_TC = true;
                        //    Tmr_TorniqueteC.Enabled = false;
                        //    LectorC = true;
                        //}
                    }

                    Tmr_TorniqueteC.Start();
                }
                //  se inicializan las variables
                else
                {
                    if (!SerialC.IsOpen)
                        SerialC.Open();

                    tiempo_final_c = DateTime.MinValue;
                    Codigo_LectorC = string.Empty;
                    First_TC = true;
                    Tmr_TorniqueteC.Enabled = false;
                    LectorC = true;
                }
            }
            catch (Exception ex)
            {
                var d = ex.Message;
            }
        }


        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: SerialB_DataReceived
        ///DESCRIPCIÓN: Evento para el serial del lector de barras
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 25-Noviembre-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void SerialB_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String Codigo_Barras = "";

            try
            {
                Codigo_Barras = SerialB.ReadExisting();

                codigo_recibido_escanerB += Codigo_Barras;


                //  validamos que la infomracion no sea mayor a la del boleto
                if (codigo_recibido_escanerB.Length > 12)
                {
                    codigo_recibido_escanerB = "";

                    codigo_recibido_escanerB += Codigo_Barras;
                }



                //  se valida que no este en uso el torniquete       
                if (LectorB)
                {
                    if (string.IsNullOrEmpty(Codigo_LectorB))
                    {
                        if (codigo_recibido_escanerB.Length >= 12)
                        {
                            Lectura_Codigo_Barras(codigo_recibido_escanerB, 1);
                            codigo_recibido_escanerB = "";

                            SerialB.DiscardInBuffer();
                            SerialB.DiscardOutBuffer();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (!System.IO.Directory.Exists("reportes"))
                        System.IO.Directory.CreateDirectory("reportes");

                    System.IO.File.WriteAllText("reportes/ex-" + DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss") + ".txt",
                        ex.Message + "\n");
                }
                catch
                {
                }
            }
            finally
            {
                // borrar el campo de texto y asignar control activo
                Serial_1 = string.Empty;
            }
        }


        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Serial2_DataReceived
        ///DESCRIPCIÓN: Evento para el serial del lector de barras
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 25-Noviembre-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************

        private void SerialC_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String Codigo_Barras = "";

            try
            {
                Codigo_Barras = SerialC.ReadExisting();

                codigo_recibido_escanerC += Codigo_Barras;

                //  validamos que la infomracion no sea mayor a la del boleto
                if (codigo_recibido_escanerC.Length > 12)
                {
                    codigo_recibido_escanerC = "";

                    codigo_recibido_escanerC += Codigo_Barras;
                }


                //  se valida que no este en uso el torniquete       
                if (LectorC)
                {
                    if (string.IsNullOrEmpty(Codigo_LectorC))
                    {
                        if (codigo_recibido_escanerC.Length >= 12)
                        {
                            Lectura_Codigo_Barras(codigo_recibido_escanerC, 0);
                            codigo_recibido_escanerC = "";

                            SerialC.DiscardInBuffer();
                            SerialC.DiscardOutBuffer();
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (!System.IO.Directory.Exists("reportes"))
                        System.IO.Directory.CreateDirectory("reportes");

                    System.IO.File.WriteAllText("reportes/ex-" + DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss") + ".txt",
                        ex.Message + "\n");
                }
                catch
                {
                }
            }
            finally
            {
                // borrar el campo de texto y asignar control activo
                Serial_1 = string.Empty;
            }

        }

        /// <summary>
        /// Validia el número de Boleto leído por el escaner.
        /// </summary>
        /// <param name="Boleto">Código del Boleto</param>
        private void Proceso_Boleto(string Boleto, int lector_discapacitados = 0)
        {
            Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio = new App_Code.Negocio.Cls_Ope_Accesos_Negocio();
            Acceso_Museo.App_Code.Negocio.Cls_Cat_Cajas_Negocio Cajas;
            DataTable Dt_Accesos;
            DateTime Fecha_Inicial_Vigencia;
            DateTime Fecha_Final_Vigencia;
            DataTable Dt_Consulta = new DataTable();

            Boolean accion_torniquete_1 = false;

            string Tipo_Producto = string.Empty;
            int Puerto_Relevador = 0;
            int puerto_mensaje = 2;

            // validar que el control contenga caracteres
            if (Boleto.Length <= 0)
            {
                // borrar el campo de texto y asignar control activo
                Txt_Acceso.Text = "";
                Txt_Acceso.Focus();
                return;
            }

            try
            {
                Acceso = Boleto.ToUpper().Substring(0, 1);

                if (lector_discapacitados == 1) {
                    Acceso = "A";
                    Puerto_Relevador = 2;
                }
                //else if (Acceso == "B") { Puerto_Relevador = 1; }
                //else if (Acceso == "C") { Puerto_Relevador = 2; }

                Dt_Consulta = Cls_Ayudante_Lector_Codigo.Consultar_Puerto(Acceso);
                Terminal_Id = "00001";

                // consultar acceso válido
                Acceso_Negocio = new Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio();
                Cajas = new Acceso_Museo.App_Code.Negocio.Cls_Cat_Cajas_Negocio();

                //Acceso_Negocio.P_Numero_Serie = Txt_Acceso.Text.Substring(2, Txt_Acceso.Text.Length - 2);
                string Folio = string.Empty;
                string No_Acceso;

                if (Boleto != string.Empty)
                {
                    Folio = Boleto.Substring(2, 10)[0].ToString();
                }

                if (Folio == "0")
                {
                    Acceso_Negocio.P_No_Acceso = Boleto.Substring(2, 10);
                }
                else
                {
                    Cajas.P_Numero_Caja = Folio;
                    DataTable Dt_Cajas = Cajas.Consultar_Caja();

                    No_Acceso = Dt_Cajas.Rows[0][Cat_Cajas.Campo_Serie].ToString();
                    No_Acceso += Boleto.Substring(3, 9);

                    Acceso_Negocio.P_No_Acceso = No_Acceso;
                }

                Dt_Accesos = Acceso_Negocio.Consultar_Accesos();

                // validar que la consulta haya regresado resultados
                if (Dt_Accesos != null && Dt_Accesos.Rows.Count > 0)
                {
                    // validar que el estatus del acceso sea activo
                    if (Dt_Accesos.Rows[0][Ope_Accesos.Campo_Estatus].ToString() != "ACTIVO")
                    {
                        string Producto_ID = Dt_Accesos.Rows[0][Ope_Accesos.Campo_Producto_ID].ToString();
                        string Estatus = Dt_Accesos.Rows[0][Ope_Accesos.Campo_Estatus].ToString();
                        string msj = "CORRECTO";

                        /*Cls_Cat_Productos_Negocio Productos = new Cls_Cat_Productos_Negocio();
                        Productos.P_Producto_Id = Producto_ID;*/

                        Tipo_Producto = Dt_Accesos.Rows[0]["NOMBRE_PRODUCTO"].ToString();

                        if (Estatus == "UTILIZADO")
                        {
                            msj = "CÓDIGO UTILIZADO";
                            Txt_Acceso.Text = "";
                        }
                        else if (Estatus == "CANCELADO")
                        {
                            msj = "CANCELADO";
                        }

                        Mostrar_Mensaje_Pantalla(puerto_mensaje, Tipo_Producto, msj, Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Boleto);

                        return;
                    }

                    // validar que esté dentro de la vigencia
                    DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Inicio].ToString(), out Fecha_Inicial_Vigencia);
                    DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Fin].ToString(), out Fecha_Final_Vigencia);
                    if (DateTime.Today < Fecha_Inicial_Vigencia || DateTime.Today > Fecha_Final_Vigencia)
                    {
                        Mostrar_Mensaje_Pantalla(puerto_mensaje, Tipo_Producto, "Fuera de vigencia", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Boleto);

                        Txt_Acceso.Text = "";

                        return;
                    }

                    String Texto_Grupo = "";
                    // obtener datos del grupo
                    Acceso_Museo.App_Code.Negocio.Cls_Ope_Grupos_Negocio Obj_Grupos_Negocio
                        = new Acceso_Museo.App_Code.Negocio.Cls_Ope_Grupos_Negocio();

                    Obj_Grupos_Negocio.P_No_Venta = Dt_Accesos.Rows[0][Ope_Accesos.Campo_No_Venta].ToString();
                    DataTable Dt_Grupos = Obj_Grupos_Negocio.Consultar_Grupos();

                    if (Dt_Grupos != null && Dt_Grupos.Rows.Count > 0)
                    {
                        // si aplican días feriados es diferente a S, validar días feriados
                        if (Dt_Grupos.Rows[0][Ope_Ventas.Campo_Aplican_Dias_Festivos].ToString() != "S")
                        {
                            Acceso_Museo.App_Code.Negocio.Cls_Cat_Dias_Feriados_Negocio Obj_Dias_Feriados
                                = new Acceso_Museo.App_Code.Negocio.Cls_Cat_Dias_Feriados_Negocio();

                            if (Obj_Dias_Feriados.EsFeriado(DateTime.Today) == true)
                            {
                                Mostrar_Mensaje_Pantalla(puerto_mensaje, "Grupo", "Grupo: no aplica en días feriados", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Boleto);

                                return;
                            }
                        }
                        // datos del grupo para mensaje de acceso
                        Texto_Grupo = "\nGrupo: " + Dt_Grupos.Rows[0][Ope_Ventas.Campo_Empresa].ToString() + "\n";
                        Texto_Grupo += Dt_Grupos.Rows[0][Ope_Ventas.Campo_Empresa].ToString() + "\n";
                    }

                    string mensaje = Tipo_Producto + Texto_Grupo;

                    if (string.IsNullOrEmpty(Texto_Grupo)) { mensaje = "ÉXITO"; }

                    // mostrar acceso (cambiar color e imagen de semáforo)
                    Tipo_Producto = Dt_Accesos.Rows[0]["NOMBRE_PRODUCTO"].ToString();

                    Mostrar_Mensaje_Pantalla(puerto_mensaje, Tipo_Producto, mensaje, Color.DarkGreen, Acceso_Museo.Properties.Resources.semaforo_verde, Boleto);

                    bool Pulso_Torniquete = true;



                    if (Acceso == "A")
                    {
                        Codigo_LectorA = Acceso_Negocio.P_No_Acceso;
                        accion_torniquete_1 = true;
                    }


                    //  ----------------------------------------------------------------------------------------------------
                    //  ----------------------------------------------------------------------------------------------------
                    //  validamos que codigo 1 y codigo 2 no sea iguanles
                    if (Codigo_LectorA.Length > 0 && Codigo_LectorB.Length > 0)
                    {
                        if (Codigo_LectorA == Codigo_LectorB)

                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(puerto_mensaje, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Boleto);

                            if (Acceso == "A")
                            {
                                Codigo_LectorA = "";
                            }
                        }
                    }
                    //  validamos que codigo 1 y codigo 3 no sea iguanles
                    else if (Codigo_LectorA.Length > 0 && Codigo_LectorC.Length > 0)
                    {
                        if (Codigo_LectorA == Codigo_LectorC)
                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(puerto_mensaje, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Boleto);

                            Codigo_LectorA = "";

                        }
                    }
                    else if (Codigo_LectorA == Acceso_Negocio.P_No_Acceso && tiempo_final_a != DateTime.MinValue)
                    {
                        Pulso_Torniquete = false;
                    }


                    //  se activa el torniquete
                    if (Pulso_Torniquete)
                    {
                        Codigo_LectorA = Acceso_Negocio.P_No_Acceso;
                        
                        tiempo_inicial_a = DateTime.Now;
                        tiempo_final_a = tiempo_inicial_a.AddSeconds(tiempo_espera_para_acceder);
                        
                        this.Invoke((MethodInvoker)delegate
                        {
                            Tmr_TorniqueteA.Enabled = true;
                        });


                        Pulso(Puerto_Relevador);
                    }




                    Txt_Acceso.Text = "";
                }
                else
                {
                    //Puerto_Torniquete = 1;
                    Mostrar_Mensaje_Pantalla(Puerto_Relevador, "Boleto", "CÓDIGO NO ENCONTRADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Boleto);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: SerialC_DataReceived
        ///DESCRIPCIÓN: Evento para el serial del lector de barras
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 25-Noviembre-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************

        private void SerialA_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String Codigo_Barras = "";

            try
            {
                Codigo_Barras = SerialA.ReadExisting();

                codigo_recibido_escanerA += Codigo_Barras;

                //  validamos que la infomracion no sea mayor a la del boleto
                if (codigo_recibido_escanerA.Length > 12)
                {                          
                    codigo_recibido_escanerA = "";
                                           
                    codigo_recibido_escanerA += Codigo_Barras;
                }


                //  se valida que no este en uso el torniquete       
                if (LectorC)
                {
                    if (string.IsNullOrEmpty(Codigo_LectorA))
                    {
                        if (codigo_recibido_escanerA.Length >= 12)
                        {
                            Lectura_Codigo_Barras(codigo_recibido_escanerA, 2);
                            codigo_recibido_escanerA = "";

                            SerialA.DiscardInBuffer();
                            SerialA.DiscardOutBuffer();
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                try
                {
                    if (!System.IO.Directory.Exists("reportes"))
                        System.IO.Directory.CreateDirectory("reportes");

                    System.IO.File.WriteAllText("reportes/ex-" + DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss") + ".txt",
                        ex.Message + "\n");
                }
                catch
                {
                }
            }
            finally
            {
                // borrar el campo de texto y asignar control activo
                Serial_1 = string.Empty;
            }

        }


        




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lectura_Codigo_Barras(String Codigo_Barras, int Puerto)
        {

            //if (Acceso == "A") { Puerto = 0; }
            //if (Acceso == "B") { Puerto = 3; }
            //if (Acceso == "C") { Puerto = 2; }

            Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio;
            Acceso_Museo.App_Code.Negocio.Cls_Cat_Cajas_Negocio Cajas;
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Accesos = new DataTable();
            DateTime Fecha_Inicial_Vigencia;
            DateTime Fecha_Final_Vigencia;
            DataTable Dt_Consulta_P = new DataTable();
            string Tipo_Producto = string.Empty;
            Boolean accion_torniquete_1 = false;
            Boolean accion_torniquete_2 = false;
            Boolean accion_torniquete_3 = false;
            string Folio = string.Empty;
            string No_Acceso = "";



            try
            {
                //if (Codigo_Barras.Length >= 12)
                //{
                Folio = Codigo_Barras.Substring(1, 10)[0].ToString();//  se obtien el numero de la caja

                if (Puerto == 2) { Acceso = "A"; }
                else if (Puerto == 1) { Acceso = "B"; }
                else if (Puerto == 0) { Acceso = "C"; }

                Dt_Consulta_P = Cls_Ayudante_Lector_Codigo.Consultar_Puerto(Acceso);

                //  se consulta el id de la terminar
                if (Dt_Consulta_P != null && Dt_Consulta_P.Rows.Count > 0)
                {
                    foreach (DataRow Registro in Dt_Consulta_P.Rows)
                    {
                        Terminal_Id = Registro[Cat_Terminales.Campo_Terminal_ID].ToString();
                    }
                }
                else
                {
                    Terminal_Id = "00001";
                }

                // consultar acceso válido
                Acceso_Negocio = new Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio();
                Cajas = new Acceso_Museo.App_Code.Negocio.Cls_Cat_Cajas_Negocio();


                if (Folio == "0")
                {
                    Acceso_Negocio.P_No_Acceso = Folio.Substring(1, 10);
                }
                else
                {
                    Cajas.P_Numero_Caja = Folio;
                    DataTable Dt_Cajas = Cajas.Consultar_Caja();

                    No_Acceso = Dt_Cajas.Rows[0][Cat_Cajas.Campo_Serie].ToString();

                    if (!string.IsNullOrEmpty(Codigo_Barras))
                    {
                        No_Acceso += Codigo_Barras.Substring(2, 9);
                    }

                    Acceso_Negocio.P_No_Acceso = No_Acceso;
                }

                Dt_Accesos = Acceso_Negocio.Consultar_Accesos();

                // validar que la consulta haya regresado resultados
                if (Dt_Accesos != null && Dt_Accesos.Rows.Count > 0)
                {

                    // validar que el estatus del acceso sea activo
                    if (Dt_Accesos.Rows[0][Ope_Accesos.Campo_Estatus].ToString() != "ACTIVO")
                    {
                        string Producto_ID = Dt_Accesos.Rows[0][Ope_Accesos.Campo_Producto_ID].ToString();
                        string Estatus = Dt_Accesos.Rows[0][Ope_Accesos.Campo_Estatus].ToString();
                        string msj = "CORRECTO";

                        Tipo_Producto = Dt_Accesos.Rows[0]["NOMBRE_PRODUCTO"].ToString();

                        if (Estatus == "UTILIZADO")
                        {
                            msj = "CÓDIGO UTILIZADO";
                        }
                        else if (Estatus == "CANCELADO")
                        {
                            msj = "CANCELADO";
                        }

                        Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, msj, Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Codigo_Barras);

                        return;
                    }

                    // validar que esté dentro de la vigencia
                    DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Inicio].ToString(), out Fecha_Inicial_Vigencia);
                    DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Fin].ToString(), out Fecha_Final_Vigencia);
                    if (DateTime.Today < Fecha_Inicial_Vigencia || DateTime.Today > Fecha_Final_Vigencia)
                    {
                        Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "Fuera de vigencia", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Folio);

                        return;
                    }

                    String Texto_Grupo = "";
                    // obtener datos del grupo
                    Acceso_Museo.App_Code.Negocio.Cls_Ope_Grupos_Negocio Obj_Grupos_Negocio = new Acceso_Museo.App_Code.Negocio.Cls_Ope_Grupos_Negocio();

                    Obj_Grupos_Negocio.P_No_Venta = Dt_Accesos.Rows[0][Ope_Accesos.Campo_No_Venta].ToString();
                    DataTable Dt_Grupos = Obj_Grupos_Negocio.Consultar_Grupos();

                    if (Dt_Grupos != null && Dt_Grupos.Rows.Count > 0)
                    {
                        // si aplican días feriados es diferente a S, validar días feriados
                        if (Dt_Grupos.Rows[0][Ope_Ventas.Campo_Aplican_Dias_Festivos].ToString() != "S")
                        {
                            Acceso_Museo.App_Code.Negocio.Cls_Cat_Dias_Feriados_Negocio Obj_Dias_Feriados
                                = new Acceso_Museo.App_Code.Negocio.Cls_Cat_Dias_Feriados_Negocio();

                            if (Obj_Dias_Feriados.EsFeriado(DateTime.Today) == true)
                            {
                                Mostrar_Mensaje_Pantalla(Puerto, "Grupo", "Grupo: no aplica en días feriados", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Codigo_Barras);

                                return;
                            }
                        }

                        // datos del grupo para mensaje de acceso
                        Texto_Grupo = "\nGrupo: " + Dt_Grupos.Rows[0][Ope_Ventas.Campo_Empresa].ToString() + "\n";
                        Texto_Grupo += Dt_Grupos.Rows[0][Ope_Ventas.Campo_Empresa].ToString() + "\n";
                    }

                    string mensaje = Tipo_Producto + Texto_Grupo;

                    if (string.IsNullOrEmpty(Texto_Grupo)) { mensaje = "ÉXITO"; }

                    // mostrar acceso (cambiar color e imagen de semáforo)
                    Tipo_Producto = Dt_Accesos.Rows[0]["NOMBRE_PRODUCTO"].ToString();

                    Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, mensaje, Color.DarkGreen, Acceso_Museo.Properties.Resources.semaforo_verde, Codigo_Barras);

                    bool Pulso_Torniquete = true;

                    //  ----------------------------------------------------------------------------------------------------
                    //  ----------------------------------------------------------------------------------------------------
                    // Se habilita el timer para detectar la lectura del Torniquete.
                    if (Acceso == "A")
                    {
                        Codigo_LectorA = Acceso_Negocio.P_No_Acceso;
                        accion_torniquete_1 = true;
                    }
                    else if (Acceso == "B")
                    {
                        Codigo_LectorB = Acceso_Negocio.P_No_Acceso;
                        accion_torniquete_2 = true;
                    }
                    else if (Acceso == "C")
                    {
                        Codigo_LectorC = Acceso_Negocio.P_No_Acceso;
                        accion_torniquete_3 = true;
                    }

                    //  ----------------------------------------------------------------------------------------------------
                    //  ----------------------------------------------------------------------------------------------------
                    //  validamos que codigo 1 y codigo 2 no sea iguanles
                    if (Codigo_LectorA.Length > 0 && Codigo_LectorB.Length > 0)
                    {
                        if (Codigo_LectorA == Codigo_LectorB)

                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Codigo_Barras);

                            if (Acceso == "A")
                            {
                                Codigo_LectorA = "";
                            }
                            else if (Acceso == "B")
                            {
                                Codigo_LectorB = "";
                            }
                            else if (Acceso == "C")
                            {
                                Codigo_LectorC = "";
                            }

                        }
                    }
                    //  validamos que codigo 2 y codigo 3 no sea iguanles
                    else if (Codigo_LectorB.Length > 0 && Codigo_LectorC.Length > 0)
                    {
                        if (Codigo_LectorB == Codigo_LectorC)
                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Codigo_Barras);

                            if (Acceso == "A")
                            {
                                Codigo_LectorA = "";
                            }
                            else if (Acceso == "B")
                            {
                                Codigo_LectorB = "";
                            }
                            else if (Acceso == "C")
                            {
                                Codigo_LectorC = "";
                            }

                        }
                    }
                    //  validamos que codigo 1 y codigo 3 no sea iguanles
                    else if (Codigo_LectorA.Length > 0 && Codigo_LectorC.Length > 0)
                    {
                        if (Codigo_LectorA == Codigo_LectorC)

                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Codigo_Barras);

                            if (Acceso == "A")
                            {
                                Codigo_LectorA = "";
                            }
                            else if (Acceso == "B")
                            {
                                Codigo_LectorB = "";
                            }
                            else if (Acceso == "C")
                            {
                                Codigo_LectorC = "";
                            }

                        }
                    }

                    if (Pulso_Torniquete)
                    {
                        if (accion_torniquete_1 == true)
                        {
                            //LectorA = false;

                            //  se asignan las horas 
                            tiempo_inicial_a = DateTime.Now;
                            tiempo_final_a = tiempo_inicial_a.AddSeconds(tiempo_espera_para_acceder);

                            this.Invoke((MethodInvoker)delegate
                            {
                                Tmr_TorniqueteA.Enabled = true;
                            });

                        }
                        else if (accion_torniquete_2 == true)
                        {
                            //LectorB = false;

                            //  se asignan las horas 
                            tiempo_inicial_b = DateTime.Now;
                            tiempo_final_b = tiempo_inicial_b.AddSeconds(tiempo_espera_para_acceder);

                            this.Invoke((MethodInvoker)delegate
                            {
                                Tmr_TorniqueteB.Enabled = true;
                            });

                        }
                        else if (accion_torniquete_3 == true)
                        {
                            //LectorC = false;

                            //  se asignan las horas 
                            tiempo_inicial_c = DateTime.Now;
                            tiempo_final_c = tiempo_inicial_c.AddSeconds(tiempo_espera_para_acceder);

                            this.Invoke((MethodInvoker)delegate
                            {
                                Tmr_TorniqueteC.Enabled = true;
                            });
                        }
                    }


                    //  se envia el pulso del relevador al toriniquete
                    if (Pulso_Torniquete)
                    {
                        Pulso(Puerto);
                    }
                }
                else
                {
                    Mostrar_Mensaje_Pantalla(Puerto, "Boleto", "CÓDIGO NO ENCONTRADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo, Codigo_Barras);
                }
                
            }
            catch (Exception ex)
            {
            }
        }
    }
}
