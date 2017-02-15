namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Cajas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Cajas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Txt_Serie_Caja = new System.Windows.Forms.TextBox();
            this.Lbl_Serie_Caja = new System.Windows.Forms.Label();
            this.Btn_Limpiar_Nombre_Equipo = new System.Windows.Forms.Button();
            this.Btn_Acutalizar_Nombre_Equipo = new System.Windows.Forms.Button();
            this.Txt_Nombre_Equipo = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre_Equipo = new System.Windows.Forms.Label();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Txt_Caja_Id = new System.Windows.Forms.TextBox();
            this.Lbl_Caja_Id = new System.Windows.Forms.Label();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Txt_Comentarios = new System.Windows.Forms.TextBox();
            this.Lbl_Comentarios = new System.Windows.Forms.Label();
            this.Txt_Numero_Caja = new System.Windows.Forms.TextBox();
            this.Lbl_Numero_Caja = new System.Windows.Forms.Label();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Fra_Cajas = new System.Windows.Forms.GroupBox();
            this.Grid_Cajas = new System.Windows.Forms.DataGridView();
            this.Caja_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero_Caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Cajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Cajas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Serie_Caja);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Serie_Caja);
            this.Fra_Datos_Generales.Controls.Add(this.Btn_Limpiar_Nombre_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Btn_Acutalizar_Nombre_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Nombre_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Nombre_Equipo);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Caja_Id);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Caja_Id);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Numero_Caja);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Numero_Caja);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(5, 0);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(780, 170);
            this.Fra_Datos_Generales.TabIndex = 37;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Txt_Serie_Caja
            // 
            this.Txt_Serie_Caja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Serie_Caja.Location = new System.Drawing.Point(400, 76);
            this.Txt_Serie_Caja.MaxLength = 1;
            this.Txt_Serie_Caja.Name = "Txt_Serie_Caja";
            this.Txt_Serie_Caja.Size = new System.Drawing.Size(150, 22);
            this.Txt_Serie_Caja.TabIndex = 53;
            this.Txt_Serie_Caja.Leave += new System.EventHandler(this.Txt_Serie_Leave);
            // 
            // Lbl_Serie_Caja
            // 
            this.Lbl_Serie_Caja.AutoSize = true;
            this.Lbl_Serie_Caja.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Serie_Caja.Location = new System.Drawing.Point(278, 76);
            this.Lbl_Serie_Caja.Name = "Lbl_Serie_Caja";
            this.Lbl_Serie_Caja.Size = new System.Drawing.Size(64, 14);
            this.Lbl_Serie_Caja.TabIndex = 52;
            this.Lbl_Serie_Caja.Text = "*Serie caja";
            // 
            // Btn_Limpiar_Nombre_Equipo
            // 
            this.Btn_Limpiar_Nombre_Equipo.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Limpiar_Nombre_Equipo.Location = new System.Drawing.Point(638, 33);
            this.Btn_Limpiar_Nombre_Equipo.Name = "Btn_Limpiar_Nombre_Equipo";
            this.Btn_Limpiar_Nombre_Equipo.Size = new System.Drawing.Size(75, 30);
            this.Btn_Limpiar_Nombre_Equipo.TabIndex = 51;
            this.Btn_Limpiar_Nombre_Equipo.UseVisualStyleBackColor = true;
            this.Btn_Limpiar_Nombre_Equipo.Click += new System.EventHandler(this.Btn_Limpiar_Nombre_Equipo_Click);
            // 
            // Btn_Acutalizar_Nombre_Equipo
            // 
            this.Btn_Acutalizar_Nombre_Equipo.Image = global::ERP_BASE.Properties.Resources.actualizar_detalle;
            this.Btn_Acutalizar_Nombre_Equipo.Location = new System.Drawing.Point(557, 33);
            this.Btn_Acutalizar_Nombre_Equipo.Name = "Btn_Acutalizar_Nombre_Equipo";
            this.Btn_Acutalizar_Nombre_Equipo.Size = new System.Drawing.Size(75, 30);
            this.Btn_Acutalizar_Nombre_Equipo.TabIndex = 50;
            this.Btn_Acutalizar_Nombre_Equipo.UseVisualStyleBackColor = true;
            this.Btn_Acutalizar_Nombre_Equipo.Click += new System.EventHandler(this.Btn_Acutalizar_Nombre_Equipo_Click);
            // 
            // Txt_Nombre_Equipo
            // 
            this.Txt_Nombre_Equipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre_Equipo.Location = new System.Drawing.Point(400, 42);
            this.Txt_Nombre_Equipo.MaxLength = 450;
            this.Txt_Nombre_Equipo.Name = "Txt_Nombre_Equipo";
            this.Txt_Nombre_Equipo.Size = new System.Drawing.Size(150, 22);
            this.Txt_Nombre_Equipo.TabIndex = 49;
            // 
            // Lbl_Nombre_Equipo
            // 
            this.Lbl_Nombre_Equipo.AutoSize = true;
            this.Lbl_Nombre_Equipo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Nombre_Equipo.Location = new System.Drawing.Point(278, 47);
            this.Lbl_Nombre_Equipo.Name = "Lbl_Nombre_Equipo";
            this.Lbl_Nombre_Equipo.Size = new System.Drawing.Size(116, 14);
            this.Lbl_Nombre_Equipo.TabIndex = 48;
            this.Lbl_Nombre_Equipo.Text = "*Nombre del equipo";
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(100, 71);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(150, 24);
            this.Cmb_Estatus.TabIndex = 2;
            this.Cmb_Estatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Estatus_KeyPress);
            // 
            // Txt_Caja_Id
            // 
            this.Txt_Caja_Id.Enabled = false;
            this.Txt_Caja_Id.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Caja_Id.Location = new System.Drawing.Point(100, 15);
            this.Txt_Caja_Id.MaxLength = 450;
            this.Txt_Caja_Id.Name = "Txt_Caja_Id";
            this.Txt_Caja_Id.Size = new System.Drawing.Size(150, 22);
            this.Txt_Caja_Id.TabIndex = 0;
            // 
            // Lbl_Caja_Id
            // 
            this.Lbl_Caja_Id.AutoSize = true;
            this.Lbl_Caja_Id.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Caja_Id.Location = new System.Drawing.Point(7, 20);
            this.Lbl_Caja_Id.Name = "Lbl_Caja_Id";
            this.Lbl_Caja_Id.Size = new System.Drawing.Size(55, 14);
            this.Lbl_Caja_Id.TabIndex = 47;
            this.Lbl_Caja_Id.Text = "ID de Caja";
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Estatus.Location = new System.Drawing.Point(6, 76);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 32;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Txt_Comentarios
            // 
            this.Txt_Comentarios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Comentarios.Location = new System.Drawing.Point(100, 101);
            this.Txt_Comentarios.MaxLength = 500;
            this.Txt_Comentarios.Multiline = true;
            this.Txt_Comentarios.Name = "Txt_Comentarios";
            this.Txt_Comentarios.Size = new System.Drawing.Size(675, 57);
            this.Txt_Comentarios.TabIndex = 3;
            // 
            // Lbl_Comentarios
            // 
            this.Lbl_Comentarios.AutoSize = true;
            this.Lbl_Comentarios.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Comentarios.Location = new System.Drawing.Point(6, 106);
            this.Lbl_Comentarios.Name = "Lbl_Comentarios";
            this.Lbl_Comentarios.Size = new System.Drawing.Size(67, 14);
            this.Lbl_Comentarios.TabIndex = 18;
            this.Lbl_Comentarios.Text = "Comentarios";
            // 
            // Txt_Numero_Caja
            // 
            this.Txt_Numero_Caja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Numero_Caja.Location = new System.Drawing.Point(100, 43);
            this.Txt_Numero_Caja.MaxLength = 450;
            this.Txt_Numero_Caja.Name = "Txt_Numero_Caja";
            this.Txt_Numero_Caja.Size = new System.Drawing.Size(150, 22);
            this.Txt_Numero_Caja.TabIndex = 1;
            this.Txt_Numero_Caja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numero_Caja_KeyPress);
            // 
            // Lbl_Numero_Caja
            // 
            this.Lbl_Numero_Caja.AutoSize = true;
            this.Lbl_Numero_Caja.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Numero_Caja.Location = new System.Drawing.Point(6, 48);
            this.Lbl_Numero_Caja.Name = "Lbl_Numero_Caja";
            this.Lbl_Numero_Caja.Size = new System.Drawing.Size(81, 14);
            this.Lbl_Numero_Caja.TabIndex = 6;
            this.Lbl_Numero_Caja.Text = "*Número Caja";
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(655, 367);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(94, 51);
            this.Btn_Salir.TabIndex = 9;
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
            this.Btn_Eliminar.Location = new System.Drawing.Point(513, 367);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(93, 51);
            this.Btn_Eliminar.TabIndex = 8;
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
            this.Btn_Buscar.Location = new System.Drawing.Point(364, 367);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(94, 51);
            this.Btn_Buscar.TabIndex = 7;
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
            this.Btn_Modificar.Location = new System.Drawing.Point(195, 367);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(96, 51);
            this.Btn_Modificar.TabIndex = 6;
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
            this.Btn_Nuevo.Location = new System.Drawing.Point(37, 367);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(97, 51);
            this.Btn_Nuevo.TabIndex = 5;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Fra_Cajas
            // 
            this.Fra_Cajas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Fra_Cajas.Controls.Add(this.Grid_Cajas);
            this.Fra_Cajas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Cajas.Location = new System.Drawing.Point(5, 184);
            this.Fra_Cajas.Name = "Fra_Cajas";
            this.Fra_Cajas.Size = new System.Drawing.Size(782, 182);
            this.Fra_Cajas.TabIndex = 39;
            this.Fra_Cajas.TabStop = false;
            this.Fra_Cajas.Text = "Cajas";
            // 
            // Grid_Cajas
            // 
            this.Grid_Cajas.AllowUserToAddRows = false;
            this.Grid_Cajas.AllowUserToDeleteRows = false;
            this.Grid_Cajas.AllowUserToResizeRows = false;
            this.Grid_Cajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Cajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Cajas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Caja_ID,
            this.Numero_Caja,
            this.Prefijo,
            this.Nombre_Equipo,
            this.Estatus,
            this.Comentarios});
            this.Grid_Cajas.Location = new System.Drawing.Point(10, 20);
            this.Grid_Cajas.Name = "Grid_Cajas";
            this.Grid_Cajas.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Cajas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Cajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Cajas.Size = new System.Drawing.Size(766, 156);
            this.Grid_Cajas.TabIndex = 4;
            this.Grid_Cajas.SelectionChanged += new System.EventHandler(this.Grid_Cajas_SelectionChanged);
            // 
            // Caja_ID
            // 
            this.Caja_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Caja_ID.DataPropertyName = "Caja_ID";
            this.Caja_ID.HeaderText = "Id de Caja";
            this.Caja_ID.Name = "Caja_ID";
            this.Caja_ID.ReadOnly = true;
            // 
            // Numero_Caja
            // 
            this.Numero_Caja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Numero_Caja.DataPropertyName = "Numero_Caja";
            this.Numero_Caja.HeaderText = "Número de Caja";
            this.Numero_Caja.Name = "Numero_Caja";
            this.Numero_Caja.ReadOnly = true;
            this.Numero_Caja.Width = 120;
            // 
            // Prefijo
            // 
            this.Prefijo.DataPropertyName = "Prefijo";
            this.Prefijo.HeaderText = "Nombre serie";
            this.Prefijo.Name = "Prefijo";
            this.Prefijo.ReadOnly = true;
            // 
            // Nombre_Equipo
            // 
            this.Nombre_Equipo.DataPropertyName = "Nombre_Equipo";
            this.Nombre_Equipo.HeaderText = "Equipo";
            this.Nombre_Equipo.Name = "Nombre_Equipo";
            this.Nombre_Equipo.ReadOnly = true;
            this.Nombre_Equipo.Width = 70;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 75;
            // 
            // Comentarios
            // 
            this.Comentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Comentarios.DataPropertyName = "Comentarios";
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.ReadOnly = true;
            this.Comentarios.Width = 400;
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.label1);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.label2);
            this.Fra_Buscar.Location = new System.Drawing.Point(6, 0);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(782, 185);
            this.Fra_Buscar.TabIndex = 5;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búscar";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(659, 102);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(75, 45);
            this.Btn_Regresar.TabIndex = 11;
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
            this.Btn_Busqueda.Location = new System.Drawing.Point(561, 102);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(75, 45);
            this.Btn_Busqueda.TabIndex = 10;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click_1);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(472, 41);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(298, 20);
            this.Txt_Descripcion_Busqueda.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(393, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "Id de Caja",
            "Numero de Caja",
            "Estatus",
            "Comentarios"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(91, 38);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(298, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "*Buscar por";
            // 
            // Frm_Cat_Cajas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(793, 430);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Cajas);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.Controls.Add(this.Fra_Buscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Cajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cajas";
            this.Load += new System.EventHandler(this.Frm_Cat_Cajas_Load);
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Cajas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Cajas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.TextBox Txt_Caja_Id;
        private System.Windows.Forms.Label Lbl_Caja_Id;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.TextBox Txt_Comentarios;
        private System.Windows.Forms.Label Lbl_Comentarios;
        private System.Windows.Forms.TextBox Txt_Numero_Caja;
        private System.Windows.Forms.Label Lbl_Numero_Caja;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.GroupBox Fra_Cajas;
        private System.Windows.Forms.DataGridView Grid_Cajas;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.TextBox Txt_Nombre_Equipo;
        private System.Windows.Forms.Label Lbl_Nombre_Equipo;
        private System.Windows.Forms.Button Btn_Acutalizar_Nombre_Equipo;
        private System.Windows.Forms.Button Btn_Limpiar_Nombre_Equipo;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Serie_Caja;
        private System.Windows.Forms.Label Lbl_Serie_Caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caja_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero_Caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefijo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
    }
}