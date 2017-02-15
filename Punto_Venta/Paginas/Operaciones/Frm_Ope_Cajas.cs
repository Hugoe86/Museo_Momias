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
using Microsoft.VisualBasic;
using Operaciones.Turnos.Negocio;
using Operaciones.Cajas.Negocio;
using Catalogos.Turnos.Negocio;
using Erp.Constantes;
using ResizeableForm;
using Erp_Apl_Parametros.Negocio;

namespace ERP_BASE.Paginas.Paginas_Generales
{
    public partial class Frm_Ope_Cajas : ResizableForm
    {
        private DataTable Cajas = null;

        public Frm_Ope_Cajas()
        {
            InitializeComponent();
            Grid_Cajas.AutoGenerateColumns = false;
        }

        #region Métodos Generales

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Cajas_Load
        ///DESCRIPCIÓN          : Muestra la forma en pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Frm_Ope_Cajas_Load(object sender, EventArgs e)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            String Parametro_Id = "";
            DataTable Dt_Consulta = new DataTable();

            Parametro_Id = "00001";
            Consulta_Parametros.P_Parametro_Id = Parametro_Id;
            Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

            if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
            {
                if (MDI_Frm_Apl_Principal.Rol_ID == Dt_Consulta.Rows[0][Cat_Parametros.Campo_Rol_Id].ToString())
                    Btn_Cierre.Enabled = true;
                else
                    Btn_Cierre.Enabled = false;
            }

