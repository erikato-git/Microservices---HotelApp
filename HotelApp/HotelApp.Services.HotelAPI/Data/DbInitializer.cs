
using HotelApp.Services.HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services.HotelAPI.Data
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
            
            if(context.Hotels.Any())
            {
                Console.WriteLine("Database has already been initialized with Hotels");
                return;
            }

            var hotels = new List<Hotel>()
            {
                new Hotel
                {
                    Id = Guid.Parse("bcc20b49-e728-46cf-89e3-afa79e297d70"),
                    HotelName = "Donwtown Hostel",
                    HotelAddress = "Istedgade 1",
                    Country = "Denmark",
                    City = "Copenhagen",
                    Stars = 3,
                    Rooms = new List<Room>
                    {
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d0"),
                            RoomType = "SingleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a0"),
                                BedType = "SingleBed",
                                PricePrNight = 200.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d1"),
                            RoomType = "SingleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a1"),
                                BedType = "SingleBed",
                                PricePrNight = 200.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d2"),
                            RoomType = "DoubleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a2"),
                                BedType = "DoubleBed",
                                PricePrNight = 350.0,
                                PeopleCapacity = 2
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d3"),
                            RoomType = "DoubleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a3"),
                                BedType = "DoubleBed",
                                PricePrNight = 350.0,
                                PeopleCapacity = 2
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d4"),
                            RoomType = "Dormitory",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a4"),
                                BedType = "Bunk",
                                PricePrNight = 80.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 6
                        }
                    }
                },

                new Hotel
                {
                    Id = Guid.Parse("bcc20b49-e728-46cf-89e3-afa79e297d71"),
                    HotelName = "The Ritz London",
                    HotelAddress = "PICCADILLY 1",
                    Country = "England",
                    City = "London",
                    Stars = 5,
                    Rooms = new List<Room>
                    {
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d5"),
                            RoomType = "SingleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a5"),
                                BedType = "SingleBed",
                                PricePrNight = 400.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d6"),
                            RoomType = "SingleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a6"),
                                BedType = "SingleBed",
                                PricePrNight = 400.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d7"),
                            RoomType = "DoubleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a7"),
                                BedType = "DoubleBed",
                                PricePrNight = 750.0,
                                PeopleCapacity = 2
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d8"),
                            RoomType = "DoubleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a8"),
                                BedType = "DoubleBed",
                                PricePrNight = 750.0,
                                PeopleCapacity = 2
                            },
                            AmountOfBeds = 1
                        }
                    }
                },

                new Hotel
                {
                    Id = Guid.Parse("bcc20b49-e728-46cf-89e3-afa79e297d72"),
                    HotelName = "Cabinn City Berlin",
                    HotelAddress = "Kreuzberg 1",
                    Country = "Germany",
                    City = "Berlin",
                    Stars = 2,
                    Rooms = new List<Room>
                    {
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a62983d9"),
                            RoomType = "Dormitory",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc8a9"),
                                BedType = "Bunk",
                                PricePrNight = 80.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 6
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a6298310"),
                            RoomType = "Dormitory",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc810"),
                                BedType = "Bunk",
                                PricePrNight = 80.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 6
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a6298311"),
                            RoomType = "Dormitory",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc811"),
                                BedType = "Bunk",
                                PricePrNight = 80.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 6
                        }
                    }
                },

                new Hotel
                {
                    Id = Guid.Parse("bcc20b49-e728-46cf-89e3-afa79e297d73"),
                    HotelName = "Hotel Hilton",
                    HotelAddress = "Kgs. Nytorv 1",
                    Country = "Denmark",
                    City = "Copenhagen",
                    Stars = 5,
                    Rooms = new List<Room>
                    {
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a6298312"),
                            RoomType = "SingleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc812"),
                                BedType = "SingleBed",
                                PricePrNight = 250.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a6298313"),
                            RoomType = "SingleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc813"),
                                BedType = "SingleBed",
                                PricePrNight = 250.0,
                                PeopleCapacity = 1
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a6298314"),
                            RoomType = "DoubleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc814"),
                                BedType = "DoubleBed",
                                PricePrNight = 450.0,
                                PeopleCapacity = 2
                            },
                            AmountOfBeds = 1
                        },
                        new Room
                        {
                            Id = Guid.Parse("5d3eafe0-1392-4056-be3b-74d6a6298315"),
                            RoomType = "DoubleRoom",
                            Bed = new Bed
                            {
                                Id = Guid.Parse("ab9ea72f-50ef-4c94-b6a8-356bfc6cc815"),
                                BedType = "DoubleBed",
                                PricePrNight = 450.0,
                                PeopleCapacity = 2
                            },
                            AmountOfBeds = 1
                        }
                    }
                },





            };

            context.AddRange(hotels);

            context.SaveChanges();
        }
    }
}
