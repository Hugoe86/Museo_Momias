namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rep_Mensual_Ingresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Rep_Mensual_Ingresos));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_Pdf = new System.Windows.Forms.Button();
            this.Btn_Pdf_Itesharp = new System.Windows.Forms.Button();
            this.Btn_Exel = new System.Windows.Forms.Button();
            this.Pnl_Filtros = new System.Windows.Forms.FlowLayoutPanel();
            this.Grp_Filtros = new System.Windows.Forms.GroupBox();
            this.Chart_Grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Rbt_Opc_Concentrado = new System.Windows.Forms.RadioButton();
            this.Cmb_Tipo_Pago = new System.Windows.Forms.ComboBox();
            this.Lbl_Etiqueta_Tipo_Pago = new System.Windows.Forms.Label();
            this.Cmb_Lugar_Venta = new System.Windows.Forms.ComboBox();
            this.Lbl_Etiqueta_Lugar_Venta = new System.Windows.Forms.Label();
            this.Cmb_Numero_Caja = new System.Windows.Forms.ComboBox();
            this.Lbl_Etiqueta_Caja = new System.Windows.Forms.Label();
            this.Cmb_Turno = new System.Windows.Forms.ComboBox();
            this.Lbl_Etiqueta_Turno = new System.Windows.Forms.Label();
            this.Pnl_Periodo = new System.Windows.Forms.Panel();
            this.Chk_ListB_Periodo_Tarifa = new System.Windows.Forms.CheckedListBox();
            this.Lbl_Etiqueta_Periodo = new System.Windows.Forms.Label();
            this.Lbl_Etiqueta_Tarifa = new System.Windows.Forms.Label();
            this.Chk_ListB_Periodo_Anio = new System.Windows.Forms.CheckedListBox();
            this.Lbl_Etiqueta_Mes = new System.Windows.Forms.Label();
            this.Chk_ListB_Periodo_Meses = new System.Windows.Forms.CheckedListBox();
            this.Lbl_Etiqueta_Anio = new System.Windows.Forms.Label();
            this.Rbt_Opc_Visitantes = new System.Windows.Forms.RadioButton();
            this.Lbl_Tipo_Reporte = new System.Windows.Forms.Label();
            this.Rbt_Opc_Reporte_Ingresos = new System.Windows.Forms.RadioButton();
            this.Grp_Resultado = new System.Windows.Forms.GroupBox();
            this.Grid_Resultado = new System.Windows.Forms.DataGridView();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.Chart_Grafico_Porcentaje = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1.SuspendLayout();
            this.Pnl_Filtros.SuspendLayout();
            this.Grp_Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Grafico)).BeginInit();
            this.Pnl_Periodo.SuspendLayout();
            this.Grp_Resultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Grafico_Porcentaje)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Btn_Consultar);
            this.flowLayoutPanel1.Controls.Add(this.Btn_Pdf);
            this.flowLayoutPanel1.Controls.Add(this.Btn_Pdf_Itesharp);
            this.flowLayoutPanel1.Controls.Add(this.Btn_Exel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(820, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Consultar.Image")));
            this.Btn_Consultar.Location = new System.Drawing.Point(3, 3);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(35, 32);
            this.Btn_Consultar.TabIndex = 0;
            this.Btn_Consultar.UseVisualStyleBackColor = true;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Pdf
            // 
            this.Btn_Pdf.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Pdf.Image")));
            this.Btn_Pdf.Location = new System.Drawing.Point(44, 3);
            this.Btn_Pdf.Name = "Btn_Pdf";
            this.Btn_Pdf.Size = new System.Drawing.Size(35, 32);
            this.Btn_Pdf.TabIndex = 1;
            this.Btn_Pdf.UseVisualStyleBackColor = true;
            this.Btn_Pdf.Visible = false;
            this.Btn_Pdf.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Btn_Pdf_Itesharp
            // 
            this.Btn_Pdf_Itesharp.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Pdf_Itesharp.Image")));
            this.Btn_Pdf_Itesharp.Location = new System.Drawing.Point(85, 3);
            this.Btn_Pdf_Itesharp.Name = "Btn_Pdf_Itesharp";
            this.Btn_Pdf_Itesharp.Size = new System.Drawing.Size(35, 32);
            this.Btn_Pdf_Itesharp.TabIndex = 2;
            this.Btn_Pdf_Itesharp.UseVisualStyleBackColor = true;
            this.Btn_Pdf_Itesharp.Click += new System.EventHandler(this.Btn_Pdf_Itesharp_Click);
            // 
            // Btn_Exel
            // 
            this.Btn_Exel.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Exel.Image")));
            this.Btn_Exel.Location = new System.Drawing.Point(126, 3);
            this.Btn_Exel.Name = "Btn_Exel";
            this.Btn_Exel.Size = new System.Drawing.Size(35, 32);
            this.Btn_Exel.TabIndex = 3;
            this.Btn_Exel.UseVisualStyleBackColor = true;
            this.Btn_Exel.Click += new System.EventHandler(this.Btn_Exel_Click);
            // 
            // Pnl_Filtros
            // 
            this.Pnl_Filtros.Controls.Add(this.Grp_Filtros);
            this.Pnl_Filtros.Location = new System.Drawing.Point(4, 47);
            this.Pnl_Filtros.Name = "Pnl_Filtros";
            this.Pnl_Filtros.Size = new System.Drawing.Size(817, 238);
            this.Pnl_Filtros.TabIndex = 1;
            // 
            // Grp_Filtros
            // 
            this.Grp_Filtros.BackColor = System.Drawing.SystemColors.Control;
            this.Grp_Filtros.Controls.Add(this.Rbt_Opc_Concentrado);
            this.Grp_Filtros.Controls.Add(this.Cmb_Tipo_Pago);
            this.Grp_Filtros.Controls.Add(this.Lbl_Etiqueta_Tipo_Pago);
            this.Grp_Filtros.Controls.Add(this.Cmb_Lugar_Venta);
            this.Grp_Filtros.Controls.Add(this.Lbl_Etiqueta_Lugar_Venta);
            this.Grp_Filtros.Controls.Add(this.Cmb_Numero_Caja);
            this.Grp_Filtros.Controls.Add(this.Lbl_Etiqueta_Caja);
            this.Grp_Filtros.Controls.Add(this.Cmb_Turno);
            this.Grp_Filtros.Controls.Add(this.Lbl_Etiqueta_Turno);
            this.Grp_Filtros.Controls.Add(this.Pnl_Periodo);
            this.Grp_Filtros.Controls.Add(this.Rbt_Opc_Visitantes);
            this.Grp_Filtros.Controls.Add(this.Lbl_Tipo_Reporte);
            this.Grp_Filtros.Controls.Add(this.Rbt_Opc_Reporte_Ingresos);
            this.Grp_Filtros.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Filtros.Location = new System.Drawing.Point(3, 3);
            this.Grp_Filtros.Name = "Grp_Filtros";
            this.Grp_Filtros.Size = new System.Drawing.Size(814, 235);
            this.Grp_Filtros.TabIndex = 0;
            this.Grp_Filtros.TabStop = false;
            this.Grp_Filtros.Text = "Filtros para la búsqueda";
            // 
            // Chart_Grafico
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart_Grafico.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart_Grafico.Legends.Add(legend1);
            this.Chart_Grafico.Location = new System.Drawing.Point(625, 261);
            this.Chart_Grafico.Name = "Chart_Grafico";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Chart_Grafico.Series.Add(series1);
            this.Chart_Grafico.Size = new System.Drawing.Size(84, 63);
            this.Chart_Grafico.TabIndex = 1;
            this.Chart_Grafico.Visible = false;
            // 
            // Rbt_Opc_Concentrado
            // 
            this.Rbt_Opc_Concentrado.AutoSize = true;
            this.Rbt_Opc_Concentrado.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbt_Opc_Concentrado.Location = new System.Drawing.Point(66, 85);
            this.Rbt_Opc_Concentrado.Name = "Rbt_Opc_Concentrado";
            this.Rbt_Opc_Concentrado.Size = new System.Drawing.Size(87, 18);
            this.Rbt_Opc_Concentrado.TabIndex = 20;
            this.Rbt_Opc_Concentrado.Text = "Concentrado";
            this.Rbt_Opc_Concentrado.UseVisualStyleBackColor = true;
            // 
            // Cmb_Tipo_Pago
            // 
            this.Cmb_Tipo_Pago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Tipo_Pago.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo_Pago.FormattingEnabled = true;
            this.Cmb_Tipo_Pago.Items.AddRange(new object[] {
            "Efectivo",
            "Credito-Debito"});
            this.Cmb_Tipo_Pago.Location = new System.Drawing.Point(641, 180);
            this.Cmb_Tipo_Pago.Name = "Cmb_Tipo_Pago";
            this.Cmb_Tipo_Pago.Size = new System.Drawing.Size(103, 23);
            this.Cmb_Tipo_Pago.TabIndex = 19;
            // 
            // Lbl_Etiqueta_Tipo_Pago
            // 
            this.Lbl_Etiqueta_Tipo_Pago.AutoSize = true;
            this.Lbl_Etiqueta_Tipo_Pago.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Tipo_Pago.Location = new System.Drawing.Point(571, 185);
            this.Lbl_Etiqueta_Tipo_Pago.Name = "Lbl_Etiqueta_Tipo_Pago";
            this.Lbl_Etiqueta_Tipo_Pago.Size = new System.Drawing.Size(64, 14);
            this.Lbl_Etiqueta_Tipo_Pago.TabIndex = 18;
            this.Lbl_Etiqueta_Tipo_Pago.Text = "Tipo_Pago";
            // 
            // Cmb_Lugar_Venta
            // 
            this.Cmb_Lugar_Venta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Lugar_Venta.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Lugar_Venta.FormattingEnabled = true;
            this.Cmb_Lugar_Venta.Items.AddRange(new object[] {
            "No Caja",
            "Internet",
            "Kiosko"});
            this.Cmb_Lugar_Venta.Location = new System.Drawing.Point(448, 181);
            this.Cmb_Lugar_Venta.Name = "Cmb_Lugar_Venta";
            this.Cmb_Lugar_Venta.Size = new System.Drawing.Size(103, 23);
            this.Cmb_Lugar_Venta.TabIndex = 17;
            // 
            // Lbl_Etiqueta_Lugar_Venta
            // 
            this.Lbl_Etiqueta_Lugar_Venta.AutoSize = true;
            this.Lbl_Etiqueta_Lugar_Venta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Lugar_Venta.Location = new System.Drawing.Point(366, 185);
            this.Lbl_Etiqueta_Lugar_Venta.Name = "Lbl_Etiqueta_Lugar_Venta";
            this.Lbl_Etiqueta_Lugar_Venta.Size = new System.Drawing.Size(76, 14);
            this.Lbl_Etiqueta_Lugar_Venta.TabIndex = 16;
            this.Lbl_Etiqueta_Lugar_Venta.Text = "Lugar_Venta";
            // 
            // Cmb_Numero_Caja
            // 
            this.Cmb_Numero_Caja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Numero_Caja.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Numero_Caja.FormattingEnabled = true;
            this.Cmb_Numero_Caja.Location = new System.Drawing.Point(237, 180);
            this.Cmb_Numero_Caja.Name = "Cmb_Numero_Caja";
            this.Cmb_Numero_Caja.Size = new System.Drawing.Size(103, 23);
            this.Cmb_Numero_Caja.TabIndex = 15;
            // 
            // Lbl_Etiqueta_Caja
            // 
            this.Lbl_Etiqueta_Caja.AutoSize = true;
            this.Lbl_Etiqueta_Caja.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Caja.Location = new System.Drawing.Point(181, 184);
            this.Lbl_Etiqueta_Caja.Name = "Lbl_Etiqueta_Caja";
            this.Lbl_Etiqueta_Caja.Size = new System.Drawing.Size(50, 14);
            this.Lbl_Etiqueta_Caja.TabIndex = 14;
            this.Lbl_Etiqueta_Caja.Text = "No. Caja";
            // 
            // Cmb_Turno
            // 
            this.Cmb_Turno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Turno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Turno.FormattingEnabled = true;
            this.Cmb_Turno.Location = new System.Drawing.Point(51, 181);
            this.Cmb_Turno.Name = "Cmb_Turno";
            this.Cmb_Turno.Size = new System.Drawing.Size(103, 23);
            this.Cmb_Turno.TabIndex = 13;
            // 
            // Lbl_Etiqueta_Turno
            // 
            this.Lbl_Etiqueta_Turno.AutoSize = true;
            this.Lbl_Etiqueta_Turno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Turno.Location = new System.Drawing.Point(6, 184);
            this.Lbl_Etiqueta_Turno.Name = "Lbl_Etiqueta_Turno";
            this.Lbl_Etiqueta_Turno.Size = new System.Drawing.Size(39, 14);
            this.Lbl_Etiqueta_Turno.TabIndex = 12;
            this.Lbl_Etiqueta_Turno.Text = "Turno";
            // 
            // Pnl_Periodo
            // 
            this.Pnl_Periodo.Controls.Add(this.Chk_ListB_Periodo_Tarifa);
            this.Pnl_Periodo.Controls.Add(this.Lbl_Etiqueta_Periodo);
            this.Pnl_Periodo.Controls.Add(this.Lbl_Etiqueta_Tarifa);
            this.Pnl_Periodo.Controls.Add(this.Chk_ListB_Periodo_Anio);
            this.Pnl_Periodo.Controls.Add(this.Lbl_Etiqueta_Mes);
            this.Pnl_Periodo.Controls.Add(this.Chk_ListB_Periodo_Meses);
            this.Pnl_Periodo.Controls.Add(this.Lbl_Etiqueta_Anio);
            this.Pnl_Periodo.Location = new System.Drawing.Point(145, 23);
            this.Pnl_Periodo.Name = "Pnl_Periodo";
            this.Pnl_Periodo.Size = new System.Drawing.Size(643, 138);
            this.Pnl_Periodo.TabIndex = 11;
            // 
            // Chk_ListB_Periodo_Tarifa
            // 
            this.Chk_ListB_Periodo_Tarifa.CheckOnClick = true;
            this.Chk_ListB_Periodo_Tarifa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_ListB_Periodo_Tarifa.FormattingEnabled = true;
            this.Chk_ListB_Periodo_Tarifa.Location = new System.Drawing.Point(365, 27);
            this.Chk_ListB_Periodo_Tarifa.Name = "Chk_ListB_Periodo_Tarifa";
            this.Chk_ListB_Periodo_Tarifa.Size = new System.Drawing.Size(273, 100);
            this.Chk_ListB_Periodo_Tarifa.TabIndex = 10;
            // 
            // Lbl_Etiqueta_Periodo
            // 
            this.Lbl_Etiqueta_Periodo.AutoSize = true;
            this.Lbl_Etiqueta_Periodo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Periodo.Location = new System.Drawing.Point(3, 27);
            this.Lbl_Etiqueta_Periodo.Name = "Lbl_Etiqueta_Periodo";
            this.Lbl_Etiqueta_Periodo.Size = new System.Drawing.Size(54, 14);
            this.Lbl_Etiqueta_Periodo.TabIndex = 3;
            this.Lbl_Etiqueta_Periodo.Text = "*Periodo";
            // 
            // Lbl_Etiqueta_Tarifa
            // 
            this.Lbl_Etiqueta_Tarifa.AutoSize = true;
            this.Lbl_Etiqueta_Tarifa.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Tarifa.Location = new System.Drawing.Point(403, 10);
            this.Lbl_Etiqueta_Tarifa.Name = "Lbl_Etiqueta_Tarifa";
            this.Lbl_Etiqueta_Tarifa.Size = new System.Drawing.Size(34, 14);
            this.Lbl_Etiqueta_Tarifa.TabIndex = 9;
            this.Lbl_Etiqueta_Tarifa.Text = "Tarifa";
            // 
            // Chk_ListB_Periodo_Anio
            // 
            this.Chk_ListB_Periodo_Anio.AccessibleDescription = "";
            this.Chk_ListB_Periodo_Anio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Chk_ListB_Periodo_Anio.CheckOnClick = true;
            this.Chk_ListB_Periodo_Anio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_ListB_Periodo_Anio.FormattingEnabled = true;
            this.Chk_ListB_Periodo_Anio.Location = new System.Drawing.Point(63, 27);
            this.Chk_ListB_Periodo_Anio.Name = "Chk_ListB_Periodo_Anio";
            this.Chk_ListB_Periodo_Anio.Size = new System.Drawing.Size(120, 96);
            this.Chk_ListB_Periodo_Anio.TabIndex = 5;
            // 
            // Lbl_Etiqueta_Mes
            // 
            this.Lbl_Etiqueta_Mes.AutoSize = true;
            this.Lbl_Etiqueta_Mes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Mes.Location = new System.Drawing.Point(231, 10);
            this.Lbl_Etiqueta_Mes.Name = "Lbl_Etiqueta_Mes";
            this.Lbl_Etiqueta_Mes.Size = new System.Drawing.Size(27, 14);
            this.Lbl_Etiqueta_Mes.TabIndex = 8;
            this.Lbl_Etiqueta_Mes.Text = "Mes";
            // 
            // Chk_ListB_Periodo_Meses
            // 
            this.Chk_ListB_Periodo_Meses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Chk_ListB_Periodo_Meses.CheckOnClick = true;
            this.Chk_ListB_Periodo_Meses.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_ListB_Periodo_Meses.FormattingEnabled = true;
            this.Chk_ListB_Periodo_Meses.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.Chk_ListB_Periodo_Meses.Location = new System.Drawing.Point(198, 27);
            this.Chk_ListB_Periodo_Meses.Name = "Chk_ListB_Periodo_Meses";
            this.Chk_ListB_Periodo_Meses.Size = new System.Drawing.Size(151, 96);
            this.Chk_ListB_Periodo_Meses.TabIndex = 6;
            // 
            // Lbl_Etiqueta_Anio
            // 
            this.Lbl_Etiqueta_Anio.AutoSize = true;
            this.Lbl_Etiqueta_Anio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Etiqueta_Anio.Location = new System.Drawing.Point(106, 10);
            this.Lbl_Etiqueta_Anio.Name = "Lbl_Etiqueta_Anio";
            this.Lbl_Etiqueta_Anio.Size = new System.Drawing.Size(27, 14);
            this.Lbl_Etiqueta_Anio.TabIndex = 7;
            this.Lbl_Etiqueta_Anio.Text = "Año";
            // 
            // Rbt_Opc_Visitantes
            // 
            this.Rbt_Opc_Visitantes.AutoSize = true;
            this.Rbt_Opc_Visitantes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbt_Opc_Visitantes.Location = new System.Drawing.Point(66, 61);
            this.Rbt_Opc_Visitantes.Name = "Rbt_Opc_Visitantes";
            this.Rbt_Opc_Visitantes.Size = new System.Drawing.Size(73, 18);
            this.Rbt_Opc_Visitantes.TabIndex = 2;
            this.Rbt_Opc_Visitantes.Text = "Visitantes";
            this.Rbt_Opc_Visitantes.UseVisualStyleBackColor = true;
            // 
            // Lbl_Tipo_Reporte
            // 
            this.Lbl_Tipo_Reporte.AutoSize = true;
            this.Lbl_Tipo_Reporte.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Tipo_Reporte.Location = new System.Drawing.Point(5, 63);
            this.Lbl_Tipo_Reporte.Name = "Lbl_Tipo_Reporte";
            this.Lbl_Tipo_Reporte.Size = new System.Drawing.Size(55, 14);
            this.Lbl_Tipo_Reporte.TabIndex = 1;
            this.Lbl_Tipo_Reporte.Text = "*Reporte";
            // 
            // Rbt_Opc_Reporte_Ingresos
            // 
            this.Rbt_Opc_Reporte_Ingresos.AutoSize = true;
            this.Rbt_Opc_Reporte_Ingresos.Checked = true;
            this.Rbt_Opc_Reporte_Ingresos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rbt_Opc_Reporte_Ingresos.Location = new System.Drawing.Point(66, 38);
            this.Rbt_Opc_Reporte_Ingresos.Name = "Rbt_Opc_Reporte_Ingresos";
            this.Rbt_Opc_Reporte_Ingresos.Size = new System.Drawing.Size(67, 18);
            this.Rbt_Opc_Reporte_Ingresos.TabIndex = 0;
            this.Rbt_Opc_Reporte_Ingresos.TabStop = true;
            this.Rbt_Opc_Reporte_Ingresos.Text = "Ingresos";
            this.Rbt_Opc_Reporte_Ingresos.UseVisualStyleBackColor = true;
            // 
            // Grp_Resultado
            // 
            this.Grp_Resultado.Controls.Add(this.Chart_Grafico);
            this.Grp_Resultado.Controls.Add(this.Chart_Grafico_Porcentaje);
            this.Grp_Resultado.Controls.Add(this.Grid_Resultado);
            this.Grp_Resultado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grp_Resultado.Location = new System.Drawing.Point(7, 294);
            this.Grp_Resultado.Name = "Grp_Resultado";
            this.Grp_Resultado.Size = new System.Drawing.Size(814, 370);
            this.Grp_Resultado.TabIndex = 2;
            this.Grp_Resultado.TabStop = false;
            this.Grp_Resultado.Text = "Resultado";
            // 
            // Grid_Resultado
            // 
            this.Grid_Resultado.AllowUserToAddRows = false;
            this.Grid_Resultado.AllowUserToDeleteRows = false;
            this.Grid_Resultado.AllowUserToResizeRows = false;
            this.Grid_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Resultado.Location = new System.Drawing.Point(9, 21);
            this.Grid_Resultado.Name = "Grid_Resultado";
            this.Grid_Resultado.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Resultado.Size = new System.Drawing.Size(799, 342);
            this.Grid_Resultado.TabIndex = 0;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(831, 676);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 2;
            this.lineShape1.X2 = 814;
            this.lineShape1.Y1 = 294;
            this.lineShape1.Y2 = 302;
            // 
            // Chart_Grafico_Porcentaje
            // 
            chartArea2.Name = "ChartArea1";
            this.Chart_Grafico_Porcentaje.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Chart_Grafico_Porcentaje.Legends.Add(legend2);
            this.Chart_Grafico_Porcentaje.Location = new System.Drawing.Point(715, 261);
            this.Chart_Grafico_Porcentaje.Name = "Chart_Grafico_Porcentaje";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Label = "#PERCENT{P2}";
            series2.Legend = "Legend1";
            series2.LegendText = "#VALX";
            series2.Name = "Series1";
            this.Chart_Grafico_Porcentaje.Series.Add(series2);
            this.Chart_Grafico_Porcentaje.Size = new System.Drawing.Size(91, 63);
            this.Chart_Grafico_Porcentaje.TabIndex = 4;
            this.Chart_Grafico_Porcentaje.Visible = false;
            // 
            // Frm_Rep_Mensual_Ingresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 676);
            this.Controls.Add(this.Grp_Resultado);
            this.Controls.Add(this.Pnl_Filtros);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Frm_Rep_Mensual_Ingresos";
            this.Text = "Reportes mensuales";
            this.Load += new System.EventHandler(this.Frm_Rep_Mensual_Ingresos_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Pnl_Filtros.ResumeLayout(false);
            this.Grp_Filtros.ResumeLayout(false);
            this.Grp_Filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Grafico)).EndInit();
            this.Pnl_Periodo.ResumeLayout(false);
            this.Pnl_Periodo.PerformLayout();
            this.Grp_Resultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Grafico_Porcentaje)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_Pdf;
        private System.Windows.Forms.Button Btn_Pdf_Itesharp;
        private System.Windows.Forms.Button Btn_Exel;
        private System.Windows.Forms.FlowLayoutPanel Pnl_Filtros;
        private System.Windows.Forms.GroupBox Grp_Filtros;
        private System.Windows.Forms.RadioButton Rbt_Opc_Visitantes;
        private System.Windows.Forms.Label Lbl_Tipo_Reporte;
        private System.Windows.Forms.RadioButton Rbt_Opc_Reporte_Ingresos;
        private System.Windows.Forms.Label Lbl_Etiqueta_Periodo;
        private System.Windows.Forms.CheckedListBox Chk_ListB_Periodo_Anio;
        private System.Windows.Forms.CheckedListBox Chk_ListB_Periodo_Meses;
        private System.Windows.Forms.CheckedListBox Chk_ListB_Periodo_Tarifa;
        private System.Windows.Forms.Label Lbl_Etiqueta_Tarifa;
        private System.Windows.Forms.Label Lbl_Etiqueta_Mes;
        private System.Windows.Forms.Label Lbl_Etiqueta_Anio;
        private System.Windows.Forms.Panel Pnl_Periodo;
        private System.Windows.Forms.Label Lbl_Etiqueta_Turno;
        private System.Windows.Forms.ComboBox Cmb_Turno;
        private System.Windows.Forms.ComboBox Cmb_Numero_Caja;
        private System.Windows.Forms.Label Lbl_Etiqueta_Caja;
        private System.Windows.Forms.ComboBox Cmb_Lugar_Venta;
        private System.Windows.Forms.Label Lbl_Etiqueta_Lugar_Venta;
        private System.Windows.Forms.ComboBox Cmb_Tipo_Pago;
        private System.Windows.Forms.Label Lbl_Etiqueta_Tipo_Pago;
        private System.Windows.Forms.GroupBox Grp_Resultado;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.RadioButton Rbt_Opc_Concentrado;
        private System.Windows.Forms.DataGridView Grid_Resultado;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Grafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Grafico_Porcentaje;



    }
}