using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Erp.Constantes;
using Acceso_Museo.App_Code.Negocio;
using Acceso_Museo.App_Code.BD;

namespace Acceso_Museo.App_Code.Datos
{
    class Cls_Cat_Cajas_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Caja
        ///DESCRIPCIÓN          : Consulta informacion de una caja de la base de datos
        ///PARÁMETROS           : P_Caja que contiene los filtros de los productos a buscar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Caja(Cls_Cat_Cajas_Negocio P_Caja)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Mi_SQL.Append("SELECT * ");
                Mi_SQL.Append(" , CONCAT ('C', " + Cat_Cajas.Campo_Numero_Caja + ") as Caja_Numero");
                Mi_SQL.Append(" FROM " + Cat_Cajas.Tabla_Cat_Cajas);
                if (!String.IsNullOrEmpty(P_Caja.P_Caja_ID))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Caja_ID + " = '" + P_Caja.P_Caja_ID + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Numero_Caja))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Numero_Caja + " = '" + P_Caja.P_Numero_Caja + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Estatus))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Estatus + " = '" + P_Caja.P_Estatus + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Comentarios))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Comentarios + " LIKE '" + P_Caja.P_Comentarios + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Nombre_Equipo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Nombre_Equipo + " LIKE '" + P_Caja.P_Nombre_Equipo + "%'");
                    Segundo_Filtro = true;
                }

                BDMySQL BD = new BDMySQL();
                return BD.Consultar(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Caja : " + e.Message);
            }
        }
    }
}
