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

    
    public class InfoExchangeOrder
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

        public InfoExchangeOrder(System.Web.SessionState.HttpSessionState Session, string IDName)
        {
            this.IDName = IDName;
            this.Session = Session;
        }


        public TickTime TimeoutWarningsExecute
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


        public string TrackingNumber
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


        
    }
}