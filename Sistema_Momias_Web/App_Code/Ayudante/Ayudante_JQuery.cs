using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Erp.Constantes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;



namespace Erp.Ayudante_JQuery
{
    public class Ayudante_JQuery
    {
        public static String Crear_Tabla_Formato_JSON_ComboBox(DataTable Dt_Datos)
        {
            StringBuilder Buffer = new StringBuilder();
            StringWriter Escritor = new StringWriter(Buffer);
            JsonWriter Escribir_Formato_JSON = new JsonTextWriter(Escritor);
            String Cadena_Resultado = String.Empty;

            try
            {
                Escribir_Formato_JSON.Formatting = Formatting.None;
                Escribir_Formato_JSON.WriteStartArray();

                if (Dt_Datos is DataTable)
                {
                    if (Dt_Datos.Rows.Count > 0)
                    {
                        foreach (DataRow FILA in Dt_Datos.Rows)
                        {
                            Escribir_Formato_JSON.WriteStartObject();
                            foreach (DataColumn COLUMNA in Dt_Datos.Columns)
                            {
                                if (!String.IsNullOrEmpty(FILA[COLUMNA.ColumnName].ToString()))
                                {
                                    Escribir_Formato_JSON.WritePropertyName(COLUMNA.ColumnName);
                                    Escribir_Formato_JSON.WriteValue(FILA[COLUMNA.ColumnName].ToString());
                                }
                            }
                            Escribir_Formato_JSON.WriteEndObject();
                        }
                    }
                }

                Escribir_Formato_JSON.WriteEndArray();
                Cadena_Resultado = Buffer.ToString();
            }
            catch (Exception)
            {
                throw new Exception("Error al crear la cadena json para cargar un combo.");
            }
            return Cadena_Resultado;
        }

        public static string agregarTotalesGridEasyUI(string contenido, string totales)
        {

            string datos = "{[]}";
            string datos_aux;

            datos_aux = contenido.Substring(0, contenido.Length - 1);
            datos = datos_aux + ",\"footer\":" + "[" + totales + "]}";

            return datos;

        }

        /// *********************************************************************************************************
        /// Nombre: Crear_Tabla_Formato_JSON
        /// 
        /// Descripción: Método que devuelve la estructura de una cadena en formato JSON
        ///              con la infomración contenida en la tabla que es pasada como parámetro
        ///              al método.
        /// 
        /// Parámetros: Dt_Datos.- Tabla que almacena la información que será procesada.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: Diciembre 2011
        /// Usuario Modifico: Leslie Gonzalez Vazquez
        /// Fecha Modifico: Diciembre 2011
        /// Causa Modificación: Cuando la tabla que se pasaba como parámetro no traia ningun registro el formato de
        ///                     la cadena no era generado de forma correcta.
        /// **********************************************************************************************************
        public static String Crear_Tabla_Formato_JSON_ComboBox_With_Item_Seleccione(DataTable Dt_Datos, string Campo, string Clave)
        {
            StringBuilder Buffer = new StringBuilder();
            StringWriter Escritor = new StringWriter(Buffer);
            JsonWriter Escribir_Formato_JSON = new JsonTextWriter(Escritor);
            String Cadena_Resultado = String.Empty;

            try
            {
                Escribir_Formato_JSON.Formatting = Formatting.None;
                Escribir_Formato_JSON.WriteStartArray();

                Escribir_Formato_JSON.WriteStartObject();
                Escribir_Formato_JSON.WritePropertyName(Campo);
                Escribir_Formato_JSON.WriteValue("SELECCIONE");
                Escribir_Formato_JSON.WritePropertyName(Clave);
                Escribir_Formato_JSON.WriteValue(String.Empty);
                Escribir_Formato_JSON.WritePropertyName("selected");
                Escribir_Formato_JSON.WriteValue("true");
                Escribir_Formato_JSON.WriteEndObject();

                if (Dt_Datos is DataTable)
                {
                    if (Dt_Datos.Rows.Count > 0)
                    {
                        foreach (DataRow FILA in Dt_Datos.Rows)
                        {
                            Escribir_Formato_JSON.WriteStartObject();
                            foreach (DataColumn COLUMNA in Dt_Datos.Columns)
                            {
                                if (!String.IsNullOrEmpty(FILA[COLUMNA.ColumnName].ToString()))
                                {
                                    Escribir_Formato_JSON.WritePropertyName(COLUMNA.ColumnName);
                                    Escribir_Formato_JSON.WriteValue(FILA[COLUMNA.ColumnName].ToString());
                                }
                            }
                            Escribir_Formato_JSON.WriteEndObject();
                        }
                    }
                }

                Escribir_Formato_JSON.WriteEndArray();
                Cadena_Resultado = Buffer.ToString();
            }
            catch (Exception)
            {
                throw new Exception("Error al crear la cadena json para cargar un combo.");
            }
            return Cadena_Resultado;
        }
        public static string arregloToJSON(string cadena_nombre, string cadena_valores)
        {
            string respuesta = "[]";
            char[] delimitador = { ',' };
            string[] nombres;
            string[] valores;
            int i;
            string s = "";
            int caracteres;

            StringBuilder jsonStringBuilder = new StringBuilder();
            StringWriter jsonStringWriter = new StringWriter(jsonStringBuilder);
            JsonWriter jsonWriter;

            jsonWriter = new JsonTextWriter(jsonStringWriter);

            nombres = cadena_nombre.Split(delimitador);
            valores = cadena_valores.Split(delimitador);

            if (nombres.Length > 0)
            {

                jsonWriter.Formatting = Formatting.None;
                jsonWriter.WriteStartArray();
                jsonWriter.WriteStartObject();

                for (i = 0; i < nombres.Length; i++)
                {
                    jsonWriter.WritePropertyName(nombres[i]);
                    jsonWriter.WriteValue(valores[i]);
                }

                jsonWriter.WriteEndObject();
            }

            jsonWriter.WriteEndArray();
            respuesta = jsonStringBuilder.ToString();

            if (respuesta.Length > 0)
            {
                caracteres = respuesta.Length;
                s = respuesta.Substring(1, caracteres - 2);
            }


            return s;
        } 

