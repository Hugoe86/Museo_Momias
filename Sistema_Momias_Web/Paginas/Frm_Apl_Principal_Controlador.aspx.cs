using System;
using System.Data;
using Erp.Principal.Negocio;
using System.Web;
using Newtonsoft.Json;
using Erp.Constantes;
using Erp.Ayudante_JQuery;
using System.Configuration;
using System.Collections;
using Erp.Productos_Detalles;
using Erp_Apl_Parametros.Negocio;
using System.Net.Mail;
using System.Net.Mime;
using Erp_Ope_Ventas.Negocio;
using Erp.Metodos_Generales;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Erp.Seguridad;
using System.Collections.Specialized;
using AjaxControlToolkit;

public partial class Paginas_Frm_Apl_Principal_Controlador : System.Web.UI.Page
{

    private Cls_Apl_Principal_Negocio Negocio_Ventas = new Cls_Apl_Principal_Negocio();//conexion con la capa de negocio
    private DataTable Dt_Productos_Accesos = new DataTable();
    private DataTable Dt_Productos = new DataTable();

    #region (PageLoad)
    /// <summary>
    /// Inicializacion de la pagina
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <creo>Leslie González Vázquez</creo>
    /// <fecha creo>21/Mayo/2014</fecha creo>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Controlador_Inicio();
            
