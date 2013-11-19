<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mozos.aspx.cs" Inherits="Integrador.Formularios.Mozos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Text="Mozos"></asp:Label>
            <br />
            <br />
            <br />
            
            <asp:Label ID="Label1" runat="server" Text="Nombre:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            &nbsp;<asp:TextBox ID="txtID" runat="server" Visible="False"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Apellido:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Cedula:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Label ID="Label12" runat="server" 
                Text="Se utilizara como usuario para ingresar al sistema"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Contraseña:"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Telefono:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Dirección:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Email:"></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Activo:"></asp:Label>
            <asp:DropDownList ID="ddlEstado" runat="server">
                <asp:ListItem Value="1">Activo</asp:ListItem>
                <asp:ListItem Value="0">Inactivo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                onclick="btnGuardar_Click" />
            &nbsp;
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                onclick="btnEliminar_Click" />
            <br />
            <asp:Panel ID="panelGrilla" runat="server" Height="200px" 
    ScrollBars="Auto">
                <asp:GridView ID="gvMozos" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" 
    onselectedindexchanged="gvMozos_SelectedIndexChanged" 
    BorderStyle="Groove" HorizontalAlign="Center" ShowFooter="True" ShowHeaderWhenEmpty="True" 
                    ToolTip="Mozos del restaurante" Width="755px">
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
            <br />
            </asp:Content>