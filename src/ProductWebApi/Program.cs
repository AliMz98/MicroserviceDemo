using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductWebApi.Application.Interfaces;
using ProductWebApi.Infrastructure.Persistence;
using ProductWebApi.Infrastructure.Repositories;
using System.Reflection;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var ConnectionString = $"Server=localhost;port=3308;Database=dms_product;user=root;Password=b@B123456;";

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
