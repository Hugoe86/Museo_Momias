using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Contactos.Negocio;
using Erp.Helper;
using System.Text;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using System.Data;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;


namespace Erp_Cat_Contactos.Datos
{
    public class Cls_Cat_Contactos_Datos
    {

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Alta_Contacto
        ///DESCRIPCIÓN: Da de alta en la Base de Datos Un nuevo Contacto
        ///PARAMENTROS:     
        ///             1. P_Contactos.     Instancia de la Clase de Negocio de Contactos 
        ///                                 con los datos del que van a ser
        ///                                 dados de Alta.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 15/Feb/2013 09:10:00 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Alta_Contacto(Cls_Cat_Contactos_Negocio P_Contactos)
        {
            Boolean Alta = false;

            StringBuilder Mi_sql = new StringBuilder(); ;
            String Contacto_Id = "";

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
                Contacto_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Adm_Contactos.Tabla_Cat_Adm_Contactos, Cat_Adm_Contactos.Campo_Contacto_Id, "", 5);
                
                Mi_sql.Append("INSERT INTO " + Cat_Adm_Contactos.Tabla_Cat_Adm_Contactos + "(");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Contacto_Id + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Cliente_Id + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Proveedor_Id + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Tipo_Contacto + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Nombre_Completo + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Nombres + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Apellido_Paterno + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Apellido_Materno + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Telefono_1 + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Telefono_2 + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Nextel + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Puesto + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Area + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Tipo + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Estatus + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Usuario_Creo + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Ip_Creo + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Equipo_Creo + ", ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Fecha_Creo);
                Mi_sql.Append(") VALUES (");
                Mi_sql.Append("'" + Contacto_Id + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Cliente_Id + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Proveedor_Id + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Tipo_Contacto + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Nombre_Completo + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Nombres + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Apellido_Paterno + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Apellido_Materno + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Telefono_1 + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Telefono_2 + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Nextel + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Puesto + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Area + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Tipo + "', ");
                Mi_sql.Append("'" + P_Contactos.P_Estatus + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append("" + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Alta = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Contacto: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Modificar_Contacto
        ///DESCRIPCIÓN: Modifica en la Base de Datos Un Contacto
        ///PARAMENTROS:     
        ///             1. P_Contacto.      Instancia de la Clase de Negocio de Contactos 
        ///                                 con los datos del que van a ser
        ///                                 modificados.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 15/Feb/2013 09:50:00 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Modificar_Contacto(Cls_Cat_Contactos_Negocio P_Contacto)
        {
            Boolean Modificado = false;
            StringBuilder Mi_sql = new StringBuilder();
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

                Mi_sql.Append("UPDATE " + Cat_Adm_Contactos.Tabla_Cat_Adm_Contactos + " SET ");
                if (P_Contacto.P_Cliente_Id != null && P_Contacto.P_Cliente_Id.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Cliente_Id + " = '" + P_Contacto.P_Cliente_Id + "', ");
                if (P_Contacto.P_Proveedor_Id != null && P_Contacto.P_Proveedor_Id.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Proveedor_Id + " = '" + P_Contacto.P_Proveedor_Id + "', ");
                if (P_Contacto.P_Tipo_Contacto != null && P_Contacto.P_Tipo_Contacto.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Tipo_Contacto + " = '" + P_Contacto.P_Tipo_Contacto + "', ");
                if (P_Contacto.P_Nombre_Completo != null && P_Contacto.P_Nombre_Completo.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Nombre_Completo + " = '" + P_Contacto.P_Nombre_Completo + "', ");
                if (P_Contacto.P_Nombres != null && P_Contacto.P_Nombres.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Nombres + " = '" + P_Contacto.P_Nombres + "', ");
                if (P_Contacto.P_Apellido_Paterno != null && P_Contacto.P_Apellido_Paterno.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Apellido_Paterno + " = '" + P_Contacto.P_Apellido_Paterno + "', ");
                if (P_Contacto.P_Apellido_Materno != null && P_Contacto.P_Apellido_Materno.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Apellido_Materno + " = '" + P_Contacto.P_Apellido_Materno + "', ");
                if (P_Contacto.P_Telefono_1 != null && P_Contacto.P_Telefono_1.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Telefono_1 + " = '" + P_Contacto.P_Telefono_1 + "', ");
                if (P_Contacto.P_Telefono_2 != null && P_Contacto.P_Telefono_2.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Telefono_2 + " = '" + P_Contacto.P_Telefono_2 + "', ");
                if (P_Contacto.P_Nextel != null && P_Contacto.P_Nextel.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Nextel + " = '" + P_Contacto.P_Nextel + "', ");
                if (P_Contacto.P_Puesto != null && P_Contacto.P_Puesto.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Puesto + " = '" + P_Contacto.P_Puesto + "', ");
                if (P_Contacto.P_Area != null && P_Contacto.P_Area.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Area + " = '" + P_Contacto.P_Area + "', ");
                if (P_Contacto.P_Tipo != null && P_Contacto.P_Tipo.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Tipo + " = '" + P_Contacto.P_Tipo + "', ");
                if (P_Contacto.P_Estatus != null && P_Contacto.P_Estatus.Trim() != "")
                    Mi_sql.Append(Cat_Adm_Contactos.Campo_Estatus + " = '" + P_Contacto.P_Estatus + "', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Adm_Contactos.Campo_Contacto_Id + " = '" + P_Contacto.P_Contacto_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Modificado = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Contacto: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Modificado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Baja_Contacto
        ///DESCRIPCIÓN: Modifica el estatus en la Base de Datos un Contacto
        ///PARAMENTROS:     
        ///             1. P_Contacto.      Instancia de la Clase de Negocio de Contactos
        ///                                 con los datos del que van a ser
        ///                                 modificados.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 14/Feb/2013 10:15:00 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Baja_Contacto(Cls_Cat_Contactos_Negocio P_Contacto)
        {
            Boolean Baja = false;
            StringBuilder Mi_sql = new StringBuilder();
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

                Mi_sql.Append("UPDATE " + Cat_Adm_Contactos.Tabla_Cat_Adm_Contactos + " SET ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Estatus + " = 'ELIMINADO', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Adm_Contactos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Adm_Contactos.Campo_Contacto_Id + " = '" + P_Contacto.P_Contacto_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Baja = true;
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Baja_Contacto: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Baja;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Contactos
        ///DESCRIPCIÓN: Consulta los Contactos
        ///PARAMENTROS:     
        ///             1. P_Contactos.     Instancia de la Clase de Negocio de Contactos 
        ///                                 con los datos que servirán de
        ///                                 filtro.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 15/Feb/2013 10:20:00 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static DataTable Consultar_Contactos(Cls_Cat_Contactos_Negocio P_Contactos)
        {
            DataTable Tabla = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
            String Aux_Filtros = ""; 
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            try
            {
                Mi_SQL.Append("SELECT CN." + Cat_Adm_Contactos.Campo_Contacto_Id
                    + ", CN." + Cat_Adm_Contactos.Campo_Cliente_Id
                    + ", (SELECT CL." + Cat_Adm_Clientes.Campo_Nombre_Corto + " FROM " + Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes + " CL WHERE CL." + Cat_Adm_Clientes.Campo_Cliente_Id + "=CN." + Cat_Adm_Contactos.Campo_Cliente_Id + ") AS NOMBRE_CLIENTE"
                    + ", CN." + Cat_Adm_Contactos.Campo_Proveedor_Id
                    + ", (SELECT PR." + Cat_Adm_Proveedores.Campo_Nombre_Corto + " FROM " + Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores + " PR WHERE PR." + Cat_Adm_Proveedores.Campo_Proveedor_Id + "=CN." + Cat_Adm_Contactos.Campo_Proveedor_Id + ") AS NOMBRE_PROVEEDOR"
                    + ", CN." + Cat_Adm_Contactos.Campo_Nombre_Completo
                    + ", CN." + Cat_Adm_Contactos.Campo_Tipo_Contacto
                    + ", CN." + Cat_Adm_Contactos.Campo_Nombres
                    + ", CN." + Cat_Adm_Contactos.Campo_Apellido_Paterno
                    + ", CN." + Cat_Adm_Contactos.Campo_Apellido_Materno
                    + ", CN." + Cat_Adm_Contactos.Campo_Telefono_1
                    + ", CN." + Cat_Adm_Contactos.Campo_Telefono_2
                    + ", CN." + Cat_Adm_Contactos.Campo_Nextel
                    + ", CN." + Cat_Adm_Contactos.Campo_Puesto
                    + ", CN." + Cat_Adm_Contactos.Campo_Area
                    + ", CN." + Cat_Adm_Contactos.Campo_Tipo
                    + ", CN." + Cat_Adm_Contactos.Campo_Estatus
                    + ", CN." + Cat_Adm_Contactos.Campo_Fecha_Creo
                    + ", CN." + Cat_Adm_Contactos.Campo_Ip_Creo
                    + ", CN." + Cat_Adm_Contactos.Campo_Equipo_Creo
                    + ", CN." + Cat_Adm_Contactos.Campo_Usuario_Creo
                    + ", CN." + Cat_Adm_Contactos.Campo_Fecha_Modifico
                    + ", CN." + Cat_Nom_Puestos.Campo_Ip_Modifico
                    + ", CN." + Cat_Adm_Contactos.Campo_Equipo_Modifico
                    + ", CN." + Cat_Adm_Contactos.Campo_Usuario_Modifico
                    + " FROM  " + Cat_Adm_Contactos.Tabla_Cat_Adm_Contactos + " CN"
                    + " WHERE ");
                if (P_Contactos.P_Contacto_Id != null && P_Contactos.P_Contacto_Id.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Contacto_Id + " = '" + P_Contactos.P_Contacto_Id + "' AND ");
                }
                if (P_Contactos.P_Cliente_Id != null && P_Contactos.P_Cliente_Id.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Cliente_Id + " = '" + P_Contactos.P_Cliente_Id + "' AND ");
                }
                if (P_Contactos.P_Proveedor_Id != null && P_Contactos.P_Proveedor_Id.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Proveedor_Id + " = '" + P_Contactos.P_Proveedor_Id + "' AND ");
                }


                if (P_Contactos.P_Tipo_Contacto != null && P_Contactos.P_Tipo_Contacto.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Tipo_Contacto + " = '" + P_Contactos.P_Tipo_Contacto + "' AND ");
                }
                if (P_Contactos.P_Nombre_Completo != null && P_Contactos.P_Nombre_Completo.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Nombre_Completo + " LIKE '%" + P_Contactos.P_Nombre_Completo + "%' AND ");
                }
                if (P_Contactos.P_Puesto != null && P_Contactos.P_Puesto.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Puesto + " = '" + P_Contactos.P_Puesto + "' AND ");
                }
                if (P_Contactos.P_Area != null && P_Contactos.P_Area.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Area + " = '" + P_Contactos.P_Area + "' AND ");
                }
                if (P_Contactos.P_Tipo != null && P_Contactos.P_Tipo.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Tipo + " = '" + P_Contactos.P_Tipo + "' AND ");
                }
                if (P_Contactos.P_Nombre_Cliente != null && P_Contactos.P_Nombre_Cliente.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Cliente_Id + " IN (SELECT CL." + Cat_Adm_Clientes.Campo_Cliente_Id + " FROM " + Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes + " CL WHERE CL." + Cat_Adm_Clientes.Campo_Nombre_Corto + " LIKE '%" + P_Contactos.P_Nombre_Cliente + "%') AND ");
                }
                if (P_Contactos.P_Nombre_Proveedor != null && P_Contactos.P_Nombre_Proveedor.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Proveedor_Id + " IN (SELECT PR." + Cat_Adm_Proveedores.Campo_Proveedor_Id + " FROM " + Cat_Adm_Proveedores.Tabla_Cat_Adm_Proveedores + " PR WHERE PR." + Cat_Adm_Proveedores.Campo_Nombre_Corto + " LIKE '%" + P_Contactos.P_Nombre_Proveedor + "%') AND ");
                }
                if (P_Contactos.P_Estatus != null && P_Contactos.P_Estatus.Trim() != "")
                {
                    Mi_SQL.Append(" CN." + Cat_Adm_Contactos.Campo_Estatus + P_Contactos.P_Estatus + " AND ");
                }
                if (Mi_SQL.ToString().EndsWith(" AND "))
                {
                    Aux_Filtros = Mi_SQL.ToString().Substring(0, Mi_SQL.Length - 5);
                    Mi_SQL.Length = 0;
                    Mi_SQL.Append(Aux_Filtros);
                }
                if (Mi_SQL.ToString().EndsWith(" WHERE "))
                {
                    Aux_Filtros = Mi_SQL.ToString().Substring(0, Mi_SQL.Length - 7);
                    Mi_SQL.Length = 0;
                    Mi_SQL.Append(Aux_Filtros);
                }
                // agregar filtro y orden a la consulta
                DataSet dataset = Conexion.HelperGenerico.Obtener_Data_Set(Mi_SQL.ToString());
                if (dataset != null)
                {
                    Tabla = dataset.Tables[0];
                }
            }
            catch (Exception Ex)
            {
                String Mensaje = "Error al intentar consultar los Contactos. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
                throw new Exception(Mensaje);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Tabla;
        }
    }
}