namespace ERP_BASE.Paginas.Operacion
{
    partial class Frm_Ope_Retiros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.Dtp_Hora = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Hora = new System.Windows.Forms.Label();
            this.Dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Fecha = new System.Windows.Forms.Label();
            this.Cmb_Caja = new System.Windows.Forms.ComboBox();
            this.Lbl_No_Caja = new System.Windows.Forms.Label();
            this.Txt_No_Retiro = new System.Windows.Forms.TextBox();
            this.Lbl_No_Retiro = new System.Windows.Forms.Label();
            this.Txt_Cantidad = new System.Windows.Forms.TextBox();
            this.Lbl_Motivo = new System.Windows.Forms.Label();
            this.Txt_Motivo = new System.Windows.Forms.TextBox();
            this.Pnl_Datos_Retiro = new System.Windows.Forms.GroupBox();
            this.Lbl_Disponible = new System.Windows.Forms.Label();
            this.Txt_Disponible_Caja = new System.Windows.Forms.TextBox();
            this.Pnl_Lista_Retiros = new System.Windows.Forms.GroupBox();
            this.Grid_Retiros = new System.Windows.Forms.DataGridView();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Pnl_Datos_Retiro.SuspendLayout();
            this.Pnl_Lista_Retiros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Retiros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.AutoSize = true;
            this.Lbl_Cantidad.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Lbl_Cantidad.Location = new System.Drawing.Point(4, 85);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(72, 17);
            this.Lbl_Cantidad.TabIndex = 8;
            this.Lbl_Cantidad.Text = "*Cantidad";
            // 
            // Dtp_Hora
            // 
            this.Dtp_Hora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtp_Hora.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Dtp_Hora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.Dtp_Hora.Location = new System.Drawing.Point(378, 50);
            this.Dtp_Hora.Name = "Dtp_Hora";
            this.Dtp_Hora.ShowUpDown = true;
            this.Dtp_Hora.Size = new System.Drawing.Size(199, 24);
            this.Dtp_Hora.TabIndex = 7;
            // 
            // Lbl_Hora
            // 
            this.Lbl_Hora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Hora.AutoSize = true;
            this.Lbl_Hora.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Lbl_Hora.Location = new System.Drawing.Point(296, 51);
            this.Lbl_Hora.Name = "Lbl_Hora";
            this.Lbl_Hora.Size = new System.Drawing.Size(45, 17);
            this.Lbl_Hora.TabIndex = 6;
            this.Lbl_Hora.Text = "*Hora";
            // 
            // Dtp_Fecha
            // 
            this.Dtp_Fecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dtp_Fecha.CustomFormat = "dd MMM yyyy";
            this.Dtp_Fecha.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha.Location = new System.Drawing.Point(81, 50);
            this.Dtp_Fecha.Name = "Dtp_Fecha";
            this.Dtp_Fecha.Size = new System.Drawing.Size(207, 24);
            this.Dtp_Fecha.TabIndex = 5;
            // 
            // Lbl_Fecha
            // 
            this.Lbl_Fecha.AutoSize = true;
            this.Lbl_Fecha.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Lbl_Fecha.Location = new System.Drawing.Point(9, 51);
            this.Lbl_Fecha.Name = "Lbl_Fecha";
            this.Lbl_Fecha.Size = new System.Drawing.Size(55, 17);
            this.Lbl_Fecha.TabIndex = 4;
            this.Lbl_Fecha.Text = "*Fecha";
            // 
            // Cmb_Caja
            // 
            this.Cmb_Caja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Caja.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Cmb_Caja.FormattingEnabled = true;
            this.Cmb_Caja.Location = new System.Drawing.Point(378, 20);
            this.Cmb_Caja.Name = "Cmb_Caja";
            this.Cmb_Caja.Size = new System.Drawing.Size(199, 25);
            this.Cmb_Caja.TabIndex = 3;
            this.Cmb_Caja.SelectedIndexChanged += new System.EventHandler(this.Cmb_Caja_SelectedIndexChanged);
            // 
            // Lbl_No_Caja
            // 
            this.Lbl_No_Caja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_No_Caja.AutoSize = true;
            this.Lbl_No_Caja.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Lbl_No_Caja.Location = new System.Drawing.Point(296, 23);
            this.Lbl_No_Caja.Name = "Lbl_No_Caja";
            this.Lbl_No_Caja.Size = new System.Drawing.Size(66, 17);
            this.Lbl_No_Caja.TabIndex = 2;
            this.Lbl_No_Caja.Text = "*No Caja";
            // 
            // Txt_No_Retiro
            // 
            this.Txt_No_Retiro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_No_Retiro.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Txt_No_Retiro.Location = new System.Drawing.Point(82, 20);
            this.Txt_No_Retiro.Name = "Txt_No_Retiro";
            this.Txt_No_Retiro.Size = new System.Drawing.Size(207, 24);
            this.Txt_No_Retiro.TabIndex = 1;
            // 
            // Lbl_No_Retiro
            // 
            this.Lbl_No_Retiro.AutoSize = true;
            this.Lbl_No_Retiro.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Lbl_No_Retiro.Location = new System.Drawing.Point(9, 23);
            this.Lbl_No_Retiro.Name = "Lbl_No_Retiro";
            this.Lbl_No_Retiro.Size = new System.Drawing.Size(69, 17);
            this.Lbl_No_Retiro.TabIndex = 0;
            this.Lbl_No_Retiro.Text = "No Retiro";
            // 
            // Txt_Cantidad
            // 
            this.Txt_Cantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Cantidad.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Txt_Cantidad.Location = new System.Drawing.Point(82, 82);
            this.Txt_Cantidad.Name = "Txt_Cantidad";
            this.Txt_Cantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Cantidad.Size = new System.Drawing.Size(207, 24);
            this.Txt_Cantidad.TabIndex = 9;
            this.Txt_Cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Cantidad_KeyPress);
            this.Txt_Cantidad.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Cantidad_Validating);
            // 
            // Lbl_Motivo
            // 
            this.Lbl_Motivo.AutoSize = true;
            this.Lbl_Motivo.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Lbl_Motivo.Location = new System.Drawing.Point(9, 114);
            this.Lbl_Motivo.Name = "Lbl_Motivo";
            this.Lbl_Motivo.Size = new System.Drawing.Size(55, 17);
            this.Lbl_Motivo.TabIndex = 10;
            this.Lbl_Motivo.Text = "*Motivo";
            // 
            // Txt_Motivo
            // 
            this.Txt_Motivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Motivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.879137F);
            this.Txt_Motivo.Location = new System.Drawing.Point(82, 114);
            this.Txt_Motivo.Multiline = true;
            this.Txt_Motivo.Name = "Txt_Motivo";
            this.Txt_Motivo.Size = new System.Drawing.Size(496, 83);
            this.Txt_Motivo.TabIndex = 11;
            this.Txt_Motivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Motivo_KeyPress);
            this.Txt_Motivo.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Motivo_Validating);
            // 
            // Pnl_Datos_Retiro
            // 
            this.Pnl_Datos_Retiro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pnl_Datos_Retiro.Controls.Add(this.Lbl_Disponible);
            this.Pnl_Datos_Retiro.Controls.Add(this.Txt_Disponible_Caja);
            this.Pnl_Datos_Retiro.Controls.Add(this.Txt_Motivo);
            this.Pnl_Datos_Retiro.Controls.Add(this.Lbl_Motivo);
            this.Pnl_Datos_Retiro.Controls.Add(this.Lbl_No_Retiro);
            this.Pnl_Datos_Retiro.Controls.Add(this.Txt_Cantidad);
            this.Pnl_Datos_Retiro.Controls.Add(this.Txt_No_Retiro);
            this.Pnl_Datos_Retiro.Controls.Add(this.Lbl_Cantidad);
            this.Pnl_Datos_Retiro.Controls.Add(this.Lbl_No_Caja);
            this.Pnl_Datos_Retiro.Controls.Add(this.Dtp_Hora);
            this.Pnl_Datos_Retiro.Controls.Add(this.Cmb_Caja);
            this.Pnl_Datos_Retiro.Controls.Add(this.Lbl_Hora);
            this.Pnl_Datos_Retiro.Controls.Add(this.Lbl_Fecha);
            this.Pnl_Datos_Retiro.Controls.Add(this.Dtp_Fecha);
            this.Pnl_Datos_Retiro.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Pnl_Datos_Retiro.Location = new System.Drawing.Point(14, 11);
            this.Pnl_Datos_Retiro.Name = "Pnl_Datos_Retiro";
            this.Pnl_Datos_Retiro.Size = new System.Drawing.Size(585, 214);
            this.Pnl_Datos_Retiro.TabIndex = 1;
            this.Pnl_Datos_Retiro.TabStop = false;
            this.Pnl_Datos_Retiro.Text = "Retiros";
            // 
            // Lbl_Disponible
            // 
            this.Lbl_Disponible.AutoSize = true;
            this.Lbl_Disponible.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Lbl_Disponible.Location = new System.Drawing.Point(296, 85);
            this.Lbl_Disponible.Name = "Lbl_Disponible";
            this.Lbl_Disponible.Size = new System.Drawing.Size(76, 17);
            this.Lbl_Disponible.TabIndex = 13;
            this.Lbl_Disponible.Text = "Disponible";
            this.Lbl_Disponible.Visible = false;
            // 
            // Txt_Disponible_Caja
            // 
            this.Txt_Disponible_Caja.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Disponible_Caja.Enabled = false;
            this.Txt_Disponible_Caja.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Txt_Disponible_Caja.Location = new System.Drawing.Point(378, 80);
            this.Txt_Disponible_Caja.Name = "Txt_Disponible_Caja";
            this.Txt_Disponible_Caja.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Disponible_Caja.Size = new System.Drawing.Size(199, 24);
            this.Txt_Disponible_Caja.TabIndex = 12;
            this.Txt_Disponible_Caja.Visible = false;
            // 
            // Pnl_Lista_Retiros
            // 
            this.Pnl_Lista_Retiros.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pnl_Lista_Retiros.Controls.Add(this.Grid_Retiros);
            this.Pnl_Lista_Retiros.Font = new System.Drawing.Font("Arial", 10.99615F);
            this.Pnl_Lista_Retiros.Location = new System.Drawing.Point(14, 230);
            this.Pnl_Lista_Retiros.Name = "Pnl_Lista_Retiros";
            this.Pnl_Lista_Retiros.Size = new System.Drawing.Size(585, 256);
            this.Pnl_Lista_Retiros.TabIndex = 2;
            this.Pnl_Lista_Retiros.TabStop = false;
            this.Pnl_Lista_Retiros.Text = "Lista de Retiros";
            // 
            // Grid_Retiros
            // 
            this.Grid_Retiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Grid_Retiros.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Retiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Retiros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.879137F);
            this.Grid_Retiros.Location = new System.Drawing.Point(7, 20);
            this.Grid_Retiros.Name = "Grid_Retiros";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Retiros.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Retiros.Size = new System.Drawing.Size(571, 222);
            this.Grid_Retiros.TabIndex = 0;
            this.Grid_Retiros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Retiros_CellClick);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 7.533813F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.Location = new System.Drawing.Point(409, 496);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(99, 49);
            this.Btn_Salir.TabIndex = 14;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 7.533813F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.Location = new System.Drawing.Point(305, 495);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(99, 49);
            this.Btn_Eliminar.TabIndex = 13;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 7.533813F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.Location = new System.Drawing.Point(201, 496);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(99, 49);
            this.Btn_Modificar.TabIndex = 11;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 7.533813F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.Location = new System.Drawing.Point(97, 496);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(99, 49);
            this.Btn_Nuevo.TabIndex = 10;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            this.Erp_Validaciones.RightToLeft = true;
            // 
            // Frm_Ope_Retiros
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(613, 558);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Pnl_Lista_Retiros);
            this.Controls.Add(this.Pnl_Datos_Retiro);
            this.Name = "Frm_Ope_Retiros";
            this.Text = "Retiros";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Ope_Retiros_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Ope_Retiros_Load);
            this.Pnl_Datos_Retiro.ResumeLayout(false);
            this.Pnl_Datos_Retiro.PerformLayout();
            this.Pnl_Lista_Retiros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Retiros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.ResumeLayout(false);

        }
        
        #endregion

        private System.Windows.Forms.Label Lbl_No_Retiro;
        private System.Windows.Forms.TextBox Txt_No_Retiro;
        private System.Windows.Forms.ComboBox Cmb_Caja;
        private System.Windows.Forms.Label Lbl_No_Caja;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha;
        private System.Windows.Forms.Label Lbl_Fecha;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.DateTimePicker Dtp_Hora;
        private System.Windows.Forms.Label Lbl_Hora;
        private System.Windows.Forms.TextBox Txt_Cantidad;
        private System.Windows.Forms.Label Lbl_Motivo;
        private System.Windows.Forms.TextBox Txt_Motivo;
        private System.Windows.Forms.GroupBox Pnl_Datos_Retiro;
        private System.Windows.Forms.GroupBox Pnl_Lista_Retiros;
        private System.Windows.Forms.DataGridView Grid_Retiros;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.Label Lbl_Disponible;
        private System.Windows.Forms.TextBox Txt_Disponible_Caja;
    }
}