using CustomerWebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CustomerWebApi.Infrastructure.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Customer> Customers { get; set; }

    }
}
