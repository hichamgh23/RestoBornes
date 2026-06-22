using System;
using System.Collections.Generic;
using System.Text;

namespace RestoBorne.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = String.Empty;

        public String Description { get; set; } = String.Empty;

        public decimal Price { get; set; }
        
        public bool IsAvailable { get; set; } = true;

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }


    }
}
