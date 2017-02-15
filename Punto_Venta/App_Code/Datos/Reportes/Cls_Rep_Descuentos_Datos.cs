using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Sesiones;
using ERP_BASE.App_Code.Negocio.Reportes;
using ERP_BASE.Paginas.Paginas_Generales;


namespace ERP_BASE.App_Code.Datos.Reportes
{
    class Cls_Rep_Descuentos_Datos
    {
        #region Consulta
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Descuentos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : Descuentos: Instancia de Cls_Ope_Descuentos_Negocio con los valores de la Consulta a ser ejecutada
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Descuentos(Cls_Rep_Descuentos_Negocio Descuentos)
        {
            String Mi_SQL = "";
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL += "SELECT " + Ope_Descuentos.Campo_No_Descuento;
            Mi_SQL += ", " + Ope_Descuentos.Campo_No_Pago;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Cantidad;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Monto_Pago;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Descuento_Pago;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Total_Pagar;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Descuento;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Vencimiento;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fundamento_Legal;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Observaciones;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Realizo;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Usuario_Creo;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Creo;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Usuario_Modifico;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Modifico;
            Mi_SQL += " FROM " + Ope_Descuentos.Tabla_Ope_Descuentos + "";
            Mi_SQL += " WHERE ";
            if (Descuentos.P_No_Descuento != "" && Descuentos.P_No_Descuento != null)
            {
                Mi_SQL += Ope_Descuentos.Campo_No_Descuento + " = '" + Descuentos.P_No_Descuento + "' AND ";
            }
            if (Descuentos.P_No_Pago != "" && Descuentos.P_No_Pago != null)
            {
                Mi_SQL += Ope_Descuentos.Campo_No_Pago + " = '" + Descuentos.P_No_Pago + "' AND ";
            }
            if (Descuentos.P_Fecha_Descuento > DateTime.MinValue)
            {
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Descuento + " >= " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Descuento) + " AND ";
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Descuento + " < " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Descuento.AddDays(1)) + " AND ";
            }
            if (Descuentos.P_Fecha_Vencimiento > DateTime.MinValue)
            {
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Vencimiento + " >= " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Vencimiento) + " AND ";
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Vencimiento + " < " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Vencimiento.AddDays(1)) + " AND ";
            }
            if (Descuentos.P_Realizo != "" && Descuentos.P_Realizo != null)
            {
                Mi_SQL += Ope_Descuentos.Campo_Realizo + " = '" + Descuentos.P_Realizo + "' AND ";
            }

            if (Mi_SQL.EndsWith(" WHERE "))
            {
                Mi_SQL = Mi_SQL.Substring(0, Mi_SQL.Length - 7);
            }

            if (Mi_SQL.EndsWith(" AND "))
            {
                Mi_SQL = Mi_SQL.Substring(0, Mi_SQL.Length - 5);
            }

            Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Consulta;
        }

        #endregion Consulta
    }
}
