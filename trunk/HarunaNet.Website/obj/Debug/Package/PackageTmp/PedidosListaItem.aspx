<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="PedidosListaItem.aspx.cs" Inherits="HarunaNet.SisWeb.PedidosListaItem"
    Theme="haruna" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="resultado">
                <div class="result_pesq">
                    <h2>
                        Lista de Compras por Categoria</h2>
                    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="" Visible="false"></asp:Label>
                    <asp:GridView ID="gvListaPed" runat="server" AutoGenerateColumns="False" Width="100%"
                        CssClass="gridheader" AllowSorting="true" AllowPaging="true" SkinID="HarunaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Categoria" ItemStyle-Width="65%">
                                <ItemTemplate>
                                    <asp:Label ID="llbCategoriaID" runat="server" Visible="false" Text='<%# Bind("ITEM.ITEMID") %>' />
                                    <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Outros")==""?Eval("Item.Nome"):Eval("Item.Nome") + " - " + Eval("Outros") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Quantidade" HeaderText="Total de itens">
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CodPedidos" HeaderText="Pedidos">
                                <ItemStyle HorizontalAlign="Center" Width="20%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblMensagem" CssClass="mensagem-vermelho" runat="server" Text="" Visible="false"></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:ImageButton ID="btnExportar" runat="server" ImageUrl="~/library/img/ic_excel.gif"
        OnClick="btnExportar_Click" />
    <br />
    <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" OnClick="btn_Voltar_Click" />
</asp:Content>
