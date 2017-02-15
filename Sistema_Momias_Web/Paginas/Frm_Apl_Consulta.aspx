<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Frm_Apl_Consulta.aspx.cs" MasterPageFile="~/Paginas/MasterPage_ERP.master"
Inherits="WEB.Paginas_Frm_Apl_Consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .grid{
            margin-left: auto;
            margin-right: auto;
        }
        
        span {
            width:60px;
            font-size:12px;
            line-height:24px;
            font-weight:bold;
        }
        input[type=text] {
            width:300px;
            margin-bottom:5px;
            line-height:18px;
            padding:2px 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            border:1px solid #CCC;
        }
        
        .Lnk { font-size: x-large; }
    </style>

    <link href="../Estilos/Estilo_Punto_Venta.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Area_Trabajo2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Area_Trabajo1" Runat="Server">
    <div id="Imagen_Momias"></div>

    <asp:Label ID="Msj" runat="server"></asp:Label>

    <div style="margin-top: 2em; text-align: center;">
        <asp:Label ID="Lbl_Folio" runat="server" Text="Folio"></asp:Label>
        <asp:TextBox ID="Txt_Folio" runat="server" Width="200px"></asp:TextBox> <br /> <br />
        <asp:Button ID="Btn_Buscar" runat="server" Text="Buscar" Width="115px" 
            onclick="Btn_Buscar_Click" CssClass="button" />
        <input id="Btn_Descargar" type="button" value="Descargar" style="width: 115px;" class="button" />
        <asp:HiddenField ID="Hdf_Ruta" runat="server" />
    </div>

    <div style="width:100%; height: 300px; overflow: scroll; margin-top: 25px;">
        <asp:GridView ID="Grd_Accesos" runat="server" CellPadding="4" AutoGenerateColumns="false"
            ForeColor="#333333" GridLines="None" Width="90%" CssClass="grid">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <Columns>
                <asp:BoundField DataField="No_Venta" HeaderText="No. Venta" />
                <asp:BoundField DataField="NOMBRE_PRODUCTO" HeaderText="Producto" />
                <asp:BoundField DataField="Numero_Serie" HeaderText="Número de Acceso" />
                <asp:BoundField DataField="Usuario_Creo" HeaderText="Lugar Venta" />
            </Columns>
        </asp:GridView>
    </div>
    
    <div style="text-align: center; margin-top: 10px;">
        <asp:LinkButton ID="Lbk_Inicio" runat="server" Text="Inicio" 
            CssClass="Lnk" onclick="Lbk_Inicio_Click"></asp:LinkButton>
    </div>

    <script src="../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$=Btn_Buscar]").click(function (e) {
                var f = false;
                var Txt = $("[id$=Txt_Folio]").val();

                if (Txt === "") { alert("Debe ingresar un número de folio"); f = true; }
                if (isNaN(Txt)) { alert("El folio debe ser numérico"); f = true; }
                if (f) { e.preventDefault(); }
            });

            $("#Btn_Descargar").click(function () {
                var ruta = $("[id$=Hdf_Ruta]").val();
                if (ruta !== "") {
                    window.location.href = 'Abrir_Archivos.aspx?Documento=' + encodeURI(ruta);
                }
            });
        });
    </script>
</asp:Content>