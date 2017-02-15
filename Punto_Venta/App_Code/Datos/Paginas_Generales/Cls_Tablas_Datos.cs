using System;
using System.Text;
using System.Data;
using Erp.Helper;
using Erp.Constantes;
using BitacorasAutomaticas.Tablas.Negocio;
using Erp.Ayudante_Sintaxis;

namespace BitacorasAutomaticas.Tablas.Datos
{
    class Cls_Tablas_Datos
    {
        public Cls_Tablas_Datos()
        {
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta una consulta para obtener un listado de tablas en la base de datos, 
        /// si tienen tabla bitácora y triggers activos
        /// </summary>
        /// <returns>Un DataTable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static DataTable Listar_Tablas()
        {
            //  variables
            DataTable Dt_Consulta = new DataTable();
            Boolean Transaccion_Activa = false;

            //  inicio de la transaccion
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                string Mi_SQL = "SELECT tablas.table_name"
                    + ", (SELECT COUNT(table_name) FROM"
                    + " information_schema.tables WHERE"
                    + " table_schema = '" + Cls_Constantes.Nombre_Base_Datos + "'"
                    + " AND table_name = concat('btc_', tablas.table_name)) bitacora "
                    + ", (SELECT count(trigger_name) FROM information_schema.triggers WHERE"
                    + " trigger_schema = tablas.table_schema"
                    + " AND trigger_name = concat('btc_', tablas.table_name, '_tgr_aftupd')) Log";
                Mi_SQL += " FROM information_schema.tables tablas"
                    + " WHERE table_schema = '" + Cls_Constantes.Nombre_Base_Datos + "'"
                    + " AND tablas.table_name NOT LIKE 'btc_%'"
                    + " ORDER BY"
                    + " tablas.table_schema";

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Lsitado de tablas: " + E.Message);
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
        /// Forma y ejecuta una consulta para obtener un listado de tablas en la base de datos, filtra 
        /// solamente las que tengan una tabla bitácora
        /// </summary>
        /// <returns>Un DataTable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static DataTable Listar_Tablas_Con_Log()
        {
            //  variables
            DataTable Dt_Consulta = new DataTable();
            Boolean Transaccion_Activa = false;

            //  inicio de la transaccion
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                string Mi_SQL = "SELECT SUBSTRING(tablas.table_name, 5) table_name"
                    + " FROM information_schema.tables tablas"
                    + " WHERE table_schema = '" + Cls_Constantes.Nombre_Base_Datos + "'"
                    + " AND tablas.table_name  LIKE 'btc_%'"
                    + " ORDER BY"
                    + " tablas.table_schema";

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Lsitado de tablas con bitácora: " + E.Message);
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
        /// Forma y ejecuta consultas para crear en la base de datos la tabla con el log para una tabla
        /// </summary>
        /// <param name="Tabla">Nombre de la tabla en la que se quiere quitar el log de eventos</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static bool Crear_Bitacora(string Tabla)
        {
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            string Campos = "";

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
                // consulta para obtener los nombre de los campos en la tabla
                string Mi_SQL = "SELECT concat(COLUMN_NAME, ' ', COLUMN_TYPE, ',') columna "
                    + "FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '" + Cls_Constantes.Nombre_Base_Datos
                    + "' AND TABLE_NAME = '" + Tabla + "' ORDER BY ORDINAL_POSITION";

                DataTable Informacion_Tabla = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                foreach (DataRow Fila in Informacion_Tabla.Rows)
                {
                    Campos += Fila[0].ToString() + " ";
                }

                // formar consulta para crear la tabla bitácora
                Mi_SQL = "DROP TABLE IF EXISTS btc_" + Tabla + ";"
                    + "CREATE TABLE btc_" + Tabla + " ("
                    + "btc_" + Tabla + "_id BIGINT AUTO_INCREMENT PRIMARY KEY,"
                    + Campos
                    + "Operacion VARCHAR(20),"
                    + "btc_usuario VARCHAR(100),"
                    + "btc_fecha_reg timestamp DEFAULT CURRENT_TIMESTAMP)";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Crear_Bitacora: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return true;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta consultas eliminan de la base de datos la tabla con el log para una tabla
        /// </summary>
        /// <param name="Tabla">Nombre de la tabla en la que se quiere quitar el log de eventos</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public static bool Eliminar_Bitacora(string Tabla)
        {
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
                // consulta para eliminar la tabla bitácora
                string Mi_SQL = "DROP TABLE IF EXISTS btc_" + Tabla;

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Bitacora: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return true;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta consultas que crean triggers en la base de datos para guardar el log
        /// </summary>
        /// <param name="Tabla">Nombre de la tabla en la que se quiere quitar el log de eventos</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static bool Crear_Servicio(string Tabla)
        {
            string Mi_SQL;
            StringBuilder Campos = new StringBuilder();
            StringBuilder Nuevos_Campos = new StringBuilder();
            StringBuilder Campos_Viejos = new StringBuilder();
            StringBuilder Campos_Validados = new StringBuilder();
            string campo;

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
                // consulta para obtener los nombre de los campos en la tabla
                Mi_SQL = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '"
                + Cls_Constantes.Nombre_Base_Datos + "' AND TABLE_NAME = '" + Tabla + "'";

                DataTable Informacion_Tabla = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                int Cont_Llave_Primario = 0;

                foreach (DataRow Fila in Informacion_Tabla.Rows)
                {
                    campo = Fila[0].ToString();
                    Campos.Append(campo + ",");
                    Nuevos_Campos.Append("NEW." + campo + ",");
                    Campos_Viejos.Append("OLD." + campo + ",");
                    // se agrega una validación para comparar el valor anterior y nuevo de cada campo
                    // de manera que solamente se inserten los valores que cambiaron
                    // si el valor nuevo es nulo o vacío, insertar un un valor especial
                    if (Cont_Llave_Primario == 0)
                    {
                        Campos_Validados.Append("OLD." + campo + ",");
                        Cont_Llave_Primario++;
                    }
                    else
                        Campos_Validados.Append(" IF (OLD." + campo + " != NEW." + campo + " || (OLD." + campo + " <=> NEW." + campo + ") = 0, IF(NEW." + campo + " IS NOT NULL && NEW." + campo + " <> '', NEW." + campo + ", '<>'), NULL),");
                }

                // generar las consultas para los triggers
                string Mi_SQL_Ins = "DROP TRIGGER IF EXISTS btc_" + Tabla + "_tgr_aftins;"
                    + " CREATE TRIGGER btc_" + Tabla + "_tgr_aftins AFTER INSERT ON " + Tabla
                    + " FOR EACH ROW BEGIN INSERT INTO btc_" + Tabla + "(" + Campos.ToString() + " Operacion, btc_usuario) VALUES (" + Nuevos_Campos.ToString() + " 'ALTA', USER()); END";
                string Mi_SQL_Upd = "DROP TRIGGER IF EXISTS btc_" + Tabla + "_tgr_aftupd;"
                    + " CREATE TRIGGER btc_" + Tabla + "_tgr_aftupd AFTER UPDATE ON " + Tabla + " FOR EACH ROW BEGIN"
                    + " INSERT INTO btc_" + Tabla + "(" + Campos.ToString() + " Operacion, btc_usuario) VALUES ("
                    + Campos_Validados.ToString() + " 'MODIFICADO', USER()); END";
                string Mi_SQL_Del = "DROP TRIGGER IF EXISTS btc_" + Tabla + "_tgr_aftdel;"
                    + " CREATE TRIGGER btc_" + Tabla + "_tgr_aftdel AFTER DELETE ON " + Tabla + " FOR EACH ROW BEGIN"
                    + " INSERT INTO btc_" + Tabla + "(" + Campos.ToString() + " Operacion, btc_usuario) VALUES ("
                    + Campos_Viejos.ToString() + " 'ELIMINADO', USER()); END";

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL_Ins.ToString());
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL_Upd.ToString());
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL_Del.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Crear_Servicio: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return true;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Forma y ejecuta consultas para eliminar los triggers de una tabla
        /// </summary>
        /// <param name="Tabla">Nombre de la tabla en la que se quiere quitar el log de eventos</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static bool Eliminar_Servicio(string Tabla)
        {
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
                // ejecutar consultas para eliminar triggers
                string Mi_SQL = "DROP TRIGGER IF EXISTS btc_" + Tabla + "_tgr_aftins";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL = "DROP TRIGGER IF EXISTS btc_" + Tabla + "_tgr_aftupd";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Mi_SQL = "DROP TRIGGER IF EXISTS btc_" + Tabla + "_tgr_aftdel";
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Servicio: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return true;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Consulta los registros en la tabla que recibe como parámetro y forma una cadena de caracteres CSV
        /// </summary>
        /// <param name="Tabla">Nombre de la tabla cuya bitácora se va a consultar</param>
        /// <returns>un arreglo de strings con los valores de la tabla separados por coma</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static string[] Respaldar_Bitacora(string Tabla)
        {
            try
            {
                DataTable Bitacora_Respaldo = null;
                string[] Contenido;
                string Linea = string.Empty;
                int Count_Lineas = 0;

                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Bitacora_Respaldo = Conexion.HelperGenerico.Obtener_Data_Table("SELECT * FROM btc_" + Tabla);

                Contenido = new string[Bitacora_Respaldo.Rows.Count + 1];

                foreach (DataColumn Columna in Bitacora_Respaldo.Columns)
                {
                    Linea += Columna.ColumnName + ",";
                }
                Contenido[Count_Lineas++] = Linea.TrimEnd(',');

                foreach (DataRow Fila in Bitacora_Respaldo.Rows)
                {
                    Linea = string.Empty;
                    foreach (object Columna in Fila.ItemArray)
                    {
                        Linea += Columna + ",";
                    }

                    Contenido[Count_Lineas++] = Linea.TrimEnd(',');
                }

                return Contenido;
            }
            catch (Exception e)
            {
                throw new Exception("Respaldar_Bitacora : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Consulta el log de eventos para una tabla y regresa un datatable con el resultado
        /// </summary>
        /// <param name="Neg_Tablas">Instancia de la clase de negocio con los filtros para la consulta</param>
        /// <returns>una tabla con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static DataTable Consultar_Bitacora(Cls_Tablas_Negocio Neg_Tablas)
        {
            try
            {
                DataTable Dt_Log = null;
                string Mi_Sql;
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                // formar consulta
                Mi_Sql = "SELECT * FROM btc_" + Neg_Tablas.P_Nombre_Tabla + " WHERE 1=1";
                // validar filtros opcionales
                if (!string.IsNullOrEmpty(Neg_Tablas.P_Operacion))
                {
                    Mi_Sql += " AND Operacion = '" + Neg_Tablas.P_Operacion + "'";
                }
                if (!string.IsNullOrEmpty(Neg_Tablas.P_Usuario))
                {
                    Mi_Sql += " AND (usuario_creo = '" + Neg_Tablas.P_Usuario + "' OR usuario_modifico = '" + Neg_Tablas.P_Usuario + "')";
                }
                // agregar filtros opcionales de fecha
                if (Neg_Tablas.P_Fecha_Inicio != DateTime.MinValue)
                {
                    Mi_Sql += " AND cast(btc_fecha_reg as date) >=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Tablas.P_Fecha_Inicio);  
                }
                if (Neg_Tablas.P_Fecha_Final!= DateTime.MinValue)
                {
                    Mi_Sql += " AND cast(btc_fecha_reg as date) <=" + Cls_Ayudante_Sintaxis.Insertar_Fecha(Neg_Tablas.P_Fecha_Final);  
                }

                // ejecutar la consulta
                Dt_Log = Conexion.HelperGenerico.Obtener_Data_Table(Mi_Sql);

                return Dt_Log;
            }
            catch (Exception e)
            {
                throw new Exception("Respaldar_Bitacora : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Ejecuta una consulta truncate en la base de datos para eliminar todos los registros de la tabla
        /// </summary>
        /// <param name="Tabla">Nombre de la tabla que se va a eliminar</param>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public static void Vaciar_Bitacora(string Tabla)
        {
            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Conexion.HelperGenerico.Ejecutar_NonQuery("TRUNCATE TABLE btc_" + Tabla);
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
    }
}