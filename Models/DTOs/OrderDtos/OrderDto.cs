using System;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models.DTOs.OrderDtos;

public class OrderDto
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public required int TotalQuantity { get; set; }
    public required string Status { get; set; }
    public required Guid EmployeeId { get; set; }
    public Guid? CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public virtual Employee Employee { get; set; } = null!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
}
