using System;
using System.Data;
using Erp.Principal.Datos;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for Cls_Apl_Principal
/// </summary>
namespace Erp.Principal.Negocio
{
    public class Cls_Apl_Principal_Negocio
    {
        #region (Variables)
            public String P_Nombre { get; set; }
            public String P_Estado { get; set; }
            public String P_Ciudad { get; set; }
            public String P_Domicilio { get; set; }
            public String P_Codigo_Postal { get; set; }
            public String P_Telefono { get; set; }
            public String P_Email { get; set; }
            public String P_Total { get; set; }
            public String P_Numero_Tarjeta { get; set; }
            public String P_Codigo_Seguridad { get; set; }
            public String P_Fecha_Expira { get; set; }
            public String P_Fecha { get; set; }
            public String P_Enviar_Email { get; set; }
            public String P_Numero_Transaccion { get; set; }
            public ArrayList P_Productos = new ArrayList();
            public DateTime P_Fecha_Visita { get; set; }
            public DataTable P_Dt_Productos { get; set; }

            //variables para la venta
            public DataTable P_Dt_Ventas { get; set; }
            public String P_No_Venta { get; set; }
            public decimal P_Subtotal { get; set; }
            public decimal P_Total_Venta { get; set; }
            public String P_Estatus { get; set; }
            public DateTime P_Fecha_Inicio_Vigencia { get; set; }
            public DateTime P_Fecha_Termino_Vigencia { get; set; }

            //variables pago
            public DataTable P_Dt_Pagos { get; set; }


        #endregion

        #region (Metodos)
            /// <summary>
            /// Consulta para obtener los tipos de productos y servicios
            /// </summary>
            /// <returns></returns>
            /// <creo>Leslie González Vázquez</creo>
            /// <fecha creo>21/Mayo/2014</fecha creo>
            public DataTable Consultar_Productos_Servicios()
            {
                return Cls_Apl_Principal_Datos.Consultar_Productos_Servicios(this);
            }

            /// <summary>
            /// Consulta para generar la venta, el pago y los accesos
            /// </summary>
            /// <returns></returns>
            /// <creo>Leslie González Vázquez</creo>
            /// <fecha creo>31/Mayo/2014</fecha creo>
            public Boolean Alta_Venta()
            {
                return Cls_Apl_Principal_Datos.Alta_Venta(this);
            }

            /// <summary>
            /// Consulta para obtener el id de la forma de pago de internet
            /// </summary>
            /// <returns></returns>
            /// <creo>Leslie González Vázquez</creo>
            /// <fecha creo>31/Mayo/2014</fecha creo>
            public String Obtener_Forma_Pago()
            {
                return Cls_Apl_Principal_Datos.Obtener_Forma_Pago();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public Cls_Apl_Principal_Negocio Consultar_Venta()
            {
                return Cls_Apl_Principal_Datos.Consultar_Venta(this);
            }
        #endregion
    }
}