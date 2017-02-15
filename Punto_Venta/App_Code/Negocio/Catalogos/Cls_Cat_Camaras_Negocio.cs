using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp.Constantes;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Camaras_Negocio
    { 
        #region Variables
        private String Camara_ID;
        private String Nombre;
        private String Descripcion;
        private String Url;
        private String Estatus;
        private String Usuario;
        private String Contrasenia;
        private String Tipo;
        #endregion


        #region Variables Públicas
        public String P_Camara_ID
        {
            get { return Camara_ID; }
            set { Camara_ID = value; }
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
        public String P_Url
        {
            get { return Url; }
            set { Url = value; }
        }
        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public String P_Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public String P_Contrasenia
        {
            get { return Contrasenia; }
            set { Contrasenia = value; }
        }
        public String P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        #endregion

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Camara
        ///DESCRIPCIÓN          : Llama el método de Alta_Camara de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Camara()
        {
            return Cls_Cat_Camaras_Datos.Alta_Camara(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Camara
        ///DESCRIPCIÓN          : Llama el método de Modificar_Camara de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Modificar_Camara()
        {
            return Cls_Cat_Camaras_Datos.Modificar_Camara(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Camaras
        ///DESCRIPCIÓN          : Llama el método de Consultar_Camaras de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Camaras()
        {
            return Cls_Cat_Camaras_Datos.Consultar_Camaras(this);
        }
        #endregion
    }
}
