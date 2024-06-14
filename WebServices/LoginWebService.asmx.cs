using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for WebServiceHello
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceHello : System.Web.Services.WebService
    {

        [WebMethod]
        public string Login(string username, string password)
        {
            // You would typically perform authentication here, checking username and password against your database or other authentication provider.
            // For demonstration purposes, let's just do a simple check here.

            if (username == "admin" && password == "password")
            {
                return "Login successful!";
            }
            else
            {
                return "Invalid username or password.";
            }
        }
    }
}
