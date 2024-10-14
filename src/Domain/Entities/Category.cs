using Domain.Interfaces;

namespace Domain.Entities;

public class Category: IEntity
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<Product> Products { get; set; }
}