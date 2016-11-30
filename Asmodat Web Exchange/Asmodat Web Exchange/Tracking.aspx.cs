using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class Tracking : System.Web.UI.Page
    {
        public static ExchangeManager Manager = ExchangeManager.Instance;
        public SessionManager SManager { get; set; } = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (SManager == null)
            {
                SManager = new SessionManager(Session);
                TrackingControl.SManager = SManager;
            }
        }
    }
}