using System;
using System.Text;
using Erp.Metodos_Generales;
using Erp.Helper;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Ayudante_Sintaxis;
using ERP_BASE.Paginas.Paginas_Generales;

namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Lista_Deudorcad_Datos
    {

        #region Consultas
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Bancos
        ///DESCRIPCIÓN          : Registra un nuevo banco en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la informacion de el nuevo banco
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Lista(Cls_Cat_Lista_Deudorcad_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Alta = false; // Variable que se utiliza para indicar si se realiza la ejecución del query.
            String Lista_Id; // Variable que almacena el valor del nuevo ID.

            try
            {
                Lista_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Lista_Deudorcad.Tabla, Cat_Lista_Deudorcad.Campo_Lista_Id, "", 5);
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

              
                // formar consulta
                Mi_SQL.Append("INSERT INTO " + Cat_Lista_Deudorcad.Tabla + "(");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Lista_Id + ",");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Nombre + ",");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Lista + ",");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Operacion + ",");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Tipo_Pago + ",");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Estatus + ",");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Lista_Id + "',");
                Mi_SQL.Append("'" + Datos.P_Nombre+ "',");
                Mi_SQL.Append("'" + Datos.P_Lista + "',");
                Mi_SQL.Append("'" + Datos.P_Operacion + "',");
                Mi_SQL.Append("'" + Datos.P_Tipo_Pago + "',");
                Mi_SQL.Append("'" + Datos.P_Estatus + "',");
                Mi_SQL.Append("'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Fecha() + ")");
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Lista
        ///DESCRIPCIÓN          : Registra un nuevo banco en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la informacion de el nuevo banco
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Modificar_Lista(Cls_Cat_Lista_Deudorcad_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Alta = false; // Variable que se utiliza para indicar si se realiza la ejecución del query.

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();


                // formar consulta
                Mi_SQL.Append("UPDATE " + Cat_Lista_Deudorcad.Tabla + " SET ");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Lista + " = '" + Datos.P_Lista + "',");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Nombre + " = '" + Datos.P_Nombre + "',");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Tipo_Pago + " = '" + Datos.P_Tipo_Pago + "',");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Operacion + " = '" + Datos.P_Operacion + "',");
                Mi_SQL.Append(Cat_Lista_Deudorcad.Campo_Estatus + " = '" + Datos.P_Estatus + "'");

                //  seccion where 
                Mi_SQL.Append(" where " + Cat_Lista_Deudorcad.Campo_Lista_Id + " = '" + Datos.P_Lista_Id + "'");

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
        ///NOMBRE DE LA FUNCIÓN : Consultar_Bancos
        ///DESCRIPCIÓN          : Consulta los bancos registrados en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la informacion de los bancos a consultar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Listas(Cls_Cat_Lista_Deudorcad_Negocio Datos)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("select * from " + Cat_Lista_Deudorcad.Tabla);

                //  filtro lista id
                if (!String.IsNullOrEmpty(Datos.P_Lista_Id))
                {
                    if (Mi_SQL.ToString().Contains("where"))
                        Mi_SQL.Append(" and " + Cat_Lista_Deudorcad.Campo_Lista_Id + " = '" +Datos.P_Lista_Id + "'");
                    else
                        Mi_SQL.Append(" where " + Cat_Lista_Deudorcad.Campo_Lista_Id + " = '" +Datos.P_Lista_Id + "'");
                }

                //  filtro lista 
                if (!String.IsNullOrEmpty(Datos.P_Lista))
                {
                    if (Mi_SQL.ToString().Contains("where"))
                        Mi_SQL.Append(" and " + Cat_Lista_Deudorcad.Campo_Lista + " = '" + Datos.P_Lista + "'");
                    else
                        Mi_SQL.Append(" where " + Cat_Lista_Deudorcad.Campo_Lista + " = '" + Datos.P_Lista + "'");
                }

                //  filtro nombre 
                if (!String.IsNullOrEmpty(Datos.P_Nombre))
                {
                    if (Mi_SQL.ToString().Contains("where"))
                        Mi_SQL.Append(" and " + Cat_Lista_Deudorcad.Campo_Nombre + " like '%" + Datos.P_Nombre + "%'");
                    else
                        Mi_SQL.Append(" where " + Cat_Lista_Deudorcad.Campo_Nombre + " like '%" + Datos.P_Nombre + "%'");
                }

                //  filtro tipo 
                if (!String.IsNullOrEmpty(Datos.P_Tipo_Pago))
                {
                    if (Mi_SQL.ToString().Contains("where"))
                        Mi_SQL.Append(" and " + Cat_Lista_Deudorcad.Campo_Tipo_Pago + " = '" + Datos.P_Tipo_Pago + "'");
                    else
                        Mi_SQL.Append(" where " + Cat_Lista_Deudorcad.Campo_Tipo_Pago + " = '" + Datos.P_Tipo_Pago + "'");
                }

                //  filtro operacion 
                if (!String.IsNullOrEmpty(Datos.P_Operacion))
                {
                    if (Mi_SQL.ToString().Contains("where"))
                        Mi_SQL.Append(" and " + Cat_Lista_Deudorcad.Campo_Operacion + " = '" + Datos.P_Operacion + "'");
                    else
                        Mi_SQL.Append(" where " + Cat_Lista_Deudorcad.Campo_Operacion + " = '" + Datos.P_Operacion + "'");
                }

                //  filtro estatus 
                if (!String.IsNullOrEmpty(Datos.P_Estatus))
                {
                    if (Mi_SQL.ToString().Contains("where"))
                        Mi_SQL.Append(" and " + Cat_Lista_Deudorcad.Campo_Estatus+ " = '" + Datos.P_Estatus + "'");
                    else
                        Mi_SQL.Append(" where " + Cat_Lista_Deudorcad.Campo_Estatus + " = '" + Datos.P_Estatus + "'");
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
