using System;
using System.Windows.Forms;
using DesktopApplication.RegistrationWebServiceReference;

namespace DesktopApplication
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormClose);
            ShowUserRegistration();
        }

    private void FormClose(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }

    private void ShowUserRegistration()
        {
            userFormPanel.Visible = true;
            partnerFormPanel.Visible = false;
            lblFormHeading.Text = "USER REGISTRATION";
        }

        private void ShowPartnerRegistration()
        {
            userFormPanel.Visible = false;
            partnerFormPanel.Visible = true;
            lblFormHeading.Text = "PARTNER REGISTRATION";
        }

        private void BtnSwitchToUser_Click(object sender, EventArgs e)
        {
            ShowUserRegistration();
        }

        private void BtnSwitchToPartner_Click(object sender, EventArgs e)
        {
            ShowPartnerRegistration();
        }

        private void BtnUserRegister_Click(object sender, EventArgs e)
        {
            // Check if any fields are empty
            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtUserEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
                string.IsNullOrWhiteSpace(txtUserRePassword.Text) ||
                string.IsNullOrWhiteSpace(txtUserAddress.Text) ||
                string.IsNullOrWhiteSpace(txtUserContact.Text))
            {
                MessageBox.Show("Please fill in all details.");
                return;
            }

            if (txtUserPassword.Text != txtUserRePassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string userName = txtUserName.Text;
            string userEmail = txtUserEmail.Text;
            string userPassword = txtUserPassword.Text;
            string userAddress = txtUserAddress.Text;
            string userContact = txtUserContact.Text;

            RegistrationWebServiceSoapClient service = new RegistrationWebServiceSoapClient();
            string result = service.RegisterUser(userName, userEmail, userPassword, userAddress, userContact);

            MessageBox.Show(result);
        }

        private void BtnPartnerRegister_Click(object sender, EventArgs e)
        {
            // Check if any fields are empty
            if (string.IsNullOrWhiteSpace(txtPartnerCompanyName.Text) ||
                string.IsNullOrWhiteSpace(txtPartnerEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPartnerPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPartnerRePassword.Text) ||
                string.IsNullOrWhiteSpace(txtPartnerAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPartnerContact.Text))
            {
                MessageBox.Show("Please fill in all details.");
                return;
            }

            if (txtPartnerPassword.Text != txtPartnerRePassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string partnerCompanyName = txtPartnerCompanyName.Text;
            string partnerEmail = txtPartnerEmail.Text;
            string partnerPassword = txtPartnerPassword.Text;
            string partnerAddress = txtPartnerAddress.Text;
            string partnerContact = txtPartnerContact.Text;

            RegistrationWebServiceSoapClient service = new RegistrationWebServiceSoapClient();
            string result = service.RegisterPartner(partnerCompanyName, partnerEmail, partnerPassword, partnerAddress, partnerContact);

            MessageBox.Show(result);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
