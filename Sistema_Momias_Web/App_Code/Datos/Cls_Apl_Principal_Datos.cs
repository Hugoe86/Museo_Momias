using System;
using System.Text;
using System.Data;
using Erp.Principal.Negocio;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Ayudante_Sintaxis;
using Erp_Ope_Accesos.Negocio;

/// <summary>
/// Summary description for Cls_Apl_Principal_Datos
/// </summary>
namespace Erp.Principal.Datos
{
    public class Cls_Apl_Principal_Datos
    {
        #region Metodos
        /// <summary>
        /// Metodo para consultar si el dia actual es un dia feriado
        /// </summary>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>20/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        internal static DataTable Consultar_Productos_Servicios(Cls_Apl_Principal_Negocio Negocio) 
        {
            DataTable Dt_Datos = new DataTable();
            DataTable Dt_Datos_Producto_Id = new DataTable();
            StringBuilder Mi_Sql = new StringBuilder();
            Boolean Dia_Festivo = false;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            String Producto_Id_Parametro = "";

            try
            {
                //consultamos si el dia de la visita es dia festivo
                Dia_Festivo = Consultar_Dias_Festivos(Negocio.P_Fecha_Visita);

                //Mi_Sql.Append("select " + Cat_Parametros.Campo_Producto_Id_Web + " from " + Cat_Parametros.Tabla_Cat_Parametros);
                //Dt_Datos_Producto_Id = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

                ////  se obtiene el parametro del producto que se mostrara en el modulo web
                //foreach (DataRow Registro in Dt_Datos_Producto_Id.Rows)
                //{
                //    if (!String.IsNullOrEmpty(Registro[Cat_Parametros.Campo_Producto_Id_Web].ToString()))
                //        Producto_Id_Parametro = Registro[Cat_Parametros.Campo_Producto_Id_Web].ToString();
                //}

                Mi_Sql.Clear();
                Mi_Sql.Append("select 0 as Cantidad, " + Cat_Productos.Campo_Producto_Id + ", ");
                Mi_Sql.Append(Cat_Productos.Campo_Nombre + ", ");
                Mi_Sql.Append(Cat_Productos.Campo_Descripcion + ", ");
                Mi_Sql.Append(Cat_Productos.Campo_Costo + ", ");
                Mi_Sql.Append(Cat_Productos.Campo_Codigo + ", ");
                Mi_Sql.Append(Cat_Productos.Campo_Ruta_Imagen + ", ");
                Mi_Sql.Append(Cat_Productos.Campo_Tipo );
                Mi_Sql.Append(" from " + Cat_Productos.Tabla_Cat_Productos);
                Mi_Sql.Append(" where " + Cat_Productos.Campo_Tipo_Servicio + " != 'ESTACIONAMIENTO'");
                Mi_Sql.Append(" and " + Cat_Productos.Campo_Estatus + " = 'ACTIVO' ");
                Mi_Sql.Append(" and " + Cat_Productos.Campo_Web + "= 'S'");

                //if (!String.IsNullOrEmpty(Producto_Id_Parametro))
                //    Mi_Sql.Append(" and " + Cat_Productos.Campo_Producto_Id + " = '" + Producto_Id_Parametro + "'");


                //if (Dia_Festivo)
                //{
                //    Mi_Sql.Append(" and " + Cat_Productos.Campo_Tipo + " = 'Servicio'");

                //    Mi_Sql.Append(" union ");

                //    Mi_Sql.Append("select  0 as Cantidad, " + Cat_Productos.Campo_Producto_Id + ", ");
                //    Mi_Sql.Append(Cat_Productos.Campo_Nombre + ", ");
                //    Mi_Sql.Append(Cat_Productos.Campo_Descripcion + ", ");
                //    Mi_Sql.Append(Cat_Productos.Campo_Costo + ", ");
                //    Mi_Sql.Append(Cat_Productos.Campo_Codigo + ", ");
                //    Mi_Sql.Append(Cat_Productos.Campo_Ruta_Imagen + ", ");
                //    Mi_Sql.Append(Cat_Productos.Campo_Tipo);
                //    Mi_Sql.Append(" from " + Cat_Productos.Tabla_Cat_Productos);
                //    Mi_Sql.Append(" where upper(" + Cat_Productos.Campo_Nombre + ") = 'ENTRADA GENERAL'");
                //}

                Mi_Sql.Append(" order by " + Cat_Productos.Campo_Tipo + " asc");

                Dt_Datos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception(" Error al consultar los productos y servicios. Error[" + Ex.Message + "]");
            }
            finally 
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Datos;
        }

