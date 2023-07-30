using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace ApiWithCleanArchitecture.Infra.Ioc
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Api Template With CleanArchitecture",
                        Version = "v1",
                        Description = "Api  base de Api de Financeiro",
                        Contact = new OpenApiContact
                        {
                            Name = "Flavio Nogueira",
                            Email = "flavio.nogueira.alfa@outlook.com.br",
                            Url = new Uri("https://www.uol.com.br")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "OSD",
                            Url = new Uri("https://www.google.com.br")
                        },
                        TermsOfService = new Uri("https://www.msn.com")
                    });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Acesso protegido utilizando o accessToken obtido em \"api/Authenticate/login\""
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference= new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                        }
                    },
                        Array.Empty<string>()
                    }
                });

                c.AddFluentValidationRulesScoped();

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                xmlPath = Path.Combine(AppContext.BaseDirectory, "ApiWithCleanArchitecture.Application.xml");
                c.IncludeXmlComments(xmlPath);
      
            });

            return services;
        }

    }
}

