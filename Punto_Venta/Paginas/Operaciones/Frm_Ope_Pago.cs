using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ERP_BASE.Paginas.Ventanas_Emergentes;
using Erp_Ope_Ventas.Negocio;
using Operaciones.Cajas.Negocio;
using ERP_BASE.Paginas.Operaciones.Grupos;
using Erp.Constantes;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Operaciones.Estacionamiento.Negocio;
using Erp_Ope_Pagos.Negocio;
//using jp.co.epson.uposcommon;
using System.Reflection;
using Microsoft.PointOfService;
using Erp_Apl_Parametros.Negocio;
using Erp.Metodos_Generales;
using System.Collections;
using System.Drawing.Printing;
using Erp.Seguridad;


namespace ERP_BASE.Paginas.Operaciones
{
    public partial class Frm_Ope_Pago : ResizeableForm.ResizableForm
    {
        private Font printFont;
        private String Str_Numero_Serie = "";
        private String Str_Numero_Control = "";
        private String Str_Tarjeta_Expiracion = "";
        private String Str_Tipo_De_Tarjeta = "";
        private DateTime Dtime_Fecha_Transaccion;
        PosPrinter m_Printer = null;
        private Cls_Ope_Estacionamiento_Negocio Obj_Estacionamiento;
        public bool Es_Pago_Estacionamiento = false;
        Frm_Ope_Estacionamiento Frm_Estacionamiento;
        DataTable Dt_Detalles_Venta;
        DataTable Dt_Pago;
        Frm_Ope_Ventas Frm_Venta;
        Dictionary<String, Button> Dic_Botones_Bancos;
        Dictionary<String, TextBox> Dic_Cajas_Texto;
        String Motivo_Descuento_Id;
        String Usuario_Autoriza_Id;
        private String Str_Documento_Oficial;
        private String Str_Descuento;
        private String Str_Banco_Id_Global = "00001";
        String Banco_Id = "00001";
        private String Str_Pinpad_Com = "";
        private String Str_Pinpad_Id = "";
        private String Str_Pinpad_Equipo = "";
        private Boolean Estatus_Chip = false;
        private Boolean Estatus_Tarjeta_Chip = false;
        private Boolean Estatus_Tarjeta_Tiene_Chip = false;
        private Boolean Estatus_Chip_Sin_Leyenda = false;
        private String Str_Arqc = "";
        private String Str_Aid = "";
        private String Str_Tvr = "";
        private String Str_Tsi = "";
        private String Str_Pin_Entry = "";
        private String Str_EmvTag = "";
        private String Str_Entry_Mode = "";
        private String Str_Delinado = "";
        private String[,] Matriz_Tag = new string[50, 3];
        private String Str_Card_Brand = "";
        private String Str_ISSUING_BANK = "";

