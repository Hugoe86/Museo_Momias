using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Erp.Constantes;
using Acceso_Museo.App_Code.BD;

namespace Erp.Ayudante_Lector_Codigo
{
    public class Cls_Ayudante_Lector_Codigo
    {
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Envia_Correo
        ///DESCRIPCIÓN  : Envia un correo a un usuario
        ///PARAMENTROS  :
        ///CREO         : Sergio Manuel Gallardo Andrade
        ///FECHA_CREO   : 25/Feb/2013
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************

        public static DataTable Consultar_Puerto(String Nombre_Terminal)
        {
            StringBuilder Mi_SQL = new StringBuilder();

            try
            {
                BDMySQL BD = new BDMySQL();

                Mi_SQL.Append("SELECT * FROM " + Cat_Parametros_Lector_Codigo.Tabla_Cat_Parametros_Lector_Codigo);

                return BD.Consultar(Mi_SQL.ToString());
            }
            catch (Exception E)
            {
                throw new Exception("Consultar_Puerto: " + E.Message);
            }
        }
    }
}
