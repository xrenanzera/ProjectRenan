using Microsoft.Extensions.DependencyInjection;
using ProjectRenan.Application.Interfaces;
using ProjectRenan.Application.Services;
using ProjectRenan.Data.Repositories;
using ProjectRenan.Domain.Interfaces;

namespace ProjectRenan.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Dependency Injection

            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
        }
    }
}