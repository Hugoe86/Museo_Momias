namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Apl_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Apl_Login));
            this.Lbl_Login = new System.Windows.Forms.Label();
            this.Lbl_Password = new System.Windows.Forms.Label();
            this.Txt_Login = new System.Windows.Forms.TextBox();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Btn_Iniciar = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Erp_Login = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Campos_Login = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Login)).BeginInit();
            this.Fra_Campos_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Login
            // 
            this.Lbl_Login.AutoSize = true;
            this.Lbl_Login.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Login.Location = new System.Drawing.Point(5, 25);
            this.Lbl_Login.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Login.Name = "Lbl_Login";
            this.Lbl_Login.Size = new System.Drawing.Size(42, 14);
            this.Lbl_Login.TabIndex = 0;
            this.Lbl_Login.Text = "*Login";
            // 
            // Lbl_Password
            // 
            this.Lbl_Password.AutoSize = true;
            this.Lbl_Password.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Password.Location = new System.Drawing.Point(5, 56);
            this.Lbl_Password.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Lbl_Password.Name = "Lbl_Password";
            this.Lbl_Password.Size = new System.Drawing.Size(67, 14);
            this.Lbl_Password.TabIndex = 1;
            this.Lbl_Password.Text = "*Password";
            // 
            // Txt_Login
            // 
            this.Txt_Login.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Login.Location = new System.Drawing.Point(74, 21);
            this.Txt_Login.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Txt_Login.Name = "Txt_Login";
            this.Txt_Login.Size = new System.Drawing.Size(300, 21);
            this.Txt_Login.TabIndex = 1;
            this.Txt_Login.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Validating);
            // 
            // Txt_Password
            // 
            this.Txt_Password.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Password.Location = new System.Drawing.Point(74, 54);
            this.Txt_Password.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(300, 21);
            this.Txt_Password.TabIndex = 2;
            this.Txt_Password.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Validating);
            // 
            // Btn_Iniciar
            // 
            this.Btn_Iniciar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Iniciar.Image = global::ERP_BASE.Properties.Resources.icono_iniciar_sesion;
            this.Btn_Iniciar.Location = new System.Drawing.Point(72, 105);
            this.Btn_Iniciar.Name = "Btn_Iniciar";
            this.Btn_Iniciar.Size = new System.Drawing.Size(80, 45);
            this.Btn_Iniciar.TabIndex = 3;
            this.Btn_Iniciar.Text = "Iniciar";
            this.Btn_Iniciar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Iniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Iniciar.UseVisualStyleBackColor = true;
            this.Btn_Iniciar.Click += new System.EventHandler(this.Btn_Iniciar_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.Location = new System.Drawing.Point(221, 105);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(80, 45);
            this.Btn_Salir.TabIndex = 4;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Erp_Login
            // 
            this.Erp_Login.ContainerControl = this;
            // 
            // Fra_Campos_Login
            // 
            this.Fra_Campos_Login.Controls.Add(this.Txt_Password);
            this.Fra_Campos_Login.Controls.Add(this.Txt_Login);
            this.Fra_Campos_Login.Controls.Add(this.Lbl_Login);
            this.Fra_Campos_Login.Controls.Add(this.Lbl_Password);
            this.Fra_Campos_Login.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Campos_Login.Location = new System.Drawing.Point(6, 6);
            this.Fra_Campos_Login.Name = "Fra_Campos_Login";
            this.Fra_Campos_Login.Size = new System.Drawing.Size(379, 93);
            this.Fra_Campos_Login.TabIndex = 5;
            this.Fra_Campos_Login.TabStop = false;
            this.Fra_Campos_Login.Text = "Login";
            // 
            // Frm_Apl_Login
            // 
            this.AcceptButton = this.Btn_Iniciar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.Btn_Salir;
            this.ClientSize = new System.Drawing.Size(391, 163);
            this.Controls.Add(this.Fra_Campos_Login);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Iniciar);
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Apl_Login";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.Load += new System.EventHandler(this.Frm_Apl_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Login)).EndInit();
            this.Fra_Campos_Login.ResumeLayout(false);
            this.Fra_Campos_Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Login;
        private System.Windows.Forms.Label Lbl_Password;
        private System.Windows.Forms.Button Btn_Iniciar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.TextBox Txt_Login;
        private System.Windows.Forms.ErrorProvider Erp_Login;
        private System.Windows.Forms.GroupBox Fra_Campos_Login;
    }
}