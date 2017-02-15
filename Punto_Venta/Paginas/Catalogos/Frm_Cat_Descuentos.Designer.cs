namespace ERP_BASE.Paginas.Catalogos
{
    partial class Frm_Cat_Descuentos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Descuentos));
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Dtp_Fecha_Desde = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Leyenda = new System.Windows.Forms.Label();
            this.Txt_Leyenda = new System.Windows.Forms.TextBox();
            this.Txt_Motivo = new System.Windows.Forms.TextBox();
            this.Lbl_Motivo = new System.Windows.Forms.Label();
            this.Txt_Monto_Descuento = new System.Windows.Forms.TextBox();
            this.Txt_Porcentaje_Descuento = new System.Windows.Forms.TextBox();
            this.Lbl_Monto_Descuento = new System.Windows.Forms.Label();
            this.Lbl_Porcentaje_Descuento = new System.Windows.Forms.Label();
            this.Lbl_Vigencia_Hasta = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Hasta = new System.Windows.Forms.DateTimePicker();
            this.Txt_ID_Descuento = new System.Windows.Forms.TextBox();
            this.Lbl_ID_Descuento = new System.Windows.Forms.Label();
            this.Txt_Descripcion = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Lbl_Vigencia_Desde = new System.Windows.Forms.Label();
            this.Fra_Descuentos = new System.Windows.Forms.GroupBox();
            this.Grid_Descuentos = new System.Windows.Forms.DataGridView();
            this.Descuento_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vigencia_Desde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vigencia_Hasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje_Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto_Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Leyenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Descuentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Descuentos)).BeginInit();
            this.Fra_Buscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Controls.Add(this.Dtp_Fecha_Desde);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Leyenda);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Leyenda);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Motivo);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Motivo);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Monto_Descuento);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Porcentaje_Descuento);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Monto_Descuento);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Porcentaje_Descuento);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Vigencia_Hasta);
            this.Fra_Datos_Generales.Controls.Add(this.Dtp_Fecha_Hasta);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_ID_Descuento);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_ID_Descuento);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Descripcion);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Descripcion);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Vigencia_Desde);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(12, 12);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(857, 287);
            this.Fra_Datos_Generales.TabIndex = 33;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Dtp_Fecha_Desde
            // 
            this.Dtp_Fecha_Desde.Location = new System.Drawing.Point(126, 106);
            this.Dtp_Fecha_Desde.Name = "Dtp_Fecha_Desde";
            this.Dtp_Fecha_Desde.Size = new System.Drawing.Size(288, 21);
            this.Dtp_Fecha_Desde.TabIndex = 3;
            // 
            // Lbl_Leyenda
            // 
            this.Lbl_Leyenda.AutoSize = true;
            this.Lbl_Leyenda.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Leyenda.Location = new System.Drawing.Point(7, 227);
            this.Lbl_Leyenda.Name = "Lbl_Leyenda";
            this.Lbl_Leyenda.Size = new System.Drawing.Size(49, 14);
            this.Lbl_Leyenda.TabIndex = 57;
            this.Lbl_Leyenda.Text = "Leyenda";
            // 
            // Txt_Leyenda
            // 
            this.Txt_Leyenda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Leyenda.Location = new System.Drawing.Point(126, 227);
            this.Txt_Leyenda.MaxLength = 255;
            this.Txt_Leyenda.Multiline = true;
            this.Txt_Leyenda.Name = "Txt_Leyenda";
            this.Txt_Leyenda.Size = new System.Drawing.Size(288, 46);
            this.Txt_Leyenda.TabIndex = 8;
            // 
            // Txt_Motivo
            // 
            this.Txt_Motivo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Motivo.Location = new System.Drawing.Point(126, 195);
            this.Txt_Motivo.MaxLength = 100;
            this.Txt_Motivo.Name = "Txt_Motivo";
            this.Txt_Motivo.Size = new System.Drawing.Size(288, 22);
            this.Txt_Motivo.TabIndex = 7;
            // 
            // Lbl_Motivo
            // 
            this.Lbl_Motivo.AutoSize = true;
            this.Lbl_Motivo.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Motivo.Location = new System.Drawing.Point(7, 200);
            this.Lbl_Motivo.Name = "Lbl_Motivo";
            this.Lbl_Motivo.Size = new System.Drawing.Size(38, 14);
            this.Lbl_Motivo.TabIndex = 54;
            this.Lbl_Motivo.Text = "Motivo";
            // 
            // Txt_Monto_Descuento
            // 
            this.Txt_Monto_Descuento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Monto_Descuento.Location = new System.Drawing.Point(126, 161);
            this.Txt_Monto_Descuento.MaxLength = 6;
            this.Txt_Monto_Descuento.Name = "Txt_Monto_Descuento";
            this.Txt_Monto_Descuento.Size = new System.Drawing.Size(132, 22);
            this.Txt_Monto_Descuento.TabIndex = 6;
            this.Txt_Monto_Descuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numerico_KeyPress);
            // 
            // Txt_Porcentaje_Descuento
            // 
            this.Txt_Porcentaje_Descuento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Porcentaje_Descuento.Location = new System.Drawing.Point(126, 133);
            this.Txt_Porcentaje_Descuento.MaxLength = 3;
            this.Txt_Porcentaje_Descuento.Name = "Txt_Porcentaje_Descuento";
            this.Txt_Porcentaje_Descuento.Size = new System.Drawing.Size(132, 22);
            this.Txt_Porcentaje_Descuento.TabIndex = 5;
            this.Txt_Porcentaje_Descuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numerico_KeyPress);
            // 
            // Lbl_Monto_Descuento
            // 
            this.Lbl_Monto_Descuento.AutoSize = true;
            this.Lbl_Monto_Descuento.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Monto_Descuento.Location = new System.Drawing.Point(6, 169);
            this.Lbl_Monto_Descuento.Name = "Lbl_Monto_Descuento";
            this.Lbl_Monto_Descuento.Size = new System.Drawing.Size(91, 14);
            this.Lbl_Monto_Descuento.TabIndex = 51;
            this.Lbl_Monto_Descuento.Text = "Monto Descuento";
            // 
            // Lbl_Porcentaje_Descuento
            // 
            this.Lbl_Porcentaje_Descuento.AutoSize = true;
            this.Lbl_Porcentaje_Descuento.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Porcentaje_Descuento.Location = new System.Drawing.Point(7, 141);
            this.Lbl_Porcentaje_Descuento.Name = "Lbl_Porcentaje_Descuento";
            this.Lbl_Porcentaje_Descuento.Size = new System.Drawing.Size(113, 14);
            this.Lbl_Porcentaje_Descuento.TabIndex = 50;
            this.Lbl_Porcentaje_Descuento.Text = "Porcentaje Descuento";
            // 
            // Lbl_Vigencia_Hasta
            // 
            this.Lbl_Vigencia_Hasta.AutoSize = true;
            this.Lbl_Vigencia_Hasta.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Vigencia_Hasta.Location = new System.Drawing.Point(437, 111);
            this.Lbl_Vigencia_Hasta.Name = "Lbl_Vigencia_Hasta";
            this.Lbl_Vigencia_Hasta.Size = new System.Drawing.Size(91, 14);
            this.Lbl_Vigencia_Hasta.TabIndex = 49;
            this.Lbl_Vigencia_Hasta.Text = "*Vigencia Hasta";
            // 
            // Dtp_Fecha_Hasta
            // 
            this.Dtp_Fecha_Hasta.Location = new System.Drawing.Point(547, 105);
            this.Dtp_Fecha_Hasta.Name = "Dtp_Fecha_Hasta";
            this.Dtp_Fecha_Hasta.Size = new System.Drawing.Size(285, 21);
            this.Dtp_Fecha_Hasta.TabIndex = 4;
            // 
            // Txt_ID_Descuento
            // 
            this.Txt_ID_Descuento.Enabled = false;
            this.Txt_ID_Descuento.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID_Descuento.Location = new System.Drawing.Point(126, 15);
            this.Txt_ID_Descuento.MaxLength = 5;
            this.Txt_ID_Descuento.Name = "Txt_ID_Descuento";
            this.Txt_ID_Descuento.Size = new System.Drawing.Size(114, 22);
            this.Txt_ID_Descuento.TabIndex = 1;
            // 
            // Lbl_ID_Descuento
            // 
            this.Lbl_ID_Descuento.AutoSize = true;
            this.Lbl_ID_Descuento.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_ID_Descuento.Location = new System.Drawing.Point(7, 20);
            this.Lbl_ID_Descuento.Name = "Lbl_ID_Descuento";
            this.Lbl_ID_Descuento.Size = new System.Drawing.Size(71, 14);
            this.Lbl_ID_Descuento.TabIndex = 47;
            this.Lbl_ID_Descuento.Text = "ID Descuento";
            // 
            // Txt_Descripcion
            // 
            this.Txt_Descripcion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion.Location = new System.Drawing.Point(126, 43);
            this.Txt_Descripcion.MaxLength = 255;
            this.Txt_Descripcion.Multiline = true;
            this.Txt_Descripcion.Name = "Txt_Descripcion";
            this.Txt_Descripcion.Size = new System.Drawing.Size(288, 57);
            this.Txt_Descripcion.TabIndex = 2;
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion.Location = new System.Drawing.Point(6, 48);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(72, 14);
            this.Lbl_Descripcion.TabIndex = 18;
            this.Lbl_Descripcion.Text = "Descripción";
            // 
            // Lbl_Vigencia_Desde
            // 
            this.Lbl_Vigencia_Desde.AutoSize = true;
            this.Lbl_Vigencia_Desde.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Vigencia_Desde.Location = new System.Drawing.Point(6, 112);
            this.Lbl_Vigencia_Desde.Name = "Lbl_Vigencia_Desde";
            this.Lbl_Vigencia_Desde.Size = new System.Drawing.Size(96, 14);
            this.Lbl_Vigencia_Desde.TabIndex = 6;
            this.Lbl_Vigencia_Desde.Text = "*Vigencia Desde";
            // 
            // Fra_Descuentos
            // 
            this.Fra_Descuentos.Controls.Add(this.Grid_Descuentos);
            this.Fra_Descuentos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Descuentos.Location = new System.Drawing.Point(12, 305);
            this.Fra_Descuentos.Name = "Fra_Descuentos";
            this.Fra_Descuentos.Size = new System.Drawing.Size(857, 186);
            this.Fra_Descuentos.TabIndex = 39;
            this.Fra_Descuentos.TabStop = false;
            this.Fra_Descuentos.Text = "Descuentos";
            // 
            // Grid_Descuentos
            // 
            this.Grid_Descuentos.AllowUserToAddRows = false;
            this.Grid_Descuentos.AllowUserToDeleteRows = false;
            this.Grid_Descuentos.AllowUserToResizeRows = false;
            this.Grid_Descuentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Descuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Descuentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descuento_ID,
            this.Descripcion,
            this.Vigencia_Desde,
            this.Vigencia_Hasta,
            this.Porcentaje_Descuento,
            this.Monto_Descuento,
            this.Motivo,
            this.Leyenda});
            this.Grid_Descuentos.Location = new System.Drawing.Point(0, 20);
            this.Grid_Descuentos.Name = "Grid_Descuentos";
            this.Grid_Descuentos.ReadOnly = true;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Descuentos.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.Grid_Descuentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Descuentos.Size = new System.Drawing.Size(851, 156);
            this.Grid_Descuentos.TabIndex = 0;
            this.Grid_Descuentos.SelectionChanged += new System.EventHandler(this.Grid_Descuentos_SelectionChanged);
            // 
            // Descuento_ID
            // 
            this.Descuento_ID.DataPropertyName = "Descuento_ID";
            this.Descuento_ID.HeaderText = "ID de Descuento";
            this.Descuento_ID.Name = "Descuento_ID";
            this.Descuento_ID.ReadOnly = true;
            this.Descuento_ID.Width = 114;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Vigencia_Desde
            // 
            this.Vigencia_Desde.DataPropertyName = "Vigencia_Desde";
            dataGridViewCellStyle7.Format = "D";
            dataGridViewCellStyle7.NullValue = null;
            this.Vigencia_Desde.DefaultCellStyle = dataGridViewCellStyle7;
            this.Vigencia_Desde.HeaderText = "Vigencia Desde";
            this.Vigencia_Desde.Name = "Vigencia_Desde";
            this.Vigencia_Desde.ReadOnly = true;
            this.Vigencia_Desde.Width = 110;
            // 
            // Vigencia_Hasta
            // 
            this.Vigencia_Hasta.DataPropertyName = "Vigencia_Hasta";
            dataGridViewCellStyle8.Format = "D";
            dataGridViewCellStyle8.NullValue = null;
            this.Vigencia_Hasta.DefaultCellStyle = dataGridViewCellStyle8;
            this.Vigencia_Hasta.HeaderText = "Vigencia Hasta";
            this.Vigencia_Hasta.Name = "Vigencia_Hasta";
            this.Vigencia_Hasta.ReadOnly = true;
            this.Vigencia_Hasta.Width = 107;
            // 
            // Porcentaje_Descuento
            // 
            this.Porcentaje_Descuento.DataPropertyName = "Porcentaje_Descuento";
            this.Porcentaje_Descuento.HeaderText = "Porcentaje Descuento";
            this.Porcentaje_Descuento.Name = "Porcentaje_Descuento";
            this.Porcentaje_Descuento.ReadOnly = true;
            this.Porcentaje_Descuento.Width = 144;
            // 
            // Monto_Descuento
            // 
            this.Monto_Descuento.DataPropertyName = "Monto_Descuento";
            this.Monto_Descuento.HeaderText = "Monto Descuento";
            this.Monto_Descuento.Name = "Monto_Descuento";
            this.Monto_Descuento.ReadOnly = true;
            this.Monto_Descuento.Width = 120;
            // 
            // Motivo
            // 
            this.Motivo.DataPropertyName = "Motivo";
            this.Motivo.HeaderText = "Motivo";
            this.Motivo.Name = "Motivo";
            this.Motivo.ReadOnly = true;
            this.Motivo.Width = 69;
            // 
            // Leyenda
            // 
            this.Leyenda.DataPropertyName = "Leyenda";
            this.Leyenda.HeaderText = "Leyenda";
            this.Leyenda.Name = "Leyenda";
            this.Leyenda.ReadOnly = true;
            this.Leyenda.Width = 80;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(628, 497);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(75, 51);
            this.Btn_Salir.TabIndex = 13;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(509, 497);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(75, 51);
            this.Btn_Eliminar.TabIndex = 12;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(383, 497);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(75, 51);
            this.Btn_Buscar.TabIndex = 11;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(255, 497);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(75, 51);
            this.Btn_Modificar.TabIndex = 10;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(120, 497);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(75, 51);
            this.Btn_Nuevo.TabIndex = 9;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(12, 6);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(857, 287);
            this.Fra_Buscar.TabIndex = 60;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            this.Fra_Buscar.Visible = false;
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(471, 139);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(78, 45);
            this.Btn_Regresar.TabIndex = 21;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(297, 139);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(78, 45);
            this.Btn_Busqueda.TabIndex = 20;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(513, 51);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(313, 20);
            this.Txt_Descripcion_Busqueda.TabIndex = 3;
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(416, 51);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(80, 15);
            this.Lbl_Descripcion_Busqueda.TabIndex = 2;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "Seleccione un opción",
            "ID Descuento",
            "Descripción"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(108, 51);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(285, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 1;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(7, 51);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Frm_Cat_Descuentos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(883, 551);
            this.Controls.Add(this.Fra_Buscar);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Descuentos);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Descuentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuentos";
            this.Load += new System.EventHandler(this.Frm_Cat_Descuentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Descuentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Descuentos)).EndInit();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.TextBox Txt_ID_Descuento;
        private System.Windows.Forms.Label Lbl_ID_Descuento;
        private System.Windows.Forms.TextBox Txt_Descripcion;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.Label Lbl_Vigencia_Desde;
        private System.Windows.Forms.Label Lbl_Leyenda;
        private System.Windows.Forms.TextBox Txt_Leyenda;
        private System.Windows.Forms.TextBox Txt_Motivo;
        private System.Windows.Forms.Label Lbl_Motivo;
        private System.Windows.Forms.TextBox Txt_Monto_Descuento;
        private System.Windows.Forms.TextBox Txt_Porcentaje_Descuento;
        private System.Windows.Forms.Label Lbl_Monto_Descuento;
        private System.Windows.Forms.Label Lbl_Porcentaje_Descuento;
        private System.Windows.Forms.Label Lbl_Vigencia_Hasta;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Hasta;
        private System.Windows.Forms.GroupBox Fra_Descuentos;
        private System.Windows.Forms.DataGridView Grid_Descuentos;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vigencia_Desde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vigencia_Hasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje_Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto_Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Leyenda;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;
    }
}