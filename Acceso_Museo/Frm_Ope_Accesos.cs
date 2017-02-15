using System;
using System.Data;
using System.Windows.Forms;
using Erp_Ope_Accesos.Negocio;
using Erp.Constantes;
using System.Drawing;
using ERP_BASE.App_Code.Negocio.Operaciones;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Catalogos.Dias.Feriados.Negocio;
using System.IO.Ports;
using DigitalIO;
using System.Threading;
using Erp.Ayudante_Lector_Codigo;

namespace Acceso_Museo
{
    public partial class Frm_Ope_Accesos : Form
    {
        String Terminal_Id = "";
        String Acceso = String.Empty;
        String Serial_1 = String.Empty;
        Relevador Rele;

        bool First_T1 = true;
        bool First_T2 = true;

        bool Lector2 = true;
        bool Lector3 = true;

        string Codigo_Lector1 = string.Empty;
        string Codigo_Lector2 = string.Empty;
        string Codigo_Lector3 = string.Empty;

        MccDaq.MccBoard DaqBoard = new MccDaq.MccBoard(1);

        int NumPorts, NumBits, FirstBit;
        int PortType, ProgAbility;

        MccDaq.DigitalPortType PortNum;

        DigitalIO.clsDigitalIO DioProps = new DigitalIO.clsDigitalIO();

        public Frm_Ope_Accesos()
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

            try
            {
                DataTable Dt_Consulta = new DataTable();

                string[] Aux = SerialPort.GetPortNames();

                foreach (string Nombre_Puerto in SerialPort.GetPortNames())
                {
                    Dt_Consulta = Cls_Ayudante_Lector_Codigo.Consultar_Puerto("");

                    //  torniquete 1
                    if (Dt_Consulta.Rows[0][Cat_Parametros_Lector_Codigo.Campo_Puerto].ToString() == Nombre_Puerto
                            && Dt_Consulta.Rows[0][Cat_Parametros_Lector_Codigo.Campo_Salida].ToString() == "0")
                    {
                        Serial1.PortName = Nombre_Puerto;
                        Serial1.BaudRate = 9600;
                        Serial1.DataBits = 8;
                        Serial1.Parity = Parity.None;
                        Serial1.StopBits = StopBits.One;
                        Serial1.Handshake = Handshake.None;

                        try
                        {
                            if (!Serial1.IsOpen)
                            {
                                Serial1.Open();

                                if (!System.IO.Directory.Exists("reportes"))
                                    System.IO.Directory.CreateDirectory("reportes");

                                System.IO.File.WriteAllText("reportes/ex-" + DateTime.Now.ToString("dd-MM-yyyy_HH_mm_ss") + ".txt", "Serial Abierto\n");
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
                }

                PortType = clsDigitalIO.PORTIN;
                NumPorts = DioProps.FindPortsOfType(DaqBoard, PortType, out ProgAbility,
                    out PortNum, out NumBits, out FirstBit);

                Rele = new Relevador();
                Rele.Activar_Relevador();

                Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Accesos =
                        new App_Code.Negocio.Cls_Ope_Accesos_Negocio();

                Accesos.Consultar_Accesos_Apertura();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (Serial1.IsOpen)
                Serial1.Close();
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
        ///NOMBRE_FUNCIÓN: serialPort1_DataReceived
        ///DESCRIPCIÓN: Evento para el serial del lector de barras
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 25-Noviembre-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DateTime Inicio = new DateTime();

            try
            {
                // Validación que indica si ya se ha leído un código válido.
                if (!Lector2) { Serial1.Write(""); }
                
                if (Lector2)
                {
                    if (string.IsNullOrEmpty(Codigo_Lector2))
                    {
                        Serial_1 = Serial1.ReadLine();
                        Inicio = DateTime.Now;
                    }

                    DataTable Dt_Consulta = new DataTable();
                    Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio;
                    Acceso_Museo.App_Code.Negocio.Cls_Cat_Cajas_Negocio Cajas;
                    DataTable Dt_Accesos;
                    DateTime Fecha_Inicial_Vigencia;
                    DateTime Fecha_Final_Vigencia;
                    DataTable Dt_Consulta_P = new DataTable();

                    int Puerto = 0;
                    string Tipo_Producto = string.Empty;

                    if (!string.IsNullOrEmpty(Serial_1))
                    {
                        Acceso = Serial_1.Substring(0, 1).ToUpper();
                    }
                    else
                    {
                        return;
                    }

                    if (Acceso == "A") { Puerto = 0; }
                    if (Acceso == "B") { Puerto = 1; }
                    if (Acceso == "C") { Puerto = 2; }

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

                    //Acceso_Negocio.P_Numero_Serie = Txt_Acceso.Text.Substring(2, Txt_Acceso.Text.Length - 2);
                    string Folio = string.Empty;
                    string No_Acceso;

                    if (!string.IsNullOrEmpty(Serial_1))
                    {
                        Folio = Serial_1.Substring(2, 10)[0].ToString();
                    }

                    if (Folio == "0")
                    {
                        Acceso_Negocio.P_No_Acceso = Txt_Acceso.Text.Substring(2, 10);
                    }
                    else
                    {
                        Cajas.P_Numero_Caja = Folio;
                        DataTable Dt_Cajas = Cajas.Consultar_Caja();

                        No_Acceso = Dt_Cajas.Rows[0][Cat_Cajas.Campo_Serie].ToString();
                        //No_Acceso += Txt_Acceso.Text.Substring(3, 9);

                        if (!string.IsNullOrEmpty(Serial_1))
                        {
                            No_Acceso += Serial_1.Substring(3, 9);
                        }

                        Acceso_Negocio.P_No_Acceso = No_Acceso;
                    }

                    Dt_Accesos = Acceso_Negocio.Consultar_Accesos();

                    // validar que la consulta haya regresado resultados
                    if (Dt_Accesos != null && Dt_Accesos.Rows.Count > 0)
                    {
                        Serial1.Close();

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

                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, msj, Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);

                            return;
                        }

                        // validar que esté dentro de la vigencia
                        DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Inicio].ToString(), out Fecha_Inicial_Vigencia);
                        DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Fin].ToString(), out Fecha_Final_Vigencia);
                        if (DateTime.Today < Fecha_Inicial_Vigencia || DateTime.Today > Fecha_Final_Vigencia)
                        {
                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "Fuera de vigencia", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);

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
                                    Mostrar_Mensaje_Pantalla(Puerto, "Grupo", "Grupo: no aplica en días feriados", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);

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

                        Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, mensaje, Color.DarkGreen, Acceso_Museo.Properties.Resources.semaforo_verde);

