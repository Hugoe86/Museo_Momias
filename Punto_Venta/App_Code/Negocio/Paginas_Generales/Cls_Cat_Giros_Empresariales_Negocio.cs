using System;
using Erp_Cat_Giros_Empresariales.Datos;

namespace Erp_Cat_Giros_Empresariales.Negocio
{
    public class Cls_Cat_Giros_Empresariales_Negocio
    {

        #region Variables Internas

            private String Giro_Id = String.Empty;
            private String Nombre = String.Empty;
            private String Descripcion = String.Empty;
            private String Estatus = String.Empty;

        #endregion

        #region Variables Publicas

            public String P_Giro_Id
            {
                get { return Giro_Id; }
                set { Giro_Id = value; }
            }
            public String P_Nombre
            {
                get { return Nombre; }
                set { Nombre = value; }
            }
            public String P_Descripcion
            {
                get { return Descripcion; }
                set { Descripcion = value; }
            }
            public String P_Estatus
            {
                get { return Estatus; }
                set { Estatus = value; }
            }

        #endregion

        #region Metodos

            public void Alta_Giro_Empresarial()
            {
                Cls_Cat_Giros_Empresariales_Datos.Alta_Giro_Empresarial(this);
            }

            public void Modificar_Giro_Empresarial()
            {
                Cls_Cat_Giros_Empresariales_Datos.Modificar_Giro_Empresarial(this);
            }

            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN : Consultar_Giro_Empresarials
            ///DESCRIPCIÓN          : Regresa un DataTable con los Giro_Empresarials encontrados.
            ///PARAMETROS           : Modificación en la Base de Datos.
            ///CREO                 : Salvador Vázquez Camacho
            ///FECHA_CREO           : 12/Enero/2013
            ///MODIFICO             :
            ///FECHA_MODIFICO       :
            ///CAUSA_MODIFICACIÓN   :
            ///*******************************************************************************
            public System.Data.DataTable Consultar_Giro_Empresariales()
            {
                return Cls_Cat_Giros_Empresariales_Datos.Consultar_Giro_Empresariales(this);
            }

            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Giro_Empresarial
            ///DESCRIPCIÓN          : Regresa un objeto con los datos de un Giro_Empresarial.
            ///PARAMETROS           : Modificación en la Base de Datos.
            ///CREO                 : Salvador Vázquez Camacho
            ///FECHA_CREO           : 12/Enero/2013
            ///MODIFICO             :
            ///FECHA_MODIFICO       :
            ///CAUSA_MODIFICACIÓN   :
            ///*******************************************************************************
            public Cls_Cat_Giros_Empresariales_Negocio Consultar_Detalles_Giro_Empresarial()
            {
                return Cls_Cat_Giros_Empresariales_Datos.Consultar_Detalles_Giro_Empresarial(this);
            }

            public void Eliminar_Giro_Empresarial()
            {
                Cls_Cat_Giros_Empresariales_Datos.Eliminar_Giro_Empresarial(this);
            }

        #endregion
    }
}
