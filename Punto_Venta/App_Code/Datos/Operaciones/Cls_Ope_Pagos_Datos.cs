using System;
using System.Data;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp_Ope_Pagos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using ERP_BASE.App_Code.Negocio.Catalogos;

namespace Erp_Ope_Pagos.Datos
{
    public class Cls_Ope_Pagos_Datos
    {
        #region Métodos

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
        public static String Alta_Pago(Cls_Ope_Pagos_Negocio Pagos)
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
                    //Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Pagos.Tabla_Ope_Pagos, Ope_Pagos.Campo_No_Pago, "", 10);

                    Mi_SQL = "set @No_Pago = (select ifnull(max(No_Pago), 0) + 1 from ope_pagos);";
                    Mi_SQL += "set @No_Pago = right(concat('0000000000', cast(@No_Pago as char(10))), 10);";

                    Mi_SQL += "INSERT INTO " + Ope_Pagos.Tabla_Ope_Pagos + " (";
                    Mi_SQL += Ope_Pagos.Campo_No_Pago;
                    Mi_SQL += ", " + Ope_Pagos.Campo_No_Venta;
                    Mi_SQL += ", " + Ope_Pagos.Campo_No_Caja;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Forma_ID;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Motivo_ID;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Banco_ID;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Monto_Pago;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Monto_Comision;
                    //Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Transaccion;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Cheque;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Referencia_Transferencia;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Tarjeta_Banco;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Tipo_Tarjeta_Banco;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Cancelacion;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Estatus;
                    Mi_SQL += ", " + Ope_Pagos.Campo_No_Estacionamiento;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Usuario_Creo;
                    Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Creo;

                    if (!String.IsNullOrEmpty(Dr_Pago["Titular_Tarjeta"].ToString()))
                        Mi_SQL += ", " + Ope_Pagos.Campo_Titular_Tarjeta;

                    if (!String.IsNullOrEmpty(Dr_Pago["Numero_Transaccion"].ToString()))
                        Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Transaccion;

