using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FM.lojavirtual.Domain.Entidades.AppSettings;
using FM.lojavirtual.Presentation.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace FM.lojavirtual.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
            builder.Services.Configure<AppSettingsUi>(builder.Configuration);
            builder.Services.AddScoped<AppSettingsUi>();

            builder.Services.AddDependencyInjection();

            var app = builder.Build();
            app.UseNotyf();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            var culturas = new List<CultureInfo>
            {
                new CultureInfo("pt-BR"),
                new CultureInfo("es-AR"),
                new CultureInfo("es-ES"),
                new CultureInfo("es-MX"),
                new CultureInfo("de-DE"),
                new CultureInfo("en-US")
            };

            var opcoesCultura = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = culturas,
                SupportedUICultures = culturas
            };

            app.UseRequestLocalization(opcoesCultura);

            var cookieProvider = opcoesCultura.RequestCultureProviders.OfType<CookieRequestCultureProvider>().First();
            cookieProvider.CookieName = CookieRequestCultureProvider.DefaultCookieName;

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}