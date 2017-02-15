using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Erp_Cat_Nom_Puestos.Datos;

/// <summary>
/// Summary description for Cls_Cat_Nom_Puestos_Negocio
/// </summary>

namespace Erp_Cat_Nom_Puestos.Negocio
{
    public class Cls_Cat_Nom_Puestos_Negocio
    {
        public Cls_Cat_Nom_Puestos_Negocio()
        {
        }

        #region Variables
        
        private String Puesto_Id;
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
        
        public String P_Puesto_Id
        {
            get { return Puesto_Id; }
            set { Puesto_Id = value; }
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
        ///NOMBRE DE LA FUNCIÓN : Alta_Puesto
        ///DESCRIPCIÓN          : Manda llamar el método de Alta_Puesto de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Puesto()
        {
            return Cls_Cat_Nom_Puestos_Datos.Alta_Puesto(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Puesto
        ///DESCRIPCIÓN          : Manda llamar el método de Modificar_Puesto de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Modificar_Puesto()
        {
            return Cls_Cat_Nom_Puestos_Datos.Modificar_Puesto(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Puesto
        ///DESCRIPCIÓN          : Manda llamar el método de Baja_Puesto de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Eliminar_Puesto()
        {
            return Cls_Cat_Nom_Puestos_Datos.Baja_Puesto(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Puestos
        ///DESCRIPCIÓN          : Manda llamar el método de Consultar_Puestos de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Puestos()
        {
            return Cls_Cat_Nom_Puestos_Datos.Consultar_Puestos(this);
        }

        #endregion
    }
}