using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeHub.Enums;
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
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRecipeRepository _recipeRepository;
        private readonly IDbContextFactory<CoffeeHubContext> _dbContextFactory;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IPromotionRepository promotionRepository,
            IMenuItemRepository menuItemRepository,
            ICustomerRepository customerRepository, 
            IEmployeeRepository employeeRepository,
            IIngredientRepository ingredientRepository,
            IRecipeRepository recipeRepository,
            IDbContextFactory<CoffeeHubContext> dbContextFactory) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _promotionRepository = promotionRepository;
            _menuItemRepository = menuItemRepository;
            _ingredientRepository = ingredientRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _ingredientRepository = ingredientRepository;
            _recipeRepository = recipeRepository;
            _dbContextFactory = dbContextFactory;
        }

        

        public override async Task AddAsync(Order order)
        {
            var totalPrice = 0m;
            var totalQuantity = 0;
            var discountAmount = 0m;
            var customerLevel = Enums.CustomerLevel.Silver;

            //Check employee is available
            var employee = await _employeeRepository.GetByIdAsync(order.EmployeeId);
            if (employee == null) {
                order.EmployeeId = new Guid("00000000-0000-0000-0000-000000000001");
            }
            
            foreach (var orderDetail in order.OrderDetails)
            {
                var menuItem = _menuItemRepository.GetByIdAsync(orderDetail.MenuItemId);
                var price = orderDetail.Quantity * menuItem.Result.Price;

                // Check if the menu item is available
                if (menuItem.Result.IsAvailable == false)
                {
                    throw new InvalidOperationException($"Menu item with name {menuItem.Result.Name} is not available.");
                }

                // Check if the ingredient is enough
                var recipes = await _recipeRepository.GetByMenuItemIdAsync(orderDetail.MenuItemId);
                var ingredientQuantities = new Dictionary<Guid, int>();
                foreach (var recipe in recipes)
                {
                    ingredientQuantities.Add(recipe.IngredientId, (int)recipe.Quantity * orderDetail.Quantity);
                }

                var isEnough = await _ingredientRepository.IsEnoughAsync(ingredientQuantities);
                if (!isEnough)
                {
                    throw new InvalidOperationException($"Ingredient is not enough for menu item with name {menuItem.Result.Name}.");
                }

                // Update ingredient stock
                using var context = _dbContextFactory.CreateDbContext();
                foreach (var ingredientQuantity in ingredientQuantities)
                {
                    var ingredient = await context.Ingredients.FindAsync(ingredientQuantity.Key);
                    if (ingredient != null)
                    {
                        ingredient.TotalQuantity -= ingredientQuantity.Value;
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new InvalidOperationException($"Ingredient with id {ingredientQuantity.Key} not found.");
                    }
                }

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

        public async Task CancelOrderAsync(Guid orderId)
        {
            await _orderRepository.UpdateOrderStatusAsync(orderId, OrderStatus.Cancelled);
        }

        public async Task CompleteOrderAsync(Guid orderId)
        {
            await _orderRepository.UpdateOrderStatusAsync(orderId, OrderStatus.Completed);
        }

        public Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            return _orderRepository.GetOrdersByCustomerIdAsync(customerId);
        }

        public Task<IEnumerable<Order>> GetPendingOrProcessingOrdersAsync()
        {
            var orderStatuses = new List<OrderStatus>
            {
                OrderStatus.Pending,
                OrderStatus.Processing
            };
            return _orderRepository.GetOrdersByStatusesAsync(orderStatuses);
        }


        public Task<IEnumerable<Order>> GetProcessingOrPreparingOrdersAsync()
        {
            var orderStatuses = new List<OrderStatus>
            {
                OrderStatus.Processing,
                OrderStatus.Preparing
            };
            return _orderRepository.GetOrdersByStatusesAsync(orderStatuses);
        }

        public Task<IEnumerable<Order>> GetReadyOrdersAsync()
        {
            var orderStatuses = new List<OrderStatus>
            {
                OrderStatus.ReadyForPickup
            };
            return _orderRepository.GetOrdersByStatusesAsync(orderStatuses);
        }

        public async Task MarkOrderAsReadyAsync(Guid orderId)
        {
            await _orderRepository.UpdateOrderStatusAsync(orderId, OrderStatus.ReadyForPickup);
        }

        public async Task StartPreparingOrderAsync(Guid orderId)
        {
            await _orderRepository.UpdateOrderStatusAsync(orderId, OrderStatus.Preparing);
        }

        public Task StartProcessingOrderAsync(Guid orderId)
        {
            return _orderRepository.UpdateOrderStatusAsync(orderId, OrderStatus.Processing);
        }

        public async Task UpadateOrderStatusAsync(Guid orderId, OrderStatus orderStatus)
        {
            await _orderRepository.UpdateOrderStatusAsync(orderId, orderStatus);
        }
    }
}