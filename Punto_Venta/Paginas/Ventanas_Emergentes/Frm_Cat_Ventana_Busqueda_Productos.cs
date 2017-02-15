using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using ResizeableForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    public partial class Frm_Cat_Ventana_Busqueda_Productos : ResizableForm
    {
        #region (Variables)
        public string P_Producto_ID { get; set; }
        #endregion

        #region (Init/Load)
        /// <summary>
        /// Nombre: Frm_Cat_Ventana_Busqueda_Productos
        /// 
        /// Descripción: Método que carga la configuración inicial de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 13:56 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public Frm_Cat_Ventana_Busqueda_Productos()
        {
            InitializeComponent();
            //Aqui se carga el listado de los tipos de productos.
            Cargar_Tipos_Productos();
        } 
        #endregion

        #region (Metodos)
        /// <summary>
        /// Nombre: Cargar_Tipos_Productos
        /// 
        /// Descripción: Método que realiza la carga de tipos de productos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete. 
        /// Fecha Creo: 21 Noviembre 2013 13:53 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Tipos_Productos()
        {
            Cls_Cat_Productos_Negocio Obj_Productos = new Cls_Cat_Productos_Negocio();//Variable que se utilizara para realizar peticiones a la clase de datos.
            DataTable Dt_Productos = null;//Tabla para almacenar los registros de la búsqueda.

            try
            {
                //Realizamos la consulta de productos.
                Dt_Productos= Obj_Productos.Consultar_Producto();

                if (Dt_Productos is DataTable)
                {
                    var lista = Dt_Productos.AsEnumerable()
                        .Select(producto => new { tipo = producto.Field<string>(Cat_Productos.Campo_Tipo) })
                        .Distinct().ToList();

                    lista.Insert(0, new { tipo = "<-- Seleccione -->" });

                    Cmb_Tipo_Producto.DataSource = lista;
                    Cmb_Tipo_Producto.DisplayMember = "tipo";
                    Cmb_Tipo_Producto.ValueMember = "tipo";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Tipos_Productos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Grid)
        /// <summary>
        /// Nombre: Btn_Consultar_Productos_Click
        /// 
        /// Descripción: Método que realiza la consulta de productos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 12:14 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != (-1))
                {
                    if (!string.IsNullOrEmpty(Grid_Productos.Rows[e.RowIndex].Cells[Cat_Productos.Campo_Producto_Id].FormattedValue.ToString()))
                    {
                        P_Producto_ID = Grid_Productos.Rows[e.RowIndex].Cells[Cat_Productos.Campo_Producto_Id].FormattedValue.ToString();
                        this.Close();
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Grid_Productos_CellClick]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Eventos)
        /// <summary>
        /// Nombre: Btn_Consultar_Productos_Click
        /// 
        /// Descripción: Método que realiza la consulta de productos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 12:14 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Consultar_Productos_Click(object sender, EventArgs e)
        {
            Cls_Cat_Productos_Negocio Obj_Productos = new Cls_Cat_Productos_Negocio();
            DataTable Dt_Productos = null;

            try
            {
                if (!string.IsNullOrEmpty(Txt_Nombre_Producto.Text))
                    Obj_Productos.P_Nombre = Txt_Nombre_Producto.Text.Trim();
                if (Cmb_Tipo_Producto.SelectedIndex > 0)
                    Obj_Productos.P_Tipo = Cmb_Tipo_Producto.Text;

                Obj_Productos.P_Estatus = "ACTIVO";

                Dt_Productos = Obj_Productos.Consultar_Producto();

                if (Dt_Productos is DataTable)
                {
                    Grid_Productos.DataSource = Dt_Productos.AsEnumerable()
                        .Where(producto => !producto.Field<string>(Cat_Productos.Campo_Tipo_Servicio).Equals("ESTACIONAMIENTO"))
                        .OrderBy(producto => producto.Field<string>(Cat_Productos.Campo_Tipo))
                        .ThenBy(producto => producto.Field<string>(Cat_Productos.Campo_Nombre))
                        .Select(producto => new { 
                            Producto_ID = producto.Field<string>(Cat_Productos.Campo_Producto_Id),
                            Tipo = producto.Field<string>(Cat_Productos.Campo_Tipo),
                            Nombre = producto.Field<string>(Cat_Productos.Campo_Nombre),
                            Costo = producto.Field<decimal>(Cat_Productos.Campo_Costo).ToString("c")
                        }).ToList();

                    Array.ForEach(Grid_Productos.Rows.OfType<DataGridViewRow>().ToArray(), fila => {
                        fila.Height = 40; 
                        Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda => {
                            celda.Style.BackColor = Color.White;
                            celda.Style.Font = new Font("Consolas", 12, FontStyle.Regular);
                        });
                    });

                    Array.ForEach(Grid_Productos.Columns.OfType<DataGridViewColumn>().ToArray(), columna => {
                        switch (columna.HeaderText)
                        {
                            case "Producto_ID":
                                columna.Width = 0;
                                columna.Visible = false;
                                break;
                            case "Tipo":
                                columna.Width = 120;
                                break;
                            case "Nombre":
                                columna.Width = 200;
                                break;
                            case "Costo":
                                columna.Width = 100;
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            default:
                                break;
                        }
                    });
                }
                else
                    Grid_Productos.DataSource = new DataTable();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Productos_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