        /// <summary>
        /// Metodo para consultar si el dia actual es un dia feriado
        /// </summary>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>20/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        internal static Boolean Consultar_Dias_Festivos(DateTime Fecha_Visita)
        {
            DataTable Dt_Datos = new DataTable();
            StringBuilder Mi_Sql = new StringBuilder();
            Boolean Es_Dia_Festivo = false;

            try
            {
                Mi_Sql.Append("select " + Cat_Dias_Feriados.Campo_Fecha + ", ");
                Mi_Sql.Append(Cat_Dias_Feriados.Campo_Anios);
                Mi_Sql.Append(" from " + Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados);
                Mi_Sql.Append(" where " + Cat_Dias_Feriados.Campo_Anios + " in('TODOS LOS AÑOS', " + String.Format("{0:yyyy}", Fecha_Visita) + ")");
                //Mi_Sql.Append(" and (extract(day from " + Cat_Dias_Feriados.Campo_Fecha + ") = " + String.Format("{0:dd}", Fecha_Visita));
                Mi_Sql.Append(" and " + String.Format("{0:dd}", Fecha_Visita) + " BETWEEN  (extract(day FROM " + Cat_Dias_Feriados.Campo_Fecha + ")) and (extract(day FROM " + Cat_Dias_Feriados.Campo_Fecha_Fin + "))");
                Mi_Sql.Append(" and extract(month from " + Cat_Dias_Feriados.Campo_Fecha + ") = " + String.Format("{0:MM}", Fecha_Visita) + "");
                Mi_Sql.Append(" and " + Cat_Dias_Feriados.Campo_Estatus + " = 'ACTIVO'");

                Dt_Datos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

                if (Dt_Datos != null)
                    if (Dt_Datos.Rows.Count > 0)
                        Es_Dia_Festivo = true;

            }
            catch (Exception Ex)
            {
                throw new Exception(" Error al consultar los productos y servicios. Error[" + Ex.Message + "]");
            }
            return Es_Dia_Festivo;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Pago
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Venta(Cls_Apl_Principal_Negocio P_Ventas)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
            Boolean Alta_Exitosa = false;
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
                //obtenemos el numero de venta
                string where = "No_Venta like '0%'";
                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Ventas.Tabla_Ope_Ventas, Ope_Ventas.Campo_No_Venta, where, 10);

                Mi_SQL = "INSERT INTO " + Ope_Ventas.Tabla_Ope_Ventas + " ("
                    + Ope_Ventas.Campo_No_Venta
                    + ", " + Ope_Ventas.Campo_Subtotal
                    + ", " + Ope_Ventas.Campo_Impuestos
                    + ", " + Ope_Ventas.Campo_Descuentos
                    + ", " + Ope_Ventas.Campo_Total
                    + ", " + Ope_Ventas.Campo_Estatus
                    + ", " + Ope_Ventas.Campo_Correo_Electronico
                    + ", " + Ope_Ventas.Campo_Telefono
                    + ", " + Ope_Ventas.Campo_Lugar_Venta
                    + ", " + Ope_Ventas.Campo_Usuario_Creo
                    + ", " + Ope_Ventas.Campo_Fecha_Creo
                    + ") VALUES ('"
                    + Consecutivo
                    + "', ";
                    Mi_SQL += P_Ventas.P_Subtotal
                    + ", 0.00"
                    + ", 0.00"
                    + ", " + P_Ventas.P_Total_Venta
                    + ", '" + P_Ventas.P_Estatus + "'";

