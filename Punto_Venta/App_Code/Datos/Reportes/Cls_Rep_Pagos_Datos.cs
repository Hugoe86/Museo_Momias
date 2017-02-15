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
    class Cls_Rep_Pagos_Datos
    {
        #region Consulta

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Pagos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de la Consulta a ser ejecutada
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Pagos(Cls_Rep_Pagos_Negocio Pagos)
        {
            String Mi_SQL = "";
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL += "SELECT " + Ope_Pagos.Campo_No_Pago;
            Mi_SQL += ", " + Ope_Pagos.Campo_No_Venta;
            Mi_SQL += ", " + Ope_Pagos.Campo_No_Caja;
            // subconsulta nombre Forma de pago
            Mi_SQL += ", " + Ope_Pagos.Campo_Forma_ID;
            Mi_SQL += ", (SELECT " + Cat_Formas_Pago.Campo_Nombre + " FROM " + Cat_Formas_Pago.Tabla_Cat_Formas_Pago
                + " WHERE " + Cat_Formas_Pago.Campo_Forma_ID + "=" + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID + ") AS NOMBRE_FORMAS";
            // subconsulta nombre motivo de cancelacion
            Mi_SQL += ", " + Ope_Pagos.Campo_Motivo_ID;
            Mi_SQL += ", (SELECT " + Cat_Motivos_Cancelacion.Campo_Motivo + " FROM " + Cat_Motivos_Cancelacion.Tabla_Cat_Motivos_Cancelacion
                + " WHERE " + Cat_Motivos_Cancelacion.Campo_Motivo_ID + "=" + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Motivo_ID + ") AS NOMBRE_MOTIVO";

            Mi_SQL += ", " + Ope_Pagos.Campo_Monto_Pago;
            Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Transaccion;
            Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Cheque;
            Mi_SQL += ", " + Ope_Pagos.Campo_Referencia_Transferencia;
            Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Tarjeta_Banco;
            Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Cancelacion;
            Mi_SQL += ", " + Ope_Pagos.Campo_Estatus;
            Mi_SQL += ", " + Ope_Pagos.Campo_Usuario_Creo;
            Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Creo;
            Mi_SQL += ", " + Ope_Pagos.Campo_Usuario_Modifico;
            Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Modifico;
            Mi_SQL += " FROM " + Ope_Pagos.Tabla_Ope_Pagos + "";
            Mi_SQL += " WHERE ";
            if (Pagos.P_No_Pago != "" && Pagos.P_No_Pago != null)
            {
                Mi_SQL += Ope_Pagos.Campo_No_Pago + " = '" + Pagos.P_No_Pago + "' AND ";
            }
            if (Pagos.P_No_Venta != "" && Pagos.P_No_Venta != null)
            {
                Mi_SQL += Ope_Pagos.Campo_No_Venta + " = '" + Pagos.P_No_Venta + "' AND ";
            }
            if (Pagos.P_No_Caja != "" && Pagos.P_No_Caja != null)
            {
                Mi_SQL += Ope_Pagos.Campo_No_Caja + " = '" + Pagos.P_No_Caja + "' AND ";
            }
            if (Pagos.P_Forma_ID != "" && Pagos.P_Forma_ID != null)
            {
                Mi_SQL += Ope_Pagos.Campo_Forma_ID + " = '" + Pagos.P_Forma_ID + "' AND ";
            }
            if (Pagos.P_Motivo_ID != "" && Pagos.P_Motivo_ID != null)
            {
                Mi_SQL += Ope_Pagos.Campo_Motivo_ID + " = '" + Pagos.P_Motivo_ID + "' AND ";
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
