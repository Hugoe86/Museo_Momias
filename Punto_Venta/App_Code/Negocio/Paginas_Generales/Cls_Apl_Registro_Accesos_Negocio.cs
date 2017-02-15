using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Apl_Registro_Accesos.Datos;



namespace Erp_Cat_Apl_Registro_Accesos.Negocio
{
    public class Cls_Apl_Registro_Accesos_Negocio
    {


        #region Variables

        private String Registro_Id;
        private String Usuario_Id;
        private String Tipo;
        private String Usuario_Creo;
        private String Ip_Creo;
        private String Equipo_Creo;
        private String Fecha_Creo;
        #endregion

        #region Variables Publicas

        public String P_Registro_Id
        {
            get { return Registro_Id; }
            set { Registro_Id = value; }
        }
        public String P_Usuario_Id
        {
            get { return Usuario_Id; }
            set { Usuario_Id = value; }
        }
        public String P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
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

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Alta_Registro_Accesos
        /////DESCRIPCIÓN          : Ingresa al metodo que realizara el alta de registros.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Alvarado Enriquez
        /////FECHA_CREO           : 15/Febrero/2013 06:40 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public void Alta_Registro_Accesos()
        {
            Cls_Cat_Apl_Registro_Accesos_Datos.Alta_Registro_Accesos(this);
        }

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Consultar_Registro_Accesos
        /////DESCRIPCIÓN          : Regresa un DataTable con los Registro de Acceso encontrados.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Alvarado Enriquez
        /////FECHA_CREO           : 15/Febrero/2013 06:48 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public System.Data.DataTable Consultar_Registro_Accesos()
        {
            return Cls_Cat_Apl_Registro_Accesos_Datos.Consultar_Registro_Accesos(this);
        }
        

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Consultar_Registro_Accesos
        /////DESCRIPCIÓN          : Actualiza el campo del usuario
        /////PARAMETROS           : 
        /////CREO                 : Sergio Manuel Galalrdo
        /////FECHA_CREO           : 28/Febrero/2013 06:48 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public void Registro_Acceso()
        {
            Cls_Cat_Apl_Registro_Accesos_Datos.Registro_Acceso(this);
        }
        


        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Consultar_Fecha_Servidor
        /////DESCRIPCIÓN          : Regresa un DataTable con los Registro de Acceso encontrados.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Alvarado Enriquez
        /////FECHA_CREO           : 15/Febrero/2013 06:48 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public System.Data.DataTable Consultar_Fecha_Servidor()
        {
            return Cls_Cat_Apl_Registro_Accesos_Datos.Consultar_Fecha_Servidor(this);
        }
        
        #endregion
    }
}