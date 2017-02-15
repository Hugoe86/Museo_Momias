using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Erp_Apl_Usuarios.Datos;

namespace Erp_Apl_Usuarios.Negocio
{
    public class Cls_Apl_Usuarios_Negocio
    {

        #region Variables
        private String Usuario_Id;
        private String Empleado_Id;
        private String Usuario;
        private String Contrasenia;
        private DateTime Fecha_Expira_Contrasenia;
        private String Email;
        private String No_Intentos_Acceso;
        private String No_Intentos_Recuperar;
        private String Pregunta_Secreta;
        private String Respuesta_Secreta;
        private String Estatus;
        private String Usuario_Creo;
        private String Ip_Creo;
        private String Equipo_Creo;
        private String Fecha_Creo;
        private String Usuario_Modifico;
        private String Ip_Modifico;
        private String Equipo_Modifico;
        private String Fecha_Modifico;
        private DateTime Fecha_Ultimo_Intento;
        private String Nombre_Usuario;
        private String Rol_ID;
        private String Comentarios;
        private String Caja_Id;
        private Boolean Estatus_Caja_Id = false;
        #endregion

        #region Variables Publicas

        public String P_Usuario_Id
        {
            get { return Usuario_Id; }
            set { Usuario_Id = value; }
        }
        public String P_Empleado_Id
        {
            get { return Empleado_Id; }
            set { Empleado_Id = value; }
        }
        public String P_Usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
        public DateTime P_Fecha_Ultimo_Intento
        {
            get { return Fecha_Ultimo_Intento; }
            set { Fecha_Ultimo_Intento = value; }
        }
        public String P_Contrasenia
        {
            get { return Contrasenia; }
            set { Contrasenia = value; }
        }
        public DateTime P_Fecha_Expira_Contrasenia
        {
            get { return Fecha_Expira_Contrasenia; }
            set { Fecha_Expira_Contrasenia = value; }
        }
        public String P_Email
        {
            get { return Email; }
            set { Email = value; }
        }
        public String P_No_Intentos_Acceso
        {
            get { return No_Intentos_Acceso; }
            set { No_Intentos_Acceso = value; }
        }
        public String P_No_Intentos_Recuperar
        {
            get { return No_Intentos_Recuperar; }
            set { No_Intentos_Recuperar = value; }
        }
        public String P_Pregunta_Secreta
        {
            get { return Pregunta_Secreta; }
            set { Pregunta_Secreta = value; }
        }
        public String P_Respuesta_Secreta
        {
            get { return Respuesta_Secreta; }
            set { Respuesta_Secreta = value; }
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
        public String P_Fecha_Creo
        {
            get { return Fecha_Creo; }
            set { Fecha_Creo = value; }
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
        public String P_Fecha_Modifico
        {
            get { return Fecha_Modifico; }
            set { Fecha_Modifico = value; }
        }
        public String P_Nombre_Usuario
        {
            get { return Nombre_Usuario; }
            set { Nombre_Usuario = value; }
        }
        public String P_Rol_ID
        {
            get { return Rol_ID; }
            set { Rol_ID = value; }
        }
        public String P_Comentarios
        {
            get { return Comentarios; }
            set { Comentarios = value; }
        }
        public String P_Caja_Id
        {
            get { return Caja_Id; }
            set { Caja_Id = value; }
        }
        public Boolean P_Estatus_Caja_Id
        {
            get { return Estatus_Caja_Id; }
            set { Estatus_Caja_Id = value; }
        }
        
        #endregion

        #region Metodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuarios
        ///DESCRIPCIÓN          : Manda llamar el método de Alta_Usuarios de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Alvarado Enriquez
        ///FECHA_CREO           : 16/Feb/2013 10:55:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Usuarios()
        {
            return Cls_Apl_Usuarios_Datos.Alta_Usuarios(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Usuarios
        ///DESCRIPCIÓN          : Manda llamar el método de Modificar_Usuario de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Angel Alvarado Enriquez
        ///FECHA_CREO           : 16/Feb/2013 11:05:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Usuario()
        {
            Cls_Apl_Usuarios_Datos.Modificar_Usuario(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Usuario_Activos
        ///DESCRIPCIÓN          : Manda llamar el método de Modificar_Usuario de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Angel Alvarado Enriquez
        ///FECHA_CREO           : 16/Feb/2013 11:05:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Usuario_Activos()
        {
            Cls_Apl_Usuarios_Datos.Modificar_Usuario_Activos(this);
        }
   
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Usuario
        ///DESCRIPCIÓN          : Manda llamar el método de Consultar_Usuario de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Angel Alvarado Enriquez
        ///FECHA_CREO           : 16/Feb/2013 11:10:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
         public DataTable Consultar_Usuario()
        {
            return Cls_Apl_Usuarios_Datos.Consultar_Usuario(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Usuario
        ///DESCRIPCIÓN          : Manda llamar el método de Eliminar_Usuario de la clase de datos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Angel Alvarado Enriquez
        ///FECHA_CREO           : 16/Feb/2013 11:15:00 a.m.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Usuario()
        {
            Cls_Apl_Usuarios_Datos.Eliminar_Usuario(this);
        }

        #endregion

    }
}