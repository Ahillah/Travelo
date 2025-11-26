using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    Id = 1,
                    Title = "Trip to Paris",
                    Description = "Explore the city of lights and visit the Eiffel Tower.",
                    ImageUrl = "https://example.com/paris.jpg",
                    Price = 1500.50m,
                    TravelDate = new DateTime(2025, 12, 20)
                },
                new Trip
                {
                    Id = 2,
                    Title = "Trip to London",
                    Description = "Enjoy the historic landmarks of London.",
                    ImageUrl = "https://example.com/london.jpg",
                    Price = 1200.00m,
                    TravelDate = new DateTime(2025, 11, 15)
                },
                new Trip
                {
                    Id = 3,
                    Title = "Trip to New York",
                    Description = "Visit Times Square and Central Park.",
                    ImageUrl = "https://example.com/ny.jpg",
                    Price = 1800.75m,
                    TravelDate = new DateTime(2026, 1, 10)
                },
                new Trip
                {
                    Id = 4,
                    Title = "Trip to Tokyo",
                    Description = "Experience the culture and technology of Tokyo.",
                    ImageUrl = "https://example.com/tokyo.jpg",
                    Price = 2000.00m,
                    TravelDate = new DateTime(2026, 2, 5)
                },
                new Trip
                {
                    Id = 5,
                    Title = "Trip to Cairo",
                    Description = "Discover the pyramids and Egyptian history.",
                    ImageUrl = "https://example.com/cairo.jpg",
                    Price = 900.00m,
                    TravelDate = new DateTime(2025, 12, 5)
                }
            );
        }

    }
}
