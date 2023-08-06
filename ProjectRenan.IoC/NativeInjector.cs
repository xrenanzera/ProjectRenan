using Microsoft.Extensions.DependencyInjection;
using ProjectRenan.Application.Interfaces;
using ProjectRenan.Application.Services;

namespace ProjectRenan.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Dependency Injection
            services.AddScoped<IUserService, UserService>();
        }
    }
}