using ClassLibrary1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyWebApi.MIddleware;

namespace MyWebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "MyWebApi", Version = "v1"}); });

            services.AddTransient<IMyService, MyBetterService>();
            services.AddSingleton<IDatabase, FakeDB>();

            services.Scan(selector => 
                selector.FromCallingAssembly()
                    .AddClasses(classes=> classes.AssignableTo<IScrutorSampleService>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
            );

            services.Scan(selector =>
                selector.FromCallingAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(IScrutorGenericSampleService<>)))
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
            );
            services.Configure<MySuperSection>(Configuration.GetSection(nameof(MySuperSection)));


            //services.AddSingleton<CountService>();
            //services.AddScoped<CountService>();
            services.AddTransient<CountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<MyLoggingMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyWebApi v1"));
            }

           
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }

    public class MySuperSection
    {
        public string MyHeader { get; set; }
    }
}