using Catalogos.Turnos.Negocio;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Reportes.Ventas.Negocio;
using ResizeableForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ERP_BASE.Paginas.Reportes;
using ERP_BASE.Paginas.Catalogos.Generales;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Ventas : ResizableForm
    {
        private DataTable Dt_Productos;

        #region (Init/Load)
        /// <summary>
        /// Nombre: Frm_Rpt_Ventas
        /// 
        /// Descripción: Método que carga la configuración inicial de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:15 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public Frm_Rpt_Ventas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Nombre: Frm_Rpt_Ventas_Load
        /// 
        /// Descripción: Método que se ejecuta cuando se completa la carga inicial de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:16 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Rpt_Ventas_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Productos();//Se realiza la carga del listado de productos.
                Cargar_Tipos_Movimientos();//Se realiza la carga del listado de movimientos.
                Cargar_Cajas();//Se realiza la carga de las cajas registradas por catálogo.
                Cargar_Turnos();//Se realiza la carga de los turnos registrados por catálogo.

                Cmb_Anio.SelectedIndex = 0;
                Cmb_Museo.SelectedIndex = 0;
                Cmb_Producto.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Frm_Rpt_Ventas_Load]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Metodos)
        /// <summary>
        /// Nombre: Cargar_Productos
        /// 
        /// Descripción: Método que realiza la carga de productos registrados por catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:17 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Productos() {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable de negocios que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Resultados_Busqueda = null;//Variable donde se almacenaran los resultados de la búsqueda.

            try
            {
                Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Consultar_Productos();//Ejecutamos la consulta de productos.
                //Cmb_Producto.DataSource = Dt_Resultados_Busqueda;//Cargamos el listado de productos.
                Dt_Resultados_Busqueda.Rows.RemoveAt(0);
                Dt_Productos = Dt_Resultados_Busqueda;
                Cmb_Producto.ValueMember = Cat_Productos.Campo_Producto_Id;
                Cmb_Producto.DisplayMember = Cat_Productos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Productos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Cargar_Cajas
        /// 
        /// Descripción: Método que realiza la carga de las cajas registradas por catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:20 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
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
                        Cmb_Cajas.DataSource = Lista;
                        Cmb_Cajas.ValueMember = Cat_Cajas.Campo_Caja_ID;
                        Cmb_Cajas.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Cargar_Turnos
        /// 
        /// Descripción: Método que carga la lista de turnos registrados por catálogo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:22 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico
        /// </summary>
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
                Cmb_Turnos.DataSource = Dt_Turnos;
                Cmb_Turnos.ValueMember = Cat_Turnos.Campo_Turno_ID;
                Cmb_Turnos.DisplayMember = Cat_Turnos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Cargar_Tipos_Movimientos
        /// 
        /// Descripción: Método que carga la lista de los tipos de movimientos [Ventas - Recolecciones - Arqueos].
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:15 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Tipos_Movimientos()
        {
            try
            {
                var Arqueo = new { Movimiento_ID = "ARQUEO", Movimiento = "ARQUEO" };
                var Recoleccion = new { Movimiento_ID = "RECOLECCION", Movimiento = "RECOLECCION" };
                var Retiro = new { Movimiento_ID = "RETIRO", Movimiento = "RETIRO" };
                var Lista = Hacer_Lista(Arqueo);

                //Lista.Add(Arqueo);
                //Lista.Add(Recoleccion);
                //Lista.Add(Retiro);
                Lista.Insert(0, new { Movimiento_ID = "", Movimiento = "VENTA" });

                Cmb_Movimientos.DataSource = Lista;
                Cmb_Movimientos.ValueMember = "Movimiento_ID";
                Cmb_Movimientos.DisplayMember = "Movimiento";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Tipos_Movimientos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Nombre: Habilitar_Controles
        /// 
        /// Descripción: Método que utilizaremos aplicar la configuración según el tipo de movimiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:26 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Estado">Bandera que servira para habilitar o deshabilitar los controles</param>
        /// <param name="Tipo">Tipo de movimientos que se consultaran</param>
        private void Habilitar_Controles(bool Estado, string Tipo)
        {
            try
            {
                switch (Tipo)
                {
                    case "Venta":
                        Limpiar_Combo(Cmb_Cajas);
                        Limpiar_Combo(Cmb_Turnos);
                        Limpiar_Combo(Cmb_Producto);
                        Limpiar_Combo(Cmb_Movimientos);
                        Limpiar_Combo(Cmb_Lugar_Venta);

                        Cmb_Cajas.Enabled = Estado;
                        Cmb_Turnos.Enabled = Estado;
                        Cmb_Producto.Enabled = Estado;
                        Cmb_Movimientos.Enabled = Estado;
                        break;
                    case "Movimiento_Caja":
                        Limpiar_Combo(Cmb_Cajas);
                        Limpiar_Combo(Cmb_Turnos);
                        Limpiar_Combo(Cmb_Producto);
                        Limpiar_Combo(Cmb_Lugar_Venta);

                        Cmb_Cajas.Enabled = Estado;
                        Cmb_Turnos.Enabled = Estado;
                        Cmb_Producto.Enabled = !Estado;
                        Cmb_Movimientos.Enabled = Estado;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Habilitar_Controles]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Limpiar_Combo
        /// 
        /// Descripción: Método que limpia los controles de tipo ComboBox de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:29 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Cmb"></param>
        private void Limpiar_Combo(ComboBox Cmb)
        {
            try
            {
                if (Cmb.Items.Count <= 0)
                    Cmb.SelectedIndex = (-1);
                else
                    Cmb.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Limpiar_Combo]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Nombre: CalcularPeriodo6Meses 
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
                Array.ForEach(Grid_Resultados_Busqueda.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    if (columna.ValueType.Name.Equals("DateTime"))
                        columna.DefaultCellStyle.Format = "dd MMM yyyy";
                    else if (columna.ValueType.Name.Equals("Decimal") && !columna.HeaderText.Equals("NoCaja"))
                        columna.DefaultCellStyle.Format = "c";

                    //columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    if (columna.HeaderText.Equals("Detalle"))
                    {
                        columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        columna.Width = 300; 
                    }
                });
                
                int Indice = Grid_Resultados_Busqueda.Rows.Count - 1;

                if (Grid_Resultados_Busqueda.Rows[Indice].Cells[0].Value.ToString().Equals("Totales"))
                {
                    Grid_Resultados_Busqueda.Rows[Indice].DefaultCellStyle =
                        new DataGridViewCellStyle()
                        {
                            BackColor = Color.BlanchedAlmond,
                            Font = new Font("Consolas", 9, FontStyle.Bold)
                        };
                }

                /*
                Array.ForEach(Grid_Resultados_Busqueda.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                {
                    fila.DefaultCellStyle.Font = new Font("Consolas", 8, FontStyle.Regular);

                    if (Cmb_Movimientos.SelectedIndex == 0)
                    {
                        if (fila.Cells["NoVenta"] != null)
                        {
                            if (fila.Cells["NoVenta"].Value != null)
                            {
                                if (fila.Cells["NoVenta"].Value.ToString().Contains("Totales"))
                                {
                                    fila.DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                                    {
                                        if (!string.IsNullOrEmpty(celda.Value.ToString()))
                                        {
                                            celda.Style.Font = new Font("Consolas", 9, FontStyle.Bold);
                                        }
                                    });
                                }
                            }
                        }
                    }
                    else if (Grid_Resultados_Busqueda.Columns.Contains("NoMovimiento"))
                    {
                        if (fila.Cells["NoMovimiento"] != null)
                        {
                            if (fila.Cells["NoMovimiento"].Value != null)
                            {
                                if (fila.Cells["NoMovimiento"].Value.ToString().Contains("Totales"))
                                {
                                    fila.DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                                    {
                                        if (!string.IsNullOrEmpty(celda.Value.ToString()))
                                        {
                                            celda.Style.Font = new Font("Consolas", 9, FontStyle.Bold);
                                        }
                                    });
                                }
                            }
                        }
                    }
                    else if (Grid_Resultados_Busqueda.Columns.Contains("NoRetiro"))
                    {
                        if (fila.Cells["NoRetiro"] != null)
                        {
                            if (fila.Cells["NoRetiro"].Value != null)
                            {
                                if (fila.Cells["NoRetiro"].Value.ToString().Contains("Total"))
                                {
                                    fila.DefaultCellStyle.BackColor = Color.BlanchedAlmond;
                                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                                    {
                                        if (!string.IsNullOrEmpty(celda.Value.ToString()))
                                        {
                                            celda.Style.Font = new Font("Consolas", 9, FontStyle.Bold);
                                        }
                                    });
                                }
                            }
                        }
                    }
                });
                */
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Formato_Tabla]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Eventos)

        #region (Botones)
        /// <summary>
        /// Nombre: Btn_Consultar_Click
        /// 
        /// Descripción: Método que ejecuta la consulta de los tipos de movimientos [Ventas - Recolecciones - Arqueos]
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:36 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            Boolean Periodo6Meses = false; 

            try
            {
                Grid_Resultados_Busqueda.DataSource = null;

                //Establecemos los filtros para realizar la búsqueda.
                if (Dtp_Fecha_Inicio.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(Dtp_Fecha_Inicio.Value.Year
                        , Dtp_Fecha_Inicio.Value.Month
                        , Dtp_Fecha_Inicio.Value.Day, 0, 0, 0);
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar una Fecha de Inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Dtp_Fecha_Termino.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(Dtp_Fecha_Termino.Value.Year
                        , Dtp_Fecha_Termino.Value.Month
                        , Dtp_Fecha_Termino.Value.Day, 23, 59, 59);
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar una Fecha de Término", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Cmb_Producto.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Producto.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Producto_ID = Cmb_Producto.SelectedValue.ToString();

                if (Cmb_Cajas.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Cajas.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = Cmb_Cajas.SelectedValue.ToString();

                if (Cmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = Cmb_Turnos.SelectedValue.ToString();

                if (Cmb_Movimientos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Movimientos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = Cmb_Movimientos.Text;

                if (Cmb_Lugar_Venta.Text is object)
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                        Obj_Rpt_Ventas.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                if (Cmb_Museo.SelectedIndex > 0)
                {
                    Obj_Rpt_Ventas.P_Museo = Cmb_Museo.Text == "MUSEO MOMIAS" ? "00001" : "00002";
                }

                Periodo6Meses = CalcularPeriodo6Meses(Obj_Rpt_Ventas.P_Fecha_Inicio, Obj_Rpt_Ventas.P_Fecha_Termino);


                if (Periodo6Meses)
                {
                    //Según el tipo de movimiento modificamos el nombre del GroupBox que almacena los resultados de la búsqueda.
                    if (Cmb_Movimientos.SelectedIndex > 0)
                    {
                        Obj_Rpt_Ventas.Es_Detallado = false;
                        if (!Cmb_Movimientos.SelectedValue.ToString().ToLower().Equals("retiro"))
                            Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Movimientos_Caja();
                        else
                            Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Consultar_Retiros();

                        Pnl_Registros.Text = "Resultados de la búsqueda de " + Cmb_Movimientos.SelectedValue
                            .ToString()
                            .Replace("RECOLECCION", "Recolecciones")
                            .Replace("ARQUEO", "Arqueos");
                    }
                    else
                    {
                        Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Rpt_Ventas().Tables["Padre"];
                        Pnl_Registros.Text = "Resultados de la búsqueda de Ventas";
                    }

                    if (Dt_Resultados_Busqueda is DataTable)
                        if (Dt_Resultados_Busqueda.Rows.Count > 0)
                            Grid_Resultados_Busqueda.DataSource = Dt_Resultados_Busqueda;
                        else Grid_Resultados_Busqueda.DataSource = new DataTable();
                    else Grid_Resultados_Busqueda.DataSource = new DataTable();
                }

                //Grid_Resultados_Busqueda.Columns["Detalle"].Visible = false;

                //Formato_Tabla(Grid_Resultados_Busqueda);//Modificamos el formato de la tabla de resultados de la búsqueda.
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Btn_Consulta_Detallada_Click
        /// 
        /// Descripción: Método realiza la consulta de movimientos de forma detallada.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 29 Noviembre 2013 12:23 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico: 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Consulta_Detallada_Click(object sender, EventArgs e)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que se utilizara para realizar peticiones a la clase de datos.
            DataSet Ds_Resultado = new DataSet();//Variable que se utiliza para almacenar el resultado de la búsqueda.
            DataTable Dt_Venta = null;//Variable que almacenara los resultados de la búsqueda.
            DataTable Dt_Detalles_Venta = null;//Variable que se utiliza para alamacenar el detalle de la venta.

            try
            {
                Grid_Resultados_Busqueda.DataSource = null;

                if (Dtp_Fecha_Inicio.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Inicio = new DateTime(Dtp_Fecha_Inicio.Value.Year
                        , Dtp_Fecha_Inicio.Value.Month
                        , Dtp_Fecha_Inicio.Value.Day, 0, 0, 0);
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar una Fecha de Inicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Dtp_Fecha_Termino.Checked)
                {
                    Obj_Rpt_Ventas.P_Fecha_Termino = new DateTime(Dtp_Fecha_Termino.Value.Year
                        , Dtp_Fecha_Termino.Value.Month
                        , Dtp_Fecha_Termino.Value.Day, 23, 59, 59);
                }
                else
                {
                    MessageBox.Show("Debe Seleccionar una Fecha de Término", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Cmb_Producto.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Producto.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Producto_ID = Cmb_Producto.SelectedValue.ToString();

                if (Cmb_Cajas.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Cajas.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Caja_ID = Cmb_Cajas.SelectedValue.ToString();

                if (Cmb_Turnos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Turnos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Turno_ID = Cmb_Turnos.SelectedValue.ToString();

                if (Cmb_Movimientos.SelectedValue is object)
                    if (!string.IsNullOrEmpty(Cmb_Movimientos.SelectedValue.ToString()))
                        Obj_Rpt_Ventas.P_Tipo_Movimiento = Cmb_Movimientos.Text;

                if (Cmb_Lugar_Venta.Text is object)
                    if (Cmb_Lugar_Venta.Text != "SELECCIONE")
                        Obj_Rpt_Ventas.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                //Según el tipo de movimiento modificamos el nombre del GroupBox que almacena los resultados de la búsqueda.
                if (Cmb_Movimientos.SelectedIndex > 0)
                {
                    Obj_Rpt_Ventas.Es_Detallado = true;
                    if (!Cmb_Movimientos.SelectedValue.ToString().ToLower().Equals("retiro"))
                        Dt_Venta = Obj_Rpt_Ventas.Rpt_Movimientos_Caja();
                    else
                        Dt_Venta = Obj_Rpt_Ventas.Consultar_Retiros();

                    Pnl_Registros.Text = "Resultados de la búsqueda de " + Cmb_Movimientos.SelectedValue
                        .ToString()
                        .Replace("RECOLECCION", "Recolecciones")
                        .Replace("ARQUEO", "Arqueos");
                }
                else
                {
                    string detalles = string.Empty;

                    Obj_Rpt_Ventas.Es_Detallado = true;
                    Ds_Resultado = Obj_Rpt_Ventas.Rpt_Ventas();
                    if (Ds_Resultado.Tables.Count == 2)
                    {
                        Dt_Venta = Ds_Resultado.Tables["Padre"];
                        Dt_Detalles_Venta = Ds_Resultado.Tables["Hijos"];
                        //Dt_Venta.Columns.Add("Detalle", typeof(string));

                        /*
                        Array.ForEach(Dt_Venta.Rows.OfType<DataRow>().ToArray(), _filaPadre =>
                        {
                            detalles = string.Empty;
                            var no_venta = _filaPadre.IsNull("NoVenta") ? string.Empty : _filaPadre.Field<string>("NoVenta");
                            if (!no_venta.Equals("Totales"))
                            {
                                Array.ForEach(Dt_Detalles_Venta.AsEnumerable().Where(x => x.Field<string>("NoVEnta").Equals(no_venta)).CopyToDataTable<DataRow>().Rows.OfType<DataRow>().ToArray(), filaHija =>
                                {
                                    detalles += (filaHija.IsNull("NoProductos") ? string.Empty : filaHija.Field<Int32>("NoProductos").ToString()).PadRight(3) + " ";
                                    detalles += (filaHija.IsNull("Producto") ? string.Empty : filaHija.Field<string>("Producto").ToString()).PadRight(25) + "\n";
                                    detalles += ("$" + (filaHija.IsNull(Ope_Ventas_Detalles.Campo_Subtotal) ? string.Empty : filaHija.Field<decimal>(Ope_Ventas_Detalles.Campo_Subtotal).ToString())).PadLeft(9) + " "; 
                                    detalles += ("Total $" + (filaHija.IsNull(Ope_Ventas_Detalles.Campo_Total) ? string.Empty : filaHija.Field<decimal>(Ope_Ventas_Detalles.Campo_Total).ToString())).PadLeft(9) + "\n";
                                    detalles += "-----------\n";
                                });
                                _filaPadre.SetField<string>("Detalle", detalles);
                            }
                        });
                        */

                        Pnl_Registros.Text = "Resultados de la búsqueda de Ventas";
                    }
                }

                if (Dt_Venta is DataTable)
                {
                    if (Dt_Venta.Rows.Count > 0)
                    {
                        Grid_Resultados_Busqueda.DataSource = Dt_Detalles_Venta; //Dt_Venta;
                        //if (Grid_Resultados_Busqueda.Columns["Detalle"] != null)
                          //  Grid_Resultados_Busqueda.Columns["Detalle"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    }
                    else Grid_Resultados_Busqueda.DataSource = new DataTable();
                }
                else Grid_Resultados_Busqueda.DataSource = new DataTable();

                //Formato_Tabla(Grid_Resultados_Busqueda);//Modificamos el formato de la tabla de resultados de la búsqueda.
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consulta_Detallada_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Btn_Exportar_PDF_Click
        /// 
        /// Descripción: Método que exporta el listado de la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:37 Hrs.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 11-mar-2014
        /// Causa Modificación: Se agrega validación: el Grid_Resultados_Busqueda debe contener registros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            if (Grid_Resultados_Busqueda.Columns.Count > 0)
            {
                try
                {
                    string Ruta_Reporte = "../../Paginas/Plantillas_Crystal/Rpt_Ventas.rpt";
                    DataTable Datos = (DataTable)Grid_Resultados_Busqueda.DataSource;

                    Generar_Reporte(ref Datos, Ruta_Reporte);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_PDF_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Ds_Datos"></param>
        /// <param name="Nombre_Plantilla_Reporte"></param>
        protected void Generar_Reporte(ref DataTable Ds_Datos, String Nombre_Plantilla_Reporte)
        {
            ReportDocument Reporte = new ReportDocument();//Variable de tipo reporte.
            
            String Ruta = String.Empty;//Variable que almacenara la ruta del archivo del crystal report. 

            try
            {
                Reporte.Load(Nombre_Plantilla_Reporte);
                
                if (Ds_Datos.Rows.Count > 0)
                {
                    Reporte.SetDataSource(Ds_Datos);

                    ParameterFieldDefinitions Parametros = Reporte.DataDefinition.ParameterFields;
                    ParameterFieldDefinition Parametro;
                    ParameterDiscreteValue Valor = new ParameterDiscreteValue();
                    ParameterValues Valores = new ParameterValues();

                    List<object[]> objParametros = new List<object[]>();

                    objParametros.Add(new object[] { Dtp_Fecha_Inicio.Value, "Periodo_Inicial" });
                    objParametros.Add(new object[] { Dtp_Fecha_Termino.Value, "Periodo_Final" });

                    if (Cmb_Turnos.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Turnos.Text, "Turno" });
                    }
                    else
                    {
                        objParametros.Add(new object[] { string.Empty, "Turno" });
                    }

                    if (Cmb_Cajas.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Cajas.Text, "No_Caja" });
                    }
                    else
                    {
                        objParametros.Add(new object[] { string.Empty, "No_Caja" });
                    }

                    if (Cmb_Lugar_Venta.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Lugar_Venta.Text, "Lugar_Venta" });
                    }
                    else
                    {
                        objParametros.Add(new object[] { string.Empty, "Lugar_Venta" });
                    }

                    if (Cmb_Museo.SelectedIndex > 0)
                    {
                        objParametros.Add(new object[] { Cmb_Museo.Text, "Museo" });
                    }
                    else
                    {
                        objParametros.Add(new object[] { string.Empty, "Museo" });
                    }
                    
                    objParametros.Add(new object[] { string.Empty, "Folio" });
                    objParametros.Add(new object[] { string.Empty, "Estatus" });
                    objParametros.Add(new object[] { string.Empty, "Tarifa" });



                    foreach (object[] objParametro in objParametros)
                    {
                        Parametro = Parametros[objParametro[1].ToString()];
                        Valores = Parametro.CurrentValues;
                        Valores.Clear();

                        Valor.Value = objParametro[0];
                        Valores.Add(Valor);
                        Parametro.ApplyCurrentValues(Valores);
                    }

                    Frm_Rpt_Mostrar_Reporte_ Frm_Mostrar_Reporte = new Frm_Rpt_Mostrar_Reporte_();

                    //Frm_Mostrar_Reporte.P_Parametros = paramFields;
                    Frm_Mostrar_Reporte.P_Reporte = Reporte;
                    Frm_Mostrar_Reporte.ShowDialog(this);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al generar el reporte. Error: [" + Ex.Message + "]");
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se da click sobre el botón de exportar reporte a excel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>21 Mayo 2014 10:05 Hrs</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            if (Grid_Resultados_Busqueda.Columns.Count > 0)
            {
                try
                {
                    DataTable Dt_Datos_Exportar = Grid_Resultados_Busqueda.DataSource as DataTable;
                    //Exportar_Excel(Dt_Datos_Exportar, Cmb_Movimientos.Text);

                    Exportar_Excel_Epplus(Dt_Datos_Exportar, Cmb_Movimientos.Text);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_Excel_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region (Combos)
        /// <summary>
        /// Nombre: Cmb_Movimientos_SelectedIndexChanged
        /// 
        /// Descripción: Método que se ejecuta cuando cambia el tipo de movimiento seleccionado.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:38 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Movimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Movimientos.SelectedIndex > 0)
                {
                    Habilitar_Controles(true, "Movimiento_Caja");
                }
                else
                {
                    Habilitar_Controles(true, "Venta");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cmb_Movimientos_SelectedIndexChanged]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        
        #endregion

        #region (Reporte)
        /// <summary>
        /// Nombre: Exportar_Datos_PDF
        /// 
        /// Descripción: Método que exporta la tabla de resultados a PDF.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:50 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Documento">Objeto al cúal agregaremos el contenido del reporte</param>
        public void Exportar_Datos_PDF(iTextSharp.text.Document Documento)
        {
            bool Es_Footer = false;
            try
            {
                iTextSharp.text.Phrase _frase = null;
                iTextSharp.text.pdf.PdfPCell _celda = null;

                iTextSharp.text.FontFactory.RegisterDirectory(@"C:\Windows\Fonts");
                //Creamos el objeto de tipo tabla para almacenar el resultado de la búsqueda. 
                iTextSharp.text.pdf.PdfPTable Rpt_Tabla = new iTextSharp.text.pdf.PdfPTable(Grid_Resultados_Busqueda.Columns.Count);
                //Obtenemos y establecemos el formato de las columnas de la tabla.
                float[] Ancho_Cabeceras = Obtener_Tamano_Columnas(Grid_Resultados_Busqueda);
                //Creamos y definimos algunas propiedades que tendrá la fuente que se aplicara a las celdas de la tabla de resultados.
                iTextSharp.text.Font Fuente_Tabla_Contenido = iTextSharp.text.FontFactory.GetFont("Courier New", 7, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font Fuente_Tabla_Footer = iTextSharp.text.FontFactory.GetFont("Courier New", 9, iTextSharp.text.Font.BOLD);

                //Establecemos el formato que tendrá la tabla que mostrara el resultado de la búsqueda según el movimiento consultado.
                Rpt_Tabla.DefaultCell.Padding = 3;
                Rpt_Tabla.SetWidths(Ancho_Cabeceras);
                Rpt_Tabla.WidthPercentage = 100;
                Rpt_Tabla.DefaultCell.BorderWidth = 2;
                Rpt_Tabla.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                Rpt_Tabla.HeaderRows = 1;

                /*
                // Creamos y establecemos el formato que tendrá el titulo del reporte.
                iTextSharp.text.Paragraph Titulo = new iTextSharp.text.Paragraph();
                Titulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Titulo.Font = iTextSharp.text.FontFactory.GetFont("Consolas");
                Titulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Titulo.Font.Size = 14;
                Titulo.Add("Museo de las Momias de Guanajuato");

                // Creamos y establecemos el formato que tendrá el subtitulo del reporte.
                iTextSharp.text.Paragraph Subtitulo = new iTextSharp.text.Paragraph();
                Subtitulo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Subtitulo.Font = iTextSharp.text.FontFactory.GetFont("Consolas");
                Subtitulo.Font.SetStyle(iTextSharp.text.Font.BOLD);
                Subtitulo.Font.Size = 12;
                Subtitulo.Add("Reporte de " + Cmb_Movimientos.Text
                        .ToString()
                        .Replace("VENTA", "Ventas")
                        .Replace("RECOLECCION", "Recolecciones")
                        .Replace("ARQUEO", "Arqueos")
                        + ": " + Dtp_Fecha_Inicio.Text + " - " + Dtp_Fecha_Termino.Text); // rango de fechas del reporte
                // fecha actual
                iTextSharp.text.Phrase Fecha = new iTextSharp.text.Phrase(DateTime.Today.ToString("dd-MMM-yyyy"));
                Fecha.Font.Size = 11;

                // subtitulo con fecha en una tabla sin bordes (misma línea)
                iTextSharp.text.pdf.PdfPTable Tabla_Subtitulo = new iTextSharp.text.pdf.PdfPTable(2);
                Tabla_Subtitulo.WidthPercentage = 100;
                Tabla_Subtitulo.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Subtitulo.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                Tabla_Subtitulo.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                Tabla_Subtitulo.AddCell(Subtitulo);
                Tabla_Subtitulo.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                Tabla_Subtitulo.AddCell(Fecha);
                */

                //Agregamos los nombres de las columnas de la tabla que se imprimira en el reporte.
                Array.ForEach(Grid_Resultados_Busqueda.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    var cabecera = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(columna.HeaderText, iTextSharp.text.FontFactory.GetFont("Consolas", 8, iTextSharp.text.Font.BOLD)));

                    cabecera.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                    cabecera.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                    Rpt_Tabla.AddCell(cabecera);
                });
                //Modificamos el tipo de border que tendrá las celdas que mostraran los datos, con respécto al borde que tiene asignado la cabeceras de las columnas.
                Rpt_Tabla.DefaultCell.BorderWidth = 1;

                //Agreamos el resultado de la búsqueda de movimientos al tabla que se enviara al reporte.
                Array.ForEach(Grid_Resultados_Busqueda.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                {
                    if (fila.Cells[0] != null)
                    {
                        if (fila.Cells[0].Value != null)
                        {
                            if (fila.Cells[0].Value.ToString().ToLower().Contains("totales"))
                                Es_Footer = true;
                            else
                                Es_Footer = false;
                        }
                        else Es_Footer = false;
                    }
                    else Es_Footer = false;

                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                    {
                        string texto = string.Empty;

                        if (celda.Value != null)
                        {
                            if (celda.ValueType.Name.Equals("DateTime"))
                                texto = string.Format("{0:dd MMM yyyy}", celda.Value);
                            else if (celda.ValueType.Name.Equals("Decimal") && !celda.OwningColumn.HeaderText.Equals("NoCaja"))
                                texto = string.Format("{0:n}", celda.Value);
                            else
                                texto = celda.Value.ToString();
                        }

                        if (Es_Footer)
                        {
                            //Establecemos el formato que llevaran las celdas de totales de la tabla del reporte.
                            _frase = new iTextSharp.text.Phrase(texto, Fuente_Tabla_Footer);
                            _celda = new iTextSharp.text.pdf.PdfPCell(_frase);
                            _celda.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                        }
                        else
                        {
                            //Establecemos el formato que llevaran las celdas de contenido de la tabla del reporte.
                            _frase = new iTextSharp.text.Phrase(texto, Fuente_Tabla_Contenido);
                            _celda = new iTextSharp.text.pdf.PdfPCell(_frase);
                        }

                        if (celda.OwningColumn.HeaderText == "Subtotal" ||
                            celda.OwningColumn.HeaderText == "Descuentos" ||
                            celda.OwningColumn.HeaderText == "Total")
                        {
                            _celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT;
                        }
                        else
                        {
                            _celda.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                        }

                        _celda.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                        //Establecemos el valor de la celda.
                        Rpt_Tabla.AddCell(_celda);
                    });

                    //Indicamos que se completo de editar la fila y completamos la operación.
                    Rpt_Tabla.CompleteRow();
                });


                // Firma Izquierda
                iTextSharp.text.Phrase Firma_Izquierda =
                    new iTextSharp.text.Phrase("\n\n\n\n\n________________________\nFirma Cajero");
                Firma_Izquierda.Font.Size = 11;

                // Firma Derecha
                iTextSharp.text.Phrase Firma_Derecha =
                    new iTextSharp.text.Phrase("\n\n\n\n\n________________________\nFirma Supervisor");
                Firma_Derecha.Font.Size = 11;

                //Tabla con firmas
                iTextSharp.text.pdf.PdfPTable Tabla_Firmas = new iTextSharp.text.pdf.PdfPTable(2);
                Tabla_Firmas.WidthPercentage = 100;
                Tabla_Firmas.DefaultCell.Border = iTextSharp.text.pdf.PdfPCell.NO_BORDER;
                Tabla_Firmas.DefaultCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                Tabla_Firmas.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                Tabla_Firmas.AddCell(Firma_Izquierda);
                Tabla_Firmas.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                Tabla_Firmas.AddCell(Firma_Derecha);

                //Se agrega el PDFTable al documento.
                /*Documento.Add(Titulo);
                Documento.Add(Tabla_Subtitulo);*/
                //Documento.Add(new iTextSharp.text.Paragraph("\n"));
                Documento.Add(Rpt_Tabla);
                //Documento.Add(new iTextSharp.text.Paragraph("\n"));
                //Documento.Add(Tabla_Firmas);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Exportar_Datos_PDF]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Obtener_Tamano_Columnas
        /// 
        /// Descripción: Método que obtiene la propiedad Width de cada columna y la almacena en un vector.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 27 Noviembre 2013 18:15 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Tabla">Tabla de resultados de la cuál obtendremos la propiedad Width de cada columna</param>
        /// <returns>Arreglo con los valores establecidos de cada columna de la tabla de resultados</returns>
        public float[] Obtener_Tamano_Columnas(DataGridView Tabla)
        {
            float[] Lst_Ancho_Columnas = null;//Arreglo que almacenara la anchura de cada columna de la tabla de resultados.
            int i = 0;//Contador que se utilizara para ir estableciendo los valores al arreglo.

            try
            {
                Lst_Ancho_Columnas = new float[Tabla.ColumnCount];//Establecemos el número de elementos que tendrá el arreglo.
                Array.ForEach(Tabla.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
                {
                    Lst_Ancho_Columnas[i++] = (float)columna.Width;//Establecemos el valor Width actual de la columna.
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Obtener_Tamano_Columnas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lst_Ancho_Columnas;
        }
        #endregion

        #region (Reporte Excel)
        /// <summary>
        /// Método que exporta el reporte a excel.
        /// </summary>
        /// <param name="Dt_Datos">Tabla que contiene los datos que se mostraran en el reporte</param>
        /// <param name="Titulo">Titulo del reporte</param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>21 Mayo 2014 10:08 Hrs</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public void Exportar_Excel_Epplus(DataTable Dt_Datos, string Titulo)
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_General = new DataTable();

            try
            {

                Dt_General = Dt_Datos.Copy();
                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xls)|*.xls";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                if (Dt_General.TableName == "Padre")
                {
                    if (!Dt_General.Columns.Contains("Fecha_Formato_Fecha"))
                    {
                        Dt_General.Columns.Add("Fecha_Formato_Fecha", typeof(System.DateTime));
                    }


                    Dt_General.Rows.RemoveAt(Dt_General.Rows.Count - 1);
                    Dt_General.AcceptChanges();

                    foreach (DataRow Registro in Dt_General.Rows)
                    {
                        Registro.BeginEdit();
                        Registro["Fecha_Formato_Fecha"] = Convert.ToDateTime(Registro["Fecha"].ToString());
                        Registro.EndEdit();
                    }

                    Dt_General.Columns.RemoveAt(5);
                    Dt_General.AcceptChanges();

                    Dt_General.Columns[0].ColumnName = "Folio de la venta";
                    Dt_General.Columns[1].ColumnName = "Lugar de la venta";
                    Dt_General.Columns[6].ColumnName = "No. caja";
                    Dt_General.Columns[8].ColumnName = "Fecha";

                }
                else
                {
                    if (!Dt_General.Columns.Contains("Fecha_Formato_Fecha"))
                    {
                        Dt_General.Columns.Add("Fecha_Formato_Fecha", typeof(System.DateTime));
                    }

                    foreach (DataRow Registro in Dt_General.Rows)
                    {
                        Registro.BeginEdit();
                        Registro["Fecha_Formato_Fecha"] = Convert.ToDateTime(Registro["Fecha"].ToString());
                        Registro.EndEdit();
                    }

                    Dt_General.Columns.RemoveAt(1);

                    Dt_General.Columns[0].ColumnName = "Folio de la venta";
                    Dt_General.Columns[6].ColumnName = "No. caja";
                    Dt_General.Columns[8].ColumnName = "Fecha";
                           
                }

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName)) File.Delete(Sfd_Ruta_Archivo.FileName);
                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Ventas");

                        Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                        Detallado.Cells["A2"].Value = "Dirección de ingresos";
                        Detallado.Cells["A3"].Value = "Museo de las momias";
                        Detallado.Cells["A4"].Value = "Periodo: De " + Convert.ToDateTime(Dtp_Fecha_Inicio.Value).ToLongDateString() + " al " + Convert.ToDateTime(Dtp_Fecha_Termino.Value).ToLongDateString(); ;

                        Detallado.Cells["A1:I5"].Style.Font.Bold = true;

                        // Encabezados del reporte
                        Detallado.Cells["A1:I1"].Merge = true;
                        Detallado.Cells["A2:I2"].Merge = true;
                        Detallado.Cells["A3:I3"].Merge = true;
                        Detallado.Cells["A4:I4"].Merge = true;

                        Detallado.Cells["A1:I1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A2:I2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A3:I3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["A4:I4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                        Detallado.Cells["A1:I1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A2:I2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A3:I3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        Detallado.Cells["A4:I4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;


                        Dt_General.Columns["Folio de la venta"].SetOrdinal(0);
                        Dt_General.Columns["Fecha"].SetOrdinal(1);


                        //  se carga el archivo
                        ExcelRangeBase Rango = Detallado.Cells["A6"].LoadFromDataTable(Dt_General,
                                                       true, OfficeOpenXml.Table.TableStyles.Medium2);

                        //  formato de valores
                        Detallado.Cells[6, 2, Rango.End.Row, 2].Style.Numberformat.Format = "mm-dd-yy";
                        Detallado.Cells[6, 4, Rango.End.Row, 6].Style.Numberformat.Format = "#,##0";

                        Rango.AutoFitColumns();

                        Epc_Accesos.Save();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Exportar_Excel_Epplus]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// Filtro de Tarifas por Año
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Cmb_Anio.SelectedIndex > 0)
                {
                    DataTable Dt_Prod = (from P in Dt_Productos.AsEnumerable()
                                         where P.Field<int>("Anio") == int.Parse(Cmb_Anio.Text)
                                         select P).CopyToDataTable();

                    DataRow Seleccione = Dt_Prod.NewRow();
                    Seleccione["Nombre"] = "SELECCIONE";
                    Dt_Prod.Rows.InsertAt(Seleccione, 0);

                    Cmb_Producto.DataSource = Dt_Prod;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
