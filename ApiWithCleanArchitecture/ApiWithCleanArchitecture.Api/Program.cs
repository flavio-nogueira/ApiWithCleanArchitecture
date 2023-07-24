using ApiWithCleanArchitecture.Infra.Ioc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

IConfigurationRoot configuration = Configuration();

GetSerialogConfiguration(builder, configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

GravaLogStartWebApi(app);

static IConfigurationRoot Configuration()
{
    string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.{ambiente}.json")
    .Build();

    return configuration;
}

static void GetSerialogConfiguration(WebApplicationBuilder builder, IConfigurationRoot configuration)
{
    builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    {
        loggerConfiguration
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(configuration)
            .WriteTo.Console();
    });

}

static void GravaLogStartWebApi(WebApplication app)
{
    try
    {
        Log.Information("Iniciando WebApi");
        app.Run();
    }
    catch (Exception ex)
    {
        Log.Fatal(ex, "Erro bravo rs!!");
    }
    finally
    {
        Log.CloseAndFlush();
    }
}