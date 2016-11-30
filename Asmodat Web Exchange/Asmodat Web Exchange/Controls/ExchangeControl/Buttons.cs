using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asmodat.Abbreviate;
using Asmodat.Kraken;

namespace Asmodat_Web_Exchange
{
    public partial class ExchangeControl : System.Web.UI.UserControl
    {
        private string textbox_success = "asm-border-radius-0px alert-success asm-tallign-center asm-height-46px asm-font-28px";
        private string textbox_danger = "asm-border-radius-0px alert-danger asm-tallign-center asm-height-46px asm-font-28px";

        private string button_success = "btn btn-success active asm-height-46px asm-font-26px";
        private string button_danger = "btn btn-danger active asm-height-46px asm-font-26px";
        private string button_null = "btn asm-height-46px asm-font-26px";

        private string label_lock = "glyphicon glyphicon-lock";
        private string label_edit = "glyphicon glyphicon-edit";

        private void InitializeButtons(bool update = false)
        {
            if (SManager.AssetPrimary.Buy)
            {
                URbtnAssetPrimaryBuy.Class = button_success;
                URbtnAssetPrimarySell.Class = button_null;
                URbtnAssetSecondaryBuy.Class = button_null;
                URbtnAssetSecondarySell.Class = button_danger;

                UTbxAmountPrimary.CssClass = textbox_success;
                UTbxAmountSecondary.CssClass = textbox_danger;
            }

            if (SManager.AssetSecondary.Buy)
            {
                URbtnAssetPrimaryBuy.Class = button_null;
                URbtnAssetPrimarySell.Class = button_danger;
                URbtnAssetSecondaryBuy.Class = button_success;
                URbtnAssetSecondarySell.Class = button_null;

                UTbxAmountPrimary.CssClass = textbox_danger;
                UTbxAmountSecondary.CssClass = textbox_success;
            }

            if (SManager.AssetPrimary.IsFixed)
            {
                UTbxAmountPrimary.ForeColor = System.Drawing.Color.Black;
                UTbxAmountPrimary.TextMode = TextBoxMode.Number;
                UTbxAmountSecondary.TextMode = TextBoxMode.SingleLine;
                UTbxAmountPrimary.ReadOnly = false;
                UTbxAmountSecondary.ReadOnly = true;
                ULBtnAssetPrimaryGlyph.LabelClass = label_lock;
                ULBtnAssetSecondaryGlyph.LabelClass = label_edit;
                
            }

            if (SManager.AssetSecondary.IsFixed)
            {
                UTbxAmountSecondary.ForeColor = System.Drawing.Color.Black;
                UTbxAmountPrimary.TextMode = TextBoxMode.SingleLine;
                UTbxAmountSecondary.TextMode = TextBoxMode.Number;
                UTbxAmountPrimary.ReadOnly = true;
                UTbxAmountSecondary.ReadOnly = false;
                ULBtnAssetPrimaryGlyph.LabelClass = label_edit;
                ULBtnAssetSecondaryGlyph.LabelClass = label_lock;
                
            }

            if (update)
            {
                ULBtnAssetPrimaryGlyph.Update();
                ULBtnAssetSecondaryGlyph.Update();
                UTbxAmountPrimaryReset(true);
                UTbxAmountSecondaryReset(true);
            }
        }

        protected void RbtnBuySell_ServerClick(object sender, EventArgs e)
        {
            string value = ((Button)sender).Attributes["value"];

            if (value == "AssetPrimaryBuy" || value == "AssetSecondarySell")
            {
                SManager.AssetPrimary.Buy = true;
                SManager.AssetSecondary.Sell = true;
            }
            else if (value == "AssetPrimarySell" || value == "AssetSecondaryBuy")
            {
                SManager.AssetPrimary.Sell = true;
                SManager.AssetSecondary.Buy = true;
            }

            this.UpdateAll();
        }

        protected void RbtnGlyph_ServerClick(object sender, EventArgs e)
        {
            if (SManager == null)
                return;

            

            SManager.AssetPrimary.IsFixed = !SManager.AssetPrimary.IsFixed;
            SManager.AssetSecondary.IsFixed = !SManager.AssetSecondary.IsFixed;


            this.UpdateAll();
            //this.InitializeButtons(true);

        }
    }
}