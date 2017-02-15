using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Erp_Cat_Nom_Empleados.Datos;

namespace Erp_Cat_Nom_Empleados.Negocio
{
    public class Cls_Cat_Nom_Empleados_Negocio
    {
        public Cls_Cat_Nom_Empleados_Negocio(){ }

        private String Empleado_Id = String.Empty;
        private String Area_Id = String.Empty;
        private String Puesto_Id = String.Empty;
        private String Jefe_Id = String.Empty;
        private String Nombre_Area = String.Empty;
        private String Nombre_Puesto = String.Empty;
        private String Nombre_Jefe = String.Empty;
        private String Nombre_Completo = String.Empty;
        private String Nombres = String.Empty;
        private String Apellido_Paterno = String.Empty;
        private String Apellido_Materno = String.Empty;
        private DateTime Fecha_Nacimiento;
        private String Pais = String.Empty;
        private String Localidad = String.Empty;
        private String Estado = String.Empty;
        private String Colonia = String.Empty;
        private String Ciudad = String.Empty;
        private String Calle = String.Empty;
        private String Numero_Exterior = String.Empty;
        private String Numero_Interior = String.Empty;
        private String Codigo_Postal = String.Empty;
        private String Rfc = String.Empty;
        private String Curp = String.Empty;
        private String No_Imss = String.Empty;
        private String Telefono = String.Empty;
        private String Celular = String.Empty;
        private String Nextel = String.Empty;
        private String Email = String.Empty;
        private String Licencia_Manejo = String.Empty;
        private DateTime Vigencia_Licencia;
        private String Tipo_Sangre = String.Empty;
        private String Alergias = String.Empty;
        private String Sueldo = String.Empty;
        private String Sueldo_Diario = String.Empty;
        private DateTime Fecha_Contratado;
        private DateTime Fecha_Baja;
        private String Motivo_Baja = String.Empty;
        private String Estatus = String.Empty;
        private String Usuario_Creo = String.Empty;
        private String Ip_Creo = String.Empty;
        private String Equipo_Creo = String.Empty;
        private String Usuario_Modifico = String.Empty;
        private String Ip_Modifico = String.Empty;
        private String Equipo_Modifico = String.Empty;

        public String P_Empleado_Id
        {
            get { return Empleado_Id; }
            set { Empleado_Id = value; }
        }

        public String P_Area_Id
        {
            get { return Area_Id; }
            set { Area_Id = value; }
        }

        public String P_Puesto_Id
        {
            get { return Puesto_Id; }
            set { Puesto_Id = value; }
        }

        public String P_Jefe_Id
        {
            get { return Jefe_Id; }
            set { Jefe_Id = value; }
        }

        public String P_Nombre_Area
        {
            get { return Nombre_Area; }
            set { Nombre_Area = value; }
        }

        public String P_Nombre_Jefe
        {
            get { return Nombre_Jefe; }
            set { Nombre_Jefe = value; }
        }

        public String P_Nombre_Puesto
        {
            get { return Nombre_Puesto; }
            set { Nombre_Puesto = value; }
        }

        public String P_Nombre_Completo
        {
            get { return Nombre_Completo; }
            set { Nombre_Completo = value; }
        }

        public String P_Nombres
        {
            get { return Nombres; }
            set { Nombres = value; }
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

        public DateTime P_Fecha_Nacimiento
        {
            get { return Fecha_Nacimiento; }
            set { Fecha_Nacimiento = value; }
        }

        public String P_Pais
        {
            get { return Pais; }
            set { Pais = value; }
        }

        public String P_Localidad
        {
            get { return Localidad; }
            set { Localidad = value; }
        }

        public String P_Estado
        {
            get { return Estado; }
            set { Estado = value; }
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

        public String P_Codigo_Postal
        {
            get { return Codigo_Postal; }
            set { Codigo_Postal = value; }
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

        public String P_No_Imss
        {
            get { return No_Imss; }
            set { No_Imss = value; }
        }

        public String P_Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        public String P_Celular
        {
            get { return Celular; }
            set { Celular = value; }
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

        public String P_Licencia_Manejo
        {
            get { return Licencia_Manejo; }
            set { Licencia_Manejo = value; }
        }

        public DateTime P_Vigencia_Licencia
        {
            get { return Vigencia_Licencia; }
            set { Vigencia_Licencia = value; }
        }

        public String P_Tipo_Sangre
        {
            get { return Tipo_Sangre; }
            set { Tipo_Sangre = value; }
        }

        public String P_Alergias
        {
            get { return Alergias; }
            set { Alergias = value; }
        }

        public String P_Sueldo
        {
            get { return Sueldo; }
            set { Sueldo = value; }
        }

        public String P_Sueldo_Diario
        {
            get { return Sueldo_Diario; }
            set { Sueldo_Diario = value; }
        }

        public DateTime P_Fecha_Contratado
        {
            get { return Fecha_Contratado; }
            set { Fecha_Contratado = value; }
        }

        public DateTime P_Fecha_Baja
        {
            get { return Fecha_Baja; }
            set { Fecha_Baja = value; }
        }

        public String P_Motivo_Baja
        {
            get { return Motivo_Baja; }
            set { Motivo_Baja = value; }
        }

        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public String P_Usuario_Creo
        {
            get { return Usuario_Creo; }
            set { Usuario_Creo = value; }
        }

        public String P_Ip_Creo
        {
            get { return Ip_Creo; }
            set { Ip_Creo = value; }
        }

        public String P_Equipo_Creo
        {
            get { return Equipo_Creo; }
            set { Equipo_Creo = value; }
        }

        public String P_Usuario_Modifico
        {
            get { return Usuario_Modifico; }
            set { Usuario_Modifico = value; }
        }

        public String P_Ip_Modifico
        {
            get { return Ip_Modifico; }
            set { Ip_Modifico = value; }
        }

        public String P_Equipo_Modifico
        {
            get { return Equipo_Modifico; }
            set { Equipo_Modifico = value; }
        }

        public Boolean Alta_Empleado()
        {
            return Cls_Cat_Nom_Empleados_Datos.Alta_Empleado(this);
        }

        public Boolean Modificar_Empleado()
        {
            return Cls_Cat_Nom_Empleados_Datos.Modificar_Empleado(this);
        }

        public Boolean Eliminar_Empleado()
        {
            return Cls_Cat_Nom_Empleados_Datos.Baja_Empleado(this);
        }

        public DataTable Consultar_Empleados()
        {
            return Cls_Cat_Nom_Empleados_Datos.Consultar_Empleados(this);
        }
    }
}