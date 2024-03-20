using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Console_Jeux.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_Console_JeuxContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_Console_JeuxContext") ?? throw new InvalidOperationException("Connection string 'API_Console_JeuxContext' not found.")));

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
