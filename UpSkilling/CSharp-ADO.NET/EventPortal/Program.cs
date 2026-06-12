using System;
using System.Collections.Generic;

namespace EventPortal
{
    class Program
    {
        static DatabaseHelper dbHelper = new DatabaseHelper();

        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("        Welcome to EventPortal             ");
            Console.WriteLine("===========================================");

            bool running = true;
            while (running)
            {
                ShowMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEvent();
                        break;
                    case "2":
                        ViewEvents();
                        break;
                    case "3":
                        RegisterParticipant();
                        break;
                    case "4":
                        dbHelper.GetAllParticipants();
                        break;
                    case "5":
                        UpdateEvent();
                        break;
                    case "6":
                        DeleteEvent();
                        break;
                    case "7":
                        running = false;
                        Console.WriteLine("Thank you for using EventPortal. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("                 MAIN MENU                 ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1. Add Event");
            Console.WriteLine("2. View Events");
            Console.WriteLine("3. Register Participant");
            Console.WriteLine("4. View Participants");
            Console.WriteLine("5. Update Event");
            Console.WriteLine("6. Delete Event");
            Console.WriteLine("7. Exit");
            Console.WriteLine("-------------------------------------------");
            Console.Write("Enter your choice: ");
        }

        static void AddEvent()
        {
            Console.WriteLine("\n--- Add New Event ---");
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter Event Date (YYYY-MM-DD): ");
            string eventDate = Console.ReadLine();

            Console.Write("Enter Venue: ");
            string venue = Console.ReadLine();

            Event newEvent = new Event();
            newEvent.EventName = eventName;
            newEvent.EventDate = eventDate;
            newEvent.Venue = venue;

            dbHelper.AddEvent(newEvent);
        }

        static void ViewEvents()
        {
            List<Event> events = dbHelper.GetAllEvents();
            if (events.Count == 0)
            {
                Console.WriteLine("No events found.");
                return;
            }

            Console.WriteLine("\n{0,-5} {1,-25} {2,-15} {3}", "ID", "Event Name", "Date", "Venue");
            Console.WriteLine(new string('-', 75));
            foreach (Event ev in events)
            {
                Console.WriteLine("{0,-5} {1,-25} {2,-15} {3}", ev.EventId, ev.EventName, ev.EventDate, ev.Venue);
            }
        }

        static void RegisterParticipant()
        {
            ViewEvents();
            Console.WriteLine("\n--- Register Participant ---");
            Console.Write("Enter Participant Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Event ID to register for: ");
            int eventId = int.Parse(Console.ReadLine());

            dbHelper.RegisterParticipant(name, email, phone, eventId);
        }

        static void UpdateEvent()
        {
            ViewEvents();
            Console.WriteLine("\n--- Update Event ---");
            Console.Write("Enter Event ID to update: ");
            int eventId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Event Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter New Event Date (YYYY-MM-DD): ");
            string newDate = Console.ReadLine();

            Console.Write("Enter New Venue: ");
            string newVenue = Console.ReadLine();

            dbHelper.UpdateEvent(eventId, newName, newDate, newVenue);
        }

        static void DeleteEvent()
        {
            ViewEvents();
            Console.WriteLine("\n--- Delete Event ---");
            Console.Write("Enter Event ID to delete: ");
            int eventId = int.Parse(Console.ReadLine());

            dbHelper.DeleteEvent(eventId);
        }
    }
}
