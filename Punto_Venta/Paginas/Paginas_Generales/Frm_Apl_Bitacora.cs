using System;
using System.Windows.Forms;
using BitacorasAutomaticas.Tablas.Negocio;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Apl_Bitacora : Form
    {
        public Frm_Apl_Bitacora()
        {
            InitializeComponent();
        }

        private bool Edicion;
        int Valor_Original;

        #region EVENTOS

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento Load del formulario: carga del listado de tablas en la base de datos
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>21-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Frm_Apl_Bitacora_Load(object sender, EventArgs e)
        {
            try
            {
                Cls_Tablas_Negocio Tablas = new Cls_Tablas_Negocio();
                Grd_Tablas.DataSource = Tablas.Listar_Tablas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento CellClick del Grid tablas: asigna false a la bandera Edicion
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>21-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Grd_Tablas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Edicion = false;
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento CellContentClick del Grid tablas: verifica si se hizo clic en un control 
        /// dentro de la celda
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>21-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Grd_Tablas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int.TryParse(((DataGridView)sender).CurrentCell.Value.ToString(), out Valor_Original);

            try
            {
                Edicion = true;
                // validar que la celda sea de tipo DataGridViewButtonCell (contiene un botón)
                if (Grd_Tablas.CurrentCell.GetType().Equals(typeof(DataGridViewButtonCell)))
                {
                    // si el texto en el botón es Vacias, intentar realizar la operación
                    if (Grd_Tablas.Columns[e.ColumnIndex].Name == "Vaciar")
                    {
                        // si el usuario confirma el borrado de la información, llamar al método correspondiente
                        if (MessageBox.Show("¿Confirma que desea vaciar la información de la tabla?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            string Nombre_Tabla = Grd_Tablas.CurrentRow.Cells["Nombre"].Value.ToString();
                            Cls_Tablas_Negocio Tablas = new Cls_Tablas_Negocio();
                            Tablas.Vaciar_Bitacora(Nombre_Tabla);
                            // mostrar mensaje de operación exitosa
                            MessageBox.Show("La Bitácora btc_" + Nombre_Tabla + " ha sido vaciada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                Grd_Tablas.EndEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento CellEndEdit del Grid tablas: valida las operaciones en los checkbox
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>21-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Grd_Tablas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Check_Box_Servicio = ((DataGridView)sender)["Log", e.RowIndex] as DataGridViewCheckBoxCell;
            var Check_Box_Bitacora = ((DataGridView)sender)["Bitacora", e.RowIndex] as DataGridViewCheckBoxCell;

            string Tabla = ((DataGridView)sender).CurrentRow.Cells["Nombre"].Value.ToString();

            try
            {
                // validar la bandera Edicion
                if (true == Edicion)
                {
                    Cls_Tablas_Negocio Tablas = new Cls_Tablas_Negocio();
                    // realizar operación de acuerdo con el nombre de la columna seleccionada
                    switch (Grd_Tablas.Columns[e.ColumnIndex].Name)
                    {
                        case "Bitacora":
                            // validar que la tabla no sea bitácora
                            if (Tabla.StartsWith("btc_"))
                            {
                                MessageBox.Show("No se puede crear bitácora para esta tabla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Check_Box_Bitacora.Value = 0;
                                break;
                            }
                            // si se activó el checkbox bitácora, crearla y mostrar mensaje
                            if (Convert.ToInt16(Check_Box_Bitacora.Value) == 1)
                            {
                                Tablas.Crear_Bitacora(Tabla);

                                MessageBox.Show("La Bitácora btc_" + Tabla + " ha sido creada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // si no hay un Log activo para esta tabla, llamar al método que elimina la bitácora y mostrar mensaje
                                if (Convert.ToInt16(Check_Box_Servicio.Value) == 0)
                                {
                                    Tablas.Eliminar_Bitacora(Tabla);

                                    MessageBox.Show("La Bitácora btc_" + Tabla + " ha sido eliminada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else // mostrar mensaje indicando que no se puede eliminar la bitácora porque el Log está activado
                                {
                                    MessageBox.Show("No se puede eliminar la bitácora debido que tiene activado el Log.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Check_Box_Bitacora.Value = 1;
                                }
                            }
                            break;

                        case "Log":
                            // si se activó el checkbox, intentar crear el Log
                            if (Convert.ToInt16(Check_Box_Servicio.Value) == 1)
                            {
                                // validar que haya una bitácora antes de crear el Log
                                if ((Int64)Check_Box_Bitacora.Value == 1)
                                {
                                    Tablas.Crear_Servicio(Tabla);

                                    MessageBox.Show("El Log para la tabla " + Tabla + " ha sido creado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No se puede crear el Log debido a que no tiene bitácora creada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    Check_Box_Servicio.Value = 0;
                                }
                            }
                            else
                            {
                                Tablas.Eliminar_Servicio(Tabla);

                                MessageBox.Show("El Log para la tabla " + Tabla + " ha sido eliminado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                // en caso de error, regresar el checkbox a su valor anterior y mostrar mensaje de error
                ((DataGridView)sender).CurrentCell.Value = Valor_Original;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion EVENTOS
    }
}
