<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FundingsControl.ascx.cs" Inherits="Asmodat_Web_Exchange.FundingsControl" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateLabel.ascx" TagPrefix="uc1" TagName="UpdateLabel" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateTextBox.ascx" TagPrefix="uc1" TagName="UpdateTextBox" %>
<%@ Register Src="~/Controls/UpdateControls/UpdateDropDownList/UpdateDropDownList.ascx" TagPrefix="uc1" TagName="UpdateDropDownList" %>
<%@ Register Src="~/Controls/AlertsControl/AlertsControl.ascx" TagPrefix="uc1" TagName="AlertsControl" %>






<link href="startasmodat-bare-1.0.1/css/asmodat.css" rel="stylesheet" type="text/css"/>
<link href="startbootstrap-bare-1.0.3/css/bootstrap.css" rel="stylesheet" type="text/css"/>
<script src="Scripts/jquery-2.1.4.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>


<div class="panel panel-primary">
<div class="panel-heading"><h2 class="panel-title">Funding settings</h2></div>
<div class="panel-body">

                <table class="table h2">
                    <tbody>
                        <tr>
                            <td>
                                <uc1:AlertsControl runat="server" ID="AlertsControlDeposit" DivOuterClass="h5" />
                                <div class="input-group asm-tallign-center">
                                <uc1:UpdateLabel ID="ULblDeposit" DivOuterClass="input-group-btn"  DivInnerClass="input-group-addon asm-font-18px asm-height-46px" runat="server"  Text="Deposit " Width="125px" />
                                <uc1:UpdateTextBox ID="UTbxDeposit" DivOuterClass="input-group-btn" runat="server"  Width="400px"  CssClass="asm-border-radius-0px alert-danger asm-tallign-center asm-height-46px asm-input-lg-39c" AutoPostBack="true" OnTextChanged="UTbxDeposit_TextChanged" />
                                <uc1:UpdateDropDownList ID="UDdlDeposit" DivOuterClass="input-group-btn" runat="server"  Width="180px" CssClass="btn form-control btn-default asm-border-radius-0px dropdown-toggle asm-height-46px asm-font-26px" AutoPostBack="true" OnSelectedIndexChanged="UDdlDeposit_SelectedIndexChanged" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:AlertsControl runat="server" ID="AlertsControlWithdraw" DivOuterClass="h5"/>
                                <div class="input-group asm-tallign-center">
                                <uc1:UpdateLabel ID="ULblWithdraw"  DivOuterClass="input-group-btn"  DivInnerClass="input-group-addon asm-font-18px asm-height-46px" runat="server" Text="Withdraw " Width="125px" />
                                <uc1:UpdateTextBox ID="UTbxWithdraw" DivOuterClass="input-group-btn" runat="server"  Width="400px"  CssClass="asm-border-radius-0px alert-success asm-tallign-center asm-height-46px asm-input-lg-39c" AutoPostBack="true" OnTextChanged="UTbxWithdraw_TextChanged"  />
                                <uc1:UpdateDropDownList ID="UDdlWithdraw" DivOuterClass="input-group-btn" runat="server" Width="180px" CssClass="btn form-control btn-default asm-border-radius-0px dropdown-toggle asm-height-46px asm-font-26px" AutoPostBack="true" OnSelectedIndexChanged="UDdlWithdraw_SelectedIndexChanged" />
                                </div>
                            </td>
                        </tr>
                    </tbody>
                 </table>



<asp:UpdatePanel ID="UpdPnlFundingControl" runat="server" UpdateMode="Conditional">
<ContentTemplate>
    <asp:Timer runat="server" ID="TimrFundingsControl" Interval="1000"></asp:Timer>
</ContentTemplate>
<Triggers>
    <asp:AsyncPostBackTrigger ControlID="TimrFundingsControl" EventName="Tick" />
</Triggers>
</asp:UpdatePanel>



</div>
</div>


<!-- 
    12345678901234567890123456789012

    123456789012345678901234567890123456789012
    0x64dde50be507ff6d0180db0b392e640b43ee284e
    asm-tallign-center col-xs-12 input-lg

    331Puqqwh8gFnFQVoVcUoD4e2zSMR3MddW
    Withdraw & Deposit
    <th><h4><b># Crypto</b></h4></th>
-->