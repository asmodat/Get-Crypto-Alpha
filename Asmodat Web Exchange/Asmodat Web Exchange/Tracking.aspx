<%@ Page Title="" Language="C#" MasterPageFile="~/ExchangeMaster.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="Asmodat_Web_Exchange.Tracking" Async="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/TrackingControl.ascx" TagPrefix="uc1" TagName="TrackingControl" %>


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
        <tr><td><uc1:TrackingControl runat="server" id="TrackingControl" /></td></tr>
        
    </tbody>
    </table>
</div>
</form>
</asp:Content>