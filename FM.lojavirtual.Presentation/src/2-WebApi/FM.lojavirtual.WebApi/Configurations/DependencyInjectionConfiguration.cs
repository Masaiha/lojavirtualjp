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
            services.AddDbConnectionString(configuration);


            ///////////////////////////  AppService //////////////////////////////////
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IVeiculoAppService, VeiculoAppService>();
            services.AddScoped<ITiposVeiculoAppService, TiposVeiculoAppService>();


            /////////////////////////////  pService //////////////////////////////////
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<ITiposVeiculoService, TiposVeiculoService>();


            ///////////////////////////  Repository //////////////////////////////////
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<ITiposVeiculoRepository, TiposVeiculoRepository>();
            services.AddScoped<IVeiculoImagemRepository, VeiculoImagemRepository>();


            return services;
        }
    }
}
