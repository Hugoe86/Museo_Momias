using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Erp.Helper;
using Reportes.Ventas.Negocio;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;
using ERP_BASE.Paginas.Paginas_Generales;
using MySql.Data.MySqlClient;

namespace Reportes.Ventas.Datos
{
    class Cls_Rpt_Ventas_Datos
    {
        #region (Metodos)
        /// <summary>
        /// Nombre: Rpt_Ventas
        /// 
        /// Descripción: Método que consulta las ventas según los filtros establecidos en la búsqueda.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 26 Noviembre 16:33 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de registros de ventas</returns>
        public static DataSet Rpt_Ventas(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
            DataTable Dt_Padre = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            DataTable Dt_Hijos = null;
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Estatus_Where = false;
            
            try
            {
                #region (Consulta Venta)
                Mi_SQL.Append("select ");
                Mi_SQL.Append("vd.No_Venta, ");
                Mi_SQL.Append("v.Fecha_Creo, ");
                Mi_SQL.Append("pr.Nombre, ");
                Mi_SQL.Append("vd.Cantidad, ");
                Mi_SQL.Append("vd.Total Subtotal, ");
                Mi_SQL.Append("v.Descuentos, ");
                Mi_SQL.Append("vd.Total, ");
                Mi_SQL.Append("v.Estatus, ");
                Mi_SQL.Append("concat('Caja ', cc.Numero_Caja) Lugar_Venta,");
                Mi_SQL.Append("case vd.Museo_ID ");
                Mi_SQL.Append("    when '00001' then 'Museo de las Momias' ");
                Mi_SQL.Append("    else 'Culto a la Muerte' ");
                Mi_SQL.Append("end Museo ");
                Mi_SQL.Append("from ");
                Mi_SQL.Append("    ope_ventas_detalles vd ");
                Mi_SQL.Append("    join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID ");
                Mi_SQL.Append("    join cat_productos pr on pr.Producto_Id = vd.Producto_ID ");
                Mi_SQL.Append("    left join (select distinct No_Venta, No_Caja, Museo_ID from ope_pagos p ");
                Mi_SQL.Append("        where p.Fecha_Creo between @FechaIni and @FechaFin) pg on pg.No_venta = v.No_Venta ");
                Mi_SQL.Append("        and pg.Museo_ID = v.Museo_ID ");
                Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = pg.No_Caja");
	            Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno");
                Mi_SQL.Append("    join cat_cajas cc on cc.Caja_ID = oc.Caja_ID ");
                Mi_SQL.Append("where ");
                Mi_SQL.Append("    vd.Fecha_Creo between @FechaIni and @FechaFin ");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append("and vd.Producto_ID = '" + Datos.P_Producto_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Museo))
                {
                    Mi_SQL.Append("and v.Museo_ID = '" + Datos.P_Museo + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Folio_Venta))
                {
                    Mi_SQL.Append("and v.No_Venta = '" + Datos.P_Folio_Venta + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append("and ot.Turno_ID = '" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append("and oc.Caja_ID = '" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    if (Datos.P_Lugar_Venta.Equals("Internet"))
                    {
                        Mi_SQL.Append("and (select Forma_ID from ope_pagos p where ");
                        Mi_SQL.Append("p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID limit 1) = '00005' ");
                    }
                    else
                    {
                        Mi_SQL.Append("and v.Lugar_Venta = '" + Datos.P_Lugar_Venta + "' ");
                    }
                }

                using (MySqlConnection Con = new MySqlConnection())
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.ConnectionString = Cls_Constantes.Cadena_Conexion;
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_SQL.ToString();
                    Cmd.Parameters.AddWithValue("@FechaIni", Datos.P_Fecha_Inicio);
                    Cmd.Parameters.AddWithValue("@FechaFin", Datos.P_Fecha_Termino);

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter())
                    {
                        Dt_Padre = new DataTable();
                        
                        Dt_Padre.Columns.Add("No_Venta", typeof(string));
                        Dt_Padre.Columns.Add("Fecha_Creo", typeof(DateTime));
                        Dt_Padre.Columns.Add("Nombre", typeof(string));
                        Dt_Padre.Columns.Add("Cantidad", typeof(Int32));
                        Dt_Padre.Columns.Add("Subtotal", typeof(double));
                        Dt_Padre.Columns.Add("Descuentos", typeof(double));
                        Dt_Padre.Columns.Add("Total", typeof(double));
                        Dt_Padre.Columns.Add("Estatus", typeof(string));
                        Dt_Padre.Columns.Add("Lugar_Venta", typeof(string));
                        Dt_Padre.Columns.Add("Museo", typeof(string));

                        Adap.SelectCommand = Cmd;
                        Adap.Fill(Dt_Padre);
                    }
                }

                DataRow Totales = Dt_Padre.NewRow();

                Totales["Nombre"] = "Totales";
                Totales["Subtotal"] = (from V in Dt_Padre.AsEnumerable()
                                       where V.Field<string>("Estatus") == "PAGADO"
                                       select V.Field<double>("Subtotal")).Sum();

                Totales["Descuentos"] = (from V in Dt_Padre.AsEnumerable()
                                         where V.Field<string>("Estatus") == "PAGADO"
                                         select V.Field<double>("Descuentos")).Sum();

                Totales["Total"] = (from V in Dt_Padre.AsEnumerable()
                                    where V.Field<string>("Estatus") == "PAGADO"
                                    select V.Field<double>("Total")).Sum();

                Dt_Padre.Rows.Add(Totales);
                #endregion

                if (Datos.Es_Detallado)
                {
                    #region (Consulta Detalles Venta)


                    Mi_SQL.Append(" SELECT ");
                    Mi_SQL.Append(" detalle_venta." + Ope_Ventas_Detalles.Campo_No_Venta + " as NoVenta");
                    Mi_SQL.Append(" ,venta." + Ope_Ventas.Campo_Fecha_Creo + " as Fecha ");
                    Mi_SQL.Append(" ,productos." + Cat_Productos.Campo_Nombre + " as Producto ");
                    Mi_SQL.Append(" ,detalle_venta." + Ope_Ventas_Detalles.Campo_Cantidad + " as Cantidad ");
                    Mi_SQL.Append(" ,detalle_venta." + Ope_Ventas_Detalles.Campo_Subtotal); 
                    Mi_SQL.Append(" ,detalle_venta." + Ope_Ventas_Detalles.Campo_Total);
                    Mi_SQL.Append(" ,venta." + Ope_Ventas.Campo_Estatus + " as Estatus ");

                    if (string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                    {
                        Mi_SQL.Append(" ,cat_caja." + Cat_Cajas.Campo_Numero_Caja + " as NoCaja");
                        Mi_SQL.Append(" ,cat_turno." + Cat_Turnos.Campo_Nombre + " as Turno");
                    }

                    Mi_SQL.Append(" from ");
                    Mi_SQL.Append(" " + Ope_Ventas.Tabla_Ope_Ventas + " venta  ");
                    Mi_SQL.Append(" left OUTER JOIN " + Ope_Pagos.Tabla_Ope_Pagos + " pago ON ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + " = pago." + Ope_Pagos.Campo_No_Venta + " ");
                    Mi_SQL.Append(" left outer join " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " detalle_venta on ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + " = detalle_venta." + Ope_Ventas_Detalles.Campo_No_Venta + " ");

                    if (string.IsNullOrEmpty(Datos.P_Lugar_Venta) || !String.IsNullOrEmpty(Datos.P_Caja_ID))
                    {
                        Mi_SQL.Append(" left OUTER JOIN " + Ope_Cajas.Tabla_Ope_Cajas + " caja ON ");
                        Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Caja + " = caja." + Ope_Cajas.Campo_No_Caja + " ");
                        Mi_SQL.Append(" left OUTER JOIN " + Ope_Turnos.Tabla_Ope_Turnos + " turno ON ");
                        Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Turno + " = turno." + Ope_Turnos.Campo_No_Turno + " ");
                        Mi_SQL.Append(" left OUTER JOIN " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja ON ");
                        Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                        Mi_SQL.Append(" left OUTER JOIN " + Cat_Turnos.Tabla_Cat_Turnos + " cat_turno ON ");
                        Mi_SQL.Append(" turno." + Ope_Turnos.Campo_Turno_ID + " = cat_turno." + Cat_Turnos.Campo_Turno_ID + " ");
                    }
                          
                    Mi_SQL.Append(" left outer join " + Cat_Productos.Tabla_Cat_Productos + " productos on ");
                    Mi_SQL.Append(" detalle_venta." + Ope_Ventas_Detalles.Campo_Producto_Id + " = productos." + Cat_Productos.Campo_Producto_Id + " ");

                    //Mi_SQL.Append(" WHERE ");
                    //Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Estatus + " in ('PAGADO', 'PAGADA') ");
                    //Mi_SQL.Append(" AND ");
                    //Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Persona_Tramita + " IS null ");

                    if (Datos.P_Fecha_Inicio.Year != 1 && Datos.P_Fecha_Termino.Year != 1)
                    {
                        if (Estatus_Where == true)
                        {
                            Mi_SQL.Append(" and ");
                        }
                        else
                        {
                            Mi_SQL.Append(" where ");
                            Estatus_Where = true;
                        }
                        
                        Mi_SQL.Append(" (venta." + Ope_Ventas.Campo_Fecha_Creo + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                        Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");

                    }

                    if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                    {
                       if (Estatus_Where == true)
                        {
                            Mi_SQL.Append(" and ");
                        }
                        else
                        {
                            Mi_SQL.Append(" where ");
                            Estatus_Where = true;
                        }

                        Mi_SQL.Append(" cat_caja." + Cat_Cajas.Campo_Caja_ID + "='" + Datos.P_Caja_ID + "' ");
                    }

                    if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                    {
                       if (Estatus_Where == true)
                        {
                            Mi_SQL.Append(" and ");
                        }
                        else
                        {
                            Mi_SQL.Append(" where ");
                            Estatus_Where = true;
                        }

                        Mi_SQL.Append(" cat_turno." + Cat_Turnos.Campo_Turno_ID + "='" + Datos.P_Turno_ID + "' ");
                    }

                    if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                    {
                       if (Estatus_Where == true)
                        {
                            Mi_SQL.Append(" and ");
                        }
                        else
                        {
                            Mi_SQL.Append(" where ");
                            Estatus_Where = true;
                        }

                        Mi_SQL.Append(" detalle_venta." + Ope_Ventas_Detalles.Campo_Producto_Id + "='" + Datos.P_Producto_ID + "' ");
                    }


                    if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                    {
                      
                        if(Datos.P_Lugar_Venta == "Internet")
                        {
                            if (Estatus_Where == true)
                            {
                                Mi_SQL.Append(" and ");
                            }
                            else
                            {
                                Mi_SQL.Append(" where ");
                                Estatus_Where = true;
                            }

                            Mi_SQL.Append(" pago." + Ope_Pagos.Campo_Forma_ID + " = '00005'");
                        }
                        else
                        {
                            if (Estatus_Where == true)
                            {
                                Mi_SQL.Append(" and ");
                            }
                            else
                            {
                                Mi_SQL.Append(" where ");
                                Estatus_Where = true;
                            }

                              Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                        }
                    }

                    Mi_SQL.Append(" GROUP BY detalle_venta." +  Ope_Ventas_Detalles.Campo_No_Venta);
                    Mi_SQL.Append(", detalle_venta." + Ope_Ventas_Detalles.Campo_Producto_Id);

                    Mi_SQL.Append(" ORDER BY detalle_venta." + Ope_Ventas.Campo_No_Venta + " desc ");

                    Mi_SQL.Clear();
                    #endregion
                }
                
                Dt_Padre.TableName = "Padre";
                Ds_Resultado.Tables.Add(Dt_Padre);
                
                if (Datos.Es_Detallado)
                {
                    Dt_Hijos.TableName = "Hijos";
                    Ds_Resultado.Tables.Add(Dt_Hijos);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
            }

            return Ds_Resultado;
        }
        /// <summary>
        /// Nombre: Rpt_Movimientos_Caja
        /// 
        /// Descripción: Método que consulta los movimientos en caja.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 09:33 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de registros de movimientos de caja</returns>
        public static DataTable Rpt_Movimientos_Caja(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataTable Dt_Resultados_Busqueda = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
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

                Mi_SQL.Append(" SELECT ");
                if (Datos.Es_Detallado)
                {
                    Mi_SQL.Append("rec." + Ope_Recolecciones.Campo_No_Recoleccion + " as NoMovimiento, ");
                    Mi_SQL.Append("rec." + Ope_Recolecciones.Campo_Fecha_Hora + " as Fecha, ");
                }
                Mi_SQL.Append(" cat_caja." + Cat_Cajas.Campo_Numero_Caja + " as  NoCaja ");
                Mi_SQL.Append(" ,cat_turno." + Cat_Turnos.Campo_Nombre + " as Turno");
                Mi_SQL.Append(" ," + ((!Datos.Es_Detallado) ? "SUM" : string.Empty) + "(" + Cls_Ayudante_Sintaxis.Nulos("rec." + Ope_Recolecciones.Campo_Monto_Recolectado, "0") + ") as Total ");
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(" " + Ope_Recolecciones.Tabla_Ope_Recolecciones + " rec ");
                Mi_SQL.Append(" left OUTER JOIN " + Ope_Cajas.Tabla_Ope_Cajas + " caja ON ");
                Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_No_Caja + " = caja." + Ope_Cajas.Campo_No_Caja + " ");
                Mi_SQL.Append(" left OUTER JOIN " + Ope_Turnos.Tabla_Ope_Turnos + " turno ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Turno + " = turno." + Ope_Turnos.Campo_No_Turno + " ");
                Mi_SQL.Append(" left OUTER JOIN " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                Mi_SQL.Append(" left OUTER JOIN " + Cat_Turnos.Tabla_Cat_Turnos + " cat_turno ON ");
                Mi_SQL.Append(" turno." + Ope_Turnos.Campo_Turno_ID + " = cat_turno." + Cat_Turnos.Campo_Turno_ID + " ");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_Estatus + " = '" + (Datos.P_Tipo_Movimiento.Equals("RECOLECCION") ? "RECOLECTADO" : "ARQUEO") + "' ");

                if (!string.IsNullOrEmpty(Datos.P_Tipo_Movimiento))
                    Mi_SQL.Append(" and rec." + Ope_Recolecciones.Campo_Tipo + " = '" + Datos.P_Tipo_Movimiento + "' ");

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                    Mi_SQL.Append(" and cat_caja." + Cat_Cajas.Campo_Caja_ID + " = '" + Datos.P_Caja_ID + "' ");

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                    Mi_SQL.Append(" and cat_turno." + Cat_Turnos.Campo_Turno_ID + " = '" + Datos.P_Turno_ID + "' ");

                if (Datos.P_Fecha_Inicio.Year != 1 && Datos.P_Fecha_Termino.Year != 1)
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" (rec." + Ope_Recolecciones.Campo_Fecha_Hora + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                    Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");
                }

                if (!Datos.Es_Detallado)
                {
                    Mi_SQL.Append(" GROUP BY  ");
                    Mi_SQL.Append(" cat_caja." + Cat_Cajas.Campo_Numero_Caja + " ");
                    Mi_SQL.Append(" ,cat_turno." + Cat_Turnos.Campo_Nombre + " ");
                }

                Dt_Resultados_Busqueda = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (Datos.Es_Detallado && Dt_Resultados_Busqueda.Rows.Count > 0)
                {
                    DataRow Dr = Dt_Resultados_Busqueda.NewRow();

                    Dr["NoMovimiento"] = "Totales";
                    Dr["Total"] = Dt_Resultados_Busqueda.AsEnumerable()
                        .Sum(x => x.Field<decimal>("Total"));
                    Dt_Resultados_Busqueda.Rows.Add(Dr);
                }

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de movimientos en caja, Metodo: [Rpt_Movimientos_Caja]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultados_Busqueda;
        }
        /// <summary>
        /// Nombre: Consultar_Producto
        /// 
        /// Descripción: Método que consulta los productos que existen actualmente en catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 26 Noviembre 16:33 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de productos</returns>
        public static DataTable Consultar_Producto(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataTable Dt_Resultados_Busqueda = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
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

                Mi_SQL.Append(" select ");
                Mi_SQL.Append(" p.* ");
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Cat_Productos.Tabla_Cat_Productos + " as p ");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID)) {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" p." + Cat_Productos.Campo_Producto_Id + "='" + Datos.P_Producto_ID + "'"); 
                }

                //Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                //Mi_SQL.Append(" p." + Cat_Productos.Campo_Estatus + "='ACTIVO'");

                Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                Mi_SQL.Append(" p." + Cat_Productos.Campo_Tipo_Servicio + " <> 'ESTACIONAMIENTO'");

                Mi_SQL.Append(" order by p." + Cat_Productos.Campo_Nombre + " asc ");

