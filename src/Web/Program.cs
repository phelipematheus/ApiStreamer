using System.Globalization;
using System.Net;
using System.Text;
using Infrastructure.Config;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

builder.Services.Configure<OAuthConfig>(builder.Configuration.GetSection("OAuth"));

builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
    serverOptions.Limits.MaxRequestBodySize = 100_000_000;
    serverOptions.Listen(IPAddress.Any, 8080, listenOptions => listenOptions.UseConnectionLogging());
    serverOptions.Listen(IPAddress.Any, 8081, listenOptions => listenOptions.UseConnectionLogging());
});

builder.Logging.ClearProviders();

// DbContext configuration
builder.Services.AddDbContext<StreamerDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
#if DEBUG
    options.EnableSensitiveDataLogging(true);
    options.EnableDetailedErrors(true);
#endif
});

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebServices();

//Definindo a serialização como camelCase

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configurar Swagger para aceitar tokens JWT
// Configurar Swagger para usar OAuth2
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Streamer API", Version = "v1" });
    c.EnableAnnotations();

    // Adiciona a definição do esquema de segurança (JWT Bearer)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Utilize a rota de Login e Insira o token JWT gerado: Bearer {seu_token}"
    });

    // Adiciona o requisito de segurança para os endpoints
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddResponseCaching();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var key = builder.Configuration["Jwt:Secret"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key!))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();

app.UseMiddleware<ErrorHandling>();
app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
    protected Program()
    {
    }
}
