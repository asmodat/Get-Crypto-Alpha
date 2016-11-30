<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateButton.ascx.cs" Inherits="Asmodat_Web_Exchange.UpdateButton" %>

<div runat="server" id="DivOuter">
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div runat="server" id="DivInner">
                <asp:Button ID="Button" runat="server" OnClick="Button_Click" />
            </div>
        </ContentTemplate>

    </asp:UpdatePanel>
</div>