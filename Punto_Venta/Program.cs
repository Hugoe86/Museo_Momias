using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ERP_BASE.Paginas.Paginas_Generales;
using ERP_BASE.Paginas.Operaciones;
using ERP_BASE.Paginas.Reportes;

namespace ERP_BASE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDI_Frm_Apl_Principal());
            //Application.Run(new Frm_Ope_Acceso());
        }
    }
}