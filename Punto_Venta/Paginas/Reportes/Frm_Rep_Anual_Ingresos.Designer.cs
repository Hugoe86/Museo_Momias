namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rep_Anual_Ingresos
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
            this.Cmb_Anio_Final = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Anio_Final = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_Anio_Inicial = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Tipo_Reporte = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_Tipo_Reporte = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Anio_Inicial = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_Numero_Caja = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Numero_Caja = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Lbl_Lugar_Venta = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_Lugar_Venta = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Cmb_Turno = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Turno = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Cmb_Tipo_Pago = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Tipo_Pago = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Flp_Barra_Herramientas = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Buscar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Exportar_PDF = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Grp_Resultados = new System.Windows.Forms.GroupBox();
            this.Grd_Resultado = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).BeginInit();
            this.Spl_Contenedor.Panel1.SuspendLayout();
            this.Spl_Contenedor.Panel2.SuspendLayout();
            this.Spl_Contenedor.SuspendLayout();
            this.Grp_Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Anio_Final)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Anio_Inicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Reporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Numero_Caja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Lugar_Venta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Turno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Pago)).BeginInit();
            this.Flp_Barra_Herramientas.SuspendLayout();
            this.Grp_Resultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // Spl_Contenedor
            // 
            this.Spl_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Spl_Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Spl_Contenedor.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.Spl_Contenedor.Size = new System.Drawing.Size(1644, 1300);
            this.Spl_Contenedor.SplitterDistance = 332;
            this.Spl_Contenedor.SplitterWidth = 8;
            this.Spl_Contenedor.TabIndex = 0;
            this.Spl_Contenedor.TabStop = false;
            // 
            // Grp_Filtros
            // 
            this.Grp_Filtros.Controls.Add(this.Cmb_Anio_Final);
            this.Grp_Filtros.Controls.Add(this.Lbl_Anio_Final);
            this.Grp_Filtros.Controls.Add(this.Cmb_Anio_Inicial);
            this.Grp_Filtros.Controls.Add(this.Lbl_Tipo_Reporte);
            this.Grp_Filtros.Controls.Add(this.Cmb_Tipo_Reporte);
            this.Grp_Filtros.Controls.Add(this.Lbl_Anio_Inicial);
            this.Grp_Filtros.Controls.Add(this.Cmb_Numero_Caja);
            this.Grp_Filtros.Controls.Add(this.Lbl_Numero_Caja);
            this.Grp_Filtros.Controls.Add(this.Lbl_Lugar_Venta);
            this.Grp_Filtros.Controls.Add(this.Cmb_Lugar_Venta);
            this.Grp_Filtros.Controls.Add(this.Cmb_Turno);
            this.Grp_Filtros.Controls.Add(this.Lbl_Turno);
            this.Grp_Filtros.Controls.Add(this.Cmb_Tipo_Pago);
            this.Grp_Filtros.Controls.Add(this.Lbl_Tipo_Pago);
            this.Grp_Filtros.Location = new System.Drawing.Point(26, 88);
            this.Grp_Filtros.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Grp_Filtros.Name = "Grp_Filtros";
            this.Grp_Filtros.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Grp_Filtros.Size = new System.Drawing.Size(1594, 215);
            this.Grp_Filtros.TabIndex = 13;
            this.Grp_Filtros.TabStop = false;
            this.Grp_Filtros.Text = "Filtros para la búsqueda";
            // 
            // Cmb_Anio_Final
            // 
            this.Cmb_Anio_Final.DropDownWidth = 168;
            this.Cmb_Anio_Final.Location = new System.Drawing.Point(882, 35);
            this.Cmb_Anio_Final.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Cmb_Anio_Final.Name = "Cmb_Anio_Final";
            this.Cmb_Anio_Final.Size = new System.Drawing.Size(336, 37);
            this.Cmb_Anio_Final.TabIndex = 3;
            // 
            // Lbl_Anio_Final
            // 
            this.Lbl_Anio_Final.Location = new System.Drawing.Point(752, 35);
            this.Lbl_Anio_Final.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Lbl_Anio_Final.Name = "Lbl_Anio_Final";
            this.Lbl_Anio_Final.Size = new System.Drawing.Size(112, 37);
            this.Lbl_Anio_Final.TabIndex = 2;
            this.Lbl_Anio_Final.Values.Text = "Año final";
            // 
            // Cmb_Anio_Inicial
            // 
            this.Cmb_Anio_Inicial.DropDownWidth = 168;
            this.Cmb_Anio_Inicial.Location = new System.Drawing.Point(200, 35);
            this.Cmb_Anio_Inicial.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Cmb_Anio_Inicial.Name = "Cmb_Anio_Inicial";
            this.Cmb_Anio_Inicial.Size = new System.Drawing.Size(336, 37);
            this.Cmb_Anio_Inicial.TabIndex = 2;
            // 
            // Lbl_Tipo_Reporte
            // 
            this.Lbl_Tipo_Reporte.Location = new System.Drawing.Point(1220, 35);
            this.Lbl_Tipo_Reporte.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Lbl_Tipo_Reporte.Name = "Lbl_Tipo_Reporte";
            this.Lbl_Tipo_Reporte.Size = new System.Drawing.Size(156, 37);
            this.Lbl_Tipo_Reporte.TabIndex = 2;
            this.Lbl_Tipo_Reporte.Values.Text = "Tipo Reporte";
            // 
            // Cmb_Tipo_Reporte
            // 
            this.Cmb_Tipo_Reporte.DropDownWidth = 168;
            this.Cmb_Tipo_Reporte.Items.AddRange(new object[] {
            "",
            "Recaudación por Tarifa",
            "Recuadación, Acumulado por Tarifa",
            "Visitantes, Acumulado por Tarifa",
            "Concentrado"});
            this.Cmb_Tipo_Reporte.Location = new System.Drawing.Point(1220, 92);
            this.Cmb_Tipo_Reporte.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Cmb_Tipo_Reporte.Name = "Cmb_Tipo_Reporte";
            this.Cmb_Tipo_Reporte.Size = new System.Drawing.Size(336, 37);
            this.Cmb_Tipo_Reporte.TabIndex = 2;
            // 
            // Lbl_Anio_Inicial
            // 
            this.Lbl_Anio_Inicial.Location = new System.Drawing.Point(12, 35);
            this.Lbl_Anio_Inicial.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Lbl_Anio_Inicial.Name = "Lbl_Anio_Inicial";
            this.Lbl_Anio_Inicial.Size = new System.Drawing.Size(128, 37);
            this.Lbl_Anio_Inicial.TabIndex = 0;
            this.Lbl_Anio_Inicial.Values.Text = "Año inicial";
            // 
            // Cmb_Numero_Caja
            // 
            this.Cmb_Numero_Caja.DropDownWidth = 168;
            this.Cmb_Numero_Caja.Location = new System.Drawing.Point(200, 92);
            this.Cmb_Numero_Caja.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Cmb_Numero_Caja.Name = "Cmb_Numero_Caja";
            this.Cmb_Numero_Caja.Size = new System.Drawing.Size(336, 37);
            this.Cmb_Numero_Caja.TabIndex = 6;
            // 
            // Lbl_Numero_Caja
            // 
            this.Lbl_Numero_Caja.Location = new System.Drawing.Point(12, 92);
            this.Lbl_Numero_Caja.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Lbl_Numero_Caja.Name = "Lbl_Numero_Caja";
            this.Lbl_Numero_Caja.Size = new System.Drawing.Size(192, 37);
            this.Lbl_Numero_Caja.TabIndex = 7;
            this.Lbl_Numero_Caja.Values.Text = "Número de Caja";
            // 
            // Lbl_Lugar_Venta
            // 
            this.Lbl_Lugar_Venta.Location = new System.Drawing.Point(12, 150);
            this.Lbl_Lugar_Venta.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Lbl_Lugar_Venta.Name = "Lbl_Lugar_Venta";
            this.Lbl_Lugar_Venta.Size = new System.Drawing.Size(177, 37);
            this.Lbl_Lugar_Venta.TabIndex = 18;
            this.Lbl_Lugar_Venta.Values.Text = "Lugar de venta";
            // 
            // Cmb_Lugar_Venta
            // 
            this.Cmb_Lugar_Venta.DropDownWidth = 168;
            this.Cmb_Lugar_Venta.Items.AddRange(new object[] {
            "",
            "No caja",
            "Internet",
            "Kiosko"});
            this.Cmb_Lugar_Venta.Location = new System.Drawing.Point(200, 150);
            this.Cmb_Lugar_Venta.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Cmb_Lugar_Venta.Name = "Cmb_Lugar_Venta";
            this.Cmb_Lugar_Venta.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Cmb_Lugar_Venta.Size = new System.Drawing.Size(336, 37);
            this.Cmb_Lugar_Venta.TabIndex = 19;
            // 
            // Cmb_Turno
            // 
            this.Cmb_Turno.DropDownWidth = 168;
            this.Cmb_Turno.Location = new System.Drawing.Point(882, 92);
            this.Cmb_Turno.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Cmb_Turno.Name = "Cmb_Turno";
            this.Cmb_Turno.Size = new System.Drawing.Size(336, 37);
            this.Cmb_Turno.TabIndex = 3;
            // 
            // Lbl_Turno
            // 
            this.Lbl_Turno.Location = new System.Drawing.Point(752, 92);
            this.Lbl_Turno.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Lbl_Turno.Name = "Lbl_Turno";
            this.Lbl_Turno.Size = new System.Drawing.Size(79, 37);
            this.Lbl_Turno.TabIndex = 2;
            this.Lbl_Turno.Values.Text = "Turno";
            // 
            // Cmb_Tipo_Pago
            // 
            this.Cmb_Tipo_Pago.DropDownWidth = 168;
            this.Cmb_Tipo_Pago.Items.AddRange(new object[] {
            "",
            "Efectivo",
            "Credito-Debito"});
            this.Cmb_Tipo_Pago.Location = new System.Drawing.Point(920, 150);
            this.Cmb_Tipo_Pago.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Cmb_Tipo_Pago.Name = "Cmb_Tipo_Pago";
            this.Cmb_Tipo_Pago.Size = new System.Drawing.Size(300, 37);
            this.Cmb_Tipo_Pago.TabIndex = 3;
            // 
            // Lbl_Tipo_Pago
            // 
            this.Lbl_Tipo_Pago.Location = new System.Drawing.Point(752, 150);
            this.Lbl_Tipo_Pago.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Lbl_Tipo_Pago.Name = "Lbl_Tipo_Pago";
            this.Lbl_Tipo_Pago.Size = new System.Drawing.Size(159, 37);
            this.Lbl_Tipo_Pago.TabIndex = 2;
            this.Lbl_Tipo_Pago.Values.Text = "Tipo de Pago";
            // 
            // Flp_Barra_Herramientas
            // 
            this.Flp_Barra_Herramientas.BackColor = System.Drawing.Color.AliceBlue;
            this.Flp_Barra_Herramientas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Buscar);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_PDF);
            this.Flp_Barra_Herramientas.Location = new System.Drawing.Point(24, 6);
            this.Flp_Barra_Herramientas.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Flp_Barra_Herramientas.Name = "Flp_Barra_Herramientas";
            this.Flp_Barra_Herramientas.Size = new System.Drawing.Size(1594, 67);
            this.Flp_Barra_Herramientas.TabIndex = 12;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(6, 6);
            this.Btn_Buscar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Buscar.Size = new System.Drawing.Size(66, 54);
            this.Btn_Buscar.TabIndex = 0;
            this.Btn_Buscar.Values.Image = global::ERP_BASE.Properties.Resources.icono_busqueda_24x20;
            this.Btn_Buscar.Values.Text = "";
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Exportar_PDF
            // 
            this.Btn_Exportar_PDF.Enabled = false;
            this.Btn_Exportar_PDF.Location = new System.Drawing.Point(84, 6);
            this.Btn_Exportar_PDF.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Btn_Exportar_PDF.Name = "Btn_Exportar_PDF";
            this.Btn_Exportar_PDF.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_PDF.Size = new System.Drawing.Size(66, 54);
            this.Btn_Exportar_PDF.TabIndex = 1;
            this.Btn_Exportar_PDF.Values.Image = global::ERP_BASE.Properties.Resources.icono_imprimir_17x17;
            this.Btn_Exportar_PDF.Values.Text = "";
            this.Btn_Exportar_PDF.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Grp_Resultados
            // 
            this.Grp_Resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Resultados.Controls.Add(this.Grd_Resultado);
            this.Grp_Resultados.Location = new System.Drawing.Point(24, 6);
            this.Grp_Resultados.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Grp_Resultados.Name = "Grp_Resultados";
            this.Grp_Resultados.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.Grp_Resultados.Size = new System.Drawing.Size(1596, 931);
            this.Grp_Resultados.TabIndex = 0;
            this.Grp_Resultados.TabStop = false;
            this.Grp_Resultados.Text = "Resultados";
            // 
            // Grd_Resultado
            // 
            this.Grd_Resultado.AllowUserToAddRows = false;
            this.Grd_Resultado.AllowUserToDeleteRows = false;
            this.Grd_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Resultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grd_Resultado.Location = new System.Drawing.Point(20, 43);
            this.Grd_Resultado.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Grd_Resultado.Name = "Grd_Resultado";
            this.Grd_Resultado.ReadOnly = true;
            this.Grd_Resultado.Size = new System.Drawing.Size(1556, 869);
            this.Grd_Resultado.TabIndex = 4;
            // 
            // Frm_Rep_Anual_Ingresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1644, 1300);
            this.Controls.Add(this.Spl_Contenedor);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Frm_Rep_Anual_Ingresos";
            this.Text = "Reporte anual de ingresos";
            this.Load += new System.EventHandler(this.Frm_Rep_Anual_Ingresos_Load);
            this.Spl_Contenedor.Panel1.ResumeLayout(false);
            this.Spl_Contenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).EndInit();
            this.Spl_Contenedor.ResumeLayout(false);
            this.Grp_Filtros.ResumeLayout(false);
            this.Grp_Filtros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Anio_Final)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Anio_Inicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Reporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Numero_Caja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Lugar_Venta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Turno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tipo_Pago)).EndInit();
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
        private System.Windows.Forms.GroupBox Grp_Filtros;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Anio_Final;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Anio_Final;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Tipo_Reporte;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Anio_Inicial;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Tipo_Reporte;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Anio_Inicial;
        private System.Windows.Forms.GroupBox Grp_Resultados;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView Grd_Resultado;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Numero_Caja;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Numero_Caja;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Turno;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Turno;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Tipo_Pago;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Tipo_Pago;


        private ComponentFactory.Krypton.Toolkit.KryptonLabel Lbl_Lugar_Venta;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Lugar_Venta;
    }
}