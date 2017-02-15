using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Terminales_Negocio
    {
        #region Variables
        private String Terminal_ID;
        private String Nombre;
        private String Puerto;
        private String Equipo;
        private String Estatus;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        #endregion

        #region Variables Publicas
        public String P_Terminal_ID
        {
            get { return Terminal_ID; }
            set { Terminal_ID = value; }
        }
        public String P_Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public String P_Puerto
        {
            get { return Puerto; }
            set { Puerto = value; }
        }
        public String P_Equipo
        {
            get { return Equipo; }
            set { Equipo = value; }
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



        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Terminales
        ///DESCRIPCIÓN          : Llama el método de Alta_Terminales de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Terminales()
        {
            return Cls_Cat_Terminales_Datos.Alta_Terminales(this);
           
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Terminales
        ///DESCRIPCIÓN          : Llama el método de Modificar_Terminales de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Terminales()
        {
            Cls_Cat_Terminales_Datos.Modificar_Terminales(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Terminales
        ///DESCRIPCIÓN          : Llama el método de Consultar_Terminales de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Terminales()
        {
            return Cls_Cat_Terminales_Datos.Consultar_Terminales(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Terminales
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Terminales de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 16 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Terminales()
        {
            Cls_Cat_Terminales_Datos.Eliminar_Terminales(this);
        }
    }
}
