using System;
using System.Data;
using Erp.Helper;
using Erp.Constantes;
using Operaciones.Turnos.Negocio;
using Erp.Metodos_Generales;
using Erp.Ayudante_Sintaxis;
using ERP_BASE.Paginas.Paginas_Generales;
using System.Text;
using Erp_Solicitud_Facturacion.Negocio;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Operaciones.Turnos.Datos
{
    public class Cls_Ope_Turnos_Datos
    {

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Turnos
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para insertar un nuevo turno en la base de datos, 
        ///             regresa el número de filas insertadas
        ///PARÁMETROS:
        /// 		1. Datos_Turno: instancia de la clase de negocio de turnos con los datos para la consulta
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static int Alta_Turno(Cls_Ope_Turnos_Negocio Datos_Turno)
        {
            int Registros_Alta = 0;
            string Mi_sql;
            String No_Turno = "";

            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            // validar el estatus de la transacción
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
                No_Turno = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Turnos.Tabla_Ope_Turnos, Ope_Turnos.Campo_No_Turno, "", 10);

                Mi_sql = "INSERT INTO " + Ope_Turnos.Tabla_Ope_Turnos + "("
                    + Ope_Turnos.Campo_No_Turno + ", "
                    + Ope_Turnos.Campo_Turno_ID + ", "
                    + Ope_Turnos.Campo_Fecha_Hora_Inicio + ", "
                    + Ope_Turnos.Campo_Estatus + ", "
                    + Ope_Turnos.Campo_Usuario_Creo + ", "
                    + Ope_Turnos.Campo_Fecha_Creo
                    + ") VALUES ("
                    + "'" + No_Turno + "', "
                    + "'" + Datos_Turno.P_Turno_ID + "', "
                    + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos_Turno.P_Fecha_Hora_Inicio) + ", "
                    + "'" + Datos_Turno.P_Estatus + "', "
                    + "'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', "
                    + Cls_Ayudante_Sintaxis.Fecha()
                    + ")";
                Registros_Alta = Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql);

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                Registros_Alta = 0;
                throw new Exception("Alta_Turno: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Registros_Alta;
        }

         ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Actualizar_Turno
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para modificar un turno en la base de datos, 
        ///             regresa el número de registros modificados
        ///PARÁMETROS:
        /// 		1. Datos_Turno: instancia de la clase de negocio de turnos con los datos para la consulta
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static void Cierre_Turno_Fuera_Fecha(Cls_Ope_Turnos_Negocio Datos_Turno)
        {
            StringBuilder Mi_SQL;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            
            // validar el estatus de la transacción
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
                Mi_SQL.Append("UPDATE " + Ope_Turnos.Tabla_Ope_Turnos + " SET ");

                // validar los parámetros que contengan valores y agregar a la consulta
                Mi_SQL.Append(Ope_Turnos.Campo_Fecha_Hora_Cierre + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos_Turno.P_Fecha_Hora_Cierre) + ", ");
                Mi_SQL.Append(Ope_Turnos.Campo_Estatus + " = 'CERRADO' ,");
                Mi_SQL.Append(Ope_Turnos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_SQL.Append(Ope_Turnos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" WHERE " + Ope_Turnos.Campo_Estatus + " = 'ABIERTO'");

                // ejecutar la actualizacion
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Actualizar_Turno: " + E.Message);
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
        ///NOMBRE_FUNCIÓN: Actualizar_Turno
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para modificar un turno en la base de datos, 
        ///             regresa el número de registros modificados
        ///PARÁMETROS:
        /// 		1. Datos_Turno: instancia de la clase de negocio de turnos con los datos para la consulta
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static int Actualizar_Turno(Cls_Ope_Turnos_Negocio Datos_Turno)
        {
            int Registros_Actualizados = 0;
            StringBuilder Mi_SQL;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            // validar el estatus de la transacción
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


                #region Cierre de turno
                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("UPDATE " + Ope_Turnos.Tabla_Ope_Turnos + " SET ");
                // validar los parámetros que contengan valores y agregar a la consulta
                if (!String.IsNullOrEmpty(Datos_Turno.P_Turno_ID))
                {
                    Mi_SQL.Append(Ope_Turnos.Campo_Turno_ID + " = '" + Datos_Turno.P_Turno_ID + "', ");
                }
                if (Datos_Turno.P_Fecha_Hora_Inicio != DateTime.MinValue)
                {
                if (Datos_Turno.P_Fecha_Hora_Cierre != DateTime.MinValue)
                    Mi_SQL.Append(Ope_Turnos.Campo_Fecha_Hora_Inicio + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos_Turno.P_Fecha_Hora_Inicio) + ", ");
                }
                {
                    Mi_SQL.Append(Ope_Turnos.Campo_Fecha_Hora_Cierre + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos_Turno.P_Fecha_Hora_Cierre) + ", ");
                }
                if (!String.IsNullOrEmpty(Datos_Turno.P_Estatus))
                {
                    Mi_SQL.Append(Ope_Turnos.Campo_Estatus + " = '" + Datos_Turno.P_Estatus + "', ");
                }

                Mi_SQL.Append(Ope_Turnos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_SQL.Append(Ope_Turnos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" WHERE " + Ope_Turnos.Campo_No_Turno + " = '" + Datos_Turno.P_No_Turno + "'");
                
                // ejecutar la consulta
                Registros_Actualizados = Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                #endregion

                #region Camaras
                //DateTime Fecha;
                //String Str_Cadena_Ip = String.Empty;
                //String Query = String.Empty;
                //DataTable Dt_Resultados = new DataTable();
                //DataTable Dt_Consulta = new DataTable();
                //DataTable Dt_Consultar_Existencia = new DataTable();
                //WebRequest Solicitud_Request;
                //HttpWebResponse Respuesta_Response = null;
                //Stream Archivo_Respuesta;
                //StreamReader Lectura;
                //String Respuesta_De_Servidor;
                //String[] Archivo;
                //String SqlQuery;
                //String SqlInsert;
                //String[] Linea;
                //int No_Acceso;
                //object res;

                //Fecha = Datos_Turno.P_Dtime_Fecha;
                ////MessageBox.Show(Fecha.ToString(), "Modificar turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                ////  se crea la cadena que consultara la informacion de las camaras
                //Str_Cadena_Ip = "http://<CamIP>/local/VE170/rep.csv?";
                //String StartMonth = Fecha.ToString("MM");
                //String EndMonth = StartMonth;
                //String StartDay = Fecha.ToString("dd");
                //String EndDay = StartDay;
                //String StartHour = "0";
                //String EndHour = "23";
                //Query = "StartMonth=" + StartMonth;
                //Query += "&EndMonth=" + EndMonth;
                //Query += "&StartDay=" + StartDay;
                //Query += "&EndDay=" + EndDay;
                //Query += "&StartHour=" + StartHour;
                //Query += "&EndHour=" + EndHour;
                //Query += "&DetailLevel=H";


                ////  se consultaran las camaras activas
                //Mi_SQL.Clear();
                //Mi_SQL.Append("SELECT * FROM " + Cat_Camaras.Tabla_Cat_Camaras + " where " + Cat_Camaras.Campo_Estatus + " ='ACTIVO'");
                //Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                //foreach (DataRow Registro in Dt_Consulta.Rows)
                //{
                //    Mi_SQL.Clear();
                //    Mi_SQL.Append("Select " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + ".*");
                //    Mi_SQL.Append(" From " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras);
                //    Mi_SQL.Append(" where ( DATE_FORMAT(" + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '%Y-%m-%d %H:%i:%S') >= '" + Fecha.ToString("yyyy-MM-dd") + " 00:00:00" + "'");
                //    Mi_SQL.Append(" and  DATE_FORMAT(" + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '%Y-%m-%d %H:%i:%S') <= '" + Fecha.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                //    Mi_SQL.Append(")");
                //    Mi_SQL.Append(" And " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Camara_Id + "='" + Registro[Cat_Camaras.Campo_Camara_ID].ToString() + "'");
                //    Dt_Consultar_Existencia = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                //    //  valida que no exista informacion
                //    if (Dt_Consultar_Existencia != null && Dt_Consultar_Existencia.Rows.Count == 0)
                //    {
                //        Str_Cadena_Ip = "http://<CamIP>/local/VE170/rep.csv?";
                //        Str_Cadena_Ip = Str_Cadena_Ip.Replace("<CamIP>", Registro[Cat_Camaras.Campo_Url].ToString()) + Query;

                //        Mi_SQL.Clear();
                //        Mi_SQL.Append("INSERT INTO " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "(");
                //        Mi_SQL.Append(Ope_Accesos_Camaras.Campo_No_Acceso + ",");
                //        Mi_SQL.Append(Ope_Accesos_Camaras.Campo_Fecha_Hora + ",");
                //        Mi_SQL.Append(Ope_Accesos_Camaras.Campo_Cantidad + ",");
                //        Mi_SQL.Append(Ope_Accesos_Camaras.Campo_Cantidad_Salida + ",");
                //        Mi_SQL.Append(Ope_Accesos_Camaras.Campo_Camara_Id + ",");
                //        Mi_SQL.Append(Ope_Accesos_Camaras.Campo_Usuario_Creo + ",");
                //        Mi_SQL.Append(Ope_Accesos_Camaras.Campo_Fecha_Creo + ")");
                //        Mi_SQL.Append("VALUES('$No_Acceso', '$Fecha_Hora', $Cantidad, $Salida, '$Camara_Id', '$Usuario_Creo', NOW());");

                //        Solicitud_Request = WebRequest.Create(Str_Cadena_Ip);
                //        Solicitud_Request.Credentials = new NetworkCredential(Registro[Cat_Camaras.Campo_Usuario].ToString(), Registro[Cat_Camaras.Campo_Contrasenia].ToString());

                //        try
                //        {
                //            Respuesta_Response = (HttpWebResponse)Solicitud_Request.GetResponse();
                //        }
                //        catch (Exception E)
                //        {
                //            MessageBox.Show("Error al conectar con la camara [" + Registro[Cat_Camaras.Campo_Nombre].ToString() + "] [" + Registro[Cat_Camaras.Campo_Tipo] + "]", "Camras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            continue;
                //        }

                //        Archivo_Respuesta = Respuesta_Response.GetResponseStream();
                //        Lectura = new StreamReader(Archivo_Respuesta);
                //        Respuesta_De_Servidor = Lectura.ReadToEnd();

                //        Archivo = Respuesta_De_Servidor.Replace("\r\n", "\n").Split('\n');
                //        SqlQuery = Mi_SQL.ToString();
                //        SqlInsert = String.Empty;

                //        Conexion.Iniciar_Helper();
                //        Conexion.HelperGenerico.Conexion_y_Apertura();

                //        res = Conexion.HelperGenerico.Obtener_Escalar("SELECT IFNULL(MAX(" + Ope_Accesos_Camaras.Campo_No_Acceso + "), 0) FROM " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras);
                //        No_Acceso = int.Parse(res.ToString());


                //        for (int Cont_For = 5; Cont_For < Archivo.Length; Cont_For++)
                //        {
                //            No_Acceso++;

                //            Linea = Archivo[Cont_For].Split(',');

                //            if (Linea.Length != 3) { break; }

                //            if (Linea[1] != "n/a")
                //            {
                //                string Hora = DateTime.Parse(Linea[0]).ToString("HH");
                //                string Fecha_Hora = Fecha.ToString("yyyy-MM-dd") + " " + Hora;

                //                SqlInsert += SqlQuery;
                //                SqlInsert = SqlInsert.Replace("$No_Acceso", String.Format("{0:0000000000}", +No_Acceso))
                //                            .Replace("$Fecha_Hora", Fecha_Hora);

                //                SqlInsert = SqlInsert.Replace("$Cantidad", Linea[1]);
                //                SqlInsert = SqlInsert.Replace("$Salida", Linea[2]);

                //                ////  validacion para la camara de entrada
                //                //if (Registro[Cat_Camaras.Campo_Tipo].ToString() == "ENTRADA")
                //                //{
                //                //    SqlInsert = SqlInsert.Replace("$Cantidad", Linea[1]);
                //                //    SqlInsert = SqlInsert.Replace("$Salida", "0");
                //                //}
                //                //else
                //                //{
                //                //    SqlInsert = SqlInsert.Replace("$Cantidad", "0");
                //                //    SqlInsert = SqlInsert.Replace("$Salida", Linea[2]);
                //                //}


                //                SqlInsert = SqlInsert.Replace("$Camara_Id", Registro[Cat_Camaras.Campo_Camara_ID].ToString())
                //                          .Replace("$Usuario_Creo", MDI_Frm_Apl_Principal.Nombre_Usuario);
                //            }
                //        }// fin del for arcnivo

                //        if (!String.IsNullOrEmpty(SqlInsert))
                //            Conexion.HelperGenerico.Ejecutar_NonQuery(SqlInsert);

                //        Lectura.Close();
                //        Archivo_Respuesta.Close();
                //        Respuesta_Response.Close();

                //    }//consulta de existencia de registros

                //}   // fin del foreach

                #endregion


                #region Deudorcad
                if (Datos_Turno.P_Estatus_Ventas_Enviadas == true)
                {
                    Cls_Ope_Solicitud_Facturacion_Negocio Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
                    Obj_Enviar_Ventas_Dia.P_Fecha_Venta = Datos_Turno.P_Fecha_Venta;
                    Obj_Enviar_Ventas_Dia.P_Dt_Ventas_Dia = Datos_Turno.P_Dt_Ventas_Dia;
                    Obj_Enviar_Ventas_Dia.P_Dt_Parametros = Datos_Turno.P_Dt_Parametros;
                    Obj_Enviar_Ventas_Dia.P_Dt_Padron_Nuevos = Datos_Turno.P_Dt_Padron_Nuevos; 
                    Obj_Enviar_Ventas_Dia.P_Dt_Listdeudor_Nuevos = Datos_Turno.P_Dt_Listdeudor_Nuevos;
                    Obj_Enviar_Ventas_Dia.P_Dt_Padron_Actualizacion = Datos_Turno.P_Dt_Padron_Actualizacion;
                    Obj_Enviar_Ventas_Dia.P_Dt_Listdeudor_ = Datos_Turno.P_Dt_Listdeudor_;
                    Obj_Enviar_Ventas_Dia.P_Dt_Padron_Nuevos_Direcciones = Datos_Turno.P_Dt_Padron_Nuevos_Direcciones;
                    Obj_Enviar_Ventas_Dia.Enviar_Ventas_Dia();

                    //  se actualiza el historico
                    Obj_Enviar_Ventas_Dia.P_No_Turno = Datos_Turno.P_No_Turno;
                    Obj_Enviar_Ventas_Dia.Actualizar_Historico();
                }
                #endregion

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                Registros_Actualizados = 0;
                throw new Exception("Actualizar_Turno: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Registros_Actualizados;
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
        public static DataTable Consultar_Turnos(Cls_Ope_Turnos_Negocio Datos_Turno)
        {
            string Mi_SQL;
            Conexion.Iniciar_Helper();
            DataTable Dt_Resultado = new DataTable();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = "SELECT *, Fecha_Hora_Inicio AS Hora_Inicio, (SELECT " + Cat_Turnos.Campo_Nombre + " FROM " + Cat_Turnos.Tabla_Cat_Turnos
                + " WHERE " + Cat_Turnos.Campo_Turno_ID + "=" + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_Turno_ID
                + ") AS NOMBRE_TURNO FROM " + Ope_Turnos.Tabla_Ope_Turnos + " WHERE 1=1";
            // agregar filtros opcionales
            if (!String.IsNullOrEmpty(Datos_Turno.P_Turno_ID))
            {
                Mi_SQL += " AND " + Ope_Turnos.Campo_No_Turno + " = '" + Datos_Turno.P_Turno_ID + "'";
            }
            if (!String.IsNullOrEmpty(Datos_Turno.P_Estatus))
            {
                Mi_SQL += " AND " + Ope_Turnos.Campo_Estatus + " = '" + Datos_Turno.P_Estatus + "'";
            }
            if (Datos_Turno.P_Desde_Fecha != DateTime.MinValue)
            {
                Mi_SQL += " AND cast(" + Ope_Turnos.Campo_Fecha_Hora_Inicio + " As Date) >= cast("
                    + Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos_Turno.P_Desde_Fecha) + " As Date)";
            }
            if (Datos_Turno.P_Hasta_Fecha != DateTime.MinValue)
            {
                Mi_SQL += " AND cast(" + Ope_Turnos.Campo_Fecha_Hora_Inicio + " As Date) <= cast("
                    + Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos_Turno.P_Hasta_Fecha) + " As Date)";
            }

            Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL);
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Resultado;
        }


        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Existencia_Turnos
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para obtener y regresar un datatable con los turnos
        ///PARÁMETROS:
        /// 		1. Datos_Turno: instancia de la clase de negocio de turnos con los criterios para la búsqueda
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static DataTable Consultar_Existencia_Turnos(Cls_Ope_Turnos_Negocio Datos)
        {
            string Mi_SQL;
            Conexion.Iniciar_Helper();
            DataTable Dt_Resultado = new DataTable();
            Conexion.HelperGenerico.Conexion_y_Apertura();


            Mi_SQL = "select * from " + Ope_Turnos.Tabla_Ope_Turnos;
            Mi_SQL += " where  DATE_FORMAT(" + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_Fecha_Hora_Inicio + ", '%Y-%m-%d') = ";
            Mi_SQL += "'" + Datos.P_Fecha_Venta + "'";

            Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL);
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Resultado;
        }

    }
}
