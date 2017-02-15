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
    public partial class Frm_Cat_Impresoras : Form
    {
        public Frm_Cat_Impresoras()
        {
            InitializeComponent();
            Grid_Impresoras.AutoGenerateColumns = false;
        }

        #region Métodos Generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Impresoras_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private void Frm_Cat_Impresoras_Load(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            Carga_Impresoras();
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Impresoras", this);
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Impresoras);
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Carga_Impresoras
        ///DESCRIPCIÓN          : Método que consulta todas las Impresoras registradas en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private void Carga_Impresoras()
        {
            Cls_Cat_Impresoras_Negocio Impresoras_Consultar = new Cls_Cat_Impresoras_Negocio();

            try
            {
                Grid_Impresoras.DataSource = Impresoras_Consultar.Consultar_Impresoras();
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
        ///FECHA_CREO           : 15 Octubre 2013
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
                        Grid_Impresoras.Enabled = false;
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
                        Grid_Impresoras.Enabled = false;
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
                        Grid_Impresoras.Enabled = true;
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
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Alta()
        {
            String Campos_Faltan = "Debe de: \n";
            Boolean Resultado = true;
            Erp_Validaciones.Clear();

            if (Txt_Nombre_Impresora.Text == String.Empty)
            {
                Campos_Faltan += "Ingresar información de la impresora";
                Erp_Validaciones.SetError(Txt_Nombre_Impresora, "Debe de ingresar información de la impresora");
                Resultado &= false;
            }
            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Impresoras
        ///DESCRIPCIÓN          : Realiza el registro de una Impresora en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************

        private Boolean Alta_Impresoras()
        {
            Cls_Cat_Impresoras_Negocio Impresoras_Nuevo = new Cls_Cat_Impresoras_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta())
                {
                    Impresoras_Nuevo.P_Nombre_Impresora = Txt_Nombre_Impresora.Text;
                    Impresoras_Nuevo.P_Ip = Txt_Ip.Text;
                    Impresoras_Nuevo.P_Ubicacion = Txt_Ubicacion.Text;
                    Impresoras_Nuevo.P_Comentarios = Txt_Comentarios.Text;

                    Impresoras_Nuevo.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Impresoras_Nuevo.P_Fecha_Creo = DateTime.Now;
                    Impresoras_Nuevo.Alta_Impresoras();
                    MessageBox.Show("La Impresora ha sido registrada", "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Impresoras
        ///DESCRIPCIÓN          : Realiza la modificación de una impresora en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private Boolean Modificar_Impresoras()
        {
            Cls_Cat_Impresoras_Negocio Impresoras_Modificar = new Cls_Cat_Impresoras_Negocio();

            try
            {
                if (Validar_Alta())
                {
                    Impresoras_Modificar.P_Impresora_Id = Txt_ID_Impresora.Text;
                    Impresoras_Modificar.P_Nombre_Impresora = Txt_Nombre_Impresora.Text;
                    Impresoras_Modificar.P_Ip = Txt_Ip.Text;
                    Impresoras_Modificar.P_Ubicacion = Txt_Ubicacion.Text;
                    Impresoras_Modificar.P_Comentarios = Txt_Comentarios.Text;
                    Impresoras_Modificar.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Impresoras_Modificar.P_Fecha_Modifico = DateTime.Now;
                    Impresoras_Modificar.Modificar_Impresoras();
                    MessageBox.Show("La Impresora '" + Txt_ID_Impresora.Text + "' ha sido modificada", "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Impresoras
        ///DESCRIPCIÓN          : Realiza la consulta de las Impresoras en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Impresoras()
        {
            Cls_Cat_Impresoras_Negocio Impresoras_Consultar = new Cls_Cat_Impresoras_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id Impresora":
                        Impresoras_Consultar.P_Impresora_Id = Txt_Descripcion_Busqueda.Text;
                        Grid_Impresoras.DataSource = Impresoras_Consultar.Consultar_Impresoras();
                        break;
                    case "Nombre de la impresora":
                        Impresoras_Consultar.P_Nombre_Impresora = Txt_Descripcion_Busqueda.Text;
                        Grid_Impresoras.DataSource = Impresoras_Consultar.Consultar_Impresoras();
                        break;
                    case "Ip":
                        Impresoras_Consultar.P_Ip = Txt_Descripcion_Busqueda.Text;
                        Grid_Impresoras.DataSource = Impresoras_Consultar.Consultar_Impresoras();
                        break;
                    case "Ubicación":
                        Impresoras_Consultar.P_Ubicacion = Txt_Descripcion_Busqueda.Text;
                        Grid_Impresoras.DataSource = Impresoras_Consultar.Consultar_Impresoras();
                        break;
                    case "Comentarios":
                        Impresoras_Consultar.P_Comentarios = Txt_Descripcion_Busqueda.Text;
                        Grid_Impresoras.DataSource = Impresoras_Consultar.Consultar_Impresoras();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        #endregion

        #region Eventos

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de  las impresoras
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
                Consultar_Impresoras();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            Carga_Impresoras();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para registrar una impresora en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
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
                Txt_ID_Impresora.Enabled = false;
            }
            else
            {
                if (Alta_Impresoras())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Impresoras();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar una impresora
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
                if (Txt_ID_Impresora.Text != String.Empty)
                {
                    Fra_Datos_Generales.Enabled = true;
                    Txt_ID_Impresora.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                }
                else
                {
                    MessageBox.Show("Para modificar una Impresora, debe seleccionar una de la lista", "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Impresoras())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Impresoras();
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
        ///DESCRIPCIÓN          : Elimina una impresora de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Impresoras_Negocio Impresoras_Eliminar = new Cls_Cat_Impresoras_Negocio();
         
            try
            {
                if (Txt_ID_Impresora.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar la Impresora '" + Txt_ID_Impresora.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Impresoras_Eliminar.P_Impresora_Id = Txt_ID_Impresora.Text;
                        Impresoras_Eliminar.Eliminar_Impressoras();
                        MessageBox.Show("La Impresora '" + Txt_ID_Impresora.Text + "' ha sido eliminada", "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Carga_Impresoras();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar una Impresora, debe seleccionar una de la lista", "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Impresoras", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///FECHA_CREO           : 15 Octubre 2013
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
                Grid_Impresoras.Enabled = true;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN          : Limpia y envia el foco al Txt_Descripcion_Busqueda para realizar una nueva descripción de busqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
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
        ///NOMBRE DE LA FUNCIÓN : Grid_Impresoras_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del elemento seleccionado en los campos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Impresoras_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Impresoras.CurrentRow != null)
            {
                Txt_ID_Impresora.Text = Grid_Impresoras.CurrentRow.Cells["Impresora_Id"].Value.ToString();
                Txt_Nombre_Impresora.Text = Grid_Impresoras.CurrentRow.Cells["Nombre_Impresora"].Value.ToString();
                Txt_Ip.Text = Grid_Impresoras.CurrentRow.Cells["Ip"].Value.ToString();
                Txt_Ubicacion.Text = Grid_Impresoras.CurrentRow.Cells["Ubicacion"].Value.ToString();
                Txt_Comentarios.Text = Grid_Impresoras.CurrentRow.Cells["Comentarios"].Value.ToString();
            }
        }

        #endregion



    }
}
