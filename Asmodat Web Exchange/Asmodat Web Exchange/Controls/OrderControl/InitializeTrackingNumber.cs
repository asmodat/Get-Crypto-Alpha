using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AsmodatMath;
using Asmodat.Cryptography;
using Asmodat.Abbreviate;

namespace Asmodat_Web_Exchange
{

    //<span class="input-group-addon asm-font-18px asm-height-46px" id="AdnOrderTrackingNr">Tracking number: </span>

    public partial class OrderControl : System.Web.UI.UserControl
    {

        private void InitializeTrackingNumber(bool _new)
        {
            string value = SManager.ExchangeOrder.TrackingNumber;

            if (_new || value.IsNullOrWhiteSpace() || value.Length != 24)
                value = AUID.NewString(24);

            SManager.ExchangeOrder.TrackingNumber = value;

            TbxOrderTrackingNr.Text = value;
        }

    }
}