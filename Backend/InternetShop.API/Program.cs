using InternetShop.Application.Interfaces;
using InternetShop.Application.Servicies;
using InternetShop.Application.Settings;

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

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});

var app = builder.Build();


app.UseCors("AllowAll");
app.MapControllers();

app.Run();