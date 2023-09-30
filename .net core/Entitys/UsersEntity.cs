using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entitys
{
    [Table("Users")]
    public class UsersEntity : BaseEntity
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}