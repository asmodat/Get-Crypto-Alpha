using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class FundingsControl : System.Web.UI.UserControl
    {
        public static ExchangeManager Manager = ExchangeManager.Instance;
        public SessionManager SManager { get; set; } = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            UTbxDeposit.ChangeClear();
            UTbxWithdraw.ChangeClear();

            if (!IsPostBack)
            {
                this.UpdateAll();
            }

            if (SManager == null || SManager.FundingDeposit == null || SManager.FundingWithdraw == null)
                return;

            if (SManager.FundingDeposit.UpdateAllCotrols && SManager.FundingWithdraw.UpdateAllCotrols)
            {
                UpdateAll();
            }
        }

        public void UpdateAll()
        {
            if (SManager == null || SManager.FundingDeposit == null || SManager.FundingWithdraw == null) return;

            this.InitializeDeposit();
            this.InitializeWithdraw();

            UDdlDeposit.Update();
            UDdlWithdraw.Update();

            this.InitializeDepositFundinng();
            this.InitializeWithdrawFundinng();

            this.InitializeDepositAddress();
            this.InitializeWithdrawAddress();

            UTbxDeposit.Update();
            UTbxWithdraw.Update();

            

            SManager.FundingDeposit.UpdateAllCotrols = false;
            SManager.FundingWithdraw.UpdateAllCotrols = false;
        }

        protected void TimrFundingsControl_Tick(object sender, EventArgs e)
        {
            if (SManager == null || SManager.FundingDeposit == null || SManager.FundingWithdraw == null)
                return;

            if (SManager.FundingDeposit.UpdateAllCotrols && SManager.FundingWithdraw.UpdateAllCotrols)
            {
                UpdateAll();

            }
        }

        protected void UTbxDeposit_TextChanged(object sender, EventArgs e)
        {
            this.InitializeDepositAddress();

        }

        protected void UTbxWithdraw_TextChanged(object sender, EventArgs e)
        {
            this.InitializeWithdrawAddress();
        }


        protected void UDdlDeposit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateAll();
        }

        protected void UDdlWithdraw_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateAll();
        }


        

    }
}