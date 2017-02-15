using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using Erp_Cat_Contactos.Negocio;
using Erp_Cat_Clientes.Negocio;
using Erp.Constantes;
using Erp_Cat_Proveedores.Negocio;
using Erp.Validador;
using ERP_BASE.Properties;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Cat_Contactos : Form
    {
       #region Page_Load

        Validador_Generico Validador;

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Frm_Cat_Contactos
        ///DESCRIPCIÓN  : Carga los elementos del formulario
        ///PARAMENTROS  :
        ///CREO         : Alejandro Leyva Alvarado
        ///FECHA_CREO   : 25 Febrero 2013 10:52 a.m.
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public Frm_Cat_Contactos()
        {
            InitializeComponent();
        }

        private void Frm_Cat_Contactos_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Contactos", this);
            Cls_Cat_Clientes_Negocio Cls_Clientes = new Cls_Cat_Clientes_Negocio();
            Cls_Cat_Proveedores_Negocio Cls_Proveedores = new Cls_Cat_Proveedores_Negocio();
            Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Clientes, Cls_Clientes.Consultar_Clientes(), Cat_Adm_Clientes.Campo_Nombre_Corto, Cat_Adm_Clientes.Campo_Cliente_Id);
            Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Proveedor, Cls_Proveedores.Consultar_Proveedores(), Cat_Adm_Proveedores.Campo_Nombre_Corto, Cat_Adm_Proveedores.Campo_Proveedor_Id);
            Cls_Metodos_Generales.Limpia_Controles(this);
            Fra_Campos.Visible = true;
            Fra_Buscar.Visible = false;
            Consultar_Contactos();
            Rellena_Combo_Busqueda();      
            Validador = new Validador_Generico(Erp_Error_Provider);
        }
            
        #endregion Page_Load

        #region Metodos_Generales
     
       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Consultar_Contactos
       ///DESCRIPCIÓN  : Consultara todos los roles de la base de datos
       ///PARAMENTROS  :
       ///CREO         : Hugo Enrique Ramírez Aguilera
       ///FECHA_CREO   : 20/Feb/2013 01:45 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       public void Consultar_Contactos()
       {
           try
           {
               Cls_Cat_Contactos_Negocio Consulta_Contacto = new Cls_Cat_Contactos_Negocio();
               Cls_Metodos_Generales.Rellena_GridView(Consulta_Contacto.Consultar_Contactos(), Grid_Contactos, new String[] { Cat_Adm_Contactos.Campo_Nombre_Completo, Cat_Adm_Contactos.Campo_Tipo, Cat_Adm_Contactos.Campo_Tipo_Contacto, Cat_Adm_Contactos.Campo_Estatus});
           }
           catch (Exception E)
           {
               MessageBox.Show(null, E.ToString(), "Error - Consultar Contacto", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }



       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Consultar
       ///DESCRIPCIÓN  : Carga el contacto buscado.
       ///PARAMENTROS  :   1. Campo. Parametro de busqueda del contacto, hace referencia
       ///                           al campo de la tabla.
       ///                 2. Valor. Valor del parametro de busqueda.
       ///CREO         : Luis Alberto Salas Garcia
       ///FECHA_CREO   : 28/Feb/2013
       ///MODIFICO     :Alejandro Leyva Alvarado
       ///FECHA_MODIFICO:10/abril/2013
       ///CAUSA_MODIFICACIÓN:ajustar a formulario
       ///*******************************************************************************
       private void Consultar(String Campo, String Valor)
       {
           try
           {
               Cls_Cat_Contactos_Negocio Consulta_Contacto = new Cls_Cat_Contactos_Negocio();
               switch (Campo)
               {
                   case Cat_Adm_Contactos.Campo_Nombre_Completo:
                       Consulta_Contacto.P_Nombre_Completo = Valor;
                       break;
                   case Cat_Adm_Contactos.Campo_Tipo_Contacto:
                       Consulta_Contacto.P_Tipo_Contacto = Valor;
                       break;
                   case Cat_Adm_Contactos.Campo_Area:
                       Consulta_Contacto.P_Area = Valor;
                       break;
                   
               }
               Cls_Metodos_Generales.Rellena_GridView(Consulta_Contacto.Consultar_Contactos(), Grid_Contactos, new String[] { Cat_Adm_Contactos.Campo_Nombre_Completo, Cat_Adm_Contactos.Campo_Tipo_Contacto, Cat_Adm_Contactos.Campo_Area });
               if (Grid_Contactos.RowCount == 0)
               {
                   MessageBox.Show(this, "No se encontró ningún contacto con esos datos.", "Búsqueda Contactos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               }
           }
           catch (Exception E)
           {
               MessageBox.Show(null, E.ToString(), "Error - Búsqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
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
           Dt_Campos.Rows.Add(new String[] { Cat_Adm_Contactos.Campo_Nombre_Completo, "NOMBRE " });
           Dt_Campos.Rows.Add(new String[] { Cat_Adm_Contactos.Campo_Tipo_Contacto, "TIPO CONTACTO" });
           Dt_Campos.Rows.Add(new String[] { Cat_Adm_Contactos.Campo_Area, "AREA" });
           
           Cmb_Busqueda_Tipo.DataSource = Dt_Campos;
           Cmb_Busqueda_Tipo.DisplayMember = "Descripcion";
           Cmb_Busqueda_Tipo.ValueMember = "Valor";
       } 

       ////*************************************************************************************
       ////NOMBRE DE LA FUNCIÓN: Validar_Alta
       ////DESCRIPCIÓN:valida que todos los datos que son requeridos esten proporcionados por el usuario
       ////PARÁMETROS :
       ////CREO       : Sergio Manuel Gallardo Andrade
       ////FECHA_CREO : 22-Febrero-2013
       ////MODIFICO:
       ////FECHA_MODIFICO
       ////CAUSA_MODIFICACIÓN
       ////*************************************************************************************
       //private Boolean Validar_Alta()
       //{
       //    Cls_Cat_Contactos_Negocio Rs_Consulta_Usuario = new Cls_Cat_Contactos_Negocio();
       //    DataTable Dt_Usuario = new DataTable();
       //    Boolean Datos_Validados = true;
       //    String Faltan = "Es necesario:\n";
       //    DateTimePicker Fecha_Usuario = new DateTimePicker();
       //    DateTimePicker Fecha_Actual = new DateTimePicker();
       //    try
       //    {
       //        if (Cmb_Clientes.SelectedIndex <= 0)
       //        {
       //            Datos_Validados = false;
       //            Faltan = Faltan + " Introducir el Cliente \n";
       //        }
       //        if (Cmb_Proveedor.SelectedIndex <= 0)
       //        {
       //            Datos_Validados = false;
       //            Faltan = Faltan + " Introducir el Proveedor \n";
       //        }
       //        if (Cmb_Estatus.SelectedIndex < 0)
       //        {
       //            Datos_Validados = false;
       //            Faltan = Faltan + " Introducir un Estatus  \n";
       //        }
       //        if (Cmb_Tipo_Contacto.SelectedIndex < 0)
       //        {
       //            Datos_Validados = false;
       //            Faltan = Faltan + " Introducir un Tipo de Contacto  \n";
       //        }
       //        if (Txt_Nombre.Text.Length <= 0)
       //        {
       //            Datos_Validados = false;
       //            Faltan = Faltan + " Introducir el nombre del contacto \n";
       //        }
       //        if (Txt_Apellido_Paterno.Text.Length <= 0)
       //        {
       //            Datos_Validados = false;
       //            Faltan = Faltan + " Introducir el Apellido Paterno \n";
       //        }
       //        if (Txt_Apellido_Materno.Text.Length <= 0)
       //        {
       //            Datos_Validados = false;
       //            Faltan = Faltan + " Introducir Apellido Materno \n";
       //        }
              
       //        //if (Txt_Password.Text.Length <= 7)
       //        //{
       //        //    Datos_Validados = false;
       //        //    Faltan = Faltan + " Introducir un password del usuario que minimo cuente con 8 caracteres \n";
       //        //}
       //        //if (Txt_Confirmar.Text.Length <= 7)
       //        //{
       //        //    Datos_Validados = false;
       //        //    Faltan = Faltan + " Introducir un password del usuario que minimo cuente con 8 caracteres \n";
       //        //}
       //        //if (Txt_Password.Text.Length > 7 && Txt_Confirmar.Text.Length > 7)
       //        //{
       //        //    if (Txt_Password.Text != Txt_Confirmar.Text)
       //        //    {
       //        //        Datos_Validados = false;
       //        //        Faltan = Faltan + "El password y la confirmacion no son iguales \n";
       //        //    }
       //        //}
       //        //if (Cmb_Rol.SelectedIndex <= 0)
       //        //{
       //        //    Datos_Validados = false;
       //        //    Faltan = Faltan + " introduce el rol del usuario \n";
       //        //}
       //        //Fecha_Usuario.Value = Convert.ToDateTime((Dtp_Fecha_Baja.Value.ToString()));
       //        //Fecha_Actual.Value = DateTime.Now;
       //        //if (Fecha_Actual.Value.CompareTo(Fecha_Usuario.Value) == 1)
       //        //{
       //        //    Datos_Validados = false;
       //        //    Faltan = Faltan + "La fecha Caduca no puede ser menor o igual a la actual \n";
       //        //}
       //        if (Datos_Validados == false)
       //        {
       //            MessageBox.Show(Faltan);
       //        }
       //    }
       //    catch (Exception E)
       //    {
       //        MessageBox.Show(this, E.ToString(), "Erorr - Contactos", MessageBoxButtons.OK, MessageBoxIcon.Error);
       //    }
       //    return Datos_Validados;
       //}
        
        #endregion Metodos_Generales

       #region Eventos

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Txt_Nombre_TextChanged
       ///DESCRIPCIÓN  : Evento de la caja de texto para formar el nombre completo
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 25/Feb/2013 12:12 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************

       private void Txt_Nombre_TextChanged(object sender, EventArgs e)
       {
           Txt_Nombre_Completo.Text = Txt_Nombre.Text.Trim() + "  " + Txt_Apellido_Paterno.Text + "  " + Txt_Apellido_Materno.Text;
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Txt_Apellido_Paterno_TextChanged
       ///DESCRIPCIÓN  : Evento de la caja de texto para formar el nombre completo
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 25/Feb/2013 12:12 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Txt_Apellido_Paterno_TextChanged(object sender, EventArgs e)
       {
           Txt_Nombre_Completo.Text = Txt_Nombre.Text + "  " + Txt_Apellido_Paterno.Text.Trim() + "  " + Txt_Apellido_Materno.Text;
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Txt_Apellido_Materno_TextChanged
       ///DESCRIPCIÓN  : Evento de la caja de texto para formar el nombre completo
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 25/Feb/2013 12:12 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************

       private void Txt_Apellido_Materno_TextChanged(object sender, EventArgs e)
       {
           Txt_Nombre_Completo.Text = Txt_Nombre.Text + "  " + Txt_Apellido_Paterno.Text + "  " + Txt_Apellido_Materno.Text.Trim();
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Btn_Nuevo_Click
       ///DESCRIPCIÓN  : Evento del boton  Nuevo para dar de alta registros
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 26/Feb/2013 11:12 a.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Btn_Nuevo_Click(object sender, EventArgs e)
       {
           if (Btn_Nuevo.Text.Equals("Nuevo"))
           {
             
               Cls_Metodos_Generales.Habilita_Deshabilita_Controles(this, true);
               Cls_Metodos_Generales.Limpia_Controles(this);
               Fra_Buscar.Visible = false;
               Fra_Campos.Visible = true;
               Fra_Contacto.Visible = true;
               Fra_Tipo_Contacto.Visible = true;
               Txt_Nombre_Completo.Enabled = false;
               Btn_Modificar.Enabled = false;
               Btn_Eliminar.Enabled = false;
               Btn_Buscar.Enabled = false;
               Btn_Nuevo.Image = Resources.icono_actualizar;
               
               Btn_Nuevo.Text = "Dar de Alta";
               Btn_Salir.Image = Resources.icono_cancelar;
               Btn_Salir.Text = "Cancelar";
           }
           else if (this.ValidateChildren(ValidationConstraints.Enabled))
           {
               Cls_Cat_Contactos_Negocio Nuevo_Contacto = new Cls_Cat_Contactos_Negocio();
               Nuevo_Contacto.P_Cliente_Id = Cmb_Clientes.SelectedValue.ToString();
               Nuevo_Contacto.P_Estatus = Cmb_Estatus.SelectedItem.ToString();
               Nuevo_Contacto.P_Proveedor_Id = Cmb_Proveedor.SelectedValue.ToString();
               Nuevo_Contacto.P_Nombres = Txt_Nombre.Text;
               Nuevo_Contacto.P_Apellido_Paterno = Txt_Apellido_Paterno.Text;
               Nuevo_Contacto.P_Apellido_Materno = Txt_Apellido_Materno.Text;
               Nuevo_Contacto.P_Nombre_Completo = Txt_Nombre_Completo.Text;
               Nuevo_Contacto.P_Telefono_1 = Txt_Telefono1.Text;
               Nuevo_Contacto.P_Telefono_2 = Txt_Telefono2.Text;
               Nuevo_Contacto.P_Nextel = Txt_Nextel.Text;
               Nuevo_Contacto.P_Puesto = Txt_Puesto.Text;
               Nuevo_Contacto.P_Area = Txt_Area.Text;
               Nuevo_Contacto.P_Tipo_Contacto = Convert.ToString(Cmb_Tipo_Contacto.SelectedItem);
               Nuevo_Contacto.P_Tipo = Txt_Contacto_Area.Text;
               Nuevo_Contacto.Alta_Contacto();

               Btn_Nuevo.Text = "Nuevo";
               Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
               Cls_Metodos_Generales.Limpia_Controles(this);
               Cls_Metodos_Generales.Habilita_Deshabilita_Controles(this, false);
               Btn_Nuevo.Enabled = true;
               Btn_Modificar.Enabled = true;
               Btn_Eliminar.Enabled = true;
               Btn_Salir.Enabled = true;
               Btn_Salir.Text = "Salir";
               Btn_Salir.Image = Resources.icono_salir_2;
               Grid_Contactos.Rows.Clear();
               Consultar_Contactos();
           }
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Btn_Eliminar_Click
       ///DESCRIPCIÓN  : Evento de convertir a mayusculas
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 26/Feb/2013 12:20 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Btn_Eliminar_Click(object sender, EventArgs e)
       {
           Cls_Cat_Contactos_Negocio Contactos = new Cls_Cat_Contactos_Negocio();
           Contactos.P_Contacto_Id = Txt_Contacto_Id.Text;
           Contactos.Eliminar_Contacto();
           Grid_Contactos.Rows.Clear();
           Consultar_Contactos();
           Cls_Metodos_Generales.Limpia_Controles(this);
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
       ///DESCRIPCIÓN  : Evento del boton Modificar
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 26/Feb/2013 12:25 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Btn_Modificar_Click(object sender, EventArgs e)
       {
           if (Btn_Modificar.Text.Equals("Modificar"))
           {
               Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Campos, true);
               Txt_Nombre_Completo.Enabled = false;
               Btn_Modificar.Enabled = true;
               Btn_Eliminar.Enabled = false;
               Btn_Nuevo.Enabled = false;
               Btn_Modificar.Image = Resources.icono_actualizar;
               Btn_Modificar.Text = "Actualizar";
               Btn_Buscar.Enabled = false;
               Btn_Salir.Image = Resources.icono_cancelar;
               Btn_Salir.Text = "Cancelar";
           }
           else
           {
               Cls_Cat_Contactos_Negocio Modificar_Contacto = new Cls_Cat_Contactos_Negocio();
               Modificar_Contacto.P_Contacto_Id = Txt_Contacto_Id.Text;
               Modificar_Contacto.P_Cliente_Id = Cmb_Clientes.SelectedValue.ToString();
               Modificar_Contacto.P_Proveedor_Id = Cmb_Proveedor.SelectedValue.ToString();
               Modificar_Contacto.P_Nombres = Txt_Nombre.Text;
               Modificar_Contacto.P_Apellido_Paterno = Txt_Apellido_Paterno.Text;
               Modificar_Contacto.P_Apellido_Materno = Txt_Apellido_Materno.Text;
               Modificar_Contacto.P_Nombre_Completo = Txt_Nombre_Completo.Text;
               Modificar_Contacto.P_Telefono_1 = Txt_Telefono1.Text;
               Modificar_Contacto.P_Telefono_2 = Txt_Telefono2.Text;
               Modificar_Contacto.P_Nextel = Txt_Nextel.Text;
               Modificar_Contacto.P_Puesto = Txt_Puesto.Text;
               Modificar_Contacto.P_Area = Txt_Area.Text;
               Modificar_Contacto.P_Tipo_Contacto = Convert.ToString(Cmb_Tipo_Contacto.SelectedItem);
               Modificar_Contacto.P_Tipo = Txt_Contacto_Area.Text;
               Modificar_Contacto.P_Estatus = Convert.ToString(Cmb_Estatus.SelectedItem);
               Modificar_Contacto.Modificar_Contacto();
               Btn_Modificar.Text = "Modificar";
               Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
               Cls_Metodos_Generales.Limpia_Controles(Fra_Campos);
               Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Campos, false);
               Btn_Nuevo.Enabled = true;
               Btn_Modificar.Enabled = true;
               Btn_Eliminar.Enabled = true;
               Btn_Salir.Enabled = true;
               Btn_Salir.Text = "Salir";
               Btn_Salir.Image = Resources.icono_salir_2;
               Cmb_Estatus.SelectedIndex = 0;
               Cmb_Tipo_Contacto.SelectedIndex = 0;
               Grid_Contactos.Rows.Clear();
               Consultar_Contactos();
           }
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Grid_Contactos_CellContentClick
       ///DESCRIPCIÓN  : Evento del grid para seleccionar un contacto de la lista
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 26/Feb/2013 12:50 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Grid_Contactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {
           DataGridViewRow row = Grid_Contactos.Rows[e.RowIndex];
           Txt_Contacto_Id.Text = Convert.ToString(row.Cells["CONTACTO_ID"].Value);
           Cmb_Clientes.SelectedValue = Convert.ToString(row.Cells["CLIENTE_ID"].Value);
           Cmb_Proveedor.SelectedValue = Convert.ToString(row.Cells["PROVEEDOR_ID"].Value);
           Txt_Nombre.Text = Convert.ToString(row.Cells["NOMBRES"].Value);
           Txt_Apellido_Paterno.Text = Convert.ToString(row.Cells["APELLIDO_PATERNO"].Value);
           Txt_Apellido_Materno.Text = Convert.ToString(row.Cells["APELLIDO_MATERNO"].Value);
           Txt_Telefono1.Text = Convert.ToString(row.Cells["TELEFONO_1"].Value);
           Txt_Telefono2.Text = Convert.ToString(row.Cells["TELEFONO_2"].Value);
           Txt_Nextel.Text = Convert.ToString(row.Cells["NEXTEL"].Value);
           Txt_Puesto.Text = Convert.ToString(row.Cells["PUESTO"].Value);
           Txt_Area.Text = Convert.ToString(row.Cells["AREA"].Value);
           Txt_Contacto_Area.Text = Convert.ToString(row.Cells["TIPO"].Value);
           Cmb_Estatus.SelectedItem = Convert.ToString(row.Cells["ESTATUS"].Value);
           if (Convert.ToString(row.Cells["TIPO_CONTACTO"].Value) != null)
           {
               Cmb_Tipo_Contacto.SelectedItem = Convert.ToString(row.Cells["TIPO_CONTACTO"].Value);
           }
           else
           {
               Cmb_Tipo_Contacto.Text = "<SELECCIONE>";
           }
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
       ///DESCRIPCIÓN  : Evento del Boton para salir de la ventana
       ///PARAMENTROS  :
       ///CREO         : Alejandro Leyva Alvarado
       ///FECHA_CREO   : 26/Feb/2013 13:30 p.m.
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Btn_Salir_Click(object sender, EventArgs e)
       {
           if (Btn_Salir.Text == "Cancelar")
           {
               Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Campos, false);
               Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Contacto, false);
               Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Tipo_Contacto, false);
               Cls_Metodos_Generales.Limpia_Controles(this);
               Btn_Modificar.Image = Resources.icono_modificar;
               Btn_Modificar.Text = "Modificar";
               Btn_Nuevo.Image = Resources.icono_nuevo;
               Btn_Nuevo.Text = "Nuevo";
               Btn_Salir.Image = Resources.icono_salir_2;
               Btn_Salir.Text = "Salir";
               Btn_Nuevo.Enabled = true;
               Btn_Modificar.Enabled = true;
               Btn_Buscar.Enabled = true;
               Btn_Eliminar.Enabled = true;
               Grid_Contactos.Enabled = true;
               Erp_Error_Provider.Clear();
           }
           else if (Btn_Salir.Text == "Salir")
           {
               this.Close();
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
           }
           else
           {
               Btn_Busqueda.Enabled = true;
               Txt_Descripcion_Busqueda.Visible = true;
               Cmb_Giro_Busqueda.Visible = false;
               if (Cmb_Busqueda_Tipo.SelectedIndex == 3)
               {
                   Txt_Descripcion_Busqueda.Visible = false;
                   Cmb_Giro_Busqueda.Visible = true;
               }
           }
       }
       #endregion Eventos

       #region "Validaciones"

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
       ///NOMBRE DE LA FUNCIÓN: Txt_Alfanumerico_Sin_Convertir_A_Mayusculas_KeyPress
       ///DESCRIPCIÓN  : Permite escribir caracteres Alfanuméricos, pero no convierte a mayusculas.
       ///PARAMENTROS  :
       ///CREO         : Luis Alberto Salas Garcia
       ///FECHA_CREO   : 28/Feb/2013
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Txt_Alfanumerico_Extendido_Sin_Convertir_A_Mayusculas_KeyPress(object sender, KeyPressEventArgs e)
       {
           Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
       }

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
           Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
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

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Txt_Numerico_Nextel_KeyPress
       ///DESCRIPCIÓN  : Permite escribir caracteres numéricos y el carácter '*'.
       ///PARAMENTROS  :
       ///CREO         : Luis Alberto Salas Garcia
       ///FECHA_CREO   : 28/Feb/2013
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Txt_Numerico_Nextel_KeyPress(object sender, KeyPressEventArgs e)
       {
           Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico_Nextel);
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Txt_Nextel_Validating
       ///DESCRIPCIÓN  : Valida que el campo solo caracteres numéricos.
       ///PARAMENTROS  :
       ///CREO         : Luis Alberto Salas Garcia
       ///FECHA_CREO   : 28/Feb/2013
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Txt_Nextel_Validating(object sender, CancelEventArgs e)
       {
           Validador.Validacion_Campo_Nextel(e, (TextBox)sender, false);
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
       ///NOMBRE DE LA FUNCIÓN: Txt_Sitio_Web_Validating
       ///DESCRIPCIÓN  : Valida que la Url del sitio web este escrita correctamente.
       ///PARAMENTROS  :
       ///CREO         : Luis Alberto Salas Garcia
       ///FECHA_CREO   : 28/Feb/2013
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Txt_Sitio_Web_Validating(object sender, CancelEventArgs e)
       {
           Validador.Validacion_Campo_Url(e, (TextBox)sender, false);
       }

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

       #endregion

       private void Btn_Buscar_Click(object sender, EventArgs e)
       {
           Fra_Buscar.Visible = true;
           Fra_Buscar.Enabled = true;
           Fra_Campos.Visible = false;
           Btn_Buscar.Visible = false;
           Btn_Eliminar.Visible = false;
           Btn_Nuevo.Visible = false;
           Btn_Salir.Visible = false;
           Btn_Modificar.Visible = false;
           Cmb_Busqueda_Tipo.SelectedIndex = 0;
           Cmb_Giro_Busqueda.Visible = false;
           Txt_Descripcion_Busqueda.Visible = true;
           Erp_Error_Provider.Clear();
       }
       private void Btn_Regresar_Click(object sender, EventArgs e)
       {
           Fra_Buscar.Visible = false;
           Fra_Campos.Visible = true;
           Fra_Contacto.Visible = true;
           Fra_Tipo_Contacto.Visible = true;
           Btn_Buscar.Visible = true;
           Btn_Eliminar.Visible = true;
           Btn_Nuevo.Visible = true;
           Btn_Salir.Visible = true;
           Btn_Modificar.Visible = true;
           Consultar_Contactos();
       }
       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN: Btn_Busqueda_Click
       ///DESCRIPCIÓN  : Realiza la busqueda del cliente.
       ///PARAMENTROS  :
       ///CREO         : Luis Alberto Salas Garcia
       ///FECHA_CREO   : 28/Feb/2013
       ///MODIFICO     :
       ///FECHA_MODIFICO:
       ///CAUSA_MODIFICACIÓN:
       ///*******************************************************************************
       private void Btn_Busqueda_Click(object sender, EventArgs e)
       {
           if (Cmb_Busqueda_Tipo.SelectedIndex != 3 && Txt_Descripcion_Busqueda.Text.Trim().Length == 0)
           {
               MessageBox.Show(this, "Favor de rellenar el campo descripción.", "Búsqueda Contacto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
           }
           if (Cmb_Busqueda_Tipo.SelectedIndex == 3 && Cmb_Giro_Busqueda.SelectedIndex == 0)
           {
               MessageBox.Show(this, "Favor de seleccionar el contacto.", "Búsqueda Contacto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
           }
           if (Cmb_Busqueda_Tipo.SelectedIndex != 3)
           {
               Consultar(Cmb_Busqueda_Tipo.SelectedValue.ToString(), Txt_Descripcion_Busqueda.Text);
           }
           else
           {
               Consultar(Cmb_Busqueda_Tipo.SelectedValue.ToString(), Cmb_Giro_Busqueda.SelectedValue.ToString());
           }
       }

      
    }
}
