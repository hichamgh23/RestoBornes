namespace RestoBorne.Application.DTOs;

public record CreateOrderDto(List<OrderItemDto> Items);