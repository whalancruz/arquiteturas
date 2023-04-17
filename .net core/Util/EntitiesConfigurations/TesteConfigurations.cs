
using Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Util.EntitiesConfigurations
{
    public class TesteConfiguration : BaseConfiguration<TesteEntity>
    {
        public new void Configure(EntityTypeBuilder<TesteEntity> builder)
        {
            builder.ToTable("teste");
        }
    }
}