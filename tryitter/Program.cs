using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using tryitter.Database;
using tryitter.Interfaces;
using tryitter.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentContext>();
builder.Services.AddScoped<IStudentsContext, StudentContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tryitter API",
        Description = "An ASP.NET Core Web API for managing posts",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Brenndha Cabral",
            Url = new Uri("https://www.linkedin.com/in/brenndhacabral/")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
