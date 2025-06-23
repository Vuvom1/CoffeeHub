using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.DTOs.TableDtos;

public class AddTableDto
{
    public int Number { get; set; }
    public int Capacity { get; set; }
    public TableStatus Status { get; set; } = TableStatus.Available;
}
