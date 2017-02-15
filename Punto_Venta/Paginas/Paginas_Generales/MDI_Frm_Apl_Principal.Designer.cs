using System;
using Erp.Helper;
namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class MDI_Frm_Apl_Principal
    {
        #region Variables
        //se declaran las variables publicas globales
        public static String Empleado_ID = "";
        public static String Nombre_Usuario = "";
        public static String Usuario_ID = "";
        public static String Rol_ID = "";
        public static String Area_ID = "";
        public static String Centro_Costo_ID = "";
        public static String Puesto_ID = "";
        public static String Ip = "";
        public static String Equipo = "";
        public static String Caja_ID = string.Empty;
        public static String Serie_Caja = string.Empty;
        public static String Nombre_Login = string.Empty;
        public static String Numero_Caja = string.Empty;
        public static String No_Caja = string.Empty;
        public static String Ruta_Plantilla_Crystal = @"../../Paginas/Plantillas_Crystal/";

        public static Boolean Opt_Arqueos;
        public static Boolean Opt_Recoleccion;
        public static Boolean Opt_Cierre;
        #endregion

     

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI_Frm_Apl_Principal));
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Estatus_Sistema = new System.Windows.Forms.StatusStrip();
            this.ToolStrip_Usuario_Logueado = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip_Fecha_Hora_Sistema = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip_Validador_Fecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip_Validador_Fecha_Resultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu_Archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Archivo_Registro = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Recuperar_Contrasenia = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Sub_Menu_Archivo_Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Cajas = new System.Windows.Forms.ToolStripMenuItem();
            this.VentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Operaciones_Reimpresion_Accesos = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenu_Cancelaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.retirosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recoleccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenu_Operacion_Arqueo = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenu_Operacion_Cierre_Caja = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Grupos = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Operaciones_Camaras = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Operaciones_Exportar = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Operaciones_Facturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Catalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Bancos = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Cajas = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogo_Padron = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogo_Listas = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogo_Camaras = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Dias_Feriados = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Impresoras = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Impresoras_Cajas = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Motivos_Cancelacion = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Motivos_Descuento = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Productos = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Turnos = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Formas_Pago = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogo_Parametros = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Catalogos_Terminales = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Sub_Menu_Catalogos_Seguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Sub_Menu_Cat_Generales_Usuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Sub_Menu_Cat_General_Roles = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Sub_Menu_Log = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Rpt_Ventas = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Reporte_Concentrado_Ventas = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Reporte_Log = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Detalle_Ventas = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Cortes_Caja_Arqueos = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Reporte_Diario_Recaudacion = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Reporte_Analisis_Mensual = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Reporte_Anual_Ingresos = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Folios_Cancelados = new System.Windows.Forms.ToolStripMenuItem();
            this.Sub_Menu_Concentrado_Accesos = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasPorInternetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tmr_Fecha_Hora_Sistema = new System.Windows.Forms.Timer(this.components);
            this.Tmr_Validador_Fecha = new System.Windows.Forms.Timer(this.components);
            this.Estatus_Sistema.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.newToolStripButton, "newToolStripButton");
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.openToolStripButton, "openToolStripButton");
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.saveToolStripButton, "saveToolStripButton");
            this.saveToolStripButton.Name = "saveToolStripButton";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.printToolStripButton, "printToolStripButton");
            this.printToolStripButton.Name = "printToolStripButton";
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.printPreviewToolStripButton, "printPreviewToolStripButton");
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.helpToolStripButton, "helpToolStripButton");
            this.helpToolStripButton.Name = "helpToolStripButton";
            // 
            // Estatus_Sistema
            // 
            this.Estatus_Sistema.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_Usuario_Logueado,
            this.ToolStrip_Fecha_Hora_Sistema,
            this.ToolStrip_Validador_Fecha,
            this.ToolStrip_Validador_Fecha_Resultado});
            resources.ApplyResources(this.Estatus_Sistema, "Estatus_Sistema");
            this.Estatus_Sistema.Name = "Estatus_Sistema";
            // 
            // ToolStrip_Usuario_Logueado
            // 
            this.ToolStrip_Usuario_Logueado.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStrip_Usuario_Logueado.Name = "ToolStrip_Usuario_Logueado";
            resources.ApplyResources(this.ToolStrip_Usuario_Logueado, "ToolStrip_Usuario_Logueado");
            // 
            // ToolStrip_Fecha_Hora_Sistema
            // 
            this.ToolStrip_Fecha_Hora_Sistema.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStrip_Fecha_Hora_Sistema.Name = "ToolStrip_Fecha_Hora_Sistema";
            resources.ApplyResources(this.ToolStrip_Fecha_Hora_Sistema, "ToolStrip_Fecha_Hora_Sistema");
            // 
            // ToolStrip_Validador_Fecha
            // 
            this.ToolStrip_Validador_Fecha.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ToolStrip_Validador_Fecha.Name = "ToolStrip_Validador_Fecha";
            resources.ApplyResources(this.ToolStrip_Validador_Fecha, "ToolStrip_Validador_Fecha");
            // 
            // ToolStrip_Validador_Fecha_Resultado
            // 
            this.ToolStrip_Validador_Fecha_Resultado.ActiveLinkColor = System.Drawing.Color.Red;
            this.ToolStrip_Validador_Fecha_Resultado.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            resources.ApplyResources(this.ToolStrip_Validador_Fecha_Resultado, "ToolStrip_Validador_Fecha_Resultado");
            this.ToolStrip_Validador_Fecha_Resultado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ToolStrip_Validador_Fecha_Resultado.Name = "ToolStrip_Validador_Fecha_Resultado";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Archivo,
            this.operacionesToolStripMenuItem,
            this.Menu_Catalogos,
            this.Menu_Reportes});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // Menu_Archivo
            // 
            this.Menu_Archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sub_Menu_Archivo_Registro,
            this.Sub_Menu_Recuperar_Contrasenia,
            this.toolStripSeparator3,
            this.Sub_Menu_Archivo_Salir});
            this.Menu_Archivo.Name = "Menu_Archivo";
            resources.ApplyResources(this.Menu_Archivo, "Menu_Archivo");
            this.Menu_Archivo.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // Sub_Menu_Archivo_Registro
            // 
            this.Sub_Menu_Archivo_Registro.Name = "Sub_Menu_Archivo_Registro";
            resources.ApplyResources(this.Sub_Menu_Archivo_Registro, "Sub_Menu_Archivo_Registro");
            this.Sub_Menu_Archivo_Registro.Click += new System.EventHandler(this.registroToolStripMenuItem_Click);
            // 
            // Sub_Menu_Recuperar_Contrasenia
            // 
            this.Sub_Menu_Recuperar_Contrasenia.Name = "Sub_Menu_Recuperar_Contrasenia";
            resources.ApplyResources(this.Sub_Menu_Recuperar_Contrasenia, "Sub_Menu_Recuperar_Contrasenia");
            this.Sub_Menu_Recuperar_Contrasenia.Click += new System.EventHandler(this.Sub_Menu_Recuperar_Contrasenia_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // Sub_Menu_Archivo_Salir
            // 
            this.Sub_Menu_Archivo_Salir.Name = "Sub_Menu_Archivo_Salir";
            resources.ApplyResources(this.Sub_Menu_Archivo_Salir, "Sub_Menu_Archivo_Salir");
            this.Sub_Menu_Archivo_Salir.Click += new System.EventHandler(this.Sub_Menu_Apl_Salir_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turnosToolStripMenuItem,
            this.Sub_Menu_Cajas,
            this.VentasToolStripMenuItem,
            this.Sub_Menu_Operaciones_Reimpresion_Accesos,
            this.SubMenu_Cancelaciones,
            this.retirosToolStripMenuItem,
            this.recoleccionesToolStripMenuItem,
            this.SubMenu_Operacion_Arqueo,
            this.SubMenu_Operacion_Cierre_Caja,
            this.Sub_Menu_Grupos,
            this.Sub_Menu_Operaciones_Camaras,
            this.Sub_Menu_Operaciones_Exportar,
            this.Sub_Menu_Operaciones_Facturacion});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            resources.ApplyResources(this.operacionesToolStripMenuItem, "operacionesToolStripMenuItem");
            // 
            // turnosToolStripMenuItem
            // 
            this.turnosToolStripMenuItem.Name = "turnosToolStripMenuItem";
            resources.ApplyResources(this.turnosToolStripMenuItem, "turnosToolStripMenuItem");
            this.turnosToolStripMenuItem.Click += new System.EventHandler(this.Sub_Menu_Ope_Turnos_Click);
            // 
            // Sub_Menu_Cajas
            // 
            this.Sub_Menu_Cajas.Name = "Sub_Menu_Cajas";
            resources.ApplyResources(this.Sub_Menu_Cajas, "Sub_Menu_Cajas");
            this.Sub_Menu_Cajas.Click += new System.EventHandler(this.Sub_Menu_Cajas_Click);
            // 
            // VentasToolStripMenuItem
            // 
            this.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem";
            resources.ApplyResources(this.VentasToolStripMenuItem, "VentasToolStripMenuItem");
            this.VentasToolStripMenuItem.Click += new System.EventHandler(this.Sub_Menu_Operaciones_Ventas_Click);
            // 
            // Sub_Menu_Operaciones_Reimpresion_Accesos
            // 
            this.Sub_Menu_Operaciones_Reimpresion_Accesos.Name = "Sub_Menu_Operaciones_Reimpresion_Accesos";
            resources.ApplyResources(this.Sub_Menu_Operaciones_Reimpresion_Accesos, "Sub_Menu_Operaciones_Reimpresion_Accesos");
            this.Sub_Menu_Operaciones_Reimpresion_Accesos.Click += new System.EventHandler(this.Sub_Menu_Operaciones_Reimpresion_Accesos_Click);
            // 
            // SubMenu_Cancelaciones
            // 
            this.SubMenu_Cancelaciones.Name = "SubMenu_Cancelaciones";
            resources.ApplyResources(this.SubMenu_Cancelaciones, "SubMenu_Cancelaciones");
            this.SubMenu_Cancelaciones.Click += new System.EventHandler(this.SubMenu_Cancelaciones_Click);
            // 
            // retirosToolStripMenuItem
            // 
            this.retirosToolStripMenuItem.Name = "retirosToolStripMenuItem";
            resources.ApplyResources(this.retirosToolStripMenuItem, "retirosToolStripMenuItem");
            this.retirosToolStripMenuItem.Click += new System.EventHandler(this.Sub_Menu_Retiros_Click);
            // 
            // recoleccionesToolStripMenuItem
            // 
            this.recoleccionesToolStripMenuItem.Name = "recoleccionesToolStripMenuItem";
            resources.ApplyResources(this.recoleccionesToolStripMenuItem, "recoleccionesToolStripMenuItem");
            this.recoleccionesToolStripMenuItem.Click += new System.EventHandler(this.Sub_Menu_Recplecciones_Click);
            // 
            // SubMenu_Operacion_Arqueo
            // 
            this.SubMenu_Operacion_Arqueo.Name = "SubMenu_Operacion_Arqueo";
            resources.ApplyResources(this.SubMenu_Operacion_Arqueo, "SubMenu_Operacion_Arqueo");
            this.SubMenu_Operacion_Arqueo.Click += new System.EventHandler(this.SubMenu_Operacion_Arqueo_Click);
            // 
            // SubMenu_Operacion_Cierre_Caja
            // 
            this.SubMenu_Operacion_Cierre_Caja.Name = "SubMenu_Operacion_Cierre_Caja";
            resources.ApplyResources(this.SubMenu_Operacion_Cierre_Caja, "SubMenu_Operacion_Cierre_Caja");
            this.SubMenu_Operacion_Cierre_Caja.Click += new System.EventHandler(this.SubMenu_Operacion_Cierre_Caja_Click);
            // 
            // Sub_Menu_Grupos
            // 
            this.Sub_Menu_Grupos.Name = "Sub_Menu_Grupos";
            resources.ApplyResources(this.Sub_Menu_Grupos, "Sub_Menu_Grupos");
            this.Sub_Menu_Grupos.Click += new System.EventHandler(this.Sub_Menu_Grupos_Click);
            // 
            // Sub_Menu_Operaciones_Camaras
            // 
            this.Sub_Menu_Operaciones_Camaras.Name = "Sub_Menu_Operaciones_Camaras";
            resources.ApplyResources(this.Sub_Menu_Operaciones_Camaras, "Sub_Menu_Operaciones_Camaras");
            this.Sub_Menu_Operaciones_Camaras.Click += new System.EventHandler(this.Sub_Menu_Operaciones_Camaras_Click);
            // 
            // Sub_Menu_Operaciones_Exportar
            // 
            this.Sub_Menu_Operaciones_Exportar.Name = "Sub_Menu_Operaciones_Exportar";
            resources.ApplyResources(this.Sub_Menu_Operaciones_Exportar, "Sub_Menu_Operaciones_Exportar");
            this.Sub_Menu_Operaciones_Exportar.Click += new System.EventHandler(this.Sub_Menu_Operaciones_Exportar_Click);
            // 
            // Sub_Menu_Operaciones_Facturacion
            // 
            this.Sub_Menu_Operaciones_Facturacion.Name = "Sub_Menu_Operaciones_Facturacion";
            resources.ApplyResources(this.Sub_Menu_Operaciones_Facturacion, "Sub_Menu_Operaciones_Facturacion");
            this.Sub_Menu_Operaciones_Facturacion.Click += new System.EventHandler(this.Sub_Menu_Operaciones_Facturacion_Click);
            // 
            // Menu_Catalogos
            // 
            this.Menu_Catalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sub_Menu_Catalogos_Bancos,
            this.Sub_Menu_Catalogos_Cajas,
            this.Sub_Menu_Catalogo_Padron,
            this.Sub_Menu_Catalogo_Listas,
            this.Sub_Menu_Catalogo_Camaras,
            this.Sub_Menu_Catalogos_Dias_Feriados,
            this.Sub_Menu_Catalogos_Impresoras,
            this.Sub_Menu_Catalogos_Impresoras_Cajas,
            this.Sub_Menu_Catalogos_Motivos_Cancelacion,
            this.Sub_Menu_Catalogos_Motivos_Descuento,
            this.Sub_Menu_Catalogos_Productos,
            this.Sub_Menu_Catalogos_Turnos,
            this.Sub_Menu_Catalogos_Formas_Pago,
            this.Sub_Menu_Catalogo_Parametros,
            this.Sub_Menu_Catalogos_Terminales,
            this.toolStripSeparator4,
            this.Sub_Menu_Catalogos_Seguridad});
            this.Menu_Catalogos.Name = "Menu_Catalogos";
            resources.ApplyResources(this.Menu_Catalogos, "Menu_Catalogos");
            // 
            // Sub_Menu_Catalogos_Bancos
            // 
            this.Sub_Menu_Catalogos_Bancos.Name = "Sub_Menu_Catalogos_Bancos";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Bancos, "Sub_Menu_Catalogos_Bancos");
            this.Sub_Menu_Catalogos_Bancos.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Bancos_Click);
            // 
            // Sub_Menu_Catalogos_Cajas
            // 
            this.Sub_Menu_Catalogos_Cajas.Name = "Sub_Menu_Catalogos_Cajas";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Cajas, "Sub_Menu_Catalogos_Cajas");
            this.Sub_Menu_Catalogos_Cajas.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Cajas_Click);
            // 
            // Sub_Menu_Catalogo_Padron
            // 
            this.Sub_Menu_Catalogo_Padron.Name = "Sub_Menu_Catalogo_Padron";
            resources.ApplyResources(this.Sub_Menu_Catalogo_Padron, "Sub_Menu_Catalogo_Padron");
            this.Sub_Menu_Catalogo_Padron.Click += new System.EventHandler(this.Sub_Menu_Catalogo_Padron_Click);
            // 
            // Sub_Menu_Catalogo_Listas
            // 
            this.Sub_Menu_Catalogo_Listas.Name = "Sub_Menu_Catalogo_Listas";
            resources.ApplyResources(this.Sub_Menu_Catalogo_Listas, "Sub_Menu_Catalogo_Listas");
            this.Sub_Menu_Catalogo_Listas.Click += new System.EventHandler(this.Sub_Menu_Catalogo_Listas_Click);
            // 
            // Sub_Menu_Catalogo_Camaras
            // 
            this.Sub_Menu_Catalogo_Camaras.Name = "Sub_Menu_Catalogo_Camaras";
            resources.ApplyResources(this.Sub_Menu_Catalogo_Camaras, "Sub_Menu_Catalogo_Camaras");
            this.Sub_Menu_Catalogo_Camaras.Click += new System.EventHandler(this.Sub_Menu_Catalogo_Camaras_Click);
            // 
            // Sub_Menu_Catalogos_Dias_Feriados
            // 
            this.Sub_Menu_Catalogos_Dias_Feriados.Name = "Sub_Menu_Catalogos_Dias_Feriados";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Dias_Feriados, "Sub_Menu_Catalogos_Dias_Feriados");
            this.Sub_Menu_Catalogos_Dias_Feriados.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Dias_Feriados_Click);
            // 
            // Sub_Menu_Catalogos_Impresoras
            // 
            this.Sub_Menu_Catalogos_Impresoras.Name = "Sub_Menu_Catalogos_Impresoras";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Impresoras, "Sub_Menu_Catalogos_Impresoras");
            this.Sub_Menu_Catalogos_Impresoras.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Impresoras_Click);
            // 
            // Sub_Menu_Catalogos_Impresoras_Cajas
            // 
            this.Sub_Menu_Catalogos_Impresoras_Cajas.Name = "Sub_Menu_Catalogos_Impresoras_Cajas";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Impresoras_Cajas, "Sub_Menu_Catalogos_Impresoras_Cajas");
            this.Sub_Menu_Catalogos_Impresoras_Cajas.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Impresoras_Cajas_Click);
            // 
            // Sub_Menu_Catalogos_Motivos_Cancelacion
            // 
            this.Sub_Menu_Catalogos_Motivos_Cancelacion.Name = "Sub_Menu_Catalogos_Motivos_Cancelacion";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Motivos_Cancelacion, "Sub_Menu_Catalogos_Motivos_Cancelacion");
            this.Sub_Menu_Catalogos_Motivos_Cancelacion.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Motivos_Cancelacion_Click);
            // 
            // Sub_Menu_Catalogos_Motivos_Descuento
            // 
            this.Sub_Menu_Catalogos_Motivos_Descuento.Name = "Sub_Menu_Catalogos_Motivos_Descuento";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Motivos_Descuento, "Sub_Menu_Catalogos_Motivos_Descuento");
            this.Sub_Menu_Catalogos_Motivos_Descuento.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Motivos_Descuento_Click);
            // 
            // Sub_Menu_Catalogos_Productos
            // 
            this.Sub_Menu_Catalogos_Productos.Name = "Sub_Menu_Catalogos_Productos";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Productos, "Sub_Menu_Catalogos_Productos");
            this.Sub_Menu_Catalogos_Productos.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Productos_Click);
            // 
            // Sub_Menu_Catalogos_Turnos
            // 
            this.Sub_Menu_Catalogos_Turnos.Name = "Sub_Menu_Catalogos_Turnos";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Turnos, "Sub_Menu_Catalogos_Turnos");
            this.Sub_Menu_Catalogos_Turnos.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Turnos_Click);
            // 
            // Sub_Menu_Catalogos_Formas_Pago
            // 
            this.Sub_Menu_Catalogos_Formas_Pago.Name = "Sub_Menu_Catalogos_Formas_Pago";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Formas_Pago, "Sub_Menu_Catalogos_Formas_Pago");
            this.Sub_Menu_Catalogos_Formas_Pago.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Formas_Pago_Click);
            // 
            // Sub_Menu_Catalogo_Parametros
            // 
            this.Sub_Menu_Catalogo_Parametros.Name = "Sub_Menu_Catalogo_Parametros";
            resources.ApplyResources(this.Sub_Menu_Catalogo_Parametros, "Sub_Menu_Catalogo_Parametros");
            this.Sub_Menu_Catalogo_Parametros.Click += new System.EventHandler(this.Sub_Menu_Catalogo_Parametros_Click);
            // 
            // Sub_Menu_Catalogos_Terminales
            // 
            this.Sub_Menu_Catalogos_Terminales.Name = "Sub_Menu_Catalogos_Terminales";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Terminales, "Sub_Menu_Catalogos_Terminales");
            this.Sub_Menu_Catalogos_Terminales.Click += new System.EventHandler(this.Sub_Menu_Catalogos_Terminales_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // Sub_Menu_Catalogos_Seguridad
            // 
            this.Sub_Menu_Catalogos_Seguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sub_Sub_Menu_Cat_Generales_Usuarios,
            this.Sub_Sub_Menu_Cat_General_Roles,
            this.Sub_Sub_Menu_Log});
            this.Sub_Menu_Catalogos_Seguridad.Name = "Sub_Menu_Catalogos_Seguridad";
            resources.ApplyResources(this.Sub_Menu_Catalogos_Seguridad, "Sub_Menu_Catalogos_Seguridad");
            // 
            // Sub_Sub_Menu_Cat_Generales_Usuarios
            // 
            this.Sub_Sub_Menu_Cat_Generales_Usuarios.Name = "Sub_Sub_Menu_Cat_Generales_Usuarios";
            resources.ApplyResources(this.Sub_Sub_Menu_Cat_Generales_Usuarios, "Sub_Sub_Menu_Cat_Generales_Usuarios");
            this.Sub_Sub_Menu_Cat_Generales_Usuarios.Click += new System.EventHandler(this.Sub_Sub_Menu_Cat_Generales_Usuarios_Click);
            // 
            // Sub_Sub_Menu_Cat_General_Roles
            // 
            this.Sub_Sub_Menu_Cat_General_Roles.Name = "Sub_Sub_Menu_Cat_General_Roles";
            resources.ApplyResources(this.Sub_Sub_Menu_Cat_General_Roles, "Sub_Sub_Menu_Cat_General_Roles");
            this.Sub_Sub_Menu_Cat_General_Roles.Click += new System.EventHandler(this.Sub_Sub_Menu_Cat_General_Roles_Click);
            // 
            // Sub_Sub_Menu_Log
            // 
            this.Sub_Sub_Menu_Log.Name = "Sub_Sub_Menu_Log";
            resources.ApplyResources(this.Sub_Sub_Menu_Log, "Sub_Sub_Menu_Log");
            this.Sub_Sub_Menu_Log.Click += new System.EventHandler(this.Sub_Sub_Menu_Log_Click);
            // 
            // Menu_Reportes
            // 
            this.Menu_Reportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sub_Menu_Rpt_Ventas,
            this.Sub_Menu_Reporte_Concentrado_Ventas,
            this.Sub_Menu_Reporte_Log,
            this.Sub_Menu_Detalle_Ventas,
            this.Sub_Menu_Cortes_Caja_Arqueos,
            this.Sub_Menu_Reporte_Diario_Recaudacion,
            this.Sub_Menu_Reporte_Analisis_Mensual,
            this.Sub_Menu_Reporte_Anual_Ingresos,
            this.Sub_Menu_Folios_Cancelados,
            this.Sub_Menu_Concentrado_Accesos,
            this.ventasPorInternetToolStripMenuItem});
            this.Menu_Reportes.Name = "Menu_Reportes";
            resources.ApplyResources(this.Menu_Reportes, "Menu_Reportes");
            // 
            // Sub_Menu_Rpt_Ventas
            // 
            this.Sub_Menu_Rpt_Ventas.Name = "Sub_Menu_Rpt_Ventas";
            resources.ApplyResources(this.Sub_Menu_Rpt_Ventas, "Sub_Menu_Rpt_Ventas");
            this.Sub_Menu_Rpt_Ventas.Click += new System.EventHandler(this.Sub_Menu_Rpt_Ventas_Click);
            // 
            // Sub_Menu_Reporte_Concentrado_Ventas
            // 
            this.Sub_Menu_Reporte_Concentrado_Ventas.Name = "Sub_Menu_Reporte_Concentrado_Ventas";
            resources.ApplyResources(this.Sub_Menu_Reporte_Concentrado_Ventas, "Sub_Menu_Reporte_Concentrado_Ventas");
            this.Sub_Menu_Reporte_Concentrado_Ventas.Click += new System.EventHandler(this.Sub_Menu_Reporte_Concentrado_Ventas_Click);
            // 
            // Sub_Menu_Reporte_Log
            // 
            this.Sub_Menu_Reporte_Log.Name = "Sub_Menu_Reporte_Log";
            resources.ApplyResources(this.Sub_Menu_Reporte_Log, "Sub_Menu_Reporte_Log");
            this.Sub_Menu_Reporte_Log.Click += new System.EventHandler(this.Sub_Menu_Reporte_Log_Click);
            // 
            // Sub_Menu_Detalle_Ventas
            // 
            this.Sub_Menu_Detalle_Ventas.Name = "Sub_Menu_Detalle_Ventas";
            resources.ApplyResources(this.Sub_Menu_Detalle_Ventas, "Sub_Menu_Detalle_Ventas");
            this.Sub_Menu_Detalle_Ventas.Click += new System.EventHandler(this.Sub_Menu_Detalle_Ventas_Click);
            // 
            // Sub_Menu_Cortes_Caja_Arqueos
            // 
            this.Sub_Menu_Cortes_Caja_Arqueos.Name = "Sub_Menu_Cortes_Caja_Arqueos";
            resources.ApplyResources(this.Sub_Menu_Cortes_Caja_Arqueos, "Sub_Menu_Cortes_Caja_Arqueos");
            this.Sub_Menu_Cortes_Caja_Arqueos.Click += new System.EventHandler(this.Sub_Menu_Cortes_Caja_Arqueos_Click);
            // 
            // Sub_Menu_Reporte_Diario_Recaudacion
            // 
            this.Sub_Menu_Reporte_Diario_Recaudacion.Name = "Sub_Menu_Reporte_Diario_Recaudacion";
            resources.ApplyResources(this.Sub_Menu_Reporte_Diario_Recaudacion, "Sub_Menu_Reporte_Diario_Recaudacion");
            this.Sub_Menu_Reporte_Diario_Recaudacion.Click += new System.EventHandler(this.Sub_Menu_Reporte_Diario_Recaudacion_Click);
            // 
            // Sub_Menu_Reporte_Analisis_Mensual
            // 
            this.Sub_Menu_Reporte_Analisis_Mensual.Name = "Sub_Menu_Reporte_Analisis_Mensual";
            resources.ApplyResources(this.Sub_Menu_Reporte_Analisis_Mensual, "Sub_Menu_Reporte_Analisis_Mensual");
            this.Sub_Menu_Reporte_Analisis_Mensual.Click += new System.EventHandler(this.Sub_Menu_Reporte_Analisis_Mensual_Click);
            // 
            // Sub_Menu_Reporte_Anual_Ingresos
            // 
            this.Sub_Menu_Reporte_Anual_Ingresos.Name = "Sub_Menu_Reporte_Anual_Ingresos";
            resources.ApplyResources(this.Sub_Menu_Reporte_Anual_Ingresos, "Sub_Menu_Reporte_Anual_Ingresos");
            this.Sub_Menu_Reporte_Anual_Ingresos.Click += new System.EventHandler(this.Sub_Menu_Reporte_Anual_Ingresos_Click);
            // 
            // Sub_Menu_Folios_Cancelados
            // 
            this.Sub_Menu_Folios_Cancelados.Name = "Sub_Menu_Folios_Cancelados";
            resources.ApplyResources(this.Sub_Menu_Folios_Cancelados, "Sub_Menu_Folios_Cancelados");
            this.Sub_Menu_Folios_Cancelados.Click += new System.EventHandler(this.Sub_Menu_Folios_Cancelados_Click);
            // 
            // Sub_Menu_Concentrado_Accesos
            // 
            this.Sub_Menu_Concentrado_Accesos.Name = "Sub_Menu_Concentrado_Accesos";
            resources.ApplyResources(this.Sub_Menu_Concentrado_Accesos, "Sub_Menu_Concentrado_Accesos");
            this.Sub_Menu_Concentrado_Accesos.Click += new System.EventHandler(this.Sub_Menu_Concentrado_Accesos_Click);
            // 
            // ventasPorInternetToolStripMenuItem
            // 
            this.ventasPorInternetToolStripMenuItem.Name = "ventasPorInternetToolStripMenuItem";
            resources.ApplyResources(this.ventasPorInternetToolStripMenuItem, "ventasPorInternetToolStripMenuItem");
            this.ventasPorInternetToolStripMenuItem.Click += new System.EventHandler(this.ventasPorInternetToolStripMenuItem_Click);
            // 
            // Tmr_Fecha_Hora_Sistema
            // 
            this.Tmr_Fecha_Hora_Sistema.Enabled = true;
            this.Tmr_Fecha_Hora_Sistema.Interval = 1000;
            this.Tmr_Fecha_Hora_Sistema.Tick += new System.EventHandler(this.Tmr_Fecha_Hora_Sistema_Tick);
            // 
            // Tmr_Validador_Fecha
            // 
            this.Tmr_Validador_Fecha.Enabled = true;
            this.Tmr_Validador_Fecha.Interval = 1000;
            this.Tmr_Validador_Fecha.Tick += new System.EventHandler(this.Tmr_Validador_Fecha_Tick);
            // 
            // MDI_Frm_Apl_Principal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Estatus_Sistema);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDI_Frm_Apl_Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDI_Frm_Apl_Principal_FormClosed);
            this.Load += new System.EventHandler(this.MDI_Frm_Apl_Principal_Load);
            this.Estatus_Sistema.ResumeLayout(false);
            this.Estatus_Sistema.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip Estatus_Sistema;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;

        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Conexion_Inicial
        //DESCRIPCIÓN: Inicia la sesion del helper y abre la conexion
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 20/Febrero/2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        public static void Conexion_Inicial(Boolean Conectar){
            try
            {
                if (Conectar)
                {
                    Conexion.Iniciar_Helper();
                    Conexion.HelperGenerico.Conexion_y_Apertura();
                }
                else
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                    Conexion.Finalizar_Sesion();
                }
            }
            catch
            {
               
            }
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_Archivo;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Archivo_Registro;
        private System.Windows.Forms.ToolStripMenuItem Menu_Catalogos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Seguridad;
        private System.Windows.Forms.ToolStripMenuItem Sub_Sub_Menu_Cat_General_Roles;
        private System.Windows.Forms.ToolStripStatusLabel ToolStrip_Usuario_Logueado;
        private System.Windows.Forms.ToolStripMenuItem Sub_Sub_Menu_Cat_Generales_Usuarios;
        private System.Windows.Forms.ToolStripStatusLabel ToolStrip_Fecha_Hora_Sistema;
        public System.Windows.Forms.Timer Tmr_Fecha_Hora_Sistema;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Archivo_Salir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogo_Parametros;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Recuperar_Contrasenia;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retirosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Productos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Cajas;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Turnos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Formas_Pago;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Bancos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Dias_Feriados;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Impresoras;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Motivos_Cancelacion;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Motivos_Descuento;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Terminales;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Cajas;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Grupos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogos_Impresoras_Cajas;
        private System.Windows.Forms.ToolStripMenuItem SubMenu_Cancelaciones;
        private System.Windows.Forms.ToolStripMenuItem Menu_Reportes;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Rpt_Ventas;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Reporte_Concentrado_Ventas;
        private System.Windows.Forms.ToolStripMenuItem Sub_Sub_Menu_Log;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Reporte_Log;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Detalle_Ventas;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Cortes_Caja_Arqueos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Reporte_Diario_Recaudacion;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Reporte_Analisis_Mensual;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Reporte_Anual_Ingresos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Folios_Cancelados;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Concentrado_Accesos;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogo_Camaras;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Operaciones_Camaras;
        public System.Windows.Forms.ToolStripMenuItem recoleccionesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem SubMenu_Operacion_Arqueo;
        public System.Windows.Forms.ToolStripMenuItem SubMenu_Operacion_Cierre_Caja;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogo_Padron;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Operaciones_Exportar;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Operaciones_Facturacion;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Operaciones_Reimpresion_Accesos;
        private System.Windows.Forms.ToolStripMenuItem ventasPorInternetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Sub_Menu_Catalogo_Listas;
        private System.Windows.Forms.Timer Tmr_Validador_Fecha;
        private System.Windows.Forms.ToolStripStatusLabel ToolStrip_Validador_Fecha;
        private System.Windows.Forms.ToolStripStatusLabel ToolStrip_Validador_Fecha_Resultado;
    }
}



