<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="meuspedidos.aspx.cs" Inherits="HarunaNet.SisWeb.meuspedidos" Theme="haruna"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <br />
        <br />
            <div id="resultado">
                <div class="result_pesq">
                    <h2>
                        Meus Pedidos</h2>
                    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:GridView ID="gvListaMeusPed" runat="server" AutoGenerateColumns="False" Width="100%"
                        EmptyDataText="Não há pedidos realizados!" CssClass="gridheader" DataKeyNames="PedidoID"
                        AllowSorting="True" OnRowDataBound="gvListaMeusPed_RowDataBound" OnRowCommand="gvListaMeusPed_RowCommand"
                        OnSorting="gvListaMeusPed_Sorting" OnPageIndexChanging="gvListaMeusPed_PageIndexChanging"
                        AllowPaging="true" EnableModelValidation="True" SkinID="HarunaGrid">
                        <Columns>
                            <asp:BoundField DataField="NomeUsuario" HeaderText="Usuário">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="left" Width="250px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PedidoID" HeaderText="Número">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DataPedido" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="left" Width="270px" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" Width="80px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandName="Editar"
                                        ImageUrl="~/library/imagens/btn_detalhes.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblMensagem" CssClass="mensagem-vermelho" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:Button ID="btn_Voltar" Visible="false" runat="server" Text="Voltar" Width="100px"
                        OnClick="btn_Voltar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
