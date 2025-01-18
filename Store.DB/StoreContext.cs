using Microsoft.EntityFrameworkCore;

namespace Store.DB;

public class StoreContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAccount> CustomerAccounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public StoreContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
    }
}
