using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WalletService.Business.Mapper;
using WalletService.Business.Services.Commands.Implements;
using WalletService.Business.Services.Commands.Interfaces;
using WalletService.Business.Services.Querys.Implements;
using WalletService.Business.Services.Querys.Interfaces;
using WalletService.Persistence.Context;
using WalletService.Persistence.Managers;
using WalletService.Persistence.Repositories.Implements;
using WalletService.Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// managers
builder.Services.AddSingleton<IConnectionManager, ConnectionManager>();

// contexts
builder.Services.AddScoped<MongoDbContext>();

// repositories
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<IWalletLogRepository, WalletLogRepository>();
builder.Services.AddScoped<IWalletTransactionRepository, WalletTransactionRepository>();

// services
builder.Services.AddScoped<IVisitorServiceCommand, VisitorServiceCommand>();
builder.Services.AddScoped<IWalletServiceCommand, WalletServiceCommand>();
builder.Services.AddScoped<IWalletTransactionServiceCommand, WalletTransactionServiceCommand>();
builder.Services.AddScoped<IWalletServiceQuery, WalletServiceQuery>();

builder.Services.AddScoped<ICustomMapper, CustomMapper>();

builder.Services.AddControllers();

builder.Services.AddCors(
    opts => opts.AddPolicy(
        "All",
        builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*")
        )
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
