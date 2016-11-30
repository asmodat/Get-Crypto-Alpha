<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlertsControl.ascx.cs" Inherits="Asmodat_Web_Exchange.AlertsControl" %>

<link href="/startbootstrap-bare-1.0.3/css/bootstrap.css" rel="stylesheet" type="text/css"/>
<link href="/startbootstrap-bare-1.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="/startasmodat-bare-1.0.1/css/asmodat.css" rel="stylesheet" type="text/css"/>
<script src="/Scripts/jquery-2.1.4.js" type="text/javascript" ></script>
<script src="/Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="/Scripts/bootstrap.min.js" type="text/javascript"></script>
<script src="/Scripts/bootstrap.js" type="text/javascript"></script>

<div runat="server" id="DivOuter">

     <asp:UpdatePanel ID="UpdPnlAlertsControl_Success" runat="server" UpdateMode="Conditional"><ContentTemplate><asp:Panel ID="PnlAlertsControl_Success" runat="server" Visible="false">
        <div class="alert alert-success">
            <button ID="BtnAlertsControl_Success" runat="server" type="button" class="close" data-dismiss="alert" onserverclick="BtnAlertsControl_Success_Click">&times;</button>
            <asp:Label ID="LblAlertsControl_Success" runat="server" Text="<b>Success!</b> success text."></asp:Label>
        </div>
     </asp:Panel></ContentTemplate></asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdPnlAlertsControl_Info" runat="server" UpdateMode="Conditional"><ContentTemplate><asp:Panel ID="PnlAlertsControl_Info" runat="server" Visible="false">
        <div class="alert alert-info">
            <button ID="BtnAlertsControl_Info" runat="server" type="button" class="close" data-dismiss="alert" onserverclick="BtnAlertsControl_Info_Click">&times;</button>
            <asp:Label ID="LblAlertsControl_Info" runat="server" Text="<b>Information!</b> information text."></asp:Label>
        </div>
     </asp:Panel></ContentTemplate></asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdPnlAlertsControl_Warning" runat="server" UpdateMode="Conditional"><ContentTemplate><asp:Panel ID="PnlAlertsControl_Warning" runat="server" Visible="false">
        <div class="alert alert-warning">
            <button ID="BtnAlertsControl_Warning" runat="server" type="button" class="close" data-dismiss="alert" onserverclick="BtnAlertsControl_Warning_Click">&times;</button>
            <asp:Label ID="LblAlertsControl_Warning" runat="server" Text="<b>Warning!</b> warning text."></asp:Label>
        </div>
     </asp:Panel></ContentTemplate></asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdPnlAlertsControl_Danger" runat="server" UpdateMode="Conditional"><ContentTemplate><asp:Panel ID="PnlAlertsControl_Danger" runat="server" Visible="false">
        <div class="alert alert-danger ">
            <button ID="BtnAlertsControl_Danger" runat="server" type="button" class="close" data-dismiss="alert" onserverclick="BtnAlertsControl_Danger_Click">&times;</button>
            <asp:Label ID="LblAlertsControl_Danger" runat="server" Text="<b>Danger!</b> danger text." ></asp:Label>
        </div>
     </asp:Panel></ContentTemplate></asp:UpdatePanel>

<asp:UpdatePanel ID="UpdPnlAlertsControl" runat="server" UpdateMode="Conditional">
<ContentTemplate>

</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="TimrAllertsControl" EventName="Tick" />
</Triggers>
</asp:UpdatePanel>

<asp:Timer runat="server" ID="TimrAllertsControl" Interval="100"></asp:Timer>
</div>