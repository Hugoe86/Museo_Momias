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
    class Cls_Cat_Descuentos_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Descuentos
        ///DESCRIPCIÓN          : Registra un nuevo descuento en la base de datos
        ///PARÁMETROS           : P_Descuento que contiene la información del nuevo descuento a registrar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static Boolean Alta_Descuentos(Cls_Cat_Descuentos_Negocio P_Descuentos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Alta = false;
            String Descuentos_ID;

            try
            {
                Descuentos_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Descuentos.Tabla_Cat_Descuentos, Cat_Descuentos.Campo_Descuento_ID, "", 5);
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("INSERT INTO " + Cat_Descuentos.Tabla_Cat_Descuentos + "(");
                Mi_SQL.Append(Cat_Descuentos.Campo_Descuento_ID + ",");
                Mi_SQL.Append(Cat_Descuentos.Campo_Descripcion + ",");
                Mi_SQL.Append(Cat_Descuentos.Campo_Vigencia_Desde + ",");
                Mi_SQL.Append(Cat_Descuentos.Campo_Vigencia_Hasta + ",");
                if (!String.IsNullOrEmpty(P_Descuentos.P_Porcentaje_Descuento))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Porcentaje_Descuento + ",");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Monto_Descuento))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Monto_Descuento + ",");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Motivo))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Motivo + ",");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Leyenda))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Leyenda + ",");
                }
                Mi_SQL.Append(Cat_Descuentos.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Descuentos.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Descuentos_ID + "',");
                Mi_SQL.Append("'" + P_Descuentos.P_Descripcion + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Descuentos.P_Vigencia_Desde) + ",");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Descuentos.P_Vigencia_Hasta) + ",");
                if (!String.IsNullOrEmpty(P_Descuentos.P_Porcentaje_Descuento))
                {
                    Mi_SQL.Append("'" + P_Descuentos.P_Porcentaje_Descuento + "',");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Monto_Descuento))
                {
                    Mi_SQL.Append("'" + P_Descuentos.P_Monto_Descuento + "',");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Motivo))
                {
                    Mi_SQL.Append("'" + P_Descuentos.P_Motivo + "',");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Leyenda))
                {
                    Mi_SQL.Append("'" + P_Descuentos.P_Leyenda + "',");
                }
                Mi_SQL.Append("'" + P_Descuentos.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Descuentos.P_Fecha_Creo) + ")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Alta = true;
            }
            catch (Exception e)
            {
                throw new Exception("Alta Descuentos : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }

            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Descuentos
        ///DESCRIPCIÓN          : Modifica la información de un descuento en la base de datos
        ///PARÁMETROS           : P_Descuentos que contiene la información de un descuento a modificar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Modificar_Descuentos(Cls_Cat_Descuentos_Negocio P_Descuentos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            
            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("UPDATE " + Cat_Descuentos.Tabla_Cat_Descuentos + " SET ");
                if (!String.IsNullOrEmpty(P_Descuentos.P_Descripcion))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Descripcion + " = '" + P_Descuentos.P_Descripcion + "',");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Vigencia_Desde.ToString()))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Vigencia_Desde + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Descuentos.P_Vigencia_Desde) + ",");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Vigencia_Hasta.ToString()))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Vigencia_Hasta + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Descuentos.P_Vigencia_Hasta) + ",");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Porcentaje_Descuento))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Porcentaje_Descuento + " = '" + P_Descuentos.P_Porcentaje_Descuento + "',");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Monto_Descuento))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Monto_Descuento + " = '" + P_Descuentos.P_Monto_Descuento + "',");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Motivo))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Motivo + " = '" + P_Descuentos.P_Motivo + "',");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Leyenda))
                {
                    Mi_SQL.Append(Cat_Descuentos.Campo_Leyenda + " = '" + P_Descuentos.P_Leyenda + "',");
                }
                Mi_SQL.Append(Cat_Descuentos.Campo_Usuario_Modifico + " = '" + P_Descuentos.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Descuentos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Descuentos.P_Fecha_Modifico) + " ");
                Mi_SQL.Append("WHERE " + Cat_Descuentos.Campo_Descuento_ID + " = '" + P_Descuentos.P_Descuento_ID + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Descuentos : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Descuentos
        ///DESCRIPCIÓN          : Consulta informacion de los descuentos de la base de datos
        ///PARÁMETROS           : P_Descuentos que contiene los filtros de los descuentos a buscar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static System.Data.DataTable Consultar_Descuentos(Cls_Cat_Descuentos_Negocio P_Descuentos)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM " + Cat_Descuentos.Tabla_Cat_Descuentos + " WHERE 1 = 1 ");
                if (!String.IsNullOrEmpty(P_Descuentos.P_Descuento_ID))
                {
                    Mi_SQL.Append("AND " + Cat_Descuentos.Campo_Descuento_ID + " = '" + P_Descuentos.P_Descuento_ID + "'");
                }
                if (!String.IsNullOrEmpty(P_Descuentos.P_Descripcion))
                {
                    Mi_SQL.Append("AND " + Cat_Descuentos.Campo_Descripcion + " LIKE '" + P_Descuentos.P_Descripcion + "%'");
                }

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Descuentos : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Descuentos
        ///DESCRIPCIÓN          : Elimina la informacion de un descuento de la base de datos
        ///PARÁMETROS           : P_Descuentos que contiene el id del descuento a eliminar
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

        public static void Eliminar_Descuentos(Cls_Cat_Descuentos_Negocio P_Descuentos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL.Append("DELETE FROM " + Cat_Descuentos.Tabla_Cat_Descuentos);
            Mi_SQL.Append(" WHERE " + Cat_Descuentos.Campo_Descuento_ID + " = '" + P_Descuentos.P_Descuento_ID + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

    }
}
