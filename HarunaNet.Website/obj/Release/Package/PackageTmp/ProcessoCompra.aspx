<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="ProcessoCompra.aspx.cs" Inherits="HarunaNet.SisWeb.ProcessoCompraWeb"
    Theme="haruna" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
    <br />
    <br />
    <div id="resultado">
        <div class="result_pesq">
            <h2>
                Lista dos Processos de Compras Abertas</h2>
            <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="" Visible="false"></asp:Label>
            <br />
            <asp:GridView ID="gvListaCompra" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="gridheader" DataKeyNames="CodProcessoCompra" AllowSorting="True" AllowPaging="True"
                OnRowDataBound="gvListaCompra_RowDataBound" OnRowCommand="gvListaCompra_RowCommand"
                OnSorting="gvListaCompra_Sorting" OnPageIndexChanging="gvListaCompra_PageIndexChanging"
                SkinID="HarunaGrid" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Código" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblCodProcesso" runat="server" Text='<%# Bind("CodProcessoCompra") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        <ItemStyle Width="10%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data do Processo de Compra" ItemStyle-Width="75%">
                        <ItemTemplate>
                            <asp:Label ID="llbPCompraID" runat="server" Visible="false" Text='<%# Bind("CodProcessoCompra") %>' />
                            <asp:HyperLink ID="hlk_DataProcesso" runat="server" NavigateUrl='<%# "~/ProcessoCompraItens.aspx?cdp=" + DataBinder.Eval(Container.DataItem, "CodProcessoCompra") %>'>
                                <asp:Label ID="lblDataProcesso" runat="server" Text='<%# Bind("DataProcesso") %>' /></asp:HyperLink></ItemTemplate><HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        <ItemStyle Width="25%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Categoria" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Label ID="llbNomeCategoria" runat="server" Visible="true" Text='<%# Bind("NomeCategoria") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="25%" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Pedidos" ShowHeader="False">
                        <ItemTemplate>
                            <asp:Label ID="llbPedidos" runat="server" Visible="true" Text='<%# Bind("Pedidos") %>' />
                        </ItemTemplate>
                        <ItemStyle Width="25%" />
                    </asp:TemplateField>
                    
                   
                    <asp:TemplateField HeaderText="ReGerar Planilha" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnGerarPlanilha" runat="server" ImageUrl="~/library/img/ic_export_excel.png"
                                OnClick="btnGerarPlanilha_Click" /></ItemTemplate>
                        <HeaderStyle HorizontalAlign="left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMensagem" CssClass="mensagem-vermelho" runat="server" Text="" Visible="false"></asp:Label></div></div><%-- </ContentTemplate></asp:UpdatePanel>--%></asp:Content>