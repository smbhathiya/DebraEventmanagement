using System;
using System.Drawing.Text;
using System.Windows.Forms;
using DesktopApplication.LoginServiceReference;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DesktopApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormClose);

        }
            private void FormClose(object sender, FormClosingEventArgs e)
            {
                Application.Exit(); 
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
                        nextForm.ShowDialog();
                        this.Hide();
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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
    
}
