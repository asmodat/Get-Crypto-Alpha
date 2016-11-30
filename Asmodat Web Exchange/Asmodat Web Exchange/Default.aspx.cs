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
using Asmodat.Extensions.Objects;

using Asmodat.Cryptocurrency.Bitcoin;
using Asmodat.Cryptography;

namespace Asmodat_Web_Exchange
{
    public partial class Default : System.Web.UI.Page
    {
        //public static BlockchainManager BlockManager = Globals.Instance.BlockManager;
       // public static KrakenManager KrkManager = Globals.Instance.KrkManager;
        //public static PayPalManager PayManager = Globals.Instance.PayManager;

        public static ExchangeManager Manager = ExchangeManager.Instance;
        public static ThreadedTimers Timers = null;
        public SessionManager SManager;

        public void InitializeTimers()
        {
            if (Timers != null) return;

            Timers = new ThreadedTimers(10);

            Timers.Run(() => this.Update(), 1000, null, true, false);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /*AES256 aes256 = new AES256();
            List<string> str1 = new List<string>();
            List<string> str2 = new List<string>();

            string stest = "1";

            while (true)
            {
                str1.Clear(); str2.Clear();

                str1.Add(aes256.Encrypt(stest, "1"));
                str2.Add(aes256.Decrypt(str1[0], "1"));

                if (stest != str2[0])
                    return;
            }

            List<string> test = new List<string>();
            test.Add(Bitcoin.ValidateAddress("1AGNa15ZQXAZUgFiqJ2i7Z2DPU2J6hW62i"));
            test.Add(Bitcoin.ValidateAddress("355k8rNKAf7BRC7Avjg5wzAp7FUtTnn4kV"));*/
            if (SManager == null)
            {
                SManager = new SessionManager(Session);
                StartControl.SManager = SManager;
            }

            if (!IsPostBack)
            {
                InitializeTimers();
                ((ExchangeMaster)Master).NavbarSelectStart();
            }

           
            return;
        }

        
        public void Update()
        {
            if (Manager.Kraken.Tickers == null || Manager.Kraken.Tickers.Length <= 0)
                return;

            for (int i = 0; i < Manager.Kraken.Tickers.Length; i++)
            {
                Ticker _ticker = Manager.Kraken.Tickers[i];
                Ticker ticker = Manager.Kraken.CalculateExchangeTicker(_ticker); //calculates ticker for income

                if (ticker == null)
                    continue;

                InfoTicker infoTicker = SManager.InfoTickers(ticker.Name);
                infoTicker.Ask = ticker.BuyPrice(ticker.AssetBase.Value, 1);
                infoTicker.Bid = ticker.SellPrice(ticker.AssetBase.Value, 1);
            }

            if (Manager.Kraken == null || Manager.Kraken.ServerTime.IsDefault)
                return;

            SManager.ServerTime = Manager.Kraken.ServerTime;
        }

    }
}


/*
           Ticker BTCUSD = Manager.Kraken.Tickers.Get(Asmodat.Kraken.ApiProperties.Pairs.BTCUSD);
           Ticker BTCEUR = Manager.Kraken.Tickers.Get(Asmodat.Kraken.ApiProperties.Pairs.BTCEUR);




           if(BTCUSD != null)
           {
               InfoTicker IT_BTCUSD = SManager.InfoTickers("BTCUSD");
               InfoTicker IT_BTCEUR = SManager.InfoTickers("BTCEUR");
               IT_BTCEUR.Ask = BTCEUR.Ask[0];
               IT_BTCUSD.Ask = BTCUSD.Ask[0];
               IT_BTCEUR.Bid = BTCEUR.Bid[0];
               IT_BTCUSD.Bid = BTCUSD.Bid[0];

           }*/
