using Domain.Entities;

namespace ShopManagementService.Application.Modules.Products.Dtos;

public class ProductDto
{
    public string Id { get; init; }
    public string Name { get; init; } 
    public string Description { get; init; }
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }
    public bool IsAvailable { get; init; }
    public DateTime CreatedDate { get; init; }

}