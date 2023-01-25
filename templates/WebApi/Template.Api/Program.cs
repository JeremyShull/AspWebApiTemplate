using MultiValidation;
using Template.Api;
using Template.Api.Extensions;
using Template.ApplicationServices;
using Template.Domain;
using Template.Domain.Validators;
using Template.DomainServices;
using Template.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDomain();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure();
builder.Services.AddMultiValidation();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<GlobalExceptionHandler>();
builder.Services.AddSingleton<PersonIdValidator>();

builder.Services.AddSwaggerGen(options => {
    var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
    foreach (var assembly in loadedAssemblies)
    {
        var path = assembly.ToXmlPath();
        if (File.Exists(path))
            options.IncludeXmlComments(path);
    }
});

var app = builder.Build();

app.UseGlobalExceptionHandler();

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
