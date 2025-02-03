using System;

namespace Core.Entities;

public class Product : BaseEntity
{
    // public int Id { get; set; } //It does not need anymore cause ID already inharited from the base entity
    public required string Name { get; set; }
    public required string Description { get; set; }
    public  decimal Price { get; set; }
    public required string PictureUrl { get; set; }
    public required string Type { get; set; }
    public required string Brand { get; set; }
    public int QuantityInStock { get; set; }
}
