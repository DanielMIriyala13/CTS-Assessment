using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EventPortal
{
    public class DatabaseHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EventPortalDB"].ConnectionString;

        public void AddEvent(Event newEvent)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Events (EventName, EventDate, Venue) VALUES (@EventName, @EventDate, @Venue)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventName", newEvent.EventName);
                    command.Parameters.AddWithValue("@EventDate", newEvent.EventDate);
                    command.Parameters.AddWithValue("@Venue", newEvent.Venue);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Event added successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding event: " + ex.Message);
            }
        }

        public List<Event> GetAllEvents()
        {
            List<Event> eventList = new List<Event>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT EventId, EventName, EventDate, Venue FROM Events";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Event ev = new Event();
                        ev.EventId = Convert.ToInt32(reader["EventId"]);
                        ev.EventName = reader["EventName"].ToString();
                        ev.EventDate = reader["EventDate"].ToString();
                        ev.Venue = reader["Venue"].ToString();
                        eventList.Add(ev);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving events: " + ex.Message);
            }
            return eventList;
        }

        public void RegisterParticipant(string name, string email, string phone, int eventId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Participants (Name, Email, Phone, EventId) VALUES (@Name, @Email, @Phone, @EventId)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@EventId", eventId);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Participant registered successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error registering participant: " + ex.Message);
            }
        }

        public void GetAllParticipants()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT p.ParticipantId, p.Name, p.Email, p.Phone, e.EventName FROM Participants p INNER JOIN Events e ON p.EventId = e.EventId";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("\n{0,-5} {1,-20} {2,-25} {3,-15} {4}", "ID", "Name", "Email", "Phone", "Event");
                    Console.WriteLine(new string('-', 80));
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-5} {1,-20} {2,-25} {3,-15} {4}",
                            reader["ParticipantId"],
                            reader["Name"],
                            reader["Email"],
                            reader["Phone"],
                            reader["EventName"]);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving participants: " + ex.Message);
            }
        }

        public void UpdateEvent(int eventId, string newName, string newDate, string newVenue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Events SET EventName = @EventName, EventDate = @EventDate, Venue = @Venue WHERE EventId = @EventId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventName", newName);
                    command.Parameters.AddWithValue("@EventDate", newDate);
                    command.Parameters.AddWithValue("@Venue", newVenue);
                    command.Parameters.AddWithValue("@EventId", eventId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Event updated successfully.");
                    else
                        Console.WriteLine("No event found with that ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating event: " + ex.Message);
            }
        }

        public void DeleteEvent(int eventId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Events WHERE EventId = @EventId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EventId", eventId);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                        Console.WriteLine("Event deleted successfully.");
                    else
                        Console.WriteLine("No event found with that ID.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting event: " + ex.Message);
            }
        }
    }
}
