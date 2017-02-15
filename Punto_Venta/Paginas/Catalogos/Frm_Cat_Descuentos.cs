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
    public partial class Frm_Cat_Descuentos : Form
    {

        #region Load
        public Frm_Cat_Descuentos()
        {
            InitializeComponent();
            Grid_Descuentos.AutoGenerateColumns = false;
        }

        private void Frm_Cat_Descuentos_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
            Cargar_Descuentos();
        }
        #endregion

        #region Validaciones
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Numerico_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres numéricos.
        ///PARAMENTROS  :
        ///CREO         : Luis Eugenio Razo Mendiola
        ///FECHA_CREO   : 18/Oct/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Numerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }

        #endregion

        #region Métodos Generales

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Descuentos
        ///DESCRIPCIÓN          : Método que carga todos los descuentos registrados en el sistema
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Cargar_Descuentos()
        {
            Cls_Cat_Descuentos_Negocio P_Descuentos = new Cls_Cat_Descuentos_Negocio();

            try
            {
                Grid_Descuentos.DataSource = P_Descuentos.Consultar_Descuentos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para manejo de los estados de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
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
                        Grid_Descuentos.Enabled = false;
                        Fra_Buscar.Visible = false;
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
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                        Grid_Descuentos.Enabled = false;
                        Fra_Buscar.Visible = false;
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
                        Grid_Descuentos.Enabled = true;
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
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
        ///DESCRIPCIÓN          : Verifica que los campos obligatorios tengan información
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Validar_Alta()
        {
            Boolean Resultado = true;

            Erp_Validaciones.Clear();

            if (Txt_Descripcion.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Txt_Descripcion, "Debe indicar la descripcion del descuento");
                Resultado &= false;
            }

            if (Dtp_Fecha_Desde.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Dtp_Fecha_Desde, "Debe indicar la fecha donde inicia el descuento");
                Resultado &= false;
            }

            if (Dtp_Fecha_Hasta.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Dtp_Fecha_Hasta, "Debe indicar la fecha del termino del descuento");
                Resultado &= false;
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Descuento
        ///DESCRIPCIÓN          : Verifica que los campos obligatorios tengan información
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Alta_Descuentos()
        {
            Cls_Cat_Descuentos_Negocio P_Descuentos = new Cls_Cat_Descuentos_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta())
                {
                    P_Descuentos.P_Descripcion = Txt_Descripcion.Text;
                    P_Descuentos.P_Vigencia_Desde = Dtp_Fecha_Desde.Value;
                    P_Descuentos.P_Vigencia_Hasta = Dtp_Fecha_Hasta.Value;
                    P_Descuentos.P_Porcentaje_Descuento = Txt_Porcentaje_Descuento.Text;
                    P_Descuentos.P_Monto_Descuento = Txt_Monto_Descuento.Text;
                    P_Descuentos.P_Motivo = Txt_Motivo.Text;
                    P_Descuentos.P_Leyenda = Txt_Leyenda.Text;
                    P_Descuentos.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    P_Descuentos.P_Fecha_Creo = DateTime.Now;
                    P_Descuentos.Alta_Descuentos();
                    Alta = true;
                    MessageBox.Show("El Descuento '" + Txt_ID_Descuento.Text + "' ha sido registrado", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Descuento
        ///DESCRIPCIÓN          : Modifica la información de un descuento
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Modificar_Descuentos()
        {
            Cls_Cat_Descuentos_Negocio P_Descuentos = new Cls_Cat_Descuentos_Negocio();
            Boolean Modificar = false;

            try
            {
                if (Validar_Alta())
                {
                    P_Descuentos.P_Descuento_ID = Txt_ID_Descuento.Text;
                    P_Descuentos.P_Vigencia_Desde = Dtp_Fecha_Desde.Value;
                    P_Descuentos.P_Vigencia_Hasta = Dtp_Fecha_Hasta.Value;
                    P_Descuentos.P_Porcentaje_Descuento = Txt_Porcentaje_Descuento.Text;
                    P_Descuentos.P_Monto_Descuento = Txt_Monto_Descuento.Text;
                    P_Descuentos.P_Motivo = Txt_Motivo.Text;
                    P_Descuentos.P_Leyenda = Txt_Leyenda.Text;
                    P_Descuentos.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    P_Descuentos.P_Fecha_Modifico = DateTime.Now;
                    P_Descuentos.Modificar_Descuentos();
                    Modificar = true;
                    MessageBox.Show("El Descuento '" + Txt_ID_Descuento.Text + "' ha sido modificado", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Modificar;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Descuentos
        ///DESCRIPCIÓN          : Realiza la consulta de los descuentos en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Descuentos()
        {
            Cls_Cat_Descuentos_Negocio Descuentos_Consultar = new Cls_Cat_Descuentos_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "ID Descuento":
                        Descuentos_Consultar.P_Descuento_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Descuentos.DataSource = Descuentos_Consultar.Consultar_Descuentos();
                        break;
                    case "Descripción":
                        Descuentos_Consultar.P_Descripcion = Txt_Descripcion_Busqueda.Text;
                        Grid_Descuentos.DataSource = Descuentos_Consultar.Consultar_Descuentos();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        #endregion

        #region Eventos
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de descuentos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Descuentos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugennio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
            Cargar_Descuentos();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para crear un nuevo descuento
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
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
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                Txt_ID_Descuento.Enabled = false;
            }
            else
            {
                if (Alta_Descuentos())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Cargar_Descuentos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar un descuento
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Menidiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_ID_Descuento.Text != String.Empty)
                {
                    Manejo_Botones_Operacion("Modificar");
                    Txt_ID_Descuento.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Para modificar un descuento, debe seleccionar uno de la lista", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Descuentos())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Cargar_Descuentos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : Elimina un descuento de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Descuentos_Negocio Descuentos_Eliminar = new Cls_Cat_Descuentos_Negocio();

            try
            {
                if (Txt_ID_Descuento.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar el descuento '" + Txt_ID_Descuento.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Descuentos_Eliminar.P_Descuento_ID = Txt_ID_Descuento.Text;
                        Descuentos_Eliminar.Eliminar_Descuentos();
                        MessageBox.Show("El Descuento '" + Txt_ID_Descuento.Text + "' ha sido eliminado", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Cargar_Descuentos();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar un Descuento, debe seleccionar una de la lista", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///FECHA_CREO           : 18 Octubre 2013
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
                Grid_Descuentos.Enabled = true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Salir_Click
        ///DESCRIPCIÓN          : Limia y envia el foco al Txt_Descripcion_Busqueda para hacer una nueva busqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
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
        ///NOMBRE DE LA FUNCIÓN : Grid_Descuentos_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la informacion del registro seleccionado del grid en los campos correspondientes
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Descuentos_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Descuentos.CurrentRow != null)
            {
                Txt_ID_Descuento.Text = Grid_Descuentos.CurrentRow.Cells["Descuento_ID"].Value.ToString();
                Txt_Descripcion.Text = Grid_Descuentos.CurrentRow.Cells["Descripcion"].Value.ToString();
                Dtp_Fecha_Desde.Value = DateTime.Parse(Grid_Descuentos.CurrentRow.Cells["Vigencia_Desde"].Value.ToString());
                Dtp_Fecha_Hasta.Value = DateTime.Parse(Grid_Descuentos.CurrentRow.Cells["Vigencia_Hasta"].Value.ToString());
                Txt_Porcentaje_Descuento.Text = Grid_Descuentos.CurrentRow.Cells["Porcentaje_Descuento"].Value.ToString();
                Txt_Monto_Descuento.Text = Grid_Descuentos.CurrentRow.Cells["Monto_Descuento"].Value.ToString();
                Txt_Motivo.Text = Grid_Descuentos.CurrentRow.Cells["Motivo"].Value.ToString();
                Txt_Leyenda.Text = Grid_Descuentos.CurrentRow.Cells["Leyenda"].Value.ToString();
            }
        }
        #endregion

        
    }
}
