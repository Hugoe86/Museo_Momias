namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rep_Log
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
            this.KGBox_Contenedor_Filtros = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.Lbl_Fecha_Inicio_Busqueda = new System.Windows.Forms.Label();
            this.Cmb_Tabla = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Lbl_Operacion = new System.Windows.Forms.Label();
            this.Cmb_Operacion = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Dtp_Fecha_Termino = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Lbl_Fecha_Termino = new System.Windows.Forms.Label();
            this.Lbl_Tabla = new System.Windows.Forms.Label();
            this.Cmb_Usuario = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.Dtp_Fecha_Inicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.Flp_Barra_Herramientas = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Buscar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Exportar_PDF = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Grp_Resultado = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.Grd_Resultado = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.Btn_Exportar_Excel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).BeginInit();
            this.Spl_Contenedor.Panel1.SuspendLayout();
            this.Spl_Contenedor.Panel2.SuspendLayout();
            this.Spl_Contenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Filtros)).BeginInit();
            this.KGBox_Contenedor_Filtros.Panel.SuspendLayout();
            this.KGBox_Contenedor_Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Operacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Usuario)).BeginInit();
            this.Flp_Barra_Herramientas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grp_Resultado)).BeginInit();
            this.Grp_Resultado.Panel.SuspendLayout();
            this.Grp_Resultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // Spl_Contenedor
            // 
            this.Spl_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Spl_Contenedor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Spl_Contenedor.IsSplitterFixed = true;
            this.Spl_Contenedor.Location = new System.Drawing.Point(0, 0);
            this.Spl_Contenedor.Name = "Spl_Contenedor";
            this.Spl_Contenedor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Spl_Contenedor.Panel1
            // 
            this.Spl_Contenedor.Panel1.Controls.Add(this.KGBox_Contenedor_Filtros);
            this.Spl_Contenedor.Panel1.Controls.Add(this.Flp_Barra_Herramientas);
            this.Spl_Contenedor.Panel1.Tag = "";
            this.Spl_Contenedor.Panel1MinSize = 30;
            // 
            // Spl_Contenedor.Panel2
            // 
            this.Spl_Contenedor.Panel2.Controls.Add(this.Grp_Resultado);
            this.Spl_Contenedor.Size = new System.Drawing.Size(791, 531);
            this.Spl_Contenedor.SplitterDistance = 210;
            this.Spl_Contenedor.SplitterWidth = 1;
            this.Spl_Contenedor.TabIndex = 0;
            // 
            // KGBox_Contenedor_Filtros
            // 
            this.KGBox_Contenedor_Filtros.Location = new System.Drawing.Point(12, 54);
            this.KGBox_Contenedor_Filtros.Name = "KGBox_Contenedor_Filtros";
            this.KGBox_Contenedor_Filtros.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // KGBox_Contenedor_Filtros.Panel
            // 
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Fecha_Inicio_Busqueda);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Cmb_Tabla);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Operacion);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Cmb_Operacion);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Dtp_Fecha_Termino);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Usuario);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Fecha_Termino);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Tabla);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Cmb_Usuario);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Dtp_Fecha_Inicio);
            this.KGBox_Contenedor_Filtros.Size = new System.Drawing.Size(767, 112);
            this.KGBox_Contenedor_Filtros.TabIndex = 14;
            this.KGBox_Contenedor_Filtros.Text = "Filtros Búsqueda";
            this.KGBox_Contenedor_Filtros.Values.Heading = "Filtros Búsqueda";
            // 
            // Lbl_Fecha_Inicio_Busqueda
            // 
            this.Lbl_Fecha_Inicio_Busqueda.AutoSize = true;
            this.Lbl_Fecha_Inicio_Busqueda.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Fecha_Inicio_Busqueda.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Fecha_Inicio_Busqueda.Location = new System.Drawing.Point(12, 14);
            this.Lbl_Fecha_Inicio_Busqueda.Name = "Lbl_Fecha_Inicio_Busqueda";
            this.Lbl_Fecha_Inicio_Busqueda.Size = new System.Drawing.Size(91, 14);
            this.Lbl_Fecha_Inicio_Busqueda.TabIndex = 1;
            this.Lbl_Fecha_Inicio_Busqueda.Text = "Fecha Inicio";
            // 
            // Cmb_Tabla
            // 
            this.Cmb_Tabla.DropDownWidth = 202;
            this.Cmb_Tabla.Location = new System.Drawing.Point(138, 57);
            this.Cmb_Tabla.Name = "Cmb_Tabla";
            this.Cmb_Tabla.Size = new System.Drawing.Size(202, 21);
            this.Cmb_Tabla.TabIndex = 6;
            // 
            // Lbl_Operacion
            // 
            this.Lbl_Operacion.AutoSize = true;
            this.Lbl_Operacion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Operacion.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Operacion.Location = new System.Drawing.Point(12, 41);
            this.Lbl_Operacion.Name = "Lbl_Operacion";
            this.Lbl_Operacion.Size = new System.Drawing.Size(70, 14);
            this.Lbl_Operacion.TabIndex = 4;
            this.Lbl_Operacion.Text = "Operación";
            // 
            // Cmb_Operacion
            // 
            this.Cmb_Operacion.DropDownWidth = 184;
            this.Cmb_Operacion.Items.AddRange(new object[] {
            "",
            "ALTA",
            "MODIFICADO",
            "ELIMINADO"});
            this.Cmb_Operacion.Location = new System.Drawing.Point(138, 34);
            this.Cmb_Operacion.Name = "Cmb_Operacion";
            this.Cmb_Operacion.Size = new System.Drawing.Size(202, 21);
            this.Cmb_Operacion.TabIndex = 4;
            // 
            // Dtp_Fecha_Termino
            // 
            this.Dtp_Fecha_Termino.CalendarTodayDate = new System.DateTime(2014, 5, 21, 0, 0, 0, 0);
            this.Dtp_Fecha_Termino.Checked = false;
            this.Dtp_Fecha_Termino.Location = new System.Drawing.Point(538, 11);
            this.Dtp_Fecha_Termino.Name = "Dtp_Fecha_Termino";
            this.Dtp_Fecha_Termino.ShowCheckBox = true;
            this.Dtp_Fecha_Termino.Size = new System.Drawing.Size(206, 21);
            this.Dtp_Fecha_Termino.TabIndex = 3;
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Usuario.Location = new System.Drawing.Point(420, 41);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(56, 14);
            this.Lbl_Usuario.TabIndex = 6;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Lbl_Fecha_Termino
            // 
            this.Lbl_Fecha_Termino.AutoSize = true;
            this.Lbl_Fecha_Termino.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Fecha_Termino.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Fecha_Termino.Location = new System.Drawing.Point(420, 14);
            this.Lbl_Fecha_Termino.Name = "Lbl_Fecha_Termino";
            this.Lbl_Fecha_Termino.Size = new System.Drawing.Size(98, 14);
            this.Lbl_Fecha_Termino.TabIndex = 2;
            this.Lbl_Fecha_Termino.Text = "Fecha Termino";
            // 
            // Lbl_Tabla
            // 
            this.Lbl_Tabla.AutoSize = true;
            this.Lbl_Tabla.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Tabla.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Tabla.Location = new System.Drawing.Point(12, 64);
            this.Lbl_Tabla.Name = "Lbl_Tabla";
            this.Lbl_Tabla.Size = new System.Drawing.Size(42, 14);
            this.Lbl_Tabla.TabIndex = 8;
            this.Lbl_Tabla.Text = "Tabla";
            // 
            // Cmb_Usuario
            // 
            this.Cmb_Usuario.DropDownWidth = 185;
            this.Cmb_Usuario.Location = new System.Drawing.Point(538, 34);
            this.Cmb_Usuario.Name = "Cmb_Usuario";
            this.Cmb_Usuario.Size = new System.Drawing.Size(206, 21);
            this.Cmb_Usuario.TabIndex = 5;
            // 
            // Dtp_Fecha_Inicio
            // 
            this.Dtp_Fecha_Inicio.CalendarTodayDate = new System.DateTime(2014, 5, 21, 0, 0, 0, 0);
            this.Dtp_Fecha_Inicio.Checked = false;
            this.Dtp_Fecha_Inicio.Location = new System.Drawing.Point(138, 11);
            this.Dtp_Fecha_Inicio.Name = "Dtp_Fecha_Inicio";
            this.Dtp_Fecha_Inicio.ShowCheckBox = true;
            this.Dtp_Fecha_Inicio.Size = new System.Drawing.Size(202, 21);
            this.Dtp_Fecha_Inicio.TabIndex = 2;
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
            this.Flp_Barra_Herramientas.Size = new System.Drawing.Size(769, 36);
            this.Flp_Barra_Herramientas.TabIndex = 11;
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
            this.Btn_Exportar_PDF.Enabled = false;
            this.Btn_Exportar_PDF.Location = new System.Drawing.Point(42, 3);
            this.Btn_Exportar_PDF.Name = "Btn_Exportar_PDF";
            this.Btn_Exportar_PDF.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_PDF.Size = new System.Drawing.Size(33, 28);
            this.Btn_Exportar_PDF.TabIndex = 1;
            this.Btn_Exportar_PDF.Values.Image = global::ERP_BASE.Properties.Resources.icono_rep_pdf;
            this.Btn_Exportar_PDF.Values.Text = "";
            this.Btn_Exportar_PDF.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Grp_Resultado
            // 
            this.Grp_Resultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Resultado.Location = new System.Drawing.Point(12, 3);
            this.Grp_Resultado.Name = "Grp_Resultado";
            this.Grp_Resultado.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // Grp_Resultado.Panel
            // 
            this.Grp_Resultado.Panel.Controls.Add(this.Grd_Resultado);
            this.Grp_Resultado.Size = new System.Drawing.Size(769, 314);
            this.Grp_Resultado.TabIndex = 0;
            this.Grp_Resultado.Tag = "";
            this.Grp_Resultado.Text = "Resultado";
            this.Grp_Resultado.Values.Heading = "Resultado";
            // 
            // Grd_Resultado
            // 
            this.Grd_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Resultado.Location = new System.Drawing.Point(0, 0);
            this.Grd_Resultado.Name = "Grd_Resultado";
            this.Grd_Resultado.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.Grd_Resultado.ReadOnly = true;
            this.Grd_Resultado.ShowEditingIcon = false;
            this.Grd_Resultado.Size = new System.Drawing.Size(765, 290);
            this.Grd_Resultado.TabIndex = 7;
            // 
            // Btn_Exportar_Excel
            // 
            this.Btn_Exportar_Excel.Enabled = false;
            this.Btn_Exportar_Excel.Location = new System.Drawing.Point(81, 3);
            this.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel";
            this.Btn_Exportar_Excel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_Excel.Size = new System.Drawing.Size(33, 28);
            this.Btn_Exportar_Excel.TabIndex = 2;
            this.Btn_Exportar_Excel.Values.Image = global::ERP_BASE.Properties.Resources.icono_rep_excel;
            this.Btn_Exportar_Excel.Values.Text = "";
            this.Btn_Exportar_Excel.Click += new System.EventHandler(this.Btn_Exportar_Excel_Click);
            // 
            // Frm_Rep_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 531);
            this.Controls.Add(this.Spl_Contenedor);
            this.Name = "Frm_Rep_Log";
            this.Text = "Bitacora";
            this.Load += new System.EventHandler(this.Frm_Rep_Log_Load);
            this.Spl_Contenedor.Panel1.ResumeLayout(false);
            this.Spl_Contenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Spl_Contenedor)).EndInit();
            this.Spl_Contenedor.ResumeLayout(false);
            this.KGBox_Contenedor_Filtros.Panel.ResumeLayout(false);
            this.KGBox_Contenedor_Filtros.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Filtros)).EndInit();
            this.KGBox_Contenedor_Filtros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Operacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cmb_Usuario)).EndInit();
            this.Flp_Barra_Herramientas.ResumeLayout(false);
            this.Grp_Resultado.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grp_Resultado)).EndInit();
            this.Grp_Resultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Spl_Contenedor;
        private System.Windows.Forms.FlowLayoutPanel Flp_Barra_Herramientas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Buscar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Exportar_PDF;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox KGBox_Contenedor_Filtros;
        private System.Windows.Forms.Label Lbl_Fecha_Inicio_Busqueda;
        private System.Windows.Forms.Label Lbl_Operacion;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Operacion;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Dtp_Fecha_Termino;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Label Lbl_Fecha_Termino;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Usuario;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Dtp_Fecha_Inicio;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox Grp_Resultado;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView Grd_Resultado;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox Cmb_Tabla;
        private System.Windows.Forms.Label Lbl_Tabla;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Exportar_Excel;
    }
}