using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Sesiones;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp_Cat_Apl_Registro_Accesos.Negocio;

namespace Erp_Cat_Apl_Registro_Accesos.Datos
{
    public class Cls_Cat_Apl_Registro_Accesos_Datos
    {
        #region MÉTODOS

        /// ***********************************************************************************
        /// Nombre de la Función: Alta_Registro_Accesos
        /// Descripción         : Da de alta en la Base de Datos una nueva Empresa
        /// Parámetros          :
        /// Usuario Creo        : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó          : 14/Febrero/2013 12:32 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        public static Boolean Alta_Registro_Accesos(Cls_Apl_Registro_Accesos_Negocio P_Registro_Accesos)
        {
            Boolean Alta = false;
            StringBuilder Mi_sql = new StringBuilder(); ;
            String Registro_Id = "";
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

                Registro_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Apl_Registro_Accesos.Tabla_Apl_Registro_Accesos, Apl_Registro_Accesos.Campo_Registro_Id, "", 10);
                Mi_sql.Append("INSERT INTO " + Apl_Registro_Accesos.Tabla_Apl_Registro_Accesos + "(");
                Mi_sql.Append(Apl_Registro_Accesos.Campo_Registro_Id + ", ");
                Mi_sql.Append(Apl_Registro_Accesos.Campo_Usuario_Id + ", ");
                Mi_sql.Append(Apl_Registro_Accesos.Campo_Tipo + ", ");
                Mi_sql.Append(Apl_Registro_Accesos.Campo_Usuario_Creo + ", ");
                Mi_sql.Append(Apl_Registro_Accesos.Campo_Fecha_Creo);
                Mi_sql.Append(", " + Apl_Registro_Accesos.Campo_Maquina);
                Mi_sql.Append(") VALUES (");
                Mi_sql.Append("'" + Registro_Id);
                Mi_sql.Append("', '" + P_Registro_Accesos.P_Usuario_Id);
                Mi_sql.Append("', '" + P_Registro_Accesos.P_Tipo);
                Mi_sql.Append("', '" + MDI_Frm_Apl_Principal.Nombre_Usuario);
                Mi_sql.Append("',  " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(", '" + P_Registro_Accesos.P_Equipo_Creo + "'");
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
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Abortar_Transaccion();
                }
                throw new Exception("Alta_Registro_Accesos: " + E.Message);
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
        #endregion MÉTODOS

        #region Consulta

        ///**************************************************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Registro_Accesos
        ///DESCRIPCIÓN         : Consulta los motivos de rechazo
        ///PARAMENTROS         : P_Registro_Accesos.- Instancia de la Clase de Negocio de Empresas con los datos que servirán de
        ///                                           filtro.
        ///CREO                : Miguel Angel Alvarado Eniquez.
        ///FECHA_CREO          : 15/Febrero/2013
        ///MODIFICO            :
        ///FECHA_MODIFICO      :
        ///CAUSA_MODIFICACIÓN  :
        ///*******************************************************************************
        public static DataTable Consultar_Registro_Accesos(Cls_Apl_Registro_Accesos_Negocio P_Registro_Accesos)
        {
            DataTable Tabla = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            try
            {
                Mi_SQL.Append("SELECT * FROM  " + Apl_Registro_Accesos.Tabla_Apl_Registro_Accesos);
                if (!String.IsNullOrEmpty(P_Registro_Accesos.P_Usuario_Id))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Apl_Registro_Accesos.Campo_Usuario_Id + " = '" + P_Registro_Accesos.P_Usuario_Id + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Registro_Accesos.P_Tipo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Apl_Registro_Accesos.Campo_Tipo + " = '" + P_Registro_Accesos.P_Tipo + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Registro_Accesos.P_Registro_Id))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Apl_Registro_Accesos.Campo_Registro_Id + " = '" + P_Registro_Accesos.P_Registro_Id + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Registro_Accesos.P_Fecha_Creo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(" DATE_FORMAT(" + Apl_Registro_Accesos.Campo_Fecha_Creo + ", '%Y-%m-%d' ) = '" + P_Registro_Accesos.P_Fecha_Creo + "'  ");
                    Segundo_Filtro = true;
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
                String Mensaje = "Error al intentar consultar los Puestos. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
                throw new Exception(Mensaje);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Tabla;
        }         
        ///**************************************************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Registro_Acceso
        ///DESCRIPCIÓN         : Consulta el ultimo registro de acceso del usuario
        ///PARAMENTROS         : P_Registro_Accesos.- Instancia de la Clase de Negocio de Empresas con los datos que servirán de
        ///                                           filtro.
        ///CREO                : Sergio Manuel Gallardo Andrade
        ///FECHA_CREO          : 28/Febrero/2013
        ///MODIFICO            :
        ///FECHA_MODIFICO      :
        ///CAUSA_MODIFICACIÓN  :
        ///*******************************************************************************
        public static void Registro_Acceso(Cls_Apl_Registro_Accesos_Negocio P_Registro_Accesos)
        {
            DataTable Tabla = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            try
            {
                Mi_SQL.Append("UPDATE " + Apl_Usuarios.Tabla_Apl_Usuarios + " SET ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Fecha_Ultimo_Acceso + " = "+Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" WHERE "+Apl_Usuarios.Campo_Usuario_Id + " = '" + P_Registro_Accesos.P_Usuario_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                String Mensaje = "Error al intentar consultar los Puestos. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
                throw new Exception(Mensaje);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }


        ///**************************************************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Registro_Accesos
        ///DESCRIPCIÓN         : Consulta los motivos de rechazo
        ///PARAMENTROS         : P_Registro_Accesos.- Instancia de la Clase de Negocio de Empresas con los datos que servirán de
        ///                                           filtro.
        ///CREO                : Miguel Angel Alvarado Eniquez.
        ///FECHA_CREO          : 15/Febrero/2013
        ///MODIFICO            :
        ///FECHA_MODIFICO      :
        ///CAUSA_MODIFICACIÓN  :
        ///*******************************************************************************
        public static DataTable Consultar_Fecha_Servidor(Cls_Apl_Registro_Accesos_Negocio P_Registro_Accesos)
        {  
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            DataTable Dt_Consulta = new DataTable();

            try
            {
                Mi_SQL.Append("SELECT now() as Fecha_Servidor");

             
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Set(Mi_SQL.ToString()).Tables[0];
                
            }
            catch (Exception Ex)
            {
                String Mensaje = "Error al intentar consultar los Puestos. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
                throw new Exception(Mensaje);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Consulta;
        }         
        

        #endregion Consulta
    }
}