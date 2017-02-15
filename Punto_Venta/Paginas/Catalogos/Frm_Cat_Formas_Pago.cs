using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_BASE.App_Code.Negocio.Catalogos;
using ERP_BASE.Paginas.Paginas_Generales;
using ERP_BASE.Paginas.Operacion;
using Erp.Metodos_Generales;
using Erp.Validador;


namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Formas_Pago : Form
    {
        string Usuario_Autoriza;

        #region Métodos Generales
        public Frm_Cat_Formas_Pago()
        {
            InitializeComponent();
            Grid_Formas_Pago.AutoGenerateColumns = false;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Formas_Pago_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Formas_Pago_Load(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = false;
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Cargar_Formas_Pago();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Formas_Pago
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Cargar_Formas_Pago()
        {
            Cls_Cat_Formas_Pago_Negocio P_Forma_Pago = new Cls_Cat_Formas_Pago_Negocio();

            try
            {
                Grid_Formas_Pago.DataSource = P_Forma_Pago.Consultar_Formas_Pago();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para manejo de los estados de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
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
                        Grid_Formas_Pago.Enabled = false;
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
                        Grid_Formas_Pago.Enabled = false;
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
                        Grid_Formas_Pago.Enabled = true;
                        Fra_Datos_Generales.Enabled = false;
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

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Alta
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Alta() 
        {
            Boolean Resultado = true;
            Erp_Validaciones.Clear();

            if (Txt_Nombre.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Txt_Nombre, "Debe ingresar el nombre de la forma de pago");
                Resultado &= false;
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Forma_Pago
        ///DESCRIPCIÓN          : Realiza el registro de una forma de pago en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Alta_Forma_Pago()
        {
            Cls_Cat_Formas_Pago_Negocio P_Forma_Pago = new Cls_Cat_Formas_Pago_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta()) 
                {
                    P_Forma_Pago.P_Nombre = Txt_Nombre.Text;
                    P_Forma_Pago.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    P_Forma_Pago.P_Fecha_Creo = DateTime.Now;
                    P_Forma_Pago.Alta_Forma_Pago();
                    Alta = true;
                    MessageBox.Show("La forma de pago ha sido registrada", "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Forma_Pago
        ///DESCRIPCIÓN          : Realiza la modificación de una forma de pago en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Modificar_Forma_Pago() 
        {
            Cls_Cat_Formas_Pago_Negocio P_Forma_Pago = new Cls_Cat_Formas_Pago_Negocio();
            Boolean Modificar = false;

            try 
            {
                if (Validar_Alta()) 
                {
                    P_Forma_Pago.P_Forma_ID = Txt_ID_Forma_Pago.Text;
                    P_Forma_Pago.P_Nombre = Txt_Nombre.Text;
                    P_Forma_Pago.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    P_Forma_Pago.P_Fecha_Modifico = DateTime.Now;
                    P_Forma_Pago.Modificar_Forma_Pago();
                    MessageBox.Show("La forma de pago '" + Txt_ID_Forma_Pago.Text + "' ha sido modificada", "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Modificar = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Modificar;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Formas_Pago
        ///DESCRIPCIÓN          : Realiza la consulta productos en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Consultar_Formas_Pago()
        {
            Cls_Cat_Formas_Pago_Negocio P_Forma_Pago = new Cls_Cat_Formas_Pago_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id de Forma de Pago":
                        P_Forma_Pago.P_Forma_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Formas_Pago.DataSource = P_Forma_Pago.Consultar_Formas_Pago();
                        break;

                    case "Nombre":
                        P_Forma_Pago.P_Nombre = Txt_Descripcion_Busqueda.Text;
                        Grid_Formas_Pago.DataSource = P_Forma_Pago.Consultar_Formas_Pago();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Autorizar_Movimiento
        /// 
        /// Descripción: Método que invoca la autorización del movimiento.
        /// 
        /// Usuario Modifico: Juan Alberto Hernández Negrete
        /// Fecha Modifico: 06 Octubre 2013 11:31 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Verdadero (true) si se autoriza y falso (false) en caso contrario</returns>
        private bool Autorizar_Movimiento()
        {
            try
            {
                //Utilizamos la clase (Frm_Apl_Usuario_Autoriza) e invocamos su método (Mostrar_Ventana) para autorizar el movimiento.
                this.Usuario_Autoriza = new Frm_Apl_Usuario_Autoriza().Mostrar_Ventana("Autorización", this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Autorizar_Movimiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !string.IsNullOrEmpty(this.Usuario_Autoriza);
        }




        #endregion

        #region Eventos
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de formas de pago
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Formas_Pago();
            }
            else 
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
            Cargar_Formas_Pago();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para crear una nueva forma de pago
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Autorizar_Movimiento())
            {            
                if (Btn_Nuevo.Text.Trim() == "Nuevo")
                {
                    Manejo_Botones_Operacion("Nuevo");
                    Cls_Metodos_Generales.Limpia_Controles(this);
                    Fra_Datos_Generales.Visible = true;
                    Fra_Datos_Generales.Enabled = true;
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                }
                else
                {
                    if (Alta_Forma_Pago())
                    {
                        Manejo_Botones_Operacion("Cancelar");
                        Fra_Datos_Generales.Enabled = false;
                        Cargar_Formas_Pago();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar una forma de pago
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Autorizar_Movimiento())
            {
                if (Btn_Modificar.Text.Trim() == "Modificar")
                {
                    if (Txt_ID_Forma_Pago.Text != String.Empty)
                    {
                        Fra_Datos_Generales.Enabled = true;
                        Txt_ID_Forma_Pago.Enabled = false;
                        Manejo_Botones_Operacion("Modificar");
                    }
                    else
                    {
                        MessageBox.Show("Para modificar una forma de pago, debe seleccionarla de la lista", "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (Modificar_Forma_Pago())
                    {
                        Manejo_Botones_Operacion("Cancelar");
                        Fra_Datos_Generales.Enabled = false;
                        Cargar_Formas_Pago();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Autorizar_Movimiento())
            {
                Fra_Buscar.Visible = true;
                Cmb_Busqueda_Tipo.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : Elimina una forma de pago de la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Formas_Pago_Negocio P_Forma_Pago = new Cls_Cat_Formas_Pago_Negocio();

            try
            {
                if (Autorizar_Movimiento())
                {
                    if (Txt_ID_Forma_Pago.Text != String.Empty)
                    {
                        if (MessageBox.Show(this, "¿Quiere realmente eliminar la forma de pago '" + Txt_ID_Forma_Pago.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            P_Forma_Pago.P_Forma_ID = Txt_ID_Forma_Pago.Text;
                            P_Forma_Pago.Eliminar_Forma_Pago();
                            MessageBox.Show("La forma de pago '" + Txt_ID_Forma_Pago.Text + "' ha sido eliminada", "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                            Cargar_Formas_Pago();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para eliminar una forma de pago, debe seleccionarla de la lista", "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Formas de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(exc.GetHashCode().ToString() + " " + exc.Message);
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Salir_Click
        ///DESCRIPCIÓN          : Evento para cerrar la pantalla o cancelar una acción
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
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
                Grid_Formas_Pago.Enabled = true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN          : Limpia y envia el foco al Txt_Descripcion_Busqueda para realizar una nueva descripción de busqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 21 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Busqueda_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Descripcion_Busqueda.Text = "";
            Txt_Descripcion_Busqueda.Focus();
        }

        #endregion

        #region Eventos Grid
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Formas_Pago_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del elemento seleccionado en los campos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Formas_Pago_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Formas_Pago.CurrentRow != null)
            {
                Txt_ID_Forma_Pago.Text = Grid_Formas_Pago.CurrentRow.Cells["Forma_ID"].Value.ToString();
                Txt_Nombre.Text = Grid_Formas_Pago.CurrentRow.Cells["Nombre"].Value.ToString();
            }
        }
        #endregion

       
    }
}