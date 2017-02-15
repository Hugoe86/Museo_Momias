using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using BitacorasAutomaticas.Tablas.Datos;

namespace BitacorasAutomaticas.Tablas.Negocio
{
    class Cls_Tablas_Negocio
    {
        public Cls_Tablas_Negocio()
        {
        }

        #region PROPIEDADES

        private string Nombre_Tabla;
        private string Operacion;
        private string Usuario;
        private DateTime Fecha_Inicio;
        private DateTime Fecha_Final;

        public string P_Nombre_Tabla
        {
            get { return Nombre_Tabla; }
            set { Nombre_Tabla = value; }
        }
        public string P_Operacion
        {
            get { return Operacion; }
            set { Operacion = value; }
        }
        public string P_Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public DateTime P_Fecha_Final
        {
            get { return Fecha_Final; }
            set { Fecha_Final = value; }
        }
        public DateTime P_Fecha_Inicio
        {
            get { return Fecha_Inicio; }
            set { Fecha_Inicio = value; }
        }

        #endregion PROPIEDADES

        #region METODOS

        ///*******************************************************************************************************
        /// <summary>
        /// Consulta el listado de tablas y si tienen activada la funcionalidad de bitácora
        /// </summary>
        /// <returns>DataTable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Listar_Tablas()
        {
            return Cls_Tablas_Datos.Listar_Tablas();
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Consulta el listado de tablas que tiene Log activado (una tabla con prefijo btc_)
        /// </summary>
        /// <returns>DataTable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Listar_Tablas_Con_Log()
        {
            return Cls_Tablas_Datos.Listar_Tablas_Con_Log();
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Crear la tabla para almacenar el log de registros para una tabla dada
        /// </summary>
        /// <param name="Tabla">nombre de la tabla para la que se va a crear el log</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public bool Crear_Bitacora(string Tabla)
        {
            return Cls_Tablas_Datos.Crear_Bitacora(Tabla);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Eliminar la tabla bitácora para una tabla dada
        /// </summary>
        /// <param name="Tabla">nombre de la tabla de la que se quiere eliminar la tabla bitácora</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public bool Eliminar_Bitacora(string Tabla)
        {
            return Cls_Tablas_Datos.Eliminar_Bitacora(Tabla);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Creación de los triggers para guardar el log de operaciones
        /// </summary>
        /// <param name="Tabla">nombre de la tabla a la que se requiere crear triggers</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public bool Crear_Servicio(string Tabla)
        {
            return Cls_Tablas_Datos.Crear_Servicio(Tabla);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Generar un archivo de valores separados por coma (CSV)
        /// </summary>
        /// <param name="Tabla">nombre de la tabla a la que se quiere eliminar el log de registros</param>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public void Respaldar_Bitacora(string Tabla)
        {
            string[] Bitacora = Cls_Tablas_Datos.Respaldar_Bitacora(Tabla);
            string Nombre_Archivo = "btc_" + Tabla + "_" + DateTime.Today.ToString("ddMMyyyy") + ".csv";
            Guardar_Archivo(Bitacora, Nombre_Archivo);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtiene un datatable con la información de los logs para los parámetros seleccionados
        /// </summary>
        /// <param name="Tabla">nombre de la tabla a la que se quiere eliminar el log de registros</param>
        /// <returns>una tabla con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Bitacora()
        {
            return Cls_Tablas_Datos.Consultar_Bitacora(this);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Elimina los triggers que guardan el log para una tabla dada
        /// </summary>
        /// <param name="Tabla">nombre de la tabla a la que se requiere eliminar triggers</param>
        /// <returns>TRUE en caso de operación exitosa</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public bool Eliminar_Servicio(string Tabla)
        {
            return Cls_Tablas_Datos.Eliminar_Servicio(Tabla);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Eliminar todos los registros de una tabla
        /// </summary>
        /// <param name="Tabla">nombre de la tabla a la que se quiere eliminar el log de registros</param>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public void Vaciar_Bitacora(string Tabla)
        {
            Cls_Tablas_Datos.Vaciar_Bitacora(Tabla);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Muestra un diáogo para guardar el archivo con el contenido recibido como parámetro
        /// </summary>
        /// <param name="Contenido">cadena de caracteres que se va a escribir a un archivo</param>
        /// <param name="Nombre_Archivo">nombre del archivo a sugerir en el diálogo guardar archivo</param>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>22-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public void Guardar_Archivo(string[] Contenido, string Nombre_Archivo)
        {
            SaveFileDialog Sfd_Bitacora = new SaveFileDialog();

            Sfd_Bitacora.Title = "Respaldar Bitácora";
            Sfd_Bitacora.FileName = Nombre_Archivo;
            Sfd_Bitacora.Filter = "Archivos CSV(*.csv)|*.csv|Todos los Archivos (*.*)|*.*";
            Sfd_Bitacora.RestoreDirectory = true;

            if (Sfd_Bitacora.ShowDialog() == DialogResult.OK)
            {
                StreamWriter Respaldo = new StreamWriter(Sfd_Bitacora.OpenFile());
                foreach (string Linea in Contenido)
                {
                    Respaldo.WriteLine(Linea);
                }

                Respaldo.Close();
            }
        }
        #endregion METODOS
    }
}
