﻿using HotelApp.Services.BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services.BookingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
    }
}
