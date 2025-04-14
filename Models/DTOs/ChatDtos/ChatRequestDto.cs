using System;

namespace CoffeeHub.Models.DTOs.ChatDtos;

public class ChatRequestDto
{
    public required string UserInput { get; set; }
    public required string SessionId { get; set; }
}
