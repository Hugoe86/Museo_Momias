using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    public class Cls_Cat_Cajas_Negocio
    {
        #region Variables
        private String Caja_ID;
        private String Comentarios;
        private String Nombre_Equipo;
        private String Estatus;
        private String Serie;
        private DateTime Fecha_Creo;
        private DateTime Fecha_Modifico;
        private String Numero_Caja;
        private String Usuario_Creo;
        private String Usuario_Modifico;
        #endregion

        #region Variables Públicas
        public String P_Caja_ID 
        { 
            get { return Caja_ID; } 
            set { Caja_ID = value; }
        }
        public String P_Comentarios 
        { 
            get { return Comentarios; } 
            set { Comentarios = value; } 
        }
        public String P_Nombre_Equipo
        {
            get { return Nombre_Equipo; }
            set { Nombre_Equipo = value; } 
        }
        
        public String P_Estatus 
        { 
            get { return Estatus; } 
            set { Estatus = value; } 
        }
        public String P_Serie
        {
            get { return Serie; }
            set { Serie = value; }
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
        public String P_Numero_Caja 
        { 
            get { return Numero_Caja; } 
            set { Numero_Caja = value; } 
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
        ///NOMBRE DE LA FUNCIÓN : Alta_Cajas
        ///DESCRIPCIÓN          : Llama el método de Alta_Cajas de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Cajas()
        {
            return Cls_Cat_Cajas_Datos.Alta_Cajas(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja
        ///DESCRIPCIÓN          : Llama el método de Modificar_Caja de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Caja()
        {
            Cls_Cat_Cajas_Datos.Modificar_Caja(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Caja
        ///DESCRIPCIÓN          : Llama el método de Consultar_Caja de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Caja()
        {
            return Cls_Cat_Cajas_Datos.Consultar_Caja(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Caja
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Caja de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Caja()
        {
            Cls_Cat_Cajas_Datos.Eliminar_Caja(this);
        }
        #endregion
    }
}
