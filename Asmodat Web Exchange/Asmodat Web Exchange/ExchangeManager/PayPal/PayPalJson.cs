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
    
    public partial class PayPalJson
    {
        [JsonProperty(PropertyName = "payment_id")]
        public string PaymentID { get; set; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "payer_id")]
        public string PayerID { get; set; }

        [JsonProperty(PropertyName = "payment_url")]
        public string PaymentURL { get; set; }
    }
}

/*

     public string 
        public string Token
        public string PayerID

*/
