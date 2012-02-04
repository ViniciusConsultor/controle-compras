<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="PedidosOrcamentoEdit.aspx.cs" Inherits="HarunaNet.SisWeb.PedidosOrcamentoEdit"
    Theme="haruna" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="userControls/ucDataField.ascx" TagName="ucDataField" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdfOrcamento" runat="server" />
            <br />
            <asp:HiddenField ID="hdfIdFornecedor" runat="server" />
            <asp:ValidationSummary ID="vlSumary" runat="server" ShowMessageBox="True" ShowSummary="False" />
            <br />
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Lista de Pedidos de Orçamentos</h2>
                    <table border="0" cellpadding="1" cellspacing="2" width="100%">
                        <tr>
                            <td colspan="4">
                                <div class="titulo">
                                    <div style="margin: 2px  0 2px 10px;">
                                        Dados do Pedido</div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 20%;">
                                <asp:Label CssClass="labeltitulo" ID="lblProjeto" runat="server" Text="Projeto:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtProjeto" CssClass="textboxes" Width="200px" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 100px">
                                <asp:Label CssClass="labeltitulo" ID="lblArea" runat="server" Text="Area:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtArea" CssClass="textboxes" Width="200px" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label CssClass="labeltitulo" ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCategoria" CssClass="textboxes" Width="200px" runat="server"
                                    Enabled="False"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 100px">
                                <asp:Label ID="lbl_Item" runat="server" CssClass="labeltitulo" Text="Item:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtItem" CssClass="textboxes" Width="200px" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblQuantidade" runat="server" CssClass="labeltitulo" Text="Quantidade:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuantidade" CssClass="textboxes" onkeypress="return PontoeNumeros(event);"
                                    Width="200px" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="left" style="width: 100px">
                                <asp:Label CssClass="labeltitulo" ID="Label2" runat="server" Text="Unidade Medida:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUnidadeMedida" CssClass="textboxes" Width="200px" runat="server"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label CssClass="labeltitulo" ID="lblDtNecessidade" runat="server" Text="Data Necessidade:"></asp:Label>
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txtDataNecessidade" CssClass="textboxes" Width="200px" runat="server"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFinalidade" runat="server" CssClass="labeltitulo" Text="Finalidade:"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtFinalidade" CssClass="textboxes" Width="90%" TextMode="MultiLine"
                                    Rows="3" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div class="titulo">
                                    <div style="margin: 2px  0 2px 10px;">
                                        Dados do Orçamento</div>
                                </div>
                            </td>
                            <tr>
                                <td>
                                    Fornecedor:
                                </td>
                                <td colspan="2" valign="middle">
                                    <asp:TextBox ID="txtFornecedor" runat="server" CssClass="textboxes" datatype="integer"
                                        Width="97%"></asp:TextBox>
                                </td>
                                <td style="width: 100px;">
                                    <asp:Panel ID="pnPesquisa" runat="server">
                                        <img alt="Buscar Licitador" onclick="window.open('../Fornecedor.aspx?PopUp=PopUp' , 'PopUpLicitador', 'height=600 , width=800, scrollbars = yes' );"
                                            src="library/img/btnPesquisar.png" style="width: 20px; cursor: pointer;" />
                                        <img alt="Novo Licitador" onclick="window.open('../cadFornecedor.aspx?PopUp=PopUp' , 'PopUpLicitador', 'height=600 , width=800, scrollbars = yes' );"
                                            src="library/img/btnAdd.png" style="width: 20px; cursor: pointer;" />
                                    </asp:Panel>
                                </td>
                                <tr>
                                    <td>
                                        Valor:
                                    </td>
                                    <td style="width: 297px">
                                        <asp:TextBox ID="txtValor" onkeypress="return PontoeNumeros(event);" runat="server"
                                            CssClass="textboxes" datatype="integer" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Desconto:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDesconto" onkeypress="return PontoeNumeros(event);" runat="server"
                                            CssClass="textboxes" datatype="integer" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Cond. Pagamento:
                                    </td>
                                    <td style="width: 297px">
                                        <asp:TextBox ID="txtCondPagamento" runat="server" CssClass="textboxes" datatype="integer"
                                            Rows="3" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                    </td>
                                    <td>
                                        Data Entrega:
                                    </td>
                                    <td>
                                        <uc1:ucDataField ID="dtEntrega" runat="server" AutoPostBack="False" ExibeCalendario="True"
                                            Required="True" ValidationGroup="Salvar" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Observação:
                                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtObservacao" runat="server" CssClass="textboxes" datatype="integer"
                                            Rows="5" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                    </td>
                                </tr>
                    </table>
                    <div style="float: right; margin: 5px;">
                        <asp:ImageButton ID="imgSalvarCotacao" runat="server" ImageUrl="~/library/img/btnSalvar2.png"
                            ValidationGroup="Salvar" onclick="imgSalvarCotacao_Click" />
                        <asp:ImageButton ID="btnVoltar" runat="server" ImageUrl="~/library/img/btnVoltar.png"
                            OnClick="btnVoltar_Click" />
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
            </div>
            <div id="resultado">
                <div class="result_pesq">
                    <asp:Repeater ID="rptOrcamentos" runat="server">
                        <ItemTemplate>
                            <table width="95%">
                                <tr>
                                    <td bgcolor="Silver" width="25%">
                                        <strong>Fornecedor:</strong>
                                    </td>
                                    <td colspan="3" bgcolor="Silver">
                                        <strong>
                                            <asp:Literal ID="ltrFornecedor" runat="server" Text='<%# Eval("Fornecedor.NomeFantasia")%>'></asp:Literal>
                                        </strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="Silver" width="25%">
                                        <strong>Valor:</strong>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltrnome" runat="server" Text='<%# Eval("Valor")%>'></asp:Literal>
                                    </td>
                               
                                    <td bgcolor="Silver" width="25%">
                                        <strong>Desconto:</strong>
                                    </td>
                                    <td bgcolor="#E0E0E0">
                                        <asp:Literal ID="ltrcomentario" runat="server" Text='<%# Eval("Desconto")%>'></asp:Literal>
                                    </td>
                                </tr>

                                <tr>
                                    <td bgcolor="Silver" width="25%">
                                        <strong>Quantidade:</strong>
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server" Text=""></asp:Literal>
                                    </td>
                               
                                    <td bgcolor="Silver" width="25%">
                                        <strong>Data Entrega:</strong>
                                    </td>
                                    <td bgcolor="#E0E0E0">
                                        <asp:Literal ID="Literal2" runat="server" Text=""></asp:Literal>
                                    </td>
                                </tr>

                                <tr>
                                    <td bgcolor="Silver" width="25%">
                                        <strong>Quantidade:</strong>
                                    </td>
                                    <td colspan = "3">
                                        <asp:Literal ID="Literal3" runat="server" Text=""></asp:Literal>
                                    </td>
                               
                                   
                                </tr>
                               
                            </table>
                            <hr />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function SetFornecedor(IdFornecedor, NomeFantasia) {
            $("#<%=hdfIdFornecedor.ClientID%>").val(IdFornecedor);
            $("#<%=txtFornecedor.ClientID%>").val(IdFornecedor + ' - ' + NomeFantasia);
        }
    </script>
</asp:Content>
