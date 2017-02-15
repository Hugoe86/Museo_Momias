using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Motivos_Cancelacion_Negocio
    {
        #region Variables
        private String Motivo_ID;
        private String Motivo;
        private String Descripcion;
        private String Leyenda;
        private String Estatus;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        #endregion

        #region Variables Publicas
        public String P_Motivo_ID
        {
            get { return Motivo_ID; }
            set { Motivo_ID = value; }
        }
        public String P_Motivo
        {
            get { return Motivo; }
            set { Motivo = value; }
        }
        public String P_Descripción
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public String P_Leyenda
        {
            get { return Leyenda; }
            set { Leyenda = value; }
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

        #region Métodos
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Motivos_Cancelacion
        ///DESCRIPCIÓN          : Llama el método de Alta_Motivos_Cancelacion de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Motivos_Cancelacion()
        {
            return Cls_Cat_Motivos_Cancelacion_Datos.Alta_Motivos_Cancelacion(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Motivos_cancelacion
        ///DESCRIPCIÓN          : Llama el método de Modificar_Motivos_cancelacion de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Motivos_Cancelacion()
        {
            Cls_Cat_Motivos_Cancelacion_Datos.Modificar_Motivos_Decuentos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Motivos_Cancelacion
        ///DESCRIPCIÓN          : Llama el método de Consultar_Motivos_Cancelacion de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Motivos_Cancelacion()
        {
            return Cls_Cat_Motivos_Cancelacion_Datos.Consultar_Motivos_Cancelacion(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Motivos_Cancelacion
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Motivos_Cancelacion de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Motivos_Cancelacion()
        {
            Cls_Cat_Motivos_Cancelacion_Datos.Emininar_Motivos_Cancelacion(this);
        }
        #endregion
    }
}
