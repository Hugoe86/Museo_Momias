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

            return Neg_Parametros;
        }

        #endregion Metodos
    }
}