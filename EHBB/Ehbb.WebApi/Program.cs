using Ehbb.Data.Repositories.Repositories;
using Ehbb.Data.Repositories.Repository_Interfaces;
using Ehbb.Domain.Services.Service_Interfaces;
using Ehbb.Domain.Services.Services;
using Ehbb.Data.DataAccess;
using Microsoft.EntityFrameworkCore;
using Ehbb.Domain.Dtos.Profiles;
using FluentValidation.AspNetCore;
using Ehbb.Data.DataAccess.Validators;
using FluentValidation;
using Ehbb.Data.Entities.Entities;
using Ehbb.Domain.Dtos.DTOs;
using Microsoft.Extensions.Logging;
using Ehbb.Data.Validation.Validators;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEhbbDbContexts(builder.Configuration);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddScoped<IEmitterService, EmitterService>();
builder.Services.AddScoped<ILaserService, LaserService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPlatformService, PlatformService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ILaserRepo, LaserRepo>();
builder.Services.AddScoped<IEmittersRepo, EmitterRepo>();
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();


//builder.Services.AddAutoMapper(typeof(UserRoleProfile), typeof(LaserProfile), typeof(EmitterProfile));
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddControllers()
    .AddFluentValidation(options =>
    {
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

        //options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
    });

builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));

builder.Services.AddTransient<IValidator<UserDTO>, UserValidator>();
builder.Services.AddTransient<IValidator<LaserModeDTO>, LaserModeValidator>();
builder.Services.AddTransient<IValidator<EmitterModeDTO>, EmitterModeValidator>();
builder.Services.AddTransient<IValidator<EmitterDTO>, EmitterValidator>();
builder.Services.AddTransient<IValidator<LaserDTO>, LaserValidator>();
builder.Services.AddTransient<IValidator<RoleDTO>, RoleValidator>();
builder.Services.AddTransient<IValidator<PlatformDTO>, PlatformValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
