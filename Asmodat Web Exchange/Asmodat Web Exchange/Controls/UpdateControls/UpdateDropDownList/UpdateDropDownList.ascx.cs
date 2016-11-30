using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
//<uc1:UpdateDropDownList runat="server" ID="UDdlCurrencyPrimary" Width="180px" CssClass="btn form-control btn-default asm-border-radius-0px dropdown-toggle asm-height-46px asm-font-26px" AutoPostBack="true"  DataTextField="Select currency" OnSelectedIndexChanged="DdlCurrencyPrimary_SelectedIndexChanged"/> 
namespace Asmodat_Web_Exchange
{
    /*
    [ParseChildren(true)]
    [PersistChildren(true)]
    [ToolboxData("<{0}:UpdateDropDownList runat=server></{0}:UpdateDropDownList>")]

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    */


    public partial class UpdateDropDownList : System.Web.UI.UserControl, INamingContainer
    {



        protected void Page_Load(object sender, EventArgs e)
        {

        }


       /*& public bool Contains(ListItem item)
        {
            if (item == null || DropDownList == null || Items.Count <= 0)
                return false;

            for (int i = 0; i < Items.Count; i++)
            {
                ListItem li = Items[i];

                if (li == item)
                    return true;
            }

            return false;
        }*/


        public event EventHandler SelectedIndexChanged;

        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            SelectedIndexChanged(sender, e);
        }

        public string DivOuterClass
        {
            get { return DivOuter.Attributes["class"]; }
            set { DivOuter.Attributes["class"] = value; }
        }

        public string DivInnerClass
        {
            get { return DivInner.Attributes["class"]; }
            set { DivInner.Attributes["class"] = value; }
        }

        public ListItemCollection Items
        {
            get { return DropDownList.Items; }
        }


        

        public int SelectedIndex
        {
            get { return DropDownList.SelectedIndex; }
            set { DropDownList.SelectedIndex = value; }
        }

        public string SelectedValue
        {
            get { return DropDownList.SelectedValue; }
            set { DropDownList.SelectedValue = value; }
        }

        public string SelectMethod
        {
            get { return DropDownList.SelectMethod; }
            set { DropDownList.SelectMethod = value; }
        }

        public string Text
        {
            get { return DropDownList.Text; }
            set { DropDownList.Text = value; }
        }

        public string CssClass
        {
            get { return DropDownList.CssClass; }
            set { DropDownList.CssClass = value; }
        }

        public Unit Width
        {
            get { return DropDownList.Width; }
            set { DropDownList.Width = value; }
        }

        public Unit Height
        {
            get { return DropDownList.Height; }
            set { DropDownList.Height = value; }
        }

        public bool AutoPostBack
        {
            get { return DropDownList.AutoPostBack; }
            set { DropDownList.AutoPostBack = value; }
        }

        public Color ForeColor
        {
            get { return DropDownList.ForeColor; }
            set { DropDownList.ForeColor = value; }
        }

        public bool Enabled
        {
            get { return DropDownList.Enabled; }
            set { DropDownList.Enabled = value; }
        }




        public void Update()
        {
            UpdatePanel.Update();
        }
    }
}

/*
<asp:DropDownList runat="server" ID="DropDownList" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged">
        <asp:ListItem Value="Default" Enabled="true" Selected="True"> </asp:ListItem>
    </asp:DropDownList>


<asp:DropDownList ID="DdlCurrencyPrimary" Width="180px" CssClass="btn form-control btn-default asm-border-radius-0px dropdown-toggle asm-height-46px asm-font-26px" runat="server" AutoPostBack="true"  DataTextField="Select currency" OnSelectedIndexChanged="DdlCurrencyPrimary_SelectedIndexChanged">
                        <asp:ListItem Value="Euro" Enabled="true"> </asp:ListItem>
                        <asp:ListItem Value="Canadian Dollar" Enabled="true"> </asp:ListItem>
                        <asp:ListItem Value="Bitcoin" Enabled="true" Selected="True"> </asp:ListItem>
                        <asp:ListItem Value="Litecoin" Enabled="true"> </asp:ListItem>
                        </asp:DropDownList>


    <div class="input-group-btn">
                        <uc1:UpdateDropDownList runat="server" ID="UDdlCurrencyPrimary" Width="180px" CssClass="btn form-control btn-default asm-border-radius-0px dropdown-toggle asm-height-46px asm-font-26px" AutoPostBack="true"  DataTextField="Select currency" OnSelectedIndexChanged="DdlCurrencyPrimary_SelectedIndexChanged">

                        </uc1:UpdateDropDownList>
                    </div>
*/
