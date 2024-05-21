using _5._2_FM.lojavirtual.Infra.Data.Repository;
using FM.lojavirtual.Domain.Interfaces.Repository;

namespace FM.lojavirtual.WebApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<ILojaRepository, LojaRepository>();

            return services;
        }
    }
}
