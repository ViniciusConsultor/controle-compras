<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="PedidosLista.aspx.cs" Inherits="HarunaNet.SisWeb.PedidosLista" Theme="haruna"%>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
         <br />
        <br />
            <div id="resultado">
                <div class="result_pesq">
                    <h2>
                        Lista de Compras</h2>
                    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:GridView ID="gvListaPed" runat="server" AutoGenerateColumns="False" Width="100%"
                        CssClass="gridheader" DataKeyNames="CategoriaID" AllowSorting="true" AllowPaging="true"
                        OnRowDataBound="grdOnda_RowDataBound" OnRowCommand="grdOnda_RowCommand" OnSorting="grdOnda_Sorting"
                        OnPageIndexChanging="gvListaPed_PageIndexChanging" SkinID="HarunaGrid">
                        <Columns>
                            <asp:TemplateField HeaderText="Categoria" ItemStyle-Width="30%">
                                <ItemTemplate>
                                    <asp:Label ID="llbCategoriaID" runat="server" Visible="false" Text='<%# Bind("CategoriaID") %>' />
                                    <asp:HyperLink ID="hlk_Categoria" runat="server" NavigateUrl='<%# "~/PedidosListaItem.aspx?categoriaid=" + DataBinder.Eval(Container.DataItem, "CategoriaID") +"&CC=" + DataBinder.Eval(Container.DataItem, "CentroDeCustoID") %>'>
                                        <asp:Label ID="lblCategoria" runat="server" Text='<%# Bind("Categoria") %>' /></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Centro de Custo" ItemStyle-Width="60%" DataField="CENTRODECUSTO"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Total" HeaderText="Total de itens">
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblMensagem" CssClass="mensagem-vermelho" runat="server" Text="" Visible="false"></asp:Label>
                    <br />
                    <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" OnClick="btn_Voltar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script language="javascript" type="text/javascript">
        function confirmaAtualizacao(nomeOnda) {
            var msg = '';
            msg = 'Deseja realmente excluir a onda ' + nomeOnda + '?';

            if (confirm(msg)) {
                return true;
            }
            else {
                return false;
            }
        }

        function ExibirPesquisa() {
            var txtLink = document.getElementById('lnkExibirPesquisa').innerHTML;

            if (document.getElementById('tabPesquisa').style.display == 'none') {
                document.getElementById('tabPesquisa').style.display = '';
                document.getElementById('lnkExibirPesquisa').innerHTML = txtLink.replace('Exibir', 'Ocultar');
                document.getElementById('imgExibirPesquisa').src = "../library/img/ic_ocultar.png";
                document.getElementById('imgExibirPesquisa').alt = "Ocultar Campos de Pesquisa";
            }
            else {
                document.getElementById('tabPesquisa').style.display = 'none';
                document.getElementById('lnkExibirPesquisa').innerHTML = txtLink.replace('Ocultar', 'Exibir');
                document.getElementById('imgExibirPesquisa').src = "../library/img/ic_exibir.png";
                document.getElementById('imgExibirPesquisa').alt = "Exibir Campos de Pesquisa";
            }
        }
    </script>
</asp:Content>
