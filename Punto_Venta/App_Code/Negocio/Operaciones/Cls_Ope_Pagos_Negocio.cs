using System;
using System.Data;
using Erp_Ope_Pagos.Datos;

namespace Erp_Ope_Pagos.Negocio
{
    public class Cls_Ope_Pagos_Negocio
    {
        #region Variables Internas

        private String No_Pago = String.Empty;
        private String No_Venta = String.Empty;
        private String No_Caja = String.Empty;
        private String Forma_ID = String.Empty;
        private String Motivo_ID = String.Empty;
        private String Banco_ID = String.Empty;
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
        public String No_Estacionamiento { get; set; }


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
        public String P_Banco_ID
        {
            get { return Banco_ID; }
            set { Banco_ID = value; }
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

        #region Metodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Pago
        ///DESCRIPCIÓN          : Genera la alta de un registro
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public String  Alta_Pago()
        {
           return  Cls_Ope_Pagos_Datos.Alta_Pago(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Pago
        ///DESCRIPCIÓN          : Modifica un registro
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Pago()
        {
            Cls_Ope_Pagos_Datos.Modificar_Pago(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Pago
        ///DESCRIPCIÓN          : Elimina un registro relacionado en base al No de Operación
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Pago()
        {
            Cls_Ope_Pagos_Datos.Eliminar_Pago(this);
        }

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
            return Cls_Ope_Pagos_Datos.Consultar_Pagos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Dias_Feriados
        ///DESCRIPCIÓN          : Regresa un DataTable con las fechas de inicio y fin de los dias feriados.
        ///PARAMETROS           : 
        ///CREO                 : Cruz Amaya Olimpo Alberto
        ///FECHA_CREO           : 08/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Dias_Feriados()
        {
            return Cls_Ope_Pagos_Datos.Consultar_Dias_Feriados(this);
        }

        #endregion Metodos
    }
}