<%@ Page Title="" Language="C#" MasterPageFile="~/ExchangeMaster.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Exchange.aspx.cs" Inherits="Asmodat_Web_Exchange.Exchange" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/ExchangeControl.ascx" TagPrefix="uc1" TagName="ExchangeControl" %>
<%@ Register Src="~/OrderControl.ascx" TagPrefix="uc1" TagName="OrderControl" %>
<%@ Register Src="~/FundingsControl.ascx" TagPrefix="uc1" TagName="FundingsControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

<form id="FormExchange" runat="server">
<asp:ScriptManager ID="ScrptMngrEchange" runat="server"></asp:ScriptManager>

    <script type="text/javascript">
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    prm.add_beginRequest(beginRequest);

    function beginRequest() {
        prm._scrollPosition = null;
    }
</script>

<div class="jumbotron">
    <table>
    <tbody>
        <tr><td><uc1:ExchangeControl runat="server" id="ExchangeControl" /></td></tr>
        <tr><td><uc1:FundingsControl runat="server" id="FundingsControl" /></td></tr>
        <tr><td><uc1:OrderControl runat="server" id="OrderControl" /></td></tr>
        
    </tbody>
    </table>
</div>
</form>
</asp:Content>
