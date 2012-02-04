<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="PedidosOrcamentoLista.aspx.cs" Inherits="HarunaNet.SisWeb.PedidosOrcamentoLista"
    Theme="haruna" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <br />
            <br />
            <div id="resultado">
                <div class="result_pesq">
                    <h2>
                        Lista de Pedidos Orçamentos</h2>
                    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:GridView ID="gvListaPed" runat="server" AutoGenerateColumns="False" Width="100%"
                        CssClass="gridheader" DataKeyNames="Cod_PedidosOrcamentos" AllowSorting="true"
                        AllowPaging="true" OnRowDataBound="grdOnda_RowDataBound" OnRowCommand="grdOnda_RowCommand"
                        OnPageIndexChanging="gvListaPed_PageIndexChanging" SkinID="HarunaGrid">
                        <Columns>
                            <asp:BoundField HeaderText="Cod." ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"
                                DataField="COD_PEDIDOSORCAMENTOS" HeaderStyle-HorizontalAlign="Left">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Item" ItemStyle-Width="80%">
                                <ItemTemplate>
                                    <%--<asp:HyperLink ID="hlk_Categoria" runat="server" NavigateUrl='<%# "~/PedidosListaItem.aspx?categoriaid=" + DataBinder.Eval(Container.DataItem, "CategoriaID") +"&CC=" + DataBinder.Eval(Container.DataItem, "CentroDeCustoID") %>'>--%>
                                    <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Outros")==""?Eval("Item.Nome"):Eval("Item.Nome") + " - " + Eval("Outros") %>' />
                                    <%--</asp:HyperLink>--%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle Width="80%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cotar" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:Button ID="btnCotar" runat="server" Font-Size="X-Small" Text="Cotar" CausesValidation="false"
                                        CommandName="Cotar" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
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
