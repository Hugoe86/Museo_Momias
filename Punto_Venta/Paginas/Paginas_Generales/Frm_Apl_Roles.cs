using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Erp_Apl_Roles.Negocio;
using Erp_Cat_Menus.Negocio;
using Erp.Constantes;
using Erp.Metodos_Generales;
using Erp.Validador;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Apl_Roles : Form
    {
        #region "Variables Globales"

        Validador_Generico Validador;

        #endregion

        #region Page_Load

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Frm_Apl_Roles
        ///DESCRIPCIÓN  : Carga los elementos del formulario
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 12:20 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public Frm_Apl_Roles()
        {
            InitializeComponent();
            Inicializar_Controles();
            Validador = new Validador_Generico(Error_Provider);
            Rellena_Combo_Busqueda();
        }

        private void Frm_Apl_Roles_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Roles", this);
            Error_Provider.Clear();
        }

        #endregion Page_Load

        #region Metodos_Generales

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Inicializar_Controles
        ///DESCRIPCIÓN  : cofigura el formulario
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 21/Feb/2013 01:24 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Inicializar_Controles()
        {
            try
            {
                Limpiar_Controles();
                Habilitar_Controles("Inicial");
                Consultar_Roles();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Limpiar_Controles
        ///DESCRIPCIÓN  : Limpia los elementos del formulario
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 12:27 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Limpiar_Controles()
        {
            try
            {
                //  Cajas de texto
                Txt_Rol_Id.Text = "";
                Txt_Nombre_Rol.Text = "";
                Txt_Descripcion_Rol.Text = "";

                //  Combos
                Cmb_Estatus.SelectedIndex = 0;

                //  grid
                Grid_Acceso.Rows.Clear();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Habilitar_Controles
        ///DESCRIPCIÓN  :configura los botones
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 21/Feb/2013 01:01 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Habilitar_Controles(String Operacion)
        {
            Boolean Estatus = false;
            if (Fra_Buscar.Visible)
            {
                Fra_Buscar.Visible = false;
                Fra_Buscar.Enabled = false;
                Grb_Generales.Visible = true;
                Fra_Buscar.Enabled = true;
            }
            switch (Operacion)
            {
                case "Inicial":
                    //Hacemos visible el frame de datos generales
                    Grb_Generales.Visible = true;

                    //  se habilitan los botones
                    Btn_Nuevo.Enabled = true;
                    Btn_Modificar.Enabled = true;
                    Btn_Eliminar.Enabled = true;
                    Btn_Buscar.Enabled = true;
                    Btn_Salir.Enabled = true;

                    //  se asignan los nombres
                    Btn_Nuevo.Text = "Nuevo";
                    Btn_Modificar.Text = "Modificar";
                    Btn_Eliminar.Text = "Eliminar";
                    Btn_Salir.Text = "Salir";

                    //  asigna el icono a los boton
                    Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                    Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                    Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
                    Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;

                    Estatus = false;
                    break;

                case "Nuevo":
                    //Hacemos visible el frame de datos generales
                    Grb_Generales.Visible = true;

                    //  se desabilitan los botones
                    Btn_Modificar.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                    Btn_Buscar.Enabled = false;

                    //  se habilitan los botones
                    Btn_Nuevo.Enabled = true;
                    Btn_Salir.Enabled = true;

                    //  se asignan los nombres
                    Btn_Nuevo.Text = "Dar de alta";
                    Btn_Salir.Text = "Cancelar";

                    //  cambia el icono del boton
                    Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                    Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;

                    Estatus = true;
                    break;

                case "Modificar":
                    //Hacemos visible el frame de datos generales
                    Grb_Generales.Visible = true;

                    //  se desabilitan los botones
                    Btn_Nuevo.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                    Btn_Buscar.Enabled = false;

                    //  se habilitan los botones
                    Btn_Modificar.Enabled = true;
                    Btn_Salir.Enabled = true;

                    //  se asignan los nombres
                    Btn_Modificar.Text = "Actualizar";
                    Btn_Salir.Text = "Cancelar";

                    //  cambia el icono del boton
                    Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                    Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;

                    Estatus = true;
                    break;
            }

            Error_Provider.Clear();
            Txt_Nombre_Rol.Enabled = Estatus;
            Txt_Descripcion_Rol.Enabled = Estatus;
            Cmb_Estatus.Enabled = Estatus;

            //  grids
            Grid_Roles.Enabled = !Estatus;
            Grid_Acceso.Enabled = Estatus;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Rellena_Combo_Busqueda
        ///DESCRIPCIÓN  : Rellena el combo box de las busquedas.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Rellena_Combo_Busqueda()
        {
            DataTable Dt_Campos = new DataTable();
            Dt_Campos.Columns.Add("Valor");
            Dt_Campos.Columns.Add("Descripcion");
            Dt_Campos.Rows.Add(new String[] { "0", "<-SELECCIONE->" });
            Dt_Campos.Rows.Add(new String[] { Apl_Roles.Campo_Nombre, "NOMBRE" });
            Dt_Campos.Rows.Add(new String[] { Apl_Roles.Campo_Descripcion, "DESCRIPCION" });
            Cmb_Busqueda_Tipo.DataSource = Dt_Campos;
            Cmb_Busqueda_Tipo.DisplayMember = "Descripcion";
            Cmb_Busqueda_Tipo.ValueMember = "Valor";
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Habilita_Verticalmente
        ///DESCRIPCIÓN  : Habilita o deshabilita los checkbox del grid verticalmente.
        ///PARAMENTROS  : 1. Grid_Copia_Accesos, GridView del que se va habilitar o deshabilitar
        ///                                 los checkbox.
        ///               2. Columna, Indice que indica la columna del grid.
        ///               3. Fila, Indice que indica la fila del grid.
        ///               4. Valor, Variable boleana que establece si se habilita o deshabilita 
        ///                                 el checkbox.
        ///               5. Condicion, Variable String que determina hasta donde avanzara
        ///                                 verticalmente.
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 07/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Habilita_Verticalmente(DataGridView Grid_Copia_Accesos, int Columna, int Fila, bool Valor, String Condicion)
        {
            DataGridViewCheckBoxCell Check_Box_Cell = new DataGridViewCheckBoxCell();

            for (int i = Fila; i < Grid_Copia_Accesos.RowCount; i++)
            {
                if (Grid_Copia_Accesos.Rows[i].Cells[Columna] is DataGridViewCheckBoxCell)
                {
                    Check_Box_Cell = Grid_Copia_Accesos.Rows[i].Cells[Columna] as DataGridViewCheckBoxCell;
                    if (Grid_Copia_Accesos.Rows[i].Cells["TIPO"].Value.ToString().Equals(Condicion))
                    {
                        break;
                    }
                    else
                    {
                        Check_Box_Cell.Value = Valor;
                        if (Grid_Copia_Accesos.Columns[Columna].HeaderText.Equals("Habilitar"))
                        {
                            Habilita_Horizontalmente(Grid_Copia_Accesos, Columna + 1, i, Valor);
                        }
                    }
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Habilita_Horizontalmente
        ///DESCRIPCIÓN  : Habilita o deshabilita los checkbox del grid horizontalmente.
        ///PARAMENTROS  : 1. Grid_Copia_Accesos, GridView del que se va habilitar o deshabilitar
        ///                                 los checkbox.
        ///               2. Columna, Indice que indica la columna del grid.
        ///               3. Fila, Indice que indica la fila del grid.
        ///               4. Valor, Variable boleana que establece si se habilita o deshabilita 
        ///                                 el checkbox.
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 07/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Habilita_Horizontalmente(DataGridView Grid_Copia_Accesos, int Columna, int Fila, bool Valor)
        {
            DataGridViewCheckBoxCell Check_Box_Cell = new DataGridViewCheckBoxCell();

            for (int j = Columna; j < Grid_Copia_Accesos.ColumnCount; j++)
            {
                if (Grid_Copia_Accesos.Rows[Fila].Cells[j] is DataGridViewCheckBoxCell)
                {
                    Check_Box_Cell = Grid_Copia_Accesos.Rows[Fila].Cells[j] as DataGridViewCheckBoxCell;
                    Check_Box_Cell.Value = Valor;
                }
            }
        }

        #region Consultas

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Roles
        ///DESCRIPCIÓN  : Consultara todos los roles de la base de datos
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 01:45 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Consultar_Roles()
        {
            Cls_Apl_Roles_Negocio Rs_Consulta_Roles = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Consulta = new DataTable();
            int Indice = 0;

            Rs_Consulta_Roles.P_Tipo = "ESCRITORIO";
            Dt_Consulta = Rs_Consulta_Roles.Consultar_Roles();

            Grid_Roles.Rows.Clear();

            if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
            {
                foreach (DataRow Renglon in Dt_Consulta.Rows)
                {
                    Grid_Roles.Rows.Add();
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Rol_Id].Value = Renglon[Apl_Roles.Campo_Rol_Id];
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Nombre].Value = Renglon[Apl_Roles.Campo_Nombre];
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Descripcion].Value = Renglon[Apl_Roles.Campo_Descripcion];
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Estatus].Value = Renglon[Apl_Roles.Campo_Estatus];
                    Indice++;
                }
                Grid_Roles.Columns[Apl_Roles.Campo_Rol_Id].Visible = false;
            }
            else
            {
                Grid_Roles.Refresh();
            }

            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Roles);// se asigna el tipo de letra y tamaño
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Roles
        ///DESCRIPCIÓN  : Consultara todos los roles de la base de datos
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 01:45 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Consultar_Roles(String Campo, String Valor)
        {
            Cls_Apl_Roles_Negocio Rs_Consulta_Roles = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Consulta = new DataTable();
            int Indice = 0;

            switch (Campo)
            {
                case Apl_Roles.Campo_Nombre:
                    Rs_Consulta_Roles.P_Nombre = Valor;
                    break;
                case Apl_Roles.Campo_Descripcion:
                    Rs_Consulta_Roles.P_Descripcion = Valor;
                    break;
            }
            Rs_Consulta_Roles.P_Tipo = "ESCRITORIO";
            Dt_Consulta = Rs_Consulta_Roles.Consultar_Roles();

            Grid_Roles.Rows.Clear();

            if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
            {
                foreach (DataRow Renglon in Dt_Consulta.Rows)
                {
                    Grid_Roles.Rows.Add();
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Rol_Id].Value = Renglon[Apl_Roles.Campo_Rol_Id];
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Nombre].Value = Renglon[Apl_Roles.Campo_Nombre];
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Descripcion].Value = Renglon[Apl_Roles.Campo_Descripcion];
                    Grid_Roles.Rows[Indice].Cells[Apl_Roles.Campo_Estatus].Value = Renglon[Apl_Roles.Campo_Estatus];
                    Indice++;
                }
                Grid_Roles.Columns[Apl_Roles.Campo_Rol_Id].Visible = false;
            }
            else
            {
                Grid_Roles.Refresh();
            }

            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Roles);// se asigna el tipo de letra y tamaño
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Acceso
        ///DESCRIPCIÓN  : Consultara todos los roles de la base de datos
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 21/Feb/2013 01:45 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Consultar_Acceso_Menus(MenuStrip Menu_Estructura, String Rol_Id)
        {
            Cls_Apl_Roles_Negocio Rs_Roles_Accesos = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Consulta_Roles_Accesos = new DataTable();
            ToolStripMenuItem Menu_Auxiliar_Nivel_1;
            ToolStripMenuItem Menu_Auxiliar_Nivel_2;
            int Indice = 0;

            //  se limpia el grid
            Grid_Acceso.Rows.Clear();

            //   consulta si existen relacion con los accesos a los menus
            if (!String.IsNullOrEmpty(Rol_Id))
            {
                Rs_Roles_Accesos.P_Rol_Id = Rol_Id;
                Dt_Consulta_Roles_Accesos = Rs_Roles_Accesos.Consultar_Acceso_Roles();
            }

            Grid_Acceso.ScrollBars = ScrollBars.None;
            foreach (Object Menu in Menu_Estructura.Items)
            {
                //  se valida que sea un menu
                if (Menu is ToolStripMenuItem)
                {
                    //  se convierte el ToolStripMenuItem
                    Menu_Auxiliar_Nivel_1 = (ToolStripMenuItem)Menu;

                    Grid_Acceso.Rows.Add();
                    Grid_Acceso.Rows[Indice].Cells["MENU"].Value = Menu.ToString();
                    Cargar_Opciones_Acceso(Grid_Acceso, Dt_Consulta_Roles_Accesos, Menu.ToString(), Indice);    //  se consultan los accesos al menu
                    Grid_Acceso.Rows[Indice].Cells["TIPO"].Value = "MENU";
                    Cargar_Propiedades_Grid_Acceso(Grid_Acceso, Indice, Color.LightGray, "MENU");
                    Indice++;

                    //  se consultan los submenus
                    foreach (Object Sub_Menu_Nivel_1 in Menu_Auxiliar_Nivel_1.DropDownItems)
                    {
                        if (Sub_Menu_Nivel_1 is ToolStripMenuItem)
                        {
                            Grid_Acceso.Rows.Add();
                            Grid_Acceso.Rows[Indice].Cells["SUB_MENU"].Value = Sub_Menu_Nivel_1.ToString();
                            Cargar_Opciones_Acceso(Grid_Acceso, Dt_Consulta_Roles_Accesos, Sub_Menu_Nivel_1.ToString(), Indice);    //  se consultan los accesos al menu
                            Grid_Acceso.Rows[Indice].Cells["TIPO"].Value = "SUBMENU";
                            Indice++;

                            //  se convierte el ToolStripMenuItem
                            Menu_Auxiliar_Nivel_2 = (ToolStripMenuItem)Sub_Menu_Nivel_1;
                            int Cont_Sub_Sub_Menu = 0;

                            foreach (Object Sub_Menu_Nivel_2 in Menu_Auxiliar_Nivel_2.DropDownItems)
                            {
                                if (Sub_Menu_Nivel_2 is ToolStripMenuItem)
                                {
                                    Grid_Acceso.Rows.Add();
                                    Grid_Acceso.Rows[Indice].Cells["SUB_SUB_MENU"].Value = Sub_Menu_Nivel_2.ToString();
                                    Cargar_Opciones_Acceso(Grid_Acceso, Dt_Consulta_Roles_Accesos, Sub_Menu_Nivel_2.ToString(), Indice);    //  se consultan los accesos al menu
                                    Grid_Acceso.Rows[Indice].Cells["TIPO"].Value = "SUBSUBMENU";

                                    if (Cont_Sub_Sub_Menu == 0)
                                    {
                                        Cargar_Propiedades_Grid_Acceso(Grid_Acceso, Indice - 1, Color.LightGray, "SUB_MENU");
                                        Cont_Sub_Sub_Menu++;
                                    }

                                    Indice++;
                                }
                            }
                        }
                    }
                }
            }
            Grid_Acceso.ScrollBars = ScrollBars.Both;

            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Roles);// se asigna el tipo de letra y tamaño
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cargar_Opciones_Acceso
        ///DESCRIPCIÓN  : Consultara todos los roles de la base de datos
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 25/Feb/2013 12:15 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Cargar_Opciones_Acceso(DataGridView Grid_Acceso, DataTable Dt_Consulta_Roles_Accesos, String Nombre_Menu, int Indice)
        {
            //  se consulta si tiene el menu habilitado
            if (Dt_Consulta_Roles_Accesos != null && Dt_Consulta_Roles_Accesos.Rows.Count > 0)
            {
                foreach (DataRow Renglon_Accesos in Dt_Consulta_Roles_Accesos.Rows)
                {
                    if (Nombre_Menu == Renglon_Accesos[Apl_Acceso.Campo_Nombre_Menu].ToString())
                    {
                        if (Renglon_Accesos[Apl_Acceso.Campo_Habilitado].ToString().Trim() == "S")
                            Grid_Acceso.Rows[Indice].Cells["HABILITAR"].Value = true;

                        if (Renglon_Accesos[Apl_Acceso.Campo_Alta].ToString().Trim() == "S")
                            Grid_Acceso.Rows[Indice].Cells["HABILITAR_ALTA"].Value = true;

                        if (Renglon_Accesos[Apl_Acceso.Campo_Cambio].ToString().Trim() == "S")
                            Grid_Acceso.Rows[Indice].Cells["HABILITAR_CAMBIO"].Value = true;

                        if (Renglon_Accesos[Apl_Acceso.Campo_Eliminar].ToString().Trim() == "S")
                            Grid_Acceso.Rows[Indice].Cells["HABILITAR_ELIMINAR"].Value = true;

                        if (Renglon_Accesos[Apl_Acceso.Campo_Consultar].ToString().Trim() == "S")
                            Grid_Acceso.Rows[Indice].Cells["HABILITAR_CONSULTA"].Value = true;
                        break;
                    }
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cargar_Color_Grid_Acceso
        ///DESCRIPCIÓN  : Carga el aspecto visual del grid de accesos
        ///PARAMENTROS  : Grid_Acceso: el grid al que se le agregara el formato
        ///               Indice_Renglon: la posicion de la renglon del grid
        ///               Tipo_Color: el color que se utilizara para rellenar
        ///               Tipo_Menu: el tipo (Menu, submenu) que se rellenara
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 25/Feb/2013 12:38 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Cargar_Propiedades_Grid_Acceso(DataGridView Grid_Acceso, int Indice_Renglon, Color Tipo_Color, String Tipo_Menu)
        {
            int Indice_Comienzo = 0;//  indica en que columna comenzara a rellenar

            //  camparacion para indicar en que columna comenzara
            if (Tipo_Menu == "MENU")
                Indice_Comienzo = 0;
            else
                Indice_Comienzo = 1;

            //  comienza a rellenar
            for (int Cnt_For = Indice_Comienzo; Cnt_For < Grid_Acceso.ColumnCount; Cnt_For++)
            {
                Grid_Acceso.Rows[Indice_Renglon].Cells[Cnt_For].Style.BackColor = Tipo_Color;
            }
        }

        #endregion Consultas

        #region Acciones

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Validar_Elementos
        ///DESCRIPCIÓN  : ingresa un registro en la base de datos
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 04:40 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public Boolean Alta()
        {
            Boolean Estatus = false;
            Cls_Apl_Roles_Negocio Rs_Alta = new Cls_Apl_Roles_Negocio();

            Rs_Alta.P_Nombre = Txt_Nombre_Rol.Text;
            Rs_Alta.P_Descripcion = Txt_Descripcion_Rol.Text;
            Rs_Alta.P_Estatus = Cmb_Estatus.SelectedItem.ToString();
            Rs_Alta.P_Grid = Grid_Acceso;

            // Alta del rol
            Rs_Alta.Alta_Rol();
            Estatus = true;

            return Estatus;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Validar_Elementos
        ///DESCRIPCIÓN  : modifica el registro seleccionado
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 21/Feb/2013 12:45 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public Boolean Modificar()
        {
            Boolean Estatus = false;
            Cls_Apl_Roles_Negocio Rs_Modificar = new Cls_Apl_Roles_Negocio();

            Rs_Modificar.P_Rol_Id = Txt_Rol_Id.Text;
            Rs_Modificar.P_Nombre = Txt_Nombre_Rol.Text;
            Rs_Modificar.P_Descripcion = Txt_Descripcion_Rol.Text;
            Rs_Modificar.P_Estatus = Cmb_Estatus.SelectedItem.ToString();
            Rs_Modificar.P_Grid = Grid_Acceso;
            Rs_Modificar.Modificar_Rol();
            Estatus = true;

            return Estatus;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Validar_Elementos
        ///DESCRIPCIÓN  : modifica el registro seleccionado
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 21/Feb/2013 12:45 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public Boolean Eliminar()
        {
            Boolean Estatus = false;
            Cls_Apl_Roles_Negocio Rs_Eliminar = new Cls_Apl_Roles_Negocio();

            Rs_Eliminar.P_Rol_Id = Txt_Rol_Id.Text;
            Rs_Eliminar.Eliminar_Rol();
            Estatus = true;

            return Estatus;
        }

        #endregion Acciones

        #endregion Metodos_Generales

        #region Grid

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Grid_Roles_CellClick
        ///DESCRIPCIÓN  : Carga la informacion del grid en las cajas de texto
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 01:01 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Grid_Roles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Indice = 0;
            try
            {
                Indice = Grid_Roles.CurrentRow.Index;
                //Limpiar_Controles();
                Txt_Rol_Id.Text = Grid_Roles.Rows[Indice].Cells[0].Value.ToString();
                Txt_Nombre_Rol.Text = Grid_Roles.Rows[Indice].Cells[1].Value.ToString();
                Txt_Descripcion_Rol.Text = Grid_Roles.Rows[Indice].Cells[3].Value.ToString();
                Cmb_Estatus.Text = Grid_Roles.Rows[Indice].Cells[2].Value.ToString();

                Consultar_Acceso_Menus(this.MdiParent.MainMenuStrip, Txt_Rol_Id.Text);
                Grid_Acceso.Enabled = false; //  se desabilita el grid para que no se pueda cambiar, solo hasta que se ejecute el evento de btn_modificar
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Grid_Acceso_CellContentClick
        ///DESCRIPCIÓN  : Cuando se selecciona la celda, comprueba si tiene un checkbox, 
        ///               si es asi, comprueba si esta afecta a otros checkbox, entonces
        ///               los habilita o deshabilita segun sea el caso.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 07/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Grid_Acceso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell Check_Box_Cell = new DataGridViewCheckBoxCell();
            DataGridViewTextBoxCell Text_Box_Cell = new DataGridViewTextBoxCell();
            DataGridView Grid_Copia_Accesos = (DataGridView)sender;
            //String Valor = "";
            String Tipo_Menu = "";
            String Nombre_Columna = "";
            try
            {
                if (Grid_Copia_Accesos.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
                {
                    Tipo_Menu = Grid_Copia_Accesos.Rows[e.RowIndex].Cells["TIPO"].Value.ToString();
                    Nombre_Columna = Grid_Copia_Accesos.Columns[e.ColumnIndex].HeaderText;
                    Check_Box_Cell = Grid_Copia_Accesos.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                    if (Check_Box_Cell.Value == null)
                        Check_Box_Cell.Value = false;
                    switch (Check_Box_Cell.Value.ToString())
                    {
                        case "True":
                            Check_Box_Cell.Value = false;
                            break;
                        case "False":
                            Check_Box_Cell.Value = true;
                            break;
                    }
                    //Valor = Check_Box_Cell.Value.ToString();

                    if (Nombre_Columna.Equals("Habilitar"))
                    {
                        Habilita_Horizontalmente(Grid_Copia_Accesos, e.ColumnIndex + 1, e.RowIndex, Convert.ToBoolean(Check_Box_Cell.Value));
                        Habilita_Verticalmente(Grid_Copia_Accesos, e.ColumnIndex, e.RowIndex + 1, Convert.ToBoolean(Check_Box_Cell.Value), Tipo_Menu);
                    }
                    else
                    {
                        Habilita_Verticalmente(Grid_Copia_Accesos, e.ColumnIndex, e.RowIndex + 1, Convert.ToBoolean(Check_Box_Cell.Value), Tipo_Menu);
                    }
                }
            }
            catch
            { }
            //MessageBox.Show(this, "Se dio clic en Columna: " + e.ColumnIndex + " Fila:" + e.RowIndex + "\nValor: " + Valor + "\nTipo: " + Tipo_Menu + "\nColumna: " + Nombre_Columna);
        }

        #endregion Grid

        #region Eventos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Nuevo_Click
        ///DESCRIPCIÓN  : crea el registro del rol
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 01:05 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Nuevo.Text == "Nuevo")
                {
                    Habilitar_Controles("Nuevo");
                    Limpiar_Controles();
                    Consultar_Acceso_Menus(this.MdiParent.MainMenuStrip, "");
                    Txt_Rol_Id.Text = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Apl_Roles.Tabla_Apl_Roles, Apl_Roles.Campo_Rol_Id, null, 5);
                }
                else
                {
                    if (this.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        if (Alta())
                        {
                            Inicializar_Controles();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Alta Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
        ///DESCRIPCIÓN  : Modifica un registro existente
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 21/Feb/2013 01:30 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Modificar.Text == "Modificar")
                {
                    if (Txt_Rol_Id.Text.Trim() != "")
                    {
                        Habilitar_Controles("Modificar");
                    }
                    else
                    {
                        MessageBox.Show(this, "Favor de seleccionar un registro de la lista.", "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (this.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        if (Modificar())
                        {
                            Inicializar_Controles();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Eliminar_Click
        ///DESCRIPCIÓN  : Elimina un registro existente
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 01:15 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_Rol_Id.Text.Trim() != "")
                {
                    if (MessageBox.Show(this, "¿Esta seguro que desea eliminar el registro del rol " + Grid_Roles.Rows[Grid_Roles.CurrentRow.Index].Cells[Apl_Roles.Campo_Nombre].Value.ToString() + "?.", "Modificar Cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Eliminar())
                        {
                            Inicializar_Controles();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Favor de seleccionar un registro de la lista.", "Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Eliminar_Click
        ///DESCRIPCIÓN  : Se saldra del formulario
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 20/Feb/2013 01:24 p.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Salir.Text == "Salir")
                {
                    this.Close();
                }
                else
                {
                    Inicializar_Controles();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN  : Muestra u oculta el campo de descripción o el combo de giros.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Cmb_Busqueda_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex < 1)
            {
                Btn_Busqueda.Enabled = false;
                Txt_Descripcion_Busqueda.Enabled = false;
            }
            else
            {
                Btn_Busqueda.Enabled = true;
                Txt_Descripcion_Busqueda.Enabled = true;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Buscar_Click
        ///DESCRIPCIÓN  : Muestra el panel de busqueda.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Fra_Buscar.Enabled = true;
            Grb_Generales.Visible = false;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
            Txt_Descripcion_Busqueda.Enabled = false;
            Error_Provider.Clear();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Regresar_Click
        ///DESCRIPCIÓN  : Oculta el panel de busqueda.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = false;
            Fra_Buscar.Enabled = false;
            Grb_Generales.Visible = true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Busqueda_Click
        ///DESCRIPCIÓN  : Realiza la busqueda del rol.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Txt_Descripcion_Busqueda.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Favor de rellenar el campo descripción.", "Búsqueda Rol", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Consultar_Roles(Cmb_Busqueda_Tipo.SelectedValue.ToString(), Txt_Descripcion_Busqueda.Text);
        }

        #endregion Eventos

        #region Validaciones

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cmb_Requerido_Validating
        ///DESCRIPCIÓN  : Valida que el combo box sea seleccionado un elemento
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 01/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Cmb_Requerido_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Combo_Requerido(e, (ComboBox)sender, true);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Alfanumerico_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres Alfanuméricos.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Alfanumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
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

        #endregion Validaciones        

        
    }
}