using ApiWithCleanArchitecture.Infra.Ioc;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add logging to the console
builder.Logging.AddConsole();

// Add Serilog request logging
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.File("log.txt",fileSizeLimitBytes :100000, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null);
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
