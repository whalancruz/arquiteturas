using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitys
{
    public abstract class BaseEntity
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdateAt { get; set; }
        public DateTime? RemoveAt { get; set; }
    }
}