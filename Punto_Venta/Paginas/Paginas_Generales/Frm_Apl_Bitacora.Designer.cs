namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Apl_Bitacora
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
            this.Grp_Tablas = new System.Windows.Forms.GroupBox();
            this.Grd_Tablas = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bitacora = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Log = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Vaciar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Grp_Tablas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Tablas)).BeginInit();
            this.SuspendLayout();
            // 
            // Grp_Tablas
            // 
            this.Grp_Tablas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Tablas.Controls.Add(this.Grd_Tablas);
            this.Grp_Tablas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Grp_Tablas.Location = new System.Drawing.Point(6, 6);
            this.Grp_Tablas.Name = "Grp_Tablas";
            this.Grp_Tablas.Size = new System.Drawing.Size(741, 437);
            this.Grp_Tablas.TabIndex = 0;
            this.Grp_Tablas.TabStop = false;
            this.Grp_Tablas.Text = "Tablas";
            // 
            // Grd_Tablas
            // 
            this.Grd_Tablas.AllowUserToAddRows = false;
            this.Grd_Tablas.AllowUserToDeleteRows = false;
            this.Grd_Tablas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Grd_Tablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Tablas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Bitacora,
            this.Log,
            this.Vaciar});
            this.Grd_Tablas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grd_Tablas.Location = new System.Drawing.Point(3, 17);
            this.Grd_Tablas.Name = "Grd_Tablas";
            this.Grd_Tablas.Size = new System.Drawing.Size(735, 417);
            this.Grd_Tablas.TabIndex = 0;
            this.Grd_Tablas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_Tablas_CellClick);
            this.Grd_Tablas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_Tablas_CellContentClick);
            this.Grd_Tablas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grd_Tablas_CellEndEdit);
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nombre.DataPropertyName = "TABLE_NAME";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // Bitacora
            // 
            this.Bitacora.DataPropertyName = "Bitacora";
            this.Bitacora.FalseValue = "0";
            this.Bitacora.HeaderText = "Bitácora";
            this.Bitacora.Name = "Bitacora";
            this.Bitacora.ToolTipText = "Generar tabla para almacenar Log de esta tabla";
            this.Bitacora.TrueValue = "1";
            // 
            // Log
            // 
            this.Log.DataPropertyName = "Log";
            this.Log.FalseValue = "0";
            this.Log.HeaderText = "Log";
            this.Log.Name = "Log";
            this.Log.ToolTipText = "Crear triggers para almacenar el Log de esta tabla";
            this.Log.TrueValue = "1";
            // 
            // Vaciar
            // 
            this.Vaciar.HeaderText = "Vaciar";
            this.Vaciar.Name = "Vaciar";
            this.Vaciar.Text = "Vaciar";
            this.Vaciar.ToolTipText = "Eliminar el contenido de la tabla bitácora";
            this.Vaciar.UseColumnTextForButtonValue = true;
            // 
            // Frm_Apl_Bitacora
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(753, 449);
            this.Controls.Add(this.Grp_Tablas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Apl_Bitacora";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log de eventos";
            this.Load += new System.EventHandler(this.Frm_Apl_Bitacora_Load);
            this.Grp_Tablas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Tablas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grp_Tablas;
        private System.Windows.Forms.DataGridView Grd_Tablas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Bitacora;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Log;
        private System.Windows.Forms.DataGridViewButtonColumn Vaciar;
    }
}