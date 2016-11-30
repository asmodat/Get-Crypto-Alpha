using Asmodat.Abbreviate;
using Asmodat.Debugging;
using Asmodat.Kraken;
using Asmodat.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{

    public static class InfoExchangeSEx
    {
        public static bool IsValid(this InfoExchange info)
        {
                if (info != null && info.Asset != null && info.Asset.HasValue && info.Buy != info.Sell)
                    return true;

                return false;
        }
    }

    public class InfoExchange
    {
        private string ID
        {
            get
            {
                string format = string.Format("{0}-{1}", IDName, Objects.nameofmethod(2));
                if (!format.IsNullOrEmpty())
                {
                    format = format.Replace("get_", "");
                    format = format.Replace("set_", "");
                }

                return format;
            }
        }

        public System.Web.SessionState.HttpSessionState Session { get; private set; }
        public string IDName { get; private set; }

        public InfoExchange(System.Web.SessionState.HttpSessionState Session, string IDName)
        {
            this.IDName = IDName;
            this.Session = Session;
        }


        public string AssetName
        {
            get
            {
                return Session.GetValue(ID, (string)null);
            }
            set
            {
                Session.SetValue(ID, value);
            }
        }

        public Kraken.Asset? Asset
        {
            get
            {
                return Kraken.ToAsset(AssetName);
            }
            set
            {
                if (value == null || !value.HasValue)
                    AssetName = null;
                else
                    AssetName = value.Value.GetEnumName();
            }
        }

        public bool Buy
        {
            get
            {
                return Session.GetValue(ID, false);
            }
            set
            {
                if (Buy == value)
                    return;

                Session.SetValue(ID, value);
                Sell = !value;
            }
        }

        public bool Sell
        {
            get
            {
                return Session.GetValue(ID, false);
            }
            set
            {
                if (Sell == value)
                    return;

                Session.SetValue(ID, value);
                Buy = !value;
            }
        }

        /// <summary>
        /// Defines if exchange is fixed, if true then amount will not be updated, otherwise it might be updated to current market price
        /// </summary>
        public bool IsFixed
        {
            get
            {
                return Session.GetValue(ID, false);
            }
            set
            {
                Session.SetValue(ID, value);
            }
        }

        public decimal Amount
        {
            get
            {
                return Session.GetValue(ID, (decimal)0);
            }
            set
            {
                Session.SetValue(ID, value);
            }
        }




    }
}