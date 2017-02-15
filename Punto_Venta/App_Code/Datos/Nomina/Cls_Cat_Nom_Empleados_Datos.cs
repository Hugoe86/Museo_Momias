using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Cat_Nom_Empleados.Negocio;
using Erp.Metodos_Generales;
using System.Text;
using Erp.Constantes;
using Erp.Sesiones;
using Erp.Ayudante_Sintaxis;
using System.Data;
using Erp.Helper;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Cat_Nom_Empleados.Datos
{
    public class Cls_Cat_Nom_Empleados_Datos
    {

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Alta_Empleado
        ///DESCRIPCIÓN: Da de alta en la Base de Datos Un nuevo Empleado
        ///PARAMENTROS:     
        ///             1. P_Empleado.      Instancia de la Clase de Negocio de Empleados 
        ///                                 con los datos del que van a ser
        ///                                 dados de Alta.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 15/Feb/2013 04:23:00 p.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Alta_Empleado(Cls_Cat_Nom_Empleados_Negocio P_Empleado)
        {
            Boolean Alta = false;
            StringBuilder Mi_sql = new StringBuilder(); ;
            String Empleado_Id = "";

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
                Empleado_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Nom_Empleados.Tabla_Cat_Nom_Empleados, Cat_Nom_Empleados.Campo_Empleado_Id, "", 5);

                Mi_sql.Append("INSERT INTO " + Cat_Nom_Empleados.Tabla_Cat_Nom_Empleados + "(");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Empleado_Id + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Area_Id + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Puesto_Id + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Jefe_Id + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Nombre_Completo + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Nombres + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Apellido_Paterno + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Apellido_Materno + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Nacimiento + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Pais + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Localidad + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Estado + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Colonia + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Ciudad + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Calle + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Numero_Exterior + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Numero_Interior + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_CP + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_RFC + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_CURP + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_No_IMSS + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Telefono + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Celular + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Nextel + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Email + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Licencia_Manejo + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Vigencia_Licencia + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Tipo_Sangre + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Alergias + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Sueldo + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Sueldo_Diario + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Contrato + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Motivo_Baja + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Estatus + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Usuario_Creo + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Ip_Creo + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Equipo_Creo + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Creo);
                Mi_sql.Append(") VALUES (");
                Mi_sql.Append("'" + Empleado_Id + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Area_Id + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Puesto_Id + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Jefe_Id + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Nombre_Completo + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Nombres + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Apellido_Paterno + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Apellido_Materno + "', ");
                Mi_sql.Append("'" + String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime((P_Empleado.P_Fecha_Nacimiento))) + "', ");
                //Mi_sql.Append("" + Cls_Ayudante_Sintaxis.Formato_Fecha(P_Empleado.P_Fecha_Nacimiento.ToString()) + ", ");
                Mi_sql.Append("'" + P_Empleado.P_Pais + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Localidad + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Estado + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Colonia + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Ciudad + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Calle + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Numero_Exterior + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Numero_Interior + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Codigo_Postal + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Rfc + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Curp + "', ");
                Mi_sql.Append("'" + P_Empleado.P_No_Imss + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Telefono + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Celular + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Nextel + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Email + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Licencia_Manejo + "', ");
                Mi_sql.Append("'" + String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime((P_Empleado.P_Vigencia_Licencia))) + "', ");
                //Mi_sql.Append("" + Cls_Ayudante_Sintaxis.Formato_Fecha(P_Empleado.P_Vigencia_Licencia.ToString()) + ", ");
                Mi_sql.Append("'" + P_Empleado.P_Tipo_Sangre + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Alergias + "', ");
                Mi_sql.Append("" + P_Empleado.P_Sueldo + ", ");
                Mi_sql.Append("" + P_Empleado.P_Sueldo_Diario + ", ");
                Mi_sql.Append("'" + String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime((P_Empleado.P_Fecha_Contratado))) + "', ");
                //Mi_sql.Append("" + Cls_Ayudante_Sintaxis.Formato_Fecha(P_Empleado.P_Fecha_Contratado.ToString()) + ", ");
                Mi_sql.Append("'" + P_Empleado.P_Motivo_Baja + "', ");
                Mi_sql.Append("'" + P_Empleado.P_Estatus + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append("'" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append("" + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Alta = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Empleado: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Modificar_Empleado
        ///DESCRIPCIÓN: Modifica en la Base de Datos Un Empleado
        ///PARAMENTROS:     
        ///             1. P_Empleado.     Instancia de la Clase de Negocio de Empleados 
        ///                                 con los datos del que van a ser
        ///                                 modificados.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 15/Feb/2013 05:30:00 p.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Modificar_Empleado(Cls_Cat_Nom_Empleados_Negocio P_Empleado)
        {
            Boolean Modificado = false;
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

                Mi_sql.Clear(); 
                Mi_sql.Append("UPDATE " + Cat_Nom_Empleados.Tabla_Cat_Nom_Empleados + " SET ");
                if (P_Empleado.P_Area_Id != null && P_Empleado.P_Area_Id.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Area_Id + " = '" + P_Empleado.P_Area_Id + "', ");
                if (P_Empleado.P_Puesto_Id != null && P_Empleado.P_Puesto_Id.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Puesto_Id + " = '" + P_Empleado.P_Puesto_Id + "', ");
                if (P_Empleado.P_Jefe_Id != null && P_Empleado.P_Jefe_Id.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Jefe_Id + " = '" + P_Empleado.P_Jefe_Id + "', ");
                if (P_Empleado.P_Nombre_Completo != null && P_Empleado.P_Nombre_Completo.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Nombre_Completo + " = '" + P_Empleado.P_Nombre_Completo + "', ");
                if (P_Empleado.P_Nombres != null && P_Empleado.P_Nombres.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Nombres + " = '" + P_Empleado.P_Nombres + "', ");
                if (P_Empleado.P_Apellido_Materno != null && P_Empleado.P_Apellido_Materno.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Apellido_Materno + " = '" + P_Empleado.P_Apellido_Materno + "', ");
                if (P_Empleado.P_Apellido_Paterno != null && P_Empleado.P_Apellido_Paterno.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Apellido_Paterno + " = '" + P_Empleado.P_Apellido_Paterno + "', ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Nacimiento + " = '" + String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime((P_Empleado.P_Fecha_Nacimiento))) + "', ");
                //Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Nacimiento + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Empleado.P_Fecha_Nacimiento) + ", ");
                if (P_Empleado.P_Pais != null && P_Empleado.P_Pais.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Pais + " = '" + P_Empleado.P_Pais + "', ");
                if (P_Empleado.P_Localidad != null && P_Empleado.P_Localidad.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Localidad + " = '" + P_Empleado.P_Localidad + "', ");
                if (P_Empleado.P_Estado != null && P_Empleado.P_Estado.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Estado + " = '" + P_Empleado.P_Estado + "', ");
                if (P_Empleado.P_Colonia != null && P_Empleado.P_Colonia.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Colonia + " = '" + P_Empleado.P_Colonia + "', ");
                if (P_Empleado.P_Ciudad != null && P_Empleado.P_Ciudad.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Ciudad + " = '" + P_Empleado.P_Ciudad + "', ");
                if (P_Empleado.P_Calle != null && P_Empleado.P_Calle.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Calle + " = '" + P_Empleado.P_Calle + "', ");
                if (P_Empleado.P_Numero_Exterior != null && P_Empleado.P_Numero_Exterior.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Numero_Exterior + " = '" + P_Empleado.P_Numero_Exterior + "', ");
                if (P_Empleado.P_Numero_Interior != null && P_Empleado.P_Numero_Interior.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Numero_Interior + " = '" + P_Empleado.P_Numero_Interior + "', ");
                if (P_Empleado.P_Codigo_Postal != null && P_Empleado.P_Codigo_Postal.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_CP + " = '" + P_Empleado.P_Codigo_Postal + "', ");
                if (P_Empleado.P_Rfc != null && P_Empleado.P_Rfc.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_RFC + " = '" + P_Empleado.P_Rfc + "', ");
                if (P_Empleado.P_Curp != null && P_Empleado.P_Curp.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_CURP + " = '" + P_Empleado.P_Curp + "', ");
                if (P_Empleado.P_No_Imss != null && P_Empleado.P_No_Imss.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_No_IMSS + " = '" + P_Empleado.P_No_Imss + "', ");
                if (P_Empleado.P_Telefono != null && P_Empleado.P_Telefono.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Telefono + " = '" + P_Empleado.P_Telefono + "', ");
                if (P_Empleado.P_Celular != null && P_Empleado.P_Celular.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Celular + " = '" + P_Empleado.P_Celular + "', ");
                if (P_Empleado.P_Nextel != null && P_Empleado.P_Nextel.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Nextel + " = '" + P_Empleado.P_Nextel + "', ");
                if (P_Empleado.P_Email != null && P_Empleado.P_Email.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Email + " = '" + P_Empleado.P_Email + "', ");
                if (P_Empleado.P_Licencia_Manejo != null && P_Empleado.P_Licencia_Manejo.Trim() != "")
                {
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Licencia_Manejo + " = '" + P_Empleado.P_Licencia_Manejo + "', ");
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Vigencia_Licencia + " = '" + String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime((P_Empleado.P_Licencia_Manejo))) + "', ");
                }
                //Mi_sql.Append(Cat_Nom_Empleados.Campo_Vigencia_Licencia + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Empleado.P_Vigencia_Licencia) + ", ");
                if (P_Empleado.P_Tipo_Sangre != null && P_Empleado.P_Tipo_Sangre.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Tipo_Sangre + " = '" + P_Empleado.P_Tipo_Sangre + "', ");
                if (P_Empleado.P_Alergias != null && P_Empleado.P_Alergias.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Alergias + " = '" + P_Empleado.P_Alergias + "', ");
                if (P_Empleado.P_Sueldo != null && P_Empleado.P_Sueldo.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Sueldo + " = " + P_Empleado.P_Sueldo + ", ");
                if (P_Empleado.P_Sueldo_Diario != null && P_Empleado.P_Sueldo_Diario.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Sueldo_Diario + " = " + P_Empleado.P_Sueldo_Diario + ", ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Contrato + " = '" + String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime((P_Empleado.P_Fecha_Contratado))) + "', ");
                //Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Contrato + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Empleado.P_Fecha_Contratado) + ", ");
                if (P_Empleado.P_Motivo_Baja != null && P_Empleado.P_Motivo_Baja.Trim() != "")
                {
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Motivo_Baja + " = '" + P_Empleado.P_Motivo_Baja + "', ");
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Baja + " = '" + String.Format("{0:dd/MMM/yyyy}", Convert.ToDateTime((P_Empleado.P_Fecha_Baja))) + "', ");
                }
                if (P_Empleado.P_Estatus != null && P_Empleado.P_Estatus.Trim() != "")
                    Mi_sql.Append(Cat_Nom_Empleados.Campo_Estatus + " = '" + P_Empleado.P_Estatus + "', ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Usuario_Modifico+ " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Ip_Modifico+ " = '" + MDI_Frm_Apl_Principal.Ip + "', ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Equipo_Modifico + " = '" + MDI_Frm_Apl_Principal.Equipo + "', ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Nom_Empleados.Campo_Empleado_Id + " = '" + P_Empleado.P_Empleado_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());
                Modificado = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Empleado: " + E.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Modificado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Baja_Empleado
        ///DESCRIPCIÓN: Modifica el estatus en la Base de Datos un Empleado
        ///PARAMENTROS:     
        ///             1. P_Empleado.      Instancia de la Clase de Negocio de Empleados
        ///                                 con los datos del que van a ser
        ///                                 modificados.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 15/Feb/2013 06:10:00 p.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static Boolean Baja_Empleado(Cls_Cat_Nom_Empleados_Negocio P_Empleado)
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

                Mi_sql.Append("UPDATE " + Cat_Nom_Empleados.Tabla_Cat_Nom_Empleados + " SET ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Estatus + " = 'INACTIVO', ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Baja + " = " +  Cls_Ayudante_Sintaxis.Insertar_Fecha(P_Empleado.P_Fecha_Baja) + ", ");
                //Mi_sql.Append(Cat_Nom_Empleados.Campo_Usuario_Modifico + " = '" + Cls_Sessiones.Empleado_Nombre + "', ");
                //Mi_sql.Append(Cat_Nom_Empleados.Campo_Ip_Modifico + " = '" + Cls_Sessiones.Ip + "', ");
                //Mi_sql.Append(Cat_Nom_Empleados.Campo_Equipo_Modifico + " = '" + Cls_Sessiones.Equipo + "', ");
                Mi_sql.Append(Cat_Nom_Empleados.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());
                Mi_sql.Append(" WHERE " + Cat_Nom_Empleados.Campo_Empleado_Id + " = '" + P_Empleado.P_Empleado_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_sql.ToString());

                Mi_sql.Length = 0;

                Mi_sql.Append("UPDATE " + Apl_Usuarios.Tabla_Apl_Usuarios + " SET ");
                Mi_sql.Append(Apl_Usuarios.Campo_Estatus + " = 'INACTIVO', ");
                //Mi_sql.Append(Apl_Usuarios.Campo_Usuario_Modifico + " = '" + Cls_Sessiones.Empleado_Nombre + "', ");
                //Mi_sql.Append(Apl_Usuarios.Campo_Ip_Modifico + " = '" + Cls_Sessiones.Ip + "', ");
                //Mi_sql.Append(Apl_Usuarios.Campo_Equipo_Modifico + " = '" + Cls_Sessiones.Equipo + "', ");
                Mi_sql.Append(Apl_Usuarios.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());





                //Mi_sql.Append(" WHERE " + Apl_Usuarios.Campo_Usuario_Id + " = '" + P_Empleado.P_usu + "'");
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
                throw new Exception("Baja_Empleado: " + E.Message);
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

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Consultar_Proveedores
        ///DESCRIPCIÓN: Consulta los Proveedores
        ///PARAMENTROS:     
        ///             1. P_Proveedor.     Instancia de la Clase de Negocio de Proveedores 
        ///                                 con los datos que servirán de
        ///                                 filtro.
        ///CREO: Miguel Angel Bedolla Moreno.
        ///FECHA_CREO: 15/Feb/2013 01:30:00 p.m. 
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        public static DataTable Consultar_Empleados(Cls_Cat_Nom_Empleados_Negocio P_Empleado)
        {
            DataTable Tabla = new DataTable();
            StringBuilder Mi_SQL = new StringBuilder();
            //String Aux_Filtros = "";
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();
            try
            {
                Mi_SQL.Clear();
                Mi_SQL.Append("SELECT EM." + Cat_Nom_Empleados.Campo_Empleado_Id
                    + ", EM." + Cat_Nom_Empleados.Campo_Area_Id
                    + ", (SELECT AR." + Cat_Nom_Areas.Campo_Nombre + " FROM " + Cat_Nom_Areas.Tabla_Cat_Nom_Areas + " AR WHERE AR." + Cat_Nom_Areas.Campo_Area_Id + "=EM." + Cat_Nom_Empleados.Campo_Area_Id + ") AS NOMBRE_AREA"
                    + ", EM." + Cat_Nom_Empleados.Campo_Puesto_Id
                    + ", (SELECT PU." + Cat_Nom_Puestos.Campo_Nombre + " FROM " + Cat_Nom_Puestos.Tabla_Cat_Nom_Puestos + " PU WHERE PU." + Cat_Nom_Puestos.Campo_Puesto_Id + "=EM." + Cat_Nom_Empleados.Campo_Puesto_Id + ") AS NOMBRE_PUESTO"
                    + ", EM." + Cat_Nom_Empleados.Campo_Jefe_Id
                    + ", (SELECT EMP." + Cat_Nom_Empleados.Campo_Nombre_Completo + " FROM " + Cat_Nom_Empleados.Tabla_Cat_Nom_Empleados + " EMP WHERE EMP." + Cat_Nom_Empleados.Campo_Empleado_Id + "=EM." + Cat_Nom_Empleados.Campo_Jefe_Id + ") AS NOMBRE_JEFE"
                    + ", EM." + Cat_Nom_Empleados.Campo_Nombre_Completo
                    + ", EM." + Cat_Nom_Empleados.Campo_Nombres
                    + ", EM." + Cat_Nom_Empleados.Campo_Apellido_Materno
                    + ", EM." + Cat_Nom_Empleados.Campo_Apellido_Paterno
                    + ", EM." + Cat_Nom_Empleados.Campo_Fecha_Nacimiento
                    + ", EM." + Cat_Nom_Empleados.Campo_Pais
                    + ", EM." + Cat_Nom_Empleados.Campo_Localidad
                    + ", EM." + Cat_Nom_Empleados.Campo_Estado
                    + ", EM." + Cat_Nom_Empleados.Campo_Colonia
                    + ", EM." + Cat_Nom_Empleados.Campo_Ciudad
                    + ", EM." + Cat_Nom_Empleados.Campo_Calle
                    + ", EM." + Cat_Nom_Empleados.Campo_Numero_Exterior
                    + ", EM." + Cat_Nom_Empleados.Campo_Numero_Interior
                    + ", EM." + Cat_Nom_Empleados.Campo_CP
                    + ", EM." + Cat_Nom_Empleados.Campo_RFC
                    + ", EM." + Cat_Nom_Empleados.Campo_CURP
                    + ", EM." + Cat_Nom_Empleados.Campo_No_IMSS
                    + ", EM." + Cat_Nom_Empleados.Campo_Telefono
                    + ", EM." + Cat_Nom_Empleados.Campo_Celular
                    + ", EM." + Cat_Nom_Empleados.Campo_Nextel
                    + ", EM." + Cat_Nom_Empleados.Campo_Email

                    + ", EM." + Cat_Nom_Empleados.Campo_Licencia_Manejo
                    + ", EM." + Cat_Nom_Empleados.Campo_Vigencia_Licencia
                    + ", EM." + Cat_Nom_Empleados.Campo_Tipo_Sangre
                    + ", EM." + Cat_Nom_Empleados.Campo_Alergias
                    + ", EM." + Cat_Nom_Empleados.Campo_Sueldo
                    + ", EM." + Cat_Nom_Empleados.Campo_Sueldo_Diario
                    + ", EM." + Cat_Nom_Empleados.Campo_Fecha_Contrato
                    + ", EM." + Cat_Nom_Empleados.Campo_Fecha_Baja
                    + ", EM." + Cat_Nom_Empleados.Campo_Motivo_Baja

                    + ", EM." + Cat_Nom_Empleados.Campo_Estatus
                    + ", EM." + Cat_Nom_Empleados.Campo_Fecha_Creo
                    + ", EM." + Cat_Nom_Empleados.Campo_Ip_Creo
                    + ", EM." + Cat_Nom_Empleados.Campo_Equipo_Creo
                    + ", EM." + Cat_Nom_Empleados.Campo_Usuario_Creo
                    + ", EM." + Cat_Nom_Empleados.Campo_Fecha_Modifico
                    + ", EM." + Cat_Nom_Empleados.Campo_Ip_Modifico
                    + ", EM." + Cat_Nom_Empleados.Campo_Equipo_Modifico
                    + ", EM." + Cat_Nom_Empleados.Campo_Usuario_Modifico
                    + " FROM  " + Cat_Nom_Empleados.Tabla_Cat_Nom_Empleados + " EM"
                    + " WHERE ");
                if (P_Empleado.P_Empleado_Id != null && P_Empleado.P_Empleado_Id.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Empleado_Id + " = '" + P_Empleado.P_Empleado_Id + "' AND ");
                }
                if (P_Empleado.P_Area_Id != null && P_Empleado.P_Area_Id.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Area_Id + " = '" + P_Empleado.P_Area_Id + "' AND ");
                }
                if (P_Empleado.P_Nombre_Area != null && P_Empleado.P_Nombre_Area.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Area_Id + " IN (SELECT AR." + Cat_Nom_Areas.Campo_Area_Id + " FROM " + Cat_Nom_Areas.Tabla_Cat_Nom_Areas + " AR WHERE AR." + Cat_Nom_Areas.Campo_Nombre + " LIKE '%" + P_Empleado.P_Nombre_Area + "%') AND ");
                }
                if (P_Empleado.P_Puesto_Id != null && P_Empleado.P_Puesto_Id.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Puesto_Id + " = '" + P_Empleado.P_Puesto_Id + "' AND ");
                }
                if (P_Empleado.P_Nombre_Puesto != null && P_Empleado.P_Nombre_Puesto.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Puesto_Id + " IN (SELECT PU." + Cat_Nom_Puestos.Campo_Puesto_Id + " FROM " + Cat_Nom_Puestos.Tabla_Cat_Nom_Puestos + " PU WHERE PU." + Cat_Nom_Puestos.Campo_Nombre + " LIKE '%" + P_Empleado.P_Nombre_Puesto + "%') AND ");
                }
                if (P_Empleado.P_Jefe_Id != null && P_Empleado.P_Jefe_Id.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Jefe_Id + " = '" + P_Empleado.P_Jefe_Id + "' AND ");
                }
                if (P_Empleado.P_Nombre_Jefe != null && P_Empleado.P_Nombre_Jefe.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Jefe_Id + " IN (SELECT EMP." + Cat_Nom_Empleados.Campo_Empleado_Id + " FROM " + Cat_Nom_Empleados.Tabla_Cat_Nom_Empleados + " EMP WHERE EMP." + Cat_Nom_Empleados.Campo_Nombre_Completo + " LIKE '%" + P_Empleado.P_Nombre_Jefe + "%') AND ");
                }
                if (P_Empleado.P_Nombre_Completo != null && P_Empleado.P_Nombre_Completo.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Nombre_Completo + " LIKE '%" + P_Empleado.P_Nombre_Completo + "%' AND ");
                }
                if (P_Empleado.P_Rfc != null && P_Empleado.P_Rfc.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_RFC + " LIKE '%" + P_Empleado.P_Rfc + "%' AND ");
                }
                if (P_Empleado.P_Estatus != null && P_Empleado.P_Estatus.Trim() != "")
                {
                    Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Estatus + " = '" + P_Empleado.P_Estatus + "' AND ");
                }
                Mi_SQL.Append("EM." + Cat_Nom_Empleados.Campo_Estatus + " != 'ELIMINADO'");
                /*if (Mi_SQL.ToString().EndsWith(" AND "))
                {
                    Aux_Filtros = Mi_SQL.ToString().Substring(0, Mi_SQL.Length - 5);
                    Mi_SQL.Length = 0;
                    Mi_SQL.Append(Aux_Filtros);
                }
                if (Mi_SQL.ToString().EndsWith(" WHERE "))
                {
                    Aux_Filtros = Mi_SQL.ToString().Substring(0, Mi_SQL.Length - 7);
                    Mi_SQL.Length = 0;
                    Mi_SQL.Append(Aux_Filtros);
                }*/
                // agregar filtro y orden a la consulta
                DataSet dataset = Conexion.HelperGenerico.Obtener_Data_Set(Mi_SQL.ToString());
                if (dataset != null)
                {
                    Tabla = dataset.Tables[0];
                }
            }
            catch (Exception Ex)
            {
                String Mensaje = "Error al intentar consultar los Empleados. Error: [" + Ex.Message + "]."; //"Error general en la base de datos"
                throw new Exception(Mensaje);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
            return Tabla;
        }
    }
}