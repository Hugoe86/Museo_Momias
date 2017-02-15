using System;
using System.Data;
using Erp_Apl_Parametros.Datos;
using Erp.Constantes;

namespace Erp_Apl_Parametros.Negocio
{
    public class Cls_Apl_Parametros_Negocio
    {
        #region Variables Internas

        private String Parametro_Id = String.Empty;
        private int Dias_Vigencia = 0;
        private String Directorio_Compartido = String.Empty;
        private String Encabezado_Recibo = "";
        private String Mensaje_Dia_Recibo = "";
        private String Email = String.Empty;
        private String Contrasenia = String.Empty;
        private String Host_Email = String.Empty;
        private String Puerto = String.Empty;
        private String Mensaje_Sistema = String.Empty;
        private String Leyenda_WEB = String.Empty;
        private DateTime Vigencia_WEB;

        private String Afiliacion_PinPad = String.Empty;
        private String Usuario_PinPad = String.Empty;
        private String Contrasenia_PinPad = String.Empty;
        private String Operacion_PinPad = String.Empty;
        private String Banorte_URL = String.Empty;

        private string Tope_Recoleccion = String.Empty;
        private string Mensaje_Ticket = String.Empty;
        private string Rol_Administrador_Id = String.Empty;
        private string Porcentaje_Faltante = String.Empty;
        private string Producto_Id_Web = String.Empty;

        private string Cuenta_Momias = String.Empty;
        private string Ip_A_Enviar_Ventas = String.Empty;
        private string Usuario_A_Enviar_Ventas = String.Empty;
        private string Password_A_Enviar_Ventas = String.Empty;
        private string Base_Datos_A_Enviar_Ventas = String.Empty;
        private string Tipo_Deudorcad = String.Empty;
        private string Lista_Deudorcad = String.Empty;
        private string Clave_Venta_Deudorcad = String.Empty;
        private string Clave_Sobrante_Deudorcad = String.Empty;
        private string Clave_Venta_Individual_Deudorcad = String.Empty;
        private string Clave_Internet = String.Empty;
        private String Version_Bd = "";

        #endregion Variables Internas

        #region Variables Publicas

        public String P_Parametro_Id
        {
            get { return Parametro_Id; }
            set { Parametro_Id = value; }
        }

        public int P_Dias_Vigencia
        {
            get { return Dias_Vigencia; }
            set { Dias_Vigencia = value; }
        }

        public String P_Directorio_Compartido
        {
            get { return Directorio_Compartido; }
            set { Directorio_Compartido = value; }
        }


        public String P_Encabezado_Recibo
        {
            get { return Encabezado_Recibo; }
            set { Encabezado_Recibo = value; }
        }

        public String P_Mensaje_Dia_Recibo
        {
            get { return Mensaje_Dia_Recibo; }
            set { Mensaje_Dia_Recibo = value; }
        }

        public String P_Email
        {
            get { return Email; }
            set { Email = value; }
        }

        public String P_Contrasenia
        {
            get { return Contrasenia; }
            set { Contrasenia = value; }
        }

        public String P_Host_Email
        {
            get { return Host_Email; }
            set { Host_Email = value; }
        }

        public String P_Puerto
        {
            get { return Puerto; }
            set { Puerto = value; }
        }

        public String P_Mensaje_Sistema
        {
            get { return Mensaje_Sistema; }
            set { Mensaje_Sistema = value; }
        }

        public String P_Tope_Recoleccion
        {
            get { return Tope_Recoleccion; }
            set { Tope_Recoleccion = value; }
        }

        public String P_Mensaje_Ticket
        {
            get { return Mensaje_Ticket; }
            set { Mensaje_Ticket = value; }
        }

        public String P_Rol_Administrador_Id
        {
            get { return Rol_Administrador_Id; }
            set { Rol_Administrador_Id = value; }
        }
        public String P_Porcentaje_Faltante
        {
            get { return Porcentaje_Faltante; }
            set { Porcentaje_Faltante = value; }
        }
        public String P_Cuenta_Momias
        {
            get { return Cuenta_Momias; }
            set { Cuenta_Momias = value; }
        }
        public String P_Ip_A_Enviar_Ventas
        {
            get { return Ip_A_Enviar_Ventas; }
            set { Ip_A_Enviar_Ventas = value; }
        }
        public String P_Producto_Id_Web
        {
            get { return Producto_Id_Web; }
            set { Producto_Id_Web = value; }
        }
        public String P_Usuario_A_Enviar_Ventas
        {
            get { return Usuario_A_Enviar_Ventas; }
            set { Usuario_A_Enviar_Ventas = value; }
        }
        public String P_Password_A_Enviar_Ventas
        {
            get { return Password_A_Enviar_Ventas; }
            set { Password_A_Enviar_Ventas = value; }
        }
        public String P_Base_Datos_A_Enviar_Ventas
        {
            get { return Base_Datos_A_Enviar_Ventas; }
            set { Base_Datos_A_Enviar_Ventas = value; }
        }
        public String P_Tipo_Deudorcad
        {
            get { return Tipo_Deudorcad; }
            set { Tipo_Deudorcad = value; }
        }
        public String P_Lista_Deudorcad
        {
            get { return Lista_Deudorcad; }
            set { Lista_Deudorcad = value; }
        }
        public String P_Clave_Venta_Deudorcad
        {
            get { return Clave_Venta_Deudorcad; }
            set { Clave_Venta_Deudorcad = value; }
        }
        public String P_Clave_Sobrante_Deudorcad
        {
            get { return Clave_Sobrante_Deudorcad; }
            set { Clave_Sobrante_Deudorcad = value; }
        }
        public String P_Clave_Venta_Individual_Deudorcad
        {
            get { return Clave_Venta_Individual_Deudorcad; }
            set { Clave_Venta_Individual_Deudorcad = value; }
        }
        public String P_Clave_Internet
        {
            get { return Clave_Internet; }
            set { Clave_Internet = value; }
        }

