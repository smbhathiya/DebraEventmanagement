using DesktopApplication.AdminServiceReference;
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
    }
}
