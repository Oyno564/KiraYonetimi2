
using KiraYonetimi.API.SignalR.Hubs;
using KiraYonetimi.Common.Commands.CommandHandlers;
using KiraYonetimi.Common.Commands.CommandRequest;
using KiraYonetimi.Common.Queries.QueryHandlers;
using KiraYonetimi.DataAcsses.Context;
using KiraYonetimi.DataAcsses.Interfaces;
using KiraYonetimi.DataAcsses.Repositories;
using KiraYonetimi.DataAcsses.UnitOfWorks;
using KiraYonetimi.Entities.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("vite",
       p => p.WithOrigins("http://localhost:5173")
             .AllowAnyHeader()
             .AllowAnyMethod()
             .AllowCredentials());
});


// ----------------- Services -----------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
builder.Services.AddScoped<IApartUserRepository, ApartUserRepository>();


// DbContext
builder.Services.AddDbContext<KiraContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("KiraYonetimi.DataAcsses")));

// IRepository<> → EntityFrameworkRepository<> (tek ve dışarıda)
builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>));
builder.Services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();
// (Varsa) Unit of Work
// builder.Services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();

// MediatR (repo kaydı buraya konmaz)
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
});

// SignalR sadece bir kez ve options’lı
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
    options.KeepAliveInterval = TimeSpan.FromSeconds(15);
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
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

app.UseCors("vite");    // ✅ UseCors mutlaka UseRouting'den sonra, UseAuthorization'dan önce
app.UseAuthorization();

// ----------------- Endpoints -----------------
app.MapControllers();
app.MapHub<NewHub>("/NewHub"); // ✅ SignalR hub mapping

app.Run();
