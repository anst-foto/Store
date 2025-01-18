using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Store.DB;

[Table("table_customers")]
[Index(nameof(Login), IsUnique = true)]
[Index(nameof(LastName))]
[Index(nameof(FirstName))]
public class Customer : IEquatable<Customer>
{
    [Column("id")]
    public Guid Id { get; set; }

    [Column("first_name")]
    [Required]
    public string FirstName { get; set; }

    [Column("last_name")]
    [Required]
    public string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{LastName} {FirstName}";

    [Column("login")]
    [Required]
    public string Login
    {
        get => Email;
        set => Email = value.ToLower();
    }

    [NotMapped]
    public string Email { get; set; }

    [Column("password")]
    [Required]
    public string Password { get; set; }

    [Column("is_active")]
    [Required]
    public bool IsActive { get; set; } =  true;

    public List<Order> Orders { get; set; }

    #region IEquatable

    public bool Equals(Customer? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id.Equals(other.Id) && FirstName == other.FirstName && LastName == other.LastName && Email == other.Email && Password == other.Password && IsActive == other.IsActive;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Customer)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, FirstName, LastName, Email, Password, IsActive);
    }

    public static bool operator ==(Customer? left, Customer? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Customer? left, Customer? right)
    {
        return !Equals(left, right);
    }

    #endregion
}
