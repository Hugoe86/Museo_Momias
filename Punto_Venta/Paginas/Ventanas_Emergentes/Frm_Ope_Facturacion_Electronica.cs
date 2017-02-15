using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Erp_Solicitud_Facturacion.Negocio;
using Erp_Apl_Parametros.Negocio;
using Erp.Constantes;
using Erp.Metodos_Generales;
using ERP_BASE.Paginas.Paginas_Generales;
using ERP_BASE.Paginas.Catalogos;
using System.IO;
using System.Runtime.InteropServices;
using Erp_Ope_Impresiones.Negocio;
using ERP_BASE.App_Code.Negocio.Catalogos;
using Erp.Seguridad;
using MySql.Data.MySqlClient;
using System.Data.Odbc;

namespace ERP_BASE.Paginas.Ventanas_Emergentes
{
    public partial class Frm_Ope_Facturacion_Electronica : Form
    {
        public Boolean Estatus_Conexion = false; 

        #region Frm_Ope_Facturacion_Electronica
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Frm_Ope_Facturacion_Electronica
        ///DESCRIPCIÓN          : Inicializa los campos
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 27/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        public Frm_Ope_Facturacion_Electronica()
        {
            InitializeComponent();
        }
        #endregion

        #region Validacion
        ///*************************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Manejo_Botones_Operacion
        ///DESCRIPCIÓN          : Método para el manejo del estado de los botones
        ///PARÁMETROS           : Tipo, define el tipo de operación a realizar
        ///CREÓ                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09 Marzo 2015
        ///MODIFICO             : 
        ///FECHA_MODIFICO       : 
        ///CAUSA_MODIFICACIÓN   : 
        ///*************************************************************************************
        private Boolean Validar_Conexion()
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            DataTable Dt_Parametros = new DataTable();
            String StrConexion = "";

