using Erp.Metodos_Generales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp_Apl_Parametros.Negocio;
using Erp.Constantes;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp.Seguridad;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Padron : Form
    {

        public Boolean Estatus_Conexion = false;

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Padron
        ///DESCRIPCIÓN          : 
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        public Frm_Cat_Padron()
        {
            InitializeComponent();

            Grid_Padron.AutoGenerateColumns = false;
        }
        #region Load
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Bancos_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Padron_Load(object sender, EventArgs e)
        {
            try
            {
                Habilitar_Controles(false);

                if (Validar_Conexion())
                {
                    Estatus_Conexion = true;
                    //DataTable Dt_Consulta = Consultar_Padron();
                    //Cargar_Grid(Dt_Consulta);
                }
                else
                {
                    Estatus_Conexion = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Frm_Cat_Padron_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Metodos Generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Habilitar_Controles(Boolean Estatus)
        {
            try
            {
                Fra_Datos_Usuario.Enabled = Estatus;
                Fra_Informacion_Usuario.Enabled = Estatus;
                Fra_Domicilio.Enabled = Estatus;
                Erp_Validaciones.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Habilitar_Controles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Validar_Conexion()
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros = new DataTable();
            String StrConexion = "";

            try
            {
                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                try
                {
                    if (Dt_Parametros.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                    {
                        #region Version odbc
                        foreach (DataRow Registro in Dt_Parametros.Rows)
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
                        Estatus_Conexion = true;
                        #endregion
                    }
                    else
                    {
                        #region Version 5

                        foreach (DataRow Registro in Dt_Parametros.Rows)
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
                        Estatus_Conexion = true;

                        #endregion
                    }
                }
                catch (Exception es)
                {
                    Estatus_Conexion = false;
                    //MessageBox.Show(this, "No se logro establecer conexcion con el deudorcad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Habilitar_Controles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Estatus_Conexion;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Padron
        ///DESCRIPCIÓN          : Método para consultar el padron
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private DataTable Consultar_Padron()
        {
            Cls_Cat_Padron_Negocio Rs_Consulta = new Cls_Cat_Padron_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable Dt_Parametros = new DataTable();

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                Rs_Consulta.P_Dt_Parametros = Dt_Parametros;

                if (!String.IsNullOrEmpty(Txt_Filtro_Rfc.Text))
                    Rs_Consulta.P_Rfc = Txt_Filtro_Rfc.Text.Trim();

                if (!String.IsNullOrEmpty(Txt_Filtro_Nombre.Text))
                    Rs_Consulta.P_Nombre = Txt_Filtro_Nombre.Text;


                if (Estatus_Conexion == true)
                    Dt_Consulta = Rs_Consulta.Consultar_Padron();
                else
                    Dt_Consulta = Rs_Consulta.Consultar_Padron_Local();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consultar_Padron", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Dt_Consulta;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Grid
        ///DESCRIPCIÓN          : Método para cargar el grid del padron de usuarios
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Marzo 2015
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private DataTable Cargar_Grid(DataTable Dt_Consulta)
        {
            try
            {
                Grid_Padron.DataSource = Dt_Consulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cargar_Grid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Dt_Consulta;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Manejo_Botones_Operacion(String Tipo)
        {
            switch (Tipo)
            {
                case "Nuevo":
                    {
                        Btn_Nuevo.Text = "Dar de Alta";
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Grid_Padron.Enabled = false;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Txt_Rfc.Enabled = true;
                        break;
                    }
                case "Modificar":
                    {
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Grid_Padron.Enabled = false;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Txt_Rfc.Enabled = false;
                        break;
                    }
                case "Cancelar":
                    {
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Modificar.Text = "Modificar";
                        Btn_Eliminar.Text = "Eliminar";
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
                        Grid_Padron.Enabled = true;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Salir.Enabled = true;
                        Txt_Rfc.Enabled = true;
                        Erp_Validaciones.Clear();
                        break;
                    }
                default: break;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuario_Padron
        ///DESCRIPCIÓN          : Método que realiza la insercion del nuevo usuario.
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Marzo 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Alta_Usuario_Padron()
        {
            Cls_Cat_Padron_Negocio Rs_Alta = new Cls_Cat_Padron_Negocio();
            Boolean Alta = false; // Variable que indica si el registro en la base de datos se efectúa satisfactoriamente
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                //  se consuntal los parametros
                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    Rs_Alta.P_Tipo_Lista_Deudor = Registro[Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                    Rs_Alta.P_Lista_Deudor = Registro[Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                }

                //  se manda la informacion a la capa de negocion
                Rs_Alta.P_Dt_Parametros = Dt_Consulta;

                Rs_Alta.P_Rfc = Txt_Rfc.Text;
                Rs_Alta.P_Curp = (String.IsNullOrEmpty(Txt_Curp.Text)) ? Txt_Rfc.Text : Txt_Curp.Text;
                Rs_Alta.P_Tipo = (Cmb_Tipo.SelectedItem.ToString() == "PERSONA FISICA") ? "0" : "1";
                Rs_Alta.P_Apellido_Paterno = Txt_Apellido_Paterno.Text;
                Rs_Alta.P_Apellido_Materno = Txt_Apellido_Materno.Text;
                Rs_Alta.P_Nombre = Txt_Nombre.Text;
                Rs_Alta.P_Edonac = "0";
                Rs_Alta.P_Genero = (Cmb_Genero.SelectedItem.ToString() == "FEMENINO") ? "M" : "H";
                Rs_Alta.P_Equipo = Environment.MachineName; ;

                String Nombre_Usuario = "";

                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;

                Rs_Alta.P_Usuario = Nombre_Usuario;

                //  domicilio
                Rs_Alta.P_Calle = Txt_Calle.Text;
                Rs_Alta.P_Numero_Interior = Txt_No_Interior.Text;
                Rs_Alta.P_Numero_Exterior = Txt_No_Exterior.Text;
                Rs_Alta.P_Codigo_Postal = Txt_Codigo_Postal.Text;
                Rs_Alta.P_Colonia = Txt_Colonia.Text;
                Rs_Alta.P_Municipio = Txt_Municipio.Text;
                Rs_Alta.P_Estado = Cmb_Estado.SelectedItem.ToString();

                Rs_Alta.Alta_Usuario_Padron();

                Alta = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alta de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuario_Padron
        ///DESCRIPCIÓN          : Método que realiza la insercion del nuevo usuario.
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Marzo 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Alta_Usuario_Padron_Local()
        {
            Cls_Cat_Padron_Negocio Rs_Alta = new Cls_Cat_Padron_Negocio();
            Boolean Alta = false; // Variable que indica si el registro en la base de datos se efectúa satisfactoriamente
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                //  se consuntal los parametros
                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    Rs_Alta.P_Tipo_Lista_Deudor = Registro[Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                    Rs_Alta.P_Lista_Deudor = Registro[Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                }

                //  se manda la informacion a la capa de negocion
                Rs_Alta.P_Dt_Parametros = Dt_Consulta;


                Rs_Alta.P_Rfc = Txt_Rfc.Text;
                Rs_Alta.P_Curp = (String.IsNullOrEmpty(Txt_Curp.Text)) ? Txt_Rfc.Text : Txt_Curp.Text;
                Rs_Alta.P_Tipo = (Cmb_Tipo.SelectedItem.ToString() == "PERSONA FISICA") ? "0" : "1";
                Rs_Alta.P_Apellido_Paterno = Txt_Apellido_Paterno.Text;
                Rs_Alta.P_Apellido_Materno = Txt_Apellido_Materno.Text;
                Rs_Alta.P_Nombre = Txt_Nombre.Text;
                Rs_Alta.P_Edonac = "0";
                Rs_Alta.P_Genero = (Cmb_Genero.SelectedItem.ToString() == "FEMENINO") ? "M" : "H";
                Rs_Alta.P_Equipo = Environment.MachineName; ;

                String Nombre_Usuario = "";

                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;

                Rs_Alta.P_Usuario = Nombre_Usuario;

                //  domicilio
                Rs_Alta.P_Calle = Txt_Calle.Text;
                Rs_Alta.P_Numero_Interior = Txt_No_Interior.Text;
                Rs_Alta.P_Numero_Exterior = Txt_No_Exterior.Text;
                Rs_Alta.P_Codigo_Postal = Txt_Codigo_Postal.Text;
                Rs_Alta.P_Colonia = Txt_Colonia.Text;
                Rs_Alta.P_Municipio = Txt_Municipio.Text;
                Rs_Alta.P_Estado = Cmb_Estado.SelectedItem.ToString();

                Rs_Alta.Alta_Usuario_Padron_Local();

                Alta = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alta de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }


        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificacion_Usuario_Padron
        ///DESCRIPCIÓN          : Método que realiza la actualizacion del usuario.
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Marzo 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Modificacion_Usuario_Padron()
        {
            Cls_Cat_Padron_Negocio Rs_Alta = new Cls_Cat_Padron_Negocio();
            Boolean Modificacion = false; // Variable que indica si el registro en la base de datos se efectúa satisfactoriamente
            try
            {
                Rs_Alta.P_Rfc = Txt_Rfc.Text;
                Rs_Alta.P_Curp = (String.IsNullOrEmpty(Txt_Curp.Text)) ? Txt_Rfc.Text : Txt_Curp.Text;
                Rs_Alta.P_Tipo = (Cmb_Tipo.SelectedItem.ToString() == "PERSONA FISICA") ? "0" : "1";
                Rs_Alta.P_Apellido_Paterno = Txt_Apellido_Paterno.Text;
                Rs_Alta.P_Apellido_Materno = Txt_Apellido_Materno.Text;
                Rs_Alta.P_Nombre = Txt_Nombre.Text;
                Rs_Alta.P_Genero = (Cmb_Genero.SelectedItem.ToString() == "FEMENINO") ? "M" : "H";
                Rs_Alta.P_Estatus = (Cmb_Estatus.SelectedItem.ToString() == "ACTIVO") ? "N" : "S";

                //  domicilio
                Rs_Alta.P_Calle = Txt_Calle.Text;
                Rs_Alta.P_Numero_Interior = Txt_No_Interior.Text;
                Rs_Alta.P_Numero_Exterior = Txt_No_Exterior.Text;
                Rs_Alta.P_Codigo_Postal = Txt_Codigo_Postal.Text;
                Rs_Alta.P_Colonia = Txt_Colonia.Text;
                Rs_Alta.P_Municipio = Txt_Municipio.Text;
                Rs_Alta.P_Estado = Cmb_Estado.SelectedItem.ToString();

                Rs_Alta.Modificar_Usuario_Padron();

                Modificacion = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Modificacion;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Usuario_Padron
        ///DESCRIPCIÓN          : Método que realiza la actualizacion del usuario.
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Marzo 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Eliminar_Usuario_Padron()
        {
            Cls_Cat_Padron_Negocio Rs_Eliminar = new Cls_Cat_Padron_Negocio();
            Boolean Modificacion = false; // Variable que indica si el registro en la base de datos se efectúa satisfactoriamente
            try
            {
                if (!String.IsNullOrEmpty(Txt_Rfc.Text))
                    Rs_Eliminar.P_Rfc = Txt_Rfc.Text;
                else
                    Rs_Eliminar.P_Curp = Txt_Curp.Text;

                Rs_Eliminar.P_Estatus = "S";

                Rs_Eliminar.Eliminar_Usuario_Padron();

                Modificacion = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Modificacion;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Alta
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Existencia_Usuario()
        {
            Cls_Cat_Padron_Negocio Rs_Consulta = new Cls_Cat_Padron_Negocio();
            DataTable Dt_Consulta = new DataTable();
            String Campos_Faltan = "";
            Boolean Resultado = false;

            if (!String.IsNullOrEmpty(Txt_Rfc.Text))
            {
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable Dt_Parametros = new DataTable();

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                Rs_Consulta.P_Dt_Parametros = Dt_Parametros;
                Txt_Rfc.Text = Txt_Rfc.Text.ToUpper();
                Rs_Consulta.P_Rfc = Txt_Rfc.Text;
                Dt_Consulta = Rs_Consulta.Consultar_Rfc_Duplicado();

                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                {
                    Campos_Faltan += "El rfc ya se encuentra registrado";
                    Erp_Validaciones.SetError(Txt_Rfc, "El rfc ya se encuentra registrado");

                    MessageBox.Show(Campos_Faltan, "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Resultado = false;
                }
                else
                {
                    Resultado = true;
                }
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Existencia_Usuario_Local
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Existencia_Usuario_Local()
        {
            Cls_Cat_Padron_Negocio Rs_Consulta = new Cls_Cat_Padron_Negocio();
            DataTable Dt_Consulta = new DataTable();
            String Campos_Faltan = "";
            Boolean Resultado = false;

            if (!String.IsNullOrEmpty(Txt_Rfc.Text))
            {
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable Dt_Parametros = new DataTable();

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                Rs_Consulta.P_Dt_Parametros = Dt_Parametros;
                Txt_Rfc.Text = Txt_Rfc.Text.ToUpper();
                Rs_Consulta.P_Rfc = Txt_Rfc.Text;
                Dt_Consulta = Rs_Consulta.Consultar_Rfc_Duplicado_Local();

                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                {
                    Campos_Faltan += "El rfc ya se encuentra registrado";
                    Erp_Validaciones.SetError(Txt_Rfc, "El rfc ya se encuentra registrado");

                    MessageBox.Show(Campos_Faltan, "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Resultado = false;
                }
                else
                {
                    Resultado = true;
                }
            }

            return Resultado;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Alta
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Alta()
        {
            String Campos_Faltan = "Debe de: \n"; // Variable concatena los diferentes mensajes para los campos obligatorios que no tienen información
            Boolean Resultado = true; // Variable que indica si todos los campos obligatorios contienen información
            Erp_Validaciones.Clear(); // Limpia los mensajes del control ErrorProvider
            Cls_Cat_Padron_Negocio Rs_Consulta = new Cls_Cat_Padron_Negocio();
            DataTable Dt_Consulta = new DataTable();

            if (Txt_Rfc.Text == String.Empty)
            {
                Campos_Faltan += "Ingresar el rfc \n";
                Erp_Validaciones.SetError(Txt_Rfc, "Ingresar el rfc\n");
                Resultado &= false;
            }
            else
            {
                try
                {
                    //Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                    //DataTable Dt_Parametros = new DataTable();

                    //Consulta_Parametros.P_Parametro_Id = "00001";
                    //Dt_Parametros = Consulta_Parametros.Consultar_Parametros();
                    //Rs_Consulta.P_Dt_Parametros = Dt_Parametros;

                    //Rs_Consulta.P_Rfc = Txt_Rfc.Text;
                    //Dt_Consulta = Rs_Consulta.Consultar_Rfc_Duplicado();

                    //if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                    //{
                    //    Campos_Faltan += "Verificar el rfc ya este ya se encuentra registrado\n";
                    //    Erp_Validaciones.SetError(Txt_Rfc, "Verificar el rfc ya este ya se encuentra registrado\n"); 
                    //    Resultado &= false;
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "**Consultar duplicidad: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Cmb_Tipo.SelectedItem.ToString() == "PERSONA FISICA")
            {
                if (Txt_Apellido_Paterno.Text == String.Empty)
                {
                    Campos_Faltan += "Ingresar el apellido paterno\n";
                    Erp_Validaciones.SetError(Txt_Apellido_Paterno, "Ingresar el apellido paterno\n");
                    Resultado &= false;
                }
                if (Txt_Apellido_Materno.Text == String.Empty)
                {
                    Campos_Faltan += "Ingresar el apellido materno\n";
                    Erp_Validaciones.SetError(Txt_Apellido_Materno, "Ingresar el apellido materno\n");
                    Resultado &= false;
                }
                if (Txt_Nombre.Text == String.Empty)
                {
                    Campos_Faltan += "Ingresar el nombre\n";
                    Erp_Validaciones.SetError(Txt_Nombre, "Ingresar el nombre\n");
                    Resultado &= false;
                }
            }
            else
            {
                if (Txt_Apellido_Paterno.Text == String.Empty && Txt_Apellido_Materno.Text == String.Empty && Txt_Nombre.Text == String.Empty)
                {
                    Campos_Faltan += "Ingresar el nombre\n";
                    Erp_Validaciones.SetError(Txt_Nombre, "Ingresar el nombre\n");
                    Resultado &= false;
                }
            }

            ////  calle
            //if (String.IsNullOrEmpty(Txt_Calle.Text))
            //{
            //    Campos_Faltan += "Ingresar la calle\n";
            //    Erp_Validaciones.SetError(Txt_Calle, "Ingresar la calle\n");
            //    Resultado &= false;
            //}
            ////  codigo postal
            //if (String.IsNullOrEmpty(Txt_Codigo_Postal.Text))
            //{
            //    Campos_Faltan += "Ingresar el codigo postal (CP)\n";
            //    Erp_Validaciones.SetError(Txt_Codigo_Postal, "Ingresar el codigo postal (CP)\n");
            //    Resultado &= false;
            //}
            ////  Colonia
            //if (String.IsNullOrEmpty(Txt_Colonia.Text))
            //{
            //    Campos_Faltan += "Ingresar la colonia\n";
            //    Erp_Validaciones.SetError(Txt_Colonia, "Ingresar la colonia\n");
            //    Resultado &= false;
            //}
            ////  Municipio
            //if (String.IsNullOrEmpty(Txt_Municipio.Text))
            //{
            //    Campos_Faltan += "Ingresar el municipio\n";
            //    Erp_Validaciones.SetError(Txt_Municipio, "Ingresar el municipio\n");
            //    Resultado &= false;
            //}
            ////  Estado
            //if (String.IsNullOrEmpty(Cmb_Estado.SelectedItem.ToString()))
            //{
            //    Campos_Faltan += "Seleccione el estado\n";
            //    Erp_Validaciones.SetError(Cmb_Estado, "Seleccione el estado\n");
            //    Resultado &= false;
            //}

            ////  numeros del domicilio
            //if (String.IsNullOrEmpty(Txt_No_Interior.Text) && String.IsNullOrEmpty(Txt_No_Exterior.Text))
            //{
            //    Campos_Faltan += "Ingrese el número del domicilio\n";
            //    Erp_Validaciones.SetError(Txt_No_Interior, "Ingrese el número del domicilio\n");
            //    Erp_Validaciones.SetError(Txt_No_Exterior, "Ingrese el número del domicilio\n");
            //    Resultado &= false;
            //}

            if (Resultado == false)
                MessageBox.Show(Campos_Faltan, "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return Resultado;
        }
        #endregion Metodos Generales

        #region Botones
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : permite ralizar las consultas de los usuarios del padron
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            DataTable Dt_Consulta = new DataTable();
            try
            {
                Dt_Consulta = Consultar_Padron();
                Cargar_Grid(Dt_Consulta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Buscar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : evento para dar un nuevo registro
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Nuevo.Text.Trim() == "Nuevo")
                {
                    Manejo_Botones_Operacion("Nuevo");
                    Cls_Metodos_Generales.Limpia_Controles(this);
                    Habilitar_Controles(true);
                }
                else
                {
                    if (Validar_Alta())
                    {
                        //  se valida la conexion con el deudorcad
                        if (Estatus_Conexion== true)
                        {
                            //  se valida que el usuario no exista
                            if (Validar_Existencia_Usuario())
                            {
                                if (Alta_Usuario_Padron())
                                {
                                    Manejo_Botones_Operacion("Cancelar");
                                    Cls_Metodos_Generales.Limpia_Controles(this);
                                    Habilitar_Controles(false);
                                    //DataTable Dt_Consulta = Consultar_Padron();
                                    //Cargar_Grid(Dt_Consulta);
                                    MessageBox.Show("El usuario se ha sido registrado", "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                        }
                        else//se realiza el proceso de manera local
                        {
                            if (Validar_Existencia_Usuario_Local())
                            {
                                if (Alta_Usuario_Padron_Local())
                                {
                                    Manejo_Botones_Operacion("Cancelar");
                                    Cls_Metodos_Generales.Limpia_Controles(this);
                                    Habilitar_Controles(false);
                                    //DataTable Dt_Consulta = Consultar_Padron();
                                    //Cargar_Grid(Dt_Consulta);
                                    MessageBox.Show("El usuario se ha sido registrado de forma local", "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Nuevo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : evento para dar un nuevo registro
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Modificar.Text.Trim() == "Modificar")
                {
                    if (Txt_Curp.Text != String.Empty || Txt_Rfc.Text != String.Empty)
                    {
                        Manejo_Botones_Operacion("Modificar");
                        Habilitar_Controles(true);

                        if (String.IsNullOrEmpty(Txt_Rfc.Text))
                            Txt_Rfc.Text = Txt_Curp.Text;
                    }
                    else
                    {
                        MessageBox.Show("Para modificar un usuario, debe seleccionar uno de la lista", "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (Validar_Alta())
                    {
                        if (Modificacion_Usuario_Padron())
                        {
                            Manejo_Botones_Operacion("Cancelar");
                            Cls_Metodos_Generales.Limpia_Controles(this);
                            Habilitar_Controles(false);
                            Cargar_Grid(Consultar_Padron());
                            MessageBox.Show("El usuario se ha modificado", "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Modificar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : evento para dar de baja un registro
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Rfc.Text != String.Empty || Txt_Curp.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente dar de baja al usuario '" + Txt_Curp.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (Eliminar_Usuario_Padron())
                        {
                            Manejo_Botones_Operacion("Cancelar");
                            Cls_Metodos_Generales.Limpia_Controles(this);
                            Habilitar_Controles(false);
                            Cargar_Grid(Consultar_Padron());
                            MessageBox.Show("El usuario se ha dado de baja", "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Eliminar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Salir_Click
        ///DESCRIPCIÓN          : evento para dar un nuevo registro
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Salir.Text == "Salir")
                {
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Habilitar_Controles(false);
                    Cls_Metodos_Generales.Limpia_Controles(this);
                    //Cargar_Grid(Consultar_Padron());
                    //Grid_Padron.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Salir_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Botones

        #region Grid
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Padron_SelectionChanged
        ///DESCRIPCIÓN          : evento para cargar la informacion de un registro
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Marzo 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Padron_SelectionChanged(object sender, EventArgs e)
        {
            Cls_Cat_Padron_Negocio Rs_Consulta = new Cls_Cat_Padron_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable Dt_Parametros = new DataTable();

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                Rs_Consulta.P_Dt_Parametros = Dt_Parametros;

                if (Grid_Padron.CurrentRow != null)
                {
                    Rs_Consulta.P_Rfc = Grid_Padron.CurrentRow.Cells["curp"].Value.ToString();
                    
                    if(Estatus_Conexion == true)
                        Dt_Consulta = Rs_Consulta.Consultar_Padron();
                    else
                        Dt_Consulta = Rs_Consulta.Consultar_Padron_Local();

                    foreach (DataRow Registro in Dt_Consulta.Rows)
                    {
                        //  curo
                        Txt_Curp.Text = Registro["curp"].ToString();

                        //  rfc
                        Txt_Rfc.Text = Registro["rfc"].ToString();

                        //  validacion para el tipo
                        if (Registro["tipo"].ToString() == "0")
                            Cmb_Tipo.Text = "PERSONA FISICA";
                        else
                            Cmb_Tipo.Text = "PERSONA MORAL";

                        //  apellido paterno
                        Txt_Apellido_Paterno.Text = Registro["paterno"].ToString();

                        //  apellido materno
                        Txt_Apellido_Materno.Text = Registro["materno"].ToString();

                        //  nombre
                        Txt_Nombre.Text = Registro["nombre"].ToString();

                        //  validacion para el genero
                        if (Registro["genero"].ToString() == "M")
                            Cmb_Genero.Text = "FEMENINO";
                        else
                            Cmb_Genero.Text = "MASCULINO";

                        //  Validacion para el estatus
                        if (Registro["baja"].ToString() == "S")
                            Cmb_Estatus.Text = "INACTIVO";
                        else
                            Cmb_Estatus.Text = "ACTIVO";

                        //  domicilio
                        Txt_Calle.Text = Registro["nomcalle"].ToString();
                        Txt_No_Interior.Text = Registro["numint"].ToString();
                        Txt_No_Exterior.Text = Registro["numext"].ToString();
                        Txt_Codigo_Postal.Text = Registro["cp"].ToString();
                        Txt_Colonia.Text = Registro["nomcol"].ToString();
                        Txt_Municipio.Text = Registro["ciudad"].ToString();

                        if (!String.IsNullOrEmpty(Registro["nomedo"].ToString()))
                            Cmb_Estado.Text = Registro["nomedo"].ToString();
                        else
                            Cmb_Estado.SelectedIndex = -1;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Grid_Padron_SelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Combo box
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN          : evento que habilita los campos de persona moral 
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Tipo.SelectedItem.ToString() == "PERSONA MORAL")
                {
                    Cmb_Genero.Enabled = false;
                    Txt_Apellido_Paterno.Enabled = false;
                    Txt_Apellido_Materno.Enabled = false;
                }
                else if (Cmb_Tipo.SelectedItem.ToString() == "PERSONA FISICA")
                {
                    Cmb_Genero.Enabled = true;
                    Txt_Apellido_Paterno.Enabled = true;
                    Txt_Apellido_Materno.Enabled = true;
                }
                else
                {
                    Cmb_Genero.Enabled = true;
                    Txt_Apellido_Paterno.Enabled = true;
                    Txt_Apellido_Materno.Enabled = true;
                }

                //PERSONA FISICA
                //PERSONA MORAL
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Cmb_Tipo_SelectedIndexChanged: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Text Box
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Rfc_Leave
        ///DESCRIPCIÓN          : consulta que el rfc no se encuentre duplicado
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Rfc_Leave(object sender, EventArgs e)
        {
            Cls_Cat_Padron_Negocio Rs_Consulta = new Cls_Cat_Padron_Negocio();
            DataTable Dt_Consulta = new DataTable();
            String Campos_Faltan = "";
            try
            {
                Txt_Rfc.Text = Txt_Rfc.Text.ToUpper();

                //if (!String.IsNullOrEmpty(Txt_Rfc.Text))
                //{
                //    Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                //    DataTable Dt_Parametros = new DataTable();

                //    Consulta_Parametros.P_Parametro_Id = "00001";
                //    Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                //    Rs_Consulta.P_Dt_Parametros = Dt_Parametros;
                //    Txt_Rfc.Text = Txt_Rfc.Text.ToUpper();
                //    Rs_Consulta.P_Rfc = Txt_Rfc.Text;
                //    Dt_Consulta = Rs_Consulta.Consultar_Rfc_Duplicado();

                //    if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                //    {
                //        Campos_Faltan += "El rfc ya se encuentra registrado";
                //        Erp_Validaciones.SetError(Txt_Rfc, "El rfc ya se encuentra registrado");

                //        MessageBox.Show(Campos_Faltan, "Padrón", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Cmb_Tipo_SelectedIndexChanged: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Curp_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Curp_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Curp.Text))
                {
                    Txt_Curp.Text = Txt_Curp.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Cmb_Tipo_SelectedIndexChanged: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Apellido_Paterno_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Apellido_Paterno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Apellido_Paterno.Text))
                {
                    Txt_Apellido_Paterno.Text = Txt_Apellido_Paterno.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Txt_Apellido_Paterno_Leave: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Apellido_Materno_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Apellido_Materno_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Apellido_Materno.Text))
                {
                    Txt_Apellido_Materno.Text = Txt_Apellido_Materno.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Txt_Apellido_Materno_Leave: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Nombre_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Nombre_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Nombre.Text))
                {
                    Txt_Nombre.Text = Txt_Nombre.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Txt_Nombre_Leave: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Calle_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Calle_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Calle.Text))
                {
                    Txt_Calle.Text = Txt_Calle.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Txt_Calle_Leave: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Colonia_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Colonia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Colonia.Text))
                {
                    Txt_Colonia.Text = Txt_Colonia.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Txt_Colonia_Leave: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Colonia_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Municipio_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Municipio.Text))
                {
                    Txt_Municipio.Text = Txt_Municipio.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Txt_Colonia_Leave: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
