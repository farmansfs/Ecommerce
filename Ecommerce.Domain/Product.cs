using System;

namespace Ecommerce.Domain
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
