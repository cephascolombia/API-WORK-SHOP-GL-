using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using WorkShopGL.API;
using WorkShopGL.API.Middlewares;
using WorkShopGL.Application.Services.Auth;
using WorkShopGL.Application.Services.Clase;
using WorkShopGL.Application.Services.Cliente;
using WorkShopGL.Application.Services.Color;
using WorkShopGL.Application.Services.Maestro;
using WorkShopGL.Application.Services.Marca;
using WorkShopGL.Application.Services.Sistema;
using WorkShopGL.Application.Services.Tecnico;
using WorkShopGL.Application.Services.Vehiculo;
using WorkShopGL.Infrastructure.Auth;
using WorkShopGL.Infrastructure.Database;
using WorkShopGL.Infrastructure.Repositories.Clase;
using WorkShopGL.Infrastructure.Repositories.Cliente;
using WorkShopGL.Infrastructure.Repositories.Color;
using WorkShopGL.Infrastructure.Repositories.Maestro;
using WorkShopGL.Infrastructure.Repositories.Marca;
using WorkShopGL.Infrastructure.Repositories.Sistema;
using WorkShopGL.Infrastructure.Repositories.Tecnicos;
using WorkShopGL.Infrastructure.Repositories.Utilidades;
using WorkShopGL.Infrastructure.Repositories.Vehiculo;
using WorkShopGL.Shared.Context;
using WorkShopGL.Shared.Results;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.ToString());
    c.AddSecurityDefinition("Bearer", new()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    c.AddSecurityRequirement(new()
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

builder.Services.AddMemoryCache();

builder.Services.AddScoped<TenantContext>();
builder.Services.AddScoped<ITenantConnectionResolver, TenantConnectionResolver>();
builder.Services.AddScoped<SqlConnectionFactory>();
builder.Services.AddScoped<SqlConnectionNoTenantFactory>();
builder.Services.AddScoped<SqlExecutor>();
builder.Services.AddScoped<SqlExecutorNoTenant>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddSingleton<CryptoInt>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IUtilidadesRepository, UtilidadesRepository>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IMaestroRepository, MaestroRepository>();

builder.Services.AddScoped<IClienteService,ClienteService>();
builder.Services.AddScoped<IVehiculoService,VehiculoService>();
builder.Services.AddScoped<IMaestroService, MaestroService>();

builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IColorService, ColorService>();

builder.Services.AddScoped<IClaseRepository, ClaseRepository>();
builder.Services.AddScoped<IClaseService, ClaseService>();

builder.Services.AddScoped<IMarcaRespository, MarcaRespository>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

builder.Services.AddScoped<ITecnicoRepository, TecnicoRepository>();
builder.Services.AddScoped<ITecnicoService, TecnicoService>();

builder.Services.AddScoped<ISistemaRepository, SistemaRepository>();
builder.Services.AddScoped<ISistemaService, SistemaService>();


builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MasterDb")));

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = ctx =>
    {
        ctx.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = ctx =>
    {
        ctx.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "WorkShopGL",
        ValidAudience = "WorkShopGL",
        IssuerSigningKey = new SymmetricSecurityKey
        (
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
        ),
        NameClaimType = ClaimTypes.Name
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenCors", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseRouting();

app.UseCors("OpenCors");

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<TenantMiddleware>();

app.MapControllers();

app.Run();
