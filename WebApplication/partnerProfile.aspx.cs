using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
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
         protected void gvUser_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUser.EditIndex = -1; 
            LoadUserData(Session["Email"].ToString());
        }

        protected void gvUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvUser.Rows[e.RowIndex];

                TextBox txtEmail = row.FindControl("txtEmail") as TextBox;
                TextBox txtCompanyName = row.FindControl("txtCompanyName") as TextBox;
                TextBox txtAddress = row.FindControl("txtAddress") as TextBox;
                TextBox txtContactNo = row.FindControl("txtContactNo") as TextBox;

                if (txtEmail == null || txtCompanyName == null || txtAddress == null || txtContactNo == null)
                {
                    throw new Exception("One or more controls were not found.");
                }

                string email = txtEmail.Text;
                string companyName = txtCompanyName.Text;
                string address = txtAddress.Text;
                string contactNo = txtContactNo.Text;

                var service = new PartnerWebServicesSoapClient();

                bool updateSuccess = service.UpdatePartnerByEmail(email, companyName, address, contactNo);

                if (updateSuccess)
                {
                    Response.Write("<script>alert('Update successful.');</script>");


                    gvUser.EditIndex = -1;

                    LoadUserData(email);
                }
                else
                {
                    throw new Exception("Update failed.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while updating the partner: " + ex.Message + "');</script>");
            }
        }

    }
}