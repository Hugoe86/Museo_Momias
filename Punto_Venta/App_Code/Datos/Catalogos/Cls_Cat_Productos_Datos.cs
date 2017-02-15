using System;
using System.Text;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Helper;
using Erp.Metodos_Generales;
using Erp.Constantes;
using Erp.Ayudante_Sintaxis;

namespace ERP_BASE.App_Code.Datos.Catalogos
{
    class Cls_Cat_Productos_Datos
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Productos
        ///DESCRIPCIÓN          : Registra un nuevo producto en la base de datos
        ///PARÁMETROS           : P_Producto que contiene la información del nuevo producto a registrar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static Boolean Alta_Productos(Cls_Cat_Productos_Negocio P_Producto)
        {
            Boolean Alta = false;
            StringBuilder Mi_SQL = new StringBuilder();
            String Usuario_ID = "";
            Boolean Transaccion_Activa = false;
            Conexion.Iniciar_Helper();

            if (!Conexion.HelperGenerico.Estatus_Transaccion())
            {
                Conexion.HelperGenerico.Conexion_y_Apertura();
            }
            else
            {
                Transaccion_Activa = true;
            }

            try
            {
                Conexion.HelperGenerico.Iniciar_Transaccion();
                Usuario_ID = Cls_Metodos_Generales.Obtener_ID_Consecutivo(Cat_Productos.Tabla_Cat_Productos, Cat_Productos.Campo_Producto_Id, "", 5);

                // sustituir el nombre de archivo con el ID si se proporciona una ruta
                if (!string.IsNullOrEmpty(P_Producto.P_Ruta_Imagen))
                {
                    P_Producto.P_Ruta_Imagen = P_Producto.P_Ruta_Imagen.Replace("nombre_temporal.", "p_" + Usuario_ID + ".");
                }

                Mi_SQL.Append("INSERT INTO " + Cat_Productos.Tabla_Cat_Productos + " (");
                Mi_SQL.Append(Cat_Productos.Campo_Producto_Id + ",");
                Mi_SQL.Append(Cat_Productos.Campo_Nombre + ",");
                //if(!String.IsNullOrEmpty(Cat_Productos.Campo_Descripcion))
                //{
                Mi_SQL.Append(Cat_Productos.Campo_Descripcion + ",");
                //}
                Mi_SQL.Append(Cat_Productos.Campo_Tipo + ",");
                if (!String.IsNullOrEmpty(Cat_Productos.Campo_Tipo_Valor))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Tipo_Valor + ",");
                }
                if (!String.IsNullOrEmpty(Cat_Productos.Campo_Costo))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Costo + ",");
                }
                Mi_SQL.Append(Cat_Productos.Campo_Estatus + ",");
                Mi_SQL.Append(Cat_Productos.Campo_Ruta_Imagen + ",");
                Mi_SQL.Append(Cat_Productos.Campo_Usuario_Creo + ",");
                Mi_SQL.Append(Cat_Productos.Campo_Fecha_Creo + ", ");
                Mi_SQL.Append(Cat_Productos.Campo_Tipo_Servicio + ", ");
                Mi_SQL.Append(Cat_Productos.Campo_Codigo);
                Mi_SQL.Append(", " + Cat_Productos.Campo_Web);
                Mi_SQL.Append(", " + Cat_Productos.Campo_Anio);
                
                //  validacion para la relacion del producto
                if (!String.IsNullOrEmpty(P_Producto.P_Relacion_Producto_Id))
                {
                    Mi_SQL.Append(", " + Cat_Productos.Campo_Relacion_Producto_Id);
                }
                //****************************************************************
                Mi_SQL.Append(") VALUES (");
                //****************************************************************
                Mi_SQL.Append("'" + Usuario_ID + "',");
                Mi_SQL.Append("'" + P_Producto.P_Nombre + "',");
                //if (!String.IsNullOrEmpty(P_Producto.P_Descripcion))
                //{
                Mi_SQL.Append("'" + P_Producto.P_Descripcion + "',");
                //}
                Mi_SQL.Append("'" + P_Producto.P_Tipo + "',");
                if (!String.IsNullOrEmpty(P_Producto.P_Tipo_Valor))
                {
                    Mi_SQL.Append(P_Producto.P_Tipo_Valor + ",");
                }
                else
                {
                    Mi_SQL.Append("NULL,");
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Costo))
                {
                    Mi_SQL.Append(P_Producto.P_Costo + ",");
                }
                Mi_SQL.Append("'" + P_Producto.P_Estatus + "',");

                // si no se está utilizando MySQL, asignar ruta, de lo contrario, duplicar el caracter \ para escaparlo en la BD
                if ("MySqlClient" != Cls_Constantes.Gestor_Base_Datos)
                {
                    Mi_SQL.Append("'" + P_Producto.P_Ruta_Imagen + "',");
                }
                else
                {
                    Mi_SQL.Append("'" + P_Producto.P_Ruta_Imagen.Replace(@"\", @"\\") + "',");
                }
                Mi_SQL.Append("'" + P_Producto.P_Usuario_Creo + "',");
                Mi_SQL.Append(Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Producto.P_Fecha_Creo) + ", ");

                if (!string.IsNullOrEmpty(P_Producto.P_Tipo_Servicio))
                    Mi_SQL.Append("'" + P_Producto.P_Tipo_Servicio + "', ");
                else
                    Mi_SQL.Append("null, ");

                if (!string.IsNullOrEmpty(P_Producto.P_Codigo))
                    Mi_SQL.Append("'" + P_Producto.P_Codigo + "'");
                else
                    Mi_SQL.Append("null");

                Mi_SQL.Append(", '" + P_Producto.P_Aparece_En_Web + "'");
                Mi_SQL.Append(", '" + P_Producto.P_Anio + "'");

                //  validacion para la relacion del producto
                if (!String.IsNullOrEmpty(P_Producto.P_Relacion_Producto_Id))
                {
                    Mi_SQL.Append(", '" + P_Producto.P_Relacion_Producto_Id + "'");
                }

                Mi_SQL.Append(")");
                //****************************************************************
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
                Alta = true;

                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Terminar_Transaccion();
                }
            }
            catch (Exception e)
            {
                Conexion.HelperGenerico.Abortar_Transaccion();
                throw new Exception("Alta de Productos : " + e.Message);
            }
            finally
            {
                if (!Transaccion_Activa)
                {
                    Conexion.HelperGenerico.Cerrar_Conexion();
                }
            }

            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Producto
        ///DESCRIPCIÓN          : Registra un nuevo producto en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Modificar_Producto(Cls_Cat_Productos_Negocio P_Producto)
        {
            try
            {
                StringBuilder Mi_SQL = new StringBuilder();
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();

                Mi_SQL.Append("UPDATE " + Cat_Productos.Tabla_Cat_Productos + " SET ");
                if (!String.IsNullOrEmpty(P_Producto.P_Nombre))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Nombre + " = '" + P_Producto.P_Nombre + "',");
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Descripcion))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Descripcion + " = '" + P_Producto.P_Descripcion + "',");
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Tipo))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Tipo + " = '" + P_Producto.P_Tipo + "',");
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Tipo_Valor))
                {
                    if (P_Producto.P_Tipo_Valor == "1" || P_Producto.P_Tipo_Valor.ToLower() == "true")
                    {
                        Mi_SQL.Append(Cat_Productos.Campo_Tipo_Valor + " = 1,");
                    }
                    else
                    {
                        Mi_SQL.Append(Cat_Productos.Campo_Tipo_Valor + " = NULL,");
                    }
                }
                else
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Tipo_Valor + " = NULL,");
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Costo))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Costo + " = " + P_Producto.P_Costo + ",");
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Estatus))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Estatus + " = '" + P_Producto.P_Estatus + "',");
                }
                if (!string.IsNullOrEmpty(P_Producto.P_Ruta_Imagen))
                {
                    // si no se está utilizando MySQL, asignar ruta sin escapar el caracter \
                    if ("MySqlClient" != Cls_Constantes.Gestor_Base_Datos)
                    {
                        Mi_SQL.Append(Cat_Productos.Campo_Ruta_Imagen + " = '" + P_Producto.P_Ruta_Imagen + "',");
                    }
                    else
                    {
                        Mi_SQL.Append(Cat_Productos.Campo_Ruta_Imagen + " = '" + P_Producto.P_Ruta_Imagen.Replace(@"\", @"\\") + "',");
                    }
                }

                if (!string.IsNullOrEmpty(P_Producto.P_Tipo_Servicio))
                    Mi_SQL.Append(Cat_Productos.Campo_Tipo_Servicio + "='" + P_Producto.P_Tipo_Servicio + "', ");

                if (!string.IsNullOrEmpty(P_Producto.P_Codigo))
                    Mi_SQL.Append(Cat_Productos.Campo_Codigo + "='" + P_Producto.P_Codigo + "', ");

                //  validacion para el año
                if (!String.IsNullOrEmpty(P_Producto.P_Anio))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Anio + " = '" + P_Producto.P_Anio + "',");
                }

                //  validacion para la relacion de los productos
                if (!String.IsNullOrEmpty(P_Producto.P_Relacion_Producto_Id))
                {
                    Mi_SQL.Append(Cat_Productos.Campo_Relacion_Producto_Id + " = '" + P_Producto.P_Relacion_Producto_Id + "',");
                }

                if (!string.IsNullOrEmpty(P_Producto.P_Categoria_ID))
                {
                    Mi_SQL.Append("Categoria_ID = '" + P_Producto.P_Categoria_ID + "',");
                }

                Mi_SQL.Append(Cat_Productos.Campo_Web + " = '" + P_Producto.P_Aparece_En_Web + "',");
                Mi_SQL.Append(Cat_Productos.Campo_Usuario_Modifico + " = '" + P_Producto.P_Usuario_Modifico + "',");
                Mi_SQL.Append(Cat_Productos.Campo_Fecha_Modifico + " = " + Cls_Ayudante_Sintaxis.Insertar_Fecha_Hora(P_Producto.P_Fecha_Modifico) + " ");
                Mi_SQL.Append("WHERE " + Cat_Productos.Campo_Producto_Id + " = '" + P_Producto.P_Producto_Id + "'");
                Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Modificar Producto: " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Producto
        ///DESCRIPCIÓN          : Consulta informacion de un producto de la base de datos
        ///PARÁMETROS           : P_Producto que contiene los filtros de los productos a buscar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Producto(Cls_Cat_Productos_Negocio P_Producto)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * ");

                //  from
                Mi_SQL.Append(" FROM " + Cat_Productos.Tabla_Cat_Productos);

                //  where
                if (!String.IsNullOrEmpty(P_Producto.P_Producto_Id))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Producto_Id + " = '" + P_Producto.P_Producto_Id + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Nombre))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Nombre + " LIKE '" + P_Producto.P_Nombre + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Tipo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Tipo + " LIKE '" + P_Producto.P_Tipo + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Estatus))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Estatus + " = '" + P_Producto.P_Estatus + "'");
                    Segundo_Filtro = true;
                }

                if (!String.IsNullOrEmpty(P_Producto.P_Codigo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Codigo + " = '" + P_Producto.P_Codigo + "'");
                    Segundo_Filtro = true;
                }

                //  seccion order by
                Mi_SQL.Append(" order by " + Cat_Productos.Campo_Anio + " desc, " + Cat_Productos.Campo_Nombre + " asc");
                
                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Producto : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
          ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Producto_Venta
        ///DESCRIPCIÓN          : Consulta informacion de un producto de la base de datos
        ///PARÁMETROS           : P_Producto que contiene los filtros de los productos a buscar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Producto_X_Anio(Cls_Cat_Productos_Negocio P_Producto)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT " + Cat_Productos.Campo_Producto_Id);
                Mi_SQL.Append(", concat(" + Cat_Productos.Campo_Anio + ", ' ' ," + Cat_Productos.Campo_Nombre + ") as Nombre");

                //  *******************************************************************
                Mi_SQL.Append(" FROM " + Cat_Productos.Tabla_Cat_Productos);
                //  *******************************************************************

                if (!String.IsNullOrEmpty(P_Producto.P_Relacion_Producto_Id))
                {
                    Mi_SQL.Append(" where " + Cat_Productos.Campo_Producto_Id + "= '" + P_Producto.P_Relacion_Producto_Id + "'");
                }

                //  *******************************************************************
                Mi_SQL.Append(" order by " + Cat_Productos.Campo_Anio + " desc , " + Cat_Productos.Campo_Nombre + " asc");

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Producto : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Producto_Venta
        ///DESCRIPCIÓN          : Consulta informacion de un producto de la base de datos
        ///PARÁMETROS           : P_Producto que contiene los filtros de los productos a buscar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static System.Data.DataTable Consultar_Producto_Venta(Cls_Cat_Productos_Negocio P_Producto)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Boolean Segundo_Filtro = false;

            try
            {
                Conexion.Iniciar_Helper();
                Conexion.HelperGenerico.Conexion_y_Apertura();
                Mi_SQL.Append("SELECT * FROM " + Cat_Productos.Tabla_Cat_Productos);
                /*Mi_SQL.Append("SELECT Producto_Id AS 'ID de Producto',");
                Mi_SQL.Append("Nombre,");
                Mi_SQL.Append("Descripcion AS Descripción,");
                Mi_SQL.Append("Tipo,");
                Mi_SQL.Append("Tipo_Valor AS 'Tiene Servicio',");
                Mi_SQL.Append("Costo,");
                Mi_SQL.Append("Estatus ");
                Mi_SQL.Append("FROM " + Cat_Productos.Tabla_Cat_Productos);*/

                if (!String.IsNullOrEmpty(P_Producto.P_Producto_Id))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Producto_Id + " = '" + P_Producto.P_Producto_Id + "'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Nombre))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Nombre + " LIKE '" + P_Producto.P_Nombre + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Tipo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Tipo + " LIKE '" + P_Producto.P_Tipo + "%'");
                    Segundo_Filtro = true;
                }
                if (!String.IsNullOrEmpty(P_Producto.P_Estatus))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Estatus + " = '" + P_Producto.P_Estatus + "'");
                    Segundo_Filtro = true;
                }

                if (!String.IsNullOrEmpty(P_Producto.P_Codigo))
                {
                    Mi_SQL.Append(Segundo_Filtro ? " AND " : " WHERE ");
                    Mi_SQL.Append(Cat_Productos.Campo_Codigo + " = '" + P_Producto.P_Codigo + "'");
                    Segundo_Filtro = true;
                }

                //  seccion order by
                Mi_SQL.Append(" order by " + Cat_Productos.Campo_Costo + ";");

                return Conexion.HelperGenerico.Obtener_Data_Table(Mi_SQL.ToString());
            }
            catch (Exception e)
            {
                throw new Exception("Consultar Producto : " + e.Message);
            }
            finally
            {
                Conexion.HelperGenerico.Cerrar_Conexion();
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Eliminar_Producto
        ///DESCRIPCIÓN          : Elimina la informacion de un producto de la base de datos
        ///PARÁMETROS           : P_Producto que contiene el id del producto a eliminar
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 03 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public static void Eliminar_Producto(Cls_Cat_Productos_Negocio P_Producto)
        {
            StringBuilder Mi_SQL = new StringBuilder();
            Conexion.Iniciar_Helper();
            Conexion.HelperGenerico.Conexion_y_Apertura();

            Mi_SQL.Append("DELETE FROM " + Cat_Productos.Tabla_Cat_Productos);
            Mi_SQL.Append(" WHERE " + Cat_Productos.Campo_Producto_Id + " = '" + P_Producto.P_Producto_Id + "'");
            Conexion.HelperGenerico.Ejecutar_NonQuery(Mi_SQL.ToString());
            Conexion.HelperGenerico.Cerrar_Conexion();
        }
    }
}
