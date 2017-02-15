using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Operaciones.Cajas.Negocio;
using Erp.Ayudante_Sintaxis;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Helper;

namespace Operaciones.Cajas.Datos
{
    class Cls_Ope_Cajas_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Caja
        ///DESCRIPCIÓN          : Inicia la apertura de una operación de caja
        ///PARÁMETROS           : P_Caja, conttiene los datos de la operación a abrir
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static Boolean Alta_Caja(Cls_Ope_Cajas_Negocio P_Caja) 
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Alta = false;
            String No_Caja;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Conexion.HelperGenerico.Iniciar_Transaccion();

                No_Caja = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Cajas.Tabla_Ope_Cajas, Ope_Cajas.Campo_No_Caja, "", 10);
                Mi_SQL.Append("INSERT INTO " + Ope_Cajas.Tabla_Ope_Cajas + "(");
                Mi_SQL.Append(Ope_Cajas.Campo_No_Caja + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_No_Turno + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_Usuario_ID + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_Caja_ID + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_Monto_Inicial + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_Fecha_Hora_Inicio + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_Estatus);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + No_Caja + "',");
                Mi_SQL.Append("'" + P_Caja.P_No_Turno + "',");
                Mi_SQL.Append("'" + P_Caja.P_Usuario_ID + "',");
                Mi_SQL.Append("'" + P_Caja.P_Caja_ID + "',");
                Mi_SQL.Append("" + P_Caja.P_Monto_Inicial + ",");
                Mi_SQL.Append("" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora( P_Caja.P_Fecha_Hora_Inicio) + ",");
                Mi_SQL.Append("'" + P_Caja.P_Estatus + "')");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Mi_SQL.Clear();

                Mi_SQL.Append("update " + Apl_Usuarios.Tabla_Apl_Usuarios + " set ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Caja_ID + "='" + P_Caja.P_Caja_ID + "'");
                Mi_SQL.Append(" where " + Apl_Usuarios.Campo_Usuario_Id + "='" + P_Caja.P_Usuario_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Conexion.HelperGenerico.Terminar_Transaccion();
                Alta = true;
            }
            catch (Exception e)
            {
                throw new Exception("Alta de Operacion de Cajas : " + e.Message);
            }

            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja
        ///DESCRIPCIÓN          : Modifica la operación de caja abierta para cerrarla
        ///PARÁMETROS           : P_Caja, conttiene los datos de la operación a cerrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : Roberto González Oseguera
        ///FECHA_MODIFICO       : 05-nov-2013
        ///CAUSA_MODIFICACIÓN   : Se actualizó para considerar transacciones activas
        ///*******************************************************************************
        public static Boolean Modificar_Caja(Cls_Ope_Cajas_Negocio P_Caja)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Modificar = false;
            Boolean Transaccion_Activa = false;

            //Abrir la conexión
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
                Mi_SQL.Append("UPDATE " + Ope_Cajas.Tabla_Ope_Cajas + " SET ");
                Mi_SQL.Append(Ope_Cajas.Campo_Fecha_Hora_Cierre + "=" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Caja.P_Fecha_Hora_Cierre) + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_Estatus + "='" + P_Caja.P_Estatus + "' ");
                Mi_SQL.Append("WHERE " + Ope_Cajas.Campo_No_Caja + "='" + P_Caja.P_No_Caja + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Mi_SQL.Clear();

                Mi_SQL.Append("update " + Apl_Usuarios.Tabla_Apl_Usuarios + " set ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Caja_ID + "=''");
                Mi_SQL.Append(" where " + Apl_Usuarios.Campo_Usuario_Id + "='" + P_Caja.P_Usuario_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Modificar = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception e)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Cierre de Caja : " + e.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }

            return Modificar;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja_Usando_Transaccion
        ///DESCRIPCIÓN          : Modifica la operación de caja abierta para cerrarla
        ///PARÁMETROS           : P_Caja, conttiene los datos de la operación a cerrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : Roberto González Oseguera
        ///FECHA_MODIFICO       : 05-nov-2013
        ///CAUSA_MODIFICACIÓN   : Se actualizó para considerar transacciones activas
        ///*******************************************************************************
        public static Boolean Modificar_Caja_Usando_Transaccion(Cls_Ope_Cajas_Negocio P_Caja)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Modificar = false;
            Boolean Transaccion_Activa = false;

            //Abrir la conexión
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
                Mi_SQL.Append("UPDATE " + Ope_Cajas.Tabla_Ope_Cajas + " SET ");
                Mi_SQL.Append(Ope_Cajas.Campo_Fecha_Hora_Cierre + "=" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Caja.P_Fecha_Hora_Cierre) + ",");
                Mi_SQL.Append(Ope_Cajas.Campo_Estatus + "='" + P_Caja.P_Estatus + "' ");
                Mi_SQL.Append("WHERE " + Ope_Cajas.Campo_No_Caja + "='" + P_Caja.P_No_Caja + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Mi_SQL.Clear();

                Mi_SQL.Append("update " + Apl_Usuarios.Tabla_Apl_Usuarios + " set ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Caja_ID + "=''");
                Mi_SQL.Append(" where " + Apl_Usuarios.Campo_Usuario_Id + "='" + P_Caja.P_Usuario_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Modificar = true;

              
            }
            catch (Exception e)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Cierre de Caja : " + e.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }

            return Modificar;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Cajas
        ///DESCRIPCIÓN          : Consulta las operaciones de caja
        ///PARÁMETROS           : P_Caja, conttiene la información de las operaciones de caja a consultar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Cajas(Cls_Ope_Cajas_Negocio P_Caja) 
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM Ope_Cajas WHERE 1 = 1");
                if (!String.IsNullOrEmpty(P_Caja.P_No_Caja))
                {
                    Mi_SQL.Append(" AND " + Ope_Cajas.Campo_No_Caja + " = '" + P_Caja.P_No_Caja + "'");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_No_Turno))
                {
                    Mi_SQL.Append(" AND " + Ope_Cajas.Campo_No_Turno + " = '" + P_Caja.P_No_Turno + "'");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Estatus))
                {
                    Mi_SQL.Append(" AND " + Ope_Cajas.Campo_Estatus + " = '" + P_Caja.P_Estatus + "'");
                }
                if (!String.IsNullOrEmpty(P_Caja.P_Caja_ID))
                {
                    Mi_SQL.Append(" AND " + Ope_Cajas.Campo_Caja_ID + " = '" + P_Caja.P_Caja_ID + "'");
                }

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consulta de Cajas : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Solicitudes_Pendientes
        ///DESCRIPCIÓN          : Consulta las solicitudes pendientes por facturar
        ///PARÁMETROS           : P_Caja, conttiene la información de las operaciones de caja a consultar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Abril 2015
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Solicitudes_Pendientes(Cls_Ope_Cajas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("Select distinct (" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta + ")");
                Mi_SQL.Append(" From " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles);

                if (!String.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    //ope_pagos on Ope_Ventas_Detalles.No_Venta = ope_pagos.No_Venta
                    Mi_SQL.Append(" left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " on " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Venta + " = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta);
                }

                Mi_SQL.Append(" where " +Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Estatus_Solicitud + "='S'");

                if (!String.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(" and " + Ope_Pagos.Campo_No_Caja + "='" +Datos.P_Caja_ID + "'");
                }

                if (!String.IsNullOrEmpty(Datos.P_Fecha_Creo))
                {
                    Mi_SQL.Append(" and " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo );
                    Mi_SQL.Append(" between " + "'" + Datos.P_Fecha_Creo + " 00:00:00'" + " and " + "'" + Datos.P_Fecha_Creo + " 23:59:59'");
                }

                Mi_SQL.Append(" order by " +Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles +"." + Ope_Ventas_Detalles.Campo_No_Venta);

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consulta de Cajas : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
    }
}
