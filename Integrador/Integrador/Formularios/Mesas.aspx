<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mesas.aspx.cs" Inherits="Integrador.Formularios.Mesas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="XX-Large" 
        Text="Mesas"></asp:Label>
    <br />
    <br />

    <asp:Label ID="Label1" runat="server" Text="Descripción"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtID" runat="server" Visible="False">0</asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Capacidad"></asp:Label>
    <asp:TextBox ID="txtCapacidad" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Estado"></asp:Label>
    <asp:DropDownList ID="ddlEstado" runat="server">
        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
        <asp:ListItem Value="Disponible">Disponible</asp:ListItem>
        <asp:ListItem Value="Inactiva">Inactiva</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
        Text="Guardar" />
    <br />
    <br />
    <asp:Panel ID="panelGrilla" runat="server" Height="250px" ScrollBars="Auto">
        <asp:GridView ID="grillaMesas" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="grillaMesas_SelectedIndexChanged" BorderStyle="Groove" HorizontalAlign="Center" 
    ShowHeaderWhenEmpty="True" ToolTip="Mesas del  restaurante" Width="755px" 
            ShowFooter="True">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
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

</asp:Content>
