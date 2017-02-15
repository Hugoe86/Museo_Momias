using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Proveedores.Negocio;
using Erp.Metodos_Generales;
using System.Text;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using System.Data;
using Erp.Helper;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Cat_Proveedores.Datos
{
	public class Cls_Cat_Proveedores_Datos
	{
		///*******************************************************************************
		///NOMBRE DE LA FUNCIÓN: Alta_Proveedor
		///DESCRIPCIÓN: Da de alta en la Base de Datos Un nuevo Proveedor
		///PARAMENTROS:     
		///             1. P_Proveedor.     Instancia de la Clase de Negocio de Proveedores 
		///                                 con los datos del que van a ser
		///                                 dados de Alta.
		///CREO: Miguel Angel Bedolla Moreno.
		///FECHA_CREO: 15/Feb/2013 12:30:00 p.m. 
		///MODIFICO:
		///FECHA_MODIFICO:
		///CAUSA_MODIFICACIÓN:
		///*******************************************************************************
		public static Boolean Alta_Proveedor(Cls_Cat_Proveedores_Negocio P_Proveedor)
		{
			Boolean Alta = false;
			StringBuilder Mi_sql = new StringBuilder(); ;
			String Proveedor_Id = "";
            Boolean Transaccion_Activa = false;
			try
            {
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

                Proveedor_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores, Cat_Adm_Proveedores.Campo_Proveedor_Id, "", 10);
				
                Mi_sql.Append("INSERT INTO " + Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores + "(");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Proveedor_Id + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Giro_Id + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Nombre_Corto + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Razon_Social + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_RFC + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Pais + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Estado + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Localidad + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Colonia + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Ciudad + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Calle + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Numero_Exterior + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Numero_Interior + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_CP + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Fax + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Telefono + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Extension + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Nextel + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Email + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Sitio_Web + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Dias_Credito + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Limite_Credito + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Descuento + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Estatus + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Usuario_Creo + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Ip_Creo + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Equipo_Creo + ", ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Fecha_Creo);
				Mi_sql.Append(") VALUES (");
				Mi_sql.Append("'" + Proveedor_Id + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Giro_Id + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Nombre_Corto + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Razon_Social + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Rfc + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Pais + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Estado + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Localidad + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Colonia + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Ciudad + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Calle + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Numero_Exterior + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Numero_Interior + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Codigo_Postal + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Fax + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Telefono + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Extension + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Nextel + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Email + "', ");
				Mi_sql.Append("'" + P_Proveedor.P_Sitio_Web + "', ");
				Mi_sql.Append("" + P_Proveedor.P_Dias_Credito + ", ");
				Mi_sql.Append("" + P_Proveedor.P_Limite_Credito + ", ");
				Mi_sql.Append("" + P_Proveedor.P_Descuento + ", ");
				Mi_sql.Append("'" + P_Proveedor.P_Estatus + "', ");
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
				throw new Exception("Alta_Proveedor: " + E.Message);
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
		///NOMBRE DE LA FUNCIÓN: Modificar_Proveedor
		///DESCRIPCIÓN: Modifica en la Base de Datos Un Proveedor
		///PARAMENTROS:     
		///             1. P_Proveedor.     Instancia de la Clase de Negocio de Proveedores 
		///                                 con los datos del que van a ser
		///                                 modificados.
		///CREO: Miguel Angel Bedolla Moreno.
		///FECHA_CREO: 15/Feb/2013 01:10:00 p.m. 
		///MODIFICO:
		///FECHA_MODIFICO:
		///CAUSA_MODIFICACIÓN:
		///*******************************************************************************
		public static Boolean Modificar_Proveedor(Cls_Cat_Proveedores_Negocio P_Proveedor)
		{
			Boolean Modificado = false;
			StringBuilder Mi_sql = new StringBuilder();
            Boolean Transaccion_Activa = false;

			try
			{
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

				Mi_sql.Append("UPDATE " + Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores + " SET ");
				if(P_Proveedor.P_Giro_Id != null && P_Proveedor.P_Giro_Id.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Giro_Id + " = '" + P_Proveedor.P_Giro_Id + "', ");
				if (P_Proveedor.P_Nombre_Corto != null && P_Proveedor.P_Nombre_Corto.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Nombre_Corto + " = '" + P_Proveedor.P_Nombre_Corto + "', ");
				if (P_Proveedor.P_Razon_Social != null && P_Proveedor.P_Razon_Social.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Razon_Social + " = '" + P_Proveedor.P_Razon_Social + "', ");
				if (P_Proveedor.P_Rfc != null && P_Proveedor.P_Rfc.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_RFC + " = '" + P_Proveedor.P_Rfc + "', ");
				if (P_Proveedor.P_Pais != null && P_Proveedor.P_Pais.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Pais + " = '" + P_Proveedor.P_Pais + "', ");
				if (P_Proveedor.P_Estado != null && P_Proveedor.P_Estado.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Estado + " = '" + P_Proveedor.P_Estado + "', ");
				if (P_Proveedor.P_Localidad != null && P_Proveedor.P_Localidad.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Localidad + " = '" + P_Proveedor.P_Localidad + "', ");
				if (P_Proveedor.P_Colonia != null && P_Proveedor.P_Colonia.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Colonia + " = '" + P_Proveedor.P_Colonia + "', ");
				if (P_Proveedor.P_Ciudad != null && P_Proveedor.P_Ciudad.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Ciudad + " = '" + P_Proveedor.P_Ciudad + "', ");
				if (P_Proveedor.P_Calle != null && P_Proveedor.P_Calle.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Calle + " = '" + P_Proveedor.P_Calle + "', ");
				if (P_Proveedor.P_Numero_Exterior != null && P_Proveedor.P_Numero_Exterior.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Numero_Exterior + " = '" + P_Proveedor.P_Numero_Exterior + "', ");
				if (P_Proveedor.P_Numero_Interior != null && P_Proveedor.P_Numero_Interior.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Numero_Interior + " = '" + P_Proveedor.P_Numero_Interior + "', ");
				if (P_Proveedor.P_Codigo_Postal != null && P_Proveedor.P_Codigo_Postal.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_CP + " = '" + P_Proveedor.P_Codigo_Postal + "', ");
				if (P_Proveedor.P_Fax != null && P_Proveedor.P_Fax.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Fax + " = '" + P_Proveedor.P_Fax + "', ");
				if (P_Proveedor.P_Telefono != null && P_Proveedor.P_Telefono.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Telefono + " = '" + P_Proveedor.P_Telefono + "', ");
				if (P_Proveedor.P_Extension != null && P_Proveedor.P_Extension.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Extension + " = '" + P_Proveedor.P_Extension + "', ");
				if (P_Proveedor.P_Nextel != null && P_Proveedor.P_Nextel.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Nextel + " = '" + P_Proveedor.P_Nextel + "', ");
				if (P_Proveedor.P_Email != null && P_Proveedor.P_Email.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Email + " = '" + P_Proveedor.P_Email + "', ");
				if (P_Proveedor.P_Sitio_Web != null && P_Proveedor.P_Sitio_Web.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Sitio_Web + " = '" + P_Proveedor.P_Sitio_Web + "', ");
				if (P_Proveedor.P_Dias_Credito != null && P_Proveedor.P_Dias_Credito.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Dias_Credito + " = " + P_Proveedor.P_Dias_Credito + ", ");
				if (P_Proveedor.P_Limite_Credito != null && P_Proveedor.P_Limite_Credito.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Limite_Credito + " = " + P_Proveedor.P_Limite_Credito + ", ");
				if (P_Proveedor.P_Descuento != null && P_Proveedor.P_Descuento.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Descuento + " = " + P_Proveedor.P_Descuento + ", ");
				if (P_Proveedor.P_Estatus != null && P_Proveedor.P_Estatus.Trim() != "")
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Estatus + " = '" + P_Proveedor.P_Estatus + "', ");
                Mi_sql.Append(Cat_Adm_Proveedores.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Adm_Proveedores.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Adm_Proveedores.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
				Mi_sql.Append(" WHERE " + Cat_Adm_Proveedores.Campo_Proveedor_Id + " = '" + P_Proveedor.P_Proveedor_Id + "'");
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
				throw new Exception("Modificar_Proveedor: " + E.Message);
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
		///NOMBRE DE LA FUNCIÓN: Baja_Proveedor
		///DESCRIPCIÓN: Modifica el estatus en la Base de Datos un Proveedor
		///PARAMENTROS:     
		///             1. P_Proveedor.     Instancia de la Clase de Negocio de Contactos
		///                                 con los datos del que van a ser
		///                                 modificados.
		///CREO: Miguel Angel Bedolla Moreno.
		///FECHA_CREO: 15/Feb/2013 01:20:00 p.m. 
		///MODIFICO:
		///FECHA_MODIFICO:
		///CAUSA_MODIFICACIÓN:
		///*******************************************************************************
		public static Boolean Baja_Proveedor(Cls_Cat_Proveedores_Negocio P_Proveedor)
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
				Mi_sql.Append("UPDATE " + Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores + " SET ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Estatus + " = 'ELIMINADO', ");
                Mi_sql.Append(Cat_Adm_Proveedores.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Adm_Proveedores.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Adm_Proveedores.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
				Mi_sql.Append(Cat_Adm_Proveedores.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
				Mi_sql.Append(" WHERE " + Cat_Adm_Proveedores.Campo_Proveedor_Id + " = '" + P_Proveedor.P_Proveedor_Id + "'");
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
				throw new Exception("Baja_Proveedor: " + E.Message);
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
		///NOMBRE DE LA FUNCIÓN: Consultar_Proveedores
		///DESCRIPCIÓN: Consulta los Proveedores
		///PARAMENTROS:     
		///             1. P_Proveedor.     Instancia de la Clase de Negocio de Proveedores 
		///                                 con los datos que servirán de
		///                                 filtro.
		///CREO: Miguel Angel Bedolla Moreno.
		///FECHA_CREO: 15/Feb/2013 01:30:00 p.m. 
		///MODIFICO:
		///FECHA_MODIFICO:
		///CAUSA_MODIFICACIÓN:
		///*******************************************************************************
		public static DataTable Consultar_Proveedores(Cls_Cat_Proveedores_Negocio P_Proveedor)
		{
			DataTable Tabla = new DataTable();
			StringBuilder Mi_SQL = new StringBuilder();
            String Aux_Filtros = ""; 
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {
                Mi_SQL.Append("SELECT PR." + Cat_Adm_Proveedores.Campo_Proveedor_Id
                    + ", PR." + Cat_Adm_Proveedores.Campo_Giro_Id
                    + ", (SELECT GE." + Cat_Adm_Giros_Empresariales.Campo_Nombre + " FROM " + Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales + " GE WHERE GE." + Cat_Adm_Giros_Empresariales.Campo_Giro_Id + "=PR." + Cat_Adm_Proveedores.Campo_Giro_Id + ") AS NOMBRE_GIRO"
                    + ", PR." + Cat_Adm_Proveedores.Campo_Nombre_Corto
                    + ", PR." + Cat_Adm_Proveedores.Campo_Razon_Social
                    + ", PR." + Cat_Adm_Proveedores.Campo_RFC
                    + ", PR." + Cat_Adm_Proveedores.Campo_Pais
                    + ", PR." + Cat_Adm_Proveedores.Campo_Estado
                    + ", PR." + Cat_Adm_Proveedores.Campo_Localidad
                    + ", PR." + Cat_Adm_Proveedores.Campo_Colonia
                    + ", PR." + Cat_Adm_Proveedores.Campo_Ciudad
                    + ", PR." + Cat_Adm_Proveedores.Campo_Calle
                    + ", PR." + Cat_Adm_Proveedores.Campo_Numero_Exterior
                    + ", PR." + Cat_Adm_Proveedores.Campo_Numero_Interior
                    + ", PR." + Cat_Adm_Proveedores.Campo_CP
                    + ", PR." + Cat_Adm_Proveedores.Campo_Fax
                    + ", PR." + Cat_Adm_Proveedores.Campo_Telefono
                    + ", PR." + Cat_Adm_Proveedores.Campo_Extension
                    + ", PR." + Cat_Adm_Proveedores.Campo_Nextel
                    + ", PR." + Cat_Adm_Proveedores.Campo_Email
                    + ", PR." + Cat_Adm_Proveedores.Campo_Sitio_Web
                    + ", PR." + Cat_Adm_Proveedores.Campo_Dias_Credito
                    + ", PR." + Cat_Adm_Proveedores.Campo_Limite_Credito
                    + ", PR." + Cat_Adm_Proveedores.Campo_Descuento
                    + ", PR." + Cat_Adm_Proveedores.Campo_Estatus
                    + ", PR." + Cat_Adm_Proveedores.Campo_Fecha_Creo
                    + ", PR." + Cat_Adm_Proveedores.Campo_Ip_Creo
                    + ", PR." + Cat_Adm_Proveedores.Campo_Equipo_Creo
                    + ", PR." + Cat_Adm_Proveedores.Campo_Usuario_Creo
                    + ", PR." + Cat_Adm_Proveedores.Campo_Fecha_Modifico
                    + ", PR." + Cat_Adm_Proveedores.Campo_Ip_Modifico
                    + ", PR." + Cat_Adm_Proveedores.Campo_Equipo_Modifico
                    + ", PR." + Cat_Adm_Proveedores.Campo_Usuario_Modifico
                    + " FROM  " + Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores + " PR"
                    + " WHERE ");
                if (P_Proveedor.P_Proveedor_Id != null && P_Proveedor.P_Proveedor_Id.Trim() != "")
                {
                    Mi_SQL.Append(" PR." + Cat_Adm_Proveedores.Campo_Proveedor_Id + " = '" + P_Proveedor.P_Proveedor_Id + "' AND ");
                }
                if (P_Proveedor.P_Giro_Id != null && P_Proveedor.P_Giro_Id.Trim() != "")
                {
                    Mi_SQL.Append(" PR." + Cat_Adm_Proveedores.Campo_Giro_Id + " = '" + P_Proveedor.P_Giro_Id + "' AND ");
                }
                if (P_Proveedor.P_Nombre_Giro != null && P_Proveedor.P_Nombre_Giro.Trim() != "")
                {
                    Mi_SQL.Append(" PR." + Cat_Adm_Proveedores.Campo_Giro_Id + " IN (SELECT GE." + Cat_Adm_Giros_Empresariales.Campo_Nombre + " FROM " + Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales + " GE WHERE GE." + Cat_Adm_Giros_Empresariales.Campo_Nombre + " LIKE '%" + P_Proveedor.P_Nombre_Giro + "%') AND ");
                }
                if (P_Proveedor.P_Razon_Social != null && P_Proveedor.P_Razon_Social.Trim() != "")
                {
                    Mi_SQL.Append(" PR." + Cat_Adm_Proveedores.Campo_Razon_Social + " LIKE '%" + P_Proveedor.P_Razon_Social + "%' AND ");
                }
                if (P_Proveedor.P_Nombre_Corto != null && P_Proveedor.P_Nombre_Corto.Trim() != "")
                {
                    Mi_SQL.Append(" PR." + Cat_Adm_Proveedores.Campo_Nombre_Corto + " LIKE '%" + P_Proveedor.P_Nombre_Corto + "%' AND ");
                }
                if (P_Proveedor.P_Rfc != null && P_Proveedor.P_Rfc.Trim() != "")
                {
                    Mi_SQL.Append(" PR." + Cat_Adm_Proveedores.Campo_RFC + " LIKE '%" + P_Proveedor.P_Rfc + "%' AND ");
                }
                if (P_Proveedor.P_Estatus != null && P_Proveedor.P_Estatus.Trim() != "")
                {
                    Mi_SQL.Append(" PR." + Cat_Adm_Proveedores.Campo_Estatus + P_Proveedor.P_Estatus + " AND ");
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
                String Mensaje = "Error al intentar consultar los Proveedores. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
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