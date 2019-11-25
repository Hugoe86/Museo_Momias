using System;
using System.Data;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp_Ope_Accesos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp_Apl_Parametros.Negocio;

namespace Erp_Ope_Accesos.Datos
{
    public class Cls_Ope_Accesos_Datos
    {
        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Acceso
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Accesos: Instancia de Cls_Ope_Accesos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static String Alta_Acceso(Cls_Ope_Accesos_Negocio Accesos)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
            String Str_Informacion_Acceso = "";
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

                // si no se especifica fecha inicio vigencia, asignar fecha actual
                if (Accesos.P_Vigencia_Inicio == DateTime.MinValue)
                {
                    Accesos.P_Vigencia_Inicio = DateTime.Today;
                }
                // si no se especifica fecha final de vigencia, asignar fecha actual más parámetro
                if (Accesos.P_Vigencia_Fin == DateTime.MinValue)
                {
                    var Obj_Paramentros = new Cls_Apl_Parametros_Negocio();
                    Obj_Paramentros = Obj_Paramentros.Obtener_Parametros();
                    Accesos.P_Vigencia_Fin = Accesos.P_Vigencia_Inicio.AddDays(Obj_Paramentros.P_Dias_Vigencia);
                }
                
                //  se agrega la fecha de la valides del folio
                Str_Informacion_Acceso = Accesos.P_Vigencia_Fin.ToString("dd/MMM/yyyy") + ",";

                //Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Accesos.Tabla_Ope_Accesos, Ope_Accesos.Campo_No_Acceso, "", 10);

                String Where = Ope_Accesos.Campo_No_Acceso + " like ('" + MDI_Frm_Apl_Principal.Serie_Caja + "%')";

                Consecutivo = "" + Cls_Metodos_Generales.Obtener_ID_Consecutivo_Numerico_Accesos(Ope_Accesos.Tabla_Ope_Accesos, Ope_Accesos.Campo_No_Acceso, Where);
                String Auxiliar = "";

                Auxiliar = MDI_Frm_Apl_Principal.Serie_Caja;
                Auxiliar += Convert.ToInt64(Consecutivo).ToString("000000000");
                Consecutivo = Auxiliar;

                //if (Consecutivo == "0" || Consecutivo == "1")
                //{
                //    Consecutivo = MDI_Frm_Apl_Principal.Serie_Caja;

                //    for (int Cont_For = Consecutivo.Length; Cont_For < 10; Cont_For++)
                //    {
                //        Consecutivo += "0";
                //    }
                //}

                //  se agrega el folio
                Str_Informacion_Acceso += Consecutivo;
                //  se agrega la caja
                Str_Informacion_Acceso += "," + MDI_Frm_Apl_Principal.Caja_ID;

                Mi_SQL += "INSERT INTO " + Ope_Accesos.Tabla_Ope_Accesos + " (";
                Mi_SQL += Ope_Accesos.Campo_No_Acceso;
                Mi_SQL += ", " + Ope_Accesos.Campo_No_Venta;
                Mi_SQL += ", " + Ope_Accesos.Campo_Producto_ID;
                Mi_SQL += ", " + Ope_Accesos.Campo_Terminal_ID;
                //Mi_SQL += ", " + Ope_Accesos.Campo_Numero_Serie;
                Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Inicio;
                Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Fin;
                Mi_SQL += ", " + Ope_Accesos.Campo_Estatus;
                Mi_SQL += ", " + Ope_Accesos.Campo_Tipo;
                Mi_SQL += ", " + Ope_Accesos.Campo_Usuario_Creo;
                Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Creo;
                Mi_SQL += ", " + Ope_Accesos.Campo_Serie;
                //Mi_SQL += ", " + Ope_Accesos.Campo_Byts_Numero_Serie;
                Mi_SQL += ")";
                Mi_SQL += " VALUES (";

                Mi_SQL += "'" + Consecutivo + "', ";

                if (Accesos.P_No_Venta != "" && Accesos.P_No_Venta != null)
                {
                    Mi_SQL += "'" + Accesos.P_No_Venta + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Accesos.P_Producto_ID != "" && Accesos.P_Producto_ID != null)
                {
                    Mi_SQL += "'" + Accesos.P_Producto_ID + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Accesos.P_Terminal_ID != "" && Accesos.P_Terminal_ID != null)
                {
                    Mi_SQL += "'" + Accesos.P_Terminal_ID + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }


