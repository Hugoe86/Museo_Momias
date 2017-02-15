using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ERP_BASE.Paginas.Paginas_Generales;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Microsoft.VisualBasic;
using Operaciones.Cajas.Negocio;
using Erp.Constantes;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Impresoras_Cajas : Form
    {
        private DataTable Cajas = null;

        public Frm_Cat_Impresoras_Cajas()
        {
            InitializeComponent();
        }

        #region Métodos Generales

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Impresoras_Cajas_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendilola
        ///FECHA_CREO           : 25 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Frm_Cat_Impresoras_Cajas_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Datos
        ///DESCRIPCIÓN          : Inicializa los controles de pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Cargar_Datos()
        {
            Cls_Cat_Cajas_Negocio P_Cajas = new Cls_Cat_Cajas_Negocio(); // Variable utilizada para obtener la informacion de las cajas registradas en la base de datos

            P_Cajas.P_Estatus = "ACTIVO";
            Cajas = P_Cajas.Consultar_Caja();

            DataRow Nueva_Fila = Cajas.NewRow();
            Nueva_Fila[Cat_Cajas.Campo_Caja_ID] = "0";
            Nueva_Fila[Cat_Cajas.Campo_Comentarios] = "<-SELECCIONE->";
            Cajas.Rows.InsertAt(Nueva_Fila, 0);

            Cmb_Impresoras_Caja_ID.DataSource = Cajas;
            Cmb_Impresoras_Caja_ID.DisplayMember = "Caja_Numero";
            Cmb_Impresoras_Caja_ID.ValueMember = Cat_Cajas.Campo_Caja_ID;

        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25 Octubre 2013
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
                        Cmb_Impresoras_Caja_ID.Enabled = true;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Salir.Enabled = true;
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
                        Btn_Salir.Enabled = true;
                        Btn_Impresora_Accesos.Enabled = true;
                        Btn_Impresora_Pago.Enabled = true;
                        Btn_Impresora_Servicios.Enabled = true;
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
                        Cmb_Impresoras_Caja_ID.Enabled = true;
                        Btn_Nuevo.Enabled = false;
                        Cmb_Impresoras_Caja_ID.SelectedIndex = 0;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Btn_Impresora_Accesos.Enabled = false;
                        Btn_Impresora_Pago.Enabled = false;
                        Btn_Impresora_Servicios.Enabled = false;
                        break;
                    }
                default: break;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Impresoras_Cajas
        ///DESCRIPCIÓN          : Realiza el registro de una Impresora de las Cajas en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 26 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Alta_Impresoras_Cajas()
        {
            Cls_Cat_Impresoras_Cajas_Negocio Impresoras_Cajas_Nuevo = new Cls_Cat_Impresoras_Cajas_Negocio();
            Boolean Alta = false;

            try
            {
                Impresoras_Cajas_Nuevo.P_Caja_ID = Cmb_Impresoras_Caja_ID.SelectedValue.ToString();
                Impresoras_Cajas_Nuevo.P_Impresora_Pago = Txt_Impresora_Pago.Text;
                Impresoras_Cajas_Nuevo.P_Impresora_Accesos = Txt_Impresora_Accesos.Text;
                Impresoras_Cajas_Nuevo.P_Impresora_Servicios = Txt_Impresora_Servicios.Text;
                Impresoras_Cajas_Nuevo.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Impresoras_Cajas_Nuevo.P_Fecha_Creo = DateTime.Now;
                Impresoras_Cajas_Nuevo.Alta_Impresoras_Cajas();
                MessageBox.Show("Las Impresoras han sido registradas", "Impresoras Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Alta = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impresoras Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Impresoras_Caja
        ///DESCRIPCIÓN          : Realiza la modificación de las impresoras de las cajas en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 28 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Modificar_Impresoras_Caja()
        {
            Cls_Cat_Impresoras_Cajas_Negocio Impresoras_Cajas_Modificar = new Cls_Cat_Impresoras_Cajas_Negocio();

            try
            {
                Impresoras_Cajas_Modificar.P_Caja_ID = Cmb_Impresoras_Caja_ID.SelectedValue.ToString();
                Impresoras_Cajas_Modificar.P_Impresora_Pago = Txt_Impresora_Pago.Text;
                Impresoras_Cajas_Modificar.P_Impresora_Accesos = Txt_Impresora_Accesos.Text;
                Impresoras_Cajas_Modificar.P_Impresora_Servicios = Txt_Impresora_Servicios.Text;
                Impresoras_Cajas_Modificar.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Impresoras_Cajas_Modificar.P_Fecha_Modifico = DateTime.Now;
                Impresoras_Cajas_Modificar.Modificar_Impresoras_Cajas();
                MessageBox.Show("Las Impresoras de  la '" + Cmb_Impresoras_Caja_ID.Text + "' ha sido modificadas", "Impresoras Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Impresoras Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        #endregion

        #region Eventos

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para registrar las impresoras de las cajas en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 28 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text.Trim() == "Nuevo")
            {
                Manejo_Botones_Operacion("Nuevo");
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Impresoras_Cajas, true);
                Cmb_Impresoras_Caja_ID.Enabled = false;
            }
            else
            {
                if (Alta_Impresoras_Cajas())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Cargar_Datos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar impresoras de las cajas
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 28 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Cmb_Impresoras_Caja_ID.Text != String.Empty)
                {
                    Fra_Impresoras_Cajas.Enabled = true;
                    Cmb_Impresoras_Caja_ID.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                }
                else
                {
                    MessageBox.Show("Para modificar las impresoras, debe seleccionar una caja de la lista", "Impresoras Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Impresoras_Caja())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Cargar_Datos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : Elimina las impresoras de una de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mensiola
        ///FECHA_CREO           : 28 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Impresoras_Cajas_Negocio Impresoras_Cajas_Eliminar = new Cls_Cat_Impresoras_Cajas_Negocio();

            try
            {
                if (Cmb_Impresoras_Caja_ID.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar las impresoras de la '" + Cmb_Impresoras_Caja_ID.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Impresoras_Cajas_Eliminar.P_Caja_ID = Cmb_Impresoras_Caja_ID.SelectedValue.ToString();
                        Impresoras_Cajas_Eliminar.Eliminar_Impresoras_Cajas();
                        MessageBox.Show("Las impresoras de la '" + Cmb_Impresoras_Caja_ID.Text + "' ha sido eliminada", "Impresoras Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Impresoras_Cajas);
                        Cargar_Datos();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar impresoras, debe seleccionar una caja de la lista", "Impresoras Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///FECHA_CREO           : 28 Octubre 2013
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
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Impresoras_Caja_ID_SelectedIndexChanged
        ///DESCRIPCIÓN          : 
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 26 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Impresoras_Caja_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lipiar las cajas de texto
            Txt_Impresora_Pago.Text = "";
            Txt_Impresora_Accesos.Text = "";
            Txt_Impresora_Servicios.Text = "";

            if (Cmb_Impresoras_Caja_ID.SelectedIndex > 0)
            {
                Cls_Cat_Impresoras_Cajas_Negocio Consulta_Impresoras = new Cls_Cat_Impresoras_Cajas_Negocio();

                DataTable Impresoras_Cajas = null;
                Consulta_Impresoras.P_Caja_ID = Cmb_Impresoras_Caja_ID.SelectedValue.ToString();
                Impresoras_Cajas = Consulta_Impresoras.Consultar_Impresoras_Cajas();

                // validar resultado de la consulta
                if (Impresoras_Cajas.Rows.Count > 0)
                {
                    Btn_Nuevo.Enabled = false;
                    Btn_Modificar.Enabled = true;
                    Btn_Eliminar.Enabled = true;
                    // mostrar impresoras
                    Txt_Impresora_Pago.Text = Impresoras_Cajas.Rows[0][Cat_Impresoras_Cajas.Campo_Impresora_Pago].ToString();
                    Txt_Impresora_Accesos.Text = Impresoras_Cajas.Rows[0][Cat_Impresoras_Cajas.Campo_Impresora_Accesos].ToString();
                    Txt_Impresora_Servicios.Text = Impresoras_Cajas.Rows[0][Cat_Impresoras_Cajas.Campo_Impresora_Servicios].ToString();
                }
                else
                {
                    Btn_Nuevo.Enabled = true;
                    Btn_Modificar.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                }
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Impresora_Pago_Click
        ///DESCRIPCIÓN          : Asigna el nombre de la impresora al campo impresora_Pago
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 28 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Impresora_Pago_Click(object sender, EventArgs e)
        {
            PrintDialog Pdg_Impresoras = new PrintDialog();
            DialogResult result = Pdg_Impresoras.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Txt_Impresora_Pago.Text = Pdg_Impresoras.PrinterSettings.PrinterName;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Impresora_Pago_Click
        ///DESCRIPCIÓN          : Asigna el nombre de la impresora al campo impresora_Accesos
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 28 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Impresora_Accesos_Click(object sender, EventArgs e)
        {
            PrintDialog Pdg_Impresoras = new PrintDialog();
            DialogResult result = Pdg_Impresoras.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Txt_Impresora_Accesos.Text = Pdg_Impresoras.PrinterSettings.PrinterName;
            }
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Impresora_Pago_Click
        ///DESCRIPCIÓN          : Asigna el nombre de la impresora al campo impresora_Servicios
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 28 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Impresora_Servicios_Click(object sender, EventArgs e)
        {
            PrintDialog Pdg_Impresoras = new PrintDialog();
            DialogResult result = Pdg_Impresoras.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Txt_Impresora_Servicios.Text = Pdg_Impresoras.PrinterSettings.PrinterName;
            }
        }
        #endregion

        

    }
}
