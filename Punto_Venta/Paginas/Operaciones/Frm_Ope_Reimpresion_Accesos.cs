using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Constantes;
using Operaciones.Reimpresion_Accesos.Negocio;

namespace ERP_BASE.Paginas.Operaciones
{
    public partial class Frm_Ope_Reimpresion_Accesos : Form
    {
        #region Page load
        public Frm_Ope_Reimpresion_Accesos()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos_Generales
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Consultar_Accesos
        ///DESCRIPCIÓN: Metodo que consulta la informacion de los accesos de una venta
        ///PARÁMETROS: N/A
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 13-Abril-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private DataTable Consultar_Accesos()
        {
            DataTable Dt_Consulta = new DataTable();
            Cls_Ope_Reimpresion_Accesos_Negocio Rs_Consulta = new Cls_Ope_Reimpresion_Accesos_Negocio();
            try
            {
                Rs_Consulta.P_No_Venta = (Txt_Numero_Venta.Text.Trim()).ToString();
                Dt_Consulta = Rs_Consulta.Consultar_Accesos();
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Consultar_Accesos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Dt_Consulta;
        }

        #endregion

        #region Botones
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Consultar_Venta_Click
        ///DESCRIPCIÓN: Metodo que consulta la informacion de la venta
        ///PARÁMETROS: N/A
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 13-Abril-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Consultar_Venta_Click(object sender, EventArgs e)
        {
            DataTable Dt_Consulta = new DataTable();
            try
            {
                if (!String.IsNullOrEmpty(Txt_Numero_Venta.Text))
                {
                    Dt_Consulta = Consultar_Accesos();
                    Grid_Accesos.DataSource = Dt_Consulta;
                }
                else
                {
                    MessageBox.Show("Ingresa en número de venta", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Grid_Accesos.DataSource = new DataTable();
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Btn_Consultar_Venta_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Btn_Reimprimir_Click
        ///DESCRIPCIÓN: Metodo que reimprime los accesos de una venta
        ///PARÁMETROS: N/A
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 13-Abril-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Btn_Reimprimir_Click(object sender, EventArgs e)
        {
            DataTable Dt_Consulta = new DataTable();
            Cls_Ope_Reimpresion_Accesos_Negocio Rs_Consulta = new Cls_Ope_Reimpresion_Accesos_Negocio();
            Boolean Estatus = false;
            try
            {
                if (Grid_Accesos.Rows.Count > 0)
                {
                    DialogResult Dialog_Confirmar_Accion = MessageBox.Show("Realmente deseas re imprimir los accesos", "Acción a realizar", MessageBoxButtons.YesNo);
                    if (Dialog_Confirmar_Accion == DialogResult.Yes)
                    {
                        //  se obtiene el numero de venta 
                        Rs_Consulta.P_No_Venta = Grid_Accesos.Rows[0].Cells[Ope_Accesos.Campo_No_Venta].Value.ToString();
                        Rs_Consulta.P_Serie = Grid_Accesos.Rows[0].Cells[Ope_Accesos.Campo_Serie].Value.ToString();
                        Dt_Consulta = Rs_Consulta.Consultar_Accesos();
                        Rs_Consulta.P_Dt_Accesos = Dt_Consulta;
                        

                        //  valida que este seleccionado alguno
                        foreach (DataGridViewRow Registro in Grid_Accesos.Rows)
                        {
                            DataGridViewCheckBoxCell Chk_Auxiliar = (DataGridViewCheckBoxCell)Registro.Cells[0];

                            if (Chk_Auxiliar.Value != null)
                            {
                                switch (Chk_Auxiliar.Value.ToString())
                                {
                                    case "True":
                                        Rs_Consulta.P_Grid_Accesos = Grid_Accesos;
                                        Estatus = true;
                                        break;
                                }
                            }

                            if (Estatus == true)
                                break;
                        }


                        Rs_Consulta.Realizar_Reimpresion();
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa en número de venta", "Re impresion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Btn_Reimprimir_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Text Box   
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Txt_Numero_Venta_KeyPress
        ///DESCRIPCIÓN: Metodo que permite solo numeros dentro de la caja de texto
        ///PARÁMETROS: N/A
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 13-Abril-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Txt_Numero_Venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Btn_Consultar_Venta_Click(sender, null);
                }
                //else if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                //{
                //    e.Handled = true;
                //    return;
                //}
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Btn_Reimprimir_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Grid
        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Grid_Accesos_CellContentClick
        ///DESCRIPCIÓN: Metodo que selecciona el check del grid
        ///PARÁMETROS: N/A
        ///CREO: Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO: 21-Abril-2015
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Grid_Accesos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell Check_Box_Cell = new DataGridViewCheckBoxCell();
            try
            {
                if (Grid_Accesos.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
                {
                    Check_Box_Cell = Grid_Accesos.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                    if (Check_Box_Cell.Value == null)
                        Check_Box_Cell.Value = false;
                    switch (Check_Box_Cell.Value.ToString())
                    {
                        case "True":
                            Check_Box_Cell.Value = false;
                            break;
                        case "False":
                            Check_Box_Cell.Value = true;
                            break;
                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.ToString(), "Error - Grid_Accesos_CellContentClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
