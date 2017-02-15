using Erp.Constantes;
using Operaciones.Estacionamiento.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Operaciones.Estacionamiento.Negocio
{
    class Cls_Ope_Estacionamiento_Negocio
    {
        #region (Variables Privadas)
        private string No_Estacionamiento;
        private DateTime Fecha_Hora_Ingreso;
        private DateTime Fecha_Hora_Salida;
        private int Horas;
        private string Codigo;
        private string Estatus;
        private string Usuario_Creo;
        private decimal Importe;
        private string Producto_ID;
        public string Tipo_Servicio { set; get; }
        #endregion

        #region (Variables Publicas)
        public string P_No_Estacionamiento
        {
            get { return No_Estacionamiento; }
            set { No_Estacionamiento = value; }
        }
        public DateTime P_Fecha_Hora_Ingreso
        {
            get { return Fecha_Hora_Ingreso; }
            set { Fecha_Hora_Ingreso = value; }
        }
        public DateTime P_Fecha_Hora_Salida
        {
            get { return Fecha_Hora_Salida; }
            set { Fecha_Hora_Salida = value; }
        }
        public int P_Horas
        {
            get { return Horas; }
            set { Horas = value; }
        }
        public string P_Codigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }
        public string P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public string P_Usuario_Creo
        {
            get { return Usuario_Creo; }
            set { Usuario_Creo = value; }
        }
        public decimal P_Importe
        {
            get { return Importe; }
            set { Importe = value; }
        }
        public string P_Producto_ID
        {
            get { return Producto_ID; }
            set { Producto_ID = value; }
        }
        #endregion

        #region (Métodos)
        public bool Alta_Estacionamiento() { return Cls_Ope_Estacionamiento_Datos.Alta_Estacionamiento(this); }
        public bool Editar_Estacionamiento() { return Cls_Ope_Estacionamiento_Datos.Editar_Estacionamiento(this); }
        public bool Cancelar_Estacionamiento() { return Cls_Ope_Estacionamiento_Datos.Cancelar_Estacionamiento(this); }
        public DataTable Consultar_Estacionamiento() { return Cls_Ope_Estacionamiento_Datos.Consultar_Estacionamiento(this); }
        public DataTable Consultar_Servicios_Estacionamiento() { return Cls_Ope_Estacionamiento_Datos.Consultar_Servicios_Estacionamiento(this); }
        #endregion
    }
}
