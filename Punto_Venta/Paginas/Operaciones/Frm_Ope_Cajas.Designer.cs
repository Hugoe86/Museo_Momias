namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Ope_Cajas
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
            this.Fra_Caja = new System.Windows.Forms.GroupBox();
            this.Txt_Monto_Cierre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cmb_Numero_Caja = new System.Windows.Forms.ComboBox();
            this.Lbl_Numero_Caja = new System.Windows.Forms.Label();
            this.Txt_Monto_Inicial = new System.Windows.Forms.TextBox();
            this.Lbl_Monto_Inicial = new System.Windows.Forms.Label();
            this.Txt_Horario_Cierre = new System.Windows.Forms.TextBox();
            this.Txt_Horario_Inicio = new System.Windows.Forms.TextBox();
            this.Lbl_Horario_Cierre = new System.Windows.Forms.Label();
            this.Lbl_Horario_Inicio = new System.Windows.Forms.Label();
            this.Fra_Caja_Fecha = new System.Windows.Forms.GroupBox();
            this.Txt_No_Caja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Fecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Fra_Turno = new System.Windows.Forms.GroupBox();
            this.Txt_Turno_ID = new System.Windows.Forms.TextBox();
            this.Lbl_Turno = new System.Windows.Forms.Label();
            this.Txt_Turno = new System.Windows.Forms.TextBox();
            this.Lbl_Turno_ID = new System.Windows.Forms.Label();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Cargar_Datos = new System.Windows.Forms.Button();
            this.Btn_Cierre = new System.Windows.Forms.Button();
            this.Btn_Apertura = new System.Windows.Forms.Button();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Cajas = new System.Windows.Forms.GroupBox();
            this.Grid_Cajas = new System.Windows.Forms.DataGridView();
            this.No_Caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No_Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Caja_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto_Inicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Hora_Inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fra_Caja.SuspendLayout();
            this.Fra_Caja_Fecha.SuspendLayout();
            this.Fra_Turno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Cajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Cajas)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Caja
            // 
            this.Fra_Caja.Controls.Add(this.Txt_Monto_Cierre);
            this.Fra_Caja.Controls.Add(this.label4);
            this.Fra_Caja.Controls.Add(this.Cmb_Numero_Caja);
            this.Fra_Caja.Controls.Add(this.Lbl_Numero_Caja);
            this.Fra_Caja.Controls.Add(this.Txt_Monto_Inicial);
            this.Fra_Caja.Controls.Add(this.Lbl_Monto_Inicial);
            this.Fra_Caja.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Caja.Location = new System.Drawing.Point(12, 149);
            this.Fra_Caja.Name = "Fra_Caja";
            this.Fra_Caja.Size = new System.Drawing.Size(510, 48);
            this.Fra_Caja.TabIndex = 0;
            this.Fra_Caja.TabStop = false;
            this.Fra_Caja.Text = "Caja y Estatus";
            // 
            // Txt_Monto_Cierre
            // 
            this.Txt_Monto_Cierre.Enabled = false;
            this.Txt_Monto_Cierre.Location = new System.Drawing.Point(444, 16);
            this.Txt_Monto_Cierre.Name = "Txt_Monto_Cierre";
            this.Txt_Monto_Cierre.Size = new System.Drawing.Size(60, 21);
            this.Txt_Monto_Cierre.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(359, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monto al Cierre";
            // 
            // Cmb_Numero_Caja
            // 
            this.Cmb_Numero_Caja.FormattingEnabled = true;
            this.Cmb_Numero_Caja.Location = new System.Drawing.Point(99, 16);
            this.Cmb_Numero_Caja.Name = "Cmb_Numero_Caja";
            this.Cmb_Numero_Caja.Size = new System.Drawing.Size(69, 23);
            this.Cmb_Numero_Caja.TabIndex = 1;
            this.Cmb_Numero_Caja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cmb_Numero_Caja_KeyPress);
            // 
            // Lbl_Numero_Caja
            // 
            this.Lbl_Numero_Caja.AutoSize = true;
            this.Lbl_Numero_Caja.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Numero_Caja.Location = new System.Drawing.Point(6, 20);
            this.Lbl_Numero_Caja.Name = "Lbl_Numero_Caja";
            this.Lbl_Numero_Caja.Size = new System.Drawing.Size(87, 14);
            this.Lbl_Numero_Caja.TabIndex = 1;
            this.Lbl_Numero_Caja.Text = "*Número de Caja";
            // 
            // Txt_Monto_Inicial
            // 
            this.Txt_Monto_Inicial.Enabled = false;
            this.Txt_Monto_Inicial.Location = new System.Drawing.Point(260, 16);
            this.Txt_Monto_Inicial.Name = "Txt_Monto_Inicial";
            this.Txt_Monto_Inicial.Size = new System.Drawing.Size(60, 21);
            this.Txt_Monto_Inicial.TabIndex = 3;
            this.Txt_Monto_Inicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Monto_Inicial_KeyPress);
            // 
            // Lbl_Monto_Inicial
            // 
            this.Lbl_Monto_Inicial.AutoSize = true;
            this.Lbl_Monto_Inicial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Monto_Inicial.Location = new System.Drawing.Point(180, 20);
            this.Lbl_Monto_Inicial.Name = "Lbl_Monto_Inicial";
            this.Lbl_Monto_Inicial.Size = new System.Drawing.Size(65, 14);
            this.Lbl_Monto_Inicial.TabIndex = 3;
            this.Lbl_Monto_Inicial.Text = "Monto Inicial";
            // 
            // Txt_Horario_Cierre
            // 
            this.Txt_Horario_Cierre.Enabled = false;
            this.Txt_Horario_Cierre.Location = new System.Drawing.Point(305, 43);
            this.Txt_Horario_Cierre.Name = "Txt_Horario_Cierre";
            this.Txt_Horario_Cierre.Size = new System.Drawing.Size(199, 21);
            this.Txt_Horario_Cierre.TabIndex = 7;
            // 
            // Txt_Horario_Inicio
            // 
            this.Txt_Horario_Inicio.Enabled = false;
            this.Txt_Horario_Inicio.Location = new System.Drawing.Point(92, 43);
            this.Txt_Horario_Inicio.Name = "Txt_Horario_Inicio";
            this.Txt_Horario_Inicio.Size = new System.Drawing.Size(118, 21);
            this.Txt_Horario_Inicio.TabIndex = 6;
            // 
            // Lbl_Horario_Cierre
            // 
            this.Lbl_Horario_Cierre.AutoSize = true;
            this.Lbl_Horario_Cierre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Horario_Cierre.Location = new System.Drawing.Point(222, 47);
            this.Lbl_Horario_Cierre.Name = "Lbl_Horario_Cierre";
            this.Lbl_Horario_Cierre.Size = new System.Drawing.Size(77, 14);
            this.Lbl_Horario_Cierre.TabIndex = 2;
            this.Lbl_Horario_Cierre.Text = "Hora de Cierre";
            // 
            // Lbl_Horario_Inicio
            // 
            this.Lbl_Horario_Inicio.AutoSize = true;
            this.Lbl_Horario_Inicio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Horario_Inicio.Location = new System.Drawing.Point(6, 47);
            this.Lbl_Horario_Inicio.Name = "Lbl_Horario_Inicio";
            this.Lbl_Horario_Inicio.Size = new System.Drawing.Size(72, 14);
            this.Lbl_Horario_Inicio.TabIndex = 1;
            this.Lbl_Horario_Inicio.Text = "Hora de Inicio";
            // 
            // Fra_Caja_Fecha
            // 
            this.Fra_Caja_Fecha.Controls.Add(this.Txt_Horario_Cierre);
            this.Fra_Caja_Fecha.Controls.Add(this.Txt_No_Caja);
            this.Fra_Caja_Fecha.Controls.Add(this.Lbl_Horario_Cierre);
            this.Fra_Caja_Fecha.Controls.Add(this.Txt_Horario_Inicio);
            this.Fra_Caja_Fecha.Controls.Add(this.label1);
            this.Fra_Caja_Fecha.Controls.Add(this.Txt_Fecha);
            this.Fra_Caja_Fecha.Controls.Add(this.Lbl_Horario_Inicio);
            this.Fra_Caja_Fecha.Controls.Add(this.label2);
            this.Fra_Caja_Fecha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Caja_Fecha.Location = new System.Drawing.Point(12, 12);
            this.Fra_Caja_Fecha.Name = "Fra_Caja_Fecha";
            this.Fra_Caja_Fecha.Size = new System.Drawing.Size(510, 74);
            this.Fra_Caja_Fecha.TabIndex = 3;
            this.Fra_Caja_Fecha.TabStop = false;
            this.Fra_Caja_Fecha.Text = "Caja y Fecha";
            // 
            // Txt_No_Caja
            // 
            this.Txt_No_Caja.Enabled = false;
            this.Txt_No_Caja.Location = new System.Drawing.Point(92, 16);
            this.Txt_No_Caja.Name = "Txt_No_Caja";
            this.Txt_No_Caja.Size = new System.Drawing.Size(118, 21);
            this.Txt_No_Caja.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "No. Caja";
            // 
            // Txt_Fecha
            // 
            this.Txt_Fecha.Enabled = false;
            this.Txt_Fecha.Location = new System.Drawing.Point(305, 16);
            this.Txt_Fecha.Name = "Txt_Fecha";
            this.Txt_Fecha.Size = new System.Drawing.Size(199, 21);
            this.Txt_Fecha.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha";
            // 
            // Fra_Turno
            // 
            this.Fra_Turno.Controls.Add(this.Txt_Turno_ID);
            this.Fra_Turno.Controls.Add(this.Lbl_Turno);
            this.Fra_Turno.Controls.Add(this.Txt_Turno);
            this.Fra_Turno.Controls.Add(this.Lbl_Turno_ID);
            this.Fra_Turno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Turno.Location = new System.Drawing.Point(12, 92);
            this.Fra_Turno.Name = "Fra_Turno";
            this.Fra_Turno.Size = new System.Drawing.Size(510, 51);
            this.Fra_Turno.TabIndex = 9;
            this.Fra_Turno.TabStop = false;
            this.Fra_Turno.Text = "Turno";
            // 
            // Txt_Turno_ID
            // 
            this.Txt_Turno_ID.Enabled = false;
            this.Txt_Turno_ID.Location = new System.Drawing.Point(92, 16);
            this.Txt_Turno_ID.Name = "Txt_Turno_ID";
            this.Txt_Turno_ID.Size = new System.Drawing.Size(118, 21);
            this.Txt_Turno_ID.TabIndex = 10;
            // 
            // Lbl_Turno
            // 
            this.Lbl_Turno.AutoSize = true;
            this.Lbl_Turno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Turno.Location = new System.Drawing.Point(222, 20);
            this.Lbl_Turno.Name = "Lbl_Turno";
            this.Lbl_Turno.Size = new System.Drawing.Size(35, 14);
            this.Lbl_Turno.TabIndex = 9;
            this.Lbl_Turno.Text = "Turno";
            // 
            // Txt_Turno
            // 
            this.Txt_Turno.Enabled = false;
            this.Txt_Turno.Location = new System.Drawing.Point(305, 16);
            this.Txt_Turno.Name = "Txt_Turno";
            this.Txt_Turno.Size = new System.Drawing.Size(199, 21);
            this.Txt_Turno.TabIndex = 8;
            // 
            // Lbl_Turno_ID
            // 
            this.Lbl_Turno_ID.AutoSize = true;
            this.Lbl_Turno_ID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Turno_ID.Location = new System.Drawing.Point(6, 20);
            this.Lbl_Turno_ID.Name = "Lbl_Turno_ID";
            this.Lbl_Turno_ID.Size = new System.Drawing.Size(47, 14);
            this.Lbl_Turno_ID.TabIndex = 1;
            this.Lbl_Turno_ID.Text = "ID Turno";
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(381, 344);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(94, 51);
            this.Btn_Salir.TabIndex = 14;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Cargar_Datos
            // 
            this.Btn_Cargar_Datos.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Cargar_Datos.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
            this.Btn_Cargar_Datos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Cargar_Datos.Location = new System.Drawing.Point(272, 344);
            this.Btn_Cargar_Datos.Name = "Btn_Cargar_Datos";
            this.Btn_Cargar_Datos.Size = new System.Drawing.Size(94, 51);
            this.Btn_Cargar_Datos.TabIndex = 13;
            this.Btn_Cargar_Datos.Text = "Actualizar";
            this.Btn_Cargar_Datos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cargar_Datos.UseVisualStyleBackColor = true;
            this.Btn_Cargar_Datos.Visible = false;
            this.Btn_Cargar_Datos.Click += new System.EventHandler(this.Btn_Cargar_Datos_Click);
            // 
            // Btn_Cierre
            // 
            this.Btn_Cierre.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Cierre.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Cierre.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Cierre.Location = new System.Drawing.Point(161, 344);
            this.Btn_Cierre.Name = "Btn_Cierre";
            this.Btn_Cierre.Size = new System.Drawing.Size(96, 51);
            this.Btn_Cierre.TabIndex = 12;
            this.Btn_Cierre.Text = "Cierre";
            this.Btn_Cierre.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cierre.UseVisualStyleBackColor = true;
            this.Btn_Cierre.Visible = false;
            this.Btn_Cierre.Click += new System.EventHandler(this.Btn_Cierre_Click);
            // 
            // Btn_Apertura
            // 
            this.Btn_Apertura.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Apertura.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Apertura.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Apertura.Location = new System.Drawing.Point(45, 344);
            this.Btn_Apertura.Name = "Btn_Apertura";
            this.Btn_Apertura.Size = new System.Drawing.Size(97, 51);
            this.Btn_Apertura.TabIndex = 11;
            this.Btn_Apertura.Text = "Apertura";
            this.Btn_Apertura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Apertura.UseVisualStyleBackColor = true;
            this.Btn_Apertura.Click += new System.EventHandler(this.Btn_Apertura_Click);
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Fra_Cajas
            // 
            this.Fra_Cajas.Controls.Add(this.Grid_Cajas);
            this.Fra_Cajas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Cajas.Location = new System.Drawing.Point(12, 203);
            this.Fra_Cajas.Name = "Fra_Cajas";
            this.Fra_Cajas.Size = new System.Drawing.Size(510, 135);
            this.Fra_Cajas.TabIndex = 15;
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
            this.No_Caja,
            this.No_Turno,
            this.Caja_ID,
            this.Monto_Inicial,
            this.Fecha_Hora_Inicio});
            this.Grid_Cajas.Location = new System.Drawing.Point(6, 17);
            this.Grid_Cajas.Name = "Grid_Cajas";
            this.Grid_Cajas.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Cajas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Cajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Cajas.Size = new System.Drawing.Size(498, 112);
            this.Grid_Cajas.TabIndex = 6;
            this.Grid_Cajas.SelectionChanged += new System.EventHandler(this.Grid_Cajas_SelectionChanged);
            // 
            // No_Caja
            // 
            this.No_Caja.DataPropertyName = "No_Caja";
            this.No_Caja.HeaderText = "No. Caja";
            this.No_Caja.Name = "No_Caja";
            this.No_Caja.ReadOnly = true;
            this.No_Caja.Width = 72;
            // 
            // No_Turno
            // 
            this.No_Turno.DataPropertyName = "No_Turno";
            this.No_Turno.HeaderText = "No. Turno";
            this.No_Turno.Name = "No_Turno";
            this.No_Turno.ReadOnly = true;
            this.No_Turno.Width = 78;
            // 
            // Caja_ID
            // 
            this.Caja_ID.DataPropertyName = "Caja_ID";
            this.Caja_ID.HeaderText = "ID de Caja";
            this.Caja_ID.Name = "Caja_ID";
            this.Caja_ID.ReadOnly = true;
            this.Caja_ID.Width = 81;
            // 
            // Monto_Inicial
            // 
            this.Monto_Inicial.DataPropertyName = "Monto_Inicial";
            this.Monto_Inicial.HeaderText = "Monto Inicial";
            this.Monto_Inicial.Name = "Monto_Inicial";
            this.Monto_Inicial.ReadOnly = true;
            this.Monto_Inicial.Width = 95;
            // 
            // Fecha_Hora_Inicio
            // 
            this.Fecha_Hora_Inicio.DataPropertyName = "Fecha_Hora_Inicio";
            this.Fecha_Hora_Inicio.HeaderText = "Fecha y Hora de Inicio";
            this.Fecha_Hora_Inicio.Name = "Fecha_Hora_Inicio";
            this.Fecha_Hora_Inicio.ReadOnly = true;
            this.Fecha_Hora_Inicio.Width = 114;
            // 
            // Frm_Ope_Cajas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(534, 402);
            this.Controls.Add(this.Fra_Cajas);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Cargar_Datos);
            this.Controls.Add(this.Btn_Cierre);
            this.Controls.Add(this.Btn_Apertura);
            this.Controls.Add(this.Fra_Turno);
            this.Controls.Add(this.Fra_Caja_Fecha);
            this.Controls.Add(this.Fra_Caja);
            this.Name = "Frm_Ope_Cajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operación de Cajas";
            this.Load += new System.EventHandler(this.Frm_Ope_Cajas_Load);
            this.Fra_Caja.ResumeLayout(false);
            this.Fra_Caja.PerformLayout();
            this.Fra_Caja_Fecha.ResumeLayout(false);
            this.Fra_Caja_Fecha.PerformLayout();
            this.Fra_Turno.ResumeLayout(false);
            this.Fra_Turno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Cajas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Cajas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Caja;
        private System.Windows.Forms.Label Lbl_Numero_Caja;
        private System.Windows.Forms.ComboBox Cmb_Numero_Caja;
        private System.Windows.Forms.Label Lbl_Horario_Cierre;
        private System.Windows.Forms.Label Lbl_Horario_Inicio;
        private System.Windows.Forms.TextBox Txt_Monto_Inicial;
        private System.Windows.Forms.Label Lbl_Monto_Inicial;
        private System.Windows.Forms.TextBox Txt_Horario_Cierre;
        private System.Windows.Forms.TextBox Txt_Horario_Inicio;
        private System.Windows.Forms.GroupBox Fra_Caja_Fecha;
        private System.Windows.Forms.TextBox Txt_Fecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox Fra_Turno;
        private System.Windows.Forms.TextBox Txt_Turno;
        private System.Windows.Forms.Label Lbl_Turno_ID;
        private System.Windows.Forms.TextBox Txt_Turno_ID;
        private System.Windows.Forms.Label Lbl_Turno;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Cargar_Datos;
        private System.Windows.Forms.Button Btn_Cierre;
        private System.Windows.Forms.Button Btn_Apertura;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.TextBox Txt_No_Caja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Fra_Cajas;
        private System.Windows.Forms.DataGridView Grid_Cajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Caja;
        private System.Windows.Forms.DataGridViewTextBoxColumn No_Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caja_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto_Inicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Hora_Inicio;
        private System.Windows.Forms.TextBox Txt_Monto_Cierre;
        private System.Windows.Forms.Label label4;

    }
}