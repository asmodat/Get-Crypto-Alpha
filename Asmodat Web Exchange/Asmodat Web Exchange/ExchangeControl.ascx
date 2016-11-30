<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExchangeControl.ascx.cs" Inherits="Asmodat_Web_Exchange.ExchangeControl"  %>
<%@ Register Src="~/Controls/AlertsControl/AlertsControl.ascx" TagPrefix="uc1" TagName="AlertsControl" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateTextBox.ascx" TagPrefix="uc1" TagName="UpdateTextBox" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateButton.ascx" TagPrefix="uc1" TagName="UpdateButton" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateDropDownList/UpdateDropDownList.ascx" TagPrefix="uc1" TagName="UpdateDropDownList" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateLabelButton.ascx" TagPrefix="uc1" TagName="UpdateLabelButton" %>







<link href="startbootstrap-bare-1.0.3/css/bootstrap.css" rel="stylesheet" type="text/css"/>
<link href="startbootstrap-bare-1.0.3/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="startasmodat-bare-1.0.1/css/asmodat.css" rel="stylesheet" type="text/css"/>
<script src="Scripts/jquery-2.1.4.js" type="text/javascript" ></script>
<script src="Scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
<script src="Scripts/bootstrap.js" type="text/javascript"></script>




<div class="panel panel-primary">
<div class="panel-heading"><h2 class="panel-title">Exchange settings</h2></div>
<div class="panel-body">

    

    <table class="table h2">
        <tbody>

            <!-- Row primary -->

            <tr>
                <td class="asm-tallign-center">
                    <uc1:AlertsControl runat="server" ID="AlertsControlPrimary" DivOuterClass="h5" />
                    <div class="input-group">
                    <uc1:UpdateButton DivOuterClass="input-group-btn" runat="server" ID="URbtnAssetPrimaryBuy" Type="button" Value="AssetPrimaryBuy"  Class="btn asm-height-46px asm-font-26px" OnClick="RbtnBuySell_ServerClick" Text="Buy" />
                    <uc1:UpdateButton DivOuterClass="input-group-btn" runat="server" ID="URbtnAssetPrimarySell" Type="button" Value="AssetPrimarySell"  Class="btn btn-danger active asm-height-46px asm-font-26px" OnClick="RbtnBuySell_ServerClick" Text="Sell" />
                    <uc1:UpdateTextBox runat="server" ID="UTbxAmountPrimary" TextMode="Number" Width="400px"  CssClass="asm-border-radius-0px alert-danger asm-tallign-center asm-height-46px asm-font-28px" AutoPostBack="true" OnTextChanged="TbxAmountPrimary_TextChanged" />
                    <uc1:UpdateDropDownList DivOuterClass="input-group-btn" runat="server" ID="UDdlCurrencyPrimary" Width="180px" CssClass="btn form-control btn-default asm-border-radius-0px dropdown-toggle asm-height-46px asm-font-26px" AutoPostBack="true"  DataTextField="Select currency" OnSelectedIndexChanged="DdlCurrencyPrimary_SelectedIndexChanged" />
                    <uc1:UpdateLabelButton runat="server" ID="ULBtnAssetPrimaryGlyph" ButtonClass="btn btn-default asm-height-46px" DivOuterClass="input-group-btn" ButtonText="" LabelText="" OnClick="RbtnGlyph_ServerClick" LabelWidth="25px" LabelClass="glyphicon glyphicon-edit" ButtonFontSize="X-Large" LabelFontSize="Large" />    
                    </div>
                </td>
            </tr>

            <!-- Row secondary -->

            <tr>
                <td class="asm-tallign-center">
                    <uc1:AlertsControl runat="server" ID="AlertsControlSecondary" DivOuterClass="h5" />
                    <div class="input-group">
                    <uc1:UpdateButton DivOuterClass="input-group-btn" runat="server" ID="URbtnAssetSecondaryBuy" Type="button" Value="AssetSecondaryBuy"  Class="btn btn-success active asm-height-46px asm-font-26px" OnClick="RbtnBuySell_ServerClick" Text="Buy" />
                    <uc1:UpdateButton DivOuterClass="input-group-btn" runat="server" ID="URbtnAssetSecondarySell" Type="button" Value="AssetSecondarySell"  Class="btn asm-height-46px asm-font-26px" OnClick="RbtnBuySell_ServerClick" Text="Sell" />
                    <uc1:UpdateTextBox ID="UTbxAmountSecondary" TextMode="Number" Width="400px" runat="server" CssClass="asm-border-radius-0px alert-success asm-tallign-center asm-height-46px asm-font-28px" AutoPostBack="true" OnTextChanged="TbxAmountSecondary_TextChanged" />
                    <uc1:UpdateDropDownList DivOuterClass="input-group-btn" runat="server" ID="UDdlCurrencySecondary" Width="180px" CssClass="btn form-control btn-default asm-border-radius-0px dropdown-toggle asm-height-46px asm-font-26px" AutoPostBack="true"  DataTextField="Select currency" OnSelectedIndexChanged="DdlCurrencySecondary_SelectedIndexChanged" />
                    <uc1:UpdateLabelButton runat="server" ID="ULBtnAssetSecondaryGlyph" ButtonClass="btn btn-default asm-height-46px " DivOuterClass="input-group-btn" ButtonText="" LabelText="" OnClick="RbtnGlyph_ServerClick" LabelWidth="25px" LabelClass="glyphicon glyphicon-lock " ButtonFontSize="X-Large" LabelFontSize="Large"  />   
                    </div>
                </td>
            </tr>


        </tbody>
    </table>



<asp:UpdatePanel ID="UpdPnlExchangeControl" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <asp:Timer runat="server" ID="TimrExchangeControl" Interval="1000"  ></asp:Timer>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="TimrExchangeControl" EventName="Tick" />
    <asp:AsyncPostBackTrigger ControlID="ULBtnAssetPrimaryGlyph" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="ULBtnAssetSecondaryGlyph" EventName="Click" />
</Triggers>
</asp:UpdatePanel>



</div>
</div>




