using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Operacion.Retiros;

namespace ERP_BASE.App_Code.Negocio.Operacion.Retiros
{
    class Cls_Ope_Retiros_Negocio
    {
        #region (Variables Privadas)
        private string No_Retiro;
        private string No_Caja;
        private string Usuario_ID_Autoriza;
        private decimal Cantidad;
        private string Motivo;
        private DateTime Fecha;
        private string Usuario_Creo;
        private string Fecha_Creo;
        private string Usuario_Modifico;
        private string Fecha_Modifico;
        #endregion

        #region (Variables Públicas)
        public string P_No_Retiro
        {
            get { return No_Retiro; }
            set { No_Retiro = value; }
        }
        public string P_No_Caja
        {
            get { return No_Caja; }
            set { No_Caja = value; }
        }
        public string P_Usuario_ID_Autoriza
        {
            get { return Usuario_ID_Autoriza; }
            set { Usuario_ID_Autoriza = value; }
        }
        public decimal P_Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public string P_Motivo
        {
            get { return Motivo; }
            set { Motivo = value; }
        }
        public DateTime P_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public string P_Usuario_Creo
        {
            get { return Usuario_Creo; }
            set { Usuario_Creo = value; }
        }
        public string P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
        }
        public string P_Usuario_Modifico
        {
            get { return Usuario_Modifico; }
            set { Usuario_Modifico = value; }
        }
        public string P_Fecha_Modifico
        {
            get { return Fecha_Modifico; }
            set { Fecha_Modifico = value; }
        }
        #endregion

        #region (Métodos)
        public bool Alta_Retiro() { return Cls_Ope_Retiros_Datos.Alta_Retiro(this); }
        public bool Modificar_Retiro() { return Cls_Ope_Retiros_Datos.Modificar_Retiro(this); }
        public bool Eliminar_Retiro() { return Cls_Ope_Retiros_Datos.Eliminar_Retiro(this); }
        public DataTable Consultar_Retiros() { return Cls_Ope_Retiros_Datos.Consultar_Retiros(this); }
        public DataTable Consultar_Cajas() { return Cls_Ope_Retiros_Datos.Consultar_Cajas(this); }
        #endregion
    }
}
