using Chapter13RazorViews.Models;
using Microsoft.EntityFrameworkCore;


namespace Chapter13RazorViews.Data
{
    public class EventDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> Categories { get; set; }
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }
    }
}
    
