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
using Operaciones.Turnos.Negocio;
using Catalogos.Turnos.Negocio;
using Operaciones.Cajas.Negocio;
using ResizeableForm;
using Erp_Solicitud_Facturacion.Negocio;
using Erp_Apl_Parametros.Negocio;
using System.Net;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Ope_Turnos : ResizableForm
    {
        private enum Tipo_Operacion
        {
            Inicial,
            Nuevo,
            Modificar
        }

        private bool Cargando_Grid = false;

        Validador_Generico Validador;
        #region "METODOS_GENERALES"
        public Frm_Ope_Turnos()
        {
            InitializeComponent();
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Frm_Ope_Turnos_Load
        ///DESCRIPCIÓN: Método para la carga inicial del formulario
        ///PARÁMETROS:
        /// 		N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Frm_Ope_Turnos_Load(object sender, EventArgs e)
        {
            Cls_Metodos_Generales.Validar_Acceso_Sistema("Turnos", this);
            Cls_Cat_Turnos_Negocio Cat_Turnos_Negocio = new Cls_Cat_Turnos_Negocio();
            DataTable Dt_Resultado;
            Fra_Buscar.Visible = false;
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Turnos.Visible = true;
            Fra_Turnos.Enabled = true;
            // consultar catálogo de turnos
            Cat_Turnos_Negocio.P_Estatus = "ACTIVO";
            Dt_Resultado = Cat_Turnos_Negocio.Consultar_Turnos();
            Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Turno, Dt_Resultado, Cat_Turnos.Campo_Nombre, Cat_Turnos.Campo_Turno_ID);
            Cargar_Turnos_Activos();
            Cls_Metodos_Generales.Grid_Propiedad_Fuente_Celdas(Grid_Turnos);
            Cmb_Estatus.Enabled = false;
            Validador = new Validador_Generico(Erp_Validaciones);
            Erp_Validaciones.Clear();
            //Grid_Turnos.ClearSelection();
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Manejo_Botones_Operacion
        ///DESCRIPCIÓN: Breve descripción de lo que hace la función.
        ///PARÁMETROS:
        /// 		1. Tipo: enumeración con el tipo de operación a realizar: Nuevo, Modificar e Inicial
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Manejo_Botones_Operacion(Tipo_Operacion Tipo)
        {
            switch (Tipo)
            {
                case Tipo_Operacion.Nuevo:
                    {
                        Btn_Nuevo.Text = "Dar de Alta";
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Erp_Validaciones.Clear();
                        break;
                    }
                case Tipo_Operacion.Modificar:
                    {
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        Btn_Buscar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        Erp_Validaciones.Clear();
                        break;
                    }
                case Tipo_Operacion.Inicial:
                    {
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Modificar.Text = "Modificar";
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        Btn_Buscar.Enabled = true;
                        Btn_Salir.Enabled = true;
                        Erp_Validaciones.Clear();
                        break;
                    }
                default: break;
            }

        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Cargar_Turnos_Activos
        ///DESCRIPCIÓN: Consulta los turnos en la base de datos y los carga en el grid
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Cargar_Turnos_Activos()
        {
            Cls_Ope_Turnos_Negocio Consulta_Turnos = new Cls_Ope_Turnos_Negocio();
            Cls_Apl_Roles_Negocio Rs_Rol = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Turnos;
            int Indice = 0;

            // establecer la bandera Cargando_Grid para evitar excepción en Grid_Turnos_SelectionChanged
            Cargando_Grid = true;

            try
            {
                Grid_Turnos.Rows.Clear();

                Consulta_Turnos.P_Estatus = "ABIERTO";
                Dt_Turnos = Consulta_Turnos.Consultar_Turnos();
                // validar que la consulta haya regresado resultados
                if (Dt_Turnos != null && Dt_Turnos.Rows.Count > 0)
                {
                    // si el grid no tiene columnas, agregarlas
                    if (Grid_Turnos.Columns.Count <= 0)
                    {
                        Grid_Turnos.Columns.Add("No_Turno", "No. Turno");
                        Grid_Turnos.Columns.Add("Turno_ID", "Turno_ID");
                        Grid_Turnos.Columns.Add("NOMBRE_TURNO", "Turno");
                        Grid_Turnos.Columns.Add("Fecha_Inicio", "Fecha");
                        Grid_Turnos.Columns.Add("Hora_Inicio", "Hora");
                        Grid_Turnos.Columns.Add("Fecha_Hora_Cierre", "Cierre");
                        Grid_Turnos.Columns.Add("Estatus", "Estatus");
                        Grid_Turnos.Columns.Add("Fecha_Hora_Inicio", "Fecha_Hora");
                    }

                    // cargar filas en el grid
                    foreach (DataRow Renglon in Dt_Turnos.Rows)
                    {
                        Grid_Turnos.Rows.Add();
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_No_Turno].Value = Renglon[Ope_Turnos.Campo_No_Turno];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Turno_ID].Value = Renglon[Ope_Turnos.Campo_Turno_ID];
                        Grid_Turnos.Rows[Indice].Cells["NOMBRE_TURNO"].Value = Renglon["NOMBRE_TURNO"];
                        Grid_Turnos.Rows[Indice].Cells["Fecha_Inicio"].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Inicio];
                        Grid_Turnos.Rows[Indice].Cells["Hora_Inicio"].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Inicio];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Fecha_Hora_Cierre].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Cierre];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Estatus].Value = Renglon[Ope_Turnos.Campo_Estatus];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Fecha_Hora_Inicio].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Inicio];
                        Indice++;
                    }

                    // configuración de las columnas del  Grid
                    Grid_Turnos.Columns[0].Visible = false;
                    Grid_Turnos.Columns[0].ReadOnly = true;
                    Grid_Turnos.Columns[1].Visible = false;
                    Grid_Turnos.Columns[1].ReadOnly = true;
                    Grid_Turnos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns["Fecha_Inicio"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                    Grid_Turnos.Columns["Hora_Inicio"].DefaultCellStyle.Format = "hh:mm tt";
                    Grid_Turnos.Columns["Fecha_Hora_Cierre"].DefaultCellStyle.Format = "dd/MMM/yyyy hh:mm tt";
                    Grid_Turnos.Columns[7].Visible = false;
                }
                Grid_Turnos.ClearSelection();

                // bandera para indicar que ya se terminó de cargar el grid
                Cargando_Grid = false;
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Validar_Alta
        ///DESCRIPCIÓN: valida que todos los campos obligatorios hayan sido llenados por el usuario
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private Boolean Validar_Alta()
        {
            Cls_Ope_Turnos_Negocio Consulta_Turnos_Negocio = new Cls_Ope_Turnos_Negocio();
            DataTable Dt_Turnos = null;
            Boolean Datos_Validados = true;
            String Faltan = "Es necesario:\n";

            try
            {
                // si se está dando de alta un turno
                if (Btn_Nuevo.Text == "Dar de Alta")
                {
                    // validar que no haya turnos abiertos
                    Consulta_Turnos_Negocio.P_Estatus = "ABIERTO";
                    Dt_Turnos = Consulta_Turnos_Negocio.Consultar_Turnos();
                    // si la consulta regresó resultados, hay turnos abiertos
                    if (Dt_Turnos != null && Dt_Turnos.Rows.Count > 0)
                    {
                        Datos_Validados = false;
                        Faltan = Faltan + " Cerrar el turno abierto antes de dar de alta otro \n";
                    }
                }

                // validar que se haya seleccionado un elemento en el combo de catálogo de turnos
                if (Cmb_Turno.SelectedIndex <= 0)
                {
                    Datos_Validados = false;
                    Faltan = Faltan + " Seleccionar un turno \n";
                }

                if (Datos_Validados == false)
                {
                    MessageBox.Show(this, Faltan, "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Datos_Validados;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Alta_Turno
        ///DESCRIPCIÓN: Llama al método en la capa de negocio para dar de alta un nuevo turno con la información en el formulario
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private Boolean Alta_Turno()
        {
            Cls_Ope_Turnos_Negocio Alta_Turno_Negocio = new Cls_Ope_Turnos_Negocio();
            Boolean Alta = true;
            try
            {
                Alta_Turno_Negocio.P_Estatus = "ABIERTO";
                if (Cmb_Turno.SelectedIndex > 0)
                {
                    Alta_Turno_Negocio.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();
                }
                else
                {
                    Alta_Turno_Negocio.P_Turno_ID = "";
                }
                Alta_Turno_Negocio.P_Fecha_Hora_Inicio = DateTime.Now;
                Alta_Turno_Negocio.Alta_Turno();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Alta;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Alta_Turno
        ///DESCRIPCIÓN: Llama al método en la capa de negocio para dar de alta un nuevo turno con la información en el formulario
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Ventas_Internet_Deudorcad()
        {
            Cls_Ope_Solicitud_Facturacion_Negocio Obj_Ventas_Internet = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DataTable Dt_Consultas = new DataTable();
            String Concepto = "";
            Double Importe = 0;
            String No_Venta = "";
            try
            {
                //  se consultan las ventas del dia anterior.
                DateTime Fecha_Anterior = Convert.ToDateTime(Dtp_Fecha_Turno.Value);
                Fecha_Anterior = Fecha_Anterior.AddDays(-1);
                Obj_Ventas_Internet.P_Time_Fecha_Inicio = Fecha_Anterior;
                Dt_Consultas = Obj_Ventas_Internet.Consultar_Venta_Internet();


                if (Dt_Consultas != null && Dt_Consultas.Rows.Count > 0)
                {
                    foreach (DataRow Registro in Dt_Consultas.Rows)
                    {
                        Importe = Importe + Convert.ToDouble(Registro["Ventas"].ToString());
                        Concepto += Registro["Cantidad"].ToString() + "-" + Registro["producto_id"].ToString() + ",";
                    }
                }

                if (Importe > 0)
                {
                    Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                    DataTable Dt_Parametros = new DataTable();

                    Consulta_Parametros.P_Parametro_Id = "00001";
                    Dt_Parametros = Consulta_Parametros.Consultar_Parametros();


                    #region Parametro
                    Cls_Ope_Solicitud_Facturacion_Negocio Rs_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();


                    Rs_Ventas_Dia.P_Dt_Parametros = Dt_Parametros;
                    Rs_Ventas_Dia.P_Cuenta_Momias = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Cuenta_Museo].ToString();
                    Rs_Ventas_Dia.P_Curp= Dt_Parametros.Rows[0][Cat_Parametros.Campo_Cuenta_Museo].ToString();
                    Rs_Ventas_Dia.P_Lista = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                    Rs_Ventas_Dia.P_Tipo = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                    Rs_Ventas_Dia.P_Clave_Venta = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Clave_Venta_Internet].ToString();
                    Rs_Ventas_Dia.P_Fecha_Venta = Fecha_Anterior.ToString();
                    Rs_Ventas_Dia.P_Importe = Importe.ToString();
                    Rs_Ventas_Dia.P_Concepto2 = Concepto;
                    #endregion


                    #region Referencia
                    //  se consulta la referencia 1 y referencia 2 basandonos en la cuenta momias
                    Cls_Ope_Solicitud_Facturacion_Negocio Rs_Consulta = new Cls_Ope_Solicitud_Facturacion_Negocio();
                    DataTable Dt_Consulta_Contribuyente = new DataTable();

                    Rs_Consulta.P_Curp = Rs_Ventas_Dia.P_Cuenta_Momias;
                    Rs_Consulta.P_Tipo = Rs_Ventas_Dia.P_Tipo;
                    Rs_Consulta.P_Lista = Rs_Ventas_Dia.P_Lista;

                    Dt_Consulta_Contribuyente = Rs_Consulta.Consultar_Contribuyente();

                    //  se valida que contenga informacion del contribuyente
                    if (Dt_Consulta_Contribuyente.Rows.Count == 0)
                    {
                        Rs_Consulta.P_Rfc = Rs_Ventas_Dia.P_Cuenta_Momias;
                        Dt_Consulta_Contribuyente = Rs_Consulta.Consultar_Contribuyente();
                    }

                    //  se valida que contenga informacion del contribuyente
                    if (Dt_Consulta_Contribuyente.Rows.Count == 0)
                    {
                        MessageBox.Show(this, "No existe cuenta en list deudor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                        
                    }

                    foreach (DataRow Registro in Dt_Consulta_Contribuyente.Rows)
                    {
                        Rs_Ventas_Dia.P_Referencia1 =  Registro["referencia1"].ToString();
                        Rs_Ventas_Dia.P_Referencia2 = Registro["referencia2"].ToString();
                    }


                    Rs_Ventas_Dia.Insertar_Ventas_Dia_Internet();
                    #endregion

                    String Ip = "";
                    String Tipo_Internet = "";
                    Ip = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString();
                    String StrConexion = "";



                    foreach (DataRow Registro in Dt_Parametros.Rows)
                    {
                        StrConexion = "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                        StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                    }


                    MySqlConnection Obj_Conexion = null;
                    //  revisamos la conexion
                    try
                    {
                        Obj_Conexion = new MySqlConnection(StrConexion);
                        Obj_Conexion.Open();
                        Obj_Conexion.Close();


                        Rs_Ventas_Dia.P_Referencia3 = "Internet " + DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                        Rs_Ventas_Dia.P_Dt_Ventas_Dia = Rs_Ventas_Dia.Consultar_Venta_Internet_Registradas_Deudorcad();
                        Rs_Ventas_Dia.Enviar_Ventas_Dia_Internet();
                        //Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas = true;
                    }
                    catch (Exception es)
                    {
                        //Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas = false;
                        MessageBox.Show(this, "No se logro establecer conexion con el deudorcad (Ventas Internet), se tendra que realizar manualmente la exportación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }



                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Modificar_Turno
        ///DESCRIPCIÓN: Breve descripción de lo que hace la función.
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        public Boolean Modificar_Turno()
        {
            Cls_Ope_Turnos_Negocio Modifica_Turno_Negocio = new Cls_Ope_Turnos_Negocio();
            DataTable Dt_Ventas_Dia = new DataTable();
            DataTable Dt_Cambios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Direccion = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Lista = new DataTable();
            DataTable Dt_Nuevos_Lista_Deudores = new DataTable();

            DataTable Dt_Consultar_Referencias_Online = new DataTable();
            DataTable Dt_Consultar_Referencias_Local = new DataTable();
            DataTable Dt_Pendientes = new DataTable();
            DateTime Fecha;


            Boolean Bol_Estatus_Referencias = false;

            try
            {
                #region DeudorCad
                //if (Chk_Enviar_Ventas_Dia.Checked == true)
                //{
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable Dt_Parametros = new DataTable();

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();
                
                Cls_Ope_Solicitud_Facturacion_Negocio Obj_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();

                Obj_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
                DateTime.TryParse(Grid_Turnos.CurrentRow.Cells[7].Value.ToString(), out Fecha);
                Obj_Ventas_Dia.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                Obj_Ventas_Dia.P_Lista = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                Obj_Ventas_Dia.P_Tipo = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                Dt_Ventas_Dia = Obj_Ventas_Dia.Consultar_Tabla_Adeudos();

                Dt_Cambios_Padron = Obj_Ventas_Dia.Consultar_Cambios_Padron();
                Dt_Nuevos_Usuarios_Padron = Obj_Ventas_Dia.Consultar_Nuevos_Usuarios_Padron();
                Dt_Nuevos_Usuarios_Direccion = Obj_Ventas_Dia.Consultar_Nuevos_Usuarios_Direcciones_Padron();
                Dt_Nuevos_Usuarios_Lista = Obj_Ventas_Dia.Consultar_Nuevos_Usuarios_Listadeudor();
                Dt_Nuevos_Lista_Deudores = Obj_Ventas_Dia.Consultar_Nuevos_Listadeudor();
                
                String Ip = "";
                Ip = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString();
                String StrConexion = "";

              
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
                                MyConnection.Open();
                                MyConnection.Close();
                            }
                        }

                        Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas = true;
                        #endregion
                    }
                    else
                    {
                        #region version 5
                        foreach (DataRow Registro in Dt_Parametros.Rows)
                        {
                            StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                        }

                        MySqlConnection Obj_Conexion = null;
                        //  revisamos la conexion
                        Obj_Conexion = new MySqlConnection(StrConexion);
                        Obj_Conexion.Open();
                        Obj_Conexion.Close();

                        Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas = true;
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
                    Cls_Ope_Solicitud_Facturacion_Negocio Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
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

                    //  se vuelven a consultar todos los adeudos
                    Cls_Ope_Solicitud_Facturacion_Negocio Obj_Adeudos_Ventas_General_Publico = new Cls_Ope_Solicitud_Facturacion_Negocio();
                    Obj_Adeudos_Ventas_General_Publico.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                    Dt_Ventas_Dia = Obj_Adeudos_Ventas_General_Publico.Consultar_Tabla_Adeudos();



                }
                catch (Exception es)
                {
                    Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas = false;
                    MessageBox.Show(this, "No se logro establecer conexion con el deudorcad, se tendra que realizar manualmente la exportación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                
                ////  validacion para la informacion de parametros con respecto a la base de datos del deudorcad
                //foreach (DataRow Registro in Dt_Parametros.Rows)
                //{
                //    //  valida que existan los parametros para la insercion de las ventas, padron y listadeudor de ingresos
                //    if (!String.IsNullOrEmpty(Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString())
                //            && !String.IsNullOrEmpty(Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString())
                //            && !String.IsNullOrEmpty(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString())
                //            && !String.IsNullOrEmpty(Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString()))
                //    {
                //        Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas = true;
                //    }
                //    else
                //        Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas = false;
                //}

                //  se pasan los valores al turno 
                Modifica_Turno_Negocio.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                Modifica_Turno_Negocio.P_Dt_Ventas_Dia = Dt_Ventas_Dia;
                Modifica_Turno_Negocio.P_Dt_Parametros = Dt_Parametros;
                Modifica_Turno_Negocio.P_Dt_Padron_Nuevos = Dt_Nuevos_Usuarios_Padron;
                Modifica_Turno_Negocio.P_Dt_Padron_Actualizacion = Dt_Cambios_Padron;
                Modifica_Turno_Negocio.P_Dt_Padron_Nuevos_Direcciones = Dt_Nuevos_Usuarios_Direccion;
                Modifica_Turno_Negocio.P_Dt_Listdeudor_Nuevos = Dt_Nuevos_Usuarios_Lista;
                Modifica_Turno_Negocio.P_Dt_Listdeudor_ = Dt_Nuevos_Lista_Deudores;
                #endregion

                #region Camaras
                Modifica_Turno_Negocio.P_Dtime_Fecha = Convert.ToDateTime(Dtp_Busqueda_Desde_Fecha.Value);

                #endregion

                #region Cierre de turno
                Modifica_Turno_Negocio.P_No_Turno = Txt_No_Turno.Text;
                Modifica_Turno_Negocio.P_Estatus = Cmb_Estatus.Text;
                Modifica_Turno_Negocio.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();
                Modifica_Turno_Negocio.P_Fecha_Hora_Cierre = DateTime.Now;
                Modifica_Turno_Negocio.Actualizar_Turno();
                #endregion

                #region pendientes por exportar

                if (Modifica_Turno_Negocio.P_Estatus_Ventas_Enviadas == true)
                {
                    Btn_Exportar_Click(null, null);
                }

                #endregion

                return true;

            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

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
            DataTable Dt_Parametros = new DataTable();
            DataTable Dt_Ventas_Dia = new DataTable();
            DataTable Dt_Cambios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Padron = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Lista = new DataTable();
            DataTable Dt_Pendientes = new DataTable();
            DataTable Dt_Nuevos_Usuarios_Direccion = new DataTable();
            DateTime Fecha;
            try
            {

                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                Obj_Enviar_Ventas_Dia = new Cls_Ope_Solicitud_Facturacion_Negocio();
                Dt_Pendientes = Obj_Enviar_Ventas_Dia.Consultar_Historico();

                foreach (DataRow Registro in Dt_Pendientes.Rows)
                {
                    DateTime.TryParse(Registro[Ope_Historico_Exportacion.Campo_Fecha].ToString(), out Fecha);
                    Obj_Enviar_Ventas_Dia.P_Fecha_Venta = Fecha.ToString("yyyy-MM-dd");
                    Dt_Ventas_Dia = Obj_Enviar_Ventas_Dia.Consultar_Tabla_Adeudos();

                    Dt_Cambios_Padron = Obj_Enviar_Ventas_Dia.Consultar_Cambios_Padron();
                    Dt_Nuevos_Usuarios_Padron = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Padron();
                    Dt_Nuevos_Usuarios_Direccion = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Direcciones_Padron();
                    Dt_Nuevos_Usuarios_Lista = Obj_Enviar_Ventas_Dia.Consultar_Nuevos_Usuarios_Listadeudor();

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
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Btn_Exportar_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "EVENTOS"
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Buscar_Click
        ///DESCRIPCIÓN: Muestra el frame con los controles para realizar una búsqueda
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            Fra_Buscar.Visible = true;
            Fra_Buscar.Enabled = true;
            Fra_Datos_Generales.Visible = false;
            Fra_Datos_Generales.Enabled = false;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Regresar_Click
        ///DESCRIPCIÓN: Cambia la visibilidad de los frames para ocultar la búsqueda y mostrar los datos generales
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Fra_Datos_Generales.Visible = true;
            Fra_Datos_Generales.Enabled = false;
            Fra_Buscar.Visible = false;
            Fra_Buscar.Enabled = false;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Nuevo_Click
        ///DESCRIPCIÓN: Configura los controles para agregar un nuevo turno o llama al método alta_turno y 
        ///             limpia los controles dependiendo del valor de la propiedad texto del botón nuevo.
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            Cls_Ope_Turnos_Negocio Consulta_Turnos_Negocio = new Cls_Ope_Turnos_Negocio();
            DataTable Dt_Turnos = null;
            DataTable Dt_Existe_Turno = null;

         

            // validar que no haya turnos abiertos
            Consulta_Turnos_Negocio.P_Estatus = "ABIERTO";
            Dt_Turnos = Consulta_Turnos_Negocio.Consultar_Turnos();
            // si la consulta regresó resultados, hay turnos abiertos
            if (Dt_Turnos != null && Dt_Turnos.Rows.Count > 0)
            {
                MessageBox.Show(this, "Ya hay un turno abierto", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //  consulta que no se haya abierto mas de un turno en el dia
            Consulta_Turnos_Negocio.P_Fecha_Venta = String.Format("{0:yyyy-MM-dd}", Dtp_Fecha_Turno.Value);
            Dt_Existe_Turno = Consulta_Turnos_Negocio.Consultar_Existencia_Turnos();
            if (Dt_Existe_Turno != null && Dt_Existe_Turno.Rows.Count > 0)
            {
                MessageBox.Show(this, "Ya se registro un turno en este dia.", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Btn_Nuevo.Text.Trim() == "Nuevo")
            {
                Manejo_Botones_Operacion(Tipo_Operacion.Nuevo);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Buscar);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Turnos);
                Fra_Buscar.Enabled = true;
                Fra_Datos_Generales.Visible = true;
                Fra_Datos_Generales.Enabled = true;
                Fra_Turnos.Enabled = true;
                Fra_Turnos.Enabled = false;
                Fra_Buscar.Visible = false;
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, true);
                Cmb_Estatus.SelectedIndex = 0;
                Cmb_Estatus.Enabled = false;
                Txt_No_Turno.Enabled = false;
                Dtp_Fecha_Turno.Enabled = false;
               
            }
            else
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    if (Validar_Alta())
                    { 
                        //  se genera la informacion de las ventas por internet Deudorcad
                        Ventas_Internet_Deudorcad();
                       
                        if (Alta_Turno())
                        {
                            Manejo_Botones_Operacion(Tipo_Operacion.Inicial);
                            Cls_Metodos_Generales.Limpia_Controles(Fra_Buscar);
                            Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                            Cls_Metodos_Generales.Limpia_Controles(Fra_Turnos);
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                            Grid_Turnos.Enabled = true;
                            Fra_Turnos.Enabled = true;
                            Cargar_Turnos_Activos();
                        }
                    }
                }
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Modificar_Click
        ///DESCRIPCIÓN: Configura los controles para modificar un turno o llama al método modificar_turno y 
        ///             limpia los controles dependiendo del valor de la propiedad texto del botón nuevo.
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            DataTable Dt_Cajas_Abiertas;
            DataTable Dt_Solicitudes_Pendientes;
            String Solicitudes = "";
            // validar que no haya cajas abiertas
            Cls_Ope_Cajas_Negocio Consultar_Cajas = new Cls_Ope_Cajas_Negocio();

            try
            {
                Consultar_Cajas.P_Estatus = "ABIERTA";
                Dt_Cajas_Abiertas = Consultar_Cajas.Consultar_Cajas();
                if (Dt_Cajas_Abiertas != null && Dt_Cajas_Abiertas.Rows.Count > 0)
                {
                    MessageBox.Show(this, "No es posible cerrar el turno porque aún hay cajas abiertas ("
                        + Dt_Cajas_Abiertas.Rows.Count + ").", "Modificar turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                //  validacion para las solicitudes pendientes por ingresar
                Consultar_Cajas.P_Fecha_Creo = String.Format("{0:yyyy-MM-dd}", Dtp_Busqueda_Desde_Fecha.Value);
                Dt_Solicitudes_Pendientes = Consultar_Cajas.Consultar_Solicitudes_Pendientes();

                if (Dt_Solicitudes_Pendientes != null && Dt_Solicitudes_Pendientes.Rows.Count > 0)
                {
                    Solicitudes = "Faltan por registrar las siguientes solicitudes de facturación con número de venta:\n";
                    foreach (DataRow Registro in Dt_Solicitudes_Pendientes.Rows)
                    {
                        Solicitudes += "" + Registro[Ope_Ventas_Detalles.Campo_No_Venta].ToString() + "\n";
                    }

                    MessageBox.Show(this, Solicitudes, "Modificar turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (Btn_Modificar.Text == "Modificar")
                {
                    if (Txt_No_Turno.Text != "")
                    {
                        Manejo_Botones_Operacion(Tipo_Operacion.Modificar);
                        Grid_Turnos.Enabled = false;
                        Cmb_Estatus.Enabled = true;
                        Fra_Buscar.Enabled = true;
                        Fra_Datos_Generales.Enabled = true;
                        Fra_Datos_Generales.Visible = true;
                        Fra_Buscar.Visible = false;
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, false);
                        Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                        Cmb_Estatus.SelectedIndex = 0;
                        Txt_No_Turno.Enabled = false;
                        Cmb_Estatus.SelectedIndex = 1;
                        Cmb_Estatus.Enabled = false;
                        Txt_Fecha_Hora_Cierre.Text = DateTime.Now.ToString("dd/MMM/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        MessageBox.Show(this, "Seleccione el turno que desea modificar.", "Modificar turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (Validar_Alta())
                    {
                        if (Modificar_Turno())
                        {
                            Manejo_Botones_Operacion(Tipo_Operacion.Inicial);
                            Cls_Metodos_Generales.Limpia_Controles(this);
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                            Cargar_Turnos_Activos();
                            Fra_Turnos.Enabled = true;
                            Grid_Turnos.Enabled = true;
                            Fra_Buscar.Enabled = true;
                            MessageBox.Show(this, "El turno se cerro correctamente.", "Modificar turno", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Btn_Modificar_Click: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Salir_Click
        //DESCRIPCIÓN:Evento de salir de la forma
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (Btn_Salir.Text == "Salir")
            {
                this.Dispose();
                this.Close();
            }
            else
            {
                Manejo_Botones_Operacion(Tipo_Operacion.Inicial);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Buscar);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Datos_Generales);
                Cls_Metodos_Generales.Limpia_Controles(Fra_Turnos);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Buscar, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Datos_Generales, false);
                Grid_Turnos.Enabled = true;
                Fra_Turnos.Enabled = true;
                Cargar_Turnos_Activos();
            }
        }

        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Btn_Busqueda_Click
        //DESCRIPCIÓN:Al seleccionar un regristro se llenaran los campos con la informacion adecuada
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Btn_Busqueda_Click(object sender, EventArgs e)
        {
            Cls_Ope_Turnos_Negocio Consulta_Turnos = new Cls_Ope_Turnos_Negocio();
            Cls_Apl_Roles_Negocio Rs_Rol = new Cls_Apl_Roles_Negocio();
            DataTable Dt_Turnos;
            int Indice = 0;
            DateTime Desde_Fecha;
            DateTime Hasta_Fecha;

            // establecer la bandera Cargando_Grid para evitar excepción en Grid_Turnos_SelectionChanged
            Cargando_Grid = true;

            try
            {
                // asignar filtros opcionales a la instancia de la clase de negocio
                if (Cmb_Busqueda_Estatus.SelectedIndex > 0)
                {
                    Consulta_Turnos.P_Estatus = Cmb_Busqueda_Estatus.SelectedItem.ToString();
                }
                if (DateTime.TryParse(Dtp_Busqueda_Desde_Fecha.Text, out Desde_Fecha))
                {
                    Consulta_Turnos.P_Desde_Fecha = Desde_Fecha;
                }
                if (DateTime.TryParse(Dtp_Busqueda_Hasta_Fecha.Text, out Hasta_Fecha))
                {
                    Consulta_Turnos.P_Hasta_Fecha = Hasta_Fecha;
                }
                Grid_Turnos.Rows.Clear();

                Dt_Turnos = Consulta_Turnos.Consultar_Turnos();
                // validar que la consulta haya regresado resultados
                if (Dt_Turnos != null && Dt_Turnos.Rows.Count > 0)
                {
                    // si el grid no tiene columnas, agregarlas
                    if (Grid_Turnos.Columns.Count <= 0)
                    {
                        Grid_Turnos.Columns.Add("No_Turno", "No. Turno");
                        Grid_Turnos.Columns.Add("Turno_ID", "Turno_ID");
                        Grid_Turnos.Columns.Add("NOMBRE_TURNO", "Turno");
                        Grid_Turnos.Columns.Add("Fecha_Inicio", "Fecha");
                        Grid_Turnos.Columns.Add("Hora_Inicio", "Hora");
                        Grid_Turnos.Columns.Add("Fecha_Hora_Cierre", "Cierre");
                        Grid_Turnos.Columns.Add("Estatus", "Estatus");
                        Grid_Turnos.Columns.Add("Fecha_Hora_Inicio", "Fecha_Hora");
                    }

                    // cargar filas en el grid
                    foreach (DataRow Renglon in Dt_Turnos.Rows)
                    {
                        Grid_Turnos.Rows.Add();
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_No_Turno].Value = Renglon[Ope_Turnos.Campo_No_Turno];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Turno_ID].Value = Renglon[Ope_Turnos.Campo_Turno_ID];
                        Grid_Turnos.Rows[Indice].Cells["NOMBRE_TURNO"].Value = Renglon["NOMBRE_TURNO"];
                        Grid_Turnos.Rows[Indice].Cells["Fecha_Inicio"].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Inicio];
                        Grid_Turnos.Rows[Indice].Cells["Hora_Inicio"].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Inicio];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Fecha_Hora_Cierre].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Cierre];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Estatus].Value = Renglon[Ope_Turnos.Campo_Estatus];
                        Grid_Turnos.Rows[Indice].Cells[Ope_Turnos.Campo_Fecha_Hora_Inicio].Value = Renglon[Ope_Turnos.Campo_Fecha_Hora_Inicio];
                        Indice++;
                    }

                    // configuración de las columnas del  Grid
                    Grid_Turnos.Columns[0].Visible = false;
                    Grid_Turnos.Columns[0].ReadOnly = true;
                    Grid_Turnos.Columns[1].Visible = false;
                    Grid_Turnos.Columns[1].ReadOnly = true;
                    Grid_Turnos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Grid_Turnos.Columns["Fecha_Inicio"].DefaultCellStyle.Format = "dd/MMM/yyyy";
                    Grid_Turnos.Columns["Hora_Inicio"].DefaultCellStyle.Format = "hh:mm tt";
                    Grid_Turnos.Columns["Fecha_Hora_Cierre"].DefaultCellStyle.Format = "dd/MMM/yyyy hh:mm tt";
                    Grid_Turnos.Columns[7].Visible = false;
                }
                Grid_Turnos.ClearSelection();

                // bandera para indicar que ya se terminó de cargar el grid
                Cargando_Grid = false;
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Cmb_Turno_SelectedIndexChanged
        ///DESCRIPCIÓN: Manejador del evento cambio de índice seleccionado para el combo Turno: consulta los 
        ///             detalles del turno para obtener el horario y mostrarlo en txt_horario
        ///PARÁMETROS: N/A
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 07-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Cmb_Turno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Cat_Turnos_Negocio Consulta_Turno_Negocio = new Cls_Cat_Turnos_Negocio();
            DataTable Dt_Turnos = null;

            // limpiar contenido de txt_horario
            Txt_Horario.Text = "";

            //  validar que hay un elemento seleccionado en el combo 
            if (Cmb_Turno.SelectedValue != null && Cmb_Turno.SelectedIndex > 0)
            {
                try
                {
                    Consulta_Turno_Negocio.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();
                    Dt_Turnos = Consulta_Turno_Negocio.Consultar_Turnos();
                    // validar resultado de la consulta en la tabla
                    if (Dt_Turnos != null && Dt_Turnos.Rows.Count > 0)
                    {
                        Txt_Horario.Text = Dt_Turnos.Rows[0][Cat_Turnos.Campo_Hora_Inicio].ToString() + " - " + Dt_Turnos.Rows[0][Cat_Turnos.Campo_Hora_Cierre].ToString();
                    }
                }
                catch (Exception E)
                {
                    MessageBox.Show(this, E.ToString(), "Error - Horario turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region "VALIDACIONES"
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Login_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Password_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Confirmar_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Confirmar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Comentarios_TextChanged
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Comentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }
        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Descripcion_Busqueda_KeyPress
        //DESCRIPCIÓN:Permite escribir caracteres reales
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 25-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Descripcion_Busqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico);
            Cls_Metodos_Generales.Convertir_Caracter_Mayuscula(e);
        }

        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Cmb_Rol
        //DESCRIPCIÓN:Valida que el nombre que no sea nulo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Cmb_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Combo_Requerido(e, (ComboBox)sender, true);
        }

        //*************************************************************************************
        //NOMBRE DE LA FUNCIÓN: Txt_Validating
        //DESCRIPCIÓN:Valida que seleccione un registro del combo
        //PARÁMETROS :
        //CREO       : Sergio Manuel Gallardo Andrade
        //FECHA_CREO : 26-Febrero-2013
        //MODIFICO:
        //FECHA_MODIFICO
        //CAUSA_MODIFICACIÓN
        //*************************************************************************************
        private void Txt_Validating(object sender, CancelEventArgs e)
        {
            Validador.Validacion_Campo_Vacio(e, (TextBox)sender);
        }

        #endregion
        #endregion
        #region "GRID"

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Grid_Turnos_SelectionChanged
        ///DESCRIPCIÓN: Manejador del evento cambio de selección para el grid turnos:
        ///             se cargan los datos del turno seleccionado a los controles correspondientes
        ///PARÁMETROS:
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 08-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Grid_Turnos_SelectionChanged(object sender, EventArgs e)
        {
            DateTime Fecha;

            try
            {
                // Cargando_Grid es una bandera a la que se asigna verdadero para indicar que se está cargando el grid
                // validar selección en el grid antes de cargar valores
                if (Cargando_Grid == false && Grid_Turnos.CurrentRow != null && Grid_Turnos.Rows.Count > 0)
                {
                    DateTime.TryParse(Grid_Turnos.CurrentRow.Cells[7].Value.ToString(), out Fecha);
                    Txt_No_Turno.Text = Grid_Turnos.CurrentRow.Cells["No_Turno"].FormattedValue.ToString();
                    Txt_Fecha_Hora_Cierre.Text = Grid_Turnos.CurrentRow.Cells["Fecha_Hora_Cierre"].FormattedValue.ToString();
                    Dtp_Fecha_Turno.Value = Fecha;
                    // validar que el elemento exista antes de asignar
                    //if (Cmb_Turno.FindString(Grid_Turnos.CurrentRow.Cells["NOMBRE_TURNO"].FormattedValue.ToString()) > 0)
                    //{
                    Cmb_Turno.SelectedValue = Grid_Turnos.CurrentRow.Cells["Turno_ID"].FormattedValue.ToString();
                    //}
                    Cmb_Estatus.SelectedIndex = 0;

                    // mostrar frame con datos del turno
                    Fra_Datos_Generales.Visible = true;
                    Fra_Buscar.Visible = false;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Grid turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
