using Erp.Constantes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Operaciones.Reimpresion_Accesos.Datos;

namespace Operaciones.Reimpresion_Accesos.Negocio
{
    class Cls_Ope_Reimpresion_Accesos_Negocio
    {
        #region (Variables Privadas)
        private string No_Venta;
        private string Serie;
        
        private DataTable Dt_Accesos;

        private System.Windows.Forms.DataGridView Grid_Accesos;
        #endregion

        #region (Variables Publicas)
        public string P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public string P_Serie
        {
            get { return Serie; }
            set { Serie = value; }
        }
        public DataTable P_Dt_Accesos
        {
            get { return Dt_Accesos; }
            set { Dt_Accesos = value; }
        }
        public System.Windows.Forms.DataGridView P_Grid_Accesos
        {
            get { return Grid_Accesos; }
            set { Grid_Accesos = value; }
        }
        #endregion


        #region (Metodos)
        public String Realizar_Reimpresion()
        {
            return Cls_Ope_Reimpresion_Accesos_Datos.Realizar_Reimpresion(this);
        }
        #endregion

        #region (Consultas)
        public DataTable Consultar_Accesos() { return Cls_Ope_Reimpresion_Accesos_Datos.Consultar_Accesos(this); }
        #endregion
    }
}
