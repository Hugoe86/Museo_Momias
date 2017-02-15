using System;
using System.Text;
using System.Data;
using Erp_Apl_Parametros.Negocio;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;
using Erp.Helper;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;

namespace Erp_Apl_Parametros.Datos
{
    public class Cls_Apl_Parametros_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Parametros
        ///DESCRIPCIÓN          : Inserta los parametros del sistema.
        ///PARAMETROS           : 1. Rs_Negocio. Contiene el registro que sera insertado.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_CREO           : 11/Mar/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Alta_Parametros(Cls_Apl_Parametros_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Boolean Transaccion_Activa = false;
            String Parametro_Id = "";
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
                Parametro_Id = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Parametros.Tabla_Cat_Parametros, Cat_Parametros.Campo_Parametro_ID, "", 5);

                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("INSERT INTO " + Cat_Parametros.Tabla_Cat_Parametros);
                Mi_SQL.Append(" (" + Cat_Parametros.Campo_Parametro_ID);//1
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Dias_Vigencia);//2
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Directorio_Compartido);//3
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Encabezado_Recibo);// 4
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Mensaje_Dia_Recibo);//    5
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Tope_Recoleccion);//  6
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Mensaje_Ticket);//    7
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Email);// 8
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Contrasenia);//   9
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Host_Email);//    10
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Puerto);//    11
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Mensaje_Sistema);//   12
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Usuario_Creo);//  13
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Fecha_Creo);//    14
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Rol_Id);//    15
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Porcentaje_Faltante_Excedente);//    16
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Producto_Id_Web);//    17
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Leyenda);//    18
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Afiliacion_PinPad);//    19
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Usuario_PinPad);//    20
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Contrasenia_PinPad);//    21
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Operacion_PinPad);//    22
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Banorte_Url);//    23
                Mi_SQL.Append(", " + Cat_Parametros.Campo_Version_Bd);//24
                Mi_SQL.Append(") VALUES ");
                Mi_SQL.Append("( '" + Parametro_Id);//1
                Mi_SQL.Append("','" + Rs_Negocio.P_Dias_Vigencia);//2
                Mi_SQL.Append("','" + Rs_Negocio.P_Directorio_Compartido);//    3
                Mi_SQL.Append("','" + Rs_Negocio.P_Encabezado_Recibo);//    4
                Mi_SQL.Append("','" + Rs_Negocio.P_Mensaje_Dia_Recibo);//   5
                Mi_SQL.Append("','" + Rs_Negocio.P_Tope_Recoleccion);// 6
                Mi_SQL.Append("','" + Rs_Negocio.P_Mensaje_Ticket);//    7
                Mi_SQL.Append("','" + Rs_Negocio.P_Email);//    8
                Mi_SQL.Append("','" + Rs_Negocio.P_Contrasenia);//  9
                Mi_SQL.Append("','" + Rs_Negocio.P_Host_Email);//   10
                Mi_SQL.Append("','" + Rs_Negocio.P_Puerto);//   11
                Mi_SQL.Append("','" + Rs_Negocio.P_Mensaje_Sistema);//  12
                Mi_SQL.Append("','" + MDI_Frm_Apl_Principal.Nombre_Usuario);//  13
                Mi_SQL.Append("', " + Cls_Ayudante_Sintaxis.Fecha());//   14
                Mi_SQL.Append("','" + Rs_Negocio.P_Rol_Administrador_Id + "'");//  15
                Mi_SQL.Append("','" + Rs_Negocio.P_Porcentaje_Faltante + "'");//  16
                Mi_SQL.Append("','" + Rs_Negocio.P_Producto_Id_Web + "'");//  17
                Mi_SQL.Append("','" + Rs_Negocio.P_Leyenda_WEB + "'");//  18
                Mi_SQL.Append("','" + Rs_Negocio.P_Afiliacion_PinPad + "'");//  19
                Mi_SQL.Append("','" + Rs_Negocio.P_Usuario_PinPad + "'");//  20
                Mi_SQL.Append("','" + Rs_Negocio.P_Contrasenia_PinPad + "'");//  21
                Mi_SQL.Append("','" + Rs_Negocio.P_Operacion_PinPad + "'");//  22
                Mi_SQL.Append("','" + Rs_Negocio.P_Banorte_URL + "'");//  23
                Mi_SQL.Append(", '" + Rs_Negocio.P_Version_Bd + "'");//24
                Mi_SQL.Append(")");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta_Parametro: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Modificar_Parametros
        ///DESCRIPCIÓN          : Modifica el registro de los parametros del sistema
        ///PARAMETROS           : 1. Rs_Negocio. Contiene el registro que sera modificado.
        ///CREO                 : Luis Alberto Salas Garcia.
        ///FECHA_CREO           : 11/Mar/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Parametros(Cls_Apl_Parametros_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
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

                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("UPDATE " + Cat_Parametros.Tabla_Cat_Parametros + " SET ");

                Mi_SQL.Append(Cat_Parametros.Campo_Dias_Vigencia + " = '" + Rs_Negocio.P_Dias_Vigencia + "', ");

                if (!String.IsNullOrEmpty(Rs_Negocio.P_Directorio_Compartido))
                    Mi_SQL.Append(Cat_Parametros.Campo_Directorio_Compartido + " = '" + Rs_Negocio.P_Directorio_Compartido + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Encabezado_Recibo))
                    Mi_SQL.Append(Cat_Parametros.Campo_Encabezado_Recibo + " = '" + Rs_Negocio.P_Encabezado_Recibo + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Mensaje_Dia_Recibo))
                    Mi_SQL.Append(Cat_Parametros.Campo_Mensaje_Dia_Recibo + " = '" + Rs_Negocio.P_Mensaje_Dia_Recibo + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Email))
                    Mi_SQL.Append(Cat_Parametros.Campo_Email + " = '" + Rs_Negocio.P_Email + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Contrasenia))
                    Mi_SQL.Append(Cat_Parametros.Campo_Contrasenia + " = '" + Rs_Negocio.P_Contrasenia + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Host_Email))
                    Mi_SQL.Append(Cat_Parametros.Campo_Host_Email + " = '" + Rs_Negocio.P_Host_Email + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Puerto))
                    Mi_SQL.Append(Cat_Parametros.Campo_Puerto + " = '" + Rs_Negocio.P_Puerto + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Mensaje_Sistema))
                    Mi_SQL.Append(Cat_Parametros.Campo_Mensaje_Sistema + " = '" + Rs_Negocio.P_Mensaje_Sistema + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Tope_Recoleccion))
                    Mi_SQL.Append(Cat_Parametros.Campo_Tope_Recoleccion + " = '" + Rs_Negocio.P_Tope_Recoleccion + "', ");
                else
                    Mi_SQL.Append(Cat_Parametros.Campo_Tope_Recoleccion + " = '0', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Mensaje_Ticket))
                    Mi_SQL.Append(Cat_Parametros.Campo_Mensaje_Ticket + " = '" + Rs_Negocio.P_Mensaje_Ticket + "', ");
                else
                    Mi_SQL.Append(Cat_Parametros.Campo_Mensaje_Ticket + " = 'G R A C I A S - P O R -  S U - V I S I T A', ");

                //  validacion para el tipo del deudorcad
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Tipo_Deudorcad))
                    Mi_SQL.Append(Cat_Parametros.Campo_Tipo_Deudorcad + " = '" + Rs_Negocio.P_Tipo_Deudorcad + "', ");

                //  validacion para la lista del deudorcad
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Lista_Deudorcad))
                    Mi_SQL.Append(Cat_Parametros.Campo_Lista_Deudorcad + " = '" + Rs_Negocio.P_Lista_Deudorcad + "', ");

                Mi_SQL.Append(Cat_Parametros.Campo_Rol_Id + " = '" + Rs_Negocio.P_Rol_Administrador_Id + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Cuenta_Museo + " = '" + Rs_Negocio.P_Cuenta_Momias + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Ip_A_Enviar_Ventas + " = '" + Rs_Negocio.P_Ip_A_Enviar_Ventas + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas + " = '" + Rs_Negocio.P_Base_Datos_A_Enviar_Ventas + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Usuario_A_Enviar_Ventas + " = '" + Rs_Negocio.P_Usuario_A_Enviar_Ventas + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas + " = '" + Rs_Negocio.P_Password_A_Enviar_Ventas + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Porcentaje_Faltante_Excedente + " = '" + Rs_Negocio.P_Porcentaje_Faltante + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Usuario_Modifico + " = '" + MDI_Frm_Apl_Principal.Nombre_Usuario + "', ");
                
                //  web
                Mi_SQL.Append(Cat_Parametros.Campo_Producto_Id_Web + " = '" + Rs_Negocio.P_Producto_Id_Web  + "', ");
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Leyenda_WEB))
                Mi_SQL.Append(Cat_Parametros.Campo_Leyenda + " = '" + Rs_Negocio.P_Leyenda_WEB + "', ");

                //pinpad
                Mi_SQL.Append(Cat_Parametros.Campo_Afiliacion_PinPad + " = '" + Rs_Negocio.P_Afiliacion_PinPad + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Usuario_PinPad + " = '" + Rs_Negocio.P_Usuario_PinPad + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Contrasenia_PinPad + " = '" + Rs_Negocio.P_Contrasenia_PinPad + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Operacion_PinPad + " = '" + Rs_Negocio.P_Operacion_PinPad + "', ");
                Mi_SQL.Append(Cat_Parametros.Campo_Banorte_Url + " = '" + Rs_Negocio.P_Banorte_URL + "', ");

                String Fecha = Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(Rs_Negocio.P_Vigencia_WEB);
                Mi_SQL.Append(Cat_Parametros.Campo_Vigencia_Web + " = " + Fecha + ",");
                //Mi_SQL.Append(Cat_Parametros.Campo_Vigencia_Web + " = '" + Fecha + "', ");
             
       
                //  validacion para la clave de venta del deudorcad
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Clave_Venta_Deudorcad))
                    Mi_SQL.Append(Cat_Parametros.Campo_Clave_Venta_Deudorcad + " = '" + Rs_Negocio.P_Clave_Venta_Deudorcad + "', ");

                //  validacion para la clave de sobrante del deudorcad
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Clave_Sobrante_Deudorcad))
                    Mi_SQL.Append(Cat_Parametros.Campo_Clave_Sobrante_Deudorcad + " = '" + Rs_Negocio.P_Clave_Sobrante_Deudorcad + "', ");

                //  validacion para la clave de sobrante del deudorcad
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Clave_Venta_Individual_Deudorcad))
                    Mi_SQL.Append(Cat_Parametros.Campo_Clave_Venta_Individual_Deudorcad + " = '" + Rs_Negocio.P_Clave_Venta_Individual_Deudorcad + "', ");

                //  validacion para la clave de internet
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Clave_Internet))
                    Mi_SQL.Append(Cat_Parametros.Campo_Clave_Venta_Internet + " = '" + Rs_Negocio.P_Clave_Internet + "', ");

                //  validacion para la version de la base de datos
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Version_Bd))
                    Mi_SQL.Append(Cat_Parametros.Campo_Version_Bd + " = '" + Rs_Negocio.P_Version_Bd + "', ");

                Mi_SQL.Append(Cat_Parametros.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Fecha());




                //  seccion where ************************************************************************************
                Mi_SQL.Append(" WHERE " + Cat_Parametros.Campo_Parametro_ID + " = '" + Rs_Negocio.P_Parametro_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Modificar_Parametros: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Parametros
        ///DESCRIPCIÓN          : Elimina el registro de los parametros.
        ///PARAMETROS           : 1. Rs_Negocio. Contiene el registro que sera eliminado.
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_CREO           : 11/Mar/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Parametros(Cls_Apl_Parametros_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Boolean Transaccion_Activa = false;

            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
                Conexion.HelperGenerico.Conexion_y_Apertura();
            else
                Transaccion_Activa = true;
            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();
                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("DELETE FROM " + Cat_Parametros.Tabla_Cat_Parametros);
                Mi_SQL.Append(" WHERE " + Cat_Parametros.Campo_Parametro_ID + " = '" + Rs_Negocio.P_Parametro_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Eliminar_Parametros: " + E.Message);
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
        ///NOMBRE DE LA FUNCIÓN : Consultar_Parametros
        ///DESCRIPCIÓN          : Regresa un DataTable con los parametros del sistema.
        ///PARAMETROS           : 1. Rs_Negocio. Contiene los criterios para la busqueda.
        ///CREO                 : Luis Alberto Salas Garcia.
        ///FECHA_CREO           : 11/Mar/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Parametros_Transaccion(Cls_Apl_Parametros_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;
            DataTable Dt_Consulta = new DataTable();
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();

            //Conexion.HelperGenerico.Conexion_y_Apertura();

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
                Mi_SQL = new StringBuilder();
                Mi_SQL.Append("SELECT * FROM " + Cat_Parametros.Tabla_Cat_Parametros);
                if (!String.IsNullOrEmpty(Rs_Negocio.P_Parametro_Id))
                {
                    Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                    Mi_SQL.Append(Cat_Parametros.Campo_Parametro_ID + " = '" + Rs_Negocio.P_Parametro_Id + "'");
                }

                Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            //    Conexion.HelperGenerico.Cerrar_Conexion();
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Insertar_Historico: " + E.Message);
            }
            finally
            {
                //if (!Transaccion_Activa)
                //{
                //    Conexion.HelperGenerico.Cerrar_Conexion();
                //}

            }
        
            return Dt_Consulta;
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Parametros
        ///DESCRIPCIÓN          : Regresa un DataTable con los parametros del sistema.
        ///PARAMETROS           : 1. Rs_Negocio. Contiene los criterios para la busqueda.
        ///CREO                 : Luis Alberto Salas Garcia.
        ///FECHA_CREO           : 11/Mar/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Parametros(Cls_Apl_Parametros_Negocio Rs_Negocio)
        {
            StringBuilder Mi_SQL;
            Boolean Entro_Where = false;
            DataTable Dt_Consulta = new DataTable();

            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL = new StringBuilder();
            Mi_SQL.Append("SELECT * FROM " + Cat_Parametros.Tabla_Cat_Parametros);
            if (!String.IsNullOrEmpty(Rs_Negocio.P_Parametro_Id))
            {
                Mi_SQL.Append(Entro_Where ? " AND " : " WHERE "); Entro_Where = true;
                Mi_SQL.Append(Cat_Parametros.Campo_Parametro_ID + " = '" + Rs_Negocio.P_Parametro_Id + "'");
            }

            Dt_Consulta = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();

            return Dt_Consulta;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Parametros
        ///DESCRIPCIÓN: Forma y ejecuta una consulta para obtener y regresar un datatable con los parámetros,
        ///             regresa un datatable con los resultados de la consulta
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 15-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public static DataTable Consultar_Parametros()
        {
            string Mi_SQL;
            DataTable Dt_Resultado;
            Boolean Transaccion_Activa = false;

            // validar si hay transacción activa
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

                Mi_SQL = "SELECT * FROM " + Cat_Parametros.Tabla_Cat_Parametros;

                Dt_Resultado = Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL);

                // si no había una transacción activa antes de llamar al método, terminar la transacción
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception E)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Consultar parámetros: " + E.Message);
            }
            finally
            {
                // si no había una transacción activa antes de iniciar el método actual, terminar la transacción
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }
            return Dt_Resultado;
        }

    }
}