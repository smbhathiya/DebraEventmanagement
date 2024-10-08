﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        public string AddEvent(string eventid, string event_name, string ticket_price, string email, string date, string time, string location, string description, byte[] imageData, int remainingTickets)
        {
            try
            {
                string imageUrl = "";
                if (imageData != null && imageData.Length > 0)
                {
                    string uploadsFolderPath = HttpContext.Current.Server.MapPath("~/Uploads/");

                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        try
                        {
                            Directory.CreateDirectory(uploadsFolderPath);
                        }
                        catch (Exception ex)
                        {
                            return "Error creating uploads folder: " + ex.Message;
                        }
                    }

                    string imageFileName = eventid + ".jpg";
                    string imagePath = Path.Combine(uploadsFolderPath, imageFileName);

                    try
                    {
                        File.WriteAllBytes(imagePath, imageData);
                        imageUrl = "Uploads/" + imageFileName;
                    }
                    catch (Exception ex)
                    {
                        return "Error saving image: " + ex.Message;
                    }
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO events (eventid, event_name, ticket_price, email, date, time, location, description, imageUrl, soldTickets, remainingTickets) " +
                                   "VALUES (@EventID, @EventName, @TicketPrice, @Email, @Date, @Time, @Location, @Description, @ImageUrl, @SoldTickets, @RemainingTickets)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EventID", eventid);
                    cmd.Parameters.AddWithValue("@EventName", event_name);
                    cmd.Parameters.AddWithValue("@TicketPrice", ticket_price);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Time", time);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);
                    cmd.Parameters.AddWithValue("@SoldTickets", 0);
                    cmd.Parameters.AddWithValue("@RemainingTickets", remainingTickets);
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
                    string query = "SELECT eventid, event_name, ticket_price, email, date, time, location, description, imageUrl, soldTickets, commissionRate, remainingTickets FROM events WHERE email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", email);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dt.Columns.Add("EstimatedIncome", typeof(decimal));
                    dt.Columns.Add("CurrentIncome", typeof(decimal));
                    dt.Columns.Add("Commission", typeof(decimal));

                    foreach (DataRow row in dt.Rows)
                    {
                        string imageUrl = row["imageUrl"].ToString();
                        string fullImageUrl = "https://localhost:44320/" + imageUrl;
                        row["imageUrl"] = fullImageUrl;

                        decimal ticketPrice = Convert.ToDecimal(row["ticket_price"]);
                        int soldTickets = Convert.ToInt32(row["soldTickets"]);
                        int remainingTickets = Convert.ToInt32(row["remainingTickets"]);
                        decimal commissionRate = Convert.ToDecimal(row["commissionRate"]);

                        decimal estimatedIncome = ticketPrice * (soldTickets + remainingTickets);
                        decimal currentIncome = ticketPrice * soldTickets;

                        decimal commission = (commissionRate / 100) * currentIncome;

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
        public DataSet GetPartnerByEmail(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT userId, company_name, email, address, contact_no FROM partners WHERE email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", email);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataSet ds = new DataSet();
                    dt.TableName = "Partner";
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
        public bool UpdatePartnerByEmail(string email, string companyName, string address, string contactNo)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE partners SET company_name = @CompanyName, address = @Address, contact_no = @ContactNo WHERE email = @Email";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@CompanyName", companyName);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@ContactNo", contactNo);
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
        public string UpdateEvent(string eventId, string event_name, string ticket_price, string date, string time, string location, string description, byte[] imageData, int soldTickets, int remainingTickets)
        {
            string query = "UPDATE Events SET event_name = @EventName, ticket_price = @TicketPrice, Date = @Date, Time = @Time, Location = @Location, Description = @Description, ImageUrl = @ImageUrl, soldTickets = @SoldTickets, remainingTickets = @RemainingTickets WHERE EventID = @EventID";

            try
            {
                string imageUrl = "";
                if (imageData != null && imageData.Length > 0)
                {
                    // Save the image and get the image URL
                    imageUrl = SaveImage(eventId, imageData);
                    if (imageUrl.StartsWith("Error"))
                    {
                        // Return error message if image saving failed
                        return imageUrl;
                    }
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventID", eventId);
                    command.Parameters.AddWithValue("@EventName", event_name);
                    command.Parameters.AddWithValue("@TicketPrice", ticket_price);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@ImageUrl", imageUrl);
                    command.Parameters.AddWithValue("@SoldTickets", soldTickets);
                    command.Parameters.AddWithValue("@RemainingTickets", remainingTickets);

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


        private string SaveImage(string eventId, byte[] imageData)
        {
            try
            {
                string uploadsFolderPath = HttpContext.Current.Server.MapPath("~/Uploads/");

                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                string imageFileName = eventId + ".jpg";
                string imagePath = Path.Combine(uploadsFolderPath, imageFileName);

                File.WriteAllBytes(imagePath, imageData);
                return "Uploads/" + imageFileName;
            }
            catch (Exception ex)
            {
                return "Error saving image: " + ex.Message;
            }
        }


    }
}