        #region (Variables Grupos)
        public string Fecha_Tramite { get; set; }
        public string Persona_Tramita { get; set; }
        public string Empresa { get; set; }
        public string Fecha_Inicio_Vigencia { get; set; }
        public string Fecha_Termino_Vigencia { get; set; }
        public string Aplican_Dias_Festivos { get; set; }
        public string No_Venta { get; set; }
        public decimal Total { get; set; }
        public Frm_Ope_Grupos Frm_Ope_Grupos { get; set; }
        #endregion

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Pago
        ///DESCRIPCIÓN          : Inicializar los controles del formulario.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Frm_Ope_Pago()
        {
            InitializeComponent();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : P_Obj_Estacionamiento
        ///DESCRIPCIÓN          : Método público para enviar los datos del cobro del estacionamiento.
        ///PARAMETROS           : 
        ///CREO                 : Juan Alberto Hernández Negrete.
        ///FECHA_CREO           : 20 Noviembre 2013 16:25 Hrs.
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        internal Cls_Ope_Estacionamiento_Negocio P_Obj_Estacionamiento
        {
            get { return Obj_Estacionamiento; }
            set { Obj_Estacionamiento = value; }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Dt_Detalles_Venta
        ///DESCRIPCIÓN          : Establece el valor de la tabla Dt_Detalles desde otra ventana
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Dt_Detalles_Venta(DataTable Dt_Detalles)
        {
            Dt_Detalles_Venta = Dt_Detalles;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Motivo_Descuento_Id
        ///DESCRIPCIÓN          : Establece el valor de la propiedad Motivo_Descuento_Id desde otra ventana.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Motivo_Descuento_Id(String Str_Motivo_Descuento_Id)
        {
            Motivo_Descuento_Id = Str_Motivo_Descuento_Id;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Motivo_Descuento_Id
        ///DESCRIPCIÓN          : Establece el valor de la propiedad Motivo_Descuento_Id desde otra ventana.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Documento_Oficial(String Str_Documento)
        {
            Str_Documento_Oficial = Str_Documento;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Motivo_Descuento_Id
        ///DESCRIPCIÓN          : Establece el valor de la propiedad Motivo_Descuento_Id desde otra ventana.
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 13/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Descuento(String Str_Descuento_Pago)
        {
            Str_Descuento = Str_Descuento_Pago;
            Txt_Descuento.Text = Str_Descuento;
            Txt_Descuento.Enabled = false;

            Double Monto_Efectivo = 0;
            Double Descuento = 0;

            Double.TryParse(string.Format("{0:n}", Txt_Total_Pagar.Text.Replace("$", "")), out Monto_Efectivo);
            Double.TryParse(string.Format("{0:n}", Str_Descuento_Pago), out Descuento);

            Monto_Efectivo = Monto_Efectivo - Descuento;

            Txt_Monto_Efectivo.Text = "";
            this.ActiveControl = Txt_Monto_Efectivo;
            Txt_Monto_Efectivo.Focus();
            //Txt_Monto_Efectivo.SelectionStart = 0;
            //Txt_Monto_Efectivo.SelectionLength = Txt_Monto_Efectivo.Text.Length;

            Btn_Ventana_Descuentos.Text = "Limpiar";
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Datos_Banco
        ///DESCRIPCIÓN          : Establece los datos del banco seleccionados desde otra ventana.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             : Olimpo Alberto Cruz Amaya 
        ///FECHA_MODIFICO       : 16/Febrero/2015
        ///CAUSA_MODIFICACIÓN   : Se agregó la opción para generar ventas mixtas (Efectivo/Credito)
        ///*******************************************************************************
        public void Set_Datos_Banco(String Str_Banco_Id, Decimal Comision, String Banco)
        {
            try
            {
                Str_Banco_Id_Global = Str_Banco_Id;
                Decimal Total_Pagar = Decimal.Parse(Txt_Total_Pagar.Text.Replace("$", ""));
                Txt_Monto_Cargar.Enabled = true;
                Txt_Referencia.Enabled = true;
                Banco_Id = Str_Banco_Id;
                //Txt_Comision.Text = Comision.ToString("#,##0.00");
                Txt_Banco.Text = Banco;
                //Calcular_Cambio();

                Txt_Cambio.Text = "0";

                //Pago MIXTO EFECTIVO/CREDITO
                if (Txt_Monto_Efectivo.Text.Trim() != String.Empty && Txt_Monto_Efectivo.Text.Trim() != "0")
                {
                    Txt_Monto_Cargar.Text = (Comision + Total_Pagar - Convert.ToDecimal(Txt_Monto_Efectivo.Text)).ToString("#,##0.00");
                }
                else
                    Txt_Monto_Cargar.Text = (Comision + Total_Pagar).ToString("#,##0.00");


                Txt_Cajas_Click(Txt_Monto_Efectivo, null);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Set_Datos_Banco]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Txt_Cajas_Click(Txt_Monto_Cargar, null);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Usuario_Autoriza_Id
        ///DESCRIPCIÓN          : Establece el valor del usuario_id desde otra ventana y 
        ///                       habilita el campo para ingresar el descuento
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Usuario_Autoriza_Id(String Str_Usuario_Autoriza_Id)
        {
            Usuario_Autoriza_Id = Str_Usuario_Autoriza_Id;
            //Txt_Descuento.Enabled = true;
            Txt_Cajas_Click(Txt_Descuento, null);
            Calcular_Cambio();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Frm_Venta
        ///DESCRIPCIÓN          : Guarda la referencia a la ventana de tipo Frm_Ope_Ventas
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Frm_Venta(Frm_Ope_Ventas Frm_Ventas)
        {
            Frm_Venta = Frm_Ventas;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Frm_Venta
        ///DESCRIPCIÓN          : Guarda la referencia a la ventana de tipo Frm_Ope_Ventas
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Frm_Estacionamiento(Frm_Ope_Estacionamiento Frm_Estacionamiento)
        {
            this.Frm_Estacionamiento = Frm_Estacionamiento;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Pago_Load
        ///DESCRIPCIÓN          : Evento Load del formulario
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Frm_Ope_Pago_Load(object sender, EventArgs e)
        {
            Cls_Cat_Terminales_Negocio Rs_Terminal = new Cls_Cat_Terminales_Negocio();
            DataTable Dt_Consulta_Terminal = new DataTable();

            Txt_Total.Text = "$ " + Dt_Detalles_Venta.AsEnumerable().Sum(x => x.Field<Decimal>("TOTAL")).ToString("#,##0.00");
                        
            Crear_Arreglo_Botones();
            Crear_Arreglo_Cajas();
            Txt_Total_Pagar.Text = Txt_Total.Text;
            Txt_Monto_Efectivo.Text = Dt_Detalles_Venta.AsEnumerable().Sum(x => x.Field<Decimal>("TOTAL")).ToString();
            Calcular_Cambio();

            if (Es_Pago_Estacionamiento)
            {
                Btn_Regresar.Enabled = true;
                //Btn_Tarjeta_American.Enabled = false;
                //Btn_Tarjeta_Credito.Enabled = false;
                //Btn_Tarjeta_Debito.Enabled = false;
                //Btn_Ventana_Bancos.Enabled = false;
                Btn_Ventana_Descuentos.Enabled = false;
            }

            //  se consultan la informacion de la pin pad asignada al equipo de computo
            Rs_Terminal.P_Equipo = Environment.MachineName;
            Rs_Terminal.P_Estatus = "ACTIVO";
            Dt_Consulta_Terminal = Rs_Terminal.Consultar_Terminales();

            if (Dt_Consulta_Terminal != null && Dt_Consulta_Terminal.Rows.Count > 0)
            {

                Tbl_Panel_Pago.Visible = true;

                foreach (DataRow Registro in Dt_Consulta_Terminal.Rows)
                {
                    if (!String.IsNullOrEmpty(Registro[Cat_Terminales.Campo_Puerto].ToString()))
                    {
                        Str_Pinpad_Com = Registro[Cat_Terminales.Campo_Puerto].ToString();
                    }
                    if (!String.IsNullOrEmpty(Registro[Cat_Terminales.Campo_Terminal_ID].ToString()))
                    {
                        Str_Pinpad_Id = Registro[Cat_Terminales.Campo_Terminal_ID].ToString();
                    }
                    if (!String.IsNullOrEmpty(Registro[Cat_Terminales.Campo_Nombre].ToString()))
                    {
                        Str_Pinpad_Equipo = Registro[Cat_Terminales.Campo_Nombre].ToString();
                    }
                }
            }
            else // desactiva el pago por pin pad
            {
                Tbl_Panel_Pago.Visible = false;
            }


            this.ActiveControl = Txt_Monto_Efectivo;
            Txt_Monto_Efectivo.Focus();
            //Txt_Monto_Efectivo.SelectionStart = 0;
            //Txt_Monto_Efectivo.SelectionLength = Txt_Monto_Efectivo.Text.Length;
            Txt_Monto_Efectivo.Text = "";

            bool DiaFeriado = Validar_Dias_Feriados();
            if (DiaFeriado)
            {
                Btn_Ventana_Descuentos.Enabled = false;
            }

            //  validamos el monto cero
            if (Txt_Total.Text == "$ 0.00")
            {
                Txt_Monto_Efectivo.Text = "0";
            }

            //Iniciar_Impresora();

        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Crear_Arreglo_Botones
        ///DESCRIPCIÓN          : Agrega los botones de las tarjetas al diccionario.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Crear_Arreglo_Botones()
        {
            Dic_Botones_Bancos = new Dictionary<string, Button>();
            //Dic_Botones_Bancos.Add(Btn_Tarjeta_Credito.Name, Btn_Tarjeta_Credito);
            //Dic_Botones_Bancos.Add(Btn_Tarjeta_Debito.Name, Btn_Tarjeta_Debito);
            //Dic_Botones_Bancos.Add(Btn_Tarjeta_American.Name, Btn_Tarjeta_American);
            //Btn_Tarjeta_Credito.FlatStyle = FlatStyle.Flat;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Crear_Arreglo_Cajas
        ///DESCRIPCIÓN          : Agrega los botones de bancos al diccionario.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Crear_Arreglo_Cajas()
        {
            Dic_Cajas_Texto = new Dictionary<string, TextBox>();
            Dic_Cajas_Texto.Add(Txt_Descuento.Name, Txt_Descuento);
            Dic_Cajas_Texto.Add(Txt_Monto_Efectivo.Name, Txt_Monto_Efectivo);
            Dic_Cajas_Texto.Add(Txt_Monto_Cargar.Name, Txt_Monto_Cargar);
            Txt_Monto_Efectivo.BorderStyle = BorderStyle.FixedSingle;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Regresar
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             : Roberto González Oseguera
        ///FECHA_MODIFICO       : 10-mar-2014
        ///CAUSA_MODIFICACIÓN   : Se agrega validación para considerar pagos de estacionamiento
        ///*******************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            // si es un pago de acceso
            if (!Es_Pago_Estacionamiento)
            {
                foreach (Control Controles in Frm_Venta.Controls)
                {
                    foreach (Control Objeto in Controles.Controls)
                    {
                        if ((Objeto is Button) && (Objeto.Name == "Btn_No_Compuesto"))
                        {
                            Objeto.Text = "";
                            break;
                        }
                    }
                }

                //Frm_Ope_Pago_FormClosing(sender, null);
                Frm_Venta.Show();
                this.Close();
            }
            else
            {
                this.Close();
                Frm_Estacionamiento.Operacion_Cancelada();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Ventana_Descuentos_Click
        ///DESCRIPCIÓN          : Muestra la ventana de tipo Frm_Cat_Ventana_Emergente_Motivos_Descuento
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Ventana_Descuentos_Click(object sender, EventArgs e)
        {
            if (Btn_Ventana_Descuentos.Text != "Limpiar")
            {
                Frm_Cat_Ventana_Emergente_Motivos_Descuento Frm_Motivos = new Frm_Cat_Ventana_Emergente_Motivos_Descuento();

                //  se cargara el pago que se realizara
                Frm_Motivos.MdiParent = this.ParentForm;
                Frm_Motivos.Show();
                this.Enabled = false;
                Frm_Motivos.Set_Frm_Pago(this);
                Frm_Motivos.Set_Monto_A_Pagar(Txt_Total_Pagar.Text.Replace("$", ""));
            }
            else
            {
                Double Monto_Efectivo = 0;
                Double Monto_Tarjeta = 0;
                Double Monto_Comision = 0;

                Double.TryParse(string.Format("{0:n}", Txt_Total.Text.Replace("$", "")), out Monto_Efectivo);


                //  se limpian la caja de texto del descuento
                Txt_Descuento.Text = "0";
                Txt_Total_Pagar.Text = Monto_Efectivo.ToString();


                Btn_Ventana_Descuentos.Text = "Mas...";

                //  validacion para la tarjeta
                if (!String.IsNullOrEmpty(Txt_Monto_Cargar.Text) && Txt_Monto_Cargar.Text != "0")
                {
                    //Double.TryParse(string.Format("{0:n}", Txt_Comision.Text), out Monto_Comision);
                    Monto_Tarjeta = Monto_Efectivo + Monto_Comision;

                    Txt_Monto_Cargar.Text = Monto_Tarjeta.ToString();
                }
                else
                {
                    Txt_Monto_Efectivo.Text = "";
                    //Txt_Monto_Efectivo.Text = Monto_Efectivo.ToString();
                    this.ActiveControl = Txt_Monto_Efectivo;
                    Txt_Monto_Efectivo.Focus();
                    //Txt_Monto_Efectivo.SelectionStart = 0;
                    //Txt_Monto_Efectivo.SelectionLength = Txt_Monto_Efectivo.Text.Length;
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Tarjetas_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Tarjetas para cambiar el foco al boton seleccionado
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             : Olimpo Alberto Cruz Amaya 
        ///FECHA_MODIFICO       : 16/Febrero/2015
        ///CAUSA_MODIFICACIÓN   : No se borra el monto en efectivo aunque seleccione credito (permite ventas mixtas) 
        ///*******************************************************************************
        private void Btn_Tarjetas_Click(object sender, EventArgs e)
        {
            //Dic_Botones_Bancos.FirstOrDefault(x => x.Value == ((Button)sender)).Value.FlatStyle = FlatStyle.Flat;
            //var a = Dic_Botones_Bancos.Where(x => x.Value != ((Button)sender));

            //foreach (var b in a)
            //{
            //    b.Value.FlatStyle = FlatStyle.Standard;
            //}

            //Txt_Monto_Efectivo.Text = "0";

            Lbl_Banco.Visible = true;
            Txt_Banco.Visible = true;
            Lbl_Monto_A_Cargar.Visible = true;
            Txt_Monto_Cargar.Visible = true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Cajas_Click
        ///DESCRIPCIÓN          : Evento Click de las cajas de texto para designarla seleccionada.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Txt_Cajas_Click(object sender, EventArgs e)
        {
            Dic_Cajas_Texto.FirstOrDefault(x => x.Value == ((TextBox)sender)).Value.BorderStyle = BorderStyle.FixedSingle;
            var a = Dic_Cajas_Texto.Where(x => x.Value != ((TextBox)sender));
            foreach (var b in a)
            {
                b.Value.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Cantidad_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Cantidad
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Cantidad_Click(object sender, EventArgs e)
        {
            TextBox Txt_Caja_Activa = Dic_Cajas_Texto.FirstOrDefault(x => x.Value.BorderStyle == BorderStyle.FixedSingle).Value;
            if (Txt_Caja_Activa.Name != "Txt_Descuento")
            {
                if (Txt_Caja_Activa.Text.Trim() == "" || Txt_Caja_Activa.Text.Trim() == "0")
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
                Calcular_Cambio();
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Pagar_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Pagar, inserta los registros en la BD.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Pagar_Click(object sender, EventArgs e)
        {
            String Venta_Id = String.Empty;
            Boolean Estatus_Pago = false;

            if (Validar_Datos())
            {
                String No_Caja;
                DataTable Dt_Formas_Pago;
                //Cargar datos de la venta
                Cls_Ope_Ventas_Negocio P_Ventas = new Cls_Ope_Ventas_Negocio();
                P_Ventas.P_No_Venta = No_Venta;
                P_Ventas.P_Motivo_Descuento_Id = Str_Documento_Oficial;
                P_Ventas.P_Usuario_Id = Usuario_Autoriza_Id;
                P_Ventas.P_Subtotal = Convert.ToDecimal(Txt_Total.Text.Replace("$", ""));
                P_Ventas.P_Impuestos = 0;
                P_Ventas.P_Descuentos = Convert.ToDecimal(Txt_Descuento.Text);
                P_Ventas.P_Total = Convert.ToDecimal(Txt_Total_Pagar.Text.Replace("$", ""));
                P_Ventas.P_Estatus = "PAGADO";
                P_Ventas.P_Dt_Ventas = Dt_Detalles_Venta;
                P_Ventas.P_Lugar_Venta = "No Caja";
                String Tipo_de_Pago = String.Empty;
                string fecha = DateTime.Now.ToString();

                //Consulta de parametros
                Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                DataTable ParametroActual = Consulta_Parametros.Consultar_Parametros();
                //obtiene el id de parametro actual
                string No_Parametro = ParametroActual.Rows[0][0].ToString();
                //Obtener la cantidad tope para las recolecciones
                string Mensaje_Ticket = Consultar_Mensaje_Ticket_Parametros(No_Parametro);

                //Carga los datos de la caja
                Cls_Ope_Cajas_Negocio P_Cajas = new Cls_Ope_Cajas_Negocio();
                P_Cajas.P_Caja_ID = Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                P_Cajas.P_Estatus = "ABIERTA";
                No_Caja = P_Cajas.Consultar_Cajas().Rows[0][Ope_Cajas.Campo_No_Caja].ToString();

                //Consulta las formas de pago
                Cls_Cat_Formas_Pago_Negocio P_Formas = new Cls_Cat_Formas_Pago_Negocio();
                Dt_Formas_Pago = P_Formas.Consultar_Formas_Pago();

                //Crear tabla para pagos
                Crear_Tabla_Pagos();
                DataRow Dr_Detalle_Pago;

                if ((!String.IsNullOrEmpty(Txt_Monto_Cargar.Text) && String.IsNullOrEmpty(Txt_Referencia.Text)))
                {
                    MessageBox.Show(this, "Realice el pago de la pin pad", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (DataRow Dr_Forma_Pago in Dt_Formas_Pago.Rows)
                {
                    Dr_Detalle_Pago = Dt_Pago.NewRow();
                    if (Dr_Forma_Pago[Cat_Formas_Pago.Campo_Nombre].ToString() == "EFECTIVO")
                    {
                        //  validacion monto cero
                        if (Txt_Total.Text == "$ 0.00")
                        {
                            Estatus_Pago = true;
                        }

                        if ((!String.IsNullOrEmpty(Txt_Monto_Efectivo.Text) && Txt_Monto_Efectivo.Text != "0") || Estatus_Pago == true)
                        {
                            if ((Convert.ToDecimal(Txt_Monto_Efectivo.Text.Replace("$", "")) - Convert.ToDecimal(Txt_Cambio.Text.Replace("$", ""))) >= 0)
                            {
                                Dr_Detalle_Pago["No_Caja"] = No_Caja;
                                Dr_Detalle_Pago["Forma_Id"] = Dr_Forma_Pago[Cat_Formas_Pago.Campo_Forma_ID].ToString();
                                Dr_Detalle_Pago["Banco_Id"] = "";
                                Dr_Detalle_Pago["Monto_Pago"] = (Convert.ToDecimal(Txt_Monto_Efectivo.Text.Replace("$", "")) - Convert.ToDecimal(Txt_Cambio.Text.Replace("$", "")));
                                Dr_Detalle_Pago["Monto_Comision"] = 0M;
                                Dr_Detalle_Pago["Numero_Tarjeta_Banco"] = "";
                                Dr_Detalle_Pago[Ope_Pagos.Campo_Tipo_Tarjeta_Banco] = "";
                                Dr_Detalle_Pago["Estatus"] = "PAGADO";
                                Dr_Detalle_Pago["Referencia"] = "";
                                Dt_Pago.Rows.Add(Dr_Detalle_Pago);
                                Tipo_de_Pago = "EFECTIVO";
                            }

                            Estatus_Pago = false;
                        }
                    }
                    else if (Dr_Forma_Pago[Cat_Formas_Pago.Campo_Nombre].ToString() == "DEBITO" && Chk_Pago_Con_Tarjeta.Checked == true && Txt_Referencia.Text != "")
                    {
                        //if (Convert.ToDecimal(Txt_Monto_Cargar.Text.Replace("$", "")) > 0 && ((Dic_Botones_Bancos.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat ).Value != null)))
                        //{
                        Dr_Detalle_Pago["No_Caja"] = No_Caja;
                        Dr_Detalle_Pago["Forma_Id"] = Dr_Forma_Pago[Cat_Formas_Pago.Campo_Forma_ID].ToString();
                        Dr_Detalle_Pago["Banco_Id"] = Str_Banco_Id_Global;
                        Dr_Detalle_Pago["Monto_Pago"] = Convert.ToDecimal(Lbl_Monto_Autorizado.Text.Replace("$", ""));
                        Dr_Detalle_Pago["Monto_Comision"] = Convert.ToDecimal(0);
                        Dr_Detalle_Pago["Numero_Tarjeta_Banco"] = Txt_Numero_Tarjeta.Text;
                        Dr_Detalle_Pago[Ope_Pagos.Campo_Tipo_Tarjeta_Banco] = Lbl_Tipo_Tarjeta.Text;
                        Dr_Detalle_Pago["Estatus"] = "PAGADO";
                        Dr_Detalle_Pago["Referencia"] = Txt_Referencia.Text;
                        Dr_Detalle_Pago["Tipo_Tarjeta"] = Lbl_Tipo_Tarjeta.Text;
                        Dr_Detalle_Pago["Titular_Tarjeta"] = Txt_Titular_Tarjeta.Text;
                        Dr_Detalle_Pago["Numero_Transaccion"] = Txt_Numero_Autorizacion.Text;

                        Dt_Pago.Rows.Add(Dr_Detalle_Pago);
                        //}
                    }
                    //else if (Dr_Forma_Pago[Cat_Formas_Pago.Campo_Nombre].ToString() == "CREDITO" && Chk_Pago_Con_Tarjeta.Checked == true && Lbl_Tipo_Tarjeta.Text.Trim() == "CREDITO")
                    //{
                    //    //if (Convert.ToDecimal(Txt_Monto_Cargar.Text.Replace("$", "")) > 0 && ((Dic_Botones_Bancos.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat).Value != null)))
                    //    //{
                    //    Dr_Detalle_Pago["No_Caja"] = No_Caja;
                    //    Dr_Detalle_Pago["Forma_Id"] = Dr_Forma_Pago[Cat_Formas_Pago.Campo_Forma_ID].ToString();
                    //    Dr_Detalle_Pago["Banco_Id"] = Str_Banco_Id_Global;
                    //    Dr_Detalle_Pago["Monto_Pago"] = Convert.ToDecimal(Lbl_Monto_Autorizado.Text.Replace("$", ""));
                    //    Dr_Detalle_Pago["Monto_Comision"] = Convert.ToDecimal(0);
                    //    Dr_Detalle_Pago["Numero_Tarjeta_Banco"] = Txt_Numero_Tarjeta.Text;
                    //    Dr_Detalle_Pago[Ope_Pagos.Campo_Tipo_Tarjeta_Banco] = Lbl_Tipo_Tarjeta.Text;
                    //    Dr_Detalle_Pago["Estatus"] = "PAGADO";
                    //    Dr_Detalle_Pago["Referencia"] = Txt_Referencia.Text;
                    //    Dr_Detalle_Pago["Tipo_Tarjeta"] = Lbl_Tipo_Tarjeta.Text;
                    //    Dr_Detalle_Pago["Titular_Tarjeta"] = Txt_Titular_Tarjeta.Text;
                    //    Dr_Detalle_Pago["Numero_Transaccion"] = Txt_Numero_Autorizacion.Text;
                    //    Dt_Pago.Rows.Add(Dr_Detalle_Pago);
                    //    //}
                    //}
                    //else if (Dr_Forma_Pago[Cat_Formas_Pago.Campo_Nombre].ToString() == "AMERICAN EXPRESS")
                    //{
                    //    if (Convert.ToDecimal(Txt_Monto_Cargar.Text.Replace("$", "")) > 0 && ((Dic_Botones_Bancos.FirstOrDefault(x => x.Value.FlatStyle == FlatStyle.Flat).Value != null)))
                    //    {
                    //        Dr_Detalle_Pago["No_Caja"] = No_Caja;
                    //        Dr_Detalle_Pago["Forma_Id"] = Dr_Forma_Pago[Cat_Formas_Pago.Campo_Forma_ID].ToString();
                    //        Dr_Detalle_Pago["Banco_Id"] = Str_Banco_Id_Global;
                    //        Dr_Detalle_Pago["Monto_Pago"] = Convert.ToDecimal(Txt_Monto_Cargar.Text.Replace("$", ""));
                    //        Dr_Detalle_Pago["Monto_Comision"] = Convert.ToDecimal(0);
                    //        Dr_Detalle_Pago["Numero_Tarjeta_Banco"] = "1234567890123456";
                    //        Dr_Detalle_Pago[Ope_Pagos.Campo_Tipo_Tarjeta_Banco] = "AMERICAN EXPRESS";
                    //        Dr_Detalle_Pago["Estatus"] = "PAGADO";
                    //        Dr_Detalle_Pago["Referencia"] = Txt_Referencia.Text;
                    //        Dt_Pago.Rows.Add(Dr_Detalle_Pago);
                    //    }
                    //}
                }

                P_Ventas.P_Dt_Pagos = Dt_Pago;

                if (!Es_Pago_Estacionamiento)
                {
                    if (string.IsNullOrEmpty(No_Venta))
                    {
                        Venta_Id = P_Ventas.Alta_Ventas();
                        {
                            // enviar impresión de recibos y accesos
                            var Obj_Impresiones = new Erp_Ope_Impresiones.Negocio.Cls_Ope_Impresiones_Negocio();
                            Obj_Impresiones.P_No_Venta = P_Ventas.P_No_Venta;
                            Obj_Impresiones.P_Descuento_Pago = Convert.ToDecimal(P_Ventas.P_Descuentos);
                            Obj_Impresiones.P_Subtotal_Pago = Convert.ToDecimal(P_Ventas.P_Subtotal);
                            Obj_Impresiones.P_Monto_Pago = Convert.ToDecimal(P_Ventas.P_Total);
                            Obj_Impresiones.P_Dt_Datos_Pago = P_Ventas.P_Dt_Ventas;
                            Obj_Impresiones.P_Dt_Formas_Pago = P_Ventas.P_Dt_Pagos;
                            Obj_Impresiones.Imprimir_Pago();

                            Frm_Venta.Show();
                            this.Close();
                            Frm_Venta.Alta_Exitosa();

                        }
                    }
                    else
                    {
                        //GRUPOS
                        Venta_Id = P_Ventas.Realizar_Pago_Grupo();

                        // enviar impresión de recibos y accesos
                        var Obj_Impresiones = new Erp_Ope_Impresiones.Negocio.Cls_Ope_Impresiones_Negocio();
                        Obj_Impresiones.P_No_Venta = P_Ventas.P_No_Venta;
                        Obj_Impresiones.P_Descuento_Pago = Convert.ToDecimal(P_Ventas.P_Descuentos);
                        Obj_Impresiones.P_Subtotal_Pago = Convert.ToDecimal(P_Ventas.P_Subtotal);
                        Obj_Impresiones.P_Monto_Pago = Convert.ToDecimal(P_Ventas.P_Total);
                        Obj_Impresiones.P_Dt_Datos_Pago = P_Ventas.P_Dt_Ventas;
                        Obj_Impresiones.P_Dt_Formas_Pago = P_Ventas.P_Dt_Pagos;
                        Obj_Impresiones.Imprimir_Pago();

                        Frm_Venta.Show();
                        this.Close();
                        Frm_Venta.Alta_Exitosa();
                    }
                }
                else
                {
                    //Completamos el registro del cobro del acceso al estacionamiento.
                    Obj_Estacionamiento.Editar_Estacionamiento();
                    //Ejecutamos el pago por concepto del acceso al estacionamiento.
                    Cls_Ope_Pagos_Negocio P_Pagos = new Cls_Ope_Pagos_Negocio();
                    P_Pagos.P_Dt_Pagos = Dt_Pago;
                    P_Pagos.No_Estacionamiento = Obj_Estacionamiento.P_No_Estacionamiento;
                    P_Pagos.Alta_Pago();
                    this.Close();
                    Frm_Estacionamiento.Operacion_Completa();
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Dias_Feriados
        ///DESCRIPCIÓN          : Indica si la fecha actual se encuentra dentro de un día feriado o no.
        ///PARAMETROS           : 
        ///CREO                 : Cruz Amaya Olimpo Alberto
        ///FECHA_CREO           : 08/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private bool Validar_Dias_Feriados()
        {
            Cls_Ope_Pagos_Negocio Pagos = new Cls_Ope_Pagos_Negocio();
            DataTable Fechas_Feridas;
            bool EsFeriado = false;
            Fechas_Feridas = Pagos.Consultar_Dias_Feriados();
            //Se recorren todos las fechas de los dias feriados existentes
            foreach (DataRow Dr_Fecha in Fechas_Feridas.Rows)
            {
                DateTime FechaActual = DateTime.Today;
                DateTime FechaInicioFeriado = Convert.ToDateTime(Dr_Fecha[Cat_Dias_Feriados.Campo_Fecha].ToString());
                DateTime FechaFinFeriado = Convert.ToDateTime(Dr_Fecha[Cat_Dias_Feriados.Campo_Fecha_Fin].ToString());
                //Se compara la fecha actual con las fechas limites
                if ((FechaActual >= FechaInicioFeriado) && (FechaActual <= FechaFinFeriado))
                {
                    EsFeriado = true;
                }
            }
            return EsFeriado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_C_Click
        ///DESCRIPCIÓN          : Evento click del boton Btn_C para eliminar el ultimo digito ingresado
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_C_Click(object sender, EventArgs e)
        {
            TextBox Txt_Caja_Activa = Dic_Cajas_Texto.FirstOrDefault(x => x.Value.BorderStyle == BorderStyle.FixedSingle).Value;

            if (Txt_Caja_Activa.Text.Trim() == "")
            {
                return;
            }

            Txt_Caja_Activa.Text = Txt_Caja_Activa.Text.Substring(0, Txt_Caja_Activa.Text.Length - 1);
            Calcular_Cambio();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Calcular_Cambio
        ///DESCRIPCIÓN          : Metodo para calcular el cambio
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Calcular_Cambio()
        {
            decimal Descuento;
            decimal Total;
            decimal Total_Pagar;
            decimal Efectivo;
            decimal Comision;
            decimal Monto_Cargar;
            decimal Cambio;

            decimal.TryParse(Txt_Total.Text.Replace("$ ", ""), out Total);
            decimal.TryParse(Txt_Descuento.Text, out Descuento);
            Total_Pagar = Total - Descuento;
            decimal.TryParse(Txt_Monto_Efectivo.Text, out Efectivo);
            decimal.TryParse(Txt_Descuento.Text, out Comision);
            decimal.TryParse(Txt_Monto_Cargar.Text, out Monto_Cargar);

            //if (Efectivo == 0)
            //{
            //    return;
            //}


            /*if (Efectivo >= 0)
            {
                Txt_Monto_Cargar.Text = "0";
                Txt_Banco.Text = string.Empty;
                Txt_Comision.Text = "0";

                Monto_Cargar = 0;
            }*/

            Cambio = Efectivo + Monto_Cargar - Total_Pagar;

            //En caso de que se tenga un monto a cargar, se recalcula el cambio
            if (Monto_Cargar > 0)
            {
                Cambio = Efectivo + Monto_Cargar - Total_Pagar;

            }

            // actualizar total a pagar
            Txt_Total_Pagar.Text = Total_Pagar.ToString("c");

            // actualizar cambio y asignar color verde para saldo a favor y rojo para remanente de pago
            Txt_Cambio.Text = Cambio.ToString("c");
            if (Cambio < 0)
            {
                Txt_Cambio.BackColor = Color.Red;
            }
            else
            {
                Txt_Cambio.BackColor = Color.LightGreen;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Limpiar_Click
        ///DESCRIPCIÓN          : Evento click del boton Btn_Limpiar, limpia la caja de 
        ///                       texto seleccionada.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            TextBox Txt_Caja_Activa = Dic_Cajas_Texto.FirstOrDefault(x => x.Value.BorderStyle == BorderStyle.FixedSingle).Value;
            //Txt_Monto_Cargar.Text = "";
            Txt_Caja_Activa.Text = "";
            this.ActiveControl = Txt_Monto_Efectivo;
            Txt_Monto_Efectivo.Focus();
            Calcular_Cambio();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Ventana_Bancos_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Ventana_Bancos, crea una nueva 
        ///                       ventana de tipo Frm_Cat_Ventana_Emergente_Bancos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Ventana_Bancos_Click(object sender, EventArgs e)
        {
            Frm_Cat_Ventana_Emergente_Bancos Frm_Bancos = new Frm_Cat_Ventana_Emergente_Bancos();
            Frm_Bancos.MdiParent = this.ParentForm;
            Frm_Bancos.Show();
            Frm_Bancos.Set_Frm_Pago(this);
            this.Enabled = false;

        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Crear_Arreglo_Botones
        ///DESCRIPCIÓN          : Agrega los botones de las tarjetas al diccionario.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Crear_Tabla_Pagos()
        {
            Dt_Pago = new DataTable();
            Dt_Pago.Columns.Add(new DataColumn("No_Caja", typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn("Forma_Id", typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn("Banco_Id", typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn("Monto_Pago", typeof(Decimal)));
            Dt_Pago.Columns.Add(new DataColumn("Monto_Comision", typeof(Decimal)));
            Dt_Pago.Columns.Add(new DataColumn("Numero_Tarjeta_Banco", typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn(Ope_Pagos.Campo_Tipo_Tarjeta_Banco, typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn("Estatus", typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn("Referencia", typeof(String)));
            //Dt_Pago.Columns.Add(new DataColumn("Tipo_Tarjeta", typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn("Titular_Tarjeta", typeof(String)));
            Dt_Pago.Columns.Add(new DataColumn("Numero_Transaccion", typeof(String)));
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Crear_Arreglo_Botones
        ///DESCRIPCIÓN          : Agrega los botones de las tarjetas al diccionario.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private Boolean Validar_Datos()
        {
            Boolean Valido = true;
            String Mensaje = "";
            if (Convert.ToDecimal(Txt_Cambio.Text.Replace("$", "")) < 0)
            {
                Mensaje += "+ No se cubre el monto a pagar.";
                Valido = false;
            }
            if (Mensaje != "")
            {
                MessageBox.Show(this, Mensaje, "Pago", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return Valido;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Iniciar_Impresora()
        ///DESCRIPCIÓN          : Inicia el dispositivo de la impresora de tickets 
        ///PARAMETROS           : 
        ///CREO                 : Cruz Amaya Olimpo Alberto     
        ///FECHA_CREO           : 31/Enero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Iniciar_Impresora()
        {
            try
            {
                /*************** Impresora de Tickets ***************/
                string strLogicalName = "PosPrinter";

                PosExplorer posExplorer = new PosExplorer();
                DeviceInfo deviceInfo = null;

                deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, strLogicalName);
                m_Printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);

                //<<<step9>>>--Start	
                //Register OutputCompleteEvent
                AddOutputCompleteEvent(m_Printer);
                //<<<step9>>>--End
                //<<<step10>>>--Start	
                //Register OutputCompleteEvent
                AddErrorEvent(m_Printer);
                //Register OutputCompleteEvent
                AddStatusUpdateEvent(m_Printer);

                m_Printer.Open();
                m_Printer.Claim(1000);
                m_Printer.DeviceEnabled = true;
                m_Printer.RecLetterQuality = true;
            }

            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Impresora de Tickets", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Liberar_Impresora()
        ///DESCRIPCIÓN          : Detiene el dispositivo de la impresora de tickets 
        ///PARAMETROS           : 
        ///CREO                 : Cruz Amaya Olimpo Alberto     
        ///FECHA_CREO           : 31/Enero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Liberar_Impresora()
        {
            if (m_Printer != null)
            {
                try
                {
                    //<<<step9>>>--Start
                    // Remove OutputCompleteEventHanlder.
                    RemoveOutputCompleteEvent(m_Printer);
                    //<<<step9>>>--End
                    //<<<step10>>>--Start
                    //Remove ErrorEventHandler.
                    RemoveErrorEvent(m_Printer);
                    // Remove StatusUpdateEventHandler.
                    RemoveStatusUpdateEvent(m_Printer);
                    //<<<step10>>>--End
                    //Cancel the device
                    m_Printer.DeviceEnabled = false;
                    //Release the device exclusive control right.
                    m_Printer.Release();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Eventos_Impresora_Tickets
        protected void AddOutputCompleteEvent(object eventSource)
        {
            EventInfo statusUpdateEvent = eventSource.GetType().GetEvent("StatusUpdateEvent");
            if (statusUpdateEvent != null)
            {
                statusUpdateEvent.RemoveEventHandler(eventSource,
                    new StatusUpdateEventHandler(OnStatusUpdateEvent));
            }
        }


        /// <summary>
        /// StatusUpdateEvnet.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OnStatusUpdateEvent(object source, StatusUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                //Ensure calls to Windows Form Controls are from this application's thread
                Invoke(new StatusUpdateEventHandler(OnStatusUpdateEvent), new object[2] { source, e });
                return;
            }

            //When there is a change of the status on the printer, the event is fired.
            switch (e.Status)
            {
                //Printer cover is open.
                case PosPrinter.StatusCoverOpen:
                    //m_btnStateByCover = false;
                    break;
                //No receipt paper.
                case PosPrinter.StatusReceiptEmpty:
                    //m_btnStateByPaper = false;
                    break;
                //'Printer cover is close.
                case PosPrinter.StatusCoverOK:
                    //m_btnStateByCover = true;
                    break;
                //'Receipt paper is ok.
                case PosPrinter.StatusReceiptPaperOK:
                case PosPrinter.StatusReceiptNearEmpty:
                    //m_btnStateByPaper = true;
                    break;
            }
        }

        /// <summary>
        /// Add StatusUpdateEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void AddStatusUpdateEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo statusUpdateEvent = eventSource.GetType().GetEvent("StatusUpdateEvent");
            if (statusUpdateEvent != null)
            {
                statusUpdateEvent.AddEventHandler(eventSource,
                    new StatusUpdateEventHandler(OnStatusUpdateEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// Add ErrorEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void AddErrorEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo errorEvent = eventSource.GetType().GetEvent("ErrorEvent");
            if (errorEvent != null)
            {
                errorEvent.AddEventHandler(eventSource,
                    new DeviceErrorEventHandler(OnErrorEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// Error Event.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OnErrorEvent(object source, DeviceErrorEventArgs e)
        {
            if (InvokeRequired)
            {
                //Ensure calls to Windows Form Controls are from this application's thread
                Invoke(new DeviceErrorEventHandler(OnErrorEvent), new object[2] { source, e });
                return;
            }

            //<<<step10>>>--Start
            DialogResult dialogResult;

            string strMessage = "Printer Error\n\n" + "ErrorCode = " + e.ErrorCode.ToString()
                + "\n" + "ErrorCodeExtended = " + e.ErrorCodeExtended.ToString();

            dialogResult = MessageBox.Show(strMessage, "PrinterSample_Step11"
                , MessageBoxButtons.RetryCancel);

            if (dialogResult == DialogResult.Cancel)
            {
                e.ErrorResponse = ErrorResponse.Clear;
            }
            else if (dialogResult == DialogResult.Retry)
            {
                e.ErrorResponse = ErrorResponse.Retry;
            }
            //<<<step10>>>--End

        }

        /// <summary>
        /// Remove OutputCompleteEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void RemoveOutputCompleteEvent(object eventSource)
        {
            //<<<step7>>>--Start
            EventInfo outputCompleteEvent = eventSource.GetType().GetEvent("OutputCompleteEvent");
            if (outputCompleteEvent != null)
            {
                outputCompleteEvent.RemoveEventHandler(eventSource,
                    new OutputCompleteEventHandler(OnOutputCompleteEvent));
            }
            //<<<step7>>>--End
        }

        /// <summary>
        /// Remove StatusUpdateEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void RemoveStatusUpdateEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo statusUpdateEvent = eventSource.GetType().GetEvent("StatusUpdateEvent");
            if (statusUpdateEvent != null)
            {
                statusUpdateEvent.RemoveEventHandler(eventSource,
                    new StatusUpdateEventHandler(OnStatusUpdateEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// Remove ErrorEventHandler.
        /// </summary>
        /// <param name="eventSource"></param>
        protected void RemoveErrorEvent(object eventSource)
        {
            //<<<step10>>>--Start
            EventInfo errorEvent = eventSource.GetType().GetEvent("ErrorEvent");
            if (errorEvent != null)
            {
                errorEvent.RemoveEventHandler(eventSource,
                    new DeviceErrorEventHandler(OnErrorEvent));
            }
            //<<<step10>>>--End
        }

        /// <summary>
        /// OutputComplete Event.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OnOutputCompleteEvent(object source, OutputCompleteEventArgs e)
        {
            //<<<step7>>>--Start
            //Notify that printing is completed when it is asnchronous.
            MessageBox.Show("Complete printing : ID = " + e.OutputId.ToString()
                , "Impresión");
            //<<<step7>>>--End
        }
        #endregion

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Pago_FormClosing
        ///DESCRIPCIÓN          : Cierra la ventana de pagos
        ///PARAMETROS           : 
        ///CREO                 : Cruz Amaya Olimpo Alberto 
        ///FECHA_CREO           : 31/Enero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Frm_Ope_Pago_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Liberar_Impresora();
        }

        private void Imprimir_Datos_Tickets(string Fecha, string Id_caja, List<string> Datos_Imprimir, string Comision, string Total, string Pagado, string Cambio, string Folio, string mensaje)
        {
            try
            {

                m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Transaction);
                m_Printer.PrintNormal(PrinterStation.Receipt, "----------------------------------------\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "============ TICKET DE VENTA ===========\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "----------------------------------------\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "   Momias de Guanajuato     \n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "   Fecha: " + Fecha + "     \n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "   Caja: " + Id_caja + "      \n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "   Folio: " + Folio + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "----------------------------------------\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "No.  \t Tipo. Entrada \t Precio \n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "----------------------------------------\n");
                foreach (string s in Datos_Imprimir)
                {
                    m_Printer.PrintNormal(PrinterStation.Receipt, s + "\n");
                }
                m_Printer.PrintNormal(PrinterStation.Receipt, "----------------------------------------\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "Comision:" + Comision + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "Total:" + Total + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "Pagado:" + Pagado + " \n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "Cambio:" + Cambio + " \n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "----------------------------------------\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, mensaje + "\n");
                m_Printer.PrintNormal(PrinterStation.Receipt, "----------------------------------------\n");
                //Fin de impresion 
                m_Printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");

                while (m_Printer.State != ControlState.Idle)
                {
                    try
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                    catch (Exception)
                    {
                    }
                }

                m_Printer.TransactionPrint(PrinterStation.Receipt, PrinterTransactionControl.Normal);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.ToString(), "Error - Impresora de Tickets", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Nombre: Consultar_Mensaje_Ticket_Parametros
        /// 
        /// Descripción: Método que obtiene el mensaje para los tickets de Parametros
        /// 
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 03 Febrero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private string Consultar_Mensaje_Ticket_Parametros(string Id_Del_Parametro)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            Consulta_Parametros.P_Parametro_Id = Id_Del_Parametro;
            DataTable Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
            string Mensaje_Ticket = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Mensaje_Ticket].ToString();
            return Mensaje_Ticket;
        }


        /// <summary>
        /// Nombre: Txt_Referencia_KeyPress
        /// 
        /// Descripción: Se valida que no se acepten caracteres no numéricos en la caja de texto 
        /// 
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 03 Febrero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Txt_Referencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Digito);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Billetes_Monedas_KeyPress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Txt_Monto_Efectivo_TextChanged
        /// 
        /// Descripción: Se consulta el cambio al cambiar la casilla de texto con teclado numerico 
        /// 
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 03 Febrero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Txt_Monto_Efectivo_TextChanged(object sender, EventArgs e)
        {
            Calcular_Cambio();
        }

        /// <summary>
        /// Nombre: Txt_Monto_Efectivo_KeyPress
        /// 
        /// Descripción: Se valida que no se acepten caracteres no numéricos en la caja de texto 
        /// 
        /// 
        /// Usuario Creo: Olimpo Alberto Cruz Amaya.
        /// Fecha Creo: 16 Febrero 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Txt_Monto_Efectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Digito);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Efectivo_KeyPress]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Nombre: Txt_Monto_Cargar_TextChanged
        /// Descripción: Se realiza el pago por medio de la pin pad
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 24 Abril 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Txt_Monto_Cargar_TextChanged(object sender, EventArgs e)
        {
            Double Monto_A_Cargar = 0;
            Double Resultado = 0;
            Double Monto_Total = 0;

            try
            {
                TextBox Txt_Caja_Activa = Dic_Cajas_Texto.FirstOrDefault(x => x.Value.BorderStyle == BorderStyle.FixedSingle).Value;

                if (Txt_Caja_Activa == Txt_Monto_Cargar && (!String.IsNullOrEmpty(Txt_Monto_Cargar.Text)))
                {
                    if (!String.IsNullOrEmpty(Txt_Total_Pagar.Text))
                    {
                        Double.TryParse(string.Format("{0:n}", Txt_Total_Pagar.Text.Replace("$", "")), out Monto_Total);
                    }

                    if (!String.IsNullOrEmpty(Txt_Monto_Cargar.Text))
                    {
                        Double.TryParse(string.Format("{0:n}", Txt_Monto_Cargar.Text.Replace("$", "")), out Monto_A_Cargar);
                    }


                    if (Monto_A_Cargar > Monto_Total)
                    {
                        Txt_Monto_Cargar.Text = "0";

                        Txt_Monto_Cargar.Focus();
                        Txt_Monto_Cargar.SelectionStart = 0;
                        Txt_Monto_Cargar.SelectionLength = Txt_Monto_Cargar.Text.Length;
                        MessageBox.Show(this, "El monto no puede ser mayor al total a pagar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Resultado = Monto_Total - Monto_A_Cargar;

                        Txt_Monto_Efectivo.Text = Resultado.ToString();
                    }

                    Calcular_Cambio();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método :[Txt_Monto_Cargar_TextChanged]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nombre: Generar_Numero_Control
        /// Descripción: Se realiza el numero de control 
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 25 Abril 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private String Generar_Numero_Control()
        {

            Double Dia, Mes, Anio, Hora, Minuto, Segundo, Msegundo;
            String Str_Dia, Str_Mes, Str_Hora, Str_Minuto, Str_Segundo, Str_Msegundo;


            Dia = DateTime.Now.Day;
            Mes = DateTime.Now.Month;
            Anio = DateTime.Now.Year;
            Hora = DateTime.Now.Hour;
            Minuto = DateTime.Now.Minute;
            Segundo = DateTime.Now.Second;
            Msegundo = DateTime.Now.Millisecond;

            Str_Dia = string.Format("{0:00}", Dia);
            Str_Mes = string.Format("{0:00}", Mes);
            Str_Hora = string.Format("{0:00}", Hora);
            Str_Minuto = string.Format("{0:00}", Minuto);
            Str_Segundo = string.Format("{0:00}", Segundo);
            Str_Msegundo = string.Format("{0:00}", Msegundo);

            return Str_Dia + Str_Mes + Anio.ToString() + Str_Hora + Str_Minuto + Str_Segundo + Str_Msegundo;
        }


        /// <summary>
        /// Nombre: Btn_Pago_PinPad_Click
        /// Descripción: Se realiza el pago por medio de la pin pad
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 24 Abril 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        private void Btn_Pago_PinPad_Click(object sender, EventArgs e)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta_Parametros = Consulta_Parametros.Consultar_Parametros();

            Banorte.PinPad.Vx810Segura Pinpad = new Banorte.PinPad.Vx810Segura("EN");

            Hashtable Hst_ConfiguracionPinPad = new Hashtable();
            Hashtable Hst_Salida = new Hashtable();
            Hashtable Hst_Selector = new Hashtable();
            Hashtable Hst_EntradaLeer = new Hashtable();
            Hashtable Hst_SalidaLeer = new Hashtable();
            Hashtable Hst_Datos_A_Enviar = new Hashtable();
            Hashtable Hst_EntradaLeer_Transaccion = new Hashtable();
            Hashtable Hst_SalidaLeer_Transaccion = new Hashtable();
            Hashtable Hst_Entrada_Notificar = new Hashtable();
            Hashtable Hst_Salida_Notificar = new Hashtable();
            Hashtable Hst_Entrada_Reversa = new Hashtable();
            Hashtable Hst_Salida_Reversa = new Hashtable();

            Boolean Estatus_Aprobado = false;
            Boolean Estatus_Rechazada = false;

            int Cont_Tag = 0;
            int Cont_Matriz = 0;
            int Cont_Operacion = 0;
            Int64 Valor_Hexadecimal = 0;
            Int64 Valor_Decimal = 0;
            Double Monto_A_Cargar = 0;

            String Tag = "";
            String Auxiliar = "";
            String Str_Mensaje = "";
            String Str_Referencia = "";
            String Str_Llave_Maestra = "";
            String Str_Tipo_Operacion_Venta = "";
            String Str_Modo_Operacion = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Operacion_PinPad].ToString();
            String Str_Afiliacion = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Afiliacion_PinPad].ToString();
            String Str_Usuario = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Usuario_PinPad].ToString();
            String Str_Contrasenia = Cls_Seguridad.Desencriptar(Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Contrasenia_PinPad].ToString());
            String Str_URL = Dt_Consulta_Parametros.Rows[0][Cat_Parametros.Campo_Banorte_Url].ToString();
            String Str_Bin = "";
            String Str_Numero_Tarjeta = "";
            String Str_Titular_Tarjeta = "";
            String Str_Accion_Tarjeta = "";
            String Str_Chip_Declinado = "";
            String Str_Emv_Tags = "";
            String Str_Track2 = "";
            String Str_Resultado_Lectura_Transaccion = "";
            String Str_Auth_Code = "";
            String Str_Emv_Result = "";
            String Str_Emv_Data = "";
           
            //  Matriz de errores posibles en la transaccion
            String[] Diccionario = new String[44] { "4F", "50", "5A", "82", "84", "8A", "95", "9A" , "9B", "9C",
                            "C2", "E2" ,"5F20","5F24" , "5F25" , "5F28", "5F2A" , "5F30", "5F34", "9F02", 
                            "9F03", "9F07", "9F09", "9F0D", "9F0E", "9F0F", "9F10", "9F12", "9F15", "9F1A" ,
                            "9F1C" , "9F1E", "9F21", "9F26", "9F27", "9F33", "9F34", "9F35", "9F36", "9F37",
                            "9F39", "9F41", "9F53" , "C1"};
            
            
            try
            {

                if (!String.IsNullOrEmpty(Txt_Monto_Cargar.Text))
                {
                    Double.TryParse(string.Format("{0:n}", Txt_Monto_Cargar.Text.Replace("$", "")), out Monto_A_Cargar);

                    if (Monto_A_Cargar > 0)
                    {

                        Matriz_Tag = new string[50, 3];
                        Estatus_Tarjeta_Chip = false;
                        Estatus_Tarjeta_Tiene_Chip = false;
                        Estatus_Chip_Sin_Leyenda = false; 
                        Str_EmvTag = "";
                        Str_Arqc = "";
                        Str_Aid = "";
                        Str_Tvr = "";
                        Str_Tsi = "";
                        Str_Pin_Entry = "";
                        Str_EmvTag = "";
                        Str_Entry_Mode = "";
                        Str_Delinado = "";
                        Str_Card_Brand = "";
                        Str_ISSUING_BANK = "";

                        //  se genera el numero de control
                        Str_Numero_Control = Generar_Numero_Control();

                        //CREA TABLA CON PARÁMETROS DE LA PINPAD
                        Hst_ConfiguracionPinPad.Add("PORT", Str_Pinpad_Com);
                        Hst_ConfiguracionPinPad.Add("BAUD_RATE", "19200");
                        Hst_ConfiguracionPinPad.Add("PARITY", "N");
                        Hst_ConfiguracionPinPad.Add("STOP_BITS", "1");
                        Hst_ConfiguracionPinPad.Add("DATA_BITS", "8");

                        Pinpad.prepareDevice(Hst_ConfiguracionPinPad);
                        Pinpad.getInformation(Hst_Salida);
                        Pinpad.getSelector(Hst_Selector);

                        //  obtener el numero de serie
                        foreach (DictionaryEntry Item in Hst_Salida)
                        {
                            if (Item.Key.ToString() == "SERIAL_NUMBER")
                            {
                                Str_Numero_Serie = Item.Value.ToString();
                                break;
                            }
                        }

                        //  obtener la llave del dispositivo
                        foreach (DictionaryEntry Item in Hst_Selector)
                        {
                            if (Item.Key.ToString() == "SELECTOR")
                            {
                                Str_Llave_Maestra = Item.Value.ToString();
                                break;
                            }
                        }

                        //  transaccion ****************************************************************************
                        Pinpad.displayText("Pago en linea");
                        Pinpad.startTransaction();

                        //  tipo de operacion venta 
                        Str_Tipo_Operacion_Venta = "AUTH";

                        Hst_EntradaLeer.Add("PAGO_MOVIL", "0");
                        Hst_EntradaLeer.Add("AMOUNT", Txt_Monto_Cargar.Text);


                        //  tarjeta ******************************************
                        Pinpad.readCard(Hst_EntradaLeer, Hst_SalidaLeer);

                        #region Lectura_Tarjeta
                        //  obtener la llave del dispositivo
                        foreach (DictionaryEntry Item in Hst_SalidaLeer)
                        {
                            if (Item.Key.ToString() == "CARD_NUMBER")
                            {
                                Str_Numero_Tarjeta = Item.Value.ToString();
                                Str_Bin = Item.Value.ToString().Substring(0, 6);
                            }
                            else if (Item.Key.ToString() == "PIN_ENTRY")
                            {
                                Str_Pin_Entry = Item.Value.ToString();
                                Estatus_Tarjeta_Tiene_Chip = true;

                                if (Str_Pin_Entry == "1")
                                    Estatus_Tarjeta_Chip = true;
                                else
                                    Estatus_Tarjeta_Chip = false;
                            }

                            else if (Item.Key.ToString() == "ARQC")
                            {
                                Str_Arqc = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "AID")
                            {
                                Str_Aid = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "CARD_EXP")
                            {
                                Str_Tarjeta_Expiracion = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "APN")
                            {
                                Lbl_Tipo_Tarjeta.Text = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "CARD_HOLDER")
                            {
                                Str_Titular_Tarjeta = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "CHIP_DECLINED")
                            {
                                Str_Accion_Tarjeta = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "ENTRY_MODE")
                            {
                                Str_Entry_Mode = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "EMV_TAGS")
                            {
                                Str_Emv_Tags = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "TRACK2")
                            {
                                Str_Track2 = Item.Value.ToString();
                            }
                            else if (Item.Key.ToString() == "AL")
                            {
                                Str_Tipo_De_Tarjeta = Item.Value.ToString();
                            }
                        }
                        #endregion

                        Txt_Numero_Tarjeta.Text = Str_Numero_Tarjeta;
                        Txt_Titular_Tarjeta.Text = Str_Titular_Tarjeta;

                        //  datos a enviar para la transaccion ******************************
                        if (Str_Accion_Tarjeta != "1")
                        {
                            #region Enviar_Transaccion
                            // PARÁMETROS DE ENTRADA PARA ENVIAR LA TRANSACCIÓN
                            Hst_Datos_A_Enviar.Add("CMD_TRANS", Str_Tipo_Operacion_Venta);
                            Hst_Datos_A_Enviar.Add("MODE", Str_Modo_Operacion);
                            Hst_Datos_A_Enviar.Add("TERMINAL_ID", Str_Numero_Serie);
                            Hst_Datos_A_Enviar.Add("USER", Str_Usuario);
                            Hst_Datos_A_Enviar.Add("PASSWORD", Str_Contrasenia);
                            Hst_Datos_A_Enviar.Add("MERCHANT_ID", Str_Afiliacion);
                            Hst_Datos_A_Enviar.Add("CONTROL_NUMBER", Str_Numero_Control);
                            Hst_Datos_A_Enviar.Add("RESPONSE_LANGUAGE", "EN");
                            Hst_Datos_A_Enviar.Add("BANORTE_URL", Str_URL);
                            Hst_Datos_A_Enviar.Add("AMOUNT", Txt_Monto_Cargar.Text);
                            Hst_Datos_A_Enviar.Add("ENTRY_MODE", Str_Entry_Mode);
                            Hst_Datos_A_Enviar.Add("QPS", "0");

                            if (Str_Entry_Mode == "CHIP")
                                Hst_Datos_A_Enviar.Add("EMV_TAGS", Str_Emv_Tags);

                            if ((Str_Entry_Mode != "MANUAL") && (Str_Entry_Mode != ""))
                                Hst_Datos_A_Enviar.Add("TRACK2", Str_Track2);

                            Banorte.ConectorBanorte.sendTransaction(Hst_Datos_A_Enviar, Hst_SalidaLeer_Transaccion);
                            #endregion

                            #region EmvTag
                            //  emvtag
                            foreach (DictionaryEntry Item in Hst_Datos_A_Enviar)
                            {
                                if (Item.Key.ToString() == "EMV_TAGS")
                                {
                                    Str_EmvTag = Item.Value.ToString();
                                }
                            }

                            //  genereo la matriz de los tags
                            foreach (Char Valor in Str_EmvTag)
                            {
                                Auxiliar += Valor;

                                //  obtiene el tag
                                if (Cont_Operacion == 0)
                                {
                                    if (Auxiliar.Length == 2 || Auxiliar.Length == 4)
                                    {
                                        for (int Cont_For = 0; Cont_For < Diccionario.Length; Cont_For++)
                                        {
                                            if (Diccionario[Cont_For] == Auxiliar)
                                            {
                                                Matriz_Tag[Cont_Matriz, 0] = Auxiliar;

                                                Cont_Operacion++;
                                                Auxiliar = "";
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (Cont_Operacion == 1) //    validacion para la longitud
                                {
                                    if (Auxiliar.Length == 2)
                                    {
                                        Matriz_Tag[Cont_Matriz, 1] = Auxiliar;

                                        //Valor_Hexadecimal = Convert.ToInt64(Auxiliar, 10);
                                        Valor_Decimal = Convert.ToInt64(Auxiliar, 16);
                                        Valor_Decimal = Valor_Decimal * 2;
                                        Auxiliar = "";
                                        Cont_Operacion++;
                                    }
                                }
                                else if (Cont_Operacion == 2) //    validacion para los bits
                                {
                                    Valor_Decimal--;

                                    if (Valor_Decimal == 0)
                                    {
                                        Matriz_Tag[Cont_Matriz, 2] = Auxiliar;
                                        Cont_Operacion = 0;
                                        Auxiliar = "";
                                        Cont_Matriz++;
                                        Cont_Tag++;
                                    }
                                }
                            }

                            //  recorremos los tag para saber que tipo de leyenda va
                            for (int Cont_For = 0; Cont_For < 50; Cont_For++)
                            {
                                if (Matriz_Tag[Cont_For, 0] == "9F34")
                                {
                                    //  validacion para tarjeta con chip SIN pin 
                                    if (Matriz_Tag[Cont_For, 2].Substring(0, 2) == "1E" || Matriz_Tag[Cont_For, 2].Substring(0, 2) == "5E")
                                    {
                                        Estatus_Chip_Sin_Leyenda = true;
                                    }
                                    //  validacion para tarjete con chip y pin
                                    else if (Matriz_Tag[Cont_For, 0].Substring(0, 2) == "01" || Matriz_Tag[Cont_For, 0].Substring(0, 2) == "04"
                                        || Matriz_Tag[Cont_For, 0].Substring(0, 2) == "41" || Matriz_Tag[Cont_For, 0].Substring(0, 2) == "44")
                                    {
                                        Estatus_Chip = true;
                                    }
                                }
                            }
                            #endregion

                            #region Respuesta_Transaccion
                            if (Str_Tipo_Operacion_Venta == "AUTH")
                            {
                                foreach (DictionaryEntry Item in Hst_SalidaLeer_Transaccion)
                                {
                                    if (Item.Key.ToString() == "REFERENCE")
                                    {
                                        Txt_Referencia.Text = Item.Value.ToString();
                                        Str_Referencia = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "AUTH_CODE")
                                    {
                                        Txt_Numero_Autorizacion.Text = Item.Value.ToString();
                                        Str_Auth_Code = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "PAYW_RESULT")
                                    {
                                        Str_Resultado_Lectura_Transaccion = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "EMV_DATA")
                                    {
                                        Str_Emv_Data = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "Date")
                                    {
                                        Dtime_Fecha_Transaccion = Convert.ToDateTime(Item.Value.ToString());
                                    }
                                    else if (Item.Key.ToString() == "CHIP_DECLINED")
                                    {
                                        Str_Chip_Declinado = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "CARD_BRAND")
                                    {
                                        Str_Card_Brand = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "ISSUING_BANK")
                                    {
                                        Str_ISSUING_BANK = Item.Value.ToString();
                                    }
                                }// fin del foreach

                            }//  fin del if  auth
                            #endregion

                            #region Validacion_Tarjeta_Chip
                            //  SI LA TRANSACCIÓN ES DE CHIP SE REALIZAN LAS VALIDACIONES DE NOTIFICAR RESULTADO
                            if (Str_Entry_Mode == "CHIP")
                            {
                                switch (Str_Resultado_Lectura_Transaccion)
                                {
                                    case "A":
                                        Hst_Entrada_Notificar.Add("RESULT", "APPROVED");
                                        break;
                                    case "D":
                                        Hst_Entrada_Notificar.Add("RESULT", "DECLINED");
                                        break;
                                    case "T":
                                        Hst_Entrada_Notificar.Add("RESULT", "NO_RESPONSE");
                                        break;
                                    case "R":
                                        Hst_Entrada_Notificar.Add("RESULT", "DECLINED");
                                        break;

                                    default:
                                        Hst_Entrada_Notificar.Add("RESULT", "NO_RESPONSE");
                                        break;
                                }

                                //  SI AUTH_CODE Y EMV_DATA VIENEN VACÍOS NO SE DEBEN ENVIAR EN EL MÉTODO NOTIFICAR RESULTADO
                                if (Str_Auth_Code != "")
                                {
                                    Hst_Entrada_Notificar.Add("AUTH_CODE", Str_Auth_Code);
                                }
                                if (Str_Emv_Data != "")
                                {
                                    Hst_Entrada_Notificar.Add("EMV_DATA", Str_Emv_Data);
                                }

                                Pinpad.notifyResult(Hst_Entrada_Notificar, Hst_Salida_Notificar);

                                #region Obtencion_Resultado_Notificacion
                                foreach (DictionaryEntry Item in Hst_Salida_Notificar)
                                {
                                    if (Item.Key.ToString() == "EMV_RESULT")
                                    {
                                        Str_Emv_Result = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "TVR")
                                    {
                                        Str_Tvr = Item.Value.ToString();
                                    }
                                    else if (Item.Key.ToString() == "TSI")
                                    {
                                        Str_Tsi = Item.Value.ToString();
                                    }
                                }
                                #endregion

                                #region Resultado_A_Mostrar
                                if (Str_Resultado_Lectura_Transaccion == "A" && Str_Emv_Result == "A")
                                {
                                    Estatus_Aprobado = true;
                                    Str_Mensaje = "Aprobada: " + Str_Auth_Code;
                                    Lbl_Monto_Autorizado.Text = Txt_Monto_Cargar.Text;
                                    Estatus_Chip = true;
                                }
                                else if (Str_Resultado_Lectura_Transaccion == "D") // rechazada
                                {
                                    Estatus_Rechazada = true;
                                    Str_Mensaje = "Rechazada";
                                }
                                #endregion
                            }
                            #endregion

                            //******************************************************************
                            //******************************************************************
                            //******************************************************************
                            //  fuera de linea
                            if (Str_Chip_Declinado == "1")
                            {
                                Estatus_Aprobado = false;
                                Str_Mensaje = "Declinada Offline";
                            }
                            //******************************************************************
                            //******************************************************************
                            //  validacion para tarjetas con banda magnetica
                            else if ((Str_Entry_Mode != "CHIP") 
                                && (Str_Resultado_Lectura_Transaccion == "A"))
                            {
                                Estatus_Aprobado = true;
                                Str_Mensaje = "Aprobada: " + Str_Auth_Code;
                                Lbl_Monto_Autorizado.Text = Txt_Monto_Cargar.Text;

                                if (String.IsNullOrEmpty(Lbl_Tipo_Tarjeta.Text))
                                {
                                    Lbl_Tipo_Tarjeta.Text = "DEBITO";
                                }
                            }
                            //******************************************************************
                            //******************************************************************
                            //******************************************************************
                            else if ((Str_Resultado_Lectura_Transaccion == "D") 
                                || (Str_Resultado_Lectura_Transaccion == "T") 
                                || (Str_Resultado_Lectura_Transaccion == "R"))
                            {
                                Estatus_Aprobado = false;
                                Str_Mensaje = "Declinada ";
                                Str_Delinado = "DECLINADA";

                                //  se ejectua el para el reverso de la transaccion anterior
                                //   referencia
                                Hst_Entrada_Reversa.Add("CMD_TRANS", "REVERSAL");
                                Hst_Entrada_Reversa.Add("MODE", Str_Modo_Operacion);
                                Hst_Entrada_Reversa.Add("MERCHANT_ID", Str_Afiliacion);
                                Hst_Entrada_Reversa.Add("USER", Str_Usuario);
                                Hst_Entrada_Reversa.Add("PASSWORD", Str_Contrasenia);
                                Hst_Entrada_Reversa.Add("TERMINAL_ID", Str_Numero_Serie);
                                Hst_Entrada_Reversa.Add("REFERENCE", Str_Referencia);
                                Hst_Entrada_Reversa.Add("RESPONSE_LANGUAGE", "EN");
                                Hst_Entrada_Reversa.Add("BANORTE_URL", Str_URL);
                                Hst_Entrada_Reversa.Add("CAUSA", "06");

                                // se envia el reverso a banorte
                                Banorte.ConectorBanorte.sendTransaction(Hst_Entrada_Reversa, Hst_Salida_Reversa);

                            }
                            //******************************************************************
                            //******************************************************************
                            //******************************************************************

                        }// fin del if Str_Accion_Tarjeta != 1

                        //******************************************************************
                        //******************************************************************
                        //******************************************************************
                        Pinpad.displayText(Str_Mensaje);

                        //******************************************************************
                        //******************************************************************
                        //******************************************************************
                        //  termina la transaccion
                        Pinpad.endTransaction();

                        //******************************************************************
                        //******************************************************************
                        //******************************************************************
                        //  se libera el equipo pin pad **************************************
                        Pinpad.releaseDevice();


                        //******************************************************************
                        //******************************************************************
                        //******************************************************************
                        //  impresion de documentos
                        if (Estatus_Aprobado == true)
                        {
                            //  se genera la impresion del Vouchers de venta
                            Cls_Cat_Impresoras_Cajas_Negocio Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                            Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                            Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                            for (int Cont_For = 0; Cont_For < 2; Cont_For++)
                            {
                                printFont = new Font("Arial", 8);
                                PrintDocument PD = new PrintDocument();
                                PD.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Pago;
                                PD.PrintPage += new PrintPageEventHandler(Imprimir_Solicitud);
                                PD.Print();
                            }

                            Chk_Pago_Con_Tarjeta.Checked = true;
                            MessageBox.Show(this, "Aprobada: " + Str_Auth_Code, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (MessageBox.Show(this, "Desea terminar la venta", "Información", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Btn_Pagar_Click(null, null);
                            }
                        }
                        else if (Str_Delinado != "")
                        {
                            //  se genera la impresion del Vouchers de venta
                            Cls_Cat_Impresoras_Cajas_Negocio Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                            Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                            Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                            for (int Cont_For = 0; Cont_For < 2; Cont_For++)
                            {
                                printFont = new Font("Arial", 6);
                                PrintDocument PD = new PrintDocument();
                                PD.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Pago;
                                PD.PrintPage += new PrintPageEventHandler(Documento_Declinado);
                                PD.Print();
                            }

                            Chk_Pago_Con_Tarjeta.Checked = true;
                            MessageBox.Show(this, "Declinada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (Str_Chip_Declinado == "1")
                        {
                            //  se genera la impresion del Vouchers de venta
                            Cls_Cat_Impresoras_Cajas_Negocio Obj_Impresora_Caja = new Cls_Cat_Impresoras_Cajas_Negocio();
                            Obj_Impresora_Caja.P_Caja_ID = ERP_BASE.Paginas.Paginas_Generales.MDI_Frm_Apl_Principal.Caja_ID;
                            Obj_Impresora_Caja = Obj_Impresora_Caja.Obtener_Impresoras_Cajas();

                            for (int Cont_For = 0; Cont_For < 2; Cont_For++)
                            {
                                printFont = new Font("Arial", 6);
                                PrintDocument PD = new PrintDocument();
                                PD.PrinterSettings.PrinterName = Obj_Impresora_Caja.P_Impresora_Pago;
                                PD.PrintPage += new PrintPageEventHandler(Documento_Declinado_Offline);
                                PD.Print();
                            }

                            Chk_Pago_Con_Tarjeta.Checked = true;
                            MessageBox.Show(this, "Declinada offline", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                        MessageBox.Show(this, "Introduzca la cantidad a cargar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Introduzca la cantidad a cargar", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {    //  se libera el equipo pin pad **************************************
                //Pinpad.releaseDevice();
                MessageBox.Show(this, Ex.Message, "Error - Método :[Btn_Pago_PinPad_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Imprimir_Solicitud(object sender, PrintPageEventArgs e)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = 5;
                float topMargin = 55;
                string line = null;

                List<string> Texto_Imprimir = new List<string>();
                Cls_Apl_Parametros_Negocio Obj_Parametros = new Cls_Apl_Parametros_Negocio();

                //  se obtiene la imagen del directorio compartido
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                //string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Accesos/Acceso.png";
                //Image Logo = Image.FromFile(Ruta_Archivo);

                Texto_Imprimir.Add("                       BANORTE\n");//   Encabezado del banco
                Texto_Imprimir.Add("                        Venta");
                Texto_Imprimir.Add("\n\n");
                Texto_Imprimir.Add("     MUNICIPIO DE GUANAJUAT\n");//  encabezado del cliente
                Texto_Imprimir.Add("    INT MUSEO MOMIAS TEPETAPA SN\n");
                Texto_Imprimir.Add("   Explanada del Panteón Municipal s/n,\n");
                Texto_Imprimir.Add("   Centro, C.P. 36000, Guanajuato, México.\n");
                Texto_Imprimir.Add("       Teléfono: (473) 732 06 39");

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Afiliación:       " + "7749753");// Afiliacion
                Texto_Imprimir.Add("\n    Terminal ID:   " + Str_Numero_Serie);// terminal id
                Texto_Imprimir.Add("\n    Número de control:    " + Str_Numero_Control);// no de control

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Número de tarjeta        Vigencia");
                Texto_Imprimir.Add("\n    xxxxxxxxxxxx" + Txt_Numero_Tarjeta.Text.Substring(12, 4) + "        " + Str_Tarjeta_Expiracion);

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n______________ APROBADA _____________");

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Tipo de tarjeta:     " + Str_Card_Brand );
                Texto_Imprimir.Add("\n    Tipo:                     " + Lbl_Tipo_Tarjeta.Text);
                Texto_Imprimir.Add("\n    Banco Emisor:       " + Str_ISSUING_BANK);
                Texto_Imprimir.Add("\n    Codigo Autoricación: " + Txt_Numero_Autorizacion.Text);
                Texto_Imprimir.Add("\n    Referencia:          " + Txt_Referencia.Text);

                if (Estatus_Chip == true)
                    Texto_Imprimir.Add("\n    ARQC:                 " + Str_Arqc);

                Texto_Imprimir.Add("\n\n");//   importe
                Texto_Imprimir.Add("\n    Importe:             " + Convert.ToDouble(Txt_Monto_Cargar.Text).ToString("C2"));
                
             
                
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");


                if (Str_Entry_Mode == "CHIP")//    chip
                {
                    if (Estatus_Chip_Sin_Leyenda == true && Estatus_Tarjeta_Chip == true)//    chip con pin
                    {
                        Texto_Imprimir.Add("\n          VALIDADO CON ");
                        Texto_Imprimir.Add("\n        FIRMA ELECTRONICA");
                    }
                    else
                    {
                        Texto_Imprimir.Add("\n__________________________________\n");//   Titular de la tarjeta   
                        Texto_Imprimir.Add("\n         " + Txt_Titular_Tarjeta.Text);

                     
                          
                    }
                }
                else//  magnetica
                {
                    Texto_Imprimir.Add("\n__________________________________\n");//   Titular de la tarjeta
                }

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n Fecha:   " + Dtime_Fecha_Transaccion.ToLongDateString());
                Texto_Imprimir.Add("\n Hora:     " + Dtime_Fecha_Transaccion.ToLongTimeString());
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");

                if (Str_Entry_Mode == "CHIP")
                {
                    Texto_Imprimir.Add("\n    AID:                 " + Str_Aid);
                    Texto_Imprimir.Add("\n    TVR:                " + Str_Tvr);
                    Texto_Imprimir.Add("\n    TSI:                 " + Str_Tsi);
                    Texto_Imprimir.Add("\n    APN:               " + Str_Tipo_De_Tarjeta);
                }

                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                float Height = 0;

                foreach (string Linea in Texto_Imprimir)
                {
                    Height = printFont.GetHeight(e.Graphics) + 5;
                    yPos = topMargin + (count * Height);
                    e.Graphics.DrawString(Linea, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                    count++;
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #region Declinacion_Documento
        /// <summary>
        /// Nombre: Documento_Declinado
        /// Descripción: Se realiza el documento declinado
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 24 Abril 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public void Documento_Declinado(object sender, PrintPageEventArgs e)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = 5;
                float topMargin = 55;
                string line = null;

                List<string> Texto_Imprimir = new List<string>();
                Cls_Apl_Parametros_Negocio Obj_Parametros = new Cls_Apl_Parametros_Negocio();

                //  se obtiene la imagen del directorio compartido
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                //string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Accesos/Acceso.png";
                //Image Logo = Image.FromFile(Ruta_Archivo);

                Texto_Imprimir.Add("                       BANORTE\n");//   Encabezado del banco
                Texto_Imprimir.Add("                        Venta");
                Texto_Imprimir.Add("\n\n");
                Texto_Imprimir.Add("     MUNICIPIO DE GUANAJUAT\n");//  encabezado del cliente
                Texto_Imprimir.Add("    INT MUSEO MOMIAS TEPETAPA SN\n");
                Texto_Imprimir.Add("   Explanada del Panteón Municipal s/n,\n");
                Texto_Imprimir.Add("   Centro, C.P. 36000, Guanajuato, México.\n");
                Texto_Imprimir.Add("       Teléfono: (473) 732 06 39");

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Afiliación:       " + "7749753");// Afiliacion
                Texto_Imprimir.Add("\n    Terminal ID:   " + Str_Numero_Serie);// terminal id
                Texto_Imprimir.Add("\n    Número de control:    " + Str_Numero_Control);// no de control

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n___________Declinada EMV _____________");


                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n Fecha:   " + Dtime_Fecha_Transaccion.ToLongDateString());
                Texto_Imprimir.Add("\n Hora:     " + Dtime_Fecha_Transaccion.ToLongTimeString());
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");

                Texto_Imprimir.Add("\n    AID:                 " + Str_Aid);
                Texto_Imprimir.Add("\n    APN:               " + Str_Tipo_De_Tarjeta);
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");

                String[] Diccionario = new String[18] { "5A", "82", "95", "9A" , "9C",
                             "5F2A" , "5F34", "9F02", "9F03", "9F10", 
                             "9F12", "9F1A" , "9F26", "9F27", "9F33",
                             "9F34", "9F36", "9F37",
                };

                for (int Cont_Diccionario = 0; Cont_Diccionario < Diccionario.Length; Cont_Diccionario++)
                {
                    for (int Cont_For = 0; Cont_For < 50; Cont_For++)
                    {

                        if (Matriz_Tag[Cont_For, 0] == Diccionario[Cont_Diccionario])
                        {
                            if(Matriz_Tag[Cont_For, 0] == "5A")
                                Texto_Imprimir.Add("\n    " + Matriz_Tag[Cont_For, 0] + " " + Matriz_Tag[Cont_For, 1] + " XXXXXXXXXXXX" + Matriz_Tag[Cont_For, 2].Substring(12, 4));
                            else
                                Texto_Imprimir.Add("\n    " + Matriz_Tag[Cont_For, 0] + " " + Matriz_Tag[Cont_For, 1] + " " + Matriz_Tag[Cont_For, 2]);

                            break;
                        }
                    }
                }


                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                float Height = 0;

                foreach (string Linea in Texto_Imprimir)
                {
                    Height = printFont.GetHeight(e.Graphics) + 5;
                    yPos = topMargin + (count * Height);
                    e.Graphics.DrawString(Linea, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                    count++;
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Nombre: Documento_Declinado_Offline
        /// Descripción: Se realiza el documento declinado
        /// Usuario Creo: Hugo Enrique Ramírez Aguilera
        /// Fecha Creo: 24 Abril 2015.
        /// Usuario Modifico:
        /// Fecha Modifico:
        /// </summary>
        public void Documento_Declinado_Offline(object sender, PrintPageEventArgs e)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = 5;
                float topMargin = 55;
                string line = null;

                List<string> Texto_Imprimir = new List<string>();
                Cls_Apl_Parametros_Negocio Obj_Parametros = new Cls_Apl_Parametros_Negocio();

                //  se obtiene la imagen del directorio compartido
                Obj_Parametros = Obj_Parametros.Obtener_Parametros();
                //string Ruta_Archivo = Obj_Parametros.P_Directorio_Compartido + "/Imagenes/Accesos/Acceso.png";
                //Image Logo = Image.FromFile(Ruta_Archivo);

                Texto_Imprimir.Add("                       BANORTE\n");//   Encabezado del banco
                Texto_Imprimir.Add("                        Venta");
                Texto_Imprimir.Add("\n\n");
                Texto_Imprimir.Add("     MUNICIPIO DE GUANAJUAT\n");//  encabezado del cliente
                Texto_Imprimir.Add("    INT MUSEO MOMIAS TEPETAPA SN\n");
                Texto_Imprimir.Add("   Explanada del Panteón Municipal s/n,\n");
                Texto_Imprimir.Add("   Centro, C.P. 36000, Guanajuato, México.\n");
                Texto_Imprimir.Add("       Teléfono: (473) 732 06 39");

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n    Afiliación:       " + "7749753");// Afiliacion
                Texto_Imprimir.Add("\n    Terminal ID:   " + Str_Numero_Serie);// terminal id
                Texto_Imprimir.Add("\n    Número de control:    " + Str_Numero_Control);// no de control

                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n___________Declinada Offline____________");


                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n Fecha:   " + Dtime_Fecha_Transaccion.ToLongDateString());
                Texto_Imprimir.Add("\n Hora:     " + Dtime_Fecha_Transaccion.ToLongTimeString());
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");

                Texto_Imprimir.Add("\n    AID:                 " + Str_Aid);
                Texto_Imprimir.Add("\n    APN:               " + Str_Tipo_De_Tarjeta);
                Texto_Imprimir.Add("\n");
                Texto_Imprimir.Add("\n");

                String[] Diccionario = new String[17] { "9F26", "9F27", "9F10", "9F37" , "9F36",
                             "95" , "9A", "9C", "9F02", "5F2A", 
                             "82", "5A" , "9F1A", "9F33", "9F34",
                             "9F03", "5F34"};

                for (int Cont_Diccionario = 0; Cont_Diccionario < Diccionario.Length; Cont_Diccionario++)
                {
                    for (int Cont_For = 0; Cont_For < 50; Cont_For++)
                    {

                        if (Matriz_Tag[Cont_For, 0] == Diccionario[Cont_Diccionario])
                        {
                            if (Matriz_Tag[Cont_For, 0] == "5A")
                                Texto_Imprimir.Add("\n    " + Matriz_Tag[Cont_For, 0] + " " + Matriz_Tag[Cont_For, 1] + " XXXXXXXXXXXX" + Matriz_Tag[Cont_For, 2].Substring(12, 4));
                            else
                                Texto_Imprimir.Add("\n    " + Matriz_Tag[Cont_For, 0] + " " + Matriz_Tag[Cont_For, 1] + " " + Matriz_Tag[Cont_For, 2]);

                            break;
                        }
                    }
                }

                linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
                float Height = 0;

                foreach (string Linea in Texto_Imprimir)
                {
                    Height = printFont.GetHeight(e.Graphics) + 5;
                    yPos = topMargin + (count * Height);
                    e.Graphics.DrawString(Linea, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());

                    count++;
                }

                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
