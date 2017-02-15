using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using Erp.Constantes;
using Erp.Helper;
using ERP_BASE.Paginas.Paginas_Generales;
using ERP_BASE.App_Code.Negocio.Catalogos;
using System.Windows.Forms;

namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Accesos_Camara_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Migrar_Datos_Camara
        ///DESCRIPCIÓN          : Lee los datos de la cámara y lo inserta en ope_accesos_camaras
        ///PARÁMETROS           : P_Banco que contiene la informacion de el nuevo banco
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 1 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static DataTable Migrar_Datos_Camara_Datos(Cls_Cat_Accesos_Camara_Negocio P_Migracion)
        {
            StringBuilder Mi_Sql = new StringBuilder();
            DateTime Fecha;
            String Str_Cadena_Ip = String.Empty;
            String Query = String.Empty;
            DataTable Dt_Resultados = new DataTable();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Consultar_Existencia = new DataTable();
            Boolean Transaccion_Activa = false;
            WebRequest Solicitud_Request;
            HttpWebResponse Respuesta_Response;
            Stream Archivo_Respuesta;
            StreamReader Lectura;
            String Respuesta_De_Servidor;
            String[] Archivo;
            String SqlQuery;
            String SqlInsert;
            String[] Linea;
            int No_Acceso;
            object res;
            Boolean Estatus = false;

            try
            {
                Fecha = P_Migracion.P_Dtime_Fecha;

                Conexion.Iniciar_Helper();

                if (!Conexion.HelperGenerico.Estatus_Transaccion())
                {
                    Conexion.HelperGenerico.Conexion_y_Apertura();
                }
                else
                {
                    Transaccion_Activa = true;
                }

                Str_Cadena_Ip = "http://<CamIP>/local/VE170/rep.csv?";

                String StartMonth = Fecha.ToString("MM");
                String EndMonth = StartMonth;
                String StartDay = Fecha.ToString("dd");
                String EndDay = StartDay;
                String StartHour = "0";
                String EndHour = "23";

                Query = "StartMonth=" + StartMonth;
                Query += "&EndMonth=" + EndMonth;
                Query += "&StartDay=" + StartDay;
                Query += "&EndDay=" + EndDay;
                Query += "&StartHour=" + StartHour;
                Query += "&EndHour=" + EndHour;
                Query += "&DetailLevel=H";


                //  se consultaran las camaras activas
                Mi_Sql.Append("SELECT * FROM " + Cat_Camaras.Tabla_Cat_Camaras + " where " + Cat_Camaras.Campo_Estatus + " ='ACTIVO'");
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

                Mi_Sql.Clear();
                Mi_Sql.Append("delete from " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras);
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_Sql.ToString());

                //  inicion de la transaccion
                Conexion.HelperGenerico.Iniciar_Transaccion();


                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    //Mi_Sql.Clear();
                    //Mi_Sql.Append("Select " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + ".*");
                    //Mi_Sql.Append(" From " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras);
                    //Mi_Sql.Append(" where (" + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Fecha_Hora + " >= '" + Fecha.ToString("yyyy-MM-dd") + " 00:00:00" + "'");
                    //Mi_Sql.Append(" and " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Fecha_Hora + " <= '" + Fecha.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                    //Mi_Sql.Append(")");
                    //Mi_Sql.Append(" And " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Camara_Id + "='" + Registro[Cat_Camaras.Campo_Camara_ID].ToString() + "'");
                    //Dt_Consultar_Existencia = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

                    //  valida que no exista informacion
                    //if (Dt_Consultar_Existencia != null && Dt_Consultar_Existencia.Rows.Count == 0)
                    //{

                    Str_Cadena_Ip = "http://<CamIP>/local/VE170/rep.csv?";
                    Str_Cadena_Ip = Str_Cadena_Ip.Replace("<CamIP>", Registro[Cat_Camaras.Campo_Url].ToString()) + Query;

                    Mi_Sql.Clear();
                    Mi_Sql.Append("INSERT INTO " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "(");
                    Mi_Sql.Append(Ope_Accesos_Camaras_Temp.Campo_No_Acceso + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras_Temp.Campo_Fecha_Hora + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras_Temp.Campo_Cantidad + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras_Temp.Campo_Cantidad_Salida + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras_Temp.Campo_Camara_Id + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras_Temp.Campo_Usuario_Creo + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras_Temp.Campo_Fecha_Creo + ")");
                    Mi_Sql.Append("VALUES('$No_Acceso', '$Fecha_Hora', $Cantidad, $Salida, '$Camara_Id', '$Usuario_Creo', NOW());");

                    Solicitud_Request = WebRequest.Create(Str_Cadena_Ip);
                    Solicitud_Request.Credentials = new NetworkCredential(Registro[Cat_Camaras.Campo_Usuario].ToString(), Registro[Cat_Camaras.Campo_Contrasenia].ToString());

                    Respuesta_Response = (HttpWebResponse)Solicitud_Request.GetResponse();
                    Archivo_Respuesta = Respuesta_Response.GetResponseStream();
                    Lectura = new StreamReader(Archivo_Respuesta);
                    Respuesta_De_Servidor = Lectura.ReadToEnd();

                    Archivo = Respuesta_De_Servidor.Replace("\r\n", "\n").Split('\n');
                    SqlQuery = Mi_Sql.ToString();
                    SqlInsert = String.Empty;

                    Conexion.Iniciar_Helper();
                    Conexion.HelperGenerico.Conexion_y_Apertura();

                    res = Conexion.HelperGenerico.Obtener_Escalar("SELECT IFNULL(MAX(" + Ope_Accesos_Camaras_Temp.Campo_No_Acceso + "), 0) FROM " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras);
                    No_Acceso = int.Parse(res.ToString());


                    for (int Cont_For = 5; Cont_For < Archivo.Length; Cont_For++)
                    {
                        No_Acceso++;

                        Linea = Archivo[Cont_For].Split(',');

                        if (Linea.Length != 3) { break; }

                        if (Linea[1] != "n/a")
                        {
                            string Hora = DateTime.Parse(Linea[0]).ToString("HH");
                            string Fecha_Hora = Fecha.ToString("yyyy-MM-dd") + " " + Hora;

                            SqlInsert += SqlQuery;
                            SqlInsert = SqlInsert.Replace("$No_Acceso", String.Format("{0:0000000000}", +No_Acceso))
                                        .Replace("$Fecha_Hora", Fecha_Hora);

                            ////  validacion para la camara de entrada
                            //if (Registro[Cat_Camaras.Campo_Tipo].ToString() == "ENTRADA")
                            //{
                            SqlInsert = SqlInsert.Replace("$Cantidad", Linea[1]);
                            //    SqlInsert = SqlInsert.Replace("$Salida", "0");
                            //}
                            //else
                            //{
                            //    SqlInsert = SqlInsert.Replace("$Cantidad", "0");
                            SqlInsert = SqlInsert.Replace("$Salida", Linea[2]);
                            //}


                            SqlInsert = SqlInsert.Replace("$Camara_Id", Registro[Cat_Camaras.Campo_Camara_ID].ToString())
                                      .Replace("$Usuario_Creo", MDI_Frm_Apl_Principal.Nombre_Usuario);
                        }
                    }// fin del for arcnivo

                    if (!String.IsNullOrEmpty(SqlInsert))
                        Conexion.HelperGenerico.Ejecutar_NonQuery(SqlInsert);

                    Lectura.Close();
                    Archivo_Respuesta.Close();
                    Respuesta_Response.Close();

                    //}//consulta de existencia de registros

                }   // fin del foreach

                Mi_Sql.Clear();
                Mi_Sql.Append("SELECT " + Cat_Camaras.Tabla_Cat_Camaras + "." + Cat_Camaras.Campo_Nombre);
                Mi_Sql.Append(", " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Fecha_Hora);
                Mi_Sql.Append(", " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Cantidad);
                Mi_Sql.Append(", " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Cantidad_Salida);
                Mi_Sql.Append(" From " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras);
                Mi_Sql.Append(" left outer join " + Cat_Camaras.Tabla_Cat_Camaras + " on " + Cat_Camaras.Tabla_Cat_Camaras + "." + Cat_Camaras.Campo_Camara_ID);
                Mi_Sql.Append(" = " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Camara_Id);
                Mi_Sql.Append(" where (" + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Fecha_Hora + " >= '" + Fecha.ToString("yyyy-MM-dd") + " 00:00:00" + "'");
                Mi_Sql.Append(" and " + Ope_Accesos_Camaras_Temp.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras_Temp.Campo_Fecha_Hora + " <= '" + Fecha.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                Mi_Sql.Append(")");

                Dt_Resultados = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception e)
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Abortar_Transaccion();
                }

                throw new Exception("Cámara : " + e.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }

            return Dt_Resultados;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Migrar_Datos_Camara
        ///DESCRIPCIÓN          : Lee los datos de la cámara y lo inserta en ope_accesos_camaras
        ///PARÁMETROS           : P_Banco que contiene la informacion de el nuevo banco
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 1 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static DataTable Migrar_Datos_Pendientes_Camara(Cls_Cat_Accesos_Camara_Negocio P_Migracion)
        {
            StringBuilder Mi_Sql = new StringBuilder();
            DateTime Fecha;
            String Str_Cadena_Ip = String.Empty;
            String Query = String.Empty;
            DataTable Dt_Resultados = new DataTable();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Consultar_Existencia = new DataTable();
            Boolean Transaccion_Activa = false;
            WebRequest Solicitud_Request;
            HttpWebResponse Respuesta_Response;
            Stream Archivo_Respuesta;
            StreamReader Lectura;
            String Respuesta_De_Servidor;
            String[] Archivo;
            String SqlQuery;
            String SqlInsert;
            String[] Linea;
            int No_Acceso;
            object res;
            Boolean Estatus = false;

            try
            {
                Fecha = P_Migracion.P_Dtime_Fecha;

                Conexion.Iniciar_Helper();

                if (!Conexion.HelperGenerico.Estatus_Transaccion())
                {
                    Conexion.HelperGenerico.Conexion_y_Apertura();
                }
                else
                {
                    Transaccion_Activa = true;
                }

                Str_Cadena_Ip = "http://<CamIP>/local/VE170/rep.csv?";

                String StartMonth = Fecha.ToString("MM");
                String EndMonth = StartMonth;
                String StartDay = Fecha.ToString("dd");
                String EndDay = StartDay;
                String StartHour = "0";
                String EndHour = "23";

                Query = "StartMonth=" + StartMonth;
                Query += "&EndMonth=" + EndMonth;
                Query += "&StartDay=" + StartDay;
                Query += "&EndDay=" + EndDay;
                Query += "&StartHour=" + StartHour;
                Query += "&EndHour=" + EndHour;
                Query += "&DetailLevel=H";


                //  se consultaran las camaras activas
                Mi_Sql.Append("SELECT * FROM " + Cat_Camaras.Tabla_Cat_Camaras + " where " + Cat_Camaras.Campo_Estatus + " ='ACTIVO'");
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());


                //  inicion de la transaccion
                Conexion.HelperGenerico.Iniciar_Transaccion();


                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    Str_Cadena_Ip = "http://<CamIP>/local/VE170/rep.csv?";
                    Str_Cadena_Ip = Str_Cadena_Ip.Replace("<CamIP>", Registro[Cat_Camaras.Campo_Url].ToString()) + Query;

                    Mi_Sql.Clear();
                    Mi_Sql.Append("INSERT INTO " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "(");
                    Mi_Sql.Append(Ope_Accesos_Camaras.Campo_No_Acceso + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras.Campo_Fecha_Hora + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras.Campo_Cantidad + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras.Campo_Cantidad_Salida + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras.Campo_Camara_Id + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras.Campo_Usuario_Creo + ",");
                    Mi_Sql.Append(Ope_Accesos_Camaras.Campo_Fecha_Creo + ")");
                    Mi_Sql.Append("VALUES('$No_Acceso', '$Fecha_Hora', $Cantidad, $Salida, '$Camara_Id', '$Usuario_Creo', NOW());");

                    Solicitud_Request = WebRequest.Create(Str_Cadena_Ip);
                    Solicitud_Request.Credentials = new NetworkCredential(Registro[Cat_Camaras.Campo_Usuario].ToString(), Registro[Cat_Camaras.Campo_Contrasenia].ToString());

                    Respuesta_Response = (HttpWebResponse)Solicitud_Request.GetResponse();
                    Archivo_Respuesta = Respuesta_Response.GetResponseStream();
                    Lectura = new StreamReader(Archivo_Respuesta);
                    Respuesta_De_Servidor = Lectura.ReadToEnd();

                    Archivo = Respuesta_De_Servidor.Replace("\r\n", "\n").Split('\n');
                    SqlQuery = Mi_Sql.ToString();
                    SqlInsert = String.Empty;

                    Conexion.Iniciar_Helper();
                    Conexion.HelperGenerico.Conexion_y_Apertura();

                    res = Conexion.HelperGenerico.Obtener_Escalar("SELECT IFNULL(MAX(" + Ope_Accesos_Camaras.Campo_No_Acceso + "), 0) FROM " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras);
                    No_Acceso = int.Parse(res.ToString());


                    for (int Cont_For = 5; Cont_For < Archivo.Length; Cont_For++)
                    {
                        No_Acceso++;

                        Linea = Archivo[Cont_For].Split(',');

                        if (Linea.Length != 3) { break; }

                        if (Linea[1] != "n/a")
                        {
                            string Hora = DateTime.Parse(Linea[0]).ToString("HH");
                            string Fecha_Hora = Fecha.ToString("yyyy-MM-dd") + " " + Hora;

                            SqlInsert += SqlQuery;
                            SqlInsert = SqlInsert.Replace("$No_Acceso", String.Format("{0:0000000000}", +No_Acceso))
                                        .Replace("$Fecha_Hora", Fecha_Hora);

                            ////  validacion para la camara de entrada
                            //if (Registro[Cat_Camaras.Campo_Tipo].ToString() == "ENTRADA")
                            //{
                            SqlInsert = SqlInsert.Replace("$Cantidad", Linea[1]);
                            //    SqlInsert = SqlInsert.Replace("$Salida", "0");
                            //}
                            //else
                            //{
                            //    SqlInsert = SqlInsert.Replace("$Cantidad", "0");
                            SqlInsert = SqlInsert.Replace("$Salida", Linea[2]);
                            //}


                            SqlInsert = SqlInsert.Replace("$Camara_Id", Registro[Cat_Camaras.Campo_Camara_ID].ToString())
                                      .Replace("$Usuario_Creo", MDI_Frm_Apl_Principal.Nombre_Usuario);
                        }
                    }// fin del for arcnivo

                    if (!String.IsNullOrEmpty(SqlInsert))
                        Conexion.HelperGenerico.Ejecutar_NonQuery(SqlInsert);

                    Lectura.Close();
                    Archivo_Respuesta.Close();
                    Respuesta_Response.Close();

                    //}//consulta de existencia de registros

                }   // fin del foreach

                Mi_Sql.Clear();
                Mi_Sql.Append("SELECT " + Cat_Camaras.Tabla_Cat_Camaras + "." + Cat_Camaras.Campo_Nombre);
                Mi_Sql.Append(", " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Fecha_Hora);
                Mi_Sql.Append(", " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Cantidad);
                Mi_Sql.Append(", " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Cantidad_Salida);
                Mi_Sql.Append(" From " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras);
                Mi_Sql.Append(" left outer join " + Cat_Camaras.Tabla_Cat_Camaras + " on " + Cat_Camaras.Tabla_Cat_Camaras + "." + Cat_Camaras.Campo_Camara_ID);
                Mi_Sql.Append(" = " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Camara_Id);
                Mi_Sql.Append(" where (" + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Fecha_Hora + " >= '" + Fecha.ToString("yyyy-MM-dd") + " 00:00:00" + "'");
                Mi_Sql.Append(" and " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Fecha_Hora + " <= '" + Fecha.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                Mi_Sql.Append(")");

                Dt_Resultados = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception e)
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Abortar_Transaccion();
                }

                throw new Exception("Cámara : " + e.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }

            return Dt_Resultados;

        }   //frin del metodo


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Migrar_Datos_Camara
        ///DESCRIPCIÓN          : Lee los datos de la cámara y lo inserta en ope_accesos_camaras
        ///PARÁMETROS           : P_Banco que contiene la informacion de el nuevo banco
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 1 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static DataTable Consultar_Si_Existe_Registros(Cls_Cat_Accesos_Camara_Negocio P_Migracion)
        {
            StringBuilder Mi_Sql = new StringBuilder();
            DateTime Fecha;
            String Str_Cadena_Ip = String.Empty;
            String Query = String.Empty;
            DataTable Dt_Resultados = new DataTable();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Consultar_Existencia = new DataTable();
            Boolean Transaccion_Activa = false;

            try
            {
                Fecha = P_Migracion.P_Dtime_Fecha;

                Conexion.Iniciar_Helper();

                if (!Conexion.HelperGenerico.Estatus_Transaccion())
                {
                    Conexion.HelperGenerico.Conexion_y_Apertura();
                }
                else
                {
                    Transaccion_Activa = true;
                }

                Mi_Sql.Clear();
                Mi_Sql.Append("SELECT * ");
                Mi_Sql.Append(" From " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras);
                Mi_Sql.Append(" where " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + "." + Ope_Accesos_Camaras.Campo_Fecha_Hora + " = '" + Fecha.ToString("yyyy-MM-dd") + " 00:00:00" + "'");

                Dt_Resultados = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

               
            }
            catch (Exception e)
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Abortar_Transaccion();
                }

                throw new Exception("Cámara : " + e.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }

            return Dt_Resultados;

        }   //frin del metodo




    }// fin de la clase

}// fin del namespace
