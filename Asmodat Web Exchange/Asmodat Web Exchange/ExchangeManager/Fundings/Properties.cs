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
using Newtonsoft.Json;
using Asmodat.Networking;
using System.ComponentModel;

namespace Asmodat_Web_Exchange
{
    /// <summary>
    /// This class is responsible for containing information about funding properties, and validation of beforesaid
    /// </summary>
    
    public partial class Fundings : ICloneable
    {
            public object Clone()
            {
                return this.MemberwiseClone();
            }

            public Fundings Copy()
            {
                return Objects.Clone(this);
            }


        public Fundings(Kind Name, Kraken.Asset Asset, AccountType Type, ValidationType Validation = ValidationType.None)
        {
            this.Name = Name.GetEnumDescription();
            this.Asset = Asset;
            this.Type = Type;
            this.Validation = Validation;
        }


        public enum AccountType
        {
            [Description("Deposit")]
            Deposit = 1,
            [Description("Withdraw")]
            Withdraw = 2
        }

        public enum Kind
        {
            [Description("PayPal")]
            PayPal = 0,
            [Description("Bitcoin")]
            Bitcoin = 1,
            [Description("Litecoin")]
            Litecoin = 2,
        }

        public enum ValidationType
        {
            [Description("None")]
            None = 0,
            [Description("EMail")]
            EMail = 1,
            [Description("Bitcoin")]
            Bitcoin = 2,
            [Description("Litecoin")]
            Litecoin = 3,
        }
    }
}