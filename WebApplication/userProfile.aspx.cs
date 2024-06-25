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
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    GetUserPurchasedTickets(email);
                    LoadUserData(email);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
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

        private void LoadUserData(string email)
        {
            var service = new UserWebServiceSoapClient();
            try
            {
                var eventsDataSet = service.GetUserByEmail(email);

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
                TextBox txtName = row.FindControl("txtName") as TextBox;
                TextBox txtAddress = row.FindControl("txtAddress") as TextBox;
                TextBox txtContactNo = row.FindControl("txtContactNo") as TextBox;

                if (txtEmail == null || txtName == null || txtAddress == null || txtContactNo == null)
                {
                    throw new Exception("One or more controls were not found.");
                }

                string email = txtEmail.Text;
                string name = txtName.Text;
                string address = txtAddress.Text;
                string contactNo = txtContactNo.Text;

                // Log the values to check what is being passed
                System.Diagnostics.Debug.WriteLine("Email: " + email);
                System.Diagnostics.Debug.WriteLine("Name: " + name);
                System.Diagnostics.Debug.WriteLine("Address: " + address);
                System.Diagnostics.Debug.WriteLine("ContactNo: " + contactNo);

                var service = new UserWebServiceSoapClient();

                bool updateSuccess = service.UpdateUserByEmail(email, name, address, contactNo);

                if (updateSuccess)
                {
                    gvUser.EditIndex = -1;
                    GetUserPurchasedTickets(email);
                    LoadUserData(email);
                    Response.Write("<script>alert('Update successful.');</script>");
                }
                else
                {
                    throw new Exception("Update failed.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while updating the user: " + ex.Message + "');</script>");
            }
        }

    }
}