        public static string dataTableToJSONAutocompletar(DataTable dt)
        {

            StringBuilder jsonStringBuilder = new StringBuilder();
            StringWriter jsonStringWriter = new StringWriter(jsonStringBuilder);
            String cadenaFinal, valor;
            JsonWriter jsonWriter;
            int i, j;

            jsonWriter = new JsonTextWriter(jsonStringWriter);

            if (dt != null && dt.Rows.Count > 0)
            {
                jsonWriter.Formatting = Formatting.None;
                jsonWriter.WriteStartArray();

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    jsonWriter.WriteStartObject();
                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonWriter.WritePropertyName(dt.Columns[j].ColumnName.ToString().ToLower());
                        if (j == 0)
                        {
                            valor = dt.Rows[i][j].ToString();
                            jsonWriter.WriteValue(valor.Trim());
                        }
                        else {
                            jsonWriter.WriteValue((i+1).ToString());
                        }
                      
                    }
                    jsonWriter.WriteEndObject();

                }
                jsonWriter.WriteEndArray();
                cadenaFinal = jsonStringBuilder.ToString();
                return cadenaFinal;
            }

            return "{}";

        
        } 

        public static string dataTableToJSONsintotalrenglones(DataTable dt)
        {
            StringBuilder jsonStringBuilder = new StringBuilder();
            StringWriter jsonStringWriter = new StringWriter(jsonStringBuilder);
            String cadenaFinal, valor;
            JsonWriter jsonWriter;
            int i, j;

            jsonWriter = new JsonTextWriter(jsonStringWriter);

            if (dt != null && dt.Rows.Count > 0)
            {
                jsonWriter.Formatting = Formatting.None;
                jsonWriter.WriteStartArray();

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    jsonWriter.WriteStartObject();
                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonWriter.WritePropertyName(dt.Columns[j].ColumnName.ToString().ToLower());
                        valor = dt.Rows[i][j].ToString();
                        jsonWriter.WriteValue(valor.Trim());
                    }
                    jsonWriter.WriteEndObject();

                }
                jsonWriter.WriteEndArray();
                cadenaFinal =   jsonStringBuilder.ToString();
                return cadenaFinal;
            }

            return "{}";

        }

        public static string dataTableToJSONRengloes(DataTable dt)
        {
            StringBuilder jsonStringBuilder = new StringBuilder();
            StringWriter jsonStringWriter = new StringWriter(jsonStringBuilder);
            String cadenaFinal, valor;
            JsonWriter jsonWriter;
            int i, j;

            jsonWriter = new JsonTextWriter(jsonStringWriter);

            if (dt != null && dt.Rows.Count > 0)
            {
                jsonWriter.Formatting = Formatting.None;
                jsonWriter.WriteStartArray();

                for (i = 0; i < dt.Rows.Count; i++)
                {
                    jsonWriter.WriteStartObject();
                    for (j = 0; j < dt.Columns.Count; j++)
                    {
                        jsonWriter.WritePropertyName(dt.Columns[j].ColumnName.ToString().ToLower());
                        valor = dt.Rows[i][j].ToString();
                        valor = valor.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ").Replace(Environment.NewLine, " ");
                        jsonWriter.WriteValue(valor.Trim());
                    }
                    jsonWriter.WriteEndObject();

                }
                jsonWriter.WriteEndArray();
                cadenaFinal = "{\"total\":" + dt.Rows.Count + ",\"rows\":" + jsonStringBuilder.ToString() + "}";
                return cadenaFinal;
            }

            return "{\"total\":0,\"rows\":[]}";

        }

        public static string dataTableToJSON(DataTable dt) { 
        StringBuilder jsonStringBuilder = new StringBuilder();
        StringWriter jsonStringWriter = new StringWriter(jsonStringBuilder);
        String cadenaFinal,valor;
        JsonWriter jsonWriter;
        int i, j;

        jsonWriter = new JsonTextWriter(jsonStringWriter);
         
            if ( dt != null && dt.Rows.Count>0)
            {
                jsonWriter.Formatting = Formatting.None;
                jsonWriter.WriteStartArray();

                for (i = 0; i < dt.Rows.Count; i++) {
                    jsonWriter.WriteStartObject();
                    for (j = 0; j < dt.Columns.Count; j++) {
                        jsonWriter.WritePropertyName(dt.Columns[j].ColumnName.ToString().ToLower());
                        valor = dt.Rows[i][j].ToString();
                        jsonWriter.WriteValue(valor.Trim());
                        }
                     jsonWriter.WriteEndObject();
                       
                    }
                jsonWriter.WriteEndArray();
                cadenaFinal = "{\"total\":" + dt.Rows.Count + ",\"rows\":" + jsonStringBuilder.ToString() + "}";
                return cadenaFinal;
                }

            return "{\"total\":0,\"rows\":[]}";

            }

        public static string onDataGrid(DataTable dt, int page, int rows) {

            string dato;
            page = (page == 0) ? 1 : page;
            rows = (rows == 0) ? 10 : rows;
            int start = (page - 1) * rows;
            int end = page * rows;
            end = (end > dt.Rows.Count) ? dt.Rows.Count : end;
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\":" + dt.Rows.Count + ",\"rows\":[");
            for (int i = start; i < end; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    dato=dt.Rows[i][j].ToString().Trim();
                    dato = dato.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ").Replace(Environment.NewLine," ");
  
                    jsonBuilder.Append(dato);

                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();


        }

        public static string onDataGrid(DataTable dt, int page, int rows, Int64 total)
        {

            string dato;
            page = (page == 0) ? 1 : page;
            rows = (rows == 0) ? 10 : rows;
            int start = 0;
            int end = rows;
            end = (end > dt.Rows.Count) ? dt.Rows.Count : end;
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"total\":" + total + ",\"rows\":[");
            for (int i = start; i < end; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    dato = dt.Rows[i][j].ToString().Trim();
                    dato = dato.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ").Replace(Environment.NewLine, " ");

                    jsonBuilder.Append(dato);

                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]}");
            return jsonBuilder.ToString();


        }

        public static String Crear_Tabla_Formato_JSON(DataTable Dt_Datos){
            StringBuilder Buffer = new StringBuilder();
            StringWriter Escritor = new StringWriter(Buffer);
            JsonWriter Escribir_Formato_JSON = new JsonTextWriter(Escritor);
            String Cadena_Resultado = String.Empty;

            try
            {
                Escribir_Formato_JSON.Formatting = Formatting.None;
                Escribir_Formato_JSON.WriteStartObject();
                Escribir_Formato_JSON.WritePropertyName("TOTAL");
                Escribir_Formato_JSON.WriteValue(Dt_Datos.Rows.Count.ToString());
                Escribir_Formato_JSON.WritePropertyName(Dt_Datos.TableName);

                if (Dt_Datos is DataTable)
                {
                    if (Dt_Datos.Rows.Count > 0)
                    {
                        Escribir_Formato_JSON.WriteStartArray();
                        foreach (DataRow FILA in Dt_Datos.Rows)
                        {
                            Escribir_Formato_JSON.WriteStartObject();
                            foreach (DataColumn COLUMNA in Dt_Datos.Columns)
                            {                                
                                if (!String.IsNullOrEmpty(FILA[COLUMNA.ColumnName].ToString()))
                                {                                    
                                    Escribir_Formato_JSON.WritePropertyName(COLUMNA.ColumnName);
                                    Escribir_Formato_JSON.WriteValue(FILA[COLUMNA.ColumnName].ToString());                                    
                                }                                
                            }
                            Escribir_Formato_JSON.WriteEndObject();
                        }
                        
                        Escribir_Formato_JSON.WriteEndArray();
                        Escribir_Formato_JSON.WriteEndObject();
                        Cadena_Resultado = Buffer.ToString();
                    }
                    else Cadena_Resultado = "[]";
                }
                else Cadena_Resultado = "[]";
            }
            catch (Exception)
            {                
                throw new Exception("Error al crear la cadena json para cargar un combo.");
            }
            return Cadena_Resultado;
        }

        public static string dataTableToJSON2(DataTable dt, int total)
        {

            StringBuilder jsonStringBuilder = new StringBuilder();

            StringWriter jsonStringWriter = new StringWriter(jsonStringBuilder);

            String cadenaFinal, valor;

            JsonWriter jsonWriter;

            int i, j;



            jsonWriter = new JsonTextWriter(jsonStringWriter);



            if (dt != null && dt.Rows.Count > 0)
            {

                jsonWriter.Formatting = Formatting.None;

                jsonWriter.WriteStartArray();



                for (i = 0; i < dt.Rows.Count; i++)
                {

                    jsonWriter.WriteStartObject();

                    for (j = 0; j < dt.Columns.Count; j++)
                    {

                        jsonWriter.WritePropertyName(dt.Columns[j].ColumnName.ToString().ToLower());

                        valor = dt.Rows[i][j].ToString();

                        jsonWriter.WriteValue(valor.Trim());

                    }

                    jsonWriter.WriteEndObject();



                }

                jsonWriter.WriteEndArray();

                cadenaFinal = "{\"total\":" + total + ",\"rows\":" + jsonStringBuilder.ToString() + "}";

                return cadenaFinal;

            }



            return "{\"total\":0,\"rows\":[]}";



        }

        public static void testnum(ref int mini, string chaine, int i)
        {
            char letra;
            mini = mini - 1;
            if (i + mini < chaine.Length)
            {
              while (mini >= 0)
                {
                   letra = Convert.ToChar(chaine.Substring(i + mini, 1));
                    if (letra < 48 || letra > 57)
                    {
                        break;
                    }
                  mini = mini - 1;
                }
            }

        }

        // codifica una cadena de caracteres para usar el font de código de barras
        public static string code128(string chaine)
        {

            string respuesta = "";
            char letra;
            int i = 0;
            long checksum = 0;
            int mini = 0;
            int dummy = 0;
            bool tableB = false;

            if (chaine.Length > 0)
            {

                //Vérifier si caractères valides
                //Check for valid characters

                for (i = 0; i < chaine.Length; i++)
                { //inicio for
                    letra = Convert.ToChar(chaine.Substring(i, 1));

                    if ((letra >= 32 && letra <= 126) || letra == 203)
                    {

                    }
                    else
                    {
                        i = 0;
                        break;
                    }
                } //fin for

                respuesta = "";
                tableB = true;
                if (i > 0)
                {
                    i = 0;
                    while (i < chaine.Length)
                    {
                        if (tableB)
                        {
                            mini = (i == 0 || i + 3 == chaine.Length ? 4 : 6);
                            testnum(ref mini, chaine, i);
                            if (mini < 0)
                            {
                                if (i == 0)
                                    respuesta = Convert.ToString(Convert.ToChar(210));
                                else
                                    respuesta = respuesta + Convert.ToString(Convert.ToChar(204));

                                tableB = false;
                            }
                            else
                            {
                                if (i == 0)
                                    respuesta = Convert.ToString(Convert.ToChar(209));
                            }

                        } // fin table b  

                        if (!tableB)
                        {
                            mini = 2;
                            testnum(ref mini, chaine, i);
                            if (mini < 0)
                            {
                                dummy = Convert.ToInt32(chaine.Substring(i, 2));
                                dummy = (dummy < 95 ? dummy + 32 : dummy + 105);
                                respuesta = respuesta + Convert.ToString(Convert.ToChar(dummy));
                                i = i + 2;
                            }
                            else
                            {
                                respuesta = respuesta + Convert.ToString(Convert.ToChar(205));
                                tableB = true;
                            }


                        } // fin table b negado


                        if (tableB)
                        {
                            respuesta = respuesta + chaine.Substring(i, 1);
                            i = i + 1;
                        }



                    } // fin while


                    for (i = 0; i < respuesta.Length; i++)
                    {

                        dummy = Convert.ToChar(respuesta.Substring(i, 1));
                        dummy = (dummy < 127 ? dummy - 32 : dummy - 105);
                        if (i == 0)
                            checksum = dummy;
                        checksum = (checksum + (i) * dummy) % 103;

                    }

                    checksum = (checksum < 95 ? checksum + 32 : checksum + 105);

                    respuesta = respuesta + Convert.ToString(Convert.ToChar(checksum)) + Convert.ToString(Convert.ToChar(211));

                } // fin segundo if


            }// fin primer if

            return respuesta;
        }

        //crea una imagen del código de barras
        public static Bitmap crearCodigo(string Code) {

            string text = code128(Code);
            Bitmap bitmap = new Bitmap(1, 1);
            Font font = new Font("Code 128", 800, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics graphics = Graphics.FromImage(bitmap);
            int width = (int)graphics.MeasureString(text, font).Width;
            int height = (int)graphics.MeasureString(text, font).Height;
            bitmap = new Bitmap(bitmap, new Size(width, height));
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphics.DrawString(text, font, new SolidBrush(Color.FromArgb(0, 0, 0)), 0, 0);
            graphics.Flush();

            return bitmap;

        }

        public static String Crear_Tabla_Formato_JSON_DataGrid(DataTable Dt_Datos, Int32 Total_Registros)
        {
            StringBuilder Buffer = new StringBuilder();
            StringWriter Escritor = new StringWriter(Buffer);
            JsonWriter Escribir_Formato_JSON = new JsonTextWriter(Escritor);
            String Cadena_Resultado = String.Empty;

            try
            {
                Escribir_Formato_JSON.Formatting = Formatting.None;
                Escribir_Formato_JSON.WriteStartObject();
                Escribir_Formato_JSON.WritePropertyName("total");
                Escribir_Formato_JSON.WriteValue(Total_Registros.ToString());
                Escribir_Formato_JSON.WritePropertyName(Dt_Datos.TableName);

                if (Dt_Datos is DataTable)
                {
                    if (Dt_Datos.Rows.Count > 0)
                    {
                        Escribir_Formato_JSON.WriteStartArray();
                        foreach (DataRow FILA in Dt_Datos.Rows)
                        {
                            Escribir_Formato_JSON.WriteStartObject();
                            foreach (DataColumn COLUMNA in Dt_Datos.Columns)
                            {
                                if (!String.IsNullOrEmpty(FILA[COLUMNA.ColumnName].ToString()))
                                {
                                    Escribir_Formato_JSON.WritePropertyName(COLUMNA.ColumnName);
                                    Escribir_Formato_JSON.WriteValue(FILA[COLUMNA.ColumnName].ToString());
                                }
                            }
                            Escribir_Formato_JSON.WriteEndObject();
                        }

                        Escribir_Formato_JSON.WriteEndArray();
                        Escribir_Formato_JSON.WriteEndObject();
                        Cadena_Resultado = Buffer.ToString();
                    }
                    else Cadena_Resultado = "{\"total\":0,\"rows\":[]}";
                }
                else Cadena_Resultado = "{\"total\":0,\"rows\":[]}";
            }
            catch (Exception)
            {
                throw new Exception("Error al crear la cadena json para cargar un combo.");
            }
            return Cadena_Resultado;
        }
    }
}
