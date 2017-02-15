using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Catalogos.Turnos.Negocio;
using Erp.Metodos_Generales;
using Erp.Validador;
using ERP_BASE.Paginas.Paginas_Generales;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Turnos : Form
    {
        private Validador_Generico Validador = null;

        #region Métodos Generales
        public Frm_Cat_Turnos()
        {
            InitializeComponent();
            Grid_Turnos.AutoGenerateColumns = false;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Productos_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Turnos_Load(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            Carga_Turnos();
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Turnos", this);
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Turnos);
            Validador = new Validador_Generico(Erp_Validaciones);
            Erp_Validaciones.Clear();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Carga_Turnos
        ///DESCRIPCIÓN          : Método para consultar todos los turnos registrados
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Carga_Turnos()
        {
            Cls_Cat_Turnos_Negocio P_Turno = new Cls_Cat_Turnos_Negocio();

            try
            {
                Grid_Turnos.DataSource = P_Turno.Consultar_Turnos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para manejo de los estados de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
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
                        Grid_Turnos.Enabled = false;
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
                        Grid_Turnos.Enabled = false;
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
                        Grid_Turnos.Enabled = true;
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
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
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
                Campos_Faltan += "Introducir el nombre del Turno.\n";
                Erp_Validaciones.SetError(Lbl_Nombre, "Debe de introducir el nombre del turno");
                Resultado &= false;
            }

            if (Cmb_Hora_Inicio.Text == String.Empty) 
            {
                Campos_Faltan += "Seleccionar un horario de inicio.\n";
                Erp_Validaciones.SetError(Cmb_Hora_Inicio, "Debe de seleccionar un horario de inicio");
                Resultado &= false;
            }

            if (Cmb_Hora_Cierre.Text == String.Empty) 
            {
                Campos_Faltan += "Seleccionar un horario de cierre.\n";
                Erp_Validaciones.SetError(Cmb_Hora_Cierre, "Debe de seleccionar un horario de cierre");
                Resultado &= false;
            }

            if (Cmb_Estatus.Text == String.Empty)
            {
                Campos_Faltan += "Seleccionar un estatus para el turno.\n";
                Erp_Validaciones.SetError(Cmb_Estatus, "Debe de seleccionar un estatus para el turno");
                Resultado &= false;
            }

            if (Cmb_Fijo.Text == String.Empty)
            {
                Campos_Faltan += "Indicar si el turno es fijo o no.\n";
                Erp_Validaciones.SetError(Cmb_Fijo, "Debe indicar si el turno es fijo o no");
                Resultado &= false;
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Producto
        ///DESCRIPCIÓN          : Realiza el registro de un producto en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Alta_Turno()
        {
            Cls_Cat_Turnos_Negocio Turno_Nuevo = new Cls_Cat_Turnos_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta())
                {
                    Turno_Nuevo.P_Nombre = Txt_Nombre.Text;
                    Turno_Nuevo.P_Comentarios = Txt_Comentarios.Text;
                    Turno_Nuevo.P_Hora_Inicio = Cmb_Hora_Inicio.Text;
                    Turno_Nuevo.P_Hora_Cierre = Cmb_Hora_Cierre.Text;
                    Turno_Nuevo.P_Estatus = Cmb_Estatus.Text;
                    Turno_Nuevo.P_Fijo = Cmb_Fijo.Text;
                    Turno_Nuevo.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Turno_Nuevo.P_Fecha_Creo = DateTime.Now;
                    Turno_Nuevo.Alta_Turnos();
                    MessageBox.Show("El turno ha sido registrado", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Producto
        ///DESCRIPCIÓN          : Realiza la modificación de un producto en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        public Boolean Modificar_Turno()
        {
            Cls_Cat_Turnos_Negocio Turno_Modificar = new Cls_Cat_Turnos_Negocio();

            try
            {
                if (Validar_Alta())
                {
                    Turno_Modificar.P_Turno_ID = Txt_ID_Turno.Text;
                    Turno_Modificar.P_Nombre = Txt_Nombre.Text;
                    Turno_Modificar.P_Comentarios = Txt_Comentarios.Text;
                    Turno_Modificar.P_Hora_Inicio = Cmb_Hora_Inicio.Text;
                    Turno_Modificar.P_Hora_Cierre = Cmb_Hora_Cierre.Text;
                    Turno_Modificar.P_Estatus = Cmb_Estatus.Text;
                    Turno_Modificar.P_Fijo = Cmb_Fijo.Text;
                    Turno_Modificar.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Turno_Modificar.P_Fecha_Modifico = DateTime.Now;
                    Turno_Modificar.Modificar_Turno();
                    MessageBox.Show("El turno '" + Txt_ID_Turno.Text + "' ha sido modificado", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Turno_Consultar
        ///DESCRIPCIÓN          : Realiza la consulta productos en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Turno_Consultar()
        {
            Cls_Cat_Turnos_Negocio Turno_Consultar = new Cls_Cat_Turnos_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id de Turno":
                        Turno_Consultar.P_Turno_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Turnos.DataSource = Turno_Consultar.Consultar_Turnos();
                        break;

                    case "Nombre":
                        Turno_Consultar.P_Nombre = Txt_Descripcion_Busqueda.Text;
                        Grid_Turnos.DataSource = Turno_Consultar.Consultar_Turnos();
                        break;

                    case "Estatus":
                        Turno_Consultar.P_Estatus = Txt_Descripcion_Busqueda.Text;
                        Grid_Turnos.DataSource = Turno_Consultar.Consultar_Turnos();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de turnos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Turno_Consultar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
            Carga_Turnos();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para crear un nuevo turno
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
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
                
            }
            else
            {
                if (Alta_Turno())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Turnos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar un turno
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_ID_Turno.Text != String.Empty)
                {
                    Fra_Datos_Generales.Enabled = true;
                    Txt_ID_Turno.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                }
                else
                {
                    MessageBox.Show("Para modificar un turno, debe seleccionar uno de la lista", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Turno())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Turnos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
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
        ///DESCRIPCIÓN          : Elimina un turno de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Turnos_Negocio Turno_Eliminar = new Cls_Cat_Turnos_Negocio();

            try
            {
                if (Txt_ID_Turno.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar el turno '" + Txt_ID_Turno.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Turno_Eliminar.P_Turno_ID = Txt_ID_Turno.Text;
                        Turno_Eliminar.Eliminar_Turno();
                        MessageBox.Show("El producto '" + Txt_ID_Turno.Text + "' ha sido eliminado", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Carga_Turnos();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar un turno, debe seleccionar uno de la lista", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///FECHA_CREO           : 07 Octubre 2013
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
                Grid_Turnos.Enabled = true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Hora_Inicio_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Hora_Inicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Hora_Cierre_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Hora_Cierre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Estatus_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Estatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Fijo_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Fijo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
        ///
        private void Cmb_Busqueda_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Descripcion_Busqueda.Text = "";
            Txt_Descripcion_Busqueda.Focus();
        }
        #endregion

        #region Eventos Grid
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Turnos_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del elemento seleccionado en los campos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Turnos_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Turnos.CurrentRow != null)
            {
                Txt_ID_Turno.Text = Grid_Turnos.CurrentRow.Cells["Turno_ID"].Value.ToString();
                Txt_Nombre.Text = Grid_Turnos.CurrentRow.Cells["Nombre"].Value.ToString();
                Txt_Comentarios.Text = Grid_Turnos.CurrentRow.Cells["Comentarios"].Value.ToString();
                Cmb_Hora_Inicio.Text = Grid_Turnos.CurrentRow.Cells["Hora_Inicio"].Value.ToString();
                Cmb_Hora_Cierre.Text = Grid_Turnos.CurrentRow.Cells["Hora_Cierre"].Value.ToString();
                Cmb_Estatus.Text = Grid_Turnos.CurrentRow.Cells["Estatus"].Value.ToString();
                Cmb_Fijo.Text = Grid_Turnos.CurrentRow.Cells["Fijo"].Value.ToString();
            }
        }
        #endregion

    }
}
