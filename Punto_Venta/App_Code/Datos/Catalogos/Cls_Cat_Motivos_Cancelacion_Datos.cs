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
    class Cls_Cat_Motivos_Cancelacion_Datos
    {

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Motivos_Cancelación
        ///DESCRIPCIÓN          : Registra un nuevo de motivo de cancelación en la base de datos
        ///PARÁMETROS           : P_Motivos_Cancelacion que contiene la información del nuevo motivo de cancelación a registrar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static Boolean Alta_Motivos_Cancelacion(Cls_Cat_Motivos_Cancelacion_Negocio P_Motivos_Cancelacion)
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
                Usuario_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Motivos_Cancelacion.Tabla_Cat_Motivos_Cancelacion, Cat_Motivos_Cancelacion.Campo_Motivo_ID, "", 5);

                Mi_SQL.Append("INSERT INTO " + Cat_Motivos_Cancelacion.Tabla_Cat_Motivos_Cancelacion + " (");
                Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Motivo_ID + ",");

                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Motivo))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Motivo + ",");
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Descripción))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Descripcion + ",");
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Leyenda))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Leyenda + ",");
                }
                if(!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Estatus))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Estatus + ",");
                }
                Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Usuario_ID + "',");

                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Motivo))
                {
                    Mi_SQL.Append("'" + P_Motivos_Cancelacion.P_Motivo + "',");
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Descripción))
                {
                    Mi_SQL.Append("'" + P_Motivos_Cancelacion.P_Descripción + "',");
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Leyenda))
                {
                    Mi_SQL.Append("'" + P_Motivos_Cancelacion.P_Leyenda + "',");
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Estatus))
                {
                    Mi_SQL.Append("'" + P_Motivos_Cancelacion.P_Estatus + "',");
                }
                Mi_SQL.Append("'" + P_Motivos_Cancelacion.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Motivos_Cancelacion.P_Fecha_Creo) + ")");
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
                throw new Exception("Alta de Motivos de Cancelación : " + e.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Motivos_Cancelacion
        ///DESCRIPCIÓN          : Modifica la información de un motivo de Cancelación en la base de datos
        ///PARÁMETROS           : P_Motivos_Cancelacion que contiene la información de un motivo de cancelación a modificar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Modificar_Motivos_Decuentos(Cls_Cat_Motivos_Cancelacion_Negocio P_Motivos_Cancelacion)
        {
            try
            {
                StringBuilder Mi_SQL = new StringBuilder();
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("UPDATE " + Cat_Motivos_Cancelacion.Tabla_Cat_Motivos_Cancelacion + " SET ");
                if (!string.IsNullOrEmpty(P_Motivos_Cancelacion.P_Motivo))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Motivo + " = '" + P_Motivos_Cancelacion.P_Motivo + "',");
                }
                if (!string.IsNullOrEmpty(P_Motivos_Cancelacion.P_Descripción))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Descripcion + " = '" + P_Motivos_Cancelacion.P_Descripción + "',");
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Leyenda))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Leyenda + " = '" + P_Motivos_Cancelacion.P_Leyenda + "',");
                }
                if (!String.IsNullOrEmpty(Cat_Motivos_Cancelacion.Campo_Estatus))
                {
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Estatus + " = '" + P_Motivos_Cancelacion.P_Estatus + "',");
                }
                Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Usuario_Modifico + " = '" + P_Motivos_Cancelacion.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Motivos_Cancelacion.P_Fecha_Modifico) + " ");
                Mi_SQL.Append("WHERE " + Cat_Motivos_Cancelacion.Campo_Motivo_ID + " = '" + P_Motivos_Cancelacion.P_Motivo_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Motivo de Cancelación:  " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Motivos_Cancelacion
        ///DESCRIPCIÓN          : Consulta informacion de un Motivo de cancelación de la base de datos
        ///PARÁMETROS           : P_Motivos_Cancelacion que contiene los filtros de los motivos de cancelación a buscar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static System.Data.DataTable Consultar_Motivos_Cancelacion(Cls_Cat_Motivos_Cancelacion_Negocio P_Motivos_Cancelacion)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM " + Cat_Motivos_Cancelacion.Tabla_Cat_Motivos_Cancelacion);

                
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Motivo_ID))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Motivo_ID + " = '" + P_Motivos_Cancelacion.P_Motivo_ID + "'");
                    Segundo_Filtro = true;
                }

                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Motivo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Motivo + " LIKE '" + P_Motivos_Cancelacion.P_Motivo + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Descripción))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Descripcion + " LIKE '" + P_Motivos_Cancelacion.P_Descripción + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Leyenda))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Leyenda + " LIKE '" + P_Motivos_Cancelacion.P_Leyenda + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Motivos_Cancelacion.P_Estatus))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Motivos_Cancelacion.Campo_Estatus + " = '" + P_Motivos_Cancelacion.P_Estatus + "'");
                    Segundo_Filtro = true;
                }

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Motivo de Cancelacion : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Motivos_Cancelacion
        ///DESCRIPCIÓN          : Elimina la informacion de un motivo de Cancelación de la base de datos
        ///PARÁMETROS           : P_Motivos_Cancelacion que contiene el id del motivo de cancelación a eliminar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Emininar_Motivos_Cancelacion(Cls_Cat_Motivos_Cancelacion_Negocio P_Motivos_Cancelacion)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL.Append("DELETE FROM " + Cat_Motivos_Cancelacion.Tabla_Cat_Motivos_Cancelacion);
            Mi_SQL.Append(" WHERE " + Cat_Motivos_Cancelacion.Campo_Motivo_ID + " = '" + P_Motivos_Cancelacion.P_Motivo_ID + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
 
    }
}
