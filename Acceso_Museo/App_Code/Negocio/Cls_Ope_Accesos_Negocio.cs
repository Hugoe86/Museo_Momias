using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Acceso_Museo.App_Code.Datos;

namespace Acceso_Museo.App_Code.Negocio
{
    class Cls_Ope_Accesos_Negocio
    {
        #region Variables Internas

        private const string Caracteres_Validos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private int Cantidad_Caracteres = Caracteres_Validos.Length;
        // se recomienda crear en este nivel para evitar que múltiples llamadas al método en el mismo espacio de tiempo generen el mismo resultado
        private Random Aleatortio = new Random();

        private String No_Acceso = String.Empty;
        private String No_Venta = String.Empty;
        private String Producto_ID = String.Empty;
        private String Terminal_ID = String.Empty;
        private String Numero_Serie = String.Empty;
        private String Byts_Numero_Serie = String.Empty;
        private DateTime Vigencia_Inicio = DateTime.MinValue;
        private DateTime Vigencia_Fin = DateTime.MinValue;
        private String Estatus = String.Empty;
        private DateTime Fecha_Hora_Acceso = DateTime.MinValue;
        private DateTime Fecha_Hora_Salida = DateTime.MinValue;
        private String Tipo = String.Empty;
        private String Usuario = String.Empty;
        private DateTime Fecha = DateTime.MinValue;

        #endregion Variables Internas

        #region Variables Publicas

        public String P_No_Acceso
        {
            get { return No_Acceso; }
            set { No_Acceso = value; }
        }
        public String P_No_Venta
        {
            get { return No_Venta; }
            set { No_Venta = value; }
        }
        public String P_Producto_ID
        {
            get { return Producto_ID; }
            set { Producto_ID = value; }
        }
        public String P_Terminal_ID
        {
            get { return Terminal_ID; }
            set { Terminal_ID = value; }
        }
        public String P_Numero_Serie
        {
            get { return Numero_Serie; }
            set { Numero_Serie = value; }
        }
        public String P_Byts_Numero_Serie
        {
            get { return Byts_Numero_Serie; }
            set { Byts_Numero_Serie = value; }
        }
        public DateTime P_Vigencia_Inicio
        {
            get { return Vigencia_Inicio; }
            set { Vigencia_Inicio = value; }
        }
        public DateTime P_Vigencia_Fin
        {
            get { return Vigencia_Fin; }
            set { Vigencia_Fin = value; }
        }
        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public DateTime P_Fecha_Hora_Acceso
        {
            get { return Fecha_Hora_Acceso; }
            set { Fecha_Hora_Acceso = value; }
        }
        public DateTime P_Fecha_Hora_Salida
        {
            get { return Fecha_Hora_Salida; }
            set { Fecha_Hora_Salida = value; }
        }
        public String P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
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

        #endregion Variables Publicas

        #region Metodos

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Actualizar_Estatus_Acceso
        ///DESCRIPCIÓN: Actualiza el estatus y/o fechas de acceso para un número de serie dado o un no_acceso
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 15-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Actualizar_Estatus_Acceso()
        {
            Cls_Ope_Accesos_Datos.Actualizar_Estatus_Acceso(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Accesos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Accesos()
        {
            return Cls_Ope_Accesos_Datos.Consultar_Accesos(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Consultar_Accesos_Apertura()
        {
            Cls_Ope_Accesos_Datos.Consultar_Accesos_Apertura();
        }

        #endregion Metodos
    }
}
