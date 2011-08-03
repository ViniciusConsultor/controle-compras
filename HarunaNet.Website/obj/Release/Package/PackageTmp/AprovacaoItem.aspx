<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="AprovacaoItem.aspx.cs" Inherits="HarunaNet.SisWeb.AprovacaoItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divtitulo">
        <span>Lista de itens para Aprovação</span>
    </div>
    <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="" Visible="false"></asp:Label>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gvListaAprov" runat="server" AutoGenerateColumns="False" Width="100%"
                CssClass="gridheader" DataKeyNames="CodigoItem" AllowSorting="True" AllowPaging="True"
                OnRowDataBound="gvListaAprov_RowDataBound" OnRowCommand="gvListaAprov_RowCommand"
                OnSorting="gvListaAprov_Sorting" OnPageIndexChanging="gvListaAprov_PageIndexChanging"
                EnableModelValidation="True">
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridnormal" />
                <Columns>
                    <asp:BoundField DataField="CodigoPedido" ItemStyle-Width="80px" HeaderText="Nº do Pedido">
                        <ItemStyle Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DataPedido" ItemStyle-Width="100px" HeaderText="Data do Pedido">
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Item" ItemStyle-Width="130px" HeaderText="Item">
                        <ItemStyle Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descrição" HeaderText="Descrição" />
                    <asp:BoundField DataField="NomeSolicitante" ItemStyle-Width="250px" HeaderText="Nome Solicitante">
                        <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="140px">
                        <ItemTemplate>
                            <asp:ImageButton CommandArgument='<%# Eval("CodigoItem") %>' ID="btnAprovar" runat="server"
                                OnClick="btnAprovar_Click" ImageUrl="~/library/img/ic_aprovar.png" />
                            <asp:ImageButton CommandArgument='<%# Eval("CodigoItem") %>' ID="btnReprovar" runat="server"
                                OnClick="btnReprovar_Click" ImageUrl="~/library/img/ic_reprovar.png" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="140px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblMensagem" CssClass="mensagem-vermelho" runat="server" Text="" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="btn_Voltar" runat="server" Text="Voltar" Width="100px" OnClick="btn_Voltar_Click" />
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