                Dt_Resultados_Busqueda = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (Dt_Resultados_Busqueda is DataTable)
                {
                    DataRow Dr = Dt_Resultados_Busqueda.NewRow();
                    Dr[Cat_Productos.Campo_Producto_Id] = string.Empty;
                    Dr[Cat_Productos.Campo_Nombre] = "SELECCIONE";
                    Dt_Resultados_Busqueda.Rows.InsertAt(Dr, 0);
                }

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultados_Busqueda;
        }
        /// <summary>
        /// Nombre: Consultar_Productos_Acceso
        /// 
        /// Descripción: Método que consulta los productos que existen actualmente en catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 26 Noviembre 16:33 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de productos</returns>
        public static DataTable Consultar_Productos_Acceso(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataTable Dt_Resultados_Busqueda = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
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

                Mi_SQL.Append(" select ");
                Mi_SQL.Append(" p." + Cat_Productos.Campo_Producto_Id);
                Mi_SQL.Append(" ,p." + Cat_Productos.Campo_Nombre);
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Cat_Productos.Tabla_Cat_Productos + " as p ");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" p." + Cat_Productos.Campo_Producto_Id + "='" + Datos.P_Producto_ID + "'");
                }

                Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                Mi_SQL.Append(" p." + Cat_Productos.Campo_Estatus + "='ACTIVO'");

                Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                Mi_SQL.Append(" p." + Cat_Productos.Campo_Tipo_Servicio + " <> 'ESTACIONAMIENTO'");

                Mi_SQL.Append(" order by p." + Cat_Productos.Campo_Nombre + " asc ");

                Dt_Resultados_Busqueda = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (Dt_Resultados_Busqueda is DataTable)
                {
                    DataRow Dr = Dt_Resultados_Busqueda.NewRow();
                    Dr[Cat_Productos.Campo_Producto_Id] = string.Empty;
                    Dr[Cat_Productos.Campo_Nombre] = "";
                    Dt_Resultados_Busqueda.Rows.InsertAt(Dr, 0);
                }

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultados_Busqueda;
        }
        /// <summary>
        /// Nombre: Consultar_Producto
        /// 
        /// Descripción: Método que consulta los productos que existen actualmente en catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 26 Noviembre 16:33 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de productos</returns>
        public static DataTable Consultar_Productos(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataTable Dt_Resultados_Busqueda = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
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

                Mi_SQL.Append(" select ");
                Mi_SQL.Append(" p." + Cat_Productos.Campo_Nombre + " as Tarifa");
                Mi_SQL.Append(" ,p." + Cat_Productos.Campo_Costo);
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Cat_Productos.Tabla_Cat_Productos + " as p ");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Cat_Productos.Campo_Tipo + "='Producto'");
                Mi_SQL.Append(" and ");
                Mi_SQL.Append(Cat_Productos.Campo_Estatus + "='ACTIVO'");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" p." + Cat_Productos.Campo_Producto_Id + "='" + Datos.P_Producto_ID + "'");
                }

                Mi_SQL.Append(" order by ");
                Mi_SQL.Append(Cat_Productos.Campo_Costo);
                Mi_SQL.Append(" desc ");

                Dt_Resultados_Busqueda = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultados_Busqueda;
        }
        /// <summary>
        /// Nombre: Consultar_Retiros
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_Retiros(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Retiros = null;//Variable de tipo estructura para almacenar los registros encontrados.
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
                Mi_SQL.Append("select ");

                if (Datos.Es_Detallado)
                {
                    Mi_SQL.Append("retiros." + Ope_Retiros.Campo_No_Retiro + " as NoRetiro ");
                    Mi_SQL.Append(", retiros." + Ope_Retiros.Campo_Fecha + ", ");
                }

                Mi_SQL.Append(" cat_caja." + Cat_Cajas.Campo_Numero_Caja  + " as NoCaja ");
                Mi_SQL.Append(", cat_turno." + Cat_Turnos.Campo_Nombre + " as Turno ");

                if (!Datos.Es_Detallado)
                    Mi_SQL.Append(", sum(" + Cls_Ayudante_Sintaxis.Nulos("retiros." + Ope_Retiros.Campo_Cantidad,"0") + ") as Total ");
                else
                    Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Nulos("retiros." + Ope_Retiros.Campo_Cantidad,"0") + " as Total ");

                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Retiros.Tabla_Ope_Retiros + " retiros ");
                Mi_SQL.Append(" left OUTER JOIN " + Ope_Cajas.Tabla_Ope_Cajas + " caja ON ");
                Mi_SQL.Append(" retiros." + Ope_Retiros.Campo_No_Caja + " = caja." + Ope_Cajas.Campo_No_Caja + " ");
                Mi_SQL.Append(" left OUTER JOIN " + Ope_Turnos.Tabla_Ope_Turnos + " turno ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Turno + " = turno." + Ope_Turnos.Campo_No_Turno + " ");
                Mi_SQL.Append(" left OUTER JOIN " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                Mi_SQL.Append(" left OUTER JOIN " + Cat_Turnos.Tabla_Cat_Turnos + " cat_turno ON ");
                Mi_SQL.Append(" turno." + Ope_Turnos.Campo_Turno_ID + " = cat_turno." + Cat_Turnos.Campo_Turno_ID + " ");

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" cat_caja." + Cat_Cajas.Campo_Caja_ID + "='" + Datos.P_Caja_ID + "'");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" cat_turno." + Cat_Turnos.Campo_Turno_ID + "='" + Datos.P_Turno_ID + "'");
                }

                if (Datos.P_Fecha_Inicio.Year != 1 && Datos.P_Fecha_Termino.Year != 1)
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" (retiros." + Ope_Retiros.Campo_Fecha + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                    Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");
                }

                if (!Datos.Es_Detallado)
                {
                    Mi_SQL.Append(" GROUP BY ");
                    Mi_SQL.Append(" cat_caja." + Cat_Cajas.Campo_Numero_Caja);
                    Mi_SQL.Append(", cat_turno." + Cat_Turnos.Campo_Nombre);                
                }
                else
                    Mi_SQL.Append(" order by retiros." + Ope_Retiros.Campo_No_Retiro + " desc ");
                Dt_Retiros = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();

                if (Datos.Es_Detallado && Dt_Retiros.Rows.Count > 0)
                {
                    DataRow Dr = Dt_Retiros.NewRow();

                    Dr["NoRetiro"] = "Totales";
                    Dr["Total"] = Dt_Retiros.AsEnumerable()
                        .Sum(x => x.Field<decimal>("Total"));
                    Dt_Retiros.Rows.Add(Dr);
                }
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Retiros]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Retiros;
        }
        #endregion

        #region (Reportes)
        /// <summary>
        /// Nombre: Rpt_Ventas
        /// 
        /// Descripción: Método que consulta las ventas según los filtros establecidos en la búsqueda.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 26 Noviembre 16:33 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de registros de ventas</returns>
        public static DataSet Rpt_Concentrado_Ventas(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.

            try
            {
                #region (Datos de la Venta)
                Mi_SQL.Append("select ");
	            Mi_SQL.Append("p.Nombre Tarifa, ");
	            Mi_SQL.Append("p.Costo Importe_Tarifa, ");
                Mi_SQL.Append("p.Tipo, ");
	            Mi_SQL.Append("sum(vd.cantidad) Ventas, ");
	            Mi_SQL.Append("sum(vd.Total) Importe_Total ");
                Mi_SQL.Append("from  ");
	            Mi_SQL.Append("ope_ventas_detalles vd ");
                Mi_SQL.Append("join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID ");
                Mi_SQL.Append("join (select distinct pg.No_Venta, pg.No_Caja, pg.Museo_ID from ope_pagos pg where pg.Fecha_Creo ");
                Mi_SQL.Append("    between @FechaIni and @FechaFin) p on p.No_Venta = vd.No_Venta and p.Museo_ID = vd.Museo_ID ");
	            Mi_SQL.Append("join ope_cajas oc on oc.No_Caja = p.No_Caja ");
	            Mi_SQL.Append("join ope_turnos ot on ot.No_Turno = oc.No_Turno ");
	            Mi_SQL.Append("join cat_productos p on p.Producto_Id = vd.Producto_ID ");
                Mi_SQL.Append("where  ");
                Mi_SQL.Append("vd.Fecha_Creo between @FechaIni and @FechaFin ");
                Mi_SQL.Append("and v.Estatus = 'PAGADO' ");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append("and vd.Producto_ID = '" + Datos.P_Producto_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Museo))
                {
                    Mi_SQL.Append("and v.Museo_ID = '" + Datos.P_Museo + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append("and ot.Turno_ID = '" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append("and oc.Caja_ID = '" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    if (Datos.P_Lugar_Venta.Equals("Internet"))
                    {
                        Mi_SQL.Append("and (select Forma_ID from ope_pagos p where ");
                        Mi_SQL.Append("p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID limit 1) = '00005' ");
                    }
                    else
                    {
                        Mi_SQL.Append("and v.Lugar_Venta = '" + Datos.P_Lugar_Venta + "' ");
                    }
                }

                Mi_SQL.Append("group by ");
	            Mi_SQL.Append("vd.Producto_ID; ");

                #endregion

                #region (Totales Venta)

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append("select ");
                    Mi_SQL.Append("    concat('Caja ', cc.Numero_Caja) No_Caja, ");
                    Mi_SQL.Append("    count(*) Total_Folios,");
                    Mi_SQL.Append("    (select count(*) from ope_accesos a where a.No_Venta between min(vd.No_Venta) and max(vd.No_Venta) and a.Producto_Id = '" + Datos.P_Producto_ID + "')");
                    Mi_SQL.Append("    Total ");
                    Mi_SQL.Append("from ");
                    Mi_SQL.Append("    ope_ventas_detalles vd ");
                    Mi_SQL.Append("    join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID ");
                    Mi_SQL.Append("    join (select distinct pg.No_Venta, pg.Museo_ID, pg.No_Caja from ope_pagos pg where pg.Fecha_Creo ");
                    Mi_SQL.Append("        between @FechaIni and @FechaFin) p ");
                    Mi_SQL.Append("        on p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID ");
                    Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = p.No_Caja ");
                    Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno ");
                    Mi_SQL.Append("    join cat_cajas cc on cc.Caja_ID = oc.Caja_ID  ");
                    Mi_SQL.Append("where ");
                    Mi_SQL.Append("    vd.Fecha_Creo between @FechaIni and @FechaFin ");
                    Mi_SQL.Append("    and vd.Producto_ID = '" + Datos.P_Producto_ID + "' ");
                }
                else
                {
                    Mi_SQL.Append("select ");
                    Mi_SQL.Append("    concat('Caja ', cc.Numero_Caja) No_Caja, ");
                    Mi_SQL.Append("    min(v.No_Venta) Folio_Inicial, ");
                    Mi_SQL.Append("    max(v.No_Venta) Folio_Final, ");
                    Mi_SQL.Append("    (select min(a.No_Acceso) from ope_accesos a where a.No_Venta between min(v.No_Venta) and max(v.No_Venta)) Inicial, ");
                    Mi_SQL.Append("    (select max(a.No_Acceso) from ope_accesos a where a.No_Venta between min(v.No_Venta) and max(v.No_Venta)) Final ");
                    Mi_SQL.Append("from ");
                    Mi_SQL.Append("    ope_ventas_detalles vd ");
                    Mi_SQL.Append("    join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_Id ");
                    Mi_SQL.Append("    join ope_pagos p on p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID ");
                    Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = p.No_Caja ");
                    Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno ");
                    Mi_SQL.Append("    join cat_cajas cc on cc.Caja_ID = oc.Caja_ID  ");
                    Mi_SQL.Append("where ");
                    Mi_SQL.Append("    v.Fecha_Creo between @FechaIni and @FechaFin ");
                }
                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append("and vd.Producto_ID = '" + Datos.P_Producto_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Museo))
                {
                    Mi_SQL.Append("and v.Museo_ID = '" + Datos.P_Museo + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append("and ot.Turno_ID = '" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append("and oc.Caja_ID = '" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    if (Datos.P_Lugar_Venta.Equals("Internet"))
                    {
                        Mi_SQL.Append("and (select Forma_ID from ope_pagos p where ");
                        Mi_SQL.Append("p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID limit 1) = '00005' ");
                    }
                    else
                    {
                        Mi_SQL.Append("and v.Lugar_Venta = '" + Datos.P_Lugar_Venta + "' ");
                    }
                }

                Mi_SQL.Append("group by ");
                Mi_SQL.Append("    oc.Caja_ID; ");

                DataSet Resultados = new DataSet();
                using (MySqlConnection Con = new MySqlConnection())
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.ConnectionString = Cls_Constantes.Cadena_Conexion;
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_SQL.ToString();
                    Cmd.Parameters.AddWithValue("@FechaIni", Datos.P_Fecha_Inicio);
                    Cmd.Parameters.AddWithValue("@FechaFin", Datos.P_Fecha_Termino);

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter())
                    {
                        Adap.SelectCommand = Cmd;
                        Adap.Fill(Resultados);
                    }
                }
                #endregion

                if (string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Resultados.Tables[1].Columns.Add("Total_Folios", typeof(Int64)); // Folios de Venta
                    Resultados.Tables[1].Columns.Add("Total", typeof(Int64)); // Folios de Acceso

                    Resultados.Tables[1].Columns["Total_Folios"].SetOrdinal(3);
                }
                else
                {
                    Resultados.Tables[1].Columns.Add("Folio_Inicial", typeof(string));
                    Resultados.Tables[1].Columns.Add("Folio_Final", typeof(string));

                    Resultados.Tables[1].Columns["Folio_Inicial"].SetOrdinal(1);
                    Resultados.Tables[1].Columns["Folio_Final"].SetOrdinal(2);

                    Resultados.Tables[1].Columns.Add("Inicial", typeof(string));
                    Resultados.Tables[1].Columns.Add("Final", typeof(string));

                    Resultados.Tables[1].Columns["Total_Folios"].SetOrdinal(3);
                    Resultados.Tables[1].Columns["Total"].SetOrdinal(6);
                }

                for (int i = 0; i < Resultados.Tables[1].Rows.Count; i++)
                {
                    string Folio_Inicial;
                    string Folio_Final;
                    Int64 Total;

                    if (string.IsNullOrEmpty(Datos.P_Producto_ID))
                    {
                        Folio_Inicial = Resultados.Tables[1].Rows[i]["Folio_Inicial"].ToString();
                        Folio_Final = Resultados.Tables[1].Rows[i]["Folio_Final"].ToString();

                        Total = Int64.Parse(Folio_Final.Substring(1)) - Int64.Parse(Folio_Inicial.Substring(1));

                        Resultados.Tables[1].Rows[i]["Total_Folios"] = Total + 1;
                    }
                    else
                    {
                        Resultados.Tables[1].Rows[i]["Folio_Inicial"] = "Ver Detalle";
                        Resultados.Tables[1].Rows[i]["Folio_Final"] = "Ver Detalle";
                    }
                    
                    /***************************************************************************************/
                    if (string.IsNullOrEmpty(Datos.P_Producto_ID))
                    {
                        string Acceso_Inicial = Resultados.Tables[1].Rows[i]["Inicial"].ToString();
                        string Acceso_Final = Resultados.Tables[1].Rows[i]["Final"].ToString();

                        if (Acceso_Inicial != string.Empty && Acceso_Final != string.Empty)
                        {
                            Total = Int64.Parse(Acceso_Final.Substring(1)) - Int64.Parse(Acceso_Inicial.Substring(1));

                            Resultados.Tables[1].Rows[i]["Total"] = Total + 1;
                        }
                        else
                        {
                            Resultados.Tables[1].Rows[i]["Inicial"] = "N/A";
                            Resultados.Tables[1].Rows[i]["Final"] = "N/A";
                            Resultados.Tables[1].Rows[i]["Total"] = 0;
                        }
                    }
                    else
                    {
                        Resultados.Tables[1].Rows[i]["Inicial"] = "Ver Detalle";
                        Resultados.Tables[1].Rows[i]["Final"] = "Ver Detalle";
                    }
                }

                Resultados.Tables[0].TableName = "Concentrado_Ventas_Tarifa";
                Resultados.Tables[1].TableName = "Concentrado_Folios";
                
                return Resultados;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
            }
        }
        /// <summary>
        /// Nombre: Rpt_Detalle_Ventas
        /// 
        /// Descripción: Método que consulta el detalle de las ventas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 26 Noviembre 2014
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de registros de ventas</returns>
        public static DataSet Rpt_Detalle_Ventas(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            
            try
            {
                DataTable Detalle_Venta = new DataTable();

                Detalle_Venta.Columns.Add("Folio_Venta", typeof(string));
                Detalle_Venta.Columns.Add("Folio_Acceso", typeof(string));
                Detalle_Venta.Columns.Add("Tarifa", typeof(decimal));
                Detalle_Venta.Columns.Add("Fecha_Expedicion_Folio", typeof(DateTime));
                Detalle_Venta.Columns.Add("Lugar_Venta", typeof(string));
                Detalle_Venta.Columns.Add("Estado_Folio", typeof(string));
                Detalle_Venta.Columns.Add("Acceso_Torniquete", typeof(DateTime));
                Detalle_Venta.Columns.Add("Usuario_Reimprimio", typeof(string));
                Detalle_Venta.Columns.Add("Fecha_Reimpresion", typeof(DateTime));
                Detalle_Venta.Columns.Add("Forma_Pago", typeof(string));
                Detalle_Venta.Columns.Add("Cantidad", typeof(int));

                /*********************************  Query para los Accesos *********************************/
                Mi_SQL.Append("select ");
                Mi_SQL.Append("a.No_Venta Folio_Venta,");
                Mi_SQL.Append("a.No_Acceso Folio_Acceso,");
                Mi_SQL.Append("pr.Costo Tarifa,");
                Mi_SQL.Append("a.Fecha_Expedicion Fecha_Expedicion_Folio,");
                Mi_SQL.Append("case v.Lugar_Venta");
		        Mi_SQL.Append("    when 'No Caja' then concat('No Caja ', cc.Numero_Caja)");
		        Mi_SQL.Append("    else v.Lugar_Venta ");
                Mi_SQL.Append("end Lugar_Venta,");
                Mi_SQL.Append("a.Estatus Estado_Folio,");
                Mi_SQL.Append("a.Fecha_Hora_Acceso Acceso_Torniquete,");
                Mi_SQL.Append("a.Usuario_Reimprimio,");
                Mi_SQL.Append("a.Fecha_Reimpresion,");
                Mi_SQL.Append("case when (select count(*) from ope_pagos p where p.No_Venta = a.No_Venta) > 1 then 'Mixto' else ");
                Mi_SQL.Append("(select cp.Nombre from ope_pagos pg ");
                Mi_SQL.Append("    join cat_formas_pago cp on cp.Forma_ID = pg.Forma_ID ");
                Mi_SQL.Append("    where pg.No_Venta = a.No_Venta) end Forma_Pago, ");
                Mi_SQL.Append("0 Cantidad ");
                Mi_SQL.Append("from ");
                Mi_SQL.Append("    ope_accesos a ");
                Mi_SQL.Append("    join (select distinct No_Venta, No_Caja from ope_pagos where Fecha_Creo between @FechaIni and @FechaFin) p ");
                Mi_SQL.Append("        on p.No_Venta = a.No_Venta ");
                Mi_SQL.Append("    join ope_ventas v on v.No_Venta = a.No_Venta");
                Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = p.No_Caja ");
                Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno ");
                Mi_SQL.Append("    join cat_cajas cc on cc.Caja_ID = oc.Caja_ID");
                Mi_SQL.Append("    join cat_productos pr on a.Producto_ID = pr.Producto_Id ");
                Mi_SQL.Append("where ");
                Mi_SQL.Append("    a.Fecha_Expedicion between @FechaIni and @FechaFin ");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append("and a.Producto_ID = '" + Datos.P_Producto_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Museo))
                {
                    Mi_SQL.Append("and v.Museo_ID = '" + Datos.P_Museo + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append("and v.Estatus = '" + Datos.P_Estatus + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Folio_Acceso))
                {
                    Mi_SQL.Append("and a.No_Acceso = '" + Datos.P_Folio_Acceso + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append("and ot.Turno_ID = '" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append("and oc.Caja_ID = '" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    if (Datos.P_Lugar_Venta.Equals("Internet"))
                    {
                        Mi_SQL.Append("and (select Forma_ID from ope_pagos p where ");
                        Mi_SQL.Append("p.No_Venta = v.No_Venta limit 1) = '00005' ");
                    }
                    else
                    {
                        Mi_SQL.Append("and v.Lugar_Venta = '" + Datos.P_Lugar_Venta + "' ");
                    }
                }

                Mi_SQL.Append("UNION ");
                /************************** Query para los Servicios *************************/
                
                Mi_SQL.Append("select ");
                Mi_SQL.Append("vd.No_Venta,");
	            Mi_SQL.Append("'' No_Acceso,");
                Mi_SQL.Append("p.Costo Tarifa,");
	            Mi_SQL.Append("NULL Fecha_Expedicion,");
                Mi_SQL.Append("case v.Lugar_Venta");
		        Mi_SQL.Append("    when 'No Caja' then concat('No Caja ', cc.Numero_Caja)");
		        Mi_SQL.Append("    else v.Lugar_Venta ");
                Mi_SQL.Append("end Lugar_Venta,");
	            Mi_SQL.Append("'' Estatus,");
	            Mi_SQL.Append("NULL Fecha_Hora_Acceso,");
                Mi_SQL.Append("'' Usuario_Reimprimio,");
	            Mi_SQL.Append("NULL Fecha_Reimpresion,");
	            Mi_SQL.Append("case when (select count(*) from ope_pagos pg where pg.No_Venta = vd.No_Venta and pg.Museo_ID = vd.Museo_ID) > 1 then 'Mixto' else ");
		        Mi_SQL.Append("    (select cp.Nombre from ope_pagos pg join cat_formas_pago cp on cp.Forma_ID = pg.Forma_ID ");
			    Mi_SQL.Append("        where pg.No_Venta = vd.No_Venta and pg.Museo_ID = vd.Museo_ID) end Forma_Pago,");
	            Mi_SQL.Append("vd.Cantidad ");
                Mi_SQL.Append("from ");
	            Mi_SQL.Append("    ope_ventas_detalles vd ");
	            Mi_SQL.Append("    join (select distinct pg.No_Venta, pg.Museo_ID, pg.No_Caja from ope_pagos pg ");
		        Mi_SQL.Append("        where pg.Fecha_Creo between @FechaIni and @FechaFin) p ");
		        Mi_SQL.Append("        on p.No_Venta = vd.No_Venta and p.Museo_ID = vd.Museo_ID ");
                Mi_SQL.Append("    join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID");
                Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = p.No_Caja ");
	            Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno ");
                Mi_SQL.Append("    join cat_cajas cc on cc.Caja_ID = oc.Caja_ID");
	            Mi_SQL.Append("    join cat_productos p on p.Producto_Id = vd.Producto_ID ");
                Mi_SQL.Append("where ");
                Mi_SQL.Append("    vd.Fecha_Creo between @FechaIni and @FechaFin");
	            Mi_SQL.Append("    and p.Tipo = 'Servicio' ");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append("and vd.Producto_ID = '" + Datos.P_Producto_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Museo))
                {
                    Mi_SQL.Append("and v.Museo_ID = '" + Datos.P_Museo + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append("and v.Estatus = '" + Datos.P_Estatus + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Folio_Acceso))
                {
                    Mi_SQL.Append("and 1 = 0 ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append("and ot.Turno_ID = '" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append("and oc.Caja_ID = '" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    if (Datos.P_Lugar_Venta.Equals("Internet"))
                    {
                        Mi_SQL.Append("and (select Forma_ID from ope_pagos p where ");
                        Mi_SQL.Append("p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID limit 1) = '00005' ");
                    }
                    else
                    {
                        Mi_SQL.Append("and v.Lugar_Venta = '" + Datos.P_Lugar_Venta + "' ");
                    }
                }

                using (MySql.Data.MySqlClient.MySqlConnection Con = new MySql.Data.MySqlClient.MySqlConnection())
                using (MySql.Data.MySqlClient.MySqlCommand Cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    Con.ConnectionString = Conexion.HelperGenerico.P_Cadena_Conexion;
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_SQL.ToString();

                    Cmd.Parameters.AddWithValue("@FechaIni", Datos.P_Fecha_Inicio);
                    Cmd.Parameters.AddWithValue("@FechaFin", Datos.P_Fecha_Termino);

                    using (MySql.Data.MySqlClient.MySqlDataAdapter Adap 
                        = new MySql.Data.MySqlClient.MySqlDataAdapter())
                    {
                        Adap.SelectCommand = Cmd;
                        Adap.Fill(Detalle_Venta);

                        var Servicios = from Det in Detalle_Venta.AsEnumerable()
                                        where Det.Field<int>("Cantidad") > 1
                                        select Det;

                        if (Servicios.Any())
                        {
                            DataTable _Servicios = Servicios.CopyToDataTable();

                            foreach (DataRow Servicio in _Servicios.Rows)
                            {
                                int Cantidad = Convert.ToInt32(Servicio["Cantidad"]);

                                for (int i = 0; i < Cantidad - 1; i++)
                                {
                                    DataRow Des = Detalle_Venta.NewRow();
                                    Des.ItemArray = Servicio.ItemArray.Clone() as object[];

                                    Detalle_Venta.Rows.Add(Des);
                                }
                            }
                        }

                        Detalle_Venta.Columns.Remove("Cantidad");

                        var Aux_Detalle_Venta = from V in Detalle_Venta.AsEnumerable()
                                                orderby V.Field<string>("Folio_Venta") ascending,
                                                V.Field<string>("Folio_Acceso") ascending
                                                select V;

                        if (Aux_Detalle_Venta.Any())
                        {
                            Detalle_Venta = Aux_Detalle_Venta.CopyToDataTable();
                            decimal Total = (decimal)Detalle_Venta.Compute("SUM(Tarifa)", "");

                            DataRow Totales = Detalle_Venta.NewRow();

                            Totales["Tarifa"] = Total;

                            Detalle_Venta.Rows.Add(Totales);
                        }

                        Detalle_Venta.TableName = "Detalle_Ventas";
                        Ds_Resultado.Tables.Add(Detalle_Venta);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                
            }

            return Ds_Resultado;
        }

        /// <summary>
        /// Nombre: Rpt_Ventas_Internet
        /// 
        /// Descripción: Método que consulta ventas de internet
        /// 
        /// Usuario Creo: Olimpo Cruz Amaya
        /// Fecha Creo: 02 Junio 2015
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de registros de ventas</returns>
        public static DataSet Rpt_Ventas_Internet(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
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

                Mi_SQL.Append("select ");
                //Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + " as Folio_Venta");
                Mi_SQL.Append("acceso." + Ope_Accesos.Campo_No_Acceso + " as Folio_Acceso ");
                Mi_SQL.Append(" , DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Expedicion + ", '%d-%m-%Y') as Fecha_Expedicion_Folio ");
                Mi_SQL.Append(" , TIME_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Expedicion + ", '%h:%i:%s %p') as Hora_Expedicion_Folio ");
                //Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Lugar_Venta + " as Lugar_Venta ");
                //Mi_SQL.Append(", acceso." + Ope_Accesos.Campo_Estatus_Reimpresion + " as Reimpresion");
                //Mi_SQL.Append(", acceso." + Ope_Accesos.Campo_Usuario_Reimprimio + "");
                //Mi_SQL.Append(", DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Reimpresion + ", '%d-%m-%Y %h:%i:%s %p') as Fecha_Reimpresion");
                Mi_SQL.Append(" , IFNULL(producto." + Cat_Productos.Campo_Costo + ", 0) as Tarifa ");
                Mi_SQL.Append(" , acceso." + Ope_Accesos.Campo_Estatus + " as Estado_Folio ");
                Mi_SQL.Append(" , DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '%d-%m-%Y') as Acceso_Torniquete ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Titular_Tarjeta + " as Titular_Tarjeta ");
                Mi_SQL.Append(" , pago." + Ope_Pagos.Campo_Numero_Tarjeta_Banco + " as Numero_Tarjeta_Banco ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Correo_Electronico + " as Email");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Telefono + " as Telefono ");
                Mi_SQL.Append(" , venta." + Ope_Ventas.Campo_Usuario_Cancelo + " as Usuario_Cancelo ");
                Mi_SQL.Append(" , DATE_FORMAT(venta." + Ope_Ventas.Campo_Fecha_Cancelacion + ", '%d-%m-%Y') as Fecha_Cancelacion ");
                //  seccion from
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Accesos.Tabla_Ope_Accesos + " acceso ");

                Mi_SQL.Append(" inner join " + Ope_Ventas.Tabla_Ope_Ventas + " venta on ");
                Mi_SQL.Append(" acceso. " + Ope_Accesos.Campo_No_Venta + " = venta." + Ope_Ventas.Campo_No_Venta);

                Mi_SQL.Append(" left outer join " + Cat_Productos.Tabla_Cat_Productos + " producto on ");
                Mi_SQL.Append(" acceso." + Ope_Accesos.Campo_Producto_ID + " = producto." + Cat_Productos.Campo_Producto_Id);

                Mi_SQL.Append(" inner join " + Ope_Pagos.Tabla_Ope_Pagos + " pago ON ");
                Mi_SQL.Append(" venta." + Ope_Ventas.Campo_No_Venta + " = pago." + Ope_Pagos.Campo_No_Venta + " ");

                Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " caja ON ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_No_Caja + " = caja." + Ope_Cajas.Campo_No_Caja + " ");

                Mi_SQL.Append(" left outer join " + Ope_Turnos.Tabla_Ope_Turnos + " turno ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Turno + " = turno." + Ope_Turnos.Campo_No_Turno + " ");
                Mi_SQL.Append(" left outer join " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja ON ");

                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                Mi_SQL.Append(" left outer join " + Cat_Turnos.Tabla_Cat_Turnos + " cat_turno ON ");
                Mi_SQL.Append(" turno." + Ope_Turnos.Campo_Turno_ID + " = cat_turno." + Cat_Turnos.Campo_Turno_ID + " ");

                //  seccion where
                Mi_SQL.Append(" WHERE ");
                Mi_SQL.Append(" acceso." + Ope_Accesos.Campo_Estatus + " in ('ACTIVO', 'UTILIZADO') ");
                Mi_SQL.Append(" and ");
                Mi_SQL.Append(" pago." + Ope_Pagos.Campo_Forma_ID +" ='00005'");

                if (Datos.P_Fecha_Inicio.Year != 1 && Datos.P_Fecha_Termino.Year != 1)
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" (venta." + Ope_Ventas.Campo_Fecha_Creo + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                    Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" cat_caja." + Cat_Cajas.Campo_Caja_ID + "='" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" cat_turno." + Cat_Turnos.Campo_Turno_ID + "='" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" acceso." + Ope_Accesos.Campo_Producto_ID + "='" + Datos.P_Producto_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Lugar_Venta + "='" + Datos.P_Lugar_Venta + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" acceso." + Ope_Accesos.Campo_Estatus + "='" + Datos.P_Estatus + "' ");
                }
                if (!string.IsNullOrEmpty(Datos.P_Folio_Acceso))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" acceso." + Ope_Accesos.Campo_No_Acceso + "='" + Datos.P_Folio_Acceso + "' ");
                }

                // group by
                Mi_SQL.Append(" GROUP BY acceso.No_Acceso");

                //  order by
                Mi_SQL.Append(" order by Folio_Acceso desc ");

                //Mi_SQL.Append(" order by Folio_Acceso desc ");
                var Detalle_Venta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Datos Generales)
                var Datos_Generales = new DataTable();
                Datos_Generales.Columns.Add("Usuario_Creo", typeof(string));
                Datos_Generales.Columns.Add("Fecha_Creo", typeof(string));
                Datos_Generales.Columns.Add("Periodo_Reporte", typeof(string));
                var Registro = Datos_Generales.NewRow();
                Registro["Usuario_Creo"] = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Registro["Fecha_Creo"] = string.Format("{0:dd MMMM yyyy HH:mm:ss tt}", DateTime.Now);
                if (Datos.P_Fecha_Inicio.Year != 1 && Datos.P_Fecha_Termino.Year != 1)
                    Registro["Periodo_Reporte"] = (string.Format("{0:dd MMMM yyyy}", Datos.P_Fecha_Inicio) + " al " + string.Format("{0:dd MMMM yyyy}", Datos.P_Fecha_Termino)).ToUpper();
                else
                    Registro["Periodo_Reporte"] = string.Empty;
                Datos_Generales.Rows.Add(Registro);
                #endregion

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();

                Detalle_Venta.TableName = "Detalle_Ventas";
                Datos_Generales.TableName = "Datos_Generales";
                Ds_Resultado.Tables.Add(Detalle_Venta);
                Ds_Resultado.Tables.Add(Datos_Generales);
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Ds_Resultado;
        }

        /// <summary>
        /// Nombre: Consultar_Retiros
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_Dias_Accesos_Ventas(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();


                string Valor_Formato  ="";
                String Fecha_Inicio ="";
                String Fecha_Fin = "";
                String Fecha_Hora_Inicio = "";
                String Fecha_Hora_Fin = "";



                if (Datos.P_Tipo == "HORA" || Datos.P_Tipo == "DIA")
                {
                    Valor_Formato = "%Y-%m-%d";

                    Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio);
                    Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino);

                    Fecha_Hora_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio);
                    Fecha_Hora_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino);
                }
                else if (Datos.P_Tipo == "MES")
                {

                    Valor_Formato = "%Y-%m";

                    Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio).Substring(0,8) + "'";
                    Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino).Substring(0, 8) + "'";

                    Fecha_Hora_Inicio = Fecha_Inicio.Remove(Fecha_Inicio.Length - 1) + "-01 00:00:00'";
                    Fecha_Hora_Fin = Fecha_Inicio.Remove(Fecha_Inicio.Length - 1) + "-" + DateTime.DaysInMonth(Convert.ToDateTime(Datos.P_Fecha_Inicio).Year, Convert.ToInt32(Fecha_Inicio.Substring(6, 2))).ToString() + " 23:59:59'";
                }
                else if (Datos.P_Tipo == "ANIO")
                {
                    Valor_Formato = "%Y";

                    Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio).Substring(0, 5) + "'";
                    Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino).Substring(0, 5) + "'";

                    Fecha_Hora_Inicio = Fecha_Inicio.Remove(Fecha_Inicio.Length - 1) + "-01-01 00:00:00'";
                    Fecha_Hora_Fin = Fecha_Fin.Remove(Fecha_Inicio.Length - 1) + "-12-31 23:59:59'";
                }


                //Crear la consulta.
                Mi_SQL.Append("select distinct(DATE_FORMAT(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + " , '" + Datos.P_Formato + "')) as " + Datos.P_Tipo);
                Mi_SQL.Append(" From " + Ope_Accesos.Tabla_Ope_Accesos);
                Mi_SQL.Append(" where  DATE_FORMAT(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Valor_Formato + "')");
                Mi_SQL.Append(" BETWEEN ");
                Mi_SQL.Append(Fecha_Inicio + " AND ");
                Mi_SQL.Append(Fecha_Fin);
                Mi_SQL.Append(" and ");
                Mi_SQL.Append(" DATE_FORMAT(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '%H') between ");
                Mi_SQL.Append("'" + Datos.P_Hora_Inicio.ToString("HH") + "' AND ");
                Mi_SQL.Append("'" + Datos.P_Hora_Termino.ToString("HH") + "' ");


                Mi_SQL.Append(" union ");

                Mi_SQL.Append(" select distinct(DATE_FORMAT(" + Ope_Ventas_Detalles.Campo_Fecha_Creo + " , '" + Datos.P_Formato + "')) as " + Datos.P_Tipo);
                Mi_SQL.Append(" From " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles);
                Mi_SQL.Append(" where " + Ope_Ventas_Detalles.Campo_Fecha_Creo );
                Mi_SQL.Append(" BETWEEN ");
                Mi_SQL.Append(Fecha_Hora_Inicio + " AND ");
                Mi_SQL.Append(Fecha_Hora_Fin);

                //Mi_SQL.Append(" union ");

                //Mi_SQL.Append(" select distinct(DATE_FORMAT(" + Ope_Accesos_Camaras.Campo_Fecha_Hora+ " , '" + Datos.P_Formato + "')) as " + Datos.P_Tipo);
                //Mi_SQL.Append(" From " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras);
                //Mi_SQL.Append(" where  DATE_FORMAT(" + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Valor_Formato + "')");
                //Mi_SQL.Append(" BETWEEN ");
                //Mi_SQL.Append(Fecha_Inicio + " AND ");
                //Mi_SQL.Append(Fecha_Fin);
                //Mi_SQL.Append(" and ");
                //Mi_SQL.Append(" DATE_FORMAT(" + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '%H') between ");
                //Mi_SQL.Append("'" + Datos.P_Hora_Inicio.ToString("HH") + "' AND ");
                //Mi_SQL.Append("'" + Datos.P_Hora_Termino.ToString("HH") + "' ");
                
                Mi_SQL.Append(" order by " + Datos.P_Tipo);
                Dt_Consulta =  Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
               
            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }

        /// <summary>
        /// Nombre: Consultar_Retiros
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_Ventas_Productos_Accesos(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();


                string Valor_Formato = "";
                String Fecha_Inicio = "";
                String Fecha_Fin = "";


                if (Datos.P_Tipo == "HORA" )
                {
                    Valor_Formato = "%Y-%m-%d %H";

                    //Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio);
                    //Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino);
                }
                else if (Datos.P_Tipo == "DIA")
                {
                    Valor_Formato = "%Y-%m-%d";

                    //Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio);
                    //Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino);
                }
                else if (Datos.P_Tipo == "MES")
                {

                    Valor_Formato = "%Y-%m";

                    //Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio).Substring(0, 8) + "'";
                    //Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino).Substring(0, 8) + "'";
                }
                else if (Datos.P_Tipo == "ANIO")
                {
                    Valor_Formato = "%Y";

                    //Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio).Substring(0, 5) + "'";
                    //Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino).Substring(0, 5) + "'";
                }
                
                //Crear la consulta.
                Mi_SQL.Append(" select IFNULL(CAST(SUM(vd.cantidad)  AS SIGNED) , 0) AS Cantidad");
                Mi_SQL.Append(" From " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles  + " vd");
                
                //  filtro hora, dia, mes, año 
                Mi_SQL.Append(" where  vd." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " between '" + Datos.P_Fecha + "' and '" + Datos.P_Str_Fecha_Termino + "'");

                //  filtro para consultar los productos tipo servicio
                Mi_SQL.Append(" and vd.Producto_Id in (select producto_id from cat_productos where  tipo= 'Servicio') ");

                
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }


        /// <summary>
        /// Nombre: Consultar_Ventas_Accesos
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_Ventas_Accesos(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();


                Mi_SQL.Append("select IFNULL( CAST(SUM(D." + Ope_Ventas_Detalles.Campo_Cantidad + ") AS SIGNED),  0) as Cantidad");
                Mi_SQL.Append(" from " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " D ");

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta) || (!string.IsNullOrEmpty(Datos.P_Turno_ID)) || (!string.IsNullOrEmpty(Datos.P_Producto_ID)))
                {
                    Mi_SQL.Append(" left outer join ope_ventas ventas on ventas.no_venta = D.No_Venta " +
                                    " LEFT OUTER JOIN Ope_Pagos pagos ON pagos.No_Venta = ventas.No_Venta" +
                                    " LEFT OUTER JOIN Ope_Cajas cajas ON cajas.No_Caja = pagos.No_Caja" +
                                    " LEFT OUTER JOIN Ope_Turnos turnos ON turnos.No_Turno = cajas.No_Turno" +
                                    " LEFT OUTER JOIN Cat_Turnos cturno ON cturno.Turno_ID = turnos.Turno_ID");
                }

                Mi_SQL.Append(" where D." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " BETWEEN '" + Datos.P_Fecha + "' and '" + Datos.P_Str_Fecha_Termino + "'");
                
                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" ventas." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                }

                //  filtro para el turno
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" cturno." + Cat_Turnos.Campo_Turno_ID + " = '" + Datos.P_Turno_ID + "'");
                }

                //  filtro para los productos
                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" D." + Ope_Ventas_Detalles.Campo_Producto_Id + " = '" + Datos.P_Producto_ID + "'");
                }

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }

        /// <summary>
        /// Nombre: Consultar_Torniquete_Accesos
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_Torniquete_Accesos(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();


                Mi_SQL.Append("SELECT  IFNULL( COUNT(ASS." + Ope_Accesos.Campo_No_Acceso + "), 0) FROM Ope_Accesos ASS ");

                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta) || (!string.IsNullOrEmpty(Datos.P_Turno_ID)) || (!string.IsNullOrEmpty(Datos.P_Producto_ID)))
                {
                    Mi_SQL.Append("  left outer join ope_ventas ventas on ventas.no_venta = ASS.No_Venta " +
                                    " LEFT OUTER JOIN Ope_Pagos pagos ON pagos.No_Venta = ventas.No_Venta" +
                                    " LEFT OUTER JOIN Ope_Cajas cajas ON cajas.No_Caja = pagos.No_Caja" +
                                    " LEFT OUTER JOIN Ope_Turnos turnos ON turnos.No_Turno = cajas.No_Turno" +
                                    " LEFT OUTER JOIN Cat_Turnos cturno ON cturno.Turno_ID = turnos.Turno_ID");
                }

                Mi_SQL.Append(" WHERE COALESCE(ASS." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ") != '' AND ASS." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");
                Mi_SQL.Append("AND ASS." + Ope_Accesos.Campo_Fecha_Hora_Acceso + " BETWEEN '" + Datos.P_Fecha + "' and '" + Datos.P_Str_Fecha_Termino + "'");

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" ventas." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                }

                //  filtro para el turno
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" cturno." + Cat_Turnos.Campo_Turno_ID + " = '" + Datos.P_Turno_ID + "'");
                }

                //  filtro para los productos
                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" ASS." + Ope_Ventas_Detalles.Campo_Producto_Id + " = '" + Datos.P_Producto_ID + "'");
                }


                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }
        /// <summary>
        /// Nombre: Consultar_Torniquete_Accesos
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_CamaraIn_Acceso(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("SELECT (IFNULL(sum(CAMARA." + Ope_Accesos_Camaras.Campo_Cantidad + "), 0) - " + "IFNULL(sum(CAMARA." + Ope_Accesos_Camaras.Campo_Cantidad_Salida + "), 0))");
                
                //  from
                Mi_SQL.Append("FROM ope_accesos_camaras CAMARA ");
                
                //  where
                Mi_SQL.Append("WHERE DATE_FORMAT(CAMARA." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') = ");
                Mi_SQL.Append("'" + Datos.P_Fecha  + "'");
                if (!String.IsNullOrEmpty(Datos.P_Camara_Entrada_Id)) // validamos que tenga informacion
                    Mi_SQL.Append(" and CAMARA." + Ope_Accesos_Camaras.Campo_Camara_Id + " in (" + Datos.P_Camara_Entrada_Id + ")");
                

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }
        /// <summary>
        /// Nombre: Consultar_Torniquete_Accesos
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_CamaraOut_Acceso(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();

                // conteo de la camara de salida
                Mi_SQL.Append("SELECT (IFNULL(sum(CAMARA." + Ope_Accesos_Camaras.Campo_Cantidad_Salida + "), 0) - " + " IFNULL(sum(CAMARA." + Ope_Accesos_Camaras.Campo_Cantidad + "), 0) )");
                
                //  from
                Mi_SQL.Append(" FROM ope_accesos_camaras CAMARA ");
                
                //  where
                Mi_SQL.Append("WHERE DATE_FORMAT(CAMARA." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') = ");
                Mi_SQL.Append("'" + Datos.P_Fecha + "' ");
                
                if (!String.IsNullOrEmpty(Datos.P_Camara_Salida_Id)) // validamos que tenga informacion
                    Mi_SQL.Append(" and CAMARA." + Ope_Accesos_Camaras.Campo_Camara_Id + " in (" + Datos.P_Camara_Salida_Id + ")");
                
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }
        /// <summary>
        /// Nombre: Consultar_Torniquete_Accesos
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_Restantes_Ventas_Acceso(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();

                //  folios restantes
                Mi_SQL.Append("SELECT COUNT(ASS." + Ope_Accesos.Campo_No_Acceso + ") FROM Ope_Accesos ASS ");
                Mi_SQL.Append("WHERE  ASS." + Ope_Accesos.Campo_Estatus + " = 'ACTIVO' ");
                Mi_SQL.Append("AND ASS." + Ope_Accesos.Campo_Fecha_Creo + " between '" + Datos.P_Fecha + "' and '" + Datos.P_Str_Fecha_Termino + "'");

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }

        /// <summary>
        /// Nombre: Consultar_Dellates_Accesos_Ventas
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 02 Diciembre 2013 16:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Consultar_Dellates_Accesos_Ventas(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.
            String Fecha_Inicio = "";
            String Fecha_Fin = "";
            String Valor_Formato = "";
            String Fecha_Hora_Inicio = "";
            String Fecha_Hora_Fin = "";

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            //if (!Conexion.HelperGenerico.Estatus_Transaccion())
            //    Conexion.HelperGenerico.Conexion_y_Apertura();
            //else
            //    Transaccion_Activa = true;

            try
            {
                //Conexion.HelperGenerico.Iniciar_Transaccion();

                if (Datos.P_Tipo == "HORA" || Datos.P_Tipo == "DIA")
                {
                    Valor_Formato = "%Y-%m-%d";

                    Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio);
                    Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino);

                    Fecha_Hora_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio);
                    Fecha_Hora_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino);
                }
                else if (Datos.P_Tipo == "MES")
                {

                    Valor_Formato = "%Y-%m";
                    Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio).Substring(0, 8) + "'";
                    Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino).Substring(0, 8) + "'";

                    Fecha_Hora_Inicio = Fecha_Inicio.Remove(Fecha_Inicio.Length - 1) + "-01 00:00:00'";
                    Fecha_Hora_Fin = Fecha_Inicio.Remove(Fecha_Inicio.Length - 1) + "-" + DateTime.DaysInMonth(Convert.ToDateTime(Datos.P_Fecha_Inicio).Year, Convert.ToInt32(Fecha_Inicio.Substring(6, 2))).ToString() + " 23:59:59'";
                }
                else if (Datos.P_Tipo == "ANIO")
                {
                    Valor_Formato = "%Y";
                    Fecha_Inicio = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio).Substring(0, 5) + "'";
                    Fecha_Fin = Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino).Substring(0, 5) + "'";

                    Fecha_Hora_Inicio = Fecha_Inicio.Remove(Fecha_Inicio.Length - 1) + "-01-01 00:00:00'";
                    Fecha_Hora_Fin = Fecha_Fin.Remove(Fecha_Inicio.Length - 1) + "-12-31 23:59:59'";
                
                }

                #region (Detalle Accesos)
                Mi_SQL.Append("select ");
                Mi_SQL.Append("a." + Ope_Accesos.Campo_No_Acceso + " as Folio_de_acceso ");
                Mi_SQL.Append(", DATE_FORMAT(a." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') as Fecha_Venta ");
                Mi_SQL.Append(", p." + Cat_Productos.Campo_Nombre + " as Tarifa ");
                Mi_SQL.Append(", p." + Cat_Productos.Campo_Costo + " as Costo ");
                Mi_SQL.Append(", a." + Ope_Accesos.Campo_Estatus + " as Estatus");
                Mi_SQL.Append(", DATE_FORMAT(a." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '%Y-%m-%d') as Fecha_de_acceso ");
                Mi_SQL.Append(", DATE_FORMAT(a." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '%H:%i:%S') as Hora_de_acceso ");

                //  seccion from
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Accesos.Tabla_Ope_Accesos + " a ");
                Mi_SQL.Append(" left outer join " + Cat_Productos.Tabla_Cat_Productos + " p  ON ");
                Mi_SQL.Append(" a." + Ope_Accesos.Campo_Producto_ID + "= p." + Cat_Productos.Campo_Producto_Id);

                Mi_SQL.Append(" left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " ventas on ventas." + Ope_Ventas.Campo_No_Venta + "= a." + Ope_Accesos.Campo_No_Venta);
                Mi_SQL.Append(" left outer join " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " detalle on detalle." + Ope_Ventas_Detalles.Campo_No_Venta + "= ventas." + Ope_Ventas.Campo_No_Venta);
                Mi_SQL.Append(" left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " pagos on pagos." + Ope_Pagos.Campo_No_Venta + "= ventas." + Ope_Ventas.Campo_No_Venta);
                Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " cajas on cajas." + Ope_Cajas.Campo_No_Caja + "= pagos." + Ope_Pagos.Campo_No_Caja);
                Mi_SQL.Append(" left outer join " + Ope_Turnos.Tabla_Ope_Turnos + " turnos on turnos." + Ope_Turnos.Campo_No_Turno + "= cajas." + Ope_Cajas.Campo_No_Turno);
                Mi_SQL.Append(" left outer join " + Cat_Turnos.Tabla_Cat_Turnos + " cturno on cturno." + Cat_Turnos.Campo_Turno_ID + "= turnos." + Ope_Turnos.Campo_Turno_ID);

                //  seccion where
                Mi_SQL.Append(" where ");


                Mi_SQL.Append(" detalle.Fecha_Creo BETWEEN " +
                    Fecha_Hora_Inicio + " AND " +
                    Fecha_Hora_Fin + " ");

                Mi_SQL.Append(" and a." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");

                ////  filtro de horas a buscar
                //Mi_SQL.Append(" AND DATE_FORMAT(a.Fecha_Creo, '%H') BETWEEN ");
                //Mi_SQL.Append("'" + Datos.P_Hora_Inicio.ToString("HH") + "' AND ");
                //Mi_SQL.Append("'" + Datos.P_Hora_Termino.ToString("HH") + "' ");

                //  filtro para los productos
                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" a." + Ope_Accesos.Campo_Producto_ID + " = '" + Datos.P_Producto_ID + "'");
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" ventas." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                }

                //  filtro para el turno
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" cturno." + Cat_Turnos.Campo_Turno_ID + " = '" + Datos.P_Turno_ID + "'");
                }

                //  seccion group by
                Mi_SQL.Append(" group by a." + Ope_Accesos.Campo_No_Acceso);
                Mi_SQL.Append(" order by a.Fecha_Creo");
                Mi_SQL.Append(" limit 100000000000000");
                #endregion
               

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                    Conexion.HelperGenerico.Cerrar_Conexion();
                //}
            }
            return Dt_Consulta;
        }
        /// <summary>
        /// Nombre: Rpt_Cortes_Arqueos_Por_Dia
        /// 
        /// Descripción: Método que consulta los cortes de caja y arqueos por día.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 2014-05-29 10:24 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Cortes de Caja ó Arqueos por día.</returns>
        public static DataSet Rpt_Cortes_Arqueos_Por_Dia(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.
            bool Entro_Where = false;

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                #region (Datos)
                Mi_SQL.Append(" SELECT  ");
                Mi_SQL.Append(" REC.NO_RECOLECCION AS FOLIO_CORTE ");
                Mi_SQL.Append(" ,DATE_FORMAT(REC.FECHA_HORA, '%Y-%m-%d %h:%i:%s %p') AS FECHA_HORA ");
                //Mi_SQL.Append(" , CAST(REC.FECHA_HORA AS DATE) AS FECHA_INICIO ");
                Mi_SQL.Append(" , REC.FECHA_CREO AS FECHA_FIN");
                Mi_SQL.Append(" , CAT_CAJA.NUMERO_CAJA AS NO_CAJA ");
                Mi_SQL.Append(" , REC.USUARIO_CREO AS CAJERO ");
                Mi_SQL.Append(" , USERS.NOMBRE_USUARIO AS USUARIO_AUTORIZO ");
                Mi_SQL.Append(" , CAT_TURNO.NOMBRE AS TURNO ");
                //Mi_SQL.Append(" , DATE_FORMAT(TURNO.FECHA_HORA_INICIO, '%Y-%m-%d %h:%i:%s %p') AS FECHA_HORA_INICIO ");
                //Mi_SQL.Append(" , DATE_FORMAT(TURNO.Fecha_Hora_Cierre, '%Y-%m-%d %h:%i:%s %p')  AS FECHA_HORA_FIN ");
                //Mi_SQL.Append(" , CAJA.MONTO_INICIAL AS FONDO_FIJO ");
                Mi_SQL.Append(" , (SELECT COUNT(PAGO.NO_PAGO) FROM OPE_PAGOS PAGO WHERE PAGO.NO_CAJA = CAJA.NO_CAJA) AS NO_OPERACIONES_REALIZADAS ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_1000, ''), 0) AS BILLETES_1000 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_500, ''), 0) AS BILLETES_500 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_200, ''), 0) AS BILLETES_200 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_100, ''), 0) AS BILLETES_100 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_50, ''), 0) AS BILLETES_50 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_20, ''), 0) AS BILLETES_20 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_20, ''), 0) AS MONEDAS_20 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_10, ''), 0) AS MONEDAS_10 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_5, ''), 0) AS MONEDAS_5 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_2, ''), 0) AS MONEDAS_2 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_1, ''), 0) AS MONEDAS_1 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_050, ''), 0) AS MONEDAS_050 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_020, ''), 0) AS MONEDAS_020 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_010, ''), 0) AS MONEDAS_010 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC.MONTO_RECOLECTADO, ''), 0) AS EFECTIVO_CAJA ");
                if (Datos.P_Es_Corte_Arqueo == "CIERRE" || Datos.P_Es_Corte_Arqueo == "ARQUEO")
                {
                    //Mi_SQL.Append(" , (REC.MONTO_RECOLECTADO + IFNULL(NULLIF(REC.TOTAL_TARJETA, ''), 0)) AS TOTAL_VENTA ");
                    Mi_SQL.Append(" , CAJA.MONTO_INICIAL AS MONTO_INICIAL ");
                    Mi_SQL.Append(" , (REC.MONTO_RECOLECTADO - IFNULL(NULLIF(CAJA.MONTO_INICIAL, ''), 0)) AS EFECTIVO_COBRADO ");
                    Mi_SQL.Append(" , IFNULL(NULLIF(REC.TOTAL_TARJETA, ''), 0) AS VENTAS_CREDITO_DEBITO ");
                    Mi_SQL.Append(" , (IFNULL(NULLIF(REC.TOTAL_CORTES, ''), 0) + IFNULL(NULLIF(REC.TOTAL_RETIROS, ''), 0)) AS MONTO_RECOLECCIONES_RETIROS ");
                    Mi_SQL.Append(" , (REC.MONTO_RECOLECTADO - IFNULL(NULLIF(CAJA.MONTO_INICIAL, ''), 0) + IFNULL(NULLIF(REC.TOTAL_TARJETA, ''), 0) + IFNULL(NULLIF(REC.TOTAL_CORTES, ''), 0)  + IFNULL(NULLIF(REC.TOTAL_RETIROS, ''), 0) ) AS TOTAL_COBRADO ");
                    Mi_SQL.Append(" , (REC.TOTAL_CAJA  + IFNULL(NULLIF(REC.TOTAL_TARJETA, ''), 0) + IFNULL(NULLIF(REC.TOTAL_CORTES, ''), 0) + IFNULL(NULLIF(REC.TOTAL_RETIROS, ''), 0)  + IFNULL(NULLIF(REC.TOTAL_CANCELACIONES, ''), 0) - IFNULL(NULLIF(CAJA.MONTO_INICIAL, ''), 0) ) AS TOTAL_SISTEMA ");
                    Mi_SQL.Append(" , IFNULL(NULLIF(REC.TOTAL_CANCELACIONES, ''), 0) AS MONTO_CANCELACIONES ");
                    Mi_SQL.Append(" , (REC.TOTAL_CAJA  + IFNULL(NULLIF(REC.TOTAL_TARJETA, ''), 0) + IFNULL(NULLIF(REC.TOTAL_CORTES, ''), 0)  + IFNULL(NULLIF(REC.TOTAL_RETIROS, ''), 0) - IFNULL(NULLIF(CAJA.MONTO_INICIAL, ''), 0) ) AS TOTAL_COBRADO_SISTEMA ");
                    Mi_SQL.Append(" , IFNULL(NULLIF(REC.RESULTADO_CORTE, ''), 0) AS RESULTADO_CORTE");
                    Mi_SQL.Append(" , (CASE ");
                    Mi_SQL.Append(" 	WHEN IFNULL(NULLIF(REC.RESULTADO_CORTE, ''), 0) > 0 THEN 'SOBRANTE'  ");
                    Mi_SQL.Append(" 	WHEN IFNULL(NULLIF(REC.RESULTADO_CORTE, ''), 0) = 0 THEN 'CERO' ");
                    Mi_SQL.Append(" 	WHEN IFNULL(NULLIF(REC.RESULTADO_CORTE, ''), 0) < 0 THEN 'FALTANTE' ");
                    Mi_SQL.Append(" 	END) AS RESULTADO ");
                    if (Datos.P_Es_Corte_Arqueo == "CIERRE")
                        Mi_SQL.Append(" , IFNULL(NULLIF(REC.MONTO_DEPOSITAR, ''), 0) AS MONTO_DEPOSITAR");
                }
                Mi_SQL.Append(" ,REC_DET.OBSERVACIONES AS OBSERVACIONES ");
                //Mi_SQL.Append(" , MIN(PAGO.NO_VENTA) AS FOLIO_INICIO ");
                //Mi_SQL.Append(" , MAX(PAGO.NO_VENTA) AS FOLIO_FIN ");
                Mi_SQL.Append(",(select min(No_Pago) from ope_pagos where No_Caja = REC.no_caja) AS FOLIO_INICIO");
                Mi_SQL.Append(",(select max(No_Pago) from ope_pagos where No_Caja = REC.no_caja) AS FOLIO_FIN");
                //Mi_SQL.Append(", '" + Datos.P_Es_Corte_Arqueo + "' as Tipo_Reporte");
                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" OPE_RECOLECCIONES REC  ");
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_CAJAS CAJA ON ");
                Mi_SQL.Append(" REC.NO_CAJA = CAJA.NO_CAJA ");
                //Mi_SQL.Append(" LEFT OUTER JOIN OPE_PAGOS PAGO ON ");
                //Mi_SQL.Append(" CAJA.NO_CAJA = PAGO.NO_CAJA ");
                Mi_SQL.Append(" LEFT OUTER JOIN APL_USUARIOS USERS ON ");
                Mi_SQL.Append(" REC.USUARIO_ID_COLECTA = USERS.USUARIO_ID ");
                Mi_SQL.Append(" LEFT OUTER JOIN CAT_CAJAS CAT_CAJA ON ");
                Mi_SQL.Append(" CAJA.CAJA_ID = CAT_CAJA.CAJA_ID ");
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_TURNOS TURNO ON ");
                Mi_SQL.Append(" CAJA.NO_TURNO = TURNO.NO_TURNO ");
                Mi_SQL.Append(" LEFT OUTER JOIN CAT_TURNOS CAT_TURNO ON ");
                Mi_SQL.Append(" TURNO.TURNO_ID = CAT_TURNO.TURNO_ID ");
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_RECOLECCIONES_DETALLES REC_DET ON ");
                Mi_SQL.Append(" REC.NO_RECOLECCION = REC_DET.NO_RECOLECCION ");

                if (Datos.P_Fecha_Inicio != DateTime.MinValue)
                {
                    if (Datos.P_Fecha_Termino == DateTime.MinValue)
                    {
                        Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                        Mi_SQL.Append(" (REC." + Ope_Recolecciones.Campo_Fecha_Hora + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                        Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio.AddDays(1).AddSeconds(-1)) + ") ");
                    }
                    else if (Datos.P_Fecha_Termino != DateTime.MinValue)
                    {
                        Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                        Mi_SQL.Append(" REC." + Ope_Recolecciones.Campo_Fecha_Hora + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                        Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino.AddDays(1).AddSeconds(-1)) + " ");
                    }
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(" CAT_CAJA." + Cat_Cajas.Campo_Caja_ID + "='" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(" CAT_TURNO." + Cat_Turnos.Campo_Turno_ID + "='" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Es_Corte_Arqueo))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append("REC." + Ope_Recolecciones.Campo_Tipo + "='" + Datos.P_Es_Corte_Arqueo + "' "); //+ 

                    //if (Datos.P_Es_Corte_Arqueo == "RECOLECCION") 
                      //  Mi_SQL.Append(" or REC." + Ope_Recolecciones.Campo_Tipo + "='CIERRE'");

                    //Mi_SQL.Append(") ");
                }

                if (!string.IsNullOrEmpty(Datos.P_No_Recoleccion))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append("REC." + Ope_Recolecciones.Campo_No_Recoleccion + "='" + Datos.P_No_Recoleccion + "' "); //+ 
                }



                Mi_SQL.Append(" ORDER BY REC.NO_RECOLECCION DESC ");
                var Detalle_Venta  = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Datos Generales)
                var Datos_Generales = new DataTable();
                Datos_Generales.Columns.Add("Usuario_Creo", typeof(string));
                Datos_Generales.Columns.Add("Fecha_Creo", typeof(string));
                Datos_Generales.Columns.Add("Periodo_Reporte", typeof(string));
                Datos_Generales.Columns.Add("Nombre_Reporte", typeof(string));
                var Registro = Datos_Generales.NewRow();
                Registro["Usuario_Creo"] = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Registro["Fecha_Creo"] = string.Format("{0:dd MMMM yyyy HH:mm:ss tt}", DateTime.Now);

                if (Datos.P_Fecha_Inicio != DateTime.MinValue)
                    Registro["Periodo_Reporte"] = (string.Format("{0:dd MMMM yyyy}", Datos.P_Fecha_Inicio) + " al " + string.Format("{0:dd MMMM yyyy}",
                        (Datos.P_Fecha_Termino != DateTime.MinValue ? Datos.P_Fecha_Termino : Datos.P_Fecha_Inicio))).ToUpper();
                else
                    Registro["Periodo_Reporte"] = string.Empty;

                if (Datos.P_Fecha_Termino != DateTime.MinValue)
                {
                    if (Datos.P_Es_Corte_Arqueo == "CIERRE")
                        Registro["Nombre_Reporte"] = "Detallado de Cortes de Caja";
                    else if (Datos.P_Es_Corte_Arqueo == "RECOLECCION")
                        Registro["Nombre_Reporte"] = "Detallado de Recolecciones";
                    else if (Datos.P_Es_Corte_Arqueo == "ARQUEO")
                        Registro["Nombre_Reporte"] = "Detallado de Arqueos";
                }
                else {
                    if (Datos.P_Es_Corte_Arqueo == "CIERRE")
                        Registro["Nombre_Reporte"] = "Reporte por día de Cortes de Caja";
                    else if (Datos.P_Es_Corte_Arqueo == "RECOLECCION")
                        Registro["Nombre_Reporte"] = "Reporte por día de Recolecciones";
                    else if (Datos.P_Es_Corte_Arqueo == "ARQUEO")
                        Registro["Nombre_Reporte"] = "Reporte por día de Arqueos";
                }

                Datos_Generales.Rows.Add(Registro);
                #endregion

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();

                Detalle_Venta.TableName = "Cortes_Arqueos";
                Datos_Generales.TableName = "Datos_Generales";
                Ds_Resultado.Tables.Add(Detalle_Venta);
                Ds_Resultado.Tables.Add(Datos_Generales);
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Ds_Resultado;
        }

        /// <summary>
        /// Nombre: Rpt_Cortes_Arqueos_Concentrado
        /// 
        /// Descripción: Método que consulta los cortes de caja y arqueos concentrados.
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya 
        /// Fecha Creo: 2015-06-04 15:00:00 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Cortes de Caja ó Arqueos por día.</returns>
        public static DataSet Rpt_Cortes_Arqueos_Concentrado(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            
            try
            {
                #region (Datos)
                Mi_SQL.Append("select ");
	            Mi_SQL.Append("    r.No_Recoleccion Folio,");
	            Mi_SQL.Append("    (select min(p.No_Venta) from ope_pagos p where p.No_Caja = r.No_Caja) Folio_Inicial,");
	            Mi_SQL.Append("    (select max(p.No_Venta) from ope_pagos p where p.No_Caja = r.No_Caja) Folio_Final,");
                Mi_SQL.Append("    cast(cc.Numero_Caja as char(2)) Numero_Caja,");
	            Mi_SQL.Append("    ct.Nombre Turno,");
	            Mi_SQL.Append("    r.Monto_Recolectado,");
	            Mi_SQL.Append("    oc.Monto_Inicial,");
	            Mi_SQL.Append("    r.Monto_Recolectado - oc.Monto_Inicial Efectivo_Cobrado,");
	            Mi_SQL.Append("    r.Total_Tarjeta,");
	            Mi_SQL.Append("    r.Total_Cortes Total_Recolecciones,");
	            Mi_SQL.Append("    (r.Monto_Recolectado - oc.Monto_Inicial) + ");
	            Mi_SQL.Append("    Total_Tarjeta + Total_Cortes Cobrado,");
	            Mi_SQL.Append("     r.Total_Caja");
		        Mi_SQL.Append("        + r.Total_Tarjeta");
		        Mi_SQL.Append("        + r.Total_Cortes");
		        Mi_SQL.Append("        + r.Total_Retiros");
		        Mi_SQL.Append("        - oc.Monto_Inicial AS Total_Sistema,");
	            Mi_SQL.Append("    r.Total_Cancelaciones,");
	            Mi_SQL.Append("    r.Resultado_Corte,");
	            Mi_SQL.Append("    (r.Monto_Recolectado - oc.Monto_Inicial) + abs(r.Resultado_Corte) Monto_Depositar,");
	            Mi_SQL.Append("    oc.Fecha_Hora_Inicio,");
	            Mi_SQL.Append("    oc.Fecha_Hora_Cierre,");
	            Mi_SQL.Append("    u.Nombre_Usuario Supervisor,");
	            Mi_SQL.Append("    r.Usuario_Creo Cajero ");
                Mi_SQL.Append("from");
	            Mi_SQL.Append("    ope_recolecciones r");
	            Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = r.No_Caja");
	            Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno");
	            Mi_SQL.Append("    join apl_usuarios u on u.Usuario_Id = r.Usuario_ID_Colecta");
	            Mi_SQL.Append("    join cat_cajas cc on cc.Caja_ID = oc.Caja_ID");
	            Mi_SQL.Append("    join cat_turnos ct on ct.Turno_ID = ot.Turno_ID ");
                Mi_SQL.Append("where");

                if (!string.IsNullOrEmpty(Datos.P_No_Recoleccion))
                {
                    Mi_SQL.Append(" r.No_Recoleccion = '" + Datos.P_No_Recoleccion + "' ");
                }
                else
                {
                    Mi_SQL.Append("    r.Fecha_Hora between @FechaIni and @FechaFin");
                    Mi_SQL.Append("    and r.Tipo = 'CIERRE'");

                    if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                    {
                        Mi_SQL.Append(" and oc.Caja_ID = '" + Datos.P_Caja_ID + "' ");
                    }

                    if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                    {
                        Mi_SQL.Append(" and ot.Turno_ID = '" + Datos.P_Turno_ID + "' ");
                    }

                }

                DataTable Cortes = new DataTable();
                
                // Se ejecuta e Query.
                using (MySqlConnection Con = new MySqlConnection())
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.ConnectionString = Cls_Constantes.Cadena_Conexion;
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_SQL.ToString();
                    Cmd.Parameters.AddWithValue("@FechaIni", Datos.P_Fecha_Inicio);
                    Cmd.Parameters.AddWithValue("@FechaFin", Datos.P_Fecha_Termino);
                    
                    using (MySqlDataAdapter Adap = new MySqlDataAdapter())
                    {
                        Adap.SelectCommand = Cmd;
                        Adap.Fill(Cortes);
                    }
                }

                Cortes.Columns.Add("Fecha_Hora_Inicio_P", typeof(DateTime));
                Cortes.Columns.Add("Fecha_Hora_Cierre_P", typeof(DateTime));

                for (int i = 0; i < Cortes.Rows.Count; i++)
                {
                    Cortes.Rows[i]["Fecha_Hora_Inicio_P"] = Cortes.Rows[i]["Fecha_Hora_Inicio"];
                    Cortes.Rows[i]["Fecha_Hora_Cierre_P"] = Cortes.Rows[i]["Fecha_Hora_Cierre"];
                }

                Cortes.Columns.Remove("Fecha_Hora_Inicio");
                Cortes.Columns.Remove("Fecha_Hora_Cierre");
                Cortes.Columns["Fecha_Hora_Inicio_P"].ColumnName = "Fecha_Hora_Inicio";
                Cortes.Columns["Fecha_Hora_Cierre_P"].ColumnName = "Fecha_Hora_Cierre";

                Mi_SQL.Clear();

                #endregion

                Cortes.TableName = "Cortes_Caja";
                Ds_Resultado.Tables.Add(Cortes);
                
                return Ds_Resultado;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
        }
       
        /// <summary>
        /// Nombre: Rpt_Folios_Cancelados
        /// 
        /// Descripción: Método que consulta los folios cancelados.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 2014-06-05 11:06 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Listado de folios cancelados.</returns>
        public static DataSet Rpt_Folios_Cancelados(Cls_Rpt_Ventas_Negocio Datos) {
            DataSet Ds_Resultado = new DataSet();
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

               
                #region Consulta de folios cancelados

                Mi_SQL.Append("Select v." + Ope_Ventas.Campo_No_Venta + " as Folio_del_ticket_de_venta");
                Mi_SQL.Append(", (select min(No_Acceso) from ope_accesos ac where ac.No_Venta = v.no_venta) as Folio_del_acceso_Numero_Inicial  ");
                Mi_SQL.Append(", (select max(No_Acceso) from ope_accesos ac where ac.No_Venta = v.no_venta) as Folio_del_acceso_Numero_Final   ");
                Mi_SQL.Append(", (select count(No_Acceso) from ope_accesos ac where ac.No_Venta = v.no_venta) as Total_Accesos ");
                Mi_SQL.Append(", v." + Ope_Ventas.Campo_Total + " as Importe_total_Ticket");
                Mi_SQL.Append(", (  case " +
                                " WHEN v.Lugar_Venta = 'No Caja'" +
                                "   THEN (" +
                                "       SELECT CONCAT (" +
                                "           'C'" +
                                "           ,Numero_Caja" +
                                "           )" +
                                "       FROM cat_cajas" +
                                "       WHERE Caja_ID = (" +
                                "       SELECT caja_id" +
                                "       FROM ope_cajas" +
                                "       WHERE No_Caja = (" +
                                "           SELECT no_caja " +
                                "   		FROM ope_pagos" +
                                "   		WHERE no_venta = v.No_Venta" +
                                "   	                )" +
                                "                   )" +
                                "               )" +
                                "	ELSE v.Lugar_Venta " +
                                "   END " +
                                ") AS Lugar_de_la_venta");
                Mi_SQL.Append(", DATE_FORMAT(v." + Ope_Ventas.Campo_Fecha_Cancelacion + ", '%Y/%m/%d') as Fecha");
                Mi_SQL.Append(", DATE_FORMAT(v." + Ope_Ventas.Campo_Fecha_Cancelacion + ", '%H:%i:%s') as Hora");
                Mi_SQL.Append(", v." + Ope_Ventas.Campo_Usuario_Cancelo + " as Usuario_Cancelo");
                Mi_SQL.Append(", v." + Ope_Ventas.Campo_Motivo_Cancelacion + " as Motivo_Cancelacion");
               
                //  from --------------------------------------------------------------------------------------------
                Mi_SQL.Append(" from " + Ope_Ventas.Tabla_Ope_Ventas + " v");

                //  where --------------------------------------------------------------------------------------------
                Mi_SQL.Append(" where v." + Ope_Ventas.Campo_Estatus + " in ('CANCELADO') ");

                //  filtro para la fecha
                if (Datos.P_Fecha_Inicio != DateTime.MinValue && Datos.P_Fecha_Termino != DateTime.MinValue)
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" (v." + Ope_Ventas.Campo_Fecha_Cancelacion + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                    Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");
                }

                //  filtro para lugar de la venta
                if (!String.IsNullOrEmpty(Datos.P_Lugar_Venta))
                    Mi_SQL.Append(" and v." + Ope_Ventas.Campo_Lugar_Venta + "='" + Datos.P_Lugar_Venta + "'");

                //  filtro para numero de venta
                if (!String.IsNullOrEmpty(Datos.P_No_Venta))
                    Mi_SQL.Append(" and v." + Ope_Ventas.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");

                //  filtro para la caja id
                if (!String.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append("AND (" +
                                    " SELECT Caja_ID" +
                                    " FROM ope_cajas" +
                                    " WHERE no_caja = (" +
                                            " SELECT no_caja" +
                                            " FROM ope_pagos" +
                                            " WHERE No_Venta = v.no_venta" +
                                            ")" +
                                    ") = '" + Datos.P_Caja_ID + "'");
                }

                //  filtro para el turno id
                if (!String.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append("AND (" +
                                    " SELECT turno_id" +
                                    " FROM ope_turnos" +
                                    " WHERE no_turno = (" +
                                            " SELECT no_turno" +
                                            " FROM ope_cajas" +
                                            " WHERE no_caja = (" +
                                                    " SELECT no_caja" +
                                                    " FROM ope_pagos" +
                                                    " WHERE No_Venta = v.no_venta" +
                                                    ")" +
                                            ")" +
                                    ") = '" + Datos.P_Turno_ID + "'");
                }

                //  group by
                Mi_SQL.Append(" group by v.no_venta ");

                //  order by
                Mi_SQL.Append(" order by v.Fecha_Cancelacion desc ");

                var Detalle_Venta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Clear();

                #endregion


                #region (Datos Generales)
                var Datos_Generales = new DataTable();
                Datos_Generales.Columns.Add("Usuario", typeof(string));
                //Datos_Generales.Columns.Add("Fecha_Creo", typeof(string));
                Datos_Generales.Columns.Add("Periodo_Reporte", typeof(string));

                var Registro = Datos_Generales.NewRow();
                Registro["Usuario"] = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Registro["Periodo_Reporte"] = Datos.P_Tipo;

                Datos_Generales.Rows.Add(Registro);

                #endregion

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();

                Detalle_Venta.TableName = "Detalle_Ventas";
                Datos_Generales.TableName = "Datos_Generales";
                Ds_Resultado.Tables.Add(Detalle_Venta);
                Ds_Resultado.Tables.Add(Datos_Generales);
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error Metodo: [Rpt_Folios_Cancelados]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Ds_Resultado;
        }
        /// <summary>
        /// Método que consulta los accesos de forma anual, mensual, diario y  por hora.
        /// </summary>
        /// <usuario_creo>Juan Alberto Hernández Negrete</usuario_creo>
        /// <fecha_creo>11 Junio 2014 12:38 Hrs.</fecha_creo>
        /// <usuario_modifico></usuario_modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificion></causa_modificion>
        /// <param name="Datos">Instancia para transportar datos de la capa de usuario a la de datos</param>
        /// <returns>DataSet con las tablas de accesos y tarifas</returns>
        public static DataSet Rpt_Accesos(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
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

                #region (Accesos)
                //Mi_SQL.Append(" SELECT DISTINCT ");
                //Mi_SQL.Append(" DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') AS " + Datos.P_Tipo);
                //Mi_SQL.Append(" , ");
                //Mi_SQL.Append(" (SELECT COUNT(A." + Ope_Accesos.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos.Tabla_Ope_Accesos + " A ");
                //Mi_SQL.Append(" 	WHERE ");
                //Mi_SQL.Append(" 	DATE_FORMAT(A." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') = DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" AND A." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");
                //Mi_SQL.Append(" ) AS NO_TICKETS_VENDIDOS ");
                //Mi_SQL.Append(" , ");
                //Mi_SQL.Append(" (SELECT COUNT(A." + Ope_Accesos.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos.Tabla_Ope_Accesos + " A ");
                //Mi_SQL.Append(" 	WHERE ");
                //Mi_SQL.Append(" 	DATE_FORMAT(A." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') = DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" 	AND COALESCE(A." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ") != '' ");
                //Mi_SQL.Append(" AND A." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");
                //Mi_SQL.Append(" ) AS NO_TICKETS_TORNIQUETE ");
                //Mi_SQL.Append(" , ");
                //Mi_SQL.Append(" (SELECT COUNT(CAMARA." + Ope_Accesos_Camaras.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + " CAMARA ");
                //Mi_SQL.Append(" 	WHERE  ");
                //Mi_SQL.Append(" 	DATE_FORMAT(CAMARA." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') = DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" 	) AS NO_ACCESOS_CAMARA ");
                //Mi_SQL.Append(" FROM  ");
                //Mi_SQL.Append(" " + Ope_Accesos.Tabla_Ope_Accesos + " acceso, " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + " cam ");
                //Mi_SQL.Append(" WHERE ");
                //Mi_SQL.Append(" (ACCESO." + Ope_Accesos.Campo_Fecha_Creo + " BETWEEN " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio) + " AND " +
                //    Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");

                //Mi_SQL.Append(" UNION DISTINCT ");

                //Mi_SQL.Append(" SELECT DISTINCT ");
                //Mi_SQL.Append(" DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') AS " + Datos.P_Tipo);
                //Mi_SQL.Append(" , ");
                //Mi_SQL.Append(" (SELECT COUNT(A." + Ope_Accesos.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos.Tabla_Ope_Accesos + " A ");
                //Mi_SQL.Append(" 	WHERE  ");
                //Mi_SQL.Append(" 	DATE_FORMAT(A." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') = DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" AND A." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");
                //Mi_SQL.Append(" ) AS NO_TICKETS_VENDIDOS ");
                //Mi_SQL.Append(" ,  ");
                //Mi_SQL.Append(" (SELECT COUNT(A." + Ope_Accesos.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos.Tabla_Ope_Accesos + " A ");
                //Mi_SQL.Append(" 	WHERE  ");
                //Mi_SQL.Append(" 	DATE_FORMAT(A." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') = DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" 	AND COALESCE(A." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ") != '' ");
                //Mi_SQL.Append(" AND A." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");
                //Mi_SQL.Append(" ) AS NO_TICKETS_TORNIQUETE ");
                //Mi_SQL.Append(" , ");
                //Mi_SQL.Append(" (SELECT COUNT(CAMARA." + Ope_Accesos_Camaras.Campo_No_Acceso + ")  ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + " CAMARA ");
                //Mi_SQL.Append(" 	WHERE  ");
                //Mi_SQL.Append(" 	DATE_FORMAT(CAMARA." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') = DATE_FORMAT(acceso." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" 	) AS NO_ACCESOS_CAMARA ");
                //Mi_SQL.Append(" 	 ");
                //Mi_SQL.Append(" FROM  ");
                //Mi_SQL.Append(" " + Ope_Accesos.Tabla_Ope_Accesos + " acceso, " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + " cam");
                //Mi_SQL.Append(" WHERE ");
                //Mi_SQL.Append(" (ACCESO." + Ope_Accesos.Campo_Fecha_Creo + " BETWEEN " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio) + " AND " +
                //    Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");

                //Mi_SQL.Append(" UNION DISTINCT ");

                //Mi_SQL.Append(" SELECT DISTINCT ");
                //Mi_SQL.Append(" DATE_FORMAT(cam." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') AS " + Datos.P_Tipo);
                //Mi_SQL.Append(" , ");
                //Mi_SQL.Append(" (SELECT COUNT(A." + Ope_Accesos.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos.Tabla_Ope_Accesos + " A ");
                //Mi_SQL.Append(" 	WHERE  ");
                //Mi_SQL.Append(" 	DATE_FORMAT(A." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') = DATE_FORMAT(cam." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" AND A." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");
                //Mi_SQL.Append(" ) AS NO_TICKETS_VENDIDOS ");
                //Mi_SQL.Append(" ,  ");
                //Mi_SQL.Append(" (SELECT COUNT(A." + Ope_Accesos.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos.Tabla_Ope_Accesos + " A ");
                //Mi_SQL.Append(" 	WHERE  ");
                //Mi_SQL.Append(" 	DATE_FORMAT(A." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') = DATE_FORMAT(cam." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" 	AND COALESCE(A." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ") != '' ");
                //Mi_SQL.Append(" AND A." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");
                //Mi_SQL.Append(" ) AS NO_TICKETS_TORNIQUETE ");
                //Mi_SQL.Append(" , ");
                //Mi_SQL.Append(" (SELECT COUNT(CAMARA." + Ope_Accesos_Camaras.Campo_No_Acceso + ") ");
                //Mi_SQL.Append(" 	FROM " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + " CAMARA ");
                //Mi_SQL.Append(" 	WHERE  ");
                //Mi_SQL.Append(" 	DATE_FORMAT(CAMARA." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') = DATE_FORMAT(cam." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') ");
                //Mi_SQL.Append(" 	) AS NO_ACCESOS_CAMARA ");
                //Mi_SQL.Append(" 	 ");
                //Mi_SQL.Append(" FROM  ");
                //Mi_SQL.Append(" " + Ope_Accesos.Tabla_Ope_Accesos + " acceso, " + Ope_Accesos_Camaras.Tabla_Ope_Accesos_Camaras + " cam");
                //Mi_SQL.Append(" WHERE ");
                //Mi_SQL.Append(" (ACCESO." + Ope_Accesos.Campo_Fecha_Creo + " BETWEEN " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio) + " AND " +
                //    Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");

                Mi_SQL.Clear();

                Mi_SQL.Append("SELECT DATE_FORMAT(D." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') AS " + Datos.P_Tipo);
                Mi_SQL.Append(",CAST(SUM(D." + Ope_Ventas_Detalles.Campo_Cantidad + ") AS SIGNED) NO_TICKETS_VENDIDOS,");
                
                Mi_SQL.Append("(SELECT COUNT(ASS." + Ope_Accesos.Campo_No_Acceso + ") FROM Ope_Accesos ASS ");
                Mi_SQL.Append("WHERE COALESCE(ASS." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ") != '' AND ASS." + Ope_Accesos.Campo_Estatus);
                Mi_SQL.Append(" <> 'CANCELADO' AND DATE_FORMAT(ASS." + Ope_Accesos.Campo_Fecha_Hora_Acceso + ", '" + Datos.P_Formato + "') = ");
                Mi_SQL.Append("DATE_FORMAT(D." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "')) ");
                Mi_SQL.Append("AS NO_TICKETS_TORNIQUETE,");
                
                // conteo de la camara de entrada 
                Mi_SQL.Append("(SELECT IFNULL(sum(CAMARA." + Ope_Accesos_Camaras.Campo_Cantidad + "), 0) FROM ope_accesos_camaras CAMARA ");
                Mi_SQL.Append("WHERE DATE_FORMAT(CAMARA." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') = ");
                Mi_SQL.Append("DATE_FORMAT(D." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') ");
                if (!String.IsNullOrEmpty(Datos.P_Camara_Entrada_Id)) // validamos que tenga informacion
                    Mi_SQL.Append(" and CAMARA." + Ope_Accesos_Camaras.Campo_Camara_Id + " in (" + Datos.P_Camara_Entrada_Id + ")");
                Mi_SQL.Append(") AS NO_ACCESOS_CAMARA_ENTRADA,");

                // conteo de la camara de salida
                Mi_SQL.Append("(SELECT IFNULL(sum(CAMARA." + Ope_Accesos_Camaras.Campo_Cantidad_Salida + "), 0) FROM ope_accesos_camaras CAMARA ");
                Mi_SQL.Append("WHERE DATE_FORMAT(CAMARA." + Ope_Accesos_Camaras.Campo_Fecha_Hora + ", '" + Datos.P_Formato + "') = ");
                Mi_SQL.Append("DATE_FORMAT(D." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') ");
                if (!String.IsNullOrEmpty(Datos.P_Camara_Salida_Id)) // validamos que tenga informacion
                    Mi_SQL.Append(" and CAMARA." + Ope_Accesos_Camaras.Campo_Camara_Id + " in (" + Datos.P_Camara_Salida_Id + ")");
                Mi_SQL.Append(") AS NO_ACCESOS_CAMARA_SALIDA,");
                
                //  folios restantes
                Mi_SQL.Append("(SELECT COUNT(ASS." + Ope_Accesos.Campo_No_Acceso + ") FROM Ope_Accesos ASS ");
                Mi_SQL.Append("WHERE  ASS." + Ope_Accesos.Campo_Estatus);
                Mi_SQL.Append(" = 'ACTIVO' AND DATE_FORMAT(ASS." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') = ");
                Mi_SQL.Append("DATE_FORMAT(D." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "')) ");
                Mi_SQL.Append("AS ACCESOS_SIN_USAR ");

                //  seccion from
                Mi_SQL.Append("FROM " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " D ");
                Mi_SQL.Append(" left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " venta on venta." + Ope_Ventas.Campo_No_Venta + "= D." + Ope_Ventas_Detalles.Campo_No_Venta);
                /*Mi_SQL.Append(" left outer join " + Ope_Accesos.Tabla_Ope_Accesos + " accesos on accesos." + Ope_Accesos.Campo_No_Venta + "= venta." + Ope_Ventas.Campo_No_Venta);*/
                Mi_SQL.Append(" left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " pagos on pagos." + Ope_Pagos.Campo_No_Venta + "= venta." + Ope_Ventas.Campo_No_Venta);
                Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " cajas on cajas." + Ope_Cajas.Campo_No_Caja + "= pagos." + Ope_Pagos.Campo_No_Caja);
                Mi_SQL.Append(" left outer join " + Ope_Turnos.Tabla_Ope_Turnos + " turnos on turnos." + Ope_Turnos.Campo_No_Turno + "= cajas." + Ope_Cajas.Campo_No_Turno);
                Mi_SQL.Append(" left outer join " + Cat_Turnos.Tabla_Cat_Turnos + " cturno on cturno." + Cat_Turnos.Campo_Turno_ID + "= turnos." + Ope_Turnos.Campo_Turno_ID);
                
                //  seccion where
                Mi_SQL.Append(" WHERE (SELECT V.Estatus FROM " + Ope_Ventas.Tabla_Ope_Ventas + " V ");
                Mi_SQL.Append(" WHERE V." + Ope_Ventas.Campo_No_Venta + " = D." + Ope_Ventas_Detalles.Campo_No_Venta + ") <> 'CANCELADO' ");
                Mi_SQL.Append("AND DATE_FORMAT(D." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ", '%Y-%m-%d') BETWEEN ");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio) + " AND ");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino));


                //  filtro de horas a buscar
                Mi_SQL.Append("AND DATE_FORMAT(D." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ", '%H') BETWEEN ");
                Mi_SQL.Append("'" + Datos.P_Hora_Inicio.ToString("HH") + "' AND ");
                Mi_SQL.Append("'" + Datos.P_Hora_Termino.ToString("HH") + "' ");

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL.Append (" and ");
                    Mi_SQL.Append(" venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                }

                //  filtro para el turno
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" cturno." + Cat_Turnos.Campo_Turno_ID + " = '" + Datos.P_Turno_ID + "'");
                }

                //  filtro para los productos
                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(" and ");
                    Mi_SQL.Append(" D." + Ope_Ventas_Detalles.Campo_Producto_Id + " = '" + Datos.P_Producto_ID + "'");
                }

                //  group by
                Mi_SQL.Append(" GROUP BY DATE_FORMAT(D." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "')");

                //Mi_SQL.Append(" order by " + Datos.P_Tipo + " desc ");

                var Datos_Venta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (Datos_Venta != null && Datos_Venta.Rows.Count > 0)
                {
                    string aa = Datos_Venta.Rows[0][1].ToString();
                    int Aux = Convert.ToInt32(Datos_Venta.Rows[0][1]);

                    if (Datos_Venta.Rows.Count > 0)
                        Datos_Venta = Datos_Venta.AsEnumerable().Where(fila =>
                            fila.Field<Int64>("NO_TICKETS_VENDIDOS") > 0 ||
                            fila.Field<Int64>("NO_TICKETS_TORNIQUETE") > 0 ||
                            fila.Field<Int64>("NO_ACCESOS_CAMARA_ENTRADA") > 0 ||
                            fila.Field<Int64>("NO_ACCESOS_CAMARA_SALIDA") > 0 ||
                            fila.Field<Int64>("ACCESOS_SIN_USAR") > 0).CopyToDataTable();

                    if (Datos_Venta.Rows.Count > 0)
                        Datos_Venta = Datos_Venta.AsEnumerable().Where(x => !string.IsNullOrEmpty(x.Field<string>(Datos.P_Tipo))).CopyToDataTable();

                    Mi_SQL.Remove(0, Mi_SQL.Length);

                    if (!Datos.P_Es_Reporte)
                    {
                        if (Datos_Venta != null && Datos_Venta.Rows.Count > 0)
                        {
                            var fila_totales = Datos_Venta.NewRow();
                            fila_totales[Datos.P_Tipo] = "Totales";
                            fila_totales["NO_TICKETS_VENDIDOS"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Int64>("NO_TICKETS_VENDIDOS"));
                            fila_totales["NO_TICKETS_TORNIQUETE"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Int64>("NO_TICKETS_TORNIQUETE"));
                            fila_totales["NO_ACCESOS_CAMARA_ENTRADA"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<decimal>("NO_ACCESOS_CAMARA_ENTRADA"));
                            fila_totales["NO_ACCESOS_CAMARA_SALIDA"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<decimal>("NO_ACCESOS_CAMARA_SALIDA"));
                            fila_totales["ACCESOS_SIN_USAR"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Int64>("ACCESOS_SIN_USAR"));
                            Datos_Venta.Rows.Add(fila_totales);
                        }
                    }

                #endregion

                    #region (Datos Generales)
                    var Datos_Generales = new DataTable();
                    Datos_Generales.Columns.Add("Usuario_Creo", typeof(string));
                    Datos_Generales.Columns.Add("Fecha_Creo", typeof(string));
                    Datos_Generales.Columns.Add("Periodo_Reporte", typeof(string));
                    var Registro = Datos_Generales.NewRow();
                    Registro["Usuario_Creo"] = MDI_Frm_Apl_Principal.Nombre_Usuario;
                    Registro["Fecha_Creo"] = string.Format("{0:dd MMMM yyyy HH:mm:ss tt}", DateTime.Now);
                    if (Datos.P_Fecha_Inicio.Year != 1 && Datos.P_Fecha_Termino.Year != 1)
                        Registro["Periodo_Reporte"] = (string.Format("{0:dd MMMM yyyy}", Datos.P_Fecha_Inicio) + " al " + string.Format("{0:dd MMMM yyyy}", Datos.P_Fecha_Termino)).ToUpper();
                    else
                        Registro["Periodo_Reporte"] = string.Empty;
                    Datos_Generales.Rows.Add(Registro);
                    #endregion

                    #region (Detalle Accesos)
                    Mi_SQL.Append("select ");
                    Mi_SQL.Append("a." + Ope_Accesos.Campo_No_Acceso + " as Folio ");
                    Mi_SQL.Append(", DATE_FORMAT(a." + Ope_Accesos.Campo_Fecha_Creo + ", '" + Datos.P_Formato + "') as Fecha_Venta ");
                    Mi_SQL.Append(", p." + Cat_Productos.Campo_Nombre + " as Acceso ");
                    Mi_SQL.Append(", p." + Cat_Productos.Campo_Costo + " as Costo ");
                    Mi_SQL.Append(", a." + Ope_Accesos.Campo_Estatus + "");
                    Mi_SQL.Append(", a." + Ope_Accesos.Campo_Fecha_Hora_Acceso + " as Fecha_Acceso ");
                    
                    //  seccion from
                    Mi_SQL.Append(" from ");
                    Mi_SQL.Append(Ope_Accesos.Tabla_Ope_Accesos + " a ");
                    Mi_SQL.Append(" left outer join " + Cat_Productos.Tabla_Cat_Productos + " p  ON ");
                    Mi_SQL.Append(" a." + Ope_Accesos.Campo_Producto_ID + "= p." + Cat_Productos.Campo_Producto_Id);

                    Mi_SQL.Append(" left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " ventas on ventas." + Ope_Ventas.Campo_No_Venta + "= a." + Ope_Accesos.Campo_No_Venta);
                    Mi_SQL.Append(" left outer join " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " detalle on detalle." + Ope_Ventas_Detalles.Campo_No_Venta + "= ventas." + Ope_Ventas.Campo_No_Venta);
                    Mi_SQL.Append(" left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " pagos on pagos." + Ope_Pagos.Campo_No_Venta + "= ventas." + Ope_Ventas.Campo_No_Venta);
                    Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " cajas on cajas." + Ope_Cajas.Campo_No_Caja + "= pagos." + Ope_Pagos.Campo_No_Caja);
                    Mi_SQL.Append(" left outer join " + Ope_Turnos.Tabla_Ope_Turnos + " turnos on turnos." + Ope_Turnos.Campo_No_Turno + "= cajas." + Ope_Cajas.Campo_No_Turno);
                    Mi_SQL.Append(" left outer join " + Cat_Turnos.Tabla_Cat_Turnos + " cturno on cturno." + Cat_Turnos.Campo_Turno_ID + "= turnos." + Ope_Turnos.Campo_Turno_ID);
                
                    //  seccion where
                    Mi_SQL.Append(" where ");

                    Mi_SQL.Append(" (detalle.Fecha_Creo BETWEEN " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio) + " AND " +
                        Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino) + ") ");

                    Mi_SQL.Append(" and a." + Ope_Accesos.Campo_Estatus + " <> 'CANCELADO' ");

                    //  filtro de horas a buscar
                    Mi_SQL.Append(" AND DATE_FORMAT(a.Fecha_Creo, '%H') BETWEEN ");
                    Mi_SQL.Append("'" + Datos.P_Hora_Inicio.ToString("HH") + "' AND ");
                    Mi_SQL.Append("'" + Datos.P_Hora_Termino.ToString("HH") + "' ");

                    //  filtro para los productos
                    if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                    {
                        Mi_SQL.Append(" and ");
                        Mi_SQL.Append(" a." + Ope_Accesos.Campo_Producto_ID + " = '" + Datos.P_Producto_ID + "'");
                    }

                    //  filtro para el lugar de la venta
                    if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                    {
                        Mi_SQL.Append(" and ");
                        Mi_SQL.Append(" ventas." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                    }

                    //  filtro para el turno
                    if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                    {
                        Mi_SQL.Append(" and ");
                        Mi_SQL.Append(" cturno." + Cat_Turnos.Campo_Turno_ID + " = '" + Datos.P_Turno_ID + "'");
                    }

                    //  seccion group by
                    Mi_SQL.Append(" group by a." + Ope_Accesos.Campo_No_Acceso);

                    var Dt_Detalle = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                    Mi_SQL.Remove(0, Mi_SQL.Length);
                    #endregion

                    if (!Transaccion_Activa)
                        Conexion.HelperGenerico.Terminar_Transaccion();

                    Datos_Venta.TableName = "Accesos";
                    Datos_Generales.TableName = "Datos_Generales";
                    Dt_Detalle.TableName = "Detalle";
                    Ds_Resultado.Tables.Add(Datos_Venta);
                    Ds_Resultado.Tables.Add(Datos_Generales);
                    Ds_Resultado.Tables.Add(Dt_Detalle);
                }
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Ds_Resultado;
        }


        /// <summary>
        /// Nombre: Consultar_Torniquete_Accesos
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera.
        /// Fecha Creo: 04 Diciembre 2015 11:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Rpt_Detalle_Ventas_Concenteado_Ventas(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            try
            {
                //******************************************************************************
                Mi_SQL.Append("select distinct v.No_Venta");
                Mi_SQL.Append(", (select IFNULL( min(No_Acceso) , '') from ope_accesos where No_Venta = v.No_Venta) as Folio_Acceso_Inicial ");
                Mi_SQL.Append(", (select IFNULL(max(No_Acceso), '') from ope_accesos where No_Venta = v.No_Venta) as Folio_Acceso_Final");
                Mi_SQL.Append(", (select count(No_Acceso) from ope_accesos where No_Venta = v.No_Venta) as Total_Acceso");
                Mi_SQL.Append(", v.Subtotal as Importe");
                Mi_SQL.Append(", v.Descuentos ");
                Mi_SQL.Append(", CASE WHEN v.Estatus = 'CANCELADO' THEN v.Total ELSE 0 END Importe_Cancelado");
                Mi_SQL.Append(", CASE WHEN v.Estatus = 'CANCELADO' THEN 0 	ELSE v.Total END AS Importe_Total");
                Mi_SQL.Append(", v.Estatus AS Estatus_Venta");
                Mi_SQL.Append(", case when v.Lugar_Venta = 'No Caja' then concat('Caja ' , c.Numero_Caja ) else v.Lugar_Venta  end As Lugar_Venta");
                Mi_SQL.Append(", case when v.Museo_ID = '00001' then 'Museo de las momias' 	else 'Culto a la muerte' end as Museo");

                //******************************************************************************
                //  from
                Mi_SQL.Append(" from ope_ventas v");
                Mi_SQL.Append("  join ope_pagos pago on pago.no_venta = v.No_Venta " +
                                " join ope_cajas oc on oc.No_Caja = pago.No_Caja" +
                                " join cat_cajas c on c.Caja_ID = oc.Caja_ID");

                //******************************************************************************
                //  where
                Mi_SQL.Append(" where ");

                //  filtro fecha inicio y fin
                Mi_SQL.Append(" (v." + Ope_Ventas.Campo_Fecha_Creo + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio));
                Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino) + ") ");

                //  filtro para estatus
                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append(" and v.estatus = '" + Datos.P_Estatus + "'");
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL.Append(" and v.Lugar_Venta = '" + Datos.P_Lugar_Venta + "'");
                }

                //  filtro para la caja
                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(" and (select caja_id from cat_cajas where Caja_ID = ( select Caja_ID from ope_cajas where no_caja = (select no_caja from ope_pagos where No_Venta = v.No_Venta) ) ) " +
                            " = '" + Datos.P_Caja_ID + "'");
                }

                //  filtro para el museo 
                if (!string.IsNullOrEmpty(Datos.P_Museo))
                {
                    Mi_SQL.Append(" and v.Museo_ID = '" + Datos.P_Museo + "'");
                }

                //  filtro para  el turno
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(" and (select Turno_ID from ope_turnos where no_turno = ( select No_Turno from ope_cajas where no_caja = (select no_caja from ope_pagos where No_Venta = v.No_Venta) ) ) " +
                            " = '" + Datos.P_Turno_ID + "'");
                }

                //  filtro para el producto
                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(" and (select Producto_Id  from ope_ventas_detalles where ope_ventas_detalles.Producto_ID = '" + Datos.P_Producto_ID + "' and No_Venta = v.No_Venta) " +
                            "= '" + Datos.P_Producto_ID + "'");
                }

                //  filtro folio de acceso
                if (!string.IsNullOrEmpty(Datos.P_Folio_Acceso))
                {
                    Mi_SQL.Append(" and (select No_Acceso from ope_accesos where No_Venta = v.No_Venta and No_Acceso = '" + Datos.P_Folio_Acceso + "' )  " +
                            "= '" + Datos.P_Folio_Acceso + "'");
                }

                //******************************************************************************
                //  order by
                Mi_SQL.Append(" order by no_venta");

                //******************************************************************************
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                for (int i = 0; i < Dt_Consulta.Rows.Count; i++)
                {
                    decimal Importe = 0;
                    decimal.TryParse(Dt_Consulta.Rows[i]["Importe_Total"].ToString(), out Importe);

                    if (Importe == 21) 
                    {
                        Dt_Consulta.Rows[i]["Folio_Acceso_Inicial"] = "Servicio";
                        Dt_Consulta.Rows[i]["Folio_Acceso_Final"] = "Servicio";
                    }
                }
            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Consulta;
        }


        /// <summary>
        /// Nombre: Rpt_Detalle_Ventas_Tipo_Pago
        /// 
        /// Descripción: Método que los retiros que se realizaron de acuerdo a los filtros establecidos.
        /// 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera.
        /// Fecha Creo: 04 Diciembre 2015 11:02 Hrs.
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <returns>Listado de retiros</returns>
        public static DataTable Rpt_Detalle_Ventas_Tipo_Pago(Cls_Rpt_Ventas_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            try
            {
                //******************************************************************************
                Mi_SQL.Append("select v.No_Venta");
                Mi_SQL.Append(", (select IFNULL( min(No_Acceso) , 'Servicio') from ope_accesos where No_Venta = v.No_Venta) as Folio_Acceso_Inicial ");
                Mi_SQL.Append(", (select IFNULL(max(No_Acceso), 'Servicio') from ope_accesos where No_Venta = v.No_Venta) as Folio_Acceso_Final");
                Mi_SQL.Append(", (select count(No_Acceso) from ope_accesos where No_Venta = v.No_Venta) as Total_Acceso");
                Mi_SQL.Append(", CASE WHEN v.Estatus = 'CANCELADO' THEN 0 	ELSE v.Total END AS Importe_Total");
                Mi_SQL.Append(", v.Estatus AS Estatus_Venta");
                Mi_SQL.Append(", case when v.Lugar_Venta = 'No Caja' then concat('Caja ' , c.Numero_Caja ) else v.Lugar_Venta  end As Lugar_Venta");
                
                Mi_SQL.Append(" , case " +
                  " when (select ope_pagos.No_Venta from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta where ope_pagos.No_Venta = v.No_Venta group by ope_pagos.No_Venta having count(*) > 1) != ''  " +
                        " then 'Mixto' " +
                    " else " +
                        " (select Nombre from cat_formas_pago where Forma_ID =  (select ope_pagos.Forma_ID from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta where ope_pagos.No_Venta = v.No_Venta))" +
                    " end as Tipo_Pago");
                
                Mi_SQL.Append(", (select ope_pagos.Titular_Tarjeta from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta where ope_pagos.No_Venta = v.No_Venta and Forma_ID = '00003')as Titular");

                Mi_SQL.Append(", (select ope_pagos.Tipo_Tarjeta from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta where ope_pagos.No_Venta = v.No_Venta and Forma_ID = '00003')as Tipo_Tarjeta");
                
                Mi_SQL.Append(", case" +
                    " when (select ope_pagos.Forma_ID from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta where ope_pagos.No_Venta = v.No_Venta and Forma_ID = '00003')" +
                        " then NULL" +
                    " else" +
                        " NULL" +
                    " end as Banco ");

                Mi_SQL.Append(", (select  concat('x-' , substring(Numero_Tarjeta_Banco, 12,4)) from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta where ope_pagos.No_Venta = v.No_Venta and Forma_ID = '00003')as Numero_Tarjeta");

                Mi_SQL.Append(", CASE " +
                                    " WHEN v.Estatus = 'CANCELADO'" +
                                        " THEN DATE_FORMAT(v.Fecha_Cancelacion , '%d/%m/%Y') " +
                                    " else Null" +
                                " end Fecha_Cancelacion");
                
                Mi_SQL.Append(", v.Usuario_Cancelo");


                //******************************************************************************
                //  from
                Mi_SQL.Append(" from ope_ventas v");
                Mi_SQL.Append("  join ope_pagos pago on pago.no_venta = v.No_Venta " +
                                " join ope_cajas oc on oc.No_Caja = pago.No_Caja" +
                                " join cat_cajas c on c.Caja_ID = oc.Caja_ID");

                //******************************************************************************
                //  where
                Mi_SQL.Append(" where ");

                //  filtro fecha inicio y fin
                Mi_SQL.Append(" (v." + Ope_Ventas.Campo_Fecha_Creo + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Inicio));
                Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha(Datos.P_Fecha_Termino) + ") ");

                //  filtro para estatus
                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append(" and v.estatus = '" + Datos.P_Estatus + "'");
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL.Append(" and v.Lugar_Venta = '" + Datos.P_Lugar_Venta + "'");
                }

                //  filtro para la caja
                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(" and (select caja_id from cat_cajas where Caja_ID = ( select Caja_ID from ope_cajas where no_caja = (select no_caja from ope_pagos where No_Venta = v.No_Venta) ) ) " +
                            " = '" + Datos.P_Caja_ID + "'");
                }

                //  filtro para el museo 
                if (!string.IsNullOrEmpty(Datos.P_Museo))
                {
                    Mi_SQL.Append(" and v.Museo_ID = '" + Datos.P_Museo + "'");
                }

                //  filtro para  el turno
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(" and (select Turno_ID from ope_turnos where no_turno = ( select No_Turno from ope_cajas where no_caja = (select no_caja from ope_pagos where No_Venta = v.No_Venta) ) ) " +
                            " = '" + Datos.P_Turno_ID + "'");
                }

                //  filtro para el producto
                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                {
                    Mi_SQL.Append(" and (select Producto_Id  from ope_ventas_detalles where ope_ventas_detalles.Producto_ID = '" + Datos.P_Producto_ID + "' and No_Venta = v.No_Venta) " +
                            "= '" + Datos.P_Producto_ID + "'");
                }

                //  filtro folio de acceso
                if (!string.IsNullOrEmpty(Datos.P_Folio_Acceso))
                {
                    Mi_SQL.Append(" and (select No_Acceso from ope_accesos where No_Venta = v.No_Venta and No_Acceso = '" + Datos.P_Folio_Acceso + "' )  " +
                            "= '" + Datos.P_Folio_Acceso + "'");
                }

                //******************************************************************************
                //  group by
                Mi_SQL.Append(" group by v.No_Venta");

                //******************************************************************************
                //  order by
                Mi_SQL.Append(" order by no_venta");

                //******************************************************************************
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                //Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los retiros, Metodo: [Consultar_Dias_Accesos_Ventas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Consulta;
        }

        /// <summary>
        /// Nombre: Rpt_Cortes_Arqueos_Por_Dia
        /// 
        /// Descripción: Método que consulta los cortes de caja y arqueos por día.
        /// 
        /// Usuario Creo: Hugo Enrique Ramirez Aguilera
        /// Fecha Creo: 2014-05-29 10:24 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Cortes de Caja ó Arqueos por día.</returns>
        public static DataSet Rpt_Recoleciones(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            bool Entro_Where = false;

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            try
            {
                Mi_SQL.Append(" SELECT  ");
                Mi_SQL.Append("  REC.NO_RECOLECCION AS Folio_Documento ");
                Mi_SQL.Append(", (SELECT min(no_venta) FROM ope_pagos WHERE No_Caja = REC.no_caja ) AS Folio_inicial_de_la_venta");
                Mi_SQL.Append(", (SELECT max(no_venta) FROM ope_pagos WHERE No_Caja = REC.no_caja ) AS Folio_final_de_la_venta");
                Mi_SQL.Append(", concat(CAT_CAJA.NUMERO_CAJA, '') AS No_Caja");
                Mi_SQL.Append(", CAT_TURNO .Nombre as Turno");
                Mi_SQL.Append(", IFNULL(NULLIF(REC.Monto_Recolectado, ''), 0) AS Monto_Recolectado");  
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_1000, ''), 0) AS Billetes_1000 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_500, ''), 0) AS Billetes_500 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_200, ''), 0) AS Billetes_200 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_100, ''), 0) AS Billetes_100 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_50, ''), 0) AS Billetes_50 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.BILLETES_20, ''), 0) AS Billetes_20 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_20, ''), 0) AS Monedas_20 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_10, ''), 0) AS Monedas_10 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_5, ''), 0) AS Monedas_5 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_2, ''), 0) AS Monedas_2 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_1, ''), 0) AS Monedas_1 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_050, ''), 0) AS Monedas_050 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_020, ''), 0) AS Monedas_020 ");
                Mi_SQL.Append(" , IFNULL(NULLIF(REC_DET.MONEDAS_010, ''), 0) AS Monedas_010 ");
                Mi_SQL.Append(", REC.USUARIO_CREO AS Cajero");
                Mi_SQL.Append(", USERS.NOMBRE_USUARIO AS Supervisor");
                Mi_SQL.Append(", DATE_FORMAT(CAJA.Fecha_Hora_Inicio, '%d/%m/%Y %H:%i:%s') AS Fecha_Inicio");
                Mi_SQL.Append(", DATE_FORMAT(CAJA.Fecha_Hora_Cierre, '%d/%m/%Y %H:%i:%s') AS Fecha_Cierre");

                //************************************************************************************
                //  from
                Mi_SQL.Append(" FROM OPE_RECOLECCIONES REC  ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_CAJAS CAJA ON ");
                Mi_SQL.Append(" REC.NO_CAJA = CAJA.NO_CAJA ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN APL_USUARIOS USERS ON ");
                Mi_SQL.Append(" REC.USUARIO_ID_COLECTA = USERS.USUARIO_ID ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN CAT_CAJAS CAT_CAJA ON ");
                Mi_SQL.Append(" CAJA.CAJA_ID = CAT_CAJA.CAJA_ID ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_TURNOS TURNO ON ");
                Mi_SQL.Append(" CAJA.NO_TURNO = TURNO.NO_TURNO ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN CAT_TURNOS CAT_TURNO ON ");
                Mi_SQL.Append(" TURNO.TURNO_ID = CAT_TURNO.TURNO_ID ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_RECOLECCIONES_DETALLES REC_DET ON ");
                Mi_SQL.Append(" REC.NO_RECOLECCION = REC_DET.NO_RECOLECCION ");
                //-----------------------------------------

                //  where
                if (Datos.P_Fecha_Inicio != DateTime.MinValue)
                {
                    if (Datos.P_Fecha_Termino == DateTime.MinValue)
                    {
                        Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                        Mi_SQL.Append(" (REC." + Ope_Recolecciones.Campo_Fecha_Hora + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                        Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio.AddDays(1).AddSeconds(-1)) + ") ");
                    }
                    else if (Datos.P_Fecha_Termino != DateTime.MinValue)
                    {
                        Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                        Mi_SQL.Append(" REC." + Ope_Recolecciones.Campo_Fecha_Hora + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                        Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino.AddDays(1).AddSeconds(-1)) + " ");
                    }
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(" CAT_CAJA." + Cat_Cajas.Campo_Caja_ID + "='" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(" CAT_TURNO." + Cat_Turnos.Campo_Turno_ID + "='" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Es_Corte_Arqueo))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append("REC." + Ope_Recolecciones.Campo_Tipo + "='" + Datos.P_Es_Corte_Arqueo + "' "); //+ 

                }

                if (!string.IsNullOrEmpty(Datos.P_No_Recoleccion))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append("REC." + Ope_Recolecciones.Campo_No_Recoleccion + "='" + Datos.P_No_Recoleccion + "' "); //+ 
                }

                Mi_SQL.Append(" ORDER BY REC.NO_RECOLECCION DESC ");
                var Detalle_Venta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if(Datos.P_Es_Corte_Arqueo == "RECOLECCION")
                    Detalle_Venta.TableName = "Dt_Recoleccion_Arqueo";
                else
                    Detalle_Venta.TableName = "Cortes_Caja";

                Ds_Resultado.Tables.Add(Detalle_Venta);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Recoleciones]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Ds_Resultado;
        }

        /// <summary>
        /// Nombre: Rpt_Cortes_Arqueos_Por_Dia
        /// 
        /// Descripción: Método que consulta los cortes de caja y arqueos por día.
        /// 
        /// Usuario Creo: Hugo Enrique Ramirez Aguilera
        /// Fecha Creo: 2014-05-29 10:24 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Cortes de Caja ó Arqueos por día.</returns>
        public static DataSet Rpt_Arqueo(Cls_Rpt_Ventas_Negocio Datos)
        {
            DataSet Ds_Resultado = new DataSet();
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            bool Entro_Where = false;

            //Iniciar Transacción
            Conexion.Iniciar_Helper();

            try
            {
                
                Mi_SQL.Append(" SELECT  ");
                Mi_SQL.Append("  REC.NO_RECOLECCION AS Folio ");
                Mi_SQL.Append(", (SELECT min(no_venta) FROM ope_pagos WHERE No_Caja = REC.no_caja ) AS Folio_Inicial");
                Mi_SQL.Append(", (SELECT max(no_venta) FROM ope_pagos WHERE No_Caja = REC.no_caja ) AS Folio_Final");
                Mi_SQL.Append(", concat(CAT_CAJA.NUMERO_CAJA, '') AS Numero_Caja");
                Mi_SQL.Append(", CAT_TURNO .Nombre as Turno");

                Mi_SQL.Append(", (select IFNULL(NULLIF(sub_rec.Monto_Recolectado, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion) " +
                                " AS Monto_Recolectado");
                
                Mi_SQL.Append(", (IFNULL(NULLIF(CAJA.Monto_Inicial, ''), 0)) AS Monto_Inicial");

                Mi_SQL.Append(", (select IFNULL(NULLIF(sub_rec.Monto_Recolectado, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion) - (IFNULL(NULLIF(CAJA.Monto_Inicial, ''), 0)) " +
                                " AS Efectivo_cobrado ");

                Mi_SQL.Append(", (select IFNULL(NULLIF(sub_rec.total_tarjeta, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion) " +
                                " AS Total_Tarjeta ");

                Mi_SQL.Append(", (select IFNULL(sum(sub_rec.Monto_Recolectado),0) from ope_recolecciones Sub_Rec where Sub_Rec.no_caja = rec.no_caja and Sub_Rec.tipo = 'RECOLECCION' and Sub_Rec.Estatus != 'CANCELADO' and sub_rec.no_recoleccion < rec.no_recoleccion limit 1) " +
                                " as Total_Recolecciones");

                Mi_SQL.Append(",  (select IFNULL(NULLIF(sub_rec.MONTO_RECOLECTADO, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion) " +
                                    " -  IFNULL(NULLIF(CAJA.MONTO_INICIAL, ''), 0)" +
                                    " + (select IFNULL(NULLIF(sub_rec.TOTAL_TARJETA, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion) " +
                                    " + (select IFNULL(NULLIF(sub_rec.TOTAL_CORTES, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion)  " +
                                    " + (select IFNULL(NULLIF(sub_rec.TOTAL_RETIROS, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion) " +
                                        " AS Cobrado");

                Mi_SQL.Append(", (select IFNULL(NULLIF(sub_rec.TOTAL_CAJA, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion)  " +
                                    " + (select IFNULL(NULLIF(sub_rec.TOTAL_TARJETA, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion)  " +
                                    " + (select IFNULL(NULLIF(sub_rec.TOTAL_CORTES, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion)   " +
                                    " + (select IFNULL(NULLIF(sub_rec.TOTAL_RETIROS, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion)  " +
                                    " - IFNULL(NULLIF(CAJA.MONTO_INICIAL, ''), 0)  " +
                                        " AS Total_sistema");

                Mi_SQL.Append(" , (select IFNULL(NULLIF(sub_rec.total_cancelaciones, ''), 0) from OPE_RECOLECCIONES Sub_Rec where Sub_Rec.No_Caja = rec.no_caja and sub_rec.no_recoleccion = rec.no_recoleccion) " +
                                    " as Total_cancelaciones");

                Mi_SQL.Append(",CASE  WHEN (IFNULL(NULLIF(REC.Resultado_Corte, ''), 0) < 0) then 'FALTANTE' " +
                                    " when (IFNULL(NULLIF(REC.Resultado_Corte, ''), 0) > 0) then 'SOBRANTE' " +
                                    " ELSE 'CERO'" +
                                " END AS Resultado");

                //Mi_SQL.Append(" ,case " +
                //                    " WHEN (IFNULL(NULLIF(REC.Resultado_Corte, ''), 0) < 0) Then " +
                //                    "   (IFNULL(NULLIF(REC.Resultado_Corte, ''), 0) * -1) " +
                //                    " else IFNULL(NULLIF(REC.Resultado_Corte, ''), 0) " +
                //                "  END AS Resultado_Corte");

                Mi_SQL.Append(", rec.Resultado_Corte AS Resultado_Corte");

                Mi_SQL.Append(", REC.USUARIO_CREO AS Cajero");
                Mi_SQL.Append(", USERS.NOMBRE_USUARIO AS Supervisor");
                Mi_SQL.Append(", DATE_FORMAT(CAJA.Fecha_Hora_Inicio, '%d/%m/%Y %H:%i:%s') AS Fecha_Hora_Inicio");
                Mi_SQL.Append(", DATE_FORMAT(CAJA.Fecha_Hora_Cierre, '%d/%m/%Y %H:%i:%s') AS Fecha_Hora_Cierre");
                
                //*************************************************************************************
                //  from
                Mi_SQL.Append(" FROM OPE_RECOLECCIONES REC  ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_CAJAS CAJA ON ");
                Mi_SQL.Append(" REC.NO_CAJA = CAJA.NO_CAJA ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN APL_USUARIOS USERS ON ");
                Mi_SQL.Append(" REC.USUARIO_ID_COLECTA = USERS.USUARIO_ID ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN CAT_CAJAS CAT_CAJA ON ");
                Mi_SQL.Append(" CAJA.CAJA_ID = CAT_CAJA.CAJA_ID ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_TURNOS TURNO ON ");
                Mi_SQL.Append(" CAJA.NO_TURNO = TURNO.NO_TURNO ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN CAT_TURNOS CAT_TURNO ON ");
                Mi_SQL.Append(" TURNO.TURNO_ID = CAT_TURNO.TURNO_ID ");
                //-----------------------------------------
                Mi_SQL.Append(" LEFT OUTER JOIN OPE_RECOLECCIONES_DETALLES REC_DET ON ");
                Mi_SQL.Append(" REC.NO_RECOLECCION = REC_DET.NO_RECOLECCION ");
                //-----------------------------------------

                //  where
                if (Datos.P_Fecha_Inicio != DateTime.MinValue)
                {
                    if (Datos.P_Fecha_Termino == DateTime.MinValue)
                    {
                        Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                        Mi_SQL.Append(" (REC." + Ope_Recolecciones.Campo_Fecha_Hora + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                        Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio.AddDays(1).AddSeconds(-1)) + ") ");
                    }
                    else if (Datos.P_Fecha_Termino != DateTime.MinValue)
                    {
                        Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                        Mi_SQL.Append(" REC." + Ope_Recolecciones.Campo_Fecha_Hora + " between " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Inicio));
                        Mi_SQL.Append(" and " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Termino.AddDays(1).AddSeconds(-1)) + " ");
                    }
                }

                if (!string.IsNullOrEmpty(Datos.P_Caja_ID))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(" CAT_CAJA." + Cat_Cajas.Campo_Caja_ID + "='" + Datos.P_Caja_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(" CAT_TURNO." + Cat_Turnos.Campo_Turno_ID + "='" + Datos.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Datos.P_Es_Corte_Arqueo))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append("REC." + Ope_Recolecciones.Campo_Tipo + "='" + Datos.P_Es_Corte_Arqueo + "' "); //+ 

                }

                if (!string.IsNullOrEmpty(Datos.P_No_Recoleccion))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append("REC." + Ope_Recolecciones.Campo_No_Recoleccion + "='" + Datos.P_No_Recoleccion + "' "); //+ 
                }

                Mi_SQL.Append(" ORDER BY REC.NO_RECOLECCION DESC ");
                var Detalle_Venta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                Detalle_Venta.TableName = "Cortes_Caja";
                Ds_Resultado.Tables.Add(Detalle_Venta);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los registros de ventas, Metodo: [Rpt_Recoleciones]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Ds_Resultado;
        }


    }
}
