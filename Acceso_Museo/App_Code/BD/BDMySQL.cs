using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Acceso_Museo.App_Code.BD
{
    /// <summary>
    /// 
    /// </summary>
    public class BDMySQL
    {
        /// <summary>
        /// 
        /// </summary>
        string Conexion = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public BDMySQL()
        { 
            Conexion = ConfigurationManager.ConnectionStrings["Gestor"].ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        public DataTable Consultar(string Query)
        {
            try
            {
                DataTable Resultados = new DataTable();

                using(MySqlConnection Con = new MySqlConnection(Conexion))
                using (MySqlCommand Cmd = Con.CreateCommand())
                {
                    Cmd.CommandText = Query;
                    using (MySqlDataAdapter Adap = new MySqlDataAdapter(Cmd))
                    {
                        Adap.Fill(Resultados);

                        return Resultados;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Query"></param>
        public void Cambiar(string Query)
        {
            try
            {
                using (MySqlConnection Con = new MySqlConnection(Conexion))
                using (MySqlCommand Cmd = Con.CreateCommand())
                {
                    Con.Open();
                    Cmd.CommandText = Query;
                    Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
