using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp_Ope_Ventas.Datos;

namespace Erp_Ope_Ventas.Negocio
{
    public class Cls_Ope_Ventas_Negocio
    {
        #region Variables privadas
        private System.Data.DataTable Dt_Ventas = null;
        private System.Data.DataTable Dt_Pagos = null;
        private String No_Venta = String.Empty;
        private decimal Subtotal = 0;
        private decimal Impuestos = 0;
        private decimal Descuentos = 0;
        private decimal Total = 0;
        private String Estatus = String.Empty;
        private String Motivo_Descuento_Id = String.Empty;
        private String Usuario_Id = String.Empty;
        private String Banco_Id = String.Empty;
        //Grupos
        private String Fecha_Tramite;
        private String Persona_Tramita;
        private String Empresa;
        private String Fecha_Inicio_Vigencia;
        private String Fecha_Termino_Vigencia;
        private String Aplica_Dias_Festivos;
        #endregion

        #region Variables publicas
        public System.Data.DataTable P_Dt_Ventas
        {
            get { return Dt_Ventas; }
            set { Dt_Ventas = value; }
        }
        public System.Data.DataTable P_Dt_Pagos
        {
            get { return Dt_Pagos; }
            set { Dt_Pagos = value; }
        }
        public String P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public decimal P_Subtotal
        {
            get { return Subtotal; }
            set { Subtotal = value; }
        }
        public decimal P_Impuestos
        {
            get { return Impuestos; }
            set { Impuestos = value; }
        }
        public decimal P_Descuentos
        {
            get { return Descuentos; }
            set { Descuentos = value; }
        }
        public decimal P_Total
        {
            get { return Total; }
            set { Total = value; }
        }
        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public String P_Motivo_Descuento_Id
        {
            get { return Motivo_Descuento_Id; }
            set { Motivo_Descuento_Id = value; }
        }
        public String P_Usuario_Id
        {
            get { return Usuario_Id; }
            set { Usuario_Id = value; }
        }
        //Grupos
        public String P_Fecha_Tramite
        {
            get { return Fecha_Tramite; }
            set { Fecha_Tramite = value; }
        }
        public String P_Persona_Tramita
        {
            get { return Persona_Tramita; }
            set { Persona_Tramita = value; }
        }
        public String P_Empresa
        {
            get { return Empresa; }
            set { Empresa = value; }
        }
        public String P_Fecha_Inicio_Vigencia
        {
            get { return Fecha_Inicio_Vigencia; }
            set { Fecha_Inicio_Vigencia = value; }
        }
        public String P_Fecha_Termino_Vigencia
        {
            get { return Fecha_Termino_Vigencia; }
            set { Fecha_Termino_Vigencia = value; }
        }
        public String P_Aplica_Dias_Festivos
        {
            get { return Aplica_Dias_Festivos; }
            set { Aplica_Dias_Festivos = value; }
        }
        #endregion

        #region Métodos
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Ventas
        ///DESCRIPCIÓN          : Metodo que manda llamar el metodo de Alta pago de la clase Cls_Ope_Ventas_Datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Ventas()
        {
            return Cls_Ope_Ventas_Datos.Alta_Pago(this);
        }

        public bool Realizar_Pago_Grupo() { return Cls_Ope_Ventas_Datos.Realizar_Pago_Grupo(this); }
        #endregion
    }
}
