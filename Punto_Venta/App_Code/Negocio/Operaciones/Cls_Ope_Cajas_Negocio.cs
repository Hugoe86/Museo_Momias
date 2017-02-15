using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Operaciones.Cajas.Datos;

namespace Operaciones.Cajas.Negocio
{
    class Cls_Ope_Cajas_Negocio
    {
        #region Variables
        private String No_Caja;
        private String No_Turno;
        private String Usuario_ID;
        private String Caja_ID;
        private decimal Monto_Inicial;
        private DateTime Fecha_Hora_Inicio;
        private String Fecha_Creo;
        private DateTime Fecha_Hora_Cierre;
        private String Estatus;
        #endregion

        #region Variables Públicas
        public String P_No_Caja 
        { 
            get { return No_Caja; } 
            set { No_Caja = value; } 
        }
        public String P_No_Turno 
        { 
            get { return No_Turno; } 
            set { No_Turno = value; } 
        }
        public String P_Usuario_ID 
        { 
            get { return Usuario_ID; } 
            set { Usuario_ID = value; } 
        }
        public String P_Caja_ID 
        { 
            get { return Caja_ID; } 
            set { Caja_ID = value; } 
        }
        public decimal P_Monto_Inicial 
        { 
            get { return Monto_Inicial; } 
            set { Monto_Inicial = value; } 
        }
        public DateTime P_Fecha_Hora_Inicio 
        { 
            get { return Fecha_Hora_Inicio; } 
            set { Fecha_Hora_Inicio = value; } 
        }
        public String P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
        }

        public DateTime P_Fecha_Hora_Cierre 
        { 
            get { return Fecha_Hora_Cierre; } 
            set { Fecha_Hora_Cierre = value; } 
        }
        public String P_Estatus 
        { 
            get { return Estatus; } 
            set { Estatus = value; } 
        }
        #endregion

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Caja
        ///DESCRIPCIÓN          : Llama al método Alta_Caja de la capa de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 11 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public Boolean Alta_Caja() 
        {
            return Cls_Ope_Cajas_Datos.Alta_Caja(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja
        ///DESCRIPCIÓN          : Llama al método Modificar_Caja de la capa de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 11 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public Boolean Modificar_Caja() 
        {
            return Cls_Ope_Cajas_Datos.Modificar_Caja(this);    
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja
        ///DESCRIPCIÓN          : Llama al método Modificar_Caja de la capa de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 11 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public Boolean Modificar_Caja_Usando_Transaccion()
        {
            return Cls_Ope_Cajas_Datos.Modificar_Caja_Usando_Transaccion(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Cajas
        ///DESCRIPCIÓN          : Llama al método Consultar_Cajas de la capa de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 11 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Cajas() 
        {
            return Cls_Ope_Cajas_Datos.Consultar_Cajas(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Cajas
        ///DESCRIPCIÓN          : Llama al método Consultar_Cajas de la capa de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 11 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Solicitudes_Pendientes()
        {
            return Cls_Ope_Cajas_Datos.Consultar_Solicitudes_Pendientes(this);
        }
        #endregion
    }
}