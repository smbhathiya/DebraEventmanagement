using MySql.Data.MySqlClient;
using System;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for RegistrationWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RegistrationWebService : System.Web.Services.WebService
    {
        private string connectionString = "Server=localhost;Database=debradb;Uid=root;Pwd=;";

        [WebMethod]
        public string RegisterUser(string name, string email, string password, string address, string contactNo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Insert user data into user table
                    string userQuery = "INSERT INTO users (name, email, password, address, contact_no) VALUES (@Name, @Email, @Password, @Address, @ContactNo)";
                    MySqlCommand userCommand = new MySqlCommand(userQuery, connection);
                    userCommand.Parameters.AddWithValue("@Name", name);
                    userCommand.Parameters.AddWithValue("@Email", email);
                    userCommand.Parameters.AddWithValue("@Password", password);
                    userCommand.Parameters.AddWithValue("@Address", address);
                    userCommand.Parameters.AddWithValue("@ContactNo", contactNo);
                    userCommand.ExecuteNonQuery();

                    // Insert user account data into userAccounts table
                    string userAccountQuery = "INSERT INTO useraccounts (email, password, userType) VALUES (@Email, @Password, @UserType)";
                    MySqlCommand userAccountCommand = new MySqlCommand(userAccountQuery, connection);
                    userAccountCommand.Parameters.AddWithValue("@Email", email);
                    userAccountCommand.Parameters.AddWithValue("@Password", password);
                    userAccountCommand.Parameters.AddWithValue("@UserType", "user");
                    userAccountCommand.ExecuteNonQuery();

                    return "User registered successfully";
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }

        [WebMethod]
        public string RegisterPartner(string companyName, string email, string password, string address, string contactNo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // Insert partner data into partner table
                    string partnerQuery = "INSERT INTO partners (company_name, email, password, address, contact_no) VALUES (@CompanyName, @Email, @Password, @Address, @ContactNo)";
                    MySqlCommand partnerCommand = new MySqlCommand(partnerQuery, connection);
                    partnerCommand.Parameters.AddWithValue("@CompanyName", companyName);
                    partnerCommand.Parameters.AddWithValue("@Email", email);
                    partnerCommand.Parameters.AddWithValue("@Password", password);
                    partnerCommand.Parameters.AddWithValue("@Address", address);
                    partnerCommand.Parameters.AddWithValue("@ContactNo", contactNo);
                    partnerCommand.ExecuteNonQuery();

                    // Insert partner account data into userAccounts table
                    string userAccountQuery = "INSERT INTO useraccounts (email, password, userType) VALUES (@Email, @Password, @UserType)";
                    MySqlCommand userAccountCommand = new MySqlCommand(userAccountQuery, connection);
                    userAccountCommand.Parameters.AddWithValue("@Email", email);
                    userAccountCommand.Parameters.AddWithValue("@Password", password);
                    userAccountCommand.Parameters.AddWithValue("@UserType", "partner"); 
                    userAccountCommand.ExecuteNonQuery();

                    return "Partner registered successfully!";
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }
    }
}
