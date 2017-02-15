using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_BASE.App_Code.Negocio.Catalogos;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Categorias : Form
    {
        private string Categoria_ID;

        public Frm_Cat_Categorias()
        {
            InitializeComponent();
        }

        private void Frm_Cat_Categorias_Load(object sender, EventArgs e)
        {
            try
            {
                Cls_Cat_Categorias_Negocio Categorias = new Cls_Cat_Categorias_Negocio();

                Grd_Categorias.DataSource = Categorias.Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Nuevo.Text == "Nuevo")
                {
                    Txt_Nombre.Enabled = true;
                    Btn_Nuevo.Text = "Guardar";
                }
                else
                {
                    Cls_Cat_Categorias_Negocio Categorias = new Cls_Cat_Categorias_Negocio();

                    if (string.IsNullOrEmpty(Txt_Nombre.Text))
                    {
                        throw new Exception("Introduzca un Nombre para la Categoría");
                    }

                    Categorias.P_Nombre = Txt_Nombre.Text;
                    Categorias.Guardar();

                    MessageBox.Show("Categoría Registrada!!!", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Btn_Nuevo.Text = "Nuevo";
                    Txt_Nombre.Enabled = false;
                    Frm_Cat_Categorias_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (Btn_Modificar.Text == "Modificar")
            {
                if (Grd_Categorias.CurrentRow != null)
                {
                    Txt_Nombre.Enabled = true;
                    Grd_Categorias.Enabled = false;
                    Btn_Nuevo.Enabled = false;
                    Btn_Modificar.Text = "Guardar";
                }
            }
            else if (Btn_Modificar.Text == "Guardar")
            {
                Cls_Cat_Categorias_Negocio Categorias =
                    new Cls_Cat_Categorias_Negocio();

                Categorias.P_Categoría_ID = Grd_Categorias.CurrentRow.Cells[0].Value.ToString(); ;
                Categorias.P_Nombre = Txt_Nombre.Text;

                Categorias.Actualizar();

                MessageBox.Show("Categoría Actualizada!!!", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                Frm_Cat_Categorias_Load(null, null);
                Grd_Categorias.Enabled = true;
                Txt_Nombre.Enabled = false;
                Btn_Nuevo.Enabled = true;
                Btn_Modificar.Text = "Modificar";
            }
        }

        private void Grd_Categorias_SelectionChanged(object sender, EventArgs e)
        {
            if (Grd_Categorias.CurrentRow != null)
            {
                Txt_Nombre.Text = Grd_Categorias.CurrentRow.Cells[1].Value.ToString();
            }
        }
    }
}
