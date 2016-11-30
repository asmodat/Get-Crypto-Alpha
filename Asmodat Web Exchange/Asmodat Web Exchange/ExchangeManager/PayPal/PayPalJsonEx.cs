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
    
    public static class PayPalJsonEx
    {
        public static PayPalJson ToPayPalJson(this InfoPayPal info)
        {
            PayPalJson json = new PayPalJson();
            json.PayerID = info.PayerID;
            json.PaymentID = info.PaymentID;
            json.Token = info.Token;
            return json;
        }

        public static void ToInfoPayPal(this PayPalJson json, ref InfoPayPal info)
        {
            info.PayerID = json.PayerID;
            info.PaymentID = json.PaymentID;
            info.Token = json.Token;
        }
    }
}

/*

     public string 
        public string Token
        public string PayerID

*/
