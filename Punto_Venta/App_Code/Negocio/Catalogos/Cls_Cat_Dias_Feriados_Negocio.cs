using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Catalogos.Dias.Feriados.Datos;
using System.Data;

namespace Catalogos.Dias.Feriados.Negocio
{
    public class Cls_Cat_Dias_Feriados_Negocio
    {
        #region Variables
        private String Dia_ID;
        private String Descripcion;
        private DateTime Fecha;
        private DateTime Fecha_Fin;
        private String Anios;
        private String Estatus;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        #endregion

        #region Variables Públicas
        public String P_Dia_ID 
        { 
            get { return Dia_ID; } 
            set { Dia_ID = value; } 
        }
        public String P_Descripcion 
        { 
            get { return Descripcion; } 
            set { Descripcion = value; } 
        }
        public DateTime P_Fecha 
        {
            get { return Fecha; } 
            set { Fecha = value; } 
        }
        public DateTime P_Fecha_Fin
        {
            get { return Fecha_Fin; }
            set { Fecha_Fin = value; }
        }
        public String P_Anios
        {
            get { return Anios; }
            set { Anios = value; }
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
        ///NOMBRE DE LA FUNCIÓN : Alta_Dia
        ///DESCRIPCIÓN          : Llama el método de Alta_Dia de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Dia()
        {
            return Cls_Cat_Dias_Feriados_Datos.Alta_Dia(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Dia
        ///DESCRIPCIÓN          : Llama el método de Modificar_Dia de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Dia()
        {
            Cls_Cat_Dias_Feriados_Datos.Modificar_Dia(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Dias
        ///DESCRIPCIÓN          : Llama el método de Consultar_Dias de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Dias()
        {
            return Cls_Cat_Dias_Feriados_Datos.Consultar_Dias(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Dia
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Dia de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Dia()
        {
            Cls_Cat_Dias_Feriados_Datos.Eliminar_Dia(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : EsFeriado
        ///DESCRIPCIÓN          : Indica si un fecha es día feriado
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 15 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean EsFeriado(DateTime Fecha)
        {
            DataTable Dt_Feriados;
            this.Fecha = Fecha;
            this.Estatus = "ACTIVO";
            Dt_Feriados = Consultar_Dias();

            if (Dt_Feriados != null && Dt_Feriados.Rows.Count > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}
