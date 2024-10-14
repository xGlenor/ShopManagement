using Domain.Interfaces;

namespace Domain.Entities;

public class Product: IEntity
{
    public string Id { get; set; }
    public string Name { get; set; } 
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}