using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using Erp_Cat_Nom_Empleados.Negocio;
using Erp_Apl_Roles.Negocio;
using Erp.Constantes;
using Erp_Apl_Usuarios.Negocio;
using Erp.Seguridad;
using Erp.Validador;
using ResizeableForm;
using Erp_Solicitud_Facturacion.Negocio;
using Erp_Apl_Parametros.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace ERP_BASE.Paginas.Operaciones
{
    public partial class Frm_Ope_Exportacion : Form
    {

        Validador_Generico Validador;

        #region Load
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Frm_Ope_Exportacion
        ///DESCRIPCIÓN: 
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public Frm_Ope_Exportacion()
        {
            InitializeComponent();
        }
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Frm_Ope_Exportacion_Load
        ///DESCRIPCIÓN: 
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Frm_Ope_Exportacion_Load(object sender, EventArgs e)
        {
            try
            {
                Consultar_Pendientes_Por_Exportar();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Frm_Ope_Exportacion_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Metodos generales
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Pendientes_Por_Exportar
        ///DESCRIPCIÓN: Consulta la informacion pendiente por enviar
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Consultar_Pendientes_Por_Exportar()
        {
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Exportacion = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DataTable Dt_Consulta = new DataTable();
            try
            {
                Dt_Consulta = Obj_Exportacion.Consultar_Historico();
                Grid_Pendientes.DataSource = Dt_Consulta;

                //Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Pendientes);


                Grid_Pendientes.Columns[Ope_Historico_Exportacion.Campo_Fecha].DefaultCellStyle.Format = "dd/MMM/yyyy";
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Consultar_Pendientes_Por_Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Ventas_Dia
        ///DESCRIPCIÓN: Consulta la informacion pendiente por enviar
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Consultar_Ventas_Dia()
        {
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Exportacion = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DateTime Fecha;
            DataTable Dt_Consulta = new DataTable();
            try
            {
                DateTime.TryParse(Grid_Pendientes.CurrentRow.Cells[0].Value.ToString(), out Fecha);
                Obj_Exportacion.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                Dt_Consulta = Obj_Exportacion.Consultar_Tabla_Adeudos();

                Grid_Ventas.DataSource = Dt_Consulta;
                //Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Ventas);     
                
                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                    Grid_Ventas.SelectedRows[0].Selected = false;
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Consultar_Ventas_Dia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Padron
        ///DESCRIPCIÓN: Consulta la informacion pendiente por enviar
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Consultar_Padron()
        {
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Exportacion = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DateTime Fecha;
            DataTable Dt_Consulta = new DataTable();
            try
            {
                DateTime.TryParse(Grid_Pendientes.CurrentRow.Cells[0].Value.ToString(), out Fecha);
                Obj_Exportacion.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                Dt_Consulta = Obj_Exportacion.Consultar_Nuevos_Usuarios_Padron();
                Grid_Padron.DataSource = Dt_Consulta;
                //Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Ventas);

                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                    Grid_Padron.SelectedRows[0].Selected = false;
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Consultar_Padron", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Lista_Deudores
        ///DESCRIPCIÓN: Consulta la informacion pendiente por enviar
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public void Consultar_Lista_Deudores()
        {
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Exportacion = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DateTime Fecha;
            DataTable Dt_Consulta = new DataTable();
            try
            {
                DateTime.TryParse(Grid_Pendientes.CurrentRow.Cells[0].Value.ToString(), out Fecha);
                Obj_Exportacion.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                Dt_Consulta = Obj_Exportacion.Consultar_Nuevos_Usuarios_Listadeudor();
                Grid_Lista_Deudor.DataSource = Dt_Consulta;
                //Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Ventas);

                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                    Grid_Lista_Deudor.SelectedRows[0].Selected = false;
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Consultar_Lista_Deudores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Grid
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Pendientes_Por_Exportar
        ///DESCRIPCIÓN: Consulta la informacion pendiente por enviar
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Grid_Pendientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Grid_Pendientes.CurrentRow != null && Grid_Pendientes.Rows.Count > 0)
                {
                    Consultar_Ventas_Dia();
                    Consultar_Padron();
                    Consultar_Lista_Deudores();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Grid_Pendientes_SelectionChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Exportar_Click
        ///DESCRIPCIÓN: Exporta la informacion de las ventas
        ///PARÁMETROS:
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 23-Marzo-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Exportar_Click(object sender, EventArgs e)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Adeudos_Ventas_General_Publico = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DataTable Dt_Parametros = new DataTable(); 
            DataTable Dt_Ventas_Dia = new DataTable();
            DataTable Dt_Cambios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Lista = new DataTable();
            DataTable Dt_Pendientes = new DataTable();
            DateTime Fecha;
            String StrConexion = "";
            DataTable Dt_Consultar_Referencias_Online = new DataTable();
            DataTable Dt_Consultar_Referencias_Local = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Direccion = new DataTable();

            try 
            {
               
                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

               
                try
                {
                    if (Dt_Parametros.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                    {
                        #region Version odbc

                        foreach (DataRow Registro in Dt_Parametros.Rows)
                        {
                            StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                            StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                            StrConexion += "OPTION=3";

                        }

                        using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))
                        {
                            using (OdbcCommand Cmd = new OdbcCommand())
                            {
                                MyConnection.ConnectionTimeout = 1200000;
                                MyConnection.Open();
                                MyConnection.Close();
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region Version 5
                        foreach (DataRow Registro in Dt_Parametros.Rows)
                        {
                            StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                            StrConexion += "default command timeout = 1200000; ";

                        }

                        MySqlConnection Obj_Conexion = null;
                        ///////////////////////////////////////

                        //  revisamos la conexion
                        Obj_Conexion = new MySqlConnection(StrConexion);
                        Obj_Conexion.Open();
                        Obj_Conexion.Close();
                        #endregion
                    }

                    //  se consultaran las referencias locales del deudorcad contra "Online"
                    Cls_Ope_Solicitud_Facturacion_Negocio Rs_Consulta_Online = new Cls_Ope_Solicitud_Facturacion_Negocio();

                    Rs_Consulta_Online.P_Curp = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Cuenta_Museo].ToString();
                    Rs_Consulta_Online.P_Tipo = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                    Rs_Consulta_Online.P_Lista = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                    Rs_Consulta_Online.P_Dt_Parametros = Dt_Parametros;

                    // consulta online
                    Dt_Consultar_Referencias_Online = Rs_Consulta_Online.Consultar_Contribuyente();

                    // consulta local
                    Dt_Consultar_Referencias_Local = Rs_Consulta_Online.Consultar_Contribuyente_Local();

                    //  se actualizan las referencias
                    if (Dt_Consultar_Referencias_Online.Rows.Count > 0 && Dt_Consultar_Referencias_Online != null)
                    {
                        Rs_Consulta_Online.P_Referencia1_Actualizacion = Dt_Consultar_Referencias_Online.Rows[0]["referencia1"].ToString();
                        Rs_Consulta_Online.P_Referencia2_Actualizacion = Dt_Consultar_Referencias_Online.Rows[0]["referencia2"].ToString();

                        Rs_Consulta_Online.Actualizar_Referencias_Locales();
                    }


                    //  actualizo los valores registrados de los cortes ******************************************************
                    Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
                    Dt_Pendientes = Obj_Enviar_Ventas_Dia.Consultar_Historico_Incluyendo_Dia_Actual();

                    foreach (DataRow Registro in Dt_Pendientes.Rows)
                    {
                        DateTime.TryParse(Registro[Ope_Historico_Exportacion.Campo_Fecha].ToString(), out Fecha);
                        Obj_Enviar_Ventas_Dia.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");//   fecha a actualizar
                        Obj_Enviar_Ventas_Dia.P_Cuenta_Momias = Rs_Consulta_Online.P_Curp;
                        Dt_Ventas_Dia = Obj_Enviar_Ventas_Dia.Consultar_Tabla_Adeudos();

                        //  datos a actualizar en las referencias
                        Obj_Enviar_Ventas_Dia.P_Referencia1 = Rs_Consulta_Online.P_Referencia1_Actualizacion;
                        Obj_Enviar_Ventas_Dia.P_Referencia2 = Rs_Consulta_Online.P_Referencia2_Actualizacion;

                        foreach (DataRow Registro_Adeudos in Dt_Ventas_Dia.Rows)
                        {
                            Obj_Enviar_Ventas_Dia.P_Anio = Registro_Adeudos["ano"].ToString();
                            Obj_Enviar_Ventas_Dia.P_Tipo = Registro_Adeudos["tipo"].ToString();
                            Obj_Enviar_Ventas_Dia.P_Lista = Registro_Adeudos["lista"].ToString();
                            Obj_Enviar_Ventas_Dia.P_Curp = Registro_Adeudos["Curp"].ToString();
                            Obj_Enviar_Ventas_Dia.Actualizar_Referencias_Adeudos_Locales();
                        }
                    }

                    //  se mandara la informacion almacenada en la base de datos local ****************************************************
                    Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
                    Dt_Pendientes = Obj_Enviar_Ventas_Dia.Consultar_Historico();

                    foreach (DataRow Registro in Dt_Pendientes.Rows)
                    {

                        DateTime.TryParse(Registro[Ope_Historico_Exportacion.Campo_Fecha].ToString(), out Fecha);


                        Obj_Adeudos_Ventas_General_Publico.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                        Dt_Ventas_Dia = Obj_Adeudos_Ventas_General_Publico.Consultar_Tabla_Adeudos();

                        Obj_Enviar_Ventas_Dia.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                        //Dt_Ventas_Dia = Obj_Enviar_Ventas_Dia.Consultar_Tabla_Adeudos();

                        Dt_Cambios_Padron = Obj_Enviar_Ventas_Dia.Consultar_Cambios_Padron();
                        Dt_Nuevos_Usuarios_Padron = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Padron();
                        Dt_Nuevos_Usuarios_Lista = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Listadeudor();
                        Dt_Nuevos_Usuarios_Direccion = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Direcciones_Padron();

                        //  se pasan los valores al turno 
                        Obj_Enviar_Ventas_Dia.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                        Obj_Enviar_Ventas_Dia.P_Estatus = true;
                        Obj_Enviar_Ventas_Dia.P_Dt_Ventas_Dia = Dt_Ventas_Dia;
                        Obj_Enviar_Ventas_Dia.P_Dt_Parametros = Dt_Parametros;
                        Obj_Enviar_Ventas_Dia.P_Dt_Padron_Nuevos = Dt_Nuevos_Usuarios_Padron;
                        Obj_Enviar_Ventas_Dia.P_Dt_Padron_Actualizacion = Dt_Cambios_Padron;
                        Obj_Enviar_Ventas_Dia.P_Dt_Listdeudor_Nuevos = Dt_Nuevos_Usuarios_Lista;
                        Obj_Enviar_Ventas_Dia.P_Dt_Padron_Nuevos_Direcciones = Dt_Nuevos_Usuarios_Direccion;
                        Obj_Enviar_Ventas_Dia.Enviar_Ventas_Dia();

                        //  se actualiza el historico
                        Obj_Enviar_Ventas_Dia.P_No_Turno = "Proceo Exportacion " + MDI_Frm_Apl_Principal.Nombre_Usuario + DateTime.Now.ToString();
                        Obj_Enviar_Ventas_Dia.Actualizar_Historico();
                    }

                    //  se limpian los grid
                    Grid_Pendientes.DataSource = new DataTable();
                    Grid_Padron.DataSource = new DataTable();
                    Grid_Lista_Deudor.DataSource = new DataTable();
                    Grid_Ventas.DataSource = new DataTable();

                    Consultar_Pendientes_Por_Exportar();
                    MessageBox.Show(this, "Exportacion exitosa.", "Exportar información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception es)
                {
                    MessageBox.Show(this, "(*****" + es.ToString() + "*****)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

              
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Btn_Exportar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
