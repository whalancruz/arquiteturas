using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ninject;
using Util.Ninject;
namespace Plantmanager
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            this.AddDatabase(services);
            this.AddNinject(services);
            this.AddSwagger(services);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Habilitar o middleware do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
                c.RoutePrefix = string.Empty; // Para acessar o Swagger UI na raiz do projeto
                c.DisplayRequestDuration(); // Opcional: exibe a duração das requisições no Swagger UI
                c.OAuthClientId(_configuration["ChaveJwt:SecretKey"]); // Substitua pelo seu ClientId de autenticação JWT
                c.OAuthClientSecret(_configuration["ChaveJwt:SecretKey"]); // Substitua pelo seu ClientSecret de autenticação JWT
                c.OAuthAppName("nomeaplicacao"); // Substitua pelo nome da sua API
            });

            app.UseRouting();

            app.UseAuthentication(); // Certifique-se de adicionar essa linha depois de app.UseSwaggerUI()
            app.UseAuthorization(); // Certifique-se de adicionar essa linha depois de app.UseAuthentication()

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        public virtual void AddDatabase(IServiceCollection services)
        {
            services.AddDbContext<DbContexto>(options => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));
        }

        public virtual void AddNinject(IServiceCollection services)
        {
            var kernel = new StandardKernel();
            kernel.Load(new NinjectRegistrations());
            services.AddSingleton<IKernel>(kernel);
        }

        public virtual void AddSwagger(IServiceCollection services)
        {

            services
                .AddAuthentication(options =>
                 {
                     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 })
                .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = _configuration["ChaveJwt:Issuer"],
                         ValidAudience = _configuration["ChaveJwt:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ChaveJwt:SecretKey"]))
                     };
                 });

            // Configurar o Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Nomeaplicacao", Version = "v1" });

                // Configurar a autenticação JWT no Swagger
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };

                options.AddSecurityDefinition("Bearer", securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                   {
                     new OpenApiSecurityScheme
                     {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
                });
            });

        }

    }

}