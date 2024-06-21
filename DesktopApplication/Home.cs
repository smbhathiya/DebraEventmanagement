using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using DesktopApplication.UserWebServiceReference;

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

        private async void GetUserPurchasedTickets(string email)
        {
            try
            {
                // Create instance of your web service client
                UserWebServiceSoapClient client = new UserWebServiceSoapClient();

                // Call async method to fetch data
                DataSet ds = await client.GetUserPurchasedTicketsAsync(email);

                // Check if DataSet contains tables
                if (ds != null && ds.Tables.Count > 0)
                {
                    // Bind the fetched data to DataGridView
                    dataGridViewPurchasedTickets.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("No data found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }



    }
}
