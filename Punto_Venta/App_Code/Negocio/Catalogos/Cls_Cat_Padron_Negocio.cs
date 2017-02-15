using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp.Constantes;
using ERP_BASE.App_Code.Datos.Catalogos;


namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Padron_Negocio
    {
        #region Variables
        private String Curp;
        private String Rfc;
        private String Tipo;
        private String Apellido_Paterno;
        private String Apellido_Materno;
        private String Nombre;
        private String Equipo;
        private String Usuario;
        private String Edonac;
        private String Genero;
        private String Estatus;
        private DateTime Fecha_Nacimiento;
        private System.Data.DataTable Dt_Parametros;
        private String Tipo_Lista_Deudor;
        private String Lista_Lista_Deudor;
        private String Clave_Venta_Individual;

        private String Calle;
        private String Numero_Interior;
        private String Numero_Exterior;
        private String Colonia;
        private String Municipio;
        private String Estado;
        private String Codigo_Postal;
        #endregion

        #region Variables Públicas
        public String P_Curp
        {
            get { return Curp; }
            set { Curp = value; }
        }
        public String P_Rfc
        {
            get { return Rfc; }
            set { Rfc = value; }
        }
        public String P_Tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public String P_Apellido_Paterno
        {
            get { return Apellido_Paterno; }
            set { Apellido_Paterno = value; }
        }
        public String P_Apellido_Materno
        {
            get { return Apellido_Materno; }
            set { Apellido_Materno = value; }
        }
        public String P_Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public String P_Equipo
        {
            get { return Equipo; }
            set { Equipo = value; }
        }
        public String P_Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public String P_Edonac
        {
            get { return Edonac; }
            set { Edonac = value; }
        }
        public String P_Genero
        {
            get { return Genero; }
            set { Genero = value; }
        }
        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public DateTime P_Fecha_Nacimiento
        {
            get { return Fecha_Nacimiento; }
            set { Fecha_Nacimiento = value; }
        }
        public System.Data.DataTable P_Dt_Parametros
        {
            get { return Dt_Parametros; }
            set { Dt_Parametros = value; }
        }
        public String P_Tipo_Lista_Deudor
        {
            get { return Tipo_Lista_Deudor; }
            set { Tipo_Lista_Deudor = value; }
        }
        public String P_Lista_Deudor
        {
            get { return Lista_Lista_Deudor; }
            set { Lista_Lista_Deudor = value; }
        }
        public String P_Clave_Venta_Individual
        {
            get { return Clave_Venta_Individual; }
            set { Clave_Venta_Individual = value; }
        }
        


        public String P_Calle
        {
            get { return Calle; }
            set { Calle = value; }
        }
        public String P_Numero_Interior
        {
            get { return Numero_Interior; }
            set { Numero_Interior = value; }
        }
        public String P_Numero_Exterior
        {
            get { return Numero_Exterior; }
            set { Numero_Exterior = value; }
        }
        public String P_Colonia
        {
            get { return Colonia; }
            set { Colonia = value; }
        }
        public String P_Municipio
        {
            get { return Municipio; }
            set { Municipio = value; }
        }
         public String P_Estado
        {
            get { return Estado; }
            set { Estado = value; }
        }
         public String P_Codigo_Postal
         {
             get { return Codigo_Postal; }
             set { Codigo_Postal = value; }
         }
        #endregion

        #region Métodos
        public Boolean Alta_Usuario_Padron()
        {
            return Cls_Cat_Padron_Datos.Alta_Usuario_Padron(this);
        }
        public Boolean Alta_Usuario_Padron_Local()
        {
            return Cls_Cat_Padron_Datos.Alta_Usuario_Padron_Local(this);
        }
        
        public Boolean Alta_Usuario_List_Deudro()
        {
            return Cls_Cat_Padron_Datos.Alta_Usuario_List_Deudro(this);
        }
        public Boolean Alta_Usuario_List_Deudro_Local()
        {
            return Cls_Cat_Padron_Datos.Alta_Usuario_List_Deudro_Local(this);
        }
        public Boolean Modificar_Usuario_Padron()
        {
            return Cls_Cat_Padron_Datos.Modificar_Usuario_Padron(this);
        }
        public Boolean Eliminar_Usuario_Padron()
        {
            return Cls_Cat_Padron_Datos.Eliminar_Usuario_Padron(this);
        }
        public System.Data.DataTable Consultar_Padron()
        {
            return Cls_Cat_Padron_Datos.Consultar_Padron(this);
        }
        public System.Data.DataTable Consultar_Padron_Local()
        {
            return Cls_Cat_Padron_Datos.Consultar_Padron_Local(this);
        }
        public System.Data.DataTable Consultar_Rfc_Duplicado()
        {
            return Cls_Cat_Padron_Datos.Consultar_Rfc_Duplicado(this);
        }
        public System.Data.DataTable Consultar_Rfc_Duplicado_Local()
        {
            return Cls_Cat_Padron_Datos.Consultar_Rfc_Duplicado_Local(this);
        }
        #endregion
    }
}
