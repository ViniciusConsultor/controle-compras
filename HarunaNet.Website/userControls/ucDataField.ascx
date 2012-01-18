<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDataField.ascx.cs" Inherits="HarunaNet.SisWeb.webUserControl.ucDataField" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:TextBox ID="txtData" runat="server" Width="75px" OnTextChanged="txtData_TextChanged"></asp:TextBox>
<asp:ImageButton ID="imgData" runat="server" ImageUrl="~/library/imagens/Calendar_scheduleHS.png" />

<asp:RequiredFieldValidator  ID="rfvData" runat="server" ControlToValidate="txtData"
    Display="Dynamic" ErrorMessage="Por favor, preencha a data" SetFocusOnError="true"
    Enabled="false" >*</asp:RequiredFieldValidator>
   <asp:RegularExpressionValidator ID="revData" runat="server" ControlToValidate="txtData"
    ValidationExpression="^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-./])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$"
    ErrorMessage="Data Inválida!" Font-Size="X-Small" Display="None" SetFocusOnError="true"></asp:RegularExpressionValidator>
<ajax:CalendarExtender ID="ceData" runat="server" TargetControlID="txtData" Format="dd/MM/yyyy"
    PopupButtonID="imgData" CssClass="Calendario" Enabled="True"></ajax:CalendarExtender>
<ajax:MaskedEditExtender ID="meeData" runat="server" TargetControlID="txtData" MaskType="Date"
    Mask="99/99/9999">
</ajax:MaskedEditExtender>
<ajax:ValidatorCalloutExtender ID="vceData" Width="170px" runat="server" TargetControlID="revData"
    WarningIconImageUrl="~/library/imagens/alert-small.gif"></ajax:ValidatorCalloutExtender>

