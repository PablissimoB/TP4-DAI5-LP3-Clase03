<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Clase3.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-3">
            <div class="mb-3">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-select" DataSourceID="SqlDataSource1" DataTextField="username" DataValueField="id" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="323px">
            </asp:DropDownList>
                </div>
            <div class="input-group mb-3">
            Username <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
            Password
            <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
            Tipo Usuario
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select" DataSourceID="SqlDataSource2" DataTextField="descripcion" DataValueField="id" AppendDataBoundItems="true">
                <asp:ListItem Text="-- Seleccione categoría --" Value="" />
            </asp:DropDownList>
                </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:cadena %>" SelectCommand="SELECT * FROM [UsuarioTipos]"></asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Modificar" CssClass="btn btn-primary" />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cadena %>" SelectCommand="SELECT * FROM [Usuarios]"></asp:SqlDataSource>
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>
