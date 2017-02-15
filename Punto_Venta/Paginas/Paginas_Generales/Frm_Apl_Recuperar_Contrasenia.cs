using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Validador;
using Erp.Metodos_Generales;
using Erp_Apl_Usuarios.Negocio;
using Erp.Constantes;
using Erp.Seguridad;
using Erp.Envio_Email;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Apl_Recuperar_Contrasenia : Form
    {
        Validador_Generico Validador;
        #region"Metodos Generales"
        public Frm_Apl_Recuperar_Contrasenia()
        {
            InitializeComponent();
        
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Frm_Apl_Recuperar_Contrasenia_Load
        //DESCRIPCIÓN:Metodo load
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 01-Marzo-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Frm_Apl_Recuperar_Contrasenia_Load(object sender, EventArgs e)
        {
            Txt_Correo.Text = "";
            Txt_Usuario.Text = "";
            Validador = new Validador_Generico(Erp_Recuperacion);
            Txt_Usuario.Focus();
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Actualizar_Usuario
        //DESCRIPCIÓN:Metodo load
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 01-Marzo-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private static void Actualizar_Usuario(String Usuario_ID)
        {
            Cls_Apl_Usuarios_Negocio Rs_Actualizar_Usuario= new Cls_Apl_Usuarios_Negocio();
            try
            {
                Rs_Actualizar_Usuario.P_Usuario_Id = Usuario_ID;
                Rs_Actualizar_Usuario.P_Estatus = "ACTIVO";
                Rs_Actualizar_Usuario.P_No_Intentos_Recuperar = "0";
                Rs_Actualizar_Usuario.Modificar_Usuario();
            }
            catch(Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion "MEtodos Generales"
        #region "Validaciones"
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Login_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Correo_KeyPress
        //DESCRIPCIÓN:Valida que seleccione un registro del combo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Correo_Validating
        //DESCRIPCIÓN:validacion de txt
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 01-Marzo-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Correo_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
            Validador.Validacion_Campo_Email(e, (TextBox)sender, true);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Enviar_Click
        //DESCRIPCIÓN:Evento de Enviar correo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Usuario_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
        }
        #endregion "Validaciones"
        #region"Eventos"
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Enviar_Click
        //DESCRIPCIÓN:Evento de Enviar correo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Enviar_Click(object sender, EventArgs e)
        {
            Cls_Apl_Usuarios_Negocio Rs_Usuario_Nuevo = new Cls_Apl_Usuarios_Negocio();
            DataTable Dt_Usuario = new DataTable();
            String Correo = "";
            String Password = "";
            String Mensaje = "";
            String Respuesta = "";
            if (Txt_Usuario.Text != "")
            {
                Rs_Usuario_Nuevo.P_Usuario = Txt_Usuario.Text;
                Dt_Usuario = Rs_Usuario_Nuevo.Consultar_Usuario();
                if (Dt_Usuario.Rows.Count > 0)
                {
                    if (Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Estatus].ToString() != "INACTIVO")
                    {
                        Correo = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Email].ToString().Trim();
                        if (Correo == Txt_Correo.Text.Trim())
                        {
                            Password = Cls_Seguridad.Desencriptar(Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Contrasenia].ToString().Trim());
                            Mensaje = "La contraseña del usuario es la siguiente para poder tener acceso al sistema:'" + Password + "'";
                            Cls_Enviar_Correo.Envia_Correo(Mensaje, Correo);
                            MessageBox.Show(this, "Se envió la contraseña a tu correo.", "Recuperar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Actualizar_Usuario(Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString());
                            Txt_Correo.Text = "";
                            Txt_Usuario.Text = "";
                            this.Dispose();
                            this.Close();
                        }
                        else
                        {
                            Respuesta = Registrar_Intentos(Txt_Usuario.Text.ToString());
                            if (Respuesta == "ULTIMA")
                            {
                                MessageBox.Show(this, "Si fallas una vez más se deshabilitara el usuario.", "Recuperar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (Respuesta == "INACTIVO")
                                {
                                    MessageBox.Show(this, "El Usuario se ha deshabilitado por intentos fallidos.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show(this, "No coincide el correo con el del usuario por favor verifícalo.", "Recuperar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            Txt_Usuario.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "El usuario está inactivo por favor comuníquese con el Administrador.", "Recuperar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "El usuario que proporciono no existe favor de verificarlo.", "Recuperar Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Cancelar_Click
        //DESCRIPCIÓN:Evento de Enviar correo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 01-Marzo-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        #endregion"Eventos"

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
            String Respuesta = "NINGUNO";
            Int16 Intentos = 0;
            Int16 Dias = 0;
            try
            {
                Rs_Consulta_Usuaio.P_Usuario = Usuario;
                Dt_Fecha_Ultimo_Intento = Rs_Consulta_Usuaio.Consultar_Usuario();
                if (Dt_Fecha_Ultimo_Intento.Rows.Count > 0)
                {
                    if (Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Estatus].ToString() == "BLOQUEADO")
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
                            if (!String.IsNullOrEmpty(Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_No_Intentos_Recuperar].ToString()))
                            {
                                Intentos = Convert.ToInt16(Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_No_Intentos_Recuperar].ToString());
                            }
                        }
                        Intentos++;
                        if (Intentos > 3)
                        {
                            Rs_Consulta_Usuaio.P_Usuario = "";
                            Rs_Consulta_Usuaio.P_Usuario_Id = Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
                            Rs_Consulta_Usuaio.P_No_Intentos_Recuperar = "0";
                            Rs_Consulta_Usuaio.P_Fecha_Ultimo_Intento = DateTime.Today;
                            Rs_Consulta_Usuaio.P_Estatus = "INACTIVO";
                            Rs_Consulta_Usuaio.Modificar_Usuario();
                            Respuesta = "INACTIVO";
                        }
                        else
                        {
                            Rs_Consulta_Usuaio.P_Usuario = "";
                            Rs_Consulta_Usuaio.P_Usuario_Id = Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
                            Rs_Consulta_Usuaio.P_No_Intentos_Recuperar = Convert.ToString(Intentos);
                            Rs_Consulta_Usuaio.P_Fecha_Ultimo_Intento = DateTime.Today;
                            Rs_Consulta_Usuaio.Modificar_Usuario();
                        }
                        if (Intentos == 3)
                        {
                            Respuesta = "ULTIMA";
                        }
                    }
                    else
                    {
                        if (Dt_Fecha_Ultimo_Intento.Rows[0][Apl_Usuarios.Campo_Estatus].ToString() == "ACTIVO")
                        {
                            Respuesta = "ACTIVO";
                        }
                        else
                        {
                            Respuesta = "INACTIVO";
                        }
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
            return Respuesta;
        }
       

    }
}
