namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Cat_Contactos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Contactos));
            this.label7 = new System.Windows.Forms.Label();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Fra_Campos = new System.Windows.Forms.GroupBox();
            this.Txt_Contacto_Id = new System.Windows.Forms.TextBox();
            this.Cmb_Proveedor = new System.Windows.Forms.ComboBox();
            this.Cmb_Clientes = new System.Windows.Forms.ComboBox();
            this.Lbl_Cliente = new System.Windows.Forms.Label();
            this.Lbl_Proveedor = new System.Windows.Forms.Label();
            this.Lbl_Apellido_Paterno = new System.Windows.Forms.Label();
            this.Lbl_Nombre_Comp = new System.Windows.Forms.Label();
            this.Txt_Nombre = new System.Windows.Forms.TextBox();
            this.Txt_Apellido_Materno = new System.Windows.Forms.TextBox();
            this.Txt_Puesto = new System.Windows.Forms.TextBox();
            this.Txt_Area = new System.Windows.Forms.TextBox();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Lbl_Puesto = new System.Windows.Forms.Label();
            this.Txt_Nombre_Completo = new System.Windows.Forms.TextBox();
            this.Txt_Apellido_Paterno = new System.Windows.Forms.TextBox();
            this.Lbl_Apellido_Materno = new System.Windows.Forms.Label();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Lbl_Area = new System.Windows.Forms.Label();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Lbl_Telefono1 = new System.Windows.Forms.Label();
            this.Lbl_Nextel = new System.Windows.Forms.Label();
            this.Txt_Telefono2 = new System.Windows.Forms.TextBox();
            this.Lbl_Contacto_Area = new System.Windows.Forms.Label();
            this.Txt_Contacto_Area = new System.Windows.Forms.TextBox();
            this.Cmb_Tipo_Contacto = new System.Windows.Forms.ComboBox();
            this.Txt_Nextel = new System.Windows.Forms.TextBox();
            this.Lbl_Tipo_Contacto = new System.Windows.Forms.Label();
            this.Txt_Telefono1 = new System.Windows.Forms.TextBox();
            this.Lbl_Telefono2 = new System.Windows.Forms.Label();
            this.Erp_Error_Provider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Grid_Contactos = new System.Windows.Forms.DataGridView();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Cmb_Giro_Busqueda = new System.Windows.Forms.ComboBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion = new System.Windows.Forms.Label();
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Fra_Contacto = new System.Windows.Forms.GroupBox();
            this.Fra_Tipo_Contacto = new System.Windows.Forms.GroupBox();
            this.Fra_Campos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Error_Provider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Contactos)).BeginInit();
            this.Fra_Buscar.SuspendLayout();
            this.Fra_Contacto.SuspendLayout();
            this.Fra_Tipo_Contacto.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 6;
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(20, 471);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(100, 60);
            this.Btn_Nuevo.TabIndex = 14;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(616, 471);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(100, 60);
            this.Btn_Salir.TabIndex = 18;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(310, 471);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(100, 60);
            this.Btn_Eliminar.TabIndex = 16;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(162, 471);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(100, 60);
            this.Btn_Modificar.TabIndex = 15;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Fra_Campos
            // 
            this.Fra_Campos.Controls.Add(this.Txt_Contacto_Id);
            this.Fra_Campos.Controls.Add(this.Cmb_Proveedor);
            this.Fra_Campos.Controls.Add(this.Cmb_Clientes);
            this.Fra_Campos.Controls.Add(this.Lbl_Cliente);
            this.Fra_Campos.Controls.Add(this.Lbl_Proveedor);
            this.Fra_Campos.Controls.Add(this.Lbl_Apellido_Paterno);
            this.Fra_Campos.Controls.Add(this.Lbl_Nombre_Comp);
            this.Fra_Campos.Controls.Add(this.Txt_Nombre);
            this.Fra_Campos.Controls.Add(this.Txt_Apellido_Materno);
            this.Fra_Campos.Controls.Add(this.Txt_Puesto);
            this.Fra_Campos.Controls.Add(this.Txt_Area);
            this.Fra_Campos.Controls.Add(this.Cmb_Estatus);
            this.Fra_Campos.Controls.Add(this.Lbl_Puesto);
            this.Fra_Campos.Controls.Add(this.Txt_Nombre_Completo);
            this.Fra_Campos.Controls.Add(this.Txt_Apellido_Paterno);
            this.Fra_Campos.Controls.Add(this.Lbl_Apellido_Materno);
            this.Fra_Campos.Controls.Add(this.Lbl_Nombre);
            this.Fra_Campos.Controls.Add(this.Lbl_Area);
            this.Fra_Campos.Controls.Add(this.Lbl_Estatus);
            this.Fra_Campos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Campos.Location = new System.Drawing.Point(11, 12);
            this.Fra_Campos.Name = "Fra_Campos";
            this.Fra_Campos.Size = new System.Drawing.Size(718, 158);
            this.Fra_Campos.TabIndex = 34;
            this.Fra_Campos.TabStop = false;
            this.Fra_Campos.Text = "Datos Generales";
            // 
            // Txt_Contacto_Id
            // 
            this.Txt_Contacto_Id.Location = new System.Drawing.Point(479, 162);
            this.Txt_Contacto_Id.Name = "Txt_Contacto_Id";
            this.Txt_Contacto_Id.Size = new System.Drawing.Size(233, 21);
            this.Txt_Contacto_Id.TabIndex = 60;
            this.Txt_Contacto_Id.Visible = false;
            // 
            // Cmb_Proveedor
            // 
            this.Cmb_Proveedor.Enabled = false;
            this.Cmb_Proveedor.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Proveedor.FormattingEnabled = true;
            this.Cmb_Proveedor.Location = new System.Drawing.Point(129, 42);
            this.Cmb_Proveedor.Name = "Cmb_Proveedor";
            this.Cmb_Proveedor.Size = new System.Drawing.Size(217, 24);
            this.Cmb_Proveedor.TabIndex = 3;
            // 
            // Cmb_Clientes
            // 
            this.Cmb_Clientes.Enabled = false;
            this.Cmb_Clientes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Clientes.FormattingEnabled = true;
            this.Cmb_Clientes.Location = new System.Drawing.Point(129, 14);
            this.Cmb_Clientes.Name = "Cmb_Clientes";
            this.Cmb_Clientes.Size = new System.Drawing.Size(217, 24);
            this.Cmb_Clientes.TabIndex = 1;
            // 
            // Lbl_Cliente
            // 
            this.Lbl_Cliente.AutoSize = true;
            this.Lbl_Cliente.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Cliente.Location = new System.Drawing.Point(7, 17);
            this.Lbl_Cliente.Name = "Lbl_Cliente";
            this.Lbl_Cliente.Size = new System.Drawing.Size(39, 14);
            this.Lbl_Cliente.TabIndex = 32;
            this.Lbl_Cliente.Text = "Cliente";
            // 
            // Lbl_Proveedor
            // 
            this.Lbl_Proveedor.AutoSize = true;
            this.Lbl_Proveedor.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Proveedor.Location = new System.Drawing.Point(7, 45);
            this.Lbl_Proveedor.Name = "Lbl_Proveedor";
            this.Lbl_Proveedor.Size = new System.Drawing.Size(57, 14);
            this.Lbl_Proveedor.TabIndex = 33;
            this.Lbl_Proveedor.Text = "Proveedor";
            // 
            // Lbl_Apellido_Paterno
            // 
            this.Lbl_Apellido_Paterno.AutoSize = true;
            this.Lbl_Apellido_Paterno.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Apellido_Paterno.Location = new System.Drawing.Point(7, 75);
            this.Lbl_Apellido_Paterno.Name = "Lbl_Apellido_Paterno";
            this.Lbl_Apellido_Paterno.Size = new System.Drawing.Size(102, 14);
            this.Lbl_Apellido_Paterno.TabIndex = 34;
            this.Lbl_Apellido_Paterno.Text = "*Apellido Paterno";
            // 
            // Lbl_Nombre_Comp
            // 
            this.Lbl_Nombre_Comp.AutoSize = true;
            this.Lbl_Nombre_Comp.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Nombre_Comp.Location = new System.Drawing.Point(7, 103);
            this.Lbl_Nombre_Comp.Name = "Lbl_Nombre_Comp";
            this.Lbl_Nombre_Comp.Size = new System.Drawing.Size(91, 14);
            this.Lbl_Nombre_Comp.TabIndex = 35;
            this.Lbl_Nombre_Comp.Text = "Nombre Completo";
            // 
            // Txt_Nombre
            // 
            this.Txt_Nombre.Enabled = false;
            this.Txt_Nombre.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre.Location = new System.Drawing.Point(479, 44);
            this.Txt_Nombre.Name = "Txt_Nombre";
            this.Txt_Nombre.Size = new System.Drawing.Size(233, 22);
            this.Txt_Nombre.TabIndex = 4;
            this.Txt_Nombre.TextChanged += new System.EventHandler(this.Txt_Nombre_TextChanged);
            this.Txt_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            this.Txt_Nombre.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Requerido_Validating);
            // 
            // Txt_Apellido_Materno
            // 
            this.Txt_Apellido_Materno.Enabled = false;
            this.Txt_Apellido_Materno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Apellido_Materno.Location = new System.Drawing.Point(479, 72);
            this.Txt_Apellido_Materno.Name = "Txt_Apellido_Materno";
            this.Txt_Apellido_Materno.Size = new System.Drawing.Size(233, 22);
            this.Txt_Apellido_Materno.TabIndex = 6;
            this.Txt_Apellido_Materno.TextChanged += new System.EventHandler(this.Txt_Apellido_Materno_TextChanged);
            this.Txt_Apellido_Materno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            this.Txt_Apellido_Materno.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Requerido_Validating);
            // 
            // Txt_Puesto
            // 
            this.Txt_Puesto.Enabled = false;
            this.Txt_Puesto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Puesto.Location = new System.Drawing.Point(479, 127);
            this.Txt_Puesto.Name = "Txt_Puesto";
            this.Txt_Puesto.Size = new System.Drawing.Size(233, 22);
            this.Txt_Puesto.TabIndex = 8;
            this.Txt_Puesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            // 
            // Txt_Area
            // 
            this.Txt_Area.Enabled = false;
            this.Txt_Area.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Area.Location = new System.Drawing.Point(131, 128);
            this.Txt_Area.Name = "Txt_Area";
            this.Txt_Area.Size = new System.Drawing.Size(217, 22);
            this.Txt_Area.TabIndex = 7;
            this.Txt_Area.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Enabled = false;
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.FormattingEnabled = true;
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "<-SELECCIONE->",
            "ACTIVO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(479, 14);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(233, 24);
            this.Cmb_Estatus.TabIndex = 2;
            this.Cmb_Estatus.Validating += new System.ComponentModel.CancelEventHandler(this.Cmb_Requerido_Validating);
            // 
            // Lbl_Puesto
            // 
            this.Lbl_Puesto.AutoSize = true;
            this.Lbl_Puesto.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Puesto.Location = new System.Drawing.Point(370, 130);
            this.Lbl_Puesto.Name = "Lbl_Puesto";
            this.Lbl_Puesto.Size = new System.Drawing.Size(40, 14);
            this.Lbl_Puesto.TabIndex = 50;
            this.Lbl_Puesto.Text = "Puesto";
            // 
            // Txt_Nombre_Completo
            // 
            this.Txt_Nombre_Completo.AcceptsTab = true;
            this.Txt_Nombre_Completo.Enabled = false;
            this.Txt_Nombre_Completo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre_Completo.Location = new System.Drawing.Point(129, 99);
            this.Txt_Nombre_Completo.Name = "Txt_Nombre_Completo";
            this.Txt_Nombre_Completo.Size = new System.Drawing.Size(583, 22);
            this.Txt_Nombre_Completo.TabIndex = 43;
            // 
            // Txt_Apellido_Paterno
            // 
            this.Txt_Apellido_Paterno.Enabled = false;
            this.Txt_Apellido_Paterno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Apellido_Paterno.Location = new System.Drawing.Point(129, 71);
            this.Txt_Apellido_Paterno.Name = "Txt_Apellido_Paterno";
            this.Txt_Apellido_Paterno.Size = new System.Drawing.Size(217, 22);
            this.Txt_Apellido_Paterno.TabIndex = 5;
            this.Txt_Apellido_Paterno.TextChanged += new System.EventHandler(this.Txt_Apellido_Materno_TextChanged);
            this.Txt_Apellido_Paterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            this.Txt_Apellido_Paterno.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Requerido_Validating);
            // 
            // Lbl_Apellido_Materno
            // 
            this.Lbl_Apellido_Materno.AutoSize = true;
            this.Lbl_Apellido_Materno.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Apellido_Materno.Location = new System.Drawing.Point(366, 75);
            this.Lbl_Apellido_Materno.Name = "Lbl_Apellido_Materno";
            this.Lbl_Apellido_Materno.Size = new System.Drawing.Size(105, 14);
            this.Lbl_Apellido_Materno.TabIndex = 48;
            this.Lbl_Apellido_Materno.Text = "*Apellido Materno";
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Nombre.Location = new System.Drawing.Point(366, 47);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(70, 14);
            this.Lbl_Nombre.TabIndex = 47;
            this.Lbl_Nombre.Text = "*Nombre(s)";
            // 
            // Lbl_Area
            // 
            this.Lbl_Area.AutoSize = true;
            this.Lbl_Area.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Area.Location = new System.Drawing.Point(7, 131);
            this.Lbl_Area.Name = "Lbl_Area";
            this.Lbl_Area.Size = new System.Drawing.Size(31, 14);
            this.Lbl_Area.TabIndex = 45;
            this.Lbl_Area.Text = "Area";
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Estatus.Location = new System.Drawing.Point(366, 19);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 46;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Lbl_Telefono1
            // 
            this.Lbl_Telefono1.AutoSize = true;
            this.Lbl_Telefono1.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Telefono1.Location = new System.Drawing.Point(7, 16);
            this.Lbl_Telefono1.Name = "Lbl_Telefono1";
            this.Lbl_Telefono1.Size = new System.Drawing.Size(54, 14);
            this.Lbl_Telefono1.TabIndex = 36;
            this.Lbl_Telefono1.Text = "Telefono1";
            // 
            // Lbl_Nextel
            // 
            this.Lbl_Nextel.AutoSize = true;
            this.Lbl_Nextel.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Nextel.Location = new System.Drawing.Point(7, 74);
            this.Lbl_Nextel.Name = "Lbl_Nextel";
            this.Lbl_Nextel.Size = new System.Drawing.Size(37, 14);
            this.Lbl_Nextel.TabIndex = 37;
            this.Lbl_Nextel.Text = "Nextel";
            // 
            // Txt_Telefono2
            // 
            this.Txt_Telefono2.Enabled = false;
            this.Txt_Telefono2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Telefono2.Location = new System.Drawing.Point(132, 41);
            this.Txt_Telefono2.Name = "Txt_Telefono2";
            this.Txt_Telefono2.Size = new System.Drawing.Size(214, 22);
            this.Txt_Telefono2.TabIndex = 10;
            this.Txt_Telefono2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numerico_KeyPress);
            // 
            // Lbl_Contacto_Area
            // 
            this.Lbl_Contacto_Area.AutoSize = true;
            this.Lbl_Contacto_Area.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Contacto_Area.Location = new System.Drawing.Point(6, 43);
            this.Lbl_Contacto_Area.Name = "Lbl_Contacto_Area";
            this.Lbl_Contacto_Area.Size = new System.Drawing.Size(92, 14);
            this.Lbl_Contacto_Area.TabIndex = 38;
            this.Lbl_Contacto_Area.Text = "Contacto del área";
            // 
            // Txt_Contacto_Area
            // 
            this.Txt_Contacto_Area.Enabled = false;
            this.Txt_Contacto_Area.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Contacto_Area.Location = new System.Drawing.Point(115, 41);
            this.Txt_Contacto_Area.Name = "Txt_Contacto_Area";
            this.Txt_Contacto_Area.Size = new System.Drawing.Size(233, 22);
            this.Txt_Contacto_Area.TabIndex = 13;
            this.Txt_Contacto_Area.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Alfanumerico_KeyPress);
            // 
            // Cmb_Tipo_Contacto
            // 
            this.Cmb_Tipo_Contacto.Enabled = false;
            this.Cmb_Tipo_Contacto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Tipo_Contacto.FormattingEnabled = true;
            this.Cmb_Tipo_Contacto.Items.AddRange(new object[] {
            "<SELECCIONE>",
            "EMPLEADO",
            "PROVEEDOR"});
            this.Cmb_Tipo_Contacto.Location = new System.Drawing.Point(115, 13);
            this.Cmb_Tipo_Contacto.Name = "Cmb_Tipo_Contacto";
            this.Cmb_Tipo_Contacto.Size = new System.Drawing.Size(233, 24);
            this.Cmb_Tipo_Contacto.TabIndex = 12;
            this.Cmb_Tipo_Contacto.Validating += new System.ComponentModel.CancelEventHandler(this.Cmb_Requerido_Validating);
            // 
            // Txt_Nextel
            // 
            this.Txt_Nextel.Enabled = false;
            this.Txt_Nextel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nextel.Location = new System.Drawing.Point(132, 69);
            this.Txt_Nextel.Name = "Txt_Nextel";
            this.Txt_Nextel.Size = new System.Drawing.Size(214, 22);
            this.Txt_Nextel.TabIndex = 11;
            this.Txt_Nextel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numerico_Nextel_KeyPress);
            this.Txt_Nextel.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Nextel_Validating);
            // 
            // Lbl_Tipo_Contacto
            // 
            this.Lbl_Tipo_Contacto.AutoSize = true;
            this.Lbl_Tipo_Contacto.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Tipo_Contacto.Location = new System.Drawing.Point(6, 16);
            this.Lbl_Tipo_Contacto.Name = "Lbl_Tipo_Contacto";
            this.Lbl_Tipo_Contacto.Size = new System.Drawing.Size(104, 14);
            this.Lbl_Tipo_Contacto.TabIndex = 51;
            this.Lbl_Tipo_Contacto.Text = "*Tipo de Contacto";
            // 
            // Txt_Telefono1
            // 
            this.Txt_Telefono1.Enabled = false;
            this.Txt_Telefono1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Telefono1.Location = new System.Drawing.Point(132, 13);
            this.Txt_Telefono1.Name = "Txt_Telefono1";
            this.Txt_Telefono1.Size = new System.Drawing.Size(214, 22);
            this.Txt_Telefono1.TabIndex = 9;
            this.Txt_Telefono1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Numerico_KeyPress);
            // 
            // Lbl_Telefono2
            // 
            this.Lbl_Telefono2.AutoSize = true;
            this.Lbl_Telefono2.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Telefono2.Location = new System.Drawing.Point(7, 43);
            this.Lbl_Telefono2.Name = "Lbl_Telefono2";
            this.Lbl_Telefono2.Size = new System.Drawing.Size(54, 14);
            this.Lbl_Telefono2.TabIndex = 49;
            this.Lbl_Telefono2.Text = "Telefono2";
            // 
            // Erp_Error_Provider
            // 
            this.Erp_Error_Provider.ContainerControl = this;
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Buscar.Location = new System.Drawing.Point(463, 471);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(100, 60);
            this.Btn_Buscar.TabIndex = 17;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Grid_Contactos
            // 
            this.Grid_Contactos.AllowUserToAddRows = false;
            this.Grid_Contactos.AllowUserToDeleteRows = false;
            this.Grid_Contactos.AllowUserToOrderColumns = true;
            this.Grid_Contactos.AllowUserToResizeRows = false;
            this.Grid_Contactos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Contactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Contactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Contactos.Location = new System.Drawing.Point(11, 301);
            this.Grid_Contactos.Name = "Grid_Contactos";
            this.Grid_Contactos.ReadOnly = true;
            this.Grid_Contactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Contactos.Size = new System.Drawing.Size(718, 163);
            this.Grid_Contactos.TabIndex = 19;
            this.Grid_Contactos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Contactos_CellContentClick);
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fra_Buscar.Controls.Add(this.Cmb_Giro_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(11, 12);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(718, 283);
            this.Fra_Buscar.TabIndex = 38;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            this.Fra_Buscar.Visible = false;
            // 
            // Cmb_Giro_Busqueda
            // 
            this.Cmb_Giro_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Giro_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Giro_Busqueda.FormattingEnabled = true;
            this.Cmb_Giro_Busqueda.Location = new System.Drawing.Point(457, 90);
            this.Cmb_Giro_Busqueda.Name = "Cmb_Giro_Busqueda";
            this.Cmb_Giro_Busqueda.Size = new System.Drawing.Size(255, 23);
            this.Cmb_Giro_Busqueda.TabIndex = 2;
            this.Cmb_Giro_Busqueda.Visible = false;
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(583, 149);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(77, 45);
            this.Btn_Regresar.TabIndex = 4;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Busqueda.Enabled = false;
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(475, 149);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(77, 45);
            this.Btn_Busqueda.TabIndex = 3;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(457, 90);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(255, 24);
            this.Txt_Descripcion_Busqueda.TabIndex = 2;
            // 
            // Lbl_Descripcion
            // 
            this.Lbl_Descripcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Lbl_Descripcion.AutoSize = true;
            this.Lbl_Descripcion.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion.Location = new System.Drawing.Point(352, 99);
            this.Lbl_Descripcion.Name = "Lbl_Descripcion";
            this.Lbl_Descripcion.Size = new System.Drawing.Size(76, 14);
            this.Lbl_Descripcion.TabIndex = 2;
            this.Lbl_Descripcion.Text = "*Descripción";
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Busqueda_Tipo.DisplayMember = "NOMBRE_CORTO";
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(91, 90);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(255, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 1;
            this.Cmb_Busqueda_Tipo.SelectedIndexChanged += new System.EventHandler(this.Cmb_Busqueda_Tipo_SelectedIndexChanged);
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(6, 98);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(71, 14);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Fra_Contacto
            // 
            this.Fra_Contacto.Controls.Add(this.Lbl_Telefono1);
            this.Fra_Contacto.Controls.Add(this.Txt_Telefono1);
            this.Fra_Contacto.Controls.Add(this.Lbl_Telefono2);
            this.Fra_Contacto.Controls.Add(this.Txt_Telefono2);
            this.Fra_Contacto.Controls.Add(this.Lbl_Nextel);
            this.Fra_Contacto.Controls.Add(this.Txt_Nextel);
            this.Fra_Contacto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Contacto.Location = new System.Drawing.Point(11, 176);
            this.Fra_Contacto.Name = "Fra_Contacto";
            this.Fra_Contacto.Size = new System.Drawing.Size(354, 111);
            this.Fra_Contacto.TabIndex = 39;
            this.Fra_Contacto.TabStop = false;
            this.Fra_Contacto.Text = "Contacto";
            // 
            // Fra_Tipo_Contacto
            // 
            this.Fra_Tipo_Contacto.Controls.Add(this.Lbl_Tipo_Contacto);
            this.Fra_Tipo_Contacto.Controls.Add(this.Cmb_Tipo_Contacto);
            this.Fra_Tipo_Contacto.Controls.Add(this.Lbl_Contacto_Area);
            this.Fra_Tipo_Contacto.Controls.Add(this.Txt_Contacto_Area);
            this.Fra_Tipo_Contacto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Tipo_Contacto.Location = new System.Drawing.Point(371, 176);
            this.Fra_Tipo_Contacto.Name = "Fra_Tipo_Contacto";
            this.Fra_Tipo_Contacto.Size = new System.Drawing.Size(357, 110);
            this.Fra_Tipo_Contacto.TabIndex = 40;
            this.Fra_Tipo_Contacto.TabStop = false;
            this.Fra_Tipo_Contacto.Text = "Tipo de Contacto";
            // 
            // Frm_Cat_Contactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 553);
            this.Controls.Add(this.Fra_Tipo_Contacto);
            this.Controls.Add(this.Fra_Contacto);
            this.Controls.Add(this.Grid_Contactos);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Fra_Campos);
            this.Controls.Add(this.Fra_Buscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Cat_Contactos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Contactos";
            this.Load += new System.EventHandler(this.Frm_Cat_Contactos_Load);
            this.Fra_Campos.ResumeLayout(false);
            this.Fra_Campos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Error_Provider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Contactos)).EndInit();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.Fra_Contacto.ResumeLayout(false);
            this.Fra_Contacto.PerformLayout();
            this.Fra_Tipo_Contacto.ResumeLayout(false);
            this.Fra_Tipo_Contacto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.GroupBox Fra_Campos;
        private System.Windows.Forms.TextBox Txt_Contacto_Id;
        private System.Windows.Forms.ComboBox Cmb_Proveedor;
        private System.Windows.Forms.ComboBox Cmb_Clientes;
        private System.Windows.Forms.Label Lbl_Cliente;
        private System.Windows.Forms.Label Lbl_Proveedor;
        private System.Windows.Forms.Label Lbl_Apellido_Paterno;
        private System.Windows.Forms.Label Lbl_Nombre_Comp;
        private System.Windows.Forms.TextBox Txt_Nombre;
        private System.Windows.Forms.Label Lbl_Telefono1;
        private System.Windows.Forms.TextBox Txt_Apellido_Materno;
        private System.Windows.Forms.Label Lbl_Nextel;
        private System.Windows.Forms.TextBox Txt_Telefono2;
        private System.Windows.Forms.Label Lbl_Contacto_Area;
        private System.Windows.Forms.TextBox Txt_Puesto;
        private System.Windows.Forms.TextBox Txt_Contacto_Area;
        private System.Windows.Forms.ComboBox Cmb_Tipo_Contacto;
        private System.Windows.Forms.TextBox Txt_Area;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.TextBox Txt_Nextel;
        private System.Windows.Forms.Label Lbl_Tipo_Contacto;
        private System.Windows.Forms.TextBox Txt_Telefono1;
        private System.Windows.Forms.Label Lbl_Puesto;
        private System.Windows.Forms.TextBox Txt_Nombre_Completo;
        private System.Windows.Forms.Label Lbl_Telefono2;
        private System.Windows.Forms.TextBox Txt_Apellido_Paterno;
        private System.Windows.Forms.Label Lbl_Apellido_Materno;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.Label Lbl_Area;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.ErrorProvider Erp_Error_Provider;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.DataGridView Grid_Contactos;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.ComboBox Cmb_Giro_Busqueda;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.Label Lbl_Busqueda;
        private System.Windows.Forms.GroupBox Fra_Contacto;
        private System.Windows.Forms.GroupBox Fra_Tipo_Contacto;
    }
}