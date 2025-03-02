// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Store.DB;

public enum OrderType
{
    Card,
    Sell
}

[Table("table_orders")]
public class Order : IEquatable<Order>
{
    [Column("id")] public Guid Id { get; set; }

    [Column("customer_id")] public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    [Column("type")] public OrderType Type { get; set; }

    [NotMapped] public Dictionary<Guid, int> Products { get; set; }

    [Column("products", TypeName = "jsonb")]
    [Required]
    public string ProductsJson
    {
        get => JsonSerializer.Serialize(Products);
        set => Products = JsonSerializer.Deserialize<Dictionary<Guid, int>>(value);
    }

    #region IEquatable

    public bool Equals(Order? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id.Equals(other.Id) && CustomerId.Equals(other.CustomerId) && Customer.Equals(other.Customer) &&
               Type == other.Type && Products.Equals(other.Products);
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

        return Equals((Order)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, CustomerId, Customer, (int)Type, Products);
    }

    public static bool operator ==(Order? left, Order? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Order? left, Order? right)
    {
        return !Equals(left, right);
    }

    #endregion
}
