using System;
using System.Text;
using Erp.Ayudante_Sintaxis;
using Erp.Constantes;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp_Apl_Menus.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Apl_Menus.Datos
{
    public class Cls_Apl_Menus_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Menu
        ///DESCRIPCIÓN          : Inserta un Manu en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera insertado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Menu(Cls_Apl_Menus_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            String Consecutivo = "";

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Consecutivo = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Apl_Menus.Tabla_Apl_Menus, Apl_Menus.Campo_Menu_Id, "", 5);

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("INSERT INTO " + Apl_Menus.Tabla_Apl_Menus);
            Mi_SQL.Append(" (" + Apl_Menus.Campo_Menu_Id);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Parent_Id);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Menu_Descripcion);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Url_Link);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Estatus);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Usuario_Creo);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Ip_Creo);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Equipo_Creo);
            Mi_SQL.Append(", " + Apl_Menus.Campo_Fecha_Creo);
            Mi_SQL.Append(") VALUES ");
            Mi_SQL.Append("( '" + Consecutivo);
            if (Parametros.P_Parent_Id != null && Parametros.P_Parent_Id.Trim() != "")
                Mi_SQL.Append("','" + Parametros.P_Parent_Id + "'");
            else
                Mi_SQL.Append("',NULL");
            Mi_SQL.Append(",'" + Parametros.P_Menu_Descripcion);
            Mi_SQL.Append("','" + Parametros.P_Url_Link);
            Mi_SQL.Append("','" + Parametros.P_Estatus);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Ip);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Equipo);
            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Menu
        ///DESCRIPCIÓN          : Modifica un Menu en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera modificado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Menu(Cls_Apl_Menus_Negocio Parametros)
        {
            StringBuilder Mi_SQL;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Apl_Menus.Tabla_Apl_Menus + " SET ");
            if (!String.IsNullOrEmpty(Parametros.P_Parent_Id))
            { Mi_SQL.Append(Apl_Menus.Campo_Parent_Id + " = '" + Parametros.P_Parent_Id + "', "); }
            else
            { Mi_SQL.Append(Apl_Menus.Campo_Parent_Id + " = NULL, "); }
            if (!String.IsNullOrEmpty(Parametros.P_Menu_Descripcion))
            { Mi_SQL.Append(Apl_Menus.Campo_Menu_Descripcion + " = '" + Parametros.P_Menu_Descripcion + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Url_Link))
            { Mi_SQL.Append(Apl_Menus.Campo_Url_Link + " = '" + Parametros.P_Url_Link + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Estatus))
            { Mi_SQL.Append(Apl_Menus.Campo_Estatus + " = '" + Parametros.P_Estatus + "', "); }
            Mi_SQL.Append(Apl_Menus.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
            Mi_SQL.Append(Apl_Menus.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
            Mi_SQL.Append(Apl_Menus.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
            Mi_SQL.Append(Apl_Menus.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
            Mi_SQL.Append(" WHERE " + Apl_Menus.Campo_Menu_Id + " = '" + Parametros.P_Menu_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Menus
        ///DESCRIPCIÓN          : Regresa un DataTable con los Menus encontrados.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Menus(Cls_Apl_Menus_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Apl_Menus.Tabla_Apl_Menus);
            if (!String.IsNullOrEmpty(Parametros.P_Menu_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Menus.Campo_Menu_Id + " = '" + Parametros.P_Menu_Id + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Parent_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Menus.Campo_Parent_Id + " = '" + Parametros.P_Parent_Id + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Menu_Descripcion))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Menus.Campo_Menu_Descripcion + " LIKE '%" + Parametros.P_Menu_Descripcion + "%'");
            }
            if (Parametros.P_Parent_Id_Nulos)
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Menus.Campo_Parent_Id + " IS NULL");
            }
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Menu
        ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Menu.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Cls_Apl_Menus_Negocio Consultar_Detalles_Menu(Cls_Apl_Menus_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Cls_Apl_Menus_Negocio Contrato = new Cls_Apl_Menus_Negocio();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Apl_Menus.Tabla_Apl_Menus);
            Mi_SQL.Append(" WHERE " + Apl_Menus.Campo_Menu_Id + " = '" + Parametros.P_Menu_Id + "'");
            System.Data.IDataReader Dr_Menu = (System.Data.IDataReader)Conexion.HelperGenerico.Obtener_Data_Reader(Mi_SQL.ToString());

            while (Dr_Menu.Read())
            {
                Contrato.P_Menu_Id = Dr_Menu.IsDBNull(0) ? "" : Dr_Menu.GetString(0);
                Contrato.P_Parent_Id = Dr_Menu.IsDBNull(1) ? "" : Dr_Menu.GetString(1);
                Contrato.P_Menu_Descripcion = Dr_Menu.IsDBNull(2) ? "" : Dr_Menu.GetString(2);
                Contrato.P_Url_Link = Dr_Menu.IsDBNull(3) ? "" : Dr_Menu.GetString(3);
                Contrato.P_Estatus = Dr_Menu.IsDBNull(4) ? "" : Dr_Menu.GetString(4);
            }
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Contrato;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Menu
        ///DESCRIPCIÓN          : Elimina un Menu de la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera eliminado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Menu(Cls_Apl_Menus_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("DELETE FROM " + Apl_Menus.Tabla_Apl_Menus);
            Mi_SQL.Append(" WHERE " + Apl_Menus.Campo_Menu_Id + " = '" + Parametros.P_Menu_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}