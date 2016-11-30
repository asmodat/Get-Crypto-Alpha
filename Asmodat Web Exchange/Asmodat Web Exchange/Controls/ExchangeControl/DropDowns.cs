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
    public partial class ExchangeControl : System.Web.UI.UserControl
    {


        private void InitializeDropDowns()
        {
            var currency = Manager.Kraken.AvailableCurrency();
            UDdlCurrencyPrimary.Items.Clear();
            UDdlCurrencySecondary.Items.Clear();

            bool primarysell = SManager.AssetPrimary.Sell;

            #region fill up sell item based on buy item
            if (primarysell)
            {
                var asset = SManager.AssetSecondary.Asset;
                var assets = Manager.Kraken.TradableAsset(asset);
                ExchangeControlEx.AddAssets(UDdlCurrencyPrimary, assets);
                ExchangeControlEx.RemoveAsset(UDdlCurrencyPrimary, SManager.AssetSecondary.Asset);
                ExchangeControlEx.RemoveCurrencyNonIncluded(UDdlCurrencyPrimary, currency);
            }
            else
            {
                var asset = SManager.AssetPrimary.Asset;
                var assets = Manager.Kraken.TradableAsset(asset);
                ExchangeControlEx.AddAssets(UDdlCurrencySecondary, assets);
                ExchangeControlEx.RemoveAsset(UDdlCurrencySecondary, SManager.AssetPrimary.Asset);
                ExchangeControlEx.RemoveCurrencyNonIncluded(UDdlCurrencySecondary, currency);
            }

            #endregion

            #region Select sell item
            if (primarysell)
            {
                var asset = SManager.AssetPrimary.Asset;

                for (int i = 0; i < UDdlCurrencyPrimary.Items.Count; i++)
                {
                    string value = UDdlCurrencyPrimary.Items[i].Value;
                    var current = Kraken.ToAsset(value);
                    if (asset == null || !asset.HasValue || asset.Value == current.Value)
                    {
                        SManager.AssetPrimary.AssetName = value;
                        UDdlCurrencyPrimary.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                var asset = SManager.AssetSecondary.Asset;

                for (int i = 0; i < UDdlCurrencySecondary.Items.Count; i++)
                {
                    string value = UDdlCurrencySecondary.Items[i].Value;
                    var current = Kraken.ToAsset(value);
                    if (asset == null || !asset.HasValue || asset.Value == current.Value)
                    {
                        SManager.AssetSecondary.AssetName = value;
                        UDdlCurrencySecondary.SelectedIndex = i;
                        break;
                    }
                }
            }
            #endregion

            #region fill up buy item based on selected sell item
            if (primarysell)
            {
                var asset = SManager.AssetPrimary.Asset;
                var assets = Manager.Kraken.TradableAsset(asset);
                ExchangeControlEx.AddAssets(UDdlCurrencySecondary, assets);
                //don't repeat values from assets and only use available currency
                ExchangeControlEx.RemoveAsset(UDdlCurrencySecondary, SManager.AssetPrimary.Asset);
                ExchangeControlEx.RemoveCurrencyNonIncluded(UDdlCurrencySecondary, currency);
            }
            else
            {
                var asset = SManager.AssetSecondary.Asset;
                var assets = Manager.Kraken.TradableAsset(asset);
                ExchangeControlEx.AddAssets(UDdlCurrencyPrimary, assets);
                ExchangeControlEx.RemoveAsset(UDdlCurrencyPrimary, SManager.AssetSecondary.Asset);
                ExchangeControlEx.RemoveCurrencyNonIncluded(UDdlCurrencyPrimary, currency);
            }
            #endregion

            #region Select buy item
            if (primarysell)
            {
                int idx = ExchangeControlEx.GetAssetIndex(UDdlCurrencySecondary, SManager.AssetSecondary.Asset, 0);

                if(idx > 0)
                {
                    UDdlCurrencySecondary.SelectedIndex = idx;
                    SManager.AssetSecondary.AssetName = UDdlCurrencySecondary.Items[idx].Value;
                }
            }
            else
            {
                int idx = ExchangeControlEx.GetAssetIndex(UDdlCurrencyPrimary, SManager.AssetPrimary.Asset, 0);

                if (idx > 0)
                {
                    UDdlCurrencyPrimary.SelectedIndex = idx;
                    SManager.AssetPrimary.AssetName = UDdlCurrencyPrimary.Items[idx].Value;
                }
            }
            #endregion

        }

        /*
        if (primarysell)
                this.RemoveAsset(UDdlCurrencyPrimary, SManager.AssetSecondary.Asset);
            else
                this.RemoveAsset(UDdlCurrencySecondary, SManager.AssetPrimary.Asset);


        if (primarysell) //don't repeat values from assets and only use available currency
            {
                this.RemoveAsset(UDdlCurrencySecondary, SManager.AssetPrimary.Asset);
                this.RemoveCurrencyNonIncluded(UDdlCurrencySecondary, currency);
            }
            else
            {
                this.RemoveAsset(UDdlCurrencyPrimary, SManager.AssetSecondary.Asset);
                this.RemoveCurrencyNonIncluded(UDdlCurrencyPrimary, currency);
            }
            */


        protected void DdlCurrencyPrimary_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = ((DropDownList)sender);
            if (value == null || !Kraken.IsAsset(value.SelectedItem.Value))
                return;

            SManager.AssetPrimary.AssetName = value.SelectedItem.Value;
            this.UpdateAll();
        }

        protected void DdlCurrencySecondary_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = ((DropDownList)sender);
            if (value == null || !Kraken.IsAsset(value.SelectedItem.Value))
                return;

            SManager.AssetSecondary.AssetName = value.SelectedItem.Value;
            this.UpdateAll();
        }

        

    }
}


