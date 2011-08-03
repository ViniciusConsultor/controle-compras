<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLogin.Master" AutoEventWireup="true"
    CodeBehind="login.aspx.cs" Inherits="HarunaNet.SisWeb.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login">
        <asp:Label ID="lbl_usuario" CssClass="labellogin" runat="server" Text="Usuário:"></asp:Label><br />
        <asp:RequiredFieldValidator ID="rfvtbLogin" runat="server" ControlToValidate="tbLogin"
            ValidationGroup="login" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Login Obrigatório!"
            ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:TextBox runat="server" CssClass="texto" ID="tbLogin"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label1" CssClass="labellogin" runat="server" Text="Senha:"></asp:Label><br />
        <asp:RequiredFieldValidator ID="rfvtbSenha" runat="server" ControlToValidate="tbSenha"
            ValidationGroup="login" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Senha Obrigatória!"
            ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:TextBox runat="server" CssClass="texto" ID="tbSenha" TextMode="Password"></asp:TextBox>
        <div>
            <br />
            <asp:ImageButton runat="server" ID="btnLogin" ValidationGroup="login" ImageUrl="~/library/imagens/btn_entrar.png"
                ToolTip="Clique aqui para fazer seu Login!" onclick="btnLogin_Click"  />
        </div>
    </div>
</asp:Content>
