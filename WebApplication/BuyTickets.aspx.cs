using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.UserWebServiceReference;
using WebApplication1.BuyTicketsServiceReference;

namespace WebApplication1
{
    public partial class BuyTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] != null)
                {
                    string eventId = Request.QueryString["eventId"];
                    string email = Session["Email"].ToString();
                    LoadEventDetails(eventId);

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
                BuyTicketsWebServiceSoapClient service = new BuyTicketsWebServiceSoapClient();

            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        private void LoadEventDetails(string eventId)
        {
            try
            {
                BuyTicketsWebServiceSoapClient service = new BuyTicketsWebServiceSoapClient();
                DataSet ds = service.ViewEvent(eventId);

                if (ds.Tables["Events"].Rows.Count > 0)
                {
                    DataRow row = ds.Tables["Events"].Rows[0];
                    lblEventNameValue.Text = row["event_name"].ToString();
                    lblDescriptionValue.Text = row["description"].ToString();
                    imgEvent.ImageUrl = row["imageUrl"].ToString();
                    lblDateValue.Text = Convert.ToDateTime(row["date"]).ToString("yyyy-MM-dd");
                    lblTimeValue.Text = row["time"].ToString();
                    lblLocationValue.Text = row["location"].ToString();
                    lblTicketPriceValue.Text = row["ticket_price"].ToString();
                    lblCompanyNameValue.Text = row["company_name"].ToString();
                    lblRemainingTicketsValue.Text = row["remainingTickets"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred: " + ex.Message);
            }
        }

        protected void btnBuyTickets_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    string eventId = Request.QueryString["eventId"];
                    int ticketCount = int.Parse(txtTicketCount.Text);

                    BuyTicketsWebServiceSoapClient service = new BuyTicketsWebServiceSoapClient();
                    decimal totalPrice = service.CalculateTotalPrice(eventId, ticketCount);

                    // Redirect to Payment Portal with necessary details
                    string redirectUrl = $"PaymentPortal.aspx?eventId={eventId}&ticketCount={ticketCount}&totalPrice={totalPrice}&email={email}";
                    Response.Redirect(redirectUrl);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception)
            {
                lblErrorMessage.Text = "Please enter ticket counts in the box";
                lblErrorMessage.Visible = true;
            }
        }

    }


}
