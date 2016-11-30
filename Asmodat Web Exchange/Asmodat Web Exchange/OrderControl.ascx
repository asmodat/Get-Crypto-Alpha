<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderControl.ascx.cs" Inherits="Asmodat_Web_Exchange.OrderControl" %>

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

<asp:UpdatePanel ID="UpdPnlOrderControl" runat="server" UpdateMode="Conditional">
<ContentTemplate>

            <div class="panel panel-primary">
            <div class="panel-heading"><h2 class="panel-title">Order request</h2></div>
             <div class="panel-body">
                <table class=" table asm-width-95">
                    <tbody>
                        <tr>
                            <td class="asm-tallign-center">

                                <uc1:AlertsControl runat="server" ID="AlertsControlTracking" DivOuterClass="h5" />

                                <div class="input-group asm-tallign-center">
                                    <uc1:UpdateLabel ID="ULblDeposit" DivOuterClass="input-group-btn"  DivInnerClass="input-group-addon asm-font-18px asm-height-46px" runat="server"  Text="Tracking Nr. " Width="125px" />
                                    
                                    <asp:TextBox ID="TbxOrderTrackingNr" runat="server" CssClass=" form-control asm-tallign-center asm-height-46px" Width="480px"  ReadOnly="true" Text="XxXxXxX" BackColor="White" Font-Size="26px" ClientIDMode="Static" >
                                    </asp:TextBox>

                                    <uc1:UpdateLabelButton runat="server" ID="ULBtnOrderTrackingNrRefresh" OnClick="ULBtnOrderTrackingNrRefresh_ServerClick" ButtonClass="btn btn-default asm-height-46px" DivOuterClass="input-group-btn" ButtonText="" LabelText="" LabelWidth="25px" LabelClass="glyphicon glyphicon-refresh" ButtonFontSize="X-Large" LabelFontSize="Large" />    
                                    <uc1:UpdateLabelButton runat="server" ID="ULBtnOrderCopy" OnClick="ULBtnOrderCopy_ServerClick" OnClientClick="copyTextToClipboard2(getValueByID('TbxOrderTrackingNr'), true)" ButtonClass="btn btn-default asm-height-46px" DivOuterClass="input-group-btn" ButtonText="" LabelText="" LabelWidth="25px" LabelClass="glyphicon glyphicon-duplicate" ButtonFontSize="X-Large" LabelFontSize="Large" />   
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="asm-tallign-center">

                                <uc1:AlertsControl runat="server" ID="AlertsControlTerms" DivOuterClass="h5" />

                                <div class="form-group checkbox" >
                                <asp:CheckBox CssClass=" asm-checkbox-md asm-font-bold" BorderColor="Red" BorderWidth="0px" BorderStyle="Dotted" ID="CmbxOrderAccept" runat="server" OnCheckedChanged="CmbxOrderAccept_CheckedChanged" Checked="false" Enabled="true" AutoPostBack="true" Text=" I agree to " />
                                <asp:HyperLink Font-Size="18px" ID="HyperLink1" runat="server"  NavigateUrl="#">Terms and Conditions</asp:HyperLink>
                                    &nbsp;
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="asm-tallign-center">
                                
                                <uc1:AlertsControl runat="server" ID="AlertsControlExecute" DivOuterClass="h5" />
                                <uc1:UpdateButton ID="UBtnOrderExecute" OnClick="BtnOrderExecute_Click"  runat="server" CssClass="btn btn-lg asm-font-bold " Text="Buy BTC with EUR" Value="AssetPrimaryBuy" BackColor="#fbee02" Height="50px" FontSize="24px" BorderStyle="Outset" BorderWidth="2px" BorderColor="Black"  />

                            </td>
                        </tr>
                        
                    </tbody>
                 </table>
                </div>
            </div>

</ContentTemplate>
</asp:UpdatePanel>



<asp:UpdatePanel ID="UpdPnlOrderControlTimr" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <asp:Timer runat="server" ID="TimrOrderControl" Interval="1000"></asp:Timer>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="TimrOrderControl" EventName="Tick" />
</Triggers>
</asp:UpdatePanel>

<!-- checkbox h3 btn btn-lg <div class="input-group"> 
    
    
    <span class="
    
    <span class="input-group-btn">

                                        <button type="button" class="btn btn-default btn-lg">
                                            <span class="glyphicon-refresh" aria-hidden="true"> Refresh</span>
                                        </button>

                                    </span>
    
    
    -->