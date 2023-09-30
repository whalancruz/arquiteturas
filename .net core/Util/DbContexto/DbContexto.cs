using Entitys;
using Microsoft.EntityFrameworkCore;
using Util.EntitiesConfigurations;

public class DbContexto : DbContext
{
    private readonly IConfiguration _configuration;
    public DbContexto(DbContextOptions<DbContexto> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        modelBuilder.ApplyConfiguration(new EnvironmentsConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
    
    public DbSet<UsersEntity> Users { get; set; }

}
