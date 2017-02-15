using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp.Metodos_Generales;
using Erp.Helper;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Ayudante_Sintaxis;
using ERP_BASE.Paginas.Paginas_Generales;


namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Camaras_Datos
    {
        #region Metodos
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Camara
        ///DESCRIPCIÓN          : Registra un nuevo banco en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la informacion de el nuevo banco
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Camara(Cls_Cat_Camaras_Negocio P_Camara)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Alta = false; // Variable que se utiliza para indicar si se realiza la ejecución del query.
            String Camara_ID; // Variable que almacena el valor del nuevo ID.

            try
            {
                Camara_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Camaras.Tabla_Cat_Camaras, Cat_Camaras.Campo_Camara_ID, "", 5);
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("INSERT INTO " + Cat_Camaras.Tabla_Cat_Camaras + "(");
                Mi_SQL.Append(Cat_Camaras.Campo_Camara_ID);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Nombre);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Descripcion);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Url);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Estatus);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Usuario);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Contrasenia);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Tipo);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Usuario_Creo);
                Mi_SQL.Append("," + Cat_Camaras.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Camara_ID + "'");
                Mi_SQL.Append(", '" + P_Camara.P_Nombre + "'");
                Mi_SQL.Append(", '" + P_Camara.P_Descripcion + "'");
                Mi_SQL.Append(", '" + P_Camara.P_Url + "'");
                Mi_SQL.Append(", '" + P_Camara.P_Estatus + "'");
                Mi_SQL.Append(", '" + P_Camara.P_Usuario + "'");
                Mi_SQL.Append(", '" + P_Camara.P_Contrasenia + "'");
                Mi_SQL.Append(", '" + P_Camara.P_Tipo + "'");
                Mi_SQL.Append(", '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append("," + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(")");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Alta = true;
            }
            catch (Exception e)
            {
                Alta = false;
                throw new Exception("Alta de Banco : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }

            return Alta;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Camara
        ///DESCRIPCIÓN          : Registra un nuevo banco en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la informacion de el nuevo banco
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Modificar_Camara(Cls_Cat_Camaras_Negocio P_Camara)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Modificacion = false; // Variable que se utiliza para indicar si se realiza la ejecución del query.

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("update " + Cat_Camaras.Tabla_Cat_Camaras + " set ");
                Mi_SQL.Append(Cat_Camaras.Campo_Estatus + "= '" + P_Camara.P_Estatus + "'");

                if (!String.IsNullOrEmpty(P_Camara.P_Nombre))
                    Mi_SQL.Append(", " + Cat_Camaras.Campo_Nombre + "= '" + P_Camara.P_Nombre + "'");

                if (!String.IsNullOrEmpty(P_Camara.P_Descripcion))
                    Mi_SQL.Append(", " + Cat_Camaras.Campo_Descripcion + "= '" + P_Camara.P_Descripcion + "'");

                if (!String.IsNullOrEmpty(P_Camara.P_Url))
                    Mi_SQL.Append(", " + Cat_Camaras.Campo_Url + "= '" + P_Camara.P_Url + "'");

                if (!String.IsNullOrEmpty(P_Camara.P_Usuario))
                    Mi_SQL.Append(", " + Cat_Camaras.Campo_Usuario + "= '" + P_Camara.P_Usuario + "'");

                if (!String.IsNullOrEmpty(P_Camara.P_Contrasenia))
                    Mi_SQL.Append(", " + Cat_Camaras.Campo_Contrasenia + "= '" + P_Camara.P_Contrasenia + "'");

                if (!String.IsNullOrEmpty(P_Camara.P_Tipo))
                    Mi_SQL.Append(", " + Cat_Camaras.Campo_Tipo + "= '" + P_Camara.P_Tipo + "'");


                Mi_SQL.Append(", " + Cat_Camaras.Campo_Usuario_Modifico + "= '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "'");
                Mi_SQL.Append(", " + Cat_Camaras.Campo_Fecha_Modifico + "= " + Cls_Ayudante_Sintaxis.Fecha() + "");

                //  seccion where
                Mi_SQL.Append(" where " + Cat_Camaras.Campo_Camara_ID + "= '" + P_Camara.P_Camara_ID + "'");

                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Modificacion = true;
            }
            catch (Exception e)
            {
                Modificacion = false;
                throw new Exception("Alta de Banco : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }

            return Modificacion;
        }

        #endregion

        #region Consultas
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Camaras
        ///DESCRIPCIÓN          : Consulta los bancos registrados en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 01 Diciembre 2014
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Camaras(Cls_Cat_Camaras_Negocio P_Camaras)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("SELECT * FROM " + Cat_Camaras.Tabla_Cat_Camaras);


                if (!String.IsNullOrEmpty(P_Camaras.P_Camara_ID))
                {
                    if (Mi_SQL.ToString().Contains("WHERE"))
                        Mi_SQL.Append(" AND " + Cat_Camaras.Campo_Camara_ID + " = '" + P_Camaras.P_Camara_ID + "'");
                    else
                        Mi_SQL.Append(" WHERE " + Cat_Camaras.Campo_Camara_ID + " = '" + P_Camaras.P_Camara_ID + "'");
                }

                if (!String.IsNullOrEmpty(P_Camaras.P_Nombre))
                {
                    if(Mi_SQL.ToString().Contains("WHERE"))
                        Mi_SQL.Append(" AND " + Cat_Camaras.Campo_Nombre + " LIKE '" + P_Camaras.P_Nombre + "%'");
                    else
                        Mi_SQL.Append(" WHERE " + Cat_Camaras.Campo_Nombre + " LIKE '" + P_Camaras.P_Nombre + "%'");
                }

                if (!String.IsNullOrEmpty(P_Camaras.P_Descripcion))
                {
                    if (Mi_SQL.ToString().Contains("WHERE"))
                        Mi_SQL.Append(" AND " + Cat_Camaras.Campo_Descripcion + " LIKE '" + P_Camaras.P_Descripcion + "%'");
                    else
                        Mi_SQL.Append(" WHERE " + Cat_Camaras.Campo_Descripcion + " LIKE '" + P_Camaras.P_Descripcion + "%'");
                }

                if (!String.IsNullOrEmpty(P_Camaras.P_Url))
                {
                    if (Mi_SQL.ToString().Contains("WHERE"))
                        Mi_SQL.Append(" AND " + Cat_Camaras.Campo_Url + " LIKE '" + P_Camaras.P_Url + "%'");
                    else
                        Mi_SQL.Append(" WHERE " + Cat_Camaras.Campo_Url + " LIKE '" + P_Camaras.P_Url + "%'");
                }

                if (!String.IsNullOrEmpty(P_Camaras.P_Estatus))
                {
                    if (Mi_SQL.ToString().Contains("WHERE"))
                        Mi_SQL.Append(" AND " + Cat_Camaras.Campo_Estatus + " = '" + P_Camaras.P_Estatus + "'");
                    else
                        Mi_SQL.Append(" WHERE " + Cat_Camaras.Campo_Estatus + " = '" + P_Camaras.P_Estatus + "'");
                }

                if (!String.IsNullOrEmpty(P_Camaras.P_Tipo))
                {
                    if (Mi_SQL.ToString().Contains("WHERE"))
                        Mi_SQL.Append(" AND " + Cat_Camaras.Campo_Tipo + " = '" + P_Camaras.P_Tipo + "'");
                    else
                        Mi_SQL.Append(" WHERE " + Cat_Camaras.Campo_Tipo + " = '" + P_Camaras.P_Tipo + "'");
                }

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consulta de Bancos : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        #endregion

    }
}
