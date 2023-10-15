using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InvManagement1.Data;
using InvManagement1.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InvManagement1Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("InvManagementContext") ?? throw new InvalidOperationException("Connection string 'InvManagement1Context' not found.")));

// Add services to the container
 builder.Services.AddScoped<IServiceProduct, ServiceProduct>();
builder.Services.AddScoped<IServiceCatogory, ServiceCatogory>();
builder.Services.AddScoped<IServiceSupplier, ServiceSupplier>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen();

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
