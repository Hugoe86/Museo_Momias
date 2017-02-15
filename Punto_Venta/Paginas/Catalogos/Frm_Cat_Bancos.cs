using System;
using System.Drawing;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using ERP_BASE.App_Code.Negocio.Catalogos;
using System.IO;
using Erp_Apl_Parametros.Negocio;
using Erp.Constantes;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Bancos : Form
    {
        private string Ruta_Logo;
        bool Nueva_Imagen = false; // se asigna valor si el usuario carga una nueva imagen, si no, no se sustituye la imagen en el servidor
        private const string Directorio_Bancos = @"Imagenes\Bancos\";
        private string Nombre_Archivo = "";

        public Frm_Cat_Bancos()
        {
            InitializeComponent();
            Grid_Bancos.AutoGenerateColumns = false;
        }

        #region Métodos Generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Bancos_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Bancos_Load(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Spl_Contenedor.Panel1Collapsed = false;
            Spl_Contenedor.Panel2Collapsed = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            Spl_Contenedor.Panel1Collapsed = false;
            Spl_Contenedor.Panel2Collapsed = true;
            Cargar_Bancos();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Bancos
        ///DESCRIPCIÓN          : Consulta todos los bancos de la base de datos y los coloca en el DataGridView
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cargar_Bancos()
        {
            Cls_Cat_Bancos_Negocio P_Bancos = new Cls_Cat_Bancos_Negocio(); // Variable utilizada para consultar todos los bancos existentes en la base de datos.

            try
            {
                Grid_Bancos.DataSource = P_Bancos.Consultar_Bancos();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
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
                        Grid_Bancos.Enabled = false;
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
                        Grid_Bancos.Enabled = false;
                        Fra_Datos_Generales.Visible = true;
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
                        Grid_Bancos.Enabled = true;
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
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Validar_Alta()
        {
            String Campos_Faltan = "Debe de: \n"; // Variable concatena los diferentes mensajes para los campos obligatorios que no tienen información
            Boolean Resultado = true; // Variable que indica si todos los campos obligatorios contienen información
            Erp_Validaciones.Clear(); // Limpia los mensajes del control ErrorProvider

            // Verifica que el ComboBox "Cmb_Moneda" tenga seleccionada la opcion de "PESO" o "DOLAR"
            if (Cmb_Moneda.Text == String.Empty)
            {
                Campos_Faltan += "Seleccionar un tipo de moneda";
                Erp_Validaciones.SetError(Cmb_Moneda, "Seleccionar un tipo de moneda");
                Resultado &= false;
            }

            // Verfica que el TextBox "Txt_Nombre" tenga un valor para el nombre del banco
            if (Txt_Nombre.Text == String.Empty)
            {
                Campos_Faltan += "Indicar un nombre para el banco";
                Erp_Validaciones.SetError(Txt_Nombre, "Debe de indicar un nombre para el banco");
                Resultado &= false;
            }

            // Verifica que el TextBox "Txt_Cuenta" tenga un valor para el número de cuenta
            if (Txt_Cuenta.Text == String.Empty)
            {
                Campos_Faltan += "Indicar un número de cuenta";
                Erp_Validaciones.SetError(Txt_Cuenta, "Debe de seleccionar un estatus");
                Resultado &= false;
            }

            // Verifica que el TextBox "Txt_Comision" tenga un valor para la comisión a cobrar
            if (Txt_Comision.Text == String.Empty)
            {
                Campos_Faltan += "Indicar la comisión";
                Erp_Validaciones.SetError(Txt_Cuenta, "Debe de indicar la comisión");
                Resultado &= false;
            }

            // Verifica que se ha seleccionado una imagen para el banco
            if (String.IsNullOrEmpty(Ruta_Logo))
            {
                Campos_Faltan += "Seleccionar una imagen para el banco";
                Erp_Validaciones.SetError(Txt_Cuenta, "Debe seleccionar una imagen para el banco");
                Resultado &= false;
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Banco
        ///DESCRIPCIÓN          : Método que valida los campos obligatorios.
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Alta_Banco()
        {
            Cls_Cat_Bancos_Negocio P_Banco = new Cls_Cat_Bancos_Negocio(); // Variable utilizada para consultar todos los bancos existentes en la base de datos.
            Boolean Alta = false; // Variable que indica si el registro en la base de datos se efectúa satisfactoriamente
            decimal Comision_Banco;

            try
            {
                if (Validar_Alta())
                {
                    P_Banco.P_Moneda = Cmb_Moneda.Text;
                    P_Banco.P_Nombre = Txt_Nombre.Text;
                    P_Banco.P_Cuenta = Txt_Cuenta.Text;
                    // asignar el valor de la ruta si hay un nombre de archivo
                    if (!string.IsNullOrEmpty(Nombre_Archivo))
                    {
                        P_Banco.P_Ruta_Logo = Ruta_Logo + Nombre_Archivo;
                    }
                    else
                    {
                        P_Banco.P_Ruta_Logo = "";
                    }
                    decimal.TryParse(Txt_Comision.Text.Trim(), out Comision_Banco);
                    P_Banco.P_Comision = Comision_Banco;
                    P_Banco.Alta_Bancos();
                    // guardar la imagen con el id como nombre de imagen
                    Guardar_Imagen(P_Banco.P_Ruta_Logo);
                    MessageBox.Show("El Banco ha sido registrado", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Banco
        ///DESCRIPCIÓN          : Realiza la modificación de un banco en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Modificar_Banco()
        {
            Cls_Cat_Bancos_Negocio P_Banco = new Cls_Cat_Bancos_Negocio(); // Variable utilizada para consultar todos los bancos existentes en la base de datos.
            decimal Comision_Bancaria;
            try
            {
                if (Validar_Alta())
                {
                    P_Banco.P_Banco_ID = Txt_ID_Banco.Text.Trim();
                    P_Banco.P_Moneda = Cmb_Moneda.Text;
                    P_Banco.P_Nombre = Txt_Nombre.Text;
                    P_Banco.P_Cuenta = Txt_Cuenta.Text;
                    // asignar el valor de la ruta si hay un nombre de archivo
                    if (!string.IsNullOrEmpty(Nombre_Archivo))
                    {
                        P_Banco.P_Ruta_Logo = Path.GetDirectoryName(Ruta_Logo) + @"\banco_" + Txt_ID_Banco.Text.Trim() + Path.GetExtension(Nombre_Archivo);
                    }
                    decimal.TryParse(Txt_Comision.Text.Trim(), out Comision_Bancaria);
                    P_Banco.P_Comision = Comision_Bancaria;
                    // llamar método para guardar archivo de imagen
                    Guardar_Imagen(P_Banco.P_Ruta_Logo);
                    // llamar método en la capa de negocio para actualizar registro en base de datos
                    P_Banco.Modificar_Banco();
                    MessageBox.Show("El Banco '" + Txt_ID_Banco.Text + "' ha sido modificado", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return false;
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Guardar_Imagen
        ///DESCRIPCIÓN: Valida que existe el directorio y guarda el archivo en la ruta especificada
        ///PARÁMETROS:
        /// 		1. Ruta: cadana de caracteres con la ruta en la que se va a guardar el archivo
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 21-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Guardar_Imagen(string Ruta)
        {
            try
            {
                // validar que se haya proporcionado una ruta
                if (!string.IsNullOrEmpty(Ruta) && Nueva_Imagen == true)
                {
                    // validar que el control contenga imagen
                    if (Pic_Logo.Image != null)
                    {
                        Nueva_Imagen = false;
                        // si el directorio no existe, crearlo
                        if (!Directory.Exists(Path.GetDirectoryName(Ruta)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(Ruta));
                        }
                        // guardar imagen
                        Pic_Logo.Image.Save(Ruta);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Guardar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Cargar_Imagen
        ///DESCRIPCIÓN: Valida que existe el archivo en la ruta especificada y cargar en el control Pic_Logo
        ///PARÁMETROS:
        /// 		1. Ruta: cadana de caracteres con la ruta al archivo con el logotipo del banco
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 21-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Cargar_Imagen(string Ruta)
        {
            FileStream Archivo_Imagen = null;
            try
            {
                // validar que se haya proporcionado una ruta
                if (!string.IsNullOrEmpty(Ruta))
                {
                    // validar que exista el archivo
                    if (File.Exists(Ruta))
                    {
                        // leer archivo de imagen como filestream y cargar al control Pic_Logo para que no bloquear el archivo
                        Archivo_Imagen = new FileStream(Ruta, FileMode.Open, FileAccess.Read);
                        Pic_Logo.Image = Image.FromStream(Archivo_Imagen);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                // validar que Archivo_Imagen sea diferente de nulo
                if (Archivo_Imagen != null)
                {
                    Archivo_Imagen.Close();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Banco
        ///DESCRIPCIÓN          : Realiza la consulta de los bancos en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Consultar_Banco()
        {
            Cls_Cat_Bancos_Negocio P_Banco = new Cls_Cat_Bancos_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id de Banco":
                        P_Banco.P_Banco_ID = Txt_Descripcion_Busqueda.Text;
                        Grid_Bancos.DataSource = P_Banco.Consultar_Bancos();
                        break;

                    case "Moneda":
                        P_Banco.P_Moneda = Txt_Descripcion_Busqueda.Text;
                        Grid_Bancos.DataSource = P_Banco.Consultar_Bancos();
                        break;

                    case "Nombre":
                        P_Banco.P_Nombre = Txt_Descripcion_Busqueda.Text;
                        Grid_Bancos.DataSource = P_Banco.Consultar_Bancos();
                        break;
                    case "Cuenta":
                        P_Banco.P_Cuenta = Txt_Descripcion_Busqueda.Text;
                        Grid_Bancos.DataSource = P_Banco.Consultar_Bancos();
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
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de bancos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Banco();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            Spl_Contenedor.Panel1Collapsed = false;
            Spl_Contenedor.Panel2Collapsed = true;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para registrar un banco en la base de datos
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
                Pic_Logo.Image = null;
                Fra_Datos_Generales.Visible = true;
                Fra_Datos_Generales.Enabled = true;
                Spl_Contenedor.Panel1Collapsed = false;
                Spl_Contenedor.Panel2Collapsed = true;
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
            }
            else
            {
                if (Alta_Banco())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Cargar_Bancos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar un banco
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
                if (Txt_ID_Banco.Text != String.Empty)
                {
                    Fra_Datos_Generales.Visible = true;
                    Fra_Datos_Generales.Enabled = true;
                    Spl_Contenedor.Panel2Collapsed = true;
                    Txt_ID_Banco.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                }
                else
                {
                    MessageBox.Show("Para modificar un banco, debe seleccionar uno de la lista", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Banco())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Cargar_Bancos();
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
            Fra_Buscar.Enabled = true;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
            Spl_Contenedor.Panel1Collapsed = true;
            Spl_Contenedor.Panel2Collapsed = false;
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
            Cls_Cat_Bancos_Negocio P_Banco = new Cls_Cat_Bancos_Negocio();

            try
            {
                if (Txt_ID_Banco.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar el banco '" + Txt_Nombre.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        P_Banco.P_Banco_ID = Txt_ID_Banco.Text;
                        P_Banco.Eliminar_Banco();
                        MessageBox.Show("El banco '" + Txt_ID_Banco.Text + "' ha sido eliminado", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Pic_Logo.Image = null;
                        Cargar_Bancos();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar una banco, debe seleccionar uno de la lista", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exc)
            {
                if (exc.Data.Contains("HelpLink.EvtID"))
                {
                    if (exc.Data["HelpLink.EvtID"].ToString() == "547")
                    {
                        MessageBox.Show("No se puede eliminar el registro debido a que tiene relación con otras tablas", "Bancos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Grid_Bancos.Enabled = true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Logo_Click
        ///DESCRIPCIÓN          : Evento para cargar una imagen para el banco y almacenarla en un directorio
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             : Roberto González Oseguera
        ///FECHA_MODIFICO       : 21-oct-2013
        ///CAUSA_MODIFICACIÓN   : Se agregó parámetro directorio compartido a la ruta y se guarda temporalmente la imagen
        ///*************************************************************************************
        private void Btn_Buscar_Logo_Click(object sender, EventArgs e)
        {
            Ofd_Logo.Filter = "Archivos PNG (*.png)|*.png|Archivos JPG (*.jpg)|*.jpg|Archivos BMP (*.bmp)|*.bmp";
            Stream Imagen_Respaldo;
            MemoryStream Imagen_Guardada = new MemoryStream();
            var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
            Obj_Parametros = Obj_Parametros.Obtener_Parametros();

            if (Ofd_Logo.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Imagen_Respaldo = Ofd_Logo.OpenFile();
                    Bitmap Imagen = new Bitmap(Imagen_Respaldo);

                    Pic_Logo.Image = Imagen;
                    Ruta_Logo = Obj_Parametros.P_Directorio_Compartido + @"\" + Directorio_Bancos;
                    Nombre_Archivo = "nombre_temporal" + Path.GetExtension(Ofd_Logo.FileName);
                    Nueva_Imagen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer la imagen : " + ex.Message);
                }
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

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Bancos_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del registro seleccionado en los campos correspondientes
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 05 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Bancos_SelectionChanged(object sender, EventArgs e)
        {
            // limpiar imagen
            Pic_Logo.Image = null;
            // validar selección de fila y cargar valores
            if (Grid_Bancos.CurrentRow != null)
            {
                Txt_ID_Banco.Text = Grid_Bancos.CurrentRow.Cells["Banco_ID"].Value.ToString();
                Cmb_Moneda.Text = Grid_Bancos.CurrentRow.Cells["Moneda"].Value.ToString();
                Txt_Nombre.Text = Grid_Bancos.CurrentRow.Cells["Nombre"].Value.ToString();
                Txt_Cuenta.Text = Grid_Bancos.CurrentRow.Cells["Cuenta"].Value.ToString();
                Txt_Comision.Text = Grid_Bancos.CurrentRow.Cells["Comision"].Value.ToString();
                Cargar_Imagen(Grid_Bancos.CurrentRow.Cells["Imagen"].Value.ToString());
                Ruta_Logo = Grid_Bancos.CurrentRow.Cells["Imagen"].Value.ToString();
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Txt_Comision_KeyPress
        ///DESCRIPCIÓN: Manejador del evento keypress en Txt_Comision: llama al método para permitir únicamente 
        ///             valores numéricos
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 21-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Txt_Comision_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }
        #endregion
    }
}
