<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="Integrador.Formularios.Factura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
    Text="Facturas"></asp:Label>
    <br />
    <br />
<br />
<asp:Label ID="Label2" runat="server" Text="Pedido:"></asp:Label>
&nbsp;
<asp:DropDownList ID="ddlPedido" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlMesa_SelectedIndexChanged">
    <asp:ListItem Selected="True">Seleccione</asp:ListItem>
</asp:DropDownList>
    <asp:TextBox ID="txtIDPedido" runat="server" Visible="False"></asp:TextBox>
<br />
<asp:Label ID="Label3" runat="server" Text="Mozo:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:Label ID="lblMozo" runat="server"></asp:Label>
<br />
<asp:Label ID="Label4" runat="server" Text="Productos"></asp:Label>
<br />
<asp:ListBox ID="lblProductos" runat="server" Width="255px"></asp:ListBox>
<br />
<asp:Label ID="Label5" runat="server" Text="SubTotal:"></asp:Label>
&nbsp;
<asp:Label ID="lbSubTotal" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label6" runat="server" Text="Total:"></asp:Label>
&nbsp;
<asp:Label ID="lbTotal" runat="server"></asp:Label>
    <br />
<a href="javascript:window.print()" style="font-weight:bold">Imprimir</a>
<br />
<asp:Button ID="btnGuardar" runat="server" Text="Facturar" 
        onclick="btnGuardar_Click" />
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Imagenes/Guardar.png" />
<br />
</asp:Content>
