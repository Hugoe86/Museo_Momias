using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ERP_BASE.Properties;
using Erp_Cat_Giros_Empresariales.Negocio;
using Erp_Cat_Clientes.Negocio;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Validador;

namespace ERP_BASE.Paginas.Paginas_Generales
{   
    public partial class Frm_Cat_Clientes : Form
    {

        #region "Variables Globales"

        Validador_Generico Validador;

        #endregion

        #region Page_Load

        public Frm_Cat_Clientes()
        {
            InitializeComponent();
            Cls_Metodos_Generales.Limpia_Controles(this);
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Clientes);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Clientes, false);
            Cls_Cat_Giros_Empresariales_Negocio Giros_Negocios = new Cls_Cat_Giros_Empresariales_Negocio();
            Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Giros, Giros_Negocios.Consultar_Giro_Empresariales(), Cat_Adm_Giros_Empresariales.Campo_Nombre, Cat_Adm_Giros_Empresariales.Campo_Giro_Id);
            Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Giro_Busqueda, Giros_Negocios.Consultar_Giro_Empresariales(), Cat_Adm_Giros_Empresariales.Campo_Nombre, Cat_Adm_Giros_Empresariales.Campo_Giro_Id);
            Rellena_Combo_Busqueda();            
            Validador = new Validador_Generico(Error_Provider);
            Error_Provider.Clear();
            Consultar();
        }

        private void Frm_Cat_Clientes_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Clientes", this);
        }

        #endregion Page_Load

        #region "Eventos"

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
        ///DESCRIPCIÓN  : Cierra la ventana.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Salir.Text == "Cancelar")
            {
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Clientes, false);
                Cls_Metodos_Generales.Limpia_Controles(this);
                Btn_Modificar.Image = Resources.icono_modificar;
                Btn_Modificar.Text = "Modificar";
                Btn_Nuevo.Image = Resources.icono_nuevo;
                Btn_Nuevo.Text = "Nuevo";
                Btn_Salir.Image = Resources.icono_salir_2;
                Btn_Salir.Text = "Salir";
                Btn_Nuevo.Enabled = true;
                Btn_Modificar.Enabled = true;
                Btn_Buscar.Enabled = true;
                Btn_Eliminar.Enabled = true;
                Grid_Clientes.Enabled = true;
                Error_Provider.Clear();
            }
            else if (Btn_Salir.Text == "Salir")
            {
                this.Close();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Nuevo_Click
        ///DESCRIPCIÓN  : Agrega un registro.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text == "Nuevo")
            {
                Fra_Buscar.Visible = false;
                Fra_Buscar.Enabled = false;
                Fra_Clientes.Visible = true;
                Cls_Metodos_Generales.Limpia_Controles(this);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Clientes, true);
                Txt_Cliente_ID.Text = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes, Cat_Adm_Clientes.Campo_Cliente_Id, null, 5);
                Grid_Clientes.Enabled = false;
                Txt_Cliente_ID.Enabled = false;
                Btn_Nuevo.Image = Resources.icono_actualizar;
                Btn_Nuevo.Text = "Guardar";
                Btn_Salir.Image = Resources.icono_cancelar;
                Btn_Salir.Text = "Cancelar";
                Btn_Modificar.Enabled = false;
                Btn_Buscar.Enabled = false;
                Btn_Eliminar.Enabled = false;
                Error_Provider.Clear();
            }
            else if (Btn_Nuevo.Text == "Guardar")
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (Alta())
                    {
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Clientes, false);
                        Btn_Nuevo.Image = Resources.icono_nuevo;
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Salir.Image = Resources.icono_salir_2;
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Grid_Clientes.Enabled = true;
                        Consultar();
                        MessageBox.Show(this, "Se dio de alta correctamente al cliente.", "Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Ocurrió un erro al dar de alta al cliente.", "Error - Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }            
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
        ///DESCRIPCIÓN  : Modifica un registro.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text == "Modificar")
            {
                if (Grid_Clientes.CurrentRow != null)
                {
                    Fra_Buscar.Visible = false;
                    Fra_Buscar.Enabled = false;
                    Fra_Clientes.Visible = true;
                    Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Clientes, true);
                    Grid_Clientes.Enabled = false;
                    Txt_Cliente_ID.Enabled = false;
                    Btn_Modificar.Image = Resources.icono_actualizar;
                    Btn_Modificar.Text = "Actualizar";
                    Btn_Salir.Image = Resources.icono_cancelar;
                    Btn_Salir.Text = "Cancelar";
                    Btn_Nuevo.Enabled = false;
                    Btn_Buscar.Enabled = false;
                    Btn_Eliminar.Enabled = false;
                    Error_Provider.Clear();
                }
                else
                {
                    MessageBox.Show(this, "Favor de seleccionar un registro de la lista.", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (Btn_Modificar.Text == "Actualizar")
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (Modificar())
                    {
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Clientes, false);
                        Btn_Modificar.Image = Resources.icono_modificar;
                        Btn_Modificar.Text = "Modificar";
                        Btn_Salir.Image = Resources.icono_salir_2;
                        Btn_Salir.Text = "Salir";
                        Btn_Nuevo.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Grid_Clientes.Enabled = true;
                        Consultar();
                        MessageBox.Show(this, "Se modifico correctamente al cliente.", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Ocurrió un erro al dar de alta al cliente.", "Modificar - Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Eliminar_Click
        ///DESCRIPCIÓN  : Elimina un registro.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (Btn_Eliminar.Text == "Eliminar")
            {
                if (Grid_Clientes.CurrentRow != null)
                {
                    if (MessageBox.Show(this, "¿Esta seguro que desea eliminar el registro del cliente " + Grid_Clientes.Rows[Grid_Clientes.CurrentRow.Index].Cells[Cat_Adm_Clientes.Campo_Nombre_Corto].Value.ToString() + "?.", "Eliminar Cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Eliminar())
                        {
                            Error_Provider.Clear();
                            Consultar();
                            Cls_Metodos_Generales.Limpia_Controles(this);
                            MessageBox.Show(this, "Se elimino correctamente al cliente.", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Ocurrió un erro al eliminar al cliente.", "Error - Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Favor de seleccionar un registro de la lista.", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }            
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Grid_Clientes_CellClick
        ///DESCRIPCIÓN  : Carga el registro seleccionado en los campos.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Grid_Clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid_Clientes.Rows.Count > 0)
            {
                int Fila_Seleccionada = Grid_Clientes.CurrentRow.Index;
                Txt_Cliente_ID.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Cliente_Id].Value.ToString();
                Txt_Rfc.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_RFC].Value.ToString();
                Cmb_Giros.SelectedValue = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Giro_Id].Value.ToString();
                Txt_Curp.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_CURP].Value.ToString();
                Txt_Nombre.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Nombre_Corto].Value.ToString();
                Txt_Razon_Social.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Razon_Social].Value.ToString();
                Txt_Pais.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Pais].Value.ToString();
                Txt_Estado.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Estado].Value.ToString();
                Txt_Localidad.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Localidad].Value.ToString();
                Txt_Colonia.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Colonia].Value.ToString();
                Txt_Ciudad.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Ciudad].Value.ToString();
                Txt_Cp.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_CP].Value.ToString();
                Txt_Calle.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Calle].Value.ToString();
                Txt_Num_Exterior.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Numero_Exterior].Value.ToString();
                Txt_Num_Interior.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Numero_Interior].Value.ToString();
                Txt_Fax.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Fax].Value.ToString();
                Txt_Nextel.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Nextel].Value.ToString();
                Txt_Telefono1.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Telefono_1].Value.ToString();
                Txt_Telefono2.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Telefono_2].Value.ToString();
                Txt_Extension.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Extension].Value.ToString();
                Txt_Email.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Email].Value.ToString();
                Txt_Sitio_Web.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Sitio_Web].Value.ToString();
                Txt_Dias_Credito.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Dias_Credito].Value.ToString();
                Txt_Limite_Credito.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Limite_Credito].Value.ToString();
                Txt_Descuento.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Descuento].Value.ToString();
                Cmb_Estatus.Text = Grid_Clientes.Rows[Fila_Seleccionada].Cells[Cat_Adm_Clientes.Campo_Estatus].Value.ToString();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Buscar_Click
        ///DESCRIPCIÓN  : Muestra el panel de busqueda.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Fra_Buscar.Enabled = true;
            Fra_Clientes.Visible = false;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
            Cmb_Giro_Busqueda.Visible = false;
            Txt_Descripcion_Busqueda.Visible = true;
            Error_Provider.Clear();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Regresar_Click
        ///DESCRIPCIÓN  : Oculta el panel de busqueda.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = false;
            Fra_Buscar.Enabled = false;
            Fra_Clientes.Visible = true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Busqueda_Click
        ///DESCRIPCIÓN  : Realiza la busqueda del cliente.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex != 3 && Txt_Descripcion_Busqueda.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Favor de rellenar el campo descripción.", "Búsqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Cmb_Busqueda_Tipo.SelectedIndex == 3 && Cmb_Giro_Busqueda.SelectedIndex == 0)
            {
                MessageBox.Show(this, "Favor de seleccionar el giro del cliente.", "Búsqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Cmb_Busqueda_Tipo.SelectedIndex != 3)
            {
                Consultar(Cmb_Busqueda_Tipo.SelectedValue.ToString(), Txt_Descripcion_Busqueda.Text);
            }
            else
            {
                Consultar(Cmb_Busqueda_Tipo.SelectedValue.ToString(), Cmb_Giro_Busqueda.SelectedValue.ToString());
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN  : Muestra u oculta el campo de descripción o el combo de giros.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Cmb_Busqueda_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex < 1)
            {
                Btn_Busqueda.Enabled = false;
            }
            else
            {
                Btn_Busqueda.Enabled = true;
                Txt_Descripcion_Busqueda.Visible = true;
                Cmb_Giro_Busqueda.Visible = false;
                if (Cmb_Busqueda_Tipo.SelectedIndex == 3)
                {
                    Txt_Descripcion_Busqueda.Visible = false;
                    Cmb_Giro_Busqueda.Visible = true;
                }
            }
        }

        #endregion

        #region "Acciones"

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Alta
        ///DESCRIPCIÓN  : Ingresa un registro en la base de datos
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 22/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private bool Alta()
        {
            try
            {

                Cls_Cat_Clientes_Negocio Nuevo_Cliente = new Cls_Cat_Clientes_Negocio();
                Nuevo_Cliente.P_Rfc = Txt_Rfc.Text;
                Nuevo_Cliente.P_Giro_Id = Cmb_Giros.SelectedValue.ToString();
                Nuevo_Cliente.P_Curp = Txt_Curp.Text;
                Nuevo_Cliente.P_Nombre_Corto = Txt_Nombre.Text;
                Nuevo_Cliente.P_Razon_Social = Txt_Razon_Social.Text;
                Nuevo_Cliente.P_Pais = Txt_Pais.Text;
                Nuevo_Cliente.P_Estado = Txt_Estado.Text;
                Nuevo_Cliente.P_Localidad = Txt_Localidad.Text;
                Nuevo_Cliente.P_Colonia = Txt_Colonia.Text;
                Nuevo_Cliente.P_Ciudad = Txt_Ciudad.Text;
                Nuevo_Cliente.P_Cp = Txt_Cp.Text;
                Nuevo_Cliente.P_Calle = Txt_Calle.Text;
                Nuevo_Cliente.P_Numero_Exterior = Txt_Num_Exterior.Text;
                Nuevo_Cliente.P_Numero_Interior = Txt_Num_Interior.Text;
                Nuevo_Cliente.P_Fax = Txt_Fax.Text;
                Nuevo_Cliente.P_Nextel = Txt_Nextel.Text;
                Nuevo_Cliente.P_Telefono_1 = Txt_Telefono1.Text;
                Nuevo_Cliente.P_Telefono_2 = Txt_Telefono2.Text;
                Nuevo_Cliente.P_Extension = Txt_Extension.Text;
                Nuevo_Cliente.P_Email = Txt_Email.Text;
                Nuevo_Cliente.P_Sitio_Web = Txt_Sitio_Web.Text;
                Nuevo_Cliente.P_Dias_Credito = Obtine_Valor_Numerico_TextBox(Txt_Dias_Credito.Text);
                Nuevo_Cliente.P_Limite_Credito = Obtine_Valor_Numerico_TextBox(Txt_Limite_Credito.Text);
                Nuevo_Cliente.P_Descuento = Obtine_Valor_Numerico_TextBox(Txt_Descuento.Text);
                Nuevo_Cliente.P_Estatus = Cmb_Estatus.SelectedItem.ToString();
                Nuevo_Cliente.Alta_Cliente();
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Alta Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Modificar
        ///DESCRIPCIÓN  : Modifica el registro seleccionado
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 22/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private bool Modificar()
        {
            try
            {
                Cls_Cat_Clientes_Negocio Modifica_Cliente = new Cls_Cat_Clientes_Negocio();
                Modifica_Cliente.P_Cliente_Id = Txt_Cliente_ID.Text;
                Modifica_Cliente.P_Rfc = Txt_Rfc.Text;
                Modifica_Cliente.P_Giro_Id = Cmb_Giros.SelectedValue.ToString();
                Modifica_Cliente.P_Curp = Txt_Curp.Text;
                Modifica_Cliente.P_Nombre_Corto = Txt_Nombre.Text;
                Modifica_Cliente.P_Razon_Social = Txt_Razon_Social.Text;
                Modifica_Cliente.P_Pais = Txt_Pais.Text;
                Modifica_Cliente.P_Estado = Txt_Estado.Text;
                Modifica_Cliente.P_Localidad = Txt_Localidad.Text;
                Modifica_Cliente.P_Colonia = Txt_Colonia.Text;
                Modifica_Cliente.P_Ciudad = Txt_Ciudad.Text;
                Modifica_Cliente.P_Cp = Txt_Cp.Text;
                Modifica_Cliente.P_Calle = Txt_Calle.Text;
                Modifica_Cliente.P_Numero_Exterior = Txt_Num_Exterior.Text;
                Modifica_Cliente.P_Numero_Interior = Txt_Num_Interior.Text;
                Modifica_Cliente.P_Fax = Txt_Fax.Text;
                Modifica_Cliente.P_Nextel = Txt_Nextel.Text;
                Modifica_Cliente.P_Telefono_1 = Txt_Telefono1.Text;
                Modifica_Cliente.P_Telefono_2 = Txt_Telefono2.Text;
                Modifica_Cliente.P_Extension = Txt_Extension.Text;
                Modifica_Cliente.P_Email = Txt_Email.Text;
                Modifica_Cliente.P_Sitio_Web = Txt_Sitio_Web.Text;
                Modifica_Cliente.P_Dias_Credito = Obtine_Valor_Numerico_TextBox(Txt_Dias_Credito.Text);
                Modifica_Cliente.P_Limite_Credito = Obtine_Valor_Numerico_TextBox(Txt_Limite_Credito.Text);
                Modifica_Cliente.P_Descuento = Obtine_Valor_Numerico_TextBox(Txt_Descuento.Text);
                Modifica_Cliente.P_Estatus = Cmb_Estatus.SelectedItem.ToString();
                Modifica_Cliente.Modificar_Cliente();
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Modificar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Eliminar
        ///DESCRIPCIÓN  : Coloca un el estatus del cliente en Inactivo.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 25/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private bool Eliminar()
        {
            try
            {
                Cls_Cat_Clientes_Negocio Elimina_Cliente = new Cls_Cat_Clientes_Negocio();
                Elimina_Cliente.P_Cliente_Id = Txt_Cliente_ID.Text;
                Elimina_Cliente.P_Estatus = "ELIMINADO";
                Elimina_Cliente.Modificar_Cliente();
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar
        ///DESCRIPCIÓN  : Carga todos los clientes en el grid.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 25/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Consultar()
        {
            try
            {
                Cls_Cat_Clientes_Negocio Consulta_Cliente = new Cls_Cat_Clientes_Negocio();
                Cls_Metodos_Generales.Rellena_GridView(Consulta_Cliente.Consultar_Clientes(), Grid_Clientes, new String[] {Cat_Adm_Clientes.Campo_Nombre_Corto, Cat_Adm_Clientes.Campo_Razon_Social, Cat_Adm_Clientes.Campo_Calle, Cat_Adm_Clientes.Campo_Colonia, Cat_Adm_Clientes.Campo_Ciudad, Cat_Adm_Clientes.Campo_Estado });
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Consultar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar
        ///DESCRIPCIÓN  : Carga el cliente buscado.
        ///PARAMENTROS  :   1. Campo. Parametro de busqueda del cliente, hace referencia
        ///                           al campo de la tabla.
        ///                 2. Valor. Valor del parametro de busqueda.
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Consultar(String Campo, String Valor)
        {
            try
            {
                Cls_Cat_Clientes_Negocio Consulta_Cliente = new Cls_Cat_Clientes_Negocio();
                switch (Campo)
                {
                    case Cat_Adm_Clientes.Campo_Nombre_Corto:
                        Consulta_Cliente.P_Nombre_Corto = Valor;
                        break;
                    case Cat_Adm_Clientes.Campo_Razon_Social:
                        Consulta_Cliente.P_Razon_Social = Valor;
                        break;
                    case Cat_Adm_Clientes.Campo_Giro_Id:
                        Consulta_Cliente.P_Giro_Id = Valor;
                        break;
                    case Cat_Adm_Clientes.Campo_Estado:
                        Consulta_Cliente.P_Estado = Valor;
                        break;
                    case Cat_Adm_Clientes.Campo_Ciudad:
                        Consulta_Cliente.P_Ciudad = Valor;
                        break;
                }
                Cls_Metodos_Generales.Rellena_GridView(Consulta_Cliente.Consultar_Clientes(), Grid_Clientes, new String[] { Cat_Adm_Clientes.Campo_Nombre_Corto, Cat_Adm_Clientes.Campo_Razon_Social, Cat_Adm_Clientes.Campo_Calle, Cat_Adm_Clientes.Campo_Colonia, Cat_Adm_Clientes.Campo_Ciudad, Cat_Adm_Clientes.Campo_Estado });
                if (Grid_Clientes.RowCount == 0)
                {
                    MessageBox.Show(this, "No se encontró ningún cliente con esos datos.", "Búsqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Búsqueda Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Funciones"

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtine_Valor_Entero_TextBox
        ///DESCRIPCIÓN  : Obtiene el valor de un textbox cuyo contenido debe ser numerico,
        ///               si esta vacio, regresa "0".
        ///PARAMENTROS  :
        ///                 1. Cadena. Contenido de la caja de texto.
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 22/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private String Obtine_Valor_Numerico_TextBox(String Cadena)
        {
            String Resultado = "0";

            if (!String.IsNullOrWhiteSpace(Cadena))
            {
                Resultado = Cadena;
            }

            return Resultado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Rellena_Combo_Busqueda
        ///DESCRIPCIÓN  : Rellena el combo box de las busquedas.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
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
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Clientes.Campo_Nombre_Corto, "NOMBRE" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Clientes.Campo_Razon_Social, "RAZON SOCIAL" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Clientes.Campo_Giro_Id, "GIRO" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Clientes.Campo_Estado, "ESTADO" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Clientes.Campo_Ciudad, "CIUDAD" });
            Cmb_Busqueda_Tipo.DataSource = Dt_Campos;
            Cmb_Busqueda_Tipo.DisplayMember = "Descripcion";
            Cmb_Busqueda_Tipo.ValueMember = "Valor";
        } 

        #endregion

        #region "Validaciones"

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
        ///NOMBRE DE LA FUNCIÓN: Txt_Alfanumerico_Sin_Convertir_A_Mayusculas_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres Alfanuméricos, pero no convierte a mayusculas.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Alfanumerico_Extendido_Sin_Convertir_A_Mayusculas_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Alfanumerico_Extendido_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres Alfanuméricos y algunos caracteres 
        ///               especiales.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Alfanumerico_Extendido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Numerico_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres numéricos.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Numerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Numerico_Nextel_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres numéricos y el carácter '*'.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Numerico_Nextel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico_Nextel);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Nextel_Validating
        ///DESCRIPCIÓN  : Valida que el campo solo caracteres numéricos.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Nextel_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Nextel(e, (TextBox)sender, false);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Email_Validating
        ///DESCRIPCIÓN  : Valida que el email este escrito correctamente.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Email_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Email(e, (TextBox)sender, true);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Sitio_Web_Validating
        ///DESCRIPCIÓN  : Valida que la Url del sitio web este escrita correctamente.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Sitio_Web_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Url(e, (TextBox)sender, false);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cmb_Requerido_Validating
        ///DESCRIPCIÓN  : Valida que el combo box sea seleccionado un elemento
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 01/Mar/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Cmb_Requerido_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Combo_Requerido(e, (ComboBox)sender, true);
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

        #endregion

    }
}