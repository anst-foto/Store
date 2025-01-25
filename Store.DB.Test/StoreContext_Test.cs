namespace Store.DB.Test;

public class StoreContextTest
{
    #region InitDB

    private readonly StoreContext _context;

    private readonly Customer _customer;

    private readonly Product _product1;
    private readonly Product _product2;

    private readonly Order _order1;
    private readonly Order _order2;

    private void InitDb()
    {
        var orders = _context.Orders.ToList();
        _context.Orders.RemoveRange(orders);
        var products = _context.Products.ToList();
        _context.Products.RemoveRange(products);
        var customers = _context.Customers.ToList();
        _context.Customers.RemoveRange(customers);
        _context.SaveChanges();

        _context.Customers.Add(_customer);

        _context.Products.Add(_product1);
        _context.Products.Add(_product2);

        _context.Orders.Add(_order1);
        _context.Orders.Add(_order2);

        _context.SaveChanges();
    }

    public StoreContextTest()
    {
        var contextFactory = new StoreContextFactory();
        _context = contextFactory.CreateDbContext();

        _customer = new Customer
        {
            Id = new Guid("1c6f9022-9d47-4597-ad3a-a062b4165dd0"),
            FirstName = "Андрей",
            LastName = "Старинин",
            Email = "andrey@starinin.ru",
            Password = "1234",
            IsActive = true
        };

        _product1 = new Product
        {
            Id = new Guid("1c6f9022-9d47-4597-ad3a-a062b4165dd1"),
            Name = "Product 1",
            Price = new decimal(125.7),
            Quantity = 10,
            IsActive = true
        };
        _product2 = new Product
        {
            Id = new Guid("1c6f9022-9d47-4597-ad3a-a062b4165dd2"),
            Name = "Product 2",
            Price = 10,
            Quantity = 1,
            IsActive = false
        };

        _order1 = new Order
        {
            Id = new Guid("1c6f9022-9d47-4597-ad3a-a062b4165dd4"),
            Customer = _customer,
            Type = OrderType.Card,
            Products = new Dictionary<Guid, int> { { _product1.Id, 1 } }
        };
        _order2 = new Order
        {
            Id = new Guid("1c6f9022-9d47-4597-ad3a-a062b4165dd5"),
            Customer = _customer,
            Type = OrderType.Sell,
            Products = new Dictionary<Guid, int> { { _product2.Id, 20 } }
        };

        InitDb();
    }

    #endregion

    [Fact]
    public void Customers_Test()
    {
        var expectedCustomers = new List<Customer>() { _customer };

        var actualCustomers = _context.Customers.ToList();

        Assert.Equal(expectedCustomers, actualCustomers);
    }

    [Fact]
    public void Products_Test()
    {
        var expectedProducts = new List<Product> { _product1, _product2 };

        var actualProducts = _context.Products.ToList();

        Assert.Equal(expectedProducts, actualProducts);
    }

    [Fact]
    public void Orders_Test()
    {
        var expectedOrders = new List<Order> { _order1, _order2 };

        var actualOrders = _context.Orders.ToList();

        Assert.Equal(expectedOrders, actualOrders);
    }
}
