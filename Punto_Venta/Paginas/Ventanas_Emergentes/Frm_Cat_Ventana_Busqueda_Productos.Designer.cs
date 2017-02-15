namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    partial class Frm_Cat_Ventana_Busqueda_Productos
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
            this.Pnl_Filtros_Busqueda = new System.Windows.Forms.GroupBox();
            this.Pnl_Resultado_Busqueda = new System.Windows.Forms.GroupBox();
            this.Grid_Productos = new System.Windows.Forms.DataGridView();
            this.Lbl_Nombre_Producto = new System.Windows.Forms.Label();
            this.Txt_Nombre_Producto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Tipo_Producto = new System.Windows.Forms.ComboBox();
            this.Btn_Consultar_Productos = new System.Windows.Forms.Button();
            this.Pnl_Filtros_Busqueda.SuspendLayout();
            this.Pnl_Resultado_Busqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Productos)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_Filtros_Busqueda
            // 
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Btn_Consultar_Productos);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Cmb_Tipo_Producto);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.label1);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Txt_Nombre_Producto);
            this.Pnl_Filtros_Busqueda.Controls.Add(this.Lbl_Nombre_Producto);
            this.Pnl_Filtros_Busqueda.Location = new System.Drawing.Point(13, 13);
            this.Pnl_Filtros_Busqueda.Name = "Pnl_Filtros_Busqueda";
            this.Pnl_Filtros_Busqueda.Size = new System.Drawing.Size(756, 95);
            this.Pnl_Filtros_Busqueda.TabIndex = 0;
            this.Pnl_Filtros_Busqueda.TabStop = false;
            this.Pnl_Filtros_Busqueda.Text = "Filtros Busqueda";
            // 
            // Pnl_Resultado_Busqueda
            // 
            this.Pnl_Resultado_Busqueda.Controls.Add(this.Grid_Productos);
            this.Pnl_Resultado_Busqueda.Location = new System.Drawing.Point(13, 114);
            this.Pnl_Resultado_Busqueda.Name = "Pnl_Resultado_Busqueda";
            this.Pnl_Resultado_Busqueda.Size = new System.Drawing.Size(756, 459);
            this.Pnl_Resultado_Busqueda.TabIndex = 1;
            this.Pnl_Resultado_Busqueda.TabStop = false;
            this.Pnl_Resultado_Busqueda.Text = "Resultados de la Búsqueda";
            // 
            // Grid_Productos
            // 
            this.Grid_Productos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Grid_Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Productos.Location = new System.Drawing.Point(13, 22);
            this.Grid_Productos.Name = "Grid_Productos";
            this.Grid_Productos.Size = new System.Drawing.Size(730, 415);
            this.Grid_Productos.TabIndex = 0;
            this.Grid_Productos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Productos_CellClick);
            // 
            // Lbl_Nombre_Producto
            // 
            this.Lbl_Nombre_Producto.AutoSize = true;
            this.Lbl_Nombre_Producto.Font = new System.Drawing.Font("Consolas", 11F);
            this.Lbl_Nombre_Producto.Location = new System.Drawing.Point(13, 20);
            this.Lbl_Nombre_Producto.Name = "Lbl_Nombre_Producto";
            this.Lbl_Nombre_Producto.Size = new System.Drawing.Size(128, 18);
            this.Lbl_Nombre_Producto.TabIndex = 0;
            this.Lbl_Nombre_Producto.Text = "Nombre Producto";
            // 
            // Txt_Nombre_Producto
            // 
            this.Txt_Nombre_Producto.Font = new System.Drawing.Font("Consolas", 11F);
            this.Txt_Nombre_Producto.Location = new System.Drawing.Point(147, 17);
            this.Txt_Nombre_Producto.MaxLength = 100;
            this.Txt_Nombre_Producto.Name = "Txt_Nombre_Producto";
            this.Txt_Nombre_Producto.Size = new System.Drawing.Size(596, 25);
            this.Txt_Nombre_Producto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11F);
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo";
            // 
            // Cmb_Tipo_Producto
            // 
            this.Cmb_Tipo_Producto.Font = new System.Drawing.Font("Consolas", 11F);
            this.Cmb_Tipo_Producto.FormattingEnabled = true;
            this.Cmb_Tipo_Producto.Location = new System.Drawing.Point(147, 50);
            this.Cmb_Tipo_Producto.Name = "Cmb_Tipo_Producto";
            this.Cmb_Tipo_Producto.Size = new System.Drawing.Size(217, 26);
            this.Cmb_Tipo_Producto.TabIndex = 3;
            // 
            // Btn_Consultar_Productos
            // 
            this.Btn_Consultar_Productos.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Btn_Consultar_Productos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Consultar_Productos.Font = new System.Drawing.Font("Consolas", 11F);
            this.Btn_Consultar_Productos.Location = new System.Drawing.Point(530, 50);
            this.Btn_Consultar_Productos.Name = "Btn_Consultar_Productos";
            this.Btn_Consultar_Productos.Size = new System.Drawing.Size(213, 30);
            this.Btn_Consultar_Productos.TabIndex = 4;
            this.Btn_Consultar_Productos.Text = "Realizar Consulta";
            this.Btn_Consultar_Productos.UseVisualStyleBackColor = false;
            this.Btn_Consultar_Productos.Click += new System.EventHandler(this.Btn_Consultar_Productos_Click);
            // 
            // Frm_Cat_Ventana_Busqueda_Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(781, 583);
            this.Controls.Add(this.Pnl_Resultado_Busqueda);
            this.Controls.Add(this.Pnl_Filtros_Busqueda);
            this.Name = "Frm_Cat_Ventana_Busqueda_Productos";
            this.Text = "Busqueda Productos";
            this.Pnl_Filtros_Busqueda.ResumeLayout(false);
            this.Pnl_Filtros_Busqueda.PerformLayout();
            this.Pnl_Resultado_Busqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Productos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Pnl_Filtros_Busqueda;
        private System.Windows.Forms.GroupBox Pnl_Resultado_Busqueda;
        private System.Windows.Forms.DataGridView Grid_Productos;
        private System.Windows.Forms.Button Btn_Consultar_Productos;
        private System.Windows.Forms.ComboBox Cmb_Tipo_Producto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Nombre_Producto;
        private System.Windows.Forms.Label Lbl_Nombre_Producto;
    }
}