namespace ERP_BASE.Paginas.Paginas_Generales
{
    partial class Frm_Cat_Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cat_Usuarios));
            this.Cmb_Busqueda_Tipo = new System.Windows.Forms.ComboBox();
            this.Fra_Datos_Generales = new System.Windows.Forms.GroupBox();
            this.Txt_Correo = new System.Windows.Forms.TextBox();
            this.Lbl_Correo = new System.Windows.Forms.Label();
            this.Dtp_Fecha_Baja = new System.Windows.Forms.DateTimePicker();
            this.Lbl_Fecha_Termino = new System.Windows.Forms.Label();
            this.Cmb_Rol = new System.Windows.Forms.ComboBox();
            this.Lbl_Rol = new System.Windows.Forms.Label();
            this.Txt_Comentarios = new System.Windows.Forms.TextBox();
            this.Lbl_Comentarios = new System.Windows.Forms.Label();
            this.Txt_Nombre_Usuario = new System.Windows.Forms.TextBox();
            this.Lbl_Nombre = new System.Windows.Forms.Label();
            this.Cmb_Estatus = new System.Windows.Forms.ComboBox();
            this.Lbl_Estatus = new System.Windows.Forms.Label();
            this.Txt_Usuario_ID = new System.Windows.Forms.TextBox();
            this.Lbl_Usuario_ID = new System.Windows.Forms.Label();
            this.Txt_Confirmar = new System.Windows.Forms.TextBox();
            this.Lbl_Confirmar = new System.Windows.Forms.Label();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Lbl_Password = new System.Windows.Forms.Label();
            this.Txt_Login = new System.Windows.Forms.TextBox();
            this.Lbl_Login = new System.Windows.Forms.Label();
            this.Fra_Buscar = new System.Windows.Forms.GroupBox();
            this.Btn_Regresar = new System.Windows.Forms.Button();
            this.Btn_Busqueda = new System.Windows.Forms.Button();
            this.Txt_Descripcion_Busqueda = new System.Windows.Forms.TextBox();
            this.Lbl_Descripcion_Busqueda = new System.Windows.Forms.Label();
            this.Lbl_Busqueda = new System.Windows.Forms.Label();
            this.Grb_Usuarios = new System.Windows.Forms.GroupBox();
            this.Grid_Usuarios = new System.Windows.Forms.DataGridView();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Btn_Modificar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Erp_Validaciones = new System.Windows.Forms.ErrorProvider(this.components);
            this.Fra_Login = new System.Windows.Forms.GroupBox();
            this.Lbl_Caja_Id = new System.Windows.Forms.Label();
            this.Cmb_Caja = new System.Windows.Forms.ComboBox();
            this.Fra_Datos_Generales.SuspendLayout();
            this.Fra_Buscar.SuspendLayout();
            this.Grb_Usuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Usuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).BeginInit();
            this.Fra_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cmb_Busqueda_Tipo
            // 
            this.Cmb_Busqueda_Tipo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cmb_Busqueda_Tipo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Busqueda_Tipo.FormattingEnabled = true;
            this.Cmb_Busqueda_Tipo.Items.AddRange(new object[] {
            "<-SELECCIONE->",
            "USUARIO_ID",
            "NOMBRE",
            "LOGIN"});
            this.Cmb_Busqueda_Tipo.Location = new System.Drawing.Point(96, 116);
            this.Cmb_Busqueda_Tipo.Name = "Cmb_Busqueda_Tipo";
            this.Cmb_Busqueda_Tipo.Size = new System.Drawing.Size(300, 24);
            this.Cmb_Busqueda_Tipo.TabIndex = 16;
            // 
            // Fra_Datos_Generales
            // 
            this.Fra_Datos_Generales.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Caja);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Caja_Id);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Correo);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Correo);
            this.Fra_Datos_Generales.Controls.Add(this.Dtp_Fecha_Baja);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Fecha_Termino);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Rol);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Rol);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Comentarios);
            this.Fra_Datos_Generales.Controls.Add(this.Txt_Nombre_Usuario);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Nombre);
            this.Fra_Datos_Generales.Controls.Add(this.Cmb_Estatus);
            this.Fra_Datos_Generales.Controls.Add(this.Lbl_Estatus);
            this.Fra_Datos_Generales.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Datos_Generales.Location = new System.Drawing.Point(5, 16);
            this.Fra_Datos_Generales.Name = "Fra_Datos_Generales";
            this.Fra_Datos_Generales.Size = new System.Drawing.Size(777, 231);
            this.Fra_Datos_Generales.TabIndex = 1;
            this.Fra_Datos_Generales.TabStop = false;
            this.Fra_Datos_Generales.Text = "Datos Generales";
            // 
            // Txt_Correo
            // 
            this.Txt_Correo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Correo.Location = new System.Drawing.Point(91, 72);
            this.Txt_Correo.MaxLength = 50;
            this.Txt_Correo.Name = "Txt_Correo";
            this.Txt_Correo.Size = new System.Drawing.Size(280, 22);
            this.Txt_Correo.TabIndex = 2;
            this.Txt_Correo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Correo_KeyPress);
            this.Txt_Correo.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Correo_Validating);
            // 
            // Lbl_Correo
            // 
            this.Lbl_Correo.AutoSize = true;
            this.Lbl_Correo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Correo.Location = new System.Drawing.Point(7, 75);
            this.Lbl_Correo.Name = "Lbl_Correo";
            this.Lbl_Correo.Size = new System.Drawing.Size(44, 14);
            this.Lbl_Correo.TabIndex = 20;
            this.Lbl_Correo.Text = "*E-mail";
            // 
            // Dtp_Fecha_Baja
            // 
            this.Dtp_Fecha_Baja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Dtp_Fecha_Baja.CalendarFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha_Baja.CustomFormat = "dd/MMM/yyyy";
            this.Dtp_Fecha_Baja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_Fecha_Baja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Fecha_Baja.Location = new System.Drawing.Point(486, 71);
            this.Dtp_Fecha_Baja.Name = "Dtp_Fecha_Baja";
            this.Dtp_Fecha_Baja.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Dtp_Fecha_Baja.Size = new System.Drawing.Size(280, 22);
            this.Dtp_Fecha_Baja.TabIndex = 3;
            // 
            // Lbl_Fecha_Termino
            // 
            this.Lbl_Fecha_Termino.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Fecha_Termino.AutoSize = true;
            this.Lbl_Fecha_Termino.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Fecha_Termino.Location = new System.Drawing.Point(406, 74);
            this.Lbl_Fecha_Termino.Name = "Lbl_Fecha_Termino";
            this.Lbl_Fecha_Termino.Size = new System.Drawing.Size(68, 14);
            this.Lbl_Fecha_Termino.TabIndex = 16;
            this.Lbl_Fecha_Termino.Text = "*Caducidad";
            // 
            // Cmb_Rol
            // 
            this.Cmb_Rol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cmb_Rol.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Rol.FormattingEnabled = true;
            this.Cmb_Rol.ItemHeight = 16;
            this.Cmb_Rol.Location = new System.Drawing.Point(91, 101);
            this.Cmb_Rol.Name = "Cmb_Rol";
            this.Cmb_Rol.Size = new System.Drawing.Size(675, 24);
            this.Cmb_Rol.TabIndex = 4;
            this.Cmb_Rol.Validating += new System.ComponentModel.CancelEventHandler(this.Cmb_Validating);
            // 
            // Lbl_Rol
            // 
            this.Lbl_Rol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Rol.AutoSize = true;
            this.Lbl_Rol.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Rol.Location = new System.Drawing.Point(7, 103);
            this.Lbl_Rol.Name = "Lbl_Rol";
            this.Lbl_Rol.Size = new System.Drawing.Size(28, 14);
            this.Lbl_Rol.TabIndex = 14;
            this.Lbl_Rol.Text = "*Rol";
            // 
            // Txt_Comentarios
            // 
            this.Txt_Comentarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Comentarios.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Comentarios.Location = new System.Drawing.Point(91, 132);
            this.Txt_Comentarios.MaxLength = 500;
            this.Txt_Comentarios.Multiline = true;
            this.Txt_Comentarios.Name = "Txt_Comentarios";
            this.Txt_Comentarios.Size = new System.Drawing.Size(675, 57);
            this.Txt_Comentarios.TabIndex = 5;
            this.Txt_Comentarios.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Comentarios_KeyPress);
            // 
            // Lbl_Comentarios
            // 
            this.Lbl_Comentarios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Comentarios.AutoSize = true;
            this.Lbl_Comentarios.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Comentarios.Location = new System.Drawing.Point(7, 135);
            this.Lbl_Comentarios.Name = "Lbl_Comentarios";
            this.Lbl_Comentarios.Size = new System.Drawing.Size(61, 14);
            this.Lbl_Comentarios.TabIndex = 18;
            this.Lbl_Comentarios.Text = "Comentario";
            // 
            // Txt_Nombre_Usuario
            // 
            this.Txt_Nombre_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Nombre_Usuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Nombre_Usuario.Location = new System.Drawing.Point(91, 43);
            this.Txt_Nombre_Usuario.MaxLength = 450;
            this.Txt_Nombre_Usuario.Name = "Txt_Nombre_Usuario";
            this.Txt_Nombre_Usuario.Size = new System.Drawing.Size(675, 22);
            this.Txt_Nombre_Usuario.TabIndex = 1;
            this.Txt_Nombre_Usuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Nombre_Usuario_KeyPress);
            this.Txt_Nombre_Usuario.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Validating);
            // 
            // Lbl_Nombre
            // 
            this.Lbl_Nombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Nombre.AutoSize = true;
            this.Lbl_Nombre.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Nombre.Location = new System.Drawing.Point(7, 47);
            this.Lbl_Nombre.Name = "Lbl_Nombre";
            this.Lbl_Nombre.Size = new System.Drawing.Size(55, 14);
            this.Lbl_Nombre.TabIndex = 6;
            this.Lbl_Nombre.Text = "*Nombre";
            // 
            // Cmb_Estatus
            // 
            this.Cmb_Estatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cmb_Estatus.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Estatus.Items.AddRange(new object[] {
            "ACTIVO",
            "BLOQUEADO",
            "INACTIVO"});
            this.Cmb_Estatus.Location = new System.Drawing.Point(486, 15);
            this.Cmb_Estatus.Name = "Cmb_Estatus";
            this.Cmb_Estatus.Size = new System.Drawing.Size(280, 24);
            this.Cmb_Estatus.TabIndex = 0;
            this.Cmb_Estatus.Validating += new System.ComponentModel.CancelEventHandler(this.Cmb_Validating);
            // 
            // Lbl_Estatus
            // 
            this.Lbl_Estatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Estatus.AutoSize = true;
            this.Lbl_Estatus.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Estatus.Location = new System.Drawing.Point(406, 18);
            this.Lbl_Estatus.Name = "Lbl_Estatus";
            this.Lbl_Estatus.Size = new System.Drawing.Size(52, 14);
            this.Lbl_Estatus.TabIndex = 2;
            this.Lbl_Estatus.Text = "*Estatus";
            // 
            // Txt_Usuario_ID
            // 
            this.Txt_Usuario_ID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Usuario_ID.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Usuario_ID.Location = new System.Drawing.Point(492, 51);
            this.Txt_Usuario_ID.Name = "Txt_Usuario_ID";
            this.Txt_Usuario_ID.Size = new System.Drawing.Size(280, 21);
            this.Txt_Usuario_ID.TabIndex = 9;
            this.Txt_Usuario_ID.Visible = false;
            // 
            // Lbl_Usuario_ID
            // 
            this.Lbl_Usuario_ID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Usuario_ID.AutoSize = true;
            this.Lbl_Usuario_ID.Font = new System.Drawing.Font("Arial", 8F);
            this.Lbl_Usuario_ID.Location = new System.Drawing.Point(412, 53);
            this.Lbl_Usuario_ID.Name = "Lbl_Usuario_ID";
            this.Lbl_Usuario_ID.Size = new System.Drawing.Size(56, 14);
            this.Lbl_Usuario_ID.TabIndex = 0;
            this.Lbl_Usuario_ID.Text = "Usuario ID";
            this.Lbl_Usuario_ID.Visible = false;
            // 
            // Txt_Confirmar
            // 
            this.Txt_Confirmar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Confirmar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Confirmar.Location = new System.Drawing.Point(492, 17);
            this.Txt_Confirmar.MaxLength = 20;
            this.Txt_Confirmar.Name = "Txt_Confirmar";
            this.Txt_Confirmar.PasswordChar = '*';
            this.Txt_Confirmar.ShortcutsEnabled = false;
            this.Txt_Confirmar.Size = new System.Drawing.Size(280, 22);
            this.Txt_Confirmar.TabIndex = 8;
            this.Txt_Confirmar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Confirmar_KeyPress);
            this.Txt_Confirmar.Leave += new System.EventHandler(this.Txt_Confirmar_Leave);
            this.Txt_Confirmar.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Validating);
            // 
            // Lbl_Confirmar
            // 
            this.Lbl_Confirmar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Confirmar.AutoSize = true;
            this.Lbl_Confirmar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Confirmar.Location = new System.Drawing.Point(412, 17);
            this.Lbl_Confirmar.Name = "Lbl_Confirmar";
            this.Lbl_Confirmar.Size = new System.Drawing.Size(67, 14);
            this.Lbl_Confirmar.TabIndex = 12;
            this.Lbl_Confirmar.Text = "*Confirmar";
            // 
            // Txt_Password
            // 
            this.Txt_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Password.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Password.Location = new System.Drawing.Point(97, 45);
            this.Txt_Password.MaxLength = 20;
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(280, 22);
            this.Txt_Password.TabIndex = 7;
            this.Txt_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Password_KeyPress);
            this.Txt_Password.Leave += new System.EventHandler(this.Txt_Password_Leave);
            this.Txt_Password.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Validating);
            // 
            // Lbl_Password
            // 
            this.Lbl_Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Password.AutoSize = true;
            this.Lbl_Password.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Password.Location = new System.Drawing.Point(13, 48);
            this.Lbl_Password.Name = "Lbl_Password";
            this.Lbl_Password.Size = new System.Drawing.Size(67, 14);
            this.Lbl_Password.TabIndex = 10;
            this.Lbl_Password.Text = "*Password";
            // 
            // Txt_Login
            // 
            this.Txt_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Login.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Login.Location = new System.Drawing.Point(97, 17);
            this.Txt_Login.MaxLength = 10;
            this.Txt_Login.Name = "Txt_Login";
            this.Txt_Login.Size = new System.Drawing.Size(280, 22);
            this.Txt_Login.TabIndex = 6;
            this.Txt_Login.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Login_KeyPress);
            this.Txt_Login.Leave += new System.EventHandler(this.Txt_Login_Leave);
            this.Txt_Login.Validating += new System.ComponentModel.CancelEventHandler(this.Txt_Validating);
            // 
            // Lbl_Login
            // 
            this.Lbl_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Login.AutoSize = true;
            this.Lbl_Login.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.Lbl_Login.Location = new System.Drawing.Point(13, 21);
            this.Lbl_Login.Name = "Lbl_Login";
            this.Lbl_Login.Size = new System.Drawing.Size(42, 14);
            this.Lbl_Login.TabIndex = 8;
            this.Lbl_Login.Text = "*Login";
            // 
            // Fra_Buscar
            // 
            this.Fra_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Fra_Buscar.Controls.Add(this.Btn_Regresar);
            this.Fra_Buscar.Controls.Add(this.Btn_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Txt_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Lbl_Descripcion_Busqueda);
            this.Fra_Buscar.Controls.Add(this.Cmb_Busqueda_Tipo);
            this.Fra_Buscar.Controls.Add(this.Lbl_Busqueda);
            this.Fra_Buscar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Buscar.Location = new System.Drawing.Point(5, 0);
            this.Fra_Buscar.Name = "Fra_Buscar";
            this.Fra_Buscar.Size = new System.Drawing.Size(782, 331);
            this.Fra_Buscar.TabIndex = 22;
            this.Fra_Buscar.TabStop = false;
            this.Fra_Buscar.Text = "Búsqueda";
            // 
            // Btn_Regresar
            // 
            this.Btn_Regresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Regresar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Regresar.Image = global::ERP_BASE.Properties.Resources.arrow_rotate_clockwise;
            this.Btn_Regresar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Regresar.Location = new System.Drawing.Point(664, 180);
            this.Btn_Regresar.Name = "Btn_Regresar";
            this.Btn_Regresar.Size = new System.Drawing.Size(77, 45);
            this.Btn_Regresar.TabIndex = 19;
            this.Btn_Regresar.Text = "Regresar";
            this.Btn_Regresar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Regresar.UseVisualStyleBackColor = true;
            this.Btn_Regresar.Click += new System.EventHandler(this.Btn_Regresar_Click);
            // 
            // Btn_Busqueda
            // 
            this.Btn_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Busqueda.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Busqueda.Image = global::ERP_BASE.Properties.Resources.bucar;
            this.Btn_Busqueda.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Busqueda.Location = new System.Drawing.Point(566, 180);
            this.Btn_Busqueda.Name = "Btn_Busqueda";
            this.Btn_Busqueda.Size = new System.Drawing.Size(77, 45);
            this.Btn_Busqueda.TabIndex = 18;
            this.Btn_Busqueda.Text = "Buscar";
            this.Btn_Busqueda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Busqueda.UseVisualStyleBackColor = true;
            this.Btn_Busqueda.Click += new System.EventHandler(this.Btn_Busqueda_Click);
            // 
            // Txt_Descripcion_Busqueda
            // 
            this.Txt_Descripcion_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Txt_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Descripcion_Busqueda.Location = new System.Drawing.Point(477, 119);
            this.Txt_Descripcion_Busqueda.MaxLength = 500;
            this.Txt_Descripcion_Busqueda.Multiline = true;
            this.Txt_Descripcion_Busqueda.Name = "Txt_Descripcion_Busqueda";
            this.Txt_Descripcion_Busqueda.Size = new System.Drawing.Size(300, 20);
            this.Txt_Descripcion_Busqueda.TabIndex = 17;
            this.Txt_Descripcion_Busqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_Descripcion_Busqueda_KeyPress);
            // 
            // Lbl_Descripcion_Busqueda
            // 
            this.Lbl_Descripcion_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Descripcion_Busqueda.AutoSize = true;
            this.Lbl_Descripcion_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Descripcion_Busqueda.Location = new System.Drawing.Point(398, 121);
            this.Lbl_Descripcion_Busqueda.Name = "Lbl_Descripcion_Busqueda";
            this.Lbl_Descripcion_Busqueda.Size = new System.Drawing.Size(80, 15);
            this.Lbl_Descripcion_Busqueda.TabIndex = 2;
            this.Lbl_Descripcion_Busqueda.Text = "*Descripción";
            // 
            // Lbl_Busqueda
            // 
            this.Lbl_Busqueda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Busqueda.AutoSize = true;
            this.Lbl_Busqueda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Lbl_Busqueda.Location = new System.Drawing.Point(18, 119);
            this.Lbl_Busqueda.Name = "Lbl_Busqueda";
            this.Lbl_Busqueda.Size = new System.Drawing.Size(75, 15);
            this.Lbl_Busqueda.TabIndex = 0;
            this.Lbl_Busqueda.Text = "*Buscar por";
            // 
            // Grb_Usuarios
            // 
            this.Grb_Usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grb_Usuarios.Controls.Add(this.Grid_Usuarios);
            this.Grb_Usuarios.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Grb_Usuarios.Location = new System.Drawing.Point(5, 337);
            this.Grb_Usuarios.Name = "Grb_Usuarios";
            this.Grb_Usuarios.Size = new System.Drawing.Size(777, 194);
            this.Grb_Usuarios.TabIndex = 13;
            this.Grb_Usuarios.TabStop = false;
            this.Grb_Usuarios.Text = "Usuarios";
            // 
            // Grid_Usuarios
            // 
            this.Grid_Usuarios.AllowUserToAddRows = false;
            this.Grid_Usuarios.AllowUserToDeleteRows = false;
            this.Grid_Usuarios.AllowUserToResizeRows = false;
            this.Grid_Usuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Usuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Grid_Usuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Usuarios.Location = new System.Drawing.Point(0, 22);
            this.Grid_Usuarios.Name = "Grid_Usuarios";
            this.Grid_Usuarios.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grid_Usuarios.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Usuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_Usuarios.Size = new System.Drawing.Size(777, 160);
            this.Grid_Usuarios.TabIndex = 10;
            this.Grid_Usuarios.SelectionChanged += new System.EventHandler(this.Grid_Usuarios_SelectionChanged);
            this.Grid_Usuarios.DoubleClick += new System.EventHandler(this.Grid_Usuarios_DoubleClick);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Salir.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Salir.Location = new System.Drawing.Point(666, 531);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(94, 51);
            this.Btn_Salir.TabIndex = 15;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Eliminar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Eliminar.Image = global::ERP_BASE.Properties.Resources.icono_eliminar;
            this.Btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Eliminar.Location = new System.Drawing.Point(524, 531);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(93, 51);
            this.Btn_Eliminar.TabIndex = 14;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.UseVisualStyleBackColor = true;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Buscar.Image")));
            this.Btn_Buscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Buscar.Location = new System.Drawing.Point(375, 531);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(94, 51);
            this.Btn_Buscar.TabIndex = 13;
            this.Btn_Buscar.Text = "Buscar";
            this.Btn_Buscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Btn_Modificar
            // 
            this.Btn_Modificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Modificar.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
            this.Btn_Modificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Modificar.Location = new System.Drawing.Point(206, 531);
            this.Btn_Modificar.Name = "Btn_Modificar";
            this.Btn_Modificar.Size = new System.Drawing.Size(96, 51);
            this.Btn_Modificar.TabIndex = 12;
            this.Btn_Modificar.Text = "Modificar";
            this.Btn_Modificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Modificar.UseVisualStyleBackColor = true;
            this.Btn_Modificar.Click += new System.EventHandler(this.Btn_Modificar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Nuevo.Font = new System.Drawing.Font("Arial", 9F);
            this.Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
            this.Btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Nuevo.Location = new System.Drawing.Point(48, 531);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(97, 51);
            this.Btn_Nuevo.TabIndex = 11;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.UseVisualStyleBackColor = true;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Erp_Validaciones
            // 
            this.Erp_Validaciones.ContainerControl = this;
            // 
            // Fra_Login
            // 
            this.Fra_Login.Controls.Add(this.Lbl_Login);
            this.Fra_Login.Controls.Add(this.Txt_Login);
            this.Fra_Login.Controls.Add(this.Lbl_Password);
            this.Fra_Login.Controls.Add(this.Txt_Password);
            this.Fra_Login.Controls.Add(this.Lbl_Confirmar);
            this.Fra_Login.Controls.Add(this.Txt_Confirmar);
            this.Fra_Login.Controls.Add(this.Txt_Usuario_ID);
            this.Fra_Login.Controls.Add(this.Lbl_Usuario_ID);
            this.Fra_Login.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.Fra_Login.Location = new System.Drawing.Point(5, 253);
            this.Fra_Login.Name = "Fra_Login";
            this.Fra_Login.Size = new System.Drawing.Size(777, 78);
            this.Fra_Login.TabIndex = 25;
            this.Fra_Login.TabStop = false;
            this.Fra_Login.Text = "Login";
            // 
            // Lbl_Caja_Id
            // 
            this.Lbl_Caja_Id.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lbl_Caja_Id.AutoSize = true;
            this.Lbl_Caja_Id.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Caja_Id.Location = new System.Drawing.Point(7, 195);
            this.Lbl_Caja_Id.Name = "Lbl_Caja_Id";
            this.Lbl_Caja_Id.Size = new System.Drawing.Size(37, 14);
            this.Lbl_Caja_Id.TabIndex = 21;
            this.Lbl_Caja_Id.Text = "* Caja";
            // 
            // Cmb_Caja
            // 
            this.Cmb_Caja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cmb_Caja.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Caja.FormattingEnabled = true;
            this.Cmb_Caja.ItemHeight = 16;
            this.Cmb_Caja.Location = new System.Drawing.Point(91, 195);
            this.Cmb_Caja.Name = "Cmb_Caja";
            this.Cmb_Caja.Size = new System.Drawing.Size(675, 24);
            this.Cmb_Caja.TabIndex = 22;
            // 
            // Frm_Cat_Usuarios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(794, 592);
            this.Controls.Add(this.Fra_Login);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Btn_Modificar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Fra_Datos_Generales);
            this.Controls.Add(this.Grb_Usuarios);
            this.Controls.Add(this.Fra_Buscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Cat_Usuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Frm_Cat_Usuarios_Load);
            this.Fra_Datos_Generales.ResumeLayout(false);
            this.Fra_Datos_Generales.PerformLayout();
            this.Fra_Buscar.ResumeLayout(false);
            this.Fra_Buscar.PerformLayout();
            this.Grb_Usuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Usuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Erp_Validaciones)).EndInit();
            this.Fra_Login.ResumeLayout(false);
            this.Fra_Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Fra_Datos_Generales;
        private System.Windows.Forms.TextBox Txt_Usuario_ID;
        private System.Windows.Forms.Label Lbl_Usuario_ID;
        private System.Windows.Forms.Label Lbl_Estatus;
        private System.Windows.Forms.Label Lbl_Login;
        private System.Windows.Forms.TextBox Txt_Nombre_Usuario;
        private System.Windows.Forms.Label Lbl_Nombre;
        private System.Windows.Forms.ComboBox Cmb_Estatus;
        private System.Windows.Forms.TextBox Txt_Login;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Label Lbl_Password;
        private System.Windows.Forms.TextBox Txt_Confirmar;
        private System.Windows.Forms.Label Lbl_Confirmar;
        private System.Windows.Forms.GroupBox Grb_Usuarios;
        private System.Windows.Forms.TextBox Txt_Comentarios;
        private System.Windows.Forms.Label Lbl_Comentarios;
        private System.Windows.Forms.Label Lbl_Rol;
        private System.Windows.Forms.Label Lbl_Fecha_Termino;
        private System.Windows.Forms.ComboBox Cmb_Rol;
        private System.Windows.Forms.DateTimePicker Dtp_Fecha_Baja;
        private System.Windows.Forms.DataGridView Grid_Usuarios;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Modificar;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.GroupBox Fra_Buscar;
        private System.Windows.Forms.Label Lbl_Busqueda;
        private System.Windows.Forms.Button Btn_Busqueda;
        private System.Windows.Forms.TextBox Txt_Descripcion_Busqueda;
        private System.Windows.Forms.Label Lbl_Descripcion_Busqueda;
        private System.Windows.Forms.Button Btn_Regresar;
        private System.Windows.Forms.ComboBox Cmb_Busqueda_Tipo;
        private System.Windows.Forms.ErrorProvider Erp_Validaciones;
        private System.Windows.Forms.TextBox Txt_Correo;
        private System.Windows.Forms.Label Lbl_Correo;
        private System.Windows.Forms.GroupBox Fra_Login;
        private System.Windows.Forms.Label Lbl_Caja_Id;
        private System.Windows.Forms.ComboBox Cmb_Caja;
    }
}