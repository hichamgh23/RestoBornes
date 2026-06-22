using System;
using System.Collections.Generic;

namespace RestoBorne.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // Utilise un Enum pour éviter les erreurs de saisie
        public string Status { get; set; } = "Pending";

        // La relation : Une commande a plusieurs lignes de commande
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        public decimal TotalAmount { get; set; }
    }
}