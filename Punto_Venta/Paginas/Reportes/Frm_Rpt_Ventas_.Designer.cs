namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rpt_Ventas_
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Folio_Venta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_Anio = new System.Windows.Forms.ComboBox();
            this.Lbl_Anio = new System.Windows.Forms.Label();
            this.Cmb_Producto = new System.Windows.Forms.ComboBox();
            this.Lbl_Producto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Museo = new System.Windows.Forms.ComboBox();
            this.Cmb_Lugar_Venta = new System.Windows.Forms.ComboBox();
            this.Lbl_Lugar_Venta = new System.Windows.Forms.Label();
            this.Cmb_Turnos = new System.Windows.Forms.ComboBox();
            this.Cmb_Cajas = new System.Windows.Forms.ComboBox();
            this.Lbl_Turno = new System.Windows.Forms.Label();
            this.Lbl_Caja = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Termino = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Fecha_Inicio = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Fecha_Termino = new System.Windows.Forms.Label();
            this.Lbl_Fecha_Inicio_Busqueda = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Grid_Resultados_Busqueda = new System.Windows.Forms.DataGridView();
            this.Btn_Exportar_Excel = new System.Windows.Forms.Button();
            this.Btn_Exportar_PDF = new System.Windows.Forms.Button();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultados_Busqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_Folio_Venta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Cmb_Anio);
            this.groupBox1.Controls.Add(this.Lbl_Anio);
            this.groupBox1.Controls.Add(this.Cmb_Producto);
            this.groupBox1.Controls.Add(this.Lbl_Producto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Cmb_Museo);
            this.groupBox1.Controls.Add(this.Cmb_Lugar_Venta);
            this.groupBox1.Controls.Add(this.Lbl_Lugar_Venta);
            this.groupBox1.Controls.Add(this.Cmb_Turnos);
            this.groupBox1.Controls.Add(this.Cmb_Cajas);
            this.groupBox1.Controls.Add(this.Lbl_Turno);
            this.groupBox1.Controls.Add(this.Lbl_Caja);
            this.groupBox1.Controls.Add(this.Dtp_Fecha_Termino);
            this.groupBox1.Controls.Add(this.Dtp_Fecha_Inicio);
            this.groupBox1.Controls.Add(this.Lbl_Fecha_Termino);
            this.groupBox1.Controls.Add(this.Lbl_Fecha_Inicio_Busqueda);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de Búsqueda";
            // 
            // Txt_Folio_Venta
            // 
            this.Txt_Folio_Venta.Location = new System.Drawing.Point(439, 110);
            this.Txt_Folio_Venta.Name = "Txt_Folio_Venta";
            this.Txt_Folio_Venta.Size = new System.Drawing.Size(233, 23);
            this.Txt_Folio_Venta.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(315, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "Folio Venta";
            // 
            // Cmb_Anio
            // 
            this.Cmb_Anio.FormattingEnabled = true;
            this.Cmb_Anio.Location = new System.Drawing.Point(117, 110);
            this.Cmb_Anio.Name = "Cmb_Anio";
            this.Cmb_Anio.Size = new System.Drawing.Size(192, 24);
            this.Cmb_Anio.TabIndex = 31;
            this.Cmb_Anio.SelectedIndexChanged += new System.EventHandler(this.Cmb_Anio_SelectedIndexChanged);
            // 
            // Lbl_Anio
            // 
            this.Lbl_Anio.AutoSize = true;
            this.Lbl_Anio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Lbl_Anio.Location = new System.Drawing.Point(7, 111);
            this.Lbl_Anio.Name = "Lbl_Anio";
            this.Lbl_Anio.Size = new System.Drawing.Size(34, 18);
            this.Lbl_Anio.TabIndex = 30;
            this.Lbl_Anio.Text = "Año";
            // 
            // Cmb_Producto
            // 
            this.Cmb_Producto.FormattingEnabled = true;
            this.Cmb_Producto.Items.AddRange(new object[] {
            "SELECCIONE"});
            this.Cmb_Producto.Location = new System.Drawing.Point(117, 139);
            this.Cmb_Producto.Name = "Cmb_Producto";
            this.Cmb_Producto.Size = new System.Drawing.Size(555, 24);
            this.Cmb_Producto.TabIndex = 29;
            // 
            // Lbl_Producto
            // 
            this.Lbl_Producto.AutoSize = true;
            this.Lbl_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Lbl_Producto.Location = new System.Drawing.Point(7, 144);
            this.Lbl_Producto.Name = "Lbl_Producto";
            this.Lbl_Producto.Size = new System.Drawing.Size(69, 18);
            this.Lbl_Producto.TabIndex = 28;
            this.Lbl_Producto.Text = "Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(7, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 27;
            this.label1.Text = "Museo";
            // 
            // Cmb_Museo
            // 
            this.Cmb_Museo.FormattingEnabled = true;
            this.Cmb_Museo.Items.AddRange(new object[] {
            "SELECCIONE",
            "MUSEO MOMIAS",
            "CULTO A LA MUERTE"});
            this.Cmb_Museo.Location = new System.Drawing.Point(117, 81);
            this.Cmb_Museo.Name = "Cmb_Museo";
            this.Cmb_Museo.Size = new System.Drawing.Size(192, 24);
            this.Cmb_Museo.TabIndex = 26;
            // 
            // Cmb_Lugar_Venta
            // 
            this.Cmb_Lugar_Venta.FormattingEnabled = true;
            this.Cmb_Lugar_Venta.Items.AddRange(new object[] {
            "SELECCIONE",
            "No Caja",
            "Internet",
            "Kiosko"});
            this.Cmb_Lugar_Venta.Location = new System.Drawing.Point(439, 81);
            this.Cmb_Lugar_Venta.Name = "Cmb_Lugar_Venta";
            this.Cmb_Lugar_Venta.Size = new System.Drawing.Size(233, 24);
            this.Cmb_Lugar_Venta.TabIndex = 25;
            // 
            // Lbl_Lugar_Venta
            // 
            this.Lbl_Lugar_Venta.AutoSize = true;
            this.Lbl_Lugar_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Lbl_Lugar_Venta.Location = new System.Drawing.Point(315, 82);
            this.Lbl_Lugar_Venta.Name = "Lbl_Lugar_Venta";
            this.Lbl_Lugar_Venta.Size = new System.Drawing.Size(104, 18);
            this.Lbl_Lugar_Venta.TabIndex = 24;
            this.Lbl_Lugar_Venta.Text = "Lugar de venta";
            // 
            // Cmb_Turnos
            // 
            this.Cmb_Turnos.FormattingEnabled = true;
            this.Cmb_Turnos.Location = new System.Drawing.Point(439, 51);
            this.Cmb_Turnos.Name = "Cmb_Turnos";
            this.Cmb_Turnos.Size = new System.Drawing.Size(233, 24);
            this.Cmb_Turnos.TabIndex = 23;
            // 
            // Cmb_Cajas
            // 
            this.Cmb_Cajas.FormattingEnabled = true;
            this.Cmb_Cajas.Location = new System.Drawing.Point(117, 51);
            this.Cmb_Cajas.Name = "Cmb_Cajas";
            this.Cmb_Cajas.Size = new System.Drawing.Size(192, 24);
            this.Cmb_Cajas.TabIndex = 22;
            // 
            // Lbl_Turno
            // 
            this.Lbl_Turno.AutoSize = true;
            this.Lbl_Turno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Lbl_Turno.Location = new System.Drawing.Point(315, 52);
            this.Lbl_Turno.Name = "Lbl_Turno";
            this.Lbl_Turno.Size = new System.Drawing.Size(47, 18);
            this.Lbl_Turno.TabIndex = 21;
            this.Lbl_Turno.Text = "Turno";
            // 
            // Lbl_Caja
            // 
            this.Lbl_Caja.AutoSize = true;
            this.Lbl_Caja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Lbl_Caja.Location = new System.Drawing.Point(7, 52);
            this.Lbl_Caja.Name = "Lbl_Caja";
            this.Lbl_Caja.Size = new System.Drawing.Size(38, 18);
            this.Lbl_Caja.TabIndex = 20;
            this.Lbl_Caja.Text = "Caja";
            // 
            // Dtp_Fecha_Termino
            // 
            this.Dtp_Fecha_Termino.Checked = false;
            this.Dtp_Fecha_Termino.CustomFormat = "dd MMMM yyyy";
            this.Dtp_Fecha_Termino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Termino.Location = new System.Drawing.Point(439, 22);
            this.Dtp_Fecha_Termino.Name = "Dtp_Fecha_Termino";
            this.Dtp_Fecha_Termino.ShowCheckBox = true;
            this.Dtp_Fecha_Termino.Size = new System.Drawing.Size(233, 23);
            this.Dtp_Fecha_Termino.TabIndex = 19;
            // 
            // Dtp_Fecha_Inicio
            // 
            this.Dtp_Fecha_Inicio.Checked = false;
            this.Dtp_Fecha_Inicio.CustomFormat = "dd MMMM yyyy";
            this.Dtp_Fecha_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Inicio.Location = new System.Drawing.Point(117, 22);
            this.Dtp_Fecha_Inicio.Name = "Dtp_Fecha_Inicio";
            this.Dtp_Fecha_Inicio.ShowCheckBox = true;
            this.Dtp_Fecha_Inicio.Size = new System.Drawing.Size(192, 23);
            this.Dtp_Fecha_Inicio.TabIndex = 18;
            // 
            // Lbl_Fecha_Termino
            // 
            this.Lbl_Fecha_Termino.AutoSize = true;
            this.Lbl_Fecha_Termino.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Lbl_Fecha_Termino.Location = new System.Drawing.Point(315, 26);
            this.Lbl_Fecha_Termino.Name = "Lbl_Fecha_Termino";
            this.Lbl_Fecha_Termino.Size = new System.Drawing.Size(108, 18);
            this.Lbl_Fecha_Termino.TabIndex = 17;
            this.Lbl_Fecha_Termino.Text = "Fecha Término";
            // 
            // Lbl_Fecha_Inicio_Busqueda
            // 
            this.Lbl_Fecha_Inicio_Busqueda.AutoSize = true;
            this.Lbl_Fecha_Inicio_Busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Lbl_Fecha_Inicio_Busqueda.Location = new System.Drawing.Point(7, 26);
            this.Lbl_Fecha_Inicio_Busqueda.Name = "Lbl_Fecha_Inicio_Busqueda";
            this.Lbl_Fecha_Inicio_Busqueda.Size = new System.Drawing.Size(87, 18);
            this.Lbl_Fecha_Inicio_Busqueda.TabIndex = 16;
            this.Lbl_Fecha_Inicio_Busqueda.Text = "Fecha Inicio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Grid_Resultados_Busqueda);
            this.groupBox2.Location = new System.Drawing.Point(14, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 361);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultado de la Búsqueda";
            // 
            // Grid_Resultados_Busqueda
            // 
            this.Grid_Resultados_Busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Resultados_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Resultados_Busqueda.Location = new System.Drawing.Point(3, 35);
            this.Grid_Resultados_Busqueda.Name = "Grid_Resultados_Busqueda";
            this.Grid_Resultados_Busqueda.Size = new System.Drawing.Size(679, 323);
            this.Grid_Resultados_Busqueda.TabIndex = 0;
            // 
            // Btn_Exportar_Excel
            // 
            this.Btn_Exportar_Excel.BackColor = System.Drawing.Color.White;
            this.Btn_Exportar_Excel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Exportar_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exportar_Excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Btn_Exportar_Excel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Exportar_Excel.Location = new System.Drawing.Point(535, 195);
            this.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel";
            this.Btn_Exportar_Excel.Size = new System.Drawing.Size(164, 30);
            this.Btn_Exportar_Excel.TabIndex = 9;
            this.Btn_Exportar_Excel.Text = "Exportar Excel";
            this.Btn_Exportar_Excel.UseVisualStyleBackColor = false;
            this.Btn_Exportar_Excel.Click += new System.EventHandler(this.Btn_Exportar_Excel_Click);
            // 
            // Btn_Exportar_PDF
            // 
            this.Btn_Exportar_PDF.BackColor = System.Drawing.Color.White;
            this.Btn_Exportar_PDF.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Exportar_PDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exportar_PDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Btn_Exportar_PDF.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Exportar_PDF.Location = new System.Drawing.Point(261, 195);
            this.Btn_Exportar_PDF.Name = "Btn_Exportar_PDF";
            this.Btn_Exportar_PDF.Size = new System.Drawing.Size(164, 30);
            this.Btn_Exportar_PDF.TabIndex = 7;
            this.Btn_Exportar_PDF.Text = "Exportar PDF";
            this.Btn_Exportar_PDF.UseVisualStyleBackColor = false;
            this.Btn_Exportar_PDF.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.BackColor = System.Drawing.Color.White;
            this.Btn_Consultar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Btn_Consultar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Consultar.Location = new System.Drawing.Point(14, 195);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(164, 30);
            this.Btn_Consultar.TabIndex = 6;
            this.Btn_Consultar.Text = "General";
            this.Btn_Consultar.UseVisualStyleBackColor = false;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Frm_Rpt_Ventas_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 604);
            this.Controls.Add(this.Btn_Exportar_Excel);
            this.Controls.Add(this.Btn_Exportar_PDF);
            this.Controls.Add(this.Btn_Consultar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Rpt_Ventas_";
            this.Text = "Reporte de Ventas";
            this.Load += new System.EventHandler(this.Frm_Rpt_Ventas__Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultados_Busqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Museo;
        private System.Windows.Forms.ComboBox Cmb_Lugar_Venta;
        private System.Windows.Forms.Label Lbl_Lugar_Venta;
        private System.Windows.Forms.ComboBox Cmb_Turnos;
        private System.Windows.Forms.ComboBox Cmb_Cajas;
        private System.Windows.Forms.Label Lbl_Turno;
        private System.Windows.Forms.Label Lbl_Caja;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Termino;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Inicio;
        private System.Windows.Forms.Label Lbl_Fecha_Termino;
        private System.Windows.Forms.Label Lbl_Fecha_Inicio_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Anio;
        private System.Windows.Forms.Label Lbl_Anio;
        private System.Windows.Forms.ComboBox Cmb_Producto;
        private System.Windows.Forms.Label Lbl_Producto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Grid_Resultados_Busqueda;
        private System.Windows.Forms.Button Btn_Exportar_Excel;
        private System.Windows.Forms.Button Btn_Exportar_PDF;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.TextBox Txt_Folio_Venta;
        private System.Windows.Forms.Label label2;
    }
}