                    Mi_SQL += ")";
                    Mi_SQL += " VALUES (";
                    //Mi_SQL += "'" + Consecutivo + "', ";
                    Mi_SQL += "@No_Pago, ";
                    if (Pagos.P_No_Venta != "" && Pagos.P_No_Venta != null)
                    {
                        Mi_SQL += "'" + Pagos.P_No_Venta + "', ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }

                    Mi_SQL += "'" + Dr_Pago["No_Caja"].ToString() + "', ";
                    Mi_SQL += "'" + Dr_Pago["Forma_Id"].ToString() + "', ";
                    if (Pagos.P_Motivo_ID != "" && Pagos.P_Motivo_ID != null)
                    {
                        Mi_SQL += "'" + Pagos.P_Motivo_ID + "', ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }
                    //if (!string.IsNullOrEmpty(Pagos.P_Banco_ID))
                    //{
                    //    Mi_SQL += "'" + Pagos.P_Banco_ID + "', ";
                    //}
                    if (Dr_Pago["Banco_Id"].ToString() != "" && Dr_Pago["Banco_Id"].ToString() != null)
                    {
                        Mi_SQL += "'" + Dr_Pago["Banco_Id"].ToString() + "', ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }
                    Mi_SQL += (decimal)Dr_Pago["Monto_Pago"] + ", ";
                    Mi_SQL += (decimal)Dr_Pago["Monto_Comision"] + ", ";
                    //if (Pagos.P_Numero_Transaccion != "" && Pagos.P_Numero_Transaccion != null)
                    //{
                    //    Mi_SQL += "'" + Pagos.P_Numero_Transaccion + "', ";
                    //}
                    //else
                    //{
                    //    Mi_SQL += "NULL, ";
                    //}
                    if (Pagos.P_Numero_Cheque != "" && Pagos.P_Numero_Cheque != null)
                    {
                        Mi_SQL += "'" + Pagos.P_Numero_Cheque + "', ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }
                    //if (Pagos.P_Referencia_Transferencia != "" && Pagos.P_Referencia_Transferencia != null)
                    //{
                    //    Mi_SQL += "'" + Pagos.P_Referencia_Transferencia + "', ";
                    //}
                    if (Dr_Pago["Referencia"].ToString() != "" && Dr_Pago["Referencia"].ToString() != null)
                    {
                        Mi_SQL += "'" + Dr_Pago["Referencia"].ToString() + "', ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }
                    Mi_SQL += "'" + Dr_Pago["Numero_Tarjeta_Banco"].ToString() + "', ";
                    Mi_SQL += "'" + Dr_Pago[Ope_Pagos.Campo_Tipo_Tarjeta_Banco].ToString() + "', ";
                    if (Pagos.P_Fecha_Cancelacion > DateTime.MinValue)
                    {
                        Mi_SQL += Cls_Ayudante_Sintaxis.Insertar_Fecha(Pagos.P_Fecha_Cancelacion) + ", ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }

                    Mi_SQL += "'" + Dr_Pago["Estatus"].ToString() + "', ";

                    if (!string.IsNullOrEmpty(Pagos.No_Estacionamiento))
                    {
                        Mi_SQL += "'" + Pagos.No_Estacionamiento + "', ";
                    }
                    else
                    {
                        Mi_SQL += "NULL, ";
                    }

                    Mi_SQL += "'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ";
                    Mi_SQL += Cls_Ayudante_Sintaxis.Fecha();


                    if (!String.IsNullOrEmpty(Dr_Pago["Titular_Tarjeta"].ToString()))
                        Mi_SQL += ", '" + Dr_Pago["Titular_Tarjeta"].ToString() + "'";

                    if (!String.IsNullOrEmpty(Dr_Pago["Numero_Transaccion"].ToString()))
                        Mi_SQL += ", '" + Dr_Pago["Numero_Transaccion"].ToString() + "'";
                    
                    Mi_SQL += ");";

                    Mi_SQL += "select @No_Pago;";

                    Consecutivo = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL).ToString();
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
            return Consecutivo;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Pago
        ///DESCRIPCIÓN          : Modifica un Registro en la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de los campos a Modificar
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Pago(Cls_Ope_Pagos_Negocio Pagos)
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

                Mi_SQL += "UPDATE " + Ope_Pagos.Tabla_Ope_Pagos + " SET ";
                if (Pagos.P_No_Pago != "" && Pagos.P_No_Pago != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_No_Pago + " = '" + Pagos.P_No_Pago + "', ";
                }
                if (Pagos.P_No_Venta != "" && Pagos.P_No_Venta != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_No_Venta + " = '" + Pagos.P_No_Venta + "', ";
                }
                if (Pagos.P_No_Caja != "" && Pagos.P_No_Caja != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_No_Caja + " = '" + Pagos.P_No_Caja + "', ";
                }
                if (Pagos.P_Forma_ID != "" && Pagos.P_Forma_ID != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_Forma_ID + " = '" + Pagos.P_Forma_ID + "', ";
                }
                if (Pagos.P_Motivo_ID != "" && Pagos.P_Motivo_ID != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_Motivo_ID + " = '" + Pagos.P_Motivo_ID + "', ";
                }
                if (!string.IsNullOrEmpty(Pagos.P_Banco_ID))
                {
                    Mi_SQL += Ope_Pagos.Campo_Banco_ID + " = '" + Pagos.P_Banco_ID + "', ";
                }
                if (Pagos.P_Monto_Pago != 0)
                {
                    Mi_SQL += Ope_Pagos.Campo_Monto_Pago + " = " + Pagos.P_Monto_Pago + ", ";
                }
                if (Pagos.P_Numero_Transaccion != "" && Pagos.P_Numero_Transaccion != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_Numero_Transaccion + " = '" + Pagos.P_Numero_Transaccion + "', ";
                }
                if (Pagos.P_Numero_Cheque != "" && Pagos.P_Numero_Cheque != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_Numero_Cheque + " = '" + Pagos.P_Numero_Cheque + "', ";
                }
                if (Pagos.P_Referencia_Transferencia != "" && Pagos.P_Referencia_Transferencia != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_Referencia_Transferencia + " = '" + Pagos.P_Referencia_Transferencia + "', ";
                }
                if (Pagos.P_Numero_Tarjeta_Banco != "" && Pagos.P_Numero_Tarjeta_Banco != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_Numero_Tarjeta_Banco + " = '" + Pagos.P_Numero_Tarjeta_Banco + "', ";
                }
                if (Pagos.P_Fecha_Cancelacion > DateTime.MinValue)
                {
                    Mi_SQL += Ope_Pagos.Campo_Fecha_Cancelacion + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Pagos.P_Fecha_Cancelacion) + ", ";
                }
                if (Pagos.P_Estatus != "" && Pagos.P_Estatus != null)
                {
                    Mi_SQL += Ope_Pagos.Campo_Estatus + " = '" + Pagos.P_Estatus + "', ";
                }
                Mi_SQL += Ope_Pagos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ";
                Mi_SQL += Ope_Pagos.Campo_Fecha_Modifico + " = '" + Cls_Ayudante_Sintaxis.Fecha() + "'";
                Mi_SQL += "WHERE " + Ope_Pagos.Campo_No_Pago + " = '" + Pagos.P_No_Pago + "'";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Pago: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Pago
        ///DESCRIPCIÓN          : Elimina un Registro de la base de datos.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con el valor del No. de Operación a Eliminar
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Pago(Cls_Ope_Pagos_Negocio Pagos)
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

                //  se eliminar los registros de Pago con respecto al Pago_id
                Mi_SQL += "DELETE FROM " + Ope_Pagos.Tabla_Ope_Pagos;
                Mi_SQL += " WHERE " + Ope_Pagos.Campo_No_Pago + " = '" + Pagos.P_No_Pago + "'";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Pago: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Consultar_Pagos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : Pagos: Instancia de Cls_Ope_Pagos_Negocio con los valores de la Consulta a ser ejecutada
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Pagos(Cls_Ope_Pagos_Negocio Pagos)
        {
            String Mi_SQL = "";
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL += "SELECT " + Ope_Pagos.Campo_No_Pago;
            Mi_SQL += ", " + Ope_Pagos.Campo_No_Venta;
            Mi_SQL += ", " + Ope_Pagos.Campo_No_Caja;
            Mi_SQL += ", " + Ope_Pagos.Campo_Forma_ID;
            Mi_SQL += ", " + Ope_Pagos.Campo_Motivo_ID;
            Mi_SQL += ", " + Ope_Pagos.Campo_Banco_ID;
            Mi_SQL += ", " + Ope_Pagos.Campo_Monto_Pago;
            Mi_SQL += ", " + Ope_Pagos.Campo_Monto_Comision;
            Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Transaccion;
            Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Cheque;
            Mi_SQL += ", " + Ope_Pagos.Campo_Referencia_Transferencia;
            Mi_SQL += ", " + Ope_Pagos.Campo_Numero_Tarjeta_Banco;
            Mi_SQL += ", " + Ope_Pagos.Campo_Tipo_Tarjeta_Banco;
            Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Cancelacion;
            Mi_SQL += ", " + Ope_Pagos.Campo_Estatus;
            Mi_SQL += ", " + Ope_Pagos.Campo_Usuario_Creo;
            Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Creo;
            Mi_SQL += ", " + Ope_Pagos.Campo_Usuario_Modifico;
            Mi_SQL += ", " + Ope_Pagos.Campo_Fecha_Modifico;
            Mi_SQL += " FROM " + Ope_Pagos.Tabla_Ope_Pagos + "";
            Mi_SQL += " WHERE ";
            if (Pagos.P_No_Pago != "" && Pagos.P_No_Pago != null)
            {
                Mi_SQL += Ope_Pagos.Campo_No_Pago + " = '" + Pagos.P_No_Pago + "' AND ";
            }
            if (Pagos.P_No_Venta != "" && Pagos.P_No_Venta != null)
            {
                Mi_SQL += Ope_Pagos.Campo_No_Venta + " = '" + Pagos.P_No_Venta + "' AND ";
            }
            if (Pagos.P_No_Caja != "" && Pagos.P_No_Caja != null)
            {
                Mi_SQL += Ope_Pagos.Campo_No_Caja + " = '" + Pagos.P_No_Caja + "' AND ";
            }
            if (Pagos.P_Forma_ID != "" && Pagos.P_Forma_ID != null)
            {
                Mi_SQL += Ope_Pagos.Campo_Forma_ID + " = '" + Pagos.P_Forma_ID + "' AND ";
            }
            if (Pagos.P_Motivo_ID != "" && Pagos.P_Motivo_ID != null)
            {
                Mi_SQL += Ope_Pagos.Campo_Motivo_ID + " = '" + Pagos.P_Motivo_ID + "' AND ";
            }
            if (!string.IsNullOrEmpty(Pagos.P_Banco_ID))
            {
                Mi_SQL += Ope_Pagos.Campo_Banco_ID + " = '" + Pagos.P_Banco_ID + "'";
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


        public static System.Data.DataTable Consultar_Dias_Feriados(Cls_Ope_Pagos_Negocio Pagos)
        {
            String Mi_SQL = "";
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL += "SELECT " + Cat_Dias_Feriados.Campo_Fecha;
            Mi_SQL += ", " + Cat_Dias_Feriados.Campo_Fecha_Fin;
            Mi_SQL += " FROM " + Cat_Dias_Feriados.Tabla_Cat_Dias_Feriados; 
            Mi_SQL += " WHERE "+ Cat_Dias_Feriados.Campo_Estatus +"= 'ACTIVO' ";

            Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Consulta;

        }

        #endregion Consulta
    }
}