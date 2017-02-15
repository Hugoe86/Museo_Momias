using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    public class Cls_Cat_Categorias_Negocio
    {
        public string P_Categoría_ID { get; set; }
        public string P_Nombre { get; set; }

        public void Actualizar()
        {
            Cls_Cat_Categorias_Datos.Actualizar(this);
        }

        public DataTable Cargar()
        {
            return Cls_Cat_Categorias_Datos.Cargar();
        }

        public void Guardar()
        {
            Cls_Cat_Categorias_Datos.Guardar(this);
        }
    }
}
