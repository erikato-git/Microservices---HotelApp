using HotelApp.Services.HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services.HotelAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bed> Beds { get; set; }

    }
}
