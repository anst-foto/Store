namespace Store.DB;

public class Customer
{
    public Guid Id { get; set; }
    public string FistName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }

    public bool IsActive { get; set; }

    public List<Order> Orders { get; set; }
}
