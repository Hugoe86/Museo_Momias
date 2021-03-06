﻿using System;
using System.Data;
using Erp_Ope_Accesos.Datos;
using Erp.Constantes;

namespace Erp_Ope_Accesos.Negocio
{
    public class Cls_Ope_Accesos_Negocio
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
        ///NOMBRE_FUNCIÓN: Alta_Acceso
        ///DESCRIPCIÓN: Genera un numero de serie y llama al método de la capa de datos para insertar un acceso
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 15-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public string Alta_Acceso()
        {
            do
            {
                // generar un número de serie
                Numero_Serie = Generar_Cadena_Proteccion(10);
                // repetir si el número generado ya existe
            } while (Cls_Ope_Accesos_Datos.Consultar_Existe_Serie(Numero_Serie) == true);
            // dar de alta la serie
            Cls_Ope_Accesos_Datos.Alta_Acceso(this);
            return Numero_Serie;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Alta_Acceso
        ///DESCRIPCIÓN: Se lee la tabla, se inserta un acceso por cada producto y se agrega, separados por coma
        ///             a la columna ACCESOS, se debe especificar el no_venta y opcionalmente, las fechas de vigencia
        ///PARÁMETROS:
        /// 		1. Dt_Venta: Tabla con detalles de la venta
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 16-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public DataTable Alta_Acceso(DataTable Dt_Venta)
        {
            int Cantidad_Producto;
            int Contador;
            string Separador;
            string Numeros_Serie;
            string Codigos = string.Empty;

            // validar que la tabla no sea nulo
            if (Dt_Venta != null)
            {
                // si la tabla no tiene una columna ACCESOS, agregarla
                if (!Dt_Venta.Columns.Contains("ACCESOS"))
                {
                    Dt_Venta.Columns.Add("ACCESOS", typeof(System.String));
                    Dt_Venta.AcceptChanges();
                }
                // recorrer la tabla
                foreach (DataRow Fila_Venta in Dt_Venta.Rows)
                {
                    // obtener la cantidad de productos, validar que sea mayor que cero y que sea de tipo PRODUCTO
                    if (int.TryParse(Fila_Venta["CANTIDAD"].ToString(), out Cantidad_Producto) == true && Cantidad_Producto > 0 && Fila_Venta["TIPO"].ToString().ToUpper().Equals("PRODUCTO"))
                    {
                        Numeros_Serie = "";
                        Separador = "";
                        // generar números de serie
                        for (Contador = 0; Contador < Cantidad_Producto; Contador++)
                        {
                            do
                            {
                                Numero_Serie = Generar_Cadena_Proteccion(10);
                                // repetir si el número generado ya existe
                            } while (Cls_Ope_Accesos_Datos.Consultar_Existe_Serie(Numero_Serie) == true);
                            Numeros_Serie += Separador + Numero_Serie;
                            Separador = ",";

                            // dar de alta el acceso
                            Estatus = "ACTIVO";
                            Producto_ID = Fila_Venta[Cat_Productos.Campo_Producto_Id].ToString();
                            Codigos += Cls_Ope_Accesos_Datos.Alta_Acceso(this) + ",";
                        } //  se generaron los número de serie para la fila actual

                        // actualizar valor de la columna ACCESOS
                        //Fila_Venta["ACCESOS"] = Numeros_Serie;
                        Fila_Venta["ACCESOS"] = Codigos;
                    }
                }
            }

            return Dt_Venta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Acceso
        ///DESCRIPCIÓN          : Modifica un registro
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Acceso()
        {
            Cls_Ope_Accesos_Datos.Modificar_Acceso(this);
        }

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
        public int Actualizar_Estatus_Acceso()
        {
            return Cls_Ope_Accesos_Datos.Actualizar_Estatus_Acceso(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Acceso
        ///DESCRIPCIÓN          : Elimina un registro relacionado en base al No de Operación
        ///PARAMETROS           : 
        ///CREO                 : Antonio Salvador Benavides Guardado
        ///FECHA_CREO           : 03/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Acceso()
        {
            Cls_Ope_Accesos_Datos.Eliminar_Acceso(this);
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

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Generar_Cadena_Proteccion
        ///DESCRIPCIÓN: Genera una cadena de caracteres alfanumérica aleatoria
        ///PARÁMETROS:
        /// 		1. Longitud: cantidad de caracteres de la cadena a generar
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 15-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public string Generar_Cadena_Proteccion(int Longitud)
        {
            // si la longitud solicitada es 0 ó menos asignar 10
            if (Longitud <= 0)
            {
                Longitud = 10;
            }

            char[] Caracteres = new char[Longitud];

            // ciclo para llenar el arreglo de caracteres
            for (int i = 0; i < Caracteres.Length; i++)
            {
                // asignar un caracter aleatorio al 
                Caracteres[i] = Caracteres_Validos[Aleatortio.Next(Cantidad_Caracteres)];
            }

            return new String(Caracteres);
        }

        #endregion Metodos
    }
}