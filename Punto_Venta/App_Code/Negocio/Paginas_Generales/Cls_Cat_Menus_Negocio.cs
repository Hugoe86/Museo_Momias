using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Erp_Cat_Menus.Datos;

namespace Erp_Cat_Menus.Negocio
{
    public class Cls_Cat_Menus_Negocio
    {
        #region Variables Internas

        private String Menu_Id = String.Empty;
        private String Parent_Id = String.Empty;
        private String Menu_Descripcion = String.Empty;
        private String Url_Link = String.Empty;
        private String Nombre_Menu = String.Empty;
        private String Orden = String.Empty;
        private String Estatus = String.Empty;
        private Boolean Parent_Id_Nulos = false;

        #endregion Variables Internas

        #region Variables Publicas

        public String P_Menu_Id
        {
            get { return Menu_Id; }
            set { Menu_Id = value; }
        }

        public String P_Parent_Id
        {
            get { return Parent_Id; }
            set { Parent_Id = value; }
        }

        public String P_Menu_Descripcion
        {
            get { return Menu_Descripcion; }
            set { Menu_Descripcion = value; }
        }

        public String P_Url_Link
        {
            get { return Url_Link; }
            set { Url_Link = value; }
        }

        public String P_Nombre_Menu
        {
            get { return Nombre_Menu; }
            set { Nombre_Menu = value; }
        }

        public String P_Orden
        {
            get { return Orden; }
            set { Orden = value; }
        }

        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public Boolean P_Parent_Id_Nulos
        {
            get { return Parent_Id_Nulos; }
            set { Parent_Id_Nulos = value; }
        }

        #endregion Variables Publicas

        #region Metodos

        public void Alta_Menu()
        {
            Cls_Cat_Menus_Datos.Alta_Menu(this);
        }

        public void Modificar_Menu()
        {
            Cls_Cat_Menus_Datos.Modificar_Menu(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Menus
        ///DESCRIPCIÓN          : Regresa un DataTable con los Menus encontrados.
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Menus()
        {
            return Cls_Cat_Menus_Datos.Consultar_Menus(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Menu
        ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Menu.
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Cls_Cat_Menus_Negocio Consultar_Detalles_Menu()
        {
            return Cls_Cat_Menus_Datos.Consultar_Detalles_Menu(this);
        }

        public void Eliminar_Menu()
        {
            Cls_Cat_Menus_Datos.Eliminar_Menu(this);
        }

        #endregion Metodos
    }
}