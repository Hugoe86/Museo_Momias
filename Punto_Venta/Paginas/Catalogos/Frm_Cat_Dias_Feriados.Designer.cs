namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Dias_Feriados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Dias_Feriados));
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Dtp_Fecha_Fin_Buscar = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Inicio_Buscar = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Fin_Periodo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Anios = new System.Windows.Forms.TextBox();
            this.Opt_Actual = new System.Windows.Forms.RadioButton();
            this.Opt_Todos = new System.Windows.Forms.RadioButton();
            this.Lbl_Anios = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Inicio_Periodo = new System.Windows.Forms.DateTimePicker();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Txt_ID_Dia = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Dia = new System.Windows.Forms.Label();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Fra_Dias_Feriados = new System.Windows.Forms.GroupBox();
            this.Grid_Dias_Feriados = new System.Windows.Forms.DataGridView();
            this.Dia_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Fin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Buscar.SuspendLayout();
            this.Fra_Dias_Feriados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Dias_Feriados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Dtp_Fecha_Fin_Periodo);
            this.Fra_Datos_Generales.Controls.Add(this.label2);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Anios);
            this.Fra_Datos_Generales.Controls.Add(this.Opt_Actual);
            this.Fra_Datos_Generales.Controls.Add(this.Opt_Todos);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Anios);
            this.Fra_Datos_Generales.Controls.Add(this.Dtp_Fecha_Inicio_Periodo);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_ID_Dia);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_ID_Dia);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Descripcion);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Descripcion);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Fecha);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(12, 12);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(437, 235);
            this.Fra_Datos_Generales.TabIndex = 32;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Controls.Add(this.Dtp_Fecha_Fin_Buscar);
            this.Fra_Buscar.Controls.Add(this.label3);
            this.Fra_Buscar.Controls.Add(this.Dtp_Fecha_Inicio_Buscar);
            this.Fra_Buscar.Controls.Add(this.label1);
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(12, 12);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(437, 235);
            this.Fra_Buscar.TabIndex = 51;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            this.Fra_Buscar.Visible = false;
            // 
            // Dtp_Fecha_Fin_Buscar
            // 
            this.Dtp_Fecha_Fin_Buscar.Enabled = false;
            this.Dtp_Fecha_Fin_Buscar.Location = new System.Drawing.Point(110, 103);
            this.Dtp_Fecha_Fin_Buscar.Name = "Dtp_Fecha_Fin_Buscar";
            this.Dtp_Fecha_Fin_Buscar.Size = new System.Drawing.Size(285, 21);
            this.Dtp_Fecha_Fin_Buscar.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(10, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha Fin";
            // 
            // Dtp_Fecha_Inicio_Buscar
            // 
            this.Dtp_Fecha_Inicio_Buscar.Enabled = false;
            this.Dtp_Fecha_Inicio_Buscar.Location = new System.Drawing.Point(110, 76);
            this.Dtp_Fecha_Inicio_Buscar.Name = "Dtp_Fecha_Inicio_Buscar";
            this.Dtp_Fecha_Inicio_Buscar.Size = new System.Drawing.Size(285, 21);
            this.Dtp_Fecha_Inicio_Buscar.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha Inicio";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(223, 150);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(78, 45);
            this.Btn_Regresar.TabIndex = 5;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(109, 150);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(78, 45);
            this.Btn_Busqueda.TabIndex = 4;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(110, 50);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(285, 20);
            this.Txt_Descripcion_Busqueda.TabIndex = 3;
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(7, 51);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(80, 15);
            this.Lbl_Descripcion_Busqueda.TabIndex = 2;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "Id Día",
            "Fecha",
            "Descripción",
            "Estatus"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(110, 20);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(285, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 1;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(4, 20);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Dtp_Fecha_Fin_Periodo
            // 
            this.Dtp_Fecha_Fin_Periodo.Location = new System.Drawing.Point(100, 137);
            this.Dtp_Fecha_Fin_Periodo.Name = "Dtp_Fecha_Fin_Periodo";
            this.Dtp_Fecha_Fin_Periodo.Size = new System.Drawing.Size(310, 21);
            this.Dtp_Fecha_Fin_Periodo.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 14);
            this.label2.TabIndex = 54;
            this.label2.Text = "*Fecha Fin";
            // 
            // Txt_Anios
            // 
            this.Txt_Anios.Location = new System.Drawing.Point(254, 171);
            this.Txt_Anios.Name = "Txt_Anios";
            this.Txt_Anios.ReadOnly = true;
            this.Txt_Anios.Size = new System.Drawing.Size(156, 21);
            this.Txt_Anios.TabIndex = 52;
            // 
            // Opt_Actual
            // 
            this.Opt_Actual.AutoSize = true;
            this.Opt_Actual.Enabled = false;
            this.Opt_Actual.Location = new System.Drawing.Point(174, 172);
            this.Opt_Actual.Name = "Opt_Actual";
            this.Opt_Actual.Size = new System.Drawing.Size(61, 19);
            this.Opt_Actual.TabIndex = 51;
            this.Opt_Actual.TabStop = true;
            this.Opt_Actual.Text = "Actual";
            this.Opt_Actual.UseVisualStyleBackColor = true;
            this.Opt_Actual.Click += new System.EventHandler(this.Opt_Actual_Click);
            // 
            // Opt_Todos
            // 
            this.Opt_Todos.AutoSize = true;
            this.Opt_Todos.Enabled = false;
            this.Opt_Todos.Location = new System.Drawing.Point(95, 172);
            this.Opt_Todos.Name = "Opt_Todos";
            this.Opt_Todos.Size = new System.Drawing.Size(59, 19);
            this.Opt_Todos.TabIndex = 50;
            this.Opt_Todos.TabStop = true;
            this.Opt_Todos.Text = "Todos";
            this.Opt_Todos.UseVisualStyleBackColor = true;
            this.Opt_Todos.Click += new System.EventHandler(this.Opt_Todos_Click);
            // 
            // Lbl_Anios
            // 
            this.Lbl_Anios.AutoSize = true;
            this.Lbl_Anios.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Anios.Location = new System.Drawing.Point(6, 175);
            this.Lbl_Anios.Name = "Lbl_Anios";
            this.Lbl_Anios.Size = new System.Drawing.Size(40, 14);
            this.Lbl_Anios.TabIndex = 49;
            this.Lbl_Anios.Text = "*Años";
            // 
            // Dtp_Fecha_Inicio_Periodo
            // 
            this.Dtp_Fecha_Inicio_Periodo.Location = new System.Drawing.Point(100, 106);
            this.Dtp_Fecha_Inicio_Periodo.Name = "Dtp_Fecha_Inicio_Periodo";
            this.Dtp_Fecha_Inicio_Periodo.Size = new System.Drawing.Size(310, 21);
            this.Dtp_Fecha_Inicio_Periodo.TabIndex = 3;
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(95, 201);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(140, 24);
            this.Cmb_Estatus.TabIndex = 4;
            this.Cmb_Estatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Estatus_KeyPress);
            // 
            // Txt_ID_Dia
            // 
            this.Txt_ID_Dia.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Dia.Location = new System.Drawing.Point(100, 15);
            this.Txt_ID_Dia.MaxLength = 450;
            this.Txt_ID_Dia.Name = "Txt_ID_Dia";
            this.Txt_ID_Dia.ReadOnly = true;
            this.Txt_ID_Dia.Size = new System.Drawing.Size(140, 22);
            this.Txt_ID_Dia.TabIndex = 1;
            // 
            // Lbl_ID_Dia
            // 
            this.Lbl_ID_Dia.AutoSize = true;
            this.Lbl_ID_Dia.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Dia.Location = new System.Drawing.Point(8, 20);
            this.Lbl_ID_Dia.Name = "Lbl_ID_Dia";
            this.Lbl_ID_Dia.Size = new System.Drawing.Size(73, 14);
            this.Lbl_ID_Dia.TabIndex = 47;
            this.Lbl_ID_Dia.Text = "ID Día Feriado";
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Estatus.Location = new System.Drawing.Point(6, 206);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 32;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion.Location = new System.Drawing.Point(100, 43);
            this.Txt_Descripcion.MaxLength = 500;
            this.Txt_Descripcion.Multiline = true;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.Size = new System.Drawing.Size(310, 57);
            this.Txt_Descripcion.TabIndex = 2;
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Descripcion.Location = new System.Drawing.Point(8, 48);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(64, 14);
            this.Lbl_Descripcion.TabIndex = 18;
            this.Lbl_Descripcion.Text = "Descripción";
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Fecha.Location = new System.Drawing.Point(6, 112);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(78, 14);
            this.Lbl_Fecha.TabIndex = 6;
            this.Lbl_Fecha.Text = "*Fecha_Inicio";
            // 
            // Fra_Dias_Feriados
            // 
            this.Fra_Dias_Feriados.Controls.Add(this.Grid_Dias_Feriados);
            this.Fra_Dias_Feriados.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Dias_Feriados.Location = new System.Drawing.Point(12, 253);
            this.Fra_Dias_Feriados.Name = "Fra_Dias_Feriados";
            this.Fra_Dias_Feriados.Size = new System.Drawing.Size(437, 186);
            this.Fra_Dias_Feriados.TabIndex = 38;
            this.Fra_Dias_Feriados.TabStop = false;
            this.Fra_Dias_Feriados.Text = "Días Feriados";
            // 
            // Grid_Dias_Feriados
            // 
            this.Grid_Dias_Feriados.AllowUserToAddRows = false;
            this.Grid_Dias_Feriados.AllowUserToDeleteRows = false;
            this.Grid_Dias_Feriados.AllowUserToResizeRows = false;
            this.Grid_Dias_Feriados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Dias_Feriados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Dias_Feriados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dia_ID,
            this.Descripcion,
            this.Fecha,
            this.Fecha_Fin,
            this.Anios,
            this.Estatus});
            this.Grid_Dias_Feriados.Location = new System.Drawing.Point(6, 20);
            this.Grid_Dias_Feriados.Name = "Grid_Dias_Feriados";
            this.Grid_Dias_Feriados.ReadOnly = true;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Dias_Feriados.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.Grid_Dias_Feriados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Dias_Feriados.Size = new System.Drawing.Size(425, 156);
            this.Grid_Dias_Feriados.TabIndex = 0;
            this.Grid_Dias_Feriados.SelectionChanged += new System.EventHandler(this.Grid_Dias_Feriados_SelectionChanged);
            // 
            // Dia_ID
            // 
            this.Dia_ID.DataPropertyName = "Dia_ID";
            this.Dia_ID.HeaderText = "ID de Día";
            this.Dia_ID.Name = "Dia_ID";
            this.Dia_ID.ReadOnly = true;
            this.Dia_ID.Width = 81;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle10.Format = "M";
            dataGridViewCellStyle10.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle10;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 66;
            // 
            // Fecha_Fin
            // 
            this.Fecha_Fin.DataPropertyName = "Fecha_Fin";
            dataGridViewCellStyle11.Format = "t";
            dataGridViewCellStyle11.NullValue = null;
            this.Fecha_Fin.DefaultCellStyle = dataGridViewCellStyle11;
            this.Fecha_Fin.HeaderText = "Fecha Fin";
            this.Fecha_Fin.Name = "Fecha_Fin";
            this.Fecha_Fin.ReadOnly = true;
            this.Fecha_Fin.Width = 85;
            // 
            // Anios
            // 
            this.Anios.DataPropertyName = "Anios";
            this.Anios.HeaderText = "Años";
            this.Anios.Name = "Anios";
            this.Anios.ReadOnly = true;
            this.Anios.Width = 61;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 75;
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(31, 445);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(75, 51);
            this.Btn_Nuevo.TabIndex = 44;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(112, 445);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(75, 51);
            this.Btn_Modificar.TabIndex = 45;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(193, 445);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 51);
            this.Btn_Buscar.TabIndex = 46;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(274, 445);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(75, 51);
            this.Btn_Eliminar.TabIndex = 47;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(355, 445);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 51);
            this.Btn_Salir.TabIndex = 48;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Frm_Cat_Dias_Feriados
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(463, 503);
            this.Controls.Add(this.Fra_Buscar);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Dias_Feriados);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Dias_Feriados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Días Feriados";
            this.Load += new System.EventHandler(this.Frm_Cat_Dias_Feriados_Load);
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.Fra_Dias_Feriados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Dias_Feriados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.TextBox Txt_ID_Dia;
        private System.Windows.Forms.Label Lbl_ID_Dia;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Inicio_Periodo;
        private System.Windows.Forms.GroupBox Fra_Dias_Feriados;
        private System.Windows.Forms.DataGridView Grid_Dias_Feriados;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.Label Lbl_Anios;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.RadioButton Opt_Todos;
        private System.Windows.Forms.TextBox Txt_Anios;
        private System.Windows.Forms.RadioButton Opt_Actual;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Inicio_Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Fin_Periodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Fin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Fin_Buscar;
        private System.Windows.Forms.Label label3;
    }
}