<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listados.aspx.cs" Inherits="Integrador.Formularios.Listados" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" 
        Text="Listados"></asp:Label>
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
        RepeatDirection="Horizontal" 
        onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="1">Ranking 10 Platos</asp:ListItem>
        <asp:ListItem Value="2">Total facturado entre fechas</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="lblInicial" runat="server" Text="Fecha Inicial:" Visible="False"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtFechaIni" runat="server" Visible="False"></asp:TextBox>
    <asp:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtFechaIni" Format="dd/MM/yyyy">
    </asp:CalendarExtender>
&nbsp;&nbsp;
    <asp:Label ID="lblFinal" runat="server" Text="Fecha Final:" Visible="False"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtFechaFin" runat="server" Visible="False"></asp:TextBox>
    <asp:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="txtFechaFin" Format="dd/MM/yyyy">
    </asp:CalendarExtender>
    <br />
    <asp:Label ID="lblFiltro" runat="server" Text="Filtrar por:" Visible="False"></asp:Label>
&nbsp;
    <asp:DropDownList ID="ddlFiltro" runat="server" Visible="False">
        <asp:ListItem Selected="True">Plato</asp:ListItem>
        <asp:ListItem>Mozo</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;
    <asp:ImageButton ID="btnActualizar" runat="server" ImageAlign="Middle" 
        ImageUrl="~/Imagenes/Refresh.png" onclick="btnActualizar_Click" 
        Visible="False" />
    <br />
    <asp:Panel ID="panelRanking" runat="server" Height="300px" ScrollBars="Auto">
        &nbsp;
        <asp:GridView ID="gvRanking" runat="server" 
    CellPadding="4" ForeColor="#333333" GridLines="None" BorderStyle="Groove" 
            HorizontalAlign="Center" ShowFooter="True" ShowHeaderWhenEmpty="True" 
            Width="755px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#77D647" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#77D647" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Center" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </asp:Panel>
    <a href="javascript:window.print()" style="font-weight:bold">Imprimir</a>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <br />
</asp:Content>
