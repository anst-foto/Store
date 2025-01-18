namespace Store.DB;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }

    public List<Order> Orders { get; set; }
}