                    if(!string.IsNullOrEmpty(P_Ventas.P_Email))
                        Mi_SQL += ", '" + P_Ventas.P_Email + "'";
                    else
                        Mi_SQL += ", NULL";

                    if (!string.IsNullOrEmpty(P_Ventas.P_Telefono))
                        Mi_SQL += ", '" + P_Ventas.P_Telefono + "'";
                    else
                        Mi_SQL += ", NULL";

                    Mi_SQL += ", 'Internet'";
                    Mi_SQL += ", 'Usuario Punto Venta Web"
                    + "', " + Cls_Ayudante_Sintaxis.Fecha()
                    + ")";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //insertamos los detalles de la venta
                if (P_Ventas.P_Dt_Ventas != null)
                {
                    foreach (System.Data.DataRow Dr_Ventas_Detalles in P_Ventas.P_Dt_Ventas.Rows)
                    {
                        Mi_SQL = "INSERT INTO " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " ("
                            + Ope_Ventas_Detalles.Campo_No_Venta
                            + ", " + Ope_Ventas_Detalles.Campo_Producto_Id
                            + ", " + Ope_Ventas_Detalles.Campo_Cantidad
                            + ", " + Ope_Ventas_Detalles.Campo_Subtotal
                            + ", " + Ope_Ventas_Detalles.Campo_Total
                            + ", " + Ope_Ventas_Detalles.Campo_Usuario_Creo
                            + ", " + Ope_Ventas_Detalles.Campo_Fecha_Creo
                            + ") VALUES ('"
                            + Consecutivo
                            + "', '" + Dr_Ventas_Detalles["PRODUCTO_ID"].ToString()
                            + "', " + ((decimal)Dr_Ventas_Detalles["CANTIDAD"])
                            + ", " + ((decimal)Dr_Ventas_Detalles["COSTO"])
                            + ", " + ((decimal)Dr_Ventas_Detalles["TOTAL"])
                            + ", 'Usuario Punto Venta Web"
                            + "', " + Cls_Ayudante_Sintaxis.Fecha()
                            + ")";
                        Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                    }
                }

                //insertamos los datos del pago
                P_Ventas.P_No_Venta = Consecutivo;
                Alta_Pago(P_Ventas);

                // generar acceso
                Cls_Ope_Accesos_Negocio P_Accesos = new Cls_Ope_Accesos_Negocio();
                P_Accesos.P_No_Venta = Consecutivo;
                P_Accesos.P_Vigencia_Inicio = P_Ventas.P_Fecha_Inicio_Vigencia;
                P_Accesos.P_Vigencia_Fin = P_Ventas.P_Fecha_Termino_Vigencia;
                P_Ventas.P_Dt_Productos = P_Accesos.Alta_Acceso(P_Ventas.P_Dt_Ventas);
                
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
            return Alta_Exitosa;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Pago
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Pago(Cls_Apl_Principal_Negocio Pagos)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
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
                foreach (DataRow Dr_Pago in Pagos.P_Dt_Pagos.Rows)
                {
                    Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Pagos.Tabla_Ope_Pagos, Ope_Pagos.Campo_No_Pago, "", 10);

