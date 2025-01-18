using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Store.DB;

public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
{
    public StoreContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
#if DEBUG
        var connectionString = config.GetConnectionString("TestConnection");
#elif RELEASE
        var connectionString = config.GetConnectionString("PublicConnection");
#endif

        return new StoreContext(connectionString);
    }
}
