using System;
using CoffeeHub.Enums;

namespace CoffeeHub.Models.DTOs.TableBookingDtos;

public class UpdateTableBookingDto
{
    public Guid Id { get; set; }
    public DateTime BookingDate { get; set; }
    public TimeOnly Duration { get; set; }
    public int NumberOfGuests { get; set; }
    public required string CustomerName { get; set; }
    public required string CustomerPhone { get; set; }
    public required string CustomerEmail { get; set; }
    public string? Notes { get; set; }
    public TableBookingStatus Status { get; set; }
    public Guid TableId { get; set; }
}
