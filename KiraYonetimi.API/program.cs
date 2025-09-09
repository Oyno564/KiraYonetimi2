using FluentAssertions.Common;
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

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<KiraContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("KiraYonetimi.DataAcsses") // 👈 migrations will be stored here
    ));

  // .Services.AddScoped<DatabaseUnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(GetAllApartQueryHandler).Assembly);
});

var app = builder.Build();


// ✅ Seed initial data at startup
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<KiraContext>();

    // Run migrations automatically (optional)
    context.Database.Migrate();

    // Seed a default user if none exist
    if (!context.Users.Any())
    {
        //  context.Users.Add(new User { FullName = "Deniz" });
      //   context.Users.Add(new User { UserId = 1 });
        context.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
