using Microsoft.EntityFrameworkCore;
using WorkshopBooking.Models;

namespace WorkshopBooking.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    {
    }
    public DbSet<Workshop> Workshops { get; set; }
}
