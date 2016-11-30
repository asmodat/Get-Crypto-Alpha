using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class UpdateLabelButton : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler Click;

        protected void Button_Click(object sender, EventArgs e)
        {
            Click(sender, e);
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


        public string OnClientClick
        {
            get { return Button.OnClientClick; }
            set { Button.OnClientClick = value; }
        }

        public string ButtonType
        {
            get { return Button.Attributes["type"]; }
            set { Button.Attributes["type"] = value; }
        }

        public string ButtonClass
        {
            get { return Button.Attributes["class"]; }
            set { Button.Attributes["class"] = value; }
        }

        public string ButtonValue
        {
            get { return Button.Attributes["value"]; }
            set { Button.Attributes["value"] = value; }
        }

        public string ButtonText
        {
            get { return Button.Attributes["text"]; }
            set { Button.Attributes["text"] = value; }
        }

        public FontUnit ButtonFontSize
        {
            get { return Button.Font.Size; }
            set { Button.Font.Size = value; }
        }

        public FontUnit LabelFontSize
        {
            get { return Label.Font.Size; }
            set { Label.Font.Size = value; }
        }

        public Unit LabelWidth
        {
            get { return Label.Width; }
            set { Label.Width = value; }
        }

        

        public Unit LabelHeight
        {
            get { return Label.Height; }
            set { Label.Height = value; }
        }

        public string LabelText
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        public string LabelType
        {
            get { return Label.Attributes["type"]; }
            set { Label.Attributes["type"] = value; }
        }

        public string LabelClass
        {
            get { return Label.Attributes["class"]; }
            set { Label.Attributes["class"] = value; }
        }

        public string LabelValue
        {
            get { return Label.Attributes["value"]; }
            set { Label.Attributes["value"] = value; }
        }

        public void Update()
        {
            UpdatePanel.Update();
        }
    }
}

/*

    <div runat="server" id="DivOuter">
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div runat="server" id="DivInner">
                <button runat="server" id="Button" onserverclick="Button_Click">
                    <asp:Label ID="Label" runat="server"></asp:Label>
                </button>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>

<div class="input-group-btn">
                        <button type="button" class="btn btn-default asm-height-46px" runat="server" id="BtnAssetPrimaryGlyph" onserverclick="RbtnGlyph_ServerClick">
                            <asp:Label Width="25px" class="glyphicon glyphicon-edit" ID="LblAssetPrimaryGlyph" runat="server"></asp:Label>
                        </button>
                    </div>
*/
