using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Negocio.Operacion.Retiros;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Sesiones;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp.Ayudante_Sintaxis;

namespace ERP_BASE.App_Code.Datos.Operacion.Retiros
{
    class Cls_Ope_Retiros_Datos
    {
        #region (Métodos)

        #region (Consulta)
        /// <summary>
        /// Nombre: Consultar_Retiros
        /// 
        /// Descripción: Método que consulta los retiros.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 03 Octubre 2013 11:43
        /// Usuario Modificó: Roberto González Oseguera
        /// Fecha Modificó: 19-feb-2014
        /// Causa modificación: Se cambia de la consulta ISNULL por la llamada al método ayudante Cls_Ayudante_Sintaxis.Nulos
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Listado con los registros de retiros encontrados según los filtros establecidos</returns>
        public static DataTable Consultar_Retiros(Cls_Ope_Retiros_Negocio Datos)
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
                Mi_SQL.Append(" retiros." + Ope_Retiros.Campo_No_Retiro);
                Mi_SQL.Append(", retiros." + Ope_Retiros.Campo_No_Caja);
                Mi_SQL.Append(", retiros." + Ope_Retiros.Campo_Fecha);
                Mi_SQL.Append("," + Cls_Ayudante_Sintaxis.Convertir_A_Decimal(Cls_Ayudante_Sintaxis.Nulos("retiros." + Ope_Retiros.Campo_Cantidad, "0")) + " as CANTIDAD ");
                Mi_SQL.Append(", retiros." + Ope_Retiros.Campo_Fecha);
                Mi_SQL.Append(", retiros." + Ope_Retiros.Campo_Motivo);
                Mi_SQL.Append("," + Cls_Ayudante_Sintaxis.Nulos("usuarios." + Apl_Usuarios.Campo_Nombre_Usuario , "''") + " as USUARIO ");
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha + " AS FECHA_RETIRO ");
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha + " AS HORA_RETIRO ");

                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Retiros.Tabla_Ope_Retiros + " retiros ");

                Mi_SQL.Append(" left outer join " + Apl_Usuarios.Tabla_Apl_Usuarios + " usuarios on ");
                Mi_SQL.Append("retiros." + Ope_Retiros.Campo_Usuario_ID_Autoriza + "=usuarios." + Apl_Usuarios.Campo_Usuario_Id);

                if (!string.IsNullOrEmpty(Datos.P_No_Caja))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" retiros." + Ope_Retiros.Campo_No_Caja + "='" + Datos.P_No_Caja + "'");
                }

                if (!string.IsNullOrEmpty(Datos.P_No_Retiro))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().ToLower().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" retiros." + Ope_Retiros.Campo_No_Retiro + "='" + Datos.P_No_Retiro + "'");
                }

                Mi_SQL.Append(" order by retiros." + Ope_Retiros.Campo_No_Retiro + " desc ");
                Dt_Retiros = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
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
        /// <summary>
        /// Nombre: Consultar_Cajas
        /// 
        /// Descripción: Método que consulta las cajas.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 03 Octubre 2013 13:08 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Listado con los registros de retiros encontrados según los filtros establecidos</returns>
        public static DataTable Consultar_Cajas(Cls_Ope_Retiros_Negocio Datos)
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
                Mi_SQL.Append(" ('No. Caja Abierta:' + " + Cls_Ayudante_Sintaxis.Convertir_A_Caracter(Cls_Ayudante_Sintaxis.Convertir_A_Entero("caja.No_Caja")) + ") as Caja");
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Convertir_A_Caracter("caja.No_Caja") + " as No_Caja ");
                Mi_SQL.Append(" from ");
                Mi_SQL.Append(" Ope_Cajas caja  ");
                Mi_SQL.Append(" left outer join Cat_Cajas cat_caja ON ");
                Mi_SQL.Append(" caja.Caja_ID = cat_caja.Caja_ID ");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(" caja.Estatus = 'ABIERTA' ");
                Mi_SQL.Append(" and ");
                Mi_SQL.Append(" caja.Caja_ID = '" + MDI_Frm_Apl_Principal.Caja_ID + "'");

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

        #region (Operación)
        /// <summary>
        /// Nombre: Alta_Retiro
        /// 
        /// Descripción: Método que ejecuta el alta del retiro.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 03 Octubre 2013 11:43
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Estatus de la operación true si la operación se completo y false en caso contrario</returns>
        public static bool Alta_Retiro(Cls_Ope_Retiros_Negocio Datos)
        {
            bool Operacion_Completa = false;//Variable que mantiene el estatus de la operación.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para crear el query que se ejecutara en la bd.
            String Consecutivo = "";//Variable para almacenar el consecutivo de la tabla de Ope_Nom_Retiros
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
                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Retiros.Tabla_Ope_Retiros, Ope_Retiros.Campo_No_Retiro, "", 10);

                //Creamos la consulta
                Mi_SQL.Append("insert into ");
                Mi_SQL.Append(Ope_Retiros.Tabla_Ope_Retiros);
                Mi_SQL.Append(" (");
                Mi_SQL.Append(Ope_Retiros.Campo_No_Retiro);
                Mi_SQL.Append(", " + Ope_Retiros.Campo_No_Caja);
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Usuario_ID_Autoriza);
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Cantidad);
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Motivo);
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha);
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Usuario_Creo);
                Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha_Creo);
                Mi_SQL.Append(") values(");
                Mi_SQL.Append("'" + Consecutivo + "'");
                Mi_SQL.Append(", '" + Datos.P_No_Caja + "'");
                Mi_SQL.Append(", '" + Datos.P_Usuario_ID_Autoriza + "'");
                Mi_SQL.Append(", " + Datos.P_Cantidad);
                Mi_SQL.Append(", '" + Datos.P_Motivo + "'");
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha));
                Mi_SQL.Append(", '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(", " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(")");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
                Operacion_Completa = true;
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al realizar el alta del retiro, Método: [Alta_Retiro]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Operacion_Completa;
        }
        /// <summary>
        /// Nombre: Modificar_Retiro
        /// 
        /// Descripción: Método que modifica el registro de retiro.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 03 Octubre 2013 12:27 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Estatus de la operación true si la operación se completo y false en caso contrario</returns>
        public static bool Modificar_Retiro(Cls_Ope_Retiros_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para crear el query que se ejecutara en la bd.
            bool Operacion_Completa = false;//Variable que mantiene el estatus de la operación.
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

                //Creamos la consulta.
                Mi_SQL.Append("update ");
                Mi_SQL.Append(Ope_Retiros.Tabla_Ope_Retiros);
                Mi_SQL.Append(" set ");

                #region (Datos Actualizar)
                if (!string.IsNullOrEmpty(Datos.P_No_Caja))
                    Mi_SQL.Append(Ope_Retiros.Campo_No_Caja + "='" + Datos.P_No_Caja + "'");
                else
                    Mi_SQL.Append(Ope_Retiros.Campo_No_Caja + "= null ");

                if (!string.IsNullOrEmpty(Datos.P_Usuario_ID_Autoriza))
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Usuario_ID_Autoriza + "='" + Datos.P_Usuario_ID_Autoriza + "'");
                else
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Usuario_ID_Autoriza + "= null ");

                if (Datos.P_Cantidad > 0)
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Cantidad + "=" + Datos.P_Cantidad);
                else
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Cantidad + "= null");

                if (!string.IsNullOrEmpty(Datos.P_Motivo))
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Motivo + "='" + Datos.P_Motivo + "'");
                else
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Motivo + "= null ");

                if (Datos.P_Fecha != DateTime.MinValue)
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha + "=" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha));
                else
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha + "= null ");

                if (!string.IsNullOrEmpty(MDI_Frm_Apl_Principal.Nombre_Usuario))
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Usuario_Creo + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                else
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Usuario_Creo + "= null ");

                if (!string.IsNullOrEmpty(Cls_Ayudante_Sintaxis.Fecha()))
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha_Creo + "=" + Cls_Ayudante_Sintaxis.Fecha());
                else
                    Mi_SQL.Append(", " + Ope_Retiros.Campo_Fecha_Creo + "= null ");
                #endregion

                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Retiros.Campo_No_Retiro + "='" + Datos.P_No_Retiro + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
                Operacion_Completa = true;
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al modificar el registro de retiro, Método: [Modificar_Retiro]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Operacion_Completa;
        }
        /// <summary>
        /// Nombre: Eliminar_Retiro
        /// 
        /// Descripción: Método que ejecuta la baja del registro de retiro.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 03 Octubre 2013 12:43 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Clase de entidad para controlar y transportar los datos del usuario a la capa de datos</param>
        /// <returns>Estatus de la operación true si la operación se completo y false en caso contrario</returns>
        public static bool Eliminar_Retiro(Cls_Ope_Retiros_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para crear el query que se ejecutara en la bd.
            bool Operacion_Completa = false;//Variable que mantiene el estatus de la operación.
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

                //Crear consulta.
                Mi_SQL.Append("delete from ");
                Mi_SQL.Append(Ope_Retiros.Tabla_Ope_Retiros);
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Retiros.Campo_No_Retiro + "='" + Datos.P_No_Retiro + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
                Operacion_Completa = true;
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al eliminar el registro, Método: [Eliminar_Retiro]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Operacion_Completa;
        }
        #endregion

        #endregion
    }
}
