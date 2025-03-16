using System;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations;

public class DeliveryService : BaseService<Delivery>, IDeliveryService
{
    private readonly IDeliveryRepository _deliveryRepository;
    public DeliveryService(IDeliveryRepository deliveryRepository) : base(deliveryRepository)
    {
        _deliveryRepository = deliveryRepository;
    }
}
