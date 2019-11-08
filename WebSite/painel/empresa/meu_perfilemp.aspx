<%@ Page Title="" Language="C#" MasterPageFile="~/painel/empresa/MasterPageEmp.master" AutoEventWireup="true" CodeFile="meu_perfilemp.aspx.cs" Inherits="painel_meu_perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form">
        <h3>Empresa</h3>
        <br />
        <asp:HiddenField ID="hdfId" runat="server" />
        <label class="label">Usuário de Acesso</label>
        <asp:TextBox ID="txtUserUsuario" runat="server"></asp:TextBox><br />
        <label class="label">Senha</label>
        <asp:TextBox ID="txtPassUsuario" runat="server" TextMode="Password"></asp:TextBox><br />
        <label class="label">Confirma senha</label>
        <asp:TextBox ID="txtConfirmaPassUsuario" runat="server" TextMode="Password"></asp:TextBox><br />
        <label class="label">Nome Fantasia</label>
        <asp:TextBox ID="txtNomeEP" runat="server"></asp:TextBox><br /> 
        <label class="label">Razão Social</label>
        <asp:TextBox ID="txtSnomeEP" runat="server"></asp:TextBox><br />
        <label class="label">E-mail</label>
        <asp:TextBox ID="txtEmailEP" runat="server"></asp:TextBox><br />
        <label class="label">CNPJ</label>
        <asp:TextBox ID="txtCGCEP" runat="server"></asp:TextBox><br />
        <label class="label">Telefone</label>
        <asp:TextBox ID="txtTelEP" runat="server"></asp:TextBox><br />
        <label class="label">Endereço</label>
        <asp:TextBox ID="txtEndEP" runat="server"></asp:TextBox><br />
        <asp:CheckBox ID="chkAtivo" runat="server" Text="Ativo" /><br />
        <div class="command">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" />
        </div>
    </div>
    <br />
</asp:Content>

