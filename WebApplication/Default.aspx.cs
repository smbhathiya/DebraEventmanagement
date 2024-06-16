using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.PartnerServiceReference;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    LoadUserEvents(email);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void LoadUserEvents(string email)
        {
            PartnerWebServicesSoapClient service = new PartnerWebServicesSoapClient();

            DataSet eventsDataSet = service.GetEventsByUserEmail(email);

            if (eventsDataSet != null && eventsDataSet.Tables.Count > 0 && eventsDataSet.Tables[0].Rows.Count > 0)
            {
                gvEvents.DataSource = eventsDataSet.Tables[0];
                gvEvents.DataBind();
            }
            else
            {
                // No events found for the user
                gvEvents.DataSource = null;
                gvEvents.DataBind();
            }
        }

        protected void AddEventtodb_Click(object sender, EventArgs e)
        {
            string eventId = eventidtxtbox.Text;
            string eventName = eventnametxtbox.Text;
            string ticketPrice = ticketPriceTxtBox.Text;
            string email = Session["Email"]?.ToString();
            string date = datbox.Text;
            string time = TextBox5.Text;
            string location = TextBox6.Text;

            PartnerWebServicesSoapClient service = new PartnerWebServicesSoapClient();

            string result = service.AddEvent(eventId, eventName, ticketPrice, email, date, time, location);

            // Refresh the GridView after adding the event
            LoadUserEvents(email);

            // Display the result
            Response.Write("<script>alert('" + result + "');</script>");
        }


        protected void gvEvents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEvents.EditIndex = e.NewEditIndex;
            string email = Session["Email"]?.ToString();
            LoadUserEvents(email);
        }

        protected void gvEvents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvEvents.EditIndex = -1;
                string email = Session["Email"]?.ToString();
                LoadUserEvents(email);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }


        protected void gvEvents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvEvents.Rows[e.RowIndex];
                string eventId = gvEvents.DataKeys[e.RowIndex].Value.ToString();
                string eventName = (row.FindControl("txtEventName") as TextBox).Text;
                string ticketPrice = (row.FindControl("txtTicketPrice") as TextBox).Text;
                string date = (row.FindControl("txtDate") as TextBox).Text;
                string time = (row.FindControl("txtTime") as TextBox).Text;
                string location = (row.FindControl("txtLocation") as TextBox).Text;

                // Call the service method to update the event
                PartnerWebServicesSoapClient service = new PartnerWebServicesSoapClient();
                string result = service.UpdateEvent(eventId, eventName, ticketPrice, date, time, location);

                // Exit edit mode
                gvEvents.EditIndex = -1;

                // Reload the GridView
                string email = Session["Email"]?.ToString();
                LoadUserEvents(email);

                // Show the result
                Response.Write("<script>alert('" + result + "');</script>");
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }




        protected void btnSearch_Click1(object sender, EventArgs e)
        {
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
        }





        protected void DeleteEvent_Click(object sender, EventArgs e)
        {

            string eventId = ((LinkButton)sender).CommandArgument;
            DeleteEvent(eventId);
        }

        private void DeleteEvent(string eventId)
        {
            PartnerWebServicesSoapClient service = new PartnerWebServicesSoapClient();
            string result = service.DeleteEvent(eventId);


            if (Session["Email"] != null)
            {
                string email = Session["Email"].ToString();
                LoadUserEvents(email);
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
                    // Get the event ID from the DataKeys collection
                    string eventId = gvEvents.DataKeys[rowIndex]["eventid"].ToString();

                    // Show confirmation dialog before proceeding with delete
                    string confirmScript = $"return confirmDelete('{eventId}');";
                    gvEvents.Attributes["onclick"] = confirmScript;

                    // Cancel the delete operation until confirmation is received
                    e.Cancel = true;
                }
                else
                {
                    // Handle the case where the RowIndex is out of range
                    throw new ArgumentOutOfRangeException("RowIndex is out of range.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or display an error message
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }



    }
}
