using System;
using System.Data;
using System.Globalization;
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

            DateTime timeValue = DateTime.ParseExact(TextBox5.Text, "HH:mm", CultureInfo.InvariantCulture);
            string time = timeValue.ToString("hh:mm tt", CultureInfo.InvariantCulture);

            string location = TextBox6.Text;

            PartnerWebServicesSoapClient service = new PartnerWebServicesSoapClient();

            string result = service.AddEvent(eventId, eventName, ticketPrice, email, date, time, location);

            LoadUserEvents(email);

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

                // FindControl and null checks
                TextBox txtEventId = row.FindControl("txtEventId") as TextBox;
                TextBox txtEventName = row.FindControl("txtEventName") as TextBox;
                TextBox txtTicketPrice = row.FindControl("txtTicketPrice") as TextBox;
                TextBox txtDate = row.FindControl("txtDate") as TextBox;
                TextBox txtTime = row.FindControl("txtTime") as TextBox;
                TextBox txtLocation = row.FindControl("txtLocation") as TextBox;

                // Collect control statuses
                string missingControls = "";
                if (txtEventId == null) missingControls += "txtEventId, ";
                if (txtEventName == null) missingControls += "txtEventName, ";
                if (txtTicketPrice == null) missingControls += "txtTicketPrice, ";
                if (txtDate == null) missingControls += "txtDate, ";
                if (txtTime == null) missingControls += "txtTime, ";
                if (txtLocation == null) missingControls += "txtLocation, ";

                if (!string.IsNullOrEmpty(missingControls))
                {
                    // Remove the last comma and space
                    missingControls = missingControls.TrimEnd(',', ' ');
                    // Handle error
                    throw new Exception("The following controls were not found during the update process: " + missingControls);
                }

                string eventId = txtEventId.Text;
                string eventName = txtEventName.Text;
                string ticketPrice = txtTicketPrice.Text;
                string date = txtDate.Text;
                string time = txtTime.Text;
                string location = txtLocation.Text;

                DateTime timeValue;
                if (DateTime.TryParseExact(time, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out timeValue))
                {
                    string formattedTime = timeValue.ToString("hh:mm tt", CultureInfo.InvariantCulture);

                    PartnerWebServicesSoapClient service = new PartnerWebServicesSoapClient();
                    string result = service.UpdateEvent(eventId, eventName, ticketPrice, date, formattedTime, location);

                    if (!string.IsNullOrEmpty(result))
                    {
                        // Log result for debugging
                        Response.Write("<script>alert('Update Result: " + result + "');</script>");
                    }
                    else
                    {
                        throw new Exception("Update failed with an empty response.");
                    }

                    gvEvents.EditIndex = -1;
                    string email = Session["Email"]?.ToString();
                    LoadUserEvents(email);
                }
                else
                {
                    // Handle invalid time format
                    throw new FormatException("Invalid time format.");
                }
            }
            catch (Exception ex)
            {
                // Display the error message
                Response.Write("<script>alert('An error occurred while updating the event: " + ex.Message + "');</script>");
            }
        }




        protected void btnSearch_Click1(object sender, EventArgs e)
        {
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
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
