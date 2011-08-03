<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="Cad_Itens.aspx.cs" Inherits="HarunaNet.SisWeb.Cad_Itens" Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="UpdCadItens">
        <ContentTemplate>
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Cadastro de Itens - Pesquisa</h2>
                    <table border="0" cellpadding="0" cellspacing="1" width="100%">
                        <tr>
                            <td class="gridnormal" align="left" style="width: 150px;">
                                <asp:Label CssClass="label" ID="lblCategoria" runat="server" Text="Categoria:"></asp:Label>
                            </td>
                            <td align="left" style="width: 300px;">
                                <asp:DropDownList runat="server" ID="ddlCategoria" />
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
                    <asp:GridView runat="server" ID="gvCaditens" AutoGenerateColumns="false" Width="100%"
                        SkinID="HarunaGrid" onrowdatabound="gvCaditens_RowDataBound">
                        <HeaderStyle CssClass="gridheader" />
                        <RowStyle CssClass="gridnormal" />
                        <Columns>
                            <asp:BoundField HeaderText="Código" DataField="ItemID" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
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

    <div id="dvDetCadItens" class="jqmWindow">
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <div class="divtitulo">
                    <asp:Label runat="server" ID="lblTituilo" Text="Cadastro de Itens" CssClass="labeltitulo"></asp:Label>
                </div>
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <td class="gridnormal" align="left" style="width: 150px;">
                            <asp:Label CssClass="label" ID="Label1" runat="server" Text="Categoria:"></asp:Label>
                        </td>
                        <td align="left" style="width: 300px;">
                            <asp:Label CssClass="labelDesc" ID="lbl_CategoriaDesc" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="gridnormal" align="left" style="width: 150px;">
                            <asp:Label CssClass="label" ID="lblDescicao" runat="server" Text="Descicao:"></asp:Label>
                        </td>
                        <td align="left" style="width: 300px;">
                            <asp:TextBox runat="server" ID="tbxDescricaoItem" CssClass="textboxes" TextMode="MultiLine"
                                Rows="10" Height="100" Width="90%"></asp:TextBox><br />
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:Button runat="server" ID="btnCancelarCadPerfil" Text="Cancelar" 
                        onclick="btnCancelarCadItem_Click"  />
                    <asp:Button runat="server" ID="btnSalvarPerfil" Text="Salvar" 
                        onclick="btnSalvarItem_Click" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        var $dvDetCadItens = $('#dvDetCadItens').jqm({ modal: true, toTop: true, trigger: false });
    </script>
</asp:Content>
