using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupplySyncBackend.Config;
using SupplySyncBackend.Data;
using SupplySyncBackend.Helpers;
using SupplySyncBackend.Middleware;
using SupplySyncBackend.Repositories;
using SupplySyncBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Load Configuration
var configuration = builder.Configuration;

// Add services to the container
builder.Services.AddControllers();

// Database Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Configure Settings
builder.Services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
builder.Services.Configure<AISettings>(configuration.GetSection("AISettings"));
builder.Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

// Register Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IAIRepository, AIRepository>();

// Register Services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAIService, AIService>();

// Register Utilities
builder.Services.AddSingleton<JwtTokenHelper>();
builder.Services.AddSingleton<EmailSender>();
builder.Services.AddSingleton<NotificationHelper>();
builder.Services.AddSingleton<RoleChecker>();
builder.Services.AddSingleton<CsvExporter>();

// Configure Middleware
builder.Services.AddTransient<ErrorHandlerMiddleware>();
builder.Services.AddTransient<AuthenticationMiddleware>();
builder.Services.AddTransient<AuthorizationMiddleware>();
builder.Services.AddTransient<LoggingMiddleware>();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "SupplySync API",
        Description = "API documentation for SupplySync backend services",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Support",
            Email = "support@supplysync.com",
            Url = new Uri("https://www.supplysync.com")
        }
    });

    // Add authorization header to Swagger UI
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer' followed by a space and your JWT token"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Build the app
var app = builder.Build();

// Apply Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<AuthorizationMiddleware>();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SupplySync API V1");
        options.RoutePrefix = ""; // Access Swagger at the root URL
    });
}

// Enable CORS
app.UseCors("AllowAll");

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Map Controllers
app.MapControllers();

// Seed initial data (if required)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
    dbInitializer.SeedData(dbContext);
}

// Run the app
app.Run();
