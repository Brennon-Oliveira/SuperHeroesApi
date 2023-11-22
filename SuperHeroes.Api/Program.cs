
using Microsoft.EntityFrameworkCore;
using SuperHeroes.Infra.Data.Contexts;
using SuperHeroes.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using System;
using Swashbuckle.AspNetCore.SwaggerUI;
using Serilog;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=app.db"));

builder.Services.AddControllers();

builder.Services.RegisterServices();

#region Logger configuration

builder.Host.ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders());
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
    loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext().CreateLogger();

#endregion

#region Builder Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Super Heroes.Api", Version = "v1" });
    c.EnableAnnotations();
});


#endregion

var app = builder.Build();

app.MapControllers();

    app.Use(async (context, next) =>
    {
        try
        {
            await next.Invoke();
        }
        catch (Exception ex)
        {
            Log.Logger.Error(ex, "Ocorreu um erro durante a execução {Context}", context.Request.Path.Value);
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            var resultError = new
            {
                title = "Ocorreu um erro interno",
                status = 500
            };
            await response.WriteAsync(JsonConvert.SerializeObject(resultError));
        }

    });


app.UseSwagger();
app.UseSwaggerUI(swagger =>
{
    swagger.DocExpansion(DocExpansion.None);
});

app.Run();
