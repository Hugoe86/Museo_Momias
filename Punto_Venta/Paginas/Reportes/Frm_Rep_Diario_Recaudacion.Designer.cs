namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rep_Diario_Recaudacion
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
            this.Spl_Contenedor = new System.Windows.Forms.SplitContainer();
            this.Grp_Filtros = new System.Windows.Forms.GroupBox();
            this.Cmb_Anio = new System.Windows.Forms.ComboBox();
            this.Lbl_Anio = new System.Windows.Forms.Label();
            this.Cmb_Tarifa = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Cmb_Tipo_Reporte = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Tarifa = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Lbl_Tipo_Reporte = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Dtp_Periodo_Final = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.Dtp_Periodo_Inicial = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.Lbl_Anio_Final = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Lbl_Anio_Inicial = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Lbl_No_Caja = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Lbl_Turno = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_No_Caja = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Cmb_Turno = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Tipo_Pago = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_Tipo_Pago = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Lugar_Venta = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_Lugar_Venta = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Flp_Barra_Herramientas = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Buscar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Exportar_PDF = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Exportar_PDF_iTextSharp = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Exportar_Excel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Grp_Resultados = new System.Windows.Forms.GroupBox();
            this.Grd_Resultado = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).BeginInit();
            this.Spl_Contenedor.Panel1.SuspendLayout();
            this.Spl_Contenedor.Panel2.SuspendLayout();
            this.Spl_Contenedor.SuspendLayout();
            this.Grp_Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tarifa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Reporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_No_Caja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Turno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Pago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Lugar_Venta)).BeginInit();
            this.Flp_Barra_Herramientas.SuspendLayout();
            this.Grp_Resultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // Spl_Contenedor
            // 
            this.Spl_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Spl_Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Spl_Contenedor.Name = "Spl_Contenedor";
            this.Spl_Contenedor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Spl_Contenedor.Panel1
            // 
            this.Spl_Contenedor.Panel1.Controls.Add(this.Grp_Filtros);
            this.Spl_Contenedor.Panel1.Controls.Add(this.Flp_Barra_Herramientas);
            this.Spl_Contenedor.Panel1MinSize = 121;
            // 
            // Spl_Contenedor.Panel2
            // 
            this.Spl_Contenedor.Panel2.Controls.Add(this.Grp_Resultados);
            this.Spl_Contenedor.Size = new System.Drawing.Size(822, 676);
            this.Spl_Contenedor.SplitterDistance = 195;
            this.Spl_Contenedor.TabIndex = 0;
            this.Spl_Contenedor.TabStop = false;
            // 
            // Grp_Filtros
            // 
            this.Grp_Filtros.Controls.Add(this.Cmb_Anio);
            this.Grp_Filtros.Controls.Add(this.Lbl_Anio);
            this.Grp_Filtros.Controls.Add(this.Cmb_Tarifa);
            this.Grp_Filtros.Controls.Add(this.Cmb_Tipo_Reporte);
            this.Grp_Filtros.Controls.Add(this.Lbl_Tarifa);
            this.Grp_Filtros.Controls.Add(this.Lbl_Tipo_Reporte);
            this.Grp_Filtros.Controls.Add(this.Dtp_Periodo_Final);
            this.Grp_Filtros.Controls.Add(this.Dtp_Periodo_Inicial);
            this.Grp_Filtros.Controls.Add(this.Lbl_Anio_Final);
            this.Grp_Filtros.Controls.Add(this.Lbl_Anio_Inicial);
            this.Grp_Filtros.Controls.Add(this.Lbl_No_Caja);
            this.Grp_Filtros.Controls.Add(this.Lbl_Turno);
            this.Grp_Filtros.Controls.Add(this.Cmb_No_Caja);
            this.Grp_Filtros.Controls.Add(this.Cmb_Turno);
            this.Grp_Filtros.Controls.Add(this.Lbl_Tipo_Pago);
            this.Grp_Filtros.Controls.Add(this.Cmb_Tipo_Pago);
            this.Grp_Filtros.Controls.Add(this.Lbl_Lugar_Venta);
            this.Grp_Filtros.Controls.Add(this.Cmb_Lugar_Venta);
            this.Grp_Filtros.Location = new System.Drawing.Point(13, 46);
            this.Grp_Filtros.Name = "Grp_Filtros";
            this.Grp_Filtros.Size = new System.Drawing.Size(797, 131);
            this.Grp_Filtros.TabIndex = 13;
            this.Grp_Filtros.TabStop = false;
            this.Grp_Filtros.Text = "Filtros para la búsqueda";
            // 
            // Cmb_Anio
            // 
            this.Cmb_Anio.FormattingEnabled = true;
            this.Cmb_Anio.Location = new System.Drawing.Point(162, 102);
            this.Cmb_Anio.Name = "Cmb_Anio";
            this.Cmb_Anio.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Cmb_Anio.Size = new System.Drawing.Size(103, 21);
            this.Cmb_Anio.TabIndex = 21;
            this.Cmb_Anio.SelectedIndexChanged += new System.EventHandler(this.Cmb_Anio_SelectedIndexChanged);
            // 
            // Lbl_Anio
            // 
            this.Lbl_Anio.AutoSize = true;
            this.Lbl_Anio.Location = new System.Drawing.Point(11, 105);
            this.Lbl_Anio.Name = "Lbl_Anio";
            this.Lbl_Anio.Size = new System.Drawing.Size(26, 13);
            this.Lbl_Anio.TabIndex = 20;
            this.Lbl_Anio.Text = "Año";
            // 
            // Cmb_Tarifa
            // 
            this.Cmb_Tarifa.DropDownWidth = 168;
            this.Cmb_Tarifa.Items.AddRange(new object[] {
            "SELECCIONE"});
            this.Cmb_Tarifa.Location = new System.Drawing.Point(362, 100);
            this.Cmb_Tarifa.Name = "Cmb_Tarifa";
            this.Cmb_Tarifa.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Cmb_Tarifa.Size = new System.Drawing.Size(402, 21);
            this.Cmb_Tarifa.TabIndex = 9;
            // 
            // Cmb_Tipo_Reporte
            // 
            this.Cmb_Tipo_Reporte.DropDownWidth = 168;
            this.Cmb_Tipo_Reporte.Items.AddRange(new object[] {
            "Ingresos",
            "Visitantes",
            "Comparativo"});
            this.Cmb_Tipo_Reporte.Location = new System.Drawing.Point(162, 40);
            this.Cmb_Tipo_Reporte.Name = "Cmb_Tipo_Reporte";
            this.Cmb_Tipo_Reporte.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Cmb_Tipo_Reporte.Size = new System.Drawing.Size(193, 21);
            this.Cmb_Tipo_Reporte.TabIndex = 7;
            this.Cmb_Tipo_Reporte.SelectedIndexChanged += new System.EventHandler(Cmb_Tipo_ReporteSelectedIndexChanged);
            // 
            // Lbl_Tarifa
            // 
            this.Lbl_Tarifa.Location = new System.Drawing.Point(316, 100);
            this.Lbl_Tarifa.Name = "Lbl_Tarifa";
            this.Lbl_Tarifa.Size = new System.Drawing.Size(41, 20);
            this.Lbl_Tarifa.TabIndex = 8;
            this.Lbl_Tarifa.Values.Text = "Tarifa";
            // 
            // Lbl_Tipo_Reporte
            // 
            this.Lbl_Tipo_Reporte.Location = new System.Drawing.Point(6, 40);
            this.Lbl_Tipo_Reporte.Name = "Lbl_Tipo_Reporte";
            this.Lbl_Tipo_Reporte.Size = new System.Drawing.Size(54, 20);
            this.Lbl_Tipo_Reporte.TabIndex = 6;
            this.Lbl_Tipo_Reporte.Values.Text = "Reporte";
            // 
            // Dtp_Periodo_Final
            // 
            this.Dtp_Periodo_Final.Location = new System.Drawing.Point(571, 20);
            this.Dtp_Periodo_Final.Name = "Dtp_Periodo_Final";
            this.Dtp_Periodo_Final.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Dtp_Periodo_Final.Size = new System.Drawing.Size(193, 21);
            this.Dtp_Periodo_Final.TabIndex = 5;
            // 
            // Dtp_Periodo_Inicial
            // 
            this.Dtp_Periodo_Inicial.CalendarShowToday = false;
            this.Dtp_Periodo_Inicial.Location = new System.Drawing.Point(162, 20);
            this.Dtp_Periodo_Inicial.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.Dtp_Periodo_Inicial.Name = "Dtp_Periodo_Inicial";
            this.Dtp_Periodo_Inicial.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Dtp_Periodo_Inicial.Size = new System.Drawing.Size(193, 21);
            this.Dtp_Periodo_Inicial.TabIndex = 4;
            // 
            // Lbl_Anio_Final
            // 
            this.Lbl_Anio_Final.Location = new System.Drawing.Point(423, 20);
            this.Lbl_Anio_Final.Name = "Lbl_Anio_Final";
            this.Lbl_Anio_Final.Size = new System.Drawing.Size(79, 20);
            this.Lbl_Anio_Final.TabIndex = 2;
            this.Lbl_Anio_Final.Values.Text = "Periodo final";
            // 
            // Lbl_Anio_Inicial
            // 
            this.Lbl_Anio_Inicial.Location = new System.Drawing.Point(6, 20);
            this.Lbl_Anio_Inicial.Name = "Lbl_Anio_Inicial";
            this.Lbl_Anio_Inicial.Size = new System.Drawing.Size(87, 20);
            this.Lbl_Anio_Inicial.TabIndex = 0;
            this.Lbl_Anio_Inicial.Values.Text = "Periodo inicial";
            // 
            // Lbl_No_Caja
            // 
            this.Lbl_No_Caja.Location = new System.Drawing.Point(6, 60);
            this.Lbl_No_Caja.Name = "Lbl_No_Caja";
            this.Lbl_No_Caja.Size = new System.Drawing.Size(54, 20);
            this.Lbl_No_Caja.TabIndex = 0;
            this.Lbl_No_Caja.Values.Text = "No Caja";
            // 
            // Lbl_Turno
            // 
            this.Lbl_Turno.Location = new System.Drawing.Point(423, 40);
            this.Lbl_Turno.Name = "Lbl_Turno";
            this.Lbl_Turno.Size = new System.Drawing.Size(43, 20);
            this.Lbl_Turno.TabIndex = 0;
            this.Lbl_Turno.Values.Text = "Turno";
            // 
            // Cmb_No_Caja
            // 
            this.Cmb_No_Caja.DropDownWidth = 168;
            this.Cmb_No_Caja.Location = new System.Drawing.Point(162, 60);
            this.Cmb_No_Caja.Name = "Cmb_No_Caja";
            this.Cmb_No_Caja.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Cmb_No_Caja.Size = new System.Drawing.Size(193, 21);
            this.Cmb_No_Caja.TabIndex = 7;
            // 
            // Cmb_Turno
            // 
            this.Cmb_Turno.DropDownWidth = 168;
            this.Cmb_Turno.Location = new System.Drawing.Point(571, 40);
            this.Cmb_Turno.Name = "Cmb_Turno";
            this.Cmb_Turno.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Cmb_Turno.Size = new System.Drawing.Size(193, 21);
            this.Cmb_Turno.TabIndex = 7;
            // 
            // Lbl_Tipo_Pago
            // 
            this.Lbl_Tipo_Pago.Location = new System.Drawing.Point(6, 80);
            this.Lbl_Tipo_Pago.Name = "Lbl_Tipo_Pago";
            this.Lbl_Tipo_Pago.Size = new System.Drawing.Size(83, 20);
            this.Lbl_Tipo_Pago.TabIndex = 8;
            this.Lbl_Tipo_Pago.Values.Text = "Tipo de Pago";
            // 
            // Cmb_Tipo_Pago
            // 
            this.Cmb_Tipo_Pago.DropDownWidth = 168;
            this.Cmb_Tipo_Pago.Items.AddRange(new object[] {
            "",
            "Efectivo",
            "Credito-Debito"});
            this.Cmb_Tipo_Pago.Location = new System.Drawing.Point(162, 80);
            this.Cmb_Tipo_Pago.Name = "Cmb_Tipo_Pago";
            this.Cmb_Tipo_Pago.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Cmb_Tipo_Pago.Size = new System.Drawing.Size(193, 21);
            this.Cmb_Tipo_Pago.TabIndex = 7;
            // 
            // Lbl_Lugar_Venta
            // 
            this.Lbl_Lugar_Venta.Location = new System.Drawing.Point(423, 60);
            this.Lbl_Lugar_Venta.Name = "Lbl_Lugar_Venta";
            this.Lbl_Lugar_Venta.Size = new System.Drawing.Size(92, 20);
            this.Lbl_Lugar_Venta.TabIndex = 18;
            this.Lbl_Lugar_Venta.Values.Text = "Lugar de venta";
            // 
            // Cmb_Lugar_Venta
            // 
            this.Cmb_Lugar_Venta.DropDownWidth = 168;
            this.Cmb_Lugar_Venta.Items.AddRange(new object[] {
            "",
            "No. caja",
            "Internet",
            "Kiosko"});
            this.Cmb_Lugar_Venta.Location = new System.Drawing.Point(571, 60);
            this.Cmb_Lugar_Venta.Name = "Cmb_Lugar_Venta";
            this.Cmb_Lugar_Venta.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Cmb_Lugar_Venta.Size = new System.Drawing.Size(193, 21);
            this.Cmb_Lugar_Venta.TabIndex = 19;
            // 
            // Flp_Barra_Herramientas
            // 
            this.Flp_Barra_Herramientas.BackColor = System.Drawing.Color.AliceBlue;
            this.Flp_Barra_Herramientas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Buscar);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_PDF);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_PDF_iTextSharp);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_Excel);
            this.Flp_Barra_Herramientas.Location = new System.Drawing.Point(12, 3);
            this.Flp_Barra_Herramientas.Name = "Flp_Barra_Herramientas";
            this.Flp_Barra_Herramientas.Size = new System.Drawing.Size(798, 36);
            this.Flp_Barra_Herramientas.TabIndex = 12;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(3, 3);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Buscar.Size = new System.Drawing.Size(33, 28);
            this.Btn_Buscar.TabIndex = 0;
            this.Btn_Buscar.Values.Image = global::ERP_BASE.Properties.Resources.icono_busqueda_24x20;
            this.Btn_Buscar.Values.Text = "";
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Exportar_PDF
            // 
            this.Btn_Exportar_PDF.Location = new System.Drawing.Point(42, 3);
            this.Btn_Exportar_PDF.Name = "Btn_Exportar_PDF";
            this.Btn_Exportar_PDF.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_PDF.Size = new System.Drawing.Size(33, 28);
            this.Btn_Exportar_PDF.TabIndex = 1;
            this.Btn_Exportar_PDF.Values.Image = global::ERP_BASE.Properties.Resources.icono_imprimir_17x17;
            this.Btn_Exportar_PDF.Values.Text = "";
            this.Btn_Exportar_PDF.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Btn_Exportar_PDF
            // 
            this.Btn_Exportar_PDF_iTextSharp.Location = new System.Drawing.Point(78, 3);
            this.Btn_Exportar_PDF_iTextSharp.Name = "Btn_Exportar_PDF_iTextSharp";
            this.Btn_Exportar_PDF_iTextSharp.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_PDF_iTextSharp.Size = new System.Drawing.Size(33, 28);
            this.Btn_Exportar_PDF_iTextSharp.TabIndex = 1;
            this.Btn_Exportar_PDF_iTextSharp.Values.Image = global::ERP_BASE.Properties.Resources.icono_rep_pdf;
            this.Btn_Exportar_PDF_iTextSharp.Values.Text = "";
            this.Btn_Exportar_PDF_iTextSharp.Click += new System.EventHandler(this.Btn_Exportar_PDF_iTextSharp_Click);

            // 
            // Btn_Exportar_Excel
            // 
            this.Btn_Exportar_Excel.Location = new System.Drawing.Point(81, 3);
            this.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel";
            this.Btn_Exportar_Excel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_Excel.Size = new System.Drawing.Size(33, 28);
            this.Btn_Exportar_Excel.TabIndex = 1;
            this.Btn_Exportar_Excel.Values.Image = global::ERP_BASE.Properties.Resources.icono_rep_excel;
            this.Btn_Exportar_Excel.Values.Text = "";
            this.Btn_Exportar_Excel.Click += new System.EventHandler(this.Btn_Exportar_Excel_Click);
            // 
            // Grp_Resultados
            // 
            this.Grp_Resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Resultados.Controls.Add(this.Grd_Resultado);
            this.Grp_Resultados.Location = new System.Drawing.Point(12, 3);
            this.Grp_Resultados.Name = "Grp_Resultados";
            this.Grp_Resultados.Padding = new System.Windows.Forms.Padding(10);
            this.Grp_Resultados.Size = new System.Drawing.Size(798, 462);
            this.Grp_Resultados.TabIndex = 0;
            this.Grp_Resultados.TabStop = false;
            this.Grp_Resultados.Text = "Resultados";
            // 
            // Grd_Resultado
            // 
            this.Grd_Resultado.AllowUserToAddRows = false;
            this.Grd_Resultado.AllowUserToDeleteRows = false;
            this.Grd_Resultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grd_Resultado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Grd_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Resultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd_Resultado.Location = new System.Drawing.Point(10, 23);
            this.Grd_Resultado.Name = "Grd_Resultado";
            this.Grd_Resultado.ReadOnly = true;
            this.Grd_Resultado.Size = new System.Drawing.Size(778, 429);
            this.Grd_Resultado.TabIndex = 4;
            // 
            // Frm_Rep_Diario_Recaudacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 676);
            this.Controls.Add(this.Spl_Contenedor);
            this.Name = "Frm_Rep_Diario_Recaudacion";
            this.Text = "Reporte diario de recaudación";
            this.Load += new System.EventHandler(this.Frm_Rep_Diario_Recaudacion_Load);
            this.Spl_Contenedor.Panel1.ResumeLayout(false);
            this.Spl_Contenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).EndInit();
            this.Spl_Contenedor.ResumeLayout(false);
            this.Grp_Filtros.ResumeLayout(false);
            this.Grp_Filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tarifa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Reporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_No_Caja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Turno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Pago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Lugar_Venta)).EndInit();
            this.Flp_Barra_Herramientas.ResumeLayout(false);
            this.Grp_Resultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Spl_Contenedor;
        private System.Windows.Forms.FlowLayoutPanel Flp_Barra_Herramientas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Buscar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Exportar_PDF;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Exportar_PDF_iTextSharp;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Exportar_Excel;
        private System.Windows.Forms.GroupBox Grp_Filtros;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Anio_Final;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Anio_Inicial;

        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_No_Caja;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_No_Caja;

        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Turno;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Turno;
        private System.Windows.Forms.GroupBox Grp_Resultados;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView Grd_Resultado;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Dtp_Periodo_Inicial;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Dtp_Periodo_Final;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Tipo_Reporte;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Tipo_Reporte;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Tarifa;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Tarifa;

        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Tipo_Pago;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Tipo_Pago;


        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Lugar_Venta;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Lugar_Venta;
        private System.Windows.Forms.Label Lbl_Anio;
        private System.Windows.Forms.ComboBox Cmb_Anio;
    }
}