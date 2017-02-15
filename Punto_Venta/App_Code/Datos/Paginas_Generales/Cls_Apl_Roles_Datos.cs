using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Sesiones;
using Erp_Apl_Roles.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Apl_Roles.Datos
{
    public class Cls_Apl_Roles_Datos
    {
        #region Alta-Modificacion-Eliminar

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Rol
        ///DESCRIPCIÓN          : Inserta un Rol en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera insertado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Rol(Cls_Apl_Roles_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            String Consecutivo = "";
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

                Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Apl_Roles.Tabla_Apl_Roles, Apl_Roles.Campo_Rol_Id, "", 5);

                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("INSERT INTO " + Apl_Roles.Tabla_Apl_Roles);
                Mi_SQL.Append(" (" + Apl_Roles.Campo_Rol_Id);
                Mi_SQL.Append(", " + Apl_Roles.Campo_Nombre);
                Mi_SQL.Append(", " + Apl_Roles.Campo_Descripcion);
                Mi_SQL.Append(", " + Apl_Roles.Campo_Estatus);
                Mi_SQL.Append(", " + Apl_Roles.Campo_Usuario_Creo);
                Mi_SQL.Append(", " + Apl_Roles.Campo_Tipo);
                Mi_SQL.Append(", " + Apl_Roles.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES ");
                Mi_SQL.Append("( '" + Consecutivo);
                Mi_SQL.Append("','" + Parametros.P_Nombre);
                Mi_SQL.Append("','" + Parametros.P_Descripcion);
                Mi_SQL.Append("','" + Parametros.P_Estatus);
                Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);
                Mi_SQL.Append("','ESCRITORIO");
                Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                Alta_Accesos_Sistema(Parametros.P_Grid, Consecutivo);

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Rol: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Rol
        ///DESCRIPCIÓN          : Modifica un Rol en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera modificado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Rol(Cls_Apl_Roles_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
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

                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("UPDATE " + Apl_Roles.Tabla_Apl_Roles + " SET ");

                //  filtro para el nombre
                if (!String.IsNullOrEmpty(Parametros.P_Nombre))
                    Mi_SQL.Append(Apl_Roles.Campo_Nombre + " = '" + Parametros.P_Nombre + "', ");

                //  filtro para la descripcion
                if (!String.IsNullOrEmpty(Parametros.P_Descripcion))
                    Mi_SQL.Append(Apl_Roles.Campo_Descripcion + " = '" + Parametros.P_Descripcion + "', ");

                //  filtro para el estatus
                if (!String.IsNullOrEmpty(Parametros.P_Estatus))
                    Mi_SQL.Append(Apl_Roles.Campo_Estatus + " = '" + Parametros.P_Estatus + "', ");

                Mi_SQL.Append(Apl_Roles.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_SQL.Append(Apl_Roles.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" WHERE " + Apl_Roles.Campo_Rol_Id + " = '" + Parametros.P_Rol_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //  se eliminar los registros de acceso con respecto al rol_id
                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("DELETE FROM " + Apl_Acceso.Tabla_Apl_Acceso);
                Mi_SQL.Append(" WHERE " + Apl_Acceso.Campo_Rol_Id + "='" + Parametros.P_Rol_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //  se agregan los accesos permitidos en los menus
                Alta_Accesos_Sistema(Parametros.P_Grid, Parametros.P_Rol_Id);

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Rol: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Rol
        ///DESCRIPCIÓN          : Elimina un Rol de la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera eliminado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Rol(Cls_Apl_Roles_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Boolean Transaccion_Activa = false;

            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();

            else
                Transaccion_Activa = true;

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();

                //  se eliminar los registros de acceso con respecto al rol_id
                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("DELETE FROM " + Apl_Acceso.Tabla_Apl_Acceso);
                Mi_SQL.Append(" WHERE " + Apl_Acceso.Campo_Rol_Id + "='" + Parametros.P_Rol_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                //  se elimina el rol
                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("DELETE FROM " + Apl_Roles.Tabla_Apl_Roles);
                Mi_SQL.Append(" WHERE " + Apl_Roles.Campo_Rol_Id + " = '" + Parametros.P_Rol_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Rol: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }

        #endregion Alta-Modificacion-Eliminar

        #region Metodos_Internos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Accesos_Sistema
        ///DESCRIPCIÓN          : Modifica un Rol en la base de datos.
        ///PARAMETROS           : Gv_Menus: el grid con los accesos
        ///                       Rol_ID: el rol al que se le asignan los permisos
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 21/Febrero/2013 05:45 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        internal static void Alta_Accesos_Sistema(DataGridView Gv_Menus, String Rol_ID)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            String Tipo_Menu = String.Empty;        //  Clasifiacion del menu (Menu, submenu,subsubmenu)
            String Nombre_Menu = String.Empty;      //  Nombre del menu
            Boolean Ope_Habilitar = false;          //  Estatus del submenu. [SI/NO] si la pagina estara habilitada o no al rol.
            Boolean Ope_Alta = false;               //  Estatus del submenu. [S/N] si la operación ALTA estara habilitada o no a la página.
            Boolean Ope_Cambio = false;             //  Estatus del submenu. [S/N] si la operación CAMBIO estara habilitada o no a la página.
            Boolean Ope_Eliminar = false;           //  Estatus del submenu. [S/N] si la operación ELIMINAR estara habilitada o no a la página.
            Boolean Ope_Consultar = false;          //  Estatus del submenu. [S/N] si la operación CONSULTAR estara habilitada o no a la página.

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            //  comienzo
            if (Gv_Menus is DataGridView)
            {
                if (Gv_Menus.Rows.Count > 0)
                {
                    foreach (DataGridViewRow FILA in Gv_Menus.Rows)
                    {
                        if (FILA is DataGridViewRow)
                        {
                            //  Comparacion para obtener el nombre del menu
                            if (FILA.Cells["MENU"].Value != null)
                                Nombre_Menu = FILA.Cells["MENU"].Value.ToString();
                            else if (FILA.Cells["SUB_MENU"].Value != null)
                                Nombre_Menu = FILA.Cells["SUB_MENU"].Value.ToString();
                            else if (FILA.Cells["SUB_SUB_MENU"].Value != null)
                                Nombre_Menu = FILA.Cells["SUB_SUB_MENU"].Value.ToString();

                            //  Tipo de menu
                            if (!String.IsNullOrEmpty(FILA.Cells["TIPO"].Value.ToString()))
                                Tipo_Menu = FILA.Cells["TIPO"].Value.ToString();

                            //  habilitar
                            if (FILA.Cells["HABILITAR"].Value != null)
                                Ope_Habilitar = (Boolean)FILA.Cells["HABILITAR"].Value;
                            else
                                Ope_Habilitar = false;

                            //  alta
                            if (FILA.Cells["HABILITAR_ALTA"].Value != null)
                                Ope_Alta = (Boolean)FILA.Cells["HABILITAR_ALTA"].Value;
                            else
                                Ope_Alta = false;

                            //  cambio
                            if (FILA.Cells["HABILITAR_CAMBIO"].Value != null)
                                Ope_Cambio = (Boolean)FILA.Cells["HABILITAR_CAMBIO"].Value;
                            else
                                Ope_Cambio = false;

                            //  eliminar
                            if (FILA.Cells["HABILITAR_ELIMINAR"].Value != null)
                                Ope_Eliminar = (Boolean)FILA.Cells["HABILITAR_ELIMINAR"].Value;
                            else
                                Ope_Eliminar = false;

                            //  consultar
                            if (FILA.Cells["HABILITAR_CONSULTA"].Value != null)
                                Ope_Consultar = (Boolean)FILA.Cells["HABILITAR_CONSULTA"].Value;
                            else
                                Ope_Consultar = false;

                            if (Ope_Habilitar == true || Ope_Alta == true || Ope_Cambio == true || Ope_Eliminar == true || Ope_Consultar == true)
                            {
                                Mi_SQL = new StringBuilder();

                                Mi_SQL.Append("INSERT INTO " + Apl_Acceso.Tabla_Apl_Acceso);
                                Mi_SQL.Append("(");
                                Mi_SQL.Append(Apl_Acceso.Campo_Rol_Id);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Nombre_Menu);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Tipo_Menu);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Habilitado);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Alta);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Cambio);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Eliminar);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Consultar);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Usuario_Creo);
                                Mi_SQL.Append(", " + Apl_Acceso.Campo_Fecha_Creo);
                                Mi_SQL.Append(") VALUES(");
                                Mi_SQL.Append("'" + Rol_ID);
                                Mi_SQL.Append("','" + Nombre_Menu);
                                Mi_SQL.Append("','" + Tipo_Menu);
                                Mi_SQL.Append("', '" + ((Ope_Habilitar) ? "S" : "N"));
                                Mi_SQL.Append("', '" + ((Ope_Alta) ? "S" : "N"));
                                Mi_SQL.Append("', '" + ((Ope_Cambio) ? "S" : "N"));
                                Mi_SQL.Append("', '" + ((Ope_Eliminar) ? "S" : "N"));
                                Mi_SQL.Append("', '" + ((Ope_Consultar) ? "S" : "N"));
                                Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);
                                Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha());
                                Mi_SQL.Append(")");
                                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                                Ope_Alta = false;
                                Ope_Cambio = false;
                                Ope_Eliminar = false;
                                Ope_Consultar = false;
                                Nombre_Menu = "";
                                Tipo_Menu = "";
                            }
                        }
                    }
                }
            }
        }

        #endregion Metodos_Internos

        #region Consulta

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Roles
        ///DESCRIPCIÓN          : Regresa un DataTable con los Roles encontrados.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Roles(Cls_Apl_Roles_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Apl_Roles.Tabla_Apl_Roles);
            if (!String.IsNullOrEmpty(Parametros.P_Rol_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Roles.Campo_Rol_Id + " = '" + Parametros.P_Rol_Id + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Tipo))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Roles.Campo_Tipo + " = '" + Parametros.P_Tipo + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Nombre))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Roles.Campo_Nombre + " LIKE '%" + Parametros.P_Nombre + "%'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Descripcion))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Roles.Campo_Descripcion + " LIKE '%" + Parametros.P_Descripcion + "%'");
            }
            Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Consulta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Acceso_Roles
        ///DESCRIPCIÓN          : Regresa un DataTable con los accesos de los Roles encontrados.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 23/Febrero/2013 12:17 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static DataTable Consultar_Acceso_Roles(Cls_Apl_Roles_Negocio Parametros)
        {
            //  variables
            DataTable Dt_Consulta = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
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

                Mi_SQL.Append("SELECT * FROM " + Apl_Acceso.Tabla_Apl_Acceso);
                Mi_SQL.Append(" WHERE " + Apl_Acceso.Campo_Rol_Id + "='" + Parametros.P_Rol_Id + "'");

                if (!String.IsNullOrEmpty(Parametros.P_Nombre_Menu))
                {
                    Mi_SQL.Append(" AND " + Apl_Acceso.Campo_Nombre_Menu + "='" + Parametros.P_Nombre_Menu + "'");
                }

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                    Conexion.HelperGenerico.Terminar_Transaccion();
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Consultar_Acceso_Roles: " + E.Message);
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

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Rol
        ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Rol.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Cls_Apl_Roles_Negocio Consultar_Detalles_Rol(Cls_Apl_Roles_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Cls_Apl_Roles_Negocio Contrato = new Cls_Apl_Roles_Negocio();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Apl_Roles.Tabla_Apl_Roles);
            Mi_SQL.Append(" WHERE " + Apl_Roles.Campo_Rol_Id + " = '" + Parametros.P_Rol_Id + "'");
            System.Data.IDataReader Dr_Rol = (System.Data.IDataReader)Conexion.HelperGenerico.Obtener_Data_Reader(Mi_SQL.ToString());

            while (Dr_Rol.Read())
            {
                Contrato.P_Rol_Id = Dr_Rol.IsDBNull(0) ? "" : Dr_Rol.GetString(0);
                Contrato.P_Nombre = Dr_Rol.IsDBNull(1) ? "" : Dr_Rol.GetString(1);
                Contrato.P_Descripcion = Dr_Rol.IsDBNull(2) ? "" : Dr_Rol.GetString(2);
                Contrato.P_Estatus = Dr_Rol.IsDBNull(3) ? "" : Dr_Rol.GetString(3);
            }
            Conexion.HelperGenerico.Cerrar_Conexion();

            return Contrato;
        }

        #endregion Consulta
    }
}