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

    
    public class InfoFunding
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

        public InfoFunding(System.Web.SessionState.HttpSessionState Session, string IDName)
        {
            this.IDName = IDName;
            this.Session = Session;
        }

        

        public Fundings Fundings
        {
            get
            {
                return Session.GetValue(ID, (Fundings)null);
            }
            set
            {
                Session.SetValue(ID, value);
            }
        }


        public string Name
        {
            get
            {
                if (Fundings == null) return null;
                else return Fundings.Name;
            }
        }

        public string Address
        {
            get
            {
                if (Fundings == null) return null;
                else return Fundings.Address;
            }
            set
            {
                if (Fundings != null)
                    Fundings.Address = value;
            }
        }

        public string Tag
        {
            get
            {
                if (Fundings == null) return null;
                else return Fundings.Tag;
            }
            set
            {
                if (Fundings != null)
                    Fundings.Tag = value;
            }
        }

        public bool UpdateAllCotrols
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
    }
}