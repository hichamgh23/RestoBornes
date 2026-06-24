namespace RestoBorne.Application.DTOs;

public record OrderResponseDto(
    Guid Id,
    decimal TotalAmount,
    string Status,
    List<OrderItemResponseDto> Items
);

public record OrderItemResponseDto(
    string ProductName,
    int Quantity,
    decimal UnitPrice,
    decimal SubTotal
);