using System;
using ERP_BASE.App_Code.Negocio.Catalogos;
using ERP_BASE.Paginas.Paginas_Generales;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using Microsoft.VisualBasic;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Cajas : Form
    {
        public Frm_Cat_Cajas()
        {
            InitializeComponent();
            Grid_Cajas.AutoGenerateColumns = false;
        }

        #region Métodos Generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Cajas_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Cajas_Load(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            Carga_Cajas();
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Cajas", this);
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Cajas);
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
        private void Carga_Cajas()
        {
            Cls_Cat_Cajas_Negocio Caja_Consultar = new Cls_Cat_Cajas_Negocio();

            try
            {
                Grid_Cajas.DataSource = Caja_Consultar.Consultar_Caja();
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
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
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
                        Grid_Cajas.Enabled = false;
                        Fra_Buscar.Visible = false;
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
                        Grid_Cajas.Enabled = false;
                        Fra_Buscar.Visible = false;
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
                        Erp_Validaciones.Clear();
                        Grid_Cajas.Enabled = true;
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
        ///CREO                 : Héctor Gabriel Galicia Luna
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

            if (Txt_Numero_Caja.Text == String.Empty)
            {
                Campos_Faltan += "Ingresar un número de caja";
                Erp_Validaciones.SetError(Txt_Numero_Caja, "Debe de ingresar un número de caja");
                Resultado &= false;
            }
            else if(!Information.IsNumeric(Txt_Numero_Caja.Text))
            {
                Campos_Faltan += "Ingresar sólo números enteros";
                Erp_Validaciones.SetError(Txt_Numero_Caja, "Debe de ingresar sólo números enteros");
                Resultado &= false;
            }

            if (Cmb_Estatus.Text == String.Empty)
            {
                Campos_Faltan += "Debe de seleccionar un estatus";
                Erp_Validaciones.SetError(Cmb_Estatus, "Debe de seleccionar un estatus");
                Resultado &= false;
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Caja
        ///DESCRIPCIÓN          : Realiza el registro de una caja en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Alta_Caja()
        {
            Cls_Cat_Cajas_Negocio Caja_Nuevo = new Cls_Cat_Cajas_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta())
                {
                    Caja_Nuevo.P_Numero_Caja = Txt_Numero_Caja.Text;
                    Caja_Nuevo.P_Estatus = Cmb_Estatus.Text;
                    Caja_Nuevo.P_Comentarios = Txt_Comentarios.Text;
                    Caja_Nuevo.P_Nombre_Equipo = Txt_Nombre_Equipo.Text;
                    Caja_Nuevo.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Caja_Nuevo.P_Fecha_Creo = DateTime.Now;
                    Caja_Nuevo.P_Serie = Txt_Serie_Caja.Text;
                    Caja_Nuevo.Alta_Cajas();
                    MessageBox.Show("La Caja ha sido registrada", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja
        ///DESCRIPCIÓN          : Realiza la modificación de una caja en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Modificar_Caja()
        {
            Cls_Cat_Cajas_Negocio Caja_Modificar = new Cls_Cat_Cajas_Negocio();

            try
            {
                if (Validar_Alta())
                {
                    Caja_Modificar.P_Caja_ID = Txt_Caja_Id.Text;
                    Caja_Modificar.P_Numero_Caja = Txt_Numero_Caja.Text;
                    Caja_Modificar.P_Estatus = Cmb_Estatus.Text;
                    Caja_Modificar.P_Comentarios = Txt_Comentarios.Text;
                    Caja_Modificar.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Caja_Modificar.P_Fecha_Modifico = DateTime.Now;
                    Caja_Modificar.P_Nombre_Equipo = Txt_Nombre_Equipo.Text;
                    Caja_Modificar.P_Serie = Txt_Serie_Caja.Text;
                    Caja_Modificar.Modificar_Caja();
                    MessageBox.Show("La Caja '" + Txt_Caja_Id.Text + "' ha sido modificada", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return false;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Caja
        ///DESCRIPCIÓN          : Realiza la consulta de cajas en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Caja()
        {
            Cls_Cat_Cajas_Negocio Caja_Consultar = new Cls_Cat_Cajas_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id de Caja":
                        Caja_Consultar.P_Caja_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Cajas.DataSource = Caja_Consultar.Consultar_Caja();
                        break;

                    case "Numero de Caja":
                        Caja_Consultar.P_Numero_Caja = Txt_Descripcion_Busqueda.Text;
                        Grid_Cajas.DataSource = Caja_Consultar.Consultar_Caja();
                        break;

                    case "Estatus":
                        Caja_Consultar.P_Estatus = Txt_Descripcion_Busqueda.Text;
                        Grid_Cajas.DataSource = Caja_Consultar.Consultar_Caja();
                        break;

                    case "Comentarios":
                        Caja_Consultar.P_Comentarios = Txt_Descripcion_Busqueda.Text;
                        Grid_Cajas.DataSource = Caja_Consultar.Consultar_Caja();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        #endregion

        #region Eventos
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Acutalizar_Nombre_Equipo_Click
        ///DESCRIPCIÓN          : Inicia el proceso de actualizar el nombre del equipo
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 13 Febrero 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Acutalizar_Nombre_Equipo_Click(object sender, EventArgs e)
        {
            try
            {
                Txt_Nombre_Equipo.Text = Environment.MachineName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Acutalizar_Nombre_Equipo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
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
                Txt_Caja_Id.Enabled = false;
                Txt_Nombre_Equipo.Enabled = false;
                Txt_Nombre_Equipo.Text = Environment.MachineName;
            }
            else
            {
                if (Alta_Caja())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Cajas();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar una caja
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_Caja_Id.Text != String.Empty)
                {
                    Fra_Datos_Generales.Enabled = true;
                    Txt_Caja_Id.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                    Txt_Nombre_Equipo.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Para modificar una caja, debe seleccionar una de la lista", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Caja()) 
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Cajas();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
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
        ///DESCRIPCIÓN          : Elimina una caja de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Cajas_Negocio Caja_Eliminar = new Cls_Cat_Cajas_Negocio();

            try
            {
                if (Txt_Caja_Id.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar la caja '" + Txt_Numero_Caja.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Caja_Eliminar.P_Caja_ID = Txt_Caja_Id.Text;
                        Caja_Eliminar.Eliminar_Caja();
                        MessageBox.Show("La caja '" + Txt_Caja_Id.Text + "' ha sido eliminada", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Carga_Cajas();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar una caja, debe seleccionar una de la lista", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
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
                Grid_Cajas.Enabled = true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Numero_Caja_KeyPress
        ///DESCRIPCIÓN          : Valida que sólo se puedan introducir números.
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 05 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Numero_Caja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Apellido_Materno_Leave
        ///DESCRIPCIÓN          : convierte al curp a mayuscula
        ///PARÁMETROS           :
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Serie_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Txt_Serie_Caja.Text))
                {
                    Txt_Serie_Caja.Text = Txt_Serie_Caja.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "**Txt_Apellido_Materno_Leave: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Eventos Grid

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Cajas_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del registro seleccionado en los campos correspondientes
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 05 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Cajas_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Cajas.CurrentRow != null)
            {
                Txt_Caja_Id.Text = Grid_Cajas.CurrentRow.Cells["Caja_ID"].Value.ToString();
                Txt_Numero_Caja.Text = Grid_Cajas.CurrentRow.Cells["Numero_Caja"].Value.ToString();
                Cmb_Estatus.Text = Grid_Cajas.CurrentRow.Cells["Estatus"].Value.ToString();
                Txt_Comentarios.Text = Grid_Cajas.CurrentRow.Cells["Comentarios"].Value.ToString();
                Txt_Nombre_Equipo.Text = Grid_Cajas.CurrentRow.Cells["Nombre_Equipo"].Value.ToString();
                Txt_Serie_Caja.Text = Grid_Cajas.CurrentRow.Cells["Prefijo"].Value.ToString();
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Estatus_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 05 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Estatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        private void Btn_Limpiar_Nombre_Equipo_Click(object sender, EventArgs e)
        {
            try
            {
                Txt_Nombre_Equipo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Btn_Acutalizar_Nombre_Equipo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }


        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de cajas
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Busqueda_Click_1(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Caja();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
        }




        

        
    }
}