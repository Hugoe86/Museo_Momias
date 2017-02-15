using System;
using Erp_Ope_Ventas.Negocio;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;
using Erp_Ope_Pagos.Negocio;
using Erp_Ope_Accesos.Negocio;
using Erp_Ope_Impresiones.Negocio;
using System.Text;

namespace Erp_Ope_Ventas.Datos
{
    public class Cls_Ope_Ventas_Datos
    {
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
        public static Boolean Alta_Pago(Cls_Ope_Ventas_Negocio P_Ventas)
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

                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Ventas.Tabla_Ope_Ventas, Ope_Ventas.Campo_No_Venta, "", 10);

                Mi_SQL = "INSERT INTO " + Ope_Ventas.Tabla_Ope_Ventas + " ("
                    + Ope_Ventas.Campo_No_Venta
                    + ", " + Ope_Ventas.Campo_Motivo_Descuento_Id
                    + ", " + Ope_Ventas.Campo_Usuario_Autoriza_ID
                    + ", " + Ope_Ventas.Campo_Subtotal
                    + ", " + Ope_Ventas.Campo_Impuestos
                    + ", " + Ope_Ventas.Campo_Descuentos
                    + ", " + Ope_Ventas.Campo_Total
                    + ", " + Ope_Ventas.Campo_Estatus
                    + ", " + Ope_Ventas.Campo_Usuario_Creo
                    + ", " + Ope_Ventas.Campo_Fecha_Creo
                    + ") VALUES ('"
                    + Consecutivo
                    + "', ";
                if (!String.IsNullOrEmpty(P_Ventas.P_Motivo_Descuento_Id))
                {
                    Mi_SQL += "'" + P_Ventas.P_Motivo_Descuento_Id
                        + "', '" + P_Ventas.P_Usuario_Id + "', ";
                }
                else
                {
                    Mi_SQL += "NULL, NULL,";
                }

                Mi_SQL += P_Ventas.P_Subtotal
                + ", " + P_Ventas.P_Impuestos
                + ", " + P_Ventas.P_Descuentos
                + ", " + P_Ventas.P_Total
                + ", '" + P_Ventas.P_Estatus
                + "', 'Usuario Punto Venta Web"
                + "', " + Cls_Ayudante_Sintaxis.Fecha()
                + ")";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

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

                Cls_Ope_Pagos_Negocio P_Pagos = new Cls_Ope_Pagos_Negocio();
                P_Pagos.P_Dt_Pagos = P_Ventas.P_Dt_Pagos;
                P_Pagos.P_No_Venta = Consecutivo;
                P_Pagos.Alta_Pago();
                // generar acceso
                Cls_Ope_Accesos_Negocio P_Accesos = new Cls_Ope_Accesos_Negocio();
                P_Accesos.P_No_Venta = Consecutivo;
                P_Accesos.Alta_Acceso(P_Ventas.P_Dt_Ventas);
                // enviar impresión de recibos y accesos
                var Obj_Impresiones = new Cls_Ope_Impresiones_Negocio();
                Obj_Impresiones.P_No_Venta = Consecutivo;
                Obj_Impresiones.P_Descuento_Pago = Convert.ToDecimal(P_Ventas.P_Descuentos);
                Obj_Impresiones.P_Subtotal_Pago = Convert.ToDecimal(P_Ventas.P_Subtotal);
                Obj_Impresiones.P_Monto_Pago = Convert.ToDecimal(P_Ventas.P_Total);
                Obj_Impresiones.P_Dt_Datos_Pago = P_Ventas.P_Dt_Ventas;
                Obj_Impresiones.P_Dt_Formas_Pago = P_Ventas.P_Dt_Pagos;
                Obj_Impresiones.Imprimir_Pago();

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
        /// <summary>
        /// Nombre: Realizar_Pago_Grupo
        /// 
        /// Descripción: Método que realiza el cierre y pago del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 24 Octubre 2013 14:20
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Objeto que se utiliza para enviar los datos de la capa de usuario</param>
        /// <returns></returns>
        public static bool Realizar_Pago_Grupo(Cls_Ope_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Estatus_Operacion = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                #region (Actualizar Datos Grupo)
                Mi_SQL.Append("update " + Ope_Ventas.Tabla_Ope_Ventas);
                Mi_SQL.Append(" set ");
                Mi_SQL.Append(Ope_Ventas.Campo_Motivo_Descuento_Id + "=" + (string.IsNullOrEmpty(Datos.P_Motivo_Descuento_Id) ? "null" : ("'" + Datos.P_Motivo_Descuento_Id + "'")));
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Usuario_Autoriza_ID + "=" + (string.IsNullOrEmpty(Datos.P_Usuario_Id) ? "null" : ("'" + Datos.P_Usuario_Id + "'")));
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Subtotal + "=" + Datos.P_Subtotal);
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Impuestos + "=" + Datos.P_Impuestos);
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Descuentos + "=" + Datos.P_Descuentos);
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Estatus + "=" + (string.IsNullOrEmpty(Datos.P_Estatus) ? "null" : ("'" + Datos.P_Estatus + "'")));
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Usuario_Modifico + "='Usuario Punto Venta Web'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Fecha_Modifico + "=" + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                Cls_Ope_Pagos_Negocio P_Pagos = new Cls_Ope_Pagos_Negocio();
                P_Pagos.P_Dt_Pagos = Datos.P_Dt_Pagos;
                P_Pagos.P_No_Venta = Datos.P_No_Venta;
                P_Pagos.Alta_Pago();
                // generar acceso
                Cls_Ope_Accesos_Negocio P_Accesos = new Cls_Ope_Accesos_Negocio();
                P_Accesos.P_No_Venta = Datos.P_No_Venta;
                P_Accesos.Alta_Acceso(Datos.P_Dt_Ventas);
                // enviar impresión de recibos y accesos
                var Obj_Impresiones = new Cls_Ope_Impresiones_Negocio();
                Obj_Impresiones.P_No_Venta = Datos.P_No_Venta;
                Obj_Impresiones.P_Descuento_Pago = Convert.ToDecimal(Datos.P_Descuentos);
                Obj_Impresiones.P_Subtotal_Pago = Convert.ToDecimal(Datos.P_Subtotal);
                Obj_Impresiones.P_Monto_Pago = Convert.ToDecimal(Datos.P_Total);
                Obj_Impresiones.P_Dt_Datos_Pago = Datos.P_Dt_Ventas;
                Obj_Impresiones.P_Dt_Formas_Pago = Datos.P_Dt_Pagos;
                Obj_Impresiones.Imprimir_Pago();

                Estatus_Operacion = true;
                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Realizar_Pago_Grupo: " + Ex.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Estatus_Operacion;
        }
    }
}
