using System;
using System.Collections.Generic;
using System.Text;

namespace RestoBorne.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public String Name { get; set; } = String.Empty;

        public String Description { get; set; } = String.Empty;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
