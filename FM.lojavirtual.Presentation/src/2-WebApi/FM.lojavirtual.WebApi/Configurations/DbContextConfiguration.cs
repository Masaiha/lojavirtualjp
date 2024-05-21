using _5._2_FM.lojavirtual.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FM.lojavirtual.WebApi.Configurations
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddDbConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FMLojaVirtualDbContext>(options =>
            {
                var cs = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(cs);
                    
        });

            return services;
        }
    }
}
