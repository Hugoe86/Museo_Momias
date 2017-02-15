namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Apl_Roles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Apl_Roles));
            this.Lbl_Rol_Id = new System.Windows.Forms.Label();
            this.Txt_Rol_Id = new System.Windows.Forms.TextBox();
            this.Txt_Nombre_Rol = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_Descripcion_Rol = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Rol = new System.Windows.Forms.Label();
            this.Tab_Roles = new System.Windows.Forms.TabControl();
            this.Tab_Roles_Pagina_Roles = new System.Windows.Forms.TabPage();
            this.Grid_Roles = new System.Windows.Forms.DataGridView();
            this.ROL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DESCRIPCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tab_Roles_Pagina_Accesos = new System.Windows.Forms.TabPage();
            this.Grid_Acceso = new System.Windows.Forms.DataGridView();
            this.MENU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUB_MENU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUB_SUB_MENU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HABILITAR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HABILITAR_ALTA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HABILITAR_CAMBIO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HABILITAR_ELIMINAR = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HABILITAR_CONSULTA = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Error_Provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Grb_Generales = new System.Windows.Forms.GroupBox();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Tab_Roles.SuspendLayout();
            this.Tab_Roles_Pagina_Roles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Roles)).BeginInit();
            this.Tab_Roles_Pagina_Accesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Acceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).BeginInit();
            this.Grb_Generales.SuspendLayout();
            this.Fra_Buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Rol_Id
            // 
            this.Lbl_Rol_Id.AutoSize = true;
            this.Lbl_Rol_Id.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Rol_Id.Location = new System.Drawing.Point(5, 27);
            this.Lbl_Rol_Id.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Rol_Id.Name = "Lbl_Rol_Id";
            this.Lbl_Rol_Id.Size = new System.Drawing.Size(34, 14);
            this.Lbl_Rol_Id.TabIndex = 0;
            this.Lbl_Rol_Id.Text = "Rol ID";
            // 
            // Txt_Rol_Id
            // 
            this.Txt_Rol_Id.Enabled = false;
            this.Txt_Rol_Id.Font = new System.Drawing.Font("Arial", 9F);
            this.Txt_Rol_Id.Location = new System.Drawing.Point(82, 19);
            this.Txt_Rol_Id.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Txt_Rol_Id.MaxLength = 100;
            this.Txt_Rol_Id.Name = "Txt_Rol_Id";
            this.Txt_Rol_Id.Size = new System.Drawing.Size(300, 21);
            this.Txt_Rol_Id.TabIndex = 1;
            // 
            // Txt_Nombre_Rol
            // 
            this.Txt_Nombre_Rol.Enabled = false;
            this.Txt_Nombre_Rol.Font = new System.Drawing.Font("Arial", 9F);
            this.Txt_Nombre_Rol.Location = new System.Drawing.Point(82, 50);
            this.Txt_Nombre_Rol.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Txt_Nombre_Rol.MaxLength = 100;
            this.Txt_Nombre_Rol.Name = "Txt_Nombre_Rol";
            this.Txt_Nombre_Rol.Size = new System.Drawing.Size(300, 21);
            this.Txt_Nombre_Rol.TabIndex = 3;
            this.Txt_Nombre_Rol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            this.Txt_Nombre_Rol.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Requerido_Validating);
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre.Location = new System.Drawing.Point(6, 58);
            this.Lbl_Nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(55, 14);
            this.Lbl_Nombre.TabIndex = 2;
            this.Lbl_Nombre.Text = "*Nombre";
            // 
            // Txt_Descripcion_Rol
            // 
            this.Txt_Descripcion_Rol.Enabled = false;
            this.Txt_Descripcion_Rol.Font = new System.Drawing.Font("Arial", 9F);
            this.Txt_Descripcion_Rol.Location = new System.Drawing.Point(82, 89);
            this.Txt_Descripcion_Rol.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Txt_Descripcion_Rol.MaxLength = 250;
            this.Txt_Descripcion_Rol.Multiline = true;
            this.Txt_Descripcion_Rol.Name = "Txt_Descripcion_Rol";
            this.Txt_Descripcion_Rol.Size = new System.Drawing.Size(684, 79);
            this.Txt_Descripcion_Rol.TabIndex = 4;
            this.Txt_Descripcion_Rol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            this.Txt_Descripcion_Rol.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Requerido_Validating);
            // 
            // Lbl_Descripcion_Rol
            // 
            this.Lbl_Descripcion_Rol.AutoSize = true;
            this.Lbl_Descripcion_Rol.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Descripcion_Rol.Location = new System.Drawing.Point(5, 89);
            this.Lbl_Descripcion_Rol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Descripcion_Rol.Name = "Lbl_Descripcion_Rol";
            this.Lbl_Descripcion_Rol.Size = new System.Drawing.Size(64, 14);
            this.Lbl_Descripcion_Rol.TabIndex = 4;
            this.Lbl_Descripcion_Rol.Text = "Descripción";
            // 
            // Tab_Roles
            // 
            this.Tab_Roles.Controls.Add(this.Tab_Roles_Pagina_Roles);
            this.Tab_Roles.Controls.Add(this.Tab_Roles_Pagina_Accesos);
            this.Tab_Roles.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tab_Roles.Location = new System.Drawing.Point(6, 199);
            this.Tab_Roles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Tab_Roles.Name = "Tab_Roles";
            this.Tab_Roles.SelectedIndex = 0;
            this.Tab_Roles.Size = new System.Drawing.Size(776, 262);
            this.Tab_Roles.TabIndex = 6;
            // 
            // Tab_Roles_Pagina_Roles
            // 
            this.Tab_Roles_Pagina_Roles.Controls.Add(this.Grid_Roles);
            this.Tab_Roles_Pagina_Roles.Location = new System.Drawing.Point(4, 25);
            this.Tab_Roles_Pagina_Roles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Tab_Roles_Pagina_Roles.Name = "Tab_Roles_Pagina_Roles";
            this.Tab_Roles_Pagina_Roles.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Tab_Roles_Pagina_Roles.Size = new System.Drawing.Size(768, 233);
            this.Tab_Roles_Pagina_Roles.TabIndex = 0;
            this.Tab_Roles_Pagina_Roles.Text = "Roles";
            this.Tab_Roles_Pagina_Roles.UseVisualStyleBackColor = true;
            // 
            // Grid_Roles
            // 
            this.Grid_Roles.AllowUserToAddRows = false;
            this.Grid_Roles.AllowUserToDeleteRows = false;
            this.Grid_Roles.AllowUserToOrderColumns = true;
            this.Grid_Roles.AllowUserToResizeRows = false;
            this.Grid_Roles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Roles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Roles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROL_ID,
            this.NOMBRE,
            this.ESTATUS,
            this.DESCRIPCION});
            this.Grid_Roles.Location = new System.Drawing.Point(0, 0);
            this.Grid_Roles.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grid_Roles.Name = "Grid_Roles";
            this.Grid_Roles.ReadOnly = true;
            this.Grid_Roles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Roles.Size = new System.Drawing.Size(766, 237);
            this.Grid_Roles.TabIndex = 8;
            this.Grid_Roles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Roles_CellClick);
            // 
            // ROL_ID
            // 
            this.ROL_ID.DataPropertyName = "ROL_ID";
            this.ROL_ID.HeaderText = "ROL";
            this.ROL_ID.Name = "ROL_ID";
            this.ROL_ID.ReadOnly = true;
            this.ROL_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ROL_ID.Width = 55;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "NOMBRE";
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.NOMBRE.Width = 80;
            // 
            // ESTATUS
            // 
            this.ESTATUS.DataPropertyName = "ESTATUS";
            this.ESTATUS.HeaderText = "ESTATUS";
            this.ESTATUS.Name = "ESTATUS";
            this.ESTATUS.ReadOnly = true;
            this.ESTATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ESTATUS.Visible = false;
            // 
            // DESCRIPCION
            // 
            this.DESCRIPCION.DataPropertyName = "DESCRIPCION";
            this.DESCRIPCION.HeaderText = "DESCRIPCION";
            this.DESCRIPCION.Name = "DESCRIPCION";
            this.DESCRIPCION.ReadOnly = true;
            this.DESCRIPCION.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.DESCRIPCION.Visible = false;
            // 
            // Tab_Roles_Pagina_Accesos
            // 
            this.Tab_Roles_Pagina_Accesos.Controls.Add(this.Grid_Acceso);
            this.Tab_Roles_Pagina_Accesos.Location = new System.Drawing.Point(4, 25);
            this.Tab_Roles_Pagina_Accesos.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Tab_Roles_Pagina_Accesos.Name = "Tab_Roles_Pagina_Accesos";
            this.Tab_Roles_Pagina_Accesos.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Tab_Roles_Pagina_Accesos.Size = new System.Drawing.Size(768, 233);
            this.Tab_Roles_Pagina_Accesos.TabIndex = 1;
            this.Tab_Roles_Pagina_Accesos.Text = "Configurar accesos";
            this.Tab_Roles_Pagina_Accesos.UseVisualStyleBackColor = true;
            // 
            // Grid_Acceso
            // 
            this.Grid_Acceso.AllowUserToAddRows = false;
            this.Grid_Acceso.AllowUserToDeleteRows = false;
            this.Grid_Acceso.AllowUserToOrderColumns = true;
            this.Grid_Acceso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Acceso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MENU,
            this.SUB_MENU,
            this.SUB_SUB_MENU,
            this.TIPO,
            this.HABILITAR,
            this.HABILITAR_ALTA,
            this.HABILITAR_CAMBIO,
            this.HABILITAR_ELIMINAR,
            this.HABILITAR_CONSULTA});
            this.Grid_Acceso.Location = new System.Drawing.Point(0, 0);
            this.Grid_Acceso.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Grid_Acceso.Name = "Grid_Acceso";
            this.Grid_Acceso.Size = new System.Drawing.Size(768, 233);
            this.Grid_Acceso.TabIndex = 0;
            this.Grid_Acceso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Acceso_CellContentClick);
            // 
            // MENU
            // 
            this.MENU.HeaderText = "Menu";
            this.MENU.Name = "MENU";
            this.MENU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.MENU.Width = 70;
            // 
            // SUB_MENU
            // 
            this.SUB_MENU.HeaderText = "Submenu";
            this.SUB_MENU.Name = "SUB_MENU";
            this.SUB_MENU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SUB_MENU.Width = 90;
            // 
            // SUB_SUB_MENU
            // 
            this.SUB_SUB_MENU.HeaderText = "Subsubmenu";
            this.SUB_SUB_MENU.Name = "SUB_SUB_MENU";
            this.SUB_SUB_MENU.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SUB_SUB_MENU.Width = 115;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "Tipo";
            this.TIPO.Name = "TIPO";
            this.TIPO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TIPO.Visible = false;
            // 
            // HABILITAR
            // 
            this.HABILITAR.HeaderText = "Habilitar";
            this.HABILITAR.Name = "HABILITAR";
            this.HABILITAR.Width = 70;
            // 
            // HABILITAR_ALTA
            // 
            this.HABILITAR_ALTA.HeaderText = "Alta";
            this.HABILITAR_ALTA.Name = "HABILITAR_ALTA";
            this.HABILITAR_ALTA.Width = 50;
            // 
            // HABILITAR_CAMBIO
            // 
            this.HABILITAR_CAMBIO.HeaderText = "Cambio";
            this.HABILITAR_CAMBIO.Name = "HABILITAR_CAMBIO";
            this.HABILITAR_CAMBIO.Width = 60;
            // 
            // HABILITAR_ELIMINAR
            // 
            this.HABILITAR_ELIMINAR.HeaderText = "Eliminar";
            this.HABILITAR_ELIMINAR.Name = "HABILITAR_ELIMINAR";
            this.HABILITAR_ELIMINAR.Width = 60;
            // 
            // HABILITAR_CONSULTA
            // 
            this.HABILITAR_CONSULTA.HeaderText = "Consultar";
            this.HABILITAR_CONSULTA.Name = "HABILITAR_CONSULTA";
            this.HABILITAR_CONSULTA.Width = 70;
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Estatus.Location = new System.Drawing.Point(389, 23);
            this.Lbl_Estatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 7;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Enabled = false;
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9F);
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "< SELECCIONE >",
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(466, 18);
            this.Cmb_Estatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(300, 23);
            this.Cmb_Estatus.TabIndex = 2;
            this.Cmb_Estatus.Validating += new System.ComponentModel.CancelEventHandler(this.Cmb_Requerido_Validating);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.Location = new System.Drawing.Point(682, 467);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(100, 60);
            this.Btn_Salir.TabIndex = 9;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.Location = new System.Drawing.Point(513, 467);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(100, 60);
            this.Btn_Eliminar.TabIndex = 8;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.Location = new System.Drawing.Point(169, 467);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(100, 60);
            this.Btn_Modificar.TabIndex = 6;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.Location = new System.Drawing.Point(14, 466);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(100, 60);
            this.Btn_Nuevo.TabIndex = 5;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Error_Provider
            // 
            this.Error_Provider.BlinkRate = 150;
            this.Error_Provider.ContainerControl = this;
            // 
            // Grb_Generales
            // 
            this.Grb_Generales.Controls.Add(this.Lbl_Rol_Id);
            this.Grb_Generales.Controls.Add(this.Txt_Rol_Id);
            this.Grb_Generales.Controls.Add(this.Lbl_Nombre);
            this.Grb_Generales.Controls.Add(this.Txt_Nombre_Rol);
            this.Grb_Generales.Controls.Add(this.Lbl_Descripcion_Rol);
            this.Grb_Generales.Controls.Add(this.Cmb_Estatus);
            this.Grb_Generales.Controls.Add(this.Txt_Descripcion_Rol);
            this.Grb_Generales.Controls.Add(this.Lbl_Estatus);
            this.Grb_Generales.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.Grb_Generales.Location = new System.Drawing.Point(6, 1);
            this.Grb_Generales.Name = "Grb_Generales";
            this.Grb_Generales.Size = new System.Drawing.Size(776, 192);
            this.Grb_Generales.TabIndex = 13;
            this.Grb_Generales.TabStop = false;
            this.Grb_Generales.Text = "Datos Generales";
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Buscar.Location = new System.Drawing.Point(339, 467);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(100, 60);
            this.Btn_Buscar.TabIndex = 7;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(6, 7);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(776, 180);
            this.Fra_Buscar.TabIndex = 33;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            this.Fra_Buscar.Visible = false;
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(688, 67);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(77, 50);
            this.Btn_Regresar.TabIndex = 13;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Busqueda.Enabled = false;
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(526, 67);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(77, 50);
            this.Btn_Busqueda.TabIndex = 12;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(465, 38);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(300, 23);
            this.Txt_Descripcion_Busqueda.TabIndex = 11;
            this.Txt_Descripcion_Busqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion.Location = new System.Drawing.Point(384, 42);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(76, 14);
            this.Lbl_Descripcion.TabIndex = 2;
            this.Lbl_Descripcion.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cmb_Busqueda_Tipo.DisplayMember = "NOMBRE_CORTO";
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9F);
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(78, 38);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(300, 23);
            this.Cmb_Busqueda_Tipo.TabIndex = 10;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(7, 42);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(71, 14);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Frm_Apl_Roles
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 572);
            this.Controls.Add(this.Grb_Generales);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Tab_Roles);
            this.Controls.Add(this.Fra_Buscar);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Apl_Roles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Catálogo de roles";
            this.Load += new System.EventHandler(this.Frm_Apl_Roles_Load);
            this.Tab_Roles.ResumeLayout(false);
            this.Tab_Roles_Pagina_Roles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Roles)).EndInit();
            this.Tab_Roles_Pagina_Accesos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Acceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Provider)).EndInit();
            this.Grb_Generales.ResumeLayout(false);
            this.Grb_Generales.PerformLayout();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Rol_Id;
        private System.Windows.Forms.TextBox Txt_Rol_Id;
        private System.Windows.Forms.TextBox Txt_Nombre_Rol;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.TextBox Txt_Descripcion_Rol;
        private System.Windows.Forms.Label Lbl_Descripcion_Rol;
        private System.Windows.Forms.TabControl Tab_Roles;
        private System.Windows.Forms.TabPage Tab_Roles_Pagina_Roles;
        private System.Windows.Forms.TabPage Tab_Roles_Pagina_Accesos;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView Grid_Acceso;
        internal System.Windows.Forms.DataGridView Grid_Roles;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn DESCRIPCION;
        private System.Windows.Forms.DataGridViewTextBoxColumn MENU;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUB_MENU;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUB_SUB_MENU;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HABILITAR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HABILITAR_ALTA;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HABILITAR_CAMBIO;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HABILITAR_ELIMINAR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HABILITAR_CONSULTA;
        private System.Windows.Forms.ErrorProvider Error_Provider;
        private System.Windows.Forms.GroupBox Grb_Generales;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;
    }
}