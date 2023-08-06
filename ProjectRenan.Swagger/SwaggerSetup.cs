using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ProjectRenan.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Project Renan .Net Core",
                    Version = "v1",
                    Description = "Sistema de Cadastro de Usuario usando .NET 6 e Angular.",
                    Contact = new OpenApiContact
                    {
                        Name = "Renan Miranda Nogueira",
                        Email = "renan.nogueira@outlook.com"
                    }
                });

                string xmlPath = Path.Combine("wwwroot", "api-doc.xml");
                options.IncludeXmlComments(xmlPath);
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(c =>
            {
                c.RoutePrefix = "documentation";
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
            });
        }
    }
}