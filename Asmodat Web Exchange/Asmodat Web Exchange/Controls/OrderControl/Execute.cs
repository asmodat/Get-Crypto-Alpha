using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AsmodatMath;
using Asmodat.Cryptography;
using Asmodat.Abbreviate;
using PayPal.Api;
using Asmodat.PayPal;
using Asmodat.Types;

namespace Asmodat_Web_Exchange
{

    

    public partial class OrderControl : System.Web.UI.UserControl
    {

        public void Execute()
        {
            var kind = SManager.FundingDeposit.Fundings.GetKind();
            OrderJson json = new OrderJson();
            ProcessingJson processing = new ProcessingJson();
            OrderTickersJson tickers = new OrderTickersJson();

            if (kind == Fundings.Kind.PayPal)
            {
                string _return = @"http://localhost:52092/Tracking.aspx?TrackingNumber=" + SManager.ExchangeOrder.TrackingNumber;
                string _cancel = @"http://localhost:52092/Default.aspx";

                Payment payment =  Manager.PayPal.RequestPayment(
                    1, 
                    Asmodat.PayPal.Api.ApiProperties.Currency.EUR, 
                    "test", 
                    _return,
                    _cancel);
                if (payment == null || !payment.IsCreated())
                    return;
                
                string url = payment.GetApprovalUrl();

                if (url.IsNullOrWhiteSpace())
                    return;

                processing.PayPal.PaymentURL = url;
                tickers.Creation = TickTime.Now;

                json.Processing = processing;
                json.Tickers = tickers;
                json.TrackingNumber = SManager.ExchangeOrder.TrackingNumber;
                json.FundingsDeposit = SManager.FundingDeposit.Fundings.ToFundingsJson();
                json.FundingsWithdraw = SManager.FundingWithdraw.Fundings.ToFundingsJson();
                json.AssetBuy = SManager.AssetBuy.ToExchangeJson();
                json.AssetSell = SManager.AssetSell.ToExchangeJson();
                Manager.Orders.Set(json.TrackingNumber, json);


                Response.Redirect(url);
            }

        }

    }
}

//<span class="input-group-addon asm-font-18px asm-height-46px" id="AdnOrderTrackingNr">Tracking number: </span>
/* if (CmbxOrderAccept.Checked)
            UBtnOrderExecute.Enabled = true;
        else
            UBtnOrderExecute.Enabled = false;*/
