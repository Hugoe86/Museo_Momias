namespace ERP_BASE.Paginas.Reportes
{
    partial class Frm_Rpt_Reporte_Cortes_Arqueo_Cajas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.KPnl_Contenedor = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.KGBox_Contenedor_Resultado_Busqueda = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.Grid_Resultado = new AC.ExtendedRenderer.Toolkit.KryptonGrid();
            this.KGBox_Contenedor_Filtros = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.Lbl_Fecha_Fin = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Fin = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.RBtn_Arques = new System.Windows.Forms.RadioButton();
            this.RBtn_Cortes_Caja = new System.Windows.Forms.RadioButton();
            this.Lbl_Fecha_Inicio_Busqueda = new System.Windows.Forms.Label();
            this.Lbl_Folio = new System.Windows.Forms.Label();
            this.KCmb_Turnos = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            //this.Lbl_Tipo_Reporte = new System.Windows.Forms.Label(); 
            //this.KCmb_Tipo_Reporte = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny3 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.Lbl_Turnos = new System.Windows.Forms.Label();
            this.Lbl_No_Caja = new System.Windows.Forms.Label();
            this.KCmb_Caja = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.KDtp_Fecha_Inicio = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.Flp_Barra_Herramientas = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_Buscar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Exportar_PDF = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Exportar_Excel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Btn_Limpiar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.Rbt_Opc_Recoleccion = new System.Windows.Forms.RadioButton();
            this.Txt_Folio_Recoleccion = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.KPnl_Contenedor)).BeginInit();
            this.KPnl_Contenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Resultado_Busqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Resultado_Busqueda.Panel)).BeginInit();
            this.KGBox_Contenedor_Resultado_Busqueda.Panel.SuspendLayout();
            this.KGBox_Contenedor_Resultado_Busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Filtros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Filtros.Panel)).BeginInit();
            this.KGBox_Contenedor_Filtros.Panel.SuspendLayout();
            this.KGBox_Contenedor_Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KCmb_Turnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KCmb_Caja)).BeginInit();
            this.Flp_Barra_Herramientas.SuspendLayout();
            this.SuspendLayout();
            // 
            // KPnl_Contenedor
            // 
            this.KPnl_Contenedor.Controls.Add(this.KGBox_Contenedor_Resultado_Busqueda);
            this.KPnl_Contenedor.Controls.Add(this.KGBox_Contenedor_Filtros);
            this.KPnl_Contenedor.Controls.Add(this.Flp_Barra_Herramientas);
            this.KPnl_Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KPnl_Contenedor.Location = new System.Drawing.Point(0, 0);
            this.KPnl_Contenedor.Name = "KPnl_Contenedor";
            this.KPnl_Contenedor.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.KPnl_Contenedor.Size = new System.Drawing.Size(751, 625);
            this.KPnl_Contenedor.TabIndex = 2;
            // 
            // KGBox_Contenedor_Resultado_Busqueda
            // 
            this.KGBox_Contenedor_Resultado_Busqueda.Location = new System.Drawing.Point(17, 177);
            this.KGBox_Contenedor_Resultado_Busqueda.Name = "KGBox_Contenedor_Resultado_Busqueda";
            this.KGBox_Contenedor_Resultado_Busqueda.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // KGBox_Contenedor_Resultado_Busqueda.Panel
            // 
            this.KGBox_Contenedor_Resultado_Busqueda.Panel.Controls.Add(this.Grid_Resultado);
            this.KGBox_Contenedor_Resultado_Busqueda.Size = new System.Drawing.Size(716, 435);
            this.KGBox_Contenedor_Resultado_Busqueda.TabIndex = 14;
            this.KGBox_Contenedor_Resultado_Busqueda.Text = "Resultado de la Búsqueda";
            this.KGBox_Contenedor_Resultado_Busqueda.Values.Heading = "Resultado de la Búsqueda";
            // 
            // Grid_Resultado
            // 
            this.Grid_Resultado.AllowUserToAddRows = false;
            this.Grid_Resultado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(246)))));
            this.Grid_Resultado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Resultado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Resultado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Resultado.DefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Resultado.Location = new System.Drawing.Point(0, 0);
            this.Grid_Resultado.Name = "Grid_Resultado";
            this.Grid_Resultado.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Resultado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Grid_Resultado.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.Grid_Resultado.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Navy;
            this.Grid_Resultado.Size = new System.Drawing.Size(712, 411);
            this.Grid_Resultado.TabIndex = 0;
            this.Grid_Resultado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Grid_Resultado_CellFormatting);
            // 
            // KGBox_Contenedor_Filtros
            // 
            this.KGBox_Contenedor_Filtros.Location = new System.Drawing.Point(15, 43);
            this.KGBox_Contenedor_Filtros.Name = "KGBox_Contenedor_Filtros";
            this.KGBox_Contenedor_Filtros.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            // 
            // KGBox_Contenedor_Filtros.Panel
            // 
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Fecha_Fin);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Dtp_Fecha_Fin);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Rbt_Opc_Recoleccion);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.RBtn_Arques);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.RBtn_Cortes_Caja);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Fecha_Inicio_Busqueda);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.KCmb_Turnos);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Turnos);
            //this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Tipo_Reporte);
            //this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.KCmb_Tipo_Reporte);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_No_Caja);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Lbl_Folio);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.KCmb_Caja);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.KDtp_Fecha_Inicio);
            this.KGBox_Contenedor_Filtros.Panel.Controls.Add(this.Txt_Folio_Recoleccion);
            this.KGBox_Contenedor_Filtros.Size = new System.Drawing.Size(718, 128);
            this.KGBox_Contenedor_Filtros.TabIndex = 13;
            this.KGBox_Contenedor_Filtros.Text = "Filtros Búsqueda";
            this.KGBox_Contenedor_Filtros.Values.Heading = "Filtros Búsqueda";
            // 
            // Lbl_Fecha_Fin
            // 
            this.Lbl_Fecha_Fin.AutoSize = true;
            this.Lbl_Fecha_Fin.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Fecha_Fin.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Fecha_Fin.Location = new System.Drawing.Point(380, 14);
            this.Lbl_Fecha_Fin.Name = "Lbl_Fecha_Fin";
            this.Lbl_Fecha_Fin.Size = new System.Drawing.Size(0, 14);
            this.Lbl_Fecha_Fin.TabIndex = 15;
            // 
            // Dtp_Fecha_Fin
            // 
            this.Dtp_Fecha_Fin.CalendarTodayDate = new System.DateTime(2014, 5, 21, 0, 0, 0, 0);
            //this.Dtp_Fecha_Fin.Checked = false;
            this.Dtp_Fecha_Fin.Location = new System.Drawing.Point(498, 11);
            this.Dtp_Fecha_Fin.Name = "Dtp_Fecha_Fin";
            //this.Dtp_Fecha_Fin.ShowCheckBox = true;
            this.Dtp_Fecha_Fin.Size = new System.Drawing.Size(202, 21);
            this.Dtp_Fecha_Fin.TabIndex = 14;
            // 
            // RBtn_Arques
            // 
            this.RBtn_Arques.AutoSize = true;
            this.RBtn_Arques.BackColor = System.Drawing.Color.White;
            this.RBtn_Arques.Location = new System.Drawing.Point(475, 85);
            this.RBtn_Arques.Name = "RBtn_Arques";
            this.RBtn_Arques.Size = new System.Drawing.Size(64, 17);
            this.RBtn_Arques.TabIndex = 14;
            this.RBtn_Arques.Text = "Arqueos";
            this.RBtn_Arques.UseVisualStyleBackColor = false;
            this.RBtn_Arques.CheckedChanged += new System.EventHandler(this.RBtn_Arques_CheckedChanged);
            // 
            // RBtn_Cortes_Caja
            // 
            this.RBtn_Cortes_Caja.AutoSize = true;
            this.RBtn_Cortes_Caja.BackColor = System.Drawing.Color.White;
            this.RBtn_Cortes_Caja.Location = new System.Drawing.Point(540, 85);
            this.RBtn_Cortes_Caja.Name = "RBtn_Cortes_Caja";
            this.RBtn_Cortes_Caja.Size = new System.Drawing.Size(79, 17);
            this.RBtn_Cortes_Caja.TabIndex = 13;
            this.RBtn_Cortes_Caja.TabStop = true;
            this.RBtn_Cortes_Caja.Text = "Cortes Caja";
            this.RBtn_Cortes_Caja.UseVisualStyleBackColor = false;
            this.RBtn_Cortes_Caja.CheckedChanged += new System.EventHandler(this.RBtn_Cortes_Caja_CheckedChanged);
            // 
            // Rbt_Opc_Recoleccion
            // 
            this.Rbt_Opc_Recoleccion.AutoSize = true;
            this.Rbt_Opc_Recoleccion.BackColor = System.Drawing.Color.White;
            this.Rbt_Opc_Recoleccion.Location = new System.Drawing.Point(410, 146);
            this.Rbt_Opc_Recoleccion.Checked = true;
            this.Rbt_Opc_Recoleccion.Name = "Rbt_Opc_Recoleccion";
            this.Rbt_Opc_Recoleccion.Size = new System.Drawing.Size(85, 17);
            this.Rbt_Opc_Recoleccion.TabIndex = 12;
            this.Rbt_Opc_Recoleccion.Text = "Recolección";
            this.Rbt_Opc_Recoleccion.UseVisualStyleBackColor = false;
            this.Rbt_Opc_Recoleccion.CheckedChanged += new System.EventHandler(this.Rbt_Opc_Recoleccion_CheckedChanged);
            
            // 
            // Lbl_Fecha_Inicio_Busqueda
            // 
            this.Lbl_Fecha_Inicio_Busqueda.AutoSize = true;
            this.Lbl_Fecha_Inicio_Busqueda.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Fecha_Inicio_Busqueda.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Fecha_Inicio_Busqueda.Location = new System.Drawing.Point(12, 14);
            this.Lbl_Fecha_Inicio_Busqueda.Name = "Lbl_Fecha_Inicio_Busqueda";
            this.Lbl_Fecha_Inicio_Busqueda.Size = new System.Drawing.Size(28, 14);
            this.Lbl_Fecha_Inicio_Busqueda.TabIndex = 1;
            this.Lbl_Fecha_Inicio_Busqueda.Text = "Día";
            // 
            // KCmb_Turnos
            // 
            this.KCmb_Turnos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.KCmb_Turnos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.KCmb_Turnos.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny3});
            this.KCmb_Turnos.DropDownWidth = 185;
            this.KCmb_Turnos.Location = new System.Drawing.Point(498, 35);
            this.KCmb_Turnos.Name = "KCmb_Turnos";
            this.KCmb_Turnos.Size = new System.Drawing.Size(206, 21);
            this.KCmb_Turnos.TabIndex = 11;
            //// 
            //// KCmb_Tipo_Reporte
            //// 
            //this.KCmb_Tipo_Reporte.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            //this.KCmb_Tipo_Reporte.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            //this.KCmb_Tipo_Reporte.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            //this.buttonSpecAny3});
            //this.KCmb_Tipo_Reporte.DropDownWidth = 185;
            //this.KCmb_Tipo_Reporte.Location = new System.Drawing.Point(498, 60);
            //this.KCmb_Tipo_Reporte.Name = "KCmb_Tipo_Reporte";
            //this.KCmb_Tipo_Reporte.Size = new System.Drawing.Size(206, 21);
            //this.KCmb_Tipo_Reporte.TabIndex = 11;
            // 
            // buttonSpecAny3
            // 
            this.buttonSpecAny3.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny3.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.LowProfile;
            this.buttonSpecAny3.Tag = "turno";
            this.buttonSpecAny3.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.buttonSpecAny3.UniqueName = "5726B33426C340114FA927FD444E1C58";
            this.buttonSpecAny3.Click += new System.EventHandler(this.SBtn_Clear_Click);
            // 
            // Lbl_Turnos
            // 
            this.Lbl_Turnos.AutoSize = true;
            this.Lbl_Turnos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Turnos.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Turnos.Location = new System.Drawing.Point(380, 38);
            this.Lbl_Turnos.Name = "Lbl_Turnos";
            this.Lbl_Turnos.Size = new System.Drawing.Size(42, 14);
            this.Lbl_Turnos.TabIndex = 10;
            this.Lbl_Turnos.Text = "Turno";
            //// 
            //// Lbl_Tipo_Reporte
            //// 
            //this.Lbl_Tipo_Reporte.AutoSize = true;
            //this.Lbl_Tipo_Reporte.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            //this.Lbl_Tipo_Reporte.Font = new System.Drawing.Font("Consolas", 9F);
            //this.Lbl_Tipo_Reporte.Location = new System.Drawing.Point(380, 60);
            //this.Lbl_Tipo_Reporte.Name = "Lbl_Tipo_Reporte";
            //this.Lbl_Tipo_Reporte.Size = new System.Drawing.Size(42, 14);
            //this.Lbl_Tipo_Reporte.TabIndex = 10;
            //this.Lbl_Tipo_Reporte.Text = "Tipo Reporte";

            // 
            // Lbl_No_Caja
            // 
            this.Lbl_No_Caja.AutoSize = true;
            this.Lbl_No_Caja.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_No_Caja.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_No_Caja.Location = new System.Drawing.Point(12, 41);
            this.Lbl_No_Caja.Name = "Lbl_No_Caja";
            this.Lbl_No_Caja.Size = new System.Drawing.Size(35, 14);
            this.Lbl_No_Caja.TabIndex = 6;
            this.Lbl_No_Caja.Text = "Caja";

            // 
            // Lbl_Folio
            // 
            this.Lbl_Folio.AutoSize = true;
            this.Lbl_Folio.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_Folio.Font = new System.Drawing.Font("Consolas", 9F);
            this.Lbl_Folio.Location = new System.Drawing.Point(12, 70);
            this.Lbl_Folio.Name = "Lbl_Folio";
            this.Lbl_Folio.Size = new System.Drawing.Size(35, 14);
            this.Lbl_Folio.TabIndex = 6;
            this.Lbl_Folio.Text = "Folio";

            // 
            // KCmb_Caja
            // 
            this.KCmb_Caja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.KCmb_Caja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.KCmb_Caja.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.KCmb_Caja.DropDownWidth = 185;
            this.KCmb_Caja.Location = new System.Drawing.Point(138, 38);
            this.KCmb_Caja.Name = "KCmb_Caja";
            this.KCmb_Caja.Size = new System.Drawing.Size(202, 21);
            this.KCmb_Caja.TabIndex = 7;
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.buttonSpecAny2.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.LowProfile;
            this.buttonSpecAny2.Tag = "caja";
            this.buttonSpecAny2.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.Close;
            this.buttonSpecAny2.UniqueName = "ABA55A83A2E44ACA218E8D557CC31561";
            this.buttonSpecAny2.Click += new System.EventHandler(this.SBtn_Clear_Click);
            // 
            // KDtp_Fecha_Inicio
            // 
            this.KDtp_Fecha_Inicio.CalendarTodayDate = new System.DateTime(2014, 5, 21, 0, 0, 0, 0);
            this.KDtp_Fecha_Inicio.Location = new System.Drawing.Point(138, 11);
            this.KDtp_Fecha_Inicio.Name = "KDtp_Fecha_Inicio";
            this.KDtp_Fecha_Inicio.Size = new System.Drawing.Size(202, 21);
            this.KDtp_Fecha_Inicio.TabIndex = 0;
            // 
            // Flp_Barra_Herramientas
            // 
            this.Flp_Barra_Herramientas.BackColor = System.Drawing.Color.AliceBlue;
            this.Flp_Barra_Herramientas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Buscar);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_PDF);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Exportar_Excel);
            this.Flp_Barra_Herramientas.Controls.Add(this.Btn_Limpiar);
            this.Flp_Barra_Herramientas.Location = new System.Drawing.Point(15, 3);
            this.Flp_Barra_Herramientas.Name = "Flp_Barra_Herramientas";
            this.Flp_Barra_Herramientas.Size = new System.Drawing.Size(718, 36);
            this.Flp_Barra_Herramientas.TabIndex = 10;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Location = new System.Drawing.Point(3, 3);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Buscar.Size = new System.Drawing.Size(33, 28);
            this.Btn_Buscar.TabIndex = 5;
            this.Btn_Buscar.Values.Image = global::ERP_BASE.Properties.Resources.icono_busqueda_24x20;
            this.Btn_Buscar.Values.Text = "";
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_Exportar_PDF
            // 
            this.Btn_Exportar_PDF.Location = new System.Drawing.Point(42, 3);
            this.Btn_Exportar_PDF.Name = "Btn_Exportar_PDF";
            this.Btn_Exportar_PDF.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_PDF.Size = new System.Drawing.Size(33, 28);
            this.Btn_Exportar_PDF.TabIndex = 2;
            this.Btn_Exportar_PDF.Values.Image = global::ERP_BASE.Properties.Resources.icono_imprimir_17x17;
            this.Btn_Exportar_PDF.Values.Text = "";
            this.Btn_Exportar_PDF.Click += new System.EventHandler(this.Btn_Exportar_PDF_Click);
            // 
            // Btn_Exportar_Excel
            // 
            this.Btn_Exportar_Excel.Location = new System.Drawing.Point(60, 3);
            this.Btn_Exportar_Excel.Name = "Btn_Exportar_Excel";
            this.Btn_Exportar_Excel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Exportar_Excel.Size = new System.Drawing.Size(33, 28);
            this.Btn_Exportar_Excel.TabIndex = 3;
            this.Btn_Exportar_Excel.Values.Image = global::ERP_BASE.Properties.Resources.icono_rep_excel;
            this.Btn_Exportar_Excel.Values.Text = "";
            this.Btn_Exportar_Excel.Click += new System.EventHandler(this.Btn_Exportar_Excel_Click);

            // 
            // Btn_Limpiar
            // 
            this.Btn_Limpiar.Location = new System.Drawing.Point(81, 3);
            this.Btn_Limpiar.Name = "Btn_Limpiar";
            this.Btn_Limpiar.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue;
            this.Btn_Limpiar.Size = new System.Drawing.Size(33, 28);
            this.Btn_Limpiar.TabIndex = 6;
            this.Btn_Limpiar.Values.Image = global::ERP_BASE.Properties.Resources.icono_escoba_14x14;
            this.Btn_Limpiar.Values.Text = "";
            this.Btn_Limpiar.Click += new System.EventHandler(this.Btn_Limpiar_Click);

            // 
            // Txt_Folio_Recoleccion
            // 
            this.Txt_Folio_Recoleccion.Font = new System.Drawing.Font("Consolas", 9F);
            this.Txt_Folio_Recoleccion.Location = new System.Drawing.Point(137, 65);
            this.Txt_Folio_Recoleccion.Name = "Txt_Folio_Recoleccion";
            this.Txt_Folio_Recoleccion.Size = new System.Drawing.Size(203, 22);
            this.Txt_Folio_Recoleccion.TabIndex = 6;
            this.Txt_Folio_Recoleccion.MaxLength = 10;
            //this.Txt_Folio_Recoleccion.TextChanged += new System.EventHandler(this.Txt_Folio_Recoleccion.TextChanged);
           
            // 
            // Frm_Rpt_Reporte_Cortes_Arqueo_Cajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 625);
            this.Controls.Add(this.Rbt_Opc_Recoleccion);
            this.Controls.Add(this.KPnl_Contenedor);
            this.Name = "Frm_Rpt_Reporte_Cortes_Arqueo_Cajas";
            this.Text = "Reporte de Cortes y Arqueos de Caja";
            ((System.ComponentModel.ISupportInitialize)(this.KPnl_Contenedor)).EndInit();
            this.KPnl_Contenedor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Resultado_Busqueda.Panel)).EndInit();
            this.KGBox_Contenedor_Resultado_Busqueda.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Resultado_Busqueda)).EndInit();
            this.KGBox_Contenedor_Resultado_Busqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Resultado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Filtros.Panel)).EndInit();
            this.KGBox_Contenedor_Filtros.Panel.ResumeLayout(false);
            this.KGBox_Contenedor_Filtros.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KGBox_Contenedor_Filtros)).EndInit();
            this.KGBox_Contenedor_Filtros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KCmb_Turnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KCmb_Caja)).EndInit();
            this.Flp_Barra_Herramientas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel KPnl_Contenedor;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox KGBox_Contenedor_Resultado_Busqueda;
        private AC.ExtendedRenderer.Toolkit.KryptonGrid Grid_Resultado;
        private ComponentFactory.Krypton.Toolkit.KryptonGroupBox KGBox_Contenedor_Filtros;
        private System.Windows.Forms.Label Lbl_Fecha_Inicio_Busqueda;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox KCmb_Turnos;
        //private ComponentFactory.Krypton.Toolkit.KryptonComboBox KCmb_Tipo_Reporte;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny3;
        private System.Windows.Forms.Label Lbl_Turnos;
        private System.Windows.Forms.Label Lbl_No_Caja;
        private System.Windows.Forms.Label Lbl_Folio;
        // System.Windows.Forms.Label Lbl_Tipo_Reporte;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox KCmb_Caja;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker KDtp_Fecha_Inicio;
        private System.Windows.Forms.FlowLayoutPanel Flp_Barra_Herramientas;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Buscar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Exportar_PDF;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Exportar_Excel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton Btn_Limpiar;
        private System.Windows.Forms.RadioButton RBtn_Arques;
        private System.Windows.Forms.RadioButton RBtn_Cortes_Caja;
        private System.Windows.Forms.Label Lbl_Fecha_Fin;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker Dtp_Fecha_Fin;
        private System.Windows.Forms.RadioButton Rbt_Opc_Recoleccion;
        private System.Windows.Forms.TextBox Txt_Folio_Recoleccion;
    }
}