using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.AdminServiceReference;

namespace WebApplication1
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    ViewEvents();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void ViewEvents()
        {
            try
            {
                var service = new AdminWebServicesSoapClient();
                var eventsDataSet = service.GetAllEvents();

                if (eventsDataSet != null && eventsDataSet.Tables.Count > 0 && eventsDataSet.Tables[0].Rows.Count > 0)
                {
                    var dt = eventsDataSet.Tables[0];

                    gvEvents.DataSource = null;

                    gvEvents.DataSource = dt;
                    gvEvents.DataBind();
                }
                else
                {
                    gvEvents.DataSource = null;
                    gvEvents.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving events: " + ex.Message);
            }
        }


        protected void gvEvents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvEvents.Rows[e.RowIndex];
                Label lblEventId = row.FindControl("lblEventId") as Label;
                string eventId = lblEventId.Text;
                TextBox txtCommissionRate = row.FindControl("txtCommissionRate") as TextBox;

                if (decimal.TryParse(txtCommissionRate.Text, out decimal newCommissionRate))
                {
                    UpdateCommission(eventId, newCommissionRate);
                    // Exit edit mode
                    gvEvents.EditIndex = -1;
                    // Rebind GridView to reflect changes
                    ViewEvents();
                }
                else
                {
                    // Handle invalid input
                    Response.Write("<script>alert('Please enter a valid commission rate.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Handle the exception
                Response.Write($"<script>alert('An error occurred while updating commission rate: {ex.Message}');</script>");
            }
        }

        private void UpdateCommission(string eventId, decimal newCommissionRate)
        {
            try
            {
                var service = new AdminWebServicesSoapClient();
                string result = service.UpdateCommissionRate(eventId, newCommissionRate);

                // Show result to the user
                Response.Write("<script>alert('" + result + "');</script>");
            }
            catch (Exception ex)
            {
                // Handle exception
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
        }



        protected void gvEvents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEvents.EditIndex = e.NewEditIndex;
            ViewEvents();
        }

        protected void gvEvents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEvents.EditIndex = -1;
            ViewEvents();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            // Implement search functionality
        }

        protected void DeleteEvent_Click(object sender, EventArgs e)
        {
            string eventId = ((LinkButton)sender).CommandArgument;
            DeleteEvent(eventId);
        }

        private void DeleteEvent(string eventId)
        {
            var service = new AdminWebServicesSoapClient();
            string result = service.DeleteEvent(eventId);

            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                ViewEvents();
            }

            Response.Write("<script>alert('" + result + "');</script>");
        }

        protected void gvEvents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;

                if (rowIndex >= 0 && rowIndex < gvEvents.Rows.Count)
                {
                    string eventId = gvEvents.DataKeys[rowIndex]["eventid"].ToString();
                    string confirmScript = $"return confirmDelete('{eventId}');";
                    gvEvents.Attributes["onclick"] = confirmScript;

                    e.Cancel = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("RowIndex is out of range.");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}