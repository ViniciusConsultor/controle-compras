<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="PedidoConfirmacao.aspx.cs" Inherits="HarunaNet.SisWeb.PedidoConfirmacao"
    Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="conteudo">
                <br />
                <div class="cont_pesq">
                    <asp:Label ID="lblTexto" runat="server" Text="Anote o número do pedido " 
                        ForeColor="#DA251D"></asp:Label>
                    <br />
                    <asp:Label ID="lblNumero" runat="server" Font-Bold="True" Font-Size="Larger" 
                        ForeColor="#DA251D"></asp:Label>
                    <br />
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </div>
                <br />
            </div>
            <div id="resultado">
                <div class="result_pesq">
                    <asp:GridView runat="server" ID="gvPedItens" AutoGenerateColumns="False" Width="100%"
                        SkinID="HarunaGrid" EnableModelValidation="True" DataKeyNames="PedidoItensID">
                        <Columns>
                            <asp:TemplateField HeaderText="Projeto" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lblPedItemID" runat="server" Visible="false" Text='<%# Bind("PedidoItensID") %>' />
                                    <asp:Label ID="lblProjNome" runat="server" Text='<%# Bind("Projeto.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjCatNome" runat="server" Text='<%# Bind("Item.Categoria.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item" ItemStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjItemNome" runat="server" Text='<%# Eval("Outros")==""?Eval("Item.Nome"):Eval("Item.Nome") + " - " + Eval("Outros")%>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantidade" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjQtd" runat="server" Text='<%# Bind("Quantidade") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" 
                        OnClick="btn_Voltar_Click" Visible="False" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
