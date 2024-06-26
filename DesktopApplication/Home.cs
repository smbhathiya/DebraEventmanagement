using DesktopApplication.UserWebServiceReference;
using System;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class Home : Form
    {
        private string email;
        private string userType;

        public Home(string email, string userType)
        {
            InitializeComponent();
            this.email = email;
            this.userType = userType;
            GetUserPurchasedTickets(email);
            this.FormClosing += new FormClosingEventHandler(FormClose);
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void GetUserPurchasedTickets(string email)
        {
            try
            {
                var service = new UserWebServiceSoapClient();
                var ticketsDataSet = service.GetUserPurchasedTickets(email);

                if (ticketsDataSet != null && ticketsDataSet.Tables.Count > 0 && ticketsDataSet.Tables[0].Rows.Count > 0)
                {
                    var dt = ticketsDataSet.Tables[0];

                    gvEvents.DataSource = null;
                    gvEvents.AutoGenerateColumns = false;
                    gvEvents.Columns.Clear();

                    // Add the necessary columns
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "SalesID", DataPropertyName = "salesid", HeaderText = "Sales ID" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "EventName", DataPropertyName = "event_name", HeaderText = "Event Name" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Location", DataPropertyName = "location", HeaderText = "Location" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", DataPropertyName = "date", HeaderText = "Date" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Time", DataPropertyName = "time", HeaderText = "Time" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "TicketCount", DataPropertyName = "tickets_purchased", HeaderText = "Ticket Count" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "TicketPrice", DataPropertyName = "ticket_price", HeaderText = "Ticket Price" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalPrice", DataPropertyName = "total_price", HeaderText = "Total Price" });

                    gvEvents.DataSource = dt;
                }
                else
                {
                    gvEvents.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving events: " + ex.Message);
            }
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
            GetUserPurchasedTickets(email);
        }



        private void logoutbtn_Click(object sender, EventArgs e)
        {

            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }



    }
}
