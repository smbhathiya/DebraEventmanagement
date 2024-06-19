using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebService : System.Web.Services.WebService
    {

        private string connectionString = "Server=localhost;Database=debradb;Uid=root;Pwd=;";

        [WebMethod]
        public DataSet ViewAllEvents()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT e.eventid, e.event_name, e.description, e.imageUrl, e.date, e.time, e.location, e.ticket_price, p.company_name 
                FROM events e 
                JOIN partners p ON e.email = p.email";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        string imageUrl = row["imageUrl"].ToString();
                        string fullImageUrl = "https://localhost:44320/" + imageUrl;
                        row["imageUrl"] = fullImageUrl;
                    }

                    DataSet ds = new DataSet();
                    dt.TableName = "Events";
                    ds.Tables.Add(dt);

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        [WebMethod]
        public DataSet GetUserPurchasedTickets(string userEmail)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT e.event_name, e.location, e.time, s.tickets_purchased, e.ticket_price, s.total_price
                        FROM sales s
                        JOIN events e ON s.eventid = e.eventid
                        WHERE s.user_email = @UserEmail";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataSet ds = new DataSet();
                    dt.TableName = "PurchasedTickets";
                    ds.Tables.Add(dt);

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }
    }


}
