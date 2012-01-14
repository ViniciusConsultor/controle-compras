<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="Cad_Areas.aspx.cs" Inherits="HarunaNet.SisWeb.Cad_Areas" Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdCadItens">
        <ContentTemplate>
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Cadastro de Áreas - Pesquisa</h2>
                    <table border="0" cellpadding="0" cellspacing="1" width="100%">
                        <tr>
                            <td class="gridnormal" align="left" style="width: 150px;">
                                <asp:Label CssClass="label" ID="lblCategoria" runat="server" Text="Área:"></asp:Label>
                            </td>
                            <td align="left" style="width: 300px;">
                                 <asp:TextBox runat="server" ID="txtArea" CssClass="textboxes" TextMode="SingleLine" />
                            </td>
                            <td align="left" style="width: 50%;">
                                <asp:ImageButton ID="btnPesquisarItem" runat="server" ImageUrl="~/library/img/ic_pesquisar.png"
                                    ToolTip="Pesquisar Itens" OnClick="btnPesquisarItem_Click" />
                                &nbsp;
                                <asp:ImageButton ID="btnInserirItem" runat="server" ImageUrl="~/library/img/ic_adicionar.png"
                                    ToolTip="Inserir Novo Item" OnClick="btnInserirItem_Click" />
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
                    <asp:GridView runat="server" ID="gvCadAreas" AutoGenerateColumns="false" Width="100%"
                        SkinID="HarunaGrid" onrowdatabound="gvCadAreas_RowDataBound" DataKeyNames="Id">
                        <HeaderStyle CssClass="gridheader" />
                        <RowStyle CssClass="gridnormal" />
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="Id" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Descrição" DataField="Nome" HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditarItem" runat="server" ToolTip="Editar Item!" 
                                        ImageUrl="~/library/img/ic_editar.gif" onclick="btnEditarItem_Click" />
                                    <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/library/imagens/btn_excluir.png"
                                        OnClientClick="return confirm('Deseja realmente apagar?');" OnClick="btnExcluir_Click" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