        public String P_Leyenda_WEB
        {
            get { return Leyenda_WEB; }
            set { Leyenda_WEB = value; }
        }

        public DateTime P_Vigencia_WEB
        {
            get { return Vigencia_WEB; }
            set { Vigencia_WEB = value; }
        }


        public String P_Afiliacion_PinPad
        {
            get { return Afiliacion_PinPad; }
            set { Afiliacion_PinPad = value; }
        }

        public String P_Usuario_PinPad
        {
            get { return Usuario_PinPad; }
            set { Usuario_PinPad = value; }
        }

        public String P_Contrasenia_PinPad
        {
            get { return Contrasenia_PinPad; }
            set { Contrasenia_PinPad = value; }
        }

        public String P_Operacion_PinPad
        {
            get { return Operacion_PinPad; }
            set { Operacion_PinPad = value; }
        }
        public String P_Banorte_URL
        {
            get { return Banorte_URL; }
            set { Banorte_URL = value; }
        }


        public String P_Version_Bd
        {
            get { return Version_Bd; }
            set { Version_Bd = value; }
        }

        #endregion Variables Publicas

        #region Metodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Parametros
        ///DESCRIPCIÓN          : Da de alta los parametros en el sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_CREO           : 11/Marzo/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Alta_Parametros()
        {
            Cls_Apl_Parametros_Datos.Alta_Parametros(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Parametros
        ///DESCRIPCIÓN          : Modifica los parametros del sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_CREO           : 11/Marzo/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Parametros()
        {
            Cls_Apl_Parametros_Datos.Modificar_Parametros(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Parametros
        ///DESCRIPCIÓN          : Elimina los parametros del sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_CREO           : 11/Marzo/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Parametros()
        {
            Cls_Apl_Parametros_Datos.Eliminar_Parametros(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Clientes
        ///DESCRIPCIÓN          : Regresa un DataTable con los parametros del sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_CREO           : 11/Mar/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Parametros()
        {
            return Cls_Apl_Parametros_Datos.Consultar_Parametros(this);
        }
          ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Clientes
        ///DESCRIPCIÓN          : Regresa un DataTable con los parametros del sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Alberto Salas Garcia
        ///FECHA_CREO           : 11/Mar/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Parametros_Transaccion()
        {
            return Cls_Apl_Parametros_Datos.Consultar_Parametros_Transaccion(this);
        }
        

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Obtener_Parametros
        ///DESCRIPCIÓN: Manda llamar el método de Consultar_Parametros de la clase de datos y regresa una nueva 
        ///             instancia de Cls_Apl_Parametros_Negocio con los valores de la consulta en las propiedades
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 15-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public Cls_Apl_Parametros_Negocio Obtener_Parametros()
        {
            var Neg_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros;
            Dt_Parametros = Cls_Apl_Parametros_Datos.Consultar_Parametros();

            try
            {
                // validar que la tabla contenga registros
                if (Dt_Parametros != null && Dt_Parametros.Rows.Count > 0)
                {
                    int.TryParse(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Dias_Vigencia].ToString(), out Dias_Vigencia);
                    Neg_Parametros.P_Dias_Vigencia = Dias_Vigencia;
                }
                Neg_Parametros.P_Directorio_Compartido = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Directorio_Compartido].ToString();
                Neg_Parametros.P_Encabezado_Recibo = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Encabezado_Recibo].ToString();
                Neg_Parametros.P_Mensaje_Dia_Recibo = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Mensaje_Dia_Recibo].ToString();
                Neg_Parametros.P_Email = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Email].ToString();
                Neg_Parametros.P_Contrasenia = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Contrasenia].ToString();
                Neg_Parametros.P_Host_Email = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Host_Email].ToString();
                Neg_Parametros.P_Puerto = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Puerto].ToString();
                Neg_Parametros.P_Mensaje_Sistema = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Mensaje_Sistema].ToString();

            }
            catch (Exception Ex)
            {
                throw new Exception("Obtener_Parametros: " + Ex.Message);
            }
            return Neg_Parametros;
        }

        #endregion Metodos
    }
}