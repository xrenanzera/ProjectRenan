using Microsoft.EntityFrameworkCore;
using ProjectRenan.Application.AutoMapper;
using ProjectRenan.Data.Context;
using ProjectRenan.IoC;
using ProjectRenan.Swagger;

namespace ProjectRenan
{
    public class Startup : IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ProjectRenanContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ProjectRenanDB")).EnableSensitiveDataLogging());
            NativeInjector.RegisterServices(services);

            services.AddAutoMapper(typeof(AutoMapperSetup));
            services.AddSwaggerConfiguration();

        }

        public void Configure(WebApplication app, IWebHostEnvironment enviroment)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization(); 


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment enviroment);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration) as IStartup ?? throw new ArgumentException("Classe Startup.cs Inválida");
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return builder;

        }
    }
}
