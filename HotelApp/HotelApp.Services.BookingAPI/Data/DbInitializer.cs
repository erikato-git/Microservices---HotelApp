using HotelApp.Services.BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services.BookingAPI.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            SeedData(scope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext context)
        {
            context.Database.Migrate();

            if (context.Bookings.Any())
            {
                Console.WriteLine("Database has already been initialized with Bookings");
                return;
            }

            var bookings = new List<Booking>()
            {
                // Test "SingleRooms" don't exist for "Downtown Hostel, Istedgade 1, Denmark, Copenhagen" in between 1.6.2024 - 1.7.2024 and only "DoubleRooms" and "Dormitories" appear
                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27801"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7e",
                    HotelName = "Donwtown Hostel",
                    HotelAddress = "Istedgade 1",
                    HotelCountry = "Denmark",
                    HotelCity = "Copenhagen",
                    Stars = 3,
                    CustomerEmail = "User1@mail.com",
                    CustomerAddress = "User1 Street",
                    CustomerFullName = "User1 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d0",
                        "5d3eafe0-1392-4056-be3b-74d6a62983d1"
                    },
                    CheckInDate = new DateTime(2024, 6, 1),
                    CheckOutDate = new DateTime(2024, 7, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27802"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7e",
                    HotelName = "Donwtown Hostel",
                    HotelAddress = "Istedgade 1",
                    HotelCountry = "Denmark",
                    HotelCity = "Copenhagen",
                    Stars = 3,
                    CustomerEmail = "User2@mail.com",
                    CustomerAddress = "User2 Street",
                    CustomerFullName = "User2 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d2",
                        "5d3eafe0-1392-4056-be3b-74d6a62983d3"
                    },
                    CheckInDate = new DateTime(2024, 7, 1),
                    CheckOutDate = new DateTime(2024, 8, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27803"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7e",
                    HotelName = "Donwtown Hostel",
                    HotelAddress = "Istedgade 1",
                    HotelCountry = "Denmark",
                    HotelCity = "Copenhagen",
                    Stars = 3,
                    CustomerEmail = "User3@mail.com",
                    CustomerAddress = "User3 Street",
                    CustomerFullName = "User3 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d4"
                    },
                    CheckInDate = new DateTime(2024, 8, 1),
                    CheckOutDate = new DateTime(2024, 9, 1)
                },


                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27804"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7f",
                    HotelName = "The Ritz London",
                    HotelAddress = "PICCADILLY 1",
                    HotelCountry = "England",
                    HotelCity = "London",
                    Stars = 5,
                    CustomerEmail = "User1@mail.com",
                    CustomerAddress = "User1 Street",
                    CustomerFullName = "User1 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d5",
                        "5d3eafe0-1392-4056-be3b-74d6a62983d6"
                    },
                    CheckInDate = new DateTime(2024, 6, 1),
                    CheckOutDate = new DateTime(2024, 7, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27805"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7f",
                    HotelName = "The Ritz London",
                    HotelAddress = "PICCADILLY 1",
                    HotelCountry = "England",
                    HotelCity = "London",
                    Stars = 5,
                    CustomerEmail = "User2@mail.com",
                    CustomerAddress = "User2 Street",
                    CustomerFullName = "User2 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d7",
                        "5d3eafe0-1392-4056-be3b-74d6a62983d8"
                    },
                    CheckInDate = new DateTime(2024, 7, 1),
                    CheckOutDate = new DateTime(2024, 8, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27806"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7f",
                    HotelName = "The Ritz London",
                    HotelAddress = "PICCADILLY 1",
                    HotelCountry = "England",
                    HotelCity = "London",
                    Stars = 5,
                    CustomerEmail = "User3@mail.com",
                    CustomerAddress = "User3 Street",
                    CustomerFullName = "User3 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d0",
                        "5d3eafe0-1392-4056-be3b-74d6a62983d1"
                    },
                    CheckInDate = new DateTime(2024, 8, 1),
                    CheckOutDate = new DateTime(2024, 9, 1)
                },


                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27807"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7g",
                    HotelName = "Cabinn City",
                    HotelAddress = "Kreuzberg 1",
                    HotelCountry = "Germany",
                    HotelCity = "Berlin",
                    Stars = 2,
                    CustomerEmail = "User1@mail.com",
                    CustomerAddress = "User1 Street",
                    CustomerFullName = "User1 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d9",
                        "5d3eafe0-1392-4056-be3b-74d6a6298310"
                    },
                    CheckInDate = new DateTime(2024, 6, 1),
                    CheckOutDate = new DateTime(2024, 7, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27808"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7g",
                    HotelName = "Cabinn City",
                    HotelAddress = "Kreuzberg 1",
                    HotelCountry = "Germany",
                    HotelCity = "Berlin",
                    Stars = 2,
                    CustomerEmail = "User2@mail.com",
                    CustomerAddress = "User2 Street",
                    CustomerFullName = "User2 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d9",
                        "5d3eafe0-1392-4056-be3b-74d6a6298310"
                    },
                    CheckInDate = new DateTime(2024, 7, 1),
                    CheckOutDate = new DateTime(2024, 8, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27809"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7g",
                    HotelName = "Cabinn City",
                    HotelAddress = "Kreuzberg 1",
                    HotelCountry = "Germany",
                    HotelCity = "Berlin",
                    Stars = 2,
                    CustomerEmail = "User3@mail.com",
                    CustomerAddress = "User3 Street",
                    CustomerFullName = "User3 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a62983d9",
                        "5d3eafe0-1392-4056-be3b-74d6a6298310"
                    },
                    CheckInDate = new DateTime(2024, 8, 1),
                    CheckOutDate = new DateTime(2024, 9, 1)
                },


                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27810"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7h",
                    HotelName = "Hilton",
                    HotelAddress = "Kgs. Nytorv 1",
                    HotelCountry = "Denmark",
                    HotelCity = "Copenhagen",
                    Stars = 5,
                    CustomerEmail = "User1@mail.com",
                    CustomerAddress = "User1 Street",
                    CustomerFullName = "User1 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a6298312",
                        "5d3eafe0-1392-4056-be3b-74d6a6298313"
                    },
                    CheckInDate = new DateTime(2024, 6, 1),
                    CheckOutDate = new DateTime(2024, 7, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27811"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7h",
                    HotelName = "Hilton",
                    HotelAddress = "Kgs. Nytorv 1",
                    HotelCountry = "Denmark",
                    HotelCity = "Copenhagen",
                    Stars = 5,
                    CustomerEmail = "User2@mail.com",
                    CustomerAddress = "User2 Street",
                    CustomerFullName = "User2 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a6298314",
                        "5d3eafe0-1392-4056-be3b-74d6a6298315"
                    },
                    CheckInDate = new DateTime(2024, 7, 1),
                    CheckOutDate = new DateTime(2024, 8, 1)
                },


                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27812"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7i",
                    HotelName = "Hotel Eiffel",
                    HotelAddress = "Champs Elysees1",
                    HotelCountry = "France",
                    HotelCity = "Paris",
                    Stars = 5,
                    CustomerEmail = "User1@mail.com",
                    CustomerAddress = "User1 Street",
                    CustomerFullName = "User1 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a6298316",
                        "5d3eafe0-1392-4056-be3b-74d6a6298317"
                    },
                    CheckInDate = new DateTime(2024, 6, 1),
                    CheckOutDate = new DateTime(2024, 7, 1)
                },

                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27813"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7i",
                    HotelName = "Hotel Eiffel",
                    HotelAddress = "Champs Elysees1",
                    HotelCountry = "France",
                    HotelCity = "Paris",
                    Stars = 5,
                    CustomerEmail = "User2@mail.com",
                    CustomerAddress = "User2 Street",
                    CustomerFullName = "User2 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a6298318",
                        "5d3eafe0-1392-4056-be3b-74d6a6298319"
                    },
                    CheckInDate = new DateTime(2024, 7, 1),
                    CheckOutDate = new DateTime(2024, 8, 1)
                },

                // Test for Dormitory that is counts down "Bunks" in the same Dormitory-room
                new Booking
                {
                    Id = Guid.Parse("89aca6c2-ee45-4d84-9654-7280f6e27814"),
                    HotelId = "bcc20b49-e728-46cf-89e3-afa79e297d7j",
                    HotelName = "Generator Barcelona",
                    HotelAddress = "La Rambla 1",
                    HotelCountry = "Spain",
                    HotelCity = "Barcelona",
                    Stars = 3,
                    CustomerEmail = "User1@mail.com",
                    CustomerAddress = "User1 Street",
                    CustomerFullName = "User1 Name",
                    OrderRoomsTextString = "",
                    RoomIds = new List<string>
                    {
                        "5d3eafe0-1392-4056-be3b-74d6a6298320",
                        "5d3eafe0-1392-4056-be3b-74d6a6298320",
                        "5d3eafe0-1392-4056-be3b-74d6a6298320",
                        "5d3eafe0-1392-4056-be3b-74d6a6298320"
                    },
                    CheckInDate = new DateTime(2024, 6, 1),
                    CheckOutDate = new DateTime(2024, 7, 1)
                }

            };

            context.AddRange(bookings);

            context.SaveChanges();
        }

    }
}
