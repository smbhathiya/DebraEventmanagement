using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Debra
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the web service client
            HelloService.WebServiceHelloSoapClient client = new HelloService.WebServiceHelloSoapClient();

            // Call the HelloWorld method
            string result = client.HelloWorld();

            // Display the result in Label1
            Label1.Text = result;
        }
    }
}