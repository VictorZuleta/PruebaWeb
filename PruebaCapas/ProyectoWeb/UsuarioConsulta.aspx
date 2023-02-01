<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="ProyectoWeb.UsuarioConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuario</title>
    <link rel="stylesheet" type="text/css" href="estilo.css" />
</head>
<body>
<ul class="menu">
    <li style="color: white">Proyecto WEB  </li>
    <li> <a href="Usuario.aspx">Registro Usuario</a></li>
    <li> <a href="UsuarioConsulta.aspx">consulta Usuario</a></li>
</ul>
        <form id="form2" runat="server">
        <div class="formularioDatos">
            <asp:HiddenField ID="hIdUsuario" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <br />
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Fecha de nacimiento"></asp:Label>
            <br />
            <asp:TextBox ID="txtFecha" Style="text-align: center;" TextMode="Date" placeholder="Fecha de nacimiento" runat="server" Width="200px" Required=""></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Sexo"></asp:Label>
            <br />
            <asp:DropDownList ID="DrpLSexo" runat="server">
                <asp:ListItem Value="M">Masculino</asp:ListItem>
                <asp:ListItem Value="F">Femenino</asp:ListItem>

            </asp:DropDownList>
            <br />

            <asp:GridView ID="GrVUsuarios" runat="server" OnRowCommand="GrVUsuarios_RowComand">
                <Columns>
                    <asp:ButtonField CommandName="Selecionar" Text="Seleccionar"></asp:ButtonField>
                    <asp:ButtonField CommandName="Borrar" Text="Borrar"></asp:ButtonField>
                </Columns>
            </asp:GridView>
            <br />

            <asp:Button ID="ModiUsusario" runat="server" Text="Modificar" OnClick="ModiUsusario_Click" /><br />


        </div>
        </form>
</body>
</html>
