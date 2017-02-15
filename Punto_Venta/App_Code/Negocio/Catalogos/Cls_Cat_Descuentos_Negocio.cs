using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Descuentos_Negocio
    {
        #region Variables
        private String Descuento_ID;
        private String Descripcion;
        private DateTime Vigencia_Desde;
        private DateTime Vigencia_Hasta;
        private String Porcentaje_Descuento;
        private String Monto_Descuento;
        private String Motivo;
        private String Leyenda;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        #endregion

        #region Variables Publicas
        public String P_Descuento_ID
        {
            get { return Descuento_ID; }
            set { Descuento_ID = value; }
        }
        public String P_Descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public DateTime P_Vigencia_Desde
        {
            get { return Vigencia_Desde; }
            set { Vigencia_Desde = value; }
        }
        public DateTime P_Vigencia_Hasta
        {
            get { return Vigencia_Hasta; }
            set { Vigencia_Hasta = value; }
        }
        public String P_Porcentaje_Descuento
        {
            get { return Porcentaje_Descuento; }
            set { Porcentaje_Descuento = value; }
        }
        public String P_Monto_Descuento
        {
            get { return Monto_Descuento; }
            set { Monto_Descuento = value; }
        }
        public String P_Motivo
        {
            get { return Motivo; }
            set { Motivo = value; }
        }
        public String P_Leyenda
        {
            get { return Leyenda; }
            set { Leyenda = value; }
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

        #region metodos
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Descuentos
        ///DESCRIPCIÓN          : Llama el método de Alta_Descuentos de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Descuentos()
        {
            return Cls_Cat_Descuentos_Datos.Alta_Descuentos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Descuentos
        ///DESCRIPCIÓN          : Llama el método de Modificar_Descuentos de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Descuentos()
        {
            Cls_Cat_Descuentos_Datos.Modificar_Descuentos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Descuentos
        ///DESCRIPCIÓN          : Llama el método de Consultar_Descuentos de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Descuentos()
        {
            return Cls_Cat_Descuentos_Datos.Consultar_Descuentos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Descuentos
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Descuentos de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 18 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Descuentos()
        {
            Cls_Cat_Descuentos_Datos.Eliminar_Descuentos(this);
        }

        #endregion

    }
}
