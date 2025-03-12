using System;
using System.ComponentModel.DataAnnotations.Schema;
using CoffeeHub.Enums;
using CoffeeHub.Models.Domains;

namespace CoffeeHub.Models.Domains
{
    public class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? IsAvailable { get; set; }
        public int Point { get; set; } = 0;
        public CustomerLevel CustomerLevel { get; set; } = CustomerLevel.Silver;
        public Guid AuthId { get; set; }
        public virtual Auth Auth { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}