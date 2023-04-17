using Microsoft.EntityFrameworkCore;
using Ninject;
using Util.Ninject;

namespace MeuProjeto
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AddDatabase(services);
            AddNinject(services);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public virtual void AddDatabase(IServiceCollection services)
        {
            services.AddDbContext<DbContexto>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        public virtual void AddNinject(IServiceCollection services)
        {
            var kernel = new StandardKernel();
            kernel.Load(new NinjectRegistrations());
            services.AddSingleton<IKernel>(kernel);
        }

    }

}