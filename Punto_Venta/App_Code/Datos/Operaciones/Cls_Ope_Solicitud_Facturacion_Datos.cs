using System;
using Erp_Solicitud_Facturacion.Negocio;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;
using Erp_Ope_Pagos.Negocio;
using Erp_Ope_Accesos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp_Ope_Impresiones.Negocio;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Erp_Apl_Parametros.Negocio;
using MySql.Data.MySqlClient;
using Erp.Seguridad;
using System.Data.Odbc;


namespace Erp_Solicitud_Facturacion.Datos
{
    class Cls_Ope_Solicitud_Facturacion_Datos
    {
        #region

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Insertar_Solicitud
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Solicitud_Catalogo_Listas(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;

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

                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo_Numerico("adeudos", "conse", " curp = '" + Datos.P_Cuenta_Momias + "'");

                String Nombre_Usuario = "";


                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;

                foreach (DataRow Registro in Datos.P_Dt_Ventas_Clasificacion.Rows)
                {
                    Mi_SQL = "INSERT INTO adeudos (";
                    Mi_SQL += "ano";
                    Mi_SQL += ", tipo";
                    Mi_SQL += ", lista";
                    Mi_SQL += ", curp";
                    Mi_SQL += ", clave";
                    Mi_SQL += ", fecha";
                    Mi_SQL += ", unidad";
                    //Mi_SQL += ", unidad2";
                    Mi_SQL += ", tarifa";
                    Mi_SQL += ", cantidad";
                    Mi_SQL += ", cantidad2";
                    Mi_SQL += ", importe";
                    Mi_SQL += ", saldo";
                    Mi_SQL += ", concepto";
                    Mi_SQL += ", concepto2";
                    Mi_SQL += ", referencia1";
                    Mi_SQL += ", referencia2";
                    Mi_SQL += ", referencia3";
                    //Mi_SQL += ", pagar";
                    Mi_SQL += ", impopago";
                    Mi_SQL += ", captura";
                    Mi_SQL += ", hora";
                    Mi_SQL += ", user";
                    Mi_SQL += ", maquina";
                    Mi_SQL += ", conse";
                    //Mi_SQL += ", requiere";
                    //Mi_SQL += ", origen";
                    Mi_SQL += ", porcond";
                    Mi_SQL += ", feccond";
                    //Mi_SQL += ", usercond";
                    //Mi_SQL += ", refcond";
                    Mi_SQL += ", hon1";
                    Mi_SQL += ", hon2";
                    Mi_SQL += ", hon3";
                    Mi_SQL += ", recargosm";
                    Mi_SQL += ", fec1";
                    Mi_SQL += ", fec2";
                    Mi_SQL += ", fec3";
                    Mi_SQL += ", fecham";
                    Mi_SQL += ")";
                    Mi_SQL += " VALUES (";//****************************************
                    Mi_SQL += "'" + DateTime.Now.ToString("yyyy") + "'";//1
                    Mi_SQL += ", '" + Datos.P_Tipo_Parametro + "'";//2 tipo
                    Mi_SQL += ", '" + Datos.P_Lista_Parametros + "'"; // lista 3
                    Mi_SQL += ", '" + Datos.P_Curp + "'";//    curp 4
                    Mi_SQL += ", '" + Registro["clave_venta_Lista"].ToString() + "'";//    clave del producto    5
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha   5
                    Mi_SQL += ", 'BOLETO'"; // unidad  6
                    Mi_SQL += ", '" + Registro["importe"].ToString() + "'";//   tarifa 7
                    Mi_SQL += ", '1'";// cantidad 8
                    Mi_SQL += ", '1'";  //  cantidad "2" 9
                    Mi_SQL += ", '" + Registro["importe"].ToString() + "'";//   importe 10
                    Mi_SQL += ", '0'";//    saldo   10
                    Mi_SQL += ", '.'";//    concepto 11
                    Mi_SQL += ", '" + Registro["concepto2"].ToString() + "'"; // concepto "2"    12
                    Mi_SQL += ", '" + Datos.P_Tipo + "'"; // referencia "1" 13
                    Mi_SQL += ", '" + Datos.P_Lista + "'";// referencia "2" 14
                    Mi_SQL += ", '" + Datos.P_Caja + Datos.P_Turno + DateTime.Now.ToString("ddMMyy") + " " + Datos.P_No_Venta + "'";// referencia "3" 15
                    Mi_SQL += ", '0'";//   impopago 16 
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha 17
                    Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 18
                    Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 19
                    Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 20
                    Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 21
                    Mi_SQL += ", '0'";// porcond 28
                    Mi_SQL += ", '1900-01-01'";// feccond 29
                    Mi_SQL += ", '0'";// hon1 32
                    Mi_SQL += ", '0'";// hon1 33
                    Mi_SQL += ", '0'";// hon1 34
                    Mi_SQL += ", '0'";// recargosm 35
                    Mi_SQL += ", '1900-01-01'";// fec1 36
                    Mi_SQL += ", '1900-01-01'";// fec2 37
                    Mi_SQL += ", '1900-01-01'";// fec2 38
                    Mi_SQL += ", '1900-01-01'";// fecham 39
                    Mi_SQL += ")";

                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                    Consecutivo++;
                }


                //  se actualizan las ventas con el estatus de f = facturado
                Mi_SQL = "update " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " set";
                Mi_SQL += " " + Ope_Ventas_Detalles.Campo_Estatus_Solicitud + "= 'F'";

                //  seccion where
                Mi_SQL += " where " + Ope_Ventas_Detalles.Campo_No_Venta + " = '" + Datos.P_No_Venta + "'";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                //}

                //  se genera la impresion del recibo de la solicitud
                var Obj_Impresiones = new Cls_Ope_Impresiones_Negocio();
                Obj_Impresiones.P_Dt_Solicitud = Datos.P_Dt_Solicitud;
                Obj_Impresiones.P_Total_Venta_En_Solicitd = Datos.P_Total_Venta;
                Obj_Impresiones.P_Imagen_Bits = Datos.P_Imagen_Bits;
                Obj_Impresiones.Imprimir_Solicitud_Facturacion();



                Alta_Exitosa = true;
                Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
            }
            finally
            {

                Conexion.HelperGenerico.Cerrar_Conexion();

            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Insertar_Solicitud
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Solicitud_Local(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;

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

                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo_Numerico_Deudorcad("adeudos", "conse", " curp = '" + Datos.P_Cuenta_Momias + "'");


                //  se obtitene el nombre de la persona que realiza la solicitud
                String Nombre_Usuario = "";
                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;


                Mi_SQL = "INSERT INTO adeudos (";
                Mi_SQL += "ano";
                Mi_SQL += ", tipo";
                Mi_SQL += ", lista";
                Mi_SQL += ", curp";
                Mi_SQL += ", clave";
                Mi_SQL += ", fecha";
                Mi_SQL += ", unidad";
                //Mi_SQL += ", unidad2";
                Mi_SQL += ", tarifa";
                Mi_SQL += ", cantidad";
                Mi_SQL += ", cantidad2";
                Mi_SQL += ", importe";
                Mi_SQL += ", saldo";
                Mi_SQL += ", concepto";
                Mi_SQL += ", concepto2";
                Mi_SQL += ", referencia1";
                Mi_SQL += ", referencia2";
                Mi_SQL += ", referencia3";
                //Mi_SQL += ", pagar";
                Mi_SQL += ", impopago";
                Mi_SQL += ", captura";
                Mi_SQL += ", hora";
                Mi_SQL += ", user";
                Mi_SQL += ", maquina";
                Mi_SQL += ", conse";
                //Mi_SQL += ", requiere";
                //Mi_SQL += ", origen";
                Mi_SQL += ", porcond";
                Mi_SQL += ", feccond";
                //Mi_SQL += ", usercond";
                //Mi_SQL += ", refcond";
                Mi_SQL += ", hon1";
                Mi_SQL += ", hon2";
                Mi_SQL += ", hon3";
                Mi_SQL += ", recargosm";
                Mi_SQL += ", fec1";
                Mi_SQL += ", fec2";
                Mi_SQL += ", fec3";
                Mi_SQL += ", fecham";
                Mi_SQL += ")";
                Mi_SQL += " VALUES (";//****************************************
                Mi_SQL += "'" + DateTime.Now.ToString("yyyy") + "'";//1
                Mi_SQL += ", '" + Datos.P_Tipo_Parametro + "'";//2 tipo
                Mi_SQL += ", '" + Datos.P_Lista_Parametros + "'"; // lista 3
                Mi_SQL += ", '" + Datos.P_Curp + "'";//    curp 4
                Mi_SQL += ", '" + Datos.P_Clave_Venta + "'";//    clave del producto    5
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha   5
                Mi_SQL += ", 'BOLETO'"; // unidad  6
                Mi_SQL += ", '" + Datos.P_Importe + "'";//   tarifa 7
                Mi_SQL += ", '1'";// cantidad 8
                Mi_SQL += ", '1'";  //  cantidad "2" 9
                Mi_SQL += ", '" + Datos.P_Importe + "'";//   importe 10
                Mi_SQL += ", '0'";//    saldo   10
                Mi_SQL += ", '.'";//    concepto 11
                Mi_SQL += ", '" + Datos.P_Concepto2 + "'"; // concepto "2"    12
                Mi_SQL += ", '" + Datos.P_Tipo + "'"; // referencia "1" 13
                Mi_SQL += ", '" + Datos.P_Lista + "'";// referencia "2" 14
                Mi_SQL += ", '" + Datos.P_Caja + Datos.P_Turno + DateTime.Now.ToString("ddMMyy") + " " + Datos.P_No_Venta + "'";// referencia "3" 15
                Mi_SQL += ", '0'";//   impopago 16 
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha 17
                Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 18
                Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 19
                Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 20
                Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 21
                Mi_SQL += ", '0'";// porcond 28
                Mi_SQL += ", '1900-01-01'";// feccond 29
                Mi_SQL += ", '0'";// hon1 32
                Mi_SQL += ", '0'";// hon1 33
                Mi_SQL += ", '0'";// hon1 34
                Mi_SQL += ", '0'";// recargosm 35
                Mi_SQL += ", '1900-01-01'";// fec1 36
                Mi_SQL += ", '1900-01-01'";// fec2 37
                Mi_SQL += ", '1900-01-01'";// fec2 38
                Mi_SQL += ", '1900-01-01'";// fecham 39
                Mi_SQL += ")";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Consecutivo++;

                //  se actualizan las ventas con el estatus de f = facturado
                Mi_SQL = "update " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " set";
                Mi_SQL += " " + Ope_Ventas_Detalles.Campo_Estatus_Solicitud + "= 'F'";

                //  seccion where
                Mi_SQL += " where " + Ope_Ventas_Detalles.Campo_No_Venta + " = '" + Datos.P_No_Venta + "'";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Conexion.HelperGenerico.Terminar_Transaccion();
                Alta_Exitosa = true;
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
            }
            finally
            {

                Conexion.HelperGenerico.Cerrar_Conexion();

            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Insertar_Solicitud
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Solicitud(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand();
            String Mi_SQL_Adeudos = "";
            Boolean Version_Bd_4 = false;

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
                //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                Consulta_Parametros.P_Parametro_Id = "00001";
                DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                /////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////
                if (Dt_Consulta.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                {
                    #region Version odbc
                    Version_Bd_4 = true;
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

                            Mi_SQL_Adeudos = "SELECT MAX(conse) FROM adeudos";

                            Cmd.Connection = MyConnection;
                            Cmd.CommandText = Mi_SQL_Adeudos;
                            Object Obj_Temp = Cmd.ExecuteScalar();

                            Obj_Temp.ToString();
                            if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                            {
                                Consecutivo = (Convert.ToInt64(Obj_Temp) + 1);
                            }

                            String Nombre_Usuario = "";
                            if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                                Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                            else
                                Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;


                            Mi_SQL = "INSERT INTO adeudos (";
                            Mi_SQL += "ano";
                            Mi_SQL += ", tipo";
                            Mi_SQL += ", lista";
                            Mi_SQL += ", curp";
                            Mi_SQL += ", clave";
                            Mi_SQL += ", fecha";
                            Mi_SQL += ", unidad";
                            //Mi_SQL += ", unidad2";
                            Mi_SQL += ", tarifa";
                            Mi_SQL += ", cantidad";
                            Mi_SQL += ", cantidad2";
                            Mi_SQL += ", importe";
                            Mi_SQL += ", saldo";
                            Mi_SQL += ", concepto";
                            Mi_SQL += ", concepto2";
                            Mi_SQL += ", referencia1";
                            Mi_SQL += ", referencia2";
                            Mi_SQL += ", referencia3";
                            //Mi_SQL += ", pagar";
                            Mi_SQL += ", impopago";
                            Mi_SQL += ", captura";
                            Mi_SQL += ", hora";
                            Mi_SQL += ", user";
                            Mi_SQL += ", maquina";
                            Mi_SQL += ", conse";
                            //Mi_SQL += ", requiere";
                            //Mi_SQL += ", origen";
                            Mi_SQL += ", porcond";
                            Mi_SQL += ", feccond";
                            //Mi_SQL += ", usercond";
                            //Mi_SQL += ", refcond";
                            Mi_SQL += ", hon1";
                            Mi_SQL += ", hon2";
                            Mi_SQL += ", hon3";
                            Mi_SQL += ", recargosm";
                            Mi_SQL += ", fec1";
                            Mi_SQL += ", fec2";
                            Mi_SQL += ", fec3";
                            Mi_SQL += ", fecham";
                            Mi_SQL += ")";
                            Mi_SQL += " VALUES (";//****************************************
                            Mi_SQL += "'" + DateTime.Now.ToString("yyyy") + "'";//1
                            Mi_SQL += ", '" + Datos.P_Tipo_Parametro + "'";//2 tipo
                            Mi_SQL += ", '" + Datos.P_Lista_Parametros + "'"; // lista 3
                            Mi_SQL += ", '" + Datos.P_Curp + "'";//    curp 4
                            Mi_SQL += ", '" + Datos.P_Clave_Venta + "'";//    clave del producto    5
                            Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha   5

                            Mi_SQL += ", 'BOLETO'"; // unidad  6

                            Mi_SQL += ", '" + Datos.P_Importe + "'";//   tarifa 7
                            Mi_SQL += ", '1'";// cantidad 8
                            Mi_SQL += ", '1'";  //  cantidad "2" 9
                            Mi_SQL += ", '" + Datos.P_Importe + "'";//   importe 10
                            Mi_SQL += ", '0'";//    saldo   10
                            Mi_SQL += ", '.'";//    concepto 11
                            Mi_SQL += ", '" + Datos.P_Concepto2 + "'"; // concepto "2"    12
                            Mi_SQL += ", '" + Datos.P_Tipo + "'"; // referencia "1" 13
                            Mi_SQL += ", '" + Datos.P_Lista + "'";// referencia "2" 14
                            Mi_SQL += ", '" + Datos.P_Caja + Datos.P_Turno + DateTime.Now.ToString("ddMMyy") + " " + Datos.P_No_Venta + "'";// referencia "3" 15
                            Mi_SQL += ", '0'";//   impopago 16 
                            Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha 17
                            Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 18
                            Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 19
                            Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 20
                            Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 21
                            Mi_SQL += ", '0'";// porcond 28
                            Mi_SQL += ", '1900-01-01'";// feccond 29
                            Mi_SQL += ", '0'";// hon1 32
                            Mi_SQL += ", '0'";// hon1 33
                            Mi_SQL += ", '0'";// hon1 34
                            Mi_SQL += ", '0'";// recargosm 35
                            Mi_SQL += ", '1900-01-01'";// fec1 36
                            Mi_SQL += ", '1900-01-01'";// fec2 37
                            Mi_SQL += ", '1900-01-01'";// fec2 38
                            Mi_SQL += ", '1900-01-01'";// fecham 39
                            Mi_SQL += ")";

                            Cmd.Connection = MyConnection;
                            Cmd.CommandText = Mi_SQL;
                            Cmd.ExecuteNonQuery();

                            Alta_Exitosa = true;

                            MyConnection.Close();

                        }
                    }
                    #endregion
                }
                /////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////
                else
                {
                    #region Version Mysql 5
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


                    //  obtenemos el consucutivo
                    Mi_SQL_Adeudos = "SELECT MAX(conse) FROM adeudos";
                    Comando_Mysql.CommandText = Mi_SQL_Adeudos;
                    Object Obj_Temp = Comando_Mysql.ExecuteScalar();
                    Obj_Temp.ToString();
                    if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                    {
                        Consecutivo = (Convert.ToInt64(Obj_Temp) + 1);
                    }


                    String Nombre_Usuario = "";
                    if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                        Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                    else
                        Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;


                    Mi_SQL = "INSERT INTO adeudos (";
                    Mi_SQL += "ano";
                    Mi_SQL += ", tipo";
                    Mi_SQL += ", lista";
                    Mi_SQL += ", curp";
                    Mi_SQL += ", clave";
                    Mi_SQL += ", fecha";
                    Mi_SQL += ", unidad";
                    //Mi_SQL += ", unidad2";
                    Mi_SQL += ", tarifa";
                    Mi_SQL += ", cantidad";
                    Mi_SQL += ", cantidad2";
                    Mi_SQL += ", importe";
                    Mi_SQL += ", saldo";
                    Mi_SQL += ", concepto";
                    Mi_SQL += ", concepto2";
                    Mi_SQL += ", referencia1";
                    Mi_SQL += ", referencia2";
                    Mi_SQL += ", referencia3";
                    //Mi_SQL += ", pagar";
                    Mi_SQL += ", impopago";
                    Mi_SQL += ", captura";
                    Mi_SQL += ", hora";
                    Mi_SQL += ", user";
                    Mi_SQL += ", maquina";
                    Mi_SQL += ", conse";
                    //Mi_SQL += ", requiere";
                    //Mi_SQL += ", origen";
                    Mi_SQL += ", porcond";
                    Mi_SQL += ", feccond";
                    //Mi_SQL += ", usercond";
                    //Mi_SQL += ", refcond";
                    Mi_SQL += ", hon1";
                    Mi_SQL += ", hon2";
                    Mi_SQL += ", hon3";
                    Mi_SQL += ", recargosm";
                    Mi_SQL += ", fec1";
                    Mi_SQL += ", fec2";
                    Mi_SQL += ", fec3";
                    Mi_SQL += ", fecham";
                    Mi_SQL += ")";
                    Mi_SQL += " VALUES (";//****************************************
                    Mi_SQL += "'" + DateTime.Now.ToString("yyyy") + "'";//1
                    Mi_SQL += ", '" + Datos.P_Tipo_Parametro + "'";//2 tipo
                    Mi_SQL += ", '" + Datos.P_Lista_Parametros + "'"; // lista 3
                    Mi_SQL += ", '" + Datos.P_Curp + "'";//    curp 4
                    Mi_SQL += ", '" + Datos.P_Clave_Venta + "'";//    clave del producto    5
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha   5

                    Mi_SQL += ", 'BOLETO'"; // unidad  6

                    Mi_SQL += ", '" + Datos.P_Importe + "'";//   tarifa 7
                    Mi_SQL += ", '1'";// cantidad 8
                    Mi_SQL += ", '1'";  //  cantidad "2" 9
                    Mi_SQL += ", '" + Datos.P_Importe + "'";//   importe 10
                    Mi_SQL += ", '0'";//    saldo   10
                    Mi_SQL += ", '.'";//    concepto 11
                    Mi_SQL += ", '" + Datos.P_Concepto2 + "'"; // concepto "2"    12
                    Mi_SQL += ", '" + Datos.P_Tipo + "'"; // referencia "1" 13
                    Mi_SQL += ", '" + Datos.P_Lista + "'";// referencia "2" 14
                    Mi_SQL += ", '" + Datos.P_Caja + Datos.P_Turno + DateTime.Now.ToString("ddMMyy") + " " + Datos.P_No_Venta + "'";// referencia "3" 15
                    Mi_SQL += ", '0'";//   impopago 16 
                    Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha 17
                    Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 18
                    Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 19
                    Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 20
                    Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 21
                    Mi_SQL += ", '0'";// porcond 28
                    Mi_SQL += ", '1900-01-01'";// feccond 29
                    Mi_SQL += ", '0'";// hon1 32
                    Mi_SQL += ", '0'";// hon1 33
                    Mi_SQL += ", '0'";// hon1 34
                    Mi_SQL += ", '0'";// recargosm 35
                    Mi_SQL += ", '1900-01-01'";// fec1 36
                    Mi_SQL += ", '1900-01-01'";// fec2 37
                    Mi_SQL += ", '1900-01-01'";// fec2 38
                    Mi_SQL += ", '1900-01-01'";// fecham 39
                    Mi_SQL += ")";

                    Comando_Mysql.CommandText = Mi_SQL;
                    Comando_Mysql.ExecuteNonQuery();

                    Obj_Transaccion.Commit();
                    Obj_Conexion.Close();

                    Alta_Exitosa = true;
                    Conexion.HelperGenerico.Terminar_Transaccion();
                    #endregion
                }
                /////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////
            }
            catch (Exception E)
            {
                if (Version_Bd_4 == true) Obj_Transaccion.Rollback();
                else Conexion.HelperGenerico.Abortar_Transaccion();

                throw new Exception("Insertar_Solicitud: " + E.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Actualizar_Estatus_Facturacion
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Datos: Instancia de Cls_Ope_Solicitud_Facturacion_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Actualizar_Estatus_Facturacion(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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
                
                //  se actualizan las ventas con el estatus de f = facturado
                Mi_SQL = "update " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " set";
                Mi_SQL += " " + Ope_Ventas_Detalles.Campo_Estatus_Solicitud + "= 'F'";

                //  seccion where
                Mi_SQL += " where " + Ope_Ventas_Detalles.Campo_No_Venta + " = '" + Datos.P_No_Venta + "'";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                
                ////  se genera la impresion del recibo de la solicitud
                //var Obj_Impresiones = new Cls_Ope_Impresiones_Negocio();
                //Obj_Impresiones.P_Dt_Solicitud = Datos.P_Dt_Solicitud;
                //Obj_Impresiones.P_Total_Venta_En_Solicitd = Datos.P_Total_Venta;
                //Obj_Impresiones.P_Imagen_Bits = Datos.P_Imagen_Bits;
                //Obj_Impresiones.Imprimir_Solicitud_Facturacion();

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }


                return Alta_Exitosa = true;

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Insertar_Historico: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Insertar_Historico
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Datos: Instancia de Cls_Ope_Solicitud_Facturacion_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Historico(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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
                //Conexion.HelperGenerico.Iniciar_Transaccion();

                //  se consulta que exista registro de exportacion
                Mi_SQL = "select * from " + Ope_Historico_Exportacion.Tabla;
                Mi_SQL += " where DATE_FORMAT(" + Ope_Historico_Exportacion.Campo_Fecha + ", '%Y-%m-%d') = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (Dt_Consulta != null && Dt_Consulta.Rows.Count == 0)
                {
                    Mi_SQL = "INSERT INTO " + Ope_Historico_Exportacion.Tabla + "(";
                    Mi_SQL += Ope_Historico_Exportacion.Campo_Fecha;
                    Mi_SQL += ")";
                    Mi_SQL += " values ";
                    Mi_SQL += "(";
                    Mi_SQL += "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'";
                    Mi_SQL += ")";
                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                }

                Alta_Exitosa = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Insertar_Historico: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Insertar_Solicitud_Ventas_Dia
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Solicitud_Ventas_Dia(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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

                String Nombre_Usuario = "";


                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;


                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo_Numerico_Deudorcad("adeudos", "conse", " curp = '" + Datos.P_Cuenta_Momias + "'");

                foreach (DataRow Dr_Registro in Datos.P_Dt_Ventas_Dia.Rows)
                {
                    Mi_SQL = "INSERT INTO adeudos (";
                    Mi_SQL += "ano";//1
                    Mi_SQL += ", tipo";//2
                    Mi_SQL += ", lista";//3
                    Mi_SQL += ", curp";//4
                    Mi_SQL += ", clave";//5
                    Mi_SQL += ", fecha";//6
                    Mi_SQL += ", unidad";//7
                    //Mi_SQL += ", unidad2";//8
                    Mi_SQL += ", tarifa";//9
                    Mi_SQL += ", cantidad";//10
                    Mi_SQL += ", cantidad2";//11
                    Mi_SQL += ", importe";//12
                    Mi_SQL += ", saldo";//13
                    Mi_SQL += ", concepto";//14
                    Mi_SQL += ", concepto2";//15
                    Mi_SQL += ", referencia1";//16
                    Mi_SQL += ", referencia2";//17
                    Mi_SQL += ", referencia3";//18
                    //Mi_SQL += ", pagar";//19
                    Mi_SQL += ", impopago";//20
                    Mi_SQL += ", captura";//21
                    Mi_SQL += ", hora";//22
                    Mi_SQL += ", user";//23
                    Mi_SQL += ", maquina";//24
                    Mi_SQL += ", conse";//25
                    //Mi_SQL += ", requiere";//26
                    //Mi_SQL += ", origen";//27
                    Mi_SQL += ", porcond";//28
                    Mi_SQL += ", feccond";//29
                    //Mi_SQL += ", usercond";//30
                    //Mi_SQL += ", refcond";//31
                    Mi_SQL += ", hon1";//32
                    Mi_SQL += ", hon2";//33
                    Mi_SQL += ", hon3";//34
                    Mi_SQL += ", recargosm";//35
                    Mi_SQL += ", fec1";//36
                    Mi_SQL += ", fec2";//37
                    Mi_SQL += ", fec3";//38
                    Mi_SQL += ", fecham";//39
                    Mi_SQL += ")";
                    Mi_SQL += " VALUES (";//****************************************
                    Mi_SQL += "'" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy") + "'";//  Año 1
                    Mi_SQL += ", '" + Datos.P_Tipo + "'";//  tipo (parametro) 2
                    Mi_SQL += ", '" + Datos.P_Lista + "'"; // lista (parametro) 3
                    Mi_SQL += ", '" + Datos.P_Cuenta_Momias + "'";//    curp (parametro) 4
                    Mi_SQL += ", '" + Datos.P_Clave_Venta + "'";//    clave del producto (1 para venta, 9 para sobrantes)    5
                    Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy-MM-dd") + "'";// fecha   6

                    //if (Dr_Registro["nombre"].ToString().Length > 10)
                    //    Mi_SQL += ", '" + Dr_Registro["nombre"].ToString().Substring(0, 9) + "'"; // unidad  7
                    //else
                    Mi_SQL += ", 'CORTE'"; // unidad  7

                    Mi_SQL += ", '" + Dr_Registro["Total"].ToString() + "'";//   tarifa 9
                    Mi_SQL += ", '1'";// cantidad 10
                    Mi_SQL += ", '1'";  //  cantidad "2" 11
                    Mi_SQL += ", '" + Dr_Registro["Total"].ToString() + "'";//   importe 12
                    Mi_SQL += ", '0'";//    saldo   13
                    Mi_SQL += ", '.'";//    concepto 14
                    Mi_SQL += ", '" + Dr_Registro["Leyenda"].ToString() + "'"; // concepto "2"    15
                    Mi_SQL += ", '" + Datos.P_Referencia1 + "'"; // referencia "1" 16
                    Mi_SQL += ", '" + Datos.P_Referencia2 + "'";// referencia "2" 17
                    Mi_SQL += ", '" + Dr_Registro["Nombre_Caja"].ToString() + Dr_Registro["Nombre_Turno"].ToString() + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("ddMM") + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yy") + " " + Datos.P_No_Cierre + "'";// referencia "3" 18
                    Mi_SQL += ", '0'";//   impopago 20 
                    Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy-MM-dd") + "'";// captura 21
                    Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 22
                    Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 23
                    Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 24
                    Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 25

                    Mi_SQL += ", '0'";// porcond 28
                    Mi_SQL += ", '1900-01-01'";// feccond 29
                    Mi_SQL += ", '0'";// hon1 32
                    Mi_SQL += ", '0'";// hon1 33
                    Mi_SQL += ", '0'";// hon1 34
                    Mi_SQL += ", '0'";// recargosm 35
                    Mi_SQL += ", '1900-01-01'";// fec1 36
                    Mi_SQL += ", '1900-01-01'";// fec2 37
                    Mi_SQL += ", '1900-01-01'";// fec2 38
                    Mi_SQL += ", '1900-01-01'";// fecham 39
                    Mi_SQL += ")";

                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                    Consecutivo++;

                }

                Alta_Exitosa = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Insertar_Solicitud_Ventas_Dia
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Solicitud_Ventas_Dia_Catalogo(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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

                String Nombre_Usuario = "";


                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;


                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo_Numerico_Deudorcad("adeudos", "conse", " curp = '" + Datos.P_Cuenta_Momias + "'");

                foreach (DataRow Registro_ in Datos.P_Dt_Listas_Deudorcad.Rows)
                {
                    foreach (DataRow Dr_Registro in Datos.P_Dt_Ventas_Dia.Rows)
                    {
                        if (Registro_["Tipo_Pago"].ToString() == Dr_Registro["Tipo_Pago"].ToString())
                        {
                            Mi_SQL = "INSERT INTO adeudos (";
                            Mi_SQL += "ano";//1
                            Mi_SQL += ", tipo";//2
                            Mi_SQL += ", lista";//3
                            Mi_SQL += ", curp";//4
                            Mi_SQL += ", clave";//5
                            Mi_SQL += ", fecha";//6
                            Mi_SQL += ", unidad";//7
                            //Mi_SQL += ", unidad2";//8
                            Mi_SQL += ", tarifa";//9
                            Mi_SQL += ", cantidad";//10
                            Mi_SQL += ", cantidad2";//11
                            Mi_SQL += ", importe";//12
                            Mi_SQL += ", saldo";//13
                            Mi_SQL += ", concepto";//14
                            Mi_SQL += ", concepto2";//15
                            Mi_SQL += ", referencia1";//16
                            Mi_SQL += ", referencia2";//17
                            Mi_SQL += ", referencia3";//18
                            //Mi_SQL += ", pagar";//19
                            Mi_SQL += ", impopago";//20
                            Mi_SQL += ", captura";//21
                            Mi_SQL += ", hora";//22
                            Mi_SQL += ", user";//23
                            Mi_SQL += ", maquina";//24
                            Mi_SQL += ", conse";//25
                            //Mi_SQL += ", requiere";//26
                            //Mi_SQL += ", origen";//27
                            Mi_SQL += ", porcond";//28
                            Mi_SQL += ", feccond";//29
                            //Mi_SQL += ", usercond";//30
                            //Mi_SQL += ", refcond";//31
                            Mi_SQL += ", hon1";//32
                            Mi_SQL += ", hon2";//33
                            Mi_SQL += ", hon3";//34
                            Mi_SQL += ", recargosm";//35
                            Mi_SQL += ", fec1";//36
                            Mi_SQL += ", fec2";//37
                            Mi_SQL += ", fec3";//38
                            Mi_SQL += ", fecham";//39
                            Mi_SQL += ")";
                            Mi_SQL += " VALUES (";//****************************************
                            Mi_SQL += "'" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy") + "'";//  Año 1
                            Mi_SQL += ", '" + Datos.P_Tipo + "'";//  tipo (parametro) 2
                            Mi_SQL += ", '" + Datos.P_Lista + "'"; // lista (parametro) 3
                            Mi_SQL += ", '" + Datos.P_Cuenta_Momias + "'";//    curp (parametro) 4
                            Mi_SQL += ", '" + Registro_["Lista"].ToString() + "'";//    clave del producto (1 para venta, 9 para sobrantes)    5
                            Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy-MM-dd") + "'";// fecha   6

                            //if (Dr_Registro["nombre"].ToString().Length > 10)
                            //    Mi_SQL += ", '" + Dr_Registro["nombre"].ToString().Substring(0, 9) + "'"; // unidad  7
                            //else
                            Mi_SQL += ", 'CORTE'"; // unidad  7

                            Mi_SQL += ", '" + Dr_Registro["Total"].ToString() + "'";//   tarifa 9
                            Mi_SQL += ", '1'";// cantidad 10
                            Mi_SQL += ", '1'";  //  cantidad "2" 11
                            Mi_SQL += ", '" + Dr_Registro["Total"].ToString() + "'";//   importe 12
                            Mi_SQL += ", '0'";//    saldo   13
                            Mi_SQL += ", '.'";//    concepto 14
                            Mi_SQL += ", '" + Dr_Registro["Leyenda"].ToString() + "'"; // concepto "2"    15
                            Mi_SQL += ", '" + Datos.P_Referencia1 + "'"; // referencia "1" 16
                            Mi_SQL += ", '" + Datos.P_Referencia2 + "'";// referencia "2" 17
                            Mi_SQL += ", '" + Dr_Registro["Nombre_Caja"].ToString() + Dr_Registro["Nombre_Turno"].ToString() + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("ddMM") + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yy") + " " + Datos.P_No_Cierre + "'";// referencia "3" 18
                            Mi_SQL += ", '0'";//   impopago 20 
                            Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy-MM-dd") + "'";// captura 21
                            Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 22
                            Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 23
                            Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 24
                            Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 25

                            Mi_SQL += ", '0'";// porcond 28
                            Mi_SQL += ", '1900-01-01'";// feccond 29
                            Mi_SQL += ", '0'";// hon1 32
                            Mi_SQL += ", '0'";// hon1 33
                            Mi_SQL += ", '0'";// hon1 34
                            Mi_SQL += ", '0'";// recargosm 35
                            Mi_SQL += ", '1900-01-01'";// fec1 36
                            Mi_SQL += ", '1900-01-01'";// fec2 37
                            Mi_SQL += ", '1900-01-01'";// fec2 38
                            Mi_SQL += ", '1900-01-01'";// fecham 39
                            Mi_SQL += ")";

                            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                            Consecutivo++;
                        }
                    }
                }

                Alta_Exitosa = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Insertar_Ventas_Dia_Internet
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Ventas_Dia_Internet(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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

                String Nombre_Usuario = "";


                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;
                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo_Numerico_Deudorcad("adeudos", "conse", " curp = '" + Datos.P_Cuenta_Momias + "'");


                Mi_SQL = "INSERT INTO adeudos (";
                Mi_SQL += "ano";
                Mi_SQL += ", tipo";
                Mi_SQL += ", lista";
                Mi_SQL += ", curp";
                Mi_SQL += ", clave";
                Mi_SQL += ", fecha";
                Mi_SQL += ", unidad";
                //Mi_SQL += ", unidad2";
                Mi_SQL += ", tarifa";
                Mi_SQL += ", cantidad";
                Mi_SQL += ", cantidad2";
                Mi_SQL += ", importe";
                Mi_SQL += ", saldo";
                Mi_SQL += ", concepto";
                Mi_SQL += ", concepto2";
                Mi_SQL += ", referencia1";
                Mi_SQL += ", referencia2";
                Mi_SQL += ", referencia3";
                //Mi_SQL += ", pagar";
                Mi_SQL += ", impopago";
                Mi_SQL += ", captura";
                Mi_SQL += ", hora";
                Mi_SQL += ", user";
                Mi_SQL += ", maquina";
                Mi_SQL += ", conse";
                //Mi_SQL += ", requiere";
                //Mi_SQL += ", origen";
                Mi_SQL += ", porcond";
                Mi_SQL += ", feccond";
                //Mi_SQL += ", usercond";
                //Mi_SQL += ", refcond";
                Mi_SQL += ", hon1";
                Mi_SQL += ", hon2";
                Mi_SQL += ", hon3";
                Mi_SQL += ", recargosm";
                Mi_SQL += ", fec1";
                Mi_SQL += ", fec2";
                Mi_SQL += ", fec3";
                Mi_SQL += ", fecham";
                Mi_SQL += ")";
                Mi_SQL += " VALUES (";//****************************************
                Mi_SQL += "'" + DateTime.Now.ToString("yyyy") + "'";//1
                Mi_SQL += ", '" + Datos.P_Tipo + "'";//2 tipo
                Mi_SQL += ", '" + Datos.P_Lista + "'"; // lista 3
                Mi_SQL += ", '" + Datos.P_Curp + "'";//    curp 4
                Mi_SQL += ", '" + Datos.P_Clave_Venta + "'";//    clave del producto    5
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha   5

                Mi_SQL += ", 'BOLETO'"; // unidad  6

                Mi_SQL += ", '" + Datos.P_Importe + "'";//   tarifa 7
                Mi_SQL += ", '1'";// cantidad 8
                Mi_SQL += ", '1'";  //  cantidad "2" 9
                Mi_SQL += ", '" + Datos.P_Importe + "'";//   importe 10
                Mi_SQL += ", '0'";//    saldo   10
                Mi_SQL += ", '.'";//    concepto 11
                Mi_SQL += ", '" + Datos.P_Concepto2 + "'"; // concepto "2"    12
                Mi_SQL += ", '" + Datos.P_Referencia1 + "'"; // referencia "1" 13
                Mi_SQL += ", '" + Datos.P_Referencia2 + "'";// referencia "2" 14
                Mi_SQL += ", 'Internet " + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + "'";// referencia "3" 15
                Mi_SQL += ", '0'";//   impopago 16 
                Mi_SQL += ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "'";// fecha 17
                Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 18
                Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 19
                Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 20
                Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 21
                Mi_SQL += ", '0'";// porcond 28
                Mi_SQL += ", '1900-01-01'";// feccond 29
                Mi_SQL += ", '0'";// hon1 32
                Mi_SQL += ", '0'";// hon1 33
                Mi_SQL += ", '0'";// hon1 34
                Mi_SQL += ", '0'";// recargosm 35
                Mi_SQL += ", '1900-01-01'";// fec1 36
                Mi_SQL += ", '1900-01-01'";// fec2 37
                Mi_SQL += ", '1900-01-01'";// fec2 38
                Mi_SQL += ", '1900-01-01'";// fecham 39
                Mi_SQL += ")";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Consecutivo++;

                Alta_Exitosa = true;

                //if (!Transaccion_Activa)
                //{
                //    Conexion.HelperGenerico.Terminar_Transaccion();
                //}

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Insertar_Solicitud_Ventas_Dia
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Insertar_Sobrante_Caja(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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
                String Nombre_Usuario = "";


                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                else
                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;


                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo_Numerico_Deudorcad("adeudos", "conse", " curp = '" + Datos.P_Cuenta_Momias + "'");

                if (Datos.P_Dt_Ventas_Dia.Rows.Count > 0 && !String.IsNullOrEmpty(Datos.P_Dt_Ventas_Dia.Rows[0][Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()))
                {
                    foreach (DataRow Dr_Registro in Datos.P_Dt_Ventas_Dia.Rows)
                    {
                        Mi_SQL = "INSERT INTO adeudos (";
                        Mi_SQL += "ano";//1
                        Mi_SQL += ", tipo";//2
                        Mi_SQL += ", lista";//3
                        Mi_SQL += ", curp";//4
                        Mi_SQL += ", clave";//5
                        Mi_SQL += ", fecha";//6
                        Mi_SQL += ", unidad";//7
                        //Mi_SQL += ", unidad2";//8
                        Mi_SQL += ", tarifa";//9
                        Mi_SQL += ", cantidad";//10
                        Mi_SQL += ", cantidad2";//11
                        Mi_SQL += ", importe";//12
                        Mi_SQL += ", saldo";//13
                        Mi_SQL += ", concepto";//14
                        Mi_SQL += ", concepto2";//15
                        Mi_SQL += ", referencia1";//16
                        Mi_SQL += ", referencia2";//17
                        Mi_SQL += ", referencia3";//18
                        //Mi_SQL += ", pagar";//19
                        Mi_SQL += ", impopago";//20
                        Mi_SQL += ", captura";//21
                        Mi_SQL += ", hora";//22
                        Mi_SQL += ", user";//23
                        Mi_SQL += ", maquina";//24
                        Mi_SQL += ", conse";//25
                        //Mi_SQL += ", requiere";//26
                        //Mi_SQL += ", origen";//27
                        Mi_SQL += ", porcond";//28
                        Mi_SQL += ", feccond";//29
                        //Mi_SQL += ", usercond";//30
                        //Mi_SQL += ", refcond";//31
                        Mi_SQL += ", hon1";//32
                        Mi_SQL += ", hon2";//33
                        Mi_SQL += ", hon3";//34
                        Mi_SQL += ", recargosm";//35
                        Mi_SQL += ", fec1";//36
                        Mi_SQL += ", fec2";//37
                        Mi_SQL += ", fec3";//38
                        Mi_SQL += ", fecham";//39
                        Mi_SQL += ")";
                        Mi_SQL += " VALUES (";//****************************************
                        Mi_SQL += "'" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy") + "'";//  Año 1
                        Mi_SQL += ", '" + Datos.P_Tipo + "'";//  tipo (parametro) 2
                        Mi_SQL += ", '" + Datos.P_Lista + "'"; // lista (parametro) 3
                        Mi_SQL += ", '" + Datos.P_Cuenta_Momias + "'";//    curp (parametro) 4
                        Mi_SQL += ", '" + Datos.P_Clave_Sobrante + "'";//    clave del producto (1 para venta, 9 para sobrantes)    5
                        Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy-MM-dd") + "'";// fecha   6

                        //if (Dr_Registro["nombre"].ToString().Length > 10)
                        //    Mi_SQL += ", '" + Dr_Registro["nombre"].ToString().Substring(0, 9) + "'"; // unidad  7
                        //else
                        Mi_SQL += ", 'SOBRANTE'"; // unidad  7
                        Mi_SQL += ", '" + Datos.P_Sobrante + "'";//   tarifa 9
                        Mi_SQL += ", '1'";// cantidad 10
                        Mi_SQL += ", '1'";  //  cantidad "2" 11
                        Mi_SQL += ", '" + Datos.P_Sobrante + "'";//   importe 12
                        Mi_SQL += ", '0'";//    saldo   13
                        Mi_SQL += ", '.'";//    concepto 14
                        Mi_SQL += ", 'SOBRANTE'"; // concepto "2"    15
                        Mi_SQL += ", '" + Datos.P_Referencia1 + "'"; // referencia "1" 16
                        Mi_SQL += ", '" + Datos.P_Referencia2 + "'";// referencia "2" 17
                        Mi_SQL += ", '" + Dr_Registro["Nombre_Caja"].ToString() + Dr_Registro["Nombre_Turno"].ToString() + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("ddMM") + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yy") + " " + Datos.P_No_Cierre + "'";// referencia "3" 18
                        Mi_SQL += ", '0'";//   impopago 20 
                        Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro[Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()).ToString("yyyy-MM-dd") + "'";// captura 21
                        Mi_SQL += ", '" + DateTime.Now.ToString("hh:mm") + "'";//    hora 22
                        Mi_SQL += ", '" + Nombre_Usuario + "'";//  user 23
                        Mi_SQL += ", '" + Environment.MachineName + "'";//    maquina 24
                        Mi_SQL += ", '" + Consecutivo.ToString() + "'";//    conse 25

                        Mi_SQL += ", '0'";// porcond 28
                        Mi_SQL += ", '1900-01-01'";// feccond 29
                        Mi_SQL += ", '0'";// hon1 32
                        Mi_SQL += ", '0'";// hon1 33
                        Mi_SQL += ", '0'";// hon1 34
                        Mi_SQL += ", '0'";// recargosm 35
                        Mi_SQL += ", '1900-01-01'";// fec1 36
                        Mi_SQL += ", '1900-01-01'";// fec2 37
                        Mi_SQL += ", '1900-01-01'";// fec2 38
                        Mi_SQL += ", '1900-01-01'";// fecham 39

                        Mi_SQL += ")";

                        Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                        Consecutivo++;
                        break;
                    }
                }

                Alta_Exitosa = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Enviar_Ventas_Dia
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 04/Marzo/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Enviar_Ventas_Dia(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            //Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Contribuyente = new DataTable();
            DataTable Dt_Adeudos = new DataTable();
            DataTable Dt_Movtos = new DataTable();
            String StrConexion = "";
            String Cuenta_Museo = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand();
            Boolean Version_Bd4 = false;

            OdbcTransaction Transaccion = null;

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

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Consulta = Consulta_Parametros.Consultar_Parametros_Transaccion();

                //////////////////////////////////////////////////
                //////////////////////////////////////////////////
                //////////////////////////////////////////////////
                if (Dt_Consulta.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                {
                    #region Version odbc
                    Version_Bd4 = true;
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
                            MyConnection.ConnectionTimeout = 1200000;
                            MyConnection.Open();
                            Transaccion = MyConnection.BeginTransaction();

                            Cmd.Connection = MyConnection;
                            Cmd.Transaction = Transaccion;



                            //  se ingresan lps nuevos contribuyentes
                            if (Datos.P_Dt_Padron_Nuevos != null)
                            {
                                foreach (DataRow Registro in Datos.P_Dt_Padron_Nuevos.Rows)
                                {
                                    //  se consultara que el registro no se encuentre registrado en la bd del deudorcad
                                    Mi_SQL = "select * from padron where curp ='" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";
                                    Cmd.Connection = MyConnection;
                                    Cmd.CommandText = Mi_SQL;

                                    using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                                    {
                                        Adap.SelectCommand = Cmd;
                                        Adap.Fill(Dt_Contribuyente);
                                    }

                                    if (Dt_Contribuyente.Rows.Count == 0)
                                    {
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
                                        Mi_SQL += ")";
                                        Mi_SQL += " values ";
                                        Mi_SQL += "(";
                                        Mi_SQL += "'" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";//   1
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Rfc].ToString() + "'";//  2
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Tipo].ToString() + "'";// 3
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Apellido_Paterno].ToString() + "'";// 4
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Apellido_Materno].ToString() + "'";// 5
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Nombre].ToString() + "'";//   6
                                        Mi_SQL += ", '0'"; //   edonac  default "0"// 7
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro[Cat_Padron.Campo_Fecha_Nacimiento].ToString()).ToString("yyyy-MM-dd") + "'";//  8
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Genero].ToString() + "'";//   9
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Consecutivo].ToString() + "'";// consecutivo //   10
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Maquina].ToString() + "'";//   11
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro[Cat_Padron.Campo_Captura].ToString()).ToString("yyyy-MM-dd") + "'";//  12
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro[Cat_Padron.Campo_Captura].ToString()).ToString("hh:mm") + "'";//   13
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Usuario].ToString() + "'";//  14
                                        Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Baja].ToString() + "'";// Baja //   15
                                        Mi_SQL += ", 'N'"; //   interno1  default "N"// 16
                                        Mi_SQL += ")";

                                        Cmd.Connection = MyConnection;
                                        Cmd.CommandText = Mi_SQL;
                                        Cmd.ExecuteNonQuery();
                                    }

                                    //  se reinicia la variable Dt_Contribuyente
                                    Dt_Contribuyente = new DataTable();
                                }
                            }


