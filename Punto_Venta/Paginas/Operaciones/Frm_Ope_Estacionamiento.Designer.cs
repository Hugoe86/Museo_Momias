namespace ERP_BASE.Paginas.Operaciones
{
    partial class Frm_Ope_Estacionamiento
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
            this.Pnl_Tipo_Acceso = new System.Windows.Forms.GroupBox();
            this.Pnl_Servicios_Estacionamiento = new System.Windows.Forms.FlowLayoutPanel();
            this.Txt_Codigo_Barras = new System.Windows.Forms.TextBox();
            this.Lbl_Cont_Carros = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Carros = new System.Windows.Forms.TextBox();
            this.Txt_Camionetas = new System.Windows.Forms.TextBox();
            this.Pnl_Tipo_Acceso.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_Tipo_Acceso
            // 
            this.Pnl_Tipo_Acceso.Controls.Add(this.Pnl_Servicios_Estacionamiento);
            this.Pnl_Tipo_Acceso.Font = new System.Drawing.Font("Arial", 11F);
            this.Pnl_Tipo_Acceso.Location = new System.Drawing.Point(12, 2);
            this.Pnl_Tipo_Acceso.Name = "Pnl_Tipo_Acceso";
            this.Pnl_Tipo_Acceso.Size = new System.Drawing.Size(754, 219);
            this.Pnl_Tipo_Acceso.TabIndex = 0;
            this.Pnl_Tipo_Acceso.TabStop = false;
            this.Pnl_Tipo_Acceso.Text = "Tickets del Estacionamiento ";
            // 
            // Pnl_Servicios_Estacionamiento
            // 
            this.Pnl_Servicios_Estacionamiento.Location = new System.Drawing.Point(7, 24);
            this.Pnl_Servicios_Estacionamiento.Name = "Pnl_Servicios_Estacionamiento";
            this.Pnl_Servicios_Estacionamiento.Size = new System.Drawing.Size(741, 179);
            this.Pnl_Servicios_Estacionamiento.TabIndex = 0;
            // 
            // Txt_Codigo_Barras
            // 
            this.Txt_Codigo_Barras.BackColor = System.Drawing.Color.AliceBlue;
            this.Txt_Codigo_Barras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Codigo_Barras.CausesValidation = false;
            this.Txt_Codigo_Barras.Font = new System.Drawing.Font("Consolas", 40F);
            this.Txt_Codigo_Barras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Txt_Codigo_Barras.Location = new System.Drawing.Point(12, 227);
            this.Txt_Codigo_Barras.Name = "Txt_Codigo_Barras";
            this.Txt_Codigo_Barras.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Codigo_Barras.Size = new System.Drawing.Size(754, 70);
            this.Txt_Codigo_Barras.TabIndex = 1;
            this.Txt_Codigo_Barras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Codigo_Barras.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_Codigo_Barras_KeyUp);
            // 
            // Lbl_Cont_Carros
            // 
            this.Lbl_Cont_Carros.AutoSize = true;
            this.Lbl_Cont_Carros.Font = new System.Drawing.Font("Consolas", 18F);
            this.Lbl_Cont_Carros.Location = new System.Drawing.Point(766, 9);
            this.Lbl_Cont_Carros.Name = "Lbl_Cont_Carros";
            this.Lbl_Cont_Carros.Size = new System.Drawing.Size(90, 28);
            this.Lbl_Cont_Carros.TabIndex = 2;
            this.Lbl_Cont_Carros.Text = "Carros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F);
            this.label1.Location = new System.Drawing.Point(766, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Camionetas";
            // 
            // Txt_Carros
            // 
            this.Txt_Carros.Enabled = false;
            this.Txt_Carros.Font = new System.Drawing.Font("Consolas", 18F);
            this.Txt_Carros.Location = new System.Drawing.Point(771, 40);
            this.Txt_Carros.Name = "Txt_Carros";
            this.Txt_Carros.Size = new System.Drawing.Size(137, 36);
            this.Txt_Carros.TabIndex = 4;
            this.Txt_Carros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Txt_Camionetas
            // 
            this.Txt_Camionetas.Enabled = false;
            this.Txt_Camionetas.Font = new System.Drawing.Font("Consolas", 18F);
            this.Txt_Camionetas.Location = new System.Drawing.Point(771, 120);
            this.Txt_Camionetas.Name = "Txt_Camionetas";
            this.Txt_Camionetas.Size = new System.Drawing.Size(137, 36);
            this.Txt_Camionetas.TabIndex = 5;
            this.Txt_Camionetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Frm_Ope_Estacionamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(918, 301);
            this.Controls.Add(this.Txt_Camionetas);
            this.Controls.Add(this.Txt_Carros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Cont_Carros);
            this.Controls.Add(this.Txt_Codigo_Barras);
            this.Controls.Add(this.Pnl_Tipo_Acceso);
            this.Name = "Frm_Ope_Estacionamiento";
            this.Text = "Impresion y Cobro Estacionamiento";
            this.Load += new System.EventHandler(this.Frm_Ope_Estacionamiento_Load);
            this.Pnl_Tipo_Acceso.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Pnl_Tipo_Acceso;
        private System.Windows.Forms.TextBox Txt_Codigo_Barras;
        private System.Windows.Forms.FlowLayoutPanel Pnl_Servicios_Estacionamiento;
        private System.Windows.Forms.Label Lbl_Cont_Carros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Carros;
        private System.Windows.Forms.TextBox Txt_Camionetas;
    }
}