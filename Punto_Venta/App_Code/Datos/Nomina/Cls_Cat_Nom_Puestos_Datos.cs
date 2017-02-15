using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Nom_Puestos.Negocio;
using Erp.Metodos_Generales;
using System.Text;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using System.Data;
using Erp.Helper;
using ERP_BASE.Paginas.Paginas_Generales;

/// <summary>
/// Summary description for Cls_Cat_Nom_Puestos_Datos
/// </summary>

namespace Erp_Cat_Nom_Puestos.Datos
{
	public class Cls_Cat_Nom_Puestos_Datos
	{

		///*******************************************************************************
		///NOMBRE DE LA FUNCIÓN: Alta_Puesto
		///DESCRIPCIÓN: Da de alta en la Base de Datos Un nuevo proveedor
		///PARAMENTROS:     
		///             1. P_Puestos.       Instancia de la Clase de Negocio de Puestos 
		///                                 con los datos del que van a ser
		///                                 dados de Alta.
		///CREO: Miguel Angel Bedolla Moreno.
		///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
		///MODIFICO:
		///FECHA_MODIFICO:
		///CAUSA_MODIFICACIÓN:
		///*******************************************************************************
		public static Boolean Alta_Puesto(Cls_Cat_Nom_Puestos_Negocio P_Puestos)
		{
			Boolean Alta = false;
			StringBuilder Mi_sql = new StringBuilder(); ;
			String Puesto_Id = "";
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

                Puesto_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Nom_Puestos.Tabla_Cat_Nom_Puestos, Cat_Nom_Puestos.Campo_Puesto_Id, "", 5);
				Mi_sql.Append("INSERT INTO " + Cat_Nom_Puestos.Tabla_Cat_Nom_Puestos + "(");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Puesto_Id + ", ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Nombre + ", ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Descripcion + ", ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Estatus + ", ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Usuario_Creo + ", ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Ip_Creo + ", ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Equipo_Creo + ", ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Fecha_Creo);
				Mi_sql.Append( ") VALUES (");
				Mi_sql.Append("'" + Puesto_Id + "', ");
				Mi_sql.Append("'" + P_Puestos.P_Nombre + "', ");
				Mi_sql.Append("'" + P_Puestos.P_Descripcion + "', ");
				Mi_sql.Append("'" + P_Puestos.P_Estatus + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Equipo + "', ");
				Mi_sql.Append("" + Cls_Ayudante_Sintaxis.Fecha());
				Mi_sql.Append (")");
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
				throw new Exception("Alta_Puesto: " + E.Message);
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
		///NOMBRE DE LA FUNCIÓN: Modificar_Puesto
		///DESCRIPCIÓN: Modifica en la Base de Datos Un nuevo proveedor
		///PARAMENTROS:     
		///             1. P_Puestos.       Instancia de la Clase de Negocio de Puestos 
		///                                 con los datos del que van a ser
		///                                 modificados.
		///CREO: Miguel Angel Bedolla Moreno.
		///FECHA_CREO: 14/Feb/2013 04:33:00 p.m. 
		///MODIFICO:
		///FECHA_MODIFICO:
		///CAUSA_MODIFICACIÓN:
		///*******************************************************************************
		public static Boolean Modificar_Puesto(Cls_Cat_Nom_Puestos_Negocio P_Puestos)
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

