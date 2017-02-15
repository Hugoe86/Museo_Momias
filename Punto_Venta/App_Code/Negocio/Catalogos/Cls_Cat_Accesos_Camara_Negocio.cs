using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ERP_BASE.App_Code.Datos.Catalogos;

namespace ERP_BASE.App_Code.Negocio.Catalogos
{
    class Cls_Cat_Accesos_Camara_Negocio
    {
        #region Variables Internas
        private DateTime Dtime_Fecha;
        #endregion

        #region Variables Publicas

        public DateTime P_Dtime_Fecha
        {
            get { return Dtime_Fecha; }
            set { Dtime_Fecha = value; }
        }
        #endregion

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Migrar_Datos_Camara_Negocio
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 02/Diciembre/2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Migrar_Datos_Camara_Negocio()
        {
            return Cls_Cat_Accesos_Camara_Datos.Migrar_Datos_Camara_Datos(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Migrar_Datos_Pendientes_Camara
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 02/Diciembre/2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Migrar_Datos_Pendientes_Camara()
        {
            return Cls_Cat_Accesos_Camara_Datos.Migrar_Datos_Pendientes_Camara(this);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Consultar_Si_Existe_Registros
        ///DESCRIPCIÓN          : Regresa un DataTable con los Registros encontrados.
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramirez Aguilera
        ///FECHA_CREO           : 02/Diciembre/2014
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public DataTable Consultar_Si_Existe_Registros()
        {
            return Cls_Cat_Accesos_Camara_Datos.Consultar_Si_Existe_Registros(this);
        }
        
    }
}
