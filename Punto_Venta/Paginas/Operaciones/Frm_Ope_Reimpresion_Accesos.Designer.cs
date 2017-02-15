namespace ERP_BASE.Paginas.Operaciones
{
    partial class Frm_Ope_Reimpresion_Accesos
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
            this.Fra_Busqueda_Folio = new System.Windows.Forms.GroupBox();
            this.Btn_Reimprimir = new System.Windows.Forms.Button();
            this.Btn_Consultar_Venta = new System.Windows.Forms.Button();
            this.Txt_Numero_Venta = new System.Windows.Forms.TextBox();
            this.Lbl_Numero_Venta = new System.Windows.Forms.Label();
            this.Fra_Accesos = new System.Windows.Forms.GroupBox();
            this.Grid_Accesos = new System.Windows.Forms.DataGridView();
            this.Reimprimir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fra_Busqueda_Folio.SuspendLayout();
            this.Fra_Accesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Accesos)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Busqueda_Folio
            // 
            this.Fra_Busqueda_Folio.Controls.Add(this.Btn_Reimprimir);
            this.Fra_Busqueda_Folio.Controls.Add(this.Btn_Consultar_Venta);
            this.Fra_Busqueda_Folio.Controls.Add(this.Txt_Numero_Venta);
            this.Fra_Busqueda_Folio.Controls.Add(this.Lbl_Numero_Venta);
            this.Fra_Busqueda_Folio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Busqueda_Folio.Location = new System.Drawing.Point(13, 12);
            this.Fra_Busqueda_Folio.Name = "Fra_Busqueda_Folio";
            this.Fra_Busqueda_Folio.Size = new System.Drawing.Size(433, 58);
            this.Fra_Busqueda_Folio.TabIndex = 0;
            this.Fra_Busqueda_Folio.TabStop = false;
            this.Fra_Busqueda_Folio.Text = "Busqueda";
            // 
            // Btn_Reimprimir
            // 
            this.Btn_Reimprimir.Image = global::ERP_BASE.Properties.Resources.icono_imprimir_24x24;
            this.Btn_Reimprimir.Location = new System.Drawing.Point(374, 11);
            this.Btn_Reimprimir.Name = "Btn_Reimprimir";
            this.Btn_Reimprimir.Size = new System.Drawing.Size(53, 41);
            this.Btn_Reimprimir.TabIndex = 3;
            this.Btn_Reimprimir.UseVisualStyleBackColor = true;
            this.Btn_Reimprimir.Click += new System.EventHandler(this.Btn_Reimprimir_Click);
            // 
            // Btn_Consultar_Venta
            // 
            this.Btn_Consultar_Venta.Image = global::ERP_BASE.Properties.Resources.icono_busqueda_fondo_azul_24x24;
            this.Btn_Consultar_Venta.Location = new System.Drawing.Point(315, 11);
            this.Btn_Consultar_Venta.Name = "Btn_Consultar_Venta";
            this.Btn_Consultar_Venta.Size = new System.Drawing.Size(53, 41);
            this.Btn_Consultar_Venta.TabIndex = 2;
            this.Btn_Consultar_Venta.UseVisualStyleBackColor = true;
            this.Btn_Consultar_Venta.Click += new System.EventHandler(this.Btn_Consultar_Venta_Click);
            // 
            // Txt_Numero_Venta
            // 
            this.Txt_Numero_Venta.Location = new System.Drawing.Point(101, 22);
            this.Txt_Numero_Venta.MaxLength = 10;
            this.Txt_Numero_Venta.Name = "Txt_Numero_Venta";
            this.Txt_Numero_Venta.Size = new System.Drawing.Size(191, 21);
            this.Txt_Numero_Venta.TabIndex = 1;
            this.Txt_Numero_Venta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numero_Venta_KeyPress);
            // 
            // Lbl_Numero_Venta
            // 
            this.Lbl_Numero_Venta.AutoSize = true;
            this.Lbl_Numero_Venta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Numero_Venta.Location = new System.Drawing.Point(6, 25);
            this.Lbl_Numero_Venta.Name = "Lbl_Numero_Venta";
            this.Lbl_Numero_Venta.Size = new System.Drawing.Size(89, 14);
            this.Lbl_Numero_Venta.TabIndex = 0;
            this.Lbl_Numero_Venta.Text = "Número de venta";
            // 
            // Fra_Accesos
            // 
            this.Fra_Accesos.Controls.Add(this.Grid_Accesos);
            this.Fra_Accesos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Accesos.Location = new System.Drawing.Point(13, 92);
            this.Fra_Accesos.Name = "Fra_Accesos";
            this.Fra_Accesos.Size = new System.Drawing.Size(654, 216);
            this.Fra_Accesos.TabIndex = 1;
            this.Fra_Accesos.TabStop = false;
            this.Fra_Accesos.Text = "Accesos";
            // 
            // Grid_Accesos
            // 
            this.Grid_Accesos.AllowUserToAddRows = false;
            this.Grid_Accesos.AllowUserToDeleteRows = false;
            this.Grid_Accesos.AllowUserToResizeRows = false;
            this.Grid_Accesos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Accesos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reimprimir});
            this.Grid_Accesos.Location = new System.Drawing.Point(6, 19);
            this.Grid_Accesos.Name = "Grid_Accesos";
            this.Grid_Accesos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Accesos.Size = new System.Drawing.Size(642, 191);
            this.Grid_Accesos.TabIndex = 0;
            this.Grid_Accesos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Accesos_CellContentClick);
            // 
            // Reimprimir
            // 
            this.Reimprimir.HeaderText = "Re imprimir";
            this.Reimprimir.Name = "Reimprimir";
            this.Reimprimir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Reimprimir.Width = 80;
            // 
            // Frm_Ope_Reimpresion_Accesos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(679, 324);
            this.Controls.Add(this.Fra_Accesos);
            this.Controls.Add(this.Fra_Busqueda_Folio);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Ope_Reimpresion_Accesos";
            this.Text = "Reimpresion de accesos";
            this.Fra_Busqueda_Folio.ResumeLayout(false);
            this.Fra_Busqueda_Folio.PerformLayout();
            this.Fra_Accesos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Accesos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Busqueda_Folio;
        private System.Windows.Forms.Button Btn_Reimprimir;
        private System.Windows.Forms.Button Btn_Consultar_Venta;
        private System.Windows.Forms.TextBox Txt_Numero_Venta;
        private System.Windows.Forms.Label Lbl_Numero_Venta;
        private System.Windows.Forms.GroupBox Fra_Accesos;
        private System.Windows.Forms.DataGridView Grid_Accesos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Reimprimir;
    }
}