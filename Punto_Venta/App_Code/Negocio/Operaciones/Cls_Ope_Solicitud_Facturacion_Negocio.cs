using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Erp_Solicitud_Facturacion.Datos;

namespace Erp_Solicitud_Facturacion.Negocio
{
    class Cls_Ope_Solicitud_Facturacion_Negocio
    {
        #region Variables privadas
        public DataGridView Grid_Ventas { get; set; }
        private String Rfc;
        private System.Data.DataTable Dt_Ventas_Dia;
        private System.Data.DataTable Dt_Parametros;
        private System.Data.DataTable Dt_Padron_Nuevos;
        private System.Data.DataTable Dt_Padron_Actualizacion;
        private System.Data.DataTable Dt_Listdeudor_Nuevos;
        private System.Data.DataTable Dt_Listdeudor_;
        private System.Data.DataTable Dt_Solicitud;
        private System.Data.DataTable Dt_Listas_Deudorcad;
        private System.Data.DataTable Dt_Ventas_Clasificacion;
        private System.Data.DataTable Dt_Padron_Nuevos_Direcciones; 
                
        private String Curp;
        private String Numero_Venta;
        private String Cuenta_Momias;
        private String Fecha_Venta;
        private String Lista;
        private String Tipo;
        private String Sobrante;
        private String Clave_Venta;
        private String Clave_Sobrante;
        private String Lista_Parametros;
        private String Tipo_Parametro;
        private String No_Turno;
        private Double Total_Venta;
        private Boolean Estatus = false;
        private String Imagen_Bits;
        private String Referencia1;
        private String Referencia2;
        private String Referencia3;
        private String Referencia1_Actualizacion;
        private String Referencia2_Actualizacion;
        private String Referencia3_Actualizacion;
        private String No_Cierre;
        private String Importe;
        private String Concepto2;
        private String No_Venta;
        private String Anio;
        private DateTime Time_Fecha_Inicio;
        private String Caja;
        private String Turno;

        #endregion

        #region Variables publicas
        public DataGridView P_Grid_Ventas
        {
            get { return Grid_Ventas; }
            set { Grid_Ventas = value; }
        }
        public System.Data.DataTable P_Dt_Ventas_Dia
        {
            get { return Dt_Ventas_Dia; }
            set { Dt_Ventas_Dia = value; }
        }
        public System.Data.DataTable P_Dt_Parametros
        {
            get { return Dt_Parametros; }
            set { Dt_Parametros = value; }
        }
        public DataTable P_Dt_Padron_Nuevos
        {
            get { return Dt_Padron_Nuevos; }
            set { Dt_Padron_Nuevos = value; }
        }
        public DataTable P_Dt_Padron_Nuevos_Direcciones
        {
            get { return Dt_Padron_Nuevos_Direcciones; }
            set { Dt_Padron_Nuevos_Direcciones = value; }
        }

        public DataTable P_Dt_Padron_Actualizacion
        {
            get { return Dt_Padron_Actualizacion; }
            set { Dt_Padron_Actualizacion = value; }
        }
        public DataTable P_Dt_Listdeudor_Nuevos
        {
            get { return Dt_Listdeudor_Nuevos; }
            set { Dt_Listdeudor_Nuevos = value; }
        }
        public DataTable P_Dt_Listdeudor_
        {
            get { return Dt_Listdeudor_; }
            set { Dt_Listdeudor_ = value; }
        }
        public DataTable P_Dt_Listas_Deudorcad
        {
            get { return Dt_Listas_Deudorcad; }
            set { Dt_Listas_Deudorcad = value; }
        }
        

        public String P_Rfc
        {
            get { return Rfc; }
            set { Rfc = value; }
        }
        public String P_Anio
        {
            get { return Anio; }
            set { Anio = value; }
        }
        
