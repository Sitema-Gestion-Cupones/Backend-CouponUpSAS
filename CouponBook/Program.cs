using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using CouponBook.Models;
using CouponBook.Services;
using System.Text;
using MimeKit.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CouponBook.Utils;
using CouponBook.Data;
using CouponBook.Repository.CouponPermissions;
using CouponBook.Repository.Coupons;
using CouponBook.Repository.CustomerUsers;
using CouponBook.Repository.Invoices;
using CouponBook.Repository.MarketingUsers;
using CouponBook.Repository.Purchases;
using CouponBook.Repository.Redemptions;
using CouponBook.Repository.UpdateLogs;
using CouponBook.Services.CouponPermissions;
using CouponBook.Services.Coupons;
using CouponBook.Services.CustomerUsers;
using CouponBook.Services.Invoices;
using CouponBook.Services.MarketingUsers;
using CouponBook.Services.Purchases;
using CouponBook.Services.Redemptions;
using CouponBook.Services.UpdateLogs;
using CouponBook.Services.Emails;
using CouponBook.Custom;
using FluentValidation.AspNetCore;
using FluentValidation;
using CouponBook.Validators;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agreagndo servicios para contraseña
builder.Services.AddSingleton<Utilities>();

// Configuración JWT
builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        };
    }

    )
;

//Agregando servicios para el controller y el json
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

//Agregando servicios para mapear dto
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(CustomUserProfile));

builder.Services.AddDbContext<CouponBaseContext>(options => 
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")
    )
);


// Agregando Servicios para envio de Correo
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));


// Agregando Transient
builder.Services.AddTransient<IEmailService, EmailService>();
//Por cada envio de correo se debe agregar la interfases y el repositorio
//builder.Services.AddTransient<ICitaRepository, CitaRepository>();


// Servicios para validar
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CustomerUserSignupValidator>();


// Agregando Scoped Repository
builder.Services.AddScoped<ICouponPermissionRepository, CouponPermissionRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddScoped<ICustomerUserRepository, CustomerUserRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IMarketingUserRepository, MarketingUserRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IRedemptionRepository, RedemptionRepository>();
builder.Services.AddScoped<IUpdateLogRepository, UpdateLogRepository>();


// Agregando Scoped Services
builder.Services.AddScoped<ICouponPermissionService, CouponPermissionService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<ICustomerUserService, CustomerUserService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IMarketingUserService, MarketingUserService>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IRedemptionService , RedemptionService >();
builder.Services.AddScoped<IUpdateLogService, UpdateLogService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


// Usando autenticaciones
app.UseAuthentication();
app.UseAuthorization();

//Agregando para poder mapear los controleadores
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
