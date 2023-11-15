using Api;
using Api.Middleware;
using Application;
using Application.Users.Validations;
using Domain;
using FluentValidation;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
builder.Services.AddDbContext<XyzHotelContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("HotelDB");
    opts.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString),

        options => options.MigrationsAssembly("Infrastructure"));
}).AddTransient<IUserRepository, UserRepository>();


builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapEndpoint();

app.Run();
