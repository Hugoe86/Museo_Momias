using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Constantes;
using Erp_Apl_Usuarios.Negocio;
using Erp.Seguridad;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Operaciones;
using Erp.Validador;


namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    public partial class Frm_Cat_Ventana_Emergente_Motivos_Descuento : Form
    {
        private String Usuario_Id;
        private String Str_Motivo_Descuento_Id;
        private String Monto_A_Pagar;
        Frm_Ope_Pago Frm_Pago; 
        Validador_Generico Validador;

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Ventana_Emergente_Motivos_Descuento
        ///DESCRIPCIÓN          : Inicializa los campos del formulario.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Frm_Cat_Ventana_Emergente_Motivos_Descuento()
        {
            InitializeComponent();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Ventana_Emergente_Motivos_Descuento_Load
        ///DESCRIPCIÓN          : Evento load del formulario Frm_Cat_Ventana_Emergente_Motivos_Descuento
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Frm_Cat_Ventana_Emergente_Motivos_Descuento_Load(object sender, EventArgs e)
        {
            Validador = new Validador_Generico(Erp_Descuentos);
            //Llenar_Grid();
            Cls_Metodos_Generales.Habilita_Deshabilita_Controles(Fra_Autenticacion, true);

            this.ActiveControl = Txt_Porcentaje_Descuento;
            Txt_Porcentaje_Descuento.Focus();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Numerico_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres numéricos.
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 13/Feb/2015
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Numerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN: Txt_Numerico_KeyPress
        ///DESCRIPCIÓN  : Permite escribir caracteres numéricos.
        ///PARAMENTROS  :
        ///CREO         : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO   : 13/Feb/2015
        ///MODIFICO     :
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACIÓN:
        ///*******************************************************************************
        private void Txt_Porcentaje_Descuento_TextChanged(object sender, EventArgs e)
        {
            Double Porcentaje= 0;
            Double Descuento = 0;
            Double Monto_A_Pagar = 0;
            Double Monto_Inicial = 0;
            

            try
            {
                Double.TryParse(string.Format("{0:n}",Txt_Monto_Inicial.Text), out Monto_Inicial);
                Double.TryParse(string.Format("{0:n}",Txt_Porcentaje_Descuento.Text), out Porcentaje);

                if (Porcentaje <= 100)
                {
                    Porcentaje = Porcentaje / 100;
                    Descuento = Monto_Inicial * Porcentaje;
                    Monto_A_Pagar = Monto_Inicial - Descuento;

                    Txt_Descuento.Text = (Descuento).ToString();
                    Txt_Monto_A_Pagar.Text = Monto_A_Pagar.ToString();
                }
                else
                {
                    Txt_Porcentaje_Descuento.SelectionStart = 0;
                    Txt_Porcentaje_Descuento.SelectionLength = Txt_Porcentaje_Descuento.Text.Length;
                    Txt_Descuento.Text = "";
                    Txt_Monto_A_Pagar.Text ="";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Metodo: [Txt_Porcentaje_Descuento_TextChanged]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void Set_Monto_A_Pagar(String Str_Monto_A_Pagar)
        {
            Txt_Monto_Inicial.Text = Str_Monto_A_Pagar;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Aceptar_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Aceptar para enviar los datos 
        ///                       de esta pantalla ala pantalla Frm_Ope_Pagos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Aceptar_Click(object sender, EventArgs e)
        {
            DataTable Dt_Usuario;
            Cls_Apl_Usuarios_Negocio P_Usuario = new Cls_Apl_Usuarios_Negocio();
            Double Porcentaje = 0;

            if (!String.IsNullOrEmpty(Txt_Porcentaje_Descuento.Text))
            {
                Double.TryParse(string.Format("{0:n}",Txt_Porcentaje_Descuento.Text), out Porcentaje);

                if (Porcentaje <= 100)
                {


                    if (!String.IsNullOrEmpty(Txt_Documento_Oficial.Text))
                    {
                        // validar que se haya ingresado el nombre de usuario y contraseña
                        if (Txt_Usuario.Text.Trim().Length > 0 && Txt_Contrasenia.Text.Trim().Length > 0)
                        {
                            P_Usuario.P_Usuario = Txt_Usuario.Text.Trim();
                            P_Usuario.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Contrasenia.Text.ToString());
                            P_Usuario.P_Estatus = "ACTIVO";
                            Dt_Usuario = P_Usuario.Consultar_Usuario();
                            if (Dt_Usuario.Rows.Count > 0)
                            {
                                Usuario_Id = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
                            }
                            else
                            {
                                Usuario_Id = "";
                            }
                            //Str_Motivo_Descuento_Id = Grid_Motivos_Descuento.CurrentRow.Cells[Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID].Value.ToString();
                            if (!String.IsNullOrEmpty(Usuario_Id))
                            {
                                Frm_Pago.Enabled = true;

                                //Frm_Pago.Set_Motivo_Descuento_Id(Str_Motivo_Descuento_Id);
                                Frm_Pago.Set_Documento_Oficial(Txt_Documento_Oficial.Text);
                                Frm_Pago.Set_Descuento(Txt_Descuento.Text);
                                Frm_Pago.Set_Usuario_Autoriza_Id(Usuario_Id);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(this, "No se encontro el usuario.", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Debe ingresar el nombre de usuario y contraseña.", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Debe ingresar el documento oficial que avale el descuento.", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "El porcentaje debe ser menor o igual a 100%.", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Debe el porcentaje del descuento a realizar.", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Regresar para volver sin 
        ///                       aplicar los cambios al formulario Frm_Ope_Pagos.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            Frm_Pago.Enabled = true;
            this.Close();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Frm_Pago
        ///DESCRIPCIÓN          : Establece la referencia a la ventana Frm_Ope_Pagos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public void Set_Frm_Pago(Frm_Ope_Pago Frm_Pagos)
        {
            Frm_Pago = Frm_Pagos;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Llenar_Grid
        ///DESCRIPCIÓN          : Carga los diferentes motivos de descuento en el grid
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Llenar_Grid()
        {
            //DataTable Dt_Motivos_Descuento;
            //Cls_Cat_Motivos_Descuento_Negocio P_Motivos = new Cls_Cat_Motivos_Descuento_Negocio();
            //Dt_Motivos_Descuento = P_Motivos.Consultar_Motivos_Descuento();
            //Grid_Motivos_Descuento.Rows.Clear();
            //int Cont_Motivos = 0;
            //foreach (DataRow Dr_Motivo_Descuento in Dt_Motivos_Descuento.Rows)
            //{
            //    Grid_Motivos_Descuento.Rows.Add();
            //    Grid_Motivos_Descuento.Rows[Cont_Motivos].Cells[Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID].Value = Dr_Motivo_Descuento[Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID].ToString();
            //    Grid_Motivos_Descuento.Rows[Cont_Motivos].Cells[Cat_Motivos_Descuento.Campo_Descripcion].Value = Dr_Motivo_Descuento[Cat_Motivos_Descuento.Campo_Descripcion].ToString();
            //    Cont_Motivos++;
            //}

        }

       

        /////*******************************************************************************
        /////NOMBRE DE LA FUNCIÓN : Grid_Motivos_Descuento_CellClick
        /////DESCRIPCIÓN          : Evento CellClick del grid para guardar la informacion 
        /////                       del registro seleccionado.
        /////PARAMETROS           : 
        /////CREO                 : Miguel Angel Bedolla Moreno
        /////FECHA_CREO           : 13/Octubre/2013
        /////MODIFICO             :
        /////FECHA_MODIFICO       :
        /////CAUSA_MODIFICACIÓN   :
        /////*******************************************************************************
        //private void Grid_Motivos_Descuento_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataTable Dt_Usuario;
        //    Cls_Apl_Usuarios_Negocio P_Usuario = new Cls_Apl_Usuarios_Negocio();
        //    // validar que se haya ingresado el nombre de usuario y contraseña
        //    if (Txt_Usuario.Text.Trim().Length > 0 && Txt_Contrasenia.Text.Trim().Length > 0)
        //    {
        //        P_Usuario.P_Usuario = Txt_Usuario.Text;
        //        P_Usuario.P_Contrasenia = Cls_Seguridad.Encriptar(Txt_Contrasenia.Text.ToString());
        //        P_Usuario.P_Estatus = "ACTIVO";
        //        Dt_Usuario = P_Usuario.Consultar_Usuario();
        //        if (Dt_Usuario.Rows.Count > 0)
        //        {
        //            Usuario_Id = Dt_Usuario.Rows[0][Apl_Usuarios.Campo_Usuario_Id].ToString();
        //        }
        //        else
        //        {
        //            Usuario_Id = "";
        //        }
        //        Str_Motivo_Descuento_Id = Grid_Motivos_Descuento.CurrentRow.Cells[Cat_Motivos_Descuento.Campo_Motivo_Descuento_ID].Value.ToString();
        //        if (!String.IsNullOrEmpty(Usuario_Id) && !String.IsNullOrEmpty(Str_Motivo_Descuento_Id))
        //        {
        //            Frm_Pago.Enabled = true;
        //            Frm_Pago.Set_Motivo_Descuento_Id(Str_Motivo_Descuento_Id);
        //            Frm_Pago.Set_Usuario_Autoriza_Id(Usuario_Id);
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show(this, "No se encontro el usuario.", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show(this, "Debe ingresar el nombre de usuario y contraseña.", "Descuentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
