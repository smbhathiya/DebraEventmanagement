using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for PartnerWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PartnerWebServices : System.Web.Services.WebService
    {
        private string connectionString = "Server=localhost;Database=debradb;Uid=root;Pwd=;";

        [WebMethod]
        public string AddEvent(string eventid, string event_name, string ticket_price, string email, string date, string time, string location)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO events (eventid, event_name, ticket_price, email, date, time, location) VALUES (@EventID, @EventName, @TicketPrice, @Email, @Date, @Time, @Location)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventid);
                    cmd.Parameters.AddWithValue("@EventName", event_name);
                    cmd.Parameters.AddWithValue("@TicketPrice", ticket_price);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Time", time);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.ExecuteNonQuery();
                    return "Event added successfully.";
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }

        [WebMethod]
        public DataSet GetEventsByUserEmail(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM events WHERE email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", email);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Create a DataSet and add DataTable to it
                    DataSet ds = new DataSet();
                    dt.TableName = "Events"; // Set the DataTable name
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
        public string DeleteEvent(string eventid)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM events WHERE eventid = @EventID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventid);
                    cmd.ExecuteNonQuery();
                    return "Event deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }



        [WebMethod]
        public string UpdateEvent(string eventId, string event_name, string ticket_price, string date, string time, string location)
        {
            string query = "UPDATE Events SET event_name = @EventName, ticket_price = @TicketPrice, Date = @Date, Time = @Time, Location = @Location WHERE EventID = @EventID";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventID", eventId);
                    command.Parameters.AddWithValue("@EventName", event_name);
                    command.Parameters.AddWithValue("@TicketPrice", ticket_price);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Location", location);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return "Event updated successfully.";
                    }
                    else
                    {
                        return "Failed to update event.";
                    }
                }
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
        }

    }
    }




