using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class UpdateTextBox : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.Page.LoadComplete += Page_LoadComplete;
          
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ChangeCounter = 0;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            ChangeCounter = 0;
        }


        private void IncChangeCounter(string caller = null)
        {
                ++ChangeCounter;
        }

        public void ChangeClear()
        {
            ChangeCounter = 0;
        }

        public ulong ChangeCounter { get; private set; } = 0;

        //public bool CountTextChange { get; private set; } = true;

        public string DivOuterClass
        {
            get { return DivOuter.Attributes["class"]; }
            set { if (DivOuterClass != value) IncChangeCounter(); DivOuter.Attributes["class"] = value; }
        }

        public string DivInnerClass
        {
            get { return DivInner.Attributes["class"]; }
            set {  if (DivInnerClass != value) IncChangeCounter(); DivInner.Attributes["class"] = value; }
        }

        #region TextBox

        public string TextBoxID
        {
            get { return DivInner.ID; }
            set {  if (TextBoxID != value) IncChangeCounter(); DivInner.ID = value; }
        }

        public ClientIDMode TextBoxClientIDMode
        {
            get { return DivInner.ClientIDMode; }
            set {  if (TextBoxClientIDMode != value) IncChangeCounter(); DivInner.ClientIDMode = value; }
        }

        public string Text
        {
            get { return TextBox.Text;  }
            set
            {
                if (Text != value)
                    IncChangeCounter();
                TextBox.Text = value;
            }
        }

        public string CssClass
        {
            get { return TextBox.CssClass; }
            set {  if (CssClass != value) IncChangeCounter(); TextBox.CssClass = value; }
        }

        public TextBoxMode TextMode
        {
            get { return TextBox.TextMode; }
            set {  if (TextMode != value) IncChangeCounter(); TextBox.TextMode = value; }
        }

        public Unit Width
        {
            get { return TextBox.Width; }
            set {  if (Width != value) IncChangeCounter(); TextBox.Width = value; }
        }

        public Unit Height
        {
            get { return TextBox.Height; }
            set {  if (Height != value) IncChangeCounter(); TextBox.Height = value; }
        }

        public bool AutoPostBack
        {
            get { return TextBox.AutoPostBack; }
            set {  if (AutoPostBack != value) IncChangeCounter(); TextBox.AutoPostBack = value; }
        }

        public Color ForeColor
        {
            get { return TextBox.ForeColor; }
            set {  if (ForeColor != value) IncChangeCounter(); TextBox.ForeColor = value; }
        }

        public bool Enabled
        {
            get { return TextBox.Enabled; }
            set {  if (Enabled != value) IncChangeCounter(); TextBox.Enabled = value; }
        }

        public bool ReadOnly
        {
            get { return TextBox.ReadOnly; }
            set {  if(ReadOnly != value) IncChangeCounter(); TextBox.ReadOnly = value; }
        }

        #endregion

        #region TextBoxEvents

        
        public event EventHandler TextChanged;

        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextChanged(sender, e);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="force">true if control should be forced to update</param>
        public void Update(bool force = false)
        {
            if (force || ChangeCounter > 0)
            {
                UpdatePanel.Update();
                ChangeCounter = 0;
            }
        }
    }
}

/*
<asp:UpdatePanel ID="UpdPnlExchangeControl_Primary" runat="server" UpdateMode="Conditional"><ContentTemplate>
                        <asp:TextBox ID="TbxAmountPrimary" TextMode="Number" Width="400px" runat="server" CssClass="asm-border-radius-0px alert-danger asm-tallign-center asm-height-46px asm-font-28px" AutoPostBack="true" OnTextChanged="TbxAmountPrimary_TextChanged" ></asp:TextBox>
                    </ContentTemplate></asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdPnlExchangeControl_Secondary" runat="server" UpdateMode="Conditional"><ContentTemplate>
                        <asp:TextBox ID="TbxAmountSecondary" TextMode="Number" Width="400px" runat="server" CssClass="asm-border-radius-0px alert-success asm-tallign-center asm-height-46px asm-font-28px" AutoPostBack="true" OnTextChanged="TbxAmountSecondary_TextChanged" ></asp:TextBox>
                    </ContentTemplate></asp:UpdatePanel>
*/
