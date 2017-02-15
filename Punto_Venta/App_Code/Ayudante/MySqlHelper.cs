using System;
using System.Data;
using MySql.Data.MySqlClient;
 
namespace Erp.Helper
{
    public class MysqlHelper : HelperGenerico
    {
        public string Cadena_Conexion_Mysql
        {
            get
            {
                if (Helper_Cadena_Conexion.Length == 0)
                {
                    if (Helper_Base.Length != 0 && Helper_Servidor.Length != 0)
                    {
                        var Cadena = new System.Text.StringBuilder("");
                        Cadena.Append("Server=<SERVIDOR>;");
                        Cadena.Append("Database=<BASE>;");
                        Cadena.Append("Uid=<USER>;");
                        Cadena.Append("Pwd=<PASSWORD>;");
                        Cadena.Replace("<SERVIDOR>", P_Servidor);
                        Cadena.Replace("<BASE>", P_Base);
                        Cadena.Replace("<USER>", P_Usuario);
                        Cadena.Replace("<PASSWORD>", P_Password);
 
                        return Cadena.ToString();
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase Mysql");
                }
                return Helper_Cadena_Conexion = Cadena_Conexion_Mysql;
            }
            set
            {
                Helper_Cadena_Conexion = value;
            }
        }

        protected override IDbDataAdapter Ejecutar_DataAdapter(string ComandoSql)
        {
            var da = new MySqlDataAdapter((MySqlCommand)Comando(ComandoSql));
            return da;
        }

        protected override IDbCommand Comando(string ComandoSql)
        {
            var com = new MySqlCommand(ComandoSql, (MySqlConnection)Helper_Conexion, (MySqlTransaction)Helper_Transaccion);
            return com;
        }

        protected override IDbConnection Crear_Conexion(string Cadena_Conexion)
        {
            return new MySqlConnection(Cadena_Conexion);
        }
        
        public MysqlHelper()
        {
            P_Base = "";
            P_Servidor = "";
            P_Usuario = "";
            P_Password = "";
        }
 
        public MysqlHelper(string cadenaConexion)
        {
            Cadena_Conexion_Mysql = cadenaConexion;
        }

        public MysqlHelper(string servidor, string @base)
        {
            P_Base = @base;
            P_Servidor = servidor;
        }

        public MysqlHelper(string servidor, string @base, string usuario, string password)
        {
            P_Base = @base;
            P_Servidor = servidor;
            P_Usuario = usuario;
            P_Password = password;
            Helper_Conexion = Crear_Conexion(Cadena_Conexion_Mysql);
        }
    }
} 