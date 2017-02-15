using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Nom_Areas.Negocio;
using Erp.Metodos_Generales;
using System.Text;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using Erp.Helper;
using System.Data;
using ERP_BASE.Paginas.Paginas_Generales;

/// <summary>
/// Summary description for Cls_Cat_Nom_Areas_Datos
/// </summary>

namespace Erp_Cat_Nom_Areas.Datos
{
    public class Cls_Cat_Nom_Areas_Datos
    {

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Alta_Area
        ///DESCRIPCIÓN: Da de alta en la Base de Datos Un nuevo proveedor
        ///PARAMENTROS:     
        ///             1. P_Area.          Instancia de la Clase de Negocio de Areas 
        ///                                 con los datos del que van a ser
        ///                                 dados de Alta.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 18/Feb/2013 10:45:00 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Alta_Area(Cls_Cat_Nom_Areas_Negocio P_Area)
        {
            Boolean Alta = false;
            StringBuilder Mi_sql = new StringBuilder(); ;
            String Area_Id = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Area_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Nom_Areas.Tabla_Cat_Nom_Areas, Cat_Nom_Areas.Campo_Area_Id, "", 5);
                Mi_sql.Append("INSERT INTO " + Cat_Nom_Areas.Tabla_Cat_Nom_Areas + "(");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Area_Id + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Centro_Costo_Id + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Nombre + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Descripcion + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Estatus + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Usuario_Creo + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Ip_Creo + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Equipo_Creo + ", ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Fecha_Creo);
                Mi_sql.Append(") VALUES (");
                Mi_sql.Append("'" + Area_Id + "', ");
                Mi_sql.Append("'" + P_Area.P_Centro_Costo_Id + "', ");
                Mi_sql.Append("'" + P_Area.P_Nombre + "', ");
                Mi_sql.Append("'" + P_Area.P_Descripcion + "', ");
                Mi_sql.Append("'" + P_Area.P_Estatus + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append("" + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Alta = true;
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Area: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Modificar_Area
        ///DESCRIPCIÓN: Modifica en la Base de Datos Un nuevo proveedor
        ///PARAMENTROS:     
        ///             1. P_Area.          Instancia de la Clase de Negocio de Areas 
        ///                                 con los datos del que van a ser
        ///                                 modificados.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 18/Feb/2013 11:20:00 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Modificar_Area(Cls_Cat_Nom_Areas_Negocio P_Area)
        {
            Boolean Modificado = false;
            StringBuilder Mi_sql = new StringBuilder(); 
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }
            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_sql.Append("UPDATE " + Cat_Nom_Areas.Tabla_Cat_Nom_Areas + " SET ");
                if (P_Area.P_Nombre != null && P_Area.P_Nombre.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Areas.Campo_Nombre + " = '" + P_Area.P_Nombre + "', ");
                if (P_Area.P_Centro_Costo_Id != null && P_Area.P_Centro_Costo_Id.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Areas.Campo_Centro_Costo_Id + " = '" + P_Area.P_Centro_Costo_Id + "', ");
                if (P_Area.P_Descripcion != null && P_Area.P_Descripcion.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Areas.Campo_Descripcion + " = '" + P_Area.P_Descripcion + "', ");
                if (P_Area.P_Estatus != null && P_Area.P_Estatus.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Areas.Campo_Estatus + " = '" + P_Area.P_Estatus + "', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Nom_Areas.Campo_Area_Id + " = '" + P_Area.P_Area_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Modificado = true;
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Area: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Modificado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Baja_Area
        ///DESCRIPCIÓN: Modifica el estatus en la Base de Datos de Un proveedor
        ///PARAMENTROS:     
        ///             1. P_Area.          Instancia de la Clase de Negocio de Areas 
        ///                                 con los datos del que van a ser
        ///                                 modificados.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 18/Feb/2013 11:30:00 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Baja_Area(Cls_Cat_Nom_Areas_Negocio P_Area)
        {
            Boolean Baja = false;
            StringBuilder Mi_sql = new StringBuilder();
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_sql.Append("UPDATE " + Cat_Nom_Areas.Tabla_Cat_Nom_Areas + " SET ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Estatus + " = 'ELIMINADO', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Nom_Areas.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Nom_Areas.Campo_Area_Id + " = '" + P_Area.P_Area_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Baja = true;
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Baja_Area: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Baja;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Areas
        ///DESCRIPCIÓN: Consulta los motivos de rechazo
        ///PARAMENTROS:     
        ///             1. P_Area.          Instancia de la Clase de Negocio de Puestos 
        ///                                 con los datos que servirán de
        ///                                 filtro.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 14/Febrero/2013 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static DataTable Consultar_Areas(Cls_Cat_Nom_Areas_Negocio P_Area)
        {
            DataTable Tabla = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
            String Aux_Filtros = "";

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {
                Mi_SQL.Append("SELECT AR." + Cat_Nom_Areas.Campo_Area_Id
                    + ", AR." + Cat_Nom_Areas.Campo_Centro_Costo_Id
                    + ", AR." + Cat_Nom_Areas.Campo_Nombre
                    + ", AR." + Cat_Nom_Areas.Campo_Descripcion
                    + ", AR." + Cat_Nom_Areas.Campo_Estatus
                    + ", AR." + Cat_Nom_Areas.Campo_Fecha_Creo
                    + ", AR." + Cat_Nom_Areas.Campo_Ip_Creo
                    + ", AR." + Cat_Nom_Areas.Campo_Equipo_Creo
                    + ", AR." + Cat_Nom_Areas.Campo_Usuario_Creo
                    + ", AR." + Cat_Nom_Areas.Campo_Fecha_Modifico
                    + ", AR." + Cat_Nom_Areas.Campo_Ip_Modifico
                    + ", AR." + Cat_Nom_Areas.Campo_Equipo_Modifico
                    + ", AR." + Cat_Nom_Areas.Campo_Usuario_Modifico
                    + " FROM  " + Cat_Nom_Areas.Tabla_Cat_Nom_Areas
                    + " AR WHERE ");
                if (P_Area.P_Nombre != null && P_Area.P_Nombre.Trim() != "")
                {
                    Mi_SQL.Append(" AR." + Cat_Nom_Areas.Campo_Nombre + " LIKE '%" + P_Area.P_Nombre + "%' AND ");
                }
                if (P_Area.P_Descripcion != null && P_Area.P_Descripcion.Trim() != "")
                {
                    Mi_SQL.Append(" AR." + Cat_Nom_Areas.Campo_Descripcion + " LIKE '%" + P_Area.P_Descripcion + "%' AND ");
                }
                if (P_Area.P_Estatus != null && P_Area.P_Estatus.Trim() != "")
                {
                    Mi_SQL.Append(" AR." + Cat_Nom_Areas.Campo_Estatus + P_Area.P_Estatus + " AND ");
                }
                if (P_Area.P_Area_Id != null && P_Area.P_Area_Id.Trim() != "")
                {
                    Mi_SQL.Append(" AR." + Cat_Nom_Areas.Campo_Area_Id + " = '" + P_Area.P_Area_Id + "' AND ");
                }
                if (P_Area.P_Nombre_Centro_Costo != null && P_Area.P_Nombre_Centro_Costo.Trim() != "")
                {
                    Mi_SQL.Append("AR." + Cat_Nom_Areas.Campo_Centro_Costo_Id + " IN (SELECT CC." + Cat_Nom_Centro_Costo.Campo_Centro_Costo_Id + " FROM " + Cat_Nom_Centro_Costo.Tabla_Cat_Nom_Centro_Costo + " CC WHERE CC." + Cat_Nom_Centro_Costo.Campo_Nombre + " LIKE '%" + P_Area.P_Nombre_Centro_Costo + "%') AND ");
                }
                if (Mi_SQL.ToString().EndsWith(" AND "))
                {
                    Aux_Filtros = Mi_SQL.ToString().Substring(0, Mi_SQL.Length - 5);
                    Mi_SQL.Length = 0;
                    Mi_SQL.Append(Aux_Filtros);
                }
                if (Mi_SQL.ToString().EndsWith(" WHERE "))
                {
                    Aux_Filtros = Mi_SQL.ToString().Substring(0, Mi_SQL.Length - 7);
                    Mi_SQL.Length = 0;
                    Mi_SQL.Append(Aux_Filtros);
                }
                // agregar filtro y orden a la consulta
                DataSet dataset = Conexion.HelperGenerico.Obtener_Data_Set(Mi_SQL.ToString());
                if (dataset != null)
                {
                    Tabla = dataset.Tables[0];
                }
            }
            catch (Exception Ex)
            {
                String Mensaje = "Error al intentar consultar las Áreas. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
                throw new Exception(Mensaje);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Tabla;
        }
    }
}