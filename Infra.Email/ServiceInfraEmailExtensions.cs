using Microsoft.Extensions.DependencyInjection;
using Domain.Ports;
using Infra.Email.Operations;

namespace Infra.Email
{
    public static class ServiceInfraEmailExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, FakeEmailAdapter>();

            return services;
        }
    }
}
