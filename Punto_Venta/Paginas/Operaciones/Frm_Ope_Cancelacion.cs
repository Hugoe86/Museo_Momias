using Erp.Constantes;
using Erp.Metodos_Generales;
using ERP_BASE.App_Code.Controles;
using ERP_BASE.App_Code.Datos.Operaciones;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp_Ope_Accesos.Negocio;
using Microsoft.PointOfService;
using ResizeableForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp_Apl_Parametros.Negocio;
using System.Drawing.Printing;
using ERP_BASE.App_Code.Negocio.Catalogos;
using System.Collections;
using Erp.Seguridad;

namespace ERP_BASE.Paginas.Operaciones
{
    public partial class Frm_Ope_Cancelacion : ResizableForm
    {
        private JButton jBtn_Busqueda;//Variable para agregar el botón que realiza la búsqueda.
        private Font printFont;
        private String Str_Numero_Serie = "";
        private String Str_Numero_Control = "";
        private String Str_Tarjeta_Expiracion = "";
        private String Str_Tipo_De_Tarjeta = "";
        private String Str_Numero_Afiliacion = "";
        private String Str_Auth_Code = "";
        private String Str_Referencia = "";
        private DateTime Dtime_Fecha_Transaccion;
        PosPrinter m_Printer = null; 
        private String Str_Pinpad_Com = "";
        private String Str_Pinpad_Id = "";
        private String Str_Pinpad_Equipo = "";

        #region (Init/Load)
        /// <summary>
        /// Nombre: Frm_Ope_Cancelacion
        /// 
        /// Descripción: Metodo que inicializa los controles.
        /// 
        /// Usuario Creo: Jaun Alberto Hernández Negrete
        /// Fecha Creo: 01 Noviembre 2013 1141 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public Frm_Ope_Cancelacion()
        {
            try
            {
                InitializeComponent();
                Inicializar_Controles();
                Deshabilitar_Datos_Consulta(splitContainer1.Panel2);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Frm_Ope_Cancelacion]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Métodos)
        /// <summary>
        /// Nombre: Frm_Ope_Cancelacion_Load
        /// 
        /// Descripción: Método que se ejecuta cuando se a terminado de cargar el formulario.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 11 Noviembre 2013 18:53 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Ope_Cancelacion_Load(object sender, EventArgs e)
        {
            Cls_Ope_Cancelaciones_Negocio Obj_Cancelaciones = new Cls_Ope_Cancelaciones_Negocio();
            DataTable Dt_Cajas = null;
            Cls_Cat_Terminales_Negocio Rs_Terminal = new Cls_Cat_Terminales_Negocio();
            DataTable Dt_Consulta_Terminal = new DataTable();

            try
            {
                Dt_Cajas = Obj_Cancelaciones.Consultar_Cajas();

                if (!Dt_Cajas.AsEnumerable().Any())
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(this, "No se encuentra ninguna caja abierta por el momento", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Dispose();
                    });
                }

                // cargar Dt_Cajas en Cmb_Cajas
                Cmb_Cajas.DataSource = Dt_Cajas;
                Cmb_Cajas.DisplayMember = "Caja";
                Cmb_Cajas.ValueMember = "No_Caja";

                Limpiar_Datos_Consulta(splitContainer1.Panel1);

                //  se consultan la informacion de la pin pad asignada al equipo de computo
                Rs_Terminal.P_Equipo = Environment.MachineName;
                Rs_Terminal.P_Estatus = "ACTIVO";
                Dt_Consulta_Terminal = Rs_Terminal.Consultar_Terminales();

