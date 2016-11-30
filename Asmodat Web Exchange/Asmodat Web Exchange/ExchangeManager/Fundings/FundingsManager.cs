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


namespace Asmodat_Web_Exchange
{
    public class FundingsManager
    {
        public ThreadedList<Fundings> Fundings { get; set; } = null;

        public void Add(Fundings fundings)
        {
            if (fundings == null)
                return;

            Fundings.Add(fundings);
        }


        public Fundings Get(Fundings.AccountType type, Kraken.Asset asset, string name)
        {
            if (Fundings == null)
                return null;

            
            for (int i = 0; i < Fundings.Count; i++)
            {
                if (Fundings[i].Type == type && Fundings[i].Asset == asset && Fundings[i].Name == name)
                    return Fundings[i];
            }

            return null;
        }


        public Fundings[] Get(Fundings.AccountType type, Kraken.Asset asset)
        {
            if (Fundings == null)
                return null;

            List<Fundings> fundings = new List<Fundings>();

            for(int i = 0; i < Fundings.Count; i++)
            {
                if (Fundings[i].Type == type && Fundings[i].Asset == asset)
                    fundings.Add(Fundings[i]);
            }

            return fundings.ToArray();
        }

        public FundingsManager()
        {
            Fundings = new ThreadedList<Fundings>();
        }
    }
}