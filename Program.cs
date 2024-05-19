using System;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new TicketContext())
        {
            db.Database.EnsureCreated();
        }

        while (true)
        {
            Console.WriteLine("Ticketing System");
            Console.WriteLine("1. Create Ticket");
            Console.WriteLine("2. View Tickets");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string option = Console.ReadLine() ?? string.Empty;

            switch (option)
            {
                case "1":
                    CreateTicket();
                    break;
                case "2":
                    ViewTickets();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateTicket()
    {
        string title, description, deviceType, emailAddress;

        // Validate Title
        while (true)
        {
            Console.Write("Enter ticket title: ");
            title = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(title))
            {
                break;
            }
            Console.WriteLine("Title is required. Please enter a valid title.");
        }

        // Validate Description
        while (true)
        {
            Console.Write("Enter ticket description: ");
            description = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(description))
            {
                break;
            }
            Console.WriteLine("Description is required. Please enter a valid description.");
        }

        // Validate Device Type
        while (true)
        {
            Console.Write("Enter device type (Laptop/Mobile): ");
            deviceType = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(deviceType) && (deviceType.ToLower() == "laptop" || deviceType.ToLower() == "mobile"))
            {
                break;
            }
            Console.WriteLine("Device Type is required and must be either 'Laptop' or 'Mobile'. Please enter a valid device type.");
        }

        // Validate Email Address
        while (true)
        {
            Console.Write("Enter your email address: ");
            emailAddress = Console.ReadLine() ?? string.Empty;
            if (IsValidEmail(emailAddress))
            {
                break;
            }
            Console.WriteLine("Email address is required and must be a valid email address (e.g., user@example.com). Please enter a valid email address.");
        }

        using (var db = new TicketContext())
        {
            var ticket = new Ticket(title, description, deviceType, emailAddress);
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }

        Console.WriteLine("Ticket created successfully!\n");
    }

    static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Use simple string checks for '@' and '.'
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        catch (Exception)
        {
            return false;
        }
    }

    static void ViewTickets()
    {
        using (var db = new TicketContext())
        {
            var tickets = db.Tickets.ToList();
            Console.WriteLine("List of Tickets:");
            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket); // Calls the ToString method of the Ticket class
            }
        }
    }
}