                if (Dt_Consulta_Terminal != null && Dt_Consulta_Terminal.Rows.Count > 0)
                {

                    foreach (DataRow Registro in Dt_Consulta_Terminal.Rows)
                    {
                        if (!String.IsNullOrEmpty(Registro[Cat_Terminales.Campo_Puerto].ToString()))
                        {
                            Str_Pinpad_Com = Registro[Cat_Terminales.Campo_Puerto].ToString();
                        }
                        if (!String.IsNullOrEmpty(Registro[Cat_Terminales.Campo_Terminal_ID].ToString()))
                        {
                            Str_Pinpad_Id = Registro[Cat_Terminales.Campo_Terminal_ID].ToString();
                        }
                        if (!String.IsNullOrEmpty(Registro[Cat_Terminales.Campo_Nombre].ToString()))
                        {
                            Str_Pinpad_Equipo = Registro[Cat_Terminales.Campo_Nombre].ToString();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Frm_Ope_Cancelacion_Load]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Inicializar_Controles
        /// 
        /// Descripción: Método que inicializa los controles.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 01 Noviembre 2013 11:43 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Inicializar_Controles()
        {
            try
            {
                jBtn_Busqueda = new JButton(global::ERP_BASE.Properties.Resources.search_icon, new Size(50, 40));
                Pnl_Contenedor_Btn_Busqueda.Controls.Add(jBtn_Busqueda);
                jBtn_Busqueda.Click += (sender, e) =>
                {
                    if (Btn_Venta.Tag != null && Btn_Grupo.Tag != null)
                        Llenar_Grid_Ventas();
                    else
                        MessageBox.Show("Indicar si la búsqueda será por venta normal o grupo");
                };

                Txt_No_Venta.LostFocus += new System.EventHandler(this.Txt_No_Venta_LostFocus);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Inicializar_Controles]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Limpiar_Datos_Consulta
        /// 
        /// Descripción: Método que limpia los controles del formulario.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 01 Noviembre 2013 11:43 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Ctrl">Control con el cuál se comenzara a limpiar.</param>
        private void Limpiar_Datos_Consulta(Control Ctrl)
        {
            try
            {
                Array.ForEach(Ctrl.Controls.OfType<Control>().ToArray(), inner_ctrl =>
                {
                    if (inner_ctrl is TextBox)
                        inner_ctrl.Text = string.Empty;
                    else if (inner_ctrl is DataGridView)
                        ((DataGridView)inner_ctrl).DataSource = new DataTable();
                    else if (inner_ctrl is DateTimePicker)
                        ((DateTimePicker)inner_ctrl).Value = DateTime.Now;
                    else if (inner_ctrl is ComboBox)
                    {
                        ComboBox Cmb = inner_ctrl as ComboBox;
                        if (Cmb.Items.Count == 0)
                            Cmb.SelectedIndex = (-1);
                        else if (Cmb.Items.Count == 2)
                            Cmb.SelectedIndex = 1;
                    }

                    if (inner_ctrl.Controls.Count > 0)
                        Limpiar_Datos_Consulta(inner_ctrl);
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Limpiar_Datos_Consulta]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Deshabilitar_Datos_Consulta
        /// 
        /// Descripción: Método que deshabilita los controles del formulario.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 01 Noviembre 2013 11:43 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Ctrl">Control con el cuál se comenzaran a deshabilitar los controles.</param>
        private void Deshabilitar_Datos_Consulta(Control Ctrl)
        {
            try
            {
                Array.ForEach(Ctrl.Controls.OfType<Control>().ToArray(), inner_ctrl =>
                {
                    if (inner_ctrl.Name.Equals("Btn_Regresar_Busqueda") ||
                        inner_ctrl.Name.StartsWith("Pnl") ||
                        inner_ctrl.Name.StartsWith("Btn_Cancelar"))
                        inner_ctrl.Enabled = true;
                    else
                        inner_ctrl.Enabled = false;

                    if (inner_ctrl.Controls.Count > 0)
                        Deshabilitar_Datos_Consulta(inner_ctrl);
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Deshabilitar_Datos_Consulta]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (GridView)
        /// <summary>
        /// Nombre: Llenar_Grid_Ventas
        /// 
        /// Descripción: Método que carga el grid de ventas y cambia el formato del mismo.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 01 Noviembre 2013 11:43 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Llenar_Grid_Ventas()
        {
            Cls_Ope_Cancelaciones_Negocio Obj_Ventas = new Cls_Ope_Cancelaciones_Negocio();
            DataTable Dt_Ventas = null;

            try
            {
                #region (Establecer Filtros Busqueda)
                Obj_Ventas.P_No_Venta = string.IsNullOrEmpty(Txt_No_Venta.Text) ? string.Empty : Txt_No_Venta.Text.Trim();
                Obj_Ventas.P_Caja_Id = Cmb_Cajas.SelectedValue.ToString();
                Obj_Ventas.P_Es_Venta = (Btn_Venta.Tag != null) ? (bool)Btn_Venta.Tag : false;
                Obj_Ventas.P_Es_Grupo = (Btn_Grupo.Tag != null) ? (bool)Btn_Grupo.Tag : false;
                Obj_Ventas.P_Persona_Tramita = string.IsNullOrEmpty(Txt_Persona_Tramita.Text) ? string.Empty : Txt_Persona_Tramita.Text.Trim();
                Obj_Ventas.P_Empresa_Tramita = string.IsNullOrEmpty(Txt_Empresa.Text) ? string.Empty : Txt_Empresa.Text.Trim();
                Obj_Ventas.Fecha_Inicio_Busqueda = Dtp_Fecha_Inicio.Value;
                Obj_Ventas.Fecha_Fin_Busqueda = Dtp_Fecha_Fin.Value;
                Dt_Ventas = Obj_Ventas.Consultar_Ventas_Sencilla();
                #endregion

                #region (Cargar Grid Ventas)
                if (Dt_Ventas is DataTable)
                {
                    if (Dt_Ventas.Rows.Count > 0)
                        Grid_Ventas.DataSource = Dt_Ventas;
                    else Grid_Ventas.DataSource = new DataTable();
                }
                else Grid_Ventas.DataSource = new DataTable();
                #endregion

                #region (Personalizar Estilo del Grid de Ventas)

                #region (Custom Columnas)
                Grid_Ventas.EnableHeadersVisualStyles = false;
                Array.ForEach(Grid_Ventas.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    DataGridViewCellStyle rowStyle = Grid_Ventas.RowHeadersDefaultCellStyle;

                    rowStyle.BackColor = Color.Black;
                    rowStyle.ForeColor = Color.White;
                    rowStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                    columna.HeaderCell.Style = rowStyle;

                    switch (columna.HeaderText)
                    {
                        case "No_Venta":
                            columna.Visible = true;
                            columna.Width = 100;
                            columna.HeaderText = "No Venta";
                            break;
                        case "Descuentos":
                            columna.Visible = false;
                            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            columna.Width = 100;
                            columna.DefaultCellStyle.Format = "c";
                            break;
                        case "Subtotal":
                            columna.Visible = true;
                            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            columna.Width = 100;
                            columna.DefaultCellStyle.Format = "c";
                            break;
                        case "Impuestos":
                            columna.Visible = true;
                            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            columna.Width = 100;
                            columna.DefaultCellStyle.Format = "c";
                            break;
                        case "Total":
                            columna.Visible = true;
                            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            columna.Width = 100;
                            columna.DefaultCellStyle.Format = "c";
                            break;
                        case "Persona_Tramita":
                            columna.Visible = false;
                            columna.Width = 100;
                            break;
                        case "Empresa":
                            columna.Visible = true;
                            columna.Width = 166;
                            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            break;
                        case "Fecha_Tramite":
                            columna.Visible = true;
                            columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            columna.Width = 140;
                            columna.HeaderText = "Fecha Tramite";
                            break;
                        case "Aplican_Dias_Festivos":
                            columna.Visible = false;
                            columna.Width = 100;
                            break;
                        default:
                            columna.Visible = true;
                            break;
                    }
                });
                #endregion

                #region (Custom Filas)
                Array.ForEach(Grid_Ventas.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                {
                    fila.Height = 35;
                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                    {
                        celda.Style.BackColor = SystemColors.Window;
                        celda.Style.ForeColor = Color.Black;
                        celda.Style.Font = new Font("Tahoma", 9, FontStyle.Regular);
                        celda.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    });
                });
                #endregion

                #endregion
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Llenar_Grid_Ventas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Grid_Ventas_CellClick
        /// 
        /// Descripción: Método que se invoca cuando se hace click sobre una celda de la tabla de ventass.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 01 Noviembre 2013 11:43 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Ventas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cls_Ope_Cancelaciones_Negocio Obj_Cancelaciones = new Cls_Ope_Cancelaciones_Negocio();//Variable de negocios para realizar peticiones a la clase de datos.
            string No_Venta = string.Empty;//Variable para almacenar el número de la venta.
            string No_Pago = string.Empty;//Variable para almacenar el número de pago.
            DataTable Dt_Detalles_Venta = null;//Variable para almacenar el detalle de la venta.
            DataTable Dt_Datos_Pago = null;//Variable para almacenar los datos del pago.

            if (e.RowIndex != (-1))
            {
                if (!string.IsNullOrEmpty(Grid_Ventas.Rows[e.RowIndex].Cells[Ope_Ventas.Campo_No_Venta].FormattedValue.ToString()))
                {
                    //Limpir los controles del panel 2 [Datos del Pago]
                    Limpiar_Datos_Consulta(splitContainer1.Panel2);

                    splitContainer1.Panel1Collapsed = true;//Ocultamos el panel 1
                    splitContainer1.Panel2Collapsed = false;//Mostramos el Panel 2

                    //Obtenemos el número de venta de la fila seleccionada de la tabla de ventas.
                    No_Venta = Grid_Ventas.Rows[e.RowIndex].Cells[Ope_Ventas.Campo_No_Venta].FormattedValue.ToString();

                    //Establecemos los filtros de búsqueda para obtener los datos del pago.
                    Obj_Cancelaciones.P_No_Venta = No_Venta;
                    Obj_Cancelaciones.P_No_Pago = No_Pago;
                    //Consultamos los datos del pago.
                    Dt_Detalles_Venta = Obj_Cancelaciones.Consultar_Detalle_Ventas();

                    if (Dt_Detalles_Venta is DataTable)
                    {
                        if (Dt_Detalles_Venta.AsEnumerable().Any())
                        {

                            //Consultamos los datos de la venta.
                            Dt_Datos_Pago = Obj_Cancelaciones.Consultar_Ventas();

                            //Establecemos el valor a los controles del panel , que muestran los datos del pago.
                            Array.ForEach(Dt_Datos_Pago.Rows.OfType<DataRow>().ToArray(), fila =>
                            {
                                Txt_No_Venta_Inf.Text = fila.IsNull(Ope_Ventas.Campo_No_Venta) ? string.Empty : fila.Field<string>(Ope_Ventas.Campo_No_Venta);
                                Txt_Descuentos_Inf.Text = fila.IsNull(Ope_Ventas.Campo_Descuentos) ? string.Empty : string.Format("{0:n}", fila.Field<decimal>(Ope_Ventas.Campo_Descuentos));
                                Txt_Subtotal_Inf.Text = fila.IsNull(Ope_Ventas.Campo_Subtotal) ? string.Empty : string.Format("{0:n}", fila.Field<decimal>(Ope_Ventas.Campo_Subtotal));
                                Txt_Impuestos_Inf.Text = fila.IsNull(Ope_Ventas.Campo_Impuestos) ? string.Empty : string.Format("{0:n}", fila.Field<decimal>(Ope_Ventas.Campo_Impuestos));
                                Txt_Total_Inf.Text = fila.IsNull(Ope_Ventas.Campo_Total) ? string.Empty : string.Format("{0:n}", fila.Field<decimal>(Ope_Ventas.Campo_Total));

                                // se utiliza MySql.Data.Types.MySqlDateTime por el manejador de base de datos, en caso de cambiar a SQL debe ser DateTime
                                Txt_Fecha_Tramite.Text = fila.IsNull(Ope_Ventas.Campo_Fecha_Tramite) ? string.Empty : string.Format("{0:dd MMM yyyy}", fila.Field<MySql.Data.Types.MySqlDateTime>(Ope_Ventas.Campo_Fecha_Tramite));
                                Txt_Persona_Tramita_Inf.Text = fila.IsNull(Ope_Ventas.Campo_Persona_Tramita) ? string.Empty : fila.Field<string>(Ope_Ventas.Campo_Persona_Tramita);
                                Txt_Empresa_Inf.Text = fila.IsNull(Ope_Ventas.Campo_Empresa) ? string.Empty : fila.Field<string>(Ope_Ventas.Campo_Empresa);
                                Txt_Dias_Festivos.Text = fila.IsNull(Ope_Ventas.Campo_Aplican_Dias_Festivos) ? string.Empty : fila.Field<string>(Ope_Ventas.Campo_Aplican_Dias_Festivos);

                                //
                                if (fila.Field<string>("forma_pago").Contains("EFECTIVO"))
                                    Txt_Monto_Efectivo.Text = fila.IsNull(Ope_Pagos.Campo_Monto_Pago) ? string.Empty : string.Format("{0:n}", fila.Field<decimal>(Ope_Pagos.Campo_Monto_Pago));
                                else
                                {
                                    Txt_Forma_Pago.Text = fila.IsNull("forma_pago") ? string.Empty : fila.Field<string>("forma_pago");
                                    Txt_Banco.Text = fila.IsNull("nombre_banco") ? string.Empty : fila.Field<string>("nombre_banco");
                                    Txt_Tarjeta.Text = fila.IsNull(Ope_Pagos.Campo_Tipo_Tarjeta_Banco) ? string.Empty : fila.Field<string>(Ope_Pagos.Campo_Tipo_Tarjeta_Banco);
                                    Txt_Comision.Text = fila.IsNull(Ope_Pagos.Campo_Monto_Comision) ? string.Empty : string.Format("{0:n}", fila.Field<decimal>(Ope_Pagos.Campo_Monto_Comision));
                                    Txt_Monto_Cargar.Text = fila.IsNull(Ope_Pagos.Campo_Monto_Pago) ? string.Empty : string.Format("{0:n}", fila.Field<decimal>(Ope_Pagos.Campo_Monto_Pago));

                                    Txt_Numero_Transaccion.Text = fila.IsNull(Ope_Pagos.Campo_Referencia_Transferencia) ? string.Empty : fila.Field<string>(Ope_Pagos.Campo_Referencia_Transferencia);
                                    Txt_Numero_Tarjeta.Text = fila.IsNull(Ope_Pagos.Campo_Numero_Tarjeta_Banco) ? string.Empty : fila.Field<string>(Ope_Pagos.Campo_Numero_Tarjeta_Banco);
                                    
                                    
                                }
                            });

                            if (!String.IsNullOrEmpty(Txt_Numero_Tarjeta.Text))
                                Txt_Numero_Tarjeta.Text = "xxxxxxxxxxxx" + Txt_Numero_Tarjeta.Text.Substring(12, 4);

                            //Cargamos el Grid de Detalles de Ventas
                            Grid_Detalle_Venta.DataSource = Dt_Detalles_Venta;

                            #region (Personalizar Estilo del Grid de Detalles de Ventas)

                            #region (Custom Columnas)
                            Grid_Detalle_Venta.EnableHeadersVisualStyles = false;

                            Array.ForEach(Grid_Detalle_Venta.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                            {
                                DataGridViewCellStyle rowStyle = Grid_Detalle_Venta.RowHeadersDefaultCellStyle;

                                rowStyle.BackColor = Color.Black;
                                rowStyle.ForeColor = Color.White;
                                rowStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                                columna.HeaderCell.Style = rowStyle;

                                switch (columna.HeaderText)
                                {
                                    case "Cantidad":
                                        columna.Width = 100;
                                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        break;
                                    case "Nombre":
                                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                        columna.Width = 200;
                                        break;
                                    case "Subtotal":
                                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        columna.Width = 100;
                                        columna.DefaultCellStyle.Format = "c";
                                        break;
                                    case "Total":
                                        columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                        columna.Width = 100;
                                        columna.DefaultCellStyle.Format = "c";
                                        break;
                                    default:
                                        columna.Visible = true;
                                        break;
                                }
                            });
                            #endregion

                            #region (Custom Filas)
                            Array.ForEach(Grid_Detalle_Venta.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                            {
                                fila.Height = 30;
                                Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                                {
                                    celda.Style.BackColor = SystemColors.Window;
                                    celda.Style.ForeColor = Color.Black;
                                    celda.Style.Font = new Font("Tahoma", 9, FontStyle.Regular);
                                    celda.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                });
                            });
                            #endregion

                            #endregion
                        }
                    }
                }
            }
        }
        #endregion

        #region (Eventos)
        /// <summary>
        /// Nombre: Btn_Cancelar_Click
        /// 
        /// Descripción: Método que realiza la cancelación del pago.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 01 Noviembre 2013 12:30 Hrs
        /// Usuario Modifico: Olimpo Alberto Cruz Amaya 
        /// Fecha Modifico: 06/Febrero/2015
        /// Motivo: Se agrego un motivo de cancelación, antes de efectuar la cancelación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Cls_Ope_Accesos_Negocio Obj_Accesos = new Cls_Ope_Accesos_Negocio();//Variable de negocios para realizar peticiones a la clase de datos.
            Cls_Ope_Cancelaciones_Negocio Obj_Cancelaciones = new Cls_Ope_Cancelaciones_Negocio();//Variable de negocios para realizar peticiones a la clase de datos.
            DataTable Dt_Accesos = null;//Variable para almacenar el resultado de la búsqueda de accesos.
            Boolean Estatus_PinPad = false;

            try
            {
                //Establecemos filtros de búsqueda.
                Obj_Accesos.P_Estatus = "UTILIZADO";
                Obj_Accesos.P_No_Venta = Txt_No_Venta_Inf.Text.Trim();
                Dt_Accesos = Obj_Accesos.Consultar_Accesos();

                //  validamos que el pago se realizo con tarjeta
                if (!String.IsNullOrEmpty(Txt_Monto_Cargar.Text))
                {
                    Estatus_PinPad = true;
                    //  validamos que tenga una pin pad para realizar la cancelacion
                    if (String.IsNullOrEmpty(Str_Pinpad_Id))
                    {
                        MessageBox.Show(this, "Requiere tener una PIN PAD para poder realizar la cancelación de esta venta", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (Dt_Accesos is DataTable)
                {
                    if (Dt_Accesos.Rows.Count == 0)
                    {
                        //doit cancel venta
                        if (MessageBox.Show(this, "Confirmar la cancelación", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            //Establecemos el no de venta a cancelar.
                            Obj_Cancelaciones.P_No_Venta = Txt_No_Venta_Inf.Text.Trim();
                            //Ejecutamos la cancelación de la venta.
                            Obj_Cancelaciones.P_Motivo_Cancelacion = Microsoft.VisualBasic.Interaction.InputBox("Ingresar el motivo de la cancelación?", "Motivo de Cancelación", string.Empty);
                            //Se realiza la baja de la recolección
                            if (!string.IsNullOrEmpty(Obj_Cancelaciones.P_Motivo_Cancelacion.Trim()))
                            {
                                if (Obj_Cancelaciones.Cancelar_Venta())
                                {
                                    if (Estatus_PinPad == true)
                                        Cancelacion_Pago_Movil();

                                    splitContainer1.Panel2Collapsed = true;//Ocultamos el panel 2
                                    splitContainer1.Panel1Collapsed = false;//Mostramos el panel 1
                                    Limpiar_Datos_Consulta(splitContainer1.Panel2);//Limpiamos los controles del panel 2
                                    Llenar_Grid_Ventas();//Volvemos a cargar el grid de ventas
                                    MessageBox.Show(this, "Se realizó la cancelación de forma correcta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Debe escribir un motivo de cancelación", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No es posible cancelar una pago si los accesos ya fueron utilizados.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Cancelar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Tipo_Venta_Click
        /// 
        /// Descripción: Método habilita e indica si los registros consultados
        ///              corresponden a una venta o aun grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 01 Noviembre 2013 12:30 Hrs
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tipo_Venta_Click(object sender, EventArgs e)
        {
            try
            {
                switch (((Button)sender).Name)
                {
                    case "Btn_Venta":
                        ((Button)sender).Tag = true;
                        Btn_Grupo.Tag = false;
                        Txt_Persona_Tramita.Enabled = false;
                        Txt_Empresa.Enabled = false;
                        Btn_Grupo.FlatStyle = ((Button)sender).FlatStyle;
                        ((Button)sender).FlatStyle = FlatStyle.Flat;
                        break;
                    case "Btn_Grupo":
                        ((Button)sender).Tag = true;
                        Btn_Venta.Tag = false;
                        Txt_Persona_Tramita.Enabled = true;
                        Txt_Empresa.Enabled = true;
                        Btn_Venta.FlatStyle = ((Button)sender).FlatStyle;
                        ((Button)sender).FlatStyle = FlatStyle.Flat;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Tipo_Venta_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Regresar_Busqueda_Click
        /// 
        /// Descripción: Método oculta el panel 2, muestra el panel 1 y limpia los controles. 
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 01 Noviembre 2013 12:30 Hrs
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Regresar_Busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainer1.Panel1Collapsed = false;//Muestra el panel 1
                splitContainer1.Panel2Collapsed = true;//Oculta el panel 2
                Limpiar_Datos_Consulta(splitContainer1.Panel2);//Limpia los controles del panel 2
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Regresar_Busqueda_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Txt_No_Venta_LostFocus
        /// 
        /// Descripción: Método que se ejecuta cuando la caja de texto de no de venta pierde el foco.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 13 Noviembre 2013
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_No_Venta_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                //Txt_No_Venta.Text = (string.IsNullOrEmpty(Txt_No_Venta.Text)) ? string.Empty : Convert.ToInt64(Txt_No_Venta.Text.Trim()).ToString("0000000000");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message,
                    "Error - Método: [Txt_No_Venta_TextChanged]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Pinpad

        /// <summary>
        /// Nombre: Cancelacion_Pago_Movil
        /// Descripción: Se realiza el pago por medio de la pin pad
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 24 Abril 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cancelacion_Pago_Movil()
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta_Parametros = Consulta_Parametros.Consultar_Parametros();

            Banorte.PinPad.Vx810Segura Pinpad = new Banorte.PinPad.Vx810Segura("EN");
            Hashtable Hst_ConfiguracionPinPad = new Hashtable();
            Hashtable Hst_Salida = new Hashtable();
            Hashtable Hst_Selector = new Hashtable();
            Hashtable Hst_EntradaLeer = new Hashtable();
            Hashtable Hst_SalidaLeer = new Hashtable();
            Hashtable Hst_Datos_A_Enviar = new Hashtable();
            Hashtable Hst_EntradaLeer_Transaccion = new Hashtable();
            Hashtable Hst_SalidaLeer_Transaccion = new Hashtable();
            Hashtable Hst_Entrada_Notificar = new Hashtable();
            Hashtable Hst_Salida_Notificar = new Hashtable();

            Boolean Estatus_Aprobado = false;
            Boolean Estatus_Rechazada = false;

            String Str_Mensaje = "";
            String Str_Llave_Maestra = "";
            String Str_Tipo_Operacion_Venta = "";
            String Str_Modo_Operacion = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Operacion_PinPad].ToString();
            String Str_Afiliacion = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Afiliacion_PinPad].ToString();
            String Str_Usuario = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Usuario_PinPad].ToString();
            String Str_Contrasenia = Cls_Seguridad.Desencriptar(Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Contrasenia_PinPad].ToString());
            String Str_URL = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Banorte_Url].ToString();
            String Str_Bin = "";
            String Str_Numero_Tarjeta = "";
            String Str_Titular_Tarjeta = "";
            String Str_Accion_Tarjeta = "";
            String Str_Entry_Mode = "";
            String Str_Emv_Tags = "";
            String Str_Track2 = "";
            String Str_Resultado_Lectura_Transaccion = "";
            String Str_Emv_Result = "";
            String Str_Emv_Data = "";

            try
            {
                if (!String.IsNullOrEmpty(Txt_Monto_Cargar.Text))
                {
                    Str_Numero_Afiliacion = Str_Afiliacion;
                    Str_Numero_Control = Generar_Numero_Control();

                    //CREA TABLA CON PARÁMETROS DE LA PINPAD
                    Hst_ConfiguracionPinPad.Add("PORT", Str_Pinpad_Com);
                    Hst_ConfiguracionPinPad.Add("BAUD_RATE", "19200");
                    Hst_ConfiguracionPinPad.Add("PARITY", "N");
                    Hst_ConfiguracionPinPad.Add("STOP_BITS", "1");
                    Hst_ConfiguracionPinPad.Add("DATA_BITS", "8");

                    Pinpad.prepareDevice(Hst_ConfiguracionPinPad);

                    Pinpad.getInformation(Hst_Salida);
                    Pinpad.getSelector(Hst_Selector);

                    //  obtener el numero de serie
                    foreach (DictionaryEntry Item in Hst_Salida)
                    {
                        if (Item.Key.ToString() == "SERIAL_NUMBER")
                        {
                            Str_Numero_Serie = Item.Value.ToString();
                            break;
                        }
                    }

                    //  obtener la llave del dispositivo
                    foreach (DictionaryEntry Item in Hst_Selector)
                    {
                        if (Item.Key.ToString() == "SELECTOR")
                        {
                            Str_Llave_Maestra = Item.Value.ToString();
                            break;
                        }
                    }


                    //  transaccion ****************************************************************************
                    Pinpad.displayText("Cancelacion");
                    Pinpad.startTransaction();

                    //  tipo de operacion venta 
                    Str_Tipo_Operacion_Venta = "VOID";

                    //Str_Modo_Operacion = "RND";
                    /*   "Producción" = "PRD"
                        "Aprobado (Pruebas)" "AUT"
                        "Declinado (Pruebas) = "DEC"
                        "Aleatorio (Pruebas) "RND"
                    */

                    Hst_EntradaLeer.Add("PAGO_MOVIL", "0");
                    Hst_EntradaLeer.Add("AMOUNT", Txt_Monto_Cargar.Text);

                    //  datos a enviar para la transaccion ******************************
                    if (Str_Accion_Tarjeta != "1")
                    {
                        // PARÁMETROS DE ENTRADA PARA ENVIAR LA TRANSACCIÓN
                        Hst_Datos_A_Enviar.Add("TERMINAL_ID", Str_Numero_Serie);
                        Hst_Datos_A_Enviar.Add("CMD_TRANS", Str_Tipo_Operacion_Venta);
                        Hst_Datos_A_Enviar.Add("CONTROL_NUMBER", Str_Numero_Control);
                        Hst_Datos_A_Enviar.Add("MODE", Str_Modo_Operacion);
                        Hst_Datos_A_Enviar.Add("RESPONSE_LANGUAGE", "EN");
                        Hst_Datos_A_Enviar.Add("BANORTE_URL", Str_URL);
                        Hst_Datos_A_Enviar.Add("REFERENCE", Txt_Numero_Transaccion.Text);
                        Hst_Datos_A_Enviar.Add("MERCHANT_ID", Str_Afiliacion);
                        Hst_Datos_A_Enviar.Add("PASSWORD", Str_Contrasenia);
                        Hst_Datos_A_Enviar.Add("QPS", "0");
                        Hst_Datos_A_Enviar.Add("USER", Str_Usuario);

                        Banorte.ConectorBanorte.sendTransaction(Hst_Datos_A_Enviar, Hst_SalidaLeer_Transaccion);


                        foreach (DictionaryEntry Item in Hst_SalidaLeer_Transaccion)
                        {
                            if (Item.Key.ToString() == "REFERENCE")
                            {
                                Str_Referencia = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "AUTH_CODE")
                            {
                                //Txt_Numero_Autorizacion.Text = Item.Value.ToString();
                                Str_Auth_Code = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "PAYW_RESULT")
                            {
                                Str_Resultado_Lectura_Transaccion = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "EMV_DATA")
                            {
                                Str_Emv_Data = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "Date")
                            {
                                Dtime_Fecha_Transaccion = Convert.ToDateTime(Item.Value.ToString());
                            }

                        }// fin del foreach


                        //  validacion para tarjetas con banda magnetica
                        if ((Str_Entry_Mode != "CHIP") && (Str_Resultado_Lectura_Transaccion == "A"))
                        {
                            Estatus_Aprobado = true;
                            Str_Mensaje = "Aprobada: " + Str_Auth_Code;
                           
                        }
                        else if ((Str_Resultado_Lectura_Transaccion == "D") || (Str_Resultado_Lectura_Transaccion == "T") || (Str_Resultado_Lectura_Transaccion == "R"))
                        {
                            Estatus_Aprobado = false;
                            Str_Mensaje = "Declinada ";
                        }
                    }


                    Pinpad.displayText(Str_Mensaje);

                    //  se libera el equipo pin pad **************************************
                    Pinpad.releaseDevice();

                    if (Estatus_Aprobado == true)
                    {
                        //  se genera la impresion del Vouchers de venta
                        Cls_Cat_Impresoras_Cajas_Negocio Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                        Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                        Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                        printFont = new Font("Arial", 8);
                        PrintDocument PD = new PrintDocument();
                        PD.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Pago;
                        PD.PrintPage += new PrintPageEventHandler(Imprimir_Solicitud);
                        PD.Print();

                        MessageBox.Show(this, "Aprobada: " + Str_Auth_Code, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "", "introdusca la cantidad a cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Btn_Pago_PinPad_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Imprimir_Solicitud(object sender, PrintPageEventArgs e)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = 5;
                float topMargin = 55;
                string line = null;

                List<string> Texto_Imprimir = new List<string>();
                Cls_Apl_Parametros_Negocio Obj_Parametros = new Cls_Apl_Parametros_Negocio();

                //  se obtiene la imagen del directorio compartido
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                //string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Accesos/Acceso.png";
                //Image Logo = Image.FromFile(Ruta_Archivo);

                Texto_Imprimir.Add("                       BANORTE\n");//   Encabezado del banco
                Texto_Imprimir.Add("                      Cancelación");
                Texto_Imprimir.Add("\n\n");
                Texto_Imprimir.Add("     MUNICIPIO DE GUANAJUAT\n");//  encabezado del cliente
                Texto_Imprimir.Add("    INT MUSEO MOMIAS TEPETAPA SN\n");
                Texto_Imprimir.Add("   Explanada del Panteón Municipal s/n,\n");
                Texto_Imprimir.Add("   Centro, C.P. 36000, Guanajuato, México.\n");
                Texto_Imprimir.Add("       Teléfono: (473) 732 06 39");

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Afiliación:      " + Str_Numero_Afiliacion);// Afiliacion
                Texto_Imprimir.Add("\n    Terminal ID:   " + Str_Numero_Serie);// terminal id
                Texto_Imprimir.Add("\n    Número de control:      " + Str_Numero_Control);// no de control

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Número de tarjeta");
                Texto_Imprimir.Add("\n    xxxxxxxxxxxx" + Txt_Numero_Tarjeta.Text.Substring(12, 4));

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n______________ APROBADA _____________");

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Codigo Autoricación:  " + Str_Auth_Code);
                Texto_Imprimir.Add("\n    Referencia:           " + Str_Referencia);
                Texto_Imprimir.Add("\n    Referencia original:  " + Txt_Numero_Transaccion.Text);
                Texto_Imprimir.Add("\n\n");//   importe
                Texto_Imprimir.Add("\n    Importe:              " + Convert.ToDouble(Txt_Monto_Cargar.Text).ToString("C2"));
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n__________________________________\n");//   Titular de la tarjeta
                //Texto_Imprimir.Add("\n         " + Txt_Titular_Tarjeta.Text);

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n Fecha:   " + Dtime_Fecha_Transaccion.ToLongDateString());
                Texto_Imprimir.Add("\n Hora:    " + Dtime_Fecha_Transaccion.ToLongTimeString());
                Texto_Imprimir.Add("\n");


                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                float Height = 0;

                foreach (string Linea in Texto_Imprimir)
                {
                    Height = printFont.GetHeight(e.Graphics) + 5;
                    yPos = topMargin + (count * Height);
                    e.Graphics.DrawString(Linea, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                    count++;
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Nombre: Generar_Numero_Control
        /// Descripción: Se realiza el numero de control 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 25 Abril 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private String Generar_Numero_Control()
        {

            Double Dia, Mes, Anio, Hora, Minuto, Segundo, Msegundo;
            String Str_Dia, Str_Mes, Str_Hora, Str_Minuto, Str_Segundo, Str_Msegundo;


            Dia = DateTime.Now.Day;
            Mes = DateTime.Now.Month;
            Anio = DateTime.Now.Year;
            Hora = DateTime.Now.Hour;
            Minuto = DateTime.Now.Minute;
            Segundo = DateTime.Now.Second;
            Msegundo = DateTime.Now.Millisecond;

            Str_Dia = string.Format("{0:00}", Dia);
            Str_Mes = string.Format("{0:00}", Mes);
            Str_Hora = string.Format("{0:00}", Hora);
            Str_Minuto = string.Format("{0:00}", Minuto);
            Str_Segundo = string.Format("{0:00}", Segundo);
            Str_Msegundo = string.Format("{0:00}", Msegundo);

            return Str_Dia + Str_Mes + Anio.ToString() + Str_Hora + Str_Minuto + Str_Segundo + Str_Msegundo;
        }

        #endregion
    }
}
