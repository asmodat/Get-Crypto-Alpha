using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class ExchangeMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void NavbarSelectStart()
        {
           liExchangeMasterStart.Attributes["class"] = "active";
        }
    }
}