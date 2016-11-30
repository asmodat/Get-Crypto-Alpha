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

using Asmodat.Cryptocurrency.Bitcoin;
using Asmodat.Cryptocurrency.Litecoin;
using Newtonsoft.Json;
using Asmodat.Networking;
using System.ComponentModel;

using Asmodat.IO;

namespace Asmodat_Web_Exchange
{
    

    public partial class OrdersManager
    {
        public string Path
        {
            get
            {
                string path = HttpContext.Current.Server.MapPath("~/DataBase");

                if (path.IsNullOrWhiteSpace())
                    return null;

                Directories.Create(path);

                return path;
            }
        }
       

        public JsonDataBase<OrderJson> Data { get; set; }

        public OrdersManager()
        {
            Data = new JsonDataBase<OrderJson>(Path, true, true, null);
        }

        public bool Contains(string key)
        {
            return Data.Contains(key);
        }

        public OrderJson Get(string key)
        {
            return Data.Get(key);
        }

        public void Set(string key, OrderJson value)
        {
            Data.Set(key, value, true);
        }

        public void Romove(string key)
        {
            Data.Remove(key, true);
        }

    }
}