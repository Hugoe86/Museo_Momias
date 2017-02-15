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
using Erp.Metodos_Generales;
using Microsoft.VisualBasic;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Motivos_Descuento : Form
    {
        public Frm_Cat_Motivos_Descuento()
        {
            InitializeComponent();
            Grid_Motivos_Descuento.AutoGenerateColumns=false;
        }

        #region Métodos Generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Motivos_Descuento_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Motivos_Descuento_Load(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            Carga_Motivos_Descuento();
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Cajas", this);
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Motivos_Descuento);
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Carga_Cajas
        ///DESCRIPCIÓN          : Método que consulta todas las cajas registradas en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Carga_Motivos_Descuento()
        {
            Cls_Cat_Motivos_Descuento_Negocio Motivos_Descuento_Consultar = new Cls_Cat_Motivos_Descuento_Negocio();

            try
            {
                Grid_Motivos_Descuento.DataSource = Motivos_Descuento_Consultar.Consultar_Motivos_Descuento();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Luis  Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
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
                        Grid_Motivos_Descuento.Enabled = false;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Fra_Buscar.Visible = false;
                        break;
                    }
                case "Modificar":
                    {
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Grid_Motivos_Descuento.Enabled = false;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Fra_Buscar.Visible = false;
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
                        Erp_Validaciones.Clear();
                        Grid_Motivos_Descuento.Enabled = true;
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
        ///NOMBRE DE LA FUNCIÓN : Validar_Alta
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Alta()
        {
            String Campos_Faltan = "Debe de: \n";
            Boolean Resultado = true;
            Erp_Validaciones.Clear();

            if (Txt_Descripcion.Text == String.Empty)
            {
                Campos_Faltan += "Ingresar información en la descripción";
                Erp_Validaciones.SetError(Txt_Descripcion, "Debe de ingresar información en la descripción");
                Resultado &= false;
            }

            return Resultado;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Motivos_Descuento
        ///DESCRIPCIÓN          : Realiza el registro de un motivo de descuento en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************

        private Boolean Alta_Motivos_Descuento()
        {
            Cls_Cat_Motivos_Descuento_Negocio Motivos_Descuento_Nuevo = new Cls_Cat_Motivos_Descuento_Negocio();
            Boolean Alta = false;


            try
            {
                if (Validar_Alta())
                {
                    Motivos_Descuento_Nuevo.P_Descripcion = Txt_Descripcion.Text;

                    Motivos_Descuento_Nuevo.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Motivos_Descuento_Nuevo.P_Fecha_Creo = DateTime.Now;
                    Motivos_Descuento_Nuevo.Alta_Motivos_Descuento();
                    MessageBox.Show("El motivo de descuento ha sido registrado", "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Motivos_Descuento
        ///DESCRIPCIÓN          : Realiza la modificación de un Motivo de descuento en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private Boolean Modificar_Motivos_Descuento()
        {
            Cls_Cat_Motivos_Descuento_Negocio Motivos_Descuento_Modificar = new Cls_Cat_Motivos_Descuento_Negocio();

            try
            {
                if (Validar_Alta())
                {
                    Motivos_Descuento_Modificar.P_Motivos_Descuento_ID = Txt_Motivos_Descuento_Id.Text;
                    Motivos_Descuento_Modificar.P_Descripcion = Txt_Descripcion.Text;
                    Motivos_Descuento_Modificar.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Motivos_Descuento_Modificar.P_Fecha_Modifico = DateTime.Now;
                    Motivos_Descuento_Modificar.Modificar_Motivos_Descuento();
                    MessageBox.Show("EL Motivo de descuento '" + Txt_Motivos_Descuento_Id.Text + "' ha sido modificado", "Motivos de descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Motivos_Descuento
        ///DESCRIPCIÓN          : Realiza la consulta de los motivos de descuento en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Motivos_Descuento()
        {
            Cls_Cat_Motivos_Descuento_Negocio Motivos_Descuento_Consultar = new Cls_Cat_Motivos_Descuento_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id de Motivos de Descuento":
                        Motivos_Descuento_Consultar.P_Motivos_Descuento_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Motivos_Descuento.DataSource = Motivos_Descuento_Consultar.Consultar_Motivos_Descuento();
                        break;

                    case "Descripción":
                        Motivos_Descuento_Consultar.P_Descripcion = Txt_Descripcion_Busqueda.Text;
                        Grid_Motivos_Descuento.DataSource = Motivos_Descuento_Consultar.Consultar_Motivos_Descuento();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        #endregion

        #region Eventos
       
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de motivos de descuento
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Motivos_Descuento();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Enabled = false;
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
            Carga_Motivos_Descuento();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para registrar una caja en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text.Trim() == "Nuevo")
            {
                Manejo_Botones_Operacion("Nuevo");
                Cls_Metodos_Generales.Limpia_Controles(this);
                Fra_Datos_Generales.Visible = true;
                Fra_Datos_Generales.Enabled = true;
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                Txt_Motivos_Descuento_Id.Enabled = false;
            }
            else
            {
                if (Alta_Motivos_Descuento())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Motivos_Descuento();
                }
            }
        }
        
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar un motivo de descuento
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_Motivos_Descuento_Id.Text != String.Empty)
                {
                    Fra_Datos_Generales.Enabled = true;
                    Txt_Motivos_Descuento_Id.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                }
                else
                {
                    MessageBox.Show("Para modificar un motivo de descuento, debe seleccionar una de la lista", "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Motivos_Descuento())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Motivos_Descuento();
                }
            }
        }
        
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Fra_Datos_Generales.Enabled = true;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
        }
        
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : Elimina un motivo de descuento de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Motivos_Descuento_Negocio Motivo_Descuento_Eliminar = new Cls_Cat_Motivos_Descuento_Negocio();

            try
            {
                if (Txt_Motivos_Descuento_Id.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar el motivo de descuento '" + Txt_Motivos_Descuento_Id.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Motivo_Descuento_Eliminar.P_Motivos_Descuento_ID = Txt_Motivos_Descuento_Id.Text;
                        Motivo_Descuento_Eliminar.Eliminar_Motivos_Descuento();
                        MessageBox.Show("El motivo de descuento '" + Txt_Motivos_Descuento_Id.Text + "' ha sido eliminado", "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Carga_Motivos_Descuento();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar un motivo de descuento, debe seleccionar uno de la lista", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Motivos de Descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
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
                Grid_Motivos_Descuento.Enabled=true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN          : Limpia y envia el foco al Txt_Descripcion_Busqueda para realizar una nueva descripción de busqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
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

        #region Grid
        private void Grid_Motivos_Descuento_SelectionChanged(object sender, EventArgs e)
        {
            if(Grid_Motivos_Descuento.CurrentRow != null)
            {
                Txt_Motivos_Descuento_Id.Text = Grid_Motivos_Descuento.CurrentRow.Cells["Motivo_Descuento_ID"].Value.ToString();
                Txt_Descripcion.Text = Grid_Motivos_Descuento.CurrentRow.Cells["Descripcion"].Value.ToString();
            }
        }
        #endregion



    }
}
