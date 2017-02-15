using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Apl_Bitacora.Datos;

namespace Erp_Cat_Apl_Bitacora.Negocio
{
    public class Cls_Apl_Bitacora_Negocio
    {

        #region Variables

        private String Bitacora_Id;
        private String Usuario_Id;
        private String Recurso_Id;
        private String Accion;
        private String Recurso;
        private String Descripcion;
        private String Usuario_Creo;
        private String Ip_Creo;
        private String Equipo_Creo;
        private String Fecha_Creo;
        #endregion

        #region Variables Publicas

        public String P_Bitacora_Id
        {
            get { return Bitacora_Id; }
            set { Bitacora_Id = value; }
        }
        public String P_Usuario_Id
        {
            get { return Usuario_Id; }
            set { Usuario_Id = value; }
        }
        public String P_Recurso_Id
        {
            get { return Recurso_Id; }
            set { Recurso_Id = value; }
        }
        public String P_Accion
        {
            get { return Accion; }
            set { Accion = value; }
        }
        public String P_Recurso
        {
            get { return Recurso; }
            set { Recurso = value; }
        }
        public String P_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public String P_Usuario_Creo
        {
            get { return Usuario_Creo; }
            set { Usuario_Creo = value; }
        }
        public String P_Ip_Creo
        {
            get { return Ip_Creo; }
            set { Ip_Creo = value; }
        }
        public String P_Equipo_Creo
        {
            get { return Equipo_Creo; }
            set { Equipo_Creo = value; }
        }
        public String P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
        }

        #endregion

        #region Metodos
        public void Alta_Bitacora()
        {
            Cls_Apl_Bitacora_Datos.Alta_Bitacora(this);
        }
        public void Modificar_Bitacora()
        {
            Cls_Apl_Bitacora_Datos.Modificar_Bitacora(this);
        }
        public DataTable Consultar_Bitacora()
        {
            return Cls_Apl_Bitacora_Datos.Consultar_Bitacora(this);
        }
        public void Eliminar_Bitacora()
        {
            Cls_Apl_Bitacora_Datos.Eliminar_Bitacora(this);
        }
        #endregion


    }
}