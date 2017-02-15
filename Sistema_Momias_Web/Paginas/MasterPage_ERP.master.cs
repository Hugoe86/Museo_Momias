using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data;
using System.Xml.Linq;
using System.Web.Security;
using Erp.Sesiones;
using Erp.Metodos_Generales;

public partial class MasterPage_ERP : System.Web.UI.MasterPage
{

    public string m_strTitulo;
    public HtmlGenericControl Etiqueta_Body_Master_Page
    {
        get
        {
            return MasterPageBodyTag;
        }
        set
        {
            MasterPageBodyTag = value;
        }
    }

    /********************************************************************************************************
     * NOMBRE_FUNCIÓN: Do_Asignar_Estilo
     * DESCRIPCIÓN: Asigan el estilo del masterpage 
     * PARÁMETROS:
                1. p_intTipo, Estilo a aplicar
     * CREO: Alberto Pantoja Hernández
     * FECHA_CREO:27/07/10
     * MODIFICÓ:
     * FECHA_MODIFICÓ:
     * CAUSA_MODIFICACIÓN: 
     *********************************************************************************************************/
    public void Do_Asignar_Estilo(int p_intTipo)
    {
        switch (p_intTipo)
        {
            case 1:
                principal.Style.Clear();
                principal.Style.Add("position", "absolute");
                principal.Style.Add("left", "50%");
                principal.Style.Add("height", "800px");
                principal.Style.Add("width", "1080px");
                principal.Style.Add("margin-left", "-540px");
                principal.Style.Add("margin-top", "30px");
                principal.Style.Add("background-color", "white");

                encabezado.Visible = true;
                encabezado.Style.Clear();
                encabezado.Style.Add("position", "absolute");
                encabezado.Style.Add("display", "block");
                encabezado.Style.Add("width", "1080px");
                encabezado.Style.Add("height", "85px");
                encabezado.Style.Add("left", "0px");
                encabezado.Style.Add("top", "-15px");
                //encabezado.Style.Add("background-image", "url(" + ConfigurationManager.AppSettings["Imagen_Encabezado_Pantalla"] + ")");
                encabezado.Style.Add("background-position", "center left");
                encabezado.Style.Add("background-repeat", "no-repeat");
                encabezado.Style.Add("background-color", "white");
                encabezado.Style.Add("border-radius", "15px 15px 0px 0px");
                encabezado.Style.Add("-moz-border-radius", "15px 15px 0px 0px");
                encabezado.Style.Add("-webkit-border-radius", "15px 15px 0px 0px");

                barra.Visible = true;
                barra.Style.Clear();
                barra.Style.Add("position", "absolute");
                barra.Style.Add("width", "1080px");
                barra.Style.Add("height", "5px");
                barra.Style.Add("left", "0px");
                barra.Style.Add("top", "75px");
                barra.Style.Add("font-size", "small");
                barra.Style.Add("background-color", "#ffc334");

                contenido_fondo.Visible = true;
                contenido_fondo.Style.Clear();
                contenido_fondo.Style.Add("position", "absolute");
                contenido_fondo.Style.Add("width", "1000px");
                contenido_fondo.Style.Add("height", "auto");
                contenido_fondo.Style.Add("left", "40px");
                contenido_fondo.Style.Add("right", "40px");
                contenido_fondo.Style.Add("top", "93px");
                contenido_fondo.Style.Add("font-size", "small");
                contenido_fondo.Style.Add("text-align", "justify");
                contenido_fondo.Style.Add("background-color", "white");
                contenido_fondo.Style.Add("overflow", "auto");
                contenido_fondo.Style.Add("float", "left");
                contenido_fondo.Style.Add("background-color", "white");
                break;
            case 2:
                principal.Style.Clear();
                principal.Style.Add("position", "absolute");
                principal.Style.Add("left", "50%");
                principal.Style.Add("top", "50%");
                principal.Style.Add("height", "542px");
                principal.Style.Add("margin-top", "-271px");
                principal.Style.Add("width", "980px");
                principal.Style.Add("margin-left", "-490px");
                principal.Style.Add("background-color", "white");

                encabezado_login.Visible = false;
                contenido_fondo_login.Style.Clear();
                contenido_fondo_login.Style.Add("position", "absolute");
                contenido_fondo_login.Style.Add("height", "491px");
                contenido_fondo_login.Style.Add("width", "980px");
                contenido_fondo_login.Style.Add("left", "0px");
                contenido_fondo_login.Style.Add("top", "18px");
                contenido_fondo_login.Style.Add("font-size", "small");
                contenido_fondo_login.Style.Add("background-position", "center");
                contenido_fondo_login.Style.Add("background-repeat", "no-repeat");
                contenido_fondo_login.Style.Add("z-index", "4");
                break;
        }
    }

    protected void Page_Load(object sendre, EventArgs e)
    {
        //Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5));
        if (!Page.IsPostBack)
        {
            Do_Asignar_Estilo(1);
           // Lbl_Fecha.Text = DateTime.Now.ToString("dd MMMM yyyy").ToUpper();
        }
    }
}