/*
private void InitializeDropDowns()
        {
            var currency = Manager.Kraken.AvailableCurrency();
            UDdlCurrencyPrimary.Items.Clear();
            UDdlCurrencySecondary.Items.Clear();

            bool primarysell = SManager.AssetPrimary.Sell;
            //bool secondarysell = SManager.AssetSecondary.Sell;

            #region fill up sell items
            if (currency != null) //Load availible currency into sell dropdown
                foreach (var v in currency)
                {
                    ListItem item = new ListItem();
                    item.Text = v.GetEnumDescription();
                    item.Value = v.GetEnumName();
                    if (primarysell)
                        UDdlCurrencyPrimary.Items.Add(item);
                    else
                        UDdlCurrencySecondary.Items.Add(item);
                }

            Kraken.Cryptocurrency[] quote = Manager.Kraken.TradableCryptocurrency();

            if (quote != null) //load all tradable cryptocurrency to sell dropdown
                foreach (var v in quote)
                {
                    ListItem item = new ListItem();
                    item.Text = v.GetEnumDescription();
                    item.Value = v.GetEnumName();
                    if (primarysell)
                        UDdlCurrencyPrimary.Items.Add(item);
                    else
                        UDdlCurrencySecondary.Items.Add(item);
                }
           
            if (primarysell)
                ExchangeControlEx.RemoveAsset(UDdlCurrencyPrimary, SManager.AssetSecondary.Asset);
            else
                ExchangeControlEx.RemoveAsset(UDdlCurrencySecondary, SManager.AssetPrimary.Asset);
            #endregion

            #region Select sell item
            if (primarysell)
            {
                var asset = SManager.AssetPrimary.Asset;

                for (int i = 0; i < UDdlCurrencyPrimary.Items.Count; i++)
                {
                    string value = UDdlCurrencyPrimary.Items[i].Value;
                    var current = Kraken.ToAsset(value);
                    if (asset == null || !asset.HasValue || asset.Value == current.Value)
                    {
                        SManager.AssetPrimary.AssetName = value;
                        UDdlCurrencyPrimary.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                var asset = SManager.AssetSecondary.Asset;

                for (int i = 0; i < UDdlCurrencySecondary.Items.Count; i++)
                {
                    string value = UDdlCurrencySecondary.Items[i].Value;
                    var current = Kraken.ToAsset(value);
                    if (asset == null || !asset.HasValue || asset.Value == current.Value)
                    {
                        SManager.AssetSecondary.AssetName = value;
                        UDdlCurrencySecondary.SelectedIndex = i;
                        break;
                    }
                }
            }
            #endregion

            #region fill up buy item based on selected sell item
            if (primarysell)
            {
                var asset = SManager.AssetPrimary.Asset;
                var assets = Manager.Kraken.TradableAsset(asset);
                ExchangeControlEx.AddAssets(UDdlCurrencySecondary, assets);
            }
            else
            {
                var asset = SManager.AssetSecondary.Asset;
                var assets = Manager.Kraken.TradableAsset(asset);
                ExchangeControlEx.AddAssets(UDdlCurrencyPrimary, assets);
            }

            if (primarysell) //don't repeat values from assets and only use available currency
            {
                ExchangeControlEx.RemoveAsset(UDdlCurrencySecondary, SManager.AssetPrimary.Asset);
                ExchangeControlEx.RemoveCurrencyNonIncluded(UDdlCurrencySecondary, currency);
            }
            else
            {
                ExchangeControlEx.RemoveAsset(UDdlCurrencyPrimary, SManager.AssetSecondary.Asset);
                ExchangeControlEx.RemoveCurrencyNonIncluded(UDdlCurrencyPrimary, currency);
            }


            #endregion

            #region Select buy item
            if (primarysell)
            {
                int idx = ExchangeControlEx.GetAssetIndex(UDdlCurrencySecondary, SManager.AssetSecondary.Asset, 0);

                if(idx > 0)
                {
                    UDdlCurrencySecondary.SelectedIndex = idx;
                    SManager.AssetSecondary.AssetName = UDdlCurrencySecondary.Items[idx].Value;
                }
            }
            else
            {
                int idx = ExchangeControlEx.GetAssetIndex(UDdlCurrencyPrimary, SManager.AssetPrimary.Asset, 0);

                if (idx > 0)
                {
                    UDdlCurrencyPrimary.SelectedIndex = idx;
                    SManager.AssetPrimary.AssetName = UDdlCurrencyPrimary.Items[idx].Value;
                }
            }
            #endregion

        }

*/
