namespace Store.DB;

public enum OrderType
{
    Card,
    Sell
}

public class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

    public OrderType Type { get; set; }

    public Dictionary<Product, int> Products { get; set; }
}
