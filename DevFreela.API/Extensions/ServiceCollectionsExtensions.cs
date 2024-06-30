using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Payments;
using DevFreela.Infrastructure.Persistence.Repositories;
using DevFreela.Infrastructure.MessageBus;

namespace DevFreela.API.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Registering repositories for dependency injection
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Registering services for authentication
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();

            return services;
        }
    }
}
