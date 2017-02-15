using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Erp.Constantes;
using Erp.Seguridad;
using Erp_Apl_Usuarios.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp_Cat_Apl_Registro_Accesos.Negocio;
using Erp.Validador;
using Catalogos.Turnos.Negocio;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Operaciones.Turnos.Negocio;
using Erp_Apl_Parametros.Negocio;
using MySql.Data.MySqlClient;
using Erp_Solicitud_Facturacion.Negocio;
using System.Data.Odbc;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Apl_Login : Form
    {
        public static Frm_Apl_Recuperar_Contrasenia Frm_Apl_Recuperar_Contrasenia_Mdi;
        Validador_Generico Validador;
        #region Enumerar Accion

        public enum Estatus_Dialogo
        {
            Cancelar = 0,
            Aceptar
        }

        // Variable que indica el estatus del cuadro de diálogo al aceptar o cancelar
        private static Estatus_Dialogo Estatus_Login;

        #endregion Enumerar Accion
        #region Page load

        public Frm_Apl_Login()
        {
            InitializeComponent();
        }

        private void Frm_Apl_Login_Load(object sender, EventArgs e)
        {
            //Establece la posición y medidas de la ventana
            //this.Height = 160;
            //this.Width = 300;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            Validador = new Validador_Generico(Erp_Login);
            Erp_Login.Clear();
            Txt_Login.Focus();
        }

        #endregion Page load
        #region Metodos Generales
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Iniciar_Session
        //DESCRIPCIÓN: inicia Session el usuario que se logueo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 20-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Iniciar_Session()
        {
            Cuentas_Caducas();
            if (Txt_Password.Text != "" && Txt_Login.Text != "")
            {
                Iniciar_Sesion_Usuario();
            }
            else
            {
                MessageBox.Show(this, "Debes ingresar el usuario y el password para continuar", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Iniciar_Session
        //DESCRIPCIÓN: inicia Session el usuario que se logueo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 20-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public static Estatus_Dialogo Entrar(Form MDIPrincipal, Form Frm_Login)
        {
            Frm_Login.ShowDialog(MDIPrincipal);

            return Estatus_Login;
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Iniciar_Sesion_Usuario
        //DESCRIPCIÓN: inicia Session el usuario que se logueo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 20-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Iniciar_Sesion_Usuario()
        {
            Cls_Apl_Usuarios_Negocio Rs_Usuario_logueado = new Cls_Apl_Usuarios_Negocio();
            Cls_Ope_Turnos_Negocio Rs_Turno = new Cls_Ope_Turnos_Negocio();
            Cls_Apl_Registro_Accesos_Negocio Rs_Consultar_Acceso = new Cls_Apl_Registro_Accesos_Negocio();

            DataTable Dt_Resultado = new DataTable();
            DataTable Dt_Accesos = new DataTable();
            DataTable Dt_Turno = new DataTable();
            DateTime Dtime_Fecha_Turno = new DateTime();

            String Respuesta = "";
            int Dias = 0;

            try
            {
                Rs_Usuario_logueado.P_Usuario = Txt_Login.Text.ToString();
                Rs_Usuario_logueado.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Password.Text.ToString());
                Rs_Usuario_logueado.P_Equipo_Creo = Environment.MachineName;

                Dt_Resultado = Rs_Usuario_logueado.Consultar_Usuario();

                if (Dt_Resultado.Rows.Count > 0)
                {
                    if (Dt_Resultado.Rows[0][Apl_Usuarios.Campo_Estatus].ToString() == "ACTIVO")
                    {
                        //se verifica si no han pasado mas de tres meses de inactividad del usuario 
                        if (Deshabilitar_Usuario(Dt_Resultado.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString()))
                        {
                            Dias = Calcular_Dias_Caduca_Password(Convert.ToDateTime(Dt_Resultado.Rows[0][Apl_Usuarios.Campo_Fecha_Expira_Contrasenia]));
                            Validar_Mensaje_Dias_Contrasenia(Dias);
                            Asignar_Valores_Globales(Dt_Resultado);

                            //  Establece el estatus de Aceptar para el usuario logueado correcto
                            Estatus_Login = Estatus_Dialogo.Aceptar;

                            //  se registra el acceso del usuario
                            Registrar_Acceso();

                            //  consulta los accesos al sistema
                            Rs_Consultar_Acceso.P_Fecha_Creo = DateTime.Now.ToString("yyyy-MM-dd");
                            Dt_Accesos = Rs_Consultar_Acceso.Consultar_Registro_Accesos();

                            ////  validacion para que el turno se cerro anteriormente *************************************
                            //Rs_Turno.P_Estatus = "ABIERTO";
                            //Dt_Turno = Rs_Turno.Consultar_Turnos();

                            //if (Dt_Turno != null && Dt_Turno.Rows.Count > 0)
                            //{
                            //    foreach (DataRow Registro in Dt_Turno.Rows)
                            //    {
                            //        Dtime_Fecha_Turno = Convert.ToDateTime(Registro["Hora_Inicio"].ToString());
                            //    }

                            //    //  comparamos la fecha actual contra la fecha del turno
                            //    if (Dtime_Fecha_Turno.ToString("dd/MM/yyyy") != DateTime.Now.ToString("dd/MM/yyyy"))
                            //    {
                            //        //  si es distinta se procedara a cerrar el turno
                            //        Rs_Turno.P_Fecha_Hora_Cierre = DateTime.Now;
                            //        //Rs_Turno.Cierre_Turno_Fuera_Fecha();

                            //        //if (Dt_Accesos.Rows.Count == 1 && Dt_Accesos != null)
                            //        //{
                            //        //    //  Se valida la conexion para el envio de la informacion al deudorcad
                            //        //    if (Validar_Conexion())
                            //        //    {
                            //        //        //  se manda la informacion pendiente
                            //        //        try
                            //        //        {
                            //        //            //Btn_Exportar_Click(null, null);
                            //        //        }
                            //        //        catch (Exception x)
                            //        //        {
                            //        //        }

                            //        //    }// fin de la validacion de conexcion

                            //        //}// fin del if de registros de accesos

                            //    }// fin de la validacion de la fecha
                            
                            //}// fin de la validacion de los turnos


                            //  Cierra la ventana de login ****************************************************
                            this.Dispose();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show(this, "El usuario ha caducado, favor de comunicarse con su administrador del sistema para poder acceder.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "El usuario ha caducado, favor de comunicarse con su administrador del sistema para poder acceder.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Respuesta = Registrar_Intentos(Txt_Login.Text.ToString());
                    if (Respuesta == "ULTIMA")
                    {
                        MessageBox.Show(this, "Si fallas una vez más se bloqueara el usuario.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (Respuesta == "BLOKEADO")
                        {
                            MessageBox.Show(this, "El Usuario se ha bloqueado por intentos fallidos.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show(this, "El Usuario o Contraseña no son los correctos por favor verifícalos.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    Txt_Login.Focus();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Iniciar_Sesion_Usuario: " + Ex.Message);
            }
        }

        #region Duedorcad
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Validar_Conexion
        ///DESCRIPCIÓN: valida que todos los campos obligatorios hayan sido llenados por el usuario
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private Boolean Validar_Conexion()
        {
            Boolean Estatus_Conexion = false; 
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros = new DataTable();
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;

            try
            {
                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                foreach (DataRow Registro in Dt_Parametros.Rows)
                {
                    StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                    StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                    StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                    StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                    StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                    StrConexion += "OPTION=3";
                }

                try
                {
                    //Obj_Conexion = new MySqlConnection(StrConexion);
                    //Obj_Conexion.Open();
                    //Obj_Conexion.Close();
                    ///////////////////////////////////////////////////

                    using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))

                    using (OdbcCommand Cmd = new OdbcCommand())
                    {
                        MyConnection.Open();
                        MyConnection.Close();
                    }


                    Estatus_Conexion = true;
                }
                catch (Exception es)
                {
                    Estatus_Conexion = false;
                }   
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Estatus_Conexion;
        }
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Exportar_Click
        ///DESCRIPCIÓN: Exporta la informacion de las ventas
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DataTable Dt_Parametros = new DataTable();
            DataTable Dt_Ventas_Dia = new DataTable();
            DataTable Dt_Cambios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Lista = new DataTable();
            DataTable Dt_Pendientes = new DataTable();
            DateTime Fecha;
            try
            {

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
                Dt_Pendientes = Obj_Enviar_Ventas_Dia.Consultar_Historico();

                foreach (DataRow Registro in Dt_Pendientes.Rows)
                {
                    DateTime.TryParse(Registro[Ope_Historico_Exportacion.Campo_Fecha].ToString(), out Fecha);
                    Obj_Enviar_Ventas_Dia.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                    Dt_Ventas_Dia = Obj_Enviar_Ventas_Dia.Consultar_Tabla_Adeudos();

                    Dt_Cambios_Padron = Obj_Enviar_Ventas_Dia.Consultar_Cambios_Padron();
                    Dt_Nuevos_Usuarios_Padron = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Padron();
                    Dt_Nuevos_Usuarios_Lista = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Listadeudor();

                    //  se pasan los valores al turno 
                    Obj_Enviar_Ventas_Dia.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                    Obj_Enviar_Ventas_Dia.P_Estatus = true;
                    Obj_Enviar_Ventas_Dia.P_Dt_Ventas_Dia = Dt_Ventas_Dia;
                    Obj_Enviar_Ventas_Dia.P_Dt_Parametros = Dt_Parametros;
                    Obj_Enviar_Ventas_Dia.P_Dt_Padron_Nuevos = Dt_Nuevos_Usuarios_Padron;
                    Obj_Enviar_Ventas_Dia.P_Dt_Padron_Actualizacion = Dt_Cambios_Padron;
                    Obj_Enviar_Ventas_Dia.P_Dt_Listdeudor_Nuevos = Dt_Nuevos_Usuarios_Lista;
                    Obj_Enviar_Ventas_Dia.Enviar_Ventas_Dia();

                    //  se actualiza el historico
                    Obj_Enviar_Ventas_Dia.P_No_Turno = "Proceo Exportacion " + MDI_Frm_Apl_Principal.Nombre_Usuario + DateTime.Now.ToString();
                    Obj_Enviar_Ventas_Dia.Actualizar_Historico();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Btn_Exportar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Deshabilitar_Usuario
        //DESCRIPCIÓN:
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 28-Febrero-2013 04:33 p.m.
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private Boolean Deshabilitar_Usuario(String Usuario_ID)
        {
            Cls_Apl_Usuarios_Negocio Rs_Usuario_Estatus = new Cls_Apl_Usuarios_Negocio();
            DataTable Dt_Resultado_Consulta = new DataTable();
            Boolean Activo=true;
            try
            {
                int Dias;
                DateTimePicker Fecha_Ultimo_Acceso = new DateTimePicker();
                DateTimePicker Fecha_Actual = new DateTimePicker();
                Rs_Usuario_Estatus.P_Usuario_Id = Usuario_ID;
                Dt_Resultado_Consulta=Rs_Usuario_Estatus.Consultar_Usuario();
                if (!String.IsNullOrEmpty(Dt_Resultado_Consulta.Rows[0][Apl_Usuarios.Campo_Fecha_Ultimo_Acceso].ToString()))
                {
                    Fecha_Ultimo_Acceso.Value = Convert.ToDateTime(Dt_Resultado_Consulta.Rows[0][Apl_Usuarios.Campo_Fecha_Ultimo_Acceso].ToString());
                }
                else
                {
                    Fecha_Ultimo_Acceso.Value = Convert.ToDateTime(Dt_Resultado_Consulta.Rows[0][Apl_Usuarios.Campo_Fecha_Creo].ToString());
                }
                Fecha_Actual.Value = DateTime.Now;
                Dias = (Fecha_Actual.Value - Fecha_Ultimo_Acceso.Value).Days;
                if (Dias >= 365)
                {
                    Cls_Apl_Usuarios_Negocio Rs_Modifica_apl_Cat_Usuarios = new Cls_Apl_Usuarios_Negocio();
                    Rs_Modifica_apl_Cat_Usuarios.P_Estatus = "INACTIVO";
                    Rs_Modifica_apl_Cat_Usuarios.P_Usuario_Id = Usuario_ID;
                    Rs_Modifica_apl_Cat_Usuarios.Modificar_Usuario();
                    Activo = false;
                }
                else
                {
                    Activo = true;
                }
            }catch(Exception E){
                MessageBox.Show(this, E.ToString(), "Erorr - Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Activo;
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Registrar_Acceso
        //DESCRIPCIÓN:
        //PARÁMETROS :
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 25-Febrero-2013 04:33 p.m.
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public static void Registrar_Acceso()
        {
            Cls_Apl_Registro_Accesos_Negocio Rs_Alta_Acceso = new Cls_Apl_Registro_Accesos_Negocio();
            Cls_Apl_Usuarios_Negocio Rs_Actualiza_Usuario = new Cls_Apl_Usuarios_Negocio();

            try
            {
                Rs_Alta_Acceso.P_Usuario_Id = MDI_Frm_Apl_Principal.Usuario_ID;
                Rs_Alta_Acceso.P_Tipo = "ACCESO"; //    tipos: ACCESO, SALIDA
                Rs_Alta_Acceso.P_Equipo_Creo = Environment.MachineName;
                Rs_Alta_Acceso.Alta_Registro_Accesos();
                //registra el ultimo acceso en la tabla de usuario
                Rs_Alta_Acceso.P_Usuario_Id = MDI_Frm_Apl_Principal.Usuario_ID;
                Rs_Alta_Acceso.Registro_Acceso();
                //Actualiza los intentos de acceso del usuario
                Rs_Actualiza_Usuario.P_Usuario_Id = MDI_Frm_Apl_Principal.Usuario_ID;
                Rs_Actualiza_Usuario.P_No_Intentos_Acceso = "0";
                Rs_Actualiza_Usuario.Modificar_Usuario();
            }
            catch(Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Registrar_Intentos
        //DESCRIPCIÓN:
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 28-Febrero-2013 04:33 p.m.
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public String Registrar_Intentos(String Usuario)
        {
            Cls_Apl_Usuarios_Negocio Rs_Consulta_Usuaio = new Cls_Apl_Usuarios_Negocio();
            DataTable Dt_Fecha_Ultimo_Intento = new DataTable();
            DateTime Fecha_Actual = DateTime.Today;
            DateTime Fecha_Ultimo_Intento;
            TimeSpan Dia_Intento;
            String  Respuesta="NINGUNO";
            Int16 Intentos = 0;
            Int16 Dias = 0;
            try
            {
                Rs_Consulta_Usuaio.P_Usuario = Usuario;
                Dt_Fecha_Ultimo_Intento = Rs_Consulta_Usuaio.Consultar_Usuario();
                if (Dt_Fecha_Ultimo_Intento.Rows.Count > 0)
                {
                    if (Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Estatus].ToString() == "ACTIVO")
                    {
                        if (!String.IsNullOrEmpty(Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Fecha_Intento_Acceso].ToString()))
                        {
                            Fecha_Ultimo_Intento = Convert.ToDateTime(String.Format("{0:MMM/dd/yyyy}", Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Fecha_Intento_Acceso].ToString()));
                        }
                        else
                        {
                            Fecha_Ultimo_Intento = DateTime.Today;
                        }
                        Dia_Intento = (Fecha_Actual - Fecha_Ultimo_Intento);
                        Dias = Convert.ToInt16(Dia_Intento.Days);
                        if (Dias == 0)
                        {
                            if (!String.IsNullOrEmpty(Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_No_Intentos_Acceso].ToString()))
                            {
                                Intentos = Convert.ToInt16(Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_No_Intentos_Acceso].ToString());
                            }
                        }
                        Intentos ++;
                        if (Intentos > 3)
                        {
                            Rs_Consulta_Usuaio.P_Usuario = "";
                            Rs_Consulta_Usuaio.P_Usuario_Id = Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
                            Rs_Consulta_Usuaio.P_No_Intentos_Acceso = "0";
                            Rs_Consulta_Usuaio.P_Fecha_Ultimo_Intento = DateTime.Today;
                            Rs_Consulta_Usuaio.P_Estatus = "BLOQUEADO";
                            Rs_Consulta_Usuaio.Modificar_Usuario();
                        }
                        else
                        {
                            Rs_Consulta_Usuaio.P_Usuario = "";
                            Rs_Consulta_Usuaio.P_Usuario_Id = Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
                            Rs_Consulta_Usuaio.P_No_Intentos_Acceso = Convert.ToString(Intentos);
                            Rs_Consulta_Usuaio.P_Fecha_Ultimo_Intento =DateTime.Today;
                            Rs_Consulta_Usuaio.Modificar_Usuario();
                        }
                        if(Intentos==3){
                            Respuesta="ULTIMA";
                        }
                    }
                    else
                    {
                        Respuesta="BLOKEADO";
                    }
                }

            }
            catch(Exception E)
            {
                MessageBox.Show(E.ToString());
            }
            return Respuesta;
        }

        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Calcular_Dias_Caduca_Password
        //DESCRIPCIÓN: Calculara los dias que tiene para que expire la contraseña
        //PARÁMETROS :
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 26-Febrero-2013 09:37 a.m.
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public static int Calcular_Dias_Caduca_Password(DateTime Fecha_Caducidad)
        {
            DateTime Fecha_Actual = DateTime.Today;
            TimeSpan Dias_Caduca_Password;
            int Dias = 0;

            Dias_Caduca_Password = (Fecha_Caducidad - Fecha_Actual);
            Dias = Dias_Caduca_Password.Days;

            return Dias;
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Validar_Mensaje_Dias_Contrasenia
        //DESCRIPCIÓN: valida que mensaje mostrar al usuario con respecto a su fecha
        //             de expiracion de contraseña
        //PARÁMETROS :
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 26-Febrero-2013 09:37 a.m.
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public static void Validar_Mensaje_Dias_Contrasenia(int Dias)
        {
            if (Dias <= 6)
            {
                MessageBox.Show(null, "Su password está por caducar dentro de " + Dias.ToString() + " días.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Dias == 0)
            {
                MessageBox.Show(null, "Hoy es último día para que renueve su password con su administrador del sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Registrar_Salida
        //DESCRIPCIÓN:
        //PARÁMETROS :
        //CREO       : Hugo Enrique Ramírez Aguilera
        //FECHA_CREO : 25-Febrero-2013 04:33 p.m.
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public static void Registrar_Salida()
        {
            Cls_Apl_Registro_Accesos_Negocio Rs_Alta_Acceso = new Cls_Apl_Registro_Accesos_Negocio();
            Rs_Alta_Acceso.P_Usuario_Id = MDI_Frm_Apl_Principal.Usuario_ID;
            Rs_Alta_Acceso.P_Tipo = "SALIDA"; //    tipos: ACCESO, SALIDA
            Rs_Alta_Acceso.P_Equipo_Creo = Environment.MachineName;
            Rs_Alta_Acceso.Alta_Registro_Accesos();
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Cuentas_Caducar
        //DESCRIPCIÓN: Cambia el estatus de activo a inactivo a cuentas que caducaron en el
        //             día
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 20-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public static void Cuentas_Caducas()
        {
            Cls_Apl_Usuarios_Negocio Rs_Modifica_apl_Cat_Usuarios = new Cls_Apl_Usuarios_Negocio();
            try
            {
                Rs_Modifica_apl_Cat_Usuarios.P_Estatus = "INACTIVO";
                Rs_Modifica_apl_Cat_Usuarios.P_Fecha_Expira_Contrasenia = DateTime.Now;//String.Format("{0:dd/MM/yyyy}", DateTime.Now);
                Rs_Modifica_apl_Cat_Usuarios.Modificar_Usuario_Activos();
            }
            catch (Exception Ex)
            {
                throw new Exception("Cuentas_Caducas: " + Ex.Message);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Asignar_Valores_Globales
        //DESCRIPCIÓN: inicia Session el usuario que se logueo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 20-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Asignar_Valores_Globales(DataTable Dt_Resultado)
        {
            String HostName = Dns.GetHostName();
            MDI_Frm_Apl_Principal.Nombre_Usuario = Dt_Resultado.Rows[0][Apl_Usuarios.Campo_Nombre_Usuario].ToString();
            MDI_Frm_Apl_Principal.Usuario_ID = Dt_Resultado.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
            MDI_Frm_Apl_Principal.Rol_ID = Dt_Resultado.Rows[0][Apl_Usuarios.Campo_Rol_Id].ToString();
            MDI_Frm_Apl_Principal.Ip = Dns.GetHostEntry(HostName).AddressList[0].ToString();
            MDI_Frm_Apl_Principal.Equipo = Dns.GetHostEntry(HostName).HostName.ToString();
            MDI_Frm_Apl_Principal.Caja_ID = Dt_Resultado.Rows[0]["Caja_Equipo"].ToString();
            MDI_Frm_Apl_Principal.Serie_Caja = Dt_Resultado.Rows[0]["Serie_Caja"].ToString();
            MDI_Frm_Apl_Principal.Nombre_Login = Dt_Resultado.Rows[0][Apl_Usuarios.Campo_Usuario].ToString();
            MDI_Frm_Apl_Principal.Numero_Caja = Dt_Resultado.Rows[0]["Numero_Caja"].ToString();

            //  consultar el numero de caja
            Cls_Cat_Cajas_Negocio P_Cajas = new Cls_Cat_Cajas_Negocio(); // Variable utilizada para obtener la informacion de las cajas registradas en la base de datos
            DataTable Dt_Caja = new DataTable();

            P_Cajas.P_Caja_ID = MDI_Frm_Apl_Principal.Caja_ID;
            Dt_Caja = P_Cajas.Consultar_Caja();

            foreach (DataRow Registro in Dt_Caja.Rows)
            {
                MDI_Frm_Apl_Principal.No_Caja = Registro[Cat_Cajas.Campo_Numero_Caja].ToString();
            }
        }
        #endregion Metodos Generales
        #region Eventos
        #region Botones
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Iniciar_Click
        //DESCRIPCIÓN: inicia Session el usuario que se logueo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 20-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Iniciar_Click(object sender, EventArgs e)
        {
            try
            {
                Iniciar_Session();
            }
            catch (Exception Ex)
            {
                throw new Exception("Btn_Iniciar_Click: " + Ex.Message);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
        //DESCRIPCIÓN:Saca de la pantalla
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 21-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            //Establece el estatus de cancelar
            Estatus_Login = Estatus_Dialogo.Cancelar;
            this.Dispose();
            this.Close();
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Link_Recuperar_LinkClicked
        //DESCRIPCIÓN:Abrir la ventana de recuperacion
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 01-marzo-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Link_Recuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_Apl_Recuperar_Contrasenia Frm_Apl_Recuperar_Contrasenia_Mdi;
            Frm_Apl_Recuperar_Contrasenia_Mdi = new Frm_Apl_Recuperar_Contrasenia();
            Frm_Apl_Recuperar_Contrasenia_Mdi.MdiParent = this.MdiParent;
            Frm_Apl_Recuperar_Contrasenia_Mdi.Show();
        }
        #endregion Botones
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Validating
        //DESCRIPCIÓN:Valida que el login que no sea nulo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
        }
        #endregion Eventos
    }
}