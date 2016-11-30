<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateLabelButton.ascx.cs" Inherits="Asmodat_Web_Exchange.UpdateLabelButton" %>


<div runat="server" id="DivOuter">
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div runat="server" id="DivInner">
                <asp:LinkButton runat="server" id="Button" OnClick="Button_Click">
                    <asp:Label ID="Label" runat="server"></asp:Label>
                </asp:LinkButton>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>



