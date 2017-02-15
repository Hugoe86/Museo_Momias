namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Camaras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Camaras));
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Tbl_Columnas_Datos_Generales = new System.Windows.Forms.TableLayoutPanel();
            this.Txt_Contrasenia = new System.Windows.Forms.TextBox();
            this.Txt_Usuario = new System.Windows.Forms.TextBox();
            this.Lbl_Contrasenia = new System.Windows.Forms.Label();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Txt_Url = new System.Windows.Forms.TextBox();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Cmb_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Lbl_Url = new System.Windows.Forms.Label();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_ID_Camara = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Camara = new System.Windows.Forms.Label();
            this.Fra_Camaras = new System.Windows.Forms.GroupBox();
            this.Tbl_Panel_Principal_Camaras = new System.Windows.Forms.TableLayoutPanel();
            this.Grid_Camaras = new System.Windows.Forms.DataGridView();
            this.Camara_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contrasenia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tbl_Botones = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Fra_Busqueda = new System.Windows.Forms.GroupBox();
            this.Tbl_Busqueda = new System.Windows.Forms.TableLayoutPanel();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Datos_Generales.SuspendLayout();
            this.Tbl_Columnas_Datos_Generales.SuspendLayout();
            this.Fra_Camaras.SuspendLayout();
            this.Tbl_Panel_Principal_Camaras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Camaras)).BeginInit();
            this.Tbl_Botones.SuspendLayout();
            this.Fra_Busqueda.SuspendLayout();
            this.Tbl_Busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Fra_Datos_Generales.Controls.Add(this.Tbl_Columnas_Datos_Generales);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(1, 7);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(719, 200);
            this.Fra_Datos_Generales.TabIndex = 0;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Tbl_Columnas_Datos_Generales
            // 
            this.Tbl_Columnas_Datos_Generales.ColumnCount = 2;
            this.Tbl_Columnas_Datos_Generales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Contrasenia, 1, 6);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Usuario, 1, 5);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Contrasenia, 0, 6);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Usuario, 0, 5);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Url, 1, 3);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Descripcion, 1, 2);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Nombre, 1, 1);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Cmb_Estatus, 1, 4);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Cmb_Tipo, 1, 7);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Tipo, 0, 7);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Estatus, 0, 4);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Url, 0, 3);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Descripcion, 0, 2);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Nombre, 0, 1);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_ID_Camara, 1, 0);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_ID_Camara, 0, 0);
            this.Tbl_Columnas_Datos_Generales.Location = new System.Drawing.Point(0, 21);
            this.Tbl_Columnas_Datos_Generales.Name = "Tbl_Columnas_Datos_Generales";
            this.Tbl_Columnas_Datos_Generales.RowCount = 8;
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Tbl_Columnas_Datos_Generales.Size = new System.Drawing.Size(719, 176);
            this.Tbl_Columnas_Datos_Generales.TabIndex = 0;
            // 
            // Txt_Contrasenia
            // 
            this.Txt_Contrasenia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Contrasenia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Contrasenia.Location = new System.Drawing.Point(146, 135);
            this.Txt_Contrasenia.MaxLength = 450;
            this.Txt_Contrasenia.Name = "Txt_Contrasenia";
            this.Txt_Contrasenia.PasswordChar = '*';
            this.Txt_Contrasenia.Size = new System.Drawing.Size(570, 22);
            this.Txt_Contrasenia.TabIndex = 63;
            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Usuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Usuario.Location = new System.Drawing.Point(146, 114);
            this.Txt_Usuario.MaxLength = 450;
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(570, 22);
            this.Txt_Usuario.TabIndex = 62;
            // 
            // Lbl_Contrasenia
            // 
            this.Lbl_Contrasenia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Contrasenia.AutoSize = true;
            this.Lbl_Contrasenia.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Contrasenia.Location = new System.Drawing.Point(3, 132);
            this.Lbl_Contrasenia.Name = "Lbl_Contrasenia";
            this.Lbl_Contrasenia.Size = new System.Drawing.Size(137, 20);
            this.Lbl_Contrasenia.TabIndex = 61;
            this.Lbl_Contrasenia.Text = "Contraseña";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Usuario.Location = new System.Drawing.Point(3, 111);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(137, 21);
            this.Lbl_Usuario.TabIndex = 60;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Txt_Url
            // 
            this.Txt_Url.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Url.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Url.Location = new System.Drawing.Point(146, 72);
            this.Txt_Url.MaxLength = 450;
            this.Txt_Url.Name = "Txt_Url";
            this.Txt_Url.Size = new System.Drawing.Size(570, 22);
            this.Txt_Url.TabIndex = 59;
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Descripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion.Location = new System.Drawing.Point(146, 45);
            this.Txt_Descripcion.MaxLength = 450;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.Size = new System.Drawing.Size(570, 22);
            this.Txt_Descripcion.TabIndex = 58;
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Nombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(146, 24);
            this.Txt_Nombre.MaxLength = 450;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(570, 22);
            this.Txt_Nombre.TabIndex = 57;
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(146, 93);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(570, 24);
            this.Cmb_Estatus.TabIndex = 56;
            // 
            // Cmb_Tipo
            // 
            this.Cmb_Tipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cmb_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo.FormattingEnabled = true;
            this.Cmb_Tipo.Items.AddRange(new object[] {
            "ENTRADA",
            "SALIDA"});
            this.Cmb_Tipo.Location = new System.Drawing.Point(146, 155);
            this.Cmb_Tipo.Name = "Cmb_Tipo";
            this.Cmb_Tipo.Size = new System.Drawing.Size(570, 24);
            this.Cmb_Tipo.TabIndex = 55;
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Tipo.Location = new System.Drawing.Point(3, 152);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(137, 24);
            this.Lbl_Tipo.TabIndex = 54;
            this.Lbl_Tipo.Text = "Tipo";
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Estatus.Location = new System.Drawing.Point(3, 90);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(137, 21);
            this.Lbl_Estatus.TabIndex = 53;
            this.Lbl_Estatus.Text = "Estatus";
            // 
            // Lbl_Url
            // 
            this.Lbl_Url.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Url.AutoSize = true;
            this.Lbl_Url.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Url.Location = new System.Drawing.Point(3, 69);
            this.Lbl_Url.Name = "Lbl_Url";
            this.Lbl_Url.Size = new System.Drawing.Size(137, 21);
            this.Lbl_Url.TabIndex = 52;
            this.Lbl_Url.Text = "Url";
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Descripcion.Location = new System.Drawing.Point(3, 42);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(137, 27);
            this.Lbl_Descripcion.TabIndex = 51;
            this.Lbl_Descripcion.Text = "Descripción";
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Nombre.Location = new System.Drawing.Point(3, 21);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(137, 21);
            this.Lbl_Nombre.TabIndex = 50;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Txt_ID_Camara
            // 
            this.Txt_ID_Camara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_ID_Camara.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Camara.Location = new System.Drawing.Point(146, 3);
            this.Txt_ID_Camara.MaxLength = 450;
            this.Txt_ID_Camara.Name = "Txt_ID_Camara";
            this.Txt_ID_Camara.ReadOnly = true;
            this.Txt_ID_Camara.Size = new System.Drawing.Size(570, 22);
            this.Txt_ID_Camara.TabIndex = 49;
            // 
            // Lbl_ID_Camara
            // 
            this.Lbl_ID_Camara.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_ID_Camara.AutoSize = true;
            this.Lbl_ID_Camara.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Camara.Location = new System.Drawing.Point(3, 0);
            this.Lbl_ID_Camara.Name = "Lbl_ID_Camara";
            this.Lbl_ID_Camara.Size = new System.Drawing.Size(137, 21);
            this.Lbl_ID_Camara.TabIndex = 48;
            this.Lbl_ID_Camara.Text = "ID Camara";
            // 
            // Fra_Camaras
            // 
            this.Fra_Camaras.Controls.Add(this.Tbl_Panel_Principal_Camaras);
            this.Fra_Camaras.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Camaras.Location = new System.Drawing.Point(1, 300);
            this.Fra_Camaras.Name = "Fra_Camaras";
            this.Fra_Camaras.Size = new System.Drawing.Size(716, 155);
            this.Fra_Camaras.TabIndex = 1;
            this.Fra_Camaras.TabStop = false;
            this.Fra_Camaras.Text = "Camaras";
            // 
            // Tbl_Panel_Principal_Camaras
            // 
            this.Tbl_Panel_Principal_Camaras.ColumnCount = 1;
            this.Tbl_Panel_Principal_Camaras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Panel_Principal_Camaras.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Panel_Principal_Camaras.Controls.Add(this.Grid_Camaras, 0, 0);
            this.Tbl_Panel_Principal_Camaras.Location = new System.Drawing.Point(0, 20);
            this.Tbl_Panel_Principal_Camaras.Name = "Tbl_Panel_Principal_Camaras";
            this.Tbl_Panel_Principal_Camaras.RowCount = 1;
            this.Tbl_Panel_Principal_Camaras.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Panel_Principal_Camaras.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Panel_Principal_Camaras.Size = new System.Drawing.Size(713, 129);
            this.Tbl_Panel_Principal_Camaras.TabIndex = 0;
            // 
            // Grid_Camaras
            // 
            this.Grid_Camaras.AllowUserToAddRows = false;
            this.Grid_Camaras.AllowUserToDeleteRows = false;
            this.Grid_Camaras.AllowUserToResizeRows = false;
            this.Grid_Camaras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Camaras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Camaras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Camaras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Camara_Id,
            this.Nombre,
            this.Descripcion,
            this.Url,
            this.Estatus,
            this.Usuario,
            this.Contrasenia,
            this.Tipo});
            this.Grid_Camaras.Location = new System.Drawing.Point(3, 3);
            this.Grid_Camaras.Name = "Grid_Camaras";
            this.Grid_Camaras.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Camaras.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Camaras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Camaras.Size = new System.Drawing.Size(707, 123);
            this.Grid_Camaras.TabIndex = 7;
            this.Grid_Camaras.SelectionChanged += new System.EventHandler(this.Grid_Camaras_SelectionChanged);
            // 
            // Camara_Id
            // 
            this.Camara_Id.DataPropertyName = "Camara_Id";
            this.Camara_Id.HeaderText = "ID Camara";
            this.Camara_Id.Name = "Camara_Id";
            this.Camara_Id.ReadOnly = true;
            this.Camara_Id.Width = 91;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 77;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 48;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 75;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 76;
            // 
            // Contrasenia
            // 
            this.Contrasenia.DataPropertyName = "Contrasenia";
            this.Contrasenia.HeaderText = "Contrasenia";
            this.Contrasenia.Name = "Contrasenia";
            this.Contrasenia.ReadOnly = true;
            this.Contrasenia.Visible = false;
            this.Contrasenia.Width = 101;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 56;
            // 
            // Tbl_Botones
            // 
            this.Tbl_Botones.ColumnCount = 5;
            this.Tbl_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Botones.Controls.Add(this.Btn_Eliminar, 0, 0);
            this.Tbl_Botones.Controls.Add(this.Btn_Modificar, 0, 0);
            this.Tbl_Botones.Controls.Add(this.Btn_Nuevo, 0, 0);
            this.Tbl_Botones.Controls.Add(this.Btn_Salir, 4, 0);
            this.Tbl_Botones.Controls.Add(this.Btn_Buscar, 2, 0);
            this.Tbl_Botones.Location = new System.Drawing.Point(10, 466);
            this.Tbl_Botones.Name = "Tbl_Botones";
            this.Tbl_Botones.RowCount = 1;
            this.Tbl_Botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Tbl_Botones.Size = new System.Drawing.Size(710, 50);
            this.Tbl_Botones.TabIndex = 2;
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(294, 3);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(122, 44);
            this.Btn_Eliminar.TabIndex = 11;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(152, 3);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(122, 44);
            this.Btn_Modificar.TabIndex = 9;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(10, 3);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(122, 44);
            this.Btn_Nuevo.TabIndex = 8;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(578, 3);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(122, 44);
            this.Btn_Salir.TabIndex = 13;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(436, 3);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(122, 44);
            this.Btn_Buscar.TabIndex = 12;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Fra_Busqueda
            // 
            this.Fra_Busqueda.Controls.Add(this.Tbl_Busqueda);
            this.Fra_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Busqueda.Location = new System.Drawing.Point(1, 196);
            this.Fra_Busqueda.Name = "Fra_Busqueda";
            this.Fra_Busqueda.Size = new System.Drawing.Size(719, 96);
            this.Fra_Busqueda.TabIndex = 3;
            this.Fra_Busqueda.TabStop = false;
            this.Fra_Busqueda.Text = "Búsqueda";
            // 
            // Tbl_Busqueda
            // 
            this.Tbl_Busqueda.ColumnCount = 4;
            this.Tbl_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Busqueda.Controls.Add(this.Btn_Regresar, 3, 1);
            this.Tbl_Busqueda.Controls.Add(this.Btn_Busqueda, 2, 1);
            this.Tbl_Busqueda.Controls.Add(this.Txt_Descripcion_Busqueda, 4, 0);
            this.Tbl_Busqueda.Controls.Add(this.Lbl_Descripcion_Busqueda, 2, 0);
            this.Tbl_Busqueda.Controls.Add(this.Cmb_Busqueda_Tipo, 1, 0);
            this.Tbl_Busqueda.Controls.Add(this.Lbl_Busqueda, 0, 0);
            this.Tbl_Busqueda.Location = new System.Drawing.Point(4, 14);
            this.Tbl_Busqueda.Name = "Tbl_Busqueda";
            this.Tbl_Busqueda.RowCount = 2;
            this.Tbl_Busqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Busqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Busqueda.Size = new System.Drawing.Size(710, 72);
            this.Tbl_Busqueda.TabIndex = 1;
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(534, 39);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(173, 30);
            this.Btn_Regresar.TabIndex = 6;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(357, 39);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(171, 30);
            this.Btn_Busqueda.TabIndex = 5;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(534, 3);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(173, 24);
            this.Txt_Descripcion_Busqueda.TabIndex = 4;
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(357, 0);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(171, 36);
            this.Lbl_Descripcion_Busqueda.TabIndex = 3;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "Id de Camara",
            "Nombre",
            "Descripcion",
            "Url",
            "Estatus"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(180, 3);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(171, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 2;
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(171, 36);
            this.Lbl_Busqueda.TabIndex = 1;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Frm_Cat_Camaras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(731, 530);
            this.Controls.Add(this.Tbl_Botones);
            this.Controls.Add(this.Fra_Camaras);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.Controls.Add(this.Fra_Busqueda);
            this.Name = "Frm_Cat_Camaras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camaras";
            this.Load += new System.EventHandler(this.Frm_Cat_Camaras_Load);
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Tbl_Columnas_Datos_Generales.ResumeLayout(false);
            this.Tbl_Columnas_Datos_Generales.PerformLayout();
            this.Fra_Camaras.ResumeLayout(false);
            this.Tbl_Panel_Principal_Camaras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Camaras)).EndInit();
            this.Tbl_Botones.ResumeLayout(false);
            this.Fra_Busqueda.ResumeLayout(false);
            this.Tbl_Busqueda.ResumeLayout(false);
            this.Tbl_Busqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.TableLayoutPanel Tbl_Columnas_Datos_Generales;
        private System.Windows.Forms.Label Lbl_ID_Camara;
        private System.Windows.Forms.TextBox Txt_ID_Camara;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.Label Lbl_Url;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.ComboBox Cmb_Tipo;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.TextBox Txt_Url;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.GroupBox Fra_Camaras;
        private System.Windows.Forms.TableLayoutPanel Tbl_Panel_Principal_Camaras;
        private System.Windows.Forms.DataGridView Grid_Camaras;
        private System.Windows.Forms.TableLayoutPanel Tbl_Botones;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.GroupBox Fra_Busqueda;
        private System.Windows.Forms.TableLayoutPanel Tbl_Busqueda;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.TextBox Txt_Contrasenia;
        private System.Windows.Forms.TextBox Txt_Usuario;
        private System.Windows.Forms.Label Lbl_Contrasenia;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Camara_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contrasenia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;

    }
}