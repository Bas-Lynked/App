using Microsoft.EntityFrameworkCore;

public class TicketContext : DbContext
{
    public DbSet<Ticket> Tickets { get; set; } = null!; // Use null-forgiving operator

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=tickets.db");
    }
}
