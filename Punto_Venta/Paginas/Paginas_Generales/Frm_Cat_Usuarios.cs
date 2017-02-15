using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using Erp_Cat_Nom_Empleados.Negocio;
using Erp_Apl_Roles.Negocio;
using Erp.Constantes;
using Erp_Apl_Usuarios.Negocio;
using Erp.Seguridad;
using Erp.Validador;
using ERP_BASE.App_Code.Negocio.Catalogos;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Cat_Usuarios : Form
    {
        public static Boolean Cargado_Grid;
        Validador_Generico Validador;
        #region "METODOS_GENERALES"
        public Frm_Cat_Usuarios()
        {
            InitializeComponent();
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Frm_Cat_Usuarios_Load
        //DESCRIPCIÓN: Carga la forma inicial
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Frm_Cat_Usuarios_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Usuarios", this);
            Cls_Apl_Roles_Negocio Rs_Roles = new Cls_Apl_Roles_Negocio();
            Cls_Cat_Cajas_Negocio Rs_Cajas = new Cls_Cat_Cajas_Negocio();
            DataTable Dt_Resultado = new DataTable();
            DataTable Dt_Cajas = new DataTable();
            
            try
            {
                Fra_Buscar.Visible = false;
                Fra_Datos_Generales.Visible = true;
                Fra_Login.Visible = true;
                Fra_Datos_Generales.Enabled = false;
                Fra_Login.Enabled = false;
                Cargar_Usuarios_Activos();
                Dt_Resultado = new DataTable();
                Rs_Roles.P_Estatus = "ACTIVO";
                Dt_Resultado = Rs_Roles.Consultar_Roles();
                Dt_Cajas = Rs_Cajas.Consultar_Caja();
                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Rol, Dt_Resultado, Apl_Roles.Campo_Nombre, Apl_Roles.Campo_Rol_Id);

                if (Dt_Cajas != null && Dt_Cajas.Rows.Count > 0)
                {
                    DataRow Row = Dt_Cajas.NewRow();
                    Row[Cat_Cajas.Campo_Caja_ID] = "0";
                    Row[Cat_Cajas.Campo_Comentarios] = "<-SELECCIONE->";
                    Dt_Cajas.Rows.InsertAt(Row, 0);
                    Cmb_Caja.DataSource = Dt_Cajas;
                    Cmb_Caja.DisplayMember = Cat_Cajas.Campo_Comentarios;
                    Cmb_Caja.ValueMember = Cat_Cajas.Campo_Caja_ID;
                }

                Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Usuarios);
                Cmb_Estatus.Enabled = false;
                Validador = new Validador_Generico(Erp_Validaciones);
                Erp_Validaciones.Clear();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Manejo_Botones_Operacion
        //DESCRIPCIÓN:Método para manejo de los estados de los botones
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
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
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Erp_Validaciones.Clear();
                        break;
                    }
                case "Modificar":
                    {
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Erp_Validaciones.Clear();
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
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Salir.Enabled = true;
                        Erp_Validaciones.Clear();
                        break;
                    }
                default: break;
            }

        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Manejo_Botones_Operacion
        //DESCRIPCIÓN:Método para manejo de los estados de los botones
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Cargar_Usuarios_Activos()
        {
            Cls_Apl_Usuarios_Negocio Rs_Usuarios_Actuales = new Cls_Apl_Usuarios_Negocio();
            Cls_Apl_Roles_Negocio Rs_Rol = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Usuarios = new DataTable();
            DataTable Dt_Temporal = new DataTable();
            DataTable Dt_Rol = new DataTable();
            Int16 Contador_Filas = 0;
            try
            {
                //Rs_Usuarios_Actuales.P_Estatus = "ACTIVO";
                Dt_Usuarios = Rs_Usuarios_Actuales.Consultar_Usuario();
                if (Dt_Usuarios.Rows.Count > 0)
                {
                    if (Dt_Temporal.Rows.Count <= 0 && Dt_Temporal.Rows.Count <= 0)
                    {
                        Dt_Temporal.Columns.Add("USUARIO_ID", typeof(System.String));
                        Dt_Temporal.Columns.Add("NOMBRE", typeof(System.String));
                        Dt_Temporal.Columns.Add("ROL", typeof(System.String));
                        Dt_Temporal.Columns.Add("ROL_ID", typeof(System.String));
                        Dt_Temporal.Columns.Add("EMPLEADO_ID", typeof(System.String));
                        Dt_Temporal.Columns.Add("ESTATUS", typeof(System.String));
                        Dt_Temporal.Columns.Add("FECHA_TERMINO", typeof(System.DateTime));
                    }
                    foreach (DataRow Fila in Dt_Usuarios.Rows)
                    {
                        DataRow row = Dt_Temporal.NewRow(); //Crea un nuevo registro a la tabla
                        //Asigna los valores al nuevo registro creado a la tabla
                        row["USUARIO_ID"] = Fila[Apl_Usuarios.Campo_Usuario_Id].ToString();
                        row["NOMBRE"] = Fila[Apl_Usuarios.Campo_Usuario].ToString();
                        Rs_Rol.P_Rol_Id = Fila[Apl_Usuarios.Campo_Rol_Id].ToString();
                        Dt_Rol = Rs_Rol.Consultar_Roles();
                        row["ROL"] = Dt_Rol.Rows[0][Apl_Roles.Campo_Nombre];
                        row["ESTATUS"] = Fila[Apl_Usuarios.Campo_Estatus].ToString();
                        row["FECHA_TERMINO"] = Fila[Apl_Usuarios.Campo_Fecha_Expira_Contrasenia].ToString();
                        row["ROL_ID"] = Fila[Apl_Usuarios.Campo_Rol_Id].ToString();
                        //row["EMPLEADO_ID"] = Fila[Apl_Usuarios.Campo_Empleado_Id].ToString();
                        Dt_Temporal.Rows.Add(row); //Agrega el registro creado con todos sus valores a la tabla
                        Dt_Temporal.AcceptChanges();
                        Contador_Filas++;
                        //if (Contador_Filas > 30)
                        //{
                        //    break;
                        //}
                    }
                    Grid_Usuarios.DataSource = Dt_Temporal;
                    //Da formato a las columnas del DataGrid
                    Grid_Usuarios.Columns["USUARIO_ID"].HeaderText = "Usuario ID";
                    Grid_Usuarios.Columns["USUARIO_ID"].DefaultCellStyle.Format = "00000";
                    Grid_Usuarios.Columns["USUARIO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Grid_Usuarios.Columns["USUARIO_ID"].Visible = false;
                    Grid_Usuarios.Columns["USUARIO_ID"].ReadOnly = true;
                    Grid_Usuarios.Columns["NOMBRE"].HeaderText = "USUARIO";
                    Grid_Usuarios.Columns["NOMBRE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Usuarios.Columns["NOMBRE"].ReadOnly = true;
                    Grid_Usuarios.Columns["ROL"].HeaderText = "ROL";
                    Grid_Usuarios.Columns["ROL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Usuarios.Columns["ROL"].ReadOnly = true;
                    Grid_Usuarios.Columns["ESTATUS"].HeaderText = "ESTATUS";
                    Grid_Usuarios.Columns["ESTATUS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Usuarios.Columns["ESTATUS"].ReadOnly = true;
                    Grid_Usuarios.Columns["FECHA_TERMINO"].HeaderText = "FECHA_TERMINO";
                    Grid_Usuarios.Columns["FECHA_TERMINO"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                    Grid_Usuarios.Columns["FECHA_TERMINO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Usuarios.Columns["FECHA_TERMINO"].ReadOnly = true;
                    Grid_Usuarios.Columns["ROL_ID"].HeaderText = "ROL_ID";
                    Grid_Usuarios.Columns["ROL_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Usuarios.Columns["ROL_ID"].Visible = false;
                    Grid_Usuarios.Columns["ROL_ID"].ReadOnly = true;
                    //Grid_Usuarios.Columns["EMPLEADO_ID"].HeaderText = "EMPLEADO_ID";
                    //Grid_Usuarios.Columns["EMPLEADO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //Grid_Usuarios.Columns["EMPLEADO_ID"].Visible = false;
                    //Grid_Usuarios.Columns["EMPLEADO_ID"].ReadOnly = true;

                   
                    //Cargando_Grid = false;
                }
                else
                {
                    Grid_Usuarios.DataSource = null;
                    //Cargando_Grid = true;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Validar_Alta
        //DESCRIPCIÓN:valida que todos los datos que son requeridos esten proporcionados por el usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private Boolean Validar_Alta()
        {
            Cls_Apl_Usuarios_Negocio Rs_Consulta_Usuario = new Cls_Apl_Usuarios_Negocio();
            DataTable Dt_Usuario = new DataTable();
            Boolean Datos_Validados = true;
            String Faltan = "Es necesario:\n";
            DateTimePicker Fecha_Usuario = new DateTimePicker();
            DateTimePicker Fecha_Actual = new DateTimePicker();
            try
            {
                //if (Cmb_Estatus.SelectedIndex < 0)
                //{
                //    Datos_Validados = false;
                //    Faltan = Faltan + " Introducir un estatus de la cuenta del usuario \n";
                //}
                //if (Txt_Login.Text.Length <= 0)
                //{
                //    Datos_Validados = false;
                //    Faltan = Faltan + " Introducir el login del usuario \n";
                //}
                if (Txt_Nombre_Usuario.Text.Length <= 0)
                {
                    Datos_Validados = false;
                    Faltan = Faltan + " Introducir el nombre del usuario \n";
                }
                else
                {
                    Rs_Consulta_Usuario.P_Usuario = Txt_Login.Text.Trim();
                    Rs_Consulta_Usuario.P_Estatus = "ACTIVO";
                    Dt_Usuario = Rs_Consulta_Usuario.Consultar_Usuario();
                    if (Btn_Nuevo.Text == "Nuevo")
                    {
                        if (Dt_Usuario.Rows.Count > 1)
                        {
                            Datos_Validados = false;
                            Faltan = Faltan + " Introducir otro login debido a que ya existe el que coloco \n";
                        }
                    }
                    else
                    {
                        if (Dt_Usuario.Rows.Count > 0)
                        {
                            Datos_Validados = false;
                            Faltan = Faltan + " Introducir otro login debido a que ya existe el que coloco \n";
                        }
                    }
                }
                //if (Txt_Password.Text.Length <= 7)
                //{
                //    Datos_Validados = false;
                //    Faltan = Faltan + " Introducir un password del usuario que minimo cuente con 8 caracteres \n";
                //}
                //if (Txt_Confirmar.Text.Length <= 7)
                //{
                //    Datos_Validados = false;
                //    Faltan = Faltan + " Introducir un password del usuario que minimo cuente con 8 caracteres \n";
                //}
                if (Txt_Password.Text.Length > 7 && Txt_Confirmar.Text.Length > 7)
                {
                    if (Txt_Password.Text != Txt_Confirmar.Text)
                    {
                        Datos_Validados = false;
                        Faltan = Faltan + "El password y la confirmación no son iguales \n";
                    }
                }
                //if (Cmb_Rol.SelectedIndex <= 0)
                //{
                //    Datos_Validados = false;
                //    Faltan = Faltan + " introduce el rol del usuario \n";
                //}
                Fecha_Usuario.Value = Convert.ToDateTime((Dtp_Fecha_Baja.Value.ToString()));
                Fecha_Actual.Value = DateTime.Now;
                if (Fecha_Actual.Value.CompareTo(Fecha_Usuario.Value) == 1)
                {
                    Datos_Validados = false;
                    Faltan = Faltan + "La fecha Caduca no puede ser menor o igual a la actual \n";
                }
                if (Datos_Validados == false)
                {
                    MessageBox.Show(this, Faltan, "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }               
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Datos_Validados;
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Alta_Usuario
        //DESCRIPCIÓN:Realiza el alta del usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private Boolean Alta_Usuario()
        {
            Cls_Apl_Usuarios_Negocio Rs_Usuario_Nuevo = new Cls_Apl_Usuarios_Negocio();
            Boolean Alta = true;
            try
            {
                Rs_Usuario_Nuevo.P_Estatus = "ACTIVO";
                Rs_Usuario_Nuevo.P_Nombre_Usuario = Txt_Nombre_Usuario.Text.ToString().ToUpper().Trim();
                Rs_Usuario_Nuevo.P_Usuario = Txt_Login.Text.ToString().ToUpper().Trim();
                Rs_Usuario_Nuevo.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Password.Text.ToString().Trim());
                Rs_Usuario_Nuevo.P_Rol_ID = Cmb_Rol.SelectedValue.ToString();
                if (Cmb_Caja.SelectedIndex > 0) Rs_Usuario_Nuevo.P_Caja_Id = Cmb_Caja.SelectedValue.ToString();
                Rs_Usuario_Nuevo.P_Email = Txt_Correo.Text.ToString().Trim();
                Rs_Usuario_Nuevo.P_Fecha_Expira_Contrasenia = Dtp_Fecha_Baja.Value;
                Rs_Usuario_Nuevo.P_Comentarios = Txt_Comentarios.Text.Trim();
                Rs_Usuario_Nuevo.Alta_Usuarios();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Alta;
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
        //DESCRIPCIÓN:realiza la modificacion de un usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public void Modificar_Usuario()
        {
            Cls_Apl_Usuarios_Negocio Rs_Modificacion_Usuario = new Cls_Apl_Usuarios_Negocio();
            try
            {
                Rs_Modificacion_Usuario.P_Usuario_Id = Txt_Usuario_ID.Text.Trim();
                Rs_Modificacion_Usuario.P_Estatus = Cmb_Estatus.Text;
                Rs_Modificacion_Usuario.P_Nombre_Usuario = Txt_Nombre_Usuario.Text.ToString().ToUpper().Trim();
                Rs_Modificacion_Usuario.P_Usuario = Txt_Login.Text.ToString().ToUpper().Trim();
                Rs_Modificacion_Usuario.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Password.Text.ToString().Trim());
                Rs_Modificacion_Usuario.P_Rol_ID = Cmb_Rol.SelectedValue.ToString();
                Rs_Modificacion_Usuario.P_Estatus_Caja_Id = true;
                if (Cmb_Caja.SelectedIndex > 0)
                    Rs_Modificacion_Usuario.P_Caja_Id = Cmb_Caja.SelectedValue.ToString();
                else
                    Rs_Modificacion_Usuario.P_Caja_Id = "";

                Rs_Modificacion_Usuario.P_Email = Txt_Correo.Text.ToString().Trim();
                Rs_Modificacion_Usuario.P_Fecha_Expira_Contrasenia = Dtp_Fecha_Baja.Value;
                Rs_Modificacion_Usuario.P_Comentarios = Txt_Comentarios.Text.Trim();
                Rs_Modificacion_Usuario.Modificar_Usuario();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Eliminar_Usuario
        //DESCRIPCIÓN:realiza la Eliminacion de un usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public void Eliminar_Usuario(String Comentario)
        {
            Cls_Apl_Usuarios_Negocio Rs_Eliminar_Usuario = new Cls_Apl_Usuarios_Negocio();
            try
            {
                Rs_Eliminar_Usuario.P_Usuario_Id = Txt_Usuario_ID.Text.Trim();
                Rs_Eliminar_Usuario.P_Estatus = "ELIMINADO";
                Rs_Eliminar_Usuario.P_Comentarios = Comentario;
                Rs_Eliminar_Usuario.Modificar_Usuario();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region "EVENTOS"
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Buscar_Click
        //DESCRIPCIÓN: Abre el panel para la busqueda de un usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Fra_Buscar.Enabled = true;
            Fra_Login.Enabled = false;
            Fra_Login.Visible = false;
            Fra_Datos_Generales.Visible = false;
            Fra_Datos_Generales.Enabled = false;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Regresar_Click
        //DESCRIPCIÓN:regresa de la forma de busqueda a la inicial
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Login.Visible = true;
            Fra_Login.Enabled = false;
            Fra_Buscar.Visible = false;
            Fra_Buscar.Enabled = false;
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Nuevo_Click
        //DESCRIPCIÓN: inicializa los controles o da de alta al usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text.Trim() == "Nuevo")
            {
                Manejo_Botones_Operacion("Nuevo");
                Cls_Metodos_Generales.Limpia_Controles(Fra_Buscar);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Login);
                Cls_Metodos_Generales.Limpia_Controles(Grb_Usuarios);
                Fra_Buscar.Enabled = true;
                Fra_Datos_Generales.Enabled = true;
                Fra_Datos_Generales.Visible = true;
                Fra_Login.Enabled = true;
                Fra_Login.Visible = true;
                Grb_Usuarios.Enabled = false;
                Fra_Buscar.Visible = false;
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Login, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Grb_Usuarios, true);
                Cmb_Estatus.SelectedIndex = 0;
                Cmb_Estatus.Enabled = false;
                Txt_Usuario_ID.Enabled = false;
            }
            else
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))//(Validar_Alta())
                {
                    if (Validar_Alta())
                    {
                        if (Alta_Usuario())
                        {
                            Manejo_Botones_Operacion("Cancelar");
                            Cls_Metodos_Generales.Limpia_Controles(Fra_Buscar);
                            Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                            Cls_Metodos_Generales.Limpia_Controles(Fra_Login);
                            Cls_Metodos_Generales.Limpia_Controles(Grb_Usuarios);
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Login, false);
                            Grb_Usuarios.Enabled = true;
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Grb_Usuarios, true);
                            Cargar_Usuarios_Activos();
                            Grid_Usuarios.Enabled = true;
                        }
                    }
                }
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Nuevo_Click
        //DESCRIPCIÓN: inicializa los controles o da de alta al usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 22-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            String Cometario;
            if (Txt_Usuario_ID.Text != "")
            {
                if (MessageBox.Show(this, "¿Quieres realmente eliminar el usuario '" + Txt_Nombre_Usuario .Text+ "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Cometario = Microsoft.VisualBasic.Interaction.InputBox("¿Porqué se va a eliminar el usuario?");
                    while (Cometario == "")
                    {
                        Cometario = Microsoft.VisualBasic.Interaction.InputBox("¿Porqué se va a eliminar el usuario?");
                    }
                    Cometario=Cometario.Replace("'", "").Replace("''", "").Replace("|", "");
                    if (Txt_Comentarios.Text.Length > 240)
                    {
                        Cometario = Cometario.Substring(0, 240); 
                    }
                    Eliminar_Usuario(Cometario);
                    Manejo_Botones_Operacion("Cancelar");
                    Cls_Metodos_Generales.Limpia_Controles(Fra_Buscar);
                    Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                    Cls_Metodos_Generales.Limpia_Controles(Fra_Login);
                    Cls_Metodos_Generales.Limpia_Controles(Grb_Usuarios);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Login, false);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Grb_Usuarios, false);
                    Cargar_Usuarios_Activos();
                 }                
            }
            else
            {
                MessageBox.Show(this, "Para Eliminar un usuario debes tener seleccionado un usuario.", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
        //DESCRIPCIÓN:realiza la modificacion de un usuario
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text == "Modificar")
            {
                if (Txt_Usuario_ID.Text != "")
                {
                    Manejo_Botones_Operacion("Modificar");
                    Grid_Usuarios.Enabled = false;
                    Txt_Nombre_Usuario.Focus();
                    Cmb_Estatus.Enabled = true;
                    Fra_Buscar.Enabled = true;
                    Fra_Datos_Generales.Enabled = true;
                    Fra_Buscar.Visible = false;
                    Fra_Datos_Generales.Visible = true;
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Login, true);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Grb_Usuarios, true);
                    Cmb_Estatus.SelectedIndex = 0;
                    Txt_Usuario_ID.Enabled = false;
                    Fra_Login.Enabled = true;
                    Fra_Login.Visible = true;
                }
                else
                {
                    MessageBox.Show(this, "Para Modificar un usuario debes tener seleccionado un usuario.", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Validar_Alta())
                {
                    Modificar_Usuario();
                    Manejo_Botones_Operacion("Cancelar");                    
                    Cls_Metodos_Generales.Limpia_Controles(this);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Login, false);
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Grb_Usuarios, true);
                    Cargar_Usuarios_Activos();
                    Grb_Usuarios.Enabled = true;
                    Grid_Usuarios.Enabled = true;
                    Fra_Buscar.Enabled = true;
                }
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
        //DESCRIPCIÓN:Evento de salir de la forma
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Salir.Text == "Salir")
            {
                this.Dispose();
                this.Close();
            }
            else
            {
                Manejo_Botones_Operacion("Cancelar");
                Cls_Metodos_Generales.Limpia_Controles(Fra_Buscar);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Login);
                Cls_Metodos_Generales.Limpia_Controles(Grb_Usuarios);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Login, false);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Grb_Usuarios, true);
                Grid_Usuarios.Enabled = true;
                Cargar_Usuarios_Activos();
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Busqueda_Click
        //DESCRIPCIÓN:Al seleccionar un regristro se llenaran los campos con la informacion adecuada
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            Cls_Apl_Usuarios_Negocio Rs_Usuarios_Actuales = new Cls_Apl_Usuarios_Negocio();
            Cls_Apl_Roles_Negocio Rs_Rol = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Usuarios = new DataTable();
            DataTable Dt_Temporal = new DataTable();
            DataTable Dt_Rol = new DataTable();
            Int16 Contador_Filas = 0;
            try
            {
                if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
                {
                    if (Txt_Descripcion_Busqueda.Text != "")
                    {
                        if (Cmb_Busqueda_Tipo.Text == "USUARIO_ID")
                        {
                            if (Txt_Descripcion_Busqueda.Text.Length < 10)
                            {
                                Int64 Id_Usuario;
                                Int64.TryParse(Txt_Descripcion_Busqueda.Text, out Id_Usuario);
                                Rs_Usuarios_Actuales.P_Usuario_Id = String.Format("{0:0000000000}", Id_Usuario);
                            }
                            else
                            {
                                Rs_Usuarios_Actuales.P_Usuario_Id = Txt_Descripcion_Busqueda.Text.Trim();
                            }

                        }
                        else
                        {
                            if (Cmb_Busqueda_Tipo.Text == "NOMBRE")
                            {
                                Rs_Usuarios_Actuales.P_Nombre_Usuario = Txt_Descripcion_Busqueda.Text.Trim();
                            }
                            else
                            {
                                if (Cmb_Busqueda_Tipo.Text == "LOGIN")
                                {
                                    Rs_Usuarios_Actuales.P_Usuario = Txt_Descripcion_Busqueda.Text.Trim();
                                }
                            }
                        }
                        Dt_Usuarios = Rs_Usuarios_Actuales.Consultar_Usuario();
                        if (Dt_Usuarios.Rows.Count > 0)
                        {
                            if (Dt_Temporal.Rows.Count <= 0 && Dt_Temporal.Rows.Count <= 0)
                            {
                                Dt_Temporal.Columns.Add("USUARIO_ID", typeof(System.String));
                                Dt_Temporal.Columns.Add("NOMBRE", typeof(System.String));
                                Dt_Temporal.Columns.Add("ROL", typeof(System.String));
                                Dt_Temporal.Columns.Add("ROL_ID", typeof(System.String));
                                Dt_Temporal.Columns.Add("EMPLEADO_ID", typeof(System.String));
                                Dt_Temporal.Columns.Add("ESTATUS", typeof(System.String));
                                Dt_Temporal.Columns.Add("FECHA_TERMINO", typeof(System.String));
                            }
                            foreach (DataRow Fila in Dt_Usuarios.Rows)
                            {
                                DataRow row = Dt_Temporal.NewRow(); //Crea un nuevo registro a la tabla
                                //Asigna los valores al nuevo registro creado a la tabla
                                row["USUARIO_ID"] = Fila[Apl_Usuarios.Campo_Usuario_Id].ToString();
                                row["NOMBRE"] = Fila[Apl_Usuarios.Campo_Usuario].ToString();
                                Rs_Rol.P_Rol_Id = Fila[Apl_Usuarios.Campo_Rol_Id].ToString();
                                Dt_Rol = Rs_Rol.Consultar_Roles();
                                // validar que la consulta haya regresado roles
                                if (Dt_Rol != null && Dt_Rol.Rows.Count > 0)
                                {
                                    row["ROL"] = Dt_Rol.Rows[0][Apl_Roles.Campo_Nombre];
                                }
                                else
                                {
                                    row["ROL"] = "";
                                }
                                row["ESTATUS"] = Fila[Apl_Usuarios.Campo_Estatus].ToString();
                                row["FECHA_TERMINO"] = Fila[Apl_Usuarios.Campo_Fecha_Expira_Contrasenia].ToString();
                                row["ROL_ID"] = Fila[Apl_Usuarios.Campo_Rol_Id].ToString();
                                //row["EMPLEADO_ID"] = Fila[Apl_Usuarios.Campo_Empleado_Id].ToString();
                                Dt_Temporal.Rows.Add(row); //Agrega el registro creado con todos sus valores a la tabla
                                Dt_Temporal.AcceptChanges();
                                Contador_Filas++;
                                //if (Contador_Filas > 30)
                                //{
                                //    break;
                                //}
                            }
                            Grid_Usuarios.DataSource = Dt_Temporal;
                            Grid_Usuarios.Columns["USUARIO_ID"].HeaderText = "Usuario ID";
                            Grid_Usuarios.Columns["USUARIO_ID"].DefaultCellStyle.Format = "00000";
                            Grid_Usuarios.Columns["USUARIO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            Grid_Usuarios.Columns["USUARIO_ID"].ReadOnly = true;
                            Grid_Usuarios.Columns["NOMBRE"].HeaderText = "USUARIO";
                            Grid_Usuarios.Columns["NOMBRE"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            Grid_Usuarios.Columns["NOMBRE"].ReadOnly = true;
                            Grid_Usuarios.Columns["ROL"].HeaderText = "ROL";
                            Grid_Usuarios.Columns["ROL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            Grid_Usuarios.Columns["ROL"].ReadOnly = true;
                            Grid_Usuarios.Columns["ESTATUS"].HeaderText = "ESTATUS";
                            Grid_Usuarios.Columns["ESTATUS"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            Grid_Usuarios.Columns["ESTATUS"].ReadOnly = true;
                            Grid_Usuarios.Columns["FECHA_TERMINO"].HeaderText = "FECHA_TERMINO";
                            Grid_Usuarios.Columns["FECHA_TERMINO"].DefaultCellStyle.Format = "{0:dd/MMM/yyyy}";
                            Grid_Usuarios.Columns["FECHA_TERMINO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            Grid_Usuarios.Columns["FECHA_TERMINO"].ReadOnly = true;
                            Grid_Usuarios.Columns["ROL_ID"].HeaderText = "ROL_ID";
                            Grid_Usuarios.Columns["ROL_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            Grid_Usuarios.Columns["ROL_ID"].Visible = false;
                            Grid_Usuarios.Columns["ROL_ID"].ReadOnly = true;
                            Grid_Usuarios.Columns["EMPLEADO_ID"].HeaderText = "EMPLEADO_ID";
                            Grid_Usuarios.Columns["EMPLEADO_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            Grid_Usuarios.Columns["EMPLEADO_ID"].Visible = false;
                            Grid_Usuarios.Columns["EMPLEADO_ID"].ReadOnly = true;
                        }
                        else
                        {
                            Grid_Usuarios.DataSource = null;
                            MessageBox.Show(this, "No se encontró coincidencia en la búsqueda.", "Búsqueda Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Cargando_Grid = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Debes ingresar una descripción.", "Búsqueda Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Debes seleccionar un tipo de búsqueda.", "Búsqueda Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #region "VALIDACIONES"
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Nombre_Usuario_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Nombre_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }
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
        private void Txt_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Password_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Confirmar_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Confirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Comentarios_TextChanged
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Comentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Descripcion_Busqueda_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Descripcion_Busqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Password_Leave
        //DESCRIPCIÓN:Al seleccionar un regristro se llenaran los campos con la informacion adecuada
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Password_Leave(object sender, EventArgs e)
        {
            if (Txt_Password.Text != "")
            {
                if (Txt_Password.Text.Length <= 7)
                {
                    Txt_Password.Text = "";
                    Txt_Password.Focus();
                    MessageBox.Show(this, "EL password debe tener mínimo 8 caracteres.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (!Cls_Metodos_Generales.Validar_Password(Convert.ToString(Txt_Password.Text.Trim())))
                    {
                        MessageBox.Show(this, "El Password que ingreso no cumple con los estándares de seguridad \n ->Debe ser Alfanumérico \n ->Debe contener por lo menos uno de estos caracteres ¡!@#$%&*-_=+[](){}:,<.>/¿?.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Txt_Password.Focus();
                    }
                }
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Login_Leave
        //DESCRIPCIÓN:Al seleccionar un regristro se llenaran los campos con la informacion adecuada
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Login_Leave(object sender, EventArgs e)
        {
            if (Txt_Login.Text != "")
            {
                if (Txt_Login.Text.Length <= 7)
                {
                    Txt_Login.Focus();
                    MessageBox.Show(this, "EL Login debe tener mínimo 8 caracteres.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Cmb_Rol
        //DESCRIPCIÓN:Valida que el nombre que no sea nulo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Cmb_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Combo_Requerido(e, (ComboBox)sender, true);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Confirmar
        //DESCRIPCIÓN:Valida cuando pierde el foco el texbox
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Confirmar_Leave(object sender, EventArgs e)
        {
            if (Txt_Password.Text != "" && Txt_Confirmar.Text != "")
            {
                if (Txt_Confirmar.Text != Txt_Password.Text)
                {
                    MessageBox.Show(this, "La confirmación no es igual al password por favor corrígelo para continuar.", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Txt_Confirmar.Text = "";
                    Txt_Confirmar.Focus();
                }
            }
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Validating
        //DESCRIPCIÓN:Valida que seleccione un registro del combo
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
        //DESCRIPCIÓN:Valida que seleccione un registro del combo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Correo_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
            Validador.Validacion_Campo_Email(e, (TextBox)sender, true);
        }
        #endregion
        #endregion
        #region "GRID"
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Grid_Usuarios_SelectionChanged
        //DESCRIPCIÓN:Al seleccionar un regristro se llenaran los campos con la informacion adecuada
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Grid_Usuarios_SelectionChanged(object sender, EventArgs e)
        {
            Cls_Apl_Usuarios_Negocio Rs_Usuario_Informacion = new Cls_Apl_Usuarios_Negocio();
            DataTable Dt_Usuario = new DataTable();
            try
            {
                if (Grid_Usuarios.CurrentRow != null && !Cargado_Grid)
                {
                    Rs_Usuario_Informacion.P_Usuario_Id = Grid_Usuarios.CurrentRow.Cells["USUARIO_ID"].FormattedValue.ToString();
                    Dt_Usuario = Rs_Usuario_Informacion.Consultar_Usuario();
                    if (Dt_Usuario.Rows.Count > 0)
                    {
                        Txt_Usuario_ID.Text = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
                        Cmb_Estatus.SelectedItem = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Estatus].ToString();
                        Txt_Nombre_Usuario.Text = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Nombre_Usuario].ToString();
                        Txt_Login.Text = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Usuario].ToString();
                        Txt_Correo.Text = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Email].ToString();
                        Txt_Password.Text = Cls_Seguridad.Desencriptar(Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Contrasenia].ToString());
                        Cmb_Rol.SelectedValue = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Rol_Id].ToString();
                        Dtp_Fecha_Baja.Value = Convert.ToDateTime(Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Fecha_Expira_Contrasenia].ToString());
                        Txt_Comentarios.Text = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Comentario].ToString();
                        Cmb_Caja.SelectedValue = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Caja_ID].ToString();
                    }
                    else
                    {
                        Txt_Usuario_ID.Text = "";
                        Cmb_Estatus.SelectedValue = "";
                        Txt_Nombre_Usuario.Text = "";
                        Txt_Login.Text = "";
                        Txt_Password.Text = "";
                        Txt_Correo.Text = "";
                        Cmb_Rol.SelectedValue = "";
                        Dtp_Fecha_Baja.Value = DateTime.Now;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Grid_Usuarios_DoubleClick
        //DESCRIPCIÓN:Al seleccionar un regristro se llenaran los campos con la informacion adecuada
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Grid_Usuarios_DoubleClick(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = false;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
            Txt_Descripcion_Busqueda.Text = "";
            Fra_Datos_Generales.Visible = true;
            Fra_Login.Visible = true; 
        }
        #endregion

    }
}
