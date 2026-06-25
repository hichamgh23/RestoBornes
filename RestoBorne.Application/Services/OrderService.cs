using RestoBorne.Application.DTOs;
using RestoBorne.Application.Interfaces;
using RestoBorne.Domain.Entities;

namespace RestoBorne.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto orderDto)
        {
            var order = new Order();
            var itemResponses = new List<OrderItemResponseDto>();

            foreach (var item in orderDto.Items)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product is null)
                {
                    throw new InvalidOperationException($"Produit introuvable : {item.ProductId}");
                }

                order.AddItem(product.Id, item.Quantity, product.Price);

                itemResponses.Add(new OrderItemResponseDto(
                    product.Name,
                    item.Quantity,
                    product.Price,
                    product.Price * item.Quantity
                ));
            }

            await _orderRepository.AddAsync(order);

            return new OrderResponseDto(order.Id, order.TotalAmount, order.Status, itemResponses);
        }
    }
}