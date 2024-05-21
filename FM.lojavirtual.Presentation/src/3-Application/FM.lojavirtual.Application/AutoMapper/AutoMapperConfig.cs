using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FM.lojavirtual.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfigurations(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ViewModelToDomainMappingProfile());
                mc.AddProfile(new DomainToViewModelMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
