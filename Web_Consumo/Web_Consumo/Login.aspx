<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Consumo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href=".\css\login.css" rel="stylesheet" />
</head>
<body>
        <div class="loginbox" runat="server">
            <img src=".\img\destination\7.png" alt="Login" class="user" />
            <h2> INICIO DE SESSIÓN </h2><br /><br />
            <form runat="server">
                <asp:Label Text="Usuario" CssClass="lblemail" runat="server" />
                <asp:TextBox ID="txt_Username" runat="server" CssClass="txtemail" placeholder="Nombre de Usuario"/>
                <asp:Label Text="Contraseña" CssClass="lblpass" runat="server" />
                <asp:TextBox ID="txt_Password" runat="server" TextMode="Password" CssClass="txtpass" placeholder="Contraseña"/>
                <asp:Button ID="btn_Login" Text="Login" runat="server" CssClass="btnsubmit" OnClick="btn_Login_Click"/>
            </form>
        </div>
</body>
</html>
