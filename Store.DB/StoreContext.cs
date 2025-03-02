// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using Microsoft.EntityFrameworkCore;

namespace Store.DB;

public class StoreContext : DbContext
{
    private readonly string _connectionString;

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    public StoreContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseNpgsql(_connectionString,
                o => o.MapEnum<OrderType>("order_type"));
    }
}
