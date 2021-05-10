using AutoMapper;
using CookBook.BL.Api.Installers;
using CookBook.DAL.Installers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag.AspNetCore;

namespace CookBook.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson()
                .AddFluentValidation(configuration =>
                    configuration.RegisterValidatorsFromAssemblyContaining<BLApiInstaller>());

            services.AddLocalization(options => options.ResourcesPath = string.Empty);

            services.AddOpenApiDocument();

            new DALInstaller().Install(services);
            new BLApiInstaller().Install(services);

            services.AddAutoMapper(typeof(DALInstaller), typeof(BLApiInstaller));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3(settings =>
                {
                    settings.SwaggerRoutes.Add(new SwaggerUi3Route("v1.0", "/swagger/v1/swagger.json"));
                });
            }
           
            // app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>endpoints.MapControllers());

         
        }
    }
}
