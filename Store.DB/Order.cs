using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

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

    [NotMapped]
    public Dictionary<Product, int> Products { get; set; }
    [Column(TypeName = "jsonb")]
    public string ProductsJson
    {
        get => JsonSerializer.Serialize(Products);
        set => Products = JsonSerializer.Deserialize<Dictionary<Product, int>>(value);
    }
}
