using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeHub.Models.Domains;
using CoffeeHub.Repositories.Interfaces;
using CoffeeHub.Services.Interfaces;

namespace CoffeeHub.Services.Implementations
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IPromotionRepository promotionRepository,
            IMenuItemRepository menuItemRepository,
            ICustomerRepository customerRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _promotionRepository = promotionRepository;
            _menuItemRepository = menuItemRepository;
            _customerRepository = customerRepository;
        }

        public async Task AddWithDetailsAsync(Order order, IEnumerable<OrderDetail> orderDetails)
        {
            // Check if customer is guest
            var guestCustomer = await _customerRepository.GetByEmailAsync("guest@gmail.com");

            if (order.CustomerId == null)
            {
                if (guestCustomer == null)
                {
                    throw new InvalidOperationException("Guest customer not found.");
                }
                order.CustomerId = guestCustomer.Id;
            }

            // Check if customer is active
            var isActiveCustomer = await _customerRepository.IsActiveAsync(order.CustomerId.Value);

            if (!isActiveCustomer)
            {
                throw new InvalidOperationException($"Customer with id {order.CustomerId} is not available.");
            }

            // Check if promotion is active
            if (order.PromotionId != null)
            {
                var isActivePromotion = await _promotionRepository.IsPromotionActiveAsync(order.PromotionId.Value);

                if (!isActivePromotion)
                {
                    throw new InvalidOperationException($"Promotion with id {order.PromotionId} is not available.");
                }
            }
            
            var createdOrder = await _orderRepository.AddAndReturnAsync(order);

            var totalPrice = 0m;
            var totalQuantity = 0;

            foreach (var orderDetail in orderDetails)
            {
                var isActiveMenuItem = await _menuItemRepository.IsActivatedAsync(orderDetail.MenuItemId);

                if (!isActiveMenuItem)
                {
                    await _orderRepository.DeleteAsync(createdOrder);

                    throw new InvalidOperationException($"MenuItem with id {orderDetail.MenuItemId} is not available.");
                }

                var menuItemPrice = await _menuItemRepository.GetPriceByIdAsync(orderDetail.MenuItemId);

                //Calculate values for order detail 
                orderDetail.OrderId = createdOrder.Id;
                orderDetail.Price = menuItemPrice;
                orderDetail.TotalPrice = orderDetail.Price * orderDetail.Quantity;

                //Calculate values for order
                totalQuantity += orderDetail.Quantity;
                totalPrice += orderDetail.TotalPrice;

                // Check for duplicate order details
                var existingOrderDetail = await _orderDetailRepository.FindAsync(od => od.OrderId == createdOrder.Id && od.MenuItemId == orderDetail.MenuItemId);
                if (existingOrderDetail != null)
                {
                    continue;
                }

                await _orderDetailRepository.AddAsync(orderDetail);
            }

            if (order.PromotionId != null)
            {
                var promotion = await _promotionRepository.GetByIdAsync(order.PromotionId.Value);
                var isUsable = await _promotionRepository.IsPromotionUsableAsync(promotion.Id, totalPrice, DateTime.Now);

                if (promotion != null && isUsable)
                {
                    var discount = await _promotionRepository.CalculateDiscountAsync(promotion.Id, totalPrice);
                    order.DiscountAmount = discount;
                    order.FinalAmount = totalPrice - discount;
                }
            }
            else
            {
                order.FinalAmount = totalPrice;
            }

            //Add point to customer
            var customer = await _customerRepository.GetByIdAsync(order.CustomerId.Value);
            var point = (int) Math.Floor(totalPrice / 1000);
            await _customerRepository.IncreasePointAsync(customer.Id, point);

            createdOrder.TotalAmount = totalPrice;
            createdOrder.TotalQuantity = totalQuantity;

            await _orderRepository.UpdateAsync(createdOrder);
        }
    }
}