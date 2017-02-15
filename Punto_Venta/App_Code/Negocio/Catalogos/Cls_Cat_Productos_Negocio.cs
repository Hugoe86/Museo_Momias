using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    public class Cls_Cat_Productos_Negocio
    {
        #region Variables
        private String Producto_Id;
        private String Nombre;
        private String Descripcion;
        private String Tipo;
        private String Anio;
        private String Tipo_Valor;
        private String Costo;
        private String Estatus;
        private String Ruta_Imagen;
        private String Usuario_Creo;
        private DateTime Fecha_Creo;
        private String Usuario_Modifico;
        private DateTime Fecha_Modifico;
        private String Tipo_Servicio;
        private String Codigo;
        private String Aparece_En_Web;
        private String Relacion_Producto_Id;
        private String Categoria_Id;
        #endregion

        #region Variables Publicas
        public String P_Producto_Id 
        {
            get { return Producto_Id; }
            set { Producto_Id = value; }
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
        public String P_Tipo 
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public String P_Anio
        {
            get { return Anio; }
            set { Anio = value; }
        }
        public String P_Tipo_Valor 
        {
            get { return Tipo_Valor; }
            set { Tipo_Valor = value; }
        }
        public String P_Costo
        { 
            get { return Costo; }
            set { Costo = value; }
        }
        public String P_Estatus 
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public String P_Ruta_Imagen
        {
            get { return Ruta_Imagen; }
            set { Ruta_Imagen = value; }
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
        public String P_Tipo_Servicio
        {
            get { return Tipo_Servicio; }
            set { Tipo_Servicio = value; }
        }
        public String P_Codigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }
        public String P_Aparece_En_Web
        {
            get { return Aparece_En_Web; }
            set { Aparece_En_Web = value; }
        }

        public String P_Relacion_Producto_Id
        {
            get { return Relacion_Producto_Id; }
            set { Relacion_Producto_Id = value; }
        }

        public String P_Categoria_ID
        {
            get { return Categoria_Id; }
            set { Categoria_Id = value; }
        }

        #endregion

        #region Métodos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Productos
        ///DESCRIPCIÓN          : Llama el método de Alta_Productos de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Boolean Alta_Productos()
        {
            return Cls_Cat_Productos_Datos.Alta_Productos(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Producto
        ///DESCRIPCIÓN          : Llama el método de Modificar_Producto de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Modificar_Producto()
        {
            Cls_Cat_Productos_Datos.Modificar_Producto(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Producto
        ///DESCRIPCIÓN          : Llama el método de Consultar_Producto de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Producto()
        {
            return Cls_Cat_Productos_Datos.Consultar_Producto(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Producto
        ///DESCRIPCIÓN          : Llama el método de Consultar_Producto de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Producto_Venta()
        {
            return Cls_Cat_Productos_Datos.Consultar_Producto_Venta(this);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Producto
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Producto de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Eliminar_Producto()
        {
            Cls_Cat_Productos_Datos.Eliminar_Producto(this);
        }
         ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Producto
        ///DESCRIPCIÓN          : Llama el método de Eliminar_Producto de la clase de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Producto_X_Anio()
        {
            return Cls_Cat_Productos_Datos.Consultar_Producto_X_Anio(this);
        }
        
        #endregion
    }
}
