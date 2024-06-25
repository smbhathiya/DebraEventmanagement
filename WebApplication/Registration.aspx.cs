using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.LoginServiceReference;
using WebApplication1.RegistrationServiceReference;

namespace WebApplication1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserRegister_Click(object sender, EventArgs e)
        {

            string userName = txtUserName.Text;
            string userEmail = txtUserEmail.Text;
            string userPassword = txtUserPassword.Text;
            string userAddress = txtUserAddress.Text;
            string userContact = txtUserContact.Text;

            RegistrationWebServiceSoapClient service = new RegistrationWebServiceSoapClient();
            string result = service.RegisterUser(userName, userEmail, userPassword, userAddress, userContact);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{result}');", true);

        }

        protected void PartnerRegister_Click(object sender, EventArgs e)
        {
            string partnerCompanyName = txtPartnerCompanyName.Text;
            string partnerEmail = txtPartnerEmail.Text;
            string partnerPassword = txtPartnerPassword.Text;
            string partnerAddress = txtPartnerAddress.Text;
            string partnerContact = txtPartnerContact.Text;

            RegistrationWebServiceSoapClient service = new RegistrationWebServiceSoapClient();
            string result = service.RegisterPartner(partnerCompanyName, partnerEmail, partnerPassword, partnerAddress, partnerContact);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{result}');", true);
        }
    }
}

