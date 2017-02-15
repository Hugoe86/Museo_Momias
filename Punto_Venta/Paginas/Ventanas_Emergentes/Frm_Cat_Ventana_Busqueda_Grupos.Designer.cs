using ERP_BASE.App_Code.Controles;
namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    partial class Frm_Cat_Ventana_Busqueda_Grupos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_Fecha_Fin = new System.Windows.Forms.Label();
            this.Lbl_Fecha_Inicio = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Fin = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Fecha_Inicio = new System.Windows.Forms.DateTimePicker();
            this.Txt_Empresa = new System.Windows.Forms.TextBox();
            this.Lbl_Empresa = new System.Windows.Forms.Label();
            this.Txt_Persona_Tramita = new System.Windows.Forms.TextBox();
            this.Lbl_Persona_Tramita = new System.Windows.Forms.Label();
            this.Pnl_Listado_Grupos = new System.Windows.Forms.GroupBox();
            this.Grid_Grupos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.Pnl_Listado_Grupos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Grupos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Lbl_Fecha_Fin);
            this.groupBox1.Controls.Add(this.Lbl_Fecha_Inicio);
            this.groupBox1.Controls.Add(this.Dtp_Fecha_Fin);
            this.groupBox1.Controls.Add(this.Dtp_Fecha_Inicio);
            this.groupBox1.Controls.Add(this.Txt_Empresa);
            this.groupBox1.Controls.Add(this.Lbl_Empresa);
            this.groupBox1.Controls.Add(this.Txt_Persona_Tramita);
            this.groupBox1.Controls.Add(this.Lbl_Persona_Tramita);
            this.groupBox1.Location = new System.Drawing.Point(12, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros Búsqueda";
            // 
            // Lbl_Fecha_Fin
            // 
            this.Lbl_Fecha_Fin.AutoSize = true;
            this.Lbl_Fecha_Fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Lbl_Fecha_Fin.Location = new System.Drawing.Point(274, 77);
            this.Lbl_Fecha_Fin.Name = "Lbl_Fecha_Fin";
            this.Lbl_Fecha_Fin.Size = new System.Drawing.Size(78, 13);
            this.Lbl_Fecha_Fin.TabIndex = 7;
            this.Lbl_Fecha_Fin.Text = "Fecha Termino";
            // 
            // Lbl_Fecha_Inicio
            // 
            this.Lbl_Fecha_Inicio.AutoSize = true;
            this.Lbl_Fecha_Inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Lbl_Fecha_Inicio.Location = new System.Drawing.Point(7, 77);
            this.Lbl_Fecha_Inicio.Name = "Lbl_Fecha_Inicio";
            this.Lbl_Fecha_Inicio.Size = new System.Drawing.Size(65, 13);
            this.Lbl_Fecha_Inicio.TabIndex = 6;
            this.Lbl_Fecha_Inicio.Text = "Fecha Inicio";
            // 
            // Dtp_Fecha_Fin
            // 
            this.Dtp_Fecha_Fin.CustomFormat = "dd MMM yyyy";
            this.Dtp_Fecha_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Fin.Location = new System.Drawing.Point(358, 77);
            this.Dtp_Fecha_Fin.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.Dtp_Fecha_Fin.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.Dtp_Fecha_Fin.Name = "Dtp_Fecha_Fin";
            this.Dtp_Fecha_Fin.Size = new System.Drawing.Size(161, 20);
            this.Dtp_Fecha_Fin.TabIndex = 5;
            // 
            // Dtp_Fecha_Inicio
            // 
            this.Dtp_Fecha_Inicio.CustomFormat = "dd MMM yyyy";
            this.Dtp_Fecha_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Inicio.Location = new System.Drawing.Point(97, 77);
            this.Dtp_Fecha_Inicio.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.Dtp_Fecha_Inicio.MinDate = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.Dtp_Fecha_Inicio.Name = "Dtp_Fecha_Inicio";
            this.Dtp_Fecha_Inicio.Size = new System.Drawing.Size(171, 20);
            this.Dtp_Fecha_Inicio.TabIndex = 4;
            // 
            // Txt_Empresa
            // 
            this.Txt_Empresa.Location = new System.Drawing.Point(97, 50);
            this.Txt_Empresa.MaxLength = 100;
            this.Txt_Empresa.Name = "Txt_Empresa";
            this.Txt_Empresa.Size = new System.Drawing.Size(422, 20);
            this.Txt_Empresa.TabIndex = 3;
            // 
            // Lbl_Empresa
            // 
            this.Lbl_Empresa.AutoSize = true;
            this.Lbl_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Lbl_Empresa.Location = new System.Drawing.Point(7, 53);
            this.Lbl_Empresa.Name = "Lbl_Empresa";
            this.Lbl_Empresa.Size = new System.Drawing.Size(48, 13);
            this.Lbl_Empresa.TabIndex = 2;
            this.Lbl_Empresa.Text = "Empresa";
            // 
            // Txt_Persona_Tramita
            // 
            this.Txt_Persona_Tramita.Location = new System.Drawing.Point(97, 25);
            this.Txt_Persona_Tramita.MaxLength = 100;
            this.Txt_Persona_Tramita.Name = "Txt_Persona_Tramita";
            this.Txt_Persona_Tramita.Size = new System.Drawing.Size(422, 20);
            this.Txt_Persona_Tramita.TabIndex = 1;
            // 
            // Lbl_Persona_Tramita
            // 
            this.Lbl_Persona_Tramita.AutoSize = true;
            this.Lbl_Persona_Tramita.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Lbl_Persona_Tramita.Location = new System.Drawing.Point(6, 25);
            this.Lbl_Persona_Tramita.Name = "Lbl_Persona_Tramita";
            this.Lbl_Persona_Tramita.Size = new System.Drawing.Size(84, 13);
            this.Lbl_Persona_Tramita.TabIndex = 0;
            this.Lbl_Persona_Tramita.Text = "Persona Tramita";
            // 
            // Pnl_Listado_Grupos
            // 
            this.Pnl_Listado_Grupos.Controls.Add(this.Grid_Grupos);
            this.Pnl_Listado_Grupos.Location = new System.Drawing.Point(12, 121);
            this.Pnl_Listado_Grupos.Name = "Pnl_Listado_Grupos";
            this.Pnl_Listado_Grupos.Size = new System.Drawing.Size(525, 231);
            this.Pnl_Listado_Grupos.TabIndex = 1;
            this.Pnl_Listado_Grupos.TabStop = false;
            this.Pnl_Listado_Grupos.Text = "Resultados Búsqueda";
            // 
            // Grid_Grupos
            // 
            this.Grid_Grupos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Grid_Grupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Grupos.Location = new System.Drawing.Point(6, 19);
            this.Grid_Grupos.Name = "Grid_Grupos";
            this.Grid_Grupos.Size = new System.Drawing.Size(513, 206);
            this.Grid_Grupos.TabIndex = 0;
            // 
            // Frm_Cat_Ventana_Busqueda_Grupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(549, 387);
            this.Controls.Add(this.Pnl_Listado_Grupos);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Cat_Ventana_Busqueda_Grupos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Grupos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Cat_Ventana_Busqueda_Grupos_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Pnl_Listado_Grupos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Grupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_Fecha_Fin;
        private System.Windows.Forms.Label Lbl_Fecha_Inicio;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Fin;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Inicio;
        private System.Windows.Forms.TextBox Txt_Empresa;
        private System.Windows.Forms.Label Lbl_Empresa;
        private System.Windows.Forms.TextBox Txt_Persona_Tramita;
        private System.Windows.Forms.Label Lbl_Persona_Tramita;
        private System.Windows.Forms.GroupBox Pnl_Listado_Grupos;
        private System.Windows.Forms.DataGridView Grid_Grupos;
    }
}