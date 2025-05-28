//using PaymentService.Infrastructure.Messaging;
//using PaymentService.Services;
//using Shared.Messaging;
//using StackExchange.Redis;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//// Add Services
//var config = ConfigurationOptions.Parse("redis:6379");
//config.AbortOnConnectFail = false;

//builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(config));
//builder.Services.AddSingleton<IEventSubscriber, RedisSubscriber>();
//builder.Services.AddHostedService<OrderConsumer>();

//builder.WebHost.UseKestrel().UseUrls("http://0.0.0.0:80"); ;

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseDeveloperExceptionPage();
//app.MapGet("/api/test", () => "pong");
//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"request: {context.Request.Method} {context.Request.Path}");
//    await next();
//});

//app.MapControllers();

//app.Run();
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel()
    .UseUrls("http://0.0.0.0:80");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    Console.WriteLine($"request: {context.Request.Method} {context.Request.Path}");
    await next();
});

app.MapGet("/api/test", () => "pong");
app.MapControllers();
app.Run();
