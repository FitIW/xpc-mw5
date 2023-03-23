using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TestService>();

var abcdString = builder.Configuration.GetConnectionString("Abcd");

// view all configurations 
var config = builder.Configuration.GetDebugView();

builder.Services.Configure<MyAppConfiguration>(builder.Configuration.GetSection("MyAppConfiguration"));

builder.Services.AddHostedService<MyBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MyAwesomeMiddleware>();
app.MapControllers();

app.Run();
