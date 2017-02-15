using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using Operaciones.Estacionamiento.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Operaciones.Estacionamiento.Datos
{
    class Cls_Ope_Estacionamiento_Datos
    {
        #region (Metodos)

        #region (Operación)
        /// <summary>
        /// Nombre: Alta_Estacionamiento
        /// 
        /// Descripción: Método que realiza el alta del estacionamiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 13 Noviembre 2013 19:06 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Variable que se utilizara para transportar los datos de la capa de usuario a la de datos</param>
        /// <returns>Devuelve verdadero si la operacion se termino de forma correcta y falso en caso contrario</returns>
        public static bool Alta_Estacionamiento(Cls_Ope_Estacionamiento_Negocio Datos){
            bool Operacion_Completa = false;//Variable que mantiene el estatus de la operación.
            StringBuilder Mi_SQL = new StringBuilder();//Variable para crear el query que se ejecutara en la bd.
            String Consecutivo = "";//Variable para almacenar el consecutivo de la tabla de Ope_Estacionamiento
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
                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Ope_Estacionamiento.Tabla_Ope_Estacionamiento, Ope_Estacionamiento.Campo_No_Estacionamiento, "", 10);

                //Creamos la consulta
                Mi_SQL.Append("insert into ");
                Mi_SQL.Append(Ope_Estacionamiento.Tabla_Ope_Estacionamiento);
                Mi_SQL.Append(" (");
                Mi_SQL.Append(Ope_Estacionamiento.Campo_No_Estacionamiento);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Fecha_Hora_Ingreso);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Fecha_Hora_Salida);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Horas);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Codigo);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Estatus);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Importe);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Producto_ID);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Usuario_Creo);
                Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Fecha_Creo);
                Mi_SQL.Append(") values(");
                Mi_SQL.Append("'" + Consecutivo + "'");
                Mi_SQL.Append(", " + ((Datos.P_Fecha_Hora_Ingreso.Year != 1) ? Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Hora_Ingreso) : " null "));
                Mi_SQL.Append(", " + ((Datos.P_Fecha_Hora_Salida.Year != 1) ? Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Hora_Salida) : " null "));
                Mi_SQL.Append(", " + ((Datos.P_Horas > 0) ? Datos.P_Horas.ToString() : " null "));
                Mi_SQL.Append(", " + ((!string.IsNullOrEmpty(Datos.P_Codigo)) ? "'" + Datos.P_Codigo + "'" : " null "));
                Mi_SQL.Append(", " + ((!string.IsNullOrEmpty(Datos.P_Estatus)) ? "'" + Datos.P_Estatus + "'" : " null "));
                Mi_SQL.Append(", " + ((Datos.P_Importe > 0) ? Datos.P_Importe.ToString() : " null "));
                Mi_SQL.Append(", " + ((!string.IsNullOrEmpty(Datos.P_Producto_ID)) ? "'" + Datos.P_Producto_ID + "'" : " null "));
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
                throw new Exception("Error al realizar al registrar el estacionamiento, Método: [Alta_Estacionamiento]. Error: [" + Ex.Message + "]");
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
        /// Nombre: Editar_Estacionamiento
        /// 
        /// Descripción: Método que realiza la edición de los datos del estacionamiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 13 Noviembre 2013 19:17 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Variable que se utilizara para transportar los datos de la capa de usuario a la de datos</param>
        /// <returns>Devuelve verdadero si la operacion se termino de forma correcta y falso en caso contrario</returns>
        public static bool Editar_Estacionamiento(Cls_Ope_Estacionamiento_Negocio Datos)
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
                Mi_SQL.Append(Ope_Estacionamiento.Tabla_Ope_Estacionamiento);
                Mi_SQL.Append(" set ");

                #region (Datos Actualizar)
                if (Datos.P_Fecha_Hora_Salida.Year != 1)
                    Mi_SQL.Append(Ope_Estacionamiento.Campo_Fecha_Hora_Salida + "=" + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Datos.P_Fecha_Hora_Salida));
                else
                    Mi_SQL.Append(Ope_Estacionamiento.Campo_Fecha_Hora_Salida + "= null ");

                if (Datos.P_Horas > 0)
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Horas + "=" + Datos.P_Horas);
                else
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Horas + "= null");

                if (Datos.P_Importe > 0)
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Importe + "=" + Datos.P_Importe);
                else
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Importe + "= null");

                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Estatus + "='" + Datos.P_Estatus + "'");

                if (!string.IsNullOrEmpty(MDI_Frm_Apl_Principal.Nombre_Usuario))
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Usuario_Modifico + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                else
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Usuario_Modifico + "= null ");

                if (!string.IsNullOrEmpty(Cls_Ayudante_Sintaxis.Fecha()))
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Fecha_Modifico + "=" + Cls_Ayudante_Sintaxis.Fecha());
                else
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Fecha_Modifico + "= null ");
                #endregion

                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Estacionamiento.Campo_No_Estacionamiento + "='" + Datos.P_No_Estacionamiento + "'");

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
                throw new Exception("Error al modificar el registro de modificar el estacionamiento, Método: [Editar_Estacionamiento]. Error: [" + Ex.Message + "]");
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
        /// Nombre: Cancelar_Estacionamiento
        /// 
        /// Descripción: Método que realiza la cancelación del registro de estacionamiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 13 Noviembre 2013 19:20 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Datos">Variable que se utilizara para transportar los datos de la capa de usuario a la de datos</param>
        /// <returns>Devuelve verdadero si la operacion se termino de forma correcta y falso en caso contrario</returns>
        public static bool Cancelar_Estacionamiento(Cls_Ope_Estacionamiento_Negocio Datos)
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
                Mi_SQL.Append(Ope_Estacionamiento.Tabla_Ope_Estacionamiento);
                Mi_SQL.Append(" set ");

                #region (Datos Actualizar)
                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Estatus + "='" + Datos.P_Estatus + "'");
                else
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Estatus + "= null ");

                if (!string.IsNullOrEmpty(MDI_Frm_Apl_Principal.Nombre_Usuario))
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Usuario_Modifico + "='" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                else
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Usuario_Modifico + "= null ");

                if (!string.IsNullOrEmpty(Cls_Ayudante_Sintaxis.Fecha()))
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Fecha_Modifico + "=" + Cls_Ayudante_Sintaxis.Fecha());
                else
                    Mi_SQL.Append(", " + Ope_Estacionamiento.Campo_Fecha_Modifico + "= null ");
                #endregion

                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Ope_Estacionamiento.Campo_No_Estacionamiento + "='" + Datos.P_No_Estacionamiento + "'");

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
                throw new Exception("Error al cancelar el registro de estacionamiento, Método: [Cancelar_Estacionamiento]. Error: [" + Ex.Message + "]");
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

        #region (Consulta)
        /// <summary>
        /// Nombre: Consultar_Estacionamiento
        /// 
        /// Descripción: Método que devuelve los resultados encontrados con los filtros establecidos para realizar la búsqueda.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 13 Noviembre 2013 19:29 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifco:
        /// </summary>
        /// <returns>Tabla con los registros de estacionamiento</returns>
        public static DataTable Consultar_Estacionamiento(Cls_Ope_Estacionamiento_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Estacionamiento = null;//Variable de tipo estructura para almacenar los registros encontrados.
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
                Mi_SQL.Append(" estacionamiento.* ");

                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Ope_Estacionamiento.Tabla_Ope_Estacionamiento + " estacionamiento ");

                if (!string.IsNullOrEmpty(Datos.P_No_Estacionamiento))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" estacionamiento." + Ope_Estacionamiento.Campo_No_Estacionamiento + "='" + Datos.P_No_Estacionamiento + "'");
                }

                if (!string.IsNullOrEmpty(Datos.P_Codigo))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" estacionamiento." + Ope_Estacionamiento.Campo_Codigo + "='" + Datos.P_Codigo + "'");
                }

                if (!string.IsNullOrEmpty(Datos.P_Estatus))
                {
                    Mi_SQL.Append(Mi_SQL.ToString().Contains("where") ? " and " : " where ");
                    Mi_SQL.Append(" estacionamiento." + Ope_Estacionamiento.Campo_Estatus + "='" + Datos.P_Estatus + "'");
                }

                Mi_SQL.Append(" order by estacionamiento." + Ope_Estacionamiento.Campo_No_Estacionamiento + " desc ");
                
                Dt_Estacionamiento = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los registros de estacionamiento, Metodo: [Consultar_Estacionamiento]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Estacionamiento;
        }
        /// <summary>
        /// Nombre: Consultar_Servicios_Estacionamiento
        /// 
        /// Descripción: Método que devuelve los resultados encontrados con los filtros establecidos para realizar la búsqueda.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 13 Noviembre 2013 19:29 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifco:
        /// </summary>
        /// <returns>Tabla con los registros de estacionamiento</returns>
        public static DataTable Consultar_Servicios_Estacionamiento(Cls_Ope_Estacionamiento_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder();//Variable para almacenar la consulta hacía la base de datos. 
            DataTable Dt_Servicios = null;//Variable de tipo estructura para almacenar los registros encontrados.
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
                Mi_SQL.Append(" servicio.* ");

                Mi_SQL.Append(" from ");
                Mi_SQL.Append(Cat_Productos.Tabla_Cat_Productos + " servicio ");
                Mi_SQL.Append(" where ");
                Mi_SQL.Append(Cat_Productos.Campo_Tipo + "='Servicio' ");
                Mi_SQL.Append(" and ");
                Mi_SQL.Append(Cat_Productos.Campo_Tipo_Servicio + "='ESTACIONAMIENTO' ");

                if (!string.IsNullOrEmpty(Datos.P_Producto_ID))
                    Mi_SQL.Append(" and servicio." + Cat_Productos.Campo_Producto_Id + "='" + Datos.P_Producto_ID + "'");

                Mi_SQL.Append(" order by servicio." + Cat_Productos.Campo_Nombre + " desc ");

                Dt_Servicios = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Error al consultar los servicios de estacionamiento, Metodo: [Consultar_Servicios_Estacionamiento]. Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Servicios;
        }
        #endregion

        #endregion
    }
}
