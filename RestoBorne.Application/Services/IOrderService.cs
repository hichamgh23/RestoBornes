using RestoBorne.Application.DTOs;

namespace RestoBorne.Application.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto orderDto);
    }
}