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
using AjaxControlToolkit;

//
namespace Asmodat_Web_Exchange
{
    public partial class Exchange : System.Web.UI.Page
    {

        public static ExchangeManager Manager = ExchangeManager.Instance;
        public SessionManager SManager { get; set; } = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SManager == null)
            {
                SManager = new SessionManager(Session);
                ExchangeControl.SManager = SManager;
                
                FundingsControl.SManager = SManager;
                OrderControl.SManager = SManager;
            }

            if (!IsPostBack)
            {
               
            }
        }

        
    }
}