using System;
using Erp_Apl_Contratos.Datos;

namespace Erp_Apl_Contratos.Negocio
{
    public class Cls_Apl_Contratos_Negocio
    {
        #region Variables Internas

            private String Contrato_Id = String.Empty;
            private String Empresa_Id = String.Empty;
            private String Tipo_Sistema = String.Empty;
            private String Costo = String.Empty;
            private String Comentarios = String.Empty;
            private String Nombre_Base_Datos = String.Empty;
            private String Usuario_Base_Datos = String.Empty;
            private String Contrasenia_Base_Datos = String.Empty;
            private String Ip_Base_Datos = String.Empty;
            private String Fecha_Contrato = String.Empty;
            private String Fecha_Renovacion = String.Empty;
            private String Fecha_Expira = String.Empty;
            private String Estatus = String.Empty;

        #endregion

        #region Variables Publicas

            public String P_Contrato_Id
            {
                get { return Contrato_Id; }
                set { Contrato_Id = value; }
            }
            public String P_Empresa_Id
            {
                get { return Empresa_Id; }
                set { Empresa_Id = value; }
            }
            public String P_Tipo_Sistema
            {
                get { return Tipo_Sistema; }
                set { Tipo_Sistema = value; }
            }
            public String P_Costo
            {
                get { return Costo; }
                set { Costo = value; }
            }
            public String P_Comentarios
            {
                get { return Comentarios; }
                set { Comentarios = value; }
            }
            public String P_Nombre_Base_Datos
            {
                get { return Nombre_Base_Datos; }
                set { Nombre_Base_Datos = value; }
            }
            public String P_Usuario_Base_Datos
            {
                get { return Usuario_Base_Datos; }
                set { Usuario_Base_Datos = value; }
            }
            public String P_Contrasenia_Base_Datos
            {
                get { return Contrasenia_Base_Datos; }
                set { Contrasenia_Base_Datos = value; }
            }
            public String P_Ip_Base_Datos
            {
                get { return Ip_Base_Datos; }
                set { Ip_Base_Datos = value; }
            }
            public String P_Fecha_Contrato
            {
                get { return Fecha_Contrato; }
                set { Fecha_Contrato = value; }
            }
            public String P_Fecha_Renovacion
            {
                get { return Fecha_Renovacion; }
                set { Fecha_Renovacion = value; }
            }
            public String P_Fecha_Expira
            {
                get { return Fecha_Expira; }
                set { Fecha_Expira = value; }
            }
            public String P_Estatus
            {
                get { return Estatus; }
                set { Estatus = value; }
            }

        #endregion

        #region Metodos

            public void Alta_Contrato()
            {
                Cls_Apl_Contratos_Datos.Alta_Contrato(this);
            }

            public void Modificar_Contrato()
            {
                Cls_Apl_Contratos_Datos.Modificar_Contrato(this);
            }

            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN : Consultar_Contratos
            ///DESCRIPCIÓN          : Regresa un DataTable con los Contratos encontrados.
            ///PARAMETROS           : Modificación en la Base de Datos.
            ///CREO                 : Salvador Vázquez Camacho
            ///FECHA_CREO           : 12/Enero/2013
            ///MODIFICO             :
            ///FECHA_MODIFICO       :
            ///CAUSA_MODIFICACIÓN   :
            ///*******************************************************************************
            public System.Data.DataTable Consultar_Contratos()
            {
                return Cls_Apl_Contratos_Datos.Consultar_Contratos(this);
            }

            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Contrato
            ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Contrato.
            ///PARAMETROS           : Modificación en la Base de Datos.
            ///CREO                 : Salvador Vázquez Camacho
            ///FECHA_CREO           : 12/Enero/2013
            ///MODIFICO             :
            ///FECHA_MODIFICO       :
            ///CAUSA_MODIFICACIÓN   :
            ///*******************************************************************************
            public Cls_Apl_Contratos_Negocio Consultar_Detalles_Contrato()
            {
                return Cls_Apl_Contratos_Datos.Consultar_Detalles_Contrato(this);
            }

            public void Eliminar_Contrato()
            {
                Cls_Apl_Contratos_Datos.Eliminar_Contrato(this);
            }

        #endregion
    }
}
