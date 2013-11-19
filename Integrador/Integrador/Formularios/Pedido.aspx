<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="Integrador.Formularios.Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
        Text="Pedido"></asp:Label>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
        RepeatDirection="Horizontal">
        <asp:ListItem Selected="True">Nuevo</asp:ListItem>
        <asp:ListItem>Modificar</asp:ListItem>
        <asp:ListItem>Reserva</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="lblReserva" runat="server" Text="Reserva" Visible="False"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlReserva" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlReserva_SelectedIndexChanged" Visible="False">
        <asp:ListItem>Seleccione</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="lblPedido" runat="server" Text="Pedido" Visible="False"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlPedido" runat="server" Visible="False" 
        AutoPostBack="True" onselectedindexchanged="ddlPedido_SelectedIndexChanged">
        <asp:ListItem Selected="True">Seleccione</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Cliente"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
    
    <asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
    
    <br />
    <asp:Label ID="Label10" runat="server" Text="Turno:"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlTurno" runat="server">
        <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
        <asp:ListItem Value="1">Turno Matutino</asp:ListItem>
        <asp:ListItem Value="2">Turno Vespertino</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:ImageButton ID="btnActualizar" runat="server" ImageAlign="Middle" 
        ImageUrl="~/Imagenes/Refresh.png" onclick="btnActualizar_Click" 
        ToolTip="Cargar Mesas" />
&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Mesa"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlMesa" runat="server">
        <asp:ListItem>Seleccione</asp:ListItem>
    </asp:DropDownList>
    
    &nbsp;
    <asp:ImageButton ID="btnAgregarMesa" runat="server" ImageAlign="Middle" 
        ImageUrl="~/Imagenes/Agregar.png" onclick="btnAgregarMesa_Click1" 
        ToolTip="Agregar Mesa Al Pedido" />
    
    <br />
    <asp:ListBox ID="lblMesas" runat="server" Height="46px" Width="184px">
    </asp:ListBox>
    
    <br />
    <asp:Label ID="Label3" runat="server" Text="Mozo"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlMozo" runat="server">
        <asp:ListItem>Seleccione</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:ImageButton ID="btnCrear" runat="server" ImageAlign="Middle" 
        ImageUrl="~/Imagenes/Guardar.png" onclick="ImageButton1_Click" 
        ToolTip="Crear Pedido" />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Tipo Plato"></asp:Label>
&nbsp;<asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlTipo_SelectedIndexChanged">
        <asp:ListItem>Seleccione</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Productos"></asp:Label>
    &nbsp;
    <asp:DropDownList ID="ddlProducto" runat="server">
        <asp:ListItem>Seleccione</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Label ID="Label6" runat="server" Text="Cantidad"></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtCantidad" runat="server">1</asp:TextBox>
    &nbsp;
    <asp:ImageButton ID="btnAgregar" runat="server" ImageAlign="Middle" 
        ImageUrl="~/Imagenes/Agregar.png" onclick="btnAgregar_Click1" 
        ToolTip="Al Pedido" />
    <br />
    <asp:ListBox ID="lbProductos" runat="server" Width="508px"></asp:ListBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Subtotal:"></asp:Label>
    <asp:Label ID="lblSubTotal" runat="server">0</asp:Label>
    <asp:Label ID="Label8" runat="server" Text="Total:"></asp:Label>
    <asp:Label ID="lblTotal" runat="server">0</asp:Label>
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
        onclick="btnGuardar_Click" />
    <br />
</asp:Content>
