<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/MasterPage_ERP.master" AutoEventWireup="true" CodeFile="Frm_Apl_Principal_Controlador.aspx.cs" Inherits="Paginas_Frm_Apl_Principal_Controlador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Area_Trabajo2" Runat="Server">
    <asp:HiddenField ID="Hdf_3D_ECI" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cph_Area_Trabajo1" Runat="Server">
    <asp:HiddenField ID="Hdf_3D_XID" runat="server" />
    <asp:HiddenField ID="Hdf_3D_CAVV" runat="server" />
    <asp:HiddenField ID="Hdf_3D_Estatus" runat="server" />
</asp:Content>