                    Mi_SQL = "INSERT INTO " + Ope_Pagos.Tabla_Ope_Pagos + " (";
                    Mi_SQL += Ope_Pagos.Campo_No_Pago;
                    Mi_SQL += ", " + Ope_Pagos.Campo_No_Venta;
                    Mi_SQL += ", " + Ope_Pagos.Campo_No_Caja;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Forma_ID;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Monto_Pago;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Monto_Comision;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Transaccion;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Tarjeta_Banco;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Tipo_Tarjeta_Banco;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Cancelacion;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Estatus;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Domicilio;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Ciudad;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Estado;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Codigo_Postal;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Titular_Tarjeta;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Usuario_Creo;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Creo;
                    Mi_SQL += ")";
                    Mi_SQL += " VALUES (";
                    Mi_SQL += "'" + Consecutivo + "', ";
                    if (Pagos.P_No_Venta != "" && Pagos.P_No_Venta != null)
                    {
                        Mi_SQL += "'" + Pagos.P_No_Venta + "', ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }
                    Mi_SQL += "NULL, ";
                    Mi_SQL += "'" + Dr_Pago["Forma_Id"].ToString() + "', ";
                    Mi_SQL += (decimal)Dr_Pago["Monto_Pago"] + ", ";
                    Mi_SQL += "0.00, ";
                    Mi_SQL += "'" + Dr_Pago["Numero_Transaccion"].ToString() + "', ";
                    Mi_SQL += "'" + Dr_Pago["Numero_Tarjeta_Banco"].ToString() + "', ";
                    Mi_SQL += "NULL, ";
                    Mi_SQL += "NULL, ";
                    Mi_SQL += "'" + Dr_Pago["Estatus"].ToString() + "', ";

                    if(!String.IsNullOrEmpty(Pagos.P_Domicilio))
                        Mi_SQL += "'" + Pagos.P_Domicilio + "', ";
                    else
                         Mi_SQL += "NULL, ";

                    if (!String.IsNullOrEmpty(Pagos.P_Ciudad))
                        Mi_SQL += "'" + Pagos.P_Ciudad + "', ";
                    else
                        Mi_SQL += "NULL, ";

                    if (!String.IsNullOrEmpty(Pagos.P_Estado))
                        Mi_SQL += "'" + Pagos.P_Estado + "', ";
                    else
                        Mi_SQL += "NULL, ";

                    if (!String.IsNullOrEmpty(Pagos.P_Codigo_Postal))
                        Mi_SQL += "'" + Pagos.P_Codigo_Postal + "', ";
                    else
                        Mi_SQL += "NULL, ";

                    if (!String.IsNullOrEmpty(Pagos.P_Nombre))
                        Mi_SQL += "'" + Pagos.P_Nombre + "', ";
                    else
                        Mi_SQL += "NULL, ";

                    Mi_SQL += "'Usuario Punto Venta Web', ";
                    Mi_SQL += Cls_Ayudante_Sintaxis.Fecha();
                    Mi_SQL += ")";

                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                }
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
        }

