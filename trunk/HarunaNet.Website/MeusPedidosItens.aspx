<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="MeusPedidosItens.aspx.cs" Inherits="HarunaNet.SisWeb.MeusPedidosItens"
    Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <br />
            <br />
            <div id="resultado">
                <div class="result_pesq">
                    <h2>
                        <asp:Label runat="server" ID="lblTitulo" Text=""></asp:Label></h2>
                    <asp:GridView ID="gvListaPed" runat="server" AutoGenerateColumns="False" Width="100%" 
                        CssClass="gridheader" AllowSorting="True" AllowPaging="true" EnableModelValidation="True"
                        OnRowDataBound="gvListaPed_RowDataBound" SkinID="HarunaGrid" 
                        onpageindexchanging="gvListaPed_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Projeto">
                                <ItemTemplate>
                                    <asp:Label ID="lblPedItemID" runat="server" Visible="false" Text='<%# Bind("PedidoItensID") %>' />
                                    <asp:Label ID="lblProjNome" runat="server" Text='<%# Bind("Projeto.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjCatNome" runat="server" Text='<%# Bind("Item.Categoria.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Área" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblArea" runat="server" Text='<%# Bind("Area.Nome") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item" ItemStyle-Width="25%">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjItemNome" runat="server" Text='<%# Eval("Outros")==""?Eval("Item.Nome"):Eval("Item.Nome") + " - " + Eval("Outros")%>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pedido">
                                <ItemTemplate>
                                    <asp:Label ID="lblDtPedido" runat="server" Text='<%# Convert.ToDateTime(Eval("Data_Pedido")) == DateTime.MinValue ? "" : Eval("Data_Pedido", "{0:dd/MM/yyyy}") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Compra">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompra" runat="server" Text='<%# Convert.ToDateTime(Eval("Data_EntradaFornecedor")) == DateTime.MinValue ? "" : Eval("Data_EntradaFornecedor", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Prev. Entrega">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntrega" runat="server" Text='<%# Convert.ToDateTime(Eval("Data_PrevisaoEntrega")) == DateTime.MinValue ? "" : Eval("Data_PrevisaoEntrega", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusItem" runat="server" Text='<%# Eval("Status") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qtd Pedida" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjQtd" runat="server" Text='<%# Bind("Quantidade") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Qtd Comprada" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Label ID="lblProjQtdcomprada" runat="server" Text='<%# Convert.ToInt32(Eval("QuantidadeComprada")) > 0 ?Eval("QuantidadeComprada"):""  %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblMensagem" CssClass="mensagem-vermelho" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" OnClick="btn_Voltar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
