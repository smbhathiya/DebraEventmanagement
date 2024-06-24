using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.PartnerServiceReference;

namespace WebApplication1
{
    public partial class partnerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    LoadUserData(email);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }


        private void LoadUserData(string email)
        {
            var service = new PartnerWebServicesSoapClient();
            try
            {
                var eventsDataSet = service.GetPartnerByEmail(email);

                if (eventsDataSet != null && eventsDataSet.Tables.Count > 0 && eventsDataSet.Tables[0].Rows.Count > 0)
                {
                    gvUser.DataSource = eventsDataSet.Tables[0];
                    gvUser.DataBind();
                }
                else
                {
                    gvUser.DataSource = null;
                    gvUser.DataBind();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                service.Close(); 
            }
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void gvUser_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUser.EditIndex = e.NewEditIndex;
            LoadUserData(Session["Email"].ToString());
        }

        protected void gvUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUser.Rows[e.RowIndex];
            int userId = Convert.ToInt32(gvUser.DataKeys[e.RowIndex].Value);

            TextBox txtCompanyName = (TextBox)row.FindControl("txtEventName");
            TextBox txtEmail = (TextBox)row.FindControl("txtEmail");
            TextBox txtAddress = (TextBox)row.FindControl("txtAddress");
            TextBox txtContactNo = (TextBox)row.FindControl("txtContactNo");

            // Update logic here

            gvUser.EditIndex = -1; // Exit edit mode
            LoadUserData(Session["Email"].ToString());
        }

        protected void gvUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUser.EditIndex = -1; // Exit edit mode
            LoadUserData(Session["Email"].ToString());
        }

    }
}