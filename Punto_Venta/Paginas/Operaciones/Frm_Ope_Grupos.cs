using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp.Metodos_Generales;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Constantes;
using ERP_BASE.Paginas.Ventanas_Emergentes;
using ERP_BASE.App_Code.Negocio.Operaciones;
using ERP_BASE.Paginas.Operacion;
using ResizeableForm;

namespace ERP_BASE.Paginas.Operaciones.Grupos
{
    public partial class Frm_Ope_Grupos : ResizableForm
    {
        #region (Variables)
        private DataTable Dt_Productos;//Variable para mantener los productos y servicios consultados.
        private DataTable Dt_Pedidos;//Variable para mantener los detalles del pedido de productos y servicios.
        private ComboBox _Concepto_Aplicar =new ComboBox();
        string Usuario_Autoriza;//Identificador del empleado que autoriza el movimiento.
        #endregion

        #region (Init/Load)
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Grupos
        ///DESCRIPCIÓN          : Inicializa los campos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Juan Alberto Hernández Negrete.
        ///FECHA_MODIFICO       : 18 Octubre 2013
        ///CAUSA_MODIFICACIÓN   : Agregar evento a la caja de texto que almacena la cantidad
        ///                       de productos.
        ///*******************************************************************************
        public Frm_Ope_Grupos()
        {
            try
            {
                InitializeComponent();//Se inicializan los controles del formulario.
                //Recorremos las columnas de la tabla para modificar el estado de la cabecera de la tabla.
                Array.ForEach(Grid_Detalles_Ventas.Columns.OfType<DataGridViewColumn>().ToArray(),
                    columna =>
                    {
                        switch (columna.HeaderText)
                        {
                            case "Cantidad":
                                columna.Width = 35;
                                columna.Visible = true;
                                columna.HeaderText = "#";
                                break;
                            case "Nombre":
                                columna.Width = 170;
                                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            case "Costo unitario":
                                columna.Width = 130;
                                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.HeaderText = "Costo Unitario";
                                break;
                            case "Total":
                                columna.Width = 90;
                                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            default:
                                break;
                        }
                        columna.HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Frm_Ope_Grupos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }
        #endregion

        #region (Metodos)

        #region (Generales)
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Grupos_Load
        ///DESCRIPCIÓN          : Evento Load del formulario
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Juan Alberto Hernández Negrete.
        ///FECHA_MODIFICO       : 18 Octubre 2013
        ///CAUSA_MODIFICACIÓN   : Se quito la lista de botones que controlaban el dato cantidad.
        ///*******************************************************************************
        private void Frm_Ope_Grupos_Load(object sender, EventArgs e)
        {
            try
            {
                Manejo_Botones_Operacion("Cancelar");
                Limpiar_Controles();
                Cargar_Botones_Productos();
                Cargar_Botones_Servicios();
                Cargar_Combo_Aplica_Días_Festivos();
                Iniciar_Dt_Pedidos();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Frm_Ope_Grupos_Load]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Manejo_Botones_Operacion
        /// 
        /// Descripción: Método que establecera la configuración de los botones según la operación a realizar.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 09 Octubre 2013 18:43 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Tipo">Configuracion a establecer</param>
        private void Manejo_Botones_Operacion(String Tipo)
        {
            bool Habilitar = false;

            switch (Tipo)
            {
                case "Nuevo":
                    {
                        Habilitar = true;
                        Btn_Nuevo.Text = "Dar de Alta";
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = false;
                        Btn_Eliminar.Enabled = false;
                        Btn_Consultar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        break;
                    }
                case "Modificar":
                    {
                        Habilitar = true;
                        Btn_Modificar.Text = "Actualizar";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Btn_Nuevo.Enabled = false;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = false;
                        Btn_Consultar.Enabled = false;
                        Btn_Salir.Enabled = true;
                        break;
                    }
                case "Cancelar":
                    {
                        Habilitar = false;
                        Btn_Nuevo.Text = "Nuevo";
                        Btn_Modificar.Text = "Modificar";
                        Btn_Eliminar.Text = "Cancelar";
                        Btn_Salir.Text = "Salir";
                        Btn_Modificar.Image = global::ERP_BASE.Properties.Resources.icono_modificar;
                        Btn_Nuevo.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
                        Btn_Nuevo.Enabled = true;
                        Btn_Modificar.Enabled = true;
                        Btn_Eliminar.Enabled = true;
                        Btn_Consultar.Enabled = true;
                        Btn_Salir.Enabled = true;
                        break;
                    }
                default: break;
            }

            Txt_Persona_Tramita.Enabled = Habilitar;
            Txt_Empresa_Tramita.Enabled = Habilitar;
            Dtp_Fecha_Tramite.Enabled = Habilitar;
            Dtp_Fecha_Inicio_Vigencia.Enabled = Habilitar;
            Dtp_Fecha_Termino_Vigencia.Enabled = Habilitar;
            Cmb_Productos.Enabled = Habilitar;
            Cmb_Servicios.Enabled = Habilitar;
            Txt_Cantidad.Enabled = Habilitar;
            Txt_Costo.Enabled = Habilitar;
            Btn_Agregar.Enabled = Habilitar;
            Grid_Detalles_Ventas.Enabled = Habilitar;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Limpiar_Controles
        ///DESCRIPCIÓN          : Limpia el grid y el campo de precio total
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Limpiar_Controles()
        {
            try
            {
                Iniciar_Dt_Pedidos();
                Lbl_Total_Precio.Text = "$ 0.00";

                Txt_Persona_Tramita.Text = string.Empty;
                Txt_Empresa_Tramita.Text = string.Empty;
                Dtp_Fecha_Tramite.Value = DateTime.Now;
                Dtp_Fecha_Inicio_Vigencia.Value = DateTime.Now;
                Dtp_Fecha_Termino_Vigencia.Value = DateTime.Now;

                if (Cmb_Aplica_Dias_Festivos.Items.Count > 1)
                    Cmb_Aplica_Dias_Festivos.SelectedIndex = (0);
                else
                    Cmb_Aplica_Dias_Festivos.SelectedIndex = (-1);

                if (Cmb_Productos.Items.Count > 1)
                    Cmb_Productos.SelectedIndex = (0);
                else
                    Cmb_Productos.SelectedIndex = (-1);

                if (Cmb_Servicios.Items.Count > 1)
                    Cmb_Servicios.SelectedIndex = (0);
                else
                    Cmb_Servicios.SelectedIndex = (-1);

                Txt_Cantidad.Text = "1";
                Txt_Costo.Text = string.Empty;
                Pnl_Datos_Generales.Tag = null;
                Grid_Detalles_Ventas.Rows.Clear();
                this._Concepto_Aplicar = new ComboBox();
                this.Usuario_Autoriza = string.Empty;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Limpiar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Botones_Productos
        ///DESCRIPCIÓN          : Metodo encargado de cargar la informacion de los productos en los botones de productos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Juan Alberto Hernández Negrete.
        ///FECHA_MODIFICO       : 18 Octubre 2013
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Cargar_Botones_Productos()
        {
            Cls_Cat_Productos_Negocio P_Productos = new Cls_Cat_Productos_Negocio();//Variable que se utiliza para realizar peticiones a la clase de datos.            
            IEnumerable<DataRow> Productos = null;//Variable que almacenara los productos activos.

            try
            {
                //Consultamos los productos.
                Dt_Productos = P_Productos.Consultar_Producto();
                //Obtenemos solo los de tipo producto y que esten activos.
                Productos = Dt_Productos
                    .AsEnumerable()
                    .Where(fila => fila.Field<String>(Cat_Productos.Campo_Tipo).Equals("Producto") && fila.Field<String>(Cat_Productos.Campo_Estatus).Equals("ACTIVO"));

                if (Productos.Any())
                    Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Productos, Productos.CopyToDataTable<DataRow>(),
                        Cat_Productos.Campo_Nombre, Cat_Productos.Campo_Producto_Id);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Botones_Productos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Botones_Servicios
        ///DESCRIPCIÓN          : Metodo encargado de cargar la informacion de los servicios 
        ///                       en los botones de servicios
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Juan Alberto Hernández Negrete.
        ///FECHA_MODIFICO       : 18 Octubre 2013
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Cargar_Botones_Servicios()
        {
            IEnumerable<DataRow> Servicios = null;//Variable que almacenara un listado de los servicios activos.

            try
            {
                Servicios = Dt_Productos
                    .AsEnumerable()
                    .Where(fila => fila.Field<String>(Cat_Productos.Campo_Tipo).Equals("Servicio") && fila.Field<String>(Cat_Productos.Campo_Estatus).Equals("ACTIVO"));

                if (Servicios.Any())
                    if (Servicios.Any())
                        Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Servicios, Servicios.CopyToDataTable<DataRow>(),
                            Cat_Productos.Campo_Nombre, Cat_Productos.Campo_Producto_Id);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Botones_Servicios]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Cargar_Datos_Grupo
        /// 
        /// Descripción: Método muestra al usuario una pantalla para capturar los datos del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 18 Octubre 2013 18:38 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="Pago">Instancia del formulario de pagos, al cuálse le estableceran los datos del grupo</param>
        private void Cargar_Datos_Grupo(ref Frm_Ope_Pago Pago)
        {
            try
            {
                //Establecemos los datos del grupo a la instancia del formulario de pagos.
                Pago.Fecha_Tramite = string.Format("{0:dd/MM/yyyy}", Dtp_Fecha_Tramite.Value); ;
                Pago.Persona_Tramita = Txt_Persona_Tramita.Text;
                Pago.Empresa = Txt_Empresa_Tramita.Text;
                Pago.Fecha_Inicio_Vigencia = string.Format("{0:dd/MM/yyyy}", Dtp_Fecha_Inicio_Vigencia.Value); ;
                Pago.Fecha_Termino_Vigencia = string.Format("{0:dd/MM/yyyy}", Dtp_Fecha_Termino_Vigencia.Value); ;
                Pago.Aplican_Dias_Festivos = Cmb_Aplica_Dias_Festivos.SelectedValue.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Cargar_Datos_Grupo]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Iniciar_Dt_Pedidos
        ///DESCRIPCIÓN          : Crea una nueva tabla
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Iniciar_Dt_Pedidos()
        {
            try
            {
                Dt_Pedidos = new DataTable();
                Dt_Pedidos.Columns.Add("CANTIDAD", typeof(Decimal));
                Dt_Pedidos.Columns.Add("PRODUCTO", typeof(String));
                Dt_Pedidos.Columns.Add("TOTAL", typeof(Decimal));
                Dt_Pedidos.Columns.Add("PRODUCTO_ID", typeof(String));
                Dt_Pedidos.Columns.Add("COSTO", typeof(Decimal));
                Dt_Pedidos.Columns.Add("TIPO", typeof(String));
                Dt_Pedidos.Columns.Add("IMPRIMIR", typeof(String));
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Iniciar_Dt_Pedidos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Exitosa
        ///DESCRIPCIÓN          : Metodo encargado de limpiar los campos y visualizar el
        ///                       mensaje de alta exitosa
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Alta_Exitosa()
        {
            try
            {
                Btn_Salir_Click(null, null);
                MessageBox.Show(this, "Alta exitosa!", "Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Alta_Exitosa]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Agregar_Concepto
        /// 
        /// Descripción: Método que agrega el concepto al grid.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Octubre 2013 16:33
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="_Cmb_Conceptos"></param>
        private void Agregar_Concepto(ComboBox _Cmb_Conceptos)
        {
            String Producto_Id = _Cmb_Conceptos.SelectedValue.ToString();
            DataRow Dr_Producto = null;
            DataRow Dr_Detalle_Existente = null;
            String Cantidad = string.Empty;
            Decimal Costo = 0;

            try
            {
                //Inicializamos las variables.
                Dr_Producto = Dt_Productos.AsEnumerable().FirstOrDefault(fila => fila.Field<String>(Cat_Productos.Campo_Producto_Id) == Producto_Id);
                Dr_Detalle_Existente = Dt_Pedidos.AsEnumerable().FirstOrDefault(x => x.Field<String>(Cat_Productos.Campo_Producto_Id) == Producto_Id);
                Cantidad = string.IsNullOrEmpty(Txt_Cantidad.Text) ? "1" : Txt_Cantidad.Text.Trim();
                Costo = Convert.ToDecimal(string.IsNullOrEmpty(Txt_Costo.Text) ? "0.0" : Txt_Costo.Text.Trim());

                if (!(Dr_Detalle_Existente is DataRow))
                {
                    DataRow Dr_Producto_Agregar = Dt_Pedidos.NewRow();
                    Dr_Producto_Agregar["CANTIDAD"] = Convert.ToDecimal(Cantidad);
                    Dr_Producto_Agregar["PRODUCTO"] = Dr_Producto[Cat_Productos.Campo_Nombre];
                    Dr_Producto_Agregar["TOTAL"] = Costo * Convert.ToDecimal(Cantidad);
                    Dr_Producto_Agregar["PRODUCTO_ID"] = Dr_Producto[Cat_Productos.Campo_Producto_Id];
                    Dr_Producto_Agregar["COSTO"] = Costo;
                    Dr_Producto_Agregar["TIPO"] = Dr_Producto[Cat_Productos.Campo_Tipo];
                    Dr_Producto_Agregar["IMPRIMIR"] = Dr_Producto[Cat_Productos.Campo_Tipo_Valor];
                    Dt_Pedidos.Rows.Add(Dr_Producto_Agregar);
                }
                else
                {
                    Dr_Detalle_Existente["CANTIDAD"] = Convert.ToDecimal(Dr_Detalle_Existente["CANTIDAD"]) + Convert.ToDecimal(Cantidad);
                    Dr_Detalle_Existente["TOTAL"] = Convert.ToDecimal(Dr_Detalle_Existente["TOTAL"]) + (Convert.ToDecimal(Cantidad) * Costo);
                }
                Llenar_Grid(Dt_Pedidos);
                Txt_Cantidad.Text = "1";

                Lbl_Total_Precio.Text = "$ " + Dt_Pedidos.AsEnumerable().Sum(fila => fila.Field<decimal>("TOTAL")).ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Agregar_Concepto]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Cargar_Combo_Aplica_Días_Festivos
        /// 
        /// Descripción: Método que carga el listado de aplica días festivos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Octubre 2013 16:33
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Cargar_Combo_Aplica_Días_Festivos()
        {
            DataTable Dt_Datos = new DataTable();//Variable que almacenara los dos elementos que se cargaran en el como de días festivos.

            try
            {
                Dt_Datos.Columns.Add("value", typeof(string));
                Dt_Datos.Columns.Add("text", typeof(string));

                DataRow dr = Dt_Datos.NewRow();
                dr["text"] = "Si";
                dr["value"] = "S";
                Dt_Datos.Rows.Add(dr);

                dr = Dt_Datos.NewRow();
                dr["text"] = "No";
                dr["value"] = "N";
                Dt_Datos.Rows.Add(dr);

                Cls_Metodos_Generales.Rellena_Combo_Box(Cmb_Aplica_Dias_Festivos, Dt_Datos, "text", "value");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método:[Cargar_Combo_Aplica_Días_Festivos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Operacion)
        /// <summary>
        /// Nombre: Registrar_Grupo
        /// 
        /// Descripción: Método que realiza el alta del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Octubre 2013 18:46
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns></returns>
        private bool Alta_Grupo()
        {
            Cls_Ope_Grupos_Negocio Obj_Grupos = new Cls_Ope_Grupos_Negocio();
            bool Estatus = false;
            string Total = string.Empty;

            try
            {
                Total = Lbl_Total_Precio.Text.Replace("$", "");
                Total = Total.Trim();
                Obj_Grupos.P_Total = Convert.ToDecimal(string.IsNullOrEmpty(Total) ? "0.0" : Total);
                Obj_Grupos.P_Persona_Tramita = Txt_Persona_Tramita.Text;
                Obj_Grupos.P_Empresa = Txt_Empresa_Tramita.Text;
                Obj_Grupos.P_Fecha_Tramite = Dtp_Fecha_Tramite.Value;
                Obj_Grupos.P_Fecha_Inicio_Vigencia = Dtp_Fecha_Inicio_Vigencia.Value;
                Obj_Grupos.P_Fecha_Termino_Vigencia = Dtp_Fecha_Termino_Vigencia.Value;
                Obj_Grupos.P_Aplica_Dias_Festivos = Cmb_Aplica_Dias_Festivos.SelectedValue.ToString();
                Obj_Grupos.P_Dt_Ventas = this.Dt_Pedidos;

                Obj_Grupos.Alta_Grupo();
                Estatus = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método:[Registrar_Grupo]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        /// <summary>
        /// Nombre: Actualizar_Grupo
        /// 
        /// Descripción: Método que realiza la actualización de los datos del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 16:01 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns></returns>
        private bool Actualizar_Grupo()
        {
            Cls_Ope_Grupos_Negocio Obj_Grupos = new Cls_Ope_Grupos_Negocio();
            bool Estatus = false;
            string Total = string.Empty;

            try
            {
                Obj_Grupos.P_No_Venta = Txt_No_Venta.Text;
                Total = Lbl_Total_Precio.Text.Replace("$", "");
                Total = Total.Trim();
                Obj_Grupos.P_Total = Convert.ToDecimal(string.IsNullOrEmpty(Total) ? "0.0" : Total);
                Obj_Grupos.P_Persona_Tramita = Txt_Persona_Tramita.Text;
                Obj_Grupos.P_Empresa = Txt_Empresa_Tramita.Text;
                Obj_Grupos.P_Fecha_Tramite = Dtp_Fecha_Tramite.Value;
                Obj_Grupos.P_Fecha_Inicio_Vigencia = Dtp_Fecha_Inicio_Vigencia.Value;
                Obj_Grupos.P_Fecha_Termino_Vigencia = Dtp_Fecha_Termino_Vigencia.Value;
                Obj_Grupos.P_Aplica_Dias_Festivos = Cmb_Aplica_Dias_Festivos.SelectedValue.ToString();
                Obj_Grupos.P_Dt_Ventas = this.Dt_Pedidos;

                Obj_Grupos.Actualizar_Grupo();
                Estatus = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método:[Actualizar_Grupo]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        /// <summary>
        /// Nombre: Cancelar_Grupo
        /// 
        /// Descripción: Método que realiza la cancelacion del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 16:01 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns></returns>
        private bool Cancelar_Grupo()
        {
            Cls_Ope_Grupos_Negocio Obj_Grupos = new Cls_Ope_Grupos_Negocio();
            bool Estatus = false;

            try
            {
                Obj_Grupos.P_No_Venta = Txt_No_Venta.Text;                
                Obj_Grupos.P_Motivo_Cancelacion = Microsoft.VisualBasic.Interaction.InputBox("Ingresar el motivo de la cancalecaion?", "Cancelar Grupos", string.Empty);
                //Se realiza la baja de la recolección
                if (!string.IsNullOrEmpty(Obj_Grupos.P_Motivo_Cancelacion))
                    Estatus = Obj_Grupos.Cancelar_Grupo();
                else Estatus = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método:[Cancelar_Grupo]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        #endregion

        #region (Validación)
        /// <summary>
        /// Nombre: Frm_Cat_Ventana_Emergente_Datos_Grupo
        /// 
        /// Descripción: Método que válida que el usuario halla ingresado los datos requeridos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 16:25 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns></returns>
        private bool Validar_Datos()
        {
            bool Estatus = true;
            StringBuilder Datos_Faltantes = new StringBuilder();

            try
            {
                Datos_Faltantes.Append("Es necesario:\n");

                if (string.IsNullOrEmpty(Txt_Persona_Tramita.Text))
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - La persona que tramita es un dato requerido para registrar el grupo. \n");
                }

                if (string.IsNullOrEmpty(Txt_Empresa_Tramita.Text))
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - El nombre de la empresa u organización es un dato requerido para registrar el grupo. \n");
                }

                if (Dtp_Fecha_Tramite.Value == null)
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - La fecha de tramite es un dato requerido para registrar el grupo. \n");
                }

                if (Dtp_Fecha_Inicio_Vigencia.Value == null)
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - La fecha de inicio de la vigencia es un dato requerido para registrar el grupo. \n");
                }

                if (Dtp_Fecha_Termino_Vigencia.Value == null)
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - La fecha de termino de la vigencia es un dato requerido para registrar el grupo. \n");
                }

                if (Cmb_Aplica_Dias_Festivos.SelectedIndex <= 0)
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - Indicar si el grupo será válido en días festivos. \n");
                }

                Pnl_Datos_Generales.Tag = Datos_Faltantes.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Validar_Datos]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        /// <summary>
        /// Nombre: Autorizar_Movimiento
        /// 
        /// Descripción: Método que invoca la autorización del movimiento.
        /// 
        /// Usuario Modifico: Juan Alberto Hernández Negrete
        /// Fecha Modifico: 06 Octubre 2013 11:31 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <returns>Verdadero (true) si se autoriza y falso (false) en caso contrario</returns>
        private bool Autorizar_Movimiento()
        {
            try
            {
                //Utilizamos la clase (Frm_Apl_Usuario_Autoriza) e invocamos su método (Mostrar_Ventana) para autorizar el movimiento.
                this.Usuario_Autoriza = new Frm_Apl_Usuario_Autoriza().Mostrar_Ventana("Autorización", this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Autorizar_Movimiento]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return !string.IsNullOrEmpty(this.Usuario_Autoriza);
        }
        /// <summary>
        /// Nombre: Validar_Datos_Agregar
        /// 
        /// Descripción: Método que válida que se hallan ingresado los datos necesarios para
        ///              agregar un concepto al listado.
        /// 
        /// Fecha Creo: Juan Alberto Hernández Negrete
        /// Usuario Creo: 24 Octubre 2013 12:20 p.m.
        /// Fecha Creo:
        /// Usuario Modifico:
        /// </summary>
        /// <returns>Verdadero si la validacion pasa, falso si falto ingresar algún dato</returns>
        private bool Validar_Datos_Agregar()
        {
            bool Estatus = true;
            StringBuilder Datos_Faltantes = new StringBuilder();

            try
            {
                Datos_Faltantes.Append("Es necesario:\n");

                if (Cmb_Productos.SelectedIndex <= 0 && Cmb_Servicios.SelectedIndex <= 0)
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - Es necesario seleccionar el concepto que se agregara. \n");
                }

                if (string.IsNullOrEmpty(Txt_Costo.Text))
                {
                    Estatus = false;
                    Datos_Faltantes.Append(" - No se ha ingresado ningún costo para el concepto que se agregara. \n");
                }

                Pnl_Datos_Generales.Tag = Datos_Faltantes.ToString();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Validar_Datos_Agregar]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Estatus;
        }
        #endregion

        #endregion

        #region (GridView)
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Llenar_Grid
        ///DESCRIPCIÓN          : Carga la informacion del DataTable en el grid
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Juan Alberto Hernández Negrete.
        ///FECHA_MODIFICO       : 18 Octubre 2013
        ///CAUSA_MODIFICACIÓN   : Formato a la tabla de productos y servicios.
        ///*******************************************************************************
        private void Llenar_Grid(DataTable Dt_Cargar)
        {
            int Cont_Detalles = 0;//Variable para realizar el conteo de detalles.

            try
            {
                //Limpiamos el grid de detalles de la venta del grupo.
                Grid_Detalles_Ventas.Rows.Clear();

                if (Dt_Cargar is DataTable)
                {
                    foreach (DataRow Dr_Cargar in Dt_Cargar.Rows)
                    {
                        Grid_Detalles_Ventas.Rows.Add();
                        Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["CANTIDAD"].Value = Dr_Cargar["CANTIDAD"].ToString();
                        Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["PRODUCTO"].Value = Dr_Cargar["PRODUCTO"].ToString();
                        Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["TOTAL"].Value = Dr_Cargar["TOTAL"].ToString();
                        Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["PRODUCTO_ID"].Value = Dr_Cargar["PRODUCTO_ID"].ToString();
                        Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["COSTO"].Value = Dr_Cargar["COSTO"].ToString();
                        Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["TIPO"].Value = Dr_Cargar["TIPO"].ToString();
                        Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["IMPRIMIR"].Value = Dr_Cargar["IMPRIMIR"].ToString();
                        Cont_Detalles++;
                    }
                }

                //Recorremos las columnas de la tabla para modificar el estado de la cabecera de la tabla.
                Array.ForEach(Grid_Detalles_Ventas.Columns.OfType<DataGridViewColumn>().ToArray(),
                    columna =>
                    {
                        switch (columna.HeaderText)
                        {
                            case "Cantidad":
                                columna.Width = 35;
                                columna.Visible = true;
                                columna.HeaderText = "#";
                                break;
                            case "Nombre":
                                columna.Width = 170;
                                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            case "Costo unitario":
                                columna.Width = 130;
                                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.HeaderText = "Costo Unitario";
                                break;
                            case "Total":
                                columna.Width = 90;
                                columna.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                break;
                            default:
                                break;
                        }
                        columna.HeaderCell.Style.Font = new Font("Arial", 9, FontStyle.Bold);
                    });

                //Recorremos la tabla para dar formato a las celdas.
                Array.ForEach(Grid_Detalles_Ventas.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
                {
                    fila.Height = 25;
                    Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                    {
                        celda.Style.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        celda.Style.ForeColor = System.Drawing.Color.Black;
                        celda.Style.BackColor = System.Drawing.Color.WhiteSmoke;
                    });
                });
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Llenar_Grid]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Grid_Detalles_Ventas_CellContentClick
        /// 
        /// Descripción: Método que  se invoca cuando se pulsa sobre la celda con el boton de eliminar,
        ///              acción que remueve el registro seleccionado.
        /// 
        /// Usuario Modifico: Juan Lebrto Hernández Negrete.
        /// Fecha Modifico: 21 Octubre 2013 16:22
        /// UsuarioModifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Detalles_Ventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewImageColumn))
                {
                    if (Grid_Detalles_Ventas.Rows.Count > 0)
                    {
                        if (Dt_Pedidos is DataTable)
                        {
                           
                            Array.ForEach(Dt_Pedidos.AsEnumerable().OfType<DataRow>().ToArray(), fila =>
                            {
                                if (fila.Field<String>("PRODUCTO_ID") == Grid_Detalles_Ventas.CurrentRow.Cells["PRODUCTO_ID"].Value.ToString())
                                    fila.Delete();
                            });
                            Dt_Pedidos.AcceptChanges();

                            Grid_Detalles_Ventas.Rows.Remove(Grid_Detalles_Ventas.CurrentRow);
                            Lbl_Total_Precio.Text = "$ " + Dt_Pedidos.AsEnumerable().Sum(fila => fila.Field<decimal>("TOTAL")).ToString();
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Grid_Detalles_Ventas_CellContentClick]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Eventos)

        #region (Botones)
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Nuevo
        ///PARAMETROS           : 
        ///CREO                 : Juan Alberto Hernández Negrete
        ///FECHA_CREO           : 22 Octubre 2013 10:57 a.m.
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Nuevo.Text.Trim() == "Nuevo")
                {
                    if (Autorizar_Movimiento())
                    {
                        Limpiar_Controles();
                        Manejo_Botones_Operacion("Nuevo");
                    }
                    else
                    {
                        MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (this.ValidateChildren(ValidationConstraints.Enabled))
                    {
                        if (Validar_Datos())
                        {
                            if (Alta_Grupo())
                            {
                                Limpiar_Controles();
                                Manejo_Botones_Operacion("Cancelar");
                                MessageBox.Show(this, "Operación completa", "Alta Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, Pnl_Datos_Generales.Tag.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Btn_Nuevo_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Modificar_Click
        /// 
        /// Descripción: Método que se liga al evento click del botón de actualizar datos del grupo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 11:02 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Modificar.Text.Trim().Equals("Modificar"))
                {
                    if (Autorizar_Movimiento())
                    {
                        if (!string.IsNullOrEmpty(Txt_No_Venta.Text))
                        {
                            Manejo_Botones_Operacion("Modificar");
                        }
                        else
                        {
                            MessageBox.Show(this, "No se ha seleccionado ningún grupo a modificar.",
                                "Modificar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (Validar_Datos())
                    {
                        if (Actualizar_Grupo())
                        {
                            Limpiar_Controles();
                            Manejo_Botones_Operacion("Cancelar");
                            MessageBox.Show(this, "Operación completa", "Actualizar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, Pnl_Datos_Generales.Tag.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Btn_Modificar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Eliminar_Click
        /// 
        /// Descripción: Método que se liga al evento click del botón de eliminar.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 11:11 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Autorizar_Movimiento())
                {
                    if (!string.IsNullOrEmpty(Txt_No_Venta.Text))
                    {
                        if (Validar_Datos())
                        {
                            if (Cancelar_Grupo())
                            {
                                Limpiar_Controles();
                                Manejo_Botones_Operacion("Cancelar");
                                MessageBox.Show(this, "Operación completa", "Cancelar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(this, "La cancelación del grupo no se completo", "Cancelar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "No se ha seleccionado ningún registro de grupo a cancelar.", "Cancelar Grupo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Usuario o password incorrectos", "Autorizar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Método: [Btn_Eliminar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Salir_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Salir
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Btn_Salir.Text.Equals("Salir"))
                {
                    this.Close();
                }
                else
                {
                    Limpiar_Controles();
                    Manejo_Botones_Operacion("Cancelar");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Salir_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Consultar_Click
        /// 
        /// Descripción: Método que consulta los datos del grupo y sus detalles.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 22 Octubre 2013 11:13 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Consultar_Click(object sender, EventArgs e)
        {
            Frm_Cat_Ventana_Busqueda_Grupos Ven_Busqueda_Grupos = new Frm_Cat_Ventana_Busqueda_Grupos();

            try
            {
                Ven_Busqueda_Grupos.ShowDialog(this);
                if (Ven_Busqueda_Grupos.Hacer_Busqueda)
                {
                    Txt_No_Venta.Text = Ven_Busqueda_Grupos.No_Venta;
                    Txt_Persona_Tramita.Text = Ven_Busqueda_Grupos.Persona_Tramita;
                    Txt_Empresa_Tramita.Text = Ven_Busqueda_Grupos.Empresa;
                    Dtp_Fecha_Tramite.Value = Ven_Busqueda_Grupos.Fecha_Tramite;
                    Dtp_Fecha_Inicio_Vigencia.Value = Ven_Busqueda_Grupos.Fecha_Inicio_Vigencia;
                    Dtp_Fecha_Termino_Vigencia.Value = Ven_Busqueda_Grupos.Fecha_Termino_Vigencia;
                    Cmb_Aplica_Dias_Festivos.SelectedValue = Ven_Busqueda_Grupos.Aplica_Dias_Festivos;
                    Lbl_Total_Precio.Text = "$" + string.Format("{0:n}", Ven_Busqueda_Grupos.Total);

                    Dt_Pedidos = Ven_Busqueda_Grupos.Dt_Grupos;
                    Llenar_Grid(Ven_Busqueda_Grupos.Dt_Grupos);
                    Manejo_Botones_Operacion("Cancelar");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Btn_Agregar_Click
        /// 
        /// Descripción: Método que agrega el producto o servicio al grid de conceptos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Octubre 2013 16:33
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validar_Datos_Agregar())
                {
                    Pnl_Datos_Generales.Tag = null;
                    Agregar_Concepto(this._Concepto_Aplicar);
                }
                else {
                    MessageBox.Show(this, Pnl_Datos_Generales.Tag.ToString(), "Error - Método:[Btn_Agregar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pnl_Datos_Generales.Tag = null;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método:[Btn_Agregar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region (Cajas)
        /// <summary>
        /// Nombre: Txt_Cantidad_KeyPress
        /// 
        /// Descripción: Método que se invoca cuando se presiona una tecla sobre una caja de texto. Valida que solo
        ///              acepte los carácteres correctos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 10:54 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Digito);
        }
        /// <summary>
        /// Nombre: Txt_Persona_Tramita_KeyPress
        /// 
        /// Descripción: Método que se invoca cuando se presiona una tecla sobre una caja de texto. Valida que solo
        ///              acepte los carácteres correctos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 10:54 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Persona_Tramita_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }
        /// <summary>
        /// Nombre: Txt_Empresa_Tramita_KeyPress
        /// 
        /// Descripción: Método que se invoca cuando se presiona una tecla sobre una caja de texto. Valida que solo
        ///              acepte los carácteres correctos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 10:54 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Empresa_Tramita_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Alfa_Numerico_Extendido);
        }
        /// <summary>
        /// Nombre: Txt_Costo_KeyPress
        /// 
        /// Descripción: Método que se invoca cuando se presiona una tecla sobre una caja de texto. Valida que solo
        ///              acepte los carácteres correctos.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 10 Octubre 2013 10:54 a.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }
        #endregion

        #region (Ventana)
        /// <summary>
        /// Nombre: Frm_Ope_Retiros_FormClosed
        /// 
        /// Descripción: Método que se liga al evento de cerrar la ventana.y que limpia
        ///              la variable que nos indica el usuario que autoriza el movimiento.
        /// 
        /// Usuario Creo: Juan Alberto Hernandez Negrete.
        /// Fecha Creo: 05 Octubre 2013 14:15 p.m.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Ope_Retiros_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._Concepto_Aplicar = new ComboBox();
            this.Usuario_Autoriza = string.Empty;
        }
        #endregion

        #region (Combos)
        /// <summary>
        /// Nombre: Cmb_Conceptos_SelectedIndexChanged
        /// 
        /// Descripción: Método que se invoca cuando se realiza la seleccion de un elemento del listado
        ///              de productos o servicios y carga el costo del concepto en la caja de costo.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Octubre 2013 16:31
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_Conceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (((ComboBox)sender).SelectedIndex > 0)
                {
                    if (this._Concepto_Aplicar != null)
                    {
                        if (this._Concepto_Aplicar.Items.Count > 1 && !this._Concepto_Aplicar.Name.Equals(((ComboBox)sender).Name))
                            this._Concepto_Aplicar.SelectedIndex = 0;
                    }

                    this._Concepto_Aplicar = (ComboBox)sender;
                    Txt_Costo.Text = ((DataRowView)this._Concepto_Aplicar.SelectedItem).Row.ItemArray[5].ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método:[Cmb_Conceptos_SelectedIndexChanged]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion
    }
}
