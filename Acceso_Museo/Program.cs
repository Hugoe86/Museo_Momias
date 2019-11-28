using System;
using System.Windows.Forms;
using Acceso_Museo.Paginas;

namespace Acceso_Museo
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
            Application.Run(new Frm_Acceso());
        }
    }
}
