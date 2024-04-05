using AutoMapper;

namespace HotelApp.Services.BookingAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            // [3] Consider to use Neil's way of implementing the Automapper-configurations
            var mappingConfig = new MapperConfiguration(config =>
            {
                //config.CreateMap<"DTO","ModelClass">
            });

            return mappingConfig;
        }
    }
}
