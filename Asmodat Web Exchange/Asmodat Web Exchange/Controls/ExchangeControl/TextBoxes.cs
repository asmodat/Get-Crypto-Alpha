using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Asmodat.Abbreviate;
using Asmodat.Kraken;

using Asmodat.Extensions;
using Asmodat.Extensions.Objects;
using AsmodatMath;

namespace Asmodat_Web_Exchange
{
    public partial class ExchangeControl : System.Web.UI.UserControl
    {
        private void InitializeTextBoxes()
        {
            if (SManager == null)
                return;

            ExchangeSettings settings = SManager.CalculateExchangeSettings(Manager);

            if (settings == null || settings.Error)
                return;

            if (SManager.AssetPrimary.IsFixed)
            {
                #region Setup Primary

                if (!settings.Primary.IsAmountValid) //incorrect amoont outsoide of limmits
                {
                    string fromat = string.Format("<b>Warning ! </b> Primary value of {0} <b>{1}</b> is out of allowed range min {2}, max {3}"
                        , settings.Primary.Amount, settings.Primary.Asset.GetEnumName(), settings.Primary.MinAmount, settings.Primary.MaxAmount);
                    AlertsControlPrimary.ShowWarning(fromat);
                }

                if (UTbxAmountSecondary.Text.ParseDecimal(-1) != settings.Secondary.Amount)
                    UTbxAmountSecondaryReset(true);

                #endregion
            }
            else if (SManager.AssetSecondary.IsFixed)
            {
                #region Setup Secondary
                

                if (!settings.Secondary.IsAmountValid) //incorrect amoont outsoide of limmits
                {
                    string fromat = string.Format("<b>Warning ! </b>Secondary value of {0} <b>{1}</b> is out of allowed range min {2}, max {3}"
                        , settings.Secondary.Amount, settings.Secondary.Asset.GetEnumName(), settings.Secondary.MinAmount, settings.Secondary.MaxAmount);
                    AlertsControlSecondary.ShowWarning(fromat);
                }

                if (UTbxAmountPrimary.Text.ParseDecimal(-1) != settings.Primary.Amount)
                    UTbxAmountPrimaryReset(true);

                #endregion
            }

            this.InitializeTextBoxesColors();
        }

        private void InitializeTextBoxesColors()
        {
            if (SManager == null || !SManager.AssetPrimary.IsValid() || !SManager.AssetSecondary.IsValid())
                return;


            if (SManager.AssetPrimary.IsFixed)
            {
                if (SManager.AssetSecondary.Buy)
                    UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkGreen;
                else if (SManager.AssetSecondary.Sell)
                    UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkRed;

                UTbxAmountSecondary.Update();
            }

            if (SManager.AssetSecondary.IsFixed)
            {
                if (SManager.AssetPrimary.Buy)
                    UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkGreen;
                else if (SManager.AssetPrimary.Sell)
                    UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkRed;

                UTbxAmountPrimary.Update();
            }
                
            
        }
    }
}


/*
private void InitializeTextBoxesColors()
        {
            if (SManager == null || SManager.AssetPrimary.Asset == null || SManager.AssetSecondary.Asset == null)
                return;

            Ticker ticker = Manager.Kraken.Tickers.GetAny(SManager.AssetPrimary.Asset.Value, SManager.AssetSecondary.Asset.Value);

            if (ticker == null)
                return;

            Kraken.Asset primary = SManager.AssetPrimary.Asset.Value;
            Kraken.Asset secondary = SManager.AssetSecondary.Asset.Value;
            Kraken.Asset _base = ticker.AssetBase.Value;
            Kraken.Asset _quote = ticker.AssetQuote.Value;
            InfoTicker info = SManager.InfoTickers(ticker.Name);

            if (SManager.AssetPrimary.IsFixed)
            {
                #region color secondary
                if (primary == _base)
                {
                    if (SManager.AssetPrimary.Buy)
                    {
                        if (info.IsAskUp)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsAskDown)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (SManager.AssetPrimary.Sell)
                    {
                        if (info.IsBidUp)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsBidDown)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                else if (primary == _quote)
                {
                    if (SManager.AssetPrimary.Buy)
                    {
                        if (info.IsBidUp)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsBidDown)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (SManager.AssetPrimary.Sell)
                    {
                        if (info.IsAskUp)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsAskDown)
                            UTbxAmountSecondary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                #endregion

                UTbxAmountSecondary.Update(); //update secondary always is not fixed
            }
            else if (SManager.AssetSecondary.IsFixed)
            {
                #region color primary
                if (secondary == _base)
                {
                    if (SManager.AssetSecondary.Buy)
                    {
                        if (info.IsAskUp)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsAskDown)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (SManager.AssetSecondary.Sell)
                    {
                        if (info.IsBidUp)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsBidDown)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                else if (secondary == _quote)
                {
                    if (SManager.AssetSecondary.Buy)
                    {
                        if (info.IsBidUp)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsBidDown)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                    else if (SManager.AssetSecondary.Sell)
                    {
                        if (info.IsAskUp)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkGreen;
                        else if (info.IsAskDown)
                            UTbxAmountPrimary.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                #endregion

                UTbxAmountPrimary.Update(); //update primary always is not fixed
            }
        }
    
    */
