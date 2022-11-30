using tryitter.Database;
using tryitter.Interfaces;
using tryitter.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<StudentContext>();
builder.Services.AddScoped<IStudentsContext, StudentContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
