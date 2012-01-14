<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPrincipal.master" AutoEventWireup="true"
    CodeBehind="cadFornecedor.aspx.cs" Inherits="HarunaNet.SisWeb.cadFornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdDetCadUsu" runat="server">
        <ContentTemplate>
            <div id="conteudo">
                <div class="cont_pesq">
                    <h2>
                        Cadastro de Fornecedores
                    </h2>
                    <asp:ValidationSummary ID="vlsListaError" runat="server" BorderStyle="None" ValidationGroup="ValidationSalvar"
                        ShowMessageBox="True" ShowSummary="false" />
                    <asp:HiddenField ID="FornecedorID" runat="server" />
                    <table width="100%" cellpadding="1" cellspacing="1">
                        <tr>
                            <td style="width: 110px">
                                <asp:Label CssClass="labeltitulo" ID="Label1" runat="server" Text="Nome Fantasia:"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtNomeFantasia" runat="server" Width="60%" CssClass="textboxes"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNomeFantasia" runat="server" ControlToValidate="txtNomeFantasia"
                                    CssClass="mensagem-vermelho" ValidationGroup="ValidationSalvar" Visible="true"
                                    ErrorMessage="Nome Fantasia Obrigatório!">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px">
                                <asp:Label CssClass="labeltitulo" ID="lblRazaoSocial" runat="server" Text="Razão Social:"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtRazaoSocial" runat="server" Width="60%" CssClass="textboxes"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRazaoSocial" runat="server" ControlToValidate="txtRazaoSocial"
                                    ErrorMessage="Razão Social Obrigatório!" ValidationGroup="ValidationSalvar">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label6" runat="server" Text="CNPJ:"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtCNPJ" runat="server" CssClass="textboxes" MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvCNPJ" ControlToValidate="txtCNPJ" runat="server"
                                    ErrorMessage="CNPJ Obrigatório!" ValidationGroup="ValidationSalvar">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px">
                                <asp:Label CssClass="labeltitulo" ID="lblInscEst" runat="server" Text="Inscrição Estadual:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtInscEstadual" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="lblInscMun" runat="server" Text="Inscrição Municipal:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtInscMunicipal" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px">
                                <asp:Label CssClass="labeltitulo" ID="Label2" runat="server" Text="Endereço:"></asp:Label>
                            </td>
                            <td colspan="4">
                                <asp:TextBox ID="txtEndereco" Width="60%" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px">
                                <asp:Label CssClass="labeltitulo" ID="Label3" runat="server" Text="Bairro:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtBairro" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label13" runat="server" Text="CEP:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtCEP" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 110px">
                                <asp:Label CssClass="labeltitulo" ID="Label4" runat="server" Text="Cidade:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtCidade" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label12" runat="server" Text="UF:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtUF" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label5" runat="server" Text="Telefone:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtTelefone1" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label7" runat="server" Text="Ramal:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtRamal1" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label8" runat="server" Text="Telefone:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtTelefone2" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label9" runat="server" Text="Ramal:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtRamal2" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label10" runat="server" Text="Celular:"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="textboxes"></asp:TextBox>
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                            <td style="width: 20%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="Label11" runat="server" Text="E-Mail:"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan="4">
                                <asp:TextBox ID="txtEmail" runat="server" Width="60%" CssClass="textboxes"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="e-mail inválido!"
                                    ValidationExpression="^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$"
                                    ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">
                                <asp:Label CssClass="labeltitulo" ID="lblObs" runat="server" Text="Observações:"></asp:Label>
                            </td>
                            <td style="width: 20%" colspan="4">
                                <asp:TextBox ID="txtObservacoes" runat="server" Rows="10" TextMode="MultiLine" Width="99%"
                                    CssClass="textboxes" Height="150px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div>
                        &nbsp;<asp:Button runat="server" ID="btnSalvar" ValidationGroup="ValidationSalvar"
                            Text="Salvar" OnClick="btnSalvar_Click" />
                        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
