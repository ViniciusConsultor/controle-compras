<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="CadPerfil.aspx.cs" Inherits="HarunaNet.SisWeb.CadPerfil" Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdPesqCadP">
        <ContentTemplate>
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Cadastro de Perfis de Usuário - Pesquisa</h2>
                    <table border="0" cellpadding="0" cellspacing="1" width="100%">
                        <tr>
                            <td class="gridnormal" align="left" style="width: 150px;">
                                <asp:Label CssClass="label" ID="lblDescicao" runat="server" Text="Descrição:"></asp:Label>
                            </td>
                            <td align="left" style="width: 300px;">
                                <asp:TextBox runat="server" Width="300px" ID="tbxPesquisaDescPerfil"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 50%;">
                                <asp:ImageButton ID="btnPesquisarPerfil" runat="server" ImageUrl="~/library/img/ic_pesquisar.png"
                                    ToolTip="Pesquisar Usuário" OnClick="btnPesquisarPerfil_Click" />
                                &nbsp;
                                <asp:ImageButton ID="btnInserirPerfil" runat="server" ImageUrl="~/library/img/ic_adicionar.png"
                                    ToolTip="Inserir Novo Usuário" OnClick="btnInserirPerfil_Click" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                </div>
            </div>
            <br />
            <div id="resultado">
                <div class="result_pesq">
                    <asp:GridView runat="server" ID="gvCadPerfil" AutoGenerateColumns="false" OnRowDataBound="gvCadPerfil_RowDataBound"
                        Width="100%" SkinID="HarunaGrid">
                        <HeaderStyle CssClass="gridheader" />
                        <RowStyle CssClass="gridnormal" />
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="PerfilId" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Descrição" DataField="Descricao" HeaderStyle-HorizontalAlign="Left" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditarPerfil" OnClick="btnEditarPerfil_Click" runat="server"
                                        ToolTip="Editar Perfil!" ImageUrl="~/library/img/ic_editar.gif" />
                                    <asp:ImageButton ID="btnExcluirPerfil" runat="server" ToolTip="Apagar Perfil!" ImageUrl="~/library/img/delete.png"
                                        OnClick="btnExcluirPerfil_Click" OnClientClick="return confirm('Deseja realmente apagar?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" OnClick="btn_Voltar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="dvDetCadPerfil" class="jqmWindow">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <div class="divtitulo">
                    <span>Cadastro de Perfis de Usuário</span>
                </div>
                <fieldset>
                    <span class="textotitulos">Código:</span><br />
                    <asp:TextBox runat="server" ID="tbxCodigoPerfil" ReadOnly="true" CssClass="textboxes"></asp:TextBox><br />
                    <span class="textotitulos">Descrição</span><br />
                    <asp:TextBox runat="server" ID="tbxDescricaoPerfil" CssClass="textboxes"></asp:TextBox><br />
                    <div>
                        <asp:Button runat="server" ID="btnCancelarCadPerfil" Text="Cancelar" OnClick="btnCancelarCadPerfil_Click" />
                        <asp:Button runat="server" ID="btnSalvarPerfil" Text="Salvar" OnClick="btnSalvarPerfil_Click" />
                    </div>
                </fieldset>
                <div class="divtitulos">
                    <span>Módulos que este perfil pode acessar</span>
                </div>
                <asp:GridView runat="server" ID="gvModulosPerfil" AutoGenerateColumns="false" OnRowDataBound="gvModulosPerfil_RowDataBound"
                    Width="100%">
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridnormal" />
                    <Columns>
                        <asp:BoundField HeaderText="Código do Módulo" DataField="ModuloId" />
                        <asp:BoundField HeaderText="Descrição do Módulo" DataField="Descricao" />
                        <asp:TemplateField HeaderText="Tem Acesso?" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkPermissaoModulo" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        var $dvDetCadPerfil = $('#dvDetCadPerfil').jqm({ modal: true, toTop: true, trigger: false });
    </script>
</asp:Content>
