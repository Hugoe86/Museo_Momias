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
using System.IO.Ports;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Terminales : Form
    {
        public Frm_Cat_Terminales()
        {
            InitializeComponent();
            Grid_Terminales.AutoGenerateColumns = false;
        }

        #region Métodos Generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Terminales_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private void Frm_Cat_Terminales_Load(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            Carga_Terminales();
            Obtener_Puertos();
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Terminales", this);
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Terminales);
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Carga_Terminales
        ///DESCRIPCIÓN          : Método que consulta todas las Terminales registradas en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private void Carga_Terminales()
        {
            Cls_Cat_Terminales_Negocio Terminales_Consultar = new Cls_Cat_Terminales_Negocio();

            try
            {
                Grid_Terminales.DataSource = Terminales_Consultar.Consultar_Terminales();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Obtener_Puertos
        ///DESCRIPCIÓN          : Método que consulta los puertos com del equipo
        ///PARÁMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 24 Abril 2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Obtener_Puertos()
        {
            try
            {
                foreach (string Serial in SerialPort.GetPortNames())
                {
                    Cmb_Puerto.Items.Add(Serial);
                }
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
        ///FECHA_CREO           : 16 Octubre 2013
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
                        Grid_Terminales.Enabled = false;
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
                        Grid_Terminales.Enabled = false;
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
                        Grid_Terminales.Enabled = true;
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
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Alta()
        {
            String Campos_Faltan = "Debe de: \n";
            Boolean Resultado = true;
            Erp_Validaciones.Clear();

            if (Txt_Nombre.Text == String.Empty)
            {
                Campos_Faltan += "Ingresar información de la Terminal";
                Erp_Validaciones.SetError(Txt_Nombre, "Debe de ingresar información de la Terminal");
                Resultado &= false;
            }

            if (Chk_Pin_Pad.Checked == true)
            {
                if (Cmb_Puerto.Text == String.Empty)
                {
                    Campos_Faltan += "Ingresar información del puerto";
                    Erp_Validaciones.SetError(Cmb_Puerto, "Debe de ingresar información del puerto");
                    Resultado &= false;
                }
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Terminales
        ///DESCRIPCIÓN          : Realiza el registro de la Terminal en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************

        private Boolean Alta_Terminales()
        {
            Cls_Cat_Terminales_Negocio Terminales_Nuevo = new Cls_Cat_Terminales_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta())
                {
                    Terminales_Nuevo.P_Nombre = Txt_Nombre.Text;
                    Terminales_Nuevo.P_Puerto = Cmb_Puerto.Text;
                    Terminales_Nuevo.P_Equipo = Txt_Equipo.Text;
                    Terminales_Nuevo.P_Estatus = Cmb_Estatus.Text;
                    Terminales_Nuevo.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Terminales_Nuevo.P_Fecha_Creo = DateTime.Now;
                    Terminales_Nuevo.Alta_Terminales();
                    MessageBox.Show("La Terminal ha sido registrada", "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Terminales
        ///DESCRIPCIÓN          : Realiza la modificación de una Terminal en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private Boolean Modificar_Terminales()
        {
            Cls_Cat_Terminales_Negocio Terminales_Modificar = new Cls_Cat_Terminales_Negocio();

            try
            {
                if (Validar_Alta())
                {
                    Terminales_Modificar.P_Terminal_ID = Txt_ID_Terminal.Text;
                    Terminales_Modificar.P_Nombre = Txt_Nombre.Text;
                    Terminales_Modificar.P_Puerto = Cmb_Puerto.Text;
                    Terminales_Modificar.P_Equipo = Txt_Equipo.Text;
                    Terminales_Modificar.P_Estatus = Cmb_Estatus.Text;
                    Terminales_Modificar.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Terminales_Modificar.P_Fecha_Modifico = DateTime.Now;
                    Terminales_Modificar.Modificar_Terminales();
                    MessageBox.Show("La Terminal '" + Txt_ID_Terminal.Text + "' ha sido modificada", "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Terminales
        ///DESCRIPCIÓN          : Realiza la consulta de las Terminales en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Terminales()
        {
            Cls_Cat_Terminales_Negocio Terminales_Consultar = new Cls_Cat_Terminales_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "ID Terminal":
                        Terminales_Consultar.P_Terminal_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Terminales.DataSource = Terminales_Consultar.Consultar_Terminales();
                        break;
                    case "Nombre":
                        Terminales_Consultar.P_Nombre = Txt_Descripcion_Busqueda.Text;
                        Grid_Terminales.DataSource = Terminales_Consultar.Consultar_Terminales();
                        break;
                    case "Puerto":
                        Terminales_Consultar.P_Puerto = Txt_Descripcion_Busqueda.Text;
                        Grid_Terminales.DataSource = Terminales_Consultar.Consultar_Terminales();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        #endregion

        #region Eventos

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de las Terminales
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Terminales();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Enabled = false;
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
            Carga_Terminales();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para registrar una Terminal en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
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
                Txt_Equipo.Enabled = false;
                Chk_Pin_Pad.Checked = false;
                Chk_Pin_Pad_CheckedChanged(sender, null);
            }
            else
            {
                if (Alta_Terminales())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Terminales();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar una Terminal
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_ID_Terminal.Text != String.Empty)
                {
                    Fra_Datos_Generales.Enabled = true;
                    Txt_ID_Terminal.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                    Txt_Equipo.Enabled = false;
                    Chk_Pin_Pad_CheckedChanged(sender, null);
                }
                else
                {
                    MessageBox.Show("Para modificar una Terminal, debe seleccionar una de la lista", "Terminal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Terminales())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Terminales();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Fra_Datos_Generales.Enabled = true;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
            Txt_Descripcion_Busqueda.Text = "";
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : Elimina una Terminal de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Terminales_Negocio Terminales_Eliminar = new Cls_Cat_Terminales_Negocio();

            try
            {
                if (Txt_ID_Terminal.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar la Terminal '" + Txt_ID_Terminal.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Terminales_Eliminar.P_Terminal_ID = Txt_ID_Terminal.Text;
                        Terminales_Eliminar.Eliminar_Terminales();
                        MessageBox.Show("La Terminal '" + Txt_ID_Terminal.Text + "' ha sido eliminada", "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Carga_Terminales();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar una Terminal, debe seleccionar una de la lista", "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Terminales", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///FECHA_CREO           : 16 Octubre 2013
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
                Grid_Terminales.Enabled = true;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN          : Limpia y envia el foco al Txt_Descripcion_Busqueda para realizar una nueva descripción de busqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
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
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Terminales_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del elemento seleccionado en los campos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        ///
        private void Grid_Terminales_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Terminales.CurrentCell != null)
            {
                Txt_ID_Terminal.Text = Grid_Terminales.CurrentRow.Cells["Terminal_ID"].Value.ToString();
                Txt_Nombre.Text = Grid_Terminales.CurrentRow.Cells["Nombre"].Value.ToString();
                Cmb_Puerto.Text = Grid_Terminales.CurrentRow.Cells["Puerto"].Value.ToString();
                Txt_Equipo.Text = Grid_Terminales.CurrentRow.Cells["Equipo"].Value.ToString();
                Cmb_Estatus.Text = Grid_Terminales.CurrentRow.Cells["Estatus"].Value.ToString();

                if (Cmb_Puerto.Text != "" || Txt_Equipo.Text != "")
                {
                    Chk_Pin_Pad.Checked = true;
                }
                else
                {
                    Chk_Pin_Pad.Checked = false;
                }
            }
        }

        #endregion
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Limpiar_Nombre_Equipo_Click
        ///DESCRIPCIÓN          : Coloca en nombre del equipo
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramímez Aguilera
        ///FECHA_CREO           : 24 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Acutalizar_Nombre_Equipo_Click(object sender, EventArgs e)
        {
            try
            {
                Txt_Equipo.Text = Environment.MachineName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Acutalizar_Nombre_Equipo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Limpiar_Nombre_Equipo_Click
        ///DESCRIPCIÓN          : limpia la caja de texto del nombre del equipo
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramímez Aguilera
        ///FECHA_CREO           : 24 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Limpiar_Nombre_Equipo_Click(object sender, EventArgs e)
        {
            try
            {
                Txt_Equipo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Acutalizar_Nombre_Equipo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Chk_Pin_Pad_CheckedChanged
        ///DESCRIPCIÓN          : habilita las cajas de las pin pads
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramímez Aguilera
        ///FECHA_CREO           : 24 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Chk_Pin_Pad_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Chk_Pin_Pad.Checked)
                {
                    Cmb_Puerto.Enabled = true;
                    Btn_Acutalizar_Nombre_Equipo.Enabled = true;
                    Btn_Limpiar_Nombre_Equipo.Enabled = true;
                }
                else
                {
                    Cmb_Puerto.Enabled = false;
                    Btn_Acutalizar_Nombre_Equipo.Enabled = false;
                    Btn_Limpiar_Nombre_Equipo.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Acutalizar_Nombre_Equipo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }


        

        
    }
}
