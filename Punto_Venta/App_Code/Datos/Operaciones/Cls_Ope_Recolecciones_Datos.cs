using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Operaciones.Recolecciones.Negocio;
using Erp.Constantes;
using Erp.Metodos_Generales;
using Erp.Sesiones;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp.Ayudante_Sintaxis;
using Erp.Helper;
using System.Data;
using Operaciones.Cajas.Negocio;
using Erp_Ope_Impresiones.Negocio;
using Erp_Solicitud_Facturacion.Negocio;

namespace Operaciones.Recolecciones.Datos
{
    class Cls_Ope_Recolecciones_Datos
    {
        #region (Metodos)

        #region (Operación)
        /// <summary>
        /// Nombre: Alta_Recoleccion
        /// 
        /// Descripción: Método para realizar el alta en la base de datos de la recolección.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 08 Octubre 2013 17:48 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Estatus de la operación true si la operación se completo y false en caso contrario</returns>
        public static Cls_Ope_Recolecciones_Negocio Alta_Recoleccion(Cls_Ope_Recolecciones_Negocio Datos)
        {
            Boolean Estatus = false;//Variable para mantener el estatus de la operación.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para crear el query que se ejecutara en la bd.
            String Consecutivo = "";//Variable para almacenar el consecutivo de la tabla de Recolecciones
            Boolean Transaccion_Activa = false;//Variable para mantener el estatus de la transacción.

            //Abrir la conexión
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Datos.P_Accion = false;
                Conexion.HelperGenerico.Iniciar_Transaccion();
                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Recolecciones.Tabla_Ope_Recolecciones, Ope_Recolecciones.Campo_No_Recoleccion, "", 10);
                Datos.P_No_Recoleccion = Consecutivo;

