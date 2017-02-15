using System;
using System.Data;
using System.Data.OracleClient;

namespace Erp.Helper
{
    public class OracleHelper : HelperGenerico
    {
        public new string Cadena_Conexion_Oracle
        {
            get
            {
                if (Helper_Cadena_Conexion.Length == 0)
                {
                    if (Helper_Base.Length != 0 && Helper_Servidor.Length != 0)
                    {
                        var Cadena = new System.Text.StringBuilder("");
                        Cadena.Append("Data Source=(DESCRIPTION = (ADDRESS =");
                        Cadena.Append("(PROTOCOL = TCP)(HOST = <SERVIDOR>)(PORT = 1521))");
                        Cadena.Append("(CONNECT_DATA = (SERVER = DEDICATED)");
                        Cadena.Append("(SERVICE_NAME = <BASE>)));");
                        Cadena.Append("Persist Security Info=True;User ID=<USER>;");
                        Cadena.Append("Password=<PASSWORD>;Unicode=True;");
                        Cadena.Replace("<SERVIDOR>", P_Servidor);
                        Cadena.Replace("<BASE>", P_Base);
                        Cadena.Replace("<USER>", P_Usuario);
                        Cadena.Replace("<PASSWORD>", P_Password);
 
                        return Cadena.ToString();
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase SQLServer");
                }
                return Helper_Cadena_Conexion = Cadena_Conexion_Oracle;
            }
            set
            {
                Helper_Cadena_Conexion = value;
            } 
        }

        protected override IDbDataAdapter Ejecutar_DataAdapter(string comandoSql)
        {
            var da = new OracleDataAdapter((OracleCommand)Comando(comandoSql));
            return da;
        }

        protected override IDbCommand Comando(string comandoSql)
        {
            var com = new OracleCommand(comandoSql, (OracleConnection)Helper_Conexion, (OracleTransaction)Helper_Transaccion);
            return com;
        }

        protected override IDbConnection Crear_Conexion(string cadenaConexion)
        {
            return new OracleConnection(cadenaConexion); 
        }

        public OracleHelper()
        {
            P_Base = "";
            P_Servidor = "";
            P_Usuario = "";
            P_Password = "";
        }
 
        public OracleHelper(string cadenaConexion)
        {
            Cadena_Conexion_Oracle = cadenaConexion; 
        }
 
        public OracleHelper(string servidor, string @base)
        {
            P_Base = @base;
            P_Servidor = servidor;
        }

        public OracleHelper(string servidor, string @base, string usuario, string password)
        {
            P_Base = @base;
            P_Servidor = servidor;
            P_Usuario = usuario;
            P_Password = password;
            Helper_Conexion = Crear_Conexion(Cadena_Conexion_Oracle);
        }
    }
} 