				Mi_sql.Append("UPDATE " + Cat_Nom_Puestos.Tabla_Cat_Nom_Puestos + " SET ");
                if(P_Puestos.P_Nombre!=null && P_Puestos.P_Nombre.Trim()!="")
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Nombre + " = '" + P_Puestos.P_Nombre + "', ");
                if (P_Puestos.P_Descripcion != null && P_Puestos.P_Descripcion.Trim() != "")
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Descripcion + " = '" + P_Puestos.P_Descripcion + "', ");
                if (P_Puestos.P_Estatus != null && P_Puestos.P_Estatus.Trim() != "")
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Estatus + " = '" + P_Puestos.P_Estatus + "', ");
                Mi_sql.Append(Cat_Nom_Puestos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Nom_Puestos.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Nom_Puestos.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
				Mi_sql.Append(" WHERE " + Cat_Nom_Puestos.Campo_Puesto_Id + " = '" + P_Puestos.P_Puesto_Id + "'");
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
				throw new Exception("Modificar_Puesto: " + E.Message);
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
		///NOMBRE DE LA FUNCIÓN: Baja_Puesto
		///DESCRIPCIÓN: Modifica el estatus en la Base de Datos de Un proveedor
		///PARAMENTROS:     
		///             1. P_Puestos.       Instancia de la Clase de Negocio de Puestos 
		///                                 con los datos del que van a ser
		///                                 modificados.
		///CREO: Miguel Angel Bedolla Moreno.
		///FECHA_CREO: 14/Feb/2013 04:55:00 p.m. 
		///MODIFICO:
		///FECHA_MODIFICO:
		///CAUSA_MODIFICACIÓN:
		///*******************************************************************************
		public static Boolean Baja_Puesto(Cls_Cat_Nom_Puestos_Negocio P_Puestos)
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
				Mi_sql.Append("UPDATE " + Cat_Nom_Puestos.Tabla_Cat_Nom_Puestos + " SET ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Estatus + " = 'ELIMINADO', ");
                Mi_sql.Append(Cat_Nom_Puestos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Nom_Puestos.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Nom_Puestos.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
				Mi_sql.Append(Cat_Nom_Puestos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
				Mi_sql.Append(" WHERE " + Cat_Nom_Puestos.Campo_Puesto_Id + " = '" + P_Puestos.P_Puesto_Id + "'");
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
                throw new Exception("Baja_Puesto: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN: Consultar_Puestos
        ///DESCRIPCIÓN: Consulta los motivos de rechazo
        ///PARAMENTROS:     
        ///             1. P_Puestos.       Instancia de la Clase de Negocio de Puestos 
        ///                                 con los datos que servirán de
        ///                                 filtro.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 14/Febrero/2013 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static DataTable Consultar_Puestos(Cls_Cat_Nom_Puestos_Negocio P_Puestos)
        {
            DataTable Tabla = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
            String Aux_Filtros = ""; 
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {
                Mi_SQL.Append("SELECT " + Cat_Nom_Puestos.Campo_Puesto_Id
                    + ", " + Cat_Nom_Puestos.Campo_Nombre
                    + ", " + Cat_Nom_Puestos.Campo_Descripcion
                    + ", " + Cat_Nom_Puestos.Campo_Estatus
                    + ", " + Cat_Nom_Puestos.Campo_Fecha_Creo
                    + ", " + Cat_Nom_Puestos.Campo_Ip_Creo
                    + ", " + Cat_Nom_Puestos.Campo_Equipo_Creo
                    + ", " + Cat_Nom_Puestos.Campo_Usuario_Creo
                    + ", " + Cat_Nom_Puestos.Campo_Fecha_Modifico
                    + ", " + Cat_Nom_Puestos.Campo_Ip_Modifico
                    + ", " + Cat_Nom_Puestos.Campo_Equipo_Modifico
                    + ", " + Cat_Nom_Puestos.Campo_Usuario_Modifico
                    + " FROM  " + Cat_Nom_Puestos.Tabla_Cat_Nom_Puestos
                    + " WHERE ");
                if (P_Puestos.P_Nombre != null && P_Puestos.P_Nombre.Trim() != "")
                {
                    Mi_SQL.Append(Cat_Nom_Puestos.Campo_Nombre + " LIKE '%" + P_Puestos.P_Nombre + "%' AND ");
                }
                if (P_Puestos.P_Descripcion != null && P_Puestos.P_Descripcion.Trim() != "")
                {
                    Mi_SQL.Append(Cat_Nom_Puestos.Campo_Descripcion + " LIKE '%" + P_Puestos.P_Descripcion + "%' AND ");
                }
                if (P_Puestos.P_Estatus != null && P_Puestos.P_Estatus.Trim() != "")
                {
                    Mi_SQL.Append(Cat_Nom_Puestos.Campo_Estatus + P_Puestos.P_Estatus + " AND ");
                }
                if (P_Puestos.P_Puesto_Id != null && P_Puestos.P_Puesto_Id.Trim() != "")
                {
                    Mi_SQL.Append(Cat_Nom_Puestos.Campo_Puesto_Id + " = '" + P_Puestos.P_Puesto_Id + "' AND ");
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
                String Mensaje = "Error al intentar consultar los Puestos. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
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