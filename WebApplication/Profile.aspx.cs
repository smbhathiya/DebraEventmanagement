using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.UserWebServiceReference;

namespace WebApplication1
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                GetUserPurchasedTickets(email);

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void GetUserPurchasedTickets(string email)
        {
            try
            {
                UserWebServiceSoapClient client = new UserWebServiceSoapClient();
                DataSet ds = client.GetUserPurchasedTickets(email);
                if (ds.Tables.Count > 0)
                {
                    GridViewPurchasedTickets.DataSource = ds.Tables[0];
                    GridViewPurchasedTickets.DataBind();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }


    }
}
