namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Productos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.Lbl_Tipo_Producto = new System.Windows.Forms.Label();
            this.Cmb_Tipo_Producto = new System.Windows.Forms.ComboBox();
            this.Lbl_Costo = new System.Windows.Forms.Label();
            this.Txt_Costo = new System.Windows.Forms.TextBox();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Pnl_Respuesta = new System.Windows.Forms.Panel();
            this.Cmb_Tipo_Servicio = new System.Windows.Forms.ComboBox();
            this.Lbl_Tipo_Servicio = new System.Windows.Forms.Label();
            this.Rdb_NO = new System.Windows.Forms.RadioButton();
            this.Rdb_SI = new System.Windows.Forms.RadioButton();
            this.Lbl_Impresion = new System.Windows.Forms.Label();
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Cmb_Categoria = new System.Windows.Forms.ComboBox();
            this.Lbl_Categoria = new System.Windows.Forms.Label();
            this.Cmb_Producto_Anterior = new System.Windows.Forms.ComboBox();
            this.Lbl_Producto_Anterior = new System.Windows.Forms.Label();
            this.Txt_Anio = new System.Windows.Forms.TextBox();
            this.Lbl_Anio = new System.Windows.Forms.Label();
            this.Chk_Web = new System.Windows.Forms.CheckBox();
            this.Lbl_Codigo = new System.Windows.Forms.Label();
            this.Txt_Codigo = new System.Windows.Forms.TextBox();
            this.Btn_Buscar_Imagen = new System.Windows.Forms.Button();
            this.Pic_Logo = new System.Windows.Forms.PictureBox();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Txt_ID_Producto = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Producto = new System.Windows.Forms.Label();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Grid_Productos = new System.Windows.Forms.DataGridView();
            this.Producto_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Valor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Web = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Relacion_Producto_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fra_Productos = new System.Windows.Forms.GroupBox();
            this.Ofd_Imagen = new System.Windows.Forms.OpenFileDialog();
            this.Sfd_Imagen = new System.Windows.Forms.SaveFileDialog();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Pnl_Respuesta.SuspendLayout();
            this.Fra_Datos_Generales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Productos)).BeginInit();
            this.Fra_Productos.SuspendLayout();
            this.Fra_Buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(595, 444);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(94, 51);
            this.Btn_Salir.TabIndex = 29;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(471, 444);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(93, 51);
            this.Btn_Eliminar.TabIndex = 28;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(345, 444);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(94, 51);
            this.Btn_Buscar.TabIndex = 27;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(228, 444);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(96, 51);
            this.Btn_Modificar.TabIndex = 26;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(109, 444);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(97, 51);
            this.Btn_Nuevo.TabIndex = 25;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Nombre.Location = new System.Drawing.Point(6, 48);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(55, 14);
            this.Lbl_Nombre.TabIndex = 6;
            this.Lbl_Nombre.Text = "*Nombre";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(100, 43);
            this.Txt_Nombre.MaxLength = 450;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(373, 22);
            this.Txt_Nombre.TabIndex = 1;
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Descripcion.Location = new System.Drawing.Point(6, 76);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(64, 14);
            this.Lbl_Descripcion.TabIndex = 18;
            this.Lbl_Descripcion.Text = "Descripción";
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion.Location = new System.Drawing.Point(100, 71);
            this.Txt_Descripcion.MaxLength = 500;
            this.Txt_Descripcion.Multiline = true;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.Size = new System.Drawing.Size(373, 33);
            this.Txt_Descripcion.TabIndex = 2;
            // 
            // Lbl_Tipo_Producto
            // 
            this.Lbl_Tipo_Producto.AutoSize = true;
            this.Lbl_Tipo_Producto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Tipo_Producto.Location = new System.Drawing.Point(6, 174);
            this.Lbl_Tipo_Producto.Name = "Lbl_Tipo_Producto";
            this.Lbl_Tipo_Producto.Size = new System.Drawing.Size(88, 14);
            this.Lbl_Tipo_Producto.TabIndex = 4;
            this.Lbl_Tipo_Producto.Text = "*Tipo Producto";
            // 
            // Cmb_Tipo_Producto
            // 
            this.Cmb_Tipo_Producto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo_Producto.FormattingEnabled = true;
            this.Cmb_Tipo_Producto.Items.AddRange(new object[] {
            "Producto",
            "Servicio"});
            this.Cmb_Tipo_Producto.Location = new System.Drawing.Point(100, 169);
            this.Cmb_Tipo_Producto.Name = "Cmb_Tipo_Producto";
            this.Cmb_Tipo_Producto.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Tipo_Producto.TabIndex = 3;
            this.Cmb_Tipo_Producto.SelectedIndexChanged += new System.EventHandler(this.Cmb_Tipo_Producto_SelectedIndexChanged);
            this.Cmb_Tipo_Producto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Tipo_Producto_KeyPress);
            // 
            // Lbl_Costo
            // 
            this.Lbl_Costo.AutoSize = true;
            this.Lbl_Costo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Costo.Location = new System.Drawing.Point(6, 204);
            this.Lbl_Costo.Name = "Lbl_Costo";
            this.Lbl_Costo.Size = new System.Drawing.Size(44, 14);
            this.Lbl_Costo.TabIndex = 26;
            this.Lbl_Costo.Text = "*Costo";
            // 
            // Txt_Costo
            // 
            this.Txt_Costo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Costo.Location = new System.Drawing.Point(100, 199);
            this.Txt_Costo.MaxLength = 50;
            this.Txt_Costo.Name = "Txt_Costo";
            this.Txt_Costo.Size = new System.Drawing.Size(140, 22);
            this.Txt_Costo.TabIndex = 4;
            this.Txt_Costo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_Costo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Costo_KeyPress);
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Estatus.Location = new System.Drawing.Point(6, 232);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 32;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Pnl_Respuesta
            // 
            this.Pnl_Respuesta.Controls.Add(this.Cmb_Tipo_Servicio);
            this.Pnl_Respuesta.Controls.Add(this.Lbl_Tipo_Servicio);
            this.Pnl_Respuesta.Controls.Add(this.Rdb_NO);
            this.Pnl_Respuesta.Controls.Add(this.Rdb_SI);
            this.Pnl_Respuesta.Controls.Add(this.Lbl_Impresion);
            this.Pnl_Respuesta.Location = new System.Drawing.Point(246, 169);
            this.Pnl_Respuesta.Name = "Pnl_Respuesta";
            this.Pnl_Respuesta.Size = new System.Drawing.Size(238, 54);
            this.Pnl_Respuesta.TabIndex = 46;
            this.Pnl_Respuesta.Visible = false;
            // 
            // Cmb_Tipo_Servicio
            // 
            this.Cmb_Tipo_Servicio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo_Servicio.FormattingEnabled = true;
            this.Cmb_Tipo_Servicio.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Tipo_Servicio.Location = new System.Drawing.Point(87, 25);
            this.Cmb_Tipo_Servicio.Name = "Cmb_Tipo_Servicio";
            this.Cmb_Tipo_Servicio.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Tipo_Servicio.TabIndex = 61;
            // 
            // Lbl_Tipo_Servicio
            // 
            this.Lbl_Tipo_Servicio.AutoSize = true;
            this.Lbl_Tipo_Servicio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Tipo_Servicio.Location = new System.Drawing.Point(9, 30);
            this.Lbl_Tipo_Servicio.Name = "Lbl_Tipo_Servicio";
            this.Lbl_Tipo_Servicio.Size = new System.Drawing.Size(78, 14);
            this.Lbl_Tipo_Servicio.TabIndex = 62;
            this.Lbl_Tipo_Servicio.Text = "Tipo Servicio";
            // 
            // Rdb_NO
            // 
            this.Rdb_NO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Rdb_NO.AutoSize = true;
            this.Rdb_NO.Location = new System.Drawing.Point(179, 1);
            this.Rdb_NO.Name = "Rdb_NO";
            this.Rdb_NO.Size = new System.Drawing.Size(42, 19);
            this.Rdb_NO.TabIndex = 1;
            this.Rdb_NO.TabStop = true;
            this.Rdb_NO.Text = "NO";
            this.Rdb_NO.UseVisualStyleBackColor = true;
            // 
            // Rdb_SI
            // 
            this.Rdb_SI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Rdb_SI.AutoSize = true;
            this.Rdb_SI.Location = new System.Drawing.Point(137, 1);
            this.Rdb_SI.Name = "Rdb_SI";
            this.Rdb_SI.Size = new System.Drawing.Size(36, 19);
            this.Rdb_SI.TabIndex = 0;
            this.Rdb_SI.TabStop = true;
            this.Rdb_SI.Text = "SI";
            this.Rdb_SI.UseVisualStyleBackColor = true;
            // 
            // Lbl_Impresion
            // 
            this.Lbl_Impresion.AutoSize = true;
            this.Lbl_Impresion.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Impresion.Location = new System.Drawing.Point(9, 8);
            this.Lbl_Impresion.Name = "Lbl_Impresion";
            this.Lbl_Impresion.Size = new System.Drawing.Size(64, 14);
            this.Lbl_Impresion.TabIndex = 59;
            this.Lbl_Impresion.Text = "Impresión";
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.button1);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Categoria);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Categoria);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Producto_Anterior);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Producto_Anterior);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Anio);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Anio);
            this.Fra_Datos_Generales.Controls.Add(this.Chk_Web);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Codigo);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Codigo);
            this.Fra_Datos_Generales.Controls.Add(this.Btn_Buscar_Imagen);
            this.Fra_Datos_Generales.Controls.Add(this.Pic_Logo);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_ID_Producto);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_ID_Producto);
            this.Fra_Datos_Generales.Controls.Add(this.Pnl_Respuesta);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Costo);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Costo);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Tipo_Producto);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Tipo_Producto);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Descripcion);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Descripcion);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Nombre);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Nombre);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(5, 6);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(782, 255);
            this.Fra_Datos_Generales.TabIndex = 31;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Cmb_Categoria
            // 
            this.Cmb_Categoria.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Categoria.FormattingEnabled = true;
            this.Cmb_Categoria.Location = new System.Drawing.Point(100, 139);
            this.Cmb_Categoria.Name = "Cmb_Categoria";
            this.Cmb_Categoria.Size = new System.Drawing.Size(334, 23);
            this.Cmb_Categoria.TabIndex = 70;
            // 
            // Lbl_Categoria
            // 
            this.Lbl_Categoria.AutoSize = true;
            this.Lbl_Categoria.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Categoria.Location = new System.Drawing.Point(7, 143);
            this.Lbl_Categoria.Name = "Lbl_Categoria";
            this.Lbl_Categoria.Size = new System.Drawing.Size(64, 14);
            this.Lbl_Categoria.TabIndex = 69;
            this.Lbl_Categoria.Text = "*Categoría";
            // 
            // Cmb_Producto_Anterior
            // 
            this.Cmb_Producto_Anterior.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Producto_Anterior.FormattingEnabled = true;
            this.Cmb_Producto_Anterior.Location = new System.Drawing.Point(100, 108);
            this.Cmb_Producto_Anterior.Name = "Cmb_Producto_Anterior";
            this.Cmb_Producto_Anterior.Size = new System.Drawing.Size(373, 23);
            this.Cmb_Producto_Anterior.TabIndex = 68;
            // 
            // Lbl_Producto_Anterior
            // 
            this.Lbl_Producto_Anterior.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Producto_Anterior.Location = new System.Drawing.Point(7, 102);
            this.Lbl_Producto_Anterior.Name = "Lbl_Producto_Anterior";
            this.Lbl_Producto_Anterior.Size = new System.Drawing.Size(88, 37);
            this.Lbl_Producto_Anterior.TabIndex = 67;
            this.Lbl_Producto_Anterior.Text = "* ¿A Que Producto corresponde el año anterior?";
            // 
            // Txt_Anio
            // 
            this.Txt_Anio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Anio.Location = new System.Drawing.Point(294, 15);
            this.Txt_Anio.MaxLength = 4;
            this.Txt_Anio.Name = "Txt_Anio";
            this.Txt_Anio.Size = new System.Drawing.Size(179, 22);
            this.Txt_Anio.TabIndex = 66;
            this.Txt_Anio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Costo_KeyPress);
            // 
            // Lbl_Anio
            // 
            this.Lbl_Anio.AutoSize = true;
            this.Lbl_Anio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Anio.Location = new System.Drawing.Point(255, 17);
            this.Lbl_Anio.Name = "Lbl_Anio";
            this.Lbl_Anio.Size = new System.Drawing.Size(33, 14);
            this.Lbl_Anio.TabIndex = 65;
            this.Lbl_Anio.Text = "*Año";
            // 
            // Chk_Web
            // 
            this.Chk_Web.AutoSize = true;
            this.Chk_Web.Location = new System.Drawing.Point(421, 230);
            this.Chk_Web.Name = "Chk_Web";
            this.Chk_Web.Size = new System.Drawing.Size(52, 19);
            this.Chk_Web.TabIndex = 64;
            this.Chk_Web.Text = "Web";
            this.Chk_Web.UseVisualStyleBackColor = true;
            // 
            // Lbl_Codigo
            // 
            this.Lbl_Codigo.AutoSize = true;
            this.Lbl_Codigo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Codigo.Location = new System.Drawing.Point(255, 234);
            this.Lbl_Codigo.Name = "Lbl_Codigo";
            this.Lbl_Codigo.Size = new System.Drawing.Size(46, 14);
            this.Lbl_Codigo.TabIndex = 63;
            this.Lbl_Codigo.Text = "Codigo";
            // 
            // Txt_Codigo
            // 
            this.Txt_Codigo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Codigo.Location = new System.Drawing.Point(333, 229);
            this.Txt_Codigo.MaxLength = 50;
            this.Txt_Codigo.Name = "Txt_Codigo";
            this.Txt_Codigo.Size = new System.Drawing.Size(73, 22);
            this.Txt_Codigo.TabIndex = 60;
            this.Txt_Codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Btn_Buscar_Imagen
            // 
            this.Btn_Buscar_Imagen.Location = new System.Drawing.Point(505, 160);
            this.Btn_Buscar_Imagen.Name = "Btn_Buscar_Imagen";
            this.Btn_Buscar_Imagen.Size = new System.Drawing.Size(253, 23);
            this.Btn_Buscar_Imagen.TabIndex = 57;
            this.Btn_Buscar_Imagen.Text = "Buscar Imagen";
            this.Btn_Buscar_Imagen.UseVisualStyleBackColor = true;
            this.Btn_Buscar_Imagen.Click += new System.EventHandler(this.Btn_Buscar_Imagen_Click);
            // 
            // Pic_Logo
            // 
            this.Pic_Logo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Pic_Logo.Location = new System.Drawing.Point(490, 36);
            this.Pic_Logo.Name = "Pic_Logo";
            this.Pic_Logo.Size = new System.Drawing.Size(286, 108);
            this.Pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pic_Logo.TabIndex = 58;
            this.Pic_Logo.TabStop = false;
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(100, 227);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Estatus.TabIndex = 49;
            this.Cmb_Estatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Estatus_KeyPress);
            // 
            // Txt_ID_Producto
            // 
            this.Txt_ID_Producto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Producto.Location = new System.Drawing.Point(100, 15);
            this.Txt_ID_Producto.MaxLength = 450;
            this.Txt_ID_Producto.Name = "Txt_ID_Producto";
            this.Txt_ID_Producto.Size = new System.Drawing.Size(140, 22);
            this.Txt_ID_Producto.TabIndex = 48;
            // 
            // Lbl_ID_Producto
            // 
            this.Lbl_ID_Producto.AutoSize = true;
            this.Lbl_ID_Producto.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Producto.Location = new System.Drawing.Point(7, 20);
            this.Lbl_ID_Producto.Name = "Lbl_ID_Producto";
            this.Lbl_ID_Producto.Size = new System.Drawing.Size(62, 14);
            this.Lbl_ID_Producto.TabIndex = 47;
            this.Lbl_ID_Producto.Text = "ID Producto";
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Grid_Productos
            // 
            this.Grid_Productos.AllowUserToAddRows = false;
            this.Grid_Productos.AllowUserToDeleteRows = false;
            this.Grid_Productos.AllowUserToResizeRows = false;
            this.Grid_Productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Productos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto_Id,
            this.Nombre,
            this.Descripcion,
            this.Tipo,
            this.Tipo_Valor,
            this.Costo,
            this.Estatus,
            this.Imagen,
            this.Web,
            this.Relacion_Producto_Id});
            this.Grid_Productos.Location = new System.Drawing.Point(10, 20);
            this.Grid_Productos.Name = "Grid_Productos";
            this.Grid_Productos.ReadOnly = true;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Productos.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.Grid_Productos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Productos.Size = new System.Drawing.Size(766, 145);
            this.Grid_Productos.TabIndex = 0;
            this.Grid_Productos.SelectionChanged += new System.EventHandler(this.Grid_Productos_SelectionChanged);
            // 
            // Producto_Id
            // 
            this.Producto_Id.DataPropertyName = "Producto_Id";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Producto_Id.DefaultCellStyle = dataGridViewCellStyle1;
            this.Producto_Id.HeaderText = "Id de Producto";
            this.Producto_Id.Name = "Producto_Id";
            this.Producto_Id.ReadOnly = true;
            this.Producto_Id.Width = 114;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 77;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tipo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 56;
            // 
            // Tipo_Valor
            // 
            this.Tipo_Valor.DataPropertyName = "Tipo_Valor";
            this.Tipo_Valor.HeaderText = "Impresión";
            this.Tipo_Valor.Name = "Tipo_Valor";
            this.Tipo_Valor.ReadOnly = true;
            this.Tipo_Valor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tipo_Valor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Tipo_Valor.Width = 89;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.Format = "C2";
            this.Costo.DefaultCellStyle = dataGridViewCellStyle5;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.Width = 65;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 75;
            // 
            // Imagen
            // 
            this.Imagen.DataPropertyName = "Ruta_Imagen";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Imagen.DefaultCellStyle = dataGridViewCellStyle7;
            this.Imagen.HeaderText = "Imagen";
            this.Imagen.Name = "Imagen";
            this.Imagen.ReadOnly = true;
            this.Imagen.Visible = false;
            this.Imagen.Width = 74;
            // 
            // Web
            // 
            this.Web.DataPropertyName = "Web";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Web.DefaultCellStyle = dataGridViewCellStyle8;
            this.Web.HeaderText = "Aparece en web";
            this.Web.Name = "Web";
            this.Web.ReadOnly = true;
            this.Web.Visible = false;
            this.Web.Width = 124;
            // 
            // Relacion_Producto_Id
            // 
            this.Relacion_Producto_Id.DataPropertyName = "Relacion_Producto_Id";
            this.Relacion_Producto_Id.HeaderText = "Relacion_Producto_Id";
            this.Relacion_Producto_Id.Name = "Relacion_Producto_Id";
            this.Relacion_Producto_Id.ReadOnly = true;
            this.Relacion_Producto_Id.Visible = false;
            this.Relacion_Producto_Id.Width = 157;
            // 
            // Fra_Productos
            // 
            this.Fra_Productos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Fra_Productos.Controls.Add(this.Grid_Productos);
            this.Fra_Productos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Productos.Location = new System.Drawing.Point(5, 267);
            this.Fra_Productos.Name = "Fra_Productos";
            this.Fra_Productos.Size = new System.Drawing.Size(782, 171);
            this.Fra_Productos.TabIndex = 24;
            this.Fra_Productos.TabStop = false;
            this.Fra_Productos.Text = "Productos";
            // 
            // Ofd_Imagen
            // 
            this.Ofd_Imagen.FileName = "openFileDialog1";
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(5, 6);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(473, 225);
            this.Fra_Buscar.TabIndex = 38;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(281, 127);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(77, 45);
            this.Btn_Regresar.TabIndex = 9;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(163, 127);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(77, 45);
            this.Btn_Busqueda.TabIndex = 8;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(100, 77);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(334, 20);
            this.Txt_Descripcion_Busqueda.TabIndex = 7;
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "Id de Producto",
            "Nombre",
            "Tipo",
            "Estatus"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(100, 35);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(334, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 6;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(6, 81);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(80, 15);
            this.Lbl_Descripcion_Busqueda.TabIndex = 2;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(7, 39);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 71;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_Cat_Productos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(794, 507);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Productos);
            this.Controls.Add(this.Fra_Buscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Productos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Frm_Cat_Productos_Load);
            this.Pnl_Respuesta.ResumeLayout(false);
            this.Pnl_Respuesta.PerformLayout();
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Productos)).EndInit();
            this.Fra_Productos.ResumeLayout(false);
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.Label Lbl_Tipo_Producto;
        private System.Windows.Forms.ComboBox Cmb_Tipo_Producto;
        private System.Windows.Forms.Label Lbl_Costo;
        private System.Windows.Forms.TextBox Txt_Costo;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.Panel Pnl_Respuesta;
        private System.Windows.Forms.RadioButton Rdb_NO;
        private System.Windows.Forms.RadioButton Rdb_SI;
        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.GroupBox Fra_Productos;
        private System.Windows.Forms.DataGridView Grid_Productos;
        private System.Windows.Forms.TextBox Txt_ID_Producto;
        private System.Windows.Forms.Label Lbl_ID_Producto;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.Button Btn_Buscar_Imagen;
        private System.Windows.Forms.PictureBox Pic_Logo;
        private System.Windows.Forms.OpenFileDialog Ofd_Imagen;
        private System.Windows.Forms.SaveFileDialog Sfd_Imagen;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Busqueda;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Codigo;
        private System.Windows.Forms.Label Lbl_Tipo_Servicio;
        private System.Windows.Forms.ComboBox Cmb_Tipo_Servicio;
        private System.Windows.Forms.TextBox Txt_Codigo;
        private System.Windows.Forms.Label Lbl_Impresion;
        private System.Windows.Forms.CheckBox Chk_Web;
        private System.Windows.Forms.TextBox Txt_Anio;
        private System.Windows.Forms.Label Lbl_Anio;
        private System.Windows.Forms.ComboBox Cmb_Producto_Anterior;
        private System.Windows.Forms.Label Lbl_Producto_Anterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tipo_Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Web;
        private System.Windows.Forms.DataGridViewTextBoxColumn Relacion_Producto_Id;
        private System.Windows.Forms.ComboBox Cmb_Categoria;
        private System.Windows.Forms.Label Lbl_Categoria;
        private System.Windows.Forms.Button button1;
    }
}