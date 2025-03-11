using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ShowroomManager
{
    public class ShowroomContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ShowroomContext(DbContextOptions<ShowroomContext> options) : base(options) 
        {
            Database.Migrate();  
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);

            var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()
                .GetConnectionString("Default");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
             modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe" },
                new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Smith" },
                new Customer { CustomerId = 3, FirstName = "Bob", LastName = "Johnson" },
                new Customer { CustomerId = 4, FirstName = "Alice", LastName = "Williams" },
                new Customer { CustomerId = 5, FirstName = "Charlie", LastName = "Brown" },
                new Customer { CustomerId = 6, FirstName = "Eve", LastName = "Davis" },
                new Customer { CustomerId = 7, FirstName = "Frank", LastName = "Miller" },
                new Customer { CustomerId = 8, FirstName = "Grace", LastName = "Wilson" },
                new Customer { CustomerId = 9, FirstName = "Hank", LastName = "Moore" },
                new Customer { CustomerId = 10, FirstName = "Ivy", LastName = "Taylor" }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { CarId = 1, CustomerId = 1, Make = "Toyota", Model = "Corolla", Color = "Red" },
                new Car { CarId = 2, CustomerId = 2, Make = "Honda", Model = "Civic", Color = "Blue" },
                new Car { CarId = 3, CustomerId = 3, Make = "Ford", Model = "Focus", Color = "Green" },
                new Car { CarId = 4, CustomerId = 4, Make = "Chevrolet", Model = "Malibu", Color = "Black" },
                new Car { CarId = 5, CustomerId = 5, Make = "BMW", Model = "320i", Color = "White" }
            );

            modelBuilder.Entity<Sale>().HasData(
                new Sale { SaleId = 1, EmployeeId = 1, CustomerId = 1, CarId = 1 },
                new Sale { SaleId = 2, EmployeeId = 2, CustomerId = 2, CarId = 2 },
                new Sale { SaleId = 3, EmployeeId = 3, CustomerId = 3, CarId = 3 },
                new Sale { SaleId = 4, EmployeeId = 4, CustomerId = 4, CarId = 4 },
                new Sale { SaleId = 5, EmployeeId = 5, CustomerId = 5, CarId = 5 }
            );
        }
    }
}