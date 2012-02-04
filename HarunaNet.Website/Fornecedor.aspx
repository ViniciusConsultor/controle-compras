<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="Fornecedor.aspx.cs" Inherits="HarunaNet.SisWeb.Fornecedor" Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="dvPesqCadUsu" runat="server">
        <div id="conteudo">
            <div class="cont_pesq">
                <h2>
                    Cadastro de Fornecedores - Pesquisa</h2>
                <table border="0" cellpadding="0" cellspacing="1" width="100%">
                    <tr>
                        <td class="gridnormal" align="left" style="width: 150px;">
                            <asp:Label CssClass="labeltitulo" ID="Label1" runat="server" Text="Nome Fantasia:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtNomeFantasia" CssClass="textboxes"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="gridnormal" align="left">
                            <asp:Label CssClass="labeltitulo" ID="Label4" runat="server" Text="Status:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddlStatus">
                                <asp:ListItem Value="1" Text="ATIVO"></asp:ListItem>
                                <asp:ListItem Value="2" Text="INATIVO"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 100px;">
                        </td>
                    </tr>
                </table>
                <br />
                <asp:ImageButton ID="btnPesquisar" runat="server" ImageUrl="~/library/img/ic_pesquisar.png"
                    ToolTip="Pesquisar Fornecedor" OnClick="btnPesquisar_Click" />
                &nbsp;
                <asp:ImageButton ID="btnInserir" runat="server" ImageUrl="~/library/img/ic_adicionar.png"
                    ToolTip="Inserir Novo Usuário" OnClick="btnInserir_Click" />
                <br />
                <br />
            </div>
        </div>
        <div id="resultado">
            <div class="result_pesq">
                <asp:GridView runat="server" ID="grdFornecedores" AutoGenerateColumns="False" OnRowDataBound="grdFornecedores_RowDataBound"
                    Width="100%" SkinID="HarunaGrid" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="NomeFantasia" HeaderText="Nome Fantasia" ItemStyle-Width="30%">
                            <ItemStyle Width="30%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="RazaoSocial" HeaderText="Razão Social" ItemStyle-Width="45%">
                            <ItemStyle Width="45%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" ItemStyle-Width="15%">
                            <ItemStyle Width="15%"></ItemStyle>
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar Fornecedor!" ImageUrl="~/library/img/ic_editar.gif"
                                    OnClick="btnEditar_Click" />
                                <asp:ImageButton ID="btnExcluir" runat="server" ToolTip="Apagar Fornecedor!" ImageUrl="~/library/img/delete.png"
                                    OnClientClick="return confirm('Deseja realmente apagar?');" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Selecionar" Visible="False">
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgSelecionar" runat="server" CausesValidation="false" CommandName="Selecionar"
                                ImageUrl="~/library/img/btnSelecionar.png" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <br />
    </div>
</asp:Content>
