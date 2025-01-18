namespace Store.DB.Test;

public class StoreContextTest
{
    [Fact]
    public void SearchCustomer_PositiveTest()
    {
        var contextFactory = new StoreContextFactory();
        var context = contextFactory.CreateDbContext();

        var expectedCustomer = new Customer()
        {
            Id = new Guid("f5bd24f6-ec26-4ef3-8153-dd22b17da1e9"),
            FirstName = "Андрей",
            LastName = "Старинин",
            Email = "andrey@starinin.ru",
            Password = "1234",
            IsActive = true
        };

        var actualCustomer = context.Customers.SingleOrDefault(c => c.Id == new Guid("f5bd24f6-ec26-4ef3-8153-dd22b17da1e9"));

        Assert.Multiple(
            () => Assert.NotNull(actualCustomer),
            () => Assert.Equal(expectedCustomer, actualCustomer));
    }

    [Fact]
    public void SearchCustomer_NegativeTest()
    {
        var contextFactory = new StoreContextFactory();
        var context = contextFactory.CreateDbContext();

        var actualCustomer = context.Customers.SingleOrDefault(c => c.Id == Guid.Empty);

        Assert.Null(actualCustomer);
    }
}
