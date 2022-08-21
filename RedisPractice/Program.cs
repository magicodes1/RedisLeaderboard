using RedisPractice.Data;
using RedisPractice.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IRedisDb, RedisDb>();
builder.Services.AddScoped<IRankService, RankService>();

var app = builder.Build();

app.MapControllers();

app.Run();
