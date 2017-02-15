using System;
using System.Text;
using Erp_Apl_Contratos.Negocio;
using Erp.Helper;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;

namespace Erp_Apl_Contratos.Datos
{
    public class Cls_Apl_Contratos_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Contrato
        ///DESCRIPCIÓN          : Inserta un contrato en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera insertado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Contrato(Cls_Apl_Contratos_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            int Consecutivo = 0;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
             

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT MAX(" + Apl_Contratos.Campo_Contrato_Id + ") FROM " + Apl_Contratos.Tabla_Apl_Contratos);
            Consecutivo = (int) Conexion.HelperGenerico.Obtener_Escalar(Mi_SQL.ToString());
            Consecutivo++;

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("INSERT INTO " + Apl_Contratos.Tabla_Apl_Contratos);
            Mi_SQL.Append(" (" + Apl_Contratos.Campo_Contrato_Id);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Empresa_Id);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Tipo_Sistema);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Costo);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Comentarios);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Nombre_Base_Datos);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Usuario_Base_Datos);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Contrasena_Base_Datos);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Ip_Base_Datos);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Fecha_Contrato);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Fecha_Renovacion);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Fecha_Expira);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Estatus);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Usuario_Creo);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Ip_Creo);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Equipo_Creo);
            Mi_SQL.Append(", " + Apl_Contratos.Campo_Fecha_Creo);
            Mi_SQL.Append(") VALUES ");
            Mi_SQL.Append("( '" + String.Format("0:0000000000", Consecutivo));
            Mi_SQL.Append("','" + Parametros.P_Empresa_Id);
            Mi_SQL.Append("','" + Parametros.P_Tipo_Sistema);
            Mi_SQL.Append("', " + Convert.ToDecimal(Parametros.P_Costo));
            Mi_SQL.Append(" ,'" + Parametros.P_Comentarios);
            Mi_SQL.Append("','" + Parametros.P_Nombre_Base_Datos);
            Mi_SQL.Append("','" + Parametros.P_Usuario_Base_Datos);
            Mi_SQL.Append("','" + Parametros.P_Contrasenia_Base_Datos);
            Mi_SQL.Append("','" + Parametros.P_Ip_Base_Datos);
            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Formato_Fecha(Parametros.P_Fecha_Contrato));
            Mi_SQL.Append(" , " + Cls_Ayudante_Sintaxis.Formato_Fecha(Parametros.P_Fecha_Renovacion));
            Mi_SQL.Append(" , " + Cls_Ayudante_Sintaxis.Formato_Fecha(Parametros.P_Fecha_Expira));
            Mi_SQL.Append(" ,'" + Parametros.P_Estatus);
            //Mi_SQL.Append("','" + Cls_Sessiones.Empleado_Nombre);
            //Mi_SQL.Append("','" + Cls_Sessiones.Ip);
            //Mi_SQL.Append("','" + Cls_Sessiones.Equipo);
            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Contrato
        ///DESCRIPCIÓN          : Modifica un contrato en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera modificado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Contrato(Cls_Apl_Contratos_Negocio Parametros)
        {
            StringBuilder Mi_SQL;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Apl_Contratos.Tabla_Apl_Contratos + " SET ");
            if (!String.IsNullOrEmpty(Parametros.P_Empresa_Id))
            { Mi_SQL.Append(Apl_Contratos.Campo_Empresa_Id + " = '" + Parametros.P_Empresa_Id + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Tipo_Sistema))
            { Mi_SQL.Append(Apl_Contratos.Campo_Tipo_Sistema + " = '" + Parametros.P_Tipo_Sistema + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Costo))
            { Mi_SQL.Append(Apl_Contratos.Campo_Costo + " = " + Convert.ToDecimal(Parametros.P_Costo) + ", "); }
            if (!String.IsNullOrEmpty(Parametros.P_Comentarios))
            { Mi_SQL.Append(Apl_Contratos.Campo_Comentarios + " = '" + Parametros.P_Comentarios + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Nombre_Base_Datos))
            { Mi_SQL.Append(Apl_Contratos.Campo_Nombre_Base_Datos + " = '" + Parametros.P_Nombre_Base_Datos + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Usuario_Base_Datos))
            { Mi_SQL.Append(Apl_Contratos.Campo_Usuario_Base_Datos + " = '" + Parametros.P_Usuario_Base_Datos + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Contrasenia_Base_Datos))
            { Mi_SQL.Append(Apl_Contratos.Campo_Contrasena_Base_Datos + " = '" + Parametros.P_Contrasenia_Base_Datos + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Ip_Base_Datos))
            { Mi_SQL.Append(Apl_Contratos.Campo_Ip_Base_Datos + " = '" + Parametros.P_Ip_Base_Datos + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Fecha_Contrato))
            { Mi_SQL.Append(Apl_Contratos.Campo_Fecha_Contrato + " = " + Cls_Ayudante_Sintaxis.Formato_Fecha(Parametros.P_Fecha_Contrato) + ", "); }
            if (!String.IsNullOrEmpty(Parametros.P_Fecha_Renovacion))
            { Mi_SQL.Append(Apl_Contratos.Campo_Fecha_Renovacion + " = " + Cls_Ayudante_Sintaxis.Formato_Fecha(Parametros.P_Fecha_Renovacion) + ", "); }
            if (!String.IsNullOrEmpty(Parametros.P_Fecha_Expira))
            { Mi_SQL.Append(Apl_Contratos.Campo_Fecha_Expira + " = '" + Cls_Ayudante_Sintaxis.Formato_Fecha(Parametros.P_Fecha_Expira) + ", "); }
            if (!String.IsNullOrEmpty(Parametros.P_Estatus))
            { Mi_SQL.Append(Apl_Contratos.Campo_Estatus + " = '" + Parametros.P_Estatus + "', "); }
            //Mi_SQL.Append(Apl_Contratos.Campo_Usuario_Modifico + " = '" + Cls_Sessiones.Empleado_Nombre + "', ");
            //Mi_SQL.Append(Apl_Contratos.Campo_Ip_Modifico + " = '" + Cls_Sessiones.Ip + "', ");
            //Mi_SQL.Append(Apl_Contratos.Campo_Equipo_Modifico + " = '" + Cls_Sessiones.Equipo + "', ");
            Mi_SQL.Append(Apl_Contratos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
            Mi_SQL.Append(" WHERE " + Apl_Contratos.Campo_Contrato_Id + " = '" + Parametros.P_Contrato_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Contratos
        ///DESCRIPCIÓN          : Regresa un DataTable con los Contratos encontrados.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Contratos(Cls_Apl_Contratos_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Apl_Contratos.Tabla_Apl_Contratos);
            if (!String.IsNullOrEmpty(Parametros.P_Contrato_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Contratos.Campo_Contrato_Id + " = '" + Parametros.P_Contrato_Id + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Empresa_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Apl_Contratos.Campo_Empresa_Id + " = '" + Parametros.P_Empresa_Id + "'");
            }

            Conexion.HelperGenerico.Cerrar_Conexion();
            return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Contrato
        ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Contrato.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Cls_Apl_Contratos_Negocio Consultar_Detalles_Contrato(Cls_Apl_Contratos_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Cls_Apl_Contratos_Negocio Contrato = new Cls_Apl_Contratos_Negocio();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Apl_Contratos.Tabla_Apl_Contratos);
            Mi_SQL.Append(" WHERE " + Apl_Contratos.Campo_Contrato_Id + " = '" + Parametros.P_Contrato_Id + "'");
            System.Data.IDataReader Dr_Contrato = (System.Data.IDataReader)Conexion.HelperGenerico.Obtener_Data_Reader(Mi_SQL.ToString());

            while (Dr_Contrato.Read())
            {
                Contrato.P_Contrato_Id = Dr_Contrato.IsDBNull(0) ? "" : Dr_Contrato.GetString(0);
                Contrato.P_Empresa_Id = Dr_Contrato.IsDBNull(1) ? "" : Dr_Contrato.GetString(1);
                Contrato.P_Tipo_Sistema = Dr_Contrato.IsDBNull(2) ? "" : Dr_Contrato.GetString(2);
                Contrato.P_Costo = Dr_Contrato.IsDBNull(3) ? "" : Dr_Contrato.GetString(3);
                Contrato.P_Comentarios = Dr_Contrato.IsDBNull(4) ? "" : Dr_Contrato.GetString(4);
                Contrato.P_Nombre_Base_Datos = Dr_Contrato.IsDBNull(5) ? "" : Dr_Contrato.GetString(5);
                Contrato.P_Usuario_Base_Datos = Dr_Contrato.IsDBNull(6) ? "" : Dr_Contrato.GetString(6);
                Contrato.P_Contrasenia_Base_Datos = Dr_Contrato.IsDBNull(7) ? "" : Dr_Contrato.GetString(7);
                Contrato.P_Ip_Base_Datos = Dr_Contrato.IsDBNull(8) ? "" : Dr_Contrato.GetString(8);
                Contrato.P_Fecha_Contrato = Dr_Contrato.IsDBNull(9) ? "" : Dr_Contrato.GetString(9);
                Contrato.P_Fecha_Renovacion = Dr_Contrato.IsDBNull(10) ? "" : Dr_Contrato.GetString(10);
                Contrato.P_Fecha_Expira = Dr_Contrato.IsDBNull(11) ? "" : Dr_Contrato.GetString(11);
                Contrato.P_Estatus = Dr_Contrato.IsDBNull(12) ? "" : Dr_Contrato.GetString(12);
            }

            Conexion.HelperGenerico.Cerrar_Conexion();
            return Contrato;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Contrato
        ///DESCRIPCIÓN          : Elimina un contrato de la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera eliminado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Contrato(Cls_Apl_Contratos_Negocio Parametros)
        {
            StringBuilder Mi_SQL;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("DELETE FROM " + Apl_Contratos.Tabla_Apl_Contratos);
            Mi_SQL.Append(" WHERE " + Apl_Contratos.Campo_Contrato_Id + " = '" + Parametros.P_Contrato_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}
