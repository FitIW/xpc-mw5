using DemoEF;
using Microsoft.EntityFrameworkCore;

IHost host = 
    Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((context,services) =>
    {
        services.AddHostedService<Worker>();
        services.AddDbContext<MyDBContext>(options=>
        {
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection"));
        }, ServiceLifetime.Singleton);
    })
    .Build();

host.Run();


