using System.ComponentModel.DataAnnotations.Schema;

namespace Entitys
{
    [Table("teste")]
    public class TesteEntity : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Observacao { get; set; }
    }
}