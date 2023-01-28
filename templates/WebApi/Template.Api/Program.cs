using MultiValidation;
using Template.Api;
using Template.Api.Extensions;
using Template.ApplicationServices;
using Template.Domain;
using Template.DomainServices;
using Template.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi();
builder.Services.AddDomain();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DataStorage"));
builder.Services.AddMultiValidation();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<GlobalExceptionHandler>();

builder.Services.AddSwagger();

var app = builder.Build();

app.UseGlobalExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
