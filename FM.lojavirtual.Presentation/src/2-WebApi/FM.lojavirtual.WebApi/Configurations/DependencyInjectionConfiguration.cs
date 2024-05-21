using _5._2_FM.lojavirtual.Infra.Data.Repository;
using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.Servicos;
using FM.lojavirtual.Domain.Interfaces.Domain;
using FM.lojavirtual.Domain.Interfaces.Repository;
using FM.lojavirtual.Domain.Servicos;

namespace FM.lojavirtual.WebApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddDbConnectionString(configuration);
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            return services;
        }
    }
}
