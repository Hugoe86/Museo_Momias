using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Lista_Deudorcad_Negocio
    {
        #region Variables
        private String Lista_Id;
        private String Lista;
        private String Nombre;
        private String Operacion;
        private String Tipo_Pago;
        private String Estatus;

        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        #endregion

        #region Variables Publicas
        public String P_Lista_Id
        {
            get { return Lista_Id; }
            set { Lista_Id = value; }
        }
        public String P_Lista
        {
            get { return Lista; }
            set { Lista = value; }
        }
        public String P_Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public String P_Operacion
        {
            get { return Operacion; }
            set { Operacion = value; }
        }
        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public String P_Tipo_Pago
        {
            get { return Tipo_Pago; }
            set { Tipo_Pago = value; }
        }

        public String P_Usuario_Creo
        {
            get { return Usuario_Creo; }
            set { Usuario_Creo = value; }
        }
        public DateTime P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
        }
        public String P_Usuario_Modifico
        {
            get { return Usuario_Modifico; }
            set { Usuario_Modifico = value; }
        }
        public DateTime P_Fecha_Modifico
        {
            get { return Fecha_Modifico; }
            set { Fecha_Modifico = value; }
        }
        #endregion


        #region Metodos
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Lista
        ///DESCRIPCIÓN          : Llama el método de Alta_Lista de la clase de datos
        ///PARÁMETROS           : 
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Lista()
        {
            return Cls_Cat_Lista_Deudorcad_Datos.Alta_Lista(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Lista
        ///DESCRIPCIÓN          : Llama el método de Modificar_Lista de la clase de datos
        ///PARÁMETROS           : 
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Modificar_Lista()
        {
            return Cls_Cat_Lista_Deudorcad_Datos.Modificar_Lista(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Impresoras
        ///DESCRIPCIÓN          : Llama el método de Alta_Impresoras de la clase de datos
        ///PARÁMETROS           : 
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 10 Junio 2015
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Listas()
        {
            return Cls_Cat_Lista_Deudorcad_Datos.Consultar_Listas(this);
        }
        #endregion
    }
}
