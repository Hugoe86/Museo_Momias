using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Erp_Cat_Nom_Areas.Datos;

/// <summary>
/// Summary description for Cls_Cat_Nom_Areas_Negocio
/// </summary>

namespace Erp_Cat_Nom_Areas.Negocio
{
    public class Cls_Cat_Nom_Areas_Negocio
    {
        public Cls_Cat_Nom_Areas_Negocio()
        {
        }

        #region Variables
        
        private String Area_Id;
        private String Centro_Costo_Id;
        private String Nombre_Centro_Costo;
        private String Nombre;
        private String Descripcion;
        private String Estatus;
        private String Usuario_Creo;
        private String Ip_Creo;
        private String Equipo_Creo;
        private String Usuario_Modifico;
        private String Ip_Modifico;
        private String Equipo_Modifico;

        #endregion

        #region Variables Públicas

        public String P_Area_Id
        {
            get { return Area_Id; }
            set { Area_Id = value; }
        }

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

        public String P_Nombre_Centro_Costo
        {
            get { return Nombre_Centro_Costo; }
            set { Nombre_Centro_Costo = value; }
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

        public String P_Usuario_Modifico
        {
            get { return Usuario_Modifico; }
            set { Usuario_Modifico = value; }
        }

        public String P_Ip_Modifico
        {
            get { return Ip_Modifico; }
            set { Ip_Modifico = value; }
        }

        public String P_Equipo_Modifico
        {
            get { return Equipo_Modifico; }
            set { Equipo_Modifico = value; }
        }

        #endregion

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Area
        ///DESCRIPCIÓN          : Manda llamar el método de Alta_Area de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 18/Feb/2013 11:50:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Area()
        {
            return Cls_Cat_Nom_Areas_Datos.Alta_Area(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Area
        ///DESCRIPCIÓN          : Manda llamar el método de Modificar_Area de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 18/Feb/2013 11:50:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Modificar_Area()
        {
            return Cls_Cat_Nom_Areas_Datos.Modificar_Area(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Baja_Area
        ///DESCRIPCIÓN          : Manda llamar el método de Baja_Area de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 18/Feb/2013 11:50:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Baja_Area()
        {
            return Cls_Cat_Nom_Areas_Datos.Baja_Area(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Areas
        ///DESCRIPCIÓN          : Manda llamar el método de Consultar_Puestos de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 18/Feb/2013 11:50:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Areas()
        {
            return Cls_Cat_Nom_Areas_Datos.Consultar_Areas(this);
        }

        #endregion
    }
}