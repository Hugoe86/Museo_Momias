using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Catalogos.Dias.Feriados.Negocio;
using Erp.Metodos_Generales;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;

namespace Catalogos.Dias.Feriados.Datos
{
    class Cls_Cat_Dias_Feriados_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Dia
        ///DESCRIPCIÓN          : Llama el método de Alta_Dia de la clase de datos
        ///PARÁMETROS           : P_Dia, contiene la información del día feriado a registrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Dia(Cls_Cat_Dias_Feriados_Negocio P_Dia)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Alta = false;
            String Dia_ID;

            try
            {
                Dia_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados, Cat_Dias_Feriados.Campo_Dia_ID, "", 5);
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("INSERT INTO " + Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados + "(");
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Dia_ID + ",");
                if (!String.IsNullOrEmpty(P_Dia.P_Descripcion))
                {
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Descripcion + ",");    
                }
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha + ",");
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha_Fin + ",");
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Anios + ",");
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Estatus + ",");
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Dia_ID + "',");
                if (!String.IsNullOrEmpty(P_Dia.P_Descripcion))
                {
                    Mi_SQL.Append("'" + P_Dia.P_Descripcion + "',");
                }
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Dia.P_Fecha) + ",");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Dia.P_Fecha_Fin) + ",");
                Mi_SQL.Append("'" + P_Dia.P_Anios + "',");
                Mi_SQL.Append("'" + P_Dia.P_Estatus + "',");
                Mi_SQL.Append("'" + P_Dia.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Dia.P_Fecha_Creo) + ")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Alta = true;
            }
            catch (Exception e)
            {
                throw new Exception("Alta Día Feriado : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }

            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Dia
        ///DESCRIPCIÓN          : Modifica la información de un día en la base de datos
        ///PARÁMETROS           : P_Dia, contiene la información del día feriado a registrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static void Modificar_Dia(Cls_Cat_Dias_Feriados_Negocio P_Dia)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            
            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("UPDATE " + Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados + " SET ");
                if (!String.IsNullOrEmpty(P_Dia.P_Descripcion))
                {
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Descripcion + " = '" + P_Dia.P_Descripcion + "',");
                }
                if (!String.IsNullOrEmpty(P_Dia.P_Fecha.ToString()))
                {
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Dia.P_Fecha) + ",");
                }
                if (!String.IsNullOrEmpty(P_Dia.P_Fecha_Fin.ToString()))
                {
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha_Fin + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Dia.P_Fecha_Fin) + ",");
                }
                if (!String.IsNullOrEmpty(P_Dia.P_Anios))
                {
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Anios + " = '" + P_Dia.P_Anios + "',");
                }
                if (!String.IsNullOrEmpty(P_Dia.P_Estatus))
                {
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Estatus + " = '" + P_Dia.P_Estatus + "',");
                }
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Usuario_Modifico + " = '" + P_Dia.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Dia.P_Fecha_Modifico) + " ");
                Mi_SQL.Append("WHERE " + Cat_Dias_Feriados.Campo_Dia_ID + " = '" + P_Dia.P_Dia_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Día : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Dia
        ///DESCRIPCIÓN          : Elimina el día feriado seleccionado
        ///PARÁMETROS           : P_Dia, contiene la información del día feriado a registrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Dia(Cls_Cat_Dias_Feriados_Negocio P_Dia)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            Mi_SQL.Append("DELETE FROM " + Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados + " ");
            Mi_SQL.Append("WHERE " + Cat_Dias_Feriados.Campo_Dia_ID + " = '" + P_Dia.P_Dia_ID + "'");

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Dias
        ///DESCRIPCIÓN          : Consulta los dias que estén registrados en la base de datos
        ///PARÁMETROS           : P_Dia, contiene los filtros de los días a consultar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Dias(Cls_Cat_Dias_Feriados_Negocio P_Dia)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("SELECT * FROM " + Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados + " WHERE 1 = 1 ");

                if (!String.IsNullOrEmpty(P_Dia.P_Dia_ID))
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Dia_ID + " = '" + P_Dia.P_Dia_ID + "'");
                }
                
                if (!String.IsNullOrEmpty(P_Dia.P_Descripcion))
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Descripcion + " LIKE '" + P_Dia.P_Descripcion + "%'");
                }
                
                if (!String.IsNullOrEmpty(P_Dia.P_Estatus))
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Estatus + " = '" + P_Dia.P_Estatus + "'");
                }

                if (P_Dia.P_Fecha != DateTime.MinValue && P_Dia.P_Fecha_Fin != DateTime.MinValue)
                {
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Fecha + " = CAST(" + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Dia.P_Fecha) + " As Date)");
                    Mi_SQL.Append(" AND " + Cat_Dias_Feriados.Campo_Fecha_Fin + " = CAST(" + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Dia.P_Fecha_Fin) + " As Date)");
                    /*Mi_SQL.Append(" AND ( (" + Cat_Dias_Feriados.Campo_Anios + " = 'TODOS LOS AÑOS' AND SUBSTRING (CONVERT (VARCHAR (10), ");
                    Mi_SQL.Append(Cat_Dias_Feriados.Campo_Fecha + ", 101),1,5) = '" + P_Dia.P_Fecha.ToString("MM/dd") + "')");
                    Mi_SQL.Append(" OR cast(" + Cat_Dias_Feriados.Campo_Fecha + " As Date) = cast("
                        + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Dia.P_Fecha) + " As Date))");*/
                }

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Dias : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
    }
}
