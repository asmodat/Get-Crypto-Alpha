<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TrackingControl.ascx.cs" Inherits="Asmodat_Web_Exchange.TrackingControl" %>


<%@ Register Src="~/Controls/AlertsControl/AlertsControl.ascx" TagPrefix="uc1" TagName="AlertsControl" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateTextBox.ascx" TagPrefix="uc1" TagName="UpdateTextBox" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateButton.ascx" TagPrefix="uc1" TagName="UpdateButton" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateDropDownList/UpdateDropDownList.ascx" TagPrefix="uc1" TagName="UpdateDropDownList" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateLabelButton.ascx" TagPrefix="uc1" TagName="UpdateLabelButton" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateLabel.ascx" TagPrefix="uc1" TagName="UpdateLabel" %>

<link href="startbootstrap-bare-1.0.3/css/bootstrap.css" rel="stylesheet" type="text/css"/>
<link href="startasmodat-bare-1.0.1/css/asmodat.css" rel="stylesheet" type="text/css"/>
<script src="Scripts/jquery-2.1.4.js" type="text/javascript" ></script>
<script src="Scripts/bootstrap.js" type="text/javascript"></script>
<script src="startasmodat-bare-1.0.1/js/asmodat.js" type="text/javascript"></script>


<div class="panel panel-primary">
<div class="panel-heading"><h2 class="panel-title">Order settings</h2></div>
<div class="panel-body">

                <table class="table h2">
                    <tbody>
                        <tr>
                            <td>
                                <div class="input-group">
                                <uc1:UpdateLabel ID="ULblTrackingNumber" Text="Tracking Number: " DivOuterClass="input-group-btn"  DivInnerClass="asm-tallign-center input-group-addon asm-font-18px asm-height-46px" runat="server"   Width="200px" />
                                <uc1:UpdateTextBox ID="UTbxTrackingNumber" runat="server" DivOuterClass="input-group-btn"  ReadOnly="true" Width="400px"  CssClass="asm-border-radius-0px asm-tallign-center asm-height-46px asm-input-lg-39c" AutoPostBack="true" />
                                </div>
                              </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </tbody>
                 </table>



<asp:UpdatePanel ID="UpdPnlTrackingControl" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <asp:Timer runat="server" ID="TimrTrackingControl" Interval="1000"></asp:Timer>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="TimrTrackingControl" EventName="Tick" />
</Triggers>
</asp:UpdatePanel>



</div>
</div>
