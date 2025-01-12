namespace Store.DB;

public class CustomerAccount
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }

    public bool IsActive { get; set; }
}