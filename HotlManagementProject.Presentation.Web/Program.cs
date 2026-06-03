using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Domain.Intefacies;
using HotelManagementProject.Repository.Extensions;
using HotelMangement_Service.Interfaces;
using HotelMangement_Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register the ProductService for Dependency Injection
builder.Services.AddInfrastructur();
builder.Services.AddScoped<IRoomService, RoomService>();
//builder.Services.AddTransient<IRoomService, RoomService>();
//builder.Services.AddSingleton<IRoomService, RoomService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
        
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
