// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

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

    private string[] _args => Array.Empty<string>();

    public StoreContext CreateDbContext()
    {
        return CreateDbContext(_args);
    }
}
