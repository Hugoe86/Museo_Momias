using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Operaciones.Recolecciones.Datos;
using System.Data;

namespace Operaciones.Recolecciones.Negocio
{
    class Cls_Ope_Recolecciones_Negocio
    {
        #region (Variable Privadas)
        //Datos Generales
        private string No_Recoleccion;
        private string No_Caja;
        private string Caja_Id;
        private string Nombre_Caja;
        private string Nombre_Equipo;
        private string Fecha_Venta;
        private string Caja_Usuario_ID;
        private string Usuario_ID_Recolecta;
        private int Numero_Recoleccion;
        private int Numero_Arqueo;
        private DateTime Fecha_Hora;
        private decimal Monto_Recolectado;
        private string Tipo;
        private string Texto_Ticket;
        private string Referencia1;
        private string Referencia2;
        private string Observacion;
        private string No_Venta_Mixto;
        private string No_Venta_Mixto_Agrupada;
        private string No_Venta;

        //Detalle Recolección
        private int Billetes_1000;
        private int Billetes_500;
        private int Billetes_200;
        private int Billetes_100;
        private int Billetes_50;
        private int Billetes_20;
        private int Monedas_20;
        private int Monedas_10;
        private int Monedas_5;
        private int Monedas_2;
        private int Monedas_1;
        private int Monedas_050;
        private int Monedas_020;
        private int Monedas_010;
        private string Estatus;
        private string Motivo_Cancelacion;
        public decimal P_Total_Cancelaciones { set; get; }
        public decimal P_Total_Tarjeta { set; get; }
        public decimal P_Resultado_Corte { set; get; }
        public decimal P_Total_Retiros { set; get; }
        public decimal P_Total_Cortes { set; get; }
        public decimal P_Monto_Depositar { set; get; }
        public decimal P_Total_Caja_Sistema{ set; get; }

        public Boolean P_Accion { set; get; }

        public DataTable P_Dt_Ventas_Dia { set; get; }
        public DataTable P_Dt_Listas_Deudorcad { set; get; }
        private string Cuenta_Momias;
        private string Lista_Adeudo;
        private string Tipo_Adeudo;
        private string Clave_Venta;
        private string Clave_Sobrante;
        private string Usuario_Autorizo; 
        #endregion

        #region (Variables Publicas)
        //Datos Generales
        public string P_No_Recoleccion {
            get { return No_Recoleccion; }
            set { No_Recoleccion = value; }
        }
        public string P_No_Caja
        {
            get { return No_Caja; }
            set { No_Caja = value; }
        }
        public string P_Nombre_Caja
        {
            get { return Nombre_Caja; }
            set { Nombre_Caja = value; }
        }
        public string P_Nombre_Equipo
        {
            get { return Nombre_Equipo; }
            set { Nombre_Equipo = value; }
        }

        public string P_Fecha_Venta
        {
            get { return Fecha_Venta; }
            set { Fecha_Venta = value; }
        }
        public string P_Caja_Id
        {
            get { return Caja_Id; }
            set { Caja_Id = value; }
        }

        public string P_Caja_Usuario_ID
        {
            get { return Caja_Usuario_ID; }
            set { Caja_Usuario_ID = value; }
        }

        public string P_Usuario_ID_Recolecta
        {
            get { return Usuario_ID_Recolecta; }
            set { Usuario_ID_Recolecta = value; }
        }
        public int P_Numero_Recoleccion
        {
            get { return Numero_Recoleccion; }
            set { Numero_Recoleccion = value; }
        }
        public int P_Numero_Arqueo
        {
            get { return Numero_Arqueo; }
            set { Numero_Arqueo = value; }
        }
        public DateTime P_Fecha_Hora
        {
            get { return Fecha_Hora; }
            set { Fecha_Hora = value; }
        }
        public decimal P_Monto_Recolectado
        {
            get { return Monto_Recolectado; }
            set { Monto_Recolectado = value; }
        }
        public string P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public string P_Texto_Ticket
        {
            get { return Texto_Ticket; }
            set { Texto_Ticket = value; }
        }
        public string P_Referencia1
        {
            get { return Referencia1; }
            set { Referencia1 = value; }
        }
        public string P_Referencia2
        {
            get { return Referencia2; }
            set { Referencia2 = value; }
        }
        public string P_Observacion
        {
            get { return Observacion; }
            set { Observacion = value; }
        }
        public string P_No_Venta_Mixto
        {
            get { return No_Venta_Mixto; }
            set { No_Venta_Mixto = value; }
        }
        public string P_No_Venta_Mixto_Agrupada
        {
            get { return No_Venta_Mixto_Agrupada; }
            set { No_Venta_Mixto_Agrupada = value; }
        }
        public string P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }

