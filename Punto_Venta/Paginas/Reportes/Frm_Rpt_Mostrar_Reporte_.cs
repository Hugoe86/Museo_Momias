using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ERP_BASE.Paginas.Catalogos.Generales
{
    public partial class Frm_Rpt_Mostrar_Reporte_ : Form
    {
        private ReportDocument Reporte;
        private ParameterFields Parametros;

        public ParameterFields P_Parametros
        {
            get { return Parametros; }
            set { Parametros = value; }
        }

        public ReportDocument P_Reporte
        {
            get { return Reporte; }
            set { Reporte = value; }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Rpt_Mostrar_Reporte_
        ///DESCRIPCIÓN          : inicializa el crystal reports viewver
        ///PARÁMETROS           : 
        ///CREO                 : MNereida OM
        ///FECHA_CREO           : 08 Abril 2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        public Frm_Rpt_Mostrar_Reporte_()
        {
            this.Parametros = null;
            InitializeComponent();
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Crv_Visor_Reporte_Load
        ///DESCRIPCIÓN          : Genera el reporte en el crystal reports viewver
        ///PARÁMETROS           : 
        ///CREO                 : MNereida OM
        ///FECHA_CREO           : 08 Abril 2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Crv_Visor_Reporte_Load(object sender, EventArgs e)
        {
            if (this.Parametros != null)
            {
                this.Crv_Visor_Reporte.ParameterFieldInfo = Parametros;
            }

            this.Crv_Visor_Reporte.ReportSource = Reporte;
            this.Crv_Visor_Reporte.Refresh();
        }

        private void Btn_Excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog Archivo = new SaveFileDialog();

            if (Archivo.ShowDialog() == DialogResult.OK)
            {
                CrystalDecisions.Shared.ExportOptions Opt = new CrystalDecisions.Shared.ExportOptions();
                CrystalDecisions.Shared.ExcelFormatOptions Opt_Exc = new CrystalDecisions.Shared.ExcelFormatOptions();
                CrystalDecisions.Shared.DiskFileDestinationOptions Opt_Dsk = new CrystalDecisions.Shared.DiskFileDestinationOptions();

                Opt.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.Excel;
                Opt.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;

                Opt_Exc.ExcelUseConstantColumnWidth = false;
                Opt.ExportFormatOptions = Opt_Exc;

                Opt_Dsk.DiskFileName = Archivo.FileName;
                Opt.ExportDestinationOptions = Opt_Dsk;
                Reporte.Export(Opt);
            }
        }
    }
}
