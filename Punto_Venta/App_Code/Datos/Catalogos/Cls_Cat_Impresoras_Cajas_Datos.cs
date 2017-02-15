using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;
using Erp.Helper;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;

namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Impresoras_Cajas_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Impresoras_Cajas
        ///DESCRIPCIÓN          : Inserta las Impresoras de las cajas del sistema.
        ///PARAMETROS           : 1. P_Impresoras_Cajas Contiene el registro que sera insertado.
        ///CREO                 : Luis Eugenio Razo mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Impresoras_Cajas(Cls_Cat_Impresoras_Cajas_Negocio P_Impresoras_Cajas)  
        {
            StringBuilder Mi_SQL;
            Boolean Transaccion_Activa = false;
            //String Parametro_Id = "";
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
                //Parametro_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Impresoras_Cajas.Tabla_Cat_Impresoras_Cajas, Cat_Impresoras_Cajas.Campo_Caja_ID, "", 5);

                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("INSERT INTO " + Cat_Impresoras_Cajas.Tabla_Cat_Impresoras_Cajas);
                Mi_SQL.Append(" (" + Cat_Impresoras_Cajas.Campo_Caja_ID);
                Mi_SQL.Append(", " + Cat_Impresoras_Cajas.Campo_Impresora_Pago);
                Mi_SQL.Append(", " + Cat_Impresoras_Cajas.Campo_Impresora_Accesos);
                Mi_SQL.Append(", " + Cat_Impresoras_Cajas.Campo_Impresora_Servicios);
                Mi_SQL.Append(", " + Cat_Impresoras_Cajas.Campo_Usuario_Creo);
                Mi_SQL.Append(", " + Cat_Impresoras_Cajas.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES ");
                Mi_SQL.Append("( '" + P_Impresoras_Cajas.P_Caja_ID);
                Mi_SQL.Append("','" + P_Impresoras_Cajas.P_Impresora_Pago);
                Mi_SQL.Append("','" + P_Impresoras_Cajas.P_Impresora_Accesos);
                Mi_SQL.Append("','" + P_Impresoras_Cajas.P_Impresora_Servicios);
                Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);
                Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Imprespras_Cajas: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Impresoras_Cajas
        ///DESCRIPCIÓN          : Modifica el registro de las impresoras de las cajas del sistema
        ///PARAMETROS           : 1. P_Impresoras_Cajas. Contiene el registro que sera modificado.
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Impresoras_Cajas (Cls_Cat_Impresoras_Cajas_Negocio P_Impresoras_Cajas)
        {
            StringBuilder Mi_SQL;
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

                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("UPDATE " + Cat_Impresoras_Cajas.Tabla_Cat_Impresoras_Cajas + " SET ");

                if (!String.IsNullOrEmpty(P_Impresoras_Cajas.P_Impresora_Pago))
                    Mi_SQL.Append(Cat_Impresoras_Cajas.Campo_Impresora_Pago + " = '" + P_Impresoras_Cajas.P_Impresora_Pago + "', ");
                if (!String.IsNullOrEmpty(P_Impresoras_Cajas.P_Impresora_Accesos))
                    Mi_SQL.Append(Cat_Impresoras_Cajas.Campo_Impresora_Accesos + " = '" + P_Impresoras_Cajas.P_Impresora_Accesos + "', ");
                if (!String.IsNullOrEmpty(P_Impresoras_Cajas.P_Impresora_Servicios))
                    Mi_SQL.Append(Cat_Impresoras_Cajas.Campo_Impresora_Servicios + " = '" + P_Impresoras_Cajas.P_Impresora_Servicios + "', ");
                Mi_SQL.Append(Cat_Impresoras_Cajas.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_SQL.Append(Cat_Impresoras_Cajas.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" WHERE " + Cat_Impresoras_Cajas.Campo_Caja_ID + " = '" + P_Impresoras_Cajas.P_Caja_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Impresoras_Cajas: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Impresoras_Cajas
        ///DESCRIPCIÓN          : Elimina el registro de las impresoras de las cajas
        ///PARAMETROS           : 1. P_Impresoras_Cajas. Contiene el registro que sera eliminado.
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Impresoras_Cajas(Cls_Cat_Impresoras_Cajas_Negocio P_Impresoras_Cajas)
        {
            StringBuilder Mi_SQL;
            Boolean Transaccion_Activa = false;

            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;
            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();
                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("DELETE FROM " + Cat_Impresoras_Cajas.Tabla_Cat_Impresoras_Cajas);
                Mi_SQL.Append(" WHERE " + Cat_Impresoras_Cajas.Campo_Caja_ID + " = '" + P_Impresoras_Cajas.P_Caja_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Impresoras_cajas: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Impresoras_Cajas
        ///DESCRIPCIÓN          : Regresa un DataTable con las Impresoras de las cajas del sistema.
        ///PARAMETROS           : 1. P_Impresoras_Cajas Contiene los criterios para la busqueda.
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Impresoras_Cajas(Cls_Cat_Impresoras_Cajas_Negocio P_Impresoras_Cajas)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            try
            {
                Mi_SQL.Append("SELECT * FROM " + Cat_Impresoras_Cajas.Tabla_Cat_Impresoras_Cajas);
                if (!String.IsNullOrEmpty(P_Impresoras_Cajas.P_Caja_ID))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(Cat_Impresoras_Cajas.Campo_Caja_ID + " = '" + P_Impresoras_Cajas.P_Caja_ID + "'");
                }

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                return Dt_Consulta;
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Producto : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Impresoras_Cajas
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para obtener y regresar un datatable con los datos de las impresoras,
        ///             regresa un datatable con los resultados de la consulta
        ///PARÁMETROS:
        ///CREO: Luis Eugenio Razo Mendiola
        ///FECHA_CREO: 25/Oct/2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static DataTable Consultar_Impresoras_Cajas()
        {
            string Mi_SQL;
            DataTable Dt_Resultado;
            Boolean Transaccion_Activa = false;

            // validar si hay transacción activa
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

                Mi_SQL = "SELECT * FROM " + Cat_Impresoras_Cajas.Tabla_Cat_Impresoras_Cajas;

                Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL);

                // si no había una transacción activa antes de llamar al método, terminar la transacción
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Consultar Impresoras_Cajas: " + E.Message);
            }
            finally
            {
                // si no había una transacción activa antes de iniciar el método actual, terminar la transacción
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultado;
        }
    }
}
