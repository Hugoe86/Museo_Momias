namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    partial class Frm_Cat_Ventana_Emergente_Motivos_Descuento
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Ventana_Emergente_Motivos_Descuento));
            this.Fra_Autenticacion = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Txt_Contrasenia = new System.Windows.Forms.TextBox();
            this.Btn_Aceptar = new System.Windows.Forms.Button();
            this.Txt_Usuario = new System.Windows.Forms.TextBox();
            this.Lbl_Contrasenia = new System.Windows.Forms.Label();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Fra_Descuento = new System.Windows.Forms.GroupBox();
            this.Txt_Documento_Oficial = new System.Windows.Forms.TextBox();
            this.Lbl_Documento_Oficial = new System.Windows.Forms.Label();
            this.Txt_Monto_A_Pagar = new System.Windows.Forms.TextBox();
            this.Lbl_Monto_A_Pagar = new System.Windows.Forms.Label();
            this.Txt_Descuento = new System.Windows.Forms.TextBox();
            this.Lbl_Monto_Descontar = new System.Windows.Forms.Label();
            this.Txt_Porcentaje_Descuento = new System.Windows.Forms.TextBox();
            this.Lbl_Descuento = new System.Windows.Forms.Label();
            this.Txt_Monto_Inicial = new System.Windows.Forms.TextBox();
            this.Lbl_Monto = new System.Windows.Forms.Label();
            this.Erp_Descuentos = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Autenticacion.SuspendLayout();
            this.Fra_Descuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Descuentos)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Autenticacion
            // 
            this.Fra_Autenticacion.Controls.Add(this.Btn_Regresar);
            this.Fra_Autenticacion.Controls.Add(this.Txt_Contrasenia);
            this.Fra_Autenticacion.Controls.Add(this.Btn_Aceptar);
            this.Fra_Autenticacion.Controls.Add(this.Txt_Usuario);
            this.Fra_Autenticacion.Controls.Add(this.Lbl_Contrasenia);
            this.Fra_Autenticacion.Controls.Add(this.Lbl_Usuario);
            this.Fra_Autenticacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Fra_Autenticacion.Location = new System.Drawing.Point(21, 263);
            this.Fra_Autenticacion.Name = "Fra_Autenticacion";
            this.Fra_Autenticacion.Size = new System.Drawing.Size(560, 119);
            this.Fra_Autenticacion.TabIndex = 0;
            this.Fra_Autenticacion.TabStop = false;
            this.Fra_Autenticacion.Text = "Autenticación";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Btn_Regresar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Regresar.Image")));
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Regresar.Location = new System.Drawing.Point(449, 62);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(105, 52);
            this.Btn_Regresar.TabIndex = 9;
            this.Btn_Regresar.Text = "Cerrar";
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Txt_Contrasenia
            // 
            this.Txt_Contrasenia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Txt_Contrasenia.Enabled = false;
            this.Txt_Contrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Txt_Contrasenia.Location = new System.Drawing.Point(156, 61);
            this.Txt_Contrasenia.Multiline = true;
            this.Txt_Contrasenia.Name = "Txt_Contrasenia";
            this.Txt_Contrasenia.PasswordChar = '*';
            this.Txt_Contrasenia.Size = new System.Drawing.Size(287, 47);
            this.Txt_Contrasenia.TabIndex = 7;
            this.Txt_Contrasenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Btn_Aceptar
            // 
            this.Btn_Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Btn_Aceptar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Aceptar.Image")));
            this.Btn_Aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Aceptar.Location = new System.Drawing.Point(449, 10);
            this.Btn_Aceptar.Name = "Btn_Aceptar";
            this.Btn_Aceptar.Size = new System.Drawing.Size(105, 52);
            this.Btn_Aceptar.TabIndex = 8;
            this.Btn_Aceptar.Text = "Aceptar";
            this.Btn_Aceptar.UseVisualStyleBackColor = true;
            this.Btn_Aceptar.Click += new System.EventHandler(this.Btn_Aceptar_Click);
            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Txt_Usuario.Enabled = false;
            this.Txt_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Txt_Usuario.Location = new System.Drawing.Point(156, 14);
            this.Txt_Usuario.Multiline = true;
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(287, 47);
            this.Txt_Usuario.TabIndex = 6;
            this.Txt_Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_Contrasenia
            // 
            this.Lbl_Contrasenia.AutoSize = true;
            this.Lbl_Contrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Contrasenia.Location = new System.Drawing.Point(6, 74);
            this.Lbl_Contrasenia.Name = "Lbl_Contrasenia";
            this.Lbl_Contrasenia.Size = new System.Drawing.Size(81, 17);
            this.Lbl_Contrasenia.TabIndex = 11;
            this.Lbl_Contrasenia.Text = "Contraseña";
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Usuario.Location = new System.Drawing.Point(6, 28);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(57, 17);
            this.Lbl_Usuario.TabIndex = 10;
            this.Lbl_Usuario.Text = "Usuario";
            // 
            // Fra_Descuento
            // 
            this.Fra_Descuento.Controls.Add(this.Txt_Documento_Oficial);
            this.Fra_Descuento.Controls.Add(this.Lbl_Documento_Oficial);
            this.Fra_Descuento.Controls.Add(this.Txt_Monto_A_Pagar);
            this.Fra_Descuento.Controls.Add(this.Lbl_Monto_A_Pagar);
            this.Fra_Descuento.Controls.Add(this.Txt_Descuento);
            this.Fra_Descuento.Controls.Add(this.Lbl_Monto_Descontar);
            this.Fra_Descuento.Controls.Add(this.Txt_Porcentaje_Descuento);
            this.Fra_Descuento.Controls.Add(this.Lbl_Descuento);
            this.Fra_Descuento.Controls.Add(this.Txt_Monto_Inicial);
            this.Fra_Descuento.Controls.Add(this.Lbl_Monto);
            this.Fra_Descuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Descuento.Location = new System.Drawing.Point(21, 12);
            this.Fra_Descuento.Name = "Fra_Descuento";
            this.Fra_Descuento.Size = new System.Drawing.Size(551, 235);
            this.Fra_Descuento.TabIndex = 1;
            this.Fra_Descuento.TabStop = false;
            this.Fra_Descuento.Text = "Descuento";
            // 
            // Txt_Documento_Oficial
            // 
            this.Txt_Documento_Oficial.Location = new System.Drawing.Point(112, 153);
            this.Txt_Documento_Oficial.MaxLength = 250;
            this.Txt_Documento_Oficial.Multiline = true;
            this.Txt_Documento_Oficial.Name = "Txt_Documento_Oficial";
            this.Txt_Documento_Oficial.Size = new System.Drawing.Size(433, 58);
            this.Txt_Documento_Oficial.TabIndex = 5;
            // 
            // Lbl_Documento_Oficial
            // 
            this.Lbl_Documento_Oficial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Documento_Oficial.Location = new System.Drawing.Point(6, 156);
            this.Lbl_Documento_Oficial.Name = "Lbl_Documento_Oficial";
            this.Lbl_Documento_Oficial.Size = new System.Drawing.Size(100, 37);
            this.Lbl_Documento_Oficial.TabIndex = 22;
            this.Lbl_Documento_Oficial.Text = "Documento oficial";
            // 
            // Txt_Monto_A_Pagar
            // 
            this.Txt_Monto_A_Pagar.Enabled = false;
            this.Txt_Monto_A_Pagar.Location = new System.Drawing.Point(112, 124);
            this.Txt_Monto_A_Pagar.Name = "Txt_Monto_A_Pagar";
            this.Txt_Monto_A_Pagar.Size = new System.Drawing.Size(135, 22);
            this.Txt_Monto_A_Pagar.TabIndex = 4;
            this.Txt_Monto_A_Pagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_Monto_A_Pagar
            // 
            this.Lbl_Monto_A_Pagar.AutoSize = true;
            this.Lbl_Monto_A_Pagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Monto_A_Pagar.Location = new System.Drawing.Point(6, 127);
            this.Lbl_Monto_A_Pagar.Name = "Lbl_Monto_A_Pagar";
            this.Lbl_Monto_A_Pagar.Size = new System.Drawing.Size(100, 17);
            this.Lbl_Monto_A_Pagar.TabIndex = 20;
            this.Lbl_Monto_A_Pagar.Text = "Monto a pagar";
            // 
            // Txt_Descuento
            // 
            this.Txt_Descuento.Enabled = false;
            this.Txt_Descuento.Location = new System.Drawing.Point(112, 91);
            this.Txt_Descuento.Name = "Txt_Descuento";
            this.Txt_Descuento.Size = new System.Drawing.Size(135, 22);
            this.Txt_Descuento.TabIndex = 3;
            this.Txt_Descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_Monto_Descontar
            // 
            this.Lbl_Monto_Descontar.AutoSize = true;
            this.Lbl_Monto_Descontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Monto_Descontar.Location = new System.Drawing.Point(6, 94);
            this.Lbl_Monto_Descontar.Name = "Lbl_Monto_Descontar";
            this.Lbl_Monto_Descontar.Size = new System.Drawing.Size(76, 17);
            this.Lbl_Monto_Descontar.TabIndex = 18;
            this.Lbl_Monto_Descontar.Text = "Descuento";
            // 
            // Txt_Porcentaje_Descuento
            // 
            this.Txt_Porcentaje_Descuento.Location = new System.Drawing.Point(112, 58);
            this.Txt_Porcentaje_Descuento.MaxLength = 3;
            this.Txt_Porcentaje_Descuento.Name = "Txt_Porcentaje_Descuento";
            this.Txt_Porcentaje_Descuento.Size = new System.Drawing.Size(135, 22);
            this.Txt_Porcentaje_Descuento.TabIndex = 2;
            this.Txt_Porcentaje_Descuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_Porcentaje_Descuento.TextChanged += new System.EventHandler(this.Txt_Porcentaje_Descuento_TextChanged);
            this.Txt_Porcentaje_Descuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numerico_KeyPress);
            // 
            // Lbl_Descuento
            // 
            this.Lbl_Descuento.AutoSize = true;
            this.Lbl_Descuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Descuento.Location = new System.Drawing.Point(6, 61);
            this.Lbl_Descuento.Name = "Lbl_Descuento";
            this.Lbl_Descuento.Size = new System.Drawing.Size(90, 17);
            this.Lbl_Descuento.TabIndex = 16;
            this.Lbl_Descuento.Text = "% descuento";
            // 
            // Txt_Monto_Inicial
            // 
            this.Txt_Monto_Inicial.Enabled = false;
            this.Txt_Monto_Inicial.Location = new System.Drawing.Point(112, 30);
            this.Txt_Monto_Inicial.Name = "Txt_Monto_Inicial";
            this.Txt_Monto_Inicial.Size = new System.Drawing.Size(135, 22);
            this.Txt_Monto_Inicial.TabIndex = 1;
            this.Txt_Monto_Inicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_Monto
            // 
            this.Lbl_Monto.AutoSize = true;
            this.Lbl_Monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lbl_Monto.Location = new System.Drawing.Point(6, 30);
            this.Lbl_Monto.Name = "Lbl_Monto";
            this.Lbl_Monto.Size = new System.Drawing.Size(47, 17);
            this.Lbl_Monto.TabIndex = 14;
            this.Lbl_Monto.Text = "Monto";
            // 
            // Erp_Descuentos
            // 
            this.Erp_Descuentos.ContainerControl = this;
            // 
            // Frm_Cat_Ventana_Emergente_Motivos_Descuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 394);
            this.ControlBox = false;
            this.Controls.Add(this.Fra_Descuento);
            this.Controls.Add(this.Fra_Autenticacion);
            this.Name = "Frm_Cat_Ventana_Emergente_Motivos_Descuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorizar descuento";
            this.Load += new System.EventHandler(this.Frm_Cat_Ventana_Emergente_Motivos_Descuento_Load);
            this.Fra_Autenticacion.ResumeLayout(false);
            this.Fra_Autenticacion.PerformLayout();
            this.Fra_Descuento.ResumeLayout(false);
            this.Fra_Descuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Descuentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Autenticacion;
        private System.Windows.Forms.TextBox Txt_Contrasenia;
        private System.Windows.Forms.TextBox Txt_Usuario;
        private System.Windows.Forms.Label Lbl_Contrasenia;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.Button Btn_Aceptar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.GroupBox Fra_Descuento;
        private System.Windows.Forms.TextBox Txt_Monto_Inicial;
        private System.Windows.Forms.Label Lbl_Monto;
        private System.Windows.Forms.Label Lbl_Monto_A_Pagar;
        private System.Windows.Forms.TextBox Txt_Descuento;
        private System.Windows.Forms.Label Lbl_Monto_Descontar;
        private System.Windows.Forms.TextBox Txt_Porcentaje_Descuento;
        private System.Windows.Forms.Label Lbl_Descuento;
        private System.Windows.Forms.TextBox Txt_Monto_A_Pagar;
        private System.Windows.Forms.TextBox Txt_Documento_Oficial;
        private System.Windows.Forms.Label Lbl_Documento_Oficial;
        private System.Windows.Forms.ErrorProvider Erp_Descuentos;
    }
}