<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridItensContrato.aspx.cs"
    Inherits="ES.Crm.Web.GridItensContrato" EnableViewState="true" Culture="pt-BR"
    UICulture="pt-BR" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="<%= ResolveUrl("~")%>Content/jquery-ui.css" type="text/css" rel="Stylesheet" />
    <link href="<%= ResolveUrl("~")%>Content/site.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="<%= ResolveUrl("~")%>Scripts/jquery-1.5.1.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~")%>Scripts/jquery.validate.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~")%>Scripts/jquery-ui.min.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~")%>Scripts/jquery.blockUI.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~")%>Scripts/default.js"></script>
    <script type="text/javascript" src="<%= ResolveUrl("~")%>Scripts/jquery.ui.datepicker-pt-BR.js"></script>
    <style type="text/css">
        .ui-widget
        {
            font-size: 11px !important;
        }
        #ui-datepicker-div
        {
            z-index: 9999;
        }
        .ui-datepicker
        {
            width: 17em;
            padding: .2em .2em 0;
            z-index: 9999;
        }
    </style>
    <script type="text/javascript" language="javascript">
       
        $(function () {
            $('#datePicker').datepicker({ inline: true });
        });
 
                                $(document).ready(function() {
           
            $("#tabs").tabs();
            $("#tabs > ul").tabs({ remote: true, cache: true });
            //$("div.ui-tabs-panel").html("");
 
                                                $("#divEditCustomer").dialog({
                                                                autoOpen: false,
                                                                modal: true,
                                                                minHeight: 20,
                                                                height: 'auto',
                                                                width: 'auto',
                                                                resizable: false,
                                                                open: function(event, ui) {
                                                                                $(this).parent().appendTo("#divEditCustomerDlgContainer");
                                                                },
                                                });
                                });
 
                                function closeDialog() {
                                                //Could cause an infinite loop because of "on close handling"
                                                $("#divEditCustomer").dialog('close');
                                }
                               
        //Função para atualizar os valores do peso
        function PreencherValoresTotal(Peso, desconto, total)
        {
           
//            var pesobruto = window.parent.document.getElementById("PedidoTemp_PesoBruto");
//            var pesoliquido = window.parent.document.getElementById("PedidoTemp_PesoLiquido");
//            var pesoembalagem = window.parent.document.getElementById("PedidoTemp_PesoEmbalagem");
//            var vlrDesconto = window.parent.document.getElementById("txtValorDescontoTotal");
//            var vlrTotal = window.parent.document.getElementById("txtTotalPedido");
 
//            var pesoembal = pesoembalagem.value.replace(",", ".");
 
//            if(pesoembalagem.value.length > 0)
//                pesobruto.value = parseFloat(Peso) + parseFloat(pesoembal);
//            else
//                pesobruto.value = parseFloat(Peso);
//           
//            pesoliquido.value = parseFloat(Peso);
//            pesoliquido.value = pesoliquido.value.replace(".", ",");
 
//            pesobruto.value = pesobruto.value.replace(".", ",");
 
//            vlrDesconto.value = parseFloat(desconto);
 
//            vlrTotal.value = parseFloat(total);
 
//            window.parent.document.getElementById("hdnTotalPedido").value = parseFloat(total);
//            window.parent.document.getElementById("hdnValorDescontoTotal").value = parseFloat(desconto);
        }
 
                                function openDialog(title, linkID) {
                                   
                                                var pos = $("#" + linkID).position();
                                                var top = 0; //pos.top;
                                                var left = 20;//pos.left + $("#" + linkID).width(); //+ 10;
                                               
                                                $("#divEditCustomer").dialog("option", "title", title);
                                                $("#divEditCustomer").dialog("option", "position", [left, top]);
                                               
                                                $("#divEditCustomer").dialog('open');
                                }
 
                                function openDialogAndBlock(title, linkID) {
                                                openDialog(title, linkID);
 
                                                //block it to clean out the data
                                                $("#divEditCustomer").block({
                                                                message: '<img src="<%=ResolveUrl("~") %>images/async.gif" />',
                                                                css: { border: '0px' },
                                                                fadeIn: 0,
                                                                //fadeOut: 0,
                                                                overlayCSS: { backgroundColor: '#ffffff', opacity: 1 }
                                                });
                                }
 
                                function unblockDialog() {
                                                $("#divEditCustomer").unblock();
                                }
 
                                function onTest() {
                                                $("#divEditCustomer").block({
                                                                message: '<h1>Processing</h1>',
                                                                css: { border: '3px solid #a00' },
                                                                overlayCSS: { backgroundColor: '#ffffff', opacity: 1 }
                                                });
                                }
 
        function BuscarProduto() {
            openModal('/Produto/BuscarProduto/', 900, 550);
        }
 
        function submitOnEnter(e) {
           
            var keycode;
           
            if (window.event)
                keycode = window.event.keyCode;
            else if (e)
                keycode = e.which;
           
            if (keycode == "13") {
                //document.getElementById('Button1').click();
                document.getElementById(e).focus();
            }
 
        }
 
    </script>
