using AutoMapper;
using HotelApp.Services.HotelAPI;
using HotelApp.Services.HotelAPI.Data;
using HotelApp.Services.HotelAPI.Interfaces;
using HotelApp.Services.HotelAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
});

// [3.1] Neil's implementation would maybe override this
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());  // [3.2] Use ChatGPT to break down this line

builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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


try
{
    DbInitializer.InitDb(app);
}
catch (Exception ex)
{
    // [5] Apply loggin
    Console.WriteLine(ex.Message);
}

app.Run();
