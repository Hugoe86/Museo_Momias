using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Reportes;

namespace ERP_BASE.App_Code.Negocio.Reportes
{
    class Cls_Rep_Pagos_Negocio
    {
        #region Variables Internas

        private String No_Pago = String.Empty;
        private String No_Venta = String.Empty;
        private String No_Caja = String.Empty;
        private String Forma_ID = String.Empty;
        private String Motivo_ID = String.Empty;
        private Decimal Monto_Pago = 0;
        private String Numero_Transaccion = String.Empty;
        private String Numero_Cheque = String.Empty;
        private String Referencia_Transferencia = String.Empty;
        private String Numero_Tarjeta_Banco = String.Empty;
        private DateTime Fecha_Cancelacion = DateTime.MinValue;
        private String Estatus = String.Empty;
        private String Usuario = String.Empty;
        private DateTime Fecha = DateTime.MinValue;
        private DataTable Dt_Pagos = null;

        #endregion Variables Internas

        #region Variables Publicas

        public String P_No_Pago
        {
            get { return No_Pago; }
            set { No_Pago = value; }
        }
        public String P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public String P_No_Caja
        {
            get { return No_Caja; }
            set { No_Caja = value; }
        }
        public String P_Forma_ID
        {
            get { return Forma_ID; }
            set { Forma_ID = value; }
        }
        public String P_Motivo_ID
        {
            get { return Motivo_ID; }
            set { Motivo_ID = value; }
        }
        public Decimal P_Monto_Pago
        {
            get { return Monto_Pago; }
            set { Monto_Pago = value; }
        }
        public String P_Numero_Transaccion
        {
            get { return Numero_Transaccion; }
            set { Numero_Transaccion = value; }
        }
        public String P_Numero_Cheque
        {
            get { return Numero_Cheque; }
            set { Numero_Cheque = value; }
        }
        public String P_Referencia_Transferencia
        {
            get { return Referencia_Transferencia; }
            set { Referencia_Transferencia = value; }
        }
        public String P_Numero_Tarjeta_Banco
        {
            get { return Numero_Tarjeta_Banco; }
            set { Numero_Tarjeta_Banco = value; }
        }
        public DateTime P_Fecha_Cancelacion
        {
            get { return Fecha_Cancelacion; }
            set { Fecha_Cancelacion = value; }
        }
        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
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
        public DataTable P_Dt_Pagos
        {
            get { return Dt_Pagos; }
            set { Dt_Pagos = value; }
        }

        #endregion Variables Publicas

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Pagos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Pagos()
        {
            return Cls_Rep_Pagos_Datos.Consultar_Pagos(this);
        }
    
    }
}
