using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Reportes.Ingresos.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using CrystalDecisions.CrystalReports.Engine;
using ERP_BASE.Paginas.Catalogos.Generales;
using Erp.Constantes;
using ERP_BASE.App_Code.Reporte;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Catalogos.Turnos.Negocio;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rep_Anual_Ingresos : Form
    {
        public Frm_Rep_Anual_Ingresos()
        {
            InitializeComponent();
        }

        #region METODOS

        /// <summary>
        /// Carga los Turnos.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Turnos()
        {
            DataTable Combos;
            DataRow Fila;

            try
            {
                // Se consultan los Turnos del Catálogo de Productos
                Cls_Cat_Turnos_Negocio Turnos = new Cls_Cat_Turnos_Negocio();

                Combos = Turnos.Consultar_Turnos();
                Fila = Combos.NewRow();
                Fila[Cat_Turnos.Campo_Turno_ID] = string.Empty;
                Fila[Cat_Turnos.Campo_Nombre] = string.Empty;
                Combos.Rows.InsertAt(Fila, 0);

                Cmb_Turno.DataSource = Combos.Copy();
                Cmb_Turno.DisplayMember = Cat_Turnos.Campo_Nombre;
                Cmb_Turno.ValueMember = Cat_Turnos.Campo_Turno_ID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Carga las Cajas.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Cargar_Cajas()
        {
            DataTable Combos;
            DataRow Fila;

            try
            {
                Cls_Cat_Cajas_Negocio Cajas = new Cls_Cat_Cajas_Negocio();

                Cajas.P_Estatus = "ACTIVO";

                Combos = Cajas.Consultar_Caja();
                Fila = Combos.NewRow();
                Fila[Cat_Cajas.Campo_Caja_ID] = string.Empty;
                Fila[Cat_Cajas.Campo_Numero_Caja] = DBNull.Value;
                Combos.Rows.InsertAt(Fila, 0);

                Cmb_Numero_Caja.DataSource = Combos.Copy();
                Cmb_Numero_Caja.DisplayMember = Cat_Cajas.Campo_Numero_Caja;
                Cmb_Numero_Caja.ValueMember = Cat_Cajas.Campo_Caja_ID;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Muestra la información de las Tarifas en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Recaudacion_Tarifa()
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos;

                Neg_Ingresos = Filtros();

                Grd_Resultado.DataSource = Neg_Ingresos.Recaudación_Tarifa();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Muestra la Información de la Recaudación por Tarifa en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Recaudacion_Acumulado_Tarifa()
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos;
                DataSet Resultados;
                DataRow Totales;

                Neg_Ingresos = Filtros();
                Resultados = Neg_Ingresos.Recaudacion_Acumulado_Tarifa();

                Totales = Resultados.Tables[0].NewRow();
                Totales[0] = "Totales";

                // Se realiza la suma de los Totales por Año.
                for (int i = 1; i < Resultados.Tables[0].Columns.Count; i++)
                {
                    decimal Total = (from Aux in Resultados.Tables[0].AsEnumerable()
                                     select Aux.Field<decimal>(i)).Sum();

                    Totales[i] = Total;
                }

                Resultados.Tables[0].Rows.Add(Totales);
                Grd_Resultado.DataSource = Resultados;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Muestra la Información de la Visitanes por Tarifa en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Recaudacion_Acumulado_Visitantes()
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos;
                DataSet Resultados;
                DataRow Totales;

                Neg_Ingresos = Filtros();
                Resultados = Neg_Ingresos.Recaudacion_Acumulado_Visitantes();
                
                Totales = Resultados.Tables[0].NewRow();
                Totales[0] = "Totales";

                // Se realiza la suma de los Totales por Año.
                for (int i = 1; i < Resultados.Tables[0].Columns.Count; i++)
                {
                    Int64 Total = (from Aux in Resultados.Tables[0].AsEnumerable()
                                   select Aux.Field<Int64>(i)).Sum();

                    Totales[i] = Total;
                }

                Resultados.Tables[0].Rows.Add(Totales);

                Grd_Resultado.DataSource = Resultados;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Muestra la Información del Concentrado de Recaudación y Visitantes en pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Concentrado()
        {
            try
            {
                Cls_Rep_Ingresos_Negocio Neg_Ingresos;

                Neg_Ingresos = Filtros();

                Grd_Resultado.DataSource = Neg_Ingresos.Concentrado();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Genera la Información de los Filtros de Búsqueda.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private Cls_Rep_Ingresos_Negocio Filtros()
        {
            Cls_Rep_Ingresos_Negocio Aux = new Cls_Rep_Ingresos_Negocio();

            int Anio_Inicial = string.IsNullOrEmpty(Cmb_Anio_Inicial.Text) ? 0 : int.Parse(Cmb_Anio_Inicial.Text);
            int Anio_Final = string.IsNullOrEmpty(Cmb_Anio_Final.Text) ? 0 : int.Parse(Cmb_Anio_Final.Text);

            if (Anio_Final == 0 || Anio_Inicial == 0)
            {
                throw new Exception("Debe Seleccionar una Año de Inicio o de Fin");
            }

            Aux.P_Anio_Inicio = Anio_Inicial;
            Aux.P_Anio_Final = Anio_Final;

            if (Cmb_Turno.SelectedIndex > 0)
            {
                Aux.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();
            }

            if (Cmb_Numero_Caja.SelectedIndex > 0)
            {
                Aux.P_No_Caja = Cmb_Numero_Caja.SelectedValue.ToString();
            }

            return Aux;
        }

        private void Generar_PDF()
        {
            try
            {
                SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
                Sfd_Ruta_Archivo.Filter = "PDF(*.pdf)|*.pdf";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // Validación a la Ruta del Archivo.
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {

                    using (FileStream fs = new FileStream(Sfd_Ruta_Archivo.FileName, FileMode.Create))
                    {
                        DataTable Res = Grd_Resultado.DataSource as DataTable; // Se utilizan los datos del DataTable.
                        Document doc = new Document(PageSize.LETTER);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        PdfPTable table = new PdfPTable(Res.Columns.Count);
                        float factor = 250 / 50;
                        float[] widths = new float[Res.Columns.Count];

                        float max = (from A in Res.AsEnumerable()
                                     select A.Field<string>(0).Length).Max();

                        widths[0] = max * factor;
                        for (int i = 1; i < widths.Length; i++) { widths[i] = 55.0f; }
                        table.SetWidths(widths);
                        
                        // Options: Element.ALIGN_LEFT (or 0), Element.ALIGN_CENTER (1), Element.ALIGN_RIGHT (2).
                        table.HorizontalAlignment = Element.ALIGN_CENTER;

                        // Fuente para el Encabezado.
                        iTextSharp.text.Font fnt_Encabezados = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 5,
                                iTextSharp.text.Font.BOLD));

                        // Fuente para el Contenido.
                        iTextSharp.text.Font fnt = new iTextSharp.text.Font(FontFactory.GetFont("Arial", 5,
                                iTextSharp.text.Font.NORMAL));

                        // Se imprimen los Encabezados.
                        foreach (DataColumn Column in Res.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(Column.ColumnName,
                                fnt_Encabezados));

                            if (Column.Ordinal != 0) { cell.HorizontalAlignment = Element.ALIGN_CENTER; }

                            table.AddCell(cell);
                        }

                        table.HeaderRows = 1;

                        // Se generan los resultados.
                        foreach (DataRow Row in Res.Rows)
                        {
                            foreach (DataColumn Column in Res.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(Row[Column].ToString(),
                                    fnt));

                                if (Column.Ordinal != 0) { cell.HorizontalAlignment = Element.ALIGN_RIGHT; }

                                table.AddCell(cell);
                            }
                        }

                        doc.Add(table);
                        doc.Close();
                    }

                    MessageBox.Show("Archivo Guardado Correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion METODOS

        #region EVENTOS

        /// <summary>
        /// Punto de Entrada al Cargar la Pantalla.
        /// </summary>
        /// <creo>Héctor Gabriel Galicia Luna</creo>
        /// <fecha_creo>19 de Enero de 2016</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Frm_Rep_Anual_Ingresos_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar_Turnos();
                Cargar_Cajas();

                for (int i = 2009; i <= DateTime.Now.Year; i++)
                {
                    Cmb_Anio_Inicial.Items.Add(i);
                    Cmb_Anio_Final.Items.Add(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón buscar: llamar al método que consulta la información y 
        /// carga el resultado en el grid
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                bool Habilitar = true;
                
                // Se utiliza para limpiar los Resultados en pantalla.
                Grd_Resultado.DataSource = null;

                // Se valida la opción del Tipo de Reporte.
                switch (Cmb_Tipo_Reporte.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show("Debe Seleccionar un Tipo de Reporte.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Habilitar = false; 
                        break;

                    case 1:
                        Recaudacion_Tarifa();
                        break;

                    case 2:
                        Recaudacion_Acumulado_Tarifa();
                        break;

                    case 3:
                        Recaudacion_Acumulado_Visitantes();
                        break;

                    case 4:
                        Concentrado();
                        break;
                }

                Btn_Exportar_PDF.Enabled = Habilitar;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Buscar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************************************
        /// <summary>
        /// Manejador del evento click del botón exportar PDF: llamar al método que muestra el reporte
        /// con el resultado de la consulta
        /// </summary>
        /// <creo>Roberto González Oseguera</creo>
        /// <fecha_creo>28-may-2014</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        ///*******************************************************************************************************
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            try
            {
                Generar_PDF();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - [Exportar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion EVENTOS
    }
}
