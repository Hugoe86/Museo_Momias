using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ERP_BASE.Properties;
using Erp_Apl_Parametros.Negocio;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Validador;
using Erp.Seguridad;
using Erp_Apl_Roles.Negocio;
using ERP_BASE.App_Code.Negocio.Catalogos;
using System.Globalization;


namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Apl_Parametros : Form
    {
        #region "Variables Globales"

        Validador_Generico Validador;
        String Operacion_PinPad;

        #endregion

        #region "Load"

        public Frm_Apl_Parametros()
        {
            InitializeComponent();
            Validador = new Validador_Generico(Error_Provider);
            Error_Provider.Clear();
        }

        private void Frm_Apl_Parametros_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Parametros", this);
            Consultar();
        }

        #endregion

        #region "Validaciones"

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Alfanumerico_Extendido_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres Alfanuméricos y algunos caracteres 
        ///               especiales.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Alfanumerico_Extendido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Email_Validating
        ///DESCRIPCIÓN  : Valida que el email este escrito correctamente.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Email_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Email(e, (TextBox)sender, true);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Descuento_Validating
        ///DESCRIPCIÓN  : Valida que se escriba correctamente un campo de tipo moneda(flotante).
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Requerido_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Numerico_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres numéricos.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Numerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }

        #endregion

        #region "Acciones"

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar
        ///DESCRIPCIÓN  : Carga los parametros del sistema en los textbox
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 12/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Consultar()
        {
            DataTable Dt_Resultado = new DataTable();
            DataTable Dt_Productos = new DataTable();
            Cls_Apl_Roles_Negocio Rs_Roles = new Cls_Apl_Roles_Negocio();
            try
            {

                /*  se consultan los productos y se cargan al combo  */
                Cls_Cat_Productos_Negocio Rs_Consulta_Productos = new Cls_Cat_Productos_Negocio();
                Rs_Consulta_Productos.P_Estatus = "ACTIVO";
                Dt_Productos = Rs_Consulta_Productos.Consultar_Producto();
                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Producto_Id_Web, Dt_Productos, Cat_Productos.Campo_Nombre,Cat_Productos.Campo_Producto_Id);


                //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                String Parametro_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Parametros.Tabla_Cat_Parametros, Cat_Parametros.Campo_Parametro_ID, "", 5);

                //  se carga la informacion de los roles --------------------------------------------------------------------------------------
                Rs_Roles.P_Estatus = "ACTIVO";
                Dt_Resultado = Rs_Roles.Consultar_Roles();
                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Rol, Dt_Resultado, Apl_Roles.Campo_Nombre, Apl_Roles.Campo_Rol_Id);
                //  ---------------------------------------------------------------------------------------------------------------------------

                if (Int16.Parse(Parametro_Id) > 1)
                {
                    Btn_Nuevo.Enabled = false;
                    Btn_Modificar.Enabled = true;

                    Parametro_Id = "00001";
                    Consulta_Parametros.P_Parametro_Id = Parametro_Id;
                    DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                    Cmb_Rol.SelectedValue = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Rol_Id].ToString();
                    Lbl_Id.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Parametro_ID].ToString();
                    Txt_Dias_Vigencia.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Dias_Vigencia].ToString();
                    Txt_Directorio_Compartido.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Directorio_Compartido].ToString();
                    Txt_Encabezado.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Encabezado_Recibo].ToString();
                    Txt_Mensaje_Dia.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Mensaje_Dia_Recibo].ToString();
                    Txt_Correo.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Email].ToString();
                    Txt_Contrasenia.Text = Cls_Seguridad.Desencriptar(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Contrasenia].ToString());
                    Txt_Host.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Host_Email].ToString();
                    Txt_Puerto.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Puerto].ToString();
                    Txt_Mensaje_Sistema.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Mensaje_Sistema].ToString();
                    Txt_Tope_Recoleccion.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Tope_Recoleccion].ToString();
                    Txt_Mensaje_Ticket.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Mensaje_Ticket].ToString();
                    Txt_Porcentaje_Faltante_Excedente.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Porcentaje_Faltante_Excedente].ToString();
                    
                    //  servidor que almacenara las ventas del dia
                    Txt_Ip_A_Enviar_Ventas.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString();
                    Txt_Base_Datos_A_Enviar_Ventas.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString();
                    Txt_Usuario_A_Enviar_Ventas.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString();
                    Txt_Password_A_Enviar_Ventas.Text = Cls_Seguridad.Desencriptar(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString());  

                    //  duedorcad
                    Txt_Cuenta_Museo.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Cuenta_Museo].ToString();
                    Txt_Tipo_Deudorcad.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                    Txt_Lista_Deudorcad.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                    Txt_Clave_Venta_Deudorcad.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Clave_Venta_Deudorcad].ToString();
                    Txt_Clave_Sobrante_Deudorcad.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Clave_Sobrante_Deudorcad].ToString();
                    Txt_Clave_Venta_Individual_DeudorCad.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Clave_Venta_Individual_Deudorcad].ToString();
                    Txt_Clave_Internet.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Clave_Venta_Internet].ToString();
                    
                    if (Dt_Consulta.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                    {
                        Rbt_Version_4.Checked = true;
                    }
                    else
                    {
                        Rbt_Version_5.Checked= true;
                    }

                    //  seccion web
                    Cmb_Producto_Id_Web.SelectedValue = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Producto_Id_Web].ToString();
                    Txt_Leyenda_WEB.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Leyenda].ToString();
                    Dta_Vigencia_WEB.Text= Dt_Consulta.Rows[0][Cat_Parametros.Campo_Vigencia_Web].ToString();

                    //seccion pinpad
                    Txt_ID_Afiliacion.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Afiliacion_PinPad].ToString();
                    Txt_Usuario_Banco.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Usuario_PinPad].ToString();
                    Txt_Contraseña_Banco.Text = Cls_Seguridad.Desencriptar(Dt_Consulta.Rows[0][Cat_Parametros.Campo_Contrasenia_PinPad].ToString());
                    Txt_Banorte_Url.Text = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Banorte_Url].ToString();

                    Operacion_PinPad = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Operacion_PinPad].ToString();

                    switch (Operacion_PinPad)
                    {
                        case "PRD":
                            Cmb_Operacion_Banco.SelectedIndex = 0;
                            break;
                        case "AUT":
                            Cmb_Operacion_Banco.SelectedIndex = 1;
                            break;
                        case "DEC":
                            Cmb_Operacion_Banco.SelectedIndex = 2;
                            break;
                        case "RND":
                            Cmb_Operacion_Banco.SelectedIndex = 3;
                            break;
                        default:
                            Cmb_Operacion_Banco.SelectedIndex = 0;
                            break;
                    } 
                }
                else
                {
                    Btn_Nuevo.Enabled = true;
                    Btn_Modificar.Enabled = false;
                 
                    //Dtp_Fecha_Dias_Inicio.Enabled = false;
                    //Dtp_Fecha_Dias_Fin.Enabled = false;
                    Txt_Dias_Vigencia.Text = "";
                    Txt_Directorio_Compartido.Text = "";
                    Txt_Encabezado.Text = "";
                    Txt_Mensaje_Dia.Text = "";
                    Txt_Correo.Text = "";
                    Txt_Contrasenia.Text = "";
                    Txt_Host.Text = "";
                    Txt_Puerto.Text = "";
                    Txt_Mensaje_Sistema.Text = "";
                    Txt_Tope_Recoleccion.Text = "";
                    Lbl_Id.Text = "";
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Consultar Parametros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Alta
        ///DESCRIPCIÓN  : Ingresa los datos de parametros del sistema.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 12/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private bool Alta()
        {
            int Dias_Vigencia;
            try
            {
                int.TryParse(Txt_Dias_Vigencia.Text.Trim(), out Dias_Vigencia);

                Cls_Apl_Parametros_Negocio Nuevo_Parametro = new Cls_Apl_Parametros_Negocio();
                Nuevo_Parametro.P_Dias_Vigencia = Dias_Vigencia;
                Nuevo_Parametro.P_Directorio_Compartido = Txt_Directorio_Compartido.Text;
                Nuevo_Parametro.P_Encabezado_Recibo = Txt_Encabezado.Text;
                Nuevo_Parametro.P_Mensaje_Dia_Recibo = Txt_Mensaje_Dia.Text;
                Nuevo_Parametro.P_Email = Txt_Correo.Text;
                Nuevo_Parametro.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Contrasenia.Text);
                Nuevo_Parametro.P_Host_Email = Txt_Host.Text;
                Nuevo_Parametro.P_Puerto = Txt_Puerto.Text;
                Nuevo_Parametro.P_Mensaje_Sistema = Txt_Mensaje_Sistema.Text;
                Nuevo_Parametro.P_Tope_Recoleccion = Txt_Tope_Recoleccion.Text;
                Nuevo_Parametro.P_Mensaje_Ticket = Txt_Mensaje_Ticket.Text;
                Nuevo_Parametro.P_Rol_Administrador_Id = Cmb_Rol.SelectedValue.ToString();
                Nuevo_Parametro.P_Porcentaje_Faltante = Txt_Porcentaje_Faltante_Excedente.Text;
                Nuevo_Parametro.P_Leyenda_WEB = Txt_Leyenda_WEB.Text; //+" Vigencia valida hasta: " + Dta_Vigencia_WEB.Value.Date.ToString("MM/dd/yy"); 
                Nuevo_Parametro.P_Vigencia_WEB = Dta_Vigencia_WEB.Value;
                Nuevo_Parametro.P_Afiliacion_PinPad = Txt_ID_Afiliacion.Text;
                Nuevo_Parametro.P_Usuario_PinPad = Txt_Usuario_Banco.Text;
                Nuevo_Parametro.P_Contrasenia_PinPad = Cls_Seguridad.Encriptar(Txt_Contraseña_Banco.Text);

                if (Rbt_Version_4.Checked == true)
                {
                    Nuevo_Parametro.P_Version_Bd = "4";
                }
                else
                {
                    Nuevo_Parametro.P_Version_Bd = "5";
                }


                Operacion_PinPad = "AUT";

                switch (Cmb_Operacion_Banco.SelectedValue.ToString())
                {
                    case "Producción":
                        Operacion_PinPad = "PRD";
                        break;
                    case "Aprobado (Pruebas)":
                        Operacion_PinPad = "AUT";
                        break;
                    case "Declinado (Pruebas)":
                        Operacion_PinPad = "DEC";
                        break;
                    case "Aleatorio (Pruebas)":
                        Operacion_PinPad = "RND";
                        break;
                    default:
                        Operacion_PinPad = "AUT";
                        break;
                }

                Nuevo_Parametro.P_Operacion_PinPad = Operacion_PinPad;
                Nuevo_Parametro.P_Banorte_URL = Txt_Banorte_Url.Text;
                Nuevo_Parametro.Alta_Parametros();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Alta Parámetro Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Modificar
        ///DESCRIPCIÓN  : Modifica los parametros del sistema.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 12/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private bool Modificar()
        {
            int Dias_Vigencia;
            String Directorio = "";
            char[] Valor;
            char Valor_Nuevo = '/';

            try
            {
                int.TryParse(Txt_Dias_Vigencia.Text.Trim(), out Dias_Vigencia);

                //  se modifica la ruta de la carpeta compartida.*******************************
                //  se cambia el valor de \\ por el de /, ya que sino genera la carpeta en bin y permite eliminar las imagenes
                Valor = Txt_Directorio_Compartido.Text.ToCharArray();

                for (int Cont_For = 0; Cont_For < Valor.Length; Cont_For++)
                {
                    if (Valor[Cont_For].ToString() == "\\")
                    {
                        Directorio += Valor_Nuevo;
                    }
                    else
                    {
                        Directorio += Valor[Cont_For].ToString();
                    }
                }

                Cls_Apl_Parametros_Negocio Modifica_Parametro = new Cls_Apl_Parametros_Negocio();
                Modifica_Parametro.P_Dias_Vigencia = Dias_Vigencia;
                Modifica_Parametro.P_Directorio_Compartido = Directorio;
                Modifica_Parametro.P_Encabezado_Recibo = Txt_Encabezado.Text;
                Modifica_Parametro.P_Mensaje_Dia_Recibo = Txt_Mensaje_Dia.Text;
                Modifica_Parametro.P_Parametro_Id = Lbl_Id.Text;
                Modifica_Parametro.P_Email = Txt_Correo.Text;
                Modifica_Parametro.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Contrasenia.Text);
                Modifica_Parametro.P_Host_Email = Txt_Host.Text;
                Modifica_Parametro.P_Puerto = Txt_Puerto.Text;
                Modifica_Parametro.P_Mensaje_Sistema = Txt_Mensaje_Sistema.Text;
                Modifica_Parametro.P_Tope_Recoleccion = Txt_Tope_Recoleccion.Text;
                Modifica_Parametro.P_Mensaje_Ticket = Txt_Mensaje_Ticket.Text;

                //  Informacion del servidor que almacenara las ventas del dia
                Modifica_Parametro.P_Ip_A_Enviar_Ventas = Txt_Ip_A_Enviar_Ventas.Text;
                Modifica_Parametro.P_Base_Datos_A_Enviar_Ventas = Txt_Base_Datos_A_Enviar_Ventas.Text;
                Modifica_Parametro.P_Usuario_A_Enviar_Ventas = Txt_Usuario_A_Enviar_Ventas.Text;
                Modifica_Parametro.P_Password_A_Enviar_Ventas =  Cls_Seguridad.Encriptar(Txt_Password_A_Enviar_Ventas.Text.ToString());

                //web
                if (Cmb_Producto_Id_Web.SelectedIndex > 0)
                    Modifica_Parametro.P_Producto_Id_Web = Cmb_Producto_Id_Web.SelectedValue.ToString();
                else
                    Modifica_Parametro.P_Producto_Id_Web = "";
                Modifica_Parametro.P_Leyenda_WEB = Txt_Leyenda_WEB.Text;// +" Vigencia valida hasta: " + Dta_Vigencia_WEB.Value.Date.ToString("MM/dd/yy"); 
                                                  
               
                Modifica_Parametro.P_Vigencia_WEB = Dta_Vigencia_WEB.Value;

                if (Cmb_Rol.SelectedIndex > 0)
                    Modifica_Parametro.P_Rol_Administrador_Id = Cmb_Rol.SelectedValue.ToString();
                else
                    Modifica_Parametro.P_Rol_Administrador_Id = "";

                if (!String.IsNullOrEmpty(Txt_Porcentaje_Faltante_Excedente.Text))
                    Modifica_Parametro.P_Porcentaje_Faltante = Txt_Porcentaje_Faltante_Excedente.Text;
                else
                    Modifica_Parametro.P_Porcentaje_Faltante = "0";

                //  deudorcad
                Modifica_Parametro.P_Cuenta_Momias = Txt_Cuenta_Museo.Text;
                Modifica_Parametro.P_Tipo_Deudorcad = Txt_Tipo_Deudorcad.Text;
                Modifica_Parametro.P_Lista_Deudorcad = Txt_Lista_Deudorcad.Text;
                Modifica_Parametro.P_Clave_Venta_Deudorcad = Txt_Clave_Venta_Deudorcad.Text;
                Modifica_Parametro.P_Clave_Sobrante_Deudorcad = Txt_Clave_Sobrante_Deudorcad.Text;
                Modifica_Parametro.P_Clave_Venta_Individual_Deudorcad = Txt_Clave_Venta_Individual_DeudorCad.Text;
                Modifica_Parametro.P_Clave_Internet = Txt_Clave_Internet.Text;
                if (Rbt_Version_4.Checked == true)
                {
                    Modifica_Parametro.P_Version_Bd = "4";
                }
                else
                {
                    Modifica_Parametro.P_Version_Bd = "5";
                }


                //PinPad
                Modifica_Parametro.P_Afiliacion_PinPad = Txt_ID_Afiliacion.Text;
                Modifica_Parametro.P_Usuario_PinPad = Txt_Usuario_Banco.Text;
                Modifica_Parametro.P_Contrasenia_PinPad = Cls_Seguridad.Encriptar(Txt_Contraseña_Banco.Text);
                Operacion_PinPad = "AUT";

                switch (Cmb_Operacion_Banco.Text)
                {
                    case "Producción":
                        Operacion_PinPad = "PRD";
                        break;
                    case "Aprobado (Pruebas)":
                        Operacion_PinPad = "AUT";
                        break;
                    case "Declinado (Pruebas)":
                        Operacion_PinPad = "DEC";
                        break;
                    case "Aleatorio (Pruebas)":
                        Operacion_PinPad = "RND";
                        break;
                    default:
                        Operacion_PinPad = "AUT";
                        break;
                }

                Modifica_Parametro.P_Operacion_PinPad = Operacion_PinPad;
                Modifica_Parametro.P_Banorte_URL = Txt_Banorte_Url.Text;

           

                //  se raliza la modificacion
                Modifica_Parametro.Modificar_Parametros();
                
                Txt_RutaImagen.Text = @"\Imagenes\Fondo";
                Txt_Imagen_Acceso.Text = @"\Imagenes\Acceso";
                Txt_Image_Logotipo.Text = @"\Imagenes\Logo";
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Modificar Parámetro Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Eliminar
        ///DESCRIPCIÓN  : Elimina por completo, el registro de los parametros del sistema.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 12/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private bool Eliminar()
        {
            try
            {
                Cls_Apl_Parametros_Negocio Elimina_Parametro = new Cls_Apl_Parametros_Negocio();
                Elimina_Parametro.P_Parametro_Id = Lbl_Id.Text;
                Elimina_Parametro.Eliminar_Parametros();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Eliminar Parámetro Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Guardar_Archivos
        ///DESCRIPCIÓN  : Carga las imagenes de fondo del MDI
        ///PARAMENTROS  :
        ///CREO         : Alejandro Leyva Alvarado
        ///FECHA_CREO   : 9/Abril/2013
        ///MODIFICÓ: Olimpo Alberto Cruz Amaya  
        ///FECHA_MODIFICÓ: 23/Feb/2015
        ///CAUSA_MODIFICACIÓN: Se agrego la posibilidad de cargar una imagen para los boletos de acceso
        ///*******************************************************************************
        private void Guardar_Archivos(String Ruta,String Tipo)
        {
            try
            {

                string fileName = "";
                string sourcePath = Ruta;
                string targetPath = "";

                if (Tipo == "Fondo")
                {
                    fileName = "Fondo.jpg";
                    sourcePath = Ruta;
                    targetPath = Txt_Directorio_Compartido.Text + @"\Imagenes\Fondo";
                }
                else if (Tipo == "Acceso")
                {
                    fileName = "Acceso.png";
                    sourcePath = Ruta;
                    targetPath = Txt_Directorio_Compartido.Text + @"\Imagenes\Accesos";
                }

                else if (Tipo == "Logotipo")
                {
                    fileName = "Logotipo.jpg";
                    sourcePath = Ruta;
                    targetPath = Txt_Directorio_Compartido.Text + @"\Imagenes\Logo";
                }

                else if (Tipo == "EncabezadoWEB")
                {
                    fileName = "Encabezado.png";
                    sourcePath = Ruta;
                    targetPath = Txt_Directorio_Compartido.Text + @"\Imagenes\WEB";
                }
                else if (Tipo == "BoletoWEB")
                {
                    fileName = "Boleto.png";
                    sourcePath = Ruta;
                    targetPath = Txt_Directorio_Compartido.Text + @"\Imagenes\WEB";
                }

                else if (Tipo == "PDFWEB")
                {
                    fileName = "EncabezadoPDF.png";
                    sourcePath = Ruta;
                    targetPath = Txt_Directorio_Compartido.Text + @"\Imagenes\WEB";
                }

                //string targetPath = @"C:\ERP_ESCRITORIO\ERP_BASE\Fondo"; 
                String rutaAbsolutaProcess = targetPath + @"\" + fileName;
                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.IO.File.Copy(sourceFile, destFile, true);

                // To copy all the files in one directory to another directory.
                // Get the files in the source folder. (To recursively iterate through
                // all subfolders under the current directory, see
                // "How to: Iterate Through a Directory Tree.")
                // Note: Check for target path was performed previously
                //       in this code example.
                if (System.IO.Directory.Exists(sourcePath))
                {
                    string[] files = System.IO.Directory.GetFiles(sourcePath);

                    // Copy the files and overwrite destination files if they already exist.
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    Console.WriteLine("No existe el directorio!");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, "Error al cargar la imágen\n" + Ex.ToString() , "Alta Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN: Dias_Vigencia
        /////DESCRIPCIÓN  : Proporciona los dias de vigencia en base a fechas
        /////PARAMENTROS  :
        /////CREO         : Luis Eugenio Razo Mendiola
        /////FECHA_CREO   : 17/Oct/2013
        /////MODIFICO     :
        /////FECHA_MODIFICO:
        /////CAUSA_MODIFICACIÓN:
        /////*******************************************************************************
        //private void Dias_Vigencia()
        //{
        //    DateTime Fecha_1 = Dtp_Fecha_Dias_Inicio.Value;
        //    DateTime Fecha_2 = Dtp_Fecha_Dias_Fin.Value;

        //    int NumeroDias = (Fecha_2 - Fecha_1).Days;

        //    if (NumeroDias <= 0)
        //        NumeroDias = 1;

        //    Txt_Dias_Vigencia.Text = NumeroDias.ToString();
        //}
        #endregion

        #region "Eventos"

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Nuevo_Click
        ///DESCRIPCIÓN  : Agrega los parametros del sistema.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 12/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text == "Nuevo")
            {
                Cls_Metodos_Generales.Limpia_Controles(this);
                Lbl_Id.Text = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Parametros.Tabla_Cat_Parametros, Cat_Parametros.Campo_Parametro_ID, "", 5);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Correo, true);
                Cmb_Producto_Id_Web.Enabled = true;
                Btn_Nuevo.Image = Resources.icono_actualizar;
                Btn_Nuevo.Text = "Guardar";
                Btn_Salir.Image = Resources.icono_cancelar;
                Btn_Salir.Text = "Cancelar";
                Error_Provider.Clear();
            }
            else
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (Alta())
                    {
                        Btn_Nuevo.Image = Resources.icono_nuevo;
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Salir.Image = Resources.icono_salir_2;
                        Btn_Salir.Text = "Salir";
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Correo, false);
                        Cmb_Producto_Id_Web.Enabled = false;
                        Consultar();
                        MessageBox.Show(this, "Se dio de alta correctamente los parámetros del sistema.", "Alta Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Alta Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
        ///DESCRIPCIÓN  : Modifica los parametros del sistema.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 12/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text == "Modificar")
            {
                Btn_Modificar.Image = Resources.icono_actualizar;
                Btn_Modificar.Text = "Actualizar";
                Btn_Salir.Image = Resources.icono_cancelar;
                Btn_Salir.Text = "Cancelar";
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Correo, true);
                Cmb_Producto_Id_Web.Enabled = true;
                Btn_Cargar_Imagen_Fondo.Enabled = true;
            }
            else
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (Modificar())
                    {
                        Btn_Modificar.Image = Resources.icono_modificar;
                        Btn_Modificar.Text = "Modificar";
                        Btn_Salir.Image = Resources.icono_salir_2;
                        Btn_Salir.Text = "Salir";
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Correo, false);
                        Cmb_Producto_Id_Web.Enabled = false;
                        Btn_Cargar_Imagen_Fondo.Enabled = false;
                        Consultar();
                        MessageBox.Show(this, "Se modifico correctamente los parámetros del sistema.", "Modificar Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Alta Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //private void Btn_Eliminar_Click(object sender, EventArgs e)
        //{
        //    if (Btn_Eliminar.Text == "Eliminar")
        //    {
        //        if (MessageBox.Show(this, "¿Esta seguro que desea eliminar los parámetros del sistema?.", "Eliminar Parámetros Sistema", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            if (Eliminar())
        //            {
        //                Error_Provider.Clear();
        //                Consultar();
        //                MessageBox.Show(this, "Se elimino correctamente los parámetros del sistema.", "Eliminar Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //            else
        //            {
        //                MessageBox.Show(this, "Ocurrió un erro al eliminar los parámetros del sistema.", "Error - Eliminar Parámetros Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //}

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
        ///DESCRIPCIÓN  : Cierra la ventana.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 12/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Salir.Text == "Cancelar")
            {
                Cls_Metodos_Generales.Limpia_Controles(this);
                Btn_Modificar.Image = Resources.icono_modificar;
                Btn_Modificar.Text = "Modificar";
                Btn_Nuevo.Image = Resources.icono_nuevo;
                Btn_Nuevo.Text = "Nuevo";
                Btn_Salir.Image = Resources.icono_salir_2;
                Btn_Salir.Text = "Salir";
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Correo, false);
                Cmb_Producto_Id_Web.Enabled = false;
                Error_Provider.Clear();
                Consultar();
            }
            else
            {
                this.Close();
            }
        }

      
        //private void Btn_Directorio_Click(object sender, EventArgs e)
        //{
           

        //}

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN: Dtp_Fecha_Dias_Inicio_ValueChanged
        /////DESCRIPCIÓN  : Manda llamar la funcion Dias_Vigencia y Obtiene los dias de vigencia
        /////PARAMENTROS  :
        /////CREO         : Luis Eugenio Razo Mendiola
        /////FECHA_CREO   : 17/Oct/2013
        /////MODIFICO     :
        /////FECHA_MODIFICO:
        /////CAUSA_MODIFICACIÓN:
        /////*******************************************************************************
        //private void Dtp_Fecha_Dias_Inicio_ValueChanged(object sender, EventArgs e)
        //{
        //    Dias_Vigencia();
        //}

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN: Dtp_Fecha_Dias_Inicio_ValueChanged
        /////DESCRIPCIÓN  : Manda llamar la funcion Dias_Vigencia y Obtiene los dias de vigencia
        /////PARAMENTROS  :
        /////CREO         : Luis Eugenio Razo Mendiola
        /////FECHA_CREO   : 17/Oct/2013
        /////MODIFICO     :
        /////FECHA_MODIFICO:
        /////CAUSA_MODIFICACIÓN:
        /////*******************************************************************************
        //private void Dtp_Fecha_Dias_Fin_ValueChanged(object sender, EventArgs e)
        //{
        //    Dias_Vigencia();
        //}
        

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Guardar_Archivos
        ///DESCRIPCIÓN  : Carga las imagenes del logotipo del documento de movimientos Arqueo Cierre y Recoleccion
        ///PARAMENTROS  :
        ///CREO         : Olimpo Alberto Cruz Amaya  
        ///FECHA_CREO   : 06/Marzo/2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************
        private void Btn_Imagen_Logotipo_Cierre_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo JPG|*.jpg";
            if ((file.ShowDialog() == DialogResult.OK))
            {
                Guardar_Archivos(file.FileName, "Logotipo");
            }
        }
        #endregion



        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Guardar_Archivos
        ///DESCRIPCIÓN  : Carga las imagenes del boleto de acceso
        ///PARAMENTROS  :
        ///CREO         : Olimpo Alberto Cruz Amaya  
        ///FECHA_CREO   : 23/Feb/2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************
        private void Btn_Cargar_Imagen_Accesso_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo PNG|*.png";
            if ((file.ShowDialog() == DialogResult.OK))
            {
                Guardar_Archivos(file.FileName, "Acceso");
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Guardar_Archivos
        ///DESCRIPCIÓN  : Carga las imagenes del fondo de la pantalla
        ///PARAMENTROS  :
        ///CREO         : Olimpo Alberto Cruz Amaya  
        ///FECHA_CREO   : 23/Feb/2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************

        private void Btn_Cargar_Imagen_Fondo_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo JPG|*.jpg";
            if ((file.ShowDialog() == DialogResult.OK))
            {
                Guardar_Archivos(file.FileName, "Fondo");
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Directorio_Click_1
        ///DESCRIPCIÓN  : Guarda el path de directorio
        ///PARAMENTROS  :
        ///CREO         : Luis Eugenio Razo Mendiola
        ///FECHA_CREO   : 17/Oct/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Directorio_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog Folder = new FolderBrowserDialog();
            Folder.ShowDialog();
            Txt_Directorio_Compartido.Text = Folder.SelectedPath;
        }


        private void Btn_Boleto_WEB_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo PNG|*.png";
            if ((file.ShowDialog() == DialogResult.OK))
            {
                Guardar_Archivos(file.FileName, "BoletoWEB");
            }
        }

        private void Btn_Encabezado_PDFWEB_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Archivo PNG|*.png";
            if ((file.ShowDialog() == DialogResult.OK))
            {
                Guardar_Archivos(file.FileName, "PDFWEB");
            }
        }

     

    }
}
