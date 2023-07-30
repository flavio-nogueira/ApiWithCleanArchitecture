using ApiWithCleanArchitecture.Domain.Interfaces;
using ApiWithCleanArchitecture.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Infra.Ioc
{
    public static class DependecyInjectionJwtBearer
    {
        public static void AddJwtTConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IJwtRepository, JwtRepository>();

            var chave = Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Secret").Value);

            services.AddAuthentication(p =>
            {
                p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(p =>
            {
                p.RequireHttpsMetadata = false;
                p.SaveToken = true;
                p.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),                  
                    ValidIssuer = configuration.GetSection("JWT:Issuer").Value,                 
                    ValidAudience = configuration.GetSection("JWT:Audience").Value
                    
                };
            });
        }

        public static void UseJwtConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }  
}
