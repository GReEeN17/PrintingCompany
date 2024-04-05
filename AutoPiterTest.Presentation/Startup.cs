using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using AutoPiterTest.Infrastructure.Implementations.Abstractions;
using AutoPiterTest.Infrastructure.Implementations.DataContext;
using AutoPiterTest.Presentation.ProjectMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AutoPiterTest.Presentation;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Conventions.Add(new RouteTokenTransformerConvention(
                new SlugifyParameterTransformer()));
            options.Filters.Add(new ErrorFilter());
        });

        services.AddHttpContextAccessor();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebLottery API", Version = "v1" });
        });

        services.AddDbContext<DataContext>(options =>
        {
            options
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    assembly =>
                        assembly.MigrationsAssembly("AutoPiterTest.Infrastructure.Migrations"));
            options.UseTriggers(triggerOptions =>
            {
                triggerOptions.AddTrigger<EntityTrigger>();
            });
        });

        services.AddAutoMapper(typeof(AppMappingProfile));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        app.UseRouting();

        app.UseSwagger();
        app.UseSwaggerUI(x =>
        {
            x.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoPiterTest API v1");
            x.RoutePrefix = "swagger";
        });
        
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    private class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value) =>
            value is null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }

    private class ErrorFilter : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            var response = $"{{\"error\": \"{exception.Message}{exception.InnerException?.Message}\"}}";
            await using var responseWriter = new StreamWriter(context.HttpContext.Response.Body, Encoding.UTF8);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.ContentType = "application/json; charset=utf-8";
            context.HttpContext.Response.ContentLength = Encoding.UTF8.GetBytes(response).Length + 3;
            await responseWriter.WriteAsync(response);
        }
    }
}