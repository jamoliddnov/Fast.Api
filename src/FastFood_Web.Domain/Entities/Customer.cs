using FastFood_Web.Domain.Common;

namespace FastFood_Web.Domain.Entities
{
    public class Customer : Base
    {
        public string TelegramId { get; set; } = String.Empty;
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;
    }
}
