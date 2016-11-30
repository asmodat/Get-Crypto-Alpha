using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asmodat_Web_Exchange
{
    public partial class AlertsControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        public string DivOuterClass
        {
            get { return DivOuter.Attributes["class"]; }
            set { DivOuter.Attributes["class"] = value; }
        }


        public void HideAll()
        {
            this.HideDanger();
            this.HideInfo();
            this.HideSuccess();
            this.HideWarning();
        }

        #region Success
        public void HideSuccess()
        {
            PnlAlertsControl_Success.Visible = false;
            UpdPnlAlertsControl_Success.Update();
        }

        public void ShowSuccess()
        {
            PnlAlertsControl_Success.Visible = true;
            UpdPnlAlertsControl_Success.Update();
        }

        public void ShowSuccess(string text)
        {
            LblAlertsControl_Success.Text = text;
            this.ShowSuccess();
        }

        protected void BtnAlertsControl_Success_Click(object sender, EventArgs e)
        {
            this.HideSuccess();
        }
        #endregion

        #region Info
        public void HideInfo()
        {
            PnlAlertsControl_Info.Visible = false;
            UpdPnlAlertsControl_Info.Update();
        }

        public void ShowInfo()
        {
            PnlAlertsControl_Info.Visible = true;
            UpdPnlAlertsControl_Info.Update();
        }

        public void ShowInfo(string text)
        {
            LblAlertsControl_Info.Text = text;
            this.ShowInfo();
        }

        protected void BtnAlertsControl_Info_Click(object sender, EventArgs e)
        {
            this.HideInfo();
        }
        #endregion

        #region Warning
        public void HideWarning()
        {
            PnlAlertsControl_Warning.Visible = false;
            UpdPnlAlertsControl_Warning.Update();
        }

        public void ShowWarning()
        {
            PnlAlertsControl_Warning.Visible = true;
            UpdPnlAlertsControl_Warning.Update();
        }

        public void ShowWarning(string text)
        {
            LblAlertsControl_Warning.Text = text;
            this.ShowWarning();
        }

        protected void BtnAlertsControl_Warning_Click(object sender, EventArgs e)
        {
            this.HideWarning();
        }
        #endregion

        #region Danger
        public void HideDanger()
        {
            PnlAlertsControl_Danger.Visible = false;
            UpdPnlAlertsControl_Danger.Update();
        }

        public void ShowDanger()
        {
            PnlAlertsControl_Danger.Visible = true;
            UpdPnlAlertsControl_Danger.Update();
        }
    
        public void ShowDanger(string text)
        {
            LblAlertsControl_Danger.Text = text;
            this.ShowDanger();
        }

        protected void BtnAlertsControl_Danger_Click(object sender, EventArgs e)
        {
            this.HideDanger();
        }
        #endregion


    }
}