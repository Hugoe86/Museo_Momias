using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Erp_Cat_Proveedores.Datos;

/// <summary>
/// Summary description for Cls_Cat_Proveedores_Negocio
/// </summary>

namespace Erp_Cat_Proveedores.Negocio
{
    public class Cls_Cat_Proveedores_Negocio
    {
        public Cls_Cat_Proveedores_Negocio()
        {
        }

        #region Variables
        
        private String Proveedor_Id;
        private String Giro_Id;
        private String Nombre_Giro;
        private String Nombre_Corto;
        private String Razon_Social;
        private String Rfc;
        private String Pais;
        private String Estado;
        private String Localidad;
        private String Colonia;
        private String Ciudad;
        private String Calle;
        private String Numero_Exterior;
        private String Numero_Interior;
        private String Codigo_Postal;
        private String Fax;
        private String Telefono;
        private String Extension;
        private String Nextel;
        private String Email;
        private String Sitio_Web;
        private String Dias_Credito;
        private String Limite_Credito;
        private String Descuento;
        private String Estatus;
        private String Usuario_Creo;
        private String Ip_Creo;
        private String Equipo_Creo;
        private String Usuario_Modifico;
        private String Ip_Modifico;
        private String Equipo_Modifico;

        #endregion


        #region Variables Públicas
        
        public String P_Proveedor_Id
        {
            get { return Proveedor_Id; }
            set { Proveedor_Id = value; }
        }

        public String P_Giro_Id
        {
            get { return Giro_Id; }
            set { Giro_Id = value; }
        }

        public String P_Nombre_Giro
        {
            get { return Nombre_Giro; }
            set { Nombre_Giro = value; }
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

        public String P_Pais
        {
            get { return Pais; }
            set { Pais = value; }
        }

        public String P_Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public String P_Localidad
        {
            get { return Localidad; }
            set { Localidad = value; }
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

        public String P_Codigo_Postal
        {
            get { return Codigo_Postal; }
            set { Codigo_Postal = value; }
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

        public String P_Dias_Credito
        {
            get { return Dias_Credito; }
            set { Dias_Credito = value; }
        }

        public String P_Limite_Credito
        {
            get { return Limite_Credito; }
            set { Limite_Credito = value; }
        }

        public String P_Descuento
        {
            get { return Descuento; }
            set { Descuento = value; }
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

        public String P_Usuario_Modifico
        {
            get { return Usuario_Modifico; }
            set { Usuario_Modifico = value; }
        }

        #endregion

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Proveedores
        ///DESCRIPCIÓN          : Manda llamar el método de Alta_Proveedor de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:55:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Proveedores()
        {
            return Cls_Cat_Proveedores_Datos.Alta_Proveedor(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Proveedor
        ///DESCRIPCIÓN          : Manda llamar el método de Modificar_Proveedor de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:56:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Modificar_Proveedor()
        {
            return Cls_Cat_Proveedores_Datos.Modificar_Proveedor(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Proveedor
        ///DESCRIPCIÓN          : Manda llamar el método de Baja_Proveedor de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:56:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Eliminar_Proveedor()
        {
            return Cls_Cat_Proveedores_Datos.Baja_Proveedor(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Proveedores
        ///DESCRIPCIÓN          : Manda llamar el método de Consultar_Proveedores de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:56:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Proveedores()
        {
            return Cls_Cat_Proveedores_Datos.Consultar_Proveedores(this);
        }

        #endregion
    }
}