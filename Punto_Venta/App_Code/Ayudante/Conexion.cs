using System.Configuration;
using System;
using Erp.Constantes;

namespace Erp.Helper
{
    public class Conexion
    {
        public static HelperGenerico HelperGenerico;
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Iniciar_Helper
        ///DESCRIPCIÓN: Asigna el Helper Generico 
        ///PARAMENTROS:
        ///CREO: Luis Alberto Salas  Garcia
        ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
        ///MODIFICO:Sergio Manuel Gallardo Andrade
        ///FECHA_MODIFICO:19/Feb/2013 11:27:47 a.m.
        ///CAUSA_MODIFICACIÓN:Se agrego una validacion de conexion
        ///*******************************************************************************
        public static void Iniciar_Helper()
        {
            if (Conexion.HelperGenerico == null)
            {
                switch (Cls_Constantes.Gestor_Base_Datos)
                {
                    case "SqlClient":
                        Conexion.Iniciar_Sesion(Cls_Constantes.Cadena_Conexion.ToString(), Cls_Constantes.Gestor_Base_Datos.ToString());
                        break;
                    case "MySqlClient":
                        Conexion.Iniciar_Sesion(Cls_Constantes.Cadena_Conexion.ToString(), Cls_Constantes.Gestor_Base_Datos.ToString());
                        break;
                    case "OracleClient":
                        Conexion.Iniciar_Sesion(Cls_Constantes.Cadena_Conexion.ToString(), Cls_Constantes.Gestor_Base_Datos.ToString());
                        break;
                }
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Iniciar_Sesion
        ///DESCRIPCIÓN: inicia Session Con el Helper
        ///PARAMENTROS:
        ///CREO: Luis Alberto Salas  Garcia
        ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static bool Iniciar_Sesion(string Nombre_Servidor, string Base_Datos, string Usuario, string Password, string Gestor)
        {
            try
            {
                switch (Gestor)
                {
                    case "SqlClient":
                        HelperGenerico = new SqlServerHelper(Nombre_Servidor, Base_Datos, Usuario, Password);
                        break;
                    case "MySqlClient":
                        HelperGenerico = new MysqlHelper(Nombre_Servidor, Base_Datos, Usuario, Password);
                        break;
                    case "OracleClient":
                        HelperGenerico = new OracleHelper(Nombre_Servidor, Base_Datos, Usuario, Password);
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Iniciar_Sesion
        ///DESCRIPCIÓN: Asigna el Helper Generico 
        ///PARAMENTROS:
        ///CREO: Luis Alberto Salas  Garcia
        ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static bool Iniciar_Sesion(string Cadena_Conexion, string Gestor)
        {
            try
            {
                switch (Gestor)
                {
                    case "SqlClient":
                        HelperGenerico = new SqlServerHelper(Cadena_Conexion);
                        break;
                    case "MySqlClient":
                        HelperGenerico = new MysqlHelper(Cadena_Conexion);
                        break;
                    case "OracleClient":
                        HelperGenerico = new OracleHelper(Cadena_Conexion);
                        break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: FinalizarSesion
        ///DESCRIPCIÓN: Finaliza Session del helper
        ///PARAMENTROS:
        ///CREO: Luis Alberto Salas  Garcia
        ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static void Finalizar_Sesion()
        {
            HelperGenerico.Cerrar_Conexion();
        }
    }
}
