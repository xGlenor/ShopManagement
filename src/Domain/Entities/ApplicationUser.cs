using Domain.Interfaces;

namespace Domain.Entities;

public class ApplicationUser : IEntity
{
    public string Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Email { get; set; }
    
    public string? PasswordHash { get; set; }
}