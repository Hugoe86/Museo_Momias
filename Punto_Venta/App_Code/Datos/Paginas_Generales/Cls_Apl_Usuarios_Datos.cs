using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;
using Erp_Apl_Usuarios.Negocio;
using Erp.Ayudante_Sintaxis;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Constantes;
using System.Data;
using System.Text;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Apl_Usuarios.Datos
{
    public class Cls_Apl_Usuarios_Datos
    {
        /// ***********************************************************************************
        /// Nombre de la Función: Alta_Usuarios
        /// Descripción         : Da de alta en la Base de Datos un nuevo Usuario
        /// Parámetros          : 
        /// Usuario Creo        : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó          : 14/Febrero/2013 12:32 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        public static Boolean Alta_Usuarios(Cls_Apl_Usuarios_Negocio P_Usuario)
        {
            Boolean Alta = false;
            StringBuilder Mi_sql = new StringBuilder(); ;
            String Usuario_ID = "";
            
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
                Usuario_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Apl_Usuarios.Tabla_Apl_Usuarios, Apl_Usuarios.Campo_Usuario_Id, "",10);
               
                Mi_sql.Append("INSERT INTO " + Apl_Usuarios.Tabla_Apl_Usuarios + "(");
                Mi_sql.Append(Apl_Usuarios.Campo_Usuario_Id + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Usuario + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Fecha_Expira_Contrasenia + ", ");
                if (!String.IsNullOrEmpty(P_Usuario.P_Email))
                {
                    Mi_sql.Append(Apl_Usuarios.Campo_Email + ", ");
                }
                Mi_sql.Append(Apl_Usuarios.Campo_No_Intentos_Acceso + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_No_Intentos_Recuperar + ", ");
                if (!String.IsNullOrEmpty(P_Usuario.P_Pregunta_Secreta))
                {
                   Mi_sql.Append(Apl_Usuarios.Campo_Pregunta_Secreta);
                }
                if (!String.IsNullOrEmpty(P_Usuario.P_Respuesta_Secreta))
                {
                 Mi_sql.Append(Apl_Usuarios.Campo_Respuesta_Secreta + ", ");
                }               
                Mi_sql.Append(Apl_Usuarios.Campo_Estatus + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Rol_Id + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Caja_ID + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Comentario + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Contrasenia + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Nombre_Usuario + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Usuario_Creo + ", ");
                Mi_sql.Append(Apl_Usuarios.Campo_Fecha_Creo);
                Mi_sql.Append(") VALUES (");
                Mi_sql.Append("'" + Usuario_ID + "', ");
                if (!String.IsNullOrEmpty(P_Usuario.P_Empleado_Id))
                {
                    Mi_sql.Append("'" + P_Usuario.P_Empleado_Id + "', ");
                }
                Mi_sql.Append("'" + P_Usuario.P_Usuario + "', ");
                Mi_sql.Append( Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Usuario.P_Fecha_Expira_Contrasenia) + ", ");
                if (!String.IsNullOrEmpty(P_Usuario.P_Email))
                {
                    Mi_sql.Append("'" + P_Usuario.P_Email + "', ");
                }
                Mi_sql.Append("0, ");
                Mi_sql.Append("0, ");
                if (!String.IsNullOrEmpty(P_Usuario.P_Pregunta_Secreta))
                {
                    Mi_sql.Append("'" + P_Usuario.P_Pregunta_Secreta + "', ");
                }
                if (!String.IsNullOrEmpty(P_Usuario.P_Respuesta_Secreta))
                {
                    Mi_sql.Append("'" + P_Usuario.P_Respuesta_Secreta + "', ");
                }
                Mi_sql.Append("'" + P_Usuario.P_Estatus + "', ");
                Mi_sql.Append("'" + P_Usuario.P_Rol_ID + "', ");
                Mi_sql.Append("'" + P_Usuario.P_Caja_Id+ "', ");
                Mi_sql.Append("'" + P_Usuario.P_Comentarios + "', ");
                Mi_sql.Append("'" + P_Usuario.P_Contrasenia + "', ");
                Mi_sql.Append("'" + P_Usuario.P_Nombre_Usuario + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
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
                throw new Exception("Alta_Usuarios: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Usuario
        ///DESCRIPCIÓN          : Modifica un registro de la tabla de usuarios en la base de datos.
        ///PARAMETROS           : P_Usuario: Contiene el registro que sera modificado.
        ///CREO                 : Miguel Angel Alvarado Enriquez.
        ///FECHA_CREO           : 16/Febrero/2013 11:35:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Usuario(Cls_Apl_Usuarios_Negocio P_Usuario)
        {
            StringBuilder Mi_SQL;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
             
            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Apl_Usuarios.Tabla_Apl_Usuarios + " SET ");

            if (!String.IsNullOrEmpty(P_Usuario.P_Nombre_Usuario))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Nombre_Usuario + " = '" + P_Usuario.P_Nombre_Usuario + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Usuario))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Usuario + " = '" + P_Usuario.P_Usuario + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Contrasenia))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Contrasenia + " = '" + P_Usuario.P_Contrasenia + "', ");
            }
            if (P_Usuario.P_Fecha_Expira_Contrasenia != DateTime.MinValue)
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Fecha_Expira_Contrasenia + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Usuario.P_Fecha_Expira_Contrasenia) + ", ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Email))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Email + " = '" + P_Usuario.P_Email + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_No_Intentos_Acceso))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_No_Intentos_Acceso + " = '" + P_Usuario.P_No_Intentos_Acceso + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_No_Intentos_Recuperar))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_No_Intentos_Recuperar + " = '" + P_Usuario.P_No_Intentos_Recuperar + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Pregunta_Secreta))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Pregunta_Secreta + " = '" + P_Usuario.P_Pregunta_Secreta + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Respuesta_Secreta))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Respuesta_Secreta + " = '" + P_Usuario.P_Respuesta_Secreta + "', ");
            }

            if (!String.IsNullOrEmpty(P_Usuario.P_Estatus))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Estatus + " = '" + P_Usuario.P_Estatus + "', ");

                if (P_Usuario.P_Estatus == "ACTIVO")
                {
                    Mi_SQL.Append(Apl_Usuarios.Campo_Fecha_Ultimo_Acceso + " = NOW(), ");
                }
            }

            if (P_Usuario.P_Fecha_Ultimo_Intento != DateTime.MinValue)
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Fecha_Intento_Acceso + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Usuario.P_Fecha_Ultimo_Intento) + ", ");
            }

            if (!String.IsNullOrEmpty(P_Usuario.P_Rol_ID))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Rol_Id + " = '" + P_Usuario.P_Rol_ID + "', ");
            }
            
            if (!String.IsNullOrEmpty(MDI_Frm_Apl_Principal.Nombre_Usuario))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
            }
            if(P_Usuario.P_Estatus_Caja_Id == true)
                Mi_SQL.Append(Apl_Usuarios.Campo_Caja_ID + " = '" + P_Usuario.P_Caja_Id + "', ");

            Mi_SQL.Append(Apl_Usuarios.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());

            //  seccion were
            Mi_SQL.Append(" WHERE " + Apl_Usuarios.Campo_Usuario_Id + " = '" + P_Usuario.P_Usuario_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Usuario_Activos
        ///DESCRIPCIÓN          : Modifica un registro de la tabla de usuarios en la base de datos.
        ///PARAMETROS           : P_Usuario: Contiene el registro que sera modificado.
        ///CREO                 : Miguel Angel Alvarado Enriquez.
        ///FECHA_CREO           : 16/Febrero/2013 11:35:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Usuario_Activos(Cls_Apl_Usuarios_Negocio P_Usuario)
        {
            StringBuilder Mi_SQL;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Apl_Usuarios.Tabla_Apl_Usuarios + " SET ");

            if (!String.IsNullOrEmpty(P_Usuario.P_Usuario))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Usuario + " = '" + P_Usuario.P_Usuario + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Contrasenia))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Contrasenia + " = '" + P_Usuario.P_Contrasenia + "', ");
            }
            if (P_Usuario.P_Fecha_Expira_Contrasenia != DateTime.MinValue)
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Fecha_Expira_Contrasenia + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Usuario.P_Fecha_Expira_Contrasenia) + ", ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Email))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Email + " = '" + P_Usuario.P_Email + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_No_Intentos_Acceso))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_No_Intentos_Acceso + " = '" + P_Usuario.P_No_Intentos_Acceso + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_No_Intentos_Recuperar))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_No_Intentos_Recuperar + " = '" + P_Usuario.P_No_Intentos_Recuperar + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Pregunta_Secreta))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Pregunta_Secreta + " = '" + P_Usuario.P_Pregunta_Secreta + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Respuesta_Secreta))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Respuesta_Secreta + " = '" + P_Usuario.P_Respuesta_Secreta + "', ");
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Estatus))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Estatus + " = '" + P_Usuario.P_Estatus + "', ");
            }

            if (!String.IsNullOrEmpty(MDI_Frm_Apl_Principal.Empleado_ID))
            {
                Mi_SQL.Append(Apl_Usuarios.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Empleado_ID + "', ");
            }
            
            Mi_SQL.Append(Apl_Usuarios.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
            Mi_SQL.Append(" WHERE " + Apl_Usuarios.Campo_Fecha_Expira_Contrasenia + " < " + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Usuario.P_Fecha_Expira_Contrasenia));
            
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Usuario
        ///DESCRIPCIÓN          : Regresa un DataTable con los registros del usuario encontrados.
        ///PARAMETROS           : P_Usuario: Contiene los criterios para la busqueda.
        ///CREO                 : Miguel Angel Alvarado Enriquez.
        ///FECHA_CREO           : 16/Febrero/2013 11:45:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Usuario(Cls_Apl_Usuarios_Negocio P_Usuario)
        {
            StringBuilder Mi_SQL;
            Boolean Segundo_Filtro = false;
            Conexion.Iniciar_Helper();
            DataTable Dt_Resultado = new DataTable();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT *, ");
            Mi_SQL.Append("(select " + Cat_Cajas.Campo_Caja_ID + " from " + Cat_Cajas.Tabla_Cat_Cajas + " ");
            Mi_SQL.Append("where " + Cat_Cajas.Campo_Nombre_Equipo + " = '" + P_Usuario.P_Equipo_Creo + "') Caja_Equipo ");
            Mi_SQL.Append(", (select " + Cat_Cajas.Campo_Serie + " from " + Cat_Cajas.Tabla_Cat_Cajas + " ");
            Mi_SQL.Append("where " + Cat_Cajas.Campo_Nombre_Equipo + " = '" + P_Usuario.P_Equipo_Creo + "') Serie_Caja ");
            Mi_SQL.Append(",CONCAT ('C', (select " + Cat_Cajas.Campo_Numero_Caja + " from " + Cat_Cajas.Tabla_Cat_Cajas + " ");
            Mi_SQL.Append("where " + Cat_Cajas.Campo_Nombre_Equipo + " = '" + P_Usuario.P_Equipo_Creo + "')) Numero_Caja ");
            Mi_SQL.Append("FROM " + Apl_Usuarios.Tabla_Apl_Usuarios);


            if (!String.IsNullOrEmpty(P_Usuario.P_Usuario_Id))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Usuario_Id + " = '" + P_Usuario.P_Usuario_Id + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Usuario))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Usuario + " = '" + P_Usuario.P_Usuario + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Nombre_Usuario))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Nombre_Usuario + " LIKE '%" + P_Usuario.P_Nombre_Usuario + "%'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Estatus))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Estatus + " = '" + P_Usuario.P_Estatus + "'");
                Segundo_Filtro = true;
            }
            else
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Estatus + " <> 'ELIMINADO'");
                Segundo_Filtro = true;

            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Email))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Email + " = '" + P_Usuario.P_Email + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Contrasenia))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Contrasenia + " = '" + P_Usuario.P_Contrasenia + "'");
                Segundo_Filtro = true;
            }
            if (!String.IsNullOrEmpty(P_Usuario.P_Rol_ID))
            {
                Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Rol_Id + " = '" + P_Usuario.P_Rol_ID + "'");
                Segundo_Filtro = true;
            }

            Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
            
            return Dt_Resultado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Usuario
        ///DESCRIPCIÓN          : Elimina un registro de usuario de la base de datos.
        ///PARAMETROS           : P_Usuario: Contiene el registro que sera eliminado.
        ///CREO                 : Miguel Angel Alvarado Enriquez.
        ///FECHA_CREO           : 16/Febrero/2013 12:03:00 p.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Usuario(Cls_Apl_Usuarios_Negocio P_Usuario)
        {
            StringBuilder Mi_SQL;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("DELETE FROM " + Apl_Usuarios.Tabla_Apl_Usuarios);
            Mi_SQL.Append(" WHERE " + Apl_Usuarios.Campo_Usuario_Id + " = '" + P_Usuario.P_Usuario_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

       

    }
}