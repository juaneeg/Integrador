<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartaPlato.aspx.cs" Inherits="Integrador.Formularios.CartaPlato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
        Text="Menu"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    <asp:Button ID="btnCrear" runat="server" onclick="btnCrear_Click" 
        Text="Crear" />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Tipo de Producto"></asp:Label>
    <asp:DropDownList ID="ddlTiposProducto" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlTiposProducto_SelectedIndexChanged">
        <asp:ListItem>Seleccione</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Producto"></asp:Label>
    <asp:DropDownList ID="ddlProducto" runat="server">
        <asp:ListItem>Seleccione</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
        Text="Agregar" />
    <br />
    <asp:ListBox ID="lbMenu" runat="server" Width="209px"></asp:ListBox>
    <br />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
    <br />
    <br />
    <asp:Panel ID="panelGrilla" runat="server" Height="250px" ScrollBars="Auto">
        <asp:GridView ID="grillaMenu" runat="server" BorderStyle="Groove" 
            CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" 
            ShowFooter="True" ShowHeaderWhenEmpty="True" ToolTip="Menus del restaurante" 
            Width="755px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#77D647" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#77D647" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </asp:Panel>
    <br />
</asp:Content>
