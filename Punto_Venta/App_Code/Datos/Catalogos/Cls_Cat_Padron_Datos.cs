using System;
using System.Text;
using Erp.Metodos_Generales;
using Erp.Helper;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Ayudante_Sintaxis;
using ERP_BASE.Paginas.Paginas_Generales;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Erp.Seguridad;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using Erp_Apl_Parametros.Negocio;



namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Padron_Datos
    {
        #region

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuario_Padron
        ///DESCRIPCIÓN          : inserta el valor de los usuarios
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static Boolean Alta_Usuario_Padron_Local(Cls_Cat_Padron_Negocio Datos)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Boolean Accion_Completa = false;

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
                
                Mi_SQL = "INSERT INTO " + Cat_Padron.Tabla + "(";
                Mi_SQL += Cat_Padron.Campo_Curp;//  1
                Mi_SQL += ", " + Cat_Padron.Campo_Rfc;//    2
                Mi_SQL += ", " + Cat_Padron.Campo_Tipo;//   3
                Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Paterno;//   4
                Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Materno;//   5
                Mi_SQL += ", " + Cat_Padron.Campo_Nombre;// 6
                Mi_SQL += ", " + Cat_Padron.Campo_Edonac;// 7
                Mi_SQL += ", " + Cat_Padron.Campo_Fecha_Nacimiento;//   8
                Mi_SQL += ", " + Cat_Padron.Campo_Genero;// 9
                Mi_SQL += ", " + Cat_Padron.Campo_Consecutivo;//    10
                Mi_SQL += ", " + Cat_Padron.Campo_Maquina;//    11
                Mi_SQL += ", " + Cat_Padron.Campo_Captura;//    12
                Mi_SQL += ", " + Cat_Padron.Campo_Hora;//   13
                Mi_SQL += ", " + Cat_Padron.Campo_Usuario;//    14
                Mi_SQL += ", " + Cat_Padron.Campo_Baja;// 15
                Mi_SQL += ", " + Cat_Padron.Campo_Interno1;//   16
                //Mi_SQL += ", " + Cat_Padron.Campo_Calle;//   17
                //Mi_SQL += ", " + Cat_Padron.Campo_No_Interno;//   18
                //Mi_SQL += ", " + Cat_Padron.Campo_No_Exterior;//   19
                //Mi_SQL += ", " + Cat_Padron.Campo_Colonia;//   20
                //Mi_SQL += ", " + Cat_Padron.Campo_Municipio;//   21
                //Mi_SQL += ", " + Cat_Padron.Campo_Estado;//   22
                //Mi_SQL += ", " + Cat_Padron.Campo_Codigo_Postal;//   23
                Mi_SQL += ")";
                Mi_SQL += " values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Datos.P_Curp + "'";//   1
                Mi_SQL += ", '" + Datos.P_Rfc + "'";//  2
                Mi_SQL += ", '" + Datos.P_Tipo + "'";// 3
                Mi_SQL += ", '" + Datos.P_Apellido_Paterno + "'";// 4
                Mi_SQL += ", '" + Datos.P_Apellido_Materno + "'";// 5
                Mi_SQL += ", '" + Datos.P_Nombre + "'";//   6
                Mi_SQL += ", '0'"; //   edonac  default "0"// 7
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//  8
                Mi_SQL += ", '" + Datos.P_Genero + "'";//   9
                Mi_SQL += ", '0'";// consecutivo //   10
                Mi_SQL += ", '" + Datos.P_Equipo + "'";//   11
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//  12
                Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//   13
                Mi_SQL += ", '" + Datos.P_Usuario + "'";//  14
                Mi_SQL += ", ''";// Baja //   15
                Mi_SQL += ", 'N'"; //   interno1  default "N"// 16
                //Mi_SQL += ", '" + Datos.P_Calle + "'";// 17
                //Mi_SQL += ", '" + Datos.P_Numero_Interior + "'";// 18
                //Mi_SQL += ", '" + Datos.P_Numero_Exterior + "'";// 19
                //Mi_SQL += ", '" + Datos.P_Colonia + "'";// 20
                //Mi_SQL += ", '" + Datos.P_Municipio + "'";// 21
                //Mi_SQL += ", '" + Datos.P_Estado + "'";// 22
                //Mi_SQL += ", '" + Datos.P_Codigo_Postal + "'";// 23
                Mi_SQL += ")";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                //Comando_Mysql.CommandText = Mi_SQL;
                //Comando_Mysql.ExecuteNonQuery();

                //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES
                Mi_SQL = "insert into listdeudor ";
                Mi_SQL += "(";
                Mi_SQL += "tipo";//  1
                Mi_SQL += ", lista";//   2
                Mi_SQL += ", curp";//    3
                Mi_SQL += ", tipol";//   4
                Mi_SQL += ", referencia1";// 5
                Mi_SQL += ", referencia2";// 6
                Mi_SQL += ", registro";//    7
                Mi_SQL += ", baja";//   8
                Mi_SQL += ", userr";//  9
                //Mi_SQL += ", userb";//    10
                Mi_SQL += ", clave";//  11
                Mi_SQL += ", cantidad";//   12
                Mi_SQL += ", observa";//   13
                Mi_SQL += ", cantidad2";//   14
                Mi_SQL += ", interno1";//   15
                Mi_SQL += ", conse";//   16
                Mi_SQL += ", conspalm";//   17
                Mi_SQL += ", conspalm2";//   18
                Mi_SQL += ")";
                Mi_SQL += " values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Datos.P_Tipo_Lista_Deudor + "'";//  1
                Mi_SQL += ", '" + Datos.P_Lista_Deudor + "'";//    2
                Mi_SQL += ", '" + Datos.P_Rfc + "'";//    3
                Mi_SQL += ", '0'";//    4
                Mi_SQL += ", 'VENTA DE BOLETOS'";//    5
                Mi_SQL += ", 'MUSEO DE MOMIAS'";//    6
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//    7
                Mi_SQL += ", '1900-01-01'";//    8
                Mi_SQL += ", '" + Datos.P_Usuario + "'";//    9
                //Mi_SQL += ", '" + "'";//    10
                Mi_SQL += ", '" + Datos.P_Dt_Parametros.Rows[0][Cat_Parametros.Campo_Clave_Venta_Individual_Deudorcad].ToString() + "'";//    11
                Mi_SQL += ", '1'";//    12
                Mi_SQL += ", 'ENTRADA MUSEO MOMIAS'";//    13
                Mi_SQL += ", '0'";//    14
                Mi_SQL += ", 'N'";//    15
                Mi_SQL += ", '0'";//    16
                Mi_SQL += ", '0'";//    17
                Mi_SQL += ", '0'";//    18
                Mi_SQL += ")";
                //Comando_Mysql.CommandText = Mi_SQL;
                //Comando_Mysql.ExecuteNonQuery();
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //  se ingresa la informacion de la direccion del usuario
                Mi_SQL = "insert into movtos ";
                Mi_SQL += "(";
                Mi_SQL += " curp ";//1 curp
                Mi_SQL += ", numcalle ";//2 numcalle valor por default 0 
                Mi_SQL += ", numext ";//3 numext 
                Mi_SQL += ", numint ";//4 numint
                Mi_SQL += ", numcol ";//5 numcol valor default 0
                Mi_SQL += ", nomcol ";//6 nomcol valor ''
                Mi_SQL += ", cp ";//7 cp 
                Mi_SQL += ", ciudad ";//8 ciudad
                Mi_SQL += ", edo ";//9 edo en numero
                Mi_SQL += ", nomedo ";//10 nomedo estado con letra 
                Mi_SQL += ", pais ";//11 pais
                //Mi_SQL += ", tel1 ";//12 tel1
                Mi_SQL += ", fechamov ";//13 fechamov
                Mi_SQL += ", numnota ";//14 numnota default 1
                Mi_SQL += ", ano ";//15 ano default 0
                Mi_SQL += ", tipom ";//16 tipom default 1
                Mi_SQL += ", maquina ";//17 maquina 
                Mi_SQL += ", captura ";//18 captura 
                Mi_SQL += ", hora ";//19 hora
                Mi_SQL += ", user ";//20 user
                Mi_SQL += ", nomcalle ";//21 nomcalle
                Mi_SQL += ")";
                Mi_SQL += " values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Datos.P_Rfc + "'";//1 curp
                Mi_SQL += ", '0'";//2 numcalle valor por default 0 
                Mi_SQL += ", '" + Datos.P_Numero_Exterior + "'";//3 numext 
                Mi_SQL += ", '" + Datos.P_Numero_Interior + "'";//4 numint
                Mi_SQL += ", '0'";//5 numcol valor default 0
                Mi_SQL += ", '" + Datos.P_Colonia + "'";//6 nomcol valor ''
                Mi_SQL += ", '" + Datos.P_Codigo_Postal + "'";// 7 cp
                Mi_SQL += ", '" + Datos.P_Municipio + "'";//8 ciudad
                Mi_SQL += ", '10'";//9 edo en numero
                Mi_SQL += ", '" + Datos.P_Estado + "'";//10 nomedo estado con letra 
                Mi_SQL += ", 'MEXICO'";//11 pais
                //Mi_SQL += ", '" + "'";//12 tel1
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//13 fechamov
                Mi_SQL += ", '1'";//14 numnota default 1
                Mi_SQL += ", '0'";//15 ano default 0
                Mi_SQL += ", '1'";//16 tipom default 1   
                Mi_SQL += ", '" + Datos.P_Equipo + "'";//17 maquina 
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//18 captura 
                Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//19 hora
                Mi_SQL += ", '" + Datos.P_Usuario + "'";//20 user
                Mi_SQL += ", '" + Datos.P_Calle + "'";//21 nomcalle
                Mi_SQL += ")";
                //Comando_Mysql.CommandText = Mi_SQL;
                //Comando_Mysql.ExecuteNonQuery();
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //  se ingresa la informacion del movimiento en la tabla de los detalles
                Mi_SQL = "insert into ope_historico_padron";
                Mi_SQL += "(";
                Mi_SQL += "Curp_Rfc";
                Mi_SQL += ", Operacion";
                Mi_SQL += ", Fecha";
                Mi_SQL += ")";
                Mi_SQL += " Values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Datos.P_Rfc + "'";
                Mi_SQL += ", 'INSERCION'";
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                Mi_SQL += ")";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

               
                Conexion.HelperGenerico.Terminar_Transaccion();

                Accion_Completa = true;
            }
            catch (Exception E)
            {
                //Obj_Transaccion.Rollback();
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Pago: " + E.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
                //Obj_Conexion.Close();
            }
            return Accion_Completa;
        }
        
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuario_Padron
        ///DESCRIPCIÓN          : inserta el valor de los usuarios
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static Boolean Alta_Usuario_Padron(Cls_Cat_Padron_Negocio Datos)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Boolean Accion_Completa = false;
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand(); ;

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //{
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //}
            //else
            //{
            //    Transaccion_Activa = true;
            //}

            try
            {
                //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                Consulta_Parametros.P_Parametro_Id =  "00001";
                DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                //   validacion para la version 4 de base de datos
                if (Dt_Consulta.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                {
                    #region Version odbc
                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                        StrConexion += "OPTION=3";

                    }

                    using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))

                    using (OdbcCommand Cmd = new OdbcCommand())
                    {
                        MyConnection.Open();

                        Mi_SQL = "INSERT INTO " + Cat_Padron.Tabla + "(";
                        Mi_SQL += Cat_Padron.Campo_Curp;//  1
                        Mi_SQL += ", " + Cat_Padron.Campo_Rfc;//    2
                        Mi_SQL += ", " + Cat_Padron.Campo_Tipo;//   3
                        Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Paterno;//   4
                        Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Materno;//   5
                        Mi_SQL += ", " + Cat_Padron.Campo_Nombre;// 6
                        Mi_SQL += ", " + Cat_Padron.Campo_Edonac;// 7
                        Mi_SQL += ", " + Cat_Padron.Campo_Fecha_Nacimiento;//   8
                        Mi_SQL += ", " + Cat_Padron.Campo_Genero;// 9
                        Mi_SQL += ", " + Cat_Padron.Campo_Consecutivo;//    10
                        Mi_SQL += ", " + Cat_Padron.Campo_Maquina;//    11
                        Mi_SQL += ", " + Cat_Padron.Campo_Captura;//    12
                        Mi_SQL += ", " + Cat_Padron.Campo_Hora;//   13
                        Mi_SQL += ", " + Cat_Padron.Campo_Usuario;//    14
                        Mi_SQL += ", " + Cat_Padron.Campo_Baja;// 15
                        Mi_SQL += ", " + Cat_Padron.Campo_Interno1;//   16
                        //Mi_SQL += ", " + Cat_Padron.Campo_Calle;//   17
                        //Mi_SQL += ", " + Cat_Padron.Campo_No_Interno;//   18
                        //Mi_SQL += ", " + Cat_Padron.Campo_No_Exterior;//   19
                        //Mi_SQL += ", " + Cat_Padron.Campo_Colonia;//   20
                        //Mi_SQL += ", " + Cat_Padron.Campo_Municipio;//   21
                        //Mi_SQL += ", " + Cat_Padron.Campo_Estado;//   22
                        //Mi_SQL += ", " + Cat_Padron.Campo_Codigo_Postal;//   23
                        Mi_SQL += ")";
                        Mi_SQL += " values ";
                        Mi_SQL += "(";
                        Mi_SQL += "'" + Datos.P_Curp + "'";//   1
                        Mi_SQL += ", '" + Datos.P_Rfc + "'";//  2
                        Mi_SQL += ", '" + Datos.P_Tipo + "'";// 3
                        Mi_SQL += ", '" + Datos.P_Apellido_Paterno + "'";// 4
                        Mi_SQL += ", '" + Datos.P_Apellido_Materno + "'";// 5
                        Mi_SQL += ", '" + Datos.P_Nombre + "'";//   6
                        Mi_SQL += ", '0'"; //   edonac  default "0"// 7
                        Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//  8
                        Mi_SQL += ", '" + Datos.P_Genero + "'";//   9
                        Mi_SQL += ", '0'";// consecutivo //   10
                        Mi_SQL += ", '" + Datos.P_Equipo + "'";//   11
                        Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//  12
                        Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//   13
                        Mi_SQL += ", '" + Datos.P_Usuario + "'";//  14
                        Mi_SQL += ", ''";// Baja //   15
                        Mi_SQL += ", 'N'"; //   interno1  default "N"// 16
                        //Mi_SQL += ", '" + Datos.P_Calle + "'";// 17
                        //Mi_SQL += ", '" + Datos.P_Numero_Interior + "'";// 18
                        //Mi_SQL += ", '" + Datos.P_Numero_Exterior + "'";// 19
                        //Mi_SQL += ", '" + Datos.P_Colonia + "'";// 20
                        //Mi_SQL += ", '" + Datos.P_Municipio + "'";// 21
                        //Mi_SQL += ", '" + Datos.P_Estado + "'";// 22
                        //Mi_SQL += ", '" + Datos.P_Codigo_Postal + "'";// 23
                        Mi_SQL += ")";

                        Cmd.Connection = MyConnection;
                        Cmd.CommandText = Mi_SQL;
                        Cmd.ExecuteNonQuery();

                        //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES
                        Mi_SQL = "insert into listdeudor ";
                        Mi_SQL += "(";
                        Mi_SQL += "tipo";//  1
                        Mi_SQL += ", lista";//   2
                        Mi_SQL += ", curp";//    3
                        Mi_SQL += ", tipol";//   4
                        Mi_SQL += ", referencia1";// 5
                        Mi_SQL += ", referencia2";// 6
                        Mi_SQL += ", registro";//    7
                        Mi_SQL += ", baja";//   8
                        Mi_SQL += ", userr";//  9
                        //Mi_SQL += ", userb";//    10
                        Mi_SQL += ", clave";//  11
                        Mi_SQL += ", cantidad";//   12
                        Mi_SQL += ", observa";//   13
                        Mi_SQL += ", cantidad2";//   14
                        Mi_SQL += ", interno1";//   15
                        Mi_SQL += ", conse";//   16
                        Mi_SQL += ", conspalm";//   17
                        Mi_SQL += ", conspalm2";//   18
                        Mi_SQL += ")";
                        Mi_SQL += " values ";
                        Mi_SQL += "(";
                        Mi_SQL += "'" + Datos.P_Tipo_Lista_Deudor + "'";//  1
                        Mi_SQL += ", '" + Datos.P_Lista_Deudor + "'";//    2
                        Mi_SQL += ", '" + Datos.P_Rfc + "'";//    3
                        Mi_SQL += ", '0'";//    4
                        Mi_SQL += ", 'VENTA DE BOLETOS'";//    5
                        Mi_SQL += ", 'MUSEO DE MOMIAS'";//    6
                        Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//    7
                        Mi_SQL += ", '1900-01-01'";//    8
                        Mi_SQL += ", '" + Datos.P_Usuario + "'";//    9
                        //Mi_SQL += ", '" + "'";//    10
                        Mi_SQL += ", '" + Datos.P_Dt_Parametros.Rows[0][Cat_Parametros.Campo_Clave_Venta_Individual_Deudorcad].ToString() + "'";//    11
                        Mi_SQL += ", '1'";//    12
                        Mi_SQL += ", 'ENTRADA MUSEO MOMIAS'";//    13
                        Mi_SQL += ", '0'";//    14
                        Mi_SQL += ", 'N'";//    15
                        Mi_SQL += ", '0'";//    16
                        Mi_SQL += ", '0'";//    17
                        Mi_SQL += ", '0'";//    18
                        Mi_SQL += ")";

                        Cmd.Connection = MyConnection;
                        Cmd.CommandText = Mi_SQL;
                        Cmd.ExecuteNonQuery();

                        //  se ingresa la informacion de la direccion del usuario
                        Mi_SQL = "insert into movtos ";
                        Mi_SQL += "(";
                        Mi_SQL += " curp ";//1 curp
                        Mi_SQL += ", numcalle ";//2 numcalle valor por default 0 
                        Mi_SQL += ", numext ";//3 numext 
                        Mi_SQL += ", numint ";//4 numint
                        Mi_SQL += ", numcol ";//5 numcol valor default 0
                        Mi_SQL += ", nomcol ";//6 nomcol valor ''
                        Mi_SQL += ", cp ";//7 cp 
                        Mi_SQL += ", ciudad ";//8 ciudad
                        Mi_SQL += ", edo ";//9 edo en numero
                        Mi_SQL += ", nomedo ";//10 nomedo estado con letra 
                        Mi_SQL += ", pais ";//11 pais
                        //Mi_SQL += ", tel1 ";//12 tel1
                        Mi_SQL += ", fechamov ";//13 fechamov
                        Mi_SQL += ", numnota ";//14 numnota default 1
                        Mi_SQL += ", ano ";//15 ano default 0
                        Mi_SQL += ", tipom ";//16 tipom default 1
                        Mi_SQL += ", maquina ";//17 maquina 
                        Mi_SQL += ", captura ";//18 captura 
                        Mi_SQL += ", hora ";//19 hora
                        Mi_SQL += ", user ";//20 user
                        Mi_SQL += ", nomcalle ";//21 nomcalle
                        Mi_SQL += ")";
                        Mi_SQL += " values ";
                        Mi_SQL += "(";
                        Mi_SQL += "'" + Datos.P_Rfc + "'";//1 curp
                        Mi_SQL += ", '0'";//2 numcalle valor por default 0 
                        Mi_SQL += ", '" + Datos.P_Numero_Exterior + "'";//3 numext 
                        Mi_SQL += ", '" + Datos.P_Numero_Interior + "'";//4 numint
                        Mi_SQL += ", '0'";//5 numcol valor default 0
                        Mi_SQL += ", '" + Datos.P_Colonia + "'";//6 nomcol valor ''
                        Mi_SQL += ", '" + Datos.P_Codigo_Postal + "'";// 7 cp
                        Mi_SQL += ", '" + Datos.P_Municipio + "'";//8 ciudad
                        Mi_SQL += ", '10'";//9 edo en numero
                        Mi_SQL += ", '" + Datos.P_Estado + "'";//10 nomedo estado con letra 
                        Mi_SQL += ", 'MEXICO'";//11 pais
                        //Mi_SQL += ", '" + "'";//12 tel1
                        Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//13 fechamov
                        Mi_SQL += ", '1'";//14 numnota default 1
                        Mi_SQL += ", '0'";//15 ano default 0
                        Mi_SQL += ", '1'";//16 tipom default 1   
                        Mi_SQL += ", '" + Datos.P_Equipo + "'";//17 maquina 
                        Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//18 captura 
                        Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//19 hora
                        Mi_SQL += ", '" + Datos.P_Usuario + "'";//20 user
                        Mi_SQL += ", '" + Datos.P_Calle + "'";//21 nomcalle
                        Mi_SQL += ")";

                        Cmd.Connection = MyConnection;
                        Cmd.CommandText = Mi_SQL;
                        Cmd.ExecuteNonQuery();

                        MyConnection.Close();
                    }
                    #endregion
                }
                ///////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////
                else
                {
                    #region version 5

                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";

                    }

                    Obj_Conexion = new MySqlConnection(StrConexion);
                    Obj_Conexion.Open();

                    Obj_Transaccion = Obj_Conexion.BeginTransaction();
                    Comando_Mysql.Connection = Obj_Conexion;
                    Comando_Mysql.Transaction = Obj_Transaccion;
                    Comando_Mysql.CommandType = CommandType.Text;
                    /////////////////////////////////////////////////////////////////

                    Mi_SQL = "INSERT INTO " + Cat_Padron.Tabla + "(";
                    Mi_SQL += Cat_Padron.Campo_Curp;//  1
                    Mi_SQL += ", " + Cat_Padron.Campo_Rfc;//    2
                    Mi_SQL += ", " + Cat_Padron.Campo_Tipo;//   3
                    Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Paterno;//   4
                    Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Materno;//   5
                    Mi_SQL += ", " + Cat_Padron.Campo_Nombre;// 6
                    Mi_SQL += ", " + Cat_Padron.Campo_Edonac;// 7
                    Mi_SQL += ", " + Cat_Padron.Campo_Fecha_Nacimiento;//   8
                    Mi_SQL += ", " + Cat_Padron.Campo_Genero;// 9
                    Mi_SQL += ", " + Cat_Padron.Campo_Consecutivo;//    10
                    Mi_SQL += ", " + Cat_Padron.Campo_Maquina;//    11
                    Mi_SQL += ", " + Cat_Padron.Campo_Captura;//    12
                    Mi_SQL += ", " + Cat_Padron.Campo_Hora;//   13
                    Mi_SQL += ", " + Cat_Padron.Campo_Usuario;//    14
                    Mi_SQL += ", " + Cat_Padron.Campo_Baja;// 15
                    Mi_SQL += ", " + Cat_Padron.Campo_Interno1;//   16
                    //Mi_SQL += ", " + Cat_Padron.Campo_Calle;//   17
                    //Mi_SQL += ", " + Cat_Padron.Campo_No_Interno;//   18
                    //Mi_SQL += ", " + Cat_Padron.Campo_No_Exterior;//   19
                    //Mi_SQL += ", " + Cat_Padron.Campo_Colonia;//   20
                    //Mi_SQL += ", " + Cat_Padron.Campo_Municipio;//   21
                    //Mi_SQL += ", " + Cat_Padron.Campo_Estado;//   22
                    //Mi_SQL += ", " + Cat_Padron.Campo_Codigo_Postal;//   23
                    Mi_SQL += ")";
                    Mi_SQL += " values ";
                    Mi_SQL += "(";
                    Mi_SQL += "'" + Datos.P_Curp + "'";//   1
                    Mi_SQL += ", '" + Datos.P_Rfc + "'";//  2
                    Mi_SQL += ", '" + Datos.P_Tipo + "'";// 3
                    Mi_SQL += ", '" + Datos.P_Apellido_Paterno + "'";// 4
                    Mi_SQL += ", '" + Datos.P_Apellido_Materno + "'";// 5
                    Mi_SQL += ", '" + Datos.P_Nombre + "'";//   6
                    Mi_SQL += ", '0'"; //   edonac  default "0"// 7
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//  8
                    Mi_SQL += ", '" + Datos.P_Genero + "'";//   9
                    Mi_SQL += ", '0'";// consecutivo //   10
                    Mi_SQL += ", '" + Datos.P_Equipo + "'";//   11
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//  12
                    Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//   13
                    Mi_SQL += ", '" + Datos.P_Usuario + "'";//  14
                    Mi_SQL += ", ''";// Baja //   15
                    Mi_SQL += ", 'N'"; //   interno1  default "N"// 16
                    //Mi_SQL += ", '" + Datos.P_Calle + "'";// 17
                    //Mi_SQL += ", '" + Datos.P_Numero_Interior + "'";// 18
                    //Mi_SQL += ", '" + Datos.P_Numero_Exterior + "'";// 19
                    //Mi_SQL += ", '" + Datos.P_Colonia + "'";// 20
                    //Mi_SQL += ", '" + Datos.P_Municipio + "'";// 21
                    //Mi_SQL += ", '" + Datos.P_Estado + "'";// 22
                    //Mi_SQL += ", '" + Datos.P_Codigo_Postal + "'";// 23
                    Mi_SQL += ")";
                    Comando_Mysql.CommandText = Mi_SQL;
                    Comando_Mysql.ExecuteNonQuery();

                    //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES
                    Mi_SQL = "insert into listdeudor ";
                    Mi_SQL += "(";
                    Mi_SQL += "tipo";//  1
                    Mi_SQL += ", lista";//   2
                    Mi_SQL += ", curp";//    3
                    Mi_SQL += ", tipol";//   4
                    Mi_SQL += ", referencia1";// 5
                    Mi_SQL += ", referencia2";// 6
                    Mi_SQL += ", registro";//    7
                    Mi_SQL += ", baja";//   8
                    Mi_SQL += ", userr";//  9
                    //Mi_SQL += ", userb";//    10
                    Mi_SQL += ", clave";//  11
                    Mi_SQL += ", cantidad";//   12
                    Mi_SQL += ", observa";//   13
                    Mi_SQL += ", cantidad2";//   14
                    Mi_SQL += ", interno1";//   15
                    Mi_SQL += ", conse";//   16
                    Mi_SQL += ", conspalm";//   17
                    Mi_SQL += ", conspalm2";//   18
                    Mi_SQL += ")";
                    Mi_SQL += " values ";
                    Mi_SQL += "(";
                    Mi_SQL += "'" + Datos.P_Tipo_Lista_Deudor + "'";//  1
                    Mi_SQL += ", '" + Datos.P_Lista_Deudor + "'";//    2
                    Mi_SQL += ", '" + Datos.P_Rfc + "'";//    3
                    Mi_SQL += ", '0'";//    4
                    Mi_SQL += ", 'VENTA DE BOLETOS'";//    5
                    Mi_SQL += ", 'MUSEO DE MOMIAS'";//    6
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//    7
                    Mi_SQL += ", '1900-01-01'";//    8
                    Mi_SQL += ", '" + Datos.P_Usuario + "'";//    9
                    //Mi_SQL += ", '" + "'";//    10
                    Mi_SQL += ", '" + Datos.P_Dt_Parametros.Rows[0][Cat_Parametros.Campo_Clave_Venta_Individual_Deudorcad].ToString() + "'";//    11
                    Mi_SQL += ", '1'";//    12
                    Mi_SQL += ", 'ENTRADA MUSEO MOMIAS'";//    13
                    Mi_SQL += ", '0'";//    14
                    Mi_SQL += ", 'N'";//    15
                    Mi_SQL += ", '0'";//    16
                    Mi_SQL += ", '0'";//    17
                    Mi_SQL += ", '0'";//    18
                    Mi_SQL += ")";
                    Comando_Mysql.CommandText = Mi_SQL;
                    Comando_Mysql.ExecuteNonQuery();

                    //  se ingresa la informacion de la direccion del usuario
                    Mi_SQL = "insert into movtos ";
                    Mi_SQL += "(";
                    Mi_SQL += " curp ";//1 curp
                    Mi_SQL += ", numcalle ";//2 numcalle valor por default 0 
                    Mi_SQL += ", numext ";//3 numext 
                    Mi_SQL += ", numint ";//4 numint
                    Mi_SQL += ", numcol ";//5 numcol valor default 0
                    Mi_SQL += ", nomcol ";//6 nomcol valor ''
                    Mi_SQL += ", cp ";//7 cp 
                    Mi_SQL += ", ciudad ";//8 ciudad
                    Mi_SQL += ", edo ";//9 edo en numero
                    Mi_SQL += ", nomedo ";//10 nomedo estado con letra 
                    Mi_SQL += ", pais ";//11 pais
                    //Mi_SQL += ", tel1 ";//12 tel1
                    Mi_SQL += ", fechamov ";//13 fechamov
                    Mi_SQL += ", numnota ";//14 numnota default 1
                    Mi_SQL += ", ano ";//15 ano default 0
                    Mi_SQL += ", tipom ";//16 tipom default 1
                    Mi_SQL += ", maquina ";//17 maquina 
                    Mi_SQL += ", captura ";//18 captura 
                    Mi_SQL += ", hora ";//19 hora
                    Mi_SQL += ", user ";//20 user
                    Mi_SQL += ", nomcalle ";//21 nomcalle
                    Mi_SQL += ")";
                    Mi_SQL += " values ";
                    Mi_SQL += "(";
                    Mi_SQL += "'" + Datos.P_Rfc + "'";//1 curp
                    Mi_SQL += ", '0'";//2 numcalle valor por default 0 
                    Mi_SQL += ", '" + Datos.P_Numero_Exterior + "'";//3 numext 
                    Mi_SQL += ", '" + Datos.P_Numero_Interior + "'";//4 numint
                    Mi_SQL += ", '0'";//5 numcol valor default 0
                    Mi_SQL += ", '" + Datos.P_Colonia + "'";//6 nomcol valor ''
                    Mi_SQL += ", '" + Datos.P_Codigo_Postal + "'";// 7 cp
                    Mi_SQL += ", '" + Datos.P_Municipio + "'";//8 ciudad
                    Mi_SQL += ", '10'";//9 edo en numero
                    Mi_SQL += ", '" + Datos.P_Estado + "'";//10 nomedo estado con letra 
                    Mi_SQL += ", 'MEXICO'";//11 pais
                    //Mi_SQL += ", '" + "'";//12 tel1
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//13 fechamov
                    Mi_SQL += ", '1'";//14 numnota default 1
                    Mi_SQL += ", '0'";//15 ano default 0
                    Mi_SQL += ", '1'";//16 tipom default 1   
                    Mi_SQL += ", '" + Datos.P_Equipo + "'";//17 maquina 
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//18 captura 
                    Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//19 hora
                    Mi_SQL += ", '" + Datos.P_Usuario + "'";//20 user
                    Mi_SQL += ", '" + Datos.P_Calle + "'";//21 nomcalle
                    Mi_SQL += ")";
                    Comando_Mysql.CommandText = Mi_SQL;
                    Comando_Mysql.ExecuteNonQuery();

                    Obj_Transaccion.Commit();
                    Obj_Conexion.Close();// version 5
                    //////////////////////////////////////////////////////
                    #endregion
                }

                Accion_Completa = true;
            }
            catch (Exception E)
            {
                //Obj_Transaccion.Rollback();
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Usuario_Padron: " + E.Message);
            }
            finally
            {
                //Conexion.HelperGenerico.Cerrar_Conexion();
                //Obj_Conexion.Close();// version 5
            }
            return Accion_Completa;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuario_List_Deudro
        ///DESCRIPCIÓN          : inserta el valor de los usuarios
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 27 Maya 2015
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static Boolean Alta_Usuario_List_Deudro(Cls_Cat_Padron_Negocio Datos)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Boolean Accion_Completa = false;
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand(); ;
            
            try
            {
                 //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                Consulta_Parametros.P_Parametro_Id =  "00001";
                DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

               //   validacion para la version 4 de base de datos
                if (Dt_Consulta.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                {
                    #region Version odbc
                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                        StrConexion += "OPTION=3";

                    }


                    using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))

                    using (OdbcCommand Cmd = new OdbcCommand())
                    {
                        MyConnection.Open();

                        Mi_SQL = "insert into listdeudor ";
                        Mi_SQL += "(";
                        Mi_SQL += "tipo";//  1
                        Mi_SQL += ", lista";//   2
                        Mi_SQL += ", curp";//    3
                        Mi_SQL += ", tipol";//   4
                        Mi_SQL += ", referencia1";// 5
                        Mi_SQL += ", referencia2";// 6
                        Mi_SQL += ", registro";//    7
                        Mi_SQL += ", baja";//   8
                        Mi_SQL += ", userr";//  9
                        //Mi_SQL += ", userb";//    10
                        Mi_SQL += ", clave";//  11
                        Mi_SQL += ", cantidad";//   12
                        Mi_SQL += ", observa";//   13
                        Mi_SQL += ", cantidad2";//   14
                        Mi_SQL += ", interno1";//   15
                        Mi_SQL += ", conse";//   16
                        Mi_SQL += ", conspalm";//   17
                        Mi_SQL += ", conspalm2";//   18
                        Mi_SQL += ")";
                        Mi_SQL += " values ";
                        Mi_SQL += "(";
                        Mi_SQL += "'" + Datos.P_Tipo_Lista_Deudor + "'";//  1
                        Mi_SQL += ", '" + Datos.P_Lista_Deudor + "'";//    2
                        Mi_SQL += ", '" + Datos.P_Rfc + "'";//    3
                        Mi_SQL += ", '0'";//    4
                        Mi_SQL += ", 'VENTA DE BOLETOS'";//    5
                        Mi_SQL += ", 'MUSEO DE MOMIAS'";//    6
                        Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//    7
                        Mi_SQL += ", '1900-01-01'";//    8
                        Mi_SQL += ", '" + Datos.P_Usuario + "'";//    9
                        //Mi_SQL += ", '" + "'";//    10
                        Mi_SQL += ", '" + Datos.P_Clave_Venta_Individual + "'";//    11
                        Mi_SQL += ", '1'";//    12
                        Mi_SQL += ", 'ENTRADA MUSEO MOMIAS'";//    13
                        Mi_SQL += ", '0'";//    14
                        Mi_SQL += ", 'N'";//    15
                        Mi_SQL += ", '0'";//    16
                        Mi_SQL += ", '0'";//    17
                        Mi_SQL += ", '0'";//    18
                        Mi_SQL += ")";

                        Cmd.Connection = MyConnection;
                        Cmd.CommandText = Mi_SQL;
                        Cmd.ExecuteNonQuery();

                        MyConnection.Close();
                    }
                    #endregion
                }

                /////////////////////////////////////////////////////
                /////////////////////////////////////////////////////
                /////////////////////////////////////////////////////
                else
                {
                    #region Version 5
                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                    }

                    Obj_Conexion = new MySqlConnection(StrConexion);
                    Obj_Conexion.Open();

                    Obj_Transaccion = Obj_Conexion.BeginTransaction();
                    Comando_Mysql.Connection = Obj_Conexion;
                    Comando_Mysql.Transaction = Obj_Transaccion;
                    Comando_Mysql.CommandType = CommandType.Text;


                    ////  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES
                    Mi_SQL = "insert into listdeudor ";
                    Mi_SQL += "(";
                    Mi_SQL += "tipo";//  1
                    Mi_SQL += ", lista";//   2
                    Mi_SQL += ", curp";//    3
                    Mi_SQL += ", tipol";//   4
                    Mi_SQL += ", referencia1";// 5
                    Mi_SQL += ", referencia2";// 6
                    Mi_SQL += ", registro";//    7
                    Mi_SQL += ", baja";//   8
                    Mi_SQL += ", userr";//  9
                    //Mi_SQL += ", userb";//    10
                    Mi_SQL += ", clave";//  11
                    Mi_SQL += ", cantidad";//   12
                    Mi_SQL += ", observa";//   13
                    Mi_SQL += ", cantidad2";//   14
                    Mi_SQL += ", interno1";//   15
                    Mi_SQL += ", conse";//   16
                    Mi_SQL += ", conspalm";//   17
                    Mi_SQL += ", conspalm2";//   18
                    Mi_SQL += ")";
                    Mi_SQL += " values ";
                    Mi_SQL += "(";
                    Mi_SQL += "'" + Datos.P_Tipo_Lista_Deudor + "'";//  1
                    Mi_SQL += ", '" + Datos.P_Lista_Deudor + "'";//    2
                    Mi_SQL += ", '" + Datos.P_Rfc + "'";//    3
                    Mi_SQL += ", '0'";//    4
                    Mi_SQL += ", 'VENTA DE BOLETOS'";//    5
                    Mi_SQL += ", 'MUSEO DE MOMIAS'";//    6
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//    7
                    Mi_SQL += ", '1900-01-01'";//    8
                    Mi_SQL += ", '" + Datos.P_Usuario + "'";//    9
                    //Mi_SQL += ", '" + "'";//    10
                    Mi_SQL += ", '" + Datos.P_Clave_Venta_Individual + "'";//    11
                    Mi_SQL += ", '1'";//    12
                    Mi_SQL += ", 'ENTRADA MUSEO MOMIAS'";//    13
                    Mi_SQL += ", '0'";//    14
                    Mi_SQL += ", 'N'";//    15
                    Mi_SQL += ", '0'";//    16
                    Mi_SQL += ", '0'";//    17
                    Mi_SQL += ", '0'";//    18
                    Mi_SQL += ")";

                    Comando_Mysql.CommandText = Mi_SQL;
                    Comando_Mysql.ExecuteNonQuery();

                    Obj_Transaccion.Commit();
                    Obj_Conexion.Close();
                    #endregion
                }
                Accion_Completa = true;


            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Pago: " + E.Message);
            }
            finally
            {
                //Conexion.HelperGenerico.Cerrar_Conexion();
                //Obj_Conexion.Close();
            }
            return Accion_Completa;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuario_List_Deudro
        ///DESCRIPCIÓN          : inserta el valor de los usuarios
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 27 Maya 2015
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static Boolean Alta_Usuario_List_Deudro_Local(Cls_Cat_Padron_Negocio Datos)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Boolean Accion_Completa = false;
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand(); ;
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
                
                //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES
                Mi_SQL = "insert into listdeudor ";
                Mi_SQL += "(";
                Mi_SQL += "tipo";//  1
                Mi_SQL += ", lista";//   2
                Mi_SQL += ", curp";//    3
                Mi_SQL += ", tipol";//   4
                Mi_SQL += ", referencia1";// 5
                Mi_SQL += ", referencia2";// 6
                Mi_SQL += ", registro";//    7
                Mi_SQL += ", baja";//   8
                Mi_SQL += ", userr";//  9
                //Mi_SQL += ", userb";//    10
                Mi_SQL += ", clave";//  11
                Mi_SQL += ", cantidad";//   12
                Mi_SQL += ", observa";//   13
                Mi_SQL += ", cantidad2";//   14
                Mi_SQL += ", interno1";//   15
                Mi_SQL += ", conse";//   16
                Mi_SQL += ", conspalm";//   17
                Mi_SQL += ", conspalm2";//   18
                Mi_SQL += ")";
                Mi_SQL += " values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Datos.P_Tipo_Lista_Deudor + "'";//  1
                Mi_SQL += ", '" + Datos.P_Lista_Deudor + "'";//    2
                Mi_SQL += ", '" + Datos.P_Rfc + "'";//    3
                Mi_SQL += ", '0'";//    4
                Mi_SQL += ", 'VENTA DE BOLETOS'";//    5
                Mi_SQL += ", 'MUSEO DE MOMIAS'";//    6
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";//    7
                Mi_SQL += ", '1900-01-01'";//    8
                Mi_SQL += ", '" + Datos.P_Usuario + "'";//    9
                //Mi_SQL += ", '" + "'";//    10
                Mi_SQL += ", '" + Datos.P_Clave_Venta_Individual + "'";//    11
                Mi_SQL += ", '1'";//    12
                Mi_SQL += ", 'ENTRADA MUSEO MOMIAS'";//    13
                Mi_SQL += ", '0'";//    14
                Mi_SQL += ", 'N'";//    15
                Mi_SQL += ", '0'";//    16
                Mi_SQL += ", '0'";//    17
                Mi_SQL += ", '0'";//    18
                Mi_SQL += ")";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //  se ingresa la informacion del movimiento en la tabla de los detalles
                Mi_SQL = "insert into ope_historico_padron";
                Mi_SQL += "(";
                Mi_SQL += "Curp_Rfc";
                Mi_SQL += ", Operacion";
                Mi_SQL += ", Fecha";
                Mi_SQL += ")";
                Mi_SQL += " Values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Datos.P_Rfc + "'";
                Mi_SQL += ", 'INSERCION_LISTA'";
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                Mi_SQL += ")";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //  terminar transaccion y ejecutar las inserciones
                Conexion.HelperGenerico.Terminar_Transaccion();


                Accion_Completa = true;
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_list_Local: " + E.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Accion_Completa;
        }

       

         ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Usuario_Padron
        ///DESCRIPCIÓN          : actualizacion de la informacion del usuario
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static Boolean Modificar_Usuario_Padron(Cls_Cat_Padron_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Boolean Accion_Completa = false;
            Boolean Filtros = false; 
            String Rfc_Curp = "";

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
                
                
                Mi_SQL = "UPDATE " + Cat_Padron.Tabla + " SET ";

                if (!String.IsNullOrEmpty(Datos.P_Curp))
                {
                    Mi_SQL += Cat_Padron.Campo_Curp + "= '" + Datos.P_Curp + "'";//  1
                    Filtros = true;
                }

                if (!String.IsNullOrEmpty(Datos.P_Rfc))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Rfc + "= '" + Datos.P_Rfc + "'";//  2 
                    Filtros = true;
                }

                if (!String.IsNullOrEmpty(Datos.P_Tipo))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Tipo + "= '" + Datos.P_Tipo + "'";//  3
                    Filtros = true;
                }

                if (!String.IsNullOrEmpty(Datos.P_Apellido_Paterno))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Apellido_Paterno + "= '" + Datos.P_Apellido_Paterno + "'";//  4
                    Filtros = true;
                }

                if (!String.IsNullOrEmpty(Datos.P_Apellido_Materno))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Apellido_Materno + "= '" + Datos.P_Apellido_Materno + "'";//  5
                    Filtros = true;
                }

                if (!String.IsNullOrEmpty(Datos.P_Nombre))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Nombre + "= '" + Datos.P_Nombre + "'";//  6
                    Filtros = true;
                }

                if (!String.IsNullOrEmpty(Datos.P_Genero))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Genero + "= '" + Datos.P_Genero + "'";//  7
                    Filtros = true;
                }

                if (!String.IsNullOrEmpty(Datos.P_Estatus))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Baja + "= '" + Datos.P_Estatus + "'";//  8
                    Filtros = true;
                }

                //  calle
                if (!String.IsNullOrEmpty(Datos.P_Calle))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Calle + "= '" + Datos.P_Calle + "'";//  8
                    Filtros = true;
                }  
                //  numero_interior
                if (!String.IsNullOrEmpty(Datos.P_Numero_Interior))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_No_Interno + "= '" + Datos.P_Numero_Interior + "'";//  8
                    Filtros = true;
                }
                //  numero_exterior
                if (!String.IsNullOrEmpty(Datos.P_Numero_Exterior))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_No_Exterior + "= '" + Datos.P_Numero_Exterior + "'";//  8
                    Filtros = true;
                }
                //  codigo postal
                if (!String.IsNullOrEmpty(Datos.P_Codigo_Postal))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Codigo_Postal + "= '" + Datos.P_Codigo_Postal + "'";//  8
                    Filtros = true;
                }
                //  colonia
                if (!String.IsNullOrEmpty(Datos.P_Colonia   ))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Colonia + "= '" + Datos.P_Colonia + "'";//  8
                    Filtros = true;
                }
                //  municipio
                if (!String.IsNullOrEmpty(Datos.P_Municipio))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Municipio + "= '" + Datos.P_Municipio + "'";//  8
                    Filtros = true;
                }
                //  municipio
                if (!String.IsNullOrEmpty(Datos.P_Estado))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Estado + "= '" + Datos.P_Estado + "'";//  8
                    Filtros = true;
                }

                //  seccion where ********************************************************************************************************
                Mi_SQL += " where " + Cat_Padron.Campo_Curp + "= '" + Datos.P_Curp + "'";


                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());


                Rfc_Curp = (!String.IsNullOrEmpty(Datos.P_Rfc)) ? Datos.P_Rfc : Datos.P_Curp;

                //  se ingresa la informacion del movimiento en la tabla de los detalles
                Mi_SQL = "insert into ope_historico_padron";
                Mi_SQL += "(";
                Mi_SQL += "Curp_Rfc";
                Mi_SQL += ", Operacion";
                Mi_SQL += ", Fecha";
                Mi_SQL += ")";
                Mi_SQL += " Values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Rfc_Curp + "'";
                Mi_SQL += ", 'ACTUALIZACION'";
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                Mi_SQL += ")";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());



                //  terminar transaccion y ejecutar las inserciones
                Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Usuario_Padron: " + E.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Accion_Completa;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Usuario_Padron
        ///DESCRIPCIÓN          : actualizacion de la informacion del usuario
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 11 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static Boolean Eliminar_Usuario_Padron(Cls_Cat_Padron_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Boolean Accion_Completa = false;
            Boolean Filtros = false;
            String Rfc_Curp = "";

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


                Mi_SQL = "UPDATE " + Cat_Padron.Tabla + " SET ";

                if (!String.IsNullOrEmpty(Datos.P_Estatus))
                {
                    if (Filtros == true) Mi_SQL += ", ";
                    Mi_SQL += Cat_Padron.Campo_Baja + "= '" + Datos.P_Estatus + "'";//  8
                    Filtros = true;
                }


                //  seccion where
                if (!String.IsNullOrEmpty(Datos.P_Curp))
                    Mi_SQL += " where " + Cat_Padron.Campo_Curp + "= '" + Datos.P_Curp + "'";
                else
                    Mi_SQL += " where " + Cat_Padron.Campo_Rfc + "= '" + Datos.P_Rfc + "'";



                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());


                Rfc_Curp = (!String.IsNullOrEmpty(Datos.P_Rfc)) ? Datos.P_Rfc : Datos.P_Curp;

                //  se ingresa la informacion del movimiento en la tabla de los detalles
                Mi_SQL = "insert into ope_historico_padron";
                Mi_SQL += "(";
                Mi_SQL += "Curp_Rfc";
                Mi_SQL += ", Operacion";
                Mi_SQL += ", Fecha";
                Mi_SQL += ")";
                Mi_SQL += " Values ";
                Mi_SQL += "(";
                Mi_SQL += "'" + Rfc_Curp + "'";
                Mi_SQL += ", 'ACTUALIZACION'";
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                Mi_SQL += ")";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());



                //  terminar transaccion y ejecutar las inserciones
                Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Usuario_Padron: " + E.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Accion_Completa;
        }
        #endregion

        #region Consultas
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Padron
        ///DESCRIPCIÓN          : Consulta los bancos registrados en la base de datos
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Marzo 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Padron(Cls_Cat_Padron_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Estatus_Consulta = false;
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Parametros = new DataTable();

            try
            {
                 //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                Consulta_Parametros.P_Parametro_Id =  "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();



                //   validacion para la version 4 de base de datos
                if (Dt_Parametros.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                {
                    #region Version odbc
                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                        StrConexion += "OPTION=3";
                    }

                    using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))
                    {

                        using (OdbcCommand Cmd = new OdbcCommand())
                        {
                            MyConnection.Open();

                            Mi_SQL.Append("SELECT " + Cat_Padron.Tabla + "." + "* ");
                            Mi_SQL.Append(", nomcalle");
                            Mi_SQL.Append(", numint");
                            Mi_SQL.Append(", numext");
                            Mi_SQL.Append(", cp");
                            Mi_SQL.Append(", nomcol");
                            Mi_SQL.Append(", ciudad");
                            Mi_SQL.Append(", nomedo");
                            Mi_SQL.Append(", nomedo");
                            Mi_SQL.Append(" FROM " + Cat_Padron.Tabla);
                            Mi_SQL.Append(" left outer join movtos on movtos.curp = " + Cat_Padron.Tabla + "." + Cat_Padron.Campo_Curp);

                            //  seccion where
                            //  filtro para el curp
                            if (!String.IsNullOrEmpty(Datos.P_Rfc))
                            {
                                if (Estatus_Consulta == true)
                                    Mi_SQL.Append(" And ");
                                else
                                    Mi_SQL.Append(" where ");

                                Mi_SQL.Append(" (");
                                Mi_SQL.Append(Cat_Padron.Campo_Rfc + " like  ('" + Datos.P_Rfc + "%')");
                                Mi_SQL.Append(" or " + Cat_Padron.Tabla + "." + Cat_Padron.Campo_Curp + " like  ('" + Datos.P_Rfc + "%')");
                                Mi_SQL.Append(" )");
                                Estatus_Consulta = true;
                            }

                            //  filtro para el nombre (Apellido parterno, apellido materno, nombre)
                            if (!String.IsNullOrEmpty(Datos.P_Nombre))
                            {
                                if (Estatus_Consulta == true)
                                    Mi_SQL.Append(" And ");
                                else
                                    Mi_SQL.Append(" where ");

                                //Mi_SQL.Append(" CONCAT (" + Cat_Padron.Campo_Apellido_Paterno + ", ' ' ," + Cat_Padron.Campo_Apellido_Materno + ", ' ' ," + Cat_Padron.Campo_Nombre + ")" + " like  ('" + Datos.P_Nombre + "%')");
                                Mi_SQL.Append(" nombre " + " like  ('" + Datos.P_Nombre + "%')");
                                Mi_SQL.Append(" COLLATE latin1_general_ci");

                                Estatus_Consulta = true;
                            }


                            Cmd.Connection = MyConnection;
                            Cmd.CommandText = Mi_SQL.ToString();

                            using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                            {
                                Adap.SelectCommand = Cmd;
                                Adap.Fill(Dt_Consulta);
                            }


                            MyConnection.Close();
                        }
                    }
                    #endregion version 4
                }
                ///////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////
                else
                {
                    #region version 5

                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                    }

                    Obj_Conexion = new MySqlConnection(StrConexion);
                    Obj_Conexion.Open();

                    Obj_Transaccion = Obj_Conexion.BeginTransaction();
                    Comando_Mysql.Connection = Obj_Conexion;
                    Comando_Mysql.Transaction = Obj_Transaccion;
                    Comando_Mysql.CommandType = CommandType.Text;
                    Comando_Mysql.CommandTimeout = 10000;

                    Mi_SQL.Append("SELECT " + Cat_Padron.Tabla + "." + "* ");
                    Mi_SQL.Append(", nomcalle");
                    Mi_SQL.Append(", numint");
                    Mi_SQL.Append(", numext");
                    Mi_SQL.Append(", cp");
                    Mi_SQL.Append(", nomcol");
                    Mi_SQL.Append(", ciudad");
                    Mi_SQL.Append(", nomedo");
                    Mi_SQL.Append(", nomedo");

                    Mi_SQL.Append(" FROM " + Cat_Padron.Tabla);


                    Mi_SQL.Append(" left outer join movtos on movtos.curp = " + Cat_Padron.Tabla + "." + Cat_Padron.Campo_Curp);


                    //  seccion where
                    //  filtro para el curp
                    if (!String.IsNullOrEmpty(Datos.P_Rfc))
                    {
                        if (Estatus_Consulta == true)
                            Mi_SQL.Append(" And ");
                        else
                            Mi_SQL.Append(" where ");

                        Mi_SQL.Append(" (");
                        Mi_SQL.Append(Cat_Padron.Campo_Rfc + " like  ('" + Datos.P_Rfc + "%')");
                        Mi_SQL.Append(" or " + Cat_Padron.Tabla + "." + Cat_Padron.Campo_Curp + " like  ('" + Datos.P_Rfc + "%')");
                        Mi_SQL.Append(" )");
                        Estatus_Consulta = true;
                    }

                    //  filtro para el nombre (Apellido parterno, apellido materno, nombre)
                    if (!String.IsNullOrEmpty(Datos.P_Nombre))
                    {
                        if (Estatus_Consulta == true)
                            Mi_SQL.Append(" And ");
                        else
                            Mi_SQL.Append(" where ");

                        Mi_SQL.Append(" CONCAT (" + Cat_Padron.Campo_Apellido_Paterno + ", ' ' ," + Cat_Padron.Campo_Apellido_Materno + ", ' ' ," + Cat_Padron.Campo_Nombre + ")" + " like  ('" + Datos.P_Nombre + "%')");

                        Estatus_Consulta = true;
                    }

                    Comando_Mysql.CommandText = Mi_SQL.ToString();
                    MySqlDataReader Reader = Comando_Mysql.ExecuteReader();

                    Dt_Consulta.Load(Reader);
                    #endregion Version 5
                }
                
                return Dt_Consulta;
                
                //return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consulta de Padron : " + e.Message);
            }
            finally
            {
                //Obj_Conexion.Close();
                //Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Padron
        ///DESCRIPCIÓN          : Consulta los bancos registrados en la base de datos
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 10 Marzo 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Padron_Local(Cls_Cat_Padron_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Estatus_Consulta = false;
            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("SELECT " + Cat_Padron.Tabla + "." + "* ");
                Mi_SQL.Append(", nomcalle");
                Mi_SQL.Append(", numint");
                Mi_SQL.Append(", numext");
                Mi_SQL.Append(", cp");
                Mi_SQL.Append(", nomcol");
                Mi_SQL.Append(", ciudad");
                Mi_SQL.Append(", nomedo");
                Mi_SQL.Append(", nomedo");

                Mi_SQL.Append(" FROM " + Cat_Padron.Tabla);


                Mi_SQL.Append(" left outer join movtos on movtos.curp = " + Cat_Padron.Tabla + "." + Cat_Padron.Campo_Curp);


                //  seccion where
                //  filtro para el curp
                if (!String.IsNullOrEmpty(Datos.P_Rfc))
                {
                    if (Estatus_Consulta == true)
                        Mi_SQL.Append(" And ");
                    else
                        Mi_SQL.Append(" where ");

                    Mi_SQL.Append(" (");
                    Mi_SQL.Append(Cat_Padron.Campo_Rfc + " like  ('" + Datos.P_Rfc + "%')");
                    Mi_SQL.Append(" or " + Cat_Padron.Tabla + "." + Cat_Padron.Campo_Curp + " like  ('" + Datos.P_Rfc + "%')");
                    Mi_SQL.Append(" )");
                    Estatus_Consulta = true;
                }

                //  filtro para el nombre (Apellido parterno, apellido materno, nombre)
                if (!String.IsNullOrEmpty(Datos.P_Nombre))
                {
                    if (Estatus_Consulta == true)
                        Mi_SQL.Append(" And ");
                    else
                        Mi_SQL.Append(" where ");

                    Mi_SQL.Append(" CONCAT (" + Cat_Padron.Campo_Apellido_Paterno + ", ' ' ," + Cat_Padron.Campo_Apellido_Materno + ", ' ' ," + Cat_Padron.Campo_Nombre + ")" + " like  ('" + Datos.P_Nombre + "%')");

                    Estatus_Consulta = true;
                }


                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consulta de Padron : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Rfc_Duplicado
        ///DESCRIPCIÓN          : Consulta los bancos registrados en la base de datos
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Rfc_Duplicado(Cls_Cat_Padron_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Estatus_Consulta = false; 
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Parametros = new DataTable();

            try
            {
                 //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                Consulta_Parametros.P_Parametro_Id =  "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                //   validacion para la version 4 de base de datos
                if (Dt_Parametros.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                {
                    #region Version odbc
                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                        StrConexion += "OPTION=3";
                    }


                    using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))
                    {
                        using (OdbcCommand Cmd = new OdbcCommand())
                        {
                            MyConnection.Open();

                            Mi_SQL.Append("SELECT * FROM " + Cat_Padron.Tabla);

                            //  filtro para el curp
                            if (!String.IsNullOrEmpty(Datos.P_Rfc))
                            {
                                if (Estatus_Consulta == true)
                                    Mi_SQL.Append(" And ");
                                else
                                    Mi_SQL.Append(" where ");

                                Mi_SQL.Append(" (");
                                Mi_SQL.Append(Cat_Padron.Campo_Rfc + " =  '" + Datos.P_Rfc + "'");
                                Mi_SQL.Append(" )");
                                Estatus_Consulta = true;
                            }

                            Cmd.Connection = MyConnection;
                            Cmd.CommandText = Mi_SQL.ToString();

                            using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                            {
                                Adap.SelectCommand = Cmd;
                                Adap.Fill(Dt_Consulta);
                            }

                            MyConnection.Close();
                        }
                    }
                    #endregion version odbc
                }
                //////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////
                else
                {
                    #region version 5
                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                    }

                    Obj_Conexion = new MySqlConnection(StrConexion);
                    Obj_Conexion.Open();

                    Obj_Transaccion = Obj_Conexion.BeginTransaction();
                    Comando_Mysql.Connection = Obj_Conexion;
                    Comando_Mysql.Transaction = Obj_Transaccion;
                    Comando_Mysql.CommandType = CommandType.Text;
                    ///////////////////////////////////////////////////////////////

                    Mi_SQL.Append("SELECT * FROM " + Cat_Padron.Tabla);

                    //  filtro para el curp
                    if (!String.IsNullOrEmpty(Datos.P_Rfc))
                    {
                        if (Estatus_Consulta == true)
                            Mi_SQL.Append(" And ");
                        else
                            Mi_SQL.Append(" where ");

                        Mi_SQL.Append(" (");
                        Mi_SQL.Append(Cat_Padron.Campo_Rfc + " =  '" + Datos.P_Rfc + "'");
                        Mi_SQL.Append(" )");
                        Estatus_Consulta = true;
                    }


                    Comando_Mysql.CommandText = Mi_SQL.ToString();
                    MySqlDataReader Reader = Comando_Mysql.ExecuteReader();
                    Dt_Consulta.Load(Reader);
                    //////////////////////////////////////////////////////////////////
                    #endregion
                }

                return Dt_Consulta;

                //return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consulta de Padron : " + e.Message);
            }
            finally
            {
                //Obj_Conexion.Close();
                //Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Rfc_Duplicado
        ///DESCRIPCIÓN          : Consulta los bancos registrados en la base de datos
        ///PARÁMETROS           : Datos que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08 Abril 2015
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Rfc_Duplicado_Local(Cls_Cat_Padron_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Estatus_Consulta = false;
            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();


                Mi_SQL.Append("SELECT * FROM " + Cat_Padron.Tabla);

                //  filtro para el curp
                if (!String.IsNullOrEmpty(Datos.P_Rfc))
                {
                    if (Estatus_Consulta == true)
                        Mi_SQL.Append(" And ");
                    else
                        Mi_SQL.Append(" where ");

                    Mi_SQL.Append(" (");
                    Mi_SQL.Append(Cat_Padron.Campo_Rfc + " =  '" + Datos.P_Rfc + "'");
                    Mi_SQL.Append(" )");
                    Estatus_Consulta = true;
                }
                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consulta de Padron : " + e.Message);
            }
            finally
            {
                //Obj_Conexion.Close();
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
        #endregion
    }
}
