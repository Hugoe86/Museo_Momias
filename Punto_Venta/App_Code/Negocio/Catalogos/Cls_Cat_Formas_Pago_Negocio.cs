using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Formas_Pago_Negocio
    {
        #region Variables Privadas
        private String Forma_ID;
        private String Nombre;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;        
        private DateTime Fecha_Modifico;
        #endregion

        #region Variables Acceso Público
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
        public String P_Forma_ID 
        { 
            get { return Forma_ID; } 
            set { Forma_ID = value; } 
        }
        public String P_Nombre 
        { 
            get { return Nombre; } 
            set { Nombre = value; } 
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
        ///NOMBRE DE LA FUNCIÓN : Alta_Forma_Pago
        ///DESCRIPCIÓN          : Llama al método Alta_Forma_Pago de la capa de de datos.
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Forma_Pago()
        {
            return Cls_Cat_Formas_Pago_Datos.Alta_Forma_Pago(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Forma_Pago
        ///DESCRIPCIÓN          : Llama al método Modificar_Forma_Pago de la capa de de datos.
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Forma_Pago()
        {
            Cls_Cat_Formas_Pago_Datos.Modificar_Forma_Pago(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Formas_Pago
        ///DESCRIPCIÓN          : Llama al método Consultar_Formas_Pago de la capa de de datos.
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Formas_Pago() 
        {
            return Cls_Cat_Formas_Pago_Datos.Consultar_Formas_Pago(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Forma_Pago
        ///DESCRIPCIÓN          : Llama al método Eliminar_Forma_Pago de la capa de de datos.
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 09 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Forma_Pago() 
        {
            Cls_Cat_Formas_Pago_Datos.Eliminar_Forma_Pago(this);
        }
        #endregion
    }
}
