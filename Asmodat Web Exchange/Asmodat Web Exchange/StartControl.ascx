<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StartControl.ascx.cs" Inherits="Asmodat_Web_Exchange.StartControl" %>

<link href="startbootstrap-bare-1.0.3/css/bootstrap.css" rel="stylesheet" type="text/css"/>
<script src="Scripts/jquery-2.1.4.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>


    

    <asp:UpdatePanel ID="UpdPnlMarketPrice" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="panel panel-primary">
            <div class="panel-heading"><h2 class="panel-title">Exchange Rates&nbsp;&nbsp;<b>Live</b>*</h2></div>
                <div class="panel-body">
                <table class="table">
                    <thead>
                        <th><h4><b># Crypto</b></h4></th>
                        <th><h4></h4></th>
                        <th><h4>Ask</h4></th>
                        <th><h4>Bid</h4></th>
                        <th><h4></h4></th>
                        <th><h4>Fiat</h4></th>
                    </thead>
                    <tbody>
                        <tr>
                            
                            <td> <h2><h3><b>1</b> Bitcoin </h3></h2></td>
                            <td> <h2><asp:Button runat="server" ID="LblStartControlBuy" CssClass="btn btn-default btn-lg" OnClick="Buy_Click" Text="Buy XBT" /></h2></td>
                            <td> <h2><asp:Label ID="LblStartControlAsk" runat="server" Text="000.00"></asp:Label></h2></td>
                            <td> <h2><asp:Label ID="LblStartControlBid" runat="server" Text="000.00"></asp:Label>  </h2></td>
                            <td> <h2><asp:Button runat="server" ID="LblStartControlSell" CssClass="btn btn-default btn-lg" OnClick="Sell_Click" Text="Sell XBT" /></h2></td>
                            <td> <h2><h3>Euro</h3></h2></td>
                        </tr>
                    </tbody>
                 </table>
                </div></div>
            
            <h5>&nbsp;<asp:Label ID="LblStartControlTime" runat="server" Text="* Server UTC Timestamp: "></asp:Label></h5>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimrStartControl" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Timer runat="server" ID="TimrStartControl" Interval="1000"></asp:Timer>

  