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
    public  class ExchangeControlEx
    {
        public static int GetAssetIndex(UpdateDropDownList ddl, Kraken.Asset? asset, int defaultIndex = -1)
        {
            if (ddl == null || ddl.Items == null || ddl.Items.Count <= 0 || asset == null || !asset.HasValue)
                return -1;

            for (int i = 0; i < ddl.Items.Count; i++)
                if (asset.Value == Kraken.ToAsset(ddl.Items[i].Value))
                    return i;

            return defaultIndex;
        }

        public static void RemoveAsset(UpdateDropDownList ddl, Kraken.Asset? asset)
        {
            if (ddl == null || ddl.Items == null || ddl.Items.Count <= 0 || asset == null || !asset.HasValue)
                return;

            for (int i = 0; i < ddl.Items.Count; i++)
                if (asset.Value == Kraken.ToAsset(ddl.Items[i].Value))
                {
                    ddl.Items.RemoveAt(i);
                    RemoveAsset(ddl, asset);
                    return;
                }
        }

        public static void RemoveCurrencyNonIncluded(UpdateDropDownList ddl, Kraken.Currency[] currency)
        {
            if (ddl == null || ddl.Items == null || ddl.Items.Count <= 0 || currency == null || currency.Length <= 0)
                return;

            var list = currency.ToList();

            for (int i = 0; i < ddl.Items.Count; i++)
            {
                var nvalue = Kraken.ToCurrency(ddl.Items[i].Value);
                if (nvalue == null || !nvalue.HasValue)
                    continue;

                var value = nvalue.Value;

                if(!currency.Contains(value))
                {
                    ddl.Items.RemoveAt(i);
                    RemoveCurrencyNonIncluded(ddl, currency);
                    return;
                }
            }
        }

        /// <summary>
        /// Adds assets to DropDownList
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="assets"></param>
        public static void AddAssets(UpdateDropDownList ddl, Kraken.Asset[] assets)
        {
            if (ddl == null || ddl.Items == null || assets == null || assets.Length <= 0)
                return;

            foreach (var v in assets)
            {
                ListItem item = new ListItem();
                item.Text = v.GetEnumDescription();
                item.Value = v.GetEnumName();
                ddl.Items.Add(item);
            }
        }

        
    }
}