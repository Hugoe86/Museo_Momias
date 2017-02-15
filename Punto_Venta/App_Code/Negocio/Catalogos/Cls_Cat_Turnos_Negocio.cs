using System;
using System.Data;
using Catalogos.Turnos.Datos;

namespace Catalogos.Turnos.Negocio
{
    public class Cls_Cat_Turnos_Negocio
    {
        #region Variables_Privadas
        private String Turno_ID;
        private String Nombre;
        private String Comentarios;
        private String Hora_Inicio;
        private String Hora_Cierre;
        private String Estatus;
        private String Fijo;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        #endregion

        #region Metodos_Acceso_Publico
        public String P_Turno_ID
        {
            get { return Turno_ID; }
            set { Turno_ID = value; }
        }
        public String P_Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        public String P_Comentarios
        {
            get { return Comentarios; }
            set { Comentarios = value; }
        }
        public String P_Hora_Inicio
        {
            get { return Hora_Inicio; }
            set { Hora_Inicio = value; }
        }
        public String P_Hora_Cierre
        {
            get { return Hora_Cierre; }
            set { Hora_Cierre = value; }
        }
        public String P_Estatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public String P_Fijo
        {
            get { return Fijo; }
            set { Fijo = value; }
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

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Turnos
        ///DESCRIPCIÓN          : Llama al método Alta_Turnos de la capa de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Turnos()
        {
            return Cls_Cat_Turnos_Datos.Alta_Turnos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Turno
        ///DESCRIPCIÓN          : Modifica un turno en la base de datos
        ///PARÁMETROS           : Llama el método Modificar_Turno de la capa de datos
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 04 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        public void Modificar_Turno() 
        {
            Cls_Cat_Turnos_Datos.Modificar_Turno(this);
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Turnos
        ///DESCRIPCIÓN: Manda llamar el método de Consultar_Turnos de la clase de datos y regresa un datatable
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 03-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public DataTable Consultar_Turnos()
        {
            return Cls_Cat_Turnos_Datos.Consultar_Turnos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Turno
        ///DESCRIPCIÓN          : Llama al método Eliminar_Turno de la capa de de datos.
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 07 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Turno() 
        {
            Cls_Cat_Turnos_Datos.Eliminar_Turno(this);
        }
        #endregion
    }
}
