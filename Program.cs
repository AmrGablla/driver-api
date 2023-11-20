using Repositories;
using Models;
using Services;
using SQLite;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (!System.IO.File.Exists(builder.Configuration.GetConnectionString("DefaultConnection")))
{
    SQLiteConnection _db = new SQLiteConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
    _db.CreateTable<Driver>();
}
builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();

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
