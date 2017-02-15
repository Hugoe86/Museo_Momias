namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Turnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Turnos));
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Lbl_Fijo = new System.Windows.Forms.Label();
            this.Cmb_Fijo = new System.Windows.Forms.ComboBox();
            this.Lbl_Hora_Cierre = new System.Windows.Forms.Label();
            this.Cmb_Hora_Cierre = new System.Windows.Forms.ComboBox();
            this.Cmb_Hora_Inicio = new System.Windows.Forms.ComboBox();
            this.Lbl_Hora_Inicio = new System.Windows.Forms.Label();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Txt_ID_Turno = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Producto = new System.Windows.Forms.Label();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Txt_Comentarios = new System.Windows.Forms.TextBox();
            this.Lbl_Comentarios = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Fra_Turnos = new System.Windows.Forms.GroupBox();
            this.Grid_Turnos = new System.Windows.Forms.DataGridView();
            this.Turno_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora_Cierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fijo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Turnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Turnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Fijo);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Fijo);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Hora_Cierre);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Hora_Cierre);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Hora_Inicio);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Hora_Inicio);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_ID_Turno);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_ID_Producto);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Nombre);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Nombre);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(5, 12);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(782, 261);
            this.Fra_Datos_Generales.TabIndex = 32;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Lbl_Fijo
            // 
            this.Lbl_Fijo.AutoSize = true;
            this.Lbl_Fijo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Fijo.Location = new System.Drawing.Point(6, 232);
            this.Lbl_Fijo.Name = "Lbl_Fijo";
            this.Lbl_Fijo.Size = new System.Drawing.Size(30, 14);
            this.Lbl_Fijo.TabIndex = 55;
            this.Lbl_Fijo.Text = "*Fijo";
            // 
            // Cmb_Fijo
            // 
            this.Cmb_Fijo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Fijo.FormattingEnabled = true;
            this.Cmb_Fijo.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.Cmb_Fijo.Location = new System.Drawing.Point(100, 227);
            this.Cmb_Fijo.Name = "Cmb_Fijo";
            this.Cmb_Fijo.Size = new System.Drawing.Size(64, 24);
            this.Cmb_Fijo.TabIndex = 7;
            this.Cmb_Fijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Fijo_KeyPress);
            // 
            // Lbl_Hora_Cierre
            // 
            this.Lbl_Hora_Cierre.AutoSize = true;
            this.Lbl_Hora_Cierre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Hora_Cierre.Location = new System.Drawing.Point(7, 170);
            this.Lbl_Hora_Cierre.Name = "Lbl_Hora_Cierre";
            this.Lbl_Hora_Cierre.Size = new System.Drawing.Size(74, 14);
            this.Lbl_Hora_Cierre.TabIndex = 53;
            this.Lbl_Hora_Cierre.Text = "*Hora Cierre";
            // 
            // Cmb_Hora_Cierre
            // 
            this.Cmb_Hora_Cierre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Hora_Cierre.FormattingEnabled = true;
            this.Cmb_Hora_Cierre.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.Cmb_Hora_Cierre.Location = new System.Drawing.Point(100, 165);
            this.Cmb_Hora_Cierre.Name = "Cmb_Hora_Cierre";
            this.Cmb_Hora_Cierre.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Hora_Cierre.TabIndex = 5;
            this.Cmb_Hora_Cierre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Hora_Cierre_KeyPress);
            // 
            // Cmb_Hora_Inicio
            // 
            this.Cmb_Hora_Inicio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Hora_Inicio.FormattingEnabled = true;
            this.Cmb_Hora_Inicio.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.Cmb_Hora_Inicio.Location = new System.Drawing.Point(100, 135);
            this.Cmb_Hora_Inicio.Name = "Cmb_Hora_Inicio";
            this.Cmb_Hora_Inicio.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Hora_Inicio.TabIndex = 4;
            this.Cmb_Hora_Inicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Hora_Inicio_KeyPress);
            // 
            // Lbl_Hora_Inicio
            // 
            this.Lbl_Hora_Inicio.AutoSize = true;
            this.Lbl_Hora_Inicio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Hora_Inicio.Location = new System.Drawing.Point(6, 140);
            this.Lbl_Hora_Inicio.Name = "Lbl_Hora_Inicio";
            this.Lbl_Hora_Inicio.Size = new System.Drawing.Size(68, 14);
            this.Lbl_Hora_Inicio.TabIndex = 50;
            this.Lbl_Hora_Inicio.Text = "*Hora Inicio";
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(100, 197);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Estatus.TabIndex = 6;
            this.Cmb_Estatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Estatus_KeyPress);
            // 
            // Txt_ID_Turno
            // 
            this.Txt_ID_Turno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Turno.Location = new System.Drawing.Point(100, 15);
            this.Txt_ID_Turno.MaxLength = 450;
            this.Txt_ID_Turno.Name = "Txt_ID_Turno";
            this.Txt_ID_Turno.ReadOnly = true;
            this.Txt_ID_Turno.Size = new System.Drawing.Size(140, 22);
            this.Txt_ID_Turno.TabIndex = 1;
            // 
            // Lbl_ID_Producto
            // 
            this.Lbl_ID_Producto.AutoSize = true;
            this.Lbl_ID_Producto.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Producto.Location = new System.Drawing.Point(7, 20);
            this.Lbl_ID_Producto.Name = "Lbl_ID_Producto";
            this.Lbl_ID_Producto.Size = new System.Drawing.Size(47, 14);
            this.Lbl_ID_Producto.TabIndex = 47;
            this.Lbl_ID_Producto.Text = "ID Turno";
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Estatus.Location = new System.Drawing.Point(6, 202);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 32;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Txt_Comentarios
            // 
            this.Txt_Comentarios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Comentarios.Location = new System.Drawing.Point(100, 71);
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
            this.Lbl_Comentarios.Location = new System.Drawing.Point(6, 76);
            this.Lbl_Comentarios.Name = "Lbl_Comentarios";
            this.Lbl_Comentarios.Size = new System.Drawing.Size(67, 14);
            this.Lbl_Comentarios.TabIndex = 18;
            this.Lbl_Comentarios.Text = "Comentarios";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(100, 43);
            this.Txt_Nombre.MaxLength = 450;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(675, 22);
            this.Txt_Nombre.TabIndex = 2;
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
            // Fra_Turnos
            // 
            this.Fra_Turnos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Fra_Turnos.Controls.Add(this.Grid_Turnos);
            this.Fra_Turnos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Turnos.Location = new System.Drawing.Point(5, 279);
            this.Fra_Turnos.Name = "Fra_Turnos";
            this.Fra_Turnos.Size = new System.Drawing.Size(782, 152);
            this.Fra_Turnos.TabIndex = 33;
            this.Fra_Turnos.TabStop = false;
            this.Fra_Turnos.Text = "Productos";
            // 
            // Grid_Turnos
            // 
            this.Grid_Turnos.AllowUserToAddRows = false;
            this.Grid_Turnos.AllowUserToDeleteRows = false;
            this.Grid_Turnos.AllowUserToResizeRows = false;
            this.Grid_Turnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Turnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Turno_ID,
            this.Nombre,
            this.Comentarios,
            this.Hora_Inicio,
            this.Hora_Cierre,
            this.Estatus,
            this.Fijo});
            this.Grid_Turnos.Location = new System.Drawing.Point(10, 20);
            this.Grid_Turnos.Name = "Grid_Turnos";
            this.Grid_Turnos.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Turnos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Turnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Turnos.Size = new System.Drawing.Size(766, 126);
            this.Grid_Turnos.TabIndex = 0;
            this.Grid_Turnos.SelectionChanged += new System.EventHandler(this.Grid_Turnos_SelectionChanged);
            // 
            // Turno_ID
            // 
            this.Turno_ID.DataPropertyName = "Turno_ID";
            this.Turno_ID.HeaderText = "ID del Turno";
            this.Turno_ID.Name = "Turno_ID";
            this.Turno_ID.ReadOnly = true;
            this.Turno_ID.Width = 98;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 77;
            // 
            // Comentarios
            // 
            this.Comentarios.DataPropertyName = "Comentarios";
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.ReadOnly = true;
            this.Comentarios.Width = 105;
            // 
            // Hora_Inicio
            // 
            this.Hora_Inicio.DataPropertyName = "Hora_Inicio";
            this.Hora_Inicio.HeaderText = "Hora de Inicio";
            this.Hora_Inicio.Name = "Hora_Inicio";
            this.Hora_Inicio.ReadOnly = true;
            this.Hora_Inicio.Width = 109;
            // 
            // Hora_Cierre
            // 
            this.Hora_Cierre.DataPropertyName = "Hora_Cierre";
            this.Hora_Cierre.HeaderText = "Hora de Cierre";
            this.Hora_Cierre.Name = "Hora_Cierre";
            this.Hora_Cierre.ReadOnly = true;
            this.Hora_Cierre.Width = 114;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 75;
            // 
            // Fijo
            // 
            this.Fijo.DataPropertyName = "Fijo";
            this.Fijo.HeaderText = "Fijio";
            this.Fijo.Name = "Fijo";
            this.Fijo.ReadOnly = true;
            this.Fijo.Width = 54;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(653, 437);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(94, 51);
            this.Btn_Salir.TabIndex = 12;
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
            this.Btn_Eliminar.Location = new System.Drawing.Point(511, 437);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(93, 51);
            this.Btn_Eliminar.TabIndex = 11;
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
            this.Btn_Buscar.Location = new System.Drawing.Point(362, 437);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(94, 51);
            this.Btn_Buscar.TabIndex = 10;
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
            this.Btn_Modificar.Location = new System.Drawing.Point(193, 437);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(96, 51);
            this.Btn_Modificar.TabIndex = 9;
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
            this.Btn_Nuevo.Location = new System.Drawing.Point(35, 437);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(97, 51);
            this.Btn_Nuevo.TabIndex = 8;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
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
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(5, 12);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(782, 261);
            this.Fra_Buscar.TabIndex = 42;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(664, 145);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(77, 45);
            this.Btn_Regresar.TabIndex = 16;
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
            this.Btn_Busqueda.Location = new System.Drawing.Point(566, 145);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(77, 45);
            this.Btn_Busqueda.TabIndex = 15;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(477, 84);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(300, 20);
            this.Txt_Descripcion_Busqueda.TabIndex = 14;
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(398, 86);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(80, 15);
            this.Lbl_Descripcion_Busqueda.TabIndex = 2;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "Id de Turno",
            "Nombre",
            "Estatus"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(96, 81);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(300, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 13;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(18, 84);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Frm_Cat_Turnos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(795, 514);
            this.Controls.Add(this.Fra_Buscar);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Turnos);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Turnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.Frm_Cat_Turnos_Load);
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Turnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Turnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.TextBox Txt_ID_Turno;
        private System.Windows.Forms.Label Lbl_ID_Producto;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.TextBox Txt_Comentarios;
        private System.Windows.Forms.Label Lbl_Comentarios;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.ComboBox Cmb_Hora_Cierre;
        private System.Windows.Forms.ComboBox Cmb_Hora_Inicio;
        private System.Windows.Forms.Label Lbl_Hora_Inicio;
        private System.Windows.Forms.Label Lbl_Hora_Cierre;
        private System.Windows.Forms.Label Lbl_Fijo;
        private System.Windows.Forms.ComboBox Cmb_Fijo;
        private System.Windows.Forms.GroupBox Fra_Turnos;
        private System.Windows.Forms.DataGridView Grid_Turnos;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Inicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora_Cierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fijo;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;
    }
}