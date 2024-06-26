using DesktopApplication.PartnerServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApplication
{
    public partial class PartnerDashboard : Form
    {
        private string email;
        private string userType;

        public PartnerDashboard(string email, string userType)
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

        private void PartnerDashboard_Load(object sender, EventArgs e)
        {

            ViewEvents();
        }



        private void ViewEvents()
        {
            try
            {
                var service = new PartnerWebServicesSoapClient();
                var eventsDataSet = service.GetEventsByUserEmail(email);

                if (eventsDataSet != null && eventsDataSet.Tables.Count > 0 && eventsDataSet.Tables[0].Rows.Count > 0)
                {
                    var dt = eventsDataSet.Tables[0];

                    gvEvents.DataSource = null;
                    gvEvents.AutoGenerateColumns = false;

                    // Add the necessary columns
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "EventID", DataPropertyName = "eventid", HeaderText = "Event ID" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "EventName", DataPropertyName = "event_name", HeaderText = "Event Name" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", DataPropertyName = "description", HeaderText = "Description" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", DataPropertyName = "date", HeaderText = "Date" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Time", DataPropertyName = "time", HeaderText = "Time" });
                    this.gvEvents.Columns.Add(new DataGridViewTextBoxColumn { Name = "Location", DataPropertyName = "location", HeaderText = "Location" });

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

        private void logoutbtn_Click(object sender, EventArgs e)
        {

            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
