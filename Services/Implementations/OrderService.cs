using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeHub.Models;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CoffeeHub.Services.Implementations
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDbContextFactory<CoffeeHubContext> _dbContextFactory;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IPromotionRepository promotionRepository,
            IMenuItemRepository menuItemRepository,
            ICustomerRepository customerRepository, 
            IEmployeeRepository employeeRepository,
            IDbContextFactory<CoffeeHubContext> dbContextFactory) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _promotionRepository = promotionRepository;
            _menuItemRepository = menuItemRepository;
            _customerRepository = customerRepository;
            _dbContextFactory = dbContextFactory;
        }

        public override async Task AddAsync(Order order)
        {
            var totalPrice = 0m;
            var totalQuantity = 0;
            var discountAmount = 0m;
            var customerLevel = Enums.CustomerLevel.Silver;
            
            order.EmployeeId = new Guid("00000000-0000-0000-0000-000000000001");
            
            foreach (var orderDetail in order.OrderDetails)
            {
                var menuItem = _menuItemRepository.GetByIdAsync(orderDetail.MenuItemId);
                var price = orderDetail.Quantity * menuItem.Result.Price;

                totalPrice += price;
                totalQuantity += orderDetail.Quantity;

                orderDetail.Price = menuItem.Result.Price;
                orderDetail.TotalPrice = price;
            }

            if (order.CustomerId == null)
            {
                order.CustomerId = new Guid("00000000-0000-0000-0000-000000000002");
            } else {
                var customer = await _customerRepository.GetByIdAsync(order.CustomerId.Value);
                var point = (int)Math.Floor(totalPrice / 1000);
                if (!customer.IsAvailable)
                {
                    throw new InvalidOperationException($"Customer with id {order.CustomerId} is not available.");
                }
                else
                {   
                    customerLevel = customer.CustomerLevel;
                    customer.Point += point;
                    await _customerRepository.UpdateAsync(customer);
                }
            }

            var PromotionId = order.PromotionId;
            if (PromotionId != null)
            {
                var isUsable = await _promotionRepository.IsPromotionUsableAsync(PromotionId.Value, totalPrice, DateTime.Now, customerLevel);

                if (isUsable)
                {
                    discountAmount = await _promotionRepository.CalculateDiscountAsync(PromotionId.Value, totalPrice);
                    await _promotionRepository.IncreaseUsageCountAsync(PromotionId.Value);
                }
            }

            order.TotalAmount = totalPrice;
            order.TotalQuantity = totalQuantity;
            order.DiscountAmount = discountAmount;
            order.FinalAmount = totalPrice - discountAmount;

            await _orderRepository.AddAsync(order);
        }
    }
}