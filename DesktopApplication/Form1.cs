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

namespace DesktopApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the web service client
            HelloService.WebServiceHelloSoapClient client = new HelloService.WebServiceHelloSoapClient();

            // Call the HelloWorld method
            string result = client.HelloWorld();

            // Display the result in Label1
            label1.Text = result;
        }
    }
}
