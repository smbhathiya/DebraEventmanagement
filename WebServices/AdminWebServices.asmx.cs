using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for AdminWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminWebServices : System.Web.Services.WebService
    {

        private string connectionString = "Server=localhost;Database=debradb;Uid=root;Pwd=;";

        [WebMethod]
        public DataSet GetAllEvents()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT e.eventid, e.event_name, e.ticket_price, e.soldTickets, e.remainingTickets, e.commissionRate, p.company_name 
                FROM events e 
                JOIN partners p ON e.email = p.email";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dt.Columns.Add("EstimatedIncome", typeof(decimal));
                    dt.Columns.Add("CurrentIncome", typeof(decimal));
                    dt.Columns.Add("Commission", typeof(decimal));

                    foreach (DataRow row in dt.Rows)
                    {
                        decimal ticketPrice = Convert.ToDecimal(row["ticket_price"]);
                        int soldTickets = Convert.ToInt32(row["soldTickets"]);
                        int remainingTickets = Convert.ToInt32(row["remainingTickets"]);
                        decimal commissionRate = Convert.ToDecimal(row["commissionRate"]);

                        decimal estimatedIncome = ticketPrice * (soldTickets + remainingTickets);
                        decimal currentIncome = ticketPrice * soldTickets;

                        decimal commission = (commissionRate/100) * currentIncome;

                        row["EstimatedIncome"] = estimatedIncome;
                        row["CurrentIncome"] = currentIncome;
                        row["Commission"] = commission;
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
        public string UpdateCommissionRate(string eventId, decimal newCommissionRate)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE events SET commissionRate = @NewCommissionRate WHERE eventid = @EventId";

                    MySqlCommand cmd = new MySqlCommand(updateQuery, connection);
                    cmd.Parameters.AddWithValue("@NewCommissionRate", newCommissionRate);
                    cmd.Parameters.AddWithValue("@EventId", eventId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "Commission rate updated successfully.";
                    }
                    else
                    {
                        return "No rows were affected. Event not found or commission rate unchanged.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }


        [WebMethod]
        public string DeleteEvent(string eventid)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the image URL of the event to be deleted
                    string getImageUrlQuery = "SELECT imageUrl FROM events WHERE eventid = @EventID";
                    MySqlCommand getImageUrlCmd = new MySqlCommand(getImageUrlQuery, connection);
                    getImageUrlCmd.Parameters.AddWithValue("@EventID", eventid);
                    string imageUrl = getImageUrlCmd.ExecuteScalar()?.ToString();

                    // Delete the event record from the database
                    string deleteEventQuery = "DELETE FROM events WHERE eventid = @EventID";
                    MySqlCommand deleteEventCmd = new MySqlCommand(deleteEventQuery, connection);
                    deleteEventCmd.Parameters.AddWithValue("@EventID", eventid);
                    deleteEventCmd.ExecuteNonQuery();

                    // Delete the associated image from the file system
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        string imagePath = HttpContext.Current.Server.MapPath("~/" + imageUrl);
                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }

                    return "Event deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }


        [WebMethod]
        public DataSet GetPartners()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT userId, company_name, email, address, contact_no FROM partners";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
   

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataSet ds = new DataSet();
                    dt.TableName = "Partners";
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
        public bool DeletePartnerByEmail(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM partners WHERE email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }


    }
}
