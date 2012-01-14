<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="Cadastros.aspx.cs" Inherits="HarunaNet.SisWeb.Cadastros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdEditarPedido" runat="server">
        <ContentTemplate>
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Cadastros
                    </h2>
                    <ul class="topnav" id="menu" runat="server">
                        <li><a href="Cad_Areas.aspx">Áreas </a></li>
                        <li><a href="CadUsuario.aspx">Usuários </a></li>
                        <li><a href="CadPerfil.aspx">Perfil </a></li>
                        <li><a href="Cad_Itens.aspx">Itens </a></li>
                        <li><a href="Fornecedor.aspx">Fornecedores </a></li>
                    </ul>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
