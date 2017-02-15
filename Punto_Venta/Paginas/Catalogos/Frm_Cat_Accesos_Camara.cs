using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp_Apl_Parametros.Negocio;
using ERP_BASE.Paginas.Paginas_Generales;
using Erp.Constantes;

namespace ERP_BASE.Paginas.Catalogos
{
    public partial class Frm_Cat_Accesos_Camara : Form
    { 
        #region Load
        public Frm_Cat_Accesos_Camara()
        {
            InitializeComponent();
        }
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Cat_Accesos_Camara_Load
        ///DESCRIPCIÓN          : 
        ///PARÁMETROS           :
        ///CREÓ                 : 
        ///FECHA_CREO           : 
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Frm_Cat_Accesos_Camara_Load(object sender, EventArgs e)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            String Parametro_Id = "";
            DataTable Dt_Consulta = new DataTable();

            Parametro_Id = "00001";
            Consulta_Parametros.P_Parametro_Id = Parametro_Id;
            Dt_Consulta = Consulta_Parametros.Consultar_Parametros();


            //  validacion para el administrador
            if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
            {
                if (MDI_Frm_Apl_Principal.Rol_ID == Dt_Consulta.Rows[0][Cat_Parametros.Campo_Rol_Id].ToString())
                {
                    Chk_Capturar_Informacion.Visible = true;
                }
                else
                {
                    Chk_Capturar_Informacion.Visible = false;
                }
            }
        }
        #endregion

        #region Metodos generales
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Migrar_Accesos_Camara_Click
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           :
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 10 Octubre 2013
        ///MODIFICÓ             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*************************************************************************************
        private void Btn_Migrar_Accesos_Camara_Click(object sender, EventArgs e)
        {
            Cls_Cat_Accesos_Camara_Negocio Negocio = new Cls_Cat_Accesos_Camara_Negocio();
            DataTable Dt_Consulta_Registros_Camaras = new DataTable();
            Negocio.P_Dtime_Fecha = Convert.ToDateTime(Dte_Fecha.Text);

            //  validacion para la captura de la informacion preliminar de las camaras
            if (Chk_Capturar_Informacion.Checked == false)
            {

                if (Negocio.P_Dtime_Fecha > DateTime.Now)
                {
                    MessageBox.Show("La fecha no puede ser mayor a la actual " + DateTime.Now.ToString("dd/MMM/yyyy"), "Validación"
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataTable Resultados = Negocio.Migrar_Datos_Camara_Negocio();

                    if (Resultados != null && Resultados.Rows.Count > 1)
                    {
                        //MessageBox.Show("Migración Exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Grd_Resultados.DataSource = Resultados;
                    }
                    else
                    {
                        Grd_Resultados.DataSource = new DataTable();
                    }
                }
            }
            else
            {
                //  proceso para la informacion pendiente de las camaras que no sea la del dia actual
                if (Negocio.P_Dtime_Fecha < DateTime.Now)
                {
                    //  se consulta que no exista informacion para poder continuar con la insercion
                    Dt_Consulta_Registros_Camaras = Negocio.Consultar_Si_Existe_Registros();

                    //  si no existen registros se procede a ser ingresados.
                    if (Dt_Consulta_Registros_Camaras != null && Dt_Consulta_Registros_Camaras.Rows.Count == 0)
                    {

                        DataTable Resultados = Negocio.Migrar_Datos_Pendientes_Camara();

                        if (Resultados != null && Resultados.Rows.Count > 1)
                        {
                            //MessageBox.Show("Migración Exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Grd_Resultados.DataSource = Resultados;
                        }
                        else
                        {
                            Grd_Resultados.DataSource = new DataTable();
                        }
                    }
                    else
                    {
                        Grd_Resultados.DataSource = new DataTable();
                    }
                }
                else
                {
                    Grd_Resultados.DataSource = new DataTable();
                }
            }
        }
        #endregion

      
    }
}
