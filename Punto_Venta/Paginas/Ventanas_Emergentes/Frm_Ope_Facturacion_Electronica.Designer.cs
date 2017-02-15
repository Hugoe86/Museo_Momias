namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    partial class Frm_Ope_Facturacion_Electronica
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Pnl_Filtro_Contribuyente = new System.Windows.Forms.GroupBox();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Consultar_Contribuyente = new System.Windows.Forms.Button();
            this.Txt_Filtro_Contribuyente = new System.Windows.Forms.TextBox();
            this.Opt_Filtro_Rfc = new System.Windows.Forms.RadioButton();
            this.Opt_Filtro_Curp = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_Referencia2 = new System.Windows.Forms.TextBox();
            this.Txt_Referencia1 = new System.Windows.Forms.TextBox();
            this.Lbl_Lista = new System.Windows.Forms.Label();
            this.Lbl_Tipo = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Txt_Apellido_Materno = new System.Windows.Forms.TextBox();
            this.Txt_Apellido_Paterno = new System.Windows.Forms.TextBox();
            this.Txt_Curp = new System.Windows.Forms.TextBox();
            this.Txt_Rfc = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Lbl_Apellido_Materno = new System.Windows.Forms.Label();
            this.Lbl_Apellido_Paterno = new System.Windows.Forms.Label();
            this.Lbl_Curp = new System.Windows.Forms.Label();
            this.Lbl_Rfc = new System.Windows.Forms.Label();
            this.Pnl_Filtro_Venta = new System.Windows.Forms.GroupBox();
            this.Btn_Solicitud = new System.Windows.Forms.Button();
            this.Btn_Facturar = new System.Windows.Forms.Button();
            this.Btn_Consultar_Venta = new System.Windows.Forms.Button();
            this.Txt_Filtro_Numero_Venta = new System.Windows.Forms.TextBox();
            this.Lbl_Filtro_Numero_Venta = new System.Windows.Forms.Label();
            this.Grid_Venta = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.Pnl_Filtro_Contribuyente.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Pnl_Filtro_Venta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Venta)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Pnl_Filtro_Contribuyente, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Pnl_Filtro_Venta, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Grid_Venta, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(657, 432);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Pnl_Filtro_Contribuyente
            // 
            this.Pnl_Filtro_Contribuyente.BackColor = System.Drawing.SystemColors.Window;
            this.Pnl_Filtro_Contribuyente.Controls.Add(this.Btn_Nuevo);
            this.Pnl_Filtro_Contribuyente.Controls.Add(this.Btn_Consultar_Contribuyente);
            this.Pnl_Filtro_Contribuyente.Controls.Add(this.Txt_Filtro_Contribuyente);
            this.Pnl_Filtro_Contribuyente.Controls.Add(this.Opt_Filtro_Rfc);
            this.Pnl_Filtro_Contribuyente.Controls.Add(this.Opt_Filtro_Curp);
            this.Pnl_Filtro_Contribuyente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_Filtro_Contribuyente.Location = new System.Drawing.Point(3, 3);
            this.Pnl_Filtro_Contribuyente.Name = "Pnl_Filtro_Contribuyente";
            this.Pnl_Filtro_Contribuyente.Size = new System.Drawing.Size(322, 102);
            this.Pnl_Filtro_Contribuyente.TabIndex = 0;
            this.Pnl_Filtro_Contribuyente.TabStop = false;
            this.Pnl_Filtro_Contribuyente.Text = "Filtro del contribuyente";
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Nuevo.Location = new System.Drawing.Point(242, 58);
            this.Btn_Nuevo.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(73, 30);
            this.Btn_Nuevo.TabIndex = 20;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Consultar_Contribuyente
            // 
            this.Btn_Consultar_Contribuyente.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Btn_Consultar_Contribuyente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Consultar_Contribuyente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Consultar_Contribuyente.Location = new System.Drawing.Point(167, 58);
            this.Btn_Consultar_Contribuyente.Name = "Btn_Consultar_Contribuyente";
            this.Btn_Consultar_Contribuyente.Size = new System.Drawing.Size(73, 30);
            this.Btn_Consultar_Contribuyente.TabIndex = 5;
            this.Btn_Consultar_Contribuyente.Text = "Consultar";
            this.Btn_Consultar_Contribuyente.UseVisualStyleBackColor = false;
            this.Btn_Consultar_Contribuyente.Click += new System.EventHandler(this.Btn_Consultar_Contribuyente_Click);
            // 
            // Txt_Filtro_Contribuyente
            // 
            this.Txt_Filtro_Contribuyente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Filtro_Contribuyente.Location = new System.Drawing.Point(26, 62);
            this.Txt_Filtro_Contribuyente.MaxLength = 20;
            this.Txt_Filtro_Contribuyente.Name = "Txt_Filtro_Contribuyente";
            this.Txt_Filtro_Contribuyente.Size = new System.Drawing.Size(135, 22);
            this.Txt_Filtro_Contribuyente.TabIndex = 2;
            this.Txt_Filtro_Contribuyente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Filtro_Contribuyente_KeyPress);
            // 
            // Opt_Filtro_Rfc
            // 
            this.Opt_Filtro_Rfc.AutoSize = true;
            this.Opt_Filtro_Rfc.Checked = true;
            this.Opt_Filtro_Rfc.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Opt_Filtro_Rfc.Location = new System.Drawing.Point(26, 34);
            this.Opt_Filtro_Rfc.Name = "Opt_Filtro_Rfc";
            this.Opt_Filtro_Rfc.Size = new System.Drawing.Size(47, 20);
            this.Opt_Filtro_Rfc.TabIndex = 0;
            this.Opt_Filtro_Rfc.TabStop = true;
            this.Opt_Filtro_Rfc.Text = "RFC";
            this.Opt_Filtro_Rfc.UseVisualStyleBackColor = true;
            // 
            // Opt_Filtro_Curp
            // 
            this.Opt_Filtro_Curp.AutoSize = true;
            this.Opt_Filtro_Curp.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Opt_Filtro_Curp.Location = new System.Drawing.Point(79, 34);
            this.Opt_Filtro_Curp.Name = "Opt_Filtro_Curp";
            this.Opt_Filtro_Curp.Size = new System.Drawing.Size(56, 20);
            this.Opt_Filtro_Curp.TabIndex = 1;
            this.Opt_Filtro_Curp.TabStop = true;
            this.Opt_Filtro_Curp.Text = "CURP";
            this.Opt_Filtro_Curp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_Referencia2);
            this.groupBox1.Controls.Add(this.Txt_Referencia1);
            this.groupBox1.Controls.Add(this.Lbl_Lista);
            this.groupBox1.Controls.Add(this.Lbl_Tipo);
            this.groupBox1.Controls.Add(this.Txt_Nombre);
            this.groupBox1.Controls.Add(this.Txt_Apellido_Materno);
            this.groupBox1.Controls.Add(this.Txt_Apellido_Paterno);
            this.groupBox1.Controls.Add(this.Txt_Curp);
            this.groupBox1.Controls.Add(this.Txt_Rfc);
            this.groupBox1.Controls.Add(this.Lbl_Nombre);
            this.groupBox1.Controls.Add(this.Lbl_Apellido_Materno);
            this.groupBox1.Controls.Add(this.Lbl_Apellido_Paterno);
            this.groupBox1.Controls.Add(this.Lbl_Curp);
            this.groupBox1.Controls.Add(this.Lbl_Rfc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 318);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del contribuyente";
            // 
            // Txt_Referencia2
            // 
            this.Txt_Referencia2.Enabled = false;
            this.Txt_Referencia2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Referencia2.Location = new System.Drawing.Point(126, 295);
            this.Txt_Referencia2.MaxLength = 20;
            this.Txt_Referencia2.Name = "Txt_Referencia2";
            this.Txt_Referencia2.Size = new System.Drawing.Size(157, 20);
            this.Txt_Referencia2.TabIndex = 14;
            this.Txt_Referencia2.Visible = false;
            // 
            // Txt_Referencia1
            // 
            this.Txt_Referencia1.Enabled = false;
            this.Txt_Referencia1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Referencia1.Location = new System.Drawing.Point(126, 269);
            this.Txt_Referencia1.MaxLength = 20;
            this.Txt_Referencia1.Name = "Txt_Referencia1";
            this.Txt_Referencia1.Size = new System.Drawing.Size(157, 20);
            this.Txt_Referencia1.TabIndex = 13;
            this.Txt_Referencia1.Visible = false;
            // 
            // Lbl_Lista
            // 
            this.Lbl_Lista.AutoSize = true;
            this.Lbl_Lista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Lista.Location = new System.Drawing.Point(16, 295);
            this.Lbl_Lista.Name = "Lbl_Lista";
            this.Lbl_Lista.Size = new System.Drawing.Size(74, 15);
            this.Lbl_Lista.TabIndex = 12;
            this.Lbl_Lista.Text = "Referencia2";
            this.Lbl_Lista.Visible = false;
            // 
            // Lbl_Tipo
            // 
            this.Lbl_Tipo.AutoSize = true;
            this.Lbl_Tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Tipo.Location = new System.Drawing.Point(16, 269);
            this.Lbl_Tipo.Name = "Lbl_Tipo";
            this.Lbl_Tipo.Size = new System.Drawing.Size(74, 15);
            this.Lbl_Tipo.TabIndex = 11;
            this.Lbl_Tipo.Text = "Referencia1";
            this.Lbl_Tipo.Visible = false;
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Enabled = false;
            this.Txt_Nombre.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(126, 162);
            this.Txt_Nombre.MaxLength = 20;
            this.Txt_Nombre.Multiline = true;
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(157, 38);
            this.Txt_Nombre.TabIndex = 10;
            // 
            // Txt_Apellido_Materno
            // 
            this.Txt_Apellido_Materno.Enabled = false;
            this.Txt_Apellido_Materno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Apellido_Materno.Location = new System.Drawing.Point(126, 119);
            this.Txt_Apellido_Materno.MaxLength = 20;
            this.Txt_Apellido_Materno.Multiline = true;
            this.Txt_Apellido_Materno.Name = "Txt_Apellido_Materno";
            this.Txt_Apellido_Materno.Size = new System.Drawing.Size(157, 37);
            this.Txt_Apellido_Materno.TabIndex = 9;
            // 
            // Txt_Apellido_Paterno
            // 
            this.Txt_Apellido_Paterno.Enabled = false;
            this.Txt_Apellido_Paterno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Apellido_Paterno.Location = new System.Drawing.Point(126, 77);
            this.Txt_Apellido_Paterno.MaxLength = 20;
            this.Txt_Apellido_Paterno.Multiline = true;
            this.Txt_Apellido_Paterno.Name = "Txt_Apellido_Paterno";
            this.Txt_Apellido_Paterno.Size = new System.Drawing.Size(157, 37);
            this.Txt_Apellido_Paterno.TabIndex = 8;
            // 
            // Txt_Curp
            // 
            this.Txt_Curp.Enabled = false;
            this.Txt_Curp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Curp.Location = new System.Drawing.Point(126, 47);
            this.Txt_Curp.MaxLength = 20;
            this.Txt_Curp.Name = "Txt_Curp";
            this.Txt_Curp.Size = new System.Drawing.Size(157, 20);
            this.Txt_Curp.TabIndex = 7;
            // 
            // Txt_Rfc
            // 
            this.Txt_Rfc.Enabled = false;
            this.Txt_Rfc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Rfc.Location = new System.Drawing.Point(126, 18);
            this.Txt_Rfc.MaxLength = 20;
            this.Txt_Rfc.Name = "Txt_Rfc";
            this.Txt_Rfc.Size = new System.Drawing.Size(157, 20);
            this.Txt_Rfc.TabIndex = 6;
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Nombre.Location = new System.Drawing.Point(16, 162);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(52, 15);
            this.Lbl_Nombre.TabIndex = 4;
            this.Lbl_Nombre.Text = "Nombre";
            // 
            // Lbl_Apellido_Materno
            // 
            this.Lbl_Apellido_Materno.AutoSize = true;
            this.Lbl_Apellido_Materno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Apellido_Materno.Location = new System.Drawing.Point(16, 119);
            this.Lbl_Apellido_Materno.Name = "Lbl_Apellido_Materno";
            this.Lbl_Apellido_Materno.Size = new System.Drawing.Size(100, 15);
            this.Lbl_Apellido_Materno.TabIndex = 3;
            this.Lbl_Apellido_Materno.Text = "Apellido Materno";
            // 
            // Lbl_Apellido_Paterno
            // 
            this.Lbl_Apellido_Paterno.AutoSize = true;
            this.Lbl_Apellido_Paterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Apellido_Paterno.Location = new System.Drawing.Point(16, 77);
            this.Lbl_Apellido_Paterno.Name = "Lbl_Apellido_Paterno";
            this.Lbl_Apellido_Paterno.Size = new System.Drawing.Size(97, 15);
            this.Lbl_Apellido_Paterno.TabIndex = 2;
            this.Lbl_Apellido_Paterno.Text = "Apellido Paterno";
            // 
            // Lbl_Curp
            // 
            this.Lbl_Curp.AutoSize = true;
            this.Lbl_Curp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Curp.Location = new System.Drawing.Point(16, 47);
            this.Lbl_Curp.Name = "Lbl_Curp";
            this.Lbl_Curp.Size = new System.Drawing.Size(33, 15);
            this.Lbl_Curp.TabIndex = 1;
            this.Lbl_Curp.Text = "Curp";
            // 
            // Lbl_Rfc
            // 
            this.Lbl_Rfc.AutoSize = true;
            this.Lbl_Rfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Rfc.Location = new System.Drawing.Point(16, 21);
            this.Lbl_Rfc.Name = "Lbl_Rfc";
            this.Lbl_Rfc.Size = new System.Drawing.Size(25, 15);
            this.Lbl_Rfc.TabIndex = 0;
            this.Lbl_Rfc.Text = "Rfc";
            // 
            // Pnl_Filtro_Venta
            // 
            this.Pnl_Filtro_Venta.Controls.Add(this.Btn_Solicitud);
            this.Pnl_Filtro_Venta.Controls.Add(this.Btn_Facturar);
            this.Pnl_Filtro_Venta.Controls.Add(this.Btn_Consultar_Venta);
            this.Pnl_Filtro_Venta.Controls.Add(this.Txt_Filtro_Numero_Venta);
            this.Pnl_Filtro_Venta.Controls.Add(this.Lbl_Filtro_Numero_Venta);
            this.Pnl_Filtro_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl_Filtro_Venta.Location = new System.Drawing.Point(331, 3);
            this.Pnl_Filtro_Venta.Name = "Pnl_Filtro_Venta";
            this.Pnl_Filtro_Venta.Size = new System.Drawing.Size(323, 100);
            this.Pnl_Filtro_Venta.TabIndex = 2;
            this.Pnl_Filtro_Venta.TabStop = false;
            this.Pnl_Filtro_Venta.Text = "Filtro Venta";
            // 
            // Btn_Solicitud
            // 
            this.Btn_Solicitud.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Btn_Solicitud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Solicitud.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Solicitud.Location = new System.Drawing.Point(9, 60);
            this.Btn_Solicitud.Name = "Btn_Solicitud";
            this.Btn_Solicitud.Size = new System.Drawing.Size(98, 28);
            this.Btn_Solicitud.TabIndex = 8;
            this.Btn_Solicitud.Text = "Solicitud";
            this.Btn_Solicitud.UseVisualStyleBackColor = false;
            this.Btn_Solicitud.Click += new System.EventHandler(this.Btn_Solicitud_Click);
            // 
            // Btn_Facturar
            // 
            this.Btn_Facturar.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Btn_Facturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Facturar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Facturar.Location = new System.Drawing.Point(113, 60);
            this.Btn_Facturar.Name = "Btn_Facturar";
            this.Btn_Facturar.Size = new System.Drawing.Size(210, 28);
            this.Btn_Facturar.TabIndex = 7;
            this.Btn_Facturar.Text = "Facturar";
            this.Btn_Facturar.UseVisualStyleBackColor = false;
            this.Btn_Facturar.Click += new System.EventHandler(this.Btn_Facturar_Click);
            // 
            // Btn_Consultar_Venta
            // 
            this.Btn_Consultar_Venta.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Btn_Consultar_Venta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Consultar_Venta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Consultar_Venta.Location = new System.Drawing.Point(230, 32);
            this.Btn_Consultar_Venta.Name = "Btn_Consultar_Venta";
            this.Btn_Consultar_Venta.Size = new System.Drawing.Size(93, 22);
            this.Btn_Consultar_Venta.TabIndex = 6;
            this.Btn_Consultar_Venta.Text = "Consultar";
            this.Btn_Consultar_Venta.UseVisualStyleBackColor = false;
            this.Btn_Consultar_Venta.Click += new System.EventHandler(this.Btn_Consultar_Venta_Click);
            // 
            // Txt_Filtro_Numero_Venta
            // 
            this.Txt_Filtro_Numero_Venta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Filtro_Numero_Venta.Location = new System.Drawing.Point(113, 33);
            this.Txt_Filtro_Numero_Venta.MaxLength = 10;
            this.Txt_Filtro_Numero_Venta.Name = "Txt_Filtro_Numero_Venta";
            this.Txt_Filtro_Numero_Venta.Size = new System.Drawing.Size(111, 22);
            this.Txt_Filtro_Numero_Venta.TabIndex = 6;
            this.Txt_Filtro_Numero_Venta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Filtro_Numero_Venta_KeyPress);
            // 
            // Lbl_Filtro_Numero_Venta
            // 
            this.Lbl_Filtro_Numero_Venta.AutoSize = true;
            this.Lbl_Filtro_Numero_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Filtro_Numero_Venta.Location = new System.Drawing.Point(6, 32);
            this.Lbl_Filtro_Numero_Venta.Name = "Lbl_Filtro_Numero_Venta";
            this.Lbl_Filtro_Numero_Venta.Size = new System.Drawing.Size(101, 15);
            this.Lbl_Filtro_Numero_Venta.TabIndex = 0;
            this.Lbl_Filtro_Numero_Venta.Text = "Numero de venta";
            // 
            // Grid_Venta
            // 
            this.Grid_Venta.AllowUserToAddRows = false;
            this.Grid_Venta.AllowUserToDeleteRows = false;
            this.Grid_Venta.AllowUserToResizeColumns = false;
            this.Grid_Venta.AllowUserToResizeRows = false;
            this.Grid_Venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Venta.Location = new System.Drawing.Point(331, 111);
            this.Grid_Venta.Name = "Grid_Venta";
            this.Grid_Venta.Size = new System.Drawing.Size(323, 318);
            this.Grid_Venta.TabIndex = 3;
            // 
            // Frm_Ope_Facturacion_Electronica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 456);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Ope_Facturacion_Electronica";
            this.Text = "Solicitud ";
            this.Load += new System.EventHandler(this.Frm_Ope_Facturacion_Electronica_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Pnl_Filtro_Contribuyente.ResumeLayout(false);
            this.Pnl_Filtro_Contribuyente.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Pnl_Filtro_Venta.ResumeLayout(false);
            this.Pnl_Filtro_Venta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Venta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox Pnl_Filtro_Contribuyente;
        private System.Windows.Forms.TextBox Txt_Filtro_Contribuyente;
        private System.Windows.Forms.RadioButton Opt_Filtro_Rfc;
        private System.Windows.Forms.RadioButton Opt_Filtro_Curp;
        private System.Windows.Forms.Button Btn_Consultar_Contribuyente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_Apellido_Paterno;
        private System.Windows.Forms.Label Lbl_Curp;
        private System.Windows.Forms.Label Lbl_Rfc;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.TextBox Txt_Apellido_Materno;
        private System.Windows.Forms.TextBox Txt_Apellido_Paterno;
        private System.Windows.Forms.TextBox Txt_Curp;
        private System.Windows.Forms.TextBox Txt_Rfc;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.Label Lbl_Apellido_Materno;
        private System.Windows.Forms.GroupBox Pnl_Filtro_Venta;
        private System.Windows.Forms.TextBox Txt_Filtro_Numero_Venta;
        private System.Windows.Forms.Label Lbl_Filtro_Numero_Venta;
        private System.Windows.Forms.Button Btn_Consultar_Venta;
        private System.Windows.Forms.DataGridView Grid_Venta;
        private System.Windows.Forms.Button Btn_Facturar;
        private System.Windows.Forms.TextBox Txt_Referencia2;
        private System.Windows.Forms.TextBox Txt_Referencia1;
        private System.Windows.Forms.Label Lbl_Lista;
        private System.Windows.Forms.Label Lbl_Tipo;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Solicitud;
    }
}