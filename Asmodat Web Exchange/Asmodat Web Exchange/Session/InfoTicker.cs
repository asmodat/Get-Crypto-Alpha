using Asmodat.Abbreviate;
using Asmodat.Debugging;
using Asmodat.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public class InfoTicker
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

        public InfoTicker(System.Web.SessionState.HttpSessionState Session, string IDName)
        {
            this.IDName = IDName;
            this.Session = Session;
        }

        public bool IsAskUp
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

        public bool IsAskDown
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

        public bool IsBidUp
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

        public bool IsBidDown
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

        public decimal Ask
        {
            get
            {
                return Session.GetValue(ID, (decimal)0);
            }
            set
            {
                try
                {
                    decimal last = Ask;
                    decimal now = value;
                    if (last > now)
                    {
                        IsAskUp = false;
                        IsAskDown = true;
                    }
                    else if (last < now)
                    {
                        IsAskUp = true;
                        IsAskDown = false;
                    }

                }
                catch (Exception ex)
                {
                    ex.ToOutput();
                }

                Session.SetValue(ID, value);
            }
        }

        public decimal Bid
        {
            get
            {
                return Session.GetValue(ID, (decimal)0);
            }
            set
            {


                try
                {
                    decimal last = Bid;
                    decimal now = value;
                    if (last > now)
                    {
                        IsBidUp = false;
                        IsBidDown = true;
                    }
                    else if (last < now)
                    {
                        IsBidUp = true;
                        IsBidDown = false;
                    }

                }
                catch (Exception ex)
                {
                    ex.ToOutput();
                }

                Session.SetValue(ID, value);
            }
        }

        public decimal Mid
        {
            get
            {
                return (Ask + Bid) / 2;
            }
        }
    }
}