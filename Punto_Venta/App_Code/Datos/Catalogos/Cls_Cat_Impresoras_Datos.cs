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
    class Cls_Cat_Impresoras_Datos
    {

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Impresoras
        ///DESCRIPCIÓN          : Registra una nueva impresora en la base de datos
        ///PARÁMETROS           : P_Impresora que contiene la información de la nueva impresora a registrar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static Boolean Alta_Impresoras(Cls_Cat_Impresoras_Negocio P_Impresoras)
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
                Usuario_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Impresoras.Tabla_Cat_Impresoras, Cat_Impresoras.Campo_Impresora_Id, "", 5);

                Mi_SQL.Append("INSERT INTO " + Cat_Impresoras.Tabla_Cat_Impresoras + " (");
                Mi_SQL.Append(Cat_Impresoras.Campo_Impresora_Id + ",");

                if (!String.IsNullOrEmpty(P_Impresoras.P_Nombre_Impresora))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Nombre_Impresora + ",");
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Ip))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Ip + ",");
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Ubicacion))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Ubicacion + ",");
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Comentarios))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Comentarios + ",");
                }
                Mi_SQL.Append(Cat_Impresoras.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Impresoras.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Usuario_ID + "',");

                if (!String.IsNullOrEmpty(P_Impresoras.P_Nombre_Impresora))
                {
                    Mi_SQL.Append("'" + P_Impresoras.P_Nombre_Impresora + "',");
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Ip))
                {
                    Mi_SQL.Append("'" + P_Impresoras.P_Ip + "',");
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Ubicacion))
                {
                    Mi_SQL.Append("'" + P_Impresoras.P_Ubicacion + "',");
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Comentarios))
                {
                    Mi_SQL.Append("'" + P_Impresoras.P_Comentarios + "',");
                }
                Mi_SQL.Append("'" + P_Impresoras.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Impresoras.P_Fecha_Creo) + ")");
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
                throw new Exception("Alta de Impresoras : " + e.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Impresoras
        ///DESCRIPCIÓN          : Modifica la información de una Impresora en la base de datos
        ///PARÁMETROS           : P_Impresora que contiene la información de una impresora a modificar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Modificar_Impresoras(Cls_Cat_Impresoras_Negocio P_Impresoras)
        {
            try
            {
                StringBuilder Mi_SQL = new StringBuilder();
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("UPDATE " + Cat_Impresoras.Tabla_Cat_Impresoras + " SET ");

                if (!string.IsNullOrEmpty(P_Impresoras.P_Nombre_Impresora))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Nombre_Impresora + " = '" + P_Impresoras.P_Nombre_Impresora + "',");
                }
                if (!string.IsNullOrEmpty(P_Impresoras.P_Ip))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Ip + " = '" + P_Impresoras.P_Ip + "',");
                }
                if (!string.IsNullOrEmpty(P_Impresoras.P_Ubicacion))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Ubicacion + " = '" + P_Impresoras.P_Ubicacion + "',");
                }
                if (!string.IsNullOrEmpty(P_Impresoras.P_Comentarios))
                {
                    Mi_SQL.Append(Cat_Impresoras.Campo_Comentarios + " = '" + P_Impresoras.P_Comentarios + "',");
                }
                Mi_SQL.Append(Cat_Impresoras.Campo_Usuario_Modifico + " = '" + P_Impresoras.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Impresoras.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Impresoras.P_Fecha_Modifico) + " ");
                Mi_SQL.Append("WHERE " + Cat_Impresoras.Campo_Impresora_Id + " = '" + P_Impresoras.P_Impresora_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Impresora:  " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Impresoras
        ///DESCRIPCIÓN          : Consulta informacion de las impresoras de la base de datos
        ///PARÁMETROS           : P_Impresoras que contiene los filtros de las impresoras a buscar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static System.Data.DataTable Consultar_Impresoras(Cls_Cat_Impresoras_Negocio P_Impresoras)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM " + Cat_Impresoras.Tabla_Cat_Impresoras);

                if (!String.IsNullOrEmpty(P_Impresoras.P_Impresora_Id))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Impresoras.Campo_Impresora_Id + " = '" + P_Impresoras.P_Impresora_Id + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Nombre_Impresora))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Impresoras.Campo_Nombre_Impresora + " LIKE '" + P_Impresoras.P_Nombre_Impresora + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Ip))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Impresoras.Campo_Ip + " LIKE '" + P_Impresoras.P_Ip + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Ubicacion))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Impresoras.Campo_Ubicacion + " LIKE '" + P_Impresoras.P_Ubicacion + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Impresoras.P_Comentarios))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Impresoras.Campo_Comentarios + " LIKE '" + P_Impresoras.P_Comentarios + "%'");
                    Segundo_Filtro = true;
                }
                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Impresoras : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Impresoras
        ///DESCRIPCIÓN          : Elimina la informacion de una impresora de la base de datos
        ///PARÁMETROS           : P_Impresoras que contiene el id de la impresora a eliminar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Eliminar_Impresoras(Cls_Cat_Impresoras_Negocio P_Impresoras)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL.Append("DELETE FROM " + Cat_Impresoras.Tabla_Cat_Impresoras);
            Mi_SQL.Append(" WHERE " + Cat_Impresoras.Campo_Impresora_Id + " = '" + P_Impresoras.P_Impresora_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

    }
}
