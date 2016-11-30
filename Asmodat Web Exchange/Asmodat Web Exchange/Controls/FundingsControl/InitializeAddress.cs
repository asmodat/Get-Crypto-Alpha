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
    public partial class FundingsControl : System.Web.UI.UserControl
    {
        private void InitializeDepositAddress()
        {
            if (SManager == null ||
                SManager.FundingDeposit == null || SManager.FundingWithdraw == null ||
                SManager.FundingDeposit.Fundings == null ||
                UTbxDeposit.ReadOnly)
            {
                AlertsControlDeposit.HideWarning();
                return;
            }


            SManager.FundingDeposit.Fundings.Address = UTbxDeposit.Text;

            if(!SManager.FundingDeposit.Fundings.IsValid)
            {
                string format = string.Format("<b>Warning !</b> Deposit address is incorrect, validation result:  <b>{0}</b>", SManager.FundingDeposit.Fundings.ValidationResult);
                AlertsControlDeposit.ShowWarning(format);
            }
            else AlertsControlDeposit.HideWarning();
        }

        private void InitializeWithdrawAddress()
        {
            if (SManager == null || 
                SManager.FundingDeposit == null || SManager.FundingWithdraw == null|| 
                SManager.FundingWithdraw.Fundings == null || UTbxWithdraw.ReadOnly)
            {
                AlertsControlWithdraw.HideWarning();
                return;
            }

            SManager.FundingWithdraw.Fundings.Address = UTbxWithdraw.Text;

            if (!SManager.FundingWithdraw.Fundings.IsValid)
            {
                string format = string.Format("<b>Warning !</b> Withdraw address is incorrect, validation result: <b>{0}</b>", SManager.FundingWithdraw.Fundings.ValidationResult);
                AlertsControlWithdraw.ShowWarning(format);
            }
            else AlertsControlWithdraw.HideWarning();
        }
    }
}