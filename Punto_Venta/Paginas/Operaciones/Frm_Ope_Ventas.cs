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
using Operaciones.Cajas.Negocio;
using System.IO;
using ERP_BASE.App_Code.Controles;
using ERP_BASE.Paginas.Ventanas_Emergentes;
using ResizeableForm;
using System.Runtime.InteropServices;
using Operaciones.Recolecciones.Negocio;
using Erp_Apl_Parametros.Negocio;

namespace ERP_BASE.Paginas.Operaciones
{
    public partial class Frm_Ope_Ventas : ResizableForm
    {
        private Dictionary<String, Button> Lista_Botones;
        private DataTable Dt_Productos;
        private DataTable Dt_Pedidos;
        private JButton jBtn_Consultar_Grupos;
        private int NUMERO_PRODUCTOS = 16;
        private int VISTA = 1;
        private int Vistas = 0;
        public Frm_Ope_Pago _Frm_Ope_Pago { get; set; }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Ventas
        ///DESCRIPCIÓN          : Inicializa los campos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Frm_Ope_Ventas()
        {
            InitializeComponent();
            Inicializar_Controles();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Ventas_Load
        ///DESCRIPCIÓN          : Evento Load del formulario
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :Olimpo Alberto Cruz Amaya
        ///FECHA_MODIFICO       :09/Febrero/2015
        ///CAUSA_MODIFICACIÓN   :Se asigna una venta por default desde el inicio del form
        ///*******************************************************************************
        private void Frm_Ope_Ventas_Load(object sender, EventArgs e)
        {
            Cls_Cat_Productos_Negocio P_Productos = new Cls_Cat_Productos_Negocio();
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Detalles_Venta, false);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Productos, false);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Servicios, false);
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Totales, false);

            P_Productos.P_Estatus = "ACTIVO";
            Dt_Productos = P_Productos.Consultar_Producto_Venta();

            Habilitar_Botones_Cantidades(false);
            Btn_Nuevo.Enabled = true;
            Btn_Salir.Enabled = true;
            Cargar_Botones_Productos();
            //Cargar_Botones_Servicios();
            Lista_Botones = new Dictionary<string, Button>();
            Cargar_Botones(Lista_Botones);
            //Btn_Cantidades_Click(Btn_No1, null);

            Iniciar_Dt_Pedidos();
            Cls_Ope_Cajas_Negocio P_Cajas = new Cls_Ope_Cajas_Negocio();
            P_Cajas.P_Caja_ID = Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
            P_Cajas.P_Estatus = "ABIERTA";

            if (P_Cajas.Consultar_Cajas().Rows.Count == 0)
            {
                Pnl_Consultar_Grupo.Visible = false;
                Btn_Nuevo.Visible = false;
                Btn_Salir.Visible = false;
                MessageBox.Show(this, " No hay un turno abierto.", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID.Trim() == "")
            {
                Pnl_Consultar_Grupo.Visible = false;
                Btn_Nuevo.Visible = false;
                Btn_Salir.Visible = false;
                MessageBox.Show(this, "Usted no tiene permisos para realizar la venta.", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID.Trim() != "")
            {
                DataTable CajaActual = P_Cajas.Consultar_Cajas();
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable ParametroActual = Consulta_Parametros.Consultar_Parametros();

                //obtiene el número de caja actual 
                string No_Caja = CajaActual.Rows[0][0].ToString();
                //obtiene el id de parametro actual
                string No_Parametro = ParametroActual.Rows[0][0].ToString();
                //Obtener la cantidad tope para las recolecciones
                decimal Tope_recolecciones = Consultar_Tope_Recolecciones(No_Parametro);
                //Obtener el total de la caja actual
                decimal Total_en_caja = Consultar_Total_En_Caja(No_Caja);

                if (Total_en_caja <= Tope_recolecciones)
                {
                    Btn_Nuevo_Click(null, null);
                }
                else
                {
                    Pnl_Consultar_Grupo.Visible = false;
                    Btn_Nuevo.Visible = false;
                    Btn_Salir.Visible = false;
                    MessageBox.Show(this, "Se debe realizar una recoleccion en esta caja", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            if (VISTA == 1) { Btn_Atras.Enabled = false; }

            //Se asigna una venta por default
            Txt_No_Compuesto.Text = "1";
            Asignar_Foco_No_Compuesto();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Eliminar_Detalle_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Eliminar_Detalle
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Eliminar_Detalle_Click(object sender, EventArgs e)
        {
            try
            {
                Dt_Pedidos.Rows.Remove(Dt_Pedidos.AsEnumerable().FirstOrDefault(x => x.Field<String>("PRODUCTO_ID") == Grid_Detalles_Ventas.CurrentRow.Cells["PRODUCTO_ID"].Value.ToString()));
                Grid_Detalles_Ventas.Rows.Remove(Grid_Detalles_Ventas.CurrentRow);
            }
            catch
            {

            }
            Lbl_Total_Precio.Text = "$ " + Dt_Pedidos.AsEnumerable().Sum(x => x.Field<Decimal>("TOTAL")).ToString();
            //Asignar_Foco_Caja_Codigo_Barras();
            Asignar_Foco_No_Compuesto();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Cantidades_Click
        ///DESCRIPCIÓN          : Evento Click para los botones con las cantidades
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :Olimpo Alberto Cruz Amaya
        ///FECHA_MODIFICO       :09/Febrero/2015    
        ///CAUSA_MODIFICACIÓN   :Se borra la venta por default para asignar una nueva venta segune el boton seleccionado
        ///*******************************************************************************
        private void Btn_Cantidades_Click(object sender, EventArgs e)
        {
            TextBox Txt_Caja_Activa = Txt_No_Compuesto;//Dic_Cajas_Texto.FirstOrDefault(x => x.Value.BorderStyle == BorderStyle.FixedSingle).Value;
            if (Txt_Caja_Activa.Text.Trim() == "")
            {
                Txt_Caja_Activa.Text = ((Button)sender).Text;
            }
            else if (Txt_Caja_Activa.SelectionLength > 0)
            {
                Txt_Caja_Activa.SelectedText = ((Button)sender).Text;
            }

            else
            {
                Txt_Caja_Activa.Text = Txt_Caja_Activa.Text + ((Button)sender).Text;
            }

            //String Cantidad_Producto = "";
            //Lista_Botones.FirstOrDefault(x => x.Value == ((Button)sender)).Value.FlatStyle = FlatStyle.Flat;
            //var a = Lista_Botones.Where(x => x.Value != ((Button)sender));
            //foreach(var b in a)
            //{
            //    b.Value.FlatStyle = FlatStyle.Standard;
            //}
            ////Asignar_Foco_Caja_Codigo_Barras();

            //Cantidad_Producto = Lista_Botones.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat).Value.Text;

            ////  reinicia la caja de texto
            ////if (Btn_No_Compuesto.Text == "x")
            ////{
            ////    Btn_No_Compuesto.Text = "1";
            ////}
            ///*else*/ if (Btn_No_Compuesto.Text == "" && Cantidad_Producto == "0")// valida que no ingrese el cero
            //{
            //}
            //else
            //    Btn_No_Compuesto.Text += Lista_Botones.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat).Value.Text;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Producto_Click
        ///DESCRIPCIÓN          : Evento Click para los botones de los productos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Olimpo Alberto Cruz Amaya
        ///FECHA_MODIFICO       : 09/Febrero/2015
        ///CAUSA_MODIFICACIÓN   :La cantidad será la indicada por el compuesto (Txt_No_Compuesto)
        ///*******************************************************************************
        private void Btn_Producto_Click(object sender, EventArgs e)
        {
            String Producto_Id = ((Button)sender).Tag.ToString();
            DataRow Dr_Producto = Dt_Productos.AsEnumerable().FirstOrDefault(x => x.Field<String>(Cat_Productos.Campo_Producto_Id) == Producto_Id);
            DataRow Dr_Detalle_Existente = Dt_Pedidos.AsEnumerable().FirstOrDefault(x => x.Field<String>(Cat_Productos.Campo_Producto_Id) == Producto_Id);
            //String Cantidad = Lista_Botones.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat).Value.Text;//valor original
            String Cantidad = Txt_No_Compuesto.Text;

            //  valida que tenga informacion el boton compuesto
            if (Txt_No_Compuesto.Text.Trim() != "" && Txt_No_Compuesto.Text.Trim() != "0")
            {
                Decimal Costo = Convert.ToDecimal(Dr_Producto[Cat_Productos.Campo_Costo]);
                if (Dr_Detalle_Existente == null)
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
                    Dr_Detalle_Existente["TOTAL"] = Convert.ToDecimal(Dr_Detalle_Existente["TOTAL"]) + (Convert.ToDecimal(Cantidad) * Convert.ToDecimal(Dr_Detalle_Existente["COSTO"]));
                }
                Llenar_Grid(Dt_Pedidos);


                Btn_Cantidades_Click(Btn_No1, null);
                Txt_No_Compuesto.Text = "1";

                Lbl_Total_Precio.Text = "$ " + Dt_Pedidos.AsEnumerable().Sum(x => x.Field<Decimal>("TOTAL")).ToString();
                //Asignar_Foco_Caja_Codigo_Barras();
                Asignar_Foco_No_Compuesto();
            }
            else
            {
                MessageBox.Show(this, "Seleccione la cantidad", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Txt_No_Compuesto.Text = "1";
                Asignar_Foco_No_Compuesto();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Producto_Click
        ///DESCRIPCIÓN          : Evento Click para los botones de los productos
        ///PARAMETROS           : 
        ///CREO                 : Olimpo Alberto Cruz Amaya
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Olimpo Alberto Cruz Amaya
        ///FECHA_MODIFICO       : 26/Marzo/2015
        ///CAUSA_MODIFICACIÓN   : Se abre el menu de todoso los productos al dar click en el boton de "mas productos"
        ///
        ///*******************************************************************************
        private void Btn_Producto_Add_Click(object sender, EventArgs e)
        {

            Frm_Cat_Ventana_Busqueda_Productos Frm_Busqueda_Productos = new Frm_Cat_Ventana_Busqueda_Productos();//Variable para llamar a la venta de búsqueda de productos.
            Frm_Busqueda_Productos.ShowDialog(this);
            if (!string.IsNullOrEmpty(Frm_Busqueda_Productos.P_Producto_ID))
                Busqueda_Producto_Por_Clave(Frm_Busqueda_Productos.P_Producto_ID);
            //Asignar_Foco_Caja_Codigo_Barras();
            Asignar_Foco_No_Compuesto();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Botones_Productos
        ///DESCRIPCIÓN          : Metodo encargado de cargar la informacion de los productos en los botones de productos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Cargar_Botones_Productos()
        {
            List<DataRow> Productos = new List<DataRow>();
            Image Img_Productos = null;
            int Cont_Productos = 0;
            int Sobrante;

            Vistas = Dt_Productos.Rows.Count / NUMERO_PRODUCTOS;
            Sobrante = Dt_Productos.Rows.Count % NUMERO_PRODUCTOS;

            if (Sobrante > 0) { Vistas++; }

            int j = 1;
            for (int i = NUMERO_PRODUCTOS * (VISTA - 1); i < NUMERO_PRODUCTOS * VISTA; i++)
            {
                Productos.Add(Dt_Productos.Rows[i]);

                if (VISTA == Vistas && Sobrante == j++) { break; }
            }

            foreach (DataRow _Producto in Productos)
            {
                if (!string.IsNullOrEmpty(_Producto[Cat_Productos.Campo_Ruta_Imagen].ToString()) &&
                    File.Exists(_Producto[Cat_Productos.Campo_Ruta_Imagen].ToString()))
                    Img_Productos = Image.FromFile(_Producto[Cat_Productos.Campo_Ruta_Imagen].ToString());
                else
                    Img_Productos = global::ERP_BASE.Properties.Resources.img_no_disponible;

                switch (Cont_Productos++)
                {
                    case 0:
                        Btn_Producto1 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto1);
                        // Btn_Producto1.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto1.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto1.Visible = true;
                        break;
                    case 1:
                        Btn_Producto2 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto2);
                        //Btn_Producto2.Text = _Producto[Cat_Productos.Campo_Nombre].ToString()+ "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto2.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto2.Visible = true;
                        break;
                    case 2:
                        Btn_Producto3 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto3);
                        //Btn_Producto3.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto3.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto3.Visible = true;
                        break;
                    case 3:
                        Btn_Producto4 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto4);
                        //Btn_Producto4.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto4.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto4.Visible = true;
                        break;
                    case 4:
                        Btn_Producto5 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto5);
                        //Btn_Producto5.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto5.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto5.Visible = true;
                        break;
                    case 5:
                        Btn_Producto6 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto6);
                        //Btn_Producto6.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto6.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto6.Visible = true;
                        break;
                    case 6:
                        Btn_Producto7 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto7);
                        //Btn_Producto7.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto7.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto7.Visible = true;
                        break;
                    case 7:
                        Btn_Producto8 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto8);
                        //Btn_Producto8.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto8.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto8.Visible = true;
                        break;
                    case 8:
                        Btn_Producto9 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto9);
                        //Btn_Producto9.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto9.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto9.Visible = true;
                        break;

                    case 9:
                        Btn_Producto10 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto10);
                        //Btn_Producto10.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto10.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto10.Visible = true;
                        break;

                    case 10:
                        Btn_Producto11 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto11);
                        //Btn_Producto11.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto11.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto11.Visible = true;
                        break;

                    case 11:
                        Btn_Producto12 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto12);
                        //Btn_Producto12.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto12.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto12.Visible = true;
                        break;

                    case 12:
                        Btn_Producto13 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto13);
                        //Btn_Producto13.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto13.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto13.Visible = true;
                        break;

                    case 13:
                        Btn_Producto14 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto14);
                        //Btn_Producto14.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto14.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto14.Visible = true;
                        break;

                    case 14:
                        Btn_Producto15 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto15);
                        //Btn_Producto15.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto15.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto15.Visible = true;
                        break;

                    case 15:
                        Btn_Producto16 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto16);
                        //Btn_Producto16.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto16.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto16.Visible = true;
                        break;


                    case 16:
                        Btn_Producto17 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto17);
                        //Btn_Producto17.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto17.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto17.Visible = true;
                        break;

                    case 17:
                        Btn_Producto18 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto18);
                        //Btn_Producto18.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto18.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto18.Visible = true;
                        break;

                    case 18:
                        Btn_Producto19 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto19);
                        //Btn_Producto19.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto19.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto19.Visible = true;
                        break;

                    case 19:
                        Btn_Producto20 = new JButton(Img_Productos, new Size(120, 125), new Size(95, 100), new Point(19, 10), _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Productos.Controls.Add(Btn_Producto20);
                        //Btn_Producto19.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Producto20.Tag = _Producto[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Producto20.Visible = true;
                        break;

                    default:
                        break;
                }
            }

            Cont_Productos = 1;
            Array.ForEach(Pnl_Productos.Controls.OfType<JButton>().ToArray(), boton =>
            {
                boton.Font = new System.Drawing.Font("Console", 10, FontStyle.Regular);
                boton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                boton.Name = "Btn_Producto" + Cont_Productos;
                Cont_Productos = Cont_Productos + 1;
                if (boton.Tag.ToString() == "+")
                    boton.Click += new System.EventHandler(this.Btn_Producto_Add_Click);
                else boton.Click += new System.EventHandler(this.Btn_Producto_Click);
            });

            if (Vistas == VISTA) { Btn_Siguiente.Enabled = false; }

            Pnl_Productos.Visible = true;
        }

        ///*******************************************************************************************************
        ///NOMBRE_FUNCIÓN: Cargar_Imagen
        ///DESCRIPCIÓN: Valida que existe el archivo en la ruta especificada y asigna la imagen al botón especificado
        ///PARÁMETROS:
        /// 		1. Ruta: cadana de caracteres con la ruta al archivo con el logotipo del banco
        /// 		2. Obj_Boton: botón al que se va a asignar la imagen
        ///CREO: Roberto González Oseguera
        ///FECHA_CREO: 23-oct-2013
        ///MODIFICÓ: 
        ///FECHA_MODIFICÓ: 
        ///CAUSA_MODIFICACIÓN: 
        ///*******************************************************************************************************
        private void Cargar_Imagen(string Ruta, Button Obj_Boton)
        {
            FileStream Archivo_Imagen = null;
            try
            {
                // validar que se haya proporcionado una ruta y un control botón
                if (!string.IsNullOrEmpty(Ruta) && Obj_Boton != null)
                {
                    // validar que exista el archivo
                    if (File.Exists(Ruta))
                    {
                        // leer archivo de imagen como filestream y cargar al control Pic_Logo para que no bloquear el archivo
                        Archivo_Imagen = new FileStream(Ruta, FileMode.Open, FileAccess.Read);
                        Obj_Boton.Image = Image.FromStream(Archivo_Imagen);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                // validar que Archivo_Imagen sea diferente de nulo
                if (Archivo_Imagen != null)
                {
                    Archivo_Imagen.Close();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Botones_Servicios
        ///DESCRIPCIÓN          : Metodo encargado de cargar la informacion de los servicios 
        ///                       en los botones de servicios
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Cargar_Botones_Servicios()
        {
            Image Img_Servicios = null;
            int Cont_Servicios = 0;
            Image Img_Plus = null;

            IEnumerable<DataRow> Servicios = Dt_Productos
                .AsEnumerable()
                .Where(_Serv => _Serv.Field<String>(Cat_Productos.Campo_Tipo).Equals("Servicio") && !_Serv.Field<string>(Cat_Productos.Campo_Tipo_Servicio).Equals("ESTACIONAMIENTO")
                    && _Serv.Field<String>(Cat_Productos.Campo_Estatus).Equals("ACTIVO"));

            foreach (DataRow _Servicio in Servicios)
            {
                if (!string.IsNullOrEmpty(_Servicio[Cat_Productos.Campo_Ruta_Imagen].ToString()) &&
                    File.Exists(_Servicio[Cat_Productos.Campo_Ruta_Imagen].ToString()))
                    Img_Servicios = Image.FromFile(_Servicio[Cat_Productos.Campo_Ruta_Imagen].ToString());
                else
                    Img_Servicios = global::ERP_BASE.Properties.Resources.img_no_disponible;

                switch (Cont_Servicios++)
                {
                    case 0:
                        Btn_Servicio1 = new JButton(Img_Servicios, new Size(102, 96), new Size(72, 60), new Point(15, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Servicios.Controls.Add(Btn_Servicio1);
                        //Btn_Servicio1.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Servicio1.Tag = _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Servicio1.Visible = true;
                        break;
                    case 1:
                        Btn_Servicio2 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Servicios.Controls.Add(Btn_Servicio2);
                        //Btn_Servicio2.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Servicio2.Tag = _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Servicio2.Visible = true;
                        break;
                    case 2:
                        Btn_Servicio3 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                        Pnl_Servicios.Controls.Add(Btn_Servicio3);
                        //Btn_Servicio3.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                        Btn_Servicio3.Tag = _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                        Btn_Servicio3.Visible = true;
                        break;
                    //case 3:
                    //    Btn_Servicio4 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio4);
                    //    //Btn_Servicio4.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio4.Tag =  _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio4.Visible = true;
                    //    break;
                    //case 4:
                    //    Btn_Servicio5 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio5);
                    //    //Btn_Servicio5.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio5.Tag =  _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio5.Visible = true;
                    //    break;
                    //case 5:
                    //    Btn_Servicio6 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio6);
                    //    //Btn_Servicio6.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio6.Tag = _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio6.Visible = true;
                    //    break;
                    //case 6:
                    //    Btn_Servicio7 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio7);
                    //    //Btn_Servicio7.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio7.Tag =  _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio7.Visible = true;
                    //    break;
                    //case 7:
                    //    Btn_Servicio8 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio8);
                    //    //Btn_Servicio8.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio8.Tag = _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio8.Visible = true;
                    //    break;
                    //case 8:
                    //    Btn_Servicio9 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio9);
                    //    //Btn_Servicio9.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio9.Tag =  _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio9.Visible = true;
                    //    break;
                    //case 9:
                    //    Btn_Servicio10 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio10);
                    //    //Btn_Servicio10.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio10.Tag =  _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio10.Visible = true;
                    //    break;
                    //case 10:
                    //    Btn_Servicio11 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio11);
                    //    //Btn_Servicio11.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio11.Tag = _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio11.Visible = true;
                    //    break;
                    //case 11:
                    //    Btn_Servicio12 = new JButton(Img_Servicios, new Size(102, 96), new Size(82, 70), new Point(10, 5), _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00"), true);
                    //    Pnl_Servicios.Controls.Add(Btn_Servicio12);
                    //    //Btn_Servicio12.Text = _Servicio[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Servicio[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                    //    Btn_Servicio12.Tag =  _Servicio[Cat_Productos.Campo_Producto_Id].ToString();
                    //    Btn_Servicio12.Visible = true;
                    //    break;
                    default:
                        break;
                }
            }

            Cont_Servicios = 1;
            Array.ForEach(Pnl_Servicios.Controls.OfType<JButton>().ToArray(), boton =>
            {
                boton.Font = new System.Drawing.Font("Console", 10, FontStyle.Regular);
                boton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                boton.Name = "Btn_Servicio" + Cont_Servicios;
                Cont_Servicios = Cont_Servicios + 1;
                boton.Click += new System.EventHandler(this.Btn_Producto_Click);
            });


            if (Cont_Servicios >= 3)
            {
                // Crea un boton que siemrpe estara presente el cual accede a la pantalla para ver todos los productos.
                Img_Plus = global::ERP_BASE.Properties.Resources.sias_add; //Contiene el icono de "+"
                Btn_Servicio4 = new JButton(Img_Plus, new Size(102, 96), new Size(82, 70), new Point(10, 5), "Buscar servicios", true);
                Pnl_Servicios.Controls.Add(Btn_Servicio4);
                //Btn_Servicio4.Text = _Producto[Cat_Productos.Campo_Nombre].ToString() + "\n $" + Convert.ToDecimal(_Producto[Cat_Productos.Campo_Costo].ToString()).ToString("###,##0.00");
                Btn_Servicio4.Tag = "+";
                Btn_Servicio4.Visible = true;

            }

            Cont_Servicios = 1;
            Array.ForEach(Pnl_Servicios.Controls.OfType<JButton>().ToArray(), boton =>
            {
                boton.Font = new System.Drawing.Font("Console", 10, FontStyle.Regular);
                boton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                boton.Name = "Btn_Servicio" + Cont_Servicios;
                Cont_Servicios = Cont_Servicios + 1;
                if (boton.Tag.ToString() == "+")
                    boton.Click += new System.EventHandler(this.Btn_Producto_Add_Click);
                else boton.Click += new System.EventHandler(this.Btn_Producto_Click);
            });
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Nuevo
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             : Olimpo Alberto Cruz Amaya
        ///FECHA_MODIFICO       : 09/Febrero/2015
        ///CAUSA_MODIFICACIÓN   : Se asigna la cantidad de "1" venta por default
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            if (Btn_Nuevo.Text == "Nuevo")
            {
                Btn_Nuevo.Text = "Terminar";
                Btn_Salir.Text = "Limpiar";
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Detalles_Venta, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Productos, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Servicios, true);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Totales, true);
                Habilitar_Botones_Cantidades(true);
            }
            else
            {
                if (Grid_Detalles_Ventas.Rows.Count > 0)
                {
                    if (_Frm_Ope_Pago == null)
                    {
                        //Btn_No_Compuesto.Text = "x";
                        Txt_No_Compuesto.Text = "1"; //1 venta por default
                        Asignar_Foco_No_Compuesto(); //se selecciona el texto
                        Frm_Ope_Pago Frm_Pago = new Frm_Ope_Pago();
                        Frm_Pago.MdiParent = this.ParentForm;
                        Frm_Pago.Set_Dt_Detalles_Venta(Dt_Pedidos);

                        this.Hide();
                        Frm_Pago.Set_Frm_Venta(this);
                        Frm_Pago.Show();

                    }
                    else
                    {
                        Frm_Ope_Pago Frm_Pago = new Frm_Ope_Pago();
                        Frm_Pago.No_Venta = this._Frm_Ope_Pago.No_Venta;
                        Frm_Pago.Persona_Tramita = this._Frm_Ope_Pago.Persona_Tramita;
                        Frm_Pago.Empresa = this._Frm_Ope_Pago.Empresa;
                        Frm_Pago.Fecha_Tramite = this._Frm_Ope_Pago.Fecha_Tramite;
                        Frm_Pago.Fecha_Inicio_Vigencia = this._Frm_Ope_Pago.Fecha_Inicio_Vigencia;
                        Frm_Pago.Fecha_Termino_Vigencia = this._Frm_Ope_Pago.Fecha_Termino_Vigencia;
                        Frm_Pago.Aplican_Dias_Festivos = this._Frm_Ope_Pago.Aplican_Dias_Festivos;
                        Frm_Pago.Total = this._Frm_Ope_Pago.Total;
                        _Frm_Ope_Pago.Set_Dt_Detalles_Venta(Dt_Pedidos);


                        Frm_Pago.MdiParent = this.ParentForm;
                        Frm_Pago.Set_Dt_Detalles_Venta(Dt_Pedidos);
                        this.Hide();

                        Frm_Pago.Set_Frm_Venta(this);
                        this._Frm_Ope_Pago = Frm_Pago;
                        this._Frm_Ope_Pago.Show();
                    }
                }
                else
                {
                    MessageBox.Show(null, "Ingrese los productos o servicios.", "Error - Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Habilitar_Botones_Cantidades
        ///DESCRIPCIÓN          : Habilita o deshabilita los botones de cantidades.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Habilitar_Botones_Cantidades(bool Estatus)
        {
            Btn_No1.Enabled = Estatus;
            Btn_No2.Enabled = Estatus;
            Btn_No3.Enabled = Estatus;
            Btn_No4.Enabled = Estatus;
            Btn_No5.Enabled = Estatus;
            Btn_No6.Enabled = Estatus;
            Btn_No7.Enabled = Estatus;
            Btn_No8.Enabled = Estatus;
            Btn_No9.Enabled = Estatus;
            Btn_No0.Enabled = Estatus;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Botones
        ///DESCRIPCIÓN          : Agrega los botones de cantidades al diccionario
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Cargar_Botones(Dictionary<String, Button> Arreglo_Botones)
        {
            Arreglo_Botones.Add(Btn_No1.Name, Btn_No1);
            Arreglo_Botones.Add(Btn_No2.Name, Btn_No2);
            Arreglo_Botones.Add(Btn_No3.Name, Btn_No3);
            Arreglo_Botones.Add(Btn_No4.Name, Btn_No4);
            Arreglo_Botones.Add(Btn_No5.Name, Btn_No5);
            Arreglo_Botones.Add(Btn_No6.Name, Btn_No6);
            Arreglo_Botones.Add(Btn_No7.Name, Btn_No7);
            Arreglo_Botones.Add(Btn_No8.Name, Btn_No8);
            Arreglo_Botones.Add(Btn_No9.Name, Btn_No9);
            Arreglo_Botones.Add(Btn_No0.Name, Btn_No0);

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
            Dt_Pedidos = new DataTable();
            Dt_Pedidos.Columns.Add();
            Dt_Pedidos.Columns.Add("CANTIDAD", typeof(Decimal));
            Dt_Pedidos.Columns.Add("PRODUCTO", typeof(String));
            Dt_Pedidos.Columns.Add("TOTAL", typeof(Decimal));
            Dt_Pedidos.Columns.Add("PRODUCTO_ID", typeof(String));
            Dt_Pedidos.Columns.Add("COSTO", typeof(Decimal));
            Dt_Pedidos.Columns.Add("TIPO", typeof(String));
            Dt_Pedidos.Columns.Add("IMPRIMIR", typeof(String));
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Llenar_Grid
        ///DESCRIPCIÓN          : Carga la informacion del DataTable en el grid
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Llenar_Grid(DataTable Dt_Cargar)
        {
            Grid_Detalles_Ventas.Rows.Clear();
            int Cont_Detalles = 0;
            foreach (DataRow Dr_Cargar in Dt_Cargar.Rows)
            {
                Grid_Detalles_Ventas.Rows.Add();
                Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["CANTIDAD"].Value = Dr_Cargar["CANTIDAD"].ToString();
                Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["PRODUCTO"].Value = Dr_Cargar["PRODUCTO"].ToString();
                Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["TOTAL"].Value = string.Format("{0:c}", Dr_Cargar["TOTAL"]);
                Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["PRODUCTO_ID"].Value = Dr_Cargar["PRODUCTO_ID"].ToString();
                Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["COSTO"].Value = string.Format("{0:c}", Dr_Cargar["COSTO"]);
                Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["TIPO"].Value = Dr_Cargar["TIPO"].ToString();
                Grid_Detalles_Ventas.Rows[Cont_Detalles].Cells["IMPRIMIR"].Value = Dr_Cargar["IMPRIMIR"].ToString();
                Cont_Detalles++;
            }

            Array.ForEach(Grid_Detalles_Ventas.Rows.OfType<DataGridViewRow>().ToArray(), fila =>
            {
                fila.Height = 50;
                Array.ForEach(fila.Cells.OfType<DataGridViewCell>().ToArray(), celda =>
                {
                    celda.Style.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    celda.Style.BackColor = Color.WhiteSmoke;
                });
            });
            Array.ForEach(Grid_Detalles_Ventas.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
            {
                columna.HeaderCell.Style.Font = new Font("Tahoma", 10, FontStyle.Regular);
            });
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Limpiar
        ///DESCRIPCIÓN          : Limpia el grid y el campo de precio total
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 11/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Limpiar()
        {
            Iniciar_Dt_Pedidos();
            Lbl_Total_Precio.Text = "$ 0.00";
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
            if (Btn_Salir.Text == "Salir")
            {
                this.Close();
            }
            else
            {
                Txt_No_Compuesto.Text = "";
                Btn_Cantidades_Click(Btn_No1, null); // Le asigna el valor de "1" al sender
                Habilitar_Botones_Cantidades(false);
                Btn_Salir.Text = "Salir";
                Iniciar_Dt_Pedidos();
                Lbl_Total_Precio.Text = "$ 0.00";
                Grid_Detalles_Ventas.Rows.Clear();
                Btn_Nuevo.Text = "Nuevo";
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Detalles_Venta, false);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Productos, false);
                Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Servicios, false);
                Btn_Nuevo_Click(null, null);
                this._Frm_Ope_Pago = null;

                Asignar_Foco_No_Compuesto();
                //Asignar_Foco_Caja_Codigo_Barras();
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
            Cls_Ope_Cajas_Negocio P_Cajas = new Cls_Ope_Cajas_Negocio();
            P_Cajas.P_Caja_ID = Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
            P_Cajas.P_Estatus = "ABIERTA";
            DataTable CajaActual = P_Cajas.Consultar_Cajas();
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable ParametroActual = Consulta_Parametros.Consultar_Parametros();

            //obtiene el número de caja actual 
            string No_Caja = CajaActual.Rows[0][0].ToString();
            //obtiene el id de parametro actual
            string No_Parametro = ParametroActual.Rows[0][0].ToString();
            //Obtener la cantidad tope para las recolecciones
            decimal Tope_recolecciones = Consultar_Tope_Recolecciones(No_Parametro);
            //Obtener el total de la caja actual
            decimal Total_en_caja = Consultar_Total_En_Caja(No_Caja);
            //Obtener el total de la venta actual 
            decimal Total_Venta_Actual = Dt_Pedidos.AsEnumerable().Sum(x => x.Field<Decimal>("TOTAL"));

            Btn_Salir_Click(null, null);
            //MessageBox.Show(this, "Alta exitosa!", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Total_en_caja > Tope_recolecciones)
            {
                Pnl_Consultar_Grupo.Visible = false;
                Btn_Nuevo.Visible = false;
                Btn_Salir.Visible = false;
                Habilitar_Botones_Cantidades(false);
                MessageBox.Show(this, "Se debe realizar una recoleccion en esta caja", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        /// <summary>
        /// Nombre: Inicializar_Controles
        /// 
        /// Descripción: Método que carga los controles de la página.
        /// 
        /// Fecha Creo: Juan Alberto Hernández Negrete.
        /// Usuario Creo: 24 Octubre 2013 12:31 p.m.
        /// Fecha Creo:
        /// Usuario Modifico:
        /// </summary>
        private void Inicializar_Controles()
        {
            //Creamos el botón que se utilizara para consultar los grupos.
            this.jBtn_Consultar_Grupos = new JButton(global::ERP_BASE.Properties.Resources.grupos, new Size(104, 64));
            //Agregamos el evento click al botón que mostrara la ventana de búsqueda de grupos.
            this.jBtn_Consultar_Grupos.Click += (sender, e) =>
            {
                Frm_Cat_Ventana_Busqueda_Grupos Ven_Busqueda_Grupos = new Frm_Cat_Ventana_Busqueda_Grupos();
                _Frm_Ope_Pago = new Frm_Ope_Pago();
                //Mostrar ventana de consulta de grupos.
                Ven_Busqueda_Grupos.ShowDialog(this);
                if (Ven_Busqueda_Grupos.Hacer_Busqueda)
                {
                    #region (Establecer Datos del Grupo)
                    _Frm_Ope_Pago.No_Venta = Ven_Busqueda_Grupos.No_Venta;
                    _Frm_Ope_Pago.Persona_Tramita = Ven_Busqueda_Grupos.Persona_Tramita;
                    _Frm_Ope_Pago.Empresa = Ven_Busqueda_Grupos.Empresa;
                    _Frm_Ope_Pago.Fecha_Tramite = string.Format("{0:dd/MM/yyyy}", Ven_Busqueda_Grupos.Fecha_Tramite);
                    _Frm_Ope_Pago.Fecha_Inicio_Vigencia = string.Format("{0:dd/MM/yyyy}", Ven_Busqueda_Grupos.Fecha_Inicio_Vigencia);
                    _Frm_Ope_Pago.Fecha_Termino_Vigencia = string.Format("{0:dd/MM/yyyy}", Ven_Busqueda_Grupos.Fecha_Termino_Vigencia);
                    _Frm_Ope_Pago.Aplican_Dias_Festivos = Ven_Busqueda_Grupos.Aplica_Dias_Festivos;
                    _Frm_Ope_Pago.Total = Convert.ToDecimal(string.IsNullOrEmpty(Ven_Busqueda_Grupos.Total) ? "0" : Ven_Busqueda_Grupos.Total);
                    Dt_Pedidos = Ven_Busqueda_Grupos.Dt_Grupos;
                    _Frm_Ope_Pago.Set_Dt_Detalles_Venta(Dt_Pedidos);
                    #endregion

                    #region (Datos en Pantalla)
                    Llenar_Grid(Ven_Busqueda_Grupos.Dt_Grupos);
                    Lbl_Total_Precio.Text = "$ " + string.Format("{0:n}", Ven_Busqueda_Grupos.Total);
                    #endregion

                    #region (Enviar Pago)
                    _Frm_Ope_Pago.MdiParent = this.ParentForm;
                    _Frm_Ope_Pago.Set_Frm_Venta(this);
                    this.Hide();
                    _Frm_Ope_Pago.Show();
                    #endregion
                }
                else { this._Frm_Ope_Pago = null; }
            };
            this.Pnl_Consultar_Grupo.Controls.Add(this.jBtn_Consultar_Grupos);

            Array.ForEach(Grid_Detalles_Ventas.Columns.OfType<DataGridViewColumn>().ToArray(), columna =>
            {
                columna.HeaderCell.Style.Font = new Font("Tahoma", 10, FontStyle.Regular);
            });
        }


        private JButton Btn_Producto1;
        private JButton Btn_Producto2;
        private JButton Btn_Producto3;
        private JButton Btn_Producto4;
        private JButton Btn_Producto5;
        private JButton Btn_Producto6;
        private JButton Btn_Producto7;
        private JButton Btn_Producto8;
        private JButton Btn_Producto9;
        private JButton Btn_Producto10;
        private JButton Btn_Producto11;
        private JButton Btn_Producto12;
        private JButton Btn_Producto13;
        private JButton Btn_Producto14;
        private JButton Btn_Producto15;
        private JButton Btn_Producto16;
        private JButton Btn_Producto17;
        private JButton Btn_Producto18;
        private JButton Btn_Producto19;
        private JButton Btn_Producto20;

        private JButton Btn_Servicio1;
        private JButton Btn_Servicio2;
        private JButton Btn_Servicio3;
        private JButton Btn_Servicio4;

        /// <summary>
        /// Nombre: Txt_Codigo_Barras_KeyPress
        /// 
        /// Descripción: Método que se ejecuta cuando se pulsa alguna tecla.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 11:33 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_Codigo_Barras_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Return)
                    Busqueda_Producto();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Txt_Codigo_Barras_KeyPress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Busqueda_Producto
        /// 
        /// Descripción: Método que realiza la búsqueda del producto por código
        ///              y lo agrega ala listado de productos y servicios.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 11:33 Hrs.
        /// Usuario Modifico: Olimpo Alberto Cruz Amaya
        /// Fecha Modifico: 09/Febrero/2015
        /// Modificación: La cantidad es igual al no de compuesto 
        /// </summary>
        private void Busqueda_Producto()
        {
            Cls_Cat_Productos_Negocio Obj_Productos = new Cls_Cat_Productos_Negocio();//Variable de negocios para realizar peticiones a la clase de datos.
            DataTable Dt_Productos = null;//Estructura para almacenar el producto consultado.
            DataRow Dr_Detalle_Existente = null;//Objeto que servira para almacenar el registro del producto si el mismo ya se encuentra agregado.
            String _Cantidad = Txt_No_Compuesto.Text;//Lista_Botones.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat).Value.Text;//Indica que cantidad de producto se agregara al listado.
            decimal _Costo = 0.0M;//Variable que almacenara el costo unitario del producto.
            int _Cantidad_Productos = 0;//Variable que almacena la cantidad de producto que se agregara al listado.
            string _Producto_ID = string.Empty;//Identificador del producto.
            string _Nombre = string.Empty;//Variable que almacenara el nombre del producto.
            string _Tipo = string.Empty;//Variable que indicara el tipo de porducto que se agregara al listado.

            try
            {
                //Obtenemos la cantidad de productos o servicios que se agregaran al listado.
                _Cantidad_Productos = Convert.ToInt32(string.IsNullOrEmpty(_Cantidad) ? "0" : _Cantidad);

                //Obj_Productos.P_Codigo = Txt_Codigo_Barras.Text.Trim();
                Dt_Productos = Obj_Productos.Consultar_Producto_Venta();

                //Obtenemos los datos del producto consultado.
                Array.ForEach(Dt_Productos.Rows.OfType<DataRow>().ToArray(), fila =>
                {
                    _Producto_ID = fila.IsNull(Cat_Productos.Campo_Producto_Id) ? string.Empty : fila.Field<string>(Cat_Productos.Campo_Producto_Id);
                    _Nombre = fila.IsNull(Cat_Productos.Campo_Nombre) ? string.Empty : fila.Field<string>(Cat_Productos.Campo_Nombre);
                    _Costo = fila.IsNull(Cat_Productos.Campo_Costo) ? 0.0M : fila.Field<decimal>(Cat_Productos.Campo_Costo);
                    _Tipo = fila.IsNull(Cat_Productos.Campo_Tipo) ? string.Empty : fila.Field<string>(Cat_Productos.Campo_Tipo);
                });

                //Consultamos y obtenemos los datos del producto si el mismo ya fue agregado previamente.
                Dr_Detalle_Existente = Dt_Pedidos.AsEnumerable().FirstOrDefault(x => x.Field<String>(Cat_Productos.Campo_Producto_Id) == _Producto_ID);

                if (Dr_Detalle_Existente == null)
                {
                    DataRow Dr_Producto_Agregar = Dt_Pedidos.NewRow();
                    Dr_Producto_Agregar["CANTIDAD"] = _Cantidad_Productos;
                    Dr_Producto_Agregar["PRODUCTO"] = _Nombre;
                    Dr_Producto_Agregar["TOTAL"] = (_Costo * _Cantidad_Productos);
                    Dr_Producto_Agregar["PRODUCTO_ID"] = _Producto_ID;
                    Dr_Producto_Agregar["COSTO"] = _Costo;
                    Dr_Producto_Agregar["TIPO"] = _Tipo;
                    Dr_Producto_Agregar["IMPRIMIR"] = string.Empty;
                    Dt_Pedidos.Rows.Add(Dr_Producto_Agregar);
                }
                else
                {
                    Dr_Detalle_Existente["CANTIDAD"] = Convert.ToDecimal(Dr_Detalle_Existente["CANTIDAD"]) + _Cantidad_Productos;
                    Dr_Detalle_Existente["TOTAL"] = Convert.ToDecimal(Dr_Detalle_Existente["TOTAL"]) + (Convert.ToDecimal(_Cantidad_Productos) * Convert.ToDecimal(Dr_Detalle_Existente["COSTO"])); ;
                }

                //Cargamos el producto al listado.
                Llenar_Grid(Dt_Pedidos);
                //Actualizamos el total de la venta.
                Lbl_Total_Precio.Text = "$ " + Dt_Pedidos.AsEnumerable().Sum(x => x.Field<Decimal>("TOTAL")).ToString();
                //Se asigna nuevamente el foco a la caja de texto que lee el código de barras del producto.
                //Asignar_Foco_Caja_Codigo_Barras();
                Asignar_Foco_No_Compuesto();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Busqueda_Producto]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Busqueda_Producto_Por_Clave
        /// 
        /// Descripción: Método que realiza la búsqueda del producto por código
        ///              y lo agrega ala listado de productos y servicios.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 11:33 Hrs.
        /// Usuario Modifico: Olimpo Alberto Cruz Amaya
        /// Fecha Modifico: 09/Febrero/2015
        /// Modificación: La cantidad es igual al no de compuesto 
        /// </summary>
        private void Busqueda_Producto_Por_Clave(string Producto_ID)
        {
            Cls_Cat_Productos_Negocio Obj_Productos = new Cls_Cat_Productos_Negocio();//Variable de negocios para realizar peticiones a la clase de datos.
            DataTable Dt_Productos = null;//Estructura para almacenar el producto consultado.
            DataRow Dr_Detalle_Existente = null;//Objeto que servira para almacenar el registro del producto si el mismo ya se encuentra agregado.
            //String _Cantidad = Lista_Botones.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat).Value.Text;//Indica que cantidad de producto se agregara al listado.
            String _Cantidad = Txt_No_Compuesto.Text;//Indica que cantidad de producto se agregara al listado.
            decimal _Costo = 0.0M;//Variable que almacenara el costo unitario del producto.
            int _Cantidad_Productos = 0;//Variable que almacena la cantidad de producto que se agregara al listado.
            string _Producto_ID = string.Empty;//Identificador del producto.
            string _Nombre = string.Empty;//Variable que almacenara el nombre del producto.
            string _Tipo = string.Empty;//Variable que indicara el tipo de porducto que se agregara al listado.

            try
            {
                //Obtenemos la cantidad de productos o servicios que se agregaran al listado.
                _Cantidad_Productos = Convert.ToInt32(string.IsNullOrEmpty(_Cantidad) ? "0" : _Cantidad);

                Obj_Productos.P_Producto_Id = Producto_ID;
                Dt_Productos = Obj_Productos.Consultar_Producto_Venta();

                //Obtenemos los datos del producto consultado.
                Array.ForEach(Dt_Productos.Rows.OfType<DataRow>().ToArray(), fila =>
                {
                    _Producto_ID = fila.IsNull(Cat_Productos.Campo_Producto_Id) ? string.Empty : fila.Field<string>(Cat_Productos.Campo_Producto_Id);
                    _Nombre = fila.IsNull(Cat_Productos.Campo_Nombre) ? string.Empty : fila.Field<string>(Cat_Productos.Campo_Nombre);
                    _Costo = fila.IsNull(Cat_Productos.Campo_Costo) ? 0.0M : fila.Field<decimal>(Cat_Productos.Campo_Costo);
                    _Tipo = fila.IsNull(Cat_Productos.Campo_Tipo) ? string.Empty : fila.Field<string>(Cat_Productos.Campo_Tipo);
                });

                //Consultamos y obtenemos los datos del producto si el mismo ya fue agregado previamente.
                Dr_Detalle_Existente = Dt_Pedidos.AsEnumerable().FirstOrDefault(x => x.Field<String>(Cat_Productos.Campo_Producto_Id) == _Producto_ID);

                if (Dr_Detalle_Existente == null)
                {
                    DataRow Dr_Producto_Agregar = Dt_Pedidos.NewRow();
                    Dr_Producto_Agregar["CANTIDAD"] = _Cantidad_Productos;
                    Dr_Producto_Agregar["PRODUCTO"] = _Nombre;
                    Dr_Producto_Agregar["TOTAL"] = (_Costo * _Cantidad_Productos);
                    Dr_Producto_Agregar["PRODUCTO_ID"] = _Producto_ID;
                    Dr_Producto_Agregar["COSTO"] = _Costo;
                    Dr_Producto_Agregar["TIPO"] = _Tipo;
                    Dr_Producto_Agregar["IMPRIMIR"] = string.Empty;
                    Dt_Pedidos.Rows.Add(Dr_Producto_Agregar);
                }
                else
                {
                    Dr_Detalle_Existente["CANTIDAD"] = Convert.ToDecimal(Dr_Detalle_Existente["CANTIDAD"]) + _Cantidad_Productos;
                    Dr_Detalle_Existente["TOTAL"] = Convert.ToDecimal(Dr_Detalle_Existente["TOTAL"]) + (Convert.ToDecimal(_Cantidad_Productos) * Convert.ToDecimal(Dr_Detalle_Existente["COSTO"])); ;
                }

                //Cargamos el producto al listado.
                Llenar_Grid(Dt_Pedidos);
                //Actualizamos el total de la venta.
                Lbl_Total_Precio.Text = "$ " + Dt_Pedidos.AsEnumerable().Sum(x => x.Field<Decimal>("TOTAL")).ToString();
                //Se asigna nuevamente el foco a la caja de texto que lee el código de barras del producto.
                //Asignar_Foco_Caja_Codigo_Barras();
                Asignar_Foco_No_Compuesto();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Busqueda_Producto]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Asignar_Foco_Caja_Codigo_Barras
        /// 
        /// Descripción: Método que le asigna el foco de la pantalla a la
        ///              caja de texto que leera el códifgo de barras del
        ///              producto o servicio.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 11:33 Hrs.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Asignar_Foco_Caja_Codigo_Barras()
        {
            try
            {
                Txt_Codigo_Barras.Text = string.Empty;//Limpiamos la caja que lee el código.
                this.ActiveControl = Txt_Codigo_Barras;//Le indicamos al formulario que el boton activo será la caja del código.
                Txt_Codigo_Barras.Focus();//Asignamos el foco a la caja que lee el código del producto.
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Asignar_Foco_Caja_Codigo_Barras]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: ProcessCmdKey
        /// 
        /// Descripcion: Método que reconoce el evento keypress sobre la ventana
        ///              y detecta la tecla pulsado y llama al procedimiento que
        ///              ejecutara la tarea programada.
        /// 
        /// Usuario Creo: Juan Alberto Hernández Negrete.
        /// Fecha Creo: 21 Noviembre 2013 14:09 Hrs.
        /// Usuario Modifico: Olimpo Alberto Cruz Amaya
        /// Fecha Modifico: 09/Enero/2015
        /// Modificación: Se asigna el foco al No de Compuesto 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            Frm_Cat_Ventana_Busqueda_Productos Frm_Busqueda_Productos = new Frm_Cat_Ventana_Busqueda_Productos();//Variable para llamar a la venta de búsqueda de productos.
            Frm_Ope_Facturacion_Electronica Frm_Solicitud_Facturacion = new Frm_Ope_Facturacion_Electronica();//Variable para llamar a la venta de búsqueda de productos.

            switch (keys)
            {
                case Keys.F1:
                    //MessageBox.Show(this, "En esta opción se mostrara la ayuda del sistema.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                case Keys.F2:
                    Frm_Busqueda_Productos.ShowDialog(this);
                    if (!string.IsNullOrEmpty(Frm_Busqueda_Productos.P_Producto_ID))
                        Busqueda_Producto_Por_Clave(Frm_Busqueda_Productos.P_Producto_ID);
                    //Asignar_Foco_Caja_Codigo_Barras();
                    Asignar_Foco_No_Compuesto();
                    return false;
                case Keys.F3:
                    Frm_Solicitud_Facturacion.ShowDialog(this);
                    return false;
                case Keys.End:
                    Btn_Nuevo_Click(new object(), new EventArgs());
                    return false;
            }
            return false;
        }

        private void Btn_Borrar_Cantidad_Click(object sender, EventArgs e)
        {
            Txt_No_Compuesto.Text = "";
        }

        /// <summary>
        /// Nombre: Consultar_Total_En_Caja
        /// 
        /// Descripción: Método que obtiene el total de efectivo de la caja.
        /// 
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 30 Enero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private decimal Consultar_Total_En_Caja(string Numero_de_Caja)
        {
            Cls_Ope_Recolecciones_Negocio Obj_Recolecciones = new Cls_Ope_Recolecciones_Negocio();//Variable para realizar peticiones a la clase de datos.
            DataTable Dt_Datos_Caja = null;
            string Total_En_Caja_String = String.Empty;

            Obj_Recolecciones.P_No_Caja = Numero_de_Caja;
            Dt_Datos_Caja = Obj_Recolecciones.Consultar_Consecutivo_Recoleccion_Por_Caja_Turno();

            if (Dt_Datos_Caja is DataTable)
            {
                if (Dt_Datos_Caja.AsEnumerable().Any())
                {
                    var _datos_caja = from _caja in Dt_Datos_Caja.AsEnumerable()
                                      select new
                                      {

                                          _total_caja_menos_rec_y_ret = _caja.IsNull("Total") ? 0 : _caja.Field<decimal>("Total"),
                                      };

                    if (_datos_caja.Any())
                    {
                        foreach (var _dato in _datos_caja)
                        {
                            Total_En_Caja_String = string.Format("{0:n}", _dato._total_caja_menos_rec_y_ret);
                        }
                    }
                }
            }

            decimal Total_En_Caja = Convert.ToDecimal(Total_En_Caja_String);
            return Total_En_Caja;
        }


        /// <summary>
        /// Nombre: Consultar_Tope_Recolecciones
        /// 
        /// Descripción: Método que obtiene el tope total para las recolecciones de .
        /// 
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 30 Enero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private decimal Consultar_Tope_Recolecciones(string Id_Del_Parametro)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            Consulta_Parametros.P_Parametro_Id = Id_Del_Parametro;
            DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
            string Tope_Recoleccion = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Tope_Recoleccion].ToString();
            decimal Tope_Parametro_Recoleccion = Convert.ToDecimal(Tope_Recoleccion);

            return Tope_Parametro_Recoleccion;
        }

        /// <summary>
        /// Nombre: Btn_No_Compuesto_Ent
        /// Descripción: Evento que se lanza, cuando se accede al focus de la caja de Texto
        /// del número de compuesto
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 09 Febrero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Txt_No_Compuesto_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txt_No_Compuesto.Text))
            {
                Txt_No_Compuesto.SelectionStart = 0;
                Txt_No_Compuesto.SelectionLength = Txt_No_Compuesto.Text.Length;
            }
        }
        /// <summary>
        /// Nombre: Asignar_Foco_No_Compuesto
        /// Descripción: Evento que se lanza, para asignar el focus al número de compuesto 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 09 Febrero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        private void Asignar_Foco_No_Compuesto()
        {
            try
            {
                this.ActiveControl = Txt_No_Compuesto;
                
                Txt_No_Compuesto.Focus(); 
                
                if (!String.IsNullOrEmpty(Txt_No_Compuesto.Text))
                {
                    Txt_No_Compuesto.SelectionStart = 0;
                    Txt_No_Compuesto.SelectionLength = Txt_No_Compuesto.Text.Length;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Asignar_Foco_Caja_Codigo_Barras]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Txt_No_Compuesto_KeyPress
        /// Descripción: Validación para que no se acepten caracteres en la caja de texto del número de compuesto
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 09 Febrero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        private void Txt_No_Compuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Digito);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Txt_No_Compuesto_KeyPress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Liberar_Botones()
        {
            for (int i = 0; i < Pnl_Productos.Controls.Count; i++)
            {
                if (Pnl_Productos.Controls[i] is JButton)
                {
                    Pnl_Productos.Controls[i].Dispose();
                }
            }

            Pnl_Productos.Controls.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Siguiente_Click(object sender, EventArgs e)
        {
            Pnl_Productos.Visible = false;

            VISTA++;

            Btn_Atras.Enabled = true;
            if (VISTA == Vistas) { Btn_Siguiente.Enabled = false; }

            Liberar_Botones();
            Cargar_Botones_Productos();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Atras_Click(object sender, EventArgs e)
        {
            Pnl_Productos.Visible = false;
            VISTA--;

            Btn_Siguiente.Enabled = true;
            if (VISTA == 1) { Btn_Atras.Enabled = false; }

            Liberar_Botones();
            Cargar_Botones_Productos();
        }
    }
}
