using _5._3_FM.lojavirtual.Infra.WebApi;
using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using _5._3_FM.lojavirtual.Infra.WebApi.Servicos;
using FM.lojavirtual.Domain.Entidades.AppSettings;

namespace FM.lojavirtual.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<AppSettingsUi>(builder.Configuration);
            builder.Services.AddScoped<AppSettingsUi>();

            builder.Services.AddScoped<IHttpGenericCall, HttpGenericCall>();
            builder.Services.AddScoped<IBaseHttpClient, BaseHttpClient>();

            builder.Services.AddScoped<LojaServicoWebApi>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}