                #region (Datos Gral Recolección)
                Mi_SQL.Append("insert into ");
                Mi_SQL.Append(Ope_Recolecciones.Tabla_Ope_Recolecciones);
                Mi_SQL.Append(" (");
                Mi_SQL.Append(Ope_Recolecciones.Campo_No_Recoleccion);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_No_Caja);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Usuario_ID_Colecta);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Numero_Recoleccion);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Numero_Arqueo);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Fecha_Hora);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Monto_Recolectado);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Tipo);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Estatus);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Usuario_Creo);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Fecha_Creo);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Cancelaciones);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Caja_Sistema);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Tarjeta);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Resultado_Corte);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Retiros);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Cortes);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Monto_Depositar);
                

                Mi_SQL.Append(") values(");
                Mi_SQL.Append("'" + Consecutivo + "'");
                Mi_SQL.Append(", '" + Datos.P_No_Caja + "'");
                Mi_SQL.Append(", '" + Datos.P_Usuario_ID_Recolecta + "'");
                Mi_SQL.Append(", " + Datos.P_Numero_Recoleccion);
                Mi_SQL.Append(", " + Datos.P_Numero_Arqueo);
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Hora));
                Mi_SQL.Append(", " + Datos.P_Monto_Recolectado);
                Mi_SQL.Append(", '" + Datos.P_Tipo + "'");
                Mi_SQL.Append(", '" + Datos.P_Estatus + "'");
                Mi_SQL.Append(", '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(",  " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(", '" + Datos.P_Total_Cancelaciones + "'");
                Mi_SQL.Append(", '" + Datos.P_Total_Caja_Sistema + "'");
                Mi_SQL.Append(", '" + Datos.P_Total_Tarjeta + "'");
                Mi_SQL.Append(", '" + Datos.P_Resultado_Corte + "'");
                Mi_SQL.Append(", '" + Datos.P_Total_Retiros + "'");
                Mi_SQL.Append(", '" + Datos.P_Total_Cortes + "'");
                Mi_SQL.Append(", '" + Datos.P_Monto_Depositar + "'");
                Mi_SQL.Append(")");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Detalle Recolección)
                Mi_SQL.Append("insert into ");
                Mi_SQL.Append(Ope_Recolecciones_Detalles.Tabla_Ope_Recolecciones_Detalles);
                Mi_SQL.Append(" (");
                Mi_SQL.Append(Ope_Recolecciones_Detalles.Campo_No_Recoleccion);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_1000);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_500);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_200);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_100);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_50);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_20);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_20);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_10);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_5);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_2);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_1);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_050);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_020);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_010);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Usuario_Creo);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Fecha_Creo);
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Observaciones);
                Mi_SQL.Append(") values(");
                Mi_SQL.Append("'" + Consecutivo + "'");
                Mi_SQL.Append(", " + ((Datos.P_Billetes_1000 > 0) ? Datos.P_Billetes_1000.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Billetes_500 > 0) ? Datos.P_Billetes_500.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Billetes_200 > 0) ? Datos.P_Billetes_200.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Billetes_100 > 0) ? Datos.P_Billetes_100.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Billetes_50 > 0) ? Datos.P_Billetes_50.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Billetes_20 > 0) ? Datos.P_Billetes_20.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_20 > 0) ? Datos.P_Monedas_20.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_10 > 0) ? Datos.P_Monedas_10.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_5 > 0) ? Datos.P_Monedas_5.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_2 > 0) ? Datos.P_Monedas_2.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_1 > 0) ? Datos.P_Monedas_1.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_050 > 0) ? Datos.P_Monedas_050.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_020 > 0) ? Datos.P_Monedas_020.ToString() : "null"));
                Mi_SQL.Append(", " + ((Datos.P_Monedas_010 > 0) ? Datos.P_Monedas_010.ToString() : "null"));
                Mi_SQL.Append(", '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(", '" + Datos.P_Observacion + "'");
                Mi_SQL.Append(")");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion


                // si es cierre de caja, actualizar estatus de caja
                if (Datos.P_Tipo == "CIERRE")
                {
                    Cls_Ope_Cajas_Negocio Obj_Cajas = new Cls_Ope_Cajas_Negocio();
                    Obj_Cajas.P_No_Caja = Datos.P_No_Caja;
                    Obj_Cajas.P_Estatus = "CERRADA";
                    Obj_Cajas.P_Fecha_Hora_Cierre = DateTime.Now;
                    Obj_Cajas.P_Usuario_ID = Datos.P_Caja_Usuario_ID; //MDI_Frm_Apl_Principal.Usuario_ID;
                    Obj_Cajas.Modificar_Caja_Usando_Transaccion();
                    MDI_Frm_Apl_Principal.Caja_ID = "";

                    //  se ingresara las ventas del dia a la tabla de adeudos (DEUDORCAD)
                    Cls_Ope_Solicitud_Facturacion_Negocio Rs_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
                    Rs_Ventas_Dia.P_Dt_Ventas_Dia = Datos.P_Dt_Ventas_Dia;
                    Rs_Ventas_Dia.P_Cuenta_Momias = Datos.P_Cuenta_Momias;
                    Rs_Ventas_Dia.P_Lista = Datos.P_Lista_Adeudo;
                    Rs_Ventas_Dia.P_Tipo = Datos.P_Tipo_Adeudo;
                    Rs_Ventas_Dia.P_Fecha_Venta = Datos.P_Fecha_Venta;
                    Rs_Ventas_Dia.P_Clave_Venta = Datos.P_Clave_Venta;
                    Rs_Ventas_Dia.P_Referencia1 = Datos.P_Referencia1;
                    Rs_Ventas_Dia.P_Referencia2 = Datos.P_Referencia2;
                    Rs_Ventas_Dia.P_No_Cierre = Consecutivo;
                    Rs_Ventas_Dia.P_Dt_Listas_Deudorcad = Datos.P_Dt_Listas_Deudorcad;

                    Rs_Ventas_Dia.Insertar_Historico();


                    if (Datos.P_Dt_Listas_Deudorcad != null && Datos.P_Dt_Listas_Deudorcad.Rows.Count == 0)
                    {
                        //  validacion sobre las ventas realizadas en el dia
                        if (Datos.P_Dt_Ventas_Dia.Rows.Count > 0 && !String.IsNullOrEmpty(Datos.P_Dt_Ventas_Dia.Rows[0][Ope_Cajas.Campo_Fecha_Hora_Inicio].ToString()))
                        {
                            Rs_Ventas_Dia.Insertar_Solicitud_Ventas_Dia();
                        }
                    }
                    else
                    {
                        //  se realiza el corte basandose en el catalogo de listas
                        Rs_Ventas_Dia.Insertar_Solicitud_Ventas_Dia_Catalogo();
                    }
                    
                    //  sobrante
                    if (Datos.P_Resultado_Corte > 0)
                    {
                        Rs_Ventas_Dia.P_Clave_Sobrante = Datos.P_Clave_Sobrante;
                        Rs_Ventas_Dia.P_Sobrante = Datos.P_Resultado_Corte.ToString();
                        Rs_Ventas_Dia.Insertar_Sobrante_Caja();
                    }

                }

                //var Obj_Impresiones = new Cls_Ope_Impresiones_Negocio();
                //Obj_Impresiones.P_Texto_Recoleccion = Datos.P_Texto_Ticket;
                //Obj_Impresiones.Imprimir_Recoleccion();


                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
               
                Estatus = true;
                Datos.P_Accion = Estatus;

                
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al realizar el alta de la recolección, Método: [Alta_Recoleccion]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Datos;
        }
        /// <summary>
        /// Nombre: Modificar_Recoleccion
        /// 
        /// Descripción: Método para realizar la modificación de la recolección.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 08 Octubre 2013 17:52 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Estatus de la operación true si la operación se completo y false en caso contrario</returns>
        public static bool Modificar_Recoleccion(Cls_Ope_Recolecciones_Negocio Datos)
        {
            bool Estatus = false;//Variable para mantener el estatus de la operación.
            Boolean Transaccion_Activa = false;//Variable para mantener el estatus de la transacción.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para crear el query que se ejecutara en la bd.

            //Abrir la conexión
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                #region (Datos Generales Recolección)
                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Recolecciones.Tabla_Ope_Recolecciones);
                Mi_SQL.Append(" set ");
                Mi_SQL.Append(Ope_Recolecciones.Campo_No_Caja + "=" + (string.IsNullOrEmpty(Datos.P_No_Caja) ? "null" : ("'" + Datos.P_No_Caja + "'")));
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Usuario_ID_Colecta + "=" + (string.IsNullOrEmpty(Datos.P_Usuario_ID_Recolecta) ? "null" : ("'" + Datos.P_Usuario_ID_Recolecta + "'")));
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Monto_Recolectado + "=" + ((Datos.P_Monto_Recolectado > 0) ? Datos.P_Monto_Recolectado.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Cancelaciones + "=" + Datos.P_Total_Cancelaciones);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Tarjeta + "=" + Datos.P_Total_Tarjeta);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Resultado_Corte + "=" + Datos.P_Resultado_Corte);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Retiros + "=" + Datos.P_Total_Retiros);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Total_Cortes + "=" + Datos.P_Total_Cortes);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Monto_Depositar + "=" + Datos.P_Monto_Depositar);
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Tipo + "=" + (string.IsNullOrEmpty(Datos.P_Tipo) ? "null" : ("'" + Datos.P_Tipo + "'")));
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Fecha_Hora + "=" + (Datos.P_Fecha_Hora <= DateTime.MinValue ? "null" : (Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Hora))));
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Usuario_Modifico + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(", " + Ope_Recolecciones.Campo_Fecha_Modifico + "=" + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Recolecciones_Detalles.Campo_No_Recoleccion + "='" + Datos.P_No_Recoleccion + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                #region (Detalle Recolección)
                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Recolecciones_Detalles.Tabla_Ope_Recolecciones_Detalles);
                Mi_SQL.Append(" set ");
                Mi_SQL.Append(Ope_Recolecciones_Detalles.Campo_Billetes_1000 + "=" + ((Datos.P_Billetes_1000 > 0) ? Datos.P_Billetes_1000.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_500 + "=" + ((Datos.P_Billetes_500 > 0) ? Datos.P_Billetes_500.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_200 + "=" + ((Datos.P_Billetes_200 > 0) ? Datos.P_Billetes_200.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_100 + "=" + ((Datos.P_Billetes_100 > 0) ? Datos.P_Billetes_100.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_50 + "=" + ((Datos.P_Billetes_50 > 0) ? Datos.P_Billetes_50.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Billetes_20 + "=" + ((Datos.P_Billetes_20 > 0) ? Datos.P_Billetes_20.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_20 + "=" + ((Datos.P_Monedas_20 > 0) ? Datos.P_Monedas_20.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_10 + "=" + ((Datos.P_Monedas_10 > 0) ? Datos.P_Monedas_10.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_5 + "=" + ((Datos.P_Monedas_5 > 0) ? Datos.P_Monedas_5.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_2 + "=" + ((Datos.P_Monedas_2 > 0) ? Datos.P_Monedas_2.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_1 + "=" + ((Datos.P_Monedas_1 > 0) ? Datos.P_Monedas_1.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_050 + "=" + ((Datos.P_Monedas_050 > 0) ? Datos.P_Monedas_050.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_020 + "=" + ((Datos.P_Monedas_020 > 0) ? Datos.P_Monedas_020.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Monedas_010 + "=" + ((Datos.P_Monedas_010 > 0) ? Datos.P_Monedas_010.ToString() : "null"));
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Usuario_Modifico + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(", " + Ope_Recolecciones_Detalles.Campo_Fecha_Modifico + "= " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Recolecciones_Detalles.Campo_No_Recoleccion + "='" + Datos.P_No_Recoleccion + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);
                #endregion

                var Obj_Impresiones = new Cls_Ope_Impresiones_Negocio();
                Obj_Impresiones.P_Texto_Recoleccion = Datos.P_Texto_Ticket;
                Obj_Impresiones.Imprimir_Recoleccion();

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
                Estatus = true;
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al realizar la modificación de la recolección, Método: [Modificar_Recoleccion]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Estatus;
        }
        /// <summary>
        /// Nombre: Eliminar_Recoleccion
        /// 
        /// Descripción: Método que elimina la recolección seleccionada.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 08 Octubre 2013 19:08 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Estatus de la operación true si la operación se completo y false en caso contrario</returns>
        public static bool Eliminar_Recoleccion(Cls_Ope_Recolecciones_Negocio Datos)
        {
            bool Estatus = false;//Variable que mantiene el estatus de la operación.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para crear el query que se ejecutara en la bd.
            Boolean Transaccion_Activa = false;//Variable para mantener el estatus de la transacción.

            //Abrir la conexión
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Recolecciones.Tabla_Ope_Recolecciones + " set ");
                Mi_SQL.Append(Ope_Recolecciones.Campo_Estatus + "='CANCELADO'");
                Mi_SQL.Append(" ," + Ope_Recolecciones.Campo_Motivo_Cancelacion + "='" + Datos.P_Motivo_Cancelacion + "'");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Recolecciones.Campo_No_Recoleccion + "='" + Datos.P_No_Recoleccion + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
                Estatus = true;
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al eliminar el registro, Método: [Eliminar_Recoleccion]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Estatus;
        }
        #endregion

        #region (Consulta)
        /// <summary>
        /// Nombre: Consultar_Recoleccion
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 09 Octubre 2013 10:41 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Recoleccion(Cls_Ope_Recolecciones_Negocio Datos)
        {
            DataTable Dt_Recoleccion = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
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
                Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_No_Recoleccion);
                Mi_SQL.Append(" ,rec." + Ope_Recolecciones.Campo_No_Caja);
                Mi_SQL.Append(" , (" + Cls_Ayudante_Sintaxis.Concatenar(new List<string> { "'Caja '", Cls_Ayudante_Sintaxis.Convertir_A_Caracter("cat_caja.Numero_Caja") }) + ") as Caja_Abierta");
                Mi_SQL.Append(" ,rec." + Ope_Recolecciones.Campo_Usuario_ID_Colecta);
                Mi_SQL.Append(" ,(usuario." + Apl_Usuarios.Campo_Usuario + ") as Usuario ");
                Mi_SQL.Append(" ," + Cls_Ayudante_Sintaxis.Convertir_A_Caracter( "rec." + Ope_Recolecciones.Campo_Numero_Recoleccion) + " as " + Ope_Recolecciones.Campo_Numero_Recoleccion);
                Mi_SQL.Append(" ," + Cls_Ayudante_Sintaxis.Convertir_A_Caracter( "rec." + Ope_Recolecciones.Campo_Numero_Arqueo) + " as " + Ope_Recolecciones.Campo_Numero_Arqueo);
                Mi_SQL.Append(" ,rec." + Ope_Recolecciones.Campo_Fecha_Hora);
                Mi_SQL.Append(" ,rec." + Ope_Recolecciones.Campo_Monto_Recolectado);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Billetes_1000);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Billetes_500);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Billetes_200);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Billetes_100);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Billetes_50);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Billetes_20);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_20);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_10);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_5);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_2);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_1);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_050);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_020);
                Mi_SQL.Append(" ,det_rec." + Ope_Recolecciones_Detalles.Campo_Monedas_010);
                Mi_SQL.Append(" from  ");
                Mi_SQL.Append(" " + Ope_Recolecciones.Tabla_Ope_Recolecciones + " rec  ");

                Mi_SQL.Append(" LEFT OUTER JOIN " + Ope_Recolecciones_Detalles.Tabla_Ope_Recolecciones_Detalles + " det_rec ON  ");
                Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_No_Recoleccion + " = det_rec." + Ope_Recolecciones_Detalles.Campo_No_Recoleccion + " ");

                Mi_SQL.Append(" LEFT OUTER JOIN Ope_Cajas caja ON ");
                Mi_SQL.Append(" rec.No_Caja = caja.No_Caja ");

                Mi_SQL.Append(" LEFT OUTER JOIN Cat_Cajas cat_caja ON ");
                Mi_SQL.Append(" caja.Caja_ID = cat_caja.Caja_ID ");

                Mi_SQL.Append(" LEFT OUTER JOIN " + Apl_Usuarios.Tabla_Apl_Usuarios + " usuario ON ");
                Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_Usuario_ID_Colecta + " = usuario." + Apl_Usuarios.Campo_Usuario_Id + " ");

                Mi_SQL.Append(" where ");
                Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_Estatus + "='RECOLECTADO' ");

                if (!string.IsNullOrEmpty(Datos.P_No_Recoleccion))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_No_Recoleccion + "='" + Datos.P_No_Recoleccion + "'");
                }

                if (!string.IsNullOrEmpty(Datos.P_No_Caja))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" rec." + Ope_Recolecciones.Campo_No_Caja + "='" + Datos.P_No_Caja + "'");
                }

                Dt_Recoleccion = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
                Mi_SQL.Remove(0, Mi_SQL.Length);

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los recolecciones, Metodo: [Consultar_Recoleccion]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Recoleccion;
        }


       
        /// <summary>
        /// Nombre: Consultar_Recoleccion
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 09 Octubre 2013 10:41 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Ventas_Dia(Cls_Ope_Recolecciones_Negocio Datos)
        {
            DataTable Dt_Consulta = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
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

                //Mi_SQL.Append("select CONCAT (sum(vd.Cantidad) ,'-$' ,cast(vd.Subtotal AS CHAR (100))) AS Leyenda,");
                //Mi_SQL.Append("'" + Datos.P_Nombre_Caja  + "' as No_Caja,");
                //Mi_SQL.Append("vd.Producto_Id,");
                //Mi_SQL.Append("sum(vd.Cantidad) as Cantidad,");
                //Mi_SQL.Append("pr.Costo as Costo_Producto,");
                //Mi_SQL.Append("( sum(vd.Cantidad) * pr.Costo) as Total,");
                //Mi_SQL.Append("(select cc.Caja_ID from cat_cajas cc where cc.Caja_ID = " +
                //                    "(select oc.Caja_ID from ope_cajas oc where oc.No_Caja = '" + Datos.P_Nombre_Caja + "')) Caja_ID,");
                //Mi_SQL.Append("(select cc.Numero_Caja from cat_cajas cc where cc.Caja_ID = " +
                //                    "(select oc.Caja_ID from ope_cajas oc where oc.No_Caja = '" + Datos.P_Nombre_Caja + "')) Numero_Caja,");
                //Mi_SQL.Append("(select cc.Comentarios from cat_cajas cc where cc.Caja_ID = " +
                //                    "(select oc.Caja_ID from ope_cajas oc where oc.No_Caja = '" + Datos.P_Nombre_Caja + "')) Nombre_Caja,");
                //Mi_SQL.Append("(select ct.Nombre from cat_turnos ct where ct.Turno_ID = " +
                //                    "(select ot.Turno_ID from ope_turnos ot where ot.No_Turno = "+
                //                    "(select oc.No_Turno from ope_cajas oc where oc.No_Caja = '" + Datos.P_Nombre_Caja + "'))) Nombre_Turno,");
                //Mi_SQL.Append("(select oc.Fecha_Hora_Inicio from ope_cajas oc where oc.No_Caja = '" + Datos.P_Nombre_Caja + "') Fecha_Hora_Inicio,");
                //Mi_SQL.Append("(select p.Forma_ID from ope_pagos p where p.No_Venta = v.No_Venta limit 1) Forma_ID,");
                //Mi_SQL.Append("pr.Nombre,");
                //Mi_SQL.Append("vd.Estatus_Solicitud");

                ////  from
                //Mi_SQL.Append(" from ope_ventas_detalles vd " +
                //                " join ope_ventas v on v.No_Venta = vd.No_Venta" +
                //                " join cat_productos pr on pr.Producto_ID = vd.Producto_ID");


                ////  where
                //Mi_SQL.Append(" where vd.Fecha_Creo between '" + Datos.P_Fecha_Venta + " 00:00:00' and '" + Datos.P_Fecha_Venta + " 23:59:59'");
                //Mi_SQL.Append(" and v.Estatus = 'PAGADO' " +
                //                " and vd.Estatus_Solicitud = 'N'");
                //Mi_SQL.Append(" and (select p.No_Caja from ope_pagos p where p.No_Venta = v.No_Venta limit 1) = '" + Datos.P_Nombre_Caja + "'");


                ////  group by
                //Mi_SQL.Append(" group by vd.Producto_Id,");
                //Mi_SQL.Append("(select p.Forma_ID from ope_pagos p where p.No_Venta = v.No_Venta limit 1)");

                #region Codigo_Original
                Mi_SQL.Append("select  concat(sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad + "), '-$' , cast(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Subtotal + " AS CHAR( 100 )) ) as Leyenda");
                Mi_SQL.Append(", " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja);
                Mi_SQL.Append(", " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id);
                Mi_SQL.Append(", sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad + ") as Cantidad");
                Mi_SQL.Append(", " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Subtotal + " as Costo_Producto");
                Mi_SQL.Append(", Sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Total + ") as Total");
                Mi_SQL.Append(", Sum(" + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Monto_Pago + ") as Total_Mixto");
                Mi_SQL.Append(", " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Caja_ID);

                Mi_SQL.Append(" , (select " + Cat_Cajas.Campo_Comentarios + " from " + Cat_Cajas.Tabla_Cat_Cajas + " where " + Cat_Cajas.Tabla_Cat_Cajas + "." + Cat_Cajas.Campo_Caja_ID + " = " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Caja_ID + ") as Nombre_Caja");
                Mi_SQL.Append(" ,(select Numero_Caja from cat_cajas where cat_cajas.Caja_ID = ope_cajas.Caja_ID) as Numero_Caja");
                Mi_SQL.Append(" ,(select Nombre from cat_turnos where Turno_ID = ope_turnos.Turno_ID) Nombre_Turno");

                Mi_SQL.Append(", DATE_FORMAT(" + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Fecha_Hora_Inicio + " ,'%Y-%m-%d') as Fecha_Hora_Inicio");
                Mi_SQL.Append(",  " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID);
                Mi_SQL.Append(",  " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Estatus_Solicitud);

                //  seccion from
                Mi_SQL.Append(" from " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles);

                Mi_SQL.Append(" left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + "=");
                Mi_SQL.Append(" " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta);

                Mi_SQL.Append(" left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " on " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Venta + "=");
                Mi_SQL.Append(" " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta);

                Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " on " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja + "=");
                Mi_SQL.Append(" " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Caja);

                Mi_SQL.Append(" left outer join " + Ope_Turnos.Tabla_Ope_Turnos + " on " + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_No_Turno + "=");
                Mi_SQL.Append(" " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Turno);

                //  seccion where
                Mi_SQL.Append(" where DATE_FORMAT(" + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Fecha_Hora_Inicio + ",'%Y-%m-%d') = '" + Datos.P_Fecha_Venta + "'");
                Mi_SQL.Append(" and " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Estatus + "='PAGADO'");
                Mi_SQL.Append(" and " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja + " = '" + Datos.P_Nombre_Caja + "'");
                Mi_SQL.Append(" AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Estatus_Solicitud + "= 'N'");

                //  filtro para el numero de venta pago mixto
                if (!String.IsNullOrEmpty(Datos.P_No_Venta_Mixto))
                {
                    Mi_SQL.Append(" and ope_pagos.no_venta not in(" + Datos.P_No_Venta_Mixto + ")");
                }

                //  filtro para el numero de venta pago mixto agrupado
                if (!String.IsNullOrEmpty(Datos.P_No_Venta_Mixto_Agrupada))
                {
                    Mi_SQL.Append(" and ope_pagos.no_venta = '" + Datos.P_No_Venta_Mixto_Agrupada + "'");
                }


                //  filtro para el numero de venta pago
                if (!String.IsNullOrEmpty(Datos.P_No_Venta))
                {
                    Mi_SQL.Append(" and ope_pagos.no_venta = '" + Datos.P_No_Venta + "'");
                }

                //  seccion group by ***************************************************
                Mi_SQL.Append(" group by Ope_Cajas.No_Caja , Producto_Id");
                Mi_SQL.Append(",  " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID);

                //  seccion order by ***************************************************
                Mi_SQL.Append(" order by Ope_Cajas.No_Caja, Producto_Id ");
                #endregion

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar las ventas del dia, Metodo: [Consultar_Ventas_Dia]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Consulta;
        }

        /// <summary>
        /// Nombre: Consultar_Recoleccion
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 09 Octubre 2013 10:41 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Pago_De_Venta_Mixta(Cls_Ope_Recolecciones_Negocio Datos)
        {
            DataTable Dt_Consulta = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
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
                #region Codigo_Original
                Mi_SQL.Append("select no_venta, Forma_ID, Monto_Pago  " +
                                " from ope_pagos" +
                                " where  No_Venta = '" +Datos.P_No_Venta_Mixto_Agrupada +"'");
                #endregion

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar las ventas del dia, Metodo: [Consultar_Ventas_Dia]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Consulta;
        }


        /// <summary>
        /// Nombre: Consultar_Recoleccion
        /// 
        /// Descripción: Método que consulta las recolecciones según los filtros establecidos
        ///              en la invocación del método.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 09 Octubre 2013 10:41 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Tabla con los resultados encontrados</returns>
        public static DataTable Consultar_Ventas_Dia_Mixtas(Cls_Ope_Recolecciones_Negocio Datos)
        {
            DataTable Dt_Consulta = null;//Variable para almacenar los registros encontrados según los filtros establecidos.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos.
            Boolean Transaccion_Activa = false;//Variable que almacena la variable que mantiene el estatus de la transacción.

            //Iniciar Transacción
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

                Mi_SQL.Append("select ope_pagos.No_Venta from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta");
                Mi_SQL.Append(" where ope_ventas.Fecha_Creo between '" + Datos.P_Fecha_Venta + " 00:00:00' and '" + Datos.P_Fecha_Venta + " 23:59:59'");
                Mi_SQL.Append(" and ope_pagos.No_Caja = '" + Datos.P_No_Caja + "'");
                Mi_SQL.Append(" group by ope_pagos.No_Venta having count(*) > 1");

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar las ventas del dia, Metodo: [Consultar_Ventas_Dia]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Consulta;
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
        public static DataTable Consultar_Cajas(Cls_Ope_Recolecciones_Negocio Datos)
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
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Caja);
                Mi_SQL.Append(",caja." + Ope_Cajas.Campo_Usuario_ID);
                Mi_SQL.Append(" , " + Cls_Ayudante_Sintaxis.Concatenar(
                    new List<string>{
                        "'CAJA '", 
                        Cls_Ayudante_Sintaxis.Convertir_A_Caracter(Cls_Ayudante_Sintaxis.Convertir_A_Entero("caja."+Ope_Cajas.Campo_No_Caja))
                    }) + " as Caja");
                Mi_SQL.Append(" , cat_caja." + Cat_Cajas.Campo_Comentarios);
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(" " + Ope_Cajas.Tabla_Ope_Cajas + " caja  ");
                Mi_SQL.Append(" left outer join " + Cat_Cajas.Tabla_Cat_Cajas + " cat_caja ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Caja_ID + " = cat_caja." + Cat_Cajas.Campo_Caja_ID + " ");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_Estatus + " = 'ABIERTA' ");

                //  validacion caja id
                if (!String.IsNullOrEmpty(Datos.P_Caja_Id)) 
                    Mi_SQL.Append(" and caja." + Ope_Cajas.Campo_Caja_ID + " = '" + MDI_Frm_Apl_Principal.Caja_ID + "'");

                //  validacion numero de caja
                if (!string.IsNullOrEmpty(Datos.P_No_Caja))
                    Mi_SQL.Append(" and caja." + Ope_Cajas.Campo_No_Caja + "='" + Datos.P_No_Caja + "' ");


                if(!String.IsNullOrEmpty(Datos.P_Nombre_Equipo))
                {
                    Mi_SQL.Append(" and cat_caja." + Cat_Cajas.Campo_Nombre_Equipo + "='" + Datos.P_Nombre_Equipo + "'");
                }


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


        /// <summary>
        /// Nombre: Consultar_Bancos
        /// 
        /// Descripción: Método que consulta los bancos y obtiene el numero de cuenta.
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz   Amaya
        /// Fecha Creo: 27 Marzo 2015
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Listado con los registros de retiros encontrados según los filtros establecidos</returns>
        public static DataTable Consultar_Bancos(Cls_Ope_Recolecciones_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Bancos = null;//Variable de tipo estructura para almacenar los registros encontrados.
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
                Mi_SQL.Append(Cat_Bancos.Campo_Nombre);
                Mi_SQL.Append("," + Cat_Bancos.Campo_Cuenta);
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(" " + Cat_Bancos.Tabla_Cat_Bancos);


                Dt_Bancos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los bancos, Metodo: [Consultar_Cajas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Bancos;
        }


        /// <summary>
        /// Nombre: Consultar_Usuario_Autorizo
        /// 
        /// Descripción: Método que consulta el usuario que se prelogea para dar permiso para efectuar el movimiento
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz   Amaya
        /// Fecha Creo: 12 Mayo 2015
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Listado con los registros de retiros encontrados según los filtros establecidos</returns>
        public static DataTable Consultar_Usuario_Autorizo(Cls_Ope_Recolecciones_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Usuarios = null;//Variable de tipo estructura para almacenar los registros encontrados.
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
                Mi_SQL.Append(" SELECT ");
                Mi_SQL.Append(Apl_Usuarios.Campo_Rol_Id);
                Mi_SQL.Append("," + Apl_Usuarios.Campo_Nombre_Usuario);
                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" " + Apl_Usuarios.Tabla_Apl_Usuarios);
                Mi_SQL.Append(" WHERE ");
                Mi_SQL.Append(" " + Apl_Usuarios.Campo_Usuario_Id + " = " + Datos.P_Usuario_Autorizo);


                Dt_Usuarios = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar usuario autoriza, Metodo: [Consultar_Usuario_Autorizo]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Usuarios;
        }


        /// <summary>
        /// Nombre: Consultar_Folio_Movimiento
        /// 
        /// Descripción: Método que consulta el folio de movimiento independientemente si es un arqueo, recoleccion o cierre
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz   Amaya
        /// Fecha Creo: 28 Mayo 2015
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Listado con los registros de retiros encontrados según los filtros establecidos</returns>
        public static DataTable Consultar_Folio_Movimiento(Cls_Ope_Recolecciones_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Folio = null;//Variable de tipo estructura para almacenar los registros encontrados.
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
                Mi_SQL.Append(" SELECT ");
                Mi_SQL.Append("MAX("+Ope_Recolecciones.Campo_No_Recoleccion+")+1 AS FOLIO");
                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" " + Ope_Recolecciones.Tabla_Ope_Recolecciones);

                Dt_Folio = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los bancos, Metodo: [Consultar_Cajas]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Folio;
        }



        /// <summary>
        /// Nombre: Consultar_Consecutivo_Recoleccion_Por_Caja_Turno
        /// 
        /// Descripción: Método que consulta el consecutivo por no de caja abierta.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 11 Octubre 2013 18:46 p.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static DataTable Consultar_Consecutivo_Recoleccion_Por_Caja_Turno(Cls_Ope_Recolecciones_Negocio Datos)
        {
            DataTable Dt_Datos_Caja = null;//Variable que almacenara los datos de la caja.
            StringBuilder Mi_SQL = new StringBuilder();//Variable que almacenara la consulta.
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
                Mi_SQL.Append(" cat_turno." + Cat_Turnos.Campo_Nombre);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Inicio);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Cierre);
                Mi_SQL.Append(" ,(SELECT CASE MAX(" + Cls_Ayudante_Sintaxis.Nulos("rec." + Ope_Recolecciones.Campo_Numero_Recoleccion, "0") + ") WHEN 0 THEN 1 ELSE (MAX(rec." + Ope_Recolecciones.Campo_Numero_Recoleccion + ") + 1) END  FROM " + Ope_Recolecciones.Tabla_Ope_Recolecciones + " rec WHERE rec." + Ope_Recolecciones.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' and rec." + Ope_Recolecciones.Campo_Estatus + " = 'RECOLECTADO' and rec." + Ope_Recolecciones.Campo_Tipo + " = 'RECOLECCION' ) AS Numero_Recoleccion ");
                Mi_SQL.Append(" ," + Cls_Ayudante_Sintaxis.Nulos("(" // inicio subconsulta total_tarjeta
                    + " SELECT SUM(" + Cls_Ayudante_Sintaxis.Nulos("pago." + Ope_Pagos.Campo_Monto_Pago, "0") + ") "
                    + " FROM " + Ope_Pagos.Tabla_Ope_Pagos + " pago "
                    + " WHERE pago." + Ope_Pagos.Campo_Estatus + " = 'PAGADO'"
                    + " AND pago." + Ope_Pagos.Campo_Forma_ID + " IN ('00002','00003') " // excluir pagos con tarjeta
                    + " AND pago." + Ope_Pagos.Campo_No_Caja + " = '" + Datos.P_No_Caja + "')"
                    , "0") + " AS Total_Tarjeta");
                Mi_SQL.Append(" ,((" + Cls_Ayudante_Sintaxis.Nulos("(" // inicio subconsulta total_caja
                    + " SELECT SUM(" + Cls_Ayudante_Sintaxis.Nulos("pago." + Ope_Pagos.Campo_Monto_Pago, "0") + ") "
                    + " FROM " + Ope_Pagos.Tabla_Ope_Pagos + " pago "
                    + " WHERE pago." + Ope_Pagos.Campo_Estatus + " = 'PAGADO' "
                    + " AND pago." + Ope_Pagos.Campo_Forma_ID + " = '00001' " // excluir pagos con tarjeta
                    + " AND pago." + Ope_Pagos.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' "
                    + " )", "0") + " + " + Cls_Ayudante_Sintaxis.Nulos("caja.Monto_Inicial", "0") + ") - "
                    + " ((" + Cls_Ayudante_Sintaxis.Nulos("(SELECT SUM(rec." + Ope_Recolecciones.Campo_Monto_Recolectado + ") FROM " + Ope_Recolecciones.Tabla_Ope_Recolecciones + " rec WHERE rec." + Ope_Recolecciones.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' and rec." + Ope_Recolecciones.Campo_Estatus + " = 'RECOLECTADO' )", "0") + " ) + "
                    + Cls_Ayudante_Sintaxis.Nulos("( select SUM(retiro." + Ope_Retiros.Campo_Cantidad + ") from " + Ope_Retiros.Tabla_Ope_Retiros + " retiro WHERE retiro." + Ope_Retiros.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' )", "0") + ")) as Total ");

                Mi_SQL.Append(" ,IFNULL( ");
                Mi_SQL.Append(" (SELECT  ");
                Mi_SQL.Append(" SUM(IFNULL(pago.Monto_Pago, 0))  ");
                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" Ope_Pagos pago  ");
                Mi_SQL.Append(" WHERE pago.Estatus = 'CANCELADO'  ");
                Mi_SQL.Append(" AND pago.No_Caja = caja.No_Caja), ");
                Mi_SQL.Append(" 0 ");
                Mi_SQL.Append(" ) AS Total_Cancelado ");

                Mi_SQL.Append(" ,IFNULL( ");
                Mi_SQL.Append(" (SELECT  ");
                Mi_SQL.Append(" SUM(rec.Monto_Recolectado)  ");
                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" Ope_Recolecciones rec  ");
                Mi_SQL.Append(" WHERE rec.No_Caja = caja.No_Caja ");
                Mi_SQL.Append(" AND rec.Estatus = 'RECOLECTADO'), ");
                Mi_SQL.Append(" 0 ");
                Mi_SQL.Append(" ) AS Total_Recolectado ");

                Mi_SQL.Append(" ,IFNULL( ");
                Mi_SQL.Append(" (SELECT  ");
                Mi_SQL.Append(" SUM(retiro.Cantidad)  ");
                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" Ope_Retiros retiro  ");
                Mi_SQL.Append(" WHERE retiro.No_Caja = caja.No_Caja), ");
                Mi_SQL.Append(" 0 ");
                Mi_SQL.Append(" ) AS Total_Retiros ");

                Mi_SQL.Append(" ,IFNULL(caja.Monto_Inicial, 0) AS Monto_Inicial ");

                Mi_SQL.Append(", IFNULL((" +
                    " SELECT SUM(IFNULL(pago.Monto_Pago, 0))" +
                    " FROM Ope_Pagos pago" +
                    " WHERE (pago.Estatus = 'PAGADO' or pago.Estatus = 'CANCELADO')" +
                        " AND pago.Forma_ID = '00001'" +
                        " AND pago.No_Caja = '" + Datos.P_No_Caja + "'" +
                    "), 0) as Ventas");

                Mi_SQL.Append(", IFNULL((" +
                  " SELECT SUM(IFNULL(pago.Monto_Pago, 0))" +
                  " FROM Ope_Pagos pago" +
                  " WHERE (pago.Estatus = 'PAGADO' or pago.Estatus = 'CANCELADO')" +
                      //" AND pago.Tipo_Tarjeta <> ''" +
                      " AND (pago.Forma_ID = 0002 or pago.Forma_ID = 0003)" +
                      " AND pago.No_Caja = '" + Datos.P_No_Caja + "'" +
                  "), 0) as Ventas_Tarjeta");

                //  seccion from
                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" " + Ope_Cajas.Tabla_Ope_Cajas + " caja ");

                Mi_SQL.Append(" LEFT OUTER JOIN " + Ope_Turnos.Tabla_Ope_Turnos + " turno ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Turno + " = turno." + Ope_Turnos.Campo_No_Turno);

                Mi_SQL.Append(" LEFT OUTER JOIN " + Cat_Turnos.Tabla_Cat_Turnos + " cat_turno ON ");
                Mi_SQL.Append(" turno." + Ope_Turnos.Campo_Turno_ID + "= cat_turno." + Cat_Turnos.Campo_Turno_ID);

                //  seccion where
                Mi_SQL.Append(" WHERE ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' ");

                Mi_SQL.Append(" GROUP BY ");
                Mi_SQL.Append(" cat_turno." + Cat_Turnos.Campo_Nombre);
                Mi_SQL.Append(" ,caja." + Ope_Cajas.Campo_Monto_Inicial);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Inicio);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Cierre);

                Dt_Datos_Caja = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar el consecutivo por caja y turno. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Datos_Caja;
        }
        /// <summary>
        /// Nombre: Consultar_Consecutivo_Recoleccion_Por_Caja_Turno
        /// 
        /// Descripción: Método que consulta el consecutivo por no de caja abierta.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 11 Octubre 2013 18:46 p.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <param name="Datos"></param>
        /// <returns></returns>
        public static DataTable Consultar_Consecutivo_Arqueo_Por_Caja_Turno(Cls_Ope_Recolecciones_Negocio Datos)
        {
            DataTable Dt_Datos_Caja = null;//Variable que almacenara los datos de la caja.
            StringBuilder Mi_SQL = new StringBuilder();//Variable que almacenara la consulta.
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
                Mi_SQL.Append(" cat_turno." + Cat_Turnos.Campo_Nombre);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Inicio);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Cierre);
                Mi_SQL.Append(" ,(SELECT CASE MAX(" + Cls_Ayudante_Sintaxis.Nulos("rec." + Ope_Recolecciones.Campo_Numero_Arqueo, "0") + ")");
                Mi_SQL.Append(" WHEN 0 THEN 1 ELSE (MAX(rec." + Ope_Recolecciones.Campo_Numero_Arqueo + ") + 1) END FROM ");
                Mi_SQL.Append(Ope_Recolecciones.Tabla_Ope_Recolecciones + " rec WHERE rec." + Ope_Recolecciones.Campo_No_Caja + " = '" + Datos.P_No_Caja + "'");
                Mi_SQL.Append("' and rec." + Ope_Recolecciones.Campo_Tipo + " = 'ARQUEO' ) AS " + Ope_Recolecciones.Campo_Numero_Arqueo);
                Mi_SQL.Append("' and rec." + Ope_Recolecciones.Campo_Estatus + " <> 'CANCELADO' ) AS " + Ope_Recolecciones.Campo_Numero_Arqueo);
                Mi_SQL.Append(" ," + Cls_Ayudante_Sintaxis.Nulos("(" // inicio subconsulta total_tarjeta
                    + " SELECT SUM(" + Cls_Ayudante_Sintaxis.Nulos("pago." + Ope_Pagos.Campo_Monto_Pago, "0") + ") "
                    + " FROM " + Ope_Pagos.Tabla_Ope_Pagos + " pago "
                    + " WHERE pago." + Ope_Pagos.Campo_Estatus + " = 'PAGADO'"
                    + " AND pago." + Ope_Pagos.Campo_Tipo_Tarjeta_Banco + " <> ''" // excluir pagos con tarjeta
                    + " AND pago." + Ope_Pagos.Campo_No_Caja + " = '" + Datos.P_No_Caja + "'"
                    + " )","0") + ") AS Total_Tarjeta");
                Mi_SQL.Append(" ,((" + Cls_Ayudante_Sintaxis.Nulos("(" // inicio subconsulta total_caja
                    + " SELECT SUM(" + Cls_Ayudante_Sintaxis.Nulos("pago." + Ope_Pagos.Campo_Monto_Pago,"0") + ") "
                    + " FROM " + Ope_Pagos.Tabla_Ope_Pagos + " pago "
                    + " WHERE pago." + Ope_Pagos.Campo_Estatus + " = 'PAGADO' "
                    + " AND pago." + Ope_Pagos.Campo_Tipo_Tarjeta_Banco + " = '' " // excluir pagos con tarjeta
                    + " AND pago." + Ope_Pagos.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' "
                    + " )", "0") + " + " + Cls_Ayudante_Sintaxis.Nulos("caja.Monto_Inicial", "0") + ") - ");
                Mi_SQL.Append(" ((" + Cls_Ayudante_Sintaxis.Nulos("(SELECT SUM(rec." + Ope_Recolecciones.Campo_Monto_Recolectado + ") FROM " + Ope_Recolecciones.Tabla_Ope_Recolecciones + " rec WHERE rec." + Ope_Recolecciones.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' and rec." + Ope_Recolecciones.Campo_Estatus + " = 'RECOLECTADO' )", "0") + ") + ");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Nulos("( select SUM(retiro." + Ope_Retiros.Campo_Cantidad + ") from " + Ope_Retiros.Tabla_Ope_Retiros + " retiro WHERE retiro." + Ope_Retiros.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' )","0") + ")) as Total ");

                Mi_SQL.Append(" FROM ");
                Mi_SQL.Append(" " + Ope_Cajas.Tabla_Ope_Cajas + " caja ");

                Mi_SQL.Append(" LEFT OUTER JOIN " + Ope_Turnos.Tabla_Ope_Turnos + " turno ON ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Turno + " = turno." + Ope_Turnos.Campo_No_Turno);

                Mi_SQL.Append(" LEFT OUTER JOIN " + Cat_Turnos.Tabla_Cat_Turnos + " cat_turno ON ");
                Mi_SQL.Append(" turno." + Ope_Turnos.Campo_Turno_ID + "= cat_turno." + Cat_Turnos.Campo_Turno_ID);

                Mi_SQL.Append(" WHERE ");
                Mi_SQL.Append(" caja." + Ope_Cajas.Campo_No_Caja + " = '" + Datos.P_No_Caja + "' ");

                Mi_SQL.Append(" GROUP BY ");
                Mi_SQL.Append(" cat_turno." + Cat_Turnos.Campo_Nombre);
                Mi_SQL.Append(" ,caja." + Ope_Cajas.Campo_Monto_Inicial);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Inicio);
                Mi_SQL.Append(" ,turno." + Ope_Turnos.Campo_Fecha_Hora_Cierre);

                Dt_Datos_Caja = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar el consecutivo de arqueo por caja y turno. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Datos_Caja;
        }
        #endregion

        #endregion
    }
}
