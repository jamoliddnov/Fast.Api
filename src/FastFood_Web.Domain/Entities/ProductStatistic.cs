using FastFood_Web.Domain.Common;

namespace FastFood_Web.Domain.Entities
{
    public class ProductStatistic : Base
    {
        public DateTime DateTime { get; set; }
        public long Count { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; } = default!;

    }
}
