using System;
using System.Text;
using Erp.Constantes;
using Erp.Helper;
using System.Data;
using Catalogos.Turnos.Negocio;
using Erp.Metodos_Generales;
using Erp.Ayudante_Sintaxis;

namespace Catalogos.Turnos.Datos
{
    public class Cls_Cat_Turnos_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Turnos
        ///DESCRIPCIÓN          : Registra una nuevo turno en la base de datos
        ///PARÁMETROS           : P_Turno que contiene la información de el turno a registrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Turnos(Cls_Cat_Turnos_Negocio P_Turno)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Alta = true;
            String Turno_ID;

            try
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Turno_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Turnos.Tabla_Cat_Turnos, Cat_Turnos.Campo_Turno_ID, "", 5);
                Mi_SQL.Append("INSERT INTO " + Cat_Turnos.Tabla_Cat_Turnos + "(");
                Mi_SQL.Append(Cat_Turnos.Campo_Turno_ID + ",");
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Nombre))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Nombre + ",");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Comentarios))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Comentarios + ",");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Hora_Inicio))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Hora_Inicio + ",");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Hora_Cierre))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Hora_Cierre + ",");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Estatus)) 
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Estatus + ",");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Fijo)) 
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Fijo + ",");
                }

                Mi_SQL.Append(Cat_Turnos.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Turnos.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Turno_ID + "',");
                Mi_SQL.Append("'" + P_Turno.P_Nombre + "',");
                Mi_SQL.Append("'" + P_Turno.P_Comentarios + "',");
                Mi_SQL.Append("'" + P_Turno.P_Hora_Inicio + "',");
                Mi_SQL.Append("'" + P_Turno.P_Hora_Cierre + "',");
                Mi_SQL.Append("'" + P_Turno.P_Estatus + "',");
                Mi_SQL.Append("'" + P_Turno.P_Fijo + "',");
                Mi_SQL.Append("'" + P_Turno.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Turno.P_Fecha_Creo) + ")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch(Exception e)
            {
                Alta = false;
                throw new Exception("Alta de Turnos : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }

            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Turno
        ///DESCRIPCIÓN          : Modifica un turno en la base de datos
        ///PARÁMETROS           : P_Turno que contiene la información de el turno a modificar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static void Modificar_Turno(Cls_Cat_Turnos_Negocio P_Turno)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("UPDATE " + Cat_Turnos.Tabla_Cat_Turnos + " SET ");
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Nombre))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Nombre + " = '" + P_Turno.P_Nombre + "', ");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Comentarios))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Comentarios + " = '" + P_Turno.P_Comentarios + "', ");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Hora_Inicio))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Hora_Inicio + " = '" + P_Turno.P_Hora_Inicio + "', ");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Hora_Cierre))
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Hora_Cierre + " = '" + P_Turno.P_Hora_Cierre + "', ");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Estatus)) 
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Estatus + " = '" + P_Turno.P_Estatus + "', ");
                }
                if (!String.IsNullOrEmpty(Cat_Turnos.Campo_Fijo)) 
                {
                    Mi_SQL.Append(Cat_Turnos.Campo_Fijo + " = '" + P_Turno.P_Fijo + "', ");
                }

                Mi_SQL.Append(Cat_Turnos.Campo_Usuario_Modifico + " = '" + P_Turno.P_Usuario_Modifico + "', ");
                Mi_SQL.Append(Cat_Turnos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Turno.P_Fecha_Modifico) + " ");
                Mi_SQL.Append(" WHERE " + Cat_Turnos.Campo_Turno_ID + " = '" + P_Turno.P_Turno_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch(Exception e)
            {
                throw new Exception("Modificar Caja : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Turnos
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para obtener y regresar un datatable con los turnos
        ///PARÁMETROS:
        /// 		1. Datos_Turno: instancia de la clase de negocio de turnos con los criterios para la búsqueda
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static DataTable Consultar_Turnos(Cls_Cat_Turnos_Negocio Datos_Turno)
        {
            string Mi_SQL;
            Conexion.Iniciar_Helper();
            DataTable Dt_Resultado = new DataTable();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = "SELECT * FROM " + Cat_Turnos.Tabla_Cat_Turnos + " WHERE 1 = 1";
            // agregar filtros opcionales
            if (!String.IsNullOrEmpty(Datos_Turno.P_Turno_ID))
            {
                Mi_SQL += " AND " + Cat_Turnos.Campo_Turno_ID + " = '" + Datos_Turno.P_Turno_ID + "'";
            }
            if (!String.IsNullOrEmpty(Datos_Turno.P_Nombre)) 
            {
                Mi_SQL += " AND " + Cat_Turnos.Campo_Nombre + " LIKE '" + Datos_Turno.P_Nombre + "%'";
            }
            if (!String.IsNullOrEmpty(Datos_Turno.P_Estatus))
            {
                Mi_SQL += " AND " + Cat_Turnos.Campo_Estatus + " = '" + Datos_Turno.P_Estatus + "'";
            }

            Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL);
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Resultado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Turno
        ///DESCRIPCIÓN          : Elimina un turno en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static void Eliminar_Turno(Cls_Cat_Turnos_Negocio P_Turno)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            Mi_SQL.Append("DELETE FROM " + Cat_Turnos.Tabla_Cat_Turnos);
            Mi_SQL.Append(" WHERE " + Cat_Turnos.Campo_Turno_ID + " = " + P_Turno.P_Turno_ID);
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}