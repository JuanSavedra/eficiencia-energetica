using Microsoft.EntityFrameworkCore;
using eficiência_energética.Data;
using eficiência_energética.Extensions;
using eficiência_energética.Interfaces;
using eficiência_energética.Repositories;
using eficiência_energética.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ISensorService, SensorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandlerMiddleware(); // Use custom exception handler
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
