using DesktopApplication.AdminServiceReference;
using MySqlX.XDevAPI;
using System;
using System.Data;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class AdminDashboard : Form
    {
        private string email;
        private string userType;

        public AdminDashboard(string email, string userType)
        {
            InitializeComponent();
            this.email = email;
            this.userType = userType;
            this.FormClosing += new FormClosingEventHandler(FormClose);
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            ViewEvents();
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
                    gvEvents.AutoGenerateColumns = false;
                    gvEvents.Columns.Clear();

                    // Add the necessary columns
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Company Name", DataPropertyName = "company_name", HeaderText = "Company Name" });

                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "EventID", DataPropertyName = "eventid", HeaderText = "Event ID" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "EventName", DataPropertyName = "event_name", HeaderText = "Event Name" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "TicketPrice", DataPropertyName = "ticket_price", HeaderText = "Ticket Price" });



                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoldTickets", DataPropertyName = "soldTickets", HeaderText = "Sold Tickets" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "RemainingTickets", DataPropertyName = "remainingTickets", HeaderText = "Remaining Tickets" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "CommissionRate", DataPropertyName = "CommissionRate", HeaderText = "Commission Rate" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstimatedIncome", DataPropertyName = "EstimatedIncome", HeaderText = "Estimated Income" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "CurrentIncome", DataPropertyName = "CurrentIncome", HeaderText = "Current Income" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Commission", DataPropertyName = "Commission", HeaderText = "Commission" });


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

        private void gvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
 
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }

        
    }
}
