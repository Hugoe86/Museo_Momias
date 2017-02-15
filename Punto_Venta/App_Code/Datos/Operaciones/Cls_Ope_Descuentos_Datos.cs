using System;
using System.Data;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp_Ope_Descuentos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Ope_Descuentos.Datos
{
    public class Cls_Ope_Descuentos_Datos
    {
        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Descuento
        ///DESCRIPCIÓN          : Inserta un Registro en la base de datos.
        ///PARAMETROS           : Descuentos: Instancia de Cls_Ope_Descuentos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Descuento(Cls_Ope_Descuentos_Negocio Descuentos)
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

                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Descuentos.Tabla_Ope_Descuentos, Ope_Descuentos.Campo_No_Descuento, "", 10);

                Mi_SQL += "INSERT INTO " + Ope_Descuentos.Tabla_Ope_Descuentos + " (";
                Mi_SQL += Ope_Descuentos.Campo_No_Descuento;
                Mi_SQL += ", " + Ope_Descuentos.Campo_No_Pago;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Cantidad;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Monto_Pago;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Descuento_Pago;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Total_Pagar;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Descuento;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Vencimiento;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Fundamento_Legal;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Observaciones;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Realizo;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Usuario_Creo;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Creo;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Usuario_Modifico;
                Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Modifico;
                Mi_SQL += ")";
                Mi_SQL += " VALUES (";
                if (Descuentos.P_No_Descuento != "" && Descuentos.P_No_Descuento != null)
                {
                    Mi_SQL += "'" + Descuentos.P_No_Descuento + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_No_Pago != "" && Descuentos.P_No_Pago != null)
                {
                    Mi_SQL += "'" + Descuentos.P_No_Pago + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Cantidad != 0)
                {
                    Mi_SQL += Descuentos.P_Cantidad + ", ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Monto_Pago != 0)
                {
                    Mi_SQL += Descuentos.P_Monto_Pago + ", ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Descuento_Pago != 0)
                {
                    Mi_SQL += Descuentos.P_Descuento_Pago + ", ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Total_Pagar != 0)
                {
                    Mi_SQL += Descuentos.P_Total_Pagar + ", ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Fecha_Descuento > DateTime.MinValue)
                {
                    Mi_SQL += Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Descuento) + ", ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Fecha_Vencimiento > DateTime.MinValue)
                {
                    Mi_SQL += Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Vencimiento) + ", ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Fundamento_Legal != "" && Descuentos.P_Fundamento_Legal != null)
                {
                    Mi_SQL += "'" + Descuentos.P_Fundamento_Legal + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Observaciones != "" && Descuentos.P_Observaciones != null)
                {
                    Mi_SQL += "'" + Descuentos.P_Observaciones + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                if (Descuentos.P_Realizo != "" && Descuentos.P_Realizo != null)
                {
                    Mi_SQL += "'" + Descuentos.P_Realizo + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, ";
                }
                Mi_SQL += MDI_Frm_Apl_Principal.Nombre_Usuario + ", ";
                Mi_SQL += Cls_Ayudante_Sintaxis.Fecha();
                Mi_SQL += ")";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Descuento: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Descuento
        ///DESCRIPCIÓN          : Modifica un Registro en la base de datos.
        ///PARAMETROS           : Descuentos: Instancia de Cls_Ope_Descuentos_Negocio con los valores de los campos a Modificar
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Descuento(Cls_Ope_Descuentos_Negocio Descuentos)
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

                Mi_SQL += "UPDATE " + Ope_Descuentos.Tabla_Ope_Descuentos + " SET ";
                if (Descuentos.P_No_Descuento != "" && Descuentos.P_No_Descuento != null)
                {
                    Mi_SQL += Ope_Descuentos.Campo_No_Descuento + " = '" + Descuentos.P_No_Descuento + "', ";
                }
                if (Descuentos.P_No_Pago != "" && Descuentos.P_No_Pago != null)
                {
                    Mi_SQL += Ope_Descuentos.Campo_No_Pago + " = '" + Descuentos.P_No_Pago + "', ";
                }
                if (Descuentos.P_Cantidad != 0)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Cantidad + " = " + Descuentos.P_Cantidad + ", ";
                }
                if (Descuentos.P_Monto_Pago != 0)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Monto_Pago + " = " + Descuentos.P_Monto_Pago + ", ";
                }
                if (Descuentos.P_Descuento_Pago != 0)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Descuento_Pago + " = " + Descuentos.P_Descuento_Pago + ", ";
                }
                if (Descuentos.P_Total_Pagar != 0)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Total_Pagar + " = " + Descuentos.P_Total_Pagar + ", ";
                }
                if (Descuentos.P_Fecha_Descuento > DateTime.MinValue)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Fecha_Descuento + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Descuento) + ", ";
                }
                if (Descuentos.P_Fecha_Vencimiento > DateTime.MinValue)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Fecha_Vencimiento + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Vencimiento) + ", ";
                }
                if (Descuentos.P_Fundamento_Legal != "" && Descuentos.P_Fundamento_Legal != null)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Fundamento_Legal + " = '" + Descuentos.P_Fundamento_Legal + "', ";
                }
                if (Descuentos.P_Observaciones != "" && Descuentos.P_Observaciones != null)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Observaciones + " = '" + Descuentos.P_Observaciones + "', ";
                }
                if (Descuentos.P_Realizo != "" && Descuentos.P_Realizo != null)
                {
                    Mi_SQL += Ope_Descuentos.Campo_Realizo + " = '" + Descuentos.P_Realizo + "', ";
                }
                Mi_SQL += Ope_Descuentos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ";
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Modifico + " = '" + Cls_Ayudante_Sintaxis.Fecha() + "'";
                Mi_SQL += "WHERE " + Ope_Descuentos.Campo_No_Descuento + " = '" + Descuentos.P_No_Descuento + "'";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Descuento: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Descuento
        ///DESCRIPCIÓN          : Elimina un Registro de la base de datos.
        ///PARAMETROS           : Descuentos: Instancia de Cls_Ope_Descuentos_Negocio con el valor del No. de Operación a Eliminar
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Descuento(Cls_Ope_Descuentos_Negocio Descuentos)
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

                //  se eliminar los registros de Descuento con respecto al Descuento_id
                Mi_SQL += "DELETE FROM " + Ope_Descuentos.Tabla_Ope_Descuentos;
                Mi_SQL += " WHERE " + Ope_Descuentos.Campo_No_Descuento + " = '" + Descuentos.P_No_Descuento + "'";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Descuento: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Consultar_Descuentos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : Descuentos: Instancia de Cls_Ope_Descuentos_Negocio con los valores de la Consulta a ser ejecutada
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Descuentos(Cls_Ope_Descuentos_Negocio Descuentos)
        {
            String Mi_SQL = "";
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL += "SELECT " + Ope_Descuentos.Campo_No_Descuento;
            Mi_SQL += ", " + Ope_Descuentos.Campo_No_Pago;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Cantidad;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Monto_Pago;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Descuento_Pago;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Total_Pagar;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Descuento;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Vencimiento;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fundamento_Legal;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Observaciones;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Realizo;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Usuario_Creo;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Creo;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Usuario_Modifico;
            Mi_SQL += ", " + Ope_Descuentos.Campo_Fecha_Modifico;
            Mi_SQL += " FROM " + Ope_Descuentos.Tabla_Ope_Descuentos + "";
            Mi_SQL += " WHERE ";
            if (Descuentos.P_No_Descuento != "" && Descuentos.P_No_Descuento != null)
            {
                Mi_SQL += Ope_Descuentos.Campo_No_Descuento + " = '" + Descuentos.P_No_Descuento + "' AND ";
            }
            if (Descuentos.P_No_Pago != "" && Descuentos.P_No_Pago != null)
            {
                Mi_SQL += Ope_Descuentos.Campo_No_Pago + " = '" + Descuentos.P_No_Pago + "' AND ";
            }
            if (Descuentos.P_Fecha_Descuento > DateTime.MinValue)
            {
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Descuento + " >= " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Descuento) + " AND ";
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Descuento + " < " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Descuento.AddDays(1)) + " AND ";
            }
            if (Descuentos.P_Fecha_Vencimiento > DateTime.MinValue)
            {
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Vencimiento + " >= " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Vencimiento) + " AND ";
                Mi_SQL += Ope_Descuentos.Campo_Fecha_Vencimiento + " < " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Descuentos.P_Fecha_Vencimiento.AddDays(1)) + " AND ";
            }
            if (Descuentos.P_Realizo != "" && Descuentos.P_Realizo != null)
            {
                Mi_SQL += Ope_Descuentos.Campo_Realizo + " = '" + Descuentos.P_Realizo + "' AND ";
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

        #endregion Consulta
    }
}