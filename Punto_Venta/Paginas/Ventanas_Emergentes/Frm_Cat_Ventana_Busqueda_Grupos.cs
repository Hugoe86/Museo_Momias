using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Constantes;
using ERP_BASE.App_Code.Controles;
using ERP_BASE.App_Code.Negocio.Operaciones;
using ResizeableForm;

namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    public partial class Frm_Cat_Ventana_Busqueda_Grupos : ResizableForm
    {
        #region (Variables)
        public string No_Venta { set; get; }
        public string Total { set; get; }
        public string Persona_Tramita { set; get; }
        public string Empresa { set; get; }
        public DateTime Fecha_Tramite { set; get; }
        public DateTime Fecha_Inicio_Vigencia { set; get; }
        public DateTime Fecha_Termino_Vigencia { set; get; }
        public string Aplica_Dias_Festivos { set; get; }
        public bool Hacer_Busqueda { set; get; }
        public DataTable Dt_Grupos { set; get; }
        #endregion

        #region (Controls)
        JButton Btn_Consultar;
        #endregion

        #region (Init/Load)
        /// <summary>
        /// Nombre: Frm_Cat_Ventana_Busqueda_Grupos
        /// 
        /// Descripción: Método que realiza la carga inicial de la página.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 19:16 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public Frm_Cat_Ventana_Busqueda_Grupos()
        {
            InitializeComponent();//Se inicializan la carga inicial de los controles del formulario.
            Inicializar_Controles();

            //Agregamos el evento que se ejecuta cuando se realiza la seleccion de  un elemento de la tabla de grupos.
            Grid_Grupos.CellClick += (sender, e) =>
            {
                if (e.RowIndex != (-1))
                {
                    if (!string.IsNullOrEmpty(Grid_Grupos.Rows[e.RowIndex].Cells["NO_VENTA"].FormattedValue.ToString()))
                    {
                        Cls_Ope_Grupos_Negocio Obj_Grupos = new Cls_Ope_Grupos_Negocio();
                        //Establecemos los valores que serán devueltos con los resultados de la búsqueda
                        this.No_Venta = Grid_Grupos.Rows[e.RowIndex].Cells["NO_VENTA"].FormattedValue.ToString();
                        Obj_Grupos.P_No_Venta = this.No_Venta  ;
                        this.Persona_Tramita = Grid_Grupos.Rows[e.RowIndex].Cells["PERSONA_TRAMITA"].FormattedValue.ToString();
                        this.Empresa = Grid_Grupos.Rows[e.RowIndex].Cells["EMPRESA"].FormattedValue.ToString();
                        this.Fecha_Tramite = ((MySql.Data.Types.MySqlDateTime) Grid_Grupos.Rows[e.RowIndex].Cells["FECHA_TRAMITE"].Value).GetDateTime();
                        this.Fecha_Inicio_Vigencia = ((MySql.Data.Types.MySqlDateTime)Grid_Grupos.Rows[e.RowIndex].Cells["FECHA_INICIO_VIGENCIA"].Value).GetDateTime();
                        this.Fecha_Termino_Vigencia = ((MySql.Data.Types.MySqlDateTime)Grid_Grupos.Rows[e.RowIndex].Cells["FECHA_TERMINO_VIGENCIA"].Value).GetDateTime();
                        this.Aplica_Dias_Festivos = Grid_Grupos.Rows[e.RowIndex].Cells["APLICA_DIAS_FESTIVOS"].FormattedValue.ToString();
                        this.Total = Grid_Grupos.Rows[e.RowIndex].Cells["TOTAL"].FormattedValue.ToString();
                        this.Hacer_Busqueda = true;//Establecemos que si se realizo la selección de un elemento de la tabla.
                        this.Dt_Grupos = Obj_Grupos.Consultar_Detalles_Grupo();//Se realiza la consulta del detalle del grupo seleccionado.

                        //Se válida que al seleccionar un grupo el mismo no se encuentre cancelado.
                        if (!Grid_Grupos.Rows[e.RowIndex].Cells["ESTATUS"].FormattedValue.ToString().Equals("Cancelado") &&
                            !Grid_Grupos.Rows[e.RowIndex].Cells["ESTATUS"].FormattedValue.ToString().Equals("PAGADO"))
                            this.Close();
                        else
                        {
                            this.Hacer_Busqueda = false;
                            MessageBox.Show(this, "El registro seleccionado actualmente se encuentra " +
                                Grid_Grupos.Rows[e.RowIndex].Cells["ESTATUS"].FormattedValue.ToString() + ", ya no es posible realizar movimientos.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            };
        }
        /// <summary>
        /// Nombre: Inicializar_Controles
        /// 
        /// Descripción: Metodo que inicializa los controles del formulario.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 23 Octubre 2013 23:42 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Inicializar_Controles()
        {
            this.Btn_Consultar = new JButton(global::ERP_BASE.Properties.Resources.btnbuscar, new Size(75, 26));
            this.Controls.Add(this.Btn_Consultar);
            this.Btn_Consultar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn_Consultar.Location = new System.Drawing.Point(456, 358);
            this.Btn_Consultar.Name = "Btn_Consultar";
            this.Btn_Consultar.Size = new System.Drawing.Size(75, 26);
            this.Btn_Consultar.TabIndex = 2;
            this.Btn_Consultar.UseVisualStyleBackColor = false;
            this.Btn_Consultar.Click += new System.EventHandler(this.Btn_Consultar_Click);
        }
        #endregion

        #region (Eventos)
        /// <summary>
        /// Nombre: Btn_Consultar_Click
        /// 
        /// Descripción: Método que realiza la consulta de los grupos según los filtros seleccionados.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 22 Octubre 2013 18:07 p.m.
        /// Usuario Modifico: Roberto González Oseguera
        /// Fecha Modifico: 21-feb-2014
        /// Causa modificación: Se cambia <DateTime?> por <MySql.Data.Types.MySqlDateTime?> para recibir 
        ///                     un campo fecha al utilizar una base de datos MySQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Cls_Ope_Grupos_Negocio Obj_Grupos = new Cls_Ope_Grupos_Negocio();//Variable para realizar peticiones a la clase de negocios.
            DataTable Dt_Grupos = null;//Variable que almacena los resultados de grupos segun los filtros seleccionados.

            try
            {
                //Establecer los filtros de la búsqueda de grupos.
                Grid_Grupos.DataSource = new DataTable();
                Obj_Grupos.P_Persona_Tramita = (string.IsNullOrEmpty(Txt_Persona_Tramita.Text)) ? string.Empty : Txt_Persona_Tramita.Text.Trim();
                Obj_Grupos.P_Empresa = (string.IsNullOrEmpty(Txt_Empresa.Text)) ? string.Empty : Txt_Empresa.Text.Trim();
                Obj_Grupos.P_Fecha_Inicio_Vigencia = Dtp_Fecha_Inicio.Value;
                Obj_Grupos.P_Fecha_Termino_Vigencia = Dtp_Fecha_Fin.Value;
                //Se realiza la consulta de grupos.
                Dt_Grupos = Obj_Grupos.Consultar_Grupos();

                //Cargamos la tabla con los resultados de la búsqueda de grupos.
                if (Dt_Grupos is DataTable)
                {
                    Grid_Grupos.DataSource = Dt_Grupos.AsEnumerable()
                        .Select(grupo => new
                        {
                            NO_VENTA = grupo.IsNull("No_Venta") ? string.Empty : grupo.Field<string>("No_Venta"),
                            FECHA_TRAMITE = grupo.IsNull("Fecha_Tramite") ? null : grupo.Field<MySql.Data.Types.MySqlDateTime?>("Fecha_Tramite"),
                            PERSONA_TRAMITA = grupo.IsNull("Persona_Tramita") ? string.Empty : grupo.Field<string>("Persona_Tramita"),
                            EMPRESA = grupo.IsNull("Empresa") ? string.Empty : grupo.Field<string>("Empresa"),
                            FECHA_INICIO_VIGENCIA = grupo.IsNull("Fecha_Tramite") ? null : grupo.Field<MySql.Data.Types.MySqlDateTime?>("Fecha_Inicio_Vigencia"),
                            FECHA_TERMINO_VIGENCIA = grupo.IsNull("Fecha_Tramite") ? null : grupo.Field<MySql.Data.Types.MySqlDateTime?>("Fecha_Fin_Vigencia"),
                            APLICA_DIAS_FESTIVOS = grupo.IsNull("Aplican_Dias_Festivos") ? string.Empty : grupo.Field<string>("Aplican_Dias_Festivos"),
                            TOTAL = grupo.IsNull(Ope_Ventas.Campo_Total) ? 0M : grupo.Field<decimal>(Ope_Ventas.Campo_Total),
                            ESTATUS = grupo.IsNull(Ope_Ventas.Campo_Estatus) ? string.Empty : grupo.Field<string>(Ope_Ventas.Campo_Estatus)
                        })
                        .ToList();
                }

                Array.ForEach(Grid_Grupos.Columns.OfType<DataGridViewColumn>().ToArray(), columna => {
                    columna.Visible = false;

                    switch (columna.HeaderText)
                    {
                        case "FECHA_TRAMITE":
                            columna.Visible = true;
                            columna.Width =120;
                            break;
                        case "PERSONA_TRAMITA":
                            columna.Visible = true;
                            columna.Width = 142;
                            break;
                        case "EMPRESA":
                            columna.Visible = true;
                            break;
                        case "ESTATUS":
                            columna.Visible = true;
                            break;

                        default:
                            break;
                    }
                    if (!string.IsNullOrEmpty(columna.HeaderText))
                        columna.HeaderText = columna.HeaderText.Replace("_", " ");
                });

                Array.ForEach(Grid_Grupos.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                {
                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda => { celda.Style.BackColor = Color.WhiteSmoke; celda.Style.Font = new Font("Tahoma", 9, FontStyle.Regular); });
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método:[Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Frm_Cat_Ventana_Busqueda_Grupos_FormClosed
        /// 
        /// Descripción: Método que establece que no se realizo la consulta de algún grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete
        /// Fecha Creo: 23 Octubre 2013 16:20 p.m.
        /// Usuario Modifico:
        /// FEcha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Cat_Ventana_Busqueda_Grupos_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Si no se realizo la selección de ningun elemento de la tabla de grupos habilita la bandera de aviso.
            if (!this.Hacer_Busqueda)
                this.Hacer_Busqueda = false;
        }
        #endregion
    }
}
