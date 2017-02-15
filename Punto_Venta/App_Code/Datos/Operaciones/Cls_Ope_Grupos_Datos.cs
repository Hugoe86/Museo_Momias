using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using ERP_BASE.App_Code.Negocio.Operaciones;
using ERP_BASE.Paginas.Paginas_Generales;

namespace ERP_BASE.App_Code.Datos.Operaciones
{
    class Cls_Ope_Grupos_Datos
    {
        #region (Metodos)

        #region (ABC)
        /// <summary>
        /// Nombre: Alta_Grupo
        /// 
        /// Descripción: Método que realiza el alta del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 21 Octubre 2013 18:50
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static bool Alta_Grupo(Cls_Ope_Grupos_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            String No_Venta = "";
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
                No_Venta = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Ventas.Tabla_Ope_Ventas, Ope_Ventas.Campo_No_Venta, "", 10);

                #region (Registrar Venta)
                Mi_SQL.Append("INSERT INTO " + Ope_Ventas.Tabla_Ope_Ventas + " (");
                Mi_SQL.Append(Ope_Ventas.Campo_No_Venta);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Total);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Estatus);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Persona_Tramita);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Empresa);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Fecha_Tramite);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Fecha_Inicio_Vigencia);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Fecha_Fin_Vigencia);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Aplican_Dias_Festivos);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Usuario_Creo);
                Mi_SQL.Append(" , " + Ope_Ventas.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + No_Venta + "'");
                Mi_SQL.Append(", " + Datos.P_Total);
                Mi_SQL.Append(", 'Pendiente'");
                Mi_SQL.Append(", '" + Datos.P_Persona_Tramita + "'");
                Mi_SQL.Append(", '" + Datos.P_Empresa + "'");
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Tramite));
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio_Vigencia));
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino_Vigencia));
                Mi_SQL.Append(", '" + Datos.P_Aplica_Dias_Festivos + "'");
                Mi_SQL.Append(", '" + ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(")");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Registrar Detalle Venta)
                if (Datos.P_Dt_Ventas is DataTable)
                {
                    var detalles_grupo = Datos.P_Dt_Ventas.AsEnumerable()
                        .Select(det_grupo => new
                        {
                            _producto_id = det_grupo.IsNull("PRODUCTO_ID") ? string.Empty : det_grupo.Field<string>("PRODUCTO_ID"),
                            _cantidad = det_grupo.IsNull("CANTIDAD") ? 0.0M : det_grupo.Field<decimal>("CANTIDAD"),
                            _costo = det_grupo.IsNull("COSTO") ? 0.0M : det_grupo.Field<decimal>("COSTO"),
                            _total = det_grupo.IsNull("TOTAL") ? 0.0M : det_grupo.Field<decimal>("TOTAL")
                        });

                    if (detalles_grupo.Any())
                    {
                        foreach (var det_grupo in detalles_grupo)
                        {
                            Mi_SQL.Append("INSERT INTO " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " (" + Ope_Ventas_Detalles.Campo_No_Venta);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Producto_Id);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Cantidad);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Subtotal);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Total);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Usuario_Creo);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Fecha_Creo);
                            Mi_SQL.Append(") VALUES ('");
                            Mi_SQL.Append(No_Venta);
                            Mi_SQL.Append("', '" + det_grupo._producto_id);
                            Mi_SQL.Append("', " + det_grupo._cantidad);
                            Mi_SQL.Append(", " + det_grupo._costo);
                            Mi_SQL.Append(", " + det_grupo._total);
                            Mi_SQL.Append(", '" + ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Nombre_Usuario);
                            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha());
                            Mi_SQL.Append(")");
                            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                            Mi_SQL.Remove(0, Mi_SQL.Length);
                        }
                    }
                }
                #endregion

                Estatus_Operacion = true;

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Grupo: " + Ex.Message);
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
        /// <summary>
        /// Nombre: Actualizar_Grupo
        /// 
        /// Descripción: Método que actualiza los datos del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 22 Octubre 2013 09:28 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Objeto que permite transportar datos de la capa de usuarios a la de datos.</param>
        /// <returns>El estatus de la operación actual</returns>
        public static bool Actualizar_Grupo(Cls_Ope_Grupos_Negocio Datos)
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
                Mi_SQL.Append(Ope_Ventas.Campo_Persona_Tramita + "='" + Datos.P_Persona_Tramita + "'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Empresa + "='" + Datos.P_Empresa + "'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Fecha_Tramite + "=" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Tramite));
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Fecha_Inicio_Vigencia + "=" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio_Vigencia));
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Fecha_Fin_Vigencia + "=" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino_Vigencia));
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Aplican_Dias_Festivos + "='" + Datos.P_Aplica_Dias_Festivos + "'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Total + "=" + Datos.P_Total);
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Usuario_Modifico + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Fecha_Modifico + "=" + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Eliminar Detalle Grupo)
                Mi_SQL.Append("delete from " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles);
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Ventas_Detalles.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Registrar Detalle Venta)
                if (Datos.P_Dt_Ventas is DataTable)
                {
                    var detalles_grupo = Datos.P_Dt_Ventas.AsEnumerable()
                        .Select(det_grupo => new
                        {
                            _producto_id = det_grupo.IsNull("PRODUCTO_ID") ? string.Empty : det_grupo.Field<string>("PRODUCTO_ID"),
                            _cantidad = det_grupo.IsNull("CANTIDAD") ? 0 : det_grupo.Field<int>("CANTIDAD"),
                            _costo = det_grupo.IsNull("COSTO") ? 0 : det_grupo.Field<decimal>("COSTO"),
                            _total = det_grupo.IsNull("TOTAL") ? 0 : det_grupo.Field<decimal>("TOTAL")
                        });

                    if (detalles_grupo.Any())
                    {
                        foreach (var det_grupo in detalles_grupo)
                        {
                            Mi_SQL.Append("INSERT INTO " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " (" + Ope_Ventas_Detalles.Campo_No_Venta);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Producto_Id);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Cantidad);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Subtotal);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Total);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Usuario_Creo);
                            Mi_SQL.Append(", " + Ope_Ventas_Detalles.Campo_Fecha_Creo);
                            Mi_SQL.Append(") VALUES ('");
                            Mi_SQL.Append(Datos.P_No_Venta);
                            Mi_SQL.Append("', '" + det_grupo._producto_id);
                            Mi_SQL.Append("', " + det_grupo._cantidad);
                            Mi_SQL.Append(", " + det_grupo._costo);
                            Mi_SQL.Append(", " + det_grupo._total);
                            Mi_SQL.Append(", '" + ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Nombre_Usuario);
                            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha());
                            Mi_SQL.Append(")");
                            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                            Mi_SQL.Remove(0, Mi_SQL.Length);
                        }
                    }
                }
                #endregion

                Estatus_Operacion = true;
                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Actualizar_Grupo: " + Ex.Message);
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
        /// <summary>
        /// Nombre: Cancelar_Grupo
        /// 
        /// Descripción: Método que cancela la captura del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 22 Octubre 2013 09:47 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Objeto que permite transportar datos de la capa de usuarios a la de datos.</param>
        /// <returns>El estatus de la operación actual</returns>
        public static bool Cancelar_Grupo(Cls_Ope_Grupos_Negocio Datos)
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

                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Ventas.Tabla_Ope_Ventas);
                Mi_SQL.Append(" set ");
                Mi_SQL.Append(Ope_Ventas.Campo_Estatus + "='Cancelado'");
                Mi_SQL.Append(", " + Ope_Ventas.Campo_Motivo_Cancelacion + "='" + Datos.P_Motivo_Cancelacion + "'");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                                
                Estatus_Operacion = true;
                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Cancelar_Grupo: " + Ex.Message);
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
        #endregion

        #region (Consulta)
        /// <summary>
        /// Nombre: Consultar_Grupos
        /// 
        /// Descripción: Método que realiza la consulta de los grupos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 10:34 a.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 24-feb-2014
        /// Causa Modificación: Se cambia el filtro por fecha para se para inicial y final
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static DataTable Consultar_Grupos(Cls_Ope_Grupos_Negocio Datos) {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Transaccion_Activa = false;
            DataTable Dt_Datos = null;
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append(" select venta.*");
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Ventas.Tabla_Ope_Ventas + " venta ");

                if (!string.IsNullOrEmpty(Datos.P_Persona_Tramita))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(" UPPER(" + Ope_Ventas.Campo_Persona_Tramita + ") like UPPER('%" + Datos.P_Persona_Tramita + "%') ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Empresa))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(" UPPER(" + Ope_Ventas.Campo_Empresa + ") like UPPER('%" + Datos.P_Empresa + "%') ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(Ope_Ventas.Campo_Estatus + "='" + Datos.P_Estatus + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_No_Venta))
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append(Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "' ");
                }

                if (Datos.P_Fecha_Inicio_Vigencia != DateTime.MinValue && Datos.P_Fecha_Termino_Vigencia != DateTime.MinValue)
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append("(" + Ope_Ventas.Campo_Fecha_Tramite + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio_Vigencia.AddDays(-1)) + " ");
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino_Vigencia) + ") ");
                }
                else if (Datos.P_Fecha_Inicio_Vigencia != DateTime.MinValue)
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append("(" + Ope_Ventas.Campo_Fecha_Tramite + " >= ");
                    Mi_SQL.Append(" " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio_Vigencia) + ") ");
                }
                else if (Datos.P_Fecha_Termino_Vigencia != DateTime.MinValue)
                {
                    Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                    Mi_SQL.Append("(" + Ope_Ventas.Campo_Fecha_Tramite + " >= ");
                    Mi_SQL.Append(" " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino_Vigencia) + ") ");
                }

                Mi_SQL.Append((Mi_SQL.ToString().ToLower().Contains("where")) ? " and " : " where ");
                Mi_SQL.Append(Ope_Ventas.Campo_Persona_Tramita + " is not null ");

                Dt_Datos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Consultar_Grupos: " + Ex.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Datos;
        }
        /// <summary>
        /// Nombre: Consultar_Detalles_Grupo
        /// 
        /// Descripción: Método que realiza la consulta de los detalles del grupos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 10:34 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static DataTable Consultar_Detalles_Grupo(Cls_Ope_Grupos_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Transaccion_Activa = false;
            DataTable Dt_Datos = null;
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append(" select ");
                Mi_SQL.Append(" detalles_venta." + Ope_Ventas_Detalles.Campo_Cantidad + " as CANTIDAD ");
                Mi_SQL.Append(", producto." + Cat_Productos.Campo_Nombre + " as PRODUCTO ");
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Convertir_A_Decimal("detalles_venta." + Ope_Ventas_Detalles.Campo_Total) + " as TOTAL ");
                Mi_SQL.Append(", detalles_venta." + Ope_Ventas_Detalles.Campo_Producto_Id + " as PRODUCTO_ID ");
                Mi_SQL.Append(", detalles_venta." + Ope_Ventas_Detalles.Campo_Subtotal + " as COSTO ");
                Mi_SQL.Append(", producto." + Cat_Productos.Campo_Tipo + " as TIPO ");
                Mi_SQL.Append(", '' as IMPRIMIR ");

                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " detalles_venta ");

                Mi_SQL.Append(" left outer join " + Cat_Productos.Tabla_Cat_Productos + " producto on ");
                Mi_SQL.Append(" detalles_venta." + Ope_Ventas_Detalles.Campo_Producto_Id + "=producto." + Cat_Productos.Campo_Producto_Id);

                Mi_SQL.Append(" where ");
                Mi_SQL.Append(" detalles_venta." + Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "' ");

                Dt_Datos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Consultar_Grupos: " + Ex.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Datos;
        }
        #endregion

        #endregion
    }
}
