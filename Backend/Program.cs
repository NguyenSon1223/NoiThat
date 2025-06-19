using Backend.Data;
using Backend.Repository;
using Backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Scopped cho UnitOfWork

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();           // << Quan trọng cho Swagger
builder.Services.AddSwaggerGen();                     // << Thêm Swagger

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                                 // << Kích hoạt middleware Swagger
    app.UseSwaggerUI();                               // << Giao diện Swagger
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();
