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
    class Cls_Cat_Motivos_Descuento_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Motivos_Descuento
        ///DESCRIPCIÓN          : Registra un nuevo de motivo de descuento en la base de datos
        ///PARÁMETROS           : P_Motivos_Descuento que contiene la información del nuevo motivo de descuento a registrar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static Boolean Alta_Motivos_Descuento(Cls_Cat_Motivos_Descuento_Negocio P_Motivos_Descuento)
        {
            Boolean Alta = false;
            StringBuilder Mi_SQL= new StringBuilder();
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
                Usuario_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Motivos_Descuento.Tabla_Cat_Motivos_Descuento, Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID, "", 5);

                Mi_SQL.Append("INSERT INTO " + Cat_Motivos_Descuento.Tabla_Cat_Motivos_Descuento + " (");
                Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID + ",");
                if (!String.IsNullOrEmpty(P_Motivos_Descuento.P_Descripcion))
                {
                    Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Descripcion + ",");
                }
                Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Usuario_ID + "',");
                if (!String.IsNullOrEmpty(P_Motivos_Descuento.P_Descripcion))
                {
                    Mi_SQL.Append("'" + P_Motivos_Descuento.P_Descripcion + "',");
                }
                Mi_SQL.Append("'" + P_Motivos_Descuento.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Motivos_Descuento.P_Fecha_Creo) + ")");
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
                throw new Exception("Alta de Motivos de Descuento : " + e.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Motivos_Descuento
        ///DESCRIPCIÓN          : Modifica la información de un motivo de descuento en la base de datos
        ///PARÁMETROS           : P_Motivos_Descuento que contiene la información de un motivo de descuento a modificar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Modificar_Motivos_Descuentos(Cls_Cat_Motivos_Descuento_Negocio P_Motivos_Descuento)
        {
            try
            {
                StringBuilder Mi_SQL = new StringBuilder();
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("UPDATE " + Cat_Motivos_Descuento.Tabla_Cat_Motivos_Descuento + " SET ");
                if (!string.IsNullOrEmpty(P_Motivos_Descuento.P_Descripcion))
                {
                    Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Descripcion + " = '" + P_Motivos_Descuento.P_Descripcion + "',");
                }
                Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Usuario_Modifico + " = '" + P_Motivos_Descuento.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Motivos_Descuento.P_Fecha_Modifico) + " ");
                Mi_SQL.Append("WHERE " + Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID + " = '" + P_Motivos_Descuento.P_Motivos_Descuento_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Motivo de Descuento; " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Motivos_Descuento
        ///DESCRIPCIÓN          : Consulta informacion de los motivos de descuento de la base de datos
        ///PARÁMETROS           : P_Motivos_Descuento que contiene los filtros del motivo de descuento a buscar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Motivos_Descuento(Cls_Cat_Motivos_Descuento_Negocio P_Motivos_Descuento)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM " + Cat_Motivos_Descuento.Tabla_Cat_Motivos_Descuento);
                if (!string.IsNullOrEmpty(P_Motivos_Descuento.P_Motivos_Descuento_ID))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE " );
                    Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID + " = '" + P_Motivos_Descuento.P_Motivos_Descuento_ID + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Motivos_Descuento.P_Descripcion))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Motivos_Descuento.Campo_Descripcion + " LIKE '" + P_Motivos_Descuento.P_Descripcion + "%'");
                    Segundo_Filtro = true;
                }
                    return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Motivos de Descuento : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Motivos_Descuento
        ///DESCRIPCIÓN          : Elimina la informacion de un motivo de descuento de la base de datos
        ///PARÁMETROS           : P_Motivos_Descuento que contiene el id del motivo de descuento a eliminar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Eliminar_Motivos_Descuento(Cls_Cat_Motivos_Descuento_Negocio P_Motivos_Descuento)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL.Append("DELETE FROM " + Cat_Motivos_Descuento.Tabla_Cat_Motivos_Descuento);
            Mi_SQL.Append(" WHERE " + Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID + " = '" + P_Motivos_Descuento.P_Motivos_Descuento_ID + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    
    }
}