                        bool Pulso_Torniquete = true;
                        // Se habilita el timer para detectar la lectura del Torniquete.
                        Codigo_Lector2 = Acceso_Negocio.P_No_Acceso;

                        if (Codigo_Lector1 == Codigo_Lector2 ||
                            Codigo_Lector3 == Codigo_Lector2)
                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);

                            Thread.Sleep(1000);

                            if (!Serial1.IsOpen)
                                Serial1.Open();

                            Codigo_Lector2 = string.Empty;
                        }
                        else
                        {
                            Lector2 = false;

                            this.Invoke((MethodInvoker)delegate
                            {
                                Tmr_Torniquete2.Enabled = true;
                            });
                        }

                        if (Pulso_Torniquete) { Pulso(Puerto); }
                    }
                    else
                    {
                        Serial1.Close();

                        Thread.Sleep(1000);

                        if (!Serial1.IsOpen)
                            Serial1.Open();

                        //Puerto_Torniquete = 1;
                        Mostrar_Mensaje_Pantalla(Puerto, "Boleto", "CÓDIGO NO ENCONTRADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);
                    }

                    //Serial1.DiscardInBuffer();
                    //Serial1.DiscardOutBuffer();
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
            }
            finally
            {
                // borrar el campo de texto y asignar control activo
                Serial_1 = string.Empty;
            }
        }

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

                if (Torniquete == "A")
                {
                    Proceso_Boleto(Txt_Acceso.Text);
                }

                if (Torniquete == "C")
                {
                    if (Lector3) { Proceso_Boleto(Txt_Acceso.Text); }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                // borrar el campo de texto y asignar control activo
                Txt_Acceso.Text = "";
                Txt_Acceso.Focus();
            }
        }

        /// <summary>
        /// Validia el número de Boleto leído por el escaner.
        /// </summary>
        /// <param name="Boleto">Código del Boleto</param>
        private void Proceso_Boleto(string Boleto)
        {
            Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio;
            Acceso_Museo.App_Code.Negocio.Cls_Cat_Cajas_Negocio Cajas;
            DataTable Dt_Accesos;
            DateTime Fecha_Inicial_Vigencia;
            DateTime Fecha_Final_Vigencia;
            DataTable Dt_Consulta = new DataTable();

            string Tipo_Producto = string.Empty;
            int Puerto = 0;

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

                if (Acceso == "A") { Puerto = 0; }
                if (Acceso == "B") { Puerto = 1; }
                if (Acceso == "C") { Puerto = 2; }

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
                        }
                        else if (Estatus == "CANCELADO")
                        {
                            msj = "CANCELADO";
                        }

                        Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, msj, Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);

                        return;
                    }

                    // validar que esté dentro de la vigencia
                    DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Inicio].ToString(), out Fecha_Inicial_Vigencia);
                    DateTime.TryParse(Dt_Accesos.Rows[0][Ope_Accesos.Campo_Vigencia_Fin].ToString(), out Fecha_Final_Vigencia);
                    if (DateTime.Today < Fecha_Inicial_Vigencia || DateTime.Today > Fecha_Final_Vigencia)
                    {
                        Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "Fuera de vigencia", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);

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
                                Mostrar_Mensaje_Pantalla(Puerto, "Grupo", "Grupo: no aplica en días feriados", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);

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

                    Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, mensaje, Color.DarkGreen, Acceso_Museo.Properties.Resources.semaforo_verde);

                    bool Pulso_Torniquete = true;
                    if (Puerto == 0) 
                    { 
                        Codigo_Lector1 = Acceso_Negocio.P_No_Acceso;

                        if (Codigo_Lector2 == Codigo_Lector1 ||
                            Codigo_Lector3 == Codigo_Lector1)
                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);
                        }
                        else
                        {
                            // actualizar acceso utilizado
                            Acceso_Negocio.P_Terminal_ID = "00001";
                            Acceso_Negocio.P_Estatus = "UTILIZADO";
                            Acceso_Negocio.P_Fecha_Hora_Acceso = DateTime.Now;
                            Acceso_Negocio.Actualizar_Estatus_Acceso();
                            Pulso(Puerto);
                        }

                        Codigo_Lector1 = string.Empty;
                    }

                    if (Puerto == 2)
                    {
                        Codigo_Lector3 = Acceso_Negocio.P_No_Acceso;

                        if (Codigo_Lector1 == Codigo_Lector3 ||
                            Codigo_Lector2 == Codigo_Lector3)
                        {
                            Pulso_Torniquete = false;
                            Mostrar_Mensaje_Pantalla(Puerto, Tipo_Producto, "CÓDIGO OCUPADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);
                        }
                        else
                        {
                            Pulso(Puerto);
                            Thread.Sleep(100);
                            Tmr_Torniquete3.Enabled = true; 
                        }
                    }
                }
                else
                {
                    //Puerto_Torniquete = 1;
                    Mostrar_Mensaje_Pantalla(Puerto, "Boleto", "CÓDIGO NO ENCONTRADO", Color.Red, Acceso_Museo.Properties.Resources.semaforo_rojo);
                }
            }
            catch (Exception e)
            {
                throw e;
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
            Txt_Acceso.Font = Fuente_Txt_Acceso;
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
        private void Mostrar_Mensaje_Pantalla(Int32 Terminal, String Tipo, String Mensaje, Color Color, Image Imagen_Pantalla )
        {
            if (Terminal == 0)
            {
                Lbl_Tipo_Acceso.ForeColor = Color;
                Lbl_Tipo_Acceso.Text = Tipo;
                Lbl_Mensaje_1.ForeColor = Color;
                Lbl_Mensaje_1.Text = Mensaje;
                Lbl_Codigo_1.ForeColor = Color;
                Lbl_Codigo_1.Text = Txt_Acceso.Text.Substring(2, 10);
                Pic_Semaforo.Image = Imagen_Pantalla;
            }
            else if (Terminal == 1)
            {
                Lbl_Tipo_Acceso_2.ForeColor = Color;
                Lbl_Tipo_Acceso_2.Text = Tipo;
                Lbl_Mensaje_2.ForeColor = Color;
                Lbl_Mensaje_2.Text = Mensaje;
                Lbl_Codigo_2.ForeColor = Color;
                Lbl_Codigo_2.Text = Serial_1.Substring(2, 10); //Txt_Acceso.Text.Substring(2, 10);
                Pic_Semaforo_2.Image = Imagen_Pantalla;
            } 
            else if (Terminal == 2)
            {
                Lbl_Tipo_Acceso_3.ForeColor = Color;
                Lbl_Tipo_Acceso_3.Text = Tipo;
                Lbl_Mensaje_3.ForeColor = Color;
                Lbl_Mensaje_3.Text = Mensaje;
                Lbl_Codigo_3.ForeColor = Color;
                Lbl_Codigo_3.Text = Txt_Acceso.Text.Substring(2, 10);
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
                DateTime Inicio = DateTime.Now;
                Btn_Entrar_Click(sender, e);

                DateTime Fin = DateTime.Now;

                //MessageBox.Show((Fin - Inicio).Milliseconds.ToString(), "Tiempo");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_Torniquete3_Tick(object sender, EventArgs e)
        {
            try
            {
                Tmr_Torniquete3.Stop();

                short DataValue = 0;
                Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio =
                    new App_Code.Negocio.Cls_Ope_Accesos_Negocio();

                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);
                int resul = DataValue & (1 << 0);

                if (resul == 1)
                {
                    Lector3 = false;
                    if (First_T1)
                    {
                        First_T1 = false;
                    }
                    else
                    {
                        short DataValue2 = 0;
                        MccDaq.ErrorInfo ULStat2 = DaqBoard.DIn(PortNum, out DataValue2);

                        int resul2 = DataValue2 & (1 << 2);

                        if (resul2 != 0)
                        {
                            Acceso_Negocio.P_No_Acceso = Codigo_Lector3;
                            Acceso_Negocio.P_Terminal_ID = "00001";
                            Acceso_Negocio.P_Estatus = "UTILIZADO";
                            Acceso_Negocio.P_Fecha_Hora_Acceso = DateTime.Now;
                            Acceso_Negocio.Actualizar_Estatus_Acceso();
                        }
                    }
                }
                else
                {
                    Lector3 = true;
                    
                    if (!First_T1)
                    {
                        First_T1 = true;
                        Codigo_Lector3 = string.Empty;
                        Tmr_Torniquete3.Enabled = false;
                    }
                }

                Tmr_Torniquete3.Start();
            }
            catch (Exception)
            {
                First_T1 = true;
                Codigo_Lector3 = string.Empty;
                Tmr_Torniquete3.Enabled = false;
                Lector3 = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_Torniquete2_Tick(object sender, EventArgs e)
        {
            try
            {
                Tmr_Torniquete2.Stop();
                short DataValue = 0;
                Acceso_Museo.App_Code.Negocio.Cls_Ope_Accesos_Negocio Acceso_Negocio =
                    new App_Code.Negocio.Cls_Ope_Accesos_Negocio();

                MccDaq.ErrorInfo ULStat = DaqBoard.DIn(PortNum, out DataValue);
                int resul = DataValue & (1 << 1);

                if (resul != 0)
                {
                    if (First_T2)
                    {
                        First_T2 = false;
                    }
                    else
                    {
                        short DataValue2 = 0;
                        MccDaq.ErrorInfo ULStat2 = DaqBoard.DIn(PortNum, out DataValue2);

                        int resul2 = DataValue2 & (1 << 3);

                        if (resul2 != 0)
                        {
                            Acceso_Negocio.P_No_Acceso = Codigo_Lector2;
                            Acceso_Negocio.P_Terminal_ID = "00001";
                            Acceso_Negocio.P_Estatus = "UTILIZADO";
                            Acceso_Negocio.P_Fecha_Hora_Acceso = DateTime.Now;
                            Acceso_Negocio.Actualizar_Estatus_Acceso();
                        }
                    }
                }
                else
                {
                    if (!First_T2)
                    {
                        if (!Serial1.IsOpen)
                            Serial1.Open();

                        Codigo_Lector2 = string.Empty;
                        Codigo_Lector3 = string.Empty;
                        First_T2 = true;
                        Tmr_Torniquete2.Enabled = false;
                        Lector2 = true;

                        Serial1.DiscardInBuffer();
                        Serial1.DiscardOutBuffer();
                    }
                }

                Tmr_Torniquete2.Start();
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
        private void Tmr_Torniquete1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!Serial1.IsOpen)
                    Serial1.Open();
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
            }
        }
    }
}
