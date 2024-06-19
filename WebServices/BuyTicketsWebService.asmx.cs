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
    /// Summary description for BuyTicketsWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BuyTicketsWebService : System.Web.Services.WebService
    {
        private string connectionString = "Server=localhost;Database=debradb;Uid=root;Pwd=;";

        [WebMethod]
        public DataSet ViewEvent(string eventId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT e.event_name, e.description, e.imageUrl, e.date, e.time, e.location, e.ticket_price, p.company_name, e.remainingTickets 
                        FROM events e 
                        JOIN partners p ON e.email = p.email
                        WHERE e.eventid = @EventId";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EventId", eventId); // Add the parameter

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
        public decimal CalculateTotalPrice(string eventId, int ticketCount)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT e.ticket_price
                        FROM events e
                        WHERE e.eventid = @EventId";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EventId", eventId);

                    object result = cmd.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal ticketPrice))
                    {
                        decimal totalPrice = ticketPrice * ticketCount;
                        return totalPrice;
                    }
                    else
                    {
                        throw new Exception("Event not found or invalid ticket price.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }

        [WebMethod]
        public string PurchaseTickets(string eventId, int ticketCount, string userEmail, decimal totalPrice)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    string insertSaleQuery = @"
                        INSERT INTO sales (eventid, user_email, tickets_purchased, total_price)
                        VALUES (@EventId, @UserEmail, @TicketCount, @TotalPrice)";

                    MySqlCommand insertCmd = new MySqlCommand(insertSaleQuery, connection, transaction);
                    insertCmd.Parameters.AddWithValue("@EventId", eventId);
                    insertCmd.Parameters.AddWithValue("@UserEmail", userEmail);
                    insertCmd.Parameters.AddWithValue("@TicketCount", ticketCount);
                    insertCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    insertCmd.ExecuteNonQuery();

                    string updateEventQuery = @"
                        UPDATE events 
                        SET soldTickets = soldTickets + @TicketCount, 
                            remainingTickets = remainingTickets - @TicketCount
                        WHERE eventid = @EventId";

                    MySqlCommand updateCmd = new MySqlCommand(updateEventQuery, connection, transaction);
                    updateCmd.Parameters.AddWithValue("@TicketCount", ticketCount);
                    updateCmd.Parameters.AddWithValue("@EventId", eventId);
                    updateCmd.ExecuteNonQuery();

                    transaction.Commit();
                    return "Purchase successful";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("An error occurred during the purchase: " + ex.Message);
                }
            }

        }
    }
}
