<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateTextBox.ascx.cs" Inherits="Asmodat_Web_Exchange.UpdateTextBox" %>


<div runat="server" id="DivOuter">
<asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional"><ContentTemplate>
    <div runat="server" id="DivInner">
    <asp:TextBox ID="TextBox" runat="server" OnTextChanged="TextBox_TextChanged"></asp:TextBox>
        </div>
</ContentTemplate></asp:UpdatePanel>
    </div>