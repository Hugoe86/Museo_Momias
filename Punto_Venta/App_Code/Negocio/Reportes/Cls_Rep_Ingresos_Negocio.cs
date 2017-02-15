using Reportes.Ingresos.Datos;
using System.Data;
using System;

namespace Reportes.Ingresos.Negocio
{
    class Cls_Rep_Ingresos_Negocio
    {

        #region PROPIEDADES

        private int Anio_Inicio;
        private int Anio_Final;
        private DateTime Fecha_Inicio;
        private DateTime Fecha_Final;
        private string Tarifa_Id;
        private string Turno_ID;
        private string Numero_Caja;
        private string Forma_ID;
        private string Museo_ID;
        private string No_Venta_Mixto;
        private string No_Venta_Detalle;

        private string No_Caja;
        private string Turno;
        private string Producto_Id;

        public string P_Lugar_Venta { set; get; }
        
        private string Anios_Busqueda;
        private string Meses_Busqueda;

        public int P_Anio_Inicio
        {
            get { return Anio_Inicio; }
            set { Anio_Inicio = value; }
        }

        public int P_Anio_Final
        {
            get { return Anio_Final; }
            set { Anio_Final = value; }
        }

        public DateTime P_Fecha_Inicio
        {
            get { return Fecha_Inicio; }
            set { Fecha_Inicio = value; }
        }
        public DateTime P_Fecha_Final
        {
            get { return Fecha_Final; }
            set { Fecha_Final = value; }
        }

        public string P_Tarifa_Id
        {
            get { return Tarifa_Id; }
            set { Tarifa_Id = value; }
        }
        public string P_No_Caja
        {
            get { return No_Caja; }
            set { No_Caja = value; }
        }
        public string P_Turno
        {
            get { return Turno; }
            set { Turno = value; }
        }
       
        public string P_Turno_ID
        {
            get { return Turno_ID; }
            set { Turno_ID = value; }
        }

        public string P_Numero_Caja
        {
            get { return Numero_Caja; }
            set { Numero_Caja = value; }
        }

        public string P_No_Venta_Mixto
        {
            get { return No_Venta_Mixto; }
            set { No_Venta_Mixto = value; }
        }

        public string P_No_Venta_Detalle
        {
            get { return No_Venta_Detalle; }
            set { No_Venta_Detalle = value; }
        }

        public string P_Forma_ID
        {
            get { return Forma_ID; }
            set { Forma_ID = value; }
        }

        public string P_Producto_Id
        {
            get { return Producto_Id; }
            set { Producto_Id = value; }
        }

        public string P_Anios_Busqueda
        {
            get { return Anios_Busqueda; }
            set { Anios_Busqueda = value; }
        }

        public string P_Meses_Busqueda
        {
            get { return Meses_Busqueda; }
            set { Meses_Busqueda = value; }
        }

        public string P_Museo_ID
        {
            get { return Museo_ID; }
            set { Museo_ID = value; }
        }
        #endregion PROPIEDADES


        #region METODOS

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener el año mínimo de ingresos en la tabla de pagos
        /// </summary>
        /// <returns>entero con el número de año resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>27-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public int Consultar_Anio_Minimo_Ingresos()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Anio_Minimo_Ingresos();
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener el año máximo de ingresos en la tabla de pagos
        /// </summary>
        /// <returns>entero con el número de año resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>27-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public int Consultar_Anio_Maximo_Ingresos()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Anio_Maximo_Ingresos();
        }

