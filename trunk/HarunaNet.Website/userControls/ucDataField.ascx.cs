using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;

namespace HarunaNet.SisWeb.webUserControl
{
    public partial class ucDataField : System.Web.UI.UserControl
    {
        public event EventHandler CtrlTextChanged;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtData_TextChanged(object sender, EventArgs e)
        {
            OnCtrlTextChanged(); // raise the trlTextChanged event
        }
        
        protected virtual void OnCtrlTextChanged()
        {
            if (CtrlTextChanged != null)
                CtrlTextChanged(this, new EventArgs());
        }
        
        public string Text
        {
            get
            {
                return txtData.Text;
            }
            set
            {
                txtData.Text = value;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return txtData.ReadOnly;
            }
            set
            {
                txtData.ReadOnly = value;
                txtData.Enabled = !value;
                imgData.Enabled = !value;
                ceData.Enabled = !value;
            }
        }

        public Color BackColor
        {
            get
            {
                return txtData.BackColor;
            }
            set
            {
                txtData.BackColor = value;
            }
        }

        public bool Required
        {
            get
            {
                return rfvData.Enabled;
            }
            set
            {
                rfvData.Enabled = value;
            }
        }

        public bool ExibeCalendario
        {
            get
            {
                return imgData.Visible;
            }
            set
            {
                imgData.Visible = value;
            }
        }

        public ValidatorDisplay RequiredDisplay
        {
            get
            {
                return rfvData.Display;
            }
            set
            {
                rfvData.Display = value;
            }
        }

        public string RequiredErrorMessage
        {
            get
            {
                return rfvData.ErrorMessage;
            }
            set
            {
                rfvData.ErrorMessage = value;
            }
        }

        public string ValidationGroup
        {
            get
            {
                return rfvData.ValidationGroup;
            }
            set
            {
                rfvData.ValidationGroup = value;
                revData.ValidationGroup = value;
            }
        }

        public string OnTextChanged
        {
            get
            {
                return txtData.Attributes["OnTextChanged"];
            }
            set
            {
                txtData.Attributes.Add("OnTextChanged", value);

            }
        }

        protected void _TextChanged(object sender, EventArgs e)
        {
        }

        public bool AutoPostBack
        {
            get
            {
                return txtData.AutoPostBack;
            }
            set
            {
                txtData.AutoPostBack = value;
            }
        }


    }
}