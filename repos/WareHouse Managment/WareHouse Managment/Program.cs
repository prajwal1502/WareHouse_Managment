using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WareHouse_Managment.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using WareHouse_Managment.Service;
using WareHouse_Managment.Repositary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WareHouse_ManagmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WareHouse_ManagmentContext") ?? throw new InvalidOperationException("Connection string 'WareHouse_ManagmentContext' not found.")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IClothRepository, ClothRepository>();
builder.Services.AddScoped<IClothService, ClothService>();
builder.Services.AddScoped<IBOHService, BOHService>();
builder.Services.AddScoped<IBOHRepository, BOHRepository>();
builder.Services.AddScoped<IFOHService, FOHService>();
builder.Services.AddScoped<IFOHRepository, FOHRepository>();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "WareHouse Api",
        Version = "v1",
    });
});

// Add HttpClient configuration
builder.Services.AddHttpClient("MyApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7251/api/WareHouse"); // Replace with your API base URL.
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
 
builder.Services.AddCors(options =>
{
    options.AddPolicy("MY-APP",
        builder => builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware for development
    app.UseSwagger(c =>
    {
        c.SerializeAsV2 = true; // Ensure Swagger uses version 2 of the OpenAPI specification if needed.
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WareHouse");
        c.RoutePrefix = "swagger"; // Change this to your desired Swagger URL path.
    });
}

app.UseCors("MY-APP");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
