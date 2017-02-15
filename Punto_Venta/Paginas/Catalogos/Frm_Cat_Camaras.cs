using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using ERP_BASE.App_Code.Negocio.Catalogos;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Camaras : Form
    {
        public Frm_Cat_Camaras()
        {
            InitializeComponent();
            Grid_Camaras.AutoGenerateColumns = false;
        }

        #region Load
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Camaras_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Camaras_Load(object sender, EventArgs e)
        {
            Point Punto_Fra_Camaras = new Point(1, 270);
            Point Punto_Fra_Busqueda = new Point(1, 1);
            Point Punto_Fra_Botones = new Point(1, 470);
            Size Tamaño_Formulario = new Size(741, 580);

            Fra_Datos_Generales.Visible = true;
            Fra_Busqueda.Visible = false;
            Fra_Camaras.Visible = true;

            //  seccion del formulario
            this.Size = Tamaño_Formulario;

            //  seccion Datos generales
            Fra_Datos_Generales.Enabled = false;

            //  seccion del grid
            Fra_Camaras.Location = Punto_Fra_Camaras; 

            //  seccion busqueda
            Fra_Busqueda.Location = Punto_Fra_Busqueda;
            
            //  seccion de los botones
            Tbl_Botones.Location = Punto_Fra_Botones;

            Cargar_Grid_Camaras();
        }
        #endregion Load


        #region Eventos_Generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
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
                        Grid_Camaras.Enabled = false;
                        Fra_Busqueda.Visible = false;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        break;
                    }
                case "Modificar":
                    {
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Grid_Camaras.Enabled = false;
                        Fra_Datos_Generales.Visible = true;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
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
                        //Erp_Validaciones.Clear();
                        Grid_Camaras.Enabled = true;
                        Fra_Datos_Generales.Enabled = false;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Salir.Enabled = true;
                        break;
                    }
                default: break;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Grid_Camaras
        ///DESCRIPCIÓN          : Consulta todos los bancos de la base de datos y los coloca en el DataGridView
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cargar_Grid_Camaras()
        {
            Cls_Cat_Camaras_Negocio P_Camaras = new Cls_Cat_Camaras_Negocio(); // Variable utilizada para consultar todos los bancos existentes en la base de datos.

            try
            {
                Grid_Camaras.DataSource = P_Camaras.Consultar_Camaras(); 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Camara
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Alta_Camara()
        {
            Cls_Cat_Camaras_Negocio P_Camara = new Cls_Cat_Camaras_Negocio();
            Boolean Alta = false; // Variable que indica si el registro en la base de datos se efectúa satisfactoriamente

            try
            {
                if (Validar_Alta())
                {
                    P_Camara.P_Nombre = Txt_Nombre.Text;
                    P_Camara.P_Descripcion = Txt_Descripcion.Text;
                    P_Camara.P_Url = Txt_Url.Text;
                    P_Camara.P_Estatus = Cmb_Estatus.Text;
                    P_Camara.P_Usuario = Txt_Usuario.Text;
                    P_Camara.P_Contrasenia = Txt_Contrasenia.Text;
                    P_Camara.P_Tipo = Cmb_Tipo.Text; 

                    P_Camara.Alta_Camara();
                 
                    MessageBox.Show("La camara ha sido registrado", "Camara", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Camara
        ///DESCRIPCIÓN          : Realiza la modificación de una camara en la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Modificar_Camara()
        {
            Cls_Cat_Camaras_Negocio P_Camara = new Cls_Cat_Camaras_Negocio(); 
            try
            {
                if (Validar_Alta())
                {
                    P_Camara.P_Camara_ID = Txt_ID_Camara.Text;
                    P_Camara.P_Nombre = Txt_Nombre.Text;
                    P_Camara.P_Descripcion = Txt_Descripcion.Text;
                    P_Camara.P_Url = Txt_Url.Text;
                    P_Camara.P_Estatus = Cmb_Estatus.Text;
                    P_Camara.P_Usuario = Txt_Usuario.Text;
                    P_Camara.P_Contrasenia = Txt_Contrasenia.Text;
                    P_Camara.P_Tipo = Cmb_Tipo.Text;

                    P_Camara.Modificar_Camara();
                    MessageBox.Show("La camara '" + Txt_ID_Camara.Text + "' ha sido modificado", "Camaras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return false;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Camaras
        ///DESCRIPCIÓN          : Realiza la consulta de las camaras en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Camaras()
        {
            Cls_Cat_Camaras_Negocio P_Camara = new Cls_Cat_Camaras_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id de Camara":
                        P_Camara.P_Camara_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Camaras.DataSource = P_Camara.Consultar_Camaras();
                        break;

                    case "Nombre":
                        P_Camara.P_Nombre = Txt_Descripcion_Busqueda.Text;
                        Grid_Camaras.DataSource = P_Camara.Consultar_Camaras();
                        break;

                    case "Descripcion":
                        P_Camara.P_Descripcion = Txt_Descripcion_Busqueda.Text;
                        Grid_Camaras.DataSource = P_Camara.Consultar_Camaras();
                        break;

                    case "Url":
                        P_Camara.P_Url = Txt_Descripcion_Busqueda.Text;
                        Grid_Camaras.DataSource = P_Camara.Consultar_Camaras();
                        break;

                    case "Estatus":
                        P_Camara.P_Estatus = Txt_Descripcion_Busqueda.Text.ToUpper();
                        Grid_Camaras.DataSource = P_Camara.Consultar_Camaras();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Camaras", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
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


            // Verfica que el TextBox "Txt_Nombre" tenga un valor para el nombre de la camara
            if (Txt_Nombre.Text == String.Empty)
            {
                Campos_Faltan += "Indicar un nombre para el banco";
                Erp_Validaciones.SetError(Txt_Nombre, "Debe de indicar un nombre para el banco");
                Resultado &= false;
            }

            // Verfica que el TextBox "Txt_Descripcion" tenga un valor para el nombre de la camara
            if (Txt_Descripcion.Text == String.Empty)
            {
                Campos_Faltan += "Indicar una descripcion para la camara";
                Erp_Validaciones.SetError(Txt_Nombre, "Debe de indicar una descripcion para la camara");
                Resultado &= false;
            }

            // Verfica que el TextBox "Txt_Descripcion" tenga un valor para el nombre de la camara
            if (Txt_Url.Text == String.Empty)
            {
                Campos_Faltan += "Indicar la url para la camara";
                Erp_Validaciones.SetError(Txt_Nombre, "Debe de indicar la url para la camara");
                Resultado &= false;
            }

            // Verifica que el ComboBox "Cmb_Estatus" tenga seleccionada la opcion de "ACTIVO" o "INACTIVO"
            if (Cmb_Estatus.Text == String.Empty)
            {
                Campos_Faltan += "Seleccionar un estatus de la camara";
                Erp_Validaciones.SetError(Cmb_Tipo, "Seleccionar un estatus de la camara");
                Resultado &= false;
            }

            // Verifica que el ComboBox "Cmb_Tipo"
            if (Cmb_Tipo.Text == String.Empty)
            {
                Campos_Faltan += "Seleccionar un tipo de la camara";
                Erp_Validaciones.SetError(Cmb_Tipo, "Seleccionar un tipo de la camara");
                Resultado &= false;
            }

            return Resultado;
        }
        #endregion

        #region Eventos
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para registrar un banco en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text.Trim() == "Nuevo")
            {
                Fra_Datos_Generales.Visible = true;
                Fra_Datos_Generales.Enabled = true;
                Manejo_Botones_Operacion("Nuevo");
                Cls_Metodos_Generales.Limpia_Controles(this);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
            }
            else
            {
                if (Alta_Camara())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Cargar_Grid_Camaras();
                }
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para registrar un banco en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_ID_Camara.Text != String.Empty)
                {
                    Fra_Datos_Generales.Visible = true;
                    Fra_Datos_Generales.Enabled = true;
                    Txt_ID_Camara.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                }
                else
                {
                    MessageBox.Show("Para modificar una camara, debe seleccionar uno de la lista", "Camara", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Camara())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Cargar_Grid_Camaras();
                }
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : Cambia el estatus a inactivo de una camara
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Camaras_Negocio P_Camara = new Cls_Cat_Camaras_Negocio();

            if (Txt_ID_Camara.Text != String.Empty)
            {
                if (MessageBox.Show(this, "¿Quiere realmente Inactivar la camara '" + Txt_Nombre.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    P_Camara.P_Camara_ID = Txt_ID_Camara.Text;
                    P_Camara.P_Estatus = "INACTIVO";

                    P_Camara.Modificar_Camara();
                    MessageBox.Show("La camara '" + Txt_ID_Camara.Text + "' ha sido INACTIVADO", "Camaras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);

                    Cargar_Grid_Camaras();
                }
            }

        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Muestra el grupo de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {  
            Point Punto_Fra_Busqueda = new Point(1, 220);

            Fra_Datos_Generales.Visible = false;
            Fra_Busqueda.Visible = true;

        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          :Inicia el proceso de búsqueda de la camara
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Camaras();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          :  Oculta el grupo de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Busqueda.Visible = false;
            Fra_Datos_Generales.Visible = true;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Salir_Click
        ///DESCRIPCIÓN          :  Evento para cerrar la pantalla o cancelar una acción
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
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
                Grid_Camaras.Enabled = true;
            }
        }
        #endregion Eventos

        #region Grid
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Camaras_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del registro seleccionado en los campos correspondientes
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Camaras_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Camaras.CurrentRow != null)
            {
                Txt_ID_Camara.Text = Grid_Camaras.CurrentRow.Cells["Camara_Id"].Value.ToString();
                Txt_Nombre.Text = Grid_Camaras.CurrentRow.Cells["Nombre"].Value.ToString();
                Txt_Descripcion.Text = Grid_Camaras.CurrentRow.Cells["Descripcion"].Value.ToString();
                Txt_Url.Text = Grid_Camaras.CurrentRow.Cells["Url"].Value.ToString();
                Cmb_Estatus.Text = Grid_Camaras.CurrentRow.Cells["Estatus"].Value.ToString();
                Txt_Usuario.Text = Grid_Camaras.CurrentRow.Cells["Usuario"].Value.ToString();
                Txt_Contrasenia.Text = Grid_Camaras.CurrentRow.Cells["Contrasenia"].Value.ToString();
                Cmb_Tipo.Text = Grid_Camaras.CurrentRow.Cells["Tipo"].Value.ToString();
            }
        }
        #endregion Grid

       

      




    }
}
