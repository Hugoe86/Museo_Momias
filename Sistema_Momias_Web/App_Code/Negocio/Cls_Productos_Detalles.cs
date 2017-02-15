using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Cls_Productos_Detalles
/// </summary>
namespace Erp.Productos_Detalles
{
    public class Cls_Productos_Detalles
    {
        #region(Variables)
        public String Producto_Id { get; set; }
        public String Cantidad { get; set; }
        public String Subtotal { get; set; }
        public String Costo { get; set; }
        public String Tipo { get; set; }
        public String Descripcion { get; set; }
        public String Ruta_Imagen{ get; set; }
        public String Codigo { get; set; }
        #endregion
    }
}