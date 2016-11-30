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
        private void InitializeDeposit()
        {
            if (SManager == null) return;

            InfoExchange info = SManager.AssetSell;

            if (!info.IsValid()) return;

            Fundings[] fundings = Manager.Fundings.Get(Fundings.AccountType.Deposit, info.Asset.Value);
            Fundings[] results = UDdlDeposit.AddItems(fundings);


            if (!results.ContainsType(SManager.FundingDeposit.Fundings))
                SManager.FundingDeposit.Fundings = null;

            if (SManager.FundingDeposit.Fundings == null && UDdlDeposit.Items.Count > 0)
            {
                UDdlDeposit.SelectedIndex = 0;
                SManager.FundingDeposit.Fundings = results[UDdlDeposit.SelectedIndex];
            }

            if (SManager.FundingDeposit.Fundings != null)
                UDdlDeposit.SelectValue(SManager.FundingDeposit.Fundings.Name);
            
        }
        
        private void InitializeWithdraw()
        {
            if (SManager == null) return;

            InfoExchange info = SManager.AssetBuy;

            if (!info.IsValid()) return;

            Fundings[] fundings = Manager.Fundings.Get(Fundings.AccountType.Withdraw, info.Asset.Value);
            Fundings[] results = UDdlWithdraw.AddItems(fundings);

            if (!results.ContainsType(SManager.FundingWithdraw.Fundings))
                SManager.FundingWithdraw.Fundings = null;

            if (SManager.FundingWithdraw.Fundings == null && UDdlWithdraw.Items.Count > 0)
            {
                UDdlWithdraw.SelectedIndex = 0;
                SManager.FundingWithdraw.Fundings = results[UDdlWithdraw.SelectedIndex];
            }

            if (SManager.FundingWithdraw.Fundings != null)
                UDdlWithdraw.SelectValue(SManager.FundingWithdraw.Fundings.Name);
        }
    }
}