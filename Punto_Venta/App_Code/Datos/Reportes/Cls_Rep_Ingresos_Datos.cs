using System;
using System.Data;
using System.Text;
using Erp.Helper;
using Erp.Constantes;
using Reportes.Ingresos.Negocio;
using Erp.Ayudante_Sintaxis;
using MySql.Data.MySqlClient;

namespace Reportes.Ingresos.Datos
{
    class Cls_Rep_Ingresos_Datos
    {

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener el año máximo de ingresos en la tabla de pagos
        /// </summary>
        /// <returns>entero con el número de año resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>27-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static int Consultar_Anio_Maximo_Ingresos()
        {
            string Mi_SQL;
            int Anio;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();


            // formar la consulta
            Mi_SQL = "SELECT YEAR(MAX(" + Ope_Pagos.Campo_Fecha_Creo + ")) FROM " + Apl_Bitacora.Tabla_Apl_Bitacora
                + " WHERE " + Ope_Pagos.Campo_Estatus + "!= 'CANCELADO'";
            // ejecutar consulta
            object Resultado = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();

            // validar objeto resultado de la consulta, si es nulo,
            if (Resultado == null)
            {
                return 0;
            }
            int.TryParse(Resultado.ToString(), out Anio);
            return Anio;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener el año mínimo de ingresos en la tabla de pagos
        /// </summary>
        /// <returns>entero con el número de año resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>27-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static int Consultar_Anio_Minimo_Ingresos()
        {
            string Mi_SQL;
            int Anio;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();


            // formar la consulta
            Mi_SQL = "SELECT YEAR(MIN(" + Ope_Pagos.Campo_Fecha_Creo + ")) FROM " + Apl_Bitacora.Tabla_Apl_Bitacora
                + " WHERE " + Ope_Pagos.Campo_Estatus + "!= 'CANCELADO'";
            // ejecutar consulta
            object Resultado = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();

            // validar objeto resultado de la consulta, si es nulo,
            if (Resultado == null)
            {
                return 0;
            }
            int.TryParse(Resultado.ToString(), out Anio);
            return Anio;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los diferentes años en la tabla de pagos
        /// </summary>
        /// <returns>datatable con los años encontrados en la tabla de pagos</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>27-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Anios_Pagos()
        {
            string Mi_SQL;
            DataTable Dt_Anios = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            // formar la consulta
            Mi_SQL = "SELECT DISTINCT(YEAR(" + Ope_Pagos.Campo_Fecha_Creo + ")) anio FROM " + Ope_Pagos.Tabla_Ope_Pagos
                + " WHERE " + Ope_Pagos.Campo_Estatus + "!= 'CANCELADO'";
            // ejecutar consulta
            Dt_Anios = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Anios;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los ingresos agrupados por mes y año, con filtros 
        /// opcionales de rango de años
        /// </summary>
        /// <param name="Neg_Parametros">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los ingresos encontrados para el rango de años seleccionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Ingresos_Anio(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            string Mi_SQL;
            DataTable Dt_Ingresos = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            try
            {
                #region Consulta original (no cuadra)
                // formar la consulta
                //Mi_SQL = "SELECT YEAR (Venta." + Ope_Ventas.Campo_Fecha_Creo + ") anio, MONTH(p." + Ope_Ventas.Campo_Fecha_Creo
                //    + ") mes, sum(Venta." + Ope_Ventas.Campo_Total + ") monto_pago ";

                ////  seccion from *********************
                //Mi_SQL += "FROM " + Ope_Ventas.Tabla_Ope_Ventas + " Venta";
                //Mi_SQL += " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " p on p." + Ope_Pagos.Campo_No_Venta + "= Venta." + Ope_Ventas.Campo_No_Venta;
                  
                ////  seccion where *********************
                //Mi_SQL += " WHERE Venta." + Ope_Ventas.Campo_Estatus + "= 'PAGADO'";
                
                //// si se proporcionan años agregar a la consulta
                //if (Neg_Parametros.P_Anio_Inicio > 0)
                //{
                //    Mi_SQL += " AND YEAR (Venta." + Ope_Ventas.Campo_Fecha_Creo + ")>=" + Neg_Parametros.P_Anio_Inicio;
                //}
                
                //if (Neg_Parametros.P_Anio_Final > 0)
                //{
                //    Mi_SQL += " AND YEAR (Venta." + Ope_Ventas.Campo_Fecha_Creo + ")<=" + Neg_Parametros.P_Anio_Final;
                //}

                //// Se valida si se seleccionó un Turno.
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                //{
                //    Mi_SQL += " AND (SELECT Turno_ID FROM Ope_Turnos t WHERE t.No_Turno = ";
                //    Mi_SQL += "(SELECT No_Turno FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja)) = ";
                //    Mi_SQL += "'" + Neg_Parametros.P_Turno_ID + "'";
                //}

                //// Se valida si se seleccionó una Caja.
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Numero_Caja))
                //{
                //    Mi_SQL += " AND (SELECT Caja_ID FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja) = ";
                //    Mi_SQL += "'" + Neg_Parametros.P_Numero_Caja + "'";
                //}

                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                //{
                //    Mi_SQL += " AND p.Forma_ID = '" + Neg_Parametros.P_Forma_ID + "'";
                //}

                ////  filtro para el lugar de la venta
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                //{
                //    Mi_SQL += " and  Venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Neg_Parametros.P_Lugar_Venta + "'";
                //}

                //// agrupar por año y mes
                //Mi_SQL += " GROUP BY YEAR(Venta." + Ope_Ventas.Campo_Fecha_Creo + ")" +
                //        ", MONTH(Venta." + Ope_Ventas.Campo_Fecha_Creo + ")";
                #endregion


                #region 
                Mi_SQL = "SELECT YEAR (detalle." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ") anio" +
                        ", MONTH(detalle." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ") mes" +
                        ", sum(detalle." + Ope_Ventas_Detalles.Campo_Total + ") monto_pago ";

                //  seccion from
                Mi_SQL += " From " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " detalle";
                
                Mi_SQL += " left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " ventas on ventas." + Ope_Ventas.Campo_No_Venta + "=detalle." + Ope_Ventas_Detalles.Campo_No_Venta;

                Mi_SQL += " and ventas.Museo_ID = detalle.Museo_ID";
                
                Mi_SQL += " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " p on p." + Ope_Pagos.Campo_No_Venta + "= ventas." + Ope_Ventas.Campo_No_Venta;
                Mi_SQL += " and ventas.Museo_ID = p.Museo_ID ";

                //Mi_SQL += " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " p on p." + Ope_Pagos.Campo_No_Venta + "= ventas." + Ope_Ventas.Campo_No_Venta;


                //  seccion where
                //  seccion where *********************
                Mi_SQL += " WHERE ventas." + Ope_Ventas.Campo_Estatus + "= 'PAGADO'";

                Mi_SQL += " and ventas.Persona_Tramita IS NULL";

                // si se proporcionan años agregar a la consulta
                if (Neg_Parametros.P_Anio_Inicio > 0)
                {
                    Mi_SQL += " AND YEAR (ventas." + Ope_Ventas.Campo_Fecha_Creo + ")>=" + Neg_Parametros.P_Anio_Inicio;
                }

                if (Neg_Parametros.P_Anio_Final > 0)
                {
                    Mi_SQL += " AND YEAR (ventas." + Ope_Ventas.Campo_Fecha_Creo + ")<=" + Neg_Parametros.P_Anio_Final;
                }

                // Se valida si se seleccionó un Turno.
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                {
                    Mi_SQL += " AND (SELECT Turno_ID FROM Ope_Turnos t WHERE t.No_Turno = ";
                    Mi_SQL += "(SELECT No_Turno FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja)) = ";
                    Mi_SQL += "'" + Neg_Parametros.P_Turno_ID + "'";
                }

                // Se valida si se seleccionó una Caja.
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Numero_Caja))
                {
                    Mi_SQL += " AND (SELECT Caja_ID FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja) = ";
                    Mi_SQL += "'" + Neg_Parametros.P_Numero_Caja + "'";
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                {
                    Mi_SQL += " AND p.Forma_ID = '" + Neg_Parametros.P_Forma_ID + "'";
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                {
                    Mi_SQL += " and  ventas." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Neg_Parametros.P_Lugar_Venta + "'";
                }


                // agrupar por año y mes
                Mi_SQL += " GROUP BY YEAR(detalle." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")" +
                        ", MONTH(detalle." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")";

                #endregion


                // ejecutar consulta
                Dt_Ingresos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Ingresos] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Ingresos;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los accesos agrupados por año y mes, con filtros 
        /// opcionales de rango de años
        /// </summary>
        /// <param name="Neg_Parametros">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los accesos encontrados para el rango de años seleccionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Accesos_Anio(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            string Mi_SQL;
            DataTable Dt_Accesos = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {

                #region Accesos (original)
                //// formar la consulta
                //Mi_SQL = "SELECT YEAR (" + Ope_Accesos.Campo_Fecha_Hora_Acceso + ") anio, MONTH(" + Ope_Accesos.Campo_Fecha_Hora_Acceso
                //    + ") mes, count(A." + Ope_Accesos.Campo_Estatus + ") accesos";


                //Mi_SQL += " FROM " + Ope_Accesos.Tabla_Ope_Accesos + " A " +
                //        " LEFT OUTER JOIN " + Ope_Ventas.Tabla_Ope_Ventas + " venta on venta." + Ope_Ventas.Campo_No_Venta + "= A." + Ope_Accesos.Campo_No_Venta +
                //        " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " p on p." + Ope_Pagos.Campo_No_Venta + " = A." + Ope_Accesos.Campo_No_Venta +
                //        " left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " c on c." + Ope_Cajas.Campo_No_Caja + " = p." + Ope_Pagos.Campo_No_Caja +
                //        " left outer join " + Ope_Turnos.Tabla_Ope_Turnos + " T on T." + Ope_Turnos.Campo_No_Turno + " = c. " + Ope_Cajas.Campo_No_Turno;
                   
                //Mi_SQL +=  " WHERE A." + Ope_Accesos.Campo_Estatus + "= 'UTILIZADO'";
                
                //// si se proporcionan años agregar a la consulta
                //if (Neg_Parametros.P_Anio_Inicio > 0)
                //{
                //    Mi_SQL += " AND YEAR (" + Ope_Accesos.Campo_Fecha_Hora_Acceso + ")>=" + Neg_Parametros.P_Anio_Inicio;
                //}
                
                //if (Neg_Parametros.P_Anio_Final > 0)
                //{
                //    Mi_SQL += " AND YEAR (" + Ope_Accesos.Campo_Fecha_Hora_Acceso + ")<=" + Neg_Parametros.P_Anio_Final;
                //}


                //// Se valida si se seleccionó un Número de Caja.
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Numero_Caja))
                //{
                //    Mi_SQL += " and  c." + Ope_Cajas.Campo_Caja_ID + "='" + Neg_Parametros.P_Numero_Caja + "'";
                ////    Mi_SQL += " AND (SELECT Caja_ID FROM Ope_Cajas C WHERE C.No_Caja = ";
                ////    Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = A.No_Venta)) = ";
                ////    Mi_SQL += "'" + Neg_Parametros.P_Numero_Caja + "'";
                //}

