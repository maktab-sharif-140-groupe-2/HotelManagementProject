using HotelManagementProject.DataAccess.AppDbContextFile;
using HotelManagementProject.Repository.Extensions;
using HotelMangement_Service.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HotelManagementProject API",
        Version = "v1"
    });
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddServiceDependency();

var app = builder.Build();

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
