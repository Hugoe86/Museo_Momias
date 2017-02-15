using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Apl_Bitacora.Negocio;
using System.Text;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using System.Data;
using Erp.Helper;
using Erp.Metodos_Generales;

namespace Erp_Cat_Apl_Bitacora.Datos
{
    public class Cls_Apl_Bitacora_Datos
    {
        //*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Bitacora
        ///DESCRIPCIÓN          : Da de alta en la Base de Datos 
        ///PARAMENTROS          :     
        ///                       1. Rs_Negocio.       Instancia de la Clase de Negocio de Bitacora 
        ///                                 con los datos del que van a ser
        ///                                 dados de Alta..
        ///CREO                 : Armando Zavala Moreno.
        ///FECHA_CREO           : 16/Feb/2013 10:27:47 a.m.  
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Bitacora(Cls_Apl_Bitacora_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Mi_SQL = new StringBuilder();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
             
            String Bitacora_Id = "";
            Bitacora_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Apl_Bitacora.Tabla_Apl_Bitacora, Apl_Bitacora.Campo_Bitacora_Id, "", 10);

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("INSERT INTO " + Apl_Bitacora.Tabla_Apl_Bitacora + "(");
            Mi_SQL.Append(Apl_Bitacora.Campo_Bitacora_Id + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Usuario_Id + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Recurso_Id + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Accion + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Recurso + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Descripcion + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Usuario_Creo + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Ip_Creo + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Equipo_Creo + ", ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Fecha_Creo);
            Mi_SQL.Append(") VALUES (");
            Mi_SQL.Append("( '" + Bitacora_Id);
            Mi_SQL.Append("','" + Rs_Negocio.P_Usuario_Id);
            Mi_SQL.Append("','" + Rs_Negocio.P_Recurso_Id);
            Mi_SQL.Append("', " + Rs_Negocio.P_Accion);
            Mi_SQL.Append(" ,'" + Rs_Negocio.P_Recurso);
            Mi_SQL.Append("','" + Rs_Negocio.P_Descripcion);
            //Mi_SQL.Append("','" + Cls_Sessiones.Empleado_Nombre);
            //Mi_SQL.Append("','" + Cls_Sessiones.Ip);
            //Mi_SQL.Append("','" + Cls_Sessiones.Equipo);
            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Bitacora
        ///DESCRIPCIÓN          : Modifica un registro de la bitacora en la base de datos.
        ///PARAMETROS           : Rs_Negocio: Contiene el registro que sera modificado.
        ///CREO                 : Armando Zavala Moreno.
        ///FECHA_CREO           : 16/Feb/2013 11:35:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Bitacora(Cls_Apl_Bitacora_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Apl_Bitacora.Tabla_Apl_Bitacora + " SET ");
            
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Usuario_Id))
            {
                Mi_SQL.Append(Apl_Bitacora.Campo_Usuario_Id + " = '" + Rs_Negocio.P_Usuario_Id + "', ");
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Recurso_Id))
            {
                Mi_SQL.Append(Apl_Bitacora.Campo_Recurso_Id + " = '" + Rs_Negocio.P_Recurso_Id + "', ");
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Accion))
            {
                Mi_SQL.Append(Apl_Bitacora.Campo_Accion + " = '" + Rs_Negocio.P_Accion + "', ");
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Recurso))
            {
                Mi_SQL.Append(Apl_Bitacora.Campo_Recurso + " = '" + Rs_Negocio.P_Recurso + "', ");
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Descripcion))
            {
                Mi_SQL.Append(Apl_Bitacora.Campo_Descripcion + " = '" + Rs_Negocio.P_Descripcion + "', ");
            }

            //Mi_SQL.Append(Apl_Bitacora.Campo_Usuario_Modifico + " = '" + Cls_Sessiones.Empleado_Nombre + "', ");
            //Mi_SQL.Append(Apl_Bitacora.Campo_Ip_Modifico + " = '" + Cls_Sessiones.Ip + "', ");
            //Mi_SQL.Append(Apl_Bitacora.Campo_Equipo_Modifico + " = '" + Cls_Sessiones.Equipo + "', ");
            Mi_SQL.Append(Apl_Bitacora.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
            Mi_SQL.Append(" WHERE " + Apl_Bitacora.Campo_Bitacora_Id + " = '" + Rs_Negocio.P_Bitacora_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Bitacora
        ///DESCRIPCIÓN          : Regresa un DataTable con los registros de la bitacora encontrados.
        ///PARAMETROS           : Rs_Negocio: Contiene los criterios para la busqueda.
        ///CREO                 : Armando Zavala Moreno.
        ///FECHA_CREO           : 16/Feb/2013 11:45:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Bitacora(Cls_Apl_Bitacora_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Boolean Segundo_Filtro = false;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();


            Mi_SQL.Append("SELECT * FROM " + Apl_Bitacora.Tabla_Apl_Bitacora);
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Usuario_Id))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Bitacora.Campo_Usuario_Id + " = '" + Rs_Negocio.P_Usuario_Id + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Recurso_Id))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Bitacora.Campo_Recurso_Id + " = '" + Rs_Negocio.P_Recurso_Id + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Accion))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Bitacora.Campo_Accion + " = '" + Rs_Negocio.P_Accion + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Recurso))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Bitacora.Campo_Recurso + " = '" + Rs_Negocio.P_Recurso + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Descripcion))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Bitacora.Campo_Descripcion + " = '" + Rs_Negocio.P_Descripcion + "'");
                Segundo_Filtro = true;
            }

            Conexion.HelperGenerico.Cerrar_Conexion();
            return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Bitacora
        ///DESCRIPCIÓN          : Elimina un registro de la bitacora de la base de datos.
        ///PARAMETROS           : Rs_Negocio: Contiene el registro que sera eliminado.
        ///CREO                 : Armando Zavala Moreno.
        ///FECHA_CREO           : 16/Feb/2013 12:03:00 p.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Bitacora(Cls_Apl_Bitacora_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("DELETE FROM " + Apl_Bitacora.Tabla_Apl_Bitacora);
            Mi_SQL.Append(" WHERE " + Apl_Bitacora.Campo_Bitacora_Id + " = '" + Rs_Negocio.P_Bitacora_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}