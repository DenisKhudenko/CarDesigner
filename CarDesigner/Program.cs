using System.Reflection;
using CarDesigner.BL.Builders;
using CarDesigner.BL.Builders.Interfaces;
using CarDesigner.BL.Factories;
using CarDesigner.BL.Factories.Interfaces;
using CarDesigner.BL.Services;
using CarDesigner.BL.Services.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI для фабрики пресетов
builder.Services.AddScoped<IPresetFactory, PresetFactory>();
builder.Services.AddScoped<ICarFactory, SportcarFactory>();
builder.Services.AddScoped<ICarFactory, SUVFactory>();
builder.Services.AddScoped<ICarFactory, CoupeFactory>();

// DI для сервиса
builder.Services.AddScoped<ICarDesignerService, CarDesignerService>();

// DI для билдера
builder.Services.AddScoped<ICarBuilder, CarBuilder>();

// DI для хранения билдеров
builder.Services.AddSingleton<BuilderStorage>();

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CarDesigner",
        Version = "v1"
    });
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    
    if (File.Exists(xmlPath))
    {
        swagger.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swagger =>
    {
        swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "CarDesigner v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