        public String P_Curp
        {
            get { return Curp; }
            set { Curp = value; }
        }
        public String P_Numero_Venta
        {
            get { return Numero_Venta; }
            set { Numero_Venta = value; }
        }
        public string P_Cuenta_Momias
        {
            get { return Cuenta_Momias; }
            set { Cuenta_Momias = value; }
        }
        public string P_Fecha_Venta
        {
            get { return Fecha_Venta; }
            set { Fecha_Venta = value; }
        }
        public string P_Lista
        {
            get { return Lista; }
            set { Lista = value; }
        }
        public string P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public string P_Sobrante
        {
            get { return Sobrante; }
            set { Sobrante = value; }
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
        public string P_Lista_Parametros
        {
            get { return Lista_Parametros; }
            set { Lista_Parametros = value; }
        }
        public string P_Tipo_Parametro
        {
            get { return Tipo_Parametro; }
            set { Tipo_Parametro = value; }
        }
        public string P_No_Turno
        {
            get { return No_Turno; }
            set { No_Turno = value; }
        }
        public Boolean P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public DataTable P_Dt_Solicitud
        {
            get { return Dt_Solicitud; }
            set { Dt_Solicitud = value; }
        }
        public DataTable P_Dt_Ventas_Clasificacion
        {
            get { return Dt_Ventas_Clasificacion; }
            set { Dt_Ventas_Clasificacion = value; }
        }
        public Double P_Total_Venta
        {
            get { return Total_Venta; }
            set { Total_Venta = value; }
        }

        public string P_Imagen_Bits
        {
            get { return Imagen_Bits; }
            set { Imagen_Bits = value; }
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
        public string P_Referencia3
        {
            get { return Referencia3; }
            set { Referencia3 = value; }
        }

        public string P_Referencia1_Actualizacion
        {
            get { return Referencia1_Actualizacion; }
            set { Referencia1_Actualizacion = value; }
        }
        public string P_Referencia2_Actualizacion
        {
            get { return Referencia2_Actualizacion; }
            set { Referencia2_Actualizacion = value; }
        }
        public string P_Referencia3_Actualizacion
        {
            get { return Referencia3_Actualizacion; }
            set { Referencia3_Actualizacion = value; }
        }

        public string P_No_Cierre
        {
            get { return No_Cierre; }
            set { No_Cierre = value; }
        }

        public string P_Importe
        {
            get { return Importe; }
            set { Importe = value; }
        }
        public string P_Concepto2
        {
            get { return Concepto2; }
            set { Concepto2 = value; }
        }
        public string P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public DateTime P_Time_Fecha_Inicio
        {
            get { return Time_Fecha_Inicio; }
            set { Time_Fecha_Inicio = value; }
        }

        public string P_Caja
        {
            get { return Caja; }
            set { Caja = value; }
        }
        public string P_Turno
        {
            get { return Turno; }
            set { Turno = value; }
        }
        #endregion

        #region Insercion

        public void Insertar_Solicitud() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Solicitud(this); }
        public void Insertar_Solicitud_Local() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Solicitud_Local(this); }
        public void Insertar_Solicitud_Catalogo_Listas() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Solicitud_Catalogo_Listas(this); }
        public Boolean Actualizar_Estatus_Facturacion() {return Cls_Ope_Solicitud_Facturacion_Datos.Actualizar_Estatus_Facturacion(this); }
        public void Insertar_Historico() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Historico(this); }
        public void Insertar_Solicitud_Ventas_Dia() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Solicitud_Ventas_Dia(this); }
        public void Insertar_Solicitud_Ventas_Dia_Catalogo() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Solicitud_Ventas_Dia_Catalogo(this); }
        public void Insertar_Ventas_Dia_Internet() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Ventas_Dia_Internet(this); }
        public void Insertar_Sobrante_Caja() { Cls_Ope_Solicitud_Facturacion_Datos.Insertar_Sobrante_Caja(this); }
        public void Eliminar_Solicitud_Ventas_Dia() { Cls_Ope_Solicitud_Facturacion_Datos.Eliminar_Solicitud_Ventas_Dia(this); }
        public void Enviar_Ventas_Dia() { Cls_Ope_Solicitud_Facturacion_Datos.Enviar_Ventas_Dia(this); }
        public void Enviar_Ventas_Dia_Internet() { Cls_Ope_Solicitud_Facturacion_Datos.Enviar_Ventas_Dia_Internet(this); }
        public void Actualizar_Historico() { Cls_Ope_Solicitud_Facturacion_Datos.Actualizar_Historico(this); }
        public void Actualizar_Venta() { Cls_Ope_Solicitud_Facturacion_Datos.Actualizar_Venta(this); }

        public void Actualizar_Referencias_Locales() { Cls_Ope_Solicitud_Facturacion_Datos.Actualizar_Referencias_Locales(this); }
        public void Actualizar_Referencias_Adeudos_Locales() { Cls_Ope_Solicitud_Facturacion_Datos.Actualizar_Referencias_Adeudos_Locales(this); }
        #endregion

        #region Consultas
        public System.Data.DataTable Consultar_Contribuyente() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Contribuyente(this); }
        public System.Data.DataTable Consultar_Contribuyente_Unico() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Contribuyente_Unico(this); }
        public System.Data.DataTable Consultar_Contribuyente_Local() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Contribuyente_Local(this); }
        public System.Data.DataTable Consultar_Contribuyente_Unico_Local() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Contribuyente_Unico_Local(this); }
        public System.Data.DataTable Consultar_Venta() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Venta(this); }
        public System.Data.DataTable ConsultarPagos_Venta_Individual() { return Cls_Ope_Solicitud_Facturacion_Datos.ConsultarPagos_Venta_Individual(this); }
        public System.Data.DataTable Consultar_Tabla_Adeudos() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Tabla_Adeudos(this); }
        public System.Data.DataTable Consultar_Nuevos_Usuarios_Padron() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Nuevos_Usuarios_Padron(this); }
        public System.Data.DataTable Consultar_Nuevos_Usuarios_Direcciones_Padron() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Nuevos_Usuarios_Direcciones_Padron(this); }
        public System.Data.DataTable Consultar_Nuevos_Usuarios_Listadeudor() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Nuevos_Usuarios_Listadeudor(this); }
        public System.Data.DataTable Consultar_Cambios_Padron() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Cambios_Padron(this); }
        public System.Data.DataTable Consultar_Historico() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Historico(this); }
        public System.Data.DataTable Consultar_Historico_Incluyendo_Dia_Actual() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Historico_Incluyendo_Dia_Actual(this); }
        public System.Data.DataTable Consultar_Nuevos_Listadeudor() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Nuevos_Listadeudor(this); }
        public System.Data.DataTable Consultar_Venta_Internet() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Venta_Internet(this); }

        public System.Data.DataTable Consultar_Venta_Internet_Registradas_Deudorcad() { return Cls_Ope_Solicitud_Facturacion_Datos.Consultar_Venta_Internet_Registradas_Deudorcad(this); }
        #endregion
    }
}
