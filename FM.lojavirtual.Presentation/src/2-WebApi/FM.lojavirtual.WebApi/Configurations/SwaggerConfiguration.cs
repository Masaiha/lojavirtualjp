using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FM.lojavirtual.WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api Loja virtual FM-JP",
                    Description = "API FM Loja virtual",
                    Contact = new OpenApiContact
                    {
                        Name = "FM-JP LTDA",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Copyright",
                    },
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "jwt Bearer",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(options => {
                options.IncludeXmlComments(XmlCommentsFilePath);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FMCore API v1");
                c.RoutePrefix = string.Empty;
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });
            return app;
        }

        static string XmlCommentsFilePath
        {
            get
            {
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var fileName = typeof(Program).GetTypeInfo().Assembly.GetName().Name + ".xml";
                var fullFilePath = Path.Combine(basePath, fileName);

                return fullFilePath;
            }
        }
    }
}
