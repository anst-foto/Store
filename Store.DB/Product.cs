// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Store.DB;

[Table("table_products")]
[Index(nameof(Name))]
public class Product : IEquatable<Product>
{
    [Column("id")] public Guid Id { get; set; }

    [Column("name")] [Required] public string? Name { get; set; }

    [Column("price", TypeName = "money")]
    [Required]
    public decimal Price { get; set; }

    [Column("quantity")] [Required] public int Quantity { get; set; }

    [Column("is_active")] [Required] public bool IsActive { get; set; } = true;

    #region IEquatable

    public bool Equals(Product? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id.Equals(other.Id) && Name == other.Name && Price == other.Price && Quantity == other.Quantity &&
               IsActive == other.IsActive;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        return Equals((Product)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Price, Quantity, IsActive);
    }

    public static bool operator ==(Product? left, Product? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Product? left, Product? right)
    {
        return !Equals(left, right);
    }

    #endregion
}
