using Erp.Metodos_Generales;
using ERP_BASE.App_Code.Negocio.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Erp.Constantes;
using System.Windows.Forms;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Lista_Deudorcad : Form
    {
        #region Load
        public Frm_Cat_Lista_Deudorcad()
        {
            InitializeComponent();
            Grid_Lista.AutoGenerateColumns = false;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Lista_Deudorcad_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera 
        ///FECHA_CREO           : 11 Junio 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Lista_Deudorcad_Load(object sender, EventArgs e)
        {
            Fra_Datos_Listas.Enabled = false;
            Cargar_Formas_Pago();
            Cargar_Listas();
        }
        #endregion

        #region Metodos generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Listas
        ///DESCRIPCIÓN          : Consulta todos los listas de la base de datos y los coloca en el DataGridView
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera 
        ///FECHA_CREO           : 11 Junio 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cargar_Listas()
        {
            Cls_Cat_Lista_Deudorcad_Negocio Rs_Consulta = new Cls_Cat_Lista_Deudorcad_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                Dt_Consulta = Rs_Consulta.Consultar_Listas();
                Grid_Lista.DataSource = Dt_Consulta;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cargar_Listas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Formas_Pago
        ///DESCRIPCIÓN          : Consulta todos los formas de pago de la base de datos y los coloca en el combo forma de pago
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera 
        ///FECHA_CREO           : 11 Junio 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cargar_Formas_Pago()
        {
            Cls_Cat_Formas_Pago_Negocio Rs_Consulta = new Cls_Cat_Formas_Pago_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                Dt_Consulta = Rs_Consulta.Consultar_Formas_Pago();

                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Forma_Pago, Dt_Consulta, Cat_Formas_Pago.Campo_Nombre, Cat_Formas_Pago.Campo_Forma_ID);
               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cargar_Formas_Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
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
                        Grid_Lista.Enabled = false;
                        //Fra_Buscar.Visible = false;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        //Btn_Eliminar.Enabled = false;
                        //Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Fra_Datos_Listas.Enabled = true; 
                        break;
                    }
                case "Modificar":
                    {
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Grid_Lista.Enabled = false;
                        //Fra_Datos_Generales.Visible = true;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        //Btn_Eliminar.Enabled = false;
                        //Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true; 
                        Fra_Datos_Listas.Enabled = true;
                        break;
                    }
                case "Cancelar":
                    {
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Modificar.Text = "Modificar";
                        //Btn_Eliminar.Text = "Eliminar";
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
                        //Erp_Validaciones.Clear();
                        Grid_Lista.Enabled = true;
                        //Fra_Datos_Generales.Enabled = false;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        //Btn_Eliminar.Enabled = true;
                        //Btn_Buscar.Enabled = true;
                        Btn_Salir.Enabled = true;
                        Fra_Datos_Listas.Enabled = false; 
                        Erp_Validaciones.Clear();
                        break;
                    }
                default: break;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Alta
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Alta()
        {
            String Campos_Faltan = "Debe de: \n"; // Variable concatena los diferentes mensajes para los campos obligatorios que no tienen información
            Boolean Resultado = true; // Variable que indica si todos los campos obligatorios contienen información
            Erp_Validaciones.Clear();

            
            if (String.IsNullOrEmpty(Txt_Lista.Text))
            {
                Campos_Faltan += "Ingresar la lista";
                Erp_Validaciones.SetError(Txt_Lista, "Ingresar la lista");
                Resultado &= false;
            }
            if (String.IsNullOrEmpty(Txt_Nombre.Text))
            {
                Campos_Faltan += "Ingresar el nombre de la lista";
                Erp_Validaciones.SetError(Txt_Nombre, "Ingresar el nombre de la lista");
                Resultado &= false;
            }

            if (Cmb_Forma_Pago.SelectedIndex == 0)
            {
                Campos_Faltan += "Ingresar la forma de pago";
                Erp_Validaciones.SetError(Cmb_Forma_Pago, "Ingresar la forma de pago");
                Resultado &= false;
            }

            return Resultado;
        }
        
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Alta()
        {
            Cls_Cat_Lista_Deudorcad_Negocio Rs_Alta = new Cls_Cat_Lista_Deudorcad_Negocio();

            try
            {
                Rs_Alta.P_Nombre = Txt_Nombre.Text;
                Rs_Alta.P_Lista = Txt_Lista.Text;
                Rs_Alta.P_Operacion = Cmb_Operacion.Text;
                
                if (Cmb_Forma_Pago.SelectedValue.ToString() != "")
                    Rs_Alta.P_Tipo_Pago = Cmb_Forma_Pago.SelectedValue.ToString();
                else
                    Rs_Alta.P_Tipo_Pago = "";

                Rs_Alta.P_Estatus = "ACTIVO";
                
                Rs_Alta.Alta_Lista();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Modificar()
        {
            Cls_Cat_Lista_Deudorcad_Negocio Rs_Modificar = new Cls_Cat_Lista_Deudorcad_Negocio();

            try
            {
                Rs_Modificar.P_Lista_Id = Txt_Lista_Id.Text;
                Rs_Modificar.P_Nombre = Txt_Nombre.Text;
                Rs_Modificar.P_Lista = Txt_Lista.Text;
                Rs_Modificar.P_Operacion = Cmb_Operacion.Text;
                Rs_Modificar.P_Tipo_Pago = Cmb_Forma_Pago.SelectedValue.ToString();
                Rs_Modificar.P_Estatus = Cmb_Estatus.Text; 
                Rs_Modificar.Modificar_Lista();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Limpiar_Controles()
        {
            try
            {
                Txt_Lista_Id.Text = "";
                Txt_Lista.Text = "";
                Txt_Nombre.Text = "";
                Cmb_Operacion.SelectedIndex = -1;
                Cmb_Forma_Pago.SelectedIndex = -1;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Grid


        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Bancos_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del registro seleccionado en los campos correspondientes
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 05 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Lista_SelectionChanged(object sender, EventArgs e)
        {
            // validar selección de fila y cargar valores
            if (Grid_Lista.CurrentRow != null)
            {
                Txt_Lista_Id.Text = Grid_Lista.CurrentRow.Cells[Cat_Lista_Deudorcad.Campo_Lista_Id].Value.ToString();
                Cmb_Forma_Pago.SelectedValue = Grid_Lista.CurrentRow.Cells[Cat_Lista_Deudorcad.Campo_Tipo_Pago].Value.ToString();
                Cmb_Operacion.Text = Grid_Lista.CurrentRow.Cells[Cat_Lista_Deudorcad.Campo_Operacion].Value.ToString();
                Txt_Nombre.Text = Grid_Lista.CurrentRow.Cells[Cat_Lista_Deudorcad.Campo_Nombre].Value.ToString();
                Txt_Lista.Text = Grid_Lista.CurrentRow.Cells[Cat_Lista_Deudorcad.Campo_Lista].Value.ToString();
                Cmb_Estatus.Text = Grid_Lista.CurrentRow.Cells[Cat_Lista_Deudorcad.Campo_Estatus].Value.ToString();
            }
        }
        #endregion



        #region Botones
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Metodo para ingresar informacion de una lista nueva
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Junio 2015
        ///MODIFICO             : 
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
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Listas, true);
                    Txt_Lista_Id.Enabled = false;
                }
                else
                {
                    if (Validar_Alta())
                    {
                        Alta();
                        MessageBox.Show("La lista ha sido registrado", "Lista deudorcad", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Manejo_Botones_Operacion("Cancelar");
                        Fra_Datos_Listas.Enabled = false;
                        Limpiar_Controles();
                        Cargar_Listas();
                        Cargar_Formas_Pago(); 
                   
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
        ///DESCRIPCIÓN          : Metodo para ingresar informacion de una lista nueva
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Junio 2015
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Btn_Modificar.Text.Trim() == "Modificar")
                {
                    if (Txt_Lista_Id.Text != String.Empty)
                    {
                        Fra_Datos_Listas.Visible = true;
                        Manejo_Botones_Operacion("Modificar");
                    }
                    else
                    {
                        MessageBox.Show("Para modificar un banco, debe seleccionar uno de la lista", "Lista deudorcad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (Validar_Alta())
                    {
                        Modificar();
                        MessageBox.Show("La lista ha sido registrado", "Lista deudorcad", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Manejo_Botones_Operacion("Cancelar");
                        Fra_Datos_Listas.Enabled = false;
                        Fra_Datos_Listas.Enabled = false;
                        Limpiar_Controles();
                        Cargar_Listas();
                        Cargar_Formas_Pago();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Modificar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Salir_Click
        ///DESCRIPCIÓN          : Metodo para ingresar informacion de una lista nueva
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Junio 2015
        ///MODIFICO             : 
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
                Grid_Lista.Enabled = true;
            }
        }
        #endregion

       

       
    }
}
