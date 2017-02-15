using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using Erp.Metodos_Generales;
using System.Data;
using Erp.Helper;
using Erp_Cat_Centro_Costos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Cat_Centro_Costos.Datos
{
    public class Cls_Cat_Centro_Costos_Datos
    {
        //*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Centro_Costo
        ///DESCRIPCIÓN          : Da de alta en la Base de Datos 
        ///PARAMENTROS          :     
        ///                       1. Rs_Negocio.       Instancia de la Clase de Negocio de Centro de Costo 
        ///                                 con los datos del que van a ser
        ///                                 dados de Alta..
        ///CREO                 : Armando Zavala Moreno.
        ///FECHA_CREO           : 16/Feb/2013 12:30:47 a.m.  
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Centro_Costo(Cls_Cat_Centro_Costos_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
             
            String Centro_Costo_Id = "";
            Centro_Costo_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Nom_Centro_Costo.Tabla_Cat_Nom_Centro_Costo, Cat_Nom_Centro_Costo.Campo_Centro_Costo_Id, "", 5);

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("INSERT INTO " + Cat_Nom_Centro_Costo.Tabla_Cat_Nom_Centro_Costo + "(");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Centro_Costo_Id + ", ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Nombre + ", ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Descripcion + ", ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Estatus + ", ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Usuario_Creo + ", ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Ip_Creo + ", ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Equipo_Creo + ", ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Fecha_Creo);
            Mi_SQL.Append(") VALUES (");
            Mi_SQL.Append(" '" + Centro_Costo_Id);
            Mi_SQL.Append("','" + Rs_Negocio.P_Nombre);
            Mi_SQL.Append("','" + Rs_Negocio.P_Descripcion);
            Mi_SQL.Append("', '" + Rs_Negocio.P_Estatus);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Ip);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Equipo);
            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Centro_Costo
        ///DESCRIPCIÓN          : Modifica un registro en la base de datos.
        ///PARAMETROS           : Rs_Negocio: Contiene el registro que sera modificado.
        ///CREO                 : Armando Zavala Moreno.
        ///FECHA_CREO           : 16/Feb/2013 12:35:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Centro_Costo(Cls_Cat_Centro_Costos_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            
            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Cat_Nom_Centro_Costo.Tabla_Cat_Nom_Centro_Costo + " SET ");

            if (!String.IsNullOrEmpty(Rs_Negocio.P_Nombre))
            {
                Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Nombre + " = '" + Rs_Negocio.P_Nombre + "', ");
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Descripcion))
            {
                Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Descripcion + " = '" + Rs_Negocio.P_Descripcion + "', ");
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Estatus))
            {
                Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Estatus + " = '" + Rs_Negocio.P_Estatus + "', ");
            }

            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
            Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
            Mi_SQL.Append(" WHERE " + Cat_Nom_Centro_Costo.Campo_Centro_Costo_Id + " = '" + Rs_Negocio.P_Centro_Costo_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString()); 
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Centro_Costo
        ///DESCRIPCIÓN          : Regresa un DataTable con los registros del Centro de costo encontrados.
        ///PARAMETROS           : Rs_Negocio: Contiene los criterios para la busqueda.
        ///CREO                 : Armando Zavala Moreno.
        ///FECHA_CREO           : 16/Feb/2013 12:45:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Centro_Costo(Cls_Cat_Centro_Costos_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Boolean Segundo_Filtro = false;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Cat_Nom_Centro_Costo.Tabla_Cat_Nom_Centro_Costo);
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Nombre))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Nombre + " = '" + Rs_Negocio.P_Nombre + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Descripcion))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Descripcion + " = '" + Rs_Negocio.P_Descripcion + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Estatus))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Cat_Nom_Centro_Costo.Campo_Estatus +  Rs_Negocio.P_Estatus );
                Segundo_Filtro = true;
            }
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
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
        public static Boolean Eliminar_Centro_Costo(Cls_Cat_Centro_Costos_Negocio P_Centro_Costo)
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

                Mi_sql.Append("UPDATE " + Cat_Nom_Centro_Costo.Tabla_Cat_Nom_Centro_Costo + " SET ");
                Mi_sql.Append(Cat_Nom_Centro_Costo.Campo_Estatus + " = 'ELIMINADO', ");
                Mi_sql.Append(Cat_Nom_Centro_Costo.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Nom_Centro_Costo.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Nom_Centro_Costo.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Nom_Centro_Costo.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Nom_Centro_Costo.Campo_Centro_Costo_Id + " = '" + P_Centro_Costo.P_Centro_Costo_Id + "'");
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
                throw new Exception("Baja_Centro_Costo: " + E.Message);
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
    }
}