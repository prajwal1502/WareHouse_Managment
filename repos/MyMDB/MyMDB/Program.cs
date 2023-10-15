using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyMDB.Data.EFCore;
using MyMDB.Data.Model;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyMDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyMDBContext") ?? throw new InvalidOperationException("Connection string 'MyMDBContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EfCoreMovieRepository>();
builder.Services.AddScoped<EfCoreStarRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("AngularApp"); // This should come after UseAuthorization
app.MapControllers();

app.Run();
