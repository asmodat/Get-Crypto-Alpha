
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
<system.web>
    <pages>
      <controls>
        <add tagPrefix="asm" namespace="AsmodatASP.Controls" assembly="AsmodatASP"/>
      </controls>
    </pages>
  </system.web>
*/

namespace Asmodat_Web_Exchange
{
    public partial class BaseDropDownList : System.Web.UI.WebControls.DropDownList
    {



        





    }
}

/*

    protected override ControlCollection CreateControlCollection()
        {
            return new ControlCollection(this);
        }

protected override ControlCollection CreateControlCollection()
        {
            return new ControlCollection(this);
        }

 private bool boolRequired;
        private BaseValidator ctrValidator;

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            ctrValidator.RenderControl(writer);

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (this.Required)
                this.AddRequiredFieldValidator();
        }

        public bool Required
        {
            get
            {
                return this.boolRequired;
            }
            set
            {
                this.boolRequired = value;
            }
        }

        public void AddRequiredFieldValidator()
        {
            ctrValidator = new RequiredFieldValidator();
            ctrValidator.Text = "*";

            if (ctrValidator != null)
            {
                ctrValidator.ControlToValidate = this.ID;
                ctrValidator.EnableClientScript = true;
                ctrValidator.Display = ValidatorDisplay.Dynamic;
                if (this.ValidationGroup != String.Empty)
                    ctrValidator.ValidationGroup = this.ValidationGroup;

                base.Controls.Add(ctrValidator);
            }
        }
*/
