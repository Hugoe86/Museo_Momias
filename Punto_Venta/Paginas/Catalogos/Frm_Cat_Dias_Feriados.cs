using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using Catalogos.Dias.Feriados.Negocio;
using Erp.Constantes;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Dias_Feriados : Form
    {
        public Frm_Cat_Dias_Feriados()
        {
            InitializeComponent();
            Grid_Dias_Feriados.AutoGenerateColumns = false;
        }

        #region Métodos Generales
        private void Frm_Cat_Dias_Feriados_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
            Cargar_Dias();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Dias
        ///DESCRIPCIÓN          : Método que carga todos los dias feriados registrados en el sistema
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Cargar_Dias()
        {
            Cls_Cat_Dias_Feriados_Negocio P_Dia = new Cls_Cat_Dias_Feriados_Negocio();

            try
            {
                Grid_Dias_Feriados.DataSource = P_Dia.Consultar_Dias();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para manejo de los estados de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Héctor Gabriel Galicia Luna
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
                        Grid_Dias_Feriados.Enabled = false;
                        Fra_Buscar.Visible = false;
                        Opt_Actual.Enabled = true;
                        Opt_Todos.Enabled = true;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Txt_Anios.Text = "";
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
                        Grid_Dias_Feriados.Enabled = false;
                        Fra_Buscar.Visible = false;
                        Opt_Actual.Enabled = true;
                        Opt_Todos.Enabled = true;
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
                        Grid_Dias_Feriados.Enabled = true;
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                        Opt_Actual.Enabled = false;
                        Opt_Todos.Enabled = false;
                        Opt_Actual.Checked = false;
                        Opt_Todos.Checked = false;
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
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
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
                Erp_Validaciones.SetError(Txt_Descripcion, "Debe indicar la descripcion del día festivo");
                Resultado = false;
            }
            
            if (Dtp_Fecha_Inicio_Periodo.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Dtp_Fecha_Inicio_Periodo, "Debe indicar la Fecha de Inicio del Periodo");
                Resultado = false;
            }
            
            if (Dtp_Fecha_Fin_Periodo.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Dtp_Fecha_Inicio_Periodo, "Debe indicar la Fecha de Inicio del Periodo");
                Resultado = false;
            }
            
            if (Txt_Anios.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Txt_Anios, "Debe seleccionar una opción");
                Resultado = false;
            }
            
            if (Cmb_Estatus.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Cmb_Estatus, "Debe indicar el estatus de el día festivo");
                Resultado = false;
            }

            if (Dtp_Fecha_Inicio_Periodo.Value > Dtp_Fecha_Fin_Periodo.Value)
            {
                MessageBox.Show("La Fecha de Inicio de Periodo no puede ser mayor que la Fecha de Fin de Periodo");
                Resultado = false;
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Dia
        ///DESCRIPCIÓN          : Verifica que los campos obligatorios tengan información
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Alta_Dia()
        {
            Cls_Cat_Dias_Feriados_Negocio P_Dia = new Cls_Cat_Dias_Feriados_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta())
                {
                    P_Dia.P_Descripcion = Txt_Descripcion.Text;
                    P_Dia.P_Fecha = Dtp_Fecha_Inicio_Periodo.Value;
                    P_Dia.P_Fecha_Fin = Dtp_Fecha_Fin_Periodo.Value;
                    P_Dia.P_Anios = Txt_Anios.Text;
                    P_Dia.P_Estatus = Cmb_Estatus.Text;
                    P_Dia.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    P_Dia.P_Fecha_Creo = DateTime.Now;
                    P_Dia.Alta_Dia();
                    Alta = true;

                    string Inicio = Dtp_Fecha_Inicio_Periodo.Value.ToShortDateString();
                    string Fin = Dtp_Fecha_Fin_Periodo.Value.ToShortDateString();

                    MessageBox.Show("El Periodo del '" + Inicio + "' al '" + Fin + "' ha sido registrado",
                        "Días Feriados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Dia
        ///DESCRIPCIÓN          : Modifica la información de un día feriado
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Modificar_Dia()
        {
            Cls_Cat_Dias_Feriados_Negocio P_Dia = new Cls_Cat_Dias_Feriados_Negocio();
            Boolean Modificar = false;

            try
            {
                if (Validar_Alta())
                {
                    P_Dia.P_Dia_ID = Txt_ID_Dia.Text;
                    P_Dia.P_Descripcion = Txt_Descripcion.Text;
                    P_Dia.P_Fecha = Dtp_Fecha_Inicio_Periodo.Value;
                    P_Dia.P_Fecha_Fin = Dtp_Fecha_Fin_Periodo.Value;
                    P_Dia.P_Anios = Txt_Anios.Text;
                    P_Dia.P_Estatus = Cmb_Estatus.Text;
                    P_Dia.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    P_Dia.P_Fecha_Modifico = DateTime.Now;
                    P_Dia.Modificar_Dia();
                    Modificar = true;
                    MessageBox.Show("El día '" + Txt_ID_Dia.Text + "' ha sido modificado", "Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Modificar;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Dia_Feriado
        ///DESCRIPCIÓN          : Realiza la consulta de los bancos en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 22 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Dia_Feriado()
        {
            Cls_Cat_Dias_Feriados_Negocio P_Dia = new Cls_Cat_Dias_Feriados_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id Día":
                        P_Dia.P_Dia_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Dias_Feriados.DataSource = P_Dia.Consultar_Dias();
                        break;

                    case "Descripción":
                        P_Dia.P_Descripcion = Txt_Descripcion_Busqueda.Text;
                        Grid_Dias_Feriados.DataSource = P_Dia.Consultar_Dias();
                        break;

                    case "Estatus":
                        P_Dia.P_Estatus = Txt_Descripcion_Busqueda.Text;
                        Grid_Dias_Feriados.DataSource = P_Dia.Consultar_Dias();
                        break;
                    case "Fecha":
                        P_Dia.P_Fecha = Dtp_Fecha_Inicio_Buscar.Value;
                        P_Dia.P_Fecha_Fin = Dtp_Fecha_Fin_Buscar.Value;
                        Grid_Dias_Feriados.DataSource = P_Dia.Consultar_Dias();
                        //Anios_Feriados();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Anios_Feriados()
        ///DESCRIPCIÓN          : Consulta los dias feriados en año actual o en todos los años
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 23 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Anios_Feriados()
        {
            Cls_Cat_Dias_Feriados_Negocio P_Anios = new Cls_Cat_Dias_Feriados_Negocio();


                if (P_Anios.EsFeriado(Dtp_Fecha_Inicio_Buscar.Value))
                {
                    MessageBox.Show("El día " + Dtp_Fecha_Inicio_Buscar.Text + " es feriado", " Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El día '" + Dtp_Fecha_Inicio_Buscar.Text + "' no es feriado", "Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
        #endregion

        #region Eventos
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de productos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {

            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Dia_Feriado();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Dias Feriados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
            Cargar_Dias();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para crear un nuevo producto
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
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
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                // inicializar valor de fecha
                Dtp_Fecha_Inicio_Periodo.Value = DateTime.Today;
                Opt_Todos.Checked = true;
                Opt_Todos_Click(null, null);
            }
            else
            {
                if (Alta_Dia())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Cargar_Dias();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar un producto
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_ID_Dia.Text != String.Empty)
                {
                    Manejo_Botones_Operacion("Modificar");
                    Txt_ID_Dia.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Para modificar un producto, debe seleccionar uno de la lista", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Dia())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Cargar_Dias();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
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
        ///DESCRIPCIÓN          : Elimina un producto de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Dias_Feriados_Negocio P_Dia = new Cls_Cat_Dias_Feriados_Negocio();

            try
            {
                if (Txt_ID_Dia.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar el día feriado '" + Dtp_Fecha_Inicio_Periodo.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        P_Dia.P_Dia_ID = Txt_ID_Dia.Text;
                        P_Dia.Eliminar_Dia();
                        MessageBox.Show("El día '" + Dtp_Fecha_Inicio_Periodo.Text + "' ha sido eliminado", "Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Cargar_Dias();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar un día, debe seleccionar uno de la lista", "Días Feriados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Grid_Dias_Feriados.Enabled = true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Estatus_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Estatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN          : Valida los campos a habilitar en base a la opción seleccionada
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Busqueda_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.Text == "Fecha")
            {
                Dtp_Fecha_Inicio_Buscar.Enabled = true;
                Dtp_Fecha_Fin_Buscar.Enabled = true;
                Txt_Descripcion_Busqueda.Enabled = false;
            }
            else
            {
                Dtp_Fecha_Inicio_Buscar.Enabled = false;
                Dtp_Fecha_Fin_Buscar.Enabled = false;
                Txt_Descripcion_Busqueda.Enabled = true;
            }

            Txt_Descripcion_Busqueda.Text = "";
            Txt_Descripcion_Busqueda.Focus();
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Rbd_Todos_Click
        ///DESCRIPCIÓN          : Al seleccionar indica que el dia festivo es en todos los años
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 23 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Opt_Todos_Click(object sender, EventArgs e)
        {
            Txt_Anios.Text = "TODOS LOS AÑOS";
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Rbd_Actual_Click
        ///DESCRIPCIÓN          : Al seleccionar indica que el dia festivo es en el año actual
        ///PARÁMETROS           :
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 23 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Opt_Actual_Click(object sender, EventArgs e)
        {
            Txt_Anios.Text = (Dtp_Fecha_Inicio_Periodo.Value.Year.ToString());
        }
        #endregion

        #region Eventos Grid

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Dias_Feriados_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la informacion del registrado seleccionado del grid en los campos correspondientes
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Dias_Feriados_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_Dias_Feriados.CurrentRow != null)
            {
                Txt_ID_Dia.Text = Grid_Dias_Feriados.CurrentRow.Cells[Cat_Dias_Feriados.Campo_Dia_ID].Value.ToString();
                Txt_Descripcion.Text = Grid_Dias_Feriados.CurrentRow.Cells[Cat_Dias_Feriados.Campo_Descripcion].Value.ToString();
                Dtp_Fecha_Inicio_Periodo.Value = DateTime.Parse(Grid_Dias_Feriados.CurrentRow.Cells[Cat_Dias_Feriados.Campo_Fecha].Value.ToString());
                Dtp_Fecha_Fin_Periodo.Value = DateTime.Parse(Grid_Dias_Feriados.CurrentRow.Cells[Cat_Dias_Feriados.Campo_Fecha_Fin].Value.ToString());
                Txt_Anios.Text = Grid_Dias_Feriados.CurrentRow.Cells[Cat_Dias_Feriados.Campo_Anios].Value.ToString();
                Cmb_Estatus.Text = Grid_Dias_Feriados.CurrentRow.Cells[Cat_Dias_Feriados.Campo_Estatus].Value.ToString();

                if (Grid_Dias_Feriados.CurrentRow.Cells[Cat_Dias_Feriados.Campo_Anios].Value.ToString().Contains("TODOS"))
                {
                    Opt_Todos.Checked = true;
                }
                else
                {
                    Opt_Actual.Checked = true;
                }
            }
        }
        #endregion

    }
}
