namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Terminales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Terminales));
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Cmb_Puerto = new System.Windows.Forms.ComboBox();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Btn_Limpiar_Nombre_Equipo = new System.Windows.Forms.Button();
            this.Btn_Acutalizar_Nombre_Equipo = new System.Windows.Forms.Button();
            this.Txt_Equipo = new System.Windows.Forms.TextBox();
            this.Lbl_Equipo = new System.Windows.Forms.Label();
            this.Txt_ID_Terminal = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Terminal = new System.Windows.Forms.Label();
            this.Lbl_Puerto = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Fra_Terminales = new System.Windows.Forms.GroupBox();
            this.Grid_Terminales = new System.Windows.Forms.DataGridView();
            this.Terminal_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puerto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Chk_Pin_Pad = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Buscar.SuspendLayout();
            this.Fra_Terminales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Terminales)).BeginInit();
            this.SuspendLayout();
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Chk_Pin_Pad);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Puerto);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Btn_Limpiar_Nombre_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Btn_Acutalizar_Nombre_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_ID_Terminal);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_ID_Terminal);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Puerto);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Nombre);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Nombre);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(12, 12);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(424, 172);
            this.Fra_Datos_Generales.TabIndex = 2;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Cmb_Puerto
            // 
            this.Cmb_Puerto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Puerto.FormattingEnabled = true;
            this.Cmb_Puerto.Location = new System.Drawing.Point(90, 81);
            this.Cmb_Puerto.Name = "Cmb_Puerto";
            this.Cmb_Puerto.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Puerto.TabIndex = 62;
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(90, 138);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Estatus.TabIndex = 61;
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Estatus.Location = new System.Drawing.Point(25, 143);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(50, 14);
            this.Lbl_Estatus.TabIndex = 60;
            this.Lbl_Estatus.Text = "* Estatus";
            // 
            // Btn_Limpiar_Nombre_Equipo
            // 
            this.Btn_Limpiar_Nombre_Equipo.Image = global::ERP_BASE.Properties.Resources.icono_limpiar;
            this.Btn_Limpiar_Nombre_Equipo.Location = new System.Drawing.Point(343, 103);
            this.Btn_Limpiar_Nombre_Equipo.Name = "Btn_Limpiar_Nombre_Equipo";
            this.Btn_Limpiar_Nombre_Equipo.Size = new System.Drawing.Size(75, 30);
            this.Btn_Limpiar_Nombre_Equipo.TabIndex = 59;
            this.Btn_Limpiar_Nombre_Equipo.UseVisualStyleBackColor = true;
            this.Btn_Limpiar_Nombre_Equipo.Click += new System.EventHandler(this.Btn_Limpiar_Nombre_Equipo_Click);
            // 
            // Btn_Acutalizar_Nombre_Equipo
            // 
            this.Btn_Acutalizar_Nombre_Equipo.Image = global::ERP_BASE.Properties.Resources.actualizar_detalle;
            this.Btn_Acutalizar_Nombre_Equipo.Location = new System.Drawing.Point(249, 103);
            this.Btn_Acutalizar_Nombre_Equipo.Name = "Btn_Acutalizar_Nombre_Equipo";
            this.Btn_Acutalizar_Nombre_Equipo.Size = new System.Drawing.Size(75, 30);
            this.Btn_Acutalizar_Nombre_Equipo.TabIndex = 58;
            this.Btn_Acutalizar_Nombre_Equipo.UseVisualStyleBackColor = true;
            this.Btn_Acutalizar_Nombre_Equipo.Click += new System.EventHandler(this.Btn_Acutalizar_Nombre_Equipo_Click);
            // 
            // Txt_Equipo
            // 
            this.Txt_Equipo.Enabled = false;
            this.Txt_Equipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Equipo.Location = new System.Drawing.Point(90, 109);
            this.Txt_Equipo.MaxLength = 20;
            this.Txt_Equipo.Name = "Txt_Equipo";
            this.Txt_Equipo.Size = new System.Drawing.Size(140, 22);
            this.Txt_Equipo.TabIndex = 57;
            // 
            // Lbl_Equipo
            // 
            this.Lbl_Equipo.AutoSize = true;
            this.Lbl_Equipo.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Equipo.Location = new System.Drawing.Point(25, 112);
            this.Lbl_Equipo.Name = "Lbl_Equipo";
            this.Lbl_Equipo.Size = new System.Drawing.Size(46, 14);
            this.Lbl_Equipo.TabIndex = 56;
            this.Lbl_Equipo.Text = "* Equipo";
            // 
            // Txt_ID_Terminal
            // 
            this.Txt_ID_Terminal.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Terminal.Location = new System.Drawing.Point(90, 25);
            this.Txt_ID_Terminal.MaxLength = 5;
            this.Txt_ID_Terminal.Name = "Txt_ID_Terminal";
            this.Txt_ID_Terminal.ReadOnly = true;
            this.Txt_ID_Terminal.Size = new System.Drawing.Size(140, 22);
            this.Txt_ID_Terminal.TabIndex = 49;
            // 
            // Lbl_ID_Terminal
            // 
            this.Lbl_ID_Terminal.AutoSize = true;
            this.Lbl_ID_Terminal.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Terminal.Location = new System.Drawing.Point(25, 30);
            this.Lbl_ID_Terminal.Name = "Lbl_ID_Terminal";
            this.Lbl_ID_Terminal.Size = new System.Drawing.Size(58, 14);
            this.Lbl_ID_Terminal.TabIndex = 55;
            this.Lbl_ID_Terminal.Text = "ID Terminal";
            // 
            // Lbl_Puerto
            // 
            this.Lbl_Puerto.AutoSize = true;
            this.Lbl_Puerto.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Puerto.Location = new System.Drawing.Point(25, 86);
            this.Lbl_Puerto.Name = "Lbl_Puerto";
            this.Lbl_Puerto.Size = new System.Drawing.Size(45, 14);
            this.Lbl_Puerto.TabIndex = 53;
            this.Lbl_Puerto.Text = "* Puerto";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(90, 53);
            this.Txt_Nombre.MaxLength = 50;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(328, 22);
            this.Txt_Nombre.TabIndex = 50;
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Nombre.Location = new System.Drawing.Point(25, 58);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(55, 14);
            this.Lbl_Nombre.TabIndex = 52;
            this.Lbl_Nombre.Text = "*Nombre";
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Location = new System.Drawing.Point(12, 12);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(424, 160);
            this.Fra_Buscar.TabIndex = 53;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(225, 103);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(75, 45);
            this.Btn_Regresar.TabIndex = 17;
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
            this.Btn_Busqueda.Location = new System.Drawing.Point(114, 103);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(75, 45);
            this.Btn_Busqueda.TabIndex = 16;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(114, 53);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(224, 26);
            this.Txt_Descripcion_Busqueda.TabIndex = 15;
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(6, 64);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(80, 15);
            this.Lbl_Descripcion_Busqueda.TabIndex = 13;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "ID Terminal",
            "Nombre",
            "Puerto"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(114, 23);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(224, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 14;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(6, 32);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda.TabIndex = 12;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Fra_Terminales
            // 
            this.Fra_Terminales.Controls.Add(this.Grid_Terminales);
            this.Fra_Terminales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Terminales.Location = new System.Drawing.Point(12, 190);
            this.Fra_Terminales.Name = "Fra_Terminales";
            this.Fra_Terminales.Size = new System.Drawing.Size(424, 169);
            this.Fra_Terminales.TabIndex = 3;
            this.Fra_Terminales.TabStop = false;
            this.Fra_Terminales.Text = "Terminales";
            // 
            // Grid_Terminales
            // 
            this.Grid_Terminales.AllowUserToAddRows = false;
            this.Grid_Terminales.AllowUserToDeleteRows = false;
            this.Grid_Terminales.AllowUserToResizeRows = false;
            this.Grid_Terminales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Terminales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Terminales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Terminal_ID,
            this.Nombre,
            this.Equipo,
            this.Estatus,
            this.Puerto});
            this.Grid_Terminales.Location = new System.Drawing.Point(6, 20);
            this.Grid_Terminales.Name = "Grid_Terminales";
            this.Grid_Terminales.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Terminales.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Terminales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Terminales.Size = new System.Drawing.Size(412, 143);
            this.Grid_Terminales.TabIndex = 1;
            this.Grid_Terminales.SelectionChanged += new System.EventHandler(this.Grid_Terminales_SelectionChanged);
            // 
            // Terminal_ID
            // 
            this.Terminal_ID.DataPropertyName = "Terminal_ID";
            this.Terminal_ID.HeaderText = "ID Terminal";
            this.Terminal_ID.Name = "Terminal_ID";
            this.Terminal_ID.ReadOnly = true;
            this.Terminal_ID.Width = 95;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 77;
            // 
            // Equipo
            // 
            this.Equipo.DataPropertyName = "Equipo";
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.Name = "Equipo";
            this.Equipo.ReadOnly = true;
            this.Equipo.Width = 70;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 75;
            // 
            // Puerto
            // 
            this.Puerto.DataPropertyName = "Puerto";
            this.Puerto.HeaderText = "Puerto";
            this.Puerto.Name = "Puerto";
            this.Puerto.ReadOnly = true;
            this.Puerto.Width = 70;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(356, 366);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(80, 51);
            this.Btn_Salir.TabIndex = 52;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(270, 366);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(80, 51);
            this.Btn_Eliminar.TabIndex = 51;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(184, 366);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(80, 51);
            this.Btn_Buscar.TabIndex = 50;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(98, 366);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(80, 51);
            this.Btn_Modificar.TabIndex = 49;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(12, 366);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(80, 51);
            this.Btn_Nuevo.TabIndex = 48;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Chk_Pin_Pad
            // 
            this.Chk_Pin_Pad.AutoSize = true;
            this.Chk_Pin_Pad.Location = new System.Drawing.Point(249, 25);
            this.Chk_Pin_Pad.Name = "Chk_Pin_Pad";
            this.Chk_Pin_Pad.Size = new System.Drawing.Size(68, 19);
            this.Chk_Pin_Pad.TabIndex = 63;
            this.Chk_Pin_Pad.Text = "Pin pad";
            this.Chk_Pin_Pad.UseVisualStyleBackColor = true;
            this.Chk_Pin_Pad.CheckedChanged += new System.EventHandler(this.Chk_Pin_Pad_CheckedChanged);
            // 
            // Frm_Cat_Terminales
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(448, 429);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Fra_Terminales);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Buscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Terminales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminales";
            this.Load += new System.EventHandler(this.Frm_Cat_Terminales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.Fra_Terminales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Terminales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.TextBox Txt_ID_Terminal;
        private System.Windows.Forms.Label Lbl_ID_Terminal;
        private System.Windows.Forms.Label Lbl_Puerto;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.GroupBox Fra_Terminales;
        private System.Windows.Forms.DataGridView Grid_Terminales;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;
        private System.Windows.Forms.TextBox Txt_Equipo;
        private System.Windows.Forms.Label Lbl_Equipo;
        private System.Windows.Forms.Button Btn_Limpiar_Nombre_Equipo;
        private System.Windows.Forms.Button Btn_Acutalizar_Nombre_Equipo;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Terminal_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puerto;
        private System.Windows.Forms.ComboBox Cmb_Puerto;
        private System.Windows.Forms.CheckBox Chk_Pin_Pad;
    }
}