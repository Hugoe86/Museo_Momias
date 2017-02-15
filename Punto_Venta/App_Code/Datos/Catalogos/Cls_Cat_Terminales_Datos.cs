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
    class Cls_Cat_Terminales_Datos
    {

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Terminales
        ///DESCRIPCIÓN          : Registra una nueva Terminal en la base de datos
        ///PARÁMETROS           : P_Terminal que contiene la información de la nueva Terminal a registrar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static Boolean Alta_Terminales(Cls_Cat_Terminales_Negocio P_Terminales)
        {
            Boolean Alta = false;
            StringBuilder Mi_SQL = new StringBuilder();
            string Usuario_ID = "";
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
                Usuario_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Terminales.Tabla_Cat_Terminales, Cat_Terminales.Campo_Terminal_ID, "", 5);

                Mi_SQL.Append("INSERT INTO " + Cat_Terminales.Tabla_Cat_Terminales + " (");
                Mi_SQL.Append(Cat_Terminales.Campo_Terminal_ID + ",");

                if (!String.IsNullOrEmpty(P_Terminales.P_Nombre))
                {
                    Mi_SQL.Append(Cat_Terminales.Campo_Nombre + ",");
                }
                if (!String.IsNullOrEmpty(P_Terminales.P_Puerto))
                {
                    Mi_SQL.Append(Cat_Terminales.Campo_Puerto + ",");
                }
                Mi_SQL.Append(Cat_Terminales.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Terminales.Campo_Fecha_Creo);
                Mi_SQL.Append(", " + Cat_Terminales.Campo_Equipo);
                Mi_SQL.Append(", " + Cat_Terminales.Campo_Estatus);

                Mi_SQL.Append(") VALUES (");//************************************************

                Mi_SQL.Append("'" + Usuario_ID + "',");

                if (!String.IsNullOrEmpty(P_Terminales.P_Nombre))
                {
                    Mi_SQL.Append("'" + P_Terminales.P_Nombre + "',");
                }
                if (!String.IsNullOrEmpty(P_Terminales.P_Puerto))
                {
                    Mi_SQL.Append("'" + P_Terminales.P_Puerto + "',");
                }
                Mi_SQL.Append("'" + P_Terminales.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Terminales.P_Fecha_Creo));
                Mi_SQL.Append(", '" + P_Terminales.P_Equipo + "'");
                Mi_SQL.Append(", '" + P_Terminales.P_Estatus + "'");
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
                throw new Exception("Alta de Terminales : " + e.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Terminales
        ///DESCRIPCIÓN          : Modifica la información de una Terminal en la base de datos
        ///PARÁMETROS           : P_Terminales que contiene la información de una Terminal a modificar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Modificar_Terminales(Cls_Cat_Terminales_Negocio P_Terminales)
        {
            try
            {
                StringBuilder Mi_SQL = new StringBuilder();
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("UPDATE " + Cat_Terminales.Tabla_Cat_Terminales + " SET ");

                if (!string.IsNullOrEmpty(P_Terminales.P_Nombre))
                {
                    Mi_SQL.Append(Cat_Terminales.Campo_Nombre + " = '" + P_Terminales.P_Nombre + "',");
                }
                //if (!string.IsNullOrEmpty(P_Terminales.P_Puerto))
                //{
                Mi_SQL.Append(Cat_Terminales.Campo_Puerto + " = '" + P_Terminales.P_Puerto + "',");
                //}
                Mi_SQL.Append(Cat_Terminales.Campo_Usuario_Modifico + " = '" + P_Terminales.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Terminales.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Terminales.P_Fecha_Modifico) + " ");

                Mi_SQL.Append(", " + Cat_Terminales.Campo_Equipo + " = '" + P_Terminales.P_Equipo + "'");
                Mi_SQL.Append(", " + Cat_Terminales.Campo_Estatus + " = '" + P_Terminales.P_Estatus + "'");

                Mi_SQL.Append("WHERE " + Cat_Terminales.Campo_Terminal_ID + " = '" + P_Terminales.P_Terminal_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Terminal:  " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Terminales
        ///DESCRIPCIÓN          : Consulta informacion de las Terminales de la base de datos
        ///PARÁMETROS           : P_Terminales que contiene los filtros de las Terminales a buscar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static System.Data.DataTable Consultar_Terminales(Cls_Cat_Terminales_Negocio P_Terminales)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM " + Cat_Terminales.Tabla_Cat_Terminales);

                if (!String.IsNullOrEmpty(P_Terminales.P_Terminal_ID))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Terminales.Campo_Terminal_ID + " = '" + P_Terminales.P_Terminal_ID + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Terminales.P_Nombre))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Terminales.Campo_Nombre + " LIKE '" + P_Terminales.P_Nombre+ "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Terminales.P_Puerto))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Terminales.Campo_Puerto + " LIKE '" + P_Terminales.P_Puerto + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Terminales.P_Equipo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Terminales.Campo_Equipo+ " = '" + P_Terminales.P_Equipo + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Terminales.P_Estatus))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Terminales.Campo_Estatus + " = '" + P_Terminales.P_Estatus + "'");
                    Segundo_Filtro = true;
                }
                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Terminales : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Terminales
        ///DESCRIPCIÓN          : Elimina la informacion de una Terminal de la base de datos
        ///PARÁMETROS           : P_Terminales que contiene el id de la Terminal a eliminar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Eliminar_Terminales(Cls_Cat_Terminales_Negocio P_Terminales)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL.Append("DELETE FROM " + Cat_Terminales.Tabla_Cat_Terminales);
            Mi_SQL.Append(" WHERE " + Cat_Terminales.Campo_Terminal_ID + " = '" + P_Terminales.P_Terminal_ID + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
       
    }
}
