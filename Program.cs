using Repositories;
using Models;
using Services;
using SQLite;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();

var app = builder.Build();

if (!System.IO.File.Exists(builder.Configuration.GetConnectionString("DefaultConnection")))
{
    app.Logger.LogInformation("database file not exists will create one.");
    SQLiteConnection _db = new SQLiteConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
    _db.CreateTable<Driver>();
}

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
