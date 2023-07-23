using ApiWithCleanArchitecture.Infra.Ioc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

// Add logging to the console
builder.Logging.AddConsole();

// Add Serilog request logging

// Add Serilog request logging
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .Enrich.FromLogContext()
        .WriteTo.Async(a => a.Console())
        .WriteTo.Async(a => a.File("log.txt", fileSizeLimitBytes: 100000, rollingInterval: RollingInterval.Day, rollOnFileSizeLimit: true))
        .WriteTo.Console(); // You can chain other sinks if needed
});

// Add services and configure the application
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Enable developer exception page for better error handling during development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    Log.Information("Iniciando Api");
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
