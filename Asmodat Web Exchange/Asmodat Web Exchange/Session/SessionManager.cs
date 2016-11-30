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

    public partial class SessionManager
    {
        public System.Web.SessionState.HttpSessionState Session { get; private set; }

        public SessionManager(System.Web.SessionState.HttpSessionState Session)
        {
            this.Session = Session;
            AssetPrimary = new InfoExchange(Session, "ExchangeControl.AssetPrimary.");
            AssetSecondary = new InfoExchange(Session, "ExchangeControl.AssetSecondary.");
            FundingDeposit = new InfoFunding(Session, "FundingsControl.FundingDeposit.");
            FundingWithdraw = new InfoFunding(Session, "FundingsControl.FundingWithdraw.");
            ExchangeOrder = new InfoExchangeOrder(Session, "OrderControl.ExchangeOrder.");
            TrackingOrder = new InfoTracking(Session, "TrackingControl.TrackingOrder.");
        }

        private string ID
        {
            get
            {
                string format = string.Format("{0}-{1}", nameof(StartControl), Objects.nameofmethod(2));
                if (!format.IsNullOrEmpty())
                {
                    format = format.Replace("get_", "");
                    format = format.Replace("set_", "");
                }

                return format;
            }
        }




        #region Default
        public TickTime ServerTime
        {
            get
            {
                return Session.GetValue(ID, TickTime.Default);
            }
            set
            {
                Session.SetValue(ID, value);
            }
        }

        private Dictionary<string, InfoTicker> _InfoTickers = new Dictionary<string, InfoTicker>();

        public InfoTicker InfoTickers(string id)
        {
            if (id == null)
                return null;

            if(_InfoTickers == null)
                _InfoTickers = new Dictionary<string, InfoTicker>();

            if (!_InfoTickers.ContainsKey(id))
                _InfoTickers.Add(id, new InfoTicker(Session, "SessionManager.InfoTickers." + id));

            return _InfoTickers[id];
        }

        #endregion


        #region Exchange
        public InfoExchange AssetBuy
        {
            get
            {
                if (AssetPrimary == null || AssetSecondary == null) return null;

                if (AssetPrimary.Buy && AssetSecondary.Sell)
                    return AssetPrimary;
                else if (AssetPrimary.Sell && AssetSecondary.Buy)
                    return AssetSecondary;

                return null;
            }
        }
        public InfoExchange AssetSell
        {
            get
            {
                if (AssetPrimary == null || AssetSecondary == null) return null;

                if (AssetPrimary.Buy && AssetSecondary.Sell)
                    return AssetSecondary;
                else if (AssetPrimary.Sell && AssetSecondary.Buy)
                    return AssetPrimary;

                return null;
            }
        }

        public InfoExchange AssetPrimary { get; private set; }
        public InfoExchange AssetSecondary { get; private set; }


        public InfoFunding FundingDeposit { get; private set; }
        public InfoFunding FundingWithdraw { get; private set; }


        public InfoExchangeOrder ExchangeOrder { get; private set; }

        #endregion


        #region Tracking

        public InfoTracking TrackingOrder;

        #endregion

    }
}

/* public bool UpdateAllCotrols
        {
            get
            {
                return Session.GetValue(ID, false);
            }
            set
            {
                Session.SetValue(ID, value);
            }
        }*/

/*
public InfoTicker InfoTickers(string id)
        {
            if (id == null)
                return null;

            if (!_InfoTickers.ContainsKey(id))
            {
                _InfoTickers = new Dictionary<string, InfoTicker>();
                _InfoTickers[id] = new InfoTicker(Session, "SessionManager.InfoTickers." + id);
            }

            return _InfoTickers[id];
        }
    

public static void InitializeBitManager()
        {
            if (BitManager != null) return;

            string apikey = @"1usOTC4WupqUy0PcjLjG5PZs3GZZB097jKIoHl4PhZo";
            string secret = @"rku0Hbi4VxCoRUCVeHmlg38U56SC9dP85cHzTvItMvb";
            BitManager = new BitfinexManager(apikey, secret);

        }
public static BitfinexManager BitManager = null;
*/
