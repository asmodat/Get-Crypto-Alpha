using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class UpdateLabel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public FontUnit FontSize
        {
            get { return Label.Font.Size; }
            set { Label.Font.Size = value; }
        }

        public Unit Width
        {
            get { return Label.Width; }
            set { Label.Width = value; }
        }



        public Unit Height
        {
            get { return Label.Height; }
            set { Label.Height = value; }
        }

        public string Text
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        public string Type
        {
            get { return Label.Attributes["type"]; }
            set { Label.Attributes["type"] = value; }
        }

        public string Class
        {
            get { return Label.Attributes["class"]; }
            set { Label.Attributes["class"] = value; }
        }

        public string Value
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