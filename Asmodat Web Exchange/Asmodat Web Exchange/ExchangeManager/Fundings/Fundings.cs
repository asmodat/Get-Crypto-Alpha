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
    [Serializable]
    public partial class Fundings : ICloneable
    {

        public Kind GetKind()
        {
            return Enums.ToEnumByDescription<Kind>(Name);
        }

        public bool IsValid
        {
            get
            {
                if (Validation == ValidationType.None)
                    return true;

                if (Validation == ValidationType.EMail)
                    return Mails.IsValid(Address);
                else if (Validation == ValidationType.Bitcoin)
                    return Bitcoin.IsValid(Address);
                else if (Validation == ValidationType.Bitcoin)
                    return Litecoin.IsValid(Address);

                throw new Exception("Validation Type Not supported");
            }
        }

        public string ValidationResult
        {
            get
            {
                if (Validation == ValidationType.None)
                    return null;

                if (Validation == ValidationType.EMail)
                {
                    if (Mails.IsValid(Address))
                        return "passed";
                    else return "wrong email format";
                }
                else if (Validation == ValidationType.Bitcoin)
                    return "wrong Bitcoin wallet address, " + Bitcoin.ValidateAddress(Address);
                else if (Validation == ValidationType.Litecoin)
                    return "wrong Litecoin wallet address, " + Litecoin.ValidateAddress(Address);

                throw new Exception("Validation Type Not supported");
            }
        }


        public Kraken.Asset Asset { get; private set; }

        public AccountType Type { get; private set; }

        public ValidationType Validation { get; private set; }

        public bool AddressRequired { get; set; } = false;
        public bool TagRequired { get; set; } = false;

        public string Name { get; private set; }
        public string Descripton { get; set; }
        public string Address { get; set; }
        public string Tag { get; set; }
    }
}