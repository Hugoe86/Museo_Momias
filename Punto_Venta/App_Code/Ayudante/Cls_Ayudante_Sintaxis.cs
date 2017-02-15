using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Erp.Constantes;

namespace Erp.Ayudante_Sintaxis
{
    public class Cls_Ayudante_Sintaxis
    {
        /// ************************************************************************************
        /// Nombre          : Fecha
        /// Descripción     : Identifica el Gestor de Base de Datos y selecciona su sintaxis.
        /// Parámetros      :
        /// Usuario Creo    : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó      : 11/Febrero/2013
        /// Usuario Modifico:
        /// Fecha Modifico  :
        /// ***********************************************************************************
        public static String Fecha()
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "GETDATE()"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "NOW()"; //Se asigna a la variable la sintaxis de MYSQL
                    break;

                case "OracleClient":
                    Valor = "SYSDATE"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }
            return Valor; //Retorna el valor a la clase de datos
        }//end Fecha

        /// ****************************************************************************************************
        /// Nombre          : Formato_Fecha
        /// Descripción     : Identifica el Gestor de Base de Datos y selecciona su sintaxis.
        /// Parámetros      : Format.- Contiene los parametros a los cuales se les aplicara el tipo de sintacis
        /// Usuario Creo    : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó      : 12/Febrero/2013
        /// Usuario Modifico:
        /// Fecha Modifico  :
        /// ****************************************************************************************************
        public static String Formato_Fecha(string Formato)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "FORMAT(" + Formato + ")"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "DATE_FORMAT(" + Formato + ")"; //Se asigna a la variable la sintaxis de MYSQL
                    break;

                case "OracleClient":
                    Valor = "TO_DATE(" + Formato + "')"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }
            return Valor; //Retorna el valor a la clase de datos
        }//end Formato_Fecha

        /// ****************************************************************************************************
        /// Nombre          : Insertar_Fecha
        /// Descripción     : Identifica el Gestor de Base de Datos y selecciona su sintaxis.
        /// Parámetros      : Format.- Contiene los parametros a los cuales se les aplicara el tipo de sintacis
        /// Usuario Creo    : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó      : 12/Febrero/2013
        /// Usuario Modifico:
        /// Fecha Modifico  :
        /// ****************************************************************************************************
        ///
        public static String Insertar_Fecha(DateTime Fecha)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;

            switch (Gestor)
            {
                case "SqlClient":
                case "SQL":
                    Valor = "'" + Fecha.ToString("yyyyMMdd") + "'"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "'" + Fecha.ToString("yyyy-MM-dd") + "'"; //Se asigna a la variable la sintaxis de MYSQL
                    break;

                case "OracleClient":
                    Valor = "'" + Fecha.ToString("d-M-yyyy") + "'"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }
            return Valor; //Retorna el valor a la clase de datos
        }//end Insertar_Fecha

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Insertar_Fecha_Hora
        ///DESCRIPCIÓN: Da formato de fecha y hora al parámetro recibido dependiendo del gestor de BD y lo regresa como string
        ///PARÁMETROS:
        /// 		1. Fecha: variable datetime con el dato a formatear
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static String Insertar_Fecha_Hora(DateTime Fecha)
        {
            String Valor = "";
            String Gestor = Cls_Constantes.Gestor_Base_Datos;

            switch (Gestor)
            {
                case "SQL":
                case "SqlClient":
                    Valor = "'" + Fecha.ToString("yyyyMMdd HH:mm:ss") + "'"; //Se asigna a la variable la sintaxis de SQL
                    break;
                case "OracleClient":
                    // es recomendable utilizar to_date porque si no, oracle hace una conversión implícita que depende de NLS_DATE_FORMAT en la instalación local
                    Valor = "to_date('" + Fecha.ToString("yyyy/MM/dd HH:mm") + "', 'yyyy/mm/dd hh24:mi')"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
                case "MySqlClient":
                    Valor = "'" + Fecha.ToString("yyyy-MM-dd HH:mm:ss") + "'"; //Se asigna a la variable la sintaxis de MYSQL
                    break;
            }

            return Valor;
        }
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Insertar_Fecha_Hora
        ///DESCRIPCIÓN: Da formato de fecha y hora al parámetro recibido dependiendo del gestor de BD y lo regresa como string
        ///PARÁMETROS:
        /// 		1. Fecha: variable datetime con el dato a formatear
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static String Insertar_Hora(DateTime Fecha)
        {
            String Valor = "";
            String Gestor = Cls_Constantes.Gestor_Base_Datos;

            switch (Gestor)
            {
                case "SQL":
                case "SqlClient":
                    Valor = "'" + Fecha.ToString("HH:mm:ss") + "'"; //Se asigna a la variable la sintaxis de SQL
                    break;
                case "OracleClient":
                    // es recomendable utilizar to_date porque si no, oracle hace una conversión implícita que depende de NLS_DATE_FORMAT en la instalación local
                    Valor = "to_date('" + Fecha.ToString("HH:mm") + "', 'yyyy/mm/dd hh24:mi')"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
                case "MySqlClient":
                    Valor = "'" + Fecha.ToString("HH:mm:ss") + "'"; //Se asigna a la variable la sintaxis de MYSQL
                    break;
            }

            return Valor;
        }
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Insertar_Default_Database_Collate
        ///DESCRIPCIÓN: Regresa un string con el texto collate DATABASE_DEFAULT cuando el manejador de base de 
        ///             datos es SQL server
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static String Insertar_Default_Database_Collate()
        {
            String Valor = "";
            String Gestor = Cls_Constantes.Gestor_Base_Datos;

            // si el gestor de base de datos es SQL Server, asignar valor
            if (Gestor == "SqlClient" || Gestor == "SQL")
            {
                Valor = " collate DATABASE_DEFAULT ";
            }

            return Valor;
        }

        /// ****************************************************************************************************
        /// Nombre          : Conversiones
        /// Descripción     : Identifica el Gestor de Base de Datos y selecciona su sintaxis.
        /// Parámetros      : Convert.- Contiene los parametros a los cuales se les aplicara el tipo de sintacis
        ///                   Tipo.- Contiene el tipo de conversión para ORACLE
        /// Usuario Creo    : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó      : 12/Febrero/2013
        /// Usuario Modifico:
        /// Fecha Modifico  :
        /// ****************************************************************************************************
        public static String Conversiones(string Campo_Convertir, string Tipo)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "Convert(" + Campo_Convertir + ",103)"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "CAST(" + Campo_Convertir + ")"; //Se asigna a la variable la sintaxis de MYSQL
                    break;

                case "OracleClient":
                    Valor = "TO_" + Tipo + "(" + Campo_Convertir + ")"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }

            return Valor; //Retorna el valor a la clase de datos
        }//end Formato

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Convertir_A_Caracter
        ///DESCRIPCIÓN: Genera una cadena de texto con el formato SQL para convertir el campo recibido como
        ///             parámetro a tipo caracter dependiendo del gestor de base de datos utilizado
        ///PARÁMETROS:
        /// 		1. Campo_Convertir: nombre del campo a convertir
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 27-nov-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static String Convertir_A_Caracter(string Campo_Convertir)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "cast(" + Campo_Convertir + " AS VARCHAR)"; //Se asigna a la variable la sintaxis de SQLServer
                    break;

                case "MySqlClient":
                    Valor = "cast(" + Campo_Convertir + " AS CHAR)"; // en el caso de mysql se pasa igual
                    break;

                case "OracleClient":
                    Valor = "TO_CHAR(" + Campo_Convertir + ")"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }

            return Valor; //Retorna el valor a la clase de datos
        }//end Convertir_A_Caracter

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Convertir_A_Entero
        ///DESCRIPCIÓN: Genera una cadena de texto con el formato SQL para convertir el campo recibido como
        ///             parámetro a tipo entero dependiendo del gestor de base de datos utilizado
        ///PARÁMETROS:
        /// 		1. Campo_Convertir: nombre del campo a convertir
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 27-nov-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static String Convertir_A_Entero(string Campo_Convertir)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "convert(integer, " + Campo_Convertir + ")"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "cast(" + Campo_Convertir + " AS SIGNED)"; // en el caso de mysql se utiliza SIGNED
                    break;

                case "OracleClient":
                    Valor = "TO_NUMBER(" + Campo_Convertir + ")"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }

            return Valor; //Retorna el valor a la clase de datos
        }//end Convertir_A_Entero

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Convertir_A_Decimal
        ///DESCRIPCIÓN: Genera una cadena de texto con el formato SQL para convertir el campo recibido como
        ///             parámetro a tipo decimal dependiendo del gestor de base de datos utilizado
        ///PARÁMETROS:
        /// 		1. Campo_Convertir: nombre del campo a convertir
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 24-fub-2014
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static String Convertir_A_Decimal(string Campo_Convertir)
        {
            String Valor = ""; // variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "convert(DECIMAL, " + Campo_Convertir + ")"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "cast(" + Campo_Convertir + " AS DECIMAL)"; // en el caso de mysql se utiliza SIGNED
                    break;

                case "OracleClient":
                    Valor = "TO_NUMBER(" + Campo_Convertir + ")"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }

            return Valor;
        }//end Convertir_A_Decimal

        /// ****************************************************************************************************
        /// Nombre          : Nulos
        /// Descripción     : Genera la sintaxis para validar valores nulos dependiendo del manejador de 
        ///                 base de datos seleccionado
        /// Parámetros      : 
        /// 		        1. Campo: nombre del campo a validar si contiene valor nulo
        /// 		        2. Valor_Si_Nulo: contiene el valor para 
        /// Usuario Creo    : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó      : 12/Febrero/2013
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico  : 19-feb-2014
        ///CAUSA_MODIFICACIÓN: Se corrige la función para el caso MySqlClient con IFNULL en lugar de ISNULL
        ///                 y se agrega como parámetro el nombre del campo
        /// ****************************************************************************************************
        public static String Nulos(string Campo, string Valor_Si_Nulo)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "ISNULL(" + Campo + "," + Valor_Si_Nulo + ")"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "IFNULL(" + Campo + "," + Valor_Si_Nulo + ")"; //Se asigna a la variable la sintaxis de MYSQL
                    break;

                case "OracleClient":
                    Valor = "NVL(" + Campo + "," + Valor_Si_Nulo + ")"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }

            return Valor; //Retorna el valor a la clase de datos
        }//end Formato

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Concatenar
        ///DESCRIPCIÓN: Genera una cadena de texto con el SQL para concatenar los elementos contenidos en
        ///             Lista_Parametros, dependiendo del gestor de base de datos utilizado
        ///PARÁMETROS:
        /// 		1. Lista_Parametros: listado de elementos a concatenar
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 27-nov-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static String Concatenar(List<string> Lista_Parametros)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            string Operador = "";
            switch (Gestor)
            {
                case "SqlClient":
                    // recorrer la lista de elementos 
                    foreach (string elemento in Lista_Parametros)
                    {
                        Valor += Operador + elemento;
                        Operador = " + ";
                    }
                    break;

                case "MySqlClient":
                    foreach (string elemento in Lista_Parametros)
                    {
                        Valor += Operador + elemento;
                        Operador = ", ";
                    }
                    Valor = "CONCAT(" + Valor + ")";
                    break;

                case "OracleClient":
                    foreach (string elemento in Lista_Parametros)
                    {
                        Valor += Operador + elemento;
                        Operador = " || ";
                    }
                    break;
            }

            return Valor; //Retorna el valor a la clase de datos
        }//end Concatenar

        /// ****************************************************************************************************
        /// Nombre          : Condiciones
        /// Descripción     : Identifica el Gestor de Base de Datos y selecciona su sintaxis.
        /// Parámetros      : Nulo.- Contiene los parametros a los cuales se les aplicara el tipo de sintacis
        /// Usuario Creo    : Miguel Angel Alvarado Enriquez.
        /// Fecha Creó      : 12/Febrero/2013
        /// Usuario Modifico:
        /// Fecha Modifico  :
        /// ****************************************************************************************************
        public static String Condiciones(string Condicion)
        {
            String Valor = ""; //Variable que almacena el tipo de sintaxis.
            String Gestor = Cls_Constantes.Gestor_Base_Datos;
            switch (Gestor)
            {
                case "SqlClient":
                    Valor = "CASE " + Condicion + " END"; //Se asigna a la variable la sintaxis de SQL
                    break;

                case "MySqlClient":
                    Valor = "DECODE(" + Condicion + ")"; //Se asigna a la variable la sintaxis de MYSQL
                    break;

                case "OracleClient":
                    Valor = "CASE " + Condicion + " END CASE"; //Se asigna a la variable la sintaxis de ORACLE
                    break;
            }

            return Valor; //Retorna el valor a la clase de datos
        }//end Formato
    }// end class Cls_Ayudante_Sintaxis
}// end namespace Erp.Cls_Ayudante_Sintaxis