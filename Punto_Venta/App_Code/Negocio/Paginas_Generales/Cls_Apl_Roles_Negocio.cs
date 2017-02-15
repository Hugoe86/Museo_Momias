using System;
using System.Data;
using Erp_Apl_Roles.Datos;

namespace Erp_Apl_Roles.Negocio
{
    public class Cls_Apl_Roles_Negocio
    {
        #region Variables Internas

        private String Rol_Id = String.Empty;
        private String Nombre = String.Empty;
        private String Descripcion = String.Empty;
        private String Estatus = String.Empty;
        private String Nombre_Menu = String.Empty;
        private String Tipo = String.Empty;
        private System.Windows.Forms.DataGridView Grid;

        #endregion Variables Internas

        #region Variables Publicas

        public String P_Rol_Id
        {
            get { return Rol_Id; }
            set { Rol_Id = value; }
        }

        public String P_Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public String P_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public String P_Nombre_Menu
        {
            get { return Nombre_Menu; }
            set { Nombre_Menu = value; }
        }

        public String P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }

        public System.Windows.Forms.DataGridView P_Grid
        {
            get { return Grid; }
            set { Grid = value; }
        }

        #endregion Variables Publicas

        #region Metodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Rol
        ///DESCRIPCIÓN          : Genera la alta de un registro
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Alta_Rol()
        {
            Cls_Apl_Roles_Datos.Alta_Rol(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Rol
        ///DESCRIPCIÓN          : modifica un registro
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Rol()
        {
            Cls_Apl_Roles_Datos.Modificar_Rol(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Rol
        ///DESCRIPCIÓN          : Elimina un registro relacionado con el rol_id
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Rol()
        {
            Cls_Apl_Roles_Datos.Eliminar_Rol(this);
        }

        #region Consultas

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Roles
        ///DESCRIPCIÓN          : Regresa un DataTable con los Roles encontrados.
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Roles()
        {
            return Cls_Apl_Roles_Datos.Consultar_Roles(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Roles
        ///DESCRIPCIÓN          : Regresa un DataTable con los Roles encontrados.
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Acceso_Roles()
        {
            return Cls_Apl_Roles_Datos.Consultar_Acceso_Roles(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Rol
        ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Rol.
        ///PARAMETROS           : Modificación en la Base de Datos.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Cls_Apl_Roles_Negocio Consultar_Detalles_Rol()
        {
            return Cls_Apl_Roles_Datos.Consultar_Detalles_Rol(this);
        }

        #endregion Consultas

        #endregion Metodos
    }
}