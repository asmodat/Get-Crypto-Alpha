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
        private void InitializeDepositFundinng()
        {
            if (SManager == null || SManager.FundingDeposit == null || SManager.FundingWithdraw == null)
                return;

            InfoExchange info = SManager.AssetSell;

            if (!info.IsValid()) return;

            Fundings fundings = Manager.Fundings.Get(Fundings.AccountType.Deposit, info.Asset.Value, UDdlDeposit.Text);

            if (fundings != null)
            {
                SManager.FundingDeposit.Fundings = fundings.Copy();
                UTbxDeposit.Text = "";
            }
            else
            {
                SManager.FundingDeposit.Fundings = null;
                return;
            }

            if (!SManager.FundingDeposit.Fundings.AddressRequired)
            {
                UTbxDeposit.Text = "Address not required";
                UTbxDeposit.ReadOnly = true;
            }
            else
            {
                UTbxDeposit.Text = SManager.FundingDeposit.Address;
                UTbxDeposit.ReadOnly = false;
            }
        }

        private void InitializeWithdrawFundinng()
        {
            if (SManager == null || SManager.FundingDeposit == null || SManager.FundingWithdraw == null)
                return;

            InfoExchange info = SManager.AssetBuy;

            if (!info.IsValid()) return;

            Fundings fundings = Manager.Fundings.Get(Fundings.AccountType.Withdraw, info.Asset.Value, UDdlWithdraw.Text);

            if (fundings != null)
            {
                SManager.FundingWithdraw.Fundings = fundings.Copy();
                UTbxWithdraw.Text = null;
            }
            else
            {
                SManager.FundingWithdraw.Fundings = null;
                return;
            }


            if (!SManager.FundingWithdraw.Fundings.AddressRequired)
            {
                UTbxWithdraw.Text = "Address not required";
                UTbxWithdraw.ReadOnly = true;
            }
            else
            {
                UTbxWithdraw.Text = SManager.FundingWithdraw.Address;
                UTbxWithdraw.ReadOnly = false;
            }

        }
    }
}