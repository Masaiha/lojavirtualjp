using FM.lojavirtual.Application.AutoMapper;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using FM.lojavirtual.WebApi.Configurations;

namespace FM.lojavirtual.WebApi
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddJwtConfiguration(builder.Configuration);
            builder.Services.AddSwaggerConfig();

            builder.Services.Configure<AppSettingsApi>(builder.Configuration);
            builder.Services.AddScoped<AppSettingsApi>();

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddAutoMapperConfigurations();

            // Add services to the container.
            builder.Services.AddDependencyInjections(builder.Configuration);

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}