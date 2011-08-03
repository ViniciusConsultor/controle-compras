<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="TrocarSenha.aspx.cs" Inherits="HarunaNet.SisWeb.trocarsenha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <div id="dvDetTrocaSenha" class="jqmWindow">
        <asp:UpdatePanel ID="UpdDetTrocaSenha" runat="server">
            <ContentTemplate>
                <div class="divtitulo">
                <br />
                    <span>Alterar Senha </span>
                    <br />
                </div>
                <fieldset>
                    <table>
                        <tr>
                            <td>
                                <span class="textotitulos">Senha Atual:</span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtSenhaAtual" CssClass="textboxes" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenhaAtual"
                                    ValidationGroup="Inserir" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Digite a senha Atual!"
                                    ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="textotitulos">Nova Senha:</span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtSenhaNova1" CssClass="textboxes" TextMode="Password"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSenhaNova1"
                                    ValidationGroup="Inserir" CssClass="mensagem-vermelho" Display="Dynamic" ErrorMessage="Digite a nova senha!"
                                    ForeColor="" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span class="textotitulos">Repita Nova Atual:</span>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtSenhaNova2" CssClass="textboxes" TextMode="Password"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" SetFocusOnError="True" runat="server"
                                    ControlToValidate="txtSenhaNova2" ControlToCompare="txtSenhaNova1" ErrorMessage="Senhas Digitadas não conferem!"
                                    CssClass="mensagem-vermelho" Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>
                    </table>
                    <div>
                    <br />
                        <asp:Button runat="server" ID="btnCancelarTrocaSenha" Text="Cancelar" OnClick="btnCancelarTrocaSenha_Click" />
                        <asp:Button runat="server" ID="btnSalvarTrocaSenha" ValidationGroup="Inserir"  Text="Salvar" OnClick="btnSalvarTrocaSenha_Click" />
                    </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    <script type="text/javascript">

        var $dvDetTrocaSenha = $('#dvDetTrocaSenha').jqm({ modal: true, toTop: true, trigger: false });


        //Inicializa o Modal
        var $dvModalLoader = $('#dvModalLoader').jqm({ modal: true, toTop: true, trigger: false });

        //Adiciona os eventos para exibir/ocultar modal enquanto o postback assíncrono é executado.
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);

        function beginRequest(sender, args) {
            $dvModalLoader.jqmShow();
        }

        function endRequest(sender, args) {
            $dvModalLoader.jqmHide();
        }

        function cancelPostback() {
            Sys.WebForms.PageRequestManager.getInstance().abortPostBack();
            return false;
        }
    </script>
</asp:Content>
