using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Application.Interfaces;
using ProductWebApi.Infrastructure.Persistence;
using ProductWebApi.Infrastructure.Repositories;
using System.Reflection;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbHost = Environment.GetEnvironmentVariable("DB_Host");
var dbName = Environment.GetEnvironmentVariable("DB_Name");
var dbPassword = Environment.GetEnvironmentVariable("DB_Password");
var dbPort = Environment.GetEnvironmentVariable("DB_Port");

var ConnectionString = $"Server={dbHost};port={dbPort};Database={dbName};user=root;Password={dbPassword};";

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(ConnectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<AppDbContext>();
await context?.Database.MigrateAsync();

app.Run();
