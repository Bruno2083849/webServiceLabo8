using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Labo8api.Data;
using Labo8api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Labo8apiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Labo8apiContext") ?? throw new InvalidOperationException("Connection string 'Labo8apiContext' not found.")));

builder.Services.AddScoped<AnimalService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
