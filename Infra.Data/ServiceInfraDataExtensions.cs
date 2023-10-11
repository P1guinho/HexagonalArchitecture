using Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Domain.Ports;

namespace Infra.Data
{
    public static class ServiceInfraDataExtensions
    {
        public static IServiceCollection AddDataBaseInMemoryService(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("test"));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