            /*
            //Valida la respuesta del 3D
            if (Request.Form["Status"] != null) //No sea nula
            {
                if (Request.Form["Status"].ToString().Trim() != "") //No este vacia
                {
                    //Inhabilita los botones
                    //////Btn_Imprimir_Estado_Cuenta.Enabled = false;
                    //////Btn_Ejecutar_Pago.Enabled = false;
                    //////Limpiar_Campos_3D();
                    //Estatus de la respuesa
                    if (Request.Form["Status"].ToString().Trim() != "")
                    {
                        Hdf_3D_Estatus.Value = Request.Form["Status"].ToString().Trim();
                    }
                    else
                    {
                        Hdf_3D_Estatus.Value = "0";
                    }
                    //Datos de la cuenta
                    //////Txt_Cuenta_Predial.Text = Request.Form["Cuenta"].ToString().Trim();
                    //////if (Txt_Cuenta_Predial.Text != "")
                    //////{
                    //////    Txt_Cuenta_Predial_TextChanged(sender, null);
                    //////}
                    //////Cmb_Tipo_Pago.SelectedValue = Request.Form["TipoPago"].ToString().Trim();
                    //////Cmb_Bimestre_Final.SelectedValue = Request.Form["HastaBimestre"].ToString().Trim();
                    //////Cmb_Anio_Final.SelectedValue = Request.Form["HastaAnio"].ToString().Trim();
                    ////////Datos de los adeudos
                    //////if (Hdf_Cuenta_Predial_ID.Value.Trim().Length > 0)
                    //////{
                    //////    Grid_Listado_Adeudos.DataSource = new DataTable();
                    //////    Grid_Listado_Adeudos.DataBind();
                    //////    Llenar_Grid_Adeudos(Hdf_Cuenta_Predial_ID.Value, true);
                    //////}
                    ////////Datos del pago
                    //////Cmb_Tipo_Tarjeta.SelectedValue = Request.Form["TipoTarjeta"].ToString().Trim();
                    //////Txt_Titular_Tarjeta.Text = Request.Form["BillToFirstName"].ToString().Trim();
                    //////Txt_No_Tarjeta.Text = Request.Form["Number"].ToString().Trim();
                    //////Txt_Codigo_Seguridad.Text = Request.Form["Cvv2Val"].ToString().Trim();
                    //////Cmb_Validez_Mes.SelectedValue = Request.Form["Expires"].ToString().Trim().Substring(0, 2);
                    //////Cmb_Valido_Anio.SelectedValue = Request.Form["Expires"].ToString().Trim().Substring(3);
                    //Datos de la respuesta
                    if (Convert.ToInt64(Hdf_3D_Estatus.Value) != 200) //Si trae error
                    {
                        //habilita los botones
                        //Btn_Imprimir_Estado_Cuenta.Enabled = true;
                        //Btn_Ejecutar_Pago.Enabled = true;
                        ToolkitScriptManager.RegisterStartupScript(this, this.GetType(), "Pagos Externos", "alert('" + Mensaje_Error_3D(Convert.ToInt64(Hdf_3D_Estatus.Value)) + "');", true);
                    }
                    else //Si es exitosa
                    {
                        //Asigna los datos de la respuesta
                        if (Request.Form["ECI"] != null)
                        {
                            Hdf_3D_ECI.Value = Request.Form["ECI"].ToString().Trim();
                            //Valida la los posibles valores
                            if (!String.IsNullOrEmpty(Hdf_3D_ECI.Value))
                            {
                                if (Hdf_3D_ECI.Value != "05" && Hdf_3D_ECI.Value != "06" && Hdf_3D_ECI.Value != "07" && Hdf_3D_ECI.Value != "01" && Hdf_3D_ECI.Value != "02")
                                {
                                    //habilita los botones
                                    //Btn_Imprimir_Estado_Cuenta.Enabled = true;
                                    //Btn_Ejecutar_Pago.Enabled = true;
                                    ToolkitScriptManager.RegisterStartupScript(this, this.GetType(), "Pagos Externos", "alert('El código ECI no esta dentro de los valores permitidos, favor de intentar nuevamente.');", true);
                                    return;
                                }
                            }
                        }
                        if (Request.Form["CardType"] != null)
                        {
                            Hdf_3D_XID.Value = Request.Form["CardType"].ToString().Trim();
                        }
                        if (Request.Form["XID"] != null)
                        {
                            Hdf_3D_XID.Value = Request.Form["XID"].ToString().Trim();
                        }
                        if (Request.Form["CAVV"] != null)
                        {
                            Hdf_3D_CAVV.Value = Request.Form["CAVV"].ToString().Trim();
                        }
                        //Realiza la ejecucion del pago

                        //generamos la compra
                        Dt_Productos_Accesos = Generar_Venta_BD(Negocio_Ventas, Dt_Productos);

                        //generamos el pdf
                        String Ruta_Pdf = Generar_Pdf(Negocio_Ventas, Dt_Productos_Accesos);

                        //enviamos el correo
                        if (Negocio_Ventas.P_Enviar_Email == "SI" && !String.IsNullOrEmpty(Negocio_Ventas.P_Email) && !String.IsNullOrEmpty(Ruta_Pdf))
                        {
                            Enviar_Correo_Pdf(Negocio_Ventas.P_Email, Ruta_Pdf);
                        }
                    }
                }
            }
            */
        }
    }
    #endregion

    #region(Metodos Generales)
    /// <summary>
    /// Metodo para inicializar los controles de la pagina
    /// </summary>
    /// <creo>Leslie González Vázquez</creo>
    /// <fecha creo>21/Mayo/2014</fecha creo>
    /// <modifico></modifico>
    /// <fecha modifico></fecha modifico>
    /// <causa modificacion></motivo modificacion>
    private void Controlador_Inicio()
    {
        String Accion = String.Empty;
        String Json_Cadena = String.Empty;
        Response.Clear();

        if (this.Request.QueryString["Accion"] != null)
        {
            if (!String.IsNullOrEmpty(this.Request.QueryString["Accion"].ToString().Trim()))
            {
                Accion = this.Request.QueryString["Accion"].ToString().Trim();
                switch (Accion)
                {
                    case "Obtener_Productos_Servicios":
                        Json_Cadena = Llenar_Grid_Productos_Servicios();
                        Response.ContentType = "application/json";
                        break;
                    case "Obtener_Cantidad":
                        Json_Cadena = ConfigurationManager.AppSettings["Cantidad"];
                        Response.ContentType = "text/html";
                        break;
                    case "Generar_Compra":
                        Json_Cadena = Generar_Compra();
                        Response.ContentType = "text/html";
                        break;
                }
            }
        }

        Response.Write(Json_Cadena);
        Response.Flush();
        Response.End();
    }

    /// <summary>
    /// Metodo para llenar el grid de los productos y los servicios
    /// </summary>
    /// <returns>La cadena con formato Json de los productos y servicios</returns>
    /// <creo>Leslie González Vázquez</creo>
    /// <fecha creo>21/Mayo/2014</fecha creo>
    /// <modifico></modifico>
    /// <fecha modifico></fecha modifico>
    /// <causa modificacion></motivo modificacion>
    public string Llenar_Grid_Productos_Servicios()
    {
        Cls_Apl_Principal_Negocio Negocio = new Cls_Apl_Principal_Negocio(); //creamos el objeto de la clase de negocio
        String Json = "{\"total\":\"0\",\"rows\":[]}"; //aki almacenaremos el json de la tabla
        DataTable Dt_Productos = new DataTable(); //tabla para guardar los datos de la consulta
        String Parametros = String.Empty;
        JsonSerializerSettings Configuracion_Json = new JsonSerializerSettings();
        Configuracion_Json.NullValueHandling = NullValueHandling.Ignore;
        String Fecha_Visita = String.Empty;

        try
        {
            //obtenemos los parametros
            Parametros = HttpContext.Current.Request["Parametros"] == null ? String.Empty : HttpContext.Current.Request["Parametros"].ToString().Trim();
            //deserealizamos el json con los datos a guardar
            Negocio = JsonConvert.DeserializeObject<Cls_Apl_Principal_Negocio>(Parametros);

            //obtenemos la fecha de la visita para consultar los datos de los productos
            Fecha_Visita = Negocio.P_Fecha;
            if (String.IsNullOrEmpty(Fecha_Visita))
                Fecha_Visita = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
            else
                Fecha_Visita = Formatear_Fecha(Fecha_Visita);

            //consultamos los productos de aceurdo a la fecha de la visita
            Negocio.P_Fecha_Visita = Convert.ToDateTime(Fecha_Visita);
            Dt_Productos = Negocio.Consultar_Productos_Servicios();

            if (Dt_Productos != null)
            {
                if (Dt_Productos.Rows.Count > 0)
                {
                    Dt_Productos.Columns.Add("Subtotal", typeof(String));
                    //verificamos si la descripcion esta vacia, le asigamos el nombre del producto
                    foreach (DataRow Dr in Dt_Productos.Rows)
                    {
                        Dr["Subtotal"] = String.Format("{0:n}", 0);

                        if (String.IsNullOrEmpty(Dr[Cat_Productos.Campo_Descripcion].ToString()))
                            Dr[Cat_Productos.Campo_Descripcion] = Dr[Cat_Productos.Campo_Nombre].ToString();
                    }

                    //generamos la cadena json
                    Dt_Productos.TableName = "rows";
                    Json = Ayudante_JQuery.Crear_Tabla_Formato_JSON_DataGrid(Dt_Productos, Dt_Productos.Rows.Count);
                }
            }

        }
        catch (Exception Ex)
        {
            throw new Exception(" Error al obtener la tabla los productos y servicios. Error[" + Ex.Message + "]");
        }
        return Json;
    }

    /// <summary>
    /// Metodo para formatear las fechas
    /// </summary>
    /// <returns>La cadena con el formato de fecha yyyy/mm/dd</returns>
    /// <creo>Leslie González Vázquez</creo>
    /// <fecha creo>21/Mayo/2014</fecha creo>
    /// <modifico></modifico>
    /// <fecha modifico></fecha modifico>
    /// <causa modificacion></motivo modificacion>
    private String Formatear_Fecha(String Fecha)
    {
        String[] Fechas;
        String Mes = String.Empty;
        String Dia = String.Empty;
        String Anio = String.Empty;

        try
        {
            if (!String.IsNullOrEmpty(Fecha.Trim()))
            {
                Fechas = Fecha.Split('/');

                Mes = String.Format("{0:00}", Convert.ToInt32(Fechas[0].Trim()));
                Dia = String.Format("{0:00}", Convert.ToInt32(Fechas[1].Trim()));
                Anio = String.Format("{0:0000}", Convert.ToInt32(Fechas[2].Trim()));

                Fecha = Anio + "/" + Mes + "/" + Dia;
            }

        }
        catch (Exception Ex)
        {
            throw new Exception("Error al formatear la fecha Error[" + Ex.Message + "]");
        }

        return Fecha;
    }

    #endregion

    #region (Generar Compra)
    /// <summary>
    /// Metodo para generar los datos de la compra
    /// </summary>
    /// <returns></returns>
    /// <creo>Leslie González Vázquez</creo>
    /// <fecha creo>29/Mayo/2014</fecha creo>
    /// <modifico></modifico>
    /// <fecha modifico></fecha modifico>
    /// <causa modificacion></motivo modificacion>
    private String Generar_Compra()
    {
        //DataTable Dt_Productos = new DataTable();
        String Ruta_Pdf = String.Empty;
        String Parametros = String.Empty;
        //DataTable Dt_Productos_Accesos = new DataTable();

        try
        {
            //obtenemos los parametros
            Parametros = HttpUtility.HtmlDecode(HttpContext.Current.Request["Parametros"] == null ? String.Empty : HttpContext.Current.Request["Parametros"].ToString().Trim());
            //deserealizamos el json con los datos a guardar
            Negocio_Ventas = JsonConvert.DeserializeObject<Cls_Apl_Principal_Negocio>(Parametros);

            if (Negocio_Ventas.P_Productos != null)
            {
                Application.Lock();
                Application["Compra"] = Negocio_Ventas;
                Application.UnLock();

                //Session["Compra"] = Negocio_Ventas;
                //Dt_Productos = Crear_Dt_Productos(Negocio_Ventas.P_Productos);
                //Enviar_Pago_Internet(Negocio_Ventas);

                //generamos la compra
                //Dt_Productos_Accesos = Generar_Venta_BD(Negocio_Ventas, Dt_Productos);

                /*
                //generamos el pdf
                Ruta_Pdf = Generar_Pdf(Negocio_Ventas, Dt_Productos_Accesos);

                //enviamos el correo
                if (Negocio_Ventas.P_Enviar_Email == "SI" && !String.IsNullOrEmpty(Negocio_Ventas.P_Email) && !String.IsNullOrEmpty(Ruta_Pdf))
                {
                    Enviar_Correo_Pdf(Negocio_Ventas.P_Email, Ruta_Pdf);
                }
                */
            }
        }
        catch (Exception Ex)
        {
            if (!Ex.Message.ToString().Equals("Error al enviar el correo con el Pdf. Error[Error al enviar correo.]"))
            {
                throw new Exception(" Error al generar la compra. Error[" + Ex.Message + "]");
            }
        }
        finally
        {
            Ruta_Pdf = @Server.MapPath(Ruta_Pdf);
        }
        return Ruta_Pdf;
    }

    /// <summary>
    /// Metodo para obtener la tabla de los productos 
    /// </summary>
    /// <param name="Productos">Productos que se adquiriran en la compra</param>
    /// <returns></returns>
    /// <creo>Leslie González Vázquez</creo>
    /// <fecha creo>29/Mayo/2014</fecha creo>
    /// <modifico></modifico>
    /// <fecha modifico></fecha modifico>
    /// <causa modificacion></motivo modificacion>
    private DataTable Crear_Dt_Productos(ArrayList Productos)
    {
        Cls_Productos_Detalles Productos_Detalle = new Cls_Productos_Detalles();
        DataTable Dt_Productos = new DataTable();
        int i = 0;
        String Registro = String.Empty;
        DataRow Fila = null;

        try
        {
            //creamos las columnas del datatable
            Dt_Productos.Columns.Add("PRODUCTO_ID", typeof(String));
            Dt_Productos.Columns.Add("CANTIDAD", typeof(Decimal));
            Dt_Productos.Columns.Add("COSTO", typeof(Decimal));
            Dt_Productos.Columns.Add("TOTAL", typeof(Decimal));
            Dt_Productos.Columns.Add("TIPO", typeof(String));
            Dt_Productos.Columns.Add("DESCRIPCION", typeof(String));
            Dt_Productos.Columns.Add("RUTA_IMAGEN", typeof(String));
            Dt_Productos.Columns.Add("CODIGO", typeof(String));

            for (i = 0; i < Productos.Count; i++)
            {
                Registro = Productos[i].ToString();//obtenemos el registro json del producto 
                Productos_Detalle = JsonConvert.DeserializeObject<Cls_Productos_Detalles>(Registro);  //deserealizamos el json con los datos del producto

                //agregamos los datos al datatable
                Fila = Dt_Productos.NewRow();
                Fila["PRODUCTO_ID"] = Productos_Detalle.Producto_Id;
                Fila["CANTIDAD"] = Convert.ToDecimal(String.IsNullOrEmpty(Productos_Detalle.Cantidad) ? "0" : Productos_Detalle.Cantidad);
                Fila["COSTO"] = Convert.ToDecimal(String.IsNullOrEmpty(Productos_Detalle.Costo) ? "0" : Productos_Detalle.Costo);
                Fila["TOTAL"] = Convert.ToDecimal(String.IsNullOrEmpty(Productos_Detalle.Subtotal) ? "0" : Productos_Detalle.Subtotal);
                Fila["TIPO"] = Productos_Detalle.Tipo;
                Fila["DESCRIPCION"] = Productos_Detalle.Descripcion;
                Fila["RUTA_IMAGEN"] = Productos_Detalle.Ruta_Imagen;
                Fila["CODIGO"] = Productos_Detalle.Codigo;
                Dt_Productos.Rows.Add(Fila);
            }
        }
        catch (Exception Ex)
        {
            throw new Exception("Error al obtener los productos. Error[" + Ex.Message + "]");
        }
        return Dt_Productos;
    }

    private void Enviar_Pago_Internet(Cls_Apl_Principal_Negocio Negocio)
    {
        NameValueCollection data = new NameValueCollection(); //Declara la coleccion de parametros
        //Asigna los parametros a enviar a la pagina 3D
        data.Add("Card", Negocio.P_Numero_Tarjeta.Trim());
        data.Add("Expires", Negocio.P_Fecha_Expira);//MM/YY
        data.Add("Total", Convert.ToDouble(Negocio.P_Total.Replace("$", "")).ToString());
        data.Add("CardType", "MC");//VISA-MC
        data.Add("MerchantId", "7749753");
        data.Add("MerchantName", "Municipio de Guanajuato");
        data.Add("MerchantCity", "Guanajuato");
        data.Add("ForwardPath", HttpContext.Current.Request.Url.ToString());
        data.Add("Cert3D", "03");
        data.Add("TipoTarjeta", "MC");
        data.Add("Cvv2Val", Negocio.P_Codigo_Seguridad);
        data.Add("BillToFirstName", Negocio.P_Nombre);
        HttpHelper.RedirectAndPOST(this.Page, "https://eps.banorte.com/secure3d/Solucion3DSecure.htm", data);
    }
    #endregion

    #region (Generar Pdf)
    /// <summary>
    /// Metodo para obtener la leyenda del boleto
    /// </summary>
    ///  /// <creo>Leslie González Vázquez</creo>
    /// <fecha creo>05/Junio/2014</fecha creo>
    /// <modifico></modifico>
    /// <fecha modifico></fecha modifico>
    /// <causa modificacion></motivo modificacion>
    private String Obtener_Leyenda_Boleto()
    {
        Cls_Apl_Parametros_Negocio Parametros = new Cls_Apl_Parametros_Negocio();
        DataTable Dt_Parametros = new DataTable();
        String Leyenda = String.Empty;
        try
        {
            Dt_Parametros = Parametros.Consultar_Parametros();
            if (Dt_Parametros != null)
            {
                if (Dt_Parametros.Rows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(Dt_Parametros.Rows[0][Cat_Parametros.Campo_Leyenda].ToString().Trim()))
                        Leyenda = Dt_Parametros.Rows[0][Cat_Parametros.Campo_Leyenda].ToString().Trim();
                }
            }
        }
        catch (Exception Ex)
        {
            throw new Exception("Error al obtener la leyenda del boleto. Error[" + Ex.Message + "]");
        }
        return Leyenda;
    }
    #endregion

    #region "Seguridad3D"
    ///******************************************************************************* 
    ///NOMBRE DE LA FUNCIÓN: Mensaje_Error_3D
    ///DESCRIPCIÓN: Obtiene el mensaje del error de acuerdo al código en estatus
    ///PARAMETROS: Estatus, recibo el numero de estatus
    ///CREO: Ismael Prieto Sánchez  
    ///FECHA_CREO: 19/Octubre/2012
    ///MODIFICO: 
    ///FECHA_MODIFICO:
    ///CAUSA_MODIFICACIÓN:
    ///*******************************************************************************
    protected String Mensaje_Error_3D(Int64 Estatus)
    {
        String Mensaje; //Almacena el mensaje de acuerdo al numero de error

        //Se verifica el código de error.
        switch (Estatus)
        {
            case 0:
                Mensaje = "TRANSACCION RECHAZADA - Error desconocido. Por favor comuniquese con su banco.";
                break;
            case 201:
            case 421:
                Mensaje = "El servicio de autenticación de transacciones está fuera de linea. Por favor intentelo más tarde.";
                break;
            case 422:
            case 423:
            case 424:
            case 425:
                Mensaje = "La contraseña ingresada para la transacción no es válida.";
                break;
            case 430:
                Mensaje = "No se especificó un número de tarjeta. Por favor verifique.";
                break;
            case 431:
                Mensaje = "No se especificó una fecha de expiración de la tarjeta. Por favor verifique.";
                break;
            case 432:
                Mensaje = "No se especificó un monto a pagar. Por favor verifique.";
                break;
            case 433:
                Mensaje = "Falta indicar el ID del comercio. Por favor verifique.";
                break;
            case 434:
                Mensaje = "La liga de respuesta esta vacia. Por favor verifique.";
                break;
            case 435:
                Mensaje = "Falta indicar el nombre del comercio. Por favor verifique.";
                break;
            case 436:
                Mensaje = "El número de tarjeta debe de ser de 16 digitos. Por favor verifique.";
                break;
            case 437:
                Mensaje = "El formato de la fecha de expiración es incorrecto. Por favor verifique.";
                break;
            case 438:
                Mensaje = "La fecha de expiración de la tarjeta no es válida. Por favor verifique.";
                break;
            case 439:
                Mensaje = "El monto indicado para el pago no es correcto. Por favor verifique.";
                break;
            case 440:
                Mensaje = "El nombre del comercio no puede ser mayor a 25 caracteres.  Por favor verifique.";
                break;
            case 498:
                Mensaje = "El tiempo de espera para la transacción ha expirado. Por favor intente nuevamente.";
                break;
            case 499:
                Mensaje = "El tiempo de captura para la transacción ha expirado. Por favor intente nuevamente.";
                break;
            default:
                Mensaje = "TRANSACCION RECHAZADA - Error desconocido. Por favor comuniquese con su banco.";
                break;
        }
        //Regresa el error.
        return Mensaje;
    }
    #endregion
}