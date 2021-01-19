using BlazingCoffee.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazingCoffee.Server
{
    public class CoffeeContext : DbContext
    {
        public static readonly ILoggerFactory ConsoleLogger
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Not for production, show EF query data in the console
            optionsBuilder.UseLoggerFactory(ConsoleLogger);
            // Show EF Query parameter values in the console
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
