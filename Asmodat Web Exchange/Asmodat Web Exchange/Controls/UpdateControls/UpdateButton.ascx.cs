using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class UpdateButton : System.Web.UI.UserControl
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

        public string Type
        {
            get { return Button.Attributes["type"]; }
            set { Button.Attributes["type"] = value; }
        }

        public string Class
        {
            get { return Button.Attributes["class"]; }
            set { Button.Attributes["class"] = value; }
        }

        public string Value
        {
            get { return Button.Attributes["value"]; }
            set { Button.Attributes["value"] = value; }
        }

        public string CssClass
        {
            get { return Button.CssClass; }
            set { Button.CssClass = value; }
        }

        public string Text
        {
            get { return Button.Text; }
            set { Button.Text = value; }
        }

        public Color BackColor
        {
            get { return Button.BackColor; }
            set { Button.BackColor = value; }
        }

        public Unit Height
        {
            get { return Button.Height; }
            set { Button.Height = value; }
        }

        public Unit Width
        {
            get { return Button.Width; }
            set { Button.Width = value; }
        }

        public FontUnit FontSize
        {
            get { return Button.Font.Size; }
            set { Button.Font.Size = value; }
        }

        public BorderStyle BorderStyle
        {
            get { return Button.BorderStyle; }
            set { Button.BorderStyle = value; }
        }

        public Unit BorderWidth
        {
            get { return Button.BorderWidth; }
            set { Button.BorderWidth = value; }
        }

        public Color BorderColor
        {
            get { return Button.BorderColor; }
            set { Button.BorderColor = value; }
        }

        public bool Enabled
        {
            get { return Button.Enabled; }
            set { Button.Enabled = value; }
        }

        public void Update()
        {
            UpdatePanel.Update();
        }

        //Attributes["aria-expanded"]
    }
}

/*
<button type="button" value="AssetPrimaryBuy"  class="btn asm-height-46px asm-font-26px" runat="server" id="RbtnAssetPrimaryBuy" onserverclick="RbtnBuySell_ServerClick">Buy</button>
                        <button type="button" value="AssetPrimarySell"  class="btn btn-danger active asm-height-46px asm-font-26px" runat="server" id="RbtnAssetPrimarySell" onserverclick="RbtnBuySell_ServerClick">Sell</button>


<div class="input-group-btn">
                        <button type="button" value="AssetSecondaryBuy"  class="btn btn-success active asm-height-46px asm-font-26px" runat="server" id="RbtnAssetSecondaryBuy" onserverclick="RbtnBuySell_ServerClick">Buy</button>
                        <button type="button" value="AssetSecondarySell"  class="btn asm-height-46px asm-font-26px" runat="server" id="RbtnAssetSecondarySell" onserverclick="RbtnBuySell_ServerClick">Sell</button>
                    </div>
*/
