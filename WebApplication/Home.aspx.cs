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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    ViewEvents(null, null);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void ViewEvents(object sender, EventArgs e)
        {
            try
            {
                UserWebServiceSoapClient service = new UserWebServiceSoapClient(); 
                DataSet ds = service.ViewAllEvents();
                if (ds != null && ds.Tables.Count > 0)
                {
                    EventRepeater.DataSource = ds.Tables[0];
                    EventRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }

    }
}