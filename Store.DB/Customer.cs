namespace Store.DB;

public class Customer
{
    public Guid Id { get; set; }
    public string FistName { get; set; }
    public string LastName { get; set; }

    public List<Order> Orders { get; set; }
}
