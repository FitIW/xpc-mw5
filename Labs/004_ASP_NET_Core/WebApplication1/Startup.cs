using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using WebApplication1.HttpClients;
using WebApplication1.Models;
using WebApplication1.Options;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyWebApi", Version = "v1" }); });

            services.AddControllers();
            services.Configure<OpenWeatherHttpClientOptions>(Configuration.GetSection(nameof(OpenWeatherHttpClientOptions)));
            services.Configure<OpenWeatherServiceOptions>(Configuration.GetSection(nameof(OpenWeatherServiceOptions)));

            services.AddHttpClient<IOpenWeatherHttpClient, OpenWeatherHttpClient>(httpClient =>
            {
                var httpClientBaseAddress = Configuration.GetSection($"{nameof(OpenWeatherHttpClientOptions)}:{nameof(OpenWeatherHttpClientOptions.BaseUrl)}").Value;

                var clientBaseAddress = new Uri(httpClientBaseAddress);
                httpClient.BaseAddress = clientBaseAddress;
            });
            services.AddHostedService<OpenWeatherService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApi v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
