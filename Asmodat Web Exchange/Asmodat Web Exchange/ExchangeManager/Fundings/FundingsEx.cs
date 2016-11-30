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

namespace Asmodat_Web_Exchange
{
   
    public static class FundingsEx
    {
        /// <summary>
        /// Defines if array contains similar fundings by its name, asset and validation type
        /// </summary>
        /// <param name="fundings"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ContainsType(this Fundings[] fundings, Fundings value)
        {
            if (fundings == null || fundings.Length <= 0 || value == null)
                return false;

            foreach(Fundings f in fundings)
            {
                if (f.EqualsType(value))
                    return true;
            }

            return false;
        }

        public static bool EqualsType(this Fundings fundings, Fundings value)
        {
            if (fundings == null || value == null)
                return false;
            
                if (
                fundings.Address == value.Address && 
                fundings.Asset == value.Asset && 
                fundings.Validation == value.Validation)
                    return true;

            return false;
        }


        
    }
}