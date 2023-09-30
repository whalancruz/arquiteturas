using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entitys;

namespace Util.EntitiesConfigurations
{
    public class UsersConfiguration : BaseConfiguration<UsersEntity>
    {
        public new void Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.Nome);
            builder.Property(x => x.Email);
            builder.Property(x => x.Password);
        }
    }
}