namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Accesos_Camara
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_Migrar_Accesos_Camara = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Grd_Resultados = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha_Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dte_Fecha = new System.Windows.Forms.DateTimePicker();
            this.Chk_Capturar_Informacion = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultados)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Migrar_Accesos_Camara
            // 
            this.Btn_Migrar_Accesos_Camara.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Migrar_Accesos_Camara.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Migrar_Accesos_Camara.Location = new System.Drawing.Point(3, 4);
            this.Btn_Migrar_Accesos_Camara.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Btn_Migrar_Accesos_Camara.Name = "Btn_Migrar_Accesos_Camara";
            this.Btn_Migrar_Accesos_Camara.Size = new System.Drawing.Size(193, 30);
            this.Btn_Migrar_Accesos_Camara.TabIndex = 0;
            this.Btn_Migrar_Accesos_Camara.Text = "Consultar Información Cámara";
            this.Btn_Migrar_Accesos_Camara.UseVisualStyleBackColor = true;
            this.Btn_Migrar_Accesos_Camara.Click += new System.EventHandler(this.Btn_Migrar_Accesos_Camara_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_Migrar_Accesos_Camara, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Grd_Resultados, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Dte_Fecha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Chk_Capturar_Informacion, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(499, 384);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // Grd_Resultados
            // 
            this.Grd_Resultados.AllowUserToAddRows = false;
            this.Grd_Resultados.AllowUserToDeleteRows = false;
            this.Grd_Resultados.AllowUserToResizeRows = false;
            this.Grd_Resultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grd_Resultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grd_Resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grd_Resultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Fecha_Hora,
            this.Cantidad,
            this.salida});
            this.tableLayoutPanel1.SetColumnSpan(this.Grd_Resultados, 2);
            this.Grd_Resultados.Location = new System.Drawing.Point(3, 67);
            this.Grd_Resultados.Name = "Grd_Resultados";
            this.Grd_Resultados.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grd_Resultados.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Grd_Resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grd_Resultados.Size = new System.Drawing.Size(493, 314);
            this.Grd_Resultados.TabIndex = 7;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Camara";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 67;
            // 
            // Fecha_Hora
            // 
            this.Fecha_Hora.DataPropertyName = "Fecha_Hora";
            this.Fecha_Hora.HeaderText = "Fecha";
            this.Fecha_Hora.Name = "Fecha_Hora";
            this.Fecha_Hora.ReadOnly = true;
            this.Fecha_Hora.Width = 59;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Entrada";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 65;
            // 
            // salida
            // 
            this.salida.DataPropertyName = "salida";
            this.salida.HeaderText = "Salida";
            this.salida.Name = "salida";
            this.salida.ReadOnly = true;
            this.salida.Width = 59;
            // 
            // Dte_Fecha
            // 
            this.Dte_Fecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dte_Fecha.Location = new System.Drawing.Point(202, 3);
            this.Dte_Fecha.Name = "Dte_Fecha";
            this.Dte_Fecha.Size = new System.Drawing.Size(294, 21);
            this.Dte_Fecha.TabIndex = 8;
            // 
            // Chk_Capturar_Informacion
            // 
            this.Chk_Capturar_Informacion.AutoSize = true;
            this.Chk_Capturar_Informacion.Location = new System.Drawing.Point(202, 41);
            this.Chk_Capturar_Informacion.Name = "Chk_Capturar_Informacion";
            this.Chk_Capturar_Informacion.Size = new System.Drawing.Size(155, 20);
            this.Chk_Capturar_Informacion.TabIndex = 9;
            this.Chk_Capturar_Informacion.Text = "Capturar información pendiente";
            this.Chk_Capturar_Informacion.UseVisualStyleBackColor = true;
            // 
            // Frm_Cat_Accesos_Camara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 455);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Cat_Accesos_Camara";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camaras";
            this.Load += new System.EventHandler(this.Frm_Cat_Accesos_Camara_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grd_Resultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Migrar_Accesos_Camara;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView Grd_Resultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha_Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn salida;
        private System.Windows.Forms.DateTimePicker Dte_Fecha;
        private System.Windows.Forms.CheckBox Chk_Capturar_Informacion;
    }
}