using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Models;
using WebAPI.RepoImpl;
using WebAPI.RepoInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(c =>
{
    c.AddPolicy("CrossAccess", copl =>
    {
        copl.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddScoped<IDepartmentRepo, DepartmentImpl>();
builder.Services.AddScoped<IStaffRepo, StaffImpl>();
builder.Services.AddScoped<IStudentRepo, StudentImpl>();
builder.Services.AddScoped<ISemesterRepo, SemesterImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();

app.UseSwaggerUI( c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1");
});

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