        ///*******************************************************************************************************
        /// <summary>
        /// obtener los diferentes años en la tabla de pagos
        /// </summary>
        /// <returns>datatable con los años encontrados en la tabla de pagos</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>27-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Anios_Pagos()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Anios_Pagos();
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los ingresos agrupados por mes y año, se puede filtrar asignando 
        /// un rango de años en las propiedades
        /// </summary>
        /// <returns>datatable con los ingresos encontrados para el rango de años seleccionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Ingresos_Anio()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Ingresos_Anio(this);
        }

        /// <summary>
        /// Generar las Tarifas con sus costo por Año.
        /// </summary>
        /// <returns>Las Tarifas agrupadas por Año</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public DataSet Recaudación_Tarifa()
        {
            return Cls_Rep_Ingresos_Datos.Recaudación_Tarifa(this);
        }

        /// <summary>
        /// Generar la Recaudación por Tarifa por Años.
        /// </summary>
        /// <returns>Las Tarifas agrupadas por Año</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public DataSet Recaudacion_Acumulado_Tarifa()
        {
            return Cls_Rep_Ingresos_Datos.Recaudacion_Acumulado_Tarifa(this);
        }

        /// <summary>
        /// Generar el Número de Visitantes por Tarifa por Años.
        /// </summary>
        /// <returns>Las Tarifas agrupadas por Año</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public DataSet Recaudacion_Acumulado_Visitantes()
        {
            return Cls_Rep_Ingresos_Datos.Recaudacion_Acumulado_Visitantes(this);
        }

        /// <summary>
        /// Generar el Concentrado de Recaudación y Visitantes.
        /// </summary>
        /// <returns>Las Tarifas agrupadas por Año</returns>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public DataTable Concentrado()
        {
            return Cls_Rep_Ingresos_Datos.Concentrado(this);
        }


        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los accesos agrupados por año y mes, se puede filtrar asignando 
        /// un rango de años en las propiedades
        /// </summary>
        /// <returns>datatable con los accesos encontrados para el rango de años seleccionado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public DataTable Consultar_Accesos_Anio()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Accesos_Anio(this);
        }


        /// <summary>
        /// Obtener los años mínimo y máximo de pagos en la base de datos
        /// </summary>
        /// <returns>un DataTable con el resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public DataTable Consultar_Rango_Pagos()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Rango_Pagos();
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los ingresos agrupados por mes, año y tarifa, se puede filtrar asignando 
        /// un rango de fechas en las propiedades
        /// </summary>
        /// <returns>datatable con los ingresos encontrados para el rango de fechas asignado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Ingresos_Mensual_Tarifa()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Ingresos_Mensual_Tarifa(this);
        }
        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los ingresos agrupados por mes, año y tarifa, se puede filtrar asignando 
        /// un rango de fechas en las propiedades
        /// </summary>
        /// <returns>datatable con los ingresos encontrados para el rango de fechas asignado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Ingresos_Accesos_Mensual()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Ingresos_Accesos_Mensual(this);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los accesos agrupados por mes, año y tarifa, se puede filtrar asignando 
        /// un rango de fechas en las propiedades
        /// </summary>
        /// <returns>datatable con los accesos encontrados para el rango de fechas asignado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>29-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Accesos_Mensual_Tarifa()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Accesos_Mensual_Tarifa(this);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los ingresos agrupados día y tarifa, se puede filtrar asignando 
        /// un rango de fechas en las propiedades
        /// </summary>
        /// <returns>datatable con los ingresos encontrados para el rango de fechas asignado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Ingresos_Diarios()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Ingresos_Diarios(this);
        }

        /// <summary>
        /// Se genera la información para el Reporte de Crystal.
        /// </summary>
        /// <returns></returns>
        public DataTable Consultar_Ingresos_Diarios_Crystal()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Ingresos_Diarios_Crystal(this);
        }

        /// <summary>
        /// Obtiene la información de los Visitantes y Recaudación.
        /// </summary>
        /// <param name="Anterior">Define si se obtiene la información del Año anterior.</param>
        /// <returns></returns>
        public DataTable Consultar_Comparativo(bool Anterior)
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Comparativo(this, Anterior);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los accesos agrupados por día y tarifa, se puede filtrar asignando 
        /// un rango de fechas en las propiedades
        /// </summary>
        /// <returns>datatable con los accesos encontrados para el rango de fechas asignado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Accesos_Diarios()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Accesos_Diarios(this);
        }
        public DataTable Consultar_Accesos_Sin_Formato()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Accesos_Sin_Formato(this);
        }

        
        ///*******************************************************************************************************
        /// <summary>
        /// Obtener los accesos agrupados por día y tarifa, se puede filtrar asignando 
        /// un rango de fechas en las propiedades
        /// </summary>
        /// <returns>datatable con los accesos encontrados para el rango de fechas asignado</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>30-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Accesos_Promedio_Tarifa()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Accesos_Promedio_Tarifa(this);
        }

        public DataTable Consultar_Reporte_Diario_Recuadiacion_Tarifa()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Reporte_Diario_Recuadiacion_Tarifa(this);
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Obtener el año máximo de ingresos en la tabla de pagos
        /// </summary>
        /// <returns>entero con el número de año resultado de la consulta</returns>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>27-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        public DataTable Consultar_Ventas_Dia_Mixtas()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_Ventas_Dia_Mixtas(this);
        }


        public DataTable Consultar_No_Venta_Detalle()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_No_Venta_Detalle(this);
        }
        public DataTable Consultar_No_Venta_Detalle_Pago()
        {
            return Cls_Rep_Ingresos_Datos.Consultar_No_Venta_Detalle_Pago(this);
        }
        
        #endregion METODOS

    }
}
