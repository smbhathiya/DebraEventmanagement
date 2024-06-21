using System;
using System.Windows.Forms;
using DesktopApplication.LoginServiceReference;

namespace DesktopApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                LoginWebServiceSoapClient service = new LoginWebServiceSoapClient();
                string result = service.Login(txtEmail.Text, txtPassword.Text);
                if (result.StartsWith("Login successful"))
                {
                    string[] parts = result.Split('|');
                    string userType = parts[1];

                    // Store email and userType for use in other forms
                    string email = txtEmail.Text;

                    Form nextForm = null;

                    if (userType == "user")
                    {
                        nextForm = new Home(email, userType);
                    }
                    else if (userType == "partner")
                    {
                        nextForm = new PartnerDashboard(email, userType);
                    }
                    else if (userType == "admin")
                    {
                        nextForm = new AdminDashboard(email, userType);
                    }

                    if (nextForm != null)
                    {
                        this.Hide();
                        nextForm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(result, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