        /// <summary>
        /// Consulta para obtener el id de la forma de pago de internet
        /// </summary>
        /// <returns></returns>
        /// <creo>Leslie González Vázquez</creo>
        /// <fecha creo>31/Mayo/2014</fecha creo>
        /// <modifico></modifico>
        /// <fecha modifico></fecha modifico>
        /// <causa modificacion></motivo modificacion>
        internal static String Obtener_Forma_Pago()
        {
            Object Forma_Pago_ID = null;
            String Forma_Pago_Id = String.Empty;
            StringBuilder Mi_Sql = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            try
            {
                Mi_Sql.Append("Select " + Cat_Formas_Pago.Campo_Forma_ID);
                Mi_Sql.Append(" from " + Cat_Formas_Pago.Tabla_Cat_Formas_Pago);
                Mi_Sql.Append(" where UPPER(" + Cat_Formas_Pago.Campo_Nombre + ") = 'INTERNET'");

                Forma_Pago_ID = Conexion.HelperGenerico.Obtener_Escalar(Mi_Sql.ToString());
                if (Forma_Pago_ID is DBNull)
                {
                    Forma_Pago_Id = String.Empty;
                }
                else 
                {
                    Forma_Pago_Id = (String)Forma_Pago_ID;
                }

            }
            catch (Exception Ex)
            {
                throw new Exception("Error al obtener la forma de pago de internet. Error[" + Ex.Message + "]");
            }
            return Forma_Pago_Id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Cls_Apl_Principal_Negocio Consultar_Venta(Cls_Apl_Principal_Negocio Venta)
        {
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                Mi_Sql.Append("SELECT V.*, P.*, ");
                Mi_Sql.Append("(SELECT A.Vigencia_Inicio FROM " + Ope_Accesos.Tabla_Ope_Accesos);
                Mi_Sql.Append(" A WHERE A." + Ope_Accesos.Campo_No_Venta);
                Mi_Sql.Append(" = V." + Ope_Ventas.Campo_No_Venta + " LIMIT 1) Vigencia_Inicio ");
                Mi_Sql.Append("FROM " + Ope_Ventas.Tabla_Ope_Ventas + " V ");
                Mi_Sql.Append("JOIN " + Ope_Pagos.Tabla_Ope_Pagos + " P ");
                Mi_Sql.Append("ON V." + Ope_Ventas.Campo_No_Venta + " = P." + Ope_Pagos.Campo_No_Venta);
                Mi_Sql.Append(" WHERE V." + Ope_Ventas.Campo_No_Venta + " = '" + Venta.P_No_Venta + "'");

                var Vnt = Conexion.HelperGenerico.Obtener_Data_Reader(Mi_Sql.ToString());

                while (Vnt.Read())
                {
                    Venta.P_Subtotal = Convert.ToDecimal(Vnt[Ope_Ventas.Campo_Subtotal]);
                    Venta.P_Total = Vnt[Ope_Ventas.Campo_Total].ToString();
                    Venta.P_Estatus = Vnt[Ope_Ventas.Campo_Estatus].ToString();
                    Venta.P_Email = Vnt[Ope_Ventas.Campo_Correo_Electronico].ToString();
                    Venta.P_Telefono = Vnt[Ope_Ventas.Campo_Telefono].ToString();
                    Venta.P_Numero_Tarjeta = Vnt[Ope_Pagos.Campo_Numero_Tarjeta_Banco].ToString();
                    Venta.P_Nombre = Vnt[Ope_Pagos.Campo_Titular_Tarjeta].ToString();
                    Venta.P_Domicilio = Vnt[Ope_Pagos.Campo_Domicilio].ToString();
                    Venta.P_Estado = Vnt[Ope_Pagos.Campo_Estado].ToString();
                    Venta.P_Codigo_Postal = Vnt[Ope_Pagos.Campo_Codigo_Postal].ToString();
                    Venta.P_Ciudad = Vnt[Ope_Pagos.Campo_Ciudad].ToString();
                    Venta.P_Fecha_Inicio_Vigencia = DateTime.Parse(
                            Vnt[Ope_Accesos.Campo_Vigencia_Inicio].ToString());
                }

                Vnt.Close();

                /*Se realiza la consulta para generar los accesos*/
                Mi_Sql.Clear();
                Mi_Sql.Append("SELECT a.Producto_Id PRODUCTO_ID, count(*) CANTIDAD, p.Costo COSTO, ");
                Mi_Sql.Append("sum(p.Costo) TOTAL, p.Tipo TIPO, p.Descripcion DESCRIPCION, ");
                Mi_Sql.Append("p.Ruta_Imagen RUTA_IMAGEN,p.Codigo CODIGO, ");
                Mi_Sql.Append("(select group_concat(ac.No_Acceso separator ', ') ");
                Mi_Sql.Append("from ope_accesos ac where ac.No_Venta = a.No_Venta ");
                Mi_Sql.Append("and ac.Producto_Id = a.Producto_Id group by ac.Producto_Id) ACCESOS ");
                Mi_Sql.Append("from ope_accesos a ");
                Mi_Sql.Append("join cat_productos p on p.Producto_Id = a.Producto_ID ");
                Mi_Sql.Append("where No_Venta = '" + Venta.P_No_Venta + "' ");
                Mi_Sql.Append("group by Producto_Id;");

                Venta.P_Dt_Productos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());

                return Venta;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
        #endregion
    }
}