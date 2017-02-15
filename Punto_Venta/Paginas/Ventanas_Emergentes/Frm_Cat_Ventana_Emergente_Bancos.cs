using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_BASE.Paginas.Operaciones;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Constantes;

namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    public partial class Frm_Cat_Ventana_Emergente_Bancos : Form
    {

        Frm_Ope_Pago Frm_Pago;
        Dictionary<String, Button> Dic_Botones_Bancos;
        DataTable Dt_Bancos;

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Ventana_Emergente_Bancos
        ///DESCRIPCIÓN          : Inicializa los campos del formulario
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 14/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Frm_Cat_Ventana_Emergente_Bancos()
        {
            InitializeComponent();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Regresar_Click
        ///DESCRIPCIÓN          : Evento click del boton Btn_Regresar, regresa el foco a la 
        ///                       pantalla de tipo Frm_Ope_Pagos
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
        ///NOMBRE DE LA FUNCIÓN : Btn_Banco_Click
        ///DESCRIPCIÓN          : Evento Click del boton Btn_Banco, establece los datos del banco
        ///                       en la pantalla de tipo Frm_Ope_Pagos
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Banco_Click(object sender, EventArgs e)
        {
            decimal Comision;
            DataRow Dr_Banco = Dt_Bancos.AsEnumerable().FirstOrDefault(x => x.Field<String>(Cat_Bancos.Campo_Banco_ID) == ((Button)sender).Name.Substring(((Button)sender).Name.Length - 5));
            decimal.TryParse(Dr_Banco[Cat_Bancos.Campo_Comision].ToString(), out Comision);
            Frm_Pago.Set_Datos_Banco(Dr_Banco[Cat_Bancos.Campo_Banco_ID].ToString(), Comision, Dr_Banco[Cat_Bancos.Campo_Nombre].ToString());
            Frm_Pago.Enabled = true;
            this.Close();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Ventana_Emergente_Bancos_Load
        ///DESCRIPCIÓN          : Evento Load del formulario
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Frm_Cat_Ventana_Emergente_Bancos_Load(object sender, EventArgs e)
        {
            Llenar_Dictionary();
            Llenar_Botones_Bancos();
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Llenar_Botones_Bancos
        ///DESCRIPCIÓN          : Evento para llenar los botones con la informacion del banco 
        ///                       dependiendo de los registros encontrados en la Bd.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Llenar_Botones_Bancos()
        {
            Button Btn_Ayudante;
            int Cont_Bancos = 0;
            decimal Comision;
            Cls_Cat_Bancos_Negocio P_Bancos = new Cls_Cat_Bancos_Negocio();
            Dt_Bancos = P_Bancos.Consultar_Bancos();
            int Renglones_Bancos = Dt_Bancos.Rows.Count;
            Cont_Bancos = 1;
            while (Cont_Bancos < 13)
            {
                Btn_Ayudante = Dic_Botones_Bancos.FirstOrDefault(x => x.Key == ("Btn_Banco" + Cont_Bancos)).Value;
                if (Cont_Bancos <= Renglones_Bancos)
                {
                    Btn_Ayudante.Visible = true;
                    Btn_Ayudante.Text = Dt_Bancos.Rows[Cont_Bancos - 1][Cat_Bancos.Campo_Nombre].ToString();
                    if (decimal.TryParse(Dt_Bancos.Rows[Cont_Bancos - 1][Cat_Bancos.Campo_Comision].ToString(), out Comision) == true && Comision > 0)
                    {
                        Btn_Ayudante.Text = Btn_Ayudante.Text + " + $" + Comision.ToString("#,##0.00");
                    }
                    Btn_Ayudante.BackgroundImage = Image.FromFile(Dt_Bancos.Rows[Cont_Bancos - 1][Cat_Bancos.Campo_Ruta_Logo].ToString());
                    Btn_Ayudante.Name = Btn_Ayudante.Name + Dt_Bancos.Rows[Cont_Bancos - 1][Cat_Bancos.Campo_Banco_ID].ToString();
                }
                Cont_Bancos++;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Llenar_Dictionary
        ///DESCRIPCIÓN          : Se cargan los diccionarios con los botones de los bancos.
        ///PARAMETROS           : 
        ///CREO                 : Miguel Angel Bedolla Moreno
        ///FECHA_CREO           : 13/Octubre/2013
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Llenar_Dictionary()
        {
            Dic_Botones_Bancos = new Dictionary<string, Button>();
            Dic_Botones_Bancos.Add(Btn_Banco1.Name, Btn_Banco1);
            Dic_Botones_Bancos.Add(Btn_Banco2.Name, Btn_Banco2);
            Dic_Botones_Bancos.Add(Btn_Banco3.Name, Btn_Banco3);
            Dic_Botones_Bancos.Add(Btn_Banco4.Name, Btn_Banco4);
            Dic_Botones_Bancos.Add(Btn_Banco5.Name, Btn_Banco5);
            Dic_Botones_Bancos.Add(Btn_Banco6.Name, Btn_Banco6);
            Dic_Botones_Bancos.Add(Btn_Banco7.Name, Btn_Banco7);
            Dic_Botones_Bancos.Add(Btn_Banco8.Name, Btn_Banco8);
            Dic_Botones_Bancos.Add(Btn_Banco9.Name, Btn_Banco9);
            Dic_Botones_Bancos.Add(Btn_Banco10.Name, Btn_Banco10);
            Dic_Botones_Bancos.Add(Btn_Banco11.Name, Btn_Banco11);
            Dic_Botones_Bancos.Add(Btn_Banco12.Name, Btn_Banco12);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Set_Frm_Pago
        ///DESCRIPCIÓN          : Se guarda la referencia del formulario Frm_Ope_Pagos.
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

    }
}
