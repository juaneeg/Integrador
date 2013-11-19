<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Integrador.Formularios.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
    Text="Pagina Principal"></asp:Label>
<br />
<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
    Text="Inicie Sesion "></asp:Label>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Usuario:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Contraseña:"></asp:Label>
&nbsp;<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:ImageButton ID="btnIniciar" runat="server" ImageAlign="Middle" 
    ImageUrl="~/Imagenes/Login.png" onclick="btnIniciar_Click" 
    ToolTip="Iniciar Sesion" />
&nbsp;<asp:ImageButton ID="btnSalir" runat="server" ImageAlign="Middle" 
    ImageUrl="~/Imagenes/LogOut.png" ToolTip="Cerrar Sesion" Visible="False" 
    onclick="btnSalir_Click" />
<br />
<asp:Label ID="lblMensaje" runat="server"></asp:Label>
<br />
</asp:Content>
