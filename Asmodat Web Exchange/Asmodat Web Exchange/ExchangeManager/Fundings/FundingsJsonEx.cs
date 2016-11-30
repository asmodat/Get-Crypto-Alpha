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
    
    public static class FundingsJsonEx
    {
        public static FundingsJson ToFundingsJson(this Fundings fundings)
        {
            FundingsJson json = new FundingsJson();
            json.Address = fundings.Address;
            json.Asset = fundings.Asset.GetEnumDescription();
            json.Name = fundings.Name;
            json.Tag = fundings.Tag;
            json.Type = fundings.Type.GetEnumDescription();
            json.Validation = fundings.Validation.GetEnumDescription();
            return json;
        }

        public static Fundings ToFundings(this FundingsJson json)
        {
            Fundings.Kind kind = Enums.ToEnumByDescription<Fundings.Kind>(json.Name);
            Kraken.Asset asset = Enums.ToEnumByDescription<Kraken.Asset>(json.Asset);
            Fundings.AccountType type = Enums.ToEnumByDescription<Fundings.AccountType>(json.Type);
            Fundings.ValidationType validation = Enums.ToEnumByDescription<Fundings.ValidationType>(json.Validation);

            Fundings fundings = new Fundings(kind, asset, type, validation);
            fundings.Address = json.Address;
            fundings.Tag = json.Tag;

            return fundings;
        }
    }
}