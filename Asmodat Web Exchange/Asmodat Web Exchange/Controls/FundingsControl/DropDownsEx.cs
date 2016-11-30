using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asmodat.Abbreviate;
using Asmodat.Kraken;

namespace Asmodat_Web_Exchange
{
    public static class FundingsControlEx
    {
        public static ListItem ToListItem(this Fundings fundings)
        {
            if (fundings == null)
                return null;

            ListItem item = new ListItem();
            item.Text = fundings.Name;
            item.Value = fundings.Name;
            return item;
        }

        public static Fundings[] AddItems(this UpdateDropDownList uddl, Fundings[] fundings)
        {
            List<Fundings> added = new List<Fundings>();

            if (uddl == null || fundings == null)
                return added.ToArray();

            uddl.Items.Clear();

            foreach (Fundings funding in fundings)
            {
                ListItem item = funding.ToListItem();
                if (item != null)
                {
                    uddl.Items.Add(item);
                    added.Add(funding.Copy());
                }
            }

            return added.ToArray();
        }

        public static void Select(this UpdateDropDownList uddl, Fundings fundings)
        {
            if (uddl == null || uddl.Items == null || fundings == null)
                return;

            ListItem item = fundings.ToListItem();

            if(item != null)
                uddl.SelectValue(item.Value);
        }

    }
}