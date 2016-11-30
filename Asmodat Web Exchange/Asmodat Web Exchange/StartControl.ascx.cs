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
    public partial class StartControl : System.Web.UI.UserControl
    {
        /*  private string PropertyID
          {
              get
              {
                  string format = string.Format("{0}-{1}", nameof(StartControl), Objects.nameofmethod(2));
                  if (!format.IsNullOrEmpty())
                  {
                      format = format.Replace("get_", "");
                      format = format.Replace("set_", "");
                  }

                  return format;
              }
          }


          [PersistenceMode(PersistenceMode.Attribute)]
          public TickTime Time
          {
              get
              {
                  return Session.GetValue(PropertyID, TickTime.Default);
              }
              set
              {
                  Session.SetValue(PropertyID, value);
              }
          }*/


        public SessionManager SManager { get; set; } = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(SManager == null)  SManager = new SessionManager(Session);

            if (!IsPostBack)
            {
                //var v = Context.Session;  if (v == null)  return;

            }



            this.Update_LabelStartControlPrice();
        }

        private void Update_LabelStartControlPrice()
        {
            try
            {

                if (SManager == null)
                    return;

                //InfoTicker BTCUSD = SManager.InfoTickers("BTCUSD");
                InfoTicker BTCEUR = SManager.InfoTickers("XXBTZEUR");// "BTCEUR");

                if (BTCEUR != null)
                {
                    string fontAsk = "<font color=\"Black\">";
                    string fontBid = "<font color=\"Black\">";

                    if (BTCEUR.IsAskUp)
                        fontAsk = "<font color=\"DarkGreen\">";
                    else if (BTCEUR.IsAskDown)
                        fontAsk = "<font color=\"DarkRed\">";

                    if (BTCEUR.IsBidUp)
                        fontBid = "<font color=\"DarkGreen\">";
                    else if (BTCEUR.IsBidDown)
                        fontBid = "<font color=\"DarkRed\">";

                    LblStartControlAsk.Text = string.Format("{0}<b>{1:#,##,###,0.00}</b></font>", fontAsk, BTCEUR.Ask);
                    LblStartControlBid.Text = string.Format("{0}<b>{1:#,##,###,0.00}</b></font>", fontBid, BTCEUR.Bid);
                }


                
                LblStartControlTime.Text = string.Format("* Server Timestamp: <b>{0}</b>", SManager.ServerTime.ToString("yyyy/MM/dd T hh:mm:ss.fff UTC"));

                UpdPnlMarketPrice.Update();
            }
            catch (Exception ex)
            {
                ex.ToOutput();
            }
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            try
            {
                Button tbx = (Button)sender;
                string[] result = Strings.Split(tbx.Text, ' ').ToArray();
                SManager.AssetPrimary.Asset = Kraken.ToAsset(result[1]);
                SManager.AssetPrimary.Buy = true;
                SManager.AssetPrimary.Amount = 1;
                SManager.AssetPrimary.IsFixed = true;
                SManager.AssetSecondary.Asset = Kraken.Asset.EUR;
                SManager.AssetSecondary.Sell = true;
            }
            catch(Exception ex)
            {
                ex.ToOutput();
            }

            Response.Redirect("Exchange.aspx");
        }

        protected void  Sell_Click(object sender, EventArgs e)
        {
            try
            {
                Button tbx = (Button)sender;
                string[] result = Strings.Split(tbx.Text, ' ').ToArray();
                SManager.AssetPrimary.Asset = Kraken.ToAsset(result[1]);
                SManager.AssetPrimary.Sell = true;
                SManager.AssetPrimary.Amount = 1;
                SManager.AssetPrimary.IsFixed = true;
                SManager.AssetSecondary.Asset = Kraken.Asset.EUR;
                SManager.AssetSecondary.Buy = true;
            }
            catch (Exception ex)
            {
                ex.ToOutput();
            }

            Response.Redirect("Exchange.aspx");
        }
    }
}

