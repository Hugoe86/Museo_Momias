namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rpt_Ventas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl_Filtros_Busqueda = new System.Windows.Forms.GroupBox();
            this.Cmb_Anio = new System.Windows.Forms.ComboBox();
            this.Lbl_Anio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Museo = new System.Windows.Forms.ComboBox();
            this.Cmb_Lugar_Venta = new System.Windows.Forms.ComboBox();
            this.Lbl_Lugar_Venta = new System.Windows.Forms.Label();
            this.Cmb_Movimientos = new System.Windows.Forms.ComboBox();
            this.Lbl_Movimiento = new System.Windows.Forms.Label();
            this.Cmb_Producto = new System.Windows.Forms.ComboBox();
            this.Lbl_Producto = new System.Windows.Forms.Label();
            this.Cmb_Turnos = new System.Windows.Forms.ComboBox();
            this.Cmb_Cajas = new System.Windows.Forms.ComboBox();
            this.Lbl_Turno = new System.Windows.Forms.Label();
            this.Lbl_Caja = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Termino = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Fecha_Inicio = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Fecha_Termino = new System.Windows.Forms.Label();
            this.Lbl_Fecha_Inicio_Busqueda = new System.Windows.Forms.Label();
            this.Pnl_Registros = new System.Windows.Forms.GroupBox();
            this.Grid_Resultados_Busqueda = new System.Windows.Forms.DataGridView();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_Exportar_PDF = new System.Windows.Forms.Button();
            this.Btn_Consulta_Detallada = new System.Windows.Forms.Button();
            this.Btn_Exportar_Excel = new System.Windows.Forms.Button();
            this.Pnl_Filtros_Busqueda.SuspendLayout();
            this.Pnl_Registros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultados_Busqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Filtros_Busqueda
            // 
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Anio);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Anio);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.label1);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Museo);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Lugar_Venta);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Lugar_Venta);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Movimientos);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Movimiento);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Producto);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Producto);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Turnos);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Cajas);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Turno);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Caja);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Dtp_Fecha_Termino);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Dtp_Fecha_Inicio);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Fecha_Termino);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Fecha_Inicio_Busqueda);
            this.Pnl_Filtros_Busqueda.Font = new System.Drawing.Font("Consolas", 10F);
            this.Pnl_Filtros_Busqueda.Location = new System.Drawing.Point(12, 3);
            this.Pnl_Filtros_Busqueda.Name = "Pnl_Filtros_Busqueda";
            this.Pnl_Filtros_Busqueda.Size = new System.Drawing.Size(705, 139);
            this.Pnl_Filtros_Busqueda.TabIndex = 0;
            this.Pnl_Filtros_Busqueda.TabStop = false;
            this.Pnl_Filtros_Busqueda.Text = "Filtros Búsqueda";
            // 
            // Cmb_Anio
            // 
            this.Cmb_Anio.FormattingEnabled = true;
            this.Cmb_Anio.Items.AddRange(new object[] {
            "SELECCIONE",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015"});
            this.Cmb_Anio.Location = new System.Drawing.Point(51, 103);
            this.Cmb_Anio.Name = "Cmb_Anio";
            this.Cmb_Anio.Size = new System.Drawing.Size(94, 23);
            this.Cmb_Anio.TabIndex = 17;
            this.Cmb_Anio.SelectedIndexChanged += new System.EventHandler(this.Cmb_Anio_SelectedIndexChanged);
            // 
            // Lbl_Anio
            // 
            this.Lbl_Anio.AutoSize = true;
            this.Lbl_Anio.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Anio.Location = new System.Drawing.Point(13, 108);
            this.Lbl_Anio.Name = "Lbl_Anio";
            this.Lbl_Anio.Size = new System.Drawing.Size(32, 18);
            this.Lbl_Anio.TabIndex = 16;
            this.Lbl_Anio.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11F);
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Museo";
            // 
            // Cmb_Museo
            // 
            this.Cmb_Museo.FormattingEnabled = true;
            this.Cmb_Museo.Items.AddRange(new object[] {
            "SELECCIONE",
            "MUSEO MOMIAS",
            "CULTO A LA MUERTE"});
            this.Cmb_Museo.Location = new System.Drawing.Point(129, 75);
            this.Cmb_Museo.Name = "Cmb_Museo";
            this.Cmb_Museo.Size = new System.Drawing.Size(200, 23);
            this.Cmb_Museo.TabIndex = 14;
            // 
            // Cmb_Lugar_Venta
            // 
            this.Cmb_Lugar_Venta.FormattingEnabled = true;
            this.Cmb_Lugar_Venta.Items.AddRange(new object[] {
            "SELECCIONE",
            "No Caja",
            "Internet",
            "Kiosko"});
            this.Cmb_Lugar_Venta.Location = new System.Drawing.Point(483, 74);
            this.Cmb_Lugar_Venta.Name = "Cmb_Lugar_Venta";
            this.Cmb_Lugar_Venta.Size = new System.Drawing.Size(200, 23);
            this.Cmb_Lugar_Venta.TabIndex = 13;
            // 
            // Lbl_Lugar_Venta
            // 
            this.Lbl_Lugar_Venta.AutoSize = true;
            this.Lbl_Lugar_Venta.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Lugar_Venta.Location = new System.Drawing.Point(367, 75);
            this.Lbl_Lugar_Venta.Name = "Lbl_Lugar_Venta";
            this.Lbl_Lugar_Venta.Size = new System.Drawing.Size(120, 18);
            this.Lbl_Lugar_Venta.TabIndex = 12;
            this.Lbl_Lugar_Venta.Text = "Lugar de venta";
            // 
            // Cmb_Movimientos
            // 
            this.Cmb_Movimientos.FormattingEnabled = true;
            this.Cmb_Movimientos.Location = new System.Drawing.Point(483, 103);
            this.Cmb_Movimientos.Name = "Cmb_Movimientos";
            this.Cmb_Movimientos.Size = new System.Drawing.Size(200, 23);
            this.Cmb_Movimientos.TabIndex = 11;
            this.Cmb_Movimientos.Visible = false;
            this.Cmb_Movimientos.SelectedIndexChanged += new System.EventHandler(this.Cmb_Movimientos_SelectedIndexChanged);
            // 
            // Lbl_Movimiento
            // 
            this.Lbl_Movimiento.AutoSize = true;
            this.Lbl_Movimiento.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Movimiento.Location = new System.Drawing.Point(367, 108);
            this.Lbl_Movimiento.Name = "Lbl_Movimiento";
            this.Lbl_Movimiento.Size = new System.Drawing.Size(88, 18);
            this.Lbl_Movimiento.TabIndex = 10;
            this.Lbl_Movimiento.Text = "Movimiento";
            this.Lbl_Movimiento.Visible = false;
            // 
            // Cmb_Producto
            // 
            this.Cmb_Producto.FormattingEnabled = true;
            this.Cmb_Producto.Items.AddRange(new object[] {
            "SELECCIONE"});
            this.Cmb_Producto.Location = new System.Drawing.Point(238, 103);
            this.Cmb_Producto.Name = "Cmb_Producto";
            this.Cmb_Producto.Size = new System.Drawing.Size(445, 23);
            this.Cmb_Producto.TabIndex = 9;
            // 
            // Lbl_Producto
            // 
            this.Lbl_Producto.AutoSize = true;
            this.Lbl_Producto.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Producto.Location = new System.Drawing.Point(160, 108);
            this.Lbl_Producto.Name = "Lbl_Producto";
            this.Lbl_Producto.Size = new System.Drawing.Size(72, 18);
            this.Lbl_Producto.TabIndex = 8;
            this.Lbl_Producto.Text = "Producto";
            // 
            // Cmb_Turnos
            // 
            this.Cmb_Turnos.FormattingEnabled = true;
            this.Cmb_Turnos.Location = new System.Drawing.Point(483, 49);
            this.Cmb_Turnos.Name = "Cmb_Turnos";
            this.Cmb_Turnos.Size = new System.Drawing.Size(200, 23);
            this.Cmb_Turnos.TabIndex = 7;
            // 
            // Cmb_Cajas
            // 
            this.Cmb_Cajas.FormattingEnabled = true;
            this.Cmb_Cajas.Location = new System.Drawing.Point(129, 49);
            this.Cmb_Cajas.Name = "Cmb_Cajas";
            this.Cmb_Cajas.Size = new System.Drawing.Size(200, 23);
            this.Cmb_Cajas.TabIndex = 6;
            // 
            // Lbl_Turno
            // 
            this.Lbl_Turno.AutoSize = true;
            this.Lbl_Turno.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Turno.Location = new System.Drawing.Point(365, 50);
            this.Lbl_Turno.Name = "Lbl_Turno";
            this.Lbl_Turno.Size = new System.Drawing.Size(48, 18);
            this.Lbl_Turno.TabIndex = 5;
            this.Lbl_Turno.Text = "Turno";
            // 
            // Lbl_Caja
            // 
            this.Lbl_Caja.AutoSize = true;
            this.Lbl_Caja.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Caja.Location = new System.Drawing.Point(13, 50);
            this.Lbl_Caja.Name = "Lbl_Caja";
            this.Lbl_Caja.Size = new System.Drawing.Size(40, 18);
            this.Lbl_Caja.TabIndex = 4;
            this.Lbl_Caja.Text = "Caja";
            // 
            // Dtp_Fecha_Termino
            // 
            this.Dtp_Fecha_Termino.Checked = false;
            this.Dtp_Fecha_Termino.CustomFormat = "dd MMMM yyyy";
            this.Dtp_Fecha_Termino.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Termino.Location = new System.Drawing.Point(483, 20);
            this.Dtp_Fecha_Termino.Name = "Dtp_Fecha_Termino";
            this.Dtp_Fecha_Termino.ShowCheckBox = true;
            this.Dtp_Fecha_Termino.Size = new System.Drawing.Size(200, 23);
            this.Dtp_Fecha_Termino.TabIndex = 3;
            // 
            // Dtp_Fecha_Inicio
            // 
            this.Dtp_Fecha_Inicio.Checked = false;
            this.Dtp_Fecha_Inicio.CustomFormat = "dd MMMM yyyy";
            this.Dtp_Fecha_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Inicio.Location = new System.Drawing.Point(129, 20);
            this.Dtp_Fecha_Inicio.Name = "Dtp_Fecha_Inicio";
            this.Dtp_Fecha_Inicio.ShowCheckBox = true;
            this.Dtp_Fecha_Inicio.Size = new System.Drawing.Size(200, 23);
            this.Dtp_Fecha_Inicio.TabIndex = 2;
            // 
            // Lbl_Fecha_Termino
            // 
            this.Lbl_Fecha_Termino.AutoSize = true;
            this.Lbl_Fecha_Termino.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Fecha_Termino.Location = new System.Drawing.Point(365, 21);
            this.Lbl_Fecha_Termino.Name = "Lbl_Fecha_Termino";
            this.Lbl_Fecha_Termino.Size = new System.Drawing.Size(112, 18);
            this.Lbl_Fecha_Termino.TabIndex = 1;
            this.Lbl_Fecha_Termino.Text = "Fecha Término";
            // 
            // Lbl_Fecha_Inicio_Busqueda
            // 
            this.Lbl_Fecha_Inicio_Busqueda.AutoSize = true;
            this.Lbl_Fecha_Inicio_Busqueda.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Fecha_Inicio_Busqueda.Location = new System.Drawing.Point(13, 21);
            this.Lbl_Fecha_Inicio_Busqueda.Name = "Lbl_Fecha_Inicio_Busqueda";
            this.Lbl_Fecha_Inicio_Busqueda.Size = new System.Drawing.Size(104, 18);
            this.Lbl_Fecha_Inicio_Busqueda.TabIndex = 0;
            this.Lbl_Fecha_Inicio_Busqueda.Text = "Fecha Inicio";
            // 
            // Pnl_Registros
            // 
            this.Pnl_Registros.Controls.Add(this.Grid_Resultados_Busqueda);
            this.Pnl_Registros.Font = new System.Drawing.Font("Consolas", 10F);
            this.Pnl_Registros.Location = new System.Drawing.Point(12, 186);
            this.Pnl_Registros.Name = "Pnl_Registros";
            this.Pnl_Registros.Size = new System.Drawing.Size(704, 463);
            this.Pnl_Registros.TabIndex = 1;
            this.Pnl_Registros.TabStop = false;
            this.Pnl_Registros.Text = "Resultado de la Busqueda";
            // 
            // Grid_Resultados_Busqueda
            // 
            this.Grid_Resultados_Busqueda.AllowUserToAddRows = false;
            this.Grid_Resultados_Busqueda.AllowUserToDeleteRows = false;
            this.Grid_Resultados_Busqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grid_Resultados_Busqueda.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Resultados_Busqueda.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Resultados_Busqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Consolas", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Resultados_Busqueda.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grid_Resultados_Busqueda.Location = new System.Drawing.Point(14, 20);
            this.Grid_Resultados_Busqueda.Name = "Grid_Resultados_Busqueda";
            this.Grid_Resultados_Busqueda.Size = new System.Drawing.Size(676, 429);
            this.Grid_Resultados_Busqueda.TabIndex = 0;
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.BackColor = System.Drawing.Color.White;
            this.Btn_Consultar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Consultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Consultar.Font = new System.Drawing.Font("Consolas", 11F);
            this.Btn_Consultar.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Consultar.Location = new System.Drawing.Point(28, 148);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(164, 30);
            this.Btn_Consultar.TabIndex = 2;
            this.Btn_Consultar.Text = "General";
            this.Btn_Consultar.UseVisualStyleBackColor = false;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_Exportar_PDF
            // 
            this.Btn_Exportar_PDF.BackColor = System.Drawing.Color.White;
            this.Btn_Exportar_PDF.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Exportar_PDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exportar_PDF.Font = new System.Drawing.Font("Consolas", 11F);
            this.Btn_Exportar_PDF.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Exportar_PDF.Location = new System.Drawing.Point(368, 148);
            this.Btn_Exportar_PDF.Name = "Btn_Exportar_PDF";
            this.Btn_Exportar_PDF.Size = new System.Drawing.Size(164, 30);
            this.Btn_Exportar_PDF.TabIndex = 3;
            this.Btn_Exportar_PDF.Text = "Exportar PDF";
            this.Btn_Exportar_PDF.UseVisualStyleBackColor = false;
            this.Btn_Exportar_PDF.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Btn_Consulta_Detallada
            // 
            this.Btn_Consulta_Detallada.BackColor = System.Drawing.Color.White;
            this.Btn_Consulta_Detallada.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Consulta_Detallada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Consulta_Detallada.Font = new System.Drawing.Font("Consolas", 11F);
            this.Btn_Consulta_Detallada.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Consulta_Detallada.Location = new System.Drawing.Point(198, 148);
            this.Btn_Consulta_Detallada.Name = "Btn_Consulta_Detallada";
            this.Btn_Consulta_Detallada.Size = new System.Drawing.Size(164, 30);
            this.Btn_Consulta_Detallada.TabIndex = 4;
            this.Btn_Consulta_Detallada.Text = "Detallado";
            this.Btn_Consulta_Detallada.UseVisualStyleBackColor = false;
            this.Btn_Consulta_Detallada.Click += new System.EventHandler(this.Btn_Consulta_Detallada_Click);
            // 
            // Btn_Exportar_Excel
            // 
            this.Btn_Exportar_Excel.BackColor = System.Drawing.Color.White;
            this.Btn_Exportar_Excel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Btn_Exportar_Excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exportar_Excel.Font = new System.Drawing.Font("Consolas", 11F);
            this.Btn_Exportar_Excel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_Exportar_Excel.Location = new System.Drawing.Point(538, 148);
            this.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel";
            this.Btn_Exportar_Excel.Size = new System.Drawing.Size(164, 30);
            this.Btn_Exportar_Excel.TabIndex = 5;
            this.Btn_Exportar_Excel.Text = "Exportar Excel";
            this.Btn_Exportar_Excel.UseVisualStyleBackColor = false;
            this.Btn_Exportar_Excel.Click += new System.EventHandler(this.Btn_Exportar_Excel_Click);
            // 
            // Frm_Rpt_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(728, 661);
            this.Controls.Add(this.Btn_Exportar_Excel);
            this.Controls.Add(this.Btn_Consulta_Detallada);
            this.Controls.Add(this.Btn_Exportar_PDF);
            this.Controls.Add(this.Btn_Consultar);
            this.Controls.Add(this.Pnl_Registros);
            this.Controls.Add(this.Pnl_Filtros_Busqueda);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Rpt_Ventas";
            this.Text = "Reporte de Movimientos";
            this.Load += new System.EventHandler(this.Frm_Rpt_Ventas_Load);
            this.Pnl_Filtros_Busqueda.ResumeLayout(false);
            this.Pnl_Filtros_Busqueda.PerformLayout();
            this.Pnl_Registros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultados_Busqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Pnl_Filtros_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Movimientos;
        private System.Windows.Forms.Label Lbl_Movimiento;
        private System.Windows.Forms.ComboBox Cmb_Producto;
        private System.Windows.Forms.Label Lbl_Producto;
        private System.Windows.Forms.ComboBox Cmb_Turnos;
        private System.Windows.Forms.ComboBox Cmb_Cajas;
        private System.Windows.Forms.Label Lbl_Turno;
        private System.Windows.Forms.Label Lbl_Caja;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Termino;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Inicio;
        private System.Windows.Forms.Label Lbl_Fecha_Termino;
        private System.Windows.Forms.Label Lbl_Fecha_Inicio_Busqueda;
        private System.Windows.Forms.GroupBox Pnl_Registros;
        private System.Windows.Forms.DataGridView Grid_Resultados_Busqueda;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_Exportar_PDF;
        private System.Windows.Forms.Button Btn_Consulta_Detallada;
        private System.Windows.Forms.Button Btn_Exportar_Excel;
        private System.Windows.Forms.Label Lbl_Lugar_Venta;
        private System.Windows.Forms.ComboBox Cmb_Lugar_Venta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Museo;
        private System.Windows.Forms.ComboBox Cmb_Anio;
        private System.Windows.Forms.Label Lbl_Anio;
    }
}