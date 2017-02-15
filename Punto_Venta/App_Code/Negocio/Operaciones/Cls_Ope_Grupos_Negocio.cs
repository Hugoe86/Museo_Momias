using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ERP_BASE.App_Code.Datos.Operaciones;

namespace ERP_BASE.App_Code.Negocio.Operaciones
{
    public class Cls_Ope_Grupos_Negocio
    {
        #region (Variables Privadas)
        private DataTable Dt_Ventas = null;
        private String No_Venta = String.Empty;
        private Decimal Subtotal = 0;
        private Decimal Impuestos = 0;
        private Decimal Descuentos = 0;
        private Decimal Total = 0;
        private String Estatus = String.Empty;
        private String Motivo_Descuento_Id = String.Empty;
        private String Usuario_Id = String.Empty;
        private String Banco_Id = String.Empty;
        //Grupos
        private DateTime Fecha_Tramite;
        private String Persona_Tramita;
        private String Empresa;
        private DateTime Fecha_Inicio_Vigencia;
        private DateTime Fecha_Termino_Vigencia;
        private String Aplica_Dias_Festivos;
        private string Motivo_Cancelacion;
        #endregion

        #region (Variables Públicas)
        public System.Data.DataTable P_Dt_Ventas
        {
            get { return Dt_Ventas; }
            set { Dt_Ventas = value; }
        }
        public String P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public Decimal P_Subtotal
        {
            get { return Subtotal; }
            set { Subtotal = value; }
        }
        public Decimal P_Impuestos
        {
            get { return Impuestos; }
            set { Impuestos = value; }
        }
        public Decimal P_Descuentos
        {
            get { return Descuentos; }
            set { Descuentos = value; }
        }
        public Decimal P_Total
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
        public DateTime P_Fecha_Tramite
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
        public DateTime P_Fecha_Inicio_Vigencia
        {
            get { return Fecha_Inicio_Vigencia; }
            set { Fecha_Inicio_Vigencia = value; }
        }
        public DateTime P_Fecha_Termino_Vigencia
        {
            get { return Fecha_Termino_Vigencia; }
            set { Fecha_Termino_Vigencia = value; }
        }
        public String P_Aplica_Dias_Festivos
        {
            get { return Aplica_Dias_Festivos; }
            set { Aplica_Dias_Festivos = value; }
        }
        public String P_Motivo_Cancelacion
        {
            get { return Motivo_Cancelacion; }
            set { Motivo_Cancelacion = value; }
        }
        #endregion

        #region (Métodos)
        public bool Alta_Grupo() { return Cls_Ope_Grupos_Datos.Alta_Grupo(this); }
        public bool Actualizar_Grupo() { return Cls_Ope_Grupos_Datos.Actualizar_Grupo(this); }
        public bool Cancelar_Grupo() { return Cls_Ope_Grupos_Datos.Cancelar_Grupo(this); }
        public DataTable Consultar_Grupos() { return Cls_Ope_Grupos_Datos.Consultar_Grupos(this); }
        public DataTable Consultar_Detalles_Grupo() { return Cls_Ope_Grupos_Datos.Consultar_Detalles_Grupo(this); }
        #endregion
    }
}
