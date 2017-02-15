using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acceso_Museo.App_Code.Negocio;
using Acceso_Museo.App_Code.BD;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;

namespace Acceso_Museo.App_Code.Datos
{
    class Cls_Cat_Dias_Feriados_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Dias
        ///DESCRIPCIÓN          : Consulta los dias que estén registrados en la base de datos
        ///PARÁMETROS           : P_Dia, contiene los filtros de los días a consultar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Dias(Cls_Cat_Dias_Feriados_Negocio P_Dia)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                Mi_SQL.Append("SELECT * FROM " + Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados + " WHERE 1 = 1 ");

                if (!String.IsNullOrEmpty(P_Dia.P_Dia_ID))
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Dia_ID + " = '" + P_Dia.P_Dia_ID + "'");
                }

                if (!String.IsNullOrEmpty(P_Dia.P_Descripcion))
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Descripcion + " LIKE '" + P_Dia.P_Descripcion + "%'");
                }

                if (!String.IsNullOrEmpty(P_Dia.P_Estatus))
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Estatus + " = '" + P_Dia.P_Estatus + "'");
                }

                if (P_Dia.P_Fecha != DateTime.MinValue && P_Dia.P_Fecha_Fin != DateTime.MinValue)
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Fecha + " = CAST(" + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Dia.P_Fecha) + " As Date)");
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Fecha_Fin + " = CAST(" + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Dia.P_Fecha_Fin) + " As Date)");
                    /*Mi_SQL.Append(" AND ( (" + Cat_Dias_Feriados.Campo_Anios + " = 'TODOS LOS AÑOS' AND SUBSTRING (CONVERT (VARCHAR (10), ");
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha + ", 101),1,5) = '" + P_Dia.P_Fecha.ToString("MM/dd") + "')");
                    Mi_SQL.Append(" OR cast(" + Cat_Dias_Feriados.Campo_Fecha + " As Date) = cast("
                        + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Dia.P_Fecha) + " As Date))");*/
                }

                BDMySQL BD = new BDMySQL();

                return BD.Consultar(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Dias : " + e.Message);
            }
            finally
            {
            }
        }
    }
}
