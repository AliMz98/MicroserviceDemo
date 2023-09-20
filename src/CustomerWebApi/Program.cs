using CustomerWebApi.Application.Interfaces;
using CustomerWebApi.Infrastructure.Persistence;
using CustomerWebApi.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var dbHost = Environment.GetEnvironmentVariable(("DB_Host"));
var dbName = Environment.GetEnvironmentVariable(("DB_Name"));
var dbPassword = Environment.GetEnvironmentVariable(("DB_Password"));

var ConnectionString = $"Server={dbHost};Database={dbName};User Id=sa;Password={dbPassword};TrustServerCertificate=True;";

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly()); 

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

var app = builder.Build();


app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<AppDbContext>();
await context?.Database.MigrateAsync();

app.Run();

