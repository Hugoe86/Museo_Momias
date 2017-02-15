using System;
using Erp_Cat_Clientes.Datos;

namespace Erp_Cat_Clientes.Negocio
{
    public class Cls_Cat_Clientes_Negocio
    {
        #region Variables Internas

            private String Cliente_Id = String.Empty;
            private String Giro_Id = String.Empty;
            private String Nombre_Corto = String.Empty;
            private String Razon_Social = String.Empty;
            private String Rfc = String.Empty;
            private String Curp = String.Empty;
            private String Pais = String.Empty;
            private String Estado = String.Empty;
            private String Localidad = String.Empty;
            private String Colonia = String.Empty;
            private String Ciudad = String.Empty;
            private String Calle = String.Empty;
            private String Numero_Exterior = String.Empty;
            private String Numero_Interior = String.Empty;
            private String Cp = String.Empty;
            private String Fax = String.Empty;
            private String Telefono_1 = String.Empty;
            private String Telefono_2 = String.Empty;
            private String Extension = String.Empty;
            private String Nextel = String.Empty;
            private String Email = String.Empty;
            private String Sitio_Web = String.Empty;
            private String Dias_Credito = String.Empty;
            private String Limite_Credito = String.Empty;
            private String Descuento = String.Empty;
            private String Estatus = String.Empty;

        #endregion

        #region Variables Publicas

            public String P_Cliente_Id
            {
                get { return Cliente_Id; }
                set { Cliente_Id = value; }
            }
            public String P_Giro_Id
            {
                get { return Giro_Id; }
                set { Giro_Id = value; }
            }
            public String P_Nombre_Corto
            {
                get { return Nombre_Corto; }
                set { Nombre_Corto = value; }
            }
            public String P_Razon_Social
            {
                get { return Razon_Social; }
                set { Razon_Social = value; }
            }
            public String P_Rfc
            {
                get { return Rfc; }
                set { Rfc = value; }
            }
            public String P_Curp
            {
                get { return Curp; }
                set { Curp = value; }
            }
            public String P_Pais
            {
                get { return Pais; }
                set { Pais = value; }
            }
            public String P_Estado
            {
                get { return Estado; }
                set { Estado = value; }
            }
            public String P_Localidad
            {
                get { return Localidad; }
                set { Localidad = value; }
            }
            public String P_Colonia
            {
                get { return Colonia; }
                set { Colonia = value; }
            }
            public String P_Ciudad
            {
                get { return Ciudad; }
                set { Ciudad = value; }
            }
            public String P_Calle
            {
                get { return Calle; }
                set { Calle = value; }
            }
            public String P_Numero_Exterior
            {
                get { return Numero_Exterior; }
                set { Numero_Exterior = value; }
            }
            public String P_Numero_Interior
            {
                get { return Numero_Interior; }
                set { Numero_Interior = value; }
            }
            public String P_Cp
            {
                get { return Cp; }
                set { Cp = value; }
            }
            public String P_Fax
            {
                get { return Fax; }
                set { Fax = value; }
            }
            public String P_Telefono_1
            {
                get { return Telefono_1; }
                set { Telefono_1 = value; }
            }
            public String P_Telefono_2
            {
                get { return Telefono_2; }
                set { Telefono_2 = value; }
            }
            public String P_Extension
            {
                get { return Extension; }
                set { Extension = value; }
            }
            public String P_Nextel
            {
                get { return Nextel; }
                set { Nextel = value; }
            }
            public String P_Email
            {
                get { return Email; }
                set { Email = value; }
            }
            public String P_Sitio_Web
            {
                get { return Sitio_Web; }
                set { Sitio_Web = value; }
            }
            public String P_Dias_Credito
            {
                get { return Dias_Credito; }
                set { Dias_Credito = value; }
            }
            public String P_Limite_Credito
            {
                get { return Limite_Credito; }
                set { Limite_Credito = value; }
            }
            public String P_Descuento
            {
                get { return Descuento; }
                set { Descuento = value; }
            }
            public String P_Estatus
            {
                get { return Estatus; }
                set { Estatus = value; }
            }

        #endregion

        #region Metodos

            public void Alta_Cliente()
            {
                Cls_Cat_Clientes_Datos.Alta_Cliente(this);
            }

            public void Modificar_Cliente()
            {
                Cls_Cat_Clientes_Datos.Modificar_Cliente(this);
            }

            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN : Consultar_Clientes
            ///DESCRIPCIÓN          : Regresa un DataTable con los clientes encontrados.
            ///PARAMETROS           : Modificación en la Base de Datos.
            ///CREO                 : Salvador Vázquez Camacho
            ///FECHA_CREO           : 12/Enero/2013
            ///MODIFICO             :
            ///FECHA_MODIFICO       :
            ///CAUSA_MODIFICACIÓN   :
            ///*******************************************************************************
            public System.Data.DataTable Consultar_Clientes()
            {
                return Cls_Cat_Clientes_Datos.Consultar_Clientes(this);
            }

            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN : Consultar_Detalles_Cliente
            ///DESCRIPCIÓN          : Regresa un objeto con los datos de un cliente.
            ///PARAMETROS           : Modificación en la Base de Datos.
            ///CREO                 : Salvador Vázquez Camacho
            ///FECHA_CREO           : 12/Enero/2013
            ///MODIFICO             :
            ///FECHA_MODIFICO       :
            ///CAUSA_MODIFICACIÓN   :
            ///*******************************************************************************
            public Cls_Cat_Clientes_Negocio Consultar_Detalles_Cliente()
            {
                return Cls_Cat_Clientes_Datos.Consultar_Detalles_Cliente(this);
            }

            public void Eliminar_Cliente()
            {
                Cls_Cat_Clientes_Datos.Eliminar_Cliente(this);
            }

        #endregion
    }
}
