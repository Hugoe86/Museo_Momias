using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Motivos_Descuento_Negocio
    {
        
        #region Variables
        private String Motivos_Descuento_ID;
        private String Descripcion;
        private DateTime Fecha_Creo;
        private DateTime Fecha_Modifico;
        private String Usuario_Creo;
        private String Usuario_Modifico;
        #endregion

        #region Variables Públicas
        public String P_Motivos_Descuento_ID
        {
            get { return Motivos_Descuento_ID; }
            set { Motivos_Descuento_ID = value; }
        }
        public String P_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public DateTime P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
        }
        public DateTime P_Fecha_Modifico
        {
            get { return Fecha_Modifico; }
            set { Fecha_Modifico = value; }
        }
        public String P_Usuario_Creo
        {
            get { return Usuario_Creo; }
            set { Usuario_Creo = value; }
        }
        public String P_Usuario_Modifico
        {
            get { return Usuario_Modifico; }
            set { Usuario_Modifico = value; }
        }
        #endregion

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Motivos_Descuento
        ///DESCRIPCIÓN          : Llama el método de Alta_Motivos_Descuento de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Motivos_Descuento()
        {
            return Cls_Cat_Motivos_Descuento_Datos.Alta_Motivos_Descuento(this);
        }

        
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Motivos_Descuento
        ///DESCRIPCIÓN          : Llama el método de Modificar_Motivos_Descuento de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Motivos_Descuento()
        {
            Cls_Cat_Motivos_Descuento_Datos.Modificar_Motivos_Descuentos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Motivos_Descuento
        ///DESCRIPCIÓN          : Llama el método de Consultar_Consultar_Motivos_Descuento de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************

       public DataTable Consultar_Motivos_Descuento()
       {
           return Cls_Cat_Motivos_Descuento_Datos.Consultar_Motivos_Descuento(this);
       }

       ///*******************************************************************************
       ///NOMBRE DE LA FUNCIÓN : Eliminar_Motivos_Descuento
       ///DESCRIPCIÓN          : Llama el método de Eliminar_Motivos_Descuento de la clase de datos
       ///PARÁMETROS           : 
       ///CREÓ                 : Luis Eugenio Razo Mendiola
       ///FECHA_CREO           : 14 Octubre 2013
       ///MODIFICÓ             :
       ///FECHA_MODIFICO       :
       ///CAUSA_MODIFICACIÓN   :
       ///*******************************************************************************
       public void Eliminar_Motivos_Descuento()
       {
           Cls_Cat_Motivos_Descuento_Datos.Eliminar_Motivos_Descuento(this);
       }

        #endregion
    }
}
