using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Catalogos.Turnos.Negocio;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Reportes.Ventas.Negocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ERP_BASE.Paginas.Catalogos.Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using ComponentFactory.Krypton.Toolkit;
using Erp.Metodos_Generales;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ERP_BASE.Paginas.Reportes
{
    public partial class Frm_Rpt_Reporte_Accesos : Form
    {
        DataTable Dt_Detalle;
        DataTable Dt_Productos;

        #region (Init/Load)
        /// <summary>
        /// Método que carga la configuración inical de la página.
        /// </summary>
        /// <usuario_creo>Juan  Alberto Hernández Negrete.</usuario_creo>
        /// <fecha_creo>12 Junio 2014 16:19 Hrs.</fecha_creo>
        /// <usuario_modifico></usuario_modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        public Frm_Rpt_Reporte_Accesos()
        {
            InitializeComponent();
            Configuracion_Inicial();//Habilita la configuración inicial de la página.

            //Evento que se ejecuta cuando se selecciona un elemento de la tabla de accesos.
            Grid_Resultado.CellClick += (sender, e) =>
            {
                if (e.RowIndex != (-1))
                {
                    if (!string.IsNullOrEmpty(Grid_Resultado.Rows[e.RowIndex].Cells[1].FormattedValue.ToString()))
                    {
                        if (Grid_Resultado.Rows[e.RowIndex].Cells[1].FormattedValue.ToString() != "Totales")
                        {
                            var tabla = Dt_Detalle.AsEnumerable()
                                 .Where(x => x.Field<string>("Fecha_Venta").ToString().Contains(
                                     Grid_Resultado.Rows[e.RowIndex].Cells[0].FormattedValue.ToString()))
                                 .Select(x => x);

                            if (tabla.Any())
                            {
                                Grid_Detalle_Accesos.DataSource = tabla.CopyToDataTable();
                                Grid_Detalle_Accesos.Columns[1].Visible = false;
                                //Formato_Tabla(Grid_Detalle_Accesos);
                            }
                            else
                                Grid_Detalle_Accesos.DataSource = null;
                        }
                    }
                }
            };

            //Inicializamos el tipo de reporte como concentrado.
            Cmb_Tipo_Reporte.SelectedIndex = 0;
        }
        #endregion

        #region (Métodos)
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
                Dtp_Hora_Inicio.Value = new DateTime(2000, 1, 1, 8, 0, 0, 0);
                Dtp_Hora_Fin.Value = new DateTime(2000, 1, 1, 19, 59, 59, 59);
                Cargar_Turnos();
                Consultar_Productos();

                Cmb_Anio.SelectedIndex = 0;
                Cmb_Productos.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error: Metodo(Configuracion_Inicial). Descripción:" + Ex.Message);
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
                    Dr[Cat_Turnos.Campo_Nombre] = "";
                    Dt_Turnos.Rows.InsertAt(Dr, 0);
                }
                Cmb_Turno.DataSource = Dt_Turnos;
                Cmb_Turno.ValueMember = Cat_Turnos.Campo_Turno_ID;
                Cmb_Turno.DisplayMember = Cat_Turnos.Campo_Nombre;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Cajas]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Consultar_Productos
        /// 
        /// Descripción: Método que realiza la consulta de los productos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 11 Junio 2014 12:35 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        private void Consultar_Productos()
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Ventas = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            DataTable Dt_Resultados_Busqueda = null;//Variable que utilizaremos para almacenar los resultados de la búsqueda.

            try
            {
                Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Consultar_Productos_Tipo_Acceso();
                if (Dt_Resultados_Busqueda != null)
                    if (Dt_Resultados_Busqueda.Rows.Count > 0)
                        Grid_Tarifas.DataSource = Dt_Resultados_Busqueda;


                //  se carga el combo de los productos 
                Dt_Resultados_Busqueda = Obj_Rpt_Ventas.Consultar_Productos();
                //Cmb_Productos.DataSource = Dt_Resultados_Busqueda;

                Dt_Resultados_Busqueda.Rows.RemoveAt(0);
                Dt_Productos = Dt_Resultados_Busqueda;
                Cmb_Productos.ValueMember = Cat_Productos.Campo_Producto_Id;
                Cmb_Productos.DisplayMember = Cat_Productos.Campo_Nombre;


                Formato_Tabla(Grid_Tarifas);
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los productos. Error: [" + Ex.Message + "]");
            }
        }

        /// <summary>
        /// Nombre: Generar_Consultar_DsReporte
        /// 
        /// Descripción: Método que realiza la consulta de los accesos
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 11 Junio 2014 12:35 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        private DataSet Generar_Consultar_DsReporte(String Tipo)
        {
            Cls_Rpt_Ventas_Negocio Obj_Rpt_Accesos = new Cls_Rpt_Ventas_Negocio();//Variable que utilizaremos para realizar peticiones a la clase de datos.
            Cls_Cat_Camaras_Negocio Obj_Camaras = new Cls_Cat_Camaras_Negocio();
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Consulta_Camaras = new DataTable();//Variable que utilizaremos para almacenar los resultados de la búsqueda.

            String Camaras_Entrada = "";
            String Camaras_Salidas = "";
            String Titulo_Encabezado = "";
            String[] Matriz_Hora = new String[3];
            String Str_Formato = "";
            try
            {
                ProBar_Proceso.Minimum = 0; 
                ProBar_Proceso.Value = 0;

                if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                {
                    /*  se obtienen las camaras */
                    Dt_Consulta_Camaras = Obj_Camaras.Consultar_Camaras();

                    foreach (DataRow Registro in Dt_Consulta_Camaras.Rows)
                    {
                        if (Registro[Cat_Camaras.Campo_Tipo].ToString() == "ENTRADA")
                        {
                            Camaras_Entrada += Registro[Cat_Camaras.Campo_Camara_ID].ToString() + " ,";
                        }
                        else if (Registro[Cat_Camaras.Campo_Tipo].ToString() == "SALIDA")
                        {
                            Camaras_Salidas += Registro[Cat_Camaras.Campo_Camara_ID].ToString() + " ,";
                        }
                    }

                    //  se elimina la ultima coma ,
                    if (!String.IsNullOrEmpty(Camaras_Entrada))
                        Camaras_Entrada = Camaras_Entrada.Remove(Camaras_Entrada.Length - 1);

                    if (!String.IsNullOrEmpty(Camaras_Salidas))
                        Camaras_Salidas = Camaras_Salidas.Remove(Camaras_Salidas.Length - 1);

                    //  si no existen camaras manda mensaje y no permite proceder con la consulta
                    if (String.IsNullOrEmpty(Camaras_Entrada) && String.IsNullOrEmpty(Camaras_Salidas))
                    {
                        MessageBox.Show(this, "No existen camaras a las cuales consultar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    if (!String.IsNullOrEmpty(Camaras_Entrada))
                        Obj_Rpt_Accesos.P_Camara_Entrada_Id = Camaras_Entrada;

                    if (!String.IsNullOrEmpty(Camaras_Salidas))
                        Obj_Rpt_Accesos.P_Camara_Salida_Id = Camaras_Salidas;
                }


                Grid_Resultado.DataSource = null;
                Grid_Detalle_Accesos.DataSource = null;

                //  Periodo inicial
                if (Dtp_Fecha_Inicio.Checked)
                {
                    Obj_Rpt_Accesos.P_Fecha_Inicio = new DateTime(Dtp_Fecha_Inicio.Value.Year
                        , Dtp_Fecha_Inicio.Value.Month
                        , Dtp_Fecha_Inicio.Value.Day, 0, 0, 0);

                    Titulo_Encabezado += "Periodo: ";

                    Array.ForEach(Pnl_Tipo_Reporte.Controls.OfType<RadioButton>().ToArray(), radio =>
                    {
                        if (radio.Checked)
                        {
                            switch (radio.Text)
                            {
                                case "Año":
                                    Titulo_Encabezado += "Del "  + Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("yyyy");
                                    break;
                                case "Mes":
                                    Titulo_Encabezado += "De " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("MM"))) 
                                        + " de " + Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("yyyy");
                                    break;
                                case "Dia":
                                    Titulo_Encabezado += "Del " + Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("dd")
                                        + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("MM"))) 
                                        + " de " + Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("yyyy");
                                    break;
                                case "Hora":
                                    Titulo_Encabezado += "Del " + Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("dd")
                                        + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("MM")))
                                        + " de " + Obj_Rpt_Accesos.P_Fecha_Inicio.ToString("yyyy");
                                    break;
                                default:
                                    break;
                            }
                        }
                    });


                }
                //  Periodo final
                if (Dtp_Fecha_Fin.Checked)
                {
                    Obj_Rpt_Accesos.P_Fecha_Termino = new DateTime(Dtp_Fecha_Fin.Value.Year
                       , Dtp_Fecha_Fin.Value.Month
                       , Dtp_Fecha_Fin.Value.Day, 23, 59, 59);

                    Titulo_Encabezado += " al ";

                    Array.ForEach(Pnl_Tipo_Reporte.Controls.OfType<RadioButton>().ToArray(), radio =>
                    {
                        if (radio.Checked)
                        {
                            switch (radio.Text)
                            {
                                case "Año":
                                    Titulo_Encabezado += "" + Obj_Rpt_Accesos.P_Fecha_Termino.ToString("yyyy");
                                    break;
                                case "Mes":
                                    Titulo_Encabezado += "" + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Accesos.P_Fecha_Termino.ToString("MM")))
                                        + " de " + Obj_Rpt_Accesos.P_Fecha_Termino.ToString("yyyy");
                                    break;
                                case "Dia":
                                    Titulo_Encabezado += "" + Obj_Rpt_Accesos.P_Fecha_Termino.ToString("dd")
                                        + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Accesos.P_Fecha_Termino.ToString("MM")))
                                        + " de " + Obj_Rpt_Accesos.P_Fecha_Termino.ToString("yyyy");
                                    break;
                                case "Hora":
                                    Titulo_Encabezado += "" + Obj_Rpt_Accesos.P_Fecha_Termino.ToString("dd")
                                        + " de " + Cls_Metodos_Generales.Convertir_Mes_Numerico_A_Equivalente_Texto(Convert.ToInt32(Obj_Rpt_Accesos.P_Fecha_Termino.ToString("MM")))
                                        + " de " + Obj_Rpt_Accesos.P_Fecha_Termino.ToString("yyyy");
                                    break;
                                default:
                                    break;
                            }
                        }
                    });
                }

                //  filtros para la hora inicio
                if (Dtp_Hora_Inicio.Checked)
                {
                    Obj_Rpt_Accesos.P_Hora_Inicio = Convert.ToDateTime(Dtp_Hora_Inicio.Value);

                    Titulo_Encabezado += ",  Horario: De ";
                    Titulo_Encabezado += "" + Obj_Rpt_Accesos.P_Hora_Inicio.ToString("hh:mm:ss tt");
                }

                //  filtro fora fin
                if (Dtp_Hora_Fin.Checked)
                {
                    Obj_Rpt_Accesos.P_Hora_Termino = Convert.ToDateTime(Dtp_Hora_Fin.Value);

                    Titulo_Encabezado += " a ";
                    Titulo_Encabezado += "" + Obj_Rpt_Accesos.P_Hora_Termino.ToString("hh:mm:ss tt");
                }

                //  filtro para el turno
                if (Cmb_Turno.SelectedValue.ToString() != "")
                {
                    Obj_Rpt_Accesos.P_Turno_ID = Cmb_Turno.SelectedValue.ToString();

                    Titulo_Encabezado += ", Turno: ";
                    Titulo_Encabezado += "" + Cmb_Turno.Text.ToString();
                }


                //  filtro para el producto
                if (Cmb_Productos.SelectedValue != null)
                {
                    if (Cmb_Productos.SelectedValue.ToString() != "")
                    {
                        Obj_Rpt_Accesos.P_Producto_ID = Cmb_Productos.SelectedValue.ToString();

                        Titulo_Encabezado += ", Tarifa: ";
                        Titulo_Encabezado += "" + Cmb_Productos.Text.ToString();
                    }
                }

                //  tipo de formato a usar en las consultas
                Array.ForEach(Pnl_Tipo_Reporte.Controls.OfType<RadioButton>().ToArray(), radio =>
                {
                    if (radio.Checked)
                    {
                        switch (radio.Text)
                        {
                            case "Año":
                                Obj_Rpt_Accesos.P_Formato = "%Y";
                                Obj_Rpt_Accesos.P_Tipo = "ANIO";
                                
                                break;
                            case "Mes":
                                Obj_Rpt_Accesos.P_Formato = "%Y-%m";
                                Obj_Rpt_Accesos.P_Tipo = "MES";
                                break;
                            case "Dia":
                                Obj_Rpt_Accesos.P_Formato = "%Y-%m-%d";
                                Obj_Rpt_Accesos.P_Tipo = "DIA";
                                break;
                            case "Hora":
                                Obj_Rpt_Accesos.P_Formato = "%Y-%m-%d %H";
                                Obj_Rpt_Accesos.P_Tipo = "HORA";
                                break;
                            default:
                                break;
                        }
                    }
                });

                //  se carga el tipo de reporte que sera
                Str_Formato = Obj_Rpt_Accesos.P_Tipo;

                //  filtro lugar de la venta
                if (Cmb_Lugar_Venta.Text is object)
                {
                    if (Cmb_Lugar_Venta.Text != "")
                    {
                        Obj_Rpt_Accesos.P_Lugar_Venta = Cmb_Lugar_Venta.Text;

                        Titulo_Encabezado += ", Lugar de la venta: ";

                        if (Cmb_Lugar_Venta.Text.ToString() == "No caja")
                        {
                            Titulo_Encabezado += " Numero de caja"; 
                        }
                        else
                        {
                            Titulo_Encabezado += "" + Cmb_Lugar_Venta.Text.ToString();
                        }
                    }
                }

                DataTable Dt_Dias = new DataTable();
                DataTable Dt_Ventas = new DataTable();
                DataTable Dt_Torniquete = new DataTable();
                DataTable Dt_CamaraIn = new DataTable();
                DataTable Dt_CamaraOut = new DataTable();
                DataTable Dt_Restantes = new DataTable();
                DataTable Dt_Venta_Productos = new DataTable();
                Double Db_Camara_Entrada = 0;
                Double Db_Camara_Salida = 0;

                //  se obtienen los dias a buscar
                Dt_Dias = Obj_Rpt_Accesos.Consultar_Dias_Accesos_Ventas();
                Dt_Detalle = Obj_Rpt_Accesos.Consultar_Dellates_Accesos_Ventas();

                Int32 Cont_Barra = 0;

                if (Tipo == "Exportar")
                {
                    Cont_Barra = (Dt_Dias.Rows.Count + 2);
                }
                else
                {
                    Cont_Barra = (Dt_Dias.Rows.Count + 1);
                }

                //  se inicializa la barra de progreso
                ProBar_Proceso.Minimum = 0;
                ProBar_Proceso.Maximum = Cont_Barra;
                ProBar_Proceso.Value = 0;
                ProBar_Proceso.Step = 1;

                #region Columnas
                //  se agregan las columnas las cuales mostraran la informacion previa del reporte
                Dt_Dias.Columns.Add("Fecha", typeof(System.String));
                
                if (RBtn_Hora.Checked == true)
                {
                    Dt_Dias.Columns.Add("Periodo", typeof(System.String));
                }

                Dt_Dias.Columns.Add("NO_TICKETS_VENDIDOS", typeof(System.Double));
                Dt_Dias.Columns.Add("NO_PRODUCTOS_VENDIDOS", typeof(System.Double));
                Dt_Dias.Columns.Add("NO_TICKETS_TORNIQUETE", typeof(System.Double));
                if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                {
                    Dt_Dias.Columns.Add("NO_ACCESOS_CAMARA_ENTRADA", typeof(System.Double));
                    Dt_Dias.Columns.Add("NO_ACCESOS_CAMARA_SALIDA", typeof(System.Double));
                }
                Dt_Dias.Columns.Add("ACCESOS_SIN_USAR", typeof(System.Double));
                Dt_Dias.Columns.Add("Fecha_Formato_Fecha", typeof(System.DateTime));

                if (Tipo == "Exportar")
                {
                    Dt_Dias.Columns.Add("Tipo");
                }

                #endregion

                //StringBuilder Historico = new StringBuilder();
                //  se recorren las ventas del dia
                if (Dt_Dias.Rows.Count > 0)
                {
                    foreach (DataRow Registro in Dt_Dias.Rows)
                    {
                        //Historico.AppendLine("--------------------------------");
                        //Historico.AppendLine(DateTime.Now.ToString());

                        Dt_Ventas = new DataTable();
                        Dt_Torniquete = new DataTable();
                        Dt_CamaraIn = new DataTable();
                        Dt_CamaraOut = new DataTable();
                        Dt_Restantes = new DataTable();
                        Dt_Venta_Productos = new DataTable();

                        Obj_Rpt_Accesos.P_Fecha = Registro[Obj_Rpt_Accesos.P_Tipo].ToString();//    columna hora
                        Obj_Rpt_Accesos.P_Str_Fecha_Termino = Registro[Obj_Rpt_Accesos.P_Tipo].ToString();//    columna hora

                        //  validacion para el formato de fecha por dia
                        if (RBtn_Hora.Checked == true)
                        {
                            Obj_Rpt_Accesos.P_Fecha = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + ":00:00";//    columna hora
                            Obj_Rpt_Accesos.P_Str_Fecha_Termino = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + ":59:59";//    columna hora termino
                        }
                        else if (Chk_Dia.Checked == true)
                        {
                            Obj_Rpt_Accesos.P_Fecha = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + " " + Convert.ToDateTime(Dtp_Hora_Inicio.Value).TimeOfDay.Hours + ":00:00";//    columna hora
                            Obj_Rpt_Accesos.P_Str_Fecha_Termino = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + " " + Convert.ToDateTime(Dtp_Hora_Fin.Value).TimeOfDay.Hours + ":59:59";//    columna hora termino
                        }
                        else if (Chk_Mes.Checked == true)
                        {
                            Obj_Rpt_Accesos.P_Fecha = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + "-01 00:00:00";//    columna hora
                            Obj_Rpt_Accesos.P_Str_Fecha_Termino = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + "-" + DateTime.DaysInMonth(Convert.ToDateTime(Obj_Rpt_Accesos.P_Fecha_Inicio).Year, Convert.ToInt32(Obj_Rpt_Accesos.P_Fecha.Substring(5, 2))).ToString() + " 23:59:59";//    columna hora termino
                        }
                        else if (Chk_Anio.Checked == true)
                        {
                            Obj_Rpt_Accesos.P_Fecha = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + "-01-01 00:00:00";//    columna hora
                            Obj_Rpt_Accesos.P_Str_Fecha_Termino = Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + "-12-31 23:59:59";//    columna hora
                        }

                        if (RBtn_Hora.Checked == true)
                        {
                            String Fecha_Auxiliar = "";
                            Fecha_Auxiliar = Registro[Obj_Rpt_Accesos.P_Tipo].ToString();
                            Fecha_Auxiliar = Fecha_Auxiliar.Remove(Fecha_Auxiliar.Length - 1);
                            Fecha_Auxiliar = Fecha_Auxiliar.Remove(Fecha_Auxiliar.Length - 1);

                            Registro["Fecha_Formato_Fecha"] = Convert.ToDateTime(Fecha_Auxiliar);
                        }
                        else if (Chk_Anio.Checked == true)
                        {
                            Registro["Fecha_Formato_Fecha"] = Convert.ToDateTime(Registro[Obj_Rpt_Accesos.P_Tipo].ToString() + "-01-01");
                        }
                        else
                        {
                            Registro["Fecha_Formato_Fecha"] = Convert.ToDateTime(Registro[Obj_Rpt_Accesos.P_Tipo].ToString());
                        }

                        //  validacion para la exportacion
                        if (Tipo == "Exportar")
                        {
                            Registro["Tipo"] = Registro[Obj_Rpt_Accesos.P_Tipo].ToString();
                        }

                        //  columna periodo
                        if (RBtn_Hora.Checked == true)
                        {
                            Matriz_Hora = new String[3];
                            Matriz_Hora = Registro[Obj_Rpt_Accesos.P_Tipo].ToString().Split(' ');
                            Registro["Periodo"] = Matriz_Hora[1].ToString() + ":00:00 a " + Matriz_Hora[1].ToString() + ":59:59";
                        }

                        Dt_Ventas = Obj_Rpt_Accesos.Consultar_Ventas_Accesos();
                        Registro["NO_TICKETS_VENDIDOS"] = Dt_Ventas.Rows[0][0].ToString();

                        //  torniquete
                        Dt_Torniquete = Obj_Rpt_Accesos.Consultar_Torniquete_Accesos();
                        Registro["NO_TICKETS_TORNIQUETE"] = Dt_Torniquete.Rows[0][0].ToString();

                        //  venta de productos
                        Dt_Venta_Productos = Obj_Rpt_Accesos.Consultar_Ventas_Productos_Accesos();
                        Registro["NO_PRODUCTOS_VENDIDOS"] = Dt_Venta_Productos.Rows[0][0].ToString();
                        //Registro["NO_PRODUCTOS_VENDIDOS"] = 0;

                        //if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                        //{
                        //    Db_Camara_Entrada = 0;
                        //    Db_Camara_Salida = 0;

                        //    //  camara entrada
                        //    Dt_CamaraIn = Obj_Rpt_Accesos.Consultar_CamaraIn_Acceso();
                        //    Db_Camara_Entrada = Convert.ToDouble(Dt_CamaraIn.Rows[0][0].ToString());//  se realiza el calculo de entradas vs salidas
                        //    Registro["NO_ACCESOS_CAMARA_ENTRADA"] = (Db_Camara_Entrada > 0) ? Db_Camara_Entrada.ToString() : "0";

                        //    //  camara Salida
                        //    Dt_CamaraOut = Obj_Rpt_Accesos.Consultar_CamaraOut_Acceso();
                        //    Db_Camara_Salida = Convert.ToDouble(Dt_CamaraOut.Rows[0][0].ToString());//  se realiza el calculo de salidas vs entradas
                        //    Registro["NO_ACCESOS_CAMARA_SALIDA"] = (Db_Camara_Salida > 0) ? Db_Camara_Salida.ToString() : "0";
                        //}

                        //  Restantes
                        Dt_Restantes = Obj_Rpt_Accesos.Consultar_Restantes_Ventas_Acceso();
                        Registro["ACCESOS_SIN_USAR"] = Dt_Restantes.Rows[0][0].ToString();

                        ProBar_Proceso.PerformStep();
                        ProBar_Proceso.Refresh();

                    }
                }

                //Historico.AppendLine("Fin");

                #region Totales
                var Datos_Venta = Dt_Dias;

                //  validacion para la informacion de las camaras
                if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                {
                    if (Datos_Venta != null && Datos_Venta.Rows.Count > 0)
                    {

                        if (Datos_Venta.Rows.Count > 0)
                            Datos_Venta = Datos_Venta.AsEnumerable().Where(fila =>
                                fila.Field<Double>("NO_TICKETS_VENDIDOS") > 0 ||
                                fila.Field<Double>("NO_TICKETS_TORNIQUETE") > 0 ||
                                fila.Field<Double>("NO_ACCESOS_CAMARA_ENTRADA") > 0 ||
                                fila.Field<Double>("NO_ACCESOS_CAMARA_SALIDA") > 0 ||
                                fila.Field<Double>("NO_PRODUCTOS_VENDIDOS") > 0 ||
                                fila.Field<Double>("ACCESOS_SIN_USAR") > 0).CopyToDataTable();

                        if (Datos_Venta.Rows.Count > 0)
                            Datos_Venta = Datos_Venta.AsEnumerable().Where(x => !string.IsNullOrEmpty(x.Field<string>(Obj_Rpt_Accesos.P_Tipo))).CopyToDataTable();



                        if (Datos_Venta != null && Datos_Venta.Rows.Count > 0)
                        {
                            if (Tipo == "")//   validamos que sea para mostrar en pantalla
                            {
                                var fila_totales = Datos_Venta.NewRow();
                                fila_totales[Obj_Rpt_Accesos.P_Tipo] = "Totales";
                                fila_totales["Fecha"] = "Totales";
                                fila_totales["NO_TICKETS_VENDIDOS"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_TICKETS_VENDIDOS"));
                                fila_totales["NO_TICKETS_TORNIQUETE"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_TICKETS_TORNIQUETE"));
                                fila_totales["NO_PRODUCTOS_VENDIDOS"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_PRODUCTOS_VENDIDOS"));                                
                                fila_totales["NO_ACCESOS_CAMARA_ENTRADA"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_ACCESOS_CAMARA_ENTRADA"));
                                fila_totales["NO_ACCESOS_CAMARA_SALIDA"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_ACCESOS_CAMARA_SALIDA"));
                                fila_totales["ACCESOS_SIN_USAR"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("ACCESOS_SIN_USAR"));
                                Datos_Venta.Rows.Add(fila_totales);
                            }
                        }
                    }
                }
                else
                {
                    if (Datos_Venta != null && Datos_Venta.Rows.Count > 0)
                    {

                        if (Datos_Venta.Rows.Count > 0)
                            Datos_Venta = Datos_Venta.AsEnumerable().Where(fila =>
                                fila.Field<Double>("NO_TICKETS_VENDIDOS") > 0 ||
                                fila.Field<Double>("NO_TICKETS_TORNIQUETE") > 0 ||
                                fila.Field<Double>("NO_PRODUCTOS_VENDIDOS") > 0 ||
                                fila.Field<Double>("ACCESOS_SIN_USAR") > 0).CopyToDataTable();

                        if (Datos_Venta.Rows.Count > 0)
                            Datos_Venta = Datos_Venta.AsEnumerable().Where(x => !string.IsNullOrEmpty(x.Field<string>(Obj_Rpt_Accesos.P_Tipo))).CopyToDataTable();



                        if (Datos_Venta != null && Datos_Venta.Rows.Count > 0)
                        {
                            if (Tipo == "")//   validamos que sea para mostrar en pantalla
                            {
                                var fila_totales = Datos_Venta.NewRow();
                                fila_totales[Obj_Rpt_Accesos.P_Tipo] = "Totales";
                                fila_totales["Fecha"] = "Totales";
                                fila_totales["NO_TICKETS_VENDIDOS"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_TICKETS_VENDIDOS"));
                                fila_totales["NO_PRODUCTOS_VENDIDOS"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_PRODUCTOS_VENDIDOS")); 
                                fila_totales["NO_TICKETS_TORNIQUETE"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("NO_TICKETS_TORNIQUETE"));
                                fila_totales["ACCESOS_SIN_USAR"] = Datos_Venta.AsEnumerable().Sum(x => x.Field<Double>("ACCESOS_SIN_USAR"));
                                Datos_Venta.Rows.Add(fila_totales);
                            }
                        }

                    }
                }
                #endregion Totales

                #region (Datos Generales)
                var Datos_Generales = new DataTable();
                Datos_Generales.Columns.Add("Usuario_Creo", typeof(string));
                Datos_Generales.Columns.Add("Fecha_Creo", typeof(string));
                Datos_Generales.Columns.Add("Periodo_Reporte", typeof(string));
                Datos_Generales.Columns.Add("Formato", typeof(string));
                
                //  se agregan los datos generales
                var Registro_Generales = Datos_Generales.NewRow();
                Registro_Generales["Usuario_Creo"] = MDI_Frm_Apl_Principal.Nombre_Usuario;
                Registro_Generales["Fecha_Creo"] = string.Format("{0:dd MMMM yyyy HH:mm:ss tt}", DateTime.Now);
                Registro_Generales["Formato"] = Str_Formato;
                
                //if (Obj_Rpt_Accesos.P_Fecha_Inicio.Year != 1 && Obj_Rpt_Accesos.P_Fecha_Termino.Year != 1)
                //    Registro_Generales["Periodo_Reporte"] = (string.Format("{0:dd MMMM yyyy}", Obj_Rpt_Accesos.P_Fecha_Inicio) + " al " + string.Format("{0:dd MMMM yyyy}", Obj_Rpt_Accesos.P_Fecha_Termino)).ToUpper();
                //else
                //    Registro_Generales["Periodo_Reporte"] = string.Empty;

                Registro_Generales["Periodo_Reporte"] = Titulo_Encabezado;

                Datos_Generales.Rows.Add(Registro_Generales);
                #endregion

                #region Formato de fecha
                //  se quita la hora de la columna de hora, solo si es filtro de hora
                if (RBtn_Hora.Checked == true || Chk_Dia.Checked == true)
                {
                    foreach (DataRow Registro_Hora in Datos_Venta.Rows)
                    {
                        Registro_Hora.BeginEdit();

                        Matriz_Hora = new String[3];

                        if (Registro_Hora[Obj_Rpt_Accesos.P_Tipo].ToString() != "Totales")
                        {
                            Matriz_Hora = Registro_Hora[Obj_Rpt_Accesos.P_Tipo].ToString().Split(' ');
                            Registro_Hora["Fecha"] = Convert.ToDateTime(Matriz_Hora[0].ToString()).ToString("dd/MM/yyyy");
                        }

                        Registro_Hora.EndEdit();
                        Datos_Venta.AcceptChanges();
                    }
                }
                else if (Chk_Mes.Checked == true)
                {
                    foreach (DataRow Registro_Hora in Datos_Venta.Rows)
                    {
                        Registro_Hora.BeginEdit();

                        Matriz_Hora = new String[3];

                        if (Registro_Hora[Obj_Rpt_Accesos.P_Tipo].ToString() != "Totales")
                        {
                            Matriz_Hora = Registro_Hora[Obj_Rpt_Accesos.P_Tipo].ToString().Split(' ');
                            Registro_Hora["Fecha"] = Convert.ToDateTime(Matriz_Hora[0].ToString() + "-01").ToString("MM/yyyy");
                        }

                        Registro_Hora.EndEdit();
                        Datos_Venta.AcceptChanges();
                    }
                }
                else // año
                {
                    foreach (DataRow Registro_Hora in Datos_Venta.Rows)
                    {
                        Registro_Hora.BeginEdit();

                        Matriz_Hora = new String[3];

                        if (Registro_Hora[Obj_Rpt_Accesos.P_Tipo].ToString() != "Totales")
                        {
                            Matriz_Hora = Registro_Hora[Obj_Rpt_Accesos.P_Tipo].ToString().Split(' ');
                            Registro_Hora["Fecha"] = Convert.ToDateTime(Matriz_Hora[0].ToString() + "-01-01").ToString("yyyy");
                        }

                        Registro_Hora.EndEdit();
                        Datos_Venta.AcceptChanges();
                    }
                }

                #endregion
                
                ProBar_Proceso.PerformStep();
                ProBar_Proceso.Refresh(); 

                Datos_Venta.TableName = "Accesos";
                Dt_Detalle.TableName = "Detalle";
                Datos_Generales.TableName = "Datos_Generales";
                Ds_Resultados_Busqueda.Tables.Add(Datos_Venta.Copy());
                Ds_Resultados_Busqueda.Tables.Add(Dt_Detalle.Copy());
                Ds_Resultados_Busqueda.Tables.Add(Datos_Generales.Copy());

            }
            catch (Exception Ex)
            {
                throw new Exception("Error al consultar los productos. Error: [" + Ex.Message + "]");
            }

            return Ds_Resultados_Busqueda;
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
                    //columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //if (columna.ValueType.Name.Equals("DateTime"))
                    //    columna.DefaultCellStyle.Format = "dd MMM yyyy";
                    //else if (columna.ValueType.Name.Equals("Decimal") && !columna.HeaderText.Equals("Total Productos")
                    //    && !columna.HeaderText.Equals("Total Accesos") && !columna.HeaderText.Equals("Visitantes"))
                    //    columna.DefaultCellStyle.Format = "c";

                    //if (columna.HeaderText.Equals("ANIO")||
                    //    columna.HeaderText.Equals("MES")||
                    //    columna.HeaderText.Equals("DIA")||
                    //    columna.HeaderText.Equals("HORA") ||
                    //    columna.HeaderText.Equals("PERIODO"))
                    //{
                    //    columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //    columna.Width = 170;
                    //}

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
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Accesos = new DataTable();
            try
            {
                Ds_Resultados_Busqueda = Generar_Consultar_DsReporte("");

                //  se carga la informacion en el grid
                if (Ds_Resultados_Busqueda.Tables["Accesos"] is DataTable)
                {
                    if (Ds_Resultados_Busqueda.Tables["Accesos"].Rows.Count > 0)
                    {
                        Dt_Accesos = Ds_Resultados_Busqueda.Tables["Accesos"];

                        if (RBtn_Hora.Checked == true)
                        {
                            if (Chk_Mostrar_Informacion_Camaras.Checked == false)
                            {
                                Dt_Accesos.Columns[3].ColumnName = "No. Tickets vendidos";
                                Dt_Accesos.Columns[4].ColumnName = "No. Servicios vendidos";
                                Dt_Accesos.Columns[5].ColumnName = "No. Tickets escaneados por torniquete";
                                Dt_Accesos.Columns[6].ColumnName = "Accesos sin usar";
                            }
                            else
                            {
                                Dt_Accesos.Columns[3].ColumnName = "No. Tickets vendidos";
                                Dt_Accesos.Columns[4].ColumnName = "No. Servicios vendidos";
                                Dt_Accesos.Columns[5].ColumnName = "No. Tickets escaneados por torniquete";
                                Dt_Accesos.Columns[6].ColumnName = "No. personas que entraron contadas con camara";
                                Dt_Accesos.Columns[7].ColumnName = "No. personas que salieron contadas con camara";
                                Dt_Accesos.Columns[8].ColumnName = "Accesos sin usar";
                            }

                            Grid_Resultado.DataSource = Dt_Accesos;
                            //  se da formato al grid
                            Formato_Tabla(Grid_Resultado);

                            if (Chk_Mostrar_Informacion_Camaras.Checked == false)
                            {
                                Grid_Resultado.Columns[7].Visible = false;
                                Grid_Resultado.Columns[0].Visible = false;
                            }
                            else
                            {
                                Grid_Resultado.Columns[9].Visible = false;
                                Grid_Resultado.Columns[0].Visible = false;
                            }
                        }
                        else
                        {
                            if (Chk_Mostrar_Informacion_Camaras.Checked == false)
                            {
                                Dt_Accesos.Columns[2].ColumnName = "No. Tickets vendidos";
                                Dt_Accesos.Columns[3].ColumnName = "No. Servicios vendidos";
                                Dt_Accesos.Columns[4].ColumnName = "No. Tickets escaneados por torniquete";
                                Dt_Accesos.Columns[5].ColumnName = "Accesos sin usar";
                            }
                            else
                            {
                                Dt_Accesos.Columns[2].ColumnName = "No. Tickets vendidos";
                                Dt_Accesos.Columns[3].ColumnName = "No. Servicios vendidos";
                                Dt_Accesos.Columns[4].ColumnName = "No. Tickets escaneados por torniquete";
                                Dt_Accesos.Columns[5].ColumnName = "No. personas que entraron contadas con camara";
                                Dt_Accesos.Columns[6].ColumnName = "No. personas que salieron contadas con camara";
                                Dt_Accesos.Columns[7].ColumnName = "Accesos sin usar";
                            }



                            Grid_Resultado.DataSource = Dt_Accesos;
                            //  se da formato al grid
                            Formato_Tabla(Grid_Resultado);

                            if (Chk_Mostrar_Informacion_Camaras.Checked == false)
                            {
                                Grid_Resultado.Columns[6].Visible = false;
                                Grid_Resultado.Columns[0].Visible = false;
                            }
                            else
                            {
                                Grid_Resultado.Columns[8].Visible = false;
                                Grid_Resultado.Columns[0].Visible = false;
                            }
                        }
                    }
                    else
                    {
                        Grid_Resultado.DataSource = new DataTable();
                        MessageBox.Show("No se encontraron resultados con la búsqueda realizada.", "Información");
                    }
                }
                else
                {
                    Grid_Resultado.DataSource = new DataTable();
                    MessageBox.Show("No se encontraron resultados con la búsqueda realizada.", "Información");
                }

                Ktc_Rpt_Accesos.SelectedTab = Tab_Accesos;

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
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 05 22 09:50 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Exportar_PDF_Click(object sender, EventArgs e)
        {
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.

            DataRow Dr_Registro;
            Double Ventas = 0;
            Double Torniquete = 0;
            Double Acceso = 0;
            Double Salida = 0;
            int Cont_Registros = 0;
            
            try
            {
                Ds_Resultados_Busqueda = Generar_Consultar_DsReporte("Exportar");

                DataTable Dt_Totales = new DataTable();
                Dt_Totales.TableName = "Dt_Totales";
                Dt_Totales.Columns.Add("Total_Ventas", typeof(System.Double));
                Dt_Totales.Columns.Add("Promedio_Ventas", typeof(System.Double));
                Dt_Totales.Columns.Add("Total_Torniquete", typeof(System.Double));
                Dt_Totales.Columns.Add("Promedio_Torniquete", typeof(System.Double));
                Dt_Totales.Columns.Add("Total_Acceso", typeof(System.Double));
                Dt_Totales.Columns.Add("Promedio_Accesos", typeof(System.Double));
                Dt_Totales.Columns.Add("Total_Salidas", typeof(System.Double));
                Dt_Totales.Columns.Add("Promedio_Salidas", typeof(System.Double));


                foreach (DataRow Registro in Ds_Resultados_Busqueda.Tables["Accesos"].Rows)
                {
                    Cont_Registros++;
                    Ventas = Ventas + Convert.ToDouble(Registro["NO_TICKETS_VENDIDOS"].ToString());
                    Torniquete = Torniquete + Convert.ToDouble(Registro["NO_TICKETS_TORNIQUETE"].ToString());

                    if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                    {
                        Acceso = Acceso + Convert.ToDouble(Registro["NO_ACCESOS_CAMARA_ENTRADA"].ToString());
                        Salida = Salida + Convert.ToDouble(Registro["NO_ACCESOS_CAMARA_SALIDA"].ToString());
                    }
                }

                Dr_Registro = Dt_Totales.NewRow();
                Dr_Registro["Total_Ventas"] = Ventas;
                Dr_Registro["Promedio_Ventas"] = Ventas / Cont_Registros;
                Dr_Registro["Total_Torniquete"] = Torniquete;
                Dr_Registro["Promedio_Torniquete"] = Torniquete / Cont_Registros;
                if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                {
                    Dr_Registro["Total_Acceso"] = Acceso;
                    Dr_Registro["Promedio_Accesos"] = Acceso / Cont_Registros; ;
                    Dr_Registro["Total_Salidas"] = Salida;
                    Dr_Registro["Promedio_Salidas"] = Salida / Cont_Registros;
                }

                Dt_Totales.Rows.Add(Dr_Registro);
                Dt_Totales.AcceptChanges();

                Ds_Resultados_Busqueda.Tables.Add(Dt_Totales);

                if (Ds_Resultados_Busqueda.Tables["Accesos"].Rows.Count > 0)
                {
                    String Tipo_Reporte = "";

                    //  se valida que tipo de reporte se mostrara
                    if (Cmb_Tipo_Reporte.SelectedItem.ToString() == "Detallado")
                    {
                        Tipo_Reporte = "Cr_Rpt_Accesos_Detalle.rpt";
                    }
                    else
                    {
                        if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                        {
                            Tipo_Reporte = "Cr_Rpt_Accesos.rpt";
                        }
                        else
                        {
                            Tipo_Reporte = "Cr_Rpt_Accesos_Sin_Conteo.rpt"; 
                        }
                    }

                    ProBar_Proceso.PerformStep();
                    ProBar_Proceso.Refresh();

                    Generar_Reporte(ref Ds_Resultados_Busqueda, MDI_Frm_Apl_Principal.Ruta_Plantilla_Crystal + Tipo_Reporte);
                }
                else
                {
                    MessageBox.Show("No se encontraron resultados con la búsqueda realizada.", "Información");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_PDF_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Btn_Exportar_Excel_Click(object sender, EventArgs e)
        {
            DataSet Ds_Resultados_Busqueda = new DataSet();//Variable que utilizaremos para almacenar los resultados de la búsqueda.
            DataTable Dt_Concentrado = new DataTable();
            DataTable Dt_Detallado = new DataTable();
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            DataTable Dt_General = new DataTable();
            String Str_Encabezado_Reporte = "";

            try
            {
                //  se obtiene el tipo de reporte que se pondra en el encabezado principal
                if (RBtn_Hora.Checked == true)
                {
                    Str_Encabezado_Reporte = "Hora";
                }
                else if (Chk_Dia.Checked == true)
                {
                    Str_Encabezado_Reporte = "Dia";
                }
                else if (Chk_Mes.Checked == true)
                {
                    Str_Encabezado_Reporte = "Mes ";
                }
                else
                {
                    Str_Encabezado_Reporte = "Año";
                }


                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName))
                    {
                        File.Delete(Sfd_Ruta_Archivo.FileName);
                    }

                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    #region Consulta

                    Ds_Resultados_Busqueda = Generar_Consultar_DsReporte("");

                    #endregion
                    #region Concentrado

                    if (Cmb_Tipo_Reporte.SelectedItem.ToString() != "Detallado")//  concentrado
                    {
                        Dt_General = Ds_Resultados_Busqueda.Tables["Datos_Generales"];
                        Dt_Concentrado = Ds_Resultados_Busqueda.Tables["ACCESOS"];

                        if (Dt_Concentrado.Rows.Count > 0)
                        {
                            //  tabla para el concentrado de accesos
                            Dt_Concentrado.Rows.RemoveAt(Dt_Concentrado.Rows.Count - 1);
                            Dt_Concentrado.Columns[1].ColumnName = "Fecha__";


                            if (RBtn_Hora.Checked == true)
                            {
                                if (Chk_Mostrar_Informacion_Camaras.Checked == false)
                                {
                                    Dt_Concentrado.Columns[7].ColumnName = "Fecha";
                                    Dt_Concentrado.Columns[2].ColumnName = "Periodo de tiempo";
                                    Dt_Concentrado.Columns.RemoveAt(0);
                                    Dt_Concentrado.Columns.RemoveAt(0);

                                    //  formato a las columnas
                                    Dt_Concentrado.Columns[1].ColumnName = "No. Tickets vendidos";
                                    Dt_Concentrado.Columns[2].ColumnName = "No. Servicios vendidos (Camaras)";
                                    Dt_Concentrado.Columns[3].ColumnName = "No. Tickets escaneados por torniquete";
                                    Dt_Concentrado.Columns[4].ColumnName = "Accesos sin utilizar";
                                }
                                else
                                {
                                    Dt_Concentrado.Columns[9].ColumnName = "Fecha";
                                    Dt_Concentrado.Columns[2].ColumnName = "Periodo de tiempo";
                                    Dt_Concentrado.Columns.RemoveAt(0);
                                    Dt_Concentrado.Columns.RemoveAt(0);

                                    Dt_Concentrado.Columns[1].ColumnName = "No. Tickets vendidos";
                                    Dt_Concentrado.Columns[2].ColumnName = "No. Servicios vendidos (Camaras)";
                                    Dt_Concentrado.Columns[3].ColumnName = "No. Tickets escaneados por torniquete";
                                    Dt_Concentrado.Columns[4].ColumnName = "No. personas que entraron contadas con camara";
                                    Dt_Concentrado.Columns[5].ColumnName = "No. personas que salieron contadas con camara";
                                    Dt_Concentrado.Columns[6].ColumnName = "Accesos sin utilizar";


                                    Dt_Concentrado.Columns["Fecha"].SetOrdinal(0);
                                    Dt_Concentrado.Columns["Periodo de tiempo"].SetOrdinal(1);
                                    Dt_Concentrado.Columns["No. Tickets vendidos"].SetOrdinal(2);
                                    Dt_Concentrado.Columns["No. Servicios vendidos (Camaras)"].SetOrdinal(3); 
                                    Dt_Concentrado.Columns["No. Tickets escaneados por torniquete"].SetOrdinal(4);
                                    Dt_Concentrado.Columns["Accesos sin utilizar"].SetOrdinal(5);
                                    Dt_Concentrado.Columns["No. personas que entraron contadas con camara"].SetOrdinal(6);
                                    Dt_Concentrado.Columns["No. personas que salieron contadas con camara"].SetOrdinal(7);
                                }

                            }
                            else
                            {
                                if (Chk_Mostrar_Informacion_Camaras.Checked == false)
                                {
                                    Dt_Concentrado.Columns[6].ColumnName = "Fecha";
                                    Dt_Concentrado.Columns.RemoveAt(0);
                                    Dt_Concentrado.Columns.RemoveAt(0);

                                    //  formato a las columnas
                                    Dt_Concentrado.Columns[0].ColumnName = "No. Tickets vendidos";
                                    Dt_Concentrado.Columns[1].ColumnName = "No. Servicios vendidos (Camaras)";
                                    Dt_Concentrado.Columns[2].ColumnName = "No. Tickets escaneados por torniquete";
                                    Dt_Concentrado.Columns[3].ColumnName = "Accesos sin utilizar";
                                }
                                else
                                {
                                    Dt_Concentrado.Columns[8].ColumnName = "Fecha";
                                    Dt_Concentrado.Columns.RemoveAt(0);
                                    Dt_Concentrado.Columns.RemoveAt(0);

                                    //  formato a las columnas
                                    Dt_Concentrado.Columns[0].ColumnName = "No. Tickets vendidos";
                                    Dt_Concentrado.Columns[1].ColumnName = "No. Servicios vendidos (Camaras)";
                                    Dt_Concentrado.Columns[2].ColumnName = "No. Tickets escaneados por torniquete";
                                    Dt_Concentrado.Columns[3].ColumnName = "No. personas que entraron contadas con camara";
                                    Dt_Concentrado.Columns[4].ColumnName = "No. personas que salieron contadas con camara";
                                    Dt_Concentrado.Columns[5].ColumnName = "Accesos sin utilizar";

                                    Dt_Concentrado.Columns["Fecha"].SetOrdinal(0);
                                    Dt_Concentrado.Columns["No. Tickets vendidos"].SetOrdinal(1);
                                    Dt_Concentrado.Columns["No. Servicios vendidos (Camaras)"].SetOrdinal(2);
                                    Dt_Concentrado.Columns["No. Tickets escaneados por torniquete"].SetOrdinal(3);
                                    Dt_Concentrado.Columns["Accesos sin utilizar"].SetOrdinal(4);
                                    Dt_Concentrado.Columns["No. personas que entraron contadas con camara"].SetOrdinal(5);
                                    Dt_Concentrado.Columns["No. personas que salieron contadas con camara"].SetOrdinal(6);
                                }
                            }


                            using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                            {
                                ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Accesos");

                                Dt_Concentrado.Columns["Fecha"].SetOrdinal(0);

                                Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                                Detallado.Cells["A2"].Value = "Dirección de ingresos";
                                Detallado.Cells["A3"].Value = "Museo de las momias";
                                Detallado.Cells["A4"].Value = Dt_General.Rows[0]["Periodo_Reporte"].ToString();
                                Detallado.Cells["A6"].Value = "Reporte de accesos (detalle por " + Str_Encabezado_Reporte + ")";

                                Detallado.Cells["A1:A1"].Style.Font.Bold = true;
                                Detallado.Cells["A3:A6"].Style.Font.Bold = true;


                                //  formato de numero
                                if (RBtn_Hora.Checked == true)
                                {
                                    // Encabezados del reporte
                                    Detallado.Cells["A1:F1"].Merge = true;
                                    Detallado.Cells["A2:F2"].Merge = true;
                                    Detallado.Cells["A3:F3"].Merge = true;
                                    Detallado.Cells["A4:F4"].Merge = true;
                                    Detallado.Cells["A6:F6"].Merge = true;

                                    Detallado.Cells["A1:F1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A2:F2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A3:F3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A4:F4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A6:F6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                    Detallado.Cells["A1:F1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A2:F2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A3:F3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A4:F4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A6:F6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                }
                                else
                                {
                                    // Encabezados del reporte
                                    Detallado.Cells["A1:E1"].Merge = true;
                                    Detallado.Cells["A2:E2"].Merge = true;
                                    Detallado.Cells["A3:E3"].Merge = true;
                                    Detallado.Cells["A4:E4"].Merge = true;
                                    Detallado.Cells["A6:E6"].Merge = true;

                                    Detallado.Cells["A1:E1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A2:E2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A3:E3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A4:E4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A6:E6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                    Detallado.Cells["A1:E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A2:E2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A3:E3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A4:E4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A6:E6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                }

                                //***************************************************************************************
                                //  se carga el archivo
                                ExcelRangeBase Rango = Detallado.Cells["A7"].LoadFromDataTable(Dt_Concentrado, true, OfficeOpenXml.Table.TableStyles.Medium2);
                                //***************************************************************************************

                                //  formato de fecha
                                Detallado.Cells[7, 1, Rango.End.Row, 1].Style.Numberformat.Format = "mm-dd-yy";

                                Int32 Filas = 0;

                                //  formato de numero
                                if (RBtn_Hora.Checked == true)
                                {

                                    Detallado.Cells[7, 3, Rango.End.Row, 6].Style.Numberformat.Format = "#,##0";

                                    if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                                    {
                                        Detallado.Cells[7, 7, Rango.End.Row, 8].Style.Numberformat.Format = "#,##0";
                                    }

                                    //  subtotales de la tabla
                                    Filas = Filas + 7 + Dt_Concentrado.Rows.Count;
                                    Detallado.Cells["C" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. Tickets vendidos] )");
                                    Detallado.Cells["D" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. Servicios vendidos (Camaras)] )");
                                    Detallado.Cells["E" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. Tickets escaneados por torniquete]) ");
                                    Detallado.Cells["F" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[Accesos sin utilizar])");
                                    
                                    if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                                    {
                                        Detallado.Cells["G" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. personas que entraron contadas con camara])");
                                        Detallado.Cells["H" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. personas que salieron contadas con camara])");
                                        Detallado.Cells[(Filas + 1), 8, (Filas + 1), 9].Style.Numberformat.Format = "#,##0";
                                        Detallado.Cells["G" + (Filas + 1) + ":H" + (Filas + 1)].Style.Font.Bold = true;
                                    }
                                    
                                    Detallado.Cells["C" + (Filas + 1) + ":F" + (Filas + 1)].Style.Font.Bold = true;
                                    Detallado.Cells[(Filas + 1), 3, (Filas + 1), 7].Style.Numberformat.Format = "#,##0";

                                    //  promedio
                                    Detallado.Cells["B" + (Filas + 3)].Value = "Promedio por " + Str_Encabezado_Reporte + "";
                                    Detallado.Cells["C" + (Filas + 3)].Formula = String.Format("C" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["D" + (Filas + 3)].Formula = String.Format("D" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["E" + (Filas + 3)].Formula = String.Format("E" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["F" + (Filas + 3)].Formula = String.Format("F" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["B" + (Filas + 3) + ":F" + (Filas + 3)].Style.Font.Bold = true;
                                    Detallado.Cells[(Filas + 3), 3, (Filas + 3), 7].Style.Numberformat.Format = "#,##0";

                                    if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                                    {
                                        Detallado.Cells["G" + (Filas + 3)].Formula = String.Format("G" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                        Detallado.Cells["H" + (Filas + 3)].Formula = String.Format("H" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                        Detallado.Cells["B" + (Filas + 3) + ":F" + (Filas + 3)].Style.Font.Bold = true; 
                                        Detallado.Cells[(Filas + 3), 8, (Filas + 3), 9].Style.Numberformat.Format = "#,##0";
                                    }

                                    Filas = Filas + 4;
                                }
                                else
                                {
                                    Detallado.Cells[7, 2, Rango.End.Row, 5].Style.Numberformat.Format = "#,##0";

                                    if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                                    {
                                        Detallado.Cells[7, 6, Rango.End.Row, 7].Style.Numberformat.Format = "#,##0";
                                    }

                                    Filas = Filas + 7 + Dt_Concentrado.Rows.Count;
                                    Detallado.Cells["B" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. Tickets vendidos] )");
                                    Detallado.Cells["C" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. Servicios vendidos (Camaras)] )");
                                    Detallado.Cells["D" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. Tickets escaneados por torniquete]) ");
                                    Detallado.Cells["E" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[Accesos sin utilizar])");

                                    Detallado.Cells["B" + (Filas + 1) + ":E" + (Filas + 1)].Style.Font.Bold = true;
                                    Detallado.Cells[(Filas + 1), 2, (Filas + 1), 6].Style.Numberformat.Format = "#,##0";

                                    if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                                    {
                                        Detallado.Cells["F" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. personas que entraron contadas con camara])");
                                        Detallado.Cells["G" + (Filas + 1)].Formula = string.Format("SUBTOTAL(109, Accesos[No. personas que salieron contadas con camara])");
                                        Detallado.Cells["F" + (Filas + 1) + ":G" + (Filas + 1)].Style.Font.Bold = true;
                                        Detallado.Cells[(Filas + 1), 7, (Filas + 1), 8].Style.Numberformat.Format = "#,##0";
                                    }

                                    //  promedio
                                    Detallado.Cells["A" + (Filas + 3)].Value = "Promedio por " + Str_Encabezado_Reporte + "";
                                    Detallado.Cells["B" + (Filas + 3)].Formula = String.Format("B" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["C" + (Filas + 3)].Formula = String.Format("C" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["D" + (Filas + 3)].Formula = String.Format("D" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["E" + (Filas + 3)].Formula = String.Format("E" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                    Detallado.Cells["A" + (Filas + 3) + ":E" + (Filas + 3)].Style.Font.Bold = true;
                                    Detallado.Cells[(Filas + 3), 3, (Filas + 3), 7].Style.Numberformat.Format = "#,##0";

                                    if (Chk_Mostrar_Informacion_Camaras.Checked == true)
                                    {
                                        Detallado.Cells["F" + (Filas + 3)].Formula = String.Format("F" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                        Detallado.Cells["G" + (Filas + 3)].Formula = String.Format("G" + (Filas + 1) + "/" + (Dt_Concentrado.Rows.Count));
                                        Detallado.Cells["F" + (Filas + 3) + ":G" + (Filas + 3)].Style.Font.Bold = true;
                                        Detallado.Cells[(Filas + 3), 7, (Filas + 3), 8].Style.Numberformat.Format = "#,##0";
                                    }

                                    Filas = Filas + 4;
                                }



                                //  valores de creacion del documento
                                Filas = Filas + 3;
                                Detallado.Cells["A" + Filas.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                                Detallado.Cells["A" + (Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();


                                Rango.AutoFitColumns();

                                Epc_Accesos.Save();
                            }


                            MessageBox.Show(this, "Exportacion exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //}// fin dialog

                        }// fin del dt
                        else
                        {
                            MessageBox.Show(this, "No existe información para exportar", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }// fin del combo
                    #endregion concentrado

                    #region Detallado
                    else
                    {
                        Dt_General = Ds_Resultados_Busqueda.Tables["Datos_Generales"];
                        Dt_Concentrado = Ds_Resultados_Busqueda.Tables["ACCESOS"];
                        Dt_Detallado = Ds_Resultados_Busqueda.Tables["Detalle"];

                        if (Dt_Concentrado.Rows.Count > 0)
                        {
                            Dt_Concentrado.Rows.RemoveAt(Dt_Concentrado.Rows.Count - 1);

                            if (RBtn_Hora.Checked == true)
                            {
                                Dt_Concentrado.Columns.RemoveAt(0);
                                Dt_Concentrado.Columns.RemoveAt(0);
                                Dt_Concentrado.Columns[5].ColumnName = "Fecha";

                                Dt_Concentrado.Columns[1].ColumnName = "No. Tickets vendidos";
                                Dt_Concentrado.Columns[2].ColumnName = "No. Productos vendidos";
                                Dt_Concentrado.Columns[3].ColumnName = "No. Tickect escaneados por torniquete";
                                Dt_Concentrado.Columns[4].ColumnName = "Accesos sin utilizar";
                                Dt_Concentrado.AcceptChanges();
                            }
                            else
                            {
                                Dt_Concentrado.Columns.RemoveAt(0);
                                Dt_Concentrado.Columns.RemoveAt(0);
                                Dt_Concentrado.Columns[0].ColumnName = "No. Tickets vendidos";
                                Dt_Concentrado.Columns[1].ColumnName = "No. Productos vendidos";
                                Dt_Concentrado.Columns[2].ColumnName = "No. Tickect escaneados por torniquete";
                                Dt_Concentrado.Columns[3].ColumnName = "Accesos sin utilizar";
                                Dt_Concentrado.Columns[4].ColumnName = "Fecha";
                                Dt_Concentrado.AcceptChanges();
                            }

                            using (ExcelPackage Epc_Accesos = new ExcelPackage(newFile))
                            {
                                ExcelWorksheet Detallado = Epc_Accesos.Workbook.Worksheets.Add("Accesos");

                                #region Encabezados
                                Detallado.Cells["A1"].Value = "Tesoreria Municipal";
                                Detallado.Cells["A2"].Value = "Dirección de ingresos";
                                Detallado.Cells["A3"].Value = "Museo de las momias";
                                Detallado.Cells["A4"].Value = Dt_General.Rows[0]["Periodo_Reporte"].ToString();
                                Detallado.Cells["A6"].Value = "Reporte de accesos (detalle por " + Str_Encabezado_Reporte + ")";

                                Detallado.Cells["A1:A1"].Style.Font.Bold = true;
                                Detallado.Cells["A3:A6"].Style.Font.Bold = true;


                                //  formato de numero
                                if (RBtn_Hora.Checked == true)
                                {
                                    // Encabezados del reporte
                                    Detallado.Cells["A1:F1"].Merge = true;
                                    Detallado.Cells["A2:F2"].Merge = true;
                                    Detallado.Cells["A3:F3"].Merge = true;
                                    Detallado.Cells["A4:F4"].Merge = true;
                                    Detallado.Cells["A6:F6"].Merge = true;

                                    Detallado.Cells["A1:F1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A2:F2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A3:F3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A4:F4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A6:F6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                    Detallado.Cells["A1:F1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A2:F2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A3:F3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A4:F4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A6:F6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                }
                                else
                                {
                                    // Encabezados del reporte
                                    Detallado.Cells["A1:E1"].Merge = true;
                                    Detallado.Cells["A2:E2"].Merge = true;
                                    Detallado.Cells["A3:E3"].Merge = true;
                                    Detallado.Cells["A4:E4"].Merge = true;
                                    Detallado.Cells["A6:E6"].Merge = true;

                                    Detallado.Cells["A1:E1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A2:E2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A3:E3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A4:E4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                                    Detallado.Cells["A6:E6"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                                    Detallado.Cells["A1:E1"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A2:E2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A3:E3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A4:E4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                    Detallado.Cells["A6:E6"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                                }

                                #endregion Encabezados

                                //  variables a usar
                                DataTable Dt_Auxiliar = new DataTable();
                                DataTable Dt_Auxiliar_Detalle = new DataTable();
                                ExcelRangeBase Rango;
                                Int32 Cont_Filas = 7;
                                Int32 Cont_Nombre_Filas = 0;
                                DateTime Dt_Fecha;
                                String Str_Periodo_Hora = "";

                                //    se recorren los registros de las ventas
                                foreach (DataRow Registro in Dt_Concentrado.Rows)
                                {
                                    Dt_Auxiliar = Dt_Concentrado.Clone();
                                    object[] Obj_row = Registro.ItemArray;

                                    Dt_Auxiliar.Rows.Add(Obj_row);

                                    Dt_Fecha = Convert.ToDateTime(Registro["Fecha"]);

                                    //  obtenemos la hora
                                    if (RBtn_Hora.Checked == true)
                                    {
                                        Str_Periodo_Hora = " " + Registro["periodo"].ToString().Substring(0, 2);

                                        //  se obtendran las ventas correpondientes a la fecha
                                        Dt_Detallado.DefaultView.RowFilter = "fecha_venta =  '" + Dt_Fecha.ToString("yyyy-MM-dd") + Str_Periodo_Hora + "'";
                                    }
                                    else if (Chk_Dia.Checked == true)
                                    {
                                        Str_Periodo_Hora = "";

                                        //  se obtendran las ventas correpondientes a la fecha
                                        Dt_Detallado.DefaultView.RowFilter = "fecha_de_acceso =  '" + Dt_Fecha.ToString("yyyy-MM-dd") + Str_Periodo_Hora + "'";
                                    }
                                    else if (Chk_Mes.Checked == true)
                                    {
                                        //  se obtendran las ventas correpondientes a la fecha
                                        Dt_Detallado.DefaultView.RowFilter = "fecha_venta =  '" + Dt_Fecha.ToString("yyyy-MM") + Str_Periodo_Hora + "'";
                                    }

                                    Dt_Auxiliar_Detalle = Dt_Detallado.DefaultView.ToTable();

                                    //  se quitan el caracter _ por ' ' 
                                    foreach (DataColumn Registro_Columna in Dt_Auxiliar_Detalle.Columns)
                                    {
                                        Registro_Columna.ColumnName = Registro_Columna.ColumnName.Replace('_', ' ');
                                    }


                                    //  informacion del concentrado ***************************************************************
                                    Dt_Auxiliar.TableName = Dt_Auxiliar.TableName + Cont_Nombre_Filas;
                                    Dt_Auxiliar_Detalle.TableName = Dt_Auxiliar_Detalle.TableName + Cont_Nombre_Filas;

                                    Dt_Auxiliar.Columns["Fecha"].SetOrdinal(0);

                                    //  se carga el archivo se ponen los datos GENERALES
                                    Rango = Detallado.Cells["A" + Cont_Filas.ToString()].LoadFromDataTable(Dt_Auxiliar, true, OfficeOpenXml.Table.TableStyles.Medium2);

                                    //  formato de fecha
                                    Detallado.Cells[Cont_Filas, 1, Rango.End.Row, 1].Style.Numberformat.Format = "mm-dd-yy";

                                    //  formato de numero
                                    if (RBtn_Hora.Checked == true)
                                    {
                                        Detallado.Cells[Cont_Filas, 3, Rango.End.Row, 6].Style.Numberformat.Format = "#,##0";
                                    }
                                    else
                                    {
                                        Detallado.Cells[Cont_Filas, 2, Rango.End.Row, 5].Style.Numberformat.Format = "#,##0";
                                    }

                                    Rango.AutoFitColumns();

                                    //  se ponen los datos  del detalle ***************************************************************
                                    Cont_Filas = Cont_Filas + Dt_Auxiliar.Rows.Count + 2;
                                    Dt_Auxiliar_Detalle.Columns.RemoveAt(1);
                                    Rango = Detallado.Cells["A" + Cont_Filas.ToString()].LoadFromDataTable(Dt_Auxiliar_Detalle, true, OfficeOpenXml.Table.TableStyles.Light2);

                                    //  formato de fecha
                                    Detallado.Cells[Cont_Filas, 5, Rango.End.Row, 5].Style.Numberformat.Format = "mm-dd-yy";
                                    Detallado.Cells[Cont_Filas, 3, Rango.End.Row, 3].Style.Numberformat.Format = "#,##0";
                                    Rango.AutoFitColumns();

                                    Cont_Filas = Cont_Filas + Dt_Auxiliar_Detalle.Rows.Count + 1;

                                    //  SUBTOTAL DE LA TABLA DE DETALLE
                                    Detallado.Cells["C" + (Cont_Filas)].Formula = string.Format("SUBTOTAL(109, " + Dt_Auxiliar_Detalle.TableName + "[Costo] )");
                                    Detallado.Cells["C" + (Cont_Filas)].Style.Font.Bold = true;
                                    Detallado.Cells[(Cont_Filas), 3, (Cont_Filas), 3].Style.Numberformat.Format = "#,##0";

                                    //  se incrementas los contadores
                                    Cont_Filas = Cont_Filas + 2;
                                    Cont_Nombre_Filas++;
                                }


                                //  pie de pagina
                                Detallado.Cells["A" + Cont_Filas.ToString()].Value = "Usuario: " + MDI_Frm_Apl_Principal.Nombre_Usuario;
                                Detallado.Cells["A" + (Cont_Filas + 1).ToString()].Value = "Fecha de emisión: " + DateTime.Now.ToLongDateString() + "; " + DateTime.Now.ToLongTimeString();



                                Epc_Accesos.Save();
                            }

                            MessageBox.Show(this, "Exportacion exitosa", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }// fin del dt count
                        else
                        {
                            MessageBox.Show(this, "No existe información para exportar", "Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }// fin del else

                #endregion

                }// fin del dialog

            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Exportar_Excel_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento que limpia los controles del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <creo>Juan Alberto Hernández Negrete</creo>
        /// <fecha_creo>2014 06 12 18:01 Hrs.</fecha_creo>
        /// <modifico></modifico>
        /// <fecha_modifico></fecha_modifico>
        /// <causa_modificacion></causa_modificacion>
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            try
            {
                Grid_Resultado.DataSource = null;
                Grid_Detalle_Accesos.DataSource = null;
                Dtp_Fecha_Inicio.Value = DateTime.Today;
                Dtp_Fecha_Fin.Value = DateTime.Today.AddHours(24).AddMilliseconds(-1);
                Chk_Anio.Checked = true;
                Ktc_Rpt_Accesos.SelectedTab = Tab_Tarifas;
                Dt_Detalle = null;
            }
            catch (Exception Ex)
            {
                throw new Exception("Error al limpiar los controles de la página. Error: [" + Ex.Message + "]");
            }
        }
        #endregion

        #region (Combo)
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

                    Cmb_Productos.DataSource = Dt_Prod;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Productos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
