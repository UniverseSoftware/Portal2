<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="painel_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import url('css/login.css');
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="geral">
        <center><img src="../img/marca1.png" height="240" /></center>
        <fieldset>
            <font size="4"><b>Acesso ao Sistema</b></font>
            <div id="content_login">
                <label>Usuário</label>
                <asp:TextBox ID="txtUsuario" runat="server" />
                <label>Senha</label>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" />
                <br /><br />
                <asp:Button ID="btnAutenticar" Text="Entrar" runat="server" onclick="btnAutenticar_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCadastrar" Text="Cadastro" runat="server" onclick="btnCadastrar_Click"/>
                <br />
                <p> <a href="http://localhost:6783/painel/login.aspx" target="_blank"><font size="1">Esqueci minha senha</font></a></p>
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
