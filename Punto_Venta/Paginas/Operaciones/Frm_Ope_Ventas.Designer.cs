namespace ERP_BASE.Paginas.Operaciones
{
    partial class Frm_Ope_Ventas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ope_Ventas));
            this.Fra_Detalles_Venta = new System.Windows.Forms.GroupBox();
            this.Grid_Detalles_Ventas = new System.Windows.Forms.DataGridView();
            this.CANTIDAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCTO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COSTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TIPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPRIMIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Txt_Codigo_Barras = new System.Windows.Forms.TextBox();
            this.Btn_Eliminar_Detalle = new System.Windows.Forms.Button();
            this.Btn_No1 = new System.Windows.Forms.Button();
            this.Btn_No4 = new System.Windows.Forms.Button();
            this.Btn_No7 = new System.Windows.Forms.Button();
            this.Btn_No8 = new System.Windows.Forms.Button();
            this.Btn_No5 = new System.Windows.Forms.Button();
            this.Btn_No2 = new System.Windows.Forms.Button();
            this.Btn_No9 = new System.Windows.Forms.Button();
            this.Btn_No6 = new System.Windows.Forms.Button();
            this.Btn_No3 = new System.Windows.Forms.Button();
            this.Fra_Productos = new System.Windows.Forms.GroupBox();
            this.Pnl_Productos = new System.Windows.Forms.FlowLayoutPanel();
            this.Fra_Totales = new System.Windows.Forms.GroupBox();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Lbl_Total_Precio = new System.Windows.Forms.Label();
            this.Lbl_Total = new System.Windows.Forms.Label();
            this.Pnl_Consultar_Grupo = new System.Windows.Forms.Panel();
            this.Btn_No0 = new System.Windows.Forms.Button();
            this.Btn_Borrar_Cantidad = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Fra_Servicios = new System.Windows.Forms.GroupBox();
            this.Pnl_Servicios = new System.Windows.Forms.FlowLayoutPanel();
            this.Txt_No_Compuesto = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Siguiente = new System.Windows.Forms.Button();
            this.Btn_Atras = new System.Windows.Forms.Button();
            this.Fra_Detalles_Venta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Detalles_Ventas)).BeginInit();
            this.Fra_Productos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.Fra_Servicios.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Fra_Detalles_Venta
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Fra_Detalles_Venta, 2);
            this.Fra_Detalles_Venta.Controls.Add(this.Grid_Detalles_Ventas);
            this.Fra_Detalles_Venta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fra_Detalles_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.129054F, System.Drawing.FontStyle.Bold);
            this.Fra_Detalles_Venta.Location = new System.Drawing.Point(3, 3);
            this.Fra_Detalles_Venta.Name = "Fra_Detalles_Venta";
            this.tableLayoutPanel1.SetRowSpan(this.Fra_Detalles_Venta, 10);
            this.Fra_Detalles_Venta.Size = new System.Drawing.Size(430, 544);
            this.Fra_Detalles_Venta.TabIndex = 0;
            this.Fra_Detalles_Venta.TabStop = false;
            this.Fra_Detalles_Venta.Text = "Venta";
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
            this.IMPRIMIR});
            this.Grid_Detalles_Ventas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid_Detalles_Ventas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.129054F, System.Drawing.FontStyle.Bold);
            this.Grid_Detalles_Ventas.Location = new System.Drawing.Point(3, 17);
            this.Grid_Detalles_Ventas.Name = "Grid_Detalles_Ventas";
            this.Grid_Detalles_Ventas.ReadOnly = true;
            this.Grid_Detalles_Ventas.Size = new System.Drawing.Size(424, 524);
            this.Grid_Detalles_Ventas.TabIndex = 0;
            // 
            // CANTIDAD
            // 
            this.CANTIDAD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CANTIDAD.FillWeight = 50F;
            this.CANTIDAD.HeaderText = "#";
            this.CANTIDAD.Name = "CANTIDAD";
            this.CANTIDAD.ReadOnly = true;
            // 
            // PRODUCTO
            // 
            this.PRODUCTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRODUCTO.FillWeight = 120F;
            this.PRODUCTO.HeaderText = "Nombre";
            this.PRODUCTO.Name = "PRODUCTO";
            this.PRODUCTO.ReadOnly = true;
            // 
            // PRODUCTO_ID
            // 
            this.PRODUCTO_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRODUCTO_ID.HeaderText = "Producto_Id";
            this.PRODUCTO_ID.Name = "PRODUCTO_ID";
            this.PRODUCTO_ID.ReadOnly = true;
            this.PRODUCTO_ID.Visible = false;
            // 
            // COSTO
            // 
            this.COSTO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.COSTO.DefaultCellStyle = dataGridViewCellStyle1;
            this.COSTO.FillWeight = 60F;
            this.COSTO.HeaderText = "Costo C/U";
            this.COSTO.Name = "COSTO";
            this.COSTO.ReadOnly = true;
            // 
            // TOTAL
            // 
            this.TOTAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TOTAL.DefaultCellStyle = dataGridViewCellStyle2;
            this.TOTAL.FillWeight = 60F;
            this.TOTAL.HeaderText = "Total";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            // 
            // TIPO
            // 
            this.TIPO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TIPO.HeaderText = "Tipo";
            this.TIPO.Name = "TIPO";
            this.TIPO.ReadOnly = true;
            this.TIPO.Visible = false;
            // 
            // IMPRIMIR
            // 
            this.IMPRIMIR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IMPRIMIR.HeaderText = "Imprimir";
            this.IMPRIMIR.Name = "IMPRIMIR";
            this.IMPRIMIR.ReadOnly = true;
            this.IMPRIMIR.Visible = false;
            // 
            // Txt_Codigo_Barras
            // 
            this.Txt_Codigo_Barras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Txt_Codigo_Barras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Txt_Codigo_Barras.Font = new System.Drawing.Font("Consolas", 27.38717F);
            this.Txt_Codigo_Barras.Location = new System.Drawing.Point(3, 553);
            this.Txt_Codigo_Barras.Multiline = true;
            this.Txt_Codigo_Barras.Name = "Txt_Codigo_Barras";
            this.Txt_Codigo_Barras.Size = new System.Drawing.Size(212, 49);
            this.Txt_Codigo_Barras.TabIndex = 10;
            this.Txt_Codigo_Barras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_Codigo_Barras.Visible = false;
            this.Txt_Codigo_Barras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Codigo_Barras_KeyPress);
            // 
            // Btn_Eliminar_Detalle
            // 
            this.Btn_Eliminar_Detalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Eliminar_Detalle.Font = new System.Drawing.Font("Arial", 16.43231F);
            this.Btn_Eliminar_Detalle.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Eliminar_Detalle.Image")));
            this.Btn_Eliminar_Detalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Eliminar_Detalle.Location = new System.Drawing.Point(221, 553);
            this.Btn_Eliminar_Detalle.Name = "Btn_Eliminar_Detalle";
            this.Btn_Eliminar_Detalle.Size = new System.Drawing.Size(212, 49);
            this.Btn_Eliminar_Detalle.TabIndex = 9;
            this.Btn_Eliminar_Detalle.Text = "Eliminar";
            this.Btn_Eliminar_Detalle.UseVisualStyleBackColor = true;
            this.Btn_Eliminar_Detalle.Click += new System.EventHandler(this.Btn_Eliminar_Detalle_Click);
            // 
            // Btn_No1
            // 
            this.Btn_No1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No1.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No1.Location = new System.Drawing.Point(439, 58);
            this.Btn_No1.Name = "Btn_No1";
            this.Btn_No1.Size = new System.Drawing.Size(130, 49);
            this.Btn_No1.TabIndex = 1;
            this.Btn_No1.Text = "1";
            this.Btn_No1.UseVisualStyleBackColor = true;
            this.Btn_No1.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No4
            // 
            this.Btn_No4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No4.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No4.Location = new System.Drawing.Point(439, 223);
            this.Btn_No4.Name = "Btn_No4";
            this.Btn_No4.Size = new System.Drawing.Size(130, 49);
            this.Btn_No4.TabIndex = 2;
            this.Btn_No4.Text = "4";
            this.Btn_No4.UseVisualStyleBackColor = true;
            this.Btn_No4.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No7
            // 
            this.Btn_No7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No7.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No7.Location = new System.Drawing.Point(439, 388);
            this.Btn_No7.Name = "Btn_No7";
            this.Btn_No7.Size = new System.Drawing.Size(130, 49);
            this.Btn_No7.TabIndex = 3;
            this.Btn_No7.Text = "7";
            this.Btn_No7.UseVisualStyleBackColor = true;
            this.Btn_No7.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No8
            // 
            this.Btn_No8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No8.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No8.Location = new System.Drawing.Point(439, 443);
            this.Btn_No8.Name = "Btn_No8";
            this.Btn_No8.Size = new System.Drawing.Size(130, 49);
            this.Btn_No8.TabIndex = 6;
            this.Btn_No8.Text = "8";
            this.Btn_No8.UseVisualStyleBackColor = true;
            this.Btn_No8.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No5
            // 
            this.Btn_No5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No5.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No5.Location = new System.Drawing.Point(439, 278);
            this.Btn_No5.Name = "Btn_No5";
            this.Btn_No5.Size = new System.Drawing.Size(130, 49);
            this.Btn_No5.TabIndex = 5;
            this.Btn_No5.Text = "5";
            this.Btn_No5.UseVisualStyleBackColor = true;
            this.Btn_No5.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No2
            // 
            this.Btn_No2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No2.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No2.Location = new System.Drawing.Point(439, 113);
            this.Btn_No2.Name = "Btn_No2";
            this.Btn_No2.Size = new System.Drawing.Size(130, 49);
            this.Btn_No2.TabIndex = 4;
            this.Btn_No2.Text = "2";
            this.Btn_No2.UseVisualStyleBackColor = true;
            this.Btn_No2.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No9
            // 
            this.Btn_No9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No9.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No9.Location = new System.Drawing.Point(439, 498);
            this.Btn_No9.Name = "Btn_No9";
            this.Btn_No9.Size = new System.Drawing.Size(130, 49);
            this.Btn_No9.TabIndex = 9;
            this.Btn_No9.Text = "9";
            this.Btn_No9.UseVisualStyleBackColor = true;
            this.Btn_No9.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No6
            // 
            this.Btn_No6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No6.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No6.Location = new System.Drawing.Point(439, 333);
            this.Btn_No6.Name = "Btn_No6";
            this.Btn_No6.Size = new System.Drawing.Size(130, 49);
            this.Btn_No6.TabIndex = 8;
            this.Btn_No6.Text = "6";
            this.Btn_No6.UseVisualStyleBackColor = true;
            this.Btn_No6.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_No3
            // 
            this.Btn_No3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No3.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No3.Location = new System.Drawing.Point(439, 168);
            this.Btn_No3.Name = "Btn_No3";
            this.Btn_No3.Size = new System.Drawing.Size(130, 49);
            this.Btn_No3.TabIndex = 7;
            this.Btn_No3.Text = "3";
            this.Btn_No3.UseVisualStyleBackColor = true;
            this.Btn_No3.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Fra_Productos
            // 
            this.Fra_Productos.Controls.Add(this.Pnl_Productos);
            this.Fra_Productos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fra_Productos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.129054F, System.Drawing.FontStyle.Bold);
            this.Fra_Productos.Location = new System.Drawing.Point(575, 3);
            this.Fra_Productos.Name = "Fra_Productos";
            this.tableLayoutPanel1.SetRowSpan(this.Fra_Productos, 10);
            this.Fra_Productos.Size = new System.Drawing.Size(515, 544);
            this.Fra_Productos.TabIndex = 35;
            this.Fra_Productos.TabStop = false;
            this.Fra_Productos.Text = "Productos";
            // 
            // Pnl_Productos
            // 
            this.Pnl_Productos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Productos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.129054F, System.Drawing.FontStyle.Bold);
            this.Pnl_Productos.Location = new System.Drawing.Point(3, 17);
            this.Pnl_Productos.Name = "Pnl_Productos";
            this.Pnl_Productos.Size = new System.Drawing.Size(509, 524);
            this.Pnl_Productos.TabIndex = 0;
            // 
            // Fra_Totales
            // 
            this.Fra_Totales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.129054F, System.Drawing.FontStyle.Bold);
            this.Fra_Totales.Location = new System.Drawing.Point(3, 492);
            this.Fra_Totales.Name = "Fra_Totales";
            this.Fra_Totales.Size = new System.Drawing.Size(442, 211);
            this.Fra_Totales.TabIndex = 36;
            this.Fra_Totales.TabStop = false;
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 16.43231F);
            this.Btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Salir.Image")));
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Salir.Location = new System.Drawing.Point(221, 663);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(212, 54);
            this.Btn_Salir.TabIndex = 25;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Nuevo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 16.43231F);
            this.Btn_Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Nuevo.Image")));
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Nuevo.Location = new System.Drawing.Point(3, 663);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(212, 54);
            this.Btn_Nuevo.TabIndex = 24;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Lbl_Total_Precio
            // 
            this.Lbl_Total_Precio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Total_Precio.Font = new System.Drawing.Font("Consolas", 23.96377F, System.Drawing.FontStyle.Bold);
            this.Lbl_Total_Precio.Location = new System.Drawing.Point(221, 605);
            this.Lbl_Total_Precio.Name = "Lbl_Total_Precio";
            this.Lbl_Total_Precio.Size = new System.Drawing.Size(212, 55);
            this.Lbl_Total_Precio.TabIndex = 23;
            this.Lbl_Total_Precio.Text = "$ 0.00";
            this.Lbl_Total_Precio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lbl_Total
            // 
            this.Lbl_Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Lbl_Total.Font = new System.Drawing.Font("Consolas", 21.90973F, System.Drawing.FontStyle.Bold);
            this.Lbl_Total.Location = new System.Drawing.Point(3, 605);
            this.Lbl_Total.Name = "Lbl_Total";
            this.Lbl_Total.Size = new System.Drawing.Size(212, 55);
            this.Lbl_Total.TabIndex = 22;
            this.Lbl_Total.Text = "Total";
            this.Lbl_Total.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pnl_Consultar_Grupo
            // 
            this.Pnl_Consultar_Grupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Consultar_Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.53147F);
            this.Pnl_Consultar_Grupo.Location = new System.Drawing.Point(439, 3);
            this.Pnl_Consultar_Grupo.Name = "Pnl_Consultar_Grupo";
            this.Pnl_Consultar_Grupo.Size = new System.Drawing.Size(130, 49);
            this.Pnl_Consultar_Grupo.TabIndex = 26;
            // 
            // Btn_No0
            // 
            this.Btn_No0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_No0.Font = new System.Drawing.Font("Courier New", 23.73554F, System.Drawing.FontStyle.Bold);
            this.Btn_No0.Location = new System.Drawing.Point(439, 553);
            this.Btn_No0.Name = "Btn_No0";
            this.Btn_No0.Size = new System.Drawing.Size(130, 49);
            this.Btn_No0.TabIndex = 28;
            this.Btn_No0.Text = "0";
            this.Btn_No0.UseVisualStyleBackColor = true;
            this.Btn_No0.Click += new System.EventHandler(this.Btn_Cantidades_Click);
            // 
            // Btn_Borrar_Cantidad
            // 
            this.Btn_Borrar_Cantidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Btn_Borrar_Cantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Borrar_Cantidad.Font = new System.Drawing.Font("Courier New", 23.96377F, System.Drawing.FontStyle.Bold);
            this.Btn_Borrar_Cantidad.Location = new System.Drawing.Point(439, 663);
            this.Btn_Borrar_Cantidad.Name = "Btn_Borrar_Cantidad";
            this.Btn_Borrar_Cantidad.Size = new System.Drawing.Size(130, 54);
            this.Btn_Borrar_Cantidad.TabIndex = 31;
            this.Btn_Borrar_Cantidad.Text = "C";
            this.Btn_Borrar_Cantidad.UseVisualStyleBackColor = true;
            this.Btn_Borrar_Cantidad.Click += new System.EventHandler(this.Btn_Borrar_Cantidad_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.tableLayoutPanel1.Controls.Add(this.Btn_Eliminar_Detalle, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.Txt_Codigo_Barras, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.Fra_Detalles_Venta, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Total_Precio, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Salir, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.Lbl_Total, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Borrar_Cantidad, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Nuevo, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No0, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.Fra_Servicios, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.Fra_Productos, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No9, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No8, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No7, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No5, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No4, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Pnl_Consultar_Grupo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Btn_No6, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.Txt_No_Compuesto, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.192874F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1093, 720);
            this.tableLayoutPanel1.TabIndex = 38;
            // 
            // Fra_Servicios
            // 
            this.Fra_Servicios.Controls.Add(this.Pnl_Servicios);
            this.Fra_Servicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Fra_Servicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.129054F, System.Drawing.FontStyle.Bold);
            this.Fra_Servicios.Location = new System.Drawing.Point(575, 608);
            this.Fra_Servicios.Name = "Fra_Servicios";
            this.tableLayoutPanel1.SetRowSpan(this.Fra_Servicios, 2);
            this.Fra_Servicios.Size = new System.Drawing.Size(515, 109);
            this.Fra_Servicios.TabIndex = 34;
            this.Fra_Servicios.TabStop = false;
            this.Fra_Servicios.Text = "Servicios";
            // 
            // Pnl_Servicios
            // 
            this.Pnl_Servicios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_Servicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.129054F, System.Drawing.FontStyle.Bold);
            this.Pnl_Servicios.Location = new System.Drawing.Point(3, 17);
            this.Pnl_Servicios.Name = "Pnl_Servicios";
            this.Pnl_Servicios.Size = new System.Drawing.Size(509, 89);
            this.Pnl_Servicios.TabIndex = 0;
            // 
            // Txt_No_Compuesto
            // 
            this.Txt_No_Compuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.68338F, System.Drawing.FontStyle.Bold);
            this.Txt_No_Compuesto.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Txt_No_Compuesto.Location = new System.Drawing.Point(439, 608);
            this.Txt_No_Compuesto.MaxLength = 6;
            this.Txt_No_Compuesto.Multiline = true;
            this.Txt_No_Compuesto.Name = "Txt_No_Compuesto";
            this.Txt_No_Compuesto.Size = new System.Drawing.Size(128, 46);
            this.Txt_No_Compuesto.TabIndex = 36;
            this.Txt_No_Compuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txt_No_Compuesto.Enter += new System.EventHandler(this.Txt_No_Compuesto_Enter);
            this.Txt_No_Compuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_No_Compuesto_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Btn_Siguiente);
            this.panel1.Controls.Add(this.Btn_Atras);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(575, 553);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 49);
            this.panel1.TabIndex = 37;
            // 
            // Btn_Siguiente
            // 
            this.Btn_Siguiente.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Siguiente.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Siguiente.Location = new System.Drawing.Point(364, 0);
            this.Btn_Siguiente.Name = "Btn_Siguiente";
            this.Btn_Siguiente.Size = new System.Drawing.Size(151, 49);
            this.Btn_Siguiente.TabIndex = 1;
            this.Btn_Siguiente.Text = "Siguiente";
            this.Btn_Siguiente.UseVisualStyleBackColor = true;
            this.Btn_Siguiente.Click += new System.EventHandler(this.Btn_Siguiente_Click);
            // 
            // Btn_Atras
            // 
            this.Btn_Atras.Dock = System.Windows.Forms.DockStyle.Left;
            this.Btn_Atras.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Atras.Location = new System.Drawing.Point(0, 0);
            this.Btn_Atras.Name = "Btn_Atras";
            this.Btn_Atras.Size = new System.Drawing.Size(151, 49);
            this.Btn_Atras.TabIndex = 0;
            this.Btn_Atras.Text = "Atrás";
            this.Btn_Atras.UseVisualStyleBackColor = true;
            this.Btn_Atras.Click += new System.EventHandler(this.Btn_Atras_Click);
            // 
            // Frm_Ope_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1093, 720);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Fra_Totales);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_Ope_Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Frm_Ope_Ventas_Load);
            this.Fra_Detalles_Venta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Detalles_Ventas)).EndInit();
            this.Fra_Productos.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.Fra_Servicios.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Detalles_Venta;
        private System.Windows.Forms.DataGridView Grid_Detalles_Ventas;
        private System.Windows.Forms.Button Btn_No1;
        private System.Windows.Forms.Button Btn_No4;
        private System.Windows.Forms.Button Btn_No7;
        private System.Windows.Forms.Button Btn_No8;
        private System.Windows.Forms.Button Btn_No5;
        private System.Windows.Forms.Button Btn_No2;
        private System.Windows.Forms.Button Btn_No9;
        private System.Windows.Forms.Button Btn_No6;
        private System.Windows.Forms.Button Btn_No3;
        private System.Windows.Forms.GroupBox Fra_Productos;
        private System.Windows.Forms.Button Btn_Eliminar_Detalle;
        private System.Windows.Forms.GroupBox Fra_Totales;
        private System.Windows.Forms.Label Lbl_Total_Precio;
        private System.Windows.Forms.Label Lbl_Total;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Panel Pnl_Consultar_Grupo;
        private System.Windows.Forms.FlowLayoutPanel Pnl_Productos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCTO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn COSTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn TIPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPRIMIR;
        private System.Windows.Forms.TextBox Txt_Codigo_Barras;
        private System.Windows.Forms.Button Btn_No0;
        private System.Windows.Forms.Button Btn_Borrar_Cantidad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox Txt_No_Compuesto;
        private System.Windows.Forms.GroupBox Fra_Servicios;
        private System.Windows.Forms.FlowLayoutPanel Pnl_Servicios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Siguiente;
        private System.Windows.Forms.Button Btn_Atras;
    }
}