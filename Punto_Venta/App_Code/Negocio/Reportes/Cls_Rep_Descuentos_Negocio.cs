using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Reportes;

namespace ERP_BASE.App_Code.Negocio.Reportes
{
    class Cls_Rep_Descuentos_Negocio
    {
        #region Variables Internas

        private String No_Descuento = String.Empty;
        private String No_Pago = String.Empty;
        private Int32 Cantidad = 0;
        private Decimal Monto_Pago = 0;
        private Decimal Descuento_Pago = 0;
        private Decimal Total_Pagar = 0;
        private DateTime Fecha_Descuento = DateTime.MinValue;
        private DateTime Fecha_Vencimiento = DateTime.MinValue;
        private String Fundamento_Legal = String.Empty;
        private String Observaciones = String.Empty;
        private String Realizo = String.Empty;
        private String Usuario = String.Empty;
        private DateTime Fecha = DateTime.MinValue;

        #endregion Variables Internas

        #region Variables Publicas
        public String P_No_Descuento
        {
            get { return No_Descuento; }
            set { No_Descuento = value; }
        }
        public String P_No_Pago
        {
            get { return No_Pago; }
            set { No_Pago = value; }
        }
        public Int32 P_Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public Decimal P_Monto_Pago
        {
            get { return Monto_Pago; }
            set { Monto_Pago = value; }
        }
        public Decimal P_Descuento_Pago
        {
            get { return Descuento_Pago; }
            set { Descuento_Pago = value; }
        }
        public Decimal P_Total_Pagar
        {
            get { return Total_Pagar; }
            set { Total_Pagar = value; }
        }
        public DateTime P_Fecha_Descuento
        {
            get { return Fecha_Descuento; }
            set { Fecha_Descuento = value; }
        }
        public DateTime P_Fecha_Vencimiento
        {
            get { return Fecha_Vencimiento; }
            set { Fecha_Vencimiento = value; }
        }
        public String P_Fundamento_Legal
        {
            get { return Fundamento_Legal; }
            set { Fundamento_Legal = value; }
        }
        public String P_Observaciones
        {
            get { return Observaciones; }
            set { Observaciones = value; }
        }
        public String P_Realizo
        {
            get { return Realizo; }
            set { Realizo = value; }
        }
        public String P_Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public DateTime P_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        #endregion Variables Publicas

         ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Descuentos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Descuentos()
        {
            return Cls_Rep_Descuentos_Datos.Consultar_Descuentos(this);
        }

    }
}
