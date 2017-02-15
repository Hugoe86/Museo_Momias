using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Validador;
using Erp.Metodos_Generales;
using Erp_Cat_Proveedores.Negocio;
using ERP_BASE.Properties;
using Erp.Constantes;
using Erp_Cat_Giros_Empresariales.Negocio;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Cat_Adm_Proveedores : Form
    {
       
        #region "Variables Globales"

        Validador_Generico Validador;

        #endregion

        public Frm_Cat_Adm_Proveedores()
        {
            InitializeComponent();
            Cls_Metodos_Generales.Limpia_Controles(this);
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Proveedores);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Contacto, false);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Credito, false);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Dats_Generales, false);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Ubicacion, false);
            Cls_Cat_Giros_Empresariales_Negocio Giros_Negocios = new Cls_Cat_Giros_Empresariales_Negocio();
            Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Giros, Giros_Negocios.Consultar_Giro_Empresariales(), Cat_Adm_Giros_Empresariales.Campo_Nombre, Cat_Adm_Giros_Empresariales.Campo_Giro_Id);
            Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Giro_Busqueda, Giros_Negocios.Consultar_Giro_Empresariales(), Cat_Adm_Giros_Empresariales.Campo_Nombre, Cat_Adm_Giros_Empresariales.Campo_Giro_Id);
            Rellena_Combo_Busqueda();
            Validador = new Validador_Generico(Error_Provider);
            Error_Provider.Clear();
            Consultar();
        }

        private void Frm_Cat_Adm_Proveedores_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Proveedores", this);
            Error_Provider.Clear();
        }

        
        #region "Eventos"

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
        ///DESCRIPCIÓN  : Cierra la ventana.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Salir.Text == "Cancelar")
            {
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Contacto, false);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Credito, false);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Dats_Generales, false);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Ubicacion, false);
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
                Grid_Proveedores.Enabled = true;
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
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text == "Nuevo")
            {
                Fra_Buscar.Visible = false;
                Fra_Buscar.Enabled = false;
                Fra_Contacto.Visible = true;
                Fra_Credito.Visible = true;
                Fra_Dats_Generales.Visible = true;
                Fra_Ubicacion.Visible = true;
                Cls_Metodos_Generales.Limpia_Controles(this);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Contacto, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Credito, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Dats_Generales, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Ubicacion, true);
                Txt_Proveedor_ID.Text = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores, Cat_Adm_Proveedores.Campo_Proveedor_Id, null, 5);
                Grid_Proveedores.Enabled = false;
                Txt_Proveedor_ID.Enabled = false;
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
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Contacto, false);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Credito, false);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Dats_Generales, false);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Ubicacion, false);
                        Btn_Nuevo.Image = Resources.icono_nuevo;
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Salir.Image = Resources.icono_eliminar;
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Grid_Proveedores.Enabled = true;
                        Consultar();
                        MessageBox.Show(this, "Se dio de alta correctamente al proveedor.", "Alta Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Ocurrió un erro al dar de alta al proveedor.", "Error - Alta Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Alta Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Modificar_Click
        ///DESCRIPCIÓN  : Modifica un registro.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text == "Modificar")
            {
                if (Grid_Proveedores.CurrentRow != null)
                {
                    if (Txt_Proveedor_ID.Text.Length > 1)
                    {
                        Fra_Buscar.Visible = false;
                        Fra_Buscar.Enabled = false;
                        Fra_Contacto.Visible = true;
                        Fra_Credito.Visible = true;
                        Fra_Dats_Generales.Visible = true;
                        Fra_Ubicacion.Visible = true;
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Contacto, true);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Credito, true);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Dats_Generales, true);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Ubicacion, true);
                        Grid_Proveedores.Enabled = false;
                        Txt_Proveedor_ID.Enabled = false;
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
                        MessageBox.Show(this, "Favor de seleccionar un registro de la lista.", "Modificar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Favor de seleccionar un registro de la lista.", "Modificar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (Btn_Modificar.Text == "Actualizar")
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (Modificar())
                    {
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Contacto, false);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Credito, false);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Dats_Generales, false);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Ubicacion, false);
                        Btn_Modificar.Image = Resources.icono_modificar;
                        Btn_Modificar.Text = "Modificar";
                        Btn_Eliminar.Image = Resources.icono_eliminar;
                        Btn_Eliminar.Text = "Eliminar";
                        Btn_Salir.Image = Resources.icono_salir_2;
                        Btn_Salir.Text = "Salir";
                        Btn_Nuevo.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Grid_Proveedores.Enabled = true;
                        Consultar();
                        MessageBox.Show(this, "Se modifico correctamente al proveedor.", "Modificar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Ocurrió un erro al dar de alta al proveedor.", "Modificar - Alta Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Faltan datos por capturar o están erróneos. Favor de verificar", "Modificar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Eliminar_Click
        ///DESCRIPCIÓN  : Elimina un registro.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 23/Feb/2013
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (Btn_Eliminar.Text == "Eliminar")
            {
                if (Grid_Proveedores.CurrentRow != null)
                {
                    if (MessageBox.Show(this, "¿Esta seguro que desea eliminar el registro del proveedor " + Grid_Proveedores.Rows[Grid_Proveedores.CurrentRow.Index].Cells[Cat_Adm_Proveedores.Campo_Nombre_Corto].Value.ToString() + "?.", "Modificar Proveedor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Eliminar())
                        {
                            Error_Provider.Clear();
                            Consultar();
                            Cls_Metodos_Generales.Limpia_Controles(this);
                            MessageBox.Show(this, "Se elimino correctamente al proveedor.", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Ocurrió un erro al eliminar al proveedor.", "Error - Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Favor de seleccionar un registro de la lista.", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Buscar_Click
        ///DESCRIPCIÓN  : Muestra el panel de busqueda.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Fra_Buscar.Enabled = true;
            Fra_Contacto.Visible = false;
            Fra_Credito.Visible = false;
            Fra_Dats_Generales.Visible = false;
            Fra_Ubicacion.Visible = false;
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
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = false;
            Fra_Buscar.Enabled = false;
            Fra_Contacto.Visible = true;
            Fra_Credito.Visible = true;
            Fra_Dats_Generales.Visible = true;
            Fra_Ubicacion.Visible = true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Btn_Busqueda_Click
        ///DESCRIPCIÓN  : Realiza la busqueda del cliente.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex != 3 && Txt_Descripcion_Busqueda.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Favor de rellenar el campo descripción.", "Búsqueda Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Cmb_Busqueda_Tipo.SelectedIndex == 3 && Cmb_Giro_Busqueda.SelectedIndex == 0)
            {
                MessageBox.Show(this, "Favor de seleccionar el giro del proveedor.", "Búsqueda Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        ///NOMBRE DE LA FUNCIÓN: Grid_Proveedores_CellContentClick
        ///DESCRIPCIÓN  : Carga los datos a los campos del grid seleccionado
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************

        private void Grid_Proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Grid_Proveedores.Rows.Count > 0)
            {
                int Fila_Seleccionada = Grid_Proveedores.CurrentRow.Index;
                Txt_Proveedor_ID.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Proveedor_Id].Value.ToString();
                Txt_Rfc.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_RFC].Value.ToString();
                Cmb_Giros.SelectedValue = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Giro_Id].Value.ToString();

                Txt_Nombre_Corto.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Nombre_Corto].Value.ToString();
                Txt_Razon_Social.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Razon_Social].Value.ToString();
                Txt_Pais.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Pais].Value.ToString();
                Txt_Estado.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Estado].Value.ToString();
                Txt_Localidad.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Localidad].Value.ToString();
                Txt_Colonia.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Colonia].Value.ToString();
                Txt_Ciudad.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Ciudad].Value.ToString();
                Txt_Cp.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_CP].Value.ToString();
                Txt_Calle.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Calle].Value.ToString();
                Txt_Num_Exterior.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Numero_Exterior].Value.ToString();
                Txt_Num_Interior.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Numero_Interior].Value.ToString();
                Txt_Fax.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Fax].Value.ToString();
                Txt_Nextel.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Nextel].Value.ToString();
                Txt_Telefono.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Telefono].Value.ToString();

                Txt_Extension.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Extension].Value.ToString();
                Txt_Email.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Email].Value.ToString();
                Txt_Sitio_Web.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Sitio_Web].Value.ToString();
                Txt_Dias_Credito.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Dias_Credito].Value.ToString();
                Txt_Limite_Credito.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Limite_Credito].Value.ToString();
                Txt_Descuento.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Descuento].Value.ToString();
                Cmb_Estatus.Text = Grid_Proveedores.Rows[Fila_Seleccionada].Cells[Cat_Adm_Proveedores.Campo_Estatus].Value.ToString();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Cmb_Busqueda_Tipo_SelectedIndexChanged
        ///DESCRIPCIÓN  : Muestra u oculta el campo de descripción o el combo de giros.
        ///PARAMENTROS  :
        ///CREO         : Luis Alberto Salas Garcia
        ///FECHA_CREO   : 28/Feb/2013
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
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
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private bool Alta()
        {
            try
            {

                Cls_Cat_Proveedores_Negocio Nuevo_Proveedor = new Cls_Cat_Proveedores_Negocio();
                Nuevo_Proveedor.P_Rfc = Txt_Rfc.Text;
                Nuevo_Proveedor.P_Giro_Id = Cmb_Giros.SelectedValue.ToString();

                Nuevo_Proveedor.P_Nombre_Corto = Txt_Nombre_Corto.Text;
                Nuevo_Proveedor.P_Razon_Social = Txt_Razon_Social.Text;
                Nuevo_Proveedor.P_Pais = Txt_Pais.Text;
                Nuevo_Proveedor.P_Estado = Txt_Estado.Text;
                Nuevo_Proveedor.P_Localidad = Txt_Localidad.Text;
                Nuevo_Proveedor.P_Colonia = Txt_Colonia.Text;
                Nuevo_Proveedor.P_Ciudad = Txt_Ciudad.Text;
                Nuevo_Proveedor.P_Codigo_Postal = Txt_Cp.Text;
                Nuevo_Proveedor.P_Calle = Txt_Calle.Text;
                Nuevo_Proveedor.P_Numero_Exterior = Txt_Num_Exterior.Text;
                Nuevo_Proveedor.P_Numero_Interior = Txt_Num_Interior.Text;
                Nuevo_Proveedor.P_Fax = Txt_Fax.Text;
                Nuevo_Proveedor.P_Nextel = Txt_Nextel.Text;
                Nuevo_Proveedor.P_Telefono = Txt_Telefono.Text;
               
                Nuevo_Proveedor.P_Extension = Txt_Extension.Text;
                Nuevo_Proveedor.P_Email = Txt_Email.Text;
                Nuevo_Proveedor.P_Sitio_Web = Txt_Sitio_Web.Text;
                Nuevo_Proveedor.P_Dias_Credito = Obtine_Valor_Numerico_TextBox(Txt_Dias_Credito.Text);
                Nuevo_Proveedor.P_Limite_Credito = Obtine_Valor_Numerico_TextBox(Txt_Limite_Credito.Text);
                Nuevo_Proveedor.P_Descuento = Obtine_Valor_Numerico_TextBox(Txt_Descuento.Text);
                Nuevo_Proveedor.P_Estatus = Cmb_Estatus.SelectedItem.ToString();
                Nuevo_Proveedor.Alta_Proveedores();
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Alta Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private bool Modificar()
        {
            try
            {
                Cls_Cat_Proveedores_Negocio Modifica_Proveedor = new Cls_Cat_Proveedores_Negocio();
                Modifica_Proveedor.P_Proveedor_Id = Txt_Proveedor_ID.Text;
                Modifica_Proveedor.P_Rfc = Txt_Rfc.Text;
                Modifica_Proveedor.P_Giro_Id = Cmb_Giros.SelectedValue.ToString();
                ;
                Modifica_Proveedor.P_Nombre_Corto = Txt_Nombre_Corto.Text;
                Modifica_Proveedor.P_Razon_Social = Txt_Razon_Social.Text;
                Modifica_Proveedor.P_Pais = Txt_Pais.Text;
                Modifica_Proveedor.P_Estado = Txt_Estado.Text;
                Modifica_Proveedor.P_Localidad = Txt_Localidad.Text;
                Modifica_Proveedor.P_Colonia = Txt_Colonia.Text;
                Modifica_Proveedor.P_Ciudad = Txt_Ciudad.Text;
                Modifica_Proveedor.P_Codigo_Postal = Txt_Cp.Text;
                Modifica_Proveedor.P_Calle = Txt_Calle.Text;
                Modifica_Proveedor.P_Numero_Exterior = Txt_Num_Exterior.Text;
                Modifica_Proveedor.P_Numero_Interior = Txt_Num_Interior.Text;
                Modifica_Proveedor.P_Fax = Txt_Fax.Text;
                Modifica_Proveedor.P_Nextel = Txt_Nextel.Text;
                Modifica_Proveedor.P_Telefono = Txt_Telefono.Text;
                
                Modifica_Proveedor.P_Extension = Txt_Extension.Text;
                Modifica_Proveedor.P_Email = Txt_Email.Text;
                Modifica_Proveedor.P_Sitio_Web = Txt_Sitio_Web.Text;
                Modifica_Proveedor.P_Dias_Credito = Obtine_Valor_Numerico_TextBox(Txt_Dias_Credito.Text);
                Modifica_Proveedor.P_Limite_Credito = Obtine_Valor_Numerico_TextBox(Txt_Limite_Credito.Text);
                Modifica_Proveedor.P_Descuento = Obtine_Valor_Numerico_TextBox(Txt_Descuento.Text);
                Modifica_Proveedor.P_Estatus = Cmb_Estatus.SelectedItem.ToString();
                Modifica_Proveedor.Modificar_Proveedor();
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Modificar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private bool Eliminar()
        {
            try
            {
                Cls_Cat_Proveedores_Negocio Elimina_Cliente = new Cls_Cat_Proveedores_Negocio();
                Elimina_Cliente.P_Proveedor_Id = Txt_Proveedor_ID.Text;
               // Elimina_Cliente.P_Estatus = "ELIMINADO";
                Elimina_Cliente.Eliminar_Proveedor();
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Consultar()
        {
            try
            {
                Cls_Cat_Proveedores_Negocio Consulta_Cliente = new Cls_Cat_Proveedores_Negocio();
                Consulta_Cliente.P_Estatus = "!='ELIMINADO'";
                Cls_Metodos_Generales.Rellena_GridView(Consulta_Cliente.Consultar_Proveedores(), Grid_Proveedores, new String[] { Cat_Adm_Proveedores.Campo_Nombre_Corto, Cat_Adm_Proveedores.Campo_Razon_Social, Cat_Adm_Proveedores.Campo_Calle, Cat_Adm_Proveedores.Campo_Colonia, Cat_Adm_Proveedores.Campo_Ciudad, Cat_Adm_Proveedores.Campo_Estado });
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Consultar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        ///MODIFICO     : Alejandro Leyva Alvarado
        ///FECHA_MODIFICO: 13/Mar/2013
        ///CAUSA_MODIFICACIÓN:Ajustar a las necesidades del formulario
        ///*******************************************************************************
        private void Consultar(String Campo, String Valor)
        {
            try
            {
                Cls_Cat_Proveedores_Negocio Consulta_Proveedor = new Cls_Cat_Proveedores_Negocio();
                switch (Campo)
                {
                    case Cat_Adm_Proveedores.Campo_Nombre_Corto:
                        Consulta_Proveedor.P_Nombre_Corto = Valor;
                        break;
                    case Cat_Adm_Proveedores.Campo_Razon_Social:
                        Consulta_Proveedor.P_Razon_Social = Valor;
                        break;
                    case Cat_Adm_Proveedores.Campo_Giro_Id:
                        Consulta_Proveedor.P_Giro_Id = Valor;
                        break;
                    case Cat_Adm_Proveedores.Campo_Estado:
                        Consulta_Proveedor.P_Estado = Valor;
                        break;
                    case Cat_Adm_Proveedores.Campo_Ciudad:
                        Consulta_Proveedor.P_Ciudad = Valor;
                        break;
                }
                Cls_Metodos_Generales.Rellena_GridView(Consulta_Proveedor.Consultar_Proveedores(), Grid_Proveedores, new String[] { Cat_Adm_Proveedores.Campo_Nombre_Corto, Cat_Adm_Proveedores.Campo_Razon_Social, Cat_Adm_Proveedores.Campo_Calle, Cat_Adm_Proveedores.Campo_Colonia, Cat_Adm_Proveedores.Campo_Ciudad, Cat_Adm_Proveedores.Campo_Estado });
                if (Grid_Proveedores.RowCount == 0)
                {
                    MessageBox.Show(this, "No se encontró ningún poveedor con esos datos.", "Búsqueda Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(null, E.ToString(), "Error - Búsqueda Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Proveedores.Campo_Nombre_Corto, "NOMBRE" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Proveedores.Campo_Razon_Social, "RAZON SOCIAL" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Proveedores.Campo_Giro_Id, "GIRO" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Proveedores.Campo_Estado, "ESTADO" });
            Dt_Campos.Rows.Add(new String[] { Cat_Adm_Proveedores.Campo_Ciudad, "CIUDAD" });
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
