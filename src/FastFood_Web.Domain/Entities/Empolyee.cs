using FastFood_Web.Domain.Common;

namespace FastFood_Web.Domain.Entities
{
    public class Empolyee : Base
    {
        public string PassportSerialNumber { get; set; } = String.Empty;
        public long Salary { get; set; }
        public string ImagePath { get; set; } = String.Empty;
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;
        public long CategoryEmpolyeeId { get; set; }
        public virtual CategoryEmpolyee CategoryEmpolyee { get; set; } = default!;

    }
}
