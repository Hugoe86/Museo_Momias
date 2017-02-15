using Operaciones.Reimpresion_Accesos.Negocio;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Erp_Ope_Impresiones.Negocio;
using System.Windows.Forms;

namespace Operaciones.Reimpresion_Accesos.Datos
{
    class Cls_Ope_Reimpresion_Accesos_Datos
    {

        #region Metodos
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Realizar_Reimpresion
        ///DESCRIPCIÓN          : Realiza la re impresion de los accesos de una venta
        ///PARAMETROS           : Datos: Instancia de Cls_Ope_Reimpresion_Accesos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 13/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static String Realizar_Reimpresion(Cls_Ope_Reimpresion_Accesos_Negocio Datos)
        {
            String Mi_SQL = "";
            String Consecutivo = "";
            Boolean Alta_Exitosa = false;
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            DataGridViewCheckBoxCell Check_Box_Cell = new DataGridViewCheckBoxCell();

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


                // enviar impresión de recibos y accesos
                var Obj_Impresiones = new Cls_Ope_Impresiones_Negocio();
                Obj_Impresiones.P_No_Venta = Consecutivo;
                Obj_Impresiones.P_Dt_Reimpresion = Datos.P_Dt_Accesos;
                Obj_Impresiones.P_Grid_Accesos = Datos.P_Grid_Accesos;
                Obj_Impresiones.P_Serie = Datos.P_Serie;
                Obj_Impresiones.ReImprimir_Accesos();


                if (Obj_Impresiones.P_Grid_Accesos != null && Obj_Impresiones.P_Grid_Accesos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow Registro in Obj_Impresiones.P_Grid_Accesos.Rows)
                    {
                        Check_Box_Cell = new DataGridViewCheckBoxCell();

                        Check_Box_Cell = Registro.Cells[0] as DataGridViewCheckBoxCell;

                        if (Check_Box_Cell.Value != null)
                        {
                            //  se valida que se encuentre seleccionado el check de reimpresion
                            switch (Check_Box_Cell.Value.ToString())
                            {
                                case "True":
                                    //Numero_Serie_Acceso = Registro.Cells[Ope_Accesos.Campo_Numero_Serie].Value.ToString();

                                    Mi_SQL = "update " + Ope_Accesos.Tabla_Ope_Accesos + " set ";
                                    Mi_SQL += Ope_Accesos.Campo_Usuario_Reimprimio + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'";
                                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Reimpresion + " = " + Cls_Ayudante_Sintaxis.Fecha();
                                    Mi_SQL += ", " + Ope_Accesos.Campo_Estatus_Reimpresion + " = 'S'";

                                    Mi_SQL += " where " + Ope_Accesos.Campo_No_Acceso + "='" + Registro.Cells[Ope_Accesos.Campo_No_Acceso].Value.ToString() + "'";

                                    // ejecutar consulta
                                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Mi_SQL = "update " + Ope_Accesos.Tabla_Ope_Accesos + " set ";
                    Mi_SQL += Ope_Accesos.Campo_Usuario_Reimprimio + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'";
                    Mi_SQL += ", " + Ope_Accesos.Campo_Fecha_Reimpresion + " = " + Cls_Ayudante_Sintaxis.Fecha();
                    Mi_SQL += ", " + Ope_Accesos.Campo_Estatus_Reimpresion + " = 'S'";

                    Mi_SQL += " where " + Ope_Accesos.Campo_No_Venta + "='" + Datos.P_No_Venta + "'";

                    // ejecutar consulta
                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                }


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
            return Consecutivo;
        }
        #endregion

        #region (Consulta)
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Accesos
        ///DESCRIPCIÓN          : Realiza la consulta de los accesos
        ///PARAMETROS           : Datos: Instancia de Cls_Ope_Reimpresion_Accesos_Negocio con los valores de los campos a dar de alta.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 13/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static DataTable Consultar_Accesos(Cls_Ope_Reimpresion_Accesos_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Consulta = null;//Variable de tipo estructura para almacenar los registros encontrados.
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

                Mi_SQL.Append("Select " );
                Mi_SQL.Append(" " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_No_Venta);
                Mi_SQL.Append(", " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_No_Acceso);
                Mi_SQL.Append(", " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Numero_Serie);
                Mi_SQL.Append(", " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Nombre + " as Producto");
                Mi_SQL.Append(", " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Subtotal + " as Costo");
                Mi_SQL.Append(", " + Cat_Cajas.Tabla_Cat_Cajas + "." + Cat_Cajas.Campo_Caja_ID + " as Caja");
                Mi_SQL.Append(", CONCAT('C', " + Cat_Cajas.Tabla_Cat_Cajas + "." + Cat_Cajas.Campo_Numero_Caja + " ) as Numero_Caja");
                Mi_SQL.Append(", DATE_FORMAT(" + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Fecha_Expedicion + ", '%Y-%m-%d') as Fecha_Expedicion");
                Mi_SQL.Append(", DATE_FORMAT(" + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Fecha_Expedicion + ", '%h:%i:%S %p') as Hora_Expedicion");
                Mi_SQL.Append(", DATE_FORMAT(" + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Vigencia_Fin + ", '%Y-%m-%d') as Fecha_Vigencia");
                Mi_SQL.Append(", " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Serie);

                //  seccion from
                Mi_SQL.Append(" From " + Ope_Accesos.Tabla_Ope_Accesos);
                Mi_SQL.Append(" left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + " = " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_No_Venta);
                Mi_SQL.Append(" left outer join " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + " = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta);
                Mi_SQL.Append(" and " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + " = " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Producto_ID);
                Mi_SQL.Append(" left outer join " + Cat_Productos.Tabla_Cat_Productos + " on " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Producto_Id + " = " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Producto_ID);
                Mi_SQL.Append(" left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " on " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Venta + " = " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta);
                Mi_SQL.Append(" left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " on " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja + " = " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja);
                Mi_SQL.Append(" left outer join " + Cat_Cajas.Tabla_Cat_Cajas + " on " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Caja_ID + " = " + Cat_Cajas.Tabla_Cat_Cajas + "." + Cat_Cajas.Campo_Caja_ID);

                //  seccion where
                Mi_SQL.Append(" where " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_No_Venta + "='" + Datos.P_No_Venta + "'");
                Mi_SQL.Append(" and " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Estatus + "='ACTIVO'");
                Mi_SQL.Append(" and DATE_FORMAT(" + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Vigencia_Fin + ", '%Y-%m-%d') >= DATE_FORMAT(NOW(),'%Y-%m-%d')");
                
                //  seccion group by
                Mi_SQL.Append(" group by " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_No_Acceso);
                Mi_SQL.Append(", " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Numero_Serie);
                Mi_SQL.Append(", " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Estatus);

                //  ejecutar consulta
                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de acceso, Metodo: [Consultar_Estacionamiento]. Error: [" + Ex.Message + "]");
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
        #endregion
    }
}
