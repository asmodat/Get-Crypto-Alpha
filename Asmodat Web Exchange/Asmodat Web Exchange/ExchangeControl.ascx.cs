using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asmodat.Abbreviate;
using Asmodat.Kraken;

using Asmodat.Extensions;
using Asmodat.Extensions.Objects;

namespace Asmodat_Web_Exchange
{
    public partial class ExchangeControl : System.Web.UI.UserControl
    {
        public static ExchangeManager Manager = ExchangeManager.Instance;
        public SessionManager SManager { get; set; } = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            UTbxAmountSecondary.ChangeClear();
            UTbxAmountSecondary.ChangeClear();

            if (!IsPostBack)
            {
                if (SManager.AssetPrimary.Buy == SManager.AssetSecondary.Buy)
                    SManager.AssetPrimary.Buy = true;

                this.UpdateAll();
            }
            
            this.InitializeTextBoxes();
        }

        /// <summary>
        /// Updates all controls form ExchangeControl, and triggers update from Fundings Control
        /// </summary>
        public void UpdateAll()
        {

            AlertsControlPrimary.HideAll();
            AlertsControlSecondary.HideAll();

            this.InitializeButtons();
            this.InitializeDropDowns();
            this.InitializeTextBoxes();


            UTbxAmountPrimaryReset(true);
            UTbxAmountSecondaryReset(true);

            this.UpdateAllPanells();

            SManager.FundingDeposit.UpdateAllCotrols = true;
            SManager.FundingWithdraw.UpdateAllCotrols = true;
        }

        /// <summary>
        /// Updates all update panels
        /// </summary>
        public void UpdateAllPanells()
        {
            URbtnAssetPrimaryBuy.Update();
            URbtnAssetPrimarySell.Update();
            URbtnAssetSecondaryBuy.Update();
            URbtnAssetSecondarySell.Update();
            ULBtnAssetPrimaryGlyph.Update();
            ULBtnAssetSecondaryGlyph.Update();
            UDdlCurrencyPrimary.Update();
            UDdlCurrencySecondary.Update();
            UTbxAmountPrimary.Update();
            UTbxAmountSecondary.Update();
        }

        protected void TbxAmountPrimary_TextChanged(object sender, EventArgs e)
        {
            if (!SManager.AssetPrimary.IsValid() || !SManager.AssetPrimary.IsFixed) return;
            //UTbxAmountSecondaryReset(true);

            Kraken.Asset asset = SManager.AssetPrimary.Asset.Value;
            Asset info = Manager.Kraken.AssetInfo(asset);

            if (info == null) return;



            /**/
            //if (UTbxAmountSecondary.Text == "") UTbxAmountSecondaryReset(true);



            decimal value = UTbxAmountPrimary.Text.ParseDecimal(-1);

            if (value.CountPrecisionDigits() > info.DisplayDecimals)
            {
                string format = string.Format("<b>Info !</b> Primary amount precision is to high, no more then <b>{0}</b> decimals places allowed.",
                    info.DisplayDecimals);
                AlertsControlPrimary.ShowInfo(format);
            }
            else AlertsControlPrimary.HideInfo();
            

            value = Math.Round(value, info.DisplayDecimals);


            if (value > 0 && value < 100000000000000)
            {
                SManager.AssetPrimary.Amount = value;
                this.AlertsControlPrimary.HideWarning();
            }
            else
            {
                //SManager.AssetPrimary.Amount = 0;
                this.AlertsControlPrimary.ShowWarning("<b>Warning !</b> Primary amount is invalid.");
            }

            this.InitializeTextBoxes();

        }

        protected void TbxAmountSecondary_TextChanged(object sender, EventArgs e)
        {
            if (!SManager.AssetSecondary.IsValid() || !SManager.AssetSecondary.IsFixed) return;
            //UTbxAmountPrimaryReset(true);

            Kraken.Asset asset = SManager.AssetSecondary.Asset.Value;
            Asset info = Manager.Kraken.AssetInfo(asset);

            if (info == null) return;


            // if (UTbxAmountPrimary.Text == "") UTbxAmountPrimaryReset(true);
            /*if (UTbxAmountSecondary.Text == "" && SManager.AssetSecondary.CotrolsUpdateTextBox)
            {
                SManager.AssetSecondary.CotrolsUpdateTextBox = false;
                UTbxAmountSecondaryReset(true);
            }*/



            decimal value = UTbxAmountSecondary.Text.ParseDecimal(-1);

            if (value.CountPrecisionDigits() > info.DisplayDecimals)
            {
                string format = string.Format("<b>Info !</b> Secondary amount precision is to high, no more then <b>{0}</b> decimals places allowed.",
                    info.DisplayDecimals);
                this.AlertsControlSecondary.ShowInfo(format);
            }
            else this.AlertsControlSecondary.HideInfo();
            

            value = Math.Round(value, info.DisplayDecimals);

            if (value > 0 && value < 100000000000000)
            {
                SManager.AssetSecondary.Amount = value;
                this.AlertsControlSecondary.HideWarning();
            }
            else
            {
                //SManager.AssetSecondary.Amount = 0;
                this.AlertsControlSecondary.ShowWarning("<b>Warning !</b> Secondary amount is invalid.");
            }

            this.InitializeTextBoxes();
        }



        protected void UTbxAmountPrimaryReset(bool update = false)
        {
            if (!SManager.AssetPrimary.IsValid())
                return;

            Kraken.Asset asset = SManager.AssetPrimary.Asset.Value;
            Asset info = Manager.Kraken.AssetInfo(asset);
            int decimals = info.GetDisplayDecimals(2);

            decimal amount = Math.Round(SManager.AssetPrimary.Amount, decimals);
            UTbxAmountPrimary.Text = amount.ToString("N" + decimals).Replace(",","");

            if (update) UTbxAmountPrimary.Update();
        }


        protected void UTbxAmountSecondaryReset(bool update = false)
        {
            if (!SManager.AssetSecondary.IsValid())
                return;

            Kraken.Asset asset = SManager.AssetSecondary.Asset.Value;
            Asset info = Manager.Kraken.AssetInfo(asset);
            int decimals = info.GetDisplayDecimals(2);

            decimal amount = Math.Round(SManager.AssetSecondary.Amount, decimals);
            UTbxAmountSecondary.Text = amount.ToString("N" + decimals).Replace(",", "");

            if (update) UTbxAmountSecondary.Update();
        }



    }
}

/*
#,##,###,0.00

       runat="server" onserverclick="DllFiat_Click" 
       protected void DllFiat_Click(object sender, EventArgs e)
       {
           string attribute = DdlFiat.Attributes["aria-expanded"];
           if (attribute.IsNullOrWhiteSpace())
               return;

           bool expanded = bool.Parse(attribute);

           if (expanded)
           {
              // DivDdlFiat.Attributes["class"] = "input-group";
           }


           DdlFiat.Attributes["aria-expanded"] = (!expanded).ToString();
       }*/
