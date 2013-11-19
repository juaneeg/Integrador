<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="Integrador.Formularios.Reservas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="XX-Large" 
        Text="Reservas"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Fecha:" Font-Bold="True" 
        Font-Size="Medium"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtFecha" runat="server" 
        ontextchanged="txtFecha_TextChanged"></asp:TextBox>
    <asp:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtFecha" Format="dd/MM/yyyy">
    </asp:CalendarExtender>
    <asp:TextBox ID="txtID" runat="server" Visible="False">0</asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Medium" 
        Text="Turno:"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlTurno" runat="server">
        <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
        <asp:ListItem Value="1">Turno Matutino</asp:ListItem>
        <asp:ListItem Value="2">Turno Vespertino</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Cliente:" Font-Bold="True" 
        Font-Size="Medium"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Cantidad Personas:" 
        Font-Bold="True" Font-Size="Medium"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtCantidad" runat="server" AutoPostBack="True" 
        ontextchanged="txtCantidad_TextChanged"></asp:TextBox>
    <asp:FilteredTextBoxExtender ID="txtCantidad_FilteredTextBoxExtender" 
        runat="server" Enabled="True" TargetControlID="txtCantidad" ValidChars="1234567890">
    </asp:FilteredTextBoxExtender>
    <asp:Label ID="lblAvisoMesas" runat="server"></asp:Label>
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="Middle" 
        ImageUrl="~/Imagenes/Refresh.png" onclick="ImageButton1_Click" 
        ToolTip="Cargar Mesas Libres" />
&nbsp;
    <asp:Label ID="Label4" runat="server" Text="Mesa(s):" Font-Bold="True" 
        Font-Size="Medium"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlMesa" runat="server">
        <asp:ListItem>Selecione</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnAgregar" runat="server" Text="+" 
        onclick="btnAgregar_Click" />
    <br />
    <asp:ListBox ID="lbMesas" runat="server" Width="280px"></asp:ListBox>
    <asp:Button ID="btnSacar" runat="server" onclick="btnSacar_Click" Text="-" />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Estado:" Font-Bold="True" 
        Font-Size="Medium"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlEstado" runat="server">
        <asp:ListItem Value="1">Activo</asp:ListItem>
        <asp:ListItem Value="0">Inactivo</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
    <br />
    <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
        Text="Guardar" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
        onclick="btnCancelar_Click" />
    <br />
    <br />
    <asp:Panel ID="panelGrilla" runat="server" Height="250px" ScrollBars="Auto">
        <asp:GridView ID="grillaReservas" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onselectedindexchanged="grillaReservas_SelectedIndexChanged" 
            BorderStyle="Groove" HorizontalAlign="Center" ShowFooter="True" 
            ShowHeaderWhenEmpty="True" Width="755px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <EditRowStyle BackColor="#CCFF99" />
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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />

</asp:Content>