/*

    //InfoTicker BTCUSD = SManager.InfoTickers("BTCUSD");
                InfoTicker BTCEUR = SManager.InfoTickers("BTCEUR");

                if (BTCUSD != null)
                {
                    string fontAsk = "<font color=\"Black\">";
                    string fontBid = "<font color=\"Black\">";

                    if (BTCUSD.IsAskUp)
                        fontAsk = "<font color=\"DarkGreen\">";
                    else if (BTCUSD.IsAskDown)
                        fontAsk = "<font color=\"DarkRed\">";

                    if (BTCUSD.IsBidUp)
                        fontBid = "<font color=\"DarkGreen\">";
                    else if (BTCUSD.IsBidDown)
                        fontBid = "<font color=\"DarkRed\">";

                    LblStartControlPriceBTCUSD_Ask.Text = string.Format("{0}<b>{1:#,##,###,0.00}</b></font>", fontAsk, BTCUSD.Ask);
                    LblStartControlPriceBTCUSD_Bid.Text = string.Format("{0}<b>{1:#,##,###,0.00}</b></font>", fontBid, BTCUSD.Bid);
                }

                if (BTCEUR != null)
                {
                    string fontAsk = "<font color=\"Black\">";
                    string fontBid = "<font color=\"Black\">";

                    if (BTCEUR.IsAskUp)
                        fontAsk = "<font color=\"DarkGreen\">";
                    else if (BTCEUR.IsAskDown)
                        fontAsk = "<font color=\"DarkRed\">";

                    if (BTCEUR.IsBidUp)
                        fontBid = "<font color=\"DarkGreen\">";
                    else if (BTCEUR.IsBidDown)
                        fontBid = "<font color=\"DarkRed\">";

                    LblStartControlPriceBTCEUR_Ask.Text = string.Format("{0}<b>{1:#,##,###,0.00}</b></font>", fontAsk, BTCEUR.Ask);
                    LblStartControlPriceBTCEUR_Bid.Text = string.Format("{0}<b>{1:#,##,###,0.00}</b></font>", fontBid, BTCEUR.Bid);
                }


    [PersistenceMode(PersistenceMode.Attribute)]
        public bool IsPriceUp
        {
            get
            {
                string id = string.Format("{0}", "StartControl_IsPriceUp");

                if (Session[id] != null)
                {
                    try
                    {
                        return bool.Parse(Session[id].ToString());
                    }
                    catch (Exception ex)
                    {
                        ex.ToOutput();
                    }
                }

                return false;
            }
            set
            {
                string id = string.Format("{0}", "StartControl_IsPriceUp");
                Session[id] = value;
            }
        }
        [PersistenceMode(PersistenceMode.Attribute)]
        public bool IsPriceDown
        {
            get
            {
                if (Session["StartControl_IsPriceDown"] != null)
                {
                    try
                    {
                        return bool.Parse(Session["StartControl_IsPriceDown"].ToString());
                    }
                    catch (Exception ex)
                    {
                        ex.ToOutput();
                    }
                }

                return false;
            }
            set
            {
                Session["StartControl_IsPriceDown"] = value;
            }
        }
        [PersistenceMode(PersistenceMode.Attribute)]
        public decimal Price
        {
            get
            {

                if (Session["StartControl_Price"] != null)
                {
                    try
                    {
                        return decimal.Parse(Session["StartControl_Price"].ToString());
                    }
                    catch (Exception ex)
                    {
                        ex.ToOutput();
                    }
                }

                return 0;
            }
            set
            {

                try
                {
                    decimal last = decimal.Parse(Session["StartControl_Price"].ToString());
                    if (last > value)
                    {
                        IsPriceUp = false;
                        IsPriceDown = true;
                    }
                    else if (last < value)
                    {
                        IsPriceUp = true;
                        IsPriceDown = false;
                    }
                }
                catch (Exception ex)
                {
                    ex.ToOutput();
                }

                Session["StartControl_Price"] = value;
            }
        }

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
    public partial class StartControl : System.Web.UI.UserControl
    {
        [PersistenceMode(PersistenceMode.Attribute)]
        public TickTime Time
        {
            get
            {

                if (Session["StartControl_Time"] != null)
                {
                    try
                    {
                        
                        return TickTime.Parse(Session["StartControl_Time"].ToString());
                    }
                    catch (Exception ex)
                    {
                        ex.ToOutput();
                    }
                }

                return TickTime.Default;
            }
            set
            {
                Session["StartControl_Time"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Price = 0;
            }

            this.Update_LabelStartControlPrice();
        }

        private void Update_LabelStartControlPrice()
        {
            try
            {
                
                string fontPrice = "<font color=\"Black\">";

                if (IsPriceUp)
                    fontPrice = "<font color=\"DarkGreen\">";
                else if (IsPriceDown)
                    fontPrice = "<font color=\"DarkRed\">";

                LblStartControlPrice.Text = string.Format("{0}<b>{1:#,##,###,0.00}</b></font>", fontPrice, this.Price);

                LblStartControlTime.Text = string.Format("* Server Timestamp: <b>{0}</b>", this.Time.ToString("yyyy/MM/dd T hh:mm:ss.fff UTC"));

                UpdPnlMarketPrice.Update();
            }
            catch(Exception ex)
            {
                ex.ToOutput();
            }
        }
    }
}*/