                            //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES
                            if (Datos.P_Dt_Listdeudor_Nuevos != null)
                            {
                                foreach (DataRow Registro in Datos.P_Dt_Listdeudor_Nuevos.Rows)
                                {
                                    //  se consulta la listdeudor del contribuyente
                                    Mi_SQL = "select * from listdeudor where curp ='" + Registro["curp"].ToString() + "'"
                                            + " and tipo ='" + Registro["tipo"].ToString() + "'"
                                            + " and lista ='" + Registro["lista"].ToString() + "'";

                                    Cmd.Connection = MyConnection;
                                    Cmd.CommandText = Mi_SQL;

                                    using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                                    {
                                        Adap.SelectCommand = Cmd;
                                        Adap.Fill(Dt_Contribuyente);
                                    }

                                    if (Dt_Contribuyente.Rows.Count == 0)
                                    {

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
                                        Mi_SQL += "'" + Registro["tipo"].ToString() + "'";//  1
                                        Mi_SQL += ", '" + Registro["lista"].ToString() + "'";//    2
                                        Mi_SQL += ", '" + Registro["curp"].ToString() + "'";//    3
                                        Mi_SQL += ", '" + Registro["tipol"].ToString() + "'";//    4
                                        Mi_SQL += ", '" + Registro["referencia1"].ToString() + "'";//    5
                                        Mi_SQL += ", '" + Registro["referencia2"].ToString() + "'";//    6
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro["registro"].ToString()).ToString("yyyy-MM-dd") + "'";//    7
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro["baja"].ToString()).ToString("yyyy-MM-dd") + "'";//    8
                                        Mi_SQL += ", '" + Registro["userr"].ToString() + "'";//    9
                                        //Mi_SQL += ", '" + "'";//    10
                                        Mi_SQL += ", '" + Registro["clave"].ToString() + "'";//    11
                                        Mi_SQL += ", '" + Registro["cantidad"].ToString() + "'";//    12
                                        Mi_SQL += ", '" + Registro["observa"].ToString() + "'";//    13
                                        Mi_SQL += ", '" + Registro["cantidad2"].ToString() + "'";//    14
                                        Mi_SQL += ", '" + Registro["interno1"].ToString() + "'";//    15
                                        Mi_SQL += ", '" + Registro["conse"].ToString() + "'";//    16
                                        Mi_SQL += ", '" + Registro["conspalm"].ToString() + "'";//    17
                                        Mi_SQL += ", '" + Registro["conspalm2"].ToString() + "'";//    18
                                        Mi_SQL += ")";

                                        Cmd.Connection = MyConnection;
                                        Cmd.CommandText = Mi_SQL;
                                        Cmd.ExecuteNonQuery();
                                    }

