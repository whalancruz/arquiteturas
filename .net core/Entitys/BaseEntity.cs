
namespace Entitys
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateAt { get; set; }
        public DateTime? RemoveAt { get; set; }
        
        // public byte[]? RowVersion { get; set; }
    }
}