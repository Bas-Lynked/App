using System;

public class Ticket
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string DeviceType { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
    public string Status { get; set; } = "To do"; // Default value for Status

    public Ticket() { }

    public Ticket(string title, string description, string deviceType, string emailAddress)
    {
        Title = title;
        Description = description;
        CreatedAt = DateTime.Now;
        DeviceType = deviceType;
        EmailAddress = emailAddress;
        Status = "To do"; // Set default status
    }

    public override string ToString()
    {
        return $"Ticket ID: {Id}\nTitle: {Title}\nDescription: {Description}\nDevice Type: {DeviceType}\nEmail Address: {EmailAddress}\nCreated At: {CreatedAt}\n";
    }
}
