using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Erp.Constantes;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Impresoras_Cajas_Negocio
    {
        #region Variables Internas

        private String Caja_ID;
        private String Impresora_Pago = "";
        private String Impresora_Accesos = "";
        private String Impresora_Servicios = "";
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;

        #endregion Variables Internas

        #region Variables Publicas

        public String P_Caja_ID
        {
            get { return Caja_ID; }
            set { Caja_ID = value; }
        }
        public String P_Impresora_Pago
        {
            get { return Impresora_Pago; }
            set { Impresora_Pago = value; }
        }
        public String P_Impresora_Accesos
        {
            get { return Impresora_Accesos; }
            set { Impresora_Accesos = value; }
        }
        public String P_Impresora_Servicios
        {
            get { return Impresora_Servicios; }
            set { Impresora_Servicios = value; }
        }
        public String P_Usuario_Creo
        {
            get { return Usuario_Creo; }
            set { Usuario_Creo = value; }
        }
        public DateTime P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
        }
        public String P_Usuario_Modifico
        {
            get { return Usuario_Modifico; }
            set { Usuario_Modifico = value; }
        }
        public DateTime P_Fecha_Modifico
        {
            get { return Fecha_Modifico; }
            set { Fecha_Modifico = value; }
        }
        #endregion

        #region Metodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Impresoras_Cajas
        ///DESCRIPCIÓN          : Da de alta las impresoras de las cajas en el sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Alta_Impresoras_Cajas()
        {
            Cls_Cat_Impresoras_Cajas_Datos.Alta_Impresoras_Cajas(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Impresoras_Cajas
        ///DESCRIPCIÓN          : Modifica las impresoras de las cajas del sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Impresoras_Cajas()
        {
            Cls_Cat_Impresoras_Cajas_Datos.Modificar_Impresoras_Cajas(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Impresoras_Cajas
        ///DESCRIPCIÓN          : Elimina las impresoras de las cajas del sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Impresoras_Cajas()
        {
            Cls_Cat_Impresoras_Cajas_Datos.Eliminar_Impresoras_Cajas(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Impresoras_Cajas
        ///DESCRIPCIÓN          : Regresa un DataTable con las impresoras de las cajas del sistema.
        ///PARAMETROS           : 
        ///CREO                 : Luis Eugenio Razo Mendiola
        ///FECHA_CREO           : 25/Oct/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public System.Data.DataTable Consultar_Impresoras_Cajas()
        {
            return Cls_Cat_Impresoras_Cajas_Datos.Consultar_Impresoras_Cajas(this);
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Obtener_Impresoras_Cajas
        ///DESCRIPCIÓN: Manda llamar el método de Consultar_Impresoras_Cajas de la clase de datos y regresa una nueva 
        ///             instancia de Cls_Cat_Impresoras_Cajas_Negocio con los valores de la consulta en las propiedades
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 15-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public Cls_Cat_Impresoras_Cajas_Negocio Obtener_Impresoras_Cajas()
        {
            var Neg_Impresoras_Cajas = new Cls_Cat_Impresoras_Cajas_Negocio();
            DataTable Dt_Impresoras_Cajas;

            Dt_Impresoras_Cajas = Cls_Cat_Impresoras_Cajas_Datos.Consultar_Impresoras_Cajas();

            if (Dt_Impresoras_Cajas != null && Dt_Impresoras_Cajas.Rows.Count > 0)
            {
                for (int Cont_For = 0; Cont_For < Dt_Impresoras_Cajas.Rows.Count; Cont_For++)
                {
                    if (ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID == Dt_Impresoras_Cajas.Rows[Cont_For][Cat_Impresoras_Cajas.Campo_Caja_ID].ToString())
                    {
                        Neg_Impresoras_Cajas.P_Caja_ID = Dt_Impresoras_Cajas.Rows[Cont_For][Cat_Impresoras_Cajas.Campo_Caja_ID].ToString();
                        Neg_Impresoras_Cajas.P_Impresora_Pago = Dt_Impresoras_Cajas.Rows[Cont_For][Cat_Impresoras_Cajas.Campo_Impresora_Pago].ToString();
                        Neg_Impresoras_Cajas.P_Impresora_Accesos = Dt_Impresoras_Cajas.Rows[Cont_For][Cat_Impresoras_Cajas.Campo_Impresora_Accesos].ToString();
                        Neg_Impresoras_Cajas.P_Impresora_Servicios = Dt_Impresoras_Cajas.Rows[Cont_For][Cat_Impresoras_Cajas.Campo_Impresora_Servicios].ToString();
                    }
                }
            }

            return Neg_Impresoras_Cajas;
        }

        #endregion Metodos
    }
}
