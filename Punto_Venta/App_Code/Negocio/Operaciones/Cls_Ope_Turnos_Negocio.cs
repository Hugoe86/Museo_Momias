using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Operaciones.Turnos.Datos;
using System.Data;

namespace Operaciones.Turnos.Negocio
{
    public class Cls_Ope_Turnos_Negocio
    {
        #region Variables_Privadas
        private String No_Turno;
        private String Turno_ID;
        private DateTime Fecha_Hora_Inicio;
        private DateTime Fecha_Hora_Cierre;
        private String Estatus;
        private String Usuario;
        private DateTime Desde_Fecha;
        private DateTime Hasta_Fecha;
        private Boolean Estatus_Ventas_Enviadas = false;
        private DataTable Dt_Ventas_Dia;
        private DataTable Dt_Parametros;
        private DataTable Dt_Padron_Nuevos;
        private DataTable Dt_Padron_Actualizacion;
        private DataTable Dt_Listdeudor_Nuevos;
        private DataTable Dt_Listdeudor_;
        private System.Data.DataTable Dt_Padron_Nuevos_Direcciones; 
        private String Fecha_Venta;
        private DateTime Dtime_Fecha;
        #endregion

        #region Metodos_Acceso_Publico
        public String P_No_Turno
        {
            get { return No_Turno; }
            set { No_Turno = value; }
        }
        public String P_Turno_ID
        {
            get { return Turno_ID; }
            set { Turno_ID = value; }
        }
        public DateTime P_Fecha_Hora_Inicio
        {
            get { return Fecha_Hora_Inicio; }
            set { Fecha_Hora_Inicio = value; }
        }
        public DateTime P_Fecha_Hora_Cierre
        {
            get { return Fecha_Hora_Cierre; }
            set { Fecha_Hora_Cierre = value; }
        }
        public String P_Fecha_Venta
        {
            get { return Fecha_Venta; }
            set { Fecha_Venta = value; }
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
        public DateTime P_Desde_Fecha
        {
            get { return Desde_Fecha; }
            set { Desde_Fecha = value; }
        }
        public DateTime P_Hasta_Fecha
        {
            get { return Hasta_Fecha; }
            set { Hasta_Fecha = value; }
        }
        public Boolean P_Estatus_Ventas_Enviadas
        {
            get { return Estatus_Ventas_Enviadas; }
            set { Estatus_Ventas_Enviadas = value; }
        }
        public DataTable P_Dt_Ventas_Dia
        {
            get { return Dt_Ventas_Dia; }
            set { Dt_Ventas_Dia = value; }
        }
        public DataTable P_Dt_Parametros
        {
            get { return Dt_Parametros; }
            set { Dt_Parametros = value; }
        }
        public DataTable P_Dt_Padron_Nuevos
        {
            get { return Dt_Padron_Nuevos; }
            set { Dt_Padron_Nuevos = value; }
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

        public DataTable P_Dt_Padron_Nuevos_Direcciones
        {
            get { return Dt_Padron_Nuevos_Direcciones; }
            set { Dt_Padron_Nuevos_Direcciones = value; }
        }

        public DateTime P_Dtime_Fecha
         {
             get { return Dtime_Fecha; }
             set { Dtime_Fecha = value; }
         }
        #endregion

        #region Metodos

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Alta_Turno
        ///DESCRIPCIÓN: Manda llamar el método de Alta_Turno de la clase de datos y regresa la cantidad 
        ///             de registros dados de alta
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public int Alta_Turno()
        {
            return Cls_Ope_Turnos_Datos.Alta_Turno(this);
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Actualizar_Turno
        ///DESCRIPCIÓN: Manda llamar el método de Actualizar_Turno de la clase de datos y regresa la cantidad 
        ///             de registros dados de alta
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public int Actualizar_Turno()
        {
            return Cls_Ope_Turnos_Datos.Actualizar_Turno(this);
        }
        
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Cierre_Turno_Fuera_Fecha
        ///DESCRIPCIÓN: Manda llamar el método de Actualizar_Turno de la clase de datos y regresa la cantidad 
        ///             de registros dados de alta
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Cierre_Turno_Fuera_Fecha()
        {
            Cls_Ope_Turnos_Datos.Cierre_Turno_Fuera_Fecha(this);
        }

        
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Turnos
        ///DESCRIPCIÓN: Manda llamar el método de Consultar_Turnos de la clase de datos y regresa un datatable
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public DataTable Consultar_Turnos()
        {
            return Cls_Ope_Turnos_Datos.Consultar_Turnos(this);
        }
           ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Existencia_Turnos
        ///DESCRIPCIÓN: Manda llamar el método de Consultar_Turnos de la clase de datos y regresa un datatable
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public DataTable Consultar_Existencia_Turnos()
        {
            return Cls_Ope_Turnos_Datos.Consultar_Existencia_Turnos(this);
        }

        
        #endregion

    }
}
