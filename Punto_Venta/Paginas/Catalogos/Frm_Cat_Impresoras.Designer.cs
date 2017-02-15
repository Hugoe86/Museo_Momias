namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Impresoras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Impresoras));
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Txt_Comentarios = new System.Windows.Forms.TextBox();
            this.Lbl_Comentarios = new System.Windows.Forms.Label();
            this.Lbl_Ubicacion = new System.Windows.Forms.Label();
            this.Txt_Ubicacion = new System.Windows.Forms.TextBox();
            this.Txt_ID_Impresora = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Impresora = new System.Windows.Forms.Label();
            this.Txt_Ip = new System.Windows.Forms.TextBox();
            this.Lbl_Ip = new System.Windows.Forms.Label();
            this.Txt_Nombre_Impresora = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre_Impresora = new System.Windows.Forms.Label();
            this.Fra_Impresoras = new System.Windows.Forms.GroupBox();
            this.Grid_Impresoras = new System.Windows.Forms.DataGridView();
            this.Impresora_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Impresora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Buscar.SuspendLayout();
            this.Fra_Impresoras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Impresoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Fra_Buscar);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Ubicacion);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Ubicacion);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_ID_Impresora);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_ID_Impresora);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Ip);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Ip);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Nombre_Impresora);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Nombre_Impresora);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(6, 12);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(552, 233);
            this.Fra_Datos_Generales.TabIndex = 1;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(1, 0);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(556, 233);
            this.Fra_Buscar.TabIndex = 40;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Busqueda";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(276, 117);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(79, 45);
            this.Btn_Regresar.TabIndex = 14;
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
            this.Btn_Busqueda.Location = new System.Drawing.Point(168, 117);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(79, 45);
            this.Btn_Busqueda.TabIndex = 13;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(348, 36);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(190, 26);
            this.Txt_Descripcion_Busqueda.TabIndex = 12;
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(262, 40);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(80, 15);
            this.Lbl_Descripcion_Busqueda.TabIndex = 10;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "Id Impresora",
            "Nombre de la impresora",
            "Ip",
            "Ubicación",
            "Comentarios"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(95, 36);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(165, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 11;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(14, 40);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda.TabIndex = 8;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Txt_Comentarios
            // 
            this.Txt_Comentarios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Comentarios.Location = new System.Drawing.Point(151, 172);
            this.Txt_Comentarios.MaxLength = 255;
            this.Txt_Comentarios.Multiline = true;
            this.Txt_Comentarios.Name = "Txt_Comentarios";
            this.Txt_Comentarios.Size = new System.Drawing.Size(279, 43);
            this.Txt_Comentarios.TabIndex = 5;
            // 
            // Lbl_Comentarios
            // 
            this.Lbl_Comentarios.AutoSize = true;
            this.Lbl_Comentarios.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Comentarios.Location = new System.Drawing.Point(29, 177);
            this.Lbl_Comentarios.Name = "Lbl_Comentarios";
            this.Lbl_Comentarios.Size = new System.Drawing.Size(67, 14);
            this.Lbl_Comentarios.TabIndex = 60;
            this.Lbl_Comentarios.Text = "Comentarios";
            // 
            // Lbl_Ubicacion
            // 
            this.Lbl_Ubicacion.AutoSize = true;
            this.Lbl_Ubicacion.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Ubicacion.Location = new System.Drawing.Point(29, 136);
            this.Lbl_Ubicacion.Name = "Lbl_Ubicacion";
            this.Lbl_Ubicacion.Size = new System.Drawing.Size(54, 14);
            this.Lbl_Ubicacion.TabIndex = 59;
            this.Lbl_Ubicacion.Text = "Ubicación";
            // 
            // Txt_Ubicacion
            // 
            this.Txt_Ubicacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Ubicacion.Location = new System.Drawing.Point(151, 131);
            this.Txt_Ubicacion.MaxLength = 50;
            this.Txt_Ubicacion.Name = "Txt_Ubicacion";
            this.Txt_Ubicacion.Size = new System.Drawing.Size(279, 22);
            this.Txt_Ubicacion.TabIndex = 4;
            // 
            // Txt_ID_Impresora
            // 
            this.Txt_ID_Impresora.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Impresora.Location = new System.Drawing.Point(151, 17);
            this.Txt_ID_Impresora.MaxLength = 5;
            this.Txt_ID_Impresora.Name = "Txt_ID_Impresora";
            this.Txt_ID_Impresora.Size = new System.Drawing.Size(140, 22);
            this.Txt_ID_Impresora.TabIndex = 1;
            // 
            // Lbl_ID_Impresora
            // 
            this.Lbl_ID_Impresora.AutoSize = true;
            this.Lbl_ID_Impresora.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Impresora.Location = new System.Drawing.Point(29, 22);
            this.Lbl_ID_Impresora.Name = "Lbl_ID_Impresora";
            this.Lbl_ID_Impresora.Size = new System.Drawing.Size(67, 14);
            this.Lbl_ID_Impresora.TabIndex = 55;
            this.Lbl_ID_Impresora.Text = "ID Impresora";
            // 
            // Txt_Ip
            // 
            this.Txt_Ip.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Ip.Location = new System.Drawing.Point(151, 94);
            this.Txt_Ip.MaxLength = 50;
            this.Txt_Ip.Name = "Txt_Ip";
            this.Txt_Ip.Size = new System.Drawing.Size(140, 22);
            this.Txt_Ip.TabIndex = 3;
            // 
            // Lbl_Ip
            // 
            this.Lbl_Ip.AutoSize = true;
            this.Lbl_Ip.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Ip.Location = new System.Drawing.Point(29, 99);
            this.Lbl_Ip.Name = "Lbl_Ip";
            this.Lbl_Ip.Size = new System.Drawing.Size(15, 14);
            this.Lbl_Ip.TabIndex = 53;
            this.Lbl_Ip.Text = "Ip";
            // 
            // Txt_Nombre_Impresora
            // 
            this.Txt_Nombre_Impresora.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre_Impresora.Location = new System.Drawing.Point(151, 55);
            this.Txt_Nombre_Impresora.MaxLength = 50;
            this.Txt_Nombre_Impresora.Name = "Txt_Nombre_Impresora";
            this.Txt_Nombre_Impresora.Size = new System.Drawing.Size(279, 22);
            this.Txt_Nombre_Impresora.TabIndex = 2;
            // 
            // Lbl_Nombre_Impresora
            // 
            this.Lbl_Nombre_Impresora.AutoSize = true;
            this.Lbl_Nombre_Impresora.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Nombre_Impresora.Location = new System.Drawing.Point(29, 60);
            this.Lbl_Nombre_Impresora.Name = "Lbl_Nombre_Impresora";
            this.Lbl_Nombre_Impresora.Size = new System.Drawing.Size(116, 14);
            this.Lbl_Nombre_Impresora.TabIndex = 52;
            this.Lbl_Nombre_Impresora.Text = "*Nombre Impresora";
            // 
            // Fra_Impresoras
            // 
            this.Fra_Impresoras.Controls.Add(this.Grid_Impresoras);
            this.Fra_Impresoras.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Impresoras.Location = new System.Drawing.Point(5, 251);
            this.Fra_Impresoras.Name = "Fra_Impresoras";
            this.Fra_Impresoras.Size = new System.Drawing.Size(552, 216);
            this.Fra_Impresoras.TabIndex = 2;
            this.Fra_Impresoras.TabStop = false;
            this.Fra_Impresoras.Text = "Impresoras";
            // 
            // Grid_Impresoras
            // 
            this.Grid_Impresoras.AllowUserToAddRows = false;
            this.Grid_Impresoras.AllowUserToDeleteRows = false;
            this.Grid_Impresoras.AllowUserToResizeRows = false;
            this.Grid_Impresoras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Impresoras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Impresoras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Impresora_Id,
            this.Nombre_Impresora,
            this.Ip,
            this.Ubicacion,
            this.Comentarios});
            this.Grid_Impresoras.Location = new System.Drawing.Point(6, 20);
            this.Grid_Impresoras.Name = "Grid_Impresoras";
            this.Grid_Impresoras.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Impresoras.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Impresoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Impresoras.Size = new System.Drawing.Size(540, 190);
            this.Grid_Impresoras.TabIndex = 1;
            this.Grid_Impresoras.SelectionChanged += new System.EventHandler(this.Grid_Impresoras_SelectionChanged);
            // 
            // Impresora_Id
            // 
            this.Impresora_Id.DataPropertyName = "Impresora_Id";
            this.Impresora_Id.HeaderText = "ID Impresora";
            this.Impresora_Id.Name = "Impresora_Id";
            this.Impresora_Id.ReadOnly = true;
            this.Impresora_Id.Width = 105;
            // 
            // Nombre_Impresora
            // 
            this.Nombre_Impresora.DataPropertyName = "Nombre_Impresora";
            this.Nombre_Impresora.HeaderText = "Nombre";
            this.Nombre_Impresora.Name = "Nombre_Impresora";
            this.Nombre_Impresora.ReadOnly = true;
            this.Nombre_Impresora.Width = 77;
            // 
            // Ip
            // 
            this.Ip.DataPropertyName = "Ip";
            this.Ip.HeaderText = "Ip";
            this.Ip.Name = "Ip";
            this.Ip.ReadOnly = true;
            this.Ip.Width = 42;
            // 
            // Ubicacion
            // 
            this.Ubicacion.DataPropertyName = "Ubicacion";
            this.Ubicacion.HeaderText = "Ubicación";
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            this.Ubicacion.Width = 88;
            // 
            // Comentarios
            // 
            this.Comentarios.DataPropertyName = "Comentarios";
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.ReadOnly = true;
            this.Comentarios.Width = 105;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(453, 474);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(94, 51);
            this.Btn_Salir.TabIndex = 10;
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
            this.Btn_Eliminar.Location = new System.Drawing.Point(343, 474);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(93, 51);
            this.Btn_Eliminar.TabIndex = 9;
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
            this.Btn_Buscar.Location = new System.Drawing.Point(233, 474);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(94, 51);
            this.Btn_Buscar.TabIndex = 8;
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
            this.Btn_Modificar.Location = new System.Drawing.Point(120, 474);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(96, 51);
            this.Btn_Modificar.TabIndex = 7;
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
            this.Btn_Nuevo.Location = new System.Drawing.Point(7, 474);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(97, 51);
            this.Btn_Nuevo.TabIndex = 6;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Frm_Cat_Impresoras
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(575, 530);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Impresoras);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Impresoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresoras";
            this.Load += new System.EventHandler(this.Frm_Cat_Impresoras_Load);
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.Fra_Impresoras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Impresoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.Label Lbl_Comentarios;
        private System.Windows.Forms.Label Lbl_Ubicacion;
        private System.Windows.Forms.TextBox Txt_Ubicacion;
        private System.Windows.Forms.TextBox Txt_ID_Impresora;
        private System.Windows.Forms.Label Lbl_ID_Impresora;
        private System.Windows.Forms.TextBox Txt_Ip;
        private System.Windows.Forms.Label Lbl_Ip;
        private System.Windows.Forms.TextBox Txt_Nombre_Impresora;
        private System.Windows.Forms.Label Lbl_Nombre_Impresora;
        private System.Windows.Forms.TextBox Txt_Comentarios;
        private System.Windows.Forms.GroupBox Fra_Impresoras;
        private System.Windows.Forms.DataGridView Grid_Impresoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impresora_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Impresora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;

    }
}