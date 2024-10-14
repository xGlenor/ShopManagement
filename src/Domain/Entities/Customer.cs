using Domain.Interfaces;

namespace Domain.Entities;

public class Customer: IEntity
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    
    public List<Order> Orders { get; set; }
}