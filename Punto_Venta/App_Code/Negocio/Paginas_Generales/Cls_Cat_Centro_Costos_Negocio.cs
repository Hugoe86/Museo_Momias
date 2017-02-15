using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Centro_Costos.Datos;

namespace Erp_Cat_Centro_Costos.Negocio
{
    public class Cls_Cat_Centro_Costos_Negocio
    {
        #region Variables

        private String Centro_Costo_Id;
        private String Nombre;
        private String Descripcion;
        private String Estatus;
        private String Usuario_Creo;
        private String Ip_Creo;
        private String Equipo_Creo;
        private String Fecha_Creo;
        #endregion

        #region Variables Publicas

        public String P_Centro_Costo_Id
        {
            get { return Centro_Costo_Id; }
            set { Centro_Costo_Id = value; }
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
        public void Alta_Centro_Costo()
        {
            Cls_Cat_Centro_Costos_Datos.Alta_Centro_Costo(this);
        }
        public void Modificar_Centro_Costo()
        {
            Cls_Cat_Centro_Costos_Datos.Modificar_Centro_Costo(this);
        }
        public DataTable Consultar_Centro_Costo()
        {
            return Cls_Cat_Centro_Costos_Datos.Consultar_Centro_Costo(this);
        }
        public void Eliminar_Centro_Costo()
        {
            Cls_Cat_Centro_Costos_Datos.Eliminar_Centro_Costo(this);
        }
        #endregion
    }
}