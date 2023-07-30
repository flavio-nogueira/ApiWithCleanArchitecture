using ApiWithCleanArchitecture.Application.Interfaces;
using ApiWithCleanArchitecture.Application.Mappings;
using ApiWithCleanArchitecture.Application.Services;
using ApiWithCleanArchitecture.Application.Validation;
using ApiWithCleanArchitecture.Domain.Interfaces;
using ApiWithCleanArchitecture.Infra.Data.Context;
using ApiWithCleanArchitecture.Infra.Data.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace ApiWithCleanArchitecture.Infra.Ioc
{
    public static class DependecyInjection
    {
   
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("MySqlEntityFrameWork"),
                    new MySqlServerVersion(new Version(8, 0, 26)), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            //AutoMapper

            services.AddAutoMapper(typeof(UsuarioMappingProfile));

            //Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Services

            services.AddScoped<IUsuarioService, UsuarioService>();
     
            services.AddControllers();

            services.AddControllers()
                .AddFluentValidation(p =>
                {
                   p.RegisterValidatorsFromAssemblyContaining<NovoUsuarioValidator>();
                   p.RegisterValidatorsFromAssemblyContaining<AlteraUsuarioValidator>(); 
                   p.RegisterValidatorsFromAssemblyContaining<LoginUsuarioValidation>(); 
                   p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                   
                });

            return services;
        }
    }
}