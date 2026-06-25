using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoBorne.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string Status { get; private set; }
        public decimal TotalAmount { get; private set; }

        private readonly List<OrderItem> _items = new();
        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        public Order()
        {
            Id = Guid.NewGuid();
            OrderDate = DateTime.UtcNow;
            Status = "Pending";
        }

        public void AddItem(Guid productId, int quantity, decimal unitPrice)
        {
            var item = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = Id,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            _items.Add(item);
            RecalculateTotal();
        }

        private void RecalculateTotal()
        {
            TotalAmount = _items.Sum(i => i.UnitPrice * i.Quantity);
        }
    }
}