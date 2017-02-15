using System;
using System.Data;
using System.Data.SqlClient;

namespace Erp.Helper
{
    public class SqlServerHelper : HelperGenerico
    {
        public string Cadena_Conexion_Sql
        {
            get
            {
                if (Helper_Cadena_Conexion.Length == 0)
                {
                    if (Helper_Base.Length != 0 && Helper_Servidor.Length != 0)
                    {
                        var sCadena = new System.Text.StringBuilder("");
                        sCadena.Append("data source=<SERVIDOR>;");
                        sCadena.Append("initial catalog=<BASE>;");
                        sCadena.Append("user id=<USER>;");
                        sCadena.Append("password=<PASSWORD>;");
                        sCadena.Append("persist security info=True;");
                        sCadena.Append("user id=sa;packet size=4096");
                        sCadena.Replace("<SERVIDOR>", P_Servidor);
                        sCadena.Replace("<BASE>", P_Base);
                        sCadena.Replace("<USER>", P_Usuario);
                        sCadena.Replace("<PASSWORD>", P_Password);
 
                        return sCadena.ToString();
                    }
                    throw new Exception("No se puede establecer la cadena de conexión en la clase SQLServer");
                }
                return Helper_Cadena_Conexion = Cadena_Conexion_Sql;
            }
            set
            {
                Helper_Cadena_Conexion = value;
            } 
        }

        protected override IDbDataAdapter Ejecutar_DataAdapter(string comandoSql)
        {
            var da = new SqlDataAdapter((SqlCommand)Comando(comandoSql));
            return da;
        }

        protected override IDbCommand Comando(string comandoSql)
        {
            var com = new SqlCommand(comandoSql, (SqlConnection)Helper_Conexion, (SqlTransaction)Helper_Transaccion);
            return com;
        }

        protected override IDbConnection Crear_Conexion(string cadenaConexion)
        {
            return new SqlConnection(cadenaConexion); 
        }

        public SqlServerHelper()
        {
            P_Base = "";
            P_Servidor = "";
            P_Usuario = "";
            P_Password = "";
        }
 
        public SqlServerHelper(string cadenaConexion)
        {
            Cadena_Conexion_Sql = cadenaConexion; 
        }
 
        public SqlServerHelper(string servidor, string @base)
        {
            P_Base = @base;
            P_Servidor = servidor;
        }
 
        public SqlServerHelper(string servidor, string @base, string usuario, string password)
        {
            P_Base = @base;
            P_Servidor = servidor;
            P_Usuario = usuario;
            P_Password = password;
            Helper_Conexion = Crear_Conexion(Cadena_Conexion_Sql);
        }
    }
} 