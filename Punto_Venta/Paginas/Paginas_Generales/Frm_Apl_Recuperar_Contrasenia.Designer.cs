namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Apl_Recuperar_Contrasenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Apl_Recuperar_Contrasenia));
            this.Lbl_Email = new System.Windows.Forms.Label();
            this.Txt_Correo = new System.Windows.Forms.TextBox();
            this.Btn_Enviar = new System.Windows.Forms.Button();
            this.Lbl_Usuario = new System.Windows.Forms.Label();
            this.Txt_Usuario = new System.Windows.Forms.TextBox();
            this.Erp_Recuperacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Fra_Recuperar_Contrasenia = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Recuperacion)).BeginInit();
            this.Fra_Recuperar_Contrasenia.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Email
            // 
            this.Lbl_Email.AutoSize = true;
            this.Lbl_Email.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Email.Location = new System.Drawing.Point(1, 63);
            this.Lbl_Email.Name = "Lbl_Email";
            this.Lbl_Email.Size = new System.Drawing.Size(50, 14);
            this.Lbl_Email.TabIndex = 3;
            this.Lbl_Email.Text = "*Correo";
            // 
            // Txt_Correo
            // 
            this.Txt_Correo.Font = new System.Drawing.Font("Arial", 9F);
            this.Txt_Correo.Location = new System.Drawing.Point(61, 63);
            this.Txt_Correo.MaxLength = 50;
            this.Txt_Correo.Name = "Txt_Correo";
            this.Txt_Correo.Size = new System.Drawing.Size(300, 21);
            this.Txt_Correo.TabIndex = 2;
            this.Txt_Correo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Correo_KeyPress);
            this.Txt_Correo.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Correo_Validating);
            // 
            // Btn_Enviar
            // 
            this.Btn_Enviar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Enviar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Enviar.Image = global::ERP_BASE.Properties.Resources.icono_enviar_email;
            this.Btn_Enviar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Enviar.Location = new System.Drawing.Point(67, 127);
            this.Btn_Enviar.Name = "Btn_Enviar";
            this.Btn_Enviar.Size = new System.Drawing.Size(80, 45);
            this.Btn_Enviar.TabIndex = 3;
            this.Btn_Enviar.Text = "Enviar";
            this.Btn_Enviar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Enviar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Enviar.UseVisualStyleBackColor = true;
            this.Btn_Enviar.Click += new System.EventHandler(this.Btn_Enviar_Click);
            // 
            // Lbl_Usuario
            // 
            this.Lbl_Usuario.AutoSize = true;
            this.Lbl_Usuario.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Usuario.Location = new System.Drawing.Point(1, 31);
            this.Lbl_Usuario.Name = "Lbl_Usuario";
            this.Lbl_Usuario.Size = new System.Drawing.Size(53, 14);
            this.Lbl_Usuario.TabIndex = 0;
            this.Lbl_Usuario.Text = "*Usuario";
            // 
            // Txt_Usuario
            // 
            this.Txt_Usuario.Font = new System.Drawing.Font("Arial", 9F);
            this.Txt_Usuario.Location = new System.Drawing.Point(61, 31);
            this.Txt_Usuario.MaxLength = 20;
            this.Txt_Usuario.Name = "Txt_Usuario";
            this.Txt_Usuario.Size = new System.Drawing.Size(300, 21);
            this.Txt_Usuario.TabIndex = 1;
            this.Txt_Usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Usuario_KeyPress);
            this.Txt_Usuario.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Usuario_Validating);
            // 
            // Erp_Recuperacion
            // 
            this.Erp_Recuperacion.ContainerControl = this;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Cancelar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Cancelar.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
            this.Btn_Cancelar.Location = new System.Drawing.Point(236, 127);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(80, 45);
            this.Btn_Cancelar.TabIndex = 4;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Cancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Fra_Recuperar_Contrasenia
            // 
            this.Fra_Recuperar_Contrasenia.Controls.Add(this.Txt_Usuario);
            this.Fra_Recuperar_Contrasenia.Controls.Add(this.Lbl_Usuario);
            this.Fra_Recuperar_Contrasenia.Controls.Add(this.Txt_Correo);
            this.Fra_Recuperar_Contrasenia.Controls.Add(this.Lbl_Email);
            this.Fra_Recuperar_Contrasenia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Recuperar_Contrasenia.Location = new System.Drawing.Point(6, 6);
            this.Fra_Recuperar_Contrasenia.Name = "Fra_Recuperar_Contrasenia";
            this.Fra_Recuperar_Contrasenia.Size = new System.Drawing.Size(372, 109);
            this.Fra_Recuperar_Contrasenia.TabIndex = 7;
            this.Fra_Recuperar_Contrasenia.TabStop = false;
            this.Fra_Recuperar_Contrasenia.Text = "Recuperar contraseña";
            // 
            // Frm_Apl_Recuperar_Contrasenia
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 178);
            this.Controls.Add(this.Fra_Recuperar_Contrasenia);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Enviar);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Apl_Recuperar_Contrasenia";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Recuperacion de Contraseña";
            this.Load += new System.EventHandler(this.Frm_Apl_Recuperar_Contrasenia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Recuperacion)).EndInit();
            this.Fra_Recuperar_Contrasenia.ResumeLayout(false);
            this.Fra_Recuperar_Contrasenia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Email;
        private System.Windows.Forms.TextBox Txt_Correo;
        private System.Windows.Forms.Button Btn_Enviar;
        private System.Windows.Forms.Label Lbl_Usuario;
        private System.Windows.Forms.TextBox Txt_Usuario;
        private System.Windows.Forms.ErrorProvider Erp_Recuperacion;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.GroupBox Fra_Recuperar_Contrasenia;
    }
}