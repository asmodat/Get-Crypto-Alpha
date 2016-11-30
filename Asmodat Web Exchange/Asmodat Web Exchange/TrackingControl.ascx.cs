using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Asmodat.Abbreviate;

namespace Asmodat_Web_Exchange
{
    public partial class TrackingControl : System.Web.UI.UserControl
    {
        public static ExchangeManager Manager = ExchangeManager.Instance;
        public SessionManager SManager { get; set; } = null;

        //http://localhost:52092/Tracking.aspx?TrackingNumber=76clSNoHhjKEm8Z4z6AMptL6&paymentId=PAY-1SG13167EP1790334KYW6ZII&token=EC-1R6717736W827472B&PayerID=UG67LBDGTVXY6
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SManager == null || SManager.TrackingOrder == null) return;

                SManager.TrackingOrder.TrackingNumber = Request.QueryString["TrackingNumber"];
                SManager.TrackingOrder.PayPal.PaymentID = Request.QueryString["paymentId"];
                SManager.TrackingOrder.PayPal.Token = Request.QueryString["token"];
                SManager.TrackingOrder.PayPal.PayerID = Request.QueryString["PayerID"];

            }
        }
    }
}