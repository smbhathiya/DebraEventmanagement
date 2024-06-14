using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
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


                if (result == "Login successful")
                {
                    this.Hide();
                    Home home = new Home();
                    home.Show();
                }
                else
                {
                    MessageBox.Show(result, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        }
}
