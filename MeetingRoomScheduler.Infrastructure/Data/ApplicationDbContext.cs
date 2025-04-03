using MeetingRoomScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomScheduler.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Room> Room { get; set; }
    public DbSet<Reservation> Reservation { get; set; }
}
