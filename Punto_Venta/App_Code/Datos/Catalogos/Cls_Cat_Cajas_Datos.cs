using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;

namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Cajas_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Cajas
        ///DESCRIPCIÓN          : Registra una nueva caja en la base de datos
        ///PARÁMETROS           : P_Caja que contiene la información de la nueva caja a registrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Cajas(Cls_Cat_Cajas_Negocio P_Caja)
        {
            Boolean Alta = false;
            StringBuilder Mi_SQL = new StringBuilder();
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
                Usuario_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Cajas.Tabla_Cat_Cajas, Cat_Cajas.Campo_Caja_ID, "", 5);

                Mi_SQL.Append("INSERT INTO " + Cat_Cajas.Tabla_Cat_Cajas + " (");
                Mi_SQL.Append(Cat_Cajas.Campo_Caja_ID + ",");
                if (!String.IsNullOrEmpty(P_Caja.P_Numero_Caja)) 
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Numero_Caja + ",");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Estatus))
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Estatus + ",");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Comentarios))
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Comentarios + ",");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Nombre_Equipo))
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Nombre_Equipo + ",");
                }
                Mi_SQL.Append(Cat_Cajas.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Cajas.Campo_Fecha_Creo);
                Mi_SQL.Append(", " + Cat_Cajas.Campo_Serie);
                
                Mi_SQL.Append(") VALUES (");//*********************************************************************
                
                
                Mi_SQL.Append("'" + Usuario_ID + "',");
                if (!String.IsNullOrEmpty(P_Caja.P_Numero_Caja))
                {
                    Mi_SQL.Append("'" + P_Caja.P_Numero_Caja + "',");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Estatus))
                {
                    Mi_SQL.Append("'" + P_Caja.P_Estatus + "',");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Comentarios))
                {
                    Mi_SQL.Append("'" + P_Caja.P_Comentarios + "',");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Nombre_Equipo))
                {
                    Mi_SQL.Append("'" + P_Caja.P_Nombre_Equipo + "',");
                }
                Mi_SQL.Append("'" + P_Caja.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Caja.P_Fecha_Creo));
                Mi_SQL.Append(" , '" + P_Caja.P_Serie +"'");
                Mi_SQL.Append(")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Alta = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception e)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta de Cajas : " + e.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja
        ///DESCRIPCIÓN          : Modifica la información de una Caja en la base de datos
        ///PARÁMETROS           : P_Caja que contiene la información de la caja a modificar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Caja(Cls_Cat_Cajas_Negocio P_Caja)
        {
            try
            {
                StringBuilder Mi_SQL = new StringBuilder();
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("UPDATE " + Cat_Cajas.Tabla_Cat_Cajas + " SET ");
                if (!String.IsNullOrEmpty(P_Caja.P_Numero_Caja))
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Numero_Caja + " = '" + P_Caja.P_Numero_Caja + "',");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Estatus))
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Estatus + " = '" + P_Caja.P_Estatus + "',");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Comentarios))
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Comentarios + " = '" + P_Caja.P_Comentarios + "',");
                }
                //if (!String.IsNullOrEmpty(P_Caja.P_Nombre_Equipo))
                //{
                Mi_SQL.Append(Cat_Cajas.Campo_Nombre_Equipo + " = '" + P_Caja.P_Nombre_Equipo + "',");
                //}

                if (!String.IsNullOrEmpty(P_Caja.P_Serie))
                {
                    Mi_SQL.Append(Cat_Cajas.Campo_Serie + " = '" + P_Caja.P_Serie + "',");
                }
                Mi_SQL.Append(Cat_Cajas.Campo_Usuario_Modifico + " = '" + P_Caja.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Cajas.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Caja.P_Fecha_Modifico));
                Mi_SQL.Append(" WHERE " + Cat_Cajas.Campo_Caja_ID + " = '" + P_Caja.P_Caja_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Caja: " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Caja
        ///DESCRIPCIÓN          : Consulta informacion de una caja de la base de datos
        ///PARÁMETROS           : P_Caja que contiene los filtros de los productos a buscar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Caja(Cls_Cat_Cajas_Negocio P_Caja)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * ");
                Mi_SQL.Append(" , CONCAT ('C', " + Cat_Cajas.Campo_Numero_Caja + ") as Caja_Numero");
                Mi_SQL.Append( " FROM " + Cat_Cajas.Tabla_Cat_Cajas);
                if (!String.IsNullOrEmpty(P_Caja.P_Caja_ID))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Caja_ID + " = '" + P_Caja.P_Caja_ID + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Numero_Caja))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Numero_Caja + " = '" + P_Caja.P_Numero_Caja + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Estatus))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Estatus + " = '" + P_Caja.P_Estatus + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Comentarios))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Comentarios + " LIKE '" + P_Caja.P_Comentarios + "%'");
                    Segundo_Filtro = true;
                } 
                if (!String.IsNullOrEmpty(P_Caja.P_Nombre_Equipo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Cajas.Campo_Nombre_Equipo + " LIKE '" + P_Caja.P_Nombre_Equipo + "%'");
                    Segundo_Filtro = true;
                }
                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Caja : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Caja
        ///DESCRIPCIÓN          : Elimina la informacion de una caja de la base de datos
        ///PARÁMETROS           : P_Caja que contiene el id de la caja a eliminar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Caja(Cls_Cat_Cajas_Negocio P_Caja)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL.Append("DELETE FROM " + Cat_Cajas.Tabla_Cat_Cajas);
            Mi_SQL.Append(" WHERE " + Cat_Cajas.Campo_Caja_ID + " = '" + P_Caja.P_Caja_ID + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}