                //// Se valida si se seleccionó un Turno.
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                //{
                //    Mi_SQL += " and T." + Ope_Turnos.Campo_Turno_ID + "='" + Neg_Parametros.P_Turno_ID + "'";

                //    //Mi_SQL += " AND (SELECT Turno_ID FROM Ope_Turnos T WHERE T.No_Turno = ";
                //    //Mi_SQL += "(SELECT No_turno FROM Ope_Cajas C WHERE C.No_Caja = ";
                //    //Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = A.No_Venta))) = ";
                //    //Mi_SQL += "'" + Neg_Parametros.P_Turno_ID + "'";
                //}

                //// Se valida si se seleccionó una Forma de Pago.
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                //{
                //    Mi_SQL += " AND (SELECT Forma_ID FROM Ope_Pagos P WHERE P.No_Venta = A.No_Venta  limit 1) = ";
                //    Mi_SQL += "'" + Neg_Parametros.P_Forma_ID + "'";
                //}

                ////  filtro para el lugar de la venta
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                //{
                //    Mi_SQL += " and ";
                //    Mi_SQL += " venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Neg_Parametros.P_Lugar_Venta + "'";
                //}


                //// agrupar por año y mes
                //Mi_SQL += " GROUP BY YEAR(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + "), MONTH(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + ")";
                
                #endregion Accesos

                #region visitantes

