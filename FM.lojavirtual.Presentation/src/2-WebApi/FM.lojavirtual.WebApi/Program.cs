
using _5._2_FM.lojavirtual.Infra.Data.Repository;
using FM.lojavirtual.Application.AutoMapper;
using FM.lojavirtual.Application.Interfaces;
using FM.lojavirtual.Application.Servicos;
using FM.lojavirtual.Domain.Interfaces.Domain;
using FM.lojavirtual.Domain.Interfaces.Repository;
using FM.lojavirtual.Domain.Servicos;
using FM.lojavirtual.WebApi.Configurations;

namespace FM.lojavirtual.WebApi
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddAutoMapperConfigurations();

            // Add services to the container.
            builder.Services.AddDependencyInjections(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            
            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
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