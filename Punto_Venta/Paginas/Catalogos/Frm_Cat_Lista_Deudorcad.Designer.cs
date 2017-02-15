namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Lista_Deudorcad
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
            this.Fra_Listas = new System.Windows.Forms.GroupBox();
            this.Grid_Lista = new System.Windows.Forms.DataGridView();
            this.Lista_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Fra_Datos_Listas = new System.Windows.Forms.GroupBox();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Cmb_Forma_Pago = new System.Windows.Forms.ComboBox();
            this.Lbl_Forma_Pago = new System.Windows.Forms.Label();
            this.Cmb_Operacion = new System.Windows.Forms.ComboBox();
            this.Lbl_Operacion = new System.Windows.Forms.Label();
            this.Txt_Lista = new System.Windows.Forms.TextBox();
            this.Lbl_Lista = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Txt_Lista_Id = new System.Windows.Forms.TextBox();
            this.Lbl_Lista_Id = new System.Windows.Forms.Label();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Listas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Lista)).BeginInit();
            this.Fra_Datos_Listas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // Fra_Listas
            // 
            this.Fra_Listas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Fra_Listas.Controls.Add(this.Grid_Lista);
            this.Fra_Listas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Listas.Location = new System.Drawing.Point(5, 186);
            this.Fra_Listas.Name = "Fra_Listas";
            this.Fra_Listas.Size = new System.Drawing.Size(518, 159);
            this.Fra_Listas.TabIndex = 35;
            this.Fra_Listas.TabStop = false;
            this.Fra_Listas.Text = "Lista";
            // 
            // Grid_Lista
            // 
            this.Grid_Lista.AllowUserToAddRows = false;
            this.Grid_Lista.AllowUserToDeleteRows = false;
            this.Grid_Lista.AllowUserToResizeRows = false;
            this.Grid_Lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Lista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lista_ID,
            this.Nombre,
            this.Lista,
            this.Estatus,
            this.Operacion,
            this.Tipo_Pago});
            this.Grid_Lista.Location = new System.Drawing.Point(10, 20);
            this.Grid_Lista.Name = "Grid_Lista";
            this.Grid_Lista.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Lista.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Lista.Size = new System.Drawing.Size(508, 133);
            this.Grid_Lista.TabIndex = 6;
            this.Grid_Lista.SelectionChanged += new System.EventHandler(this.Grid_Lista_SelectionChanged);
            // 
            // Lista_ID
            // 
            this.Lista_ID.DataPropertyName = "Lista_Id";
            this.Lista_ID.HeaderText = "Lista_id";
            this.Lista_ID.Name = "Lista_ID";
            this.Lista_ID.ReadOnly = true;
            this.Lista_ID.Width = 77;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 77;
            // 
            // Lista
            // 
            this.Lista.DataPropertyName = "Lista";
            this.Lista.HeaderText = "Lista";
            this.Lista.Name = "Lista";
            this.Lista.ReadOnly = true;
            this.Lista.Width = 60;
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.Width = 75;
            // 
            // Operacion
            // 
            this.Operacion.DataPropertyName = "Operacion";
            this.Operacion.HeaderText = "Operacion";
            this.Operacion.Name = "Operacion";
            this.Operacion.ReadOnly = true;
            this.Operacion.Width = 91;
            // 
            // Tipo_Pago
            // 
            this.Tipo_Pago.DataPropertyName = "Tipo_Pago";
            this.Tipo_Pago.HeaderText = "Forma de pago";
            this.Tipo_Pago.Name = "Tipo_Pago";
            this.Tipo_Pago.ReadOnly = true;
            this.Tipo_Pago.Width = 81;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(301, 351);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(123, 44);
            this.Btn_Salir.TabIndex = 50;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(158, 351);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(123, 44);
            this.Btn_Modificar.TabIndex = 47;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(15, 351);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(123, 44);
            this.Btn_Nuevo.TabIndex = 46;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Fra_Datos_Listas
            // 
            this.Fra_Datos_Listas.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Listas.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Listas.Controls.Add(this.Cmb_Forma_Pago);
            this.Fra_Datos_Listas.Controls.Add(this.Lbl_Forma_Pago);
            this.Fra_Datos_Listas.Controls.Add(this.Cmb_Operacion);
            this.Fra_Datos_Listas.Controls.Add(this.Lbl_Operacion);
            this.Fra_Datos_Listas.Controls.Add(this.Txt_Lista);
            this.Fra_Datos_Listas.Controls.Add(this.Lbl_Lista);
            this.Fra_Datos_Listas.Controls.Add(this.Txt_Nombre);
            this.Fra_Datos_Listas.Controls.Add(this.Lbl_Nombre);
            this.Fra_Datos_Listas.Controls.Add(this.Txt_Lista_Id);
            this.Fra_Datos_Listas.Controls.Add(this.Lbl_Lista_Id);
            this.Fra_Datos_Listas.Location = new System.Drawing.Point(15, 13);
            this.Fra_Datos_Listas.Name = "Fra_Datos_Listas";
            this.Fra_Datos_Listas.Size = new System.Drawing.Size(508, 187);
            this.Fra_Datos_Listas.TabIndex = 51;
            this.Fra_Datos_Listas.TabStop = false;
            this.Fra_Datos_Listas.Text = "Listas";
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(89, 98);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(161, 24);
            this.Cmb_Estatus.TabIndex = 21;
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Location = new System.Drawing.Point(12, 103);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(42, 13);
            this.Lbl_Estatus.TabIndex = 20;
            this.Lbl_Estatus.Text = "Estatus";
            // 
            // Cmb_Forma_Pago
            // 
            this.Cmb_Forma_Pago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Forma_Pago.FormattingEnabled = true;
            this.Cmb_Forma_Pago.Location = new System.Drawing.Point(89, 157);
            this.Cmb_Forma_Pago.Name = "Cmb_Forma_Pago";
            this.Cmb_Forma_Pago.Size = new System.Drawing.Size(161, 24);
            this.Cmb_Forma_Pago.TabIndex = 19;
            // 
            // Lbl_Forma_Pago
            // 
            this.Lbl_Forma_Pago.AutoSize = true;
            this.Lbl_Forma_Pago.Location = new System.Drawing.Point(12, 159);
            this.Lbl_Forma_Pago.Name = "Lbl_Forma_Pago";
            this.Lbl_Forma_Pago.Size = new System.Drawing.Size(63, 13);
            this.Lbl_Forma_Pago.TabIndex = 18;
            this.Lbl_Forma_Pago.Text = "Forma pago";
            // 
            // Cmb_Operacion
            // 
            this.Cmb_Operacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Operacion.FormattingEnabled = true;
            this.Cmb_Operacion.Items.AddRange(new object[] {
            "Venta general",
            "Venta individual",
            "Internet"});
            this.Cmb_Operacion.Location = new System.Drawing.Point(89, 128);
            this.Cmb_Operacion.Name = "Cmb_Operacion";
            this.Cmb_Operacion.Size = new System.Drawing.Size(161, 24);
            this.Cmb_Operacion.TabIndex = 17;
            // 
            // Lbl_Operacion
            // 
            this.Lbl_Operacion.AutoSize = true;
            this.Lbl_Operacion.Location = new System.Drawing.Point(12, 132);
            this.Lbl_Operacion.Name = "Lbl_Operacion";
            this.Lbl_Operacion.Size = new System.Drawing.Size(56, 13);
            this.Lbl_Operacion.TabIndex = 16;
            this.Lbl_Operacion.Text = "Operacion";
            // 
            // Txt_Lista
            // 
            this.Txt_Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Lista.Location = new System.Drawing.Point(89, 75);
            this.Txt_Lista.Name = "Txt_Lista";
            this.Txt_Lista.Size = new System.Drawing.Size(161, 22);
            this.Txt_Lista.TabIndex = 15;
            // 
            // Lbl_Lista
            // 
            this.Lbl_Lista.AutoSize = true;
            this.Lbl_Lista.Location = new System.Drawing.Point(12, 78);
            this.Lbl_Lista.Name = "Lbl_Lista";
            this.Lbl_Lista.Size = new System.Drawing.Size(29, 13);
            this.Lbl_Lista.TabIndex = 14;
            this.Lbl_Lista.Text = "Lista";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(89, 48);
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(339, 22);
            this.Txt_Nombre.TabIndex = 13;
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Location = new System.Drawing.Point(12, 48);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(44, 13);
            this.Lbl_Nombre.TabIndex = 12;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Txt_Lista_Id
            // 
            this.Txt_Lista_Id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Lista_Id.Location = new System.Drawing.Point(89, 19);
            this.Txt_Lista_Id.Name = "Txt_Lista_Id";
            this.Txt_Lista_Id.Size = new System.Drawing.Size(161, 22);
            this.Txt_Lista_Id.TabIndex = 11;
            // 
            // Lbl_Lista_Id
            // 
            this.Lbl_Lista_Id.AutoSize = true;
            this.Lbl_Lista_Id.Location = new System.Drawing.Point(12, 19);
            this.Lbl_Lista_Id.Name = "Lbl_Lista_Id";
            this.Lbl_Lista_Id.Size = new System.Drawing.Size(43, 13);
            this.Lbl_Lista_Id.TabIndex = 10;
            this.Lbl_Lista_Id.Text = "Lista ID";
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Frm_Cat_Lista_Deudorcad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 407);
            this.Controls.Add(this.Fra_Datos_Listas);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Listas);
            this.Name = "Frm_Cat_Lista_Deudorcad";
            this.Text = "Catalogo Lista Deudorcad";
            this.Load += new System.EventHandler(this.Frm_Cat_Lista_Deudorcad_Load);
            this.Fra_Listas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Lista)).EndInit();
            this.Fra_Datos_Listas.ResumeLayout(false);
            this.Fra_Datos_Listas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Listas;
        private System.Windows.Forms.DataGridView Grid_Lista;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.GroupBox Fra_Datos_Listas;
        private System.Windows.Forms.ComboBox Cmb_Forma_Pago;
        private System.Windows.Forms.Label Lbl_Forma_Pago;
        private System.Windows.Forms.ComboBox Cmb_Operacion;
        private System.Windows.Forms.Label Lbl_Operacion;
        private System.Windows.Forms.TextBox Txt_Lista;
        private System.Windows.Forms.Label Lbl_Lista;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.TextBox Txt_Lista_Id;
        private System.Windows.Forms.Label Lbl_Lista_Id;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lista_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_Pago;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
    }
}