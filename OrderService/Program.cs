using OrderService.Infrastructure.Messaging;
using Shared.Messaging;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = ConfigurationOptions.Parse("redis:6379");
config.AbortOnConnectFail = false;

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(config));

builder.Services.AddControllers();
builder.Services.AddSingleton<IEventPublisher, RedisPublisher>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
