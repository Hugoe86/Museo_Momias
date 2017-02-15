using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Erp_Cat_Contactos.Datos;

/// <summary>
/// Summary description for Cls_Cat_Contactos_Negocio
/// </summary>

namespace Erp_Cat_Contactos.Negocio
{
    public class Cls_Cat_Contactos_Negocio
    {
        public Cls_Cat_Contactos_Negocio()
        {
        }

        #region Variables

        private String Contacto_Id;
        private String Cliente_Id;
        private String Nombre_Cliente;
        private String Proveedor_Id;
        private String Nombre_Proveedor;
        private String Tipo_Contacto;
        private String Nombre_Completo;
        private String Nombres;
        private String Apellido_Paterno;
        private String Apellido_Materno;
        private String Telefono_1;
        private String Telefono_2;
        private String Nextel;
        private String Puesto;
        private String Area;
        private String Tipo;
        private String Estatus;
        private String Usuario_Creo;
        private String Ip_Creo;
        private String Equipo_Creo;
        private String Usuario_Modifico;
        private String Ip_Modifico;
        private String Equipo_Modifico;

        #endregion

        #region Variables Públicas

        public String P_Contacto_Id
        {
            get { return Contacto_Id; }
            set { Contacto_Id = value; }
        }

        public String P_Cliente_Id
        {
            get { return Cliente_Id; }
            set { Cliente_Id = value; }
        }

        public String P_Nombre_Cliente
        {
            get { return Nombre_Cliente; }
            set { Nombre_Cliente = value; }
        }

        public String P_Proveedor_Id
        {
            get { return Proveedor_Id; }
            set { Proveedor_Id = value; }
        }

        public String P_Nombre_Proveedor
        {
            get { return Nombre_Proveedor; }
            set { Nombre_Proveedor = value; }
        }

        public String P_Tipo_Contacto
        {
            get { return Tipo_Contacto; }
            set { Tipo_Contacto = value; }
        }

        public String P_Nombre_Completo
        {
            get { return Nombre_Completo; }
            set { Nombre_Completo = value; }
        }

        public String P_Nombres
        {
            get { return Nombres; }
            set { Nombres = value; }
        }

        public String P_Apellido_Paterno
        {
            get { return Apellido_Paterno; }
            set { Apellido_Paterno = value; }
        }

        public String P_Apellido_Materno
        {
            get { return Apellido_Materno; }
            set { Apellido_Materno = value; }
        }

        public String P_Telefono_1
        {
            get { return Telefono_1; }
            set { Telefono_1 = value; }
        }

        public String P_Telefono_2
        {
            get { return Telefono_2; }
            set { Telefono_2 = value; }
        }

        public String P_Nextel
        {
            get { return Nextel; }
            set { Nextel = value; }
        }

        public String P_Puesto
        {
            get { return Puesto; }
            set { Puesto = value; }
        }

        public String P_Area
        {
            get { return Area; }
            set { Area = value; }
        }

        public String P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
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
        ///NOMBRE DE LA FUNCIÓN : Alta_Contacto
        ///DESCRIPCIÓN          : Manda llamar el método de Alta_Contacto de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Contacto()
        {
            return Cls_Cat_Contactos_Datos.Alta_Contacto(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Contacto
        ///DESCRIPCIÓN          : Manda llamar el método de Modificar_Contacto de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Modificar_Contacto()
        {
            return Cls_Cat_Contactos_Datos.Modificar_Contacto(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Contacto
        ///DESCRIPCIÓN          : Manda llamar el método de Baja_Contacto de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Eliminar_Contacto()
        {
            return Cls_Cat_Contactos_Datos.Baja_Contacto(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Contactos
        ///DESCRIPCIÓN          : Manda llamar el método de Consultar_Contactos de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 15/Feb/2013 01:57:00 p.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Contactos()
        {
            return Cls_Cat_Contactos_Datos.Consultar_Contactos(this);
        }

        #endregion
    }
}