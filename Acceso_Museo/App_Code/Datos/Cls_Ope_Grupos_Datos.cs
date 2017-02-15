using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;
using Acceso_Museo.App_Code.Negocio;
using Acceso_Museo.App_Code.BD;

namespace Acceso_Museo.App_Code.Datos
{
    class Cls_Ope_Grupos_Datos
    {
        /// <summary>
        /// Nombre: Consultar_Grupos
        /// 
        /// Descripción: Método que realiza la consulta de los grupos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 10:34 a.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 24-feb-2014
        /// Causa Modificación: Se cambia el filtro por fecha para se para inicial y final
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static DataTable Consultar_Grupos(Cls_Ope_Grupos_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            
            try
            {
                Mi_SQL.Append(" select venta.*");
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Ventas.Tabla_Ope_Ventas + " venta ");

                if (!string.IsNullOrEmpty(Datos.P_Persona_Tramita))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(" UPPER(" + Ope_Ventas.Campo_Persona_Tramita + ") like UPPER('%" + Datos.P_Persona_Tramita + "%') ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Empresa))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(" UPPER(" + Ope_Ventas.Campo_Empresa + ") like UPPER('%" + Datos.P_Empresa + "%') ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(Ope_Ventas.Campo_Estatus + "='" + Datos.P_Estatus + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_No_Venta))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "' ");
                }

                if (Datos.P_Fecha_Inicio_Vigencia != DateTime.MinValue && Datos.P_Fecha_Termino_Vigencia != DateTime.MinValue)
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append("(" + Ope_Ventas.Campo_Fecha_Tramite + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio_Vigencia.AddDays(-1)) + " ");
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino_Vigencia) + ") ");
                }
                else if (Datos.P_Fecha_Inicio_Vigencia != DateTime.MinValue)
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append("(" + Ope_Ventas.Campo_Fecha_Tramite + " >= ");
                    Mi_SQL.Append(" " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio_Vigencia) + ") ");
                }
                else if (Datos.P_Fecha_Termino_Vigencia != DateTime.MinValue)
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append("(" + Ope_Ventas.Campo_Fecha_Tramite + " >= ");
                    Mi_SQL.Append(" " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino_Vigencia) + ") ");
                }

                Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                Mi_SQL.Append(Ope_Ventas.Campo_Persona_Tramita + " is not null ");

                BDMySQL BD = new BDMySQL();
                return BD.Consultar(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("Consultar_Grupos: " + Ex.Message);
            }
            finally
            {
            }
        }
    }
}
