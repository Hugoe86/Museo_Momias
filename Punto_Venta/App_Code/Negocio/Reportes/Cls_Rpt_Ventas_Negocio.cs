using Reportes.Ventas.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Reportes.Ventas.Negocio
{
    class Cls_Rpt_Ventas_Negocio
    {
        #region (Variables Públicas)
        private DateTime Fecha_Inicio;
        private DateTime Fecha_Termino;
        private DateTime Hora_Inicio;
        private DateTime Hora_Termino;
        private string Caja_ID;
        private string Turno_ID;
        private string Producto_ID;
        private string Tipo_Movimiento;
        public bool Es_Detallado = false;
        public string P_Lugar_Venta { set; get; }
        public string P_Estatus { set; get; }
        public string P_Es_Corte_Arqueo { set; get; }
        private string No_Recoleccion { set; get;  }
        public string P_Formato { set; get; }
        public string P_Tipo { set; get; }
        public bool P_Es_Reporte { set; get; }
        public string P_No_Venta { set; get; }
        public string P_Folio_Acceso { set; get; }
        public string P_Museo { set; get; }
        public string P_Folio_Venta { get; set; }

        private String Camara_Entrada_Id;
        private String Camara_Salida_Id;
        private String Fecha;
        private String Str_Fecha_Termino;
        #endregion

        #region (Variables Privadas)
        public DateTime P_Fecha_Inicio
        {
            get { return Fecha_Inicio; }
            set { Fecha_Inicio = value; }
        }
        public DateTime P_Fecha_Termino
        {
            get { return Fecha_Termino; }
            set { Fecha_Termino = value; }
        }
        public DateTime P_Hora_Termino
        {
            get { return Hora_Termino; }
            set { Hora_Termino = value; }
        }
        public DateTime P_Hora_Inicio
        {
            get { return Hora_Inicio; }
            set { Hora_Inicio = value; }
        }
        public string P_Caja_ID
        {
            get { return Caja_ID; }
            set { Caja_ID = value; }
        }
        public string P_Turno_ID
        {
            get { return Turno_ID; }
            set { Turno_ID = value; }
        }
        public string P_Producto_ID
        {
            get { return Producto_ID; }
            set { Producto_ID = value; }
        }
        public string P_Tipo_Movimiento
        {
            get { return Tipo_Movimiento; }
            set { Tipo_Movimiento = value; }
        }
        public String P_Camara_Entrada_Id
        {
            get { return Camara_Entrada_Id; }
            set { Camara_Entrada_Id = value; }
        }
        public String P_Camara_Salida_Id
        {
            get { return Camara_Salida_Id; }
            set { Camara_Salida_Id = value; }
        }
        public String P_Fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public String P_Str_Fecha_Termino
        {
            get { return Str_Fecha_Termino; }
            set { Str_Fecha_Termino = value; }
        }
        public String P_No_Recoleccion
        {
            get { return No_Recoleccion; }
            set { No_Recoleccion = value; }
        }
        #endregion

        #region (Metodos)
        public DataSet Rpt_Ventas() { return Cls_Rpt_Ventas_Datos.Rpt_Ventas(this); }
        public DataTable Rpt_Movimientos_Caja() { return Cls_Rpt_Ventas_Datos.Rpt_Movimientos_Caja(this); }
        public DataTable Consultar_Productos() { return Cls_Rpt_Ventas_Datos.Consultar_Producto(this); }
        public DataTable Consultar_Productos_Acceso() { return Cls_Rpt_Ventas_Datos.Consultar_Productos_Acceso(this); }
        public DataTable Consultar_Productos_Tipo_Acceso() { return Cls_Rpt_Ventas_Datos.Consultar_Productos(this); }
        public DataTable Consultar_Retiros() { return Cls_Rpt_Ventas_Datos.Consultar_Retiros(this); }
        #endregion

        #region (Reportes)
        public DataSet Rpt_Concentrado_Ventas() { return Cls_Rpt_Ventas_Datos.Rpt_Concentrado_Ventas(this); }
        public DataSet Rpt_Detalle_Ventas() { return Cls_Rpt_Ventas_Datos.Rpt_Detalle_Ventas(this); }
        public DataTable Rpt_Detalle_Ventas_Concenteado_Ventas() { return Cls_Rpt_Ventas_Datos.Rpt_Detalle_Ventas_Concenteado_Ventas(this); }
        public DataTable Rpt_Detalle_Ventas_Tipo_Pago() { return Cls_Rpt_Ventas_Datos.Rpt_Detalle_Ventas_Tipo_Pago(this); }
        public DataSet Rpt_Ventas_Internet() { return Cls_Rpt_Ventas_Datos.Rpt_Ventas_Internet(this); }
        public DataSet Rpt_Cortes_Arqueos_Por_Dia() { return Cls_Rpt_Ventas_Datos.Rpt_Cortes_Arqueos_Por_Dia(this); }
        public DataSet Rpt_Cortes_Arqueos_Concentrado() { return Cls_Rpt_Ventas_Datos.Rpt_Cortes_Arqueos_Concentrado(this); }
        public DataSet Rpt_Folios_Cancelados() { return Cls_Rpt_Ventas_Datos.Rpt_Folios_Cancelados(this); } // folios cancelados
        public DataSet Rpt_Accesos() { return Cls_Rpt_Ventas_Datos.Rpt_Accesos(this); }



        public DataTable Consultar_Dias_Accesos_Ventas() { return Cls_Rpt_Ventas_Datos.Consultar_Dias_Accesos_Ventas(this); }
        public DataTable Consultar_Ventas_Accesos() { return Cls_Rpt_Ventas_Datos.Consultar_Ventas_Accesos(this); }
        public DataTable Consultar_Torniquete_Accesos() { return Cls_Rpt_Ventas_Datos.Consultar_Torniquete_Accesos(this); }
        public DataTable Consultar_Ventas_Productos_Accesos() { return Cls_Rpt_Ventas_Datos.Consultar_Ventas_Productos_Accesos(this); }

        public DataTable Consultar_CamaraIn_Acceso() { return Cls_Rpt_Ventas_Datos.Consultar_CamaraIn_Acceso(this); }
        public DataTable Consultar_CamaraOut_Acceso() { return Cls_Rpt_Ventas_Datos.Consultar_CamaraOut_Acceso(this); }
        public DataTable Consultar_Restantes_Ventas_Acceso() { return Cls_Rpt_Ventas_Datos.Consultar_Restantes_Ventas_Acceso(this); }
        public DataTable Consultar_Dellates_Accesos_Ventas() { return Cls_Rpt_Ventas_Datos.Consultar_Dellates_Accesos_Ventas(this); }

        #region Cortes, arqueos, recolecciones
        public DataSet Rpt_Recoleciones() { return Cls_Rpt_Ventas_Datos.Rpt_Recoleciones(this); }
        public DataSet Rpt_Arqueo() { return Cls_Rpt_Ventas_Datos.Rpt_Arqueo(this); }
        #endregion Cortes, arqueos, recolecciones
        #endregion
    }
}
