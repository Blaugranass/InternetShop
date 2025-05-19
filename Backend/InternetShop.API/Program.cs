using InternetShop.Application.Interfaces;
using InternetShop.Application.Services;
using InternetShop.Application.Settings;
using InternetShop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using InternetShop.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.Configure<AuthSettings>
    (builder.Configuration.GetSection("AuthSettings"));

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});

var app = builder.Build();

app.UseExceptionHandling();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();