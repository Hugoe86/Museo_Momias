using System;
using System.Text;
using Erp_Cat_Giros_Empresariales.Negocio;
using Erp.Helper;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using System.Data;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Cat_Giros_Empresariales.Datos
{
    public class Cls_Cat_Giros_Empresariales_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Giro_Empresarial
        ///DESCRIPCIÓN          : Inserta un Giro_Empresarial en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera insertado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Giro_Empresarial(Cls_Cat_Giros_Empresariales_Negocio Parametros)
        {


            StringBuilder Mi_SQL;
            String Giro_Id = "";

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Giro_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales, Cat_Adm_Giros_Empresariales.Campo_Giro_Id, "", 5);



           

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("INSERT INTO " + Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales);
            Mi_SQL.Append(" (" + Cat_Adm_Giros_Empresariales.Campo_Giro_Id);
            Mi_SQL.Append(", " + Cat_Adm_Giros_Empresariales.Campo_Nombre);
            Mi_SQL.Append(", " + Cat_Adm_Giros_Empresariales.Campo_Descripcion);
            Mi_SQL.Append(", " + Cat_Adm_Giros_Empresariales.Campo_Estatus);
            Mi_SQL.Append(", " + Cat_Adm_Giros_Empresariales.Campo_Usuario_Creo);
            Mi_SQL.Append(", " + Cat_Adm_Giros_Empresariales.Campo_Ip_Creo);
            Mi_SQL.Append(", " + Cat_Adm_Giros_Empresariales.Campo_Equipo_Creo);
            Mi_SQL.Append(", " + Cat_Adm_Giros_Empresariales.Campo_Fecha_Creo);
            Mi_SQL.Append(") VALUES ");
            Mi_SQL.Append("( '" + Giro_Id);
            Mi_SQL.Append("','" + Parametros.P_Nombre);
            Mi_SQL.Append("','" + Parametros.P_Descripcion);
            Mi_SQL.Append("','" + Parametros.P_Estatus);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Ip);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Equipo);
            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Giro_Empresarial
        ///DESCRIPCIÓN          : Modifica un Giro_Empresarial en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera modificado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Giro_Empresarial(Cls_Cat_Giros_Empresariales_Negocio Parametros)
        {
            StringBuilder Mi_SQL;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales + " SET ");
            if (!String.IsNullOrEmpty(Parametros.P_Nombre))
            { Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Nombre + " = '" + Parametros.P_Nombre + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Descripcion))
            { Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Descripcion + " = '" + Parametros.P_Descripcion + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Estatus))
            { Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Estatus + " = '" + Parametros.P_Estatus + "', "); }
            //Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Usuario_Modifico + " = '" + Cls_Sessiones.Empleado_Nombre + "', ");
            //Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Ip_Modifico + " = '" + Cls_Sessiones.Ip + "', ");
            //Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Equipo_Modifico + " = '" + Cls_Sessiones.Equipo + "', ");
            Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
            Mi_SQL.Append(" WHERE " + Cat_Adm_Giros_Empresariales.Campo_Giro_Id + " = '" + Parametros.P_Giro_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Giro_Empresariales
        ///DESCRIPCIÓN          : Regresa un DataTable con los Giro_Empresariales encontrados.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Giro_Empresariales(Cls_Cat_Giros_Empresariales_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;
            DataTable Dt_Resultado=new DataTable();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales);
            if (!String.IsNullOrEmpty(Parametros.P_Giro_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Giro_Id + " = '" + Parametros.P_Giro_Id + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Nombre))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Nombre + " LIKE '%" + Parametros.P_Nombre + "%'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Estatus))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Estatus  + Parametros.P_Estatus );
            }
            if (!String.IsNullOrEmpty(Parametros.P_Descripcion))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Giros_Empresariales.Campo_Descripcion + " LIKE '%" + Parametros.P_Descripcion + "%'");
            }
             Dt_Resultado=Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
             Conexion.HelperGenerico.Cerrar_Conexion();
            return Dt_Resultado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Giro_Empresarial
        ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Giro_Empresarial.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Cls_Cat_Giros_Empresariales_Negocio Consultar_Detalles_Giro_Empresarial(Cls_Cat_Giros_Empresariales_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Cls_Cat_Giros_Empresariales_Negocio Contrato = new Cls_Cat_Giros_Empresariales_Negocio();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales);
            Mi_SQL.Append(" WHERE " + Cat_Adm_Giros_Empresariales.Campo_Giro_Id + " = '" + Parametros.P_Giro_Id + "'");
            System.Data.IDataReader Dr_Giro_Empresarial = (System.Data.IDataReader)Conexion.HelperGenerico.Obtener_Data_Reader(Mi_SQL.ToString());

            while (Dr_Giro_Empresarial.Read())
            {
                Contrato.P_Giro_Id = Dr_Giro_Empresarial.IsDBNull(0) ? "" : Dr_Giro_Empresarial.GetString(0);
                Contrato.P_Nombre = Dr_Giro_Empresarial.IsDBNull(1) ? "" : Dr_Giro_Empresarial.GetString(1);
                Contrato.P_Descripcion = Dr_Giro_Empresarial.IsDBNull(2) ? "" : Dr_Giro_Empresarial.GetString(2);
                Contrato.P_Estatus = Dr_Giro_Empresarial.IsDBNull(3) ? "" : Dr_Giro_Empresarial.GetString(3);
            }
            Conexion.HelperGenerico.Cerrar_Conexion();
            return Contrato;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Giro_Empresarial
        ///DESCRIPCIÓN          : Elimina un Giro_Empresarial de la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera eliminado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Eliminar_Giro_Empresarial(Cls_Cat_Giros_Empresariales_Negocio Parametros)
        {
            
            
             Boolean Baja = false;
            StringBuilder Mi_sql = new StringBuilder();
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

                Mi_sql.Append("UPDATE " + Cat_Adm_Giros_Empresariales.Tabla_Cat_Adm_Giros_Empresariales + " SET ");
                Mi_sql.Append(Cat_Adm_Giros_Empresariales.Campo_Estatus + " = 'ELIMINADO', ");
                Mi_sql.Append(Cat_Adm_Giros_Empresariales.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Adm_Giros_Empresariales.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Adm_Giros_Empresariales.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Adm_Giros_Empresariales.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Adm_Giros_Empresariales.Campo_Giro_Id + " = '" + Parametros.P_Giro_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Baja = true;
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Baja_Centro_Costo: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Baja;
        



            
            
          
        }
    }
}
