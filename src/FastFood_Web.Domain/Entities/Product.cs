using FastFood_Web.Domain.Common;

namespace FastFood_Web.Domain.Entities
{
    public class Product : Base
    {
        public string NameProduct { get; set; } = String.Empty;
        public double Price { get; set; }
        public string ImagePath { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

        public long CategoryProductId { get; set; }
        public virtual CategoryProduct CategoryProduct { get; set; } = default!;
    }
}