            try
            {
                Consulta_Parametros.P_Parametro_Id = "00001";
                Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

               
                try
                {
                    if (Dt_Parametros.Rows[0][Cat_Parametros.Campo_Version_Bd].ToString() == "4")
                    {
                        #region Odbc

                        foreach (DataRow Registro in Dt_Parametros.Rows)
                        {
                            StrConexion = "DRIVER={MySQL ODBC 3.51 Driver};";
                            StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                            StrConexion += "OPTION=3";
                        }

                        using (OdbcConnection MyConnection = new OdbcConnection(StrConexion))
                        {
                            using (OdbcCommand Cmd = new OdbcCommand())
                            {
                                MyConnection.Open();
                                MyConnection.Close();
                            }
                        }

                        Estatus_Conexion = true;
                        #endregion
                    }
                    else
                    {
                        #region Version 5

                        foreach (DataRow Registro in Dt_Parametros.Rows)
                        {
                            StrConexion += "Server=" + Registro[Cat_Parametros.Campo_Ip_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Database=" + Registro[Cat_Parametros.Campo_Base_Datos_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Uid=" + Registro[Cat_Parametros.Campo_Usuario_A_Enviar_Ventas].ToString() + ";";
                            StrConexion += "Pwd=" + Cls_Seguridad.Desencriptar(Registro[Cat_Parametros.Campo_Contrasenia_A_Enviar_Ventas].ToString()) + ";";
                        }

                        MySqlConnection Obj_Conexion = null;
                        Obj_Conexion = new MySqlConnection(StrConexion);
                        Obj_Conexion.Open();
                        Obj_Conexion.Close();
                        Estatus_Conexion = true;
                        #endregion
                    }
                }
                catch (Exception es)
                {
                    Estatus_Conexion = false;
                    //MessageBox.Show(this, "No se logro establecer conexcion con el deudorcad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Habilitar_Controles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Estatus_Conexion;
        }
        #endregion

        #region Botones
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Nuevo_Click
        ///DESCRIPCIÓN          :Realiza el llamado a la ventana de padron
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 08/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            Frm_Cat_Padron Frm_Padron = new Frm_Cat_Padron();//Variable para llamar a la venta de búsqueda de productos.
            
            try
            {
                Frm_Padron.ShowDialog(this);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Nuevo_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Consultar_Contribuyente_Click
        ///DESCRIPCIÓN          :Realiza la consulta de la informacion del contribuyente
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 27/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Consultar_Contribuyente_Click(object sender, EventArgs e)
        {
            Cls_Ope_Solicitud_Facturacion_Negocio Rs_Consulta = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Parametros = new DataTable();
            DataTable Dt_contribuyente_Padron = new DataTable();
            Cls_Cat_Padron_Negocio Rs_Alta_Lista_Deudor = new Cls_Cat_Padron_Negocio();
            Boolean Estado_Conexion = false;
            try
            {
                if (Opt_Filtro_Rfc.Checked == true || Opt_Filtro_Curp.Checked == true)
                {
                    if (!String.IsNullOrEmpty(Txt_Filtro_Contribuyente.Text))
                    {
                        //validacion para la conexion
                        if (Estatus_Conexion == true)
                        {
                            Estado_Conexion = true;
                        }
                        else
                        {
                            Estado_Conexion = false;
                        }


                        if (Opt_Filtro_Rfc.Checked == true) Rs_Consulta.P_Rfc = Txt_Filtro_Contribuyente.Text;
                        else Rs_Consulta.P_Curp = Txt_Filtro_Contribuyente.Text;

                        #region Parametro
                        Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
                        String Lista = "";
                        String Tipo = "";
                        String Clave_Venta_Individual = "";
                        Boolean Estatus_List = false;

                        Consulta_Parametros.P_Parametro_Id = "00001";
                        Dt_Parametros = Consulta_Parametros.Consultar_Parametros();

                        Rs_Consulta.P_Dt_Parametros = Dt_Parametros;
                        Lista = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                        Tipo = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                        Clave_Venta_Individual = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Clave_Venta_Individual_Deudorcad].ToString();
                        #endregion

                        //Rs_Consulta.P_Tipo = Tipo;
                        //Rs_Consulta.P_Lista = Lista;
                        if (Estado_Conexion == true)
                            Dt_Consulta = Rs_Consulta.Consultar_Contribuyente();
                        else
                            Dt_Consulta = Rs_Consulta.Consultar_Contribuyente_Local();

                        if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                        {
                            foreach (DataRow Registro in Dt_Consulta.Rows)
                            {
                                if (Registro["Tipo_List"].ToString() == Tipo && Registro["Lista_List"].ToString() == Lista)
                                {
                                    Estatus_List = true;
                                    break;
                                }
                            }
                        }

                        // si no existe se ingresa a la lista de duedores
                        if(Estatus_List == false)
                        {

                            //  se valida que se encuentre registrado el usuario
                            if (Estado_Conexion == true)
                                Dt_contribuyente_Padron = Rs_Consulta.Consultar_Contribuyente_Unico();
                            else
                                Dt_contribuyente_Padron = Rs_Consulta.Consultar_Contribuyente_Unico_Local();

                            if (Dt_contribuyente_Padron != null && Dt_contribuyente_Padron.Rows.Count > 0)
                            {

                                String Nombre_Usuario = "";

                                if (MDI_Frm_Apl_Principal.Nombre_Login.Length > 10)
                                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login.Substring(0, 10);
                                else
                                    Nombre_Usuario = MDI_Frm_Apl_Principal.Nombre_Login;

                                Rs_Alta_Lista_Deudor.P_Dt_Parametros = Dt_Parametros;
                                Rs_Alta_Lista_Deudor.P_Tipo_Lista_Deudor = Tipo;
                                Rs_Alta_Lista_Deudor.P_Lista_Deudor = Lista;
                                Rs_Alta_Lista_Deudor.P_Rfc = Txt_Filtro_Contribuyente.Text;
                                Rs_Alta_Lista_Deudor.P_Clave_Venta_Individual = Clave_Venta_Individual;
                                Rs_Alta_Lista_Deudor.P_Equipo = Environment.MachineName; ;
                                Rs_Alta_Lista_Deudor.P_Usuario = Nombre_Usuario;

                                if (Estado_Conexion == true)
                                    Rs_Alta_Lista_Deudor.Alta_Usuario_List_Deudro();
                                else
                                    Rs_Alta_Lista_Deudor.Alta_Usuario_List_Deudro_Local();

                                //  se vuelve a consultar al usuario
                                Rs_Consulta.P_Tipo = Tipo;
                                Rs_Consulta.P_Lista = Lista;

                                if (Estado_Conexion == true)
                                    Dt_Consulta = Rs_Consulta.Consultar_Contribuyente();
                                else
                                    Dt_Consulta = Rs_Consulta.Consultar_Contribuyente_Local();
                            }
                            //else
                            //{
                            //    MessageBox.Show(this, "No existe el contribuyente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }

                        if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                        {
                            foreach (DataRow Dr_Registro in Dt_Consulta.Rows)
                            {
                                Txt_Rfc.Text = Dr_Registro["rfc"].ToString();
                                Txt_Curp.Text = Dr_Registro["curp"].ToString();
                                Txt_Apellido_Paterno.Text = Dr_Registro["paterno"].ToString();
                                Txt_Apellido_Materno.Text = Dr_Registro["materno"].ToString();
                                Txt_Nombre.Text = Dr_Registro["nombre"].ToString();
                                Txt_Referencia1.Text = Dr_Registro["referencia1"].ToString();
                                Txt_Referencia2.Text = Dr_Registro["referencia2"].ToString();
                            }
                        }
                        else
                        {
                            Txt_Rfc.Text = "";
                            Txt_Curp.Text = "";
                            Txt_Apellido_Paterno.Text = "";
                            Txt_Apellido_Materno.Text = "";
                            Txt_Nombre.Text = ""; 
                            Txt_Referencia1.Text = "";
                            Txt_Referencia2.Text = "";
                            MessageBox.Show(this, "No existe el contribuyente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show(this, "Ingrese la informacion del filtro a buscar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Seleccione algun filtro de busqueda", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Contribuyente_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Consultar_Venta_Click
        ///DESCRIPCIÓN          :Realiza la consulta de la informacion de la venta
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 27/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Consultar_Venta_Click(object sender, EventArgs e)
        {
            Cls_Ope_Solicitud_Facturacion_Negocio Rs_Consulta = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DataTable Dt_Consulta = new DataTable();
            Boolean Estatus = false;
            try
            {
                if(!String.IsNullOrEmpty(Txt_Filtro_Numero_Venta.Text))
                {
                    Rs_Consulta.P_Numero_Venta = Txt_Filtro_Numero_Venta.Text; //(string.IsNullOrEmpty(Txt_Filtro_Numero_Venta.Text)) ? string.Empty : Convert.ToInt64(Txt_Filtro_Numero_Venta.Text.Trim()).ToString("0000000000");

                    Dt_Consulta = Rs_Consulta.Consultar_Venta();


                    //  valida que no se encuentre facturado
                    foreach (DataRow Registro in Dt_Consulta.Rows)
                    {
                        if (Registro["estatus_solicitud"].ToString() == "F")
                        {
                            Estatus = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }


                    //  validacion para llenar el grid
                    if (Estatus == true)
                    {
                        Grid_Venta.DataSource = new DataTable(); 
                        MessageBox.Show(this, "El folio " + Rs_Consulta.P_Numero_Venta + " ya fue facturado", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                        {
                            Grid_Venta.DataSource = Dt_Consulta;
                        }
                        else
                        {
                            Grid_Venta.DataSource = new DataTable();
                            MessageBox.Show(this, "No existe información de la venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "Ingrese el número de la venta a consultar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Consultar_Venta_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///******b*************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Facturar_Click
        ///DESCRIPCIÓN          :Realiza la solicitud de facturacion
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 27/Febrero/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Btn_Facturar_Click(object sender, EventArgs e)
        {
            Cls_Apl_Parametros_Negocio Consulta_Parametros = new Cls_Apl_Parametros_Negocio();
            Cls_Cat_Lista_Deudorcad_Negocio Rs_Consulta_Listas = new Cls_Cat_Lista_Deudorcad_Negocio();

            var Obj_Parametros = new Cls_Apl_Parametros_Negocio();
            Cls_Ope_Solicitud_Facturacion_Negocio Rs_Alta = new Cls_Ope_Solicitud_Facturacion_Negocio();
            DataTable Dt_Consulta = new DataTable();
            DataTable Dt_Venta = new DataTable();
            DataTable Dt_Consulta_Lista_Deudorcad = new DataTable();
            DataTable Dt_Pagos = new DataTable();

            String Concepto = "";
            Double Importe = 0;
            String No_Venta = "";

            DataRow Dr_Ventas;
            DataTable Dt_Ventas_Clasificacion = new DataTable();
            Boolean Estado_Conexcion = false;

            try
            {
                Rs_Alta.P_Imagen_Bits = "";// se agrega la imagen de los parametros en forma de bits

                if (!String.IsNullOrEmpty(Txt_Curp.Text) && Grid_Venta.Rows.Count > 0)
                {

                    if (Estatus_Conexion == true)
                    {
                        Estado_Conexcion = true;
                    }
                    else
                    {
                        Estado_Conexcion = false;
                    }

                    #region Parametros
                    Consulta_Parametros.P_Parametro_Id = "00001";
                    Dt_Consulta = Consulta_Parametros.Consultar_Parametros();
                    Rs_Alta.P_Lista_Parametros = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Lista_Deudorcad].ToString();
                    Rs_Alta.P_Tipo_Parametro = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Tipo_Deudorcad].ToString();
                    Rs_Alta.P_Clave_Venta = Dt_Consulta.Rows[0][Cat_Parametros.Campo_Clave_Venta_Individual_Deudorcad].ToString();
                    Rs_Alta.P_Dt_Parametros = Dt_Consulta;
                    #endregion

                    #region listas deudorcad
                    Rs_Consulta_Listas.P_Operacion = "Venta individual";
                    Rs_Consulta_Listas.P_Estatus = "ACTIVO";
                    Dt_Consulta_Lista_Deudorcad = Rs_Consulta_Listas.Consultar_Listas();
                    Rs_Alta.P_Dt_Listas_Deudorcad = Dt_Consulta_Lista_Deudorcad;


                    //  se construira la tabla con la informacion de las ventas correspondientes a las formas de pago que se encuentren en las listas


                    #endregion

                    Rs_Alta.P_Curp = Txt_Curp.Text;
                    Rs_Alta.P_Tipo = Txt_Referencia1.Text;
                    Rs_Alta.P_Lista = Txt_Referencia2.Text;
                    Rs_Alta.P_Cuenta_Momias = (!String.IsNullOrEmpty(Txt_Rfc.Text)) ? Txt_Rfc.Text : Txt_Curp.Text;

                    Rs_Alta.P_Grid_Ventas = Grid_Venta;

                    //  se realiza el proceso para la utilizacion del catalogo de listas del deudorcad
                    if (Dt_Consulta_Lista_Deudorcad != null && Dt_Consulta_Lista_Deudorcad.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow Registro in Grid_Venta.Rows)
                        {
                            No_Venta = Registro.Cells["No_Venta"].Value.ToString();
                            Concepto += Registro.Cells["Cantidad"].Value.ToString() + "-$" + Registro.Cells["costo_Producto"].Value.ToString() + ",";
                        }

                        //  se remueve la ultima coma
                        if (Concepto.Length > 0)
                        {
                            Concepto = Concepto.Remove(Concepto.Length - 1);
                        }

                        //  se consultan los pagos registrados
                        Rs_Alta.P_No_Venta = No_Venta;
                        Dt_Pagos = Rs_Alta.ConsultarPagos_Venta_Individual();

                        //  se genera la tabla de las ventas por tipo de lista
                        Dt_Ventas_Clasificacion.Columns.Add("clave_venta_Lista");
                        Dt_Ventas_Clasificacion.Columns.Add("importe");
                        Dt_Ventas_Clasificacion.Columns.Add("concepto2");


                        foreach (DataRow Registro_Listas in Dt_Consulta_Lista_Deudorcad.Rows)
                        {
                            foreach (DataRow Registro_Pagos in Dt_Pagos.Rows)
                            {
                                //  se obtiene los conceptos de los ventas
                                if (Registro_Listas["Tipo_Pago"].ToString() == Registro_Pagos["Forma_Id"].ToString())
                                {
                                    Importe = Convert.ToDouble(Registro_Pagos["Monto_Pago"].ToString());
                                }
                            }

                            if (Importe > 0)
                            {
                                Dr_Ventas = Dt_Ventas_Clasificacion.NewRow();

                                Dr_Ventas["clave_venta_Lista"] = Registro_Listas["Lista"].ToString();
                                Dr_Ventas["importe"] = Importe;
                                Dr_Ventas["concepto2"] = Concepto;

                                Dt_Ventas_Clasificacion.Rows.Add(Dr_Ventas);
                                Dt_Ventas_Clasificacion.AcceptChanges();

                                Importe = 0;
                            }
                        }

                        Rs_Alta.P_Dt_Ventas_Clasificacion = Dt_Ventas_Clasificacion;
                        Rs_Alta.P_No_Venta = No_Venta;
                        Rs_Alta.Insertar_Solicitud_Catalogo_Listas();
                    }
                    else//  metodo original de los parametros del punto de venta
                    {
                        foreach (DataGridViewRow Registro in Grid_Venta.Rows)
                        {
                            Importe = Importe + Convert.ToDouble(Registro.Cells["Total"].Value.ToString());
                            No_Venta = Registro.Cells["No_Venta"].Value.ToString();
                            Concepto += Registro.Cells["Cantidad"].Value.ToString() + "-$" + Registro.Cells["costo_Producto"].Value.ToString() + ",";
                            Rs_Alta.P_Caja = Registro.Cells["Nombre_Caja"].Value.ToString();
                            Rs_Alta.P_Turno = Registro.Cells["Turno"].Value.ToString();
                        }

                        //  se remueve la ultima coma
                        if (Concepto.Length > 0)
                        {
                            Concepto = Concepto.Remove(Concepto.Length - 1);
                        }

                        Rs_Alta.P_Importe = Importe.ToString();
                        Rs_Alta.P_Concepto2 = Concepto;
                        Rs_Alta.P_No_Venta = No_Venta;

                        if (Estado_Conexcion == true)
                        {
                            Rs_Alta.Insertar_Solicitud();
                            Rs_Alta.Actualizar_Estatus_Facturacion();
                        }
                        else
                        {
                            Rs_Alta.Insertar_Solicitud_Local();
                        }
                    }


                    MessageBox.Show(this, "Se ingreso la facturación de manera correcta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cls_Metodos_Generales.Limpia_Controles(this);
                    Grid_Venta.DataSource = new DataTable();
                }
                else if (String.IsNullOrEmpty(Txt_Curp.Text))
                {
                    MessageBox.Show(this, "Ingrese la informacion del contribuyente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Grid_Venta.Rows.Count > 0)
                {
                    MessageBox.Show(this, "Ingrese la informacion de la venta", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Facturar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Text Box
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Btn_Facturar_Click
        ///DESCRIPCIÓN          :Realiza la consulta del usuario
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Txt_Filtro_Contribuyente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Btn_Consultar_Contribuyente_Click(sender, null);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Facturar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCIÓN : Txt_Filtro_Numero_Venta_KeyPress
        ///DESCRIPCIÓN          :Realiza la consulta de la factura
        ///PARAMETROS           : 
        ///CREO                 : Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO           : 09/Abril/2015
        ///MODIFICO             :
        ///FECHA_MODIFICO       :
        ///CAUSA_MODIFICACIÓN   :
        ///*******************************************************************************
        private void Txt_Filtro_Numero_Venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Btn_Consultar_Venta_Click(sender, null);
                }
                //else if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
                //{
                //    e.Handled = true;
                //    return;
                //}
            }
            catch (Exception Ex)
            {
                MessageBox.Show(this, Ex.Message, "Error - Método: [Btn_Facturar_Click]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Solicitud_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Ope_Solicitud_Facturacion_Negocio Rs_Consulta = new Cls_Ope_Solicitud_Facturacion_Negocio();
                Cls_Ope_Impresiones_Negocio Solicitud = new Cls_Ope_Impresiones_Negocio();
                DataTable Dt_Venta;
                string Folio;

                if (Grid_Venta.Rows.Count > 0)
                {
                    Folio = Grid_Venta.CurrentRow.Cells["Folio_Venta"].Value.ToString();

                    Rs_Consulta.P_Numero_Venta = Txt_Filtro_Numero_Venta.Text; // Convert.ToInt64(Folio).ToString("0000000000");
                    Dt_Venta = Rs_Consulta.Consultar_Venta();

                    if (Dt_Venta != null && Dt_Venta.Rows.Count > 0)
                    {
                        Rs_Consulta.P_Dt_Solicitud = Dt_Venta;
                        Solicitud.P_Dt_Solicitud = Dt_Venta;
                        Solicitud.P_Total_Venta_En_Solicitd = Convert.ToDouble(Dt_Venta.Compute("Sum(Total)", ""));
                    }
                    else
                    {
                        throw new Exception("Error al consultar la venta " + Rs_Consulta.P_Numero_Venta);
                    }

                    Solicitud.Imprimir_Solicitud_Facturacion();
                    Rs_Consulta.Actualizar_Venta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_Ope_Facturacion_Electronica_Load(object sender, EventArgs e)
        {
            Validar_Conexion();
        }
    }
}
