using Microsoft.Extensions.Logging;

namespace Finalka;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ShowroomDbContext : DbContext
{
    private readonly ILogger<ShowroomDbContext> _logger;

    public DbSet<Client> Clients { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderService> OrderServices { get; set; }
    
    public ShowroomDbContext(DbContextOptions<ShowroomDbContext> options, ILogger<ShowroomDbContext> logger)
        : base(options)
    {
        _logger = logger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString("Default")!;
        optionsBuilder.UseSqlServer(connectionString);
    }
}
