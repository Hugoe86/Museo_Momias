namespace ERP_BASE.Paginas.Catalogos.Generales
{
    partial class Frm_Rpt_Mostrar_Reporte_
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
            this.Crv_Visor_Reporte = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // Crv_Visor_Reporte
            // 
            this.Crv_Visor_Reporte.ActiveViewIndex = -1;
            this.Crv_Visor_Reporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Crv_Visor_Reporte.Cursor = System.Windows.Forms.Cursors.Default;
            this.Crv_Visor_Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Crv_Visor_Reporte.Location = new System.Drawing.Point(0, 0);
            this.Crv_Visor_Reporte.Name = "Crv_Visor_Reporte";
            this.Crv_Visor_Reporte.Size = new System.Drawing.Size(916, 720);
            this.Crv_Visor_Reporte.TabIndex = 0;
            this.Crv_Visor_Reporte.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.Crv_Visor_Reporte.Load += new System.EventHandler(this.Crv_Visor_Reporte_Load);
            // 
            // Frm_Rpt_Mostrar_Reporte_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 720);
            this.Controls.Add(this.Crv_Visor_Reporte);
            this.Name = "Frm_Rpt_Mostrar_Reporte_";
            this.Text = "Frm_Rpt_Mostrar_Reporte_";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Crv_Visor_Reporte;
    }
}