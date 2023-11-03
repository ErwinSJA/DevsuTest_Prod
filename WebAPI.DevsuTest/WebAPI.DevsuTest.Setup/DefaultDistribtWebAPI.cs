using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebAPI.DevsuTest.Middlewares.Exceptions;
using WebAPI.DevsuTest.Middlewares.TimeOut;
using WebAPI.DevsuTest.Services.Class;
using WebAPI.DevsuTest.Util.Class;

namespace WebAPI.DevsuTest.Setup
{
    public static class DefaultDistribtWebAPI
    {
        public static WebApplication Create(string[] args, Action<WebApplicationBuilder>? webappBuilder = null)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "PoliticaCORS", policy =>
            //    //options.AddDefaultPolicy(policy =>
            //    {
            //        policy.WithOrigins("http://localhost:7113") // PONER LA DIRECCION DE PUBLICACION
            //            .AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .AllowCredentials();
            //    });
            //});
            
            builder.Host.ConfigureServices((hostingContext, services) => {
                services.AddMemoryCache(); // Agrega la configuración para utilizar IMemoryCache                
            });
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddAuthorization();

            builder.Services.AddControllers().AddNewtonsoftJson();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
                options.SchemaFilter<SwaggerSchemaExampleFilter>();
                
                options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Servicios para Test Devsu",
                    Version = "v1",
                    Description = "Esta es la Documentación de los Servicios Web API.",
                    Contact = new OpenApiContact
                    {
                        Name = "Joao Sanchez Aranda",
                        Email = "sanchezaej@gmail.com"
                    },
                    
                });
            });

            builder.Services.AddAutoMapper(typeof(clsAutoMapperProfile));

            if (webappBuilder != null)
            {
                webappBuilder.Invoke(builder);
            }

            return builder.Build();
        }

        public static void Run(WebApplication webApp)
        {
            //webApp.UseCors("PoliticaCORS");

            if (webApp.Environment.IsDevelopment())
            {
                webApp.UseSwagger();
                webApp.UseSwaggerUI();
            }

            webApp.UseSwagger();
            webApp.UseSwaggerUI(options => {
                options.SwaggerEndpoint("swagger/v1/swagger.json", webApp.Configuration["WebApi:ApiNombre"]);
                options.RoutePrefix = string.Empty;
            });

            webApp.UseReDoc(options =>
            {
                options.DocumentTitle = "Documentación Web API - Joao Sanchez";
                if (webApp.Environment.IsDevelopment())
                {
                    options.SpecUrl = "/swagger/v1/swagger.json";
                }
                else
                {
                    options.SpecUrl = webApp.Configuration["WebApi:ApiRutaMatriz"]! + "/swagger/v1/swagger.json";
                }
                options.ExpandResponses("200,201");
            });

            webApp.UseMiddleware<ExceptionMiddleware>();

            webApp.UseHttpsRedirection();

            webApp.UseRouting();

            webApp.UseAuthentication();

            webApp.UseAuthorization();

            webApp.UseTimeoutMiddleware(int.Parse(webApp.Configuration["WebApi:TimeOut"]!));

            webApp.MapControllers();

            webApp.Run();
        }
    }
}
