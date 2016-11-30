<%@ Page Title="" Language="C#" MasterPageFile="~/ExchangeMaster.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Asmodat_Web_Exchange.Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/StartControl.ascx" TagPrefix="uc1" TagName="StartControl" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

<form id="FormDefult" runat="server">
<asp:ScriptManager ID="ScrptMngrDefault" runat="server"></asp:ScriptManager>


<div class="jumbotron">

    <h1>Fund your wallet at market spot price.</h1><br />
    <p><span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>
    Buy Bitcoins with PayPal, directly from exchange.
    </p>
    <p><span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>
    Automated, secure and anonymous, no account or credentials are required.
    </p>
    <p><span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>
    Best price, and Full refund guaranteed if transacion fails or rates change.
    </p>

    <uc1:StartControl runat="server" ID="StartControl" />

</div>
</form>
    
</asp:Content>
