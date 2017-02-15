using System;
using System.Data;
using System.Configuration;
 
namespace Erp.Helper
{
    public abstract class HelperGenerico
    {
        #region "Declaración de Variables" 
            protected string Helper_Servidor = "";
            protected string Helper_Base = "";
            protected string Helper_Usuario = "";
            protected string Helper_Password = "";
            protected string Helper_Cadena_Conexion = "";
            protected bool Transaccion_Activa;
            protected IDbConnection Helper_Conexion;
            protected IDbTransaction Helper_Transaccion;
            protected abstract IDbConnection Crear_Conexion(string Cadena_Conexion);
            protected abstract IDbCommand Comando(string Comando_Sql);
            protected abstract IDbDataAdapter Ejecutar_DataAdapter(string Comando_Sql);

        #endregion
 
        #region "Setters y Getters" 

            public string P_Servidor
            {
                get { return Helper_Servidor; }
                set { Helper_Servidor = value; }
            }
     
            public string P_Base
            {
                get { return Helper_Base; }
                set { Helper_Base = value; }
            }
     
            public string P_Usuario
            {
                get { return Helper_Usuario; }
                set { Helper_Usuario = value; }
            }
     
            public string P_Password
            {
                get { return Helper_Password; }
                set { Helper_Password = value; }
            } 

            public string P_Cadena_Conexion
            {
                get { return Helper_Cadena_Conexion; }
                set { Helper_Cadena_Conexion = value; }
            }
     
        #endregion

            #region "Ejecutar"
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Obtener_Data_Reader
            ///DESCRIPCIÓN: Regresa datareader
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public IDataReader Obtener_Data_Reader(string Comando_Sql)
            {
                var Command = Comando(Comando_Sql);
                return Command.ExecuteReader();
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Obtener_Data_Adapter
            ///DESCRIPCIÓN: Asigna el Helper Generico 
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public IDataAdapter Obtener_Data_Adapter(string Comando_Sql)
            {
                var Data_Adapter = Ejecutar_DataAdapter(Comando_Sql);
                return Data_Adapter;
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Obtener_Data_Set
            ///DESCRIPCIÓN: regresa un dataset
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public DataSet Obtener_Data_Set(string Comando_Sql)
            {
                var Data_Set = new DataSet();
                Ejecutar_DataAdapter(Comando_Sql).Fill(Data_Set);
                return Data_Set;
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Obtener_Data_Table
            ///DESCRIPCIÓN: Regresa El datatable
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public DataTable Obtener_Data_Table(string Comando_Sql)
            {
                return Obtener_Data_Set(Comando_Sql).Tables[0].Copy(); 
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Obtener_Escalar
            ///DESCRIPCIÓN: Regresa un Escalar
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public Object Obtener_Escalar(string Comando_Sql)
            {
                var Command = Comando(Comando_Sql);
                return Command.ExecuteScalar();
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Ejecutar_NonQuery
            ///DESCRIPCIÓN: Ejecuta el nonquery
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public int Ejecutar_NonQuery(string Comando_Sql)
            {
                var Command = Comando(Comando_Sql);
                return Command.ExecuteNonQuery();
            }      ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Ejecutar_NonQuery
            ///DESCRIPCIÓN: Ejecuta el nonquery
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public int Ejecutar_NonQuery_Int(string Comando_Sql)
            {
                var Command = Comando(Comando_Sql);
                return Command.ExecuteNonQuery();
            }     
        #endregion 
        #region "Acciones"
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Estado_Conexion
            ///DESCRIPCIÓN: Regresa el estado de conexion 
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public bool Estado_Conexion()
            {
                if (Helper_Conexion.State == ConnectionState.Open)
                    return true;
                else
                    return false;
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Conexion_y_Apertura
            ///DESCRIPCIÓN: Asigna el Helper Generico 
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public bool Conexion_y_Apertura()
            {

                if (Helper_Conexion == null)
                    Helper_Conexion = Crear_Conexion(Helper_Cadena_Conexion);
                if (Helper_Conexion.State != ConnectionState.Open)
                    Helper_Conexion.Open();
                return true;
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Estatus_Transaccion
            ///DESCRIPCIÓN: Regresa el estatus de la transaccion 
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public bool Estatus_Transaccion()
            {
                return Transaccion_Activa;
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Autenticar
            ///DESCRIPCIÓN: Asigna el Helper Generico 
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public bool Autenticar(string Usuario_Conexion, string Password_Conexion)
            {
                P_Usuario = Usuario_Conexion;
                P_Password = Password_Conexion;
                Helper_Conexion = Crear_Conexion(Helper_Cadena_Conexion);

                Helper_Conexion.Open();
                return true;
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Cerrar_Conexion
            ///DESCRIPCIÓN: Cierra la conexion
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public void Cerrar_Conexion()
            {
                if (Helper_Conexion.State != ConnectionState.Closed)
                    Helper_Conexion.Close();
            }        
        #endregion
        #region "Transacciones"
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Iniciar_Transaccion
            ///DESCRIPCIÓN: inicia la transaccion 
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:Sergio Manuel Gallardo Andrade
            ///FECHA_MODIFICO:19/Feb/2013 11:27:47 a.m.
            ///CAUSA_MODIFICACIÓN:Se agrego una validacion de conexion
            ///*******************************************************************************
            public void Iniciar_Transaccion()
            {
                try
                {
                    if (!Transaccion_Activa)
                    {
                        Helper_Transaccion = Helper_Conexion.BeginTransaction();
                        Transaccion_Activa = true;
                    }
                }
                catch
                {
                    Transaccion_Activa = false; 
                }
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Terminar_Transaccion
            ///DESCRIPCIÓN:Termina la transaccion
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:
            ///FECHA_MODIFICO:
            ///CAUSA_MODIFICACIÓN:
            ///*******************************************************************************
            public void Terminar_Transaccion()
            {
                try
                {
                    Helper_Transaccion.Commit(); 
                }
                finally
                {
                    Helper_Transaccion = null;
                    Transaccion_Activa = false;
                }
            }
            ///*******************************************************************************
            ///NOMBRE DE LA FUNCIÓN: Abortar_Transaccion
            ///DESCRIPCIÓN: Cancela la transaccion cuando falla
            ///PARAMENTROS:
            ///CREO: Luis Alberto Salas  Garcia
            ///FECHA_CREO: 14/Feb/2013 11:27:47 a.m. 
            ///MODIFICO:Sergio Manuel Gallardo Andrade
            ///FECHA_MODIFICO:19/Feb/2013 11:27:47 a.m.
            ///CAUSA_MODIFICACIÓN:Se agrego una validacion de conexion
            ///*******************************************************************************
            public void Abortar_Transaccion()
            {
                try
                {
                    Helper_Transaccion.Rollback(); 
                }
                finally
                {
                    Helper_Transaccion = null;
                    Transaccion_Activa = false;
                }
            }
        #endregion
    }
}