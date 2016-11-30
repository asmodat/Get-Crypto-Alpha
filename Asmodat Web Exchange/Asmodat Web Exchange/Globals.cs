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
    /*
    public sealed partial class Globals
    {
        private static Globals _instance;
        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Globals();
                return _instance;
            }
        }

        public  BlockchainManager BlockManager { get; private set; }
        public  KrakenManager KrkManager { get; private set; }
        public  PayPalManager PayManager { get; private set; }
        public  ThreadedTimers Timers { get; private set; }

        public  void InitializeBlockManager()
        {
            if (BlockManager != null) return;

            //AsmodatWebExchange
            //adress: 16VMBZSL5nnipZrBpbCqZav3yX2XKufTgc
            string guid = @"a2b0da0c-a5f5-4d04-a359-67a314e89a40";
            string passmain = @"f5e8b53b7e5045cbe3692e61e7be0f8d";
            string passsecond = @"b4288f069f4c14520bd2900d8e792355";
            BlockManager = new BlockchainManager(guid, passmain, passsecond);

        }
        public  void InitializePayManager()
        {
            if (PayManager != null) return;

            //string clientid = @"AbBjjeTKyQsphXEnUaSvkRfmdFF4RycLHwTbFceUm4DiBCRtsu-84u1Tm4nsZWDYm9ZD4scerZOkiLHk";
            //string secret = @"ECgI2hKecEQ1ngb3DdKs5DgBrZ8k-RBDA8bYSt_OwFJlGoZiZnTn89hkmyOGJwyyG1yq59h4UvJ_wz1J";
            string sclientid = @"AXVgOS4m4HkjPvMRJtKAKBdcwUydIW_M7DfwE2YWLBP5oqh973jA8vNs4DOlf3Grr-fuFENvNEhuE9IX";
            string ssecret = @"ENjBeYjBU61f-sZyygWpTf4kL3brz5J-GtjrF4uxgQ2iFG8IWOQh9ObCaD6fvhEKHsAiql9SzUQHfxfP";

            PayManager = new PayPalManager(sclientid, ssecret, Asmodat.PayPal.Api.ApiProperties.ContextMode.sandbox);


        }
        public  void InitializeKrkManager()
        {
            if (KrkManager != null) return;

            string apikey = @"7Ghkrwm0k9mOaCox1P6YECaGaOk/HMclLIuYuUBqxFt4CFT9BXTwV2Ng";
            string privatekey = @"2gin1SU8hr5h8OqRdSlUeYih9FnbR7Z+p9QhRYnF2s7X8lrPaFX86sgX0AA4PeD0tOqkvB1LHoGN3vT/ynB3ng==";

            KrkManager = new KrakenManager(apikey, privatekey);
        }


        private Globals()
        {
            try
            {
                InitializeBlockManager();
                InitializePayManager();
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }

            InitializeKrkManager();
        }


    }*/
}
/*
public static void InitializeBitManager()
        {
            if (BitManager != null) return;

            string apikey = @"1usOTC4WupqUy0PcjLjG5PZs3GZZB097jKIoHl4PhZo";
            string secret = @"rku0Hbi4VxCoRUCVeHmlg38U56SC9dP85cHzTvItMvb";
            BitManager = new BitfinexManager(apikey, secret);

        }
public static BitfinexManager BitManager = null;
*/
