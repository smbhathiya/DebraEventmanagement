using System;
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
                if (result.StartsWith("Login successful"))
                {
                    string[] parts = result.Split('|');
                    string userType = parts[1];

                    Session["Email"] = txtEmail.Text;
                    Session["UserType"] = userType;

                    if (userType == "user")
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else if (userType == "partner")
                    {
                        Response.Redirect("PartnerDashboard.aspx");
                    }
                    else if (userType == "admin")
                    {
                        Response.Redirect("AdminDashboard.aspx");
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('" + result + "');", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('An error occurred: " + ex.Message + "');", true);
            }
        }
    }
}
