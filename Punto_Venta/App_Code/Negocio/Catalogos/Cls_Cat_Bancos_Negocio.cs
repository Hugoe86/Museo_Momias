using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp.Constantes;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Bancos_Negocio
    {
        #region Variables
        private String Banco_ID;
        private String Moneda;
        private String Nombre;
        private String Cuenta;
        private String Ruta_Logo;
        private decimal Comision;
        #endregion

        #region Variables Públicas
        public String P_Banco_ID 
        { 
            get { return Banco_ID; } 
            set { Banco_ID = value; } 
        }
        public String P_Moneda 
        { 
            get { return Moneda; } 
            set { Moneda = value; } 
        }
        public String P_Nombre 
        { 
            get { return Nombre; } 
            set { Nombre = value; } 
        }
        public String P_Cuenta 
        { 
            get { return Cuenta; } 
            set { Cuenta = value; } 
        }
        public String P_Ruta_Logo 
        { 
            get { return Ruta_Logo; } 
            set { Ruta_Logo = value; } 
        }
        public decimal P_Comision 
        { 
            get { return Comision; } 
            set { Comision = value; } 
        }
        #endregion

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Bancos
        ///DESCRIPCIÓN          : Llama el método de Alta_Bancos de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Bancos() 
        {
            return Cls_Cat_Bancos_Datos.Alta_Bancos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Banco
        ///DESCRIPCIÓN          : Llama el método de Modificar_Banco de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Banco() 
        {
            Cls_Cat_Bancos_Datos.Modificar_Banco(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Bancos
        ///DESCRIPCIÓN          : Llama el método de Consultar_Bancos de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Bancos()
        {
            return Cls_Cat_Bancos_Datos.Consultar_Bancos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Banco
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Banco de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Banco() 
        {
            Cls_Cat_Bancos_Datos.Eliminar_Banco(this);
        }
        #endregion
    }
}