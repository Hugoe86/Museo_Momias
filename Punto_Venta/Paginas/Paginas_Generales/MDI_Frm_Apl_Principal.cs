using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Erp.Constantes;
using Erp_Apl_Roles.Negocio;
using ERP_BASE.Paginas.Catalogos;
using ERP_BASE.Paginas.Operaciones;
using ERP_BASE.Paginas.Operacion;
using ERP_BASE.Paginas.Operaciones.Grupos;
using Erp_Apl_Parametros.Negocio;
using ERP_BASE.Paginas.Ventanas_Emergentes;
using System.IO;
using ERP_BASE.Paginas.Reportes;
using Erp_Cat_Apl_Registro_Accesos.Negocio;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class MDI_Frm_Apl_Principal : Form
    {
        private int childFormNumber = 0;

        #region "Variables de Formas"

        public static Frm_Cat_Usuarios Frm_Cat_Usuarios_Mdi;
        public static Frm_Apl_Roles Frm_Apl_Roles_Mdi;
        public static Frm_Apl_Parametros Frm_Apl_Parametros_Mdi;
        public static Frm_Apl_Recuperar_Contrasenia Frm_Apl_Recuperar_Contrasenia_Mdi;
        public static Frm_Ope_Ventas Frm_Ope_Ventas_Mdi;
        public static Frm_Ope_Retiros Frm_Ope_Retiros;
        public static Frm_Ope_Turnos Frm_Ope_Turnos;
        public static Frm_Ope_Cajas Frm_Ope_Cajas;
        public static Frm_Ope_Recolecciones Frm_Ope_Recolecciones;
        public static Frm_Cat_Productos Frm_Cat_Productos;
        public static Frm_Cat_Cajas Frm_Cat_Cajas;
        public static Frm_Cat_Turnos Frm_Cat_Turnos;
        public static Frm_Cat_Formas_Pago Frm_Cat_Formas_Pago;
        public static Frm_Cat_Terminales Frm_Cat_Terminales;
        public static Frm_Cat_Camaras Frm_Cat_Camaras;
        public static Frm_Cat_Bancos Frm_Cat_Bancos;
        public static Frm_Cat_Dias_Feriados Frm_Cat_Dias_Feriados;
        public static Frm_Cat_Impresoras Frm_Cat_Impresoras;
        public static Frm_Cat_Impresoras_Cajas Frm_Cat_Impresoras_Cajas;
        public static Frm_Cat_Motivos_Cancelacion Frm_Cat_Motivos_Cancelacion;
        public static Frm_Cat_Motivos_Descuento Frm_Cat_Motivos_Descuento;
        public static Frm_Ope_Grupos Frm_Ope_Grupos;
        public static Frm_Ope_Cancelacion Frm_Ope_Cancelacion;
        public static Frm_Ope_Estacionamiento Frm_Ope_Estacionamiento;
        public static Frm_Rpt_Ventas Frm_Rpt_Ventas;
        public static Frm_Rpt_Ventas_ Frm_Rpt_Ventas_;
        public static Frm_Rpt_Concentrado_Ventas Frm_Rpt_Concentrado_Ventas;
        public static Frm_Apl_Bitacora Frm_Apl_Bitacora;
        public static Frm_Rep_Log Frm_Rep_Log;
        public static Frm_Rpt_Detallado_Ventas Frm_Rpt_Detallado_Ventas;
        public static Frm_Rpt_Ventas_Internet Frm_Rpt_Ventas_Internet;
        public static Frm_Rpt_Reporte_Cortes_Arqueo_Cajas Frm_Rpt_Reporte_Cortes_Arqueo_Cajas;
        public static Frm_Rep_Diario_Recaudacion Frm_Rep_Diario_Recaudacion;
        public static Frm_Rep_Anual_Ingresos Frm_Rep_Anual_Ingresos;
        public static Frm_Rep_Mensual_Ingresos Frm_Rep_Mensual_Ingresos;
        public static Frm_Rpt_Folios_Cancelados Frm_Rpt_Folios_Cancelados;
        public static Frm_Rpt_Reporte_Accesos Frm_Rpt_Reporte_Accesos;
        public static Frm_Cat_Accesos_Camara Frm_Cat_Accesos_Camara;
        public static Frm_Cat_Padron Frm_Cat_Padron;
        public static Frm_Ope_Exportacion Frm_Ope_Exportacion;
        public static Frm_Ope_Facturacion_Electronica Frm_Ope_Facturacion_Electronica;
        public static Frm_Ope_Reimpresion_Accesos Frm_Ope_Reimpresion_Accesos;
        public static Frm_Cat_Lista_Deudorcad Frm_Cat_Lista_Deudorcad;
        
        #endregion "Variables de Formas"

        public MDI_Frm_Apl_Principal()
        {
            InitializeComponent();
        }

        #region Load

        private void MDI_Frm_Apl_Principal_Load(object sender, EventArgs e)
        {
            FileStream Archivo_Imagen = null;
            Conexion_Inicial(true);
            var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
            Obj_Parametros = Obj_Parametros.Obtener_Parametros();
            try
            {
                recoleccionesToolStripMenuItem.Enabled = true;
                SubMenu_Operacion_Arqueo.Enabled = true;
                SubMenu_Operacion_Arqueo.Enabled = true;


                // obtener ruta de la imagen desde parámetros
                string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + @"\Imagenes\Fondo\Fondo.jpg";
                // validar que la ruta exista
                if (System.IO.File.Exists(Ruta_Archivo))
                {
                    // leer archivo de imagen como filestream para que no bloquear el archivo
                    Archivo_Imagen = new FileStream(Ruta_Archivo, FileMode.Open, FileAccess.Read);
                    this.BackgroundImage = Image.FromStream(Archivo_Imagen);
                }
            }
            catch { }
            finally
            {
                // validar que Archivo_Imagen sea diferente de nulo
                if (Archivo_Imagen != null)
                {
                    Archivo_Imagen.Close();
                }
            }
            //  se carga el formulario de login
            Mostrar_Login();
        }

        #endregion Load

        #region Metodos Generales

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        #endregion Metodos Generales

        #region Menu Archivo

        /// ***********************************************************************************
        /// Nombre de la Función: registroToolStripMenuItem_Click
        /// Descripción         : Da acceso al formulario de login
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 25/Febrero/2013 05:38 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cerrar_Ventanas_Abiertas(this);

            //  se registra la salida del sistema
            if (MDI_Frm_Apl_Principal.Usuario_ID != "")
            {
                Paginas_Generales.Frm_Apl_Login.Registrar_Salida();
            }

            Mostrar_Login();
        }

        /// ***********************************************************************************
        /// Nombre de la Función: Sub_Menu_Apl_Salir_Click
        /// Descripción         : Sale del sistema
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 26/Febrero/2013 06:55 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Sub_Menu_Apl_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Menu Archivo

        #region Menu Catalogos

        private void Sub_Menu_Catalogos_Productos_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Productos == null)
            {
                Frm_Cat_Productos = new Frm_Cat_Productos();
                Frm_Cat_Productos.MdiParent = this;
                Frm_Cat_Productos.Show();
            }
            else
            {
                if (Frm_Cat_Productos.IsDisposed)
                {
                    Frm_Cat_Productos = new Frm_Cat_Productos();
                    Frm_Cat_Productos.MdiParent = this;
                    Frm_Cat_Productos.Show();
                }
                else
                {
                    Frm_Cat_Productos.WindowState = FormWindowState.Normal;
                    Frm_Cat_Productos.Activate();
                }
            }
        }

        private void Sub_Menu_Catalogos_Cajas_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Cajas == null)
            {
                Frm_Cat_Cajas = new Frm_Cat_Cajas();
                Frm_Cat_Cajas.MdiParent = this;
                Frm_Cat_Cajas.Show();
            }
            else
            {
                if (Frm_Cat_Cajas.IsDisposed)
                {
                    Frm_Cat_Cajas = new Frm_Cat_Cajas();
                    Frm_Cat_Cajas.MdiParent = this;
                    Frm_Cat_Cajas.Show();
                }
                else
                {
                    Frm_Cat_Cajas.WindowState = FormWindowState.Normal;
                    Frm_Cat_Cajas.Activate();
                }
            }
        }

        private void Sub_Menu_Catalogos_Turnos_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Turnos == null)
            {
                Frm_Cat_Turnos = new Frm_Cat_Turnos();
                Frm_Cat_Turnos.MdiParent = this;
                Frm_Cat_Turnos.Show();
            }
            else
            {
                if (Frm_Cat_Turnos.IsDisposed)
                {
                    Frm_Cat_Turnos = new Frm_Cat_Turnos();
                    Frm_Cat_Turnos.MdiParent = this;
                    Frm_Cat_Turnos.Show();
                }
                else
                {
                    Frm_Cat_Turnos.WindowState = FormWindowState.Normal;
                    Frm_Cat_Turnos.Activate();
                }
            }
        }

        private void Sub_Menu_Catalogos_Formas_Pago_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Formas_Pago == null)
            {
                Frm_Cat_Formas_Pago = new Frm_Cat_Formas_Pago();
                Frm_Cat_Formas_Pago.MdiParent = this;
                Frm_Cat_Formas_Pago.Show();
            }
            else
            {
                if (Frm_Cat_Formas_Pago.IsDisposed)
                {
                    Frm_Cat_Formas_Pago = new Frm_Cat_Formas_Pago();
                    Frm_Cat_Formas_Pago.MdiParent = this;
                    Frm_Cat_Formas_Pago.Show();
                }
                else
                {
                    Frm_Cat_Formas_Pago.WindowState = FormWindowState.Normal;
                    Frm_Cat_Formas_Pago.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Catalogos_Terminales_Click
        ///DESCRIPCIÓN: Manejador del evento click en el submenú del catálogo Terminales: carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Catalogos_Terminales_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Terminales == null)
            {
                Frm_Cat_Terminales = new Frm_Cat_Terminales();
                Frm_Cat_Terminales.MdiParent = this;
                Frm_Cat_Terminales.Show();
            }
            else
            {
                if (Frm_Cat_Terminales.IsDisposed)
                {
                    Frm_Cat_Terminales = new Frm_Cat_Terminales();
                    Frm_Cat_Terminales.MdiParent = this;
                    Frm_Cat_Terminales.Show();
                }
                else
                {
                    Frm_Cat_Terminales.WindowState = FormWindowState.Normal;
                    Frm_Cat_Terminales.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Catalogos_Bancos_Click
        ///DESCRIPCIÓN: Manejador del evento click en el submenú del catálogo Bancos: carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Catalogos_Bancos_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Bancos == null)
            {
                Frm_Cat_Bancos = new Frm_Cat_Bancos();
                Frm_Cat_Bancos.MdiParent = this;
                Frm_Cat_Bancos.Show();
            }
            else
            {
                if (Frm_Cat_Bancos.IsDisposed)
                {
                    Frm_Cat_Bancos = new Frm_Cat_Bancos();
                    Frm_Cat_Bancos.MdiParent = this;
                    Frm_Cat_Bancos.Show();
                }
                else
                {
                    Frm_Cat_Bancos.WindowState = FormWindowState.Normal;
                    Frm_Cat_Bancos.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Catalogos_Dias_Feriados_Click
        ///DESCRIPCIÓN: Manejador del evento click en el submenú del catálogo Días feriados: carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Catalogos_Dias_Feriados_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Dias_Feriados == null)
            {
                Frm_Cat_Dias_Feriados = new Frm_Cat_Dias_Feriados();
                Frm_Cat_Dias_Feriados.MdiParent = this;
                Frm_Cat_Dias_Feriados.Show();
            }
            else
            {
                if (Frm_Cat_Dias_Feriados.IsDisposed)
                {
                    Frm_Cat_Dias_Feriados = new Frm_Cat_Dias_Feriados();
                    Frm_Cat_Dias_Feriados.MdiParent = this;
                    Frm_Cat_Dias_Feriados.Show();
                }
                else
                {
                    Frm_Cat_Dias_Feriados.WindowState = FormWindowState.Normal;
                    Frm_Cat_Dias_Feriados.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Catalogos_Impresoras_Click
        ///DESCRIPCIÓN: Manejador del evento click en el submenú del catálogo Impresoras: 
        ///             carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Catalogos_Impresoras_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Impresoras == null)
            {
                Frm_Cat_Impresoras = new Frm_Cat_Impresoras();
                Frm_Cat_Impresoras.MdiParent = this;
                Frm_Cat_Impresoras.Show();
            }
            else
            {
                if (Frm_Cat_Impresoras.IsDisposed)
                {
                    Frm_Cat_Impresoras = new Frm_Cat_Impresoras();
                    Frm_Cat_Impresoras.MdiParent = this;
                    Frm_Cat_Impresoras.Show();
                }
                else
                {
                    Frm_Cat_Impresoras.WindowState = FormWindowState.Normal;
                    Frm_Cat_Impresoras.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Catalogos_Impresoras_Cajas_Click
        ///DESCRIPCIÓN: Manejador del evento click en el submenú del catálogo Impresoras - cajas: 
        ///             carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 28-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Catalogos_Impresoras_Cajas_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Impresoras_Cajas == null)
            {
                Frm_Cat_Impresoras_Cajas = new Frm_Cat_Impresoras_Cajas();
                Frm_Cat_Impresoras_Cajas.MdiParent = this;
                Frm_Cat_Impresoras_Cajas.Show();
            }
            else
            {
                if (Frm_Cat_Impresoras_Cajas.IsDisposed)
                {
                    Frm_Cat_Impresoras_Cajas = new Frm_Cat_Impresoras_Cajas();
                    Frm_Cat_Impresoras_Cajas.MdiParent = this;
                    Frm_Cat_Impresoras_Cajas.Show();
                }
                else
                {
                    Frm_Cat_Impresoras_Cajas.WindowState = FormWindowState.Normal;
                    Frm_Cat_Impresoras_Cajas.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Catalogos_Motivos_Cancelacion_Click
        ///DESCRIPCIÓN: Manejador del evento click en el submenú del catálogo Motivos de cancelación: 
        ///             carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Catalogos_Motivos_Cancelacion_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Motivos_Cancelacion == null)
            {
                Frm_Cat_Motivos_Cancelacion = new Frm_Cat_Motivos_Cancelacion();
                Frm_Cat_Motivos_Cancelacion.MdiParent = this;
                Frm_Cat_Motivos_Cancelacion.Show();
            }
            else
            {
                if (Frm_Cat_Motivos_Cancelacion.IsDisposed)
                {
                    Frm_Cat_Motivos_Cancelacion = new Frm_Cat_Motivos_Cancelacion();
                    Frm_Cat_Motivos_Cancelacion.MdiParent = this;
                    Frm_Cat_Motivos_Cancelacion.Show();
                }
                else
                {
                    Frm_Cat_Motivos_Cancelacion.WindowState = FormWindowState.Normal;
                    Frm_Cat_Motivos_Cancelacion.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Catalogos_Motivos_Descuento_Click
        ///DESCRIPCIÓN: Manejador del evento click en el submenú del catálogo Motivos de descuento: 
        ///             carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Catalogos_Motivos_Descuento_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Motivos_Descuento == null)
            {
                Frm_Cat_Motivos_Descuento = new Frm_Cat_Motivos_Descuento();
                Frm_Cat_Motivos_Descuento.MdiParent = this;
                Frm_Cat_Motivos_Descuento.Show();
            }
            else
            {
                if (Frm_Cat_Motivos_Descuento.IsDisposed)
                {
                    Frm_Cat_Motivos_Descuento = new Frm_Cat_Motivos_Descuento();
                    Frm_Cat_Motivos_Descuento.MdiParent = this;
                    Frm_Cat_Motivos_Descuento.Show();
                }
                else
                {
                    Frm_Cat_Motivos_Descuento.WindowState = FormWindowState.Normal;
                    Frm_Cat_Motivos_Descuento.Activate();
                }
            }
        }

        #region Seguridad

        /// ***********************************************************************************
        /// Nombre de la Función: Sub_Sub_Menu_Cat_General_Roles_Click
        /// Descripción         : Da acceso al formulario de roles
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 25/Febrero/2013 05:38 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Sub_Sub_Menu_Cat_General_Roles_Click(object sender, EventArgs e)
        {
            if (Frm_Apl_Roles_Mdi == null)
            {
                Frm_Apl_Roles_Mdi = new Frm_Apl_Roles();
                Frm_Apl_Roles_Mdi.MdiParent = this;
                Frm_Apl_Roles_Mdi.Show();
            }
            else
            {
                if (Frm_Apl_Roles_Mdi.IsDisposed)
                {
                    Frm_Apl_Roles_Mdi = new Frm_Apl_Roles();
                    Frm_Apl_Roles_Mdi.MdiParent = this;
                    Frm_Apl_Roles_Mdi.Show();
                }
                else
                {
                    Frm_Apl_Roles_Mdi.WindowState = FormWindowState.Normal;
                    Frm_Apl_Roles_Mdi.Activate();
                }
            }
        }

        /// ***********************************************************************************
        /// Nombre de la Función: Sub_Sub_Menu_Cat_Generales_Usuarios_Click
        /// Descripción         : Da acceso al formulario de usuarios
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 25/Febrero/2013 05:38 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Sub_Sub_Menu_Cat_Generales_Usuarios_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Usuarios_Mdi == null)
            {
                Frm_Cat_Usuarios_Mdi = new Frm_Cat_Usuarios();
                Frm_Cat_Usuarios_Mdi.MdiParent = this;
                Frm_Cat_Usuarios_Mdi.Show();
            }
            else
            {
                if (Frm_Cat_Usuarios_Mdi.IsDisposed)
                {
                    Frm_Cat_Usuarios_Mdi = new Frm_Cat_Usuarios();
                    Frm_Cat_Usuarios_Mdi.MdiParent = this;
                    Frm_Cat_Usuarios_Mdi.Show();
                }
                else
                {
                    Frm_Cat_Usuarios_Mdi.WindowState = FormWindowState.Normal;
                    Frm_Cat_Usuarios_Mdi.Activate();
                }
            }
        }

        #endregion Seguridad

        #endregion Menu Catalogos

        #region Login

        /// ***********************************************************************************
        /// Nombre de la Función: Cerrar_Ventanas_Abiertas
        /// Descripción         : Cierra todas las ventanas que se encuentren abiertas
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 25/Febrero/2013 05:38 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Cerrar_Ventanas_Abiertas(Form MDIPrincipal)
        {
            foreach (Form Ventana_Hija in MDIPrincipal.MdiChildren)
            {
                Ventana_Hija.Dispose();
                Ventana_Hija.Close();
            }
        }

        /// ***********************************************************************************
        /// Nombre de la Función: Mostrar_Login
        /// Descripción         : Cierra todas las ventanas que se encuentren abiertas
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 25/Febrero/2013 05:38 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Mostrar_Login()
        {
            Frm_Apl_Login Frm_Apl_Registo;
            Frm_Apl_Registo = new Frm_Apl_Login();

            //  Se limpia la etiqueta de usuario logueado
            ToolStrip_Usuario_Logueado.Text = "";

            Ocultar_Menus_Sistema(this.MainMenuStrip);
            Mostrar_Menu_Login();

            int Estatus = (int)Frm_Apl_Login.Entrar(this, Frm_Apl_Registo);

            if (Estatus == 1)
            {
                Mostrar_Menus_Rol();
                ToolStrip_Usuario_Logueado.Text = MDI_Frm_Apl_Principal.Nombre_Usuario;
            }
        }

        /// ***********************************************************************************
        /// Nombre de la Función: Mostrar_Menu_Login
        /// Descripción         : muestra el menu de login dentro del formulario principal
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 25/Febrero/2013 05:38 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Mostrar_Menu_Login()
        {
            this.Menu_Archivo.Visible = true;
            this.Sub_Menu_Archivo_Registro.Visible = true;
            this.Sub_Menu_Recuperar_Contrasenia.Visible = true;
            this.Sub_Menu_Archivo_Salir.Visible = true;
        }

        /// ***********************************************************************************
        /// Nombre de la Función: Cargar_Acceso_Menu
        /// Descripción         : configura los menus a los que puede acceder al sistema
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 26/Febrero/2013 04:28 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Mostrar_Menus_Rol()
        {
            DataTable Dt_Consulta_Accesos = new DataTable();
            Cls_Apl_Roles_Negocio Rs_Consulta_Accesos = new Cls_Apl_Roles_Negocio();

            Rs_Consulta_Accesos.P_Rol_Id = MDI_Frm_Apl_Principal.Rol_ID;
            Dt_Consulta_Accesos = Rs_Consulta_Accesos.Consultar_Acceso_Roles();

            if (Dt_Consulta_Accesos != null && Dt_Consulta_Accesos.Rows.Count > 0)
            {
                foreach (DataRow Renglon_Acceso in Dt_Consulta_Accesos.Rows)
                {
                    if (!String.IsNullOrEmpty(Renglon_Acceso[Apl_Acceso.Campo_Nombre_Menu].ToString()))
                    {
                        Buscar_Menu(this.MainMenuStrip, Renglon_Acceso[Apl_Acceso.Campo_Nombre_Menu].ToString());
                    }
                }
            }
        }

        /// ***********************************************************************************
        /// Nombre de la Función: Cargar_Acceso_Menu
        /// Descripción         : configura los menus a los que puede acceder al sistema
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 26/Febrero/2013 04:28 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Buscar_Menu(MenuStrip MDIPrincipal, String Nombre_Menu)
        {
            ToolStripMenuItem Menu_Auxiliar_Nivel_1;
            ToolStripMenuItem Menu_Auxiliar_Nivel_2;

            foreach (Object Menu in MDIPrincipal.Items)
            {
                //  menu
                if (Menu is ToolStripMenuItem)
                {
                    if (Menu.ToString() == Nombre_Menu)
                    {
                        ToolStripMenuItem Sub_Menu = (ToolStripMenuItem)Menu;
                        Sub_Menu.Visible = true;
                        break;
                    }

                    //  se convierte el ToolStripMenuItem
                    if (Menu is ToolStripMenuItem)
                    {
                        Menu_Auxiliar_Nivel_1 = (ToolStripMenuItem)Menu;

                        //  se consultan los submenus
                        foreach (Object Sub_Menu_Nivel_1 in Menu_Auxiliar_Nivel_1.DropDownItems)
                        {
                            if (Sub_Menu_Nivel_1 is ToolStripMenuItem)
                            {
                                if (Sub_Menu_Nivel_1.ToString() == Nombre_Menu)
                                {
                                    ToolStripMenuItem Sub_Menu = (ToolStripMenuItem)Sub_Menu_Nivel_1;
                                    Sub_Menu.Visible = true;
                                    break;
                                }
                            }
                            if (Sub_Menu_Nivel_1 is ToolStripMenuItem)
                            {
                                Menu_Auxiliar_Nivel_2 = (ToolStripMenuItem)Sub_Menu_Nivel_1;
                                foreach (Object Sub_Menu_Nivel_2 in Menu_Auxiliar_Nivel_2.DropDownItems)
                                {
                                    if (Sub_Menu_Nivel_2 is ToolStripMenuItem)
                                    {
                                        if (Sub_Menu_Nivel_2.ToString() == Nombre_Menu)
                                        {
                                            ToolStripMenuItem Sub_Menu = (ToolStripMenuItem)Sub_Menu_Nivel_2;
                                            Sub_Menu.Visible = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// ***********************************************************************************
        /// Nombre de la Función: Ocultar_Menus_Sistema
        /// Descripción         : oculta los menus
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 26/Febrero/2013 12:38 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Ocultar_Menus_Sistema(MenuStrip Menu)
        {
            ToolStripMenuItem Menu_Auxiliar_Nivel_1;
            ToolStripMenuItem Menu_Auxiliar_Nivel_2;
            ToolStripMenuItem Sub_Menu_Bloqueado;
            ToolStripMenuItem Sub_Sub_Menu_Bloqueado;

            foreach (Object Renglon_Sub_Menu in Menu.Items)
            {
                if (Renglon_Sub_Menu is ToolStripMenuItem)
                {
                    ToolStripMenuItem Sub_menu = (ToolStripMenuItem)Renglon_Sub_Menu;

                    //  se convierte el ToolStripMenuItem
                    Menu_Auxiliar_Nivel_1 = (ToolStripMenuItem)Renglon_Sub_Menu;

                    //  se consultan los submenus
                    foreach (Object Sub_Menu_Nivel_1 in Menu_Auxiliar_Nivel_1.DropDownItems)
                    {
                        if (Sub_Menu_Nivel_1 is ToolStripMenuItem)
                        {
                            Sub_Menu_Bloqueado = (ToolStripMenuItem)Sub_Menu_Nivel_1;

                            Menu_Auxiliar_Nivel_2 = (ToolStripMenuItem)Sub_Menu_Nivel_1;
                            foreach (Object Sub_Menu_Nivel_2 in Menu_Auxiliar_Nivel_2.DropDownItems)
                            {
                                if (Sub_Menu_Nivel_2 is ToolStripMenuItem)
                                {
                                    Sub_Sub_Menu_Bloqueado = (ToolStripMenuItem)Sub_Menu_Nivel_2;
                                    Sub_Sub_Menu_Bloqueado.Visible = false;
                                }
                            }
                            Sub_Menu_Bloqueado.Visible = false;
                        }
                    }

                    Sub_menu.Visible = false;
                }
            }
        }

        #endregion Login

        #region Timer

        /// ***********************************************************************************
        /// Nombre de la Función: Tmr_Fecha_Hora_Sistema_Tick
        /// Descripción         : visualizar la fecha y hora
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 26/Febrero/2013 12:00 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void Tmr_Fecha_Hora_Sistema_Tick(object sender, EventArgs e)
        {
            ToolStrip_Fecha_Hora_Sistema.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString().ToString();
        }

        #endregion Timer

        #region Mdi_Form

        /// ***********************************************************************************
        /// Nombre de la Función: MDI_Frm_Apl_Principal_FormClosed
        /// Descripción         : registra la informacion de la salida del formulario
        /// Parámetros          :
        /// Usuario Creo        : Hugo Enrique Ramírez Aguilera
        /// Fecha Creó          : 25/Febrero/2013 06:55 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        private void MDI_Frm_Apl_Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  registra la salida
            if (MDI_Frm_Apl_Principal.Usuario_ID != "")
                Frm_Apl_Login.Registrar_Salida();
        }

        #endregion Mdi_Form

        private void Sub_Menu_Catalogo_Parametros_Click(object sender, EventArgs e)
        {
            if (Frm_Apl_Parametros_Mdi == null)
            {
                Frm_Apl_Parametros_Mdi = new Frm_Apl_Parametros();
                Frm_Apl_Parametros_Mdi.MdiParent = this;
                Frm_Apl_Parametros_Mdi.Show();
            }
            else
            {
                if (Frm_Apl_Parametros_Mdi.IsDisposed)
                {
                    Frm_Apl_Parametros_Mdi = new Frm_Apl_Parametros();
                    Frm_Apl_Parametros_Mdi.MdiParent = this;
                    Frm_Apl_Parametros_Mdi.Show();
                }
                else
                {
                    Frm_Apl_Parametros_Mdi.WindowState = FormWindowState.Normal;
                    Frm_Apl_Parametros_Mdi.Activate();
                }
            }
        }

        private void Sub_Menu_Recuperar_Contrasenia_Click(object sender, EventArgs e)
        {
            if (Frm_Apl_Recuperar_Contrasenia_Mdi == null)
            {
                Frm_Apl_Recuperar_Contrasenia_Mdi = new Frm_Apl_Recuperar_Contrasenia();
                Frm_Apl_Recuperar_Contrasenia_Mdi.MdiParent = this;
                Frm_Apl_Recuperar_Contrasenia_Mdi.Show();
            }
            else
            {
                if (Frm_Apl_Recuperar_Contrasenia_Mdi.IsDisposed)
                {
                    Frm_Apl_Recuperar_Contrasenia_Mdi = new Frm_Apl_Recuperar_Contrasenia();
                    Frm_Apl_Recuperar_Contrasenia_Mdi.MdiParent = this;
                    Frm_Apl_Recuperar_Contrasenia_Mdi.Show();
                }
                else
                {
                    Frm_Apl_Recuperar_Contrasenia_Mdi.WindowState = FormWindowState.Normal;
                    Frm_Apl_Recuperar_Contrasenia_Mdi.Activate();
                }
            }
        }

        private void Sub_Menu_Retiros_Click(object sender, EventArgs e)
        {
            if (Frm_Ope_Retiros == null)
            {
                Frm_Ope_Retiros = new Frm_Ope_Retiros();
                Frm_Ope_Retiros.MdiParent = this;
                Frm_Ope_Retiros.Show();
            }
            else
            {
                if (Frm_Ope_Retiros.IsDisposed)
                {
                    Frm_Ope_Retiros = new Frm_Ope_Retiros();
                    Frm_Ope_Retiros.MdiParent = this;
                    Frm_Ope_Retiros.Show();
                }
                else
                {
                    Frm_Ope_Retiros.WindowState = FormWindowState.Normal;
                    Frm_Ope_Retiros.Activate();
                }
            }
        }

        private void Sub_Menu_Operaciones_Ventas_Click(object sender, EventArgs e)
        {
            if (Frm_Ope_Ventas_Mdi == null)
            {
                Frm_Ope_Ventas_Mdi = new Frm_Ope_Ventas();
                Frm_Ope_Ventas_Mdi.MdiParent = this;
                Frm_Ope_Ventas_Mdi.Show();
            }
            else
            {
                if (Frm_Ope_Ventas_Mdi.IsDisposed)
                {
                    Frm_Ope_Ventas_Mdi = new Frm_Ope_Ventas();
                    Frm_Ope_Ventas_Mdi.MdiParent = this;
                    Frm_Ope_Ventas_Mdi.Show();
                }
                else
                {
                    Frm_Ope_Ventas_Mdi.WindowState = FormWindowState.Normal;
                    Frm_Ope_Ventas_Mdi.Activate();
                    Frm_Ope_Ventas_Mdi.Show();
                }
            }
        }
        
        private void Sub_Menu_Recplecciones_Click(object sender, EventArgs e)
        {
            int Cont_Objetos = 0;
            MDI_Frm_Apl_Principal.Opt_Arqueos = false;
            MDI_Frm_Apl_Principal.Opt_Recoleccion = true;
            MDI_Frm_Apl_Principal.Opt_Cierre = false;




            if (Frm_Ope_Recolecciones == null)
            {
                Frm_Ope_Recolecciones = new Frm_Ope_Recolecciones();
                Frm_Ope_Recolecciones.MdiParent = this; 
                Frm_Ope_Recolecciones.Text = "Recoleccion";
                Frm_Ope_Recolecciones.Show();
            }
            else
            {
                if (Frm_Ope_Recolecciones.IsDisposed)
                {
                    Frm_Ope_Recolecciones = new Frm_Ope_Recolecciones();
                    Frm_Ope_Recolecciones.MdiParent = this;
                    Frm_Ope_Recolecciones.Text = "Recoleccion";
                    Frm_Ope_Recolecciones.Show();
                }
                else
                {
                    Frm_Ope_Recolecciones.WindowState = FormWindowState.Normal;
                    Frm_Ope_Recolecciones.Text = "Recoleccion";
                    Frm_Ope_Recolecciones.Activate();
                }
            }

            foreach (Control Controles in Frm_Ope_Recolecciones.Controls)
            {
                foreach (Control Objeto in Controles.Controls)
                {
                    foreach (Control Objeto_2 in Objeto.Controls)
                    {
                        if (((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Arqueo"))
                            || ((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Cierre_Caja")))
                        {
                            Objeto_2.Visible = false;
                            Cont_Objetos++;
                            //Opt_Recoleccion
                        }
                        if (((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Recoleccion")))
                        {
                            RadioButton Opt_Arqueo = (RadioButton)Objeto_2;
                            Opt_Arqueo.Checked = true;
                            Cont_Objetos++;
                        }
                        if (Cont_Objetos == 3)
                            break;
                    }
                    if (Cont_Objetos == 3)
                        break;
                }
                if (Cont_Objetos == 3)
                    break;
            }

            SubMenu_Operacion_Arqueo.Enabled = false;
            SubMenu_Operacion_Cierre_Caja.Enabled = false;
        }
		
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Ope_Turnos_Click
        ///DESCRIPCIÓN: Manejador del evento click en el menú de operación turnos: carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Ope_Turnos_Click(object sender, EventArgs e)
        {
            // si el formulario aún no se ha instanciado, crear y mostrar una instancia
            if (Frm_Ope_Turnos == null)
            {
                Frm_Ope_Turnos = new Frm_Ope_Turnos();
                Frm_Ope_Turnos.MdiParent = this;
                Frm_Ope_Turnos.Show();
            }
            else
            {
                // validar si el formulario fue cerrado, crear y mostrar una instancia del formulario de operación
                if (Frm_Ope_Turnos.IsDisposed)
                {
                    Frm_Ope_Turnos = new Frm_Ope_Turnos();
                    Frm_Ope_Turnos.MdiParent = this;
                    Frm_Ope_Turnos.Show();
                }
                else // mostrar el formulario
                {
                    Frm_Ope_Turnos.WindowState = FormWindowState.Normal;
                    Frm_Ope_Turnos.Activate();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Sub_Menu_Ope_Turnos_Click
        ///DESCRIPCIÓN: Manejador del evento click en el menú de operación turnos: carga o muestra el formulario correspondiente
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Sub_Menu_Cajas_Click(object sender, EventArgs e)
        {
            // si el formulario aún no se ha instanciado, crear y mostrar una instancia
            if (Frm_Ope_Cajas == null)
            {
                Frm_Ope_Cajas = new Frm_Ope_Cajas();
                Frm_Ope_Cajas.MdiParent = this;
                Frm_Ope_Cajas.Show();
            }
            else
            {
                // validar si el formulario fue cerrado, crear y mostrar una instancia del formulario de operación
                if (Frm_Ope_Cajas.IsDisposed)
                {
                    Frm_Ope_Cajas = new Frm_Ope_Cajas();
                    Frm_Ope_Cajas.MdiParent = this;
                    Frm_Ope_Cajas.Show();
                }
                else // mostrar el formulario
                {
                    Frm_Ope_Cajas.WindowState = FormWindowState.Normal;
                    Frm_Ope_Cajas.Activate();
                }
            }
        }

        private void Sub_Menu_Grupos_Click(object sender, EventArgs e)
        {
            if (Frm_Ope_Grupos == null)
            {
                Frm_Ope_Grupos = new Frm_Ope_Grupos();
                Frm_Ope_Grupos.MdiParent = this;
                Frm_Ope_Grupos.Show();
            }
            else
            {
                if (Frm_Ope_Grupos.IsDisposed)
                {
                    Frm_Ope_Grupos = new Frm_Ope_Grupos();
                    Frm_Ope_Grupos.MdiParent = this;
                    Frm_Ope_Grupos.Show();
                }
                else
                {
                    Frm_Ope_Grupos.WindowState = FormWindowState.Normal;
                    Frm_Ope_Grupos.Activate();
                }
            }
        }

        private void SubMenu_Cancelaciones_Click(object sender, EventArgs e)
        {
            if (Frm_Ope_Cancelacion == null)
            {
                Frm_Ope_Cancelacion = new Frm_Ope_Cancelacion();
                Frm_Ope_Cancelacion.MdiParent = this;
                Frm_Ope_Cancelacion.Show();
            }
            else
            {
                if (Frm_Ope_Cancelacion.IsDisposed)
                {
                    Frm_Ope_Cancelacion = new Frm_Ope_Cancelacion();
                    Frm_Ope_Cancelacion.MdiParent = this;
                    Frm_Ope_Cancelacion.Show();
                }
                else
                {
                    Frm_Ope_Cancelacion.WindowState = FormWindowState.Normal;
                    Frm_Ope_Cancelacion.Activate();
                }
            }
        }

        private void Sub_Menu_Estacionamiento_Click(object sender, EventArgs e)
        {
            if (Frm_Ope_Estacionamiento == null)
            {
                Frm_Ope_Estacionamiento = new Frm_Ope_Estacionamiento();
                Frm_Ope_Estacionamiento.MdiParent = this;
                Frm_Ope_Estacionamiento.Show();
            }
            else
            {
                if (Frm_Ope_Estacionamiento.IsDisposed)
                {
                    Frm_Ope_Estacionamiento = new Frm_Ope_Estacionamiento();
                    Frm_Ope_Estacionamiento.MdiParent = this;
                    Frm_Ope_Estacionamiento.Show();
                }
                else
                {
                    Frm_Ope_Estacionamiento.WindowState = FormWindowState.Normal;
                    Frm_Ope_Estacionamiento.Activate();
                }
            }
        }

        private void Sub_Menu_Rpt_Ventas_Click(object sender, EventArgs e)
        {
            if (Frm_Rpt_Ventas_ == null)
            {
                Frm_Rpt_Ventas_ = new Frm_Rpt_Ventas_();
                Frm_Rpt_Ventas_.MdiParent = this;
                Frm_Rpt_Ventas_.Show();
            }
            else
            {
                if (Frm_Rpt_Ventas_.IsDisposed)
                {
                    Frm_Rpt_Ventas_ = new Frm_Rpt_Ventas_();
                    Frm_Rpt_Ventas_.MdiParent = this;
                    Frm_Rpt_Ventas_.Show();
                }
                else
                {
                    Frm_Rpt_Ventas_.WindowState = FormWindowState.Normal;
                    Frm_Rpt_Ventas_.Activate();
                }
            }
        }

        private void Sub_Menu_Reporte_Concentrado_Ventas_Click(object sender, EventArgs e)
        {
            if (Frm_Rpt_Concentrado_Ventas == null)
            {
                Frm_Rpt_Concentrado_Ventas = new Frm_Rpt_Concentrado_Ventas();
                Frm_Rpt_Concentrado_Ventas.MdiParent = this;
                Frm_Rpt_Concentrado_Ventas.Show();
            }
            else
            {
                if (Frm_Rpt_Concentrado_Ventas.IsDisposed)
                {
                    Frm_Rpt_Concentrado_Ventas = new Frm_Rpt_Concentrado_Ventas();
                    Frm_Rpt_Concentrado_Ventas.MdiParent = this;
                    Frm_Rpt_Concentrado_Ventas.Show();
                }
                else
                {
                    Frm_Rpt_Concentrado_Ventas.WindowState = FormWindowState.Normal;
                    Frm_Rpt_Concentrado_Ventas.Activate();
                }
            }
        }

        private void Sub_Sub_Menu_Log_Click(object sender, EventArgs e)
        {
            if (Frm_Apl_Bitacora == null)
            {
                Frm_Apl_Bitacora = new Frm_Apl_Bitacora();
                Frm_Apl_Bitacora.MdiParent = this;
                Frm_Apl_Bitacora.Show();
            }
            else
            {
                if (Frm_Apl_Bitacora.IsDisposed)
                {
                    Frm_Apl_Bitacora = new Frm_Apl_Bitacora();
                    Frm_Apl_Bitacora.MdiParent = this;
                    Frm_Apl_Bitacora.Show();
                }
                else
                {
                    Frm_Apl_Bitacora.WindowState = FormWindowState.Normal;
                    Frm_Apl_Bitacora.Activate();
                }
            }
        }

        private void Sub_Menu_Reporte_Log_Click(object sender, EventArgs e)
        {
            if (Frm_Rep_Log == null)
            {
                Frm_Rep_Log = new Frm_Rep_Log();
                Frm_Rep_Log.MdiParent = this;
                Frm_Rep_Log.Show();
            }
            else
            {
                if (Frm_Rep_Log.IsDisposed)
                {
                    Frm_Rep_Log = new Frm_Rep_Log();
                    Frm_Rep_Log.MdiParent = this;
                    Frm_Rep_Log.Show();
                }
                else
                {
                    Frm_Rep_Log.WindowState = FormWindowState.Normal;
                    Frm_Rep_Log.Activate();
                }
            }
        }

        private void Sub_Menu_Detalle_Ventas_Click(object sender, EventArgs e)
        {
            if (Frm_Rpt_Detallado_Ventas == null)
            {
                Frm_Rpt_Detallado_Ventas = new Frm_Rpt_Detallado_Ventas();
                Frm_Rpt_Detallado_Ventas.MdiParent = this;
                Frm_Rpt_Detallado_Ventas.Show();
            }
            else
            {
                if (Frm_Rpt_Detallado_Ventas.IsDisposed)
                {
                    Frm_Rpt_Detallado_Ventas = new Frm_Rpt_Detallado_Ventas();
                    Frm_Rpt_Detallado_Ventas.MdiParent = this;
                    Frm_Rpt_Detallado_Ventas.Show();
                }
                else
                {
                    Frm_Rpt_Detallado_Ventas.WindowState = FormWindowState.Normal;
                    Frm_Rpt_Detallado_Ventas.Activate();
                }
            }
        }

        private void Sub_Menu_Cortes_Caja_Arqueos_Click(object sender, EventArgs e)
        {
            if (Frm_Rpt_Reporte_Cortes_Arqueo_Cajas == null)
            {
                Frm_Rpt_Reporte_Cortes_Arqueo_Cajas = new Frm_Rpt_Reporte_Cortes_Arqueo_Cajas();
                Frm_Rpt_Reporte_Cortes_Arqueo_Cajas.MdiParent = this;
                Frm_Rpt_Reporte_Cortes_Arqueo_Cajas.Show();
            }
            else
            {
                if (Frm_Rpt_Reporte_Cortes_Arqueo_Cajas.IsDisposed)
                {
                    Frm_Rpt_Reporte_Cortes_Arqueo_Cajas = new Frm_Rpt_Reporte_Cortes_Arqueo_Cajas();
                    Frm_Rpt_Reporte_Cortes_Arqueo_Cajas.MdiParent = this;
                    Frm_Rpt_Reporte_Cortes_Arqueo_Cajas.Show();
                }
                else
                {
                    Frm_Rpt_Reporte_Cortes_Arqueo_Cajas.WindowState = FormWindowState.Normal;
                    Frm_Rpt_Reporte_Cortes_Arqueo_Cajas.Activate();
                }
            }
        }

        private void Sub_Menu_Reporte_Diario_Recaudacion_Click(object sender, EventArgs e)
        {
            if (Frm_Rep_Diario_Recaudacion == null)
            {
                Frm_Rep_Diario_Recaudacion = new Frm_Rep_Diario_Recaudacion();
                Frm_Rep_Diario_Recaudacion.MdiParent = this;
                Frm_Rep_Diario_Recaudacion.Show();
            }
            else
            {
                if (Frm_Rep_Diario_Recaudacion.IsDisposed)
                {
                    Frm_Rep_Diario_Recaudacion = new Frm_Rep_Diario_Recaudacion();
                    Frm_Rep_Diario_Recaudacion.MdiParent = this;
                    Frm_Rep_Diario_Recaudacion.Show();
                }
                else
                {
                    Frm_Rep_Diario_Recaudacion.WindowState = FormWindowState.Normal;
                    Frm_Rep_Diario_Recaudacion.Activate();
                }
            }
        }

        private void Sub_Menu_Reporte_Analisis_Mensual_Click(object sender, EventArgs e)
        {
            if (Frm_Rep_Mensual_Ingresos == null)
            {
                Frm_Rep_Mensual_Ingresos = new Frm_Rep_Mensual_Ingresos();
                Frm_Rep_Mensual_Ingresos.MdiParent = this;
                Frm_Rep_Mensual_Ingresos.Show();
            }
            else
            {
                if (Frm_Rep_Mensual_Ingresos.IsDisposed)
                {
                    Frm_Rep_Mensual_Ingresos = new Frm_Rep_Mensual_Ingresos();
                    Frm_Rep_Mensual_Ingresos.MdiParent = this;
                    Frm_Rep_Mensual_Ingresos.Show();
                }
                else
                {
                    Frm_Rep_Mensual_Ingresos.WindowState = FormWindowState.Normal;
                    Frm_Rep_Mensual_Ingresos.Activate();
                }
            }
        }

        private void Sub_Menu_Reporte_Anual_Ingresos_Click(object sender, EventArgs e)
        {
            Frm_Rep_Anual Obj = new Frm_Rep_Anual();

            Obj.MdiParent = this;
            Obj.Show();

            //if (Frm_Rep_Anual_Ingresos == null)
            //{
            //    Frm_Rep_Anual_Ingresos = new Frm_Rep_Anual_Ingresos();
            //    Frm_Rep_Anual_Ingresos.MdiParent = this;
            //    Frm_Rep_Anual_Ingresos.Show();
            //}
            //else
            //{
            //    if (Frm_Rep_Anual_Ingresos.IsDisposed)
            //    {
            //        Frm_Rep_Anual_Ingresos = new Frm_Rep_Anual_Ingresos();
            //        Frm_Rep_Anual_Ingresos.MdiParent = this;
            //        Frm_Rep_Anual_Ingresos.Show();
            //    }
            //    else
            //    {
            //        Frm_Rep_Anual_Ingresos.WindowState = FormWindowState.Normal;
            //        Frm_Rep_Anual_Ingresos.Activate();
            //    }
            //}
        }

        private void Sub_Menu_Folios_Cancelados_Click(object sender, EventArgs e)
        {
            if (Frm_Rpt_Folios_Cancelados == null)
            {
                Frm_Rpt_Folios_Cancelados = new Frm_Rpt_Folios_Cancelados();
                Frm_Rpt_Folios_Cancelados.MdiParent = this;
                Frm_Rpt_Folios_Cancelados.Show();
            }
            else
            {
                if (Frm_Rpt_Folios_Cancelados.IsDisposed)
                {
                    Frm_Rpt_Folios_Cancelados = new Frm_Rpt_Folios_Cancelados();
                    Frm_Rpt_Folios_Cancelados.MdiParent = this;
                    Frm_Rpt_Folios_Cancelados.Show();
                }
                else
                {
                    Frm_Rpt_Folios_Cancelados.WindowState = FormWindowState.Normal;
                    Frm_Rpt_Folios_Cancelados.Activate();
                }
            }
        }

        private void Sub_Menu_Concentrado_Accesos_Click(object sender, EventArgs e)
        {
            if (Frm_Rpt_Reporte_Accesos == null)
            {
                Frm_Rpt_Reporte_Accesos = new Frm_Rpt_Reporte_Accesos();
                Frm_Rpt_Reporte_Accesos.MdiParent = this;
                Frm_Rpt_Reporte_Accesos.Show();
            }
            else
            {
                if (Frm_Rpt_Reporte_Accesos.IsDisposed)
                {
                    Frm_Rpt_Reporte_Accesos = new Frm_Rpt_Reporte_Accesos();
                    Frm_Rpt_Reporte_Accesos.MdiParent = this;
                    Frm_Rpt_Reporte_Accesos.Show();
                }
                else
                {
                    Frm_Rpt_Reporte_Accesos.WindowState = FormWindowState.Normal;
                    Frm_Rpt_Reporte_Accesos.Activate();
                }
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Sub_Menu_Catalogo_Camaras_Click
        ///DESCRIPCIÓN          : Habilita el menu de catalogo de camaras
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 02 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Sub_Menu_Catalogo_Camaras_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Camaras == null)
            {
                Frm_Cat_Camaras = new Frm_Cat_Camaras();
                Frm_Cat_Camaras.MdiParent = this;
                Frm_Cat_Camaras.Show();
            }
            else
            {
                if (Frm_Cat_Camaras.IsDisposed)
                {
                    Frm_Cat_Camaras = new Frm_Cat_Camaras();
                    Frm_Cat_Camaras.MdiParent = this;
                    Frm_Cat_Camaras.Show();
                }
                else
                {
                    Frm_Cat_Camaras.WindowState = FormWindowState.Normal;
                    Frm_Cat_Camaras.Activate();
                }
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Sub_Menu_Operaciones_Camaras_Click
        ///DESCRIPCIÓN          : Habilita el menu de operaciones>migracion de informacion 
        ///                         de las camaras
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 02 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Sub_Menu_Operaciones_Camaras_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Accesos_Camara == null)
            {
                Frm_Cat_Accesos_Camara = new Frm_Cat_Accesos_Camara();
                Frm_Cat_Accesos_Camara.MdiParent = this;
                Frm_Cat_Accesos_Camara.Show();
            }
            else
            {
                if (Frm_Cat_Accesos_Camara.IsDisposed)
                {
                    Frm_Cat_Accesos_Camara = new Frm_Cat_Accesos_Camara();
                    Frm_Cat_Accesos_Camara.MdiParent = this;
                    Frm_Cat_Accesos_Camara.Show();
                }
                else
                {
                    Frm_Cat_Accesos_Camara.WindowState = FormWindowState.Normal;
                    Frm_Cat_Accesos_Camara.Activate();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : SubMenu_Operacion_Arqueo_Click
        ///DESCRIPCIÓN          : Habilita el menu de catalogo de recoleccion, modalidad arqueo
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 30 Enero 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void SubMenu_Operacion_Arqueo_Click(object sender, EventArgs e)
        {
            MDI_Frm_Apl_Principal.Opt_Arqueos = true;
            MDI_Frm_Apl_Principal.Opt_Recoleccion = false;
            MDI_Frm_Apl_Principal.Opt_Cierre = false;

            if (Frm_Ope_Recolecciones == null)
            {
                Frm_Ope_Recolecciones = new Frm_Ope_Recolecciones();
                Frm_Ope_Recolecciones.Text = "Arqueo";
                Frm_Ope_Recolecciones.MdiParent = this;
                Frm_Ope_Recolecciones.Show();
            }
            else
            {
                if (Frm_Ope_Recolecciones.IsDisposed)
                {
                    Frm_Ope_Recolecciones = new Frm_Ope_Recolecciones();
                    Frm_Ope_Recolecciones.MdiParent = this;
                    Frm_Ope_Recolecciones.Text = "Arqueo";
                    Frm_Ope_Recolecciones.Show();
                }
                else
                {
                    Frm_Ope_Recolecciones.WindowState = FormWindowState.Normal;
                    Frm_Ope_Recolecciones.Text = "Arqueo";
                    Frm_Ope_Recolecciones.Activate();
                }
            }

            foreach (Control Controles in Frm_Ope_Recolecciones.Controls)
            {
                foreach (Control Objeto in Controles.Controls)
                {
                    foreach (Control Objeto_2 in Objeto.Controls)
                    {
                        if (((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Recoleccion"))
                            || ((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Cierre_Caja")))
                        {
                            Objeto_2.Visible = false;
                        }
                        if (((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Arqueo")))
                        {
                            RadioButton Opt_Arqueo = (RadioButton)Objeto_2;
                            Opt_Arqueo.Checked = true;
                        }
                        if ((Objeto_2 is TextBox) && (Objeto_2.Name == "Txt_Total_En_Caja"))
                        {
                            TextBox Txt_Total_Caja = (TextBox)Objeto_2;
                            Txt_Total_Caja.Visible = false;
                        }
                        if ((Objeto_2 is TextBox) && (Objeto_2.Name == "TXt_Resultado_Corte"))
                        {
                            TextBox TXt_Resultado_Corte = (TextBox)Objeto_2;
                            TXt_Resultado_Corte.Visible = false;
                        }
                    }
                }
            }

            recoleccionesToolStripMenuItem.Enabled = false;
            SubMenu_Operacion_Cierre_Caja.Enabled = false;

        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : SubMenu_Operacion_Cierre_Caja_Click
        ///DESCRIPCIÓN          : Habilita el menu de catalogo de recoleccion, modalidad cierre caja
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 30 Enero 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void SubMenu_Operacion_Cierre_Caja_Click(object sender, EventArgs e)
        {
            MDI_Frm_Apl_Principal.Opt_Arqueos = false;
            MDI_Frm_Apl_Principal.Opt_Recoleccion = false;
            MDI_Frm_Apl_Principal.Opt_Cierre = true;

            int Cont_Objetos = 0;
            if (Frm_Ope_Recolecciones == null)
            {
                Frm_Ope_Recolecciones = new Frm_Ope_Recolecciones();
                Frm_Ope_Recolecciones.MdiParent = this;
                Frm_Ope_Recolecciones.Text = "Cierre de caja";
                Frm_Ope_Recolecciones.Show();
            }
            else
            {
                if (Frm_Ope_Recolecciones.IsDisposed)
                {
                    Frm_Ope_Recolecciones = new Frm_Ope_Recolecciones();
                    Frm_Ope_Recolecciones.MdiParent = this;
                    Frm_Ope_Recolecciones.Text = "Cierre de caja";
                    Frm_Ope_Recolecciones.Show();
                }
                else
                {
                    Frm_Ope_Recolecciones.WindowState = FormWindowState.Normal; 
                    Frm_Ope_Recolecciones.Text = "Cierre de caja";
                    Frm_Ope_Recolecciones.Activate();
                }
            }

            foreach (Control Controles in Frm_Ope_Recolecciones.Controls)
            {
                foreach (Control Objeto in Controles.Controls)
                {
                    foreach (Control Objeto_2 in Objeto.Controls)
                    {
                        if (((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Recoleccion"))
                            || ((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Arqueo")))
                        {
                            Objeto_2.Visible = false;
                            Cont_Objetos++;
                            //Opt_Arqueo
                        }
                        if (((Objeto_2 is RadioButton) && (Objeto_2.Name == "Opt_Cierre_Caja")))
                        {
                            RadioButton Opt_Arqueo = (RadioButton)Objeto_2;
                            Opt_Arqueo.Checked = true;
                            Cont_Objetos++;
                        }
                        if (Cont_Objetos == 3)
                            break;
                    }
                    if (Cont_Objetos == 3)
                        break;
                }
                if (Cont_Objetos == 3)
                    break;
            }

            recoleccionesToolStripMenuItem.Enabled = false;
            SubMenu_Operacion_Arqueo.Enabled = false;
        }
        /// <summary>
        /// Sub_Menu_Catalogo_Padron_Click
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub_Menu_Catalogo_Padron_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Padron == null)
            {
                Frm_Cat_Padron = new Frm_Cat_Padron();
                Frm_Cat_Padron.MdiParent = this;
                Frm_Cat_Padron.Show();
            }
            else
            {
                if (Frm_Cat_Padron.IsDisposed)
                {
                    Frm_Cat_Padron = new Frm_Cat_Padron();
                    Frm_Cat_Padron.MdiParent = this;
                    Frm_Cat_Padron.Show();
                }
                else
                {
                    Frm_Cat_Padron.WindowState = FormWindowState.Normal;
                    Frm_Cat_Padron.Activate();
                }
            }
        }
        /// <summary>
        /// Sub_Menu_Operaciones_Exportar_Click
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub_Menu_Operaciones_Exportar_Click(object sender, EventArgs e)
        {
            if (Frm_Ope_Exportacion == null)
            {
                Frm_Ope_Exportacion = new Frm_Ope_Exportacion();
                Frm_Ope_Exportacion.MdiParent = this;
                Frm_Ope_Exportacion.Show();
            }
            else
            {
                if (Frm_Ope_Exportacion.IsDisposed)
                {
                    Frm_Ope_Exportacion = new Frm_Ope_Exportacion();
                    Frm_Ope_Exportacion.MdiParent = this;
                    Frm_Ope_Exportacion.Show();
                }
                else
                {
                    Frm_Ope_Exportacion.WindowState = FormWindowState.Normal;
                    Frm_Ope_Exportacion.Activate();
                }
            }
        }
        /// <summary>
        /// Sub_Menu_Operaciones_Facturacion_Click
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub_Menu_Operaciones_Facturacion_Click(object sender, EventArgs e)
        {
            if (Frm_Ope_Facturacion_Electronica == null)
            {
                Frm_Ope_Facturacion_Electronica = new Frm_Ope_Facturacion_Electronica();
                Frm_Ope_Facturacion_Electronica.MdiParent = this;
                Frm_Ope_Facturacion_Electronica.Show();
            }
            else
            {
                if (Frm_Ope_Facturacion_Electronica.IsDisposed)
                {
                    Frm_Ope_Facturacion_Electronica = new Frm_Ope_Facturacion_Electronica();
                    Frm_Ope_Facturacion_Electronica.MdiParent = this;
                    Frm_Ope_Facturacion_Electronica.Show();
                }
                else
                {
                    Frm_Ope_Facturacion_Electronica.WindowState = FormWindowState.Normal;
                    Frm_Ope_Facturacion_Electronica.Activate();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sub_Menu_Operaciones_Reimpresion_Accesos_Click(object sender, EventArgs e)
        {
            //
            if (Frm_Ope_Reimpresion_Accesos == null)
            {
                Frm_Ope_Reimpresion_Accesos = new Frm_Ope_Reimpresion_Accesos();
                Frm_Ope_Reimpresion_Accesos.MdiParent = this;
                Frm_Ope_Reimpresion_Accesos.Show();
            }
            else
            {
                if (Frm_Ope_Reimpresion_Accesos.IsDisposed)
                {
                    Frm_Ope_Reimpresion_Accesos = new Frm_Ope_Reimpresion_Accesos();
                    Frm_Ope_Reimpresion_Accesos.MdiParent = this;
                    Frm_Ope_Reimpresion_Accesos.Show();
                }
                else
                {
                    Frm_Ope_Reimpresion_Accesos.WindowState = FormWindowState.Normal;
                    Frm_Ope_Reimpresion_Accesos.Activate();
                }
            }

        }

        private void ventasPorInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm_Rpt_Ventas_Internet == null)
            {
                Frm_Rpt_Ventas_Internet = new Frm_Rpt_Ventas_Internet();
                Frm_Rpt_Ventas_Internet.MdiParent = this;
                Frm_Rpt_Ventas_Internet.Show();
            }
            else
            {
                if (Frm_Rpt_Ventas_Internet.IsDisposed)
                {
                    Frm_Rpt_Ventas_Internet = new Frm_Rpt_Ventas_Internet();
                    Frm_Rpt_Ventas_Internet.MdiParent = this;
                    Frm_Rpt_Ventas_Internet.Show();
                }
                else
                {
                    Frm_Rpt_Ventas_Internet.WindowState = FormWindowState.Normal;
                    Frm_Rpt_Ventas_Internet.Activate();
                }
            }
        }

        private void Sub_Menu_Catalogo_Listas_Click(object sender, EventArgs e)
        {
            if (Frm_Cat_Lista_Deudorcad == null)
            {
                Frm_Cat_Lista_Deudorcad = new Frm_Cat_Lista_Deudorcad();
                Frm_Cat_Lista_Deudorcad.MdiParent = this;
                Frm_Cat_Lista_Deudorcad.Show();
            }
            else
            {
                if (Frm_Cat_Lista_Deudorcad.IsDisposed)
                {
                    Frm_Cat_Lista_Deudorcad = new Frm_Cat_Lista_Deudorcad();
                    Frm_Cat_Lista_Deudorcad.MdiParent = this;
                    Frm_Cat_Lista_Deudorcad.Show();
                }
                else
                {
                    Frm_Cat_Lista_Deudorcad.WindowState = FormWindowState.Normal;
                    Frm_Cat_Lista_Deudorcad.Activate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tmr_Validador_Fecha_Tick(object sender, EventArgs e)
        {
            Cls_Apl_Registro_Accesos_Negocio Rs_Consulta = new Cls_Apl_Registro_Accesos_Negocio();
            DataTable Dt_Fecha = new DataTable();
            DateTime Dtim_Fecha_Servidor = new DateTime();
            DateTime Dtim_Fecha_Cliente = DateTime.Now;
            //DateTime Dtim_Fecha_Cliente = new DateTime(2016, 1, 1);

            try
            {
                Dt_Fecha = Rs_Consulta.Consultar_Fecha_Servidor();

                foreach (DataRow Registro in Dt_Fecha.Rows)
                {
                    Dtim_Fecha_Servidor = Convert.ToDateTime(Registro["Fecha_Servidor"].ToString());
                    //Dtim_Fecha_Servidor = new DateTime(2016, 1, 1);
                    ToolStrip_Validador_Fecha.Text = Dtim_Fecha_Servidor.ToShortDateString();
                }

                //  validamos la fecha del servidor vs cliente
                if (Dtim_Fecha_Servidor.Year == Dtim_Fecha_Cliente.Year
                    && Dtim_Fecha_Servidor.Month == Dtim_Fecha_Cliente.Month
                    && Dtim_Fecha_Servidor.Day == Dtim_Fecha_Cliente.Day)
                {
                    //  si son iguales se habilita la forma principal
                    this.Enabled = true;
                    ToolStrip_Validador_Fecha_Resultado.Text = "";
                }
                else
                {
                    //  si son iguales se bloquea la forma principal
                    this.Enabled = false;
                    ToolStrip_Validador_Fecha_Resultado.Text = "Fechas incorrectas"; 

                }

                Tmr_Validador_Fecha.Enabled = false;
            }
            catch (Exception Ex)
            {

            }

        }// fin de la funcion

    }
}