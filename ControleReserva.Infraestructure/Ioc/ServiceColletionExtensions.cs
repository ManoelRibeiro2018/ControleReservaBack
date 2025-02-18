using Microsoft.Extensions.DependencyInjection;

namespace ControleReserva.Infraestructure.Ioc
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {

            return services;
        }
    }
}