</head>
<body style="background-color: White;">
    <form id="form1" runat="server" onkeydown="submitOnEnter('btnSave');">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <div id="divEditCustomerDlgContainer">
        <div id="divEditCustomer" style="display: none">
            <%--<asp:UpdatePanel ID="upnlEditCustomer" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <ContentTemplate>--%>
                    <asp:PlaceHolder ID="phrEditCustomer" runat="server">
                        <div id="tabs">
                            <ul>
                                <li><a href="#fragment-1"><span>Dados Principais</span></a></li>
                                <li><a href="#fragment-2"><span>Pagamento</span></a></li>
                                <li><a href="#fragment-3"><span>Histórico</span></a></li>
                            </ul>
                            <div id="fragment-1">
                                <table cellpadding="3" cellspacing="1">
                                    <tr>
                                        <td>
                                            Código:
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="idProduto" Columns="40" MaxLength="50" runat="server" ReadOnly="true"
                                                onkeydown="submitOnEnter('btnSave');" /><a onclick="BuscarProduto();"><img src="images/lupa.gif"
                                                    alt="Buscar Produto" title="Buscar Produto" border="0" style="cursor: pointer;" /></a>
                                            <asp:RequiredFieldValidator ID="vtxtFirstName" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="idProduto" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Descrição:
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtDescricao" Columns="40" MaxLength="50" runat="server" ReadOnly="true"
                                                onkeydown="submitOnEnter('btnSave');" />
                                            <asp:RequiredFieldValidator ID="vtxtLastName" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="txtDescricao" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Unidade de Medida:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UnidadeMedida" Columns="3" MaxLength="3" runat="server" onkeydown="submitOnEnter('btnSave');" />
                                            <asp:RequiredFieldValidator ID="vtxtEmail" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="UnidadeMedida" />
                                        </td>
                                        <td>
                                            Quantidade:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtQuantidade" Columns="10" MaxLength="10" runat="server" onkeydown="submitOnEnter('btnSave');" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="txtQuantidade" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Desconto (%):
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDesconto" Columns="10" MaxLength="2" runat="server" onkeydown="submitOnEnter('btnSave');" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="txtDesconto" />
                                        </td>
                                        <td>
                                            Data de Início:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="datePicker" Columns="10" MaxLength="10" runat="server" onkeydown="submitOnEnter('btnSave');" />
                                            <%--<input type="text" id="datePicker" maxlength="10" onkeydown="submitOnEnter('btnSave');">--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="datePicker" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Valor Unitário:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ValorUnitario" Columns="10" MaxLength="10" runat="server" onkeydown="submitOnEnter('btnSave');" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="ValorUnitario" ForeColor="Red" />
                                        </td>
                                        <td>
                                            Peso (Kg):
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Peso" Columns="10" MaxLength="10" runat="server" onkeydown="submitOnEnter('btnSave');" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" EnableClientScript="true"
                                                Display="Dynamic" ErrorMessage="Obrigatório." ControlToValidate="Peso" />
                                        </td>
                                    </tr>
 
                                </table>
                            </div>
                            <div id="fragment-2">
                                <table cellpadding="3" cellspacing="1">
                                    <tr>
                                        <td>
                                            Cond. Pagamento:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="dpdCondPagamento" Width="280" CssClas="select_forms"
                                                onkeydown="submitOnEnter('btnSave');">
                                            </asp:DropDownList>
                                        </td>
                                       
                                    </tr>
 
                                    <tr>
                                        <td>
                                            Tipo de Mov. a ser gerado:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="dpdTipoMov" Width="280" CssClas="select_forms"
                                                onkeydown="submitOnEnter('btnSave');">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
 
                                    <tr>
                                        <td>
                                            Tipo:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="dpdTipo" Width="280" CssClas="select_forms"
                                                onkeydown="submitOnEnter('btnSave');">
                                            </asp:DropDownList>
                                        </td>
                                       
                                    </tr>
 
                                    <tr>
                                        <td>
                                            Origem:
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="dpdOrigem" Width="280" CssClas="select_forms"
                                                onkeydown="submitOnEnter('btnSave');">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
 
                                    <tr>
                                        <td>
                                            Campanha:
                                        </td>
                                        <td colspan="3">
                                            <asp:DropDownList runat="server" ID="dpdCampanha" Width="280" CssClas="select_forms"
                                                onkeydown="submitOnEnter('btnSave');">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="fragment-3">
                                <table cellpadding="3" cellspacing="1">
                                    <tr>
                                        <td>
                                            Histórico:
                                        </td>
                                        <td colspan="3">
                                            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtHistorico" Width="320" Height="80"
                                                CssClas="select_forms" onkeydown="submitOnEnter('btnSave');"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                           
                            
 
                        </div>
                        <div style="float: right;">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" Text="Adicionar" runat="server" /></div>&nbsp;
                            <div style="float: right;">
                            <asp:Button ID="btnCancel" OnClick="btnCancel_Click" OnClientClick="closeDialog()"
                                CausesValidation="false" Text="Cancelar" runat="server" /></div>
                    </asp:PlaceHolder>
                <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </div>
    <asp:UpdatePanel ID="upnlCustomers" UpdateMode="Conditional" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:LinkButton ID="btnAddCustomer" Text="Adicionar Produto" runat="server" OnClientClick="openDialogAndBlock('Adicionar Produto', 'btnAddCustomer')"
                CausesValidation="false" OnClick="btnAddCustomer_Click"></asp:LinkButton>
            <br />
            <br />
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ShowFooter="true" CellSpacing="1" OnRowDataBound="gvCustomer_RowDataBound" OnRowCommand="gvCustomers_RowCommand"
                OnDataBound="gvCustomer_DataBound">
                <FooterStyle BackColor="#dddddd" />
                <Columns>
                    <asp:BoundField HeaderText="Sequencia" />
                    <asp:TemplateField HeaderText="Produto">
                        <ItemTemplate>
                            <%# Eval("idProduto") + " - " + Eval("descricao")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" DataFormatString="{0:n3}" />
                    <asp:BoundField DataField="preco" HeaderText="Valor Unitário" DataFormatString="{0:n2}" />
                    <asp:BoundField DataField="Desconto" HeaderText="Desconto(%)" DataFormatString="{0:n2}" />
                    <asp:BoundField DataField="UnidadeMedida" HeaderText="UM" />
                    <asp:BoundField HeaderText="Total(R$)" DataFormatString="{0:n2}" />
                    <%--<asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" DataFormatString="{0:MMMM d, yyyy}" />--%>
                    <asp:TemplateField HeaderText="Opções">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" AlternateText="Editar" ToolTip="Editar" ImageUrl="~/images/pencil-icon.png"
                                CommandName="EditCustomer" CausesValidation="false" CommandArgument='<%#Eval("idProduto")%>'
                                runat="server"></asp:ImageButton>
                            <asp:ImageButton ID="btnDelete" AlternateText="Excluir" ToolTip="Excluir" CommandName="DeleteCustomer"
                                CausesValidation="false" ImageUrl="~/images/excluir.gif" CommandArgument='<%#Eval("idProduto")%>'
                                runat="server"></asp:ImageButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:LinkButton ID="btnRefreshGrid" CausesValidation="false" OnClick="btnRefreshGrid_Click"
                Style="display: none" runat="server"></asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upnlJsRunner" UpdateMode="Always" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="phrJsRunner" runat="server"></asp:PlaceHolder>