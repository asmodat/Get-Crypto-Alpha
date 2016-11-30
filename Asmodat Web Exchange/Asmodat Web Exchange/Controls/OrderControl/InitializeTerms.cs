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

        public void InitializeTerms()
        {
            if (CmbxOrderAccept.Checked)
            {
                AlertsControlTerms.HideWarning();
                CmbxOrderAccept.BorderWidth = 0;
            }
            else
            {
                string format = string.Format("<b>Stop ! </b> To porceed you must first read and accept our <b>Terms and Conditions</b>, by checking 'I agree to'. ");
                AlertsControlTerms.ShowWarning(format);
                CmbxOrderAccept.BorderWidth = 1;
            }
        }

    }
}