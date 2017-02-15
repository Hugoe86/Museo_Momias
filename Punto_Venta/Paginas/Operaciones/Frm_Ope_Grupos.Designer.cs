namespace ERP_BASE.Paginas.Operaciones.Grupos
{
    partial class Frm_Ope_Grupos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ope_Grupos));
            this.Fra_Detalles_Venta = new System.Windows.Forms.GroupBox();
            this.Grid_Detalles_Ventas = new System.Windows.Forms.DataGridView();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPRIMIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Lbl_Total_Precio = new System.Windows.Forms.Label();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.Txt_Cantidad = new System.Windows.Forms.TextBox();
            this.Lbl_Cantidad = new System.Windows.Forms.Label();
            this.Pnl_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Btn_Agregar = new System.Windows.Forms.Button();
            this.Txt_Costo = new System.Windows.Forms.TextBox();
            this.Lbl_Costo = new System.Windows.Forms.Label();
            this.Cmb_Servicios = new System.Windows.Forms.ComboBox();
            this.Cmb_Productos = new System.Windows.Forms.ComboBox();
            this.Lbl_Servicios = new System.Windows.Forms.Label();
            this.Lbl_Productos = new System.Windows.Forms.Label();
            this.Pnl_Datos_Grupo = new System.Windows.Forms.GroupBox();
            this.Txt_No_Venta = new System.Windows.Forms.TextBox();
            this.Cmb_Aplica_Dias_Festivos = new System.Windows.Forms.ComboBox();
            this.Lbl_Aplica_Dias_Festivos = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Termino_Vigencia = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Fecha_Inicio_Vigencia = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Fecha_Tramite = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Fecha_Tramite = new System.Windows.Forms.Label();
            this.Lbl_Fecha_Inicio_Vigencia = new System.Windows.Forms.Label();
            this.Lbl_Fecha_Termino_Vigencia = new System.Windows.Forms.Label();
            this.Txt_Empresa_Tramita = new System.Windows.Forms.TextBox();
            this.Txt_Persona_Tramita = new System.Windows.Forms.TextBox();
            this.Lbl_Empresa = new System.Windows.Forms.Label();
            this.Lbl_Persona_Tramita = new System.Windows.Forms.Label();
            this.Btn_Consultar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Fra_Detalles_Venta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Detalles_Ventas)).BeginInit();
            this.Pnl_Datos_Generales.SuspendLayout();
            this.Pnl_Datos_Grupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fra_Detalles_Venta
            // 
            this.Fra_Detalles_Venta.Controls.Add(this.Grid_Detalles_Ventas);
            this.Fra_Detalles_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fra_Detalles_Venta.Location = new System.Drawing.Point(4, 280);
            this.Fra_Detalles_Venta.Name = "Fra_Detalles_Venta";
            this.Fra_Detalles_Venta.Size = new System.Drawing.Size(617, 224);
            this.Fra_Detalles_Venta.TabIndex = 0;
            this.Fra_Detalles_Venta.TabStop = false;
            this.Fra_Detalles_Venta.Text = "Detalles Grupos";
            // 
            // Grid_Detalles_Ventas
            // 
            this.Grid_Detalles_Ventas.AllowUserToAddRows = false;
            this.Grid_Detalles_Ventas.AllowUserToDeleteRows = false;
            this.Grid_Detalles_Ventas.BackgroundColor = System.Drawing.Color.White;
            this.Grid_Detalles_Ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Detalles_Ventas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CANTIDAD,
            this.PRODUCTO,
            this.PRODUCTO_ID,
            this.COSTO,
            this.TOTAL,
            this.TIPO,
            this.IMPRIMIR,
            this.Eliminar});
            this.Grid_Detalles_Ventas.Location = new System.Drawing.Point(5, 16);
            this.Grid_Detalles_Ventas.Name = "Grid_Detalles_Ventas";
            this.Grid_Detalles_Ventas.ReadOnly = true;
            this.Grid_Detalles_Ventas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Detalles_Ventas.Size = new System.Drawing.Size(606, 193);
            this.Grid_Detalles_Ventas.TabIndex = 0;
            this.Grid_Detalles_Ventas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Detalles_Ventas_CellContentClick);
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.FillWeight = 50F;
            this.CANTIDAD.HeaderText = "Cantidad";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            this.CANTIDAD.Width = 50;
            // 
            // PRODUCTO
            // 
            this.PRODUCTO.FillWeight = 120F;
            this.PRODUCTO.HeaderText = "Nombre";
            this.PRODUCTO.Name = "PRODUCTO";
            this.PRODUCTO.ReadOnly = true;
            this.PRODUCTO.Width = 120;
            // 
            // PRODUCTO_ID
            // 
            this.PRODUCTO_ID.HeaderText = "Producto_Id";
            this.PRODUCTO_ID.Name = "PRODUCTO_ID";
            this.PRODUCTO_ID.ReadOnly = true;
            this.PRODUCTO_ID.Visible = false;
            // 
            // COSTO
            // 
            this.COSTO.FillWeight = 60F;
            this.COSTO.HeaderText = "Costo unitario";
            this.COSTO.Name = "COSTO";
            this.COSTO.ReadOnly = true;
            this.COSTO.Width = 60;
            // 
            // TOTAL
            // 
            this.TOTAL.FillWeight = 60F;
            this.TOTAL.HeaderText = "Total";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            this.TOTAL.Width = 60;
            // 
            // TIPO
            // 
            this.TIPO.HeaderText = "Tipo";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.Visible = false;
            // 
            // IMPRIMIR
            // 
            this.IMPRIMIR.HeaderText = "Imprimir";
            this.IMPRIMIR.Name = "IMPRIMIR";
            this.IMPRIMIR.ReadOnly = true;
            this.IMPRIMIR.Visible = false;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 7F);
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.Location = new System.Drawing.Point(444, 510);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(83, 45);
            this.Btn_Salir.TabIndex = 25;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 7F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.Location = new System.Drawing.Point(94, 510);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(83, 45);
            this.Btn_Nuevo.TabIndex = 24;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Lbl_Total_Precio
            // 
            this.Lbl_Total_Precio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Total_Precio.Location = new System.Drawing.Point(440, 250);
            this.Lbl_Total_Precio.Name = "Lbl_Total_Precio";
            this.Lbl_Total_Precio.Size = new System.Drawing.Size(181, 29);
            this.Lbl_Total_Precio.TabIndex = 23;
            this.Lbl_Total_Precio.Text = "$ 0.00";
            this.Lbl_Total_Precio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Total.Location = new System.Drawing.Point(386, 250);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(90, 27);
            this.Lbl_Total.TabIndex = 22;
            this.Lbl_Total.Text = "Total";
            this.Lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Txt_Cantidad
            // 
            this.Txt_Cantidad.BackColor = System.Drawing.Color.White;
            this.Txt_Cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Cantidad.Location = new System.Drawing.Point(89, 54);
            this.Txt_Cantidad.MaxLength = 4;
            this.Txt_Cantidad.Name = "Txt_Cantidad";
            this.Txt_Cantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Cantidad.Size = new System.Drawing.Size(202, 22);
            this.Txt_Cantidad.TabIndex = 38;
            this.Txt_Cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Cantidad_KeyPress);
            // 
            // Lbl_Cantidad
            // 
            this.Lbl_Cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Cantidad.Location = new System.Drawing.Point(9, 52);
            this.Lbl_Cantidad.Name = "Lbl_Cantidad";
            this.Lbl_Cantidad.Size = new System.Drawing.Size(77, 27);
            this.Lbl_Cantidad.TabIndex = 26;
            this.Lbl_Cantidad.Text = "Cantidad";
            this.Lbl_Cantidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pnl_Datos_Generales
            // 
            this.Pnl_Datos_Generales.Controls.Add(this.Btn_Agregar);
            this.Pnl_Datos_Generales.Controls.Add(this.Txt_Costo);
            this.Pnl_Datos_Generales.Controls.Add(this.Lbl_Costo);
            this.Pnl_Datos_Generales.Controls.Add(this.Cmb_Servicios);
            this.Pnl_Datos_Generales.Controls.Add(this.Txt_Cantidad);
            this.Pnl_Datos_Generales.Controls.Add(this.Lbl_Cantidad);
            this.Pnl_Datos_Generales.Controls.Add(this.Cmb_Productos);
            this.Pnl_Datos_Generales.Controls.Add(this.Lbl_Servicios);
            this.Pnl_Datos_Generales.Controls.Add(this.Lbl_Productos);
            this.Pnl_Datos_Generales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Pnl_Datos_Generales.Location = new System.Drawing.Point(3, 153);
            this.Pnl_Datos_Generales.Name = "Pnl_Datos_Generales";
            this.Pnl_Datos_Generales.Size = new System.Drawing.Size(617, 92);
            this.Pnl_Datos_Generales.TabIndex = 39;
            this.Pnl_Datos_Generales.TabStop = false;
            this.Pnl_Datos_Generales.Text = "Datos Generales";
            // 
            // Btn_Agregar
            // 
            this.Btn_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Agregar.Location = new System.Drawing.Point(504, 52);
            this.Btn_Agregar.Name = "Btn_Agregar";
            this.Btn_Agregar.Size = new System.Drawing.Size(99, 23);
            this.Btn_Agregar.TabIndex = 42;
            this.Btn_Agregar.Text = "Agregar";
            this.Btn_Agregar.UseVisualStyleBackColor = true;
            this.Btn_Agregar.Click += new System.EventHandler(this.Btn_Agregar_Click);
            // 
            // Txt_Costo
            // 
            this.Txt_Costo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Costo.Location = new System.Drawing.Point(377, 53);
            this.Txt_Costo.MaxLength = 12;
            this.Txt_Costo.Name = "Txt_Costo";
            this.Txt_Costo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt_Costo.Size = new System.Drawing.Size(121, 22);
            this.Txt_Costo.TabIndex = 41;
            this.Txt_Costo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Costo_KeyPress);
            // 
            // Lbl_Costo
            // 
            this.Lbl_Costo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Costo.Location = new System.Drawing.Point(297, 52);
            this.Lbl_Costo.Name = "Lbl_Costo";
            this.Lbl_Costo.Size = new System.Drawing.Size(77, 27);
            this.Lbl_Costo.TabIndex = 39;
            this.Lbl_Costo.Text = "Costo";
            this.Lbl_Costo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Cmb_Servicios
            // 
            this.Cmb_Servicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Servicios.FormattingEnabled = true;
            this.Cmb_Servicios.Location = new System.Drawing.Point(377, 23);
            this.Cmb_Servicios.Name = "Cmb_Servicios";
            this.Cmb_Servicios.Size = new System.Drawing.Size(226, 24);
            this.Cmb_Servicios.TabIndex = 30;
            this.Cmb_Servicios.SelectedIndexChanged += new System.EventHandler(this.Cmb_Conceptos_SelectedIndexChanged);
            // 
            // Cmb_Productos
            // 
            this.Cmb_Productos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Productos.FormattingEnabled = true;
            this.Cmb_Productos.Location = new System.Drawing.Point(89, 24);
            this.Cmb_Productos.Name = "Cmb_Productos";
            this.Cmb_Productos.Size = new System.Drawing.Size(202, 24);
            this.Cmb_Productos.TabIndex = 29;
            this.Cmb_Productos.SelectedIndexChanged += new System.EventHandler(this.Cmb_Conceptos_SelectedIndexChanged);
            // 
            // Lbl_Servicios
            // 
            this.Lbl_Servicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Servicios.Location = new System.Drawing.Point(297, 22);
            this.Lbl_Servicios.Name = "Lbl_Servicios";
            this.Lbl_Servicios.Size = new System.Drawing.Size(74, 27);
            this.Lbl_Servicios.TabIndex = 28;
            this.Lbl_Servicios.Text = "Servicios";
            this.Lbl_Servicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_Productos
            // 
            this.Lbl_Productos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Productos.Location = new System.Drawing.Point(9, 23);
            this.Lbl_Productos.Name = "Lbl_Productos";
            this.Lbl_Productos.Size = new System.Drawing.Size(95, 27);
            this.Lbl_Productos.TabIndex = 27;
            this.Lbl_Productos.Text = "Productos";
            this.Lbl_Productos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pnl_Datos_Grupo
            // 
            this.Pnl_Datos_Grupo.Controls.Add(this.Txt_No_Venta);
            this.Pnl_Datos_Grupo.Controls.Add(this.Cmb_Aplica_Dias_Festivos);
            this.Pnl_Datos_Grupo.Controls.Add(this.Lbl_Aplica_Dias_Festivos);
            this.Pnl_Datos_Grupo.Controls.Add(this.Dtp_Fecha_Termino_Vigencia);
            this.Pnl_Datos_Grupo.Controls.Add(this.Dtp_Fecha_Inicio_Vigencia);
            this.Pnl_Datos_Grupo.Controls.Add(this.Dtp_Fecha_Tramite);
            this.Pnl_Datos_Grupo.Controls.Add(this.Lbl_Fecha_Tramite);
            this.Pnl_Datos_Grupo.Controls.Add(this.Lbl_Fecha_Inicio_Vigencia);
            this.Pnl_Datos_Grupo.Controls.Add(this.Lbl_Fecha_Termino_Vigencia);
            this.Pnl_Datos_Grupo.Controls.Add(this.Txt_Empresa_Tramita);
            this.Pnl_Datos_Grupo.Controls.Add(this.Txt_Persona_Tramita);
            this.Pnl_Datos_Grupo.Controls.Add(this.Lbl_Empresa);
            this.Pnl_Datos_Grupo.Controls.Add(this.Lbl_Persona_Tramita);
            this.Pnl_Datos_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Pnl_Datos_Grupo.Location = new System.Drawing.Point(3, 2);
            this.Pnl_Datos_Grupo.Name = "Pnl_Datos_Grupo";
            this.Pnl_Datos_Grupo.Size = new System.Drawing.Size(617, 145);
            this.Pnl_Datos_Grupo.TabIndex = 42;
            this.Pnl_Datos_Grupo.TabStop = false;
            this.Pnl_Datos_Grupo.Text = "Datos Grupo";
            // 
            // Txt_No_Venta
            // 
            this.Txt_No_Venta.Location = new System.Drawing.Point(9, 117);
            this.Txt_No_Venta.Name = "Txt_No_Venta";
            this.Txt_No_Venta.Size = new System.Drawing.Size(0, 22);
            this.Txt_No_Venta.TabIndex = 51;
            this.Txt_No_Venta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Cmb_Aplica_Dias_Festivos
            // 
            this.Cmb_Aplica_Dias_Festivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Cmb_Aplica_Dias_Festivos.FormattingEnabled = true;
            this.Cmb_Aplica_Dias_Festivos.Location = new System.Drawing.Point(476, 109);
            this.Cmb_Aplica_Dias_Festivos.Name = "Cmb_Aplica_Dias_Festivos";
            this.Cmb_Aplica_Dias_Festivos.Size = new System.Drawing.Size(127, 24);
            this.Cmb_Aplica_Dias_Festivos.TabIndex = 50;
            // 
            // Lbl_Aplica_Dias_Festivos
            // 
            this.Lbl_Aplica_Dias_Festivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Aplica_Dias_Festivos.Location = new System.Drawing.Point(337, 107);
            this.Lbl_Aplica_Dias_Festivos.Name = "Lbl_Aplica_Dias_Festivos";
            this.Lbl_Aplica_Dias_Festivos.Size = new System.Drawing.Size(136, 27);
            this.Lbl_Aplica_Dias_Festivos.TabIndex = 49;
            this.Lbl_Aplica_Dias_Festivos.Text = "Aplica Días Festivos";
            this.Lbl_Aplica_Dias_Festivos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dtp_Fecha_Termino_Vigencia
            // 
            this.Dtp_Fecha_Termino_Vigencia.CustomFormat = "dd MMM yyyy";
            this.Dtp_Fecha_Termino_Vigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha_Termino_Vigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Termino_Vigencia.Location = new System.Drawing.Point(476, 81);
            this.Dtp_Fecha_Termino_Vigencia.Name = "Dtp_Fecha_Termino_Vigencia";
            this.Dtp_Fecha_Termino_Vigencia.Size = new System.Drawing.Size(127, 22);
            this.Dtp_Fecha_Termino_Vigencia.TabIndex = 48;
            // 
            // Dtp_Fecha_Inicio_Vigencia
            // 
            this.Dtp_Fecha_Inicio_Vigencia.CustomFormat = "dd MMM yyyy";
            this.Dtp_Fecha_Inicio_Vigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha_Inicio_Vigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Inicio_Vigencia.Location = new System.Drawing.Point(282, 81);
            this.Dtp_Fecha_Inicio_Vigencia.Name = "Dtp_Fecha_Inicio_Vigencia";
            this.Dtp_Fecha_Inicio_Vigencia.Size = new System.Drawing.Size(127, 22);
            this.Dtp_Fecha_Inicio_Vigencia.TabIndex = 47;
            // 
            // Dtp_Fecha_Tramite
            // 
            this.Dtp_Fecha_Tramite.CustomFormat = "dd MMM yyyy";
            this.Dtp_Fecha_Tramite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha_Tramite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Tramite.Location = new System.Drawing.Point(105, 81);
            this.Dtp_Fecha_Tramite.Name = "Dtp_Fecha_Tramite";
            this.Dtp_Fecha_Tramite.Size = new System.Drawing.Size(127, 22);
            this.Dtp_Fecha_Tramite.TabIndex = 46;
            // 
            // Lbl_Fecha_Tramite
            // 
            this.Lbl_Fecha_Tramite.AutoSize = true;
            this.Lbl_Fecha_Tramite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Lbl_Fecha_Tramite.Location = new System.Drawing.Point(9, 84);
            this.Lbl_Fecha_Tramite.Name = "Lbl_Fecha_Tramite";
            this.Lbl_Fecha_Tramite.Size = new System.Drawing.Size(95, 16);
            this.Lbl_Fecha_Tramite.TabIndex = 43;
            this.Lbl_Fecha_Tramite.Text = "Fecha Tramite";
            // 
            // Lbl_Fecha_Inicio_Vigencia
            // 
            this.Lbl_Fecha_Inicio_Vigencia.AutoSize = true;
            this.Lbl_Fecha_Inicio_Vigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Lbl_Fecha_Inicio_Vigencia.Location = new System.Drawing.Point(238, 84);
            this.Lbl_Fecha_Inicio_Vigencia.Name = "Lbl_Fecha_Inicio_Vigencia";
            this.Lbl_Fecha_Inicio_Vigencia.Size = new System.Drawing.Size(39, 16);
            this.Lbl_Fecha_Inicio_Vigencia.TabIndex = 44;
            this.Lbl_Fecha_Inicio_Vigencia.Text = "Inicio";
            // 
            // Lbl_Fecha_Termino_Vigencia
            // 
            this.Lbl_Fecha_Termino_Vigencia.AutoSize = true;
            this.Lbl_Fecha_Termino_Vigencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Lbl_Fecha_Termino_Vigencia.Location = new System.Drawing.Point(415, 84);
            this.Lbl_Fecha_Termino_Vigencia.Name = "Lbl_Fecha_Termino_Vigencia";
            this.Lbl_Fecha_Termino_Vigencia.Size = new System.Drawing.Size(58, 16);
            this.Lbl_Fecha_Termino_Vigencia.TabIndex = 45;
            this.Lbl_Fecha_Termino_Vigencia.Text = "Termino";
            // 
            // Txt_Empresa_Tramita
            // 
            this.Txt_Empresa_Tramita.BackColor = System.Drawing.Color.White;
            this.Txt_Empresa_Tramita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Empresa_Tramita.Location = new System.Drawing.Point(105, 52);
            this.Txt_Empresa_Tramita.MaxLength = 100;
            this.Txt_Empresa_Tramita.Name = "Txt_Empresa_Tramita";
            this.Txt_Empresa_Tramita.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Empresa_Tramita.Size = new System.Drawing.Size(498, 22);
            this.Txt_Empresa_Tramita.TabIndex = 42;
            this.Txt_Empresa_Tramita.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Empresa_Tramita_KeyPress);
            // 
            // Txt_Persona_Tramita
            // 
            this.Txt_Persona_Tramita.BackColor = System.Drawing.Color.White;
            this.Txt_Persona_Tramita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Persona_Tramita.Location = new System.Drawing.Point(105, 25);
            this.Txt_Persona_Tramita.MaxLength = 100;
            this.Txt_Persona_Tramita.Name = "Txt_Persona_Tramita";
            this.Txt_Persona_Tramita.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Persona_Tramita.Size = new System.Drawing.Size(498, 22);
            this.Txt_Persona_Tramita.TabIndex = 38;
            this.Txt_Persona_Tramita.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Persona_Tramita_KeyPress);
            // 
            // Lbl_Empresa
            // 
            this.Lbl_Empresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Empresa.Location = new System.Drawing.Point(9, 52);
            this.Lbl_Empresa.Name = "Lbl_Empresa";
            this.Lbl_Empresa.Size = new System.Drawing.Size(77, 27);
            this.Lbl_Empresa.TabIndex = 26;
            this.Lbl_Empresa.Text = "Empresa";
            this.Lbl_Empresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_Persona_Tramita
            // 
            this.Lbl_Persona_Tramita.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Persona_Tramita.Location = new System.Drawing.Point(9, 23);
            this.Lbl_Persona_Tramita.Name = "Lbl_Persona_Tramita";
            this.Lbl_Persona_Tramita.Size = new System.Drawing.Size(74, 27);
            this.Lbl_Persona_Tramita.TabIndex = 27;
            this.Lbl_Persona_Tramita.Text = "Tramita";
            this.Lbl_Persona_Tramita.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Btn_Consultar
            // 
            this.Btn_Consultar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Consultar.Font = new System.Drawing.Font("Arial", 7F);
            this.Btn_Consultar.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Consultar.Location = new System.Drawing.Point(356, 510);
            this.Btn_Consultar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(83, 45);
            this.Btn_Consultar.TabIndex = 45;
            this.Btn_Consultar.Text = "Consultar";
            this.Btn_Consultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Consultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Consultar.UseVisualStyleBackColor = true;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 7F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
            this.Btn_Eliminar.Location = new System.Drawing.Point(269, 510);
            this.Btn_Eliminar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(83, 45);
            this.Btn_Eliminar.TabIndex = 44;
            this.Btn_Eliminar.Text = "Cancelar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 7F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.Location = new System.Drawing.Point(182, 510);
            this.Btn_Modificar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(83, 45);
            this.Btn_Modificar.TabIndex = 43;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Frm_Ope_Grupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 562);
            this.Controls.Add(this.Btn_Consultar);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Pnl_Datos_Grupo);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Pnl_Datos_Generales);
            this.Controls.Add(this.Lbl_Total_Precio);
            this.Controls.Add(this.Lbl_Total);
            this.Controls.Add(this.Fra_Detalles_Venta);
            this.Name = "Frm_Ope_Grupos";
            this.Text = "Grupos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Ope_Retiros_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Ope_Grupos_Load);
            this.Fra_Detalles_Venta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Detalles_Ventas)).EndInit();
            this.Pnl_Datos_Generales.ResumeLayout(false);
            this.Pnl_Datos_Generales.PerformLayout();
            this.Pnl_Datos_Grupo.ResumeLayout(false);
            this.Pnl_Datos_Grupo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Detalles_Venta;
        private System.Windows.Forms.Label Lbl_Total_Precio;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.DataGridView Grid_Detalles_Ventas;
        private System.Windows.Forms.TextBox Txt_Cantidad;
        private System.Windows.Forms.Label Lbl_Cantidad;
        private System.Windows.Forms.GroupBox Pnl_Datos_Generales;
        private System.Windows.Forms.Label Lbl_Costo;
        private System.Windows.Forms.ComboBox Cmb_Servicios;
        private System.Windows.Forms.ComboBox Cmb_Productos;
        private System.Windows.Forms.Label Lbl_Servicios;
        private System.Windows.Forms.Label Lbl_Productos;
        private System.Windows.Forms.TextBox Txt_Costo;
        private System.Windows.Forms.GroupBox Pnl_Datos_Grupo;
        private System.Windows.Forms.TextBox Txt_Persona_Tramita;
        private System.Windows.Forms.Label Lbl_Empresa;
        private System.Windows.Forms.Label Lbl_Persona_Tramita;
        private System.Windows.Forms.TextBox Txt_Empresa_Tramita;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Termino_Vigencia;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Inicio_Vigencia;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Tramite;
        private System.Windows.Forms.Label Lbl_Fecha_Tramite;
        private System.Windows.Forms.Label Lbl_Fecha_Inicio_Vigencia;
        private System.Windows.Forms.Label Lbl_Fecha_Termino_Vigencia;
        private System.Windows.Forms.ComboBox Cmb_Aplica_Dias_Festivos;
        private System.Windows.Forms.Label Lbl_Aplica_Dias_Festivos;
        private System.Windows.Forms.Button Btn_Agregar;
        private System.Windows.Forms.Button Btn_Consultar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.TextBox Txt_No_Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPRIMIR;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
    }
}