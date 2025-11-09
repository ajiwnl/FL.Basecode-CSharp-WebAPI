using FL.Basecode.Data;
using FL.Basecode.Data.Interfaces;
using FL.Basecode.Data.Repository;
using FL.Basecode.Services.Implementation;
using FL.Basecode.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("Data Source=C:\\Users\\alvin\\Source\\Repos\\FL.SplitMoney-CSharp-WebAPI\\FL.Basecode.Data\\app.db"));

builder.Services.AddScoped<iIconsRepository, IconsRepository>();

// Add services to the container.
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<iIconService, IconService>();


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

app.Run();
