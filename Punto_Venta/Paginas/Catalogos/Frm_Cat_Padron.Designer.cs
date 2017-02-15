namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Padron
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Fra_Datos_Usuario = new System.Windows.Forms.GroupBox();
            this.Cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Txt_Rfc = new System.Windows.Forms.TextBox();
            this.Txt_Curp = new System.Windows.Forms.TextBox();
            this.Lbl_Rfc = new System.Windows.Forms.Label();
            this.Lbl_Curp = new System.Windows.Forms.Label();
            this.Lbl_Apellido_Paterno = new System.Windows.Forms.Label();
            this.Fra_Informacion_Usuario = new System.Windows.Forms.GroupBox();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Cmb_Genero = new System.Windows.Forms.ComboBox();
            this.Lbl_Genero = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_Apellido_Materno = new System.Windows.Forms.TextBox();
            this.Lbl_Apellido_Materno = new System.Windows.Forms.Label();
            this.Txt_Apellido_Paterno = new System.Windows.Forms.TextBox();
            this.Grid_Padron = new System.Windows.Forms.DataGridView();
            this.Curp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rfc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fra_Filtros = new System.Windows.Forms.GroupBox();
            this.Txt_Filtro_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Filtro_Nombre = new System.Windows.Forms.Label();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Txt_Filtro_Rfc = new System.Windows.Forms.TextBox();
            this.Lbl_Filtro_Rfc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Domicilio = new System.Windows.Forms.GroupBox();
            this.Txt_Codigo_Postal = new System.Windows.Forms.TextBox();
            this.Lbl_Codigo_Postal = new System.Windows.Forms.Label();
            this.Cmb_Estado = new System.Windows.Forms.ComboBox();
            this.Lbl_Estado = new System.Windows.Forms.Label();
            this.Txt_Municipio = new System.Windows.Forms.TextBox();
            this.Lbl_Municipio = new System.Windows.Forms.Label();
            this.Txt_Colonia = new System.Windows.Forms.TextBox();
            this.Lbl_Colonia = new System.Windows.Forms.Label();
            this.Txt_No_Exterior = new System.Windows.Forms.TextBox();
            this.Lbl_Numero_Exterior = new System.Windows.Forms.Label();
            this.Txt_No_Interior = new System.Windows.Forms.TextBox();
            this.Lbl_Numero_Interno = new System.Windows.Forms.Label();
            this.Txt_Calle = new System.Windows.Forms.TextBox();
            this.Lbl_Calle = new System.Windows.Forms.Label();
            this.Fra_Datos_Usuario.SuspendLayout();
            this.Fra_Informacion_Usuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Padron)).BeginInit();
            this.Fra_Filtros.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Domicilio.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fra_Datos_Usuario
            // 
            this.Fra_Datos_Usuario.Controls.Add(this.Cmb_Tipo);
            this.Fra_Datos_Usuario.Controls.Add(this.Lbl_Tipo);
            this.Fra_Datos_Usuario.Controls.Add(this.Txt_Rfc);
            this.Fra_Datos_Usuario.Controls.Add(this.Txt_Curp);
            this.Fra_Datos_Usuario.Controls.Add(this.Lbl_Rfc);
            this.Fra_Datos_Usuario.Controls.Add(this.Lbl_Curp);
            this.Fra_Datos_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Datos_Usuario.Location = new System.Drawing.Point(13, 7);
            this.Fra_Datos_Usuario.Name = "Fra_Datos_Usuario";
            this.Fra_Datos_Usuario.Size = new System.Drawing.Size(688, 54);
            this.Fra_Datos_Usuario.TabIndex = 0;
            this.Fra_Datos_Usuario.TabStop = false;
            this.Fra_Datos_Usuario.Text = "Datos usuario";
            // 
            // Cmb_Tipo
            // 
            this.Cmb_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo.FormattingEnabled = true;
            this.Cmb_Tipo.Items.AddRange(new object[] {
            "PERSONA FISICA",
            "PERSONA MORAL"});
            this.Cmb_Tipo.Location = new System.Drawing.Point(503, 21);
            this.Cmb_Tipo.Name = "Cmb_Tipo";
            this.Cmb_Tipo.Size = new System.Drawing.Size(179, 21);
            this.Cmb_Tipo.TabIndex = 3;
            this.Cmb_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Tipo.Location = new System.Drawing.Point(457, 27);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(28, 13);
            this.Lbl_Tipo.TabIndex = 3;
            this.Lbl_Tipo.Text = "Tipo";
            // 
            // Txt_Rfc
            // 
            this.Txt_Rfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Rfc.Location = new System.Drawing.Point(44, 24);
            this.Txt_Rfc.MaxLength = 20;
            this.Txt_Rfc.Name = "Txt_Rfc";
            this.Txt_Rfc.Size = new System.Drawing.Size(168, 20);
            this.Txt_Rfc.TabIndex = 1;
            this.Txt_Rfc.Leave += new System.EventHandler(this.Txt_Rfc_Leave);
            // 
            // Txt_Curp
            // 
            this.Txt_Curp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Curp.Location = new System.Drawing.Point(265, 24);
            this.Txt_Curp.MaxLength = 30;
            this.Txt_Curp.Name = "Txt_Curp";
            this.Txt_Curp.Size = new System.Drawing.Size(179, 20);
            this.Txt_Curp.TabIndex = 2;
            this.Txt_Curp.Leave += new System.EventHandler(this.Txt_Curp_Leave);
            // 
            // Lbl_Rfc
            // 
            this.Lbl_Rfc.AutoSize = true;
            this.Lbl_Rfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Rfc.Location = new System.Drawing.Point(16, 24);
            this.Lbl_Rfc.Name = "Lbl_Rfc";
            this.Lbl_Rfc.Size = new System.Drawing.Size(24, 13);
            this.Lbl_Rfc.TabIndex = 0;
            this.Lbl_Rfc.Text = "Rfc";
            // 
            // Lbl_Curp
            // 
            this.Lbl_Curp.AutoSize = true;
            this.Lbl_Curp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Curp.Location = new System.Drawing.Point(232, 24);
            this.Lbl_Curp.Name = "Lbl_Curp";
            this.Lbl_Curp.Size = new System.Drawing.Size(29, 13);
            this.Lbl_Curp.TabIndex = 0;
            this.Lbl_Curp.Text = "Curp";
            // 
            // Lbl_Apellido_Paterno
            // 
            this.Lbl_Apellido_Paterno.AutoSize = true;
            this.Lbl_Apellido_Paterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Apellido_Paterno.Location = new System.Drawing.Point(16, 17);
            this.Lbl_Apellido_Paterno.Name = "Lbl_Apellido_Paterno";
            this.Lbl_Apellido_Paterno.Size = new System.Drawing.Size(83, 13);
            this.Lbl_Apellido_Paterno.TabIndex = 0;
            this.Lbl_Apellido_Paterno.Text = "Apellido paterno";
            // 
            // Fra_Informacion_Usuario
            // 
            this.Fra_Informacion_Usuario.Controls.Add(this.Cmb_Estatus);
            this.Fra_Informacion_Usuario.Controls.Add(this.Lbl_Estatus);
            this.Fra_Informacion_Usuario.Controls.Add(this.Cmb_Genero);
            this.Fra_Informacion_Usuario.Controls.Add(this.Lbl_Genero);
            this.Fra_Informacion_Usuario.Controls.Add(this.Txt_Nombre);
            this.Fra_Informacion_Usuario.Controls.Add(this.Lbl_Nombre);
            this.Fra_Informacion_Usuario.Controls.Add(this.Txt_Apellido_Materno);
            this.Fra_Informacion_Usuario.Controls.Add(this.Lbl_Apellido_Materno);
            this.Fra_Informacion_Usuario.Controls.Add(this.Txt_Apellido_Paterno);
            this.Fra_Informacion_Usuario.Controls.Add(this.Lbl_Apellido_Paterno);
            this.Fra_Informacion_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Informacion_Usuario.Location = new System.Drawing.Point(13, 70);
            this.Fra_Informacion_Usuario.Name = "Fra_Informacion_Usuario";
            this.Fra_Informacion_Usuario.Size = new System.Drawing.Size(313, 154);
            this.Fra_Informacion_Usuario.TabIndex = 4;
            this.Fra_Informacion_Usuario.TabStop = false;
            this.Fra_Informacion_Usuario.Text = "Información del usuario";
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Estatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(113, 122);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(182, 21);
            this.Cmb_Estatus.TabIndex = 8;
            this.Cmb_Estatus.Visible = false;
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Estatus.Location = new System.Drawing.Point(18, 122);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(42, 13);
            this.Lbl_Estatus.TabIndex = 0;
            this.Lbl_Estatus.Text = "Estatus";
            this.Lbl_Estatus.Visible = false;
            // 
            // Cmb_Genero
            // 
            this.Cmb_Genero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Genero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Genero.FormattingEnabled = true;
            this.Cmb_Genero.Items.AddRange(new object[] {
            "FEMENINO",
            "MASCULINO"});
            this.Cmb_Genero.Location = new System.Drawing.Point(113, 94);
            this.Cmb_Genero.Name = "Cmb_Genero";
            this.Cmb_Genero.Size = new System.Drawing.Size(182, 21);
            this.Cmb_Genero.TabIndex = 7;
            // 
            // Lbl_Genero
            // 
            this.Lbl_Genero.AutoSize = true;
            this.Lbl_Genero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Genero.Location = new System.Drawing.Point(18, 94);
            this.Lbl_Genero.Name = "Lbl_Genero";
            this.Lbl_Genero.Size = new System.Drawing.Size(42, 13);
            this.Lbl_Genero.TabIndex = 0;
            this.Lbl_Genero.Text = "Genero";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(113, 68);
            this.Txt_Nombre.MaxLength = 100;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(182, 20);
            this.Txt_Nombre.TabIndex = 6;
            this.Txt_Nombre.Leave += new System.EventHandler(this.Txt_Nombre_Leave);
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre.Location = new System.Drawing.Point(16, 68);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(44, 13);
            this.Lbl_Nombre.TabIndex = 0;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Txt_Apellido_Materno
            // 
            this.Txt_Apellido_Materno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Apellido_Materno.Location = new System.Drawing.Point(113, 42);
            this.Txt_Apellido_Materno.MaxLength = 30;
            this.Txt_Apellido_Materno.Name = "Txt_Apellido_Materno";
            this.Txt_Apellido_Materno.Size = new System.Drawing.Size(182, 20);
            this.Txt_Apellido_Materno.TabIndex = 5;
            this.Txt_Apellido_Materno.Leave += new System.EventHandler(this.Txt_Apellido_Materno_Leave);
            // 
            // Lbl_Apellido_Materno
            // 
            this.Lbl_Apellido_Materno.AutoSize = true;
            this.Lbl_Apellido_Materno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Apellido_Materno.Location = new System.Drawing.Point(16, 42);
            this.Lbl_Apellido_Materno.Name = "Lbl_Apellido_Materno";
            this.Lbl_Apellido_Materno.Size = new System.Drawing.Size(85, 13);
            this.Lbl_Apellido_Materno.TabIndex = 0;
            this.Lbl_Apellido_Materno.Text = "Apellido materno";
            // 
            // Txt_Apellido_Paterno
            // 
            this.Txt_Apellido_Paterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Apellido_Paterno.Location = new System.Drawing.Point(113, 17);
            this.Txt_Apellido_Paterno.MaxLength = 30;
            this.Txt_Apellido_Paterno.Name = "Txt_Apellido_Paterno";
            this.Txt_Apellido_Paterno.Size = new System.Drawing.Size(182, 20);
            this.Txt_Apellido_Paterno.TabIndex = 4;
            this.Txt_Apellido_Paterno.Leave += new System.EventHandler(this.Txt_Apellido_Paterno_Leave);
            // 
            // Grid_Padron
            // 
            this.Grid_Padron.AllowUserToAddRows = false;
            this.Grid_Padron.AllowUserToDeleteRows = false;
            this.Grid_Padron.AllowUserToResizeRows = false;
            this.Grid_Padron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Padron.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Curp,
            this.Rfc,
            this.Paterno,
            this.materno,
            this.nombre});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Padron.DefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Padron.Location = new System.Drawing.Point(12, 323);
            this.Grid_Padron.Name = "Grid_Padron";
            this.Grid_Padron.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Padron.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Padron.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Padron.Size = new System.Drawing.Size(689, 189);
            this.Grid_Padron.TabIndex = 0;
            this.Grid_Padron.SelectionChanged += new System.EventHandler(this.Grid_Padron_SelectionChanged);
            // 
            // Curp
            // 
            this.Curp.DataPropertyName = "Curp";
            this.Curp.HeaderText = "Curp";
            this.Curp.Name = "Curp";
            this.Curp.ReadOnly = true;
            this.Curp.Width = 130;
            // 
            // Rfc
            // 
            this.Rfc.DataPropertyName = "Rfc";
            this.Rfc.HeaderText = "Rfc";
            this.Rfc.Name = "Rfc";
            this.Rfc.ReadOnly = true;
            this.Rfc.Width = 130;
            // 
            // Paterno
            // 
            this.Paterno.DataPropertyName = "Paterno";
            this.Paterno.HeaderText = "Paterno";
            this.Paterno.Name = "Paterno";
            this.Paterno.ReadOnly = true;
            this.Paterno.Width = 80;
            // 
            // materno
            // 
            this.materno.DataPropertyName = "materno";
            this.materno.HeaderText = "Materno";
            this.materno.Name = "materno";
            this.materno.ReadOnly = true;
            this.materno.Width = 80;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 80;
            // 
            // Fra_Filtros
            // 
            this.Fra_Filtros.Controls.Add(this.Txt_Filtro_Nombre);
            this.Fra_Filtros.Controls.Add(this.Lbl_Filtro_Nombre);
            this.Fra_Filtros.Controls.Add(this.Btn_Buscar);
            this.Fra_Filtros.Controls.Add(this.Txt_Filtro_Rfc);
            this.Fra_Filtros.Controls.Add(this.Lbl_Filtro_Rfc);
            this.Fra_Filtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Filtros.Location = new System.Drawing.Point(13, 230);
            this.Fra_Filtros.Name = "Fra_Filtros";
            this.Fra_Filtros.Size = new System.Drawing.Size(688, 86);
            this.Fra_Filtros.TabIndex = 16;
            this.Fra_Filtros.TabStop = false;
            this.Fra_Filtros.Text = "Filtros";
            // 
            // Txt_Filtro_Nombre
            // 
            this.Txt_Filtro_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Filtro_Nombre.Location = new System.Drawing.Point(69, 53);
            this.Txt_Filtro_Nombre.MaxLength = 20;
            this.Txt_Filtro_Nombre.Name = "Txt_Filtro_Nombre";
            this.Txt_Filtro_Nombre.Size = new System.Drawing.Size(331, 20);
            this.Txt_Filtro_Nombre.TabIndex = 17;
            // 
            // Lbl_Filtro_Nombre
            // 
            this.Lbl_Filtro_Nombre.AutoSize = true;
            this.Lbl_Filtro_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Filtro_Nombre.Location = new System.Drawing.Point(16, 53);
            this.Lbl_Filtro_Nombre.Name = "Lbl_Filtro_Nombre";
            this.Lbl_Filtro_Nombre.Size = new System.Drawing.Size(44, 13);
            this.Lbl_Filtro_Nombre.TabIndex = 0;
            this.Lbl_Filtro_Nombre.Text = "Nombre";
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Buscar.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(406, 40);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(81, 30);
            this.Btn_Buscar.TabIndex = 18;
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Txt_Filtro_Rfc
            // 
            this.Txt_Filtro_Rfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Filtro_Rfc.Location = new System.Drawing.Point(69, 23);
            this.Txt_Filtro_Rfc.MaxLength = 20;
            this.Txt_Filtro_Rfc.Name = "Txt_Filtro_Rfc";
            this.Txt_Filtro_Rfc.Size = new System.Drawing.Size(179, 20);
            this.Txt_Filtro_Rfc.TabIndex = 16;
            // 
            // Lbl_Filtro_Rfc
            // 
            this.Lbl_Filtro_Rfc.AutoSize = true;
            this.Lbl_Filtro_Rfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Filtro_Rfc.Location = new System.Drawing.Point(16, 23);
            this.Lbl_Filtro_Rfc.Name = "Lbl_Filtro_Rfc";
            this.Lbl_Filtro_Rfc.Size = new System.Drawing.Size(24, 13);
            this.Lbl_Filtro_Rfc.TabIndex = 0;
            this.Lbl_Filtro_Rfc.Text = "Rfc";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Salir);
            this.panel1.Controls.Add(this.Btn_Modificar);
            this.panel1.Controls.Add(this.Btn_Eliminar);
            this.panel1.Controls.Add(this.Btn_Nuevo);
            this.panel1.Location = new System.Drawing.Point(1, 518);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 63);
            this.panel1.TabIndex = 0;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(568, 11);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(119, 45);
            this.Btn_Salir.TabIndex = 22;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(188, 11);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(119, 45);
            this.Btn_Modificar.TabIndex = 20;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Visible = false;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(380, 11);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(119, 45);
            this.Btn_Eliminar.TabIndex = 21;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Visible = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(10, 11);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(120, 45);
            this.Btn_Nuevo.TabIndex = 19;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Fra_Domicilio
            // 
            this.Fra_Domicilio.Controls.Add(this.Txt_Codigo_Postal);
            this.Fra_Domicilio.Controls.Add(this.Lbl_Codigo_Postal);
            this.Fra_Domicilio.Controls.Add(this.Cmb_Estado);
            this.Fra_Domicilio.Controls.Add(this.Lbl_Estado);
            this.Fra_Domicilio.Controls.Add(this.Txt_Municipio);
            this.Fra_Domicilio.Controls.Add(this.Lbl_Municipio);
            this.Fra_Domicilio.Controls.Add(this.Txt_Colonia);
            this.Fra_Domicilio.Controls.Add(this.Lbl_Colonia);
            this.Fra_Domicilio.Controls.Add(this.Txt_No_Exterior);
            this.Fra_Domicilio.Controls.Add(this.Lbl_Numero_Exterior);
            this.Fra_Domicilio.Controls.Add(this.Txt_No_Interior);
            this.Fra_Domicilio.Controls.Add(this.Lbl_Numero_Interno);
            this.Fra_Domicilio.Controls.Add(this.Txt_Calle);
            this.Fra_Domicilio.Controls.Add(this.Lbl_Calle);
            this.Fra_Domicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Domicilio.Location = new System.Drawing.Point(342, 70);
            this.Fra_Domicilio.Name = "Fra_Domicilio";
            this.Fra_Domicilio.Size = new System.Drawing.Size(359, 154);
            this.Fra_Domicilio.TabIndex = 9;
            this.Fra_Domicilio.TabStop = false;
            this.Fra_Domicilio.Text = "Domicilio";
            // 
            // Txt_Codigo_Postal
            // 
            this.Txt_Codigo_Postal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Codigo_Postal.Location = new System.Drawing.Point(284, 42);
            this.Txt_Codigo_Postal.MaxLength = 10;
            this.Txt_Codigo_Postal.Name = "Txt_Codigo_Postal";
            this.Txt_Codigo_Postal.Size = new System.Drawing.Size(53, 20);
            this.Txt_Codigo_Postal.TabIndex = 12;
            // 
            // Lbl_Codigo_Postal
            // 
            this.Lbl_Codigo_Postal.AutoSize = true;
            this.Lbl_Codigo_Postal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Codigo_Postal.Location = new System.Drawing.Point(256, 45);
            this.Lbl_Codigo_Postal.Name = "Lbl_Codigo_Postal";
            this.Lbl_Codigo_Postal.Size = new System.Drawing.Size(27, 13);
            this.Lbl_Codigo_Postal.TabIndex = 0;
            this.Lbl_Codigo_Postal.Text = "C.P.";
            // 
            // Cmb_Estado
            // 
            this.Cmb_Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estado.FormattingEnabled = true;
            this.Cmb_Estado.Items.AddRange(new object[] {
            "AGUASCALIENTES",
            "BAJA CALIFORNIA",
            "BAJA CALIFORNIA SUR",
            "CAMPECHE",
            "CHIAPAS",
            "CHIHUAHUA",
            "COAHUILA",
            "COLIMA",
            "DISTRITO FEDERAL",
            "DURANGO",
            "ESTADO DE MEXICO",
            "GUANAJUATO",
            "GUERRERO",
            "HIDALGO",
            "JALISCO",
            "MICHOACAN",
            "MORELOS",
            "NAYARIT",
            "NUEVO LEON",
            "OAXACA",
            "PUEBLA",
            "QUERATARO",
            "QUINTANA ROO",
            "SAN LUIS POTOSI",
            "SINALOA",
            "SONORA",
            "TABASCO",
            "TAMAULIPAS",
            "TLAXCALA",
            "VERACRUZ",
            "YUCATAN",
            "ZACATECAS"});
            this.Cmb_Estado.Location = new System.Drawing.Point(61, 117);
            this.Cmb_Estado.Name = "Cmb_Estado";
            this.Cmb_Estado.Size = new System.Drawing.Size(276, 21);
            this.Cmb_Estado.TabIndex = 15;
            // 
            // Lbl_Estado
            // 
            this.Lbl_Estado.AutoSize = true;
            this.Lbl_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Estado.Location = new System.Drawing.Point(6, 120);
            this.Lbl_Estado.Name = "Lbl_Estado";
            this.Lbl_Estado.Size = new System.Drawing.Size(40, 13);
            this.Lbl_Estado.TabIndex = 0;
            this.Lbl_Estado.Text = "Estado";
            // 
            // Txt_Municipio
            // 
            this.Txt_Municipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Municipio.Location = new System.Drawing.Point(61, 91);
            this.Txt_Municipio.MaxLength = 100;
            this.Txt_Municipio.Name = "Txt_Municipio";
            this.Txt_Municipio.Size = new System.Drawing.Size(276, 20);
            this.Txt_Municipio.TabIndex = 14;
            this.Txt_Municipio.Leave += new System.EventHandler(this.Txt_Municipio_Leave);
            // 
            // Lbl_Municipio
            // 
            this.Lbl_Municipio.AutoSize = true;
            this.Lbl_Municipio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Municipio.Location = new System.Drawing.Point(6, 94);
            this.Lbl_Municipio.Name = "Lbl_Municipio";
            this.Lbl_Municipio.Size = new System.Drawing.Size(52, 13);
            this.Lbl_Municipio.TabIndex = 0;
            this.Lbl_Municipio.Text = "Municipio";
            // 
            // Txt_Colonia
            // 
            this.Txt_Colonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Colonia.Location = new System.Drawing.Point(61, 68);
            this.Txt_Colonia.MaxLength = 100;
            this.Txt_Colonia.Name = "Txt_Colonia";
            this.Txt_Colonia.Size = new System.Drawing.Size(276, 20);
            this.Txt_Colonia.TabIndex = 13;
            this.Txt_Colonia.Leave += new System.EventHandler(this.Txt_Colonia_Leave);
            // 
            // Lbl_Colonia
            // 
            this.Lbl_Colonia.AutoSize = true;
            this.Lbl_Colonia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Colonia.Location = new System.Drawing.Point(6, 68);
            this.Lbl_Colonia.Name = "Lbl_Colonia";
            this.Lbl_Colonia.Size = new System.Drawing.Size(42, 13);
            this.Lbl_Colonia.TabIndex = 0;
            this.Lbl_Colonia.Text = "Colonia";
            // 
            // Txt_No_Exterior
            // 
            this.Txt_No_Exterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_No_Exterior.Location = new System.Drawing.Point(187, 43);
            this.Txt_No_Exterior.MaxLength = 10;
            this.Txt_No_Exterior.Name = "Txt_No_Exterior";
            this.Txt_No_Exterior.Size = new System.Drawing.Size(53, 20);
            this.Txt_No_Exterior.TabIndex = 11;
            // 
            // Lbl_Numero_Exterior
            // 
            this.Lbl_Numero_Exterior.AutoSize = true;
            this.Lbl_Numero_Exterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Numero_Exterior.Location = new System.Drawing.Point(128, 45);
            this.Lbl_Numero_Exterior.Name = "Lbl_Numero_Exterior";
            this.Lbl_Numero_Exterior.Size = new System.Drawing.Size(58, 13);
            this.Lbl_Numero_Exterior.TabIndex = 0;
            this.Lbl_Numero_Exterior.Text = "No exterior";
            // 
            // Txt_No_Interior
            // 
            this.Txt_No_Interior.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_No_Interior.Location = new System.Drawing.Point(61, 43);
            this.Txt_No_Interior.MaxLength = 10;
            this.Txt_No_Interior.Name = "Txt_No_Interior";
            this.Txt_No_Interior.Size = new System.Drawing.Size(54, 20);
            this.Txt_No_Interior.TabIndex = 10;
            // 
            // Lbl_Numero_Interno
            // 
            this.Lbl_Numero_Interno.AutoSize = true;
            this.Lbl_Numero_Interno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Numero_Interno.Location = new System.Drawing.Point(6, 45);
            this.Lbl_Numero_Interno.Name = "Lbl_Numero_Interno";
            this.Lbl_Numero_Interno.Size = new System.Drawing.Size(56, 13);
            this.Lbl_Numero_Interno.TabIndex = 0;
            this.Lbl_Numero_Interno.Text = "No interno";
            // 
            // Txt_Calle
            // 
            this.Txt_Calle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Calle.Location = new System.Drawing.Point(61, 17);
            this.Txt_Calle.MaxLength = 100;
            this.Txt_Calle.Name = "Txt_Calle";
            this.Txt_Calle.Size = new System.Drawing.Size(276, 20);
            this.Txt_Calle.TabIndex = 9;
            this.Txt_Calle.Leave += new System.EventHandler(this.Txt_Calle_Leave);
            // 
            // Lbl_Calle
            // 
            this.Lbl_Calle.AutoSize = true;
            this.Lbl_Calle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Calle.Location = new System.Drawing.Point(6, 20);
            this.Lbl_Calle.Name = "Lbl_Calle";
            this.Lbl_Calle.Size = new System.Drawing.Size(30, 13);
            this.Lbl_Calle.TabIndex = 0;
            this.Lbl_Calle.Text = "Calle";
            // 
            // Frm_Cat_Padron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(710, 593);
            this.Controls.Add(this.Fra_Domicilio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Fra_Filtros);
            this.Controls.Add(this.Grid_Padron);
            this.Controls.Add(this.Fra_Informacion_Usuario);
            this.Controls.Add(this.Fra_Datos_Usuario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Padron";
            this.Text = "Padrón de usuarios";
            this.Load += new System.EventHandler(this.Frm_Cat_Padron_Load);
            this.Fra_Datos_Usuario.ResumeLayout(false);
            this.Fra_Datos_Usuario.PerformLayout();
            this.Fra_Informacion_Usuario.ResumeLayout(false);
            this.Fra_Informacion_Usuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Padron)).EndInit();
            this.Fra_Filtros.ResumeLayout(false);
            this.Fra_Filtros.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Domicilio.ResumeLayout(false);
            this.Fra_Domicilio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Datos_Usuario;
        private System.Windows.Forms.TextBox Txt_Rfc;
        private System.Windows.Forms.TextBox Txt_Curp;
        private System.Windows.Forms.Label Lbl_Rfc;
        private System.Windows.Forms.Label Lbl_Curp;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.Label Lbl_Apellido_Paterno;
        private System.Windows.Forms.GroupBox Fra_Informacion_Usuario;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.TextBox Txt_Apellido_Materno;
        private System.Windows.Forms.Label Lbl_Apellido_Materno;
        private System.Windows.Forms.TextBox Txt_Apellido_Paterno;
        private System.Windows.Forms.ComboBox Cmb_Genero;
        private System.Windows.Forms.Label Lbl_Genero;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.DataGridView Grid_Padron;
        private System.Windows.Forms.GroupBox Fra_Filtros;
        private System.Windows.Forms.TextBox Txt_Filtro_Rfc;
        private System.Windows.Forms.Label Lbl_Filtro_Rfc;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.ComboBox Cmb_Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rfc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn materno;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.TextBox Txt_Filtro_Nombre;
        private System.Windows.Forms.Label Lbl_Filtro_Nombre;
        private System.Windows.Forms.GroupBox Fra_Domicilio;
        private System.Windows.Forms.Label Lbl_Calle;
        private System.Windows.Forms.TextBox Txt_No_Exterior;
        private System.Windows.Forms.Label Lbl_Numero_Exterior;
        private System.Windows.Forms.TextBox Txt_No_Interior;
        private System.Windows.Forms.Label Lbl_Numero_Interno;
        private System.Windows.Forms.TextBox Txt_Calle;
        private System.Windows.Forms.TextBox Txt_Colonia;
        private System.Windows.Forms.Label Lbl_Colonia;
        private System.Windows.Forms.Label Lbl_Municipio;
        private System.Windows.Forms.Label Lbl_Codigo_Postal;
        private System.Windows.Forms.ComboBox Cmb_Estado;
        private System.Windows.Forms.Label Lbl_Estado;
        private System.Windows.Forms.TextBox Txt_Municipio;
        private System.Windows.Forms.TextBox Txt_Codigo_Postal;
    }
}