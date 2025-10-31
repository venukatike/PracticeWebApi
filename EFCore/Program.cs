using EFCore;
using Microsoft.EntityFrameworkCore;
using EFCore.MyProjectInfrastructure.Interface;
using EFCore.Data_DataAccessLayer.Data;
using EFCore.SharedServices_BussinessLayer.Interfaces;
using EFCore.SharedServices_BussinessLayer.Services;
using EFCore.API_ApiLayer.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IPatientService, PatientService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CustomMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
