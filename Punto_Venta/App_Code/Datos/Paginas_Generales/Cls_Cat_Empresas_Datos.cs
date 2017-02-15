using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Erp.Metodos_Generales;
using Erp.Ayudante_Sintaxis;
using Erp.Helper;
using Erp.Constantes;
using Erp.Sesiones;
using Erp_Cat_Empresas.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Cat_Empresas.Datos
{
    public class Cls_Cat_Empresas_Datos
    {

        #region MÉTODOS
        /// ***********************************************************************************
        /// Nombre de la Función: Alta_Empresas
        /// Descripción         : Da de alta en la Base de Datos una nueva Empresa
        /// Parámetros          : 
        /// Usuario Creo        : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó          : 14/Febrero/2013 12:32 p.m.
        /// Usuario Modifico    :
        /// Fecha Modifico      :
        /// ***********************************************************************************
        public static Boolean Alta_Empresas(Cls_Cat_Empresas_Negocio P_Empresas)
        {
            Boolean Alta = false;
			StringBuilder Mi_sql = new StringBuilder(); ;
            String Empresa_ID = "";
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
                Empresa_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Empresas.Tabla_Cat_Empresas, Cat_Empresas.Campo_Empresa_Id, "", 5);
                Mi_sql.Clear();
				Mi_sql.Append("INSERT INTO " + Cat_Empresas.Tabla_Cat_Empresas + "(");
				Mi_sql.Append(Cat_Empresas.Campo_Empresa_Id + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Nombre_Corto + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Razon_Social + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_RFC + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Giro + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Calle + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Numero_Exterior + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Numero_Interior + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Colonia + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Ciudad + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Localidad + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Estado + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Pais + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_CP + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Fax + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Telefono + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Telefono_2 + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Extension + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Nextel + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Contacto + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Email + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Sitio_Web + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Estatus + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Usuario_Creo + ", ");
				Mi_sql.Append(Cat_Empresas.Campo_Ip_Creo + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Equipo_Creo + ", ");
                Mi_sql.Append(Cat_Empresas.Campo_Fecha_Creo);
				Mi_sql.Append( ") VALUES (");
				Mi_sql.Append("'" + Empresa_ID + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Nombre_Corto + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Razon_Social + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Rfc + "', ");
                Mi_sql.Append("'" + P_Empresas.P_Giro + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Calle + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Numero_Exterior + "', ");
                Mi_sql.Append("'" + P_Empresas.P_Numero_Interior + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Colonia + "', ");
                Mi_sql.Append("'" + P_Empresas.P_Ciudad + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Localidad + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Estado + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Pais + "', ");
                Mi_sql.Append("'" + P_Empresas.P_Cp + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Fax + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Telefono + "', ");
                Mi_sql.Append("'" + P_Empresas.P_Telefono_2 + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Extension + "', ");
                Mi_sql.Append("'" + P_Empresas.P_Nextel + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Contacto + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Email + "', ");
				Mi_sql.Append("'" + P_Empresas.P_Sitio_Web + "', ");
                Mi_sql.Append("'" + P_Empresas.P_Estatus + "', ");
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
                throw new Exception("Alta_Empresas: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN: Modificar_Empresa
        ///DESCRIPCIÓN         : Modifica en la Base de Datos una nueva Empresa
        ///PARAMENTROS         : P_Empresas.- Instancia de la Clase de Negocio de Empresas con los datos del que van a ser
        ///                                   modificados.
        ///CREO                : Miguel Angel Alvarado Enriquez.
        ///FECHA_CREO          : 14/Febrero/2013 04:33:00 p.m. 
        ///MODIFICO            :
        ///FECHA_MODIFICO      :
        ///CAUSA_MODIFICACIÓN  :
        ///*******************************************************************************
        public static Boolean Modificar_Empresa(Cls_Cat_Empresas_Negocio P_Empresas)
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

                Mi_sql.Append("UPDATE " + Cat_Empresas.Tabla_Cat_Empresas + " SET ");
                if (!String.IsNullOrEmpty(P_Empresas.P_Nombre_Corto))
                {
                Mi_sql.Append(Cat_Empresas.Campo_Nombre_Corto + " = '" + P_Empresas.P_Nombre_Corto + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Razon_Social))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Razon_Social + " = '" + P_Empresas.P_Razon_Social + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Rfc))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_RFC + " = '" + P_Empresas.P_Rfc + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Giro))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Giro + " = '" + P_Empresas.P_Giro + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Calle))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Calle + " = '" + P_Empresas.P_Calle + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Numero_Exterior))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Numero_Exterior + " = '" + P_Empresas.P_Numero_Exterior + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Numero_Interior))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Numero_Interior + " = '" + P_Empresas.P_Numero_Exterior + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Colonia))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Colonia + " = '" + P_Empresas.P_Colonia + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Ciudad))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Ciudad + " = '" + P_Empresas.P_Ciudad + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Localidad))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Localidad + " = '" + P_Empresas.P_Localidad + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Estado))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Estado + " = '" + P_Empresas.P_Estado + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Calle))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Pais + " = '" + P_Empresas.P_Pais + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Pais))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_CP + " = '" + P_Empresas.P_Cp + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Fax))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Fax + " = '" + P_Empresas.P_Fax + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Telefono))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Telefono + " = '" + P_Empresas.P_Telefono + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Telefono_2))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Telefono_2 + " = '" + P_Empresas.P_Telefono_2 + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Extension))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Extension + " = '" + P_Empresas.P_Extension + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Nextel))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Nextel + " = '" + P_Empresas.P_Nextel + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Calle))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Contacto + " = '" + P_Empresas.P_Contacto + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Contacto))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Email + " = '" + P_Empresas.P_Email + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Sitio_Web))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Sitio_Web + " = '" + P_Empresas.P_Sitio_Web + "', ");
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Estatus))
                {
                    Mi_sql.Append(Cat_Empresas.Campo_Estatus + " = '" + P_Empresas.P_Estatus + "', ");
                }
                Mi_sql.Append(Cat_Empresas.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Empresas.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Empresas.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Empresas.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Empresas.Campo_Empresa_Id + " = '" + P_Empresas.P_Empresa_Id + "'");
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
                throw new Exception("Modificar_Empresa: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN: Empresa_Modificacion_Estatus
        ///DESCRIPCIÓN         : Modifica el estatus en la Base de Datos de una Empresa
        ///PARAMENTROS         : P_Empresas.- Instancia de la Clase de Negocio de Empresas con los datos del que van a ser
        ///                                   modificados.
        ///CREO                : Miguel Angel Alvarado Enriquez.
        ///FECHA_CREO          : 15/Febrero/2013 04:55:00 p.m. 
        ///MODIFICO            :
        ///FECHA_MODIFICO      :
        ///CAUSA_MODIFICACIÓN  :
        ///*******************************************************************************
        public static Boolean Empresa_Modificacion_Estatus(Cls_Cat_Empresas_Negocio P_Empresas)
        {
            Boolean Modifica_Estatus = false;
            StringBuilder Mi_sql = new StringBuilder();
            Boolean Transaccion_Activa = false;
            try{

                Conexion.Iniciar_Helper();
                if (!Conexion.HelperGenerico.Estatus_Transaccion())
                {
                    Conexion.HelperGenerico.Conexion_y_Apertura();
                }
                else
                {
                    Transaccion_Activa = true;
                }

                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_sql.Append("UPDATE " + Cat_Empresas.Tabla_Cat_Empresas + " SET ");
                Mi_sql.Append(Cat_Empresas.Campo_Estatus + " = 'INACTIVO', ");
                Mi_sql.Append(Cat_Empresas.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Empresas.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Empresas.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Empresas.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Empresas.Campo_Empresa_Id + " = '" + P_Empresas.P_Empresa_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Modifica_Estatus = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Empresa_Modificacion_Estatus: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Modifica_Estatus;
        }

        ///**************************************************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Empresas
        ///DESCRIPCIÓN         : Consulta los motivos de rechazo
        ///PARAMENTROS         : P_Empresas.- Instancia de la Clase de Negocio de Empresas con los datos que servirán de
        ///                                   filtro.
        ///CREO                : Miguel Angel Alvarado Eniquez.
        ///FECHA_CREO          : 15/Febrero/2013 
        ///MODIFICO            :
        ///FECHA_MODIFICO      :
        ///CAUSA_MODIFICACIÓN  :
        ///*******************************************************************************
        public static DataTable Consultar_Empresas(Cls_Cat_Empresas_Negocio P_Empresas)
        {
            DataTable Tabla = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
            String Aux_Filtros = "";
            Boolean Segundo_Filtro=false;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {

                Mi_SQL.Append("SELECT * FROM  " + Cat_Empresas.Tabla_Cat_Empresas);
                if (!String.IsNullOrEmpty(P_Empresas.P_Nombre_Corto))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Nombre_Corto + " LIKE '%" + P_Empresas.P_Nombre_Corto + "%' ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Rfc))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_RFC + " = '" + P_Empresas.P_Rfc + "' ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Estado))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Estado + " = '" + P_Empresas.P_Estado + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Ciudad))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Ciudad + " = '" + P_Empresas.P_Ciudad + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Localidad))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Localidad + " = '" + P_Empresas.P_Localidad + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Colonia))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Colonia + " = '" + P_Empresas.P_Colonia + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Calle))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Calle + " = '" + P_Empresas.P_Calle + "'  ");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Estatus))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Estatus + P_Empresas.P_Estatus + "'  ");
                    Segundo_Filtro = true;
                }
                else
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE "); 
                    Mi_SQL.Append(Cat_Empresas.Campo_Estatus + " != 'ELIMINADO'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Empresas.P_Empresa_Id))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Empresas.Campo_Empresa_Id + " = '" + P_Empresas.P_Empresa_Id + "'  ");
                    Segundo_Filtro = true;
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
                Mi_SQL.Append(" ORDER BY " + Cat_Empresas.Campo_Empresa_Id);
                // agregar filtro y orden a la consulta
                DataSet dataset = Conexion.HelperGenerico.Obtener_Data_Set(Mi_SQL.ToString());
                if (dataset != null)
                {
                    Tabla = dataset.Tables[0];
                }

            }
            catch (Exception Ex)
            {
                String Mensaje = "Error al intentar consultar las Empresas. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
                throw new Exception(Mensaje);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Tabla;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Empresa
        ///DESCRIPCIÓN          : Elimina un registro de Empresa de la base de datos.
        ///PARAMETROS           : P_Empresas: Contiene el registro que sera eliminado.
        ///CREO                 : Miguel Angel Alvarado Enriquez.
        ///FECHA_CREO           : 18/Febrero/2013 10:36:00 a.m. 
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Empresa(Cls_Cat_Empresas_Negocio P_Empresas)
        {
            StringBuilder Mi_SQL;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("DELETE FROM " + Cat_Empresas.Tabla_Cat_Empresas);
            Mi_SQL.Append(" WHERE " + Cat_Empresas.Campo_Empresa_Id + " = '" + P_Empresas.P_Empresa_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        
        #endregion
    }
}
