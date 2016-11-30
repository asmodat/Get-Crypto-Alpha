<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpdateDropDownList.ascx.cs" Inherits="Asmodat_Web_Exchange.UpdateDropDownList" %>
<%@ Register TagPrefix="as1" Assembly="Asmodat Web Exchange" Namespace="Asmodat_Web_Exchange" %>


<div runat="server" id="DivOuter">
<asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional"><ContentTemplate>
    <div runat="server" id="DivInner">
    <asp:DropDownList runat="server" ID="DropDownList" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged"></asp:DropDownList>
        </div>
</ContentTemplate></asp:UpdatePanel>
    </div>
<!-- <as1:BaseDropDownList runat="server" ID="DropDownList9" AutoPostBack="true"></as1:BaseDropDownList> -->