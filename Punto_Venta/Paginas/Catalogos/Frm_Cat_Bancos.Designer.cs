namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Bancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Bancos));
            this.Fra_Bancos = new System.Windows.Forms.GroupBox();
            this.Grid_Bancos = new System.Windows.Forms.DataGridView();
            this.Banco_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Tbl_Controles_Busqueda = new System.Windows.Forms.TableLayoutPanel();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Ofd_Logo = new System.Windows.Forms.OpenFileDialog();
            this.Sfd_Logo = new System.Windows.Forms.SaveFileDialog();
            this.Tbl_Panel_Principal = new System.Windows.Forms.TableLayoutPanel();
            this.Tbl_Panel_Inferior_Botones = new System.Windows.Forms.TableLayoutPanel();
            this.Spl_Contenedor = new System.Windows.Forms.SplitContainer();
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Tbl_Columnas_Datos_Generales = new System.Windows.Forms.TableLayoutPanel();
            this.Lbl_Moneda = new System.Windows.Forms.Label();
            this.Cmb_Moneda = new System.Windows.Forms.ComboBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Cuenta = new System.Windows.Forms.Label();
            this.Txt_Cuenta = new System.Windows.Forms.TextBox();
            this.Lbl_Comision = new System.Windows.Forms.Label();
            this.Txt_Comision = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Banco = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Pic_Logo = new System.Windows.Forms.PictureBox();
            this.Btn_Buscar_Logo = new System.Windows.Forms.Button();
            this.Txt_ID_Banco = new System.Windows.Forms.TextBox();
            this.Fra_Bancos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Bancos)).BeginInit();
            this.Fra_Buscar.SuspendLayout();
            this.Tbl_Controles_Busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Tbl_Panel_Principal.SuspendLayout();
            this.Tbl_Panel_Inferior_Botones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).BeginInit();
            this.Spl_Contenedor.Panel1.SuspendLayout();
            this.Spl_Contenedor.Panel2.SuspendLayout();
            this.Spl_Contenedor.SuspendLayout();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Tbl_Columnas_Datos_Generales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Bancos
            // 
            this.Fra_Bancos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Fra_Bancos.Controls.Add(this.Grid_Bancos);
            this.Fra_Bancos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Bancos.Location = new System.Drawing.Point(3, 226);
            this.Fra_Bancos.Name = "Fra_Bancos";
            this.Fra_Bancos.Size = new System.Drawing.Size(719, 273);
            this.Fra_Bancos.TabIndex = 34;
            this.Fra_Bancos.TabStop = false;
            this.Fra_Bancos.Text = "Bancos";
            // 
            // Grid_Bancos
            // 
            this.Grid_Bancos.AllowUserToAddRows = false;
            this.Grid_Bancos.AllowUserToDeleteRows = false;
            this.Grid_Bancos.AllowUserToResizeRows = false;
            this.Grid_Bancos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Bancos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Bancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Bancos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Banco_ID,
            this.Moneda,
            this.Nombre,
            this.Cuenta,
            this.Comision,
            this.Imagen});
            this.Grid_Bancos.Location = new System.Drawing.Point(10, 20);
            this.Grid_Bancos.Name = "Grid_Bancos";
            this.Grid_Bancos.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Bancos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Bancos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Bancos.Size = new System.Drawing.Size(703, 247);
            this.Grid_Bancos.TabIndex = 6;
            this.Grid_Bancos.SelectionChanged += new System.EventHandler(this.Grid_Bancos_SelectionChanged);
            // 
            // Banco_ID
            // 
            this.Banco_ID.DataPropertyName = "Banco_ID";
            this.Banco_ID.HeaderText = "ID de Banco";
            this.Banco_ID.Name = "Banco_ID";
            this.Banco_ID.ReadOnly = true;
            this.Banco_ID.Width = 99;
            // 
            // Moneda
            // 
            this.Moneda.DataPropertyName = "Moneda";
            this.Moneda.HeaderText = "Moneda";
            this.Moneda.Name = "Moneda";
            this.Moneda.ReadOnly = true;
            this.Moneda.Width = 77;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 77;
            // 
            // Cuenta
            // 
            this.Cuenta.DataPropertyName = "Cuenta";
            this.Cuenta.HeaderText = "Cuenta";
            this.Cuenta.Name = "Cuenta";
            this.Cuenta.ReadOnly = true;
            this.Cuenta.Width = 72;
            // 
            // Comision
            // 
            this.Comision.DataPropertyName = "Comision";
            this.Comision.HeaderText = "Comisión";
            this.Comision.Name = "Comision";
            this.Comision.ReadOnly = true;
            this.Comision.Width = 85;
            // 
            // Imagen
            // 
            this.Imagen.DataPropertyName = "Ruta_Logo";
            this.Imagen.HeaderText = "Imagen";
            this.Imagen.Name = "Imagen";
            this.Imagen.ReadOnly = true;
            this.Imagen.Visible = false;
            this.Imagen.Width = 74;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(582, 3);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(127, 44);
            this.Btn_Salir.TabIndex = 11;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(296, 3);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(123, 44);
            this.Btn_Eliminar.TabIndex = 10;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(439, 3);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(123, 44);
            this.Btn_Buscar.TabIndex = 9;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(153, 3);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(123, 44);
            this.Btn_Modificar.TabIndex = 8;
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
            this.Btn_Nuevo.Size = new System.Drawing.Size(123, 44);
            this.Btn_Nuevo.TabIndex = 7;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Controls.Add(this.Tbl_Controles_Busqueda);
            this.Fra_Buscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(0, 0);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(719, 105);
            this.Fra_Buscar.TabIndex = 44;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            // 
            // Tbl_Controles_Busqueda
            // 
            this.Tbl_Controles_Busqueda.ColumnCount = 4;
            this.Tbl_Controles_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Controles_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Controles_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Controles_Busqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Tbl_Controles_Busqueda.Controls.Add(this.Lbl_Busqueda, 0, 0);
            this.Tbl_Controles_Busqueda.Controls.Add(this.Btn_Regresar, 3, 1);
            this.Tbl_Controles_Busqueda.Controls.Add(this.Cmb_Busqueda_Tipo, 1, 0);
            this.Tbl_Controles_Busqueda.Controls.Add(this.Btn_Busqueda, 2, 1);
            this.Tbl_Controles_Busqueda.Controls.Add(this.Lbl_Descripcion_Busqueda, 2, 0);
            this.Tbl_Controles_Busqueda.Controls.Add(this.Txt_Descripcion_Busqueda, 3, 0);
            this.Tbl_Controles_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_Controles_Busqueda.Location = new System.Drawing.Point(3, 17);
            this.Tbl_Controles_Busqueda.Name = "Tbl_Controles_Busqueda";
            this.Tbl_Controles_Busqueda.RowCount = 2;
            this.Tbl_Controles_Busqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Controles_Busqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Controles_Busqueda.Size = new System.Drawing.Size(713, 85);
            this.Tbl_Controles_Busqueda.TabIndex = 6;
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(3, 0);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(172, 42);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(537, 45);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(173, 37);
            this.Btn_Regresar.TabIndex = 5;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "Id de Banco",
            "Moneda",
            "Nombre",
            "Cuenta"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(181, 3);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(172, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 1;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(359, 45);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(172, 37);
            this.Btn_Busqueda.TabIndex = 4;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(359, 0);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(172, 42);
            this.Lbl_Descripcion_Busqueda.TabIndex = 2;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(537, 3);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(173, 24);
            this.Txt_Descripcion_Busqueda.TabIndex = 3;
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Ofd_Logo
            // 
            this.Ofd_Logo.FileName = "openFileDialog1";
            // 
            // Tbl_Panel_Principal
            // 
            this.Tbl_Panel_Principal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tbl_Panel_Principal.ColumnCount = 1;
            this.Tbl_Panel_Principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Panel_Principal.Controls.Add(this.Fra_Bancos, 0, 1);
            this.Tbl_Panel_Principal.Controls.Add(this.Tbl_Panel_Inferior_Botones, 0, 2);
            this.Tbl_Panel_Principal.Controls.Add(this.Spl_Contenedor, 0, 0);
            this.Tbl_Panel_Principal.Location = new System.Drawing.Point(0, 0);
            this.Tbl_Panel_Principal.Name = "Tbl_Panel_Principal";
            this.Tbl_Panel_Principal.RowCount = 3;
            this.Tbl_Panel_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.Tbl_Panel_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tbl_Panel_Principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.Tbl_Panel_Principal.Size = new System.Drawing.Size(725, 558);
            this.Tbl_Panel_Principal.TabIndex = 45;
            // 
            // Tbl_Panel_Inferior_Botones
            // 
            this.Tbl_Panel_Inferior_Botones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tbl_Panel_Inferior_Botones.ColumnCount = 5;
            this.Tbl_Panel_Inferior_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Panel_Inferior_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Panel_Inferior_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Panel_Inferior_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Panel_Inferior_Botones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Panel_Inferior_Botones.Controls.Add(this.Btn_Salir, 4, 0);
            this.Tbl_Panel_Inferior_Botones.Controls.Add(this.Btn_Buscar, 3, 0);
            this.Tbl_Panel_Inferior_Botones.Controls.Add(this.Btn_Modificar, 1, 0);
            this.Tbl_Panel_Inferior_Botones.Controls.Add(this.Btn_Eliminar, 2, 0);
            this.Tbl_Panel_Inferior_Botones.Controls.Add(this.Btn_Nuevo, 0, 0);
            this.Tbl_Panel_Inferior_Botones.Location = new System.Drawing.Point(3, 505);
            this.Tbl_Panel_Inferior_Botones.Name = "Tbl_Panel_Inferior_Botones";
            this.Tbl_Panel_Inferior_Botones.RowCount = 1;
            this.Tbl_Panel_Inferior_Botones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tbl_Panel_Inferior_Botones.Size = new System.Drawing.Size(719, 50);
            this.Tbl_Panel_Inferior_Botones.TabIndex = 0;
            // 
            // Spl_Contenedor
            // 
            this.Spl_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Spl_Contenedor.Location = new System.Drawing.Point(3, 3);
            this.Spl_Contenedor.Name = "Spl_Contenedor";
            this.Spl_Contenedor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Spl_Contenedor.Panel1
            // 
            this.Spl_Contenedor.Panel1.Controls.Add(this.Fra_Datos_Generales);
            // 
            // Spl_Contenedor.Panel2
            // 
            this.Spl_Contenedor.Panel2.Controls.Add(this.Fra_Buscar);
            this.Spl_Contenedor.Size = new System.Drawing.Size(719, 217);
            this.Spl_Contenedor.SplitterDistance = 108;
            this.Spl_Contenedor.TabIndex = 35;
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Tbl_Columnas_Datos_Generales);
            this.Fra_Datos_Generales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(0, 0);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(719, 108);
            this.Fra_Datos_Generales.TabIndex = 32;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Tbl_Columnas_Datos_Generales
            // 
            this.Tbl_Columnas_Datos_Generales.ColumnCount = 4;
            this.Tbl_Columnas_Datos_Generales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.Tbl_Columnas_Datos_Generales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Moneda, 0, 1);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Cmb_Moneda, 1, 1);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Nombre, 0, 2);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Nombre, 1, 2);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Cuenta, 0, 3);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Cuenta, 1, 3);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_Comision, 0, 4);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_Comision, 1, 4);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Lbl_ID_Banco, 0, 0);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.label2, 2, 0);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Pic_Logo, 3, 0);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Btn_Buscar_Logo, 3, 4);
            this.Tbl_Columnas_Datos_Generales.Controls.Add(this.Txt_ID_Banco, 1, 0);
            this.Tbl_Columnas_Datos_Generales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tbl_Columnas_Datos_Generales.Location = new System.Drawing.Point(3, 17);
            this.Tbl_Columnas_Datos_Generales.Name = "Tbl_Columnas_Datos_Generales";
            this.Tbl_Columnas_Datos_Generales.RowCount = 5;
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Tbl_Columnas_Datos_Generales.Size = new System.Drawing.Size(713, 88);
            this.Tbl_Columnas_Datos_Generales.TabIndex = 45;
            // 
            // Lbl_Moneda
            // 
            this.Lbl_Moneda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Moneda.AutoSize = true;
            this.Lbl_Moneda.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Moneda.Location = new System.Drawing.Point(3, 17);
            this.Lbl_Moneda.Name = "Lbl_Moneda";
            this.Lbl_Moneda.Size = new System.Drawing.Size(136, 17);
            this.Lbl_Moneda.TabIndex = 51;
            this.Lbl_Moneda.Text = "*Moneda";
            // 
            // Cmb_Moneda
            // 
            this.Cmb_Moneda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cmb_Moneda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Moneda.FormattingEnabled = true;
            this.Cmb_Moneda.Items.AddRange(new object[] {
            "PESO",
            "DOLAR"});
            this.Cmb_Moneda.Location = new System.Drawing.Point(145, 20);
            this.Cmb_Moneda.Name = "Cmb_Moneda";
            this.Cmb_Moneda.Size = new System.Drawing.Size(207, 24);
            this.Cmb_Moneda.TabIndex = 1;
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Nombre.Location = new System.Drawing.Point(3, 34);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(136, 17);
            this.Lbl_Nombre.TabIndex = 6;
            this.Lbl_Nombre.Text = "*Nombre";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Nombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(145, 37);
            this.Txt_Nombre.MaxLength = 450;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(207, 22);
            this.Txt_Nombre.TabIndex = 2;
            // 
            // Lbl_Cuenta
            // 
            this.Lbl_Cuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Cuenta.AutoSize = true;
            this.Lbl_Cuenta.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Cuenta.Location = new System.Drawing.Point(3, 51);
            this.Lbl_Cuenta.Name = "Lbl_Cuenta";
            this.Lbl_Cuenta.Size = new System.Drawing.Size(136, 17);
            this.Lbl_Cuenta.TabIndex = 53;
            this.Lbl_Cuenta.Text = "*Cuenta";
            // 
            // Txt_Cuenta
            // 
            this.Txt_Cuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Cuenta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Cuenta.Location = new System.Drawing.Point(145, 54);
            this.Txt_Cuenta.MaxLength = 450;
            this.Txt_Cuenta.Name = "Txt_Cuenta";
            this.Txt_Cuenta.Size = new System.Drawing.Size(207, 22);
            this.Txt_Cuenta.TabIndex = 3;
            // 
            // Lbl_Comision
            // 
            this.Lbl_Comision.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Comision.AutoSize = true;
            this.Lbl_Comision.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Comision.Location = new System.Drawing.Point(3, 68);
            this.Lbl_Comision.Name = "Lbl_Comision";
            this.Lbl_Comision.Size = new System.Drawing.Size(136, 20);
            this.Lbl_Comision.TabIndex = 55;
            this.Lbl_Comision.Text = "*Comisión";
            // 
            // Txt_Comision
            // 
            this.Txt_Comision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Comision.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Comision.Location = new System.Drawing.Point(145, 71);
            this.Txt_Comision.MaxLength = 450;
            this.Txt_Comision.Name = "Txt_Comision";
            this.Txt_Comision.Size = new System.Drawing.Size(207, 22);
            this.Txt_Comision.TabIndex = 4;
            this.Txt_Comision.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Comision_KeyPress);
            // 
            // Lbl_ID_Banco
            // 
            this.Lbl_ID_Banco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_ID_Banco.AutoSize = true;
            this.Lbl_ID_Banco.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Banco.Location = new System.Drawing.Point(3, 0);
            this.Lbl_ID_Banco.Name = "Lbl_ID_Banco";
            this.Lbl_ID_Banco.Size = new System.Drawing.Size(136, 17);
            this.Lbl_ID_Banco.TabIndex = 47;
            this.Lbl_ID_Banco.Text = "ID Banco";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.Location = new System.Drawing.Point(358, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "Logo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pic_Logo
            // 
            this.Pic_Logo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pic_Logo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Pic_Logo.Location = new System.Drawing.Point(500, 3);
            this.Pic_Logo.Name = "Pic_Logo";
            this.Tbl_Columnas_Datos_Generales.SetRowSpan(this.Pic_Logo, 4);
            this.Pic_Logo.Size = new System.Drawing.Size(210, 62);
            this.Pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Pic_Logo.TabIndex = 56;
            this.Pic_Logo.TabStop = false;
            // 
            // Btn_Buscar_Logo
            // 
            this.Btn_Buscar_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Buscar_Logo.Location = new System.Drawing.Point(500, 78);
            this.Btn_Buscar_Logo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.Btn_Buscar_Logo.MinimumSize = new System.Drawing.Size(50, 30);
            this.Btn_Buscar_Logo.Name = "Btn_Buscar_Logo";
            this.Btn_Buscar_Logo.Size = new System.Drawing.Size(210, 30);
            this.Btn_Buscar_Logo.TabIndex = 5;
            this.Btn_Buscar_Logo.Text = "Buscar Logo";
            this.Btn_Buscar_Logo.UseVisualStyleBackColor = true;
            this.Btn_Buscar_Logo.Click += new System.EventHandler(this.Btn_Buscar_Logo_Click);
            // 
            // Txt_ID_Banco
            // 
            this.Txt_ID_Banco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_ID_Banco.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Banco.Location = new System.Drawing.Point(145, 3);
            this.Txt_ID_Banco.MaxLength = 450;
            this.Txt_ID_Banco.Name = "Txt_ID_Banco";
            this.Txt_ID_Banco.ReadOnly = true;
            this.Txt_ID_Banco.Size = new System.Drawing.Size(207, 22);
            this.Txt_ID_Banco.TabIndex = 0;
            // 
            // Frm_Cat_Bancos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(725, 556);
            this.Controls.Add(this.Tbl_Panel_Principal);
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Bancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bancos";
            this.Load += new System.EventHandler(this.Frm_Cat_Bancos_Load);
            this.Fra_Bancos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Bancos)).EndInit();
            this.Fra_Buscar.ResumeLayout(false);
            this.Tbl_Controles_Busqueda.ResumeLayout(false);
            this.Tbl_Controles_Busqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Tbl_Panel_Principal.ResumeLayout(false);
            this.Tbl_Panel_Inferior_Botones.ResumeLayout(false);
            this.Spl_Contenedor.Panel1.ResumeLayout(false);
            this.Spl_Contenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).EndInit();
            this.Spl_Contenedor.ResumeLayout(false);
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Tbl_Columnas_Datos_Generales.ResumeLayout(false);
            this.Tbl_Columnas_Datos_Generales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Bancos;
        private System.Windows.Forms.DataGridView Grid_Bancos;
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
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.OpenFileDialog Ofd_Logo;
        private System.Windows.Forms.SaveFileDialog Sfd_Logo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Banco_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Moneda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imagen;
        private System.Windows.Forms.TableLayoutPanel Tbl_Panel_Principal;
        private System.Windows.Forms.TableLayoutPanel Tbl_Panel_Inferior_Botones;
        private System.Windows.Forms.SplitContainer Spl_Contenedor;
        private System.Windows.Forms.TableLayoutPanel Tbl_Controles_Busqueda;
        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.TableLayoutPanel Tbl_Columnas_Datos_Generales;
        private System.Windows.Forms.Label Lbl_Moneda;
        private System.Windows.Forms.ComboBox Cmb_Moneda;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Cuenta;
        private System.Windows.Forms.TextBox Txt_Cuenta;
        private System.Windows.Forms.Label Lbl_Comision;
        private System.Windows.Forms.TextBox Txt_Comision;
        private System.Windows.Forms.Label Lbl_ID_Banco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Pic_Logo;
        private System.Windows.Forms.Button Btn_Buscar_Logo;
        private System.Windows.Forms.TextBox Txt_ID_Banco;
    }
}