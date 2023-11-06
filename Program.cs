using Microsoft.EntityFrameworkCore;
using SensitiveWordsApi.Persistence.Context;
using SensitiveWordsApi.ServiceLayer;
using SensitiveWordsApi.ServiceLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISensitiveWordsService, SensitiveWordsService>();

//Dependency Injection of DBContext 
builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

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
