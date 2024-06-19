using _5._3_FM.lojavirtual.Infra.WebApi;
using _5._3_FM.lojavirtual.Infra.WebApi.Classes;
using _5._3_FM.lojavirtual.Infra.WebApi.Interfaces;
using _5._3_FM.lojavirtual.Infra.WebApi.Servicos;
using FM.lojavirtual.Presentation.Helpers;
using FM.lojavirtual.Presentation.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FM.lojavirtual.Presentation.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IHttpGenericCall, HttpGenericCall>();
            services.AddScoped<IBaseHttpClient, BaseHttpClient>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddScoped<LojaServicoWebApi>();
            services.AddScoped<ITiposVeiculoWebApi, TiposVeiculoWebApi>();

            services.AddScoped<IVeiculoWebApi, VeiculoWebApi>();
            services.AddScoped<ILoginWebApi, LoginWebApi>();
            services.AddScoped<IUser, User>();






            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   options =>
                   {
                       options.Events = new CookieAuthenticationEvents()
                       {
                           OnRedirectToLogin = (context) =>
                           {
                               context.HttpContext.Response.Redirect("/login?isAccessDenied=true");
                               return Task.CompletedTask;
                           }
                       };
                   }
               );

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "FM.JP.core.cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
                options.LoginPath = "Login/Index";
                options.AccessDeniedPath = "~/AccessDenied.cshtml";
            });

            return services;
        }
    }
}
