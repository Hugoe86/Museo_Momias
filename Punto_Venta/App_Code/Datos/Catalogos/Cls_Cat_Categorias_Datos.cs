using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Erp.Constantes;
using MySql.Data.MySqlClient;
using ERP_BASE.App_Code.Negocio.Catalogos;
using ERP_BASE.Paginas.Paginas_Generales;

namespace ERP_BASE.App_Code.Datos.Catalogos
{
    public class Cls_Cat_Categorias_Datos
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Negocio"></param>
        public static void Actualizar(Cls_Cat_Categorias_Negocio Negocio)
        { 
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                Mi_Sql.Append("UPDATE cat_categorias ");
                Mi_Sql.Append("SET Nombre = '" + Negocio.P_Nombre + "' ");
                Mi_Sql.Append("WHERE catergoria_id='" + Negocio.P_Categoría_ID + "'");

                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_Sql.ToString();
                    Cmd.ExecuteNonQuery();
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
        /// <returns></returns>
        public static DataTable Cargar()
        {
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                Mi_Sql.Append("SELECT * FROM cat_categorias");

                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_Sql.ToString();

                    using (MySqlDataAdapter Adap = new MySqlDataAdapter(Cmd))
                    {
                        DataTable Resultados = new DataTable();
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
        /// <param name="Negocio"></param>
        public static void Guardar(Cls_Cat_Categorias_Negocio Negocio)
        {
            StringBuilder Mi_Sql = new StringBuilder();

            try
            {
                if (string.IsNullOrEmpty(Negocio.P_Nombre))
                {
                    throw new Exception("Debe asignar la propiedad P_Nombre");
                }

                Mi_Sql.Append("INSERT INTO cat_categorias ");
                Mi_Sql.Append("select");
	            Mi_Sql.Append("    right(concat('00000',");
	            Mi_Sql.Append("    cast(ifnull(max(catergoria_id), 0) + 1 as char(5))), 5) Cat_ID,");
                Mi_Sql.Append("    '" + Negocio.P_Nombre + "',");
                Mi_Sql.Append("    '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "',");
                Mi_Sql.Append("    now(),");
                Mi_Sql.Append("    null,");
                Mi_Sql.Append("    null ");
                Mi_Sql.Append("from");
                Mi_Sql.Append("    cat_categorias");

                using (MySqlConnection Con = new MySqlConnection(Cls_Constantes.Cadena_Conexion))
                using (MySqlCommand Cmd = new MySqlCommand())
                {
                    Con.Open();

                    Cmd.Connection = Con;
                    Cmd.CommandText = Mi_Sql.ToString();

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
