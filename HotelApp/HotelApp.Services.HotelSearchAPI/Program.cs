using HotelApp.Services.HotelSearchAPI.Interfaces;
using HotelApp.Services.HotelSearchAPI.Repositories;
using HotelApp.Services.HotelSearchAPI.Service;
using HotelApp.Services.HotelSearchAPI.Service.IService;
using HotelApp.Services.HotelSearchAPI.Util;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient("HotelAPI", u => u.BaseAddress = new Uri(builder.Configuration["ServiceUrls:HotelAPI"]));
builder.Services.AddHttpClient("BookingAPI", u => u.BaseAddress = new Uri(builder.Configuration["ServiceUrls:BookingAPI"]));
// [7] Find out how to make Bookings requests completely secret. Only Admin and HotelSearchAPI should be allowed to access all bookings
builder.Services.AddScoped<IBookingAPI_SvcHttpClient, BookingAPI_SvcHttpClient>();
builder.Services.AddScoped<IHotelAPI_SvcHttpClient, HotelAPI_SvcHttpClient>();

builder.Services.AddScoped<IHotelSearchAPI_Repository,HotelSearchAPI_Repository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<DateOnlySchemaFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
