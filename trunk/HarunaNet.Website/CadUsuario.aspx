<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="CadUsuario.aspx.cs" Inherits="HarunaNet.SisWeb.CadUsuario" Theme="haruna" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="dvPesqCadUsu" runat="server">
        <asp:UpdatePanel runat="server" ID="UpdPesqCadUsu">
            <ContentTemplate>
                <div id="conteudo">
                    <div class="cont_pesq">
                        <h2>
                            Cadastro de Usuários - Pesquisa</h2>
                        <table border="0" cellpadding="0" cellspacing="1" width="100%">
                            <tr>
                                <td class="gridnormal" align="left" style="width: 150px;">
                                    <asp:Label CssClass="labeltitulo" ID="Label1" runat="server" Text="Nome Completo:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="tbxPesqNomeUsu" CssClass="textboxes"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="gridnormal" align="left">
                                    <asp:Label CssClass="labeltitulo" ID="Label2" runat="server" Text="Login:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="tbxPesqLoginUsu" CssClass="textboxes"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="gridnormal" align="left">
                                    <asp:Label CssClass="labeltitulo" ID="Label3" runat="server" Text="Perfil:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList runat="server" ID="ddlPesqPerfilUsu">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="gridnormal" align="left">
                                    <asp:Label CssClass="labeltitulo" ID="Label4" runat="server" Text="Status:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList runat="server" ID="ddlPesqStatusUsu">
                                        <asp:ListItem Value="" Text="--TODOS--"></asp:ListItem>
                                        <asp:ListItem Value="A" Text="ATIVO"></asp:ListItem>
                                        <asp:ListItem Value="I" Text="INATIVO"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="width: 100px;">
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:ImageButton ID="btnPesquisarUsu" runat="server" ImageUrl="~/library/img/ic_pesquisar.png"
                            ToolTip="Pesquisar Usuário" OnClick="btnPesquisarUsu_Click" />
                        &nbsp;
                        <asp:ImageButton ID="btnInserirUsuario" runat="server" ImageUrl="~/library/img/ic_adicionar.png"
                            ToolTip="Inserir Novo Usuário" OnClick="btnInserirUsuario_Click" />
                        <br />
                        <br />
                    </div>
                </div>
                <div id="resultado">
                    <div class="result_pesq">
                        <asp:GridView runat="server" ID="gvPesqUsuarios" AutoGenerateColumns="false" OnRowDataBound="gvPesqUsuarios_RowDataBound"
                            Width="100%" SkinID="HarunaGrid">
                            <Columns>
                                <asp:BoundField DataField="Login" HeaderText="Login" />
                                <asp:BoundField DataField="Nome" HeaderText="Nome Completo" />
                                <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblAtivo" Text='<%# Eval("Status")=="A"?"Inativo":"Ativo" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Perfil" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lbPerfil" Text='<%# Eval("Perfil.Descricao") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEditarUsuario" OnClick="btnEditarUsuario_Click" runat="server"
                                            ToolTip="Editar usuário!" ImageUrl="~/library/img/ic_editar.gif" />
                                        <asp:ImageButton ID="btnExcluirUsuario" runat="server" ToolTip="Apagar usuário!"
                                            ImageUrl="~/library/img/delete.png" OnClick="btnExcluirUsuario_Click" OnClientClick="return confirm('Deseja realmente apagar?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <br />
                <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" OnClick="btn_Voltar_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--class="jqmWindow"--%>
    <div id="dvDetCadUsu" class="jqmWindow">
        <asp:UpdatePanel ID="UpdDetCadUsu" runat="server">
            <ContentTemplate>
                <div class="divtitulo">
                    <span>Cadastro de Usuários</span>
                </div>
                <fieldset>
                    <table>
                        <tr>
                            <td>
                                <span class="textotitulos"></span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" Visible="false" ID="tbxCodigoUsuario" CssClass="textboxes"
                                    ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="textotitulos">Nome Completo:</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblErroNomeUsuario" runat="server" CssClass="mensagem-vermelho" Visible="False" />
                                <asp:TextBox runat="server" ID="tbxNomeUsuario" CssClass="textboxes"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomeUsuario" runat="server" ControlToValidate="tbxNomeUsuario"
                                    ValidationGroup="Inserir" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Nome Obrigatório!"
                                    ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="textotitulos">e-mail:</span>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblErroEmail" runat="server" CssClass="mensagem-vermelho" Visible="False" />
                                <asp:TextBox runat="server" ID="txtemail" CssClass="textboxes"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtemail"
                                    ValidationGroup="Inserir" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="E-Mail Obrigatório!"
                                    ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="textotitulos">Login:</span>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="tbxLoginUsuario" CssClass="textboxes"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="tbxLoginUsuario"
                                    ValidationGroup="Inserir" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Login Obrigatório!"
                                    ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="textotitulos">Senha:</span>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="tbxSenhaUsuario" CssClass="textboxes" TextMode="Password"></asp:TextBox>
                                <%-- <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="tbxSenhaUsuario"
                                    ValidationGroup="Inserir" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Senha Obrigatória!"
                                    ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="textotitulos">Perfil:</span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlPerfilUsuario">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="textotitulos">Àrea:</span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlArea">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="textotitulos">Status:</span>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlStatus">
                                    <asp:ListItem Value="A" Text="ATIVO"></asp:ListItem>
                                    <asp:ListItem Value="I" Text="INATIVO"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:Button runat="server" ID="btnCancelarCadUsu" Text="Cancelar" OnClick="btnCancelarCadUsu_Click" />
                        <asp:Button runat="server" ID="btnSalvarUsuario" ValidationGroup="Inserir" Text="Salvar"
                            OnClick="btnSalvarUsuario_Click" />
                    </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        var $dvDetCadUsu = $('#dvDetCadUsu').jqm({ modal: true, toTop: true, trigger: false });
    </script>
</asp:Content>
