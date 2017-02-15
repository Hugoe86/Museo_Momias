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
    class Cls_Cat_Bancos_Datos
    {
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
        public static Boolean Alta_Bancos(Cls_Cat_Bancos_Negocio P_Banco)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.
            Boolean Alta = false; // Variable que se utiliza para indicar si se realiza la ejecución del query.
            String Banco_ID; // Variable que almacena el valor del nuevo ID.

            try
            {
                Banco_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Bancos.Tabla_Cat_Bancos, Cat_Bancos.Campo_Banco_ID, "", 5);
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                // si la ruta de archivo contiene texto, sustituir el nombre de archivo con el ID
                if (!string.IsNullOrEmpty(P_Banco.P_Ruta_Logo))
                {
                    P_Banco.P_Ruta_Logo = P_Banco.P_Ruta_Logo.Replace("nombre_temporal.", "banco_" + Banco_ID + ".");
                }

                // formar consulta
                Mi_SQL.Append("INSERT INTO " + Cat_Bancos.Tabla_Cat_Bancos + "(");
                Mi_SQL.Append(Cat_Bancos.Campo_Banco_ID + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Moneda + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Nombre + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Cuenta + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Ruta_Logo + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Comision + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Fecha_Creo);
                Mi_SQL.Append(") VALUES (");
                Mi_SQL.Append("'" + Banco_ID + "',");
                Mi_SQL.Append("'" + P_Banco.P_Moneda + "',");
                Mi_SQL.Append("'" + P_Banco.P_Nombre + "',");
                Mi_SQL.Append("'" + P_Banco.P_Cuenta + "',");

                // si no se está utilizando MySQL, asignar ruta, de lo contrario, duplicar el caracter \ para escaparlo en la BD
                if ("MySqlClient" != Cls_Constantes.Gestor_Base_Datos)
                {
                    Mi_SQL.Append("'" + P_Banco.P_Ruta_Logo + "',");
                }
                else
                {
                    Mi_SQL.Append("'" + P_Banco.P_Ruta_Logo.Replace(@"\", @"\\") + "',");
                }
                Mi_SQL.Append(P_Banco.P_Comision + ",");
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Banco
        ///DESCRIPCIÓN          : Modifica el registro de un banco en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la informacion del banco a Modificar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static void Modificar_Banco(Cls_Cat_Bancos_Negocio P_Banco)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("UPDATE " + Cat_Bancos.Tabla_Cat_Bancos + " SET ");
                Mi_SQL.Append(Cat_Bancos.Campo_Moneda + " = '" + P_Banco.P_Moneda + "',");
                Mi_SQL.Append(Cat_Bancos.Campo_Nombre + " = '" + P_Banco.P_Nombre + "',");
                Mi_SQL.Append(Cat_Bancos.Campo_Cuenta + " = '" + P_Banco.P_Cuenta + "',");
                // asignar el valor de la ruta si hay un nombre de archivo
                if (!string.IsNullOrEmpty(P_Banco.P_Ruta_Logo))
                {
                    // si no se está utilizando MySQL, asignar ruta sin escapar el caracter \
                    if ("MySqlClient" != Cls_Constantes.Gestor_Base_Datos)
                    {
                        Mi_SQL.Append(Cat_Bancos.Campo_Ruta_Logo + " = '" + @P_Banco.P_Ruta_Logo + "',");
                    }
                    else
                    {
                        Mi_SQL.Append(Cat_Bancos.Campo_Ruta_Logo + " = '" + @P_Banco.P_Ruta_Logo.Replace(@"\", @"\\") + "',");
                    }

                }
                Mi_SQL.Append(Cat_Bancos.Campo_Comision + " = " + P_Banco.P_Comision + ",");
                Mi_SQL.Append(Cat_Bancos.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_SQL.Append(Cat_Bancos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_SQL.Append(" WHERE " + Cat_Bancos.Campo_Banco_ID + " = '" + P_Banco.P_Banco_ID + "'");

                // ejecutar consulta
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Banco : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
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
        public static System.Data.DataTable Consultar_Bancos(Cls_Cat_Bancos_Negocio P_Banco)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM " + Cat_Bancos.Tabla_Cat_Bancos + " WHERE 1 = 1 ");
                if (!String.IsNullOrEmpty(P_Banco.P_Banco_ID))
                {
                    Mi_SQL.Append("AND " + Cat_Bancos.Campo_Banco_ID + " = '" + P_Banco.P_Banco_ID + "'");
                }
                if (!String.IsNullOrEmpty(P_Banco.P_Moneda))
                {
                    Mi_SQL.Append("AND " + Cat_Bancos.Campo_Moneda + " LIKE '" + P_Banco.P_Moneda + "%'");
                }
                if (!String.IsNullOrEmpty(P_Banco.P_Nombre))
                {
                    Mi_SQL.Append("AND " + Cat_Bancos.Campo_Nombre + " LIKE '" + P_Banco.P_Nombre + "%'");
                }
                if (!String.IsNullOrEmpty(P_Banco.P_Cuenta))
                {
                    Mi_SQL.Append("AND " + Cat_Bancos.Campo_Cuenta + " = '" + P_Banco.P_Cuenta + "'");
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

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Banco
        ///DESCRIPCIÓN          : Elimina el banco registrados en la base de datos
        ///PARÁMETROS           : P_Banco que contiene la información del banco a eliminar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public static void Eliminar_Banco(Cls_Cat_Bancos_Negocio P_Banco)
        {
            StringBuilder Mi_SQL = new StringBuilder(); // Variable para almacenar el query a ejecutar en la base de datos.

            Mi_SQL.Append("DELETE FROM " + Cat_Bancos.Tabla_Cat_Bancos);
            Mi_SQL.Append(" WHERE " + Cat_Bancos.Campo_Banco_ID + " = '" + P_Banco.P_Banco_ID + "'");
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}
