using FluentAssertions.Common;
using KiraYonetimi.API.SignalR.Hubs;
using KiraYonetimi.Common.Queries.QueryHandlers;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.DataAcsses.Repositories;
using KiraYonetimi.Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);



// ----------------- Services -----------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(" http://localhost:5173/NewHub") // frontend adresiniz
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // ✅ signalR için gerekli
    });
});

// DbContext ve diğer servisler
builder.Services.AddDbContext<KiraContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("KiraYonetimi.DataAcsses")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(configuration => {
    configuration.RegisterServicesFromAssembly(typeof(GetAllApartQueryHandler).Assembly);
});

var app = builder.Build();

// ----------------- Middleware -----------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // ✅ UseRouting öncesinde CORS olamaz

app.UseCors();    // ✅ UseCors mutlaka UseRouting'den sonra, UseAuthorization'dan önce
app.UseAuthorization();

// ----------------- Endpoints -----------------
app.MapControllers();
app.MapHub<NewHub>("/NewHub"); // ✅ SignalR hub mapping

app.Run();
