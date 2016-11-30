using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AsmodatMath;
using Asmodat.Cryptography;
using Asmodat.Abbreviate;
using Asmodat.Types;

namespace Asmodat_Web_Exchange
{

    //<span class="input-group-addon asm-font-18px asm-height-46px" id="AdnOrderTrackingNr">Tracking number: </span>

    public partial class OrderControl : System.Web.UI.UserControl
    {

        public static ExchangeManager Manager = ExchangeManager.Instance;
        public SessionManager SManager { get; set; } = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeTrackingNumber(true);
            }

            if(SManager != null && SManager.ExchangeOrder != null)
            {
                if (!SManager.ExchangeOrder.TimeoutWarningsExecute.IsDefault && TickTime.Timeout(SManager.ExchangeOrder.TimeoutWarningsExecute, 5, TickTime.Unit.s))
                {
                    SManager.ExchangeOrder.TimeoutWarningsExecute = TickTime.Default;
                    AlertsControlExecute.HideWarning();
                }
            }
        }


        

        protected void ULBtnOrderTrackingNrRefresh_ServerClick(object sender, EventArgs e)
        {
            InitializeTrackingNumber(true);

            //AlertsControlTracking.HideAll();
            //string format = string.Format("<b>Success ! </b> New tracking number <b>{0}</b> was assigned to your order.", SManager.ExchangeOrder.TrackingNumber);
            //AlertsControlTracking.ShowSuccess(format);
            UpdPnlOrderControl.Update();
        }

        protected void ULBtnOrderCopy_ServerClick(object sender, EventArgs e)
        {
            //AlertsControlTracking.HideAll();
            //string format = string.Format("<b>Info ! </b> Order tracking number: <b>{0}</b> copy to clipboard request was executed.", SManager.ExchangeOrder.TrackingNumber);
            //AlertsControlTracking.ShowInfo(format);
        }


        protected void CmbxOrderAccept_CheckedChanged(object sender, EventArgs e)
        {
            this.InitializeTerms();
            UpdPnlOrderControl.Update();
        }

        

        protected void BtnOrderExecute_Click(object sender, EventArgs e)
        {
            if (SManager == null || SManager.AssetPrimary.Asset == null || SManager.AssetSecondary.Asset == null)
            {
                AlertsControlExecute.ShowWarning("Session ended, plese refresh this webpage !");
                SManager.ExchangeOrder.TimeoutWarningsExecute = TickTime.Now;
                return;
            }

            this.InitializeTerms();

            //cannot proceed, used must agree to terms and conditions
            if (!CmbxOrderAccept.Checked) 
            {
                UpdPnlOrderControl.Update();
                return;
            }

            ExchangeSettings settings = SManager.CalculateExchangeSettings(Manager);
            
            if(settings == null || !settings.Primary.IsAmountValid || !settings.Secondary.IsAmountValid)
            {
                AlertsControlExecute.ShowWarning("<b>Warning ! </b>Exchange Settings are invalid !");
                SManager.ExchangeOrder.TimeoutWarningsExecute = TickTime.Now;
                return;
            }

            if(SManager.FundingWithdraw == null || 
                SManager.FundingDeposit == null ||
                SManager.FundingWithdraw.Fundings == null ||
                SManager.FundingDeposit.Fundings == null ||
                !SManager.FundingWithdraw.Fundings.IsValid ||
                !SManager.FundingDeposit.Fundings.IsValid)
            {
                AlertsControlExecute.ShowWarning("<b>Warning ! </b>Fundings Settings are invalid !");
                SManager.ExchangeOrder.TimeoutWarningsExecute = TickTime.Now;
                return;
            }

            this.Execute();

        }
    }
}