        //Detalle de la recolección.
        public int P_Billetes_1000
        {
            get { return Billetes_1000; }
            set { Billetes_1000 = value; }
        }
        public int P_Billetes_500
        {
            get { return Billetes_500; }
            set { Billetes_500 = value; }
        }
        public int P_Billetes_200
        {
            get { return Billetes_200; }
            set { Billetes_200 = value; }
        }
        public int P_Billetes_100
        {
            get { return Billetes_100; }
            set { Billetes_100 = value; }
        }
        public int P_Billetes_50
        {
            get { return Billetes_50; }
            set { Billetes_50 = value; }
        }
        public int P_Billetes_20
        {
            get { return Billetes_20; }
            set { Billetes_20 = value; }
        }
        public int P_Monedas_20
        {
            get { return Monedas_20; }
            set { Monedas_20 = value; }
        }
        public int P_Monedas_10
        {
            get { return Monedas_10; }
            set { Monedas_10 = value; }
        }
        public int P_Monedas_5
        {
            get { return Monedas_5; }
            set { Monedas_5 = value; }
        }
        public int P_Monedas_2
        {
            get { return Monedas_2; }
            set { Monedas_2 = value; }
        }
        public int P_Monedas_1
        {
            get { return Monedas_1; }
            set { Monedas_1 = value; }
        }
        public int P_Monedas_050
        {
            get { return Monedas_050; }
            set { Monedas_050 = value; }
        }
        public int P_Monedas_020
        {
            get { return Monedas_020; }
            set { Monedas_020 = value; }
        }
        public int P_Monedas_010
        {
            get { return Monedas_010; }
            set { Monedas_010 = value; }
        }
        public string P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public string P_Motivo_Cancelacion
        {
            get { return Motivo_Cancelacion; }
            set { Motivo_Cancelacion = value; }
        }
        public string P_Cuenta_Momias
        {
            get { return Cuenta_Momias; }
            set { Cuenta_Momias = value; }
        }
        public string P_Lista_Adeudo
        {
            get { return Lista_Adeudo; }
            set { Lista_Adeudo = value; }
        }
        public string P_Tipo_Adeudo
        {
            get { return Tipo_Adeudo; }
            set { Tipo_Adeudo = value; }
        }
        public string P_Clave_Venta
        {
            get { return Clave_Venta; }
            set { Clave_Venta = value; }
        }
         public string P_Clave_Sobrante
        {
            get { return Clave_Sobrante; }
            set { Clave_Sobrante = value; }
        }

         public string P_Usuario_Autorizo
         {
             get { return Usuario_Autorizo; }
             set { Usuario_Autorizo = value; }
         }
        #endregion

        #region (Métodos)
        public Cls_Ope_Recolecciones_Negocio Alta_Recoleccion() { return Cls_Ope_Recolecciones_Datos.Alta_Recoleccion(this); }
        public bool Modificar_Recoleccion() { return Cls_Ope_Recolecciones_Datos.Modificar_Recoleccion(this); }
        public bool Eliminar_Recoleccion() { return Cls_Ope_Recolecciones_Datos.Eliminar_Recoleccion(this); }
        public DataTable Consultar_Recoleccion() { return Cls_Ope_Recolecciones_Datos.Consultar_Recoleccion(this); }
        public DataTable Consultar_Cajas() { return Cls_Ope_Recolecciones_Datos.Consultar_Cajas(this); }
        public DataTable Consultar_Bancos() { return Cls_Ope_Recolecciones_Datos.Consultar_Bancos(this); }
        public DataTable Consultar_Usuario_Autorizo() { return Cls_Ope_Recolecciones_Datos.Consultar_Usuario_Autorizo(this); }
        public DataTable Consultar_Folio_Movimiento() { return Cls_Ope_Recolecciones_Datos.Consultar_Folio_Movimiento(this); }
        public DataTable Consultar_Consecutivo_Recoleccion_Por_Caja_Turno() { return Cls_Ope_Recolecciones_Datos.Consultar_Consecutivo_Recoleccion_Por_Caja_Turno(this); }
        public DataTable Consultar_Consecutivo_Arqueo_Por_Caja_Turno() { return Cls_Ope_Recolecciones_Datos.Consultar_Consecutivo_Arqueo_Por_Caja_Turno(this); }
        public DataTable Consultar_Ventas_Dia() { return Cls_Ope_Recolecciones_Datos.Consultar_Ventas_Dia(this); }
        public DataTable Consultar_Pago_De_Venta_Mixta() { return Cls_Ope_Recolecciones_Datos.Consultar_Pago_De_Venta_Mixta(this); }

        public DataTable Consultar_Ventas_Dia_Mixtas() { return Cls_Ope_Recolecciones_Datos.Consultar_Ventas_Dia_Mixtas(this); }
        #endregion
    }
}
