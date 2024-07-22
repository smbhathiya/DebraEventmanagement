using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.BuyTicketsServiceReference;

namespace WebApplication1
{
    public partial class PaymentPortal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCardNumber.Attributes.Add("required", "true");
                txtExpiryDate.Attributes.Add("required", "true");
                txtCVV.Attributes.Add("required", "true");
                txtCardholderName.Attributes.Add("required", "true");
                txtBillingAddress.Attributes.Add("required", "true");
                txtZipCode.Attributes.Add("required", "true");

                string eventId = Request.QueryString["eventId"];
                string email = Request.QueryString["email"];
                string ticketCountStr = Request.QueryString["ticketCount"];
                string totalPriceStr = Request.QueryString["totalPrice"];

                if (!string.IsNullOrEmpty(eventId) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(ticketCountStr) && !string.IsNullOrEmpty(totalPriceStr))
                {
                    int ticketCount = int.Parse(ticketCountStr);
                    decimal totalPrice = decimal.Parse(totalPriceStr);

                    decimal ticketPrice = totalPrice / ticketCount;


                    lblTicketPrice.Text = $"Rs.{ticketPrice:F2}";
                    lblTicketsCount.Text = ticketCount.ToString();
                    lblTotalPrice.Text = $"Rs.{totalPrice:F2}";
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
        protected void btnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["Email"] != null)
                {
                    string email = Session["Email"].ToString();
                    string eventId = Request.QueryString["eventId"];
                    string ticketCountStr = Request.QueryString["ticketCount"];
                    string totalPriceStr = Request.QueryString["totalPrice"];

                    if (!string.IsNullOrEmpty(ticketCountStr) && !string.IsNullOrEmpty(totalPriceStr))
                    {
                        int ticketCount = int.Parse(ticketCountStr);
                        decimal totalPrice = decimal.Parse(totalPriceStr);

                        BuyTicketsWebServiceSoapClient service = new BuyTicketsWebServiceSoapClient();
                        string result = service.PurchaseTickets(eventId, ticketCount, email, totalPrice);

                        string script = $@"<script>alert('{result}'); window.location.href = 'Home.aspx';</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "PurchaseSuccessScript", script);
                    }
                    else
                    {
                        string script = $@"<script>console.log('Error: Ticket count or total price is missing.');</script>";
                        ClientScript.RegisterStartupScript(this.GetType(), "ErrorScript", script);
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message.Replace("'", "\\'").Replace("\n", "\\n");
                string script = $@"<script>console.log('Error: {errorMessage}');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "ErrorScript", script);
            }
        }
    }
}