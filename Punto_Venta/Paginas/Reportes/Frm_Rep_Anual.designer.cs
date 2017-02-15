namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rep_Anual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Rep_Anual));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Flp_Barra_Herramientas = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Exportar_PDF = new System.Windows.Forms.Button();
            this.Btn_Exportar_Excel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Cmb_Producto = new System.Windows.Forms.ComboBox();
            this.Cmb_Anio = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Cmb_Museo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Cmb_Tipo_Reporte = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cmb_Turno = new System.Windows.Forms.ComboBox();
            this.Cmb_Lugar_Venta = new System.Windows.Forms.ComboBox();
            this.Cmb_Numero_Caja = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cmb_Anio_Final = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_Anio_Inicial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Pnl_Mensaje = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Grd_Resultados = new System.Windows.Forms.DataGridView();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Flp_Barra_Herramientas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Pnl_Mensaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // Flp_Barra_Herramientas
            // 
            this.Flp_Barra_Herramientas.BackColor = System.Drawing.Color.AliceBlue;
            this.Flp_Barra_Herramientas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Buscar);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_PDF);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_Excel);
            this.Flp_Barra_Herramientas.Location = new System.Drawing.Point(12, 12);
            this.Flp_Barra_Herramientas.Name = "Flp_Barra_Herramientas";
            this.Flp_Barra_Herramientas.Size = new System.Drawing.Size(605, 36);
            this.Flp_Barra_Herramientas.TabIndex = 13;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Image = global::ERP_BASE.Properties.Resources.icono_busqueda_24x20;
            this.Btn_Buscar.Location = new System.Drawing.Point(3, 3);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(40, 28);
            this.Btn_Buscar.TabIndex = 0;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Exportar_PDF
            // 
            this.Btn_Exportar_PDF.Image = global::ERP_BASE.Properties.Resources.icono_rep_pdf;
            this.Btn_Exportar_PDF.Location = new System.Drawing.Point(49, 3);
            this.Btn_Exportar_PDF.Name = "Btn_Exportar_PDF";
            this.Btn_Exportar_PDF.Size = new System.Drawing.Size(40, 28);
            this.Btn_Exportar_PDF.TabIndex = 1;
            this.Btn_Exportar_PDF.UseVisualStyleBackColor = true;
            this.Btn_Exportar_PDF.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Btn_Exportar_Excel
            // 
            this.Btn_Exportar_Excel.Image = global::ERP_BASE.Properties.Resources.icono_rep_excel;
            this.Btn_Exportar_Excel.Location = new System.Drawing.Point(95, 3);
            this.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel";
            this.Btn_Exportar_Excel.Size = new System.Drawing.Size(40, 28);
            this.Btn_Exportar_Excel.TabIndex = 2;
            this.Btn_Exportar_Excel.UseVisualStyleBackColor = true;
            this.Btn_Exportar_Excel.Click += new System.EventHandler(this.Btn_Exportar_Excel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(798, 36);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.Cmb_Producto);
            this.groupBox1.Controls.Add(this.Cmb_Anio);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Cmb_Museo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Cmb_Tipo_Reporte);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Cmb_Turno);
            this.groupBox1.Controls.Add(this.Cmb_Lugar_Venta);
            this.groupBox1.Controls.Add(this.Cmb_Numero_Caja);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Cmb_Anio_Final);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Cmb_Anio_Inicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 177);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "Tarifa";
            // 
            // Cmb_Producto
            // 
            this.Cmb_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Producto.FormattingEnabled = true;
            this.Cmb_Producto.Location = new System.Drawing.Point(121, 137);
            this.Cmb_Producto.Name = "Cmb_Producto";
            this.Cmb_Producto.Size = new System.Drawing.Size(478, 24);
            this.Cmb_Producto.TabIndex = 18;
            // 
            // Cmb_Anio
            // 
            this.Cmb_Anio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Anio.FormattingEnabled = true;
            this.Cmb_Anio.Location = new System.Drawing.Point(121, 107);
            this.Cmb_Anio.Name = "Cmb_Anio";
            this.Cmb_Anio.Size = new System.Drawing.Size(150, 24);
            this.Cmb_Anio.TabIndex = 17;
            this.Cmb_Anio.SelectedIndexChanged += new System.EventHandler(this.Cmb_Anio_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 18);
            this.label9.TabIndex = 16;
            this.label9.Text = "Año";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(296, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Museo";
            // 
            // Cmb_Museo
            // 
            this.Cmb_Museo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Museo.FormattingEnabled = true;
            this.Cmb_Museo.Items.AddRange(new object[] {
            "SELECCIONE",
            "MUSEO MOMIAS",
            "CULTO A LA MUERTE"});
            this.Cmb_Museo.Location = new System.Drawing.Point(396, 107);
            this.Cmb_Museo.Name = "Cmb_Museo";
            this.Cmb_Museo.Size = new System.Drawing.Size(203, 24);
            this.Cmb_Museo.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(296, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tipo Reporte";
            // 
            // Cmb_Tipo_Reporte
            // 
            this.Cmb_Tipo_Reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo_Reporte.FormattingEnabled = true;
            this.Cmb_Tipo_Reporte.Items.AddRange(new object[] {
            "SELECCIONE",
            "Recaudación por Tarifa",
            "Recuadación, Acumulado por Tarifa",
            "Visitantes, Acumulado por Tarifa",
            "Concentrado"});
            this.Cmb_Tipo_Reporte.Location = new System.Drawing.Point(396, 77);
            this.Cmb_Tipo_Reporte.Name = "Cmb_Tipo_Reporte";
            this.Cmb_Tipo_Reporte.Size = new System.Drawing.Size(203, 24);
            this.Cmb_Tipo_Reporte.TabIndex = 12;
            this.Cmb_Tipo_Reporte.SelectedIndexChanged += new System.EventHandler(this.Cmb_Tipo_Reporte_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(296, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Turno";
            // 
            // Cmb_Turno
            // 
            this.Cmb_Turno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Turno.FormattingEnabled = true;
            this.Cmb_Turno.Location = new System.Drawing.Point(396, 46);
            this.Cmb_Turno.Name = "Cmb_Turno";
            this.Cmb_Turno.Size = new System.Drawing.Size(203, 24);
            this.Cmb_Turno.TabIndex = 8;
            // 
            // Cmb_Lugar_Venta
            // 
            this.Cmb_Lugar_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Lugar_Venta.FormattingEnabled = true;
            this.Cmb_Lugar_Venta.Items.AddRange(new object[] {
            "SELECCIONE",
            "No Caja",
            "Internet",
            "Kiosko"});
            this.Cmb_Lugar_Venta.Location = new System.Drawing.Point(121, 76);
            this.Cmb_Lugar_Venta.Name = "Cmb_Lugar_Venta";
            this.Cmb_Lugar_Venta.Size = new System.Drawing.Size(150, 24);
            this.Cmb_Lugar_Venta.TabIndex = 7;
            // 
            // Cmb_Numero_Caja
            // 
            this.Cmb_Numero_Caja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Numero_Caja.FormattingEnabled = true;
            this.Cmb_Numero_Caja.Location = new System.Drawing.Point(121, 46);
            this.Cmb_Numero_Caja.Name = "Cmb_Numero_Caja";
            this.Cmb_Numero_Caja.Size = new System.Drawing.Size(150, 24);
            this.Cmb_Numero_Caja.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Lugar de Venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Número de Caja";
            // 
            // Cmb_Anio_Final
            // 
            this.Cmb_Anio_Final.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Anio_Final.FormattingEnabled = true;
            this.Cmb_Anio_Final.Location = new System.Drawing.Point(396, 17);
            this.Cmb_Anio_Final.Name = "Cmb_Anio_Final";
            this.Cmb_Anio_Final.Size = new System.Drawing.Size(203, 24);
            this.Cmb_Anio_Final.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año Final";
            // 
            // Cmb_Anio_Inicial
            // 
            this.Cmb_Anio_Inicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Anio_Inicial.FormattingEnabled = true;
            this.Cmb_Anio_Inicial.Location = new System.Drawing.Point(121, 17);
            this.Cmb_Anio_Inicial.Name = "Cmb_Anio_Inicial";
            this.Cmb_Anio_Inicial.Size = new System.Drawing.Size(150, 24);
            this.Cmb_Anio_Inicial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año Inicial";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Chart);
            this.groupBox2.Controls.Add(this.Pnl_Mensaje);
            this.groupBox2.Controls.Add(this.Grd_Resultados);
            this.groupBox2.Location = new System.Drawing.Point(12, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(605, 261);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // Pnl_Mensaje
            // 
            this.Pnl_Mensaje.BackColor = System.Drawing.Color.White;
            this.Pnl_Mensaje.Controls.Add(this.textBox1);
            this.Pnl_Mensaje.Controls.Add(this.pictureBox1);
            this.Pnl_Mensaje.Location = new System.Drawing.Point(3, 104);
            this.Pnl_Mensaje.Margin = new System.Windows.Forms.Padding(2);
            this.Pnl_Mensaje.Name = "Pnl_Mensaje";
            this.Pnl_Mensaje.Size = new System.Drawing.Size(599, 27);
            this.Pnl_Mensaje.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(202, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Cargando.. Espere un momento";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(148, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Grd_Resultados
            // 
            this.Grd_Resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Resultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Resultados.Location = new System.Drawing.Point(3, 16);
            this.Grd_Resultados.Name = "Grd_Resultados";
            this.Grd_Resultados.Size = new System.Drawing.Size(599, 242);
            this.Grd_Resultados.TabIndex = 0;
            this.Grd_Resultados.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grd_Resultados_CellFormatting);
            // 
            // Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(162, 23);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(300, 222);
            this.Chart.TabIndex = 4;
            this.Chart.Text = "chart1";
            this.Chart.Visible = false;
            // 
            // Frm_Rep_Anual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 510);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Flp_Barra_Herramientas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Rep_Anual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Análisis Anual";
            this.Load += new System.EventHandler(this.Frm_Rep_Anual_Load);
            this.Flp_Barra_Herramientas.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.Pnl_Mensaje.ResumeLayout(false);
            this.Pnl_Mensaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Flp_Barra_Herramientas;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Exportar_PDF;
        private System.Windows.Forms.Button Btn_Exportar_Excel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Cmb_Anio_Inicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Anio_Final;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Cmb_Lugar_Venta;
        private System.Windows.Forms.ComboBox Cmb_Numero_Caja;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cmb_Tipo_Reporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cmb_Turno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Grd_Resultados;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Pnl_Mensaje;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox Cmb_Museo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Cmb_Producto;
        private System.Windows.Forms.ComboBox Cmb_Anio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
    }
}