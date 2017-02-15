using System;
using System.Text;
using Erp_Cat_Clientes.Negocio;
using Erp.Helper;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using System.Data;

namespace Erp_Cat_Clientes.Datos
{
    public class Cls_Cat_Clientes_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Cliente
        ///DESCRIPCIÓN          : Inserta un Cliente en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera insertado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Cliente(Cls_Cat_Clientes_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            String Cliente_Id = "";

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Cliente_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes, Cat_Adm_Clientes.Campo_Cliente_Id, "", 5);

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("INSERT INTO " + Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes);
            Mi_SQL.Append(" (" + Cat_Adm_Clientes.Campo_Cliente_Id);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Giro_Id);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Nombre_Corto);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Razon_Social);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_RFC);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_CURP);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Pais);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Estado);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Localidad);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Colonia);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Ciudad);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Calle);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Numero_Exterior);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Numero_Interior);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_CP);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Fax);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Telefono_1);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Telefono_2);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Extension);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Nextel);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Email);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Sitio_Web);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Dias_Credito);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Limite_Credito);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Descuento);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Estatus);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Usuario_Creo);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Ip_Creo);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Equipo_Creo);
            Mi_SQL.Append(", " + Cat_Adm_Clientes.Campo_Fecha_Creo);
            Mi_SQL.Append(") VALUES ");
            Mi_SQL.Append("( '" + Cliente_Id);
            Mi_SQL.Append("','" + Parametros.P_Giro_Id);
            Mi_SQL.Append("','" + Parametros.P_Nombre_Corto);
            Mi_SQL.Append("','" + Parametros.P_Razon_Social);
            Mi_SQL.Append("','" + Parametros.P_Rfc);
            Mi_SQL.Append("','" + Parametros.P_Curp);
            Mi_SQL.Append("','" + Parametros.P_Pais);
            Mi_SQL.Append("','" + Parametros.P_Estado);
            Mi_SQL.Append("','" + Parametros.P_Localidad);
            Mi_SQL.Append("','" + Parametros.P_Colonia);
            Mi_SQL.Append("','" + Parametros.P_Ciudad);
            Mi_SQL.Append("','" + Parametros.P_Calle);
            Mi_SQL.Append("','" + Parametros.P_Numero_Exterior);
            Mi_SQL.Append("','" + Parametros.P_Numero_Interior);
            Mi_SQL.Append("','" + Parametros.P_Cp);
            Mi_SQL.Append("','" + Parametros.P_Fax);
            Mi_SQL.Append("','" + Parametros.P_Telefono_1);
            Mi_SQL.Append("','" + Parametros.P_Telefono_2);
            Mi_SQL.Append("','" + Parametros.P_Extension);
            Mi_SQL.Append("','" + Parametros.P_Nextel);
            Mi_SQL.Append("','" + Parametros.P_Email);
            Mi_SQL.Append("','" + Parametros.P_Sitio_Web);
            Mi_SQL.Append("', " + Parametros.P_Dias_Credito);
            Mi_SQL.Append(" , " + Parametros.P_Limite_Credito);
            Mi_SQL.Append(" , " + Parametros.P_Descuento);
            Mi_SQL.Append(" ,'" + Parametros.P_Estatus);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Ip);
            Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Equipo);
            Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha() + ")");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Cliente
        ///DESCRIPCIÓN          : Modifica un Cliente en la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera modificado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Cliente(Cls_Cat_Clientes_Negocio Parametros)
        {
            StringBuilder Mi_SQL;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("UPDATE " + Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes + " SET ");
            if (!String.IsNullOrEmpty(Parametros.P_Giro_Id))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Giro_Id + " = '" + Parametros.P_Giro_Id + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Nombre_Corto))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Nombre_Corto + " = '" + Parametros.P_Nombre_Corto + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Razon_Social))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Razon_Social + " = '" + Parametros.P_Razon_Social + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Rfc))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_RFC + " = '" + Parametros.P_Rfc + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Curp))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_CURP + " = '" + Parametros.P_Curp + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Pais))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Pais + " = '" + Parametros.P_Pais + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Estado))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Estado + " = '" + Parametros.P_Estado + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Localidad))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Localidad + " = '" + Parametros.P_Localidad + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Colonia))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Colonia + " = '" + Parametros.P_Colonia + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Ciudad))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Ciudad + " = '" + Parametros.P_Ciudad + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Calle))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Calle + " = '" + Parametros.P_Calle + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Numero_Exterior))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Numero_Exterior + " = '" + Parametros.P_Numero_Exterior + "', "); ;}
            if (!String.IsNullOrEmpty(Parametros.P_Numero_Interior))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Numero_Interior + " = '" + Parametros.P_Numero_Interior + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Cp))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_CP + " = '" + Parametros.P_Cp + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Fax))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Fax + " = '" + Parametros.P_Fax + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Telefono_1))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Telefono_1 + " = '" + Parametros.P_Telefono_1 + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Telefono_2))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Telefono_2 + " = '" + Parametros.P_Telefono_2 + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Extension))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Extension + " = '" + Parametros.P_Extension + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Nextel))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Nextel + " = '" + Parametros.P_Nextel + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Email))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Email + " = '" + Parametros.P_Email + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Sitio_Web))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Sitio_Web + " = '" + Parametros.P_Sitio_Web + "', "); }
            if (!String.IsNullOrEmpty(Parametros.P_Dias_Credito))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Dias_Credito + " = " + Parametros.P_Dias_Credito + ", "); }
            if (!String.IsNullOrEmpty(Parametros.P_Limite_Credito))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Limite_Credito + " = " + Parametros.P_Limite_Credito + ", "); }
            if (!String.IsNullOrEmpty(Parametros.P_Descuento))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Descuento + " = " + Parametros.P_Descuento + ", "); }
            if (!String.IsNullOrEmpty(Parametros.P_Estatus))
            { Mi_SQL.Append(Cat_Adm_Clientes.Campo_Estatus + " = '" + Parametros.P_Estatus + "', "); }
            Mi_SQL.Append(Cat_Adm_Clientes.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
            Mi_SQL.Append(Cat_Adm_Clientes.Campo_Ip_Modifico + " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
            Mi_SQL.Append(Cat_Adm_Clientes.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
            Mi_SQL.Append(Cat_Adm_Clientes.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
            Mi_SQL.Append(" WHERE " + Cat_Adm_Clientes.Campo_Cliente_Id + " = '" + Parametros.P_Cliente_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Clientees
        ///DESCRIPCIÓN          : Regresa un DataTable con los Clientes encontrados.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Clientes(Cls_Cat_Clientes_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;
            DataTable Dt_Resultado;

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes);
            if (!String.IsNullOrEmpty(Parametros.P_Cliente_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Cliente_Id + " = '" + Parametros.P_Cliente_Id + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Estatus))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Estatus + " = '" + Parametros.P_Estatus + "'");
            }
            else
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Estatus + " != 'ELIMINADO'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Nombre_Corto))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Nombre_Corto + " LIKE '%" + Parametros.P_Nombre_Corto + "%'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Razon_Social))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Razon_Social + " LIKE '%" + Parametros.P_Razon_Social + "%'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Giro_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Giro_Id + " = '" + Parametros.P_Giro_Id + "'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Estado))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Estado + " LIKE '%" + Parametros.P_Estado + "%'");
            }
            if (!String.IsNullOrEmpty(Parametros.P_Ciudad))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Adm_Clientes.Campo_Ciudad + " LIKE '%" + Parametros.P_Ciudad + "%'");
            }
            Mi_SQL.Append(" ORDER BY " + Cat_Adm_Clientes.Campo_Cliente_Id);
            Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();

            return Dt_Resultado;            
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Cliente
        ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Cliente.
        ///PARAMETROS           : Parametros: Contiene los criterios para la busqueda.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Cls_Cat_Clientes_Negocio Consultar_Detalles_Cliente(Cls_Cat_Clientes_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Cls_Cat_Clientes_Negocio Cliente = new Cls_Cat_Clientes_Negocio();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes);
            Mi_SQL.Append(" WHERE " + Cat_Adm_Clientes.Campo_Cliente_Id + " = '" + Parametros.P_Cliente_Id + "'");
            System.Data.IDataReader Dr_Cliente = (System.Data.IDataReader)Conexion.HelperGenerico.Obtener_Data_Reader(Mi_SQL.ToString());

            while (Dr_Cliente.Read())
            {
                Cliente.P_Cliente_Id = Dr_Cliente.IsDBNull(0) ? "" : Dr_Cliente.GetString(0);
                Cliente.P_Giro_Id = Dr_Cliente.IsDBNull(1) ? "" : Dr_Cliente.GetString(1);
                Cliente.P_Nombre_Corto = Dr_Cliente.IsDBNull(2) ? "" : Dr_Cliente.GetString(2);
                Cliente.P_Razon_Social = Dr_Cliente.IsDBNull(3) ? "" : Dr_Cliente.GetString(3);
                Cliente.P_Rfc = Dr_Cliente.IsDBNull(4) ? "" : Dr_Cliente.GetString(4);
                Cliente.P_Curp = Dr_Cliente.IsDBNull(5) ? "" : Dr_Cliente.GetString(5);
                Cliente.P_Pais = Dr_Cliente.IsDBNull(6) ? "" : Dr_Cliente.GetString(6);
                Cliente.P_Estado = Dr_Cliente.IsDBNull(7) ? "" : Dr_Cliente.GetString(7);
                Cliente.P_Localidad = Dr_Cliente.IsDBNull(8) ? "" : Dr_Cliente.GetString(8);
                Cliente.P_Colonia = Dr_Cliente.IsDBNull(9) ? "" : Dr_Cliente.GetString(9);
                Cliente.P_Ciudad = Dr_Cliente.IsDBNull(10) ? "" : Dr_Cliente.GetString(10);
                Cliente.P_Calle = Dr_Cliente.IsDBNull(11) ? "" : Dr_Cliente.GetString(11);
                Cliente.P_Numero_Exterior = Dr_Cliente.IsDBNull(12) ? "" : Dr_Cliente.GetString(12);
                Cliente.P_Numero_Interior = Dr_Cliente.IsDBNull(13) ? "" : Dr_Cliente.GetString(13);
                Cliente.P_Cp = Dr_Cliente.IsDBNull(14) ? "" : Dr_Cliente.GetString(14);
                Cliente.P_Fax = Dr_Cliente.IsDBNull(15) ? "" : Dr_Cliente.GetString(15);
                Cliente.P_Telefono_1 = Dr_Cliente.IsDBNull(16) ? "" : Dr_Cliente.GetString(16);
                Cliente.P_Telefono_2 = Dr_Cliente.IsDBNull(17) ? "" : Dr_Cliente.GetString(17);
                Cliente.P_Extension = Dr_Cliente.IsDBNull(18) ? "" : Dr_Cliente.GetString(18);
                Cliente.P_Nextel = Dr_Cliente.IsDBNull(19) ? "" : Dr_Cliente.GetString(19);
                Cliente.P_Email = Dr_Cliente.IsDBNull(20) ? "" : Dr_Cliente.GetString(20);
                Cliente.P_Sitio_Web = Dr_Cliente.IsDBNull(21) ? "" : Dr_Cliente.GetString(21);
                Cliente.P_Dias_Credito = Dr_Cliente.IsDBNull(22) ? "" : Dr_Cliente.GetString(22);
                Cliente.P_Limite_Credito = Dr_Cliente.IsDBNull(23) ? "" : Dr_Cliente.GetString(23);
                Cliente.P_Descuento = Dr_Cliente.IsDBNull(24) ? "" : Dr_Cliente.GetString(24);
                Cliente.P_Estatus = Dr_Cliente.IsDBNull(25) ? "" : Dr_Cliente.GetString(25);
            }
            Conexion.HelperGenerico.Cerrar_Conexion();

            return Cliente;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Cliente
        ///DESCRIPCIÓN          : Elimina un Cliente de la base de datos.
        ///PARAMETROS           : Parametros: Contiene el registro que sera eliminado.
        ///CREO                 : Salvador Vázquez Camacho
        ///FECHA_CREO           : 12/Enero/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Cliente(Cls_Cat_Clientes_Negocio Parametros)
        {
            StringBuilder Mi_SQL;
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("DELETE FROM " + Cat_Adm_Clientes.Tabla_Cat_Adm_Clientes);
            Mi_SQL.Append(" WHERE " + Cat_Adm_Clientes.Campo_Cliente_Id + " = '" + Parametros.P_Cliente_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}