            Cargar_Datos();


        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Datos
        ///DESCRIPCIÓN          : Inicializa los controles de pantalla, y verifica si hay turnos abiertos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Cargar_Datos() 
        {
            Cls_Cat_Cajas_Negocio P_Cajas = new Cls_Cat_Cajas_Negocio(); // Variable utilizada para obtener la informacion de las cajas registradas en la base de datos
            Cls_Ope_Turnos_Negocio P_Turnos = new Cls_Ope_Turnos_Negocio(); // Variable utilizada para obtner los turnos registrados en la base de datos
            DataTable Turnos = null; // DataTable que almacena la información de los turnos
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta = new DataTable();	

            Grid_Cajas.DataSource = null;
            Txt_No_Caja.Text = String.Empty;


            String Parametro_Id = "";
            Parametro_Id = "00001";
            Consulta_Parametros.P_Parametro_Id = Parametro_Id;
            Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

            ////  validacion para el administrador
            //if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
            //{
            //    if (MDI_Frm_Apl_Principal.Rol_ID != Dt_Consulta.Rows[0][Cat_Parametros.Campo_Rol_Id].ToString())
            //        P_Cajas.P_Caja_ID = MDI_Frm_Apl_Principal.Caja_ID;
            //}


            P_Cajas.P_Nombre_Equipo = Environment.MachineName;
            P_Cajas.P_Estatus = "ACTIVO";
            Cajas = P_Cajas.Consultar_Caja();

            Cmb_Numero_Caja.DataSource = Cajas;
            Cmb_Numero_Caja.DisplayMember = "Numero_Caja";
            Cmb_Numero_Caja.ValueMember = "Caja_ID";

            P_Turnos.P_Estatus = "ABIERTO";
            Turnos = P_Turnos.Consultar_Turnos();

            //Verifica si existen turnos abiertos
            if (Turnos.Rows.Count == 0)
            {
                MessageBox.Show("No hay turnos abiertos", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Btn_Apertura.Enabled = false;
                Btn_Cierre.Enabled = false;
            }
            else
            {
                //DateTime Dtime_Fecha_Turno = Convert.ToDateTime(Turnos.Rows[0]["Hora_Inicio"].ToString());

                ////  se valida la fecha del turno
                //if (Dtime_Fecha_Turno.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
                //{
                    Txt_Fecha.Text = DateTime.Now.ToLongDateString();
                    Txt_Turno_ID.Text = Turnos.Rows[0]["No_Turno"].ToString();
                    Txt_Turno.Text = Nombre_Turno(Txt_Turno_ID.Text);
                    Cargar_Cajas();
                //}
                //else
                //{
                //    if (Turnos.AsEnumerable().Any())
                //    {
                //        this.BeginInvoke((MethodInvoker)delegate
                //        {
                //            //  se activan los menus de recoleccino, arqueo, cierre de caja
                //            MDI_Frm_Apl_Principal Frm_Principal = (MDI_Frm_Apl_Principal)this.MdiParent;

                //            MessageBox.Show("El turno abierto no corresponde con la fecha actual, revise el turno", "Turnos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            this.Dispose();
                //        });
                //    }
                //}
            }

        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cargar_Cajas
        ///DESCRIPCIÓN          : Verifica si existen operaciones de caja abiertos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Cargar_Cajas() 
        {
            Cls_Ope_Cajas_Negocio P_Caja = new Cls_Ope_Cajas_Negocio(); // Variable utilizada para consultar las operaciones de caja registradas en la base de datos
            DataTable Operacion_Cajas = null; // Variable utilizada para almacenar la información obtenida de las operaciones de caja

            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta = new DataTable();
            String Parametro_Id = "";
            try
            {
                Parametro_Id = "00001";
                Consulta_Parametros.P_Parametro_Id = Parametro_Id;
                Dt_Consulta = Consulta_Parametros.Consultar_Parametros();

                //  validacion para el administrador
                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                {
                    if (MDI_Frm_Apl_Principal.Rol_ID != Dt_Consulta.Rows[0][Cat_Parametros.Campo_Rol_Id].ToString())
                        P_Caja.P_Caja_ID = MDI_Frm_Apl_Principal.Caja_ID;
                }

                P_Caja.P_Estatus = "ABIERTA";
                Operacion_Cajas = P_Caja.Consultar_Cajas();

                // Verifica si existen cajas abiertas y deshabilita el botón de Apertura
                if (Operacion_Cajas.Rows.Count > 0)
                {
                    Grid_Cajas.DataSource = Operacion_Cajas;
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Limpiar_Pantalla
        ///DESCRIPCIÓN          : Limpia los controles de la pantalla, y actualiza el de fecha
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Limpiar_Pantalla() 
        {
            try
            {
                Cls_Metodos_Generales.Limpia_Controles(Fra_Caja_Fecha);
                Cmb_Numero_Caja.SelectedIndex = 0;
                Txt_Fecha.Text = DateTime.Today.ToLongDateString();
                Txt_Monto_Inicial.Text = String.Empty;
            }
            catch(Exception Ex)
            {
            }
        }

        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para manejo de los estados de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREO                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private void Manejo_Botones_Operacion(String Tipo)
        {
            switch (Tipo)
            {
                case "Apertura":
                    {
                        Txt_Monto_Inicial.Enabled = true;
                        Btn_Apertura.Text = "Confirmar";
                        Btn_Apertura.Image = global::ERP_BASE.Properties.Resources.icono_actualizar;
                        Btn_Salir.Text = "Cancelar";
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_cancelar;
                        Grid_Cajas.Enabled = false;
                        Btn_Cierre.Enabled = false;
                        Btn_Salir.Enabled = true;
                        break;
                    }
                case "Cancelar":
                    {
                        Txt_Monto_Inicial.Enabled = false;
                        Btn_Apertura.Text = "Apertura";
                        Btn_Salir.Text = "Salir";
                        Btn_Apertura.Image = global::ERP_BASE.Properties.Resources.icono_nuevo;
                        Btn_Salir.Image = global::ERP_BASE.Properties.Resources.icono_salir_2;
                        Grid_Cajas.Enabled = true;
                        Btn_Apertura.Enabled = true;
                        Btn_Cierre.Enabled = true;
                        Btn_Cargar_Datos.Enabled = true;
                        Btn_Salir.Enabled = true;
                        break;
                    }
                default: break;
            }

            //  validacion para el rol de administrador
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Consulta = new DataTable();
            String Parametro_Id = "";

            Parametro_Id = "00001";
            Consulta_Parametros.P_Parametro_Id = Parametro_Id;
            Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
            if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
            {
                if (MDI_Frm_Apl_Principal.Rol_ID == Dt_Consulta.Rows[0][Cat_Parametros.Campo_Rol_Id].ToString())
                    Btn_Cierre.Enabled = true;
                else
                    Btn_Cierre.Enabled = false;
            }
            else
                Btn_Cierre.Enabled = false;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Alta
        ///DESCRIPCIÓN          : Verifica que los campos obligatorios tengan información
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private Boolean Validar_Alta()
        {
            Boolean Resultado = true; // Variable que indica si los campos obligatorios contienen información
            Erp_Validaciones.Clear();

            // Verifica que el ComboBox "Cmb_Numero_Caja" tenga seleccionado un número de caja
            if (Cmb_Numero_Caja.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Cmb_Numero_Caja, "Debe seleccionar una caja de la lista");
                Resultado &= false;
            }

            // Verifica que el TextBox "Txt_Monto_Inicial" contenga información
            if (Txt_Monto_Inicial.Text == String.Empty)
            {
                Erp_Validaciones.SetError(Txt_Monto_Inicial, "El Monto Inicial no puede estar vacío");
                Resultado &= false;
            }
            // Verifica que la información contenida en el TextBox "Txt_Monto_Inicial" se numérica
            else if (!Information.IsNumeric(Txt_Monto_Inicial.Text))
            {
                Erp_Validaciones.SetError(Txt_Monto_Inicial," El Monto Inicial debe ser un valor numérico");
                Resultado &= false;
            }

            return Resultado;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Validar_Turno_Caja
        ///DESCRIPCIÓN          : Valida si una caja se encuentra abierta
        ///PARÁMETROS           : Numero_Caja, número de caja a revisar si se encuentra abierta
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 14 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private Boolean Validar_Turno_Caja(int Numero_Caja)
        {
            Cls_Ope_Cajas_Negocio P_Caja = new Cls_Ope_Cajas_Negocio();
            Cls_Cat_Cajas_Negocio P_Cat_Cajas = new Cls_Cat_Cajas_Negocio();
            DataTable Ope_Cajas = null;
            DataTable Cat_Cajas = null;

            try
            {
                P_Caja.P_Estatus = "ABIERTA";
                Ope_Cajas = P_Caja.Consultar_Cajas();

                // Verifica si existen cajas abiertas
                if (Ope_Cajas.Rows.Count > 0)
                {
                    P_Cat_Cajas.P_Numero_Caja = Numero_Caja.ToString();
                    Cat_Cajas = P_Cat_Cajas.Consultar_Caja();

                    // Verifica si el ID de la Caja, se encuentra en una operación de caja que se encuentre abierta
                    if (Ope_Cajas.Select("Caja_ID = '" + Cat_Cajas.Rows[0]["Caja_ID"] + "'").Length > 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Nombre_Turno
        ///DESCRIPCIÓN          : Obtiene el nombre del turno en base al número de turno
        ///PARÁMETROS           : No_Turno, es el turno que se encuentra abierto
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private String Nombre_Turno(String No_Turno) 
        {
            Cls_Ope_Turnos_Negocio P_Turno = new Cls_Ope_Turnos_Negocio(); // Variable utilizada para obtener el turno que se encuentre abierto
            Cls_Cat_Turnos_Negocio P_Cat_Turno = new Cls_Cat_Turnos_Negocio(); // Variable utilizada para obtener el nombre del turno

            try
            {
                P_Turno.P_No_Turno = No_Turno;
                P_Turno.P_Estatus = "ABIERTO";
                P_Cat_Turno.P_Turno_ID = P_Turno.Consultar_Turnos().Rows[0][Ope_Turnos.Campo_Turno_ID].ToString();
                return P_Cat_Turno.Consultar_Turnos().Rows[0][Cat_Turnos.Campo_Nombre].ToString();
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Alta_Caja
        ///DESCRIPCIÓN          : Registra la apertura de caja en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private Boolean Alta_Caja()
        {
            Cls_Ope_Cajas_Negocio P_Caja = new Cls_Ope_Cajas_Negocio(); // Variable utilizada para registrar la operación de caja en la base de datos
            Boolean Alta = false; // Variable que indica si el regstro de la operación es exitoso
            decimal Monto_Inicial;

            try
            {
                decimal.TryParse(Txt_Monto_Inicial.Text.Trim(), out Monto_Inicial);
                P_Caja.P_No_Turno = Txt_Turno_ID.Text;
                P_Caja.P_Usuario_ID = MDI_Frm_Apl_Principal.Usuario_ID;
                P_Caja.P_Caja_ID = Cmb_Numero_Caja.SelectedValue.ToString();
                P_Caja.P_Monto_Inicial = Monto_Inicial;
                P_Caja.P_Fecha_Hora_Inicio = DateTime.Parse(Txt_Fecha.Text + " " + Txt_Horario_Inicio.Text);
                P_Caja.P_Estatus = "ABIERTA";
                P_Caja.Alta_Caja();

                ////  se asigna la caja abierta al usuario
                MDI_Frm_Apl_Principal.Caja_ID = P_Caja.P_Caja_ID;

                Alta = true;
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Alta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Modificar_Caja
        ///DESCRIPCIÓN          : Registra el cierre de caja en la base de datos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private Boolean Modificar_Caja() 
        {
            Cls_Ope_Cajas_Negocio P_Caja = new Cls_Ope_Cajas_Negocio(); // Variable utilizada para realizar el cierre de caja
            Boolean Modificar = false; // Variable que indica si el cierre de caja se efectúa con éxito

            try
            {
                P_Caja.P_Fecha_Hora_Cierre = DateTime.Now;
                P_Caja.P_Estatus = "CERRADA";
                P_Caja.P_No_Caja = Txt_No_Caja.Text;
                P_Caja.P_Usuario_ID = MDI_Frm_Apl_Principal.Usuario_ID;
                P_Caja.Modificar_Caja();

                ////  se quita la caja al usuario logiado
                //MDI_Frm_Apl_Principal.Caja_ID = "";
                Modificar = true;
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Modificar;
        }
        #endregion

        #region Eventos

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Apertura_Click
        ///DESCRIPCIÓN          : Evento utilizado para realizar la apertura de caja
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Btn_Apertura_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica si el botón tiene el texto "Apertura"
                if (Btn_Apertura.Text.Trim() == "Apertura")
                {
                    Manejo_Botones_Operacion("Apertura");
                    Limpiar_Pantalla();
                }
                else
                {

                    // Verifica si una caja no se encuentra abierta
                    if (!Validar_Turno_Caja(int.Parse(Cmb_Numero_Caja.Text)))
                    {
                        // Verfica que los campos obligatorios tengan información
                        if (Validar_Alta())
                        {
                            Txt_Horario_Inicio.Text = DateTime.Now.ToShortTimeString();

                            // Verifica que la apertura de caja se efectue correctamente
                            if (Alta_Caja())
                            {
                                Cargar_Datos();
                                Manejo_Botones_Operacion("Cancelar");
                                MessageBox.Show("Se ha efectuado la apertura de caja", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("La caja ya ha sido abierta", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Erp_Validaciones.Clear();
                        Erp_Validaciones.SetError(Cmb_Numero_Caja, "La caja ya ha sido abierta");
                    }
                }
            }
            catch (Exception Ex)
            {
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Cierre_Click
        ///DESCRIPCIÓN          : Evento utilizado para realizar el cierre de caja
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Btn_Cierre_Click(object sender, EventArgs e)
        {
            // Pregunta al usuario si realmente desea cerrar la caja
            if (MessageBox.Show("¿Desea Cerrar la Caja?", "Cajas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // Verifica que el cierre de caja se efectue correctamente
                if (Modificar_Caja())
                {
                    Txt_Horario_Cierre.Text = DateTime.Now.ToShortTimeString();
                    Cargar_Datos();
                    //Cargar_Datos();
                    MessageBox.Show("Se ha efectuado el cierre de caja", "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Salir_Click
        ///DESCRIPCIÓN          : Evento utilizado para cerrar la pantalla
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            // Verifica si el boton tiene el texto "Salir"
            if (Btn_Salir.Text == "Salir")
            {
                this.Dispose();
                this.Close();
            }
            else
            {
                Manejo_Botones_Operacion("Cancelar");
                Grid_Cajas.Enabled = true;
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Cmb_Numero_Caja_KeyPress
        ///DESCRIPCIÓN          : Evento utilizado para evitar introducir datos mediante el teclado
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Cmb_Numero_Caja_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Monto_Inicial_KeyPress
        ///DESCRIPCIÓN          : Evento utilizado para permitir sólo valores numéricos
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Txt_Monto_Inicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_Metodos_Generales.Validar_Caracter(e, Cls_Metodos_Generales.Enum_Tipo_Caracteres.Numerico);
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Cargar_Datos_Click
        ///DESCRIPCIÓN          : Actualiza la informacion de las cajas abiertas y las muestra en el grid
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 13 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Btn_Cargar_Datos_Click(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
        #endregion

        #region Eventos Grid

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Grid_Cajas_SelectionChanged
        ///DESCRIPCIÓN          : Coloca la informacion del registro seleccionado en los campos correspondientes
        ///PARÁMETROS           : 
        ///CREÓ                 : Héctor Gabriel Galicia Luna
        ///FECHA_CREO           : 12 Octubre 2013
        ///MODIFICÓ             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*******************************************************************************
        private void Grid_Cajas_SelectionChanged(object sender, EventArgs e)
        {
            // Verifica que se seleccione un registro dentro del DataGridView
            if (Grid_Cajas.CurrentRow != null) 
            {
                Cls_Cat_Turnos_Negocio P_Turno = new Cls_Cat_Turnos_Negocio();

                Txt_No_Caja.Text = Grid_Cajas.CurrentRow.Cells[Ope_Cajas.Campo_No_Caja].Value.ToString();

                DateTime Fecha = DateTime.Parse(Grid_Cajas.CurrentRow.Cells[Ope_Cajas.Campo_Fecha_Hora_Inicio].Value.ToString());
                Txt_Fecha.Text = Fecha.ToLongDateString();

                Txt_Turno_ID.Text = Grid_Cajas.CurrentRow.Cells[Ope_Cajas.Campo_No_Turno].Value.ToString();
                Txt_Turno.Text = Nombre_Turno(Txt_Turno_ID.Text);
                Txt_Horario_Inicio.Text = Fecha.ToShortTimeString();
                Cmb_Numero_Caja.SelectedValue = Grid_Cajas.CurrentRow.Cells[Ope_Cajas.Campo_Caja_ID].Value.ToString();
                Txt_Monto_Inicial.Text = Grid_Cajas.CurrentRow.Cells[Ope_Cajas.Campo_Monto_Inicial].Value.ToString();
            }
        }
        #endregion
    }
}