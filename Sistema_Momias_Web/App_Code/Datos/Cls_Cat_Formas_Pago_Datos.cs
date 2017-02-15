using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Helper;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Ayudante_Sintaxis;

namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Formas_Pago_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Forma_Pago
        ///DESCRIPCIÓN          : Guarda la información de la forma de pago en la base de datos
        ///PARÁMETROS           : P_Forma_Pago que contiene la información de la forma de pago
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Forma_Pago(Cls_Cat_Formas_Pago_Negocio P_Forma_Pago) 
        {
            Boolean Alta = true;
            StringBuilder Mi_SQL = new StringBuilder();
            String Forma_Pago_ID;

            try 
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Forma_Pago_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Formas_Pago.Tabla_Cat_Formas_Pago, Cat_Formas_Pago.Campo_Forma_ID, "", 5);

                Mi_SQL.Append("INSERT INTO " + Cat_Formas_Pago.Tabla_Cat_Formas_Pago + "(");
                Mi_SQL.Append(Cat_Formas_Pago.Campo_Forma_ID + ",");
                Mi_SQL.Append(Cat_Formas_Pago.Campo_Nombre + ",");
                Mi_SQL.Append(Cat_Formas_Pago.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Formas_Pago.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Forma_Pago_ID + "',");
                Mi_SQL.Append("'" + P_Forma_Pago.P_Nombre + "',");
                Mi_SQL.Append("'" + P_Forma_Pago.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Forma_Pago.P_Fecha_Creo) + ")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch(Exception e)
            {
                Alta = false;
                throw new Exception("Alta de Forma de Pago : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }

            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Forma_Pago
        ///DESCRIPCIÓN          : Modifica la información de la forma de pago en la base de datos
        ///PARÁMETROS           : P_Forma_Pago que contiene la información de la forma de pago
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Forma_Pago(Cls_Cat_Formas_Pago_Negocio P_Forma_Pago) 
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try 
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("UPDATE " + Cat_Formas_Pago.Tabla_Cat_Formas_Pago + " SET ");
                Mi_SQL.Append(Cat_Formas_Pago.Campo_Nombre + " = '" + P_Forma_Pago.P_Nombre + "',");
                Mi_SQL.Append(Cat_Formas_Pago.Campo_Usuario_Modifico + " = '" + P_Forma_Pago.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Formas_Pago.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Forma_Pago.P_Fecha_Modifico) + " ");
                Mi_SQL.Append("WHERE " + Cat_Formas_Pago.Campo_Forma_ID + " = '" + P_Forma_Pago.P_Forma_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch(Exception e)
            {
                throw new Exception("Modificar Forma de Pago : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Formas_Pago
        ///DESCRIPCIÓN          : Consulta la información de las formas de pago en la base de datos
        ///PARÁMETROS           : P_Forma_Pago que contiene la información de la forma de pago
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Formas_Pago(Cls_Cat_Formas_Pago_Negocio P_Forma_Pago) 
        {
            StringBuilder Mi_SQL = new StringBuilder();

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
                Mi_SQL.Append("SELECT * FROM " + Cat_Formas_Pago.Tabla_Cat_Formas_Pago + " WHERE 1 = 1 ");
                if (!String.IsNullOrEmpty(P_Forma_Pago.P_Forma_ID)) 
                {
                    Mi_SQL.Append("AND " + Cat_Formas_Pago.Campo_Forma_ID + " = '" + P_Forma_Pago.P_Forma_ID + "'");
                }
                if (!String.IsNullOrEmpty(P_Forma_Pago.P_Nombre))
                {
                    Mi_SQL.Append("AND " + Cat_Formas_Pago.Campo_Nombre + " LIKE '" + P_Forma_Pago.P_Nombre + "%'");
                }

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch(Exception e)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Consultar Formas de Pago : " + e.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        public static void Eliminar_Forma_Pago(Cls_Cat_Formas_Pago_Negocio P_Forma_Pago)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            Mi_SQL.Append("DELETE FROM " + Cat_Formas_Pago.Tabla_Cat_Formas_Pago);
            Mi_SQL.Append(" WHERE " + Cat_Formas_Pago.Campo_Forma_ID + " = " + P_Forma_Pago.P_Forma_ID);
            Conexion.HelperGenerico.Conexion_y_Apertura();
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}