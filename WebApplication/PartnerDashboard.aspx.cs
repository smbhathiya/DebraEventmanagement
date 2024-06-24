using System;
using System.Data;
using System.Globalization;
using System.IO;
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
            var service = new PartnerWebServicesSoapClient();
            var eventsDataSet = service.GetEventsByUserEmail(email);

            if (eventsDataSet != null && eventsDataSet.Tables.Count > 0 && eventsDataSet.Tables[0].Rows.Count > 0)
            {
                var dt = eventsDataSet.Tables[0];
                dt.Columns.Add("FullImageUrl", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string imageUrl = row["imageUrl"].ToString();
                    string fullImageUrl = "https://localhost:44360/" + imageUrl;
                    row["FullImageUrl"] = fullImageUrl;
                }

                gvEvents.DataSource = dt;
                gvEvents.DataBind();
            }
            else
            {
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
            string time = DateTime.ParseExact(TextBox5.Text, "HH:mm", CultureInfo.InvariantCulture).ToString("hh:mm tt", CultureInfo.InvariantCulture);
            string location = TextBox6.Text;
            string description = TextBox7.Text;
            int remainingTickets = int.Parse(txtRemainingTickets.Text);

            byte[] imageData = null;
            if (FileUpload1.HasFile)
            {
                using (Stream fileStream = FileUpload1.PostedFile.InputStream)
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    imageData = reader.ReadBytes((int)fileStream.Length);
                }
            }

            var service = new PartnerWebServicesSoapClient();
            string result = service.AddEvent(eventId, eventName, ticketPrice, email, date, time, location, description, imageData, remainingTickets);

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
            gvEvents.EditIndex = -1;
            string email = Session["Email"]?.ToString();
            LoadUserEvents(email);
        }

        protected void gvEvents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvEvents.Rows[e.RowIndex];

                TextBox txtEventId = row.FindControl("txtEventId") as TextBox;
                TextBox txtEventName = row.FindControl("txtEventName") as TextBox;
                TextBox txtTicketPrice = row.FindControl("txtTicketPrice") as TextBox;
                TextBox txtDate = row.FindControl("txtDate") as TextBox;
                TextBox txtTime = row.FindControl("txtTime") as TextBox;
                TextBox txtLocation = row.FindControl("txtLocation") as TextBox;
                TextBox txtDescription = row.FindControl("txtDescription") as TextBox;
                FileUpload fileUpload = row.FindControl("fileUpload") as FileUpload;
                TextBox txtSoldTickets = row.FindControl("txtSoldTickets") as TextBox;
                TextBox txtRemainingTickets = row.FindControl("txtRemainingTickets") as TextBox;

                if (txtEventId == null || txtEventName == null || txtTicketPrice == null || txtDate == null || txtTime == null || txtLocation == null || txtDescription == null || fileUpload == null || txtSoldTickets == null || txtRemainingTickets == null)
                {
                    throw new Exception("One or more controls were not found.");
                }

                string eventId = txtEventId.Text;
                string eventName = txtEventName.Text;
                string ticketPrice = txtTicketPrice.Text;
                string date = txtDate.Text;
                string time = txtTime.Text;
                string location = txtLocation.Text;
                string description = txtDescription.Text;
                byte[] imageData = null;

                if (fileUpload.HasFile)
                {
                    using (Stream fileStream = fileUpload.PostedFile.InputStream)
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        imageData = reader.ReadBytes((int)fileStream.Length);
                    }
                }

                int soldTickets;
                if (!int.TryParse(txtSoldTickets.Text, out soldTickets))
                {
                    throw new Exception("Invalid format for Sold Tickets.");
                }

                int remainingTickets;
                if (!int.TryParse(txtRemainingTickets.Text, out remainingTickets))
                {
                    throw new Exception("Invalid format for Remaining Tickets.");
                }

                if (DateTime.TryParseExact(time, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime timeValue))
                {
                    string formattedTime = timeValue.ToString("hh:mm tt", CultureInfo.InvariantCulture);

                    var service = new PartnerWebServicesSoapClient();
                    string result = service.UpdateEvent(eventId, eventName, ticketPrice, date, formattedTime, location, description, imageData, soldTickets, remainingTickets);

                    if (!string.IsNullOrEmpty(result))
                    {
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
                    throw new FormatException("Invalid time format.");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('An error occurred while updating the event: " + ex.Message + "');</script>");
            }
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
            var service = new PartnerWebServicesSoapClient();
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
