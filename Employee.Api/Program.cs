using EmployeeManagement.Api.Extentions;
using EmployeeManagement.Api.Middleware;
using EmployeeManagement.Api.Service;
using EmployeeManagement.Infrastructure.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var orgigin = builder.Configuration
                     .GetSection("AllowedOrigins")
                     .Get<string[]>()?? Array.Empty<string>();

// CORS Configuration for Production
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowEmployeeApp", policy =>
    {
        policy.WithOrigins(orgigin)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

Console.WriteLine($"Environment : {builder.Environment.EnvironmentName}");
Console.WriteLine($"Allowed Origin : {string.Join(", ",orgigin)}");

// Database connection String
var connectionString = builder.Configuration.GetConnectionString("EmployeeDbConnection")
            ?? throw new InvalidOperationException("connection string is not found");

builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


// Dependency Injection
builder.Services.ApplicaitionServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("AllowEmployeeApp");


app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();


