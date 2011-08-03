<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="EditProcessoCompraItem.aspx.cs" Inherits="HarunaNet.SisWeb.EditProcessoCompraItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdEditarPedido" runat="server">
        <ContentTemplate>
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Atualiza Item do Processo</h2>
                    <asp:ValidationSummary ID="vldSummary" runat="server" DisplayMode="List" ShowMessageBox="True"
                        ShowSummary="False" Visible="False" />
                    <asp:CustomValidator ID="vldcusMSG_RET" runat="server" ErrorMessage=""></asp:CustomValidator>
                    <table>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label1" runat="server" Text="Num. Pedido"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="lbl_NumPedido" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label2" runat="server" Text="Projeto"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                &nbsp;<span class="textotitulos"><asp:Label ID="lbl_Projeto" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label3" runat="server" Text="Usuário"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="lbl_NomeUsuario" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label4" runat="server" Text="Item"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                &nbsp;<span class="textotitulos"><asp:Label ID="lbl_Item" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label5" runat="server" Text="Qtd. Pedida"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="lbl_Quantidade" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label12" runat="server" Text="Status"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList runat="server" ID="ddl_Status" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label15" runat="server" Text="Data da Compra"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="dt_DataCompra" runat="server" datatype="date" MaxLength="10" CssClass="textboxes"></asp:TextBox>
                                <asp:Label ID="lblErroDataCompra" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label6" runat="server" Text="Qtd. Comprada"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txt_QtdComprada" runat="server" datatype="integer" MaxLength="4"
                                    CssClass="textboxes"></asp:TextBox>
                                <asp:Label ID="lblErroQtdComprada" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label7" runat="server" Text="Valor Unitário"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txt_Valor" runat="server" datatype="double" CssClass="textboxes"></asp:TextBox>
                                <asp:Label ID="lblErroValor" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblErroPrevisaoEntrega" runat="server" CssClass="mensagem-vermelho"
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label8" runat="server" Text="Data Previsão Entrega"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="dt_PrevisaoEntrega" runat="server" datatype="date" MaxLength="10"
                                    CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos"></span>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblErroDTEntrega" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label9" runat="server" Text="Data da Entrega"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="dt_Entrega" runat="server" datatype="date" MaxLength="10" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblErroFornecedor" runat="server" CssClass="mensagem-vermelho" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label10" runat="server" Text="Fornecedor"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList runat="server" ID="ddl_Fornecedor" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label16" runat="server" Text="Documento Fiscal"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="ddl_TpDocumento" runat="server" DataTextField="Descricao" DataValueField="Codigo" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label11" runat="server" Text="Numero"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txt_NotaFiscal" runat="server" CssClass="textboxes" datatype="integer"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label13" runat="server" Text="Série"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="txt_NFSerie" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <span class="textotitulos">
                                    <asp:Label ID="Label14" runat="server" Text="Data Emissão"></asp:Label>
                                </span>
                            </td>
                            <td style="text-align: left">
                                <asp:TextBox ID="dt_EmissaoNF" runat="server" datatype="date" MaxLength="10" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <br />
                        <asp:Button runat="server" ID="btnSalvarItem" Text="Salvar" OnClick="btnSalvarItem_Click" />
                        &nbsp;<asp:Button runat="server" ID="btnCancelarCadUsu" Text="Cancelar" OnClick="btnCancelarCadUsu_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="dvDescCancelar" class="jqmWindow">
        <asp:UpdatePanel ID="UpdDetCadUsu" runat="server">
            <ContentTemplate>
                <div class="divtitulo">
                    <span>Motivo Cancelamento</span>
                </div>
                <table  Width="100%">
                    <tr>
                        <td align="left">
                            <asp:Label ID="lblErroDescMotivoCancelamento" runat="server" CssClass="mensagem-vermelho"
                                Visible="False" />
                            <asp:TextBox runat="server" ID="txt_DescMotivoCancelamento" Rows="15" MaxLength="1000"
                                TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:Button runat="server" ID="btnCancelarDesc" Text="Cancelar" OnClick="btnCancelarDesc_Click" />
                    <asp:Button runat="server" ID="btnSalvarDesc" ValidationGroup="Inserir" Text="Salvar"
                        OnClick="btnSalvarDesc_Click" />
                </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        var $dvDescCancelar = $('#dvDescCancelar').jqm({ modal: true, toTop: true, trigger: false });
    </script>
</asp:Content>
