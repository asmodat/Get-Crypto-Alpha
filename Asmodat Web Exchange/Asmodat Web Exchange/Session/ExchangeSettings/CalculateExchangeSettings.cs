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
using Asmodat.Extensions.Objects;

namespace Asmodat_Web_Exchange
{

    public class ExchangeAsset
    {
        public Kraken.Asset Asset { get; set; }
        public Asset Info { get; set; }
        public int DisplayDecimals { get; set; }

        public decimal Amount { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }

        public bool IsAmountValid
        {
            get
            {
                return Amount.InRange(MinAmount, MaxAmount);
            }
        }
    }

    public class ExchangeSettings
    {
        public ExchangeAsset Primary { get; set; } = null;
        public ExchangeAsset Secondary { get; set; } = null;

        public bool Error { get; set; } = false;
        public string ErrorMessage { get; set; } = null;
    }

    public partial class SessionManager
    {
        public ExchangeSettings CalculateExchangeSettings(ExchangeManager Manager)
        {
            ExchangeSettings exchange = new ExchangeSettings();
            ExchangeAsset primary = new ExchangeAsset();
            ExchangeAsset secondary = new ExchangeAsset();

            if (Manager == null || AssetPrimary.Asset == null || AssetSecondary.Asset == null)
                return null;

            primary.Asset = AssetPrimary.Asset.Value;
            secondary.Asset = AssetSecondary.Asset.Value;
            primary.Info = Manager.Kraken.AssetInfo(primary.Asset);
            secondary.Info = Manager.Kraken.AssetInfo(secondary.Asset);
            primary.DisplayDecimals = primary.Info.GetDisplayDecimals(2);
            secondary.DisplayDecimals = secondary.Info.GetDisplayDecimals(2);

            //Get min and max amounts
            decimal[] min = Manager.Kraken.MinAmount(primary.Asset, secondary.Asset);
            decimal[] max = Manager.Kraken.MaxAmount(primary.Asset, secondary.Asset);//TODO: Fail secondary

            if (min == null || max == null || min[0] <= 0 || min[1] <= 0 || max[0] <= 0 || max[1] <= 0)
                return null;

            Ticker _ticker = Manager.Kraken.Tickers.GetAny(primary.Asset, secondary.Asset);
            Ticker ticker = Manager.Kraken.CalculateExchangeTicker(_ticker); //calculates ticker for income

            if (ticker == null || ticker.AssetBase == null || ticker.AssetQuote == null)
                return null;

            primary.MinAmount = Math.Round(min[0], primary.DisplayDecimals);
            primary.MaxAmount = Math.Round(max[0], primary.DisplayDecimals);
            secondary.MinAmount = Math.Round(min[1], secondary.DisplayDecimals);
            secondary.MaxAmount = Math.Round(max[1], secondary.DisplayDecimals);

            if (AssetPrimary.IsFixed)
            {
                #region Setup Primary
                primary.Amount = AssetPrimary.Amount;

                if (AssetPrimary.Buy)
                    secondary.Amount = ticker.BuyPrice(primary.Asset, primary.Amount);
                else if (AssetPrimary.Sell)
                    secondary.Amount = ticker.SellPrice(primary.Asset, primary.Amount);
                else
                    return null;

                AssetSecondary.Amount = Math.Round(secondary.Amount, secondary.DisplayDecimals);

                #endregion
            }
            else if (AssetSecondary.IsFixed)
            {
                #region Setup Secondary
                secondary.Amount = AssetSecondary.Amount;

                if (AssetSecondary.Buy)
                    primary.Amount = ticker.BuyPrice(secondary.Asset, secondary.Amount);
                else if (AssetSecondary.Sell)
                    primary.Amount = ticker.SellPrice(secondary.Asset, secondary.Amount);
                else
                    return null;

                AssetPrimary.Amount = Math.Round(primary.Amount, primary.DisplayDecimals);

                #endregion
            }
            else
                return null;



            exchange.Primary = primary;
            exchange.Secondary = secondary;

            return exchange;
        }

    }
}

