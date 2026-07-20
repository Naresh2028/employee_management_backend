using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Middleware;
using EmployeeManagement.Api.Service;
using EmployeeManagement.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Configuration
builder.Services.AddCors( options => 
{
    options.AddPolicy("AllowEmployeeApp", policy => 
    {
        policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

// Database connection String
var connectionString = builder.Configuration.GetConnectionString("EmployeeDbConnection")
            ?? throw new InvalidOperationException("connection string is not found");

builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


// Dependency Injection
builder.Services.AddScoped<IOrganizationService,OrganizationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowEmployeeApp");

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();


