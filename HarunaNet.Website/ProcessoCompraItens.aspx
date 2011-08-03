<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="ProcessoCompraItens.aspx.cs" Inherits="HarunaNet.SisWeb.ProcessoCompraItens"
    Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
         <br />
        <br />
            <div id="resultado">
                <div class="result_pesq">
                    <h2>
                        Lista de Compras por Categoria</h2>
                    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="" Visible="false"></asp:Label>
                    <br />
                    <br />
                    <asp:GridView runat="server" ID="gvListaPCompraItens" AutoGenerateColumns="false"
                        OnRowDataBound="gvListaPCompraItens_RowDataBound" Width="100%" SkinID="HarunaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Num. Pedido">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodProcesso" runat="server" Visible="false" Text='<%# Eval("CodProcesso") %>' />
                                    <asp:Label ID="llbPedItemID" runat="server" Visible="false" Text='<%# Eval("CodItem") %>' />
                                    <asp:Label ID="lblCategoria" runat="server"   Text='<%# Eval("CodPedido") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle Width="8%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NomeProjeto" HeaderText="Projeto">
                                <ItemStyle HorizontalAlign="Center" Width=" 10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Àrea">
                                <ItemTemplate>
                                    <asp:Label ID="lblArea" runat="server" Visible="true" Text='<%# Eval("Area.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle Width="10%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NomeUsuario" HeaderText="Usuário" ItemStyle-Width="25%">
                                <ItemStyle Width="15%" />
                            </asp:BoundField>

                             <asp:TemplateField HeaderText="Item">
                                <ItemTemplate>
                                    <asp:Label ID="lblNomeItem" runat="server" Text='<%# Eval("Outros")==""?Eval("NomeItem"):Eval("NomeItem") + " - " + Eval("Outros")%>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle Width="40%" />
                            </asp:TemplateField>

                           
                            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade">
                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar" ImageUrl="~/library/img/ic_editar.gif"
                                        CommandArgument='<%# Eval("CodItem") %>' OnClick="btnEditar_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblMensagem" CssClass="mensagem-vermelho" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:Button ID="btn_Fechar" runat="server" Text="Fechar Processo de Compra" Width="100px"
                        OnClick="btn_Fechar_Click" />
                    &nbsp;<asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" OnClick="btn_Voltar_Click" />
                </div>
            </div>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--  --%>
  <%--  <div id="dvEditarPedido"  class="jqmWindow">
        <asp:UpdatePanel ID="UpdEditarPedido" runat="server">
            <ContentTemplate>

            <asp:ValidationSummary ID="vldSummary" runat="server" DisplayMode="List" 
                    ShowMessageBox="True" ShowSummary="False" Visible="False" />
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
                            <asp:DropDownList runat="server"
                                ID="ddl_Status"  />
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
                                <asp:Label ID="Label11" runat="server" Text="Nota Fiscal"></asp:Label>
                            </span>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txt_NotaFiscal" runat="server" CssClass="textboxes"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <span class="textotitulos">
                                <asp:Label ID="Label13" runat="server" Text="Nota Série"></asp:Label>
                            </span>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txt_NFSerie" runat="server" CssClass="textboxes"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <span class="textotitulos">
                                <asp:Label ID="Label14" runat="server" Text="Data Emissão NF"></asp:Label>
                            </span>
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="dt_EmissaoNF" runat="server" datatype="date" MaxLength="10" CssClass="textboxes"></asp:TextBox>
                        </td>
                    </tr>
                    
                </table>
                <div>
                    <br />
                    <asp:Button runat="server" ID="btnSalvarItem" Text="Salvar" 
                        OnClick="btnSalvarItem_Click" />
                    &nbsp;<asp:Button runat="server" ID="btnCancelarCadUsu" Text="Cancelar" OnClick="btnCancelarCadUsu_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>--%>
   <%-- <script type="text/javascript">
        var $dvEditarPedido = $('#dvEditarPedido').jqm({ modal: true, toTop: true, trigger: false });
    </script>--%>
</asp:Content>
