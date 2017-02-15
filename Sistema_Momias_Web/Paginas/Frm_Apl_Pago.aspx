<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Paginas/MasterPage_ERP.master"
CodeFile="Frm_Apl_Pago.aspx.cs" Inherits="WEB.Paginas_Frm_Apl_Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../Estilos/Estilo_Pago.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Area_Trabajo2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Area_Trabajo1" Runat="Server">
    <asp:Image ID="Img_Operacion" runat="server" />
    <div class="div">
        <asp:Panel ID="Lbl_Mensaje" runat="server">
            <asp:Label ID="Lbl_Msj" runat="server"></asp:Label>
        </asp:Panel>
        <asp:GridView ID="Grd_Productos" runat="server" CellPadding="4" AutoGenerateColumns="false"
            ForeColor="#333333" GridLines="None" Width="600px">
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
                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" />
                <asp:BoundField DataField="COSTO" HeaderText="Costo" DataFormatString="{0:C}" />
                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="div_2">
        <asp:Button ID="Btn_Principal" runat="server" Text="Realizar Nueva Compra" Width="200px"
            onclick="Btn_Principal_Click" /> <br />
        <input type="button" id="Btn_Pdf" value="Imprimir Comprobante" style="width: 200px;" />
        <asp:Label ID="Lbl_Ruta_Pdf" runat="server" CssClass="pdf"></asp:Label>
    </div>

    <script src="../Scripts/jquery-easyui-1.3.1/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var ruta = $("[id$=Lbl_Ruta_Pdf]").text();

            if (ruta == "") {
                $("#Btn_Pdf").hide();
            }

            $("#Btn_Pdf").click(function () {
                window.location.href = 'Abrir_Archivos.aspx?Documento=' + encodeURI(ruta);
            });
        });
    </script>
</asp:Content>