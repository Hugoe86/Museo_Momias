using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Erp_Ope_Pagos.Negocio;
using Erp.Constantes;
using Erp.Metodos_Generales;
using Erp.Validador;
using ResizeableForm;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Ope_Descuentos : ResizableForm
    {
        #region "Variables Globales"

        Validador_Generico Validador;

        #endregion

        #region Page_Load

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Frm_Ope_Descuentos
        ///DESCRIPCIÓN  : Carga los elementos del formulario
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public Frm_Ope_Descuentos()
        {
            InitializeComponent();
            Inicializar_Controles();
            Validador = new Validador_Generico(Error_Provider);
            Rellena_Combo_Busqueda();
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Cancelaciones", this);
            Error_Provider.Clear();
        }
        #endregion Page_Load

        #region Metodos_Generales
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Inicializar_Controles
        ///DESCRIPCIÓN  : cofigura el formulario
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Inicializar_Controles()
        {
            try
            {
                Limpiar_Controles();
                Habilitar_Controles("Inicial");
                Consultar_Pagos();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Limpiar_Controles
        ///DESCRIPCIÓN  : Limpia los elementos del formulario
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Limpiar_Controles()
        {
            try
            {
                //  Cajas de texto
                Txt_No_Pago.Text = "";
                Txt_No_Venta.Text = "";
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Habilitar_Controles
        ///DESCRIPCIÓN  :configura los botones
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Habilitar_Controles(String Operacion)
        {
            Boolean Estatus = false;
            if (Grb_Busqueda_Pagos.Visible)
            {
                Grb_Busqueda_Pagos.Visible = false;
                Grb_Busqueda_Pagos.Enabled = false;
                Grb_Generales.Visible = true;
                Grb_Busqueda_Pagos.Enabled = true;
            }
            switch (Operacion)
            {
                case "Inicial":
                    //Hacemos visible el frame de datos generales
                    Grb_Generales.Visible = true;

                    //  se habilitan los botones
                    Btn_Modificar.Enabled = true;
                    Btn_Buscar.Enabled = true;
                    Btn_Salir.Enabled = true;

                    //  se asignan los nombres
                    Btn_Modificar.Text = "Modificar";
                    Btn_Salir.Text = "Salir";

                    //  asigna el icono a los boton
                    Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                    Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;

                    Estatus = false;
                    break;

                case "Nuevo":
                    //Hacemos visible el frame de datos generales
                    Grb_Generales.Visible = true;

                    //  se desabilitan los botones
                    Btn_Modificar.Enabled = false;
                    Btn_Buscar.Enabled = false;

                    //  se habilitan los botones
                    Btn_Salir.Enabled = true;

                    //  se asignan los nombres
                    Btn_Salir.Text = "Cancelar";

                    //  cambia el icono del boton
                    Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;

                    Estatus = true;
                    break;

                case "Modificar":
                    //Hacemos visible el frame de datos generales
                    Grb_Generales.Visible = true;

                    //  se desabilitan los botones
                    Btn_Buscar.Enabled = false;

                    //  se habilitan los botones
                    Btn_Modificar.Enabled = true;
                    Btn_Salir.Enabled = true;

                    //  se asignan los nombres
                    Btn_Modificar.Text = "Actualizar";
                    Btn_Salir.Text = "Cancelar";

                    //  cambia el icono del boton
                    Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                    Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;

                    Estatus = true;
                    break;
            }

            Error_Provider.Clear();
            Txt_No_Venta.Enabled = Estatus;

            //  grids
            Grid_Pagos.Enabled = !Estatus;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Rellena_Combo_Busqueda
        ///DESCRIPCIÓN  : Rellena el combo box de las busquedas.
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Rellena_Combo_Busqueda()
        {
            DataTable Dt_Campos = new DataTable();
            Dt_Campos.Columns.Add("Valor");
            Dt_Campos.Columns.Add("Descripcion");
            Dt_Campos.Rows.Add(new String[] { "0", "<-SELECCIONE->" });
            Dt_Campos.Rows.Add(new String[] { Apl_Roles.Campo_Nombre, "NOMBRE" });
            Dt_Campos.Rows.Add(new String[] { Apl_Roles.Campo_Descripcion, "DESCRIPCION" });
            Cmb_Busqueda_Pagos.DataSource = Dt_Campos;
            Cmb_Busqueda_Pagos.DisplayMember = "Descripcion";
            Cmb_Busqueda_Pagos.ValueMember = "Valor";
        }
        #region Consultas

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Pagos
        ///DESCRIPCIÓN  : Consultara todos los roles de la base de datos
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public void Consultar_Pagos()
        {
            Cls_Ope_Pagos_Negocio Pagos = new Cls_Ope_Pagos_Negocio();
            DataTable Dt_Consulta = new DataTable();
            int Indice = 0;

            Dt_Consulta = Pagos.Consultar_Pagos();

            Grid_Pagos.Rows.Clear();

            if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
            {
                foreach (DataRow Renglon in Dt_Consulta.Rows)
                {
                    Grid_Pagos.Rows.Add();
                    Grid_Pagos.Rows[Indice].Cells[Apl_Roles.Campo_Rol_Id].Value = Renglon[Apl_Roles.Campo_Rol_Id];
                    Grid_Pagos.Rows[Indice].Cells[Apl_Roles.Campo_Nombre].Value = Renglon[Apl_Roles.Campo_Nombre];
                    Grid_Pagos.Rows[Indice].Cells[Apl_Roles.Campo_Descripcion].Value = Renglon[Apl_Roles.Campo_Descripcion];
                    Grid_Pagos.Rows[Indice].Cells[Apl_Roles.Campo_Estatus].Value = Renglon[Apl_Roles.Campo_Estatus];
                    Indice++;
                }
                Grid_Pagos.Columns[Apl_Roles.Campo_Rol_Id].Visible = false;
            }
            else
            {
                Grid_Pagos.Refresh();
            }

            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Pagos);// se asigna el tipo de letra y tamaño
        }
        #endregion Consultas

        #region Acciones
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Modificar
        ///DESCRIPCIÓN  : modifica el registro seleccionado
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public Boolean Modificar()
        {
            Boolean Estatus = false;
            Cls_Ope_Pagos_Negocio Pagos = new Cls_Ope_Pagos_Negocio();

            Pagos.P_No_Pago = Txt_No_Pago.Text;
            Pagos.P_No_Caja = Txt_No_Venta.Text;
            Pagos.P_No_Venta = Txt_No_Venta.Text;
            Pagos.Modificar_Pago();
            Estatus = true;

            return Estatus;
        }

        #endregion Acciones

        #endregion Metodos_Generales

        #region Grid
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Grid_Pagos_CellClick
        ///DESCRIPCIÓN  : Carga la informacion del grid en las cajas de texto
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Grid_Pagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Indice = 0;
            try
            {
                Indice = Grid_Pagos.CurrentRow.Index;
                //Limpiar_Controles();
                Txt_No_Pago.Text = Grid_Pagos.Rows[Indice].Cells[0].Value.ToString();
                Txt_No_Venta.Text = Grid_Pagos.Rows[Indice].Cells[1].Value.ToString();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        #endregion Grid

        #region Eventos
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
        ///DESCRIPCIÓN  : Modifica un registro existente
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Modificar.Text == "Modificar")
                {
                    if (Txt_No_Pago.Text.Trim() != "")
                    {
                        Habilitar_Controles("Modificar");
                    }
                    else
                    {
                        MessageBox.Show(this, "Debe Seleccionar un registro de la lista.", "Modificar Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (this.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        if (Modificar())
                        {
                            Inicializar_Controles();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Modificar Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
        ///DESCRIPCIÓN  : Evento de botón Btn_Salir para abandonar el formnulario
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Salir.Text == "Salir")
                {
                    this.Close();
                }
                else
                {
                    Inicializar_Controles();
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cmb_Busqueda_Pagos_SelectedIndexChanged
        ///DESCRIPCIÓN  : Muestra u oculta el campo de descripción o el combo de giros.
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Cmb_Busqueda_Pagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Pagos.SelectedIndex < 1)
            {
                Btn_Busqueda.Enabled = false;
                Txt_Descripcion_Busqueda.Enabled = false;
            }
            else
            {
                Btn_Busqueda.Enabled = true;
                Txt_Descripcion_Busqueda.Enabled = true;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Buscar_Click
        ///DESCRIPCIÓN  : Muestra el panel de busqueda.
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Grb_Busqueda_Pagos.Visible = true;
            Grb_Busqueda_Pagos.Enabled = true;
            Grb_Generales.Visible = false;
            Cmb_Busqueda_Pagos.SelectedIndex = 0;
            Txt_Descripcion_Busqueda.Enabled = false;
            Error_Provider.Clear();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Regresar_Click
        ///DESCRIPCIÓN  : Oculta el panel de busqueda.
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Grb_Busqueda_Pagos.Visible = false;
            Grb_Busqueda_Pagos.Enabled = false;
            Grb_Generales.Visible = true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Busqueda_Click
        ///DESCRIPCIÓN  : Realiza la busqueda del rol.
        ///PARAMENTROS  :
        ///CREO         : Antonio Salvador Benavides Guardado
        ///FECHA_CREO   : 03/Octubre/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Txt_Descripcion_Busqueda.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Favor de rellenar el campo descripción.", "Búsqueda Pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Consultar_Pagos();
        }
        #endregion Eventos

        #region Validaciones
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Alfanumerico_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres Alfanuméricos.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Alfanumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Descuento_Validating
        ///DESCRIPCIÓN  : Valida que se escriba correctamente un campo de tipo moneda(flotante).
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Requerido_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
        }

        #endregion Validaciones        

        
    }
}