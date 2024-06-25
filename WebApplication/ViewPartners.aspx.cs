using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.AdminServiceReference;
using WebApplication1.UserWebServiceReference;

namespace WebApplication1
{
    public partial class ViewPartners : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    LoadPartners();
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

        private void LoadPartners()
        {
            try
            {
                var service = new AdminWebServicesSoapClient();
                DataSet ds = service.GetPartners();

                gvPartners.DataSource = ds.Tables["Partners"];
                gvPartners.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while loading partners: " + ex.Message + "');</script>");
            }
        }

        protected void DeleteEvent_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkDelete = (LinkButton)sender;
                string email = lnkDelete.CommandArgument;

                var service = new AdminWebServicesSoapClient();
                bool deleteSuccess = service.DeletePartnerByEmail(email);

                if (deleteSuccess)
                {
                    LoadPartners(); 
                    Response.Write("<script>alert('Partner deleted successfully.');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Delete operation failed.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while deleting the partner: " + ex.Message + "');</script>");
            }
        }
    }
}
