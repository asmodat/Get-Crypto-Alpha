using Asmodat.Blockchain;
using Asmodat.BitfinexV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asmodat.BitfinexV1.API;
using Asmodat.Types;
using Asmodat.PayPal;
using Asmodat.Abbreviate;
using Asmodat.Debugging;
using Asmodat.Kraken;

using Asmodat.Cryptocurrency.Bitcoin;
using Asmodat.Cryptocurrency.Litecoin;
using Asmodat.Networking;
using System.ComponentModel;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Asmodat_Web_Exchange
{

    public partial class OrderTickersJson
    {
        [JsonProperty(PropertyName = "creation")]
        public TickTime Creation { get; set; }

        [JsonProperty(PropertyName = "execution")]
        public TickTime Execution { get; set; }

        [JsonProperty(PropertyName = "expiration")]
        public TickTime Expiration { get; set; }

        [JsonProperty(PropertyName = "cancellation")]
        public TickTime Cancellation { get; set; }
    }

    public partial class OrderJson
    {
        [JsonProperty(PropertyName = "tickers")]
        public OrderTickersJson Tickers { get; set; }

        [JsonProperty(PropertyName = "tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty(PropertyName = "fundings_deposit")]
        public FundingsJson FundingsDeposit { get; set; }

        [JsonProperty(PropertyName = "fundings_withdraw")]
        public FundingsJson FundingsWithdraw { get; set; }

        [JsonProperty(PropertyName = "asset_buy")]
        public ExchangeJson AssetBuy { get; set; }

        [JsonProperty(PropertyName = "asset_sell")]
        public ExchangeJson AssetSell { get; set; }


        [JsonProperty(PropertyName = "processing")]
        public ProcessingJson Processing { get; set; }

    }
}

/*

     public string 
        public string Token
        public string PayerID

*/
