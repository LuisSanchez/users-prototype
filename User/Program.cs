using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using User.Application.Interfaces;
using User.Application.Services;
using User.Infrastructure.Repositories;
using User.Infrastructure.Services;
using User.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5138", "https://0.0.0.0:7138");

// Load .env file
Env.Load();

// Add JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET") ?? 
            throw new InvalidOperationException("JWT_SECRET environment variable is not set"));
        
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
        };
    });

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

// Configuration
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("Email"));

// Add services to the container.
builder.Services.AddControllers();


var app = builder.Build();

// Middleware pipeline
// HTTPS redirection disabled for development
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Health checks
app.MapGet("/", () => "User Service is running");
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.Run();
