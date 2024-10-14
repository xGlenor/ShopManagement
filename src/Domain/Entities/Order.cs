using Domain.Interfaces;

namespace Domain.Entities;

public class Order: IEntity
{
    public string Id { get; set; }                      // Unikalny identyfikator zamówienia
    public DateTime OrderDate { get; set; }          // Data złożenia zamówienia
    public DateTime? ShippedDate { get; set; }       // Data wysyłki (opcjonalna)
    public decimal TotalAmount { get; set; }         // Łączna kwota zamówienia

    // Relacja do klienta
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    // Relacja do szczegółów zamówienia
    public List<OrderItem> OrderItems { get; set; }
}