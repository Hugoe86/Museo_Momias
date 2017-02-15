using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Erp.Constantes;
using Acceso_Museo.App_Code.Negocio;
using Acceso_Museo.App_Code.BD;
using Erp.Ayudante_Sintaxis;

namespace Acceso_Museo.App_Code.Datos
{
    class Cls_Ope_Accesos_Datos
    {
        #region Métodos

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Actualizar_Estatus_Acceso
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para actualizar el estatus, hora_acceso y hora_salida 
        ///             de un acceso por no_acceso o numero_serie; regresa la cantidad de registros actualizados
        ///PARÁMETROS:
        /// 		1. Accesos: Instancia de Cls_Ope_Accesos_Negocio con los valores a actualizar
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 14-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static void Actualizar_Estatus_Acceso(Cls_Ope_Accesos_Negocio Accesos)
        {
            String Mi_SQL = "";

            // validar que se haya proporcionado por lo menos el no_acceso o el numero_serie
            if (string.IsNullOrEmpty(Accesos.P_No_Acceso) && string.IsNullOrEmpty(Accesos.P_Numero_Serie))
            {
                return ;
            }

            try
            {
                Mi_SQL += "UPDATE " + Ope_Accesos.Tabla_Ope_Accesos + " SET "
                    + Ope_Accesos.Campo_Usuario_Modifico + " = ''"
                    + ", " + Ope_Accesos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha();
                if (Accesos.P_Estatus != "" && Accesos.P_Estatus != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Estatus + " = '" + Accesos.P_Estatus + "'";
                }
                if (Accesos.P_Terminal_ID != "" && Accesos.P_Terminal_ID != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Terminal_ID + " = '" + Accesos.P_Terminal_ID + "'";
                }
                if (Accesos.P_Fecha_Hora_Acceso > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Acceso + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Accesos.P_Fecha_Hora_Acceso);
                }
                if (Accesos.P_Fecha_Hora_Salida > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Salida + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Accesos.P_Fecha_Hora_Salida);
                }
                Mi_SQL += "WHERE 1=1";
                // filtrar por no_acceso o por numero_serie
                if (!string.IsNullOrEmpty(Accesos.P_No_Acceso))
                {
                    Mi_SQL += " AND " + Ope_Accesos.Campo_No_Acceso + " = '" + Accesos.P_No_Acceso + "'";
                }
                if (!string.IsNullOrEmpty(Accesos.P_Numero_Serie))
                {
                    Mi_SQL += " AND " + Ope_Accesos.Campo_Numero_Serie + " = '" + Accesos.P_Numero_Serie + "'";
                }

                BDMySQL BD = new BDMySQL();

                BD.Cambiar(Mi_SQL);
            }
            catch (Exception E)
            {
                throw new Exception("Modificar_Acceso: " + E.Message);
            }
            finally
            {
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Accesos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : Accesos: Instancia de Cls_Ope_Accesos_Negocio con los valores de la Consulta a ser ejecutada
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static DataTable Consultar_Accesos(Cls_Ope_Accesos_Negocio Accesos)
        {
            String Mi_SQL;
            DataTable Dt_Consulta = new DataTable();

            try
            {
                Mi_SQL = "SELECT " + Ope_Accesos.Campo_No_Acceso;
                Mi_SQL += ", " + Ope_Accesos.Campo_No_Venta;
                Mi_SQL += ", " + Ope_Accesos.Campo_Producto_ID;
                // subconsulta nombre producto
                Mi_SQL += ", (SELECT " + Cat_Productos.Campo_Nombre + " FROM " + Cat_Productos.Tabla_Cat_Productos
                    + " WHERE " + Cat_Productos.Campo_Producto_Id + "=" + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Producto_ID + ") AS NOMBRE_PRODUCTO";
                Mi_SQL += ", " + Ope_Accesos.Campo_Terminal_ID;
                Mi_SQL += ", " + Ope_Accesos.Campo_Numero_Serie;
                Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Inicio;
                Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Fin;
                Mi_SQL += ", " + Ope_Accesos.Campo_Estatus;
                Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Acceso;
                Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Salida;
                Mi_SQL += ", " + Ope_Accesos.Campo_Tipo;
                Mi_SQL += ", " + Ope_Accesos.Campo_Usuario_Creo;
                Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Creo;
                Mi_SQL += ", " + Ope_Accesos.Campo_Usuario_Modifico;
                Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Modifico;
                Mi_SQL += " FROM " + Ope_Accesos.Tabla_Ope_Accesos;
                Mi_SQL += " WHERE ";
                if (Accesos.P_No_Acceso != "" && Accesos.P_No_Acceso != null)
                {
                    Mi_SQL += Ope_Accesos.Campo_No_Acceso + " = '" + Accesos.P_No_Acceso + "' AND ";
                }
                if (!string.IsNullOrEmpty(Accesos.P_Numero_Serie))
                {
                    Mi_SQL += Ope_Accesos.Campo_Numero_Serie + " = '" + Accesos.P_Numero_Serie + "' AND ";
                }
                if (!string.IsNullOrEmpty(Accesos.P_Estatus))
                {
                    Mi_SQL += Ope_Accesos.Campo_Estatus + " = '" + Accesos.P_Estatus + "' AND ";
                }
                if (Accesos.P_No_Venta != "" && Accesos.P_No_Venta != null)
                {
                    Mi_SQL += Ope_Accesos.Campo_No_Venta + " = '" + Accesos.P_No_Venta + "' AND ";
                }
                if (Accesos.P_Producto_ID != "" && Accesos.P_Producto_ID != null)
                {
                    Mi_SQL += Ope_Accesos.Campo_Producto_ID + " = '" + Accesos.P_Producto_ID + "' AND ";
                }
                if (Accesos.P_Terminal_ID != "" && Accesos.P_Terminal_ID != null)
                {
                    Mi_SQL += Ope_Accesos.Campo_Terminal_ID + " = '" + Accesos.P_Terminal_ID + "' AND ";
                }

                if (Mi_SQL.EndsWith(" WHERE "))
                {
                    Mi_SQL = Mi_SQL.Substring(0, Mi_SQL.Length - 7);
                }

                if (Mi_SQL.EndsWith(" AND "))
                {
                    Mi_SQL = Mi_SQL.Substring(0, Mi_SQL.Length - 5);
                }

                BDMySQL BD = new BDMySQL();

                return BD.Consultar(Mi_SQL);
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Acceso: " + e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Consultar_Accesos_Apertura()
        {
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                Mi_Sql.Append("SELECT * FROM " + Ope_Accesos.Tabla_Ope_Accesos);
                Mi_Sql.Append(" WHERE MONTH(" + Ope_Accesos.Campo_Fecha_Creo + ")");
                Mi_Sql.Append(" = " + DateTime.Now.Month);
                Mi_Sql.Append(" AND YEAR(" + Ope_Accesos.Campo_Fecha_Creo + ")");
                Mi_Sql.Append(" = " + DateTime.Now.Year);

                BDMySQL BD = new BDMySQL();
                BD.Consultar(Mi_Sql.ToString());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion Consulta
    }
}
