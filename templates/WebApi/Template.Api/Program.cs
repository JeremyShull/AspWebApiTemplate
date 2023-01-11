using Asp.Template.Api.Controllers;
using Microsoft.Extensions.PlatformAbstractions;
using System.Reflection;
using Template.ApplicationServices;
using Template.Domain;
using Template.DomainServices;
using Template.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDomain();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var basePath = PlatformServices.Default.Application.ApplicationBasePath;
var fileName = typeof(WeatherForecastController).GetTypeInfo().Assembly.GetName().Name + ".xml";
var XmlCommentsFilePath = Path.Combine(basePath, fileName);

builder.Services.AddSwaggerGen(options => {
    options.IncludeXmlComments(XmlCommentsFilePath);
});

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
