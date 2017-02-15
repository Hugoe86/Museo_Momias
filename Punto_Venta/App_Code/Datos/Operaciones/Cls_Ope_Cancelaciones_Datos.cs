using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using ERP_BASE.App_Code.Datos.Operaciones;
using ERP_BASE.Paginas.Paginas_Generales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ERP_BASE.App_Code.Negocio.Operaciones
{
    class Cls_Ope_Cancelaciones_Datos
    {
        #region (Metodos)

        #region (Operación)
        /// <summary>
        /// Nombre: Cancelar_Venta
        /// 
        /// Descripción: Método que realiza la cancelacion del pago, venta y accesos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 31 Octubre 2013 18:29 hrs.
        /// Usuario Modifico: Olimpo Alberto Cruz Amaya 
        /// Fecha Modifico: 06/Febrero/2015
        /// Motivo: Se agrego un motivo de cancelación.
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static bool Cancelar_Venta(Cls_Ope_Cancelaciones_Negocio Datos) {
            bool Estado_Operacion = false;//Variable que almacena el estatus de la cancelacion.
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

                #region (Cancelar Pagos)
                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Pagos.Tabla_Ope_Pagos);
                Mi_SQL.Append(" set ");
                Mi_SQL.Append(Ope_Pagos.Campo_Estatus + "='CANCELADO'");
                Mi_SQL.Append(", " + Ope_Pagos.Campo_Fecha_Cancelacion + "= " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Pagos.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Cancelar Venta)
                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Ventas.Tabla_Ope_Ventas);
                Mi_SQL.Append(" set ");
                Mi_SQL.Append(Ope_Ventas.Campo_Estatus + "='CANCELADO'");
                
                //Mi_SQL.Append(", " +Ope_Ventas.Campo_Motivo_Cancelacion + "='CANCELADO'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Motivo_Cancelacion + "='" + Datos.P_Motivo_Cancelacion + "'");//"='CANCELADO'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Fecha_Cancelacion + " =now() ");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Usuario_Cancelo + "='" + MDI_Frm_Apl_Principal.Nombre_Login + "'");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");
                

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Cancelar Accesos)
                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Accesos.Tabla_Ope_Accesos);
                Mi_SQL.Append(" set ");
                Mi_SQL.Append(Ope_Accesos.Campo_Estatus + "='CANCELADO'");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Accesos.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();

                Estado_Operacion = true;
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al cancelar las ventas, Metodo: [Cancelar_Venta]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Estado_Operacion;
        }
        #endregion

        #region (Consulta)
        /// <summary>
        /// Nombre: Consultar_Ventas
        /// 
        /// Descripción: Método que realiza la consulta de ventas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 31 Octubre 2013 10:00 hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Tabla con los registros de ventas</returns>
        internal static DataTable Consultar_Ventas(Cls_Ope_Cancelaciones_Negocio Datos) {
            DataTable Dt_Resultado = null ;//Variable que almacenara el resultado de la consulta.
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

                #region (Datos Mostrar)
                Mi_SQL.Append(" select ");
                Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + " ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_No_Pago + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Descuentos + " ");
                Mi_SQL.Append(" , descuentos." + Cat_Descuentos.Campo_Descripcion + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Subtotal + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Impuestos + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Total + " ");
                Mi_SQL.Append(" , " + Cls_Ayudante_Sintaxis.Nulos("forma_pago." + Cat_Formas_Pago.Campo_Nombre, "'Sin Asignar'") + " as forma_pago ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Estatus + " ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Fecha_Creo + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Persona_Tramita + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Empresa + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Fecha_Tramite + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Aplican_Dias_Festivos + " ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Tipo_Tarjeta_Banco + " ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Monto_Comision + " ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Monto_Pago + " ");
                Mi_SQL.Append(" , banco." + Cat_Bancos.Campo_Nombre + " as nombre_banco ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Referencia_Transferencia + " ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Tipo_Tarjeta_Banco + " ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Numero_Tarjeta_Banco + " ");


                #endregion

                #region (Tablas)
                Mi_SQL.Append(" from  ");
                Mi_SQL.Append(" " + Ope_Ventas.Tabla_Ope_Ventas + " venta  ");

                Mi_SQL.Append(" left outer join  " + Ope_Pagos.Tabla_Ope_Pagos + " pago on ");
                Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate() + "=  ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Venta + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate());

                Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " caja on ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Caja + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate() + "=  ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Caja + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate());

                Mi_SQL.Append(" left outer join " + Cat_Motivos_Descuento.Tabla_Cat_Motivos_Descuento + " descuentos on ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_Motivo_ID + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate() + "=  ");
                Mi_SQL.Append(" descuentos." + Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate());

                Mi_SQL.Append(" left outer join " + Cat_Formas_Pago.Tabla_Cat_Formas_Pago + " forma_pago on ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_Forma_ID + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate() + "=  ");
                Mi_SQL.Append(" forma_pago." + Cat_Formas_Pago.Campo_Forma_ID + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate());

                Mi_SQL.Append(" left outer join " + Cat_Bancos.Tabla_Cat_Bancos + " banco on ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_Banco_ID + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate() + "=  ");
                Mi_SQL.Append(" banco." + Cat_Bancos.Campo_Banco_ID + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate());
                #endregion

                #region (Filtros)
                if (!string.IsNullOrEmpty(Datos.P_No_Venta)) {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_No_Pago))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Pago + "='" + Datos.P_No_Pago + "' ");
                }

                //if (!string.IsNullOrEmpty(Datos.P_No_Caja))
                //{
                //    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                //    Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Caja + "='" + Datos.P_No_Caja+ "' ");
                //}

                if (Datos.P_Es_Grupo)
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Persona_Tramita + " is not null ");
                }

                if (Datos.P_Es_Venta)
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Persona_Tramita + " is null ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Persona_Tramita))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" upper(venta." + Ope_Ventas.Campo_Persona_Tramita + ") like upper('%" + Datos.P_Persona_Tramita + "%') ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Empresa_Tramita))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" upper(venta." + Ope_Ventas.Campo_Empresa + ") like upper('%" + Datos.P_Empresa_Tramita + "%') ");
                }
                #endregion

                Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar las ventas, Metodo: [Consultar_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultado  ;
        }
        /// <summary>
        /// Nombre: Consultar_Ventas_Sencilla
        /// 
        /// Descripción: Método que realiza la consulta de ventas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 31 Octubre 2013 10:00 hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Tabla con los registros de ventas</returns>
        internal static DataTable Consultar_Ventas_Sencilla(Cls_Ope_Cancelaciones_Negocio Datos)
        {
            DataTable Dt_Resultado = null;//Variable que almacenara los resultados de la búsqueda.
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

                #region (Datos Mostrar)
                Mi_SQL.Append(" select DISTINCT ");
                Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Descuentos + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Subtotal + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Impuestos + " ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Total + " ");

                if (Datos.P_Es_Venta)
                {
                    Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Fecha_Creo + " as Fecha ");
                }

                if (Datos.P_Es_Grupo)
                {
                    Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Persona_Tramita + " ");
                    Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Empresa + " ");
                    Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Fecha_Tramite + " ");
                    Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Aplican_Dias_Festivos + " ");
                }
                #endregion

                #region (Tablas)
                Mi_SQL.Append(" from  ");
                Mi_SQL.Append(" " + Ope_Ventas.Tabla_Ope_Ventas + " venta  ");

                Mi_SQL.Append(" left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " pago on ");
                Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + " = pago." + Ope_Pagos.Campo_No_Venta + " ");

                Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " caja on ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Caja + " = caja." + Ope_Cajas.Campo_No_Caja + " ");

                Mi_SQL.Append(" left outer join " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja on ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                #endregion

                #region (Filtros)
                if (!string.IsNullOrEmpty(Datos.P_No_Venta))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "' ");
                }

                if (Datos.P_Es_Grupo)
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Persona_Tramita + " is not null ");
                }

                if (Datos.P_Es_Venta)
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Persona_Tramita + " is null ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Persona_Tramita))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" upper(venta." + Ope_Ventas.Campo_Persona_Tramita + ") like upper('%" + Datos.P_Persona_Tramita + "%') ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Empresa_Tramita))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" upper(venta." + Ope_Ventas.Campo_Empresa + ") like upper('%" + Datos.P_Empresa_Tramita + "%') ");
                }

                if (Datos.Fecha_Inicio_Busqueda != null && Datos.Fecha_Inicio_Busqueda != DateTime.MinValue && Datos.Fecha_Fin_Busqueda != null && Datos.Fecha_Fin_Busqueda != DateTime.MinValue)
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" (pago." + Ope_Pagos.Campo_Fecha_Creo + " >= ");
                    Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.Fecha_Inicio_Busqueda));
                    Mi_SQL.Append(" and pago." + Ope_Pagos.Campo_Fecha_Creo + " <= ");
                    Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.Fecha_Fin_Busqueda));
                    Mi_SQL.Append(") ");
                }

                Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                Mi_SQL.Append(" upper(venta." + Ope_Ventas.Campo_Estatus+ ") <> upper('CANCELADO') ");

                Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Caja + " in (");
                Mi_SQL.Append(" select ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Caja);
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(" " + Ope_Cajas.Tabla_Ope_Cajas + " caja  ");
                Mi_SQL.Append(" left outer join " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Estatus + " = 'ABIERTA' ");
                Mi_SQL.Append(" and ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = '" + Datos.P_Caja_Id + "')");
                #endregion

                Mi_SQL.Append(" order by " + Ope_Ventas.Campo_No_Venta + " desc ");

                Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar las ventas, Metodo: [Consultar_Ventas_Sencilla]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultado;
        }
        /// <summary>
        /// Nombre: Consultar_Detalle_Ventas
        /// 
        /// Descripción: Método que consulta los detalles de la venta.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 31 Octubre 2013 10:00 hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Tabla con los detalles de la búsqueda</returns>
        internal static DataTable Consultar_Detalle_Ventas(Cls_Ope_Cancelaciones_Negocio Datos)
        {
            DataTable Dt_Resultado = null;//Variable que almacenara los resultados de la búsqueda.
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

                #region (Datos a Mostrar)
                Mi_SQL.Append(" select ");
                Mi_SQL.Append(" detalle." + Ope_Ventas_Detalles.Campo_Cantidad + " ");
                Mi_SQL.Append(" , producto." + Cat_Productos.Campo_Nombre + " ");
                Mi_SQL.Append(" , detalle." + Ope_Ventas_Detalles.Campo_Subtotal + " ");
                Mi_SQL.Append(" , detalle." + Ope_Ventas_Detalles.Campo_Total + " ");
                #endregion

                #region (Tablas)
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(" " + Ope_Ventas.Tabla_Ope_Ventas + " venta ");

                Mi_SQL.Append(" left outer join " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " detalle on ");
                Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate() + "=  ");
                Mi_SQL.Append(" detalle." + Ope_Ventas_Detalles.Campo_No_Venta + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate());

                Mi_SQL.Append(" left outer join  " + Cat_Productos.Tabla_Cat_Productos + " producto on ");
                Mi_SQL.Append(" detalle." + Ope_Ventas_Detalles.Campo_Producto_Id + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate() + "=  ");
                Mi_SQL.Append(" producto." + Cat_Productos.Campo_Producto_Id + Cls_Ayudante_Sintaxis.Insertar_Default_Database_Collate());
                #endregion

                #region (Filtros)
                if (!string.IsNullOrEmpty(Datos.P_No_Venta))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_No_Pago))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Pago + "='" + Datos.P_No_Pago + "' ");
                }
                #endregion

                Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar las ventas, Metodo: [Consultar_Detalle_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultado;
        }
        /// <summary>
        /// Nombre: Consultar_Cajas
        /// 
        /// Descripción: Método que consulta las cajas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 09 Octubre 2013 10:46 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Listado con los registros de retiros encontrados según los filtros establecidos</returns>
        public static DataTable Consultar_Cajas(Cls_Ope_Cancelaciones_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Cajas = null;//Variable de tipo estructura para almacenar los registros encontrados.
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

                //Crear la consulta.
                Mi_SQL.Append(" select ");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Convertir_A_Caracter("caja." + Cat_Cajas.Campo_Caja_ID) + " as No_Caja ");
                Mi_SQL.Append(" , ('CAJA ' + " + Cls_Ayudante_Sintaxis.Convertir_A_Caracter(Cls_Ayudante_Sintaxis.Convertir_A_Entero("caja." + Ope_Cajas.Campo_No_Caja)) + ") as Caja");
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(" " + Ope_Cajas.Tabla_Ope_Cajas + " caja  ");
                Mi_SQL.Append(" left outer join " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Estatus + " = 'ABIERTA' ");
                //Mi_SQL.Append(" and ");
                //Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = '" + MDI_Frm_Apl_Principal.Caja_ID + "'");

                if (!string.IsNullOrEmpty(Datos.P_No_Caja))
                    Mi_SQL.Append(" and caja.No_Caja='" + Datos.P_No_Caja + "' ");

                Dt_Cajas = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar las cajas, Metodo: [Consultar_Cajas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Cajas;
        }
        #endregion

        #endregion
    }
}
