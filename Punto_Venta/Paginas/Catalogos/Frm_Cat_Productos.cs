using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using Erp.Validador;
using ERP_BASE.App_Code.Negocio.Catalogos;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp_Apl_Parametros.Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Erp.Constantes;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Productos : Form
    {
        Validador_Generico Validador = null;
        bool Nueva_Imagen = false; // se asigna valor si el usuario carga una nueva imagen, si no, no se sustituye la imagen en el servidor
        private string Ruta_Imagen;
        private const string Directorio_Productos = @"Imagenes\Productos_Servicios\";
        private string Nombre_Archivo = "";
        private const string Caracteres_Validos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private int Cantidad_Caracteres = Caracteres_Validos.Length;

        #region Métodos Generales
        public Frm_Cat_Productos()
        {
            InitializeComponent();
            Grid_Productos.AutoGenerateColumns = false;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Productos_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Productos_Load(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Productos", this);
            
            //Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Productos);

            Carga_Productos();
            Cargar_Combo_Tipos_Servicios();
            Cargar_Combo_Productos();
            Cargar_Categorias();

            Validador = new Validador_Generico(Erp_Validaciones);
            
            Erp_Validaciones.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Cargar_Categorias()
        {
            try
            {
                Cls_Cat_Categorias_Negocio Categorias = new Cls_Cat_Categorias_Negocio();

                DataTable Res = Categorias.Cargar();
                DataRow Fila = Res.NewRow();

                Fila[0] = string.Empty;
                Fila[1] = "SELECCIONE";

                Res.Rows.InsertAt(Fila, 0);

                Cmb_Categoria.DataSource = Res;
                Cmb_Categoria.DisplayMember = "Nombre";
                Cmb_Categoria.ValueMember = "Catergoria_ID";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Carga_Productos
        ///DESCRIPCIÓN          : Método para consultar todos los productos registrados
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Carga_Productos()
        {
            Cls_Cat_Productos_Negocio Producto_Consultar = new Cls_Cat_Productos_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                Dt_Consulta = Producto_Consultar.Consultar_Producto();
                Grid_Productos.DataSource = Dt_Consulta ;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para manejo de los estados de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
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
                        Grid_Productos.Enabled = false;
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
                        Grid_Productos.Enabled = false;
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
                        Grid_Productos.Enabled = true;
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
        ///FECHA_CREO           : 03 Octubre 2013
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
                Campos_Faltan += "Introducir el nombre del producto.\n";
                Erp_Validaciones.SetError(Lbl_Nombre, "Debe de introducir el nombre del producto");
                Resultado &= false;
            }

            if (Cmb_Tipo_Producto.Text == String.Empty)
            {
                Campos_Faltan += "Debe seleccionar un tipo de producto.\n";
                Erp_Validaciones.SetError(Cmb_Tipo_Producto, "Debe seleccionar un tipo de producto");
                Resultado &= false;
            }
            else
            {
                if (Cmb_Tipo_Producto.Text == "Servicio")
                {
                    if (!(Rdb_SI.Checked || Rdb_NO.Checked))
                    {
                        Campos_Faltan += "Indicar si tiene o no servicio\n";
                        Erp_Validaciones.SetError(Pnl_Respuesta, "Debe indicar si tiene o no servicio");
                        Resultado &= false;
                    }

                    if (Cmb_Tipo_Servicio.SelectedIndex == 0)
                    {
                        Campos_Faltan += "Indicar el tipo de servicio\n";
                        Erp_Validaciones.SetError(Pnl_Respuesta, "Debe indicar el tipo de servicio");
                        Resultado &= false;
                    }
                }

               
            }

            if (Txt_Costo.Text == String.Empty)
            {
                Campos_Faltan += "Introducir el precio del producto.\n";
                Erp_Validaciones.SetError(Txt_Costo, "Debe introducir el costo del producto");
                Resultado &= false;
            }

            if (Cmb_Estatus.Text == String.Empty)
            {
                Campos_Faltan += "Seleccionar el estatus del producto.\n";
                Erp_Validaciones.SetError(Cmb_Estatus, "Debe seleccionar el estatus del producto");
                Resultado &= false;
            }
            if (Txt_Anio.Text == String.Empty)
            {
                Campos_Faltan += "Seleccionar el año del producto.\n";
                Erp_Validaciones.SetError(Txt_Anio, "Debe seleccionar el año del producto");
                Resultado &= false;
            }
            else //  validamos la relacion del producto
            {
                Double Db_Anio = 0;

                Db_Anio = Convert.ToDouble(Txt_Anio.Text);

                if (Db_Anio == 2009) // no requiere relacion
                {
                }
                else if (Db_Anio < 2009)//   no se permite ingresar el producto
                {
                    Campos_Faltan += "El año no puede ser menor a 2009.\n";
                    Erp_Validaciones.SetError(Txt_Anio, "El año no puede ser menor a 2009");
                    Resultado &= false;
                }
                else if (Db_Anio > 2009)//   no se permite ingresar el producto
                {
                    ////  validamos que existe relacion
                    //if (Cmb_Producto_Anterior.SelectedIndex == 0)
                    //{
                    //    Campos_Faltan += "Seleccione la relacion del producto del año anterior.\n";
                    //    Erp_Validaciones.SetError(Cmb_Producto_Anterior, "Seleccione la relacion del producto del año anterior");
                    //    Resultado &= false;
                    //}
                }
            }

            return Resultado;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Producto
        ///DESCRIPCIÓN          : Realiza el registro de un producto en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Alta_Producto()
        {
            Cls_Cat_Productos_Negocio Producto_Nuevo = new Cls_Cat_Productos_Negocio();
            Boolean Alta = false;

            try
            {
                if (Validar_Alta())
                {
                    Producto_Nuevo.P_Nombre = Txt_Nombre.Text;
                    Producto_Nuevo.P_Descripcion = Txt_Descripcion.Text;
                    Producto_Nuevo.P_Tipo = Cmb_Tipo_Producto.Text;
                    Producto_Nuevo.P_Anio = Txt_Anio.Text;

                    if (Cmb_Tipo_Producto.Text == "Servicio")
                    {
                        Producto_Nuevo.P_Tipo_Servicio = Cmb_Tipo_Servicio.Text;                        

                        if (Rdb_SI.Checked)
                            Producto_Nuevo.P_Tipo_Valor = "1";
                        else
                            Producto_Nuevo.P_Tipo_Valor = "0";
                    }
                    else
                    {
                        Producto_Nuevo.P_Tipo_Servicio = "PRODUCTO";      
                        Producto_Nuevo.P_Tipo_Valor = null;
                    }

                    Producto_Nuevo.P_Codigo = Txt_Codigo.Text;
                    Producto_Nuevo.P_Costo = Txt_Costo.Text;
                    Producto_Nuevo.P_Estatus = Cmb_Estatus.Text;
                    // asignar el valor de la ruta si hay un nombre de archivo
                    if (!string.IsNullOrEmpty(Nombre_Archivo))
                    {
                        Producto_Nuevo.P_Ruta_Imagen = Ruta_Imagen + Nombre_Archivo;
                    }
                    else
                    {
                        Producto_Nuevo.P_Ruta_Imagen = "";
                    }
                    Producto_Nuevo.P_Usuario_Creo = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Producto_Nuevo.P_Fecha_Creo = DateTime.Now;

                    //  validacion para el modulo web
                    if (Chk_Web.Checked == true)
                        Producto_Nuevo.P_Aparece_En_Web = "S";
                    else
                        Producto_Nuevo.P_Aparece_En_Web = "N";

                    //  validacion para la relacion del producto
                    if (Cmb_Producto_Anterior.SelectedIndex > 0)
                    {
                        Producto_Nuevo.P_Relacion_Producto_Id = Cmb_Producto_Anterior.SelectedValue.ToString(); 
                    }

                    Producto_Nuevo.Alta_Productos();
                    Guardar_Imagen(Producto_Nuevo.P_Ruta_Imagen);
                    MessageBox.Show("El producto ha sido registrado", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Alta = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Producto
        ///DESCRIPCIÓN          : Realiza la modificación de un producto en la base de datos
        ///PARÁMETROS           :
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private Boolean Modificar_Producto()
        {
            Cls_Cat_Productos_Negocio Producto_Modificar = new Cls_Cat_Productos_Negocio();

            try
            {
                if (Validar_Alta())
                {
                    Producto_Modificar.P_Producto_Id = Txt_ID_Producto.Text;
                    Producto_Modificar.P_Nombre = Txt_Nombre.Text;
                    Producto_Modificar.P_Descripcion = Txt_Descripcion.Text;
                    Producto_Modificar.P_Tipo = Cmb_Tipo_Producto.Text;
                    Producto_Modificar.P_Anio = Txt_Anio.Text;
                    Producto_Modificar.P_Categoria_ID = Cmb_Categoria.SelectedValue.ToString();

                    if (Cmb_Tipo_Producto.Items[Cmb_Tipo_Producto.SelectedIndex].ToString() == "Servicio")
                    {
                        Producto_Modificar.P_Tipo_Servicio = Cmb_Tipo_Servicio.Text;
                        Producto_Modificar.P_Tipo_Valor = (Rdb_SI.Checked ? true : false).ToString();
                    }
                    else
                    {
                        Producto_Modificar.P_Tipo_Servicio = "PRODUCTO";      
                        Producto_Modificar.P_Tipo_Valor = null;
                    }

                    Producto_Modificar.P_Codigo = Txt_Codigo.Text; 
                    Producto_Modificar.P_Costo = Txt_Costo.Text;
                    Producto_Modificar.P_Estatus = Cmb_Estatus.Text;
                    if (!string.IsNullOrEmpty(Nombre_Archivo))
                    {
                        Producto_Modificar.P_Ruta_Imagen = Path.GetDirectoryName(Ruta_Imagen) + @"\p_" + Txt_ID_Producto.Text.Trim() + Path.GetExtension(Nombre_Archivo);
                    }

                    //  validacion para el modulo web
                    if (Chk_Web.Checked == true)
                        Producto_Modificar.P_Aparece_En_Web = "S";
                    else
                        Producto_Modificar.P_Aparece_En_Web = "N";

                    Producto_Modificar.P_Usuario_Modifico = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Producto_Modificar.P_Fecha_Modifico = DateTime.Now;

                    //  validacion para la relacion del producto
                    if (Cmb_Producto_Anterior.SelectedIndex > 0)
                    {
                        Producto_Modificar.P_Relacion_Producto_Id = Cmb_Producto_Anterior.SelectedValue.ToString();
                    }

                    
                    // llamar método para guardar archivo de imagen
                    Guardar_Imagen(Producto_Modificar.P_Ruta_Imagen);
                    Producto_Modificar.Modificar_Producto();

                    MessageBox.Show("El Producto '" + Txt_ID_Producto.Text + "' ha sido modificado", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        if (File.Exists(Path.GetDirectoryName(Ruta)))
                        {
                        }
                        // guardar imagen
                        Pic_Logo.Image.Save(Ruta);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
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
        ///NOMBRE DE LA FUNCIÓN : Consultar_Producto
        ///DESCRIPCIÓN          : Realiza la consulta productos en la base de datos
        ///PARÁMETROS           : 
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Consultar_Producto()
        {
            Cls_Cat_Productos_Negocio Producto_Consultar = new Cls_Cat_Productos_Negocio();

            try
            {
                switch (Cmb_Busqueda_Tipo.Text)
                {
                    case "Id de Producto":
                        Producto_Consultar.P_Producto_Id = Txt_Descripcion_Busqueda.Text;
                        Grid_Productos.DataSource = Producto_Consultar.Consultar_Producto();
                        break;

                    case "Nombre":
                        Producto_Consultar.P_Nombre = Txt_Descripcion_Busqueda.Text;
                        Grid_Productos.DataSource = Producto_Consultar.Consultar_Producto();
                        break;

                    case "Tipo":
                        Producto_Consultar.P_Tipo = Txt_Descripcion_Busqueda.Text;
                        Grid_Productos.DataSource = Producto_Consultar.Consultar_Producto();
                        break;

                    case "Estatus":
                        Producto_Consultar.P_Estatus = Txt_Descripcion_Busqueda.Text;
                        Grid_Productos.DataSource = Producto_Consultar.Consultar_Producto();
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Cargar_Combo_Tipos_Servicios
        /// 
        /// Descripción: Método que carga los tipos de servicios que existen.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 18:02 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Combo_Tipos_Servicios()
        {
            try
            {
                var Lst_Tipos_Servicios = new[] {
                    new { tipo = "<-- Seleccione -->" }, 
                    new { tipo = "SERVICIO" },
                    new { tipo = "ESTACIONAMIENTO" }
                }.ToList();

                Cmb_Tipo_Servicio.DataSource = Lst_Tipos_Servicios;
                Cmb_Tipo_Servicio.ValueMember = "tipo";
                Cmb_Tipo_Servicio.DisplayMember = "tipo";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Combo_Tipos_Servicios]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Cargar_Combo_Productos
        /// 
        /// Descripción: Método que carga los productos existentes
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera.
        /// Fecha Creo: 23 Diciembre 2015 10:13 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Combo_Productos()
        {
            Cls_Cat_Productos_Negocio Rs_Productos = new Cls_Cat_Productos_Negocio();
            DataTable Dt_Productos = new DataTable();
            try
            {
                Dt_Productos = Rs_Productos.Consultar_Producto_X_Anio();
                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Producto_Anterior, Dt_Productos, Cat_Productos.Campo_Nombre, Cat_Productos.Campo_Producto_Id);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Combo_Productos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Generar_Cadena_Proteccion
        /// 
        /// Descripción: Método que genera el código que se enviara a impresión como código de barras.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 15 Noviembre 2013.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Longitud"></param>
        /// <returns></returns>
        public string Generar_Cadena_Proteccion(int Longitud)
        {
            char[] Caracteres = new char[Longitud];
            var Aleatortio = new Random();

            try
            {
                // Si la longitud solicitada es 0 ó menos asignar 10
                if (Longitud <= 0)
                    Longitud = 10;

                // Ciclo para llenar el arreglo de caracteres
                for (int i = 0; i < Caracteres.Length; i++)
                    // asignar un caracter aleatorio al arreglo de carácteres.
                    Caracteres[i] = Caracteres_Validos[Aleatortio.Next(Cantidad_Caracteres)];
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Generar_Cadena_Proteccion]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new String(Caracteres);
        }
        #endregion

        #region Eventos
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Busqueda_Click
        ///DESCRIPCIÓN          : Inicia el proceso de búsqueda de productos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            if (Cmb_Busqueda_Tipo.SelectedIndex > 0)
            {
                Consultar_Producto();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una opción de búsqueda", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Oculta el grupo de búsqueda
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Buscar.Visible = false;
            Carga_Productos();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Inicia el proceso para crear un nuevo producto
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {

            if (Btn_Nuevo.Text.Trim() == "Nuevo")
            {
                Manejo_Botones_Operacion("Nuevo");
                Pic_Logo.Image = null;
                Cls_Metodos_Generales.Limpia_Controles(this);
                Fra_Buscar.Visible = false;
                Fra_Datos_Generales.Visible = true;
                Fra_Datos_Generales.Enabled = true;
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                Txt_ID_Producto.Enabled = false;
                Txt_Codigo.Text = Generar_Cadena_Proteccion(10);
            }
            else
            {
                if (Alta_Producto())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Productos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Modificar_Click
        ///DESCRIPCIÓN          : Inicia el proceso para modificar un producto
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text.Trim() == "Modificar")
            {
                if (Txt_ID_Producto.Text != String.Empty)
                {
                    Fra_Datos_Generales.Visible = true;
                    Fra_Buscar.Visible = false;
                    Fra_Datos_Generales.Enabled = true;
                    Txt_ID_Producto.Enabled = false;
                    Manejo_Botones_Operacion("Modificar");
                }
                else
                {
                    MessageBox.Show("Para modificar un producto, debe seleccionar uno de la lista", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (Modificar_Producto())
                {
                    Manejo_Botones_Operacion("Cancelar");
                    Fra_Datos_Generales.Enabled = false;
                    Carga_Productos();
                }
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Click
        ///DESCRIPCIÓN          : Habilita el Panel de búsqueda
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Pic_Logo.Image = null;
            Fra_Datos_Generales.Visible = false;
            Fra_Buscar.Visible = true;
            Cmb_Busqueda_Tipo.SelectedIndex = 0;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Click
        ///DESCRIPCIÓN          : Elimina un producto de la base de datos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            Cls_Cat_Productos_Negocio Producto_Eliminar = new Cls_Cat_Productos_Negocio();

            try
            {
                if (Txt_ID_Producto.Text != String.Empty)
                {
                    if (MessageBox.Show(this, "¿Quiere realmente eliminar el producto '" + Txt_ID_Producto.Text + "' ?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Producto_Eliminar.P_Producto_Id = Txt_ID_Producto.Text;
                        Producto_Eliminar.Eliminar_Producto();
                        MessageBox.Show("El producto '" + Txt_ID_Producto.Text + "' ha sido eliminado", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                        Carga_Productos();
                    }
                }
                else
                {
                    MessageBox.Show("Para eliminar un producto, debe seleccionar uno de la lista", "Productos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        ///FECHA_CREO           : 03 Octubre 2013
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
                Grid_Productos.Enabled = true;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Tipo_Producto_SelectedIndexChanged
        ///DESCRIPCIÓN          : Valida si se selecciona "Servicio" aparezca el panel con las opciones "SI" o "NO"
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Tipo_Producto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Tipo_Producto.Text == "Servicio")
            {
                Pnl_Respuesta.Visible = true;
            }
            else
            {
                Pnl_Respuesta.Visible = false;
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Costo_KeyPress
        ///DESCRIPCIÓN          : Valida que sólo se puedan introducir números y los puntos decimales.
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Txt_Costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Estatus_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Estatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Tipo_Producto_KeyPress
        ///DESCRIPCIÓN          : Valida que no se puedan insertar valores a través del teclado
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Cmb_Tipo_Producto_KeyPress(object sender, KeyPressEventArgs e)
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
        private void Cmb_Busqueda_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Descripcion_Busqueda.Text = "";
            Txt_Descripcion_Busqueda.Focus();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Buscar_Imagen_Click
        ///DESCRIPCIÓN          : Evento para cargar una imagen para el banco y almacenarla en un directorio
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             : Roberto González Oseguera
        ///FECHA_MODIFICO       : 21-oct-2013
        ///CAUSA_MODIFICACIÓN   : Se agregó parámetro directorio compartido a la ruta y se guarda temporalmente la imagen
        ///*************************************************************************************
        private void Btn_Buscar_Imagen_Click(object sender, EventArgs e)
        {

            Ofd_Imagen.Filter = "Archivos PNG (*.png)|*.png|Archivos JPG (*.jpg)|*.jpg|Archivos BMP (*.bmp)|*.bmp";
            Stream Imagen_Respaldo;
            MemoryStream Imagen_Guardada = new MemoryStream();
            var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
            Obj_Parametros = Obj_Parametros.Obtener_Parametros();

            if (Ofd_Imagen.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    Imagen_Respaldo = Ofd_Imagen.OpenFile();
                    Bitmap Imagen = new Bitmap(Imagen_Respaldo);

                    Pic_Logo.Image = Imagen;
                    Ruta_Imagen = Obj_Parametros.P_Directorio_Compartido + @"\" + Directorio_Productos;
                    Nombre_Archivo = "nombre_temporal" + Path.GetExtension(Ofd_Imagen.FileName);
                    Nueva_Imagen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer la imagen : " + ex.Message);
                }
            }
        }

        #endregion

        #region Eventos Grid

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Productos_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la información del elemento seleccionado en los campos
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Grid_Productos_SelectionChanged(object sender, EventArgs e)
        {
            Cls_Cat_Productos_Negocio Obj_Productos = new Cls_Cat_Productos_Negocio();
            Cls_Cat_Productos_Negocio Obj_Productos_Anterior = new Cls_Cat_Productos_Negocio();
            DataTable Dt_Productos = null;
            DataTable Dt_Producto_Anterior = new DataTable();

            // limpiar imagen
            Pic_Logo.Image = null;

            if (Grid_Productos.CurrentRow != null)
            {
                Txt_ID_Producto.Text = Grid_Productos.CurrentRow.Cells["Producto_ID"].Value.ToString();
                Obj_Productos.P_Producto_Id = Grid_Productos.CurrentRow.Cells["Producto_ID"].Value.ToString();
                Dt_Productos = Obj_Productos.Consultar_Producto();
                Txt_Nombre.Text = Grid_Productos.CurrentRow.Cells["Nombre"].Value.ToString();
                Txt_Descripcion.Text = Grid_Productos.CurrentRow.Cells["Descripcion"].Value.ToString();
                Cmb_Tipo_Producto.Text = Grid_Productos.CurrentRow.Cells["Tipo"].Value.ToString();
                
                //  servicio ****************************************
                if (Cmb_Tipo_Producto.Text == "Servicio")
                {
                    if (Grid_Productos.CurrentRow.Cells["Tipo_Valor"].Value.ToString() != "")
                    {
                        if ((Boolean)Grid_Productos.CurrentRow.Cells["Tipo_Valor"].Value)
                        {
                            Rdb_SI.Checked = true;
                        }
                        else
                        {
                            Rdb_NO.Checked = true;
                        }
                    }
                    else
                    {
                        Rdb_NO.Checked = true;
                    }
                }

                //  web **********************************************************
                if (Grid_Productos.CurrentRow.Cells["Web"].Value.ToString() == "S")
                    Chk_Web.Checked = true;
                else
                    Chk_Web.Checked = false;

                Txt_Costo.Text = Grid_Productos.CurrentRow.Cells["Costo"].Value.ToString();
                Cmb_Estatus.Text = Grid_Productos.CurrentRow.Cells["Estatus"].Value.ToString();
                Cargar_Imagen(Grid_Productos.CurrentRow.Cells["Imagen"].Value.ToString());
                Ruta_Imagen = Grid_Productos.CurrentRow.Cells["Imagen"].Value.ToString();
                Txt_Anio.Text = Dt_Productos.Rows[0]["Anio"].ToString();

                
                if (DBNull.Value.Equals(Dt_Productos.Rows[0]["Categoria_ID"]))
                {
                    Cmb_Categoria.SelectedValue = string.Empty;
                }
                else
                {
                    Cmb_Categoria.SelectedValue = Dt_Productos.Rows[0]["Categoria_ID"].ToString();
                }
                
                //  relacion del producto con años anteriores
                if (!String.IsNullOrEmpty(Dt_Productos.Rows[0][Cat_Productos.Campo_Relacion_Producto_Id].ToString()))
                {
                    Obj_Productos_Anterior.P_Relacion_Producto_Id = Dt_Productos.Rows[0][Cat_Productos.Campo_Relacion_Producto_Id].ToString();
                    Dt_Producto_Anterior = Obj_Productos_Anterior.Consultar_Producto_X_Anio();

                    if (Dt_Producto_Anterior != null && Dt_Producto_Anterior.Rows.Count > 0)
                    {
                        Cmb_Producto_Anterior.Text = Dt_Producto_Anterior.Rows[0]["Nombre"].ToString();
                    }
                    else
                    {
                        Cmb_Producto_Anterior.SelectedIndex = 0;
                    }

                    Obj_Productos_Anterior = new Cls_Cat_Productos_Negocio();
                    Dt_Producto_Anterior = new DataTable();
                }
                else
                {
                    if (Cmb_Producto_Anterior.Items.Count > 0)
                    {
                        Cmb_Producto_Anterior.SelectedIndex = 0;
                    }
                }

                Array.ForEach(Dt_Productos.Rows.OfType<DataRow>().ToArray(), fila => {
                    Txt_Codigo.Text = fila.IsNull(Cat_Productos.Campo_Codigo) ? string.Empty : fila.Field<string>(Cat_Productos.Campo_Codigo);
                });
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Cat_Categorias Cat = new Frm_Cat_Categorias();

            Cat.ShowDialog(this);

            Cargar_Categorias();
        }
    }
}