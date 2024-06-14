using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.LoginServiceReference;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                LoginWebServiceSoapClient service = new LoginWebServiceSoapClient();
                string result = service.Login(txtEmail.Text, txtPassword.Text);

                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('" + result + "');", true);

                if (result == "Login successful")
                {
                    Response.Redirect("default.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('An error occurred: " + ex.Message + "');", true);
            }
        }

    }
}