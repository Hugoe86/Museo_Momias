using ERP_BASE.App_Code.Negocio.Operaciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ERP_BASE.App_Code.Datos.Operaciones
{
    class Cls_Ope_Cancelaciones_Negocio
    {
        #region (Variables Privadas)
        private string No_Venta;
        private string No_Pago;
        private bool Es_Grupo;
        private bool Es_Venta;
        private string No_Caja;
        private string Caja_Id;
        private DateTime Fecha_Pago;
        private string Persona_Tramita;
        private string Empresa_Tramita;
        private string Motivo_Cancelacion;
        public DateTime Fecha_Inicio_Busqueda { get; set; }
        public DateTime Fecha_Fin_Busqueda { get; set; }
        #endregion

        #region (Variables Publicas)
        public string P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public string P_No_Pago
        {
            get { return No_Pago; }
            set { No_Pago = value; }
        }
        public bool P_Es_Grupo
        {
            get { return Es_Grupo; }
            set { Es_Grupo = value; }
        }
        public bool P_Es_Venta
        {
            get { return Es_Venta; }
            set { Es_Venta = value; }
        }
        public string P_No_Caja
        {
            get { return No_Caja; }
            set { No_Caja = value; }
        }
        public string P_Caja_Id
        {
            get { return Caja_Id; }
            set { Caja_Id = value; }
        }
        public DateTime P_Fecha_Pago
        {
            get { return Fecha_Pago; }
            set { Fecha_Pago = value; }
        }
        public string P_Persona_Tramita
        {
            get { return Persona_Tramita; }
            set { Persona_Tramita = value; }
        }
        public string P_Empresa_Tramita
        {
            get { return Empresa_Tramita; }
            set { Empresa_Tramita = value; }
        }
        public string P_Motivo_Cancelacion
        {
            get { return Motivo_Cancelacion; }
            set { Motivo_Cancelacion = value; }
        }
        #endregion

        #region (Metodos)
        public DataTable Consultar_Ventas_Sencilla() { return Cls_Ope_Cancelaciones_Datos.Consultar_Ventas_Sencilla(this); }
        public DataTable Consultar_Ventas() { return Cls_Ope_Cancelaciones_Datos.Consultar_Ventas(this); }
        public DataTable Consultar_Detalle_Ventas() { return Cls_Ope_Cancelaciones_Datos.Consultar_Detalle_Ventas(this); }
        public bool Cancelar_Venta() { return Cls_Ope_Cancelaciones_Datos.Cancelar_Venta(this);  }
        public DataTable Consultar_Cajas() { return Cls_Ope_Cancelaciones_Datos.Consultar_Cajas(this); }
        #endregion
    }
}
