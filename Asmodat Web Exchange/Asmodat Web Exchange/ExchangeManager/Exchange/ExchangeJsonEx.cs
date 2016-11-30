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
    
    public static class ExchangeJsonEx
    {
        /// <summary>
        /// Converts InfoExchange to Json class
        /// </summary>
        /// <param name="exchange"></param>
        /// <returns></returns>
        public static ExchangeJson ToExchangeJson(this InfoExchange exchange)
        {
            ExchangeJson json = new ExchangeJson();
            json.AssetName = exchange.AssetName;
            json.Amount = exchange.Amount;
            json.Buy = exchange.Buy;
            json.Sell = exchange.Sell;
            json.IsFixed = exchange.IsFixed;
            return json;
        }

        public static void ToInfoExchange(this ExchangeJson json, ref InfoExchange exchanage)
        {
            exchanage.AssetName = json.AssetName;
            exchanage.Amount = json.Amount;
            exchanage.Buy = json.Buy;
            exchanage.Sell = json.Sell;
            exchanage.IsFixed = json.IsFixed;
        }
    }
}