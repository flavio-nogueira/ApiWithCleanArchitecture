using ApiWithCleanArchitecture.Infra.Ioc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

IConfigurationRoot configuration = Configuration();

GetSerialogConfiguration(builder, configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureSwagger();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddJwtTConfiguration(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
 
}

app.UseSwagger();
app.UseSwaggerUI();
//app.UseExceptionHandler("/error"); // =>Tratamento para mostrar mensagem tecnica do erro na tela , no caso devera ser analisar log.txt porem se quiser abilitar  erro detalhado e so trocar posicao antes if (app.Environment.IsDevelopment())

app.UseHttpsRedirection();
app.MapControllers();

GravaLogStartWebApi(app);

static IConfigurationRoot Configuration()
{
    string ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
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

//  static void UseSwaggerConfiguration(this IApplicationBuilder app)
//{
//    app.UseSwagger();

//    app.UseSwaggerUI(c =>
//    {
//        c.RoutePrefix = string.Empty;
//        c.SwaggerEndpoint("./swagger/v1/swagger.json", "CL V1");
//    });
//}