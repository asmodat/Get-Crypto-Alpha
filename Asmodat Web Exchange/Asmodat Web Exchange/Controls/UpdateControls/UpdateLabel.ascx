<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateLabel.ascx.cs" Inherits="Asmodat_Web_Exchange.UpdateLabel" %>


<div runat="server" id="DivOuter">
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div runat="server" id="DivInner">
                <asp:Label ID="Label" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>