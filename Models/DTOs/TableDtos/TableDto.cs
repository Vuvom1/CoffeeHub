using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.DTOs.TableDtos;

public class TableDto
{
    public Guid Id { get; set; }    
    public int Number { get; set; }
    public int Capacity { get; set; }
    public TableStatus Status { get; set; }
    public virtual ICollection<TableDto> TableBookings { get; set; } = new HashSet<TableDto>();
}
