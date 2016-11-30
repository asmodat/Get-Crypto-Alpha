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

    public partial class ExchangeManager
    {
        private static ExchangeManager _instance;
        public static ExchangeManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ExchangeManager();
                return _instance;
            }
        }

        public BlockchainManager Blockchain { get; private set; }
        public KrakenManager Kraken { get; private set; }
        public PayPalManager PayPal { get; private set; }
        public FundingsManager Fundings { get; private set; }

        public OrdersManager Orders { get; private set; }

        public ThreadedTimers Timers { get; private set; }

        


        public void InitializeBlockManager()
        {
            if (Blockchain != null) return;
            
            string guid = @"qwertyuiop";
            string passmain = @"qwertyuiop";
            string passsecond = @"qwertyuiop";
            Blockchain = new BlockchainManager(guid, passmain, passsecond);

        }
        public void InitializePayManager()
        {
            if (PayPal != null) return;
            
            string sclientid = @"qwertyuiop";
            string ssecret = @"qwertyuiop";

            PayPal = new PayPalManager(sclientid, ssecret, Asmodat.PayPal.Api.ApiProperties.ContextMode.sandbox);


        }
        public void InitializeKrkManager()
        {
            if (Kraken != null) return;

            string apikey = @"qwertyuiop";
            string privatekey = @"qwertyuiop";

            Kraken = new KrakenManager(apikey, privatekey);
        }

        public void InitializeOrdersManager()
        {
            Orders = new OrdersManager();
        }



        public void InitializeFundingsManager()
        {
            Fundings = new FundingsManager();

            Fundings fundings = new Fundings(
                Asmodat_Web_Exchange.Fundings.Kind.PayPal,
                Asmodat.Kraken.Kraken.Asset.EUR, 
                Asmodat_Web_Exchange.Fundings.AccountType.Withdraw,
                Asmodat_Web_Exchange.Fundings.ValidationType.EMail);
            fundings.AddressRequired = true;
            Fundings.Add(fundings);

            Fundings fundings4 = new Fundings(
                Asmodat_Web_Exchange.Fundings.Kind.Bitcoin, 
                Asmodat.Kraken.Kraken.Asset.XBT,
                Asmodat_Web_Exchange.Fundings.AccountType.Withdraw,
                Asmodat_Web_Exchange.Fundings.ValidationType.Bitcoin);
            fundings4.AddressRequired = true;
            Fundings.Add(fundings4);

            Fundings fundings2 = new Fundings(
                Asmodat_Web_Exchange.Fundings.Kind.PayPal, 
                Asmodat.Kraken.Kraken.Asset.EUR,
                Asmodat_Web_Exchange.Fundings.AccountType.Deposit,
                Asmodat_Web_Exchange.Fundings.ValidationType.None);
            fundings2.AddressRequired = false;
            Fundings.Add(fundings2);

            Fundings fundings3 = new Fundings(
                Asmodat_Web_Exchange.Fundings.Kind.Bitcoin,
                Asmodat.Kraken.Kraken.Asset.XBT,
                Asmodat_Web_Exchange.Fundings.AccountType.Deposit,
                Asmodat_Web_Exchange.Fundings.ValidationType.Bitcoin);
            fundings3.AddressRequired = true;
            Fundings.Add(fundings3);
        }

        private ExchangeManager()
        {
            try
            {
                this.InitializeBlockManager();
                this.InitializePayManager();
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }

            this.InitializeKrkManager();
            this.InitializeFundingsManager();
            this.InitializeOrdersManager();
        }

    }
}