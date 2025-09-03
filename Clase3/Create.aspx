<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="Clase3.Create" %>

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
            <div class="input-group mb-3">
            Username<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            Password
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            TipoUsuarios
            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true">
                  <asp:ListItem Text="-- Seleccione categoría --" Value="" />
            </asp:DropDownList>
            </div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Agregar" style="height: 26px" />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
</body>
</html>
