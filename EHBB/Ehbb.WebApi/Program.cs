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
using Ehbb.Data.Repositories;
using Ehbb.Domain.Services;
using Ehbb.Data.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEhbbDbContexts(builder.Configuration);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddEhbbServices();

builder.Services.AddEhbbRepository();


builder.Services.AddHttpContextAccessor();
builder.Services
    .AddControllers()
    .AddFluentValidation(options =>
    {
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;

    });

builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));

builder.Services.AddEhbbValidator();

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
