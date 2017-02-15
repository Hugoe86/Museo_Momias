using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Erp.Constantes;
using Erp.Numeros_Letras;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using Erp.Helper;

namespace Erp.Metodos_Generales
{
    public class Cls_Metodos_Generales
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:     
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010 
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static String Obtener_ID_Consecutivo(String Tabla, String Campo, String Filtro, Int32 Longitud_ID)
        {
            String Id = Convertir_A_Formato_ID(1, Longitud_ID); ;

            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }
            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();
                String Mi_SQL = "SELECT MAX(" + Campo + ") FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }
                Object Obj_Temp = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL);
                if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                {
                    Id = Convertir_A_Formato_ID((Convert.ToInt32(Obj_Temp) + 1), Longitud_ID);
                }
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                new Exception(Ex.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Id;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Obtener_ID_Consecutivo
        ///DESCRIPCIÓN: Obtiene el ID Cosnecutivo disponible para dar de alta un Registro en la Tabla
        ///PARAMETROS:     
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010 
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static String Obtener_ID_Consecutivo(String Tabla, String Campo, String Filtro, Int32 Longitud_ID, String Cadena_conexion)
        {
            String Id = Convertir_A_Formato_ID(1, Longitud_ID); ;

            Boolean Transaccion_Activa = false;
            //Conexion.Iniciar_Helper(Cls_Constantes.Cadena_Conexion, Cls_Constantes.Gestor_Base_Datos);
            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }
            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();
                String Mi_SQL = "SELECT MAX(" + Campo + ") FROM " + Tabla;
                if (Filtro != "" && Filtro != null)
                {
                    Mi_SQL += " WHERE " + Filtro;
                }
                Object Obj_Temp = Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL);
                if (!(Obj_Temp is Nullable) && !Obj_Temp.ToString().Equals(""))
                {
                    Id = Convertir_A_Formato_ID((Convert.ToInt32(Obj_Temp) + 1), Longitud_ID);
                }
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                new Exception(Ex.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Id;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Convertir_A_Formato_ID
        ///DESCRIPCIÓN: Pasa un numero entero a Formato de ID.
        ///PARAMETROS:     
        ///             1. Dato_ID. Dato que se desea pasar al Formato de ID.
        ///             2. Longitud_ID. Longitud que tendra el ID. 
        ///CREO: Francisco Antonio Gallardo Castañeda.
        ///FECHA_CREO: 10/Marzo/2010 
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static String Convertir_A_Formato_ID(Int32 Dato_ID, Int32 Longitud_ID)
        {
            String Retornar = "";
            String Dato = "" + Dato_ID;
            for (int Cont_Temp = Dato.Length; Cont_Temp < Longitud_ID; Cont_Temp++)
            {
                Retornar = Retornar + "0";
            }
            Retornar = Retornar + Dato;
            return Retornar;
        }


        public static void Configuracion_Acceso_Sistema_ERP(List<ImageButton> Botones, DataRow Accesos)
        {
            String Operacion = String.Empty;

            try
            {
                foreach (ImageButton Btn_Aux in Botones)
                {
                    if (Btn_Aux is ImageButton)
                    {
                        switch (Btn_Aux.ToolTip.Trim().ToUpper())
                        {
                            case "NUEVO":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Alta].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Alta].ToString().Equals("S")) ? true : false;
                                break;
                            case "MODIFICAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Cambio].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Cambio].ToString().Equals("S")) ? true : false;
                                break;
                            case "ELIMINAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Eliminar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Eliminar].ToString().Equals("S")) ? true : false;
                                break;
                            case "CONSULTAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            case "AVANZADA":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al configurar el control de acceso a nivel de operacion de las páginas del sistema. Error: [" + Ex.Message + "]");
            }
        }
        public static void Configuracion_Acceso_Sistema_ERP(List<LinkButton> Botones, DataRow Accesos)
        {
            String Operacion = String.Empty;

            try
            {
                foreach (LinkButton Btn_Aux in Botones)
                {
                    if (Btn_Aux is LinkButton)
                    {
                        switch (Btn_Aux.ToolTip.Trim().ToUpper())
                        {
                            case "NUEVO":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Alta].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Alta].ToString().Equals("S")) ? true : false;
                                break;
                            case "MODIFICAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Cambio].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Cambio].ToString().Equals("S")) ? true : false;
                                break;
                            case "ELIMINAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Eliminar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Eliminar].ToString().Equals("S")) ? true : false;
                                break;
                            case "CONSULTAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            case "AVANZADA":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al configurar el control de acceso a nivel de operacion de las páginas del sistema. Error: [" + Ex.Message + "]");
            }
        }

        public static void Configuracion_Acceso_Sistema_ERP(List<Button> Botones, DataRow Accesos)
        {
            String Operacion = String.Empty;

            try
            {
                foreach (Button Btn_Aux in Botones)
                {
                    if (Btn_Aux is Button)
                    {
                        switch (Btn_Aux.ToolTip.Trim().ToUpper())
                        {
                            case "NUEVO":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Alta].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Alta].ToString().Equals("S")) ? true : false;
                                break;
                            case "MODIFICAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Cambio].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Cambio].ToString().Equals("S")) ? true : false;
                                break;
                            case "ELIMINAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Eliminar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Eliminar].ToString().Equals("S")) ? true : false;
                                break;
                            case "CONSULTAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            case "AVANZADA":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al configurar el control de acceso a nivel de operacion de las páginas del sistema. Error: [" + Ex.Message + "]");
            }
        }

        public static void Configuracion_Acceso_Sistema_ERP_AlternateText(List<ImageButton> Botones, DataRow Accesos)
        {
            String Operacion = String.Empty;

            try
            {
                foreach (ImageButton Btn_Aux in Botones)
                {
                    if (Btn_Aux is ImageButton)
                    {
                        switch (Btn_Aux.AlternateText.Trim().ToUpper())
                        {
                            case "NUEVO":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Alta].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Alta].ToString().Equals("S")) ? true : false;
                                break;
                            case "MODIFICAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Cambio].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Cambio].ToString().Equals("S")) ? true : false;
                                break;
                            case "ELIMINAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Eliminar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Eliminar].ToString().Equals("S")) ? true : false;
                                break;
                            case "CONSULTAR":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            case "AVANZADA":
                                if (!String.IsNullOrEmpty(Accesos[Apl_Acceso.Campo_Consultar].ToString()))
                                    Btn_Aux.Visible = (Accesos[Apl_Acceso.Campo_Consultar].ToString().Equals("S")) ? true : false;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al configurar el control de acceso a nivel de operacion de las páginas del sistema. Error: [" + Ex.Message + "]");
            }
        }

        /// *************************************************************************************
        /// NOMBRE:             Generar_Reporte
        /// DESCRIPCIÓN:        Método que invoca la generación del reporte.
        ///              
        /// PARÁMETROS:         Ds_Reporte_Crystal.- Es el DataSet con el que se muestra el reporte en cristal 
        ///                     Ruta_Reporte_Crystal.-  Ruta y Nombre del archivo del Crystal Report.
        ///                     Nombre_Reporte_Generar.- Nombre que tendrá el reporte generado.
        ///                     Formato.- Es el tipo de reporte "PDF", "Excel"
        /// USUARIO CREO:       Juan Alberto Hernández Negrete.
        /// FECHA CREO:         3/Mayo/2011 18:15 p.m.
        /// USUARIO MODIFICO:   Salvador Henrnandez Ramirez
        /// FECHA MODIFICO:     16/Mayo/2011
        /// CAUSA MODIFICACIÓN: Se cambio Nombre_Plantilla_Reporte por Ruta_Reporte_Crystal, ya que este contendrá tambien la ruta
        ///                     y se asigno la opción para que se tenga acceso al método que muestra el reporte en Excel.
        /// *************************************************************************************
        public static void Generar_Reporte(ref DataSet Ds_Reporte_Crystal, String Ruta_Reporte, String Nombre_Reporte, String Ruta_Archivo, String Titulo_Ventana, Page Server, Type Tipo)
        {
            ReportDocument Reporte = new ReportDocument();
            String Ruta = String.Empty;

            try
            {
                Ruta = Server.MapPath(Ruta_Reporte + Nombre_Reporte);
                Reporte.Load(Ruta);

                if (Ds_Reporte_Crystal is DataSet)
                {
                    if (Ds_Reporte_Crystal.Tables.Count > 0)
                    {
                        Reporte.SetDataSource(Ds_Reporte_Crystal);
                        Exportar_Reporte_PDF(Reporte, Ruta_Archivo, Server);
                        Mostrar_Archivo(Ruta_Archivo, Titulo_Ventana, Server, Tipo);
                    }
                }
                Reporte.Close();
                Reporte.Dispose();
                Reporte = null;
            }
            catch (Exception Ex)
            {
                throw new Exception("Generar_Reporte Error: [" + Ex.Message + "]");
            }
        }
        /// *************************************************************************************
        /// NOMBRE:             Generar_Reporte
        /// DESCRIPCIÓN:        Método que invoca la generación del reporte.
        ///              
        /// PARÁMETROS:         Ds_Reporte_Crystal.- Es el DataSet con el que se muestra el reporte en cristal 
        ///                     Ruta_Reporte_Crystal.-  Ruta y Nombre del archivo del Crystal Report.
        ///                     Nombre_Reporte_Generar.- Nombre que tendrá el reporte generado.
        ///                     Formato.- Es el tipo de reporte "PDF", "Excel"
        ///                     Parametros, arreglo de n x 2, donde la primera posicion es el nombre del parametro
        ///                             y en la segunda posicion se guarda el valor de ese parametro.
        ///                             ejemplo. new String[1, 2] {{"NOMBRE_PARAMETRO","VALOR"}}
        /// USUARIO CREO:       Juan Alberto Hernández Negrete.
        /// FECHA CREO:         3/Mayo/2011 18:15 p.m.
        /// USUARIO MODIFICO:   Salvador Henrnandez Ramirez
        /// FECHA MODIFICO:     16/Mayo/2011
        /// CAUSA MODIFICACIÓN: Se cambio Nombre_Plantilla_Reporte por Ruta_Reporte_Crystal, ya que este contendrá tambien la ruta
        ///                     y se asigno la opción para que se tenga acceso al método que muestra el reporte en Excel.
        /// *************************************************************************************
        public static void Generar_Reporte(ref DataSet Ds_Reporte_Crystal, String Ruta_Reporte, String Nombre_Reporte, String[,] Parametros, String Ruta_Archivo, String Titulo_Ventana, Page Server, Type Tipo)
        {
            ReportDocument Reporte = new ReportDocument();
            String Ruta = String.Empty;

            try
            {
                Ruta = Server.MapPath(Ruta_Reporte + Nombre_Reporte);
                Reporte.Load(Ruta);

                if (Ds_Reporte_Crystal is DataSet)
                {
                    if (Ds_Reporte_Crystal.Tables.Count > 0)
                    {
                        Reporte.SetDataSource(Ds_Reporte_Crystal);
                        if (Parametros != null)
                        {
                            for (int i = 0; i < Parametros.GetLength(0); i++)
                            {
                                Reporte.SetParameterValue(Parametros[i, 0], Parametros[i, 1]);
                            }
                        }
                        Exportar_Reporte_PDF(Reporte, Ruta_Archivo, Server);
                        Mostrar_Archivo(Ruta_Archivo, Titulo_Ventana, Server, Tipo);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Generar_Reporte Error: [" + Ex.Message + "]");
            }
        }
        /// *************************************************************************************
        /// NOMBRE:             Generar_Reporte
        /// DESCRIPCIÓN:        Método que invoca la generación del reporte.
        ///              
        /// PARÁMETROS:         Ds_Reporte_Crystal.- Es el DataSet con el que se muestra el reporte en cristal 
        ///                     Ruta_Reporte_Crystal.-  Ruta y Nombre del archivo del Crystal Report.
        ///                     Nombre_Reporte_Generar.- Nombre que tendrá el reporte generado.
        ///                     Formato.- Es el tipo de reporte "PDF", "Excel"
        ///                     Parametros, arreglo de n x 2, donde la primera posicion es el nombre del parametro
        ///                             y en la segunda posicion se guarda el valor de ese parametro.
        ///                             ejemplo. new String[1, 2] {{"NOMBRE_PARAMETRO","VALOR"}}
        /// USUARIO CREO:       Juan Alberto Hernández Negrete.
        /// FECHA CREO:         3/Mayo/2011 18:15 p.m.
        /// USUARIO MODIFICO:   Salvador Henrnandez Ramirez
        /// FECHA MODIFICO:     16/Mayo/2011
        /// CAUSA MODIFICACIÓN: Se cambio Nombre_Plantilla_Reporte por Ruta_Reporte_Crystal, ya que este contendrá tambien la ruta
        ///                     y se asigno la opción para que se tenga acceso al método que muestra el reporte en Excel.
        /// *************************************************************************************
        public static void Generar_Reporte(ref DataSet Ds_Reporte_Crystal, ref DataSet Ds_Empresa, String Ruta_Reporte, String Nombre_Reporte, String[,] Parametros, String Ruta_Archivo, String Titulo_Ventana, Page Server, Type Tipo)
        {
            ReportDocument Reporte = new ReportDocument();
            String Ruta = String.Empty;

            try
            {
                Ruta = Server.MapPath(Ruta_Reporte + Nombre_Reporte);
                Reporte.Load(Ruta);

                if (Ds_Reporte_Crystal is DataSet)
                {
                    if (Ds_Reporte_Crystal.Tables.Count > 0)
                    {
                        Reporte.SetDataSource(Ds_Reporte_Crystal);
                        Reporte.Subreports[0].DataSourceConnections.Clear();
                        Reporte.Subreports[0].SetDataSource(Ds_Empresa.Tables[0]);

                        if (Parametros != null)
                        {
                            for (int i = 0; i < Parametros.GetLength(0); i++)
                            {
                                Reporte.SetParameterValue(Parametros[i, 0], Parametros[i, 1]);
                            }
                        }

                        Exportar_Reporte_PDF(Reporte, Ruta_Archivo, Server);
                        Mostrar_Archivo(Ruta_Archivo, Titulo_Ventana, Server, Tipo);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Generar_Reporte Error: [" + Ex.Message + "]");
            }
        }
        /// *************************************************************************************
        /// NOMBRE:             Generar_Reporte
        /// DESCRIPCIÓN:        Método que invoca la generación del reporte.
        ///              
        /// PARÁMETROS:         Ds_Reporte_Crystal.- Es el DataSet con el que se muestra el reporte en cristal 
        ///                     Ruta_Reporte_Crystal.-  Ruta y Nombre del archivo del Crystal Report.
        ///                     Nombre_Reporte_Generar.- Nombre que tendrá el reporte generado.
        ///                     Formato.- Es el tipo de reporte "PDF", "Excel"
        /// USUARIO CREO:       Juan Alberto Hernández Negrete.
        /// FECHA CREO:         3/Mayo/2011 18:15 p.m.
        /// USUARIO MODIFICO:   Armando Zavala Moreno
        /// FECHA MODIFICO:     05/Julio/2013 01:00 p.m
        /// CAUSA MODIFICACIÓN: Se agrego el dataset de la empresa para llenar el encabezado del reporte
        /// *************************************************************************************
        public static void Generar_Reporte(ref DataSet Ds_Reporte_Crystal, ref DataSet Ds_Empresa, String Ruta_Reporte, String Nombre_Reporte, String Ruta_Archivo, String Titulo_Ventana, Page Server, Type Tipo)
        {
            ReportDocument Reporte = new ReportDocument();
            String Ruta = String.Empty;

            try
            {
                Ruta = Server.MapPath(Ruta_Reporte + Nombre_Reporte);
                Reporte.Load(Ruta);

                if (Ds_Reporte_Crystal is DataSet)
                {
                    if (Ds_Reporte_Crystal.Tables.Count > 0)
                    {
                        Reporte.SetDataSource(Ds_Reporte_Crystal);
                        Reporte.Subreports[0].DataSourceConnections.Clear();
                        Reporte.Subreports[0].SetDataSource(Ds_Empresa.Tables[0]);
                        Exportar_Reporte_PDF(Reporte, Ruta_Archivo, Server);
                        Mostrar_Archivo(Ruta_Archivo, Titulo_Ventana, Server, Tipo);
                    }
                }
                Reporte = null;
            }
            catch (Exception Ex)
            {
                throw new Exception("Generar_Reporte Error: [" + Ex.Message + "]");
            }
        }
        /// ************************************************************************************
        /// NOMBRE:             Exportar_Reporte_PDF
        /// DESCRIPCIÓN:        Método que guarda el reporte generado en formato PDF en la ruta
        ///                     especificada.
        /// PARÁMETROS:         Reporte.- Objeto de tipo documento que contiene el reporte a guardar.
        ///                     Nombre_Reporte.- Nombre que se le dio al reporte.
        /// USUARIO CREO:       Juan Alberto Hernández Negrete.
        /// FECHA CREO:         3/Mayo/2011 18:19 p.m.
        /// USUARIO MODIFICO:
        /// FECHA MODIFICO:
        /// CAUSA MODIFICACIÓN:
        /// *************************************************************************************
        public static void Exportar_Reporte_PDF(ReportDocument Reporte, String Nombre_Reporte_Generar, Page Server)
        {
            ExportOptions Opciones_Exportacion = new ExportOptions();
            DiskFileDestinationOptions Direccion_Guardar_Disco = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions Opciones_Formato_PDF = new PdfRtfWordFormatOptions();

            try
            {
                if (Reporte is ReportDocument)
                {
                    Direccion_Guardar_Disco.DiskFileName = Server.MapPath(Nombre_Reporte_Generar);
                    Opciones_Exportacion.ExportDestinationOptions = Direccion_Guardar_Disco;
                    Opciones_Exportacion.ExportDestinationType = ExportDestinationType.DiskFile;
                    Opciones_Exportacion.ExportFormatType = ExportFormatType.PortableDocFormat;
                    Reporte.Export(Opciones_Exportacion);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Exportar_Reporte_PDF. Error: [" + Ex.Message + "]");
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Mostrar_Archivo
        ///DESCRIPCIÓN:          Muestra una archivo en una ventana.
        ///PARAMETROS:           Ruta,  Ruta del Archivo.
        ///                      Titulo_Ventana, Titulo que se muestra en al ventana
        ///                      Server, Página padre donde se mostrará
        ///                      Tipo, Tipo de la página padre
        ///CREO:                 Luis Alberto Salas
        ///FECHA_CREO:           01/Junio/2013
        ///MODIFICO:
        ///FECHA_MODIFICO
        ///CAUSA_MODIFICACIÓN
        ///*******************************************************************************  
        public static void Mostrar_Archivo(String Ruta, String Titulo_Ventana, Page Server, Type Tipo)
        {
            try
            {
                if (System.IO.File.Exists(Server.MapPath(HttpUtility.HtmlDecode(Ruta))))
                {
                    ScriptManager.RegisterStartupScript(Server, Tipo, "Window_Archivo_Archivos", "window.open('" + Ruta + "','" + Titulo_Ventana + "','toolbar=0,directories=0,menubar=0,status=0,scrollbars=0,resizable=1,width=1000,height=800')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Server, Tipo, "Mostrar Archivo", "$.messager.alert('Error','El archivo no existe.', 'warning');", true);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Mostrar_Archivo. Error: [" + Ex.Message + "]");
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Convertir_Imagen_Bytes
        ///DESCRIPCIÓN:          Convierte una imagen a bytes
        ///PARAMETROS:           Ruta,  Ruta de la imagen.
        ///                      Porcentaje_Reducion,  Porcentaje que reducira el tamaño de
        ///                         la imagen, tiene que ser double.
        ///                      Resolucion, Resolusion de la imagen dpi, entre mayor, mejor
        ///                         la calidad de la imagen.
        ///CREO:                 Luis Alberto Salas
        ///FECHA_CREO:           13/Junio/2013
        ///MODIFICO:
        ///FECHA_MODIFICO
        ///CAUSA_MODIFICACIÓN
        ///*******************************************************************************  
        public static byte[] Convertir_Imagen_Bytes(String Ruta, Double Porcentaje_Reducion, int Resolucion)
        {
            try
            {
                System.Drawing.Image Imagen = System.Drawing.Image.FromFile(Ruta);
                MemoryStream Ms = new MemoryStream();

                int Nuevo_Ancho = Convert.ToInt32((Imagen.Width * Resolucion) / Imagen.HorizontalResolution * Porcentaje_Reducion);
                int Nuevo_Alto = Convert.ToInt32((Imagen.Height * Resolucion) / Imagen.VerticalResolution * Porcentaje_Reducion);
                Bitmap Nueva_Imagen = new Bitmap(Imagen, Nuevo_Ancho, Nuevo_Alto);
                Nueva_Imagen.SetResolution(Resolucion, Resolucion);
                Nueva_Imagen.Save(Ms, Imagen.RawFormat);

                return Ms.ToArray();
            }
            catch
            {
                return new byte[0];
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Convertir_Imagen_Bytes
        ///DESCRIPCIÓN:          Convierte una imagen a bytes
        ///PARAMETROS:           Ruta,  Ruta de la imagen.
        ///                      Nuevo_Ancho, Ancho de la imagen, con esto calcula el nuevo
        ///                         alto de la imagen.
        ///                      Resolucion, Resolusion de la imagen dpi, entre mayor, mejor
        ///                         la calidad de la imagen.
        ///CREO:                 Luis Alberto Salas
        ///FECHA_CREO:           13/Junio/2013
        ///MODIFICO:
        ///FECHA_MODIFICO
        ///CAUSA_MODIFICACIÓN
        ///*******************************************************************************  
        public static byte[] Convertir_Imagen_Bytes(String Ruta, int Nuevo_Ancho, int Resolucion)
        {
            try
            {
                System.Drawing.Image Imagen = System.Drawing.Image.FromFile(Ruta);
                MemoryStream Ms = new MemoryStream();
                int Old_Ancho = Imagen.Width;
                int Old_Alto = Imagen.Height;
                Double Aux_Alto = ((Convert.ToDouble(Nuevo_Ancho) / Convert.ToDouble(Old_Ancho)) * Convert.ToDouble(Old_Alto));
                int Nuevo_Alto = Convert.ToInt32(Aux_Alto);
                Bitmap Nueva_Imagen = new Bitmap(Imagen, Old_Ancho, Old_Alto);
                Nueva_Imagen.SetResolution(Resolucion, Resolucion);
                Nueva_Imagen.Save(Ms, Imagen.RawFormat);

                return Ms.ToArray();
            }
            catch
            {
                return new byte[0];
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Convertir_Cantidad_Letras
        ///DESCRIPCIÓN:          Convierte una cantidad a letras
        ///PARAMETROS:           Cantidad_Numero, Cantidad a convertir a letras
        ///                      Moneda, Tipo de moneda Pesos o Dolares
        ///CREO:                 Luis Alberto Salas
        ///FECHA_CREO:           13/Junio/2013
        ///MODIFICO:
        ///FECHA_MODIFICO
        ///CAUSA_MODIFICACIÓN
        ///******************************************************************************* 
        public static String Convertir_Cantidad_Letras(Decimal Cantidad_Numero, String Moneda)
        {
            Cls_Numeros_Letras Letras = new Cls_Numeros_Letras();
            String Cantidad_Letra = String.Empty;

            try
            {
                if (Moneda.ToUpper().Equals("PESOS"))
                {
                    Letras.MascaraSalidaDecimal = "00/100 M.N.";
                    Letras.SeparadorDecimalSalida = "PESOS CON";
                }
                else
                {
                    Letras.MascaraSalidaDecimal = "00/100 DLLS";
                    Letras.SeparadorDecimalSalida = "DOLARES CON";
                }
                Letras.ApocoparUnoParteEntera = true;
                Cantidad_Letra = Letras.ToCustomCardinal(Cantidad_Numero).Trim().ToUpper();
            }
            catch (Exception Ex)
            {
                throw new Exception("Convertir_Cantidad_Letras. Error:[" + Ex.Message + "]");
            }
            return Cantidad_Letra;
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Eliminar_Registro_Base_Datos
        ///DESCRIPCIÓN: 
        ///PARAMETROS:     
        ///CREO: Alejandro Leyva Alvarado
        ///FECHA_CREO: 10/Marzo/2010 
        ///MODIFICO             : Antonio Salvador Benavides Guardado
        ///FECHA_MODIFICO       : 26/Octubre/2010
        ///CAUSA_MODIFICACIÓN   : Estandarizar variables usadas
        ///*******************************************************************************
        public static void Eliminar_Registro_Base_Datos(String Tabla, String Campo, String Filtro)
        {
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();
            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }
            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();
                String Mi_SQL = "DELETE FROM " + Tabla;
                if (Campo != "" && Campo != null)
                {
                    Mi_SQL += " WHERE " + Campo;
                    Mi_SQL += " =" + Filtro;
                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                }

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Registro Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Crear_Dataset_Empresa
        ///DESCRIPCIÓN          : Crea el dataset para mostrar los datos de la empresa en 
        ///                       Subreporte
        ///PARAMETROS           :     
        ///CREO                 : Armando Zavala Moreno
        ///FECHA_CREO           : 05/Julio/2012 11:16 a.m 
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static DataSet Crear_Dataset_Empresa(DataTable Dt_Empresa, String Ruta_Imagen)
        {
            DataSet Ds_Empresa = new DataSet();
            Dt_Empresa.TableName = "CAT_EMPRESAS";
            if (!Dt_Empresa.Columns.Contains("IMAGEN"))
            {
                Dt_Empresa.Columns.Add("IMAGEN", typeof(Byte[]));
            }
            Dt_Empresa.Rows[0]["IMAGEN"] = Cls_Metodos_Generales.Convertir_Imagen_Bytes(Ruta_Imagen, 400, 300);
            Ds_Empresa.Tables.Add(Dt_Empresa.Copy());
            return Ds_Empresa;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Eliminar_Registro_Base_Datos
        ///DESCRIPCIÓN: Elimina un registro que tiene detalles, primero borra los detalles
        ///             para que no marque error al momento de eliminar el encabezado.
        ///PARAMETROS:  Tabla, Nombre de la tabla de encabezado.
        ///             Tabla_Detalles, Nombre de la tabla de los detalles, si se omite este
        ///             parametro elimina solo el encabezado, para casos en que la  tabla no
        ///             tenga detalles.
        ///             Campo, Nombre del campo a evaluar.
        ///             Filtro, Id del registro a elimnar.
        ///CREO: Luis A. Salas
        ///FECHA_CREO: 06/Julio/2013 
        ///MODIFICO: 
        ///FECHA_MODIFICO: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************
        public static Boolean Eliminar_Registro_Base_Datos_Detalles(String Tabla, String Tabla_Detalles, String Campo, String Filtro)
        {
            Boolean Transaccion_Activa = false;
            Boolean Eliminado = false;
            Conexion.Iniciar_Helper();
            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }
            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();
                StringBuilder Mi_SQL = new StringBuilder();
                if (!String.IsNullOrEmpty(Tabla_Detalles))
                {
                    Mi_SQL.Append("DELETE FROM " + Tabla_Detalles);
                    if (!String.IsNullOrEmpty(Campo))
                    {
                        Mi_SQL.Append(" WHERE " + Campo);
                        Mi_SQL.Append(" = " + Filtro);
                        Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                    }
                }
                Mi_SQL.Clear();
                Mi_SQL.Append("DELETE FROM " + Tabla);
                if (!String.IsNullOrEmpty(Campo))
                {
                    Mi_SQL.Append(" WHERE " + Campo);
                    Mi_SQL.Append(" = " + Filtro);
                    Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                }

                Eliminado = true;
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception Ex)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Registro Error: [" + Ex.Message + "]");
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Eliminado;
        }
    }
}