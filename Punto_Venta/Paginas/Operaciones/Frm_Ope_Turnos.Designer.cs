namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Ope_Turnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ope_Turnos));
            this.Fra_Turnos = new System.Windows.Forms.GroupBox();
            this.Grid_Turnos = new System.Windows.Forms.DataGridView();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Lbl_Fecha_Hora_Inicio = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Turno = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Turno = new System.Windows.Forms.Label();
            this.Cmb_Turno = new System.Windows.Forms.ComboBox();
            this.Lbl_No_Turno = new System.Windows.Forms.Label();
            this.Txt_No_Turno = new System.Windows.Forms.TextBox();
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Chk_Enviar_Ventas_Dia = new System.Windows.Forms.CheckBox();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Dtp_Busqueda_Desde_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Busqueda_Hasta_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Busqueda_Desde_Fecha = new System.Windows.Forms.Label();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Lbl_Busqueda_Hasta_Fecha = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Estatus = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda_Estatus = new System.Windows.Forms.Label();
            this.Lbl_Horario = new System.Windows.Forms.Label();
            this.Txt_Horario = new System.Windows.Forms.TextBox();
            this.Txt_Fecha_Hora_Cierre = new System.Windows.Forms.TextBox();
            this.Lbl_Fecha_Hora_Cierre = new System.Windows.Forms.Label();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Fra_Turnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Turnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fra_Turnos
            // 
            this.Fra_Turnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Fra_Turnos.Controls.Add(this.Grid_Turnos);
            this.Fra_Turnos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Turnos.Location = new System.Drawing.Point(5, 155);
            this.Fra_Turnos.Name = "Fra_Turnos";
            this.Fra_Turnos.Size = new System.Drawing.Size(777, 194);
            this.Fra_Turnos.TabIndex = 13;
            this.Fra_Turnos.TabStop = false;
            this.Fra_Turnos.Text = "Turnos";
            // 
            // Grid_Turnos
            // 
            this.Grid_Turnos.AllowUserToAddRows = false;
            this.Grid_Turnos.AllowUserToDeleteRows = false;
            this.Grid_Turnos.AllowUserToResizeRows = false;
            this.Grid_Turnos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Turnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Turnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Turnos.Location = new System.Drawing.Point(6, 20);
            this.Grid_Turnos.Name = "Grid_Turnos";
            this.Grid_Turnos.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Turnos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Turnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Turnos.Size = new System.Drawing.Size(765, 168);
            this.Grid_Turnos.TabIndex = 6;
            this.Grid_Turnos.SelectionChanged += new System.EventHandler(this.Grid_Turnos_SelectionChanged);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(682, 363);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(94, 51);
            this.Btn_Salir.TabIndex = 10;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(574, 363);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(94, 51);
            this.Btn_Buscar.TabIndex = 9;
            this.Btn_Buscar.Text = "Búsqueda";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(464, 363);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(96, 51);
            this.Btn_Modificar.TabIndex = 8;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Estatus.Location = new System.Drawing.Point(406, 23);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 2;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ABIERTO",
            "CERRADO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(486, 20);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(280, 24);
            this.Cmb_Estatus.TabIndex = 1;
            this.Cmb_Estatus.Validating += new System.ComponentModel.CancelEventHandler(this.Cmb_Validating);
            // 
            // Lbl_Fecha_Hora_Inicio
            // 
            this.Lbl_Fecha_Hora_Inicio.AutoSize = true;
            this.Lbl_Fecha_Hora_Inicio.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Fecha_Hora_Inicio.Location = new System.Drawing.Point(11, 53);
            this.Lbl_Fecha_Hora_Inicio.Name = "Lbl_Fecha_Hora_Inicio";
            this.Lbl_Fecha_Hora_Inicio.Size = new System.Drawing.Size(31, 14);
            this.Lbl_Fecha_Hora_Inicio.TabIndex = 16;
            this.Lbl_Fecha_Hora_Inicio.Text = "Inicio";
            // 
            // Dtp_Fecha_Turno
            // 
            this.Dtp_Fecha_Turno.CalendarFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha_Turno.CustomFormat = "dd/MMM/yyyy hh:mm tt";
            this.Dtp_Fecha_Turno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha_Turno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Turno.Location = new System.Drawing.Point(91, 50);
            this.Dtp_Fecha_Turno.Name = "Dtp_Fecha_Turno";
            this.Dtp_Fecha_Turno.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dtp_Fecha_Turno.Size = new System.Drawing.Size(280, 22);
            this.Dtp_Fecha_Turno.TabIndex = 2;
            // 
            // Lbl_Turno
            // 
            this.Lbl_Turno.AutoSize = true;
            this.Lbl_Turno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Turno.Location = new System.Drawing.Point(11, 83);
            this.Lbl_Turno.Name = "Lbl_Turno";
            this.Lbl_Turno.Size = new System.Drawing.Size(43, 14);
            this.Lbl_Turno.TabIndex = 4;
            this.Lbl_Turno.Text = "*Turno";
            // 
            // Cmb_Turno
            // 
            this.Cmb_Turno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Turno.FormattingEnabled = true;
            this.Cmb_Turno.Location = new System.Drawing.Point(91, 78);
            this.Cmb_Turno.MaxLength = 100;
            this.Cmb_Turno.Name = "Cmb_Turno";
            this.Cmb_Turno.Size = new System.Drawing.Size(280, 24);
            this.Cmb_Turno.TabIndex = 4;
            this.Cmb_Turno.SelectedIndexChanged += new System.EventHandler(this.Cmb_Turno_SelectedIndexChanged);
            // 
            // Lbl_No_Turno
            // 
            this.Lbl_No_Turno.AutoSize = true;
            this.Lbl_No_Turno.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_No_Turno.Location = new System.Drawing.Point(11, 25);
            this.Lbl_No_Turno.Name = "Lbl_No_Turno";
            this.Lbl_No_Turno.Size = new System.Drawing.Size(51, 14);
            this.Lbl_No_Turno.TabIndex = 22;
            this.Lbl_No_Turno.Text = "No Turno";
            // 
            // Txt_No_Turno
            // 
            this.Txt_No_Turno.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_No_Turno.Location = new System.Drawing.Point(91, 20);
            this.Txt_No_Turno.Name = "Txt_No_Turno";
            this.Txt_No_Turno.Size = new System.Drawing.Size(280, 21);
            this.Txt_No_Turno.TabIndex = 0;
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Chk_Enviar_Ventas_Dia);
            this.Fra_Datos_Generales.Controls.Add(this.Fra_Buscar);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Horario);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Horario);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Fecha_Hora_Cierre);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Fecha_Hora_Cierre);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_No_Turno);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_No_Turno);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Turno);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Turno);
            this.Fra_Datos_Generales.Controls.Add(this.Dtp_Fecha_Turno);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Fecha_Hora_Inicio);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(5, 19);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(777, 130);
            this.Fra_Datos_Generales.TabIndex = 1;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Chk_Enviar_Ventas_Dia
            // 
            this.Chk_Enviar_Ventas_Dia.AutoSize = true;
            this.Chk_Enviar_Ventas_Dia.Location = new System.Drawing.Point(485, 105);
            this.Chk_Enviar_Ventas_Dia.Name = "Chk_Enviar_Ventas_Dia";
            this.Chk_Enviar_Ventas_Dia.Size = new System.Drawing.Size(142, 19);
            this.Chk_Enviar_Ventas_Dia.TabIndex = 27;
            this.Chk_Enviar_Ventas_Dia.Text = "Enviar ventas del dia";
            this.Chk_Enviar_Ventas_Dia.UseVisualStyleBackColor = true;
            this.Chk_Enviar_Ventas_Dia.Visible = false;
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fra_Buscar.Controls.Add(this.Dtp_Busqueda_Desde_Fecha);
            this.Fra_Buscar.Controls.Add(this.Dtp_Busqueda_Hasta_Fecha);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda_Desde_Fecha);
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda_Hasta_Fecha);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Estatus);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda_Estatus);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(0, 0);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(777, 124);
            this.Fra_Buscar.TabIndex = 22;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            // 
            // Dtp_Busqueda_Desde_Fecha
            // 
            this.Dtp_Busqueda_Desde_Fecha.CustomFormat = "dd/MMM/yyyy";
            this.Dtp_Busqueda_Desde_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Busqueda_Desde_Fecha.Location = new System.Drawing.Point(91, 23);
            this.Dtp_Busqueda_Desde_Fecha.Name = "Dtp_Busqueda_Desde_Fecha";
            this.Dtp_Busqueda_Desde_Fecha.Size = new System.Drawing.Size(280, 21);
            this.Dtp_Busqueda_Desde_Fecha.TabIndex = 11;
            // 
            // Dtp_Busqueda_Hasta_Fecha
            // 
            this.Dtp_Busqueda_Hasta_Fecha.CustomFormat = "dd/MMM/yyyy";
            this.Dtp_Busqueda_Hasta_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Busqueda_Hasta_Fecha.Location = new System.Drawing.Point(486, 25);
            this.Dtp_Busqueda_Hasta_Fecha.Name = "Dtp_Busqueda_Hasta_Fecha";
            this.Dtp_Busqueda_Hasta_Fecha.Size = new System.Drawing.Size(280, 21);
            this.Dtp_Busqueda_Hasta_Fecha.TabIndex = 12;
            // 
            // Lbl_Busqueda_Desde_Fecha
            // 
            this.Lbl_Busqueda_Desde_Fecha.AutoSize = true;
            this.Lbl_Busqueda_Desde_Fecha.Location = new System.Drawing.Point(13, 26);
            this.Lbl_Busqueda_Desde_Fecha.Name = "Lbl_Busqueda_Desde_Fecha";
            this.Lbl_Busqueda_Desde_Fecha.Size = new System.Drawing.Size(78, 15);
            this.Lbl_Busqueda_Desde_Fecha.TabIndex = 6;
            this.Lbl_Busqueda_Desde_Fecha.Text = "Desde fecha";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(693, 73);
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
            this.Btn_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(610, 73);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(77, 45);
            this.Btn_Busqueda.TabIndex = 14;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Lbl_Busqueda_Hasta_Fecha
            // 
            this.Lbl_Busqueda_Hasta_Fecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Busqueda_Hasta_Fecha.AutoSize = true;
            this.Lbl_Busqueda_Hasta_Fecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda_Hasta_Fecha.Location = new System.Drawing.Point(393, 25);
            this.Lbl_Busqueda_Hasta_Fecha.Name = "Lbl_Busqueda_Hasta_Fecha";
            this.Lbl_Busqueda_Hasta_Fecha.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda_Hasta_Fecha.TabIndex = 2;
            this.Lbl_Busqueda_Hasta_Fecha.Text = "Hasta fecha";
            // 
            // Cmb_Busqueda_Estatus
            // 
            this.Cmb_Busqueda_Estatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cmb_Busqueda_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Estatus.FormattingEnabled = true;
            this.Cmb_Busqueda_Estatus.Items.AddRange(new object[] {
            "<-SELECCIONE->",
            "ABIERTO",
            "CERRADO"});
            this.Cmb_Busqueda_Estatus.Location = new System.Drawing.Point(91, 57);
            this.Cmb_Busqueda_Estatus.Name = "Cmb_Busqueda_Estatus";
            this.Cmb_Busqueda_Estatus.Size = new System.Drawing.Size(280, 24);
            this.Cmb_Busqueda_Estatus.TabIndex = 13;
            // 
            // Lbl_Busqueda_Estatus
            // 
            this.Lbl_Busqueda_Estatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Busqueda_Estatus.AutoSize = true;
            this.Lbl_Busqueda_Estatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda_Estatus.Location = new System.Drawing.Point(13, 60);
            this.Lbl_Busqueda_Estatus.Name = "Lbl_Busqueda_Estatus";
            this.Lbl_Busqueda_Estatus.Size = new System.Drawing.Size(50, 15);
            this.Lbl_Busqueda_Estatus.TabIndex = 0;
            this.Lbl_Busqueda_Estatus.Text = "Estatus";
            // 
            // Lbl_Horario
            // 
            this.Lbl_Horario.AutoSize = true;
            this.Lbl_Horario.Font = new System.Drawing.Font("Arial", 9F);
            this.Lbl_Horario.Location = new System.Drawing.Point(406, 83);
            this.Lbl_Horario.Name = "Lbl_Horario";
            this.Lbl_Horario.Size = new System.Drawing.Size(48, 15);
            this.Lbl_Horario.TabIndex = 26;
            this.Lbl_Horario.Text = "Horario";
            // 
            // Txt_Horario
            // 
            this.Txt_Horario.Location = new System.Drawing.Point(486, 81);
            this.Txt_Horario.Name = "Txt_Horario";
            this.Txt_Horario.ReadOnly = true;
            this.Txt_Horario.Size = new System.Drawing.Size(280, 21);
            this.Txt_Horario.TabIndex = 5;
            // 
            // Txt_Fecha_Hora_Cierre
            // 
            this.Txt_Fecha_Hora_Cierre.Location = new System.Drawing.Point(486, 53);
            this.Txt_Fecha_Hora_Cierre.Name = "Txt_Fecha_Hora_Cierre";
            this.Txt_Fecha_Hora_Cierre.ReadOnly = true;
            this.Txt_Fecha_Hora_Cierre.Size = new System.Drawing.Size(280, 21);
            this.Txt_Fecha_Hora_Cierre.TabIndex = 3;
            this.Txt_Fecha_Hora_Cierre.TabStop = false;
            // 
            // Lbl_Fecha_Hora_Cierre
            // 
            this.Lbl_Fecha_Hora_Cierre.AutoSize = true;
            this.Lbl_Fecha_Hora_Cierre.Font = new System.Drawing.Font("Arial", 9F);
            this.Lbl_Fecha_Hora_Cierre.Location = new System.Drawing.Point(406, 57);
            this.Lbl_Fecha_Hora_Cierre.Name = "Lbl_Fecha_Hora_Cierre";
            this.Lbl_Fecha_Hora_Cierre.Size = new System.Drawing.Size(41, 15);
            this.Lbl_Fecha_Hora_Cierre.TabIndex = 23;
            this.Lbl_Fecha_Hora_Cierre.Text = "Cierre";
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(353, 363);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(97, 51);
            this.Btn_Nuevo.TabIndex = 7;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Frm_Ope_Turnos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(793, 426);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Turnos);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.Name = "Frm_Ope_Turnos";
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.Frm_Ope_Turnos_Load);
            this.Fra_Turnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Turnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Turnos;
        private System.Windows.Forms.DataGridView Grid_Turnos;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.TextBox Txt_No_Turno;
        private System.Windows.Forms.Label Lbl_No_Turno;
        private System.Windows.Forms.ComboBox Cmb_Turno;
        private System.Windows.Forms.Label Lbl_Turno;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Turno;
        private System.Windows.Forms.Label Lbl_Fecha_Hora_Inicio;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.Label Lbl_Busqueda_Hasta_Fecha;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Estatus;
        private System.Windows.Forms.Label Lbl_Busqueda_Estatus;
        private System.Windows.Forms.TextBox Txt_Fecha_Hora_Cierre;
        private System.Windows.Forms.Label Lbl_Fecha_Hora_Cierre;
        private System.Windows.Forms.Label Lbl_Horario;
        private System.Windows.Forms.TextBox Txt_Horario;
        private System.Windows.Forms.Label Lbl_Busqueda_Desde_Fecha;
        private System.Windows.Forms.DateTimePicker Dtp_Busqueda_Desde_Fecha;
        private System.Windows.Forms.DateTimePicker Dtp_Busqueda_Hasta_Fecha;
        private System.Windows.Forms.CheckBox Chk_Enviar_Ventas_Dia;
    }
}