                //if (Accesos.P_Numero_Serie != "" && Accesos.P_Numero_Serie != null)
                //{
                //    Mi_SQL += "'" + Accesos.P_Numero_Serie + "', ";
                //}
                //else
                //{
                //    Mi_SQL += "NULL, ";
                //}

               
                Mi_SQL += Cls_Ayudante_Sintaxis.Insertar_Fecha(Accesos.P_Vigencia_Inicio) + ", ";
                Mi_SQL += Cls_Ayudante_Sintaxis.Insertar_Fecha(Accesos.P_Vigencia_Fin) + ", ";

                if (Accesos.P_Estatus != "" && Accesos.P_Estatus != null)
                {
                    Mi_SQL += "'" + Accesos.P_Estatus + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Accesos.P_Tipo != "" && Accesos.P_Tipo != null)
                {
                    Mi_SQL += "'" + Accesos.P_Tipo + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                Mi_SQL += "'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', "
                    + Cls_Ayudante_Sintaxis.Fecha();


                //if (Accesos.P_Byts_Numero_Serie != "" && Accesos.P_Byts_Numero_Serie != null)
                //{
                //    Mi_SQL += ", '" + Accesos.P_Byts_Numero_Serie + "' ";
                //}
                //else
                //{
                //    Mi_SQL += ", NULL ";
                //}


                Mi_SQL += ", '" + MDI_Frm_Apl_Principal.Serie_Caja + "' ";
                Mi_SQL += ")";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                // si no había una transacción activa antes de llamar al método, terminar la transacción
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Acceso: " + E.Message);
            }
            finally
            {
                // si no había una transacción activa antes de iniciar el método actual, terminar la transacción
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Str_Informacion_Acceso;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Acceso
        ///DESCRIPCIÓN          : Modifica un Registro en la base de datos.
        ///PARAMETROS           : Accesos: Instancia de Cls_Ope_Accesos_Negocio con los valores de los campos a Modificar
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Acceso(Cls_Ope_Accesos_Negocio Accesos)
        {
            String Mi_SQL = "";
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

                Mi_SQL += "UPDATE " + Ope_Accesos.Tabla_Ope_Accesos + " SET ";
                if (Accesos.P_No_Acceso != "" && Accesos.P_No_Acceso != null)
                {
                    Mi_SQL += Ope_Accesos.Campo_No_Acceso + " = '" + Accesos.P_No_Acceso + "'";
                }
                if (Accesos.P_No_Venta != "" && Accesos.P_No_Venta != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_No_Venta + " = '" + Accesos.P_No_Venta + "'";
                }
                if (Accesos.P_Producto_ID != "" && Accesos.P_Producto_ID != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Producto_ID + " = '" + Accesos.P_Producto_ID + "'";
                }
                if (Accesos.P_Terminal_ID != "" && Accesos.P_Terminal_ID != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Terminal_ID + " = '" + Accesos.P_Terminal_ID + "'";
                }
                if (Accesos.P_Numero_Serie != "" && Accesos.P_Numero_Serie != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Numero_Serie + " = '" + Accesos.P_Numero_Serie + "'";
                }
                if (Accesos.P_Vigencia_Inicio > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Inicio + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Accesos.P_Vigencia_Inicio);
                }
                if (Accesos.P_Vigencia_Fin > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Fin + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Accesos.P_Vigencia_Fin);
                }
                if (Accesos.P_Estatus != "" && Accesos.P_Estatus != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Estatus + " = '" + Accesos.P_Estatus + "'";
                }
                if (Accesos.P_Fecha_Hora_Acceso > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Acceso + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Accesos.P_Fecha_Hora_Acceso);
                }
                if (Accesos.P_Fecha_Hora_Salida > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Salida + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Accesos.P_Fecha_Hora_Salida);
                }
                if (Accesos.P_Tipo != "" && Accesos.P_Tipo != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Tipo + " = '" + Accesos.P_Tipo + "'";
                }
                Mi_SQL += ", " + Ope_Accesos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'";
                Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Modifico + " = '" + Cls_Ayudante_Sintaxis.Fecha() + "'";
                Mi_SQL += "WHERE " + Ope_Accesos.Campo_No_Acceso + " = '" + Accesos.P_No_Acceso + "'";
                //Mi_SQL += "AND " + Ope_Accesos.Campo_No_Venta + " = '" + Accesos.P_No_Venta + "'";
                //Mi_SQL += "AND " + Ope_Accesos.Campo_Producto_ID + " = '" + Accesos.P_Producto_ID + "'";
                //Mi_SQL += "AND " + Ope_Accesos.Campo_Terminal_ID + " = '" + Accesos.P_Terminal_ID + "'";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Acceso: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Actualizar_Estatus_Acceso
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para actualizar el estatus, hora_acceso y hora_salida 
        ///             de un acceso por no_acceso o numero_serie; regresa la cantidad de registros actualizados
        ///PARÁMETROS:
        /// 		1. Accesos: Instancia de Cls_Ope_Accesos_Negocio con los valores a actualizar
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 14-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static int Actualizar_Estatus_Acceso(Cls_Ope_Accesos_Negocio Accesos)
        {
            String Mi_SQL = "";
            Boolean Transaccion_Activa = false;
            int Registros_Modificados = 0;

            // validar que se haya proporcionado por lo menos el no_acceso o el numero_serie
            if (string.IsNullOrEmpty(Accesos.P_No_Acceso) && string.IsNullOrEmpty(Accesos.P_Numero_Serie))
            {
                return 0;
            }

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

                Mi_SQL += "UPDATE " + Ope_Accesos.Tabla_Ope_Accesos + " SET "
                    + Ope_Accesos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'"
                    + ", " + Ope_Accesos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha();
                if (Accesos.P_Estatus != "" && Accesos.P_Estatus != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Estatus + " = '" + Accesos.P_Estatus + "'";
                }
                if (Accesos.P_Terminal_ID != "" && Accesos.P_Terminal_ID != null)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Terminal_ID + " = '" + Accesos.P_Terminal_ID + "'";
                }
                if (Accesos.P_Fecha_Hora_Acceso > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Acceso + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Accesos.P_Fecha_Hora_Acceso);
                }
                if (Accesos.P_Fecha_Hora_Salida > DateTime.MinValue)
                {
                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Salida + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Accesos.P_Fecha_Hora_Salida);
                }
                Mi_SQL += "WHERE 1=1";
                // filtrar por no_acceso o por numero_serie
                if (!string.IsNullOrEmpty(Accesos.P_No_Acceso))
                {
                    Mi_SQL += " AND " + Ope_Accesos.Campo_No_Acceso + " = '" + Accesos.P_No_Acceso + "'";
                }
                if (!string.IsNullOrEmpty(Accesos.P_Numero_Serie))
                {
                    Mi_SQL += " AND " + Ope_Accesos.Campo_Numero_Serie + " = '" + Accesos.P_Numero_Serie + "'";
                }

                Registros_Modificados = Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Registros_Modificados = 0;
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Acceso: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }

            return Registros_Modificados;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Acceso
        ///DESCRIPCIÓN          : Elimina un Registro de la base de datos.
        ///PARAMETROS           : Accesos: Instancia de Cls_Ope_Accesos_Negocio con el valor del No. de Operación a Eliminar
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Acceso(Cls_Ope_Accesos_Negocio Accesos)
        {
            String Mi_SQL = "";
            Boolean Transaccion_Activa = false;

            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();

            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                //  se eliminar los registros de acceso con respecto al Acceso_id
                Mi_SQL += "DELETE FROM " + Ope_Accesos.Tabla_Ope_Accesos;
                Mi_SQL += " WHERE " + Ope_Accesos.Campo_No_Acceso + " = '" + Accesos.P_No_Acceso + "'";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Acceso: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Consultar_Accesos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : Accesos: Instancia de Cls_Ope_Accesos_Negocio con los valores de la Consulta a ser ejecutada
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Accesos(Cls_Ope_Accesos_Negocio Accesos)
        {
            String Mi_SQL;
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = "SELECT " + Ope_Accesos.Campo_No_Acceso;
            Mi_SQL += ", " + Ope_Accesos.Campo_No_Venta;
            Mi_SQL += ", " + Ope_Accesos.Campo_Producto_ID;
            // subconsulta nombre producto
            Mi_SQL += ", (SELECT " + Cat_Productos.Campo_Nombre + " FROM " + Cat_Productos.Tabla_Cat_Productos
                + " WHERE " + Cat_Productos.Campo_Producto_Id + "=" + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Producto_ID + ") AS NOMBRE_PRODUCTO";
            Mi_SQL += ", " + Ope_Accesos.Campo_Terminal_ID;
            Mi_SQL += ", " + Ope_Accesos.Campo_Numero_Serie;
            Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Inicio;
            Mi_SQL += ", " + Ope_Accesos.Campo_Vigencia_Fin;
            Mi_SQL += ", " + Ope_Accesos.Campo_Estatus;
            Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Acceso;
            Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Hora_Salida;
            Mi_SQL += ", " + Ope_Accesos.Campo_Tipo;
            Mi_SQL += ", " + Ope_Accesos.Campo_Usuario_Creo;
            Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Creo;
            Mi_SQL += ", " + Ope_Accesos.Campo_Usuario_Modifico;
            Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Modifico;
            Mi_SQL += " FROM " + Ope_Accesos.Tabla_Ope_Accesos;
            Mi_SQL += " WHERE ";
            if (Accesos.P_No_Acceso != "" && Accesos.P_No_Acceso != null)
            {
                Mi_SQL += Ope_Accesos.Campo_No_Acceso + " = '" + Accesos.P_No_Acceso + "' AND ";
            }
            if (!string.IsNullOrEmpty(Accesos.P_Numero_Serie))
            {
                Mi_SQL += Ope_Accesos.Campo_Numero_Serie + " = '" + Accesos.P_Numero_Serie + "' AND ";
            }
            if (!string.IsNullOrEmpty(Accesos.P_Estatus))
            {
                Mi_SQL += Ope_Accesos.Campo_Estatus + " = '" + Accesos.P_Estatus + "' AND ";
            }
            if (Accesos.P_No_Venta != "" && Accesos.P_No_Venta != null)
            {
                Mi_SQL += Ope_Accesos.Campo_No_Venta + " = '" + Accesos.P_No_Venta + "' AND ";
            }
            if (Accesos.P_Producto_ID != "" && Accesos.P_Producto_ID != null)
            {
                Mi_SQL += Ope_Accesos.Campo_Producto_ID + " = '" + Accesos.P_Producto_ID + "' AND ";
            }
            if (Accesos.P_Terminal_ID != "" && Accesos.P_Terminal_ID != null)
            {
                Mi_SQL += Ope_Accesos.Campo_Terminal_ID + " = '" + Accesos.P_Terminal_ID + "' AND ";
            }

            if (Mi_SQL.EndsWith(" WHERE "))
            {
                Mi_SQL = Mi_SQL.Substring(0, Mi_SQL.Length - 7);
            }

            if (Mi_SQL.EndsWith(" AND "))
            {
                Mi_SQL = Mi_SQL.Substring(0, Mi_SQL.Length - 5);
            }

            Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Consulta;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Existe_Serie
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para buscar un acceso por número de serie, regresa 
        ///             true en caso de encontrarlo
        ///PARÁMETROS:
        /// 		1. Serie: cadena de caracteres con el número de serie a consultar
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static bool Consultar_Existe_Serie(string Serie)
        {
            String Mi_SQL;
            DataTable Dt_Consulta = new DataTable();

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
                Mi_SQL = "SELECT " + Ope_Accesos.Campo_No_Acceso
                    + ", " + Ope_Accesos.Campo_No_Venta
                    + ", " + Ope_Accesos.Campo_Producto_ID
                    + " FROM " + Ope_Accesos.Tabla_Ope_Accesos
                    + " WHERE " + Ope_Accesos.Campo_Numero_Serie + " = '" + Serie + "'";

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Pago: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            // si la tabla está vacía, regresar falso
            if (Dt_Consulta == null || Dt_Consulta.Rows.Count <= 0)
            {
                return false;
            }
            else // si la talba contiene resultados, regresar verdadero
            {
                return true;
            }
        }

        #endregion Consulta
    }
}