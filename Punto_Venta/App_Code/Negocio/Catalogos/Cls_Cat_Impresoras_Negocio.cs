using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Impresoras_Negocio
    {

        #region Variables
        private String Impresora_Id;
        private String Nombre_Impresora;
        private String Ip;
        private String Ubicacion;
        private String Comentarios;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        #endregion

        #region Variables Publicas
        public String P_Impresora_Id
        {
            get { return Impresora_Id; }
            set { Impresora_Id = value; }
        }
        public String P_Nombre_Impresora
        {
            get { return Nombre_Impresora; }
            set { Nombre_Impresora = value; }
        }
        public String P_Ip
        {
            get { return Ip; }
            set { Ip = value; }
        }
        public String P_Ubicacion
        {
            get { return Ubicacion; }
            set { Ubicacion = value; }
        }
        public String P_Comentarios
        {
            get { return Comentarios; }
            set { Comentarios = value; }
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

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Impresoras
        ///DESCRIPCIÓN          : Llama el método de Alta_Impresoras de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Impresoras()
        {
            return Cls_Cat_Impresoras_Datos.Alta_Impresoras(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Impresoras
        ///DESCRIPCIÓN          : Llama el método de Modificar_Impresoras de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Impresoras()
        {
            Cls_Cat_Impresoras_Datos.Modificar_Impresoras(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Impresoras
        ///DESCRIPCIÓN          : Llama el método de Consultar_Impresoras de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Impresoras()
        {
            return Cls_Cat_Impresoras_Datos.Consultar_Impresoras(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Impresoras
        ///DESCRIPCIÓN          : Llama el método de Impresoras de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Impressoras()
        {
            Cls_Cat_Impresoras_Datos.Eliminar_Impresoras(this);
        }

        #endregion
    }
}
