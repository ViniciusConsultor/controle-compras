<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="PedidosCadastro.aspx.cs" Inherits="HarunaNet.SisWeb.PedidosCadastro"
    Theme="haruna" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdDetCadForn" runat="server">
        <ContentTemplate>
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Pedidos</h2>
                    <table border="0" cellpadding="0" cellspacing="1" width="340">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblMensagem" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label CssClass="labeltitulo" ID="lblProjeto" runat="server" Text="Projeto:"></asp:Label>
                                <br />
                                <asp:RangeValidator ID="rgvProjeto" runat="server" ControlToValidate="ddlProjeto"
                                    MaximumValue="32768" MinimumValue="1" Type="Integer" CssClass="mensagem-vermelho"
                                    ValidationGroup="Salvar" ForeColor="" Display="Dynamic" SetFocusOnError="True">Escolha um Projeto!</asp:RangeValidator>
                                <asp:Label ID="lblErroProjeto" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlProjeto">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr runat="server" id="trArea" visible="false">
                            <td align="left" colspan="2">
                                <asp:Label CssClass="labeltitulo" ID="lblArea" runat="server" Text="Area:"></asp:Label>
                                <br />
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddlArea"
                                    MaximumValue="32768" MinimumValue="1" Type="Integer" CssClass="mensagem-vermelho"
                                    ValidationGroup="Salvar" ForeColor="" Display="Dynamic" SetFocusOnError="True">Escolha Area!</asp:RangeValidator>
                                <asp:Label ID="Label2" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlArea">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label CssClass="labeltitulo" ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
                                <br />
                                <asp:RangeValidator ID="rgvCategoria" runat="server" ControlToValidate="ddlCategoria"
                                    MaximumValue="32768" MinimumValue="1" Type="Integer" CssClass="mensagem-vermelho"
                                    ValidationGroup="Salvar" ForeColor="" Display="Dynamic" SetFocusOnError="True">Escolha uma Categoria!</asp:RangeValidator>
                                <asp:Label ID="lblErroCategoria" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlCategoria" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 300px" colspan="2">
                                <asp:Label CssClass="labeltitulo" ID="lbl_Item" runat="server" Text="Item:"></asp:Label>
                                <br />
                                <asp:Label ID="lblErroItem" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                                <asp:DropDownList Visible="true" runat="server" ID="ddlItem" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlItem_SelectedIndexChanged" Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <td colspan="2">
                            <asp:Label CssClass="labeltitulo" ID="lblOutros" runat="server" Text="Outros:" Visible="false"></asp:Label>
                            <asp:TextBox MaxLength="2000" TextMode="MultiLine" Width="300px" runat="server" ID="txtOutros"
                                Visible="false" Rows="10"></asp:TextBox>
                        </td>
                        </tr>
                        <tr runat="server" id="trdesc" visible="false">
                            <td class="gridnormal">
                                <asp:Label CssClass="labeltitulo" ID="lblDescricao" runat="server" Text="Descrição:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox MaxLength="2000" TextMode="MultiLine" Width="300px" runat="server" ID="txtDesc"
                                    CssClass="textboxes" Rows="10"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RequiredFieldValidator ID="rfvQuantidade" runat="server" ControlToValidate="txtQuantidade"
                                    CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Preencha a quantidade desejada!"
                                    ValidationGroup="Salvar" ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblErroQuantidade" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100px">
                                <asp:Label CssClass="labeltitulo" ID="lblQuantidade" runat="server" Text="Quantidade:"></asp:Label>
                                <br>
                                <asp:TextBox MaxLength="4" CssClass="numero" datatype="integer" runat="server" ID="txtQuantidade"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:ImageButton ImageUrl="~/library/img/btnAdicionar.png" ID="btnAddItem" runat="server"
                                    OnClick="btnAddItem_Click" ValidationGroup="Salvar" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="resultado">
                <div class="result_pesq">
                    <asp:GridView runat="server" ID="gvPedItens" AutoGenerateColumns="False" Width="100%"
                        EnableModelValidation="True" OnRowDataBound="gvPedItens_RowDataBound" DataKeyNames="PedidoItensID"
                        SkinID="HarunaGrid">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="180px" HeaderText="Projeto">
                                <ItemTemplate>
                                    <asp:Label ID="lblPedItemID" runat="server" Visible="false" Text='<%# Bind("PedidoItensID") %>' />
                                    <asp:Label ID="lblProjNome" runat="server" Text='<%# Bind("Projeto.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="180px" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="180px" HeaderText="Categoria">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjCatNome" runat="server" Text='<%# Bind("Item.Categoria.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="180px" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="300px" HeaderText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjItemNome" runat="server" Text='<%# Eval("Outros")==""?Eval("Item.Nome"):Eval("Item.Nome") + " - " + Eval("Outros")%>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="300px" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Quantidade">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjQtd" runat="server" Text='<%# Bind("Quantidade") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="50px" HeaderText="Excluir" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/library/imagens/btn_excluir.png"
                                        OnClientClick="return confirm('Deseja realmente apagar?');" OnClick="btnExcluir_Click" />
                                </ItemTemplate>
                                <ItemStyle BackColor="White" HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <br />
                    <div>
                        <asp:ImageButton ID="btnSalvar" runat="server" ImageUrl="~/library/img/btnSalvar.png"
                            OnClick="btnSalvar_Click" Visible="false" />&nbsp;
                        <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/library/img/btnCancelar.png"
                            OnClick="btnCancelar_Click" Visible="false" />
                    </div>
                    <br />
                    <asp:Label ID="lblenvioemail" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <script language="javascript" type="text/javascript">
        function confirmaAtualizacao(nomeOnda) {
            var msg = '';
            msg = 'Deseja realmente excluir ' + nomeOnda + '?';

            if (confirm(msg)) {
                return true;
            }
            else {
                return false;
            }
        }

        function ExibirPesquisa() {
            var txtLink = document.getElementById('lnkExibirPesquisa').innerHTML;

            if (document.getElementById('tabPesquisa').style.display == 'none') {
                document.getElementById('tabPesquisa').style.display = '';
                document.getElementById('lnkExibirPesquisa').innerHTML = txtLink.replace('Exibir', 'Ocultar');
                document.getElementById('imgExibirPesquisa').src = "../library/img/ic_ocultar.png";
                document.getElementById('imgExibirPesquisa').alt = "Ocultar Campos de Pesquisa";
            }
            else {
                document.getElementById('tabPesquisa').style.display = 'none';
                document.getElementById('lnkExibirPesquisa').innerHTML = txtLink.replace('Ocultar', 'Exibir');
                document.getElementById('imgExibirPesquisa').src = "../library/img/ic_exibir.png";
                document.getElementById('imgExibirPesquisa').alt = "Exibir Campos de Pesquisa";
            }
        }

    </script>--%>
</asp:Content>