                Mi_SQL = "SELECT YEAR(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ") anio";
                Mi_SQL += ", MONTH(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ") mes";
                Mi_SQL += ", sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad + ") accesos";

                Mi_SQL += " FROM " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "  " +
                        " LEFT OUTER JOIN " + Ope_Ventas.Tabla_Ope_Ventas + " venta on venta." + Ope_Ventas.Campo_No_Venta + "= " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Accesos.Campo_No_Venta + " and venta.Museo_ID = Ope_Ventas_Detalles.Museo_ID " +
                        " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + " p on p." + Ope_Pagos.Campo_No_Venta + " = venta." + Ope_Accesos.Campo_No_Venta + " and p.Museo_ID = venta.Museo_ID " +
                        " left outer join " + Ope_Cajas.Tabla_Ope_Cajas + " c on c." + Ope_Cajas.Campo_No_Caja + " = p." + Ope_Pagos.Campo_No_Caja +
                        " left outer join " + Ope_Turnos.Tabla_Ope_Turnos + " T on T." + Ope_Turnos.Campo_No_Turno + " = c. " + Ope_Cajas.Campo_No_Turno;

                // si se proporcionan años agregar a la consulta
                if (Neg_Parametros.P_Anio_Inicio > 0)
                {
                    Mi_SQL += " where YEAR (" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")>=" + Neg_Parametros.P_Anio_Inicio;
                }

                if (Neg_Parametros.P_Anio_Final > 0)
                {
                    Mi_SQL += " AND YEAR (" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")<=" + Neg_Parametros.P_Anio_Final;
                }

                Mi_SQL += " and venta.Estatus IN ('PAGADO')";
                Mi_SQL += " and venta.Persona_Tramita IS NULL";

                // Se valida si se seleccionó un Número de Caja.
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Numero_Caja))
                {
                    Mi_SQL += " and  c." + Ope_Cajas.Campo_Caja_ID + "='" + Neg_Parametros.P_Numero_Caja + "'";
                }

                // Se valida si se seleccionó un Turno.
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                {
                    Mi_SQL += " and T." + Ope_Turnos.Campo_Turno_ID + "='" + Neg_Parametros.P_Turno_ID + "'";
                }

                // Se valida si se seleccionó una Forma de Pago.
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                {
                    Mi_SQL += " AND (SELECT Forma_ID FROM Ope_Pagos P WHERE P.No_Venta = " +Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles +".No_Venta  limit 1) = ";
                    Mi_SQL += "'" + Neg_Parametros.P_Forma_ID + "'";
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                {
                    Mi_SQL += " and ";
                    Mi_SQL += " venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Neg_Parametros.P_Lugar_Venta + "'";
                }

                // agrupar por año y mes
                Mi_SQL += " GROUP BY YEAR(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")" +
                    ", MONTH(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")";
                
                #endregion


                // ejecutar consulta
                Dt_Accesos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Accesos] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Accesos;
        }

        /// <summary>
        /// Genera la Tabla del Costo de Tarifa por Año.
        /// </summary>
        /// <param name="Neg_Parametros">Los Datos para los filtros.</param>
        /// <returns>DataTable con la información de las Tarifas.</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static DataSet Recaudación_Tarifa(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                int Rango = Neg_Parametros.P_Anio_Final - Neg_Parametros.P_Anio_Inicio + 1;

                Mi_Sql.Append("select ");
                Mi_Sql.Append("    Nombre,");

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                {
                    Rango = 1;
                }

                for (int i = 0; i < Rango; i++)
                {
                    Mi_Sql.Append("    sum(Costo * (1 - sign(abs(" +
                        (Neg_Parametros.P_Anio_Inicio + i) + " - Anio)))) '" +
                        (Neg_Parametros.P_Anio_Inicio + i) + "',");
                }
                
                // Se quita la última coma ',' de la sentencia SELECT.
                Mi_Sql.Replace(",", " ", Mi_Sql.Length - 1, 1);

                Mi_Sql.Append("from (");
	            Mi_Sql.Append("    select"); 
		        Mi_Sql.Append("        c.Nombre,");
		        Mi_Sql.Append("        p.Costo,");
		        Mi_Sql.Append("        p.Anio");
	            Mi_Sql.Append("    from");
		        Mi_Sql.Append("        cat_productos p"); 
		        Mi_Sql.Append("        join cat_categorias c on c.Catergoria_ID = p.Categoria_ID");

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                {
                    Mi_Sql.Append("    where p.Producto_ID = '" + Neg_Parametros.P_Tarifa_Id + "'");
                }

                Mi_Sql.Append(") T1 ");
                Mi_Sql.Append("group by");
                Mi_Sql.Append("    Nombre;");

                Mi_Sql.Append("select");
	            Mi_Sql.Append("    c.Nombre,");
                Mi_Sql.Append("    p.Anio ");
                Mi_Sql.Append("from ");
	            Mi_Sql.Append("    cat_productos p");
                Mi_Sql.Append("    join cat_categorias c on c.Catergoria_ID = p.Categoria_ID ");
                Mi_Sql.Append("order by");
                Mi_Sql.Append("    c.Nombre,");
	            Mi_Sql.Append("    p.Anio;");

                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_Sql.ToString();

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter(Cmd))
                    {
                        DataSet Resultados = new DataSet();
                        Adap.Fill(Resultados);

                        return Resultados;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Genera la Tabla de Recaudación por Tarifa por Año.
        /// </summary>
        /// <param name="Neg_Parametros">Los Datos para los Filtros.</param>
        /// <returns>DataTable con la Información de las Tarifas.</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static DataSet Recaudacion_Acumulado_Tarifa(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                int Rango = Neg_Parametros.P_Anio_Final - Neg_Parametros.P_Anio_Inicio + 1;

                Mi_Sql.Append("select ");
	            Mi_Sql.Append("    Nombre,");

                for (int i = 0; i < Rango; i++)
                {
                    Mi_Sql.Append("    sum(Total * (1 - sign(abs(" +
                        (Neg_Parametros.P_Anio_Inicio + i) + " - Anio)))) '" +
                        (Neg_Parametros.P_Anio_Inicio + i) + "',");
                }

                // Se quita la última coma ',' de la sentencia SELECT.
                Mi_Sql.Replace(",", " ", Mi_Sql.Length - 1, 1);

                Mi_Sql.Append("from (");
	            Mi_Sql.Append("    select"); 
		        Mi_Sql.Append("        c.Nombre,");
		        Mi_Sql.Append("        sum(vd.Total) Total,");
		        Mi_Sql.Append("        year(v.Fecha_Creo) Anio");
	            Mi_Sql.Append("    from");
		        Mi_Sql.Append("        ope_ventas_detalles vd");
		        Mi_Sql.Append("        join ope_ventas v on vd.No_Venta = v.No_Venta and vd.Museo_ID = v.Museo_ID");
                
                Mi_Sql.Append("        join (select distinct pp.No_Caja, pp.No_Venta, pp.Museo_ID from ope_pagos pp");
                Mi_Sql.Append("             where pp.Fecha_Creo between @FechaIni and @FechaFin) p on p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID");
                Mi_Sql.Append("        join ope_cajas oc on oc.No_Caja = p.No_Caja");
                Mi_Sql.Append("        join ope_turnos ot on ot.No_Turno = oc.No_Turno");

		        Mi_Sql.Append("        join cat_productos p on p.Producto_ID = vd.Producto_ID");
		        Mi_Sql.Append("        join cat_categorias c on c.Catergoria_ID = p.Categoria_ID");
	            Mi_Sql.Append("    where");
		        Mi_Sql.Append("        v.Fecha_Creo between @FechaIni and @FechaFin");
                Mi_Sql.Append("        and v.Estatus = 'PAGADO' ");

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Museo_ID))
                {
                    Mi_Sql.Append("        and v.Museo_ID = '" + Neg_Parametros.P_Museo_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                {
                    Mi_Sql.Append("        and vd.Producto_ID = '" + Neg_Parametros.P_Tarifa_Id + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                {
                    Mi_Sql.Append("        and ot.Turno_ID = '" + Neg_Parametros.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                {
                    Mi_Sql.Append("        and oc.Caja_ID = '" + Neg_Parametros.P_No_Caja + "' ");
                }
                
	            Mi_Sql.Append("    group by");
		        Mi_Sql.Append("        c.Nombre,");
		        Mi_Sql.Append("        year(v.Fecha_Creo)");
                Mi_Sql.Append(") T1 ");
                Mi_Sql.Append("group by");
	            Mi_Sql.Append("    Nombre;");

                Mi_Sql.Append("select");
                Mi_Sql.Append("    c.Nombre,");
                Mi_Sql.Append("    p.Anio ");
                Mi_Sql.Append("from ");
                Mi_Sql.Append("    cat_productos p");
                Mi_Sql.Append("    join cat_categorias c on c.Catergoria_ID = p.Categoria_ID ");
                Mi_Sql.Append("order by");
                Mi_Sql.Append("    c.Nombre,");
                Mi_Sql.Append("    p.Anio;");

                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_Sql.ToString();
                    Cmd.Parameters.AddWithValue("@FechaIni", new DateTime(Neg_Parametros.P_Anio_Inicio, 1, 1));
                    Cmd.Parameters.AddWithValue("@FechaFin", new DateTime(Neg_Parametros.P_Anio_Final, 12, 31));

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter(Cmd))
                    {
                        DataSet Resultados = new DataSet();
                        Adap.Fill(Resultados);

                        return Resultados;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Genera la Tabla de Visitantes por Tarifa por Año.
        /// </summary>
        /// <param name="Neg_Parametros">Los Datos para los filtros.</param>
        /// <returns>DataTable con la información de las Tarifas.</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static DataSet Recaudacion_Acumulado_Visitantes(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                int Rango = Neg_Parametros.P_Anio_Final - Neg_Parametros.P_Anio_Inicio + 1;

                Mi_Sql.Append("select ");
                Mi_Sql.Append("    Nombre,");

                for (int i = 0; i < Rango; i++)
                {
                    Mi_Sql.Append("    cast(sum(Total * (1 - sign(abs(" +
                        (Neg_Parametros.P_Anio_Inicio + i) + " - Anio)))) as signed) '" +
                        (Neg_Parametros.P_Anio_Inicio + i) + "',");
                }

                // Se quita la última coma ',' de la sentencia SELECT.
                Mi_Sql.Replace(",", " ", Mi_Sql.Length - 1, 1);

                Mi_Sql.Append("from (");
                Mi_Sql.Append("    select");
                Mi_Sql.Append("        c.Nombre,");
                Mi_Sql.Append("        sum(vd.Cantidad) Total,");
                Mi_Sql.Append("        year(v.Fecha_Creo) Anio");
                Mi_Sql.Append("    from");
                Mi_Sql.Append("        ope_ventas_detalles vd");
                Mi_Sql.Append("        join ope_ventas v on vd.No_Venta = v.No_Venta and vd.Museo_ID = v.Museo_ID");

                Mi_Sql.Append("        join (select distinct pp.No_Caja, pp.No_Venta, pp.Museo_ID from ope_pagos pp");
                Mi_Sql.Append("             where pp.Fecha_Creo between @FechaIni and @FechaFin) p on p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID");
                Mi_Sql.Append("        join ope_cajas oc on oc.No_Caja = p.No_Caja");
                Mi_Sql.Append("        join ope_turnos ot on ot.No_Turno = oc.No_Turno");
                
                Mi_Sql.Append("        join cat_productos p on p.Producto_ID = vd.Producto_ID");
                Mi_Sql.Append("        join cat_categorias c on c.Catergoria_ID = p.Categoria_ID");
                
                Mi_Sql.Append("    where");
                Mi_Sql.Append("        v.Fecha_Creo between @FechaIni and @FechaFin");
                Mi_Sql.Append("        and v.Estatus = 'PAGADO'");

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Museo_ID))
                {
                    Mi_Sql.Append("        and v.Museo_ID = '" + Neg_Parametros.P_Museo_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                {
                    Mi_Sql.Append("        and vd.Producto_ID = '" + Neg_Parametros.P_Tarifa_Id + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                {
                    Mi_Sql.Append("        and ot.Turno_ID = '" + Neg_Parametros.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                {
                    Mi_Sql.Append("        and oc.Caja_ID = '" + Neg_Parametros.P_No_Caja + "' ");
                }
                
                Mi_Sql.Append("    group by");
                Mi_Sql.Append("        c.Nombre,");
                Mi_Sql.Append("        year(v.Fecha_Creo)");
                Mi_Sql.Append(") T1 ");
                Mi_Sql.Append("group by");
                Mi_Sql.Append("    Nombre;");

                Mi_Sql.Append("select");
                Mi_Sql.Append("    c.Nombre,");
                Mi_Sql.Append("    p.Anio ");
                Mi_Sql.Append("from ");
                Mi_Sql.Append("    cat_productos p");
                Mi_Sql.Append("    join cat_categorias c on c.Catergoria_ID = p.Categoria_ID ");
                Mi_Sql.Append("order by");
                Mi_Sql.Append("    c.Nombre,");
                Mi_Sql.Append("    p.Anio;");

                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_Sql.ToString();
                    Cmd.Parameters.AddWithValue("@FechaIni", new DateTime(Neg_Parametros.P_Anio_Inicio, 1, 1));
                    Cmd.Parameters.AddWithValue("@FechaFin", new DateTime(Neg_Parametros.P_Anio_Final, 12, 31));

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter(Cmd))
                    {
                        DataSet Resultados = new DataSet();
                        Adap.Fill(Resultados);

                        return Resultados;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Genera la Tabla de Concentado de Recaudación y Visitantes.
        /// </summary>
        /// <param name="Neg_Parametros">Los Datos para los filtros.</param>
        /// <returns>DataTable con la información de las Tarifas.</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static DataTable Concentrado(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                int Rango = Neg_Parametros.P_Anio_Final - Neg_Parametros.P_Anio_Inicio + 1;

                Mi_Sql.Append("select ");
	            Mi_Sql.Append("    'Recaudación' Tipo,");

                for (int i = 0; i < Rango; i++)
                {
                    Mi_Sql.Append("    sum(Total * (1 - sign(abs(" +
                        (Neg_Parametros.P_Anio_Inicio + i) + " - Anio)))) '" +
                        (Neg_Parametros.P_Anio_Inicio + i) + "',");
                }

                // Se quita la última coma ',' de la sentencia SELECT.
                Mi_Sql.Replace(",", " ", Mi_Sql.Length - 1, 1);

                Mi_Sql.Append("from (");
	            Mi_Sql.Append("    select");
		        Mi_Sql.Append("        year(v.Fecha_Creo) Anio,");
		        Mi_Sql.Append("        sum(vd.Total) Total");
	            Mi_Sql.Append("    from");
		        Mi_Sql.Append("        ope_ventas_detalles vd");
                Mi_Sql.Append("        join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID");

                Mi_Sql.Append("        join (select distinct pp.No_Caja, pp.No_Venta, pp.Museo_ID from ope_pagos pp");
                Mi_Sql.Append("             where pp.Fecha_Creo between @FechaIni and @FechaFin) p on p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID");
                Mi_Sql.Append("        join ope_cajas oc on oc.No_Caja = p.No_Caja");
                Mi_Sql.Append("        join ope_turnos ot on ot.No_Turno = oc.No_Turno");
                
                Mi_Sql.Append("    where");
		        Mi_Sql.Append("        v.Fecha_Creo between @FechaIni and @FechaFin");
                Mi_Sql.Append("        and v.Estatus = 'PAGADO'");

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Museo_ID))
                {
                    Mi_Sql.Append("        and v.Museo_ID = '" + Neg_Parametros.P_Museo_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                {
                    Mi_Sql.Append("        and vd.Producto_ID = '" + Neg_Parametros.P_Tarifa_Id + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                {
                    Mi_Sql.Append("        and ot.Turno_ID = '" + Neg_Parametros.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                {
                    Mi_Sql.Append("        and oc.Caja_ID = '" + Neg_Parametros.P_No_Caja + "' ");
                }
                
                Mi_Sql.Append("    group by");
		        Mi_Sql.Append("        year(Fecha_Creo)");
	            Mi_Sql.Append("    ) T1 ");
                Mi_Sql.Append("union ");
                Mi_Sql.Append("select");
	            Mi_Sql.Append("    'Visitantes',");

                for (int i = 0; i < Rango; i++)
                {
                    Mi_Sql.Append("    sum(Cantidad * (1 - sign(abs(" +
                        (Neg_Parametros.P_Anio_Inicio + i) + " - Anio)))) '" +
                        (Neg_Parametros.P_Anio_Inicio + i) + "',");
                }

                // Se quita la última coma ',' de la sentencia SELECT.
                Mi_Sql.Replace(",", " ", Mi_Sql.Length - 1, 1);

                Mi_Sql.Append("from (");
	            Mi_Sql.Append("    select");
		        Mi_Sql.Append("        year(v.Fecha_Creo) Anio,");
		        Mi_Sql.Append("        sum(Cantidad) Cantidad");
	            Mi_Sql.Append("    from");
		        Mi_Sql.Append("        ope_ventas_detalles vd");
		        Mi_Sql.Append("        join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID");

                Mi_Sql.Append("        join (select distinct pp.No_Caja, pp.No_Venta, pp.Museo_ID from ope_pagos pp");
                Mi_Sql.Append("             where pp.Fecha_Creo between @FechaIni and @FechaFin) p on p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID");
                Mi_Sql.Append("        join ope_cajas oc on oc.No_Caja = p.No_Caja");
                Mi_Sql.Append("        join ope_turnos ot on ot.No_Turno = oc.No_Turno");
                
                Mi_Sql.Append("    where");
                Mi_Sql.Append("        v.Fecha_Creo between @FechaIni and @FechaFin");
                Mi_Sql.Append("        and v.Estatus = 'PAGADO'");

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Museo_ID))
                {
                    Mi_Sql.Append("        and v.Museo_ID = '" + Neg_Parametros.P_Museo_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                {
                    Mi_Sql.Append("        and vd.Producto_ID = '" + Neg_Parametros.P_Tarifa_Id + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                {
                    Mi_Sql.Append("        and ot.Turno_ID = '" + Neg_Parametros.P_Turno_ID + "' ");
                }

                if (!string.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                {
                    Mi_Sql.Append("        and oc.Caja_ID = '" + Neg_Parametros.P_No_Caja + "' ");
                }
                
	            Mi_Sql.Append("    group by");
                Mi_Sql.Append("        year(v.Fecha_Creo)");
                Mi_Sql.Append(") T1");

                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_Sql.ToString();
                    Cmd.Parameters.AddWithValue("@FechaIni", new DateTime(Neg_Parametros.P_Anio_Inicio, 1, 1));
                    Cmd.Parameters.AddWithValue("@FechaFin", new DateTime(Neg_Parametros.P_Anio_Final, 12, 31));

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter(Cmd))
                    {
                        DataTable Resultados = new DataTable();
                        Adap.Fill(Resultados);

                        return Resultados;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los años mínimo y máximo de pagos en la base de datos
        /// </summary>
        /// <returns>datatable con los accesos encontrados para el rango de años seleccionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Rango_Pagos()
        {
            string Mi_SQL;
            DataTable Dt_Ingresos = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {
                // formar la consulta
                Mi_SQL = "SELECT min(" + Ope_Pagos.Campo_Fecha_Creo + ") minimo, max(" + Ope_Pagos.Campo_Fecha_Creo
                    + ") maximo FROM " + Ope_Pagos.Tabla_Ope_Pagos
                    + " WHERE " + Ope_Pagos.Campo_Estatus + "= 'PAGADO'";

                // ejecutar consulta
                Dt_Ingresos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Rango] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Ingresos;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los ingresos agrupados por mes, año y tarifa, con filtros 
        /// opcionales de rango de fechas
        /// </summary>
        /// <param name="Datos">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los ingresos encontrados para el rango de fechas seleccionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Ingresos_Mensual_Tarifa(Cls_Rep_Ingresos_Negocio Datos)
        {
            
            StringBuilder Mi_Sql = new StringBuilder();
            DataTable Dt_Ingresos = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            
            try
            {
                // formar la consulta
                Mi_Sql.Append( "SELECT YEAR (venta." + Ope_Pagos.Campo_Fecha_Creo + ") anio"
                    + ", MONTH(venta." + Ope_Pagos.Campo_Fecha_Creo + ") mes"
                    + ", sum(v." + Ope_Ventas_Detalles.Campo_Total + ") monto_pago");

                if (!string.IsNullOrEmpty(Datos.P_Forma_ID))
                {
                    Mi_Sql.Append(", p.forma_id");
                }

                Mi_Sql.Append(", (SELECT " + Cat_Productos.Campo_Nombre + " FROM "
                    + Cat_Productos.Tabla_Cat_Productos + " WHERE " + Cat_Productos.Campo_Producto_Id
                    + "=v." + Ope_Ventas_Detalles.Campo_Producto_Id + ") tarifa");

                //  from *******************************************************************************
                Mi_Sql.Append(" FROM " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " v ");
                //  *join *******************************************************************************
                Mi_Sql.Append( " left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " venta on  venta." + Ope_Ventas.Campo_No_Venta + "= v." + Ope_Ventas_Detalles.Campo_No_Venta + " and venta.Museo_ID = v.Museo_ID");
                //  *join *******************************************************************************
                Mi_Sql.Append(" left outer join (select   DISTINCT No_Venta, No_Caja, Museo_ID, Estatus, Forma_ID FROM ope_pagos p");
                Mi_Sql.Append(" where YEAR(p." + Ope_Pagos.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ") ");
                Mi_Sql.Append(" and MONTH(p." + Ope_Pagos.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")");
                //  filtro para el numero de venta pago mixto
                if (!String.IsNullOrEmpty(Datos.P_No_Venta_Mixto))
                {
                    Mi_Sql.Append(" and p.no_venta not in(" + Datos.P_No_Venta_Mixto + ")");
                }
                Mi_Sql.Append(")");
                Mi_Sql.Append(" p on p." + Ope_Pagos.Campo_No_Venta + " = venta." + Ope_Ventas.Campo_No_Venta + " and p.Museo_ID = venta.Museo_ID");

                //  where *************************************************************************************
                Mi_Sql.Append( " WHERE venta.Estatus IN ('PAGADO')");
                Mi_Sql.Append(" AND venta.Persona_Tramita IS NULL ");


                //  filtro para el numero de venta pago mixto
                if (!String.IsNullOrEmpty(Datos.P_No_Venta_Mixto))
                {
                    Mi_Sql.Append(" and p.no_venta not in(" + Datos.P_No_Venta_Mixto + ")");
                }


                // si hay una tarifa seleccionada, asignar para el filtro
                if (!string.IsNullOrEmpty(Datos.P_Tarifa_Id))
                {
                    Mi_Sql.Append( " AND v." + Ope_Ventas_Detalles.Campo_Producto_Id + " in (" + Datos.P_Tarifa_Id + ")");
                }
                

                //  años a consultar
                if (!String.IsNullOrEmpty(Datos.P_Anios_Busqueda))
                {
                    Mi_Sql.Append(" and YEAR(VENTA." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ")");
                }

                //  meses a consultar
                if (!String.IsNullOrEmpty(Datos.P_Meses_Busqueda))
                {
                    Mi_Sql.Append(" and MONTH(VENTA." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")");
                }

                //// si se proporcionan fechas agregar a la consulta
                //if (Neg_Parametros.P_Fecha_Inicio != DateTime.MinValue)
                //{
                //    Mi_SQL += " AND  cast(venta." + Ope_Ventas.Campo_Fecha_Creo + " as date)>=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Inicio);
                //}
                //if (Neg_Parametros.P_Fecha_Final != DateTime.MinValue)
                //{
                //    Mi_SQL += " AND cast(venta." + Ope_Ventas.Campo_Fecha_Creo + " as date)<=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Final); ;
                //}

                // Se valida si se seleccionó un Turno.
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_Sql.Append(" AND (SELECT Turno_ID FROM Ope_Turnos t WHERE t.No_Turno = ");
                    Mi_Sql.Append("(SELECT No_Turno FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja)) = ");
                    Mi_Sql.Append("'" + Datos.P_Turno_ID + "'");
                }

                // Se valida si se seleccionó una Caja.
                if (!string.IsNullOrEmpty(Datos.P_Numero_Caja))
                {
                    Mi_Sql.Append( " AND (SELECT Caja_ID FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja) = ");
                    Mi_Sql.Append("'" + Datos.P_Numero_Caja + "'");
                }

                if (!string.IsNullOrEmpty(Datos.P_Forma_ID))
                {
                    Mi_Sql.Append( " AND p.Forma_ID = '" + Datos.P_Forma_ID + "'");
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_Sql.Append(" and venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                }

                // agrupar por año, mes y producto*******************************
                Mi_Sql.Append(" GROUP BY YEAR(venta." + Ope_Ventas.Campo_Fecha_Creo + "), MONTH(venta." + Ope_Ventas.Campo_Fecha_Creo
                    + "), v." + Ope_Ventas_Detalles.Campo_Producto_Id);

                if (!string.IsNullOrEmpty(Datos.P_Forma_ID))
                {
                    Mi_Sql.Append(", p.forma_id");
                }
                


                // ejecutar consulta
                Dt_Ingresos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Ingresos_Mensual] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Ingresos;
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
        public static DataTable Consultar_Ventas_Dia_Mixtas(Cls_Rep_Ingresos_Negocio Datos)
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

                Mi_SQL.Append("select ope_pagos.No_Venta " +
                    ", year(ope_pagos.fecha_creo) as Año " +
                    ", month(ope_pagos.fecha_creo) as Mes " +
                    " from ope_ventas join ope_pagos on ope_pagos.No_Venta = ope_ventas.No_Venta");

                //  años a consultar
                if (!String.IsNullOrEmpty(Datos.P_Anios_Busqueda))
                {
                    Mi_SQL.Append(" and YEAR(ope_ventas." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ")");
                }

                //  meses a consultar
                if (!String.IsNullOrEmpty(Datos.P_Meses_Busqueda))
                {
                    Mi_SQL.Append(" and MONTH(ope_ventas." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")");
                }


                Mi_SQL.Append(" group by ope_pagos.No_Venta " +
                        ", ope_pagos.fecha_creo " +
                        " having count(*) > 1");

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
        public static DataTable Consultar_No_Venta_Detalle(Cls_Rep_Ingresos_Negocio Datos)
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

                Mi_SQL.Append("select vd.Producto_Id, p.nombre , vd.total " +
                                " , year(vd.fecha_creo) as año, month(vd.fecha_creo) as mes" +
                                " from ope_ventas_detalles vd " +
                                " join cat_productos p on p.producto_id	= vd.producto_id " +
                                " where vd.No_Venta = '" + Datos.P_No_Venta_Detalle + "'");


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
        public static DataTable Consultar_No_Venta_Detalle_Pago(Cls_Rep_Ingresos_Negocio Datos)
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

                Mi_SQL.Append("select year(p.fecha_creo) as año" +
                                    ", month(p.fecha_creo) as mes " +
                                    ", ifnull((select Monto_Pago from ope_pagos ps where ps.No_Venta = '" + Datos.P_No_Venta_Detalle + "' and ps.Forma_ID= '00001' and Monto_Pago > 0), 0) as Efectivo " +
                                    ", ifnull((select Monto_Pago from ope_pagos ps where ps.No_Venta = '" + Datos.P_No_Venta_Detalle + "' and ps.Forma_ID= '00003' and Monto_Pago > 0), 0) as Tarjeta " +
                                " from ope_pagos p " +
                                " where No_Venta = '" + Datos.P_No_Venta_Detalle + "'" +
                                " group by fecha_creo");


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



        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los ingresos agrupados por mes, año y tarifa, con filtros 
        /// opcionales de rango de fechas
        /// </summary>
        /// <param name="Datos">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los ingresos encontrados para el rango de fechas seleccionado</returns>
        /// <creo>Hugo Enrique Ramírez Aguilera</creo>
        /// <fecha_creo>14-Enero-2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Ingresos_Accesos_Mensual(Cls_Rep_Ingresos_Negocio Datos)
        {

            StringBuilder Mi_Sql = new StringBuilder();
            DataTable Dt_Ingresos = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            try
            {
                #region Ingresos
                // formar la consulta
                Mi_Sql.Append("SELECT YEAR (venta." + Ope_Pagos.Campo_Fecha_Creo + ") anio_"
                    + ", MONTH(venta." + Ope_Pagos.Campo_Fecha_Creo + ") mes"
                    + ", sum(v." + Ope_Ventas_Detalles.Campo_Total + ") Recaudacion_Visitantes");

                Mi_Sql.Append(",'Recaudacion' as Tipo");

                //  from *******************************************************************************
                Mi_Sql.Append(" FROM " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + " v ");
                Mi_Sql.Append(" left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " venta on  venta." + Ope_Ventas.Campo_No_Venta + "= v." + Ope_Ventas_Detalles.Campo_No_Venta + " and venta.Museo_ID = v.Museo_ID");
                //  *join *******************************************************************************
                Mi_Sql.Append(" left outer join (select   DISTINCT No_Venta, No_Caja, Museo_ID, Estatus, Forma_ID FROM ope_pagos p");
                Mi_Sql.Append(" where YEAR(p." + Ope_Pagos.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ") ");
                Mi_Sql.Append(" and MONTH(p." + Ope_Pagos.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")");
                if (!String.IsNullOrEmpty(Datos.P_No_Venta_Mixto))
                {
                    Mi_Sql.Append(" and p.no_venta not in(" + Datos.P_No_Venta_Mixto + ")");
                }
                Mi_Sql.Append(")");
                Mi_Sql.Append(" p on p." + Ope_Pagos.Campo_No_Venta + " = venta." + Ope_Ventas.Campo_No_Venta + " and p.Museo_ID = venta.Museo_ID");

                //  where *************************************************************************************
                Mi_Sql.Append(" WHERE  venta.Estatus IN ('PAGADO')");
                Mi_Sql.Append(" AND venta.Persona_Tramita IS NULL ");


                if (!String.IsNullOrEmpty(Datos.P_No_Venta_Mixto))
                {
                    Mi_Sql.Append(" and p.no_venta not in(" + Datos.P_No_Venta_Mixto + ")");
                }

                // si hay una tarifa seleccionada, asignar para el filtro
                if (!string.IsNullOrEmpty(Datos.P_Tarifa_Id))
                {
                    Mi_Sql.Append(" AND v." + Ope_Ventas_Detalles.Campo_Producto_Id + " in (" + Datos.P_Tarifa_Id + ")");
                }


                //  años a consultar
                if (!String.IsNullOrEmpty(Datos.P_Anios_Busqueda))
                {
                    Mi_Sql.Append(" and YEAR(VENTA." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ")");
                }

                //  meses a consultar
                if (!String.IsNullOrEmpty(Datos.P_Meses_Busqueda))
                {
                    Mi_Sql.Append(" and MONTH(VENTA." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")");
                }

                // Se valida si se seleccionó un Turno.
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_Sql.Append(" AND (SELECT Turno_ID FROM Ope_Turnos t WHERE t.No_Turno = ");
                    Mi_Sql.Append("(SELECT No_Turno FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja)) = ");
                    Mi_Sql.Append("'" + Datos.P_Turno_ID + "'");
                }

                // Se valida si se seleccionó una Caja.
                if (!string.IsNullOrEmpty(Datos.P_Numero_Caja))
                {
                    Mi_Sql.Append(" AND (SELECT Caja_ID FROM Ope_Cajas c WHERE c.No_Caja = p.No_Caja) = ");
                    Mi_Sql.Append("'" + Datos.P_Numero_Caja + "'");
                }

                if (!string.IsNullOrEmpty(Datos.P_Forma_ID))
                {
                    Mi_Sql.Append(" AND p.Forma_ID = '" + Datos.P_Forma_ID + "'");
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_Sql.Append(" and venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                }

                // agrupar por año, mes y producto*******************************
                Mi_Sql.Append(" GROUP BY YEAR(venta." + Ope_Ventas.Campo_Fecha_Creo + "), MONTH(venta." + Ope_Ventas.Campo_Fecha_Creo + ")");

                #endregion Ingresos

                //  ******************************************************************************************************************
                Mi_Sql.Append(" Union all ");

                #region Visitantes

                Mi_Sql.Append("select  YEAR( " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " ) anio_ ");
                Mi_Sql.Append(", MONTH( " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " ) mes ");
                Mi_Sql.Append(", sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad + ") Recaudacion_Visitantes");
                Mi_Sql.Append(", 'Visitantes' as Tipo");

                //  seccion from
                Mi_Sql.Append(" From " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles);
                Mi_Sql.Append(" left outer join " + Cat_Productos.Tabla_Cat_Productos + " on " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Producto_Id + "="
                       + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id);
                Mi_Sql.Append(" left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + "="
                       + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta);
                Mi_Sql.Append(" and Ope_Ventas.Museo_ID = Ope_Ventas_Detalles.Museo_ID ");


                //  where  ***********************************************************************************
                // si se proporcionan fechas agregar a la consulta
                Mi_Sql.Append(" where Ope_Ventas.Estatus IN ('PAGADO')");
                Mi_Sql.Append(" AND Ope_Ventas.Persona_Tramita IS NULL ");

                //  años a consultar
                if (!String.IsNullOrEmpty(Datos.P_Anios_Busqueda))
                {
                    Mi_Sql.Append(" and YEAR(" + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ")");
                }

                //  meses a consultar
                if (!String.IsNullOrEmpty(Datos.P_Meses_Busqueda))
                {
                    Mi_Sql.Append(" and MONTH(" + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")");
                }


                // Se valida si se seleccionó un Número de Caja.
                if (!string.IsNullOrEmpty(Datos.P_Numero_Caja))
                {
                    Mi_Sql.Append(" AND (SELECT Caja_ID FROM Ope_Cajas C WHERE C.No_Caja = ");
                    Mi_Sql.Append("(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + ".No_Venta limit 1) limit 1) = ");
                    Mi_Sql.Append("'" + Datos.P_Numero_Caja + "'");
                }

                // Se valida si se seleccionó un Turno.
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_Sql.Append(" AND (SELECT Turno_ID FROM Ope_Turnos T WHERE T.No_Turno = ");
                    Mi_Sql.Append("(SELECT No_turno FROM Ope_Cajas C WHERE C.No_Caja = ");
                    Mi_Sql.Append("(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + ".No_Venta");
                    Mi_Sql.Append(" and p.Museo_ID = Ope_Ventas_Detalles.Museo_ID))) = ");
                    Mi_Sql.Append("'" + Datos.P_Turno_ID + "'");
                }

                // Se valida si se seleccionó una Forma de Pago.
                if (!string.IsNullOrEmpty(Datos.P_Forma_ID))
                {
                    Mi_Sql.Append(" AND (SELECT Forma_ID FROM Ope_Pagos P WHERE P.No_Venta =" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + ".No_Venta limit 1) = ");
                    Mi_Sql.Append("'" + Datos.P_Forma_ID + "'");
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_Sql.Append(" and ");
                    Mi_Sql.Append(Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'");
                }

                // si hay una tarifa seleccionada, asignar para el filtro
                if (!string.IsNullOrEmpty(Datos.P_Tarifa_Id))
                {
                    Mi_Sql.Append(" AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + " in (" + Datos.P_Tarifa_Id + ")");
                }

                #endregion

                //  seccion group by
                Mi_Sql.Append(" GROUP BY YEAR(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")");
                Mi_Sql.Append(" , MONTH(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")");

                // ejecutar consulta
                Dt_Ingresos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Ingresos_Mensual] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Ingresos;
        }



        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los accesos agrupados por año, mes y tarifa (producto), con filtros 
        /// opcionales de rango de fechas
        /// </summary>
        /// <param name="Datos">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los accesos encontrados para el rango de fechas proporcionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Accesos_Mensual_Tarifa(Cls_Rep_Ingresos_Negocio Datos)
        {
            String Mi_SQL = "";
            DataTable Dt_Accesos = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {
                #region Visitantes

                Mi_SQL = "select  YEAR( " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " ) anio ";
                Mi_SQL += ", MONTH( " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " ) mes ";
                Mi_SQL += ", sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad + ") accesos";
                Mi_SQL += ", " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Nombre + " as tarifa";

                //  seccion from
                Mi_SQL += " From " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles;
                Mi_SQL += " left outer join " + Cat_Productos.Tabla_Cat_Productos + " on " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Producto_Id + "="
                        + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id;
                Mi_SQL += " left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + "="
                        + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta;
                Mi_SQL += " and Ope_Ventas.Museo_ID = Ope_Ventas_Detalles.Museo_ID ";
                Mi_SQL += " left outer join ope_pagos p on p.no_venta = Ope_Ventas.no_venta";

                //  where  ***********************************************************************************
                // si se proporcionan fechas agregar a la consulta
                
                Mi_SQL += " where Ope_Ventas.Estatus IN ('PAGADO')";
                Mi_SQL += " AND Ope_Ventas.Persona_Tramita IS NULL ";

                //  años a consultar
                if (!String.IsNullOrEmpty(Datos.P_Anios_Busqueda))
                {
                    Mi_SQL += " and YEAR(" + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ")";
                }

                //  meses a consultar
                if (!String.IsNullOrEmpty(Datos.P_Meses_Busqueda))
                {
                    Mi_SQL += " and MONTH(" + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")";
                }


                // Se valida si se seleccionó un Número de Caja.
                if (!string.IsNullOrEmpty(Datos.P_Numero_Caja))
                {
                    Mi_SQL += " AND (SELECT Caja_ID FROM Ope_Cajas C WHERE C.No_Caja = ";
                    Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + ".No_Venta limit 1) limit 1) = ";
                    Mi_SQL += "'" + Datos.P_Numero_Caja + "'";
                }

                // Se valida si se seleccionó un Turno.
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL += " AND (SELECT Turno_ID FROM Ope_Turnos T WHERE T.No_Turno = ";
                    Mi_SQL += "(SELECT No_turno FROM Ope_Cajas C WHERE C.No_Caja = ";
                    Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + ".No_Venta";
                    Mi_SQL += " and p.Museo_ID = Ope_Ventas_Detalles.Museo_ID))) = ";
                    Mi_SQL += "'" + Datos.P_Turno_ID + "'";
                }

                // Se valida si se seleccionó una Forma de Pago.
                if (!string.IsNullOrEmpty(Datos.P_Forma_ID))
                {
                    //Mi_SQL += " AND (SELECT Forma_ID FROM Ope_Pagos P WHERE P.No_Venta =" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + ".No_Venta) = ";
                    //Mi_SQL += "'" + Datos.P_Forma_ID + "'";

                    Mi_SQL += " AND  p.Forma_ID  = '" + Datos.P_Forma_ID + "'";
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL += " and ";
                    Mi_SQL += Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'";
                }

                // si hay una tarifa seleccionada, asignar para el filtro
                if (!string.IsNullOrEmpty(Datos.P_Tarifa_Id))
                {
                    Mi_SQL += " AND " + Ope_Ventas_Detalles .Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + " in (" + Datos.P_Tarifa_Id + ")";
                }
                

                //  seccion group by
                Mi_SQL += " GROUP BY YEAR(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")";
                Mi_SQL += " , MONTH(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ")";
                Mi_SQL += " , " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Nombre + "";

                #endregion

                // ejecutar consulta
                Dt_Accesos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Accesos_Mensual] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Accesos;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los accesos agrupados por año, mes y tarifa (producto), con filtros 
        /// opcionales de rango de fechas
        /// </summary>
        /// <param name="Datos">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los accesos encontrados para el rango de fechas proporcionado</returns>
        /// <creo>Hugo Enrique Ramírez Aguilera</creo>
        /// <fecha_creo>31-mar-2015</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Accesos_Promedio_Tarifa(Cls_Rep_Ingresos_Negocio Datos)
        {
            string Mi_SQL;
            DataTable Dt_Accesos = null;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {
                // formar la consulta
                Mi_SQL = "SELECT " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id;
                Mi_SQL += ", " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Nombre + " as tarifa";
                //Mi_SQL += ", DATE_FORMAT(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + ",'%Y-%m-%d') as Fecha";
                Mi_SQL += ", sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad+ ") as Contador";
                Mi_SQL += ", DAY(LAST_DAY(venta.Fecha_Creo)) AS Ultimo_Dia";
                Mi_SQL += ", SUM(Ope_Ventas_Detalles.Cantidad) / DAY(LAST_DAY(venta.Fecha_Creo)) AS Promedio";
                Mi_SQL += ", year(venta.Fecha_Creo) As Anio ";
                Mi_SQL += ", month(venta.Fecha_Creo) As Mes";


                //  seccion from
                Mi_SQL += " from " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles;
                Mi_SQL += " left outer join " + Cat_Productos.Tabla_Cat_Productos + " on " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Producto_Id +
                        " = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id;

                Mi_SQL += " left outer join " + Ope_Ventas.Tabla_Ope_Ventas + " venta on venta." + Ope_Ventas.Campo_No_Venta + " = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta;

                Mi_SQL += " and venta.Museo_ID = " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + ".Museo_ID ";

                //  seccion where
                Mi_SQL += " where venta." + Ope_Ventas.Campo_Estatus + " = 'PAGADO'";


                // si hay una tarifa seleccionada, asignar para el filtro
                if (!string.IsNullOrEmpty(Datos.P_Tarifa_Id))
                {
                    Mi_SQL += " AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + " in (" + Datos.P_Tarifa_Id + ")";
                }

                //  años a consultar
                if (!String.IsNullOrEmpty(Datos.P_Anios_Busqueda))
                {
                    Mi_SQL += " and YEAR(venta." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Anios_Busqueda + ")";
                }

                //  meses a consultar
                if (!String.IsNullOrEmpty(Datos.P_Meses_Busqueda))
                {
                    Mi_SQL += " and MONTH(venta." + Ope_Ventas.Campo_Fecha_Creo + ") in (" + Datos.P_Meses_Busqueda + ")";
                }

                // Se valida si se seleccionó un Número de Caja.
                if (!string.IsNullOrEmpty(Datos.P_Numero_Caja))
                {
                    Mi_SQL += " AND (SELECT Caja_ID FROM Ope_Cajas C WHERE C.No_Caja = ";

                    Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = venta.No_Venta and p.Museo_ID = venta.Museo_ID)) = ";

                    //Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = venta.No_Venta) = ";

                    Mi_SQL += "'" + Datos.P_Numero_Caja + "'";
                }

                // Se valida si se seleccionó un Turno.
                if (!string.IsNullOrEmpty(Datos.P_Turno_ID))
                {
                    Mi_SQL += " AND (SELECT Turno_ID FROM Ope_Turnos T WHERE T.No_Turno = ";
                    Mi_SQL += "(SELECT No_turno FROM Ope_Cajas C WHERE C.No_Caja = ";

                    Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = venta.No_Venta and p.Museo_ID = venta.Museo_ID))) = ";

                    //Mi_SQL += "(SELECT p.No_Caja FROM Ope_Pagos p WHERE p.No_Venta = venta.No_Venta) = ";

                    Mi_SQL += "'" + Datos.P_Turno_ID + "'";
                }

                // Se valida si se seleccionó una Forma de Pago.
                if (!string.IsNullOrEmpty(Datos.P_Forma_ID))
                {

                    Mi_SQL += " AND (SELECT Forma_ID FROM Ope_Pagos P WHERE P.No_Venta = venta.No_Venta and p.Museo_ID = venta.Museo_ID) ";

                    Mi_SQL += " = (SELECT Forma_ID FROM Ope_Pagos P WHERE P.No_Venta = venta.No_Venta) = ";

                    Mi_SQL += "'" + Datos.P_Forma_ID + "'";
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Datos.P_Lugar_Venta))
                {
                    Mi_SQL += " and ";
                    Mi_SQL += " venta." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Datos.P_Lugar_Venta + "'";
                }

                // agrupar por año, mes y producto ****************************************
                Mi_SQL += " GROUP BY " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles+ "." + Ope_Ventas_Detalles.Campo_Producto_Id +
                        ", " + Cat_Productos.Tabla_Cat_Productos + "." + Cat_Productos.Campo_Nombre +
                        ", year(" +  "venta." + Ope_Ventas.Campo_Fecha_Creo + ")" +
                        ", MONTH(" + "venta." + Ope_Ventas.Campo_Fecha_Creo + ")";

                // ejecutar consulta
                Dt_Accesos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consultar_Accesos_Promedio_Tarifa] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Accesos;
        }


        ///*******************************************************************************************************
        /// <summary>
        /// Se ejecuta el SP que consulta la información de las Tarifas por Columna.
        /// </summary>
        /// <param name="Neg_Parametros">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los ingresos encontrados para el rango de fechas proporcionadas</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Ingresos_Diarios(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            DataTable Dt_Ingresos = new DataTable();

            try
            {
                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    string Lugar_Venta = Neg_Parametros.P_Lugar_Venta == string.Empty ? null : Neg_Parametros.P_Lugar_Venta;
                    if (Lugar_Venta == "No. caja") Lugar_Venta = "No Caja";

                    Cmd.Connection = Con;
                    Cmd.CommandText = "Diario_Recaudacion";
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@Fecha_Ini", Neg_Parametros.P_Fecha_Inicio.Date);
                    Cmd.Parameters.AddWithValue("@Fecha_Fin", Neg_Parametros.P_Fecha_Final.Date);
                    Cmd.Parameters.AddWithValue("@Caja_ID", Neg_Parametros.P_No_Caja);
                    Cmd.Parameters.AddWithValue("@Turno_ID", Neg_Parametros.P_Turno);
                    Cmd.Parameters.AddWithValue("@Lugar_Venta", Lugar_Venta);
                    Cmd.Parameters.AddWithValue("@Producto_ID", Neg_Parametros.P_Tarifa_Id);

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter())
                    {
                        Adap.SelectCommand = Cmd;
                        Adap.Fill(Dt_Ingresos);

                        return Dt_Ingresos;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Ingresos_Diarios] " + Ex.Message, Ex);
            }
        }

        /// <summary>
        /// Se consulta la información para el Reporte de Crystal.
        /// </summary>
        /// <param name="Neg_Parametros"></param>
        /// <returns></returns>
        public static DataTable Consultar_Ingresos_Diarios_Crystal(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            DataTable Dt_Ingresos = new DataTable();

            try
            {
                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Mi_SQL.Append("select");
                    Mi_SQL.Append("    cast(vd.Fecha_Creo as date) Fecha,");
                    Mi_SQL.Append("    p.Nombre Producto,");
                    Mi_SQL.Append("    sum(vd.Total) Total ");
                    Mi_SQL.Append("from");
                    Mi_SQL.Append("    ope_ventas_detalles vd ");
			        Mi_SQL.Append("    join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID");
			        Mi_SQL.Append("    join (select distinct No_Caja, No_Venta, Museo_ID from ope_pagos where");
                    Mi_SQL.Append("        Fecha_Creo between @FechaIni and @FechaFin) p");
			        Mi_SQL.Append("    on v.No_Venta = p.No_Venta and v.Museo_ID = p.Museo_ID"); 
			        Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = p.No_Caja");
                    Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno");
                    Mi_SQL.Append("    join cat_productos p on p.Producto_Id = vd.Producto_ID ");
                    Mi_SQL.Append("where ");
                    Mi_SQL.Append("    v.Fecha_Creo between @FechaIni and @FechaFin ");
                    Mi_SQL.Append("    and v.Estatus = 'PAGADO' ");

                    if (!string.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                    {
                        Mi_SQL.Append("    and oc.Caja_ID = '" + Neg_Parametros.P_No_Caja + "' ");
                    }

                    if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno))
                    {
                        Mi_SQL.Append("    and ot.Turno_ID = '" + Neg_Parametros.P_Turno + "' ");
                    }

                    if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                    {
                        if (Neg_Parametros.P_Lugar_Venta.Equals("Internet"))
                        {
                            Mi_SQL.Append("and (select Forma_ID from ope_pagos p where ");
                            Mi_SQL.Append("p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID limit 1) = '00005' ");
                        }
                        else
                        {
                            if (Neg_Parametros.P_Lugar_Venta == "No. caja") Neg_Parametros.P_Lugar_Venta = "No Caja";
                            Mi_SQL.Append("and v.Lugar_Venta = '" + Neg_Parametros.P_Lugar_Venta + "' ");
                        }
                    }

                    Mi_SQL.Append("group by");
                    Mi_SQL.Append("    to_days(vd.Fecha_Creo),");
                    Mi_SQL.Append("    vd.Producto_ID ");
                    Mi_SQL.Append("order by ");
                    Mi_SQL.Append("    vd.Producto_ID;");

                    Dt_Ingresos.TableName = "Ingresos";
                    Dt_Ingresos.Columns.Add("Fecha", typeof(DateTime));
                    Dt_Ingresos.Columns.Add("Producto", typeof(string));
                    Dt_Ingresos.Columns.Add("Total", typeof(decimal));

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_SQL.ToString();
                    Cmd.Parameters.AddWithValue("@FechaIni", Neg_Parametros.P_Fecha_Inicio.Date);
                    Cmd.Parameters.AddWithValue("@FechaFin", Neg_Parametros.P_Fecha_Final.Date);

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter())
                    {
                        Adap.SelectCommand = Cmd;
                        Adap.Fill(Dt_Ingresos);

                        return Dt_Ingresos;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Ingresos_Diarios] " + Ex.Message, Ex);
            }
        }


         ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los accesos agrupados por día y tarifa (producto), con filtros 
        /// opcionales de rango de fechas
        /// </summary>
        /// <param name="Neg_Parametros">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los accesos encontrados para el rango de fechas proporcionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Accesos_Sin_Formato(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            string Mi_SQL;
            DataTable Dt_Accesos = new DataTable();
            
            try
            {
                #region Visitantes

                Mi_SQL = "SELECT cast(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " as date) fecha"
                    + ", sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad + ") Productos"
                    + ", (SELECT " + Cat_Productos.Campo_Nombre
                    + " FROM "
                    + Cat_Productos.Tabla_Cat_Productos + " WHERE " + Cat_Productos.Campo_Producto_Id
                    + "= " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + ") Total"
                    + ", " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id;

                //  seccion from
                Mi_SQL += " FROM " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles;

                Mi_SQL += " left outer join " + Ope_Ventas.Tabla_Ope_Ventas + "  on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + " =  "
                    + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta + " and Ope_Ventas.Museo_ID =  Ope_Ventas_Detalles.Museo_ID ";
                Mi_SQL += " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + "  on " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Venta + " = "
                    + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + " and Ope_Pagos.Museo_ID = Ope_Ventas.Museo_ID ";
                Mi_SQL += " left outer join " + Ope_Cajas.Tabla_Ope_Cajas + "  on " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja + " = " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Caja;
                Mi_SQL += " left outer join " + Ope_Turnos.Tabla_Ope_Turnos + "  on " + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_No_Turno + " = " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Turno;

                //  seccion where

                Mi_SQL += " where Ope_Ventas.Estatus IN ('PAGADO')";
                Mi_SQL += " AND Ope_Ventas.Persona_Tramita IS NULL";

                // si se proporcionan fechas agregar a la consulta
                if (Neg_Parametros.P_Fecha_Inicio != DateTime.MinValue)
                {
                    string aux_fech = Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Inicio);

                    aux_fech = aux_fech.Remove(aux_fech.LastIndexOf('\''));
                    Mi_SQL += " AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " >= " + aux_fech  + " 00:00:00' ";
                }
                if (Neg_Parametros.P_Fecha_Final != DateTime.MinValue)
                {
                    string aux_fech = Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Final);

                    aux_fech = aux_fech.Remove(aux_fech.LastIndexOf('\''));
                    Mi_SQL += " AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " <= " + aux_fech + " 23:59:59' ";
                }

                // si hay una tarifa seleccionada, asignar para el filtro
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                {
                    Mi_SQL += " AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + "='" + Neg_Parametros.P_Tarifa_Id + "'";
                }

                if (!String.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                {
                    Mi_SQL += " and " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Caja_ID + " = '" + Neg_Parametros.P_No_Caja + "'";
                }
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Turno))
                {
                    Mi_SQL += " and " + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_Turno_ID + " = '" + Neg_Parametros.P_Turno + "'";
                }
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                {
                    if (Neg_Parametros.P_Forma_ID == "00001")
                        Mi_SQL += " and " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID + " = '" + Neg_Parametros.P_Forma_ID + "'";
                    else
                        Mi_SQL += " and " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID + " != '00001'";
                }

                //  filtro para el lugar de la venta
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                {
                    Mi_SQL += " and " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Neg_Parametros.P_Lugar_Venta + "'";
                }

                // agrupar por día y producto

                Mi_SQL += " GROUP BY to_days(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + "), "
                    + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id;


                Mi_SQL += " order by fecha desc, Total asc";

                #endregion

                Dt_Accesos = new DataTable();
                Dt_Accesos.Columns.Add("fecha", typeof(DateTime));
                Dt_Accesos.Columns.Add("Productos", typeof(decimal));
                Dt_Accesos.Columns.Add("Total", typeof(string));
                Dt_Accesos.Columns.Add("Producto_ID", typeof(string));

                // ejecutar consulta
                new MySqlDataAdapter(Mi_SQL, new MySqlConnection(Cls_Constantes.Cadena_Conexion)).Fill(Dt_Accesos);
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Accesos_Diarios] " + Ex.Message, Ex);
            }
            
            return Dt_Accesos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable Consultar_Comparativo(Cls_Rep_Ingresos_Negocio Neg_Parametros, bool Anterior)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            DataTable Res = new DataTable();
            
            try
            {
                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Res.Columns.Add("Fecha", typeof(DateTime));
                    Res.Columns.Add("Producto_ID", typeof(string));
                    Res.Columns.Add("Producto", typeof(string));
                    Res.Columns.Add("Producto_Anterior", typeof(string));
                    Res.Columns.Add("Producto_Siguiente", typeof(string));
                    Res.Columns.Add("Visitantes", typeof(decimal));
                    Res.Columns.Add("Total", typeof(decimal));

                    Mi_SQL.Append("select");
                    Mi_SQL.Append("    cast(vd.Fecha_Creo as date) Fecha,");
                    Mi_SQL.Append("    p.Producto_ID,");
                    Mi_SQL.Append("    p.Nombre Producto,");
                    Mi_SQL.Append("    p.Relacion_Producto_ID Producto_Anterior,");
                    Mi_SQL.Append("    pp.Producto_ID Producto_Siguiente,");
                    Mi_SQL.Append("    sum(vd.Cantidad) Visitantes, ");
                    Mi_SQL.Append("    sum(vd.Total) Total ");
                    Mi_SQL.Append("from");
                    Mi_SQL.Append("    ope_ventas_detalles vd ");
                    Mi_SQL.Append("    join ope_ventas v on v.No_Venta = vd.No_Venta and v.Museo_ID = vd.Museo_ID");
                    Mi_SQL.Append("    join (select distinct No_Caja, No_Venta, Museo_ID from ope_pagos where");
                    Mi_SQL.Append("        Fecha_Creo between @FechaIni and @FechaFin) p");
                    Mi_SQL.Append("    on v.No_Venta = p.No_Venta and v.Museo_ID = p.Museo_ID");
                    Mi_SQL.Append("    join ope_cajas oc on oc.No_Caja = p.No_Caja");
                    Mi_SQL.Append("    join ope_turnos ot on ot.No_Turno = oc.No_Turno");
                    Mi_SQL.Append("    join cat_productos p on p.Producto_Id = vd.Producto_ID ");
                    Mi_SQL.Append("    left join cat_productos pp on pp.Relacion_Producto_ID = p.Producto_Id ");
                    Mi_SQL.Append("where ");
                    Mi_SQL.Append("    vd.Fecha_Creo between @FechaIni and @FechaFin ");
                    Mi_SQL.Append("    and v.Estatus = 'PAGADO' ");

                    if (!string.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                    {
                        Mi_SQL.Append("    and oc.Caja_ID = '" + Neg_Parametros.P_No_Caja + "' ");
                    }

                    if (!string.IsNullOrEmpty(Neg_Parametros.P_Turno))
                    {
                        Mi_SQL.Append("    and ot.Turno_ID = '" + Neg_Parametros.P_Turno + "' ");
                    }

                    if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                    {
                        if (Neg_Parametros.P_Lugar_Venta.Equals("Internet"))
                        {
                            Mi_SQL.Append("and (select Forma_ID from ope_pagos p where ");
                            Mi_SQL.Append("p.No_Venta = v.No_Venta and p.Museo_ID = v.Museo_ID limit 1) = '00005' ");
                        }
                        else
                        {
                            if (Neg_Parametros.P_Lugar_Venta == "No. caja") Neg_Parametros.P_Lugar_Venta = "No Caja";
                            Mi_SQL.Append("and v.Lugar_Venta = '" + Neg_Parametros.P_Lugar_Venta + "' ");
                        }
                    }

                    Mi_SQL.Append("group by");
                    Mi_SQL.Append("    to_days(vd.Fecha_Creo),");
                    Mi_SQL.Append("    vd.Producto_ID ");
                    Mi_SQL.Append("order by ");
                    Mi_SQL.Append("    vd.Producto_ID;");

                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_SQL.ToString();

                    if (!Anterior)
                    {
                        Cmd.Parameters.AddWithValue("@FechaIni", Neg_Parametros.P_Fecha_Inicio.Date);
                        Cmd.Parameters.AddWithValue("@FechaFin", new DateTime(Neg_Parametros.P_Fecha_Final.Year,
                                    Neg_Parametros.P_Fecha_Final.Month,
                                    Neg_Parametros.P_Fecha_Final.Day, 23, 59, 59));
                    }
                    else
                    {
                        Cmd.Parameters.AddWithValue("@FechaIni", Neg_Parametros.P_Fecha_Inicio.Date.AddYears(-1));
                        Cmd.Parameters.AddWithValue("@FechaFin", new DateTime(Neg_Parametros.P_Fecha_Final.Year - 1,
                                    Neg_Parametros.P_Fecha_Final.Month,
                                    Neg_Parametros.P_Fecha_Final.Day, 23, 59, 59));
                    }
                    
                    using (MySqlDataAdapter Adap = new MySqlDataAdapter())
                    {
                        Adap.SelectCommand = Cmd;
                        Adap.Fill(Res);

                        return Res;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los accesos agrupados por día y tarifa (producto), con filtros 
        /// opcionales de rango de fechas
        /// </summary>
        /// <param name="Neg_Parametros">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los accesos encontrados para el rango de fechas proporcionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Accesos_Diarios(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            string Mi_SQL;
            DataTable Dt_Accesos = new DataTable();
            DataSet Ds_Accesos = new DataSet();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            try
            {

                #region Accesos
                //// formar la consulta
                //Mi_SQL = "SELECT cast(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + " as date) fecha"
                //    + ", count(" + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Estatus + ") accesos"
                //    + ", (SELECT " + Cat_Productos.Campo_Nombre + " FROM "
                //    + Cat_Productos.Tabla_Cat_Productos + " WHERE " + Cat_Productos.Campo_Producto_Id
                //    + "= " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Producto_ID + ") tarifa"
                //    + " FROM " + Ope_Accesos.Tabla_Ope_Accesos;


                //Mi_SQL += " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + "  on " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Venta + " = " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_No_Venta;
                //Mi_SQL += " left outer join " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "  on " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta + " =  " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_No_Venta;
                //Mi_SQL += " left outer join " + Ope_Ventas.Tabla_Ope_Ventas + "  on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + " =  " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta;
                //Mi_SQL += " left outer join " + Ope_Cajas.Tabla_Ope_Cajas + "  on " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja + " = " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Caja;
                //Mi_SQL += " left outer join " + Ope_Turnos.Tabla_Ope_Turnos + "  on " + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_No_Turno + " = " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Turno;

                //Mi_SQL += " WHERE " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Estatus + "= 'UTILIZADO'";

                //// si hay una tarifa seleccionada, asignar para el filtro
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                //{
                //    Mi_SQL += " AND " + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Producto_ID + "='" + Neg_Parametros.P_Tarifa_Id + "'";
                //}

                //// si se proporcionan fechas agregar a la consulta
                //if (Neg_Parametros.P_Fecha_Inicio != DateTime.MinValue)
                //{
                //    Mi_SQL += " AND  cast(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + " as date)>=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Inicio);
                //}
                //if (Neg_Parametros.P_Fecha_Final != DateTime.MinValue)
                //{
                //    Mi_SQL += " AND cast(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + " as date)<=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Final); ;
                //}

                //if (!String.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                //{
                //    Mi_SQL += " and " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Caja_ID + " = '" + Neg_Parametros.P_No_Caja + "'";
                //}
                //if (!String.IsNullOrEmpty(Neg_Parametros.P_Turno))
                //{
                //    Mi_SQL += " and " + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_Turno_ID + " = '" + Neg_Parametros.P_Turno + "'";
                //}
                //if (!String.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                //{
                //    if (Neg_Parametros.P_Forma_ID == "00001")
                //        Mi_SQL += " and " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID + " = '" + Neg_Parametros.P_Forma_ID + "'";
                //    else
                //        Mi_SQL += " and " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID + " != '00001'";
                //}

                ////  filtro para el lugar de la venta
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                //{
                //    Mi_SQL += " and " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Neg_Parametros.P_Lugar_Venta + "'";
                //}

                //// agrupar por día y producto
                //Mi_SQL += " GROUP BY to_days(" + Ope_Accesos.Campo_Fecha_Hora_Acceso + "), "
                //    + Ope_Accesos.Tabla_Ope_Accesos + "." + Ope_Accesos.Campo_Producto_ID;

                #endregion


                #region Visitantes

                //Mi_SQL = "SELECT cast(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " as date) fecha"
                //    + ",cast( sum(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Cantidad + ") as SIGNED ) accesos"
                //    + ", (SELECT " + Cat_Productos.Campo_Nombre
                //    + " FROM "
                //    + Cat_Productos.Tabla_Cat_Productos + " WHERE " + Cat_Productos.Campo_Producto_Id
                //    + "= " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + ") tarifa"
                //    + ", " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id;
                
                ////  seccion from
                //Mi_SQL += " FROM " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles;

                //Mi_SQL += " left outer join " + Ope_Ventas.Tabla_Ope_Ventas + "  on " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + " =  "
                //    + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_No_Venta + " and Ope_Ventas.Museo_ID =  Ope_Ventas_Detalles.Museo_ID ";
                //Mi_SQL += " left outer join " + Ope_Pagos.Tabla_Ope_Pagos + "  on " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Venta + " = "
                //    + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_No_Venta + " and Ope_Pagos.Museo_ID = Ope_Ventas.Museo_ID ";
                //Mi_SQL += " left outer join " + Ope_Cajas.Tabla_Ope_Cajas + "  on " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Caja + " = " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_No_Caja;
                //Mi_SQL += " left outer join " + Ope_Turnos.Tabla_Ope_Turnos + "  on " + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_No_Turno + " = " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_No_Turno;

                ////  seccion where

                //Mi_SQL += " where Ope_Ventas.Estatus IN ('PAGADO')";
                //Mi_SQL += " AND Ope_Ventas.Persona_Tramita IS NULL";

                //// si se proporcionan fechas agregar a la consulta
                //if (Neg_Parametros.P_Fecha_Inicio != DateTime.MinValue)
                //{
                //    Mi_SQL += "  and " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " >=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Inicio);
                //}
                //if (Neg_Parametros.P_Fecha_Final != DateTime.MinValue)
                //{
                //    Mi_SQL += " AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + " <=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Parametros.P_Fecha_Final); ;
                //}

                //// si hay una tarifa seleccionada, asignar para el filtro
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                //{
                //    Mi_SQL += " AND " + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id + "='" + Neg_Parametros.P_Tarifa_Id + "'";
                //}

                //if (!String.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                //{
                //    Mi_SQL += " and " + Ope_Cajas.Tabla_Ope_Cajas + "." + Ope_Cajas.Campo_Caja_ID + " = '" + Neg_Parametros.P_No_Caja + "'";
                //}
                //if (!String.IsNullOrEmpty(Neg_Parametros.P_Turno))
                //{
                //    Mi_SQL += " and " + Ope_Turnos.Tabla_Ope_Turnos + "." + Ope_Turnos.Campo_Turno_ID + " = '" + Neg_Parametros.P_Turno + "'";
                //}
                //if (!String.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                //{
                //    if (Neg_Parametros.P_Forma_ID == "00001")
                //        Mi_SQL += " and " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID + " = '" + Neg_Parametros.P_Forma_ID + "'";
                //    else
                //        Mi_SQL += " and " + Ope_Pagos.Tabla_Ope_Pagos + "." + Ope_Pagos.Campo_Forma_ID + " != '00001'";
                //}

                ////  filtro para el lugar de la venta
                //if (!string.IsNullOrEmpty(Neg_Parametros.P_Lugar_Venta))
                //{
                //    Mi_SQL += " and " + Ope_Ventas.Tabla_Ope_Ventas + "." + Ope_Ventas.Campo_Lugar_Venta + " = '" + Neg_Parametros.P_Lugar_Venta + "'";
                //}

                //// agrupar por día y producto

                //Mi_SQL += " GROUP BY to_days(" + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Fecha_Creo + "), "
                //    + Ope_Ventas_Detalles.Tabla_Ope_Ventas_Detalles + "." + Ope_Ventas_Detalles.Campo_Producto_Id;


                //Mi_SQL += " order by fecha desc, tarifa asc";

                #endregion

                MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
                MySqlCommand Comando_Mysql = new MySqlCommand();

                //String StrConexion = "";
                //String[] Matriz_Conexion = new String[10];
                //Matriz_Conexion = Cls_Constantes.Cadena_Conexion.ToString().Split(';');

                //StrConexion += Matriz_Conexion[0] + ";";
                //StrConexion += Matriz_Conexion[1] + ";";
                //StrConexion += Matriz_Conexion[2] + ";";
                //StrConexion += Matriz_Conexion[3] + ";";

                Comando_Mysql = new MySqlCommand("Diario_Recaudacion_Visitantes", new MySqlConnection(Cls_Constantes.Cadena_Conexion.ToString()));
                
                Comando_Mysql.CommandType = CommandType.StoredProcedure;

                //  parametros
                Comando_Mysql.Parameters.AddWithValue("?Fecha_Ini", Neg_Parametros.P_Fecha_Inicio);
                Comando_Mysql.Parameters.AddWithValue("?Fecha_Fin", Neg_Parametros.P_Fecha_Final);

                //  caja
                if (!String.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                    Comando_Mysql.Parameters.AddWithValue("?Caja_ID", Neg_Parametros.P_No_Caja);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Caja_ID", null);

                // Forma de Pago.
                if (!string.IsNullOrEmpty(Neg_Parametros.P_Forma_ID))
                    Comando_Mysql.Parameters.AddWithValue("?Forma_Pago", Neg_Parametros.P_Forma_ID);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Forma_Pago", null);

                //  turno
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                    Comando_Mysql.Parameters.AddWithValue("?Turno_ID", Neg_Parametros.P_Turno_ID);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Turno_ID", null);

                //  lugar de la venta
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                    Comando_Mysql.Parameters.AddWithValue("?Lugar_Venta", Neg_Parametros.P_Lugar_Venta);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Lugar_Venta", null);

                //  lugar de la venta
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                    Comando_Mysql.Parameters.AddWithValue("?Tarifa_Id", Neg_Parametros.P_Tarifa_Id);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Tarifa_Id", null);


                Comando_Mysql.Connection.Open();

                Obj_Adaptador.SelectCommand = Comando_Mysql;
                Obj_Adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                Obj_Adaptador.Fill(Ds_Accesos);

                Comando_Mysql.Connection.Close();

                if (Ds_Accesos != null && Ds_Accesos.Tables.Count > 0)
                {
                    Dt_Accesos = Ds_Accesos.Tables[0].Copy();
                }

                // ejecutar consulta
                //Dt_Accesos = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Accesos_Diarios] " + Ex.Message, Ex);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Dt_Accesos;
        }


        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener los accesos agrupados por día y tarifa (producto), con filtros 
        /// opcionales de rango de fechas
        /// </summary>
        /// <param name="Neg_Parametros">instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>datatable con los accesos encontrados para el rango de fechas proporcionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Reporte_Diario_Recuadiacion_Tarifa(Cls_Rep_Ingresos_Negocio Neg_Parametros)
        {
            string Mi_SQL;
            DataTable Dt_Accesos = new DataTable();
            DataSet Ds_Accesos = new DataSet();

            try
            {
                MySqlDataAdapter Obj_Adaptador = new MySqlDataAdapter();
                MySqlCommand Comando_Mysql = new MySqlCommand();

                Comando_Mysql = new MySqlCommand("Diario_Recaudacion_Tarifa", new MySqlConnection(Cls_Constantes.Cadena_Conexion.ToString()));

                Comando_Mysql.CommandType = CommandType.StoredProcedure;

                //  parametros
                Comando_Mysql.Parameters.AddWithValue("?Fecha_Ini", Neg_Parametros.P_Fecha_Inicio);
                Comando_Mysql.Parameters.AddWithValue("?Fecha_Fin", Neg_Parametros.P_Fecha_Final);

                //  caja
                if (!String.IsNullOrEmpty(Neg_Parametros.P_No_Caja))
                    Comando_Mysql.Parameters.AddWithValue("?Caja_ID", Neg_Parametros.P_No_Caja);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Caja_ID", null);

                //  turno
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                    Comando_Mysql.Parameters.AddWithValue("?Turno_ID", Neg_Parametros.P_Turno_ID);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Turno_ID", null);

                //  lugar de la venta
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Turno_ID))
                    Comando_Mysql.Parameters.AddWithValue("?Lugar_Venta", Neg_Parametros.P_Lugar_Venta);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Lugar_Venta", null);

                //  lugar de la venta
                if (!String.IsNullOrEmpty(Neg_Parametros.P_Tarifa_Id))
                    Comando_Mysql.Parameters.AddWithValue("?Tarifa_Id", Neg_Parametros.P_Tarifa_Id);
                else
                    Comando_Mysql.Parameters.AddWithValue("?Tarifa_Id", null);


                Comando_Mysql.Connection.Open();

                Obj_Adaptador.SelectCommand = Comando_Mysql;
                Obj_Adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                Obj_Adaptador.Fill(Ds_Accesos);

                Comando_Mysql.Connection.Close();

                if (Ds_Accesos != null && Ds_Accesos.Tables.Count > 0)
                {
                    Dt_Accesos = Ds_Accesos.Tables[0].Copy();
                }

            }
            catch (Exception Ex)
            {
                throw new Exception("[Consulta_Accesos_Diarios] " + Ex.Message, Ex);
            }
            finally
            {
                
            }
            return Dt_Accesos;
        }

    }
}
