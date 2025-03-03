using System;

namespace CoffeeHub.Models.Domains;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public required int TotalQuantity { get; set; }
    public required string Status { get; set; }
    public long? EmployeeId { get; set; }
    public required long CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new HashSet<OrderDetail>();
}
