using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Constantes;
using Catalogos.Turnos.Negocio;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Reportes.Ventas.Negocio;
using CrystalDecisions.CrystalReports.Engine;
using ERP_BASE.Paginas.Catalogos.Generales;
using ComponentFactory.Krypton.Toolkit;
using ERP_BASE.Paginas.Paginas_Generales;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Ventas_Internet : Form
    {
        #region (Init/Load)
        public Frm_Rpt_Ventas_Internet()
        {
            InitializeComponent();
            Configuracion_Inicial();
            this.Text = "Reporte de Ventas por Internet";
            
        }
        #endregion

        #region (Métodos)
        /// <summary>
        /// Método que habilita los controles según el valor del parámetro.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 16:42 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Habilitar_Controles(bool Habilitado)
        {
            KCmb_Caja.Enabled = Habilitado;
        }
        /// <summary>
        /// Método que habilita la configuración inical de la pagina.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:19 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Configuracion_Inicial()
        {
            try
            {
                this.Text = "Reporte Detallado de Ventas de Accesos";
                Cargar_Productos();
                Cargar_Cajas();
                Cargar_Turnos();
                Cargar_Lugar_Venta();
                Cargar_Estatus();
                Habilitar_Controles(false);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: Metodo(Configuracion_Inicial). Descripción:" + Ex.Message);
            }
        }
        /// <summary>
        /// Método que realiza la carga de productos registrados por catálogo.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:16 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Productos()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Resultados_Busqueda = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Consultar_Productos();//Ejecutamos la consulta de productos.
                KCmb_Tarifa_Productos.DataSource = Dt_Resultados_Busqueda;//Cargamos el listado de productos.
                KCmb_Tarifa_Productos.ValueMember = Cat_Productos.Campo_Producto_Id;
                KCmb_Tarifa_Productos.DisplayMember = Cat_Productos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Productos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método que realiza la carga de las cajas registradas por catálogo.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:16 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Cajas()
        {
            Cls_Cat_Cajas_Negocio Obj_Cajas = new Cls_Cat_Cajas_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Cajas = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Cajas = Obj_Cajas.Consultar_Caja();//Ejecutamos la consulta de las cajas registradas por catálogo.
                if (Dt_Cajas is DataTable)
                {
                    if (Dt_Cajas.Rows.Count > 0)
                    {
                        var Lista = Dt_Cajas.AsEnumerable()
                            .Select(x => new
                            {
                                Caja_ID = x.IsNull(Cat_Cajas.Campo_Caja_ID) ? string.Empty : x.Field<string>(Cat_Cajas.Campo_Caja_ID),
                                Numero_Caja = x.IsNull(Cat_Cajas.Campo_Numero_Caja) ? string.Empty : x.Field<decimal>(Cat_Cajas.Campo_Numero_Caja).ToString("#")
                            }).ToList();

                        Lista.Insert(0, new { Caja_ID = string.Empty, Numero_Caja = "SELECCIONE" });
                        KCmb_Caja.DataSource = Lista;
                        KCmb_Caja.ValueMember = Cat_Cajas.Campo_Caja_ID;
                        KCmb_Caja.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método que carga los turnos en sistema.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:16 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Turnos()
        {
            Cls_Cat_Turnos_Negocio Obj_Turnos = new Cls_Cat_Turnos_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Turnos = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Turnos = Obj_Turnos.Consultar_Turnos();//Ejecutamos la consulta de las cajas registrados por catálogo.
                if (Dt_Turnos is DataTable)
                {
                    DataRow Dr = Dt_Turnos.NewRow();
                    Dr[Cat_Turnos.Campo_Turno_ID] = string.Empty;
                    Dr[Cat_Turnos.Campo_Nombre] = "SELECCIONE";
                    Dt_Turnos.Rows.InsertAt(Dr, 0);
                }
                KCmb_Turnos.DataSource = Dt_Turnos;
                KCmb_Turnos.ValueMember = Cat_Turnos.Campo_Turno_ID;
                KCmb_Turnos.DisplayMember = Cat_Turnos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método que carga los lugares donde se pueden registrar las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Lugar_Venta()
        {
            try
            {
                Dictionary<string, string> Lugares_Venta = new Dictionary<string, string> { 
                            {"SELECCIONE", string.Empty},
                            {"No Caja", "No Caja"},
                            {"Internet", "Internet"},
                            {"Kiosko", "Kiosko"}
              };
                KCmb_Lugar_Venta.DataSource = new BindingSource(Lugares_Venta, null);
                KCmb_Lugar_Venta.DisplayMember = "Key";
                KCmb_Lugar_Venta.ValueMember = "Value";
                KCmb_Lugar_Venta.SelectedIndex = (0);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Cargar_Lugar_Venta). Descripción: " + Ex.Message);
            }
        }
        /// <summary>
        /// Método que carga los estatus de las ventas.
        /// </summary>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 21 13:33 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Estatus()
        {
            try
            {
                Dictionary<string, string> Lugares_Venta = new Dictionary<string, string> { 
                            {"SELECCIONE", string.Empty},
                            {"ACTIVO", "ACTIVO"},
                            {"UTILIZADO", "UTILIZADO"}
              };
                KCmb_Estatus.DataSource = new BindingSource(Lugares_Venta, null);
                KCmb_Estatus.DisplayMember = "Key";
                KCmb_Estatus.ValueMember = "Value";
                KCmb_Estatus.SelectedIndex = (0);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: (Cargar_Lugar_Venta). Descripción: " + Ex.Message);
            }
        }
        /// <summary>
        /// Nombre: Hacer_Lista
        /// 
        /// Descripción: Método generico que utilizaremos para crear listas con datos anonimos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:24 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemOftype"></param>
        /// <returns></returns>
        public static List<T> Hacer_Lista<T>(T itemOftype)
        {
            List<T> Lista_Nueva = new List<T>();
            return Lista_Nueva;
        }

        /// <summary>
        /// Nombre: CalcularPeriodo6Meses 
        /// Fecha_Creo: 05/Mayo/2015
        /// Descripcion: Se encaga de evaluar si el periodo de busqueda sobrepasa los 6 meses
        /// Usuario_Creo: Olimpo_Cruz
        /// </summary>
        /// <param name="FechaInicio"> Parametro de fecha de inicio a ser evaluado</param>
        /// <param name="FechaFin">Parametro de fecha final a aser evaluado</param>
        /// <returns></returns>
        private bool CalcularPeriodo6Meses(DateTime FechaInicio, DateTime FechaFin)
        {
            Boolean Periodo6meses = false;

            if (FechaInicio <= FechaFin)
            {
                int Dias = (FechaFin - FechaInicio).Days;
                //MessageBox.Show("La cantidad de días es: " + Dias.ToString());
                if (Dias > 183) // 183 dias = 6 meses.
                {
                    Periodo6meses = false;
                    if (!Periodo6meses)
                    {
                        if (MessageBox.Show("El periodo de consulta es MAYOR a 6 meses.\nRealizar esta consulta puede demorar debido a la gran cantidad de ventas efectuadas.\nAún así, ¿Desea continuar?", "Alerta",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                                            == DialogResult.Yes)
                        {
                            Periodo6meses = true;
                        }
                        else Periodo6meses = false;
                    }
                }
                else
                    Periodo6meses = true;
            }
            return Periodo6meses;
        }
        #endregion

        #region (Grid)
        /// <summary>
        /// Nombre: Formato_Tabla
        /// 
        /// Descripción: Método que modifica el formato de la tabla que lista el resultado de la búsqueda.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:31 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Tabla">Control DataGridView del cuál se modificara su formato</param>
        private void Formato_Tabla(DataGridView Tabla)
        {
            try
            {
                Tabla.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                Array.ForEach(Tabla.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    columna.HeaderText = columna.HeaderText.Replace("_", " ");
                    columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (columna.ValueType.Name.Equals("DateTime"))
                        columna.DefaultCellStyle.Format = "dd MMM yyyy";
                    else if (columna.ValueType.Name.Equals("Decimal"))
                        columna.DefaultCellStyle.Format = "c";

                    if (columna.HeaderText.Equals("Detalle"))
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        columna.Width = 300;
                    }
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Formato_Tabla]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Metodo que cambia el formato de las celdas del grid de detalles de la venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:31 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        private void Grid_Resultado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.Font = new System.Drawing.Font("Consolas Black", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        #endregion

        #region (Eventos)

        #region (Botones)
        /// <summary>
        /// Evento que realiza la búsqueda de las ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio(); //Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null; //Variable que utilizaremos para almacenar los resultados de la búsqueda.
            Boolean Periodo6Meses = false;


            try
            {
                Grid_Resultado.DataSource = null;

                //Establecemos los filtros para realizar la búsqueda.
                if (KDtp_Fecha_Inicio.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                if (KDtp_Fecha_Termino.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(KDtp_Fecha_Termino.Value.Year
                        , KDtp_Fecha_Termino.Value.Month
                        , KDtp_Fecha_Termino.Value.Day, 23, 59, 59);

                if (KCmb_Tarifa_Productos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Tarifa_Productos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Producto_ID = KCmb_Tarifa_Productos.SelectedValue.ToString();

                if (KCmb_Caja.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();

                if (KCmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = KCmb_Lugar_Venta.Text;

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Lugar_Venta = KCmb_Lugar_Venta.SelectedValue.ToString();

                if (KCmb_Estatus.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Estatus.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Estatus = KCmb_Estatus.SelectedValue.ToString();

                if (!String.IsNullOrEmpty(Txt_Folio_Acceso.Text))
                    Obj_Rpt_Ventas.P_Folio_Acceso = Txt_Folio_Acceso.Text;

                Periodo6Meses = CalcularPeriodo6Meses(Obj_Rpt_Ventas.P_Fecha_Inicio, Obj_Rpt_Ventas.P_Fecha_Termino);

                if (Periodo6Meses)
                {
                    Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Ventas_Internet();

                    if (Ds_Resultados_Busqueda.Tables["Detalle_Ventas"] is DataTable)
                        if (Ds_Resultados_Busqueda.Tables["Detalle_Ventas"].Rows.Count > 0)
                            Grid_Resultado.DataSource = Ds_Resultados_Busqueda.Tables["Detalle_Ventas"];
                        else Grid_Resultado.DataSource = new DataTable();
                    else Grid_Resultado.DataSource = new DataTable();
                }

                //Formato_Tabla(Grid_Resultado);//Modificamos el formato de la tabla de resultados de la búsqueda.
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento que genera el reporte de concentrado de las ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataSet Ds_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.

            try
            {
                //Establecemos los filtros para realizar la búsqueda.
                if (KDtp_Fecha_Inicio.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(KDtp_Fecha_Inicio.Value.Year
                        , KDtp_Fecha_Inicio.Value.Month
                        , KDtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                if (KDtp_Fecha_Termino.Checked)
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(KDtp_Fecha_Termino.Value.Year
                        , KDtp_Fecha_Termino.Value.Month
                        , KDtp_Fecha_Termino.Value.Day, 23, 59, 59);

                if (KCmb_Tarifa_Productos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Tarifa_Productos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Producto_ID = KCmb_Tarifa_Productos.SelectedValue.ToString();

                if (KCmb_Caja.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Caja.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = KCmb_Caja.SelectedValue.ToString();

                if (KCmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = KCmb_Turnos.SelectedValue.ToString();

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = KCmb_Lugar_Venta.Text;

                if (KCmb_Lugar_Venta.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Lugar_Venta.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Lugar_Venta = KCmb_Lugar_Venta.SelectedValue.ToString();

                if (KCmb_Estatus.SelectedValue is object)
                    if (!string.IsNullOrEmpty(KCmb_Estatus.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Estatus = KCmb_Estatus.SelectedValue.ToString();

                if (!String.IsNullOrEmpty(Txt_Folio_Acceso.Text))
                    Obj_Rpt_Ventas.P_Folio_Acceso = String.Format("{0:0000000000}", Convert.ToDouble(Txt_Folio_Acceso.Text));

                Ds_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Ventas_Internet();
                Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + "Cr_Rpt_Ventas_Internet.rpt");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento que limpia los combos de lugar de venta, cajas, turnos y tarifas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void SBtn_Clear_Click(object sender, EventArgs e)
        {
            switch (((ButtonSpecAny)sender).Tag.ToString())
            {
                case "lugar_venta":
                    KCmb_Lugar_Venta.SelectedIndex = 0;
                    break;
                case "caja":
                    KCmb_Caja.SelectedIndex = 0;
                    break;
                case "turno":
                    KCmb_Turnos.SelectedIndex = 0;
                    break;
                case "tarifa":
                    KCmb_Tarifa_Productos.SelectedIndex = 0;
                    break;
                case "estatus":
                    KCmb_Estatus.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Evento que limpia los controles de la pagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            KCmb_Caja.SelectedIndex = 0;
            KCmb_Caja.Enabled = true;
            KCmb_Estatus.SelectedIndex = 0;
            KCmb_Lugar_Venta.SelectedIndex = 0;
            KCmb_Tarifa_Productos.SelectedIndex = 0;
            KCmb_Turnos.SelectedIndex = 0;

            KDtp_Fecha_Inicio.Value = DateTime.Now;
            KDtp_Fecha_Inicio.Checked = false;
            KDtp_Fecha_Inicio.Invalidate();

            KDtp_Fecha_Termino.Value = DateTime.Now;
            KDtp_Fecha_Termino.Checked = false;
            KDtp_Fecha_Termino.Invalidate();

            Grid_Resultado.DataSource = new DataTable();
        }
        #endregion

        #region (Combos)
        /// <summary>
        /// Evento que habilita o deshabilita el combo de cajas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void KCmb_Lugar_Venta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KCmb_Lugar_Venta.SelectedValue != null)
            {
                switch (KCmb_Lugar_Venta.SelectedValue.ToString())
                {
                    case "No Caja":
                        KCmb_Caja.Enabled = true;
                        break;
                    default:
                        KCmb_Caja.Enabled = false;
                        KCmb_Caja.SelectedIndex = 0;
                        break;
                }
            }
        }
        #endregion

        #endregion

        #region (Reporte)
        /// *************************************************************************************
        /// NOMBRE: Generar_Reporte
        /// 
        /// DESCRIPCIÓN: Método que invoca la generación del reporte.
        ///              
        /// PARÁMETROS: Nombre_Plantilla_Reporte.- Nombre del archivo del Crystal Report.
        ///             Nombre_Reporte_Generar.- Nombre que tendrá el reporte generado.
        /// 
        /// USUARIO CREO: Juan Alberto Hernández Negrete.
        /// FECHA CREO: 3/Mayo/2011 18:15 p.m.
        /// USUARIO MODIFICO:
        /// FECHA MODIFICO:
        /// CAUSA MODIFICACIÓN:
        /// *************************************************************************************
        protected void Generar_Reporte(ref DataSet Ds_Datos, String Nombre_Plantilla_Reporte)
        {
            ReportDocument Reporte = new ReportDocument();//Variable de tipo reporte.
            String Ruta = String.Empty;//Variable que almacenara la ruta del archivo del crystal report. 

            try
            {
                Ruta = (Nombre_Plantilla_Reporte);
                Reporte.Load(Ruta);

                if (Ds_Datos is DataSet)
                {
                    if (Ds_Datos.Tables.Count > 0)
                    {
                        Reporte.SetDataSource(Ds_Datos);
                        Frm_Rpt_Mostrar_Reporte_ Frm_Mostrar_Reporte = new Frm_Rpt_Mostrar_Reporte_();
                        Frm_Mostrar_Reporte.P_Reporte = Reporte;
                        Frm_Mostrar_Reporte.ShowDialog(this);
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte. Error: [" + Ex.Message + "]");
            }
        }
        #endregion
    }
}