                                    Dt_Contribuyente = new DataTable();
                                }
                            }

                            //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES que no existen en la tabla
                            if (Datos.P_Dt_Listdeudor_ != null)
                            {
                                foreach (DataRow Registro in Datos.P_Dt_Listdeudor_.Rows)
                                {

                                    //  se consulta la listdeudor del contribuyente
                                    Mi_SQL = "select * from listdeudor where curp ='" + Registro["curp"].ToString() + "'"
                                            + " and tipo ='" + Registro["tipo"].ToString() + "'"
                                            + " and lista ='" + Registro["lista"].ToString() + "'";

                                    Cmd.Connection = MyConnection;
                                    Cmd.CommandText = Mi_SQL;

                                    using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                                    {
                                        Adap.SelectCommand = Cmd;
                                        Adap.Fill(Dt_Contribuyente);
                                    }

                                    if (Dt_Contribuyente.Rows.Count == 0)
                                    {
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
                                        Mi_SQL += "'" + Registro["tipo"].ToString() + "'";//  1
                                        Mi_SQL += ", '" + Registro["lista"].ToString() + "'";//    2
                                        Mi_SQL += ", '" + Registro["curp"].ToString() + "'";//    3
                                        Mi_SQL += ", '" + Registro["tipol"].ToString() + "'";//    4
                                        Mi_SQL += ", '" + Registro["referencia1"].ToString() + "'";//    5
                                        Mi_SQL += ", '" + Registro["referencia2"].ToString() + "'";//    6
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro["registro"].ToString()).ToString("yyyy-MM-dd") + "'";//    7
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro["baja"].ToString()).ToString("yyyy-MM-dd") + "'";//    8
                                        Mi_SQL += ", '" + Registro["userr"].ToString() + "'";//    9
                                        //Mi_SQL += ", '" + "'";//    10
                                        Mi_SQL += ", '" + Registro["clave"].ToString() + "'";//    11
                                        Mi_SQL += ", '" + Registro["cantidad"].ToString() + "'";//    12
                                        Mi_SQL += ", '" + Registro["observa"].ToString() + "'";//    13
                                        Mi_SQL += ", '" + Registro["cantidad2"].ToString() + "'";//    14
                                        Mi_SQL += ", '" + Registro["interno1"].ToString() + "'";//    15
                                        Mi_SQL += ", '" + Registro["conse"].ToString() + "'";//    16
                                        Mi_SQL += ", '" + Registro["conspalm"].ToString() + "'";//    17
                                        Mi_SQL += ", '" + Registro["conspalm2"].ToString() + "'";//    18
                                        Mi_SQL += ")";

                                        Cmd.Connection = MyConnection;
                                        Cmd.CommandText = Mi_SQL;
                                        Cmd.ExecuteNonQuery();

                                    }

                                    Dt_Contribuyente = new DataTable();
                                }
                            }

                            //  se ingresan las direcciones de los nuevos contribuyentes
                            if (Datos.P_Dt_Padron_Nuevos_Direcciones != null)
                            {
                                foreach (DataRow Registro in Datos.P_Dt_Padron_Nuevos_Direcciones.Rows)
                                {
                                    //  se consultara que el registro no se encuentre registrado en la bd del deudorcad
                                    Mi_SQL = "select * from movtos where curp IN ('" + Registro[Cat_Padron.Campo_Curp].ToString() + "')";
                                    Cmd.Connection = MyConnection;
                                    Cmd.CommandText = Mi_SQL;

                                    using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                                    {
                                        Adap.SelectCommand = Cmd;
                                        Adap.Fill(Dt_Movtos);
                                    }

                                    if (Dt_Movtos.Rows.Count == 0)
                                    {
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
                                        Mi_SQL += "'" + Registro["curp"].ToString() + "'";//1 curp
                                        Mi_SQL += ", '0'";//2 numcalle valor por default 0 
                                        Mi_SQL += ", '" + Registro["numext"].ToString() + "'";//3 numext 
                                        Mi_SQL += ", '" + Registro["numint"].ToString() + "'";//4 numint
                                        Mi_SQL += ", '0'";//5 numcol valor default 0
                                        Mi_SQL += ", '" + Registro["nomcol"].ToString() + "'";//6 nomcol valor ''
                                        Mi_SQL += ", '" + Registro["cp"].ToString() + "'";// 7 cp
                                        Mi_SQL += ", '" + Registro["ciudad"].ToString() + "'";//8 ciudad
                                        Mi_SQL += ", '10'";//9 edo en numero
                                        Mi_SQL += ", '" + Registro["nomedo"].ToString() + "'";//10 nomedo estado con letra 
                                        Mi_SQL += ", 'MEXICO'";//11 pais
                                        //Mi_SQL += ", '" + "'";//12 tel1
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro["fechamov"].ToString()).ToString("yyyy-MM-dd") + "'";//13 fechamov
                                        Mi_SQL += ", '1'";//14 numnota default 1
                                        Mi_SQL += ", '0'";//15 ano default 0
                                        Mi_SQL += ", '1'";//16 tipom default 1   
                                        Mi_SQL += ", '" + Registro["maquina"].ToString() + "'";//17 maquina 
                                        Mi_SQL += ", '" + Convert.ToDateTime(Registro["captura"].ToString()).ToString("yyyy-MM-dd") + "'";//18 captura 
                                        Mi_SQL += ", '" + Registro["hora"].ToString() + "'";//19 hora
                                        Mi_SQL += ", '" + Registro["user"].ToString() + "'";//20 user
                                        Mi_SQL += ", '" + Registro["nomcalle"].ToString() + "'";//21 nomcalle
                                        Mi_SQL += ")";

                                        Cmd.Connection = MyConnection;
                                        Cmd.CommandText = Mi_SQL;
                                        Cmd.ExecuteNonQuery();
                                    }
                                }
                            }

                            /*  se actualizan los usuarios del padron  */
                            if (Datos.P_Dt_Padron_Actualizacion != null)
                            {
                                foreach (DataRow Registro in Datos.P_Dt_Padron_Actualizacion.Rows)
                                {
                                    Mi_SQL = "UPDATE " + Cat_Padron.Tabla + " SET ";


                                    Mi_SQL += Cat_Padron.Campo_Curp + "= '" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";//  1
                                    Mi_SQL += ", " + Cat_Padron.Campo_Tipo + "= '" + Registro[Cat_Padron.Campo_Tipo].ToString() + "'";//  3
                                    Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Paterno + "= '" + Registro[Cat_Padron.Campo_Apellido_Paterno].ToString() + "'";//  4
                                    Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Materno + "= '" + Registro[Cat_Padron.Campo_Apellido_Materno].ToString() + "'";//  5
                                    Mi_SQL += ", " + Cat_Padron.Campo_Nombre + "= '" + Registro[Cat_Padron.Campo_Nombre].ToString() + "'";//  6
                                    Mi_SQL += ", " + Cat_Padron.Campo_Genero + "= '" + Registro[Cat_Padron.Campo_Genero].ToString() + "'";//  7
                                    Mi_SQL += ", " + Cat_Padron.Campo_Baja + "= '" + Registro[Cat_Padron.Campo_Baja].ToString() + "'";//  8

                                    //  seccion where
                                    Mi_SQL += " where " + Cat_Padron.Campo_Curp + "= '" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";

                                    Cmd.Connection = MyConnection;
                                    Cmd.CommandText = Mi_SQL;
                                    Cmd.ExecuteNonQuery();
                                }
                            }

                            //  adeudos o ventas del dia
                            if (Datos.P_Dt_Ventas_Dia != null)
                            {
                                foreach (DataRow Dr_Registro in Datos.P_Dt_Ventas_Dia.Rows)
                                {
                                    //Consecutivo = Obtener_ID_Consecutivo_Numerico("adeudos", "conse", " curp = '" + Dr_Registro["curp"].ToString() + "'", StrConexion);

                                    Dt_Adeudos = new DataTable();
                                    //  se consulta la listdeudor del contribuyente
                                    Mi_SQL = "select * from adeudos where fecha ='" + Convert.ToDateTime(Dr_Registro["fecha"].ToString()).ToString("yyyy-MM-dd") + "'"
                                            + " and tipo ='" + Dr_Registro["tipo"].ToString() + "'"
                                            + " and lista ='" + Dr_Registro["lista"].ToString() + "'"
                                            + " and conse= '" + Dr_Registro["conse"].ToString() + "'"
                                            + " and hora = '" + Dr_Registro["hora"].ToString() + "'"
                                            + " COLLATE latin1_general_ci";

                                    Cmd.Connection = MyConnection;
                                    Cmd.CommandText = Mi_SQL;

                                    using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                                    {
                                        Adap.SelectCommand = Cmd;
                                        Adap.Fill(Dt_Adeudos);
                                    }

                                    if (Dt_Adeudos != null && Dt_Adeudos.Rows.Count == 0)
                                    {
                                        Mi_SQL = "INSERT INTO adeudos (";
                                        Mi_SQL += "ano";//1
                                        Mi_SQL += ", tipo";//2
                                        Mi_SQL += ", lista";//3
                                        Mi_SQL += ", curp";//4
                                        Mi_SQL += ", clave";//5
                                        Mi_SQL += ", fecha";//6
                                        Mi_SQL += ", unidad";//7
                                        //Mi_SQL += ", unidad2";//8
                                        Mi_SQL += ", tarifa";//9
                                        Mi_SQL += ", cantidad";//10
                                        Mi_SQL += ", cantidad2";//11
                                        Mi_SQL += ", importe";//12
                                        Mi_SQL += ", saldo";//13
                                        Mi_SQL += ", concepto";//14
                                        Mi_SQL += ", concepto2";//15
                                        Mi_SQL += ", referencia1";//16
                                        Mi_SQL += ", referencia2";//17
                                        Mi_SQL += ", referencia3";//18
                                        //Mi_SQL += ", pagar";//19
                                        Mi_SQL += ", impopago";//20
                                        Mi_SQL += ", captura";//21
                                        Mi_SQL += ", hora";//22
                                        Mi_SQL += ", user";//23
                                        Mi_SQL += ", maquina";//24
                                        Mi_SQL += ", conse";//25
                                        //Mi_SQL += ", requiere";//26
                                        //Mi_SQL += ", origen";//27
                                        Mi_SQL += ", porcond";//28
                                        Mi_SQL += ", feccond";//29
                                        //Mi_SQL += ", usercond";//30
                                        //Mi_SQL += ", refcond";//31
                                        Mi_SQL += ", hon1";//32
                                        Mi_SQL += ", hon2";//33
                                        Mi_SQL += ", hon3";//34
                                        Mi_SQL += ", recargosm";//35
                                        Mi_SQL += ", fec1";//36
                                        Mi_SQL += ", fec2";//37
                                        Mi_SQL += ", fec3";//38
                                        Mi_SQL += ", fecham";//39
                                        Mi_SQL += ")";
                                        Mi_SQL += " VALUES (";//****************************************
                                        Mi_SQL += "'" + Dr_Registro["ano"].ToString() + "'";//  Año 1
                                        Mi_SQL += ", '" + Dr_Registro["tipo"].ToString() + "'";//  tipo (1502) 2
                                        Mi_SQL += ", '" + Dr_Registro["lista"].ToString() + "'"; // lista 3
                                        Mi_SQL += ", '" + Dr_Registro["curp"].ToString() + "'";//    curp 4
                                        Mi_SQL += ", '" + Dr_Registro["clave"].ToString() + "'";//    clave del producto    5
                                        Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro["fecha"].ToString()).ToString("yyyy-MM-dd") + "'";// fecha   6
                                        Mi_SQL += ", '" + Dr_Registro["unidad"].ToString() + "'"; // unidad  7
                                        Mi_SQL += ", '" + Dr_Registro["tarifa"].ToString() + "'";//   tarifa 9
                                        Mi_SQL += ", '" + Dr_Registro["Cantidad"].ToString() + "'";// cantidad 10
                                        Mi_SQL += ", '" + Dr_Registro["Cantidad2"].ToString() + "'";  //  cantidad "2" 11
                                        Mi_SQL += ", '" + Dr_Registro["importe"].ToString() + "'";//   importe 12
                                        Mi_SQL += ", '" + Dr_Registro["saldo"].ToString() + "'";//    saldo   13
                                        Mi_SQL += ", '" + Dr_Registro["concepto"].ToString() + "'";//    concepto 14
                                        Mi_SQL += ", '" + Dr_Registro["concepto2"].ToString() + "'"; // concepto "2"    15
                                        Mi_SQL += ", '" + Dr_Registro["referencia1"].ToString() + "'"; // referencia "1" 16
                                        Mi_SQL += ", '" + Dr_Registro["referencia2"].ToString() + "'";// referencia "2" 17
                                        Mi_SQL += ", '" + Dr_Registro["referencia3"].ToString() + "'";// referencia "3" 18
                                        Mi_SQL += ", '" + Dr_Registro["impopago"].ToString() + "'";//   impopago 20 
                                        Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro["captura"].ToString()).ToString("yyyy-MM-dd") + "'";// captura 21
                                        Mi_SQL += ", '" + Dr_Registro["hora"].ToString() + "'";//    hora 22
                                        Mi_SQL += ", '" + Dr_Registro["user"].ToString() + "'";//  user 23
                                        Mi_SQL += ", '" + Dr_Registro["maquina"].ToString() + "'";//    maquina 24
                                        Mi_SQL += ", '" + Dr_Registro["conse"].ToString() + "'";//    conse 25
                                        Mi_SQL += ", '" + Dr_Registro["porcond"].ToString() + "'";// porcond 28
                                        Mi_SQL += ", '1900-01-01'";// feccond 29

                                        Mi_SQL += ", '" + Dr_Registro["hon1"].ToString() + "'";// hon1 32
                                        Mi_SQL += ", '" + Dr_Registro["hon2"].ToString() + "'";// hon2 33
                                        Mi_SQL += ", '" + Dr_Registro["hon3"].ToString() + "'";// hon3 34
                                        Mi_SQL += ", '" + Dr_Registro["recargosm"].ToString() + "'";// recargosm 35
                                        Mi_SQL += ", '1900-01-01'";// fec1 36
                                        Mi_SQL += ", '1900-01-01'";// fec2 37
                                        Mi_SQL += ", '1900-01-01'";// fec2 38
                                        Mi_SQL += ", '1900-01-01'";// fecham 39
                                        Mi_SQL += ")";

                                        Cmd.Connection = MyConnection;
                                        Cmd.CommandText = Mi_SQL;
                                        Cmd.ExecuteNonQuery();

                                    }// fin del if Dt_Adeudos
                                }
                            }

                            Transaccion.Commit();

                            //  termina el proceso de enviar datos al deudorcad
                            MyConnection.Close();
                        }
                    }
                    #endregion
                }
                //////////////////////////////////////////////////
                //////////////////////////////////////////////////
                //////////////////////////////////////////////////
                else
                {
                    #region version 5

                    foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                    {
                        StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                        StrConexion += "default command timeout = 1200000; ";
                    }

                    Obj_Conexion = new MySqlConnection(StrConexion);
                    Obj_Conexion.Open();

                    Obj_Transaccion = Obj_Conexion.BeginTransaction();
                    Comando_Mysql.Connection = Obj_Conexion;
                    Comando_Mysql.Transaction = Obj_Transaccion;
                    Comando_Mysql.CommandType = CommandType.Text;
                    ////////////////////////////////////////////////////


                    /*  se ingresan los nuevos usuarios del padron */
                    if (Datos.P_Dt_Padron_Nuevos != null)
                    {
                        foreach (DataRow Registro in Datos.P_Dt_Padron_Nuevos.Rows)
                        {

                            //  se consultara que el registro no se encuentre registrado en la bd del deudorcad
                            Mi_SQL = "select * from padron where curp ='" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";
                            Comando_Mysql.CommandText = Mi_SQL.ToString();
                            MySqlDataReader Reader = Comando_Mysql.ExecuteReader();

                            if (Reader != null && Reader.HasRows == true)
                            {
                                Dt_Contribuyente.Load(Reader);
                            }

                            Reader.Close();

                            if (Dt_Contribuyente.Rows.Count == 0)
                            {
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
                                Mi_SQL += ")";
                                Mi_SQL += " values ";
                                Mi_SQL += "(";
                                Mi_SQL += "'" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";//   1
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Rfc].ToString() + "'";//  2
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Tipo].ToString() + "'";// 3
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Apellido_Paterno].ToString() + "'";// 4
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Apellido_Materno].ToString() + "'";// 5
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Nombre].ToString() + "'";//   6
                                Mi_SQL += ", '0'"; //   edonac  default "0"// 7
                                Mi_SQL += ", '" + Convert.ToDateTime(Registro[Cat_Padron.Campo_Fecha_Nacimiento].ToString()).ToString("yyyy-MM-dd") + "'";//  8
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Genero].ToString() + "'";//   9
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Consecutivo].ToString() + "'";// consecutivo //   10
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Maquina].ToString() + "'";//   11
                                Mi_SQL += ", '" + Convert.ToDateTime(Registro[Cat_Padron.Campo_Captura].ToString()).ToString("yyyy-MM-dd") + "'";//  12
                                Mi_SQL += ", '" + Convert.ToDateTime(Registro[Cat_Padron.Campo_Captura].ToString()).ToString("hh:mm") + "'";//   13
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Usuario].ToString() + "'";//  14
                                Mi_SQL += ", '" + Registro[Cat_Padron.Campo_Baja].ToString() + "'";// Baja //   15
                                Mi_SQL += ", 'N'"; //   interno1  default "N"// 16
                                Mi_SQL += ")";


                                Comando_Mysql.CommandText = Mi_SQL;
                                Comando_Mysql.ExecuteNonQuery();
                            }

                            //  se reinicia la variable Dt_Contribuyente
                            Dt_Contribuyente = new DataTable();
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////

                    //  se ingresan las direcciones de los nuevos contribuyentes
                    if (Datos.P_Dt_Padron_Nuevos_Direcciones != null)
                    {
                        foreach (DataRow Registro in Datos.P_Dt_Padron_Nuevos_Direcciones.Rows)
                        {
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
                            Mi_SQL += "'" + Registro["curp"].ToString() + "'";//1 curp
                            Mi_SQL += ", '0'";//2 numcalle valor por default 0 
                            Mi_SQL += ", '" + Registro["numext"].ToString() + "'";//3 numext 
                            Mi_SQL += ", '" + Registro["numint"].ToString() + "'";//4 numint
                            Mi_SQL += ", '0'";//5 numcol valor default 0
                            Mi_SQL += ", '" + Registro["nomcol"].ToString() + "'";//6 nomcol valor ''
                            Mi_SQL += ", '" + Registro["cp"].ToString() + "'";// 7 cp
                            Mi_SQL += ", '" + Registro["ciudad"].ToString() + "'";//8 ciudad
                            Mi_SQL += ", '10'";//9 edo en numero
                            Mi_SQL += ", '" + Registro["nomedo"].ToString() + "'";//10 nomedo estado con letra 
                            Mi_SQL += ", 'MEXICO'";//11 pais
                            //Mi_SQL += ", '" + "'";//12 tel1
                            Mi_SQL += ", '" + Convert.ToDateTime(Registro["fechamov"].ToString()).ToString("yyyy-MM-dd") + "'";//13 fechamov
                            Mi_SQL += ", '1'";//14 numnota default 1
                            Mi_SQL += ", '0'";//15 ano default 0
                            Mi_SQL += ", '1'";//16 tipom default 1   
                            Mi_SQL += ", '" + Registro["maquina"].ToString() + "'";//17 maquina 
                            Mi_SQL += ", '" + Convert.ToDateTime(Registro["captura"].ToString()).ToString("yyyy-MM-dd") + "'";//18 captura 
                            Mi_SQL += ", '" + Registro["hora"].ToString() + "'";//19 hora
                            Mi_SQL += ", '" + Registro["user"].ToString() + "'";//20 user
                            Mi_SQL += ", '" + Registro["nomcalle"].ToString() + "'";//21 nomcalle
                            Mi_SQL += ")";

                            Comando_Mysql.CommandText = Mi_SQL;
                            Comando_Mysql.ExecuteNonQuery();
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////

                    //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES
                    if (Datos.P_Dt_Listdeudor_Nuevos != null)
                    {
                        foreach (DataRow Registro in Datos.P_Dt_Listdeudor_Nuevos.Rows)
                        {
                            //  se consulta la listdeudor del contribuyente
                            Mi_SQL = "select * from listdeudor where curp ='" + Registro["curp"].ToString() + "'"
                                    + " and tipo ='" + Registro["tipo"].ToString() + "'"
                                    + " and lista ='" + Registro["lista"].ToString() + "'";

                            Comando_Mysql.CommandText = Mi_SQL.ToString();
                            MySqlDataReader Reader = Comando_Mysql.ExecuteReader();

                            if (Reader != null && Reader.HasRows == true)
                            {
                                Dt_Contribuyente.Load(Reader);
                            }

                            Reader.Close();

                            if (Dt_Contribuyente.Rows.Count == 0)
                            {

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
                                Mi_SQL += "'" + Registro["tipo"].ToString() + "'";//  1
                                Mi_SQL += ", '" + Registro["lista"].ToString() + "'";//    2
                                Mi_SQL += ", '" + Registro["curp"].ToString() + "'";//    3
                                Mi_SQL += ", '" + Registro["tipol"].ToString() + "'";//    4
                                Mi_SQL += ", '" + Registro["referencia1"].ToString() + "'";//    5
                                Mi_SQL += ", '" + Registro["referencia2"].ToString() + "'";//    6
                                Mi_SQL += ", '" + Convert.ToDateTime(Registro["registro"].ToString()).ToString("yyyy-MM-dd") + "'";//    7
                                Mi_SQL += ", '" + Convert.ToDateTime(Registro["baja"].ToString()).ToString("yyyy-MM-dd") + "'";//    8
                                Mi_SQL += ", '" + Registro["userr"].ToString() + "'";//    9
                                //Mi_SQL += ", '" + "'";//    10
                                Mi_SQL += ", '" + Registro["clave"].ToString() + "'";//    11
                                Mi_SQL += ", '" + Registro["cantidad"].ToString() + "'";//    12
                                Mi_SQL += ", '" + Registro["observa"].ToString() + "'";//    13
                                Mi_SQL += ", '" + Registro["cantidad2"].ToString() + "'";//    14
                                Mi_SQL += ", '" + Registro["interno1"].ToString() + "'";//    15
                                Mi_SQL += ", '" + Registro["conse"].ToString() + "'";//    16
                                Mi_SQL += ", '" + Registro["conspalm"].ToString() + "'";//    17
                                Mi_SQL += ", '" + Registro["conspalm2"].ToString() + "'";//    18
                                Mi_SQL += ")";

                                Comando_Mysql.CommandText = Mi_SQL;
                                Comando_Mysql.ExecuteNonQuery();
                            }

                            Dt_Contribuyente = new DataTable();
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////


                    //  SE INSERTA LA INFORMACION EN LA LISTA DE DEUDORES que no existen en la tabla
                    if (Datos.P_Dt_Listdeudor_ != null)
                    {
                        foreach (DataRow Registro in Datos.P_Dt_Listdeudor_.Rows)
                        {

                            //  se consulta la listdeudor del contribuyente
                            Mi_SQL = "select * from listdeudor where curp ='" + Registro["curp"].ToString() + "'"
                                    + " and tipo ='" + Registro["tipo"].ToString() + "'"
                                    + " and lista ='" + Registro["lista"].ToString() + "'";

                            Comando_Mysql.CommandText = Mi_SQL.ToString();
                            MySqlDataReader Reader = Comando_Mysql.ExecuteReader();

                            if (Reader != null && Reader.HasRows == true)
                            {
                                Dt_Contribuyente.Load(Reader);
                            }

                            Reader.Close();

                            if (Dt_Contribuyente.Rows.Count == 0)
                            {
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
                                Mi_SQL += "'" + Registro["tipo"].ToString() + "'";//  1
                                Mi_SQL += ", '" + Registro["lista"].ToString() + "'";//    2
                                Mi_SQL += ", '" + Registro["curp"].ToString() + "'";//    3
                                Mi_SQL += ", '" + Registro["tipol"].ToString() + "'";//    4
                                Mi_SQL += ", '" + Registro["referencia1"].ToString() + "'";//    5
                                Mi_SQL += ", '" + Registro["referencia2"].ToString() + "'";//    6
                                Mi_SQL += ", '" + Convert.ToDateTime(Registro["registro"].ToString()).ToString("yyyy-MM-dd") + "'";//    7
                                Mi_SQL += ", '" + Convert.ToDateTime(Registro["baja"].ToString()).ToString("yyyy-MM-dd") + "'";//    8
                                Mi_SQL += ", '" + Registro["userr"].ToString() + "'";//    9
                                //Mi_SQL += ", '" + "'";//    10
                                Mi_SQL += ", '" + Registro["clave"].ToString() + "'";//    11
                                Mi_SQL += ", '" + Registro["cantidad"].ToString() + "'";//    12
                                Mi_SQL += ", '" + Registro["observa"].ToString() + "'";//    13
                                Mi_SQL += ", '" + Registro["cantidad2"].ToString() + "'";//    14
                                Mi_SQL += ", '" + Registro["interno1"].ToString() + "'";//    15
                                Mi_SQL += ", '" + Registro["conse"].ToString() + "'";//    16
                                Mi_SQL += ", '" + Registro["conspalm"].ToString() + "'";//    17
                                Mi_SQL += ", '" + Registro["conspalm2"].ToString() + "'";//    18
                                Mi_SQL += ")";
                                Comando_Mysql.CommandText = Mi_SQL;
                                Comando_Mysql.ExecuteNonQuery();
                            }

                            Dt_Contribuyente = new DataTable();
                        }
                    }
                    /////////////////////////////////////////////////////////////////


                    /*  se actualizan los usuarios del padron  */
                    if (Datos.P_Dt_Padron_Actualizacion != null)
                    {
                        foreach (DataRow Registro in Datos.P_Dt_Padron_Actualizacion.Rows)
                        {
                            Mi_SQL = "UPDATE " + Cat_Padron.Tabla + " SET ";


                            Mi_SQL += Cat_Padron.Campo_Curp + "= '" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";//  1
                            Mi_SQL += ", " + Cat_Padron.Campo_Tipo + "= '" + Registro[Cat_Padron.Campo_Tipo].ToString() + "'";//  3
                            Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Paterno + "= '" + Registro[Cat_Padron.Campo_Apellido_Paterno].ToString() + "'";//  4
                            Mi_SQL += ", " + Cat_Padron.Campo_Apellido_Materno + "= '" + Registro[Cat_Padron.Campo_Apellido_Materno].ToString() + "'";//  5
                            Mi_SQL += ", " + Cat_Padron.Campo_Nombre + "= '" + Registro[Cat_Padron.Campo_Nombre].ToString() + "'";//  6
                            Mi_SQL += ", " + Cat_Padron.Campo_Genero + "= '" + Registro[Cat_Padron.Campo_Genero].ToString() + "'";//  7
                            Mi_SQL += ", " + Cat_Padron.Campo_Baja + "= '" + Registro[Cat_Padron.Campo_Baja].ToString() + "'";//  8

                            //  seccion where
                            Mi_SQL += " where " + Cat_Padron.Campo_Curp + "= '" + Registro[Cat_Padron.Campo_Curp].ToString() + "'";

                            Comando_Mysql.CommandText = Mi_SQL;
                            Comando_Mysql.ExecuteNonQuery();
                        }
                    }
                    /////////////////////////////////////////////////////////////////

                    if (Datos.P_Dt_Ventas_Dia != null)
                    {
                        foreach (DataRow Dr_Registro in Datos.P_Dt_Ventas_Dia.Rows)
                        {

                            Mi_SQL = "select * from adeudos where fecha ='" + Convert.ToDateTime(Dr_Registro["fecha"].ToString()).ToString("yyyy-MM-dd") + "'"
                                           + " and tipo ='" + Dr_Registro["tipo"].ToString() + "'"
                                           + " and lista ='" + Dr_Registro["lista"].ToString() + "'"
                                           + " and conse= '" + Dr_Registro["conse"].ToString() + "'"
                                           + " and hora = '" + Dr_Registro["hora"].ToString() + "'";

                            Comando_Mysql.CommandText = Mi_SQL.ToString();
                            MySqlDataReader Reader = Comando_Mysql.ExecuteReader();

                            if (Reader != null && Reader.HasRows == true)
                            {
                                Dt_Adeudos.Load(Reader);
                            }

                            Reader.Close();


                            if (Dt_Adeudos != null && Dt_Adeudos.Rows.Count == 0)
                            {
                                Mi_SQL = "INSERT INTO adeudos (";
                                Mi_SQL += "ano";//1
                                Mi_SQL += ", tipo";//2
                                Mi_SQL += ", lista";//3
                                Mi_SQL += ", curp";//4
                                Mi_SQL += ", clave";//5
                                Mi_SQL += ", fecha";//6
                                Mi_SQL += ", unidad";//7
                                //Mi_SQL += ", unidad2";//8
                                Mi_SQL += ", tarifa";//9
                                Mi_SQL += ", cantidad";//10
                                Mi_SQL += ", cantidad2";//11
                                Mi_SQL += ", importe";//12
                                Mi_SQL += ", saldo";//13
                                Mi_SQL += ", concepto";//14
                                Mi_SQL += ", concepto2";//15
                                Mi_SQL += ", referencia1";//16
                                Mi_SQL += ", referencia2";//17
                                Mi_SQL += ", referencia3";//18
                                //Mi_SQL += ", pagar";//19
                                Mi_SQL += ", impopago";//20
                                Mi_SQL += ", captura";//21
                                Mi_SQL += ", hora";//22
                                Mi_SQL += ", user";//23
                                Mi_SQL += ", maquina";//24
                                Mi_SQL += ", conse";//25
                                //Mi_SQL += ", requiere";//26
                                //Mi_SQL += ", origen";//27
                                Mi_SQL += ", porcond";//28
                                Mi_SQL += ", feccond";//29
                                //Mi_SQL += ", usercond";//30
                                //Mi_SQL += ", refcond";//31
                                Mi_SQL += ", hon1";//32
                                Mi_SQL += ", hon2";//33
                                Mi_SQL += ", hon3";//34
                                Mi_SQL += ", recargosm";//35
                                Mi_SQL += ", fec1";//36
                                Mi_SQL += ", fec2";//37
                                Mi_SQL += ", fec3";//38
                                Mi_SQL += ", fecham";//39
                                Mi_SQL += ")";
                                Mi_SQL += " VALUES (";//****************************************
                                Mi_SQL += "'" + Dr_Registro["ano"].ToString() + "'";//  Año 1
                                Mi_SQL += ", '" + Dr_Registro["tipo"].ToString() + "'";//  tipo (1502) 2
                                Mi_SQL += ", '" + Dr_Registro["lista"].ToString() + "'"; // lista 3
                                Mi_SQL += ", '" + Dr_Registro["curp"].ToString() + "'";//    curp 4
                                Mi_SQL += ", '" + Dr_Registro["clave"].ToString() + "'";//    clave del producto    5
                                Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro["fecha"].ToString()).ToString("yyyy-MM-dd") + "'";// fecha   6
                                Mi_SQL += ", '" + Dr_Registro["unidad"].ToString() + "'"; // unidad  7
                                Mi_SQL += ", '" + Dr_Registro["tarifa"].ToString() + "'";//   tarifa 9
                                Mi_SQL += ", '" + Dr_Registro["Cantidad"].ToString() + "'";// cantidad 10
                                Mi_SQL += ", '" + Dr_Registro["Cantidad2"].ToString() + "'";  //  cantidad "2" 11
                                Mi_SQL += ", '" + Dr_Registro["importe"].ToString() + "'";//   importe 12
                                Mi_SQL += ", '" + Dr_Registro["saldo"].ToString() + "'";//    saldo   13
                                Mi_SQL += ", '" + Dr_Registro["concepto"].ToString() + "'";//    concepto 14
                                Mi_SQL += ", '" + Dr_Registro["concepto2"].ToString() + "'"; // concepto "2"    15
                                Mi_SQL += ", '" + Dr_Registro["referencia1"].ToString() + "'"; // referencia "1" 16
                                Mi_SQL += ", '" + Dr_Registro["referencia2"].ToString() + "'";// referencia "2" 17
                                Mi_SQL += ", '" + Dr_Registro["referencia3"].ToString() + "'";// referencia "3" 18
                                Mi_SQL += ", '" + Dr_Registro["impopago"].ToString() + "'";//   impopago 20 
                                Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro["captura"].ToString()).ToString("yyyy-MM-dd") + "'";// captura 21
                                Mi_SQL += ", '" + Dr_Registro["hora"].ToString() + "'";//    hora 22
                                Mi_SQL += ", '" + Dr_Registro["user"].ToString() + "'";//  user 23
                                Mi_SQL += ", '" + Dr_Registro["maquina"].ToString() + "'";//    maquina 24
                                Mi_SQL += ", '" + Dr_Registro["conse"].ToString() + "'";//    conse 25
                                Mi_SQL += ", '" + Dr_Registro["porcond"].ToString() + "'";// porcond 28
                                Mi_SQL += ", '1900-01-01'";// feccond 29

                                Mi_SQL += ", '" + Dr_Registro["hon1"].ToString() + "'";// hon1 32
                                Mi_SQL += ", '" + Dr_Registro["hon2"].ToString() + "'";// hon2 33
                                Mi_SQL += ", '" + Dr_Registro["hon3"].ToString() + "'";// hon3 34
                                Mi_SQL += ", '" + Dr_Registro["recargosm"].ToString() + "'";// recargosm 35
                                Mi_SQL += ", '1900-01-01'";// fec1 36
                                Mi_SQL += ", '1900-01-01'";// fec2 37
                                Mi_SQL += ", '1900-01-01'";// fec2 38
                                Mi_SQL += ", '1900-01-01'";// fecham 39
                                Mi_SQL += ")";

                                Comando_Mysql.CommandText = Mi_SQL;
                                Comando_Mysql.ExecuteNonQuery();

                            }
                        }
                    }
                    /////////////////////////////////////////////


                    Obj_Transaccion.Commit();
                    Obj_Conexion.Close();
                    ////////////////////////////////////////////////
                    #endregion
                }
                //////////////////////////////////////////////////
                //////////////////////////////////////////////////
                //////////////////////////////////////////////////

                Alta_Exitosa = true;

            }
            catch (Exception E)
            {
                if (Version_Bd4 == true) Transaccion.Rollback();
                else Obj_Transaccion.Rollback();

                throw new Exception("Enviar_Ventas_Dia: " + E.Message);
            }
            finally
            {
                //Obj_Conexion.Close();// version 5
                //if (Obj_Conexion.State == ConnectionState.Open) Obj_Conexion.Close();
            }
        }



        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Enviar_Ventas_Dia_Internet
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 04/Marzo/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Enviar_Ventas_Dia_Internet(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();
            String StrConexion = "";
            String Cuenta_Museo = "";
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


                foreach (DataRow Registro in Datos.P_Dt_Parametros.Rows)
                {
                    StrConexion = "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
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


                foreach (DataRow Dr_Registro in Datos.P_Dt_Ventas_Dia.Rows)
                {
                    //Consecutivo = Obtener_ID_Consecutivo_Numerico("adeudos", "conse", " curp = '" + Dr_Registro["curp"].ToString() + "'", StrConexion);

                    Mi_SQL = "INSERT INTO adeudos (";
                    Mi_SQL += "ano";//1
                    Mi_SQL += ", tipo";//2
                    Mi_SQL += ", lista";//3
                    Mi_SQL += ", curp";//4
                    Mi_SQL += ", clave";//5
                    Mi_SQL += ", fecha";//6
                    Mi_SQL += ", unidad";//7
                    //Mi_SQL += ", unidad2";//8
                    Mi_SQL += ", tarifa";//9
                    Mi_SQL += ", cantidad";//10
                    Mi_SQL += ", cantidad2";//11
                    Mi_SQL += ", importe";//12
                    Mi_SQL += ", saldo";//13
                    Mi_SQL += ", concepto";//14
                    Mi_SQL += ", concepto2";//15
                    Mi_SQL += ", referencia1";//16
                    Mi_SQL += ", referencia2";//17
                    Mi_SQL += ", referencia3";//18
                    //Mi_SQL += ", pagar";//19
                    Mi_SQL += ", impopago";//20
                    Mi_SQL += ", captura";//21
                    Mi_SQL += ", hora";//22
                    Mi_SQL += ", user";//23
                    Mi_SQL += ", maquina";//24
                    Mi_SQL += ", conse";//25
                    //Mi_SQL += ", requiere";//26
                    //Mi_SQL += ", origen";//27
                    Mi_SQL += ", porcond";//28
                    Mi_SQL += ", feccond";//29
                    //Mi_SQL += ", usercond";//30
                    //Mi_SQL += ", refcond";//31
                    Mi_SQL += ", hon1";//32
                    Mi_SQL += ", hon2";//33
                    Mi_SQL += ", hon3";//34
                    Mi_SQL += ", recargosm";//35
                    Mi_SQL += ", fec1";//36
                    Mi_SQL += ", fec2";//37
                    Mi_SQL += ", fec3";//38
                    Mi_SQL += ", fecham";//39
                    Mi_SQL += ")";
                    Mi_SQL += " VALUES (";//****************************************
                    Mi_SQL += "'" + Dr_Registro["ano"].ToString() + "'";//  Año 1
                    Mi_SQL += ", '" + Dr_Registro["tipo"].ToString() + "'";//  tipo (1502) 2
                    Mi_SQL += ", '" + Dr_Registro["lista"].ToString() + "'"; // lista 3
                    Mi_SQL += ", '" + Dr_Registro["curp"].ToString() + "'";//    curp 4
                    Mi_SQL += ", '" + Dr_Registro["clave"].ToString() + "'";//    clave del producto    5
                    Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro["fecha"].ToString()).ToString("yyyy-MM-dd") + "'";// fecha   6
                    Mi_SQL += ", '" + Dr_Registro["unidad"].ToString() + "'"; // unidad  7
                    Mi_SQL += ", '" + Dr_Registro["tarifa"].ToString() + "'";//   tarifa 9
                    Mi_SQL += ", '" + Dr_Registro["Cantidad"].ToString() + "'";// cantidad 10
                    Mi_SQL += ", '" + Dr_Registro["Cantidad2"].ToString() + "'";  //  cantidad "2" 11
                    Mi_SQL += ", '" + Dr_Registro["importe"].ToString() + "'";//   importe 12
                    Mi_SQL += ", '" + Dr_Registro["saldo"].ToString() + "'";//    saldo   13
                    Mi_SQL += ", '" + Dr_Registro["concepto"].ToString() + "'";//    concepto 14
                    Mi_SQL += ", '" + Dr_Registro["concepto2"].ToString() + "'"; // concepto "2"    15
                    Mi_SQL += ", '" + Dr_Registro["referencia1"].ToString() + "'"; // referencia "1" 16
                    Mi_SQL += ", '" + Dr_Registro["referencia2"].ToString() + "'";// referencia "2" 17
                    Mi_SQL += ", '" + Dr_Registro["referencia3"].ToString() + "'";// referencia "3" 18
                    Mi_SQL += ", '" + Dr_Registro["impopago"].ToString() + "'";//   impopago 20 
                    Mi_SQL += ", '" + Convert.ToDateTime(Dr_Registro["captura"].ToString()).ToString("yyyy-MM-dd") + "'";// captura 21
                    Mi_SQL += ", '" + Dr_Registro["hora"].ToString() + "'";//    hora 22
                    Mi_SQL += ", '" + Dr_Registro["user"].ToString() + "'";//  user 23
                    Mi_SQL += ", '" + Dr_Registro["maquina"].ToString() + "'";//    maquina 24
                    Mi_SQL += ", '" + Dr_Registro["conse"].ToString() + "'";//    conse 25
                    Mi_SQL += ", '" + Dr_Registro["porcond"].ToString() + "'";// porcond 28
                    Mi_SQL += ", '1900-01-01'";// feccond 29

                    Mi_SQL += ", '" + Dr_Registro["hon1"].ToString() + "'";// hon1 32
                    Mi_SQL += ", '" + Dr_Registro["hon2"].ToString() + "'";// hon2 33
                    Mi_SQL += ", '" + Dr_Registro["hon3"].ToString() + "'";// hon3 34
                    Mi_SQL += ", '" + Dr_Registro["recargosm"].ToString() + "'";// recargosm 35
                    Mi_SQL += ", '1900-01-01'";// fec1 36
                    Mi_SQL += ", '1900-01-01'";// fec2 37
                    Mi_SQL += ", '1900-01-01'";// fec2 38
                    Mi_SQL += ", '1900-01-01'";// fecham 39
                    Mi_SQL += ")";

                    Comando_Mysql.CommandText = Mi_SQL;
                    Comando_Mysql.ExecuteNonQuery();

                }

              

                Obj_Transaccion.Commit();
                Alta_Exitosa = true;

            }
            catch (Exception E)
            {
                Obj_Transaccion.Rollback();
                throw new Exception("Enviar_Ventas_Dia: " + E.Message);
            }
            finally
            {
                if (Obj_Conexion.State == ConnectionState.Open) Obj_Conexion.Close();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Actualizar_Historico
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Datos: Instancia de Cls_Ope_Solicitud_Facturacion_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Actualizar_Historico(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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
                if (Datos.P_Estatus == true)
                {
                    Conexion.HelperGenerico.Iniciar_Transaccion();
                }

                Mi_SQL = "UPDATE " + Ope_Historico_Exportacion.Tabla + " SET ";
                Mi_SQL += Ope_Historico_Exportacion.Campo_Estatus_Exportacion + "= 'S'";
                Mi_SQL += ", " + Ope_Historico_Exportacion.Campo_Comentarios + " = 'Turno cerrado " + Datos.P_No_Turno + ".'";

                //  Seccion where
                Mi_SQL += " where DATE_FORMAT(" + Ope_Historico_Exportacion.Campo_Fecha + ",'%Y-%m-%d') ='" + Datos.P_Fecha_Venta + "'";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());


                Mi_SQL = "UPDATE ope_historico_padron SET ";
                Mi_SQL += " Estatus = 'S'";

                //  Seccion where
                Mi_SQL += " where DATE_FORMAT(Fecha ,'%Y-%m-%d') ='" + Datos.P_Fecha_Venta + "'";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());


                Alta_Exitosa = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Insertar_Historico: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        private static Int64 Obtener_ID_Consecutivo_Numerico(String Tabla, String Campo, String Filtro, String StrConexion)
        {
            Int64 Id = 1;
            DataTable Dt_Consulta = new DataTable();
            MySqlConnection Obj_Conexion = new MySqlConnection(StrConexion);
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();

            try
            {
                Obj_Conexion.Open();
                String Mi_SQL = "SELECT MAX(" + Campo + ") FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }

                Obj_Adaptador = new MySqlDataAdapter(Mi_SQL, Obj_Conexion);
                MySqlCommandBuilder ComandoBuilder = new MySqlCommandBuilder(Obj_Adaptador);
                DataSet Ds_tabla_Origen = new DataSet();
                Obj_Adaptador.Fill(Ds_tabla_Origen);

                Dt_Consulta = Ds_tabla_Origen.Tables[0];

                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                {
                    Id = (Convert.ToInt64(Dt_Consulta.Rows[0][Campo].ToString()) + 1);
                }

            }
            catch (Exception Ex)
            {
                new Exception(Ex.Message);
            }
            finally
            {
                Obj_Conexion.Close();
            }
            return Id;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Insertar_Solicitud_Ventas_Dia
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 28/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Solicitud_Ventas_Dia(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            String Mi_SQL = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            Int64 Consecutivo = 1;
            DataTable Dt_Consulta = new DataTable();

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

                Mi_SQL = "delete from adeudos where DATE_FORMAT(fecha,'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "' and curp = '" + Datos.P_Cuenta_Momias + "'";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }

            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Datos"></param>
        public static void Actualizar_Venta(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            DataTable Dt_Consulta = new DataTable();

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
                string No_Venta = Datos.P_Dt_Solicitud.Rows[0]["No_Venta"].ToString();

                Mi_SQL.Append("UPDATE " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles);
                Mi_SQL.Append(" SET " + Ope_Ventas_Detalles.Campo_Estatus_Solicitud + " = 'S'");
                Mi_SQL.Append(" WHERE " + Ope_Ventas_Detalles.Campo_No_Venta + "= '" + No_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        /// <summary>
        /// Nombre: Actualizar_Referencias_Locales
        /// 
        /// Descripción: Método que actualiza las referencias locales
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 29 septiembre 2015 12:31 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static void Actualizar_Referencias_Locales(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            DataTable Dt_Consulta = new DataTable();

           
            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("UPDATE " + " listdeudor ");
                Mi_SQL.Append(" SET ");
                Mi_SQL.Append(" listdeudor.referencia1	= '" + Datos.P_Referencia1_Actualizacion  + "'" );
                Mi_SQL.Append(",listdeudor.referencia2 = '" + Datos.P_Referencia2_Actualizacion + "'");

                //  filtros
                Mi_SQL.Append(" WHERE curp = '" + Datos.P_Curp + "' ");
                Mi_SQL.Append(" AND listdeudor.tipo = '" +Datos.P_Tipo + "'");
                Mi_SQL.Append(" AND listdeudor.lista = '" +Datos.P_Lista + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        /// <summary>
        /// Nombre: Actualizar_Referencias_Locales
        /// 
        /// Descripción: Método que actualiza las referencias locales
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 29 septiembre 2015 12:31 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static void Actualizar_Referencias_Adeudos_Locales(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            DataTable Dt_Consulta = new DataTable();


            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("UPDATE " + " adeudos ");
                Mi_SQL.Append(" SET ");
                Mi_SQL.Append("referencia1 = '" + Datos.P_Referencia1 + "', referencia2 = '" + Datos.P_Referencia2 + "'");
                
                //  filtros
                Mi_SQL.Append(" WHERE curp = '" + Datos.P_Curp + "' ");
                Mi_SQL.Append(" AND tipo = '" + Datos.P_Tipo + "'");
                Mi_SQL.Append(" AND lista = '" + Datos.P_Lista + "'");
                Mi_SQL.Append(" and ano = '" + Datos.P_Anio + "'");
                Mi_SQL.Append(" and fecha ='" + Datos.P_Fecha_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Ventas: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }
        #endregion


        #region (Consulta)
        /// <summary>
        /// Nombre: Consultar_Recoleccion
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 28 Febrero 2015 10:02 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Contribuyente(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = new DataTable();//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand(); ;
            DataTable Dt_Padron = new DataTable();

            try
            {
                //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                Consulta_Parametros.P_Parametro_Id =  "00001";
                DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                /////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////
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

                        Mi_SQL.Append("select padron.* ,  listdeudor.referencia1, listdeudor.referencia2 " +
                                ", listdeudor.tipo as Tipo_List" +
                                ", listdeudor.lista as Lista_List" +
                                 " from padron");
                        Mi_SQL.Append(" left outer join listdeudor on listdeudor.curp =");

                        if (!String.IsNullOrEmpty(Datos.P_Curp))
                            Mi_SQL.Append(" padron.curp");
                        else
                            Mi_SQL.Append(" padron.rfc");

                        if (!String.IsNullOrEmpty(Datos.P_Curp))
                            Mi_SQL.Append(" where padron.curp = '" + Datos.P_Curp + "'");
                        else
                            Mi_SQL.Append(" where padron.rfc = '" + Datos.P_Rfc + "'");

                        if (!String.IsNullOrEmpty(Datos.P_Tipo))
                            Mi_SQL.Append(" and listdeudor.tipo ='" + Datos.P_Tipo + "'");

                        if (!String.IsNullOrEmpty(Datos.P_Lista))
                            Mi_SQL.Append(" and listdeudor.lista ='" + Datos.P_Lista + "'");


                        Cmd.Connection = MyConnection;
                        Cmd.CommandText = Mi_SQL.ToString();

                        using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                        {
                            Adap.SelectCommand = Cmd;
                            Adap.Fill(Dt_Contribuyente);
                        }


                        MyConnection.Close();
                    }
                    #endregion
                }
                /////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////
                else
                {
                    #region Version Mysql5

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

                    Mi_SQL.Append("select padron.* ,  listdeudor.referencia1, listdeudor.referencia2 " +
                            ", listdeudor.tipo as Tipo_List" +
                            ", listdeudor.lista as Lista_List" +
                             " from padron");
                    Mi_SQL.Append(" left outer join listdeudor on listdeudor.curp =");

                    if (!String.IsNullOrEmpty(Datos.P_Curp))
                        Mi_SQL.Append(" padron.curp");
                    else
                        Mi_SQL.Append(" padron.rfc");

                    if (!String.IsNullOrEmpty(Datos.P_Curp))
                        Mi_SQL.Append(" where padron.curp = '" + Datos.P_Curp + "'");
                    else
                        Mi_SQL.Append(" where padron.rfc = '" + Datos.P_Rfc + "'");

                    if (!String.IsNullOrEmpty(Datos.P_Tipo))
                        Mi_SQL.Append(" and listdeudor.tipo ='" + Datos.P_Tipo + "'");

                    if (!String.IsNullOrEmpty(Datos.P_Lista))
                        Mi_SQL.Append(" and listdeudor.lista ='" + Datos.P_Lista + "'");


                    Comando_Mysql.CommandText = Mi_SQL.ToString();
                    MySqlDataReader Reader = Comando_Mysql.ExecuteReader();

                    if (Reader != null && Reader.HasRows == true)
                    {
                        Dt_Contribuyente.Load(Reader);
                    }


                    Obj_Conexion.Close();
                    ////////////////////////////////////////////////////////////
                    Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                    #endregion
                }
                /////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////
                /////////////////////////////////////////////////////////////////
            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                //    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Contribuyente;
        }

        /// <summary>
        /// Nombre: Consultar_Recoleccion
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 28 Febrero 2015 10:02 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Contribuyente_Unico(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = new DataTable();//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.
            String StrConexion = "";
            MySqlConnection Obj_Conexion = null;
            MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
            MySqlTransaction Obj_Transaccion = null;
            MySqlCommand Comando_Mysql = new MySqlCommand(); ;

            //Iniciar Transacción
            //Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            { 
                //  consulta de los parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();

                Consulta_Parametros.P_Parametro_Id = "00001";
                DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                ///////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////
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

                        Mi_SQL.Append("select padron.* from padron");

                        if (!String.IsNullOrEmpty(Datos.P_Curp))
                            Mi_SQL.Append(" where padron.curp = '" + Datos.P_Curp + "'");
                        else
                            Mi_SQL.Append(" where padron.rfc = '" + Datos.P_Rfc + "'");

                        Cmd.Connection = MyConnection;
                        Cmd.CommandText = Mi_SQL.ToString();

                        using (OdbcDataAdapter Adap = new OdbcDataAdapter())
                        {
                            DataTable Dt = new DataTable();

                            Adap.SelectCommand = Cmd;
                            Adap.Fill(Dt_Contribuyente);
                        }

                        MyConnection.Close();
                    }

                    #endregion
                }
                ///////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////
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

                    Mi_SQL.Append("select padron.* from padron");


                    if (!String.IsNullOrEmpty(Datos.P_Curp))
                        Mi_SQL.Append(" where padron.curp = '" + Datos.P_Curp + "'");
                    else
                        Mi_SQL.Append(" where padron.rfc = '" + Datos.P_Rfc + "'");

                    Comando_Mysql.CommandText = Mi_SQL.ToString();
                    MySqlDataReader Reader = Comando_Mysql.ExecuteReader();

                    if (Reader != null && Reader.HasRows == true)
                    {
                        Dt_Contribuyente.Load(Reader);
                    }
                    ////////////////////////////////////////////////////////////////////////////

                    Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                    #endregion
                }
                ///////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////
            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //Obj_Conexion.Close();// version 5

                //if (!Transaccion_Activa)
                //{
                //    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Contribuyente;
        }

        /// <summary>
        /// Nombre: Consultar_Contribuyente_Local
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 28 Febrero 2015 10:02 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Contribuyente_Local(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = new DataTable();//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.
            String StrConexion = "";
         

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select padron.* ,  listdeudor.referencia1, listdeudor.referencia2 " +
                        ", listdeudor.tipo as Tipo_List" +
                        ", listdeudor.lista as Lista_List" +
                         " from padron");
                Mi_SQL.Append(" left outer join listdeudor on listdeudor.curp =");

                if (!String.IsNullOrEmpty(Datos.P_Curp))
                    Mi_SQL.Append(" padron.curp");
                else
                    Mi_SQL.Append(" padron.rfc");

                if (!String.IsNullOrEmpty(Datos.P_Curp))
                    Mi_SQL.Append(" where padron.curp = '" + Datos.P_Curp + "'");
                else
                    Mi_SQL.Append(" where padron.rfc = '" + Datos.P_Rfc + "'");

                if (!String.IsNullOrEmpty(Datos.P_Tipo))
                    Mi_SQL.Append(" and listdeudor.tipo ='" + Datos.P_Tipo + "'");

                if (!String.IsNullOrEmpty(Datos.P_Lista))
                    Mi_SQL.Append(" and listdeudor.lista ='" + Datos.P_Lista + "'");


             
                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
        /// <summary>
        /// Nombre: Consultar_Contribuyente_Unico_Local
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 28 Febrero 2015 10:02 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Contribuyente_Unico_Local(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = new DataTable();//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.
            String StrConexion = "";


            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select padron.* from padron");

                if (!String.IsNullOrEmpty(Datos.P_Curp))
                    Mi_SQL.Append(" where padron.curp = '" + Datos.P_Curp + "'");
                else
                    Mi_SQL.Append(" where padron.rfc = '" + Datos.P_Rfc + "'");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
       

        /// <summary>
        /// Nombre: Consultar_Venta
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 28 Febrero 2015 10:28 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Venta(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select cat_productos.nombre ");
                Mi_SQL.Append(", ope_ventas_detalles.Cantidad");
                Mi_SQL.Append(", ope_ventas_detalles.Subtotal as Costo_Producto");
                Mi_SQL.Append(", ope_ventas_detalles.Total");
                Mi_SQL.Append(", ope_ventas_detalles.Producto_ID");
                Mi_SQL.Append(", cat_cajas.comentarios as Nombre_Caja");
                Mi_SQL.Append(", ope_ventas_detalles.No_Venta");
                Mi_SQL.Append(", cat_cajas.Numero_Caja AS Numero_Caja");
                Mi_SQL.Append(", ope_ventas_detalles.No_Venta as Folio_Venta");
                Mi_SQL.Append(", ope_pagos.Usuario_Creo as Nombre_Cajero");
                Mi_SQL.Append(", ope_pagos.Usuario_Creo as Nombre_Cajero");
                //Mi_SQL.Append(", ope_pagos.Forma_Id as Forma_Id");
                Mi_SQL.Append(", ope_ventas_detalles.estatus_solicitud ");
                Mi_SQL.Append(", substring(cat_turnos.Nombre, 1,1) as Turno ");

                //  seccion from
                Mi_SQL.Append(" from ope_ventas_detalles");
                Mi_SQL.Append(" left outer join cat_productos on cat_productos.Producto_Id = ope_ventas_detalles.Producto_Id");
                Mi_SQL.Append(" left outer join ope_pagos on ope_pagos.No_Venta = ope_ventas_detalles.No_Venta ");
                Mi_SQL.Append(" left outer join ope_cajas on ope_cajas.No_Caja = ope_pagos.No_Caja");
                Mi_SQL.Append(" left outer join cat_cajas on cat_cajas.Caja_ID = ope_cajas.Caja_ID");
                Mi_SQL.Append(" left outer join ope_turnos on ope_turnos.No_Turno = ope_cajas.No_Turno");
                Mi_SQL.Append(" left outer join cat_turnos on cat_turnos.Turno_ID = ope_turnos.Turno_ID");

                //    seccion where
                Mi_SQL.Append(" where ope_ventas_detalles.No_Venta = '" + Datos.P_Numero_Venta + "' ");
                Mi_SQL.Append(" and ope_cajas.Estatus = 'ABIERTA'");
                //Mi_SQL.Append(" and ope_ventas_detalles.estatus_solicitud is null");


                //  seccion group by
                Mi_SQL.Append(" group by " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id);

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
        /// <summary>
        /// Nombre: Consultar_Venta
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 28 Febrero 2015 10:28 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable ConsultarPagos_Venta_Individual(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Pagos = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select * from " + Ope_Pagos.Tabla_Ope_Pagos);

                Mi_SQL.Append(" where " + Ope_Pagos.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");
   

                Dt_Pagos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Pagos;
        }



        /// <summary>
        /// Nombre: Consultar_Venta_Internet
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 01 Junio 2015 10:28 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Venta_Internet(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select IFNULL(sum("+Ope_Ventas.Tabla_Ope_Ventas +"." + Ope_Ventas.Campo_Total + ") , 0) as Ventas");
                Mi_SQL.Append(",  " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad);
                Mi_SQL.Append(",  " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id);

                //  seccion from
                Mi_SQL.Append(" from " + Ope_Ventas.Tabla_Ope_Ventas);
                Mi_SQL.Append(" left outer join " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " on ");
                Mi_SQL.Append(" " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta + "=");
                Mi_SQL.Append(" " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta);

                //  seccion where
                Mi_SQL.Append(" where " + Ope_Ventas.Campo_Lugar_Venta + " = 'INTERNET'");
                Mi_SQL.Append(" and DATE_FORMAT(" + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Fecha_Creo + " , '%Y-%m-%d') = " +
                    Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Time_Fecha_Inicio));

                //  seccion gorup by
                Mi_SQL.Append(" group by  " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id);

             
                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }

        /// <summary>
        /// Nombre: Consultar_Venta_Internet
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 01 Junio 2015 10:28 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Venta_Internet_Registradas_Deudorcad(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select * from adeudos ");
                Mi_SQL.Append(" where referencia3 = '" + Datos.P_Referencia3 + "'");
              

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
        /// <summary>
        /// Nombre: Consultar_Venta
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 04 Marzo 2015 11:13 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Tabla_Adeudos(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select * ");

                //  seccion from
                Mi_SQL.Append(" from adeudos");

                //    seccion where
                Mi_SQL.Append(" where DATE_FORMAT(fecha,'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "' ");

                if (!String.IsNullOrEmpty(Datos.P_Cuenta_Momias))
                {
                    Mi_SQL.Append(" and curp ='" + Datos.P_Cuenta_Momias + "'");
                }

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
        /// <summary>
        /// Nombre: Consultar_Cambios_Padron
        /// 
        /// Descripción: Método que consulta los cambios realizados en el padron
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 12 Marzo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Cambios_Padron(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("SELECT padron.*");

                //  seccion from
                Mi_SQL.Append(" from ope_historico_padron");
                Mi_SQL.Append(" left outer join padron on padron.rfc = ope_historico_padron.CURP_RFC");

                //    seccion where
                Mi_SQL.Append(" where DATE_FORMAT(FECHA,'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "' ");
                Mi_SQL.Append(" and Operacion = 'ACTUALIZACION'");
                Mi_SQL.Append(" and estatus is null ");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
        /// <summary>
        /// Nombre: Consultar_Cambios_Padron
        /// 
        /// Descripción: Método que consulta los cambios realizados en el padron
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 12 Marzo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Historico(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("SELECT " + Ope_Historico_Exportacion.Campo_Fecha + " from " + Ope_Historico_Exportacion.Tabla);

                //    seccion where
                Mi_SQL.Append(" where " + Ope_Historico_Exportacion.Campo_Estatus_Exportacion + " is null");
                Mi_SQL.Append(" and " + Ope_Historico_Exportacion.Campo_Fecha + " != '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "'");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar Historico de exportaciones, Metodo: [Consultar_Historico]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }

        /// <summary>
        /// Nombre: Consultar_Cambios_Padron
        /// 
        /// Descripción: Método que consulta los cambios realizados en el padron
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 12 Marzo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Historico_Incluyendo_Dia_Actual(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("SELECT " + Ope_Historico_Exportacion.Campo_Fecha + " from " + Ope_Historico_Exportacion.Tabla);

                //    seccion where
                Mi_SQL.Append(" where " + Ope_Historico_Exportacion.Campo_Estatus_Exportacion + " is null");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar Historico de exportaciones, Metodo: [Consultar_Historico]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
        
        
        /// <summary>
        /// Nombre: Consultar_Nuevos_Usuarios_Padron
        /// 
        /// Descripción: Método que consulta los cambios realizados en el padron
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 12 Marzo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Nuevos_Usuarios_Padron(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select padron.*");

                //  seccion from
                Mi_SQL.Append(" from ope_historico_padron");
                Mi_SQL.Append(" left outer join padron on padron.rfc = ope_historico_padron.CURP_RFC");

                //    seccion where
                Mi_SQL.Append(" where DATE_FORMAT(FECHA,'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "' ");
                Mi_SQL.Append(" and Operacion = 'INSERCION'");
                Mi_SQL.Append(" and estatus is null ");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }

        /// <summary>
        /// Nombre: Consultar_Nuevos_Usuarios_Padron
        /// 
        /// Descripción: Método que consulta los cambios realizados en el padron
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 12 Marzo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Nuevos_Usuarios_Direcciones_Padron(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select movtos.*");

                //  seccion from
                Mi_SQL.Append(" from ope_historico_padron");
                Mi_SQL.Append(" left outer join movtos on movtos.curp = ope_historico_padron.CURP_RFC");

                //    seccion where
                Mi_SQL.Append(" where DATE_FORMAT(FECHA,'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "' ");
                Mi_SQL.Append(" and Operacion = 'INSERCION'");
                Mi_SQL.Append(" and estatus is null ");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }

        /// <summary>
        /// Nombre: Consultar_Nuevos_Listadeudor
        /// 
        /// Descripción: Método que consulta los cambios realizados en el padron
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 12 Marzo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Nuevos_Listadeudor(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select listdeudor.*");

                //  seccion from
                Mi_SQL.Append(" from ope_historico_padron");
                Mi_SQL.Append(" left outer join listdeudor on listdeudor.curp = ope_historico_padron.CURP_RFC");

                //    seccion where
                Mi_SQL.Append(" where DATE_FORMAT(FECHA,'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "' ");
                Mi_SQL.Append(" and Operacion = 'INSERCION_LISTA'");
                Mi_SQL.Append(" and estatus is null ");
                Mi_SQL.Append(" and tipo = '" + Datos.P_Tipo + "'");
                Mi_SQL.Append(" and lista = '" + Datos.P_Lista + "'");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }

        /// <summary>
        /// Nombre: Consultar_Nuevos_Usuarios_Listadeudor
        /// 
        /// Descripción: Método que consulta los cambios realizados en el padron
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 12 Marzo 2015 
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Nuevos_Usuarios_Listadeudor(Cls_Ope_Solicitud_Facturacion_Negocio Datos)
        {
            DataTable Dt_Contribuyente = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("select listdeudor.*");

                //  seccion from
                Mi_SQL.Append(" from ope_historico_padron");
                Mi_SQL.Append(" left outer join listdeudor on listdeudor.curp = ope_historico_padron.CURP_RFC");

                //    seccion where
                Mi_SQL.Append(" where DATE_FORMAT(FECHA,'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "' ");
                Mi_SQL.Append(" and (Operacion = 'INSERCION_LISTA' or Operacion = 'INSERCION')");// se toman ambos tipos de operacion ya que puede provenir de padron (insercion) ó de selicitud (insercion_lista)
                Mi_SQL.Append(" and estatus is null ");

                Dt_Contribuyente = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los contribuyentes, Metodo: [Consultar_Contribuyente]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Contribuyente;
        }
        #endregion
    }
}
