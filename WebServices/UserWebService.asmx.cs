using iTextSharp.text.pdf;
using iTextSharp.text;
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
                        SELECT e.eventid, e.event_name, e.location, e.time, s.tickets_purchased, e.ticket_price, s.total_price, s.salesid
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


        [WebMethod]
        public byte[] GeneratePdf(string salesId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT e.event_name, e.location, e.time, s.tickets_purchased, e.ticket_price, s.total_price, s.salesid
                FROM sales s
                JOIN events e ON s.eventid = e.eventid
                WHERE s.salesid = @SalesId";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@SalesId", salesId);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        throw new Exception("No sale found with the specified ID.");
                    }

                    DataRow eventDetails = dt.Rows[0];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Document document = new Document(PageSize.A4);
                        PdfWriter writer = PdfWriter.GetInstance(document, ms);
                        document.Open();

                        document.Add(new Paragraph("Sales Report"));
                        document.Add(new Paragraph("Event Name: " + eventDetails["event_name"]));
                        document.Add(new Paragraph("Location: " + eventDetails["location"]));
                        document.Add(new Paragraph("Time: " + eventDetails["time"]));
                        document.Add(new Paragraph("Tickets Purchased: " + eventDetails["tickets_purchased"]));
                        document.Add(new Paragraph("Ticket Price: " + String.Format("{0:C}", eventDetails["ticket_price"])));
                        document.Add(new Paragraph("Total Price: " + String.Format("{0:C}", eventDetails["total_price"])));

                        document.Close();
                        writer.Close();

                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while generating the PDF: " + ex.Message);
            }
        }
    }


    }
