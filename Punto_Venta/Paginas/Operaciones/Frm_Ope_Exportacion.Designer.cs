namespace ERP_BASE.Paginas.Operaciones
{
    partial class Frm_Ope_Exportacion
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
            this.Fra_Pendientes_Exportar = new System.Windows.Forms.GroupBox();
            this.Btn_Exportar = new System.Windows.Forms.Button();
            this.Grid_Pendientes = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fra_Ventas = new System.Windows.Forms.GroupBox();
            this.Grid_Ventas = new System.Windows.Forms.DataGridView();
            this.Fra_Padron = new System.Windows.Forms.GroupBox();
            this.Grid_Padron = new System.Windows.Forms.DataGridView();
            this.Fra_Lista_Deudor = new System.Windows.Forms.GroupBox();
            this.Grid_Lista_Deudor = new System.Windows.Forms.DataGridView();
            this.Fra_Pendientes_Exportar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Pendientes)).BeginInit();
            this.Fra_Ventas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Ventas)).BeginInit();
            this.Fra_Padron.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Padron)).BeginInit();
            this.Fra_Lista_Deudor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Lista_Deudor)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Pendientes_Exportar
            // 
            this.Fra_Pendientes_Exportar.Controls.Add(this.Btn_Exportar);
            this.Fra_Pendientes_Exportar.Controls.Add(this.Grid_Pendientes);
            this.Fra_Pendientes_Exportar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Pendientes_Exportar.Location = new System.Drawing.Point(12, 12);
            this.Fra_Pendientes_Exportar.Name = "Fra_Pendientes_Exportar";
            this.Fra_Pendientes_Exportar.Size = new System.Drawing.Size(677, 140);
            this.Fra_Pendientes_Exportar.TabIndex = 0;
            this.Fra_Pendientes_Exportar.TabStop = false;
            this.Fra_Pendientes_Exportar.Text = "Pendientes";
            // 
            // Btn_Exportar
            // 
            this.Btn_Exportar.Image = global::ERP_BASE.Properties.Resources.accept;
            this.Btn_Exportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Exportar.Location = new System.Drawing.Point(546, 87);
            this.Btn_Exportar.Name = "Btn_Exportar";
            this.Btn_Exportar.Size = new System.Drawing.Size(119, 47);
            this.Btn_Exportar.TabIndex = 8;
            this.Btn_Exportar.Text = "Exportar";
            this.Btn_Exportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Exportar.UseVisualStyleBackColor = true;
            this.Btn_Exportar.Click += new System.EventHandler(this.Btn_Exportar_Click);
            // 
            // Grid_Pendientes
            // 
            this.Grid_Pendientes.AllowUserToAddRows = false;
            this.Grid_Pendientes.AllowUserToDeleteRows = false;
            this.Grid_Pendientes.AllowUserToResizeRows = false;
            this.Grid_Pendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Pendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Pendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha});
            this.Grid_Pendientes.Location = new System.Drawing.Point(6, 21);
            this.Grid_Pendientes.Name = "Grid_Pendientes";
            this.Grid_Pendientes.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Pendientes.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Pendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Pendientes.Size = new System.Drawing.Size(534, 113);
            this.Grid_Pendientes.TabIndex = 7;
            this.Grid_Pendientes.SelectionChanged += new System.EventHandler(this.Grid_Pendientes_SelectionChanged);
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha pendiente";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 111;
            // 
            // Fra_Ventas
            // 
            this.Fra_Ventas.Controls.Add(this.Grid_Ventas);
            this.Fra_Ventas.Location = new System.Drawing.Point(12, 158);
            this.Fra_Ventas.Name = "Fra_Ventas";
            this.Fra_Ventas.Size = new System.Drawing.Size(677, 150);
            this.Fra_Ventas.TabIndex = 1;
            this.Fra_Ventas.TabStop = false;
            this.Fra_Ventas.Text = "Ventas";
            // 
            // Grid_Ventas
            // 
            this.Grid_Ventas.AllowUserToAddRows = false;
            this.Grid_Ventas.AllowUserToDeleteRows = false;
            this.Grid_Ventas.AllowUserToResizeRows = false;
            this.Grid_Ventas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Ventas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Ventas.Location = new System.Drawing.Point(6, 19);
            this.Grid_Ventas.Name = "Grid_Ventas";
            this.Grid_Ventas.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Ventas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Grid_Ventas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Ventas.Size = new System.Drawing.Size(665, 125);
            this.Grid_Ventas.TabIndex = 7;
            // 
            // Fra_Padron
            // 
            this.Fra_Padron.Controls.Add(this.Grid_Padron);
            this.Fra_Padron.Location = new System.Drawing.Point(12, 314);
            this.Fra_Padron.Name = "Fra_Padron";
            this.Fra_Padron.Size = new System.Drawing.Size(677, 150);
            this.Fra_Padron.TabIndex = 2;
            this.Fra_Padron.TabStop = false;
            this.Fra_Padron.Text = "Padron";
            // 
            // Grid_Padron
            // 
            this.Grid_Padron.AllowUserToAddRows = false;
            this.Grid_Padron.AllowUserToDeleteRows = false;
            this.Grid_Padron.AllowUserToResizeRows = false;
            this.Grid_Padron.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Padron.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Padron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Padron.Location = new System.Drawing.Point(6, 19);
            this.Grid_Padron.Name = "Grid_Padron";
            this.Grid_Padron.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Padron.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Padron.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Padron.Size = new System.Drawing.Size(665, 125);
            this.Grid_Padron.TabIndex = 7;
            // 
            // Fra_Lista_Deudor
            // 
            this.Fra_Lista_Deudor.Controls.Add(this.Grid_Lista_Deudor);
            this.Fra_Lista_Deudor.Location = new System.Drawing.Point(12, 477);
            this.Fra_Lista_Deudor.Name = "Fra_Lista_Deudor";
            this.Fra_Lista_Deudor.Size = new System.Drawing.Size(671, 150);
            this.Fra_Lista_Deudor.TabIndex = 8;
            this.Fra_Lista_Deudor.TabStop = false;
            this.Fra_Lista_Deudor.Text = "Lista Deudor";
            // 
            // Grid_Lista_Deudor
            // 
            this.Grid_Lista_Deudor.AllowUserToAddRows = false;
            this.Grid_Lista_Deudor.AllowUserToDeleteRows = false;
            this.Grid_Lista_Deudor.AllowUserToResizeRows = false;
            this.Grid_Lista_Deudor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Lista_Deudor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Lista_Deudor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Lista_Deudor.Location = new System.Drawing.Point(6, 19);
            this.Grid_Lista_Deudor.Name = "Grid_Lista_Deudor";
            this.Grid_Lista_Deudor.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Lista_Deudor.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Grid_Lista_Deudor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Lista_Deudor.Size = new System.Drawing.Size(659, 125);
            this.Grid_Lista_Deudor.TabIndex = 7;
            // 
            // Frm_Ope_Exportacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 639);
            this.Controls.Add(this.Fra_Lista_Deudor);
            this.Controls.Add(this.Fra_Padron);
            this.Controls.Add(this.Fra_Ventas);
            this.Controls.Add(this.Fra_Pendientes_Exportar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Ope_Exportacion";
            this.Text = "Exportacion de ventas";
            this.Load += new System.EventHandler(this.Frm_Ope_Exportacion_Load);
            this.Fra_Pendientes_Exportar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Pendientes)).EndInit();
            this.Fra_Ventas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Ventas)).EndInit();
            this.Fra_Padron.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Padron)).EndInit();
            this.Fra_Lista_Deudor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Lista_Deudor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Pendientes_Exportar;
        private System.Windows.Forms.DataGridView Grid_Pendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.GroupBox Fra_Ventas;
        private System.Windows.Forms.DataGridView Grid_Ventas;
        private System.Windows.Forms.GroupBox Fra_Padron;
        private System.Windows.Forms.DataGridView Grid_Padron;
        private System.Windows.Forms.GroupBox Fra_Lista_Deudor;
        private System.Windows.Forms.DataGridView Grid_Lista_Deudor;
        private System.Windows.Forms.Button Btn_Exportar;
    }
}