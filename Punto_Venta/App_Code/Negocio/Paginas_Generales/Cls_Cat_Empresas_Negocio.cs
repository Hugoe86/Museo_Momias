using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp_Cat_Empresas.Datos;
using System.Data;

namespace Erp_Cat_Empresas.Negocio
{
    public class Cls_Cat_Empresas_Negocio
    {
        #region Variables Internas

        private String Empresa_Id = String.Empty;
        private String Nombre_Corto = String.Empty;
        private String Razon_Social = String.Empty;
        private String Rfc = String.Empty;
        private String Giro = String.Empty;
        private String Calle = String.Empty;
        private String Numero_Exterior = String.Empty;
        private String Numero_Interior = String.Empty;
        private String Colonia = String.Empty;
        private String Ciudad = String.Empty;
        private String Localidad = String.Empty;
        private String Estado = String.Empty;
        private String Pais = String.Empty;
        private String Cp = String.Empty;
        private String Fax = String.Empty;
        private String Telefono = String.Empty;
        private String Telefono_2 = String.Empty;
        private String Extension = String.Empty;
        private String Nextel = String.Empty;
        private String Contacto = String.Empty;
        private String Email = String.Empty;
        private String Sitio_Web = String.Empty;
        private String Estatus = String.Empty;
        private String Usuario_Creo = String.Empty;
        private String Ip_Creo = String.Empty;
        private String Fecha_Creo = String.Empty;
        private String Usuario_Modifico = String.Empty;
        private String Ip_Modifico = String.Empty;
        private String Equipo_Modifico = String.Empty;
        private String Fecha_Modifico = String.Empty;

        #endregion

        #region Variables Publicas

        public String P_Empresa_Id
        {
            get { return Empresa_Id; }
            set { Empresa_Id = value; }
        }
        public String P_Nombre_Corto
        {
            get { return Nombre_Corto; }
            set { Nombre_Corto = value; }
        }
        public String P_Razon_Social
        {
            get { return Razon_Social; }
            set { Razon_Social = value; }
        }
        public String P_Rfc
        {
            get { return Rfc; }
            set { Rfc = value; }
        }
        public String P_Giro
        {
            get { return Giro; }
            set { Giro = value; }
        }
        public String P_Calle
        {
            get { return Calle; }
            set { Calle = value; }
        }
        public String P_Numero_Exterior
        {
            get { return Numero_Exterior; }
            set { Numero_Exterior = value; }
        }
        public String P_Numero_Interior
        {
            get { return Numero_Interior; }
            set { Numero_Interior = value; }
        }
        public String P_Colonia
        {
            get { return Colonia; }
            set { Colonia = value; }
        }
        public String P_Ciudad
        {
            get { return Ciudad; }
            set { Ciudad = value; }
        }
        public String P_Localidad
        {
            get { return Localidad; }
            set { Localidad = value; }
        }
        public String P_Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
        public String P_Pais
        {
            get { return Pais; }
            set { Pais = value; }
        }
        public String P_Cp
        {
            get { return Cp; }
            set { Cp = value; }
        }
        public String P_Fax
        {
            get { return Fax; }
            set { Fax = value; }
        }
        public String P_Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }
        public String P_Telefono_2
        {
            get { return Telefono_2; }
            set { Telefono_2 = value; }
        }
        public String P_Extension
        {
            get { return Extension; }
            set { Extension = value; }
        }
        public String P_Nextel
        {
            get { return Nextel; }
            set { Nextel = value; }
        }
        public String P_Contacto
        {
            get { return Contacto; }
            set { Contacto = value; }
        }
        public String P_Email
        {
            get { return Email; }
            set { Email = value; }
        }
        public String P_Sitio_Web
        {
            get { return Sitio_Web; }
            set { Sitio_Web = value; }
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
        public String P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
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
        public String P_Fecha_Modifico
        {
            get { return Fecha_Modifico; }
            set { Fecha_Modifico = value; }
        }


        #endregion

        #region Metodos

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Alta_Empresas
        /////DESCRIPCIÓN          : Ingresa al metodo que realizara el alta de registros.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Alvarado Enriquez
        /////FECHA_CREO           : 15/Febrero/2013 01:40 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public void Alta_Empresa()
        {
             Cls_Cat_Empresas_Datos.Alta_Empresas(this);
        }

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Modificar_Empresa
        /////DESCRIPCIÓN          : Ingresa al metodo que realizara la modificación de registros.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Alvarado Enriquez
        /////FECHA_CREO           : 14/Febrero/2013 01:45 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public void Modificar_Empresa()
        {
            Cls_Cat_Empresas_Datos.Modificar_Empresa(this);
        }
        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Empresa_Modificacion_Estatus
        /////DESCRIPCIÓN          : Ingresa al metodo que realizara la modificación de Estatus.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Alvarado Enriquez
        /////FECHA_CREO           : 15/Febrero/2013 01:50 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public Boolean Empresa_Modificacion_Estatus()
        {
           return  Cls_Cat_Empresas_Datos.Empresa_Modificacion_Estatus(this);
        }
        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Consultar_Empresas
        /////DESCRIPCIÓN          : Regresa un DataTable con las Empresas encontrados.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Alvarado Enriquez
        /////FECHA_CREO           : 15/Febrero/2013 01:55 p.m.
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        public DataTable Consultar_Empresas()
        {
            return Cls_Cat_Empresas_Datos.Consultar_Empresas(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Usuario
        ///DESCRIPCIÓN          : Manda llamar el método de Eliminar_Usuario de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Angel Alvarado Enriquez
        ///FECHA_CREO           : 16/Feb/2013 11:15:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Empresa()
        {
            Cls_Cat_Empresas_Datos.Eliminar_Empresa(this);
        }

        #endregion
    }
}
